//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力（ＴＭＹ）
// プログラム概要   : 売上データテキスト出力（ＴＭＹ）　アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン
// 作 成 日  2011/10/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン 							
// 修 正 日  2012/11/21  修正内容 : Redmine#33560
//                                  ①行N0.は明細の行N0.をそのままセットする仕様変更
//                                  ②数量は１００倍でセットする仕様変更					
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン 							
// 修 正 日  2012/11/27  修正内容 : 自動送信の追加仕様変更
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン 							
// 修 正 日  2013/01/15  修正内容 : 自動送信の追加メッセージについての仕様変更
//----------------------------------------------------------------------------//
// 管理番号  11000127-00 作成担当 : 30757 佐々木　貴英 							
// 修 正 日  2015/01/26  修正内容 : httpsプロトコル送信時コマンドが送信されない
//                                  不具合調査
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Security.Cryptography;
//---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
using Microsoft.Win32;
//---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    ///  売上データテキスト出力（ＴＭＹ） アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データテキスト出力（ＴＭＹ） アクセスクラス</br>										
    /// <br>Programmer : 鄧潘ハン</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>管理番号   : 10805731-00</br>
    /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
    /// <br>管理番号   : 10805731-00</br>
    /// <br>             Redmine#33560</br>
    /// <br>             ①行N0.は明細の行N0.をそのままセットする仕様変更</br>
    /// <br>             ②数量は１００倍でセットする仕様変更</br>
    /// <br>Update Note: 2012/11/27 鄧潘ハン</br>
    /// <br>管理番号   : 10805731-00</br>
    /// <br>             自動送信の追加仕様変更</br>
    /// <br>Update Note: 2013/01/15 鄧潘ハン</br>
    /// <br>管理番号   : 10805731-00</br>
    /// <br>             自動送信の追加メッセージについての仕様変更</br>
    /// <br>Update Note: 2015/01/26 30757 佐々木　貴英</br>
    /// <br>管理番号   : 11000127-00</br>
    /// <br>             Httpsプロトコル送信時コマンドが送信されない不具合対策</br>
    /// </remarks>
    public class SalesSliptextAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members

        private static SalesSliptextAcs _salesSliptextAcs = null;
        private ISalesSliptextResultDB _salesSliptextResultDB = null;
        private List<SalesSliptextResultWork> _salesSliptextListResult = null;
        private const string ct_RmotError = "リモート サーバーに接続できません。";
        //出力テキストテーブル
        private DataTable _salesSliptextCsv = null;
        //---ADD　鄧潘ハン　2012/11/27 ---------------->>>>>
        //接続マスタの初期化
        private ConnectInfoWorkAcs _connectInfoWorkAcs = null;
        //---DEL　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
        //HttpWebRequest request = null;
        //---DEL　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<
        //---ADD　鄧潘ハン　2012/11/27 ----------------<<<<<
        # endregion

        //---ADD　鄧潘ハン　2012/11/27 ---------------->>>>>
        private const string STRING_BOUNDARY = "-----------------------------7d21cef303f8";
        private const string STRING_CHANGE_ROW = "\r\n";        
        private const int    ERROR_SUCCESS = 0;
        //辰巳屋固定の仕入先「215700」
        private const int    SUPPLIERCD = 215700;
        #region API定義
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int InternetAttemptConnect(int dwReserved);
        //---ADD　鄧潘ハン　2012/11/27 ----------------<<<<<
        #endregion

        //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
        #region Delphi5のリクエストメソッド呼び出し
        /// <summary>
        /// Http送受信処理
        /// </summary>
        /// <param name="addres1">接続先アドレスのドメイン部分</param>
        /// <param name="addres2">接続先アドレスのドメイン以降</param>
        /// <param name="usrname">ユーザーID</param>
        /// <param name="password">パスワード</param>
        /// <param name="filepath">送信XMLの格納先</param>
        /// <param name="filename">ファイル名</param>
        /// <param name="ssl">プロトコル[0:HTTP 1:HTTPS]</param>
        /// <param name="usercode">企業コード</param>
        /// <param name="timeout">タイムアウト時間</param>
        /// <param name="errcode">エラー区分</param>
        /// <remarks>
        /// <br>Note       : Httpsプロトコル送信時コマンドが送信されない不具合対策</br>										
        /// <br>Programmer : 30757 佐々木　貴英</br>										
        /// <br>Date       : 2015/01/26</br>										
        /// <br>管理番号   : 11000127-0</br>
        /// </remarks>
        /// <returns></returns>
        [DllImport("PMPP9901.dll")]
        public extern static Int16 xPMPP9901(
              string addres1         //----接続先アドレスのドメイン部分をセット
            , string addres2         //----接続先アドレスのドメイン以下の部分をセット
            , string usrname         //----接続する際のユーザーIDをセット
            , string password        //----接続する際のパスワードをセット
            , string filepath        //----送信XMLの格納先をセット
            , string filename        //----送信XMLのファイル名をセット
            , Int16 ssl                //----プロトコル[0:HTTP 1:HTTPS]
            , string usercode        //----BL管理のユーザーコードをセット(企業コード)
            , int timeout            //----タイム時間の値をセット
            , ref Int16 errcode        //----エラー区分
            );
        #endregion
        //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : デフォルトコンストラクタ</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/27 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             自動送信の追加仕様変更</br>
        /// </remarks>
        private SalesSliptextAcs()
        {
            this._salesSliptextResultDB = (ISalesSliptextResultDB)MediationSalesSliptextResultDB.GetSalesSliptextResultDB();
            //出力テキストテーブル初期化
            this._salesSliptextCsv = new DataTable();
            //---ADD　鄧潘ハン　2012/11/27 ---------------->>>>>
            //接続マスタの初期化
            this._connectInfoWorkAcs = new ConnectInfoWorkAcs();
            //---ADD　鄧潘ハン　2012/11/27 ----------------<<<<<
            //出力テキスト作成
            CreateDataTable();
        }

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : アクセスクラス インスタンス取得処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        public static SalesSliptextAcs GetInstance()
        {
            if (_salesSliptextAcs == null)
            {
                _salesSliptextAcs = new SalesSliptextAcs();
            }

            return _salesSliptextAcs;
        }

        #endregion

        // ===================================================================================== //
        // 属性
        // ===================================================================================== //
        # region ■Propertity

        /// <summary>
        /// 出力テキストテーブル
        /// </summary>
        public DataTable SalesSliptextCsv
        {
            get { return _salesSliptextCsv; }
        }

        #endregion


        // ===================================================================================== //
        // 検索処理メソッド
        // ===================================================================================== //
        # region ■Search Methods
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="salesSliptextCndtn">検索条件</param>
        /// <param name="tmy_id">TMY-ID</param>
        /// <param name="resultCount">抽出伝票件数</param>
        /// <param name="message">エラーメッセッジ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        public int SearchData(SalesSliptextCndtn salesSliptextCndtn, string tmy_id, ref int resultCount, ref string message)
        {
            return SearchDataProc(salesSliptextCndtn, tmy_id, ref resultCount, ref message);
        }
        # endregion 

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■Private Methods
        /// <summary>
        /// 検索処理Proc
        /// </summary>
        /// <param name="salesSliptextCndtn">検索条件</param>
        /// <param name="tmy_id">TMY-ID</param>
        /// <param name="resultCount">抽出伝票件数</param>
        /// <param name="message">エラーメッセッジ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理Proc</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             ①行N0.は明細の行N0.をそのままセットする仕様変更</br>
        /// <br>             ②数量は１００倍でセットする仕様変更</br>
        /// </remarks>
        private int SearchDataProc(SalesSliptextCndtn salesSliptextCndtn, string tmy_id, ref int resultCount, ref string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string rtMessage = string.Empty;
            //int salesDetailindex = 0;//DEL　鄧潘ハン　2012/11/21 Redmine33560
            double shipmentCntHiyagu = 0;//ADD　鄧潘ハン　2012/11/21 Redmine33560
            try
            {
                ArrayList salesSliptextList = null;
                this._salesSliptextListResult = new List<SalesSliptextResultWork>();

                // UIデータクラス→ワーク
                SalesSliptextCndtnWork cndtnWork = CopyToSalesSliptextCndtnWorkFromSalesSliptextCndtn(salesSliptextCndtn);
                object salesSliptextResultWork = null;
                
                status = this._salesSliptextResultDB.Search(out salesSliptextResultWork, (object)cndtnWork, out rtMessage);
                salesSliptextList = salesSliptextResultWork as ArrayList;
                //検索データがあるの場合、値をセットする
                if (salesSliptextList != null && salesSliptextList.Count > 0)
                {
                    resultCount = 1;
                    if (this._salesSliptextCsv != null && this._salesSliptextCsv.Rows.Count > 0)
                    {
                        this._salesSliptextCsv.Rows.Clear();
                    }
                    else
                    {
                        //なし。
                    } 
                    foreach (SalesSliptextResultWork resultWork in salesSliptextList)
                    {
                        this._salesSliptextListResult.Add(resultWork);
                    }
                    for (int index = 0; index < this._salesSliptextListResult.Count; index++)
                    {
                        //伝票一つずつ取得明細ﾃﾞｰﾀより採番
                        if (index > 0 && this._salesSliptextListResult[index - 1].SalesSlipNum != this._salesSliptextListResult[index].SalesSlipNum)
                        {
                            //salesDetailindex = 0;//DEL　鄧潘ハン　2012/11/21 Redmine33560
                            resultCount++;
                        }
                        else
                        {
                            //なし。
                        } 
                        //salesDetailindex++;//DEL　鄧潘ハン　2012/11/21 Redmine33560
                        DataRow dr = this._salesSliptextCsv.NewRow();
                        // データ区分
                        dr["DATADIV"] = "01";
                        // TMY-ID
                        dr["TMYID"] = SubStringOfByte(tmy_id,7);
                        // 得意先ｺｰﾄﾞ
                        dr["CUSTOMERCODE"] = this._salesSliptextListResult[index].CustomerCode.ToString("00000000");
                        // 売上日付
                        dr["SALESDATE"] = this._salesSliptextListResult[index].SalesDate.ToString();
                        // 売上伝票番号
                        dr["SALESSLIPNUM"] = this._salesSliptextListResult[index].SalesSlipNum;
                        // 売上行番号
                        //dr["SALESROWNO"] = SubStringOfByte(salesDetailindex.ToString(),2);//DEL　鄧潘ハン　2012/11/21 Redmine33560
                        dr["SALESROWNO"] = SubStringOfByte(this._salesSliptextListResult[index].SalesRowNo.ToString(), 2);//ADD　鄧潘ハン　2012/11/21 Redmine33560
                        // 商品番号
                        dr["GOODSNO"] = SubStringOfByte(this._salesSliptextListResult[index].GoodsNo,20);
                        // 商品メーカーコード
                        dr["GOODSMAKERCD"] = this._salesSliptextListResult[index].GoodsMakerCd.ToString();
                        // BL商品コード
                        if (this._salesSliptextListResult[index].BLGoodsCode != 0)
                        {
                           
                            dr["BLGOODSCODE"] = this._salesSliptextListResult[index].BLGoodsCode.ToString("00000");
                        }
                        else
                        {
                            dr["BLGOODSCODE"] = DBNull.Value;
                        }
                        // 出荷数
                        //dr["SHIPMENTCNT"] = SubStringOfByte(this._salesSliptextListResult[index].ShipmentCnt.ToString(),8);//DEL　鄧潘ハン　2012/11/21 Redmine33560
                        //---ADD　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
                        shipmentCntHiyagu = this._salesSliptextListResult[index].ShipmentCnt * 100;
                        dr["SHIPMENTCNT"] = SubStringOfByte(shipmentCntHiyagu.ToString(), 8);
                        //---ADD　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<
                        // 仕入先コード
                        if (this._salesSliptextListResult[index].SupplierCd >= 215700 && this._salesSliptextListResult[index].SupplierCd <= 215799)
                        {

                            dr["SUPPLIERCD"] = this._salesSliptextListResult[index].SupplierCd.ToString();
                        }
                        else
                        {
                            dr["SUPPLIERCD"] = DBNull.Value;
                        }
                        this._salesSliptextCsv.Rows.Add(dr);
                    }

                }
                else
                {
                    //なし。
                } 
            }
            catch (Exception ex)
            {
                ex.ToString();
                message = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            else if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else
            { 
               //なし。
            }
            
            return status;
        }

        #region[文字列　バイト数指定切り抜き]
        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        /// <remarks>
        /// <br>Note       : 文字列　バイト数指定切り抜き</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        protected static string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }
            else
            {
                //なし。
            }

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

            string resultString = string.Empty;

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount)
                {
                    break;
                }
                else
                {
                    //なし。
                }
            }

            // 終端の空白は削除
            return resultString;

        }
        #endregion

        /// <summary>
        /// 出力テキストテーブル作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出力テキストテーブル作成</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void CreateDataTable()
        {
            // スキーマ設定
            this._salesSliptextCsv = new DataTable("salesSliptextCsv");

            // データ区分
            this._salesSliptextCsv.Columns.Add("DATADIV", typeof(string));
            this._salesSliptextCsv.Columns["DATADIV"].DefaultValue = "";

            // TMY-ID
            this._salesSliptextCsv.Columns.Add("TMYID", typeof(string));
            this._salesSliptextCsv.Columns["TMYID"].DefaultValue = "";

            // 得意先ｺｰﾄﾞ
            this._salesSliptextCsv.Columns.Add("CUSTOMERCODE", typeof(string));
            this._salesSliptextCsv.Columns["CUSTOMERCODE"].DefaultValue = "";

            // 売上日付
            this._salesSliptextCsv.Columns.Add("SALESDATE", typeof(Int32));
            this._salesSliptextCsv.Columns["SALESDATE"].DefaultValue = 0;

            // 売上伝票番号
            this._salesSliptextCsv.Columns.Add("SALESSLIPNUM", typeof(Int32));
            this._salesSliptextCsv.Columns["SALESSLIPNUM"].DefaultValue = 0;

            // 売上行番号
            this._salesSliptextCsv.Columns.Add("SALESROWNO", typeof(Int32));
            this._salesSliptextCsv.Columns["SALESROWNO"].DefaultValue = 0; 

            // 商品番号
            this._salesSliptextCsv.Columns.Add("GOODSNO", typeof(string));
            this._salesSliptextCsv.Columns["GOODSNO"].DefaultValue = "";

            // 商品メーカーコード
            this._salesSliptextCsv.Columns.Add("GOODSMAKERCD", typeof(string));
            this._salesSliptextCsv.Columns["GOODSMAKERCD"].DefaultValue = "";

            // BL商品コード
            this._salesSliptextCsv.Columns.Add("BLGOODSCODE", typeof(string));
            this._salesSliptextCsv.Columns["BLGOODSCODE"].DefaultValue = "";

            // 出荷数
            this._salesSliptextCsv.Columns.Add("SHIPMENTCNT", typeof(Int32));
            this._salesSliptextCsv.Columns["SHIPMENTCNT"].DefaultValue = 0;

            // 仕入先コード
            this._salesSliptextCsv.Columns.Add("SUPPLIERCD", typeof(Int32));
            this._salesSliptextCsv.Columns["SUPPLIERCD"].DefaultValue = 0;  
        }

    　　
        /// <summary>
        /// クラスメンバーコピー処理（売上データテキスト出力（TMY)条件クラス⇒売上データテキスト出力（TMY)条件ワーククラス）
        /// </summary>
        /// <param name="cndtn">売上データテキスト出力（TMY)条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバーコピー処理（売上データテキスト出力（TMY)条件クラス⇒売上データテキスト出力（TMY)条件ワーククラス）</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private SalesSliptextCndtnWork CopyToSalesSliptextCndtnWorkFromSalesSliptextCndtn(SalesSliptextCndtn cndtn)
        {
            SalesSliptextCndtnWork cndtnWork = new SalesSliptextCndtnWork();

            cndtnWork.CarMngNo1 = cndtn.CarMngNo1;                 //車輌管理コード
            cndtnWork.CustAnalysCode1 = cndtn.CustAnalysCode1;     //得意先分析コード1
            cndtnWork.CustAnalysCode2 = cndtn.CustAnalysCode2;     //得意先分析コード2
            cndtnWork.CustAnalysCode3 = cndtn.CustAnalysCode3;     //得意先分析コード3
            cndtnWork.CustAnalysCode4 = cndtn.CustAnalysCode4;     //得意先分析コード4
            cndtnWork.CustAnalysCode5 = cndtn.CustAnalysCode5;     //得意先分析コード5 
            cndtnWork.CustAnalysCode6 = cndtn.CustAnalysCode6;     //得意先分析コード6
            cndtnWork.EnterpriseCode = cndtn.EnterpriseCode;       //企業コード
            cndtnWork.PartySaleSlipNum = cndtn.PartySaleSlipNum;   //相手先伝票番号
            cndtnWork.SalesDateEd = cndtn.SalesDateEd;             //対象日の終了日
            cndtnWork.SalesDateSt = cndtn.SalesDateSt;             //対象日の開始日
            cndtnWork.SlipNote = cndtn.SlipNote;                   //伝票備考
            cndtnWork.SlipNote2 = cndtn.SlipNote2;                 //伝票備考２
            cndtnWork.SlipNote3 = cndtn.SlipNote3;                 //伝票備考３
            cndtnWork.SupplierCd = cndtn.SupplierCd;               //仕入先コード

            return cndtnWork;
        }

        # region 自動送信の追加
        //---ADD　鄧潘ハン　2012/11/27 ---------------->>>>>
        /// <summary>
        /// Webサーバと送受信します。
        /// </summary>
        /// <param name="salesSliptextCndtn">条件</param>
        /// <param name="xmlfileDir">パス</param>
        /// <param name="fileNamepara">ファイル名</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : Webサーバと送受信します。</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/11/27</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             自動送信の追加仕様変更</br>
        /// <br>Update Note: 2013/01/15 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             自動送信の追加メッセージについての仕様変更</br>
        /// <br>Update Note: 2015/01/26 30757 佐々木　貴英</br>
        /// <br>管理番号   : 11000127-00</br>
        /// <br>             Httpsプロトコル送信時コマンドが送信されない不具合対策</br>
        /// </remarks>
        public int SendAndReceive(SalesSliptextCndtn salesSliptextCndtn, string xmlfileDir, string fileNamepara)
        {
            //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
            LogFile logger = new LogFile(true);
            Int16 errorCode = 0;
            Int16 errorKbn = 0;
            //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            string fileName = xmlfileDir + "\\" + fileNamepara + ".XML";
            ConnectInfoWork connectInfoWork = null;
            connectInfoWork = null;
            try
            {
                status = this._connectInfoWorkAcs.Read(out connectInfoWork, salesSliptextCndtn.EnterpriseCode, SUPPLIERCD);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = -1;
                //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
                logger.WriteErrorLog("SendAndReceive", "接続先情報の取得に失敗しました。", ex);
                //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<
                return status;
            }

            //if (connectInfoWork == null)//DEL　鄧潘ハン　2013/01/15 Redmine34342
            if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)//ADD　鄧潘ハン　2013/01/15 Redmine34342
            {
                status = -1;
                //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
                logger.WriteErrorLog("SendAndReceive", "接続先情報の取得に失敗しました。", null);
                //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<
                return status;
            }

            //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
            try
            {
                errorKbn = xPMPP9901(
                      connectInfoWork.OrderUrl          //---ドメイン
                    , connectInfoWork.StockCheckUrl     //---ドメイン以降のアドレス
                    , connectInfoWork.ConnectUserId     //---接続先の認証ID
                    , connectInfoWork.ConnectPassword   //---接続先の認証パスワード
                    , xmlfileDir                        //---送受信XMLのファイルパス
                    , fileNamepara                      //---送受信XMLのファイル名
                    , Convert.ToInt16(connectInfoWork.DaihatsuOrdreDiv)  //---プロトコル
                    , connectInfoWork.EnterpriseCode    //---企業コード
                    , connectInfoWork.LoginTimeoutVal   //---タイムアウト
                    , ref errorCode                     //---エラーコード
                    );

                if (0 != errorKbn)
                {
                    string errorMes = "予期せぬエラーが発生しました。";
                    status = -1;
                    if (1 >= errorKbn)
                    {
                        switch (errorCode)
                        {

                            case -3:
                                errorMes = string.Format("データ送信対象ファイルオープン処理でエラーが発生しました(AssignFile)({0})", fileNamepara);
                                break;
                            case -2:
                                errorMes = string.Format("データ送信対象ファイルがありません(AssignFile)({0})", fileNamepara);
                                break;
                            case -1:
                                errorMes = "データ送受信で予期せぬエラーが発生しました。";
                                break;
                            case 1:
                                errorMes = "回線オープンエラー(InternetAttemptConnect)";
                                break;
                            case 2:
                                errorMes = "回線オープンエラー(InternetOpen)";
                                break;
                            case 3:
                                errorMes = "回線オープンエラー(InternetConnect)";
                                break;
                            case 4:
                                errorMes = "回線オープンエラー(HttpOpenRequest)";
                                break;
                            case 5:
                                errorMes = "回線オープンエラー(InternetSetOption)";
                                break;
                        }
                    }
                    else if (2 == errorKbn)
                    {
                        errorMes = "データ送信エラー(SendRequest)";
                    }
                    else if (3 == errorKbn || 4 == errorKbn)
                    {
                        errorMes = "データ送受信エラー(HttpQueryInfo)";
                    }

                    logger.WriteErrorLog(
                          "xPMPP9901"
                        , string.Format("{0}（区分:{1} エラーコード:{2}）", errorMes, errorKbn, errorCode)
                        , null);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                logger.WriteErrorLog("xPMPP9901", "売上データの送受信に失敗しました。", ex);
                return status;
            }
            //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<

            //---DEL　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
            //string myString = ""; ;
            //string content = "";
            //string fileRecStream = "";
            //string errorMessage = "";

            //// 回線オープン処理
            //if (RequestOpen(connectInfoWork))
            //{
            //    HttpWebResponse response = null;
            //    try
            //    {
            //        // 送信電文データをXMLファイルに変換する
            //        content = ConvertUoeSndHedToXML(connectInfoWork, fileName);
            //
            //
            //        myString += STRING_BOUNDARY;
            //        myString += STRING_CHANGE_ROW;
            //        myString += "Content-Disposition: form-data; name=\"xml_data\"; ";
            //        myString += "filename=\"" + fileName + "\"";
            //        myString += STRING_CHANGE_ROW;
            //        myString += STRING_CHANGE_ROW;
            //
            //        myString = myString + content + STRING_CHANGE_ROW + STRING_BOUNDARY + "--" + STRING_CHANGE_ROW;
            //
            //        byte[] body = Encoding.ASCII.GetBytes(myString);
            //
            //        using (Stream reqStream = request.GetRequestStream())
            //        {
            //            reqStream.Write(body, 0, body.Length);
            //            reqStream.Close();
            //        }
            //        
            //        using (response = (HttpWebResponse)request.GetResponse())
            //        {
            //        
            //            Stream revStream = response.GetResponseStream();
            //            StreamReader sr = new StreamReader(revStream, Encoding.GetEncoding(932));
            //            fileRecStream = sr.ReadToEnd();
            //        
            //        }
            //    }
            //    catch (WebException ex)
            //    {
            //        errorMessage = ex.Message;
            //        status = -1;
            //        return status;
            //    }
            //    response.Close();
            //    try
            //    {
            //        //Recファイル作成
            //
            //        if (fileRecStream == string.Empty)
            //        {
            //            status = -1;
            //            errorMessage = "ﾃﾞｰﾀ受信中にｴﾗｰが発生(受信ファイル内容がありません) ";
            //            return status;
            //        }
            //
            //        //ファイル名は TMY-ID＋YYYYMM＋"RECV.XML"とする。（YYYYMMは画面指定された年月(対象日付の年月)）
            //        string fileRecName = xmlfileDir + "\\" + fileNamepara + "RECV.XML";
            //
            //        FileStream file = new FileStream(fileRecName, FileMode.Create);
            //
            //        file.Write(Encoding.UTF8.GetBytes(fileRecStream), 0, Encoding.UTF8.GetByteCount(fileRecStream));
            //        file.Close();
            //
            //    }
            //    catch (Exception ex)
            //    {
            //        ex.ToString();
            //        status = -1;
            //        return status;
            //    }
            //}
            //else
            //{
            //    status = -1;
            //    return status;
            //}
            //---DEL　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<
            return status;
        }

        //---DEL　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
        ///// <summary>
        ///// 回線オープン処理
        ///// </summary>
        ///// <param name="connectInfo">条件</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : 回線オープン処理</br>										
        ///// <br>Programmer : 鄧潘ハン</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>管理番号   : 10805731-00</br>
        ///// <br>             自動送信の追加仕様変更</br>
        ///// </remarks>
        //private bool RequestOpen(ConnectInfoWork connectInfo)
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
        //    if (connectInfo.DaihatsuOrdreDiv == 0)
        //    {
        //        httpHead = "http://";
        //    }
        //    else
        //    {
        //        httpHead = "https://";
        //    }
        //    //接続先情報マスタの発注手配区分（ダイハツ）＋接続先情報マスタの発注URL＋接続先情報マスタの在庫確認URL
        //    request = (HttpWebRequest)HttpWebRequest.Create(httpHead + connectInfo.OrderUrl + connectInfo.StockCheckUrl);
        //    request.Method = "POST";
        //    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        //    return true;
        //}

        ///// <summary>
        ///// 送信電文データをWebサービス用パラメータに変換する
        ///// </summary>
        ///// <param name="connectInfo">条件</param>
        ///// <param name="fileName">ファイル名</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : 送信電文データをWebサービス用パラメータに変換する</br>										
        ///// <br>Programmer : 鄧潘ハン</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>管理番号   : 10805731-00</br>
        ///// <br>             自動送信の追加仕様変更</br>
        ///// </remarks>
        //private string ConvertUoeSndHedToXML(ConnectInfoWork connectInfo, string fileName)
        //{
        //    // ヘッダ情報追加
        //    HeaderMake(connectInfo);
        //    string xmlFileString = "";
        //    xmlFileString = fileChange(fileName);
            
        //    return xmlFileString;
        //}

        ///// <summary>
        ///// ファイルを変更
        ///// </summary>
        ///// <param name="fileName">ファイル名</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : ファイルを変更</br>										
        ///// <br>Programmer : 鄧潘ハン</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>管理番号   : 10805731-00</br>
        ///// <br>             自動送信の追加仕様変更</br>
        ///// </remarks>
        //private string fileChange(string fileName)
        //{
        //    //ファイルへ送信
        //    string fileString = "";
        //    try
        //    {
        //        FileStream file = new FileStream(fileName, FileMode.Open);
        //        byte[] byDate = new byte[file.Length];
        //        char[] charDate = new char[file.Length];
        //        file.Read(byDate, 0, (int)file.Length);
        //        Decoder d = Encoding.UTF8.GetDecoder();
        //        d.GetChars(byDate, 0, byDate.Length, charDate, 0);
        //        for (int i = 0; i < charDate.Length; i++)
        //        {
        //            fileString = fileString + charDate[i];
        //        }
        //        file.Close();
        //    }
        //    catch (Exception)
        //    {
        //        fileString = "";
        //    }
        //    return fileString;
        //}

        
        ///// <summary>
        ///// ヘッダ情報追加
        ///// </summary>
        ///// <param name="connectInfo">条件</param>
        ///// <remarks>
        ///// <br>Note       :  ヘッダ情報追加</br>										
        ///// <br>Programmer : 鄧潘ハン</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>管理番号   : 10805731-00</br>
        ///// <br>             自動送信の追加仕様変更</br>
        ///// </remarks>
        //private void HeaderMake(ConnectInfoWork connectInfo)
        //{
        //    request.Accept = "*/*";
        //    request.Headers.Add("Accept-Language", "ja");
        //    //WSSE認証用の文字列を作る
        //    string wsse = CreateWSSEToken(connectInfo.ConnectUserId, connectInfo.ConnectPassword);

        //    request.Headers.Add("X-WSSE: " + wsse);

        //    request.ContentType = "multipart/form-data; boundary=" + STRING_BOUNDARY.Substring(2);
        //    request.KeepAlive = true;
        //    //接続先情報マスタのログインタイムアウト
        //    if (connectInfo.LoginTimeoutVal != 0)
        //    {
        //        request.Timeout = connectInfo.LoginTimeoutVal * 1000;
        //    }
        //}

        ///// <summary>
        ///// 16進数表記のSHA-1メッセージダイジェストを生成します。
        ///// </summary>
        ///// <param name="source">source</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : 16進数表記のSHA-1メッセージダイジェストを生成します。</br>										
        ///// <br>Programmer : 鄧潘ハン</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>管理番号   : 10805731-00</br>
        ///// <br>             自動送信の追加仕様変更</br>
        ///// </remarks>
        //private string GetDigest(string source)
        //{
        //    SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
        //    StringBuilder answer = new StringBuilder();
        //    foreach (Byte b in sha1.ComputeHash(Encoding.UTF8.GetBytes(source)))
        //    {
        //        if (b < 16)
        //        {
        //            answer.Append("0");
        //        }
        //        answer.Append(Convert.ToString(b, 16));
        //    }
        //    return answer.ToString();
        //}

        ///// <summary>
        ///// Nonceを生成します。
        ///// Nonceは精度の高い擬似乱数生成器を利用してください。
        ///// </summary>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : Nonceを生成します。</br>										
        ///// <br>Programmer : 鄧潘ハン</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>管理番号   : 10805731-00</br>
        ///// <br>             自動送信の追加仕様変更</br>
        ///// </remarks>
        //private string CreateNonce()
        //{
        //    Random r = new Random();
        //    double d1 = r.NextDouble();
        //    double d2 = d1 * d1;
        //    return GetDigest(d2.ToString());
        //}

        ///// <summary>
        ///// Nonceを生成します。
        ///// Nonceは精度の高い擬似乱数生成器を利用してください。
        ///// </summary>
        ///// <param name="userName">userName</param>
        ///// <param name="password">password</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : Nonceを生成します。</br>										
        ///// <br>Programmer : 鄧潘ハン</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>管理番号   : 10805731-00</br>
        ///// <br>             自動送信の追加仕様変更</br>
        ///// </remarks>
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
        //---DEL　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<
        //---ADD　鄧潘ハン　2012/11/27 ----------------<<<<<

        //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ---------------->>>>>
        /// <summary>
        /// ログ記録クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : [InstallDirectory]\Log\PMKHN07703A_yyyyMMdd_HHmmss.log を作成します。</br>										
        /// <br>Programmer : 30757 佐々木　貴英</br>										
        /// <br>Date       : 2015/01/19</br>										
        /// <br>管理番号   : 11000127-00</br>
        /// <br>             Httpsプロトコル送信時コマンドが送信されない不具合対策</br>
        /// </remarks>
        public class LogFile
        {
            const string _logFileNameFormat = @"PMKHN07703A_{0:yyyyMMdd_HHmmss}.log";

            private bool _errorFlg = false;
            private string _folderPath = string.Empty;
            private string _fileName = string.Empty;

            /// <summary>
            /// エラーフラグを取得します。
            /// </summary>
            /// <remarks>
            /// エラーログが１回でも記録された場合は True を返す。
            /// </remarks>
            public bool ErrorFlg
            {
                get { return this._errorFlg; }
            }

            /// <summary>
            /// ログファイルのファイル名を取得します。
            /// </summary>
            /// <remarks>
            /// ログファイルのファイル名をフルパスで取得します。
            /// </remarks>
            public string FileName
            {
                get { return this._fileName; }
            }

            /// <summary>
            /// ログ記録クラス コンストラクタ
            /// </summary>
            /// <param name="clientMode">True: クライアントモード, False: サーバーモード</param>
            public LogFile(bool clientMode)
            {
                string keyPath = "";

                if (clientMode)
                {
                    // クラインアント
                    keyPath = @String.Format(@"SOFTWARE\Broadleaf\Product\Partsman");
                }

                else
                {
                    // サーバー
                    keyPath = @String.Format(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                }

                RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);

                try
                {
                    if (key.GetValue("InstallDirectory") != null)
                    {
                        this._folderPath = (string)key.GetValue("InstallDirectory");
                    }
                    else
                    {
                        // 取得できなかった場合は、保険としてアセンブリが配置されているフォルダを採用する
                        this._folderPath = System.AppDomain.CurrentDomain.BaseDirectory;
                    }

                    this._folderPath = Path.Combine(this._folderPath, "Log");
                }
                finally
                {
                    key.Close();
                }
            }

            /// <summary>
            /// エラーログ出力
            /// </summary>
            /// <param name="method">メソッド名</param>
            /// <param name="Msg">エラーテキスト</param>
            /// <param name="ex">例外オブジェクト</param>
            public void WriteErrorLog(string method, string Msg, Exception ex)
            {
                this._errorFlg = true;

                string exceptionMsg = "無し";
                if (ex != null)
                    exceptionMsg = ex.Message;
                string msg = string.Format("Msg:{0} Exception.Msg:{1}", Msg, exceptionMsg);
                WriteLog(method, msg);
            }

            /// <summary>
            /// ログ出力
            /// </summary>
            /// <param name="method">メソッド名</param>
            /// <param name="Msg">出力テキスト</param>
            public void WriteLog(string method, string Msg)
            {
                string msg = string.Format("Method:{0} {1}", method, Msg);
                Write(msg);
            }

            /// <summary>
            /// 例外ログ出力
            /// </summary>
            /// <param name="ex">例外オブジェクト</param>
            /// <param name="text">出力テキスト</param>
            public void Write(Exception ex, string text)
            {
                this._errorFlg = true;

                string exceptionMsg = "無し";
                if (ex != null)
                    exceptionMsg = ex.Message;

                if (string.IsNullOrEmpty(text))
                {
                    this.Write(exceptionMsg);
                }
                else
                {
                    this.Write(string.Format("{0} ({1})", exceptionMsg, text));
                }
            }

            /// <summary>
            /// ログ出力
            /// </summary>
            /// <param name="text">出力テキスト</param>
            public void Write(string text)
            {
                string contents = string.Empty;

                if (string.IsNullOrEmpty(this._fileName))
                {
                    this._fileName = System.IO.Path.Combine(this._folderPath, string.Format(_logFileNameFormat, DateTime.Now));
                }

                contents = string.Format("[{0:HH:mm:ss}] {1}" + Environment.NewLine, DateTime.Now, text);

                if (!System.IO.Directory.Exists(this._folderPath))
                {
                    // ログフォルダが存在しない場合は作成する
                    System.IO.Directory.CreateDirectory(this._folderPath);
                }

                // ログの追記
                System.IO.File.AppendAllText(this._fileName, contents);
            }
        }
        //---ADD　30757 佐々木　貴英　2015/01/26 Httpsプロトコル送信時コマンドが送信されない不具合対策 ----------------<<<<<<
        # endregion 
     # endregion
    }
}