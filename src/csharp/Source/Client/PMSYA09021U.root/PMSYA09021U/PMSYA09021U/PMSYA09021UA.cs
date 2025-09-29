//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�Ǘ��}�X�^(�ꊇ����)
// �v���O�����T�v   : ���q�Ǘ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2009/10/10  �C�����e : ��Q��Redmine#537,703�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570163-00 �쐬�S�� : 杍^
// �C �� ��  2019/08/19  �C�����e : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770175-00 �쐬�S�� : ���X�ؘj
// �C �� ��  2021/11/02  �C�����e : OUT OF MEMORY�Ή�(4GB�Ή�) ���q�Ǘ��}�X�^�ێ�
//                                  ���o�Ώی������ő匏��20001���܂Łi20000���܂ŉ�ʕ\���j
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;// ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���q�Ǘ��}�X�^�ꊇ�o�^�C���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���q�Ǘ��}�X�^�ꊇ�o�^�C���֘A�̈ꗗ�\�����s���t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : �����</br>
    /// <br>Date        : 2009.09.07</br>
    /// <br>Update Note : ���� 2009.10.10</br>
    /// <br>            : ��Q��Redmine#537�̏C��</br>
    /// <br>Update Note : 杍^ 2019/08/19</br>
    /// <br>            : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
    /// <br>Update Note : 2021/11/02 ���X�ؘj</br>
    /// <br>�Ǘ��ԍ�    : 11770175-00</br>
    /// <br>              OUT OF MEMORY�Ή�(4GB�Ή�) ���q�Ǘ��}�X�^�ێ�</br>
    /// <br>              ���o�Ώی������ő匏��20001���܂Łi20000���܂ŉ�ʕ\���j</br>
    /// </remarks>
    public partial class PMSYA09021UA : Form
    {
        #region �� �R���X�g���N�^ ��
        /// <summary>
        /// ���q�Ǘ��}�X�^�ꊇ�o�^�C��UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���q�Ǘ��}�X�^�ꊇ�o�^�C��UI�t�H�[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// <br>Note        : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2019/08/19</br>
        /// </remarks>
        public PMSYA09021UA()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            // ���O�C�����擾
            this.GetLoginInfo();

            // �O���b�h
            this._detailGrid = new PMSYA09021UB();
            this._gridStateController = new GridStateController();

            this._secInfoAcs = new SecInfoAcs();
            this._carMngListInputAcs = CarMngListInputAcs.GetInstance();
            this._carMngInputAcs = CarMngInputAcs.GetInstance();

            // �t�H�[�J�X�ݒ�C�x���g
            this._detailGrid.SetFocus += new PMSYA09021UB.SettingFocusEventHandler(this.DetailGrid_SetFocus);

            // �ҏW�{�^�������ېݒ�C�x���g
            this._detailGrid.SetEditButton += new PMSYA09021UB.SetEditButtonEnableHandler(this.SetEditButtonEnable);

            // �f�[�^���͉�ʂ��N���C�x���g
            this._detailGrid.StartInPut += new PMSYA09021UB.StartInPutHandler(this.StartInPut);

            this.TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs(); // ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�
        }
        #endregion

        #region �� private�萔 ��
        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        private const string TOOLBAR_NEWBUTTON_KEY = "ButtonTool_New";
        private const string TOOLBAR_EDITBUTTON_KEY = "ButtonTool_Edit";
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";
        private const string TOOLBAR_TEXTOUTPUTBUTTON_KEY = "ButtonTool_TextOutPut";
        private const string TOOLBAR_NEWINFOBUTTON_KEY = "ButtonTool_NewInfo";

        private const string TOOLBAR_SECTIONLABEL_TITLE = "LableTool_SectionTitle";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        private const string TOOLBAR_SECTIONNAMELABLE_KEY = "LableTool_SectionName";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_ROWDELETE_KEY = "ButtonTool_delRow";

        // --- UPD 2009/10/10 ----->>>>>
        //private const string SEARCH_DIV1 = "���S";
        //private const string SEARCH_DIV2 = "�O��";
        //private const string SEARCH_DIV3 = "�B��";
        private const string SEARCH_DIV1 = "�ƈ�v";
        private const string SEARCH_DIV2 = "�Ŏn��";
        private const string SEARCH_DIV3 = "���܂�";
        private const string SEARCH_DIV4 = "�ŏI��";
        // --- UPD 2009/10/10 -----<<<<<

        private const string INIT_MODE = "init";
        private const string SEARCH_MODE = "search";

        // �N���X��
        private string ct_PRINTNAME = "���q�Ǘ��}�X�^";
        // �v���O����ID
        private const string ct_PGID = "PMSYA09020U";

        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMSYA09020U.dat";

        //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        // �ŏ�����
        private const string StartStr = "�ŏ�����";
        // �Ō�܂�
        private const string EndStr = "�Ō�܂�";
        // ���\�b�h��
        private const string MethodNm = "TextOutput";
        // �ǉ�����
        private const string AddWrite = "�ǉ�����";
        // �㏑������
        private const string OverWrite = "�㏑������";
        // ��ʏ���
        private const string MenuCon = "���Ӑ�:{0} �` {1},�Ǘ��ԍ�:{2}{3},�o�̓p�^�[��:{4},�o�͐�:{5}";
        // �v���O����ID
        private const string PgId = "PMSYA09021U";
        // �o�͌���
        private const string CountNumStr = "�f�[�^�o�͌���:{0},";
        //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<

        // --- ADD ���X�ؘj 2021/11/02 ------>>>>> 
        // �ő咊�o����
        private const int MAX_MST_RECORD_COUNT = 20000;
        // �ő匏���𒴂������̃��b�Z�[�W
        private const string INFO_MAX_RECORD = "�f�[�^������{0:#,##0}���𒴂��܂����B";
        // --- ADD ���X�ؘj 2021/11/02 ------<<<<<

        #endregion

        #region �� private�ϐ� ��
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;

        // ��ƃR�[�h
        private string _enterpriseCode;
        // �����_�R�[�h
        private string _sectionCode;
        // ���׃O���b�h�R���g���[���N���X
        private PMSYA09021UB _detailGrid;

        // �O���b�h�ݒ萧��N���X
        private GridStateController _gridStateController;
        // ----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ------>>>>>
        // ���O�o�͋��ʕ��i
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        // �o�^�E�X�V�p���엚�����[�N
        private TextOutPutOprtnHisLogWork TextOutPutOprtnHisLogWorkObj = null;
        // ----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ------<<<<<

        private ImageList _imageList16 = null;											// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;				// �����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;				// �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _newButton;				// �V�K�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _editButton;				// �ҏW�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _textOutPutButton;			// ÷�ďo�̓{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _newInfotButton;			// �ŐV���{�^��

        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionTitleLabel;	        // ���O�C�����_����
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionNameLabel;			// ���O�C�����_����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		    // ���O�C���S���Җ���

        private SecInfoAcs _secInfoAcs = null;              // ���_���A�N�Z�X�N���X
        private CarMngListInputAcs _carMngListInputAcs;
        private CarMngInputAcs _carMngInputAcs;

        private CustomerSearchRet _customerSearchRet;
        private bool _cusotmerGuideSelected;

        // �������̒��o����
        CarManagementExtractInfo _oldExtractInfo;
        #endregion

        #region �� private���\�b�h
        #region �� �����\���֘A
        /// <summary>
        /// ���O�C�����擾
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���O�C�����擾</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void GetLoginInfo()
        {
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �����_�R�[�h
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }

        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // �c�[���o�[�����ݒ菈��
            this.ToolBarInitilSetting();

            //// �{�^���A�C�R���ݒ�
            this.SetGuidButtonIcon();

            //// �c�[���{�^��Enable�ݒ菈��
            this.SetControlEnabled(INIT_MODE);

            //// ������ʃf�[�^�ݒ�
            this.InitialScreenData();
        }

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������A�c�[���o�[�����ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            // �I���̃A�C�R���ݒ�
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            if (this._closeButton != null)
            {
                this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.CLOSE];
            }

            // �����̃A�C�R���ݒ�
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY];
            if (this._searchButton != null)
            {
                this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SEARCH];
            }

            // �N���A�̃A�C�R���ݒ�
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];
            if (this._clearButton != null)
            {
                this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.ALLCANCEL];
            }

            // �V�K�̃A�C�R���ݒ�
            this._newButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_NEWBUTTON_KEY];
            if (this._newButton != null)
            {
                this._newButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.NEW];
            }

            // �ҏW�̃A�C�R���ݒ�
            this._editButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_EDITBUTTON_KEY];
            if (this._editButton != null)
            {
                this._editButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.MODIFY];
            }

            // �ۑ��̃A�C�R���ݒ�
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY];
            if (this._saveButton != null)
            {
                this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SAVE];
            }

            // ÷�ďo�͂̃A�C�R���ݒ�
            this._textOutPutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
            if (this._textOutPutButton != null)
            {
                this._textOutPutButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.CSVOUTPUT];
            }

            // �ŐV���̃A�C�R���ݒ�
            this._newInfotButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_NEWINFOBUTTON_KEY];
            if (this._newInfotButton != null)
            {
                this._newInfotButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.RENEWAL];
            }

            // ���O�C�����_�̃A�C�R���ݒ�
            this._sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_SECTIONLABEL_TITLE];
            if (this._sectionTitleLabel != null)
            {
                this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.BASE]; ;
            }

            // ���O�C���S���҂̃A�C�R���ݒ�
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }

            // ���O�C�����_��
            this._sectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_SECTIONNAMELABLE_KEY];
            if (this._sectionNameLabel != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._sectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    this._sectionNameLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
                }
            }

            // ���O�C���S���Җ�
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            if (this._loginNameLabel != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                this._loginNameLabel.SharedProps.Caption = employee.Name;
            }
        }

        /// <summary>
        /// �K�C�h�{�^���̃A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �K�C�h�{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            // -----------------------------
            // �{�^���A�C�R���ݒ�
            // -----------------------------
            this.CustomerGuideSt_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuideEd_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.CarMngCode_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// �R���g���[��Enabled���䏈��
        /// </summary>
        /// <param name="editMode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note        : �R���g���[����Enabled������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            switch (editMode)
            {
                // �����\��
                case INIT_MODE:
                    this._textOutPutButton.SharedProps.Enabled = false;
                    this._editButton.SharedProps.Enabled = false;

                    break;
                // ����
                case SEARCH_MODE:
                    CarMngInputDataSet.CarInfoRow[] logicRows = (CarMngInputDataSet.CarInfoRow[])this._carMngListInputAcs.CarInfoDataTable.Select(
                        this._carMngListInputAcs.CarInfoDataTable.DeleteDateColumn.ColumnName + " is null " );

                    if (logicRows.Length > 0)
                    {
                        this._textOutPutButton.SharedProps.Enabled = true;
                    }
                    else
                    {
                        this._textOutPutButton.SharedProps.Enabled = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// ���ׂ���̃t�H�[�J�X�ݒ�C�x���g
        /// </summary>
        /// <param name="ctrlKey">�R���g���[����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ���ׂ���̃t�H�[�J�X�ݒ�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void DetailGrid_SetFocus(string ctrlKey)
        {
            switch (ctrlKey)
            {
                case "tNedit_CustomerCode_St":
                    {
                        this.tNedit_CustomerCode_St.Focus();
                        break;
                    }
                case "tEdit_CarMngCode":
                    {
                        this.tEdit_CarMngCode.Focus();
                        break;
                    }
                case "uCheckEditor_AutoFillToColumn":
                    {
                        this.uCheckEditor_AutoFillToColumn.Focus();
                        break;
                    }
                case "Before_Grid":
                    {
                        // �O���b�h�̑O�̃R���g���[���Ƀt�H�[�J�X
                        // �Ώۋ敪�ɂ��قȂ�
                        this.tComboEditor_SearchDiv.Focus();

                        break;
                    }
            }
        }

        /// <summary>
        /// �ҏW�{�^���̉����ۂ�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ҏW�{�^���̉����ۂ�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void SetEditButtonEnable(bool flag)
        {
            this._editButton.SharedProps.Enabled = flag;
        }

        /// <summary>
        /// ������ʃf�[�^�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void InitialScreenData()
        {
            // ���o����
            this.tNedit_CustomerCode_St.Clear();
            this.tNedit_CustomerCode_Ed.Clear();
            this.tEdit_CarMngCode.Clear();

            // �����敪
            this.tComboEditor_SearchDiv.Items.Clear();
            this.tComboEditor_SearchDiv.Items.Add("1", SEARCH_DIV1);
            this.tComboEditor_SearchDiv.Items.Add("2", SEARCH_DIV2);
            this.tComboEditor_SearchDiv.Items.Add("3", SEARCH_DIV3);
            this.tComboEditor_SearchDiv.Items.Add("4", SEARCH_DIV4);
            this.tComboEditor_SearchDiv.SelectedIndex = 0;

            this.uCheckEditor_AutoFillToColumn.Checked = false;
            this.tComboEditor_GridFontSize.Text = "11";
            this.DeleteIndication_CheckEditor.Checked = false;

            this.tNedit_CustomerCode_St.Focus();
        }
        # endregion

        # region �� �I������ ��
        /// <summary>
        /// �I������
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ̏I������</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void CloseWindow()
        {
            // �ύX�L���`�F�b�N
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂�" + "\r\n" + "\r\n" +
                    "�o�^���Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    int status = this.Save();
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.Close();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }
        # endregion �� �I������ ��

        #region �� �������� ��
        /// <summary>
        ///�@��������(SearchProc())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �����������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// <br>Update Note : 2021/11/02 ���X�ؘj</br>
        /// <br>�Ǘ��ԍ�    : 11770175-00</br>
        /// <br>              OUT OF MEMORY�Ή�(4GB�Ή�) ���q�Ǘ��}�X�^�ێ�</br>
        /// <br>              ���o�Ώی������ő匏��20001���܂Łi20000���܂ŉ�ʕ\���j</br>
        /// </remarks>
        private void Search()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // �ύX�L���`�F�b�N
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂�" + "\r\n" + "\r\n" +
                    "�o�^���Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    status = this.Save();
                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return;
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    // NoThing
                }
                else
                {
                    return;
                }
            }

            string errMsg;
            Control errCtl;

            // ���͏����`�F�b�N
            if (!this.SearchBeforeCheck(out errMsg, out errCtl))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errCtl != null)
                {
                    errCtl.Focus();
                }

                return;
            }

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "���o��";
            msgForm.Message = "���q�Ǘ��}�X�^�̒��o���ł��B";
            try
            {
                msgForm.Show();

                CarManagementExtractInfo extractInfo;
                this.SetExtrInfo(out extractInfo);

                // ����
                string errMessge;
                status = this._carMngListInputAcs.Search(extractInfo, out errMessge);

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.RefreshSort(true);
                        this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();

                        this._oldExtractInfo = extractInfo;

                        // �O���b�h�\���̍X�V
                        this._detailGrid.SettingGrid();

                        // �폜�ς݃f�[�^�\���E��\���̔��f
                        this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

                        this.SetControlEnabled(SEARCH_MODE);

                        int activationColIndex;
                        int activationRowIndex;

                        // �t�H�[�J�X�ݒ�
                        string nextFocusColKey = this._detailGrid.GetNextFocusColumnKey(0, 0, false, out activationColIndex, out activationRowIndex);

                        if (nextFocusColKey != string.Empty)
                        {
                            this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColKey].Activate();

                            if (!this._detailGrid.uGrid_Details.Rows[activationRowIndex].IsFilteredOut)
                            {
                                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                if (this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.BelowCell))
                                {
                                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this._detailGrid.uGrid_Details.ActiveCell = null;
                                    this._detailGrid.uGrid_Details.ActiveRow = null;
                                }
                            }
                        }

                        // --- ADD ���X�ؘj 2021/11/02 ------>>>>>
                        if (this._carMngListInputAcs.CarInfoDataTable.Count > MAX_MST_RECORD_COUNT)
                        {
                            // �_�C�A���O�����
                            msgForm.Close();

                            // �ő匏���𒴂������̃��b�Z�[�W
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(INFO_MAX_RECORD, MAX_MST_RECORD_COUNT), 0);
                        }
                        // --- ADD ���X�ؘj 2021/11/02 ------<<<<<
                        break;

                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        // �ۑ����_�C�A���O�����
                        msgForm.Close();

                        // 0���G���[
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���������ɊY������f�[�^�����݂��܂���B", 0);
                        this.SetControlEnabled(INIT_MODE);
                        break;

                    default:
                        // �ۑ����_�C�A���O�����
                        msgForm.Close();

                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "���q�Ǘ��}�X�^�̌����Ɏ��s���܂����B" + "[" + errMessge + "]", 0);
                        this.SetControlEnabled(INIT_MODE);
                        break;
                }
            }
            finally
            {
                // �ۑ����_�C�A���O�����
                msgForm.Close();

                // �{�^������L������
                this._detailGrid.SetButtonEnable();
            }

        }

        /// <summary>
        /// ���������i�[����
        /// </summary>
        /// <param name="extrInfo">��������(�����I��out�p�����[�^�œn���܂�)</param>
        /// <remarks>
        /// <br>Note        : �����������i�[���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void SetExtrInfo(out CarManagementExtractInfo extrInfo)
        {
            extrInfo = new CarManagementExtractInfo();

            // ��ƃR�[�h
            extrInfo.EnterpriseCode = this._enterpriseCode;

            // ���Ӑ�R�[�h(�J�n)
            if (this.tNedit_CustomerCode_St.GetInt() == 0)
            {
                extrInfo.CustomerCodeSt = 1;
            }
            else
            {
                extrInfo.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
            }
            // ���Ӑ�R�[�h(�I��)
            if (this.tNedit_CustomerCode_Ed.GetInt() == 0)
            {
                extrInfo.CustomerCodeEd = 99999999;
            }
            else
            {
                extrInfo.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
            }

            // �Ǘ��ԍ�
            extrInfo.CarMngCode = this.tEdit_CarMngCode.Text;

            // �����敪
            extrInfo.SearchDiv = this.tComboEditor_SearchDiv.SelectedIndex;
        }

        /// <summary>
        /// ��ʏ����̓`�F�b�N����
        /// </summary>
        /// <param name="errMsg">message</param>
        /// <param name="errCtl">Control</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private bool SearchBeforeCheck(out string errMsg, out Control errCtl)
        {
            bool status = true;
            errMsg = string.Empty;
            errCtl = null;

            if ((this.tNedit_CustomerCode_St.GetInt() != 0) && (this.tNedit_CustomerCode_Ed.GetInt() != 0))
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    status = false;
                    errMsg = "���Ӑ�͈͎̔w��Ɍ�肪����܂��B";
                    errCtl = this.tNedit_CustomerCode_Ed;
                }
            }

            return status;
        }
        # endregion �� �������� ��

        # region �� �N���A���� ��
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �N���A���N���b�N���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void Clear()
        {
            // �ύX�L���`�F�b�N
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂�" + "\r\n" + "\r\n" +
                    "�o�^���Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    int status = this.Save();
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.ClearProc();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.ClearProc();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.ClearProc();
            }
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �N���A���N���b�N���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void ClearProc()
        {
            // ��ʏ�����
            this.SetControlEnabled(INIT_MODE);

            // �O���b�h���̏�����
            this._detailGrid.Initialize();

            // ������ʃf�[�^�ݒ�
            this.InitialScreenData();
        }
        #endregion

        # region �� �ŐV��񏈗� ��
        /// <summary>
        /// ��ʍŐV��񏈗�
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ŐV�����N���b�N���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void Renewal()
        {
            // �ύX�L���`�F�b�N
            bool isChanged = this.CompareGridDataWithOriginal();
            // -----UPD 2009/10/10 ------>>>>> 
            //�ŐV���擾���ɁA�ύX�f�[�^������ꍇ�́A�m�F���b�Z�[�W���o���Ȃ��悤�ɏC���B
            //if (isChanged)
            //{
            //    DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "���݁A�ҏW���̃f�[�^�����݂��܂�" + "\r\n" + "\r\n" +
            //        "�o�^���Ă���낵���ł����H",
            //        0,
            //        MessageBoxButtons.YesNoCancel,
            //        MessageBoxDefaultButton.Button1);

            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        int status = this.Save();
            //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //        {
            //            this.RenewalProc();
            //        }
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        this.RenewalProc();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
                this.RenewalProc();
            //}
            // -----UPD 2009/10/10 ------<<<<<
        }

        /// <summary>
        /// ��ʍŐV��񏈗�
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ŐV�����N���b�N���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void RenewalProc()
        {
            // ���Ӑ挟���}�X�^
            this._carMngListInputAcs.LoadCustomerSearchRet();
            // ���^�������ԍ��Ǎ�����
            this._carMngListInputAcs.LoadNumberPlate1Code();

            string msg = "�ŐV�����擾���܂����B";
            // ���b�Z�[�W��\��
            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, msg, 0);
        }
        #endregion

        # region �� �ۑ����� ��
        /// <summary>
        /// ��ʕۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ۑ����N���b�N���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int Save()
        {
            if (this._detailGrid.uGrid_Details.ActiveCell != null
                && this._detailGrid.uGrid_Details.ActiveCell.IsInEditMode)
            {
                // �ҏW���[�h����������
                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            }
            // --- ADD 2009/10/26 ----->>>>>
            if (!this._detailGrid.ChooseFlg)
            {
                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                this._detailGrid.ChooseFlg = true;
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                
            }
            // --- ADD 2009/10/26 -----<<<<<
            this._carMngListInputAcs.CarInfoDataTable.AcceptChanges();

            // �f�[�^���݃`�F�b�N
            if (this._carMngListInputAcs.CarInfoDataTable.Rows.Count == 0)
            {
                string message = "�X�V�Ώۂ̃f�[�^�����݂��܂���B";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, message, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            bool isChanged = this.CompareGridDataWithOriginal();

            if (!isChanged)
            {
                string message = "�X�V�Ώۂ̃f�[�^�����݂��܂���B";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, message, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            string errMsg;
            // ���̓`�F�b�N�i�O���b�h���j
            if (!this.SaveBeforeGridCheck(out errMsg))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg = string.Empty;

            Cursor _localCursor = this.Cursor;

            this.Cursor = Cursors.WaitCursor;

            // �ۑ����_�C�A���O�\��
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�ۑ���";
            msgForm.Message = "���q�Ǘ��}�X�^�̕ۑ����ł��B";

            try
            {
                // �ۑ�����
                status = this._carMngListInputAcs.Write(out msg);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // �o�^����
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);

                            //this.ClearProc();
                            // �O���b�h���̏�����
                            this._detailGrid.Initialize();

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            // �r������
                            ExclusiveTransaction(status);
                            this.SetControlEnabled(SEARCH_MODE);

                            break;
                        }
                    default:
                        {
                            // �ۑ����_�C�A���O�����
                            msgForm.Close();

                            MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "���q�Ǘ��}�X�^�̕ۑ��Ɏ��s���܂����B", status);
                            this.SetControlEnabled(SEARCH_MODE);
                            break;
                        }
                }
            }
            finally
            {
                // �ۑ����_�C�A���O�����
                msgForm.Close();

                // �J�[�\�������ɖ߂�
                this.Cursor = _localCursor;
            }

            return status;
        }

        /// <summary>
        /// �O���b�h���ڃ`�F�b�N
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns>True:OK Flase:NG</returns>
        /// <remarks>
        /// <br>Note        : �ۑ����N���b�N���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private bool SaveBeforeGridCheck(out string errMsg)
        {
            errMsg = string.Empty;

            // �L�[���ڂ̓��͂������ꍇ�G���[
            foreach (UltraGridRow ultraRow in this._detailGrid.uGrid_Details.Rows)
            {
                // �Ǘ��ԍ������̓`�F�b�N
                if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CustomerCodeColumn.ColumnName].Value == null
                    || ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CustomerCodeColumn.ColumnName].Value == DBNull.Value
                    || ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CustomerCodeColumn.ColumnName].Value.ToString() == string.Empty)
                {
                    errMsg = "���Ӑ����͂��ĉ������B";

                    // �t�H�[�J�X
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CustomerCodeColumn.ColumnName].Activate();
                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                    return false;
                }

                // �Ǘ��ԍ������̓`�F�b�N
                if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarMngCodeColumn.ColumnName].Value == null
                    || ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarMngCodeColumn.ColumnName].Value == DBNull.Value
                    || ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarMngCodeColumn.ColumnName].Value.ToString() == string.Empty)
                {
                    errMsg = "�Ǘ��ԍ�����͂��ĉ������B";

                    // �t�H�[�J�X
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarMngCodeColumn.ColumnName].Activate();
                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                    return false;
                }
                // ---- ADD 2009/10/10 ------>>>>>
                // �O��Ԍ������͂���̏ꍇ�A���Ԃ̖����̓`�F�b�N���s��
                if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != null
                    && !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString().Equals("�@")   // ADD 2009/10/10
                    && ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != DBNull.Value
                    && (Int32)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarInspectYearColumn.ColumnName].Value == 0)
                {
                    errMsg = "�Ԍ����� ����͂��ĉ������B";
                    // �t�H�[�J�X
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarInspectYearColumn.ColumnName].Activate();
                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    return false;
                }


                // ---- ADD 2009/10/10 ------<<<<<

                // �召�`�F�b�N(�O��Ԍ������o�^�N������)
                if (
                    //ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != null
                    //&& !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString().Equals("�@")   // ADD 2009/10/10
                    //&& ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != DBNull.Value
                    //&& 
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value != null
                    && !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value.ToString().Equals("�@")   // ADD 2009/10/10
                    && ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value != DBNull.Value
                    )
                {
                    // ----UPD 2009/10/10 ------>>>>>
                    //if ((DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value
                    //    < (DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value)
                    if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString().CompareTo(
                         ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value.ToString()) < 0)
                    // ----UPD 2009/10/10 ------>>>>>
                    {
                        errMsg = "�o�^�N�����ȍ~�̓��t����͂��ĉ������B";

                        // �t�H�[�J�X
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                }

                // �召�`�F�b�N(����Ԍ������o�^�N������)
                if (
                    //ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value != null
                    //&& !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value.ToString().Equals("�@")   // ADD 2009/10/10
                    //&& ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value != DBNull.Value
                    //&& 
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value != null
                    && !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value.ToString().Equals("�@")   // ADD 2009/10/10
                    && ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value != DBNull.Value)
                {
                    // ----UPD 2009/10/10 ------>>>>>
                    //if ((DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value
                    //    < (DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value)
                    if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value.ToString().CompareTo(
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value.ToString())<0)
                    // ----UPD 2009/10/10 ------>>>>>
                    {
                        errMsg = "�o�^�N�����ȍ~�̓��t����͂��ĉ������B";

                        // �t�H�[�J�X
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                }

                // �召�`�F�b�N(����Ԍ������O��Ԍ�����)
                if (
                    //ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value != null
                    //&& !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value.ToString().Equals("�@")   // ADD 2009/10/10
                    //&& ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value != DBNull.Value
                    //&& 
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != null
                    && !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString().Equals("�@")   // ADD 2009/10/10
                    && ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != DBNull.Value)
                {
                    // ----UPD 2009/10/10 ------>>>>>
                    //if ((DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value
                    //    < (DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value)
                    if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value.ToString().CompareTo(
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString())<0)
                    // ----UPD 2009/10/10 ------>>>>>
                    {
                        errMsg = "�O��Ԍ����ȍ~�̓��t����͂��ĉ������B";

                        // �t�H�[�J�X
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        # region �� ÷�ďo�͏��� ��
        /// <summary>
        /// ���÷�ďo�͏���
        /// </summary>
        /// <remarks>
        /// <br>Note        : ÷�ďo�͂��N���b�N���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// <br>Note        : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2019/08/19</br>
        /// </remarks>
        private int TextOutput()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            // �A���[�g�\��
            status = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
            // �A���[�g��OK�{�^����������Ȃ��ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, status, MessageBoxButtons.OK);
                }
                // ���~
                return status;
            }
            //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<

            // �e�L�X�g�o�͗p�_�C�A���O�ɕK�v�ȏ����Z�b�g����
            SFCMN06002C printInfo;
            status = this.GetPrintInfo(out printInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }

            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            customTextProviderInfo.OutPutFileName = printInfo.outPutFilePathName;
            // �㏑���^�ǉ��t���O���Z�b�g(true:�ǉ�����Afalse:�㏑������)
            customTextProviderInfo.AppendMode = printInfo.overWriteFlag;
            // �X�L�[�}�擾
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);

            DataTable outDataTable = new DataTable();
            this._carMngListInputAcs.GetTextOutData(out outDataTable);

            // CSV�o��
            status = customTextWriter.WriteText(outDataTable, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            int count = outDataTable.Rows.Count;// ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�
            outDataTable.Clear();
            string resultMessage = "";

            switch (status)
            {
                case 0:    // ��������
                    resultMessage = "CSV�o�͂��������܂����B";
                    break;
                case -9:    // �o�͑ΏۊO�̃f�[�^���w�肳�ꂽ
                    resultMessage = "�o�͑ΏۊO�̃f�[�^���w�肳��܂����B";
                    break;
                default:    // ���̑��G���[
                    resultMessage = "���̑��̃G���[���������܂����B�X�e�[�^�X(" + status.ToString() + ")";
                    break;
            }

            if (!string.IsNullOrEmpty(resultMessage))
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO
                            , resultMessage
                            , status);
            }
            //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �G���[���b�Z�[�W
                errMsg = string.Empty;
                // ���엚��o�^
                TextOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(CountNumStr, count.ToString()) + TextOutPutOprtnHisLogWorkObj.LogOperationData;
                status = TextOutPutOprtnHisLogAcsObj.Write(this, ref TextOutPutOprtnHisLogWorkObj, out errMsg);
                // ���O�o�^�ُ�̏ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, status, MessageBoxButtons.OK);
                    }
                }
            }
            //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<

            return status;
        }

        #region �� ������擾����
        /// <summary>
        /// ������擾����
        /// </summary>
        /// <param name="printInfo">������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ��������擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int GetPrintInfo(out SFCMN06002C printInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ������p�����[�^
            printInfo = new SFCMN06002C();
            // ���[�I���K�C�h
            SFCMN00391U printDialog = new SFCMN00391U();

            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �N���o�f�h�c
            printInfo.kidopgid = ct_PGID;
            printInfo.selectInfoCode = 1;
            //printInfo.PrintPaperSetCd = this._outPutMode;
            // ���[�I���K�C�h
            printDialog.PrintMode = 1;
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            switch (dialogResult)
            {
                case DialogResult.OK:
                    //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
                    // �G���[���b�Z�[�W
                    string errMsg = string.Empty;
                    // �e�L�X�g�o�͑��샍�O�o�^����
                    status = TextOutPutWrite(printInfo.outPutFilePathName, printInfo.prpnm, printInfo.overWriteFlag, out errMsg);

                    // ���O�o�^�ُ�̏ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (!string.IsNullOrEmpty(errMsg))
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                        errMsg, status, MessageBoxButtons.OK);
                        }
                        // ���~
                        return status;
                    }
                    //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
                    if (File.Exists(printInfo.outPutFilePathName) == false)
                    {
                        // �t�@�C���Ȃ�
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        // �t�@�C�������݂���ꍇ�́A�I�[�v���`�F�b�N
                        try
                        {
                            // ���ɖ��̂�ύX
                            string tempFileName = printInfo.outPutFilePathName
                                                + DateTime.Now.Ticks.ToString();
                            FileInfo fi = new FileInfo(printInfo.outPutFilePathName);
                            fi.MoveTo(tempFileName);
                            // ���̂̕ύX���������s�����̂ŁA���̂����ɖ߂�
                            fi.MoveTo(printInfo.outPutFilePathName);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        catch (Exception)
                        {
                            // ���̕ύX���s -> ���̃A�v���P�[�V�������r���Ŏg�p��
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO
                                        , "�w�肳�ꂽ�t�@�C���͎g�p�ł��܂���B\r\n"
                                        + "Excel�����g�p���Ă��Ȃ����m�F���āA\r\n"
                                        + "�g�p���Ă���Ƃ��̓t�@�C������ĉ������B"
                                        , 0);

                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                    }
                    break;
                case DialogResult.Cancel:
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    break;
                default:
                    // ��O������
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    break;
            }

            return status;
        }

        //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        /// <summary>
        /// �e�L�X�g�o�͑��샍�O�o�^����
        /// </summary>
        /// <param name="outPutFilePathName">�o�̓t�@�C���p�X</param>
        /// <param name="prpnm">�o�̓p�^�[��</param>
        /// <param name="overWriteFlag">�㏑���^�ǉ��t���O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O�o�^�������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/08/19</br>
        /// </remarks>
        private int TextOutPutWrite(string outPutFilePathName, string prpnm, bool overWriteFlag, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                TextOutPutOprtnHisLogWorkObj = new TextOutPutOprtnHisLogWork();
                // ���O�f�[�^�ΏۃA�Z���u��ID
                TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = PgId;
                // ���O�f�[�^�ΏۃA�Z���u������
                TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyNm = ct_PRINTNAME;
                // ���O�f�[�^�ΏۋN���v���O��������
                TextOutPutOprtnHisLogWorkObj.LogDataObjBootProgramNm = ct_PRINTNAME;
                // ���O�f�[�^�Ώۏ�����
                TextOutPutOprtnHisLogWorkObj.LogDataObjProcNm = MethodNm;
                // ���O�I�y���[�V�����f�[�^
                string customerCdSt = this.tNedit_CustomerCode_St.Text.Trim();
                customerCdSt = string.IsNullOrEmpty(customerCdSt) ? StartStr : customerCdSt;
                string customerCdEd = this.tNedit_CustomerCode_Ed.Text.Trim();
                customerCdEd = string.IsNullOrEmpty(customerCdEd) ? EndStr : customerCdEd;
                string carMngCode = this.tEdit_CarMngCode.Text;
                string selectedNm = string.Empty;
                if (!carMngCode.Equals(string.Empty))
                {
                    if (this.tComboEditor_SearchDiv.SelectedIndex == 0)
                    {
                        selectedNm = SEARCH_DIV1;
                    }
                    else if (this.tComboEditor_SearchDiv.SelectedIndex == 1)
                    {
                        selectedNm = SEARCH_DIV2;
                    }
                    else if (this.tComboEditor_SearchDiv.SelectedIndex == 2)
                    {
                        selectedNm = SEARCH_DIV3;
                    }
                    else
                    {
                        selectedNm = SEARCH_DIV4;
                    }
                }
                string overWrite = string.Empty;
                if (File.Exists(outPutFilePathName))
                {
                    overWrite = string.Format(",�㏑���^�ǉ�:{0}", overWriteFlag.Equals(true) ? AddWrite : OverWrite);
                }

                string logOperationData = string.Format(MenuCon, customerCdSt, customerCdEd, carMngCode, selectedNm, prpnm, outPutFilePathName) + overWrite;
                // ���O�I�y���[�V�����f�[�^
                TextOutPutOprtnHisLogWorkObj.LogOperationData = logOperationData;

                // �G���[���b�Z�[�W
                errMsg = string.Empty;
                // ���엚��o�^
                status = TextOutPutOprtnHisLogAcsObj.Write(this, ref TextOutPutOprtnHisLogWorkObj, out errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return status;
        }
        //----- ADD 2019/08/19 杍^ �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
        #endregion
        # endregion

        # region �� �r������ ��
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �r��������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        errMsg = "���ɑ��[�����X�V����Ă��܂��B";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        errMsg = "���ɑ��[�����폜����Ă��܂��B";
                        break;
                    }
            }

            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, status);

        }
        # endregion �� �r������

        #region �� ���̑����� ��
        /// <summary>
        /// �f�[�^���͉�ʂ��N������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �f�[�^���͉�ʂ��N�����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void StartInPut(object key)
        {
            PMSYA09021UC form;
            // �V�K�ꍇ
            if (key == null)
            {
                form = new PMSYA09021UC();
            }
            // �ҏW�ꍇ
            else
            {
                Guid newKey = (Guid)key;
                form = new PMSYA09021UC(newKey);
            }

            // �f�[�^���͉�ʂ��N���C�x���g
            form.RefreshParent += new PMSYA09021UC.RefreshParentHandler(this.RefreshParent);

            form.ShowDialog();
        }

        /// <summary>
        /// ��ʂ̏�ԍX�V����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ̏�Ԃ��X�V���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void RefreshParent(bool flag)
        {
            // �X�V�ꍇ
            if (flag)
            {
                // �O���b�g���ڂ��X�V
                this._detailGrid.SettingGrid();
                // �{�^������L������
                this._detailGrid.SetButtonEnable();
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�\������
        /// </summary>
        /// <param name="customerSearchRet">���Ӑ�}�X�^</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ�K�C�h��\�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int ShowCustomerGuide(out CustomerSearchRet customerSearchRet, int searchMode)
        {
            customerSearchRet = new CustomerSearchRet();

            this._cusotmerGuideSelected = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(searchMode, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._cusotmerGuideSelected == true)
            {
                customerSearchRet = this._customerSearchRet;
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�K�C�h�œ��Ӑ��I���������ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // �I���������Ӑ�}�X�^���o�b�t�@�ɕێ�
            this._customerSearchRet = customerSearchRet.Clone();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// ���׃O���b�h�ύX�L���`�F�b�N
        /// </summary>
        /// <returns>True:�ύX�L; False:�ύX��</returns>
        /// <remarks>
        /// <br>Note        : ���׃O���b�h�ύX�L���`�F�b�N���s��</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private bool CompareGridDataWithOriginal()
        {
            if (this._detailGrid.uGrid_Details.ActiveCell != null
                && this._detailGrid.uGrid_Details.ActiveCell.IsInEditMode)
            {
                // �ҏW���[�h����������
                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            }

            if (this._carMngListInputAcs.CarInfoDataTable.Rows.Count
                != this._carMngListInputAcs.OriginalCarInfoDataTable.Rows.Count)
            {
                // �s�����ς���Ă��邩
                return true;
            }

            // �l���ύX���ꂽ�Z�������邩
            for (int rowIndex = 0; rowIndex < this._carMngListInputAcs.CarInfoDataTable.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < this._carMngListInputAcs.CarInfoDataTable.Columns.Count; colIndex++)
                {

                    if (this._carMngListInputAcs.CarInfoDataTable.Rows[rowIndex][colIndex].ToString()
                        != this._carMngListInputAcs.OriginalCarInfoDataTable.Rows[rowIndex][colIndex].ToString())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�\������</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMSYA09021UA",						// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PRINTNAME,				// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        # endregion
        #endregion

        #region �� �R���g���[���C�x���g ��
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void PMSYA09020UA_Load(object sender, EventArgs e)
        {
            // ��ʏ�����
            InitialScreenSetting();

            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            // ��ʃC���[�W����
            this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            // ���ו�
            this.Panel_Detail.Controls.Add(this._detailGrid);
            this._detailGrid.Dock = DockStyle.Fill;

            // �t�H�[�J�X�ݒ�^�C�}�[
            this.InitialFocusTimer.Enabled = true;
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        this.CloseWindow();
                        break;
                    }
                // ����
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        // ����
                        this.Search();
                        break;
                    }
                // �N���A
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        this.Clear();
                        break;
                    }
                // �V�K
                case TOOLBAR_NEWBUTTON_KEY:
                    {
                        this.StartInPut(null);
                        break;
                    }
                // �ҏW
                case TOOLBAR_EDITBUTTON_KEY:
                    {
                        List<Guid> list = this._detailGrid.GetSelectedRowNoList();

                        this.StartInPut(list[0]);
                        break;
                    }
                // �ۑ�
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        this.Save();
                        break;
                    }
                // ÷�ďo��
                case TOOLBAR_TEXTOUTPUTBUTTON_KEY:
                    {
                        this.TextOutput();
                        break;
                    }
                // �ŐV���
                case TOOLBAR_NEWINFOBUTTON_KEY:
                    {
                        this.Renewal();
                        break;
                    }
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // ���Ӑ�R�[�h�J�n
                case "tNedit_CustomerCode_St":
                    {
                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                        {
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = DeleteIndication_CheckEditor;
                            }
                            else
                            {
                                if (this.tNedit_CustomerCode_St.GetInt() == 0)
                                {
                                    e.NextCtrl = this.CustomerGuideSt_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                }
                            }
                        }
                        break;
                    }
                // ���Ӑ�R�[�h�I��
                case "tNedit_CustomerCode_Ed":
                    {
                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                        {
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                            }
                            else
                            {
                                if (this.tNedit_CustomerCode_Ed.GetInt() == 0)
                                {
                                    e.NextCtrl = this.CustomerGuideEd_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_CarMngCode;
                                }
                            }
                        }
                        break;
                    }
                // �Ǘ��ԍ�
                case "tEdit_CarMngCode":
                    {
                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                        {
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                            }
                            else
                            {
                                if (this.tEdit_CarMngCode.Text == string.Empty)
                                {
                                    e.NextCtrl = this.CarMngCode_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tComboEditor_SearchDiv;
                                }
                            }
                        }

                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = this._detailGrid.uGrid_Details;
                        }
                        break;
                    }
                // �����敪
                case "tComboEditor_SearchDiv":
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                        {
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = this.tEdit_CarMngCode;
                            }
                            else
                            {

                                e.NextCtrl = this._detailGrid.uGrid_Details;
                            }
                        }
                        break;
                    }
                // �O���b�h
                case "uGrid_Details":
                    {
                        if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                        {
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // �O���b�h�^�u�ړ�����
                                this._detailGrid.SetGridTabFocus(ref e);
                            }
                            else
                            {
                                this._detailGrid.SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (e.NextCtrl.Name == "PMSYA09021UB")
                                {
                                    e.NextCtrl = this.tComboEditor_SearchDiv;
                                }
                                // �O���b�h�V�t�g�^�u�ړ�����
                                this._detailGrid.SetGridShiftTabFocus(ref e);
                            }
                        }

                        break;
                    }
                // ��T�C�Y���������`�F�b�N�{�b�N�X
                case "uCheckEditor_AutoFillToColumn":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.tComboEditor_SearchDiv;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();

                                    this._detailGrid.uGrid_Details.Rows[this._detailGrid.uGrid_Details.Rows.Count - 1].Cells["CarNoteGuide"].Activate();
                                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = this.tComboEditor_GridFontSize;
                        }
                        break;
                    }
                // �����T�C�Y�R���{�{�b�N�X
                case "tComboEditor_GridFontSize":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.DeleteIndication_CheckEditor;
                            }
                        }
                        break;
                    }
                // �폜�σf�[�^�̕\��
                case "DeleteIndication_CheckEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "PMSYA09021UB":
                case "uGrid_Details":
                    {
                        if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = this.uCheckEditor_AutoFillToColumn;
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tEdit_CarMngCode;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tComboEditor_SearchDiv;
                                }
                            }
                        }
                        else
                        {
                            string nextFocusColumn;

                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(0, 0, false, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uCheckEditor_AutoFillToColumn;
                                    }
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    // �ŏI�s�Ƀt�H�[�J�X
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(0, this._detailGrid.uGrid_Details.Rows.Count - 1, false, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_CarMngCode;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1, this._detailGrid.uGrid_Details.Rows.Count - 1, true, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_SearchDiv;
                                    }
                                }
                            }
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            UltraButton uButton = (UltraButton)sender;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                CustomerSearchRet customerSearchRet;

                int status = ShowCustomerGuide(out customerSearchRet, PMKHN04005UA.SEARCHMODE_NORMAL);
                if (status == 0)
                {
                    // �t�H�[�J�X�ݒ�
                    if (uButton.Name == "CustomerGuideSt_Button")
                    {
                        // �J�n
                        this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
                        this.tNedit_CustomerCode_Ed.Focus();
                    }
                    else
                    {
                        // �I��
                        this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
                        this.tEdit_CarMngCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Ǘ��ԍ��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void CarMngCode_Button_Click(object sender, EventArgs e)
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
                // ���q�Ǘ��敪�`�F�b�N����
                paramInfo.IsCheckCarMngDivCd = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "�V�K�o�^")
                    {
                        this.tEdit_CarMngCode.Text = selectedInfo.CarMngCode;
                        this.tComboEditor_SearchDiv.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// CheckedChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ��T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uCheckEditor_AutoFillToColumn_CheckedChanged(object sender, EventArgs e)
        {
            this._detailGrid.AutoFillToColumnSetting(this.uCheckEditor_AutoFillToColumn.Checked);
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H���g�T�C�Y�R���{�{�b�N�X�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this._detailGrid.GridFontSizeSetting(11);
            }
            else
            {
                this._detailGrid.GridFontSizeSetting((int)this.tComboEditor_GridFontSize.Value);
            }
        }

        /// <summary>
        /// �폜�ς݃f�[�^�\���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �폜�ς݃f�[�^�\���{�^���N�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void DeleteIndication_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);
        }

        /// <summary>
        /// �����t�H�[�J�X�ݒ�^�C�}
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �����t�H�[�J�X�ݒ�^�C�}</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>  
        private void InitialFocusTimer_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tNedit_CustomerCode_St.Focus();

            // �폜�ς݃f�[�^�\���̐���
            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

            this.InitialFocusTimer.Enabled = false;
        }
        #endregion
    }
}