using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMSCM04000UA : Form
    {
        private PMSCM04001UA _pmscm04001UA;
        /// <summary>�R�}���h���C������</summary>
        private readonly string[] _commandLineArgs;

        public PMSCM04000UA()
        {
            InitializeComponent();
        }

        public PMSCM04000UA(string[] commandLineArgs)
            : this()
        {
            _commandLineArgs = commandLineArgs;
        }

        private void PMSCM04000UA_Load(object sender, EventArgs e)
        {
            this._pmscm04001UA = new PMSCM04001UA(_commandLineArgs);
            this._pmscm04001UA.TopLevel = false;
            this._pmscm04001UA.FormBorderStyle = FormBorderStyle.None;
            this._pmscm04001UA.Show();
            this.Controls.Add(this._pmscm04001UA);
            this._pmscm04001UA.Dock = DockStyle.Fill;

            this._pmscm04001UA.FormClosed += new FormClosedEventHandler(this.PMSCM04000UA_FormClosed);

            //// TEST ����`�[���͂���̌Ăѕ��e�X�g
            //this._pmscm04001UA = new PMSCM04001UA("25", "���_", 2000, "����1");
            //int count = this._pmscm04001UA.SearchInquiryCountForSalesSlip();

            //if (count > 0)
            //{
            //    Int64 a;
            //    Int32 b;
            //    string c;
            //    this._pmscm04001UA.ShowGuideForSalesSlip(this, out a, out b, out c);
            //}
        }

        private void PMSCM04000UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMSCM04000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // XML�ۑ�
            this._pmscm04001UA.SaveStateXmlData();
        }
    }
}