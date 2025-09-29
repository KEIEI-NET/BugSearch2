//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Ԍ����q�ꗗ�\
// �v���O�����T�v   : �����Ԍ����q�ꗗ�\���𒊏o���A����EPDF�o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2001 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �L�Q
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
    /// �����Ԍ����q�ꗗ�\ ���̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����Ԍ����q�ꗗ�\PDF�o�͑�����s���N���X�ł��B</br>
    /// <br>Programmer : �L�Q</br>
    /// <br>Date       : 2010.04.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public partial class PMSYA02100UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// ���[����(�������̓^�C�v)�t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public PMSYA02100UA()
        {
            InitializeComponent();
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._employeeAcs = new EmployeeAcs();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
            // �Ǘ��ԍ��K�C�h
            this._carMngInputAcs = CarMngInputAcs.GetInstance();
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

        //--IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ� -------------------
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L��
        private bool _isOptSection = false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc = false;
        // �I�����_���X�g
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = string.Empty;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private MonthCarInspectListPara _monthCarInspectListPara;

        // �K�C�h�n�A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs;

        // ���t�擾���i
        private DateGetAcs _dateGet;
        
        // �Ǘ��ԍ��K�C�h
        private CarMngInputAcs _carMngInputAcs;

        // �t�H�[�J�XControl
        private Control _prevControl = null;

        // �`�F�b�N�G���[
        private bool hasCheckError = false;

        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;

        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;


        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		// �N���XID
        private const string ct_ClassID = "PMSYA02100UA";
		// �v���O����ID
        private const string ct_PGID = "PMSYA02100U";
		//// ���[����
        private const string PDF_PRINT_NAME = "�����Ԍ����q�ꗗ�\";
		private string _printName = PDF_PRINT_NAME;
        // ���[�L�[	
        private const string PDF_PRINT_KEY = "e079661c-2117-4b46-a0fc-5118082d9456";
        //�S��
        private const string ct_All = "00";
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
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
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
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
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
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        public int Print(ref object parameter)
        {

            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "�����Ԍ����q�ꗗ�\�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;
            printInfo.PrintPaperSetCd = 0;

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }
            
            // ���o�����̐ݒ�
            printInfo.jyoken = this._monthCarInspectListPara;
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
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._monthCarInspectListPara = new MonthCarInspectListPara();

            // �����^�`�F�b�N
            this.Show();

            return;
        }
        #endregion

        #endregion �� Public Method

        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypeSelectedSection �����o
        #region �� Public Property

        /// <summary> �{�Ћ@�\�v���p�e�B </summary>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary> ���_�I�v�V�����v���p�e�B </summary>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> �v�㋒�_�I��\���擾�v���p�e�B </summary>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        #endregion �� Public Property

        #region �� Public Method

        #region �� ���_�I������
        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">�I�����_�R�[�h</param>
        /// <param name="checkState">�I�����</param>
        /// <remarks>
        /// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // ���_��I��������
            if (checkState == CheckState.Checked)
            {
                // �S�Ђ��I�����ꂽ�ꍇ
                if (sectionCode == "0")
                {
                    this._selectedSectionList.Clear();

                }

                if (!this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Add(sectionCode, checkState);
                }
            }
            // ���_�I��������������
            else if (checkState == CheckState.Unchecked)
            {
                if (this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Remove(sectionCode);
                }
            }
        }
        #endregion

        #region �� �����I���v�㋒�_�ݒ菈��( ������ )
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #region �� �����I�����_�ݒ菈��
        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
        /// <param name="sectionCodeLst">�I�����_�R�[�h���X�g</param>
        /// <remarks>
        /// <br>Note		: ���_���X�g�̏��������s���B</br>
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // �I�����X�g������
            this._selectedSectionList.Clear();
            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionList.Add(wk, CheckState.Checked);
            }
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
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
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
        /// <param name="addUpCd">addUpCd</param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
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
        #region �� PMSYA02100UA
        #region �� PMSYA02100UA_Load Event
        /// <summary>
        /// PMSYA02100UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private void PMSYA02100UA_Load(object sender, EventArgs e)
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
            //this.Cursor = Cursors.WaitCursor;
            //this.tComboEditor_ChangePg.Focus();
            //_prevControl = tComboEditor_ChangePg;
            //this.Cursor = Cursors.Default;

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
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // �����������s
                        e.NextCtrl = this.uos_NewRowDiv;
                    }
                    else if (e.PrevCtrl == this.uos_NewRowDiv)
                    {
                        // ���s������
                        e.NextCtrl = this.uos_NewPageDiv;
                    }
                    else if (e.PrevCtrl == this.uos_NewPageDiv)
                    {
                        // ���Ł����Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // ���Ӑ�(�J�n)�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // ���Ӑ�(�I��)���Ǘ��ԍ�(�J�n)
                        e.NextCtrl = this.tEdit_CarMngCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_CarMngCode_St)
                    {
                        // �Ǘ��ԍ�(�J�n)���Ǘ��ԍ�(�I��)
                        e.NextCtrl = this.tEdit_CarMngCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_CarMngCode_Ed)
                    {
                        // �Ǘ��ԍ�(�I��)��������
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tEdit_CarMngCode_Ed)
                    {
                        // �Ǘ��ԍ�(�I��)���Ǘ��ԍ�(�J�n)
                        e.NextCtrl = this.tEdit_CarMngCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_CarMngCode_St)
                    {
                        // �Ǘ��ԍ�(�J�n)�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // ���Ӑ�(�I��)�����Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // ���Ӑ�(�J�n)������
                        e.NextCtrl = this.uos_NewPageDiv;
                    }
                    else if (e.PrevCtrl == this.uos_NewPageDiv)
                    {
                        // ���Ł����s
                        e.NextCtrl = this.uos_NewRowDiv;
                    }
                    if (e.PrevCtrl == this.uos_NewRowDiv)
                    {
                        // ���s��������
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // ���������Ǘ��ԍ�(�I��)
                        e.NextCtrl = this.tEdit_CarMngCode_Ed;
                    }
                }
            }
        }
        #endregion

        #endregion �� PMSYA02100UA

        # region �� �K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : ���Ӑ�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : �L�Q</br>                                  
        /// <br>Date       : 2010.04.21</br> 
        /// </remarks>
        private void ub_St_CustomerCode_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                if (sender == ub_St_CustomerCode)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_CarMngCode_St.Focus();
                }
            }

        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : ���Ӑ�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : �L�Q</br>                                  
        /// <br>Date       : 2010.04.21</br> 
        /// </remarks>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // �K�C�h�N��
            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;
            // ���ڂɓW�J
            if (_customerGuideSender == this.ub_St_CustomerCode)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }

            _customerGuideOK = true;
        }


        /// <summary>
        /// �Ǘ��ԍ��K�C�h �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Ǘ��ԍ��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private void ub_St_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                paramInfo.EnterpriseCode = this._enterpriseCode;
                // �u�V�K�o�^�v�s�\���Ȃ�
                paramInfo.IsDispNewRow = false;
                // ���Ӑ�\������
                paramInfo.IsDispCustomerInfo = true;
                // ���Ӑ�R�[�h�i�荞�ݖ���
                paramInfo.IsCheckCustomerCode = false;
                // �Ǘ��ԍ��i�荞�ݖ���
                paramInfo.IsCheckCarMngCode = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "�V�K�o�^")
                    {
                        this.tEdit_CarMngCode_St.Text = selectedInfo.CarMngCode;
                        this.tEdit_CarMngCode_Ed.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �Ǘ��ԍ��K�C�h �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Ǘ��ԍ��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private void ub_Ed_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                paramInfo.EnterpriseCode = this._enterpriseCode;
                // �u�V�K�o�^�v�s�\���Ȃ�
                paramInfo.IsDispNewRow = false;
                // ���Ӑ�\������
                paramInfo.IsDispCustomerInfo = true;
                // ���Ӑ�R�[�h�i�荞�ݖ���
                paramInfo.IsCheckCustomerCode = false;
                // �Ǘ��ԍ��i�荞�ݖ���
                paramInfo.IsCheckCarMngCode = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "�V�K�o�^")
                    {
                        this.tEdit_CarMngCode_Ed.Text = selectedInfo.CarMngCode;
                        this.tDateEdit_YearMonth.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion �� �K�C�h�{�^���N���b�N�C�x���g

        #region �� �t�H�[�J�X�A�E�g
        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : �L�Q</br>                                  
        /// <br>Date       : 2010.04.21</br> 
        /// </remarks> 
        private void tNedit_CustomerCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // ���Ӑ�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_CustomerCode_St.GetInt())
            {
                this.tNedit_CustomerCode_St.Text = string.Empty;
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
        /// <br>Note       : ���Ӑ�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : �L�Q</br>                                  
        /// <br>Date       : 2010.04.21</br> 
        /// </remarks> 
        private void tNedit_CustomerCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // ���Ӑ�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_CustomerCode_Ed.GetInt())
            {
                this.tNedit_CustomerCode_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        #endregion �� �t�H�[�J�X�A�E�g
        
        #endregion �� Control Event

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            
            try
            {
                // ������
                this.tDateEdit_YearMonth.SetDateTime(DateTime.Today);
                
                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_CustomerCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CarMngNoGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CarMngNoGuide, Size16_Index.STAR1);

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
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
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
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
            const string ct_NoInputError = "����͂��Ă��������B";
            const string ct_InputError = "���s���ł��B";

            bool status = true;
            int longDate = this.tDateEdit_YearMonth.LongDate;
            longDate = (longDate / 100) * 100 + 1;
            this.tDateEdit_YearMonth.SetLongDate(longDate);
            if (this.tDateEdit_YearMonth.GetDateYear() == 0 && this.tDateEdit_YearMonth.GetDateMonth() == 0)
            {
                errMessage = string.Format("������{0}", ct_NoInputError);
                errComponent = this.tDateEdit_YearMonth;
                status = false;
            }
            else if ((this.tDateEdit_YearMonth.LongDate != 0) && this.tDateEdit_YearMonth.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("�������̓���{0}", ct_InputError);
                errComponent = this.tDateEdit_YearMonth;
                status = false;
            }
            else if (
                (this.tNedit_CustomerCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_CustomerCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_CustomerCode_St.DataText.TrimEnd().CompareTo(this.tNedit_CustomerCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("���Ӑ�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            else if (
                (this.tEdit_CarMngCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_CarMngCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_CarMngCode_St.DataText.TrimEnd().CompareTo(this.tEdit_CarMngCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�Ǘ��ԍ�{0}", ct_RangeError);
                errComponent = this.tEdit_CarMngCode_Ed;
                status = false;
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
        /// <br>Programmer  : �L�Q</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                this._monthCarInspectListPara.EnterpriseCode = this._enterpriseCode;
                // ���_�I�v�V��������̂Ƃ�
                if (IsOptSection)
                {
                    ArrayList secList = new ArrayList();
                    // �S�БI�����ǂ���
                    if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
                    {
                        _monthCarInspectListPara.SectionCodes = new string[0];
                    }
                    else
                    {
                        foreach (DictionaryEntry dicEntry in this._selectedSectionList)
                        {
                            if ((CheckState)dicEntry.Value == CheckState.Checked)
                            {
                                secList.Add(dicEntry.Key);
                            }
                        }
                        _monthCarInspectListPara.SectionCodes = (string[])secList.ToArray(typeof(string));
                    }
                }
                // ���_�I�v�V�����Ȃ��̎�
                else
                {
                    _monthCarInspectListPara.SectionCodes = new string[0];
                }

                // ������
                this._monthCarInspectListPara.InspectMaturityDate = this.tDateEdit_YearMonth.GetDateTime();


                // ���s
                this._monthCarInspectListPara.ChangeRowDiv = (MonthCarInspectListPara.ChangeRowDivState)this.uos_NewRowDiv.Value;
                // ����
                this._monthCarInspectListPara.ChangePageDiv = (MonthCarInspectListPara.ChangePageDivState)this.uos_NewPageDiv.Value;

                // ���Ӑ�J�n
                if (0 == this.tNedit_CustomerCode_St.GetInt())
                {
                    this._monthCarInspectListPara.StCustomerCode = string.Empty;
                }
                else
                {
                    this._monthCarInspectListPara.StCustomerCode = this.tNedit_CustomerCode_St.GetInt().ToString("D8");
                }
                // ���Ӑ�I��
                if (0 == this.tNedit_CustomerCode_Ed.GetInt())
                {
                    this._monthCarInspectListPara.EdCustomerCode = string.Empty;
                }
                else
                {
                    this._monthCarInspectListPara.EdCustomerCode = this.tNedit_CustomerCode_Ed.GetInt().ToString("D8");
                }

                // �Ǘ��ԍ��J�n
                if (String.IsNullOrEmpty(this.tEdit_CarMngCode_St.Text))
                {
                    this._monthCarInspectListPara.StCarMngCode = string.Empty;
                }
                else
                {
                    this._monthCarInspectListPara.StCarMngCode = this.tEdit_CarMngCode_St.Text;
                }
                // �Ǘ��ԍ��I��
                if (String.IsNullOrEmpty(this.tEdit_CarMngCode_Ed.Text))
                {
                    this._monthCarInspectListPara.EdCarMngCode = string.Empty;
                }
                else
                {
                    this._monthCarInspectListPara.EdCarMngCode = this.tEdit_CarMngCode_Ed.Text;
                }


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
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
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
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportOutputGroup") ||
                (e.Group.Key == "ReportExtractionGroup"))
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
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportOutputGroup") ||
                (e.Group.Key == "ReportExtractionGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        #region �� �����𔻒f����
        /// <summary>
        /// �����𔻒f����
        /// </summary>
        /// <param name="s">������</param>
        /// <remarks>
        /// <br>Note		: �����𔻒f�������s��</br>
        /// <br>Programmer	: �L�Q</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private static bool IsNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region �� ���p�J�i�𔻒f����
        /// <summary>
        /// ���p�J�i�����𔻒f����
        /// </summary>
        /// <param name="str">������</param>
        /// <remarks>
        /// <br>Note		: ���p�J�i�����𔻒f�������s��</br>
        /// <br>Programmer	: �L�Q</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private static bool hkCheck(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[\uFF61-\uFF9F-0-9]*$");
            bool flg = false;
            if (regex.Match(str).Success)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            return flg;
        }

        #endregion

        #region �� �I�t���C����ԃ`�F�b�N����

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note		: ���O�I�����I�����C����ԃ`�F�b�N�������s��</br>
        /// <br>Programmer	: �L�Q</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: �L�Q</br>
        /// <br>Date		: 2010.04.21</br>
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

        #endregion �� Private Method

    }
}