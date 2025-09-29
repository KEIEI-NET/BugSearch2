//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10701342-00 �쐬�S�� : ������
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/07  �C�����e : Redmine#22810 ���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^ UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^UI�t�H�[���N���X</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 ���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�</br>
    /// </remarks>
    public partial class PMKHN09620UA : Form
    {
        /// <summary>
        ///�L�����y�[���Ώۏ��i�ݒ�}�X�^���C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���Ώۏ��i�ݒ�}�X�^���C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public PMKHN09620UA()
        {
            InitializeComponent();
        }

        private PMKHN09621UA _pmkhn09621UA;

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09620UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09621UA = new PMKHN09621UA();
            this._pmkhn09621UA.TopLevel = false;
            this._pmkhn09621UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09621UA.Show();
            this.Controls.Add(this._pmkhn09621UA);
            this._pmkhn09621UA.Dock = DockStyle.Fill;

            this._pmkhn09621UA.FormClosed += new FormClosedEventHandler(this.PMKHN09621UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���Ώۏ��i�ݒ�}�X�^���C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 ���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�</br>
        /// </remarks>
        private void PMKHN09621UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._pmkhn09621UA.BeforeFormClose();  // ADD 2011/07/07 
            this.Close();
        }

        // ----- ADD 2011/07/07 ------- >>>>>>>>>
        /// <summary>
        /// �E�B���h�E���b�Z�[�W���䏈��
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                // FormClose�O�̏���
                this._pmkhn09621UA.BeforeFormClose();
            }
            base.WndProc(ref m);
        }
        // ----- ADD 2011/07/07 ------- <<<<<<<<<

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���Ώۏ��i�ݒ�}�X�^���C���t���[����ʂ�\�����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09620UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
            this._pmkhn09621UA.SetInitFocus();
        }
    }
}