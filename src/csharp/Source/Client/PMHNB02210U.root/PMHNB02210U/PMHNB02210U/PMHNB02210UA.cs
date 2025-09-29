//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi���R�ꗗ�\
// �v���O�����T�v   : �ԕi���R�ꗗ�\���𒊏o���A����EPDF�o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : caowj
// �C �� ��  2010/08/12  �C�����e : ���㌎��N��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : cheq                                
// �C �� ��  2013/01/25  �C�����e : 2013/03/13�z�M��                    
//                                  Redmine#34098 �r���󎚐���̒ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : ���N                                
// �C �� ��  2013/02/27  �C�����e : 2013/03/13�z�M��                    
//                                  Redmine#34098 �r���󎚐���̒ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : cheq                                
// �C �� ��  2013/03/11  �C�����e : 2013/03/26�z�M��                    
//                                  Redmine#34987 �t�H�[�J�X�J�ڂ̒ǉ��Ή�
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
    /// �ԕi���R�ꗗ�\ ���̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi���R�ꗗ�\PDF�o�͑�����s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// <br>Update Note : 2010/08/12  caowj</br>
    /// <br>              �E PM.NS1012�Ή�</br>
    /// <br>Update Note : 2013/01/25 cheq</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
    /// <br>Update Note : 2013/02/27 ���N</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
    /// <br>Update Note : 2013/03/11 cheq</br>
    /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/26�z�M��</br>
    /// <br>              Redmine#34987 �t�H�[�J�X�J�ڂ̑Ή�</br>
    /// </remarks>
    public partial class PMHNB02210UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer,		// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
                                IPrintConditionInpTypeGuidExecuter      // F5�F�K�C�h�̕\����\��  // ADD 2010/08/12
    {
        #region �� Constructor
        /// <summary>
        /// ���[����(�������̓^�C�v)�t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public PMHNB02210UA()
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
        private HenbiRiyuListReport _henbiRiyuListReport;

        // �K�C�h�n�A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs;

        //���t�擾���i
        private DateGetAcs _dateGet;

        // �t�H�[�J�XControl
        private Control _prevControl = null;

        // �`�F�b�N�G���[
        private bool hasCheckError = false;

        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;

        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        private bool _customerCodeSt = false;
        // --- ADD 2010/08/12 ----------------------------------<<<<<

        // ADD 2007/07/13 PVCS326
        // �Ώ۔N��Clone
        private string _thisYearMonthClone;

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        private object _preComboEditorValue = null;

        /// <summary>
        /// �K�C�h�p�C�x���g
        /// </summary>
        public event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent;
        // --- ADD 2010/08/12 ----------------------------------<<<<<

        // --- ADD 2010/08/26 ---------->>>>>
        private Control _preControl = null;
        public event ParentPrint ParentPrintCall;
        // --- ADD 2010/08/26 ----------<<<<<

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		// �N���XID
        private const string ct_ClassID = "PMHNB02210UA";
		// �v���O����ID
        private const string ct_PGID = "PMHNB02210U";
		//// ���[����
        private const string PDF_PRINT_NAME = "�ԕi���R�ꗗ�\";
		private string _printName = PDF_PRINT_NAME;
        // ���[�L�[	
        private const string PDF_PRINT_KEY = "e51401e3-8545-4e50-85f2-baad3992d818";
        //�S��
        private const string ct_All = "00";
		private string _printKey = PDF_PRINT_KEY;
		#endregion �� Interface member

        /// <summary>���[�U�[�K�C�h�敪�R�[�h�i�ԕi���R�j</summary>
        public static readonly int DIVCODE_UserGuideDivCd_RetGoodsReason = 91;
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;
            string errMessage = "";
            Control errComponent = null;

            // --- ADD 2010/08/26 ---------->>>>>
            ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this._preControl, this._preControl);
            this.tArrowKeyControl1_ChangeFocus(this, evt);
            // --- ADD 2010/08/26 ----------<<<<<
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
        /// </remarks>
        public int Print(ref object parameter)
        {

            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "�ԕi���R�ꗗ�\�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
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
            printInfo.jyoken = this._henbiRiyuListReport;
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._henbiRiyuListReport = new HenbiRiyuListReport();

            // �����^�`�F�b�N
            //int result = 0;
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
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
        #region �� PMHNB02210UA
        #region �� PMHNB02210UA_Load Event
        /// <summary>
        /// PMHNB02210UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
        /// <br>Update Note : 2010/08/12 caowj</br>
        /// <br>              PM.NS1012�Ή�</br>
        /// </remarks>
        private void PMHNB02210UA_Load(object sender, EventArgs e)
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
            this.tComboEditor_ChangePg.Focus();
            _prevControl = tComboEditor_ChangePg;
            this.Cursor = Cursors.Default;

            // --- ADD 2010/08/12 ---------------------------------->>>>>
            ParentToolbarGuideSettingEvent(true);
            // --- ADD 2010/08/12 ----------------------------------<<<<<
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
        /// <br>Update Note : 2010/08/12 caowj</br>
        /// <br>              PM.NS1012�Ή�</br>
        /// <br>Update Note : 2013/01/25 cheq</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// <br>Update Note : 2013/03/11 cheq</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/26�z�M��</br>
        /// <br>              Redmine#34987 �t�H�[�J�X�J�ڂ̑Ή�</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            #region ���ڏ���
            if (e.PrevCtrl != null)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "tComboEditor_SlipKind":
                    case "tComboEditor_PrintType":
                    case "tComboEditor_ChangePg":
                    case "tComboEditor_LinePrintDiv": // ADD cheq 2013/01/25 Redmine#34098 
                        {
                            this.setTComboEditorByName(e.PrevCtrl.Name);
                            break;
                        }
                }
            }

            if (e.NextCtrl != null)
            {
                if (e.NextCtrl.GetType().Name == "TComboEditor")
                {
                    this._preComboEditorValue = ((TComboEditor)e.NextCtrl).Value;
                }
            }
            // --- ADD 2010/08/26 --- >>>>>
            this._preControl = e.NextCtrl;
            // --- ADD 2010/08/26 --- <<<<<
            #endregion
            // --- ADD 2010/08/12 ----------------------------------<<<<<

            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                // --- DEL 2010/08/12 ---------------------------------->>>>>
                //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                // --- DEL 2010/08/12 ----------------------------------<<<<<
                // --- ADD 2010/08/12 ---------------------------------->>>>>
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Right))
                // --- ADD 2010/08/12 ----------------------------------<<<<<
                {
                    /*----- DEL 2013/01/25 cheq Redmine#34098 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // ���Ł��o�͏�
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    ----- DEL 2013/01/25 cheq Redmine#34098 -----<<<<<*/
                    /*----- DEL 2013/01/25 cheq Redmine#34098 ----->>>>>
                    //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // ���Ł��r����
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // �r���󎚁��o�͏�
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
                    ----- DEL 2013/01/25 cheq Redmine#34098 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // �r���󎚁�����
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // ���Ł��o�͏�
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // �o�͏������Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        tNedit_CustomerCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // ���Ӑ�(�J�n)�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        tNedit_CustomerCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // ���Ӑ�(�I��)���S����(�J�n)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_St)
                    {
                        tEdit_SalesEmployeeCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �S����(�J�n)���S����(�I��)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_Ed)
                    {
                        tEdit_SalesEmployeeCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �S����(�I��)���󒍎�(�J�n)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_St)
                    {
                        tEdit_FrontEmployeeCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �󒍎�(�J�n)���󒍎�(�I��)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_Ed)
                    {
                        tEdit_FrontEmployeeCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �󒍎�(�I��)�����s��(�J�n)
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        tEdit_SalesInputCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // ���s��(�J�n)�����s��(�I��)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        tEdit_SalesInputCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // ���s��(�I��)���ԕi���R(�J�n)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_St)
                    {
                        tNedit_RetGoodsReasonDiv_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �ԕi���R(�J�n)���ԕi���R(�I��)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_Ed)
                    {
                        tNedit_RetGoodsReasonDiv_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �ԕi���R(�I��)���`�[���
                        e.NextCtrl = this.tComboEditor_SlipKind;
                    }
                    // --- ADD 2010/08/12 ---------------------------------->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_SlipKind)
                    {
                        this.tComboEditor_SlipKind.SelectAll();
                        if (this.tComboEditor_SlipKind.Text.Equals("0") || this.tComboEditor_SlipKind.Text.Equals("1"))
                        {
                            int index = Convert.ToInt32(this.tComboEditor_SlipKind.Text);
                            this.tComboEditor_SlipKind.SelectedText = this.tComboEditor_SlipKind.Items[index].DisplayText;
                        }

                        // --- ADD 2010/08/26 ---------->>>>>
                        if (this.ParentPrintCall != null)
                        {
                            this.ParentPrintCall();
                        }
                        // --- ADD 2010/08/26 ----------<<<<<

                        e.NextCtrl = null;
                    }
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // �Ώ۔N��������
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                     ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // �Ώ۔N�����r����
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    // --- ADD 2010/08/12 ----------------------------------<<<<<
                }
                // --- ADD 2010/08/12 ---------------------------------->>>>>
                else if (e.Key == Keys.Left)
                {

                    /*----- DEL 2013/01/25 cheq Redmine#34098 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // �o�͏�������
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    ----- DEL 2013/01/25 cheq Redmine#34098 -----<<<<<*/
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // �o�͏����r����
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // �r���󎚁�����
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
                    ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // �o�͏�������
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // ���Ł��r����
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // ���Ӑ�(�J�n)���o�͏�
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // ���Ӑ�(�I��)�����Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_St)
                    {
                        // �S����(�J�n)�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_Ed)
                    {
                        // �S����(�I��)���S����(�J�n)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_St)
                    {
                        // �󒍎�(�J�n)���S����(�I��)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_Ed)
                    {
                        // �󒍎�(�I��)���󒍎�(�J�n)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        // ���s��(�J�n)���󒍎�(�I��)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        // ���s��(�I��)�����s��(�J�n)
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_St)
                    {
                        // �ԕi���R(�J�n)�����s��(�I��)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_Ed)
                    {
                        // �ԕi���R(�I��)���ԕi���R(�J�n)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_St;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SlipKind)
                    {
                        // �`�[��ʁ��ԕi���R(�I��)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // �Ώ۔N�����Ώ۔N��
                        e.NextCtrl = null;
                    }
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // ���Ł��Ώ۔N��
                        e.NextCtrl = this.tDateEdit_YearMonth.Controls[4];
                    }
                    ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // ���Ł��r����
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // �r���󎚁��Ώ۔N��
                        e.NextCtrl = this.tDateEdit_YearMonth.Controls[4];
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                }
                    // --- ADD 2010/08/12 ----------------------------------<<<<<
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    // �`�[���
                    if (e.PrevCtrl == this.tComboEditor_SlipKind)
                    {
                        // �`�[��ʁ��ԕi���R(�I��)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_Ed)
                    {
                        tNedit_RetGoodsReasonDiv_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �ԕi���R(�I��)�� �ԕi���R(�J�n)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_St)
                    {
                        tNedit_RetGoodsReasonDiv_St_AfterExitEditMode(e.PrevCtrl, null);
                        //�ԕi���R(�J�n)�� ���s��(�I��)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        tEdit_SalesInputCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // ���s��(�I��)�����s��(�J�n)
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        tEdit_SalesInputCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // ���s��(�J�n)���󒍎�(�I��)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_Ed)
                    {
                        tEdit_FrontEmployeeCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �󒍎�(�I��)���󒍎�(�J�n)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_St)
                    {
                        tEdit_FrontEmployeeCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �󒍎�(�J�n)���S����(�I��)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_Ed)
                    {
                        tEdit_SalesEmployeeCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // �S����(�I��)���S����(�J�n)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_St)
                    {
                        tEdit_SalesEmployeeCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // �S����(�J�n)�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        tNedit_CustomerCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // ���Ӑ�(�I��)�����Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        tNedit_CustomerCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // ���Ӑ�(�J�n)���o�͏�
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    /*----- DEL 2013/01/25 cheq Redmine#34098 ----->>>>> 
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // �o�͏�������
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                     ----- DEL 2013/01/25 cheq Redmine#34098 -----<<<<<*/
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // �o�͏����r����
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // �r���󎚁�����
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // ���Ł��`�[���
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // �o�͏�������
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // ���Ł��r����
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // �r���󎚁��Ώ۔N��
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // �Ώ۔N�����Ώ۔N��
                        e.NextCtrl = null;
                    }
                }
                else if (e.Key == Keys.Enter)
                {
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // �o�͏�������
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // ���Ł��r����
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // �r���󎚁��Ώ۔N��
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // �Ώ۔N�����Ώ۔N��
                        e.NextCtrl = null;
                    }
                }
            }
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_CustomerCode_St":
                    case "tNedit_CustomerCode_Ed":
                    case "tEdit_SalesEmployeeCd_St":
                    case "tEdit_SalesEmployeeCd_Ed":
                    case "tEdit_FrontEmployeeCd_St":
                    case "tEdit_FrontEmployeeCd_Ed":
                    case "tEdit_SalesInputCode_St":
                    case "tEdit_SalesInputCode_Ed":
                    case "tNedit_RetGoodsReasonDiv_St":
                    case "tNedit_RetGoodsReasonDiv_Ed":
                        {
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    default:
                        {
                            if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                                || e.NextCtrl is TDateEdit || e.NextCtrl is UltraButton)
                            {
                                ParentToolbarGuideSettingEvent(false);
                            }
                            break;
                        }
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }
        #endregion

        #endregion �� PMHNB02210UA

        # region �� �K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : ���Ӑ�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012�Ή�</br>
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
                // --- DEL 2010/08/12 ---------------------------------->>>>>
                //if (sender == ub_St_CustomerCode)
                //{
                //    this.tNedit_CustomerCode_Ed.Focus();
                //}
                //else
                //{
                //    this.tEdit_SalesEmployeeCd_St.Focus();
                //}
                // --- DEL 2010/08/12 ----------------------------------<<<<<
                // --- ADD 2010/08/12 ---------------------------------->>>>>
                if (sender == ub_St_CustomerCode)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else if (sender == ub_Ed_CustomerCode)
                {
                    this.tEdit_SalesEmployeeCd_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else if (sender == tNedit_CustomerCode_St)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else if (sender == tNedit_CustomerCode_Ed)
                {
                    this.tEdit_SalesEmployeeCd_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                // --- ADD 2010/08/12 ----------------------------------<<<<<
            }

        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : ���Ӑ�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012�Ή�</br>
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
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (_customerGuideSender == this.ub_St_CustomerCode)
            //{
            //    this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            //}
            //else
            //{
            //    this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (_customerGuideSender != null)
            {
                if (_customerGuideSender == this.ub_St_CustomerCode)
                {
                    this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                }
                else
                {
                    this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                }
            }
            else
            {
                if (this._customerCodeSt)
                {
                    this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                }
                else
                {
                    this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
            _customerGuideOK = true;
        }

        /// <summary>
        /// �S���҃K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> 
        /// <br>Note       : �S���҃K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012�Ή�</br>
        /// </remarks>
        private void ub_St_SalesEmployeeCd_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            // �K�C�h�N��
            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
            // ���ڂɓW�J
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (sender == this.ub_St_SalesEmployeeCd)
            //    {
            //        this.tEdit_SalesEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_SalesEmployeeCd_Ed.Focus();
            //    }
            //    else
            //    {
            //        this.tEdit_SalesEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_FrontEmployeeCd_St.Focus();
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (sender == this.ub_St_SalesEmployeeCd)
                    {
                        this.tEdit_SalesEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_SalesEmployeeCd_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tEdit_SalesEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_FrontEmployeeCd_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            else
            {
                if (tEdit_SalesEmployeeCd_St.Focused)
                {
                    this.tEdit_SalesEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_SalesEmployeeCd_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else
                {
                    this.tEdit_SalesEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_FrontEmployeeCd_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }

        /// <summary>
        /// �󒍎҃K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> 
        /// <br>Note       : �󒍎҃K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012�Ή�</br>
        /// </remarks>
        private void ub_St_FrontEmployeeCd_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            // �K�C�h�N��
            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            // ���ڂɓW�J
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (sender == this.ub_St_FrontEmployeeCd)
            //    {
            //        this.tEdit_FrontEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_FrontEmployeeCd_Ed.Focus();
            //    }
            //    else
            //    {
            //        this.tEdit_FrontEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_SalesInputCode_St.Focus();
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (sender == this.ub_St_FrontEmployeeCd)
                    {
                        this.tEdit_FrontEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_FrontEmployeeCd_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tEdit_FrontEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_SalesInputCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            else
            {
                if (tEdit_FrontEmployeeCd_St.Focused)
                {
                    this.tEdit_FrontEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_FrontEmployeeCd_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else
                {
                    this.tEdit_FrontEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_SalesInputCode_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<

        }

        /// <summary>
        /// ���s�҃K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> 
        /// <br>Note       : ���s�҃K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br>
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012�Ή�</br>
        /// </remarks>
        private void ub_St_SalesInputCode_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            // �K�C�h�N��
            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            // ���ڂɓW�J
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (sender == this.ub_St_SalesInputCode)
            //    {
            //        this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_SalesInputCode_Ed.Focus();
            //    }
            //    else
            //    {
            //        this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tNedit_RetGoodsReasonDiv_St.Focus();
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (sender == this.ub_St_SalesInputCode)
                    {
                        this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_SalesInputCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tNedit_RetGoodsReasonDiv_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            else
            {
                if (tEdit_SalesInputCode_St.Focused)
                {
                    this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_SalesInputCode_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else
                {
                    this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                    this.tNedit_RetGoodsReasonDiv_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<

        }

        /// <summary>
        /// �ԕi���R�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> 
        /// <br>Note       : �ԕi���R�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012�Ή�</br>
        /// </remarks>
        private void ub_St_RetGoodsReasonDiv_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            UserGuideAcs userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd;
            UserGdBd userGdBd;


            if (userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, PMHNB02210UA.DIVCODE_UserGuideDivCd_RetGoodsReason) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���ڂɓW�J
                // --- DEL 2010/08/12 ---------------------------------->>>>>
                //if (sender == this.ub_St_RetGoodsReasonDiv)
                //{
                //    this.tNedit_RetGoodsReasonDiv_St.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                //    this.tNedit_RetGoodsReasonDiv_Ed.Focus();
                //}
                //else
                //{
                //    this.tNedit_RetGoodsReasonDiv_Ed.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                //    this.tComboEditor_SlipKind.Focus();
                //}
                // --- DEL 2010/08/12 ----------------------------------<<<<<
                // --- ADD 2010/08/12 ---------------------------------->>>>>
                if (sender is Infragistics.Win.Misc.UltraButton)
                {
                    if (sender == this.ub_St_RetGoodsReasonDiv)
                    {
                        this.tNedit_RetGoodsReasonDiv_St.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                        this.tNedit_RetGoodsReasonDiv_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tNedit_RetGoodsReasonDiv_Ed.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                        this.tComboEditor_SlipKind.Focus();
                        ParentToolbarGuideSettingEvent(false);
                    }
                }
                else
                {
                    if (tNedit_RetGoodsReasonDiv_St.Focused)
                    {
                        this.tNedit_RetGoodsReasonDiv_St.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                        this.tNedit_RetGoodsReasonDiv_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tNedit_RetGoodsReasonDiv_Ed.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                        this.tComboEditor_SlipKind.Focus();
                        ParentToolbarGuideSettingEvent(false);
                    }
                }
                // --- ADD 2010/08/12 ----------------------------------<<<<<
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
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
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
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
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

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �S���҃R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_SalesEmployeeCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �S���҃R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (!hkCheck(this.tEdit_SalesEmployeeCd_St.Text))
            {
                this.tEdit_SalesEmployeeCd_St.Text = string.Empty;
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
        /// <br>Note       : �S���҃R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_SalesEmployeeCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �S���҃R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ

            if (!hkCheck(this.tEdit_SalesEmployeeCd_Ed.Text))
            {
                this.tEdit_SalesEmployeeCd_Ed.Text = string.Empty;
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
        /// <br>Note       : �󒍎҃R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_FrontEmployeeCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �󒍎҃R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (!hkCheck(this.tEdit_FrontEmployeeCd_St.Text))
            {
                this.tEdit_FrontEmployeeCd_St.Text = string.Empty;
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
        /// <br>Note       : �󒍎҃R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_FrontEmployeeCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �󒍎҃R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (!hkCheck(this.tEdit_FrontEmployeeCd_Ed.Text))
            {
                this.tEdit_FrontEmployeeCd_Ed.Text = string.Empty;
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
        /// <br>Note       : ���s�҃R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_SalesInputCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // ���s�҃R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (!hkCheck(this.tEdit_SalesInputCode_St.Text))
            {
                this.tEdit_SalesInputCode_St.Text = string.Empty;
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
        /// <br>Note       : ���s�҃R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_SalesInputCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // ���s�҃R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (!hkCheck(this.tEdit_SalesInputCode_Ed.Text))
            {
                this.tEdit_SalesInputCode_Ed.Text = string.Empty;
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
        /// <br>Note       : �ԕi���R�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tNedit_RetGoodsReasonDiv_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �ԕi���R�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_RetGoodsReasonDiv_St.GetInt())
            {
                this.tNedit_RetGoodsReasonDiv_St.Text = string.Empty;
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
        /// <br>Note       : �ԕi���R�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tNedit_RetGoodsReasonDiv_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �ԕi���R�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_RetGoodsReasonDiv_Ed.GetInt())
            {
                this.tNedit_RetGoodsReasonDiv_Ed.Text = string.Empty;
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
        /// <br>Update Note : 2013/01/25 cheq</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            
            try
            {
                // �Ώ۔N��
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                //�O���������
                DateTime prevTotalDay = DateTime.MinValue;
                //�����������
                DateTime currentTotalDay = DateTime.MinValue;
                //�O���������
                DateTime prevTotalMonth = DateTime.MinValue;
                //�����������
                DateTime currentTotalMonth = DateTime.MinValue;

                int convertProcessDivCd = 0;

                // �����������擾����
                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd);

                if (currentTotalDay != DateTime.MinValue)
                {
                    // �Ώ۔N����ݒ�
                    this.tDateEdit_YearMonth.SetDateTime(currentTotalMonth);
                    // �O�����������ݒ�
                    // this._henbiRiyuListReport.StartYearDate = prevTotalDay;// DEL 2007/07/13
                    this._henbiRiyuListReport.StartYearDate = prevTotalDay.AddDays(1.0);// ADD 2007/07/13
                    // �������������ݒ�
                    this._henbiRiyuListReport.EndYearDate = currentTotalDay;
                }
                else
                {
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
                    // �Ώ۔N����ݒ�
                    this.tDateEdit_YearMonth.SetDateTime(thisYearMonth);
                    // �N���x�J�n����ݒ�
                    // this._henbiRiyuListReport.StartYearDate = startYearDate;// DEL 2009/07/13
                    this._henbiRiyuListReport.StartYearDate = startMonthDate;// ADD 2009/07/15
                    // �N���x�J�n����ݒ�
                    // this._henbiRiyuListReport.EndYearDate = endYearDate;// DEL 2009/07/15 WUYX PVCS337
                    this._henbiRiyuListReport.EndYearDate = endMonthDate;// ADD 2009/07/15 WUYX PVCS337
                }

                /*---------DEL 2009/07/13 PVCS326-------->>>>>
                // �Ώ۔N��:���͕s��
                this.tDateEdit_YearMonth.Enabled = false;
                ---------DEL 2009/07/13 PVCS326--------<<<<<*/

                // ------ADD 2007/07/13 PVCS326----->>>>>
                // �ۑ������������Ώ۔N��
                _thisYearMonthClone = tDateEdit_YearMonth.GetDateTime().ToString("yyyyMM");
                // ------ADD 2007/07/13 PVCS326-----<<<<<

                // ���y�[�W
                if (this.tComboEditor_ChangePg.Value == null)
                {
                    this.tComboEditor_ChangePg.Value = 0;  // DEF�F���_
                }
                // �o�͏�
                if (this.tComboEditor_PrintType.Value == null)
                {
                    this.tComboEditor_PrintType.Value = 0;   // DEF:0:�ԕi���R��
                }
                // �`�[���
                if (this.tComboEditor_SlipKind.Value == null)
                {
                    this.tComboEditor_SlipKind.Value = 0;   // DEF:0:����
                }
                //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                //�r����
                if (this.tComboEditor_LinePrintDiv.Value == null)
                {
                    this.tComboEditor_LinePrintDiv.Value = 0;   // DEF:0:�󎚂���
                }
                //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_CustomerCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_FrontEmployeeCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_RetGoodsReasonDiv, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SalesEmployeeCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SalesInputCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_FrontEmployeeCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_RetGoodsReasonDiv, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SalesEmployeeCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SalesInputCode, Size16_Index.STAR1);

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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            const string ct_RangeError = "�͈̔͂Ɍ�肪����܂��B";
            const string ct_NoInputError = "����͂��Ă��������B"; // ADD 2007/07/13 PVCS326
            const string ct_InputError = "���s���ł��B";// ADD 2007/07/13 PVCS326

            bool status = true;
            //--------ADD ADD 2007/07/13 PVCS326------>>>>>
            int longDate = this.tDateEdit_YearMonth.LongDate;
            longDate = (longDate / 100) * 100 + 1;
            this.tDateEdit_YearMonth.SetLongDate(longDate);
            if (this.tDateEdit_YearMonth.GetDateYear() == 0 && this.tDateEdit_YearMonth.GetDateMonth() == 0)
            {
                errMessage = string.Format("�Ώ۔N��{0}", ct_NoInputError);
                errComponent = this.tDateEdit_YearMonth;
                status = false;
            }
            else if ((this.tDateEdit_YearMonth.LongDate != 0) && this.tDateEdit_YearMonth.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("�Ώ۔N��{0}", ct_InputError);
                errComponent = this.tDateEdit_YearMonth;
                status = false;
            }
            //-------ADD ADD 2007/07/13 PVCS326------<<<<<
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
                (this.tEdit_SalesEmployeeCd_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesEmployeeCd_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesEmployeeCd_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesEmployeeCd_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�S���҃R�[�h{0}", ct_RangeError);
                errComponent = this.tEdit_SalesEmployeeCd_St;
                status = false;
            }
            else if (
                (this.tEdit_FrontEmployeeCd_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_FrontEmployeeCd_Ed.DataText.TrimEnd() != string.Empty) &&
      (this.tEdit_FrontEmployeeCd_St.DataText.TrimEnd().CompareTo(this.tEdit_FrontEmployeeCd_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�󒍎҃R�[�h{0}", ct_RangeError);
                errComponent = this.tEdit_FrontEmployeeCd_St;
                status = false;
            }
            else if (
                (this.tEdit_SalesInputCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesInputCode_Ed.DataText.TrimEnd() != string.Empty) &&
      (this.tEdit_SalesInputCode_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesInputCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("���s�҃R�[�h{0}", ct_RangeError);
                errComponent = this.tEdit_SalesInputCode_St;
                status = false;
            }
            else if (
                (this.tNedit_RetGoodsReasonDiv_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_RetGoodsReasonDiv_Ed.DataText.TrimEnd() != string.Empty) &&
      (this.tNedit_RetGoodsReasonDiv_St.DataText.TrimEnd().CompareTo(this.tNedit_RetGoodsReasonDiv_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�ԕi���R�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_RetGoodsReasonDiv_St;
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.05.14</br>
        /// <br>Update Note : 2013/01/25 cheq</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                this._henbiRiyuListReport.EnterpriseCode = this._enterpriseCode;
                // ���_�I�v�V��������̂Ƃ�
                if (IsOptSection)
                {
                    ArrayList secList = new ArrayList();
                    // �S�БI�����ǂ���
                    if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
                    {
                        _henbiRiyuListReport.SectionCodes = new string[0];
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
                        _henbiRiyuListReport.SectionCodes = (string[])secList.ToArray(typeof(string));
                    }
                }
                // ���_�I�v�V�����Ȃ��̎�
                else
                {
                    _henbiRiyuListReport.SectionCodes = new string[0];
                }
                // �Ώ۔N��
                int longDate = this.tDateEdit_YearMonth.LongDate;
                longDate = (longDate / 100) * 100 + 1;
                this.tDateEdit_YearMonth.SetLongDate(longDate);
                this._henbiRiyuListReport.SalesDate = this.tDateEdit_YearMonth.GetDateTime();

                //---------ADD 2007/07/13 PVCS326-------->>>>>
                if (this.tDateEdit_YearMonth.GetDateTime().ToString("yyyyMM") != _thisYearMonthClone)
                {
                    DateTime startMonthDate, endMonthDate;
                    this._dateGet.GetDaysFromMonth(this._henbiRiyuListReport.SalesDate, out startMonthDate, out endMonthDate);
                    // �N�x�J�n����ݒ�
                    this._henbiRiyuListReport.StartYearDate = startMonthDate;
                    // �N�x�I������ݒ�
                    this._henbiRiyuListReport.EndYearDate = endMonthDate;

                }
                //---------ADD 2007/07/13 PVCS326--------<<<<<

                //����
                this._henbiRiyuListReport.ChangePageDiv = Convert.ToInt32(this.tComboEditor_ChangePg.Value);
                // �o�͏�
                this._henbiRiyuListReport.PrintType = Convert.ToInt32(this.tComboEditor_PrintType.Value);
                //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                // �r����
                this._henbiRiyuListReport.LinePrintDiv = Convert.ToInt32(this.tComboEditor_LinePrintDiv.Value);
                //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<

                // ���Ӑ�J�n
                if (0 == this.tNedit_CustomerCode_St.GetInt())
                {
                    this._henbiRiyuListReport.CustomerCodeSt = string.Empty;
                }
                else
                {
                    this._henbiRiyuListReport.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt().ToString("D8");
                }
                // ���Ӑ�I��
                if (0 == this.tNedit_CustomerCode_Ed.GetInt())
                {
                    this._henbiRiyuListReport.CustomerCodeEd = string.Empty;
                }
                else
                {
                    this._henbiRiyuListReport.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt().ToString("D8");
                }

                // �S���ҊJ�n
                this._henbiRiyuListReport.SalesEmployeeCdRFSt = this.tEdit_SalesEmployeeCd_St.DataText;
                // �S���ҏI��   
                this._henbiRiyuListReport.SalesEmployeeCdRFEd = this.tEdit_SalesEmployeeCd_Ed.DataText;
                // �󒍎ҊJ�n
                this._henbiRiyuListReport.FrontEmployeeCdRFSt = this.tEdit_FrontEmployeeCd_St.DataText;
                // �󒍎ҏI��
                this._henbiRiyuListReport.FrontEmployeeCdRFEd = this.tEdit_FrontEmployeeCd_Ed.DataText;
                // ���s�ҊJ�n
                this._henbiRiyuListReport.SalesInputCdRFSt = this.tEdit_SalesInputCode_St.DataText;
                // ���s�ҏI��
                this._henbiRiyuListReport.SalesInputCdRFEd = this.tEdit_SalesInputCode_Ed.DataText;
                // �ԕi���R�J�n
                if (0 == this.tNedit_RetGoodsReasonDiv_St.GetInt())
                {
                    this._henbiRiyuListReport.RetGoodsReasonDivSt = string.Empty;
                }
                else
                {
                    this._henbiRiyuListReport.RetGoodsReasonDivSt = this.tNedit_RetGoodsReasonDiv_St.GetInt().ToString("D4");
                }
                // �ԕi���R�I��
                if (0 == this.tNedit_RetGoodsReasonDiv_Ed.GetInt())
                {
                    this._henbiRiyuListReport.RetGoodsReasonDivEd = string.Empty;
                }
                else
                {
                    this._henbiRiyuListReport.RetGoodsReasonDivEd = this.tNedit_RetGoodsReasonDiv_Ed.GetInt().ToString("D4");
                }

                // �`�[���
                this._henbiRiyuListReport.SlipKindCd = Convert.ToInt32(this.tComboEditor_SlipKind.Value);

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.14</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportType") ||
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportType") ||
                (e.Group.Key == "PrintConditionGroup"))
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
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.05.11</br>
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
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.05.11</br>
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
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.05.11</br>
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
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.05.11</br>
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
        /// <br>Note	�@ : UI�ۑ��R���|�[�l���g�Ǎ��݃C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.25</br>
        /// <br>Update Note: 2013/01/25 cheq</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            //if (customizeData.Length > 0 && customizeData.Length == 13) // DEL cheq 2013/01/25 Redmine#34098 
            if (customizeData.Length > 0 && customizeData.Length == 14) // ADD cheq 2013/01/25 Redmine#34098 
            {
                // ����
                if (customizeData[0] == "0")
                {
                    this.tComboEditor_ChangePg.Value = 0;

                }
                else if (customizeData[0] == "1")
                {
                    this.tComboEditor_ChangePg.Value = 1;
                }
                else if (customizeData[0] == "2")
                {
                    this.tComboEditor_ChangePg.Value = 2;
                }
                // �o�͏�
                if (customizeData[1] == "0")
                {
                    this.tComboEditor_PrintType.Value = 0;

                }
                else if (customizeData[1] == "1")
                {
                    this.tComboEditor_PrintType.Value = 1;
                }
                else if (customizeData[1] == "2")
                {
                    this.tComboEditor_PrintType.Value = 2;
                }
                else if (customizeData[1] == "3")
                {
                    this.tComboEditor_PrintType.Value = 3;
                }
                else if (customizeData[1] == "4")
                {
                    this.tComboEditor_PrintType.Value = 4;
                }
                // ���Ӑ�
                this.tNedit_CustomerCode_St.DataText = customizeData[2];
                this.tNedit_CustomerCode_Ed.DataText = customizeData[3];
                // �S����
                this.tEdit_SalesEmployeeCd_St.DataText = customizeData[4];
                this.tEdit_SalesEmployeeCd_Ed.DataText = customizeData[5];
                // �󒍎�
                this.tEdit_FrontEmployeeCd_St.DataText = customizeData[6];
                this.tEdit_FrontEmployeeCd_Ed.DataText = customizeData[7];
                // ���s��
                this.tEdit_SalesInputCode_St.DataText = customizeData[8];
                this.tEdit_SalesInputCode_Ed.DataText = customizeData[9];
                // �ԕi���R
                this.tNedit_RetGoodsReasonDiv_St.DataText = customizeData[10];
                this.tNedit_RetGoodsReasonDiv_Ed.DataText = customizeData[11];
                // �`�[���
                if (customizeData[12] == "0")
                {
                    this.tComboEditor_SlipKind.Value = 0;

                }
                else if (customizeData[12] == "1")
                {
                    this.tComboEditor_SlipKind.Value = 1;
                }
                //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>> 
                //�r����
                if (customizeData[13] == "0")
                {
                    this.tComboEditor_LinePrintDiv.Value = 0;
                }
                else if (customizeData[13] == "1")
                {
                    this.tComboEditor_LinePrintDiv.Value = 1;
                }
                else if (customizeData[13] == "2")
                {
                    this.tComboEditor_LinePrintDiv.Value = 2;
                }
                else
                { }
                //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
            }
        }

        /// <remarks>
        /// <br>Update Note: 2013/01/25 cheq</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            //customizeData = new string[13]; // DEL cheq 2013/01/25 Redmine#34098 
            customizeData = new string[14]; // ADD cheq 2013/01/25 Redmine#34098 

            // ����
            if (tComboEditor_ChangePg.SelectedIndex == 0)
            {
               customizeData[0] = "0";
            }
            else if (tComboEditor_ChangePg.SelectedIndex == 1)
            {
                customizeData[0] = "1";
            }
            else if (tComboEditor_ChangePg.SelectedIndex == 2)
            {
                customizeData[0] = "2";
            }
            // �o�͏�
            if (tComboEditor_PrintType.SelectedIndex == 0)
            {
               customizeData[1] = "0";
            }
            else if (tComboEditor_PrintType.SelectedIndex == 1)
            {
                customizeData[1] = "1";
            }
            else if (tComboEditor_PrintType.SelectedIndex == 2)
            {
                customizeData[1] = "2";
            }
            else if (tComboEditor_PrintType.SelectedIndex == 3)
            {
                customizeData[1] = "3";
            }
            else if (tComboEditor_PrintType.SelectedIndex == 4)
            {
                customizeData[1] = "4";
            }
�@�@�@�@�@�@// ���Ӑ�
            customizeData[2] = this.tNedit_CustomerCode_St.DataText;
            customizeData[3] = this.tNedit_CustomerCode_Ed.DataText;
            // �S����
            customizeData[4] = this.tEdit_SalesEmployeeCd_St.DataText;
            customizeData[5] = this.tEdit_SalesEmployeeCd_Ed.DataText;
            // �󒍎�
            customizeData[6] = this.tEdit_FrontEmployeeCd_St.DataText;
            customizeData[7] = this.tEdit_FrontEmployeeCd_Ed.DataText;
            // ���s��
            customizeData[8] = this.tEdit_SalesInputCode_St.DataText;
            customizeData[9] = this.tEdit_SalesInputCode_Ed.DataText;
            // �ԕi���R
            customizeData[10] = this.tNedit_RetGoodsReasonDiv_St.DataText;
            customizeData[11] = this.tNedit_RetGoodsReasonDiv_Ed.DataText;
            // �`�[���
            if (tComboEditor_SlipKind.SelectedIndex == 0)
            {
                customizeData[12] = "0";
            }
            else if (tComboEditor_SlipKind.SelectedIndex == 1)
            {
                customizeData[12] = "1";
            }
            //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>> 
            // �r����
            if (tComboEditor_LinePrintDiv.SelectedIndex == 0)
            {
                customizeData[13] = "0";
            }
            else if (tComboEditor_LinePrintDiv.SelectedIndex == 1)
            {
                customizeData[13] = "1";
            }
            else if (tComboEditor_LinePrintDiv.SelectedIndex == 2)
            {
                customizeData[13] = "2";
            }
            else
            { }
            //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
        }

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        /// <summary>
        /// �R�[�h����̑I�����\�֕ύX����
        /// </summary>
        /// <param name="name"></param>
        /// <remarks>
        /// <br>Note		: �R�[�h����̑I�����\�֕ύX����</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (item.DataValue == control.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }

            if (inputErrorFlg)
            {
                control.Value = this._preComboEditorValue;
            }
            else
            {
                this._preComboEditorValue = control.Value;
            }
        }
        // --- ADD 2010/08/12 ----------------------------------<<<<<
        #endregion �� Private Method

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        #region �� F5�F�K�C�h�̎��s
        /// <summary>
        /// F5�F�K�C�h�̎��s
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: F5�F�K�C�h�̎��s</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        public void ExcuteGuide(object sender, EventArgs e)
        {
            if (this.tNedit_CustomerCode_St.Focused)
            {
                this._customerCodeSt = true;
                ub_St_CustomerCode_Click(tNedit_CustomerCode_St, e);
            }
            else if (this.tNedit_CustomerCode_Ed.Focused)
            {
                this._customerCodeSt = false;
                ub_St_CustomerCode_Click(tNedit_CustomerCode_Ed, e);
            }
            else if (this.tEdit_SalesEmployeeCd_St.Focused)
            {
                ub_St_SalesEmployeeCd_Click(tEdit_SalesEmployeeCd_St, e);
            }
            else if (this.tEdit_SalesEmployeeCd_Ed.Focused)
            {
                ub_St_SalesEmployeeCd_Click(tEdit_SalesEmployeeCd_Ed, e);
            }
            else if (this.tEdit_FrontEmployeeCd_St.Focused)
            {
                ub_St_FrontEmployeeCd_Click(tEdit_FrontEmployeeCd_St, e);
            }
            else if (this.tEdit_FrontEmployeeCd_Ed.Focused)
            {
                ub_St_FrontEmployeeCd_Click(tEdit_FrontEmployeeCd_Ed, e);
            }
            else if (this.tEdit_SalesInputCode_St.Focused)
            {
                ub_St_SalesInputCode_Click(tEdit_SalesInputCode_St, e);
            }
            else if (this.tEdit_SalesInputCode_Ed.Focused)
            {
                ub_St_SalesInputCode_Click(tEdit_SalesInputCode_Ed, e);
            }
            else if (this.tNedit_RetGoodsReasonDiv_St.Focused)
            {
                ub_St_RetGoodsReasonDiv_Click(tNedit_RetGoodsReasonDiv_St, e);
            }
            else if (this.tNedit_RetGoodsReasonDiv_Ed.Focused)
            {
                ub_St_RetGoodsReasonDiv_Click(tNedit_RetGoodsReasonDiv_Ed, e);
            }
        }
        #endregion
        // --- ADD 2010/08/12 ----------------------------------<<<<<


    }
}