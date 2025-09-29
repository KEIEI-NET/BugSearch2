//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ������ԕ\���v���O����
// �v���O�����T�v   : ������ԕ\���v���O�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070136-00 �쐬�S�� : chenyk
// �� �� ��  2014/08/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/09/03   �C�����e : Redmine#43408
//                                   �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/09/12   �C�����e : Redmine#43532
//                                   �N���C�A���g���O�̏o�́A�A�C�R���̎w�E��Ή�����
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using System.IO;
using System.Xml;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �G���[�\���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �G���[�\���̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : chenyk</br>
    /// <br>Date       : 2014/08/14</br>
    /// <br>Update Note: 2014/09/03 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43408</br>
    /// <br>           : �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�</br>
    /// <br>Update Note: 2014/09/12 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43532</br>
    /// <br>           : �N���C�A���g���O�̏o�́A�A�C�R���̎w�E��Ή�����</br>
    /// </remarks>
    public partial class PMSCM04110UB : Form
    {
        #region Private Members
        private const int DEFAULT_X = 100000;//�f�t�H���gx���W
        private const int DEFAULT_Y = 100000;//�f�t�H���gy���W
        private int _requireTime; //�v���o�ߎ���
        private int _showTime; //�|�b�v�A�b�v�̕\������
        private int _monitorTime; //�Ď��Ԋu����
        private int _retryCount; //�Ď��s��
        private const double CT_FORM_OPACITY = 1; //��ʓ��ߗ�
        private const string XMLFILE = "PMSCM04110U_RunFile.XML";
        private const string E0001 = "E0001";
        private const string E0002 = "E0002";
        private const string E0003 = "E0003";
        private const string E0004 = "E0004";
        private PMSCM04110UA _form;
        bool _res = false;

        private SynchConfirmAcs _synchConfirmAcs; // �����󋵊m�F�A�N�Z�X�N���X
        private string _errorMessageId; //�G���[���b�Z�[�W
        private bool _isErrorRead;
        private PosTerminalMgAcs _posTerminalMgAcs; // �[���Ǘ��ݒ�A�N�Z�X�N���X
        private SyncStateDspTermStAcs _syncStateDspTermStAcs; // ������ԕ\���[���ݒ�A�N�Z�X�N���X
        #endregion

        #region �R�}���h���C������
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        //private string _sectionCode; //DEL 2014/09/01 �c���� Redmine#43391
        #endregion

        #region �t�H�[������锻��
        /// <summary>�t�H�[������锻��t���O</summary>
        private bool _canClose;
        /// <summary>�t�H�[������锻��t���O�̃A�N�Z�T</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }
        #endregion

        # region Constructors
        public PMSCM04110UB()
        {
            InitializeComponent();
            _errorMessageId = "";
            _isErrorRead = false;
            _posTerminalMgAcs = new PosTerminalMgAcs();
            _synchConfirmAcs = new SynchConfirmAcs();
            _syncStateDspTermStAcs = new SyncStateDspTermStAcs();
            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; // ��ƃR�[�h
            }
            //this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode; // ���_�R�[�h //DEL 2014/09/01 �c���� Redmine#43391
        }
        #endregion

        #region �C�x���g
        /// <summary>
        /// ���Load
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Load</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// <br>Update Note: 2014/09/12 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43532</br>
        /// <br>           : �N���C�A���g���O�̏o�́A�A�C�R���̎w�E��Ή�����</br>
        /// </remarks>
        private void PMSCM04110UB_Load(object sender, EventArgs e)
        {
            //�|�b�v�A�b�v�̑��d�N���h�~
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                CanClose = true;
                this.Close();
                return;
            }

            //----- ADD 2014/09/12 �c���� Redmine#43532 ----->>>>>
            try
            {
                //----- ADD 2014/09/12 �c���� Redmine#43532 -----<<<<<
                //�[���`�F�b�N
                ArrayList localList = new ArrayList();
                ArrayList serverList = new ArrayList();
                ArrayList localMachineList = new ArrayList();
                ArrayList serverMachineList = new ArrayList();
                ArrayList syncStateDspTermList = new ArrayList();
                int status1 = this._posTerminalMgAcs.SearchLocal(out localList, this._enterpriseCode);
                int status2 = this._posTerminalMgAcs.SearchServer(out serverList, this._enterpriseCode);
                int status3 = this._syncStateDspTermStAcs.SearchAll(out syncStateDspTermList, this._enterpriseCode);

                if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL || status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL || status3 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CanClose = true;
                    this.Close();
                    return;
                }
                else
                {
                    #region �T�[�o�[�ɓo�^�ς݂̃��[�J���̒[��ID���擾
                    foreach (PosTerminalMg work in localList)
                    {
                        if (work.LogicalDeleteCode == 0)
                        {
                            string machineName = work.MachineName;
                            localMachineList.Add(machineName);
                        }
                    }
                    foreach (PosTerminalMg work in serverList)
                    {
                        if (work.LogicalDeleteCode == 0)
                        {
                            for (int i = 0; i < localMachineList.Count; i++)
                            {
                                if (work.MachineName.Equals(localMachineList[i]))
                                {
                                    serverMachineList.Add(work.CashRegisterNo);
                                }
                            }
                        }
                    }
                    #endregion
                }
                bool flag = false;
                string belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                foreach (SyncStateDspTermStWork work in syncStateDspTermList)
                {
                    if (work.LogicalDeleteCode == 0)
                    {
                        for (int i = 0; i < serverMachineList.Count; i++)
                        {
                            #region ���_����`�F�b�N
                            if (!string.IsNullOrEmpty(work.SectionCode) && (work.SectionCode.Trim() == "00" || work.SectionCode.Trim() == belongSectionCode))
                            {
                                #region �N���[���`�F�b�N
                                if (work.CashRegisterNo.ToString().Equals(serverMachineList[i].ToString()))
                                {
                                    flag = true;
                                    break;
                                }
                                #endregion
                            }
                            #endregion
                        }
                    }
                }
                if (!flag)
                {
                    CanClose = true;
                    this.Close();
                    return;
                }


                //�N���t�@�C����ǂ�
                int status4 = GetXML();
                if (status4 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CanClose = true;
                    this.Close();
                    return;
                }
                this.notifyIcon.Visible = true;

                // �����\���͉B��
                SetVisibleState(false);

                // �����ʒu��ݒ�i������h�~�ׁ̈A10000�ɂ��Ă��܂��j
                SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

                if (_showTime > 0)
                {
                    this.show_timer.Interval = _showTime;
                }

                //�����`�F�b�N
                SerachErr();

                if (!string.IsNullOrEmpty(this._errorMessageId) && !_isErrorRead)
                {
                    if (_showTime > 0)
                    {
                        this.show_timer.Enabled = true;
                    }
                    MessageSetting();
                }
                //�����`�F�b�N��ݒ�
                if (_monitorTime > 0)
                {
                    check_timer.Enabled = true;
                    check_timer.Interval = _monitorTime;
                }
            }
            catch (Exception ex)
            {
                PMSCM04110UA.WriteErrorLog(ex, "PMSCM04110UB.PMSCM04110UB_Load", -1);

                CanClose = true;
                this.Close();
                return;
            }
        }

        /// <summary>
        /// ����`�F�b�N���s�^�C�}�[����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ����`�F�b�N���s�^�C�}�[����</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void Check_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                check_timer.Enabled = false;
                SerachErr();
                if (!string.IsNullOrEmpty(this._errorMessageId) && !this._isErrorRead)
                {
                    if (_showTime > 0)
                    {
                        this.show_timer.Enabled = true;
                    }
                    MessageSetting();
                }
            }
            catch
            {
            }
            finally
            {
                check_timer.Enabled = true;
            }
        }

        /// <summary>
        /// ��ʌv������
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʌv������</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void show_timer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this._errorMessageId) && _showTime > 0)
            {
                this.show_timer.Enabled = false;
            }
            this.PMSCM04110UB_MouseLeave(sender, e);
        }

        /// <summary>
        /// �t�H�[����FormClosing�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[����FormClosing�C�x���g�n���h��</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void PMSCM04110UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // �Ӑ}�I�ȏI���ȊO�̓L�����Z�����ăA�C�R�����i�t�H�[�����\���ɂ���j
                    e.Cancel = true; // �I�������̃L�����Z��
                    Visible = false;
                    return;
                }
            }
        }

        /// <summary>
        /// ��ʂ���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ���܂��B</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "������ԕ\���v���O�������I�����܂��B\r\n" +
                "�I�����Ă���낵���ł����H",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.No) return;

            CanClose = true;
            Close();
        }

        /// <summary>
        /// �t�H�[����MouseLeave�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[����MouseLeave�C�x���g�n���h��</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void PMSCM04110UB_MouseLeave(object sender, EventArgs e)
        {
            if (!CanClose)
            {
                this._isErrorRead = true;
                Visible = false;
                return;
            }

        }

        /// <summary>
        /// �o�^���[��close�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�^���[��close�C�x���g�n���h��</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void close_button_Click(object sender, EventArgs e)
        {
            this.show_timer.Enabled = false; // ADD 2014/09/03 �c����
            if (!CanClose)
            {
                this._isErrorRead = true;
                Visible = false;
                return;
            }
        }

        /// <summary>
        /// �o�^���[��MouseMove�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�^���[��close�C�x���g�n���h��</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void close_button_MouseMove(object sender, MouseEventArgs e)
        {
            this.close_button.Appearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.close_button.Appearance.BackColor = System.Drawing.Color.LightGray;
        }

        /// <summary>
        /// �o�^���[��MouseLeave�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�^���[��MouseLeave�C�x���g�n���h��</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void close_button_MouseLeave(object sender, EventArgs e)
        {
            this.close_button.Appearance.BorderColor = System.Drawing.Color.White;
            this.close_button.Appearance.BackColor = System.Drawing.Color.Transparent;
        }

        /// <summary>
        /// �p�g�����v�A�C�R����MouseClick�C�x���g�n���h��
        /// </summary>
        /// <remarks>��ʂ�\�����܂��B</remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �p�g�����v�A�C�R����MouseClick�C�x���g�n���h��</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (!e.Button.Equals(MouseButtons.Left) || _res) return;
            Activate();

            if (_form == null)
            {
                _form = new PMSCM04110UA();
                _form.FormClosed += new FormClosedEventHandler(ChildForm_FormClosed);
                _form.RetetEvent += new EventHandler(ClearErrorMessage);
                _form.Show(this);
            }
            else
            {
                if (_form.WindowState == FormWindowState.Minimized)
                {
                    _form.WindowState = FormWindowState.Normal;
                }

                _res = true;
                string msg = "�����󋵊m�F�͊��ɋN�����Ă��܂��B";
                DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text, msg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.OK)
                {
                    _res = false;
                }
            }

            /*----- DEL 2014/09/03 �c���� ---------->>>>>
            if (_form == null)
            {
                _form = new PMSCM04110UA();
                //_form.ShowDialog(this); // DEL 2014/09/03 �c����
                //----- ADD 2014/09/03 �c���� ---------->>>>>
                if (_form.ShowDialog(this) == DialogResult.Cancel)
                {
                    _form.Dispose();
                    _form = null;
                }
                //----- ADD 2014/09/03 �c���� ----------<<<<<
            }
            else
            {
                if (!_form.Visible)
                {
                    //_form.ShowDialog(this); // DEL 2014/09/03 �c����
                    //----- ADD 2014/09/03 �c���� ---------->>>>>
                    if (_form.ShowDialog(this) == DialogResult.Cancel)
                    {
                        _form.Dispose();
                        _form = null;
                    }
                    //----- ADD 2014/09/03 �c���� ----------<<<<<
                }
                else
                {
                    if (_form.WindowState == FormWindowState.Minimized)
                    {
                        _form.WindowState = FormWindowState.Normal;
                    }

                    _res = true;
                    string msg = "�����󋵊m�F�͊��ɋN�����Ă��܂��B";
                    DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text, msg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    if (res == DialogResult.OK)
                    {
                        _res = false;
                    }
                }
            }
            ----- DEL 2014/09/03 �c���� ----------<<<<<*/
        }

        //----- ADD 2014/09/03 �c���� ---------->>>>>
        /// <summary>
        /// �q�t�H�[���̃N���[�Y�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �q�t�H�[�����N���[�Y������̏����B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/09/03</br>
        /// </remarks>
        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Dispose();
            _form = null;
        }
        #endregion
        //----- ADD 2014/09/03 �c���� ----------<<<<<

        #region private�@���\�b�h
        /// <summary>
        /// �\����Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="visible">�\���t���O</param>
        /// <remarks>
        /// <br>Note       : �\����Ԃ�ݒ肵�܂��B</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void SetVisibleState(bool visible)
        {
            if (visible)
            {
                SetInitialPosition();
                SetWindowPos();
                Visible = true;
            }
            else
            {
                Visible = false;
            }
        }

        /// <summary>
        /// ShowWithoutActivation
        /// </summary>
        /// <remarks>
        /// <br>Note       : ShowWithoutActivation</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private void SetWindowPos()
        {
            const int HWND_TOPMOST = -1;
            const int SWP_NOSIZE = 0x0001;
            const int SWP_NOMOVE = 0x0002;
            const int SWP_NOACTIVATE = 0x0010;
            const int SWP_DRAWFRAME = 0x0020;
            const int SWP_SHOWWINDOW = 0x0040;
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_DRAWFRAME);
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_DRAWFRAME);
        }

        /// <summary>
        /// �����N���ʒu��ݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����N���ʒu��ݒ肵�܂��B</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
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
        /// �G���[���O����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �G���[���O����</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// <br>Update Note: 2014/09/03 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43408</br>
        /// <br>           : �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�</br>
        /// <br>Update Note: 2014/09/12 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43532</br>
        /// <br>           : �N���C�A���g���O�̏o�́A�A�C�R���̎w�E��Ή�����</br>
        /// </remarks>
        private int SerachErr()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string errMessage = string.Empty;
            string err = string.Empty;
            ArrayList retList = new ArrayList();
            DateTime nowDateTime = DateTime.Now;
            DateTime dt = nowDateTime.AddSeconds((double)_requireTime * -1);
            string newErrorMessageId = string.Empty;
            try
            {
                //DO CHECK
                status = _synchConfirmAcs.SerachErr(this._enterpriseCode, _retryCount, dt, ref retList, out err);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList.Count > 0)
                {
                    SyncReqDataWork work = retList[0] as SyncReqDataWork;
                    if (work != null && work.SyncExecRslt == 2 && work.RetryCount >= _retryCount)
                    {
                        //E0001
                        if (work.ErrorStatus == 1010 || work.ErrorStatus == 1020 || work.ErrorStatus == 1030 || work.ErrorStatus == 1040)
                        {
                            newErrorMessageId = E0001;
                        }
                        //E0002
                        else if (work.ErrorStatus == 2000)
                        {
                            newErrorMessageId = E0002;
                        }
                        //E0004
                        else
                        {
                            newErrorMessageId = E0004;
                        }
                    }
                    else if (work != null)
                    {
                        //E0003
                        newErrorMessageId = E0003;
                    }

                    if (this._errorMessageId != newErrorMessageId)
                    {
                        this._errorMessageId = newErrorMessageId;
                        this._isErrorRead = false;
                    }
                }
                else
                {
                    this.ClearErrorMessage(this, null);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMessage = ex.Message;
                PMSCM04110UA.WriteErrorLog(ex, "PMSCM04110UB.SerachErr", status); // ADD 2014/09/12 �c���� Redmine#43532
            }
            finally
            {
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (string.IsNullOrEmpty(errMessage))
                    {
                        errMessage = err;
                    }

                    PMSCM04110UA.WriteErrorLog(null, errMessage, status); // ADD 2014/09/12 �c���� Redmine#43532
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text, errMessage, 0, MessageBoxButtons.OK);
                }
            }
            return status;
        }

        /// <summary>
        /// �G���[���̃N���A
        /// </summary>
        public void ClearErrorMessage(object sender, System.EventArgs e)
        {
            this._errorMessageId = string.Empty;
            this._isErrorRead = false;
        }

        /// <summary>
        /// ���b�Z�[�W��ݒ肵�܂��B
        /// </summary>
        /// <param name="count">�v���t���O</param>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W��ݒ肵�܂��B</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void MessageSetting()
        {
            if (this._errorMessageId.Equals(E0001))
            {
                E0001_Label.Visible = true;
                E0002_Label.Visible = false;
                E0003_Label.Visible = false;
                E0004_Label.Visible = false;
                SetVisibleState(true);
            }
            if (this._errorMessageId.Equals(E0002))
            {
                E0001_Label.Visible = false;
                E0002_Label.Visible = true;
                E0003_Label.Visible = false;
                E0004_Label.Visible = false;
                SetVisibleState(true);
            }
            if (this._errorMessageId.Equals(E0003))
            {
                E0001_Label.Visible = false;
                E0002_Label.Visible = false;
                E0003_Label.Visible = true;
                E0004_Label.Visible = false;
                SetVisibleState(true);
            }
            if (this._errorMessageId.Equals(E0004))
            {
                E0001_Label.Visible = false;
                E0002_Label.Visible = false;
                E0003_Label.Visible = false;
                E0004_Label.Visible = true;
                SetVisibleState(true);
            }
        }

        /// <summary>
        /// �N���t�@�C�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���t�@�C�����擾���܂��B</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// <br>Update Note: 2014/09/12 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43532</br>
        /// <br>           : �N���C�A���g���O�̏o�́A�A�C�R���̎w�E��Ή�����</br>
        /// </remarks>
        private int GetXML()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string errMessage = string.Empty;
            try
            {
                string path = ConstantManagement_ClientDirectory.UISettings + "\\" + XMLFILE;
                if (File.Exists(path))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(path);
                    XmlNode root = xmlDoc.SelectSingleNode("//ExtractConditionItem");
                    if (root != null)
                    {
                        _requireTime = Convert.ToInt32((root.SelectSingleNode("RequireTime")).InnerText);
                        _showTime = Convert.ToInt32((root.SelectSingleNode("ShowTime")).InnerText) * 1000;
                        _monitorTime = Convert.ToInt32((root.SelectSingleNode("MonitorTime")).InnerText) * 1000;
                        _retryCount = Convert.ToInt32((root.SelectSingleNode("RetryCount")).InnerText);
                    }
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMessage = ex.Message;
                PMSCM04110UA.WriteErrorLog(ex, "PMSCM04110UB.GetXML", status); // ADD 2014/09/12 �c���� Redmine#43532
            }
            finally
            {
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMessage))
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text,
                        errMessage, 0, MessageBoxButtons.OK);
                    }
                }
            }
            return status;
        }
        #endregion
    }
}