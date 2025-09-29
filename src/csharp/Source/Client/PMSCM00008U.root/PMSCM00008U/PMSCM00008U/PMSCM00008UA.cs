//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM�ȒP�⍇���V�X�e���Ԑ���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/20  �C�����e : IAAE�ł��琻�i�ł֕ύX(�s�v���W�b�N�폜)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/30  �C�����e : ����`�[���͋N�����ɉ񓚋敪���Z�b�g����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/05/20  �C�����e : ��M�������ǑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 20056�@���n ���
// �� �� ��  2010/06/17  �C�����e : Delphi���`���N������悤�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 30434�@�H�� �b�D
// �� �� ��  2010/06/26  �C�����e : IDExchange�T�[�r�X�̕ύX�ɔ����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/02/03  �C�����e : �@�V�X�e�����̐ڑ��A�J�E���g�Ǘ��֌W�̃��W�b�N�폜
//                                 �ACMT�ڑ������t���O�Ǘ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/02/18  �C�����e : �L�����Z���敪�̎d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/03/03  �C�����e : CMT�A�g�̎���Ή�
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;   

using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
// 2011/03/03 Add >>>
using Broadleaf.Library.Collections;
using System.Collections;
// 2011/03/03 Add <<<

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// SCM�ȒP�⍇���V�X�e���Ԑ���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬(IAAE����ύX)</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/20</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM00008UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region �� Private Const

        /// <summary>�f�t�H���gx���W</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>�f�t�H���gy���W</summary>
        private const int DEFAULT_Y = 100000;

        /// <summary>���O�t�@�C������</summary>
        private const string ctLogName = "PMSCM00008U_{0}.log";

        private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01001U.exe";   // 2010/06/17
        private const string CTI_EXE_NAME = "PMSCM00100U.exe";              // 2011/03/04 Add

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Member

        private readonly string[] _commandLineArgs; // �R�}���h���C������ 
        private Thread _createInstanceThread;       // ����`�[���͐����p�X���b�h
        private Thread _msgCatchProcThread = null;  // Ipc���b�Z�[�W��M�����p�X���b�h
        private PosTerminalMg _posTerminalMg;       // �[���Ǘ����

        //private MAHNB01010UA _entryFrm;             // ����`�[���� �t�H�[���N���X // 2010/06/17
        private PMSCM01104UA _compDlg;              // �������

        bool first = true;                          // ����N���t���O

        private PMSCM01104UA _rcvForm = null;       // ���������
        private List<PMSCM00009UA> _list;           // ��M��ʃ��X�g
        private UserSCMOrderHeaderRecord _cuurentData;  // �����Ώۂ�SCM�󒍃f�[�^

        private CmtLocalSet _cmtLocalSet;           // ���[�J���ݒ�

        // 2011/02/03 Del >>>
        //private SimplInqCnectInfoAcs _simplInqCnectInfoAcs;     // �ȒP�⍇���ڑ����A�N�Z�X�N���X
        // 2011/02/03 Del <<<
        private SimplInqIDExchangeAcs _simplInqIDExchangeAcs;   // �ȒP�⍇��Web�T�[�r�X�A�N�Z�X�N���X
        
        private IIOWriteScmDB _iIOWriteScmDB;       // SCM I/OWriter

        private SCMDtRcveExecAcs _sCMDtRcveExecAcs;  // SCM ��M�N�������[�g�A�N�Z�X�N���X  2010/05/20 Add

        // 2011/02/03 Add >>>
        private bool _cmtConnected = false;         // CMT�ڑ��Ǘ��t���O
        // 2011/02/03 Add <<<

        #endregion

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        #region �� Delegate

        /// <summary>�G���g���C���X�^���X�����f���Q�[�g</summary>
        private delegate void CreateEntryInstanceDelegate();

        /// <summary>���b�Z�[�W��M�����p�f���Q�[�g</summary>
        /// <param name="msg">��M���b�Z�[�W</param>
        private delegate void CatchMessageDelegate(object msg);

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region �� Property

        /// <summary>�R�}���h���C���������擾���܂��B</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �� Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMSCM00008UA()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="commandLineArgs">�R�}���h���C������</param>
        public PMSCM00008UA(string[] commandLineArgs)
            : this()
        {
            _commandLineArgs = commandLineArgs;

            // 2010/04/05 >>>
            //this._cmtConnectionAcs = new CMTConnectionAcs();    // 2010/03/02 Add

            // 2011/02/03 Del >>>
            //this._simplInqCnectInfoAcs = new SimplInqCnectInfoAcs();
            // 2011/02/03 Del <<<
            // 2010/04/05 <<<
        }

        #endregion

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        #region �� Control Event

        /// <summary>
        /// ��� ���[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //// �����ʒu��ݒ�i������h�~�ׁ̈A10000�ɂ��Ă��܂��j
            SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

            this._iIOWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB(); // IOWriter

            // �[���Ǘ����̎擾
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            posTerminalMgAcs.Search(out this._posTerminalMg, LoginInfoAcquisition.EnterpriseCode);

            // ���[�J���ݒ�̎擾
            CmtLocalSetAcs cmtLocalSetAcs = new CmtLocalSetAcs();
            this._cmtLocalSet = cmtLocalSetAcs.ReadScmLocalSet();
            if (this._cmtLocalSet == null) this._cmtLocalSet = new CmtLocalSet();
            if (this._cmtLocalSet.RecvTime == 0) this._cmtLocalSet.RecvTime = 30;
            if (this._cmtLocalSet.CTIMode == -1) this._cmtLocalSet.CTIMode = 1;   // 2011/03/04 Add
            cmtLocalSetAcs.CmtLocal = this._cmtLocalSet;
            cmtLocalSetAcs.WriteLocalSet();

            this.ScmLoadingDlg_Timer.Interval = this._cmtLocalSet.RecvTime * 1000;

            // IPC�T�[�o�[�̐����E�C�x���g�o�^
            SimpleInqPMIpcServer server = new SimpleInqPMIpcServer();
            server.SimplInqPMCommMsg.MessageRecieveEvent += new SimplInqPMCommMsg.ReceivedMessageEventHandler(msg_eventCall);
            // 2011/02/03 Add >>>
            server.SimplInqPMCommMsg.ConnectCheckEvent += new SimplInqPMCommMsg.CheckedConnectEventHandler(ConnectionCheck_EventCall);
            // 2011/02/03 Add <<<

            // �A�v���I�����̃C�x���g�ǉ�
            System.Windows.Forms.Application.ApplicationExit += new EventHandler(Application_ApplicationExit); 

            // ����`�[���̓C���X�^���X���X���b�h�̊J�n
            this._createInstanceThread = new Thread(new ThreadStart(this.CreateEntryInstance));
            this._createInstanceThread.IsBackground = true;
            this._createInstanceThread.Start();

            WriteLog("MainForm_Load", "�풓�J�n");
        }


        /// <summary>
        /// ��ʕ\�����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// SCM���ʏ������_�C�A���O�I���^�C�}�[(Exception���Ő���I�����Ȃ������Ƃ��̈�)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScmLoadingDlg_Timer_Tick(object sender, EventArgs e)
        {
            ScmLoadingDlg_Timer.Enabled = false;
            try
            {
                if (_rcvForm != null)
                {
                    _rcvForm.Close();
                    _rcvForm.Dispose();
                    _rcvForm = null;
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// �����ʒm�p�^�C�}�[
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compMsg_timer_Tick(object sender, EventArgs e)
        {
            compMsg_timer.Enabled = false;
            try
            {
                _compDlg.Close2();
                _compDlg.Dispose();
                _compDlg = null;
            }
            catch (Exception)
            {
            }
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        /// <summary>
        /// �A�v���P�[�V�����I�����̃C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            // 2011/02/03 >>>
            //// �ȒP�⍇���ڑ������N���A����(���[����)
            //this.ClearConnection();
            this._cmtConnected = false;
            // 2011/02/03 <<<

            System.Windows.Forms.Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
        }

        // 2011/02/03 Add >>>
        #region �� �ڑ��Ǘ��֘A
        /// <summary>
        /// �ڑ��`�F�b�N�C�x���g
        /// </summary>
        /// <param name="isConnected"></param>
        private void ConnectionCheck_EventCall(out bool isConnected)
        {
            // CMT�A�g���t���O��Ԃ�
            isConnected = this._cmtConnected;
        }
        #endregion
        // 2011/02/03 Add <<<

        #region �� ���b�Z�[�W��M�֘A

        /// <summary>
        /// Ipc���b�Z�[�W��M���C�x���g
        /// </summary>
        /// <param name="str">Ipc�N���C�A���g����̃��b�Z�[�W</param>
        private void msg_eventCall(string msg)
        {
            // ���b�Z�[�W��M�����p�X���b�h�J�n
            this._msgCatchProcThread = new Thread(new ParameterizedThreadStart(CatchMessageThreadStart));
            this._msgCatchProcThread.IsBackground = true;   // �o�b�N�O���E���h�X���b�h
            this._msgCatchProcThread.SetApartmentState(ApartmentState.STA);
            this._msgCatchProcThread.Start(msg);
        }

        /// <summary>
        ///	Ipc���b�Z�[�W��M�������p�X���b�h�J�n����
        /// </summary>
        /// <param name="msg">��M���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note        : Ipc���b�Z�[�W��M�������p�X���b�h���J�n���܂��B</br>
        /// </remarks>
        private void CatchMessageThreadStart(object msg)
        {
            // �X���b�h�Z�[�t�ɂ��邽��Invoke�Ńf���Q�[�g���Ăяo��
            // ���Ȃ݂ɁA�ʃX���b�h���璼�ڃ��C���X���b�h�̃R���g���[����ύX�ł��Ȃ�
            Invoke(new CatchMessageDelegate(CatchMessageProc), msg);
        }

        /// <summary>
        /// ���b�Z�[�W��M���̎��ۂ̏���
        /// </summary>
        /// <param name="msg">��M���b�Z�[�W</param>
        private void CatchMessageProc(object msg)
        {
            WriteLog("CatchMessageProc", "Start");

            /*---<���� ��M���b�Z�[�W�͎��̌`���ł�-----------------------------------------------------------------------//
             * �R�~���j�P�[�V�����c�[���̏�Ԏ擾
             *  �y�v���O�C���N���z
             *      "pluginon"
             *  �y�v���O�C���I���z
             *      "pluginoff"
             *  �y�ڑ��z
             *      "Connect"
             *  �y�ؒf�z
             *      "DisConnect" (1�A�J�E���g�̏ꍇ�́A:��؂�ŃA�J�E���gID����M���܂�)
             * 
             * PM��SF/BK�̒ʐM (�J���}��؂�)                                                                                                
             *  �y�⍇����/�����񓚁z                                                                                    
             *�@    �⍇������ƃR�[�h:�⍇�������_�R�[�h:�⍇�����ƃR�[�h:�⍇���拒�_�R�[�h:�⍇���E�������:�⍇���ԍ�:�X�V���t:�X�V����
             *  �y�������M�����z                                                                                         
             *�@    �⍇������ƃR�[�h:�⍇�������_�R�[�h:�⍇�����ƃR�[�h:�⍇���拒�_�R�[�h:�⍇���E�������:complete    
             ____________________________________________________________________________________________________________*/

            string[] messages;

            try
            {
                // �p�����[�^�s��
                if (string.IsNullOrEmpty((string)msg))
                {
                    WriteLog("CatchMessageProc", "�p�����[�^�s��");
                    return;
                }

                // ��M���b�Z�[�W���R�����ŋ�؂�
                messages = ( (string)msg ).Split(':');

                WriteLog("CatchMessageProc", (string)msg);

                switch (messages[0])
                {
                    #region �v���O�C��:On
                    case "pluginon":
                        {
                            this._cmtConnected = true;  // 2011/02/03 Add
                            break;
                        }
                    #endregion  // �v���O�C��:On

                    #region �v���O�C��:Off
                    case "pluginoff":
                        {
                            // 2011/02/03 >>>
                            //this.ClearConnection();
                            this._cmtConnected = false;
                            // 2011/02/03 <<<
                            break;
                        }
                    #endregion  // �v���O�C��:Off

                    #region �A�J�E���g�ڑ����������ꍇ
                    case "Connect":
                        {
                            if (messages.Length > 1)
                            {
                                // �S�A�J�E���g�𓾈Ӑ�ɕϊ����A�ڑ����ǉ���CTI�N��
                                List<int> customerCodeList = new List<int>();
                                for (int i = 1; i < messages.Length; i++)
                                {
                                    CustomerSearchRet customer = GetCustomerFromInqAcount(messages[i]);
                                    if (customer != null)
                                    {
                                        if (!customerCodeList.Contains(customer.CustomerCode))
                                        {
                                            this.ExecuteCTI(customer.CustomerCode);
                                            // 2011/02/03 Del >>>
                                            //this.AddConnection(customer.CustomerCode);
                                            this._cmtConnected = true;
                                            // 2011/02/03 Del <<<
                                            customerCodeList.Add(customer.CustomerCode);
                                        }
                                    }
                                }
                            }

                            break;
                        }
                    #endregion  // �A�J�E���g�ڑ����������ꍇ

                    #region �ؒf���������ꍇ
                    case "DisConnect":
                        {
                            // 2011/02/03 Del >>>
                            //// �A�J�E���g�w�肪�Ȃ������ꍇ�͑S�Đؒf
                            //if (messages.Length == 1)
                            //{
                            //    this.ClearConnection();
                            //}
                            //else if (messages.Length > 1)
                            //{
                            //    // �S�A�J�E���g�𓾈Ӑ�ɕϊ����A�ڑ����폜
                            //    List<int> customerCodeList = new List<int>();
                            //    for (int i = 1; i < messages.Length; i++)
                            //    {
                            //        CustomerSearchRet customer = GetCustomerFromInqAcount(messages[i]);
                            //        if (customer != null)
                            //        {
                            //            if (!customerCodeList.Contains(customer.CustomerCode))
                            //            {
                            //                this.DelConnection(customer.CustomerCode);
                            //                customerCodeList.Add(customer.CustomerCode);
                            //            }
                            //        }
                            //    }
                            //}
                            // 2011/02/03 Del <<<
                            break;
                        }
                    #endregion  // �ؒf���������ꍇ

                    #region ��L�ȊO(��M�A�����ʒm)
                    default:
                        // 2011/02/03 Add >>>
                        // �O�ׂ̈����ł��t���O�𗧂Ă�
                        this._cmtConnected = true;
                        // 2011/02/03 Add <<<
                        if (messages.Length > 5)
                        {
                            // ����ƁE�����_�ɑ���ꂽ���b�Z�[�W�łȂ���ΏI��
                            if (messages[2] != LoginInfoAcquisition.EnterpriseCode || messages[3].Trim() != LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
                            {
                                WriteLog("CatchMessageProc", "�����_���̑��M�ł͂���܂���:" + LoginInfoAcquisition.EnterpriseCode + "," + LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                                return;
                            }
                            if ("complete" == messages[5])
                            {
                                // �������M�����_�C�A���O�\��
                                completeDlgShow();
                            }
                            else if (messages.Length == 8)
                            {
                                // 2011/03/03 >>>
                                //_rcvForm = new PMSCM01104UA();
                                //int status = 0;
                                //_rcvForm.Title = "��M����";
                                //_rcvForm.Message = "�f�[�^����M���Ă��܂�";
                                //_rcvForm.Show();

                                int status = 0;
                                if (_rcvForm == null)
                                {
                                    _rcvForm = new PMSCM01104UA();
                                    _rcvForm.Title = "��M����";
                                    _rcvForm.Message = "�f�[�^����M���Ă��܂�";
                                    _rcvForm.Show();
                                }
                                // 2011/03/03 <<<
                                this.ScmLoadingDlg_Timer.Stop();
                                this.ScmLoadingDlg_Timer.Enabled = true;
                                this.ScmLoadingDlg_Timer.Start();

                                string inqOriginalEpCd = messages[0].Trim();
                                string inqOriginalSecCd = messages[1].Trim();
                                string inqOtherEpCd = messages[2].Trim();
                                string inqOtherSecCd = messages[3].Trim();
                                int inqOrdDivCd = TStrConv.StrToIntDef(messages[4].Trim(), 0);
                                long inqNum = (long)TStrConv.StrToDoubleDef(messages[5].Trim(), 0);

                                DateTime updateDate = DateTime.MinValue;
                                try
                                {
                                    updateDate = DateTime.ParseExact(messages[6].Trim(), "yyyyMMdd", null);
                                }
                                catch
                                {
                                }
                                int updateTime = TStrConv.StrToIntDef(messages[7].Trim(), 0);


                                status = 2;

                                // �₢���킹�f�[�^�̓Ǎ�
                                UserSCMOrderHeaderRecord scmorderHeader = null;
                                // 2011/03/03 Add >>>
                                List<UserSCMOrderDetailRecord> detailList = null;
                                // 2011/03/03 Add <<<

                                int retryCnt = this._cmtLocalSet.RecvTime;
                                for (int cnt = 1; cnt <= retryCnt; cnt++)
                                {
                                    // 2010/05/20 Add >>>
                                    this.ExecuteReceive();
                                    // 2010/05/20 Add <<<
                                    // 2011/03/03 >>>
                                    //scmorderHeader = this.ReadSCMData(inqOriginalEpCd, inqOriginalSecCd, inqOtherEpCd, inqOtherSecCd, inqNum, inqOrdDivCd, updateDate, updateTime);
                                    this.ReadSCMData(inqOriginalEpCd.Trim(), inqOriginalSecCd, inqOtherEpCd, inqOtherSecCd, inqNum, inqOrdDivCd, updateDate, updateTime, out scmorderHeader, out detailList);//@@@@20230303
                                    // 2011/03/03 <<<
                                    if (scmorderHeader != null) break;
                                    System.Threading.Thread.Sleep(1000);
                                }

                                // �������犮����ʕ\��
                                if (scmorderHeader != null)
                                {
                                    status = 4;

                                    const string ctProtcol_SBpipe = "pmcmtpipe";
                                    // �ȒP�⍇���Ƀ��b�Z�[�W���M
                                    string errorMsg;
                                    status = SimpleInquiryPipeMessage.Send(ctProtcol_SBpipe + ":" + messages[0] + ":" + messages[1] + ":" + messages[2] + ":" + messages[3] + ":" + messages[4] + ":" + "complete", 30000, out errorMsg);
                                    // 2011/02/03 >>>
                                    //this.AddConnection(scmorderHeader.CustomerCode);
                                    // 2011/02/03 <<<
                                    // 2011/03/03 >>>
                                    //this.ShowRcvCompDialog(scmorderHeader);
                                    this.ShowRcvCompDialog(scmorderHeader, detailList);
                                    // 2011/03/03 <<<
                                    status = 0;
                                }
                                else
                                {
                                    WriteLog("CatchMessageProc", "��M�ΏۂƂȂ�f�[�^�����݂��܂���ł���");

                                    if (this._cmtLocalSet.Retry == 1)
                                    {
                                        this.TopMost = true;
                                        System.Windows.Forms.Application.DoEvents();
                                        this.TopMost = false;
                                        DialogResult ret =
                                            MessageBox.Show(this, "�f�[�^����M�ł��܂���ł����B" + Environment.NewLine + "�Ď��s���܂����H",
                                            "��M����",
                                            MessageBoxButtons.RetryCancel,
                                            MessageBoxIcon.Information);

                                        if (ret == DialogResult.Retry)
                                        {
                                            this.CatchMessageThreadStart(msg);
                                            return;
                                        }
                                    }
                                }

                            }
                        }
                        
                        break;
                    #endregion  // ��L�ȊO(��M�A�����ʒm)
                }
            }
            catch (Exception ex)
            {
                WriteLog("CatchMessageProc", ex.Message);
            }
            finally
            {
                WriteLog("CatchMessageProc", "End");
            }
        }

        #endregion

        /// <summary>
        /// �����ʒm��ʕ\������
        /// </summary>
        private void completeDlgShow()
        {
            if (_compDlg == null)
            {
                compMsg_timer.Stop();
                _compDlg = new PMSCM01104UA();
                compMsg_timer.Enabled = true;
                _compDlg.Show2(this);
                compMsg_timer.Start();
            }
        }

        #region �� �f�[�^��M�֘A

        /// <summary>
        /// �f�[�^��M��ʂ��\�����ꂽ�Ƃ��ɌĂяo����܂�
        /// </summary>
        /// <param name="sender">�┭���</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void RcvCompDialog_Shown(object sender, EventArgs e)
        {
            // SCM���ʏ�������ʂ��N���[�Y
            try
            {
                lock (_rcvForm)
                {
                    if (_rcvForm != null)
                    {
                        _rcvForm.Close();
                        _rcvForm.Dispose();
                        _rcvForm = null;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// ��M������ʂ̕\��
        /// </summary>
        /// <param name="header"></param>
        // 2011/03/03 >>>
        //private void ShowRcvCompDialog(UserSCMOrderHeaderRecord header)
        private void ShowRcvCompDialog(UserSCMOrderHeaderRecord header, List<UserSCMOrderDetailRecord> detailList)
        // 2011/03/03 <<<
        {
            if (_list != null && _list.Count > 0)
            {
                foreach (PMSCM00009UA fm in _list)
                {
                    if (fm != null && !fm.IsDisposed)
                    {
                        fm.Invoke(new MethodInvoker(fm.Close));
                        fm.Close();
                        fm.Dispose();
                    }
                }
                _list.Clear();

            }

            _cuurentData = new UserSCMOrderHeaderRecord();
            _cuurentData.EnterpriseCode = header.EnterpriseCode;
            _cuurentData.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
            _cuurentData.InqOriginalSecCd = header.InqOriginalSecCd;
            _cuurentData.InqOtherEpCd = header.InqOtherEpCd;
            _cuurentData.InqOtherSecCd = header.InqOtherSecCd;
            _cuurentData.InquiryNumber = header.InquiryNumber;
            _cuurentData.InqOrdDivCd = header.InqOrdDivCd;
            _cuurentData.AcptAnOdrStatus = header.AcptAnOdrStatus;
            _cuurentData.SalesSlipNum = header.SalesSlipNum;
            _cuurentData.AnswerDivCd = header.AnswerDivCd;
            // 2011/02/18 Add >>>
            _cuurentData.CancelDiv = header.CancelDiv;
            // 2011/02/18 Add <<<

            PMSCM00009UA frm = new PMSCM00009UA();

            frm.Top = ( Screen.PrimaryScreen.WorkingArea.Height - this.Height ) / 2;
            frm.Left = ( Screen.PrimaryScreen.WorkingArea.Width - this.Width ) / 2;

            // ���Ӑ���擾
            CustomerInfo ret = this.GetCustomerInfo(header.CustomerCode);

            if (ret != null)
            {
                frm.CustomerCode = ret.CustomerCode;
                frm.CustomerSnm = ret.CustomerSnm;
            }

            frm.InqOrdDiv = (PMSCM00009UA.InqOrdDivCd)header.InqOrdDivCd;
            frm.InquiryNumber = header.InquiryNumber;
            // 2011/03/03 Add >>>
            frm.CancelDiv = header.CancelDiv;
            UserSCMOrderDetailRecord cancelRow = this.GetCancelRow(detailList);
            if (cancelRow != null)
            {
                frm.CancelRowNumber = cancelRow.InqRowNumber;
                frm.CancelGoodsName = ( string.IsNullOrEmpty(cancelRow.AnsGoodsName.Trim()) ) ? cancelRow.InqGoodsName.Trim() : cancelRow.AnsGoodsName.Trim();
            }
            // 2011/03/03 Add <<<

            // �C�x���g�̒ǉ�
            frm.button_ExecuteEntry.Click += new EventHandler(this.ExecuteEntry);
            frm.Shown += new EventHandler(RcvCompDialog_Shown);

            frm.Show();
            frm.TopMost = true;
            System.Windows.Forms.Application.DoEvents();
            frm.TopMost = false;
            if (_list == null) _list = new List<PMSCM00009UA>();
            _list.Add(frm);
        }

        // 2011/03/03 Add >>>
        /// <summary>
        /// ����f�[�^���`�F�b�N���܂�
        /// </summary>
        /// <param name="detailList"></param>
        /// <returns></returns>
        private UserSCMOrderDetailRecord GetCancelRow(List<UserSCMOrderDetailRecord> detailList)
        {
            return detailList.Find(
                    delegate(UserSCMOrderDetailRecord data)
                    {
                        if (data.CancelCndtinDiv == 30) return true;
                        return false;
                    });
            ;
        }
        // 2011/03/03 Add <<<


        #region ��M�f�[�^�̓ǂݍ���

        /// <summary>
        /// ��M�f�[�^�̓ǂݍ���
        /// </summary>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="inqOrdDivCd">�⍇���E�������</param>
        /// <param name="updateDate">�X�V�N����</param>
        /// <param name="updateTime">�X�V�����b�~���b</param>
        /// <returns></returns>
        // 2011/03/03 >>>
        //private UserSCMOrderHeaderRecord ReadSCMData(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, long inquiryNumber, int inqOrdDivCd, DateTime updateDate, int updateTime)
        private void ReadSCMData(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, long inquiryNumber, int inqOrdDivCd, DateTime updateDate, int updateTime, out UserSCMOrderHeaderRecord header, out List<UserSCMOrderDetailRecord> detailList)
        // 2011/03/03 <<<
        {
            SCMAcOdrDataWork para = new SCMAcOdrDataWork();
            para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            para.InqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            para.InqOriginalSecCd = inqOriginalSecCd;
            para.InqOtherEpCd = inqOtherEpCd;
            para.InqOtherSecCd = inqOtherSecCd;
            para.InquiryNumber = inquiryNumber;
            para.UpdateDate = updateDate;
            para.UpdateTime = updateTime;

            object paraObj = (object)para;
            // 2011/03/03 >>>
            //object retObj;

            //int status = this._iIOWriteScmDB.GetSCMAcOdrData(out retObj, paraObj);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    if (retObj is SCMAcOdrDataWork)
            //    {
            //        SCMAcOdrDataWork scmHeaderWork = (SCMAcOdrDataWork)retObj;
            //        UserSCMOrderHeaderRecord retHeader = new UserSCMOrderHeaderRecord(scmHeaderWork);

            //        return retHeader;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //else
            //{
            //    return null;
            //}

            header = null;
            detailList = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            int status = this._iIOWriteScmDB.GetSCMAcOdrData(ref retList, paraObj);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SCMAcOdrDataWork scmHeaderWork = null;
                ArrayList inqList = null;
                if (retList != null)
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        if (retList[i] is SCMAcOdrDataWork)
                        {
                            scmHeaderWork = (SCMAcOdrDataWork)retList[i];
                        }
                        else if (retList[i] is ArrayList)
                        {
                            inqList = (ArrayList)retList[i];
                        }
                    }
                }
                if (scmHeaderWork != null) header = new UserSCMOrderHeaderRecord(scmHeaderWork);

                if (inqList != null)
                {
                    detailList = new List<UserSCMOrderDetailRecord>();
                    foreach (SCMAcOdrDtlIqWork dtlInq in inqList)
                    {
                        detailList.Add(new UserSCMOrderDetailRecord(dtlInq));
                    }
                }
            }
            // 2011/03/03 <<<
        }

        #endregion // ��M�f�[�^�̓ǂݍ���


        // 2010/05/20 Add >>>
        /// <summary>
        /// �f�[�^��M�����̋N��
        /// </summary>
        private int ExecuteReceive()
        {
            string msg;
            if (_sCMDtRcveExecAcs == null) _sCMDtRcveExecAcs = new SCMDtRcveExecAcs();
            //>>>2010/07/30
            this._sCMDtRcveExecAcs.GetStartParameterEvent += new SCMDtRcveExecAcs.GetStartParameterEventHandler(this.GetStartParameter);
            //<<<2010/07/30
            return this._sCMDtRcveExecAcs.DataReceive(false, out msg);
        }
        // 2010/05/20 Add <<<

        #endregion // �f�[�^��M�֘A

        /// <summary>
        /// ����`�[���̓C���X�^���X������
        /// </summary>
        private void CreateEntryInstance()
        {
            if (InvokeRequired)
            {
                // �X���b�h�Z�[�t
                Invoke(new CreateEntryInstanceDelegate(CreateEntryInstance));
                return;
            }

            //_entryFrm = new MAHNB01010UA(); // 2010/06/17
        }

        /// <summary>
        /// �G���g����ʂ̋N��
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void ExecuteEntry(object obj, EventArgs e)
        {
            //>>>2010/06/17
            //while (_createInstanceThread.ThreadState == System.Threading.ThreadState.Running)
            //{
            //    Thread.Sleep(100);
            //}

            //bool isNew = false;
            //if (_entryFrm == null || _entryFrm.IsDisposed)
            //{
            //    _entryFrm = new MAHNB01010UA();
            //    isNew = true;
            //}
            //if (_cuurentData != null)
            //{
            //    _entryFrm.InqOriginalEpCd = _cuurentData.InqOriginalEpCd;
            //    _entryFrm.InqOriginalSecCd = _cuurentData.InqOriginalSecCd;
            //    _entryFrm.InquiryNumber = _cuurentData.InquiryNumber;
            //    _entryFrm.AcptAnOdrStatus = _cuurentData.AcptAnOdrStatus;
            //    _entryFrm.SalesSlipNum = _cuurentData.SalesSlipNum;
            //    // 2010/04/30 Add >>>
            //    _entryFrm.AnswerDivCd = _cuurentData.AnswerDivCd;
            //    // 2010/04/30 Add <<<
            //    _entryFrm.TopMost = true;
            //    System.Windows.Forms.Application.DoEvents();
            //    _entryFrm.TopMost = false;
            //    System.Windows.Forms.Application.DoEvents();
            //    _entryFrm.InqOrdDivCd = _cuurentData.InqOrdDivCd;

            //    if (_entryFrm.WindowState == FormWindowState.Minimized)
            //    {
            //        _entryFrm.WindowState = FormWindowState.Normal;
            //    }

            //    // ���O�C���p�����[�^����ݒ�
            //    StringBuilder loginArguments = new StringBuilder();
            //    {
            //        foreach (string argument in CommandLineArgs)
            //        {
            //            if (!string.IsNullOrEmpty(argument.Trim()))
            //            {
            //                loginArguments.Append(argument + " ");
            //            }
            //        }
            //    }
            //    loginArguments.ToString();
            //}

            //_entryFrm.Show();
            //if (!first && !isNew)
            //{
            //    _entryFrm.InputInquiryNumber();
            //}
            //first = false;

            string programPath = Path.Combine(Directory.GetCurrentDirectory(), SALESSLIPINPUT_EXE_NAME);
            if (!File.Exists(programPath)) return;

            // ���O�C���p�����[�^����ݒ�
            StringBuilder param = new StringBuilder();
            {
                foreach (string argument in CommandLineArgs)
                {
                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        param.Append(argument + " ");
                    }
                }
            }

            param.Append("/SCM ");
            param.Append(_cuurentData.InquiryNumber.ToString() + ','); // �⍇���ԍ�
            param.Append(_cuurentData.AcptAnOdrStatus.ToString() + ','); // �󒍃X�e�[�^�X
            param.Append(_cuurentData.SalesSlipNum + ','); // ����`�[�ԍ�
            param.Append(_cuurentData.InqOriginalEpCd.Trim() + ','); // �⍇����ƃR�[�h//@@@@20230303_
            param.Append(_cuurentData.InqOriginalSecCd + ','); // �⍇�����_�R�[�h
            param.Append(_cuurentData.InqOrdDivCd.ToString() + ','); // �⍇���E�������
            // 2011/02/18 >>>
            //param.Append(_cuurentData.AnswerDivCd.ToString() + ','); // �񓚋敪
            param.Append(_cuurentData.CancelDiv.ToString() + ','); // �L�����Z���敪
            // 2011/02/18 <<<

            Process.Start(programPath, param.ToString());
            //<<<2010/06/17
        }

        // 2011/02/03 Del >>>
#if False
        #region �� �ȒP�⍇���ڑ����̊Ǘ�
        /// <summary>
        /// �R�~���j�P�[�V�������̍폜
        /// </summary>
        /// <param name="customerCode"></param>
        private void DelConnection(int customerCode)
        {
            WriteLog("DelConnection", string.Format("EnterpriseCode:{0},CashRegisterNo:{1},CustomerCode:{2}", LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, customerCode));

            this._simplInqCnectInfoAcs.DeleteConnect(LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, customerCode);
        }

        /// <summary>
        /// �R�~���j�P�[�V�������̍폜
        /// </summary>
        private void ClearConnection()
        {
            WriteLog("ClearConnection", "EnterpriseCode:" + LoginInfoAcquisition.EnterpriseCode + "," + "CashRegisterNo:" + this._posTerminalMg.CashRegisterNo.ToString());
            // �ڑ����̃N���A(���Ӑ�O�ŁA�[������S�ăN���A)
            this._simplInqCnectInfoAcs.DeleteConnect(LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, 0);
        }

        /// <summary>
        /// �R�~���j�P�[�V�������̒ǉ�
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        private void AddConnection(int customerCode)
        {
            WriteLog("AddConnection", string.Format("EnterpriseCode:{0},CashRegisterNo:{1},CustomerCode:{2}", LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, customerCode));

            this._simplInqCnectInfoAcs.AddConnect(LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, customerCode);
        }

        #endregion // �ȒP�⍇���ڑ����̊Ǘ�
#endif
        // 2011/02/03 Del <<<

        /// <summary>
        /// ���Ӑ���̎擾
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerInfo GetCustomerInfo(int customerCode)
        {
            CustomerInfo inf;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            int status = customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out inf);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return inf;
            }
            return null;
        }

        /// <summary>
        /// �ȒP�⍇���̃A�J�E���g���A���Ӑ����肵�܂��B
        /// </summary>
        /// <param name="acntId"></param>
        /// <returns></returns>
        private CustomerSearchRet GetCustomerFromInqAcount(string acntId)
        {
            SmplInqBas smplInqbas = GetSmplInqBas(acntId);
            if (smplInqbas == null)
            {
                WriteLog("GetCustomerFromInqAcount", "�A�J�E���g�̕ϊ��Ɏ��s���܂����B:" + acntId);
                return null;
            }

            List<CustomerSearchRet> custList = new List<CustomerSearchRet>();
            CustomerSearchAcs _customerSearchAcs = new CustomerSearchAcs();
            CustomerSearchPara para = new CustomerSearchPara();
            {
                para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            CustomerSearchRet[] retList;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            int status = customerSearchAcs.Serch(out retList, para);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                custList = new List<CustomerSearchRet>();

                custList.AddRange(retList);
            }
            else
            {
                return null;
            }
            if (custList == null || custList.Count == 0) return null;

            // ADD 2010/06/26 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
            if (custList.Count.Equals(1))
            {
                return custList[0]; // 1���݂̂̏ꍇ�A���̂܂ܕԂ�
            }

            // ��ƃR�[�h��0�l16���œ���
            smplInqbas.EnterpriseCode = smplInqbas.EnterpriseCode.Trim().PadLeft(16, '0');

            #region ��ƃR�[�h + �A�J�E���g�O���[�vID�œ��Ӑ�����i���Y���Ȃ��̏ꍇ�A��ƃR�[�h�݂̂œ��聫�j

            SmplInqBasExt smpInqBasExt = smplInqbas as SmplInqBasExt;
            if (smpInqBasExt != null)
            {
                List<string> simplInqAcntGrIdList = smpInqBasExt.SimplInqAcntGrIdList;
                foreach (string simpInqAcntGrId in simplInqAcntGrIdList)
                {
                    CustomerSearchRet foundCustomer = custList.Find(
                        delegate(CustomerSearchRet searchRet)
                        {
                            // null�`�F�b�N
                            if (searchRet == null) return false;
                            if (string.IsNullOrEmpty(searchRet.CustomerEpCode))
                            {
                                searchRet.CustomerEpCode = string.Empty;
                            }
                            if (string.IsNullOrEmpty(searchRet.SimplInqAcntAcntGrId))
                            {
                                searchRet.SimplInqAcntAcntGrId = string.Empty;
                            }

                            // ��ƃR�[�h��0�l16���œ���
                            searchRet.CustomerEpCode = searchRet.CustomerEpCode.Trim().PadLeft(16, '0');

                            if (
                                searchRet.OnlineKindDiv == 10
                                    &&
                                searchRet.CustomerEpCode.Trim() == smplInqbas.EnterpriseCode.Trim()
                                    &&
                                searchRet.SimplInqAcntAcntGrId.Trim() == simpInqAcntGrId.Trim()
                            )
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );
                    if (foundCustomer != null) return foundCustomer;
                }   // foreach (string simpInqAcntGrId in simplInqAcntGrIdList)
            }   // if (smpInqBasExt != null)

            #endregion // ��ƃR�[�h + �A�J�E���g�O���[�vID�œ��Ӑ�����i���Y���Ȃ��̏ꍇ�A��ƃR�[�h�݂̂œ��聫�j
            // ADD 2010/06/26 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<

            #region ��ƃR�[�h�݂̂œ��Ӑ�����

            CustomerSearchRet ret = custList.Find(
                delegate(CustomerSearchRet searchRet)
                {
                    // ADD 2010/06/26 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
                    // null�`�F�b�N
                    if (searchRet == null) return false;
                    if (string.IsNullOrEmpty(searchRet.CustomerEpCode))
                    {
                        searchRet.CustomerEpCode = string.Empty;
                    }

                    // ��ƃR�[�h��0�l16���œ���
                    searchRet.CustomerEpCode = searchRet.CustomerEpCode.Trim().PadLeft(16, '0');
                    // ADD 2010/06/26 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<

                    if (searchRet.OnlineKindDiv == 10 &&
                        searchRet.CustomerEpCode.Trim() == smplInqbas.EnterpriseCode.Trim()
                        // TODO:�{���͋��_�܂œ��Ă遨2010/06/26 �ȒP�⍇���A�J�E���g�O���[�vID�œ��Ă遪
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            #endregion // ��ƃR�[�h�݂̂œ��Ӑ�����

            return ret;
        }

        /// <summary>
        /// �ȒP�⍇���A�J�E���g���̎擾
        /// </summary>
        /// <param name="acntId">�A�J�E���gID</param>
        /// <returns></returns>
        private SmplInqBas GetSmplInqBas(string acntId)
        {
            if (this._simplInqIDExchangeAcs == null) this._simplInqIDExchangeAcs= new SimplInqIDExchangeAcs();

            SmplInqInf inf;
            SmplInqBas bas;
            List<SmplInqChg> chgList;
            string msg;
            int status = this._simplInqIDExchangeAcs.SearchRelatedSmplInqInf(acntId, out inf, out bas, out chgList, out msg);

            return bas;
        }
        
        /// <summary>
        /// CTI��ʋN��
        /// </summary>
        /// <param name="customerCode"></param>
        private void ExecuteCTI(int customerCode)
        {
            // 2011/03/04 >>>
            //string programPath = Path.Combine(Directory.GetCurrentDirectory(), "PMSCM00100U.EXE");
            //if (!File.Exists(programPath)) return;

            //// ���O�C���p�����[�^����ݒ�
            //StringBuilder arguments = new StringBuilder();
            //{
            //    foreach (string argument in CommandLineArgs)
            //    {
            //        if (!string.IsNullOrEmpty(argument.Trim()))
            //        {
            //            arguments.Append(argument + " ");
            //        }
            //    }
            //}

            //arguments.Append("/Customer," + customerCode.ToString());

            //Process.Start(programPath, arguments.ToString());

            CmtLocalSetAcs cmtLocalSetAcs = new CmtLocalSetAcs();
            CmtLocalSet localSet = cmtLocalSetAcs.ReadScmLocalSet();
            if (localSet == null) localSet = this._cmtLocalSet;
            if (localSet.CTIMode <= 0) return;

            string programPath = Path.Combine(Directory.GetCurrentDirectory(), ( localSet.CTIMode == 1 ) ? CTI_EXE_NAME : SALESSLIPINPUT_EXE_NAME);
            if (!File.Exists(programPath)) return;

            // ���O�C���p�����[�^����ݒ�
            StringBuilder arguments = new StringBuilder();
            {
                foreach (string argument in CommandLineArgs)
                {
                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        arguments.Append(argument + " ");
                    }
                }
            }

            switch (localSet.CTIMode)
            {
                case 1:
                    arguments.Append("/Customer," + customerCode.ToString());
                    break;
                case 2:
                    arguments.Append("/CTI ");
                    arguments.Append(customerCode.ToString());
                    break;
                default:
                    break;
            }
            

            Process.Start(programPath, arguments.ToString());

            // 2011/03/04 <<<
        }

        //>>>2010/07/30
        /// <summary>
        /// �N���p�����[�^�擾����(�G���g�����C����ʂŃf���Q�[�g�Ŏg�p)
        /// </summary>
        /// <param name="param"></param>
        private void GetStartParameter(out string param)
        {
            if (this._commandLineArgs.Length != 0)
            {
                param = this._commandLineArgs[0] + " " + this._commandLineArgs[1];
            }
            else
            {
                param = string.Empty;
            }
        }
        //<<<2010/07/30
        #endregion

        #region ���O

        /// <summary>
        /// ���O������
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="msg"></param>
        private static void WriteLog(string methodName, string msg)
        {
            System.IO.FileStream _fs = null;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw = null;										// �X�g���[��writer
            string dir = System.IO.Directory.GetCurrentDirectory();
            dir = Path.Combine(dir, @"log\SimpleInquiryConnect");

            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                _fs = new FileStream(Path.Combine(dir, string.Format(ctLogName, DateTime.Now.ToString("yyyyMMdd"))), FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));

                DateTime edt = DateTime.Now;
                _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2},{3}", edt, edt.Millisecond, methodName, msg));
            }
            catch
            {
            }
            finally
            {
                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
        }

        #endregion
    }
}
