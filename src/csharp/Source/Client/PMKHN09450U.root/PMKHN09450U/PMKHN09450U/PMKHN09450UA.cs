//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڕW�����ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/20  �C�����e : �V�K�쐬
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
    /// �ڕW�����ݒ�
    /// </summary>
    /// <remarks>
    /// Note       : �ڕW�����ݒ菈���ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.04.20<br />
    /// </remarks>
    public partial class PMKHN09450UA : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKHN09450UA()
        {
            InitializeComponent();
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� private field ��

        private PMKHN09451UA _objAutoSetForm;

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
        /// <br>Date       : 2009.05.01</br>
        /// </remarks>
        private void PMKHN09450UA_Load(object sender, EventArgs e)
        {
            this._objAutoSetForm = new PMKHN09451UA();
            this._objAutoSetForm.TopLevel = false;
            this._objAutoSetForm.FormBorderStyle = FormBorderStyle.None;
            this._objAutoSetForm.Show();
            this._objAutoSetForm.Dock = DockStyle.Fill;
            this.Text = this._objAutoSetForm.Text;
            this.Controls.Add(this._objAutoSetForm);
            this._objAutoSetForm.FormClosed += new FormClosedEventHandler(this.ObjAutoSetForm_FormClosed);
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
        /// <br>Date       : 2009.05.01</br>
        /// </remarks>
        private void ObjAutoSetForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion �� Private Method ��
    }
}