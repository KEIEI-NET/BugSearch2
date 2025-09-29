//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ɖ�
// �v���O�����T�v   : �e�L�X�g�o�͂̊m�F�_�C�A���O
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470154-00 �쐬�S�� : ���O
// �� �� ��  2018/10/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class BeforeTextOutputDialog : Form
    {
        #region
        /// <summary>
        /// �e�L�X�g�o�͂̊m�F�_�C�A���O�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͂̊m�F�_�C�A���O�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        public BeforeTextOutputDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Event
        /// <summary>
        /// ����\����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ����\�����C�x���g�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void BeforeTextOutputDialog_Shown(object sender, EventArgs e)
        {
            this.ubCancel.Focus();
        }

        #region ubOk_Click Event
        /// <summary>
        /// ubOk_Click Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �u�͂��v�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void ubOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
        #endregion

        #region ubCancel_Click Event
        /// <summary>
        /// ubCancel_Click Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �u�������v�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void ubCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        #endregion

        #endregion
    }
}