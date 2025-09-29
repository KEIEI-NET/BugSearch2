using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms; // ADD 王君 2013/06/24 for Redmine#35501

namespace Broadleaf.Windows.Forms
{
	public partial class PMKHN09260U : Form
	{
        public PMKHN09260U()
		{
			InitializeComponent();
		}

        private PMKHN09261UA _customerCreditForm;

        private void PMKHN09260U_Load(object sender, EventArgs e)
        {
            this._customerCreditForm = new PMKHN09261UA();
            this._customerCreditForm.TopLevel = false;
            this._customerCreditForm.FormBorderStyle = FormBorderStyle.None;
            this._customerCreditForm.Show();
            this.Controls.Add(this._customerCreditForm);
            this._customerCreditForm.Dock = DockStyle.Fill;
            this._customerCreditForm.FormClosed += new FormClosedEventHandler(this.CustomerCreditForm_FormClosed);
        }

        private void CustomerCreditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        // ----- ADD 王君　2013/06/24　Redmine#35501 ----->>>>>
        /// <summary>
        /// 画面を閉じる
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote  : 2013/06/24 王君</br>
        /// <br>            : 2013/06/18配信分</br>
        /// <br>            : Redmine #35501 #14の対応</br>
        /// </remarks>
        private void onClosing(object sender, CancelEventArgs e)
        {
            if (this._customerCreditForm.WaitFlag)
            {
                DialogResult result = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                "PMKHN09260U",
                                "タイマーセット中です。"+"\r\n\r\n"+"処理を中断して画面を閉じてもよろしいですか？",
                                0,
                                MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }
        // ----- ADD 王君　2013/06/24　Redmine#35501 -----<<<<<
	}
}