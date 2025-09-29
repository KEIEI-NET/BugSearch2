//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �e�L�X�g�o�͂̊m�F�_�C�A���O
// �v���O�����T�v   : �e�L�X�g�o�͂̊m�F�_�C�A���O�\���������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570163-00  �쐬�S�� : �c����
// �� �� ��  K2019/08/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570217-00  �쐬�S�� : ���c�`�[
// �� �� ��  2019/11/15   �C�����e : �i�C�����e�ꗗNo.1�j�e�L�X�g�o�̓��b�Z�[�W����
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
    /// <summary>
    /// �o�͎��A���[�g���b�Z�[�W�\�������X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �o�͎��A���[�g���b�Z�[�W�\�������ł��B<br/>
    /// Programmer : �c����<br/>
    /// Date       : K2019/08/12<br/>
    /// </remarks>
    public partial class BeforeTextOutputDialog : Form
    {
        #region
        /// <summary>
        /// �e�L�X�g�o�͂̊m�F�_�C�A���O�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͂̊m�F�_�C�A���O�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        private void ubCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        #endregion

        #endregion
    }
}