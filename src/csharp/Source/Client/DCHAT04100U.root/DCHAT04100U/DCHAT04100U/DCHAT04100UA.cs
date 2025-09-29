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
	public partial class DCHAT04100UA : Form
	{
		public DCHAT04100UA()
		{
			InitializeComponent();
		}

		private DCHAT04110UA _orderRemainReference;

		private void OrderRemainReferenceForm_FormClosed( object sender, FormClosedEventArgs e )
		{
			this.Close();
		}

		private void DCHAT04100UA_Load( object sender, EventArgs e )
		{
			this._orderRemainReference = new DCHAT04110UA();
			this._orderRemainReference.TopLevel = false;
			this._orderRemainReference.FormBorderStyle = FormBorderStyle.None;
			this._orderRemainReference.Show();
			this._orderRemainReference.Dock = DockStyle.Fill;
			this._orderRemainReference.FormClosed += new FormClosedEventHandler(this.OrderRemainReferenceForm_FormClosed);
			this.Controls.Add(this._orderRemainReference);
		}
	}
}