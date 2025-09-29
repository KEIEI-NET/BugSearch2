using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMSCM04100UA : Form
    {
        public PMSCM04100UA()
        {
            InitializeComponent();
        }

        private PMSCM04101UA _pmscm04101UA;

        private void PMSCM04100UA_Load(object sender, EventArgs e)
        {
            this._pmscm04101UA = new PMSCM04101UA();
            this._pmscm04101UA.TopLevel = false;
            this._pmscm04101UA.FormBorderStyle = FormBorderStyle.None;
            this._pmscm04101UA.Show();
            this.Controls.Add(this._pmscm04101UA);
            this._pmscm04101UA.Dock = DockStyle.Fill;

            this._pmscm04101UA.FormClosed += new FormClosedEventHandler(this.PMSCM04100UA_FormClosed);
        }

        private void PMSCM04100UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMSCM04100UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // XML•Û‘¶
            this._pmscm04101UA.SaveStateXmlData();
        }
    }
}