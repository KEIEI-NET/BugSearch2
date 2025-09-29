using System;
using Broadleaf.Library.Text;
using DataDynamics.ActiveReports;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ìæà”êÊå≥í†ñæç◊ÉtÉHÅ[ÉÄàÛç¸ÉNÉâÉX
	/// </summary>
	/// <remarks>
	/// <br>Note       : ìæà”êÊå≥í†ÇÃñæç◊àÛç¸ÇçsÇ¢Ç‹Ç∑ÅB</br>
	/// <br>Programmer : 20081 ïDìc óEêl</br>
    /// <br>Date       : 2007.11.14</br>
    /// <br>Programmer : 30009 èaíJ ëÂï„</br>
    /// <br>Date       : 2009.01.21</br>
    /// <br>Note       : PM.NSópÇ…èCê≥</br>
    /// <br>Note       : Å¶DCÅ®PMÇ≈ïœçXÇ™ïKóvÇ»ïîï™ÇÃÇ›èCê≥ÇµÇ‹ÇµÇΩÅBÅ¶</br>
    /// <br>Note       : Å¶PMÇ≈ïsóvÇ»èàóùÇ™Ç†Ç¡ÇƒÇ‡ñ‚ëËÇ™Ç»ÇØÇÍÇŒÇªÇÃÇ‹Ç‹Ç…ÇµÇƒÇ†ÇËÇ‹Ç∑Å¶</br>
    /// <br></br>
	/// </remarks>
	public class DCKAU02622P_01_Detail : DataDynamics.ActiveReports.ActiveReport3
	{
		//================================================================================
		//  ÉRÉìÉXÉgÉâÉNÉ^Å[
		//================================================================================
		#region ÉRÉìÉXÉgÉâÉNÉ^Å[
		public DCKAU02622P_01_Detail()
		{
			InitializeComponent();
		}
		#endregion

        private TextBox DraftPayTimeLimit;
        private TextBox PartySlipNum;
        private Line Line87;

		//================================================================================
		//  ì‡ïîïœêî
		//================================================================================
		#region private member
		// ãíì_èÓïÒàÛéöóLñ≥
		private bool _isSectionPrint = false;
        private Label label12;
        private TextBox TotalSalesTotal;
        private TextBox TotalSalesSubtotalTax;
        private TextBox textBox5;
   		#endregion
        private TextBox SubSalesTotal1;
        private TextBox SubSalesSubtotalTax1;
        private TextBox SubSalesTotal;
        private TextBox SubSalesSubtotalTax;
        private Label label1;
        private TextBox LastTimeBalance;
        private TextBox GoodsName;

        public int _keyLastTimeDemand = 0;

		//================================================================================
		//  ÉvÉçÉpÉeÉB 
		//================================================================================
		#region public property
		/// <summary>
		/// ãíì_èÓïÒàÛéöóLñ≥
		/// </summary>
		public bool IsSectionPrint
		{
			set{this._isSectionPrint = value;}
		}
		#endregion
		
		//================================================================================
		//  ÉCÉxÉìÉg
		//================================================================================
		#region event
		/// <summary>
		/// ñæç◊ÉrÉtÉHÅ[ÉvÉäÉìÉgÉCÉxÉìÉg
		/// </summary>
		/// <param name="sender">ÉCÉxÉìÉgÉ\Å[ÉX</param>
		/// <param name="e">ÉCÉxÉìÉgÉfÅ[É^</param>
		/// <remarks>
		/// <br>Note        : ÉZÉNÉVÉáÉìÇ™ÉyÅ[ÉWÇ…ï`âÊÇ≥ÇÍÇÈëOÇ…î≠ê∂ÇµÇ‹Ç∑ÅB</br>
		/// <br>Programmer  : 20081 ïDìc óEêl</br>
        /// <br>Date        : 2007.11.14</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// ÉåÉ|Å[Égópï∂éöóÒï“èWèàóù
			PrintCommonLibrary.ConvertReportString(this.Detail);
		}
		#endregion
		
		// ===============================================================================
		// ActiveReportsÉfÉUÉCÉiÇ≈ê∂ê¨Ç≥ÇÍÇΩÉRÅ[Éh
		// ===============================================================================
		#region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox AddUpDate;
        private DataDynamics.ActiveReports.TextBox SlipNo;
        private DataDynamics.ActiveReports.TextBox SalesSlipKindName;
		private DataDynamics.ActiveReports.TextBox SalesTotal;
		private DataDynamics.ActiveReports.TextBox SalesSubtotalTax;
		private DataDynamics.ActiveReports.TextBox Deposit;
		private DataDynamics.ActiveReports.TextBox Balance;
        private DataDynamics.ActiveReports.TextBox SlipNote;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKAU02622P_01_Detail));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.AddUpDate = new DataDynamics.ActiveReports.TextBox();
            this.SlipNo = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipKindName = new DataDynamics.ActiveReports.TextBox();
            this.SalesTotal = new DataDynamics.ActiveReports.TextBox();
            this.SalesSubtotalTax = new DataDynamics.ActiveReports.TextBox();
            this.Deposit = new DataDynamics.ActiveReports.TextBox();
            this.Balance = new DataDynamics.ActiveReports.TextBox();
            this.SlipNote = new DataDynamics.ActiveReports.TextBox();
            this.DraftPayTimeLimit = new DataDynamics.ActiveReports.TextBox();
            this.PartySlipNum = new DataDynamics.ActiveReports.TextBox();
            this.Line87 = new DataDynamics.ActiveReports.Line();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.LastTimeBalance = new DataDynamics.ActiveReports.TextBox();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.TotalSalesTotal = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesSubtotalTax = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.SubSalesTotal1 = new DataDynamics.ActiveReports.TextBox();
            this.SubSalesSubtotalTax1 = new DataDynamics.ActiveReports.TextBox();
            this.SubSalesTotal = new DataDynamics.ActiveReports.TextBox();
            this.SubSalesSubtotalTax = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipKindName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSubtotalTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayTimeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesSubtotalTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesTotal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesSubtotalTax1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesSubtotalTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.AddUpDate,
            this.SlipNo,
            this.SalesSlipKindName,
            this.SalesTotal,
            this.SalesSubtotalTax,
            this.Deposit,
            this.Balance,
            this.SlipNote,
            this.DraftPayTimeLimit,
            this.PartySlipNum,
            this.Line87,
            this.GoodsName});
            this.Detail.Height = 0.375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.AddUpDate.Style = "text-align: left; font-size: 8pt; white-space: inherit; vertical-align: top; ";
            this.AddUpDate.Text = "2007îN05åé09ì˙";
            this.AddUpDate.Top = 0.0625F;
            this.AddUpDate.Width = 0.8125F;
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
            this.SlipNo.Left = 0.875F;
            this.SlipNo.MultiLine = false;
            this.SlipNo.Name = "SlipNo";
            this.SlipNo.Style = "text-align: left; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
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
            this.SalesSlipKindName.Height = 0.125F;
            this.SalesSlipKindName.Left = 1.489583F;
            this.SalesSlipKindName.MultiLine = false;
            this.SalesSlipKindName.Name = "SalesSlipKindName";
            this.SalesSlipKindName.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.SalesSlipKindName.Text = "îÑè„";
            this.SalesSlipKindName.Top = 0.0625F;
            this.SalesSlipKindName.Width = 0.3125F;
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
            this.SalesTotal.DataField = "SalesTotal";
            this.SalesTotal.Height = 0.1377953F;
            this.SalesTotal.Left = 1.875F;
            this.SalesTotal.MultiLine = false;
            this.SalesTotal.Name = "SalesTotal";
            this.SalesTotal.OutputFormat = resources.GetString("SalesTotal.OutputFormat");
            this.SalesTotal.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.SalesTotal.Text = "123,456,789,012";
            this.SalesTotal.Top = 0.0625F;
            this.SalesTotal.Width = 0.9212598F;
            // 
            // SalesSubtotalTax
            // 
            this.SalesSubtotalTax.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSubtotalTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSubtotalTax.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSubtotalTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSubtotalTax.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSubtotalTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSubtotalTax.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSubtotalTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSubtotalTax.DataField = "SalesSubtotalTax";
            this.SalesSubtotalTax.Height = 0.1377953F;
            this.SalesSubtotalTax.Left = 2.8125F;
            this.SalesSubtotalTax.MultiLine = false;
            this.SalesSubtotalTax.Name = "SalesSubtotalTax";
            this.SalesSubtotalTax.OutputFormat = resources.GetString("SalesSubtotalTax.OutputFormat");
            this.SalesSubtotalTax.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.SalesSubtotalTax.Text = "123,456,789,012";
            this.SalesSubtotalTax.Top = 0.0625F;
            this.SalesSubtotalTax.Width = 0.9212598F;
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
            this.Deposit.Left = 3.75F;
            this.Deposit.MultiLine = false;
            this.Deposit.Name = "Deposit";
            this.Deposit.OutputFormat = resources.GetString("Deposit.OutputFormat");
            this.Deposit.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.Deposit.Text = "123,456,789,012";
            this.Deposit.Top = 0.0625F;
            this.Deposit.Width = 0.9212598F;
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
            this.Balance.Left = 5.625F;
            this.Balance.MultiLine = false;
            this.Balance.Name = "Balance";
            this.Balance.OutputFormat = resources.GetString("Balance.OutputFormat");
            this.Balance.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.Balance.Text = "123,456,789,012";
            this.Balance.Top = 0.0625F;
            this.Balance.Width = 0.9375F;
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
            this.SlipNote.Height = 0.125F;
            this.SlipNote.Left = 7.8125F;
            this.SlipNote.MultiLine = false;
            this.SlipNote.Name = "SlipNote";
            this.SlipNote.OutputFormat = resources.GetString("SlipNote.OutputFormat");
            this.SlipNote.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.SlipNote.Text = "ÇPÇQÇRÇSÇTÇUÇVÇWÇXÇOÇPÇQÇRÇSÇTÇUÇVÇWÇXÇOÇPÇQÇRÇSÇT";
            this.SlipNote.Top = 0.0625F;
            this.SlipNote.Width = 2.875F;
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
            this.DraftPayTimeLimit.DataField = "DraftPayTimeLimit";
            this.DraftPayTimeLimit.Height = 0.125F;
            this.DraftPayTimeLimit.Left = 4.75F;
            this.DraftPayTimeLimit.MultiLine = false;
            this.DraftPayTimeLimit.Name = "DraftPayTimeLimit";
            this.DraftPayTimeLimit.OutputFormat = resources.GetString("DraftPayTimeLimit.OutputFormat");
            this.DraftPayTimeLimit.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.DraftPayTimeLimit.Text = "2007îN05åé09ì˙";
            this.DraftPayTimeLimit.Top = 0.0625F;
            this.DraftPayTimeLimit.Width = 0.8125F;
            // 
            // PartySlipNum
            // 
            this.PartySlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.PartySlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.PartySlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.PartySlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.PartySlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySlipNum.DataField = "PartySlipNum";
            this.PartySlipNum.Height = 0.125F;
            this.PartySlipNum.Left = 6.59375F;
            this.PartySlipNum.MultiLine = false;
            this.PartySlipNum.Name = "PartySlipNum";
            this.PartySlipNum.Style = "text-align: left; font-size: 8pt; font-family: ÇlÇr ñæí©; white-space: inherit; ";
            this.PartySlipNum.Text = "12345678901234567890";
            this.PartySlipNum.Top = 0.0625F;
            this.PartySlipNum.Width = 1.1875F;
            // 
            // Line87
            // 
            this.Line87.Border.BottomColor = System.Drawing.Color.Black;
            this.Line87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Border.LeftColor = System.Drawing.Color.Black;
            this.Line87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Border.RightColor = System.Drawing.Color.Black;
            this.Line87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Border.TopColor = System.Drawing.Color.Black;
            this.Line87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Height = 0F;
            this.Line87.Left = 0F;
            this.Line87.LineWeight = 1F;
            this.Line87.Name = "Line87";
            this.Line87.Top = 0.25F;
            this.Line87.Width = 10.75F;
            this.Line87.X1 = 0F;
            this.Line87.X2 = 10.75F;
            this.Line87.Y1 = 0.25F;
            this.Line87.Y2 = 0.25F;
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
            this.GoodsName.Left = 1.5F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.GoodsName.Text = "îÑè„";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 0.5625F;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.LastTimeBalance});
            this.TitleHeader.Height = 0.3125F;
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
            this.label1.Text = "ëOâÒécçÇ";
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
            this.LastTimeBalance.Left = 5.625F;
            this.LastTimeBalance.MultiLine = false;
            this.LastTimeBalance.Name = "LastTimeBalance";
            this.LastTimeBalance.OutputFormat = resources.GetString("LastTimeBalance.OutputFormat");
            this.LastTimeBalance.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.LastTimeBalance.SummaryGroup = "TitleHeader";
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
            this.TotalSalesTotal,
            this.TotalSalesSubtotalTax,
            this.textBox5,
            this.SubSalesTotal1,
            this.SubSalesSubtotalTax1,
            this.SubSalesTotal,
            this.SubSalesSubtotalTax});
            this.TitleFooter.Height = 0.3854167F;
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
            this.label12.Left = 0.25F;
            this.label12.Name = "label12";
            this.label12.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.label12.Text = "çáåv";
            this.label12.Top = 0.0625F;
            this.label12.Width = 1.125F;
            // 
            // TotalSalesTotal
            // 
            this.TotalSalesTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesTotal.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesTotal.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesTotal.Height = 0.1377953F;
            this.TotalSalesTotal.Left = 1.854167F;
            this.TotalSalesTotal.MultiLine = false;
            this.TotalSalesTotal.Name = "TotalSalesTotal";
            this.TotalSalesTotal.OutputFormat = resources.GetString("TotalSalesTotal.OutputFormat");
            this.TotalSalesTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.TotalSalesTotal.SummaryGroup = "TitleHeader";
            this.TotalSalesTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TotalSalesTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TotalSalesTotal.Text = "123,456,789,012";
            this.TotalSalesTotal.Top = 0.1145833F;
            this.TotalSalesTotal.Width = 0.9212598F;
            // 
            // TotalSalesSubtotalTax
            // 
            this.TotalSalesSubtotalTax.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesSubtotalTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesSubtotalTax.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesSubtotalTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesSubtotalTax.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesSubtotalTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesSubtotalTax.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesSubtotalTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesSubtotalTax.Height = 0.1377953F;
            this.TotalSalesSubtotalTax.Left = 2.802083F;
            this.TotalSalesSubtotalTax.MultiLine = false;
            this.TotalSalesSubtotalTax.Name = "TotalSalesSubtotalTax";
            this.TotalSalesSubtotalTax.OutputFormat = resources.GetString("TotalSalesSubtotalTax.OutputFormat");
            this.TotalSalesSubtotalTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.TotalSalesSubtotalTax.SummaryGroup = "TitleHeader";
            this.TotalSalesSubtotalTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TotalSalesSubtotalTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TotalSalesSubtotalTax.Text = "123,456,789,012";
            this.TotalSalesSubtotalTax.Top = 0.1145833F;
            this.TotalSalesSubtotalTax.Width = 0.9212598F;
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
            this.textBox5.DataField = "Deposit";
            this.textBox5.Height = 0.1377953F;
            this.textBox5.Left = 3.75F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.textBox5.SummaryGroup = "TitleHeader";
            this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox5.Text = "123,456,789,012";
            this.textBox5.Top = 0.1145833F;
            this.textBox5.Width = 0.9212598F;
            // 
            // SubSalesTotal1
            // 
            this.SubSalesTotal1.Border.BottomColor = System.Drawing.Color.Black;
            this.SubSalesTotal1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesTotal1.Border.LeftColor = System.Drawing.Color.Black;
            this.SubSalesTotal1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesTotal1.Border.RightColor = System.Drawing.Color.Black;
            this.SubSalesTotal1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesTotal1.Border.TopColor = System.Drawing.Color.Black;
            this.SubSalesTotal1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesTotal1.DataField = "SalesTotal1";
            this.SubSalesTotal1.Height = 0.1377953F;
            this.SubSalesTotal1.Left = 8.4375F;
            this.SubSalesTotal1.MultiLine = false;
            this.SubSalesTotal1.Name = "SubSalesTotal1";
            this.SubSalesTotal1.OutputFormat = resources.GetString("SubSalesTotal1.OutputFormat");
            this.SubSalesTotal1.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.SubSalesTotal1.SummaryGroup = "TitleHeader";
            this.SubSalesTotal1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubSalesTotal1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubSalesTotal1.Text = "123,456,789,012";
            this.SubSalesTotal1.Top = 0.125F;
            this.SubSalesTotal1.Visible = false;
            this.SubSalesTotal1.Width = 0.9212598F;
            // 
            // SubSalesSubtotalTax1
            // 
            this.SubSalesSubtotalTax1.Border.BottomColor = System.Drawing.Color.Black;
            this.SubSalesSubtotalTax1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesSubtotalTax1.Border.LeftColor = System.Drawing.Color.Black;
            this.SubSalesSubtotalTax1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesSubtotalTax1.Border.RightColor = System.Drawing.Color.Black;
            this.SubSalesSubtotalTax1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesSubtotalTax1.Border.TopColor = System.Drawing.Color.Black;
            this.SubSalesSubtotalTax1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesSubtotalTax1.DataField = "SalesSubtotalTax1";
            this.SubSalesSubtotalTax1.Height = 0.1377953F;
            this.SubSalesSubtotalTax1.Left = 9.5625F;
            this.SubSalesSubtotalTax1.MultiLine = false;
            this.SubSalesSubtotalTax1.Name = "SubSalesSubtotalTax1";
            this.SubSalesSubtotalTax1.OutputFormat = resources.GetString("SubSalesSubtotalTax1.OutputFormat");
            this.SubSalesSubtotalTax1.Style = "text-align: right; font-size: 8pt; font-family: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.SubSalesSubtotalTax1.SummaryGroup = "TitleHeader";
            this.SubSalesSubtotalTax1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubSalesSubtotalTax1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubSalesSubtotalTax1.Text = "123,456,789,012";
            this.SubSalesSubtotalTax1.Top = 0.125F;
            this.SubSalesSubtotalTax1.Visible = false;
            this.SubSalesSubtotalTax1.Width = 0.9212598F;
            // 
            // SubSalesTotal
            // 
            this.SubSalesTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.SubSalesTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.SubSalesTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesTotal.Border.RightColor = System.Drawing.Color.Black;
            this.SubSalesTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesTotal.Border.TopColor = System.Drawing.Color.Black;
            this.SubSalesTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesTotal.DataField = "SalesTotal";
            this.SubSalesTotal.Height = 0.1377953F;
            this.SubSalesTotal.Left = 8.4375F;
            this.SubSalesTotal.MultiLine = false;
            this.SubSalesTotal.Name = "SubSalesTotal";
            this.SubSalesTotal.OutputFormat = resources.GetString("SubSalesTotal.OutputFormat");
            this.SubSalesTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.SubSalesTotal.SummaryGroup = "TitleHeader";
            this.SubSalesTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubSalesTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubSalesTotal.Text = "123,456,789,012";
            this.SubSalesTotal.Top = 0.125F;
            this.SubSalesTotal.Visible = false;
            this.SubSalesTotal.Width = 0.9212598F;
            // 
            // SubSalesSubtotalTax
            // 
            this.SubSalesSubtotalTax.Border.BottomColor = System.Drawing.Color.Black;
            this.SubSalesSubtotalTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesSubtotalTax.Border.LeftColor = System.Drawing.Color.Black;
            this.SubSalesSubtotalTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesSubtotalTax.Border.RightColor = System.Drawing.Color.Black;
            this.SubSalesSubtotalTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesSubtotalTax.Border.TopColor = System.Drawing.Color.Black;
            this.SubSalesSubtotalTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubSalesSubtotalTax.DataField = "SalesSubtotalTax";
            this.SubSalesSubtotalTax.Height = 0.1377953F;
            this.SubSalesSubtotalTax.Left = 9.5625F;
            this.SubSalesSubtotalTax.MultiLine = false;
            this.SubSalesSubtotalTax.Name = "SubSalesSubtotalTax";
            this.SubSalesSubtotalTax.OutputFormat = resources.GetString("SubSalesSubtotalTax.OutputFormat");
            this.SubSalesSubtotalTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ÇlÇr ÉSÉVÉbÉN; white-space: inherit; ";
            this.SubSalesSubtotalTax.SummaryGroup = "TitleHeader";
            this.SubSalesSubtotalTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubSalesSubtotalTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubSalesSubtotalTax.Text = "123,456,789,012";
            this.SubSalesSubtotalTax.Top = 0.125F;
            this.SubSalesSubtotalTax.Visible = false;
            this.SubSalesSubtotalTax.Width = 0.9212598F;
            // 
            // DCKAU02622P_01_Detail
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.AddUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipKindName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSubtotalTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayTimeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesSubtotalTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesTotal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesSubtotalTax1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubSalesSubtotalTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        private void Detail_Format(object sender, EventArgs e)
        {
            int iSalesTotal = 0;
            int iSalesSubtotalTax = 0;
            int iDeposit = 0;

            if (this.SalesTotal.Value != null)
            {
                iSalesTotal = TStrConv.StrToIntDef(this.SalesTotal.Value.ToString(), 0);
                iSalesSubtotalTax = TStrConv.StrToIntDef(this.SalesSubtotalTax.Value.ToString(), 0);
            }
            if (this.Deposit.Value != null)
            {
                iDeposit = TStrConv.StrToIntDef(this.Deposit.Value.ToString(), 0);
            }
            _keyLastTimeDemand = (this._keyLastTimeDemand + (iSalesTotal + iSalesSubtotalTax)) - iDeposit;
            this.Balance.Value = this._keyLastTimeDemand;

            if (this.SalesSlipKindName.Text == "ì¸ã‡")
            {
                this.SalesSlipKindName.Visible = false;
                this.GoodsName.Visible = true;
            }
            else
            {
                this.SalesSlipKindName.Visible = true;
                this.GoodsName.Visible = false;
            }
        }

        private void TitleFooter_Format(object sender, EventArgs e)
        {
            this.TotalSalesTotal.Value = TStrConv.StrToIntDef(this.SubSalesTotal.Value.ToString(), 0) - TStrConv.StrToIntDef(this.SubSalesTotal1.Value.ToString(), 0);
            this.TotalSalesSubtotalTax.Value = TStrConv.StrToIntDef(this.SubSalesSubtotalTax.Value.ToString(), 0) - TStrConv.StrToIntDef(this.SubSalesSubtotalTax1.Value.ToString(), 0);
        }

        private void TitleHeader_Format(object sender, EventArgs e)
        {
            this.LastTimeBalance.Value = this._keyLastTimeDemand;
        }
	}
}
