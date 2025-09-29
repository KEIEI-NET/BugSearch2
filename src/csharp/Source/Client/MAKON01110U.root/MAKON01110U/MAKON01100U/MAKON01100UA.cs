using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
//using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    public partial class MAKON01100UA : Form
	{
		public MAKON01100UA()
		{
			InitializeComponent();
		}

		MAKON01110UA _stockSlipInput;

        //public MAKON01110UA StockSlipInput
        //{
        //    get
        //    {
        //        if (_stockSlipInput == null)
        //        {
        //            _stockSlipInput = new MAKON01110UA();
        //        }
        //        return _stockSlipInput;
        //    }
        //}

		private void MAKON01100UA_Load(object sender, EventArgs e)
		{
            this._stockSlipInput = new MAKON01110UA();
            this._stockSlipInput.TopLevel = false;
            this._stockSlipInput.FormBorderStyle = FormBorderStyle.None;
            this._stockSlipInput.Show();
            this._stockSlipInput.Dock = DockStyle.Fill;
            this.Text = this._stockSlipInput.Text;
            this._stockSlipInput.FormClosed += new FormClosedEventHandler(this.StockSlipInput_FormClosed);
            this.Controls.Add(this._stockSlipInput); 
		}

		private void StockSlipInput_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}

    }
}