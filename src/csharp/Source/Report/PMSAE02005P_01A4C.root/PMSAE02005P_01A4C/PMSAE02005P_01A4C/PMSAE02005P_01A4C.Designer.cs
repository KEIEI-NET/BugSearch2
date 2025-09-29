namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMSAE02005P_01A4C の概要の説明です。
    /// </summary>
    partial class PMSAE02005P_01A4C
    {
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.PageFooter PageFooter;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMSAE02005P_01A4C));
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.DATE = new DataDynamics.ActiveReports.TextBox();
            this.TIME = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.bLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.bLGoodsHalfName = new DataDynamics.ActiveReports.TextBox();
            this.aBGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bLGoodsHalfName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line1,
            this.tb_ReportTitle,
            this.Label3,
            this.DATE,
            this.TIME,
            this.Label2,
            this.tb_PrintPage,
            this.Header_SubReport,
            this.line2});
            this.PageHeader.Height = 0.48F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.Line1.Top = 0.2620833F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.2620833F;
            this.Line1.Y2 = 0.2620833F;
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
            this.tb_ReportTitle.Height = 0.25F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.25F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "オートバックス商品コード変換マスタ";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 3.6875F;
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
            this.Label3.Height = 0.1875F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.6875F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.125F;
            this.Label3.Width = 0.625F;
            // 
            // DATE
            // 
            this.DATE.Border.BottomColor = System.Drawing.Color.Black;
            this.DATE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.LeftColor = System.Drawing.Color.Black;
            this.DATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.RightColor = System.Drawing.Color.Black;
            this.DATE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.TopColor = System.Drawing.Color.Black;
            this.DATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.CanShrink = true;
            this.DATE.Height = 0.1875F;
            this.DATE.Left = 8.3125F;
            this.DATE.MultiLine = false;
            this.DATE.Name = "DATE";
            this.DATE.OutputFormat = resources.GetString("DATE.OutputFormat");
            this.DATE.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.DATE.Text = null;
            this.DATE.Top = 0.125F;
            this.DATE.Width = 0.9375F;
            // 
            // TIME
            // 
            this.TIME.Border.BottomColor = System.Drawing.Color.Black;
            this.TIME.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.LeftColor = System.Drawing.Color.Black;
            this.TIME.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.RightColor = System.Drawing.Color.Black;
            this.TIME.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.TopColor = System.Drawing.Color.Black;
            this.TIME.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Height = 0.1875F;
            this.TIME.Left = 9.25F;
            this.TIME.Name = "TIME";
            this.TIME.Style = "font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.TIME.Text = null;
            this.TIME.Top = 0.125F;
            this.TIME.Width = 0.5F;
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
            this.Label2.Left = 9.875F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.125F;
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
            this.tb_PrintPage.Left = 10.375F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.125F;
            this.tb_PrintPage.Width = 0.28125F;
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
            this.Header_SubReport.Height = 0.17F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0.2916667F;
            this.Header_SubReport.Width = 11.188F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 2F;
            this.line2.Name = "line2";
            this.line2.Top = 0.46875F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0.46875F;
            this.line2.Y2 = 0.46875F;
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnCount = 3;
            this.Detail.ColumnSpacing = 0.65F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.bLGoodsCode,
            this.bLGoodsHalfName,
            this.aBGoodsCode,
            this.line4});
            this.Detail.Height = 0.1666667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // bLGoodsCode
            // 
            this.bLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.bLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.bLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.bLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.bLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bLGoodsCode.DataField = "BLGoodsCode";
            this.bLGoodsCode.Height = 0.15F;
            this.bLGoodsCode.Left = 0F;
            this.bLGoodsCode.MultiLine = false;
            this.bLGoodsCode.Name = "bLGoodsCode";
            this.bLGoodsCode.OutputFormat = resources.GetString("bLGoodsCode.OutputFormat");
            this.bLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.bLGoodsCode.Text = "99999";
            this.bLGoodsCode.Top = 0F;
            this.bLGoodsCode.Width = 0.3125F;
            // 
            // bLGoodsHalfName
            // 
            this.bLGoodsHalfName.Border.BottomColor = System.Drawing.Color.Black;
            this.bLGoodsHalfName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bLGoodsHalfName.Border.LeftColor = System.Drawing.Color.Black;
            this.bLGoodsHalfName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bLGoodsHalfName.Border.RightColor = System.Drawing.Color.Black;
            this.bLGoodsHalfName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bLGoodsHalfName.Border.TopColor = System.Drawing.Color.Black;
            this.bLGoodsHalfName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bLGoodsHalfName.DataField = "BLGoodsHalfName";
            this.bLGoodsHalfName.Height = 0.15F;
            this.bLGoodsHalfName.Left = 0.625F;
            this.bLGoodsHalfName.MultiLine = false;
            this.bLGoodsHalfName.Name = "bLGoodsHalfName";
            this.bLGoodsHalfName.OutputFormat = resources.GetString("bLGoodsHalfName.OutputFormat");
            this.bLGoodsHalfName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.bLGoodsHalfName.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            this.bLGoodsHalfName.Top = 0F;
            this.bLGoodsHalfName.Width = 1.72F;
            // 
            // aBGoodsCode
            // 
            this.aBGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.aBGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.aBGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.aBGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.aBGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.aBGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.aBGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.aBGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.aBGoodsCode.DataField = "ABGoodsCode";
            this.aBGoodsCode.Height = 0.15F;
            this.aBGoodsCode.Left = 2.624833F;
            this.aBGoodsCode.MultiLine = false;
            this.aBGoodsCode.Name = "aBGoodsCode";
            this.aBGoodsCode.OutputFormat = resources.GetString("aBGoodsCode.OutputFormat");
            this.aBGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.aBGoodsCode.Text = "99999999";
            this.aBGoodsCode.Top = 0F;
            this.aBGoodsCode.Width = 0.480315F;
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0F;
            this.line4.Left = 0F;
            this.line4.LineWeight = 2F;
            this.line4.Name = "line4";
            this.line4.Top = 0.15625F;
            this.line4.Width = 3.3F;
            this.line4.X1 = 0F;
            this.line4.X2 = 3.3F;
            this.line4.Y1 = 0.15625F;
            this.line4.Y2 = 0.15625F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.25F;
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
            this.Footer_SubReport.Height = 0.184F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.813F;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label4,
            this.label5,
            this.line3});
            this.TitleHeader.Height = 0.2604167F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.All;
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
            this.label1.Height = 0.17F;
            this.label1.HyperLink = "";
            this.label1.Left = 0F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "BLｺｰﾄﾞ";
            this.label1.Top = 0.063F;
            this.label1.Width = 0.375F;
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
            this.label4.Height = 0.17F;
            this.label4.HyperLink = "";
            this.label4.Left = 0.625F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "BLｺｰﾄﾞ名";
            this.label4.Top = 0.063F;
            this.label4.Width = 1.72F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.17F;
            this.label5.HyperLink = "";
            this.label5.Left = 2.625F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "商品ｺｰﾄﾞ";
            this.label5.Top = 0.063F;
            this.label5.Width = 0.5F;
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
            this.line3.Height = 0.002083406F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0.2499999F;
            this.line3.Width = 3.3F;
            this.line3.X1 = 0F;
            this.line3.X2 = 3.3F;
            this.line3.Y1 = 0.2499999F;
            this.line3.Y2 = 0.2520833F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            // 
            // PMSAE02005P_01A4C
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
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: \"ＭＳ 明朝\"; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ddo-char-set: 128; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ddo-char-set: 128; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; font-style: italic; ddo-char-set: 204; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMSAE02005P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bLGoodsHalfName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label tb_ReportTitle;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.TextBox DATE;
        private DataDynamics.ActiveReports.TextBox TIME;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.TextBox tb_PrintPage;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.TextBox bLGoodsCode;
        private DataDynamics.ActiveReports.TextBox bLGoodsHalfName;
        private DataDynamics.ActiveReports.TextBox aBGoodsCode;
        private DataDynamics.ActiveReports.Line line3;
        private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.Line line4;
        private DataDynamics.ActiveReports.SubReport Footer_SubReport;
    }
}
