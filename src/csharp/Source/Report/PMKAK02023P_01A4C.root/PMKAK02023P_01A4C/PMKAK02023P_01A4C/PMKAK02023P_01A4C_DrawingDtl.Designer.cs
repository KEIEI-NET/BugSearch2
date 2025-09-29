namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMKAK02023P_01A4C_DrawingDtl の概要の説明です。
    /// </summary>
    partial class DrawingDetail
    {
        private DataDynamics.ActiveReports.Detail Detail;

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
            this.CashPayment = new DataDynamics.ActiveReports.TextBox();
            this.LastTimeAccPay = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeTtlBlcAcPay = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.ThisRgdsDisPric = new DataDynamics.ActiveReports.TextBox();
            this.PureStock = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.StockPricTax = new DataDynamics.ActiveReports.TextBox();
            this.StckTtlAccPayBalance = new DataDynamics.ActiveReports.TextBox();
            this.StockSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.TrfrPayment = new DataDynamics.ActiveReports.TextBox();
            this.CheckPayment = new DataDynamics.ActiveReports.TextBox();
            this.DraftPayment = new DataDynamics.ActiveReports.TextBox();
            this.OffsetPayment = new DataDynamics.ActiveReports.TextBox();
            this.OthsPayment = new DataDynamics.ActiveReports.TextBox();
            this.FundTransferPayment = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeFeePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDisPayNrml = new DataDynamics.ActiveReports.TextBox();
            this.PayeeSnm = new DataDynamics.ActiveReports.TextBox();
            this.PayeeCode = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CashPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeAccPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcAcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisRgdsDisPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPricTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckTtlAccPayBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrfrPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OthsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FundTransferPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisPayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CashPayment,
            this.LastTimeAccPay,
            this.ThisTimePayNrml,
            this.ThisTimeTtlBlcAcPay,
            this.ThisTimeStockPrice,
            this.ThisRgdsDisPric,
            this.PureStock,
            this.OfsThisStockTax,
            this.StockPricTax,
            this.StckTtlAccPayBalance,
            this.StockSlipCount,
            this.TrfrPayment,
            this.CheckPayment,
            this.DraftPayment,
            this.OffsetPayment,
            this.OthsPayment,
            this.FundTransferPayment,
            this.ThisTimeFeePayNrml,
            this.ThisTimeDisPayNrml,
            this.PayeeSnm,
            this.PayeeCode,
            this.AddUpSecCode});
            this.Detail.Height = 0.2291667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // CashPayment
            // 
            this.CashPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.CashPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.CashPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashPayment.Border.RightColor = System.Drawing.Color.Black;
            this.CashPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashPayment.Border.TopColor = System.Drawing.Color.Black;
            this.CashPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashPayment.DataField = "CashPayment";
            this.CashPayment.Height = 0.125F;
            this.CashPayment.Left = 2.3125F;
            this.CashPayment.MultiLine = false;
            this.CashPayment.Name = "CashPayment";
            this.CashPayment.OutputFormat = resources.GetString("CashPayment.OutputFormat");
            this.CashPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.CashPayment.Text = "11,234,567,890";
            this.CashPayment.Top = 0.125F;
            this.CashPayment.Width = 0.8125F;
            // 
            // LastTimeAccPay
            // 
            this.LastTimeAccPay.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimeAccPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccPay.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimeAccPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccPay.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimeAccPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccPay.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimeAccPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccPay.DataField = "LastTimeAccPay";
            this.LastTimeAccPay.Height = 0.125F;
            this.LastTimeAccPay.Left = 2.3125F;
            this.LastTimeAccPay.MultiLine = false;
            this.LastTimeAccPay.Name = "LastTimeAccPay";
            this.LastTimeAccPay.OutputFormat = resources.GetString("LastTimeAccPay.OutputFormat");
            this.LastTimeAccPay.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.LastTimeAccPay.Text = "11,234,567,890";
            this.LastTimeAccPay.Top = 0F;
            this.LastTimeAccPay.Width = 0.8125F;
            // 
            // ThisTimePayNrml
            // 
            this.ThisTimePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.DataField = "ThisTimePayNrml";
            this.ThisTimePayNrml.Height = 0.125F;
            this.ThisTimePayNrml.Left = 3.125F;
            this.ThisTimePayNrml.MultiLine = false;
            this.ThisTimePayNrml.Name = "ThisTimePayNrml";
            this.ThisTimePayNrml.OutputFormat = resources.GetString("ThisTimePayNrml.OutputFormat");
            this.ThisTimePayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimePayNrml.Text = "1,234,567,890";
            this.ThisTimePayNrml.Top = 0F;
            this.ThisTimePayNrml.Width = 0.8125F;
            // 
            // ThisTimeTtlBlcAcPay
            // 
            this.ThisTimeTtlBlcAcPay.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcPay.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcPay.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcPay.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcPay.DataField = "ThisTimeTtlBlcAcPay";
            this.ThisTimeTtlBlcAcPay.Height = 0.125F;
            this.ThisTimeTtlBlcAcPay.Left = 3.9375F;
            this.ThisTimeTtlBlcAcPay.MultiLine = false;
            this.ThisTimeTtlBlcAcPay.Name = "ThisTimeTtlBlcAcPay";
            this.ThisTimeTtlBlcAcPay.OutputFormat = resources.GetString("ThisTimeTtlBlcAcPay.OutputFormat");
            this.ThisTimeTtlBlcAcPay.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeTtlBlcAcPay.Text = "11,234,567,890";
            this.ThisTimeTtlBlcAcPay.Top = 0F;
            this.ThisTimeTtlBlcAcPay.Width = 0.8125F;
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
            this.ThisTimeStockPrice.Left = 4.75F;
            this.ThisTimeStockPrice.MultiLine = false;
            this.ThisTimeStockPrice.Name = "ThisTimeStockPrice";
            this.ThisTimeStockPrice.OutputFormat = resources.GetString("ThisTimeStockPrice.OutputFormat");
            this.ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeStockPrice.Text = "1,234,567,890";
            this.ThisTimeStockPrice.Top = 0F;
            this.ThisTimeStockPrice.Width = 0.8125F;
            // 
            // ThisRgdsDisPric
            // 
            this.ThisRgdsDisPric.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisRgdsDisPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDisPric.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisRgdsDisPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDisPric.Border.RightColor = System.Drawing.Color.Black;
            this.ThisRgdsDisPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDisPric.Border.TopColor = System.Drawing.Color.Black;
            this.ThisRgdsDisPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDisPric.DataField = "ThisRgdsDisPric";
            this.ThisRgdsDisPric.Height = 0.125F;
            this.ThisRgdsDisPric.Left = 5.5625F;
            this.ThisRgdsDisPric.MultiLine = false;
            this.ThisRgdsDisPric.Name = "ThisRgdsDisPric";
            this.ThisRgdsDisPric.OutputFormat = resources.GetString("ThisRgdsDisPric.OutputFormat");
            this.ThisRgdsDisPric.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisRgdsDisPric.Text = "1,234,567,890";
            this.ThisRgdsDisPric.Top = 0F;
            this.ThisRgdsDisPric.Width = 0.8125F;
            // 
            // PureStock
            // 
            this.PureStock.Border.BottomColor = System.Drawing.Color.Black;
            this.PureStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureStock.Border.LeftColor = System.Drawing.Color.Black;
            this.PureStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureStock.Border.RightColor = System.Drawing.Color.Black;
            this.PureStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureStock.Border.TopColor = System.Drawing.Color.Black;
            this.PureStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureStock.DataField = "PureStock";
            this.PureStock.Height = 0.125F;
            this.PureStock.Left = 6.375F;
            this.PureStock.MultiLine = false;
            this.PureStock.Name = "PureStock";
            this.PureStock.OutputFormat = resources.GetString("PureStock.OutputFormat");
            this.PureStock.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PureStock.Text = "1,234,567,890";
            this.PureStock.Top = 0F;
            this.PureStock.Width = 0.8125F;
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
            this.OfsThisStockTax.Left = 7.1875F;
            this.OfsThisStockTax.MultiLine = false;
            this.OfsThisStockTax.Name = "OfsThisStockTax";
            this.OfsThisStockTax.OutputFormat = resources.GetString("OfsThisStockTax.OutputFormat");
            this.OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OfsThisStockTax.Text = "1,234,567,890";
            this.OfsThisStockTax.Top = 0F;
            this.OfsThisStockTax.Width = 0.8125F;
            // 
            // StockPricTax
            // 
            this.StockPricTax.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPricTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPricTax.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPricTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPricTax.Border.RightColor = System.Drawing.Color.Black;
            this.StockPricTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPricTax.Border.TopColor = System.Drawing.Color.Black;
            this.StockPricTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPricTax.DataField = "StockPricTax";
            this.StockPricTax.Height = 0.125F;
            this.StockPricTax.Left = 8F;
            this.StockPricTax.MultiLine = false;
            this.StockPricTax.Name = "StockPricTax";
            this.StockPricTax.OutputFormat = resources.GetString("StockPricTax.OutputFormat");
            this.StockPricTax.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockPricTax.Text = "1,234,567,890";
            this.StockPricTax.Top = 0F;
            this.StockPricTax.Width = 0.8125F;
            // 
            // StckTtlAccPayBalance
            // 
            this.StckTtlAccPayBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBalance.Border.RightColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBalance.Border.TopColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBalance.DataField = "StckTtlAccPayBalance";
            this.StckTtlAccPayBalance.Height = 0.125F;
            this.StckTtlAccPayBalance.Left = 8.8125F;
            this.StckTtlAccPayBalance.MultiLine = false;
            this.StckTtlAccPayBalance.Name = "StckTtlAccPayBalance";
            this.StckTtlAccPayBalance.OutputFormat = resources.GetString("StckTtlAccPayBalance.OutputFormat");
            this.StckTtlAccPayBalance.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StckTtlAccPayBalance.Text = "1,234,567,890";
            this.StckTtlAccPayBalance.Top = 0F;
            this.StckTtlAccPayBalance.Width = 0.8125F;
            // 
            // StockSlipCount
            // 
            this.StockSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.StockSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.StockSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.StockSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.StockSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSlipCount.DataField = "StockSlipCount";
            this.StockSlipCount.Height = 0.125F;
            this.StockSlipCount.Left = 9.6875F;
            this.StockSlipCount.MultiLine = false;
            this.StockSlipCount.Name = "StockSlipCount";
            this.StockSlipCount.OutputFormat = resources.GetString("StockSlipCount.OutputFormat");
            this.StockSlipCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockSlipCount.Text = "234,567";
            this.StockSlipCount.Top = 0F;
            this.StockSlipCount.Width = 0.5F;
            // 
            // TrfrPayment
            // 
            this.TrfrPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.TrfrPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.TrfrPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrPayment.Border.RightColor = System.Drawing.Color.Black;
            this.TrfrPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrPayment.Border.TopColor = System.Drawing.Color.Black;
            this.TrfrPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrPayment.DataField = "TrfrPayment";
            this.TrfrPayment.Height = 0.125F;
            this.TrfrPayment.Left = 3.125F;
            this.TrfrPayment.MultiLine = false;
            this.TrfrPayment.Name = "TrfrPayment";
            this.TrfrPayment.OutputFormat = resources.GetString("TrfrPayment.OutputFormat");
            this.TrfrPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TrfrPayment.Text = "11,234,567,890";
            this.TrfrPayment.Top = 0.125F;
            this.TrfrPayment.Width = 0.8125F;
            // 
            // CheckPayment
            // 
            this.CheckPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckPayment.Border.RightColor = System.Drawing.Color.Black;
            this.CheckPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckPayment.Border.TopColor = System.Drawing.Color.Black;
            this.CheckPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckPayment.DataField = "CheckPayment";
            this.CheckPayment.Height = 0.125F;
            this.CheckPayment.Left = 3.9375F;
            this.CheckPayment.MultiLine = false;
            this.CheckPayment.Name = "CheckPayment";
            this.CheckPayment.OutputFormat = resources.GetString("CheckPayment.OutputFormat");
            this.CheckPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.CheckPayment.Text = "11,234,567,890";
            this.CheckPayment.Top = 0.125F;
            this.CheckPayment.Width = 0.8125F;
            // 
            // DraftPayment
            // 
            this.DraftPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.DraftPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.DraftPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayment.Border.RightColor = System.Drawing.Color.Black;
            this.DraftPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayment.Border.TopColor = System.Drawing.Color.Black;
            this.DraftPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayment.DataField = "DraftPayment";
            this.DraftPayment.Height = 0.125F;
            this.DraftPayment.Left = 4.75F;
            this.DraftPayment.MultiLine = false;
            this.DraftPayment.Name = "DraftPayment";
            this.DraftPayment.OutputFormat = resources.GetString("DraftPayment.OutputFormat");
            this.DraftPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DraftPayment.Text = "11,234,567,890";
            this.DraftPayment.Top = 0.125F;
            this.DraftPayment.Width = 0.8125F;
            // 
            // OffsetPayment
            // 
            this.OffsetPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.OffsetPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.OffsetPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetPayment.Border.RightColor = System.Drawing.Color.Black;
            this.OffsetPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetPayment.Border.TopColor = System.Drawing.Color.Black;
            this.OffsetPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetPayment.DataField = "OffsetPayment";
            this.OffsetPayment.Height = 0.125F;
            this.OffsetPayment.Left = 5.5625F;
            this.OffsetPayment.MultiLine = false;
            this.OffsetPayment.Name = "OffsetPayment";
            this.OffsetPayment.OutputFormat = resources.GetString("OffsetPayment.OutputFormat");
            this.OffsetPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OffsetPayment.Text = "11,234,567,890";
            this.OffsetPayment.Top = 0.125F;
            this.OffsetPayment.Width = 0.8125F;
            // 
            // OthsPayment
            // 
            this.OthsPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.OthsPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.OthsPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsPayment.Border.RightColor = System.Drawing.Color.Black;
            this.OthsPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsPayment.Border.TopColor = System.Drawing.Color.Black;
            this.OthsPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsPayment.DataField = "OthsPayment";
            this.OthsPayment.Height = 0.125F;
            this.OthsPayment.Left = 6.375F;
            this.OthsPayment.MultiLine = false;
            this.OthsPayment.Name = "OthsPayment";
            this.OthsPayment.OutputFormat = resources.GetString("OthsPayment.OutputFormat");
            this.OthsPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OthsPayment.Text = "11,234,567,890";
            this.OthsPayment.Top = 0.125F;
            this.OthsPayment.Width = 0.8125F;
            // 
            // FundTransferPayment
            // 
            this.FundTransferPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.FundTransferPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.FundTransferPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferPayment.Border.RightColor = System.Drawing.Color.Black;
            this.FundTransferPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferPayment.Border.TopColor = System.Drawing.Color.Black;
            this.FundTransferPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferPayment.DataField = "FundTransferPayment";
            this.FundTransferPayment.Height = 0.125F;
            this.FundTransferPayment.Left = 7.1875F;
            this.FundTransferPayment.MultiLine = false;
            this.FundTransferPayment.Name = "FundTransferPayment";
            this.FundTransferPayment.OutputFormat = resources.GetString("FundTransferPayment.OutputFormat");
            this.FundTransferPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.FundTransferPayment.Text = "11,234,567,890";
            this.FundTransferPayment.Top = 0.125F;
            this.FundTransferPayment.Width = 0.8125F;
            // 
            // ThisTimeFeePayNrml
            // 
            this.ThisTimeFeePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeFeePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeFeePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeFeePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeFeePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeePayNrml.DataField = "ThisTimeFeePayNrml";
            this.ThisTimeFeePayNrml.Height = 0.125F;
            this.ThisTimeFeePayNrml.Left = 8F;
            this.ThisTimeFeePayNrml.MultiLine = false;
            this.ThisTimeFeePayNrml.Name = "ThisTimeFeePayNrml";
            this.ThisTimeFeePayNrml.OutputFormat = resources.GetString("ThisTimeFeePayNrml.OutputFormat");
            this.ThisTimeFeePayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeFeePayNrml.Text = "11,234,567,890";
            this.ThisTimeFeePayNrml.Top = 0.125F;
            this.ThisTimeFeePayNrml.Width = 0.8125F;
            // 
            // ThisTimeDisPayNrml
            // 
            this.ThisTimeDisPayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeDisPayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisPayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeDisPayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisPayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeDisPayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisPayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeDisPayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisPayNrml.DataField = "ThisTimeDisPayNrml";
            this.ThisTimeDisPayNrml.Height = 0.125F;
            this.ThisTimeDisPayNrml.Left = 8.8125F;
            this.ThisTimeDisPayNrml.MultiLine = false;
            this.ThisTimeDisPayNrml.Name = "ThisTimeDisPayNrml";
            this.ThisTimeDisPayNrml.OutputFormat = resources.GetString("ThisTimeDisPayNrml.OutputFormat");
            this.ThisTimeDisPayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeDisPayNrml.Text = "11,234,567,890";
            this.ThisTimeDisPayNrml.Top = 0.125F;
            this.ThisTimeDisPayNrml.Width = 0.8125F;
            // 
            // PayeeSnm
            // 
            this.PayeeSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.RightColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.TopColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.DataField = "PayeeSnm";
            this.PayeeSnm.Height = 0.125F;
            this.PayeeSnm.Left = 0.75F;
            this.PayeeSnm.MultiLine = false;
            this.PayeeSnm.Name = "PayeeSnm";
            this.PayeeSnm.OutputFormat = resources.GetString("PayeeSnm.OutputFormat");
            this.PayeeSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PayeeSnm.Text = "支払先略称６７８９０";
            this.PayeeSnm.Top = 0F;
            this.PayeeSnm.Width = 1.14F;
            // 
            // PayeeCode
            // 
            this.PayeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.DataField = "PayeeCode";
            this.PayeeCode.Height = 0.125F;
            this.PayeeCode.Left = 0.25F;
            this.PayeeCode.MultiLine = false;
            this.PayeeCode.Name = "PayeeCode";
            this.PayeeCode.OutputFormat = resources.GetString("PayeeCode.OutputFormat");
            this.PayeeCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PayeeCode.Text = "123456";
            this.PayeeCode.Top = 0F;
            this.PayeeCode.Width = 0.4375F;
            // 
            // AddUpSecCode
            // 
            this.AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.DataField = "AddUpSecCode";
            this.AddUpSecCode.Height = 0.125F;
            this.AddUpSecCode.Left = 0F;
            this.AddUpSecCode.MultiLine = false;
            this.AddUpSecCode.Name = "AddUpSecCode";
            this.AddUpSecCode.OutputFormat = resources.GetString("AddUpSecCode.OutputFormat");
            this.AddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-" +
                "space: inherit; vertical-align: top; ";
            this.AddUpSecCode.Text = "00";
            this.AddUpSecCode.Top = 0F;
            this.AddUpSecCode.Width = 0.1875F;
            // 
            // DrawingDetail
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 10.375F;
            this.Sections.Add(this.Detail);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.CashPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeAccPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcAcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisRgdsDisPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPricTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckTtlAccPayBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrfrPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OthsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FundTransferPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisPayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.TextBox CashPayment;
        private DataDynamics.ActiveReports.TextBox LastTimeAccPay;
        private DataDynamics.ActiveReports.TextBox ThisTimePayNrml;
        private DataDynamics.ActiveReports.TextBox ThisTimeTtlBlcAcPay;
        private DataDynamics.ActiveReports.TextBox ThisTimeStockPrice;
        private DataDynamics.ActiveReports.TextBox ThisRgdsDisPric;
        private DataDynamics.ActiveReports.TextBox PureStock;
        private DataDynamics.ActiveReports.TextBox OfsThisStockTax;
        private DataDynamics.ActiveReports.TextBox StockPricTax;
        private DataDynamics.ActiveReports.TextBox StckTtlAccPayBalance;
        private DataDynamics.ActiveReports.TextBox StockSlipCount;
        private DataDynamics.ActiveReports.TextBox TrfrPayment;
        private DataDynamics.ActiveReports.TextBox CheckPayment;
        private DataDynamics.ActiveReports.TextBox DraftPayment;
        private DataDynamics.ActiveReports.TextBox OffsetPayment;
        private DataDynamics.ActiveReports.TextBox OthsPayment;
        private DataDynamics.ActiveReports.TextBox FundTransferPayment;
        private DataDynamics.ActiveReports.TextBox ThisTimeFeePayNrml;
        private DataDynamics.ActiveReports.TextBox ThisTimeDisPayNrml;
        private DataDynamics.ActiveReports.TextBox PayeeSnm;
        private DataDynamics.ActiveReports.TextBox PayeeCode;
        private DataDynamics.ActiveReports.TextBox AddUpSecCode;

    }
}
