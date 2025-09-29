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
	public partial class DCKOU04100UA : Form
	{
		public DCKOU04100UA()
		{
			InitializeComponent();
		}

		private DCKOU04101UA _customerCarSearchForm;

		private void SFTOK01101UA_Load(object sender, EventArgs e)
		{
			this._customerCarSearchForm = new DCKOU04101UA(1);


			this._customerCarSearchForm.IsMultiSelect = false;


			//this._customerCarSearchForm.IsMultiSelect = true;
			//this._customerCarSearchForm.ShowDialog(this, 0);
#if False
			
			this._customerCarSearchForm.Standard_UGroupBox_Expand = false;
			this._customerCarSearchForm.Detail_UGroupBox_Expand = false;
			
			this._customerCarSearchForm.SectionCode = "000001";
			this._customerCarSearchForm.SectionName = "SectionName";
			this._customerCarSearchForm.CustomerCode = 4;
			this._customerCarSearchForm.CustomerName = "CustomerName";
			this._customerCarSearchForm.SearchData(1);
			MessageBox.Show("START");
#endif

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