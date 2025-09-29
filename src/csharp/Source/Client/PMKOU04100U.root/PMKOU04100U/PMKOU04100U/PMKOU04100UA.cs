using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	public partial class PMKOU04100UA : Form
	{
        public PMKOU04100UA()
		{
			InitializeComponent();
		}

        private PMKOU04110UA _suppYearResultForm;

        private void PMKOU04100UA_Load(object sender, EventArgs e)
		{
            this._suppYearResultForm = new PMKOU04110UA();
            this._suppYearResultForm.TopLevel = false;
            this._suppYearResultForm.FormBorderStyle = FormBorderStyle.None;
            this._suppYearResultForm.Show();
            this.Controls.Add(this._suppYearResultForm);
            this._suppYearResultForm.Dock = DockStyle.Fill;
            this.Text = this._suppYearResultForm.Text;

            this._suppYearResultForm.FormClosed += new FormClosedEventHandler(this.SuppYearResultForm_FormClosed);
		}

        private void SuppYearResultForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}