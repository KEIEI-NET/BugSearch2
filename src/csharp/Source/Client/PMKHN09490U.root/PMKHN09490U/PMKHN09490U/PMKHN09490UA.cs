//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^
// �v���O�����T�v   : �݌Ƀ}�X�^�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2010/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// �݌Ƀ}�X�^
    /// </summary>
    /// <remarks>
    /// Note       : �݌Ƀ}�X�^�ݒ菈���ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2010/08/11<br />
    /// </remarks>
    public partial class PMKHN09490UA : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        public PMKHN09490UA()
        {
            InitializeComponent();
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� private field ��

        private PMKHN09491UA _pmKHN09491UA;

        # endregion �� private field ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void PMKHN09490UA_Load(object sender, EventArgs e)
        {
            this._pmKHN09491UA = new PMKHN09491UA();
            this._pmKHN09491UA.TopLevel = false;
            this._pmKHN09491UA.FormBorderStyle = FormBorderStyle.None;
            this._pmKHN09491UA.Show();
            this._pmKHN09491UA.Dock = DockStyle.Fill;
            this.Text = this._pmKHN09491UA.Text;
            this.Controls.Add(this._pmKHN09491UA);
            this._pmKHN09491UA.FormClosed += new FormClosedEventHandler(this.PMKHN09490UA_FormClosed);
        }
        # endregion �� �t�H�[�����[�h ��

        #region �� Private Method ��
        /// <summary>
        /// ��ʕ��鏈��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void PMKHN09490UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion �� Private Method ��
    }
}