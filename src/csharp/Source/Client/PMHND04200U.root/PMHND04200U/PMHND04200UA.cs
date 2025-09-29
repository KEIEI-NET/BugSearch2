//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ɖ�
// �v���O�����T�v   : ���i�Ɖ�t���[��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 杍^
// �� �� ��  2017/07/20  �C�����e : �V�K�쐬
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
    /// <summary>
    /// ���i�Ɖ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ɖ���s���܂��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/07/20</br>
    /// </remarks>
	public partial class PMHND04200UA : Form
	{
        /// <summary>
        /// ���i�Ɖ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�Ɖ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
		public PMHND04200UA()
		{
			InitializeComponent();
		}

        private PMHND04201UA InspectInfoForm;

        /// <summary>
        /// Form.Load �C�x���g (PMHND04200U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����\�������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void PMHND04200UA_Load(object sender, EventArgs e)
        {
            this.InspectInfoForm = new PMHND04201UA();
            this.InspectInfoForm.TopLevel = false;
            this.InspectInfoForm.FormBorderStyle = FormBorderStyle.None;
            this.InspectInfoForm.Show();
            this.Controls.Add(this.InspectInfoForm);
            this.InspectInfoForm.Dock = DockStyle.Fill;

            this.InspectInfoForm.FormClosed += new FormClosedEventHandler(this.InspectInfoForm_FormClosed);

        }

        /// <summary>
        /// Form.Closed �C�x���g (PMHND04200U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void InspectInfoForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}