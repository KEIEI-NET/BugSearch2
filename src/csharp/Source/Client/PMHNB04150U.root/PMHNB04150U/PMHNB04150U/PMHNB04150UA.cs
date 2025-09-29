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
	public partial class PMHNB04150UA : Form
	{
        public PMHNB04150UA()
		{
			InitializeComponent();
		}

        private PMHNB04151UA _salesReport;

        private void PMHNB04150UA_Load(object sender, EventArgs e)
        {
            this._salesReport = new PMHNB04151UA();
            this._salesReport.TopLevel = false;
            this._salesReport.FormBorderStyle = FormBorderStyle.None;
            this._salesReport.Show();
            this.Controls.Add(this._salesReport);
            this._salesReport.Dock = DockStyle.Fill;
            this._salesReport.FormClosed += new FormClosedEventHandler(this.SalesReport_FormClosed);
        }

        private void SalesReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
	}
}