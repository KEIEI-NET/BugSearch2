//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�̕ێ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/01/20  �C�����e : �V�K�쐬
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
    /// ���R�����h���i�֘A�ݒ�}�X�^ UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^UI�t�H�[���N���X</br>
    /// <br>Programmer : �{�{����</br>
    /// <br>Date       : 2015/01/20</br>
    /// </remarks>
    public partial class PMREC09010UA : Form
    {
        /// <summary>
        ///���R�����h���i�֘A�ݒ�}�X�^���C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���R�����h���i�֘A�ݒ�}�X�^���C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public PMREC09010UA()
        {
            InitializeComponent();
        }

        private PMREC09011UA _pmrec09011UA;

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09010UA_Load(object sender, EventArgs e)
        {
            this._pmrec09011UA = new PMREC09011UA();
            this._pmrec09011UA.TopLevel = false;
            this._pmrec09011UA.FormBorderStyle = FormBorderStyle.None;
            this._pmrec09011UA.Show();
            this.Controls.Add(this._pmrec09011UA);
            this._pmrec09011UA.Dock = DockStyle.Fill;

            this._pmrec09011UA.FormClosed += new FormClosedEventHandler(this.PMREC09011UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���R�����h���i�֘A�ݒ�}�X�^���C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09011UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._pmrec09011UA.BeforeFormClose();
            this.Close();
        }

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
                this._pmrec09011UA.BeforeFormClose();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���R�����h���i�֘A�ݒ�}�X�^���C���t���[����ʂ�\�����܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09010UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
            this._pmrec09011UA.SetInitFocus();
        }
    }
}