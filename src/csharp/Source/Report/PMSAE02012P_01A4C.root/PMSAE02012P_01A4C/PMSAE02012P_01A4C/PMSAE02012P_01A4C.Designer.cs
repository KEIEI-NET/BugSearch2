namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMSAE02005P_01A4C の概要の説明です。
    /// </summary>
    partial class PMSAE02012P_01A4C
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMSAE02012P_01A4C));
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.DATE = new DataDynamics.ActiveReports.TextBox();
            this.TIME = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.CustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.SlipCountSum = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.SalesSupplierMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.PureCount = new DataDynamics.ActiveReports.TextBox();
            this.PureSalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.PureSupplierMoney = new DataDynamics.ActiveReports.TextBox();
            this.PureDefferent = new DataDynamics.ActiveReports.TextBox();
            this.PriCount = new DataDynamics.ActiveReports.TextBox();
            this.PriSalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.PriSupplierMoney = new DataDynamics.ActiveReports.TextBox();
            this.PriDefferent = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.Lable_PureDefferent = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.Lable_PriDefferent = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Extra_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionCodeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.SectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.SectionCodeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.SCustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.SSlipCountSum = new DataDynamics.ActiveReports.TextBox();
            this.SSalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.SSalesSupplierMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.SPureCount = new DataDynamics.ActiveReports.TextBox();
            this.SPureSalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.SPureDefferent = new DataDynamics.ActiveReports.TextBox();
            this.SPriCount = new DataDynamics.ActiveReports.TextBox();
            this.SPriSalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SPriSupplierMoney = new DataDynamics.ActiveReports.TextBox();
            this.SPriDefferent = new DataDynamics.ActiveReports.TextBox();
            this.GrandHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.APriDefferent = new DataDynamics.ActiveReports.TextBox();
            this.APriSupplierMoney = new DataDynamics.ActiveReports.TextBox();
            this.APriSalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.APriCount = new DataDynamics.ActiveReports.TextBox();
            this.APureDefferent = new DataDynamics.ActiveReports.TextBox();
            this.APureSupplierMoney = new DataDynamics.ActiveReports.TextBox();
            this.APureSalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.APureCount = new DataDynamics.ActiveReports.TextBox();
            this.ASalesSupplierMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.ASalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.ASlipCountSum = new DataDynamics.ActiveReports.TextBox();
            this.ACustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSupplierMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSupplierMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureDefferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriSalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriSupplierMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriDefferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lable_PureDefferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lable_PriDefferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SCustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSlipCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSalesSupplierMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPureCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPureSalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPureDefferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPriCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPriSalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPriSupplierMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPriDefferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APriDefferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APriSupplierMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APriSalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APriCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureDefferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureSupplierMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureSalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ASalesSupplierMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ASalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ASlipCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACustomerSnm)).BeginInit();
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
            this.tb_PrintPage});
            this.PageHeader.Height = 0.3958333F;
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
            this.Line1.Top = 0.2604167F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.2604167F;
            this.Line1.Y2 = 0.2604167F;
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
            this.tb_ReportTitle.Text = "テキスト確認リスト";
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
            this.Label3.Left = 7.625F;
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
            this.DATE.Left = 8.25F;
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
            this.TIME.Left = 9.1875F;
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
            this.Label2.Left = 9.8125F;
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
            this.tb_PrintPage.Left = 10.3125F;
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
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0.65F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CustomerSnm,
            this.CustomerCode,
            this.SlipCountSum,
            this.SalesMoneySum,
            this.SalesSupplierMoneySum,
            this.PureCount,
            this.PureSalesMoneyTaxExc,
            this.PureSupplierMoney,
            this.PureDefferent,
            this.PriCount,
            this.PriSalesMoneyTaxExc,
            this.PriSupplierMoney,
            this.PriDefferent,
            this.line4});
            this.Detail.Height = 0.2083333F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // CustomerSnm
            // 
            this.CustomerSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.DataField = "CustomerSnm";
            this.CustomerSnm.Height = 0.1875F;
            this.CustomerSnm.Left = 0.5625F;
            this.CustomerSnm.MultiLine = false;
            this.CustomerSnm.Name = "CustomerSnm";
            this.CustomerSnm.OutputFormat = resources.GetString("CustomerSnm.OutputFormat");
            this.CustomerSnm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.CustomerSnm.Text = "あいうえおかきくけこあい";
            this.CustomerSnm.Top = 0F;
            this.CustomerSnm.Width = 1.2F;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.DataField = "CustomerCode";
            this.CustomerCode.Height = 0.1875F;
            this.CustomerCode.Left = 0F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: bottom" +
                "; ";
            this.CustomerCode.Text = "12345678";
            this.CustomerCode.Top = 0F;
            this.CustomerCode.Width = 0.5F;
            // 
            // SlipCountSum
            // 
            this.SlipCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.SlipCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.SlipCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipCountSum.DataField = "SlipCountSum";
            this.SlipCountSum.Height = 0.1875F;
            this.SlipCountSum.Left = 1.895833F;
            this.SlipCountSum.MultiLine = false;
            this.SlipCountSum.Name = "SlipCountSum";
            this.SlipCountSum.OutputFormat = resources.GetString("SlipCountSum.OutputFormat");
            this.SlipCountSum.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.SlipCountSum.Text = "ZZZ,ZZ9";
            this.SlipCountSum.Top = 0F;
            this.SlipCountSum.Width = 0.5F;
            // 
            // SalesMoneySum
            // 
            this.SalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneySum.DataField = "SalesMoneySum";
            this.SalesMoneySum.Height = 0.1875F;
            this.SalesMoneySum.Left = 2.5F;
            this.SalesMoneySum.MultiLine = false;
            this.SalesMoneySum.Name = "SalesMoneySum";
            this.SalesMoneySum.OutputFormat = resources.GetString("SalesMoneySum.OutputFormat");
            this.SalesMoneySum.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.SalesMoneySum.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SalesMoneySum.Top = 0F;
            this.SalesMoneySum.Width = 0.8125F;
            // 
            // SalesSupplierMoneySum
            // 
            this.SalesSupplierMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSupplierMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSupplierMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSupplierMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSupplierMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSupplierMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSupplierMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSupplierMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSupplierMoneySum.DataField = "SalesSupplierMoneySum";
            this.SalesSupplierMoneySum.Height = 0.1875F;
            this.SalesSupplierMoneySum.Left = 3.458333F;
            this.SalesSupplierMoneySum.MultiLine = false;
            this.SalesSupplierMoneySum.Name = "SalesSupplierMoneySum";
            this.SalesSupplierMoneySum.OutputFormat = resources.GetString("SalesSupplierMoneySum.OutputFormat");
            this.SalesSupplierMoneySum.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.SalesSupplierMoneySum.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SalesSupplierMoneySum.Top = 0F;
            this.SalesSupplierMoneySum.Width = 0.8125F;
            // 
            // PureCount
            // 
            this.PureCount.Border.BottomColor = System.Drawing.Color.Black;
            this.PureCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCount.Border.LeftColor = System.Drawing.Color.Black;
            this.PureCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCount.Border.RightColor = System.Drawing.Color.Black;
            this.PureCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCount.Border.TopColor = System.Drawing.Color.Black;
            this.PureCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCount.DataField = "PureCount";
            this.PureCount.Height = 0.1875F;
            this.PureCount.Left = 4.458333F;
            this.PureCount.MultiLine = false;
            this.PureCount.Name = "PureCount";
            this.PureCount.OutputFormat = resources.GetString("PureCount.OutputFormat");
            this.PureCount.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.PureCount.Text = "ZZZ,ZZ9";
            this.PureCount.Top = 0F;
            this.PureCount.Width = 0.4375F;
            // 
            // PureSalesMoneyTaxExc
            // 
            this.PureSalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.PureSalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.PureSalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.PureSalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.PureSalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesMoneyTaxExc.DataField = "PureSalesMoneyTaxExc";
            this.PureSalesMoneyTaxExc.Height = 0.1875F;
            this.PureSalesMoneyTaxExc.Left = 5.03125F;
            this.PureSalesMoneyTaxExc.MultiLine = false;
            this.PureSalesMoneyTaxExc.Name = "PureSalesMoneyTaxExc";
            this.PureSalesMoneyTaxExc.OutputFormat = resources.GetString("PureSalesMoneyTaxExc.OutputFormat");
            this.PureSalesMoneyTaxExc.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.PureSalesMoneyTaxExc.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.PureSalesMoneyTaxExc.Top = 0F;
            this.PureSalesMoneyTaxExc.Width = 0.8125F;
            // 
            // PureSupplierMoney
            // 
            this.PureSupplierMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.PureSupplierMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSupplierMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.PureSupplierMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSupplierMoney.Border.RightColor = System.Drawing.Color.Black;
            this.PureSupplierMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSupplierMoney.Border.TopColor = System.Drawing.Color.Black;
            this.PureSupplierMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSupplierMoney.DataField = "PureSupplierMoney";
            this.PureSupplierMoney.Height = 0.1875F;
            this.PureSupplierMoney.Left = 5.864583F;
            this.PureSupplierMoney.MultiLine = false;
            this.PureSupplierMoney.Name = "PureSupplierMoney";
            this.PureSupplierMoney.OutputFormat = resources.GetString("PureSupplierMoney.OutputFormat");
            this.PureSupplierMoney.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.PureSupplierMoney.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.PureSupplierMoney.Top = 0F;
            this.PureSupplierMoney.Width = 0.8125F;
            // 
            // PureDefferent
            // 
            this.PureDefferent.Border.BottomColor = System.Drawing.Color.Black;
            this.PureDefferent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureDefferent.Border.LeftColor = System.Drawing.Color.Black;
            this.PureDefferent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureDefferent.Border.RightColor = System.Drawing.Color.Black;
            this.PureDefferent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureDefferent.Border.TopColor = System.Drawing.Color.Black;
            this.PureDefferent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureDefferent.DataField = "PureDefferent";
            this.PureDefferent.Height = 0.1875F;
            this.PureDefferent.Left = 6.708333F;
            this.PureDefferent.MultiLine = false;
            this.PureDefferent.Name = "PureDefferent";
            this.PureDefferent.OutputFormat = resources.GetString("PureDefferent.OutputFormat");
            this.PureDefferent.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.PureDefferent.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.PureDefferent.Top = 0F;
            this.PureDefferent.Width = 0.8125F;
            // 
            // PriCount
            // 
            this.PriCount.Border.BottomColor = System.Drawing.Color.Black;
            this.PriCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriCount.Border.LeftColor = System.Drawing.Color.Black;
            this.PriCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriCount.Border.RightColor = System.Drawing.Color.Black;
            this.PriCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriCount.Border.TopColor = System.Drawing.Color.Black;
            this.PriCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriCount.DataField = "PriCount";
            this.PriCount.Height = 0.1875F;
            this.PriCount.Left = 7.75F;
            this.PriCount.MultiLine = false;
            this.PriCount.Name = "PriCount";
            this.PriCount.OutputFormat = resources.GetString("PriCount.OutputFormat");
            this.PriCount.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.PriCount.Text = "ZZZ,ZZ9";
            this.PriCount.Top = 0F;
            this.PriCount.Width = 0.4375F;
            // 
            // PriSalesMoneyTaxExc
            // 
            this.PriSalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.PriSalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriSalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.PriSalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriSalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.PriSalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriSalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.PriSalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriSalesMoneyTaxExc.DataField = "PriSalesMoneyTaxExc";
            this.PriSalesMoneyTaxExc.Height = 0.1875F;
            this.PriSalesMoneyTaxExc.Left = 8.25F;
            this.PriSalesMoneyTaxExc.MultiLine = false;
            this.PriSalesMoneyTaxExc.Name = "PriSalesMoneyTaxExc";
            this.PriSalesMoneyTaxExc.OutputFormat = resources.GetString("PriSalesMoneyTaxExc.OutputFormat");
            this.PriSalesMoneyTaxExc.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.PriSalesMoneyTaxExc.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.PriSalesMoneyTaxExc.Top = 0F;
            this.PriSalesMoneyTaxExc.Width = 0.8125F;
            // 
            // PriSupplierMoney
            // 
            this.PriSupplierMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.PriSupplierMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriSupplierMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.PriSupplierMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriSupplierMoney.Border.RightColor = System.Drawing.Color.Black;
            this.PriSupplierMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriSupplierMoney.Border.TopColor = System.Drawing.Color.Black;
            this.PriSupplierMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriSupplierMoney.DataField = "PriSupplierMoney";
            this.PriSupplierMoney.Height = 0.1875F;
            this.PriSupplierMoney.Left = 9.09375F;
            this.PriSupplierMoney.MultiLine = false;
            this.PriSupplierMoney.Name = "PriSupplierMoney";
            this.PriSupplierMoney.OutputFormat = resources.GetString("PriSupplierMoney.OutputFormat");
            this.PriSupplierMoney.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.PriSupplierMoney.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.PriSupplierMoney.Top = 0F;
            this.PriSupplierMoney.Width = 0.8125F;
            // 
            // PriDefferent
            // 
            this.PriDefferent.Border.BottomColor = System.Drawing.Color.Black;
            this.PriDefferent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriDefferent.Border.LeftColor = System.Drawing.Color.Black;
            this.PriDefferent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriDefferent.Border.RightColor = System.Drawing.Color.Black;
            this.PriDefferent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriDefferent.Border.TopColor = System.Drawing.Color.Black;
            this.PriDefferent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriDefferent.DataField = "PriDefferent";
            this.PriDefferent.Height = 0.1875F;
            this.PriDefferent.Left = 9.895836F;
            this.PriDefferent.MultiLine = false;
            this.PriDefferent.Name = "PriDefferent";
            this.PriDefferent.OutputFormat = resources.GetString("PriDefferent.OutputFormat");
            this.PriDefferent.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.PriDefferent.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.PriDefferent.Top = 0F;
            this.PriDefferent.Width = 0.8125F;
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
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.1875F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0.1875F;
            this.line4.Y2 = 0.1875F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.25F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format_1);
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
            this.Footer_SubReport.Width = 11.2F;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label4,
            this.label5,
            this.line3,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.Lable_PureDefferent,
            this.label12,
            this.label13,
            this.label14,
            this.Lable_PriDefferent,
            this.label20,
            this.label16});
            this.TitleHeader.Height = 0.3958333F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
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
            this.label1.Text = "得意先";
            this.label1.Top = 0.1875F;
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
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = "";
            this.label4.Left = 1.90625F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "伝票枚数";
            this.label4.Top = 0.1875F;
            this.label4.Width = 0.5F;
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
            this.label5.Left = 2.8125F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "売上合計";
            this.label5.Top = 0.1875F;
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
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0.3229167F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0.3229167F;
            this.line3.Y2 = 0.3229167F;
            // 
            // label7
            // 
            this.label7.Border.BottomColor = System.Drawing.Color.Black;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftColor = System.Drawing.Color.Black;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightColor = System.Drawing.Color.Black;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopColor = System.Drawing.Color.Black;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Height = 0.1875F;
            this.label7.HyperLink = "";
            this.label7.Left = 3.583333F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "値引予定額";
            this.label7.Top = 0.1875F;
            this.label7.Width = 0.6875F;
            // 
            // label8
            // 
            this.label8.Border.BottomColor = System.Drawing.Color.Black;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftColor = System.Drawing.Color.Black;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightColor = System.Drawing.Color.Black;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopColor = System.Drawing.Color.Black;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Height = 0.1875F;
            this.label8.HyperLink = "";
            this.label8.Left = 4.59375F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "行数";
            this.label8.Top = 0.1875F;
            this.label8.Width = 0.3125F;
            // 
            // label9
            // 
            this.label9.Border.BottomColor = System.Drawing.Color.Black;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftColor = System.Drawing.Color.Black;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightColor = System.Drawing.Color.Black;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopColor = System.Drawing.Color.Black;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Height = 0.17F;
            this.label9.HyperLink = "";
            this.label9.Left = 5.354167F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "売上金額";
            this.label9.Top = 0.1875F;
            this.label9.Width = 0.5F;
            // 
            // label10
            // 
            this.label10.Border.BottomColor = System.Drawing.Color.Black;
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.LeftColor = System.Drawing.Color.Black;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.RightColor = System.Drawing.Color.Black;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.TopColor = System.Drawing.Color.Black;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Height = 0.17F;
            this.label10.HyperLink = "";
            this.label10.Left = 6.177083F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "仕切金額";
            this.label10.Top = 0.1875F;
            this.label10.Width = 0.5F;
            // 
            // Lable_PureDefferent
            // 
            this.Lable_PureDefferent.Border.BottomColor = System.Drawing.Color.Black;
            this.Lable_PureDefferent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lable_PureDefferent.Border.LeftColor = System.Drawing.Color.Black;
            this.Lable_PureDefferent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lable_PureDefferent.Border.RightColor = System.Drawing.Color.Black;
            this.Lable_PureDefferent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lable_PureDefferent.Border.TopColor = System.Drawing.Color.Black;
            this.Lable_PureDefferent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lable_PureDefferent.Height = 0.1875F;
            this.Lable_PureDefferent.HyperLink = "";
            this.Lable_PureDefferent.Left = 7.1875F;
            this.Lable_PureDefferent.MultiLine = false;
            this.Lable_PureDefferent.Name = "Lable_PureDefferent";
            this.Lable_PureDefferent.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lable_PureDefferent.Text = "差額";
            this.Lable_PureDefferent.Top = 0.1875F;
            this.Lable_PureDefferent.Width = 0.3125F;
            // 
            // label12
            // 
            this.label12.Border.BottomColor = System.Drawing.Color.Black;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftColor = System.Drawing.Color.Black;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightColor = System.Drawing.Color.Black;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopColor = System.Drawing.Color.Black;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Height = 0.1875F;
            this.label12.HyperLink = "";
            this.label12.Left = 7.885417F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "行数";
            this.label12.Top = 0.1875F;
            this.label12.Width = 0.3125F;
            // 
            // label13
            // 
            this.label13.Border.BottomColor = System.Drawing.Color.Black;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.LeftColor = System.Drawing.Color.Black;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.RightColor = System.Drawing.Color.Black;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.TopColor = System.Drawing.Color.Black;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Height = 0.17F;
            this.label13.HyperLink = "";
            this.label13.Left = 8.552083F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "売上金額";
            this.label13.Top = 0.1875F;
            this.label13.Width = 0.5F;
            // 
            // label14
            // 
            this.label14.Border.BottomColor = System.Drawing.Color.Black;
            this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.LeftColor = System.Drawing.Color.Black;
            this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.RightColor = System.Drawing.Color.Black;
            this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.TopColor = System.Drawing.Color.Black;
            this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Height = 0.17F;
            this.label14.HyperLink = "";
            this.label14.Left = 9.40625F;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "仕切金額";
            this.label14.Top = 0.1875F;
            this.label14.Width = 0.5F;
            // 
            // Lable_PriDefferent
            // 
            this.Lable_PriDefferent.Border.BottomColor = System.Drawing.Color.Black;
            this.Lable_PriDefferent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lable_PriDefferent.Border.LeftColor = System.Drawing.Color.Black;
            this.Lable_PriDefferent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lable_PriDefferent.Border.RightColor = System.Drawing.Color.Black;
            this.Lable_PriDefferent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lable_PriDefferent.Border.TopColor = System.Drawing.Color.Black;
            this.Lable_PriDefferent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lable_PriDefferent.Height = 0.1875F;
            this.Lable_PriDefferent.HyperLink = "";
            this.Lable_PriDefferent.Left = 10.39583F;
            this.Lable_PriDefferent.Name = "Lable_PriDefferent";
            this.Lable_PriDefferent.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lable_PriDefferent.Text = "差額";
            this.Lable_PriDefferent.Top = 0.1875F;
            this.Lable_PriDefferent.Width = 0.3125F;
            // 
            // label20
            // 
            this.label20.Border.BottomColor = System.Drawing.Color.Black;
            this.label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.LeftColor = System.Drawing.Color.Black;
            this.label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.RightColor = System.Drawing.Color.Black;
            this.label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.TopColor = System.Drawing.Color.Black;
            this.label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Height = 0.1875F;
            this.label20.HyperLink = "";
            this.label20.Left = 7.78125F;
            this.label20.MultiLine = false;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label20.Text = "<====================   優  良   ===================>";
            this.label20.Top = 0F;
            this.label20.Width = 3.25F;
            // 
            // label16
            // 
            this.label16.Border.BottomColor = System.Drawing.Color.Black;
            this.label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.LeftColor = System.Drawing.Color.Black;
            this.label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.RightColor = System.Drawing.Color.Black;
            this.label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.TopColor = System.Drawing.Color.Black;
            this.label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Height = 0.125F;
            this.label16.HyperLink = "";
            this.label16.Left = 4.53125F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "<====================   純  正   ====================>";
            this.label16.Top = 0F;
            this.label16.Width = 3.0625F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Extra_SubReport,
            this.line6});
            this.ExtraHeader.Height = 0.2291667F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Extra_SubReport
            // 
            this.Extra_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Extra_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extra_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Extra_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extra_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Extra_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extra_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Extra_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extra_SubReport.CloseBorder = false;
            this.Extra_SubReport.Height = 0.1875F;
            this.Extra_SubReport.Left = 0F;
            this.Extra_SubReport.Name = "Extra_SubReport";
            this.Extra_SubReport.Report = null;
            this.Extra_SubReport.Top = 0F;
            this.Extra_SubReport.Width = 10.8125F;
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
            this.line6.Top = 0.1875F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0.1875F;
            this.line6.Y2 = 0.1875F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            // 
            // SectionCodeHeader
            // 
            this.SectionCodeHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label6,
            this.SectionGuideSnm,
            this.SectionCode,
            this.line2});
            this.SectionCodeHeader.DataField = "SectionCode";
            this.SectionCodeHeader.Height = 0.2083333F;
            this.SectionCodeHeader.Name = "SectionCodeHeader";
            this.SectionCodeHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionCodeHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SectionCodeHeader.Format += new System.EventHandler(this.SectionCodeHeader_Format);
            this.SectionCodeHeader.AfterPrint += new System.EventHandler(this.SectionCodeHeader_AfterPrint);
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = "";
            this.label6.Left = 0.4375F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.label6.Text = "拠点";
            this.label6.Top = 0F;
            this.label6.Width = 0.375F;
            // 
            // SectionGuideSnm
            // 
            this.SectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.DataField = "SectionGuideSnm";
            this.SectionGuideSnm.Height = 0.1875F;
            this.SectionGuideSnm.Left = 1.041667F;
            this.SectionGuideSnm.MultiLine = false;
            this.SectionGuideSnm.Name = "SectionGuideSnm";
            this.SectionGuideSnm.OutputFormat = resources.GetString("SectionGuideSnm.OutputFormat");
            this.SectionGuideSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: bottom; ";
            this.SectionGuideSnm.Text = "あいうえおかきくけこあ";
            this.SectionGuideSnm.Top = 0F;
            this.SectionGuideSnm.Width = 1.1875F;
            // 
            // SectionCode
            // 
            this.SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.DataField = "SectionCode";
            this.SectionCode.Height = 0.19F;
            this.SectionCode.Left = 0.8541667F;
            this.SectionCode.MultiLine = false;
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.OutputFormat = resources.GetString("SectionCode.OutputFormat");
            this.SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: bottom; ";
            this.SectionCode.Text = "12";
            this.SectionCode.Top = 0F;
            this.SectionCode.Width = 0.15F;
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
            this.line2.Top = 0.1875F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0.1875F;
            this.line2.Y2 = 0.1875F;
            // 
            // SectionCodeFooter
            // 
            this.SectionCodeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line5,
            this.SCustomerSnm,
            this.SSlipCountSum,
            this.SSalesMoneySum,
            this.SSalesSupplierMoneySum,
            this.SPureCount,
            this.SPureSalesMoneyTaxExc,
            this.textBox7,
            this.SPureDefferent,
            this.SPriCount,
            this.SPriSalesMoneyTaxExc,
            this.SPriSupplierMoney,
            this.SPriDefferent});
            this.SectionCodeFooter.Height = 0.208F;
            this.SectionCodeFooter.KeepTogether = true;
            this.SectionCodeFooter.Name = "SectionCodeFooter";
            this.SectionCodeFooter.BeforePrint += new System.EventHandler(this.SectionCodeFooter_BeforePrint);
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
            this.line5.Top = 0F;
            this.line5.Visible = false;
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // SCustomerSnm
            // 
            this.SCustomerSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SCustomerSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SCustomerSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SCustomerSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SCustomerSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SCustomerSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SCustomerSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SCustomerSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SCustomerSnm.Height = 0.1875F;
            this.SCustomerSnm.Left = 0.5625F;
            this.SCustomerSnm.MultiLine = false;
            this.SCustomerSnm.Name = "SCustomerSnm";
            this.SCustomerSnm.OutputFormat = resources.GetString("SCustomerSnm.OutputFormat");
            this.SCustomerSnm.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: bottom; ";
            this.SCustomerSnm.Text = "拠点計";
            this.SCustomerSnm.Top = 0F;
            this.SCustomerSnm.Width = 1.2F;
            // 
            // SSlipCountSum
            // 
            this.SSlipCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SSlipCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSlipCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SSlipCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSlipCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.SSlipCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSlipCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.SSlipCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSlipCountSum.DataField = "SlipCountSum";
            this.SSlipCountSum.Height = 0.1875F;
            this.SSlipCountSum.Left = 1.896F;
            this.SSlipCountSum.MultiLine = false;
            this.SSlipCountSum.Name = "SSlipCountSum";
            this.SSlipCountSum.OutputFormat = resources.GetString("SSlipCountSum.OutputFormat");
            this.SSlipCountSum.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SSlipCountSum.SummaryGroup = "SectionCodeHeader";
            this.SSlipCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SSlipCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SSlipCountSum.Text = "ZZZ,ZZ9";
            this.SSlipCountSum.Top = 0F;
            this.SSlipCountSum.Width = 0.5F;
            // 
            // SSalesMoneySum
            // 
            this.SSalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.SSalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.SSalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.SSalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.SSalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSalesMoneySum.DataField = "SalesMoneySum";
            this.SSalesMoneySum.Height = 0.1875F;
            this.SSalesMoneySum.Left = 2.5F;
            this.SSalesMoneySum.MultiLine = false;
            this.SSalesMoneySum.Name = "SSalesMoneySum";
            this.SSalesMoneySum.OutputFormat = resources.GetString("SSalesMoneySum.OutputFormat");
            this.SSalesMoneySum.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SSalesMoneySum.SummaryGroup = "SectionCodeHeader";
            this.SSalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SSalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SSalesMoneySum.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SSalesMoneySum.Top = 0F;
            this.SSalesMoneySum.Width = 0.8125F;
            // 
            // SSalesSupplierMoneySum
            // 
            this.SSalesSupplierMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.SSalesSupplierMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSalesSupplierMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.SSalesSupplierMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSalesSupplierMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.SSalesSupplierMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSalesSupplierMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.SSalesSupplierMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SSalesSupplierMoneySum.DataField = "SalesSupplierMoneySum";
            this.SSalesSupplierMoneySum.Height = 0.1875F;
            this.SSalesSupplierMoneySum.Left = 3.458F;
            this.SSalesSupplierMoneySum.MultiLine = false;
            this.SSalesSupplierMoneySum.Name = "SSalesSupplierMoneySum";
            this.SSalesSupplierMoneySum.OutputFormat = resources.GetString("SSalesSupplierMoneySum.OutputFormat");
            this.SSalesSupplierMoneySum.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SSalesSupplierMoneySum.SummaryGroup = "SectionCodeHeader";
            this.SSalesSupplierMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SSalesSupplierMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SSalesSupplierMoneySum.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SSalesSupplierMoneySum.Top = 0F;
            this.SSalesSupplierMoneySum.Width = 0.8125F;
            // 
            // SPureCount
            // 
            this.SPureCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SPureCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SPureCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureCount.Border.RightColor = System.Drawing.Color.Black;
            this.SPureCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureCount.Border.TopColor = System.Drawing.Color.Black;
            this.SPureCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureCount.DataField = "PureCount";
            this.SPureCount.Height = 0.1875F;
            this.SPureCount.Left = 4.458F;
            this.SPureCount.MultiLine = false;
            this.SPureCount.Name = "SPureCount";
            this.SPureCount.OutputFormat = resources.GetString("SPureCount.OutputFormat");
            this.SPureCount.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SPureCount.SummaryGroup = "SectionCodeHeader";
            this.SPureCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SPureCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SPureCount.Text = "ZZZ,ZZ9";
            this.SPureCount.Top = 0F;
            this.SPureCount.Width = 0.4375F;
            // 
            // SPureSalesMoneyTaxExc
            // 
            this.SPureSalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SPureSalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureSalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SPureSalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureSalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SPureSalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureSalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SPureSalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureSalesMoneyTaxExc.DataField = "PureSalesMoneyTaxExc";
            this.SPureSalesMoneyTaxExc.Height = 0.1875F;
            this.SPureSalesMoneyTaxExc.Left = 5.031F;
            this.SPureSalesMoneyTaxExc.MultiLine = false;
            this.SPureSalesMoneyTaxExc.Name = "SPureSalesMoneyTaxExc";
            this.SPureSalesMoneyTaxExc.OutputFormat = resources.GetString("SPureSalesMoneyTaxExc.OutputFormat");
            this.SPureSalesMoneyTaxExc.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SPureSalesMoneyTaxExc.SummaryGroup = "SectionCodeHeader";
            this.SPureSalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SPureSalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SPureSalesMoneyTaxExc.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SPureSalesMoneyTaxExc.Top = 0F;
            this.SPureSalesMoneyTaxExc.Width = 0.8125F;
            // 
            // textBox7
            // 
            this.textBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.RightColor = System.Drawing.Color.Black;
            this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.TopColor = System.Drawing.Color.Black;
            this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.DataField = "PureSupplierMoney";
            this.textBox7.Height = 0.1875F;
            this.textBox7.Left = 5.865F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.textBox7.SummaryGroup = "SectionCodeHeader";
            this.textBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox7.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.8125F;
            // 
            // SPureDefferent
            // 
            this.SPureDefferent.Border.BottomColor = System.Drawing.Color.Black;
            this.SPureDefferent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureDefferent.Border.LeftColor = System.Drawing.Color.Black;
            this.SPureDefferent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureDefferent.Border.RightColor = System.Drawing.Color.Black;
            this.SPureDefferent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureDefferent.Border.TopColor = System.Drawing.Color.Black;
            this.SPureDefferent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPureDefferent.DataField = "PureDefferent";
            this.SPureDefferent.Height = 0.1875F;
            this.SPureDefferent.Left = 6.708F;
            this.SPureDefferent.MultiLine = false;
            this.SPureDefferent.Name = "SPureDefferent";
            this.SPureDefferent.OutputFormat = resources.GetString("SPureDefferent.OutputFormat");
            this.SPureDefferent.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SPureDefferent.SummaryGroup = "SectionCodeHeader";
            this.SPureDefferent.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SPureDefferent.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SPureDefferent.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SPureDefferent.Top = 0F;
            this.SPureDefferent.Width = 0.8125F;
            // 
            // SPriCount
            // 
            this.SPriCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SPriCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SPriCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriCount.Border.RightColor = System.Drawing.Color.Black;
            this.SPriCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriCount.Border.TopColor = System.Drawing.Color.Black;
            this.SPriCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriCount.DataField = "PriCount";
            this.SPriCount.Height = 0.1875F;
            this.SPriCount.Left = 7.75F;
            this.SPriCount.MultiLine = false;
            this.SPriCount.Name = "SPriCount";
            this.SPriCount.OutputFormat = resources.GetString("SPriCount.OutputFormat");
            this.SPriCount.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SPriCount.SummaryGroup = "SectionCodeHeader";
            this.SPriCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SPriCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SPriCount.Text = "ZZZ,ZZ9";
            this.SPriCount.Top = 0F;
            this.SPriCount.Width = 0.4375F;
            // 
            // SPriSalesMoneyTaxExc
            // 
            this.SPriSalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SPriSalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriSalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SPriSalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriSalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SPriSalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriSalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SPriSalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriSalesMoneyTaxExc.DataField = "PriSalesMoneyTaxExc";
            this.SPriSalesMoneyTaxExc.Height = 0.1875F;
            this.SPriSalesMoneyTaxExc.Left = 8.25F;
            this.SPriSalesMoneyTaxExc.MultiLine = false;
            this.SPriSalesMoneyTaxExc.Name = "SPriSalesMoneyTaxExc";
            this.SPriSalesMoneyTaxExc.OutputFormat = resources.GetString("SPriSalesMoneyTaxExc.OutputFormat");
            this.SPriSalesMoneyTaxExc.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SPriSalesMoneyTaxExc.SummaryGroup = "SectionCodeHeader";
            this.SPriSalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SPriSalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SPriSalesMoneyTaxExc.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SPriSalesMoneyTaxExc.Top = 0F;
            this.SPriSalesMoneyTaxExc.Width = 0.8125F;
            // 
            // SPriSupplierMoney
            // 
            this.SPriSupplierMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SPriSupplierMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriSupplierMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SPriSupplierMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriSupplierMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SPriSupplierMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriSupplierMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SPriSupplierMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriSupplierMoney.DataField = "PriSupplierMoney";
            this.SPriSupplierMoney.Height = 0.1875F;
            this.SPriSupplierMoney.Left = 9.094F;
            this.SPriSupplierMoney.MultiLine = false;
            this.SPriSupplierMoney.Name = "SPriSupplierMoney";
            this.SPriSupplierMoney.OutputFormat = resources.GetString("SPriSupplierMoney.OutputFormat");
            this.SPriSupplierMoney.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SPriSupplierMoney.SummaryGroup = "SectionCodeHeader";
            this.SPriSupplierMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SPriSupplierMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SPriSupplierMoney.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SPriSupplierMoney.Top = 0F;
            this.SPriSupplierMoney.Width = 0.8125F;
            // 
            // SPriDefferent
            // 
            this.SPriDefferent.Border.BottomColor = System.Drawing.Color.Black;
            this.SPriDefferent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriDefferent.Border.LeftColor = System.Drawing.Color.Black;
            this.SPriDefferent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriDefferent.Border.RightColor = System.Drawing.Color.Black;
            this.SPriDefferent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriDefferent.Border.TopColor = System.Drawing.Color.Black;
            this.SPriDefferent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SPriDefferent.DataField = "PriDefferent";
            this.SPriDefferent.Height = 0.1875F;
            this.SPriDefferent.Left = 9.896F;
            this.SPriDefferent.MultiLine = false;
            this.SPriDefferent.Name = "SPriDefferent";
            this.SPriDefferent.OutputFormat = resources.GetString("SPriDefferent.OutputFormat");
            this.SPriDefferent.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.SPriDefferent.SummaryGroup = "SectionCodeHeader";
            this.SPriDefferent.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SPriDefferent.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SPriDefferent.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SPriDefferent.Top = 0F;
            this.SPriDefferent.Width = 0.8125F;
            // 
            // GrandHeader
            // 
            this.GrandHeader.Height = 0F;
            this.GrandHeader.Name = "GrandHeader";
            // 
            // GrandFooter
            // 
            this.GrandFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.APriDefferent,
            this.APriSupplierMoney,
            this.APriSalesMoneyTaxExc,
            this.APriCount,
            this.APureDefferent,
            this.APureSupplierMoney,
            this.APureSalesMoneyTaxExc,
            this.APureCount,
            this.ASalesSupplierMoneySum,
            this.ASalesMoneySum,
            this.ASlipCountSum,
            this.ACustomerSnm,
            this.line7});
            this.GrandFooter.Height = 0.208F;
            this.GrandFooter.KeepTogether = true;
            this.GrandFooter.Name = "GrandFooter";
            this.GrandFooter.BeforePrint += new System.EventHandler(this.GrandFooter_BeforePrint);
            // 
            // APriDefferent
            // 
            this.APriDefferent.Border.BottomColor = System.Drawing.Color.Black;
            this.APriDefferent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriDefferent.Border.LeftColor = System.Drawing.Color.Black;
            this.APriDefferent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriDefferent.Border.RightColor = System.Drawing.Color.Black;
            this.APriDefferent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriDefferent.Border.TopColor = System.Drawing.Color.Black;
            this.APriDefferent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriDefferent.DataField = "PriDefferent";
            this.APriDefferent.Height = 0.1875F;
            this.APriDefferent.Left = 9.896F;
            this.APriDefferent.MultiLine = false;
            this.APriDefferent.Name = "APriDefferent";
            this.APriDefferent.OutputFormat = resources.GetString("APriDefferent.OutputFormat");
            this.APriDefferent.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.APriDefferent.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.APriDefferent.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.APriDefferent.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.APriDefferent.Top = 0F;
            this.APriDefferent.Width = 0.8125F;
            // 
            // APriSupplierMoney
            // 
            this.APriSupplierMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.APriSupplierMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriSupplierMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.APriSupplierMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriSupplierMoney.Border.RightColor = System.Drawing.Color.Black;
            this.APriSupplierMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriSupplierMoney.Border.TopColor = System.Drawing.Color.Black;
            this.APriSupplierMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriSupplierMoney.DataField = "PriSupplierMoney";
            this.APriSupplierMoney.Height = 0.1875F;
            this.APriSupplierMoney.Left = 9.094F;
            this.APriSupplierMoney.MultiLine = false;
            this.APriSupplierMoney.Name = "APriSupplierMoney";
            this.APriSupplierMoney.OutputFormat = resources.GetString("APriSupplierMoney.OutputFormat");
            this.APriSupplierMoney.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.APriSupplierMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.APriSupplierMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.APriSupplierMoney.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.APriSupplierMoney.Top = 0F;
            this.APriSupplierMoney.Width = 0.8125F;
            // 
            // APriSalesMoneyTaxExc
            // 
            this.APriSalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.APriSalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriSalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.APriSalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriSalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.APriSalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriSalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.APriSalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriSalesMoneyTaxExc.DataField = "PriSalesMoneyTaxExc";
            this.APriSalesMoneyTaxExc.Height = 0.1875F;
            this.APriSalesMoneyTaxExc.Left = 8.25F;
            this.APriSalesMoneyTaxExc.MultiLine = false;
            this.APriSalesMoneyTaxExc.Name = "APriSalesMoneyTaxExc";
            this.APriSalesMoneyTaxExc.OutputFormat = resources.GetString("APriSalesMoneyTaxExc.OutputFormat");
            this.APriSalesMoneyTaxExc.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.APriSalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.APriSalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.APriSalesMoneyTaxExc.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.APriSalesMoneyTaxExc.Top = 0F;
            this.APriSalesMoneyTaxExc.Width = 0.8125F;
            // 
            // APriCount
            // 
            this.APriCount.Border.BottomColor = System.Drawing.Color.Black;
            this.APriCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriCount.Border.LeftColor = System.Drawing.Color.Black;
            this.APriCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriCount.Border.RightColor = System.Drawing.Color.Black;
            this.APriCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriCount.Border.TopColor = System.Drawing.Color.Black;
            this.APriCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APriCount.DataField = "PriCount";
            this.APriCount.Height = 0.1875F;
            this.APriCount.Left = 7.75F;
            this.APriCount.MultiLine = false;
            this.APriCount.Name = "APriCount";
            this.APriCount.OutputFormat = resources.GetString("APriCount.OutputFormat");
            this.APriCount.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.APriCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.APriCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.APriCount.Text = "ZZZ,ZZ9";
            this.APriCount.Top = 0F;
            this.APriCount.Width = 0.4375F;
            // 
            // APureDefferent
            // 
            this.APureDefferent.Border.BottomColor = System.Drawing.Color.Black;
            this.APureDefferent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureDefferent.Border.LeftColor = System.Drawing.Color.Black;
            this.APureDefferent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureDefferent.Border.RightColor = System.Drawing.Color.Black;
            this.APureDefferent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureDefferent.Border.TopColor = System.Drawing.Color.Black;
            this.APureDefferent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureDefferent.DataField = "PureDefferent";
            this.APureDefferent.Height = 0.1875F;
            this.APureDefferent.Left = 6.708F;
            this.APureDefferent.MultiLine = false;
            this.APureDefferent.Name = "APureDefferent";
            this.APureDefferent.OutputFormat = resources.GetString("APureDefferent.OutputFormat");
            this.APureDefferent.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.APureDefferent.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.APureDefferent.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.APureDefferent.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.APureDefferent.Top = 0F;
            this.APureDefferent.Width = 0.8125F;
            // 
            // APureSupplierMoney
            // 
            this.APureSupplierMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.APureSupplierMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureSupplierMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.APureSupplierMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureSupplierMoney.Border.RightColor = System.Drawing.Color.Black;
            this.APureSupplierMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureSupplierMoney.Border.TopColor = System.Drawing.Color.Black;
            this.APureSupplierMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureSupplierMoney.DataField = "PureSupplierMoney";
            this.APureSupplierMoney.Height = 0.1875F;
            this.APureSupplierMoney.Left = 5.865F;
            this.APureSupplierMoney.MultiLine = false;
            this.APureSupplierMoney.Name = "APureSupplierMoney";
            this.APureSupplierMoney.OutputFormat = resources.GetString("APureSupplierMoney.OutputFormat");
            this.APureSupplierMoney.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.APureSupplierMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.APureSupplierMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.APureSupplierMoney.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.APureSupplierMoney.Top = 0F;
            this.APureSupplierMoney.Width = 0.8125F;
            // 
            // APureSalesMoneyTaxExc
            // 
            this.APureSalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.APureSalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureSalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.APureSalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureSalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.APureSalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureSalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.APureSalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureSalesMoneyTaxExc.DataField = "PureSalesMoneyTaxExc";
            this.APureSalesMoneyTaxExc.Height = 0.1875F;
            this.APureSalesMoneyTaxExc.Left = 5.031F;
            this.APureSalesMoneyTaxExc.MultiLine = false;
            this.APureSalesMoneyTaxExc.Name = "APureSalesMoneyTaxExc";
            this.APureSalesMoneyTaxExc.OutputFormat = resources.GetString("APureSalesMoneyTaxExc.OutputFormat");
            this.APureSalesMoneyTaxExc.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.APureSalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.APureSalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.APureSalesMoneyTaxExc.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.APureSalesMoneyTaxExc.Top = 0F;
            this.APureSalesMoneyTaxExc.Width = 0.8125F;
            // 
            // APureCount
            // 
            this.APureCount.Border.BottomColor = System.Drawing.Color.Black;
            this.APureCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureCount.Border.LeftColor = System.Drawing.Color.Black;
            this.APureCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureCount.Border.RightColor = System.Drawing.Color.Black;
            this.APureCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureCount.Border.TopColor = System.Drawing.Color.Black;
            this.APureCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.APureCount.DataField = "PureCount";
            this.APureCount.Height = 0.1875F;
            this.APureCount.Left = 4.458F;
            this.APureCount.MultiLine = false;
            this.APureCount.Name = "APureCount";
            this.APureCount.OutputFormat = resources.GetString("APureCount.OutputFormat");
            this.APureCount.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.APureCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.APureCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.APureCount.Text = "ZZZ,ZZ9";
            this.APureCount.Top = 0F;
            this.APureCount.Width = 0.4375F;
            // 
            // ASalesSupplierMoneySum
            // 
            this.ASalesSupplierMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.ASalesSupplierMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASalesSupplierMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.ASalesSupplierMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASalesSupplierMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.ASalesSupplierMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASalesSupplierMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.ASalesSupplierMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASalesSupplierMoneySum.DataField = "SalesSupplierMoneySum";
            this.ASalesSupplierMoneySum.Height = 0.1875F;
            this.ASalesSupplierMoneySum.Left = 3.458F;
            this.ASalesSupplierMoneySum.MultiLine = false;
            this.ASalesSupplierMoneySum.Name = "ASalesSupplierMoneySum";
            this.ASalesSupplierMoneySum.OutputFormat = resources.GetString("ASalesSupplierMoneySum.OutputFormat");
            this.ASalesSupplierMoneySum.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.ASalesSupplierMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.ASalesSupplierMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.ASalesSupplierMoneySum.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.ASalesSupplierMoneySum.Top = 0F;
            this.ASalesSupplierMoneySum.Width = 0.8125F;
            // 
            // ASalesMoneySum
            // 
            this.ASalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.ASalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.ASalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.ASalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.ASalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASalesMoneySum.DataField = "SalesMoneySum";
            this.ASalesMoneySum.Height = 0.1875F;
            this.ASalesMoneySum.Left = 2.5F;
            this.ASalesMoneySum.MultiLine = false;
            this.ASalesMoneySum.Name = "ASalesMoneySum";
            this.ASalesMoneySum.OutputFormat = resources.GetString("ASalesMoneySum.OutputFormat");
            this.ASalesMoneySum.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.ASalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.ASalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.ASalesMoneySum.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.ASalesMoneySum.Top = 0F;
            this.ASalesMoneySum.Width = 0.8125F;
            // 
            // ASlipCountSum
            // 
            this.ASlipCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.ASlipCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASlipCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.ASlipCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASlipCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.ASlipCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASlipCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.ASlipCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ASlipCountSum.DataField = "SlipCountSum";
            this.ASlipCountSum.Height = 0.1875F;
            this.ASlipCountSum.Left = 1.896F;
            this.ASlipCountSum.MultiLine = false;
            this.ASlipCountSum.Name = "ASlipCountSum";
            this.ASlipCountSum.OutputFormat = resources.GetString("ASlipCountSum.OutputFormat");
            this.ASlipCountSum.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ＭＳ ゴシック; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.ASlipCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.ASlipCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.ASlipCountSum.Text = "ZZZ,ZZ9";
            this.ASlipCountSum.Top = 0F;
            this.ASlipCountSum.Width = 0.5F;
            // 
            // ACustomerSnm
            // 
            this.ACustomerSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.ACustomerSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ACustomerSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.ACustomerSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ACustomerSnm.Border.RightColor = System.Drawing.Color.Black;
            this.ACustomerSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ACustomerSnm.Border.TopColor = System.Drawing.Color.Black;
            this.ACustomerSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ACustomerSnm.Height = 0.1875F;
            this.ACustomerSnm.Left = 0.5625F;
            this.ACustomerSnm.MultiLine = false;
            this.ACustomerSnm.Name = "ACustomerSnm";
            this.ACustomerSnm.OutputFormat = resources.GetString("ACustomerSnm.OutputFormat");
            this.ACustomerSnm.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: bottom; ";
            this.ACustomerSnm.Text = "総合計";
            this.ACustomerSnm.Top = 0F;
            this.ACustomerSnm.Width = 1.2F;
            // 
            // line7
            // 
            this.line7.Border.BottomColor = System.Drawing.Color.Black;
            this.line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.LeftColor = System.Drawing.Color.Black;
            this.line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.RightColor = System.Drawing.Color.Black;
            this.line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.TopColor = System.Drawing.Color.Black;
            this.line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Height = 0F;
            this.line7.Left = 0F;
            this.line7.LineWeight = 2F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 10.8F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
            // 
            // PMSAE02012P_01A4C
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
            this.PrintWidth = 11.2F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandHeader);
            this.Sections.Add(this.SectionCodeHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SectionCodeFooter);
            this.Sections.Add(this.GrandFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: \"ＭＳ 明朝\"; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ddo-char-set: 128; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ddo-char-set: 128; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; font-style: italic; ddo-char-set: 204; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMSAE02012P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSupplierMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSupplierMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureDefferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriSalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriSupplierMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriDefferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lable_PureDefferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lable_PriDefferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SCustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSlipCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSalesSupplierMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPureCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPureSalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPureDefferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPriCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPriSalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPriSupplierMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPriDefferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APriDefferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APriSupplierMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APriSalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APriCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureDefferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureSupplierMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureSalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ASalesSupplierMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ASalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ASlipCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label tb_ReportTitle;
        private DataDynamics.ActiveReports.TextBox DATE;
        private DataDynamics.ActiveReports.TextBox TIME;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.TextBox tb_PrintPage;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.TextBox CustomerSnm;
        private DataDynamics.ActiveReports.Line line3;
        private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.SubReport Extra_SubReport;
        private DataDynamics.ActiveReports.GroupHeader SectionCodeHeader;
        private DataDynamics.ActiveReports.GroupFooter SectionCodeFooter;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.Line line6;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.Label label8;
        private DataDynamics.ActiveReports.Label label9;
        private DataDynamics.ActiveReports.Label label10;
        private DataDynamics.ActiveReports.Label Lable_PureDefferent;
        private DataDynamics.ActiveReports.Label label12;
        private DataDynamics.ActiveReports.Label label13;
        private DataDynamics.ActiveReports.Label label14;
        private DataDynamics.ActiveReports.Label Lable_PriDefferent;
        private DataDynamics.ActiveReports.Label label16;
        private DataDynamics.ActiveReports.Label label20;
        private DataDynamics.ActiveReports.TextBox SectionGuideSnm;
        private DataDynamics.ActiveReports.TextBox CustomerCode;
        private DataDynamics.ActiveReports.TextBox SectionCode;
        private DataDynamics.ActiveReports.TextBox SlipCountSum;
        private DataDynamics.ActiveReports.TextBox SalesMoneySum;
        private DataDynamics.ActiveReports.TextBox SalesSupplierMoneySum;
        private DataDynamics.ActiveReports.TextBox PureCount;
        private DataDynamics.ActiveReports.TextBox PureSalesMoneyTaxExc;
        private DataDynamics.ActiveReports.TextBox PureSupplierMoney;
        private DataDynamics.ActiveReports.TextBox PureDefferent;
        private DataDynamics.ActiveReports.TextBox PriCount;
        private DataDynamics.ActiveReports.TextBox PriSalesMoneyTaxExc;
        private DataDynamics.ActiveReports.TextBox PriSupplierMoney;
        private DataDynamics.ActiveReports.TextBox PriDefferent;
        private DataDynamics.ActiveReports.Line line4;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.GroupHeader GrandHeader;
        private DataDynamics.ActiveReports.GroupFooter GrandFooter;
        private DataDynamics.ActiveReports.Line line5;
        private DataDynamics.ActiveReports.TextBox SCustomerSnm;
        private DataDynamics.ActiveReports.TextBox SSlipCountSum;
        private DataDynamics.ActiveReports.TextBox SSalesMoneySum;
        private DataDynamics.ActiveReports.TextBox SSalesSupplierMoneySum;
        private DataDynamics.ActiveReports.TextBox SPureCount;
        private DataDynamics.ActiveReports.TextBox SPureSalesMoneyTaxExc;
        private DataDynamics.ActiveReports.TextBox textBox7;
        private DataDynamics.ActiveReports.TextBox SPureDefferent;
        private DataDynamics.ActiveReports.TextBox SPriCount;
        private DataDynamics.ActiveReports.TextBox SPriSalesMoneyTaxExc;
        private DataDynamics.ActiveReports.TextBox SPriSupplierMoney;
        private DataDynamics.ActiveReports.TextBox SPriDefferent;
        private DataDynamics.ActiveReports.TextBox APriDefferent;
        private DataDynamics.ActiveReports.TextBox APriSupplierMoney;
        private DataDynamics.ActiveReports.TextBox APriSalesMoneyTaxExc;
        private DataDynamics.ActiveReports.TextBox APriCount;
        private DataDynamics.ActiveReports.TextBox APureDefferent;
        private DataDynamics.ActiveReports.TextBox APureSupplierMoney;
        private DataDynamics.ActiveReports.TextBox APureSalesMoneyTaxExc;
        private DataDynamics.ActiveReports.TextBox APureCount;
        private DataDynamics.ActiveReports.TextBox ASalesSupplierMoneySum;
        private DataDynamics.ActiveReports.TextBox ASalesMoneySum;
        private DataDynamics.ActiveReports.TextBox ASlipCountSum;
        private DataDynamics.ActiveReports.TextBox ACustomerSnm;
        private DataDynamics.ActiveReports.Line line7;
    }
}
