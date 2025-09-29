using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMZAI02030UA : Form
    {
        public PMZAI02030UA()
        {
            InitializeComponent();
        }

        private PMZAI02031UA _salesOrderRemainClearForm;

        private void PMZAI02030UA_Load(object sender, EventArgs e)
        {
            this._salesOrderRemainClearForm = new PMZAI02031UA();
            this._salesOrderRemainClearForm.TopLevel = false;
            this._salesOrderRemainClearForm.FormBorderStyle = FormBorderStyle.None;
            this._salesOrderRemainClearForm.Show();
            this.Controls.Add(this._salesOrderRemainClearForm);
            this._salesOrderRemainClearForm.Dock = DockStyle.Fill;
            this.Text = this._salesOrderRemainClearForm.Text;

            this._salesOrderRemainClearForm.FormClosed += new FormClosedEventHandler(this.SalesOrderRemainClearForm_FormClosed);
        }

        private void SalesOrderRemainClearForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}