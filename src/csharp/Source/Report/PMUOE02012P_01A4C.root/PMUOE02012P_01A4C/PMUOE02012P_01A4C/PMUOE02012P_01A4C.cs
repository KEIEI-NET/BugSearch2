using System;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.Common;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 回線エラーリスト印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 回線エラーリストのフォームクラスです。</br>
    /// <br>Programmer   : 照田 貴志</br>
    /// <br>Date         : 2008/11/04</br>
    /// <br>UpdateNote   :</br>
    /// <br>             :</br>
    /// </remarks>
    public class PMUOE02012P_01A4C : DataDynamics.ActiveReports.ActiveReport3,
                                     IPrintActiveReportTypeList,
                                     IPrintActiveReportTypeCommon
    {
        #region ■定数、変数、構造体
        // 変数
        private int _printCount;					// 印刷件数用カウンタ
        private SFCMN06002C _printInfo;				// 印刷情報クラス
        bool _disposed = false;                     // Disposeチェック用フラグ

        // IPrintActiveReportTypeListインターフェイス用変数
        private int _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
        private string _pageHeaderSubTitle;			// 帳票サブタイトル
        private string _pageHeaderSortOderTitle;	// ソート順
        private StringCollection _extraConditions;	// 抽出条件
        private StringCollection _pageFooters;		// フッターメッセージ
        private int _pageFooterOutCode;             // フッター出力区分
        #endregion

        #region ■Public
        #region ▼IPrintActiveReportTypeListインターフェイス用プロパティ
        /// <summary> 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ] </summary>
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }
        /// <summary> 帳票サブタイトル </summary>
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderSubTitle = value; }
        }
        /// <summary> ページヘッダソート順タイトル項目 </summary>
        public string PageHeaderSortOderTitle
        {
            set { this._pageHeaderSortOderTitle = value; }
        }
        /// <summary> 抽出条件ヘッダー項目 </summary>
        public StringCollection ExtraConditions
        {
            set { this._extraConditions = value; }
        }
        /// <summary> フッター出力区分 </summary>
        public int PageFooterOutCode
        {
            set { this._pageFooterOutCode = value; }
        }
        /// <summary> フッタ出力文 </summary>
        public StringCollection PageFooters
        {
            set { this._pageFooters = value; }
        }
        /// <summary> 印刷情報 </summary>
        public SFCMN06002C PrintInfo
        {
            set { this._printInfo = value; }
        }
        /// <summary> その他データ </summary>
        public ArrayList OtherDataList
        {
            set { }
        }
        #endregion

        #region ▼IPrintActiveReportTypeCommonインターフェイス用プロパティ
        /// <summary> 背景透過設定値プロパティ </summary>
        public int WatermarkMode
        {
            get { return 0; }
            set { }
        }
        #endregion

        #region ▼印刷件数カウントアップイベント
        /// <summary> 印刷件数カウントアップイベント </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion
        #endregion ■Public - end

        #region ■ Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note         : インスタンスを初期化します。</br>
        /// <br>Programmer   : 照田 貴志</br>
        /// <br>Date         : 2008/11/04</br>
        /// </remarks>
        public PMUOE02012P_01A4C ()
        {
            InitializeComponent();
        }
        #endregion ■ Constructor

        #region ■ Dispose(override)
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                try
                {
                    if (disposing)
                    {
                        // ヘッダ用サブレポート後処理実行
                        if (this._rptExtraHeader != null)
                        {
                            this._rptExtraHeader.Dispose();
                        }

                        // フッタ用サブレポート後処理実行
                        if (this._rptPageFooter != null)
                        {
                            this._rptPageFooter.Dispose();
                        }
                    }

                    this._disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion ■ Dispose(override) - end

        #region ■イベント
        #region ▼PMUOE02012P_01A4C_ReportStart(処理開始時)
        /// <summary>
        /// 処理開始時
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void PMUOE02012P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region ▼PMUOE02012P_01A4C_PageEnd(ページ処理終了時)
        /// <summary>
        /// ページ処理終了時
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ページ終了時のイベントです。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void PMUOE02012P_01A4C_PageEnd(object sender, EventArgs e)
        {
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
        }
        #endregion

        #region ▼PageHeader_Format(ヘッダーデータ連結後、描画前)
        /// <summary>
        /// ヘッダーデータ連結後、描画前
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後、描画前に発生します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            this.tb_PrintDate.Text = DateTime.Now.ToString("yyyy/MM/dd");       // 作成日付
            this.tb_PrintTime.Text = DateTime.Now.ToString("HH:mm");            // 作成時間
        }
        #endregion

        #region ▼UOESupplierHeader_Format(発注先ヘッダーデータ連結後、描画前)
        /// <summary>
        /// 発注先ヘッダーデータ連結後、描画前
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後、描画前に発生します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void UOESupplierHeader_Format(object sender, EventArgs e)
        {
            if (this.UOESupplierCd.Value.ToString() == "0")
            {
                this.UOESupplierCd.Text = string.Empty;
            }
        }
        #endregion

        #region ▼Detail_Format(明細データ連結後、描画前)
        /// <summary>
        /// 明細データ連結後、描画前
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後、描画前に発生します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            if (this.GoodsMakerCd.Value.ToString() == "0")
            {
                this.GoodsMakerCd.Text = string.Empty;
            }
        }
        #endregion

        #region ▼Detail_BeforePrint(明細描画直前)
        /// <summary>
        /// 明細描画直前
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される直前に発生する。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
        {
            // グループサプレスの判断
            this.CheckGroupSuppression();

            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion

        #region ▼Detail_AfterPrint(明細描画後)
        /// <summary>
        /// 明細描画後
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void Detail_AfterPrint ( object sender, System.EventArgs eArgs )
        {
            // 印刷件数カウントアップ
            this._printCount++;
#if DEBUG
            return;
#endif
            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }

        }
        #endregion

        #region ▼PageFooter_Format(フッターデータ連結後、描画前)
        /// <summary>
        /// フッターデータ連結後、描画前
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後、描画前に発生します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void PageFooter_Format ( object sender, System.EventArgs eArgs )
        {
            if (this._pageFooters == null)
            {
                return;
            }

            // フッター出力
            if ( this._pageFooterOutCode == 0 ) {
                if (_rptPageFooter == null)
                {
                    // インスタンスが作成されていなければ作成
                    _rptPageFooter = new ListCommon_PageFooter();
                }
                else {
                    // インスタンスが作成されていれば、データソースを初期化する
                    // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                    _rptPageFooter.DataSource = null;
                }

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    _rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    _rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = _rptPageFooter;
            }
        }
        #endregion
        #endregion ■イベント - end

        #region ■Private
        #region ▼SetOfReportMembersOutput(レポート要素出力設定)
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void SetOfReportMembersOutput ()
        {
            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            // 改ページ
            this.UOESupplierHeader.NewPage = NewPage.Before;
            this.UOESupplierHeader.RepeatStyle = RepeatStyle.OnPage;

            this.OnlineNoHeader.NewPage = NewPage.Before;
            this.OnlineNoHeader.RepeatStyle = RepeatStyle.OnPage;

            // ゼロ埋め
            this.UOESupplierCd.OutputFormat = "000000";         // 発注先コード
            this.OnlineNo.OutputFormat = "000000000";    // 発注番号
            this.GoodsMakerCd.OutputFormat = "0000";            // メーカーコード

            // 件数初期化
            this._printCount = 0;
        }
        #endregion

        #region ▼CheckGroupSuppression(グループサプレス判断)
        /// <summary>
        /// グループサプレス判断
        /// </summary>
        /// <remarks>
        /// <br>Note		: グループサプレス処理の判定を行う。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        private void CheckGroupSuppression()
        {
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。
        }
        #endregion
        #endregion ■Private - end

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private TextBox tb_SystemDivName;
        private Label label1;
        private Label label4;
        private TextBox BOCode;
        private TextBox UOERemark1;
        private TextBox ErrorContents;
        private Line line3;
        private GroupHeader OnlineNoHeader;
        private TextBox OnlineNo;
        private Label lb_UOESalesOrder;
        private Line line5;
        private Label lb_GoodsNo;
        private Line line6;
        private Label lb_GoodsName;
        private Label lb_GoodsMakerCd;
        private Label lb_AcceptAnOrderCnt;
        private Label lb_BOCode;
        private Label lb_UOERemark1;
        private Label lb_ErrorContents;
        private GroupFooter OnlineNoFooter;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private GroupHeader TitleHeader;
        private GroupFooter TitleFooter;
        private GroupHeader GrandTotalHeader;
        private GroupFooter GrandTotalFooter;
        private GroupHeader UOESupplierHeader;
        private GroupFooter UOESupplierFooter;
        private Label lb_UOESupplier;
        private TextBox UOESupplierCd;
        private TextBox UOESupplierName;
        private SubReport Header_SubReport;
        private SubReport Footer_SubReport;

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
        private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox GoodsNo;
        private DataDynamics.ActiveReports.TextBox GoodsName;
        private DataDynamics.ActiveReports.TextBox GoodsMakerCd;
        private DataDynamics.ActiveReports.TextBox AcceptAnOrderCnt;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE02012P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.AcceptAnOrderCnt = new DataDynamics.ActiveReports.TextBox();
            this.BOCode = new DataDynamics.ActiveReports.TextBox();
            this.UOERemark1 = new DataDynamics.ActiveReports.TextBox();
            this.ErrorContents = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.tb_SystemDivName = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.OnlineNoHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.OnlineNo = new DataDynamics.ActiveReports.TextBox();
            this.lb_UOESalesOrder = new DataDynamics.ActiveReports.Label();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.lb_GoodsMakerCd = new DataDynamics.ActiveReports.Label();
            this.lb_AcceptAnOrderCnt = new DataDynamics.ActiveReports.Label();
            this.lb_BOCode = new DataDynamics.ActiveReports.Label();
            this.lb_UOERemark1 = new DataDynamics.ActiveReports.Label();
            this.lb_ErrorContents = new DataDynamics.ActiveReports.Label();
            this.OnlineNoFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.UOESupplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.lb_UOESupplier = new DataDynamics.ActiveReports.Label();
            this.UOESupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.UOESupplierName = new DataDynamics.ActiveReports.TextBox();
            this.UOESupplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOERemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorContents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SystemDivName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_UOESalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_AcceptAnOrderCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_BOCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_UOERemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ErrorContents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_UOESupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsNo,
            this.GoodsName,
            this.GoodsMakerCd,
            this.AcceptAnOrderCnt,
            this.BOCode,
            this.UOERemark1,
            this.ErrorContents,
            this.line3});
            this.Detail.Height = 0.21875F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // GoodsNo
            // 
            this.GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.125F;
            this.GoodsNo.Left = 0F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.0625F;
            this.GoodsNo.Width = 1.375F;
            // 
            // GoodsName
            // 
            this.GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.125F;
            this.GoodsName.Left = 1.4375F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 1.1875F;
            // 
            // GoodsMakerCd
            // 
            this.GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.DataField = "GoodsMakerCd";
            this.GoodsMakerCd.Height = 0.125F;
            this.GoodsMakerCd.Left = 2.6875F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0.0625F;
            this.GoodsMakerCd.Width = 0.375F;
            // 
            // AcceptAnOrderCnt
            // 
            this.AcceptAnOrderCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.Border.RightColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.Border.TopColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.DataField = "AcceptAnOrderCnt";
            this.AcceptAnOrderCnt.Height = 0.125F;
            this.AcceptAnOrderCnt.Left = 3.125F;
            this.AcceptAnOrderCnt.MultiLine = false;
            this.AcceptAnOrderCnt.Name = "AcceptAnOrderCnt";
            this.AcceptAnOrderCnt.OutputFormat = resources.GetString("AcceptAnOrderCnt.OutputFormat");
            this.AcceptAnOrderCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AcceptAnOrderCnt.Text = "123";
            this.AcceptAnOrderCnt.Top = 0.0625F;
            this.AcceptAnOrderCnt.Width = 0.3125F;
            // 
            // BOCode
            // 
            this.BOCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BOCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BOCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOCode.Border.RightColor = System.Drawing.Color.Black;
            this.BOCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOCode.Border.TopColor = System.Drawing.Color.Black;
            this.BOCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOCode.DataField = "BOCode";
            this.BOCode.Height = 0.125F;
            this.BOCode.Left = 3.5625F;
            this.BOCode.MultiLine = false;
            this.BOCode.Name = "BOCode";
            this.BOCode.OutputFormat = resources.GetString("BOCode.OutputFormat");
            this.BOCode.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.BOCode.Text = "1";
            this.BOCode.Top = 0.0625F;
            this.BOCode.Width = 0.1875F;
            // 
            // UOERemark1
            // 
            this.UOERemark1.Border.BottomColor = System.Drawing.Color.Black;
            this.UOERemark1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark1.Border.LeftColor = System.Drawing.Color.Black;
            this.UOERemark1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark1.Border.RightColor = System.Drawing.Color.Black;
            this.UOERemark1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark1.Border.TopColor = System.Drawing.Color.Black;
            this.UOERemark1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark1.DataField = "UOERemark1";
            this.UOERemark1.Height = 0.125F;
            this.UOERemark1.Left = 3.875F;
            this.UOERemark1.MultiLine = false;
            this.UOERemark1.Name = "UOERemark1";
            this.UOERemark1.OutputFormat = resources.GetString("UOERemark1.OutputFormat");
            this.UOERemark1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UOERemark1.Text = "12345678901234567890";
            this.UOERemark1.Top = 0.0625F;
            this.UOERemark1.Width = 1.1875F;
            // 
            // ErrorContents
            // 
            this.ErrorContents.Border.BottomColor = System.Drawing.Color.Black;
            this.ErrorContents.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErrorContents.Border.LeftColor = System.Drawing.Color.Black;
            this.ErrorContents.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErrorContents.Border.RightColor = System.Drawing.Color.Black;
            this.ErrorContents.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErrorContents.Border.TopColor = System.Drawing.Color.Black;
            this.ErrorContents.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErrorContents.DataField = "ErrorContents";
            this.ErrorContents.Height = 0.125F;
            this.ErrorContents.Left = 5.125F;
            this.ErrorContents.MultiLine = false;
            this.ErrorContents.Name = "ErrorContents";
            this.ErrorContents.OutputFormat = resources.GetString("ErrorContents.OutputFormat");
            this.ErrorContents.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.ErrorContents.Text = "12345678901234567890";
            this.ErrorContents.Top = 0.0625F;
            this.ErrorContents.Width = 1.1875F;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0.1875F;
            this.line3.Width = 10.81F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.81F;
            this.line3.Y1 = 0.1875F;
            this.line3.Y2 = 0.1875F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.Line1,
            this.tb_PrintTime,
            this.tb_ReportTitle,
            this.tb_SystemDivName,
            this.label1,
            this.label4});
            this.PageHeader.Height = 0.28125F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.15625F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 8.1875F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0625F;
            this.Label3.Width = 0.625F;
            // 
            // tb_PrintDate
            // 
            this.tb_PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.CanShrink = true;
            this.tb_PrintDate.Height = 0.1875F;
            this.tb_PrintDate.Left = 8.75F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "2008/01/01";
            this.tb_PrintDate.Top = 0.0625F;
            this.tb_PrintDate.Width = 0.625F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.15625F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.9375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
            // 
            // tb_PrintPage
            // 
            this.tb_PrintPage.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.CanShrink = true;
            this.tb_PrintPage.Height = 0.15625F;
            this.tb_PrintPage.Left = 10.4375F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.0625F;
            this.tb_PrintPage.Width = 0.28125F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.25F;
            this.Line1.Width = 10.8125F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8125F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.25F;
            // 
            // tb_PrintTime
            // 
            this.tb_PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Height = 0.125F;
            this.tb_PrintTime.Left = 9.375F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.tb_PrintTime.Text = "01:01";
            this.tb_PrintTime.Top = 0.0625F;
            this.tb_PrintTime.Width = 0.375F;
            // 
            // tb_ReportTitle
            // 
            this.tb_ReportTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Height = 0.21875F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.25F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "回線エラーリスト";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 1.90625F;
            // 
            // tb_SystemDivName
            // 
            this.tb_SystemDivName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SystemDivName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SystemDivName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SystemDivName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SystemDivName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SystemDivName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SystemDivName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SystemDivName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SystemDivName.DataField = "SystemDivName";
            this.tb_SystemDivName.Height = 0.16F;
            this.tb_SystemDivName.Left = 2.0625F;
            this.tb_SystemDivName.Name = "tb_SystemDivName";
            this.tb_SystemDivName.Style = "text-align: center; font-size: 8pt; vertical-align: bottom; ";
            this.tb_SystemDivName.Text = "あいうえ";
            this.tb_SystemDivName.Top = 0.0625F;
            this.tb_SystemDivName.Width = 0.5F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.16F;
            this.label1.HyperLink = null;
            this.label1.Left = 1.9375F;
            this.label1.Name = "label1";
            this.label1.Style = "text-align: right; font-size: 8pt; vertical-align: bottom; ";
            this.label1.Text = "[";
            this.label1.Top = 0.0625F;
            this.label1.Width = 0.125F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.16F;
            this.label4.HyperLink = null;
            this.label4.Left = 2.5625F;
            this.label4.Name = "label4";
            this.label4.Style = "text-align: left; font-size: 8pt; vertical-align: bottom; ";
            this.label4.Text = "]";
            this.label4.Top = 0.0625F;
            this.label4.Width = 0.125F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2291667F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Footer_SubReport
            // 
            this.Footer_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.CloseBorder = false;
            this.Footer_SubReport.Height = 0.239F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.8F;
            // 
            // OnlineNoHeader
            // 
            this.OnlineNoHeader.CanShrink = true;
            this.OnlineNoHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.OnlineNo,
            this.lb_UOESalesOrder,
            this.line5,
            this.lb_GoodsNo,
            this.line6,
            this.lb_GoodsName,
            this.lb_GoodsMakerCd,
            this.lb_AcceptAnOrderCnt,
            this.lb_BOCode,
            this.lb_UOERemark1,
            this.lb_ErrorContents});
            this.OnlineNoHeader.DataField = "OnlineNo";
            this.OnlineNoHeader.Height = 0.3229167F;
            this.OnlineNoHeader.Name = "OnlineNoHeader";
            // 
            // OnlineNo
            // 
            this.OnlineNo.Border.BottomColor = System.Drawing.Color.Black;
            this.OnlineNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo.Border.LeftColor = System.Drawing.Color.Black;
            this.OnlineNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo.Border.RightColor = System.Drawing.Color.Black;
            this.OnlineNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo.Border.TopColor = System.Drawing.Color.Black;
            this.OnlineNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo.DataField = "OnlineNo";
            this.OnlineNo.Height = 0.125F;
            this.OnlineNo.Left = 0.625F;
            this.OnlineNo.MultiLine = false;
            this.OnlineNo.Name = "OnlineNo";
            this.OnlineNo.OutputFormat = resources.GetString("OnlineNo.OutputFormat");
            this.OnlineNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.OnlineNo.Text = "123456789";
            this.OnlineNo.Top = 0F;
            this.OnlineNo.Width = 0.5625F;
            // 
            // lb_UOESalesOrder
            // 
            this.lb_UOESalesOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_UOESalesOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOESalesOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_UOESalesOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOESalesOrder.Border.RightColor = System.Drawing.Color.Black;
            this.lb_UOESalesOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOESalesOrder.Border.TopColor = System.Drawing.Color.Black;
            this.lb_UOESalesOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOESalesOrder.Height = 0.125F;
            this.lb_UOESalesOrder.HyperLink = "";
            this.lb_UOESalesOrder.Left = 0F;
            this.lb_UOESalesOrder.MultiLine = false;
            this.lb_UOESalesOrder.Name = "lb_UOESalesOrder";
            this.lb_UOESalesOrder.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_UOESalesOrder.Text = "呼出番号 ：";
            this.lb_UOESalesOrder.Top = 0F;
            this.lb_UOESalesOrder.Width = 0.6875F;
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0F;
            this.line5.Left = 0F;
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0.125F;
            this.line5.Width = 10.8125F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8125F;
            this.line5.Y1 = 0.125F;
            this.line5.Y2 = 0.125F;
            // 
            // lb_GoodsNo
            // 
            this.lb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.lb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.lb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsNo.Height = 0.125F;
            this.lb_GoodsNo.HyperLink = "";
            this.lb_GoodsNo.Left = 0F;
            this.lb_GoodsNo.MultiLine = false;
            this.lb_GoodsNo.Name = "lb_GoodsNo";
            this.lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lb_GoodsNo.Text = "品番";
            this.lb_GoodsNo.Top = 0.1875F;
            this.lb_GoodsNo.Width = 1.375F;
            // 
            // line6
            // 
            this.line6.Border.BottomColor = System.Drawing.Color.Black;
            this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.LeftColor = System.Drawing.Color.Black;
            this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.RightColor = System.Drawing.Color.Black;
            this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.TopColor = System.Drawing.Color.Black;
            this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Height = 0F;
            this.line6.Left = 0F;
            this.line6.LineWeight = 2F;
            this.line6.Name = "line6";
            this.line6.Top = 0.3125F;
            this.line6.Width = 10.8125F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0.3125F;
            this.line6.Y2 = 0.3125F;
            // 
            // lb_GoodsName
            // 
            this.lb_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.lb_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.lb_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsName.Height = 0.125F;
            this.lb_GoodsName.HyperLink = "";
            this.lb_GoodsName.Left = 1.4375F;
            this.lb_GoodsName.MultiLine = false;
            this.lb_GoodsName.Name = "lb_GoodsName";
            this.lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lb_GoodsName.Text = "品名";
            this.lb_GoodsName.Top = 0.1875F;
            this.lb_GoodsName.Width = 1.1875F;
            // 
            // lb_GoodsMakerCd
            // 
            this.lb_GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.lb_GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.lb_GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsMakerCd.Height = 0.125F;
            this.lb_GoodsMakerCd.HyperLink = "";
            this.lb_GoodsMakerCd.Left = 2.6875F;
            this.lb_GoodsMakerCd.MultiLine = false;
            this.lb_GoodsMakerCd.Name = "lb_GoodsMakerCd";
            this.lb_GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lb_GoodsMakerCd.Text = "ﾒｰｶｰ";
            this.lb_GoodsMakerCd.Top = 0.1875F;
            this.lb_GoodsMakerCd.Width = 0.375F;
            // 
            // lb_AcceptAnOrderCnt
            // 
            this.lb_AcceptAnOrderCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_AcceptAnOrderCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_AcceptAnOrderCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_AcceptAnOrderCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_AcceptAnOrderCnt.Border.RightColor = System.Drawing.Color.Black;
            this.lb_AcceptAnOrderCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_AcceptAnOrderCnt.Border.TopColor = System.Drawing.Color.Black;
            this.lb_AcceptAnOrderCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_AcceptAnOrderCnt.Height = 0.125F;
            this.lb_AcceptAnOrderCnt.HyperLink = "";
            this.lb_AcceptAnOrderCnt.Left = 3.125F;
            this.lb_AcceptAnOrderCnt.MultiLine = false;
            this.lb_AcceptAnOrderCnt.Name = "lb_AcceptAnOrderCnt";
            this.lb_AcceptAnOrderCnt.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lb_AcceptAnOrderCnt.Text = "発注数";
            this.lb_AcceptAnOrderCnt.Top = 0.1875F;
            this.lb_AcceptAnOrderCnt.Width = 0.375F;
            // 
            // lb_BOCode
            // 
            this.lb_BOCode.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_BOCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_BOCode.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_BOCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_BOCode.Border.RightColor = System.Drawing.Color.Black;
            this.lb_BOCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_BOCode.Border.TopColor = System.Drawing.Color.Black;
            this.lb_BOCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_BOCode.Height = 0.125F;
            this.lb_BOCode.HyperLink = "";
            this.lb_BOCode.Left = 3.5625F;
            this.lb_BOCode.MultiLine = false;
            this.lb_BOCode.Name = "lb_BOCode";
            this.lb_BOCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lb_BOCode.Text = "B/O";
            this.lb_BOCode.Top = 0.1875F;
            this.lb_BOCode.Width = 0.25F;
            // 
            // lb_UOERemark1
            // 
            this.lb_UOERemark1.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_UOERemark1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOERemark1.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_UOERemark1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOERemark1.Border.RightColor = System.Drawing.Color.Black;
            this.lb_UOERemark1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOERemark1.Border.TopColor = System.Drawing.Color.Black;
            this.lb_UOERemark1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOERemark1.Height = 0.125F;
            this.lb_UOERemark1.HyperLink = "";
            this.lb_UOERemark1.Left = 3.875F;
            this.lb_UOERemark1.MultiLine = false;
            this.lb_UOERemark1.Name = "lb_UOERemark1";
            this.lb_UOERemark1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lb_UOERemark1.Text = "リマーク";
            this.lb_UOERemark1.Top = 0.1875F;
            this.lb_UOERemark1.Width = 1.1875F;
            // 
            // lb_ErrorContents
            // 
            this.lb_ErrorContents.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_ErrorContents.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ErrorContents.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_ErrorContents.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ErrorContents.Border.RightColor = System.Drawing.Color.Black;
            this.lb_ErrorContents.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ErrorContents.Border.TopColor = System.Drawing.Color.Black;
            this.lb_ErrorContents.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ErrorContents.Height = 0.125F;
            this.lb_ErrorContents.HyperLink = "";
            this.lb_ErrorContents.Left = 5.125F;
            this.lb_ErrorContents.MultiLine = false;
            this.lb_ErrorContents.Name = "lb_ErrorContents";
            this.lb_ErrorContents.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lb_ErrorContents.Text = "エラー内容";
            this.lb_ErrorContents.Top = 0.1875F;
            this.lb_ErrorContents.Width = 1.1875F;
            // 
            // OnlineNoFooter
            // 
            this.OnlineNoFooter.Height = 0.01041667F;
            this.OnlineNoFooter.Name = "OnlineNoFooter";
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.5833333F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Header_SubReport
            // 
            this.Header_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.CloseBorder = false;
            this.Header_SubReport.Height = 0.5F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0.625F;
            this.Header_SubReport.Width = 10.8F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Height = 0F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // GrandTotalHeader
            // 
            this.GrandTotalHeader.CanShrink = true;
            this.GrandTotalHeader.Height = 0F;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Height = 0.02083333F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // UOESupplierHeader
            // 
            this.UOESupplierHeader.CanGrow = false;
            this.UOESupplierHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lb_UOESupplier,
            this.UOESupplierCd,
            this.UOESupplierName});
            this.UOESupplierHeader.DataField = "UOESupplierCd";
            this.UOESupplierHeader.Height = 0.1354167F;
            this.UOESupplierHeader.Name = "UOESupplierHeader";
            this.UOESupplierHeader.Format += new System.EventHandler(this.UOESupplierHeader_Format);
            // 
            // lb_UOESupplier
            // 
            this.lb_UOESupplier.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_UOESupplier.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOESupplier.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_UOESupplier.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOESupplier.Border.RightColor = System.Drawing.Color.Black;
            this.lb_UOESupplier.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOESupplier.Border.TopColor = System.Drawing.Color.Black;
            this.lb_UOESupplier.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_UOESupplier.Height = 0.125F;
            this.lb_UOESupplier.HyperLink = "";
            this.lb_UOESupplier.Left = 0F;
            this.lb_UOESupplier.MultiLine = false;
            this.lb_UOESupplier.Name = "lb_UOESupplier";
            this.lb_UOESupplier.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_UOESupplier.Text = "発注先　 ：";
            this.lb_UOESupplier.Top = 0.01F;
            this.lb_UOESupplier.Width = 0.6875F;
            // 
            // UOESupplierCd
            // 
            this.UOESupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.DataField = "UOESupplierCd";
            this.UOESupplierCd.Height = 0.15625F;
            this.UOESupplierCd.Left = 0.625F;
            this.UOESupplierCd.MultiLine = false;
            this.UOESupplierCd.Name = "UOESupplierCd";
            this.UOESupplierCd.OutputFormat = resources.GetString("UOESupplierCd.OutputFormat");
            this.UOESupplierCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UOESupplierCd.Text = "123456";
            this.UOESupplierCd.Top = 0.01F;
            this.UOESupplierCd.Width = 0.375F;
            // 
            // UOESupplierName
            // 
            this.UOESupplierName.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.Border.RightColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.Border.TopColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.DataField = "UOESupplierName";
            this.UOESupplierName.Height = 0.15625F;
            this.UOESupplierName.Left = 1.125F;
            this.UOESupplierName.MultiLine = false;
            this.UOESupplierName.Name = "UOESupplierName";
            this.UOESupplierName.OutputFormat = resources.GetString("UOESupplierName.OutputFormat");
            this.UOESupplierName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UOESupplierName.Text = "あいうえおかきくけこ";
            this.UOESupplierName.Top = 0.01F;
            this.UOESupplierName.Width = 1.1875F;
            // 
            // UOESupplierFooter
            // 
            this.UOESupplierFooter.Height = 0.01041667F;
            this.UOESupplierFooter.Name = "UOESupplierFooter";
            // 
            // PMUOE02012P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.268056F;
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.UOESupplierHeader);
            this.Sections.Add(this.OnlineNoHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.OnlineNoFooter);
            this.Sections.Add(this.UOESupplierFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.PageEnd += new System.EventHandler(this.PMUOE02012P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMUOE02012P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOERemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorContents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SystemDivName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_UOESalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_AcceptAnOrderCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_BOCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_UOERemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ErrorContents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_UOESupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
     }
}
