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
	public partial class PMKHN04000UA : Form
	{
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
		public PMKHN04000UA()
		{
			InitializeComponent();
		}
        /// <summary>
        /// �����q�t�H�[��
        /// </summary>
        private PMKHN04001UA _customerSearchForm;

        /// <summary>
        /// ���[�h�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void PMKHN04000UA_Load(object sender, EventArgs e)
		{
            this._customerSearchForm = new PMKHN04001UA();
            this._customerSearchForm.TopLevel = false;
			this._customerSearchForm.FormBorderStyle = FormBorderStyle.None;
			this._customerSearchForm.Show();
			this.Controls.Add(this._customerSearchForm);
			this._customerSearchForm.Dock = DockStyle.Fill;

			this._customerSearchForm.FormClosed += new FormClosedEventHandler(this.CustomerSearchForm_FormClosed);
		}
        /// <summary>
        /// �q�t�H�[���N���[�Y�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void CustomerSearchForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}