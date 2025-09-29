using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMSCM04001UC : Form
    {
        /// <summary>���ה��l</summary>
        private string _commentDtl = string.Empty;

        /// <summary>���ה��l</summary>
        public string CommentDtl
        {
            set { this._commentDtl = value; }
            get { return this._commentDtl; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMSCM04001UC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PMSCM04001UC_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM04001UC_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = this._commentDtl;
        }

        /// <summary>
        /// close�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}