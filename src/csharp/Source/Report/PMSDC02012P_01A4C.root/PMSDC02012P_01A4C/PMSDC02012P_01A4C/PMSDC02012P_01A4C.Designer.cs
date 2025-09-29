namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMSAE02005P_01A4C ÇÃäTóvÇÃê‡ñæÇ≈Ç∑ÅB
    /// </summary>
    partial class PMSDC02012P_01A4C
    {
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.PageFooter PageFooter;

        /// <summary>
        /// égópíÜÇÃÉäÉ\Å[ÉXÇÇ∑Ç◊ÇƒÉNÉäÅ[ÉìÉAÉbÉvÇµÇ‹Ç∑ÅB
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport ÉfÉUÉCÉiÇ≈ê∂ê¨Ç≥ÇÍÇΩÉRÅ[Éh
        /// <summary>
        /// ÉfÉUÉCÉi ÉTÉ|Å[ÉgÇ…ïKóvÇ»ÉÅÉ\ÉbÉhÇ≈Ç∑ÅBÇ±ÇÃÉÅÉ\ÉbÉhÇÃì‡óeÇ
        /// ÉRÅ[Éh ÉGÉfÉBÉ^Ç≈ïœçXÇµÇ»Ç¢Ç≈Ç≠ÇæÇ≥Ç¢ÅB
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMSDC02012P_01A4C));
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
            this.PureCount = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.label8 = new DataDynamics.ActiveReports.Label();
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
            this.GrandHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.APureCount = new DataDynamics.ActiveReports.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.PureCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureCount)).BeginInit();
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
                "family: ÇlÇr ñæí©; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "ämîFÉäÉXÉg";
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
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-align: top; ";
            this.Label3.Text = "çÏê¨ì˙ïtÅF";
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
            this.DATE.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-align: top; ";
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
            this.TIME.Style = "font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-align: top; ";
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
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-align: top; ";
            this.Label2.Text = "ÉyÅ[ÉWÅF";
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
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-" +
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
            this.PureCount});
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
            this.CustomerSnm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-a" +
                "lign: bottom; ";
            this.CustomerSnm.Text = "Ç†Ç¢Ç§Ç¶Ç®Ç©Ç´Ç≠ÇØÇ±Ç†Ç¢";
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
            this.CustomerCode.Style = "font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: nowrap; vertical-align: bottom" +
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
            this.SlipCountSum.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: nowrap; ver" +
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
            this.SalesMoneySum.Left = 2.5625F;
            this.SalesMoneySum.MultiLine = false;
            this.SalesMoneySum.Name = "SalesMoneySum";
            this.SalesMoneySum.OutputFormat = resources.GetString("SalesMoneySum.OutputFormat");
            this.SalesMoneySum.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.SalesMoneySum.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.SalesMoneySum.Top = 0F;
            this.SalesMoneySum.Width = 0.86F;
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
            this.PureCount.Left = 3.625F;
            this.PureCount.MultiLine = false;
            this.PureCount.Name = "PureCount";
            this.PureCount.OutputFormat = resources.GetString("PureCount.OutputFormat");
            this.PureCount.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: nowrap; ver" +
                "tical-align: bottom; ";
            this.PureCount.Text = "ZZZ,ZZ9";
            this.PureCount.Top = 0F;
            this.PureCount.Width = 0.4375F;
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
            this.label8});
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
                "ly: ÇlÇr ñæí©; vertical-align: top; ";
            this.label1.Text = "ìæà”êÊ";
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
                "ily: ÇlÇr ñæí©; vertical-align: top; ";
            this.label4.Text = "ì`ï[ñáêî";
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
            this.label5.Left = 2.9225F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ÇlÇr ñæí©; vertical-align: top; ";
            this.label5.Text = "îÑè„çáåv";
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
            this.label8.Left = 3.75F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ÇlÇr ñæí©; vertical-align: top; ";
            this.label8.Text = "çsêî";
            this.label8.Top = 0.1875F;
            this.label8.Width = 0.3125F;
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
                "ly: ÇlÇr ñæí©; vertical-align: bottom; ";
            this.label6.Text = "ãíì_";
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
            this.SectionGuideSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical" +
                "-align: bottom; ";
            this.SectionGuideSnm.Text = "Ç†Ç¢Ç§Ç¶Ç®Ç©Ç´Ç≠ÇØÇ±Ç†";
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
            this.SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; vertic" +
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
            this.line5});
            this.SectionCodeFooter.Height = 0F;
            this.SectionCodeFooter.KeepTogether = true;
            this.SectionCodeFooter.Name = "SectionCodeFooter";
            this.SectionCodeFooter.Visible = false;
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
            // GrandHeader
            // 
            this.GrandHeader.Height = 0F;
            this.GrandHeader.Name = "GrandHeader";
            // 
            // GrandFooter
            // 
            this.GrandFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.APureCount,
            this.ASalesMoneySum,
            this.ASlipCountSum,
            this.ACustomerSnm,
            this.line7});
            this.GrandFooter.Height = 0.208F;
            this.GrandFooter.KeepTogether = true;
            this.GrandFooter.Name = "GrandFooter";
            this.GrandFooter.BeforePrint += new System.EventHandler(this.GrandFooter_BeforePrint);
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
            this.APureCount.Left = 3.625F;
            this.APureCount.MultiLine = false;
            this.APureCount.Name = "APureCount";
            this.APureCount.OutputFormat = resources.GetString("APureCount.OutputFormat");
            this.APureCount.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ÇlÇr ÉSÉVÉbÉN; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.APureCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.APureCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.APureCount.Text = "ZZZ,ZZ9";
            this.APureCount.Top = 0F;
            this.APureCount.Width = 0.4375F;
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
            this.ASalesMoneySum.Left = 2.5625F;
            this.ASalesMoneySum.MultiLine = false;
            this.ASalesMoneySum.Name = "ASalesMoneySum";
            this.ASalesMoneySum.OutputFormat = resources.GetString("ASalesMoneySum.OutputFormat");
            this.ASalesMoneySum.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ÇlÇr ÉSÉVÉbÉN; wh" +
                "ite-space: nowrap; vertical-align: bottom; ";
            this.ASalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.ASalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.ASalesMoneySum.Text = "ZZ,ZZZ,ZZZ,ZZ9";
            this.ASalesMoneySum.Top = 0F;
            this.ASalesMoneySum.Width = 0.86F;
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
            this.ASlipCountSum.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; font-family: ÇlÇr ÉSÉVÉbÉN; wh" +
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
                "amily: ÇlÇr ñæí©; vertical-align: bottom; ";
            this.ACustomerSnm.Text = "ëççáåv";
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
            // PMSDC02012P_01A4C
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
                        "color: Black; font-family: \"ÇlÇr ñæí©\"; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ddo-char-set: 128; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ddo-char-set: 128; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; font-style: italic; ddo-char-set: 204; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMSDC02012P_01A4C_ReportStart);
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
            ((System.ComponentModel.ISupportInitialize)(this.PureCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APureCount)).EndInit();
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
        private DataDynamics.ActiveReports.Label label8;
        private DataDynamics.ActiveReports.TextBox SectionGuideSnm;
        private DataDynamics.ActiveReports.TextBox CustomerCode;
        private DataDynamics.ActiveReports.TextBox SectionCode;
        private DataDynamics.ActiveReports.TextBox SlipCountSum;
        private DataDynamics.ActiveReports.TextBox SalesMoneySum;
        private DataDynamics.ActiveReports.TextBox PureCount;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.GroupHeader GrandHeader;
        private DataDynamics.ActiveReports.GroupFooter GrandFooter;
        private DataDynamics.ActiveReports.Line line5;
        private DataDynamics.ActiveReports.TextBox APureCount;
        private DataDynamics.ActiveReports.TextBox ASalesMoneySum;
        private DataDynamics.ActiveReports.TextBox ASlipCountSum;
        private DataDynamics.ActiveReports.TextBox ACustomerSnm;
        private DataDynamics.ActiveReports.Line line7;
    }
}
