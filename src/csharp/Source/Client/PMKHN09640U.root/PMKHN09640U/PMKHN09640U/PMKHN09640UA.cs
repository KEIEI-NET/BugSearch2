//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
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
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜���s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/04/26</br>
    /// </remarks>
    public partial class PMKHN09640UA : Form
    {

        #region Constroctors
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2011/04/26</br>
        /// </remarks>
        public PMKHN09640UA()
        {
            InitializeComponent();
        }
        #endregion


        #region Private Members
        private PMKHN09641UA _dispatchInputForm;

        #endregion


        #region Event
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09640U_Load(object sender, EventArgs e)
        {
            this._dispatchInputForm = new PMKHN09641UA();

            this._dispatchInputForm.TopLevel = false;
            this._dispatchInputForm.FormBorderStyle = FormBorderStyle.None;
            this._dispatchInputForm.Show();
            this._dispatchInputForm.Dock = DockStyle.Fill;

            this.Text = this._dispatchInputForm.Text;
           
            this.Controls.Add(this._dispatchInputForm);
            this._dispatchInputForm.FormClosed += new FormClosedEventHandler(this.dispatchInpu_FormClosed);
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�t�H�[������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void dispatchInpu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜���C���t���[����ʂ�\�����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09640UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }
    }
}