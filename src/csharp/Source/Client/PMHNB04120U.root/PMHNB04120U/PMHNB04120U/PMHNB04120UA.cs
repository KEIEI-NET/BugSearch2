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
	public partial class PMHNB04120UA : Form
	{
        public PMHNB04120UA()
		{
			InitializeComponent();
		}

        private PMHNB04121UA _customerPastExperience;

        private void PMHNB04120UA_Load(object sender, EventArgs e)
		{
            this._customerPastExperience = new PMHNB04121UA();
            this._customerPastExperience.TopLevel = false;
            this._customerPastExperience.FormBorderStyle = FormBorderStyle.None;
            this._customerPastExperience.Show();
            this.Controls.Add(this._customerPastExperience);
            this._customerPastExperience.Dock = DockStyle.Fill;
            this._customerPastExperience.FormClosed += new FormClosedEventHandler(this.CustomerPastExperience_FormClosed);
		}

        private void CustomerPastExperience_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
	}
}