//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ݒ�}�X�^�i�|���D��Ǘ��p�^�[���j 
// �v���O�����T�v   : �|���ݒ�}�X�^�i�|���D��Ǘ��p�^�[���j�̏������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2010/08/10  �C�����e : �V�K�쐬
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
    /// �|���ݒ�}�X�^�i�|���D��Ǘ��p�^�[���j
    /// </summary>
    /// <remarks>
    /// Note       : �|���ݒ�}�X�^�i�|���D��Ǘ��p�^�[���j�ݒ菈���ł��B<br />
    /// Programmer : ������<br />
    /// Date       : 2010/08/10<br />
    /// </remarks>
    public partial class PMKHN09470U : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKHN09470U()
        {
            InitializeComponent();
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� private field ��

        private PMKHN09471UA _pMKHN09471UA;

        # endregion �� private field ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09470UA_Load(object sender, EventArgs e)
        {
            this._pMKHN09471UA = new PMKHN09471UA();
            this._pMKHN09471UA.TopLevel = false;
            this._pMKHN09471UA.FormBorderStyle = FormBorderStyle.None;
            this._pMKHN09471UA.Show();
            this._pMKHN09471UA.Dock = DockStyle.Fill;
            this.Text = this._pMKHN09471UA.Text;
            this.Controls.Add(this._pMKHN09471UA);
            this._pMKHN09471UA.FormClosed += new FormClosedEventHandler(this.PMKHN09470UA_FormClosed);
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09470UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion �� Private Method ��

    }
}