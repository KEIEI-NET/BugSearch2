//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�p�^�[�����������Ɖ�
// �v���O�����T�v   : ���[�J�[�p�^�[�����������Ɖ�t���[��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11570249-00 �쐬�S�� : ���O
// �� �� ��  2020/03/09  �C�����e : �V�K�쐬
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
    /// ���[�J�[�p�^�[�����������Ɖ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�J�[�p�^�[�����������Ɖ���s���܂��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/03/09</br>
    /// </remarks>
	public partial class PMKHN09783UA : Form
	{
        /// <summary>
        /// ���[�J�[�p�^�[�����������Ɖ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�p�^�[�����������Ɖ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
		public PMKHN09783UA()
		{
			InitializeComponent();
		}

        private PMKHN09783UB MakerGoodsPtrnHisForm;

        /// <summary>
        /// Form.Load �C�x���g (PMKHN09783U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����\�������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09783UA_Load(object sender, EventArgs e)
        {
            this.MakerGoodsPtrnHisForm = new PMKHN09783UB();
            this.MakerGoodsPtrnHisForm.TopLevel = false;
            this.MakerGoodsPtrnHisForm.FormBorderStyle = FormBorderStyle.None;
            this.MakerGoodsPtrnHisForm.Show();
            this.Controls.Add(this.MakerGoodsPtrnHisForm);
            this.MakerGoodsPtrnHisForm.Dock = DockStyle.Fill;

            this.MakerGoodsPtrnHisForm.FormClosed += new FormClosedEventHandler(this.MakerGoodsPtrnHisForm_FormClosed);

        }

        /// <summary>
        /// Form.Closed �C�x���g (PMKHN09783U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void MakerGoodsPtrnHisForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}