namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMTEG02103P_01A4C ÇÃäTóvÇÃê‡ñæÇ≈Ç∑ÅB
    /// </summary>
    partial class PMZAI04209P_01A4C
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMZAI04209P_01A4C));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.lb_MakerNameDsp = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.tb_MaxInventoryMony = new DataDynamics.ActiveReports.TextBox();
            this.tb_InventoryMony = new DataDynamics.ActiveReports.TextBox();
            this.tb_WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.tb_Balance = new DataDynamics.ActiveReports.TextBox();
            this.tb_ItemCnt = new DataDynamics.ActiveReports.TextBox();
            this.tb_WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.tb_FooterStr1 = new DataDynamics.ActiveReports.TextBox();
            this.tb_FooterStr2 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.lb_InventoryMony = new DataDynamics.ActiveReports.Label();
            this.lb_MaxInventoryMony = new DataDynamics.ActiveReports.Label();
            this.line15 = new DataDynamics.ActiveReports.Line();
            this.lb_WarehouseCode = new DataDynamics.ActiveReports.Label();
            this.lb_ItemCnt = new DataDynamics.ActiveReports.Label();
            this.lb_WarehouseName = new DataDynamics.ActiveReports.Label();
            this.lb_Balance = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_MakerNameDsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MaxInventoryMony)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_InventoryMony)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Balance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ItemCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_FooterStr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_FooterStr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_InventoryMony)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_MaxInventoryMony)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ItemCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_Balance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.CanShrink = true;
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.tb_PrintTime,
            this.lb_MakerNameDsp,
            this.label1,
            this.Line1});
            this.pageHeader.Height = 0.28125F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.tb_ReportTitle.Left = 0.1145833F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ÇlÇr ñæí©; vertical-align: bottom; ";
            this.tb_ReportTitle.Text = "íIâµï\é¶àÍóóï\(";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 1.55F;
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
            this.Label3.Height = 0.13F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 2.947917F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-align: top; ";
            this.Label3.Text = "çÏê¨ì˙ïtÅF";
            this.Label3.Top = 0.1041667F;
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
            this.tb_PrintDate.Height = 0.13F;
            this.tb_PrintDate.Left = 3.510417F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-align: top; ";
            this.tb_PrintDate.Text = "2008/01/01";
            this.tb_PrintDate.Top = 0.1041667F;
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
            this.Label2.Height = 0.13F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 4.604167F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-align: top; ";
            this.Label2.Text = "ÉyÅ[ÉWÅF";
            this.Label2.Top = 0.1041667F;
            this.Label2.Width = 0.48F;
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
            this.tb_PrintPage.Height = 0.13F;
            this.tb_PrintPage.Left = 5.083333F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.1041667F;
            this.tb_PrintPage.Width = 0.28125F;
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
            this.tb_PrintTime.Height = 0.13F;
            this.tb_PrintTime.Left = 4.135417F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ÇlÇr ñæí©; ";
            this.tb_PrintTime.Text = "01:01";
            this.tb_PrintTime.Top = 0.1041667F;
            this.tb_PrintTime.Width = 0.375F;
            // 
            // lb_MakerNameDsp
            // 
            this.lb_MakerNameDsp.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_MakerNameDsp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_MakerNameDsp.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_MakerNameDsp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_MakerNameDsp.Border.RightColor = System.Drawing.Color.Black;
            this.lb_MakerNameDsp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_MakerNameDsp.Border.TopColor = System.Drawing.Color.Black;
            this.lb_MakerNameDsp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_MakerNameDsp.Height = 0.25F;
            this.lb_MakerNameDsp.HyperLink = "";
            this.lb_MakerNameDsp.Left = 1.604166F;
            this.lb_MakerNameDsp.MultiLine = false;
            this.lb_MakerNameDsp.Name = "lb_MakerNameDsp";
            this.lb_MakerNameDsp.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ÇlÇr ñæí©; vertical-align: bottom; ";
            this.lb_MakerNameDsp.Text = "ëSÉÅÅ[ÉJÅ[";
            this.lb_MakerNameDsp.Top = 0F;
            this.lb_MakerNameDsp.Width = 1.05F;
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
            this.label1.Height = 0.25F;
            this.label1.HyperLink = "";
            this.label1.Left = 2.604166F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ÇlÇr ñæí©; vertical-align: bottom; ";
            this.label1.Text = ")";
            this.label1.Top = 0F;
            this.label1.Width = 0.2F;
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
            this.Line1.Width = 5.4F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 5.4F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.25F;
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_MaxInventoryMony,
            this.tb_InventoryMony,
            this.tb_WarehouseCode,
            this.tb_Balance,
            this.tb_ItemCnt,
            this.tb_WarehouseName,
            this.line2});
            this.Detail.Height = 0.1770833F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // tb_MaxInventoryMony
            // 
            this.tb_MaxInventoryMony.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_MaxInventoryMony.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_MaxInventoryMony.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_MaxInventoryMony.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_MaxInventoryMony.Border.RightColor = System.Drawing.Color.Black;
            this.tb_MaxInventoryMony.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_MaxInventoryMony.Border.TopColor = System.Drawing.Color.Black;
            this.tb_MaxInventoryMony.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_MaxInventoryMony.DataField = "MaxItem";
            this.tb_MaxInventoryMony.Height = 0.15F;
            this.tb_MaxInventoryMony.Left = 3.636667F;
            this.tb_MaxInventoryMony.MultiLine = false;
            this.tb_MaxInventoryMony.Name = "tb_MaxInventoryMony";
            this.tb_MaxInventoryMony.OutputFormat = resources.GetString("tb_MaxInventoryMony.OutputFormat");
            this.tb_MaxInventoryMony.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; vertica" +
                "l-align: top; ";
            this.tb_MaxInventoryMony.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.tb_MaxInventoryMony.Top = 0F;
            this.tb_MaxInventoryMony.Width = 0.8F;
            // 
            // tb_InventoryMony
            // 
            this.tb_InventoryMony.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_InventoryMony.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_InventoryMony.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_InventoryMony.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_InventoryMony.Border.RightColor = System.Drawing.Color.Black;
            this.tb_InventoryMony.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_InventoryMony.Border.TopColor = System.Drawing.Color.Black;
            this.tb_InventoryMony.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_InventoryMony.DataField = "Mony";
            this.tb_InventoryMony.Height = 0.15F;
            this.tb_InventoryMony.Left = 3.636667F;
            this.tb_InventoryMony.MultiLine = false;
            this.tb_InventoryMony.Name = "tb_InventoryMony";
            this.tb_InventoryMony.OutputFormat = resources.GetString("tb_InventoryMony.OutputFormat");
            this.tb_InventoryMony.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; vertica" +
                "l-align: top; ";
            this.tb_InventoryMony.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.tb_InventoryMony.Top = 0F;
            this.tb_InventoryMony.Width = 0.8F;
            // 
            // tb_WarehouseCode
            // 
            this.tb_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.tb_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.tb_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_WarehouseCode.DataField = "WareCode";
            this.tb_WarehouseCode.Height = 0.15F;
            this.tb_WarehouseCode.Left = 0.1979167F;
            this.tb_WarehouseCode.MultiLine = false;
            this.tb_WarehouseCode.Name = "tb_WarehouseCode";
            this.tb_WarehouseCode.OutputFormat = resources.GetString("tb_WarehouseCode.OutputFormat");
            this.tb_WarehouseCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; vertical" +
                "-align: top; ";
            this.tb_WarehouseCode.Text = "0000";
            this.tb_WarehouseCode.Top = 0F;
            this.tb_WarehouseCode.Width = 0.3F;
            // 
            // tb_Balance
            // 
            this.tb_Balance.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_Balance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_Balance.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_Balance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_Balance.Border.RightColor = System.Drawing.Color.Black;
            this.tb_Balance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_Balance.Border.TopColor = System.Drawing.Color.Black;
            this.tb_Balance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_Balance.DataField = "Balance";
            this.tb_Balance.Height = 0.15F;
            this.tb_Balance.Left = 4.5325F;
            this.tb_Balance.MultiLine = false;
            this.tb_Balance.Name = "tb_Balance";
            this.tb_Balance.OutputFormat = resources.GetString("tb_Balance.OutputFormat");
            this.tb_Balance.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ÇlÇr ÉSÉVÉbÉN; vertical-align: top; ";
            this.tb_Balance.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.tb_Balance.Top = 0F;
            this.tb_Balance.Width = 0.8F;
            // 
            // tb_ItemCnt
            // 
            this.tb_ItemCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_ItemCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ItemCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_ItemCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ItemCnt.Border.RightColor = System.Drawing.Color.Black;
            this.tb_ItemCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ItemCnt.Border.TopColor = System.Drawing.Color.Black;
            this.tb_ItemCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ItemCnt.DataField = "Item";
            this.tb_ItemCnt.Height = 0.15F;
            this.tb_ItemCnt.Left = 2.947802F;
            this.tb_ItemCnt.MultiLine = false;
            this.tb_ItemCnt.Name = "tb_ItemCnt";
            this.tb_ItemCnt.OutputFormat = resources.GetString("tb_ItemCnt.OutputFormat");
            this.tb_ItemCnt.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ÇlÇr ÉSÉVÉbÉN; vertical-align: top; ";
            this.tb_ItemCnt.Text = "Z,ZZZ,ZZ9";
            this.tb_ItemCnt.Top = 0F;
            this.tb_ItemCnt.Width = 0.6F;
            // 
            // tb_WarehouseName
            // 
            this.tb_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_WarehouseName.DataField = "Ware";
            this.tb_WarehouseName.Height = 0.15F;
            this.tb_WarehouseName.Left = 0.6145837F;
            this.tb_WarehouseName.MultiLine = false;
            this.tb_WarehouseName.Name = "tb_WarehouseName";
            this.tb_WarehouseName.OutputFormat = resources.GetString("tb_WarehouseName.OutputFormat");
            this.tb_WarehouseName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-a" +
                "lign: top; ";
            this.tb_WarehouseName.Text = "XXXXXXXX10XXXXXXXX20XXXXXXXX30XXXXXXXX40";
            this.tb_WarehouseName.Top = 0F;
            this.tb_WarehouseName.Width = 2.28F;
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
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0F;
            this.line2.Width = 5.4F;
            this.line2.X1 = 0F;
            this.line2.X2 = 5.4F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_FooterStr1,
            this.tb_FooterStr2,
            this.line3});
            this.pageFooter.Height = 0.15F;
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
            // 
            // tb_FooterStr1
            // 
            this.tb_FooterStr1.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_FooterStr1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_FooterStr1.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_FooterStr1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_FooterStr1.Border.RightColor = System.Drawing.Color.Black;
            this.tb_FooterStr1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_FooterStr1.Border.TopColor = System.Drawing.Color.Black;
            this.tb_FooterStr1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_FooterStr1.Height = 0.15F;
            this.tb_FooterStr1.Left = 0.0625F;
            this.tb_FooterStr1.MultiLine = false;
            this.tb_FooterStr1.Name = "tb_FooterStr1";
            this.tb_FooterStr1.OutputFormat = resources.GetString("tb_FooterStr1.OutputFormat");
            this.tb_FooterStr1.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-a" +
                "lign: bottom; ";
            this.tb_FooterStr1.Text = null;
            this.tb_FooterStr1.Top = 0F;
            this.tb_FooterStr1.Width = 2F;
            // 
            // tb_FooterStr2
            // 
            this.tb_FooterStr2.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_FooterStr2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_FooterStr2.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_FooterStr2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_FooterStr2.Border.RightColor = System.Drawing.Color.Black;
            this.tb_FooterStr2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_FooterStr2.Border.TopColor = System.Drawing.Color.Black;
            this.tb_FooterStr2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_FooterStr2.Height = 0.15F;
            this.tb_FooterStr2.Left = 3.333333F;
            this.tb_FooterStr2.MultiLine = false;
            this.tb_FooterStr2.Name = "tb_FooterStr2";
            this.tb_FooterStr2.OutputFormat = resources.GetString("tb_FooterStr2.OutputFormat");
            this.tb_FooterStr2.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ÇlÇr ñæí©; vertical-" +
                "align: bottom; ";
            this.tb_FooterStr2.Text = null;
            this.tb_FooterStr2.Top = 0F;
            this.tb_FooterStr2.Width = 2F;
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
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Visible = false;
            this.line3.Width = 5.4F;
            this.line3.X1 = 0F;
            this.line3.X2 = 5.4F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Height = 0F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lb_InventoryMony,
            this.lb_MaxInventoryMony,
            this.line15,
            this.lb_WarehouseCode,
            this.lb_ItemCnt,
            this.lb_WarehouseName,
            this.lb_Balance});
            this.TitleHeader.Height = 0.1666667F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // lb_InventoryMony
            // 
            this.lb_InventoryMony.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_InventoryMony.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_InventoryMony.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_InventoryMony.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_InventoryMony.Border.RightColor = System.Drawing.Color.Black;
            this.lb_InventoryMony.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_InventoryMony.Border.TopColor = System.Drawing.Color.Black;
            this.lb_InventoryMony.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_InventoryMony.Height = 0.15F;
            this.lb_InventoryMony.HyperLink = "";
            this.lb_InventoryMony.Left = 3.636667F;
            this.lb_InventoryMony.Name = "lb_InventoryMony";
            this.lb_InventoryMony.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ÇlÇr ñæí©; vertical-align: bottom; ";
            this.lb_InventoryMony.Text = "íIâµã‡äz";
            this.lb_InventoryMony.Top = 0F;
            this.lb_InventoryMony.Width = 0.8F;
            // 
            // lb_MaxInventoryMony
            // 
            this.lb_MaxInventoryMony.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_MaxInventoryMony.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_MaxInventoryMony.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_MaxInventoryMony.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_MaxInventoryMony.Border.RightColor = System.Drawing.Color.Black;
            this.lb_MaxInventoryMony.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_MaxInventoryMony.Border.TopColor = System.Drawing.Color.Black;
            this.lb_MaxInventoryMony.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_MaxInventoryMony.Height = 0.15F;
            this.lb_MaxInventoryMony.HyperLink = "";
            this.lb_MaxInventoryMony.Left = 3.636667F;
            this.lb_MaxInventoryMony.Name = "lb_MaxInventoryMony";
            this.lb_MaxInventoryMony.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ÇlÇr ñæí©; vertical-align: bottom; ";
            this.lb_MaxInventoryMony.Text = "ç≈ëÂíIâµã‡äz";
            this.lb_MaxInventoryMony.Top = 0F;
            this.lb_MaxInventoryMony.Width = 0.8F;
            // 
            // line15
            // 
            this.line15.Border.BottomColor = System.Drawing.Color.Black;
            this.line15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.LeftColor = System.Drawing.Color.Black;
            this.line15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.RightColor = System.Drawing.Color.Black;
            this.line15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.TopColor = System.Drawing.Color.Black;
            this.line15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Height = 0F;
            this.line15.Left = 0F;
            this.line15.LineWeight = 2F;
            this.line15.Name = "line15";
            this.line15.Top = 0.15625F;
            this.line15.Width = 5.4F;
            this.line15.X1 = 0F;
            this.line15.X2 = 5.4F;
            this.line15.Y1 = 0.15625F;
            this.line15.Y2 = 0.15625F;
            // 
            // lb_WarehouseCode
            // 
            this.lb_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.lb_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.lb_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_WarehouseCode.Height = 0.15F;
            this.lb_WarehouseCode.HyperLink = "";
            this.lb_WarehouseCode.Left = 0.1979167F;
            this.lb_WarehouseCode.Name = "lb_WarehouseCode";
            this.lb_WarehouseCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ÇlÇr ñæí©; vertical-align: bottom; ";
            this.lb_WarehouseCode.Text = "ÉRÅ[Éh";
            this.lb_WarehouseCode.Top = 0F;
            this.lb_WarehouseCode.Width = 0.4F;
            // 
            // lb_ItemCnt
            // 
            this.lb_ItemCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_ItemCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ItemCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_ItemCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ItemCnt.Border.RightColor = System.Drawing.Color.Black;
            this.lb_ItemCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ItemCnt.Border.TopColor = System.Drawing.Color.Black;
            this.lb_ItemCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ItemCnt.Height = 0.15F;
            this.lb_ItemCnt.HyperLink = "";
            this.lb_ItemCnt.Left = 2.547802F;
            this.lb_ItemCnt.Name = "lb_ItemCnt";
            this.lb_ItemCnt.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ÇlÇr ñæí©; vertical-align: bottom; ";
            this.lb_ItemCnt.Text = "ÉAÉCÉeÉÄêî";
            this.lb_ItemCnt.Top = 0F;
            this.lb_ItemCnt.Width = 1F;
            // 
            // lb_WarehouseName
            // 
            this.lb_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.lb_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.lb_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_WarehouseName.Height = 0.15F;
            this.lb_WarehouseName.HyperLink = "";
            this.lb_WarehouseName.Left = 0.6145837F;
            this.lb_WarehouseName.Name = "lb_WarehouseName";
            this.lb_WarehouseName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ÇlÇr ñæí©; vertical-align: bottom; ";
            this.lb_WarehouseName.Text = "ëqå…ñºèÃ";
            this.lb_WarehouseName.Top = 0F;
            this.lb_WarehouseName.Width = 1.15F;
            // 
            // lb_Balance
            // 
            this.lb_Balance.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_Balance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Balance.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_Balance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Balance.Border.RightColor = System.Drawing.Color.Black;
            this.lb_Balance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Balance.Border.TopColor = System.Drawing.Color.Black;
            this.lb_Balance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Balance.Height = 0.15F;
            this.lb_Balance.HyperLink = "";
            this.lb_Balance.Left = 4.8325F;
            this.lb_Balance.Name = "lb_Balance";
            this.lb_Balance.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ÇlÇr ñæí©; vertical-align: bottom; ";
            this.lb_Balance.Text = "ç∑äz";
            this.lb_Balance.Top = 0F;
            this.lb_Balance.Width = 0.5F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            // 
            // PMZAI04209P_01A4C
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
            this.PrintWidth = 6F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMZAI04209P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_MakerNameDsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MaxInventoryMony)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_InventoryMony)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Balance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ItemCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_FooterStr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_FooterStr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_InventoryMony)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_MaxInventoryMony)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ItemCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_Balance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label tb_ReportTitle;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.Label lb_InventoryMony;
        private DataDynamics.ActiveReports.Label lb_MaxInventoryMony;
        private DataDynamics.ActiveReports.Line line15;
        private DataDynamics.ActiveReports.Label lb_WarehouseCode;
        private DataDynamics.ActiveReports.TextBox tb_WarehouseCode;
        private DataDynamics.ActiveReports.TextBox tb_Balance;
        private DataDynamics.ActiveReports.Label lb_ItemCnt;
        private DataDynamics.ActiveReports.Label lb_WarehouseName;
        private DataDynamics.ActiveReports.TextBox tb_ItemCnt;
        private DataDynamics.ActiveReports.TextBox tb_WarehouseName;
        private DataDynamics.ActiveReports.TextBox tb_InventoryMony;
        private DataDynamics.ActiveReports.TextBox tb_MaxInventoryMony;
        private DataDynamics.ActiveReports.Label lb_Balance;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.TextBox tb_PrintDate;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.TextBox tb_PrintPage;
        private DataDynamics.ActiveReports.TextBox tb_PrintTime;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.Line line3;
        private DataDynamics.ActiveReports.TextBox tb_FooterStr1;
        private DataDynamics.ActiveReports.TextBox tb_FooterStr2;
        private DataDynamics.ActiveReports.Label lb_MakerNameDsp;
        private DataDynamics.ActiveReports.Label label1;
    }
}
