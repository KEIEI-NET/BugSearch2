//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ψꗗ�\
// �v���O�����T�v   : ��`���ψꗗ�\���𒊏o���A����EPDF�o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.Misc;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��`���ψꗗ�\ ���̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ψꗗ�\PDF�o�͑�����s���N���X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public partial class PMTEG02200UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// ���[����(�������̓^�C�v)�t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02200UA()
        {
            InitializeComponent();
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._employeeAcs = new EmployeeAcs();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

        }
        #endregion �� Constructor

        #region �� Const Memebers ��
        /// <summary>������</summary>
        private const string STR_DEPOSITDATE = "������";
        /// <summary>�x����</summary>
        private const string STR_PAYMENTDATE = "�x����";
        /// <summary>�`�F�b�N�����b�Z�[�W�u���㌎�������擾�̏��������ŃG���[���������܂����B�v</summary>
        private const string MSG_TOTALDAYREC_INITIALIE_FAILED = "���㌎�������擾�̏��������ŃG���[���������܂����B";
        /// <summary>�`�F�b�N�����b�Z�[�W�u�d�����������擾�̏��������ŃG���[���������܂����B�v</summary>
        private const string MSG_TOTALDAYPAY_INITIALIE_FAILED = "�d�����������擾�̏��������ŃG���[���������܂����B";
        #endregion �� Const Memebers ��

        #region �� Private Member
        #region �� Interface member

        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;

        //// �I����`��ʃ��X�g
        //private Hashtable _selectedDraftKindList = new Hashtable();
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = string.Empty;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private TegataKessaiReport _tegataKessaiReport;

        // �K�C�h�n�A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs;

        //���t�擾���i
        private DateGetAcs _dateGet;

        // �t�H�[�J�XControl
        private Control _prevControl = null;

        // �`�F�b�N�G���[
        private bool hasCheckError = false;

        // ��s/�x�X�K�C�h����OK�t���O
        private bool _bankBranchGuideOK;

        // ��s/�x�X�K�C�h�p
        private UltraButton _bankBranchGuideSender;

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		// �N���XID
        private const string ct_ClassID = "PMTEG02200UA";
		// �v���O����ID
        private const string ct_PGID = "PMTEG02200U";
		//// ���[����
        private const string PDF_PRINT_NAME1 = "����`���ψꗗ�\";
        private const string PDF_PRINT_NAME2 = "�x����`���ψꗗ�\";
		private string _printName = string.Empty;
        // ���[�L�[	
        private const string PDF_PRINT_KEY = "bf814cb3-97d8-4836-a2bd-618e232b300f";
        
		private string _printKey = PDF_PRINT_KEY;
		#endregion �� Interface member
        #endregion Private Const

        #region �� IPrintConditionInpType �����o

        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^�����</summary>
        /// <value>CanExtract</value>               
        /// <remarks>���o�{�^����Ԏ擾�v���p�e�B </remarks> 
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^�����</summary>
        /// <value>CanPdf</value>               
        /// <remarks>PDF�o�̓{�^����Ԏ擾�v���p�e�B </remarks> 
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^�����</summary>
        /// <value>CanPrint</value>               
        /// <remarks>����{�^����Ԏ擾�v���p�e�B </remarks> 
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B</summary>
        /// <value>VisibledExtractButton</value>               
        /// <remarks>���o�{�^���\���L���擾�v���p�e�B </remarks> 
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L��</summary>
        /// <value>CanPrint</value>               
        /// <remarks>PDF�o�̓{�^���\���L���v���p�e�B�擾�v���p�e�B </remarks> 
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\��</summary>
        /// <value>VisibledPrintButton</value>               
        /// <remarks>����{�^���\���擾�v���p�e�B </remarks> 
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }
        
        #endregion �� Public Property

        #region �� Public Method

        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note		: ���o�������s���B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;
            string errMessage = "";
            Control errComponent = null;
            
            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                // �t�H�[�J�X�A�E�g����
                if (this._prevControl != null)
                {
                    hasCheckError = false;
                    ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                    this.tArrowKeyControl1_ChangeFocus(this, e);
                }
                if (hasCheckError)
                {
                    status = false;
                }

                status = false;
            }
            return status;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public int Print(ref object parameter)
        {

            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "��`���ψꗗ�\�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }
            // ���[�I���K�C�h
            SFCMN06001U printDialog = new SFCMN06001U();
            // ������p�����[�^
            SFCMN06002C printInfo = parameter as SFCMN06002C;	

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            // �N��PGID
            printInfo.kidopgid = ct_PGID;				

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            if (this._tegataKessaiReport.DraftDivide == 0)
                this._printName = PDF_PRINT_NAME1;
            else
                this._printName = PDF_PRINT_NAME2;
            printInfo.prpnm = this._printName;

            // �l�e���v���[�g�̑I��
            if (this._tegataKessaiReport.DraftDivide == 0)
            {
                if (this._tegataKessaiReport.SortOrder == 0)
                    printInfo.PrintPaperSetCd = 0;
                else
                    printInfo.PrintPaperSetCd = 1;
            }
            else
            {
                if (this._tegataKessaiReport.SortOrder == 0)
                    printInfo.PrintPaperSetCd = 3;
                else
                    printInfo.PrintPaperSetCd = 4;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._tegataKessaiReport;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
            }
            
            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._tegataKessaiReport = new TegataKessaiReport();
            this.Show();

            return;
        }
        #endregion

        #endregion �� Public Method

        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return _printName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� Control Event
        #region �� PMTEG02200UA
        #region �� PMTEG02200UA_Load Event
        /// <summary>
        /// PMTEG02200UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void PMTEG02200UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();
            // ��ʃX�L���ύX		
            this._controlScreenSkin.SettingScreenSkin(this);		
            // �c�[���o�[�{�^���ݒ�C�x���g�N�� 
            ParentToolbarSettingEvent(this);						    
            // �������t�H�[�J�X
            this.Cursor = Cursors.WaitCursor;
            // �d���x���Ǘ��I�v�V����(*1)�ɂ��A�����t�H�[�J�X�ʒu��ύX����
            int option = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            // ���|�L�̏ꍇ�A�����t�H�[�J�X�� ��`�敪�Ƃ���B
            if (0 < option)
            {
                this.tComboEditor_DraftDivide.Focus();
                _prevControl = tComboEditor_DraftDivide;
            }
            // ���|���̏ꍇ�A�����t�H�[�J�X�� �������Ƃ��A��`�敪�͓��͕s�i�O���[�A�E�g�j�Ƃ���B
            else
            {
                this.tDateEdit_DepositDate_St.Focus();
                _prevControl = tDateEdit_DepositDate_St;
                this.tComboEditor_DraftDivide.Enabled = false;
            }

            this.Cursor = Cursors.Default;

        }
        #endregion

        #region �� tArrowKeyControl1
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ȃ�</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tComboEditor_DraftDivide)
                    {
                        // ��`�敪��������(�J�n)
                        e.NextCtrl = this.tDateEdit_DepositDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_St)
                    {
                        // ������(�J�n)��������(�I��)
                        e.NextCtrl = this.tDateEdit_DepositDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_Ed)
                    {
                        // ������(�I��)���������i�J�n�j
                        e.NextCtrl = this.tDateEdit_MaturityDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_MaturityDate_St)
                    {
                        // �������i�J�n�j���������i�I���j
                        e.NextCtrl = this.tDateEdit_MaturityDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_MaturityDate_Ed)
                    {
                        // �������i�I���j���o�͏�
                        e.NextCtrl = this.tComboEditor_Sort;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Sort)
                    {
                        // �o�͏�����s�R�[�h�J�n
                        e.NextCtrl = this.tNedit_BankCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BankCd_St)
                    {
                        // ��s�R�[�h�J�n���x�X�R�[�h�J�n
                        e.NextCtrl = this.tNedit_BranchCd_St;

                    }
                    else if (e.PrevCtrl == this.tNedit_BranchCd_St)
                    {
                        // �x�X�R�[�h�J�n����s�K�C�h�J�n
                        e.NextCtrl = this.ub_St_BankBranchCd;

                    }
                    else if (e.PrevCtrl == this.ub_St_BankBranchCd)
                    {
                        // �x�X�R�[�h�J�n����s�R�[�h�I��
                        e.NextCtrl = this.tNedit_BankCd_Ed;

                    }
                    else if (e.PrevCtrl == this.tNedit_BankCd_Ed)
                    {
                        // ��s�R�[�h�I�����x�X�R�[�h�I��
                        e.NextCtrl = this.tNedit_BranchCd_Ed;

                    }
                    else if (e.PrevCtrl == this.tNedit_BranchCd_Ed)
                    {
                        // �x�X�R�[�h�I������s�K�C�h�I��
                        e.NextCtrl = this.ub_Ed_BankBranchCd;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.ub_Ed_BankBranchCd)
                    {
                        // ��s�K�C�h�I�����x�X�R�[�h�I��
                        e.NextCtrl = this.tNedit_BranchCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BranchCd_Ed)
                    {
                        // �x�X�R�[�h�I������s�R�[�h�I��
                        e.NextCtrl = this.tNedit_BankCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BankCd_Ed)
                    {
                        // ��s�R�[�h�I������s�K�C�h�J�n
                        e.NextCtrl = this.ub_St_BankBranchCd;
                    }
                    else if (e.PrevCtrl == this.ub_St_BankBranchCd)
                    {
                        // ��s�K�C�h�J�n���x�X�R�[�h�J�n
                        e.NextCtrl = this.tNedit_BranchCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BranchCd_St)
                    {
                        //�x�X�R�[�h�J�n����s�R�[�h�J�n
                        e.NextCtrl = this.tNedit_BankCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BankCd_St)
                    {
                        // ��s�R�[�h�J�n���o�͏�
                        e.NextCtrl = this.tComboEditor_Sort;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Sort)
                    {
                        // �o�͏����������i�I���j
                        e.NextCtrl = this.tDateEdit_MaturityDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_MaturityDate_Ed)
                    {
                        // �������i�I���j���������i�J�n�j
                        e.NextCtrl = this.tDateEdit_MaturityDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_MaturityDate_St)
                    {
                        // �������i�J�n�j��������(�I��)
                        e.NextCtrl = this.tDateEdit_DepositDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_Ed)
                    {
                        // ������(�I��)��������(�J�n)
                        e.NextCtrl = this.tDateEdit_DepositDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_St)
                    {
                        // ������(�J�n)����`�敪
                        e.NextCtrl = this.tComboEditor_DraftDivide;
                    }

                }
            }
        }
        #endregion

        #endregion �� PMTEG02200UA

        # region �� �K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// ��s/�x�X�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : ��s/�x�X�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ���R</br>                                  
        /// <br>Date       : 2010.05.05</br> 
        /// </remarks>
        private void ub_St_BankBranchCd_Click(object sender, EventArgs e)
        {
            _bankBranchGuideOK = false;

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _bankBranchGuideSender = (UltraButton)sender;
            }
     
            this.SearchForm_BankBranchSelect(_bankBranchGuideSender);

            if (_bankBranchGuideOK)
            {
                if (sender == ub_St_BankBranchCd)
                {
                    this.tNedit_BranchCd_Ed.Focus();
                }
            }
        }

        /// <summary>
        /// �d����K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <remarks> 
        /// <br>Note       : �d����K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ���R</br>                                  
        /// <br>Date       : 2010.05.05</br> 
        /// </remarks>
        private void SearchForm_BankBranchSelect(object sender)
        {
            // �K�C�h�N��
            UserGdHd userGdHd;
            UserGdBd userGdBd;
            UserGuideAcs userGuideAcs = new UserGuideAcs();

            int status = userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 46);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;
            // ���ڂɓW�J
            if (_bankBranchGuideSender == this.ub_St_BankBranchCd)
            {
                this.tNedit_BankCd_St.SetInt(userGdBd.GuideCode / 1000);
                this.tNedit_BranchCd_St.SetInt(userGdBd.GuideCode % 1000);
            }
            else
            {
                this.tNedit_BankCd_Ed.SetInt(userGdBd.GuideCode / 1000);
                this.tNedit_BranchCd_Ed.SetInt(userGdBd.GuideCode % 1000);
            }

            _bankBranchGuideOK = true;
        }
        #endregion �� �K�C�h�{�^���N���b�N�C�x���g

        /// <summary>
        /// tComboEditor_DraftDivide_ValueChanged �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��`�敪�ύX�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���R</br>                                  
        /// <br>Date       : 2010.05.05</br> 
        /// </remarks> 
        private void tComboEditor_DraftDivide_ValueChanged(object sender, EventArgs e)
        {

            // �E��`�敪���u����`�v�̎��@�F�@�o�͏��̑I�����ڂɂ�����t���ڂ��u�������v�ɕύX����B
            if ((int)this.tComboEditor_DraftDivide.SelectedIndex == 0)
            {
                this.tComboEditor_Sort.Items.Clear();
                this.tComboEditor_Sort.Items.Add(0, "��s/�x�X�{�������{������");
                this.tComboEditor_Sort.Items.Add(1, "�������{��s/�x�X�{������");
                this.tComboEditor_Sort.SelectedIndex = 0;
                // ��`�敪�u����`�v��I�����́A���t���ڂ̃^�C�g�����u�������v�ɕύX����B
                this.Lbl_DepositDate.Text = STR_DEPOSITDATE;
            }
            // �E��`�敪���u�x����`�v�̎��@�F�@�o�͏��̑I�����ڂɂ�����t���ڂ��u�x�����v�ɕύX����B
            else
            {
                this.tComboEditor_Sort.Items.Clear();
                this.tComboEditor_Sort.Items.Add(0, "��s/�x�X�{�x�����{������");
                this.tComboEditor_Sort.Items.Add(1, "�������{��s/�x�X�{�x����");
                this.tComboEditor_Sort.SelectedIndex = 0;
                // ��`�敪�u�x����`�v��I�����́A���t���ڂ̃^�C�g�����u�x�����v�ɕύX����B
                this.Lbl_DepositDate.Text = STR_PAYMENTDATE;
            }

            //�J�n�������ƊJ�n�������擾��������
            GetHisTotalDayProc();
        }
        
        #endregion �� Control Event

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            
            try
            {
                // ��`�敪
                this.tComboEditor_DraftDivide.Items.Clear();
                this.tComboEditor_DraftDivide.Items.Add(0, "����`");
                this.tComboEditor_DraftDivide.Items.Add(1, "�x����`");

                // ������
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();

                // ������(�J�n)�Ɩ�����(�J�n)�擾��������
                GetHisTotalDayProc();

                // ������(�I��)��ݒ�F�V�X�e�����t
                this.tDateEdit_DepositDate_Ed.SetDateTime(DateTime.Now);
                // ������(�I��)��ݒ�F�V�X�e�����t
                this.tDateEdit_MaturityDate_Ed.SetDateTime(DateTime.Now);

                // �o�͏�
                if (this.tComboEditor_Sort.Value == null)
                {
                    this.tComboEditor_Sort.Value = 0;   // DEF:0:�u��s/�x�X�{�������{�������v
                }
                // ��`�敪
                if (this.tComboEditor_DraftDivide.Value == null)
                {
                    this.tComboEditor_DraftDivide.Value = 0;   // DEF:0:����`
                }

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_BankBranchCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BankBranchCd, Size16_Index.STAR1);

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput(); 

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
           
            return status;
        }

        #region �� �O�񌎎��X�V���擾�������� ��
        /// <summary>
        /// �J�n�������ƊJ�n�������擾��������
        /// </summary>
        /// <returns>�V�X�e�����t</returns>
        /// <remarks>
        /// <br>Note       : �������Ɩ������擾���������ł��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void GetHisTotalDayProc()
        {
            int status;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            //�O�񌎎��X�V��
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            // �O�񌎎��X�V���擾�O��������
            status = totalDayCalculator.InitializeHisMonthlyAccRec();

            int billDivIndex = this.tComboEditor_DraftDivide.SelectedIndex;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���񂨂�ёO��̒��ߓ�/�����擾(���Ɠ��͈قȂ�ꍇ������)
                //����`
                if (billDivIndex == 0)
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }
                else
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccPay(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }

                if (prevTotalDay == DateTime.MinValue)
                {

                    // ������(�J�n)��ݒ�F�V�X�e�����t
                    this.tDateEdit_DepositDate_St.SetDateTime(DateTime.Now);
                    // ������(�J�n)��ݒ�F�V�X�e�����t
                    this.tDateEdit_MaturityDate_St.SetDateTime(DateTime.Now);
                }
                else
                {
                    // ���㍡�񌎎��X�V����ݒ�
                    // ������(�J�n)��ݒ�F�O�񌎎��X�V���̗���
                    this.tDateEdit_DepositDate_St.SetDateTime(prevTotalDay.AddDays(1));
                    // ������(�J�n)��ݒ�F�O�񌎎��X�V���̗���
                    this.tDateEdit_MaturityDate_St.SetDateTime(prevTotalDay.AddDays(1));
                }
            }
            else
            {
                // �����������s
                // ����`
                if (billDivIndex == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYREC_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYPAY_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
            }
        }
        #endregion
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R����ݒ肷��</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
            const string ct_InputError = "�̓��͂��s���ł��B";

            bool status = true;
            string dateStr = null;
            // ����`
            if (this.tComboEditor_DraftDivide.SelectedIndex == 0)
                dateStr = STR_DEPOSITDATE;
            // �x����`
            else
                dateStr = STR_PAYMENTDATE;

            // ������/�x����
            if ((this.tDateEdit_DepositDate_St.LongDate != 0) && this.tDateEdit_DepositDate_St.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("�J�n��{0}", ct_InputError);
                errComponent = this.tDateEdit_DepositDate_St;
                status = false;
            }
            else if ((this.tDateEdit_DepositDate_Ed.LongDate != 0) && this.tDateEdit_DepositDate_Ed.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("�I����{0}", ct_InputError);
                errComponent = this.tDateEdit_DepositDate_Ed;
                status = false;
            }
            else if (this.tDateEdit_DepositDate_St.LongDate != 0 && this.tDateEdit_DepositDate_Ed.LongDate != 0 &&
                !DateGetAcs.CheckDateRangeResult.OK.Equals(this._dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref this.tDateEdit_DepositDate_St, ref this.tDateEdit_DepositDate_Ed, false)))
            {

                errMessage = string.Format(dateStr + "{0}", ct_RangeError);
                errComponent = this.tDateEdit_DepositDate_Ed;
                status = false;
            }
            // ������
            else if ((this.tDateEdit_MaturityDate_St.LongDate != 0) && this.tDateEdit_MaturityDate_St.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("�J�n��{0}", ct_InputError);
                errComponent = this.tDateEdit_MaturityDate_St;
                status = false;
            }
            else if ((this.tDateEdit_MaturityDate_Ed.LongDate != 0) && this.tDateEdit_MaturityDate_Ed.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("�I����{0}", ct_InputError);
                errComponent = this.tDateEdit_MaturityDate_Ed;
                status = false;
            }
            else if (
                this.tDateEdit_MaturityDate_St.LongDate != 0 &&
                this.tDateEdit_MaturityDate_Ed.LongDate != 0 &&
                !DateGetAcs.CheckDateRangeResult.OK.Equals(this._dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref this.tDateEdit_MaturityDate_St, ref this.tDateEdit_MaturityDate_Ed, false)))
            {
                errMessage = string.Format("������{0}", ct_RangeError);
                errComponent = this.tDateEdit_MaturityDate_Ed;
                status = false;
            }
            // ��s/�x�X
            else
            {
                int bankCdSt = this.tNedit_BankCd_St.GetInt() * 1000;
                int branchCdSt = this.tNedit_BranchCd_St.GetInt();
                int bankCdEnd;
                int branchCdEnd;
                if (this.tNedit_BankCd_Ed.DataText.TrimEnd() != string.Empty)
                    bankCdEnd = this.tNedit_BankCd_Ed.GetInt() * 1000;
                else
                    bankCdEnd = 9999000;

                if (this.tNedit_BranchCd_Ed.DataText.TrimEnd() != string.Empty)
                    branchCdEnd = this.tNedit_BranchCd_Ed.GetInt();
                else
                    branchCdEnd = 999;

                if (bankCdSt + branchCdSt > bankCdEnd + branchCdEnd)
                {
                    errMessage = string.Format("��s/�x�X{0}", ct_RangeError);
                    if (bankCdSt > bankCdEnd)
                        errComponent = this.tNedit_BankCd_Ed;
                    else
                        errComponent = this.tNedit_BranchCd_Ed;
                    status = false;
                }
            }
            return status;
        }

        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                this._tegataKessaiReport.EnterpriseCode = this._enterpriseCode;
                // ������
                this._tegataKessaiReport.DateSt = this.tDateEdit_DepositDate_St.GetDateTime();
                this._tegataKessaiReport.DateEd = this.tDateEdit_DepositDate_Ed.GetDateTime();

                // ������
                this._tegataKessaiReport.MaturityDateSt = this.tDateEdit_MaturityDate_St.GetDateTime();
                this._tegataKessaiReport.MaturityDateEd = this.tDateEdit_MaturityDate_Ed.GetDateTime();

                //��`�敪
                this._tegataKessaiReport.DraftDivide = Convert.ToInt32(this.tComboEditor_DraftDivide.Value);

                // �\�[�g��
                this._tegataKessaiReport.SortOrder = Convert.ToInt32(this.tComboEditor_Sort.Value);

                // ��s/�x�X�J�n
                if (this.tNedit_BankCd_St.Text == "" && this.tNedit_BranchCd_St.Text == "")
                {
                    this._tegataKessaiReport.BankAndBranchCdSt = string.Empty;
                }
                else
                {
                    this._tegataKessaiReport.BankAndBranchCdSt = (this.tNedit_BankCd_St.GetInt() * 1000 + this.tNedit_BranchCd_St.GetInt()).ToString("D7");
                }

                // ��s/�x�X�I��
                if (this.tNedit_BankCd_Ed.Text == "" && this.tNedit_BranchCd_Ed.Text == "")
                    this._tegataKessaiReport.BankAndBranchCdEd = string.Empty;
                else if (this.tNedit_BankCd_Ed.Text != "" && this.tNedit_BranchCd_Ed.Text != "")
                    this._tegataKessaiReport.BankAndBranchCdEd = (this.tNedit_BankCd_Ed.GetInt() * 1000 + this.tNedit_BranchCd_Ed.GetInt()).ToString("D7");
                else if (this.tNedit_BankCd_Ed.Text != "")
                    this._tegataKessaiReport.BankAndBranchCdEd = (this.tNedit_BankCd_Ed.GetInt() * 1000 + 999).ToString("D7");
                else
                    this._tegataKessaiReport.BankAndBranchCdEd = (9999 * 1000 + this.tNedit_BranchCd_Ed.GetInt()).ToString("D7");

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
            
        }

        #endregion
        #endregion �� ����O����

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        /// <summary>
        /// �O���[�v���k���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param> 
        /// <remarks> 
        /// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br> 
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "SortGroup") || 
                (e.Group.Key == "PrintConditionGroup"))
            {
                // �O���[�v�̏k�����L�����Z�� 
                e.Cancel = true;
            }

        }
        
        /// <summary> 
        /// �G�N�X�v���[���[�o�[ �O���[�v�W�J �C�x���g 
        /// </summary> 
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param> 
        /// <param name="e">�C�x���g���</param> 
        /// <remarks> 
        /// <br>Note       : �O���[�v���W�J�����O�ɔ������܂��B</br> 
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "SortGroup") || 
                (e.Group.Key == "PrintConditionGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        #region �� �I�t���C����ԃ`�F�b�N����

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note		: ���O�I�����I�����C����ԃ`�F�b�N�������s��</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2010.05.05</br>
        /// </remarks>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note		: �����[�g�ڑ��\������s��</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2010.05.05</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        /// <summary>
        /// UI�ۑ��R���|�[�l���g�Ǎ��݃C�x���g
        /// </summary>
        /// <param name="targetControls">�Ώ�Control</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	�@ : UI�ۑ��R���|�[�l���g�Ǎ��݃C�x���g���s��</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0 && customizeData.Length == 5)
            {
                // ��`�敪
                if (customizeData[0] == "0")
                {
                    this.tComboEditor_DraftDivide.Value = 0;

                }
                else if (customizeData[0] == "1")
                {
                    this.tComboEditor_DraftDivide.Value = 1;
                }
                // �o�͏�
                if (customizeData[1] == "0")
                {
                    this.tComboEditor_Sort.Value = 0;
                }
                else
                {
                    this.tComboEditor_Sort.Value = 1;
                }

                // ��s/�x�X
                this.tNedit_BankCd_St.DataText = customizeData[2];
                this.tNedit_BranchCd_St.DataText = customizeData[3];
                this.tNedit_BankCd_Ed.DataText = customizeData[4];
                this.tNedit_BranchCd_Ed.DataText = customizeData[5];
            }
        }

        /// <summary>
        /// UI�ۑ��R���|�[�l���g�����݃C�x���g
        /// </summary>
        /// <param name="targetControls">�Ώ�Control</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	�@ : UI�ۑ��R���|�[�l���g�����݃C�x���g���s��</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[6];
            // ��`�敪
            if (tComboEditor_DraftDivide.SelectedIndex == 0)
            {
                customizeData[0] = "0";
            }
            else if (tComboEditor_DraftDivide.SelectedIndex == 1)
            {
                customizeData[0] = "1";
            }   
            // �o�͏�
            if (tComboEditor_Sort.SelectedIndex == 0)
            {
               customizeData[1] = "0";
            }
            else
            {
                customizeData[1] = "1";
            }
            
�@�@�@�@�@�@// ��s/�x�X
            customizeData[2] = this.tNedit_BankCd_St.DataText;
            customizeData[3] = this.tNedit_BranchCd_St.DataText;
            customizeData[4] = this.tNedit_BankCd_Ed.DataText;
            customizeData[5] = this.tNedit_BranchCd_Ed.DataText;
        }
        #endregion �� Private Method

    }
}