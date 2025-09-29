//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：在庫マスタ一覧印刷
// プログラム概要   ：在庫マスタ一覧の印刷を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/01/13     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/20     修正内容：Mantis【12127】速度アップ対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/27     修正内容：Mantis【12126】倉庫のグループサプレス対応
//                          修正内容：Mantis【11394】ソート順設定の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木正臣
// 修正日    2009/05/25     修正内容：ドットプリンタ印刷対応。通常の印刷部品を使用するよう変更。
// ---------------------------------------------------------------------//

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

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 自由帳票（在庫マスタ一覧）印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由帳票（在庫マスタ一覧）の印刷を行う。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009.01.13</br>
    /// </remarks>
    class PMZAI02022PA : IPrintProc
    {
        #region ■ Constructor
        /// <summary>
        /// 自由帳票（在庫マスタ一覧）印刷クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由帳票（在庫マスタ一覧）印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public PMZAI02022PA ()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
            this._printARTypeCmn = new PrintActiveReportTypeCommon();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD
        }

        /// <summary>
        /// 自由帳票（在庫マスタ一覧）印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 自由帳票（在庫マスタ一覧）印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public PMZAI02022PA ( object printInfo )
        {
            this._printInfo = printInfo as SFCMN06002C;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
            this._printARTypeCmn = new PrintActiveReportTypeCommon();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD
        }
        #endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        private const string ct_RangeConst = "：{0} ～ {1}";
        private const string ct_SortOrder = "STOCKRF.WAREHOUSECODERF, STOCKRF.WAREHOUSESHELFNORF, STOCKRF.GOODSNORF, STOCKRF.GOODSMAKERCDRF";
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private ExtrInfo_StockMasterTbl _extrInfo;
        private List<string> _pdfPathList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
        private PrintActiveReportTypeCommon _printARTypeCmn;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD
        #endregion ■ Private Member

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
        /// 印刷情報取得プロパティ
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 印刷処理開始
        /// <summary>
        /// 印刷処理開始
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷を開始する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public int StartPrint ()
        {
            return PrintMain();
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private int PrintMain ()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
                _printARTypeCmn.ClearCount();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD

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

                DataSet printDataSet = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();
                dv.Table = printDataSet.Tables[PMZAI02029AB.CT_Tbl_StockList];
                dv.Sort = ct_SortOrder;

                // 印刷情報データリストを展開
                this._extrInfo = this._printInfo.jyoken as ExtrInfo_StockMasterTbl;
                List<SlipPrtSetWork> slipPrtSetWorkList = null;
                List<CustSlipMngWork> custSlipMngWorkList = null;
                List<FrePrtPSetWork> frePrtPSetWorkList = null;
                List<PrtManage> prtManageList = null;
                List<FrePprSrtOWork> frePprSrtOWorkList = null;     // ADD 2009/04/27

                foreach (object obj in this._extrInfo.PrintInfoList)
                {
                    if (obj is List<SlipPrtSetWork>)
                    {
                        slipPrtSetWorkList = (List<SlipPrtSetWork>)obj;
                    }
                    else if (obj is List<CustSlipMngWork>)
                    {
                        custSlipMngWorkList = (List<CustSlipMngWork>)obj;
                    }
                    else if (obj is List<FrePrtPSetWork>)
                    {
                        frePrtPSetWorkList = (List<FrePrtPSetWork>)obj;
                    }
                    else if (obj is List<PrtManage>)
                    {
                        prtManageList = (List<PrtManage>)obj;
                    }
                    // ADD 2009/04/27 ------>>>
                    else if (obj is List<FrePprSrtOWork>)
                    {
                        frePprSrtOWorkList = (List<FrePprSrtOWork>)obj;
                    }
                    // ADD 2009/04/27 ------<<<
                }

                // ADD 2009/04/27 ------>>>
                // ソート順の設定
                string sortOrder = SFANL08235CE.GetSortString(frePprSrtOWorkList);
                if (sortOrder != string.Empty)
                {
                    dv.Sort = sortOrder;
                }
                // ADD 2009/04/27 ------<<<

                // PDF出力一覧リスト
                _pdfPathList = new List<string>();

                // 自由帳票印字位置設定 取得
                FrePrtPSetWork frePrtPSet = frePrtPSetWorkList[0];
                // プリンタ管理設定 取得
                PrtManage prtManage = prtManageList[0];

                # region [印刷処理]
                // レポートドキュメント初期化
                Document printDocument = new Document();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                //SFCMN00299CA processingDialog = new SFCMN00299CA();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL

                try
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                    //processingDialog.Title = "印刷処理";
                    //processingDialog.Message = "現在、印刷準備中です。";
                    //processingDialog.DispCancelButton = false;
                    //processingDialog.Show();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL

                    using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
                    {
                        ar.ActiveReport3 prtRpt = null;
                        prtRpt = new ar.ActiveReport3();

                        # region [レポート基本設定]
                        stream.Position = 0;
                        prtRpt.LoadLayout(stream);
                        //SFANL08235CE.AddScriptReference(ref prtRpt);	// Script用参照追加     // DEL 2009/04/20
                        prtRpt.Script = string.Empty;       // ADD 2009/04/20
                        SetPrinterInfo(prtRpt.Document, prtManage);
                        SFANL08235CE.SetValidPaperKind(prtRpt);
                        prtRpt.DataSource = dv;

                        // ADD 2009/04/27 ------>>>
                        // グループサプレス処理
                        PMCMN02000CA prtCmn = PMCMN02000CA.GetInstance();
                        prtCmn.GroupSuppressDiv = PMCMN02000CA.GroupSuppressDivState.FreePrint;
                        prtCmn.SetReportProps(ref prtRpt);
                        // ADD 2009/04/27 ------<<<                        
                        # endregion

                        // ページセクション取得
                        ar.Section pageHeader = prtRpt.Sections["PageHeader1"];
                        foreach (ar.ARControl control in pageHeader.Controls)
                        {
                            if (control.Name == "PrintPageRF")
                            {
                                // ページ数の設定
                                control.DataField = "";
                                ((ar.TextBox)control).SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
                                ((ar.TextBox)control).SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
                            }
                        }
                        // グループセクションの取得
                        ar.Section groupHeader = prtRpt.Sections["GroupHeader1"];
                        foreach (ar.ARControl control in groupHeader.Controls)
                        {
                            if (control.Name == "PrintRangeRF")
                            {
                                // 抽出範囲の設定
                                control.DataField = "";
                                string extarCondition;
                                MakeExtarCondition(out extarCondition);
                                ((ar.TextBox)control).Text = extarCondition;
                            }
                        }


                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                        //// 印刷実行
                        //prtRpt.Run();

                        //// 印刷用Documentにまとめる
                        //printDocument.Pages.AddRange(prtRpt.Document.Pages);

                        //if (prtRpt != null)
                        //{
                        //    SetPrinterInfo(printDocument, prtManage);

                        //    // 用紙の種類を指定
                        //    printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                        //    // 用紙サイズがカスタムの時は用紙サイズまで指定
                        //    if (prtRpt.PageSettings.PaperKind == PaperKind.Custom)
                        //    {
                        //        printDocument.Printer.PaperSize = new PaperSize("Custom", Convert.ToInt32(prtRpt.PageSettings.PaperWidth * 100), Convert.ToInt32(prtRpt.PageSettings.PaperHeight * 100));
                        //    }
                        //    // 用紙方向（縦・横）の設定
                        //    if (prtRpt.PageSettings.Orientation == PageOrientation.Landscape)
                        //    {
                        //        printDocument.Printer.Landscape = true;
                        //    }
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD

                        // 印刷共通情報プロパティ設定
                        Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                        this.SetPrintCommonInfo( out commonInfo );

                        // プレビュー有無				
                        int prevkbn = this._printInfo.prevkbn;

                        // 出力モードがＰＤＦの場合、無条件でプレビュー無
                        if ( this._printInfo.printmode == 2 )
                        {
                            prevkbn = 0;
                        }
                        switch ( prevkbn )
                        {
                            case 0:		// プレビュ無
                                {
                                    Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                                    // 共通条件設定
                                    processForm.CommonInfo = commonInfo;

                                    // プログレスバーUPイベント追加
                                    DataDynamics.ActiveReports.Detail detail = null;
                                    foreach ( DataDynamics.ActiveReports.Section sec in prtRpt.Sections )
                                    {
                                        if ( sec.Type == DataDynamics.ActiveReports.SectionType.Detail )
                                        {
                                            detail = (sec as DataDynamics.ActiveReports.Detail);
                                            break;
                                        }
                                    }
                                    if ( detail != null )
                                    {
                                        detail.AfterPrint += new EventHandler( PMZAI02022PA_Detail_AfterPrint );
                                        _printARTypeCmn.ProgressBarUpEvent += new ProgressBarUpEventHandler( processForm.ProgressBarUpEvent );
                                    }

                                    // 印刷実行
                                    status = processForm.Run( prtRpt );

                                    // 戻り値設定
                                    this._printInfo.status = status;

                                    break;
                                }
                            case 1:		// プレビュ有
                                {
                                    Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                                    // 共通条件設定
                                    viewForm.CommonInfo = commonInfo;

                                    // プレビュー実行
                                    status = viewForm.Run( prtRpt );

                                    // 戻り値設定
                                    this._printInfo.status = status;

                                    break;
                                }
                        }

                        // ＰＤＦ出力の場合
                        if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                        {
                            switch ( this._printInfo.printmode )
                            {
                                case 1:		// プリンタ
                                    break;
                                case 2:		// ＰＤＦ
                                case 3:		// 両方(プリンタ + ＰＤＦ)
                                    {
                                        // ＰＤＦ表示フラグON
                                        this._printInfo.pdfopen = true;

                                        // 両方印刷時のみ履歴保存
                                        if ( this._printInfo.printmode == 3 )
                                        {
                                            // 出力履歴管理に追加
                                            Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                            pdfHistoryControl.AddPrintInfo( this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                                this._printInfo.pdftemppath );
                                        }
                                        break;
                                    }
                            }
                        }

                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD

                        stream.Close();
                    }
                }
                finally
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                    //processingDialog.Dispose();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                //if (_printInfo.printmode == 1 || _printInfo.printmode == 3)
                //{
                //    //-------------------------------------------
                //    // ①印刷：
                //    //-------------------------------------------
                //    ExecutePrint(printDocument, null);
                //}
                //if (_printInfo.printmode == 2)
                //{
                //    //-------------------------------------------
                //    // ②ＰＤＦ：
                //    //-------------------------------------------
                //    _pdfPathList = new List<string>();
                //    ExecutePrint(printDocument, _pdfPathList);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL

                # endregion
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
        /// <summary>
        /// 明細印刷後イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI02022PA_Detail_AfterPrint( object sender, EventArgs e )
        {
            _printARTypeCmn.CallProgressBarUp();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD

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
        /// <param name="pdfList"></param>
        private void ExecutePrint(Document printDocument, List<string> pdfList)
        {
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
                        this._printInfo.status = form.PrintPreview(para);
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
                            pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                this._printInfo.pdftemppath);
                        }
                        break;
                }
            }
            # endregion
        }

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
        /// プリンター情報セット処理
        /// </summary>
        /// <param name="document">レポートDocument</param>
        /// <param name="prtManage"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: プリンター情報を設定します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009.01.13</br>
        /// </remarks>
        private void SetPrinterInfo( Document document, PrtManage prtManage )
        {
            // 使用プリンターの設定
            document.Printer.PrinterSettings.PrinterName = prtManage.PrinterName;
            
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
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

        #region ◎ 各種プロパティ設定
        /// <summary>
        /// 各種プロパティ設定
        /// </summary>
        /// <param name="rpt">インスタンス化された帳票フォームクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 各種プロパティを設定します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
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
            //object[] titleObj = new object[] { "自由帳票（在庫マスタ一覧）" };
            //instance.PageHeaderSubtitle = string.Format( "{0}", titleObj );

            //// その他データ
            //// Todo:移動元とか渡す？抽出条件渡るからいいか？
            //instance.OtherDataList = null;

            //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.02.05</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
            //int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            //// 帳票チャート共通部品クラス
            //SFCMN00331C cmnCommon = new SFCMN00331C();

            //// PDFパス取得
            //string pdfPath = "";
            //string pdfName = "";

            //// プリンタ名
            //commonInfo.PrinterName = string.Empty;//prtManage.PrinterName;
            //// 帳票名
            //commonInfo.PrintName = "在庫マスタ一覧印刷";
            //// 印刷モード

            //try
            //{
            //    commonInfo.PrintMode = this.Printinfo.printmode;
            //}
            //catch
            //{
            //    commonInfo.PrintMode = 1;
            //}

            //// 印刷件数表示
            //commonInfo.PrintMax = 0;

            //status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            //this._printInfo.pdftemppath = pdfPath + pdfName;
            //commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            //// 上余白
            //commonInfo.MarginsTop = 0;//this._printInfo.py;
            //// 左余白
            //commonInfo.MarginsLeft = 0;//this._printInfo.px;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
            SFCMN00331C sfcmn00331C = new SFCMN00331C();

            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // プリンタ名
            commonInfo.PrinterName = this._printInfo.prinm;

            // 帳票名
            commonInfo.PrintName = "在庫マスタ一覧印刷";

            // 印刷件数
            commonInfo.PrintMax = ((DataSet)this._printInfo.rdData).Tables[PMZAI02029AB.CT_Tbl_StockList].Rows.Count;

            // 印刷モード
            commonInfo.PrintMode = this._printInfo.printmode;

            // 余白設定
            // 桁位置
            commonInfo.MarginsLeft = this._printInfo.px;

            // 行位置
            commonInfo.MarginsTop = this._printInfo.py;

            // PDF出力フルパス
            string pdfPath = "";
            string pdfName = "";
            sfcmn00331C.GetPdfSavePathName( this._printInfo.prpnm, ref pdfPath, ref pdfName );

            string pdfFileName = System.IO.Path.Combine( pdfPath, pdfName );
            commonInfo.PdfFullPath = pdfFileName;

            this._printInfo.pdftemppath = pdfFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD
        }

        #endregion

        #region ◎ 抽出条件出力情報作成
        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraCondition">作成後抽出条件文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private void MakeExtarCondition(out String extraCondition)
        {
            extraCondition = "";
            StringCollection addConditions = new StringCollection();

            //-------------------------------------------------------------------------------------------------------------------
            // 倉庫 
            // 開始･終了のいずれかが入力されていれば印字
            if (_extrInfo.St_WarehouseCode != string.Empty || _extrInfo.Ed_WarehouseCode != string.Empty)
            {
                string stCode = _extrInfo.St_WarehouseCode;
                string edCode = _extrInfo.Ed_WarehouseCode;
                if (stCode == string.Empty) stCode = ct_Extr_Top;
                if (edCode == string.Empty) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("倉庫" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // 棚番 
            // 開始･終了のいずれかが入力されていれば印字
            if (_extrInfo.St_WarehouseShelfNo != string.Empty || _extrInfo.Ed_WarehouseShelfNo != string.Empty)
            {
                string stCode = _extrInfo.St_WarehouseShelfNo;
                string edCode = _extrInfo.Ed_WarehouseShelfNo;
                if (stCode == string.Empty) stCode = ct_Extr_Top;
                if (edCode == string.Empty) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("棚番" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // 仕入先
            // 開始･終了のいずれかが入力されていれば印字
            if (_extrInfo.St_SupplierCd != 0 || _extrInfo.Ed_SupplierCd != 0)
            {
                string stCode = _extrInfo.St_SupplierCd.ToString("d08");
                string edCode = _extrInfo.Ed_SupplierCd.ToString("d08");
                if (_extrInfo.St_SupplierCd == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_SupplierCd == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("仕入先" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // メーカー
            // 開始･終了のいずれかが入力されていれば印字
            if (_extrInfo.St_GoodsMakerCd != 0 || _extrInfo.Ed_GoodsMakerCd != 0)
            {
                string stCode = _extrInfo.St_GoodsMakerCd.ToString("d04");
                string edCode = _extrInfo.Ed_GoodsMakerCd.ToString("d04");
                if (_extrInfo.St_GoodsMakerCd == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_GoodsMakerCd == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("メーカー" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // 商品大分類
            // 開始･終了のいずれかが入力されていれば印字
            if (_extrInfo.St_GoodsLGroup != 0 || _extrInfo.Ed_GoodsLGroup != 0)
            {
                string stCode = _extrInfo.St_GoodsLGroup.ToString("d04");
                string edCode = _extrInfo.Ed_GoodsLGroup.ToString("d04");
                if (_extrInfo.St_GoodsLGroup == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_GoodsLGroup == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("商品大分類" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // 商品中分類
            // 開始･終了のいずれかが入力されていれば印字
            if (_extrInfo.St_GoodsMGroup != 0 || _extrInfo.Ed_GoodsMGroup != 0)
            {
                string stCode = _extrInfo.St_GoodsMGroup.ToString("d04");
                string edCode = _extrInfo.Ed_GoodsMGroup.ToString("d04");
                if (_extrInfo.St_GoodsMGroup == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_GoodsMGroup == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("商品中分類" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // グループ
            // 開始･終了のいずれかが入力されていれば印字
            if (_extrInfo.St_BLGroupCode != 0 || _extrInfo.Ed_BLGroupCode != 0)
            {
                string stCode = _extrInfo.St_BLGroupCode.ToString("d05");
                string edCode = _extrInfo.Ed_BLGroupCode.ToString("d05");
                if (_extrInfo.St_BLGroupCode == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_BLGroupCode == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("グループコード" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // BL
            // 開始･終了のいずれかが入力されていれば印字
            if (_extrInfo.St_BLGoodsCode != 0 || _extrInfo.Ed_BLGoodsCode != 0)
            {
                string stCode = _extrInfo.St_BLGoodsCode.ToString("d05");
                string edCode = _extrInfo.Ed_BLGoodsCode.ToString("d05");
                if (_extrInfo.St_BLGoodsCode == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_BLGoodsCode == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("ＢＬコード" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // 品番 
            // 開始･終了のいずれかが入力されていれば印字
            if (_extrInfo.St_GoodsNo != string.Empty || _extrInfo.Ed_GoodsNo != string.Empty)
            {
                string stCode = _extrInfo.St_GoodsNo;
                string edCode = _extrInfo.Ed_GoodsNo;
                if (stCode == string.Empty) stCode = ct_Extr_Top;
                if (edCode == string.Empty) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("品番" + ct_RangeConst, stCode, edCode));
            }

            // 追加
            foreach (string exCondStr in addConditions)
            {
                extraCondition = extraCondition + exCondStr;
            }
        }
        #endregion

        #region ◎ 抽出範囲文字列作成
        /// <summary>
        /// 抽出範囲文字列作成
        /// </summary>
        /// <returns>作成文字列</returns>
        /// <remarks>
        /// <br>Note       : 抽出範囲文字列を作成します</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private DialogResult MsgDispProc ( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            return TMsgDisp.Show( iLevel, "MAZAI02022P", iMsg, iSt, iButton, iDefButton );
        }

        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
        /// <summary>
        /// プログレスバーカウントアップ用クラス
        /// </summary>
        /// <remarks>通常はReportクラスに実装しますが、本ＰＧは自由帳票でReportはクラス定義を持たない為、このクラスで代用します。</remarks>
        private class PrintActiveReportTypeCommon : IPrintActiveReportTypeCommon
        {
            private int _printCount;

            public event ProgressBarUpEventHandler ProgressBarUpEvent;

            public int WatermarkMode
            {
                get
                {
                    return 0;
                }
                set
                {
                }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public PrintActiveReportTypeCommon()
            {
                _printCount = 0;
            }
            /// <summary>
            /// カウントクリア
            /// </summary>
            public void ClearCount()
            {
                _printCount = 0;
            }
            /// <summary>
            /// カウントアップイベントコール
            /// </summary>
            public void CallProgressBarUp()
            {
                _printCount++;

                if ( ProgressBarUpEvent != null )
                {
                    ProgressBarUpEvent( this, _printCount );
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD

        #endregion
    }
}
