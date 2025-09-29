//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ʗ\��\
// �v���O�����T�v   : ��`���ʗ\��\���𒊏o���A����EPDF�o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
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
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��`���ʗ\��\ ���̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ʗ\��\PDF�o�͑�����s���N���X�ł��B</br>
    /// <br>Programmer : �I�M</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public partial class PMTEG02400UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// ���[����(�������̓^�C�v)�t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02400UA()
        {
            InitializeComponent();
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._employeeAcs = new EmployeeAcs();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

        }
        #endregion �� Constructor

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

		// �I����`��ʃ��X�g
		private SortedList _selectedDraftKindList = new SortedList();
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = string.Empty;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private TegataTsukibetsuYoteListReport _tegataTsukibetsuYoteListReport;

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

		// ��`��ʃ`�F�b�N���f�p
		private bool _checkFlag = false;

        // ����͈͔N��Clone
        private string _thisYearMonthClone;

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		// �N���XID
        private const string ct_ClassID = "PMTEG02400UA";
		// �v���O����ID
        private const string ct_PGID = "PMTEG02400U";
		//// ���[����
        private const string PDF_PRINT_NAME1 = "����`���ʗ\��\";
        private const string PDF_PRINT_NAME2 = "�x����`���ʗ\��\";
		private string _printName = string.Empty;
        // ���[�L�[	
		private const string PDF_PRINT_KEY = "1edbf5b6-78b7-436c-852d-65aec83d680e";
        
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
        /// <br>Programmer  : �I�M</br>
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
        /// <br>Programmer  : �I�M</br>
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
        /// <br>Programmer  : �I�M</br>
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
                    "��`���ʗ\��\�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

			// ��ƃR�[�h���Z�b�g
			printInfo.enterpriseCode = this._enterpriseCode;
			printInfo.kidopgid = ct_PGID;				// �N��PGID

			// PDF�o�͗���p
			printInfo.key = this._printKey;
			if (this._tegataTsukibetsuYoteListReport.DraftDivide == 0)
			{
				this._printName = PDF_PRINT_NAME1;
				if (this._tegataTsukibetsuYoteListReport.SortOrder == 0)
				{
					printInfo.PrintPaperSetCd = 0;
				}
				else
				{
					printInfo.PrintPaperSetCd = 2;
				}
			}
			else
			{
				this._printName = PDF_PRINT_NAME2;
				if (this._tegataTsukibetsuYoteListReport.SortOrder == 0)
				{
					printInfo.PrintPaperSetCd = 1;
				}
				else
				{
					printInfo.PrintPaperSetCd = 3;
				}
			}
			printInfo.prpnm = this._printName;
			// ���o�����̐ݒ�
			printInfo.jyoken = this._tegataTsukibetsuYoteListReport;
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
        /// <br>Programmer  : �I�M</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._tegataTsukibetsuYoteListReport = new TegataTsukibetsuYoteListReport();

            // �����^�`�F�b�N
            //int result = 0;
            this.Show();

            return;
        }
        #endregion

        #region �� �����I���v�㋒�_�ݒ菈��( ������ )
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer  : �I�M</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #region �� �������_�I��\���`�F�b�N����
        /// <summary>
        /// �������_�I��\���`�F�b�N����
        /// </summary>
        /// <param name="isDefaultState">true�F�X���C�_�[�\���@false�F�X���C�_�[��\��</param>
        /// <remarks>
        /// <br>Note		: ���_�I���X���C�_�[�̕\���L���𔻒肷��B</br>
        /// <br>			: ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���B</br>
        /// <br>Programmer  : �I�M</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region �� �v�㋒�_�I������( ������ )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer  : �I�M</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypeSelectedSection �����o

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
        #region �� PMTEG02400UA
        #region �� PMTEG02400UA_Load Event
        /// <summary>
        /// PMTEG02400UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : �I�M</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void PMTEG02400UA_Load(object sender, EventArgs e)
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
            // ���|���̏ꍇ�A�����t�H�[�J�X�� ����͈͔N���Ƃ��A��`�敪�͓��͕s�i�O���[�A�E�g�j�Ƃ���B
            else
            {
                this.tDateEdit_YearMonth.Focus();
                _prevControl = tDateEdit_YearMonth;
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
        /// <br>Programmer  : �I�M</br>
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
                        // ��`�敪������͈͔N��
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
						// ����͈͔N��������
						e.NextCtrl = this.tComboEditor_ChangePg;
                    }
					else if (e.PrevCtrl == this.tComboEditor_ChangePg)
					{
						// ���Ł��o�͏�
						e.NextCtrl = this.tComboEditor_Sort;
					}
					else if (e.PrevCtrl == this.tComboEditor_Sort)
					{
						// �o�͏�����s�R�[�h�J�n
						e.NextCtrl = this.tNedit_BankCd_St;
					}
					else if (e.PrevCtrl == this.tNedit_BankCd_St)
					{
						tNedit_BankCd_St_AfterExitEditMode(e.PrevCtrl, null);
						// ��s�R�[�h�J�n���x�X�R�[�h�J�n
						e.NextCtrl = this.tNedit_BranchCd_St;

					}
					else if (e.PrevCtrl == this.tNedit_BranchCd_St)
					{
						tNedit_BranchCd_St_AfterExitEditMode(e.PrevCtrl, null);
						// �x�X�R�[�h�J�n����s/�x�X�R�[�h�J�n�K�C�h�{�^��
						e.NextCtrl = this.ub_St_BankBranchCd;
					}
					else if (e.PrevCtrl == this.ub_St_BankBranchCd)
					{
						// ��s/�x�X�R�[�h�J�n�K�C�h�{�^������s�R�[�h�I��
						e.NextCtrl = this.tNedit_BankCd_Ed;

					}
					else if (e.PrevCtrl == this.tNedit_BankCd_Ed)
					{
						tNedit_BankCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
						// ��s�R�[�h�I�����x�X�R�[�h�I��
						e.NextCtrl = this.tNedit_BranchCd_Ed;

					}
					else if (e.PrevCtrl == this.tNedit_BranchCd_Ed)
					{
						tNedit_BranchCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
						// �x�X�R�[�h�I������s/�x�X�R�[�h�I���K�C�h�{�^��
						e.NextCtrl = this.ub_Ed_BankBranchCd;
					}
					else if (e.PrevCtrl == this.ub_Ed_BankBranchCd)
					{
						// ��s/�x�X�R�[�h�I���K�C�h�{�^������`���
						e.NextCtrl = this.DraftKindCd_ultraTree;

					}
					else if (e.PrevCtrl == this.DraftKindCd_ultraTree)
					{
						// ��`��ʁ���`�敪
						e.NextCtrl = this.tComboEditor_DraftDivide;

					}
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
					if (e.PrevCtrl == this.DraftKindCd_ultraTree)
					{
						// ��`��ʁ���s/�x�X�R�[�h�I���K�C�h�{�^��
						e.NextCtrl = this.ub_Ed_BankBranchCd;
					}
					else if (e.PrevCtrl == this.ub_Ed_BankBranchCd)
					{
						// ��s/�x�X�R�[�h�I���K�C�h�{�^�����x�X�R�[�h�I��
						e.NextCtrl = this.tNedit_BranchCd_Ed;
					}
					else if (e.PrevCtrl == this.tNedit_BranchCd_Ed)
					{
						tNedit_BranchCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
						// �x�X�R�[�h�I������s�R�[�h�I��
						e.NextCtrl = this.tNedit_BankCd_Ed;
					}
					else if (e.PrevCtrl == this.tNedit_BankCd_Ed)
					{
						tNedit_BankCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
						// ��s�R�[�h�I������s/�x�X�R�[�h�J�n�K�C�h�{�^��
						e.NextCtrl = this.ub_St_BankBranchCd;
					}
					else if (e.PrevCtrl == this.ub_St_BankBranchCd)
					{
						// ��s/�x�X�R�[�h�J�n�K�C�h�{�^�����x�X�R�[�h�J�n
						e.NextCtrl = this.tNedit_BranchCd_St;
					}
					else if (e.PrevCtrl == this.tNedit_BranchCd_St)
					{
						tNedit_BranchCd_St_AfterExitEditMode(e.PrevCtrl, null);
						//�x�X�R�[�h�J�n����s�R�[�h�J�n
						e.NextCtrl = this.tNedit_BankCd_St;
					}
					else if (e.PrevCtrl == this.tNedit_BankCd_St)
					{
						tNedit_BankCd_St_AfterExitEditMode(e.PrevCtrl, null);
						// ��s�R�[�h�J�n���o�͏�
						e.NextCtrl = this.tComboEditor_Sort;
					}
					else if (e.PrevCtrl == this.tComboEditor_Sort)
					{
						// �o�͏�������
						e.NextCtrl = this.tComboEditor_ChangePg;
					}
					else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
						// ���Ł�����͈͔N��
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // ����͈͔N������`�敪
                        e.NextCtrl = this.tComboEditor_DraftDivide;
                    }
					else if (e.PrevCtrl == this.tComboEditor_DraftDivide)
					{
						// ��`�敪����`���
						e.NextCtrl = this.DraftKindCd_ultraTree;
					}

                }
            }
        }
        #endregion

        #endregion �� PMTEG02400UA

        # region �� �K�C�h�{�^���N���b�N�C�x���g
		/// <summary>
		/// ��s/�x�X�K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks> 
		/// <br>Note       : ��s/�x�X�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
		/// <br>Programmer  : �I�M</br>
		/// <br>Date        : 2010.05.05</br>
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
					this.ub_St_BankBranchCd.Focus();
				}
				else if (sender == ub_Ed_BankBranchCd)
				{
					this.ub_Ed_BankBranchCd.Focus();
				}
			}
		}

		/// <summary>
		/// ��s/�x�X�K�C�h�I���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <remarks> 
		/// <br>Note       : ��s/�x�X�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
		/// <br>Programmer  : �I�M</br>
		/// <br>Date        : 2010.05.05</br>
		/// </remarks>
		private void SearchForm_BankBranchSelect(object sender)
		{
			// �K�C�h�N��
			UserGdHd userGdHd;
			UserGdBd userGdBd;
			UserGuideAcs userGuideAcs = new UserGuideAcs();

			int status = userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 46);

			if (status != 0) return;
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

		#region �� �t�H�[�J�X�A�E�g
		/// <summary>
		/// AfterExitEditMode �C�x���g�����C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : ��s�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
		/// <br>Programmer : �I�M</br>                                  
		/// <br>Date       : 2010.05.05</br>  
		/// </remarks> 
		private void tNedit_BankCd_St_AfterExitEditMode(object sender, EventArgs e)
		{
			// ��s/�x�X�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
			if (!this.IsInteger(this.tNedit_BankCd_St.Text))
			{
				this.tNedit_BankCd_St.Text = string.Empty;
				hasCheckError = false;
				return;
			}
		}

		/// <summary>
		/// AfterExitEditMode �C�x���g�����C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : ��s�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
		/// <br>Programmer : �I�M</br>                                  
		/// <br>Date       : 2010.05.05</br> 
		/// </remarks> 
		private void tNedit_BankCd_Ed_AfterExitEditMode(object sender, EventArgs e)
		{
			// ��s/�x�X�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
			if (!this.IsInteger(this.tNedit_BankCd_Ed.Text))
			{
				this.tNedit_BankCd_Ed.Text = string.Empty;
				hasCheckError = false;
				return;
			}
		}

		/// <summary>
		/// AfterExitEditMode �C�x���g�����C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : �x�X�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
		/// <br>Programmer : �I�M</br>                                  
		/// <br>Date       : 2010.05.05</br> 
		/// </remarks> 
		private void tNedit_BranchCd_St_AfterExitEditMode(object sender, EventArgs e)
		{
			// ��s/�x�X�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
			if (!this.IsInteger(this.tNedit_BranchCd_St.Text))
			{
				this.tNedit_BranchCd_St.Text = string.Empty;
				hasCheckError = false;
				return;
			}
		}

		/// <summary>
		/// AfterExitEditMode �C�x���g�����C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : �x�X�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
		/// <br>Programmer : �I�M</br>                                  
		/// <br>Date       : 2010.05.05</br> 
		/// </remarks> 
		private void tNedit_BranchCd_Ed_AfterExitEditMode(object sender, EventArgs e)
		{
			// ��s/�x�X�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
			if (!this.IsInteger(this.tNedit_BranchCd_Ed.Text))
			{
				this.tNedit_BranchCd_Ed.Text = string.Empty;
				hasCheckError = false;
				return;
			}
		}
		#endregion �� �t�H�[�J�X�A�E�g

		/// <summary>
		/// AfterCheck �C�x���g�����C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : ��`��ʂ��`�F�b�N���ꂽ�Ƃ��ɔ������܂��B</br>      
		/// <br>Programmer : �I�M</br>                                  
		/// <br>Date       : 2010.05.05</br> 
		/// </remarks> 
		private void DraftKindCd_ultraTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
		{
			// �u�S�āv���N���b�N���ꂽ�Ƃ�
			if (e.TreeNode.Index == 0)
			{
				if (this.DraftKindCd_ultraTree.Nodes[0].CheckedState == CheckState.Checked)
				{
					for (int i = 1; i <= 9; i++)
					{
						if (this.DraftKindCd_ultraTree.Nodes[i].CheckedState == CheckState.Checked)
						{
							_checkFlag = true;
							this.DraftKindCd_ultraTree.Nodes[i].CheckedState = CheckState.Unchecked;
						}
					}
					return;
				}
			}
			else
			{
				if (!_checkFlag && this.DraftKindCd_ultraTree.Nodes[0].CheckedState == CheckState.Checked)
				{
					for (int i = 1; i <= 9; i++)
					{
						if (this.DraftKindCd_ultraTree.Nodes[i].CheckedState == CheckState.Checked)
						{
							this.DraftKindCd_ultraTree.Nodes[0].CheckedState = CheckState.Unchecked;
							break;
						}
					}
					return;
				}
				_checkFlag = false;
			}
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
        /// <br>Programmer  : �I�M</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            
            try
            {
                // ����͈͔N��
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                //�N���x ( ����01 )
                DateTime thisYearMonth;
                //�N�x
                Int32 thisYear;
                //�N���x�J�n��
                DateTime startMonthDate;
                //�N���x�I����
                DateTime endMonthDate;
                //�N�x�J�n��
                DateTime startYearDate;
                //�N�x�I����
                DateTime endYearDate;
                this._dateGet.GetThisYearMonth(out thisYearMonth, out thisYear, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate);
                // ����͈͔N����ݒ�
                this.tDateEdit_YearMonth.SetDateTime(thisYearMonth);
                // �ۑ���������������͈͔N��
                _thisYearMonthClone = tDateEdit_YearMonth.GetDateTime().ToString("yyyyMM");
                // ���y�[�W
                if (this.tComboEditor_ChangePg.Value == null)
                {
					this.tComboEditor_ChangePg.Value = 0;  // DEF�F���v
                }
				// �o�͏�
				if (this.tComboEditor_Sort.Value == null)
				{
					this.tComboEditor_Sort.Value = 0;   // DEF:��`��ʏ�
				}
                // ��`�敪
                if (this.tComboEditor_DraftDivide.Value == null)
                {
                    this.tComboEditor_DraftDivide.Value = 0;   // DEF:����`
                }
				// �u�S�āv�Ƀ`�F�b�N
				this.DraftKindCd_ultraTree.Nodes[0].CheckedState = CheckState.Checked;
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
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R����ݒ肷��</br>
        /// <br>Programmer  : �I�M</br>
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
        /// <br>Programmer  : �I�M</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
		private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
		{
			const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
			const string ct_NoInputError = "����͂��Ă��������B";
			const string ct_InputError = "�̓��͂��s���ł��B";

			bool status = true;
			int longDate = this.tDateEdit_YearMonth.LongDate;
			longDate = (longDate / 100) * 100 + 1;
			this.tDateEdit_YearMonth.SetLongDate(longDate);
			if (this.tDateEdit_YearMonth.GetDateYear() == 0 && this.tDateEdit_YearMonth.GetDateMonth() == 0)
			{
				errMessage = string.Format("����͈͔N��{0}", ct_NoInputError);
				errComponent = this.tDateEdit_YearMonth;
				status = false;
			}
			else if ((this.tDateEdit_YearMonth.LongDate != 0) && this.tDateEdit_YearMonth.GetDateTime() == DateTime.MinValue)
			{
				errMessage = string.Format("����͈͔N��{0}", ct_InputError);
				errComponent = this.tDateEdit_YearMonth;
				status = false;
			}
			// ��s/�x�X
			else if (this.tNedit_BankCd_St.DataText.TrimEnd() != string.Empty
				|| this.tNedit_BankCd_Ed.DataText.TrimEnd() != string.Empty
				|| this.tNedit_BranchCd_St.DataText.TrimEnd() != string.Empty
				|| this.tNedit_BranchCd_Ed.DataText.TrimEnd() != string.Empty)
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
			else if (!IsDraftKindCdSelected())
			{
				errMessage = string.Format("��`���{0}", ct_NoInputError);
				errComponent = this.DraftKindCd_ultraTree;
				status = false;
			}
			return status;
		}

		/// <summary>
		/// ��`��ʂ̂����ꂩ��I������邩
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��`��ʂ̂����ꂩ��I������邩�𔻒肷��</br>
		/// <br>Programmer  : �I�M</br>
		/// <br>Date        : 2010.05.05</br>
		/// </remarks>
		private bool IsDraftKindCdSelected()
		{
			for (int i = 0; i < this.DraftKindCd_ultraTree.Nodes.Count; i++)
			{
				if (this.DraftKindCd_ultraTree.Nodes[i].CheckedState == CheckState.Checked)
				{
					return true;
				}
			}
			return false;
		}
		#endregion

		#region �� ���o�����ݒ菈��(��ʁ����o����)
		/// <summary>
		/// ���o�����ݒ菈��(��ʁ����o����)
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
		/// <br>Programmer  : �I�M</br>
		/// <br>Date        : 2010.05.05</br>
		/// </remarks>
		private int SetExtraInfoFromScreen()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// ��ƃR�[�h
				this._tegataTsukibetsuYoteListReport.EnterpriseCode = this._enterpriseCode;
				//��`�敪
				this._tegataTsukibetsuYoteListReport.DraftDivide = Convert.ToInt32(this.tComboEditor_DraftDivide.Value);
				// ����͈͔N��
				int longDate = this.tDateEdit_YearMonth.LongDate;
				longDate = (longDate / 100) * 100 + 1;
				this.tDateEdit_YearMonth.SetLongDate(longDate);
				this._tegataTsukibetsuYoteListReport.SalesDate = this.tDateEdit_YearMonth.GetDateTime();
				//����
				this._tegataTsukibetsuYoteListReport.ChangePageDiv = Convert.ToInt32(this.tComboEditor_ChangePg.Value);
				// �\�[�g��
				this._tegataTsukibetsuYoteListReport.SortOrder = Convert.ToInt32(this.tComboEditor_Sort.Value);
				// ��s/�x�X�J�n
				if (this.tNedit_BankCd_St.Text == "" && this.tNedit_BranchCd_St.Text == "")
				{
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdSt = string.Empty;
				}
				else
				{
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdSt = (this.tNedit_BankCd_St.GetInt() * 1000 + this.tNedit_BranchCd_St.GetInt()).ToString("D7");
				}
				// ��s/�x�X�I��
				if (this.tNedit_BankCd_Ed.Text == "" && this.tNedit_BranchCd_Ed.Text == "")
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdEd = string.Empty;
				else if (this.tNedit_BankCd_Ed.Text != "" && this.tNedit_BranchCd_Ed.Text != "")
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdEd = (this.tNedit_BankCd_Ed.GetInt() * 1000 + this.tNedit_BranchCd_Ed.GetInt()).ToString("D7");
				else if (this.tNedit_BankCd_Ed.Text != "")
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdEd = (this.tNedit_BankCd_Ed.GetInt() * 1000 + 999).ToString("D7");
				else
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdEd = (9999 * 1000 + this.tNedit_BranchCd_Ed.GetInt()).ToString("D7");
				// ��`���
				// ��`��ʃc���[�ݒ� 
				SetDraftKindCdList(ref _selectedDraftKindList);
				ArrayList secList = new ArrayList();
				if (this.DraftKindCd_ultraTree.Nodes[0].CheckedState == CheckState.Checked)
				{
					_tegataTsukibetsuYoteListReport.DraftKindCds = new string[0];
				}
				else
				{
					foreach (DictionaryEntry dicEntry in this._selectedDraftKindList)
					{
						if ((CheckState)dicEntry.Value == CheckState.Checked)
						{
							secList.Add(dicEntry.Key);
						}
					}
					_tegataTsukibetsuYoteListReport.DraftKindCds = (string[])secList.ToArray(typeof(string));
				}
				// ��`��ʖ��̂̐ݒ�
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt = new Hashtable();
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(0, "�莝��`");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(1, "�旧��`");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(2, "������`");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(3, "���n��`");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(4, "�S�ێ�`");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(5, "�s�n��`");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(6, "�x����`");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(7, "��t��`");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(9, "���ώ�`");


			}
			catch (Exception)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			return status;

		}

		/// <summary>
		/// ��`��ʃ��X�g�̐ݒ�
		/// </summary>
		/// <param name="_selectedDraftKindList">��`��ʃ��X�g</param>
		/// <remarks>
		/// <br>Note       : ��`��ʃ��X�g�̐ݒ���s��</br>
		/// <br>Programmer : �I�M</br>
		/// <br>Date       : 2010.05.05</br>
		/// </remarks>
		private void SetDraftKindCdList(ref SortedList _selectedDraftKindList)
		{
			_selectedDraftKindList.Clear();
			for (int i = 0; i < this.DraftKindCd_ultraTree.Nodes.Count; i++)
			{
				if (this.DraftKindCd_ultraTree.Nodes[i].CheckedState == CheckState.Checked)
				{
					_selectedDraftKindList.Add(DraftKindCd_ultraTree.Nodes[i].Key, CheckState.Checked);
				}

			}
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
        /// <br>Programmer : �I�M</br>
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
        /// <br>Programmer : �I�M</br>
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
        /// <br>Programmer : �I�M</br>
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
        /// <br>Programmer	: �I�M</br>
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
        /// <br>Programmer	: �I�M</br>
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
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0 && customizeData.Length == 7)
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
				// ����
				if (customizeData[1] == "0")
				{
					this.tComboEditor_ChangePg.Value = 0;

				}
				else if (customizeData[1] == "1")
				{
					this.tComboEditor_ChangePg.Value = 1;
				}
				// �o�͏�
				if (customizeData[2] == "0")
				{
					this.tComboEditor_Sort.Value = 0;

				}
				else if (customizeData[2] == "1")
				{
					this.tComboEditor_Sort.Value = 1;
				}
				// ��s/�x�X
				this.tNedit_BankCd_St.DataText = customizeData[3];
				this.tNedit_BranchCd_St.DataText = customizeData[4];
				this.tNedit_BankCd_Ed.DataText = customizeData[5];
				this.tNedit_BranchCd_Ed.DataText = customizeData[6];

            }
        }

        /// <summary>
        /// UI�ۑ��R���|�[�l���g�����݃C�x���g
        /// </summary>
        /// <param name="targetControls">�Ώ�Control</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	�@ : UI�ۑ��R���|�[�l���g�����݃C�x���g���s��</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
			customizeData = new string[7];
			// ��`�敪
			if (tComboEditor_DraftDivide.SelectedIndex == 0)
			{
				customizeData[0] = "0";
			}
			else if (tComboEditor_DraftDivide.SelectedIndex == 1)
			{
				customizeData[0] = "1";
			}
			// ����
			if (tComboEditor_ChangePg.SelectedIndex == 0)
			{
				customizeData[1] = "0";
			}
			else if (tComboEditor_ChangePg.SelectedIndex == 1)
			{
				customizeData[1] = "1";
			}

			// �o�͏�
			if (tComboEditor_Sort.SelectedIndex == 0)
			{
				customizeData[2] = "0";
			}
			else if (tComboEditor_Sort.SelectedIndex == 1)
			{
				customizeData[2] = "1";
			}
			// ��s/�x�X
			customizeData[3] = this.tNedit_BankCd_St.DataText;
			customizeData[4] = this.tNedit_BranchCd_St.DataText;
			customizeData[5] = this.tNedit_BankCd_Ed.DataText;
			customizeData[6] = this.tNedit_BranchCd_Ed.DataText;
        }

		/// <summary>
		/// �����l���ǂ����Ƃ������f
		/// </summary>
		/// <param name="num">string</param>
		/// <returns>�����l���ǂ���</returns>
		/// <remarks>
		/// <br>Note       : �����l���ǂ����Ƃ������f</br>
		/// <br>Programmer : �I�M</br>
		/// <br>Date       : 2010.05.05</br>
		/// </remarks>
		private bool IsInteger(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim().Length == 0)
			{
				return false;
			}
			return Regex.IsMatch(str, @"^-?\d+$");
		}
        #endregion �� Private Method

	}
}