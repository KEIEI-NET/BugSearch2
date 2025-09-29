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
	public partial class PMZAI04000UA : Form
	{
		public PMZAI04000UA()
		{
			InitializeComponent();
		}

		private PMZAI04001UA _customerCarSearchForm;

		private void SFTOK01101UA_Load(object sender, EventArgs e)
		{
			this._customerCarSearchForm = new PMZAI04001UA(1);
			//this._customerCarSearchForm = new PMZAI04001UA();
			this._customerCarSearchForm.TopLevel = false;
			this._customerCarSearchForm.FormBorderStyle = FormBorderStyle.None;
			this._customerCarSearchForm.Show();
			this.Controls.Add(this._customerCarSearchForm);
			this._customerCarSearchForm.Dock = DockStyle.Fill;

			this._customerCarSearchForm.FormClosed += new FormClosedEventHandler(this.CustomerCarSearchForm_FormClosed);
		}

		private void CustomerCarSearchForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}