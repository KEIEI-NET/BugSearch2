//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^���p�o�^
// �v���O�����T�v   : �|���}�X�^���p�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/08  �C�����e : �V�K�쐬
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
    /// �|���}�X�^���p�o�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^���p�o�^���s���܂��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2008.03.27</br>
    /// </remarks>
    public partial class PMKHN09410UA : Form
    {

        #region Constroctors
        /// <summary>
        /// �|���}�X�^���p�o�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �|���}�X�^���p�o�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���m</br>
        /// <br>Date		: 2008.03.27</br>
        /// </remarks>
        public PMKHN09410UA()
        {
            InitializeComponent();
        }
        #endregion


        #region Private Members
        private PMKHN09411UA _dispatchInputForm;

        #endregion


        #region Event
        /// <summary>
        /// �|���}�X�^���p�o�^�t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2008.03.27</br>
        /// </remarks>
        private void PMKHN09410U_Load(object sender, EventArgs e)
        {
            this._dispatchInputForm = new PMKHN09411UA();

            this._dispatchInputForm.TopLevel = false;
            this._dispatchInputForm.FormBorderStyle = FormBorderStyle.None;
            this._dispatchInputForm.Show();
            this._dispatchInputForm.Dock = DockStyle.Fill;

            this.Text = this._dispatchInputForm.Text;
           
            this.Controls.Add(this._dispatchInputForm);
            this._dispatchInputForm.FormClosed += new FormClosedEventHandler(this.dispatchInpu_FormClosed);
        }

        /// <summary>
        /// �|���}�X�^���p�o�^�t�H�[������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2008.03.27</br>
        /// </remarks>
        private void dispatchInpu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}