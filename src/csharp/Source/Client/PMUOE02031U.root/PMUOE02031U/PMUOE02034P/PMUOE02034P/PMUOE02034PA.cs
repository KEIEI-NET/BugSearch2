//****************************************************************************//
// システム         : 送信前リスト
// プログラム名称   : 送信前リスト 印刷クラス
// プログラム概要   : 送信前リスト 印刷クラスを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/09/11  修正内容 : MAHNB02012P：入金確認表を参考に新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 送信前リスト 印刷クラス
    /// </summary>
    public sealed class PMUOE02034PA : IPrintProc
    {
        #region <例外/>

        /// <summary>
        /// 送信前リスト例外クラス
        /// </summary>
        private class SendBeforeOrderException : ApplicationException
        {
            /// <summary>ステータス</summary>
            private readonly int _status;
            /// <summary>
            /// ステータスを取得します。
            /// </summary>
            /// <value>ステータス</value>
            public int Status { get { return _status; } }

            /// <summary>
            ///カスタムコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public SendBeforeOrderException(
                string message,
                int status
            ) : base(message)
            {
                _status = status;
            }
        }

        #endregion  // <例外/>

        #region <IPrintProc メンバ/>

        #region <印刷情報/>

        /// <summary>印刷情報</summary>
        private SFCMN06002C _printInfo;
        /// <summary>
        /// 印刷情報のアクセサ
        /// </summary>
        /// <value>印刷情報</value>
        public SFCMN06002C Printinfo
        {
            get { return _printInfo; }
            set { _printInfo = value; }
        }

        #endregion  // <印刷情報/>

        /// <summary>
        /// 印刷処理を開始します。
        /// </summary>
        /// <returns>結果コード</returns>
        public int StartPrint()
        {
            return PrintMain();
        }

        /// <summary>
        /// 印刷処理を行います。
        /// </summary>
        /// <returns>結果コード</returns>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 印刷フォーム
            DataDynamics.ActiveReports.ActiveReport3 printingReport = null;

            try
            {
                // レポートインスタンスを生成
                printingReport = CreateReport(Printinfo.prpid);
                if (printingReport == null) return status;

                // 各種プロパティを設定
                status = SetPropertyOf(ref printingReport);
                if (!status.Equals((int)ConstantManagement.MethodResult.ctFNC_NORMAL)) return status;

                // データソース設定
                printingReport.DataSource = (DataSet)Printinfo.rdData;
                printingReport.DataMember = SendBeforeAcs.SearchedDataTableName;

                // 印刷共通情報を生成
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo = CreatePrintCommonInfo();

                // プレビュー有無				
                int mode = Printinfo.prevkbn;
                // 出力モードがＰＤＦの場合、無条件でプレビュー無
                if (Printinfo.printmode.Equals(2))  // HACK:(Magic Number)出力モード.PDF
                {
                    mode = 0;   // HACK:(Magic Number)出力モード.プレビュー無し
                }
                switch (mode)
                {
                    case 0: // HACK:(Magic Number)出力モード.プレビュー無し
                    {
                        Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                        // 共通条件を設定
                        processForm.CommonInfo = commonInfo;

                        // プログレスバーUPイベントを追加
                        if (printingReport is IPrintActiveReportTypeCommon)
                        {
                            ((IPrintActiveReportTypeCommon)printingReport).ProgressBarUpEvent += new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                        }

                        // 印刷を実行
                        status = processForm.Run(printingReport);

                        // 戻り値を設定
                        Printinfo.status = status;

                        break;
                    }
                    case 1: // HACK:(Magic Number)出力モード.プレビュー有り
                    {
                        Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                        // 共通条件を設定
                        viewForm.CommonInfo = commonInfo;

                        // プレビューを実行
                        status = viewForm.Run(printingReport);

                        // 戻り値を設定
                        Printinfo.status = status;

                        break;
                    }
                }

                // ＰＤＦ出力の場合
                if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_NORMAL))
                {
                    switch (Printinfo.printmode)
                    {
                        case 1:  // HACK:(Magic Number)印刷モード.プリンタ
                            break;
                        case 2:  // HACK:(Magic Number)印刷モード.ＰＤＦ
                        case 3:  // HACK:(Magic Number)印刷モード.両方(プリンタ + ＰＤＦ)
                        {
                            // ＰＤＦ表示フラグON
                            Printinfo.pdfopen = true;

                            // 両方印刷時のみ履歴保存
                            if (Printinfo.printmode == 3)   // HACK:(Magic Number)印刷モード.両方(プリンタ + ＰＤＦ)
                            {
                                // 出力履歴管理に追加
                                Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                pdfHistoryControl.AddPrintInfo(
                                    Printinfo.key,
                                    Printinfo.prpnm,
                                    Printinfo.prpnm,
                                    Printinfo.pdftemppath
                                );
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(emErrorLevel.ERR_LEVEL_STOPDISP, e.Message, STATUS_OF_ERROR, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (printingReport != null) printingReport.Dispose();
            }

            return status;
        }

        #region <帳票構築/>

        /// <summary>帳票フォームの名前空間</summary>
        private const string REPORT_FORM_NAME_SPACE = "Broadleaf.Drawing.Printing";

        /// <summary>
        /// 各種ActiveReport帳票のインスタンスを生成します。
        /// </summary>
        /// <param name="reportId">帳票フォームID</param>
        /// <returns>各種ActiveReport帳票のインスタンス</returns>
        private static DataDynamics.ActiveReports.ActiveReport3 CreateReport(string reportId)
        {
            // 印刷フォームクラスのインスタンスを作成
            return (DataDynamics.ActiveReports.ActiveReport3)CreateInstanceFromAssembly(
                reportId.Trim(),
                REPORT_FORM_NAME_SPACE + "." + reportId.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3)
            );
        }

        /// <summary>
        /// アセンブリからインスタンスを生成します。
        /// </summary>
        /// <param name="assemblyName">アセンブリ名称</param>
        /// <param name="className">クラス名称</param>
        /// <param name="type">クラス型</param>
        /// <returns>インスタンス</returns>
        private static object CreateInstanceFromAssembly(
            string assemblyName,
            string className,
            Type type
        )
        {
            object instance = null;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(assemblyName);
            Type loadedType = assembly.GetType(className);
            if (loadedType != null)
            {
                if (
                    (loadedType == type)
                        ||
                    loadedType.IsSubclassOf(type)
                        ||
                    (loadedType.GetInterface(type.Name).Name.Equals(type.Name)))
                {
                    instance = Activator.CreateInstance(loadedType);
                }
            }
            
            return instance;
        }

        /// <summary>
        /// 各種プロパティを設定します。
        /// </summary>
        /// <param name="reportForm">帳票フォーム</param>
        /// <returns>結果コード</returns>
        private int SetPropertyOf(ref DataDynamics.ActiveReports.ActiveReport3 reportForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList activeReport = reportForm as IPrintActiveReportTypeList;

            // 印刷条件を取得
            SendBeforeOrderCondition extraInfo = (SendBeforeOrderCondition)Printinfo.jyoken;

            // ソート順プロパティを設定
            activeReport.PageHeaderSortOderTitle = string.Empty;

            // 帳票出力設定情報を取得 
            PrtOutSet printOutSet;
            string message;
            int result = SendBeforeAcs.ReadPrtOutSet(out printOutSet, out message);
            if (!result.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                throw new SendBeforeOrderException(message, status);
            }

            // 抽出条件ヘッダ出力区分
            activeReport.ExtraCondHeadOutDiv = printOutSet.ExtraCondHeadOutDiv;

            // 抽出条件の編集処理
            StringCollection extraInfomations = CreateStringCollectionOfExtractionCondition();
            activeReport.ExtraConditions = extraInfomations;

            // フッタ出力区分
            activeReport.PageFooterOutCode = printOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            {
                footers.Add(printOutSet.PrintFooter1);
                footers.Add(printOutSet.PrintFooter2);
            }
            activeReport.PageFooters = footers;

            // 印刷情報オブジェクト
            activeReport.PrintInfo = Printinfo;

            // ヘッダーサブタイトル
            activeReport.PageHeaderSubtitle = string.Empty;

            // その他データ
            ArrayList otherDataList = new ArrayList();
            activeReport.OtherDataList = otherDataList;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #region <帳票ヘッダ（抽出条件）/>

        /// <summary>
        /// 抽出条件の文字列コレクションを生成します。
        /// </summary>
        /// <returns>抽出条件の文字列コレクション</returns>
        private StringCollection CreateStringCollectionOfExtractionCondition()
        {
            const string THAT = ": ";
            const string FROM_BEGIN = "最初から";   // HACK:最初から
            const string TO_END     = "最後まで";   // HACK:最後まで
            const string WAVE = " ～ ";
            const string ONLINE_NO_FORMAT           = "000000000";
            const string UOE_SUPPLIER_CODE_FORMAT   = "000000";

            StringCollection extraConditions= new StringCollection();
            StringCollection addConditions  = new StringCollection();

            string target = string.Empty;

            // システム区分
            EditCondition(ref addConditions, SendBeforeOrderCondition.SYSTEM_DIV_CD_TITLE + THAT + ExtractionCondition.SystemDivName);

            // 印刷順
            EditCondition(ref addConditions, SendBeforeOrderCondition.PRINT_ORDER_TITLE + THAT + ExtractionCondition.PrintOrderName);

            // 注文番号
            string fromOnLineNo = ExtractionCondition.St_OnlineNo.ToString(ONLINE_NO_FORMAT);
            string toOnLineNo   = ExtractionCondition.Ed_OnlineNo.ToString(ONLINE_NO_FORMAT);
            if ((ExtractionCondition.St_OnlineNo.Equals(0)) && (!ExtractionCondition.Ed_OnlineNo.Equals(0)))
            {
                target = SendBeforeOrderCondition.ONLINE_NO_TITLE + THAT + FROM_BEGIN + WAVE + toOnLineNo;
                EditCondition(ref addConditions, target);
            }
            if ((ExtractionCondition.St_OnlineNo > 0) && (ExtractionCondition.Ed_OnlineNo.Equals(0)))
            {
                target = SendBeforeOrderCondition.ONLINE_NO_TITLE + THAT + fromOnLineNo + WAVE + TO_END;
                EditCondition(ref addConditions, target);
            }
            if ((ExtractionCondition.St_OnlineNo > 0) && (!ExtractionCondition.Ed_OnlineNo.Equals(0)))
            {
                target = SendBeforeOrderCondition.ONLINE_NO_TITLE + THAT + fromOnLineNo + WAVE + toOnLineNo;
                EditCondition(ref addConditions, target);
            }

            // 発注先
            string fromUOESupplierCode  = ExtractionCondition.St_UOESupplierCd.ToString(UOE_SUPPLIER_CODE_FORMAT);
            string toUOESupplierCode    = ExtractionCondition.Ed_UOESupplierCd.ToString(UOE_SUPPLIER_CODE_FORMAT);
            if ((ExtractionCondition.St_UOESupplierCd.Equals(0)) && (!ExtractionCondition.Ed_UOESupplierCd.Equals(0)))
            {
                target = SendBeforeOrderCondition.UOE_SUPPLIER_CD_TITLE + THAT + FROM_BEGIN + WAVE + toUOESupplierCode;
                EditCondition(ref addConditions, target);
            }
            if ((ExtractionCondition.St_UOESupplierCd > 0) && (ExtractionCondition.Ed_UOESupplierCd.Equals(0)))
            {
                target = SendBeforeOrderCondition.UOE_SUPPLIER_CD_TITLE + THAT + fromUOESupplierCode + WAVE + TO_END;
                EditCondition(ref addConditions, target);
            }
            if ((ExtractionCondition.St_UOESupplierCd > 0) && (!ExtractionCondition.Ed_UOESupplierCd.Equals(0)))
            {
                target = SendBeforeOrderCondition.UOE_SUPPLIER_CD_TITLE + THAT + fromUOESupplierCode + WAVE + toUOESupplierCode;
                EditCondition(ref addConditions, target);
            }

            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }

            return extraConditions;
        }

        /// <summary>
        /// 出力する抽出条件文字列を編集します。
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        private static void EditCondition(
            ref StringCollection editArea,
            string target
        )
        {
            const string SPACE_CHAR = "　"; // 空白文字

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

                if ((areaByte + targetByte + 2) <= 190) // LITERAL:190[Byte]
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[i] != null) editArea[i] += SPACE_CHAR;

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

        #endregion  // <帳票ヘッダ（抽出条件）/>

        #endregion  // <帳票構築/>

        #region <印刷ダイアログ/>

        /// <summary>
        /// 印刷画面の共通情報を生成します。
        /// </summary>
        /// <returns>印刷画面の共通情報</returns>
        private Broadleaf.Windows.Forms.SFCMN00293UC CreatePrintCommonInfo()
        {
            Broadleaf.Windows.Forms.SFCMN00293UC commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // プリンタ名
            commonInfo.PrinterName = Printinfo.prinm;
            // 帳票名
            commonInfo.PrintName = Printinfo.prpnm;
            // 印刷モード
            commonInfo.PrintMode = Printinfo.printmode;
            // 印刷件数
            commonInfo.PrintMax = 0;

            // PDFパス取得
            string pdfPath = string.Empty;
            string pdfName = string.Empty;

            // 帳票チャート共通部品クラス
            SFCMN00331C cmnCommon = new SFCMN00331C();
            int status = cmnCommon.GetPdfSavePathName(Printinfo.prpnm, ref pdfPath, ref pdfName);

            Printinfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = Printinfo.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = Printinfo.py;
            // 左余白
            commonInfo.MarginsLeft = Printinfo.px;

            return commonInfo;
        }

        #endregion  // <印刷ダイアログ/>

        #endregion  // <IPrintProc メンバ/>

        #region <抽出条件/>

        /// <summary>抽出条件</summary>
        private readonly SendBeforeOrderCondition _extractionCondition;
        /// <summary>
        /// 抽出条件を取得します。
        /// </summary>
        /// <value>抽出条件</value>
        private SendBeforeOrderCondition ExtractionCondition { get { return _extractionCondition; } }

        #endregion  // <抽出条件/>

        #region <Constructor/>

        /// <summary>
		/// カスタムクラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報</param>
        public PMUOE02034PA(object printInfo)
		{
			_printInfo = printInfo as SFCMN06002C;
			_extractionCondition = _printInfo.jyoken as SendBeforeOrderCondition;
        }

        #endregion  // <Constructor/>

        #region <エラーメッセージ表示/>

        /// <summary>異常</summary>
        private int STATUS_OF_ERROR = -1;

        /// <summary>
		/// エラーメッセージを表示します。
		/// </summary>
        /// <param name="errorLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="button">表示ボタン</param>
        /// <param name="defaultButton">デフォルトフォーカスボタン</param>
		/// <returns>ダイアログの操作結果</returns>
		private static DialogResult ShowErrorMessage(
            emErrorLevel errorLevel,
            string message,
            int status,
            MessageBoxButtons button,
            MessageBoxDefaultButton defaultButton
        )
		{
            const string PG_ID = "PMUOE02034P"; // HACK:プログラムID
			return TMsgDisp.Show(errorLevel, PG_ID, message, status, button, defaultButton);
        }

        #endregion  // <エラーメッセージ表示/>
    }
}
