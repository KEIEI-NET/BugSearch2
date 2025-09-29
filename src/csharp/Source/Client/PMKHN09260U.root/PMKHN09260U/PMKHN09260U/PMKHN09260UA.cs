using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms; // ADD ���N 2013/06/24 for Redmine#35501

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

        // ----- ADD ���N�@2013/06/24�@Redmine#35501 ----->>>>>
        /// <summary>
        /// ��ʂ����
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote  : 2013/06/24 ���N</br>
        /// <br>            : 2013/06/18�z�M��</br>
        /// <br>            : Redmine #35501 #14�̑Ή�</br>
        /// </remarks>
        private void onClosing(object sender, CancelEventArgs e)
        {
            if (this._customerCreditForm.WaitFlag)
            {
                DialogResult result = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                "PMKHN09260U",
                                "�^�C�}�[�Z�b�g���ł��B"+"\r\n\r\n"+"�����𒆒f���ĉ�ʂ���Ă���낵���ł����H",
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
        // ----- ADD ���N�@2013/06/24�@Redmine#35501 -----<<<<<
	}
}