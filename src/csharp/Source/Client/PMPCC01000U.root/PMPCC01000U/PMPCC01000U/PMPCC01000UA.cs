//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ惁�b�Z�[�W�ݒ菈��
// �v���O�����T�v   : ���Ӑ惁�b�Z�[�W�ݒ菈���ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
    /// ���Ӑ惁�b�Z�[�W�ݒ菈��
    /// </summary>
    /// <remarks>
    /// Note       : ���Ӑ惁�b�Z�[�W�ݒ菈���ł��B<br />
    /// Programmer : ���C��<br />
    /// Date       : 2011.08.08<br />
    /// </remarks>
    public partial class PMPCC01000UA : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// ���Ӑ惁�b�Z�[�W�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08 </br>
        /// </remarks>
        public PMPCC01000UA()
        {
            InitializeComponent();
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� private field ��

        private PMPCC01001UA _updateCountForm;

        # endregion �� private field ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PMPCC01000UA_Load(object sender, EventArgs e)
        {
            this._updateCountForm = new PMPCC01001UA();
            this._updateCountForm.TopLevel = false;
            this._updateCountForm.FormBorderStyle = FormBorderStyle.None;
            this._updateCountForm.Show();
            this._updateCountForm.Dock = DockStyle.Fill;
            this.Text = this._updateCountForm.Text;
            this.Controls.Add(this._updateCountForm);
            this._updateCountForm.FormClosed += new FormClosedEventHandler(this.PMPCC01000UA_FormClosed);
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PMPCC01000UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion �� Private Method ��
    }
}