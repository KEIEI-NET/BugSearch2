namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// DCKAK02503P_01A4C_DrawingDtl の概要の説明です。
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DrawingDetail));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.ResultsSectCd = new DataDynamics.ActiveReports.TextBox();
            this.SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.RetGoodsDiscount = new DataDynamics.ActiveReports.TextBox();
            this.PureCost = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsSectCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupplierCd,
            this.ResultsSectCd,
            this.SupplierSnm,
            this.ThisTimeStockPrice,
            this.RetGoodsDiscount,
            this.PureCost,
            this.OfsThisStockTax});
            this.Detail.Height = 0.1666667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // SupplierCd
            // 
            this.SupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.DataField = "SupplierCd";
            this.SupplierCd.Height = 0.125F;
            this.SupplierCd.Left = 0.25F;
            this.SupplierCd.MultiLine = false;
            this.SupplierCd.Name = "SupplierCd";
            this.SupplierCd.OutputFormat = resources.GetString("SupplierCd.OutputFormat");
            this.SupplierCd.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.SupplierCd.Text = "123456";
            this.SupplierCd.Top = 0F;
            this.SupplierCd.Width = 0.4375F;
            // 
            // ResultsSectCd
            // 
            this.ResultsSectCd.Border.BottomColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.LeftColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.RightColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.TopColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.DataField = "ResultsSectCd";
            this.ResultsSectCd.Height = 0.125F;
            this.ResultsSectCd.Left = 0F;
            this.ResultsSectCd.MultiLine = false;
            this.ResultsSectCd.Name = "ResultsSectCd";
            this.ResultsSectCd.OutputFormat = resources.GetString("ResultsSectCd.OutputFormat");
            this.ResultsSectCd.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ ゴシック; ver" +
                "tical-align: top; ";
            this.ResultsSectCd.Text = "12";
            this.ResultsSectCd.Top = 0F;
            this.ResultsSectCd.Width = 0.1875F;
            // 
            // SupplierSnm
            // 
            this.SupplierSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.DataField = "SupplierSnm";
            this.SupplierSnm.Height = 0.125F;
            this.SupplierSnm.Left = 0.75F;
            this.SupplierSnm.MultiLine = false;
            this.SupplierSnm.Name = "SupplierSnm";
            this.SupplierSnm.OutputFormat = resources.GetString("SupplierSnm.OutputFormat");
            this.SupplierSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.SupplierSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SupplierSnm.Top = 0F;
            this.SupplierSnm.Width = 1.9375F;
            // 
            // ThisTimeStockPrice
            // 
            this.ThisTimeStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.DataField = "ThisTimeStockPrice";
            this.ThisTimeStockPrice.Height = 0.125F;
            this.ThisTimeStockPrice.Left = 4.0625F;
            this.ThisTimeStockPrice.MultiLine = false;
            this.ThisTimeStockPrice.Name = "ThisTimeStockPrice";
            this.ThisTimeStockPrice.OutputFormat = resources.GetString("ThisTimeStockPrice.OutputFormat");
            this.ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.ThisTimeStockPrice.Text = "1,234,567,890";
            this.ThisTimeStockPrice.Top = 0F;
            this.ThisTimeStockPrice.Width = 0.6875F;
            // 
            // RetGoodsDiscount
            // 
            this.RetGoodsDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGoodsDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGoodsDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.RetGoodsDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.RetGoodsDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsDiscount.DataField = "RetGoodsDiscount";
            this.RetGoodsDiscount.Height = 0.125F;
            this.RetGoodsDiscount.Left = 4.75F;
            this.RetGoodsDiscount.MultiLine = false;
            this.RetGoodsDiscount.Name = "RetGoodsDiscount";
            this.RetGoodsDiscount.OutputFormat = resources.GetString("RetGoodsDiscount.OutputFormat");
            this.RetGoodsDiscount.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.RetGoodsDiscount.Text = "1,234,567,890";
            this.RetGoodsDiscount.Top = 0F;
            this.RetGoodsDiscount.Width = 0.6875F;
            // 
            // PureCost
            // 
            this.PureCost.Border.BottomColor = System.Drawing.Color.Black;
            this.PureCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCost.Border.LeftColor = System.Drawing.Color.Black;
            this.PureCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCost.Border.RightColor = System.Drawing.Color.Black;
            this.PureCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCost.Border.TopColor = System.Drawing.Color.Black;
            this.PureCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCost.DataField = "PureCost";
            this.PureCost.Height = 0.125F;
            this.PureCost.Left = 5.4375F;
            this.PureCost.MultiLine = false;
            this.PureCost.Name = "PureCost";
            this.PureCost.OutputFormat = resources.GetString("PureCost.OutputFormat");
            this.PureCost.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.PureCost.Text = "1,234,567,890";
            this.PureCost.Top = 0F;
            this.PureCost.Width = 0.6875F;
            // 
            // OfsThisStockTax
            // 
            this.OfsThisStockTax.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.DataField = "OfsThisStockTax";
            this.OfsThisStockTax.Height = 0.125F;
            this.OfsThisStockTax.Left = 6.125F;
            this.OfsThisStockTax.MultiLine = false;
            this.OfsThisStockTax.Name = "OfsThisStockTax";
            this.OfsThisStockTax.OutputFormat = resources.GetString("OfsThisStockTax.OutputFormat");
            this.OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.OfsThisStockTax.Text = "1,234,567,890";
            this.OfsThisStockTax.Top = 0F;
            this.OfsThisStockTax.Width = 0.6875F;
            // 
            // DrawingDetail
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.885417F;
            this.Sections.Add(this.Detail);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsSectCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.TextBox SupplierCd;
        private DataDynamics.ActiveReports.TextBox ResultsSectCd;
        private DataDynamics.ActiveReports.TextBox SupplierSnm;
        private DataDynamics.ActiveReports.TextBox ThisTimeStockPrice;
        private DataDynamics.ActiveReports.TextBox RetGoodsDiscount;
        private DataDynamics.ActiveReports.TextBox PureCost;
        private DataDynamics.ActiveReports.TextBox OfsThisStockTax;

    }
}
