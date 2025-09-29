//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/05  �C�����e : Redmine#22743 �ڕW�l���S��0�ł��o�^�\�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/05  �C�����e : Redmine#22750 �t�H�[�J�X�����Q�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using System.Collections;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[���ڕW�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���ڕW�ݒ�t�H�[���N���X</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>Update Note: 2011/07/05 杍^ Redmine#22743 �ڕW�l���S��0�ł��o�^�\�̑Ή�</br>
    /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
    /// </remarks>
    public partial class PMKHN09651UA : Form
    {
        #region �� Constants

        private const string ASSEMBLY_ID = "PMKHN09651U";

        private const string COLUMN_MONTH = "Month";
        private const string COLUMN_SALESTARGET = "SalesTarget";
        private const string COLUMN_PROFITTARGET = "ProfitTarget";
        private const string COLUMN_COUNTTARGET = "CountTarget";

        private const string FORMAT_NUM = "#,###,###,###";
        private const string FORMAT_NUM1 = "##,###,###,###,###";

        private const string INSERT_MODE = "�V�K";
        private const string UPDATE_MODE = "�X�V";
        private const string DELETE_MODE = "�폜";

        private const string ctGUIDE_NAME_CampaignGuide = "tNedit_CampaignCode";
        private const string ctGUIDE_NAME_Section = "tEdit_SectionCode";
        private const string ctGUIDE_NAME_CustomerCode = "tNedit_CustomerCode";
        private const string ctGUIDE_NAME_EmployeeCode = "tEdit_EmployeeCode";
        private const string ctGUIDE_NAME_SalesAreaCode = "tNedit_SalesAreaCode";
        private const string ctGUIDE_NAME_SalesGroupCode = "tNedit_BLGloupCode";
        private const string ctGUIDE_NAME_BLCode = "tNedit_BLGoodsCode";
        private const string ctGUIDE_NAME_SalesCode = "tNedit_SalesCode";
        private string _guideKey;

        private const string ct_Tool_CloseButton = "tool_Close";						// �I��
        private const string ct_Tool_NewButton = "tool_New";							// �V�K
        private const string ct_Tool_SaveButton = "tool_Save";							// �ۑ�
        private const string ct_Tool_LogicalDeleteButton = "tool_LogicalDelete";		// �_���폜
        private const string ct_Tool_DeleteButton = "tool_Delete";						// �폜
        private const string ct_Tool_RevivalButton = "tool_Revival";					// ����
        private const string ct_Tool_UndoButton = "tool_Undo";					        // ���ɖ߂�
        private const string ct_Tool_GuideButton = "tool_Guide";					    // �K�C�h
        private const string ct_Tool_RenewalButton = "tool_Renewal";					// �ŐV���
        private const string ct_Tool_LoginEmployee = "tool_LoginEmployee";				// ���O�C���S���҃^�C�g��
        private const string ct_Tool_LoginEmployeeName = "tool_LoginEmployeeName";		// ���O�C���S���Җ���
        #endregion �� Constants


        #region �� Private Members

        private bool _isClose;
        private bool _isSave;
        private bool _isNew;
        private bool _isRevival;
        private bool _isLogicalDelete;
        private bool _isDelete;
        private bool _isUndo;
        private bool _isRenewal;
        private bool _isGuide;

        private string _enterpriseCode;                     // ��ƃR�[�h

        private bool _cusotmerGuideSelected;                // ���Ӑ�K�C�h�I���t���O

        private List<DateTime> _yearMonthList;              // �N���x���X�g
        private List<DateTime> _startMonthDateList;         // �N���x�J�n�����X�g
        private List<DateTime> _endMonthDateList;           // �N���x�I�������X�g
        private int _year;                                  // ��v�N�x
        private int _thisYear;                              // ���N�x

        private SecInfoAcs _secInfoAcs;                     // ���_�}�X�^
        private SecInfoSetAcs _secInfoSetAcs;               // ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂�
        private CampaignStAcs _campaignStAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;       // ���Ӑ�}�X�^
        private EmployeeAcs _employeeAcs;                   // �]�ƈ��}�X�^
        private UserGuideAcs _userGuideAcs;                 // ���[�U�[�K�C�h�}�X�^
        private BLGroupUAcs _blGroupUAcs;                   // �O���[�v�R�[�h�K�C�h�}�X�^
        private BLGoodsCdAcs _blGoodsCdAcs;                  // BL�R�[�h�K�C�h�}�X�^
        private CampaignTargetAcs _campaignTargetAcs;       // �L�����y�[���ڕW�ݒ�}�X�^
        private DateGetAcs _dateGetAcs;

        private Dictionary<int, CampaignSt> _campaignStDic;
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<string, Employee> _employeeDic;
        private Dictionary<int, string> _blGroupUDic;
        private Dictionary<int, string> _blGoodsCdDic;
        private Dictionary<int, string> _salesAreaDic;
        private Dictionary<int, string> _salesCodeDic;

        private Dictionary<string, CampaignTarget> _campaignTargetDicClone;

        //private bool _searchFlg;  // DEL K2011/07/05 

        private int _prevTargetContrastCd;
        private int _prevCampaignCode;
        private string _prevSectionCode;
        private int _prevCustomerCode;
        private string _prevEmployeeCode;
        private int _prevSalesAreaCode;
        private int _prevSalesCode;
        private int _prevBLGroupCode;
        private int _prevBLGoodsCode;

        private int _prevSetArea;

        private int _customerFlag;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        #endregion �� Private Members


        #region �� Constructor

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�t�H�[���N���X</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public PMKHN09651UA()
        {
            InitializeComponent();

            this._isClose = true;
            this._isSave = true;
            this._isNew = true;
            this._isRevival = false;
            this._isLogicalDelete = false;
            this._isDelete = false;
            this._isUndo = true;
            this._isGuide = true;
            this._isRenewal = true;
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �e��A�N�Z�X�N���X�C���X�^���X����
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._campaignStAcs = new CampaignStAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._employeeAcs = new EmployeeAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();
            this._campaignTargetAcs = new CampaignTargetAcs();

            this._campaignTargetDicClone = new Dictionary<string, CampaignTarget>();


            // �e��}�X�^�擾
            bool bStatus = ReadMaster();
            if (!bStatus)
            {
                return;
            }

            // ��v�N�x���擾
            GetFinancialYearTable(0);

            // �c�[���{�^��Enable�ݒ�
            SetToolButtonVisible(this);
        }

        #endregion �� Constructor

        /// <summary> �I���{�^��Visible�v���p�e�B </summary>
        public bool IsClose
        {
            get { return this._isClose; }
        }

        /// <summary> �ۑ��{�^��Visible�v���p�e�B </summary>
        public bool IsSave
        {
            get { return this._isSave; }
        }

        /// <summary> �V�K�{�^��Visible�v���p�e�B </summary>
        public bool IsNew
        {
            get { return this._isNew; }
        }

        /// <summary> �����{�^��Visible�v���p�e�B </summary>
        public bool IsRevival
        {
            get { return this._isRevival; }
        }

        /// <summary> �_���폜�{�^��Visible�v���p�e�B </summary>
        public bool IsLogicalDelete
        {
            get { return this._isLogicalDelete; }
        }

        /// <summary> ���S�폜�{�^��Visible�v���p�e�B </summary>
        public bool IsDelete
        {
            get { return this._isDelete; }
        }

        /// <summary> ���ɖ߂��{�^��Visible�v���p�e�B </summary>
        public bool IsUndo
        {
            get { return this._isUndo; }
        }

        /// <summary> �ŐV���{�^��Visible�v���p�e�B </summary>
        public bool IsRenewal
        {
            get { return this._isRenewal; }
        }

        /// <summary> �K�C�h��{�^��Visible�v���p�e�B </summary>
        public bool IsGuide
        {
            get { return this._isGuide; }
        }
        /// <summary>
        /// �I���O����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I���O�������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int BeforeClose()
        {
            DialogResult result = DialogResult.No;

            // ��ʏ�ԕύX�`�F�b�N
            bool bStatus = CompareInputScreen();
            if (!bStatus)
            {
                result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                       "",
                                       0,
                                       MessageBoxButtons.YesNoCancel,
                                       MessageBoxDefaultButton.Button2);
            }
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        // �ۑ�����
                        int status = SaveProc();
                        if (status != 0)
                        {
                            return (status);
                        }

                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return -1;
                    }
            }

            return 0;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Save()
        {
            return SaveProc();
        }

        /// <summary>
        /// �V�K����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �V�K�������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int New()
        {
            DialogResult result = DialogResult.No;

            // ��ʏ�ԕύX�`�F�b�N
            bool bStatus = CompareInputScreen();
            if (!bStatus)
            {
                result = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                           "�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" + "�o�^���Ă��悢�ł����H",
                                           0,
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxDefaultButton.Button1);
            }

            switch (result)
            {
                case DialogResult.Yes:
                    {
                        // �ۑ�����
                        int status = SaveProc();
                        if (status != 0)
                        {
                            return (status);
                        }

                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return 0;
                    }
            }

            // ��ʏ���������
            ClearScreen();

            SetControlEnabled(INSERT_MODE);

            this.tNedit_CampaignCode.Focus();

            // �����R���g���[��Enabled����
            ChangeTargetContrastControl(10);

            // �t�H�[�J�X�ݒ�
            this.timer_SetFocus.Enabled = true;

            return 0;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Revival()
        {
            int statsu = RevivalProc();
            if (statsu == 0)
            {
                // �t�H�[�J�X�ݒ�
                this.tNedit_SalesTargetSale.Focus();
            }

            return (statsu);
        }

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        public int LogicalDelete()
        {
            // �_���폜�m�F
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "���݁A�\�����̃f�[�^���폜���܂��B\r\n��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return 0;
            }


            if (this._prevCampaignCode != 0)
            {
                this.tNedit_CampaignCode.Text = this._prevCampaignCode.ToString();
            }
            if (!string.IsNullOrEmpty(this._prevSectionCode))
            {
                this.tEdit_SectionCode.Text = int.Parse(this._prevSectionCode).ToString("00");

            }
            if (this._prevCustomerCode != 0)
            {
                this.tNedit_CustomerCode.Text = this._prevCustomerCode.ToString("00000000");
            }
            if (!string.IsNullOrEmpty(this._prevEmployeeCode))
            {
                this.tEdit_EmployeeCode.Text = int.Parse(this._prevEmployeeCode).ToString("0000");
            }
            if (this._prevSalesAreaCode != 0)
            {
                this.tNedit_SalesAreaCode.Text = this._prevSalesAreaCode.ToString("0000");
            }
            if (this._prevBLGroupCode != 0)
            {
                this.tNedit_BLGloupCode.Text = this._prevBLGroupCode.ToString("00000");
            }
            if (this._prevBLGoodsCode != 0)
            {
                this.tNedit_BLGoodsCode.Text = this._prevBLGoodsCode.ToString("00000");
            }
            if (this._prevSalesCode != 0)
            {
                this.tNedit_SalesCode.Text = this._prevSalesCode.ToString("0000");
            }
            
            return LogicalDeleteProc();
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����폜�������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Delete()
        {
            // ���S�폜�m�F
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "�f�[�^�𕨗��폜���܂��B\r\n��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return 0;
            }

            return DeleteProc();
        }

        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���ɖ߂��������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Undo()
        {
            return UndoProc();
        }

        /// <summary>
        /// �K�C�h����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Guide()
        {
            ExecuteGuide();
            return 0;
        }

        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ŐV�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Renewal()
        {
            return RenewalProc();
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public void SetFocus()
        {
            this.tNedit_CampaignCode.Focus();
        }

        #region �� Private Methods

        #region �c�[���o�[�����ݒ菈��
        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̏����ݒ���s��</br>
        /// <br>Programer  : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void InitialToolbarSetting()
        {
            // �C���[�W���X�g�ݒ�
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
           
            //----------------------------
            // �c�[���A�C�R���ݒ�
            //----------------------------
            // �I��
            this.tToolsManager_MainMenu.Tools[ct_Tool_CloseButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // �V�K
            this.tToolsManager_MainMenu.Tools[ct_Tool_NewButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // �ۑ�
            this.tToolsManager_MainMenu.Tools[ct_Tool_SaveButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // �_���폜
            this.tToolsManager_MainMenu.Tools[ct_Tool_LogicalDeleteButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // �폜
            this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // ����
            this.tToolsManager_MainMenu.Tools[ct_Tool_RevivalButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // ���ɖ߂�
            this.tToolsManager_MainMenu.Tools[ct_Tool_UndoButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // �K�C�h�v�Z
            this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // �ŐV���
            this.tToolsManager_MainMenu.Tools[ct_Tool_RenewalButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // ���O�C���S����
            this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployee].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // �S���ҕ\��
            if (LoginInfoAcquisition.Employee != null)
            {
                LabelTool loginNameLabel = (LabelTool)this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployeeName];
                if (loginNameLabel != null)
                {
                    loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
                }
            }
        }
        #endregion

        #region �c�[���o�[�����ݒ菈��
        /// <summary>
        /// �c�[���{�^��Enable�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���{�^��Enable��ݒ肷��</br>
        /// <br>Programer  : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetToolButtonVisible(Form form)
        {
            // �V�K
            this.tToolsManager_MainMenu.Tools[ct_Tool_NewButton].SharedProps.Visible = this.IsNew;
            this.tToolsManager_MainMenu.Tools[ct_Tool_NewButton].SharedProps.Enabled = this.IsNew;
            // �ۑ�
            this.tToolsManager_MainMenu.Tools[ct_Tool_SaveButton].SharedProps.Visible = this.IsSave;
            this.tToolsManager_MainMenu.Tools[ct_Tool_SaveButton].SharedProps.Enabled = this.IsSave;
            // �_���폜
            this.tToolsManager_MainMenu.Tools[ct_Tool_LogicalDeleteButton].SharedProps.Visible = this.IsLogicalDelete;
            this.tToolsManager_MainMenu.Tools[ct_Tool_LogicalDeleteButton].SharedProps.Enabled = this.IsLogicalDelete;
            // �폜
            this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.Visible = this.IsDelete;
            this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.Enabled = this.IsDelete;
            // ����
            this.tToolsManager_MainMenu.Tools[ct_Tool_RevivalButton].SharedProps.Visible = this.IsRevival;
            this.tToolsManager_MainMenu.Tools[ct_Tool_RevivalButton].SharedProps.Enabled = this.IsRevival;
            // ���ɖ߂�
            this.tToolsManager_MainMenu.Tools[ct_Tool_UndoButton].SharedProps.Visible = this.IsUndo;
            this.tToolsManager_MainMenu.Tools[ct_Tool_UndoButton].SharedProps.Enabled = this.IsUndo;
            // �K�C�h�v�Z
            this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.Visible = this.IsGuide;
            this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.Enabled = this.IsGuide;
            // �ŐV���
            this.tToolsManager_MainMenu.Tools[ct_Tool_RenewalButton].SharedProps.Visible = this.IsRenewal;
            this.tToolsManager_MainMenu.Tools[ct_Tool_RenewalButton].SharedProps.Enabled = this.IsRenewal;
        }
        #endregion


        #region �}�X�^�Ǎ�
        /// <summary>
        /// �e��}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:�ُ�)</returns>
        /// <remarks>
        /// <br>Note       : �e��}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool ReadMaster()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string errMsg = "";

            try
            {
                // �L�����y�[���R�[�h
                status = GetCampaignStList();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�L�����y�[���ݒ�}�X�^�̓Ǎ��Ɏ��s���܂����B";
                        return (false);
                }

                // ���_
                status = ReadSecInfoSet();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "���_�}�X�^�̓Ǎ��Ɏ��s���܂����B";
                        return (false);
                }

                // ���Ӑ�
                status = ReadCustomer();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "���Ӑ�}�X�^�̓Ǎ��Ɏ��s���܂����B";
                        return (false);
                }

                // �]�ƈ�
                status = ReadEmployee();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�]�ƈ��}�X�^�̓Ǎ��Ɏ��s���܂����B";
                        return (false);
                }

                // �n��
                status = ReadSalesArea();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�n����̎擾�Ɏ��s���܂����B";
                        return (false);
                }

                // �O���[�v�R�[�h
                status = ReadBLGroup();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�O���[�v�R�[�h���̎擾�Ɏ��s���܂����B";
                        return (false);
                }

                // BL�R�[�h
                status = ReadBLGoodsCd();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "BL�R�[�h���̎擾�Ɏ��s���܂����B";
                        return (false);
                }

                // �̔��敪
                status = ReadSalesCode();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�̔��敪���̎擾�Ɏ��s���܂����B";
                        return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                  this.Name,
                                  errMsg,
                                  status,
                                  MessageBoxButtons.OK);
                }
            }

            return (true);
        }

        /// <summary>
        /// �L�����y�[���ݒ胊�X�g�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�}�X�^�̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private int GetCampaignStList()
        {
            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            _campaignStDic = new Dictionary<int, CampaignSt>();
            ArrayList retList;

            try
            {
                // �S����
                int status = _campaignStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CampaignSt campaignSt in retList)
                    {
                        if (!_campaignStDic.ContainsKey(campaignSt.CampaignCode))
                        {
                            _campaignStDic.Add(campaignSt.CampaignCode, campaignSt);
                        }
                    }
                }
            }
            catch
            {
                this._campaignStDic = new Dictionary<int, CampaignSt>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <returns>�L�����y�[���ݒ�f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�}�X�^�̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private CampaignSt ReadCampaignSt(int campaignCode)
        {
            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            CampaignSt campaignSt;
            int status = _campaignStAcs.Read(out campaignSt, LoginInfoAcquisition.EnterpriseCode, campaignCode);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                (campaignSt.LogicalDeleteCode == 0))
            {
                ;
            }
            else
            {
                campaignSt = new CampaignSt();
            }

            return campaignSt;
        }

        /// <summary>
        /// ���_�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadCustomer()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retArray;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet customerSearchRet in retArray)
                    {
                        if (customerSearchRet.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(customerSearchRet.CustomerCode, customerSearchRet);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// �]�ƈ��}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadEmployee()
        {
            this._employeeDic = new Dictionary<string, Employee>();

            try
            {
                ArrayList retList;
                ArrayList retList2;

                int status = this._employeeAcs.SearchAll(out retList, out retList2, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Employee employee in retList)
                    {
                        if (employee.LogicalDeleteCode == 0)
                        {
                            this._employeeDic.Add(employee.EmployeeCode.Trim(), employee);
                        }
                    }
                }
            }
            catch
            {
                this._employeeDic = new Dictionary<string, Employee>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// �n��}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n��}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadSalesArea()
        {
            this._salesAreaDic = new Dictionary<int, string>();

            return ReadUserGdBd(21, ref this._salesAreaDic);
        }

        /// <summary>
        /// BL�O���[�v�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadBLGroup()
        {
            this._blGroupUDic = new Dictionary<int, string>();

            try
            {
                string enterpriseCode = this._enterpriseCode;

                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retList)
                    {
                        if (bLGroupU.LogicalDeleteCode == 0)
                        {
                            this._blGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU.BLGroupName);
                        }
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// �̔��敪�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �̔��敪�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadSalesCode()
        {
            this._salesCodeDic = new Dictionary<int, string>();

            return ReadUserGdBd(71, ref this._salesCodeDic);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadBLGoodsCd()
        {
            this._blGoodsCdDic = new Dictionary<int, string>();

            try
            {
                string enterpriseCode = this._enterpriseCode;
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt.BLGoodsFullName);
                        }
                    }
                }

            }
            catch
            {
                this._blGoodsCdDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�Ǎ�����
        /// </summary>
        /// <param name="userGuideDivCd">�K�C�h�敪</param>
        /// <param name="targetDic">�Ώ�Dictionary</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadUserGdBd(int userGuideDivCd, ref Dictionary<int, string> targetDic)
        {
            try
            {
                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                     userGuideDivCd, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            targetDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                        }
                    }
                }
            }
            catch
            {
                targetDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }
        #endregion �}�X�^�Ǎ�

        #region ���̎擾
        /// <summary>
        /// �L�����y�[�����̎擾
        /// </summary>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <returns>�L�����y�[������</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�����̂̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public string GetCampaignName(int campaignCode)
        {
            string name = string.Empty;

            if (_campaignStDic == null)
            {
                // �L�����y�[���ݒ胊�X�g�擾
                GetCampaignStList();
            }

            CampaignSt campaignSt;
            if (_campaignStDic.ContainsKey(campaignCode))
            {
                // �f�B�N�V���i���[�ɑ���
                campaignSt = _campaignStDic[campaignCode];
                name = campaignSt.CampaignName;
            }
            else
            {
                // �f�B�N�V���i���[�ɑ��݂��Ȃ��̂ŁA�}�X�^����Ǎ�
                campaignSt = ReadCampaignSt(campaignCode);
                name = campaignSt.CampaignName;
            }

            return name;
        }

        /// <summary>
        /// ���_���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : ���_�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// ���Ӑ於�擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於���擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                if (customerCode != 0)
                {
                    customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
                }
            }

            return customerName;
        }

        /// <summary>
        /// �]�ƈ����擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ���</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ������擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            if (this._employeeDic.ContainsKey(employeeCode.Trim()))
            {
                employeeName = this._employeeDic[employeeCode].Name.Trim();
            }

            return employeeName;
        }

        /// <summary>
        /// �n�於�擾����
        /// </summary>
        /// <param name="salesAreaCode">�n��R�[�h</param>
        /// <returns>�n�於</returns>
        /// <remarks>
        /// <br>Note       : �n�於���擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetSalesAreaName(int salesAreaCode)
        {
            string salesAreaName = "";

            if (this._salesAreaDic.ContainsKey(salesAreaCode))
            {
                if (salesAreaCode != 0)
                {
                    salesAreaName = this._salesAreaDic[salesAreaCode].Trim();
                }
            }

            return salesAreaName;
        }

        /// <summary>
        /// BL�O���[�v�擾����
        /// </summary>
        /// <param name="blGroupCode">BL�O���[�v�R�[�h</param>
        /// <returns>BL�O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            string blGroupName = "";

            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                if (blGroupCode != 0)
                {
                    blGroupName = this._blGroupUDic[blGroupCode].Trim();
                }
            }

            return blGroupName;
        }

        /// <summary>
        /// �̔��敪���擾����
        /// </summary>
        /// <param name="salesCode">�̔��敪�R�[�h</param>
        /// <returns>�̔��敪��</returns>
        /// <remarks>
        /// <br>Note       : �̔��敪�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetSalesCodeName(int salesCode)
        {
            string salesCodeName = "";

            if (this._salesCodeDic.ContainsKey(salesCode))
            {
                if (salesCode != 0)
                {
                    salesCodeName = this._salesCodeDic[salesCode].Trim();
                }
            }

            return salesCodeName;
        }

        /// <summary>
        /// BL���̎擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns>BL����</returns>
        /// <remarks>
        /// <br>Note       : BL���̂��擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            if (this._blGoodsCdDic.ContainsKey(blGoodsCode))
            {
                if (blGoodsCode != 0)
                {
                    blGoodsName = this._blGoodsCdDic[blGoodsCode].Trim();
                }
            }

            return blGoodsName;
        }
        #endregion ���̎擾


        #region �}�X�^���݃`�F�b�N
        /// <summary>
        /// ���Ӑ摶�݃`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>true�FOK�Afalse�FNG</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ悪���݂��邩�`�F�b�N���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        #endregion �}�X�^���݃`�F�b�N

        #region ��v�N�x�e�[�u���擾
        /// <summary>
        /// ��v�N�x�e�[�u���擾����
        /// </summary>
        /// <param name="addYearFromThis">���N����̍���</param>
        /// <remarks>
        /// <br>Note       : ��v�N�x�e�[�u�����擾���A��v�N�x�����o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void GetFinancialYearTable(int addYearFromThis)
        {
            try
            {
                this._dateGetAcs.GetFinancialYearTable(addYearFromThis,
                                                       out this._startMonthDateList,
                                                       out this._endMonthDateList,
                                                       out this._yearMonthList,
                                                       out this._year);
                if (addYearFromThis == 0)
                {
                    this._thisYear = this._year;
                }
            }
            catch
            {
                this._startMonthDateList = new List<DateTime>();
                this._endMonthDateList = new List<DateTime>();
                this._yearMonthList = new List<DateTime>();
                this._year = 0;
            }
        }
        #endregion ��v�N�x�e�[�u���擾


        #region ��ʏ�����

        private void InitialSetting()
        {

            // ��ʃC���[�W����
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �c�[���o�[�����ݒ菈��
            InitialToolbarSetting();
        }



        /// <summary>
        /// ��ʏ�񏉊�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.tNedit_CampaignCode.Clear();
            this.tEdit_CampaignName.Clear();
            this.tNedit_YearFrm.Clear();
            this.tNedit_MonthFrm.Clear();
            this.tNedit_DayFrm.Clear();
            this.tNedit_YearTo.Clear();
            this.tNedit_MonthTo.Clear();
            this.tNedit_DayTo.Clear();
            this.tComboEditor_TargetContrastCd.Value = 10;
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();
            this.tEdit_EmployeeCode.Clear();
            this.tEdit_EmployeeName.Clear();
            this.tNedit_SalesAreaCode.Clear();
            this.tEdit_SalesAreaName.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tEdit_GroupName.Clear();
            this.tNedit_SalesCode.Clear();
            this.tEdit_SalesCodeName.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLName.Clear();

            ClearGrid();

            this.Mode_Label.Text = INSERT_MODE;

            //this._searchFlg = false; // DEL K2011/07/05 

            this._prevTargetContrastCd = 10;
            this._prevCampaignCode = 0;
            this._prevSectionCode = "";
            this._prevCustomerCode = 0;
            this._prevEmployeeCode = "";
            this._prevSalesAreaCode = 0;
            this._prevSalesCode = 0;
            this._prevBLGroupCode = 0;
            this._prevBLGoodsCode = 0;
            this._prevSetArea = 10;
            this._customerFlag = 0;
        }

        /// <summary>
        /// ��ʏ�񏉊�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void ComboChgClearScreen()
        {
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();
            this.tEdit_EmployeeCode.Clear();
            this.tEdit_EmployeeName.Clear();
            this.tNedit_SalesAreaCode.Clear();
            this.tEdit_SalesAreaName.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tEdit_GroupName.Clear();
            this.tNedit_SalesCode.Clear();
            this.tEdit_SalesCodeName.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLName.Clear();

            ClearGrid();

            this.Mode_Label.Text = INSERT_MODE;
            SetControlEnabled(INSERT_MODE);  // ADD K2011/07/05 

            //this._searchFlg = false; // DEL K2011/07/05

            this._prevTargetContrastCd = (Int32)this.tComboEditor_TargetContrastCd.Value;
            this._prevSectionCode = "";
            this._prevCustomerCode = 0;
            this._prevEmployeeCode = "";
            this._prevSalesAreaCode = 0;
            this._prevSalesCode = 0;
            this._prevBLGroupCode = 0;
            this._prevBLGoodsCode = 0;
            this._prevSetArea = 10;
        }

        /// <summary>
        /// �O���b�h����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�������������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ClearGrid()
        {
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();
            this.tNedit_SalesTargetSale1.Clear();
            this.tNedit_SalesTargetProfit1.Clear();
            this.tNedit_SalesTargetCount1.Clear();

            for (int index = 0; index < 13; index++)
            {
                if (index != 12)
                {
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_MONTH].Value = this._yearMonthList[index].Month.ToString("00");
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_MONTH].Value = "�v";
                }
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            this._campaignTargetDicClone.Clear();
        }
        #endregion ��ʏ�����

        #region ��ʐݒ�
        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���T�C�Y��ݒ肵�܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_YearFrm.Size = new Size(43, 24);
            this.tEdit_SectionCode.Size = new Size(74, 24);
            this.tEdit_SectionName.Size = new Size(315, 24);
            this.tNedit_CustomerCode.Size = new Size(74, 24);
            this.tEdit_CustomerName.Size = new Size(315, 24);
            this.tEdit_EmployeeCode.Size = new Size(74, 24);
            this.tEdit_EmployeeName.Size = new Size(315, 24);
            this.tNedit_SalesAreaCode.Size = new Size(74, 24);
            this.tEdit_SalesAreaName.Size = new Size(315, 24);
            this.tNedit_BLGloupCode.Size = new Size(74, 24);
            this.tEdit_GroupName.Size = new Size(315, 24);
            this.tNedit_SalesCode.Size = new Size(74, 24);
            this.tEdit_SalesCodeName.Size = new Size(315, 24);
            this.tNedit_BLGoodsCode.Size = new Size(74, 24);
            this.tEdit_BLName.Size = new Size(315, 24);

            this.tNedit_SalesTargetSale.Size = new Size(139, 24);
            this.tNedit_SalesTargetProfit.Size = new Size(139, 24);
            this.tNedit_SalesTargetCount.Size = new Size(115, 24);

            this.tNedit_SalesTargetSale1.Size = new Size(139, 24);
            this.tNedit_SalesTargetProfit1.Size = new Size(139, 24);
            this.tNedit_SalesTargetCount1.Size = new Size(115, 24);

        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();

            // -----------------------------
            // �{�^���A�C�R���ݒ�
            // -----------------------------
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.CampaignGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesAreaGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesCodeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // -----------------------------
            // �O���b�h�ݒ�
            // -----------------------------
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMN_MONTH, typeof(string));
            dataTable.Columns.Add(COLUMN_SALESTARGET, typeof(string));
            dataTable.Columns.Add(COLUMN_PROFITTARGET, typeof(string));
            dataTable.Columns.Add(COLUMN_COUNTTARGET, typeof(string));

            for (int index = 0; index < 13; index++)
            {
                DataRow dataRow;
                dataRow = dataTable.NewRow();

                if (index != 12)
                {
                    dataRow[COLUMN_MONTH] = "";
                }
                else
                {
                    dataRow[COLUMN_MONTH] = "�v";
                }
                dataRow[COLUMN_SALESTARGET] = "";
                dataRow[COLUMN_PROFITTARGET] = "";
                dataRow[COLUMN_COUNTTARGET] = "";
                dataTable.Rows.Add(dataRow);
            }

            this.SalesTarget_uGrid.DataSource = dataTable;

            // �L���v�V����
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Caption = "��";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Caption = "����ڕW";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Caption = "�e���ڕW";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Caption = "���ʖڕW";

            // ��
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Width = 54;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Width = 137;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Width = 137;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Width = 114;

            // TextHAlign(�w�b�_�[)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.TextHAlign = HAlign.Center;

            // TextHAlign(�Z��)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.TextHAlign = HAlign.Right;

            // TextVAlign(�w�b�_�[)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.TextVAlign = VAlign.Middle;

            // TextVAlign(�Z��)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.TextVAlign = VAlign.Middle;

            // ForeColor(�w�b�_�[)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.ForeColorDisabled = Color.White;

            // ForeColor(�Z��)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.ForeColorDisabled = Color.Black;

            // ��ݒ�(��)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.ForeColorDisabled = Color.White;

            // �s�ݒ�(�v)
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Appearance.BackColorDisabled = Color.Gainsboro;

            // Activation
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellActivation = Activation.Disabled;
            this.SalesTarget_uGrid.Rows[12].Activation = Activation.Disabled;
        }
        #endregion ��ʐݒ�

        #region �R���g���[��Enabled����
        /// <summary>
        /// �ݒ�敪�����R���g���[��Enabled���䏈��
        /// </summary>
        /// <param name="targetContrastCd">�ݒ�敪�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �ݒ�敪�̒l�ɂ���ăR���g���[���̐�����s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void ChangeTargetContrastControl(int targetContrastCd)
        {
            switch (targetContrastCd)
            {
                case 10:    // ���_
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 30:    // ���_�{���Ӑ�
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;

                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 221:   // ���_�{�S����
                case 222:   // ���_�{�󒍎�
                case 223:   // ���_�{���s��
                    {
                        if (targetContrastCd == 221)
                        {
                            this.uLabel_Employee.Text = "�S����";
                        }
                        else if (targetContrastCd == 222)
                        {
                            this.uLabel_Employee.Text = "�󒍎�";
                        }
                        else
                        {
                            this.uLabel_Employee.Text = "���s��";
                        }
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tEdit_EmployeeCode.Enabled = true;
                        this.EmployeeGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        //this.tEdit_EmployeeCode.Clear();  // DEL K2011/07/05 
                        //this.tEdit_EmployeeName.Clear();  // DEL K2011/07/05 
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 32:    // ���_�{�n��
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SalesAreaCode.Enabled = true;
                        this.SalesAreaGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 50:    // ���_�{BL�R�[�h
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_BLGloupCode.Enabled = true;
                        this.GroupGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 44:    // ���_�{�̔��敪
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SalesCode.Enabled = true;
                        this.SalesCodeGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 60:    // ���_�{BL�O���[�v�R�[�h
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.BLGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();

                        break;
                    }
            }
        }

        /// <summary>
        /// �R���g���[��Enabled���䏈��
        /// </summary>
        /// <param name="editMode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �R���g���[����Enabled������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            switch (editMode)
            {
                case INSERT_MODE:
                    {
                        this.tComboEditor_TargetContrastCd.Enabled = true;

                        this.tNedit_SalesTargetSale.Enabled = true;
                        this.tNedit_SalesTargetProfit.Enabled = true;
                        this.tNedit_SalesTargetCount.Enabled = true;
                        this.tNedit_SalesTargetSale1.Enabled = true;
                        this.tNedit_SalesTargetProfit1.Enabled = true;
                        this.tNedit_SalesTargetCount1.Enabled = true;
                        this.tNedit_CampaignCode.Enabled = true;
                        this.CampaignGuide_Button.Enabled = true;

                        this.SalesTarget_uGrid.Enabled = true;

                        this._isClose = true;
                        this._isSave = true;
                        this._isNew = true;
                        this._isRevival = false;
                        this._isLogicalDelete = false;
                        this._isDelete = false;
                        this._isUndo = true;
                        this._isRenewal = true;
                        this._isGuide = true;

                        break;
                    }
                case UPDATE_MODE:
                    {

                        // �e�[�u���L�[���ڂ͓��͕s��
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //this.tComboEditor_TargetContrastCd.Enabled = false;
                        //this.tEdit_SectionCode.Enabled = false;
                        //this.SectionGuide_Button.Enabled = false;
                        //this.tNedit_CustomerCode.Enabled = false;
                        //this.CustomerGuide_Button.Enabled = false;
                        //this.tEdit_EmployeeCode.Enabled = false;
                        //this.EmployeeGuide_Button.Enabled = false;
                        //this.tNedit_SalesAreaCode.Enabled = false;
                        //this.SalesAreaGuide_Button.Enabled = false;
                        //this.tNedit_BLGloupCode.Enabled = false;
                        //this.GroupGuide_Button.Enabled = false;
                        //this.tNedit_SalesCode.Enabled = false;
                        //this.SalesCodeGuide_Button.Enabled = false;
                        //this.tNedit_CampaignCode.Enabled = false;
                        //this.CampaignGuide_Button.Enabled = false;

                        //this.tNedit_BLGoodsCode.Enabled = false;
                        //this.BLGuide_Button.Enabled = false;
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // ----- ADD K2011/07/05 ------- >>>>>>>>>
                        this.tComboEditor_TargetContrastCd.Enabled = true;
                        this.tNedit_CampaignCode.Enabled = true;
                        this.CampaignGuide_Button.Enabled = true;
                        ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                        // ----- ADD K2011/07/05 ------- <<<<<<<<<


                        this.tNedit_SalesTargetSale.Enabled = true;
                        this.tNedit_SalesTargetProfit.Enabled = true;
                        this.tNedit_SalesTargetCount.Enabled = true;
                        this.tNedit_SalesTargetSale1.Enabled = true;
                        this.tNedit_SalesTargetProfit1.Enabled = true;
                        this.tNedit_SalesTargetCount1.Enabled = true;

                        this.SalesTarget_uGrid.Enabled = true;

                        this._isClose = true;
                        this._isSave = true;
                        this._isNew = true;
                        this._isRevival = false;
                        this._isLogicalDelete = true;
                        this._isDelete = false;
                        this._isUndo = true;
                        this._isRenewal = true;
                        //this._isGuide = false;  // DEL K2011/07/05 
                        this._isGuide = true;   // ADD K2011/07/05 

                        break;
                    }
                case DELETE_MODE:
                    {
                        // �e�[�u���L�[���ڂ͓��͕s��
                        this.tComboEditor_TargetContrastCd.Enabled = false;
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_CampaignCode.Enabled = false;
                        this.CampaignGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;



                        this.tNedit_SalesTargetSale.Enabled = false;
                        this.tNedit_SalesTargetProfit.Enabled = false;
                        this.tNedit_SalesTargetCount.Enabled = false;
                        this.tNedit_SalesTargetSale1.Enabled = false;
                        this.tNedit_SalesTargetProfit1.Enabled = false;
                        this.tNedit_SalesTargetCount1.Enabled = false;

                        this.SalesTarget_uGrid.Enabled = false;

                        this._isClose = true;
                        this._isSave = false;
                        this._isNew = true;
                        this._isDelete = true;
                        this._isRevival = true;
                        this._isLogicalDelete = false;
                        this._isUndo = false;
                        this._isRenewal = false;
                        this._isGuide = false;

                        break;
                    }
            }

            SetToolButtonVisible(this);
        }
        #endregion �R���g���[��Enabled����


        #region �L�[�R���g���[��Disable����
        /// <summary>
        /// �L�[�R���g���[��Disable���䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�[�R���g���[����Disable������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetKeyControlDisable()
        {
            // �e�[�u���L�[���ڂ͓��͕s��
            this.tNedit_CampaignCode.Enabled = false;
            this.CampaignGuide_Button.Enabled = false;
            this.tComboEditor_TargetContrastCd.Enabled = false;
            this.tEdit_SectionCode.Enabled = false;
            this.SectionGuide_Button.Enabled = false;


            this.tNedit_CustomerCode.Enabled = false;
            this.CustomerGuide_Button.Enabled = false;
            this.tEdit_EmployeeCode.Enabled = false;
            this.EmployeeGuide_Button.Enabled = false;
            this.tNedit_SalesAreaCode.Enabled = false;
            this.SalesAreaGuide_Button.Enabled = false;
            this.tNedit_BLGloupCode.Enabled = false;
            this.GroupGuide_Button.Enabled = false;
            this.tNedit_BLGoodsCode.Enabled = false;
            this.BLGuide_Button.Enabled = false;
            this.tNedit_SalesCode.Enabled = false;
            this.SalesCodeGuide_Button.Enabled = false;

        }
        #endregion �L�[�R���g���[��Disable����


        #region Focus�ݒ�
        /// <summary>
        /// Next�R���g���[���擾����
        /// </summary>
        /// <param name="prevControl">���݃R���g���[��</param>
        /// <param name="nextControl">Next�R���g���[��</param>
        /// <remarks>
        /// <br>Note       : Next�R���g���[�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void GetNextControl(Control prevControl, out Control nextControl)
        {
            nextControl = null;

            if (prevControl == null)
            {
                return;
            }

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

            switch (prevControl.Name)
            {
                case "tNedit_CampaignCode":
                case "CampaignGuide_Button":
                    {
                        nextControl = this.tComboEditor_TargetContrastCd;
                        break;
                    }
                case "tEdit_SectionCode":
                case "SectionGuide_Button":
                    {
                        switch (targetContrastCd)
                        {
                            case 10:    // ���_
                                {
                                    nextControl = this.tNedit_SalesTargetSale;
                                    break;
                                }
                            case 30:    // ���_�{���Ӑ�
                                {
                                    nextControl = this.tNedit_CustomerCode;
                                    break;
                                }
                            case 221:   // ���_�{�S����
                            case 222:   // ���_�{�󒍎�
                            case 223:   // ���_�{���s��
                                {
                                    nextControl = this.tEdit_EmployeeCode;
                                    break;
                                }
                            case 32:    // ���_�{�n��
                                {
                                    nextControl = this.tNedit_SalesAreaCode;
                                    break;
                                }
                            case 50:    // ���_�{�O���[�v�R�[�h
                                {
                                    nextControl = this.tNedit_BLGloupCode;
                                    break;
                                }
                            case 60:    // ���_�{BL�R�[�h
                                {
                                    nextControl = this.tNedit_BLGoodsCode;
                                    break;
                                }
                            case 44:    // ���_�{�̔��敪
                                {
                                    nextControl = tNedit_SalesCode;
                                    break;
                                }
                        }
                        break;
                    }
                case "tNedit_CustomerCode":
                case "CustomerGuide_Button":
                case "tEdit_EmployeeCode":
                case "EmployeeGuide_Button":
                case "tNedit_SalesAreaCode":
                case "SalesAreaGuide_Button":
                case "tNedit_BLGloupCode":
                case "GroupGuide_Button":
                case "tNedit_BLGoodsCode":
                case "BLGuide_Button":
                case "tNedit_SalesCode":
                case "SalesCodeGuide_Button":

                    {
                        nextControl = this.tNedit_SalesTargetSale;
                        break;
                    }
            }
        }

        /// <summary>
        /// NextCell�ݒ菈��
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <param name="shiftFlg">ShiftKey�����t���O(True:���� Flase:��������)</param>
        /// <remarks>
        /// <br>Note       : NextCell��ݒ肵�܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetNextCell(ref ChangeFocusEventArgs e, bool shiftFlg)
        {
            int rowIndex;
            int columnIndex;

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                if (this.SalesTarget_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
                columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            if (shiftFlg == false)
            {
                if (rowIndex < 11)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (columnIndex < 3)
                    {
                        this.SalesTarget_uGrid.Rows[0].Cells[columnIndex + 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        if (this.Mode_Label.Text == INSERT_MODE)
                        {
                            this.tNedit_CampaignCode.Focus();
                        }
                        else
                        {
                            this.tNedit_SalesTargetSale.Focus();
                        }
                    }
                }
            }
            else
            {
                if (rowIndex > 0)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (columnIndex > 1)
                    {
                        this.SalesTarget_uGrid.Rows[11].Cells[columnIndex - 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.tNedit_SalesTargetCount1.Focus();
                    }
                }
            }
        }
        #endregion Focus�ݒ�

        #region �ۑ�����
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ��ۑ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SaveProc()
        {
            this.SalesTarget_uGrid.ActiveCell = null;

            // ���̓`�F�b�N
            bool bStatus = CheckScreenInput(true);
            if (!bStatus)
            {
                return -1;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = SaveCampaignTarget();

            return (status);
        }

        /// <summary>
        /// �ۑ�����(�L�����y�[���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ��ۑ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SaveCampaignTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ��ʏ��擾
            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            ScreenToCampaignTargetList(ref campaignTargetList);

            // �폜���X�g�擾
            List<CampaignTarget> deleteList = new List<CampaignTarget>();
            if (this._campaignTargetDicClone.ContainsKey("1"))
            {
                deleteList.Add(this._campaignTargetDicClone["1"]);
            }

            // �폜����
            if (deleteList.Count > 0)
            {
                status = this._campaignTargetAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        {
                            // �r������
                            ExclusiveTransaction(status);
                            return (status);
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           "SaveProc",
                           "�ۑ������Ɏ��s���܂����B",
                           status,
                           MessageBoxButtons.OK);
                            return (status);
                        }
                }
            }

            

            // �ۑ�����
            status = this._campaignTargetAcs.Write(ref campaignTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        this.Mode_Label.Text = INSERT_MODE;

                        if (this.Mode_Label.Text == INSERT_MODE)
                        {
                            // �R���g���[��Enabled����
                            SetControlEnabled(INSERT_MODE);
                            ComboChgClearScreen();
                            // �ݒ�敪�����R���g���[��Enabled����
                            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                            this.tEdit_SectionCode.Focus();
                        }

                        // �o�b�t�@�X�V
                        this._campaignTargetDicClone.Clear();
                        foreach (CampaignTarget campaignTarget in campaignTargetList)
                        {
                            for (int index = 1; index < 13; index++)
                            {
                                this._campaignTargetDicClone.Add(index.ToString(), campaignTarget);
                            }

                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "�ۑ������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion �ۑ�����

        #region ���ɖ߂�����
        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ�Ԃ����ɖ߂��܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int UndoProc()
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // ��ʏ�����
                ClearScreen();

                // �R���g���[��Enabled����
                SetControlEnabled(INSERT_MODE);

                // �ݒ�敪�����R���g���[��Enabled����
                ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);

                // �t�H�[�J�X�Z�b�g
                this.tNedit_CampaignCode.Focus();
            }
            else if (this.Mode_Label.Text == UPDATE_MODE)
            {
                CampaignTargetToScreen(this._campaignTargetDicClone);
            }
            // �{�^���c�[���L�������ݒ菈��
            this.SettingGuideButtonToolEnabled(this.ActiveControl);
            return 0;
        }
        #endregion ���ɖ߂�����

        #region �_���폜����
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ��_���폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int LogicalDeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = LogicalDeleteCampaignTarget();

            return (status);
        }

        /// <summary>
        /// �_���폜����(�L�����y�[���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ��_���폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int LogicalDeleteCampaignTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            if (this._campaignTargetDicClone.ContainsKey("1"))
            {
                campaignTargetList.Add(this._campaignTargetDicClone["1"]);
            }
            

            // �_���폜
            status = this._campaignTargetAcs.LogicalDelete(ref campaignTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = DELETE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(DELETE_MODE);

                        // �o�b�t�@�X�V
                        this._campaignTargetDicClone.Clear();
                        foreach (CampaignTarget campaignTarget in campaignTargetList)
                        {
                            for (int index = 1; index < 13; index++)
                            {
                                this._campaignTargetDicClone.Add(index.ToString(), campaignTarget);
                            }
                        }

                        // ��ʓW�J
                        CampaignTargetToScreen(this._campaignTargetDicClone);

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "�폜�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion �_���폜����

        #region �����폜����
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�𕨗��폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int DeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            if (this._campaignTargetDicClone.ContainsKey("1"))
            {
                campaignTargetList.Add(this._campaignTargetDicClone["1"]);
            }

            // �����폜
            status = this._campaignTargetAcs.Delete(campaignTargetList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = INSERT_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(INSERT_MODE);

                        // �ݒ�敪�����R���g���[��Enabled����
                        ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);

                        // ��ʃN���A
                        ClearScreen();

                        // �t�H�[�J�X�Z�b�g
                        this.tNedit_CampaignCode.Focus();

                        // �o�b�t�@�X�V
                        this._campaignTargetDicClone.Clear();

                        // �ݒ�敪�����R���g���[��Enabled����
                        ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DeleteProc",
                                       "���S�폜�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion �����폜����

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�𕜊����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int RevivalProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = RevivalCampaignTarget();

            return (status);
        }

        /// <summary>
        /// ��������(�L�����y�[���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�𕜊����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int RevivalCampaignTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            if (this._campaignTargetDicClone.ContainsKey("1"))
            {
                campaignTargetList.Add(this._campaignTargetDicClone["1"]);
            }

            // ����
            status = this._campaignTargetAcs.Revival(ref campaignTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(UPDATE_MODE);

                        // �o�b�t�@�X�V
                        this._campaignTargetDicClone.Clear();
                        foreach (CampaignTarget campaignTarget in campaignTargetList)
                        {
                            for (int index = 1; index < 13; index++)
                            {
                                this._campaignTargetDicClone.Add(index.ToString(), campaignTarget);
                            }
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "���������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        #endregion ��������



        #region �ŐV���擾����
        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ŐV�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int RenewalProc()
        {
            // �e��}�X�^�擾
            bool bStatus = ReadMaster();
            if (!bStatus)
            {
                return (-1);
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�ŐV�����擾���܂����B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

            return (0);
        }
        #endregion �ŐV���擾����

        #region �`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="beforeSaveFlg">�ۑ��O�t���O(True:�ۑ��O False:������)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CheckScreenInput(bool beforeSaveFlg)
        {
            bool bStatus;

            // ���̓`�F�b�N(����)
            bStatus = CheckCondition(beforeSaveFlg);
            if (!bStatus)
            {
                return (false);
            }

            // ----- DEL 2011/07/05 ---- >>>>
            //if (beforeSaveFlg == true)
            //{
            //    // ���̓`�F�b�N(�ڕW)
            //    bStatus = CheckSalesTarget();
            //    if (!bStatus)
            //    {
            //        return (false);
            //    }
            //}
            // ----- DEL 2011/07/05 ---- <<<<

            return (true);
        }

        /// <summary>
        /// ���̓`�F�b�N����(����)
        /// </summary>
        /// <param name="beforeSaveFlg">�ۑ��O�t���O(True:�ۑ��O False:������)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CheckCondition(bool beforeSaveFlg)
        {
            // �ꊇ�[���l��
            this.uiSetControl1.SettingAllControlsZeroPaddedText();

            string errMsg = "";
            Control control = null;

            try
            {
                if (this.tNedit_CampaignCode.GetInt() == 0)
                {
                    errMsg = "�L�����y�[���R�[�h����͂��ĉ������B";
                    control = this.tNedit_CampaignCode;
                    return (false);
                }
                int campaignCode = this.tNedit_CampaignCode.GetInt();
                if (this.Mode_Label.Text == INSERT_MODE && GetCampaignName(campaignCode) == "")
                {
                    errMsg = "�L�����y�[���R�[�h�����݂��܂���B";
                    control = this.tEdit_SectionCode;
                    return (false);
                }

                // �ݒ�敪
                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    default:
                        {
                            if (this.tEdit_SectionCode.DataText.Trim() == "")
                            {
                                errMsg = "���_����͂��Ă��������B";
                                control = this.tEdit_SectionCode;
                                return (false);
                            }

                            string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                            if (this.Mode_Label.Text == INSERT_MODE && GetSectionName(sectionCode) == "")
                            {
                                errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                control = this.tEdit_SectionCode;
                                return (false);
                            }

                            if (targetContrastCd == 30)
                            {
                                if (this.tNedit_CustomerCode.GetInt() == 0)
                                {
                                    errMsg = "���Ӑ����͂��Ă��������B";
                                    control = this.tNedit_CustomerCode;
                                    return (false);
                                }

                                int customerCode = this.tNedit_CustomerCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && !CheckCustomer(customerCode))
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_CustomerCode;
                                    return (false);
                                }
                            }
                            else if ((targetContrastCd == 221) || (targetContrastCd == 222) || (targetContrastCd == 223))
                            {
                                if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                                {
                                    if (targetContrastCd == 221)
                                    {
                                        errMsg = "�S���҂���͂��Ă��������B";
                                    }
                                    else if (targetContrastCd == 222)
                                    {
                                        errMsg = "�󒍎҂���͂��Ă��������B";
                                    }
                                    else
                                    {
                                        errMsg = "���s�҂���͂��Ă��������B";
                                    }
                                    control = this.tEdit_EmployeeCode;
                                    return (false);
                                }

                                string employeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                                if (this.Mode_Label.Text == INSERT_MODE && GetEmployeeName(employeeCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tEdit_EmployeeCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 32)
                            {
                                if (this.tNedit_SalesAreaCode.GetInt() == 0)
                                {
                                    errMsg = "�n�����͂��Ă��������B";
                                    control = this.tNedit_SalesAreaCode;
                                    return (false);
                                }

                                int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && GetSalesAreaName(salesAreaCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_SalesAreaCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 50)
                            {
                                if (this.tNedit_BLGloupCode.GetInt() == 0)
                                {
                                    errMsg = "�O���[�v�R�[�h����͂��Ă��������B";
                                    control = this.tNedit_BLGloupCode;
                                    return (false);
                                }

                                int groupCode = this.tNedit_BLGloupCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && GetBLGroupName(groupCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_BLGloupCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 44)
                            {
                                if (this.tNedit_SalesCode.GetInt() == 0)
                                {
                                    errMsg = "�̔��敪����͂��Ă��������B";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }

                                int salesCode = this.tNedit_SalesCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && GetSalesCodeName(salesCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 60)
                            {
                                if (this.tNedit_BLGoodsCode.GetInt() == 0)
                                {
                                    errMsg = "BL�R�[�h����͂��Ă��������B";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }

                                int blCode = this.tNedit_BLGoodsCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && GetBLGoodsName(blCode) == "")
                                {
                                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                    control = this.tNedit_BLGoodsCode;
                                    return (false);
                                }
                            }

                            break;
                        }
                }
            }
            finally
            {
                if ((errMsg.Length > 0) && (beforeSaveFlg == true))
                {
                    control.Focus();

                    this.SettingGuideButtonToolEnabled(control);

                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ���̓`�F�b�N����(�ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CheckSalesTarget()
        {
            string errMsg = "";

            try
            {
                bool inputFlg = false;
                for (int index = 0; index < 12; index++)
                {
                    // �Z���l�ϊ�
                    if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                        (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                        (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                    {
                        continue;
                    }

                    inputFlg = true;
                }

                if (inputFlg == false)
                {
                    errMsg = "�ڕW����͂��Ă��������B";
                    this.SalesTarget_uGrid.Focus();
                    this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ��ύX�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂪕ύX����Ă��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CompareInputScreen()
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                if (this.tNedit_CampaignCode.GetInt() != 0)
                {
                    return (false);
                }
                if ((int)this.tComboEditor_TargetContrastCd.Value != 10)
                {
                    return (false);
                }
                if (this.tEdit_SectionCode.DataText.Trim() != "")
                {
                    return (false);
                }
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tEdit_EmployeeCode.DataText.Trim() != "")
                {
                    return (false);
                }
                if (this.tNedit_SalesAreaCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_BLGloupCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_SalesCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_BLGoodsCode.GetInt() != 0)
                {
                    return (false);
                }
            }

            return CompareInputGrid();
        }

        /// <summary>
        /// �O���b�h���ύX�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h���ύX����Ă��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CompareInputGrid()
        {
            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            List<CampaignTarget> campaignTargetListCam = new List<CampaignTarget>();
            ScreenToCampaignTargetList(ref campaignTargetList);
            if (this._campaignTargetDicClone.Count != 0)
            {
                campaignTargetListCam.Add(this._campaignTargetDicClone["1"]);

                if (!((campaignTargetList[0].MonthlySalesTarget == campaignTargetListCam[0].MonthlySalesTarget)
                && (campaignTargetList[0].TermSalesTarget == campaignTargetListCam[0].TermSalesTarget)
                && (campaignTargetList[0].MonthlySalesTargetProfit == campaignTargetListCam[0].MonthlySalesTargetProfit)
                && (campaignTargetList[0].TermSalesTargetProfit == campaignTargetListCam[0].TermSalesTargetProfit)
                && (campaignTargetList[0].MonthlySalesTargetCount == campaignTargetListCam[0].MonthlySalesTargetCount)
                && (campaignTargetList[0].TermSalesTargetCount == campaignTargetListCam[0].TermSalesTargetCount)
                && (campaignTargetList[0].SalesTargetProfit1 == campaignTargetListCam[0].SalesTargetProfit1)
                && (campaignTargetList[0].SalesTargetProfit2 == campaignTargetListCam[0].SalesTargetProfit2)
                && (campaignTargetList[0].SalesTargetProfit3 == campaignTargetListCam[0].SalesTargetProfit3)
                && (campaignTargetList[0].SalesTargetProfit4 == campaignTargetListCam[0].SalesTargetProfit4)
                && (campaignTargetList[0].SalesTargetProfit5 == campaignTargetListCam[0].SalesTargetProfit5)
                && (campaignTargetList[0].SalesTargetProfit6 == campaignTargetListCam[0].SalesTargetProfit6)
                && (campaignTargetList[0].SalesTargetProfit7 == campaignTargetListCam[0].SalesTargetProfit7)
                && (campaignTargetList[0].SalesTargetProfit8 == campaignTargetListCam[0].SalesTargetProfit8)
                && (campaignTargetList[0].SalesTargetProfit9 == campaignTargetListCam[0].SalesTargetProfit9)
                && (campaignTargetList[0].SalesTargetProfit10 == campaignTargetListCam[0].SalesTargetProfit10)
                && (campaignTargetList[0].SalesTargetProfit11 == campaignTargetListCam[0].SalesTargetProfit11)
                && (campaignTargetList[0].SalesTargetProfit12 == campaignTargetListCam[0].SalesTargetProfit12)
                && (campaignTargetList[0].SalesTargetMoney1 == campaignTargetListCam[0].SalesTargetMoney1)
                && (campaignTargetList[0].SalesTargetMoney2 == campaignTargetListCam[0].SalesTargetMoney2)
                && (campaignTargetList[0].SalesTargetMoney3 == campaignTargetListCam[0].SalesTargetMoney3)
                && (campaignTargetList[0].SalesTargetMoney4 == campaignTargetListCam[0].SalesTargetMoney4)
                && (campaignTargetList[0].SalesTargetMoney5 == campaignTargetListCam[0].SalesTargetMoney5)
                && (campaignTargetList[0].SalesTargetMoney6 == campaignTargetListCam[0].SalesTargetMoney6)
                && (campaignTargetList[0].SalesTargetMoney7 == campaignTargetListCam[0].SalesTargetMoney7)
                && (campaignTargetList[0].SalesTargetMoney8 == campaignTargetListCam[0].SalesTargetMoney8)
                && (campaignTargetList[0].SalesTargetMoney9 == campaignTargetListCam[0].SalesTargetMoney9)
                && (campaignTargetList[0].SalesTargetMoney10 == campaignTargetListCam[0].SalesTargetMoney10)
                && (campaignTargetList[0].SalesTargetMoney11 == campaignTargetListCam[0].SalesTargetMoney11)
                && (campaignTargetList[0].SalesTargetMoney12 == campaignTargetListCam[0].SalesTargetMoney12)
                && (campaignTargetList[0].SalesTargetCount1 == campaignTargetListCam[0].SalesTargetCount1)
                && (campaignTargetList[0].SalesTargetCount2 == campaignTargetListCam[0].SalesTargetCount2)
                && (campaignTargetList[0].SalesTargetCount3 == campaignTargetListCam[0].SalesTargetCount3)
                && (campaignTargetList[0].SalesTargetCount4 == campaignTargetListCam[0].SalesTargetCount4)
                && (campaignTargetList[0].SalesTargetCount5 == campaignTargetListCam[0].SalesTargetCount5)
                && (campaignTargetList[0].SalesTargetCount6 == campaignTargetListCam[0].SalesTargetCount6)
                && (campaignTargetList[0].SalesTargetCount7 == campaignTargetListCam[0].SalesTargetCount7)
                && (campaignTargetList[0].SalesTargetCount8 == campaignTargetListCam[0].SalesTargetCount8)
                && (campaignTargetList[0].SalesTargetCount9 == campaignTargetListCam[0].SalesTargetCount9)
                && (campaignTargetList[0].SalesTargetCount10 == campaignTargetListCam[0].SalesTargetCount10)
                && (campaignTargetList[0].SalesTargetCount11 == campaignTargetListCam[0].SalesTargetCount11)
                && (campaignTargetList[0].SalesTargetCount12 == campaignTargetListCam[0].SalesTargetCount12)
                ))
                {
                    return (false);
                }
            }
            else
            {
                if (campaignTargetList.Count == 0)
                {
                    return (true);
                }
                if (!((campaignTargetList[0].MonthlySalesTarget == 0)
                && (campaignTargetList[0].TermSalesTarget == 0)
                && (campaignTargetList[0].MonthlySalesTargetProfit == 0)
                && (campaignTargetList[0].TermSalesTargetProfit == 0)
                && (campaignTargetList[0].MonthlySalesTargetCount == 0)
                && (campaignTargetList[0].TermSalesTargetCount == 0)
                && (campaignTargetList[0].SalesTargetProfit1 == 0)
                && (campaignTargetList[0].SalesTargetProfit2 == 0)
                && (campaignTargetList[0].SalesTargetProfit3 == 0)
                && (campaignTargetList[0].SalesTargetProfit4 == 0)
                && (campaignTargetList[0].SalesTargetProfit5 == 0)
                && (campaignTargetList[0].SalesTargetProfit6 == 0)
                && (campaignTargetList[0].SalesTargetProfit7 == 0)
                && (campaignTargetList[0].SalesTargetProfit8 == 0)
                && (campaignTargetList[0].SalesTargetProfit9 == 0)
                && (campaignTargetList[0].SalesTargetProfit10 == 0)
                && (campaignTargetList[0].SalesTargetProfit11 == 0)
                && (campaignTargetList[0].SalesTargetProfit12 == 0)
                && (campaignTargetList[0].SalesTargetMoney1 == 0)
                && (campaignTargetList[0].SalesTargetMoney2 == 0)
                && (campaignTargetList[0].SalesTargetMoney3 == 0)
                && (campaignTargetList[0].SalesTargetMoney4 == 0)
                && (campaignTargetList[0].SalesTargetMoney5 == 0)
                && (campaignTargetList[0].SalesTargetMoney6 == 0)
                && (campaignTargetList[0].SalesTargetMoney7 == 0)
                && (campaignTargetList[0].SalesTargetMoney8 == 0)
                && (campaignTargetList[0].SalesTargetMoney9 == 0)
                && (campaignTargetList[0].SalesTargetMoney10 == 0)
                && (campaignTargetList[0].SalesTargetMoney11 == 0)
                && (campaignTargetList[0].SalesTargetMoney12 == 0)
                && (campaignTargetList[0].SalesTargetCount1 == 0)
                && (campaignTargetList[0].SalesTargetCount2 == 0)
                && (campaignTargetList[0].SalesTargetCount3 == 0)
                && (campaignTargetList[0].SalesTargetCount4 == 0)
                && (campaignTargetList[0].SalesTargetCount5 == 0)
                && (campaignTargetList[0].SalesTargetCount6 == 0)
                && (campaignTargetList[0].SalesTargetCount7 == 0)
                && (campaignTargetList[0].SalesTargetCount8 == 0)
                && (campaignTargetList[0].SalesTargetCount9 == 0)
                && (campaignTargetList[0].SalesTargetCount10 == 0)
                && (campaignTargetList[0].SalesTargetCount11 == 0)
                && (campaignTargetList[0].SalesTargetCount12 == 0)
                ))
                {
                    return (false);
                }
            
            }

            return (true);
        }

        /// <summary>
        /// ���ۑ��`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ۑ��\�@False:�ۑ��s��)</returns>
        /// <remarks>
        /// <br>Note       : ���ۑ�����邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private bool CheckSaveConfirm()
        {
            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;


            if (this.tNedit_CampaignCode.GetInt() == 0)
            {
                return (false);
            }

            int campaignCode = this.tNedit_CampaignCode.GetInt();
            if (GetCampaignName(campaignCode) == "")
            {
                return (false);
            }


            if (this.tEdit_SectionCode.DataText.Trim() == "")
            {
                return (false);
            }

            string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            if (GetSectionName(sectionCode) == "")
            {
                return (false);
            }

            if (targetContrastCd == 30)
            {
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    return (false);
                }

                int customerCode = this.tNedit_CustomerCode.GetInt();
                if (!CheckCustomer(customerCode))
                {
                    return (false);
                }
            }
            else if ((targetContrastCd == 221) || (targetContrastCd == 222) || (targetContrastCd == 223))
            {
                if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                {
                    return (false);
                }

                string employeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                if (GetEmployeeName(employeeCode) == "")
                {
                    return (false);
                }
            }
            else if (targetContrastCd == 32)
            {
                if (this.tNedit_SalesAreaCode.GetInt() == 0)
                {
                    return (false);
                }

                int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                if (GetSalesAreaName(salesAreaCode) == "")
                {
                    return (false);
                }
            }
            else if (targetContrastCd == 50)
            {
                if (this.tNedit_BLGloupCode.GetInt() == 0)
                {
                    return (false);
                }

                int groupCode = this.tNedit_BLGloupCode.GetInt();
                if (GetBLGroupName(groupCode) == "")
                {
                    return (false);
                }
            }
            else if (targetContrastCd == 44)
            {
                if (this.tNedit_SalesCode.GetInt() == 0)
                {
                    return (false);
                }

                int salesCode = this.tNedit_SalesCode.GetInt();
                if (GetSalesCodeName(salesCode) == "")
                {
                    return (false);
                }
            }
            else if (targetContrastCd == 60)
            {
                if (this.tNedit_BLGoodsCode.GetInt() == 0)
                {
                    return (false);
                }

                int blCode = this.tNedit_BLGoodsCode.GetInt();
                if (GetBLGoodsName(blCode) == "")
                {
                    return (false);
                }
            }

            // �V�K�ŃL�[���ڂ��S�ē���OK�̏ꍇ�A�L�[�R���g���[����Disable����
            //SetKeyControlDisable();  // DEL K2011/07/05

            return (true);
        }
        #endregion �`�F�b�N����

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^���������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SearchProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            bool bStatus;

            // ���������`�F�b�N
            bStatus = CheckScreenInput(false);
            if (!bStatus)
            {
                return (-1);
            }

            status = SearchCampaignTarget();

            return (status);
        }

        /// <summary>
        /// ��������(�L�����y�[���ڕW)
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^���������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private int SearchCampaignTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ���������ݒ�
            CampaignTarget searchPara = new CampaignTarget();
            SetSearchCampaignTargetPara(ref searchPara);

            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();

            // ����
            status = this._campaignTargetAcs.Search(ref campaignTargetList, searchPara, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ݒ�
                        if (campaignTargetList[0].LogicalDeleteCode == 0)
                        {
                            this.Mode_Label.Text = UPDATE_MODE;

                            // �R���g���[��Enabled����
                            SetControlEnabled(UPDATE_MODE);
                        }
                        else
                        {
                            this.Mode_Label.Text = DELETE_MODE;

                            // �R���g���[��Enabled����
                            SetControlEnabled(DELETE_MODE);
                        }

                        // �o�b�t�@�X�V
                        this._campaignTargetDicClone.Clear();

                        foreach (CampaignTarget campaignTarget in campaignTargetList)
                        {
                            for (int index = 1; index < 13; index++)
                            {
                                this._campaignTargetDicClone.Add(index.ToString(), campaignTarget);
                            }
                        }

                        // ��ʓW�J
                        CampaignTargetToScreen(_campaignTargetDicClone);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                    {
                        this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "��ʌ��������Ɏ��s���܂����B", -1);
                        break;
                    }
                default:
                    {
                        this.Mode_Label.Text = INSERT_MODE;
                        // ----- ADD K2011/07/05 ------- >>>>>>>>>
                        ClearGrid();    
                        // �R���g���[��Enabled����
                        SetControlEnabled(INSERT_MODE);
                        // ----- ADD K2011/07/05 ------- <<<<<<<<<
                        break;
                    }
            }

            //this._searchFlg = true; // DEL K2011/07/05

            return (status);
        }
        #endregion ��������

        #region �O���b�h�֘A
        /// <summary>
        /// ���v�ڕW�擾����
        /// </summary>
        /// <param name="columnIndex">��C���f�b�N�X(2:����ڕW 3:�e���ڕW 4:���ʖڕW)</param>
        /// <returns>���v�ڕW</returns>
        /// <remarks>
        /// <br>Note       : ���v�ڕW���擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private double GetTotalTarget(int columnIndex)
        {
            double totalTarget = 0;

            if (columnIndex < 1)
            {
                return totalTarget;
            }

            for (int index = 0; index < 12; index++)
            {
                if ((this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value == DBNull.Value) ||
                    ((string)this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value == ""))
                {
                    continue;
                }

                totalTarget += double.Parse((string)this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value);
            }

            return totalTarget;
        }

        /// <summary>
        /// �Z���l�ϊ�����(�Z���l��Double�^)
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>�Z���l</returns>
        /// <remarks>
        /// <br>Note       : �Z���l��Double�^�ɕϊ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private double ChangeCellValue(object cellValue)
        {
            double target = 0;

            if ((cellValue != DBNull.Value) && (cellValue != null) && ((string)cellValue != ""))
            {
                target = double.Parse((string)cellValue);
            }

            return target;
        }

        /// <summary>
        /// �ϊ�����(�Z���l��string�^)
        /// </summary>
        /// <param name="tNedit">tNedit</param>
        /// <param name="columNum">columNum</param>
        /// <returns>�Z���l</returns>
        /// <remarks>
        /// <br>Note       : �l��Double�^�ɕϊ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ChangeValue(TNedit tNedit,int columNum)
        {
            double targetValue = 0;
            string retText;
            string targetText = tNedit.DataText;

            // �J���}�̂ݍ폜
            RemoveCommaPeriod(targetText, out retText, false);
            try
            {
                targetValue = double.Parse(retText);
                if (targetText.Length > columNum)
                {
                    tNedit.Value = "";
                }
                else
                {
                    // ���[�U�[�艿�̏ꍇ
                    tNedit.Value = targetValue.ToString(FORMAT_NUM);
                }
                
            }
            catch
            {
                tNedit.Value = "";
            }
        }
        #endregion �O���b�h�֘A

        #region ���������ݒ�
        /// <summary>
        /// ���������ݒ菈��(�L�����y�[���ڕW)
        /// </summary>
        /// <param name="searchPara">�L�����y�[���ڕW��������</param>
        /// <remarks>
        /// <br>Note       : ����������ݒ肵�܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetSearchCampaignTargetPara(ref CampaignTarget searchPara)
        {
            // ��ƃR�[�h
            searchPara.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            searchPara.SectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // �L�����y�[���R�[�h
            searchPara.CampaignCode = this.tNedit_CampaignCode.GetInt();

            // �ݒ�敪
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // ���_
                    {
                        searchPara.TargetContrastCd = 10;
                        break;
                    }
                case 30:    // ���_�{���Ӑ�
                    {
                        searchPara.TargetContrastCd = 30;
                        searchPara.CustomerCode = this.tNedit_CustomerCode.GetInt();
                        break;
                    }
                case 221:   // ���_�{�S����
                case 222:   // ���_�{�󒍎�
                case 223:   // ���_�{���s��
                    {
                        searchPara.TargetContrastCd = 22;
                        searchPara.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                        if (targetContrastCd == 221)
                        {
                            searchPara.EmployeeDivCd = 10;
                        }
                        if (targetContrastCd == 222)
                        {
                            searchPara.EmployeeDivCd = 20;
                        }
                        if (targetContrastCd == 223)
                        {
                            searchPara.EmployeeDivCd = 30;
                        }
                        break;
                    }
                case 32:    // ���_�{�n��
                    {
                        searchPara.TargetContrastCd = 32;
                        searchPara.SalesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                        break;
                    }
                case 50:    // ���_�{�O���[�v�R�[�h
                    {
                        searchPara.TargetContrastCd = 50;
                        searchPara.BLGroupCode = this.tNedit_BLGloupCode.GetInt();
                        break;
                    }
                case 44:    // ���_�{�̔��敪
                    {
                        searchPara.TargetContrastCd = 44;
                        searchPara.SalesCode = this.tNedit_SalesCode.GetInt();
                        break;
                    }
                case 60:    // ���_�{BL�R�[�h
                    {
                        searchPara.TargetContrastCd = 60;
                        searchPara.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        break;
                    }
            }

        }
        #endregion ���������ݒ�

        #region ��ʏ��擾
        /// <summary>
        /// ��ʏ��擾����(�L�����y�[���ڕW�ݒ�}�X�^)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 Redmine#22743 �ڕW�l���S��0�ł��o�^�\�̑Ή�</br>
        /// </remarks>
        private void ScreenToCampaignTargetList(ref List<CampaignTarget> campaignTargetList)
        {

            CampaignTarget campaignTarget = new CampaignTarget();
            //Boolean boo = false;  // DEL 2011/07/05
            // ���㌎�ԖڕW���z
            campaignTarget.MonthlySalesTarget = (long)ChangeCellValue(this.tNedit_SalesTargetSale.Value);
            // DEL 2011/07/05 --- >>>
            //if (!((long)ChangeCellValue(this.tNedit_SalesTargetSale.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // ������ԖڕW���z
            campaignTarget.TermSalesTarget = (long)ChangeCellValue(this.tNedit_SalesTargetSale1.Value);
            // DEL 2011/07/05 --- >>>
            //if (!((long)ChangeCellValue(this.tNedit_SalesTargetSale1.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // ���㌎�ԖڕW�e���z
            campaignTarget.MonthlySalesTargetProfit = (long)ChangeCellValue(this.tNedit_SalesTargetProfit.Value);
            // DEL 2011/07/05 --- >>>
            //if (!((long)ChangeCellValue(this.tNedit_SalesTargetProfit.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // ������ԖڕW�e���z
            campaignTarget.TermSalesTargetProfit = (long)ChangeCellValue(this.tNedit_SalesTargetProfit1.Value);
            // DEL 2011/07/05 --- >>>
            //if (!((long)ChangeCellValue(this.tNedit_SalesTargetProfit1.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // ���㌎�ԖڕW����
            campaignTarget.MonthlySalesTargetCount = ChangeCellValue(this.tNedit_SalesTargetCount.Value);
            // DEL 2011/07/05 --- >>>
            //if (!(ChangeCellValue(this.tNedit_SalesTargetCount.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // ������ԖڕW����
            campaignTarget.TermSalesTargetCount = ChangeCellValue(this.tNedit_SalesTargetCount1.Value);
            // DEL 2011/07/05 --- >>>
            //if (!(ChangeCellValue(this.tNedit_SalesTargetCount1.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<

            // ��ƃR�[�h
            campaignTarget.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            campaignTarget.SectionCode = this.tEdit_SectionCode.DataText.Trim();
            // �L�����y�[���R�[�h
            campaignTarget.CampaignCode = this.tNedit_CampaignCode.GetInt();

            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:
                    {
                        // �ڕW�Δ�敪
                        campaignTarget.TargetContrastCd = 10;
                        break;
                    }
                case 221:
                    {
                        // �ڕW�Δ�敪
                        campaignTarget.TargetContrastCd = 22;
                        // �]�ƈ��敪
                        campaignTarget.EmployeeDivCd = 10;
                        // �]�ƈ��R�[�h
                        campaignTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                        break;
                    }
                case 222:
                    {
                        // �ڕW�Δ�敪
                        campaignTarget.TargetContrastCd = 22;
                        // �]�ƈ��敪
                        campaignTarget.EmployeeDivCd = 20;
                        // �]�ƈ��R�[�h
                        campaignTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                        break;
                    }
                case 223:
                    {
                        // �ڕW�Δ�敪
                        campaignTarget.TargetContrastCd = 22;
                        // �]�ƈ��敪
                        campaignTarget.EmployeeDivCd = 30;
                        // �]�ƈ��R�[�h
                        campaignTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                        break;
                    }
                case 30:
                    {
                        // �ڕW�Δ�敪
                        campaignTarget.TargetContrastCd = 30;
                        campaignTarget.CustomerCode = this.tNedit_CustomerCode.GetInt();
                        break;
                    }
                case 32:
                    {
                        // �ڕW�Δ�敪
                        campaignTarget.TargetContrastCd = 32;
                        campaignTarget.SalesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                        break;
                    }
                case 44:
                    {
                        // �ڕW�Δ�敪
                        campaignTarget.TargetContrastCd = 44;
                        campaignTarget.SalesCode = this.tNedit_SalesCode.GetInt();
                        break;
                    }
                case 50:
                    {
                        // �ڕW�Δ�敪
                        campaignTarget.TargetContrastCd = 50;
                        campaignTarget.BLGroupCode = this.tNedit_BLGloupCode.GetInt();
                        break;
                    }
                case 60:
                    {
                        // �ڕW�Δ�敪
                        campaignTarget.TargetContrastCd = 60;
                        campaignTarget.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        break;
                    }
            }
            
            for (int index = 0; index < 12; index++)
            {
                string salesTargetMoney = "SalesTargetMoney";
                string salesTargetProfit = "SalesTargetProfit";
                string salesTargetCount = "SalesTargetCount";
                salesTargetMoney = salesTargetMoney + (this._yearMonthList[0].AddMonths(index).Month).ToString();
                salesTargetProfit = salesTargetProfit + (this._yearMonthList[0].AddMonths(index).Month).ToString();
                salesTargetCount = salesTargetCount + (this._yearMonthList[0].AddMonths(index).Month).ToString();
                // �Z���l�ϊ�
                if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                {
                    continue;
                }
                //boo = true; // DEL 2011/07/05
                Type type = campaignTarget.GetType();
                type.GetProperty(salesTargetMoney).SetValue(campaignTarget, (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value), null);
                // ����ڕW�e���z
                type.GetProperty(salesTargetProfit).SetValue(campaignTarget, (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value), null);
                // ����ڕW����
                type.GetProperty(salesTargetCount).SetValue(campaignTarget, (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value), null);
            }
            // UPD 2011/07/05 --- >>>
            //if (boo)
            //{
                campaignTargetList.Add(campaignTarget);
            //}
            // UPD 2011/07/05--- <<<
        }
        #endregion ��ʏ��擾

        #region ��ʓW�J
        /// <summary>
        /// ��ʓW�J����(�L�����y�[���ڕW)
        /// </summary>
        /// <param name="campaignTargetDic">�L�����y�[���ڕW���X�g</param>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void CampaignTargetToScreen(Dictionary<string, CampaignTarget> campaignTargetDic)
        {
            //------------------------------
            // �ڕW��񏉊���
            //------------------------------
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();
            this.tNedit_SalesTargetSale1.Clear();
            this.tNedit_SalesTargetProfit1.Clear();
            this.tNedit_SalesTargetCount1.Clear();

            CampaignTarget campaignTarget = campaignTargetDic["1"];
            // ���㌎�ԖڕW���z
            if (campaignTarget.MonthlySalesTarget != 0)
            {
                this.tNedit_SalesTargetSale.Value = campaignTarget.MonthlySalesTarget.ToString(FORMAT_NUM);
            }

            // ������ԖڕW���z
            if (campaignTarget.TermSalesTarget != 0)
            {
                this.tNedit_SalesTargetSale1.Value = campaignTarget.TermSalesTarget.ToString(FORMAT_NUM);
            }

            // ���㌎�ԖڕW�e���z
            if (campaignTarget.MonthlySalesTargetProfit != 0)
            {
                this.tNedit_SalesTargetProfit.Value = campaignTarget.MonthlySalesTargetProfit.ToString(FORMAT_NUM);
            }

            // ������ԖڕW�e���z
            if (campaignTarget.TermSalesTargetProfit != 0)
            {
                this.tNedit_SalesTargetProfit1.Value = campaignTarget.TermSalesTargetProfit.ToString(FORMAT_NUM);
            }

            // ���㌎�ԖڕW����
            if (campaignTarget.MonthlySalesTargetCount != 0)
            {
                this.tNedit_SalesTargetCount.Value = campaignTarget.MonthlySalesTargetCount.ToString(FORMAT_NUM);
            }
            
            // ������ԖڕW����
            if (campaignTarget.TermSalesTargetCount != 0)
            {
                this.tNedit_SalesTargetCount1.Value = campaignTarget.TermSalesTargetCount.ToString(FORMAT_NUM);
            }

            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            //------------------------------
            // �ڕW���ݒ�
            //------------------------------
            double totalMoney = 0;
            double totalProfit = 0;
            double totalCount = 0;
            for (int index = 0; index < 12; index++)
            {
                int index1 = index + 1;
                if (!campaignTargetDic.ContainsKey(index1.ToString()))
                {
                    continue;
                }
                campaignTarget = (CampaignTarget)campaignTargetDic[index1.ToString()];
                switch(this._yearMonthList[0].AddMonths(index).Month)
                {
                    case 1:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney1;
                            totalProfit += campaignTarget.SalesTargetProfit1;
                            totalCount += campaignTarget.SalesTargetCount1;
                            SetCellValue(campaignTarget.SalesTargetMoney1, campaignTarget.SalesTargetProfit1, campaignTarget.SalesTargetCount1,index);
                            break;
                        }
                    case 2:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney2;
                            totalProfit += campaignTarget.SalesTargetProfit2;
                            totalCount += campaignTarget.SalesTargetCount2;
                            SetCellValue(campaignTarget.SalesTargetMoney2, campaignTarget.SalesTargetProfit2, campaignTarget.SalesTargetCount2,index);
                            break;
                        }
                    case 3:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney3;
                            totalProfit += campaignTarget.SalesTargetProfit3;
                            totalCount += campaignTarget.SalesTargetCount3;
                            SetCellValue(campaignTarget.SalesTargetMoney3, campaignTarget.SalesTargetProfit3, campaignTarget.SalesTargetCount3, index);
                            break;
                        }
                    case 4:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney4;
                            totalProfit += campaignTarget.SalesTargetProfit4;
                            totalCount += campaignTarget.SalesTargetCount4;
                            SetCellValue(campaignTarget.SalesTargetMoney4, campaignTarget.SalesTargetProfit4, campaignTarget.SalesTargetCount4, index);
                            break;
                        }
                    case 5:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney5;
                            totalProfit += campaignTarget.SalesTargetProfit5;
                            totalCount += campaignTarget.SalesTargetCount5;
                            SetCellValue(campaignTarget.SalesTargetMoney5, campaignTarget.SalesTargetProfit5, campaignTarget.SalesTargetCount5, index);
                            break;
                        }
                    case 6:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney6;
                            totalProfit += campaignTarget.SalesTargetProfit6;
                            totalCount += campaignTarget.SalesTargetCount6;
                            SetCellValue(campaignTarget.SalesTargetMoney6, campaignTarget.SalesTargetProfit6, campaignTarget.SalesTargetCount6, index);
                            break;
                        }
                    case 7:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney7;
                            totalProfit += campaignTarget.SalesTargetProfit7;
                            totalCount += campaignTarget.SalesTargetCount7;
                            SetCellValue(campaignTarget.SalesTargetMoney7, campaignTarget.SalesTargetProfit7, campaignTarget.SalesTargetCount7, index);
                            break;
                        }
                    case 8:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney8;
                            totalProfit += campaignTarget.SalesTargetProfit8;
                            totalCount += campaignTarget.SalesTargetCount8;
                            SetCellValue(campaignTarget.SalesTargetMoney8, campaignTarget.SalesTargetProfit8, campaignTarget.SalesTargetCount8, index);
                            break;
                        }
                    case 9:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney9;
                            totalProfit += campaignTarget.SalesTargetProfit9;
                            totalCount += campaignTarget.SalesTargetCount9;
                            SetCellValue(campaignTarget.SalesTargetMoney9, campaignTarget.SalesTargetProfit9, campaignTarget.SalesTargetCount9, index);
                            break;
                        }
                    case 10:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney10;
                            totalProfit += campaignTarget.SalesTargetProfit10;
                            totalCount += campaignTarget.SalesTargetCount10;
                            SetCellValue(campaignTarget.SalesTargetMoney10, campaignTarget.SalesTargetProfit10, campaignTarget.SalesTargetCount10, index);
                            break;
                        }
                    case 11:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney11;
                            totalProfit += campaignTarget.SalesTargetProfit11;
                            totalCount += campaignTarget.SalesTargetCount11;
                            SetCellValue(campaignTarget.SalesTargetMoney11, campaignTarget.SalesTargetProfit11, campaignTarget.SalesTargetCount11, index);
                            break;
                        }
                    case 12:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney12;
                            totalProfit += campaignTarget.SalesTargetProfit12;
                            totalCount += campaignTarget.SalesTargetCount12;
                            SetCellValue(campaignTarget.SalesTargetMoney12, campaignTarget.SalesTargetProfit12, campaignTarget.SalesTargetCount12, index);
                            break;
                        }
                }

            }

            //------------------------------
            // ���v�s�ݒ�
            //------------------------------
            if (totalMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = totalMoney.ToString(FORMAT_NUM);
            }
            if (totalProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = totalProfit.ToString(FORMAT_NUM);
            }
            if (totalCount != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = totalCount.ToString(FORMAT_NUM);
            }
        }
        /// <summary>
        /// ��ʓW�J����(�L�����y�[���ڕW)1
        /// </summary>
        /// <param name="salesTargetMoney">����ڕW���z</param>
        /// <param name="salesTargetProfit">����ڕW�e���z</param>
        /// <param name="salesTargetCount">����ڕW����</param>
        /// <param name="index"></param>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW)���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
       private void SetCellValue(double salesTargetMoney, double salesTargetProfit, double salesTargetCount, int index)
        {

            if (salesTargetMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = salesTargetMoney.ToString(FORMAT_NUM);
            }
            if (salesTargetProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = salesTargetProfit.ToString(FORMAT_NUM);
            }
            if (salesTargetCount != 0)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = salesTargetCount.ToString(FORMAT_NUM);
            }
        }
         #endregion ��ʓW�J

        #region �r����
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �r��������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
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
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // ���Ɏg�p����Ă��܂�
                        string campaignCode = this.tNedit_CampaignCode.DataText.Trim();
                        errMsg = "����" + campaignCode + "�����Ɏg�p����Ă��܂��B";
                        break;
                    }
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           errMsg,
                           status,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
        }
        #endregion �r����


        /// <summary>
        /// �u�K�C�h�v����
        /// </summary>
        public void ExecuteGuide()
        {
            switch (this._guideKey)
            {

                // �ڕW�ݒ�
                case ctGUIDE_NAME_CampaignGuide:
                    {
                        this.CampaignGuide_Button_Click(this.CampaignGuide_Button, new EventArgs());
                        break;
                    }
                // ���_ 
                case ctGUIDE_NAME_Section:
                    {
                        this.SectionGuide_Button_Click(this.SectionGuide_Button, new EventArgs());
                        break;
                    }
                // ���Ӑ�
                case ctGUIDE_NAME_CustomerCode:
                    {
                        this.CustomerGuide_Button_Click(this.CustomerGuide_Button, new EventArgs());
                        break;
                    }
                // �S����
                case ctGUIDE_NAME_EmployeeCode:
                    {
                        this.EmployeeGuide_Button_Click(this.EmployeeGuide_Button, new EventArgs());
                        break;
                    }
                // �n��
                case ctGUIDE_NAME_SalesAreaCode:
                    {
                        this.SalesAreaGuide_Button_Click(this.SalesAreaGuide_Button, new EventArgs());
                        break;
                    }
                // �O���[�v�R�[�h
                case ctGUIDE_NAME_SalesGroupCode:
                    {
                        this.GroupGuide_Button_Click(this.GroupGuide_Button, new EventArgs());
                        break;
                    }
                // BL�R�[�h
                case ctGUIDE_NAME_BLCode:
                    {
                        this.BLGuide_Button_Click(this.BLGuide_Button, new EventArgs());
                        break;
                    }
                // �̔��敪
                case ctGUIDE_NAME_SalesCode:
                    {
                        this.SalesCodeGuide_Button_Click(this.SalesCodeGuide_Button, new EventArgs());
                        break;
                    }
            }
        }

        /// <summary>
        /// �{�^���c�[���L�������ݒ菈��
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        /// <remarks>
        /// <br>Note		: �{�^���c�[���L�������ݒ菈��</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SettingGuideButtonToolEnabled(Control nextControl)
        {
            if (nextControl == null) return;

            Control targetControl = nextControl;
            if (nextControl.Parent != null)
            {
                if ((nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit))
                {
                    targetControl = nextControl.Parent;
                }
            }

            if (targetControl.Name == ctGUIDE_NAME_CampaignGuide
                || targetControl.Name == ctGUIDE_NAME_Section
                || targetControl.Name == ctGUIDE_NAME_CustomerCode
                || targetControl.Name == ctGUIDE_NAME_EmployeeCode
                || targetControl.Name == ctGUIDE_NAME_SalesAreaCode
                || targetControl.Name == ctGUIDE_NAME_SalesGroupCode
                || targetControl.Name == ctGUIDE_NAME_BLCode
                || targetControl.Name == ctGUIDE_NAME_SalesCode)
            {
                this._guideKey = targetControl.Name;
                this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.Enabled = true;
            }
            else
            {
                this._guideKey = string.Empty;
                this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.Enabled = false;
            }
        }


         #region ���b�Z�[�W�{�b�N�X�\

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                       // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         ASSEMBLY_ID, 		  �@�@			// �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._campaignTargetAcs,			// �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }

         #endregion ���b�Z�[�W�{�b�N�X�\��

        #region ������ҏW��

        /// <summary>
        /// �J���}�E�s���I�h�폜����
        /// </summary>
        /// <param name="targetText">�J���}�E�s���I�h�폜�O�e�L�X�g</param>
        /// <param name="retText">�J���}�E�s���I�h�폜�ς݃e�L�X�g</param>
        /// <param name="periodDelFlg">�s���I�h�폜�t���O(True:�J���}�E�s���I�h�폜  False:�J���}�폜)</param>
        /// <remarks>
        /// <br>Note		: �Ώۂ̃e�L�X�g����J���}�E�s���I�h���폜���܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            // �Z���l�ҏW�p�ɃJ���}�E�s���I�h�폜
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // �J���}�E�s���I�h�폜
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // �J���}�̂ݍ폜
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// �����_�擾����
        /// </summary>
        /// <param name="targetText">�`�F�b�N�Ώۃe�L�X�g</param>
        /// <param name="retText">���������e�L�X�g</param>
        /// <remarks>
        /// <br>Note		: �Ώۂ̃e�L�X�g���珬�������݂̂�Ԃ��܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void GetDecimal(string targetText, out string retText)
        {
            retText = "";

            for (int i = targetText.IndexOf(".") + 1; i < targetText.Length; i++)
            {
                retText += targetText[i].ToString();
            }
        }

        #endregion ������ҏW����

        #endregion �� Private Methods


        #region �� Control Event

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : Form_Load���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void PMKHN09651UA_Load(object sender, EventArgs e)
        {
            // ��ʏ����ݒ�
            SetScreenInitialSetting();

            // ��ʏ���������
            ClearScreen();

            // �����ݒ菈��
            InitialSetting();

            // �t�H�[�J�X�ݒ�
            this.timer_SetFocus.Enabled = true;
        }

         #region �K�C�h�{�^����
        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �L�����y�[���R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void CampaignGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // �K�C�h�N��
                int status = _campaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    // ���ʃZ�b�g
                    this.tNedit_CampaignCode.SetInt(campaignSt.CampaignCode);
                    this.tEdit_CampaignName.Text = campaignSt.CampaignName;
                    this.tNedit_YearFrm.SetInt(campaignSt.ApplyStaDate.Year);
                    this.tNedit_MonthFrm.SetInt(campaignSt.ApplyStaDate.Month);
                    this.tNedit_DayFrm.SetInt(campaignSt.ApplyStaDate.Day);
                    this.tNedit_YearTo.SetInt(campaignSt.ApplyEndDate.Year);
                    this.tNedit_MonthTo.SetInt(campaignSt.ApplyEndDate.Month);
                    this.tNedit_DayTo.SetInt(campaignSt.ApplyEndDate.Day);
                    //this._prevCampaignCode = campaignSt.CampaignCode;
                    Control nextControl;
                    if (CheckSaveConfirm() == false)
                    {
                        this._prevCampaignCode = campaignSt.CampaignCode;
                        GetNextControl(this.CampaignGuide_Button, out nextControl);
                        nextControl.Focus();
                        this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        return;
                    }
                    else
                    {
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // �ۑ�����
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevCampaignCode = campaignSt.CampaignCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_CampaignCode.Value = this._prevCampaignCode;
                        //                this.tEdit_CampaignName.DataText = GetCampaignName(this._prevCampaignCode);
                        //                return;
                        //            }
                        //    }
                        //}

                        if (campaignSt.CampaignCode != this._prevCampaignCode)
                        {
                            // ����
                            status = SearchProc();
                            if (status != 0)
                            {
                                ClearGrid();
                                this._prevCampaignCode = campaignSt.CampaignCode;
                            }
                            else
                            {
                                this._prevCampaignCode = campaignSt.CampaignCode;
                            }
                        }


                    }
                    // �t�H�[�J�X�ݒ�
                    GetNextControl(this.CampaignGuide_Button, out nextControl);
                    nextControl.Focus();
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
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
        /// <br>Note       : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // ���_�R�[�h�ݒ�
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // ���_���ݒ�
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                    {
                        // ����
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();

                            // �L�����y�[���R�[�h�擾
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                          
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    Control nextControl;
                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        // �t�H�[�J�X�ݒ�
                       
                        GetNextControl(this.SectionGuide_Button, out nextControl);
                        nextControl.Focus();
                        this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // �ۑ�����
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tEdit_SectionCode.DataText = this._prevSectionCode;
                        //                this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        }
                        else
                        {
                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    GetNextControl(this.SectionGuide_Button, out nextControl);
                    nextControl.Focus();
                    // �{�^���c�[���L�������ݒ菈��
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
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
        /// <br>Note       : ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this._customerFlag = 0;

                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                int status;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if ((int)this.tComboEditor_TargetContrastCd.Value == 30)
                {
                    // ����
                    status = SearchProc();
                    //this._searchFlg = false;  // DEL K2011/07/05
                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                    {
                        GetCampaignStList();

                        if (this._customerFlag == 1)
                        {
                            // �Y���Ȃ�
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                            this.tNedit_CampaignCode.Focus();
                            this.tNedit_CampaignCode.Text = "";
                            this.tEdit_CampaignName.Clear();
                            this.tNedit_YearFrm.Clear();
                            this.tNedit_MonthFrm.Clear();
                            this.tNedit_DayFrm.Clear();
                            this.tNedit_YearTo.Clear();
                            this.tNedit_MonthTo.Clear();
                            this.tNedit_DayTo.Clear();
                            this._prevCampaignCode = 0;
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                            return;
                        }

                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                       
                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                        {
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                            this.tNedit_CampaignCode.Focus();
                            this.tNedit_CampaignCode.Text = "";
                            this.tEdit_CampaignName.Clear();
                            this.tNedit_YearFrm.Clear();
                            this.tNedit_MonthFrm.Clear();
                            this.tNedit_DayFrm.Clear();
                            this.tNedit_YearTo.Clear();
                            this.tNedit_MonthTo.Clear();
                            this.tNedit_DayTo.Clear();
                            this._prevCampaignCode = 0;
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                            return;
                        }
                    }
                }

                if (this._cusotmerGuideSelected == true)
                {
                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.CustomerGuide_Button, out nextControl);
                    nextControl.Focus();
                    // �{�^���c�[���L�������ݒ菈��
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }

                // ����
                status = SearchProc();
                if (status != 0)
                {
                    ClearGrid();
                    if (this.tNedit_CustomerCode.Text.ToString() != "")
                    {
                        this._prevCustomerCode = Convert.ToInt32(this.tNedit_CustomerCode.Text.ToString());
                    }
                    else
                    {
                        this._prevCustomerCode = 0;
                    }
                }
                else
                {
                    if (this.tNedit_CustomerCode.Text.ToString() != "")
                    {
                        this._prevCustomerCode = Convert.ToInt32(this.tNedit_CustomerCode.Text.ToString());
                    }
                    else
                    {
                        this._prevCustomerCode = 0;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            int status;

            // ���Ӑ�R�[�h�ݒ�
            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            // ���Ӑ於�ݒ�
            this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();


            if ((int)this.tComboEditor_TargetContrastCd.Value == 30)
            {
                // ����
                status = SearchProc();
                //this._searchFlg = false;  // DEL K2011/07/05
                if (this.tNedit_CampaignCode.Text.ToString() != "")
                {
                    GetCampaignStList();

                    // �L�����y�[���R�[�h�擾
                    int campaignCode = this.tNedit_CampaignCode.GetInt();
                    if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                    {
                        this._customerFlag = 1;
                        return;
                    }

                    int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                 
                    if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                    {
                        return;
                    }
                }
            }


            if (CheckSaveConfirm() == false)
            {
                this._prevCustomerCode = customerSearchRet.CustomerCode;
                return;
            }
            else
            {
                //if (this._searchFlg)
                //{
                //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                //                                        "",
                //                                        0,
                //                                        MessageBoxButtons.YesNoCancel,
                //                                        MessageBoxDefaultButton.Button2);
                //    switch (result)
                //    {
                //        case DialogResult.Yes:
                //            {
                //                // �ۑ�����
                //                status = SaveProc();
                //                if (status != 0)
                //                {
                //                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                //                    return;
                //                }

                //                break;
                //            }
                //        case DialogResult.No:
                //            {
                //                break;
                //            }
                //        case DialogResult.Cancel:
                //            {
                //                this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                //                this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                //                return;
                //            }
                //    }
                //}

                // ����
                status = SearchProc();
                if (status != 0)
                {
                    ClearGrid();
                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                }
                else
                {
                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                }
            }

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �]�ƈ��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void EmployeeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;

                int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, false, out employee);
                if (status == 0)
                {
                    // �]�ƈ��R�[�h�ݒ�
                    this.tEdit_EmployeeCode.DataText = employee.EmployeeCode.Trim();
                    // �]�ƈ����ݒ�
                    this.tEdit_EmployeeName.DataText = employee.Name.Trim();
                    if ((int)this.tComboEditor_TargetContrastCd.Value == 221
                        || (int)this.tComboEditor_TargetContrastCd.Value == 222
                        || (int)this.tComboEditor_TargetContrastCd.Value == 223)
                    {
                        // ����
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();

                            // �L�����y�[���R�[�h�擾
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                         
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // �ۑ�����
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                        //                this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        }
                        else
                        {
                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.EmployeeGuide_Button, out nextControl);
                    nextControl.Focus();
                    // �{�^���c�[���L�������ݒ菈��
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
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
        /// <br>Note       : �n��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void SalesAreaGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

                if (status == 0)
                {
                    // �n��R�[�h�ݒ�
                    this.tNedit_SalesAreaCode.SetInt(userGdBd.GuideCode);
                    // �n�於�ݒ�
                    this.tEdit_SalesAreaName.DataText = userGdBd.GuideName.Trim();

                    if ((int)this.tComboEditor_TargetContrastCd.Value == 32)
                    {
                        // ����
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();
                            // �L�����y�[���R�[�h�擾
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                      
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSalesAreaCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // �ۑ�����
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevSalesAreaCode = userGdBd.GuideCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                        //                this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSalesAreaCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevSalesAreaCode = userGdBd.GuideCode;
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.SalesAreaGuide_Button, out nextControl);
                    nextControl.Focus();
                    // �{�^���c�[���L�������ݒ菈��
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(BLGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �a�k�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void BLGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGoodsCdUMnt blGoodsCdUMnt = null;

                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    // BL�R�[�h�ݒ�
                    this.tNedit_BLGoodsCode.Value = blGoodsCdUMnt.BLGoodsCode;
                    // BL���ݒ�
                    this.tEdit_BLName.DataText = blGoodsCdUMnt.BLGoodsFullName.Trim();

                    if ((int)this.tComboEditor_TargetContrastCd.Value == 60)
                    {
                        // ����
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();

                            // �L�����y�[���R�[�h�擾
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                          
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // �ۑ�����
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this.tNedit_BLGoodsCode.Value= blGoodsCdUMnt.BLGoodsCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_BLGoodsCode.Value = this._prevBLGoodsCode;
                        //                this.tEdit_BLName.DataText = GetBLGoodsName(this._prevBLGoodsCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        }
                        else
                        {
                            this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        }
                    }
                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.BLGuide_Button, out nextControl);
                    nextControl.Focus();
                    // �{�^���c�[���L�������ݒ菈��
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(GroupGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �O���[�v�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void GroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGroupU blGroupU = new BLGroupU();

                int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    // BL�O���[�v�R�[�h�ݒ�
                    this.tNedit_BLGloupCode.Value = blGroupU.BLGroupCode;
                    // BL�O���[�v���ݒ�
                    this.tEdit_GroupName.DataText = GetBLGroupName(blGroupU.BLGroupCode);
                    if ((int)this.tComboEditor_TargetContrastCd.Value == 50)
                    {
                        // ����
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();
                            // �L�����y�[���R�[�h�擾
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevBLGroupCode = blGroupU.BLGroupCode;
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // �ۑ�����
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this.tNedit_BLGloupCode.Value = blGroupU.BLGroupCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_BLGloupCode.Value = this._prevBLGroupCode;
                        //                this.tEdit_GroupName.DataText = GetBLGroupName(this._prevBLGroupCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevBLGoodsCode = blGroupU.BLGroupCode;
                        }
                        else
                        {
                            this._prevBLGoodsCode = blGroupU.BLGroupCode;
                        }
                    }
                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.GroupGuide_Button, out nextControl);
                    nextControl.Focus();
                    // �{�^���c�[���L�������ݒ菈��
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
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
        /// <br>Note       : �̔��敪�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void SalesCodeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);
                if (status == 0)
                {
                    // �̔��敪�R�[�h�ݒ�
                    this.tNedit_SalesCode.SetInt(userGdBd.GuideCode);
                    // �̔��敪���ݒ�
                    this.tEdit_SalesCodeName.DataText = userGdBd.GuideName.Trim();

                    if ((int)this.tComboEditor_TargetContrastCd.Value == 44)
                    {
                        // ����
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();

                            // �L�����y�[���R�[�h�擾
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                          
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSalesCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // �ۑ�����
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevSalesCode = userGdBd.GuideCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                        //                this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // ����
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSalesCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevSalesCode = userGdBd.GuideCode;
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    Control nextControl;
                    GetNextControl(this.SalesCodeGuide_Button, out nextControl);
                    nextControl.Focus();
                    // �{�^���c�[���L�������ݒ菈��
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
         #endregion �K�C�h�{�^������

        #region �O���b�h��

        /// <summary>
        /// AfterEnterEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z�����ҏW���[�h�ɂȂ������ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            // �{�^���c�[���L�������ݒ菈��
            this.SettingGuideButtonToolEnabled(this.ActiveControl);
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            if ((this.SalesTarget_uGrid.ActiveCell.Value == DBNull.Value) || 
                ((string)this.SalesTarget_uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            string retText;
            string targetText = (string)this.SalesTarget_uGrid.ActiveCell.Value;

            // �J���}�̂ݍ폜
            RemoveCommaPeriod(targetText, out retText, false);

            this.SalesTarget_uGrid.ActiveCell.Value = retText;
            this.SalesTarget_uGrid.ActiveCell.SelStart = 0;
            this.SalesTarget_uGrid.ActiveCell.SelLength = retText.Length;
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���̕ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if ((this.SalesTarget_uGrid.ActiveCell.Value != DBNull.Value) &&
                ((string)this.SalesTarget_uGrid.ActiveCell.Value != ""))
            {
                string retText;
                string targetText = (string)this.SalesTarget_uGrid.ActiveCell.Value;

                // �J���}�̂ݍ폜
                RemoveCommaPeriod(targetText, out retText, false);
                double targetValue;
                try
                {
                   targetValue = double.Parse(retText);
                   if (targetText.Length > 13)
                   {
                       this.SalesTarget_uGrid.ActiveCell.Value = "";
                   }
                   else
                   {
                       // ���[�U�[�艿�̏ꍇ
                       this.SalesTarget_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM);
                   }
                   
                }
                catch
                {
                    this.SalesTarget_uGrid.ActiveCell.Value = "";
                }  
            }

            // ���v�ڕW�擾
            double totalTarget = GetTotalTarget(columnIndex);

            if (totalTarget == 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[columnIndex].Value = "";
            }
            else
            {
                this.SalesTarget_uGrid.Rows[12].Cells[columnIndex].Value = totalTarget.ToString(FORMAT_NUM1);
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���A�N�e�B�u��ԂŃL�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                if (this.SalesTarget_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
                columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            if (columnIndex == 1)
                            {
                                this.tNedit_SalesTargetSale1.Focus();
                            }
                            else if (columnIndex == 2)
                            {
                                this.tNedit_SalesTargetProfit1.Focus();
                            }
                            else
                            {
                                this.tNedit_SalesTargetCount1.Focus();
                            }
                        }
                        else
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex < 11)
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (this.SalesTarget_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.SalesTarget_uGrid.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;

                                if (columnIndex <= 1)
                                {
                                    int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                                    if (targetContrastCd == 45)
                                    {
                                        this.BLGuide_Button.Focus();
                                    }
                                    else
                                    {
                                        this.SectionGuide_Button.Focus();
                                    }
                                }
                                else
                                {
                                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.SalesTarget_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.SalesTarget_uGrid.ActiveCell.SelStart >= this.SalesTarget_uGrid.ActiveCell.Text.Length)
                            {
                                e.Handled = true;

                                if (columnIndex != 3)
                                {
                                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���A�N�e�B�u��ԂŃL�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if (columnIndex < 1)
            {
                return;
            }

            // �uBackspace�v�L�[�������ꂽ��
            if ((byte)e.KeyChar == (byte)'\b')
            {
                return;
            }

            // �ΏۃZ���̃e�L�X�g�擾
            string retText;
            string targetText = this.SalesTarget_uGrid.ActiveCell.Text;
            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);

            // �e�s�̓��͉\������ݒ肵�܂�
            switch (columnIndex)
            {

                // ����ڕW�A�e���ڕW ���ʖڕW
                // 11
                case 1:
                case 2:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������9��������������͕s��
                        if (retText.Length == 10)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // �u,�v�͓��͉�
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������9��������������͕s��
                        if (retText.Length == 8)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // �u,�v�͓��͉�
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_Leave(object sender, EventArgs e)
        {
            this.SalesTarget_uGrid.ActiveCell = null;
            this.SalesTarget_uGrid.ActiveRow = null;
        }
        #endregion �O���b�h�֘A

        /// <summary>
        /// SelectionChangeCommitted �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ݒ�敪�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tComboEditor_TargetContrastCd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.tComboEditor_TargetContrastCd.Value == null)
            {
                return;
            }

            ComboChgClearScreen();
            // �ݒ�敪�����R���g���[��Enabled����
            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);

            this._prevSetArea = (int)this.tComboEditor_TargetContrastCd.Value;
        }

        private void AfterChangeTargetContrastCd()
        {
            int status;

            // ----- DEL K2011/07/05 ------- >>>>>>>>>
            //if (this._searchFlg)
            //{
            //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
            //                                        "",
            //                                        0,
            //                                        MessageBoxButtons.YesNoCancel,
            //                                        MessageBoxDefaultButton.Button2);
            //    switch (result)
            //    {
            //        case DialogResult.Yes:
            //            {
            //                // �ۑ�����
            //                status = SaveProc();
            //                if (status != 0)
            //                {
            //                    this._prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            //                    return;
            //                }

            //                break;
            //            }
            //        case DialogResult.No:
            //            {
            //                break;
            //            }
            //        case DialogResult.Cancel:
            //            {
            //                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted -= tComboEditor_TargetContrastCd_SelectionChangeCommitted;
            //                this.tComboEditor_TargetContrastCd.Value = this._prevTargetContrastCd;
            //                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted += tComboEditor_TargetContrastCd_SelectionChangeCommitted;
            //                return;
            //            }
            //    }
            //}
            // ----- DEL K2011/07/05 ------- <<<<<<<<<

            //����
           status = SearchProc();
            if (status != 0)
            {
                int prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                ClearScreen();
                this._prevTargetContrastCd = prevTargetContrastCd;
                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted -= tComboEditor_TargetContrastCd_SelectionChangeCommitted;
                this.tComboEditor_TargetContrastCd.Value = prevTargetContrastCd;
                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted += tComboEditor_TargetContrastCd_SelectionChangeCommitted;
            }
            else
            {
                this._prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            }

            this.Top_Panel.Focus();
            this.tComboEditor_TargetContrastCd.Focus();

            // �ݒ�敪�����R���g���[��Enabled����
            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
        }
        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃t�H�[�J�X���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            int status;
            GetCampaignStList();

            switch (e.PrevCtrl.Name)
            {
                // �L�����y�[���R�[�h
                case "tNedit_CampaignCode":
                    {
                      
                        if (this.tNedit_CampaignCode.GetInt() == 0)
                        {
                            this.tEdit_CampaignName.Clear();
                            this.tNedit_YearFrm.Clear();
                            this.tNedit_MonthFrm.Clear();
                            this.tNedit_DayFrm.Clear();
                            this.tNedit_YearTo.Clear();
                            this.tNedit_MonthTo.Clear();
                            this.tNedit_DayTo.Clear();
                            this.tNedit_CampaignCode.Clear();
                            this._prevCampaignCode = 0;
                            break;
                        }
                        // �L�����y�[���R�[�h�擾
                        int campaignCode = this.tNedit_CampaignCode.GetInt();

                        if (campaignCode != this._prevCampaignCode)
                        {
                            if (!string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // �L�����y�[�����擾
                                this.tEdit_CampaignName.DataText = GetCampaignName(campaignCode);
                                this._prevCampaignCode = campaignCode;

                                CampaignSt campaignSt = ReadCampaignSt(campaignCode);
                                this.tNedit_YearFrm.SetInt(campaignSt.ApplyStaDate.Year);
                                this.tNedit_MonthFrm.SetInt(campaignSt.ApplyStaDate.Month);
                                this.tNedit_DayFrm.SetInt(campaignSt.ApplyStaDate.Day);
                                this.tNedit_YearTo.SetInt(campaignSt.ApplyEndDate.Year);
                                this.tNedit_MonthTo.SetInt(campaignSt.ApplyEndDate.Month);
                                this.tNedit_DayTo.SetInt(campaignSt.ApplyEndDate.Day);
                                if (((int)this.tComboEditor_TargetContrastCd.Value == 10 && this.tEdit_SectionCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 30 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_CustomerCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 221 && this.tEdit_SectionCode.Text !="" &&  this.tEdit_EmployeeName.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 222 && this.tEdit_SectionCode.Text !="" &&  this.tEdit_EmployeeName.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 223 && this.tEdit_SectionCode.Text !="" &&  this.tEdit_EmployeeName.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 32 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_SalesAreaCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 50 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_BLGloupCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 60 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_BLGoodsCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 44 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_SalesCode.Text !=""))
                                {
                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                      
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                           
                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_CampaignCode.SetInt(this._prevCampaignCode);
                                this.tEdit_CampaignName.DataText = GetCampaignName(this._prevCampaignCode);
                                return;
                            }

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevCampaignCode = campaignCode;
                            }
                            else
                            {
                                // ----- DEL K2011/07/05 ------- >>>>>>>>>
                                //if (this._searchFlg)
                                //{
                                //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                //                                        "",
                                //                                        0,
                                //                                        MessageBoxButtons.YesNoCancel,
                                //                                        MessageBoxDefaultButton.Button2);
                                //    switch (result)
                                //    {
                                //        case DialogResult.Yes:
                                //            {
                                //                // �ۑ�����
                                //                status = SaveProc();
                                //                if (status != 0)
                                //                {
                                //                    this._prevCampaignCode = campaignCode;
                                //                    break;
                                //                }

                                //                break;
                                //            }
                                //        case DialogResult.No:
                                //            {
                                //                break;
                                //            }
                                //        case DialogResult.Cancel:
                                //            {
                                //                this.tNedit_CampaignCode.Value = this._prevCampaignCode;
                                //                this.tEdit_CampaignName.DataText = GetCampaignName(this._prevCampaignCode);
                                //                break;
                                //            }
                                //    }
                                //}
                                // ----- DEL K2011/07/05 ------- <<<<<<<<<


                                // ����
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevCampaignCode = campaignCode;
                                }
                                else
                                {
                                    this._prevCampaignCode = campaignCode;
                                }
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                Control nextControl;
                                GetNextControl(this.tNedit_CampaignCode, out nextControl);
                                e.NextCtrl = nextControl;
                                break;
                            }
                        }
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        if (this.tNedit_CampaignCode.DataText.Trim() != "")
                        //        {
                        //            e.NextCtrl = this.tComboEditor_TargetContrastCd;
                        //            break;
                        //        }
                        //    }
                        //}

                        break;
                    }
                case "tComboEditor_TargetContrastCd":
                    {
                        if (this._prevSetArea != (int)this.tComboEditor_TargetContrastCd.Value)
                        {
                            if (this.tComboEditor_TargetContrastCd.Value == null)
                            {
                                return;
                            }

                            ComboChgClearScreen();
                            // �ݒ�敪�����R���g���[��Enabled����
                            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);

                            this._prevSetArea = (int)this.tComboEditor_TargetContrastCd.Value;
                        }
                        break;
                    }
                // ���_
                case "tEdit_SectionCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    e.NextCtrl = null;
                                    break;
                                }
                            }
                        }

                        if (this.tEdit_SectionCode.DataText.Trim() == "")
                        {
                            this.tEdit_SectionName.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevSectionCode = "";
                            break;
                        }

                        // ���_�R�[�h�擾
                        string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');

                        if (sectionCode != this._prevSectionCode)
                        {
                            
                            if (!string.IsNullOrEmpty(GetSectionName(sectionCode)))
                            {
                                // ���_���擾
                                this.tEdit_SectionName.DataText = GetSectionName(sectionCode);
                                this._prevSectionCode = sectionCode;
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());

                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevSectionCode = sectionCode;
                                    }
                                    else
                                    {
                                        // ����
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevSectionCode = sectionCode;
                                        }
                                        else
                                        {
                                            this._prevSectionCode = sectionCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tEdit_SectionCode.DataText = this._prevSectionCode;
                                this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>> 
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevSectionCode = sectionCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // �ۑ�����
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevSectionCode = sectionCode;
                            //                        break;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tEdit_SectionCode.DataText = this._prevSectionCode;
                            //                    this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                            //                    break;
                            //                }
                            //        }
                            //    }


                            //    // ����
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevSectionCode = sectionCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevSectionCode = sectionCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tEdit_SectionCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_CustomerCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 30)
                                {
                                    e.NextCtrl = null;
                                    break;
                                }
                            }
                        }

                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tEdit_CustomerName.Clear();
                            this.tNedit_CustomerCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevCustomerCode = 0;
                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        if (customerCode != this._prevCustomerCode)
                        {
                            if (!string.IsNullOrEmpty(GetCustomerName(customerCode)))
                            {
                                // ���Ӑ於�擾
                                this.tEdit_CustomerName.DataText = GetCustomerName(customerCode);
                                this._prevCustomerCode = customerCode;

                                if ((int)this.tComboEditor_TargetContrastCd.Value == 30)
                                {
                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false;  // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                     
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevCustomerCode = customerCode;
                                    }
                                    else
                                    {
                                        // ����
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevCustomerCode = customerCode;
                                        }
                                        else
                                        {
                                            this._prevCustomerCode = customerCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<


                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                                this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevCustomerCode = customerCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // �ۑ�����
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevCustomerCode = customerCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                            //                    this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // ����
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevCustomerCode = customerCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevCustomerCode = customerCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_CustomerName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_CustomerCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_EmployeeCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 221
                                    || (int)this.tComboEditor_TargetContrastCd.Value == 222
                                    || (int)this.tComboEditor_TargetContrastCd.Value == 223)
                                {
                                    e.NextCtrl = null;
                                    break;
                                }
                            }
                        }

                        if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                        {
                            this.tEdit_EmployeeName.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevEmployeeCode = "";
                            break;
                        }

                        // �]�ƈ��R�[�h�擾
                        string employeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');

                        if (employeeCode != this._prevEmployeeCode)
                        {
                            if (!string.IsNullOrEmpty(GetEmployeeName(employeeCode)))
                            {
                                // �]�ƈ����擾
                                this.tEdit_EmployeeName.DataText = GetEmployeeName(employeeCode);
                                this._prevEmployeeCode = employeeCode;


                                if ((int)this.tComboEditor_TargetContrastCd.Value == 221
                                    || (int)this.tComboEditor_TargetContrastCd.Value == 222
                                    || (int)this.tComboEditor_TargetContrastCd.Value == 223)
                                {
                                    // �L�����y�[���R�[�h�擾
                                    int campaignCode = this.tNedit_CampaignCode.GetInt();
                                    if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                    {
                                        // �Y���Ȃ�
                                        this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                        e.NextCtrl = this.tNedit_CampaignCode;
                                        this.tNedit_CampaignCode.Text = "";
                                        this.tEdit_CampaignName.Clear();
                                        this.tNedit_YearFrm.Clear();
                                        this.tNedit_MonthFrm.Clear();
                                        this.tNedit_DayFrm.Clear();
                                        this.tNedit_YearTo.Clear();
                                        this.tNedit_MonthTo.Clear();
                                        this.tNedit_DayTo.Clear();
                                        this._prevCampaignCode = 0;
                                        return;
                                    }

                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                       
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevEmployeeCode = employeeCode;
                                    }
                                    else
                                    {
                                        // ����
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevEmployeeCode = employeeCode;
                                        }
                                        else
                                        {
                                            this._prevEmployeeCode = employeeCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<


                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                                this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevEmployeeCode = employeeCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // �ۑ�����
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevEmployeeCode = employeeCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                            //                    this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // ����
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevEmployeeCode = employeeCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevEmployeeCode = employeeCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_EmployeeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tEdit_EmployeeCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesAreaCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 32)
                                {
                                    e.NextCtrl = null;
                                    break;
                                }
                            }
                        }

                        if (this.tNedit_SalesAreaCode.GetInt() == 0)
                        {
                            this.tEdit_SalesAreaName.Clear();
                            this.tNedit_SalesAreaCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevSalesAreaCode = 0;
                            break;
                        }

                        // �n��R�[�h�擾
                        int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();

                        if (salesAreaCode != this._prevSalesAreaCode)
                        {
                            if (!string.IsNullOrEmpty(GetSalesAreaName(salesAreaCode)))
                            {
                                // �n�於�擾
                                this.tEdit_SalesAreaName.DataText = GetSalesAreaName(salesAreaCode);
                                this._prevSalesAreaCode = salesAreaCode;

                                if ((int)this.tComboEditor_TargetContrastCd.Value == 32)
                                {
                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false;  // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                   
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevSalesAreaCode = salesAreaCode;
                                    }
                                    else
                                    {
                                        // ����
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevSalesAreaCode = salesAreaCode;
                                        }
                                        else
                                        {
                                            this._prevSalesAreaCode = salesAreaCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                                this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevSalesAreaCode = salesAreaCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // �ۑ�����
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevSalesAreaCode = salesAreaCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                            //                    this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // ����
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevSalesAreaCode = salesAreaCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevSalesAreaCode = salesAreaCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SalesAreaName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SalesAreaCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_BLGloupCode":
                    {
                        if (this.tNedit_BLGloupCode.GetInt() == 0)
                        {
                            this.tEdit_GroupName.Clear();
                            this.tNedit_BLGloupCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevBLGroupCode = 0;
                            break;
                        }

                        // ��ٰ�ߺ��ގ擾
                        int bLGloupCode = this.tNedit_BLGloupCode.GetInt();

                        if (bLGloupCode != this._prevBLGroupCode)
                        {
                            if (!string.IsNullOrEmpty(GetBLGroupName(bLGloupCode)))
                            {
                                // ��ٰ�ߺ��ޖ��擾
                                this.tEdit_GroupName.DataText = GetBLGroupName(bLGloupCode);
                                this._prevBLGroupCode = bLGloupCode;

                                if ((int)this.tComboEditor_TargetContrastCd.Value == 50)
                                {
                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                        
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevBLGroupCode = bLGloupCode;
                                    }
                                    else
                                    {
                                        // ����
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevBLGroupCode = bLGloupCode;
                                        }
                                        else
                                        {
                                            this._prevBLGroupCode = bLGloupCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_BLGloupCode.SetInt(this._prevBLGroupCode);
                                this.tEdit_GroupName.DataText = GetBLGroupName(this._prevBLGroupCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevBLGroupCode = bLGloupCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // �ۑ�����
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevBLGroupCode = bLGloupCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_BLGloupCode.SetInt(this._prevBLGroupCode);
                            //                    this.tEdit_GroupName.DataText = GetBLGroupName(this._prevBLGroupCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // ����
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevBLGroupCode = bLGloupCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevBLGroupCode = bLGloupCode;
                            //    }
                            //}

                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_GroupName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_BLGloupCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                // BL����
                case "tNedit_BLGoodsCode":
                    {
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            this.tEdit_BLName.Clear();
                            this.tNedit_BLGoodsCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevBLGoodsCode = 0;
                            break;
                        }

                        // BL���ގ擾
                        int bLGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                        if (bLGoodsCode != this._prevBLGoodsCode)
                        {
                            if (!string.IsNullOrEmpty(GetBLGoodsName(bLGoodsCode)))
                            {
                                // BL���ޖ��擾
                                this.tEdit_BLName.DataText = GetBLGoodsName(bLGoodsCode);
                                this._prevBLGoodsCode = bLGoodsCode;

                                if ((int)this.tComboEditor_TargetContrastCd.Value == 60)
                                {
                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                       
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevBLGoodsCode = bLGoodsCode;
                                    }
                                    else
                                    {
                                        // ����
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevBLGoodsCode = bLGoodsCode;
                                        }
                                        else
                                        {
                                            this._prevBLGoodsCode = bLGoodsCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_BLGoodsCode.SetInt(this._prevBLGoodsCode);
                                this.tEdit_BLName.DataText = GetBLGoodsName(this._prevBLGoodsCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevBLGoodsCode = bLGoodsCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // �ۑ�����
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevBLGoodsCode = bLGoodsCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_BLGoodsCode.SetInt(this._prevBLGroupCode);
                            //                    this.tEdit_BLName.DataText = GetBLGoodsName(this._prevBLGoodsCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // ����
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevBLGoodsCode = bLGoodsCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevBLGoodsCode = bLGoodsCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_BLName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_BLGoodsCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "SectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Right)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10 && this.tEdit_SectionCode.Text != "")
                                {
                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false;  // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                        
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_SalesTargetSale;
                                }

                                return;
                            }
                        }
                        break;
                    }
                case "CustomerGuide_Button":
                case "EmployeeGuide_Button":
                case "SalesAreaGuide_Button":
                case "GroupGuide_Button":
                case "BLGuide_Button":
                case "SalesCodeGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                if (((int)this.tComboEditor_TargetContrastCd.Value == 30 && this.tEdit_SectionCode.Text != "" && this.tNedit_CustomerCode.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 221 && this.tEdit_SectionCode.Text != "" && this.tEdit_EmployeeName.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 222 && this.tEdit_SectionCode.Text != "" && this.tEdit_EmployeeName.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 223 && this.tEdit_SectionCode.Text != "" && this.tEdit_EmployeeName.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 32 && this.tEdit_SectionCode.Text != "" && this.tNedit_SalesAreaCode.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 50 && this.tEdit_SectionCode.Text != "" && this.tNedit_BLGloupCode.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 60 && this.tEdit_SectionCode.Text != "" && this.tNedit_BLGoodsCode.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 44 && this.tEdit_SectionCode.Text != "" && this.tNedit_SalesCode.Text != ""))
                                {
                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false;  // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                     
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_SalesTargetSale;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesCode":
                    {
                        if (tNedit_SalesCode.GetInt() == 0)
                        {
                            this.tEdit_SalesCodeName.Clear();
                            this.tNedit_SalesCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevSalesCode = 0;
                            return;
                        }

                        // �̔��敪�R�[�h�擾
                        int salesCode = this.tNedit_SalesCode.GetInt();

                        if (salesCode != this._prevSalesCode)
                        {
                            if (!string.IsNullOrEmpty(GetSalesCodeName(salesCode)))
                            {
                                // �̔��敪���擾
                                this.tEdit_SalesCodeName.DataText = GetSalesCodeName(salesCode);
                                this._prevSalesCode = salesCode;


                                if ((int)this.tComboEditor_TargetContrastCd.Value == 44)
                                {
                                    // ����
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // �L�����y�[���R�[�h�擾
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // �Y���Ȃ�
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�L�����y�[���R�[�h�����݂��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                   
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevSalesCode = salesCode;
                                    }
                                    else
                                    {
                                        // ����
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevSalesCode = salesCode;
                                        }
                                        else
                                        {
                                            this._prevSalesCode = salesCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�}�X�^�ɓo�^����Ă��܂���B", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                                this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevSalesCode = salesCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // �ۑ�����
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevSalesCode = salesCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                            //                    this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // ����
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevSalesCode = salesCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevSalesCode = salesCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SalesCodeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SalesCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesTargetSale":
                    {
                        ChangeValue(this.tNedit_SalesTargetSale,10);
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.tNedit_SalesTargetSale1.Focus();
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.Mode_Label.Text == INSERT_MODE
                                    || this.Mode_Label.Text == UPDATE_MODE)  // ADD K2011/07/05 
                                {
                                    // ----- DEL K2011/07/05 ------- >>>>>>>>>
                                    // �ݒ�敪
                                    //int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

                                    //switch (targetContrastCd)
                                    //{
                                    //    case 10:    // ���_
                                    //        {
                                    //            if (this.tEdit_SectionName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tEdit_SectionCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 30:    // ���_�{���Ӑ�
                                    //        {
                                    //            if (this.tEdit_CustomerName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_CustomerCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 221:   // ���_�{�S����
                                    //    case 222:   // ���_�{�󒍎�
                                    //    case 223:   // ���_�{���s��
                                    //        {
                                    //            if (this.tEdit_EmployeeName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tEdit_EmployeeCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 32:    // ���_�{�n��
                                    //        {
                                    //            if (this.tEdit_SalesAreaName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_SalesAreaCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 50:    // ���_�{�O���[�v�R�[�h
                                    //        {
                                    //            if (this.tEdit_GroupName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_BLGloupCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 44:    // ���_�{�̔��敪
                                    //        {
                                    //            if (this.tEdit_GroupName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_SalesCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 60:    // ���_�{BL�R�[�h
                                    //        {
                                    //            if (this.tEdit_BLName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_BLGoodsCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //}
                                    // ----- DEL K2011/07/05 ------- <<<<<<<<<
                                }
                                else
                                {
                                    e.NextCtrl = this.SalesTarget_uGrid;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesTargetProfit":
                    {
                        ChangeValue(this.tNedit_SalesTargetProfit,10);
                        break;
                    }
                case "tNedit_SalesTargetCount":
                    {
                        ChangeValue(this.tNedit_SalesTargetCount,8);
                        break;
                    }
                case "tNedit_SalesTargetSale1":
                    {
                        ChangeValue(this.tNedit_SalesTargetSale1,10);
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        break;
                    }
                case "tNedit_SalesTargetProfit1":
                    {
                        ChangeValue(this.tNedit_SalesTargetProfit1,10);
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_PROFITTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        break;
                    }
                case "tNedit_SalesTargetCount1":
                    {
                        ChangeValue(this.tNedit_SalesTargetCount1,8);
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_COUNTTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = null;
                                this.SalesTarget_uGrid.Focus();
                                this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                                this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }

                        break;
                    }
                case "SalesTarget_uGrid":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextCell(ref e, false);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                SetNextCell(ref e, true);
                                return;
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }
    
            if (e.NextCtrl == this.SalesTarget_uGrid)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || e.Key == Keys.Down || e.Key == Keys.Right)
                    {
                        e.NextCtrl = null;
                        this.SalesTarget_uGrid.Focus();
                        this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                    }
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[11].Cells[COLUMN_COUNTTARGET].Activate();
                }

                this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }

            // �K�C�h�{�^���c�[���L�������ݒ菈��
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tNedit_CampaignCode.Focus();
            this._guideKey = this.tNedit_CampaignCode.Name;

            this.timer_SetFocus.Enabled = false;
        }
        #endregion �� Control Events

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�\������</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMKHN09651UA",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�L�����y�[���ڕW�ݒ�}�X�^",		// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case ct_Tool_CloseButton:
                    {
                        int status = this.BeforeClose();
                        // �I���O�`�F�b�N������ꍇ�͏����I��
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            this.Close();
                        }
                        break;
                    }
                // �V�K
                case ct_Tool_NewButton:
                    {
                        this.New();
                        break;
                    }
                // �ۑ� 
                case ct_Tool_SaveButton:
                    {
                        this.Save();
                        break;
                    }
                // ����
                case ct_Tool_RevivalButton:
                    {
                        this.Revival();
                        break;
                    }
                // �_���폜
                case ct_Tool_LogicalDeleteButton:
                    {
                        this.LogicalDelete();
                        break;
                    }
                // �폜
                case ct_Tool_DeleteButton:
                    {
                        this.Delete();
                        break;
                    }
                // ���ɖ߂�
                case ct_Tool_UndoButton:
                    {
                        this.Undo();
                        break;
                    }
                // �K�C�h
                case ct_Tool_GuideButton:
                    {
                        this.Guide();
                        break;
                    }
                // �ŐV���
                case ct_Tool_RenewalButton:
                    {
                        this.Renewal();
                        break;
                    }
            }
        }
    }
}
