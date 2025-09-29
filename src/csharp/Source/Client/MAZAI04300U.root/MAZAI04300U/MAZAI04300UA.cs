//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌ɓ��o�ɏƉ�
// �v���O�����T�v   : �݌ɓ��o�ɏƉ�t���[��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070263-00 �쐬�S�� : ���V��
// �� �� ��  2015/03/27  �C�����e : Redmine#44209 �݌ɓ��o�ɏƉ��ʂɁu�폜�σ}�X�^�̌����v�`�F�b�N�{�^����ǉ��Ή�
//----------------------------------------------------------------------------//
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
	public partial class MAZAI04300UA : Form
	{
		public MAZAI04300UA()
		{
			InitializeComponent();
		}

		private MAZAI04310UA _stockAcPayHisSearchForm;

        private void MAZAI04300UA_Load(object sender, EventArgs e)
        {
            this._stockAcPayHisSearchForm = new MAZAI04310UA();
            this._stockAcPayHisSearchForm.TopLevel = false;
            this._stockAcPayHisSearchForm.FormBorderStyle = FormBorderStyle.None;
            this._stockAcPayHisSearchForm.Show();
            this.Controls.Add(this._stockAcPayHisSearchForm);
            this._stockAcPayHisSearchForm.Dock = DockStyle.Fill;

            this._stockAcPayHisSearchForm.FormClosed += new FormClosedEventHandler(this.StockAcPayHisSearchForm_FormClosed);

        }

        private void StockAcPayHisSearchForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}

        //----- ADD 2015/03/27 ���V�� Redmine#44209 �݌ɓ��o�ɏƉ��ʂɁu�폜�σ}�X�^�̌����v�`�F�b�N�{�^����ǉ��Ή�------>>>>>
        /// <summary>
        /// Form��close�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remark>
        /// <br>Update Note: 2015/03/27 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �݌ɓ��o�ɏƉ��ʂɁu�폜�σ}�X�^�̌����v�`�F�b�N�{�^����ǉ��Ή�</br>
        /// </remark>
        private void MAZAI04300UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._stockAcPayHisSearchForm.BeforeClose();
        }
        //----- ADD 2015/03/27 ���V�� Redmine#44209 �݌ɓ��o�ɏƉ��ʂɁu�폜�σ}�X�^�̌����v�`�F�b�N�{�^����ǉ��Ή�------<<<<<

	}
}