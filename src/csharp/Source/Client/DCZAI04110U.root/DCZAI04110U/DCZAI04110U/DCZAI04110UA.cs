using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 在庫検索フォーム
    /// </summary>
    /// <remarks>
    /// <br>Note		: 起動、抽出の速度改良</br>
    /// <br>Programmer	: 20073 西 毅</br>
    /// <br>Date		: 2012/04/10</br>
    /// </remarks>
	public partial class DCZAI04110UA : Form
	{
        /// <summary>
        /// 在庫検索フォーム
        /// </summary>
		public DCZAI04110UA()
		{
			InitializeComponent();
		}

        private StockSearchGuide _stockSearchGuide;

		private void OrderRemainReferenceForm_FormClosed( object sender, FormClosedEventArgs e )
		{
			this.FormClosed -= new System.Windows.Forms.FormClosedEventHandler(this.DCZAI04110UA_FormClosed);  // T.Nishi 2012/04/10 ADD
			this.Close();
		}

		private void DCHAT04100UA_Load( object sender, EventArgs e )
		{
            this._stockSearchGuide = new StockSearchGuide();
            this._stockSearchGuide.TopLevel = false;
            this._stockSearchGuide.FormBorderStyle = FormBorderStyle.None;
            this._stockSearchGuide.ShowReference(StockSearchGuide.emSearchMode.Stock, LoginInfoAcquisition.EnterpriseCode );
            this._stockSearchGuide.Dock = DockStyle.Fill;
            this._stockSearchGuide.FormClosed += new FormClosedEventHandler( this.OrderRemainReferenceForm_FormClosed );
            this.Controls.Add( this._stockSearchGuide );
		}
		
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>
        /// フォームクローズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCZAI04110UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._stockSearchGuide.Close();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD
	}
}