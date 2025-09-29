//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����̉��
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���F
// �� �� ��  2006/10/10  �C�����e : �V�K�쐬�F�s�r�o����M�����y�o�l���z(SFMIT02850U)
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/29  �C�����e : SCM�p�ɃA�����W
// �Ǘ��ԍ�              �쐬�S�� : ZHANGYH
// �� �� ��  2011/07/12  �C�����e : 1�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhouzy
// �� �� ��  2011/09/06  �C�����e : Websync PCCUOE�̃`�����l����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2015/06/30  �A�C�����e : SCM�d�|�ꗗ��10707 ���O�o�͂̒ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData; // 2011.09.06 zhouzy ADD

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���M��ʃt�H�[��
    /// </summary>
	public partial class PMSCM01101UC : Form
    {
        #region API��`
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        static extern uint SendMessage(IntPtr window, int msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        public const Int32 WM_COPYDATA = 0x4A;
        public const Int32 WM_USER = 0x400;

        //COPYDATASTRUCT�\���� 
        struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public UInt32 cbData;
            public string lpData;
        }
        #endregion 

        #region <�񓚑��M����>

        /// <summary>�񓚑��M����</summary>
        private readonly SCMSendController _scmController;
        /// <summary>�񓚑��M�������擾���܂��B</summary>
        private SCMSendController SCMController { get { return _scmController; } }

        #endregion // </�񓚑��M����>

        #region <Constructor>
        /// <summary>�f�t�H���gx���W</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>�f�t�H���gy���W</summary>
        private const int DEFAULT_Y = 100000;

        /// <summary>
		/// �J�X�^���R���X�g���N�^
		/// </summary>
        /// <param name="scmController">�񓚑��M����</param>
        /// <param name="position">�ʒu</param>
        public PMSCM01101UC(
            SCMSendController scmController,
            FormStartPosition position
        )
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // <Designer Code>

            _scmController = scmController;
            //this.StartPosition = position;
            this.Hide();
        }

        #endregion // </Constructor>

        #region <������>

        /// <summary>
        /// ���M��ʃt�H�[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
		private void PMSCM01101UC_Load(object sender, EventArgs e)
		{
            SimpleLogger.WriteDebugLog("PMSCM01101UC", "PMSCM01101UC_Load", "�t�H�[��Load�C�x���g"); // ADD 2015/06/30�A T.Miyamoto SCM�d�|�ꗗ��10707
            // �����ʒu��ݒ�i������h�~�ׁ̈A10000�ɂ��Ă��܂��j
            SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);
            this.SetVisibleState(false);
            this.sendTimer.Enabled = true;
        }

        #endregion // </������>

        /// <summary>
        /// ���M�^�C�}�[��Tick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 2010/02/13 >>>
                this.SetVisibleState(false);
                this.Refresh();
                // 2010/02/13 <<<
                this.sendTimer.Enabled = false;
                //this.Refresh();

                // ���M
                CanClose = false;
                // 2011.07.12 ZHANGYH ADD STA >>>>>>
                List<string> sendEnterpriseCodeList;
                List<string> sendSectionCodeList;
                // 2011.09.06 zhouzy UPDATE STA >>>>>>
                List<SCMAcOdrDataWork> scmAcOdrDataList;
                // 2011.09.06 zhouzy UPDATE END <<<<<<
                // 2011.07.12 ZHANGYH ADD END <<<<<<

                // 2011.07.12 ZHANGYH EDT STA >>>>>>
                //int status = SCMController.Send();
                // 2011.09.06 zhouzy UPDATE STA >>>>>>
                //int status = SCMController.Send(out sendEnterpriseCodeList, out sendSectionCodeList);
                int status = SCMController.Send(out sendEnterpriseCodeList, out sendSectionCodeList, out scmAcOdrDataList);
                // 2011.09.06 zhouzy UPDATE END <<<<<<
                // 2011.07.12 ZHANGYH EDT END <<<<<<
                if (status.Equals((int)ResultUtil.ResultCode.Error))
                {
                    SetErrorStatus();
                    return;
                }

                // 2011.07.12 ZHANGYH ADD STA >>>>>>
                // �񓚐�������ƁASF.NS�[����ʒm���܂��B
                // 2011.09.06 zhouzy UPDATE STA >>>>>>
                //if (sendEnterpriseCodeList != null && sendSectionCodeList != null && sendEnterpriseCodeList.Count > 0 && sendSectionCodeList.Count > 0)
                //{
                //    SCMChecker.NotifyOtherSide(sendEnterpriseCodeList, sendSectionCodeList);
                //}
                if (sendEnterpriseCodeList != null && sendSectionCodeList != null && sendEnterpriseCodeList.Count > 0 && sendSectionCodeList.Count > 0
                    && scmAcOdrDataList != null && scmAcOdrDataList.Count > 0)
                {
                    SCMAcOdrDataWork sCMAcOdrDataWork = scmAcOdrDataList[0];
                    SCMChecker.NotifyOtherSide(sendEnterpriseCodeList, sendSectionCodeList, sCMAcOdrDataWork.AcceptOrOrderKind);
                }
                // 2011.09.06 zhouzy UPDATE END <<<<<<
                // 2011.07.12 ZHANGYH ADD END <<<<<<

                CanClose = true;
                SCMController.SettingInfo.LastDate = DateTime.Now;
                //this.Refresh();
            }
            finally
            {
                SendRecevingClose();
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// �G���[��Ԃ�ݒ肵�܂��B
        /// </summary>
        private void SetErrorStatus()
        {
            this.pictureWait.Visible = false;
            this.lblStatus.Text = "���M���ɃG���[���������܂����B";
            this.lblPlease.Text = "�ڍׂ̓G���[���O���Q�Ƃ��Ă��������B";
            this.btnCancel.Visible = true;
        }

        // 2010/02/13 Add >>>
        /// <summary>
        /// �����N���ʒu��ݒ肵�܂��B
        /// </summary>
        private void SetInitialPosition()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;
            int appWidth = Width;
            int appHeight = Height;
            int appLeftXPos = screenWidth - appWidth;
            int appLeftYPos = screenheigth - appHeight;

            SetDesktopBounds(appLeftXPos, appLeftYPos, appWidth, appHeight);
        }

        /// <summary>
        /// �\����Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="visible">�\���t���O</param>
        private void SetVisibleState(bool visible)
        {
            if (visible)
            {
                SetInitialPosition();
                Visible = true;
                TopMost = true;
                Activate();
                TopMost = false;
            }
            else
            {
                this.ShowIcon = false;
                Visible = false;
            }
        }
        // 2010/02/13 Add <<<


        /// <summary>
        /// ���M���A�C�R����MouseDoubleClick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void nowSendingNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            #region <Guard Phrase>

            if (!e.Button.Equals(MouseButtons.Left)) return;

            #endregion // </Guard Phrase>

            this.Visible = true;
        }

        private void SendRecevingClose()
        {
            Process[] pr = Process.GetProcessesByName("PMSCM01104U");
            foreach (Process process in pr)
            {
                COPYDATASTRUCT st = new COPYDATASTRUCT();

                string msg = "Close";
                st.dwData = (IntPtr)0;
                st.cbData = (uint)( msg.Length + 1 );
                st.lpData = msg;

                SendMessage(process.MainWindowHandle, WM_COPYDATA, this.Handle, ref st);
            }
        }

        #region <�I������>

        #region <�N���[�Y�\�t���O>

        /// <summary>�N���[�Y�\�t���O</summary>
        private bool _canClose;
        /// <summary>�N���[�Y�\�t���O���擾�܂��͐ݒ肵�܂��B</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion // </�N���[�Y�\�t���O>

        /// <summary>
        /// [����]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
            CanClose = true;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// ���M��ʃt�H�[����FormClosing�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMSCM01101UC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // �Ӑ}�I�ȏI���ȊO�̓L�����Z�����ăA�C�R�����i�t�H�[�����\���ɂ���j
                    e.Cancel = true; // �I�������̃L�����Z��
                    this.Visible = false;
                    return;
                }
            }
        }

        #endregion // </�I������>
    }
}