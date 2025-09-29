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
    /// 自由帳票（請求書）印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由帳票（請求書）の印刷を行う。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2008.06.17</br>
    /// <br></br>
    /// <br>Update Note  : 2009.09.28  22018  鈴木 正臣</br>
    /// <br>             : ㈱四日市モータース商会 個別請求書対応</br>
    /// <br>             : 　①２頁目以降の明細行数が不正になる不具合の修正。</br>
    /// <br>             : 　②２頁目以降印字しない制御を可能に変更。</br>
    /// <br></br>
    /// <br>Update Note  : 2009.12.11  30531  大矢 睦美</br>
    /// <br>             : タイトル設定（プレート番号）の項目の追加</br>
    /// <br></br>
    /// <br>Update Note  : 2010.02.03  22018  鈴木 正臣</br>
    /// <br>             : 請求書(総括)の対応</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/25  30517  夏野 駿希</br>
    /// <br>             : 森川部品㈱対応</br>
    /// <br>             : ③伝票合計消費税リテラル追加</br>
    /// <br></br>
    /// <br>Update Note  : 2010/06/16  30531  大矢 睦美</br>
    /// <br>             : ㈱竹田商会対応</br>
    /// <br>             : ①デザインガイド(売上フッタ２)処理追加</br>
    /// <br></br>
    /// <br>Update Note  : 2010/06/23  22018  鈴木 正臣</br>
    /// <br>             : 請求書印刷ページ指定対応</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/09  30531  大矢 睦美</br>
    /// <br>             : ㈲山西商会対応</br>
    /// <br>             : 個別項目追加</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/22  22018  鈴木 正臣</br>
    /// <br>             : アウトオブメモリエラーの対応</br>
    /// <br></br>
    /// <br>Update Note  : 2010/11/05  30517  夏野 駿希</br>
    /// <br>             : ㈲城光商会対応</br>
    /// <br>             : 個別項目追加（消費税・課税合計・*入金計*</br>
    /// <br></br>
    /// <br>Update Note  : 2010/11/10  22018  鈴木 正臣</br>
    /// <br>             : ・複写印刷対応</br>
    /// <br>             : ・使用済みレポートの解放処理を修正</br>
    /// <br></br>
    /// <br>Update Note  : 2010/11/16  22018  鈴木 正臣</br>
    /// <br>             : ・明細網掛け対応（交互に網掛け）</br>
    /// <br></br>
    /// <br>Update Note  : 2010/11/17  22018  鈴木 正臣</br>
    /// <br>             : ・自社名印字＝ビットマップで複数請求先の印刷時にエラーになる件の修正。</br>
    /// <br>             : ・冗長な処理(一度,印刷用DocumentにAddRangeしてから,もう一度別のDocumentにAddRangeする)を削除。</br>
    /// <br></br>
    /// <br>Update Note  : 2011/01/13  30517  夏野 駿希</br>
    /// <br>             : 台東部品商会個別対応</br>
    /// <br>             : 伝票計行の下に罫線を引く</br>
    /// <br>Update Note　: 2011/03/09 yangmj readmine #19751対応</br>
    /// <br></br>
    /// </remarks>
    // --- UPD m.suzuki 2010/07/22 ---------->>>>>
    //public class PMKAU08001PA : IPrintProc // m.suzuki 2009/03/10 internal→public
    public class PMKAU08001PA : IPrintProc, IDisposable
    // --- UPD m.suzuki 2010/07/22 ----------<<<<<
    {
        #region ■ Constructor
        /// <summary>
        /// 自由帳票（請求書）印刷クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由帳票（請求書）印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public PMKAU08001PA ()
        {
            _reportCtrl = PMCMN02000CA.GetInstance();
            // 2011/01/13 Add >>>
            _reportCtrl.BeforePrintEditLine += new PMCMN02000CA.BeforePrintEditLineHandler(_reportCtrl_BeforePrintEditLine);
            // 2011/01/13 Add <<<
        }

        /// <summary>
        /// 自由帳票（請求書）印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 自由帳票（請求書）印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public PMKAU08001PA ( object printInfo )
        {
            this._printInfo = printInfo as SFCMN06002C;

            _reportCtrl = PMCMN02000CA.GetInstance();
        }
        #endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        private const string ct_Extr_Top = "ＴＯＰ";
        private const string ct_Extr_End = "ＥＮＤ";
        private const string ct_RangeConst = "：{0} ～ {1}";
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
        // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
        private string _ofsThisSalesTaxIncTtl;
        // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
        private Dictionary<int, List<PrintMarkScheme>> _printMarkDic;
        private List<string> _pdfPathList;
        private List<string> _previewPdfPathList;
        private PMCMN02000CA _reportCtrl;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
        private bool _printCancelFlag; // 印刷キャンセルフラグ
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
        private string _reportTitle; // 帳票タイトル
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
        // --- ADD  大矢睦美  2009/12/11 ---------->>>>>
        private string _carmngCodeTitle;
        // --- ADD  大矢睦美  2009/12/11 ----------<<<<<
        // 2010/05/25 Add >>>
        private string _slipTtlTaxTitle;
        // 2010/05/25 Add <<<
        // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
        private string _footerTitleOfTax;
        private string _footerTitleOfSlipTaxInc;
        private bool _existsSalesFooter;
        private bool _existsSalesFooter2;
        // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
        // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
        private bool _existsSalesFooter3;
        private bool _existsSalesHeader2;
        // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
        // --- ADD m.suzuki 2010/08/05 ---------->>>>>
        private bool _existsMoneyKindCodeOther;
        // --- ADD m.suzuki 2010/08/05 ----------<<<<<
        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        private Dictionary<string, Document> _documentByTypeDic;
        private Dictionary<string, Document> _orgDocuments;
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<
        // --- ADD m.suzuki 2010/11/10 ---------->>>>>
        private List<ar.ActiveReport3> _prtRptList;
        // --- ADD m.suzuki 2010/11/10 ----------<<<<<
        // 2010/11/05 Add >>>
        private string _depositFooterTitleOfSlip;
        private string _footerTitleOfTax2;
        private string _footerTitleOfSlipTaxInc2;
        // 2010/11/05 Add <<<
        // --- ADD m.suzuki 2010/11/16 ---------->>>>>
        private bool _existsMesh;
        private int _lineCount;
        // --- ADD m.suzuki 2010/11/16 ----------<<<<<
        // 2011/01/13 Add >>>
        private int _formFeedLineCount = 0;
        private int _detailPrtCount = 1;
        private int _depoDtlPrcPrtDiv = 0;
        // 2011/01/13 Add <<<
        #endregion ■ Private Member

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        public event EventHandler MessageChange;
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        #region ■ Exception Class
        /// <summary> 例外クラス </summary>
        private class StockMoveException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public StockMoveException ( string message, int status )
                : base( message )
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
        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// タイプ別ドキュメントディクショナリ
        /// </summary>
        public Dictionary<string, Document> DocumentByTypeDic
        {
            get
            {
                if ( _documentByTypeDic == null )
                {
                    _documentByTypeDic = new Dictionary<string, Document>();
                }
                return _documentByTypeDic;
            }
            set { _documentByTypeDic = value; }
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<
        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 印刷処理開始
        /// <summary>
        /// 印刷処理開始
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷を開始する。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public int StartPrint ()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 DEL
            //return PrintMain();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
            int status = PrintMain();
            if ( status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL )
            {
                TMsgDisp.Show( emErrorLevel.ERR_LEVEL_INFO, "PMKAU08001P", "印刷処理を中断しました。", 0, MessageBoxButtons.OK );
            }
            return status;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
        }
        #endregion
        #endregion ◆ Public Method
        #endregion ■ IPrintProc メンバ

        #region ■ Private Member
        #region ◆ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        /// <br>Update Note: 2011/03/09 yangmj readmine #19751対応</br>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
            _reportTitle = "請求書";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD

            try
            {
                // --- UPD m.suzuki 2010/02/03 ---------->>>>>
                //if ( (this._printInfo.jyoken is ExtrInfo_DemandTotal) == false )
                if ( (this._printInfo.jyoken is ExtrInfo_DemandTotal) == false && (this._printInfo.jyoken is SumExtrInfo_DemandTotal) == false )
                // --- UPD m.suzuki 2010/02/03 ----------<<<<<
                {
                    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU08001P", "設定が不正な為、印刷出来ませんでした。", 0, MessageBoxButtons.OK );
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                // 印刷モード未設定の場合のデフォルト設定
                # region [印刷モード未設定]
                if ( this._printInfo.printmode == 0 )
                {
                    // 1:プレビューあり
                    this._printInfo.prevkbn = 1;
                    // 1:プリンタ（※プレビューありなので実際には印刷しない）
                    this._printInfo.printmode = 1;

# if DEBUG
                    //// プレビューなしＰＤＦテスト
                    //this._printInfo.prevkbn = 0;
                    //this._printInfo.printmode = 2;
# endif
                }
                # endregion

                // タイプ別印刷ドキュメントディクショナリ
                Dictionary<string, Document> documentsDic = new Dictionary<string, Document>();
                // 請求書別ドキュメントディクショナリ
                Dictionary<string, Document> orgDocuments = new Dictionary<string, Document>();

                // PDF出力一覧リスト
                _pdfPathList = new List<string>();

                DataSet printDataSet = (DataSet)this._printInfo.rdData;
                DataTable billData = printDataSet.Tables[PMKAU08002AB.CT_Tbl_BillList];

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                // 抽出処理(E→A)でキャンセルされた場合のキャンセル処理
                if ( billData.Rows.Count > 0 )
                {
                    if ( (bool)billData.Rows[0][PMKAU08002AB.CT_BillList_ExtractCancel] == true )
                    {
                        // キャンセル
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

                // エラー理由ディクショナリ
                Dictionary<string, bool> errReasonDic = new Dictionary<string, bool>();
                errReasonDic.Add( PMKAU08002AB.CT_BillList_DmdPrtPtn, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_FrePrtPSet, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_FrePBillHead, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_PrtManage, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_BillAllSt, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_BillPrtSt, false );

                // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                //SFCMN00299CA processingDialog = new SFCMN00299CA();
                //// --- ADD m.suzuki 2010/06/23 ---------->>>>>
                //bool disposed = false;
                //// --- ADD m.suzuki 2010/06/23 ----------<<<<<
                // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                try
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    string prevOutputFormFileName = string.Empty;
                    _printCancelFlag = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD

                    // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                    //processingDialog.Title = "印刷処理";
                    //processingDialog.Message = "現在、印刷準備中です。";
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 DEL
                    ////processingDialog.DispCancelButton = false;
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 DEL
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    //processingDialog.DispCancelButton = true;
                    //processingDialog.CancelButtonClick += new EventHandler( processingDialog_CancelButtonClick );
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                    //processingDialog.Show();
                    // --- DEL m.suzuki 2010/07/22 ----------<<<<<

                    DataView billDataView = new DataView( billData );

                    //----------------------------------------------------------------
                    // 請求書のソート順
                    //----------------------------------------------------------------
                    # region [ヘッダのソート順]
                    // --- UPD m.suzuki 2010/02/03 ---------->>>>>
                    //switch ( (this._printInfo.jyoken as ExtrInfo_DemandTotal).SortOrder )

                    int sortOrder = 0;
                    int customerAgentDivCd = 0;
                    int prCustDtl = 0;
                    if ( this._printInfo.jyoken is ExtrInfo_DemandTotal )
                    {
                        // 請求書
                        ExtrInfo_DemandTotal cndtn = (this._printInfo.jyoken as ExtrInfo_DemandTotal);
                        sortOrder = cndtn.SortOrder;
                        customerAgentDivCd = cndtn.CustomerAgentDivCd;
                        prCustDtl = cndtn.PrCustDtl;
                    }
                    else if ( this._printInfo.jyoken is SumExtrInfo_DemandTotal )
                    {
                        // 請求書(総括)
                        SumExtrInfo_DemandTotal sumCndtn = (this._printInfo.jyoken as SumExtrInfo_DemandTotal);
                        sortOrder = sumCndtn.SortOrder;
                        customerAgentDivCd = sumCndtn.CustomerAgentDivCd;
                        prCustDtl = 0;
                    }

                    switch ( sortOrder )
                    // --- UPD m.suzuki 2010/02/03 ----------<<<<<
                    {
                        // 担当者順
                        case 1:
                            {
                                // --- UPD m.suzuki 2010/02/03 ---------->>>>>
                                //if ( (this._printInfo.jyoken as ExtrInfo_DemandTotal).CustomerAgentDivCd == 0 )
                                if ( customerAgentDivCd == 0 )
                                // --- UPD m.suzuki 2010/02/03 ----------<<<<<
                                {
                                    // 得意先担当者
                                    billDataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU08002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU08002AB.CT_BillList_CustomerAgentCd, // 担当者
                                                                        PMKAU08002AB.CT_BillList_ClaimCode,
                                                                        PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU08002AB.CT_BillList_CustomerCode );
                                }
                                else
                                {
                                    // 集金担当者
                                    billDataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU08002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU08002AB.CT_BillList_BillCollecterCd, // 集金担当者
                                                                        PMKAU08002AB.CT_BillList_ClaimCode,
                                                                        PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU08002AB.CT_BillList_CustomerCode );
                                }
                            }
                            break;
                        // 地区順
                        case 2:
                            {
                                billDataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU08002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU08002AB.CT_BillList_SalesAreaCode, // 地区
                                                                        PMKAU08002AB.CT_BillList_ClaimCode,
                                                                        PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU08002AB.CT_BillList_CustomerCode );
                            }
                            break;
                        // 得意先順
                        default:
                            {
                                billDataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}",
                                                                        PMKAU08002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU08002AB.CT_BillList_ClaimCode,
                                                                        PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU08002AB.CT_BillList_CustomerCode );
                            }
                            break;
                    }
                    # endregion

                    //----------------------------------------------------------------
                    // 「親を請求先に含める」ならば親レコードを除外
                    //----------------------------------------------------------------
                    # region [請求先に含める、対応]
                    // --- UPD m.suzuki 2010/02/03 ---------->>>>>
                    //if ( (this._printInfo.jyoken as ExtrInfo_DemandTotal).PrCustDtl == 0 )
                    if ( prCustDtl == 0 )
                    // --- UPD m.suzuki 2010/02/03 ----------<<<<<
                    {
                        // 拠点違いor得意先違いを対象とする（結果的に集計レコードも対象）
                        billDataView.RowFilter = string.Format( "{0}<>{1} OR {2}<>{3}",
                                                    PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                    PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                    PMKAU08002AB.CT_BillList_ClaimCode,
                                                    PMKAU08002AB.CT_BillList_CustomerCode );
                    }
                    else
                    {
                        billDataView.RowFilter = string.Empty;
                    }
                    # endregion

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    if ( _printCancelFlag )
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD

                    // --- ADD m.suzuki 2010/11/17 ---------->>>>> // ループの中から移動
                    // 処理後に全てのレポートを解放する為のリスト
                    if ( _prtRptList != null )
                    {
                        foreach ( ar.ActiveReport3 report in _prtRptList )
                        {
                            report.Dispose();
                        }
                    }
                    _prtRptList = new List<DataDynamics.ActiveReports.ActiveReport3>();
                    // --- ADD m.suzuki 2010/11/17 ----------<<<<<

                    //----------------------------------------------------------------
                    // 請求書の印刷
                    //----------------------------------------------------------------
                    foreach ( DataRowView billRowView in billDataView )
                    {
                        # region [請求書単位]
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                        if ( _printCancelFlag )
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                        DataRow billRow = billRowView.Row;

                        // 必要マスタ情報がなければ「自由帳票(請求書)」としては対象外にします。
                        bool errCheck = false;
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_DmdPrtPtn] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_DmdPrtPtn] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_FrePrtPSet] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_FrePrtPSet] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_FrePBillHead] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_FrePBillHead] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_PrtManage] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_PrtManage] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_BillAllSt] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_BillAllSt] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_BillPrtSt] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_BillPrtSt] = true; errCheck = true; }
                        if ( errCheck )
                        {
                            continue;
                        }

                        // 請求書印刷パターン設定 取得
                        DmdPrtPtnWork dmdPrtPtn = (DmdPrtPtnWork)billRow[PMKAU08002AB.CT_BillList_DmdPrtPtn];
                        // 自由帳票印字位置設定 取得
                        FrePrtPSetWork frePrtPSet = (FrePrtPSetWork)billRow[PMKAU08002AB.CT_BillList_FrePrtPSet];
                        // プリンタ管理設定 取得
                        PrtManage prtManage = (PrtManage)billRow[PMKAU08002AB.CT_BillList_PrtManage];
                        // 請求印刷設定 取得
                        BillPrtStWork billPrtSt = (BillPrtStWork)billRow[PMKAU08002AB.CT_BillList_BillPrtSt];

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                        // 80:領収書
                        if ( dmdPrtPtn.SlipPrtKind == 80 )
                        {
                            _reportTitle = "領収書";
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD


                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
                        //_existsSalesTotalFooter = false;
                        //_existsDepositTotalFooter = false;
                        //_feedAddCount = 1;
                        //_printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
                        // 印刷対象テーブル生成（１請求書単位）
                        DataTable printData = PMKAU08002AC.CreatePrintDataTable();
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
                        //this.SearchPrintLayout( frePrtPSet );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                        if ( prevOutputFormFileName != frePrtPSet.OutputFormFileName.Trim() )
                        {
                            _existsSalesTotalFooter = false;
                            _existsDepositTotalFooter = false;
                            // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
                            _existsSalesFooter = false;
                            _existsSalesFooter2 = false;
                            // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
                            // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
                            _existsSalesFooter3 = false;
                            _existsSalesHeader2 = false;
                            // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
                            // --- ADD m.suzuki 2010/11/16 ---------->>>>>
                            _existsMesh = false;
                            // --- ADD m.suzuki 2010/11/16 ----------<<<<<
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 DEL
                            //_feedAddCount = 1;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 ADD
                            _feedAddCount = 0; // ２頁目以降の行数増分はデフォルト0
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 ADD
                            _printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                            this.SearchPrintLayout( frePrtPSet );
                        }
                        prevOutputFormFileName = frePrtPSet.OutputFormFileName.Trim();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 DEL 未使用なので削除
                        //int feedAddCount = _feedAddCount;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 DEL

                        // 2011/01/13 Add >>>
                        _depoDtlPrcPrtDiv = dmdPrtPtn.DepoDtlPrcPrtDiv;
                        _formFeedLineCount = frePrtPSet.FormFeedLineCount;
                        _detailPrtCount = 1;
                        // 2011/01/13 Add <<<

                        // 印刷レイアウトパラメータ
                        PMKAU08002AC.BillDmdPrintParameter parameter = new PMKAU08002AC.BillDmdPrintParameter();
                        # region [parameter]
                        parameter.OtherFeedAddCount = _feedAddCount;
                        parameter.ExistsSalesTotalFooter = _existsSalesTotalFooter;
                        parameter.ExistsDepositTotalFooter = _existsDepositTotalFooter;
                        parameter.FooterTitleOfSlip = _footerTitleOfSlip;
                        parameter.FooterTitleOfDaily = _footerTitleOfDaily;
                        parameter.FooterTitleOfCustomer = _footerTitleOfCustomer;
                        parameter.TaxTitle = _taxTitle;
                        // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
                        parameter.OfsThisSalesTaxIncTtl = _ofsThisSalesTaxIncTtl;
                        // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
                        // --- ADD  大矢睦美  2009/12/11 ---------->>>>>
                        parameter.CarmngCodeTitle = _carmngCodeTitle;
                        // --- ADD  大矢睦美  2009/12/11 ----------<<<<<
                        // 2010/05/25 Add >>>
                        parameter.SlipTtlTaxTitle = _slipTtlTaxTitle;
                        // 2010/05/25 Add <<<
                        // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
                        parameter.FooterTitleOfTax = _footerTitleOfTax;
                        parameter.FooterTitleOfSlipTaxInc = _footerTitleOfSlipTaxInc;
                        parameter.ExistsSalesFooter = _existsSalesFooter;
                        parameter.ExistsSalesFooter2 = _existsSalesFooter2;
                        // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
                        // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
                        parameter.ExistsSalesFooter3 = _existsSalesFooter3;
                        parameter.ExistsSalesHeader2 = _existsSalesHeader2;
                        // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
                        // 2010/11/05 Add >>>
                        parameter.DepositFooterTitleOfSlip = _depositFooterTitleOfSlip;
                        parameter.FooterTitleOfSlipTaxInc2 = _footerTitleOfSlipTaxInc2;
                        parameter.FooterTitleOfTax2 = _footerTitleOfTax2;
                        // 2010/11/05 Add <<<
                        # endregion

                        PMKAU08002AC.CopyToPrintDataTable( ref printData, this._printInfo.jyoken, billRow, parameter );

                        // 印刷データを頁単位に分ける
                        List<DataTable> printDataList = PMKAU08002AC.DevelopPrintDataList( ref printData );
                        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                        if ( printData != null )
                        {
                            printData.Dispose();
                        }
                        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

                        # region [印刷ドキュメント生成処理]

                        // --- DEL m.suzuki 2010/11/17 ---------->>>>> // 処理が冗長なので削除
                        //// レポートドキュメント初期化
                        //Document printDocument = new Document();
                        // --- DEL m.suzuki 2010/11/17 ----------<<<<<

                        using ( MemoryStream stream = new MemoryStream( frePrtPSet.PrintPosClassData ) )
                        {
                            ar.ActiveReport3 prtRpt = null;

                            // --- ADD m.suzuki 2010/11/10 ---------->>>>>
                            // --- DEL m.suzuki 2010/11/17 ---------->>>>> // ループの外に移動
                            //// 処理後に全てのレポートを解放する為のリスト
                            //if ( _prtRptList != null )
                            //{
                            //    foreach ( ar.ActiveReport3 report in _prtRptList )
                            //    {
                            //        report.Dispose();
                            //    }
                            //}
                            //_prtRptList = new List<DataDynamics.ActiveReports.ActiveReport3>();
                            // --- DEL m.suzuki 2010/11/17 ----------<<<<<

                            // 複写枚数の取得
                            int copyCount;
                            # region [copyCount←dmdPrtPtn.CopyCount]
                            // 複写枚数をセット
                            if ( dmdPrtPtn.CopyCount != 0 )
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
                            for ( int copyIndex = 0; copyIndex < copyCount; copyIndex++ )
                            {
                            // --- ADD m.suzuki 2010/11/10 ----------<<<<<

                                // レイアウト違い繰り返し
                                for ( int pageIndex = 0; pageIndex < printDataList.Count; pageIndex++ )
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                                    if ( _printCancelFlag )
                                    {
                                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD

                                    printData = printDataList[pageIndex];
                                    bool isParent = PMKAU08002AC.IsParent( printData );
                                    int consTaxLayMethod = PMKAU08002AC.GetConsTaxLayMethod( printData );

                                    prtRpt = new ar.ActiveReport3();
                                    // --- ADD m.suzuki 2010/11/10 ---------->>>>>
                                    // 後で解放できるように退避
                                    _prtRptList.Add( prtRpt );
                                    // --- ADD m.suzuki 2010/11/10 ----------<<<<<

                                    # region [レポート基本設定]
                                    stream.Position = 0;
                                    prtRpt.LoadLayout( stream );
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                                    //SFANL08235CE.AddScriptReference( ref prtRpt );	// Script用参照追加
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                                    prtRpt.Script = string.Empty; // スクリプト削除
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                                    SetMargin( prtRpt, dmdPrtPtn );
                                    SetPrinterInfo( prtRpt.Document, prtManage );
                                    SFANL08235CE.SetValidPaperKind( prtRpt );
                                    _reportCtrl.SetReportProps( ref prtRpt ); // 帳票共通設定
                                    prtRpt.DataSource = printData;
                                    prtRpt.DataMember = printData.TableName;
                                    // --- ADD m.suzuki 2010/11/16 ---------->>>>>
                                    SetReportPropsByPrinting( ref prtRpt ); // 帳票に追加で設定
                                    // --- ADD m.suzuki 2010/11/16 ----------<<<<<
                                    # endregion

                                    # region [複写対応]
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                                    //// 複写する為の制御
                                    //DataDynamics.ActiveReports.GroupHeader topHeader;
                                    //try
                                    //{
                                    //    topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                    //}
                                    //catch
                                    //{
                                    //    prtRpt.Sections.Add( DataDynamics.ActiveReports.SectionType.GroupHeader, "GroupHeader1" );
                                    //    topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                    //}
                                    //topHeader.DataField = PMKAU08002AC.ct_col_InpageCount;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL

                                    // --- DEL m.suzuki 2010/11/10 ---------->>>>>
                                    //// 合計請求書・領収書以外は複写の際に改ページする
                                    //if ( frePrtPSet.FreePrtPprSpPrpseCd != 50 && frePrtPSet.FreePrtPprSpPrpseCd != 80 )
                                    //{
                                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                                    //    // 複写する為の制御
                                    //    DataDynamics.ActiveReports.GroupHeader topHeader;
                                    //    try
                                    //    {
                                    //        topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                    //    }
                                    //    catch
                                    //    {
                                    //        prtRpt.Sections.Add( DataDynamics.ActiveReports.SectionType.GroupHeader, "GroupHeader1" );
                                    //        topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                    //    }
                                    //    topHeader.DataField = PMKAU08002AC.ct_col_InpageCount;
                                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                                    //    topHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
                                    //}
                                    // --- DEL m.suzuki 2010/11/10 ----------<<<<<

                                    // --- ADD m.suzuki 2010/11/10 ---------->>>>>
                                    // 複写時のタイトル差し替え
                                    // （※DataTableを書き換えるので、複写２枚目の時だけ実行すれば良い）
                                    if ( copyIndex == 1 )
                                    {
                                        PMKAU08002AC.SetCopyTitle( ref printData );
                                    }
                                    // --- ADD m.suzuki 2010/11/10 ----------<<<<<

                                    # endregion

                                    # region [明細デザイン対応]
                                    //ReflectReportDesign(ref prtRpt, billPrtSt, pageIndex, isParent, consTaxLayMethod);//DEL 2011/03/09
                                    ReflectReportDesign(ref prtRpt, dmdPrtPtn, billPrtSt, pageIndex, isParent, consTaxLayMethod);//ADD 2011/03/09
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
                                    //ReflectDetailDesign( ref prtRpt );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
                                    # endregion

                                    // 印刷実行
                                    prtRpt.Run();

                                    // 記号印字
                                    PrintMarks( prtRpt, dmdPrtPtn );

                                    // --- DEL m.suzuki 2010/11/17 ---------->>>>> // 処理が冗長なので削除
                                    //// 印刷用Documentにまとめる
                                    //printDocument.Pages.AddRange( prtRpt.Document.Pages );
                                    // --- DEL m.suzuki 2010/11/17 ----------<<<<<
                                    // --- ADD m.suzuki 2010/11/17 ---------->>>>>
                                    // タイプ別にドキュメントをまとめる
                                    if ( !documentsDic.ContainsKey( dmdPrtPtn.SlipPrtSetPaperId ) )
                                    {
                                        Document document = new Document();
                                        SettingDocumentInfo( ref document, prtRpt, prtManage );
                                        documentsDic.Add( dmdPrtPtn.SlipPrtSetPaperId, document );
                                    }
                                    documentsDic[dmdPrtPtn.SlipPrtSetPaperId].Pages.AddRange( prtRpt.Document.Pages );

                                    // 請求書別にドキュメントをまとめる
                                    string derivedNo = PMKAU08002AC.GetDocumentDerivedNo( billRow );
                                    if ( !orgDocuments.ContainsKey( derivedNo ) )
                                    {
                                        Document document = new Document();
                                        SettingDocumentInfo( ref document, prtRpt, prtManage );
                                        orgDocuments.Add( derivedNo, document );
                                    }
                                    orgDocuments[derivedNo].Pages.AddRange( prtRpt.Document.Pages );
                                    // --- ADD m.suzuki 2010/11/17 ----------<<<<<

                                }
                            // --- ADD m.suzuki 2010/11/10 ---------->>>>>
                            }
                            // --- ADD m.suzuki 2010/11/10 ----------<<<<<


                            //if ( prtRpt != null )
                            //{
                            //    SetPrinterInfo( printDocument, prtManage );

                            //    // 用紙の種類を指定
                            //    printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                            //    // 用紙サイズがカスタムの時は用紙サイズまで指定
                            //    if ( prtRpt.PageSettings.PaperKind == PaperKind.Custom )
                            //    {
                            //        printDocument.Printer.PaperSize = new PaperSize( "Custom", Convert.ToInt32( prtRpt.PageSettings.PaperWidth * 100 ), Convert.ToInt32( prtRpt.PageSettings.PaperHeight * 100 ) );
                            //    }
                            //    // 用紙方向（縦・横）の設定
                            //    if ( prtRpt.PageSettings.Orientation == PageOrientation.Landscape )
                            //    {
                            //        printDocument.Printer.Landscape = true;
                            //    }
                            //}

                            //// 印刷準備
                            //SetPrinterInfo( printDocument, prtManage );

                            // --- DEL m.suzuki 2010/11/17 ---------->>>>> // 冗長な処理を削除する為にループの中に移動
                            //// タイプ別にドキュメントをまとめる
                            //if ( !documentsDic.ContainsKey( dmdPrtPtn.SlipPrtSetPaperId ) )
                            //{
                            //    Document document = new Document();
                            //    SettingDocumentInfo( ref document, prtRpt, prtManage );
                            //    documentsDic.Add( dmdPrtPtn.SlipPrtSetPaperId, document );
                            //}
                            //documentsDic[dmdPrtPtn.SlipPrtSetPaperId].Pages.AddRange( printDocument.Pages );

                            //// 請求書別にドキュメントをまとめる
                            //string derivedNo = PMKAU08002AC.GetDocumentDerivedNo( billRow );
                            //if ( !orgDocuments.ContainsKey( derivedNo ) )
                            //{
                            //    Document document = new Document();
                            //    SettingDocumentInfo( ref document, prtRpt, prtManage );
                            //    orgDocuments.Add( derivedNo, document );
                            //}
                            //orgDocuments[derivedNo].Pages.AddRange( printDocument.Pages );
                            // --- DEL m.suzuki 2010/11/17 ----------<<<<<

                            stream.Close();

                            // --- DEL m.suzuki 2010/11/10 ---------->>>>>
                            //// --- ADD m.suzuki 2010/07/22 ---------->>>>>
                            //prtRpt.Dispose();
                            //// --- ADD m.suzuki 2010/07/22 ----------<<<<<
                            // --- DEL m.suzuki 2010/11/10 ----------<<<<<
                        }

                        # endregion

                        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                        if ( printDataList != null )
                        {
                            foreach ( DataTable table in printDataList )
                            {
                                table.Dispose();
                            }
                        }
                        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

                        # endregion
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 DEL
                    //}
                    //finally
                    //{
                    //    processingDialog.Dispose();
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 DEL
                    // --- UPD m.suzuki 2010/07/22 ---------->>>>>
                    //// --- UPD m.suzuki 2010/06/23 ---------->>>>>
                    ////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    ////processingDialog.Message = "現在、印刷処理中です。";
                    ////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                    //if ( _printInfo.prevkbn == 0 )
                    //{
                    //    // プレビュー無し時
                    //    processingDialog.Message = "現在、印刷処理中です。";
                    //}
                    //else
                    //{
                    //    // プレビュー有り時
                    //    processingDialog.Dispose();
                    //    disposed = true;
                    //}
                    //// --- UPD m.suzuki 2010/06/23 ----------<<<<<
                    if ( this.MessageChange != null )
                    {
                        // メッセージ変更処理
                        MessageChange( this, new EventArgs() );
                    }
                    // --- UPD m.suzuki 2010/07/22 ----------<<<<<

                    # region [印刷／ＰＤＦ出力]
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    if ( _printCancelFlag )
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                    if ( _printInfo.printmode == 1 || _printInfo.printmode == 3 )
                    {
                        //-------------------------------------------
                        // ①印刷：タイプ毎に印刷実行
                        //-------------------------------------------
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                        if ( _printCancelFlag )
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                        foreach ( string typeName in documentsDic.Keys )
                        {
                            ExecutePrint( documentsDic[typeName], typeName, null );
                        }
                    }
                    if ( _printInfo.printmode == 2 || _printInfo.printmode == 3 )
                    {
                        //-------------------------------------------
                        // ②ＰＤＦ：請求書別出力
                        //-------------------------------------------
                        _pdfPathList = new List<string>();
                        foreach ( string derivedNo in orgDocuments.Keys )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                            if ( _printCancelFlag )
                            {
                                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                            ExecutePrint( orgDocuments[derivedNo], derivedNo, _pdfPathList );
                        }
                        // --- DEL m.suzuki 2010/07/22 ---------->>>>> // タイプ別はメソッドを分ける(⇒PrintPDF)
                        //// UIでの表示用にタイプ別も出力
                        //_previewPdfPathList = new List<string>();
                        //foreach ( string typeName in documentsDic.Keys )
                        //{
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                        //    if ( _printCancelFlag )
                        //    {
                        //        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        //    }
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                        //    ExecutePrint( documentsDic[typeName], typeName, _previewPdfPathList );
                        //}
                        // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                    }
                    # endregion
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                }
                finally
                {
                    // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                    //// --- UPD m.suzuki 2010/06/23 ---------->>>>>
                    ////processingDialog.Dispose();
                    //if ( !disposed )
                    //{
                    //    processingDialog.Dispose();
                    //}
                    //// --- UPD m.suzuki 2010/06/23 ----------<<<<<
                    // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD

                string errorMessage = string.Empty;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_BillAllSt] ) errorMessage += "請求全体設定" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_BillPrtSt] ) errorMessage += "請求初期値設定" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_DmdPrtPtn] ) errorMessage += "請求書印刷パターン設定" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_FrePrtPSet] ) errorMessage += "自由帳票印字位置設定" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_PrtManage] ) errorMessage += "プリンタ設定" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_FrePBillHead] ) errorMessage += "請求書データ" + Environment.NewLine;

                if ( errorMessage != string.Empty )
                {
                    errorMessage = "設定が不正な為、印刷できないデータがありました。" + Environment.NewLine + Environment.NewLine + errorMessage;
                    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU08001P", errorMessage, 0, MessageBoxButtons.OK );
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                // タイプ別ドキュメントをセット(外部から参照できるようにする)
                _documentByTypeDic = documentsDic;
                // 印刷ドキュメント退避(あとでDisposeする為)
                _orgDocuments = orgDocuments;
                // --- ADD m.suzuki 2010/07/22 ----------<<<<<
            }
            catch( Exception ex )
            {
                TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU08001P", ex.Message, 0, MessageBoxButtons.OK );
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

# if DEBUG
            //string txt = string.Empty;
            //foreach ( string str in _pdfPathList )
            //{
            //    txt += str + Environment.NewLine;
            //}
            //MessageBox.Show( txt );

            //txt = string.Empty;
            //foreach ( string str in _previewPdfPathList )
            //{
            //    txt += str + Environment.NewLine;
            //}
            //MessageBox.Show( txt );
# endif

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
            // 返却前に帳票名を書き換える(固定)
            _printInfo.prpnm = _reportTitle;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD


            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        // --- ADD m.suzuki 2010/11/16 ---------->>>>>
        # region [レポートに対する帳票属性設定処理]
        /// <summary>
        /// 帳票属性設定処理
        /// </summary>
        /// <param name="prtRpt"></param>
        private void SetReportPropsByPrinting( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt )
        {
            if ( _existsMesh )
            {
                // 行カウントを初期化
                _lineCount = 0;

                // "明細"セクションを取得
                ar.Section detail = prtRpt.Sections["Detail1"];
                if ( detail != null && detail.Type == DataDynamics.ActiveReports.SectionType.Detail )
                {
                    // "明細"セクションの印刷前イベントを設定
                    detail.BeforePrint += new EventHandler( ReportDetail_BeforePrint );

                    // レポートの改ページイベントを設定
                    prtRpt.PageEnd += new EventHandler( Report_PageEnd );
                }
            }
        }
        /// <summary>
        /// 明細セクション印刷前処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportDetail_BeforePrint( object sender, EventArgs e )
        {
            if ( sender is ar.Section )
            {
                ar.Section detail = (sender as ar.Section);
                foreach ( ar.ARControl control in detail.Controls )
                {
                    // 74:網掛けの制御
                    if ( control != null &&
                         control is ar.Shape &&
                         control.Tag is string &&
                         (control.Tag as string).StartsWith( "74," ) )
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Report_PageEnd( object sender, EventArgs e )
        {
            // 初期化
            _lineCount = 0;
        }
        # endregion
        // --- ADD m.suzuki 2010/11/16 ----------<<<<<

        // --- DEL m.suzuki 2010/07/22 ---------->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
        ///// <summary>
        ///// 印刷キャンセルボタン
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void processingDialog_CancelButtonClick( object sender, EventArgs e )
        //{
        //    // 印刷キャンセルフラグを立てる
        //    _printCancelFlag = true;
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
        // --- DEL m.suzuki 2010/07/22 ----------<<<<<
        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// 印刷キャンセル
        /// </summary>
        public void Cancel()
        {
            // 印刷キャンセルフラグを立てる
            _printCancelFlag = true;
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// PDFキャンセルデリゲート定義
        /// </summary>
        /// <returns></returns>
        public delegate bool PDFCancelDelegate();

        /// <summary>
        /// PDF出力処理
        /// </summary>
        /// <param name="printInfo"></param>
        /// <param name="documentsDic"></param>
        /// <param name="slipPrtKind"></param>
        /// <param name="cancelDelegate"></param>
        /// <returns></returns>
        public static List<string> PrintPDF( ref SFCMN06002C printInfo, Dictionary<string, Document> documentsDic, int slipPrtKind, PDFCancelDelegate cancelDelegate )
        {
            List<string> previewPdfPathList = new List<string>();

            // 帳票タイトル
            string reportTitle;
            if ( slipPrtKind != 80 )
            {
                reportTitle = "請求書";
            }
            else
            {
                reportTitle = "領収書";
            }


            foreach ( string typeName in documentsDic.Keys )
            {
                // キャンセル(delegateにより呼び出し元で判断)
                if ( cancelDelegate != null && cancelDelegate() )
                {
                    break;
                }

                //--------------------------------------------------
                // PDF帳票名
                //--------------------------------------------------
                # region [PDF帳票名]
                // PDF帳票名
                printInfo.prpnm = string.Format( "{0}({1})", reportTitle, typeName );

                // 共通条件設定
                SFCMN00293UC commonInfo;
                SetPrintCommonInfo( out commonInfo, printInfo, reportTitle );
                printInfo.pdftemppath = commonInfo.PdfFullPath;
                if ( previewPdfPathList != null )
                {
                    previewPdfPathList.Add( commonInfo.PdfFullPath );
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

                    pdfExport1.Export( doc, printInfo.pdftemppath );
                    printInfo.status = 0;
                }
                catch ( Exception ex )
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
                if ( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    switch ( printInfo.printmode )
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
                                pdfHistoryControl.AddPrintInfo( printInfo.key, reportTitle, reportTitle, printInfo.pdftemppath );
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
        /// SetPrintCommonInfo(static用)
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <param name="printInfo"></param>
        /// <param name="reportTitle"></param>
        private static void SetPrintCommonInfo( out SFCMN00293UC commonInfo, SFCMN06002C printInfo, string reportTitle )
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

            status = cmnCommon.GetPdfSavePathName( printInfo.prpnm, ref pdfPath, ref pdfName );
            printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = printInfo.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = 0;
            // 左余白
            commonInfo.MarginsLeft = 0;
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        /// <summary>
        /// 印刷ドキュメント情報設定
        /// </summary>
        /// <param name="printDocument"></param>
        /// <param name="prtRpt"></param>
        /// <param name="prtManage"></param>
        private void SettingDocumentInfo( ref Document printDocument, DataDynamics.ActiveReports.ActiveReport3 prtRpt, PrtManage prtManage )
        {
            if ( prtRpt != null )
            {
                SetPrinterInfo( printDocument, prtManage );

                // 用紙の種類を指定
                printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                // 用紙サイズがカスタムの時は用紙サイズまで指定
                if ( prtRpt.PageSettings.PaperKind == PaperKind.Custom )
                {
                    printDocument.Printer.PaperSize = new PaperSize( "Custom", Convert.ToInt32( prtRpt.PageSettings.PaperWidth * 100 ), Convert.ToInt32( prtRpt.PageSettings.PaperHeight * 100 ) );
                }
                // 用紙方向（縦・横）の設定
                if ( prtRpt.PageSettings.Orientation == PageOrientation.Landscape )
                {
                    printDocument.Printer.Landscape = true;
                }
            }
        }

        /// <summary>
        /// 記号印刷処理
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="dmdPrtPtn"></param>
        /// <remarks>生成された印刷ドキュメントに対して記号を描き加える</remarks>
        private void PrintMarks( DataDynamics.ActiveReports.ActiveReport3 prtRpt, DmdPrtPtnWork dmdPrtPtn )
        {
            if ( _printMarkDic == null || _printMarkDic.Count == 0 ) return;

            float adjustX = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.LeftMargin);
            float adjustY = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.TopMargin);

            foreach ( Page page in prtRpt.Document.Pages )
            {
                // 折り返しマーク(>)
                foreach ( PrintMarkScheme mark in _printMarkDic[64] )
                {
                    page.TextAngle = 900; // 時計回り90.0度
                    page.ForeColor = mark.ForeColor;
                    page.Font = new System.Drawing.Font( "ＭＳゴシック", mark.Size );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                    page.TextAlignment = DataDynamics.ActiveReports.TextAlignment.Left;
                    page.VerticalTextAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Top;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD
                    page.DrawText( "▲", new System.Drawing.RectangleF( mark.Position.X + adjustX, mark.Position.Y + adjustY, 0.5f, 0.5f ) );
                }

                // 折り返しマーク(<)
                foreach ( PrintMarkScheme mark in _printMarkDic[65] )
                {
                    page.TextAngle = -900; // 反時計回り90.0度
                    page.ForeColor = mark.ForeColor;
                    page.Font = new System.Drawing.Font( "ＭＳゴシック", mark.Size );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                    page.TextAlignment = DataDynamics.ActiveReports.TextAlignment.Left;
                    page.VerticalTextAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Top;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD
                    page.DrawText( "▲", new System.Drawing.RectangleF( mark.Position.X + adjustX, mark.Position.Y + adjustY, 0.5f, 0.5f ) );
                }
            }
        }
        /// <summary>
        /// レイアウト情報取得（１ページ目のヘッダが何明細分に相当するかなど）
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private void SearchPrintLayout( FrePrtPSetWork frePrtPSet )
        {
            // 初期値設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 DEL
            //_feedAddCount = 1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 ADD
            _feedAddCount = 0; // ２頁目以降の行数増分はデフォルト0
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 ADD
            _footerTitleOfSlip = "*伝票計*";
            _footerTitleOfDaily = "*日計*";
            _footerTitleOfCustomer = "*得意先計*";
            _taxTitle = "消費税";
            // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
            _ofsThisSalesTaxIncTtl = "*売上合計金額(税込)*";
            // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
            // --- ADD  大矢睦美  2009/12/11 ---------->>>>>
            _carmngCodeTitle = "プレート番号";
            // --- ADD  大矢睦美  2009/12/11 ----------<<<<<
            // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
            _footerTitleOfTax = "*消費税*";
            _footerTitleOfSlipTaxInc = "*課税合計*";
            // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
            // 2010/05/25 Add >>>
            _slipTtlTaxTitle = "消費税";
            // 2010/11/05 Add >>>
            _depositFooterTitleOfSlip = "*入金計*";
            _footerTitleOfSlipTaxInc2 = "課税合計";
            _footerTitleOfTax2 = "消費税";
            // 2010/11/05 Add <<<
            // --- UPD  大矢睦美  2010/07/09 ---------->>>>>
            //Dictionary<string, string> reportItemDic = PMKAU08002AC.ReportItemDic;
            //if (reportItemDic == null)
            //{
            //    reportItemDic = new Dictionary<string, string>();
            //}
            Dictionary<string, string> reportItemDic = new Dictionary<string, string>();
            // --- UPD  大矢睦美  2010/07/09 ----------<<<<<
            // 2010/05/25 Add <<<

            // レイアウト情報の取り込み
            using ( MemoryStream stream = new MemoryStream( frePrtPSet.PrintPosClassData ) )
            {
                // レイアウト情報取得
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout( stream );


                foreach ( ar.Section section in prtRpt.Sections )
                {
                    foreach ( ar.ARControl control in section.Controls )
                    {
                        // 2010/05/25 Add >>>
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
                        // 2010/05/25 Add <<<

                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring( 0, 3 );

                        switch ( tagText )
                        {
                            // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
                            // 53:売上フッタ
                            case "53,":
                                _existsSalesFooter = true;
                                break;
                            // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
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
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 ADD
                                _feedAddCount += 1; // 既に出荷済みの旧ﾚｲｱｳﾄの互換性を保つため,＋１する
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 ADD
                                _feedAddCount += GetFeedAddCount( control );
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
                                if ( (control as ar.Label).Visible )
                                {
                                    AddToMarkDic( 64, (control as ar.Label) );
                                }
                                (control as ar.Label).Visible = false;
                                break;
                            // 65:折り返しマーク(<)
                            case "65,":
                                if ( (control as ar.Label).Visible )
                                {
                                    AddToMarkDic( 65, (control as ar.Label) );
                                }
                                (control as ar.Label).Visible = false;
                                break;
                            // --- ADD  大矢睦美  2009/12/11 ---------->>>>>
                            // 66:タイトル設定（プレート番号）
                            case "66,":
                                _carmngCodeTitle = (control as ar.Label).Text;
                                break;
                            // --- ADD  大矢睦美  2009/12/11 ----------<<<<<
                            // 2010/05/25 Add >>>
                            // 67:伝票合計消費税リテラル
                            case "67,":
                                _slipTtlTaxTitle = (control as ar.Label).Text;
                                break;
                            // 2010/05/25 Add <<<
                            // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
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
                            // --- ADD  大矢睦美  2010/06/16 ----------<<<<<                        
                            // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
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
                            // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
                            // --- ADD m.suzuki 2010/11/16 ---------->>>>>
                            //74:明細網掛け
                            case "74,":
                                _existsMesh = true;
                                break;
                            // --- ADD m.suzuki 2010/11/16 ----------<<<<<
                        }
                    }
                }

                // 2010/05/25 Add >>>
                PMKAU08002AC.ReportItemDic = reportItemDic;
                // 2010/05/25 Add <<<

                // ストリーム閉じる
                stream.Close();
            }
        }
        /// <summary>
        /// 記号ディクショナリに追加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="arLabel"></param>
        private void AddToMarkDic( int key, ar.Label arLabel )
        {
            string text = arLabel.Text;

            if ( text.Contains( "," ) )
            {
                string[] subText = text.Split( ',' );
                if ( subText.Length >= 2 )
                {
                    float posX = ToSingle( subText[0] );
                    float posY = ToSingle( subText[1] );

                    // ディクショナリが無ければ作成
                    if ( _printMarkDic == null )
                    {
                        _printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                    }
                    // ディクショナリ内にリストが無ければ生成
                    if ( !_printMarkDic.ContainsKey( key ) )
                    {
                        _printMarkDic.Add( key, new List<PrintMarkScheme>() );
                    }

                    // ディクショナリ内リストに追加
                    _printMarkDic[key].Add( new PrintMarkScheme( new PointF( posX, posY ), arLabel.ForeColor, arLabel.Font.Size ) );
                }
            }
        }
        /// <summary>
        /// 文字列→数値(float)変換
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static private float ToSingle( string text )
        {
            try
            {
                return float.Parse( text );
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// コントロールからのFeedAddCount取得（テキストより）
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private int GetFeedAddCount(ar.ARControl control)
        {
            if ( control is ar.Label )
            {
                return GetInt( (control as ar.Label).Text );
            }
            return 0;
        }
        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int GetInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 印刷or印刷プレビュー実行
        /// </summary>
        /// <param name="printDocument"></param>
        /// <param name="derivedNo"></param>
        /// <param name="pdfList"></param>
        private void ExecutePrint( Document printDocument, string derivedNo, List<string> pdfList )
        {
            # region // DEL
            ////if ( isDirectPrint )
            ////{
            ////    // 印刷実行
            ////    bool printStatus = printDocument.Print( false, false, false );

            ////    if ( printStatus )
            ////    {
            ////        this._printInfo.status = 0;
            ////    }
            ////    else
            ////    {
            ////        this._printInfo.status = 9;
            ////    }
            ////}
            ////else
            ////{
            ////    //Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

            ////    //// 共通条件設定
            ////    //SFCMN00293UC commonInfo;
            ////    //SetPrintCommonInfo( out commonInfo, dmdPrtPtn, frePrtPSet, prtManage );
            ////    //viewForm.CommonInfo = commonInfo;
            ////    //// プレビュー実行
            ////    //status = viewForm.Run( prtRpt );
            ////    //// 戻り値設定
            ////    //this._printInfo.status = status;

            ////    // 印刷プレビュー表示
            ////    SFMIT01290UB para = new SFMIT01290UB();
            ////    para.PrintDocument = printDocument;
            ////    para.PreviewDocument = printDocument;
            ////    para.ExpansionRate = 50;

            ////    SFMIT01290UA form = new SFMIT01290UA();
            ////    this._printInfo.status = form.PrintPreview( para );
            ////}
            # endregion

            // 名称設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 DEL
            //_printInfo.prpnm = string.Format( "請求書({0})", derivedNo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
            _printInfo.prpnm = string.Format( "{0}({1})", _reportTitle, derivedNo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

            // 共通条件設定
            SFCMN00293UC commonInfo;
            SetPrintCommonInfo( out commonInfo );
            _printInfo.pdftemppath = commonInfo.PdfFullPath;
            if ( pdfList != null )
            {
                pdfList.Add( commonInfo.PdfFullPath );
            }

            // プレビュー有無				
            int mode = this._printInfo.prevkbn;

            // 出力モードがＰＤＦの場合、無条件でプレビュー無
            if ( this._printInfo.printmode == 2 )
            {
                mode = 0;
            }

            switch ( mode )
            {
                case 0:
                    {
                        // プレビュー無
                        # region [プレビュー無]
                        // ①直接印刷
                        if ( this._printInfo.printmode == 1 || this._printInfo.printmode == 3 )
                        {
                            bool printStatus = printDocument.Print( false, false, false );

                            if ( printStatus )
                            {
                                this._printInfo.status = 0;
                            }
                            else
                            {
                                this._printInfo.status = 9;
                            }
                        }
                        // ②PDF出力
                        if ( this._printInfo.printmode == 2 || this._printInfo.printmode == 3 )
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

                                pdfExport1.Export( printDocument, _printInfo.pdftemppath );
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
                        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                        //this._printInfo.status = form.PrintPreview( para );
                        this._printInfo.status = form.PrintPreviewDefaultSetting( para );
                        // --- ADD m.suzuki 2010/06/23 ----------<<<<<
                        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                        form.Dispose();
                        // --- ADD m.suzuki 2010/07/22 ----------<<<<<
                        # endregion

                        break;
                    }
            }

            // ＰＤＦ出力の場合
            # region [ＰＤＦ出力の場合の処理]
            if ( this._printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                switch ( this._printInfo.printmode )
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
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
                            //pdfHistoryControl.AddPrintInfo( this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                            //    this._printInfo.pdftemppath );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                            pdfHistoryControl.AddPrintInfo( this._printInfo.key, _reportTitle, _reportTitle, this._printInfo.pdftemppath );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
                            // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                            pdfHistoryControl.Dispose();
                            // --- ADD m.suzuki 2010/07/22 ----------<<<<<
                        }
                        break;
                }
            }
            # endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="dmdPrtPtn"></param>
        /// <param name="billPrtSt"></param>
        /// <remarks>ReflectDetailDesignの内容はこちらに移行</remarks>
        /// <br>Update Note: 2011/03/09 yangmj readmine #19751対応</br>
        //private void ReflectReportDesign( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, BillPrtStWork billPrtSt, int layoutChangeIndex, bool isParent, int consTaxLayMethod )//DEL 2011/03/09
        private void ReflectReportDesign(ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, DmdPrtPtnWork dmdPrtPtn, BillPrtStWork billPrtSt, int layoutChangeIndex, bool isParent, int consTaxLayMethod)//ADD 2011/03/09
        {
            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                //// 明細セクション取得
                //ar.Section detail = prtRpt.Sections["Detail1"];

                // 明細デザイン用ラベル
                ar.Label designSalesHeader = null;
                ar.Label designSalesDetail = null;
                ar.Label designSalesFooter = null;
                ar.Label designSalesTotal = null;
                ar.Label designDepositDetail = null;
                ar.Label designDepositTotal = null;
                // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
                ar.Label designSalesFooter2 = null;
                // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
                // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
                ar.Label designSalesFooter3 = null;
                ar.Label designSalesHeader2 = null;
                // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD


                // 全セクション
                foreach ( ar.Section section in prtRpt.Sections )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                    if ( section is ar.GroupHeader )
                    {
                        // グループ保持ＯＮ
                        (section as ar.GroupHeader).GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
                        // 繰り返しＯＮ
                        (section as ar.GroupHeader).RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
                        //(section as ar.GroupHeader).IsRepeating = true;
                        // 改ページフィールド
                        (section as ar.GroupHeader).DataField = PMKAU08002AC.ct_col_PageCount;
                    }
                    //else if ( sectino is ar.GroupFooter )
                    //{
                    //    ( sectino as ar.GroupFooter ).
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

                    // セクションのコントロールを調査
                    foreach ( ar.ARControl control in section.Controls )
                    {
                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring( 0, 3 );

                        switch ( tagText )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
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
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
                            case "55,":
                                {
                                    //-----ADD 2011/03/09----->>>>>
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
                                    //// 0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない
                                    //switch (billPrtSt.BillCoNmPrintOutCd)
                                    //{
                                    //    case 0:
                                    //    case 1:
                                    //        break;
                                    //    case 2:
                                    //    case 3:
                                    //    default:
                                    //        {
                                    //            control.Visible = false;
                                    //        }
                                    //        break;
                                    //}
                                    //-----ADD 2011/03/09-----<<<<<
                                }
                                break;
                            case "58,":
                                // レイアウト制御（１頁目）
                                // このコントロールの貼ってあるセクションを非印字にする
                                if ( layoutChangeIndex != 0 )
                                {
                                    section.Visible = false;
                                }
                                break;
                            case "59,":
                                // レイアウト制御（２頁目以降）
                                // このコントロールの貼ってあるセクションを非印字にする
                                if ( layoutChangeIndex == 0 )
                                {
                                    section.Visible = false;
                                }
                                break;
                            case "60,":
                                // 鑑消費税タイトル
                                if ( !isParent || consTaxLayMethod == 9 )
                                {
                                    control.Visible = false;
                                }
                                else
                                {
                                    control.DataField = PMKAU08002AC.ct_col_TaxTitle;
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
                            // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
                            case "68,":
                                designSalesFooter2 = (ar.Label)control;
                                break;
                            // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
                            // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
                            case "71,":
                                // 相殺後売上合計金額(税込)タイトル
                                if (!isParent || consTaxLayMethod == 9)
                                {
                                    control.Visible = false;
                                }
                                else
                                {
                                    control.DataField = PMKAU08002AC.ct_col_OfsThisSalesTaxIncTtl;
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
                            // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 ADD
                        // 各種ヘッダ・フッタのみ
                        if ( section.Type != DataDynamics.ActiveReports.SectionType.Detail )
                        {
                            string[] tagParams;
                            //--------------------------------------------------
                            // 印刷ページ区分（全ページ／１ページ目のみ）の対応
                            //--------------------------------------------------
                            try
                            {
                                tagParams = ((string)control.Tag).Split( ',' );
                            }
                            catch
                            {
                                continue;
                            }
                            if ( tagParams.Length > 1 )
                            {
                                string printPageCtrlDivCd = tagParams[1].Trim();
                                if ( printPageCtrlDivCd == "1" )
                                {
                                    if ( layoutChangeIndex != 0 )
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
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 ADD
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                    # region [項目グループ化]
                    if ( section is ar.Detail )
                    {
                        ar.Detail detail = (section as ar.Detail);

                        // 対象データフィールドリスト取得
                        List<string> salesHeaderList = PMKAU08002AC.GetDesignSalesHeaderList();
                        List<string> salesFooterList = PMKAU08002AC.GetDesignSalesFooterList();
                        List<string> salesDetailList = PMKAU08002AC.GetDesignSalesDetailList();
                        List<string> salesTotalList = PMKAU08002AC.GetDesignSalesTotalList();
                        List<string> depositDetailList = PMKAU08002AC.GetDesignDepositDetailList();
                        List<string> depositTotalList = PMKAU08002AC.GetDesignDepositTotalList();
                        // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
                        List<string> salesFooter2List = PMKAU08002AC.GetDesignSalesFooter2List();
                        // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
                        // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
                        List<string> salesFooter3List = PMKAU08002AC.GetDesignSalesFooter3List();
                        List<string> salesHeader2List = PMKAU08002AC.GetDesignSalesHeader2List();
                        // --- ADD  大矢睦美  2010/07/09 ----------<<<<<

                        if ( designSalesHeader == null )
                        {
                            // 売上ヘッダデザインガイドが無い場合は明細リストに移してヘッダリストをクリア
                            salesDetailList.AddRange( salesHeaderList );
                            salesHeaderList.Clear();
                        }
                        if ( designSalesFooter == null )
                        {
                            // 売上フッタデザインガイドが無い場合は明細リストに移してフッタリストをクリア
                            salesDetailList.AddRange( salesFooterList );
                            salesFooterList.Clear();
                        }
                        if ( designSalesTotal == null )
                        {
                            // 売上集計デザインガイドが無い場合は明細リストに移して売上集計リストをクリア
                            salesDetailList.AddRange( salesTotalList );
                            salesTotalList.Clear();
                        }
                        if ( designSalesDetail == null )
                        {
                            // 売上明細デザインガイドが無い場合はリストをクリア
                            salesDetailList.Clear();
                        }
                        if ( designDepositTotal == null )
                        {
                            // 入金集計デザインガイドが無い場合は明細リストに移して入金集計リストをクリア
                            depositDetailList.AddRange( depositTotalList );
                            depositTotalList.Clear();
                        }
                        if ( designDepositDetail == null )
                        {
                            // 入金明細デザインガイドが無い場合はリストをクリア
                            depositDetailList.Clear();
                        }
                        // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
                        if (designSalesFooter2 == null)
                        {
                            //売上フッタ２デザインガイドが無い場合は明細リストに移してフッタ２リストをクリア
                            salesDetailList.AddRange(salesFooter2List);
                            salesFooter2List.Clear();
                        }
                        // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
                        // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
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
                        // --- ADD  大矢睦美  2010/07/09 ----------<<<<<

                        // 全てのコントロールを調査
                        foreach ( ar.ARControl control in detail.Controls )
                        {
                            if ( control is ar.TextBox )
                            {
                                string dataField = control.DataField.ToUpper();

                                if ( salesHeaderList.Contains( dataField ) )
                                {
                                    // 売上ヘッダ項目の場合
                                    control.Top -= designSalesHeader.Top;
                                }
                                else if ( salesFooterList.Contains( dataField ) )
                                {
                                    // 売上フッタ項目の場合
                                    control.Top -= designSalesFooter.Top;
                                }
                                else if ( salesTotalList.Contains( dataField ) )
                                {
                                    // 売上集計項目の場合
                                    control.Top -= designSalesTotal.Top;
                                }
                                else if ( salesDetailList.Contains( dataField ) )
                                {
                                    // 売上明細項目の場合
                                    control.Top -= designSalesDetail.Top;
                                }
                                else if ( depositTotalList.Contains( dataField ) )
                                {
                                    // 入金集計項目の場合
                                    control.Top -= designDepositTotal.Top;
                                }
                                else if ( depositDetailList.Contains( dataField ) )
                                {
                                    // 入金明細項目の場合
                                    control.Top -= designDepositDetail.Top;
                                }
                                // --- ADD  大矢睦美  2010/06/16 ---------->>>>>
                                else if ( salesFooter2List.Contains( dataField ) )
                                {
                                    //売上フッタ２の場合
                                    control.Top -= designSalesFooter2.Top;
                                }
                                // --- ADD  大矢睦美  2010/06/16 ----------<<<<<
                                // --- ADD  大矢睦美  2010/07/09 ---------->>>>>
                                else if ( salesFooter3List.Contains( dataField ) )
                                {
                                    //売上フッタ３の場合
                                    control.Top -= designSalesFooter3.Top; 
                                }
                                else if (salesHeader2List.Contains(dataField))
                                {
                                    //売上ヘッダ２の場合
                                    control.Top -= designSalesHeader2.Top;
                                }
                                // --- ADD  大矢睦美  2010/07/09 ----------<<<<<
                            }
                        }
                    }
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
                }
            }
            catch
            {
            }
        }

        // 2011/01/13 Add >>>
        /// <summary>
        /// DetailLineを描画するかどうかを判断します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        void _reportCtrl_BeforePrintEditLine(object sender, PMCMN02000CA.BeforePrintEditLineEventArgs e)
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
        /// <param name="arControlList"></param>
        /// <returns>取得した値</returns>
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
        // 2011/01/13 Add <<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
        ///// <summary>
        ///// 明細デザイン適用
        ///// </summary>
        ///// <param name="prtRpt"></param>
        ///// <remarks>リストに属する項目の縦位置を調整する</remarks>
        //private void ReflectDetailDesign( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt )
        //{
        //    try
        //    {
        //        // 明細セクション取得
        //        ar.Section detail = prtRpt.Sections["Detail1"];

        //        // 明細デザイン用ラベル
        //        ar.Label designSalesHeader = null;
        //        ar.Label designSalesDetail = null;
        //        ar.Label designSalesFooter = null;
        //        ar.Label designSalesTotal = null;
        //        ar.Label designDepositDetail = null;
        //        ar.Label designDepositTotal = null;

        //        // 明細セクションのコントロールを調査
        //        foreach ( ar.ARControl control in detail.Controls )
        //        {
        //            string tagText = (string)control.Tag;
        //            tagText = tagText.Substring( 0, 3 );

        //            switch ( tagText )
        //            {
        //                case "51,":
        //                    designSalesHeader = (ar.Label)control;
        //                    break;
        //                case "52,":
        //                    designSalesDetail = (ar.Label)control;
        //                    break;
        //                case "53,":
        //                    designSalesFooter = (ar.Label)control;
        //                    break;
        //                case "54,":
        //                    designDepositDetail = (ar.Label)control;
        //                    break;
        //                case "56,":
        //                    designSalesTotal = (ar.Label)control;
        //                    break;
        //                case "57,":
        //                    designDepositTotal = (ar.Label)control;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        // 対象データフィールドリスト取得
        //        List<string> salesHeaderList = PMKAU08002AC.GetDesignSalesHeaderList();
        //        List<string> salesFooterList = PMKAU08002AC.GetDesignSalesFooterList();
        //        List<string> salesDetailList = PMKAU08002AC.GetDesignSalesDetailList();
        //        List<string> salesTotalList = PMKAU08002AC.GetDesignSalesTotalList();
        //        List<string> depositDetailList = PMKAU08002AC.GetDesignDepositDetailList();
        //        List<string> depositTotalList = PMKAU08002AC.GetDesignDepositTotalList();

        //        if ( designSalesHeader == null )
        //        {
        //            // 売上ヘッダデザインガイドが無い場合は明細リストに移してヘッダリストをクリア
        //            salesDetailList.AddRange( salesHeaderList );
        //            salesHeaderList.Clear();
        //        }
        //        if ( designSalesFooter == null )
        //        {
        //            // 売上フッタデザインガイドが無い場合は明細リストに移してフッタリストをクリア
        //            salesDetailList.AddRange( salesFooterList );
        //            salesFooterList.Clear();
        //        }
        //        if ( designSalesTotal == null )
        //        {
        //            // 売上集計デザインガイドが無い場合は明細リストに移して売上集計リストをクリア
        //            salesDetailList.AddRange( salesTotalList );
        //            salesTotalList.Clear();
        //        }
        //        if ( designSalesDetail == null )
        //        {
        //            // 売上明細デザインガイドが無い場合はリストをクリア
        //            salesDetailList.Clear();
        //        }
        //        if ( designDepositTotal == null )
        //        {
        //            // 入金集計デザインガイドが無い場合は明細リストに移して入金集計リストをクリア
        //            depositDetailList.AddRange( depositTotalList );
        //            depositTotalList.Clear();
        //        }
        //        if ( designDepositDetail == null )
        //        {
        //            // 入金明細デザインガイドが無い場合はリストをクリア
        //            depositDetailList.Clear();
        //        }

        //        // 全てのコントロールを調査
        //        foreach ( ar.ARControl control in detail.Controls )
        //        {
        //            if ( control is ar.TextBox )
        //            {
        //                string dataField = control.DataField.ToUpper();

        //                if ( salesHeaderList.Contains( dataField ) )
        //                {
        //                    // 売上ヘッダ項目の場合
        //                    control.Top -= designSalesHeader.Top;
        //                }
        //                else if ( salesFooterList.Contains( dataField ) )
        //                {
        //                    // 売上フッタ項目の場合
        //                    control.Top -= designSalesFooter.Top;
        //                }
        //                else if ( salesTotalList.Contains( dataField ) )
        //                {
        //                    // 売上集計項目の場合
        //                    control.Top -= designSalesTotal.Top;
        //                }
        //                else if ( salesDetailList.Contains( dataField ) )
        //                {
        //                    // 売上明細項目の場合
        //                    control.Top -= designSalesDetail.Top;
        //                }
        //                else if ( depositTotalList.Contains( dataField ) )
        //                {
        //                    // 入金集計項目の場合
        //                    control.Top -= designDepositTotal.Top;
        //                }
        //                else if ( depositDetailList.Contains( dataField ) )
        //                {
        //                    // 入金明細項目の場合
        //                    control.Top -= designDepositDetail.Top;
        //                }
        //            }
        //        }
        //        //detail.Height = designSalesDetail.Height;
        //    }
        //    catch
        //    {
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
        /// <summary>
        /// テーブルセルのNULL判定処理
        /// </summary>
        /// <param name="cellObject"></param>
        /// <returns></returns>
        private bool IsNull( object cellObject )
        {
            return (cellObject == null || cellObject == DBNull.Value);
        }
        /// <summary>
        /// 余白設定処理
        /// </summary>
        /// <param name="rpt">アクティブレポートオブジェクト</param>
        /// <param name="dmdPrtPtn">請求書印刷パターン</param>
        /// <remarks>
        /// <br>Note		: 余白設定をします。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.08.09</br>
        /// </remarks>
        private void SetMargin( ar.ActiveReport3 rpt, DmdPrtPtnWork dmdPrtPtn )
        {
            // 上の余白を設定
            rpt.PageSettings.Margins.Top
                = ar.ActiveReport3.CmToInch( (float)dmdPrtPtn.TopMargin );
            // 下の余白を設定
            rpt.PageSettings.Margins.Bottom
                = ar.ActiveReport3.CmToInch( (float)dmdPrtPtn.BottomMargin );
            // 左の余白を設定
            rpt.PageSettings.Margins.Left
                = ar.ActiveReport3.CmToInch( (float)dmdPrtPtn.LeftMargin );
            // 右の余白を設定
            rpt.PageSettings.Margins.Right
                = ar.ActiveReport3.CmToInch( (float)dmdPrtPtn.RightMargin );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 ADD
            // ReportのPrintWidthがinch単位で中途半端な場合、不要な空ページが印刷されてしまうので防止する。
            // (小数第３位以降は切り捨てる)
            int width = (int)((float)rpt.PrintWidth * (float)100.0f);
            rpt.PrintWidth = (float)width / (float)100.0f;
            // 余白分を除く
            rpt.PrintWidth -= (rpt.PageSettings.Margins.Left + rpt.PageSettings.Margins.Right);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 ADD
        }

        /// <summary>
        /// プリンター情報セット処理
        /// </summary>
        /// <param name="document">レポートDocument</param>
        /// <param name="prtManage"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: プリンター情報を設定します。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.08.09</br>
        /// </remarks>
        private void SetPrinterInfo( Document document, PrtManage prtManage )
        {
            // 使用プリンターの設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 DEL
            //foreach ( string wkStr in PrinterSettings.InstalledPrinters )
            //{
            //    if ( wkStr.Equals( prtManage.PrinterName ) )
            //    {
            //        document.Printer.PrinterSettings.PrinterName = prtManage.PrinterName;
            //        break;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 ADD
            document.Printer.PrinterSettings.PrinterName = prtManage.PrinterName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 ADD

            // 使用プリンタの有効有無チェック（有効では無い場合は仮想プリンタを使用）
            if ( !document.Printer.PrinterSettings.IsValid )
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void CreateReport ( out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid )
        {
            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof( DataDynamics.ActiveReports.ActiveReport3 ) );
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private object LoadAssemblyReport ( string asmname, string classname, Type type )
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load( asmname );
                Type objType = asm.GetType( classname );
                if ( objType != null )
                {
                    if ( ( objType == type ) || ( objType.IsSubclassOf( type ) == true ) || ( objType.GetInterface( type.Name ).Name == type.Name ) )
                    {
                        obj = Activator.CreateInstance( objType );
                    }
                }
            }
            catch ( System.IO.FileNotFoundException )
            {
                throw new StockMoveException( asmname + "が存在しません。", -1 );
            }
            catch ( System.Exception er )
            {
                throw new StockMoveException( er.Message, -1 );
            }
            return obj;
        }
        #endregion

        #region ◎ 印刷画面共通情報設定

        /// <summary>
        /// 印刷画面共通情報設定
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷画面共通条件の設定を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void SetPrintCommonInfo ( out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo )
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
            //// 帳票名
            //commonInfo.PrintName = "請求書";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
            // 帳票名
            commonInfo.PrintName = _reportTitle;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
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

            status = cmnCommon.GetPdfSavePathName( this._printInfo.prpnm, ref pdfPath, ref pdfName );
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = 0;//this._printInfo.py;
            // 左余白
            commonInfo.MarginsLeft = 0;//this._printInfo.px;
        }

        #endregion

        #region ◎ 各種プロパティ設定

        /// <summary>
        /// 各種プロパティ設定
        /// </summary>
        /// <param name="rpt">インスタンス化された帳票フォームクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 各種プロパティを設定します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private int SettingProperty ( ref DataDynamics.ActiveReports.ActiveReport3 rpt )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            //// ActiveReportインターフェースにキャスト
            //IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            //// 印刷条件取得
            //FrePBillCndtn extraInfo = (FrePBillCndtn)this._printInfo.jyoken;

            //// ソート順プロパティ設定
            //instance.PageHeaderSortOderTitle = "";

            //// 帳票出力設定情報取得 
            //PrtOutSet prtOutSet;
            //string message;
            //int st = FrePBillAcs.ReadPrtOutSet( out prtOutSet, out message );
            //if ( st != 0 )
            //{
            //    throw new StockMoveException( message, status );
            //}



            //// 抽出条件ヘッダ出力区分
            //instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            //// 抽出条件編集処理
            //StringCollection extraInfomations;
            //this.MakeExtarCondition( out extraInfomations );

            //instance.ExtraConditions = extraInfomations;

            //// フッタ出力区分
            //instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            //// フッタ出力メッセージ
            //StringCollection footers = new StringCollection();
            //footers.Add( prtOutSet.PrintFooter1 );
            //footers.Add( prtOutSet.PrintFooter2 );

            //instance.PageFooters = footers;

            //// 印刷情報オブジェクト
            //instance.PrintInfo = this._printInfo;

            //// ヘッダーサブタイトル
            //object[] titleObj = new object[] { "自由帳票（請求書）" };
            //instance.PageHeaderSubtitle = string.Format( "{0}", titleObj );

            //// その他データ
            //// Todo:移動元とか渡す？抽出条件渡るからいいか？
            //instance.OtherDataList = null;

            //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion

        #region ◎ 抽出条件出力情報作成
        ///// <summary>
        ///// 抽出条件出力情報作成
        ///// </summary>
        ///// <param name="extraConditions">作成後抽出条件コレクション</param>
        ///// <remarks>
        ///// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        ///// <br>Programmer : 22018 鈴木 正臣</br>
        ///// <br>Date       : 2007.09.19</br>
        ///// </remarks>
        //private void MakeExtarCondition ( out StringCollection extraConditions )
        //{
            //const string dateFormat = "yyyy年MM月dd日";

            //extraConditions = new StringCollection();
            //StringCollection addConditions = new StringCollection();
            //string stDate = string.Empty;
            //string edDate = string.Empty;


            ////-------------------------------------------------------------------------------------------------------------------
            //// 入力日
            //// 開始･終了のいずれかが入力されていれば印字
            //if ( ( this._estimateListCndtn.St_SearchSlipDate != DateTime.MinValue ) || ( this._estimateListCndtn.Ed_SearchSlipDate != DateTime.MinValue ) )
            //{
            //    // 開始
            //    if ( this._estimateListCndtn.St_SearchSlipDate != DateTime.MinValue )
            //    {
            //        stDate = this._estimateListCndtn.St_SearchSlipDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        stDate = ct_Extr_Top;
            //    }
            //    // 終了
            //    if ( this._estimateListCndtn.Ed_SearchSlipDate != DateTime.MinValue )
            //    {
            //        edDate = this._estimateListCndtn.Ed_SearchSlipDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        edDate = ct_Extr_End;
            //    }
            //    this.EditCondition( ref addConditions, string.Format( "入力日" + ct_RangeConst, stDate, edDate ) );
            //}
            ////-------------------------------------------------------------------------------------------------------------------
            //// 見積日

            //// 開始･終了のいずれかが入力されていれば印字
            //if ( (this._estimateListCndtn.St_SalesDate != DateTime.MinValue) || (this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue) )
            //{
            //    // 開始
            //    if ( this._estimateListCndtn.St_SalesDate != DateTime.MinValue )
            //    {
            //        stDate = this._estimateListCndtn.St_SalesDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        stDate = ct_Extr_Top;
            //    }
            //    // 終了
            //    if ( this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue )
            //    {
            //        edDate = this._estimateListCndtn.Ed_SalesDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        edDate = ct_Extr_End;
            //    }
            //    this.EditCondition( ref addConditions, string.Format( "見積日" + ct_RangeConst, stDate, edDate ) );
            //}

            ////----------------------------------------------------------------------------------------------------------------
            //// 得意先
            //// 開始･終了のいずれかが入力されていれば印字
            //if ( this._estimateListCndtn.St_CustomerCode != 0 || this._estimateListCndtn.Ed_CustomerCode != 999999999 )
            //{
            //    string stCode = this._estimateListCndtn.St_CustomerCode.ToString();
            //    string edCode = this._estimateListCndtn.Ed_CustomerCode.ToString();
            //    if ( stCode == string.Empty ) stCode = ct_Extr_Top;
            //    if ( edCode == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "得意先" + ct_RangeConst, stCode, edCode ) );
            //}

            ////-------------------------------------------------------------------------------------------------------------------
            //// 担当者 
            //// 開始･終了のいずれかが入力されていれば印字
            //if ( this._estimateListCndtn.St_SalesEmployeeCd != string.Empty || this._estimateListCndtn.Ed_SalesEmployeeCd != string.Empty )
            //{
            //    string stCode = this._estimateListCndtn.St_SalesEmployeeCd;
            //    string edCode = this._estimateListCndtn.Ed_SalesEmployeeCd;
            //    if ( stCode == string.Empty ) stCode = ct_Extr_Top;
            //    if ( edCode == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "担当者" + ct_RangeConst, stCode, edCode ) );
            //}

            //// 追加
            //foreach ( string exCondStr in addConditions )
            //{
            //    extraConditions.Add( exCondStr );
            //}
        //}
        #endregion

        #region ◎ 抽出範囲文字列作成
        /// <summary>
        /// 抽出範囲文字列作成
        /// </summary>
        /// <returns>作成文字列</returns>
        /// <remarks>
        /// <br>Note       : 抽出範囲文字列を作成します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private string GetConditionRange ( string title, string startString, string endString )
        {
            string result = "";
            if ( ( startString != "" ) || ( endString != "" ) )
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if ( startString != "" ) start = startString;
                if ( endString != "" ) end = endString;
                result = String.Format( title + ct_RangeConst, start, end );
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void EditCondition ( ref StringCollection editArea, string target )
        {
            bool isEdit = false;

            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS( target );

            for ( int i = 0; i < editArea.Count; i++ )
            {
                int areaByte = 0;

                // 格納エリアのバイト数算出
                if ( editArea[i] != null )
                {
                    areaByte = TStrConv.SizeCountSJIS( editArea[i] );
                }

                if ( ( areaByte + targetByte + 2 ) <= 190 )
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if ( editArea[i] != null ) editArea[i] += ct_Space;

                    editArea[i] += target;
                    break;
                }
            }
            // 新規編集エリア作成
            if ( !isEdit )
            {
                editArea.Add( target );
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private DialogResult MsgDispProc ( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            return TMsgDisp.Show( iLevel, "PMKAU08001P", iMsg, iSt, iButton, iDefButton );
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
            public PrintMarkScheme( PointF position, Color foreColor, float size )
            {
                _position = position;
                _foreColor = foreColor;
                _size = size;
            }
        }
        # endregion
        #endregion

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// 破棄処理
        /// </summary>
        public void Dispose()
        {
            // タイプ別ドキュメント解放
            if ( _documentByTypeDic != null )
            {
                foreach ( Document doc in _documentByTypeDic.Values )
                {
                    doc.Dispose();
                }
                _documentByTypeDic = null;
            }
            // 印刷ドキュメント解放
            if ( _orgDocuments != null )
            {
                foreach ( Document doc in _orgDocuments.Values )
                {
                    doc.Dispose();
                }
                _orgDocuments = null;
            }
            // 帳票共通部品キャッシュクリア
            if ( _reportCtrl != null )
            {
                _reportCtrl.Clear();
                _reportCtrl = null;
            }
            // --- ADD m.suzuki 2010/11/10 ---------->>>>>
            // レポートクラス
            if ( _prtRptList != null )
            {
                foreach ( ar.ActiveReport3 report in _prtRptList )
                {
                    report.Dispose();
                }
                _prtRptList = null;
            }
            // --- ADD m.suzuki 2010/11/10 ----------<<<<<
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<
    }
}
