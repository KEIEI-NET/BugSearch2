using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	public partial class MAZAI05150UA : Form
	{
		public MAZAI05150UA()
		{
			InitializeComponent();
		}

        private MAZAI05160UA _inventoryRenewalForm;

		private void MAZAI05150UA_Load(object sender, EventArgs e)
		{
            this._inventoryRenewalForm = new MAZAI05160UA();
			this._inventoryRenewalForm.TopLevel = false;
			this._inventoryRenewalForm.FormBorderStyle = FormBorderStyle.None;
			this._inventoryRenewalForm.Show();
            this.Controls.Add(this._inventoryRenewalForm);
			this._inventoryRenewalForm.Dock = DockStyle.Fill;
            this.Text = this._inventoryRenewalForm.Text;

			this._inventoryRenewalForm.FormClosed += new FormClosedEventHandler(this.InventoryRenewalForm_FormClosed);
		}

		private void InventoryRenewalForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}

        /// <summary>
        /// �t�H�[���I���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note: 2011/01/11 ����</br>
        /// <br>             �I����Q�Ή�</br>
        private void MAZAI05150UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._inventoryRenewalForm.SaveGridState();
        }
	}
}