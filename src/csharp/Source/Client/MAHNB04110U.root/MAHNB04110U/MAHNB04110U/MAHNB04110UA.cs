using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    using GridSettingsType = SlipGridSettings;  // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX

    /// <summary>
    /// ����`�[�I���K�C�h�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����`�[�I���K�C�h�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 980076 �Ȓ��@����Y</br>
    /// <br>Date       : 2007.06.13</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.06.13 men �V�K�쐬</br>
    /// <br>					 ���C�i���o�����E�\�����ڕύX�j</br>
    /// <br>Programmer       :   30418 ���i �r��</br>
    /// <br>Date             :   2008/07/11</br>
    /// <br>Update Note      : 2008.10.09 ��� ���b</br>
    /// <br>                      �@�t�H�[�J�X����C���A�o�f�^�C�g���C���A��ʔz�u�C��</br>
    /// <br>Update Note      : 2009.01.29 �E �K�j</br>
    /// <br>                      �@��QID:7552,10621�Ή�</br>
    /// <br>Update Note      : 2009.02.25 �E �K�j</br>
    /// <br>                      �@��QID:7882�Ή�</br>
    /// <br>Update Note      : 2009/03/06 ��� �r��</br>
    /// <br>                      �@��QID:12181�Ή�</br>
    /// <br>Update Note      : 2009/04/03 ��� �r��</br>
    /// <br>                      �@��QID:13082�Ή�</br>
    /// <br>Update Note      : 2009/12/03 �H�� �b�D</br>
    /// <br>                      �@��QID:14742�Ή�</br>
    /// <br>Update Note      : 2010/07/27 20056 ���n ���</br>
    /// <br>                      �\�����x���P</br>
    /// <br>Update Note      : 2010/12/21 ���N�n��</br>
    /// <br>                      �@�N���A������̃t�H�[�J�X����ύX</br>
    /// <br>Update Note      : 2011/03/02 22008 ���� ���n</br>
    /// <br>                      ���ʕ������~�X 2010/07/27�C�����𓝍�</br>
    /// <br>Update Note      : 2011/07/18 ���R</br>
    /// <br>                      �񓚋敪�ǉ��Ή�</br>
    /// <br>Update Note      : ���N�n�� Redmine 26538�Ή�</br>
    /// <br>Date             : 2011/11/11</br>
    /// <br>Update Note      : 2011/12/14 yangmj</br>
    /// <br>�Ǘ��ԍ�         : 10707327-00 2012/01/25�z�M��</br>
    /// <br>                   redmine#27359 �`�[�����̉�ʕ\���̑Ή�</br>
    /// <br>Update Note      : 2015/05/08 gaocheng</br>
    /// <br>�Ǘ��ԍ�         : 11175085-00</br>
    /// <br>                 : Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��</br>
    /// <br> </br>
    /// </remarks>
    public partial class MAHNB04110UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// ����`�[�I���K�C�h�̃R���X�g���N�^�ł��B
        /// </summary>
        public MAHNB04110UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Select"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._para = new SalesSlipSearch();
            this._salesSlipSearchAcs = new SalesSlipSearchAcs();
            this._dataSet = this._salesSlipSearchAcs.DataSet;
            this._salesSearchConstructionAcs = SalesSearchConstructionAcs.GetInstance();
            this._salesSearchConstructionAcs.DataChanged += new EventHandler(this.SalesSearchConstructionAcs_DataChanged);

            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            // �����Z�o���W���[��
            _totalDayCalculator = TotalDayCalculator.GetInstance();

            // �ϑ��t�H�[�J�X����
            _irrFocusCtrl = new IrregularFocusControl();
            # region [focus]
            _irrFocusCtrl.AddFocusDictionary( SectionCodeGuide_ultraButton, false, Keys.Down, 0, ultraButton_SubSectionGuide );
            _irrFocusCtrl.AddFocusDictionary( SectionCodeGuide_ultraButton, false, Keys.Down, 1, uButton_CustomerGuide );
            _irrFocusCtrl.AddFocusDictionary( SectionCodeGuide_ultraButton, false, Keys.Right, 0, tDateEdit_SalesDateSt );
            _irrFocusCtrl.AddFocusDictionary( tDateEdit_SearchSlipDateEd, false, Keys.Down, 0, tEdit_SalesSlipNum_Ed );
            _irrFocusCtrl.AddFocusDictionary( tEdit_SalesSlipNum_Ed, false, Keys.Up, 0, tDateEdit_SearchSlipDateEd );
            _irrFocusCtrl.AddFocusDictionary( uButton_SalesEmployeeGuide, false, Keys.Up, 0, tEdit_SalesSlipNum_Ed );
            _irrFocusCtrl.AddFocusDictionary( ultraButton_SubSectionGuide, false, Keys.Down, 0, uButton_CustomerGuide );
            _irrFocusCtrl.AddFocusDictionary( ultraButton_SubSectionGuide, false, Keys.Right, 0, tDateEdit_SearchSlipDateSt );
            # endregion

            // �O������̎�����������
            this.SectionCode = string.Empty;
            this.SectionName = string.Empty;
            this.CustomerName = string.Empty;
            this.ClaimName = string.Empty;
            this.SalesEmployeeCd = string.Empty;
            this.SalesEmployeeName = string.Empty;
            this.SalesInputCode = string.Empty;
            this.SalesInputName = string.Empty;
            this.FrontEmployeeCd = string.Empty;
            this.FrontEmployeeName = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            // ADD 2008/11/05 �s��Ή�[7070] ����S�̐ݒ�}�X�^�̔��s�ҋ敪���Q�� ---------->>>>>
            // ���s��UI���B��
            // 2008.11.18 modify start [7070]
            SetInpAgentDispDivFromSalesTtlSt(LoginInfoAcquisition.Employee.BelongSectionCode);
            // 2008.11.18 modify end [7070]
            HideSalesInputUI(!this._inpAgentDispDiv.Equals(INP_AGT_DISP));
            // ADD 2008/11/05 �s��Ή�[7070] ����S�̐ݒ�}�X�^�̔��s�ҋ敪���Q�� ----------<<<<<

            // --- ADD 2009/02/12 ��QID:11416�Ή�------------------------------------------------------>>>>>
            this._secInfoAcs = new SecInfoAcs();
            // --- ADD 2009/02/12 ��QID:11416�Ή�------------------------------------------------------<<<<<

        }

        public MAHNB04110UA(int startMovment)
            : this()
        {
            this.StartMovment = startMovment;
            if (startMovment == 1)
            {
                ChangeDecisionButtonEnable(false);
            }
        }

        // 2008.11.11 add start [7552]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="extractSlipCdType"></param>
        public MAHNB04110UA(ExtractSlipCdType extractSlipCdType)
            : this()
        {
            // ���ϐ��ɕۑ�
            this._extractSlipCdType = (int)extractSlipCdType;

            Infragistics.Win.ValueListItem item;

            // �`�[�敪�̒��o�����ɂ��A�`�[�敪�R���{�̓��e�𒲐�
            switch (_extractSlipCdType)
            {
                // �S��
                case 0:
                    {
                        this.tComboEditor_SalesSlipCd.Items.Clear();

                        // �S��
                        item = new Infragistics.Win.ValueListItem(-1, "�S��");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // �|����
                        item = new Infragistics.Win.ValueListItem(0, "�|����");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // �|�ԕi
                        item = new Infragistics.Win.ValueListItem(1, "�|�ԕi");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // ��������
                        item = new Infragistics.Win.ValueListItem(100, "��������");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // �����ԕi
                        item = new Infragistics.Win.ValueListItem(101, "�����ԕi");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);
                    }
                    break;
                // ����
                case 1:
                    {
                        this.tComboEditor_SalesSlipCd.Items.Clear();

                        // �S��
                        item = new Infragistics.Win.ValueListItem(-1, "�S��");
                        item.Tag = 1;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // �|����
                        item = new Infragistics.Win.ValueListItem(0, "�|����");
                        item.Tag = 2;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // ��������
                        item = new Infragistics.Win.ValueListItem(100, "��������");
                        item.Tag = 4;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);
                    }
                    break;
                // �ԕi
                case 2:
                    {
                        this.tComboEditor_SalesSlipCd.Items.Clear();

                        // �S��
                        item = new Infragistics.Win.ValueListItem(-1, "�S��");
                        item.Tag = 1;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // �|�ԕi
                        item = new Infragistics.Win.ValueListItem(1, "�|�ԕi");
                        item.Tag = 3;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // �����ԕi
                        item = new Infragistics.Win.ValueListItem(101, "�����ԕi");
                        item.Tag = 5;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);
                    }
                    break;
                // ����ȊO�͉������Ȃ�
                default:
                    {
                        this.tComboEditor_SalesSlipCd.Items.Clear();

                        // �S��
                        item = new Infragistics.Win.ValueListItem(-1, "�S��");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // �|����
                        item = new Infragistics.Win.ValueListItem(0, "�|����");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // �|�ԕi
                        item = new Infragistics.Win.ValueListItem(1, "�|�ԕi");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // ��������
                        item = new Infragistics.Win.ValueListItem(100, "��������");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // �����ԕi
                        item = new Infragistics.Win.ValueListItem(101, "�����ԕi");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);
                    }
                    break; 
            }
        }
        // 2008.11.11 add end [7552]

        # endregion

        # region �v���C�x�[�g�ϐ�
        private SalesSlipSearchAcs _salesSlipSearchAcs;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private DateTime _baseDate = DateTime.MinValue;
        private ImageList _imageList16 = null;
        private ControlScreenSkin _controlScreenSkin;
        private DialogResult _dialogResult = DialogResult.Cancel;
        private SalesSlipSearch _para;
        private SalesSlipDataSet _dataSet;
        private SalesSlipSearchResult _selectedData = null;
        private SalesSearchConstructionAcs _salesSearchConstructionAcs;
        private ColDisplayStatusList _colDisplayStatusList = null;				// ��\����ԃR���N�V�����N���X
        private int _defaultAcceptAcptAnOdrStatus = 30;							//����
        private bool _defaultAcceptAcptAnOdrStatusEnable = true;
        private int _startMovment = 0;											// �N�����[�h 0:�G���g���[ 1:���j���[

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _selectButton;					// �m��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// �I�������{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;					// �����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _setupButton;					// �ݒ�{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;			// ���O�C���S���҃^�C�g��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;				// ���O�C���S���Җ���
        private int _startMode = 0;											// �N�����[�h 1:����// ADD 2011/12/14 yangmj redmine#27359
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.09 TOKUNAGA ADD START
        // ���_�A�N�Z�X�N���X
        SecInfoSetAcs _secInfoSetAcs;

        // ����A�N�Z�X�N���X
        SubSectionAcs _subSectionAcs;

        // ���Аݒ�A�N�Z�X�N���X
        CompanyInfAcs _companyAcs;

        // ���Ӑ挟���A�N�Z�X�N���X
        CustomerInfoAcs _customerInfoAcs;

        // ���Аݒ�f�[�^�N���X
        //CompanyInf _conpamyInf;

        // ����S�̐ݒ�A�N�Z�X�N���X
        SalesTtlStAcs _salesTtlStAcs;

        // ����S�̐ݒ�f�[�^�N���X
        //SalesTtlSt _salesTtlSt;

        // �����_�R�[�h(���O�C�����̋��_�R�[�h)
        // ��ʏ�̋��_�R�[�h�Ƃ͉����֌W�Ȃ�
        private string _sectionCode;

        // ��ʂ̋��_�R�[�h�E����R�[�h
        private string _dspSectionCode;
        private int _dspSubSectionCode;

        // ���Ӑ�R�[�h
        // ������R�[�h
        private int _customerCode;
        private int _claimCode;

        // ���s�ҕ\���敪(DCKHN09211E�̋敪�ƍ��킹��K�v����)
        private const int INP_AGT_DISP = 0;         // 0:����
        private const int INP_AGT_NODISP = 1;       // 1:���Ȃ�
        private const int INP_AGT_NESSESALY = 2;    // 2:�K�{

        // �ݒ�l�ۑ��p�F����S�̐ݒ�D���s�ҕ\���敪
        private int _inpAgentDispDiv;

        // �����Ǘ��敪(SFULN09001E�̋敪�ƍ��킹��K�v����)
        private const int DIV_MNG_SECTION = 0;      // 0:���_
        private const int DIV_MNG_SUBSECTION = 1;   // 1:���_�{��
        private const int DIV_MNG_DIVITION = 2;     // 2:���_�{���{��

        // �ݒ�l�ۑ��p�F���Аݒ�D�����Ǘ��敪
        private int _secMngDiv;

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.09 TOKUNAGA ADD END

        // 2008.11.11 add start [7552]
        /// <summary>�`�[�敪���o�`�� 0:�S�� 1:���� 2:�ԕi</summary>
        private int _extractSlipCdType = 0;
        // 2008.11.11 add end [7552]

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
        // �S���_����
        private const string ct_AllSection = "�S��";
        // �����Z�o���W���[��
        private TotalDayCalculator _totalDayCalculator;
        // ���������t���O
        private bool _autoSearch;

        // ���[�h�����ς݃t���O
        private bool _loaded;

        // �������� ���_�R�[�h
        private string _paraSectionCode;
        // �������� ���_����
        private string _paraSectionName;
        // �������� ���Ӑ�R�[�h
        private int _paraCustomerCode;
        // �������� ���Ӑ於��
        private string _paraCustomerName;
        // �������� �����
        private DateTime _paraSalesDate;
        // �������� �󒍃X�e�[�^�X
        private int _paraAcptAnOdrStatus;
        // �������� ������R�[�h
        private int _paraClaimCode;
        // �������� �����於��
        private string _paraClaimName;

        // �������� �`�[�敪
        private int _paraSalesSlipCd;
        // �������� �S���҃R�[�h
        private string _paraSalesEmployeeCd;
        // �������� ���s�҃R�[�h
        private string _paraSalesInputCode;
        // �������� �󒍎҃R�[�h
        private string _paraFrontEmployeeCd;
        // �������� �S���Җ���
        private string _paraSalesEmployeeName;
        // �������� ���s�Җ���
        private string _paraSalesInputName;
        // �������� �󒍎Җ���
        private string _paraFrontEmployeeName;

        // �ϑ��t�H�[�J�X����
        private IrregularFocusControl _irrFocusCtrl;

        // ��������������t���O
        private bool isFirstOfAutoSearch;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

        private DateGetAcs _dateGet;

        // --- ADD 2009/01/29 ��QID:10621�Ή�------------------------------------------------------>>>>>
        private bool _showEstimateInput = true;
        // --- ADD 2009/01/29 ��QID:10621�Ή�------------------------------------------------------<<<<<

        // --- ADD 2009/02/12 ��QID:11416�Ή�------------------------------------------------------>>>>>
        private SecInfoAcs _secInfoAcs;
        // --- ADD 2009/02/12 ��QID:11416�Ή�------------------------------------------------------<<<<<

        # endregion

        #region �� Private Const
        private const string ctFILENAME_COLDISPLAYSTATUS = "MAHNB04110U_ColSetting.DAT";	// ��\����ԃZ�b�e�B���OXML�t�@�C����

        //�G���[�������b�Z�[�W
        const string ct_InputError = "�̓��͂��s���ł�";
        const string ct_NoInput = "����͂��ĉ�����";
        const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
        const string ct_RangeOverError = "�͂R�����͈͓̔��œ��͂��ĉ�����";
        # endregion

        #region ��Properties
        /// <summary>
        /// �N�����샂�[�h
        /// </summary>
        public int StartMovment
        {
            get { return this._startMovment; }
            set { this._startMovment = value; }
        }
        //-----ADD 2011/12/14 yangmj redmine#27359 ----->>>>>
        /// <summary>
        /// �N�����[�h
        /// </summary>
        public int StartMode
        {
            get { return this._startMode; }
            set { this._startMode = value; }
        }
        //-----ADD 2011/12/14 yangmj redmine#27359 -----<<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
        /// <summary>
        /// ���������t���O
        /// </summary>
        public bool AutoSearch
        {
            get { return _autoSearch; }
            set { _autoSearch = value; }
        }
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string SectionCode
        {
            get { return _paraSectionCode; }
            set { _paraSectionCode = value; }
        }
        /// <summary>
        /// ���_����
        /// </summary>
        public string SectionName
        {
            get { return _paraSectionName; }
            set { _paraSectionName = value; }
        }
        /// <summary>
        /// ���Ӑ�R�[�h
        /// </summary>
        public int CustomerCode
        {
            get { return _paraCustomerCode; }
            set { _paraCustomerCode = value; }
        }
        /// <summary>
        /// ���Ӑ於��
        /// </summary>
        public string CustomerName
        {
            get { return _paraCustomerName; }
            set { _paraCustomerName = value; }
        }
        /// <summary>
        /// ������R�[�h
        /// </summary>
        public int ClaimCode
        {
            get { return _paraClaimCode; }
            set { _paraClaimCode = value; }
        }
        /// <summary>
        /// �������� �����於��
        /// </summary>
        public string ClaimName
        {
            get { return _paraClaimName; }
            set { _paraClaimName = value; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public DateTime SalesDate
        {
            get { return _paraSalesDate; }
            set { _paraSalesDate = value; }
        }
        /// <summary>
        /// �`�[���
        /// </summary>
        public int AcptAnOdrStatus
        {
            get { return _paraAcptAnOdrStatus; }
            set { _paraAcptAnOdrStatus = value; }
        }
        /// <summary>
        /// �`�[�敪
        /// </summary>
        public int SalesSlipCd
        {
            get { return _paraSalesSlipCd; }
            set { _paraSalesSlipCd = value; }
        }
        /// <summary>
        /// �S���҃R�[�h
        /// </summary>
        public string SalesEmployeeCd
        {
            get { return _paraSalesEmployeeCd; }
            set { _paraSalesEmployeeCd = value; }
        }
        /// <summary>
        /// ���s�҃R�[�h
        /// </summary>
        public string SalesInputCode
        {
            get { return _paraSalesInputCode; }
            set { _paraSalesInputCode = value; }
        }
        /// <summary>
        /// �󒍎҃R�[�h
        /// </summary>
        public string FrontEmployeeCd
        {
            get { return _paraFrontEmployeeCd; }
            set { _paraFrontEmployeeCd = value; }
        }
        /// <summary>
        /// �S���Җ���
        /// </summary>
        public string SalesEmployeeName
        {
            get { return _paraSalesEmployeeName; }
            set { _paraSalesEmployeeName = value; }
        }
        /// <summary>
        /// ���s�Җ���
        /// </summary>
        public string SalesInputName
        {
            get { return _paraSalesInputName; }
            set { _paraSalesInputName = value; }
        }
        /// <summary>
        /// �󒍎Җ���
        /// </summary>
        public string FrontEmployeeName
        {
            get { return _paraFrontEmployeeName; }
            set { _paraFrontEmployeeName = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

        // --- ADD 2009/01/29 ��QID:7552,10621�Ή�------------------------------------------------------>>>>>
        /// <summary>
        /// �`�[�敪���o�`��
        /// </summary>
        public ExtractSlipCdType ExtractSlipCdType
        {
            get { return (ExtractSlipCdType)_extractSlipCdType; }
            set { _extractSlipCdType = (int)value; }
        }

        /// <summary>
        /// �������ϕ\���敪
        /// </summary>
        public bool ShowEstimateInput
        {
            get { return _showEstimateInput; }
            set { _showEstimateInput = value; }
        }
        // --- ADD 2009/01/29 ��QID:7552,10621�Ή�------------------------------------------------------<<<<<

        # endregion

        # region �p�u���b�N���\�b�h
        /// <summary>
        /// �v���p�e�B
        /// </summary>
        public bool TComboEditor_SalesFormalCode
        {
            get { return this.tComboEditor_SalesFormalCode.Enabled; }
            set { this.tComboEditor_SalesFormalCode.Enabled = value; }

        }

        /// <summary>
        /// ����`�[�����K�C�h���N�����܂��B
        /// </summary>
        /// <param name="owner">�g�b�v���x���E�B���h�E</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        public DialogResult ShowGuide(IWin32Window owner, string enterpriseCode, out SalesSlipSearchResult data)
        {
            this._enterpriseCode = enterpriseCode;
            this._defaultAcceptAcptAnOdrStatus = 30;
            this._defaultAcceptAcptAnOdrStatusEnable = true;
            data = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            // �����N��para�ɃZ�b�g
            this.AcptAnOdrStatus = _defaultAcceptAcptAnOdrStatus;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

            DialogResult dialogResult = this.ShowDialog(owner);

            if (dialogResult == DialogResult.OK)
            {
                data = this._selectedData;
            }

            return dialogResult;
        }

        /// <summary>
        /// ����`�[�����K�C�h���N�����܂��B
        /// </summary>
        /// <param name="owner">�g�b�v���x���E�B���h�E</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="acceptAcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        public DialogResult ShowGuide(IWin32Window owner, string enterpriseCode, int acceptAcptAnOdrStatus, int estimateDivide, out SalesSlipSearchResult data)
        {
            this._enterpriseCode = enterpriseCode;

            //�P������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
            //if ((acceptAcptAnOdrStatus == 10) && (estimateDivide == 2))
            //{
            //    acceptAcptAnOdrStatus = 15;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            if (acceptAcptAnOdrStatus == 10)
            {
                switch ( estimateDivide )
                {
                    case 2:
                        // �P������
                        acceptAcptAnOdrStatus = 15;
                        break;
                    case 3:
                        // ��������
                        acceptAcptAnOdrStatus = 16;
                        break;
                    case 1:
                    default:
                        // ����
                        acceptAcptAnOdrStatus = 10;
                        break;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

            if ((acceptAcptAnOdrStatus == 10)
            || (acceptAcptAnOdrStatus == 15)
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            || (acceptAcptAnOdrStatus == 16)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
            || (acceptAcptAnOdrStatus == 20)
            || (acceptAcptAnOdrStatus == 30)
            || (acceptAcptAnOdrStatus == 40))
            {
                this._defaultAcceptAcptAnOdrStatus = acceptAcptAnOdrStatus;
                this._defaultAcceptAcptAnOdrStatusEnable = false;
            }
            else
            {
                this._defaultAcceptAcptAnOdrStatus = 30;
                this._defaultAcceptAcptAnOdrStatusEnable = true;
            }

            data = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            // �����N��para�ɃZ�b�g
            this.AcptAnOdrStatus = _defaultAcceptAcptAnOdrStatus;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

            DialogResult dialogResult = this.ShowDialog(owner);

            if (dialogResult == DialogResult.OK)
            {
                data = this._selectedData;
            }

            return dialogResult;
        }
        # endregion

        # region �v���C�x�[�g���\�b�h
        /// <summary>
        /// ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
        /// </summary>
        /// <param name="para">����f�[�^���������p�����[�^�I�u�W�F�N�g</param>
        private void SetDisplayConditionInfo(SalesSlipSearch para)
        {
            // ����`�[�敪
            //0:���|�Ȃ�
            if (para.AccRecDivCd == 0)
            {
                switch (para.SalesSlipCd)
                {
                    // 2008.12.05 add start [8776]
                    case -1:
                        this.tComboEditor_SalesSlipCd.Value = -1;
                        break;
                    // 2008.12.05 add start [8776]
                    case 0:
                        this.tComboEditor_SalesSlipCd.Value = 100;
                        break;
                    case 1:
                        this.tComboEditor_SalesSlipCd.Value = 101;
                        break;
                    case 2:
                        this.tComboEditor_SalesSlipCd.Value = 102;
                        break;
                }
            }
            //1:���|
            else
            {
                this.tComboEditor_SalesSlipCd.Value = para.SalesSlipCd;
            }

            // �`�[���
            this.tComboEditor_SalesFormalCode.Value = para.AcptAnOdrStatus;
            //this.tComboEditor_SalesFormalCode.Enabled = this._defaultAcceptAcptAnOdrStatusEnable;
            Lb_SearchSlipDate_SetName((int)tComboEditor_SalesFormalCode.Value);

            // ����`�[�ԍ�
            this.tEdit_SalesSlipNum_St.Text = para.SalesSlipNumSt.Trim();
            this.tEdit_SalesSlipNum_Ed.Text = para.SalesSlipNumEd.Trim();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            // ���_�R�[�h
            //this._salesSlipSearchAcs.SetSectionComboEditorValue(this.tComboEditor_SalesInpSecCd, para.SectionCode);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //this.tEdit_SectionCodeAllowZero.Text = para.SectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            this.tEdit_SectionCodeAllowZero.Text = para.SectionCode.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            // --- CHG 2009/02/12 ��QID:11416�Ή�------------------------------------------------------>>>>>
            //this.uLabel_SectionName.Text = para.SectionName;
            this.uLabel_SectionName.Text = "";

            // --- ADD 2009/03/06 -------------------------------->>>>>
            if (string.IsNullOrEmpty(para.SectionCode.Trim())
                || para.SectionCode.Trim().PadLeft(2, '0') == "00")
            {
                this.uLabel_SectionName.Text = "�S��";
            }
            // --- ADD 2009/03/06 --------------------------------<<<<<
            else
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == para.SectionCode.Trim())
                    {
                        this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                        break;
                    }
                }
            }
            // --- CHG 2009/02/12 ��QID:11416�Ή�------------------------------------------------------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END			

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA ADD START
            //// ���_�R�[�h���疼�̂��擾����
            //SecInfoSet secInfoset;
            //int status = _secInfoSetAcs.Read(out secInfoset, this._enterpriseCode, para.SectionCode);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    this.uLabel_SectionName.Text = secInfoset.SectionGuideNm.TrimEnd();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            this.tDateEdit_SalesDateSt.SetDateTime(para.SalesDateSt);			// �����(�J�n)
            this.tDateEdit_SalesDateEd.SetDateTime(para.SalesDateEd);			// �����(�I��)
            this.tDateEdit_SearchSlipDateSt.SetDateTime(para.SearchSlipDateSt);	// ���͓�(�J�n)
            this.tDateEdit_SearchSlipDateEd.SetDateTime(para.SearchSlipDateEd);	// ���͓�(�I��)

            this.tEdit_SalesEmployeeCd.Text = para.SalesEmployeeCd.Trim();				// �S���҃R�[�h
            this.uLabel_SalesEmployeeName.Text = para.SalesEmployeeName;				// �S���Җ�

            this.tEdit_SalesInputCode.Text = para.SalesInputCode.Trim();				// ���s�҃R�[�h
            this.uLabel_SalesInputName.Text = para.SalesInputName;						// ���s�Җ�

            this.tNedit_ClaimCode.SetInt(para.ClaimCode);								// ������R�[�h
            this.uLabel_ClaimName.Text = para.ClaimName;								// �����於��

            this.tNedit_CustomerCode.SetInt(para.CustomerCode);							// ���Ӑ�R�[�h
            this.uLabel_CustomerName.Text = para.CustomerName;							// ���Ӑ於��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA ADD START
            this.tEdit_FullModel.Text = para.FullModel;                                 // �i���`��

            // �����Ǘ��敪�����_�̎��͕���R�[�h�͎g�p����Ȃ�
            if (this._secMngDiv != DIV_MNG_SECTION)
            {
                this.tNedit_SubSectionCode.SetInt(para.SubSectionCode);                 // �����R�[�h
                this.uLabel_SubSectionName.Text = para.SubSectionName;                   // ������
                //SubSection subSection;
                //// ����R�[�h���疼�̂�����(para�I�u�W�F�N�g�Ɋi�[����Ă��Ȃ�)
                //status = _subSectionAcs.Read(out subSection, this._enterpriseCode, para.SectionCode, para.SubSectionCode);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    this.uLabel_SectionName.Text = subSection.SubSectionName.TrimEnd();
                //}
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //// �󒍎҃R�[�h
            //this.tEdit_FrontEmployeeCd.Text = para.FrontEmployeeCd;
            // 
            //EmployeeAcs employeeAcs = new EmployeeAcs();
            //// �󒍎҃R�[�h���疼�̂�����(para�I�u�W�F�N�g�Ɋi�[����Ă��Ȃ�)
            //Employee employee;
            //status = employeeAcs.Read(out employee, this._enterpriseCode, para.FrontEmployeeCd);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    this.uLabel_FrontEmployeeName.Text = employee.Name.TrimEnd();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            // �󒍎҃R�[�h
            this.tEdit_FrontEmployeeCd.Text = para.FrontEmployeeCd.Trim();
            // �󒍎Җ�
            this.uLabel_FrontEmployeeName.Text = para.FrontEmployeeName.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA ADD END
        }

        private DateTime ConvertInt2DateTime(Int32 SourceInt)
        {
            // �ϊ����s
            if (SourceInt == 0 || SourceInt < 0)
            {
                return DateTime.Now;
            }


            string strConvertSrc;

            // �ϊ�
            if (SourceInt.ToString().Length == 5)
            {
                strConvertSrc = "0" + SourceInt.ToString();
            }
            else
            {
                strConvertSrc = SourceInt.ToString();
            }

            return new DateTime(int.Parse(strConvertSrc.Substring(0, 2)), int.Parse(strConvertSrc.Substring(3, 2)), int.Parse(strConvertSrc.Substring(5, 2)));

        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (this._para.CustomerCode != customerSearchRet.CustomerCode)
            {
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                CustomerInfo customerInfo = new CustomerInfo();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
                //int status = customerInfoAcs.ReadDBData(_enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
                //if ((status == 0) && ((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                //{
                //    this._para.CustomerCode = customerSearchRet.CustomerCode;
                //    this._para.CustomerName = customerSearchRet.Name + " " + customerSearchRet.Name2;

                //    // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                //    this.SetDisplayConditionInfo(this._para);
                //}
                //else
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_INFO,
                //        this.Name,
                //        "�d����͓��͂ł��܂���B",
                //        -1,
                //        MessageBoxButtons.OK);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
                this._para.CustomerCode = customerSearchRet.CustomerCode;
                this._para.CustomerName = customerSearchRet.Name + " " + customerSearchRet.Name2;

                // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                this.SetDisplayConditionInfo( this._para );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            }
        }

        /// <summary>
        /// ������I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_ClaimSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (this._para.ClaimCode != customerSearchRet.CustomerCode)
            {
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                CustomerInfo customerInfo = new CustomerInfo();

                int status = customerInfoAcs.ReadDBData(_enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
                if ((status == 0) && ((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                {
                    this._para.ClaimCode = customerSearchRet.CustomerCode;
                    this._para.ClaimName = customerSearchRet.Name + " " + customerSearchRet.Name2;
                    // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                    this.SetDisplayConditionInfo(this._para);
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�d����͓��͂ł��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// �ŏ�ʂ̐e�t�H�[���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <returns>�ŏ�ʂ̐e�t�H�[���I�u�W�F�N�g</returns>
        private Form GetTopLevelOwnerForm()
        {
            bool exists = true;
            Form ownerForm = this.Owner;

            while (exists)
            {
                if (ownerForm == null)
                {
                    break;
                }
                if ((ownerForm.Owner != null) && (ownerForm.Owner is Form))
                {
                    ownerForm = ownerForm.Owner;
                }
                else
                {
                    break;
                }
            }

            return ownerForm;
        }

        /// <summary>
        /// ����f�[�^�̌������s���܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Date             :   2011/11/11</br>
        private int Search(SalesSlipSearch para)
        {

            //---ADD 2011/11/11 ---------------------------------------->>>>>
            if (this.tComboEditor_AutoAnswerDivSCM.SelectedIndex == 0)
            {
                //�A�g�`�[�o�͋敪
                para.AutoAnswerDivSCM = 0;
                para.AcceptOrOrderKind = -1;
            }
            else
            {
                //�A�g�`�[�o�͋敪
                if (this.tComboEditor_AutoAnswerDivSCM.SelectedIndex == 1)
                {
                    para.AutoAnswerDivSCM = 1;
                }
                else
                {
                    para.AutoAnswerDivSCM = 2;
                }
                //�A�g�`�[�Ώۋ敪
                if (this.uCheckEditor_PccForNS.Checked == true && this.uCheckEditor_BlPaCOrder.Checked == false)
                {
                    para.AcceptOrOrderKind = 0;
                }
                else if (this.uCheckEditor_PccForNS.Checked == false && this.uCheckEditor_BlPaCOrder.Checked == true)
                {
                    para.AcceptOrOrderKind = 1;
                }
                else if (this.uCheckEditor_PccForNS.Checked == true && this.uCheckEditor_BlPaCOrder.Checked == true)
                {
                    para.AcceptOrOrderKind = 2;
                }
                else
                {
                    para.AcceptOrOrderKind = -1;
                }
            }
            //---ADD 2011/11/11 ----------------------------------------<<<<<
            
            // --- CHG 2009/01/29 ��QID:7552,10621�Ή�------------------------------------------------------>>>>>
            //int status = this._salesSlipSearchAcs.Search(para);
            int status = this._salesSlipSearchAcs.Search(para, this._extractSlipCdType, this._showEstimateInput);
            // --- CHG 2009/01/29 ��QID:7552,10621�Ή�------------------------------------------------------<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //�Z�����̐ݒ�
                this.uGrid_Result_InitializeLayout(this, null);
                // ����f�[�^�O���b�h�̍s�A�Z�����̐ݒ���s���܂��B
                this.SettingGridRow();

                if (this.uGrid_Result.Rows.Count > 0)
                {
                    this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                    this.uGrid_Result.ActiveRow.Selected = true;
                }

                // 2008.11.07 add start [7071]
                string sSort;
                // 2008.11.07 add start [8722]
                //sSort = "SlipDateString Desc, SearchSlipNum Desc";
                sSort = "RowNo Asc";
                // 2008.11.07 add end [8722]
                DataView dv = (DataView)this.uGrid_Result.DataSource;
                dv.Sort = sSort;

                // 2008.11.07 add end [7071]
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                if ( !isFirstOfAutoSearch )
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�Y���f�[�^�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK );
                }
                isFirstOfAutoSearch = false;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "����f�[�^�̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);
            }

            return status;
        }

        /// <summary>
        /// ��ʂ����������܂��B
        /// <br>Update Note      : 2010/12/21 ���N�n��</br>
        /// <br>                   �@�N���A������̃t�H�[�J�X����ύX</br>
        /// </summary>
        private void Clear()
        {
            this._para = new SalesSlipSearch();
            this._para.EnterpriseCode = this._enterpriseCode;
            // modify 2008.11.07 start
            if (String.IsNullOrEmpty(this.SectionCode))
            {
                this._para.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            else
            {
                this._para.SectionCode = this.SectionCode;
            }
            //this._para.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // modify 2008.11.07 end

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            this._para.SectionName = this.GetSectionName( this._para.SectionCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            this._para.AccRecDivCd = 1;

            this._para.AcptAnOdrStatus = _defaultAcceptAcptAnOdrStatus;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //this._para.SearchSlipDateSt = DateTime.Today;
            //this._para.SearchSlipDateEd = DateTime.Today;
            //this._para.SalesDateSt = DateTime.MinValue;
            //this._para.SalesDateEd = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            this._para.SalesDateSt = this.GetPrevTotalDayNextDay( _para.SectionCode );
            this._para.SalesDateEd = DateTime.Today;
            this._para.SearchSlipDateSt = DateTime.MinValue;
            this._para.SearchSlipDateEd = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL

            //�`�[�敪��ݒ�
            // --- CHG 2009/01/29 ��QID:7552�Ή�------------------------------------------------------>>>>>
            //this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, this._para.AcptAnOdrStatus);
            this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, this._para.AcptAnOdrStatus, (SalesSlipSearchAcs.ExtractSlipCdType)this._extractSlipCdType);
            // --- CHG 2009/01/29 ��QID:7552�Ή�------------------------------------------------------<<<<<
            _para.SalesSlipCd = 0;

            this.SetDisplayConditionInfo(this._para);

            this._salesSlipSearchAcs.Clear();
            this.tEdit_SectionCodeAllowZero.Focus();// ADD 2010/12/21
            this.tEdit_SectionCodeAllowZero.SelectAll();// ADD 2010/12/21
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
        /// <summary>
        /// �O�񌎎����������擾
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay(string sectionCode)
        {
            DateTime prevTotalDay;
            int status = _totalDayCalculator.GetHisTotalDayMonthlyAccRec( sectionCode.Trim(), out prevTotalDay );

            // �擾�����s���ȏꍇ�͂R�����O���Z�b�g
            if ( status != 0 || prevTotalDay == DateTime.MinValue || prevTotalDay > DateTime.Today )
            {
                prevTotalDay = DateTime.Today.AddMonths( -3 );
            }
            // �����擾
            prevTotalDay = prevTotalDay.AddDays( 1 );

            return prevTotalDay;
        }
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private string GetSectionName( string sectionCode )
        {
            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read( out sectionInfo, this._enterpriseCode, sectionCode );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                return sectionInfo.SectionGuideNm;
            }
            else
            {
                return string.Empty;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

        /// <summary>
        /// ����f�[�^�O���b�h�̍s�A�Z�����̐ݒ���s���܂��B
        /// </summary>
        private void SettingGridRow()
        {
            try
            {
                // �`����ꎞ��~
                this.uGrid_Result.BeginUpdate();

                // �`�悪�K�v�Ȗ��׌������擾����B
                int cnt = this.uGrid_Result.Rows.Count;

                // �e�s���Ƃ̐ݒ�
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }
            }
            finally
            {
                // �`����J�n
                this.uGrid_Result.EndUpdate();
            }
        }

        /// <summary>
        /// ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// </summary>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // �ԓ`�敪���擾
            int debitNoteDiv = Convert.ToInt32(this._salesSlipSearchAcs.DataView[rowIndex][this._dataSet.SalesSlip.DebitNoteDivColumn.ColumnName]);

            //>>>2010/07/27
            // �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            //{
            //    // �Z�������擾
            //    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.Rows[rowIndex].Cells[col];
            //    if (cell == null) continue;

            //    switch (debitNoteDiv)
            //    {
            //        case 0:			// ���`
            //            {
            //                cell.Appearance.ForeColor = Color.Black;
            //                break;
            //            }
            //        case 1:			// �ԓ`
            //            {
            //                cell.Appearance.ForeColor = Color.Red;
            //                break;
            //            }
            //        case 2:			// ����
            //            {
            //                cell.Appearance.ForeColor = Color.Gray;
            //                break;
            //            }
            //    }
            //}

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Result.DisplayLayout.Rows[rowIndex];
            switch (debitNoteDiv)
            {
                case 0:			// ���`
                    {
                        row.Appearance.ForeColor = Color.Black;
                        break;
                    }
                case 1:			// �ԓ`
                    {
                        row.Appearance.ForeColor = Color.Red;
                        break;
                    }
                case 2:			// ����
                    {
                        row.Appearance.ForeColor = Color.Gray;
                        break;
                    }
            }
            //<<<2010/07/27
        }

        /// <summary>
        /// �I���ς݃f�[�^���擾���܂��B
        /// </summary>
        /// <returns>�I���ς݃f�[�^</returns>
        private SalesSlipSearchResult GetSelectedData()
        {
            // �I���s�̃C���f�b�N�X���擾
            CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Result.DataSource];
            int index = cm.Position;

            DataView dataView = (DataView)this.uGrid_Result.DataSource;

            if (index >= 0)
            {
                SalesSlipSearchResult data = SalesSlipSearchAcs.CreateUIDataFromParamData(
                    (SalesSlipSearchResultWork)dataView[index][this._dataSet.SalesSlip.SalesSlipSearchResultWorkColumn.ColumnName]);

                return data;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// ���[�U�[�ݒ�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void SalesSearchConstructionAcs_DataChanged(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// ��\����ԃN���X���X�g���\�z���܂��B
        /// </summary>
        /// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
        /// <returns>��\����ԃN���X���X�g</returns>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // �O���b�h�����\����ԃN���X���X�g���\�z
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }

        // ADD 2008/11/05 �s��Ή�[7070] ����S�̐ݒ�}�X�^�̔��s�ҋ敪���Q�� �����\�b�h�Ƃ��Ē��o ---------->>>>>
        /// <summary>
        /// ����S�̐ݒ�}�X�^��蔭�s�ҕ\���敪���擾���A�ێ����܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        private void SetInpAgentDispDivFromSalesTtlSt(string sectionCode)
        {
            #region <Guard Phrase/>

            if (string.IsNullOrEmpty(sectionCode.Trim()))
            {
                this._inpAgentDispDiv = INP_AGT_DISP;
                return;
            }

            #endregion  // <Guard Phrase/>

            // ����S�̐ݒ���擾
            // TODO ����SearchAll�͏����I��Search���\�b�h�ɕς��\������B
            ArrayList retSalesTtlSt;
            if (this._salesTtlStAcs == null) this._salesTtlStAcs = new SalesTtlStAcs();

            int status = _salesTtlStAcs.SearchAll(out retSalesTtlSt, this._enterpriseCode);

            if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                foreach (SalesTtlSt salesTtlSt in retSalesTtlSt)
                {
                    if (salesTtlSt.SectionCode.Trim().Equals(sectionCode.Trim()))
                    {
                        // 0:����@1:���Ȃ��@ 2:�K�{
                        this._inpAgentDispDiv = salesTtlSt.InpAgentDispDiv;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// ���s��UI���B���܂��B
        /// </summary>
        /// <param name="hidden">�B���t���O</param>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Date             :   2011/11/11</br>
        private void HideSalesInputUI(bool hidden)
        {
            // ���s�҃��x��
            this.ultraLabel12.Enabled = !hidden;
            this.ultraLabel12.Visible = !hidden;

            // ���s�҃R�[�h
            this.tEdit_SalesInputCode.Enabled = !hidden;
            this.tEdit_SalesInputCode.Visible = !hidden;

            // ���s�Җ�
            this.uLabel_SalesInputName.Enabled = !hidden;
            this.uLabel_SalesInputName.Visible = !hidden;

            // ���s�҃R�[�h�̃K�C�h
            this.uButton_SalesInputGuide.Enabled = !hidden;
            this.uButton_SalesInputGuide.Visible = !hidden;
        }
        // ADD 2008/11/05 �s��Ή�[7070] ����S�̐ݒ�}�X�^�̔��s�ҋ敪���Q�� �����\�b�h�Ƃ��Ē��o ----------<<<<<

        # endregion

        # region �e��R���g���[���C�x���g����
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
        /// <summary>
        /// ���[�h����
        /// </summary>
        private void Loading()
        {
            if ( _loaded ) return;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.09 TOKUNAGA ADD START
            // ���_�E����A�N�Z�X�N���X���쐬
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._subSectionAcs = new SubSectionAcs();

            // �A�N�Z�X�N���X���쐬
            this._customerInfoAcs = new CustomerInfoAcs();
            this._companyAcs = new CompanyInfAcs();
            CompanyInf companyInf;

            // ���Аݒ���擾
            this._companyAcs.Read( out companyInf, this._enterpriseCode );
            if ( companyInf != null )
            {
                this._secMngDiv = companyInf.SecMngDiv;

                // ����Ǘ��敪�����_�ł���Ε��喼���\��
                // 0:���_�@1:���_�{���@2:���_�{���{�ہi�\�[�X���j
                if ( this._secMngDiv == 0 )
                {
                    this.ultraLabel14.Visible = false;
                    this.tNedit_SubSectionCode.Visible = false;
                    this.ultraButton_SubSectionGuide.Visible = false;
                    this.uLabel_SubSectionName.Visible = false;
                }
            }

            //---ADD 2011/11/11 ----------------------------->>>>>
            //�A�g�`�[�o�͋敪�̃f�t�H���g�I����"�A�g�`�[���܂܂Ȃ�"
            this.tComboEditor_AutoAnswerDivSCM.SelectedIndex = 0;
            //�A�g�`�[�Ώۋ敪
            this.uCheckEditor_PccForNS.Enabled = false;
            this.uCheckEditor_BlPaCOrder.Enabled = false;
            //---ADD 2011/11/11 -----------------------------<<<<<

            // �����_�R�[�h���擾
            //SecInfoSet secInfoSet;
            //SecInfoSetAcs secInfoAcs = new SecInfoSetAcs();
            //secInfoAcs.GetSecInfo(SecInfoSetAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            //this._sectionCode = secInfoSet.SectionCode.TrimEnd();
            //if (String.IsNullOrEmpty(this.SectionCode))
            //{
                this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            //}
            //else
            //{
            //    this._sectionCode = this.SectionCode.Trim();
            //}
            //this._dspSectionCode = secInfoSet.SectionCode.TrimEnd();


            // ����S�̐ݒ���擾
            // DEL 2008/11/05 �s��Ή�[7070] ����S�̐ݒ�}�X�^�̔��s�ҋ敪���Q�� �����\�b�h�Ƃ��Ē��o ---------->>>>>
            #region �폜�R�[�h
            //// TODO ����SearchAll�͏����I��Search���\�b�h�ɕς��\������B
            //ArrayList retSalesTtlSt;
            //this._salesTtlStAcs = new SalesTtlStAcs();
            //int status = _salesTtlStAcs.SearchAll( out retSalesTtlSt, this._enterpriseCode );

            //if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            //{
            //    foreach ( SalesTtlSt salesTtlSt in retSalesTtlSt )
            //    {
            //        if ( salesTtlSt.SectionCode.Trim() == this._sectionCode.Trim() )
            //        {
            //            // 0:����@1:���Ȃ��@ 2:�K�{
            //            this._inpAgentDispDiv = salesTtlSt.InpAgentDispDiv;
            //            break;
            //        }
            //    }
            //}
            #endregion  // �폜�R�[�h
            // DEL 2008/11/05 �s��Ή�[7070] ����S�̐ݒ�}�X�^�̔��s�ҋ敪���Q�� �����\�b�h�Ƃ��Ē��o ----------<<<<<
            // ADD 2008/11/05 �s��Ή�[7070]�� ����S�̐ݒ�}�X�^�̔��s�ҋ敪���Q�� �����\�b�h�Ƃ��Ē��o
            SetInpAgentDispDivFromSalesTtlSt(this._sectionCode);

            // �{�^���C���[�W��ݒ�
            this.SectionCodeGuide_ultraButton.ImageList = this._imageList16;
            this.SectionCodeGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;

            this.ultraButton_SubSectionGuide.ImageList = this._imageList16;
            this.ultraButton_SubSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_FrontEmployeeCd.ImageList = this._imageList16;
            this.uButton_FrontEmployeeCd.Appearance.Image = (int)Size16_Index.STAR1;

            // �f�t�H���g�l���N���A
            this.tEdit_FullModel.Clear();


            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.09 TOKUNAGA ADD END

            this.uButton_SalesEmployeeGuide.ImageList = this._imageList16;
            this.uButton_SalesInputGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_ClaimGuide.ImageList = this._imageList16;

            this.uButton_SalesEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SalesInputGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_ClaimGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._salesSlipSearchAcs.ReadInitData( this._enterpriseCode );

            // �X�L�����[�h
            List<string> controlNameList = new List<string>();
            //controlNameList.Add( this.groupBox_ExtractCondition1.Name );
            //controlNameList.Add( this.groupBox_ExtractCondition2.Name );
            controlNameList.Add(this.ultraExpandableGroupBox1.Name);
            //controlNameList.Add(this.groupBox_ExtractCondition3.Name);
            //controlNameList.Add(this.groupBox_ExtractCondition4.Name);
            //controlNameList.Add(this.groupBox_ExtractCondition5.Name);
            //controlNameList.Add(this.groupBox_ExtractCondition6.Name);
            this._controlScreenSkin.SetExceptionCtrl( controlNameList );
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin( this );

            // �X�L���N���X�őΉ��ł��Ȃ��R���g���[���̃J���[��ݒ肷��
            try
            {
                CustomUltraGridAppearance gridAppearance = this._controlScreenSkin.GetGridAppearance().Clone();
                //this.uLabel_ExtractConditionTitle.Appearance.BackColor = gridAppearance.GridHeaderAppearance.BackColor;
                //this.uLabel_ExtractConditionTitle.Appearance.BackColor2 = gridAppearance.GridHeaderAppearance.BackColor2;
                //this.uLabel_ExtractConditionTitle.Appearance.BackGradientStyle = gridAppearance.GridHeaderAppearance.BackGradientStyle;
                //this.uLabel_ExtractConditionTitle.Appearance.ForeColor = gridAppearance.GridHeaderAppearance.ForeColor;
                //this.panel_ExtractConditionTitleTitle.BackColor = gridAppearance.GridHeaderAppearance.BackColor2;
            }
            catch ( NullReferenceException ) { }

            // �ŏ�ʂ̐e�t�H�[���I�u�W�F�N�g���擾���܂��B
            Form ownerForm = this.GetTopLevelOwnerForm();

            if ( ownerForm != null )
            {
                //if ((ownerForm.Height < this.Height) && (ownerForm.Width < this.Width)) return;

                //int afterHeight = Convert.ToInt32(ownerForm.Height * 0.95);
                //int afterWidth = Convert.ToInt32(ownerForm.Width * 0.95);
                int afterHeight = Convert.ToInt32( ownerForm.Height );
                int afterWidth = Convert.ToInt32( ownerForm.Width );

                int afterTop = Convert.ToInt32( ownerForm.Top + ((ownerForm.Height - afterHeight) * 0.5) );
                int afterLeft = Convert.ToInt32( ownerForm.Left + ((ownerForm.Width - afterWidth) * 0.5) );

                this.Size = new Size( afterWidth, afterHeight );
                this.Location = new Point( afterLeft, afterTop );
            }

            //this._salesSlipSearchAcs.SetSectionComboEditor(ref this.tComboEditor_SalesInpSecCd, true);


            this._salesSlipSearchAcs.DataView.Sort = "EnterpriseCode, SearchSlipNum DESC";
            this.uGrid_Result.DataSource = this._salesSlipSearchAcs.DataView;   // MEMO:�O���b�h�Ƀo�C���h

            /// ��ʂ�����������B
            this.Clear();

            // �O���b�h�ݒ�
            this.uGrid_Result_InitializeLayout(this, null);

            this.timer_InitFocusSetting.Enabled = true;

            if ( (this._defaultAcceptAcptAnOdrStatus == 20)
            || (this._defaultAcceptAcptAnOdrStatus == 30)
            || (this._defaultAcceptAcptAnOdrStatus == 10)
            || (this._defaultAcceptAcptAnOdrStatus == 15)
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            || (this._defaultAcceptAcptAnOdrStatus == 16)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
            || (this._defaultAcceptAcptAnOdrStatus == 40) )
            {
                this._para.AcptAnOdrStatus = this._defaultAcceptAcptAnOdrStatus;

                // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                this.SetDisplayConditionInfo( this._para );
            }

            // ����ݒ�̐ݒ�𔽉f����
            if ( this._salesSearchConstructionAcs.ExecAutoSearchValue == SalesSearchConstructionAcs.ExecAutoSearch_ON )
            {
                this.timer_Search.Enabled = true;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //this.tEdit_SectionCodeAllowZero.Focus();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            // �m��{�^��Enable�ݒ�
            ChangeDecisionButtonEnable( StartMovment == 0 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            _loaded = true;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

        /// <summary>
        /// ����f�[�^�����K�C�h���[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void MAHNB04110UA_Load(object sender, EventArgs e)
        {
            // --- ADD 2009/01/29 ��QID:10621�Ή�------------------------------------------------------>>>>>
            // �`�[��ʐݒ�
            this.tComboEditor_SalesFormalCode.Items.Clear();
            if (this._showEstimateInput)
            {
                this.tComboEditor_SalesFormalCode.Items.Add(30, "����");
                this.tComboEditor_SalesFormalCode.Items.Add(40, "�ݏo");
                this.tComboEditor_SalesFormalCode.Items.Add(20, "��");
                this.tComboEditor_SalesFormalCode.Items.Add(10, "�ʏ팩��");
                this.tComboEditor_SalesFormalCode.Items.Add(15, "�P������");
                this.tComboEditor_SalesFormalCode.Items.Add(16, "��������");
                this.tComboEditor_SalesFormalCode.Items.Add(-1, "�S��");
            }
            else
            {
                this.tComboEditor_SalesFormalCode.Items.Add(30, "����");
                this.tComboEditor_SalesFormalCode.Items.Add(40, "�ݏo");
                this.tComboEditor_SalesFormalCode.Items.Add(20, "��");
                this.tComboEditor_SalesFormalCode.Items.Add(10, "�ʏ팩��");
                this.tComboEditor_SalesFormalCode.Items.Add(15, "�P������");
                this.tComboEditor_SalesFormalCode.Items.Add(-1, "�S��");
            }
            // --- ADD 2009/01/29 ��QID:10621�Ή�------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Loading();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
        }

        /// <summary>
        /// �S���҃K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_SalesEmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (this._para.SalesEmployeeCd.Trim() != employee.EmployeeCode.Trim()))
            {
                this._para.SalesEmployeeCd = employee.EmployeeCode.Trim();
                this._para.SalesEmployeeName = employee.Name;

                // ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
                this.SetDisplayConditionInfo(this._para);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // ���t�H�[�J�X
                if ( tEdit_SalesInputCode.Enabled )
                {
                    tEdit_SalesInputCode.Focus();
                }
                else if ( tEdit_FrontEmployeeCd.Enabled )
                {
                    tEdit_FrontEmployeeCd.Focus();
                }
                else
                {
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt;
            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._para.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                this._para.MakerName = makerUMnt.MakerName.Trim();

                // ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
                this.SetDisplayConditionInfo(this._para);
            }
        }

        /// <summary>
        /// ���͎҃K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_SalesInputGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (this._para.SalesInputCode.Trim() != employee.EmployeeCode.Trim()))
            {
                this._para.SalesInputCode = employee.EmployeeCode.Trim();
                this._para.SalesInputName = employee.Name;

                // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                this.SetDisplayConditionInfo(this._para);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // ���t�H�[�J�X
                if ( tEdit_FrontEmployeeCd.Enabled )
                {
                    tEdit_FrontEmployeeCd.Focus();
                }
                else
                {
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note      :   2015/05/08 gaocheng</br>
        /// <br>�Ǘ��ԍ�         :   11175085-00</br>
        /// <br>                 :   Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��</br> 
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            // ���Ӑ�K�C�h�p���C�u�������ύX
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// ���Ӑ挟���A�N�Z�X�N���X
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                this.SetDisplayConditionInfo(this._para);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // ���t�H�[�J�X
                if ( tNedit_ClaimCode.Enabled )
                {
                    tNedit_ClaimCode.Focus();
                }
                // else // DEL gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� 
                else if (tComboEditor_SalesFormalCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s�
                {
                    tComboEditor_SalesFormalCode.Focus();
                }
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ---->>>>>
                else
                {
                    tComboEditor_SalesSlipCd.Focus();
                }
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ----<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// ������K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note : 2015/05/08 gaocheng</br>
        /// <br>�Ǘ��ԍ�    : 11175085-00</br>
        /// <br>            : Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��</br>
        private void uButton_ClaimGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            // ������K�C�h�p���C�u�������ύX
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// �����挟���A�N�Z�X�N���X
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_ClaimSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                this.SetDisplayConditionInfo(this._para);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // ���t�H�[�J�X
                // tComboEditor_SalesFormalCode.Focus(); // DEL gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ---->>>>>
                if (tComboEditor_SalesFormalCode.Enabled)
                {
                    tComboEditor_SalesFormalCode.Focus();
                }
                else
                {
                    tComboEditor_SalesSlipCd.Focus();
                }
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ----<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_ClaimSelect);
            //customerSearchForm.ShowDialog(this);
        }


        /// <summary>
        /// ���i�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_GoodsGuide_Click(object sender, EventArgs e)
        {
            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

            GoodsUnitData goodsUnitData;
            GoodsCndtn para = new GoodsCndtn();
            para.EnterpriseCode = this._enterpriseCode;

            DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, para, out goodsUnitData);

            if ((dialogResult == DialogResult.OK) && (goodsUnitData != null) && (this._para.GoodsNo.Trim() != goodsUnitData.GoodsNo.Trim()))
            {
                this._para.GoodsNo = goodsUnitData.GoodsNo;
                this._para.GoodsName = goodsUnitData.GoodsName;

                // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                this.SetDisplayConditionInfo(this._para);
            }
        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Date             :   2011/11/11</br>
        /// <br>Update Note      :   2015/05/08 gaocheng</br>
        /// <br>�Ǘ��ԍ�         :   11175085-00</br>
        /// <br>                 :   Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            SalesSlipSearch para = this._para.Clone();

            switch (e.PrevCtrl.Name)
            {
                // �`�[�敪
                case "tComboEditor_SalesSlipCd":
                    {
                        int code = Convert.ToInt32(this.tComboEditor_SalesSlipCd.Value);

                        if (para.SalesSlipCd != code)
                        {
                            para.SalesSlipCd = Convert.ToInt32(this.tComboEditor_SalesSlipCd.Value);

                            //�|����
                            if ((para.SalesSlipCd == 0) || (para.SalesSlipCd == 1))
                            {
                                para.AccRecDivCd = 1;
                            }
                            //����
                            else
                            {
                                para.AccRecDivCd = 0;
                            }

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // �`�[���
                case "tComboEditor_SalesFormalCode":
                    {
                        int code = Convert.ToInt32(this.tComboEditor_SalesFormalCode.Value);

                        if (para.AcptAnOdrStatus != code)
                        {
                            //�`�[�敪��ݒ�
                            //this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, code);
                            // 2008.12.05 modify start [8776]
                            int acptStatus = Convert.ToInt32(this.tComboEditor_SalesFormalCode.Value);
                            if (acptStatus == 16)
                            {
                                // �������ς̎��̂݁u�S�āv�ȊO�͑I��s�\
                                para.SalesSlipCd = -1;
                            }
                            else
                            {
                                para.SalesSlipCd = 0;
                            }
                            para.AccRecDivCd = 1;

                            para.AcptAnOdrStatus = acptStatus;// Convert.ToInt32(this.tComboEditor_SalesFormalCode.Value);
                            // 2008.12.05 modify end [8776]

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // �`�[�ԍ��i�J�n�j
                case "tEdit_SalesSlipNum_St":
                    {
                        string code = this.tEdit_SalesSlipNum_St.Text.Trim();

                        if (para.SalesSlipNumSt.Trim() != code)
                        {
                            para.SalesSlipNumSt = this.tEdit_SalesSlipNum_St.Text;

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // �`�[�ԍ��i�I���j
                case "tEdit_SalesSlipNum_Ed":
                    {
                        string code = this.tEdit_SalesSlipNum_Ed.Text.Trim();

                        if (para.SalesSlipNumEd.Trim() != code)
                        {
                            para.SalesSlipNumEd = this.tEdit_SalesSlipNum_Ed.Text;

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //// ���Ӑ撍��
                //case "tEdit_PartySaleSlipNum":
                //    {
                //        string code = this.tEdit_PartySaleSlipNum.Text.Trim();

                //        if (para.PartySaleSlipNum.Trim() != code)
                //        {
                //            para.PartySaleSlipNum = this.tEdit_PartySaleSlipNum.Text;

                //            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                //            this.SetDisplayConditionInfo(para);
                //        }

                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

                // �`�[���t�i�J�n�j
                case "tDateEdit_SalesDateSt":
                    {
                        DateTime date = this.tDateEdit_SalesDateSt.GetDateTime();
                        if (para.SalesDateSt != date)
                        {
                            para.SalesDateSt = date;

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // �`�[���t�i�I���j
                case "tDateEdit_SalesDateEd":
                    {
                        DateTime date = this.tDateEdit_SalesDateEd.GetDateTime();
                        if (para.SalesDateEd != date)
                        {
                            para.SalesDateEd = date;

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // ���͓��i�J�n�j
                case "tDateEdit_SearchSlipDateSt":
                    {
                        DateTime date = this.tDateEdit_SearchSlipDateSt.GetDateTime();
                        if (para.SearchSlipDateSt != date)
                        {
                            para.SearchSlipDateSt = date;

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // ���͓��i�I���j
                case "tDateEdit_SearchSlipDateEd":
                    {
                        DateTime date = this.tDateEdit_SearchSlipDateEd.GetDateTime();
                        if (para.SearchSlipDateEd != date)
                        {
                        para.SearchSlipDateEd = date;

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // �S���҃R�[�h
                case "tEdit_SalesEmployeeCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SalesEmployeeCd.Text.Trim();

                        if (para.SalesEmployeeCd.Trim() != code)
                        {
                            if (code == "")
                            {
                                para.SalesEmployeeCd = "";
                                para.SalesEmployeeName = "";
                            }
                            else
                            {
                                Employee data;
                                int status = this._salesSlipSearchAcs.GetEmployee(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    para.SalesEmployeeCd = data.EmployeeCode;
                                    para.SalesEmployeeName = data.Name;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������]�ƈ������݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "�]�ƈ����̂̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                            //// NextCtrl����
                            //if (canChangeFocus)
                            //{
                            //    if (!e.ShiftKey)
                            //    {
                            //        switch (e.Key)
                            //        {
                            //            case Keys.Return:
                            //            case Keys.Tab:
                            //                {
                            //                    if (this.tEdit_SalesEmployeeCd.Text == "")
                            //                    {
                            //                        e.NextCtrl = this.uButton_SalesEmployeeGuide;
                            //                    }
                            //                    else
                            //                    {
                            //                        e.NextCtrl = this.tEdit_SalesInputCode;
                            //                    }
                            //                    break;
                            //                }
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    this.tEdit_SalesEmployeeCd.SelectAll();
                            //    e.NextCtrl = e.PrevCtrl;
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                        // NextCtrl����
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( this.tEdit_SalesEmployeeCd.Text == "" )
                                            {
                                                e.NextCtrl = this.uButton_SalesEmployeeGuide;
                                            }
                                            else
                                            {
                                                // 2008.11.20 add start [8042]
                                                if (this.tEdit_SalesInputCode.Visible)
                                                {
                                                    e.NextCtrl = this.tEdit_SalesInputCode;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tEdit_FrontEmployeeCd;
                                                }
                                                // 2008.11.20 add end [8042]
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            this.tEdit_SalesEmployeeCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

                        break;
                    }
                // 2008.11.20 add start [8042]
                // �S���҃{�^��
                case "uButton_SalesEmployeeGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tEdit_SalesSlipNum_Ed;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.tEdit_SalesInputCode.Visible)
                                        {
                                            e.NextCtrl = this.tEdit_SalesInputCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_FrontEmployeeCd;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                    // 2008.11.20 add end [8042]

                // TODO:���s�҃R�[�h
                case "tEdit_SalesInputCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SalesInputCode.Text.Trim();

                        if (para.SalesInputCode.Trim() != code)
                        {
                            if (code == "")
                            {
                                para.SalesInputCode = "";
                                para.SalesInputName = "";
                            }
                            else
                            {
                                Employee data;
                                int status = this._salesSlipSearchAcs.GetEmployee(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    para.SalesInputCode = data.EmployeeCode;
                                    para.SalesInputName = data.Name;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������]�ƈ������݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "�]�ƈ����̂̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo(para);

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                            //// NextCtrl����
                            //if (canChangeFocus)
                            //{
                            //    if (!e.ShiftKey)
                            //    {
                            //        switch (e.Key)
                            //        {
                            //            case Keys.Return:
                            //            case Keys.Tab:
                            //                {
                            //                    if (this.tEdit_SalesInputCode.Text == "")
                            //                    {
                            //                        e.NextCtrl = this.uButton_SalesInputGuide;
                            //                    }
                            //                    else
                            //                    {
                            //                        e.NextCtrl = this.tNedit_CustomerCode;
                            //                    }
                            //                    break;
                            //                }
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    this.tEdit_SalesInputCode.SelectAll();
                            //    e.NextCtrl = e.PrevCtrl;
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                        //else
                        //{
                        //    // NextCtrl����
                        //    switch (e.Key)
                        //    {
                        //        case Keys.Down:
                        //            {
                        //                if (this.uGrid_Result.Rows.Count > 0)
                        //                {
                        //                    e.NextCtrl = this.uGrid_Result;
                        //                }
                        //                break;
                        //            }
                        //    }
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                        // NextCtrl����
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( this.tEdit_SalesInputCode.Text == "" )
                                            {
                                                e.NextCtrl = this.uButton_SalesInputGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_FrontEmployeeCd;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            this.tEdit_SalesInputCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // �󒍎�
                case "tEdit_FrontEmployeeCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_FrontEmployeeCd.Text.Trim();

                        if ( para.FrontEmployeeCd.Trim() != code )
                        {
                            if ( code == string.Empty )
                            {
                                para.FrontEmployeeCd = string.Empty;
                                para.FrontEmployeeName = string.Empty;
                            }
                            else
                            {
                                Employee data;
                                int status = this._salesSlipSearchAcs.GetEmployee( this._enterpriseCode, code, out data );

                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    para.FrontEmployeeCd = data.EmployeeCode;
                                    para.FrontEmployeeName = data.Name;
                                }
                                else if ( (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF) )
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������]�ƈ������݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "�]�ƈ����̂̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                            }

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo( para );
                        }

                        // NextCtrl����
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // DEL 2008/11/05 �s��Ή�[7078]���K�C�h�̃t�H�[�J�X����
                                            //if ( tEdit_SalesInputCode.Text == string.Empty )
                                            if (tEdit_FrontEmployeeCd.Text == string.Empty) // ADD 2008/11/05 �s��Ή�[7078] �K�C�h�̃t�H�[�J�X����
                                            {
                                                e.NextCtrl = this.uButton_FrontEmployeeCd;
                                            }
                                            else
                                            {
                                                // 2008.12.09 modify start [8879]
                                                //e.NextCtrl = this.uGrid_Result;
                                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                                // 2008.12.09 modify end [8879]
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            this.tEdit_FrontEmployeeCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                // ���Ӑ�R�[�h
                case "tNedit_CustomerCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_CustomerCode.GetInt();

                        if (para.CustomerCode != code)
                        {
                            if (code == 0)
                            {
                                para.CustomerCode = 0;
                                para.CustomerName = "";
                            }
                            else
                            {
                                CustomerInfo data;
                                int status = this._salesSlipSearchAcs.GetCustomer(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                                    //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                                    //CustomerInfo customerInfo = new CustomerInfo();

                                    //int st = customerInfoAcs.ReadDBData(_enterpriseCode, data.CustomerCode, out customerInfo);
                                    //if ((st == 0) && ((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                                    //{
                                    //    para.CustomerCode = data.CustomerCode;
                                    //    para.CustomerName = data.Name + " " + data.Name2;
                                    //}
                                    //else
                                    //{
                                    //    TMsgDisp.Show(
                                    //        this,
                                    //        emErrorLevel.ERR_LEVEL_INFO,
                                    //        this.Name,
                                    //        "�d����͓��͂ł��܂���B",
                                    //        -1,
                                    //        MessageBoxButtons.OK);
                                    //}
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                                    para.CustomerCode = data.CustomerCode;
                                    para.CustomerName = data.Name + " " + data.Name2;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����链�Ӑ悪���݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���Ӑ於�̂̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo( para );

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                            //// NextCtrl����
                            //if (canChangeFocus)
                            //{
                            //    if (!e.ShiftKey)
                            //    {
                            //        switch (e.Key)
                            //        {
                            //            case Keys.Return:
                            //            case Keys.Tab:
                            //                {
                            //                    if (this.tNedit_CustomerCode.GetInt() == 0)
                            //                    {
                            //                        e.NextCtrl = this.uButton_CustomerGuide;
                            //                    }
                            //                    else
                            //                    {
                            //                        e.NextCtrl = this.tNedit_ClaimCode;
                            //                    }
                            //                    break;
                            //                }
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    this.tNedit_CustomerCode.SelectAll();
                            //    e.NextCtrl = e.PrevCtrl;
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                        // NextCtrl����
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( this.tNedit_CustomerCode.GetInt() == 0 )
                                            {
                                                e.NextCtrl = this.uButton_CustomerGuide;
                                            }
                                            else if ( tNedit_ClaimCode.Enabled )
                                            {
                                                e.NextCtrl = this.tNedit_ClaimCode;
                                            }
                                            // else // DEL gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��
                                            else if (this.tComboEditor_SalesFormalCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��
                                            {
                                                e.NextCtrl = this.tComboEditor_SalesFormalCode;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ---->>>>>
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_SalesSlipCd;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ----<<<<<
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            this.tNedit_CustomerCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

                        break;
                    }
                // ������R�[�h
                case "tNedit_ClaimCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_ClaimCode.GetInt();

                        if (para.ClaimCode != code)
                        {
                            if (code == 0)
                            {
                                para.ClaimCode = 0;
                                para.ClaimName = "";
                            }
                            else
                            {
                                CustomerInfo data;
                                int status = this._salesSlipSearchAcs.GetCustomer(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                                    //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                                    //CustomerInfo customerInfo = new CustomerInfo();

                                    //int st = customerInfoAcs.ReadDBData( _enterpriseCode, data.CustomerCode, out customerInfo );
                                    //if ((st == 0) && ((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                                    //{
                                    //    para.ClaimCode = data.CustomerCode;
                                    //    para.ClaimName = data.Name + " " + data.Name2;
                                    //}
                                    //else
                                    //{
                                    //    TMsgDisp.Show(
                                    //        this,
                                    //        emErrorLevel.ERR_LEVEL_INFO,
                                    //        this.Name,
                                    //        "�d����͓��͂ł��܂���B",
                                    //        -1,
                                    //        MessageBoxButtons.OK);
                                    //}
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                                    para.ClaimCode = data.CustomerCode;
                                    para.ClaimName = data.Name + " " + data.Name2;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����链�Ӑ悪���݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���Ӑ於�̂̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo( para );

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                            //// NextCtrl����
                            //if (canChangeFocus)
                            //{
                            //    if (!e.ShiftKey)
                            //    {
                            //        switch (e.Key)
                            //        {
                            //            case Keys.Return:
                            //            case Keys.Tab:
                            //                {
                            //                    if (this.tNedit_ClaimCode.GetInt() == 0)
                            //                    {
                            //                        e.NextCtrl = this.uButton_ClaimGuide;
                            //                    }
                            //                    else
                            //                    {
                            //                        e.NextCtrl = this.tComboEditor_SalesInpSecCd;
                            //                    }
                            //                    break;
                            //                }
                            //            case Keys.Down:
                            //                {
                            //                    break;
                            //                }
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    this.tNedit_ClaimCode.SelectAll();
                            //    e.NextCtrl = e.PrevCtrl;
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                        // NextCtrl����
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( this.tNedit_ClaimCode.GetInt() == 0 )
                                            {
                                                e.NextCtrl = this.uButton_ClaimGuide;
                                            }
                                            // else // DEL gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��
                                            else if (tComboEditor_SalesFormalCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��
                                            {
                                                e.NextCtrl = tComboEditor_SalesFormalCode;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ---->>>>>
                                            else
                                            {
                                                e.NextCtrl = tComboEditor_SalesSlipCd;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ----<<<<<
                                            break;
                                        }
                                    case Keys.Down:
                                        {
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            this.tNedit_ClaimCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

                        break;
                    }
                // ������K�C�h�{�^��
                case "uButton_ClaimGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.uGrid_Result.Rows.Count > 0)
                                        {
                                            e.NextCtrl = this.uGrid_Result;
                                        }
                                        else
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                                            //e.NextCtrl = this.tComboEditor_SalesInpSecCd;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                                            // e.NextCtrl = tComboEditor_SalesFormalCode; // DEL gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ---->>>>>
                                            if (tComboEditor_SalesFormalCode.Enabled)
                                            {
                                                e.NextCtrl = tComboEditor_SalesFormalCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tComboEditor_SalesSlipCd;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ----<<<<<
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //// ������͋��_
                //case "tComboEditor_SalesInpSecCd":
                //    {
                //        string code = this.tComboEditor_SalesInpSecCd.Value.ToString();

                //        if (code.Trim() != para.SectionCode.Trim())
                //        {
                //            para.SectionCode = code;
                //            para.SectionName = this._salesSlipSearchAcs.GetName_FromSecInfoSet(code);

                //            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                //            this.SetDisplayConditionInfo(para);
                //        }

                //        if (!e.ShiftKey)
                //        {
                //            switch (e.Key)
                //            {
                //                case Keys.Return:
                //                case Keys.Tab:
                //                    {
                //                        if (this.uGrid_Result.Rows.Count > 0)
                //                        {
                //                            e.NextCtrl = this.uGrid_Result;
                //                        }
                //                        else
                //                        {
                //                            e.NextCtrl = this.tComboEditor_SalesFormalCode;
                //                        }
                //                        break;
                //                    }
                //            }
                //        }
                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // ���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        bool canChangeFocus = true;

                        //------------------------------------
                        // ���_�[���R�[�h�擾
                        //------------------------------------
                        UiSet uiset;
                        uiSetControl1.ReadUISet( out uiset, tEdit_SectionCodeAllowZero.Name );
                        string sectionCodeZero = new string( '0', uiset.Column );

                        //------------------------------------
                        // ���_�R�[�h�擾
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();
                        //bool inputFlag = (sectionCode != sectionCodeZero);
                        bool inputFlag = true;

                        if ( sectionCode != para.SectionCode )
                        {

                            //------------------------------------
                            // ����
                            //------------------------------------
                            if ( sectionCode != string.Empty && sectionCode != sectionCodeZero )
                            {
                                if ( _secInfoSetAcs == null )
                                {
                                    _secInfoSetAcs = new SecInfoSetAcs();
                                }
                                SecInfoSet sectionInfo;
                                int status = this._secInfoSetAcs.Read( out sectionInfo, this._enterpriseCode, sectionCode );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    // ���ʕϐ��ɕۑ�
                                    this._dspSectionCode = sectionInfo.SectionCode.TrimEnd();

                                    // �p�����[�^�ɕۑ�
                                    para.SectionCode = sectionInfo.SectionCode.TrimEnd();
                                    para.SectionName = sectionInfo.SectionGuideNm.TrimEnd();
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����鋒�_�����݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���_���̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }
                            else
                            {
                                // �N���A����
                                // ���ʕϐ��ɕۑ�
                                this._dspSectionCode = sectionCodeZero;
                                // �p�����[�^�ɕۑ�
                                para.SectionCode = sectionCodeZero;
                                para.SectionName = ct_AllSection;
                            }

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo( para );

                        }
                        else
                        {
                        }

                        // �t�H�[�J�X����
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if ( inputFlag )
                                            {
                                                // 2008.12.09 modify start[8879]
                                                //if ( tNedit_SubSectionCode.Enabled )
                                                if (tNedit_SubSectionCode.Visible)
                                                // 2008.12.09 modify end[8879]
                                                {
                                                    e.NextCtrl = this.tNedit_SubSectionCode;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tNedit_CustomerCode;
                                                }
                                            }
                                            else
                                            {
                                                e.NextCtrl = SectionCodeGuide_ultraButton;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            tEdit_SectionCodeAllowZero.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                // ����R�[�h
                case "tNedit_SubSectionCode":
                    {
                        bool canChangeFocus = true;

                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();
                        int subSectionCode = this.tNedit_SubSectionCode.GetInt();
                        bool inputFlag = (subSectionCode != 0);

                        if ( subSectionCode != para.SubSectionCode )
                        {
                            if ( subSectionCode != 0 )
                            {
                                if ( _subSectionAcs == null )
                                {
                                    _subSectionAcs = new SubSectionAcs();
                                }
                                SubSection subSection;
                                int status = this._subSectionAcs.Read( out subSection, this._enterpriseCode, sectionCode, subSectionCode );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    //this.tNedit_SubSectionCode.Text = subSection.SubSectionName.TrimEnd();

                                    // ���ʕϐ��ɕۑ�
                                    this._dspSubSectionCode = subSection.SubSectionCode;

                                    // �p�����[�^�ɕۑ�
                                    para.SubSectionCode = subSection.SubSectionCode;
                                    para.SubSectionName = subSection.SubSectionName;
                                }
                                else if ( (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF) )
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����镔�傪���݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���喼�̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                            }
                            else
                            {
                                this._dspSubSectionCode = 0;

                                // �p�����[�^����폜
                                para.SubSectionCode = 0;
                                para.SubSectionName = string.Empty;
                            }

                            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                            this.SetDisplayConditionInfo( para );
                        }

                        // �t�H�[�J�X����
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if ( inputFlag )
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.ultraButton_SubSectionGuide;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            tNedit_SubSectionCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                // �^��
                case "tEdit_FullModel":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        // e.NextCtrl = tComboEditor_SalesFormalCode; // DEL gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C��
                                        //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ---->>>>>
                                        if (tComboEditor_SalesFormalCode.Enabled)
                                        {
                                            e.NextCtrl = tComboEditor_SalesFormalCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tComboEditor_SalesSlipCd;
                                        }
                                        //---- ADD gaocheng 2015/05/08 for Redmine#45800 �v��`�[�ďo�������̃J�[�\���ړ��̕s��̏C�� ----<<<<<
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        //e.NextCtrl = tDateEdit_SalesDateSt;//DEL 2011/11/11
                                        e.NextCtrl = tComboEditor_AutoAnswerDivSCM;//ADD 2011/11/11
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                //---ADD 2011/11/11 ------------------------------->>>>>
                // �A�g�`�[�o�͋敪
                case "tComboEditor_AutoAnswerDivSCM":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tEdit_FullModel;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tDateEdit_SalesDateSt;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                //---ADD 2011/11/11 -------------------------------<<<<<
                // �������ʃO���b�h
                case "uGrid_Result":
                    {
                        if (e.Key == Keys.Return)
                        {
                            this._selectedData = this.GetSelectedData();
                            if (StartMovment == 1)
                            {
                                break;
                            }

                            if (this._selectedData != null)
                            {
                                this._dialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }

                        break;
                    }
            }

            // ��������̓��e�Ɣ�r����
            ArrayList arRetList = para.Compare(this._para);

            if (arRetList.Count > 0)
            {
                this._para = para.Clone();

                // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                this.SetDisplayConditionInfo(this._para);

                this.timer_Search.Enabled = true;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            // �ϑ��t�H�[�J�X����
            _irrFocusCtrl.ReflectIrregularNextControl( e );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
        }

        /// <summary>
        /// �������ʃO���b�h���C�A�E�g�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            string codeFormat = "#0;-#0;''";
            string moneyFormat = "#,##0;-#,##0;''";
            string dateFormat = "yyyy/MM/dd";

            int visiblePosition = 1;
            string acptAnOdrStatusTiTle = "";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Result.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            }

            switch (_para.AcptAnOdrStatus)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
                //case 10: acptAnOdrStatusTiTle = "����"; break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
                case 10:
                case 15:
                case 16:
                    acptAnOdrStatusTiTle = "����"; 
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
                case 20: acptAnOdrStatusTiTle = "��"; break;
                case 30: acptAnOdrStatusTiTle = "����"; break;
                case 40: acptAnOdrStatusTiTle = "�ݏo"; break;
                default: acptAnOdrStatusTiTle = "����"; break;
            }

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            ////�o�ד����o�׎��̂ݕ\����
            //if (_para.AcptAnOdrStatus == 40)
            //{
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Header.Caption = "�ݏo��";
            //    //Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Width = 100;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //    //Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            //else
            //{
            //    //�����
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "��";
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Width = 100;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //    //Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            // 2008.11.07 add start [7071]
            //�����
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Fixed = true;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Caption = "No";
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Width = 60;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // 2008.11.07 add end [7071]

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            //�����
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "��";
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            //�`�[�ԍ�
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
            //Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Format = codeFormat;

            //�`�[���
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.Caption = "�`�[���";
            //Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //�`�[�敪
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.Caption = "�`�[�敪";
            //Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //���Ӑ�R�[�h
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
            //Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki  2008/00/00 DEL
            //Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Format = codeFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Format = GetCustomerCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            //���Ӑ於
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.Caption = "���Ӑ於";
            //Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            // �S���Җ�
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.Caption = "�S���Җ�";
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���s��
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            //if (this._inpAgentDispDiv == INP_AGT_NODISP)
            //{
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Hidden = true;
            //}
            //else
            //{
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.Caption = "���s�Җ�";
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            SetInpAgentDispDivFromSalesTtlSt(this._para.SectionCode);   // ADD 2008/11/05 �s��Ή�[7070] ����S�̐ݒ�}�X�^�̔��s�ҋ敪���Q��
            if (this._inpAgentDispDiv == INP_AGT_NODISP)
            {
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = true;
            }
            else
            {
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.Caption = "���s�Җ�";
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END

            // �󒍎Җ�
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.Caption = "�󒍎Җ�";
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            //������z�i�Ŕ��j
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "���z";
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;

            //�����
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.Caption = "�����";
            //Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Format = moneyFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            //�Ǘ��ԍ�
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.Caption = "�Ǘ��ԍ�";
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //�ޕʌ^��
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Hidden = false;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Caption = "�ޕʌ`��";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Caption = "�ޕʌ^��";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //�Ԏ�
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.Caption = "�Ԏ�";
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            // �^��
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.Caption = "�^��";
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            ////�^��
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Caption = "�ޕʌ`��";
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            ////���׍s��
            //Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].Header.Caption = "���׍s��";
            ////Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //�����E�����s��
            //Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].Header.Caption = "����";
            ////Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            ////��t�S���Җ�
            //Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Hidden = false;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            //Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.Caption = "�󒍖�";
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END
            ////Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            //�ԍ�
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.Caption = "�ԍ�";
            //Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //���z�\��
            //Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].Header.Caption = "���z�\��";
            ////Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            //������z�i�ō��j
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "���z�i�ō��j";
            ////Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Format = moneyFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //�������z
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Header.Caption = "�������z";
            ////Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Format = moneyFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            //���i�敪��
            Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].Header.Caption = "���i�敪��";
            //Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END

            //���͓�
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.Caption = "���͓�";
            //Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Format = dateFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            ////�o�ד������㎞�̂ݕ\����
            //if (_para.AcptAnOdrStatus == 30)
            //{
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Header.Caption = "�ݏo��";
            //    //Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Width = 100;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //    //Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            //�v���
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.Caption = "�v���";
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA ADD END

            //�`�[���l
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.Caption = "�`�[���l";
            //Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //�`�[���l�Q
            Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].Hidden = true;  // MOD 2008/11/05 �s��Ή�[7063] �O���b�h�̕\�����ڂ��d�l���ƈقȂ� false��true
            Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].Header.Caption = "�`�[���l�Q";
            //Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            //���}�[�N1
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Hidden = false;
            // 2008.11.07 modify start [7071]
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.Caption = "���}�[�N�P";
            // 2008.11.07 modify end [7071]
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA ADD END

            //���_��
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.Caption = "���_��";
            //Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            //���喼
            // --- CHG 2009/03/31 ��QID:8859�Ή�------------------------------------------------------>>>>>
            //if (this._secMngDiv != DIV_MNG_DIVITION) // ���喼��\���ł���͕̂����Ǘ��敪�����_�ȊO�̂Ƃ��̂�
            if (this._secMngDiv != DIV_MNG_SECTION) // ���喼��\���ł���͕̂����Ǘ��敪�����_�ȊO�̂Ƃ��̂�
            // --- CHG 2009/03/31 ��QID:8859�Ή�------------------------------------------------------<<<<<
            {
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.Caption = "���喼";
                //Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Width = 100;
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            }
            else
            {
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Hidden = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            //������R�[�h
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.Caption = "������R�[�h";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Format = GetCustomerCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            //�����於
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.Caption = "�����於";
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //�ۖ�
            //Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].Header.Caption = "�ۖ�";
            ////Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            // ��\����ԃN���X���X�gXML�t�@�C�����f�V���A���C�Y
            List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(ctFILENAME_COLDISPLAYSTATUS);

            // ��\����ԃR���N�V�����N���X���C���X�^���X��
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._dataSet.SalesSlip);

            // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ---------->>>>>
            // FIXME:��ړ��Ɨ�Œ���\�Ƃ���
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this.uGrid_Result);
            // FIXME:�O���b�h��̐ݒ���捞
            SlipGridUtil.LoadColumnInfo(this.uGrid_Result, GridSettings.SlipColumnsList);
            // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ----------<<<<<
        }

        /// <summary>
        /// �u�m��v�{�^���\���ύX����
        /// </summary>
        /// <param name="enable">�\���ݒ�(true:�\���Afalse:��\��)</param>
        private void ChangeDecisionButtonEnable(bool enableSet)
        {
            if (this.StartMovment == 1) enableSet = false;
            this._selectButton.SharedProps.Enabled = enableSet;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            this._selectButton.SharedProps.Visible = enableSet;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
        }

        /// <summary>
        /// �c�[���o�[�c�[���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this._dialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    }
                case "ButtonTool_Select":
                    {
                        this._selectedData = this.GetSelectedData();

                        if (this._selectedData != null)
                        {
                            this._dialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�I������Ă���f�[�^�����݂��܂���B",
                                0,
                                MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        this.Clear();
                        this.timer_InitFocusSetting.Enabled = true;
                        break;
                    }
                case "ButtonTool_Search":   // MEMO:����
                    {
                        if (SeachBeforeCheck())
                        {
                            this.Search(this._para);
                        }
                        break;
                    }
                case "ButtonTool_Setup":
                    {
                        SalesSearchSetup salesSearchSetup = new SalesSearchSetup();
                        DialogResult dialogResult = salesSearchSetup.ShowDialog(this);

                        if (dialogResult == DialogResult.OK)
                        {
                            if (this.uGrid_Result.Rows.Count == 0)
                            {
                                this.Clear();
                            }
                        }

                        break;
                    }
            }
        }

        #region �� �����O�m�F����
        /// <summary>
        /// �����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: 96186 ���� �T��</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
        public bool SeachBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMessage,
                    0,
                    MessageBoxButtons.OK);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion


        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode, int ym)
        {
            cdrResult = _dateGet.CheckDateRange( DateGetAcs.YmdType.YearMonth, ym, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 96186 ���� �T��</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            string kbnNm = Lb_SearchSlipDate.Text;

            DateGetAcs.CheckDateRangeResult cdrResult;

            // ������t�i�J�n�`�I���j
            //if ( CallCheckDateRange( out cdrResult, ref tDateEdit_SalesDateSt, ref tDateEdit_SalesDateEd, false, 3 ) == false ) // DEL 2009/04/03
            if (CallCheckDateRange(out cdrResult, ref tDateEdit_SalesDateSt, ref tDateEdit_SalesDateEd, true, 0) == false) // ADD 2009/04/03
            {
                switch (cdrResult)
                {
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format("�J�n" + kbnNm + "{0}", ct_NoInput);
                    //        errComponent = this.tDateEdit_SalesDateSt;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n" + kbnNm + "{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesDateSt;
                            return false; // ADD 2009/04/03
                        }
                    //break; // DEL 2009/04/03
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format("�I��" + kbnNm + "{0}", ct_NoInput);
                    //        errComponent = this.tDateEdit_SalesDateEd;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I��" + kbnNm + "{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesDateEd;
                            return false; // ADD 2009/04/03
                        }
                        //break; // DEL 2009/04/03
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                    // --- ADD 2009/04/03 -------------------------------->>>>>
                        {
                            errMessage = string.Format(kbnNm + "{0}", ct_RangeError);
                            errComponent = this.tDateEdit_SalesDateSt;
                            return false; // ADD 2009/04/03
                        }
                        //break; // DEL 2009/04/03
                    // --- ADD 2009/04/03 --------------------------------<<<<<
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        // 2008.11.18 modify start [7871]
                    //        //errMessage = string.Format(kbnNm + "{0}", ct_RangeError);
                    //        errMessage = string.Format(kbnNm + "{0}", ct_RangeOverError);
                    //        // 2008.11.18 modify end [7871]
                    //        errComponent = this.tDateEdit_SalesDateSt;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                }
                //status = false;
                //return false; // DEL 2009/04/03
            }
            // ���͓��t�i�J�n�`�I���j
            // --- CHG 2009/02/19 ��QID:7882�Ή�------------------------------------------------------>>>>>
            //if ( CallCheckDateRange( out cdrResult, ref tDateEdit_SearchSlipDateSt, ref tDateEdit_SearchSlipDateEd, true, 0 ) == false )
            //{
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format( "�J�n���͓�{0}", ct_NoInput );
            //                errComponent = this.tDateEdit_SearchSlipDateSt;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format( "�J�n���͓�{0}", ct_InputError );
            //                errComponent = this.tDateEdit_SearchSlipDateSt;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format( "�I�����͓�{0}", ct_NoInput );
            //                errComponent = this.tDateEdit_SearchSlipDateEd;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format( "�I�����͓�{0}", ct_InputError );
            //                errComponent = this.tDateEdit_SearchSlipDateEd;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format( "���͓�{0}", ct_RangeError );
            //                errComponent = this.tDateEdit_SearchSlipDateSt;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format( "���͓�{0}", ct_RangeOverError );
            //                errComponent = this.tDateEdit_SearchSlipDateSt;
            //            }
            //            break;
            //    }
            //    //status = false;
            //    return false;
            //}
            DateGetAcs.CheckDateResult cdResult;

            if (tDateEdit_SearchSlipDateSt.GetLongDate() != 0)
            {
                cdResult = _dateGet.CheckDate(ref tDateEdit_SearchSlipDateSt, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("�J�n���͓�{0}", ct_InputError);
                    errComponent = this.tDateEdit_SearchSlipDateSt;
                    return (false);
                }
            }

            if (tDateEdit_SearchSlipDateEd.GetLongDate() != 0)
            {
                cdResult = _dateGet.CheckDate(ref tDateEdit_SearchSlipDateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("�I�����͓�{0}", ct_InputError);
                    errComponent = this.tDateEdit_SearchSlipDateEd;
                    return (false);
                }
            }

            if ((tDateEdit_SearchSlipDateSt.GetLongDate() != 0) && (tDateEdit_SearchSlipDateEd.GetLongDate() != 0))
            {
                if (CallCheckDateRange(out cdrResult, ref tDateEdit_SearchSlipDateSt, ref tDateEdit_SearchSlipDateEd, true, 0) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("�J�n���͓�{0}", ct_NoInput);
                                errComponent = this.tDateEdit_SearchSlipDateSt;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("�J�n���͓�{0}", ct_InputError);
                                errComponent = this.tDateEdit_SearchSlipDateSt;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("�I�����͓�{0}", ct_NoInput);
                                errComponent = this.tDateEdit_SearchSlipDateEd;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("�I�����͓�{0}", ct_InputError);
                                errComponent = this.tDateEdit_SearchSlipDateEd;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("���͓�{0}", ct_RangeError);
                                errComponent = this.tDateEdit_SearchSlipDateSt;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("���͓�{0}", ct_RangeOverError);
                                errComponent = this.tDateEdit_SearchSlipDateSt;
                            }
                            break;
                    }
                    return false;
                }
            }

            // --- CHG 2009/02/19 ��QID:7882�Ή�------------------------------------------------------<<<<<

            // �`�[�ԍ�
            long start = 0;
            long end = 0;
            if (!String.IsNullOrEmpty(this.tEdit_SalesSlipNum_St.Text.Trim()))
            {
                try
                {
                    start = long.Parse(this.tEdit_SalesSlipNum_St.Text.Trim());
                }
                catch
                {
                    errMessage = "�`�[�ԍ��͐����œ��͂��Ă��������B";
                    errComponent = this.tEdit_SalesSlipNum_St;
                    return false;
                }
            }

            if (!String.IsNullOrEmpty(this.tEdit_SalesSlipNum_Ed.Text.Trim()))
            {
                try
                {
                    end = long.Parse(this.tEdit_SalesSlipNum_Ed.Text.Trim());
                }
                catch
                {
                    errMessage = "�`�[�ԍ��͐����œ��͂��Ă��������B";
                    errComponent = this.tEdit_SalesSlipNum_Ed;
                    return false;
                }
            }

            if (start > 0 && end > 0 && start - end > 0)
            {
                errMessage = "�`�[�ԍ��i�J�n�j�͓`�[�ԍ��i�I���j��菬�����l����͂��Ă��������B";
                errComponent = this.tEdit_SalesSlipNum_St;
                return false;
            }
            return status;
        }
        #endregion



        /// <summary>
        /// �����t�H�[�J�X�ݒ�^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note      : 2011/12/14 yangmj</br>
        /// <br>�Ǘ��ԍ�         : 10707327-00 2012/01/25�z�M��</br>
        /// <br>                   redmine#27359 �`�[�����̉�ʕ\���̑Ή�</br>
        private void timer_InitFocusSetting_Tick(object sender, EventArgs e)
        {
            this.timer_InitFocusSetting.Enabled = false;
            //this.tComboEditor_SalesFormalCode.Focus();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //this.tEdit_SectionCodeAllowZero.Focus();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            //-----ADD 2011/12/14 yangmj redmine#27359 ----->>>>>
            if (_startMode == 1)
            {
                this.tNedit_CustomerCode.Focus();
            }
            //-----ADD 2011/12/14 yangmj redmine#27359 -----<<<<<
        }

        /// <summary>
        /// ����f�[�^�O���b�h�Z���A�N�e�B�u��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.ActiveCell.Row;
                this.uGrid_Result.ActiveRow.Selected = true;
            }
        }

        /// <summary>
        /// ����f�[�^�O���b�h�G���^�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.ActiveCell.Row;
                this.uGrid_Result.ActiveRow.Selected = true;
            }
            else
            {
                if (this.uGrid_Result.Rows.Count > 0)
                {
                    this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                    this.uGrid_Result.ActiveCell = this.uGrid_Result.ActiveRow.Cells[0];
                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                    this.uGrid_Result.ActiveRow.Selected = true;
                }
            }

            this.uStatusBar_Main.Text = "�}�E�X�̃h���b�O���h���b�v�ɂāA��̕\���ʒu��񕝂̕ύX���s�����Ƃ��o���܂��B";
        }

        /// <summary>
        /// ����f�[�^�O���b�h���[�u�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_Leave(object sender, EventArgs e)
        {
            this.uStatusBar_Main.Text = "";
        }

        /// <summary>
        /// �t�H�[���I���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void MAHNB04110UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ---------->>>>>
            if (_disposed) return;
            // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ----------<<<<<

            // ��\����ԃN���X���X�g�\�z����
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Result.DisplayLayout.Bands[0].Columns);
            this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

            // ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
            ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ctFILENAME_COLDISPLAYSTATUS);

            // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ---------->>>>>
            // FIXME:�O���b�h��̕\���ݒ��ۑ�
            GridSettings.SlipColumnsList = SlipGridUtil.CreateColumnInfoList(this.uGrid_Result);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
            // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ----------<<<<<

            DialogResult = this._dialogResult;
        }

        // 2008.11.11 add start [7610]
        ///// <summary>
        ///// �N���b�N
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uGrid_Result_Click(object sender, EventArgs e)
        //{
        //    Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

        //    // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
        //    Point point = System.Windows.Forms.Cursor.Position;
        //    point = targetGrid.PointToClient(point);
        //    Infragistics.Win.UIElement objElement = null;
        //    Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
        //    objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

        //    if (objElement != null)
        //    {
        //        objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
        //            (typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

        //        // �w�b�_���̏ꍇ�͈ȉ��̏������L�����Z������
        //        if (objRowCellAreaUIElement == null)
        //        {
        //            return;
        //        }
        //    }

        //    this._selectedData = this.GetSelectedData();

        //    if (StartMovment == 1)
        //    {
        //        return;
        //    }

        //    if (this._selectedData != null)
        //    {
        //        this._dialogResult = DialogResult.OK;
        //        this.Close();
        //    }
        //}
        // 2008.11.11 add end [7610]

        /// <summary>
        /// ����f�[�^�O���b�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);
            Infragistics.Win.UIElement objElement = null;
            Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
            objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

            if (objElement != null)
            {
                objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
                    (typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

                // �w�b�_���̏ꍇ�͈ȉ��̏������L�����Z������
                if (objRowCellAreaUIElement == null)
                {
                    return;
                }
            }

            this._selectedData = this.GetSelectedData();

            if (StartMovment == 1)
            {
                return;
            }

            if (this._selectedData != null)
            {
                this._dialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// ����f�[�^�O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.uGrid_Result.ActiveCell != null)
                        {
                            if (this.uGrid_Result.ActiveCell.Row.Index == 0)
                            {
                                this.tEdit_SalesInputCode.Focus();
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// �����^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_Search_Tick(object sender, EventArgs e)
        {
            timer_Search.Enabled = false;

#if False
			this.Search(this._para);
#endif
        }
        # endregion

        /// <summary>
        /// ���׃{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_StockSearch_Click(object sender, EventArgs e)  // UNDONE:���׃{�^���N���b�N
        {
            if (this.uGrid_Result.ActiveRow == null)
            {
                return;
            }

            // ���ݑI���s�̔���`�[���擾
            SalesSlipSearchResult salesSlipSearchResult = this.GetSelectedData();

            // ���׎Q�Ɖ�ʂ��N��
            MAHNB04110UC searchDetail = new MAHNB04110UC(_salesSlipSearchAcs, salesSlipSearchResult);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            searchDetail.SetDecisionButtonEnabled( this._selectButton.SharedProps.Enabled );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ---------->>>>>
            // FIXME:���ו\����ʂ̃O���b�h��������[�h���ɐݒ�
            searchDetail.Load += new EventHandler(this.LoadDetailGridSettings);
            // FIXME:���ו\����ʂ̃O���b�h������N���[�Y���Ɏ擾
            searchDetail.FormClosing += new FormClosingEventHandler(this.SetDetailGridSettings);
            // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ----------<<<<<

            DialogResult dialogResult = searchDetail.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                this._selectedData = this.GetSelectedData();
                this._dialogResult = DialogResult.OK;	//this.SetMainDialogResult(DialogResult.OK);
                this.Close();	//this.CloseMain();
            }
        }

        private void tComboEditor_SalesFormalCode_ValueChanged(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(this.tComboEditor_SalesFormalCode.Value);

            if (_para.AcptAnOdrStatus != code)
            {
                //�`�[�敪��ݒ�
                // --- CHG 2009/01/29 ��QID:7552�Ή�------------------------------------------------------>>>>>
                //this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, code);
                this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, code, (SalesSlipSearchAcs.ExtractSlipCdType)this._extractSlipCdType);
                // --- CHG 2009/01/29 ��QID:7552�Ή�------------------------------------------------------<<<<<

                Lb_SearchSlipDate_SetName((int)tComboEditor_SalesFormalCode.Value);
            }
        }

        /// <summary>
        /// ���t�����̃��x�����̂�ݒ�
        /// </summary>
        /// <param name="cd"></param>
        private void Lb_SearchSlipDate_SetName(int cd)
        {
            switch (cd)
            {
                //10,15:����,20:��,30:����,40:�o��
                case 10:
                case 15:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                case 16:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
                    //���t
                    Lb_SearchSlipDate.Text = "���ϓ�";
                    //tEdit_PartySaleSlipNum.Enabled = false;
                    tNedit_ClaimCode.Enabled = false;
                    uButton_ClaimGuide.Enabled = false;

                    //tEdit_PartySaleSlipNum.Clear();
                    tNedit_ClaimCode.Clear();
                    uLabel_ClaimName.Text = "";

                    break;
                case 20:
                    //���t
                    Lb_SearchSlipDate.Text = "�󒍓�";
                    //tEdit_PartySaleSlipNum.Enabled = true;
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                //case 30:
                //    //���t
                //    Lb_SearchSlipDate.Text = "�����";
                //    //tEdit_PartySaleSlipNum.Enabled = true;
                //    tNedit_ClaimCode.Enabled = true;
                //    uButton_ClaimGuide.Enabled = true;
                //    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                case 40:
                    //���t
                    Lb_SearchSlipDate.Text = "�ݏo��";
                    //tEdit_PartySaleSlipNum.Enabled = true;
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                case 30:
                default:
                    //���t
                    Lb_SearchSlipDate.Text = "�����";
                    //tEdit_PartySaleSlipNum.Enabled = true;
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            if ( tNedit_ClaimCode.Enabled == false )
            {
                _para.ClaimCode = 0;
                _para.ClaimName = string.Empty;
                tNedit_ClaimCode.SetInt( 0 );
                uLabel_ClaimName.Text = string.Empty;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA ADD START

        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ���i �r��</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            int status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, true, out sectionInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                //this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.TrimEnd();
                //this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();

                // ���ʕϐ��ɕۑ�
                this._dspSectionCode = sectionInfo.SectionCode.TrimEnd();

                // �p�����[�^�ɕۑ�
                this._para.SectionCode = sectionInfo.SectionCode.TrimEnd();
                this._para.SectionName = sectionInfo.SectionGuideNm.TrimEnd();

                // ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
                this.SetDisplayConditionInfo(this._para);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // ���t�H�[�J�X
                if ( tNedit_SubSectionCode.Enabled )
                {
                    this.tNedit_SubSectionCode.Focus();
                }
                else
                {
                    this.tNedit_CustomerCode.Focus();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
        ///// <summary>
        ///// ���_�R�[�h���͗�Leave����
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <remarks>
        ///// <br>Note		: ���_�R�[�h���͗���Leave�������ɔ������܂��B</br>
        ///// <br>Programmer	: ���i �r��</br>
        ///// <br>Date		: 2008.07.15</br>
        ///// </remarks>
        //private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        //{
        //    string sectionCode = this.tEdit_SectionCodeAllowZero.Text;

        //    if (!String.IsNullOrEmpty(sectionCode))
        //    {
        //        SecInfoSet sectionInfo;
        //        int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            //this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();

        //            // ���ʕϐ��ɕۑ�
        //            this._dspSectionCode = sectionInfo.SectionCode.TrimEnd();

        //            // �p�����[�^�ɕۑ�
        //            this._para.SectionCode = sectionInfo.SectionCode.TrimEnd();
        //            this._para.SectionName = sectionInfo.SectionGuideNm.TrimEnd();
        //        }
        //    }
        //    else
        //    {
        //        this._para.SectionCode = "000000";
        //        this._para.SectionName = string.Empty;
        //    }
        //    // ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
        //    this.SetDisplayConditionInfo(this._para);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
        ///// <summary>
        ///// ����R�[�h���͗�Leave����
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <remarks>
        ///// <br>Note		: ����R�[�h���͗���Leave�������ɔ������܂��B���_�R�[�h�����́E�I������Ă���K�v������܂��B</br>
        ///// <br>Programmer	: ���i �r��</br>
        ///// <br>Date		: 2008.07.15</br>
        ///// </remarks>
        //private void tNedit_SubSectionCode_Leave(object sender, EventArgs e)
        //{
        //    // ���_�R�[�h���I������Ă���K�v������
        //    if (this._dspSectionCode == null) return;

        //    string subSectionCode = this.tNedit_SubSectionCode.Text;

        //    if (!String.IsNullOrEmpty(subSectionCode))
        //    {
        //        SubSection subSection;
        //        int status = this._subSectionAcs.Read(out subSection, this._enterpriseCode, this._dspSectionCode, int.Parse(subSectionCode));
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            //this.tNedit_SubSectionCode.Text = subSection.SubSectionName.TrimEnd();

        //            // ���ʕϐ��ɕۑ�
        //            this._dspSubSectionCode = subSection.SubSectionCode;

        //            // �p�����[�^�ɕۑ�
        //            this._para.SubSectionCode = subSection.SubSectionCode;
        //            this._para.SubSectionName = subSection.SubSectionName;
        //        }
        //    }
        //    else
        //    {
        //        this._dspSubSectionCode = 0;

        //        // �p�����[�^����폜
        //        this._para.SubSectionCode = 0;
        //        this._para.SubSectionName = string.Empty;
        //    }

        //    // ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
        //    this.SetDisplayConditionInfo(this._para);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

        /// <summary>
        /// ����K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ���i �r��</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void ultraButton_SubSectionGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //// ���_�R�[�h���I������Ă���K�v������
            //if (this._dspSectionCode == null) return;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

            SubSection subSection;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode, this._dspSectionCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            int status = this._subSectionAcs.ExecuteGuid( out subSection, this._enterpriseCode, sectionCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //this.tNedit_SubSectionCode.Text = subSection.SubSectionCode.ToString();
                //this.uLabel_SubSectionName.Text = subSection.SubSectionName.TrimEnd();

                // ���ʕϐ��ɕۑ�
                this._dspSubSectionCode = subSection.SubSectionCode;

                // �p�����[�^�ɕۑ�
                this._para.SubSectionCode = subSection.SubSectionCode;
                this._para.SubSectionName = subSection.SubSectionName;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
                this.SetDisplayConditionInfo( this._para );
                // ���t�H�[�J�X
                tNedit_CustomerCode.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //// ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
            //this.SetDisplayConditionInfo(this._para);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
        }

        /// <summary>
        /// ���Ӑ���̓t�B�[���hLeave����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���Ӑ���̓t�B�[���h����ړ����鎞�ɔ������܂��B</br>
        /// <br>Programmer	: ���i �r��</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            int customerCode;

            customerCode = this.tNedit_CustomerCode.GetInt();
            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();

                    // ���ʕϐ��ɕۑ�
                    this._customerCode = customerInfo.CustomerCode;

                    // ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
                    this.SetDisplayConditionInfo(this._para);
                }
            }
            else
            {
                // ���̂��N���A
                this.uLabel_CustomerName.Text = string.Empty;

                // ���ʕϐ��A�p�����[�^���폜
                this._customerCode = 0;
                this._para.CustomerCode = 0;
                this._para.CustomerName = string.Empty;
            }
        }

        /// <summary>
        /// ������K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ���i �r��</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void tNedit_ClaimCode_Leave(object sender, EventArgs e)
        {
            int claimCode;

            claimCode = this.tNedit_ClaimCode.GetInt();
            if (claimCode > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, claimCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uLabel_ClaimName.Text = customerInfo.ClaimName.TrimEnd();

                    // ���ʕϐ��ɕۑ�
                    this._claimCode = customerInfo.ClaimCode;

                    // ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
                    this.SetDisplayConditionInfo(this._para);
                }
            }
        }

        /// <summary>
        /// ���͎҃K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ���i �r��</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void uButton_FrontEmployeeCd_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (this._para.SalesInputCode.Trim() != employee.EmployeeCode.Trim()))
            {
                this._para.FrontEmployeeCd = employee.EmployeeCode.Trim();
                this._para.FrontEmployeeName = employee.Name;

                // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
                this.SetDisplayConditionInfo(this._para);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
                // ���t�H�[�J�X
                this.uGrid_Result.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            }
        }

        private void tEdit_FullModel_ValueChanged(object sender, EventArgs e)
        {
            string fullModelValue = this.tEdit_FullModel.Text;

            if (fullModelValue.Trim().Length > 0)
            {
                this._para.FullModel = fullModelValue.Trim();
            }
            else
            {
                this._para.FullModel = string.Empty;
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA ADD END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
        /// <summary>
        /// �t�h�ݒ�w�l�k����̃R�[�h�t�H�[�}�b�g�擾(00,000,0000�c etc.)
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        private string GetCodeFormat( string editName )
        {
            UiSet uiset;
            int status = uiSetControl1.ReadUISet( out uiset, editName );
            if ( status == 0 )
            {
                return string.Format( "{0};-{0};''", new string( '0', uiset.Column ) );
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// ���Ӑ�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetCustomerCodeFormat()
        {
            return GetCodeFormat( "tNedit_CustomerCode" );
        }
        /// <summary>
        /// �a�k�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetBLGoodsCodeFormat()
        {
            return GetCodeFormat( "tNedit_BLGoodsCode" );
        }

        /// <summary>
        /// �t�H�[���\���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB04110UA_Shown( object sender, EventArgs e )
        {
            if ( _autoSearch )
            {
                // ��������
                SearchDataForInitialSearch();
                this.uGrid_Result.Focus();
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Focus();
            }
        }
        /// <summary>
        /// �N�����������s�p������������
        /// </summary>
        private void SearchDataForInitialSearch()
        {
            isFirstOfAutoSearch = true;

            // 
            Clear();

            // �p�����[�^����
            CreateSearchParameterForInitialSearch( ref _para );

            // ���o�����̊e��R���g���[���ɒl��ݒ肷��B
            this.SetDisplayConditionInfo( _para );

            // �������s
            Search( _para );
        }

        /// <summary>
        /// �p�����[�^����
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        private void CreateSearchParameterForInitialSearch( ref SalesSlipSearch para )
        {
            if ( para == null )
            {
                para = new SalesSlipSearch();
            }

            para.SectionCode = this.SectionCode.Trim();
            para.SectionName = this.SectionName.Trim();
            para.CustomerCode = this.CustomerCode;
            para.CustomerName = this.CustomerName.Trim();
            para.ClaimCode = this.ClaimCode;
            para.ClaimName = this.ClaimName.Trim();
            para.SalesDateSt = this.SalesDate;
            para.SalesDateEd = this.SalesDate;
            para.AcptAnOdrStatus = this.AcptAnOdrStatus;
            para.SalesSlipCd = this.SalesSlipCd;
            para.SalesEmployeeCd = this.SalesEmployeeCd;
            para.SalesInputCode = this.SalesInputCode;
            para.FrontEmployeeCd = this.FrontEmployeeCd;
            para.SalesEmployeeName = this.SalesEmployeeName;
            para.SalesInputName = this.SalesInputName;
            para.FrontEmployeeName = this.FrontEmployeeName;

            // �O������̃Z�b�g���e�̕␳
            if ( this.SectionCode.Trim() == string.Empty )
            {
                UiSet uiset;
                uiSetControl1.ReadUISet( out uiset, tEdit_SectionCodeAllowZero.Name );
                para.SectionCode = new string( '0', uiset.Column );
                para.SectionName = ct_AllSection;
            }
            if ( this.AcptAnOdrStatus == 0 )
            {
                para.AcptAnOdrStatus = -1; // -1:�S��
            }
            if ( this.SalesDate == DateTime.MinValue )
            {
                if ( this.SectionCode.Trim() == string.Empty )
                {
                    para.SalesDateSt = GetPrevTotalDayNextDay( LoginInfoAcquisition.Employee.BelongSectionCode );
                    para.SalesDateEd = DateTime.Today;
                }
                else
                {
                    para.SalesDateSt = GetPrevTotalDayNextDay( this.SectionCode.Trim() );
                    para.SalesDateEd = DateTime.Today;
                }
            }
            if (this.AcptAnOdrStatus == 16)
            {
                para.SalesSlipCd = -1;
            }
        }

        private void tEdit_SectionCodeAllowZero_Enter( object sender, EventArgs e )
        {
            // �[���T�v���X
            tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText( "tEdit_SectionCode", tEdit_SectionCodeAllowZero.Text );
        }


        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

        // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ---------->>>>>
        #region �O���b�h�̐ݒ���

        /// <summary>FIXME:�O���b�h���XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "DCHNB04120U_Construction.XML";

        /// <summary>�O���b�h�̐ݒ���</summary>
        private GridSettingsType _gridSettings;
        /// <summary>�O���b�h�̐ݒ�����擾���܂��B</summary>
        public GridSettingsType GridSettings
        {
            get
            {
                if (_gridSettings == null)
                {
                    _gridSettings = SlipGridUtil.ReadGridSettings(XML_FILE_NAME);
                }
                return _gridSettings;
            }
        }

        /// <summary>
        /// ���׏��O���b�h�ɃO���b�h�ݒ����W�J���܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void LoadDetailGridSettings(
            object sender,
            EventArgs e
        )
        {
            MAHNB04110UC detailForm = sender as MAHNB04110UC;
            if (detailForm == null) return;

            // ��ړ��Ɨ�Œ���\�Ƃ���
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(detailForm.DetailGrid);
            // �O���b�h��̐ݒ���捞
            SlipGridUtil.LoadColumnInfo(detailForm.DetailGrid, GridSettings.DetailColumnsList);
            // ---------------------- ADD START 2011/07/18 ���R ----------------->>>>>
            // PCC�I�v�V�������Đݒ�
            if (detailForm.Opt_Pcc == 1)
            {
                detailForm.DetailGrid.DisplayLayout.Bands[0].Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].Hidden = false;
            }
            else
            {
                detailForm.DetailGrid.DisplayLayout.Bands[0].Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].Hidden = true;
            }
            // ---------------------- ADD END   2011/07/18 ���R -----------------<<<<<
        }

        /// <summary>
        /// ���׏��O���b�h�̃O���b�h�ݒ����ݒ肵�܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void SetDetailGridSettings(
            object sender,
            FormClosingEventArgs e
        )
        {
            MAHNB04110UC detailForm = sender as MAHNB04110UC;
            if (detailForm == null) return;

            // ���׏���ʂ̃O���b�h����𐶐�
            GridSettings.DetailColumnsList = SlipGridUtil.CreateColumnInfoList(detailForm.DetailGrid);
        }

        #endregion // �O���b�h�̐ݒ���

        //---ADD 2011/11/11 ----------------------------------->>>>>
        /// <summary>
        /// �A�g�`�[�o�͋敪�R���{�G�f�B�^ ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void tComboEditor_AutoAnswerDivSCM_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_AutoAnswerDivSCM.SelectedIndex != 0)
            {
                this.uCheckEditor_PccForNS.Enabled = true;
                this.uCheckEditor_BlPaCOrder.Enabled = true;
            }
            else
            {
                this.uCheckEditor_PccForNS.Enabled = false;
                this.uCheckEditor_BlPaCOrder.Enabled = false;
                this.uCheckEditor_PccForNS.Checked = false;
                this.uCheckEditor_BlPaCOrder.Checked = false;
            }
        }
        //---ADD 2011/11/11 -----------------------------------<<<<<

        // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ----------<<<<<
    }
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
    # region [�ϑ��t�H�[�J�X����]
    /// <summary>
    /// �ϑ��t�H�[�J�X����N���X
    /// </summary>
    internal class IrregularFocusControl
    {
        /// <summary>
        /// �ϑ��t�H�[�J�X����f�B�N�V���i���@ 
        /// </summary>
        private Dictionary<IrregularFocusControlKey, Control> _irregularFocusControlDic;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public IrregularFocusControl()
        {
            _irregularFocusControlDic = new Dictionary<IrregularFocusControlKey, Control>();
        }

        # region [public ���\�b�h]
        /// <summary>
        /// �ϑ��t�H�[�J�X����f�B�N�V���i���ǉ�
        /// </summary>
        /// <param name="prevCtrl"></param>
        /// <param name="shiftKey"></param>
        /// <param name="key"></param>
        /// <param name="priority"></param>
        /// <param name="nextControl"></param>
        public void AddFocusDictionary( Control prevCtrl, bool shiftKey, Keys key, int priority, Control nextControl )
        {
            _irregularFocusControlDic.Add( new IrregularFocusControlKey( prevCtrl.Name, shiftKey, key, priority ), nextControl );
        }
        /// <summary>
        /// �ϑ��t�H�[�J�X����f�B�N�V���i���N���A
        /// </summary>
        public void ClearFocusDictionary()
        {
            _irregularFocusControlDic.Clear();
        }
        /// <summary>
        /// �ϑ��I���t�H�[�J�X���ڎ擾����
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool ReflectIrregularNextControl( Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            if ( e == null || e.PrevCtrl == null ) return false;
            if ( e.NextCtrl == e.PrevCtrl ) return false;

            bool result = false;

            Control wkControl = GetIrregularNextControl( e.PrevCtrl.Name, e.Key, e.ShiftKey );
            if ( wkControl != null )
            {
                e.NextCtrl = wkControl;
                result = true;
            }

            return result;
        }
        # endregion

        # region [private ���\�b�h]
        /// <summary>
        /// �ϑ��I���t�H�[�J�X���ڎ擾����
        /// </summary>
        /// <param name="prevCtrlName"></param>
        /// <param name="key"></param>
        /// <param name="shiftKey"></param>
        /// <returns></returns>
        private Control GetIrregularNextControl( string prevCtrlName, Keys key, bool shiftKey )
        {
            Control irregularNextCtrl = null;

            if ( _irregularFocusControlDic == null )
            {
                return null;
            }

            int priority = 0;
            IrregularFocusControlKey dicKey = new IrregularFocusControlKey( prevCtrlName, shiftKey, key, priority );
            while ( _irregularFocusControlDic.ContainsKey( dicKey ) )
            {
                Control wkNextCtrl = _irregularFocusControlDic[dicKey];
                if ( wkNextCtrl.Enabled == true && wkNextCtrl.Visible == true )
                {
                    // Enabled=true�Ȃ�Ίm��
                    irregularNextCtrl = wkNextCtrl;
                    break;
                }
                else
                {
                    // Enabled=false�Ȃ�Ύ��̌���
                    priority++;
                    dicKey = new IrregularFocusControlKey( prevCtrlName, shiftKey, key, priority );
                }
            }

            return irregularNextCtrl;
        }
        # endregion

        # region [�t�H�[�J�X����L�[]
        /// <summary>
        /// �t�H�[�J�X����L�[
        /// </summary>
        private struct IrregularFocusControlKey
        {
            /// <summary>�O�R���g���[����</summary>
            private string _prevCtrlName;
            /// <summary>�����L�[�V�t�g</summary>
            private bool _shiftKey;
            /// <summary>�����L�[</summary>
            private Keys _key;
            /// <summary>�D�揇</summary>
            private int _priority;
            /// <summary>
            /// �O�R���g���[����
            /// </summary>
            public string PrevCtrlName
            {
                get { return _prevCtrlName; }
                set { _prevCtrlName = value; }
            }
            /// <summary>
            /// �����L�[�V�t�g
            /// </summary>
            /// <remarks>True:Shift����</remarks>
            public bool ShiftKey
            {
                get { return _shiftKey; }
                set { _shiftKey = value; }
            }
            /// <summary>
            /// �����L�[
            /// </summary>
            public Keys Key
            {
                get { return _key; }
                set { _key = value; }
            }
            /// <summary>
            /// �D�揇
            /// </summary>
            /// <remarks>�ʏ��0���w��B�t�H�[�J�X�ړ��悪Enabled=false�Ȃ�1,2,3�c�Ə��ԂɎQ�Ƃ���B</remarks>
            public int Priority
            {
                get { return _priority; }
                set { _priority = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="prevCtrlName">�O�R���g���[����</param>
            /// <param name="shiftKey">�����L�[�V�t�g</param>
            /// <param name="key">�����L�[</param>
            /// <param name="priority">�D�揇</param>
            public IrregularFocusControlKey( string prevCtrlName, bool shiftKey, Keys key, int priority )
            {
                _prevCtrlName = prevCtrlName;
                _shiftKey = shiftKey;
                _key = key;
                _priority = priority;
            }
        }
        # endregion
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD

    // 2008.11.11 add start [7552]
    public enum ExtractSlipCdType : int
    {
        /// <summary>�S��</summary>
        All = 0,
        /// <summary>����</summary>
        Sales = 1,
        /// <summary>�ԕi</summary>
        Return = 2,
    }
    // 2008.11.11 add end [7552]

    // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ---------->>>>>
    #region �`�[�O���b�h

    /// <summary>
    /// �`�[�O���b�h���[�e�B���e�B
    /// </summary>
    /// <remarks>
    /// �ȉ��̋@�\�ŎQ�Ƃ��Ă��܂��B<br/>
    /// �E���㗚���Ɖ�<br/>
    /// �E�d���`�[�Ɖ�<br/>
    /// �E�d�������Ɖ�
    /// </remarks>
    public static class SlipGridUtil
    {
        #region ���ݒ�

        /// <summary>
        /// ������Ɨ�Œ���\�Ƃ��܂��B
        /// </summary>
        /// <param name="grid">�ΏۃO���b�h</param>
        public static void EnableAllowColSwappingAndFixedHeaderIndicator(UltraGrid grid)
        {
            #region Guard Phrase

            if (grid == null) return;

            #endregion // Guard Phrase

            // ��������\�ɂ���
            grid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.WithinGroup;
            // ��Œ���\�ɂ���
            grid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.Button;
        }

        #endregion // ���ݒ�

        #region �ݒ�̓W�J

        /// <summary>
        /// �O���b�h�̕\���ݒ��ǂݍ��݂܂��B
        /// </summary>
        /// <remarks>
        /// �y�Q�l�z���Ӑ�d�q�����FPMKAU04004UA.Deserialize()
        /// </remarks>
        /// <param name="xmlFileName">�ݒ�XML�t�@�C����</param>
        public static GridSettingsType ReadGridSettings(string xmlFileName)
        {
            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName);
            if (!UserSettingController.ExistUserSetting(filePath)) return new GridSettingsType();

            GridSettingsType gridSettings = null;
            try
            {
                gridSettings = UserSettingController.DeserializeUserSetting<GridSettingsType>(filePath);
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
                return new GridSettingsType();
            }
            return gridSettings;
        }

        /// <summary>
        /// �������荞�݂܂��B
        /// </summary>
        /// <remarks>
        /// �y�Q�l�z���Ӑ�d�q�����FPMKAU04001UA.LoadGridColumnsSetting()
        /// </remarks>
        /// <param name="grid">�ΏۃO���b�h</param>
        /// <param name="columnInfoList">����</param>
        public static void LoadColumnInfo(
            UltraGrid grid,
            List<ColumnInfo> columnInfoList
        )
        {
            #region Guard Phrase

            if (columnInfoList == null || columnInfoList.Count.Equals(0)) return;

            #endregion // Guard Phrase

            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in columnInfoList)
            {
                try
                {
                    UltraGridColumn ultraGridColumn = grid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    {
                        ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                        ultraGridColumn.Hidden = columnInfo.Hidden;
                        ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                        ultraGridColumn.Width = columnInfo.Width;
                    }
                }
                catch (Exception ex)
                {
                    Debug.Assert(false, ex.ToString());
                }
            }
        }

        #endregion // �ݒ�̓W�J

        #region �ݒ�̕ۑ�

        /// <summary>
        /// �O���b�h�̕\���ݒ��ۑ����܂��B
        /// </summary>
        /// <remarks>
        /// �y�Q�l�z���Ӑ�d�q�����FPMKAU04004UA.Serialize()
        /// </remarks>
        /// <param name="gridSettings">�O���b�h�̐ݒ���</param>
        /// <param name="xmlFileName">�ݒ�XML�t�@�C����</param>
        public static void StoreGridSettings(
            GridSettingsType gridSettings,
            string xmlFileName
        )
        {
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName);

                UserSettingController.SerializeUserSetting(gridSettings, fileName);

                #region �����R�[�h
                //CustPtrSalesUserConst test = new CustPtrSalesUserConst();
                //test.OutputPattern = new string[0];
                //test.SlipColumnsList = new List<ColumnInfo>();
                //test.DetailColumnsList = columnInfoList; 
                //test.RedSlipColumnsList = new List<ColumnInfo>();
                //test.EnabledConditionList = new List<string>();
                //UserSettingController.SerializeUserSetting(test, fileName);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// ���񃊃X�g�𐶐����܂��B
        /// </summary>
        /// <remarks>
        /// �y�Q�l�z���Ӑ�d�q�����FPMKAU04001UA.SaveGridColumnsSetting()
        /// </remarks>
        /// <param name="grid">�ΏۃO���b�h</param>
        /// <returns>�ΏۃO���b�h������𒊏o���A���X�g�ŕԂ��܂��B</returns>
        public static List<ColumnInfo> CreateColumnInfoList(UltraGrid grid)
        {
            #region Guard Phrase

            if (grid == null) return new List<ColumnInfo>();

            #endregion // Guard Phrase

            List<ColumnInfo> columnInfoList = new List<ColumnInfo>();
            {
                foreach (UltraGridColumn ultraGridColumn in grid.DisplayLayout.Bands[0].Columns)
                {
                    columnInfoList.Add(new ColumnInfo(
                        ultraGridColumn.Key,
                        ultraGridColumn.Header.VisiblePosition,
                        ultraGridColumn.Hidden,
                        ultraGridColumn.Width,
                        ultraGridColumn.Header.Fixed
                    ));
                }
            }
            return columnInfoList;
        }

        #endregion // �ݒ�̕ۑ�
    }

    #region �`�[�O���b�h�ݒ���

    /// <summary>
    /// �`�[�O���b�h�ݒ���N���X
    /// </summary>
    [Serializable]
    public class SlipGridSettings : CustPtrSalesUserConst
    {
        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SlipGridSettings() : base()
        {
            base.OutputPattern          = new string[0];
            base.SlipColumnsList        = new List<ColumnInfo>();
            base.DetailColumnsList      = new List<ColumnInfo>();
            base.RedSlipColumnsList     = new List<ColumnInfo>();
            base.EnabledConditionList   = new List<string>();
        }

        #endregion // Constructor
    }

    #endregion // �`�[�O���b�h�ݒ���

    #endregion // �`�[�O���b�h
    // ADD 2009/12/03 MANTIS�Ή�[14742]�F�`�[����і��׃O���b�h��̗�ݒ�̕ύX ----------<<<<<
}
