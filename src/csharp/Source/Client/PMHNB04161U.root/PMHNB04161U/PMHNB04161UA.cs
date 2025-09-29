//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �S���ҕʎ��яƉ�
// �v���O�����T�v   : �S���ҕʎ��яƉ�ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �C �� ��  2010/07/20  �C�����e : �e�L�X�g�o��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : chenyd
// �C �� ��  2010/08/12  �C�����e : ��QID:13038 �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �C �� ��  2010/10/09  �C�����e : ��QID:15880�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp
// �C �� ��  2011/02/16  �C�����e : �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���O
// �C �� ��  2024/11/29  �C�����e : PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�
//----------------------------------------------------------------------------//


using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;//ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using System.Net.NetworkInformation;
using Broadleaf.Application.Controller;
using Broadleaf.Application; // ADD 2010/07/20
using Infragistics.Excel; // ADD 2010/07/20
using Infragistics.Win.UltraWinGrid; // ADD 2010/07/20
using Broadleaf.Application.Controller.Facade; // ADD 2010/07/20

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �S���ҕʎ��яƉ� ���̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �S���ҕʎ��яƉ���̓t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br>Update Note: 2010/08/12�A2010/08/20 chenyd</br>
    /// <br>            �E��QID:13038 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/08/23 chenyd</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�13482</br>
    /// <br>Update Note: 2010/09/21 zhume</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�14876</br>
    /// <br>Update Note:2011/02/16 liyp</br>
    /// <br>            �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2024/11/29 ���O</br>
    /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
    /// </remarks>
    public partial class PMHNB04161UA : Form
    {
        #region ��  Private Members
        /// <summary>�C���[�W���X�g</summary>
        /// <remarks></remarks>
        private ImageList _imageList16 = null;

        /// <summary>PMHNB04161UB�I�u�W�F�N�g</summary>
        /// <remarks></remarks>
        private PMHNB04161UB _inputDetails;

        /// <summary>�]�ƈ��}�X�^�A�N�Z�X�N���X</summary>
        /// <remarks></remarks>
        private EmployeeAcs _employeeAcs;

        /// <summary>�����_</summary>
        /// <remarks></remarks>
        private string _loginSectionCode;

        /// <summary>���_�A�N�Z�X�N���X</summary>
        /// <remarks></remarks>
        private SecInfoSetAcs _secInfoSetAcs;


        private DialogResult _dialogRes = DialogResult.Cancel;


        private Control _prevControl = null;

        /// <summary>���_�R���{�{�b�N�X</summary>
        /// <remarks></remarks>
        private Infragistics.Win.UltraWinToolbars.ComboBoxTool _sectionComboBox;

        /// <summary>�S���ҕʎ��яƉ� �f�[�^�N���X</summary>
        /// <remarks></remarks>
        private EmployeeResultsCtdtn _EmployeeResultsCtdtn;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks></remarks>
        private string _enterpriseCode;

        /// <summary>�S���ҕʎ��яƉ� �����f�[�^�L���b�V��</summary>
        /// <remarks></remarks>
        private EmployeeResultsCtdtn _paraEmployeeResultsSlipCache_Display;

        //���t�擾���i
        private DateGetAcs _dateGet;

        /// <summary>�S���ҕʎ��яƉ� �e�[�u���A�N�Z�X�N���X</summary>
        /// <remarks></remarks> 
        private EmployeeResultsAcs _employeeResultsAcs = null;
        // --- ADD 2010/07/20-------------------------------->>>>>
        private PMHNB04161UC _extractSetupFrm = null;           // �o�͏����ݒ���

        private PMHNB04161UD _userSetupFrm = null;            // ���[�U�[�ݒ���

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_TextOutput;

        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // ���쌠���̐��䃊�X�g(���ڎQ�Ƃ���ƒx���̂Ńf�B�N�V���i����)
        // --- ADD 2010/07/20--------------------------------<<<<<
        private bool checkFlg = false; //  ADD 2010/08/12 ��QID:13038�Ή�

        private bool isSearch = false;                          // �����{�^�����N���b�N���邩�ǂ���  // ADD 2010/09/14

        private bool isError = false; // ADD 2010/09/25

        private string _employeeCodeSt = string.Empty; // ADD 2010/09/28 ��Q�� #15609 
        private string _employeeCodeEd = string.Empty; // ADD 2010/09/28 ��Q�� #15609 
        private string _sectionCodeAllowZero = string.Empty; // ADD 2010/09/28 ��Q�� #15609 

        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        #endregion

        # region �� Private const

        ///// <summary> ���t�Ⴄ</summary>
        ////private const string ct_InputError = "���t�̎w��Ɍ�肪����܂��B";
        /// <summary> �͈̓`�F�b�N</summary>
        private const string MESSAGE_StartEndError = "�J�n���I���ƂȂ�悤�ݒ肵�Ă��������B";
        /// <summary> �K�{���̓`�F�b�N</summary>
        private const string MESSAGE_NoInput = "����͂��Ă��������B";
        /// <summary> �L���ȓ��t�`�F�b�N</summary>
        private const string MESSAGE_InvalidDate = "�L���ȓ��t�ł͂���܂���B";
        /// <summary> �S�ЃR�[�h [00] </summary>
        private const string WHOLE_SECTION_CODE = "00";
        /// <summary> �S�Ж��� [�S��] </summary>
        private const string WHOLE_SECTION_NAME = "�S��";
        /// <summary> ���� [�S����] </summary>
        private const string SALESINPUT_NAME = "�S����";
        /// <summary> ���� [�󒍎�] </summary>
        private const string FRONTEMPLOYEE_SECTION_NAME = "�󒍎�";
        /// <summary> ���� [���s��] </summary>
        private const string SALESEMPLOYEE_NAME = "���s��";

        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary> �e�L�X�g�o�̓��\�b�h��</summary>
        private const string TEXT_METHODNM = "outputTextData";
        /// <summary> Excel�o�̓��\�b�h��</summary>
        private const string EXCEL_METHODNM = "outputExcelData";
        /// <summary> ���ԋ敪 [���v] </summary>
        private const string DURINGDIV_DAILY = "���v";
        /// <summary> ���ԋ敪 [���v] </summary>
        private const string DURINGDIV_MOONGAUGE = "���v";
        /// <summary> ���ԋ敪 [����] </summary>
        private const string DURINGDIV_CURRENTPERIOD = "����";
        /// <summary> �o�͌���</summary>
        private const string COUNTNUMSTR = "�f�[�^�o�͌���:{0},";
        /// <summary>�S���ҕʎ��яƉ�PGID</summary>
        private const string CT_EMPLOYEE_RESULT_PGID = "PMHNB04161U";
        /// <summary> �A�Z���u����</summary>
        private const string ASSEMBLYNM = "�S���ҕʎ��яƉ�";
        /// <summary> �e�L�X�g��Excel�o�͏���</summary>
        private const string OUTPUTCON = "�Q�Ƌ敪:{0},���ԋ敪:{1},���_:{2} �` {3},{0}:{4} �` {5},����:{6} �` {7},�o�̓t�@�C����:{8}";
        /// <summary> �e�L�X�g��Excel�o�͏���2</summary>
        private const string OUTPUTCON2 = "�Q�Ƌ敪:{0},���ԋ敪:{1},���_:{2} �` {3},{0}:{4} �` {5},�o�̓t�@�C����:{6}";
        /// <summary> �ŏ�����</summary>
        private const string STARTSTR = "�ŏ�����";
        /// <summary> �Ō�܂�</summary>
        private const string ENDSTR = "�Ō�܂�";
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<

        //�G���[�������b�Z�[�W
        const string ct_InputError = "�̎w��Ɍ�肪����܂��B";
        const string ct_NoInput = "����͂��ĉ������B";
        const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
        const string ct_RangeOverError = "�͒������P�����͈͓̔��œ��͂��ĉ������B";

        const string ct_RangeYearMonthOverError = "��12�����ȓ��œ��͂��ĉ������B";
        const string ct_NotOnYearError = "������N�x���ł͂���܂���B";
        const string ct_NotOnMonthError = "�����ꌎ���ł͂���܂���B";

        /// <summary>���������b�Z�[�W�u�����ɍ��v����f�[�^�����݂��܂���B�v</summary>
        private const string MSG_MATCHED_DATA_NOT_FOUND = "�����ɍ��v����f�[�^�����݂��܂���B"; // ADD 2010/07/20
        /// <summary>�`�F�b�N�����b�Z�[�W�u�o�̓t�@�C�������w�肳��Ă��܂���B�ݒ�{�^������ݒ���s���Ă��������B�v</summary>
        private const string MSG_OUTPUTFILENAME_NOTFOUND = "�o�̓t�@�C�������w�肳��Ă��܂���B�ݒ�{�^������ݒ���s���Ă��������B"; // ADD 2010/07/20

        # endregion

        #region �� Constroctors
        /// <summary>
        /// �S���ҕʎ��яƉ� ���̓t�H�[���N���X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ� ���̓t�H�[���N���X�N���X�̃R���X�g���N�^�ł�</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2024/11/29 ���O</br>
        /// <br>�Ǘ��ԍ�   : 12070203-00</br>
        /// <br>           : PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        /// </remarks>
        public PMHNB04161UA()
        {
            InitializeComponent();

            _EmployeeResultsCtdtn = new EmployeeResultsCtdtn();

            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

            this._inputDetails = new PMHNB04161UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._employeeResultsAcs = EmployeeResultsAcs.GetInstance();
            this._paraEmployeeResultsSlipCache_Display = new EmployeeResultsCtdtn();
            if (this._employeeResultsAcs.GetParaEmployeeResultsSlipCache() != null)
            {
                this._paraEmployeeResultsSlipCache_Display = this._employeeResultsAcs.GetParaEmployeeResultsSlipCache();
            }
            //this._employeeResultsAcs.StatusBarMessageSetting += new EmployeeResultsAcs.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
            this._sectionComboBox = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager_MainMenu.Tools["ComboBoxTool_SectionCode"];

            // �e�L�X�g�o�̓I�v�V�����̐���@// ADD 2010/07/20
            this.CacheOptionInfo();�@// ADD 2010/07/20
            //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�---->>>>>
            TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs();//�e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�\�������̑Ώ�
            //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�----<<<<<
        }
        #endregion

        #region �� Private Methods
        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus textOutputPs;
            textOutputPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (textOutputPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_TextOutput = 1;
            }
            else
            {
                this._opt_TextOutput = 0;
            }
            #region[�e�L�X�g�o�́AExcel�o��]
            //�e�L�X�g�o�̓I�v�V�������L���̏ꍇ
            if (this._opt_TextOutput == 1)
            {
                // �e�L�X�g�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = true;
                // EXCEL�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = true;
                // �ݒ�
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = true;
            }
            //�e�L�X�g�o�̓I�v�V�����������̏ꍇ
            else
            {
                // �e�L�X�g�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = false;
                // EXCEL�o��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = false;
                // �ݒ�
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = false;
            }
            // ���쌠���̐���
            if (!OpeAuthDictionary[OperationCode.TextOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Shortcut = Shortcut.None;
            }
            if (!OpeAuthDictionary[OperationCode.ExcelOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Shortcut = Shortcut.None;
            }
            if ((!OpeAuthDictionary[OperationCode.TextOut]) && (!OpeAuthDictionary[OperationCode.ExcelOut])) // ADD 2010/08/23
            {
                // �ݒ�
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = false; // ADD 2010/08/23
            }
            #endregion
        }

        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        public enum OperationCode : int
        {
            /// <summary>�e�L�X�g�o��</summary>
            TextOut = 1,
            /// <summary>�G�N�Z���o��</summary>
            ExcelOut = 2
        }

        /// <summary>���쌠���̐���I�u�W�F�N�g</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("PMHNB04160U", this);
                }
                return _operationAuthority;
            }
        }
        /// <summary>���쌠���̐��䃊�X�g</summary>
        private Dictionary<OperationCode, bool> OpeAuthDictionary
        {
            get
            {
                if (_operationAuthorityList == null)
                {
                    _operationAuthorityList = new Dictionary<OperationCode, bool>();
                    _operationAuthorityList.Add(OperationCode.TextOut, !MyOpeCtrl.Disabled((int)OperationCode.TextOut));
                    _operationAuthorityList.Add(OperationCode.ExcelOut, !MyOpeCtrl.Disabled((int)OperationCode.ExcelOut));
                }
                return _operationAuthorityList;
            }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̏����l��ݒ肷��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ToolBarInitilSetting()
        {
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
            int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode);

            // ���O�C���S���ҋ��_���̂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginSectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["Label_SectionName"];
            //loginSectionNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.BelongSectionName;
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                loginSectionNameLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
            }
            loginSectionNameLabel.SharedProps.Visible = true;

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }

        /// <summary>
        /// �R���{�{�b�N�X�̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���{�{�b�N�X��ݒ肷��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ComboInitialSetting()
        {
            //�Q�Ƌ敪
            this.tComboEditor_Refer.Items.Clear();
            this.tComboEditor_Refer.Items.Add(1, "�S����");
            this.tComboEditor_Refer.Items.Add(2, "�󒍎�");
            this.tComboEditor_Refer.Items.Add(3, "���s��");
            this.tComboEditor_Refer.MaxDropDownItems = this.tComboEditor_Refer.Items.Count;
            this.tComboEditor_Refer.SelectedIndex = 0;

            //���ԋ敪
            this.tComboEditor_During.Items.Clear();
            this.tComboEditor_During.Items.Add(1, "���v");
            this.tComboEditor_During.Items.Add(2, "���v");
            this.tComboEditor_During.Items.Add(3, "����");
            this.tComboEditor_During.MaxDropDownItems = this.tComboEditor_During.Items.Count;
            this.tComboEditor_During.SelectedIndex = 0;
        }

        /// <summary>
        /// �A�C�R���̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A�C�R����ݒ肷��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            Infragistics.Win.UltraWinToolbars.ButtonTool clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            Infragistics.Win.UltraWinToolbars.LabelTool sectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            Infragistics.Win.UltraWinToolbars.LabelTool loginLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            // --- ADD 2010/07/20-------------------------------->>>>>
            Infragistics.Win.UltraWinToolbars.ButtonTool textButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"];
            Infragistics.Win.UltraWinToolbars.ButtonTool excelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"];
            Infragistics.Win.UltraWinToolbars.ButtonTool setUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            // --- ADD 2010/07/20 --------------------------------<<<<<

            closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            loginLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // --- ADD 2010/07/20-------------------------------->>>>>
            textButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            excelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            setUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            // --- ADD 2010/07/20 --------------------------------<<<<<


            this.uButton_Section.ImageList = this._imageList16;
            this.uButton_St_EmployeeCode.ImageList = this._imageList16;
            this.ultraButton_Ed_EmployeeCode.ImageList = this._imageList16;

            this.uButton_Section.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_St_EmployeeCode.Appearance.Image = (int)Size16_Index.STAR1;
            this.ultraButton_Ed_EmployeeCode.Appearance.Image = (int)Size16_Index.STAR1;

        }

        /// <summary>
        /// �X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       :�X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void SetStatusBarMessage(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }

        # region [ChangeFocus]
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���L�[�ł̃t�H�[�J�X�ړ��C�x���g���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            SetStatusBarMessage(this, "");

            // ���̎擾 ============================================ //
            # region [���̎擾]
            switch (e.PrevCtrl.Name)
            {
                //-----------------------------------------------------
                // ���_
                //-----------------------------------------------------
                case "tEdit_SectionCodeAllowZero":
                    {
                        if (!WHOLE_SECTION_CODE.Equals(tEdit_SectionCodeAllowZero.Text))
                        {
                            // �I�t���C����ԃ`�F�b�N	
                            // �I�t���C����ԃ`�F�b�N	
                            if (!CheckOnline())
                            {
                                TMsgDisp.Show(
                                    emErrorLevel.ERR_LEVEL_STOP,
                                    "���_",
                                    "���_" + "�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

                                tEdit_SectionCodeAllowZero.Text = _paraEmployeeResultsSlipCache_Display.SectionCode;
                                uLabel_SectionName.Text = _paraEmployeeResultsSlipCache_Display.SectionCodeNm;
                                break;
                            }
                        }
                        else
                        {
                            tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
                            uLabel_SectionName.Text = WHOLE_SECTION_NAME;
                            _paraEmployeeResultsSlipCache_Display.SectionCode = WHOLE_SECTION_CODE;
                            _paraEmployeeResultsSlipCache_Display.SectionCodeNm = WHOLE_SECTION_NAME;

                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            e.NextCtrl = this.tComboEditor_Refer;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                int DuringType = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                                if (1 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // �ړ���
                                        e.NextCtrl = this.tDateEdit_Ed_During;
                                    }
                                }
                                else if (2 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // �ړ���
                                        e.NextCtrl = this.tDateEdit_Ed_YearMonth;
                                    }
                                }
                                else if (3 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // �ړ���
                                        e.NextCtrl = this.tComboEditor_During;
                                    }
                                }
                            }
                        }

                        # region [���_]

                        bool status;

                        if (tEdit_SectionCodeAllowZero.Text == _paraEmployeeResultsSlipCache_Display.SectionCode
                            && (!string.IsNullOrEmpty(uLabel_SectionName.Text)) && (WHOLE_SECTION_NAME.Equals(uLabel_SectionName.Text)))
                        {
                            _paraEmployeeResultsSlipCache_Display.SectionCode = WHOLE_SECTION_CODE;
                            _paraEmployeeResultsSlipCache_Display.SectionCodeNm = WHOLE_SECTION_NAME;
                            this.tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
                            this.uLabel_SectionName.Text = WHOLE_SECTION_NAME;
                            status = true;
                            break;
                        }
                        else
                        {
                            string zeroSec = tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            if (!string.IsNullOrEmpty(tEdit_SectionCodeAllowZero.Text))
                            {

                                string code;
                                string name;

                                // ���_�ǂݍ���
                                //status = ReadSection(tEdit_SectionCodeAllowZero.Text, out code, out name);
                                status = ReadSection(zeroSec, out code, out name);

                                // �R�[�h�E���̂��X�V
                                if (status)
                                {
                                    tEdit_SectionCodeAllowZero.Text = code.TrimEnd();
                                    _paraEmployeeResultsSlipCache_Display.SectionCode = code.TrimEnd();
                                    if (!string.IsNullOrEmpty(name))
                                    {
                                        _paraEmployeeResultsSlipCache_Display.SectionCodeNm = name.TrimEnd();
                                    }
                                    uLabel_SectionName.Text = name;
                                }
                            }
                            else
                            {
                                // �p�����[�^�ɕۑ�
                                tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
                                _paraEmployeeResultsSlipCache_Display.SectionCode = WHOLE_SECTION_CODE;
                                _paraEmployeeResultsSlipCache_Display.SectionCodeNm = WHOLE_SECTION_NAME;
                                uLabel_SectionName.Text = WHOLE_SECTION_NAME;
                                status = true;
                            }
                        }

                        if (status == true)
                        {
                            isError = false; // ADD 2010/09/21
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            //if (_paraEmployeeResultsSlipCache_Display.SectionCode == WHOLE_SECTION_NAME)
                                            //{
                                            //    e.NextCtrl = this.uButton_Section;
                                            //}
                                            //else
                                            //{
                                            e.NextCtrl = this.tComboEditor_Refer;
                                            //}
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                int DuringType = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                                if (1 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // �ړ���
                                        e.NextCtrl = this.tDateEdit_Ed_During;
                                    }
                                }
                                else if (2 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // �ړ���
                                        e.NextCtrl = this.tDateEdit_Ed_YearMonth;
                                    }
                                }
                                else if (3 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // �ړ���
                                        e.NextCtrl = this.tComboEditor_During;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            tEdit_SectionCodeAllowZero.Text = _paraEmployeeResultsSlipCache_Display.SectionCode;
                            uLabel_SectionName.Text = _paraEmployeeResultsSlipCache_Display.SectionCodeNm;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            checkFlg = true; //ADD 2010/08/12 ��QID:13038�Ή�
                            isError = true; // ADD 2010/09/21
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // �S����(�J�n)
                //-----------------------------------------------------
                case "tEdit_EmployeeCode_St":
                    {
                        if (!string.IsNullOrEmpty(tEdit_EmployeeCode_St.DataText))
                        {
                            // �I�t���C����ԃ`�F�b�N	
                            if (!CheckOnline())
                            {
                                // �I�t���C����ԃ`�F�b�N	
                                if (!CheckOnline())
                                {
                                    TMsgDisp.Show(
                                        emErrorLevel.ERR_LEVEL_STOP,
                                        "�S����(�J�n)",
                                        "�S����(�J�n)" + "�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                }
                                tEdit_EmployeeCode_St.DataText = _paraEmployeeResultsSlipCache_Display.St_EmployeeCode;
                                uLabel_SalesEmployeeNm_St.Text = _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm;
                                break;
                            }
                        }
                        else
                        {
                            tEdit_EmployeeCode_St.DataText = string.Empty;
                            uLabel_SalesEmployeeNm_St.Text = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.St_EmployeeCode = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm = string.Empty;
                            break;
                        }

                        # region [�S����]
                        bool status;

                        // ���͖���
                        if (string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.Text.Trim()))
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            _paraEmployeeResultsSlipCache_Display.St_EmployeeCode = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm = string.Empty;
                            this.uLabel_SalesEmployeeNm_St.Text = string.Empty;
                            this.tEdit_EmployeeCode_St.Text = string.Empty;
                            status = true;

                            break;
                        }

                        string zerotcode_St = tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                        tEdit_EmployeeCode_St.Text = zerotcode_St; // ADD 2010/09/21
                        if ((zerotcode_St.Equals(_paraEmployeeResultsSlipCache_Display.St_EmployeeCode))
                            && (!string.IsNullOrEmpty(uLabel_SalesEmployeeNm_St.Text)))
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // �ǂݍ���
                            status = ReadEmployee(zerotcode_St, out code, out name);

                            // �R�[�h�E���̂��X�V
                            if (status)
                            {
                                //tEdit_EmployeeCode_St.Text = code.TrimEnd();
                                if (!string.IsNullOrEmpty(name))
                                {
                                    uLabel_SalesEmployeeNm_St.Text = name.TrimEnd();
                                }
                                _paraEmployeeResultsSlipCache_Display.St_EmployeeCode = code.TrimEnd();

                                if (!string.IsNullOrEmpty(name))
                                {
                                    _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm = name.TrimEnd();
                                }
                            }
                            //uLabel_StockAgentName.Text = name;
                        }

                        if (status == true)
                        {
                            isError = false; // ADD 2010/09/21
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_paraEmployeeResultsSlipCache_Display.St_EmployeeCode == string.Empty)
                                            {
                                                e.NextCtrl = this.uButton_St_EmployeeCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            tEdit_EmployeeCode_St.DataText = _paraEmployeeResultsSlipCache_Display.St_EmployeeCode;
                            uLabel_SalesEmployeeNm_St.Text = _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�]�ƈ������݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            checkFlg = true; //ADD 2010/08/12 ��QID:13038�Ή�
                            isError = true; // ADD 2010/09/21
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // �S����(�I��)
                //-----------------------------------------------------
                case "tEdit_EmployeeCode_Ed":
                    {
                        if (!string.IsNullOrEmpty(tEdit_EmployeeCode_Ed.DataText))
                        {
                            // �I�t���C����ԃ`�F�b�N	
                            if (!CheckOnline())
                            {
                                // �I�t���C����ԃ`�F�b�N	
                                if (!CheckOnline())
                                {
                                    TMsgDisp.Show(
                                        emErrorLevel.ERR_LEVEL_STOP,
                                        "�S����(�I��)",
                                        "�S����(�I��)" + "�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                }
                                tEdit_EmployeeCode_Ed.DataText = _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode;
                                uLabel_SalesEmployeeNm_Ed.Text = _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm;
                                break;
                            }
                        }
                        else
                        {
                            tEdit_EmployeeCode_Ed.DataText = string.Empty;
                            uLabel_SalesEmployeeNm_Ed.Text = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm = string.Empty;
                            break;
                        }

                        # region [�S����]
                        bool status;

                        // ���͖���
                        if (string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.Text.Trim()))
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm = string.Empty;
                            this.uLabel_SalesEmployeeNm_Ed.Text = string.Empty;
                            this.tEdit_EmployeeCode_Ed.Text = string.Empty;
                            status = true;

                            break;
                        }

                        string zerotcode_Ed = tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                        tEdit_EmployeeCode_Ed.Text = zerotcode_Ed; // ADD 2010/09/21
                        if ((zerotcode_Ed.Equals(_paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode))
                            && (!string.IsNullOrEmpty(uLabel_SalesEmployeeNm_Ed.Text)))
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // �ǂݍ���
                            status = ReadEmployee(zerotcode_Ed, out code, out name);

                            // �R�[�h�E���̂��X�V
                            if (status)
                            {
                                //tEdit_EmployeeCode_Ed.Text = code.TrimEnd();
                                _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode = code.TrimEnd();
                                if (!string.IsNullOrEmpty(name))
                                {
                                    uLabel_SalesEmployeeNm_Ed.Text = name.TrimEnd();
                                    _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm = name.TrimEnd();
                                }
                            }
                            //uLabel_StockAgentName.Text = name;
                        }

                        if (status == true)
                        {
                            isError = false; // ADD 2010/09/21
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode == string.Empty)
                                            {
                                                e.NextCtrl = this.ultraButton_Ed_EmployeeCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_During;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // �ړ���
                                    if (string.IsNullOrEmpty(uLabel_SalesEmployeeNm_St.Text))
                                    {
                                        e.NextCtrl = this.uButton_St_EmployeeCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            tEdit_EmployeeCode_Ed.DataText = _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode;
                            uLabel_SalesEmployeeNm_Ed.Text = _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�]�ƈ������݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            checkFlg = true; //ADD 2010/08/12 ��QID:13038�Ή�
                            isError = true; // ADD 2010/09/21
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // ���ԁi�I���j
                //-----------------------------------------------------
                case "tDateEdit_Ed_During":
                case "tDateEdit_Ed_YearMonth":
                    {
                        # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �ړ����Ȃ�
                                        e.NextCtrl = this._inputDetails;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            int DuringType = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                            if (1 == DuringType)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // �ړ���
                                    e.NextCtrl = this.tDateEdit_St_During;
                                }
                            }
                            else if (2 == DuringType)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // �ړ���
                                    e.NextCtrl = this.tDateEdit_St_YearMonth;
                                }
                            }
                            else if (3 == DuringType)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // �ړ���
                                    e.NextCtrl = this.tComboEditor_During;
                                }
                            }
                        }
                        # endregion
                    }
                    break;
                case "tComboEditor_During":
                    {
                        # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if (e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �ړ����Ȃ�
                                        if (string.IsNullOrEmpty(uLabel_SalesEmployeeNm_Ed.Text))
                                        {
                                            e.NextCtrl = this.ultraButton_Ed_EmployeeCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                                        }
                                        break;
                                    }
                            }
                        }
                        # endregion
                    }
                    break;
                case "tComboEditor_Refer":
                    {
                        # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if (e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �ړ����Ȃ�
                                        if (string.IsNullOrEmpty(uLabel_SectionName.Text))
                                        {
                                            e.NextCtrl = this.uButton_Section;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        break;
                                    }
                            }
                        }
                        # endregion
                    }
                    break;
            }
            # endregion
        }

        # endregion [ChangeFocus]

        # region [ChangeFocus����Read����]
        /// <summary>
        /// ���_Read
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="code">���_�R�[�h</param>
        /// <param name="name">���_����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���_Read���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private bool ReadSection(string sectionCode, out string code, out string name)
        {
            bool result = false;

            // �����͔���
            if (sectionCode != string.Empty && sectionCode != WHOLE_SECTION_CODE) // 2009.01.06 add [9693]
            {
                // �ǂݍ���
                if (_secInfoSetAcs == null)
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, sectionCode);

                //if (status == 0 && secInfoSet != null) // DEL 2010/09/21
                if (status == 0 && secInfoSet != null && secInfoSet.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    // �Y�����聨�\��
                    code = secInfoSet.SectionCode.TrimEnd();
                    name = secInfoSet.SectionGuideNm;

                    result = true;
                }
                else
                {
                    code = WHOLE_SECTION_CODE;
                    name = WHOLE_SECTION_NAME;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                code = WHOLE_SECTION_CODE;
                name = WHOLE_SECTION_NAME;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// �]�ƈ�Read
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="code">�]�ƈ��R�[�h</param>
        /// <param name="name">�]�ƈ�����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ�Read���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private bool ReadEmployee(string employeeCode, out string code, out string name)
        {
            bool result = false;

            // �����͔���
            if (employeeCode != string.Empty)
            {
                // �ǂݍ���
                if (_employeeAcs == null)
                {
                    _employeeAcs = new EmployeeAcs();
                }
                Employee employee;
                int status = _employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

                //if (status == 0 && employee != null) // DEL 2010/09/21
                if (status == 0 && employee != null && employee.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    // �Y�����聨�\��
                    code = employee.EmployeeCode.TrimEnd();
                    name = employee.Name;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        # endregion

        # region [���̓`�F�b�N]
        /// <summary>
        /// ���͍��ڃ`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͍��ڃ`�F�b�N�������s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        //private Control CheckInputPara() // DEL 2010/07/20
        private Control CheckInputPara(bool msgFlg) // ADD 2010/07/20
        {
            string errMessage = null;

            # region ���݃`�F�b�N
            //���_�R�[�h
            string code;
            string name;
            bool existFlg = false;
            if (!string.IsNullOrEmpty(tEdit_SectionCodeAllowZero.Text))
            {
                // ���_�ǂݍ���
                existFlg = ReadSection(tEdit_SectionCodeAllowZero.Text, out code, out name);
                if (!existFlg)
                {
                    errMessage = "�Y�����鋒�_�����݂��܂���B";
                    if (msgFlg) // ADD 2010/07/20
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                errMessage,
                                0,
                                MessageBoxButtons.OK);
                    tEdit_SectionCodeAllowZero.Focus();
                    return tEdit_SectionCodeAllowZero;
                }
            }

            //�S���҃R�[�h�i�J�n�j���@�S���҃R�[�h�i�I���j�̃`�F�b�N
            if (!string.IsNullOrEmpty(tEdit_EmployeeCode_St.Text) && !string.IsNullOrEmpty(tEdit_EmployeeCode_Ed.Text))
            {
                if (tEdit_EmployeeCode_St.DataText.Trim().PadLeft(4, '0').CompareTo(
                    tEdit_EmployeeCode_Ed.DataText.Trim().PadLeft(4, '0')) >= 1)
                {
                    errMessage = "�S���Ҕ͈͂̎w��Ɍ�肪����܂��B";
                    if (msgFlg) // ADD 2010/07/20
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    errMessage,
                                    0,
                                    MessageBoxButtons.OK);

                    if ("tEdit_EmployeeCode_St".Equals(this._prevControl.Name))
                    {
                        tEdit_EmployeeCode_St.Focus();
                    }
                    else if ("tEdit_EmployeeCode_Ed".Equals(this._prevControl.Name))
                    {
                        tEdit_EmployeeCode_Ed.Focus();
                    }
                    else
                    {
                        tEdit_EmployeeCode_St.Focus();
                    }
                    return tEdit_EmployeeCode_St;
                }
            }
            # endregion ���݃`�F�b�N


            # region �K�{���̓`�F�b�N

            //���ԋ敪
            int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);

            //���t
            DateGetAcs.CheckDateRangeResult cdrResult;

            if (duringFlg == 1)
            {
                // ���ԁi�J�n�`�I���j
                if (CallCheckDateForYearMonthDayRange(out cdrResult, ref tDateEdit_St_During, ref tDateEdit_Ed_During) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("����(�J�n){0}", MESSAGE_NoInput);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("����(�J�n){0}", ct_InputError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("����(�I��){0}", ct_NoInput);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_Ed_During.Focus();
                                return tDateEdit_Ed_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("����(�I��){0}", ct_InputError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_Ed_During.Focus();
                                return tDateEdit_Ed_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("����{0}", ct_RangeError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;

                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                            {
                                errMessage = string.Format("�J�n�E�I�����t{0}", ct_NotOnMonthError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("����{0}", ct_RangeOverError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;
                            }
                    }
                }
            }
            else if (duringFlg == 2)
            {
                // ���ԁi�J�n�`�I���j
                if (CallCheckDateForYearMonthRange(out cdrResult, ref tDateEdit_St_YearMonth, ref tDateEdit_Ed_YearMonth) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("����(�J�n){0}", ct_NoInput);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("����(�J�n){0}", ct_InputError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("����(�I��){0}", ct_NoInput);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_Ed_YearMonth.Focus();
                                return tDateEdit_Ed_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("����(�I��){0}", ct_InputError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_Ed_YearMonth.Focus();
                                return tDateEdit_Ed_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("����{0}", ct_RangeError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;

                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("����{0}", ct_RangeYearMonthOverError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                            {
                                errMessage = string.Format("�J�n�E�I���N��{0}", ct_NotOnYearError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;
                            }
                    }
                }
            }

            # endregion �K�{���̓`�F�b�N


            return null;
        }
        #endregion

        #region �� �N�����̓`�F�b�N����

        /// <summary>
        /// ���t((YYYYMM))�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDateEdit"></param>
        /// <param name="endDateEdit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���t�`�F�b�N�����Ăяo�����s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.01.05</br>
        /// </remarks>
        public bool CallCheckDateForYearMonthRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit)
        {
            // --- DEL 2010/07/20-------------------------------->>>>>
            ////���ԋ敪
            //int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);

            //if (duringFlg == 2)
            //{
            // --- DEL 2010/07/20--------------------------------<<<<<
                // �����̏ꍇ�A�N�x�ׂ�̃`�F�b�N�Ȃ�
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref startDateEdit, ref endDateEdit, false, true);
            // --- DEL 2010/07/20-------------------------------->>>>>
            //}
            //else
            //{
            //    // �������܂ޏꍇ�A�N�x�ׂ���`�F�b�N
            //    cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref startDateEdit, ref endDateEdit, false, true);

            //    //if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear)
            //    //{
            //    //    // �N�x�ׂ�ȊO���ă`�F�b�N
            //    //    cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref startDateEdit, ref endDateEdit, false);

            //    //    if (cdrResult == DateGetAcs.CheckDateRangeResult.OK)
            //    //    {
            //    //        // �N�x�ׂ�G���[�̏ꍇ�͓����ɂ���
            //    //        this.PrintType_ultraOptionSet.CheckedIndex = 0;
            //    //    }
            //    //}
            //}
            // --- DEL 2010/07/20--------------------------------<<<<<


            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���t(YYYYMMDD)�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.01.05</br>
        /// </remarks>
        public bool CallCheckDateForYearMonthDayRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="control">�`�F�b�N�ΏۃR���g���[��</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.05</br>
        /// </remarks>
        private bool InputDateYYYYMMDDEditCheack(TDateEdit control)
        {
            // ���t�𐔒l�^�Ŏ擾
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // ���t�����̓`�F�b�N
            if (date == 0) return false;

            // �V�X�e���T�|�[�g�`�F�b�N
            if (yy < 1900) return false;

            // �N�E���E���ʓ��̓`�F�b�N
            switch (control.DateFormat)
            {
                // �N�E���E���\����
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;
                // �N�E��    �\����
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;
                // �N        �\����
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;
                // ���E���@�@�\����
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;
                // ��        �\����
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;
                // ��        �\����
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            DateTime dt = TDateTime.LongDateToDateTime("YYYYMMDD", date);
            // �P�����t�Ó����`�F�b�N
            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;
        }


        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="control">�`�F�b�N�ΏۃR���g���[��</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.08</br>
        /// </remarks>
        private bool InputDateYYYYMMEditCheack(TDateEdit control)
        {
            // ���t�𐔒l�^�Ŏ擾
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // ���t�����̓`�F�b�N
            if (date == 0) return false;

            // �V�X�e���T�|�[�g�`�F�b�N
            if (yy < 1900) return false;

            // �N�E���E���ʓ��̓`�F�b�N
            switch (control.DateFormat)
            {
                // �N�E���E���\����
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;
                // �N�E��    �\����
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;
                // �N        �\����
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;
                // ���E���@�@�\����
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;
                // ��        �\����
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;
                // ��        �\����
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            DateTime dt = TDateTime.LongDateToDateTime("YYYYMM", date / 100);
            // �P�����t�Ó����`�F�b�N
            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;
        }
        #endregion

        # region [����]
        /// <summary>
        /// �S���ҕʎ��яƉ�����s����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ�Read���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        //private Control SearchEmployeeResults() // DEL 2010/07/20
        private Control SearchEmployeeResults(bool msgFlg) // ADD 2010/07/20
        {
            // ----- ADD 2010/09/21 ---------------------------->>>>>
            if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                this._prevControl = this.tEdit_SectionCodeAllowZero;
            }
            else if (this.tEdit_EmployeeCode_St.Focused)
            {
                this._prevControl = this.tEdit_EmployeeCode_St;
            }
            else if (this.tEdit_EmployeeCode_Ed.Focused)
            {
                this._prevControl = this.tEdit_EmployeeCode_Ed;
            }
            // ----- ADD 2010/09/21 ----------------------------<<<<<
            if (this._prevControl != null)
            {
                //hasCheckError = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
                // ----- ADD 2010/09/21 ---------------------------->>>>>
                if (isError == true)
                {
                    return null;
                }
                // ----- ADD 2010/09/21 ----------------------------<<<<<
            }

            // ���͍��ڃ`�F�b�N����
            //Control control = this.CheckInputPara(); // DEL 2010/07/20
            Control control = this.CheckInputPara(msgFlg); // ADD 2010/07/20

            if (control != null)
            {
                return control;
            }

            EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();

            // �Ǎ������p�����[�^�N���X�ݒ菈��
            this.SetReadPara(out employeeResultsCtdtn);

            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                // �I�t���C����ԃ`�F�b�N	
                //if (!CheckOnline()) // DEL 2010/07/20
                if (!CheckOnline() && msgFlg) // ADD 2010/07/20
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,
                        "�S���ҕʎ��яƉ�",
                        "�S���ҕʎ��яƉ�" + "�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                return control;
            }

            // �S���ҕʎ��яƉ���Ǎ��E�f�[�^�Z�b�g�i�[����
            if (this._employeeResultsAcs.SetSearchData(employeeResultsCtdtn) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCodeAllowZero.Focus();
            }
            else
            {
                if (msgFlg) // ADD 2010/07/20
                { // ADD 2010/07/20
                    TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�Y���f�[�^�����݂��܂���B",
                                0,
                                MessageBoxButtons.OK);
                } // ADD 2010/07/20
            }



            return null;
        }
        # endregion

        /// <summary>
        /// �t�H�[���I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���I���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void PMHNB04161UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        #region �l�ύX�㔭���C�x���g
        /// <summary>
        /// ���ԋ敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���ԋ敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tComboEditor_During_ValueChanged(object sender, EventArgs e)
        {
            //���ԋ敪flg
            int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
            if (duringFlg == 1)
            {
                uLabel_During_From_To.Visible = true;

                //����(�J�n)YYYYMMDD
                tDateEdit_St_During.Visible = true;

                //����(�I��)YYYYMMDD
                tDateEdit_Ed_During.Visible = true;


                //����(�J�n)YYYYMM
                tDateEdit_St_YearMonth.Visible = false;

                //����(�I��)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = false;

                uLabel_To_OutputDay.Visible = true;

                // �����
                DateTime staratDate;
                DateTime endDate;
                this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

                if (tDateEdit_St_During.GetDateTime().Equals(DateTime.MinValue))
                {
                    //����(�J�n)YYYYMMDD
                    this.tDateEdit_St_During.Visible = true;
                    this.tDateEdit_St_During.Clear();
                    this.tDateEdit_St_During.SetDateTime(staratDate);
                }

                if (tDateEdit_Ed_During.GetDateTime().Equals(DateTime.MinValue))
                {
                    //����(�I��)YYYYMMDD
                    this.tDateEdit_Ed_During.Visible = true;
                    this.tDateEdit_Ed_During.Clear();
                    this.tDateEdit_Ed_During.SetDateTime(endDate);
                }

                this._inputDetails.InitialSettingGridCol(1);

            }
            else if (duringFlg == 2)
            {
                uLabel_During_From_To.Visible = true;

                //����(�J�n)YYYYMMDD
                tDateEdit_St_During.Visible = false;

                //����(�I��)YYYYMMDD
                tDateEdit_Ed_During.Visible = false;


                //����(�J�n)YYYYMM
                tDateEdit_St_YearMonth.Visible = true;

                //����(�I��)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = true;

                uLabel_To_OutputDay.Visible = true;


                // ������ݒ�
                DateTime nowYearMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;
                int thisYear;

                this._dateGet.GetThisYearMonth(out nowYearMonth, out thisYear, out startMonthDate, out endMonthDate);

                if (tDateEdit_St_YearMonth.GetDateTime().Equals(DateTime.MinValue))
                {
                    this.tDateEdit_St_YearMonth.SetDateTime(startMonthDate);
                }

                if (tDateEdit_Ed_YearMonth.GetDateTime().Equals(DateTime.MinValue))
                {
                    this.tDateEdit_Ed_YearMonth.SetDateTime(endMonthDate);
                }
                this._inputDetails.InitialSettingGridCol(2);
            }
            else
            {

                uLabel_During_From_To.Visible = false;

                //����(�J�n)YYYYMMDD
                tDateEdit_St_During.Visible = false;

                //����(�I��)YYYYMMDD
                tDateEdit_Ed_During.Visible = false;


                //����(�J�n)YYYYMM
                tDateEdit_St_YearMonth.Visible = false;

                //����(�I��)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = false;

                uLabel_To_OutputDay.Visible = false;

                //������ݒ�
                DateTime nowYearMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;
                DateTime startYearDate;
                DateTime endYearDate;
                int thisYear;

                this._dateGet.GetThisYearMonth(out nowYearMonth, out thisYear, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate);

                this.tDateEdit_St_YearMonth.SetDateTime(startYearDate);
                this.tDateEdit_Ed_YearMonth.SetDateTime(endYearDate);

                this._inputDetails.InitialSettingGridCol(3);

            }

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();
        }

        /// <summary>
        /// �Q�Ƌ敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Q�Ƌ敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tComboEditor_Refer_ValueChanged(object sender, EventArgs e)
        {
            //�Q�Ƌ敪flg
            int duringFlg = Convert.ToInt32(tComboEditor_Refer.SelectedItem.DataValue);

            if (duringFlg == 1)
            {
                uLabel_EmployeeCode.Text = SALESINPUT_NAME;
            }
            else if (duringFlg == 2)
            {
                uLabel_EmployeeCode.Text = FRONTEMPLOYEE_SECTION_NAME;
            }
            else
            {
                uLabel_EmployeeCode.Text = SALESEMPLOYEE_NAME;
            }

            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();
            // ---ADD 2010/10/09 --------------------->>>
            if (this._userSetupFrm != null)
            {
                this._userSetupFrm.ReferDiv = duringFlg;
                this._userSetupFrm.AnalysisTextSettingAcs.ReferDivValue = duringFlg;
                this._userSetupFrm.AnalysisTextSettingAcs.AnalysisTextSetting.ReferDivValue = duringFlg;
            }
            // ---ADD 2010/10/09 ---------------------<<<


        }


        /// <summary>
        /// ���_�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���_�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_ValueChanged(object sender, EventArgs e)
        {
            if (!this._sectionCodeAllowZero.Trim().PadLeft(2, '0').Equals(tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0'))) // ADD 2010/09/28 ��Q�� #15609 
            { // ADD 2010/09/28 ��Q�� #15609 
                ClearDetail();

                this.isSearch = false; // ADD 2010/09/21

                this._employeeResultsAcs.ClearEmployeeResultsDataTable();
            } // ADD 2010/09/28 ��Q�� #15609 
        }


        /// <summary>
        /// �S���҃R�[�h�i�J�n�j�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �S���҃R�[�h�i�J�n�j�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tEdit_EmployeeCode_St_ValueChanged(object sender, EventArgs e)
        {
            if (!this._employeeCodeSt.Trim().PadLeft(4, '0').Equals(tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0'))) // ADD 2010/09/28 ��Q�� #15609 
            { // ADD 2010/09/28 ��Q�� #15609 
                ClearDetail();

                this.isSearch = false; // ADD 2010/09/21

                this._employeeResultsAcs.ClearEmployeeResultsDataTable();
            } // ADD 2010/09/28 ��Q�� #15609 

        }


        /// <summary>
        /// �S���҃R�[�h�i�I���j�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �S���҃R�[�h�i�I���j�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tEdit_EmployeeCode_Ed_ValueChanged(object sender, EventArgs e)
        {
            if (!this._employeeCodeEd.Trim().PadLeft(4, '0').Equals(tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0'))) // ADD 2010/09/28 ��Q�� #15609 
            { // ADD 2010/09/28 ��Q�� #15609 
                ClearDetail();

                this.isSearch = false; // ADD 2010/09/21

                this._employeeResultsAcs.ClearEmployeeResultsDataTable();
            } // ADD 2010/09/28 ��Q�� #15609 

        }


        /// <summary>
        /// ���ԁi�J�n�j�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���ԁi�J�n�j�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tDateEdit_St_YearMonth_ValueChanged(object sender, EventArgs e)
        {
            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();

        }


        /// <summary>
        /// ����(�I��)�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ����(�I��)�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tDateEdit_Ed_YearMonth_ValueChanged(object sender, EventArgs e)
        {
            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();
        }


        /// <summary>
        /// ���ԁi�J�n�j�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���ԁi�J�n�j�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tDateEdit_St_During_ValueChanged(object sender, EventArgs e)
        {
            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();

        }


        /// <summary>
        /// ����(�I��)�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ����(�I��)�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tDateEdit_Ed_During_ValueChanged(object sender, EventArgs e)
        {
            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();
        }

        /// <summary>
        /// ��ʃw�b�_�N���A����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ��ʃw�b�_�N���A�������s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ClearDetail()
        {
            if (tComboEditor_During.SelectedItem != null)
            {
                int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                if (duringFlg == 1)
                {
                    this._inputDetails.InitialSettingGridCol(1);
                }
                else if (duringFlg == 2)
                {
                    this._inputDetails.InitialSettingGridCol(2);
                }
                else
                {
                    this._inputDetails.InitialSettingGridCol(3);
                }
            }
        }

        #endregion

        #endregion

        #region �� Event
        /// <summary>�t�H�[�����[�h</summary>
        /// <param name="sender">�C�x���g�̃\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^���i�[���Ă���<see cref="EventArgs"/>�B</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�����[�h�������s��</br>
        /// <br>Programmer	: ���痈</br>	
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private void PMHNB04161UA_Load(object sender, EventArgs e)
        {
            this.panel_Detail.Controls.Add(this._inputDetails);
            this._inputDetails.Dock = DockStyle.Fill;
            this._inputDetails.InitialSettingGridCol(1);
            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �����_�R�[�h���擾����
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();

            this.ToolBarInitilSetting();
            this.ButtonInitialSetting();
            this.ComboInitialSetting();

            // ���ɖ߂�����
            this.ClearDisplayHeader();
            this.SetDisplayHeaderInfo();
            this._employeeResultsAcs.ClearEmployeeResultsDataTable();

            this.tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
            uLabel_SectionName.Text = WHOLE_SECTION_NAME;


        }

        #endregion

        #region �� �I�t���C����ԃ`�F�b�N����

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
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
        /// <br>Note       : �����[�g�ڑ��\���菈�����s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
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

        # region �� �e�R���g���[���C�x���g����

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       :�c�[���o�[�{�^���N���b�N�C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Note       : �S���ҕʎ��яƉ����ǂݍ��݂܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // �ꊇ�[���l�ߏ���	
            //uiSetControl1.SettingAllControlsZeroPaddedText(); // DEL 2010/07/20
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        // �I������
                        this.CloseForm();
                        break;
                    }
                case "ButtonTool_Search":
                    {

                        // ��������
                        //SearchEmployeeResults(); // DEL 2010/07/20
                        SearchEmployeeResults(true); // ADD 2010/07/20
                        this.isSearch = true; // ADD 2010/09/14
                        break;

                    }
                case "ButtonTool_Clear":
                    {

                        this.ClearDisplayHeader();
                        this.SetDisplayHeaderInfo();
                        this._employeeResultsAcs.ClearEmployeeResultsDataTable();
                        this.isSearch = false; // ADD 2010/09/14

                        // �����t�H�[�J�X
                        this.SetInitFocus(this);

                        break;
                    }
                // --- ADD 2010/07/20-------------------------------->>>>>
                case "ButtonTool_Text":
                    {
                        this.ExportIntoTextFile(false);
                        break;
                    }
                case "ButtonTool_Excel":
                    {
                        this.exportIntoExcelData(true);
                        break;
                    }
                case "ButtonTool_Setup":
                    {
                        if (this._userSetupFrm == null)
                            //this._userSetupFrm = new PMHNB04161UD(); // DEL 2010/10/09
                            this._userSetupFrm = new PMHNB04161UD(Convert.ToInt16(this.tComboEditor_Refer.Value)); // ADD 2010/10/09

                        this._userSetupFrm.ShowDialog();
                        break;
                    }
                // --- ADD 2010/07/20 --------------------------------<<<<<
            }
        }
        # endregion

        # region �� [�ǂݍ��ݏ���]

        /// <summary>
        /// �Ǎ������p�����[�^�ݒ菈��
        /// </summary>
        /// <param>�Ǎ������p�����[�^�N���X</param>
        /// <param name="employeeResultsCtdtn">�Ǎ������p�����[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ǎ������p�����[�^�ݒ菈�����s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void SetReadPara(out EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            employeeResultsCtdtn = new EmployeeResultsCtdtn();

            //��ƃR�[�h
            employeeResultsCtdtn.EnterpriseCode = this._enterpriseCode;

            //���_
            employeeResultsCtdtn.SectionCode = this.tEdit_SectionCodeAllowZero.Text;

            //���_����
            employeeResultsCtdtn.SectionCodeNm = this.uLabel_SectionName.Text;
            
            //�Q�Ƌ敪  
            employeeResultsCtdtn.ReferType = Convert.ToInt32(tComboEditor_Refer.SelectedItem.DataValue);
            //�S����(�J�n)
            employeeResultsCtdtn.St_EmployeeCode = this.tEdit_EmployeeCode_St.Text;
            //�S����(�I��)
            employeeResultsCtdtn.Ed_EmployeeCode = this.tEdit_EmployeeCode_Ed.Text;
            //�S���Җ���(�J�n)
            employeeResultsCtdtn.St_EmployeeCodeNm = this.uLabel_SalesEmployeeNm_St.Text;
            //�S���Җ���(�I��)
            employeeResultsCtdtn.Ed_EmployeeCodeNm = this.uLabel_SalesEmployeeNm_Ed.Text;

            //���ԋ敪
            employeeResultsCtdtn.DuringType = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);

            if (employeeResultsCtdtn.DuringType == 1)
            {

                //����(�J�n)YYYYMMDD
                employeeResultsCtdtn.St_DuringTime = tDateEdit_St_During.GetDateTime();

                //����(�I��)YYYYMMDD
                employeeResultsCtdtn.Ed_DuringTime = tDateEdit_Ed_During.GetDateTime();

            }
            else if (employeeResultsCtdtn.DuringType == 2 || employeeResultsCtdtn.DuringType == 3)
            {
                //����(�J�n)YYYYMM
                employeeResultsCtdtn.St_YearMonth = tDateEdit_St_YearMonth.GetDateTime();

                //����(�I��)YYYYMM
                employeeResultsCtdtn.Ed_YearMonth = tDateEdit_Ed_YearMonth.GetDateTime();
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            //��ʃr���[�E�o�̓r���[�t���O  
            employeeResultsCtdtn.ViewFlg = "MAIN";
            // --- ADD 2010/07/20--------------------------------<<<<<

        }

        #endregion

        # region �� �w�b�_����
        /// <summary>
        /// ��ʃw�b�_�N���A����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ��ʃw�b�_�N���A�������s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ClearDisplayHeader()
        {
            // ���_
            this.tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
            this.uLabel_SectionName.Text = WHOLE_SECTION_NAME;
            _paraEmployeeResultsSlipCache_Display.SectionCode = WHOLE_SECTION_CODE;
            _paraEmployeeResultsSlipCache_Display.SectionCodeNm = WHOLE_SECTION_NAME;

            // �Q�Ƌ敪
            this.tComboEditor_Refer.SelectedIndex = 0;

            //���ԋ敪
            this.tComboEditor_During.SelectedIndex = 0;


            //�S����
            tEdit_EmployeeCode_St.Text = string.Empty;
            tEdit_EmployeeCode_Ed.Text = string.Empty;

            uLabel_SalesEmployeeNm_St.Text = string.Empty;
            uLabel_SalesEmployeeNm_Ed.Text = string.Empty;

            // ���͓�
            this.tDateEdit_St_During.Clear();
            this.tDateEdit_Ed_During.Clear();

        }


        /// <summary>
        /// ��ʃw�b�_�\������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ��ʃw�b�_�\���������s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void SetDisplayHeaderInfo()
        {
            // �R���{�{�b�N�X���ڏ����\��
            this.tComboEditor_Refer.SelectedIndex = 0;
            this.tComboEditor_During.SelectedIndex = 0;

            this.uLabel_During_From_To.Visible = true;

            _prevControl = this.tEdit_SectionCodeAllowZero;

            // �����
            DateTime staratDate;
            DateTime endDate;
            this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

            //����(�J�n)YYYYMMDD
            this.tDateEdit_St_During.Visible = true;
            this.tDateEdit_St_During.Clear();
            this.tDateEdit_St_During.SetDateTime(staratDate);

            //����(�I��)YYYYMMDD
            this.tDateEdit_Ed_During.Visible = true;
            this.tDateEdit_Ed_During.Clear();
            this.tDateEdit_Ed_During.SetDateTime(endDate);

            //����(�J�n)YYYYMM
            this.tDateEdit_St_YearMonth.Visible = false;

            //����(�I��)YYYYMM
            this.tDateEdit_Ed_YearMonth.Visible = false;

            this.uLabel_To_OutputDay.Visible = true;


            // ���_�ݒ�
            this.tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
            this.uLabel_SectionName.Text = WHOLE_SECTION_NAME;

        }

        /// <summary>
        /// �_�C�A���O���U���g�ݒ菈��
        /// </summary>
        /// <param name="dialogRes">�_�C�A���O���U���g</param>
        /// <remarks>
        /// <br>Note       : �_�C�A���O���U���g�ݒ菈�����s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        /// <summary>
        /// �t�H�[������\���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04161UA_Shown(object sender, EventArgs e)
        {
            this.SetInitFocus(this);
        }

        /// <summary>
        /// �����t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����t�H�[�J�X�ݒ菈�����s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public Control SetInitFocus(object sender)
        {
            this.tEdit_SectionCodeAllowZero.Focus();
            this.tEdit_SectionCodeAllowZero.SelectAll();
            return this.tEdit_SectionCodeAllowZero;
        }



        # endregion

        #region �� ��ʏI������
        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏI���������s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void CloseForm()
        {
            this.Close();
        }
        #endregion

        # region �� [�K�C�h�{�^���N���b�N]
        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^���N���b�N�C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void uButton_Section_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "���_�K�C�h" + "��ʏ����������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim();
                this._sectionCodeAllowZero = this.tEdit_SectionCodeAllowZero.Text; // ADD 2010/09/21
                _paraEmployeeResultsSlipCache_Display.SectionCode = secInfoSet.SectionCode.Trim();

                _EmployeeResultsCtdtn.SectionCode = secInfoSet.SectionCode.Trim();

                if (!string.IsNullOrEmpty(secInfoSet.SectionGuideNm))
                {
                    uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                    _EmployeeResultsCtdtn.SectionCodeNm = secInfoSet.SectionGuideNm.Trim();

                    _paraEmployeeResultsSlipCache_Display.SectionCodeNm = secInfoSet.SectionGuideNm.Trim();
                }

                // �t�H�[�J�X�ړ�
                tComboEditor_Refer.Focus();
            }
        }

        /// <summary>
        /// �S����(�J�n)�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �S����(�J�n)�K�C�h�{�^���N���b�N�C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void uButton_St_EmployeeCode_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "�]�ƈ��K�C�h" + "��ʏ����������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (_employeeAcs == null)
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_EmployeeCode_St.Text = employee.EmployeeCode.Trim();

                _paraEmployeeResultsSlipCache_Display.St_EmployeeCode = employee.EmployeeCode.Trim();

                if (!string.IsNullOrEmpty(employee.Name))
                {
                    uLabel_SalesEmployeeNm_St.Text = employee.Name.Trim();
                    this._employeeCodeSt = this.tEdit_EmployeeCode_St.Text; // ADD 2010/09/21
                    _EmployeeResultsCtdtn.St_EmployeeCodeNm = employee.Name.Trim();

                    _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm = employee.Name.Trim();
                }
                _EmployeeResultsCtdtn.St_EmployeeCode = employee.EmployeeCode.Trim();

                tEdit_EmployeeCode_Ed.Focus();
            }
        }

        /// <summary>
        /// �S����(�I��)�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �S����(�I��)�K�C�h�{�^���N���b�N�C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ultraButton_Ed_EmployeeCode_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "�]�ƈ��K�C�h" + "��ʏ����������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (_employeeAcs == null)
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.Trim();
                this._employeeCodeEd = this.tEdit_EmployeeCode_Ed.Text; // ADD 2010/09/21
                _EmployeeResultsCtdtn.Ed_EmployeeCode = employee.EmployeeCode.Trim();

                _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode = employee.EmployeeCode.Trim();

                if (!string.IsNullOrEmpty(employee.Name))
                {
                    uLabel_SalesEmployeeNm_Ed.Text = employee.Name.TrimEnd();
                    _EmployeeResultsCtdtn.Ed_EmployeeCodeNm = employee.Name.TrimEnd();

                    _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm = employee.Name.TrimEnd();
                }

                tComboEditor_During.Focus();
            }
        }

        #endregion

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// EXCEL�f�[�^�o��
        /// </summary>
        /// <br>Update Note: 2024/11/29 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private void exportIntoExcelData(bool excelFlg)
        {
            // --- ADD 2010/08/12 ��QID:13038�Ή�-------------------------------->>>>>
            if (this._prevControl != null)
            {
                checkFlg = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }
            if (!checkFlg)
            {
                // --- ADD 2010/08/12 ��QID:13038�Ή�--------------------------------<<<<<
                this._extractSetupFrm = new PMHNB04161UC();

                this._extractSetupFrm.FormcloseFlg = false;
                // �o�͌`��
                this._extractSetupFrm.ExcelFlg = excelFlg;
                // �J�n���_
                this._extractSetupFrm.SectionCodeSt = this.tEdit_SectionCodeAllowZero.Text;
                // �I�����_
                this._extractSetupFrm.SectionCodeEd = this.tEdit_SectionCodeAllowZero.Text;
                // �Q�Ƌ敪
                this._extractSetupFrm.ReferDiv = this.tComboEditor_Refer.SelectedIndex;
                // ���ԋ敪
                this._extractSetupFrm.DuringDiv = this.tComboEditor_During.SelectedIndex;
                // �J�n�S����
                this._extractSetupFrm.EmployeeCodeSt = this.tEdit_EmployeeCode_St.Text;
                // �I���S����
                this._extractSetupFrm.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.Text;
                // �J�n����
                this._extractSetupFrm.DuringSt = this.tDateEdit_St_During.GetDateTime();
                // �I������
                this._extractSetupFrm.DuringEd = this.tDateEdit_Ed_During.GetDateTime();
                // �J�n����(�N��)
                this._extractSetupFrm.DuringYmSt = this.tDateEdit_St_YearMonth.GetLongDate();
                this._extractSetupFrm.DuringYmEd = this.tDateEdit_Ed_YearMonth.GetLongDate();

                this._extractSetupFrm.OutputData += new PMHNB04161UC.OutputDataEvent(this.outputExcelData); // ADD 2010/10/09

                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
                // �G���[���b�Z�[�W
                string errMsg = string.Empty;
                // �A���[�g�\��
                int logStatus = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
                // �A���[�g��OK�{�^����������Ȃ��ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, logStatus, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    // ���~
                    return;
                }
                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

                this._extractSetupFrm.ShowDialog();

                // --- DEL 2010/10/09 ---------->>>
                //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
                //{
                //    return;
                //}

                //EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();
                //// �Ǎ������p�����[�^�N���X�ݒ菈��
                //this.SetReadParaForOutput(out employeeResultsCtdtn);

                //// �O���b�h��ݒ菈��
                //int duringFlg = _extractSetupFrm.DuringDiv;
                //int referDiv = this._extractSetupFrm.ReferDiv; // ADD 2010/09/09
                //if (duringFlg == 1)
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(1); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(1, referDiv); // ADD 2010/09/09
                //}
                //else if (duringFlg == 2)
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(2); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(2, referDiv); // ADD 2010/09/09
                //}
                //else
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(2); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(2, referDiv); // ADD 2010/09/09
                //}
                ////this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn);// DEL 2010/08/20
                ////this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt); // ADD 2010/08/20
                //this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt, this._extractSetupFrm.SectionCodeEd); // ADD 2010/09/21

                //if (this._employeeResultsAcs.DataSet.EmployeeResults.Count == 0)
                //{
                //    // �o�͑O�̏�Ԃ�߂�܂�
                //    ClearDetail();

                //    // ��������
                //    if (this.isSearch) // ADD 2010/09/14
                //        SearchEmployeeResults(false);

                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

                //    return;
                //}

                //try
                //{
                //    if (this.ultraGridExcelExporter1.Export(this._inputDetails.uGrid_Details, this._extractSetupFrm.SettingFileName) != null)
                //    {
                //        // �f�[�^�Z�b�g���N���A
                //        this._employeeResultsAcs.DataSet.EmployeeResults.Clear(); // ADD 2010/09/14

                //        // �o�͑O�̏�Ԃ�߂�܂�
                //        ClearDetail();

                //        // ��������
                //        if (this.isSearch) // ADD 2010/09/14
                //            SearchEmployeeResults(false);
                //        // ����
                //        TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_INFO,
                //            this.Name,
                //            "EXCEL�f�[�^���o�͂��܂����B",
                //            -1,
                //            MessageBoxButtons.OK);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    // �f�[�^�Z�b�g���N���A
                //    this._employeeResultsAcs.DataSet.EmployeeResults.Clear(); // ADD 2010/09/14

                //    // �o�͑O�̏�Ԃ�߂�܂�
                //    ClearDetail(); // ADD 2010/09/14

                //    // ��������
                //    if (this.isSearch) // ADD 2010/09/14
                //        SearchEmployeeResults(false); // ADD 2010/09/14

                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        ex.Message,
                //        -1,
                //        MessageBoxButtons.OK);
                //}
                // --- DEL 2010/10/09 ----------<<<
            } //ADD 2010/08/12 ��QID:13038�Ή�
            
        }

        /// <summary>
        /// �c���ꗗ���e�L�X�g�o�͂��܂��B
        /// </summary>
        /// <br>Update Note : 2024/11/29 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private void ExportIntoTextFile(bool excelFlg)
        {
            // --- ADD 2010/08/12 ��QID:13038�Ή�-------------------------------->>>>>
            if (this._prevControl != null)
            {
                checkFlg = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }
            if (!checkFlg)
            {
                // --- ADD 2010/08/12 ��QID:13038�Ή�--------------------------------<<<<<
                this._extractSetupFrm = new PMHNB04161UC();

                this._extractSetupFrm.FormcloseFlg = false;
                // �o�͌`��
                this._extractSetupFrm.ExcelFlg = excelFlg;
                // �J�n���_
                this._extractSetupFrm.SectionCodeSt = this.tEdit_SectionCodeAllowZero.Text;
                // �I�����_
                this._extractSetupFrm.SectionCodeEd = this.tEdit_SectionCodeAllowZero.Text;
                // �Q�Ƌ敪
                this._extractSetupFrm.ReferDiv = this.tComboEditor_Refer.SelectedIndex;
                // ���ԋ敪
                this._extractSetupFrm.DuringDiv = this.tComboEditor_During.SelectedIndex;
                // �J�n�S����
                this._extractSetupFrm.EmployeeCodeSt = this.tEdit_EmployeeCode_St.Text;
                // �I���S����
                this._extractSetupFrm.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.Text;
                // �J�n����
                this._extractSetupFrm.DuringSt = this.tDateEdit_St_During.GetDateTime();
                // �I������
                this._extractSetupFrm.DuringEd = this.tDateEdit_Ed_During.GetDateTime();
                // �J�n����(�N��)
                this._extractSetupFrm.DuringYmSt = this.tDateEdit_St_YearMonth.GetLongDate();
                // �I������(�N��)
                this._extractSetupFrm.DuringYmEd = this.tDateEdit_Ed_YearMonth.GetLongDate();

                this._extractSetupFrm.OutputData += new PMHNB04161UC.OutputDataEvent(this.outputTextData); // ADD 2010/10/09

                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
                // �G���[���b�Z�[�W
                string errMsg = string.Empty;
                // �A���[�g�\��
                int logStatus = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
                // �A���[�g��OK�{�^����������Ȃ��ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, logStatus, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    // ���~
                    return;
                }
                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

                this._extractSetupFrm.ShowDialog();

                // --- DEL 2010/10/09 ---------->>>
                //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
                //{
                //    return;
                //}

                //EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();
                //// �Ǎ������p�����[�^�N���X�ݒ菈��
                //this.SetReadParaForOutput(out employeeResultsCtdtn);

                //// �O���b�h��ݒ菈��
                //int duringFlg = _extractSetupFrm.DuringDiv;
                //int referDiv = this._extractSetupFrm.ReferDiv; // ADD 2010/09/09
                //if (duringFlg == 1)
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(1); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(1, referDiv); // ADD 2010/09/09
                //}
                //else if (duringFlg == 2)
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(2); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(2, referDiv); // ADD 2010/09/09
                //}
                //else
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(2); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(2, referDiv); // ADD 2010/09/09
                //}
                ////this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn); // DEL 2010/08/20
                ////this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt); // ADD 2010/08/20
                //this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt, this._extractSetupFrm.SectionCodeEd); // ADD 2010/09/21


                ////string outputFileName = this._extractSetupFrm.SettingFileName;
                //if (String.IsNullOrEmpty(outputFileName))
                //{
                //    // �o�͑O�̏�Ԃ�߂�܂�
                //    ClearDetail();

                //    // ��������
                //    if (this.isSearch) // ADD 2010/09/14
                //        SearchEmployeeResults(false);

                //    // �t�@�C�������w�肳��Ă��Ȃ��ƃG���[
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        MSG_OUTPUTFILENAME_NOTFOUND, -1, MessageBoxButtons.OK);
                //    return;
                //}

                //if (this._employeeResultsAcs.DataSet.EmployeeResults.Count == 0)
                //{
                //    // �o�͑O�̏�Ԃ�߂�܂�
                //    ClearDetail();

                //    // ��������
                //    if (this.isSearch) // ADD 2010/09/14
                //        SearchEmployeeResults(false);

                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

                //    return;
                //}

                //String typeStr = string.Empty;
                //Char typeChar = new char();
                //Byte typeByte = new byte();
                //DateTime typeDate = new DateTime();
                //Int16 typeInt16 = new short();
                //Int32 typeInt32 = new int();
                //Int64 typeInt64 = new long();
                //Single typeSingle = new float();
                //Double typeDouble = new double();
                //Decimal typeDecimal = new decimal();
                //FormattedTextWriter tw = new FormattedTextWriter();

                //Dictionary<int, string> sortList = new Dictionary<int, string>();
                //List<String> schemeList = new List<string>();

                //DataTable targetTable = this._employeeResultsAcs.DataSet.EmployeeResults;
                //// --- UPD 2010/09/09 ---------->>>>>
                ////targetTable.Columns["EmployeeCode"].Caption = "�S����";
                //if (referDiv == 1)
                //{
                //    targetTable.Columns["EmployeeCode"].Caption = "�S����";
                //    targetTable.Columns["EmployeeName"].Caption = "�S���Җ�";
                //}
                //else if (referDiv == 2)
                //{
                //    targetTable.Columns["EmployeeCode"].Caption = "�󒍎�";
                //    targetTable.Columns["EmployeeName"].Caption = "�󒍎Җ�";
                //}
                //else if (referDiv == 3)
                //{
                //    targetTable.Columns["EmployeeCode"].Caption = "���s��";
                //    targetTable.Columns["EmployeeName"].Caption = "���s�Җ�";
                //}
                //// --- UPD 2010/09/09 ----------<<<<<
                //targetTable.Columns["BackSalesTotalTaxExc"].Caption = "������z";
                //targetTable.Columns["RetGoodSalesTotalTaxExc"].Caption = "�ԕi�z";
                //targetTable.Columns["BackSalesDisTtlTaxExc"].Caption = "�l���z";
                //targetTable.Columns["PureSales"].Caption = "������";
                //targetTable.Columns["SectionName"].Caption = "���_";
                //targetTable.Columns["SalesTargetMoney"].Caption = "����ڕW�z";
                //targetTable.Columns["SalesStructure"].Caption = "����\����";
                ////targetTable.Columns["EmployeeName"].Caption = "�S���Җ�"; // DEL 2010/09/09
                //targetTable.Columns["TotalCost"].Caption = "����";
                //targetTable.Columns["RetGoodsPct"].Caption = "�ԕi��";
                //targetTable.Columns["DisTtlPct"].Caption = "�l����";
                //targetTable.Columns["GrossProfit"].Caption = "�e���z";
                //targetTable.Columns["GrossProfitPct"].Caption = "�e����";
                //targetTable.Columns["TargetPct"].Caption = "����ڕW�B����";
                //targetTable.Columns["RetGoodsStructure"].Caption = "�ԕi�\����";

                //if (this._extractSetupFrm.DuringDiv == 1)
                //{
                //    targetTable.Columns["DuringSt"].Caption = "�J�n�N����";
                //    targetTable.Columns["DuringEd"].Caption = "�I���N����";
                //}
                //else
                //{
                //    targetTable.Columns["DuringSt"].Caption = "�J�n�N��";
                //    targetTable.Columns["DuringEd"].Caption = "�I���N��";
                //}

                //Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns;
                //int dispOrder;
                //string columnName;
                //for (int i = 0; i < Columns.Count; i++)
                //{
                //    if (Columns[i].Hidden == false)
                //    {
                //        dispOrder = Columns[i].Header.VisiblePosition;
                //        columnName = targetTable.Columns[Columns[i].Index].ColumnName;
                //        sortList.Add(dispOrder, columnName);
                //    }
                //}

                //List<int> keyList = new List<int>(sortList.Keys);
                //keyList.Sort();


                //foreach (int key in keyList)
                //{
                //    schemeList.Add(sortList[key]);
                //}

                //// �o�͍��ږ�
                //tw.SchemeList = schemeList;

                //// �f�[�^�\�[�X
                //tw.DataSource = this._employeeResultsAcs.DataSet.EmployeeResults.DefaultView;

                //# region [�t�H�[�}�b�g���X�g]
                //Dictionary<string, string> formatList = new Dictionary<string, string>();
                //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns)
                //{
                //    if (col.Hidden == false)
                //    {
                //        formatList.Add(col.Key, col.Format);
                //    }
                //}
                //tw.FormatList = formatList;

                //#endregion // �t�H�[�}�b�g���X�g

                //#region �I�v�V�����Z�b�g
                //// �t�@�C����
                ////tw.OutputFileName = this._extractSetupFrm.SettingFileName;
                //// ��؂蕶��
                //tw.Splitter = ",";
                //// ���ڊ��蕶��
                //tw.Encloser = "\"";
                //// �Œ蕝
                //tw.FixedLength = false;
                //// �^�C�g���s�o��
                //tw.CaptionOutput = true;

                //// ���ڊ���K�p
                //List<Type> enclosingList = new List<Type>();
                //enclosingList.Add(typeInt16.GetType());
                //enclosingList.Add(typeInt32.GetType());
                //enclosingList.Add(typeInt64.GetType());
                //enclosingList.Add(typeDouble.GetType());
                //enclosingList.Add(typeDecimal.GetType());
                //enclosingList.Add(typeSingle.GetType());
                //enclosingList.Add(typeStr.GetType());
                //enclosingList.Add(typeChar.GetType());
                //enclosingList.Add(typeByte.GetType());
                //enclosingList.Add(typeDate.GetType());
                //tw.EnclosingTypeList = enclosingList;
                //#endregion

                //int outputCount = 0;
                //int status = tw.TextOut(out outputCount);
                //// �f�[�^�Z�b�g���N���A
                //this._employeeResultsAcs.DataSet.EmployeeResults.Clear(); // ADD 2010/09/14
                
                //// �o�͑O�̏�Ԃ�߂�܂�
                //ClearDetail();

                //// ��������
                //if (this.isSearch) // ADD 2010/09/14
                //    SearchEmployeeResults(false);

                //if (status == 9)// �ُ�I��
                //{
                //    // �o�͎��s
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
                //}
                //else
                //{
                //    // �o�͐���
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                //        outputCount.ToString() + "�s�̃f�[�^���t�@�C���֏o�͂��܂����B", -1, MessageBoxButtons.OK);
                //}
                // --- DEL 2010/10/09 ----------<<<
            }
        }

        //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary>
        /// �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ�����
        /// </summary>
        /// <param name="mode">���[�h�u�e�L�X�g�o�́F1�@Excel�o�́F2�v</param>
        /// <param name="textOutPutOprtnHisLogWorkObj">�o�^�p�Ώۃ��[�N</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2024/11/29</br>
        /// </remarks>
        private int TextOutPutWrite(int mode, ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                string outPutCon = string.Empty;
                textOutPutOprtnHisLogWorkObj = new TextOutPutOprtnHisLogWork();
                // ���O�f�[�^�ΏۃA�Z���u��ID
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = CT_EMPLOYEE_RESULT_PGID;
                // ���O�f�[�^�ΏۃA�Z���u������
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyNm = ASSEMBLYNM;
                // ���O�f�[�^�ΏۋN���v���O��������
                textOutPutOprtnHisLogWorkObj.LogDataObjBootProgramNm = ASSEMBLYNM;
                if (mode == (int)OperationCode.TextOut || mode == (int)OperationCode.ExcelOut)
                {
                    if (mode == (int)OperationCode.TextOut)
                    {
                        // �e�L�X�g�o�͂̏ꍇ
                        // ���O�f�[�^�Ώۏ�����:�e�L�X�g�o�̓��\�b�h��
                        textOutPutOprtnHisLogWorkObj.LogDataObjProcNm = TEXT_METHODNM;
                    }
                    else
                    {
                        // Excel�o�͂̏ꍇ
                        // ���O�f�[�^�Ώۏ�����:Excel�o�̓��\�b�h��
                        textOutPutOprtnHisLogWorkObj.LogDataObjProcNm = EXCEL_METHODNM;
                    }
                }

                // ���O�I�y���[�V�����f�[�^
                //�Q�Ƌ敪
                string referDivStr = string.Empty;
                //�o�̓t�@�C����
                string�@outputFileName = string.Empty;
                if (this._extractSetupFrm.ReferDiv == 1)
                {
                    referDivStr = SALESINPUT_NAME; //�S����
                    outputFileName = this._extractSetupFrm.SettingFileName;
                }
                else if (this._extractSetupFrm.ReferDiv == 2)
                {
                    referDivStr = FRONTEMPLOYEE_SECTION_NAME;//�󒍎�
                    outputFileName = this._extractSetupFrm.SettingFileNameSeller;
                }
                else if (this._extractSetupFrm.ReferDiv == 3)
                {
                    referDivStr = SALESEMPLOYEE_NAME;//���s��
                    outputFileName = this._extractSetupFrm.SettingFileNamePublisher;
                }
                else 
                {
                    referDivStr = string.Empty;
                    outputFileName = this._extractSetupFrm.SettingFileName;
                }
           
                // ���_
                string sectionCdSt = this._extractSetupFrm.SectionCodeLogSt.Trim();
                sectionCdSt = string.IsNullOrEmpty(sectionCdSt) ? STARTSTR : sectionCdSt;
                string sectionCdEd = this._extractSetupFrm.SectionCodeLogEd.Trim();
                sectionCdEd = string.IsNullOrEmpty(sectionCdEd) ? ENDSTR : sectionCdEd;
                // �S����
                string employeeCodeSt = this._extractSetupFrm.EmployeeCodeSt.Trim();
                employeeCodeSt = string.IsNullOrEmpty(employeeCodeSt) ? STARTSTR : employeeCodeSt;
                string employeeCodeEd = this._extractSetupFrm.EmployeeCodeEd.Trim();
                employeeCodeEd = string.IsNullOrEmpty(employeeCodeEd) ? ENDSTR : employeeCodeEd;


                //���ԋ敪
                string duringDivStr = string.Empty;
                if (this._extractSetupFrm.DuringDiv == 1)
                {
                    // ���v
                    duringDivStr = DURINGDIV_DAILY;
                    // ����(�J�n)YYYYMMDD
                    string duringSt = this._extractSetupFrm.DuringSt.ToString();
                    duringSt = string.IsNullOrEmpty(duringSt) ? STARTSTR : duringSt;
                    // ����(�I��)YYYYMMDD
                    string duringEd = this._extractSetupFrm.DuringEd.ToString();
                    duringEd = string.IsNullOrEmpty(duringEd) ? ENDSTR : duringEd;
                    // ���O�I�y���[�V�����f�[�^
                    outPutCon = string.Format(OUTPUTCON, referDivStr, duringDivStr, sectionCdSt, sectionCdEd, employeeCodeSt,
                        employeeCodeEd, duringSt, duringEd, outputFileName);
                }
                else if (this._extractSetupFrm.DuringDiv == 2)
                {
                    // ���v
                    duringDivStr = DURINGDIV_MOONGAUGE;
                    // ����(�J�n)YYYYMM
                    string duringSt = TDateTime.LongDateToDateTime(this._extractSetupFrm.DuringYmSt).ToString("yyyy/MM");
                    // ����(�I��)YYYYMM
                    string duringEd = TDateTime.LongDateToDateTime(this._extractSetupFrm.DuringYmEd).ToString("yyyy/MM");
                    duringEd = string.IsNullOrEmpty(duringEd) ? ENDSTR : duringEd;
                    // ���O�I�y���[�V�����f�[�^
                    outPutCon = string.Format(OUTPUTCON, referDivStr, duringDivStr, sectionCdSt, sectionCdEd, employeeCodeSt,
                        employeeCodeEd, duringSt, duringEd, outputFileName);
                }
                else if (this._extractSetupFrm.DuringDiv == 3)
                {
                    // ����
                    duringDivStr = DURINGDIV_CURRENTPERIOD;
                    // ���O�I�y���[�V�����f�[�^
                    outPutCon = string.Format(OUTPUTCON2, referDivStr, duringDivStr, sectionCdSt, sectionCdEd, employeeCodeSt,
                        employeeCodeEd, outputFileName);
                }
                else
                {
                    duringDivStr = string.Empty;
                    // ���O�I�y���[�V�����f�[�^
                    outPutCon = string.Format(OUTPUTCON2, referDivStr, duringDivStr, sectionCdSt, sectionCdEd, employeeCodeSt,
                        employeeCodeEd, outputFileName);
                }

                // ���O�I�y���[�V�����f�[�^�̐ݒ�
                textOutPutOprtnHisLogWorkObj.LogOperationData = outPutCon;
                status = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return status;
        }
        //----- ADD 2024/11/29 ���O 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<

        // --- ADD 2010/10/09 ---------->>>
        /// <summary>
        /// Excel�o�͏���
        /// </summary>
        /// <returns>True:����; False:�ُ�</returns>
        /// <br>Update Note :2024/11/29 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private bool outputExcelData()
        {
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            // �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\�������uExcel�o�́v
            int logStatus = TextOutPutWrite((int)OperationCode.ExcelOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

            // ���O�o�^�ُ�ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
            if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    Form form = new Form();
                    form.TopMost = true;
                    DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, logStatus, MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // ���~
                return false;
            }
            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<

            EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();
            // �Ǎ������p�����[�^�N���X�ݒ菈��
            this.SetReadParaForOutput(out employeeResultsCtdtn);

            // �O���b�h��ݒ菈��
            int duringFlg = _extractSetupFrm.DuringDiv;
            int referDiv = this._extractSetupFrm.ReferDiv;
            if (duringFlg == 1)
            {
                this._inputDetails.InitialSettingGridColForOutput(1, referDiv);
            }
            else if (duringFlg == 2)
            {
                this._inputDetails.InitialSettingGridColForOutput(2, referDiv);
            }
            else
            {
                this._inputDetails.InitialSettingGridColForOutput(2, referDiv);
            }
            this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt, this._extractSetupFrm.SectionCodeEd);

            if (this._employeeResultsAcs.DataSet.EmployeeResults.Count == 0)
            {
                // �o�͑O�̏�Ԃ�߂�܂�
                ClearDetail();

                // ��������
                if (this.isSearch)
                    SearchEmployeeResults(false);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

                return false;
            }

            try
            {
                string outputFileName = string.Empty;
                // �Q�Ƌ敪�͎󒍎҂̏ꍇ
                if (referDiv == 2)
                {
                    outputFileName = this._extractSetupFrm.SettingFileNameSeller;
                }
                // �Q�Ƌ敪�͔��s�҂̏ꍇ
                else if (referDiv == 3)
                {
                    outputFileName = this._extractSetupFrm.SettingFileNamePublisher;
                }
                // ���̂ق��̏ꍇ
                else
                {
                    outputFileName = this._extractSetupFrm.SettingFileName;
                }

                if (this.ultraGridExcelExporter1.Export(this._inputDetails.uGrid_Details, outputFileName) != null)
                {
                    int outputCount = ((DataTable)this._inputDetails.uGrid_Details.DataSource).Rows.Count; //ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�
                    // �f�[�^�Z�b�g���N���A
                    this._employeeResultsAcs.DataSet.EmployeeResults.Clear();

                    // �o�͑O�̏�Ԃ�߂�܂�
                    ClearDetail();

                    // ��������
                    if (this.isSearch)
                        SearchEmployeeResults(false);
                    // ����
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "EXCEL�f�[�^���o�͂��܂����B",
                        -1,
                        MessageBoxButtons.OK);

                    //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
                    // �G���[���b�Z�[�W
                    errMsg = string.Empty;
                    // ���엚��o�^
                    textOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(COUNTNUMSTR, outputCount.ToString()) + textOutPutOprtnHisLogWorkObj.LogOperationData;
                    logStatus = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
                    // ���O�o�^�ُ�̏ꍇ�A���O�o�^�ُ탁�b�Z�[�W��\������
                    if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (!string.IsNullOrEmpty(errMsg))
                        {
                            Form form = new Form();
                            form.TopMost = true;
                            DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                        errMsg, logStatus, MessageBoxButtons.OK);
                            form.TopMost = false;
                        }
                        // ���~
                        return false;
                    }
                    //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<
                }
                return true;
            }
            catch (Exception ex)
            {
                // �f�[�^�Z�b�g���N���A
                this._employeeResultsAcs.DataSet.EmployeeResults.Clear();

                // �o�͑O�̏�Ԃ�߂�܂�
                ClearDetail();

                // ��������
                if (this.isSearch)
                    SearchEmployeeResults(false);

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// �e�L�X�g�o�͏���
        /// </summary>
        /// <returns>True:����; False:�ُ�</returns>
        /// <br>Update Note:2011/02/16 liyp</br>
        /// <br>            �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note :2024/11/29 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private bool outputTextData()
        {
            this._employeeResultsAcs.ExcOrtxtDiv = true; // ADD 2011/02/16
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            // �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\�������u�e�L�X�g�o�́v
            int logStatus = TextOutPutWrite((int)OperationCode.TextOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

            // ���O�o�^�ُ�ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
            if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    Form form = new Form();
                    form.TopMost = true;
                    DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, logStatus, MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // ���~
                return false;
            }
            //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<

            EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();
            // �Ǎ������p�����[�^�N���X�ݒ菈��
            this.SetReadParaForOutput(out employeeResultsCtdtn);

            // �O���b�h��ݒ菈��
            int duringFlg = _extractSetupFrm.DuringDiv;
            int referDiv = this._extractSetupFrm.ReferDiv;
            if (duringFlg == 1)
            {
                this._inputDetails.InitialSettingGridColForOutput(1, referDiv);
            }
            else if (duringFlg == 2)
            {
                this._inputDetails.InitialSettingGridColForOutput(2, referDiv);
            }
            else
            {
                this._inputDetails.InitialSettingGridColForOutput(2, referDiv);
            }
            this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt, this._extractSetupFrm.SectionCodeEd);

            string outputFileName = string.Empty;
            // �Q�Ƌ敪�͎󒍎҂̏ꍇ
            if (referDiv == 2)
            {
                outputFileName = this._extractSetupFrm.SettingFileNameSeller;
            }
            // �Q�Ƌ敪�͔��s�҂̏ꍇ
            else if (referDiv == 3)
            {
                outputFileName = this._extractSetupFrm.SettingFileNamePublisher;
            }
            // ���̂ق��̏ꍇ
            else
            {
                outputFileName = this._extractSetupFrm.SettingFileName;
            }

            if (String.IsNullOrEmpty(outputFileName))
            {
                // �o�͑O�̏�Ԃ�߂�܂�
                ClearDetail();

                // ��������
                if (this.isSearch)
                    SearchEmployeeResults(false);

                // �t�@�C�������w�肳��Ă��Ȃ��ƃG���[
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILENAME_NOTFOUND, -1, MessageBoxButtons.OK);
                return false;
            }

            if (this._employeeResultsAcs.DataSet.EmployeeResults.Count == 0)
            {
                // �o�͑O�̏�Ԃ�߂�܂�
                ClearDetail();

                // ��������
                if (this.isSearch)
                    SearchEmployeeResults(false);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

                return false;
            }

            String typeStr = string.Empty;
            Char typeChar = new char();
            Byte typeByte = new byte();
            DateTime typeDate = new DateTime();
            Int16 typeInt16 = new short();
            Int32 typeInt32 = new int();
            Int64 typeInt64 = new long();
            Single typeSingle = new float();
            Double typeDouble = new double();
            Decimal typeDecimal = new decimal();
            FormattedTextWriter tw = new FormattedTextWriter();

            Dictionary<int, string> sortList = new Dictionary<int, string>();
            List<String> schemeList = new List<string>();

            DataTable targetTable = this._employeeResultsAcs.DataSet.EmployeeResults;

            if (referDiv == 1)
            {
                targetTable.Columns["EmployeeCode"].Caption = "�S����";
                targetTable.Columns["EmployeeName"].Caption = "�S���Җ�";
            }
            else if (referDiv == 2)
            {
                targetTable.Columns["EmployeeCode"].Caption = "�󒍎�";
                targetTable.Columns["EmployeeName"].Caption = "�󒍎Җ�";
            }
            else if (referDiv == 3)
            {
                targetTable.Columns["EmployeeCode"].Caption = "���s��";
                targetTable.Columns["EmployeeName"].Caption = "���s�Җ�";
            }

            targetTable.Columns["BackSalesTotalTaxExc"].Caption = "������z";
            targetTable.Columns["RetGoodSalesTotalTaxExc"].Caption = "�ԕi�z";
            targetTable.Columns["BackSalesDisTtlTaxExc"].Caption = "�l���z";
            targetTable.Columns["PureSales"].Caption = "������";
            targetTable.Columns["SectionName"].Caption = "���_";
            targetTable.Columns["SalesTargetMoney"].Caption = "����ڕW�z";
            targetTable.Columns["SalesStructure"].Caption = "����\����";
            targetTable.Columns["TotalCost"].Caption = "����";
            targetTable.Columns["RetGoodsPct"].Caption = "�ԕi��";
            targetTable.Columns["DisTtlPct"].Caption = "�l����";
            targetTable.Columns["GrossProfit"].Caption = "�e���z";
            targetTable.Columns["GrossProfitPct"].Caption = "�e����";
            targetTable.Columns["TargetPct"].Caption = "����ڕW�B����";
            targetTable.Columns["RetGoodsStructure"].Caption = "�ԕi�\����";

            if (this._extractSetupFrm.DuringDiv == 1)
            {
                targetTable.Columns["DuringSt"].Caption = "�J�n�N����";
                targetTable.Columns["DuringEd"].Caption = "�I���N����";
            }
            else
            {
                targetTable.Columns["DuringSt"].Caption = "�J�n�N��";
                targetTable.Columns["DuringEd"].Caption = "�I���N��";
            }

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns;
            int dispOrder;
            string columnName;
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].Hidden == false)
                {
                    dispOrder = Columns[i].Header.VisiblePosition;
                    columnName = targetTable.Columns[Columns[i].Index].ColumnName;
                    sortList.Add(dispOrder, columnName);
                }
                // ------------ ADD 2011/02/16 --------------------->>>>>
                if (Columns[i].ToString().Equals("RetGoodsStructure") 
                    || Columns[i].ToString().Equals("SalesStructure") 
                    || Columns[i].ToString().Equals("RetGoodsPct") 
                    || Columns[i].ToString().Equals("DisTtlPct") 
                    || Columns[i].ToString().Equals("GrossProfitPct") 
                    || Columns[i].ToString().Equals("TargetPct"))
                {
                    Columns[i].Format = "0.00;-0.00;";
                }
                else
                {
                    Columns[i].Format = ""; 
                }
                // ------------ ADD 2011/02/16 ---------------------<<<<<
            }

            List<int> keyList = new List<int>(sortList.Keys);
            keyList.Sort();


            foreach (int key in keyList)
            {
                schemeList.Add(sortList[key]);
            }

            // �o�͍��ږ�
            tw.SchemeList = schemeList;

            // �f�[�^�\�[�X
            tw.DataSource = this._employeeResultsAcs.DataSet.EmployeeResults.DefaultView;

            # region [�t�H�[�}�b�g���X�g]
            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns)
            {
                if (col.Hidden == false)
                {
                    formatList.Add(col.Key, col.Format);
                }
            }
            tw.FormatList = formatList;

            #endregion // �t�H�[�}�b�g���X�g

            #region �I�v�V�����Z�b�g
            // �t�@�C����
            // �Q�Ƌ敪�͎󒍎҂̏ꍇ
            if (referDiv == 2)
            {
                tw.OutputFileName = this._extractSetupFrm.SettingFileNameSeller;
            }
            // �Q�Ƌ敪�͔��s�҂̏ꍇ
            else if (referDiv == 3)
            {
                tw.OutputFileName = this._extractSetupFrm.SettingFileNamePublisher;
            }
            // ���̂ق��̏ꍇ
            else
            {
                tw.OutputFileName = this._extractSetupFrm.SettingFileName;
            }
            // ��؂蕶��
            tw.Splitter = ",";
            // ���ڊ��蕶��
            tw.Encloser = "\"";
            // �Œ蕝
            tw.FixedLength = false;
            // �^�C�g���s�o��
            tw.CaptionOutput = true;

            // ���ڊ���K�p
            List<Type> enclosingList = new List<Type>();
            enclosingList.Add(typeInt16.GetType());
            enclosingList.Add(typeInt32.GetType());
            enclosingList.Add(typeInt64.GetType());
            enclosingList.Add(typeDouble.GetType());
            enclosingList.Add(typeDecimal.GetType());
            enclosingList.Add(typeSingle.GetType());
            enclosingList.Add(typeStr.GetType());
            enclosingList.Add(typeChar.GetType());
            enclosingList.Add(typeByte.GetType());
            enclosingList.Add(typeDate.GetType());
            tw.EnclosingTypeList = enclosingList;
            #endregion

            int outputCount = 0;
            int status = tw.TextOut(out outputCount);
            // �f�[�^�Z�b�g���N���A
            this._employeeResultsAcs.DataSet.EmployeeResults.Clear();

            // �o�͑O�̏�Ԃ�߂�܂�
            ClearDetail();

            // ��������
            if (this.isSearch)
                SearchEmployeeResults(false);

            if (status == 9)// �ُ�I��
            {
                // �o�͎��s
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", -1, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // �o�͐���
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + "�s�̃f�[�^���t�@�C���֏o�͂��܂����B", -1, MessageBoxButtons.OK);

                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----->>>>>
                // �G���[���b�Z�[�W
                errMsg = string.Empty;
                // ���엚��o�^
                textOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(COUNTNUMSTR, outputCount.ToString()) + textOutPutOprtnHisLogWorkObj.LogOperationData;
                logStatus = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
                // ���O�o�^�ُ�̏ꍇ�A���O�o�^�ُ탁�b�Z�[�W��\������
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, logStatus, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    // ���~
                    return false;
                }
                //----- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� -----<<<<<
                return true;
            }
        }
        // --- ADD 2010/10/09 ----------<<<

        /// <summary>
        /// �Ǎ������p�����[�^�ݒ菈��(�o�͗p)
        /// </summary>
        /// <param>�Ǎ������p�����[�^�N���X</param>
        /// <param name="employeeResultsCtdtn">�Ǎ������p�����[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ǎ������p�����[�^�ݒ菈�����s���B </br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public void SetReadParaForOutput(out EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            employeeResultsCtdtn = new EmployeeResultsCtdtn();

            //��ƃR�[�h
            employeeResultsCtdtn.EnterpriseCode = this._enterpriseCode;

            employeeResultsCtdtn.SectionCodeList = this._extractSetupFrm.SectionCodeList;

            //�Q�Ƌ敪  
            employeeResultsCtdtn.ReferType = this._extractSetupFrm.ReferDiv;
            //�S����(�J�n)
            employeeResultsCtdtn.St_EmployeeCode = this._extractSetupFrm.EmployeeCodeSt;
            //�S����(�I��)
            employeeResultsCtdtn.Ed_EmployeeCode = this._extractSetupFrm.EmployeeCodeEd;

            //���ԋ敪
            employeeResultsCtdtn.DuringType = this._extractSetupFrm.DuringDiv;

            if (employeeResultsCtdtn.DuringType == 1)
            {

                //����(�J�n)YYYYMMDD
                employeeResultsCtdtn.St_DuringTime = this._extractSetupFrm.DuringSt;

                //����(�I��)YYYYMMDD
                employeeResultsCtdtn.Ed_DuringTime = this._extractSetupFrm.DuringEd;

            }
            else if (employeeResultsCtdtn.DuringType == 2 || employeeResultsCtdtn.DuringType == 3)
            {
                //����(�J�n)YYYYMM
                employeeResultsCtdtn.St_YearMonth = TDateTime.LongDateToDateTime(this._extractSetupFrm.DuringYmSt);

                //����(�I��)YYYYMM
                employeeResultsCtdtn.Ed_YearMonth =  TDateTime.LongDateToDateTime(this._extractSetupFrm.DuringYmEd);
            }
            //��ʃr���[�E�o�̓r���[�t���O  
            employeeResultsCtdtn.ViewFlg = "OUTPUT";

        }

        /// <summary>
        /// �Z���̃R���N�V�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraGridExcelExporter1_CellExported(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs e)
        {
            int index = e.CurrentRowIndex;
            for (int celIndex = 0; celIndex < 18; celIndex++)
            {
                IWorksheetCellFormat tmCF = e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat;
                if (7 == celIndex || 9 == celIndex || 12 == celIndex || 14 == celIndex || 16 == celIndex || 17 == celIndex) 
                    tmCF.FormatString = "0.00%;-0.00%;";
                else
                    tmCF.FormatString = "#,###,##0;-#,###,##0;";
                e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.SetFormatting(tmCF);
            }

        }

        // --- ADD 2010/07/20 --------------------------------<<<<<

        // --- ADD 2010/09/28 ��Q�� #15609-------------------------------->>>>>
        /// <summary>
        /// tEdit_EmployeeCode_St_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_EmployeeCode_St_Leave(object sender, EventArgs e)
        {
            this._employeeCodeSt = this.tEdit_EmployeeCode_St.Text;
        }

        /// <summary>
        /// tEdit_EmployeeCode_Ed_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_EmployeeCode_Ed_Leave(object sender, EventArgs e)
        {
            this._employeeCodeEd = this.tEdit_EmployeeCode_Ed.Text;
        }

        /// <summary>
        /// tEdit_SectionCodeAllowZero_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            this._sectionCodeAllowZero = this.tEdit_SectionCodeAllowZero.Text;
        }
        // --- ADD 2010/09/28 ��Q�� #15609--------------------------------<<<<<

    }

}