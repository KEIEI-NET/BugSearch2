namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// DrawingDetail の概要の説明です。
    /// </summary>
    partial class DrawingDetail
    {
        private DataDynamics.ActiveReports.Detail Detail;

        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof( DrawingDetail ) );
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.ClaimSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.DemandBalance = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeTtlBlcDmd = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisSalesTax = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisSalesSum = new DataDynamics.ActiveReports.TextBox();
            this.AfCalDemandPrice = new DataDynamics.ActiveReports.TextBox();
            this.SaleslSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.AcpOdrTtl3TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.AcpOdrTtl2TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv101 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv102 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv107 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv105 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv106 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv109 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv112 = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemandBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfCalDemandPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleslSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl3TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl2TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.DemandBalance,
            this.textBox3,
            this.ClaimSectionCode,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.ThisTimeDmdNrml,
            this.ThisTimeTtlBlcDmd,
            this.OfsThisSalesTax,
            this.OfsThisSalesSum,
            this.AfCalDemandPrice,
            this.SaleslSlipCount,
            this.AcpOdrTtl3TmBfBlDmd,
            this.AcpOdrTtl2TmBfBlDmd,
            this.LastTimeDemand,
            this.MoneyKindDiv101,
            this.MoneyKindDiv102,
            this.MoneyKindDiv107,
            this.MoneyKindDiv105,
            this.MoneyKindDiv106,
            this.MoneyKindDiv109,
            this.MoneyKindDiv112,
            this.ThisTimeFeeDmdNrml,
            this.ThisTimeDisDmdNrml,
            this.textBox2} );
            this.Detail.Height = 0.375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.BeforePrint += new System.EventHandler( this.Detail_BeforePrint );
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "ClaimName";
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 0.8125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "ddo-char-set: 1; font-size: 7.5pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.textBox2.Text = "あいうえおかきくけこ";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 1.074167F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "ClaimCode";
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 0.25F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString( "textBox3.OutputFormat" );
            this.textBox3.Style = "ddo-char-set: 1; text-align: right; font-size: 7.5pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.textBox3.Text = "12345678";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.5F;
            // 
            // ClaimSectionCode
            // 
            this.ClaimSectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.ClaimSectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.ClaimSectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.ClaimSectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.ClaimSectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSectionCode.DataField = "ClaimSectionCode";
            this.ClaimSectionCode.Height = 0.125F;
            this.ClaimSectionCode.Left = 0F;
            this.ClaimSectionCode.MultiLine = false;
            this.ClaimSectionCode.Name = "ClaimSectionCode";
            this.ClaimSectionCode.OutputFormat = resources.GetString( "ClaimSectionCode.OutputFormat" );
            this.ClaimSectionCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.ClaimSectionCode.Text = "99";
            this.ClaimSectionCode.Top = 0F;
            this.ClaimSectionCode.Width = 0.1875F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DataField = "ThisTimeSales";
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 4.03125F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString( "textBox4.OutputFormat" );
            this.textBox4.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.textBox4.Text = "2,345,678,901";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.695F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DataField = "ThisSalesPricRgdsDis";
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 4.713F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString( "textBox5.OutputFormat" );
            this.textBox5.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.textBox5.Text = "2,345,678,901";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.695F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.DataField = "NetSales";
            this.textBox6.Height = 0.125F;
            this.textBox6.Left = 5.40625F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString( "textBox6.OutputFormat" );
            this.textBox6.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.textBox6.Text = "2,345,678,901";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.695F;
            // 
            // DemandBalance
            // 
            this.DemandBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.DemandBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DemandBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.DemandBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DemandBalance.Border.RightColor = System.Drawing.Color.Black;
            this.DemandBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DemandBalance.Border.TopColor = System.Drawing.Color.Black;
            this.DemandBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DemandBalance.DataField = "DemandBalance";
            this.DemandBalance.Height = 0.125F;
            this.DemandBalance.Left = 1.96825F;
            this.DemandBalance.MultiLine = false;
            this.DemandBalance.Name = "DemandBalance";
            this.DemandBalance.OutputFormat = resources.GetString( "DemandBalance.OutputFormat" );
            this.DemandBalance.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.DemandBalance.Text = "2,345,678,901";
            this.DemandBalance.Top = 0F;
            this.DemandBalance.Width = 0.695F;
            // 
            // ThisTimeDmdNrml
            // 
            this.ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.ThisTimeDmdNrml.Height = 0.125F;
            this.ThisTimeDmdNrml.Left = 2.65625F;
            this.ThisTimeDmdNrml.MultiLine = false;
            this.ThisTimeDmdNrml.Name = "ThisTimeDmdNrml";
            this.ThisTimeDmdNrml.OutputFormat = resources.GetString( "ThisTimeDmdNrml.OutputFormat" );
            this.ThisTimeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.ThisTimeDmdNrml.Text = "2,345,678,901";
            this.ThisTimeDmdNrml.Top = 0F;
            this.ThisTimeDmdNrml.Width = 0.695F;
            // 
            // ThisTimeTtlBlcDmd
            // 
            this.ThisTimeTtlBlcDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.DataField = "ThisTimeTtlBlcDmd";
            this.ThisTimeTtlBlcDmd.Height = 0.125F;
            this.ThisTimeTtlBlcDmd.Left = 3.34375F;
            this.ThisTimeTtlBlcDmd.MultiLine = false;
            this.ThisTimeTtlBlcDmd.Name = "ThisTimeTtlBlcDmd";
            this.ThisTimeTtlBlcDmd.OutputFormat = resources.GetString( "ThisTimeTtlBlcDmd.OutputFormat" );
            this.ThisTimeTtlBlcDmd.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.ThisTimeTtlBlcDmd.Text = "2,345,678,901";
            this.ThisTimeTtlBlcDmd.Top = 0F;
            this.ThisTimeTtlBlcDmd.Width = 0.695F;
            // 
            // OfsThisSalesTax
            // 
            this.OfsThisSalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.DataField = "OfsThisSalesTax";
            this.OfsThisSalesTax.Height = 0.125F;
            this.OfsThisSalesTax.Left = 6.09375F;
            this.OfsThisSalesTax.MultiLine = false;
            this.OfsThisSalesTax.Name = "OfsThisSalesTax";
            this.OfsThisSalesTax.OutputFormat = resources.GetString( "OfsThisSalesTax.OutputFormat" );
            this.OfsThisSalesTax.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.OfsThisSalesTax.Text = "2,345,678,901";
            this.OfsThisSalesTax.Top = 0F;
            this.OfsThisSalesTax.Width = 0.695F;
            // 
            // OfsThisSalesSum
            // 
            this.OfsThisSalesSum.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisSalesSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesSum.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisSalesSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesSum.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisSalesSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesSum.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisSalesSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesSum.DataField = "OfsThisSalesSum";
            this.OfsThisSalesSum.Height = 0.125F;
            this.OfsThisSalesSum.Left = 6.78125F;
            this.OfsThisSalesSum.MultiLine = false;
            this.OfsThisSalesSum.Name = "OfsThisSalesSum";
            this.OfsThisSalesSum.OutputFormat = resources.GetString( "OfsThisSalesSum.OutputFormat" );
            this.OfsThisSalesSum.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.OfsThisSalesSum.Text = "2,345,678,901";
            this.OfsThisSalesSum.Top = 0F;
            this.OfsThisSalesSum.Width = 0.695F;
            // 
            // AfCalDemandPrice
            // 
            this.AfCalDemandPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.DataField = "AfCalDemandPrice";
            this.AfCalDemandPrice.Height = 0.125F;
            this.AfCalDemandPrice.Left = 7.463F;
            this.AfCalDemandPrice.MultiLine = false;
            this.AfCalDemandPrice.Name = "AfCalDemandPrice";
            this.AfCalDemandPrice.OutputFormat = resources.GetString( "AfCalDemandPrice.OutputFormat" );
            this.AfCalDemandPrice.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.AfCalDemandPrice.Text = "2,345,678,901";
            this.AfCalDemandPrice.Top = 0F;
            this.AfCalDemandPrice.Width = 0.695F;
            // 
            // SaleslSlipCount
            // 
            this.SaleslSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SaleslSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SaleslSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SaleslSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SaleslSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.SaleslSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SaleslSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.SaleslSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SaleslSlipCount.DataField = "SaleslSlipCount";
            this.SaleslSlipCount.Height = 0.125F;
            this.SaleslSlipCount.Left = 8.94725F;
            this.SaleslSlipCount.MultiLine = false;
            this.SaleslSlipCount.Name = "SaleslSlipCount";
            this.SaleslSlipCount.OutputFormat = resources.GetString( "SaleslSlipCount.OutputFormat" );
            this.SaleslSlipCount.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.SaleslSlipCount.Text = "123,456";
            this.SaleslSlipCount.Top = 0F;
            this.SaleslSlipCount.Width = 0.59F;
            // 
            // AcpOdrTtl3TmBfBlDmd
            // 
            this.AcpOdrTtl3TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.AcpOdrTtl3TmBfBlDmd.Height = 0.125F;
            this.AcpOdrTtl3TmBfBlDmd.Left = 1.968F;
            this.AcpOdrTtl3TmBfBlDmd.MultiLine = false;
            this.AcpOdrTtl3TmBfBlDmd.Name = "AcpOdrTtl3TmBfBlDmd";
            this.AcpOdrTtl3TmBfBlDmd.OutputFormat = resources.GetString( "AcpOdrTtl3TmBfBlDmd.OutputFormat" );
            this.AcpOdrTtl3TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.AcpOdrTtl3TmBfBlDmd.Text = "2,345,678,901";
            this.AcpOdrTtl3TmBfBlDmd.Top = 0.125F;
            this.AcpOdrTtl3TmBfBlDmd.Width = 0.695F;
            // 
            // AcpOdrTtl2TmBfBlDmd
            // 
            this.AcpOdrTtl2TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.AcpOdrTtl2TmBfBlDmd.Height = 0.125F;
            this.AcpOdrTtl2TmBfBlDmd.Left = 2.65625F;
            this.AcpOdrTtl2TmBfBlDmd.MultiLine = false;
            this.AcpOdrTtl2TmBfBlDmd.Name = "AcpOdrTtl2TmBfBlDmd";
            this.AcpOdrTtl2TmBfBlDmd.OutputFormat = resources.GetString( "AcpOdrTtl2TmBfBlDmd.OutputFormat" );
            this.AcpOdrTtl2TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.AcpOdrTtl2TmBfBlDmd.Text = "2,345,678,901";
            this.AcpOdrTtl2TmBfBlDmd.Top = 0.125F;
            this.AcpOdrTtl2TmBfBlDmd.Width = 0.695F;
            // 
            // LastTimeDemand
            // 
            this.LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.DataField = "LastTimeDemand";
            this.LastTimeDemand.Height = 0.125F;
            this.LastTimeDemand.Left = 3.34375F;
            this.LastTimeDemand.MultiLine = false;
            this.LastTimeDemand.Name = "LastTimeDemand";
            this.LastTimeDemand.OutputFormat = resources.GetString( "LastTimeDemand.OutputFormat" );
            this.LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.LastTimeDemand.Text = "2,345,678,901";
            this.LastTimeDemand.Top = 0.125F;
            this.LastTimeDemand.Width = 0.695F;
            // 
            // MoneyKindDiv101
            // 
            this.MoneyKindDiv101.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv101.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv101.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv101.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv101.DataField = "MoneyKindDiv101";
            this.MoneyKindDiv101.Height = 0.125F;
            this.MoneyKindDiv101.Left = 4.03125F;
            this.MoneyKindDiv101.MultiLine = false;
            this.MoneyKindDiv101.Name = "MoneyKindDiv101";
            this.MoneyKindDiv101.OutputFormat = resources.GetString( "MoneyKindDiv101.OutputFormat" );
            this.MoneyKindDiv101.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv101.Text = "2,345,678,901";
            this.MoneyKindDiv101.Top = 0.125F;
            this.MoneyKindDiv101.Width = 0.695F;
            // 
            // MoneyKindDiv102
            // 
            this.MoneyKindDiv102.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv102.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv102.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv102.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv102.DataField = "MoneyKindDiv102";
            this.MoneyKindDiv102.Height = 0.125F;
            this.MoneyKindDiv102.Left = 4.713F;
            this.MoneyKindDiv102.MultiLine = false;
            this.MoneyKindDiv102.Name = "MoneyKindDiv102";
            this.MoneyKindDiv102.OutputFormat = resources.GetString( "MoneyKindDiv102.OutputFormat" );
            this.MoneyKindDiv102.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv102.Text = "2,345,678,901";
            this.MoneyKindDiv102.Top = 0.125F;
            this.MoneyKindDiv102.Width = 0.695F;
            // 
            // MoneyKindDiv107
            // 
            this.MoneyKindDiv107.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv107.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv107.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv107.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv107.DataField = "MoneyKindDiv107";
            this.MoneyKindDiv107.Height = 0.125F;
            this.MoneyKindDiv107.Left = 5.40625F;
            this.MoneyKindDiv107.MultiLine = false;
            this.MoneyKindDiv107.Name = "MoneyKindDiv107";
            this.MoneyKindDiv107.OutputFormat = resources.GetString( "MoneyKindDiv107.OutputFormat" );
            this.MoneyKindDiv107.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv107.Text = "2,345,678,901";
            this.MoneyKindDiv107.Top = 0.125F;
            this.MoneyKindDiv107.Width = 0.695F;
            // 
            // MoneyKindDiv105
            // 
            this.MoneyKindDiv105.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv105.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv105.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv105.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv105.DataField = "MoneyKindDiv105";
            this.MoneyKindDiv105.Height = 0.125F;
            this.MoneyKindDiv105.Left = 6.09375F;
            this.MoneyKindDiv105.MultiLine = false;
            this.MoneyKindDiv105.Name = "MoneyKindDiv105";
            this.MoneyKindDiv105.OutputFormat = resources.GetString( "MoneyKindDiv105.OutputFormat" );
            this.MoneyKindDiv105.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv105.Text = "2,345,678,901";
            this.MoneyKindDiv105.Top = 0.125F;
            this.MoneyKindDiv105.Width = 0.695F;
            // 
            // MoneyKindDiv106
            // 
            this.MoneyKindDiv106.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv106.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv106.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv106.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv106.DataField = "MoneyKindDiv106";
            this.MoneyKindDiv106.Height = 0.125F;
            this.MoneyKindDiv106.Left = 6.78125F;
            this.MoneyKindDiv106.MultiLine = false;
            this.MoneyKindDiv106.Name = "MoneyKindDiv106";
            this.MoneyKindDiv106.OutputFormat = resources.GetString( "MoneyKindDiv106.OutputFormat" );
            this.MoneyKindDiv106.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv106.Text = "2,345,678,901";
            this.MoneyKindDiv106.Top = 0.125F;
            this.MoneyKindDiv106.Width = 0.695F;
            // 
            // MoneyKindDiv109
            // 
            this.MoneyKindDiv109.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv109.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv109.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv109.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv109.DataField = "MoneyKindDiv109";
            this.MoneyKindDiv109.Height = 0.125F;
            this.MoneyKindDiv109.Left = 7.463F;
            this.MoneyKindDiv109.MultiLine = false;
            this.MoneyKindDiv109.Name = "MoneyKindDiv109";
            this.MoneyKindDiv109.OutputFormat = resources.GetString( "MoneyKindDiv109.OutputFormat" );
            this.MoneyKindDiv109.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv109.Text = "2,345,678,901";
            this.MoneyKindDiv109.Top = 0.125F;
            this.MoneyKindDiv109.Width = 0.695F;
            // 
            // MoneyKindDiv112
            // 
            this.MoneyKindDiv112.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv112.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv112.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv112.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv112.DataField = "MoneyKindDiv112";
            this.MoneyKindDiv112.Height = 0.125F;
            this.MoneyKindDiv112.Left = 8.15625F;
            this.MoneyKindDiv112.MultiLine = false;
            this.MoneyKindDiv112.Name = "MoneyKindDiv112";
            this.MoneyKindDiv112.OutputFormat = resources.GetString( "MoneyKindDiv112.OutputFormat" );
            this.MoneyKindDiv112.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv112.Text = "2,345,678,901";
            this.MoneyKindDiv112.Top = 0.125F;
            this.MoneyKindDiv112.Width = 0.695F;
            // 
            // ThisTimeFeeDmdNrml
            // 
            this.ThisTimeFeeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeFeeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeFeeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeFeeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeFeeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeeDmdNrml.DataField = "ThisTimeFeeDmdNrml";
            this.ThisTimeFeeDmdNrml.Height = 0.125F;
            this.ThisTimeFeeDmdNrml.Left = 8.84375F;
            this.ThisTimeFeeDmdNrml.MultiLine = false;
            this.ThisTimeFeeDmdNrml.Name = "ThisTimeFeeDmdNrml";
            this.ThisTimeFeeDmdNrml.OutputFormat = resources.GetString( "ThisTimeFeeDmdNrml.OutputFormat" );
            this.ThisTimeFeeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.ThisTimeFeeDmdNrml.Text = "2,345,678,901";
            this.ThisTimeFeeDmdNrml.Top = 0.125F;
            this.ThisTimeFeeDmdNrml.Width = 0.695F;
            // 
            // ThisTimeDisDmdNrml
            // 
            this.ThisTimeDisDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeDisDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeDisDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeDisDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeDisDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisDmdNrml.DataField = "ThisTimeDisDmdNrml";
            this.ThisTimeDisDmdNrml.Height = 0.125F;
            this.ThisTimeDisDmdNrml.Left = 9.53125F;
            this.ThisTimeDisDmdNrml.MultiLine = false;
            this.ThisTimeDisDmdNrml.Name = "ThisTimeDisDmdNrml";
            this.ThisTimeDisDmdNrml.OutputFormat = resources.GetString( "ThisTimeDisDmdNrml.OutputFormat" );
            this.ThisTimeDisDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.ThisTimeDisDmdNrml.Text = "2,345,678,901";
            this.ThisTimeDisDmdNrml.Top = 0.125F;
            this.ThisTimeDisDmdNrml.Width = 0.695F;
            // 
            // DrawingDetail
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 10.3F;
            this.Sections.Add( this.Detail );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 16pt; font-weight: bold; ", "Heading1", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 14pt; font-weight: bold; ", "Heading2", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 13pt; font-weight: bold; ", "Heading3", "Normal" ) );
            this.ReportStart += new System.EventHandler( this.DrawingDetail_ReportStart );
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemandBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfCalDemandPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleslSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl3TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl2TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox ClaimSectionCode;
        private DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.TextBox textBox6;
        private DataDynamics.ActiveReports.TextBox DemandBalance;
        private DataDynamics.ActiveReports.TextBox ThisTimeDmdNrml;
        private DataDynamics.ActiveReports.TextBox ThisTimeTtlBlcDmd;
        private DataDynamics.ActiveReports.TextBox OfsThisSalesTax;
        private DataDynamics.ActiveReports.TextBox OfsThisSalesSum;
        private DataDynamics.ActiveReports.TextBox AfCalDemandPrice;
        private DataDynamics.ActiveReports.TextBox SaleslSlipCount;
        private DataDynamics.ActiveReports.TextBox AcpOdrTtl3TmBfBlDmd;
        private DataDynamics.ActiveReports.TextBox AcpOdrTtl2TmBfBlDmd;
        private DataDynamics.ActiveReports.TextBox LastTimeDemand;
        private DataDynamics.ActiveReports.TextBox MoneyKindDiv101;
        private DataDynamics.ActiveReports.TextBox MoneyKindDiv102;
        private DataDynamics.ActiveReports.TextBox MoneyKindDiv107;
        private DataDynamics.ActiveReports.TextBox MoneyKindDiv105;
        private DataDynamics.ActiveReports.TextBox MoneyKindDiv106;
        private DataDynamics.ActiveReports.TextBox MoneyKindDiv109;
        private DataDynamics.ActiveReports.TextBox MoneyKindDiv112;
        private DataDynamics.ActiveReports.TextBox ThisTimeFeeDmdNrml;
        private DataDynamics.ActiveReports.TextBox ThisTimeDisDmdNrml;
    }
}
