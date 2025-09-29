//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 卸NET-WEBサーバと送受信する処理クラス
// プログラム概要   : 卸NET-WEBサーバと送受信する処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LIUSY
// 作 成 日  2011/10/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LIUSY
// 作 成 日  2011/12/02  修正内容 : readmine 8432
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 堀田 剛生
// 作 成 日  2012/04/02  修正内容 : Httpリクエスト送信をDelphi5のDLLで実装する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸(アベールジャパン)
// 作 成 日  2012/04/10  修正内容 : Httpリクエスト送信部分を非同期で処理する
//　　　　　　　　　　　　　　　　　ように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 作 成 日  2012/06/19  修正内容 : 企業コードをセットする際、頭０をカットする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2012/07/13  修正内容 : 仕切単価の型をDoubleに変更（少数点以下を使用する為）
//                                  出荷伝票番号・Ｂ／Ｏ受付け番号をstringに変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高川 悟
// 作 成 日  2012/09/10  修正内容 : BL管理ユーザーコード対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 堀田 剛生
// 作 成 日  2012/12/06  修正内容 : 明治産業WEB　アドレス変更対応
//　　　　　　　　　　　　　　　　　①WebReferences参照先を変更
//　　　　　　　　　　　　　　　　　②①に伴う参照フォルダの変更
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2013/02/18  修正内容 : 2013/03/13配信分、Redmine#34610
//                                  発注先マスタのPGIDが「1003」接続タイプが「Aタイプ」
//                                  の場合に１つのXMLを作成して、毎にそのXMLを送信する。
//----------------------------------------------------------------------------//
// 管理番号  　　　　　  作成担当 : 櫻井 亮太
// 作 成 日  2014/03/04  修正内容 : 大和産業障害対応分
//                                  送信リクエストの問合せ番号の[From] [To] の間に
//                                  [&]を付加する
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 佐々木 貴英
// 作 成 日  2014/04/01  修正内容 : UOEリクエスト受信電文障害対応
//                                  リマーク及びラインリマークは受信XMLデータ
//                                  から取得するのではなく、送信電文データを
//                                  変換する際、一時的に退避した値を再セット
//                                  するよう修正
//----------------------------------------------------------------------------//
// 管理番号  11001634-00  作成担当 : 鄧潘ハン
// 作 成 日  K2014/05/26  修正内容 : 自動発注エラーメッセージを出さないように修正とエラーログの更新
//----------------------------------------------------------------------------//
// 管理番号  11275084-00  作成担当 : 田建委
// 作 成 日  2016/04/07   修正内容 : Redmine#48694 SPK仕入受信エラーの対応
//----------------------------------------------------------------------------//
// 管理番号  11201848-00  作成担当 : 田建委
// 作 成 日  2016/09/28   修正内容 : XML読み込み後、XMLオブジェクトの閉じるを行う
//----------------------------------------------------------------------------//
// 管理番号  11201849-00  作成担当 : 時シン
// 作 成 日  2016/10/11   修正内容 : Redmine#48880 オンライン番号ごと⇒納品区分ごとに送信を行う様に修正する
//----------------------------------------------------------------------------//
// 管理番号  11202049-00  作成担当 : 宋剛
// 作 成 日  2017/03/02   修正内容 : Redmine#48897 ＳＰＫ仕入受信処理修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using System.IO;
// 2012/12/06 ↓>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//using Broadleaf.Application.Controller.jp.mesaco.catalog;
using Broadleaf.Application.Controller.jp.mesaco.meijiweb;
// 2012/12/06 ↑>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
using System.Xml;
using System.Net;
using System.Web.Services;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Broadleaf.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using System.Threading;// ADD K2014/05/26 鄧潘ハン Redmine 42571
namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送受信データを変換し、Webサーバと送受信するクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 卸NET-WEBサーバと送受信する処理クラス</br>
    /// <br>Programmer	: LIUSY</br>
    /// <br>Date		: 2011/10/26</br>
    /// <br>Update Note : K2014/05/26 鄧潘ハン</br>
    /// <br>              自動発注エラーメッセージを出さないように修正とエラーログの更新</br>
    /// <br>Update Note : 2016/04/07 田建委</br>
    /// <br>              Redmine#48694 SPK仕入受信エラーの対応</br>
    /// <br>Update Note : 2016/09/28 田建委</br>
    /// <br>管理番号    : 11201848-00</br>
    /// <br>              Redmine#48879 XML読み込み後、XMLオブジェクトの閉じるを行う</br>
    /// <br>Update Note : 2016/10/11 時シン</br>
    /// <br>管理番号    : 11201849-00</br>
    /// <br>              Redmine#48880 オンライン番号ごと⇒納品区分ごとに送信を行う様に修正する</br>
    /// </remarks>
    public class NetWebClient : IUOEWebClient
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        //--- 2012/04/02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //HttpWebRequest request = null;
        //--- 2012/04/02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        private XmlWriter sendWriter;
        private XmlTextReader recvReader;
        private UOESupplier _uoeSupplier;

        private string fileName = "";
        private string fileRecName = "";
        private string fristGyoNo = "";
        private string lastGyoNo = "";
        private Dictionary<int, UoeRecDtl> UoeRecDtlDic = new Dictionary<int, UoeRecDtl>();
        private Dictionary<int, int> REQNODic = new Dictionary<int, int>();
        private Dictionary<string, string> MakerDic = new Dictionary<string, string>();
        //エラーフラグ
        private bool _errorFlag = false;
        // --- ADD 李亜博 2013/02/18 for Redmine#34610---------->>>>>
        //ＡタイプのＵＯＥ送信編集（明細）クラス
        private List<UoeSndDtl> _uoeSndDtlCopyList = new List<UoeSndDtl>();
        // --- ADD 李亜博 2013/02/18 for Redmine#34610----------<<<<<
        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
        /// <summary>
        /// リマーク格納連想配列
        /// </summary>
        private Dictionary<int, string> RemarkDic = new Dictionary<int, string>();

        /// <summary>
        /// ラインリマーク格納連想配列
        /// </summary>
        private Dictionary<int, string> ChkcdDic = new Dictionary<int, string>();
        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<

        // upd 2012/07/13 >>>
        //private NewDataSet2.PartsmanResponseTblDataTable _netRecvDataTable;
        private NewDataSet2.PartsmanResponseTbl1003DataTable _netRecvDataTable;
        // upd 2012/07/13 <<<
        private System.Data.DataSet dsResponse;
        private System.Data.DataTable tableresp;

        // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
        //メッセージセット関係
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_FuTaBa;//OPT-CPM0110：フタバUOEオプション（個別）

        //専用USB用
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<

        # endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region Const Members
        private const int DENBKB_35 = 35;
        private const int DENBKB_45 = 45;
        private const string ERROR_CODE_0 = "0";
        private const string ERROR_CODE_1 = "1";
        private const string ERROR_CODE_2 = "2";
        private const string ERROR_CODE_3 = "3";
        private const string REQUEST_ID = "BBB101";
        private const int DENBKB_60 = 60;
        private const string KUBUN_STOCK = "3";

        private const string SEND_DENBKB = "DENBKB";    //電文区分
        private const string SEND_GYONO = "GYONO";      //行番号
        private const string SEND_KUBUN = "KUBUN";      //処理区分
        private const string SEND_REQNO = "REQNO";      //電文問合せ番号
        private const string SEND_REQGYO = "REQGYO";    //伝票用行番号
        private const string SEND_REMARK = "REMARK";    //リマーク（備考）
        private const string SEND_NHNKB = "NHNKB";      //納品区分
        private const string SEND_HNSBT = "HNSBT";      //部品種別
        private const string SEND_JYUHNNO = "JYUHNNO";  //部品番号
        private const string SEND_MKCD = "MKCD";        //メーカーコード
        private const string SEND_JYUSU = "JYUSU";      //数量
        private const string SEND_BOKB = "BOKB";        //Ｂ／Ｏ区分
        private const string SEND_CHKCD = "CHKCD";      //ラインリマーク（備考）

        private const string RECV_UKENO = "UKENO";      //受付番号
        private const string RECV_DENBKB = "DENBKB";    //電文区分
        private const string RECV_KUBUN = "KUBUN";      //処理区分
        private const string RECV_GYONO = "GYONO";      //行番号
        private const string RECV_RESULT = "RESULT";    //処理結果
        private const string RECV_REQNO = "REQNO";      //電文問合せ番号
        private const string RECV_REQGYO = "REQGYO";    //伝票用行番号
        private const string RECV_REMARK = "REMARK";    //リマーク（備考）
        private const string RECV_NHNKB = "NHNKB";      //納品区分
        private const string RECV_HNSBT = "HNSBT";      //部品種別
        private const string RECV_JYUHNNO = "JYUHNNO";  //受注部品番号
        private const string RECV_SYUHNNO = "SYUHNNO";  //出荷部品番号
        private const string RECV_MKCD = "MKCD";        //メーカーコード
        private const string RECV_HINNM = "HINNM";      //品名
        private const string RECV_SHOTIK = "SHOTIK";    //定価
        private const string RECV_SKRTNK = "SKRTNK";    //仕切り単価
        private const string RECV_JYUSU = "JYUSU";      //受注数
        private const string RECV_SYUSU = "SYUSU";      //出荷数
        private const string RECV_BOKB = "BOKB";        //Ｂ／Ｏ区分
        private const string RECV_BOSU = "BOSU";        //Ｂ／Ｏ数
        private const string RECV_SYUNO = "SYUNO";      //出荷伝票番号
        private const string RECV_BOUKENO = "BOUKENO";  //Ｂ／Ｏ受付け番号
        private const string RECV_CHKCD = "CHKCD";      //ラインリマーク（備考）
        private const string RECV_LINERR = "LINERR";    //ラインメッセージ
        private const string RECV_UKEYMD = "UKEYMD";    //受付日付
        private const string RECV_SDATE = "SDATE";      //作成日付
        private const string RECV_STIME = "STIME";      //作成時間

        private const string STRING_CHANGE_ROW = "\r\n";
        private const string SAVE_XML_NAME = "PMUOE09020U_Maker.xml";
        private const string STRING_BOUNDARY = "-----------------------------7d21cef303f8";
        private const int ERROR_SUCCESS = 0;
        // --- ADD 李亜博 2013/02/18 for Redmine#34610---------->>>>>
        private const string FILESPKSEND = "\\SPKSEND.TXT";
        private const string FILESPKRECV = "\\SPKRECV.TXT";
        // --- ADD 李亜博 2013/02/18 for Redmine#34610----------<<<<<
        # endregion

        #region API定義 2012/04/02 使用していないため削除
        //[DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        //private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        //[DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        //private static extern int InternetAttemptConnect(int dwReserved);
        #endregion

        //　2012/04/02　add　Httpリクエスト送信をDelphi5のDLLで実装する >>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region Delphi5のリクエストメソッド呼び出し
        [DllImport("PMPU9013.dll")]
        public extern static int xPMPU9013(string addres1,         //----接続先アドレスのドメイン部分をセット
                                           string addres2,         //----接続先アドレスのドメイン以下の部分をセット
                                           string usrname,         //----接続する際のユーザーIDをセット
                                           string password,        //----接続する際のパスワードをセット
                                           string filepath,        //----送信XMLの格納先をセット
                                           int ssl,                //----プロトコル[0:HTTP 1:HTTPS]
                                           int netflg,             //----接続タイプ[0:Atype 1:Btype 2:Ctype]
                                           string usercode,        //----BL管理のユーザーコードをセット(企業コード)
                                           int timeout,            //----タイム時間の値をセット
                                           string nonce,           //----nonceの設定
                                           string created,         //----createdの設定
                                           string sha1,            //----sha1変換後の文字列設定
                                           int irecv,              //----仕入受信判定フラグ「0：通常、1：仕入受信」
                                           int irecr,              //----復旧判定フラグ「0：通常、1：復旧」
                                           ref int errkbn);        //----エラー区分。
        #endregion
        //　2012/04/02　add　Httpリクエスト送信をDelphi5のDLLで実装する <<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors

        /// <summary>
        /// Webサーバと送受信する処理クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : Webサーバと送受信する処理クラスの初期化を行う。</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: K2014/05/26 鄧潘ハン</br>
        /// <br>             自動発注エラーメッセージを出さないように修正とエラーログの更新</br>
        /// </remarks>
        public NetWebClient(UOESupplier uoeSupplier)
        {
            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
            //OPT-CPM0110：フタバUOEオプション（個別）
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<
            this._uoeSupplier = uoeSupplier;
        }
        # endregion

        #region IUOEWebClient メンバ

        /// <summary>
        /// Webサーバと送受信します。
        /// </summary>
        /// <param name="uoeSendingData"></param>
        /// <param name="isReceivingStock"></param>
        /// <param name="uoeReceivedData"></param>
        /// <param name="errorMessage"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : Webサーバと送受信する処理を行う。</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2013/02/18 李亜博</br>
        ///	<br>			 2013/03/13配信分、Redmine#34610</br>
        ///	<br>			 発注先マスタのPGIDが「1003」接続タイプが「Aタイプ」</br>
        ///	<br>             の場合に１つのXMLを作成して、毎にそのXMLを送信する。</br> 
        /// <br>Update Note: K2014/05/26 鄧潘ハン</br>
        /// <br>             自動発注エラーメッセージを出さないように修正とエラーログの更新</br>
        /// <br>Update Note: 2016/04/07 田建委</br>
        /// <br>             Redmine#48694 SPK仕入受信エラーの対応</br>
        /// <br>Update Note: 2016/10/11 時シン</br>
        /// <br>管理番号   : 11201849-00</br>
        /// <br>             Redmine#48880 オンライン番号ごと⇒納品区分ごとに送信を行う様に修正する</br>
        /// </remarks>
        public int SendAndReceive(UoeSndHed uoeSendingData, bool isReceivingStock, out UoeRecHed uoeReceivedData, out string errorMessage)
        {

            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
            //フタバUSB専用:Option.ON
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                //メッセージを取得
                msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
            }
            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<
            uoeReceivedData = new UoeRecHed();
            errorMessage = string.Empty;
            //リクエスト送信
            //--- 2012/04/02 削除 >>>>>>>>>>>>>>>>>
            //bool Ist = false;
            //--- 2012/04/02 削除 <<<<<<<<<<<<<<<<<
            //エラーフラグ
            string address = "";
            IntPtr lpBuffer = IntPtr.Zero;
            int status = 0;
            string errorCode = ERROR_CODE_1;
            //--- 2012/04/02 追加と削除 >>>>>>>>>>>>>>>>>
            //string myString = ""; ;
            //string content = "";
            //string fileRecStream = "";
            int errkbn = 0;
            int irecv = 0;
            int irecr = 0;
            string nonce = "";
            string created = "";
            string password = "";
            //--- 2012/04/02 追加と削除 <<<<<<<<<<<<<<<<<


            //アドレス判定
            //エラーフラグOFF
            if (_errorFlag == false)
            {
                //仕入受信フラグON：発注先マスタ仕入受信アドレス
                if (isReceivingStock)
                {
                    address = _uoeSupplier.UOELoginUrl;             //発注先マスタの仕入受信アドレス
                    //--- 2012/04/02 仕入受信判定フラグ >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    irecv = 1;
                    //--- 2012/04/02 仕入受信判定フラグ <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                //上記以外：通常アドレス
                else
                {
                    address = _uoeSupplier.UOEStockCheckUrl;        //発注先マスタの通常発注アドレス
                    //--- 2012/04/02 仕入受信判定フラグ >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    irecv = 0;
                    //--- 2012/04/02 仕入受信判定フラグ <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                //--- 2012/04/02 復旧フラグ >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                irecr = 0;
                //--- 2012/04/02 復旧フラグ <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            //エラーフラグON：発注先マスタ復旧アドレス
            else
            {
                address = _uoeSupplier.UOEForcedTermUrl; //発注先マスタの復旧確認アドレス
                //--- 2012/04/02 仕入受信判定フラグ と　復旧フラグ　>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                irecv = 0;
                irecr = 1;
                //--- 2012/04/02 仕入受信判定フラグ と　復旧フラグ　<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            //---　2012/04/02　Delphi5のDLLを呼び出す。>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region 削除したロジックが多いため表示上カットする。
            /*
            // 回線オープン処理
            if (RequestOpen(this._uoeSupplier.DaihatsuOrdreDiv, address))
            {
                HttpWebResponse response = null;
                try
                {
                    // 送信電文データをXMLファイルに変換する
                    content = ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);

                    myString += STRING_BOUNDARY;
                    myString += STRING_CHANGE_ROW;
                    myString += "Content-Disposition: form-data; name=\"xml_data\"; ";
                    myString += "filename=\"" + fileName + "\"";
                    myString += STRING_CHANGE_ROW;
                    myString += STRING_CHANGE_ROW;

                    errorCode = ERROR_CODE_0;

                    myString = myString + content + STRING_CHANGE_ROW + STRING_BOUNDARY + "--" + STRING_CHANGE_ROW;



                    byte[] body = Encoding.ASCII.GetBytes(myString);
                    //request.ContentLength = body.LongLength;

                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(body, 0, body.Length);
                        reqStream.Close();
                    }
                    using (response = (HttpWebResponse)request.GetResponse())
                    {

                        Stream revStream = response.GetResponseStream();
                        StreamReader sr = new StreamReader(revStream, Encoding.GetEncoding(932));
                        fileRecStream = sr.ReadToEnd();

                    }
                }
                catch (WebException ex)
                {
                    if (ex.Response != null)
                    {
                        HttpWebResponse res = (HttpWebResponse)ex.Response;
                        int statusCode = (int)res.StatusCode;
                        errorMessage = "ﾃﾞｰﾀ送受信中にｴﾗｰが発生(" + ex.Message + ")";

                        if (!_errorFlag && !isReceivingStock)
                        {
                            TMsgDisp.Show(null,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "",
                                errorMessage,
                                status,
                                MessageBoxButtons.OK);
                        }
                        if (!isReceivingStock && !_errorFlag)
                        {
                            _errorFlag = true;
                            string errorMessageTemp = "";
                            status = SendAndReceive(uoeSendingData, isReceivingStock, out uoeReceivedData, out errorMessageTemp);
                            if (errorMessageTemp != string.Empty)
                            {
                                errorMessage = errorMessageTemp;
                            }
                        }
                        if (isReceivingStock)
                        {
                            //最初に空明細の作成「開局と偽る」　

                            byte[] toByteArray = new byte[256];
                            UoeRecDtl uoeRecDtlEmply = new UoeRecDtl();
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            //
                            uoeRecDtlEmply = new UoeRecDtl();
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            //最終に空明細の作成「開局と偽る」
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                        }
                        return status;
                    }
                    errorMessage = ex.Message;
                    status = -1;
                    return status;
                }
                response.Close();
                try
                {

                    //Recファイル作成

                    if (fileRecStream == string.Empty)
                    {
                        if (!isReceivingStock)
                        {
                            status = -1;
                            errorMessage = "ﾃﾞｰﾀ受信中にｴﾗｰが発生(受信ファイル内容がありません) ";
                            return status;
                        }
                        else
                        {
                            //最初に空明細の作成「開局と偽る」　

                            byte[] toByteArray = new byte[256];
                            UoeRecDtl uoeRecDtlEmply = new UoeRecDtl();
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            //
                            uoeRecDtlEmply = new UoeRecDtl();
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            //最終に空明細の作成「開局と偽る」
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);
                            return status;
                        }
                    }
                    //Aタイプ
                    if (this._uoeSupplier.InqOrdDivCd == 0)
                    {
                        fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\SPKRECV.XML";
                    }
                    // B,C
                    else if (this._uoeSupplier.InqOrdDivCd != 0)
                    {
                        fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECV.XML";
                    }

                    FileStream file = new FileStream(fileRecName, FileMode.Create);

                    file.Write(Encoding.UTF8.GetBytes(fileRecStream), 0, Encoding.UTF8.GetByteCount(fileRecStream));
                    file.Close();
                }
                catch (Exception ex)
                {
                    status = -1;
                    return status;
                }
            }
            else
            {
                status = -1;
                return status;
            }
            if (errorCode == ERROR_CODE_0)
            {

                // Webサービスからの戻り値を受信電文データに変換する 
                ConvertXMLToUoeSndHed(uoeSendingData, isReceivingStock, errorCode, this._uoeSupplier.InqOrdDivCd, ref uoeReceivedData);
            }
            */
            #endregion

            try
            {
                // --- ADD 李亜博 2013/02/18 for Redmine#34610---------->>>>>
                string fileNameSend = string.Empty;
                string fileNameRecv = string.Empty;
                string xmlFileSendString = string.Empty;
                string xmlFileRecvString = string.Empty;
                FileStream fileSend = null;
                FileStream fileRecv = null;
                //B,Cタイプ OR 復旧送信を実行
                if (this._uoeSupplier.InqOrdDivCd != 0 || _errorFlag == true)
                {
                    //Aタイプ復旧
                    if (this._uoeSupplier.InqOrdDivCd == 0)
                    {
                        //SPKSEND.TXTとSPKRECV.TXTファイルのパースを取得する。
                        fileNameSend = System.IO.Directory.GetCurrentDirectory() + FILESPKSEND;
                        fileNameRecv = System.IO.Directory.GetCurrentDirectory() + FILESPKRECV;
                        //ファイルストリームの作成
                        fileSend = new FileStream(fileNameSend, FileMode.Append, FileAccess.Write);
                        fileRecv = new FileStream(fileNameRecv, FileMode.Append, FileAccess.Write);

                        // 送信電文データをXMLファイルに変換する
                        xmlFileSendString = ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);

                        //SPKSEND.TXTファイルにデータを書き込む。
                        if (!string.IsNullOrEmpty(xmlFileSendString))
                        {
                            fileSend.Write(Encoding.Default.GetBytes(xmlFileSendString), 0, Encoding.Default.GetByteCount(xmlFileSendString));
                            fileSend.Flush();
                        }
                    }
                    else
                    {
                        // 送信電文データをXMLファイルに変換する
                        ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);
                    }
                // --- ADD 李亜博 2013/02/18 for Redmine#34610----------<<<<<
                    // --- DEL 李亜博 2013/02/18 for Redmine#34610---------->>>>>
                    //// 送信電文データをXMLファイルに変換する
                    //ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);
                    // --- DEL 李亜博 2013/02/18 for Redmine#34610----------<<<<<

                    //---WSSE必要情報の取得　nonce,created,password
                    nonce = CreateNonce();
                    created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");
                    password = _uoeSupplier.UOEConnectPassword;

                    //---Delphi Methodの呼び出し
                    // UPD START 2012/04/10
                    //status =xPMPU9013(_uoeSupplier.UOEOrderUrl,                                                       //---ドメイン
                    //                  address.Substring(address.Length - (address.Length - 1)),                       //---ドメイン以下のアドレス
                    //                  _uoeSupplier.UOEConnectUserId,                                                  //---接続先のID
                    //                  password,                                                                       //---接続先のパスワード
                    //                  System.IO.Directory.GetCurrentDirectory(),                                      //---送信XMLのファイルパス
                    //                  _uoeSupplier.DaihatsuOrdreDiv,                                                  //---プロトコル
                    //                  _uoeSupplier.InqOrdDivCd,                                                       //---送信先タイプ
                    //                  _uoeSupplier.EnterpriseCode.Substring(_uoeSupplier.EnterpriseCode.Length - 9),  //---企業コードの末尾
                    //                  _uoeSupplier.LoginTimeoutVal * 1000,                                            //---タイムアウト
                    //                  nonce,                                                                          //---nonceをセット
                    //                  created,                                                                        //---Createdをセット
                    //                  GetDigest(String.Format("{0}{1}{2}", nonce, created, password)),                //---Passwordをセット
                    // irecv,                                                                          //---仕入受信判定フラグ
                    //                  irecr,                                                                          //---復旧フラグ
                    //                  ref errkbn);                                                                    //---エラーメッセージ
                    xPMPU9013AsyncCall caller = xPMPU9013Async;
                    IAsyncResult result = caller.BeginInvoke(address, password, nonce, created, irecv, irecr, ref errkbn, null, null);  //非同期呼び出し開始

                    // 非同期処理が終了するまでスレッド待機
                    // マウス操作などを受け付けない
                    // 同期呼び出しの様に動作する、「応答なし」にはならない
                    // 下の WaitOne を採用する場合は、その下の while 文はコメントにする
                    //result.AsyncWaitHandle.WaitOne();

                    // 非同期処理が終了するまでループ（ポーリング）する
                    // マウス操作など可能
                    while (!result.IsCompleted)
                    {
                        System.Windows.Forms.Application.DoEvents(); 
                        System.Threading.Thread.Sleep(100);
                    }

                    status = caller.EndInvoke(ref errkbn, result);  // 非同期処理終了
                    // UPD END   2012/04/10

                    //---エラー判定　status=0は正常終了。
                    if (status == 0)
                    {
                        // Webサービスからの戻り値を受信電文データに変換する 
                        ConvertXMLToUoeSndHed(uoeSendingData, isReceivingStock, errorCode, this._uoeSupplier.InqOrdDivCd, ref uoeReceivedData);
                        // --- ADD 李亜博 2013/02/18 for Redmine#34610---------->>>>>
                        //Aタイプ復旧
                        if (this._uoeSupplier.InqOrdDivCd == 0)
                        {
                             //受信電文データの読み込む。
                            xmlFileRecvString = ReadXML(fileRecName);

                            //SPKRECV.TXTファイルにデータを書き込む。
                            if (!string.IsNullOrEmpty(xmlFileRecvString))
                            {
                                //SPKRECV.TXTファイルにデータを書き込む。
                                fileRecv.Write(Encoding.Default.GetBytes(xmlFileRecvString), 0, Encoding.Default.GetByteCount(xmlFileRecvString));
                                fileRecv.Flush();
                            }
                        }
                        // --- ADD 李亜博 2013/02/18 for Redmine#34610----------<<<<<
                    }
                    else
                    {
                        //エラーメッセージの生成
                        if (status == 1)
                        {
                            switch (errkbn)
                            {
                                case 1: { errorMessage = "回線オープンエラー(AttemptConnect)"; break; }
                                case 2: { errorMessage = "回線オープンエラー(Opent)"; break; }
                                case 3: { errorMessage = "回線オープンエラー(Connect)"; break; }
                                case 4: { errorMessage = "回線オープンエラー(HttpOpenRequest)"; break; }
                                case 5: { errorMessage = "回線オープンエラー(SetOption)"; break; }
                            }

                        }
                        else if (status == 2)
                        {
                            errorMessage = "データ送信中にエラーが発生(SendRequest) " + errkbn.ToString();
                        }
                        else if (status == 3)
                        {
                            errorMessage = "データ送信中にエラーが発生 " + errkbn.ToString();
                        }

                        // --- ADD 李亜博 2013/02/18 for Redmine#34610---------->>>>>
                        //Aタイプ復旧
                        if (this._uoeSupplier.InqOrdDivCd == 0)
                        {
                            //ファイルストリームを閉じる。
                            fileSend.Close();
                            fileRecv.Close();
                        }
                        // --- ADD 李亜博 2013/02/18 for Redmine#34610----------<<<<<
                        //通常送信でエラーが発生した場合は、エラーメッセージ表示後復旧送信を実行
                        if (!isReceivingStock && !_errorFlag)
                        {

                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
                            //TMsgDisp.Show(null,
                            //              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            //              "",
                            //              errorMessage,
                            //              status,
                            //              MessageBoxButtons.OK);
                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<

                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
                            if (this._opt_FuTaBa == (int)Option.ON)
                            {
                                //卸商発注処理(自動)ではない
                                if (!(Thread.GetData(msgShowSolt) != null
                                    && (Int32)Thread.GetData(msgShowSolt) == 1))
                                {
                                    TMsgDisp.Show(null,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      "",
                                      errorMessage,
                                      status,
                                      MessageBoxButtons.OK);

                                }
                            }
                            else
                            {
                                TMsgDisp.Show(null,
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   "",
                                   errorMessage,
                                   status,
                                   MessageBoxButtons.OK);

                            }
                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<

                            _errorFlag = true;
                            string errorMessageTemp = "";
                            status = SendAndReceive(uoeSendingData, isReceivingStock, out uoeReceivedData, out errorMessageTemp);
                            if (errorMessageTemp != string.Empty)
                            {
                                errorMessage = errorMessageTemp;
                            }
                        }

                        //仕入受信でエラーが発生した場合は、空明細を作成して終了
                        if (isReceivingStock)
                        {
                            //最初に開局要求明細の作成
                            byte[] toByteArray = new byte[256];
                            UoeRecDtl uoeRecDtlEmply = new UoeRecDtl();
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                            //空明細の作成
                            uoeRecDtlEmply = new UoeRecDtl();
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                            //最終に閉局要求明細の作成
                            uoeRecDtlEmply.RecTelegram = toByteArray;
                            uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                            uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                            //--- status4は該当データなしなので、正常処理とする。
                            if (status == 4)
                            {
                                status = 0;
                            }
                        }
                        return status;
                    }
                  // --- ADD 李亜博 2013/02/18 for Redmine#34610---------->>>>>
                    //Aタイプ復旧
                    if (this._uoeSupplier.InqOrdDivCd == 0)
                    {
                        //ファイルストリームを閉じる。
                        fileSend.Close();
                        fileRecv.Close();
                    }
                }
                //Aタイプ
                else
                {
                     //SPKSEND.TXTとSPKRECV.TXTファイルのパースを取得する。
                     fileNameSend = System.IO.Directory.GetCurrentDirectory() + FILESPKSEND;
                     fileNameRecv = System.IO.Directory.GetCurrentDirectory() + FILESPKRECV;
                     //ファイルストリームの作成
                     fileSend = new FileStream(fileNameSend, FileMode.Create, FileAccess.Write);
                     fileRecv = new FileStream(fileNameRecv, FileMode.Create, FileAccess.Write);
                    
                    _uoeSndDtlCopyList = uoeSendingData.UoeSndDtlList;
                    
                    password = _uoeSupplier.UOEConnectPassword;

                    //----- ADD 2016/10/11 時シン Redmine#48880 オンライン番号ごと⇒納品区分ごとに送信を行う様に修正する ----->>>>>
                    // 納品区分
                    string noHinDiv = string.Empty;

                    // 電文情報
                    byte[] messageByte;
                    Dictionary<string, List<UoeSndDtl>> resultUoeDtlDic = new Dictionary<string, List<UoeSndDtl>>();

                    // 納品区分ごとにグループとする
                    for (int i = 1; i < _uoeSndDtlCopyList.Count - 1; i++)
                    {
                        // 納品区分
                        noHinDiv = string.Empty;
                        // 電文
                        messageByte = _uoeSndDtlCopyList[i].SndTelegram;
                        // オンライン番号毎に電文から、納品区分を取得する
                        UoeCommonFnc.MemCopy(ref noHinDiv, ref messageByte, 26, 1);

                        if (resultUoeDtlDic.ContainsKey(noHinDiv))
                        {
                            resultUoeDtlDic[noHinDiv].Add(_uoeSndDtlCopyList[i]);
                        }
                        else
                        {
                            List<UoeSndDtl> uoeDtlList = new List<UoeSndDtl>();
                            uoeDtlList.Add(_uoeSndDtlCopyList[i]);
                            resultUoeDtlDic.Add(noHinDiv, uoeDtlList);
                        }
                    }
                    //----- ADD 2016/10/11 時シン Redmine#48880 オンライン番号ごと⇒納品区分ごとに送信を行う様に修正する -----<<<<<

                    //----- UPD 2016/10/11 時シン Redmine#48880 オンライン番号ごと⇒納品区分ごとに送信を行う様に修正する ----->>>>>
                    //for (int i = 1; i < _uoeSndDtlCopyList.Count - 1; i++)
                    //{
                    //    //送信情報をXMLに変換する際、オンライン番号毎に作成するようにする。
                    //    uoeSendingData.UoeSndDtlList = new List<UoeSndDtl>();
                    //    uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[0]);
                    //    uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[i]);
                    //    uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[_uoeSndDtlCopyList.Count - 1]);
                    foreach (string uoeDtlKey in resultUoeDtlDic.Keys)
                    {                        
                        //送信情報をXMLに変換する際、納品区分毎に作成するようにする。
                        uoeSendingData.UoeSndDtlList = new List<UoeSndDtl>();
                        uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[0]);
                        uoeSendingData.UoeSndDtlList.AddRange(resultUoeDtlDic[uoeDtlKey]);
                        uoeSendingData.UoeSndDtlList.Add(_uoeSndDtlCopyList[_uoeSndDtlCopyList.Count - 1]);
                    //----- UPD 2016/10/11 時シン Redmine#48880 オンライン番号ごと⇒納品区分ごとに送信を行う様に修正する -----<<<<<

                        if (sendWriter != null)
                        {
                            sendWriter = null;
                        }

                        // 送信電文データをXMLファイルに変換する
                        xmlFileSendString = ConvertUoeSndHedToXML(uoeSendingData, isReceivingStock, this._uoeSupplier.InqOrdDivCd);

                        //SPKSEND.TXTファイルにデータを書き込む。
                        if (!string.IsNullOrEmpty(xmlFileSendString))
                        {
                            fileSend.Write(Encoding.Default.GetBytes(xmlFileSendString + STRING_CHANGE_ROW), 0, Encoding.Default.GetByteCount(xmlFileSendString + STRING_CHANGE_ROW));
                            fileSend.Flush();
                        }
                        //---WSSE必要情報の取得　nonce,created,password
                        nonce = CreateNonce();
                        created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");

                        xPMPU9013AsyncCall caller = xPMPU9013Async;
                        IAsyncResult result = caller.BeginInvoke(address, password, nonce, created, irecv, irecr, ref errkbn, null, null);  //非同期呼び出し開始

                        // 非同期処理が終了するまでスレッド待機
                        // マウス操作などを受け付けない
                        // 同期呼び出しの様に動作する、「応答なし」にはならない
                        // 下の WaitOne を採用する場合は、その下の while 文はコメントにする
                        //result.AsyncWaitHandle.WaitOne();

                        // 非同期処理が終了するまでループ（ポーリング）する
                        // マウス操作など可能
                        while (!result.IsCompleted)
                        {
                            System.Windows.Forms.Application.DoEvents();
                            System.Threading.Thread.Sleep(100);
                        }

                        status = caller.EndInvoke(ref errkbn, result);  // 非同期処理終了

                        //---エラー判定　status=0は正常終了。
                        if (status == 0)
                        {
                            //XMLファイル作成
                            if (recvReader != null)
                            {
                                recvReader = null;
                            }
                            //----- UPD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 ----->>>>>
                            //MakeXMLFile(this._uoeSupplier.InqOrdDivCd);
                            MakeXMLFile(this._uoeSupplier.InqOrdDivCd, isReceivingStock);
                            //----- UPD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 -----<<<<<

                            //受信電文データの読み込む。
                            xmlFileRecvString = ReadXML(fileRecName);

                            //SPKRECV.TXTファイルにデータを書き込む。
                            if (!string.IsNullOrEmpty(xmlFileRecvString))
                            {
                                fileRecv.Write(Encoding.Default.GetBytes(xmlFileRecvString + STRING_CHANGE_ROW), 0, Encoding.Default.GetByteCount(xmlFileRecvString + STRING_CHANGE_ROW));
                                fileRecv.Flush();
                            }
                            continue;
                        }
                        else
                        {
                            //エラーメッセージの生成
                            if (status == 1)
                            {
                                switch (errkbn)
                                {
                                    case 1: { errorMessage = "回線オープンエラー(AttemptConnect)"; break; }
                                    case 2: { errorMessage = "回線オープンエラー(Opent)"; break; }
                                    case 3: { errorMessage = "回線オープンエラー(Connect)"; break; }
                                    case 4: { errorMessage = "回線オープンエラー(HttpOpenRequest)"; break; }
                                    case 5: { errorMessage = "回線オープンエラー(SetOption)"; break; }
                                }

                            }
                            else if (status == 2)
                            {
                                errorMessage = "データ送信中にエラーが発生(SendRequest) " + errkbn.ToString();
                            }
                            else if (status == 3)
                            {
                                errorMessage = "データ送信中にエラーが発生 " + errkbn.ToString();
                            }
                            //ファイルストリームを閉じる。
                            fileSend.Close();
                            fileRecv.Close();

                            //通常送信でエラーが発生した場合は、エラーメッセージ表示後復旧送信を実行
                            if (!isReceivingStock && !_errorFlag)
                            {
                                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
                                //TMsgDisp.Show(null,
                                //              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                //              "",
                                //              errorMessage,
                                //              status,
                                //              MessageBoxButtons.OK);
                                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<

                                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
                                if (this._opt_FuTaBa == (int)Option.ON)
                                {
                                    //卸商発注処理(自動)ではない
                                    if (!(Thread.GetData(msgShowSolt) != null
                                        && (Int32)Thread.GetData(msgShowSolt) == 1))
                                    {
                                        TMsgDisp.Show(null,
                                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                             "",
                                             errorMessage,
                                             status,
                                             MessageBoxButtons.OK);

                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(null,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            "",
                                            errorMessage,
                                            status,
                                            MessageBoxButtons.OK);

                                }
                                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<
                                _errorFlag = true;
                                string errorMessageTemp = "";

                                uoeSendingData.UoeSndDtlList = _uoeSndDtlCopyList;

                                status = SendAndReceive(uoeSendingData, isReceivingStock, out uoeReceivedData, out errorMessageTemp);
                                if (errorMessageTemp != string.Empty)
                                {
                                    errorMessage = errorMessageTemp;
                                }
                            }

                            //仕入受信でエラーが発生した場合は、空明細を作成して終了
                            if (isReceivingStock)
                            {
                                //最初に開局要求明細の作成
                                byte[] toByteArray = new byte[256];
                                UoeRecDtl uoeRecDtlEmply = new UoeRecDtl();
                                uoeRecDtlEmply.RecTelegram = toByteArray;
                                uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                                //空明細の作成
                                uoeRecDtlEmply = new UoeRecDtl();
                                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                                //最終に閉局要求明細の作成
                                uoeRecDtlEmply.RecTelegram = toByteArray;
                                uoeRecDtlEmply.RecTelegramLen = uoeRecDtlEmply.RecTelegram.Length;
                                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtlEmply);

                                //--- status4は該当データなしなので、正常処理とする。
                                if (status == 4)
                                {
                                    status = 0;
                                }
                            }
                            return status;
                        }

                    }
                    //ファイルストリームを閉じる。
                    fileSend.Close();
                    fileRecv.Close();

                    uoeSendingData.UoeSndDtlList = _uoeSndDtlCopyList;
                    // Webサービスからの戻り値を受信電文データに変換する 
                    ConvertAtypeXMLToUoeSndHed(uoeSendingData, isReceivingStock, ref uoeReceivedData);
                }
                // --- ADD 李亜博 2013/02/18 for Redmine#34610----------<<<<<
            }
            catch (Exception ex)
            {
                //---例外対応
                status = 999;
                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
                //TMsgDisp.Show(null,
                //              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //              "",
                //              ex.Message,
                //              status,
                //              MessageBoxButtons.OK);
                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<

                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
                if (this._opt_FuTaBa == (int)Option.ON)
                {
                    //卸商発注処理(自動)ではない
                    if (!(Thread.GetData(msgShowSolt) != null
                        && (Int32)Thread.GetData(msgShowSolt) == 1))
                    {
                        TMsgDisp.Show(null,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             "",
                             ex.Message,
                             status,
                             MessageBoxButtons.OK);

                    }
                }
                else
                {
                    TMsgDisp.Show(null,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "",
                                ex.Message,
                                status,
                                MessageBoxButtons.OK);

                }
                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<
                return status;
            }
            //---　2012/04/02　Delphi5のDLLを呼び出す。 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        // ADD START 2012/04/10
        /// <summary>
        /// Delphi Methodの呼び出しのデリゲート
        /// </summary>
        /// <param name="address"></param>
        /// <param name="password"></param>
        /// <param name="nonce"></param>
        /// <param name="created"></param>
        /// <param name="irecv"></param>
        /// <param name="irecr"></param>
        /// <param name="errkbn"></param>
        /// <returns>非同期デリゲートの定義</returns>
        delegate int xPMPU9013AsyncCall(string address, string password, string nonce, string created, int irecv, int irecr, ref int errkbn);
        /// <summary>
        /// Delphi Methodの呼び出し
        /// </summary>
        /// <param name="address"></param>
        /// <param name="password"></param>
        /// <param name="nonce"></param>
        /// <param name="created"></param>
        /// <param name="irecv"></param>
        /// <param name="irecr"></param>
        /// <param name="errkbn"></param>
        /// <returns>同期メソッドを非同期呼び出しする為</returns>
        private int xPMPU9013Async(string address, string password, string nonce, string created, int irecv, int irecr, ref int errkbn)
        {
            return xPMPU9013(_uoeSupplier.UOEOrderUrl,                                                        //---ドメイン
                              address.Substring(address.Length - (address.Length - 1)),                       //---ドメイン以下のアドレス
                              _uoeSupplier.UOEConnectUserId,                                                  //---接続先のID
                              password,                                                                       //---接続先のパスワード
                              System.IO.Directory.GetCurrentDirectory(),                                      //---送信XMLのファイルパス
                              _uoeSupplier.DaihatsuOrdreDiv,                                                  //---プロトコル
                              _uoeSupplier.InqOrdDivCd,                                                       //---送信先タイプ
                // ----- DEL 2012/06/19 xupz --------->>>>>
                //_uoeSupplier.EnterpriseCode.Substring(_uoeSupplier.EnterpriseCode.Length - 9),  //---企業コードの末尾 
                // ----- DEL 2012/06/19 xupz ---------<<<<<
                // ----- ADD 2012/06/19 xupz --------->>>>>
                //企業コードをセットする際、頭０をカットする
                              // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                              //_uoeSupplier.EnterpriseCode.Substring(_uoeSupplier.EnterpriseCode.Length - 9).TrimStart('0'),  //---企業コードの末尾 
                              _uoeSupplier.BLMngUserCode,                                                     //BL管理ユーザーコード
                              // 2012/09/10 UPD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                // ----- ADD 2012/06/19 xupz ---------<<<<<
                              _uoeSupplier.LoginTimeoutVal * 1000,                                            //---タイムアウト
                              nonce,                                                                          //---nonceをセット
                              created,                                                                        //---Createdをセット
                              GetDigest(String.Format("{0}{1}{2}", nonce, created, password)),                //---Passwordをセット
                              irecv,                                                                          //---仕入受信判定フラグ
                              irecr,                                                                          //---復旧フラグ
                              ref errkbn);                                                                    //---エラーメッセージ
        }
        // ADD END   2012/04/10

        /// -+<summary>
        /// 送信電文データをWebサービス用パラメータに変換する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信電文データをWebサービス用パラメータに変換する</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private string ConvertUoeSndHedToXML(UoeSndHed uoeSendingData, bool isReceivingStock, int InqOrdDivCd)
        {
            //--- 2012/04/02 削除　この部分の処理はDelphi5で実装するため >>>>>>>>>>>>>>>>>>>>
            //// ヘッダ情報追加
            //HeaderMake(this._uoeSupplier, InqOrdDivCd);
            //--- 2012/04/02 削除　この部分の処理はDelphi5で実装するため <<<<<<<<<<<<<<<<<<<<

            string xmlFileString = "";
            if (_errorFlag == false)
            {   // 要求情報の設定
                SetNetsendXML(uoeSendingData, isReceivingStock, InqOrdDivCd);
                xmlFileString = fileChange();
            }
            else
            {
                // --- DEL 櫻井亮太 2014/03/04---------->>>>>
                // add by liusy 2011/12/02 --------->>>>>>>
                //xmlFileString = "from=" + fristGyoNo + "to=" + lastGyoNo;
                //if (InqOrdDivCd == 0)
                //{

                //    fileName = System.IO.Directory.GetCurrentDirectory() + "\\SPKSEND.XML";
                //}
                ////B,Cタイプ
                //else
                //{
                //    fileName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECR.XML";
                //}
                // add by liusy 2011/12/02 ---------<<<<<<<
                // --- DEL 櫻井亮太 2014/03/04----------<<<<<
                // --- ADD 櫻井亮太 2014/03/04---------->>>>>
                if (InqOrdDivCd == 0)
                {
                    xmlFileString = "from=" + fristGyoNo + "to=" + lastGyoNo;
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\SPKSEND.XML";
                }
                //Bタイプで且つプロトコルがHTTP（大和、ヤマト、辰巳屋のみ）
                //PM7と同じ運用であれば全卸商に&を付加する必要が有るが稼動して時間がたっており
                //全卸とテストを行うとテスト範囲が大きい為３社のみとする
                else if (InqOrdDivCd == 1 && _uoeSupplier.DaihatsuOrdreDiv == 0)
                {
                    xmlFileString = "from=" + fristGyoNo + "&" + "to=" + lastGyoNo;
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECR.XML";
                }
                //CタイプとBタイプのプロトコルHTTPS
                else
                {
                    xmlFileString = "from=" + fristGyoNo + "to=" + lastGyoNo;
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECR.XML";
                }
                // --- ADD 櫻井亮太 2014/03/04----------<<<<<


                FileStream file = new FileStream(fileName, FileMode.Create);

                file.Write(Encoding.UTF8.GetBytes(xmlFileString), 0, Encoding.UTF8.GetByteCount(xmlFileString));
                file.Close();
            }

            return xmlFileString;
        }

        #region [DEL 2012/04/02 この部分の処理はDelphi5で実装するため]
        //--- 2012/04/02 削除　この部分の処理はDelphi5で実装するため
        ///// <summary>
        ///// ヘッダ情報追加
        ///// </summary>
        //private void HeaderMake(UOESupplier uoeSupplier, int InqOrdDivCd)
        //{
        //
        //    request.Accept = "*/*";
        //    request.Headers.Add("Accept-Language", "ja");
        //    //WSSE認証用の文字列を作る
        //    string wsse = CreateWSSEToken(uoeSupplier.UOEConnectUserId, uoeSupplier.UOEConnectPassword);
        //
        //    //sHead = "Accept-Language: ja" + STRING_CHANGE_ROW;
        //
        //    request.Headers.Add("X-WSSE: " + wsse);
        //
        //    if (InqOrdDivCd == 2)
        //    {
        //        request.Headers.Add("X-PMREN", uoeSupplier.EnterpriseCode.Substring(uoeSupplier.EnterpriseCode.Length - 9));
        //    }
        //    request.ContentType = "multipart/form-data; boundary=" + STRING_BOUNDARY.Substring(2);
        //    request.KeepAlive = true;
        //    if (this._uoeSupplier.LoginTimeoutVal != 0)
        //    {
        //        request.Timeout = this._uoeSupplier.LoginTimeoutVal * 1000;
        //    }
        //}
        //--- 2012/04/02 削除　この部分の処理はDelphi5で実装するため
        #endregion

        /// <summary>
        /// 16進数表記のSHA-1メッセージダイジェストを生成します。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string GetDigest(string source)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            StringBuilder answer = new StringBuilder();
            foreach (Byte b in sha1.ComputeHash(Encoding.UTF8.GetBytes(source)))
            {
                if (b < 16)
                {
                    answer.Append("0");
                }
                answer.Append(Convert.ToString(b, 16));
            }
            return answer.ToString();
        }

        /// <summary>
        /// Nonceを生成します。
        /// Nonceは精度の高い擬似乱数生成器を利用してください。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string CreateNonce()
        {
            Random r = new Random();
            double d1 = r.NextDouble();
            double d2 = d1 * d1;
            return GetDigest(d2.ToString());
        }

        #region [DEL 2012/04/02 この部分の処理はDelphi5で実装するため]
        //--- 2012/04/02 削除　この部分の処理はDelphi5で実装するため
        ///// <summary>
        ///// Nonceを生成します。
        ///// Nonceは精度の高い擬似乱数生成器を利用してください。
        ///// </summary>
        ///// <param name="source"></param>
        ///// <returns></returns>
        //private string CreateWSSEToken(string userName, string password)
        //{
        //    StringBuilder wsseToken = new StringBuilder();
        //    string nonce = CreateNonce();
        //    string created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");
        //    string passwordDigest = Convert.ToBase64String(Encoding.UTF8.GetBytes(GetDigest(String.Format("{0}{1}{2}", nonce, created, password))));

        //    //Username Tokenの文字列を生成する 
        //    wsseToken.Append("UsernameToken ");
        //    wsseToken.AppendFormat("Username=\"{0}\", ", userName);
        //    wsseToken.AppendFormat("PasswordDigest=\"{0}\", ", passwordDigest);
        //    wsseToken.AppendFormat("Nonce=\"{0}\", ", nonce);
        //    wsseToken.AppendFormat("Created=\"{0}\" ", created);

        //    return wsseToken.ToString();
        //}
        //--- 2012/04/02 削除　この部分の処理はDelphi5で実装するため
        #endregion

        #region [DEL 2012/04/02 この部分の処理はDelphi5で実装するため]
        //--- 2012/04/02 削除　この部分の処理はDelphi5で実装するため
        ///// <summary>
        ///// 回線オープン処理
        ///// </summary>
        ///// <param name="daihatsuOrdreDiv">UOE発注先マスタのプロトコル</param>
        ///// <param name="address">アドレス</param>
        ///// <returns></returns>
        //private bool RequestOpen(int daihatsuOrdreDiv, string address)
        //{
        //    bool isConnected;
        //    int flags;
        //    isConnected = InternetGetConnectedState(out flags, 0);

        //    if (InternetAttemptConnect(0) != ERROR_SUCCESS || isConnected == false)
        //    {
        //        // 回線おオーペンエラー
        //        return false;
        //    }
        //    string httpHead = "";
        //    //HTTP/HTTPS プロトコル  
        //    if (_uoeSupplier.DaihatsuOrdreDiv == 0)
        //    {
        //        httpHead = "http://";
        //    }
        //    else
        //    {
        //        httpHead = "https://";
        //    }
        //    request = (HttpWebRequest)HttpWebRequest.Create(httpHead + _uoeSupplier.UOEOrderUrl + address);
        //    request.Method = "POST";
        //    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        //    return true;
        //}
        //--- 2012/04/02 削除　この部分の処理はDelphi5で実装するため
        #endregion

        /// <summary>
        /// Webサービスからの戻り値を受信電文データに変換する
        /// </summary>
        /// <param name="isReceivingStock"></param>
        /// <param name="errorCode"></param>
        /// <param name="uoeReceivedData"></param>
        /// <remarks>
        /// <br>Note       : Webサービスからの戻り値を受信電文データに変換する</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2014/04/1 佐々木貴英</br>
        ///	<br>			 UOEリクエスト受信電文障害対応</br>
        /// <br>Update Note: 2016/04/07 田建委</br>
        /// <br>             Redmine#48694 SPK仕入受信エラーの対応</br>
        /// <br>Update Note: 2016/09/28 田建委</br>
        /// <br>管理番号   : 11201848-00</br>
        /// <br>             Redmine#48879 XML読み込み後、XMLオブジェクトの閉じるを行う</br>
        /// </remarks>
        private void ConvertXMLToUoeSndHed(UoeSndHed uoeSendingData, bool isReceivingStock, string errorCode, int InqOrdDivCd, ref UoeRecHed uoeReceivedData)
        {
            uoeReceivedData = new UoeRecHed();
            uoeReceivedData.BusinessCode = uoeSendingData.BusinessCode;
            uoeReceivedData.CommAssemblyId = uoeSendingData.CommAssemblyId;
            uoeReceivedData.UOESupplierCd = uoeSendingData.UOESupplierCd;
            uoeReceivedData.UoeRecDtlList = new List<UoeRecDtl>();
            //--- 2012/04/02 削除 >>>>>>>>>>>>>>>>>>>>>>
            //bool EmptyFlag = false;
            //--- 2012/04/02 削除 <<<<<<<<<<<<<<<<<<<<<<

            //XMLファイル作成
            if (recvReader == null)
            {
                //Aタイプ
                if (InqOrdDivCd == 0)
                {
                    fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\SPKRECV.XML";
                }
                //
                else
                {
                    fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECV.XML";
                }
                recvReader = new XmlTextReader(fileRecName);
            }

            # region XML項目をテーブルにセット
            this.dsResponse = new NewDataSet2();
            // upd 2012/07/13 >>>
            //this._netRecvDataTable = ((NewDataSet2)this.dsResponse).PartsmanResponseTbl;
            //NewDataSet2.PartsmanResponseTblRow netrecvRow = this._netRecvDataTable.NewPartsmanResponseTblRow();
            this._netRecvDataTable = ((NewDataSet2)this.dsResponse).PartsmanResponseTbl1003;
            NewDataSet2.PartsmanResponseTbl1003Row netrecvRow = this._netRecvDataTable.NewPartsmanResponseTbl1003Row();
            // upd 2012/07/13 <<<
            int iCnt = 0;
            string nodeName = "";
            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
            int iGyono = -1;
            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<

            //----- ADD 2016/09/28 田建委 Redmine#48879 XML読み込み後、XMLオブジェクトの閉じる ----->>>>>
            try
            {
            //----- ADD 2016/09/28 田建委 Redmine#48879 XML読み込み後、XMLオブジェクトの閉じる -----<<<<<
                if (recvReader.ReadState != ReadState.Error)
                {
                    while (recvReader.Read())
                    {
                        //--- 2012/04/02 判定は受注日付のみで行う >>>>>>>>>>>>>>>>>>>>>>>
                        //if (iCnt == 2)
                        if (iCnt == 1)
                        //--- 2012/04/02 判定は受注日付のみで行う <<<<<<<<<<<<<<<<<<<<<<<
                        {
                        //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 ----->>>>>
                        // 仕入受信ではない場合
                        if (!isReceivingStock)
                        {
                        //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 -----<<<<<
                            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                            if (iGyono >= 0)
                            {
                                // リマーク、ラインリマークを連想配列から取得
                                netrecvRow.REMARK = RemarkDic[iGyono];
                                netrecvRow.CHKCD = ChkcdDic[iGyono];
                            }
                            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                        } // ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応
                            // upd 2012/07/13 >>>
                            //this._netRecvDataTable.AddPartsmanResponseTblRow(netrecvRow);
                            //netrecvRow = this._netRecvDataTable.NewPartsmanResponseTblRow();
                            this._netRecvDataTable.AddPartsmanResponseTbl1003Row(netrecvRow);
                            netrecvRow = this._netRecvDataTable.NewPartsmanResponseTbl1003Row();
                            // upd 2012/07/13 <<<
                            iCnt = 0;
                            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                            iGyono = -1;
                            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                        }
                        //--- 2012/04/02 削除 >>>>>>>>>>>>>>>>>>>>>>
                        //byte[] byteArr = null;
                        //--- 2012/04/02 削除 <<<<<<<<<<<<<<<<<<<<<<
                        switch (recvReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (recvReader.Name != null && recvReader.Name != string.Empty)
                                {
                                    nodeName = recvReader.Name;
                                }

                                break;
                            case XmlNodeType.Text:
                                if (nodeName == RECV_UKENO)        //受付番号
                                {
                                }
                                else if (nodeName == RECV_DENBKB)        //電文区分
                                {
                                    netrecvRow.DENBKB = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_KUBUN)        //処理区分
                                {
                                    netrecvRow.KUBUN = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_GYONO)        //行番号
                                {
                                    netrecvRow.GYONO = int.Parse(recvReader.Value.ToString());
                                    // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                                    iGyono = netrecvRow.GYONO;
                                    // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                                }
                                else if (nodeName == RECV_RESULT)        //処理結果
                                {
                                    netrecvRow.RESULT = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_REQNO)        //電文問合せ番号
                                {
                                    netrecvRow.REQNO = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_REQGYO)        //伝票用行番号
                                {
                                    netrecvRow.REQGYO = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_REMARK)        //ﾘﾏｰｸ（備考）
                                {
                                    // --- DEL 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                                    //netrecvRow.REMARK = recvReader.Value.ToString();
                                    // --- DEL 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                                //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 ----->>>>>
                                // 仕入受信の場合
                                if (isReceivingStock)
                                {
                                    // 受信XMLファイルから備考(REMARK)を取得（禁則文字変換はPMPU9013で処理）
                                    netrecvRow.REMARK = recvReader.Value;
                                }
                                //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 -----<<<<<
                                }
                                else if (nodeName == RECV_NHNKB)        //納品区分
                                {
                                    netrecvRow.NHNKB = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_HNSBT)        //部品種別
                                {
                                    //指定拠点 削除（不要と判断）
                                }
                                else if (nodeName == RECV_JYUHNNO)        //受注部品番号
                                {
                                    netrecvRow.JYUHNNO = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_SYUHNNO)        //出荷部品番号
                                {
                                    netrecvRow.SYUHNNO = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_MKCD)        //ﾒｰｶｰｺｰﾄﾞ
                                {
                                    netrecvRow.MKCD = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_UKEYMD)        //受付日付
                                {
                                    netrecvRow.UKEYMD = int.Parse(recvReader.Value.ToString());
                                    //--- 2012/04/02 判定は受注日付のみで行う >>>>>>>>>>>>>>>>
                                    //if (iCnt == 1)
                                    //{
                                    //    iCnt = 2;
                                    //}
                                    iCnt = 1;
                                    //--- 2012/04/02 判定は受注日付のみで行う <<<<<<<<<<<<<<<<
                                }
                                else if (nodeName == RECV_HINNM)        //品名
                                {
                                    //--- 2012/04/02 判定は受注日付のみで行う >>>>>>>>>>>>>>>>>
                                    //netrecvRow.HINNM = recvReader.Value.ToString();
                                    //iCnt = 1;

                                    if (recvReader.Value.ToString().Length > 20)
                                    {
                                        netrecvRow.HINNM = recvReader.Value.ToString().Substring(0, 19);
                                    }
                                    else
                                    {
                                        netrecvRow.HINNM = recvReader.Value.ToString();
                                    }
                                    //--- 2012/04/02 判定は受注日付のみで行う <<<<<<<<<<<<<<<<<

                                }
                                else if (nodeName == RECV_SHOTIK)        //定価
                                {
                                    netrecvRow.SHOTIK = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_SKRTNK)        //仕切り単価
                                {
                                    // upd 2012/07/13 >>>
                                    //netrecvRow.SKRTNK = int.Parse(recvReader.Value.ToString());
                                    netrecvRow.SKRTNK = double.Parse(recvReader.Value.ToString());
                                    // upd 2012/07/13 <<<
                                }
                                else if (nodeName == RECV_JYUSU)        //受注数
                                {
                                    netrecvRow.JYUSU = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_SYUSU)        //出荷数
                                {
                                    netrecvRow.SYUSU = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_BOKB)        //BO区分
                                {
                                    netrecvRow.BOKB = recvReader.Value.ToString();
                                }
                                else if (nodeName == RECV_BOSU)        //BO数
                                {
                                    netrecvRow.BOSU = int.Parse(recvReader.Value.ToString());
                                }
                                else if (nodeName == RECV_SYUNO)        //出荷伝票番号
                                {
                                    // upd 2012/07/13 >>>
                                    //netrecvRow.SYUNO = int.Parse(recvReader.Value.ToString());
                                    netrecvRow.SYUNO = recvReader.Value.ToString();
                                    // upd 2012/07/13 <<<
                                }
                                else if (nodeName == RECV_BOUKENO)        //BO受付番号
                                {
                                    // upd 2012/07/13 >>>
                                    //netrecvRow.BOUKENO = int.Parse(recvReader.Value.ToString());
                                    netrecvRow.BOUKENO = recvReader.Value.ToString();
                                    // upd 2012/07/13 <<<
                                }
                                else if (nodeName == RECV_CHKCD)        //ﾗｲﾝﾘﾏｰｸ（備考）
                                {
                                    // --- DEL 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                                    //netrecvRow.CHKCD = recvReader.Value.ToString();
                                    // --- DEL 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                                //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 ----->>>>>
                                // 仕入受信の場合
                                if (isReceivingStock)
                                {
                                    // 受信XMLファイルからﾗｲﾝﾘﾏｰｸ(CHKCD)を取得（禁則文字変換はPMPU9013で処理）
                                    netrecvRow.CHKCD = recvReader.Value;
                                }
                                //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 -----<<<<<
                                }
                                else if (nodeName == RECV_LINERR)        //ﾗｲﾝﾒｯｾｰｼﾞ
                                {
                                    netrecvRow.LINERR = recvReader.Value.ToString();
                                }
                                break;
                            case XmlNodeType.EndElement:
                                nodeName = "";
                                break;
                            default:
                                break;
                        }

                    }

                }
            //----- ADD 2016/09/28 田建委 Redmine#48879 XML読み込み後、XMLオブジェクトの閉じる ----->>>>>
            }
            finally
            {
                if (recvReader != null)
                {
                    recvReader.Close();
                    recvReader = null;
                }
            }
            //----- ADD 2016/09/28 田建委 Redmine#48879 XML読み込み後、XMLオブジェクトの閉じる -----<<<<<
            # endregion

            UoeRecDtl Dtl = new UoeRecDtl();
            Dtl.UOESalesOrderRowNo = new List<int>();

            byte[] recv_work = new byte[5120];
            byte[] toByteArray = new byte[256];
            byte[] recv = new byte[toByteArray.Length];

            UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length);

            iCnt = 0;
            int recv_pnt = 0;
            string REQNO_BACK = "";

            // upd 2012/07/13 >>>
            //this.tableresp = this.dsResponse.Tables["PartsmanResponseTbl"];
            this.tableresp = this.dsResponse.Tables["PartsmanResponseTbl1003"];
            // upd 2012/07/13 <<<

            // 最初に空明細の作成「開局と偽る」　
            toByteArray = new byte[256];
            Dtl = new UoeRecDtl();
            Dtl.RecTelegram = toByteArray;
            Dtl.RecTelegramLen = Dtl.RecTelegram.Length;
            uoeReceivedData.UoeRecDtlList.Add(Dtl);

            Dtl = new UoeRecDtl();

            // テーブルに件数がある場合
            if (this.tableresp.Rows.Count != 0)
            {
                // テーブルの件数分のLOOP
                for (int index = 0; index < tableresp.Rows.Count; index++)
                {
                    System.Data.DataRow netrecvRow1 = tableresp.Rows[index];
                    toByteArray = new byte[256];

                    //　仕入受信では無い場合
                    if (!isReceivingStock)
                    {
                        if (((netrecvRow1["REQNO"].ToString() != REQNO_BACK) || (iCnt == 5)) && (iCnt != 0))
                        {
                            iCnt = 0;
                            //　ADDが必要
                            //　明細行数分のバッファを作成し、内容をコピー
                            recv = new byte[recv_pnt];
                            UoeCommonFnc.MemCopy(ref recv, 0, ref recv_work, 0, recv_pnt);

                            //　受信情報の構造体に内容をセット
                            Dtl.RecTelegram = recv;
                            Dtl.RecTelegramLen = recv.Length;
                            Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                            Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;

                            //　受信情報の構造体に追加
                            uoeReceivedData.UoeRecDtlList.Add(Dtl);

                            recv_work = new byte[5120];
                            UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length);

                            recv_pnt = 0;
                            Dtl = new UoeRecDtl();
                            Dtl.UOESalesOrderRowNo = new List<int>();
                        }

                        //　RecTelegramに追加
                        iCnt = iCnt + 1;
                        toByteArray = (byte[])ToByteArray(netrecvRow1);
                        UoeCommonFnc.MemCopy(ref recv_work, recv_pnt, ref toByteArray, 0, toByteArray.Length);
                        recv_pnt += toByteArray.Length;
                        Dtl.UOESalesOrderNo = int.Parse((string)tableresp.Rows[index]["REQNO"]);

                        // 復旧処理から送信した場合、元の明細行数をセットしなければいけないため
                        for (int index1 = 0; index1 < uoeSendingData.UoeSndDtlList.Count; index1++)
                        {
                            if (Dtl.UOESalesOrderNo == uoeSendingData.UoeSndDtlList[index1].UOESalesOrderNo)
                            {
                                Dtl.UOESalesOrderRowNo.Add(uoeSendingData.UoeSndDtlList[index1].UOESalesOrderRowNo[iCnt - 1]);
                                break;
                            }
                        }

                        REQNO_BACK = netrecvRow1["REQNO"].ToString();
                    }
                    else
                    {
                        toByteArray = (byte[])ToByteArray(netrecvRow1);

                        recv = new byte[toByteArray.Length];
                        UoeCommonFnc.MemCopy(ref recv, 0, ref toByteArray, 0, toByteArray.Length);

                        Dtl = new UoeRecDtl();
                        Dtl.RecTelegram = recv;
                        Dtl.RecTelegramLen = recv.Length;
                        Dtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                        Dtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;

                        Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                        Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;

                        //　受信情報の構造体に追加
                        uoeReceivedData.UoeRecDtlList.Add(Dtl);
                    }
                }

                if (!isReceivingStock)
                {
                    recv = new byte[recv_pnt];
                    UoeCommonFnc.MemCopy(ref recv, 0, ref recv_work, 0, recv_pnt);
                    Dtl.RecTelegram = recv;
                    Dtl.RecTelegramLen = recv.Length;
                    Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                    Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;
                    // 受信電文内容をリストに追加
                    uoeReceivedData.UoeRecDtlList.Add(Dtl);
                }
            }
            else
            {
                if (isReceivingStock)
                {
                    Dtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                    Dtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;
                    uoeReceivedData.UoeRecDtlList.Add(Dtl);
                }
            }

            //最後に空明細の作成「開局と偽る」　
            toByteArray = new byte[256];
            Dtl = new UoeRecDtl();
            Dtl.RecTelegram = toByteArray;
            Dtl.RecTelegramLen = Dtl.RecTelegram.Length;
            uoeReceivedData.UoeRecDtlList.Add(Dtl);
        }

        /// <summary>
        /// 仕入受信処理であるの場合、XMLの設定
        /// </summary>
        /// <param name="uoeSendingData">ＵＯＥ受信ヘッダークラス</param>
        /// <remarks>
        /// <br>Note       : 仕入受信処理であるの場合、XMLの設定</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/27</br>
        /// </remarks>
        private void SetReceivingStockXMLFlie(ref XmlWriter writer)
        {
            //電文区分
            // 電文区分に“６０”を固定でセットし、他の項目は何もセット致しません
            writer.WriteStartElement(SEND_DENBKB);
            writer.WriteValue(DENBKB_60);
            writer.WriteFullEndElement();
            //行番号
            writer.WriteStartElement(SEND_GYONO);
            writer.WriteValue(0);
            writer.WriteFullEndElement();
            //電文問合せ番号
            writer.WriteStartElement(SEND_REQNO);
            writer.WriteFullEndElement();
            //伝票用行番号
            writer.WriteStartElement(SEND_REQGYO);
            writer.WriteValue(0);
            writer.WriteFullEndElement();
            //リマーク（備考）
            writer.WriteStartElement(SEND_REMARK);
            writer.WriteFullEndElement();
            //納品区分
            writer.WriteStartElement(SEND_NHNKB);
            writer.WriteFullEndElement();
            //部品種別
            writer.WriteStartElement(SEND_HNSBT);
            writer.WriteValue(0);
            writer.WriteFullEndElement();
            //部品番号
            writer.WriteStartElement(SEND_JYUHNNO);
            writer.WriteFullEndElement();
            //メーカーコード
            writer.WriteStartElement(SEND_MKCD);
            writer.WriteFullEndElement();
            //数量
            writer.WriteStartElement(SEND_JYUSU);
            writer.WriteValue(0);
            writer.WriteFullEndElement();
            //Ｂ／Ｏ区分
            writer.WriteStartElement(SEND_BOKB);
            writer.WriteFullEndElement();
            //ラインリマーク（備考）
            writer.WriteStartElement(SEND_CHKCD);
            writer.WriteFullEndElement();

        }
        /// <summary>
        /// ファイルを変更
        /// </summary>
        /// <param name="uoeSendingData">ＵＯＥ受信ヘッダークラス</param>
        /// <remarks>
        /// <br>Note       : ファイルの変更</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2013/02/18 李亜博</br>
        ///	<br>			 2013/03/13配信分、Redmine#34610</br>
        ///	<br>			 発注先マスタのPGIDが「1003」接続タイプが「Aタイプ」</br>
        ///	<br>             の場合に１つのXMLを作成して、毎にそのXMLを送信する。</br> 
        /// </remarks>
        private string fileChange()
        {
            //ファイルへ送信
            string fileString = "";
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                byte[] byDate = new byte[file.Length];
                char[] charDate = new char[file.Length];
                file.Read(byDate, 0, (int)file.Length);
                //Decoder d = Encoding.UTF8.GetDecoder();//DEL 2013/02/18 李亜博 for Redmine#34610
                Decoder d = Encoding.Default.GetDecoder();//ADD 2013/02/18 李亜博 for Redmine#34610
                d.GetChars(byDate, 0, byDate.Length, charDate, 0);
                for (int i = 0; i < charDate.Length; i++)
                {
                    fileString = fileString + charDate[i];
                }
                file.Close();
            }
            catch (Exception)
            {
                fileString = "";
            }
            return fileString;
        }
        /// <summary>
        /// xml to datatable処理
        /// </summary>
        /// <remarks>
        /// <br>Note       :xml to dic処理を行います。</br>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void XmlLoad()
        {
            MakerDic = new Dictionary<string, string>();
            List<UoeCdparameterList> fromXmlUoeList = null;
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME)))
            {
                try
                {
                    // XMLから抽出条件アイテムクラス配列にデシリアライズする
                    fromXmlUoeList = UserSettingController.DeserializeUserSetting<List<UoeCdparameterList>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                }
            }
            if (fromXmlUoeList != null && fromXmlUoeList.Count > 0)
            {
                for (int i = 0; i < fromXmlUoeList.Count; i++)
                {
                    UoeCdparameterList fromXmlUoeCdList = (UoeCdparameterList)fromXmlUoeList[i];
                    if (fromXmlUoeCdList.UoeCdparameter.Equals(String.Format("{0:D6}", this._uoeSupplier.UOESupplierCd)))
                    {
                        for (int j = 0; j < fromXmlUoeCdList.MakerCdList.Count; j++)
                        {
                            MakerDic.Add(fromXmlUoeCdList.MakerCdList[j], String.Format("{0:D6}", this._uoeSupplier.UOESupplierCd));
                        }
                    }
                }
            }

        }
        /// <summary>
        /// 要求情報の設定
        /// </summary>
        /// <param name="uoeSendingData">ＵＯＥ受信ヘッダークラス</param>
        /// <remarks>
        /// <br>Note       : 要求情報の設定</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2013/02/18 李亜博</br>
        ///	<br>			 2013/03/13配信分、Redmine#34610</br>
        ///	<br>			 発注先マスタのPGIDが「1003」接続タイプが「Aタイプ」</br>
        ///	<br>             の場合に１つのXMLを作成して、毎にそのXMLを送信する。</br> 
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2014/04/1 佐々木貴英</br>
        ///	<br>			 UOEリクエスト受信電文障害対応</br>
        /// </remarks>
        private void SetNetsendXML(UoeSndHed uoeSendingData, bool isReceivingStock, int InqOrdDivCd)
        {

            int j = 1;
            XmlWriterSettings settings = new XmlWriterSettings();
            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
            int iGyono = 0;
            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
            settings.Indent = true;
            settings.NewLineOnAttributes = false;
            settings.Encoding = Encoding.Default;
            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
            // リマーク格納連想配列のクリア
            RemarkDic.Clear();
            // ラインリマーク格納連想配列のクリア
            ChkcdDic.Clear();
            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
            //XMLファイル作成
            if (sendWriter == null)
            {

                if (InqOrdDivCd == 0)
                {
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\SPKSEND.XML";

                }
                //B,Cタイプ
                else
                {
                    fileName = System.IO.Directory.GetCurrentDirectory() + "\\NETSEND.XML";
                }
                sendWriter = XmlWriter.Create(fileName, settings);

            }


            //Write the XML delcaration. 
            sendWriter.WriteStartDocument();
            //Aタイプ
            if (InqOrdDivCd == 0)
            {
                //--- 2012/04/02 変更　タグ名称の大文字・小文字をSPK側では確認しているため >>>>>
                //sendWriter.WriteStartElement("spkSend");
                sendWriter.WriteStartElement("SpkSend");
                //--- 2012/04/02 変更　タグ名称の大文字・小文字をSPK側では確認しているため <<<<<

                //国産部品を設定
                XmlLoad();
            }
            //B,Cタイプ
            else
            {
                //--- 2012/04/02 変更　タグ名称の大文字・小文字をSPK側では確認しているため念のため >>>>>
                //sendWriter.WriteStartElement("netSend");
                sendWriter.WriteStartElement("NETSEND");
                //--- 2012/04/02 変更　タグ名称の大文字・小文字をSPK側では確認しているため念のため <<<<<
            }

            // 開局電文の発注区分
            string kubun = null;
            for (int index = 0; index < uoeSendingData.UoeSndDtlList.Count; index++)
            {

                UoeSndDtl uoeSndDtl = uoeSendingData.UoeSndDtlList[index];
                byte[] sndTelegram = uoeSndDtl.SndTelegram;
                string readStr = null;
                if (index == 0)
                {
                    byte[] kaiTelegram = uoeSndDtl.SndTelegram;
                    UoeCommonFnc.MemCopy(ref kubun, ref kaiTelegram, 36, 1);
                }
                if (index == 0 || index == uoeSendingData.UoeSndDtlList.Count - 1)
                {
                    continue;
                }
                UoeRecDtl uoeRecDtl = new UoeRecDtl();
                // 仕入受信処理である
                if (isReceivingStock)
                {

                    // 電文区分→電文区分
                    // 電文区分に“６０”を固定でセットし、他の項目は何もセット致しません
                    sendWriter.WriteStartElement("DATA");
                    SetReceivingStockXMLFlie(ref sendWriter);
                    sendWriter.WriteFullEndElement();

                    //該当データの場合は、[UOESalesOrderNo]へ値をセット
                    //対象明細のSend情報の値をセット
                }
                else if (!isReceivingStock)
                {

                    uoeRecDtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_RcvNG;
                    uoeRecDtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_YES;

                    UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, 15, 1);
                    int detailCount = int.Parse(readStr);
                    for (int m = 1; m <= detailCount; m++)
                    {
                        int i = 0;
                        int iValue = 0;
                        sendWriter.WriteStartElement("DATA");
                        // 仕入受信処理ではない
                        # region 電文区分
                        sendWriter.WriteStartElement(SEND_DENBKB);

                        // 発注
                        if (uoeSendingData.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                        {
                            sendWriter.WriteValue(DENBKB_35);
                        }
                        // 在庫
                        else
                        {
                            sendWriter.WriteValue(DENBKB_45);
                        }
                        sendWriter.WriteFullEndElement();
                        i = i + 1;
                        # endregion

                        # region 処理区分
                        ////B,Cタイプ
                        if (InqOrdDivCd != 0)
                        {
                            // 開局電文の発注区分→処理区分
                            sendWriter.WriteStartElement(SEND_KUBUN);
                            sendWriter.WriteValue(kubun);
                            sendWriter.WriteFullEndElement();
                        }
                        i = i + 1;
                        # endregion

                        # region 行番号
                        sendWriter.WriteStartElement(SEND_GYONO);
                        sendWriter.WriteValue(j);
                        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                        // リマーク、ラインリマーク用に行番号を一時的に保持
                        iGyono = j;
                        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                        j++;
                        sendWriter.WriteFullEndElement();
                        # endregion

                        # region 電文問合せ番号
                        i = i + 7;
                        // 電文問合せ番号→電文問合せ番号
                        sendWriter.WriteStartElement(SEND_REQNO);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 6);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        uoeRecDtl.UOESalesOrderNo = Convert.ToInt32(readStr);
                        // --- DEL 李亜博 2013/02/18 for Redmine#34610---------->>>>>
                        //復旧確認時 開始の問い合わせ番号を取得
                        //if (index == 1)
                        //{
                        //    fristGyoNo = readStr;
                        //}
                        ////復旧確認時 終了の問い合わせ番号を取得
                        //if (index == uoeSendingData.UoeSndDtlList.Count - 2)
                        //{
                        //    lastGyoNo = readStr;
                        //}
                        // --- DEL 李亜博 2013/02/18 for Redmine#34610----------<<<<<
                        // --- ADD 李亜博 2013/02/18 for Redmine#34610---------->>>>>
                        //B,Cタイプ
                        if (InqOrdDivCd != 0)
                        {
                            //復旧確認時 開始の問い合わせ番号を取得
                            if (index == 1)
                            {
                                fristGyoNo = readStr;
                            }
                            //復旧確認時 終了の問い合わせ番号を取得
                            if (index == uoeSendingData.UoeSndDtlList.Count - 2)
                            {
                                lastGyoNo = readStr;
                            }
                        }
                        else
                        {
                            //復旧確認時 開始、終了の問い合わせ番号を取得
                            if (fristGyoNo == string.Empty)
                            {
                                //開始の問い合わせ番号を取得
                                fristGyoNo = readStr;
                                string tempReadStr = null;
                                // 最終桁の問い合わせ番号を取得
                                byte[] tempSndTelegram = _uoeSndDtlCopyList[_uoeSndDtlCopyList.Count - 2].SndTelegram;
                                UoeCommonFnc.MemCopy(ref tempReadStr, ref tempSndTelegram, i, 6);
                                //終了の問い合わせ番号を取得
                                lastGyoNo = tempReadStr;
                            }
                        }
                        // --- ADD 李亜博 2013/02/18 for Redmine#34610----------<<<<<
                        i = i + 6;
                        # endregion

                        # region 伝票用行番号
                        // 送信部品数→伝票用行番号
                        sendWriter.WriteStartElement(SEND_REQGYO);
                        //送信部品数(1送信電文内の明細行数)を取得
                        sendWriter.WriteValue(m);
                        uoeRecDtl.UOESalesOrderRowNo.Add(m);
                        sendWriter.WriteFullEndElement();
                        i = i + 1;
                        # endregion

                        # region リマーク（備考）
                        // リマーク（備考）→リマーク（備考）
                        sendWriter.WriteStartElement(SEND_REMARK);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 10);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 10;
                        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                        // リマークを連想配列に格納
                        RemarkDic.Add(iGyono, readStr.Trim());
                        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                        # endregion

                        # region 納品区分
                        // 納品区分→納品区分
                        sendWriter.WriteStartElement(SEND_NHNKB);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                        //--- 2012/04/02 SPKは在庫確認の場合　納品区分1でなければエラーになる件の対応　>>>>>>>>>>>>>>
                        //sendWriter.WriteValue(readStr.Trim());
                        //sendWriter.WriteFullEndElement();

                        if ((InqOrdDivCd == 0) && (uoeSendingData.BusinessCode != (int)EnumUoeConst.TerminalDiv.ct_Order))
                        {
                            sendWriter.WriteValue("1");
                        }
                        else
                        {
                            sendWriter.WriteValue(readStr.Trim());
                        }
                        sendWriter.WriteFullEndElement();
                        //--- 2012/04/02 SPKは在庫確認の場合　納品区分1でなければエラーになる件の対応  <<<<<<<<<<<<<<
                        i = i + 1;
                        # endregion

                        # region 部品種別
                        //指定拠点
                        i = i + 3;
                        //予備区分(1)
                        i = i + 1;
                        //予備区分(2)
                        i = i + 1;
                        // 部品種別 1:国産部品を設定（固定）TODO    
                        sendWriter.WriteStartElement(SEND_HNSBT);
                        if (InqOrdDivCd == 0)
                        {
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i + (m - 1) * 43 + 20, 4);
                            if (readStr != string.Empty && MakerDic.ContainsKey(readStr))
                            {
                                sendWriter.WriteValue("6");
                            }
                            else
                            {
                                sendWriter.WriteValue("1");
                            }
                        }
                        else
                        {
                            sendWriter.WriteValue("1");
                        }
                        sendWriter.WriteFullEndElement();
                        i = i + (m - 1) * 43;
                        # endregion

                        # region 部品番号
                        // 部品番号～ラインリマーク（備考）
                        // 電文の部品番号→部品番号
                        sendWriter.WriteStartElement(SEND_JYUHNNO);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 20);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 20;
                        # endregion

                        # region メーカーコード
                        // 電文のメーカーコード→メーカーコード
                        sendWriter.WriteStartElement(SEND_MKCD);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 4);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 4;
                        # endregion

                        # region 数量
                        //分類コード
                        i = i + 4;
                        // 電文の数量→数量
                        sendWriter.WriteStartElement(SEND_JYUSU);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 3);
                        iValue = 0;
                        Int32.TryParse(readStr, out iValue);
                        sendWriter.WriteValue(iValue);
                        i = i + 3;
                        sendWriter.WriteFullEndElement();
                        # endregion

                        # region Ｂ／Ｏ区分
                        // 電文のＢ／Ｏ区分→Ｂ／Ｏ区分
                        sendWriter.WriteStartElement(SEND_BOKB);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 1;
                        # endregion

                        # region ﾗｲﾝﾘﾏｰｸ（備考）
                        //予備コード
                        i = i + 1;
                        // 電文のチェックコード→ラインリマーク（備考）
                        sendWriter.WriteStartElement(SEND_CHKCD);
                        readStr = null;
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 10);
                        sendWriter.WriteValue(readStr.Trim());
                        sendWriter.WriteFullEndElement();
                        i = i + 10;
                        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                        // ラインリマークを連想配列に格納
                        ChkcdDic.Add(iGyono, readStr.Trim());
                        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                        # endregion
                        sendWriter.WriteFullEndElement();
                    }
                }
                UoeRecDtlDic.Add(uoeRecDtl.UOESalesOrderNo, uoeRecDtl);

            }

            sendWriter.WriteFullEndElement();

            sendWriter.Flush();

            sendWriter.Close();

        }
        /// <summary>
        /// バイト型配列に変換
        /// </summary>
        /// <returns>バイト型配列</returns>
        /// <remarks>
        /// <br>Note       : バイト型配列に変換</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/07</br>
        /// <br>Programmer : 堀田</br>
        /// <br>Date       : 2010/06/08</br>
        /// <br>Note       : Redmine#48897 ＳＰＫ仕入受信処理修正</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2017/03/02</br>
        /// </remarks>
        public byte[] ToByteArray(System.Data.DataRow netrecvRow)
        {
            byte[] toByteArray = new byte[256];
            UoeCommonFnc.MemSet(ref toByteArray, 0x20, toByteArray.Length);
            byte[] byteArr = null;

            // Webサービス戻り値の電文区分→受信電文データの電文区分
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["DENBKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 0);

            // Webサービス戻り値の処理区分→受信電文データの処理区分
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["KUBUN"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 1);

            // Webサービス戻り値の処理結果→受信電文データの処理結果
            byteArr = new byte[2];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["RESULT"].ToString().PadLeft(2, '0'), 2);
            byteArr.CopyTo(toByteArray, 2);

            // Webサービス戻り値の電文問合せ番号→受信電文データの電文問合せ番号
            byteArr = new byte[6];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REQNO"].ToString().PadLeft(6, '0'), 6);
            byteArr.CopyTo(toByteArray, 4);

            // Webサービス戻り値の伝票用行番号→受信電文データの回答電文対応行数
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REQGYO"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 10);

            // Webサービス戻り値のリマーク（備考）→受信電文データのリマーク（備考）
            byteArr = new byte[10];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REMARK"].ToString(), 10);
            byteArr.CopyTo(toByteArray, 11);

            // Webサービス戻り値の納品区分→受信電文データの納品区分
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["NHNKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 21);

            // Webサービス戻り値の受注部品番号→受信電文データの受注部品番号
            byteArr = new byte[20];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["JYUHNNO"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 25);

            // Webサービス戻り値の出荷部品番号→受信電文データの出荷部品番号
            byteArr = new byte[20];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUHNNO"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 45);

            // Webサービス戻り値のメーカーコード→受信電文データのメーカーコード
            byteArr = new byte[4];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["MKCD"].ToString().PadLeft(4, '0'), 4);
            byteArr.CopyTo(toByteArray, 65);

            // Webサービス戻り値の受付日付→受信電文データの分類コード
            byteArr = new byte[4];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["UKEYMD"].ToString().Substring(4, 4), 4);
            byteArr.CopyTo(toByteArray, 69);

            // Webサービス戻り値の品名→受信電文データの品名
            byteArr = new byte[20];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["HINNM"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 73);

            // Webサービス戻り値の定価→受信電文データの定価
            byteArr = new byte[7];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SHOTIK"].ToString().PadLeft(7, '0'), 7);
            byteArr.CopyTo(toByteArray, 93);

            // Webサービス戻り値の仕切単価→受信電文データの仕切単価
            byteArr = new byte[7];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SKRTNK"].ToString().PadLeft(7, '0'), 7);
            byteArr.CopyTo(toByteArray, 100);

            // Webサービス戻り値の受注数→受信電文データの受注数
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["JYUSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 107);

            // Webサービス戻り値の出庫数→受信電文データの出庫数
            byteArr = new byte[3];
            // UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUSU"].ToString().PadLeft(3, '0'), 3); // DEL BY 宋剛 2017/03/02 FOR Redmine#48897 ＳＰＫ仕入受信処理修正
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUSU"].ToString(), 3);                    // ADD BY 宋剛 2017/03/02 FOR Redmine#48897 ＳＰＫ仕入受信処理修正
            byteArr.CopyTo(toByteArray, 110);

            // Webサービス戻り値のＢ／Ｏ区分→受信電文データのＢ／Ｏ区分
            byteArr = new byte[1];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 113);

            // Webサービス戻り値のＢ／Ｏ数→受信電文データのＢ／Ｏ数
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 115);

            // Webサービス戻り値の出荷伝票番号→受信電文データの出荷伝票番号
            byteArr = new byte[6];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //--- 2012/04/02 空白がセットされた場合の変換対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if ((int)netrecvRow["SYUNO"] == 0)
            //{
            //    UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //}
            //else
            //{
            //    UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUNO"].ToString().PadLeft(6, '0'), 6);
            //}

            // del 2012/07/13 >>>
            //try
            //{
            //    if ((int)netrecvRow["SYUNO"] == 0)
            //    {
            //        UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //    }
            //    else
            //    {
            //        UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUNO"].ToString().PadLeft(6, '0'), 6);
            //    }
            //}
            //catch
            //{
            //    if (netrecvRow["SYUNO"].ToString().Trim() == "")
            //    {
            //        UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //    }
            //}
            // del 2012/07/13 <<<
            // add 2012/07/13 >>>
            if (netrecvRow["SYUNO"].ToString().Trim() != "")
            {
                UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUNO"].ToString().PadLeft(6, '0'), 6);
            }
            else
            {
                UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            }
            // add 2012/07/13 <<<
            //--- 2012/04/02 空白がセットされた場合の変換対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            byteArr.CopyTo(toByteArray, 118);

            // Webサービス戻り値のＢ／Ｏ受付番号→受信電文データのＢ／Ｏ受付番号
            byteArr = new byte[6];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //--- 2012/04/02 空白がセットされた場合の変換対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if ((int)netrecvRow["BOUKENO"] == 0)
            //{
            //    UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //}
            //else
            //{
            //    UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOUKENO"].ToString().PadLeft(6, '0'), 6);
            //}

            // del 2012/07/13 >>>
            //try
            //{
            //    if ((int)netrecvRow["BOUKENO"] == 0)
            //    {
            //        UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //    }
            //    else
            //    {
            //        UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOUKENO"].ToString().PadLeft(6, '0'), 6);
            //    }
            //}
            //catch
            //{
            //    if (netrecvRow["BOUKENO"].ToString().Trim() == "")
            //    {
            //        UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            //    }
            //}
            // del 2012/07/13 <<<
            // add 2012/07/13 >>>
            if (netrecvRow["BOUKENO"].ToString().Trim() != "")
            {
                UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOUKENO"].ToString().PadLeft(6, '0'), 6);
            }
            else
            {
                UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            }
            // add 2012/07/13 <<<
            //--- 2012/04/02 空白がセットされた場合の変換対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            byteArr.CopyTo(toByteArray, 124);

            // Webサービス戻り値のラインメッセージ→受信電文データのラインエラー
            byteArr = new byte[15];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["LINERR"].ToString(), 15);
            byteArr.CopyTo(toByteArray, 130);

            // Webサービス戻り値のラインマーク（備考）→受信電文データのチェックコード
            byteArr = new byte[10];
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["CHKCD"].ToString(), 10);
            byteArr.CopyTo(toByteArray, 145);

            return toByteArray;
        }
        // --- ADD 李亜博 2013/02/18 for Redmine#34610---------->>>>>
        /// <summary>
        /// Webサービスからの戻り値を受信電文データに変換する
        /// </summary>
        /// <param name="uoeSendingData"></param>
        /// <param name="isReceivingStock"></param>
        /// <param name="uoeReceivedData"></param>
        /// <remarks>
        /// <br>Note       : Webサービスからの戻り値を受信電文データに変換する</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ConvertAtypeXMLToUoeSndHed(UoeSndHed uoeSendingData, bool isReceivingStock, ref UoeRecHed uoeReceivedData)
        {
            uoeReceivedData = new UoeRecHed();
            uoeReceivedData.BusinessCode = uoeSendingData.BusinessCode;
            uoeReceivedData.CommAssemblyId = uoeSendingData.CommAssemblyId;
            uoeReceivedData.UOESupplierCd = uoeSendingData.UOESupplierCd;
            uoeReceivedData.UoeRecDtlList = new List<UoeRecDtl>();

            UoeRecDtl Dtl = new UoeRecDtl();
            Dtl.UOESalesOrderRowNo = new List<int>();

            byte[] recv_work = new byte[5120];
            byte[] toByteArray = new byte[256];
            byte[] recv = new byte[toByteArray.Length];

            UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length);

            int iCnt = 0;
            int recv_pnt = 0;
            string REQNO_BACK = "";

            this.tableresp = this.dsResponse.Tables["PartsmanResponseTbl1003"];

            // 最初に空明細の作成「開局と偽る」　
            toByteArray = new byte[256];
            Dtl = new UoeRecDtl();
            Dtl.RecTelegram = toByteArray;
            Dtl.RecTelegramLen = Dtl.RecTelegram.Length;
            uoeReceivedData.UoeRecDtlList.Add(Dtl);

            Dtl = new UoeRecDtl();

            // テーブルに件数がある場合
            if (this.tableresp.Rows.Count != 0)
            {
                // テーブルの件数分のLOOP
                for (int index = 0; index < tableresp.Rows.Count; index++)
                {
                    System.Data.DataRow netrecvRow1 = tableresp.Rows[index];
                    toByteArray = new byte[256];

                    //　仕入受信では無い場合
                    if (!isReceivingStock)
                    {
                        if (((netrecvRow1["REQNO"].ToString() != REQNO_BACK) || (iCnt == 5)) && (iCnt != 0))
                        {
                            iCnt = 0;
                            //　ADDが必要
                            //　明細行数分のバッファを作成し、内容をコピー
                            recv = new byte[recv_pnt];
                            UoeCommonFnc.MemCopy(ref recv, 0, ref recv_work, 0, recv_pnt);

                            //　受信情報の構造体に内容をセット
                            Dtl.RecTelegram = recv;
                            Dtl.RecTelegramLen = recv.Length;
                            Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                            Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;

                            //　受信情報の構造体に追加
                            uoeReceivedData.UoeRecDtlList.Add(Dtl);

                            recv_work = new byte[5120];
                            UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length);

                            recv_pnt = 0;
                            Dtl = new UoeRecDtl();
                            Dtl.UOESalesOrderRowNo = new List<int>();
                        }

                        //　RecTelegramに追加
                        iCnt = iCnt + 1;
                        toByteArray = (byte[])ToByteArray(netrecvRow1);
                        UoeCommonFnc.MemCopy(ref recv_work, recv_pnt, ref toByteArray, 0, toByteArray.Length);
                        recv_pnt += toByteArray.Length;
                        Dtl.UOESalesOrderNo = int.Parse((string)tableresp.Rows[index]["REQNO"]);

                        // 復旧処理から送信した場合、元の明細行数をセットしなければいけないため
                        for (int index1 = 0; index1 < uoeSendingData.UoeSndDtlList.Count; index1++)
                        {
                            if (Dtl.UOESalesOrderNo == uoeSendingData.UoeSndDtlList[index1].UOESalesOrderNo)
                            {
                                Dtl.UOESalesOrderRowNo.Add(uoeSendingData.UoeSndDtlList[index1].UOESalesOrderRowNo[iCnt - 1]);
                                break;
                            }
                        }

                        REQNO_BACK = netrecvRow1["REQNO"].ToString();
                    }
                    else
                    {
                        toByteArray = (byte[])ToByteArray(netrecvRow1);

                        recv = new byte[toByteArray.Length];
                        UoeCommonFnc.MemCopy(ref recv, 0, ref toByteArray, 0, toByteArray.Length);

                        Dtl = new UoeRecDtl();
                        Dtl.RecTelegram = recv;
                        Dtl.RecTelegramLen = recv.Length;
                        Dtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                        Dtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;

                        Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                        Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;

                        //　受信情報の構造体に追加
                        uoeReceivedData.UoeRecDtlList.Add(Dtl);
                    }
                }

                if (!isReceivingStock)
                {
                    recv = new byte[recv_pnt];
                    UoeCommonFnc.MemCopy(ref recv, 0, ref recv_work, 0, recv_pnt);
                    Dtl.RecTelegram = recv;
                    Dtl.RecTelegramLen = recv.Length;
                    Dtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                    Dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;
                    // 受信電文内容をリストに追加
                    uoeReceivedData.UoeRecDtlList.Add(Dtl);
                }
            }
            else
            {
                if (isReceivingStock)
                {
                    Dtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                    Dtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;
                    uoeReceivedData.UoeRecDtlList.Add(Dtl);
                }
            }

            //最後に空明細の作成「開局と偽る」　
            toByteArray = new byte[256];
            Dtl = new UoeRecDtl();
            Dtl.RecTelegram = toByteArray;
            Dtl.RecTelegramLen = Dtl.RecTelegram.Length;
            uoeReceivedData.UoeRecDtlList.Add(Dtl);
        }
        /// <summary>
        /// XMLファイル作成
        /// </summary>
        /// <param name="InqOrdDivCd">タイプ区分</param>
        /// <param name="isReceivingStock">仕入受信処理フラグ</param>
        /// <remarks>
        /// <br>Note       : XMLファイル作成</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2013/02/18</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br>Update Note: 2014/04/1 佐々木貴英</br>
        ///	<br>			 UOEリクエスト受信電文障害対応</br>
        /// <br>Update Note: 2016/04/07 田建委</br>
        /// <br>             Redmine#48694 SPK仕入受信エラーの対応</br>
        /// </remarks>
        //----- UPD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 ----->>>>>
        //private void MakeXMLFile(int InqOrdDivCd)
        private void MakeXMLFile(int InqOrdDivCd, bool isReceivingStock)
        //----- UPD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 -----<<<<<
        {
            //XMLファイル作成
            if (recvReader == null)
            {
                //Aタイプ
                if (InqOrdDivCd == 0)
                {
                    fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\SPKRECV.XML";
                }
                //
                else
                {
                    fileRecName = System.IO.Directory.GetCurrentDirectory() + "\\NETRECV.XML";
                }
                recvReader = new XmlTextReader(fileRecName);
            }

            # region XML項目をテーブルにセット
            if (this.dsResponse == null)
            {
                this.dsResponse = new NewDataSet2();
                this._netRecvDataTable = ((NewDataSet2)this.dsResponse).PartsmanResponseTbl1003;
            }
            NewDataSet2.PartsmanResponseTbl1003Row netrecvRow = this._netRecvDataTable.NewPartsmanResponseTbl1003Row();
            int iCnt = 0;
            string nodeName = "";
            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
            int iGyono = -1;
            // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<

            if (recvReader.ReadState != ReadState.Error)
            {
                while (recvReader.Read())
                {
                    if (iCnt == 1)
                    {
                        //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 ----->>>>>
                        // 仕入受信ではない場合
                        if (!isReceivingStock)
                        {
                        //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 -----<<<<<
                        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                        if (iGyono >= 0)
                        {
                            // リマーク、ラインリマークを連想配列から取得
                            netrecvRow.REMARK = RemarkDic[iGyono];
                            netrecvRow.CHKCD = ChkcdDic[iGyono];
                        }
                        iGyono = -1;
                        // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                        } // ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応
                        this._netRecvDataTable.AddPartsmanResponseTbl1003Row(netrecvRow);
                        netrecvRow = this._netRecvDataTable.NewPartsmanResponseTbl1003Row();
                        iCnt = 0;
                    }
                    switch (recvReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (recvReader.Name != null && recvReader.Name != string.Empty)
                            {
                                nodeName = recvReader.Name;
                            }

                            break;
                        case XmlNodeType.Text:
                            if (nodeName == RECV_UKENO)        //受付番号
                            {
                            }
                            else if (nodeName == RECV_DENBKB)        //電文区分
                            {
                                netrecvRow.DENBKB = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_KUBUN)        //処理区分
                            {
                                netrecvRow.KUBUN = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_GYONO)        //行番号
                            {
                                netrecvRow.GYONO = int.Parse(recvReader.Value.ToString());
                                // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                                iGyono = netrecvRow.GYONO;
                                // --- ADD 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<

                            }
                            else if (nodeName == RECV_RESULT)        //処理結果
                            {
                                netrecvRow.RESULT = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_REQNO)        //電文問合せ番号
                            {
                                netrecvRow.REQNO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_REQGYO)        //伝票用行番号
                            {
                                netrecvRow.REQGYO = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_REMARK)        //ﾘﾏｰｸ（備考）
                            {
                                // --- DEL 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                                //netrecvRow.REMARK = recvReader.Value.ToString();
                                // --- DEL 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                                //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 ----->>>>>
                                // 仕入受信の場合
                                if (isReceivingStock)
                                {
                                    // 受信XMLファイルから備考(REMARK)を取得（禁則文字変換はPMPU9013で処理）
                                    netrecvRow.REMARK = recvReader.Value;
                                }
                                //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 -----<<<<<
                            }
                            else if (nodeName == RECV_NHNKB)        //納品区分
                            {
                                netrecvRow.NHNKB = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_HNSBT)        //部品種別
                            {
                                //指定拠点 削除（不要と判断）
                            }
                            else if (nodeName == RECV_JYUHNNO)        //受注部品番号
                            {
                                netrecvRow.JYUHNNO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_SYUHNNO)        //出荷部品番号
                            {
                                netrecvRow.SYUHNNO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_MKCD)        //ﾒｰｶｰｺｰﾄﾞ
                            {
                                netrecvRow.MKCD = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_UKEYMD)        //受付日付
                            {
                                netrecvRow.UKEYMD = int.Parse(recvReader.Value.ToString());

                                iCnt = 1;
                            }
                            else if (nodeName == RECV_HINNM)        //品名
                            {

                                if (recvReader.Value.ToString().Length > 20)
                                {
                                    netrecvRow.HINNM = recvReader.Value.ToString().Substring(0, 19);
                                }
                                else
                                {
                                    netrecvRow.HINNM = recvReader.Value.ToString();
                                }
                            }
                            else if (nodeName == RECV_SHOTIK)        //定価
                            {
                                netrecvRow.SHOTIK = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_SKRTNK)        //仕切り単価
                            {
                                netrecvRow.SKRTNK = double.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_JYUSU)        //受注数
                            {
                                netrecvRow.JYUSU = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_SYUSU)        //出荷数
                            {
                                netrecvRow.SYUSU = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_BOKB)        //BO区分
                            {
                                netrecvRow.BOKB = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_BOSU)        //BO数
                            {
                                netrecvRow.BOSU = int.Parse(recvReader.Value.ToString());
                            }
                            else if (nodeName == RECV_SYUNO)        //出荷伝票番号
                            {
                                netrecvRow.SYUNO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_BOUKENO)        //BO受付番号
                            {
                                netrecvRow.BOUKENO = recvReader.Value.ToString();
                            }
                            else if (nodeName == RECV_CHKCD)        //ﾗｲﾝﾘﾏｰｸ（備考）
                            {
                                // --- DEL 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応---------->>>>>
                                //netrecvRow.CHKCD = recvReader.Value.ToString();
                                // --- DEL 佐々木貴英 2014/04/01 UOEリクエスト受信電文障害対応----------<<<<<
                                //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 ----->>>>>
                                // 仕入受信の場合
                                if (isReceivingStock)
                                {
                                    // 受信XMLファイルからﾗｲﾝﾘﾏｰｸ(CHKCD)を取得（禁則文字変換はPMPU9013で処理）
                                    netrecvRow.CHKCD = recvReader.Value;
                                }
                                //----- ADD 2016/04/07 田建委 Redmine#48694 SPK仕入受信エラーの対応 -----<<<<<
                            }
                            else if (nodeName == RECV_LINERR)        //ﾗｲﾝﾒｯｾｰｼﾞ
                            {
                                netrecvRow.LINERR = recvReader.Value.ToString();
                            }
                            break;
                        case XmlNodeType.EndElement:
                            nodeName = "";
                            break;
                        default:
                            break;
                    }

                }
            }
            recvReader.Close();

            # endregion
        }

        /// <summary>
        /// XMLファイルの読み込む
        /// </summary>
        /// <param name="filePath">XMLファイルのパース</param>
        /// <returns name="fileString">XMLファイルの内容</returns>
        /// <remarks>
        /// <br>Note       : XMLファイルの読み込む</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private string ReadXML(string filePath)
        {
            string fileString = "";
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                byte[] byDate = new byte[file.Length];
                char[] charDate = new char[file.Length];
                //ファイルの読み込む
                file.Read(byDate, 0, (int)file.Length);
                Decoder deCoder = Encoding.Default.GetDecoder();
                deCoder.GetChars(byDate, 0, byDate.Length, charDate, 0);
                for (int i = 0; i < charDate.Length; i++)
                {
                    fileString = fileString + charDate[i];
                }
                file.Close();
            }
            catch (Exception)
            {
                fileString = "";
            }
            return fileString;
        }
        // --- ADD 李亜博 2013/02/18 for Redmine#34610----------<<<<<
        # endregion
    }
}