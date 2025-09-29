//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���Ӑ�d�q����
// �v���O�����T�v   : ���Ӑ�d�q���� �t���[��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���i �r��
// �� �� ��  2008/09/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J ���� 30182
// �C �� ��  2012/06/13  �C�����e : PM.NS �풓�ҋ@�����N���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470152-00  �쐬�S�� : 杍^
// �� �� ��  2018/09/04   �C�����e : ���������\���@�\�ǉ��Ή�
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
	public partial class PMKAU04000U : Form
	{
        public PMKAU04000U()
		{
			InitializeComponent();
            this.ShowInTaskbar = false;// -- Add 2012/06/13 30182 R.Tachiya --
        }

        private PMKAU04001UA _customerElecNoteMainForm;

        // --- Add 2011/08/06 duzg for �ԓ`���s���A�f�[�^���M�Ή� --->>>
        /// <summary>�R�}���h���C������</summary>
        private string[] _commandLineArgs;

        /// <summary>�R�}���h���C������</summary>
        public string[] CommandLineArgs
        {
            set { _commandLineArgs = value; }
            get { return this._commandLineArgs; }
        }
        // --- Add 2011/08/06 duzg for �ԓ`���s���A�f�[�^���M�Ή� --->>>

        //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�------->>>>>
        /// <summary>�R�}���h���C������</summary>
        private string[] _salesCommandArgs;

        /// <summary>�R�}���h���C������</summary>
        public string[] SalesCommandArgs
        {
            set { _salesCommandArgs = value; }
            get { return this._salesCommandArgs; }
        }
        //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�-------<<<<<

        /// <summary>Form.Load �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Update Note: 2018/09/04 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11470152-00</br>
        /// <br>           : ���������\���@�\�ǉ��Ή�</br>
        /// </remarks>
        private void PMKAU04000U_Load(object sender, EventArgs e)
		{
            this.Hide();// -- Add 2012/06/13 30182 R.Tachiya --
            this._customerElecNoteMainForm = new PMKAU04001UA();
            this._customerElecNoteMainForm.CommandLineArgs = CommandLineArgs;// 2011.08.06 duzg for �ԓ`���s���A�f�[�^���M�Ή�
            this._customerElecNoteMainForm.SalesCommandArgs = SalesCommandArgs;// ADD�@2018/09/04 杍^�@���������\���̑Ή�
            this._customerElecNoteMainForm.TopLevel = false;
            this._customerElecNoteMainForm.FormBorderStyle = FormBorderStyle.None;
            this._customerElecNoteMainForm.Show();
            this.Controls.Add(this._customerElecNoteMainForm);
            this._customerElecNoteMainForm.Dock = DockStyle.Fill;

            this._customerElecNoteMainForm.FormClosed += new FormClosedEventHandler(this.CustomerElecNoteMainForm_FormClosed);
            // -- Add St 2012/06/13 30182 R.Tachiya --
            int id = System.Diagnostics.Process.GetCurrentProcess().Id;
            ApplicationWaiter applicationWaiter = new ApplicationWaiter();
            applicationWaiter.SleepUpToFormReView(id);//�풓�ҋ@
            this.ShowInTaskbar = true;
            this.Show();
            applicationWaiter.ReViewForm(id);//�ĕ\�������I��
            // -- Add Ed 2012/06/13 30182 R.Tachiya --
        }

        /// <summary>
        /// �q�t�H�[���N���[�Y��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2018/09/04 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11470152-00</br>
        /// <br>           : ���������\���@�\�ǉ��Ή�</br>
        /// </remarks>
        private void PMKAU04000U_Shown( object sender, EventArgs e )
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
            //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�------->>>>>
            if (this._customerElecNoteMainForm.SalesCommandArgs != null && this._customerElecNoteMainForm.SalesCommandArgs.Length == 2)
            {
                this._customerElecNoteMainForm.ShowCustPrtSlip();
            }
            //----- ADD�@2018/09/04 杍^�@���������\���̑Ή�-------<<<<<
        }

        private void PMKAU04000U_FormClosing(object sender, FormClosingEventArgs e)
        {
            //-----ADD 2010/12/20----->>>>>
            System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory;
            //-----ADD 2010/12/20-----<<<<<
        }
	}
}