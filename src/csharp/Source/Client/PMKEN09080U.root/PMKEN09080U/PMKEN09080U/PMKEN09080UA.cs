using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMKEN09080U : Form
    {
        public PMKEN09080U()
        {
            InitializeComponent();
        }

        private PMKEN09081U _partsSubstUSearchForm;

        private void PMKEN09080U_Load(object sender, EventArgs e)
        {
            this._partsSubstUSearchForm = new PMKEN09081U();
            this._partsSubstUSearchForm.TopLevel = false;
            this._partsSubstUSearchForm.FormBorderStyle = FormBorderStyle.None;
            this._partsSubstUSearchForm.Show();
            this.Controls.Add(this._partsSubstUSearchForm);
            this._partsSubstUSearchForm.Dock = DockStyle.Fill;

            this._partsSubstUSearchForm.FormClosed += new FormClosedEventHandler(this.PartsSubstUSearchForm_FormClosed);
        }

        private void PartsSubstUSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}