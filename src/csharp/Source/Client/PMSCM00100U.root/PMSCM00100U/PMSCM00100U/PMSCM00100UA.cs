//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ȒP�⍇��CTI�\�� �t���[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/06  �C�����e : IAAE�ł��琻�i�ł֕ύX(�s�v���W�b�N�폜)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/30  �C�����e : ActiveReport���i�őΉ�
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
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ȒP�⍇��CTI�\�� �t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : IAAE�ł��琻�i�ł֕ύX(�s�v���W�b�N�폜)</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/06</br>
    /// </remarks>
    public partial class PMSCM00100UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Member

        /// <summary>�R�}���h���C������</summary>
        private readonly string[] _commandLineArgs;
        /// <summary>�R�}���h���C���������擾���܂��B</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        /// <summary>���</summary>
        private PMSCM00101UA _ctiForm;

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �� Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="commandLineArgs">�R�}���h���C������</param>
		public PMSCM00100UA(string[] commandLineArgs)
		{
			InitializeComponent();

            _commandLineArgs = commandLineArgs;


            int customerCode = 0;
            foreach (string prm in _commandLineArgs)
            {
                if (prm.Contains("/Customer,"))
                {
                    string customerCodeStr = prm.Replace("/Customer,", "");
                    customerCode = TStrConv.StrToIntDef(customerCodeStr, 0);
                    break;
                }
            }
            this._ctiForm = ( customerCode > 0 ) ? new PMSCM00101UA(customerCode) : new PMSCM00101UA();
        }

        #endregion

        // ===================================================================================== //
        // �R���|�[�l���g�̃C�x���g
        // ===================================================================================== //
        #region �� Component Event
        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM00100UA_Load(object sender, EventArgs e)
		{
            this._ctiForm.CommandLineArgs = CommandLineArgs; 
            this._ctiForm.SettingVisible += new PMSCM00101UA.SettingVisibleEventHandler(this.SetVisibleState);
            this._ctiForm.TopLevel = false;
			this._ctiForm.FormBorderStyle = FormBorderStyle.None;
			this._ctiForm.Show();
			this.Controls.Add(this._ctiForm);
			this._ctiForm.Dock = DockStyle.Fill;

            // �N���[�Y�����̃C�x���g��ǉ�
			this._ctiForm.FormClosed += new FormClosedEventHandler(this.CTIForm_FormClosed);
        }

        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region �� Public Method

        /// <summary>
        /// �N���\���`�F�b�N
        /// </summary>
        /// <returns></returns>
        public bool CanStart()
        {
            return this._ctiForm.CanStart;
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        /// <summary>
        /// CTI�̎q��ʂ������Ƃ��ɔ�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CTIForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}

        /// <summary>
        /// �\����Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="visible">�\���t���O</param>
        private void SetVisibleState(bool visible)
        {
            if (visible)
            {
                Visible = true;
                ShowInTaskbar = true;
                TopMost = true;
                Activate();
                TopMost = false;
                SetInitialPosition();
            }
            else
            {
                Visible = false;
                ShowInTaskbar = false;
                this.Hide();
            }
        }

        /// <summary>
        /// �����N���ʒu��ݒ肵�܂��B
        /// </summary>
        private void SetInitialPosition()
        {
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                //this.SetVisibleState(false);
                this._ctiForm.SaveDetailSetting();
                //return;
            }
            base.WndProc(ref m);
        }

        #endregion
    }
}