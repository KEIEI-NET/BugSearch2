//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɉړ��d�q����
// �v���O�����T�v   : �݌Ɉړ��d�q���� �t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;

using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// �݌Ɉړ��d�q���� �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉړ��d�q���� �t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
	public partial class PMZAI04600U : Form
	{
        /// <summary>
        /// PMZAI04600U
        /// </summary>
        public PMZAI04600U()
		{
			InitializeComponent();
		}

        private PMZAI04601UA _customerElecNoteMainForm;

        /// <summary>
        /// ���[�h����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���[�h�����ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04600U_Load(object sender, EventArgs e)
		{
            this._customerElecNoteMainForm = new PMZAI04601UA();
            this._customerElecNoteMainForm.TopLevel = false;
            this._customerElecNoteMainForm.FormBorderStyle = FormBorderStyle.None;
            this._customerElecNoteMainForm.Show();
            this.Controls.Add(this._customerElecNoteMainForm);
            this._customerElecNoteMainForm.Dock = DockStyle.Fill;

            this._customerElecNoteMainForm.FormClosed += new FormClosedEventHandler(this.CustomerElecNoteMainForm_FormClosed);
		}

        /// <summary>
        /// �q�t�H�[���N���[�Y��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �q�t�H�[���N���[�Y��C�x���g�����ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void CustomerElecNoteMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // FormClose�O�̏���
            _customerElecNoteMainForm.BeforeFormClose();
            this.Close();
        }

        /// <summary>
        /// �E�B���h�E���b�Z�[�W���䏈��
        /// </summary>
        /// <param name="m"></param>
        /// <remarks>
        /// <br>Note       : �E�B���h�E���b�Z�[�W���䏈���ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        protected override void WndProc( ref Message m )
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if ( m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE )
            {
                // FormClose�O�̏���
                _customerElecNoteMainForm.BeforeFormClose();
            }
            base.WndProc( ref m );
        }
        /// <summary>
        /// �\���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �\���C�x���g�����ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04600U_Shown( object sender, EventArgs e )
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }

        private void PMZAI04600U_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory;
        }
	}
}