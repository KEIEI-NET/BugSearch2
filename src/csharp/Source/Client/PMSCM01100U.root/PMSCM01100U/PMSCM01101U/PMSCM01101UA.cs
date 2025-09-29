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
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/03/30  �C�����e : ���M����ʂ̕\���������Ď���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21112 �v�ۓc ��
// �� �� ��  2011/06/01  �C�����e : ���O�\���{�^���̕\������ǉ�
//                                  ���O�\�����@�̕ύX(������ �� ���O�\�����)
//                                  �ݒ�{�^���̔�\��(�@�\�������̈�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�ˁ@�L��
// �� �� ��  2012/12/05  �C�����e : 2012/12/99�z�M SCM��Q��10442�Ή� ���M�{�^���\������A�P�̋N�������O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/08/28  �C�����e : �^�u���b�g����̔���o�^���A"���M��"�E�B���h�E���\���ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/04/09  �C�����e : SCM�d�|�ꗗ��10641�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/11/26  �C�����e : SCM�d�|�ꗗ��10707�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���M����(�`�[�\��)�t�H�[��
    /// </summary>
    public partial class PMSCM01101UA : Form
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
        // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ---------->>>>>>>>>>
        private string cmdLineTablet = string.Empty;
        // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ----------<<<<<<<<<<

        // ADD 2010/03/30 ���M����ʂ̕\���������Ď��� ---------->>>>>
        #region ���M�����

        /// <summary>
        /// ���M�����
        /// �i�\������ѕ���ۂ͂��ꂼ��<c>ShowingNowSendingForm()</c>�����<c>CloseNowSendingForm()</c>���g�p���ĉ������j
        /// </summary>
        private PMSCM01104UA _nowSendingForm;
        /// <summary>
        /// ���M����ʂ��擾���܂��B
        /// �i�\������ѕ���ۂ͂��ꂼ��<c>ShowingNowSendingForm()</c>�����<c>CloseNowSendingForm()</c>���g�p���ĉ������j
        /// </summary>
        private PMSCM01104UA NowSendingForm
        {
            get
            {
                if (_nowSendingForm == null)
                {
                    _nowSendingForm = new PMSCM01104UA();
                    _nowSendingForm.Title = "���M����";
                    _nowSendingForm.Message = "�f�[�^�𑗐M���Ă��܂�";
                }
                return _nowSendingForm;
            }
            set { _nowSendingForm = value; }
        }

        /// <summary>���M����ʕ\�����t���O</summary>
        private bool _showingNowSendingForm;
        /// <summary>���M����ʕ\�����t���O���擾�܂��͐ݒ肵�܂��B</summary>
        private bool ShowingNowSendingForm
        {
            get { return _showingNowSendingForm; }
            set { _showingNowSendingForm = value; }
        }

        /// <summary>
        /// ���M����ʂ�\�����܂��B
        /// </summary>
        private void ShowNowSendingForm()
        {
            if (ShowingNowSendingForm) return;

            ShowingNowSendingForm = true;
            // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ---------->>>>>>>>>>
            // �^�u���b�g�̏ꍇ��"���M���c"�̃E�C���h�E��\�����Ȃ�
            if (this.cmdLineTablet == SCMSendController.CMD_LINE_FOR_PMSCM01100_TABLET) return;
            // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ----------<<<<<<<<<<
            NowSendingForm.Show(this);
        }

        /// <summary>
        /// ���M����ʂ���܂��B
        /// </summary>
        private void CloseNowSendingForm()
        {
            ShowingNowSendingForm = false;

            if (NowSendingForm != null)
            {
                NowSendingForm.Close();
                NowSendingForm = null;
            }
        }

        #endregion // ���M�����
        // ADD 2010/03/30 ���M����ʂ̕\���������Ď��� ----------<<<<<

        #region <�񓚑��M����>

        /// <summary>�񓚑��M����</summary>
        private readonly SCMSendController _scmController;
        /// <summary>�񓚑��M�������擾���܂��B</summary>
        private SCMSendController SCMController { get { return _scmController; } }

        // --- ADD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private string mode = "(�P�̋N�����[�h)";
        // --- ADD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �o�b�`����(���M�N�����[�h)�ł��邩���f���܂��B
        /// </summary>
        /// <value>
        /// <c>true</c> :�o�b�`����(���M�N�����[�h)�ł��B<br/>
        /// <c>false</c>:�Θb����(�P�̋N�����[�h)�ł��B
        /// </value>
        public bool IsBatchMode
        {
            get { return SCMController.IsBatchMode; }
        }

        #endregion // </�񓚑��M����>

        #region <���M����(���ו\��)���>

        /// <summary>���M����(���ו\��)���</summary>
        private PMSCM01101UB _detailRecordForm;
        /// <summary>���M����(���ו\��)��ʂ��擾���܂��B</summary>
        private PMSCM01101UB DetailRecordForm
        {
            get
            {
                if (_detailRecordForm == null)
                {
                    _detailRecordForm = new PMSCM01101UB(SCMController);
                }
                return _detailRecordForm;
            }
        }

        #endregion // </���M����(���ו\��)���>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="scmController">�񓚑��M����</param>
        public PMSCM01101UA(SCMSendController scmController)
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _scmController = scmController;

            // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ---------->>>>>>>>>>
            this.cmdLineTablet = string.Empty;
            this.cmdLineTablet = scmController.CmdLineTablet;
            // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ----------<<<<<<<<<<

            // ADD 2010/03/30 ���M����ʂ̕\���������Ď��� ---------->>>>>
            if (_scmController.IsBatchMode)
            {
                ShowNowSendingForm();
            }
            // ADD 2010/03/30 ���M����ʂ̕\���������Ď��� ---------->>>>>
        }

        #endregion // </Constructor>

        #region <������>

        /// <summary>
        /// �񓚑��M�����t�H�[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMSCM01101UA_Load(object sender, EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\��
            // �c�[���{�^��
            this.myToolbar.ImageListSmall = IconResourceManagement.ImageList24;
            this.myToolbar.Tools["exit"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.CLOSE;
            this.myToolbar.Tools["send"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DEMANDPROP;
            this.myToolbar.Tools["detail"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.MODIFY;
            this.myToolbar.Tools["delete"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;
            this.myToolbar.Tools["log"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.AMBIGUOUSSEARCH;
            this.myToolbar.Tools["setting"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.SETUP1;
            // �c�[���{�^���𖳌��ɂ���
            this.myToolbar.Tools["exit"].SharedProps.Enabled = false;
            this.myToolbar.Tools["send"].SharedProps.Enabled = false;
            this.myToolbar.Tools["log"].SharedProps.Enabled = false;
            this.myToolbar.Tools["setting"].SharedProps.Enabled = false;
            this.myToolbar.Tools["detail"].SharedProps.Enabled = false;
            this.myToolbar.Tools["delete"].SharedProps.Enabled = false;
            this.myToolbar.Tools["filter"].SharedProps.Enabled = false;

            Infragistics.Win.UltraWinToolbars.ComboBoxTool combo = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.myToolbar.Tools.GetItem(this.myToolbar.Tools.IndexOf("filter"));
            combo.SelectedIndex = 0;

            // ���
            this.Stat0Cnt_label.Text = "0��";
            this.Stat1Cnt_label.Text = "0��";
            this.Stat2Cnt_label.Text = "0��";
            this.lblLastDate.Text = "--/--/-- --:--:--";

            this.myToolbar.Tools["log"].SharedProps.Visible = this.SCMController.SettingInfo.LogDisplay == 1;  //ADD 2011/06/01

            // --- ADD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // UPD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ------------------------------------------>>>>>
            //this.myToolbar.Tools["send"].SharedProps.Visible = this.SCMController.SendDisplay;
            if (this.SCMController.SendDisplay && this.SCMController.SettingInfo.AloneStartSend == 1)
            {
                this.myToolbar.Tools["send"].SharedProps.Visible = true;
            }
            else
            {
                this.myToolbar.Tools["send"].SharedProps.Visible = false;
            }
            // UPD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ------------------------------------------<<<<<
            // --- ADD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // �^�C�}�[ ON
            this.initializeTimer.Enabled = true;
        }

        /// <summary>
        /// �������^�C�}�[��Tick�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// �N���㏈��
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void initializeTimer_Tick(object sender, EventArgs e)
        {
            const string MY_NAME= "PMSCM01101UA";
            const string METHOD = "initializeTimer_Tick";

            // �^�C�}�[ OFF
            this.initializeTimer.Enabled = false;

            // FIXME:PM7�p���M�N�����[�h�̎d�l�ύX�c���b�Z�[�W�{�b�N�X�\���̖������ƒ��f����

            // ���M�f�[�^�t�H���_
            if (string.IsNullOrEmpty(SCMController.SettingInfo.SCMDataPath))
            {
                if (!SCMController.IsBatchMode)
                {
                    MessageBox.Show("���M�t�H���_���ݒ肳��Ă��܂���B\n���M�t�H���_�̐ݒ���s���Ă��������B");
                }
                else
                {
                    // UNDONE:���O�o�́H
                    this.Close();
                }
                // �c�[���{�^���𖳌��ɂ���
                this.myToolbar.Tools["exit"].SharedProps.Enabled = true;
                this.myToolbar.Tools["setting"].SharedProps.Enabled = true;
                return;
            }
            if (!Directory.Exists(SCMController.SettingInfo.SCMDataPath))
            {
                if (!SCMController.IsBatchMode)
                {
                    MessageBox.Show("���M�t�H���_�����݂��܂���B\n���M�t�H���_�̐ݒ���s���Ă��������B");
                }
                else
                {
                    // UNDONE:���O�o�́H
                    this.Close();
                }
                //SCMController.WriteLog("�������f\r\n");
                //SCMController.CloseLog();
                // �c�[���{�^���𖳌��ɂ���
                this.myToolbar.Tools["exit"].SharedProps.Enabled = true;
                this.myToolbar.Tools["setting"].SharedProps.Enabled = true;
                return;
            }

            // ���O���J�n
            // UPD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� --------------------------------------->>>>>
            //if (SCMController.OpenLog().Equals((int)ResultUtil.ResultCode.Error))
            if (SCMController.IsBatchMode && SCMController.OpenLog().Equals((int)ResultUtil.ResultCode.Error))
            // UPD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ---------------------------------------<<<<<
            {
                if (!SCMController.IsBatchMode)
                {
                    MessageBox.Show("���̒[���ő��M���̈דǍ��݂ł��܂���ł����B");
                }
                else
                {
                    // UNDONE:���O�o�́H
                    // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� --------------------------------------------------------------------->>>>>
                    // ���b�Z�[�W�\���E���O�o��
                    string msg = string.Empty;
                    string commentSlipNumber = string.Empty;
                    if (SCMController.SalesSlipNumList != null && SCMController.SalesSlipNumList.Count != 0)
                    {
                        for (int i = 0; i < SCMController.SalesSlipNumList.Count; i++)
                        {
                            if (i != 0) commentSlipNumber = commentSlipNumber + ",";
                            commentSlipNumber = commentSlipNumber + SCMController.SalesSlipNumList[i];
                        }
                        msg = "���̒[���ő��M���̈ב��M�ł��܂���ł����B" + Environment.NewLine +
                                        "����`�[�ԍ��y" + commentSlipNumber + "�z";
                        MessageBox.Show(msg, "�񓚑��M����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        SimpleLogger.WriteSlipNumLog(SCMController.SettingInfo.SCMDataPath, msg);
                    }
                    else if (SCMController.InquiryNumber != 0)
                    {
                        commentSlipNumber = SCMController.InquiryNumber.ToString();
                        msg = "���̒[���ő��M���̈ב��M�ł��܂���ł����B" + Environment.NewLine +
                                        "�⍇���ԍ��y" + commentSlipNumber + "�z";
                        MessageBox.Show(msg, "�񓚑��M����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        SimpleLogger.WriteSlipNumLog(SCMController.SettingInfo.SCMDataPath, msg);
                    }
                    // SCM�󒍃f�[�^�X�V(�����M��ԉ����j
                    UpdateSCMData();
                    // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ---------------------------------------------------------------------<<<<<
                    this.Close();
                }
                // �c�[���{�^���𖳌��ɂ���
                this.myToolbar.Tools["exit"].SharedProps.Enabled = true;
                return;
            }
            // --- UPD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SCMController.WriteLog("�񓚑��M�����N��");
            //SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "�񓚑��M�����N��");
            if (SCMController.IsBatchMode) mode = ""; //�P�̋N������Ȃ��ꍇ�A���[�h�N���A
            SCMController.WriteLog("�񓚑��M�����N��" + mode);
            SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "�񓚑��M�����N��" + mode);
            // --- UPD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            
            try
            {
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t���Ӑ�O���b�h�̃\�[�X��ݒ蒆�c");
                // ���M�擾�Ӑ惊�X�g
                this.sendingCustomerGrid.DataSource = SCMController.SendingCustomerTable.DefaultView;
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t���Ӑ�O���b�h�̃\�[�X��ݒ芮��");

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t���M�f�[�^�O���b�h�̃\�[�X��ݒ蒆�c");
                // ���M�f�[�^������
                this.sendingAnswerGrid.DataSource = SCMController.SendingHeaderTable.DefaultView;
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t���M�f�[�^�O���b�h�̃\�[�X��ݒ芮��");

                // �c�[���{�^����L���ɂ���
                this.myToolbar.Tools["exit"].SharedProps.Enabled = true;
                this.myToolbar.Tools["send"].SharedProps.Enabled = true;
                this.myToolbar.Tools["log"].SharedProps.Enabled = true;
                this.myToolbar.Tools["setting"].SharedProps.Enabled = true;
                this.myToolbar.Tools["filter"].SharedProps.Enabled = true;

                // �c�[���{�^���𖳌��ɂ���
                this.myToolbar.Tools["detail"].SharedProps.Enabled = false;
                this.myToolbar.Tools["delete"].SharedProps.Enabled = false;

                // ���Ӑ���t�B���^�����O(�I�����C����ʋ敪��"SCM"��\���ΏۂƂ���)
                string customerFilter = SCMController.SendingCustomerTable.OnlineKindDivColumn.ColumnName + "=" + ((int)CustomerAgent.OnlineKindDiv.SCM).ToString();
                this.SCMController.SendingCustomerTable.DefaultView.RowFilter = customerFilter;
                if (this.sendingCustomerGrid.Rows.Count > 0)
                {
                    this.sendingCustomerGrid.Rows[0].Selected = true;
                }
            }
            catch (SCMFileOpeningException ex)
            {
                Debug.WriteLine(ex.ToString());

                if (!SCMController.IsBatchMode)
                {
                    MessageBox.Show("�񓚃f�[�^���쐬���ł��B", "�񓚑��M����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (SCMController != null)
                {
                    SCMController.WriteLog("�񓚃f�[�^���쐬���ł��B�N���𒆒f���܂����B");
                    SCMController.CloseLog();
                }
                this.Close();
            }
            // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
            catch (Exception exception)
            {
                if (SCMController != null)
                {
                    SCMController.WriteLog(exception.ToString());
                    SCMController.CloseLog();
                }
                this.Close();
            }
            // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<

            // ���M�N�����[�h�̏ꍇ
            // �A�C�R���݂̂�\�������M�������I��
            if (SCMController.IsBatchMode)
            {
                this.Visible = false;
                this.Refresh();
                OnClickSendToolButton();
                this.Close();
            }
            else
            {
                // �`�[�����\��
                SlipCountRefresh();

                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        #endregion // </������>

        #region <���Ӑ�>

        /// <summary>
        /// ���Ӑ�O���b�h��InitializeLayout�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void sendingCustomerGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = sendingCustomerGrid;
            // �o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            // �񕝎�������
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // �J�����̃L�[
            string codeColumnKey= SCMController.SendingCustomerTable.CustomerCodeColumn.ColumnName; // ���Ӑ�R�[�h
            string nameColumnKey= SCMController.SendingCustomerTable.CustomerNameColumn.ColumnName; // ���Ӑ於��
            string divColumnKey = SCMController.SendingCustomerTable.OnlineKindDivColumn.ColumnName;// �I�����C����ʋ敪

            // ��̕\���^��\��
            band.Columns[divColumnKey].Hidden = true;   // �I�����C����ʋ敪

            // ��
            band.Columns[codeColumnKey].Width = 160;    // ���Ӑ�R�[�h
            band.Columns[nameColumnKey].Width = 280;	// ���Ӑ於��
            // �\����
            band.Columns[codeColumnKey].Header.VisiblePosition = 0;	// ���Ӑ�R�[�h
            band.Columns[nameColumnKey].Header.VisiblePosition = 1;	// ���Ӑ於��
            // �\���ʒu
            band.Columns[codeColumnKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;   // ���Ӑ�R�[�h
            band.Columns[nameColumnKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	// ���Ӑ於��
        }

        /// <summary>
        /// ���Ӑ�O���b�h��AfterRowActivate�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingCustomerGrid_AfterRowActivate(object sender, EventArgs e)
        {
            #region <Guard Phrase>

            if (this.sendingCustomerGrid.ActiveRow == null) return;

            #endregion // </Guard Phrase>

            FilterSendingAnswerGridByCustomerCode();
        }

        /// <summary>
        /// ���M�`�[���X�g�O���b�h�𓾈Ӑ�R�[�h�Ńt�B���^�����O���܂��B
        /// </summary>
        private void FilterSendingAnswerGridByCustomerCode()
        {
            #region <Guard Phrase>

            if (this.sendingCustomerGrid.ActiveRow == null) return;

            #endregion // </Guard Phrase>

            string customerCodeKey = SCMController.SendingCustomerTable.CustomerCodeColumn.ColumnName;
            int currentCustomerCode = (int)this.sendingCustomerGrid.ActiveRow.Cells[customerCodeKey].Value;
            string answerFilter = SCMController.SendingHeaderTable.CustomerCodeColumn.ColumnName + "=" + currentCustomerCode.ToString();
            SCMController.SendingHeaderTable.DefaultView.RowFilter = answerFilter;
        }

        #endregion // </���Ӑ�>

        #region <���M�`�[���X�g>

        #region <������>

        /// <summary>
        /// ���M�`�[���X�g�O���b�h��InitializeLayout�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingAnswerGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = this.sendingAnswerGrid;

            // �o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            // �񕝎�������
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // �J�����̃L�[
            string idKey                = SCMController.SendingHeaderTable.IDColumn.ColumnName;             // ID
            string sendStatusKey = SCMController.SendingHeaderTable.SendStatusColumn.ColumnName;    // �ʐM���
            string inquiryNumberKey     = SCMController.SendingHeaderTable.InquiryNumberColumn.ColumnName;  // �⍇���ԍ�
            string acptAnOdrStatusKey   = SCMController.SendingHeaderTable.AcptAnOdrStatusColumn.ColumnName;// �󒍃X�e�[�^�X
            string slipTypeNameKey      = SCMController.SendingHeaderTable.SlipTypeNameColumn.ColumnName;   // �`�[���
            string salesSlipNumKey      = SCMController.SendingHeaderTable.SalesSlipNumColumn.ColumnName;   // �`�[�ԍ�
            string salesDateKey         = SCMController.SendingHeaderTable.SalesDateColumn.ColumnName;      // �󒍓�
            string salesTotalKey        = SCMController.SendingHeaderTable.SalesTotalColumn.ColumnName;     // ���v���z
            string inqOrdNoteKey        = SCMController.SendingHeaderTable.InqOrdNoteColumn.ColumnName;     // ���l
            string customerCodeKey      = SCMController.SendingHeaderTable.CustomerCodeColumn.ColumnName;   // ���Ӑ�R�[�h

            // ��̕\���^��\��
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in band.Columns)
            {
                // ��x�S�Ĕ�\���ɂ���
                column.Hidden = true;
            }

            // �\������
            band.Columns[sendStatusKey].Hidden = false;    // �ʐM���
            band.Columns[inquiryNumberKey].Hidden = false;	// �⍇���ԍ�
            band.Columns[slipTypeNameKey].Hidden = false;	// �`�[���
            band.Columns[salesSlipNumKey].Hidden = false;	// �`�[�ԍ�
            band.Columns[salesDateKey].Hidden = false;	// �󒍓�
            band.Columns[salesTotalKey].Hidden = false;	// ���v���z
            band.Columns[inqOrdNoteKey].Hidden = false;	// ���l

            // �\����
            band.Columns[sendStatusKey].Header.VisiblePosition = 0;    // �ʐM���
            band.Columns[inquiryNumberKey].Header.VisiblePosition   = 1;	// �⍇���ԍ�
            band.Columns[slipTypeNameKey].Header.VisiblePosition    = 2;	// �`�[���
            band.Columns[salesSlipNumKey].Header.VisiblePosition    = 3;	// �`�[�ԍ�
            band.Columns[salesDateKey].Header.VisiblePosition       = 4;	// �󒍓�
            band.Columns[salesTotalKey].Header.VisiblePosition      = 5;	// ���v���z
            band.Columns[inqOrdNoteKey].Header.VisiblePosition      = 6;	// ���l

            // ��
            band.Columns[sendStatusKey].Width = 70;	// �ʐM���
            band.Columns[inquiryNumberKey].Width= 90;	// �⍇���ԍ�
            band.Columns[slipTypeNameKey].Width = 70;   // �`�[���
            band.Columns[salesSlipNumKey].Width = 100;	// �`�[�ԍ�
            band.Columns[salesDateKey].Width    = 90;	// �󒍓�
            band.Columns[salesTotalKey].Width   = 80;	// ���v���z
            band.Columns[inqOrdNoteKey].Width   = 300;  // ���l

            // ����
            band.Columns[salesDateKey].Format = "yyyy/MM/dd";
            band.Columns[salesTotalKey].Format = "#,##0;-#,##0;";	// ���v���z

            // �\���ʒu
            band.Columns[sendStatusKey].CellAppearance.TextHAlign   = Infragistics.Win.HAlign.Center;	// �ʐM���
            band.Columns[inquiryNumberKey].CellAppearance.TextHAlign= Infragistics.Win.HAlign.Right;	// �⍇���ԍ�
            band.Columns[slipTypeNameKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	    // �`�[���
            band.Columns[salesSlipNumKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	    // �`�[�ԍ�
            band.Columns[salesDateKey].CellAppearance.TextHAlign    = Infragistics.Win.HAlign.Left;	    // �󒍓�
            band.Columns[salesTotalKey].CellAppearance.TextHAlign   = Infragistics.Win.HAlign.Right;	// ���v���z
            band.Columns[inqOrdNoteKey].CellAppearance.TextHAlign   = Infragistics.Win.HAlign.Left;	    // ���l
            
            // �L�[����}�b�s���O��ǉ�
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	// Enter�L�[
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0
                )
            );
        }

        #endregion // </������>

        #region <�c�[���o�[����>

        /// <summary>
        /// ���M�`�[���X�g�O���b�h��Enter�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingAnswerGrid_Enter(object sender, EventArgs e)
        {
            if (!this.myToolbar.Tools["send"].SharedProps.Enabled)
            {
                // �c�[���{�^���𖳌��ɂ���
                this.myToolbar.Tools["detail"].SharedProps.Enabled = false;
                this.myToolbar.Tools["delete"].SharedProps.Enabled = false;
            }
            else
            {
                // �c�[���{�^����L���ɂ���
                this.myToolbar.Tools["detail"].SharedProps.Enabled = true;
                this.myToolbar.Tools["delete"].SharedProps.Enabled = true;
            }
        }

        /// <summary>
        /// ���M�`�[���X�g�O���b�h��leave�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingAnswerGrid_Leave(object sender, EventArgs e)
        {
            // �c�[���{�^���𖳌��ɂ���
            this.myToolbar.Tools["detail"].SharedProps.Enabled = false;
            this.myToolbar.Tools["delete"].SharedProps.Enabled = false;
        }

        #endregion // </�c�[���o�[����>

        /// <summary>
        /// ���M�`�[���X�g�O���b�h��DblClick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingAnswerGrid_DblClick(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            #region <Guard Phrase>

            if (e.Row == null) return;
            if (this.sendingAnswerGrid.ActiveRow == null) return;

            #endregion // </Guard Phrase>

            OnClickDetailToolButton();
        }

        #endregion // </���M�`�[���X�g>

        #region <�c�[���o�[>

        /// <summary>
        /// �c�[���o�[��ToolClick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void myToolbar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "exit":    // �I��
                    OnClickExitToolButton();    break;

                case "detail":	// �ڍ�
                    OnClickDetailToolButton();  break;

                case "delete":	// �폜
                    OnClickDeleteToolButton();  break;

                case "send":    // ���M
                    OnClickSendToolButton(); break;

                case "log":	    // ���O�\��
                    OnClickShowLogToolButton(); break;

                case "setting": // �ݒ�
                    OnClickSettingToolButton(); break;
            }
        }

        #endregion </�c�[���o�[>

        #region <�I��>

        /// <summary>
        /// [�I��]�c�[���{�^����Click�C�x���g�n���h��
        /// </summary>
        private void OnClickExitToolButton()
        {
            this.Close();
        }

        /// <summary>
        /// �񓚑��M��ʃt�H�[����FormClosing�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMSCM01101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ���M�������̏ꍇ�͏I���������s��Ȃ�
            if (!this.myToolbar.Tools["send"].SharedProps.Enabled) return;

            // �폜
            SCMController.AutoDelete();
            SCMController.CloseLog();
            //SendRecevingClose();
            //if (_sendFrm != null)
            //{
            //    _sendFrm.Close();
            //}
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

        #endregion // </�I��>

        #region <�ڍ�>

        /// <summary>
        /// [�ڍ�]�c�[���{�^����Click�C�x���g�n���h��
        /// </summary>
        private void OnClickDetailToolButton()
        {
            #region <Guard Phrase>

            if (this.sendingAnswerGrid.ActiveRow == null) return;

            #endregion // </Guard Phrase>

            DetailRecordForm.CurrentHeaderID = (long)this.sendingAnswerGrid.ActiveRow.Cells[SCMController.SendingHeaderTable.IDColumn.ColumnName].Value;
            DetailRecordForm.ShowDialog();
        }

        #endregion // </�ڍ�>

        #region <�폜>

        /// <summary>
        /// [�폜]�c�[���{�^����Click�C�x���g�n���h��
        /// </summary>
        private void OnClickDeleteToolButton()
        {
            if (this.sendingAnswerGrid.ActiveRow == null)
            {
                return;
            }

            // �폜�m�F���b�Z�[�W
            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "�I�������f�[�^���폜���܂��B" + "\r\n" + "\r\n" +"��낵���ł����H",
                0,
                MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            SCMController.WriteLog("�폜�J�n\r\n");

            SCMController.Delete((DataRowView)this.sendingAnswerGrid.ActiveRow.ListObject);
               
            // �����f�[�^�̃N���A
            SCMController.ClearSCMIOData();

            SCMController.WriteLog("�폜�I��\r\n");
            SCMController.CloseLog();

            // ���O�����
            SCMController.CloseLog();

            // �������^�C�}�[ ON
            this.initializeTimer.Enabled = true;

            this.sendingCustomerGrid.Select();
        }

        // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ---------------------------------------------->>>>>
        /// <summary>
        /// SCM�󒍃f�[�^�֘A���X�V�������M��Ԃ��������܂�
        /// </summary>
        private void UpdateSCMData()
        {
            const string MY_NAME = "PMSCM01101UA";
            const string METHOD = "UpdateSCMData";

            try
            {
                // �X�V�Ώۂ̃��X�g�𐶐�
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t���Ӑ�O���b�h�̃\�[�X��ݒ蒆�c");
                // ���M�擾�Ӑ惊�X�g
                this.sendingCustomerGrid.DataSource = SCMController.SendingCustomerTable.DefaultView;
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t���Ӑ�O���b�h�̃\�[�X��ݒ芮��");

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t���M�f�[�^�O���b�h�̃\�[�X��ݒ蒆�c");
                // ���M�f�[�^������
                this.sendingAnswerGrid.DataSource = SCMController.SendingHeaderTable.DefaultView;
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t���M�f�[�^�O���b�h�̃\�[�X��ݒ芮��");

                SCMController.WriteLog("�폜�J�n\r\n");

                // ���M�f�[�^�����ׂč폜
                for (int i = 0; i < this.sendingAnswerGrid.Rows.Count; i++)
                {
                    SCMController.Delete((DataRowView)this.sendingAnswerGrid.Rows[i].ListObject);
                }

                // �����f�[�^�̃N���A
                SCMController.ClearSCMIOData();

                SCMController.WriteLog("�폜�I��\r\n");
                // ���O�����
                SCMController.CloseLog();

            }
            catch (SCMFileOpeningException ex)
            {
                Debug.WriteLine(ex.ToString());

                if (SCMController != null)
                {
                    SCMController.WriteLog("�񓚃f�[�^���쐬���ł��B�N���𒆒f���܂����B");
                    SCMController.CloseLog();
                }
            }

        }
        // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ----------------------------------------------<<<<<


        #endregion // </�폜>

        #region <���M>

        /// <summary>
        /// [���M]�c�[���{�^����Click�C�x���g�n���h��
        /// </summary>
        private void OnClickSendToolButton()
        {
            #region <Guard Phrase>

            if (!SCMController.IsOpenedLog)
            {
                if (SCMController.OpenLog().Equals((int)ResultUtil.ResultCode.Error))
                {
                    MessageBox.Show("���̒[���ŏ������̈ב��M�o���܂���ł����B\n���΂炭���Ă���ēx�������s���Ă��������B");
                    return;
                }
            }

            #endregion // </Guard Phrase>

        #if DEBUG
            DialogResult result = MessageBox.Show(
                "���M���܂����H",
                "�񓚑��M����",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question
            );
            if (result.Equals(DialogResult.Cancel)) return;
        #else
            // �P�̋N�����[�h�̏ꍇ�A�m�F����
            if (!SCMController.IsBatchMode)
            {
                DialogResult result = MessageBox.Show(
                    "���M���܂����H",
                    "�񓚑��M����",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question
                );
                if (result.Equals(DialogResult.Cancel)) return;
            }
        #endif

            // --- UPD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SCMController.WriteLog("�蓮���M�J�n");
            //SimpleLogger.WriteDebugLog("PMSCM01101UA", "OnClickSendToolButton", "�蓮���M�J�n");
            SCMController.WriteLog("�蓮���M�J�n" + mode);
            SimpleLogger.WriteDebugLog("PMSCM01101UA", "OnClickSendToolButton", "�蓮���M�J�n" + mode);
            // --- UPD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            using (PMSCM01101UC progressForm = new PMSCM01101UC(SCMController, FormStartPosition.CenterParent))
            {
                if (!IsBatchMode) ShowNowSendingForm(); // ADD 2010/03/30 ���M����ʂ̕\���������Ď���

                progressForm.ShowDialog();

                if (!IsBatchMode) CloseNowSendingForm();// ADD 2010/03/30 ���M����ʂ̕\���������Ď���
            }

            // �����f�[�^�̃N���A
            SCMController.ClearSCMIOData();

            // --- UPD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SCMController.WriteLog("�蓮���M�I��\r\n");
            SCMController.WriteLog("�蓮���M�I��" + mode + "\r\n");
            // --- UPD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            SCMController.CloseLog();

            // --- UPD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SimpleLogger.WriteDebugLog("PMSCM01101UA", "OnClickSendToolButton", "�蓮���M�I��");
            SimpleLogger.WriteDebugLog("PMSCM01101UA", "OnClickSendToolButton", "�蓮���M�I��" + mode);
            // --- UPD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ���O�����
            SCMController.CloseLog();

            // �������^�C�}�[ ON
            this.initializeTimer.Enabled = true;
        }

        #endregion // </���M>

        #region <���O�\��>

        # region --- DEL 2011/06/01 ---
        /*
        #region <�e�L�X�g�t�@�C���̃r���[��>

        /// <summary>������</summary>
        private const string NOTEPAD_NAME = "NOTEPAD.EXE";
        /// <summary>�e�L�X�g�t�@�C���̃r���[����</summary>
        private readonly string _textFileViewerName = NOTEPAD_NAME;
        /// <summary>�e�L�X�g�t�@�C���̃r���[�������擾���܂��B</summary>
        private string TextFileViewerName { get { return _textFileViewerName; } }

        #endregion // </�e�L�X�g�t�@�C���̃r���[��>

        /// <summary>�e�L�X�g�t�@�C���̃r���[���p�v���Z�X</summary>
        private Process _textFileViewerProcess;
        /// <summary>�e�L�X�g�t�@�C���̃r���[���p�X���b�h</summary>
        private Thread _textFileViewerThread;

        /// <summary>
        /// [���O�\��]�c�[���{�^����Click�C�x���g�n���h��
        /// </summary>
        private void OnClickShowLogToolButton()
        {
            _textFileViewerThread = new Thread(new ThreadStart(ShowLogFileByTextFileViewer));
            _textFileViewerThread.Start();
        }

        /// <summary>
        /// ���O�t�@�C�����e�L�X�g�t�@�C���̃r���[���ŕ\�����܂��B
        /// </summary>
        /// <remarks>
        /// �O���v���Z�X���N�����邽�߂̃X���b�h
        /// </remarks>
        private void ShowLogFileByTextFileViewer()
        {
            // �O���v���Z�X�̋N��
            try
            {
                _textFileViewerProcess = new Process();
                _textFileViewerProcess.StartInfo.FileName = TextFileViewerName; // �N������t�@�C����
                _textFileViewerProcess.StartInfo.Arguments= SCMController.LogFilePath;
                _textFileViewerProcess.Start();

                // �X���b�h���I�������܂őҋ@
                while (!_textFileViewerProcess.HasExited)
                {
                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException e)
            {
                Debug.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        */
        # endregion

        //--- ADD 2011/06/01 ------------------------------------------------->>>
        private PMSCM01101UD _LogDisplayForm = null;

        /// <summary>
        /// [���O�\��]�c�[���{�^����Click�C�x���g�n���h��
        /// </summary>
        private void OnClickShowLogToolButton()
        {
            // ���O�\���t�H�[���̐���
            if (this._LogDisplayForm == null)
            {
                this._LogDisplayForm = new PMSCM01101UD(SCMController.SettingInfo.SCMDataPath, SCMController.LogFileNameFormat);
            }

            if (!this._LogDisplayForm.Visible)
            {
                // �\���ʒu�����A�A������\�����̂�
                this._LogDisplayForm.Width = this.Width;
                this._LogDisplayForm.Height = (int)(this.Height * 0.8);
                this._LogDisplayForm.Top = this.Top + this.Height - this._LogDisplayForm.Height;
                this._LogDisplayForm.Left = this.Left + 50;
                
            }

            this._LogDisplayForm.Show();            
            this._LogDisplayForm.Activate();
        }
        //--- ADD 2011/06/01 -------------------------------------------------<<<

        #endregion // </���O�\��>

        #region <�ݒ�>

        /// <summary>
        /// [�ݒ�]�c�[���{�^����Click�C�x���g�n���h��
        /// </summary>
        private void OnClickSettingToolButton()
        {
            SCMController.SettingInfo.ShowDialog();
        }

        #endregion // </�ݒ�>

        private void SlipCountRefresh()
        {
            SCMController.GetSlipCnt();
            this.Stat0Cnt_label.Text = String.Format("{0}��", SCMController.Stat0Cnt);
            this.Stat1Cnt_label.Text = String.Format("{0}��", SCMController.Stat1Cnt);

            if (SCMController.SettingInfo.LastDate == DateTime.MinValue)
            {
                this.lblLastDate.Text = "--/--/-- --:--:--";
            }
            else
            {
                this.lblLastDate.Text = (SCMController.SettingInfo.LastDate.ToShortDateString() + " " + SCMController.SettingInfo.LastDate.ToShortTimeString());
            }
        }
    }
}