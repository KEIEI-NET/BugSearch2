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
        /// <summary>明細備考</summary>
        private string _commentDtl = string.Empty;

        /// <summary>明細備考</summary>
        public string CommentDtl
        {
            set { this._commentDtl = value; }
            get { return this._commentDtl; }
        }

        /// <summary>
        /// コンストラクタ
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
        /// closeボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}