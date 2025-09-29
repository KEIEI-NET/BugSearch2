using System;
using Broadleaf.Library.Text;
using DataDynamics.ActiveReports;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 得意先元帳明細フォーム印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先元帳の明細印刷を行います。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.11.14</br>
    /// <br>Programmer : 30009 渋谷 大輔</br>
    /// <br>Date       : 2009.01.21</br>
    /// <br>Note       : PM.NS用に修正</br>
    /// <br></br>
	/// </remarks>
	public class PMHNB02193P_01_Detail : DataDynamics.ActiveReports.ActiveReport3
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		public PMHNB02193P_01_Detail()
		{
			InitializeComponent();
		}
		#endregion

        private TextBox Balance;
        private TextBox GoodsNo;
        private TextBox GoodsName;
        private TextBox ShipmentCnt;
        private GroupHeader SlipNoHeader;
        private GroupFooter SlipNoFooter;
        private Label label13;
        private TextBox SalesTotal;
        private TextBox DepositTotal;
        private Line line2;
        private Label label12;
        private TextBox TotalSalesMoneyTaxExc;
        private TextBox textBox3;

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member
		// 拠点情報印字有無
        private bool _isSectionPrint = false;
        private Line line3;
        private TextBox TotalSalsePriceConsTax;
        private TextBox ConsTaxTotal;
   		#endregion

        private TextBox SubSalsePriceConsTax1;
        private TextBox SubSalsePriceConsTax;
        private TextBox SubSalesMoneyTaxExc;
        private TextBox SubSalesMoneyTaxExc1;
        private TextBox SalsePriceConsTax;
        private TextBox AddUpDate;
        private TextBox SlipNo;
        private TextBox SalesSlipKindName;
        private TextBox SlipNote;
        private TextBox SlipNote2;
        private TextBox PartySlipNumDtl;
        private TextBox UoeRemark1;
        private TextBox UoeRemark2;
        private TextBox SupplierCd;
        private TextBox textBox1;
        private Label label1;
        private TextBox LastTimeBalance;
        private TextBox TaxationDivCd;
        private TextBox ConsTaxLayMethod;


        public int _keyLastTimeDemand = 0;

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

            if (this.SupplierCd.Value != null)
            {
                if (this.SupplierCd.Text == "000000")
                {
                    this.SupplierCd.Visible = false;
                }
                else
                {
                    this.SupplierCd.Visible = true;
                }
            }
            else
            {
                this.SupplierCd.Visible = false;
            }

		}
		#endregion
		
		// ===============================================================================
		// ActiveReportsデザイナで生成されたコード
		// ===============================================================================
		#region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox SalesUnPrcTaxExcFl;
        private DataDynamics.ActiveReports.TextBox SalesMoneyTaxExc;
        private DataDynamics.ActiveReports.TextBox Deposit;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMHNB02193P_01_Detail));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.SalesUnPrcTaxExcFl = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Deposit = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.SalsePriceConsTax = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TaxationDivCd = new DataDynamics.ActiveReports.TextBox();
            this.ConsTaxLayMethod = new DataDynamics.ActiveReports.TextBox();
            this.Balance = new DataDynamics.ActiveReports.TextBox();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.LastTimeBalance = new DataDynamics.ActiveReports.TextBox();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.TotalSalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.TotalSalsePriceConsTax = new DataDynamics.ActiveReports.TextBox();
            this.SubSalsePriceConsTax1 = new DataDynamics.ActiveReports.TextBox();
            this.SubSalsePriceConsTax = new DataDynamics.ActiveReports.TextBox();
            this.SubSalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SubSalesMoneyTaxExc1 = new DataDynamics.ActiveReports.TextBox();
            this.SlipNoHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.AddUpDate = new DataDynamics.ActiveReports.TextBox();
            this.SlipNo = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipKindName = new DataDynamics.ActiveReports.TextBox();
            this.SlipNote = new DataDynamics.ActiveReports.TextBox();
            this.SlipNote2 = new DataDynamics.ActiveReports.TextBox();
            this.PartySlipNumDtl = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark1 = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark2 = new DataDynamics.ActiveReports.TextBox();
            this.SlipNoFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.SalesTotal = new DataDynamics.ActiveReports.TextBox();
            this.DepositTotal = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.ConsTaxTotal = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalsePriceConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxationDivCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxLayMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalsePriceConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalsePriceConsTax1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalsePriceConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesMoneyTaxExc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipKindName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySlipNumDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SalesUnPrcTaxExcFl,
            this.SalesMoneyTaxExc,
            this.Deposit,
            this.GoodsNo,
            this.GoodsName,
            this.ShipmentCnt,
            this.SalsePriceConsTax,
            this.SupplierCd,
            this.textBox1,
            this.TaxationDivCd,
            this.ConsTaxLayMethod});
            this.Detail.Height = 0.40625F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // SalesUnPrcTaxExcFl
            // 
            this.SalesUnPrcTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.DataField = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.Height = 0.1377953F;
            this.SalesUnPrcTaxExcFl.Left = 4.1875F;
            this.SalesUnPrcTaxExcFl.MultiLine = false;
            this.SalesUnPrcTaxExcFl.Name = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.OutputFormat = resources.GetString("SalesUnPrcTaxExcFl.OutputFormat");
            this.SalesUnPrcTaxExcFl.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.SalesUnPrcTaxExcFl.Text = "123,456,789,012";
            this.SalesUnPrcTaxExcFl.Top = 0.0625F;
            this.SalesUnPrcTaxExcFl.Width = 0.9212598F;
            // 
            // SalesMoneyTaxExc
            // 
            this.SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.Height = 0.1377953F;
            this.SalesMoneyTaxExc.Left = 5.1875F;
            this.SalesMoneyTaxExc.MultiLine = false;
            this.SalesMoneyTaxExc.Name = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.OutputFormat = resources.GetString("SalesMoneyTaxExc.OutputFormat");
            this.SalesMoneyTaxExc.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.SalesMoneyTaxExc.Text = "123,456,789,012";
            this.SalesMoneyTaxExc.Top = 0.0625F;
            this.SalesMoneyTaxExc.Width = 0.9212598F;
            // 
            // Deposit
            // 
            this.Deposit.Border.BottomColor = System.Drawing.Color.Black;
            this.Deposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.Border.LeftColor = System.Drawing.Color.Black;
            this.Deposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.Border.RightColor = System.Drawing.Color.Black;
            this.Deposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.Border.TopColor = System.Drawing.Color.Black;
            this.Deposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.DataField = "Deposit";
            this.Deposit.Height = 0.1377953F;
            this.Deposit.Left = 7.1875F;
            this.Deposit.MultiLine = false;
            this.Deposit.Name = "Deposit";
            this.Deposit.OutputFormat = resources.GetString("Deposit.OutputFormat");
            this.Deposit.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.Deposit.Text = "123,456,789,012";
            this.Deposit.Top = 0.0625F;
            this.Deposit.Width = 0.9212598F;
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
            this.GoodsNo.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; white-space: inherit; ";
            this.GoodsNo.Text = "12345678901234567890123456789012";
            this.GoodsNo.Top = 0.0625F;
            this.GoodsNo.Width = 1.53125F;
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
            this.GoodsName.Left = 1.75F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "text-align: left; font-weight: normal; font-size: 6.75pt; white-space: inherit; ";
            this.GoodsName.Text = "12345678901234567890123456789012";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 1.53125F;
            // 
            // ShipmentCnt
            // 
            this.ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.CanGrow = false;
            this.ShipmentCnt.DataField = "ShipmentCnt";
            this.ShipmentCnt.Height = 0.125F;
            this.ShipmentCnt.Left = 3.375F;
            this.ShipmentCnt.Name = "ShipmentCnt";
            this.ShipmentCnt.OutputFormat = resources.GetString("ShipmentCnt.OutputFormat");
            this.ShipmentCnt.Style = "text-align: right; font-weight: normal; font-size: 6.75pt; font-family: ＭＳ ゴシック; " +
                "";
            this.ShipmentCnt.Text = "101.234.567,890";
            this.ShipmentCnt.Top = 0.0625F;
            this.ShipmentCnt.Width = 0.75F;
            // 
            // SalsePriceConsTax
            // 
            this.SalsePriceConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.SalsePriceConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalsePriceConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.SalsePriceConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalsePriceConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.SalsePriceConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalsePriceConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.SalsePriceConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalsePriceConsTax.DataField = "SalsePriceConsTax";
            this.SalsePriceConsTax.Height = 0.1377953F;
            this.SalsePriceConsTax.Left = 6.1875F;
            this.SalsePriceConsTax.MultiLine = false;
            this.SalsePriceConsTax.Name = "SalsePriceConsTax";
            this.SalsePriceConsTax.OutputFormat = resources.GetString("SalsePriceConsTax.OutputFormat");
            this.SalsePriceConsTax.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.SalsePriceConsTax.Text = "123,456,789,012";
            this.SalsePriceConsTax.Top = 0.0625F;
            this.SalsePriceConsTax.Width = 0.9212598F;
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
            this.SupplierCd.Left = 9.125F;
            this.SupplierCd.MultiLine = false;
            this.SupplierCd.Name = "SupplierCd";
            this.SupplierCd.OutputFormat = resources.GetString("SupplierCd.OutputFormat");
            this.SupplierCd.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.SupplierCd.Text = "123456";
            this.SupplierCd.Top = 0.0625F;
            this.SupplierCd.Width = 0.6875F;
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
            this.textBox1.DataField = "DraftPayTimeLimit";
            this.textBox1.Height = 0.125F;
            this.textBox1.Left = 8.25F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.textBox1.Text = "2007/05/09/";
            this.textBox1.Top = 0.0625F;
            this.textBox1.Width = 0.8125F;
            // 
            // TaxationDivCd
            // 
            this.TaxationDivCd.Border.BottomColor = System.Drawing.Color.Black;
            this.TaxationDivCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxationDivCd.Border.LeftColor = System.Drawing.Color.Black;
            this.TaxationDivCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxationDivCd.Border.RightColor = System.Drawing.Color.Black;
            this.TaxationDivCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxationDivCd.Border.TopColor = System.Drawing.Color.Black;
            this.TaxationDivCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxationDivCd.CanGrow = false;
            this.TaxationDivCd.DataField = "TaxationDivCd";
            this.TaxationDivCd.Height = 0.125F;
            this.TaxationDivCd.Left = 9.875F;
            this.TaxationDivCd.Name = "TaxationDivCd";
            this.TaxationDivCd.OutputFormat = resources.GetString("TaxationDivCd.OutputFormat");
            this.TaxationDivCd.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.TaxationDivCd.Text = null;
            this.TaxationDivCd.Top = 0.25F;
            this.TaxationDivCd.Visible = false;
            this.TaxationDivCd.Width = 0.5625F;
            // 
            // ConsTaxLayMethod
            // 
            this.ConsTaxLayMethod.Border.BottomColor = System.Drawing.Color.Black;
            this.ConsTaxLayMethod.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxLayMethod.Border.LeftColor = System.Drawing.Color.Black;
            this.ConsTaxLayMethod.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxLayMethod.Border.RightColor = System.Drawing.Color.Black;
            this.ConsTaxLayMethod.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxLayMethod.Border.TopColor = System.Drawing.Color.Black;
            this.ConsTaxLayMethod.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxLayMethod.CanGrow = false;
            this.ConsTaxLayMethod.DataField = "ConsTaxLayMethod";
            this.ConsTaxLayMethod.Height = 0.125F;
            this.ConsTaxLayMethod.Left = 9.375F;
            this.ConsTaxLayMethod.Name = "ConsTaxLayMethod";
            this.ConsTaxLayMethod.OutputFormat = resources.GetString("ConsTaxLayMethod.OutputFormat");
            this.ConsTaxLayMethod.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.ConsTaxLayMethod.Text = null;
            this.ConsTaxLayMethod.Top = 0.25F;
            this.ConsTaxLayMethod.Visible = false;
            this.ConsTaxLayMethod.Width = 0.5625F;
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
            this.Balance.Height = 0.125F;
            this.Balance.Left = 9.8125F;
            this.Balance.MultiLine = false;
            this.Balance.Name = "Balance";
            this.Balance.OutputFormat = resources.GetString("Balance.OutputFormat");
            this.Balance.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.Balance.SummaryGroup = "SlipNoHeader";
            this.Balance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Balance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Balance.Text = "123,456,789,012";
            this.Balance.Top = 0.0625F;
            this.Balance.Width = 0.9375F;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.LastTimeBalance});
            this.TitleHeader.Height = 0.3229167F;
            this.TitleHeader.Name = "TitleHeader";
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
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = "";
            this.label1.Left = 0.0625F;
            this.label1.Name = "label1";
            this.label1.Style = "text-align: justify; font-weight: bold; font-size: 8.25pt; vertical-align: middle" +
                "; ";
            this.label1.Text = "前回残高";
            this.label1.Top = 0.0625F;
            this.label1.Width = 1.125F;
            // 
            // LastTimeBalance
            // 
            this.LastTimeBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimeBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimeBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeBalance.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimeBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeBalance.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimeBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeBalance.Height = 0.1875F;
            this.LastTimeBalance.Left = 9.8125F;
            this.LastTimeBalance.MultiLine = false;
            this.LastTimeBalance.Name = "LastTimeBalance";
            this.LastTimeBalance.OutputFormat = resources.GetString("LastTimeBalance.OutputFormat");
            this.LastTimeBalance.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.LastTimeBalance.SummaryGroup = "SlipNoHeader";
            this.LastTimeBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LastTimeBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LastTimeBalance.Text = "123,456,789,012";
            this.LastTimeBalance.Top = 0.0625F;
            this.LastTimeBalance.Width = 0.9375F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label12,
            this.TotalSalesMoneyTaxExc,
            this.textBox3,
            this.line3,
            this.TotalSalsePriceConsTax,
            this.SubSalsePriceConsTax1,
            this.SubSalsePriceConsTax,
            this.SubSalesMoneyTaxExc,
            this.SubSalesMoneyTaxExc1});
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
            this.label12.Height = 0.1875F;
            this.label12.HyperLink = "";
            this.label12.Left = 1.75F;
            this.label12.Name = "label12";
            this.label12.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.label12.Text = "合計";
            this.label12.Top = 0.0625F;
            this.label12.Width = 1.125F;
            // 
            // TotalSalesMoneyTaxExc
            // 
            this.TotalSalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoneyTaxExc.Height = 0.1377953F;
            this.TotalSalesMoneyTaxExc.Left = 5.1875F;
            this.TotalSalesMoneyTaxExc.MultiLine = false;
            this.TotalSalesMoneyTaxExc.Name = "TotalSalesMoneyTaxExc";
            this.TotalSalesMoneyTaxExc.OutputFormat = resources.GetString("TotalSalesMoneyTaxExc.OutputFormat");
            this.TotalSalesMoneyTaxExc.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.TotalSalesMoneyTaxExc.SummaryGroup = "TitleHeader";
            this.TotalSalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TotalSalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TotalSalesMoneyTaxExc.Text = "123,456,789,012";
            this.TotalSalesMoneyTaxExc.Top = 0.0625F;
            this.TotalSalesMoneyTaxExc.Width = 0.9212598F;
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
            this.textBox3.DataField = "Deposit";
            this.textBox3.Height = 0.1377953F;
            this.textBox3.Left = 7.1875F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.textBox3.SummaryGroup = "TitleHeader";
            this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox3.Text = "123,456,789,012";
            this.textBox3.Top = 0.0625F;
            this.textBox3.Width = 0.9212598F;
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
            this.line3.Top = 0.25F;
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0.25F;
            this.line3.Y2 = 0.25F;
            // 
            // TotalSalsePriceConsTax
            // 
            this.TotalSalsePriceConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalsePriceConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalsePriceConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalsePriceConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalsePriceConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalsePriceConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalsePriceConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalsePriceConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalsePriceConsTax.Height = 0.1377953F;
            this.TotalSalsePriceConsTax.Left = 6.1875F;
            this.TotalSalsePriceConsTax.MultiLine = false;
            this.TotalSalsePriceConsTax.Name = "TotalSalsePriceConsTax";
            this.TotalSalsePriceConsTax.OutputFormat = resources.GetString("TotalSalsePriceConsTax.OutputFormat");
            this.TotalSalsePriceConsTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.TotalSalsePriceConsTax.SummaryGroup = "TitleHeader";
            this.TotalSalsePriceConsTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TotalSalsePriceConsTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TotalSalsePriceConsTax.Text = "123,456,789,012";
            this.TotalSalsePriceConsTax.Top = 0.0625F;
            this.TotalSalsePriceConsTax.Width = 0.9212598F;
            // 
            // SubSalsePriceConsTax1
            // 
            this.SubSalsePriceConsTax1.Border.BottomColor = System.Drawing.Color.Black;
            this.SubSalsePriceConsTax1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalsePriceConsTax1.Border.LeftColor = System.Drawing.Color.Black;
            this.SubSalsePriceConsTax1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalsePriceConsTax1.Border.RightColor = System.Drawing.Color.Black;
            this.SubSalsePriceConsTax1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalsePriceConsTax1.Border.TopColor = System.Drawing.Color.Black;
            this.SubSalsePriceConsTax1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalsePriceConsTax1.DataField = "SalsePriceConsTax1";
            this.SubSalsePriceConsTax1.Height = 0.125F;
            this.SubSalsePriceConsTax1.Left = 9.8125F;
            this.SubSalsePriceConsTax1.MultiLine = false;
            this.SubSalsePriceConsTax1.Name = "SubSalsePriceConsTax1";
            this.SubSalsePriceConsTax1.OutputFormat = resources.GetString("SubSalsePriceConsTax1.OutputFormat");
            this.SubSalsePriceConsTax1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.SubSalsePriceConsTax1.SummaryGroup = "TitleHeader";
            this.SubSalsePriceConsTax1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubSalsePriceConsTax1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubSalsePriceConsTax1.Text = "123,456,789,012";
            this.SubSalsePriceConsTax1.Top = 0.0625F;
            this.SubSalsePriceConsTax1.Visible = false;
            this.SubSalsePriceConsTax1.Width = 0.9375F;
            // 
            // SubSalsePriceConsTax
            // 
            this.SubSalsePriceConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.SubSalsePriceConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalsePriceConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.SubSalsePriceConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalsePriceConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.SubSalsePriceConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalsePriceConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.SubSalsePriceConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalsePriceConsTax.DataField = "SalsePriceConsTax";
            this.SubSalsePriceConsTax.Height = 0.125F;
            this.SubSalsePriceConsTax.Left = 9.8125F;
            this.SubSalsePriceConsTax.MultiLine = false;
            this.SubSalsePriceConsTax.Name = "SubSalsePriceConsTax";
            this.SubSalsePriceConsTax.OutputFormat = resources.GetString("SubSalsePriceConsTax.OutputFormat");
            this.SubSalsePriceConsTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.SubSalsePriceConsTax.SummaryGroup = "TitleHeader";
            this.SubSalsePriceConsTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubSalsePriceConsTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubSalsePriceConsTax.Text = "123,456,789,012";
            this.SubSalsePriceConsTax.Top = 0.0625F;
            this.SubSalsePriceConsTax.Visible = false;
            this.SubSalsePriceConsTax.Width = 0.9375F;
            // 
            // SubSalesMoneyTaxExc
            // 
            this.SubSalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SubSalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SubSalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SubSalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SubSalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.SubSalesMoneyTaxExc.Height = 0.1377953F;
            this.SubSalesMoneyTaxExc.Left = 8.1875F;
            this.SubSalesMoneyTaxExc.MultiLine = false;
            this.SubSalesMoneyTaxExc.Name = "SubSalesMoneyTaxExc";
            this.SubSalesMoneyTaxExc.OutputFormat = resources.GetString("SubSalesMoneyTaxExc.OutputFormat");
            this.SubSalesMoneyTaxExc.Style = "text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; white" +
                "-space: inherit; ";
            this.SubSalesMoneyTaxExc.SummaryGroup = "TitleHeader";
            this.SubSalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubSalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubSalesMoneyTaxExc.Text = "123,456,789,012";
            this.SubSalesMoneyTaxExc.Top = 0.0625F;
            this.SubSalesMoneyTaxExc.Visible = false;
            this.SubSalesMoneyTaxExc.Width = 0.9212598F;
            // 
            // SubSalesMoneyTaxExc1
            // 
            this.SubSalesMoneyTaxExc1.Border.BottomColor = System.Drawing.Color.Black;
            this.SubSalesMoneyTaxExc1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesMoneyTaxExc1.Border.LeftColor = System.Drawing.Color.Black;
            this.SubSalesMoneyTaxExc1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesMoneyTaxExc1.Border.RightColor = System.Drawing.Color.Black;
            this.SubSalesMoneyTaxExc1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesMoneyTaxExc1.Border.TopColor = System.Drawing.Color.Black;
            this.SubSalesMoneyTaxExc1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesMoneyTaxExc1.DataField = "SalesMoneyTaxExc1";
            this.SubSalesMoneyTaxExc1.Height = 0.1377953F;
            this.SubSalesMoneyTaxExc1.Left = 8.1875F;
            this.SubSalesMoneyTaxExc1.MultiLine = false;
            this.SubSalesMoneyTaxExc1.Name = "SubSalesMoneyTaxExc1";
            this.SubSalesMoneyTaxExc1.OutputFormat = resources.GetString("SubSalesMoneyTaxExc1.OutputFormat");
            this.SubSalesMoneyTaxExc1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.SubSalesMoneyTaxExc1.SummaryGroup = "TitleHeader";
            this.SubSalesMoneyTaxExc1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubSalesMoneyTaxExc1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubSalesMoneyTaxExc1.Text = "123,456,789,012";
            this.SubSalesMoneyTaxExc1.Top = 0.0625F;
            this.SubSalesMoneyTaxExc1.Visible = false;
            this.SubSalesMoneyTaxExc1.Width = 0.9212598F;
            // 
            // SlipNoHeader
            // 
            this.SlipNoHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.AddUpDate,
            this.SlipNo,
            this.SalesSlipKindName,
            this.SlipNote,
            this.SlipNote2,
            this.PartySlipNumDtl,
            this.UoeRemark1,
            this.UoeRemark2});
            this.SlipNoHeader.DataField = "SlipNo";
            this.SlipNoHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
            this.SlipNoHeader.Height = 0.2604167F;
            this.SlipNoHeader.KeepTogether = true;
            this.SlipNoHeader.Name = "SlipNoHeader";
            // 
            // AddUpDate
            // 
            this.AddUpDate.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpDate.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpDate.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpDate.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpDate.DataField = "AddUpADateDisp";
            this.AddUpDate.Height = 0.125F;
            this.AddUpDate.Left = 0.125F;
            this.AddUpDate.MultiLine = false;
            this.AddUpDate.Name = "AddUpDate";
            this.AddUpDate.OutputFormat = resources.GetString("AddUpDate.OutputFormat");
            this.AddUpDate.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.AddUpDate.Text = "2007年05月09日";
            this.AddUpDate.Top = 0.0625F;
            this.AddUpDate.Width = 0.875F;
            // 
            // SlipNo
            // 
            this.SlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo.DataField = "SlipNo";
            this.SlipNo.Height = 0.1377953F;
            this.SlipNo.Left = 1.0625F;
            this.SlipNo.MultiLine = false;
            this.SlipNo.Name = "SlipNo";
            this.SlipNo.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.SlipNo.Text = "1234567890";
            this.SlipNo.Top = 0.0625F;
            this.SlipNo.Width = 0.6102362F;
            // 
            // SalesSlipKindName
            // 
            this.SalesSlipKindName.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipKindName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipKindName.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipKindName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipKindName.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipKindName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipKindName.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipKindName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipKindName.DataField = "SalesSlipKindName";
            this.SalesSlipKindName.Height = 0.1377953F;
            this.SalesSlipKindName.Left = 1.75F;
            this.SalesSlipKindName.MultiLine = false;
            this.SalesSlipKindName.Name = "SalesSlipKindName";
            this.SalesSlipKindName.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.SalesSlipKindName.Text = "売上";
            this.SalesSlipKindName.Top = 0.0625F;
            this.SalesSlipKindName.Width = 0.5634843F;
            // 
            // SlipNote
            // 
            this.SlipNote.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.DataField = "SlipNote";
            this.SlipNote.Height = 0.1377953F;
            this.SlipNote.Left = 5.125F;
            this.SlipNote.MultiLine = false;
            this.SlipNote.Name = "SlipNote";
            this.SlipNote.OutputFormat = resources.GetString("SlipNote.OutputFormat");
            this.SlipNote.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.SlipNote.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５";
            this.SlipNote.Top = 0.0625F;
            this.SlipNote.Width = 2.838583F;
            // 
            // SlipNote2
            // 
            this.SlipNote2.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.DataField = "SlipNote2";
            this.SlipNote2.Height = 0.1377953F;
            this.SlipNote2.Left = 8F;
            this.SlipNote2.MultiLine = false;
            this.SlipNote2.Name = "SlipNote2";
            this.SlipNote2.OutputFormat = resources.GetString("SlipNote2.OutputFormat");
            this.SlipNote2.Style = "font-size: 8pt; white-space: inherit; ";
            this.SlipNote2.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５";
            this.SlipNote2.Top = 0.0625F;
            this.SlipNote2.Width = 2.838583F;
            // 
            // PartySlipNumDtl
            // 
            this.PartySlipNumDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.PartySlipNumDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySlipNumDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.PartySlipNumDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySlipNumDtl.Border.RightColor = System.Drawing.Color.Black;
            this.PartySlipNumDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySlipNumDtl.Border.TopColor = System.Drawing.Color.Black;
            this.PartySlipNumDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySlipNumDtl.DataField = "PartySlipNumDtl";
            this.PartySlipNumDtl.Height = 0.125F;
            this.PartySlipNumDtl.Left = 3.875F;
            this.PartySlipNumDtl.MultiLine = false;
            this.PartySlipNumDtl.Name = "PartySlipNumDtl";
            this.PartySlipNumDtl.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.PartySlipNumDtl.Text = "12345678901234567890";
            this.PartySlipNumDtl.Top = 0.0625F;
            this.PartySlipNumDtl.Width = 1.1875F;
            // 
            // UoeRemark1
            // 
            this.UoeRemark1.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1.DataField = "UoeRemark1";
            this.UoeRemark1.Height = 0.125F;
            this.UoeRemark1.Left = 2.375F;
            this.UoeRemark1.MultiLine = false;
            this.UoeRemark1.Name = "UoeRemark1";
            this.UoeRemark1.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.UoeRemark1.Text = "1234567890";
            this.UoeRemark1.Top = 0.0625F;
            this.UoeRemark1.Width = 0.625F;
            // 
            // UoeRemark2
            // 
            this.UoeRemark2.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2.DataField = "UoeRemark2";
            this.UoeRemark2.Height = 0.125F;
            this.UoeRemark2.Left = 3.125F;
            this.UoeRemark2.MultiLine = false;
            this.UoeRemark2.Name = "UoeRemark2";
            this.UoeRemark2.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.UoeRemark2.Text = "1234567890";
            this.UoeRemark2.Top = 0.0625F;
            this.UoeRemark2.Width = 0.625F;
            // 
            // SlipNoFooter
            // 
            this.SlipNoFooter.CanShrink = true;
            this.SlipNoFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label13,
            this.SalesTotal,
            this.DepositTotal,
            this.line2,
            this.Balance,
            this.ConsTaxTotal});
            this.SlipNoFooter.Height = 0.2604167F;
            this.SlipNoFooter.KeepTogether = true;
            this.SlipNoFooter.Name = "SlipNoFooter";
            this.SlipNoFooter.Format += new System.EventHandler(this.SlipNoFooter_Format);
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
            this.label13.Left = 1.75F;
            this.label13.Name = "label13";
            this.label13.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.label13.Text = "伝票計";
            this.label13.Top = 0.0625F;
            this.label13.Width = 1.125F;
            // 
            // SalesTotal
            // 
            this.SalesTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotal.Border.RightColor = System.Drawing.Color.Black;
            this.SalesTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotal.Border.TopColor = System.Drawing.Color.Black;
            this.SalesTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotal.DataField = "SalesMoneyTaxExc";
            this.SalesTotal.Height = 0.1377953F;
            this.SalesTotal.Left = 5.1875F;
            this.SalesTotal.MultiLine = false;
            this.SalesTotal.Name = "SalesTotal";
            this.SalesTotal.OutputFormat = resources.GetString("SalesTotal.OutputFormat");
            this.SalesTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.SalesTotal.SummaryGroup = "SlipNoHeader";
            this.SalesTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SalesTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SalesTotal.Text = "123,456,789,012";
            this.SalesTotal.Top = 0.0625F;
            this.SalesTotal.Width = 0.9212598F;
            // 
            // DepositTotal
            // 
            this.DepositTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositTotal.Border.RightColor = System.Drawing.Color.Black;
            this.DepositTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositTotal.Border.TopColor = System.Drawing.Color.Black;
            this.DepositTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositTotal.DataField = "Deposit";
            this.DepositTotal.Height = 0.1377953F;
            this.DepositTotal.Left = 7.1875F;
            this.DepositTotal.MultiLine = false;
            this.DepositTotal.Name = "DepositTotal";
            this.DepositTotal.OutputFormat = resources.GetString("DepositTotal.OutputFormat");
            this.DepositTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.DepositTotal.SummaryGroup = "SlipNoHeader";
            this.DepositTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DepositTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DepositTotal.Text = "123,456,789,012";
            this.DepositTotal.Top = 0.0625F;
            this.DepositTotal.Width = 0.9212598F;
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
            this.line2.Top = 0.25F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.25F;
            this.line2.Y2 = 0.25F;
            // 
            // ConsTaxTotal
            // 
            this.ConsTaxTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.ConsTaxTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.ConsTaxTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxTotal.Border.RightColor = System.Drawing.Color.Black;
            this.ConsTaxTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxTotal.Border.TopColor = System.Drawing.Color.Black;
            this.ConsTaxTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxTotal.DataField = "SalsePriceConsTax";
            this.ConsTaxTotal.Height = 0.1377953F;
            this.ConsTaxTotal.Left = 6.1875F;
            this.ConsTaxTotal.MultiLine = false;
            this.ConsTaxTotal.Name = "ConsTaxTotal";
            this.ConsTaxTotal.OutputFormat = resources.GetString("ConsTaxTotal.OutputFormat");
            this.ConsTaxTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.ConsTaxTotal.SummaryGroup = "SlipNoHeader";
            this.ConsTaxTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.ConsTaxTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ConsTaxTotal.Text = "123,456,789,012";
            this.ConsTaxTotal.Top = 0.0625F;
            this.ConsTaxTotal.Width = 0.9212598F;
            // 
            // PMHNB02193P_01_Detail
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 10.875F;
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.SlipNoHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SlipNoFooter);
            this.Sections.Add(this.TitleFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalsePriceConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxationDivCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxLayMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalsePriceConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalsePriceConsTax1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalsePriceConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesMoneyTaxExc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipKindName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySlipNumDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        private void SlipNoFooter_Format(object sender, EventArgs e)
        {
            int iSalesTotal   = 0;
            int iSalsePriceConsTax = 0;
            int iDepositTotal = 0;

            if (this.SalesTotal.Value != null)
            {
                iSalesTotal = TStrConv.StrToIntDef(this.SalesTotal.Value.ToString(), 0);
                iSalsePriceConsTax = TStrConv.StrToIntDef(this.ConsTaxTotal.Value.ToString(), 0);
            }

            if (this.DepositTotal.Value != null)
            {
                this.DepositTotal.Visible = true;
                iDepositTotal = TStrConv.StrToIntDef(this.DepositTotal.Value.ToString(), 0);
                if (this.DepositTotal.Value.ToString() != "0")
                {
                    this.DepositTotal.Visible = true;
                }
                else
                {
                    this.DepositTotal.Visible = false;
                }

            }
            else
            {
                this.DepositTotal.Visible = false;
            }
            this._keyLastTimeDemand = (this._keyLastTimeDemand + (iSalesTotal + iSalsePriceConsTax)) - iDepositTotal;
            this.Balance.Value = this._keyLastTimeDemand;
        }

        private void TitleFooter_Format(object sender, EventArgs e)
        {
            this.TotalSalesMoneyTaxExc.Value = TStrConv.StrToIntDef(this.SubSalesMoneyTaxExc.Value.ToString(), 0) - TStrConv.StrToIntDef(this.SubSalesMoneyTaxExc1.Value.ToString(), 0);
            this.TotalSalsePriceConsTax.Value = TStrConv.StrToIntDef(this.SubSalsePriceConsTax.Value.ToString(), 0) - TStrConv.StrToIntDef(this.SubSalsePriceConsTax1.Value.ToString(), 0);
        }

        private void TitleHeader_Format(object sender, EventArgs e)
        {
            this.LastTimeBalance.Value = this._keyLastTimeDemand;
        }

        private void Detail_Format(object sender, EventArgs e)
        {
            /*
            if ((string)this.SupplierCd.Value == "000000")
            {
                this.SupplierCd.Visible = false;
            }
            else
            {
                this.SupplierCd.Visible = true;
            }*/
            // 2009.02.25 30413 犬飼 消費税の印字制御 >>>>>>START
            if ((this.ConsTaxLayMethod.Value == DBNull.Value) || (this.TaxationDivCd.Value == DBNull.Value) ||
                (this.ConsTaxLayMethod.Value == null) || (this.TaxationDivCd.Value == null))
            {
                // 消費税転嫁方式と課税区分が未設定の場合は処理終了
                this.SalsePriceConsTax.Visible = true;
                return;
            }
            else
            {
                // 消費税転嫁方式　0：伝票単位
                if (this.ConsTaxLayMethod.Value.ToString().TrimEnd() == "0")
                {
                    this.SalsePriceConsTax.Visible = false;
                }
                // 消費税転嫁方式　1：明細単位
                else if (this.ConsTaxLayMethod.Value.ToString().TrimEnd() == "1")
                {
                    // 課税区分　0：課税、2：内税
                    if ((this.TaxationDivCd.Value.ToString().TrimEnd() == "0") ||
                        (this.TaxationDivCd.Value.ToString().TrimEnd() == "2"))
                    {
                        this.SalsePriceConsTax.Visible = true;
                    }
                    // 課税区分　1：非課税
                    else
                    {
                        this.SalsePriceConsTax.Visible = false;
                    }
                }
                // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                else
                {
                    // 課税区分　2：内税
                    if (this.TaxationDivCd.Value.ToString().TrimEnd() == "2")
                    {
                        this.SalsePriceConsTax.Visible = true;
                    }
                    // 課税区分　0：課税、1：非課税
                    else
                    {
                        this.SalsePriceConsTax.Visible = false;
                    }
                }
            }
            // 2009.02.25 30413 犬飼 消費税の印字制御 <<<<<<END
        }
	}
}
