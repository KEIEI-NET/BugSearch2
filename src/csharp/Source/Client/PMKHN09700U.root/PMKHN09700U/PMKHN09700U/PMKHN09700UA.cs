//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����񓚕i�ڐݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����񓚕i�ڐݒ�}�X�^�̑�����s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F���@30745
// �� �� ��  2012/10/25  �C�����e : �V�K�쐬
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
    /// �����񓚕i�ڐݒ胁�C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: UI�N���X��\�����܂��B</br>
    /// </remarks>
    public partial class PMKHN09700UA : Form
    {
        PMKHN09701UA _pmkhn09701UA;

        /// <summary>
        /// �|���}�X�^�ꊇ�C���E�o�^���C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// </remarks>
        public PMKHN09700UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void PMKHN09700UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09701UA = new PMKHN09701UA();
            this._pmkhn09701UA.TopLevel = false;
            this._pmkhn09701UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09701UA.Show();
            this.Controls.Add(this._pmkhn09701UA);
            this._pmkhn09701UA.Dock = DockStyle.Fill;

            this._pmkhn09701UA.FormClosed += new FormClosedEventHandler(PMKHN09701UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// </remarks>
        private void PMKHN09701UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H�[���������鎞�ɔ������܂��B</br>
        /// </remarks>
        private void PMKHN09700UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��ʏ���r
            bool bStatus = this._pmkhn09701UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML�ۑ�
            this._pmkhn09701UA.SaveStateXmlData();
        }
    }
}