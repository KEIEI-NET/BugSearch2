using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	public partial class DCHNB04170UA : Form
	{
		public DCHNB04170UA()
		{
			InitializeComponent();
		}

        private DCHNB04180UA _resultinquiryForm;

		private void DCHNB04170UA_Load(object sender, EventArgs e)
		{
            this._resultinquiryForm = new DCHNB04180UA();
			this._resultinquiryForm.TopLevel = false;
			this._resultinquiryForm.FormBorderStyle = FormBorderStyle.None;
			this._resultinquiryForm.Show();
            this.Controls.Add(this._resultinquiryForm);
			this._resultinquiryForm.Dock = DockStyle.Fill;
            this.Text = this._resultinquiryForm.Text;

			this._resultinquiryForm.FormClosed += new FormClosedEventHandler(this.ResultinquiryForm_FormClosed);
		}

		private void ResultinquiryForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}