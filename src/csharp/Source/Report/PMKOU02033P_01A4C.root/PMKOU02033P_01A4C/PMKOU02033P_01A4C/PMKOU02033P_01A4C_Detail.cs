using System;
using DataDynamics.ActiveReports;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;// ADD　2014/09/16 時シン 伝票番号印字区分の追加
using Broadleaf.Application.UIData;// ADD　2014/09/16 時シン 伝票番号印字区分の追加

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 仕入先元帳明細フォーム印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入先元帳の明細印刷を行います。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.11.14</br>
    /// <br>Update Note: 2014/09/16 時シン</br>
    /// <br>           : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
	/// <br></br>
	/// </remarks>
	public class PMKOU02033P_01_Detail : DataDynamics.ActiveReports.ActiveReport3
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
        // --- DEL　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
        //public PMKOU02033P_01_Detail()
        //{
        //    InitializeComponent();
        //}
        // --- DEL　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<
        // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
        public PMKOU02033P_01_Detail(SFCMN06002C PrintInfo)
        {
            InitializeComponent();

            this._printInfo = PrintInfo;
            this._ledgerCmnCndtn = this._printInfo.jyoken as LedgerCmnCndtn;

            if (_ledgerCmnCndtn.PrintDiv == 0)
            {
                this.SupplierSlipNo.DataField = "SupplierSlipNo";
                this.PartySaleSlipNum.DataField = "PartySaleSlipNum";
                this.SupplierSlipNo.OutputFormat = "000000000";
                this.PartySaleSlipNum.OutputFormat = "";

            }
            else
            {
                this.SupplierSlipNo.DataField = "PartySaleSlipNum";
                this.PartySaleSlipNum.DataField = "SupplierSlipNo";
                this.SupplierSlipNo.OutputFormat = "";
                this.PartySaleSlipNum.OutputFormat = "000000000";
            }
        }
        // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<
		#endregion

        // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
        // 印刷情報
        private SFCMN06002C _printInfo;

        // 抽出条件クラス
        private LedgerCmnCndtn _ledgerCmnCndtn = null;
        // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<

        private TextBox GoodsNo;
        private TextBox GoodsName;
        private TextBox StockCount;
        private TextBox PartySaleSlipNum;
        private GroupHeader RecordHeader;
        private GroupFooter RecordFooter;
        private Label label13;
        private TextBox StockPrice;
        private TextBox PaymentSubTotal;
        private Label label12;
        private TextBox TotalStockPriceTaxExc;
        private TextBox PaymentTotal;

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member
		// 拠点情報印字有無
		private bool _isSectionPrint = false;
        private TextBox StockPriceConsTax;
        private TextBox TotalStockPriceConsTax;
        private TextBox DraftPayTimeLimit;
        private TextBox SubStockPriceConsTax;
		#endregion

        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox BalanceTotal;
        private TextBox Balance;
        private TextBox SalesCustomerCode;
        private GroupHeader SlipNoHeader;
        private GroupFooter SlipNoFooter;
        private Line line3;
        private Line line1;
        private TextBox Balance2;
        private Label DetailSlitTitle;

        public int _lastTimePayment = 0;
        private int _lastTimePaymentSub = 0;
        private int _StockPriceConsTax = 0;
        public string _dtlTtl = "";

		//================================================================================
		//  プロパティ 
		//================================================================================
		#region public property
		/// <summary>
		/// 拠点情報印字有無
		/// </summary>
		public bool IsSectionPrint
		{
			set{this._isSectionPrint = value;}
		}
		#endregion
		
		//================================================================================
		//  イベント
		//================================================================================
		#region event
		/// <summary>
		/// 明細ビフォープリントイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画される前に発生します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.11.14</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// レポート用文字列編集処理
			PrintCommonLibrary.ConvertReportString(this.Detail);
		}
		#endregion
		
		// ===============================================================================
		// ActiveReportsデザイナで生成されたコード
		// ===============================================================================
		#region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox StockAddUpADate;
        private DataDynamics.ActiveReports.TextBox SupplierSlipNo;
        private DataDynamics.ActiveReports.TextBox SlipKindNm;
		private DataDynamics.ActiveReports.TextBox StockUnitPriceFl;
        private DataDynamics.ActiveReports.TextBox StockPriceTaxExc;
		private DataDynamics.ActiveReports.TextBox Payment;
        private DataDynamics.ActiveReports.TextBox SupplierSlipNote1;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKOU02033P_01_Detail));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.StockUnitPriceFl = new DataDynamics.ActiveReports.TextBox();
            this.StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Payment = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.StockCount = new DataDynamics.ActiveReports.TextBox();
            this.StockPriceConsTax = new DataDynamics.ActiveReports.TextBox();
            this.DraftPayTimeLimit = new DataDynamics.ActiveReports.TextBox();
            this.SalesCustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.Balance = new DataDynamics.ActiveReports.TextBox();
            this.StockAddUpADate = new DataDynamics.ActiveReports.TextBox();
            this.SupplierSlipNo = new DataDynamics.ActiveReports.TextBox();
            this.SlipKindNm = new DataDynamics.ActiveReports.TextBox();
            this.SupplierSlipNote1 = new DataDynamics.ActiveReports.TextBox();
            this.PartySaleSlipNum = new DataDynamics.ActiveReports.TextBox();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Balance2 = new DataDynamics.ActiveReports.TextBox();
            this.DetailSlitTitle = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.TotalStockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.PaymentTotal = new DataDynamics.ActiveReports.TextBox();
            this.TotalStockPriceConsTax = new DataDynamics.ActiveReports.TextBox();
            this.BalanceTotal = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.RecordHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.RecordFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.PaymentSubTotal = new DataDynamics.ActiveReports.TextBox();
            this.SubStockPriceConsTax = new DataDynamics.ActiveReports.TextBox();
            this.SlipNoHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SlipNoFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line3 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayTimeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAddUpADate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipKindNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNote1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailSlitTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockPriceConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubStockPriceConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.StockUnitPriceFl,
            this.StockPriceTaxExc,
            this.Payment,
            this.GoodsNo,
            this.GoodsName,
            this.StockCount,
            this.StockPriceConsTax,
            this.DraftPayTimeLimit,
            this.SalesCustomerCode});
            this.Detail.Height = 0.1354167F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // StockUnitPriceFl
            // 
            this.StockUnitPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.DataField = "StockUnitPriceFl";
            this.StockUnitPriceFl.Height = 0.1377953F;
            this.StockUnitPriceFl.Left = 4.1875F;
            this.StockUnitPriceFl.MultiLine = false;
            this.StockUnitPriceFl.Name = "StockUnitPriceFl";
            this.StockUnitPriceFl.OutputFormat = resources.GetString("StockUnitPriceFl.OutputFormat");
            this.StockUnitPriceFl.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.StockUnitPriceFl.Text = "123,456,789,012";
            this.StockUnitPriceFl.Top = 0F;
            this.StockUnitPriceFl.Width = 0.9212598F;
            // 
            // StockPriceTaxExc
            // 
            this.StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.StockPriceTaxExc.Height = 0.1377953F;
            this.StockPriceTaxExc.Left = 5.3125F;
            this.StockPriceTaxExc.MultiLine = false;
            this.StockPriceTaxExc.Name = "StockPriceTaxExc";
            this.StockPriceTaxExc.OutputFormat = resources.GetString("StockPriceTaxExc.OutputFormat");
            this.StockPriceTaxExc.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.StockPriceTaxExc.Text = "123,456,789,012";
            this.StockPriceTaxExc.Top = 0F;
            this.StockPriceTaxExc.Width = 0.9212598F;
            // 
            // Payment
            // 
            this.Payment.Border.BottomColor = System.Drawing.Color.Black;
            this.Payment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Payment.Border.LeftColor = System.Drawing.Color.Black;
            this.Payment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Payment.Border.RightColor = System.Drawing.Color.Black;
            this.Payment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Payment.Border.TopColor = System.Drawing.Color.Black;
            this.Payment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Payment.DataField = "Payment";
            this.Payment.Height = 0.1377953F;
            this.Payment.Left = 7.3125F;
            this.Payment.MultiLine = false;
            this.Payment.Name = "Payment";
            this.Payment.OutputFormat = resources.GetString("Payment.OutputFormat");
            this.Payment.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.Payment.Text = "123,456,789,012";
            this.Payment.Top = 0F;
            this.Payment.Width = 0.9212598F;
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
            this.GoodsNo.CanGrow = false;
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.125F;
            this.GoodsNo.Left = 0.125F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 6.75pt; font-f" +
                "amily: ＭＳ 明朝; white-space: inherit; ";
            this.GoodsNo.Text = "12345678901234567890123456789012";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.25F;
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
            this.GoodsName.CanGrow = false;
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.125F;
            this.GoodsName.Left = 1.4375F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; font-family: ＭＳ 明朝; whi" +
                "te-space: inherit; ";
            this.GoodsName.Text = "12345678901234567890123456789012";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 1.375F;
            // 
            // StockCount
            // 
            this.StockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount.Border.RightColor = System.Drawing.Color.Black;
            this.StockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount.Border.TopColor = System.Drawing.Color.Black;
            this.StockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount.CanGrow = false;
            this.StockCount.DataField = "StockCount";
            this.StockCount.Height = 0.125F;
            this.StockCount.Left = 3.3125F;
            this.StockCount.Name = "StockCount";
            this.StockCount.OutputFormat = resources.GetString("StockCount.OutputFormat");
            this.StockCount.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.StockCount.Text = "101.234.567,890";
            this.StockCount.Top = 0F;
            this.StockCount.Width = 0.75F;
            // 
            // StockPriceConsTax
            // 
            this.StockPriceConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPriceConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPriceConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.StockPriceConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.StockPriceConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceConsTax.DataField = "Dtl_StockPriceConsTax";
            this.StockPriceConsTax.Height = 0.1377953F;
            this.StockPriceConsTax.Left = 6.3125F;
            this.StockPriceConsTax.MultiLine = false;
            this.StockPriceConsTax.Name = "StockPriceConsTax";
            this.StockPriceConsTax.OutputFormat = resources.GetString("StockPriceConsTax.OutputFormat");
            this.StockPriceConsTax.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.StockPriceConsTax.Text = "123,456,789,012";
            this.StockPriceConsTax.Top = 0F;
            this.StockPriceConsTax.Width = 0.9212598F;
            // 
            // DraftPayTimeLimit
            // 
            this.DraftPayTimeLimit.Border.BottomColor = System.Drawing.Color.Black;
            this.DraftPayTimeLimit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayTimeLimit.Border.LeftColor = System.Drawing.Color.Black;
            this.DraftPayTimeLimit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayTimeLimit.Border.RightColor = System.Drawing.Color.Black;
            this.DraftPayTimeLimit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayTimeLimit.Border.TopColor = System.Drawing.Color.Black;
            this.DraftPayTimeLimit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayTimeLimit.DataField = "ValidityTerm";
            this.DraftPayTimeLimit.Height = 0.125F;
            this.DraftPayTimeLimit.Left = 8.3125F;
            this.DraftPayTimeLimit.MultiLine = false;
            this.DraftPayTimeLimit.Name = "DraftPayTimeLimit";
            this.DraftPayTimeLimit.OutputFormat = resources.GetString("DraftPayTimeLimit.OutputFormat");
            this.DraftPayTimeLimit.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.DraftPayTimeLimit.Text = "2000年02月99日";
            this.DraftPayTimeLimit.Top = 0F;
            this.DraftPayTimeLimit.Width = 0.875F;
            // 
            // SalesCustomerCode
            // 
            this.SalesCustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesCustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesCustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.SalesCustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.SalesCustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCustomerCode.DataField = "SalesCustomerCode";
            this.SalesCustomerCode.Height = 0.125F;
            this.SalesCustomerCode.Left = 9.3125F;
            this.SalesCustomerCode.MultiLine = false;
            this.SalesCustomerCode.Name = "SalesCustomerCode";
            this.SalesCustomerCode.OutputFormat = resources.GetString("SalesCustomerCode.OutputFormat");
            this.SalesCustomerCode.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.SalesCustomerCode.Text = "20304000";
            this.SalesCustomerCode.Top = 0F;
            this.SalesCustomerCode.Width = 0.8125F;
            // 
            // Balance
            // 
            this.Balance.Border.BottomColor = System.Drawing.Color.Black;
            this.Balance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance.Border.LeftColor = System.Drawing.Color.Black;
            this.Balance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance.Border.RightColor = System.Drawing.Color.Black;
            this.Balance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance.Border.TopColor = System.Drawing.Color.Black;
            this.Balance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance.DataField = "StockPriceConsTax";
            this.Balance.Height = 0.1377953F;
            this.Balance.Left = 10.1875F;
            this.Balance.MultiLine = false;
            this.Balance.Name = "Balance";
            this.Balance.OutputFormat = resources.GetString("Balance.OutputFormat");
            this.Balance.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.Balance.SummaryGroup = "TitleHeader";
            this.Balance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Balance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Balance.Text = "123,456,789,012";
            this.Balance.Top = 0F;
            this.Balance.Width = 0.9212598F;
            // 
            // StockAddUpADate
            // 
            this.StockAddUpADate.Border.BottomColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.Border.LeftColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.Border.RightColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.Border.TopColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.DataField = "StockAddUpADate";
            this.StockAddUpADate.Height = 0.125F;
            this.StockAddUpADate.Left = 0.125F;
            this.StockAddUpADate.MultiLine = false;
            this.StockAddUpADate.Name = "StockAddUpADate";
            this.StockAddUpADate.OutputFormat = resources.GetString("StockAddUpADate.OutputFormat");
            this.StockAddUpADate.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.StockAddUpADate.Text = "2007年05月09日";
            this.StockAddUpADate.Top = 0F;
            this.StockAddUpADate.Width = 0.8125F;
            // 
            // SupplierSlipNo
            // 
            this.SupplierSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNo.DataField = "SupplierSlipNo";
            this.SupplierSlipNo.Height = 0.1377953F;
            this.SupplierSlipNo.Left = 1.0625F;
            this.SupplierSlipNo.MultiLine = false;
            this.SupplierSlipNo.Name = "SupplierSlipNo";
            this.SupplierSlipNo.OutputFormat = resources.GetString("SupplierSlipNo.OutputFormat");
            this.SupplierSlipNo.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.SupplierSlipNo.Text = "12345678901234567890";
            this.SupplierSlipNo.Top = 0F;
            this.SupplierSlipNo.Width = 1.25F;
            // 
            // SlipKindNm
            // 
            this.SlipKindNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipKindNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipKindNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipKindNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipKindNm.Border.RightColor = System.Drawing.Color.Black;
            this.SlipKindNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipKindNm.Border.TopColor = System.Drawing.Color.Black;
            this.SlipKindNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipKindNm.DataField = "SlipKindNm";
            this.SlipKindNm.Height = 0.125F;
            this.SlipKindNm.Left = 2.1875F;
            this.SlipKindNm.MultiLine = false;
            this.SlipKindNm.Name = "SlipKindNm";
            this.SlipKindNm.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.SlipKindNm.Text = "テスト";
            this.SlipKindNm.Top = 0F;
            this.SlipKindNm.Width = 0.3125F;
            // 
            // SupplierSlipNote1
            // 
            this.SupplierSlipNote1.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierSlipNote1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNote1.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierSlipNote1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNote1.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierSlipNote1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNote1.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierSlipNote1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNote1.DataField = "SupplierSlipNote1";
            this.SupplierSlipNote1.Height = 0.1377953F;
            this.SupplierSlipNote1.Left = 6.0625F;
            this.SupplierSlipNote1.MultiLine = false;
            this.SupplierSlipNote1.Name = "SupplierSlipNote1";
            this.SupplierSlipNote1.OutputFormat = resources.GetString("SupplierSlipNote1.OutputFormat");
            this.SupplierSlipNote1.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.SupplierSlipNote1.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５";
            this.SupplierSlipNote1.Top = 0F;
            this.SupplierSlipNote1.Width = 2.838583F;
            // 
            // PartySaleSlipNum
            // 
            this.PartySaleSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.DataField = "PartySaleSlipNum";
            this.PartySaleSlipNum.Height = 0.125F;
            this.PartySaleSlipNum.Left = 4.5625F;
            this.PartySaleSlipNum.MultiLine = false;
            this.PartySaleSlipNum.Name = "PartySaleSlipNum";
            this.PartySaleSlipNum.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; white-space: inherit; ";
            this.PartySaleSlipNum.Text = "12345678901234567890";
            this.PartySaleSlipNum.Top = 0F;
            this.PartySaleSlipNum.Width = 1.25F;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Balance2,
            this.DetailSlitTitle});
            this.TitleHeader.DataField = "AddUpDate";
            this.TitleHeader.Height = 0.1770833F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
            // 
            // Balance2
            // 
            this.Balance2.Border.BottomColor = System.Drawing.Color.Black;
            this.Balance2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance2.Border.LeftColor = System.Drawing.Color.Black;
            this.Balance2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance2.Border.RightColor = System.Drawing.Color.Black;
            this.Balance2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance2.Border.TopColor = System.Drawing.Color.Black;
            this.Balance2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance2.Height = 0.1377953F;
            this.Balance2.Left = 9.75F;
            this.Balance2.MultiLine = false;
            this.Balance2.Name = "Balance2";
            this.Balance2.OutputFormat = resources.GetString("Balance2.OutputFormat");
            this.Balance2.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.Balance2.SummaryGroup = "TitleHeader";
            this.Balance2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Balance2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Balance2.Text = "123,456,789,012";
            this.Balance2.Top = 0.0625F;
            this.Balance2.Width = 0.9212598F;
            // 
            // DetailSlitTitle
            // 
            this.DetailSlitTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailSlitTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailSlitTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailSlitTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailSlitTitle.Border.RightColor = System.Drawing.Color.Black;
            this.DetailSlitTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailSlitTitle.Border.TopColor = System.Drawing.Color.Black;
            this.DetailSlitTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailSlitTitle.Height = 0.25F;
            this.DetailSlitTitle.HyperLink = "";
            this.DetailSlitTitle.Left = 0.0625F;
            this.DetailSlitTitle.Name = "DetailSlitTitle";
            this.DetailSlitTitle.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: middle; ";
            this.DetailSlitTitle.Text = "前回残高";
            this.DetailSlitTitle.Top = 0F;
            this.DetailSlitTitle.Width = 1F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label12,
            this.TotalStockPriceTaxExc,
            this.PaymentTotal,
            this.TotalStockPriceConsTax,
            this.BalanceTotal,
            this.line1});
            this.TitleFooter.Height = 0.2604167F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Format += new System.EventHandler(this.TitleFooter_Format);
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
            this.label12.Height = 0.25F;
            this.label12.HyperLink = "";
            this.label12.Left = 2.1875F;
            this.label12.Name = "label12";
            this.label12.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.label12.Text = "合計";
            this.label12.Top = 0.03125F;
            this.label12.Width = 1.125F;
            // 
            // TotalStockPriceTaxExc
            // 
            this.TotalStockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.TotalStockPriceTaxExc.Height = 0.1377953F;
            this.TotalStockPriceTaxExc.Left = 5.322917F;
            this.TotalStockPriceTaxExc.MultiLine = false;
            this.TotalStockPriceTaxExc.Name = "TotalStockPriceTaxExc";
            this.TotalStockPriceTaxExc.OutputFormat = resources.GetString("TotalStockPriceTaxExc.OutputFormat");
            this.TotalStockPriceTaxExc.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.TotalStockPriceTaxExc.SummaryGroup = "TitleHeader";
            this.TotalStockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TotalStockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TotalStockPriceTaxExc.Text = "123,456,789,012";
            this.TotalStockPriceTaxExc.Top = 0.0625F;
            this.TotalStockPriceTaxExc.Width = 0.9212598F;
            // 
            // PaymentTotal
            // 
            this.PaymentTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentTotal.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentTotal.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentTotal.DataField = "Payment";
            this.PaymentTotal.Height = 0.1377953F;
            this.PaymentTotal.Left = 7.322917F;
            this.PaymentTotal.MultiLine = false;
            this.PaymentTotal.Name = "PaymentTotal";
            this.PaymentTotal.OutputFormat = resources.GetString("PaymentTotal.OutputFormat");
            this.PaymentTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.PaymentTotal.SummaryGroup = "TitleHeader";
            this.PaymentTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.PaymentTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.PaymentTotal.Text = "123,456,789,012";
            this.PaymentTotal.Top = 0.0625F;
            this.PaymentTotal.Width = 0.9212598F;
            // 
            // TotalStockPriceConsTax
            // 
            this.TotalStockPriceConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockPriceConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPriceConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockPriceConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPriceConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockPriceConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPriceConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockPriceConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPriceConsTax.DataField = "StockPriceConsTax";
            this.TotalStockPriceConsTax.Height = 0.1377953F;
            this.TotalStockPriceConsTax.Left = 6.322917F;
            this.TotalStockPriceConsTax.MultiLine = false;
            this.TotalStockPriceConsTax.Name = "TotalStockPriceConsTax";
            this.TotalStockPriceConsTax.OutputFormat = resources.GetString("TotalStockPriceConsTax.OutputFormat");
            this.TotalStockPriceConsTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.TotalStockPriceConsTax.SummaryGroup = "TitleHeader";
            this.TotalStockPriceConsTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TotalStockPriceConsTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TotalStockPriceConsTax.Text = "123,456,789,012";
            this.TotalStockPriceConsTax.Top = 0.0625F;
            this.TotalStockPriceConsTax.Width = 0.9212598F;
            // 
            // BalanceTotal
            // 
            this.BalanceTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.BalanceTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BalanceTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.BalanceTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BalanceTotal.Border.RightColor = System.Drawing.Color.Black;
            this.BalanceTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BalanceTotal.Border.TopColor = System.Drawing.Color.Black;
            this.BalanceTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BalanceTotal.Height = 0.1377953F;
            this.BalanceTotal.Left = 10.19792F;
            this.BalanceTotal.MultiLine = false;
            this.BalanceTotal.Name = "BalanceTotal";
            this.BalanceTotal.OutputFormat = resources.GetString("BalanceTotal.OutputFormat");
            this.BalanceTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.BalanceTotal.Text = "123,456,789,012";
            this.BalanceTotal.Top = 0.0625F;
            this.BalanceTotal.Width = 0.9212598F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.25F;
            this.line1.Width = 11.13F;
            this.line1.X1 = 0F;
            this.line1.X2 = 11.13F;
            this.line1.Y1 = 0.25F;
            this.line1.Y2 = 0.25F;
            // 
            // RecordHeader
            // 
            this.RecordHeader.DataField = "StockRecordCd";
            this.RecordHeader.Height = 0F;
            this.RecordHeader.Name = "RecordHeader";
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.DataField = "UoeRemark1";
            this.textBox1.Height = 0.125F;
            this.textBox1.Left = 2.9375F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.textBox1.Text = "リマーク1";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.6875F;
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
            this.textBox4.DataField = "UoeRemark2";
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 3.8125F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.textBox4.Text = "リマーク2";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.6875F;
            // 
            // RecordFooter
            // 
            this.RecordFooter.CanShrink = true;
            this.RecordFooter.Height = 0.02083333F;
            this.RecordFooter.Name = "RecordFooter";
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
            this.label13.Height = 0.1875F;
            this.label13.HyperLink = "";
            this.label13.Left = 2.1875F;
            this.label13.Name = "label13";
            this.label13.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.label13.Text = "伝票計";
            this.label13.Top = 0F;
            this.label13.Width = 1.125F;
            // 
            // StockPrice
            // 
            this.StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.DataField = "StockPriceTaxExc";
            this.StockPrice.Height = 0.1377953F;
            this.StockPrice.Left = 5.3125F;
            this.StockPrice.MultiLine = false;
            this.StockPrice.Name = "StockPrice";
            this.StockPrice.OutputFormat = resources.GetString("StockPrice.OutputFormat");
            this.StockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.StockPrice.SummaryGroup = "SlipNoHeader";
            this.StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.StockPrice.Text = "123,456,789,012";
            this.StockPrice.Top = 0F;
            this.StockPrice.Width = 0.9212598F;
            // 
            // PaymentSubTotal
            // 
            this.PaymentSubTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentSubTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentSubTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentSubTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentSubTotal.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentSubTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentSubTotal.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentSubTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentSubTotal.DataField = "Payment";
            this.PaymentSubTotal.Height = 0.1377953F;
            this.PaymentSubTotal.Left = 7.3125F;
            this.PaymentSubTotal.MultiLine = false;
            this.PaymentSubTotal.Name = "PaymentSubTotal";
            this.PaymentSubTotal.OutputFormat = resources.GetString("PaymentSubTotal.OutputFormat");
            this.PaymentSubTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.PaymentSubTotal.SummaryGroup = "SlipNoHeader";
            this.PaymentSubTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.PaymentSubTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.PaymentSubTotal.Text = "123,456,789,012";
            this.PaymentSubTotal.Top = 0F;
            this.PaymentSubTotal.Width = 0.9212598F;
            // 
            // SubStockPriceConsTax
            // 
            this.SubStockPriceConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.SubStockPriceConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPriceConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.SubStockPriceConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPriceConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.SubStockPriceConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPriceConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.SubStockPriceConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPriceConsTax.DataField = "StockPriceConsTax";
            this.SubStockPriceConsTax.Height = 0.1377953F;
            this.SubStockPriceConsTax.Left = 6.3125F;
            this.SubStockPriceConsTax.MultiLine = false;
            this.SubStockPriceConsTax.Name = "SubStockPriceConsTax";
            this.SubStockPriceConsTax.OutputFormat = resources.GetString("SubStockPriceConsTax.OutputFormat");
            this.SubStockPriceConsTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.SubStockPriceConsTax.SummaryGroup = "SlipNoHeader";
            this.SubStockPriceConsTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubStockPriceConsTax.Text = "123,456,789,012";
            this.SubStockPriceConsTax.Top = 0F;
            this.SubStockPriceConsTax.Width = 0.9212598F;
            // 
            // SlipNoHeader
            // 
            this.SlipNoHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupplierSlipNote1,
            this.SupplierSlipNo,
            this.SlipKindNm,
            this.PartySaleSlipNum,
            this.textBox1,
            this.textBox4,
            this.StockAddUpADate});
            this.SlipNoHeader.DataField = "SupplierSlipNo";
            this.SlipNoHeader.Height = 0.125F;
            this.SlipNoHeader.Name = "SlipNoHeader";
            this.SlipNoHeader.Format += new System.EventHandler(this.SlipNoHeader_Format);
            // 
            // SlipNoFooter
            // 
            this.SlipNoFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label13,
            this.StockPrice,
            this.SubStockPriceConsTax,
            this.PaymentSubTotal,
            this.Balance,
            this.line3});
            this.SlipNoFooter.Height = 0.1979167F;
            this.SlipNoFooter.Name = "SlipNoFooter";
            this.SlipNoFooter.Format += new System.EventHandler(this.SlipNoFooter_Format);
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
            this.line3.Top = 0.1875F;
            this.line3.Width = 11.13F;
            this.line3.X1 = 0F;
            this.line3.X2 = 11.13F;
            this.line3.Y1 = 0.1875F;
            this.line3.Y2 = 0.1875F;
            // 
            // PMKOU02033P_01_Detail
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 11.25F;
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.RecordHeader);
            this.Sections.Add(this.SlipNoHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SlipNoFooter);
            this.Sections.Add(this.RecordFooter);
            this.Sections.Add(this.TitleFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayTimeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAddUpADate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipKindNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNote1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailSlitTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockPriceConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubStockPriceConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        private void SlipNoFooter_Format(object sender, EventArgs e)
        {
            if (SubStockPriceConsTax.Value == null)
            {
                SubStockPriceConsTax.Value = 0;
            }
            
            int iStockPrice = 0;
            int iStockPriceConsTax = 0;
            int iPaymentTotal = 0;

            if (this.StockPrice.Value != null)
            {
                iStockPrice = TStrConv.StrToIntDef(this.StockPrice.Value.ToString(), 0);
                iStockPriceConsTax = TStrConv.StrToIntDef(this.SubStockPriceConsTax.Value.ToString(), 0);
            }
            if (this.PaymentSubTotal.Value != null)
            {
                iPaymentTotal = TStrConv.StrToIntDef(this.PaymentSubTotal.Value.ToString(), 0);
            }

            this._lastTimePayment = (this._lastTimePayment + (iStockPrice + iStockPriceConsTax)) - iPaymentTotal;
            this.Balance.Value = this._lastTimePayment;

            this._StockPriceConsTax += iStockPriceConsTax;
        }

        private void TitleFooter_Format(object sender, EventArgs e)
        {
            TotalStockPriceConsTax.Value = this._StockPriceConsTax;
            this.BalanceTotal.Value = long.Parse(TotalStockPriceTaxExc.Value.ToString())
                                    + long.Parse(TotalStockPriceConsTax.Value.ToString())
                                    - long.Parse(PaymentTotal.Value.ToString())
                                    + this._lastTimePaymentSub;
        }

        private void SlipNoHeader_Format(object sender, EventArgs e)
        {
            if (StockAddUpADate.Value != null)
            {
                int _printAddUpDate;
                if (StockAddUpADate.Value is string)
                {
                    _printAddUpDate = int.Parse((string)StockAddUpADate.Value);
                }
                else
                {
                    _printAddUpDate = (int)StockAddUpADate.Value;
                }
                DateTime dt = TDateTime.LongDateToDateTime(_printAddUpDate);
                this.StockAddUpADate.Text = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + dt.Day.ToString();
            }
            // --- ADD　2014/10/17 時シン 「支払」の場合、「支払伝票番号」は常に「伝票番号」欄に印字する------->>>>>
            if (SlipKindNm.Value != null)
            {
                if ((!"仕入".Equals(SlipKindNm.Value.ToString())) && this._ledgerCmnCndtn.PrintDiv == 1)
                {
                    SupplierSlipNo.Value = PartySaleSlipNum.Value.ToString().PadLeft(9, '0');
                    PartySaleSlipNum.Visible = false;
                }
                else
                {
                    PartySaleSlipNum.Visible = true;
                }

            }
            // --- ADD　2014/10/17 時シン 「支払」の場合、「支払伝票番号」は常に「伝票番号」欄に印字する-------<<<<<
        }

        private void TitleHeader_Format(object sender, EventArgs e)
        {
            this._StockPriceConsTax = 0;
            this.Balance2.Value = this._lastTimePayment;
            this._lastTimePaymentSub = _lastTimePayment;
            //this.DetailSlitTitle.Value = "前月" + this._dtlTtl;
        }

        private void Detail_Format(object sender, EventArgs e)
        {
            DraftPayTimeLimit.Visible = true;
            if ((DraftPayTimeLimit.Value != null) && ((DraftPayTimeLimit.Value.ToString() != "")))
            {
                int ivalidityTerm = int.Parse(DraftPayTimeLimit.Value.ToString());
                DateTime dt = TDateTime.LongDateToDateTime(ivalidityTerm);
                this.DraftPayTimeLimit.Text = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + dt.Day.ToString();
            }
            if ((DraftPayTimeLimit.Value != null) && (DraftPayTimeLimit.Value.ToString() != ""))
            {
                if (DraftPayTimeLimit.Text == "1/1/1")
                {
                    DraftPayTimeLimit.Visible = false;
                }
            }
            SalesCustomerCode.Visible = true;
            if (SalesCustomerCode.Value != null)
            {
                if ((SalesCustomerCode.Value.ToString() == "0") || (SalesCustomerCode.Value.ToString() == ""))
                {
                    SalesCustomerCode.Visible = false;
                }
            }
        }
	}
}
