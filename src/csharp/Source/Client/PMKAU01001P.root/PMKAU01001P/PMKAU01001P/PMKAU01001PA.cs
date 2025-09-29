//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 請求書発行（電子帳簿連携）自由帳票（請求書）印刷クラス
// プログラム概要   : 請求書発行（電子帳簿連携）自由帳票（請求書）印刷クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00  作成担当 : 陳艶丹
// 作 成 日  2022/03/07   修正内容 : 請求書発行（電子帳簿連携）新規作成
//----------------------------------------------------------------------------//
// 管理番号  11870080-00  作成担当 : 陳艶丹
// 作 成 日  2022/04/21   修正内容 : 電子帳簿2次対応
//----------------------------------------------------------------------------//
// 管理番号  11800082-00   作成担当 : 陳艶丹
// 作 成 日  2023/01/10    修正内容 : 電子帳簿連携（請求書）のCSV出力順番対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using ar = DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;
using System.Drawing.Printing;
using Broadleaf.Windows.Forms;
using System.Drawing;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 請求書発行（電子帳簿連携）自由帳票（請求書）印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 自由帳票（請求書）の印刷を行う。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/08</br>
    /// <br>Update Note : 2022/04/21 陳艶丹</br>
    /// <br>管理番号    : 11870080-00 電子帳簿2次対応</br>  
    /// <br>Update Note : 2023/01/10 陳艶丹</br>
    /// <br>管理番号    : 11800082-00 電子帳簿連携（請求書）のCSV出力順番対応</br>
    /// </remarks>
    public class PMKAU01001PA : IPrintProc, IDisposable
    {
        #region ■ Constructor
        /// <summary>
        /// 自由帳票（請求書）印刷クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由帳票（請求書）印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        public PMKAU01001PA()
        {
            _reportCtrl = PMCMN02001CA.GetInstance();
            _reportCtrl.BeforePrintEditLine += new PMCMN02001CA.BeforePrintEditLineHandler(_reportCtrl_BeforePrintEditLine);
        }

        /// <summary>
        /// 自由帳票（請求書）印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 自由帳票（請求書）印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        public PMKAU01001PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;

            _reportCtrl = PMCMN02001CA.GetInstance();
        }
        #endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        private const string ct_Extr_Top = "ＴＯＰ";
        private const string ct_Extr_End = "ＥＮＤ";
        private const string ct_RangeConst = "：{0} ～ {1}";

        private const int EXSTATUS = -1;
        private const int INITSTATUS = 0;
        private const int INITCOUNT = 0;
        private const int FIRSTINDEX = 0;
        private const int INITVAR = 0;
        private const int COPYCOUNT = 0;
        private const int TAGPARAMSLENGTH = 1;
        private const int MARKLEN = 2;
        private const int DEPODTLGROPUCOUNT = 2;
        private const int CONSTAXLAYMETHODNOTAX = 9;

        private const string CT_LINEFORMAT = "74,";
        private const string CT_CUSTOMSTR = "Custom";
        private const string CT_FONT = "ＭＳゴシック";
        private const string CT_TRIANGLE = "▲";
        private const string CT_HOURMS = "_yyyyMMdd_HHmmss";
        private const string CT_YEARMD = "_yyyyMMdd_HHmmssff";
        private const string CT_YEARMD2 = "_yyyyMMddHHmmssff";// ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応
        private const string CT_PDFFILE = ".pdf";
        private const string CT_FOOTERTITLEOFSLIP = "*伝票計*";
        private const string CT_FOOTERTITLEOFDAILY = "*日計*";
        private const string CT_FOOTERTITLEOFCUSTOMER = "*得意先計*";
        private const string CT_TAXTITLE = "消費税";
        private const string CT_OFSTHISSALESTAXINCTTL = "*売上合計金額(税込)*";
        private const string CT_CARMNGCODETITLE = "プレート番号";
        private const string CT_FOOTERTITLEOFTAX = "*消費税*";
        private const string CT_FOOTERTITLEOFSLIPTAXINC = "*課税合計*";
        private const string CT_DEPOSITFOOTERTITLEOFSLIP = "*入金計*";
        private const string CT_FOOTERTITLEOFSLIPTAXINC2 = "課税合計";
        private const string CT_REPORTFORM_NAMESPACE = "Broadleaf.Drawing.Printing";
        private const string CT_ASSEMBLYID = "PMKAU01001P";
        private const string CT_STOPERR = "印刷処理を中断しました。";
        private const string CT_SEETINGERRNOPRT = "設定が不正な為、印刷出来ませんでした。";
        private const string CT_TITLE = "請求書";
        private const string CT_NOTEXIST = "が存在しません。";
        private const string CT_BILLALLST = "請求全体設定";
        private const string CT_BILLINITST = "請求初期値設定";
        private const string CT_BILLPRTPATTERNST = "請求書印刷パターン設定";
        private const string CT_FREPRTPSET = "自由帳票印字位置設定";
        private const string CT_PRINTERST = "プリンタ設定";
        private const string CT_BILLDATA = "請求書データ";
        private const string CT_SEETINGERRNODATA = "設定が不正な為、印刷できないデータがありました。";

        /// <summary>
        /// ファイル名パターン
        /// </summary>
        private enum FileNameDivEnum : int
        {
            /// <summary>パターン１</summary>
            Pattern1 = 1,
            /// <summary>パターン２</summary>
            Pattern2 = 2,
            //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
            /// <summary>パターン３</summary>
            Pattern3 = 3
            //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
        }
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private bool _existsSalesTotalFooter;
        private bool _existsDepositTotalFooter;
        private int _feedAddCount;
        private string _footerTitleOfSlip;
        private string _footerTitleOfDaily;
        private string _footerTitleOfCustomer;
        private string _taxTitle;
        private string _ofsThisSalesTaxIncTtl;
        private Dictionary<int, List<PrintMarkScheme>> _printMarkDic;
        private List<string> _pdfPathList;
        private DateTime _OutPutDateTime;
        private List<string> _previewPdfPathList;
        private PMCMN02001CA _reportCtrl;
        private bool _printCancelFlag; // 印刷キャンセルフラグ
        private string _reportTitle; // 帳票タイトル
        private string _carmngCodeTitle;
        private string _slipTtlTaxTitle;
        private string _footerTitleOfTax;
        private string _footerTitleOfSlipTaxInc;
        private bool _existsSalesFooter;
        private bool _existsSalesFooter2;
        private bool _existsSalesFooter3;
        private bool _existsSalesHeader2;
        private Dictionary<string, Document> _documentByTypeDic;
        private Dictionary<string, Document> _orgDocuments;
        private List<ar.ActiveReport3> _prtRptList;
        private string _depositFooterTitleOfSlip;
        private string _footerTitleOfTax2;
        private string _footerTitleOfSlipTaxInc2;
        private bool _existsMesh;
        private int _lineCount;
        private int _formFeedLineCount = 0;
        private int _detailPrtCount = 1;
        private int _depoDtlPrcPrtDiv = 0;
        #endregion ■ Private Member

        /// <summary>
        /// メッセージ変更処理
        /// </summary>
        public event EventHandler MessageChange;

        #region ■ Exception Class
        /// <summary>
        /// 例外クラス
        /// </summary>
        /// <remarks>
        /// <br>Note        : 例外クラス</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private class StockMoveException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public StockMoveException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            #endregion

            #region ◆ Public Property
            /// <summary> ステータスプロパティ </summary>
            public int Status
            {
                get { return this._status; }
            }
            #endregion
        }
        #endregion ■ Exception Class

        #region ■ IPrintProc メンバ
        #region ◆ Public Property
        /// <summary>
        /// ＰＤＦ出力パス一覧プロパティ
        /// </summary>
        public List<string> PdfPathList
        {
            get { return _pdfPathList; }
            set { _pdfPathList = value; }
        }
        /// <summary>
        /// プレビュー用ＰＤＦ出力パス一覧プロパティ
        /// </summary>
        public List<string> PreviewPdfPathList
        {
            get { return _previewPdfPathList; }
            set { _previewPdfPathList = value; }
        }
        /// <summary>
        /// 印刷情報取得プロパティ
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        /// <summary>
        /// タイプ別ドキュメントディクショナリ
        /// </summary>
        public Dictionary<string, Document> DocumentByTypeDic
        {
            get
            {
                if (_documentByTypeDic == null)
                {
                    _documentByTypeDic = new Dictionary<string, Document>();
                }
                return _documentByTypeDic;
            }
            set { _documentByTypeDic = value; }
        }
        /// <summary>
        /// 出力日時
        /// </summary>
        public DateTime OutPutDateTime
        {
            get { return _OutPutDateTime; }
            set { _OutPutDateTime = value; }
        }
        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 印刷処理開始
        /// <summary>
        /// 印刷処理開始
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 印刷を開始する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        public int StartPrint()
        {
            int status = PrintMain();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                Form form = new Form();
                form.TopMost = true;
                TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_INFO, "PMKAU01001P", "印刷処理を中断しました。", 0, MessageBoxButtons.OK);
                form.TopMost = false;
            }
            return status;
        }
        #endregion
        #endregion ◆ Public Method
        #endregion ■ IPrintProc メンバ

        #region ■ Private Member
        #region ◆ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 印刷処理を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// <br>Update Note : 2022/04/21 陳艶丹</br>
        /// <br>管理番号    : 11870080-00 電子帳簿2次対応</br> 
        /// <br>Update Note : 2023/01/10 陳艶丹</br>
        /// <br>管理番号    : 11800082-00 電子帳簿連携（請求書）のCSV出力順番対応</br> 
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            _reportTitle = "請求書";

            ExtrInfo_EBooksDemandTotal cndtn = (this._printInfo.jyoken as ExtrInfo_EBooksDemandTotal);
            if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern2)
            {
                _reportTitle = string.Empty;
            }

            try
            {
                if ((this._printInfo.jyoken is ExtrInfo_EBooksDemandTotal) == false)
                {
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU01001P", "設定が不正な為、印刷出来ませんでした。", 0, MessageBoxButtons.OK);
                    form.TopMost = false;
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                // 印刷モード未設定の場合のデフォルト設定
                # region [印刷モード未設定]
                if (this._printInfo.printmode == 0)
                {
                    // 1:プレビューあり
                    this._printInfo.prevkbn = 1;
                    // 1:プリンタ（※プレビューありなので実際には印刷しない）
                    this._printInfo.printmode = 1;
                }
                # endregion

                // タイプ別印刷ドキュメントディクショナリ
                Dictionary<string, Document> documentsDic = new Dictionary<string, Document>();
                // 請求書別ドキュメントディクショナリ
                Dictionary<string, Document> orgDocuments = new Dictionary<string, Document>();

                // PDF出力一覧リスト
                _pdfPathList = new List<string>();

                DataSet printDataSet = (DataSet)this._printInfo.rdData;
                DataTable billData = printDataSet.Tables[PMKAU01002AB.CT_Tbl_BillList];

                // 抽出処理(E→A)でキャンセルされた場合のキャンセル処理
                if (billData.Rows.Count > 0)
                {
                    if ((bool)billData.Rows[0][PMKAU01002AB.CT_BillList_ExtractCancel] == true)
                    {
                        // キャンセル
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }

                // エラー理由ディクショナリ
                Dictionary<string, bool> errReasonDic = new Dictionary<string, bool>();
                errReasonDic.Add(PMKAU01002AB.CT_BillList_DmdPrtPtn, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_FrePrtPSet, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_FrePBillHead, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_PrtManage, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_BillAllSt, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_BillPrtSt, false);

                try
                {
                    string prevOutputFormFileName = string.Empty;
                    _printCancelFlag = false;
                    DataView billDataView = new DataView(billData);

                    //----------------------------------------------------------------
                    // 請求書のソート順
                    //----------------------------------------------------------------
                    # region [ヘッダのソート順]
                    int sortOrder = 0;
                    int customerAgentDivCd = 0;
                    if (this._printInfo.jyoken is ExtrInfo_EBooksDemandTotal)
                    {
                        // 請求書
                        sortOrder = cndtn.SortOrder;
                        customerAgentDivCd = cndtn.CustomerAgentDivCd;
                    }

                    switch (sortOrder)
                    {
                        // 担当者順
                        case 1:
                            {
                                if (customerAgentDivCd == 0)
                                {
                                    // 得意先担当者
                                    billDataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU01002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU01002AB.CT_BillList_CustomerAgentCd, // 担当者
                                                                        PMKAU01002AB.CT_BillList_ClaimCode,
                                                                        PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU01002AB.CT_BillList_CustomerCode);
                                }
                                else
                                {
                                    // 集金担当者
                                    billDataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU01002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU01002AB.CT_BillList_BillCollecterCd, // 集金担当者
                                                                        PMKAU01002AB.CT_BillList_ClaimCode,
                                                                        PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU01002AB.CT_BillList_CustomerCode);
                                }
                            }
                            break;
                        // 地区順
                        case 2:
                            {
                                billDataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU01002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU01002AB.CT_BillList_SalesAreaCode, // 地区
                                                                        PMKAU01002AB.CT_BillList_ClaimCode,
                                                                        PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU01002AB.CT_BillList_CustomerCode);
                            }
                            break;
                        // 得意先順
                        default:
                            {
                                billDataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}",
                                                                        PMKAU01002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU01002AB.CT_BillList_ClaimCode,
                                                                        PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU01002AB.CT_BillList_CustomerCode);
                            }
                            break;
                    }
                    # endregion

                    //---ADD 2023/01/10 陳艶丹 電子帳簿連携（請求書）のCSV出力順番の修正--->>>>>
                    //_printInfo内の印刷データ「_printInfo.rdData」を変更する「請求書のソート順追加」
                    DataSet rdDataDS = new DataSet();
                    rdDataDS.Tables.Add(billDataView.ToTable());
                    this._printInfo.rdData = rdDataDS;
                    //---ADD 2023/01/10 陳艶丹 電子帳簿連携（請求書）のCSV出力順番の修正---<<<<<

                    //----------------------------------------------------------------
                    // 「親を請求先に含める」ならば親レコードを除外
                    //----------------------------------------------------------------
                    # region [請求先に含める、対応]
                    // 拠点違いor得意先違いを対象とする（結果的に集計レコードも対象）
                    billDataView.RowFilter = string.Format("{0}<>{1} OR {2}<>{3}",
                                                PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                PMKAU01002AB.CT_BillList_ClaimCode,
                                                PMKAU01002AB.CT_BillList_CustomerCode);
                    # endregion

                    if (_printCancelFlag)
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }

                    // 処理後に全てのレポートを解放する為のリスト
                    if (_prtRptList != null)
                    {
                        foreach (ar.ActiveReport3 report in _prtRptList)
                        {
                            report.Dispose();
                        }
                    }
                    _prtRptList = new List<DataDynamics.ActiveReports.ActiveReport3>();

                    //----------------------------------------------------------------
                    // 請求書の印刷
                    //----------------------------------------------------------------
                    foreach (DataRowView billRowView in billDataView)
                    {
                        # region [請求書単位]
                        if (_printCancelFlag)
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        DataRow billRow = billRowView.Row;

                        // 必要マスタ情報がなければ「自由帳票(請求書)」としては対象外にします。
                        bool errCheck = false;
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_DmdPrtPtn])) { errReasonDic[PMKAU01002AB.CT_BillList_DmdPrtPtn] = true; errCheck = true; }
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_FrePrtPSet])) { errReasonDic[PMKAU01002AB.CT_BillList_FrePrtPSet] = true; errCheck = true; }
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_FrePBillHead])) { errReasonDic[PMKAU01002AB.CT_BillList_FrePBillHead] = true; errCheck = true; }
                        if (_printInfo.printmode != 2 && IsNull(billRow[PMKAU01002AB.CT_BillList_PrtManage])) { errReasonDic[PMKAU01002AB.CT_BillList_PrtManage] = true; errCheck = true; }
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_BillAllSt])) { errReasonDic[PMKAU01002AB.CT_BillList_BillAllSt] = true; errCheck = true; }
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_BillPrtSt])) { errReasonDic[PMKAU01002AB.CT_BillList_BillPrtSt] = true; errCheck = true; }
                        if (errCheck)
                        {
                            continue;
                        }

                        // 請求書印刷パターン設定 取得
                        DmdPrtPtnWork dmdPrtPtn = (DmdPrtPtnWork)billRow[PMKAU01002AB.CT_BillList_DmdPrtPtn];
                        // 自由帳票印字位置設定 取得
                        FrePrtPSetWork frePrtPSet = (FrePrtPSetWork)billRow[PMKAU01002AB.CT_BillList_FrePrtPSet];
                        // プリンタ管理設定 取得
                        PrtManage prtManage = null;
                        if (!IsNull(billRow[PMKAU01002AB.CT_BillList_PrtManage]))
                        {
                            prtManage = (PrtManage)billRow[PMKAU01002AB.CT_BillList_PrtManage];
                        }
                        // 請求印刷設定 取得
                        BillPrtStWork billPrtSt = (BillPrtStWork)billRow[PMKAU01002AB.CT_BillList_BillPrtSt];

                        // 印刷対象テーブル生成（１請求書単位）
                        DataTable printData = PMKAU01002AC.CreatePrintDataTable();
                        string outFileName = frePrtPSet.OutputFormFileName.Trim();
                        outFileName = this._printInfo.prpid;


                        if (prevOutputFormFileName != frePrtPSet.OutputFormFileName.Trim())
                        {
                            _existsSalesTotalFooter = false;
                            _existsDepositTotalFooter = false;
                            _existsSalesFooter = false;
                            _existsSalesFooter2 = false;
                            _existsSalesFooter3 = false;
                            _existsSalesHeader2 = false;
                            _existsMesh = false;
                            _feedAddCount = 0; // ２頁目以降の行数増分はデフォルト0
                            _printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                            this.SearchPrintLayout(frePrtPSet);
                        }
                        prevOutputFormFileName = outFileName;

                        _depoDtlPrcPrtDiv = dmdPrtPtn.DepoDtlPrcPrtDiv;
                        _formFeedLineCount = frePrtPSet.FormFeedLineCount;
                        _detailPrtCount = 1;

                        // 印刷レイアウトパラメータ
                        PMKAU01002AC.BillDmdPrintParameter parameter = new PMKAU01002AC.BillDmdPrintParameter();
                        # region [parameter]
                        parameter.OtherFeedAddCount = _feedAddCount;
                        parameter.ExistsSalesTotalFooter = _existsSalesTotalFooter;
                        parameter.ExistsDepositTotalFooter = _existsDepositTotalFooter;
                        parameter.FooterTitleOfSlip = _footerTitleOfSlip;
                        parameter.FooterTitleOfDaily = _footerTitleOfDaily;
                        parameter.FooterTitleOfCustomer = _footerTitleOfCustomer;
                        parameter.TaxTitle = _taxTitle;
                        parameter.OfsThisSalesTaxIncTtl = _ofsThisSalesTaxIncTtl;
                        parameter.CarmngCodeTitle = _carmngCodeTitle;
                        parameter.SlipTtlTaxTitle = _slipTtlTaxTitle;
                        parameter.FooterTitleOfTax = _footerTitleOfTax;
                        parameter.FooterTitleOfSlipTaxInc = _footerTitleOfSlipTaxInc;
                        parameter.ExistsSalesFooter = _existsSalesFooter;
                        parameter.ExistsSalesFooter2 = _existsSalesFooter2;
                        parameter.ExistsSalesFooter3 = _existsSalesFooter3;
                        parameter.ExistsSalesHeader2 = _existsSalesHeader2;
                        parameter.DepositFooterTitleOfSlip = _depositFooterTitleOfSlip;
                        parameter.FooterTitleOfSlipTaxInc2 = _footerTitleOfSlipTaxInc2;
                        parameter.FooterTitleOfTax2 = _footerTitleOfTax2;
                        # endregion

                        PMKAU01002AC.CopyToPrintDataTable(ref printData, this._printInfo.jyoken, billRow, parameter);

                        // 印刷データを頁単位に分ける
                        List<DataTable> printDataList = PMKAU01002AC.DevelopPrintDataList(ref printData);
                        if (printData != null)
                        {
                            printData.Dispose();
                        }

                        # region [印刷ドキュメント生成処理]
                        using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
                        {
                            ar.ActiveReport3 prtRpt = null;

                            // 複写枚数の取得
                            int copyCount;
                            # region [copyCount←dmdPrtPtn.CopyCount]
                            // 複写枚数をセット
                            if (dmdPrtPtn.CopyCount != 0)
                            {
                                // 複写=1　⇒1枚(控え0枚)
                                // 複写=2　⇒2枚(控え1枚)
                                copyCount = dmdPrtPtn.CopyCount;
                            }
                            else
                            {
                                // ｾﾞﾛは１に補正する。
                                copyCount = 1;
                            }
                            # endregion

                            // 複写分繰り返し
                            for (int copyIndex = 0; copyIndex < copyCount; copyIndex++)
                            {

                                // レイアウト違い繰り返し
                                for (int pageIndex = 0; pageIndex < printDataList.Count; pageIndex++)
                                {
                                    if (_printCancelFlag)
                                    {
                                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                    }

                                    printData = printDataList[pageIndex];
                                    bool isParent = PMKAU01002AC.IsParent(printData);
                                    int consTaxLayMethod = PMKAU01002AC.GetConsTaxLayMethod(printData);

                                    prtRpt = new ar.ActiveReport3();
                                    // 後で解放できるように退避
                                    _prtRptList.Add(prtRpt);

                                    # region [レポート基本設定]
                                    stream.Position = 0;
                                    prtRpt.LoadLayout(stream);
                                    prtRpt.Script = string.Empty; // スクリプト削除
                                    SetMargin(prtRpt, dmdPrtPtn);
                                    SetPrinterInfo(prtRpt.Document, prtManage);
                                    SFANL08235CE.SetValidPaperKind(prtRpt);
                                    _reportCtrl.SetReportProps(ref prtRpt); // 帳票共通設定
                                    prtRpt.DataSource = printData;
                                    prtRpt.DataMember = printData.TableName;
                                    SetReportPropsByPrinting(ref prtRpt); // 帳票に追加で設定
                                    # endregion

                                    # region [複写対応]
                                    // 複写時のタイトル差し替え
                                    // （※DataTableを書き換えるので、複写２枚目の時だけ実行すれば良い）
                                    if (copyIndex == 1)
                                    {
                                        PMKAU01002AC.SetCopyTitle(ref printData);
                                    }

                                    # endregion

                                    # region [明細デザイン対応]
                                    ReflectReportDesign(ref prtRpt, dmdPrtPtn, billPrtSt, pageIndex, isParent, consTaxLayMethod);
                                    # endregion

                                    // 印刷実行
                                    prtRpt.Run();

                                    // 記号印字
                                    PrintMarks(prtRpt, dmdPrtPtn);

                                    // タイプ別にドキュメントをまとめる
                                    if (!documentsDic.ContainsKey(dmdPrtPtn.SlipPrtSetPaperId))
                                    {
                                        Document document = new Document();
                                        SettingDocumentInfo(ref document, prtRpt, prtManage);
                                        documentsDic.Add(dmdPrtPtn.SlipPrtSetPaperId, document);
                                    }
                                    documentsDic[dmdPrtPtn.SlipPrtSetPaperId].Pages.AddRange(prtRpt.Document.Pages);

                                    // 請求書別にドキュメントをまとめる
                                    string derivedNo = string.Empty;
                                    if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern2)
                                    {
                                        derivedNo = PMKAU01002AC.GetDocumentDerivedNoForBatch(billRow);
                                    }
                                    //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>
                                    else if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern3)
                                    {
                                        derivedNo = PMKAU01002AC.GetDocumentDerivedNoForPattern3(billRow);
                                    }
                                    //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
                                    else
                                    {
                                        derivedNo = PMKAU01002AC.GetDocumentDerivedNo(billRow);
                                    }
                                    if (!orgDocuments.ContainsKey(derivedNo))
                                    {
                                        Document document = new Document();
                                        SettingDocumentInfo(ref document, prtRpt, prtManage);
                                        orgDocuments.Add(derivedNo, document);
                                    }
                                    orgDocuments[derivedNo].Pages.AddRange(prtRpt.Document.Pages);

                                }
                            }
                            stream.Close();
                        }

                        # endregion

                        if (printDataList != null)
                        {
                            foreach (DataTable table in printDataList)
                            {
                                table.Dispose();
                            }
                        }

                        # endregion
                    }

                    if (this.MessageChange != null)
                    {
                        // メッセージ変更処理
                        MessageChange(this, new EventArgs());
                    }

                    # region [印刷／ＰＤＦ出力]
                    if (_printCancelFlag)
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                    if (_printInfo.printmode == 1 || _printInfo.printmode == 3)
                    {
                        //-------------------------------------------
                        // ①印刷：タイプ毎に印刷実行
                        //-------------------------------------------
                        if (_printCancelFlag)
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        foreach (string typeName in documentsDic.Keys)
                        {
                            ExecutePrint(documentsDic[typeName], typeName, null);
                        }
                    }
                    if (_printInfo.printmode == 2 || _printInfo.printmode == 3)
                    {
                        //-------------------------------------------
                        // ②ＰＤＦ：請求書別出力
                        //-------------------------------------------
                        _pdfPathList = new List<string>();
                        foreach (string derivedNo in orgDocuments.Keys)
                        {
                            if (_printCancelFlag)
                            {
                                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            }
                            ExecutePrint(orgDocuments[derivedNo], derivedNo, _pdfPathList);
                        }
                    }
                    # endregion
                }
                finally
                {
                }

                string errorMessage = string.Empty;
                if (errReasonDic[PMKAU01002AB.CT_BillList_BillAllSt]) errorMessage += "請求全体設定" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_BillPrtSt]) errorMessage += "請求初期値設定" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_DmdPrtPtn]) errorMessage += "請求書印刷パターン設定" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_FrePrtPSet]) errorMessage += "自由帳票印字位置設定" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_PrtManage]) errorMessage += "プリンタ設定" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_FrePBillHead]) errorMessage += "請求書データ" + Environment.NewLine;

                if (errorMessage != string.Empty)
                {
                    errorMessage = "設定が不正な為、印刷できないデータがありました。" + Environment.NewLine + Environment.NewLine + errorMessage;
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU01001P", errorMessage, 0, MessageBoxButtons.OK);
                    form.TopMost = false;
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                // タイプ別ドキュメントをセット(外部から参照できるようにする)
                _documentByTypeDic = documentsDic;
                // 印刷ドキュメント退避(あとでDisposeする為)
                _orgDocuments = orgDocuments;
            }
            catch (Exception ex)
            {
                Form form = new Form();
                form.TopMost = true;
                TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU01001P", ex.Message, 0, MessageBoxButtons.OK);
                form.TopMost = false;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // 返却前に帳票名を書き換える(固定)
            _printInfo.prpnm = _reportTitle;


            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        # region [レポートに対する帳票属性設定処理]
        /// <summary>
        /// 帳票属性設定処理
        /// </summary>
        /// <param name="prtRpt">ActiveReport</param>
        /// <remarks>
        /// <br>Note        : 帳票属性設定処理を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SetReportPropsByPrinting(ref DataDynamics.ActiveReports.ActiveReport3 prtRpt)
        {
            if (_existsMesh)
            {
                // 行カウントを初期化
                _lineCount = 0;

                // "明細"セクションを取得
                ar.Section detail = prtRpt.Sections["Detail1"];
                if (detail != null && detail.Type == DataDynamics.ActiveReports.SectionType.Detail)
                {
                    // "明細"セクションの印刷前イベントを設定
                    detail.BeforePrint += new EventHandler(ReportDetail_BeforePrint);

                    // レポートの改ページイベントを設定
                    prtRpt.PageEnd += new EventHandler(Report_PageEnd);
                }
            }
        }
        /// <summary>
        /// 明細セクション印刷前処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベント</param>
        /// <remarks>
        /// <br>Note        : 明細セクション印刷前処理を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void ReportDetail_BeforePrint(object sender, EventArgs e)
        {
            if (sender is ar.Section)
            {
                ar.Section detail = (sender as ar.Section);
                foreach (ar.ARControl control in detail.Controls)
                {
                    // 74:網掛けの制御
                    if (control != null &&
                         control is ar.Shape &&
                         control.Tag is string &&
                         (control.Tag as string).StartsWith("74,"))
                    {
                        // 0,2,4,…行目 ⇒ 印字しない
                        // 1,3,5,…行目 ⇒ 印字する
                        control.Visible = ((_lineCount % 2) != 0);

                        // ※汎用的では無いが実際に影響は無いと思われるので、
                        //   高速化の為にbreakする。
                        break;
                    }
                }
            }
            _lineCount++;
        }
        /// <summary>
        /// レポート改ページ後処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベント</param>
        /// <remarks>
        /// <br>Note        : レポート改ページ後処理を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void Report_PageEnd(object sender, EventArgs e)
        {
            // 初期化
            _lineCount = 0;
        }
        # endregion
        /// <summary>
        /// 印刷キャンセル
        /// </summary>
        /// <remarks>
        /// <br>Note        : 印刷キャンセルを行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks> 
        public void Cancel()
        {
            // 印刷キャンセルフラグを立てる
            _printCancelFlag = true;
        }

        /// <summary>
        /// PDFキャンセルデリゲート定義
        /// </summary>
        /// <returns></returns>
        public delegate bool PDFCancelDelegate();

        /// <summary>
        /// PDF出力処理
        /// </summary>
        /// <param name="printInfo">印刷情報</param>
        /// <param name="documentsDic">ドキュメントDic</param>
        /// <param name="cancelDelegate">PDFキャンセルデリゲート</param>
        /// <returns>previewPdfPathList</returns>
        /// <remarks>
        /// <br>Note        : PDF出力処理を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks> 
        public static List<string> PrintPDF(ref SFCMN06002C printInfo, Dictionary<string, Document> documentsDic, PDFCancelDelegate cancelDelegate)
        {
            List<string> previewPdfPathList = new List<string>();

            // 帳票タイトル
            string reportTitle = "請求書";

            foreach (string typeName in documentsDic.Keys)
            {
                // キャンセル(delegateにより呼び出し元で判断)
                if (cancelDelegate != null && cancelDelegate())
                {
                    break;
                }

                //--------------------------------------------------
                // PDF帳票名
                //--------------------------------------------------
                # region [PDF帳票名]
                // PDF帳票名
                printInfo.prpnm = string.Format("{0}({1})", reportTitle, typeName);

                // 共通条件設定
                SFCMN00293UC commonInfo;
                SetPrintCommonInfo(out commonInfo, printInfo, reportTitle);
                printInfo.pdftemppath = commonInfo.PdfFullPath;
                if (previewPdfPathList != null)
                {
                    previewPdfPathList.Add(commonInfo.PdfFullPath);
                }
                # endregion

                //--------------------------------------------------
                // PDFエクスポート処理
                //--------------------------------------------------
                # region [PDFエクスポート処理]
                Document doc = documentsDic[typeName];
                DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
                try
                {
                    pdfExport1.Security.Permissions = ((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions)(((((((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyContents)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowCopy)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyAnnotations)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowFillIn)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAccessibleReaders)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAssembly)));

                    pdfExport1.Export(doc, printInfo.pdftemppath);
                    printInfo.status = 0;
                }
                catch
                {
                    printInfo.status = 9;
                }
                finally
                {
                    pdfExport1.Dispose();
                }
                # endregion

                //--------------------------------------------------
                // 出力履歴管理 追加
                //--------------------------------------------------
                # region [出力履歴管理 追加]
                if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (printInfo.printmode)
                    {
                        case 1:  // プリンタ
                            break;
                        case 2:  // ＰＤＦ
                            {
                                // ＰＤＦ表示フラグON
                                printInfo.pdfopen = true;
                            }
                            break;
                        case 3:  // 両方(プリンタ + ＰＤＦ)
                            {
                                // ＰＤＦ表示フラグON
                                printInfo.pdfopen = true;

                                // 出力履歴管理に追加
                                Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                pdfHistoryControl.AddPrintInfo(printInfo.key, reportTitle, reportTitle, printInfo.pdftemppath);
                                pdfHistoryControl.Dispose();
                            }
                            break;
                    }
                }
                # endregion
            }

            return previewPdfPathList;
        }
        /// <summary>
        /// 印刷共通情報設定(static用)
        /// </summary>
        /// <param name="commonInfo">共通情報</param>
        /// <param name="printInfo">印刷情報</param>
        /// <param name="reportTitle">帳票タイトル</param>
        /// <remarks>
        /// <br>Note        : 印刷共通情報設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private static void SetPrintCommonInfo(out SFCMN00293UC commonInfo, SFCMN06002C printInfo, string reportTitle)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // 帳票チャート共通部品クラス
            SFCMN00331C cmnCommon = new SFCMN00331C();

            // PDFパス取得
            string pdfPath = "";
            string pdfName = "";

            // プリンタ名
            commonInfo.PrinterName = string.Empty;
            // 帳票名
            commonInfo.PrintName = reportTitle;
            // 印刷モード

            try
            {
                commonInfo.PrintMode = printInfo.printmode;
            }
            catch
            {
                commonInfo.PrintMode = 1;
            }

            // 印刷件数表示
            commonInfo.PrintMax = 0;

            status = cmnCommon.GetPdfSavePathName(printInfo.prpnm, ref pdfPath, ref pdfName);
            printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = printInfo.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = 0;
            // 左余白
            commonInfo.MarginsLeft = 0;
        }

        /// <summary>
        /// 印刷ドキュメント情報設定
        /// </summary>
        /// <param name="printDocument">印刷用ドキュメント</param>
        /// <param name="prtRpt">印刷対象</param>
        /// <param name="prtManage">印刷管理対象</param>
        /// <remarks>
        /// <br>Note        : 印刷ドキュメント情報設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SettingDocumentInfo(ref Document printDocument, DataDynamics.ActiveReports.ActiveReport3 prtRpt, PrtManage prtManage)
        {
            if (prtRpt != null)
            {
                SetPrinterInfo(printDocument, prtManage);

                // 用紙の種類を指定
                printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                // 用紙サイズがカスタムの時は用紙サイズまで指定
                if (prtRpt.PageSettings.PaperKind == PaperKind.Custom)
                {
                    printDocument.Printer.PaperSize = new PaperSize("Custom", Convert.ToInt32(prtRpt.PageSettings.PaperWidth * 100), Convert.ToInt32(prtRpt.PageSettings.PaperHeight * 100));
                }
                // 用紙方向（縦・横）の設定
                if (prtRpt.PageSettings.Orientation == PageOrientation.Landscape)
                {
                    printDocument.Printer.Landscape = true;
                }
            }
        }


        /// <summary>
        /// 記号印刷処理
        /// </summary>
        /// <param name="prtRpt">印刷対象</param>
        /// <param name="dmdPrtPtn">印刷用ワーク</param>
        /// <remarks>
        /// <br>Note        : 記号印刷処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void PrintMarks(DataDynamics.ActiveReports.ActiveReport3 prtRpt, DmdPrtPtnWork dmdPrtPtn)
        {
            if (_printMarkDic == null || _printMarkDic.Count == 0) return;

            float adjustX = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.LeftMargin);
            float adjustY = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.TopMargin);

            foreach (Page page in prtRpt.Document.Pages)
            {
                // 折り返しマーク(>)
                foreach (PrintMarkScheme mark in _printMarkDic[64])
                {
                    page.TextAngle = 900; // 時計回り90.0度
                    page.ForeColor = mark.ForeColor;
                    page.Font = new System.Drawing.Font("ＭＳゴシック", mark.Size);
                    page.TextAlignment = DataDynamics.ActiveReports.TextAlignment.Left;
                    page.VerticalTextAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Top;
                    page.DrawText("▲", new System.Drawing.RectangleF(mark.Position.X + adjustX, mark.Position.Y + adjustY, 0.5f, 0.5f));
                }

                // 折り返しマーク(<)
                foreach (PrintMarkScheme mark in _printMarkDic[65])
                {
                    page.TextAngle = -900; // 反時計回り90.0度
                    page.ForeColor = mark.ForeColor;
                    page.Font = new System.Drawing.Font("ＭＳゴシック", mark.Size);
                    page.TextAlignment = DataDynamics.ActiveReports.TextAlignment.Left;
                    page.VerticalTextAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Top;
                    page.DrawText("▲", new System.Drawing.RectangleF(mark.Position.X + adjustX, mark.Position.Y + adjustY, 0.5f, 0.5f));
                }
            }
        }
        /// <summary>
        /// レイアウト情報取得（１ページ目のヘッダが何明細分に相当するかなど）
        /// </summary>
        /// <param name="frePrtPSet">レイアウト情報</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : レイアウト情報取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SearchPrintLayout(FrePrtPSetWork frePrtPSet)
        {
            // 初期値設定
            _feedAddCount = 0; // ２頁目以降の行数増分はデフォルト0
            _footerTitleOfSlip = "*伝票計*";
            _footerTitleOfDaily = "*日計*";
            _footerTitleOfCustomer = "*得意先計*";
            _taxTitle = "消費税";
            _ofsThisSalesTaxIncTtl = "*売上合計金額(税込)*";
            _carmngCodeTitle = "プレート番号";
            _footerTitleOfTax = "*消費税*";
            _footerTitleOfSlipTaxInc = "*課税合計*";
            _slipTtlTaxTitle = "消費税";
            _depositFooterTitleOfSlip = "*入金計*";
            _footerTitleOfSlipTaxInc2 = "課税合計";
            _footerTitleOfTax2 = "消費税";
            Dictionary<string, string> reportItemDic = new Dictionary<string, string>();

            // レイアウト情報の取り込み
            using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
            {
                // レイアウト情報取得
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout(stream);


                foreach (ar.Section section in prtRpt.Sections)
                {
                    foreach (ar.ARControl control in section.Controls)
                    {
                        // ディクショナリ追加
                        if (control is ar.TextBox && control.Tag is string)
                        {
                            string dataFieldName = control.DataField.ToUpper();
                            if (!reportItemDic.ContainsKey(dataFieldName))
                            {
                                reportItemDic.Add(dataFieldName, dataFieldName);
                            }
                        }
                        else if (control is ar.Barcode)
                        {
                            string dataFieldName = (control as ar.Barcode).DataField.ToUpper();
                            if (!reportItemDic.ContainsKey(dataFieldName))
                            {
                                reportItemDic.Add(dataFieldName, dataFieldName);
                            }
                        }
                        else if (control is ar.Label)
                        {
                            ar.Label label = (control as ar.Label);
                            const string subReportDataField = "FREEPRINT.SUBREPORT";

                            // レポート項目ディクショナリに追加
                            if (!reportItemDic.ContainsKey(subReportDataField))
                            {
                                reportItemDic.Add(subReportDataField, subReportDataField);
                            }
                        }

                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring(0, 3);

                        switch (tagText)
                        {
                            // 53:売上フッタ
                            case "53,":
                                _existsSalesFooter = true;
                                break;
                            // 売上集計フッタ
                            case "56,":
                                _existsSalesTotalFooter = true;
                                break;
                            // 入金集計フッタ
                            case "57,":
                                _existsDepositTotalFooter = true;
                                break;
                            // 58:レイアウト制御（１ページ目）
                            case "58,":
                                _feedAddCount += 1; // 既に出荷済みの旧ﾚｲｱｳﾄの互換性を保つため,＋１する
                                _feedAddCount += GetFeedAddCount(control);
                                break;
                            // 60:鑑消費税タイトル
                            case "60,":
                                _taxTitle = (control as ar.Label).Text;
                                break;
                            // 61:タイトル設定（伝票計）
                            case "61,":
                                _footerTitleOfSlip = (control as ar.Label).Text;
                                break;
                            // 62:タイトル設定（日計）
                            case "62,":
                                _footerTitleOfDaily = (control as ar.Label).Text;
                                break;
                            // 63:タイトル設定（得意先計）
                            case "63,":
                                _footerTitleOfCustomer = (control as ar.Label).Text;
                                break;
                            // 64:折り返しマーク(>)
                            case "64,":
                                if ((control as ar.Label).Visible)
                                {
                                    AddToMarkDic(64, (control as ar.Label));
                                }
                                (control as ar.Label).Visible = false;
                                break;
                            // 65:折り返しマーク(<)
                            case "65,":
                                if ((control as ar.Label).Visible)
                                {
                                    AddToMarkDic(65, (control as ar.Label));
                                }
                                (control as ar.Label).Visible = false;
                                break;
                            // 66:タイトル設定（プレート番号）
                            case "66,":
                                _carmngCodeTitle = (control as ar.Label).Text;
                                break;
                            // 2010/05/25 Add >>>
                            // 67:伝票合計消費税リテラル
                            case "67,":
                                _slipTtlTaxTitle = (control as ar.Label).Text;
                                break;
                            //68：売上フッタ２
                            case "68,":
                                _existsSalesFooter2 = true;
                                break;
                            //69:タイトル設定(消費税)
                            case "69,":
                                _footerTitleOfTax = (control as ar.Label).Text;
                                break;
                            //70：タイトル設定(課税合計)
                            case "70,":
                                _footerTitleOfSlipTaxInc = (control as ar.Label).Text;
                                break;
                            //71：相殺後売上合計金額(税込)タイトル
                            case "71,":
                                _ofsThisSalesTaxIncTtl = (control as ar.Label).Text;
                                break;
                            //72：売上フッタ３(山西商会個別用)
                            case "72,":
                                _existsSalesFooter3 = true;
                                break;
                            //73：売上ヘッダ２(山西商会個別用)
                            case "73,":
                                _existsSalesHeader2 = true;
                                break;
                            //74:明細網掛け
                            case "74,":
                                _existsMesh = true;
                                break;
                        }
                    }
                }

                PMKAU01002AC.ReportItemDic = reportItemDic;

                // ストリーム閉じる
                stream.Close();
            }
        }
        /// <summary>
        /// 記号ディクショナリに追加
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="arLabel">ラベル</param>
        /// <remarks>
        /// <br>Note        : 記号ディクショナリに追加</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void AddToMarkDic(int key, ar.Label arLabel)
        {
            string text = arLabel.Text;

            if (text.Contains(","))
            {
                string[] subText = text.Split(',');
                if (subText.Length >= 2)
                {
                    float posX = ToSingle(subText[0]);
                    float posY = ToSingle(subText[1]);

                    // ディクショナリが無ければ作成
                    if (_printMarkDic == null)
                    {
                        _printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                    }
                    // ディクショナリ内にリストが無ければ生成
                    if (!_printMarkDic.ContainsKey(key))
                    {
                        _printMarkDic.Add(key, new List<PrintMarkScheme>());
                    }

                    // ディクショナリ内リストに追加
                    _printMarkDic[key].Add(new PrintMarkScheme(new PointF(posX, posY), arLabel.ForeColor, arLabel.Font.Size));
                }
            }
        }
        /// <summary>
        /// 文字列→数値(float)変換
        /// </summary>
        /// <param name="text">変換テキスト</param>
        /// <returns>変換結果</returns>
        /// <remarks>
        /// <br>Note        : 文字列→数値(float)変換</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        static private float ToSingle(string text)
        {
            try
            {
                return float.Parse(text);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// コントロールからのFeedAddCount取得（テキストより）
        /// </summary>
        /// <param name="control">印字コントロール</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : コントロールからのFeedAddCount取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private int GetFeedAddCount(ar.ARControl control)
        {
            if (control is ar.Label)
            {
                return GetInt((control as ar.Label).Text);
            }
            return 0;
        }
        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text">変換テキスト</param>
        /// <returns>変換結果</returns>
        /// <remarks>
        /// <br>Note        : 数値変換処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private int GetInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 印刷実行
        /// </summary>
        /// <param name="printDocument">印刷ドキュメント</param>
        /// <param name="derivedNo"></param>
        /// <param name="pdfList">PDFファイル出力パスリスト</param>
        /// <remarks>
        /// <br>Note        : 印刷実行</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// <br>Update Note : 2022/04/21 陳艶丹</br>
        /// <br>管理番号    : 11870080-00 電子帳簿2次対応</br>  
        /// </remarks>
        private void ExecutePrint(Document printDocument, string derivedNo, List<string> pdfList)
        {

            // 名称設定
            ExtrInfo_EBooksDemandTotal cndtn = (this._printInfo.jyoken as ExtrInfo_EBooksDemandTotal);
            _OutPutDateTime = DateTime.Now;
            if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern1)
            {
                _printInfo.prpnm = string.Format("{0}({1})", _reportTitle, derivedNo) + _OutPutDateTime.ToString(CT_YEARMD) + CT_PDFFILE;
            }
            //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
            else if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern3)
            {
                _printInfo.prpnm = string.Format("{0}{1}", _reportTitle, derivedNo) + _OutPutDateTime.ToString(CT_YEARMD2) + CT_PDFFILE;
            }
            //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
            else
            {
                _printInfo.prpnm = string.Format("{0}{1}", _reportTitle, derivedNo) + _OutPutDateTime.ToString(CT_HOURMS) + CT_PDFFILE;
            }

            // 共通条件設定
            SFCMN00293UC commonInfo;
            SetPrintCommonInfo(out commonInfo);
            _printInfo.pdftemppath = commonInfo.PdfFullPath;
            if (pdfList != null)
            {
                pdfList.Add(commonInfo.PdfFullPath);
            }

            // プレビュー有無				
            int mode = this._printInfo.prevkbn;

            // 出力モードがＰＤＦの場合、無条件でプレビュー無
            if (this._printInfo.printmode == 2)
            {
                mode = 0;
            }

            switch (mode)
            {
                case 0:
                    {
                        // プレビュー無
                        # region [プレビュー無]
                        // ①直接印刷
                        if (this._printInfo.printmode == 1 || this._printInfo.printmode == 3)
                        {
                            bool printStatus = printDocument.Print(false, false, false);

                            if (printStatus)
                            {
                                this._printInfo.status = 0;
                            }
                            else
                            {
                                this._printInfo.status = 9;
                            }
                        }
                        // ②PDF出力
                        if (this._printInfo.printmode == 2 || this._printInfo.printmode == 3)
                        {
                            DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
                            try
                            {
                                pdfExport1.Security.Permissions = ((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions)(((((((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyContents)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowCopy)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyAnnotations)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowFillIn)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAccessibleReaders)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAssembly)));

                                pdfExport1.Export(printDocument, _printInfo.pdftemppath);
                                this._printInfo.status = 0;
                            }
                            catch
                            {
                                this._printInfo.status = 9;
                            }
                            finally
                            {
                                pdfExport1.Dispose();
                            }
                        }
                        # endregion

                        break;
                    }
                case 1:
                    {
                        // プレビュー有
                        # region [プレビュー有]
                        SFMIT01290UB para = new SFMIT01290UB();
                        para.PrintDocument = printDocument;
                        para.PreviewDocument = printDocument;
                        para.ExpansionRate = 50;

                        SFMIT01290UA form = new SFMIT01290UA();
                        this._printInfo.status = form.PrintPreviewDefaultSetting(para);
                        form.Dispose();
                        # endregion

                        break;
                    }
            }

            // ＰＤＦ出力の場合
            # region [ＰＤＦ出力の場合の処理]
            if (this._printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                switch (this._printInfo.printmode)
                {
                    case 1:  // プリンタ
                        break;
                    case 2:  // ＰＤＦ
                        {
                            // ＰＤＦ表示フラグON
                            this._printInfo.pdfopen = true;
                        }
                        break;
                    case 3:  // 両方(プリンタ + ＰＤＦ)
                        {
                            // ＰＤＦ表示フラグON
                            this._printInfo.pdfopen = true;

                            // 出力履歴管理に追加
                            Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                            pdfHistoryControl.AddPrintInfo(this._printInfo.key, _reportTitle, _reportTitle, this._printInfo.pdftemppath);
                            pdfHistoryControl.Dispose();
                        }
                        break;
                }
            }
            # endregion
        }

        /// <summary>
        /// 明細デザイン対応
        /// </summary>
        /// <param name="prtRpt">印刷対象</param>
        /// <param name="dmdPrtPtn">印刷用ワーク</param>
        /// <param name="billPrtSt">請求印刷設定</param>
        /// <param name="layoutChangeIndex">レイアウト変更インデックス</param>
        /// <param name="isParent">親フラグ</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <remarks>
        /// <br>Note        : 明細デザイン対応</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void ReflectReportDesign(ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, DmdPrtPtnWork dmdPrtPtn, BillPrtStWork billPrtSt, int layoutChangeIndex, bool isParent, int consTaxLayMethod)//ADD 2011/03/09
        {
            try
            {
                // 明細デザイン用ラベル
                ar.Label designSalesHeader = null;
                ar.Label designSalesDetail = null;
                ar.Label designSalesFooter = null;
                ar.Label designSalesTotal = null;
                ar.Label designDepositDetail = null;
                ar.Label designDepositTotal = null;
                ar.Label designSalesFooter2 = null;
                ar.Label designSalesFooter3 = null;
                ar.Label designSalesHeader2 = null;


                // 全セクション
                foreach (ar.Section section in prtRpt.Sections)
                {
                    if (section is ar.GroupHeader)
                    {
                        // グループ保持ＯＮ
                        (section as ar.GroupHeader).GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
                        // 繰り返しＯＮ
                        (section as ar.GroupHeader).RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
                        // 改ページフィールド
                        (section as ar.GroupHeader).DataField = PMKAU01002AC.ct_col_PageCount;
                    }

                    // セクションのコントロールを調査
                    foreach (ar.ARControl control in section.Controls)
                    {
                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring(0, 3);

                        switch (tagText)
                        {
                            case "51,":
                                designSalesHeader = (ar.Label)control;
                                break;
                            case "52,":
                                designSalesDetail = (ar.Label)control;
                                break;
                            case "53,":
                                designSalesFooter = (ar.Label)control;
                                break;
                            case "54,":
                                designDepositDetail = (ar.Label)control;
                                break;
                            case "56,":
                                designSalesTotal = (ar.Label)control;
                                break;
                            case "57,":
                                designDepositTotal = (ar.Label)control;
                                break;
                            case "55,":
                                {
                                    switch (dmdPrtPtn.CoNmPrintOutCd)
                                    {
                                        case 0:
                                            {
                                                // 0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない
                                                switch (billPrtSt.BillCoNmPrintOutCd)
                                                {
                                                    case 0:
                                                    case 1:
                                                        break;
                                                    case 2:
                                                    case 3:
                                                    default:
                                                        {
                                                            control.Visible = false;
                                                        }
                                                        break;
                                                }
                                            }
                                            break;
                                        case 1:
                                        case 2:
                                            break;
                                        case 3:
                                        case 4:
                                        default:
                                            {
                                                control.Visible = false;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "58,":
                                // レイアウト制御（１頁目）
                                // このコントロールの貼ってあるセクションを非印字にする
                                if (layoutChangeIndex != 0)
                                {
                                    section.Visible = false;
                                }
                                break;
                            case "59,":
                                // レイアウト制御（２頁目以降）
                                // このコントロールの貼ってあるセクションを非印字にする
                                if (layoutChangeIndex == 0)
                                {
                                    section.Visible = false;
                                }
                                break;
                            case "60,":
                                // 鑑消費税タイトル
                                if (!isParent || consTaxLayMethod == 9)
                                {
                                    control.Visible = false;
                                }
                                else
                                {
                                    control.DataField = PMKAU01002AC.ct_col_TaxTitle;
                                }
                                break;
                            case "64,":
                                // 折り返しマーク(>)
                                control.Visible = false;
                                break;
                            case "65,":
                                // 折り返しマーク(<)
                                control.Visible = false;
                                break;
                            default:
                                break;
                            case "68,":
                                designSalesFooter2 = (ar.Label)control;
                                break;
                            case "71,":
                                // 相殺後売上合計金額(税込)タイトル
                                if (!isParent || consTaxLayMethod == 9)
                                {
                                    control.Visible = false;
                                }
                                else
                                {
                                    control.DataField = PMKAU01002AC.ct_col_OfsThisSalesTaxIncTtl;
                                }
                                break;
                            case "72,":
                                //明細ガイド（売上フッタ３）
                                designSalesFooter3 = (ar.Label)control;
                                break;
                            //
                            case "73,":
                                //明細ガイド（売上ヘッダ２）
                                designSalesHeader2 = (ar.Label)control;
                                break;
                        }
                        // 各種ヘッダ・フッタのみ
                        if (section.Type != DataDynamics.ActiveReports.SectionType.Detail)
                        {
                            string[] tagParams;
                            //--------------------------------------------------
                            // 印刷ページ区分（全ページ／１ページ目のみ）の対応
                            //--------------------------------------------------
                            try
                            {
                                tagParams = ((string)control.Tag).Split(',');
                            }
                            catch
                            {
                                continue;
                            }
                            if (tagParams.Length > 1)
                            {
                                string printPageCtrlDivCd = tagParams[1].Trim();
                                if (printPageCtrlDivCd == "1")
                                {
                                    if (layoutChangeIndex != 0)
                                    {
                                        // 2ページ目以降
                                        control.Visible = false;
                                    }
                                    else
                                    {
                                        // 1ページ目
                                        control.Visible = true;
                                    }
                                }
                            }
                        }
                    }

                    # region [項目グループ化]
                    if (section is ar.Detail)
                    {
                        ar.Detail detail = (section as ar.Detail);

                        // 対象データフィールドリスト取得
                        List<string> salesHeaderList = PMKAU01002AC.GetDesignSalesHeaderList();
                        List<string> salesFooterList = PMKAU01002AC.GetDesignSalesFooterList();
                        List<string> salesDetailList = PMKAU01002AC.GetDesignSalesDetailList();
                        List<string> salesTotalList = PMKAU01002AC.GetDesignSalesTotalList();
                        List<string> depositDetailList = PMKAU01002AC.GetDesignDepositDetailList();
                        List<string> depositTotalList = PMKAU01002AC.GetDesignDepositTotalList();
                        List<string> salesFooter2List = PMKAU01002AC.GetDesignSalesFooter2List();
                        List<string> salesFooter3List = PMKAU01002AC.GetDesignSalesFooter3List();
                        List<string> salesHeader2List = PMKAU01002AC.GetDesignSalesHeader2List();

                        if (designSalesHeader == null)
                        {
                            // 売上ヘッダデザインガイドが無い場合は明細リストに移してヘッダリストをクリア
                            salesDetailList.AddRange(salesHeaderList);
                            salesHeaderList.Clear();
                        }
                        if (designSalesFooter == null)
                        {
                            // 売上フッタデザインガイドが無い場合は明細リストに移してフッタリストをクリア
                            salesDetailList.AddRange(salesFooterList);
                            salesFooterList.Clear();
                        }
                        if (designSalesTotal == null)
                        {
                            // 売上集計デザインガイドが無い場合は明細リストに移して売上集計リストをクリア
                            salesDetailList.AddRange(salesTotalList);
                            salesTotalList.Clear();
                        }
                        if (designSalesDetail == null)
                        {
                            // 売上明細デザインガイドが無い場合はリストをクリア
                            salesDetailList.Clear();
                        }
                        if (designDepositTotal == null)
                        {
                            // 入金集計デザインガイドが無い場合は明細リストに移して入金集計リストをクリア
                            depositDetailList.AddRange(depositTotalList);
                            depositTotalList.Clear();
                        }
                        if (designDepositDetail == null)
                        {
                            // 入金明細デザインガイドが無い場合はリストをクリア
                            depositDetailList.Clear();
                        }
                        if (designSalesFooter2 == null)
                        {
                            //売上フッタ２デザインガイドが無い場合は明細リストに移してフッタ２リストをクリア
                            salesDetailList.AddRange(salesFooter2List);
                            salesFooter2List.Clear();
                        }
                        if (designSalesFooter3 == null)
                        {
                            //売上フッタ３デザインガイドがない場合は明細リストに移してフッタ３リストをクリア
                            salesFooter3List.AddRange(salesFooter3List);
                            salesFooter3List.Clear();
                        }
                        if (designSalesHeader2 == null)
                        {
                            //売上ヘッダ２デザインガイドがない場合は明細リストに移してヘッダ２リストをクリア
                            salesHeader2List.AddRange(salesHeader2List);
                            salesHeader2List.Clear();
                        }

                        // 全てのコントロールを調査
                        foreach (ar.ARControl control in detail.Controls)
                        {
                            if (control is ar.TextBox)
                            {
                                string dataField = control.DataField.ToUpper();

                                if (salesHeaderList.Contains(dataField))
                                {
                                    // 売上ヘッダ項目の場合
                                    control.Top -= designSalesHeader.Top;
                                }
                                else if (salesFooterList.Contains(dataField))
                                {
                                    // 売上フッタ項目の場合
                                    control.Top -= designSalesFooter.Top;
                                }
                                else if (salesTotalList.Contains(dataField))
                                {
                                    // 売上集計項目の場合
                                    control.Top -= designSalesTotal.Top;
                                }
                                else if (salesDetailList.Contains(dataField))
                                {
                                    // 売上明細項目の場合
                                    control.Top -= designSalesDetail.Top;
                                }
                                else if (depositTotalList.Contains(dataField))
                                {
                                    // 入金集計項目の場合
                                    control.Top -= designDepositTotal.Top;
                                }
                                else if (depositDetailList.Contains(dataField))
                                {
                                    // 入金明細項目の場合
                                    control.Top -= designDepositDetail.Top;
                                }
                                else if (salesFooter2List.Contains(dataField))
                                {
                                    //売上フッタ２の場合
                                    control.Top -= designSalesFooter2.Top;
                                }
                                else if (salesFooter3List.Contains(dataField))
                                {
                                    //売上フッタ３の場合
                                    control.Top -= designSalesFooter3.Top;
                                }
                                else if (salesHeader2List.Contains(dataField))
                                {
                                    //売上ヘッダ２の場合
                                    control.Top -= designSalesHeader2.Top;
                                }
                            }
                        }
                    }
                    # endregion
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// DetailLineを描画するかどうかを判断します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : DetailLineを描画するかどうかを判断します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        void _reportCtrl_BeforePrintEditLine(object sender, PMCMN02001CA.BeforePrintEditLineEventArgs e)
        {
            if (e.Control.Name == "DetailLineRF")
            {
                if (_detailPrtCount <= _formFeedLineCount)
                {
                    // １頁目改頁チェック
                    if (_detailPrtCount == _formFeedLineCount)
                    {
                        (e.Control as ar.Line).LineColor = Color.Transparent;
                        _detailPrtCount++;
                        return;
                    }
                    _detailPrtCount++;
                }
                else
                {
                    // ２頁目以降改頁チェック
                    if (_detailPrtCount == _formFeedLineCount + _formFeedLineCount + _feedAddCount)
                    {
                        (e.Control as ar.Line).LineColor = Color.Transparent;
                        _detailPrtCount = _formFeedLineCount + 1;
                        return;
                    }
                    _detailPrtCount++;
                }
                // 伝票計行かチェック
                string SalesFtTitle = getSalesFtTitle(e.ControlList);
                if (string.IsNullOrEmpty(SalesFtTitle))
                {
                    (e.Control as ar.Line).LineColor = Color.Transparent;
                }
                else
                {
                    (e.Control as ar.Line).LineColor = Color.Black;
                }
            }
        }

        /// <summary>
        /// コントロールリストから売上伝票計タイトル・入金集計タイトル・入金額の内いずれかの値を取得します。
        /// </summary>
        /// <param name="arControlList">コントロールリスト</param>
        /// <returns>取得した値</returns>
        /// <remarks>
        /// <br>Note        : コントロールリストから売上伝票計タイトル・入金集計タイトル・入金額の内いずれかの値を取得します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        string getSalesFtTitle(List<ar.ARControl> arControlList)
        {
            string salesFtTitle = string.Empty;
            int hitCount = 0;
            bool countUpFlg = false;
            foreach (ar.ARControl cntrl in arControlList)
            {
                if (cntrl.Name == "SalesFtTitleRF")
                {
                    ar.TextBox textBox = cntrl as ar.TextBox;
                    salesFtTitle = textBox.Text;
                    hitCount++;
                }
                // 入金明細印字する（合計）
                if (_depoDtlPrcPrtDiv == 1)
                {
                    if (cntrl.Name == "DepositRF")
                    {
                        ar.TextBox textBox = cntrl as ar.TextBox;
                        salesFtTitle = textBox.Text;
                        hitCount++;
                    }
                }
                // 入金明細印字する（明細）
                else if (_depoDtlPrcPrtDiv == 2)
                {
                    if (cntrl.Name == "DetailSumPriceRF")
                    {
                        ar.TextBox textBox = cntrl as ar.TextBox;
                        salesFtTitle = textBox.Text;
                        hitCount++;
                    }
                }
                else
                {
                    if (!countUpFlg)
                    {
                        hitCount++;
                        countUpFlg = true;
                    }
                }
                if (string.IsNullOrEmpty(salesFtTitle))
                {
                    if (hitCount == 2) break;
                }
                else break;
            }
            return salesFtTitle;
        }

        /// <summary>
        /// テーブルセルのNULL判定処理
        /// </summary>
        /// <param name="cellObject">セル対象</param>
        /// <returns>NULLの判定結果</returns>
        /// <remarks>
        /// <br>Note        : テーブルセルのNULL判定処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private bool IsNull(object cellObject)
        {
            return (cellObject == null || cellObject == DBNull.Value);
        }

        /// <summary>
        /// 余白設定処理
        /// </summary>
        /// <param name="rpt">アクティブレポートオブジェクト</param>
        /// <param name="dmdPrtPtn">請求書印刷パターン</param>
        /// <remarks>
        /// <br>Note        : 余白設定をします。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SetMargin(ar.ActiveReport3 rpt, DmdPrtPtnWork dmdPrtPtn)
        {
            // 上の余白を設定
            rpt.PageSettings.Margins.Top
                = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.TopMargin);
            // 下の余白を設定
            rpt.PageSettings.Margins.Bottom
                = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.BottomMargin);
            // 左の余白を設定
            rpt.PageSettings.Margins.Left
                = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.LeftMargin);
            // 右の余白を設定
            rpt.PageSettings.Margins.Right
                = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.RightMargin);

            // ReportのPrintWidthがinch単位で中途半端な場合、不要な空ページが印刷されてしまうので防止する。
            // (小数第３位以降は切り捨てる)
            int width = (int)((float)rpt.PrintWidth * (float)100.0f);
            rpt.PrintWidth = (float)width / (float)100.0f;
            // 余白分を除く
            rpt.PrintWidth -= (rpt.PageSettings.Margins.Left + rpt.PageSettings.Margins.Right);
        }

        /// <summary>
        /// プリンター情報セット処理
        /// </summary>
        /// <param name="document">レポートDocument</param>
        /// <param name="prtManage">印刷管理</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : プリンター情報を設定します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SetPrinterInfo(Document document, PrtManage prtManage)
        {
            // 使用プリンターの設定
            if (prtManage != null)
            {
                document.Printer.PrinterSettings.PrinterName = prtManage.PrinterName;
            }
            else
            {
                document.Printer.PrinterSettings.PrinterName = string.Empty;
            }

            // 使用プリンタの有効有無チェック（有効では無い場合は仮想プリンタを使用）
            if (!document.Printer.PrinterSettings.IsValid)
                document.Printer.PrinterSettings.PrinterName = string.Empty;
        }

        #endregion ◆ 印刷処理

        #region ◆ レポートフォーム設定関連
        #region ◎ 各種ActiveReport帳票インスタンス作成
        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }
        #endregion

        #region ◎ レポートアセンブリインスタンス化
        /// <summary>
        /// レポートアセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="type">実装するクラス型</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private object LoadAssemblyReport(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new StockMoveException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new StockMoveException(er.Message, -1);
            }
            return obj;
        }
        #endregion

        #region ◎ 印刷画面共通情報設定

        /// <summary>
        /// ＰＤＦ出力ファイル名取得処理
        /// </summary>
        /// <param name="commonInfo">出力情報</param>
        /// <returns>status(0:正常,-1:エラー)</returns>
        /// <remarks>
        /// <br>Note        : ＰＤＦ出力パス名を取得します</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // 帳票チャート共通部品クラス
            SFCMN00331C cmnCommon = new SFCMN00331C();

            // PDFパス取得
            string pdfPath = "";
            string pdfName = "";

            // プリンタ名
            commonInfo.PrinterName = string.Empty;//prtManage.PrinterName;
            // 帳票名
            commonInfo.PrintName = _reportTitle;
            // 印刷モード

            try
            {
                commonInfo.PrintMode = this.Printinfo.printmode;
            }
            catch
            {
                commonInfo.PrintMode = 1;
            }

            // 印刷件数表示
            commonInfo.PrintMax = 0;

            if (!string.IsNullOrEmpty(this._printInfo.outPutFilePathName))
            {
                pdfPath = this._printInfo.outPutFilePathName + "\\";
            }
            else
            {
                status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            }
            this._printInfo.pdftemppath = pdfPath + this._printInfo.prpnm;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = 0;
            // 左余白
            commonInfo.MarginsLeft = 0;
        }

        #endregion

        #region ◎ 抽出範囲文字列作成
        /// <summary>
        /// 抽出範囲文字列作成
        /// </summary>
        /// <param name="title">タイトル</param>
        /// <param name="startString">開始文字列</param>
        /// <param name="endString">終了文字列</param>
        /// <returns>作成文字列</returns>
        /// <remarks>
        /// <br>Note       : 抽出範囲文字列を作成します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private string GetConditionRange(string title, string startString, string endString)
        {
            string result = "";
            if ((startString != "") || (endString != ""))
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if (startString != "") start = startString;
                if (endString != "") end = endString;
                result = String.Format(title + ct_RangeConst, start, end);
            }
            return result;
        }
        #endregion

        #region ◎ 抽出条件文字列編集
        /// <summary>
        /// 抽出条件文字列編集
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を編集します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            bool isEdit = false;

            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS(target);

            for (int i = 0; i < editArea.Count; i++)
            {
                int areaByte = 0;

                // 格納エリアのバイト数算出
                if (editArea[i] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[i]);
                }

                if ((areaByte + targetByte + 2) <= 190)
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[i] != null) editArea[i] += ct_Space;

                    editArea[i] += target;
                    break;
                }
            }
            // 新規編集エリア作成
            if (!isEdit)
            {
                editArea.Add(target);
            }
        }
        #endregion
        #endregion ◆ レポートフォーム設定関連

        #region ◎ メッセージ表示

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : 出力件数の設定を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            Form form = new Form();
            form.TopMost = true;
            DialogResult rst = TMsgDisp.Show(form, iLevel, "PMKAU01001P", iMsg, iSt, iButton, iDefButton);
            form.TopMost = false;
            return rst;
        }

        #endregion

        # region [印刷マーク定義]
        /// <summary>
        /// 印刷マーク定義
        /// </summary>
        internal struct PrintMarkScheme
        {
            /// <summary>印字位置</summary>
            private PointF _position;
            /// <summary>印字カラー</summary>
            private Color _foreColor;
            /// <summary>印字サイズ</summary>
            private float _size;
            /// <summary>
            /// 印字位置
            /// </summary>
            /// <remarks>インチ単位</remarks>
            public PointF Position
            {
                get { return _position; }
                set { _position = value; }
            }
            /// <summary>
            /// 印字カラー
            /// </summary>
            public Color ForeColor
            {
                get { return _foreColor; }
                set { _foreColor = value; }
            }
            /// <summary>
            /// 印字サイズ
            /// </summary>
            public float Size
            {
                get { return _size; }
                set { _size = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="position">印字位置</param>
            /// <param name="foreColor">印字カラー</param>
            /// <param name="size">印字サイズ</param>
            public PrintMarkScheme(PointF position, Color foreColor, float size)
            {
                _position = position;
                _foreColor = foreColor;
                _size = size;
            }
        }
        # endregion
        #endregion

        /// <summary>
        /// 破棄処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 破棄処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        public void Dispose()
        {
            // タイプ別ドキュメント解放
            if (_documentByTypeDic != null)
            {
                foreach (Document doc in _documentByTypeDic.Values)
                {
                    doc.Dispose();
                }
                _documentByTypeDic = null;
            }
            // 印刷ドキュメント解放
            if (_orgDocuments != null)
            {
                foreach (Document doc in _orgDocuments.Values)
                {
                    doc.Dispose();
                }
                _orgDocuments = null;
            }
            // 帳票共通部品キャッシュクリア
            if (_reportCtrl != null)
            {
                _reportCtrl.Clear();
                _reportCtrl = null;
            }
            // レポートクラス
            if (_prtRptList != null)
            {
                foreach (ar.ActiveReport3 report in _prtRptList)
                {
                    report.Dispose();
                }
                _prtRptList = null;
            }
        }
    }
}
