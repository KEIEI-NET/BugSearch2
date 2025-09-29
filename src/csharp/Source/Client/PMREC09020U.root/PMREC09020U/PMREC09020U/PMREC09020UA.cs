//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������i�ݒ�}�X�^
// �v���O�����T�v   : ���������i�ݒ�}�X�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
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
    /// ���������i�ݒ�}�X�^ UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������i�ݒ�}�X�^UI�t�H�[���N���X</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public partial class PMREC09020UA : Form
    {
        /// <summary>
        ///���������i�ݒ�}�X�^���C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���������i�ݒ�}�X�^���C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public PMREC09020UA()
        {
            InitializeComponent();
        }

        private PMREC09021UA _PMREC09021UA;

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09020UA_Load(object sender, EventArgs e)
        {
            this._PMREC09021UA = new PMREC09021UA();
            this._PMREC09021UA.TopLevel = false;
            this._PMREC09021UA.FormBorderStyle = FormBorderStyle.None;
            this._PMREC09021UA.Show();
            this.Controls.Add(this._PMREC09021UA);
            this._PMREC09021UA.Dock = DockStyle.Fill;

            this._PMREC09021UA.FormClosed += new FormClosedEventHandler(this.PMREC09021UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���������i�ݒ�}�X�^���C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09021UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._PMREC09021UA.BeforeFormClose();
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
                this._PMREC09021UA.BeforeFormClose();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���������i�ݒ�}�X�^���C���t���[����ʂ�\�����܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09020UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
            this._PMREC09021UA.SetInitFocus();
        }
    }
}