//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00 作成担当 : 譚洪
// 作 成 日  K2019/12/02 修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570219-00 作成担当 : 小原
// 作 成 日  2020/02/04  修正内容 : （修正内容一覧No.2）備考設定変更項目追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Microsoft.Win32;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信処理自起動
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送信処理自起動UIフォームクラス</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : K2019/12/02</br>
    /// </remarks>
    public partial class PMSDC04020UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Member
        // 売上データテキスト出力 アクセスクラス
        private SalesCprtAcs _salesCprtAcs;
        // 接続先情報設定 アクセスクラス
        private SalCprtConnectInfoWorkAcs _connectInfoWorkAcs;
        // 企業コード
        private string _enterpriseCode;

        /// <summary>ログメッセージ：送信準備エラー</summary>
        private const string LOGMSG_ERROR = "送信準備エラー";

        /// <summary>ログメッセージ：フォルダー不存在</summary>
        private const string LOGMSG_FOLDERERROR = "指定されたフォルダが存在しません";

        // 一日(millisecond)
        private const int _INTERVAL = 86400000;

        // 一分
        private const int _INTERVALMin = 60000;

        //  毎日初回実行Flg
        private bool fstRunFlg = false;

        // 起動時間が時間帯内Flg
        private bool aotoRunFlg = false;
        // 接続先情報設定List
        private ArrayList _connectInfoList = null;

        // 端末設定
        private PosTerminalMg _posTerminalMg = null;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 送信データフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信データフォームクラス デフォルトコンストラクタ</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        public PMSDC04020UA()
        {
            // 初期化処理
            InitializeComponent();
            // ログイン企業コード
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 売上データテキスト出力 アクセスクラス初期化
            _salesCprtAcs = new SalesCprtAcs();
            // 接続先アクセスクラス
            _connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 接続先情報設定取得
        /// </summary>
        /// <returns>接続先情報</returns>
        /// <remarks>
        /// <br>Note		: 接続先情報設定取得を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: K2019/12/02</br>
        /// </remarks>
        private ArrayList Read()
        {
            ArrayList connectInfoList = new ArrayList();
            connectInfoList.Clear();
            ArrayList aotoConnectInfoList = new ArrayList();
            aotoConnectInfoList.Clear();

            // 接続先情報設定取得
            int status = this._connectInfoWorkAcs.SearchAll(out connectInfoList, this._enterpriseCode);

            if (connectInfoList != null && connectInfoList.Count > 0)
            {
                foreach (SalCprtConnectInfoWork salCprtConnectInfoWork in connectInfoList)
                {
                    // 接続先設定マスタに登録済み端末番号の対応端末名称と一致する場合＆自動送信の場合
                    if (salCprtConnectInfoWork.LogicalDeleteCode == 0 
                        && salCprtConnectInfoWork.AutoSendDiv == 0
                        && (this._posTerminalMg.MachineName.ToUpper().Trim() == salCprtConnectInfoWork.SendMachineName.ToUpper().Trim()))
                    {
                        aotoConnectInfoList.Add(salCprtConnectInfoWork);
                    }
                }
            }

            if (aotoConnectInfoList != null && aotoConnectInfoList.Count > 0 &&
                status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return aotoConnectInfoList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 接続先情報設定
        /// </summary>
        /// <param name="connectInfoWork">接続先情報</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: 接続先情報設定を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: K2019/12/02</br>
        /// </remarks>
        private int Write(ref SalCprtConnectInfoWork connectInfoWork)
        {
            int status = 0;
            status = _connectInfoWorkAcs.Write(ref connectInfoWork, 0);
            return status;
        }

        /// <summary>
        /// 接続先マスタから検索パラメーター作成
        /// </summary>
        /// <remarks>
        /// <br>Note		: 接続先マスタから検索パラメーター作成を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: K2019/12/02</br>
        /// </remarks>
        private SalesCprtCndtnWork MakeSalesHistoryCndtn(SalCprtConnectInfoWork connectInfoWork)
        {
            SalesCprtCndtnWork retSalesCprtCndtn = new SalesCprtCndtnWork();
            // 企業コード
            retSalesCprtCndtn.EnterpriseCode = this._enterpriseCode;
            // 得意先コード
            retSalesCprtCndtn.CustomerCode = connectInfoWork.CustomerCode;
            // 拠点コード
            retSalesCprtCndtn.SectionCode = connectInfoWork.SectionCode.PadLeft(2,'0');

            // 検索開始時間
            try
            {
                retSalesCprtCndtn.SearchTimeSt = DateTime.ParseExact(connectInfoWork.FrstSendDate.ToString(), "yyyyMMdd", null);

            }
            catch
            {
                retSalesCprtCndtn.SearchTimeSt = DateTime.MinValue;
            }

            // 自動送信接続区分
            retSalesCprtCndtn.AutoDataSendDiv = connectInfoWork.CnectSendDiv;

            // 送信区分(0:手動;1:自動)
            retSalesCprtCndtn.SendDataDiv = 1; 

            return retSalesCprtCndtn;
        }

        /// <summary>
        /// 時間フォマット変更
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: 時間フォマット変更を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: K2019/12/02</br>
        /// </remarks>
        private int DateTimeToInt(DateTime dt)
        {
            return dt.Year * 10000 + dt.Month * 100 + dt.Day;
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : K2019/12/02</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMSDC04020U",						// アセンブリＩＤまたはクラスＩＤ
                "",              					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        /// <summary>
        /// イベントLoad
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">インベントパラメーター</param>
        /// <remarks>
        /// <br>Note       : 計時Timer</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        private void PMSDC04020UA_Load(object sender, EventArgs e)
        {
            // 端末設定の取得
            this.GetPosTerminalMg(out this._posTerminalMg, this._enterpriseCode);

            if (null == _posTerminalMg)
            {
                // 端末未設定時、常駐を起動しない
                this.Close();
                return;
            }

            // 接続先マスタ設定情報の取得
            this._connectInfoList = this.Read();

            if (null == _connectInfoList || _connectInfoList.Count == 0)
            {
                // 接続先マスタ設定取得できない時、常駐を起動しない
                this.Close();
                return;
            }

            this.Visible = false;
            this.notifyIcon1.Visible = true;

            // 送信時間帯内なら、自動送信起動
            int interval = getNextRunTime();
            if (!this.aotoRunFlg)
            {
                timer1.Interval = interval;
            }
            
            timer1.Enabled = true;
        }

        /// <summary>
        /// Timerの次回起動時間算出
        /// </summary>
        /// <remarks>
        /// <br>Note       : 次回実行時間計算</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        private int getNextRunTime()
        {
            SalCprtConnectInfoWork connectInfo = (SalCprtConnectInfoWork)_connectInfoList[0];

            // 起動時間
            string bootTime = connectInfo.BootTime.ToString().PadLeft(4, '0');
            // 終了時間
            string endTime = connectInfo.EndTime.ToString().PadLeft(4, '0');
            // システム時間取得
            double systemTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            double nextTime = connectInfo.ExecInterval * _INTERVALMin + systemTime;

            int stHours = 0;
            int stMinitus = 0;
            if (bootTime != "0")
            {
                stHours = Convert.ToInt16(bootTime.Substring(0, 2));
                stMinitus = Convert.ToInt16(bootTime.Substring(2, 2));
            }

            int edHours = 0;
            int edMinitus = 0;
            if (endTime != "0")
            {
                edHours = Convert.ToInt16(endTime.Substring(0, 2));
                edMinitus = Convert.ToInt16(endTime.Substring(2, 2));
            }

            double stTime = new TimeSpan(stHours, stMinitus, 0).TotalMilliseconds;
            double edTime = new TimeSpan(edHours, edMinitus, 0).TotalMilliseconds;

            int interval;

            this.fstRunFlg = false;
            // 接続先マスタ設定の起動時間 >= Now
            if (stTime.CompareTo(systemTime) >= 0)
            {
                interval = (int)(stTime - systemTime);
            }
            else
            {

                // Now > 接続先マスタ設定の終了時間
                if (systemTime.CompareTo(edTime) > 0 || nextTime.CompareTo(edTime) > 0)
                {
                    interval = (int)(_INTERVAL - systemTime + stTime);
                    this.fstRunFlg = true;
                }
                else
                {
                    interval = (int)(connectInfo.ExecInterval * _INTERVALMin);
                    this.aotoRunFlg = true;
                }
            }

            return interval;
        }

        /// <summary>
        /// 計時Timer
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">インベントパラメーター</param>
        /// <remarks>
        /// <br>Note       : 計時Timer</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;

                if (this.fstRunFlg)
                {
                    // 毎日の初回実行時、接続先マスタ設定情報の取得
                    this._connectInfoList = this.Read();
                    if (null == this._connectInfoList || this._connectInfoList.Count == 0)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "接続先情報設定マスタが登録されていません。", 0);
                        this.Close();
                        return;
                    }
                }
                // 自動送信処理
                foreach (SalCprtConnectInfoWork connectInfoWork in this._connectInfoList)
                {
                    this.SendDataAuto(connectInfoWork);
                }

                // 設定の実行間隔後に接続先マスタの起動時間再取得                   
                timer1.Interval = getNextRunTime();

                timer1.Enabled = true;
            }
        }

        /// <summary>
        /// 送信ファイル名を取る
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note		: 送信ファイル名を取る</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        private String GetXmlFileName(string fileName)
        {
            string xmlFileName = string.Empty;
            if (!String.IsNullOrEmpty(fileName))
            {
                if (fileName.Contains("."))
                {
                    int index = fileName.LastIndexOf(".");
                    fileName = fileName.Substring(0, index) + ".XML";
                }
                else
                {
                    fileName = fileName + ".XML";
                }
                xmlFileName = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.PRTOUT) + "\\" + fileName;
            }
            return xmlFileName;
        }

        /// <summary>
        /// 自動送信XML生成
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 自動送信XMLを生成する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int SaveNetSendSetting(string fileName, ref SalesCprtCndtnWork salesCprtCndtnWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            string xmlFileName = string.Empty;
            List<long> timeSortList = new List<long>();

            try
            {
                int rowsCount = this._salesCprtAcs.SalesHistoryDt.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // 更新日時初期化
                XmlElement update = null;
                // 伝票区分初期化
                XmlElement kubun = null;
                // 得意先ｺｰﾄﾞ初期化
                XmlElement kjcd = null;
                // 売上日付初期化
                XmlElement dndt = null;
                // 売上伝票番号初期化
                XmlElement dnno = null;
                // 売上行番号初期化uButton_SectionGuide
                XmlElement dngyno = null;
                // 品名初期化
                XmlElement pmncd = null;
                // メーカー名初期化
                XmlElement mkname = null;
                // BL商品コード初期化
                XmlElement blcd = null;
                // 出荷数初期化
                XmlElement sksu = null;
                // 売上単価初期化
                XmlElement unprc = null;
                // 売上金額初期化
                XmlElement taxexc = null;
                // 備考１初期化
                XmlElement note = null;
                // 備考2初期化
                XmlElement note2 = null;
                // 備考3初期化
                XmlElement note3 = null;
                // 元黒伝票番号初期化
                XmlElement mtdnno = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);

                long dateTimeLong = 0;
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // 更新日時
                    update = xmldoc.CreateElement("KOSINBI");
                    update.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["UpdateDateTime"].ToString();
                    if (long.TryParse(this._salesCprtAcs.SalesHistoryDt.Rows[i]["UpdateDateTime"].ToString(), out dateTimeLong))
                    {
                        timeSortList.Add(dateTimeLong);
                    }
                    data.AppendChild(update);

                    // 計上日
                    dndt = xmldoc.CreateElement("KEIJOBI");
                    dndt.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["AddUpADate"].ToString();
                    data.AppendChild(dndt);

                    // 売上伝票番号
                    dnno = xmldoc.CreateElement("DENNO");
                    dnno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesSlipNum"].ToString();
                    data.AppendChild(dnno);

                    // 売上行番号
                    dngyno = xmldoc.CreateElement("ROWNO");
                    dngyno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesRowNo"].ToString();
                    data.AppendChild(dngyno);

                    // 伝票区分
                    kubun = xmldoc.CreateElement("DENKUBUN");
                    kubun.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesSlipCd"].ToString();
                    data.AppendChild(kubun);

                    // 得意先ｺｰﾄﾞ
                    kjcd = xmldoc.CreateElement("TOKUCD");
                    kjcd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["CustomerCode"].ToString();
                    data.AppendChild(kjcd);

                    // BL商品コード
                    blcd = xmldoc.CreateElement("HINCD");
                    blcd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["BLGoodsCode"].ToString();
                    data.AppendChild(blcd);

                    // 品名
                    pmncd = xmldoc.CreateElement("HINMEI");
                    pmncd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["GoodsNameKana"].ToString();
                    data.AppendChild(pmncd);

                    // メーカー名
                    mkname = xmldoc.CreateElement("MAKERMEI");
                    mkname.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["MakerName"].ToString();
                    data.AppendChild(mkname);

                    // 出荷数
                    sksu = xmldoc.CreateElement("SYUKKASU");
                    sksu.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["ShipmentCnt"].ToString();
                    data.AppendChild(sksu);

                    // 売上単価
                    unprc = xmldoc.CreateElement("URITAN");
                    unprc.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesUnPrcTaxExcFl"].ToString();
                    data.AppendChild(unprc);

                    // 売上金額
                    taxexc = xmldoc.CreateElement("URIKIN");
                    taxexc.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesMoneyTaxExc"].ToString();
                    data.AppendChild(taxexc);

                    // 備考１
                    note = xmldoc.CreateElement("BIKO1");
                    note.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote"].ToString();
                    data.AppendChild(note);
                    // 備考２
                    note2 = xmldoc.CreateElement("BIKO2");
                    note2.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote2"].ToString();
                    data.AppendChild(note2);
                    // 備考３
                    note3 = xmldoc.CreateElement("BIKO3");
                    note3.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote3"].ToString();
                    data.AppendChild(note3);

                    // 元黒伝票番号
                    mtdnno = xmldoc.CreateElement("MOTODENNO");
                    mtdnno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["DebitNLnkSalesSlNum"].ToString();
                    data.AppendChild(mtdnno);

                    root.AppendChild(data);
                }

                timeSortList.Sort();
                long minTime = timeSortList[0];

                timeSortList.Reverse();
                long maxTime = timeSortList[0];

                salesCprtCndtnWork.SalesInfoTimeSt = minTime;
                salesCprtCndtnWork.SalesInfoTimeEd = maxTime;

                //XML書き込み
                xmlFileName = this.GetXmlFileName(fileName);
                xmldoc.Save(xmlFileName);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// XMLの削除
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: XMLの削除する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        private int DeleteXmlFile(string fileName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageDe = string.Empty;
            string xmlFileName = this.GetXmlFileName(fileName);
            try
            {
                // ファイルを削除
                FileInfo info = new FileInfo(xmlFileName);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show();
            }
        }

        /// <summary>
        /// 終了クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 確認メッセージを表示する。
            DialogResult result = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_QUESTION,                // エラーレベル
                        "PMSDC04020U",						                // アセンブリＩＤまたはクラスＩＤ
                        "売上連携自動送信",				                        // プログラム名称
                        "", 								            // 処理名称
                        "",									            // オペレーション
                        "終了処理を実行してもよろしいですか？",						    // 表示するメッセージ
                        -1, 							                // ステータス値
                        null, 								            // エラーが発生したオブジェクト
                        MessageBoxButtons.YesNo, 				        // 表示するボタン
                        MessageBoxDefaultButton.Button1);	            // 初期表示ボタン

            // 入力画面へ戻る。
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// 自動送信処理を行う。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自動送信処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/12/02</br>
        /// <br>Update Note : 2020/02/04 小原 卓也</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        public void SendDataAuto(SalCprtConnectInfoWork connectInfoWork)
        {
            int status = -1;
            string errMsg = "";

            int logStatus = 0;
            SalCprtSndLogListResultWork salCprtSndLogWork = null;

            // 抽出条件クラス作成
            SalesCprtCndtnWork salesCprtCndtn = MakeSalesHistoryCndtn(connectInfoWork);

            try
            {
                // データ抽出処理
                // --- UPD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
                //status = this._salesCprtAcs.SearchSalesHistoryProcMain(salesCprtCndtn, out errMsg);
                status = this._salesCprtAcs.SearchSalesHistoryProcMain(salesCprtCndtn, out errMsg, connectInfoWork);
                // --- UPD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
            }
            catch (Exception)
            {
                return;
            }

            // 自動送信XML生成
            string fileName = string.Empty;
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                fileName = connectInfoWork.CnectFileId;
            }
            else
            {
                return;
            }

            this.DeleteXmlFile(fileName);
            status = SaveNetSendSetting(fileName, ref salesCprtCndtn);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                status = this._salesCprtAcs.SendAndReceive(ref salesCprtCndtn, fileName, out salCprtSndLogWork, out logStatus);
            }
            
            //売上抽出データ更新処理
            try
            {
                if (status == 0)
                {
                    //データ更新処理
                    status = this._salesCprtAcs.Write(out errMsg);

                    if (status == 0)
                    {
                        // 売上連携接続情報マスタ更新
                        SalCprtConnectInfoWork updConnectInfo = connectInfoWork;
                        updConnectInfo.LtAtSadDateTime = DateTime.Now;

                        status = this._connectInfoWorkAcs.Write(ref updConnectInfo, 0);
                    }

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
            }

            return;
        }
        #endregion

        # region [端末設定取得]
        /// <summary>
        /// 端末設定取得処理
        /// </summary>
        /// <param name="posTerminalMg">POS端末管理設定</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 端末設定取得処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        private int GetPosTerminalMg(out PosTerminalMg posTerminalMg, string enterpriseCode)
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search(out posTerminalMg, enterpriseCode);
        }
        #endregion

    }
}