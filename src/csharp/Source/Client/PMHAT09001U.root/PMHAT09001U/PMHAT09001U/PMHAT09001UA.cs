//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����_�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/31  �C�����e : �V�K�쐬
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
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����_�ݒ�}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.03.31</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.03.31 lizc �V�K�쐬</br>
    /// </remarks>
    public partial class PMHAT09001UA : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �R���X�g���N�^
        /// <summary>
        /// �����_�ݒ�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^�̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public PMHAT09001UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._orderPointStListTable = new Hashtable();

            this._orderPointStDataTable = new OrderPointStDataSet.OrderPointStDataTable();
            this._orderPointStDataTableClone = new OrderPointStDataSet.OrderPointStDataTable();
            this._orderPointStAcs = new OrderPointStAcs();

            this._secInfoAcs = new SecInfoAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._makerAcs = new MakerAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._supplierAcs = new SupplierAcs();

            this._orderPointStClone = new OrderPointSt();
            this._orderPointStDicClone = new Dictionary<int, OrderPointSt>();
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        # region Private Constant

        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        private const string TOOLBAR_LOGICALDELETE_KEY = "ButtonTool_LogicalDelete";
        private const string TOOLBAR_DELETE_KEY = "ButtonTool_Delete";
        private const string TOOLBAR_REVIVAL_KEY = "ButtonTool_Revival";
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LableTool_LoginSection";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_ROWDELETE_KEY = "ButtonTool_delRow";

        private const string TOOLBAR_LOGINSECTIONLABEL_TITLE = "LableTool_LoginSectionTitle";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        private const string AVGSUMDIV_1 = "����";
        private const string AVGSUMDIV_2 = "���v";

        private const string COLUMNKEY_1 = "ShipScopeMore";         // �o�א��͈�(�ȏ�)
        private const string COLUMNKEY_2 = "ShipScopeLess";         // �o�א��͈�(�ȉ�)
        private const string COLUMNKEY_3 = "MinimumStockCnt";       // �Œ�݌ɐ�
        private const string COLUMNKEY_4 = "MaximumStockCnt";       // �ō��݌ɐ�
        private const string COLUMNKEY_5 = "SalesOrderUnit";        // �����P��

        private const string ASSEMBLY_ID = "PMHAT09001U";

        private const string COLUMN_SHIPSCOPEMORE = "ShipScopeMore";
        private const string COLUMN_SHIPSCOPELESS = "ShipScopeLess";
        private const string COLUMN_MINIMUMSTOCKCNT = "MinimumStockCnt";
        private const string COLUMN_MAXIMUMSTOCKCNT = "MaximumStockCnt";
        private const string COLUMN_SALESORDERUNIT = "SalesOrderUnit";

        private const string FORMAT_NUM = "###,##0.00";
        private const string FORMAT_NUM2 = "###,###";

        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        private const string UPDATE_DIV_0 = "���X�V";
        private const string UPDATE_DIV_1 = "�X�V��";

        private const int COLUMN_COUNT = 6;                    // ��
        private const int ROW_COUNT = 20;                       // �s��
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        // ��ƃR�[�h�擾�p
        private string _enterpriseCode;
        // ���O�C�����_(�����_)
        private string _loginSectionCode;

        private Hashtable _orderPointStListTable;

        // �ۑ���r�pClone
        private OrderPointSt _orderPointStClone;
        private OrderPointStDataSet.OrderPointStDataTable _orderPointStDataTableClone;

        private OrderPointStDataSet.OrderPointStDataTable _orderPointStDataTable;
        private OrderPointStAcs _orderPointStAcs;

        private ImageList _imageList16 = null;											// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;				// �����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;				// �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _logicDeleteButton;		// �_���폜
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;				// �폜
        private Infragistics.Win.UltraWinToolbars.ButtonTool _revivalButton;			// ����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;	// ���O�C�����_����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionLabel;			// ���O�C�����_����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		    // ���O�C���S���Җ���

        // �s�폜
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDelButton;

        // �A�N�Z�X�N���X
        private WarehouseAcs _warehouseAcs = null;           //�q�ɃK�C�h
        private MakerAcs _makerAcs = null;					// ���[�J�[�A�N�Z�X�N���X
        private GoodsGroupUAcs _goodsGroupUAcs = null;      // �����ރA�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BL�A�N�Z�X�N���X
        private BLGroupUAcs _blGroupUAcs = null;            // BL�O���[�v�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs = null;            // �d����A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs = null;              // ���_���A�N�Z�X�N���X

        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;

        private Dictionary<int, OrderPointSt> _orderPointStDicClone;

        // �O��l�ێ��p�ϐ�
        private int _prevPatterNo;
        private string _prevWarehouseCode;
        private int _prevSupplierCd;
        private int _prevMakerCode;
        private int _prevBLGroupCode;
        private int _prevBLGoodsCode;
        private int _prevGoodsMGroupCd;

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g
        // ===================================================================================== //
        # region Private Method
        # region ��ʏ�����
        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // �c�[���o�[�����ݒ菈��
            this.ToolBarInitilSetting();

            // �{�^���A�C�R���ݒ�
            this.SetGuidButtonIcon();

            // �c�[���{�^��Enable�ݒ菈��
            this.SetControlEnabled(INSERT_MODE);

            // ������ʃf�[�^�ݒ�
            this.InitialScreenData();

            //this.SetBlankGrid();
            this.FillDetailRow();
        }

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������A�c�[���o�[�����ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.03.31</br>
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

            // �ۑ��̃A�C�R���ݒ�
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY];
            if (this._saveButton != null)
            {
                this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SAVE];
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

            // �_���폜
            this._logicDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGICALDELETE_KEY];
            {
                this._logicDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DELETE];
            }

            // �폜
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_DELETE_KEY];
            {
                this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DELETE];
            }

            // ����
            this._revivalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_REVIVAL_KEY];
            {
                this._revivalButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.UNDO];
            }

            // ���O�C�����_�̃A�C�R���ݒ�
            this._loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABEL_TITLE];
            if (this._loginSectionTitleLabel != null)
            {
                this._loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.BASE]; ;
            }

            // ���O�C���S���҂̃A�C�R���ݒ�
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }

            // ���O�C�����_��
            this._loginSectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            if (this._loginSectionLabel != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    this._loginSectionLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
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

            // �s�폜
            this._rowDelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_ROWDELETE_KEY];
            {
                this._rowDelButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.ROWDELETE];
            }
        }

        /// <summary>
        /// �K�C�h�{�^���̃A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            // -----------------------------
            // �{�^���A�C�R���ݒ�
            // -----------------------------
            this.WarehouseGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsMGroupGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGroupGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCdGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// ������ʃf�[�^�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks> 
        private void InitialScreenData()
        {
            // ���ρE���v�敪
            this.tComboEditor_OrderApplyDiv.Items.Clear();
            this.tComboEditor_OrderApplyDiv.Items.Add("1", AVGSUMDIV_1);
            this.tComboEditor_OrderApplyDiv.Items.Add("2", AVGSUMDIV_2);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <param name="clearFlag">�N���A�ݒ�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.02</br>
        /// </remarks>
        private void ClearScreen(bool clearFlag)
        {
            if (clearFlag)
            {
                this.tNedit_PatterNo.Clear();
            }

            // ��{���
            this.tEdit_WarehouseCode.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tNedit_BLGoodsCode.Clear();

            //�@�������
            this.tDateEdit_StckShipMonthSt.Clear();
            this.tDateEdit_StckShipMonthEd.SetDateTime(System.DateTime.Now);
            this.tDateEdit_StockCreateDate.SetDateTime(System.DateTime.Now);
            this.tComboEditor_OrderApplyDiv.Value = "1";

            //�@�ڍ׏��
            this.ClearGrid();

            this._prevPatterNo = 0;
            this._prevWarehouseCode = string.Empty;
            this._prevBLGroupCode = 0;
            this._prevBLGoodsCode = 0;
            this._prevMakerCode = 0;
            this._prevSupplierCd = 0;
            this._prevGoodsMGroupCd = 0;

            this.UpdateDiv_Label.Text = UPDATE_DIV_0;

            this.SetControlEnabled(INSERT_MODE);

            ScreenToOrderPointSt(ref this._orderPointStClone);
            // �t�H�[�J�X�̐ݒ�
            this.tNedit_PatterNo.Focus();

            // scrollbar�̈ʒu
            this.Detail_uGrid.ActiveRowScrollRegion.FirstRow = this.Detail_uGrid.Rows[0];
        }

        /// <summary>
        /// �O���b�h����������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�������������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void ClearGrid()
        {
            for (int index = 0; index < ROW_COUNT; index++)
            {
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SHIPSCOPEMORE].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SHIPSCOPELESS].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_MINIMUMSTOCKCNT].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_MAXIMUMSTOCKCNT].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SALESORDERUNIT].Value = "";
            }
            this.Detail_uGrid.UpdateData();
            this._orderPointStDicClone.Clear();
        }
        # endregion ��ʏ�����

        #region ��ʐݒ�
        /// <summary>
        /// �c�[���{�^��Enable�ݒ菈��
        /// </summary>
        /// <param name="mode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �c�[���{�^��Enable��ݒ肷��</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2009/04/21</br>
        /// </remarks>
        private void SetToolButtonVisible(string mode)
        {
            switch (mode)
            {
                // �V�K
                case INSERT_MODE:
                    {
                        this._saveButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }
                // �X�V
                case UPDATE_MODE:
                    {
                        this._saveButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = true;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = UPDATE_MODE;
                        break;
                    }
                // �폜
                case DELETE_MODE:
                    {
                        this._saveButton.SharedProps.Visible = false;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = true;
                        this._revivalButton.SharedProps.Visible = true;

                        this.Mode_Label.Text = DELETE_MODE;
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
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2009/04/21</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            switch (editMode)
            {
                // �V�K
                case INSERT_MODE:
                    {
                        // ��{���R�[�h
                        this.tEdit_WarehouseCode.Enabled = true;
                        this.tNedit_GoodsMGroup.Enabled = true;
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGloupCode.Enabled = true;
                        this.tNedit_SupplierCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;

                        // ��{���button
                        this.WarehouseGuide_Button.Enabled = true;
                        this.GoodsMGroupGuide_Button.Enabled = true;
                        this.SupplierGuide_Button.Enabled = true;
                        this.BLGroupGuide_Button.Enabled = true;
                        this.MakerGuide_Button.Enabled = true;
                        this.BLGoodsCdGuide_Button.Enabled = true;

                        // �������
                        this.tDateEdit_StckShipMonthSt.Enabled = true;
                        this.tDateEdit_StckShipMonthEd.Enabled = true;
                        this.tDateEdit_StockCreateDate.Enabled = true;
                        this.tComboEditor_OrderApplyDiv.Enabled = true;

                        // �ڍ׏��
                        this.Detail_uGrid.Enabled = true;

                        this._saveButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = INSERT_MODE;

                        this.tRetKeyControl1.OwnerForm = this;

                        break;
                    }
                // �X�V
                case UPDATE_MODE:
                    {
                        // ��{���R�[�h
                        this.tEdit_WarehouseCode.Enabled = true;
                        this.tNedit_GoodsMGroup.Enabled = true;
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGloupCode.Enabled = true;
                        this.tNedit_SupplierCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;

                        // ��{���button
                        this.WarehouseGuide_Button.Enabled = true;
                        this.GoodsMGroupGuide_Button.Enabled = true;
                        this.SupplierGuide_Button.Enabled = true;
                        this.BLGroupGuide_Button.Enabled = true;
                        this.MakerGuide_Button.Enabled = true;
                        this.BLGoodsCdGuide_Button.Enabled = true;

                        // �������
                        this.tDateEdit_StckShipMonthSt.Enabled = true;
                        this.tDateEdit_StckShipMonthEd.Enabled = true;
                        this.tDateEdit_StockCreateDate.Enabled = true;
                        this.tComboEditor_OrderApplyDiv.Enabled = true;

                        // �ڍ׏��
                        this.Detail_uGrid.Enabled = true;

                        this._saveButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = true;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = UPDATE_MODE;

                        this.tRetKeyControl1.OwnerForm = this;
                        break;
                    }
                // �폜
                case DELETE_MODE:
                    {
                        // ��{���R�[�h
                        this.tEdit_WarehouseCode.Enabled = false;
                        this.tNedit_GoodsMGroup.Enabled = false;
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.tNedit_SupplierCd.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;

                        // ��{���button
                        this.WarehouseGuide_Button.Enabled = false;
                        this.GoodsMGroupGuide_Button.Enabled = false;
                        this.SupplierGuide_Button.Enabled = false;
                        this.BLGroupGuide_Button.Enabled = false;
                        this.MakerGuide_Button.Enabled = false;
                        this.BLGoodsCdGuide_Button.Enabled = false;

                        // �������
                        this.tDateEdit_StckShipMonthSt.Enabled = false;
                        this.tDateEdit_StckShipMonthEd.Enabled = false;
                        this.tDateEdit_StockCreateDate.Enabled = false;
                        this.tComboEditor_OrderApplyDiv.Enabled = false;

                        // �ڍ׏��
                        this.Detail_uGrid.Enabled = false;

                        this._saveButton.SharedProps.Visible = false;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = true;
                        this._revivalButton.SharedProps.Visible = true;

                        this.Mode_Label.Text = DELETE_MODE;

                        this.tRetKeyControl1.OwnerForm = this.Detail_uGrid;

                        break;
                    }
            }
        }
        # endregion ��ʐݒ�

        # region �}�X�^�Ǎ�
        /// <summary>
        /// �q�Ƀ}�X�^�Ǎ�����
        /// </summary>
        private void LoadWarehouse()
        {
            int status = 0;

            this._warehouseDic = new Dictionary<string, Warehouse>();

            try
            {
                ArrayList retList;

                status = this._warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }
        }

        /// <summary>
        /// �d����}�X�^�Ǎ�����
        /// </summary>
        private void LoadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        this._supplierDic.Add(supplier.SupplierCd, supplier);
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// �����ރ}�X�^�Ǎ�����
        /// </summary>
        private void LoadGoodsGroupU()
        {
            this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

            try
            {
                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }

        /// <summary>
        /// BL�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        private void LoadBLGoodsCdUMnt()
        {
            int status = 0;

            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// �O���[�v�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        private void LoadBLGroupU()
        {
            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU blGroupU in retList)
                    {
                        this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }
        # endregion �}�X�^�Ǎ�

        # region �ۑ�����
        /// <summary>
        ///�@�ۑ�����(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool bStatus = false;

            // ���̓`�F�b�N
            bStatus = CheckInputScreen(true);

            if (bStatus != true)
            {
                return (false);
            }

            int status = 0;

            // �V�K���[�h�̏ꍇ
            if (this.Mode_Label.Text.Equals(INSERT_MODE))
            {
                List<OrderPointSt> retList = new List<OrderPointSt>();
                status = this._orderPointStAcs.Search(out retList, this.tNedit_PatterNo.GetInt(), this._enterpriseCode);
                if (retList.Count > 0)
                {
                    ExclusiveTransaction((int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE);

                    return false;
                }
            }

            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();

            this.ScreenToOrderPointStList(ref orderPointStList);

            // �폜���X�g�擾
            List<OrderPointSt> deleteList = new List<OrderPointSt>();
            foreach (OrderPointSt orderPointSt in this._orderPointStDicClone.Values)
            {
                // TODO:��肪����
                deleteList.Add(orderPointSt);
            }

            // �폜����
            if (deleteList.Count > 0)
            {
                status = this._orderPointStAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                           "SaveProc",
                                           "�ۑ������Ɏ��s���܂����B",
                                           status,
                                           MessageBoxButtons.OK);

                            return false;
                        }
                }
            }

            // �ۑ�����
            status = this._orderPointStAcs.Write(ref orderPointStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        this.ClearScreen(true);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        return false;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "�ۑ������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return false;
                    }
            }
            return bStatus;
        }
        # endregion �ۑ�����

        # region ��������
        /// <summary>
        ///�@��������(SearchProc())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �����������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private int SearchProc()
        {
            bool bStatus = false;

            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʌ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

            int patterNo = this.tNedit_PatterNo.GetInt();

            if (this._prevPatterNo != 0)
            {
                // ���͒��̃f�[�^�`���b�N
                if (!this.CompareInputScreen())
                {
                    this.tNedit_PatterNo.SetInt(this._prevPatterNo);
                    return (-1);
                }
            }

            this.tNedit_PatterNo.SetInt(patterNo);
            // ���̓`�F�b�N
            bStatus = CheckInputScreen(false);
            if (bStatus != true)
            {
                return (-1);
            }

            int status = 0;

            List<OrderPointSt> orderPointList;

            status = this._orderPointStAcs.Search(out orderPointList, patterNo, this._enterpriseCode);

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // �ҏW���[�h�ݒ�
                        if (orderPointList[0].LogicalDeleteCode == 0)
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

                        // �X�V�敪
                        if (orderPointList[0].OrderPProcUpdFlg == 0)
                        {
                            this.UpdateDiv_Label.Text = UPDATE_DIV_0;
                        }
                        else
                        {
                            this.UpdateDiv_Label.Text = UPDATE_DIV_1;
                        }

                        // �o�b�t�@�X�V
                        this._orderPointStDicClone.Clear();
                        foreach (OrderPointSt orderPointSt in orderPointList)
                        {
                            this._orderPointStDicClone.Add(orderPointSt.PatternNoDerivedNo, orderPointSt);
                        }


                        this.OrderPointStToScreen(_orderPointStDicClone);

                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        // �c�[���{�^��Enable�ݒ菈��
                        this.SetControlEnabled(INSERT_MODE);
                        this.UpdateDiv_Label.Text = UPDATE_DIV_0;

                        this.ClearScreen(false);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            this.Text,                              // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._orderPointStAcs,					    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,					// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        break;
                    }
            }

            return status;
        }
        # endregion ��������

        # region �`�F�b�N����
        /// <summary>
        /// ��ʏ����̓`�F�b�N����
        /// </summary>
        /// <param name="saveFlag">�ۑ��t���O(True:�ۑ��O�`�F�b�N�@False:���������`�F�b�N)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckInputScreen(bool saveFlag)
        {
            string errMsg = "";
            bool bStatus;

            try
            {
                // �ݒ�R�[�h
                if (this.tNedit_PatterNo.DataText.Trim() == "")
                {
                    errMsg = "�ݒ�R�[�h����͂��Ă��������B";

                    this.tNedit_PatterNo.Focus();
                    return (false);
                }

                if (saveFlag)
                {
                    // ��{���`�F�b�N
                    bStatus = CheckBaseInfo(out errMsg);
                    if (!bStatus)
                    {
                        return (false);
                    }

                    // �������`�F�b�N
                    bStatus = CheckCondtionInfo(out errMsg);
                    if (!bStatus)
                    {
                        return (false);
                    }

                    // �ڍ׏��`�F�b�N
                    bStatus = CheckDetailInfo(out errMsg);
                    if (!bStatus)
                    {
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                                 , this.ToString()
                                 , errMsg
                                 , 0
                                 , MessageBoxButtons.OK);
                }
            }

            return true;
        }

        /// <summary>
        /// ��ʏ����̓`�F�b�N����(��{���)
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckBaseInfo(out string errMsg)
        {
            errMsg = "";

            // �q�ɃR�[�h
            if (this.tEdit_WarehouseCode.DataText.Trim() != string.Empty)
            {
                if (this._warehouseDic == null)
                {
                    // �q�Ƀ}�X�^�Ǎ�����
                    LoadWarehouse();
                }

                if (!this._warehouseDic.ContainsKey(this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0')))
                {
                    errMsg = "�w�肳�ꂽ�����̑q�ɃR�[�h�͑��݂��܂���ł����B";

                    this.tEdit_WarehouseCode.Focus();
                    return (false);
                }
            }
            // ������
            if (this.tNedit_GoodsMGroup.GetInt() != 0)
            {
                if (this._goodsGroupUDic == null)
                {
                    // �����ރ}�X�^�Ǎ�����
                    LoadGoodsGroupU();
                }

                if (!this._goodsGroupUDic.ContainsKey(this.tNedit_GoodsMGroup.GetInt()))
                {
                    errMsg = "�w�肳�ꂽ�����̒����ރR�[�h�͑��݂��܂���ł����B";

                    this.tNedit_GoodsMGroup.Focus();
                    return (false);
                }
            }
            // �d����
            if (this.tNedit_SupplierCd.GetInt() != 0)
            {
                if (this._supplierDic == null)
                {
                    // �d����}�X�^�Ǎ�����
                    LoadSupplier();
                }

                if (!this._supplierDic.ContainsKey(this.tNedit_SupplierCd.GetInt()))
                {
                    errMsg = "�w�肳�ꂽ�����̎d����R�[�h�͑��݂��܂���ł����B";

                    this.tNedit_SupplierCd.Focus();
                    return (false);
                }
            }
            // �O���[�v�R�[�h
            if (this.tNedit_BLGloupCode.GetInt() != 0)
            {
                if (this._blGroupUDic == null)
                {
                    // �O���[�v�}�X�^�Ǎ�����
                    LoadBLGroupU();
                }

                if (!this._blGroupUDic.ContainsKey(this.tNedit_BLGloupCode.GetInt()))
                {
                    errMsg = "�w�肳�ꂽ�����̃O���[�v�R�[�h�͑��݂��܂���ł����B";

                    this.tNedit_BLGloupCode.Focus();
                    return (false);
                }
            }
            // ���[�J�[�R�[�h
            if (this.tNedit_GoodsMakerCd.GetInt() != 0)
            {
                if (this._makerUMntDic == null)
                {
                    // �O���[�v�}�X�^�Ǎ�����
                    LoadMakerUMnt();
                }

                if (!this._makerUMntDic.ContainsKey(this.tNedit_GoodsMakerCd.GetInt()))
                {
                    errMsg = "�w�肳�ꂽ�����̃��[�J�[�R�[�h�͑��݂��܂���ł����B";

                    this.tNedit_GoodsMakerCd.Focus();
                    return (false);
                }
            }
            // BL�R�[�h
            if (this.tNedit_BLGoodsCode.GetInt() != 0)
            {
                if (this._blGoodsCdUMntDic == null)
                {
                    // �O���[�v�}�X�^�Ǎ�����
                    LoadBLGoodsCdUMnt();
                }

                if (!this._blGoodsCdUMntDic.ContainsKey(this.tNedit_BLGoodsCode.GetInt()))
                {
                    errMsg = "�w�肳�ꂽ������BL�R�[�h�͑��݂��܂���ł����B";

                    this.tNedit_BLGoodsCode.Focus();
                    return (false);
                }
            }
            //
            return true;
        }

        /// <summary>
        /// ��ʏ����̓`�F�b�N����(�������)
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckCondtionInfo(out string errMsg)
        {
            errMsg = "";
            if (this.tDateEdit_StckShipMonthSt.GetDateYear() == 0
                && this.tDateEdit_StckShipMonthSt.GetDateMonth() == 0
                && this.tDateEdit_StckShipMonthSt.GetDateDay() == 0)
            {
                errMsg = "�݌ɏo�בΏۊ���(�J�n)����͂��Ă��������B\r\n";

                this.tDateEdit_StckShipMonthSt.Focus();
                return false;
            }

            // �݌ɏo�בΏۊ��ԁ@�J�n
            if (this.tDateEdit_StckShipMonthSt.LongDate != 0
                && this.tDateEdit_StckShipMonthSt.GetDateTime() == DateTime.MinValue)
            {
                errMsg = "�݌ɏo�בΏۊ���(�J�n)�̓��͂��s���ł��B\r\n";

                this.tDateEdit_StckShipMonthSt.Focus();
                return false;
            }

            if (this.tDateEdit_StckShipMonthEd.GetDateYear() == 0
                && this.tDateEdit_StckShipMonthEd.GetDateMonth() == 0
                && this.tDateEdit_StckShipMonthEd.GetDateDay() == 0)
            {
                errMsg = "�݌ɏo�בΏۊ���(�I��)����͂��Ă��������B\r\n";

                this.tDateEdit_StckShipMonthEd.Focus();
                return false;
            }

            // �݌ɏo�בΏۊ��ԁ@�I��
            if (this.tDateEdit_StckShipMonthEd.LongDate != 0
                && this.tDateEdit_StckShipMonthEd.GetDateTime() == DateTime.MinValue)
            {
                errMsg = "�݌ɏo�בΏۊ���(�I��)�̓��͂��s���ł��B\r\n";

                this.tDateEdit_StckShipMonthEd.Focus();
                return false;
            }
            // �I�����t���J�n���t�`�F�b�N
            if (this.tDateEdit_StckShipMonthSt.GetDateTime() != DateTime.MinValue
                && this.tDateEdit_StckShipMonthEd.GetDateTime() != DateTime.MinValue
                && this.tDateEdit_StckShipMonthSt.GetDateTime().CompareTo(this.tDateEdit_StckShipMonthEd.GetDateTime()) > 0)
            {
                errMsg = "�݌ɏo�בΏۊ��Ԃ͈͎̔w��Ɍ�肪����܂��B\r\n";

                this.tDateEdit_StckShipMonthSt.Focus();
                return false;
            }

            if (this.tDateEdit_StockCreateDate.GetDateYear() == 0
                && this.tDateEdit_StockCreateDate.GetDateMonth() == 0
                && this.tDateEdit_StockCreateDate.GetDateDay() == 0)
            {
                errMsg = "�݌ɓo�^���t����͂��Ă��������B\r\n";

                this.tDateEdit_StockCreateDate.Focus();
                return false;
            }

            // �݌ɓo�^���t
            if (this.tDateEdit_StockCreateDate.LongDate != 0
                && this.tDateEdit_StockCreateDate.GetDateTime() == DateTime.MinValue)
            {
                errMsg = "�݌ɓo�^���t�̓��͂��s���ł��B\r\n";

                this.tDateEdit_StockCreateDate.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// ��ʏ����̓`�F�b�N����(�ڍ׏��)
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckDetailInfo(out string errMsg)
        {
            errMsg = "";

            return this.CheckGridStockCnt(ref errMsg); ;
        }

        /// <summary>
        /// ��ʏ��ύX�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂪕ύX����Ă��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CompareInputScreen()
        {
            OrderPointSt compareOrderPointSt = new OrderPointSt();
            compareOrderPointSt = this._orderPointStClone.Clone();

            this.ScreenToOrderPointSt(ref compareOrderPointSt);

            // �f�[�^��r
            if (!this._orderPointStClone.Equals(compareOrderPointSt)
                || CompareDetailGrid())
            {
                //return false;

                // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                    ASSEMBLY_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                    null, 					                              // �\�����郁�b�Z�[�W
                    0, 					                                  // �X�e�[�^�X�l
                    MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            return this.SaveProc();
                        }

                    case DialogResult.No:
                        {
                            return true;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }
            return true;
        }
        # endregion �`�F�b�N����

        # region ��ʏ��擾
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ�񔭒��_�ݒ�}�X�^�N���X�i�[����
        /// </summary>
        /// <param name="orderPointSt">�����_�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂甭���_�ݒ�}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void ScreenToOrderPointSt(ref OrderPointSt orderPointSt)
        {
            if (orderPointSt == null)
            {
                // �V�K�̏ꍇ
                orderPointSt = new OrderPointSt();
            }

            // ��ƃR�[�h
            orderPointSt.EnterpriseCode = this._enterpriseCode;
            // �p�^�[���ԍ�
            orderPointSt.PatterNo = this._prevPatterNo;
            // �q�ɃR�[�h
            orderPointSt.WarehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');
            // �d����R�[�h
            orderPointSt.SupplierCd = this.tNedit_SupplierCd.GetInt();
            // ���i���[�J�[�R�[�h
            orderPointSt.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // ���i�����ރR�[�h
            orderPointSt.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
            // BL�O���[�v�R�[�h
            orderPointSt.BLGroupCode = this.tNedit_BLGloupCode.GetInt();
            // BL���i�R�[�h
            orderPointSt.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            // �݌ɏo�בΏۊJ�n��
            orderPointSt.StckShipMonthSt = Convert.ToInt32(this.tDateEdit_StckShipMonthSt.GetDateTime().ToString("yyyyMMdd"));
            // �݌ɏo�בΏۏI����
            orderPointSt.StckShipMonthEd = Convert.ToInt32(this.tDateEdit_StckShipMonthEd.GetDateTime().ToString("yyyyMMdd"));
            // �݌ɓo�^��
            orderPointSt.StockCreateDate = Convert.ToInt32(this.tDateEdit_StockCreateDate.GetDateTime().ToString("yyyyMMdd"));
            // �����K�p�敪
            orderPointSt.OrderApplyDiv = this.tComboEditor_OrderApplyDiv.SelectedIndex;
        }

        /// <summary>
        /// ��ʏ�񔭒��_�ݒ�}�X�^�N���X�i�[����
        /// </summary>
        /// <param name="orderPointStList">�����_�ݒ�}�X�^List</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂甭���_�ݒ�}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void ScreenToOrderPointStList(ref List<OrderPointSt> orderPointStList)
        {
            for (int i = 0; i < ROW_COUNT; i++)
            {
                // ��ʂł���Line�������͏ꍇ
                if (ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_SHIPSCOPELESS].Value) == 0
                    && ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_SHIPSCOPEMORE].Value) == 0
                    && ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_MINIMUMSTOCKCNT].Value) == 0
                    && ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_MAXIMUMSTOCKCNT].Value) == 0
                    && ChangeCellValueToInt(this.Detail_uGrid.Rows[i].Cells[COLUMN_SALESORDERUNIT].Value) == 0)
                {
                    continue;
                }

                //// R�g�p�̍X�V����
                //OrderPointSt orderPointStTem = this._orderPointStListTable[0] as OrderPointSt;
                //OrderPointSt orderPointSt = null;
                //if (orderPointStTem != null)
                //{
                //    orderPointSt = orderPointStTem.Clone();
                //}
                //else
                //{
                //    orderPointSt = new OrderPointSt();
                //}

                OrderPointSt orderPointSt = new OrderPointSt();
                this.ScreenToOrderPointSt(ref orderPointSt);

                // �p�^�[���ԍ��}��
                orderPointSt.PatternNoDerivedNo = i + 1;
                // �o�א��͈�(�ȏ�)
                orderPointSt.ShipScopeMore = ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_SHIPSCOPEMORE].Value);
                // �o�א��͈�(�ȉ�)
                orderPointSt.ShipScopeLess = ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_SHIPSCOPELESS].Value);
                // �Œ�݌ɐ�
                orderPointSt.MinimumStockCnt = ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_MINIMUMSTOCKCNT].Value);
                // �ō��݌ɐ�
                orderPointSt.MaximumStockCnt = ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_MAXIMUMSTOCKCNT].Value);
                // �����P��
                orderPointSt.SalesOrderUnit = ChangeCellValueToInt(this.Detail_uGrid.Rows[i].Cells[COLUMN_SALESORDERUNIT].Value);

                orderPointStList.Add(orderPointSt);
            }
        }
        # endregion

        #region ��ʓW�J
        /// <summary>
        /// ��ʓW�J����(�����_�ݒ�)
        /// </summary>
        /// <param name="orderPointStDic">�����_�ݒ�}�X�^���X�g</param>
        /// <remarks>
        /// <br>Note        : �����_�ݒ�}�X�^���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void OrderPointStToScreen(Dictionary<int, OrderPointSt> orderPointStDic)
        {
            //------------------------------
            // �ڕW��񏉊���
            //------------------------------
            // ��{���
            this.tEdit_WarehouseCode.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tNedit_BLGoodsCode.Clear();

            //�@�������
            this.tDateEdit_StckShipMonthSt.Clear();
            this.tDateEdit_StckShipMonthEd.SetDateTime(System.DateTime.Now);
            this.tDateEdit_StockCreateDate.SetDateTime(System.DateTime.Now);
            this.tComboEditor_OrderApplyDiv.Value = "1";

            for (int index = 0; index < ROW_COUNT; index++)
            {
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SHIPSCOPEMORE].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SHIPSCOPELESS].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_MINIMUMSTOCKCNT].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_MAXIMUMSTOCKCNT].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SALESORDERUNIT].Value = "";
            }

            // scrollbar�̈ʒu
            this.Detail_uGrid.ActiveRowScrollRegion.FirstRow = this.Detail_uGrid.Rows[0];

            //------------------------------
            // �ڕW���ݒ�
            //------------------------------
            for (int index = 1; index < 21; index++)
            {
                // ��
                int times = 0;

                if (!orderPointStDic.ContainsKey(index))
                {
                    continue;
                }

                OrderPointSt orderPointSt = (OrderPointSt)orderPointStDic[index];
                // �R�[�h�̐ݒ�
                if (times == 0)
                {
                    this.tEdit_WarehouseCode.DataText = orderPointSt.WarehouseCode.Trim();
                    this._prevWarehouseCode = orderPointSt.WarehouseCode.Trim();
                    this.tNedit_GoodsMGroup.SetInt(orderPointSt.GoodsMGroup);
                    this._prevGoodsMGroupCd = orderPointSt.GoodsMGroup;
                    this.tNedit_SupplierCd.SetInt(orderPointSt.SupplierCd);
                    this._prevSupplierCd = orderPointSt.SupplierCd;
                    this.tNedit_BLGloupCode.SetInt(orderPointSt.BLGroupCode);
                    this._prevBLGroupCode = orderPointSt.BLGroupCode;
                    this.tNedit_GoodsMakerCd.SetInt(orderPointSt.GoodsMakerCd);
                    this._prevMakerCode = orderPointSt.GoodsMakerCd;
                    this.tNedit_BLGoodsCode.SetInt(orderPointSt.BLGoodsCode);
                    this._prevBLGoodsCode = orderPointSt.BLGoodsCode;

                    this.tDateEdit_StckShipMonthSt.SetLongDate(orderPointSt.StckShipMonthSt);
                    this.tDateEdit_StckShipMonthEd.SetLongDate(orderPointSt.StckShipMonthEd);
                    this.tDateEdit_StockCreateDate.SetLongDate(orderPointSt.StockCreateDate);
                    this.tComboEditor_OrderApplyDiv.SelectedIndex = orderPointSt.OrderApplyDiv;
                }
                times++;

                // 0�̏���
                //if (orderPointSt.ShipScopeMore != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SHIPSCOPEMORE].Value = orderPointSt.ShipScopeMore.ToString(FORMAT_NUM);
                //}

                //if (orderPointSt.ShipScopeLess != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SHIPSCOPELESS].Value = orderPointSt.ShipScopeLess.ToString(FORMAT_NUM);
                //}

                //if (orderPointSt.MinimumStockCnt != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_MINIMUMSTOCKCNT].Value = orderPointSt.MinimumStockCnt.ToString(FORMAT_NUM);
                //}

                //if (orderPointSt.MaximumStockCnt != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_MAXIMUMSTOCKCNT].Value = orderPointSt.MaximumStockCnt.ToString(FORMAT_NUM);
                //}

                //if (orderPointSt.SalesOrderUnit != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SALESORDERUNIT].Value = orderPointSt.SalesOrderUnit.ToString(FORMAT_NUM2);
                //}

                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SHIPSCOPEMORE].Value = orderPointSt.ShipScopeMore.ToString(FORMAT_NUM);
                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SHIPSCOPELESS].Value = orderPointSt.ShipScopeLess.ToString(FORMAT_NUM);
                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_MINIMUMSTOCKCNT].Value = orderPointSt.MinimumStockCnt.ToString(FORMAT_NUM);
                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_MAXIMUMSTOCKCNT].Value = orderPointSt.MaximumStockCnt.ToString(FORMAT_NUM);
                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SALESORDERUNIT].Value = orderPointSt.SalesOrderUnit.ToString(FORMAT_NUM2);
            }
            this.Detail_uGrid.UpdateData();

            this.ScreenToOrderPointSt(ref this._orderPointStClone);
        }
        # endregion

        # region �_���폜����
        /// <summary>
        /// �_���폜�N���b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �_���폜�{�^�����N���b�N���ꂽ�Ƃ��ɔ���</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2009/04/22</br>
        /// </remarks>
        private int LogicalDeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();

            foreach (OrderPointSt orderPointSt in this._orderPointStDicClone.Values)
            {
                orderPointStList.Add(orderPointSt);
            }

            // �_���폜
            status = this._orderPointStAcs.LogicalDelete(ref orderPointStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �R���g���[��Enabled����
                        SetControlEnabled(DELETE_MODE);

                        // �o�b�t�@�X�V
                        this._orderPointStDicClone.Clear();
                        foreach (OrderPointSt orderPointSt in orderPointStList)
                        {
                            this._orderPointStDicClone.Add(orderPointSt.PatternNoDerivedNo, orderPointSt);
                        }

                        // ��ʓW�J
                        OrderPointStToScreen(this._orderPointStDicClone);

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
        # endregion �_���폜����

        # region �����폜����
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�𕨗��폜���܂��B</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2009/04/22</br>
        /// </remarks>
        private int DeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();

            foreach (OrderPointSt orderPointSt in this._orderPointStDicClone.Values)
            {
                orderPointStList.Add(orderPointSt);
            }

            // �����폜
            status = this._orderPointStAcs.Delete(orderPointStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ҏW���[�h�ύX
                        this.Mode_Label.Text = INSERT_MODE;

                        // �R���g���[��Enabled����
                        SetControlEnabled(INSERT_MODE);

                        // ��ʃN���A
                        ClearScreen(true);

                        // �o�b�t�@�X�V
                        this._orderPointStDicClone.Clear();

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
        # endregion �����폜����

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�𕜊����܂��B</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2009/04/22</br>
        /// </remarks>
        private int RevivalProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();

            foreach (OrderPointSt orderPointSt in this._orderPointStDicClone.Values)
            {
                orderPointStList.Add(orderPointSt);
            }
            // ����
            status = this._orderPointStAcs.Revival(ref orderPointStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �R���g���[��Enabled����
                        SetControlEnabled(UPDATE_MODE);

                        // �o�b�t�@�X�V
                        this._orderPointStDicClone.Clear();
                        foreach (OrderPointSt orderPointSt in orderPointStList)
                        {
                            this._orderPointStDicClone.Add(orderPointSt.PatternNoDerivedNo, orderPointSt);
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
        # endregion

        # region �r������
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �r��������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/04/23</br>
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

            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           errMsg,
                           status,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
        }
        # endregion �r������

        # region ���b�Z�[�W�{�b�N�X�\��

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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/04/23</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/04/23</br>
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
                                         this._orderPointStAcs,				// �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }

        # endregion ���b�Z�[�W�{�b�N�X�\��

        #region ������ҏW����

        /// <summary>
        /// �J���}�E�s���I�h�폜����
        /// </summary>
        /// <param name="targetText">�J���}�E�s���I�h�폜�O�e�L�X�g</param>
        /// <param name="retText">�J���}�E�s���I�h�폜�ς݃e�L�X�g</param>
        /// <param name="periodDelFlg">�s���I�h�폜�t���O(True:�J���}�E�s���I�h�폜  False:�J���}�폜)</param>
        /// <remarks>
        /// <br>Note	   : �Ώۂ̃e�L�X�g����J���}�E�s���I�h���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            if (targetText == string.Empty)
            {
                return;
            }
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
        /// <br>Note	   : �Ώۂ̃e�L�X�g���珬�������݂̂�Ԃ��܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/04/23</br>
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

        # endregion Private Method

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks>
        private void PMHAT09001UA_Load(object sender, EventArgs e)
        {
            // ��ʏ�����
            InitialScreenSetting();

            this.Detail_uGrid.DataSource = this._orderPointStDataTable;

            // ��ʃN���A����
            this.ClearScreen(true);
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        // ���͒��̃f�[�^�`���b�N
                        if (!this.CompareInputScreen())
                        {
                            return;
                        }

                        this.Close();
                        break;
                    }

                // �ۑ�
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        // �I�t���C����ԃ`�F�b�N
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "��ʕۑ������Ɏ��s���܂����B",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        SaveProc();
                        break;
                    }

                // ����
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        SearchProc();
                        break;
                    }

                // �N���A
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        this.ClearScreen(true);
                        break;
                    }
                // �_���폜
                case TOOLBAR_LOGICALDELETE_KEY:
                    {
                        // �I�t���C����ԃ`�F�b�N
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "��ʘ_���폜�����Ɏ��s���܂����B",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // �_���폜�m�F
                        // �_���폜�m�F
                        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                             "�f�[�^��_���폜���܂��B\r\n��낵���ł����H",
                                                             0,
                                                             MessageBoxButtons.OKCancel,
                                                             MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }

                        LogicalDeleteProc();
                        break;
                    }
                // �폜
                case TOOLBAR_DELETE_KEY:
                    {
                        // �I�t���C����ԃ`�F�b�N
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "��ʕ����폜�����Ɏ��s���܂����B",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // ���S�폜�m�F
                        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                             "�f�[�^�𕨗��폜���܂��B\r\n��낵���ł����H",
                                                             0,
                                                             MessageBoxButtons.OKCancel,
                                                             MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }

                        DeleteProc();
                        break;
                    }
                // ����
                case TOOLBAR_REVIVAL_KEY:
                    {
                        // �I�t���C����ԃ`�F�b�N
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "��ʕ��������Ɏ��s���܂����B",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        RevivalProc();
                        break;
                    }
                // �s�폜
                case TOOLBAR_ROWDELETE_KEY:
                    {
                        RowDelete();
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
        /// <br>Date        : 2009.04.02</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // �O���b�h
            if (e.PrevCtrl == this.Detail_uGrid)
            {
                if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                {
                    if (this.Detail_uGrid.ActiveCell == null)
                    {
                        this.Detail_uGrid.PerformAction(UltraGridAction.NextCell);
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        return;
                    }

                    int activeRowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                    int activeColumnIndex = this.Detail_uGrid.ActiveCell.Column.Index;

                    if (e.ShiftKey == false)
                    {
                        for (int rowIndex = activeRowIndex; rowIndex < ROW_COUNT; rowIndex++)
                        {
                            if (rowIndex == activeRowIndex)
                            {
                                for (int columnIndex = activeColumnIndex + 1; columnIndex < COLUMN_COUNT; columnIndex++)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                for (int columnIndex = 1; columnIndex < COLUMN_COUNT; columnIndex++)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                        }

                        // grid�̍Ō��cell
                        if ((activeRowIndex + 1 == ROW_COUNT) && (activeColumnIndex + 1 == COLUMN_COUNT))
                        {
                            e.NextCtrl = this.tNedit_PatterNo;
                            return;
                        }
                    }
                    else
                    {
                        for (int rowIndex = activeRowIndex; rowIndex >= 0; rowIndex--)
                        {
                            if (rowIndex == activeRowIndex)
                            {
                                for (int columnIndex = activeColumnIndex - 1; columnIndex >= 1; columnIndex--)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                for (int columnIndex = COLUMN_COUNT - 1; columnIndex >= 1; columnIndex--)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // �ݒ�R�[�h
            else if (e.PrevCtrl == this.tNedit_PatterNo)
            {
                // �t�H�[�J�X�ݒ�
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tEdit_WarehouseCode;
                    }
                }
                else
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.Detail_uGrid;
                        this.Detail_uGrid.Rows[ROW_COUNT - 1].Cells[COLUMN_SALESORDERUNIT].Activate();
                    }
                }

                int patterNo = this.tNedit_PatterNo.GetInt();

                // �ݒ�R�[�h���ς��Ȃ��Ƃ�
                if (patterNo == this._prevPatterNo)
                {
                    return;
                }

                // �ݒ�R�[�h����ꍇ
                if (patterNo == 0)
                {
                    // �x��
                    this.ClearScreen(true);
                    return;
                }

                if (SearchProc() != -1)
                {
                    this._prevPatterNo = patterNo;
                }
            }
            // �q�ɃR�[�h
            else if (e.PrevCtrl == this.tEdit_WarehouseCode)
            {
                // �q�ɃR�[�h�擾
                string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();

                // ���͂��Ȃ�
                if (warehouseCode == string.Empty)
                {
                    this._prevWarehouseCode = string.Empty;
                    return;
                }

                if (this._warehouseDic == null)
                {
                    // �q�Ƀ}�X�^�Ǎ�����
                    LoadWarehouse();
                }

                bool existFlag = false;

                if (this._warehouseDic.ContainsKey(warehouseCode.PadLeft(4, '0')))
                {
                    this._prevWarehouseCode = warehouseCode.PadLeft(4, '0');
                    existFlag = true;
                }
                else
                {
                    existFlag = false;
                    this.tEdit_WarehouseCode.DataText = this._prevWarehouseCode;
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "�w�肳�ꂽ�����̑q�ɃR�[�h�͑��݂��܂���ł����B"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_GoodsMGroup;
                        }
                        else
                        {
                            // �� 2009.07.07 ���m modify PVCS NO.307
                            // e.NextCtrl = this.WarehouseGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // �� 2009.07.07 ���m
                        }
                    }
                }
            }
            // �����ރR�[�h
            else if (e.PrevCtrl == this.tNedit_GoodsMGroup)
            {
                // �����ރR�[�h�擾
                int goodsMGroupCode = this.tNedit_GoodsMGroup.GetInt();

                // ���͂��Ȃ�
                if (this.tNedit_GoodsMGroup.DataText == string.Empty)
                {
                    this._prevGoodsMGroupCd = 0;
                    return;
                }

                // �����ރR�[�h�}�X�^�̌���
                if (this._goodsGroupUDic == null)
                {
                    // �����ރ}�X�^�Ǎ�����
                    LoadGoodsGroupU();
                }

                bool existFlag = false;

                if (_goodsGroupUDic.ContainsKey(goodsMGroupCode))
                {
                    this._prevGoodsMGroupCd = goodsMGroupCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;
                    this.tNedit_GoodsMGroup.SetInt(this._prevGoodsMGroupCd);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "�w�肳�ꂽ�����̒����ރR�[�h�͑��݂��܂���ł����B"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_SupplierCd;
                        }
                        else
                        {
                            // �� 2009.07.07 ���m modify PVCS NO.307
                            // e.NextCtrl = this.GoodsMGroupGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // �� 2009.07.07 ���m
                        }
                    }
                }

            }
            // �d����R�[�h
            else if (e.PrevCtrl == this.tNedit_SupplierCd)
            {
                // �d����R�[�h�擾
                int supplierCode = this.tNedit_SupplierCd.GetInt();

                // ���͂��Ȃ�
                if (this.tNedit_SupplierCd.DataText == string.Empty)
                {
                    this._prevSupplierCd = 0;
                    return;
                }

                // �d����R�[�h�}�X�^�̌���
                if (this._supplierDic == null)
                {
                    // �d����}�X�^�Ǎ�����
                    LoadSupplier();
                }

                bool existFlag = false;

                if (_supplierDic.ContainsKey(supplierCode))
                {
                    this._prevSupplierCd = supplierCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;
                    this.tNedit_SupplierCd.SetInt(this._prevSupplierCd);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "�w�肳�ꂽ�����̎d����R�[�h�͑��݂��܂���ł����B"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_BLGloupCode;
                        }
                        else
                        {
                            // �� 2009.07.07 ���m modify PVCS NO.307
                            // e.NextCtrl = this.SupplierGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // �� 2009.07.07 ���m
                        }
                    }
                }
            }
            // �O���[�v�R�[�h
            else if (e.PrevCtrl == this.tNedit_BLGloupCode)
            {
                // �O���[�v�R�[�h�擾
                int groupCode = this.tNedit_BLGloupCode.GetInt();

                // ���͂��Ȃ�
                if (this.tNedit_BLGloupCode.DataText == string.Empty)
                {
                    this._prevBLGroupCode = 0;
                    return;
                }

                // �O���[�v�R�[�h�}�X�^�̌���
                if (this._blGroupUDic == null)
                {
                    // �O���[�v�R�[�h�}�X�^�Ǎ�����
                    LoadBLGroupU();
                }

                bool existFlag = false;

                if (this._blGroupUDic.ContainsKey(groupCode))
                {
                    this._prevBLGroupCode = groupCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;

                    this.tNedit_BLGloupCode.SetInt(this._prevBLGroupCode);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "�w�肳�ꂽ�����̃O���[�v�R�[�h�͑��݂��܂���ł����B"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd;
                        }
                        else
                        {
                            // �� 2009.07.07 ���m modify PVCS NO.307
                            // e.NextCtrl = this.BLGroupGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // �� 2009.07.07 ���m
                        }
                    }
                }
            }
            // ���[�J�[�R�[�h
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
            {
                // ���[�J�[�R�[�h�擾
                int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                // ���͂��Ȃ�
                if (this.tNedit_GoodsMakerCd.DataText == string.Empty)
                {
                    this._prevMakerCode = 0;
                    return;
                }

                // ���[�J�[�R�[�h�}�X�^�̌���
                if (this._makerUMntDic == null)
                {
                    // ���[�J�[�}�X�^�Ǎ�����
                    LoadMakerUMnt();
                }

                bool existFlag = false;

                if (this._makerUMntDic.ContainsKey(makerCode))
                {
                    this._prevMakerCode = makerCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;

                    this.tNedit_GoodsMakerCd.SetInt(this._prevMakerCode);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "�w�肳�ꂽ�����̃��[�J�[�R�[�h�͑��݂��܂���ł����B"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_BLGoodsCode;
                        }
                        else
                        {
                            // �� 2009.07.07 ���m modify PVCS NO.307
                            // e.NextCtrl = this.MakerGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // �� 2009.07.07 ���m modify
                        }
                    }
                }
            }
            // BL�R�[�h
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode)
            {
                // BL�R�[�h�擾
                int bLGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                // ���͂��Ȃ�
                if (this.tNedit_BLGoodsCode.DataText == string.Empty)
                {
                    this._prevBLGoodsCode = 0;
                    return;
                }

                // BL�R�[�h�}�X�^�̌���
                if (this._blGoodsCdUMntDic == null)
                {
                    // BL�R�[�h�}�X�^�Ǎ�����
                    LoadBLGoodsCdUMnt();
                }

                bool existFlag = false;

                if (this._blGoodsCdUMntDic.ContainsKey(bLGoodsCode))
                {
                    this._prevBLGoodsCode = bLGoodsCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;

                    this.tNedit_BLGoodsCode.SetInt(this._prevBLGoodsCode);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "�w�肳�ꂽ������BL�R�[�h�͑��݂��܂���ł����B"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tDateEdit_StckShipMonthSt;
                        }
                        else
                        {
                            // �� 2009.07.07 ���m modify PVCS NO.307
                            // e.NextCtrl = this.BLGoodsCdGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // �� 2009.07.07 ���m modify
                        }
                    }
                }
            }
            // BL�K�C�h
            else if (e.PrevCtrl == this.BLGoodsCdGuide_Button)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.tDateEdit_StckShipMonthSt;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = this.tNedit_BLGoodsCode;
                    }
                }
            }
            else if (e.PrevCtrl == this.tComboEditor_OrderApplyDiv)
            {
                // �t�H�[�J�X�ݒ�
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.Detail_uGrid;
                    }
                }
            }

            if (e.NextCtrl == this.Detail_uGrid)
            {
                e.NextCtrl = null;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                    {
                        this.Detail_uGrid.Rows[0].Cells[COLUMN_SHIPSCOPEMORE].Activate();
                    }
                }
                else
                {
                    this.Detail_uGrid.Rows[ROW_COUNT].Cells[COLUMN_SALESORDERUNIT].Activate();
                }

                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }

        }

        /// <summary>
        /// Button_Click �C�x���g(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �q�ɃK�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.02</br>
        /// </remarks>
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Warehouse warehouse = null;

                int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, this._loginSectionCode);

                if (status == 0)
                {
                    // ���̓f�[�^�ƑO��f�[�^�͈Ⴂ�ꍇ
                    if (warehouse.WarehouseCode != this._prevWarehouseCode)
                    {
                        this._prevWarehouseCode = warehouse.WarehouseCode.Trim();

                        this.tEdit_WarehouseCode.DataText = warehouse.WarehouseCode.Trim();
                        this.tNedit_GoodsMGroup.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(MGroupGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �����ރK�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void MGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();

                // �����ރK�C�h�\��
                status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
                if (status == 0)
                {
                    if (goodsGroupU.GoodsMGroup != this._prevGoodsMGroupCd)
                    {
                        this._prevGoodsMGroupCd = goodsGroupU.GoodsMGroup;

                        // �����ރR�[�h
                        this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);

                        this.tNedit_SupplierCd.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �d����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                Supplier supplier = null;

                // �d����K�C�h�\��
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._loginSectionCode);
                if (status == 0)
                {
                    if (supplier.SupplierCd != this._prevSupplierCd)
                    {
                        this._prevSupplierCd = supplier.SupplierCd;

                        // �d����R�[�h
                        this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                        this.tNedit_BLGloupCode.Focus();
                    }
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
        /// <br>Note		: �O���[�v�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void GroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGroupU blGroupU = new BLGroupU();

                // BL�O���[�v�K�C�h�\��
                status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    if (blGroupU.BLGroupCode != this._prevBLGroupCode)
                    {
                        this._prevBLGroupCode = blGroupU.BLGroupCode;

                        // BL�O���[�v�R�[�h
                        this.tNedit_BLGloupCode.SetInt(blGroupU.BLGroupCode);

                        this.tNedit_GoodsMakerCd.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                MakerUMnt makerUMnt = new MakerUMnt();

                // ���[�J�[�K�C�h�\��
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if (makerUMnt.GoodsMakerCd != this._prevMakerCode)
                    {
                        this._prevMakerCode = makerUMnt.GoodsMakerCd;

                        // ���[�J�[�R�[�h
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);

                        this.tNedit_BLGoodsCode.Focus();
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(BLGoodsGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: BL�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void BLGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = null;

                // BL�R�[�h�K�C�h�\��
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    if (blGoodsCdUMnt.BLGoodsCode != this._prevBLGoodsCode)
                    {
                        this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                        // BL�R�[�h
                        this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);

                        this.tDateEdit_StckShipMonthSt.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// KeyDown�C�x���g(tNedit_PatterNo)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �ݒ�R�[�h���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void tNedit_PatterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                int patterNo = this.tNedit_PatterNo.GetInt();
                // �ݒ�R�[�h����ꍇ
                if (patterNo == 0)
                {
                    // �x��
                    this.ClearScreen(true);
                    return;
                }

                if (SearchProc() != -1)
                {
                    this._prevPatterNo = patterNo;
                }
            }
        }
        # endregion

        // ===================================================================================== //
        // Detail_uGrid�̊֘A����
        // ===================================================================================== //
        # region Detail_uGrid�̊֘A����
        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void Detail_uGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Detail_uGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.ColHeadersVisible = false;

            // �\�����ݒ�
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].Width = 45;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].Width = 130;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].Width = 130;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].Width = 130;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].Width = 130;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].Width = 110;

            //---------------------------------------------------------------------
            // ���͋��ݒ�
            //---------------------------------------------------------------------
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            // �Œ��ݒ�
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            // �l��
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // RowNo�ݒ�
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void Detail_uGrid_Leave(object sender, EventArgs e)
        {
            this.Detail_uGrid.ActiveCell = null;
            this.Detail_uGrid.ActiveRow = null;
        }

        /// <summary>
        /// �O���b�h�}�E�X�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void Detail_uGrid_MouseClick(object sender, MouseEventArgs e)
        {
            // �E�N���b�N�ȊO�̏ꍇ
            if (e.Button != MouseButtons.Right) return;

            if (this.Detail_uGrid.ActiveRow == null) return;

            System.Drawing.Point nowPos = new Point(e.X, e.Y);

            Infragistics.Win.UIElement objElement = this.Detail_uGrid.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            // �N���b�N�ʒu����w�b�_�[������
            bool isColumnHeader = false;

            if (objElement != null)
            {
                if ((objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader) ||
                    (objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement))
                {
                    isColumnHeader = true;
                    // string columnName = ((Infragistics.Win.UltraWinGrid.ColumnHeader)objElement.SelectableItem).Column.Key;
                }
            }

            if (isColumnHeader)
            {
                // ��w�b�_�[�E�N���b�N���͉������Ȃ�
            }
            else
            {
                // ����ȊO�ŉE�N���b�N���ꂽ�ꍇ�́A�ҏW�̃|�b�v�A�b�v��\������
                ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_MainMenu.Tools["PopupMenuTool_grid"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.Detail_uGrid);

                if ((this.Detail_uGrid.ActiveCell == null) && (this.Detail_uGrid.ActiveRow != null))
                {
                    if (this.Detail_uGrid.ActiveRow.Selected)
                    {
                        //
                    }
                    else
                    {
                        this.Detail_uGrid.Selected.Rows.Clear();
                        this.Detail_uGrid.ActiveRow.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Grid�f�[�^�ω��̔��f
        /// </summary>
        /// <returns>Grid�f�[�^�ω��̔��f����</returns>
        /// <remarks>
        /// <br>Note        : Grid�f�[�^�ω����鎞�������s���܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CompareDetailGrid()
        {
            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();
            ScreenToOrderPointStList(ref orderPointStList);

            if (orderPointStList.Count != this._orderPointStDicClone.Count)
            {
                return true;
            }

            foreach (OrderPointSt orderPointSt in orderPointStList)
            {
                int patternNoDerivedNo = orderPointSt.PatternNoDerivedNo;
                if (!this._orderPointStDicClone.ContainsKey(patternNoDerivedNo))
                {
                    return true;
                }

                if (orderPointSt.ShipScopeMore != this._orderPointStDicClone[patternNoDerivedNo].ShipScopeMore
                    || orderPointSt.ShipScopeLess != this._orderPointStDicClone[patternNoDerivedNo].ShipScopeLess
                    || orderPointSt.MinimumStockCnt != this._orderPointStDicClone[patternNoDerivedNo].MinimumStockCnt
                    || orderPointSt.MaximumStockCnt != this._orderPointStDicClone[patternNoDerivedNo].MaximumStockCnt
                    || orderPointSt.SalesOrderUnit != this._orderPointStDicClone[patternNoDerivedNo].SalesOrderUnit)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>Double�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��Double�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private double ChangeCellValueToDouble(object cellValue)
        {
            // cellValue�����͂��Ȃ��ꍇ
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return double.Parse((string)cellValue);
            }
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>Int�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��Int�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private int ChangeCellValueToInt(object cellValue)
        {
            // cellValue�����͂��Ȃ��ꍇ
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                double value = double.Parse((string)cellValue);
                return Convert.ToInt32(value);
            }
        }

        /// <summary>
        /// �O���b�h�̍݌ɐ��`�F�b�N����
        /// </summary>
        /// <param name="errMsg">errMsg</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̍݌ɐ��`�F�b�N�������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckGridStockCnt(ref string errMsg)
        {
            bool bstatus = true;
            int inputDataNum = 0;

            DataRowCollection rows = this._orderPointStDataTable.Rows;

            for (int i = 0; i < rows.Count; i++)
            {
                OrderPointStDataSet.OrderPointStRow row = (OrderPointStDataSet.OrderPointStRow)rows[i];

                // ���̓f�[�^���擾
                double shipScopeMore = this.ChangeCellValueToDouble(row[this._orderPointStDataTable.ShipScopeMoreColumn]);
                double shipScopeLess = this.ChangeCellValueToDouble(row[this._orderPointStDataTable.ShipScopeLessColumn]);
                double minimumStockCnt = this.ChangeCellValueToDouble(row[this._orderPointStDataTable.MinimumStockCntColumn]);
                double maximumStockCnt = this.ChangeCellValueToDouble(row[this._orderPointStDataTable.MaximumStockCntColumn]);
                int salesOrderUnit = this.ChangeCellValueToInt(row[this._orderPointStDataTable.SalesOrderUnitColumn]);

                // ���͂��Ȃ��ꍇ
                if (shipScopeMore == 0 && shipScopeLess == 0
                    && minimumStockCnt == 0 & maximumStockCnt == 0
                    && salesOrderUnit == 0)
                {
                    continue;
                }

                inputDataNum++;

                // �ȏぃ�ȉ��`�F�b�N
                if (shipScopeMore > shipScopeLess)
                {
                    errMsg = (i + 1) + "�s�ڂōݏo�א��͈̔͂̓��͂��s���ł��B";

                    bstatus = false;
                    break;
                }

                // �Œᐔ���ō���
                if (minimumStockCnt > maximumStockCnt)
                {
                    errMsg = (i + 1) + "�s�ڂōŒᐔ�ƍō����͈̔͂̓��͂��s���ł��B";

                    bstatus = false;
                    break;
                }

                // �ō��������b�g��
                if (maximumStockCnt < salesOrderUnit)
                {
                    errMsg = (i + 1) + "�s�ڂōō����ƃ��b�g���͈̔͂̓��͂��s���ł��B";

                    bstatus = false;
                    break;
                }

                // �݌ɏo�א������ׂƂ͈̔͏d���`�F�b�N
                for (int j = 0; j < i; j++)
                {
                    OrderPointStDataSet.OrderPointStRow compareRow = (OrderPointStDataSet.OrderPointStRow)rows[j];

                    double compareShipScopeMore = this.ChangeCellValueToDouble(compareRow[this._orderPointStDataTable.ShipScopeMoreColumn]);
                    double compareShipScopeLess = this.ChangeCellValueToDouble(compareRow[this._orderPointStDataTable.ShipScopeLessColumn]);
                    double compareMinimumStockCnt = this.ChangeCellValueToDouble(compareRow[this._orderPointStDataTable.MinimumStockCntColumn]);
                    double compareMaximumStockCnt = this.ChangeCellValueToDouble(compareRow[this._orderPointStDataTable.MaximumStockCntColumn]);
                    int compareSalesOrderUnit = this.ChangeCellValueToInt(compareRow[this._orderPointStDataTable.SalesOrderUnitColumn]);


                    if (compareShipScopeMore == 0
                        && compareShipScopeLess == 0
                        && compareMinimumStockCnt == 0
                        && compareMaximumStockCnt == 0
                        && compareSalesOrderUnit == 0)
                    {
                        continue;
                    }

                    // �͈͏d���`�F�b�N
                    if ((shipScopeMore >= compareShipScopeMore && shipScopeMore <= compareShipScopeLess)
                        || (shipScopeLess >= compareShipScopeMore && shipScopeLess <= compareShipScopeLess)
                        || (shipScopeMore < compareShipScopeMore && shipScopeLess > compareShipScopeLess))
                    {
                        errMsg = (i + 1) + "�s�ڂ�" + (j + 1) + "�s�ڂƏo�א��͈̔͂��d�����܂��B";

                        bstatus = false;
                        break;
                    }
                }

                if (!errMsg.Equals(""))
                {
                    bstatus = false;
                    break;
                }
            }

            if (inputDataNum == 0)
            {
                errMsg = "�ۑ��Ώۃf�[�^�����݂��܂���B";
                bstatus = false;
            }
            return bstatus;
        }

        /// <summary>
        /// AfterEnterEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z�����ҏW���[�h�ɂȂ������ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void Detail_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            if ((this.Detail_uGrid.ActiveCell.Value == DBNull.Value) ||
                ((string)this.Detail_uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            string retText;
            string targetText = (string)this.Detail_uGrid.ActiveCell.Value;

            // �J���}�̂ݍ폜
            RemoveCommaPeriod(targetText, out retText, false);

            this.Detail_uGrid.ActiveCell.Value = retText;
            this.Detail_uGrid.ActiveCell.SelStart = 0;
            this.Detail_uGrid.ActiveCell.SelLength = retText.Length;
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void Detail_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            try
            {
                if ((this.Detail_uGrid.ActiveCell.Value != DBNull.Value) &&
                     ((string)this.Detail_uGrid.ActiveCell.Value != ""))
                {
                    string retText;
                    string targetText = (string)this.Detail_uGrid.ActiveCell.Value;

                    // �J���}�̂ݍ폜
                    RemoveCommaPeriod(targetText, out retText, false);

                    double targetValue = double.Parse(retText);

                    UltraGridCell cell = this.Detail_uGrid.ActiveCell;

                    if (cell.Column.Key == this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName)
                    {
                        this.Detail_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM2);
                    }
                    else
                    {
                        this.Detail_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM);
                    }
                }
            }
            catch
            {
                this.Detail_uGrid.ActiveCell.Value = string.Empty;
            }

            //if (this.Detail_uGrid.ActiveCell.Column.Key == this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName)
            //{
            //    int intNum = ChangeCellValueToInt(this.Detail_uGrid.ActiveCell.Value);
            //    // 0�͋󔒕\��
            //    if (intNum == 0)
            //    {
            //        this.Detail_uGrid.ActiveCell.Value = string.Empty;
            //    }
            //}
            //else
            //{
            //    // ���͒l�擾
            //    double num = ChangeCellValueToDouble(this.Detail_uGrid.ActiveCell.Value);

            //    // 0�͋󔒕\��
            //    if (num == 0)
            //    {
            //       this.Detail_uGrid.ActiveCell.Value = string.Empty;
            //    }
            //}
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void Detail_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (this.Detail_uGrid.ActiveCell == null)
            {
                if (this.Detail_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.Detail_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            this.tComboEditor_OrderApplyDiv.Focus();
                        }
                        else
                        {
                            this.Detail_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex < ROW_COUNT - 1)
                        {
                            this.Detail_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (this.Detail_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.Detail_uGrid.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;

                                //if (columnIndex <= 1)
                                //{
                                //    //int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                                //    //if (targetContrastCd == 45)
                                //    //{
                                //    //    this.EnterpriseGanreGuide_Button.Focus();
                                //    //}
                                //    //else
                                //    //{
                                //    //    this.SectionGuide_Button.Focus();
                                //    //}
                                //}
                                //else
                                //{
                                //    this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                                //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //}

                                if (columnIndex == 1 && rowIndex == 0)
                                {
                                    this.tComboEditor_OrderApplyDiv.Focus();
                                }
                                else if (columnIndex == 1)
                                {
                                    this.Detail_uGrid.Rows[rowIndex - 1].Cells[COLUMN_COUNT - 1].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.Detail_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.Detail_uGrid.ActiveCell.SelStart >= this.Detail_uGrid.ActiveCell.Text.Length)
                            {
                                e.Handled = true;

                                if (columnIndex == COLUMN_COUNT - 1 && rowIndex == ROW_COUNT - 1)
                                {
                                    this.tNedit_PatterNo.Focus();
                                }
                                else if (columnIndex == COLUMN_COUNT - 1)
                                {
                                    this.Detail_uGrid.Rows[rowIndex + 1].Cells[1].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void Detail_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.Detail_uGrid.ActiveCell;

            // ActiveCell�����b�g�̏ꍇ
            if (cell.Column.Key == this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            else
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(9, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note        : ���l�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        # region �s�̍폜�����̊֘A����
        /// <summary>
        /// �s�폜����
        /// </summary>
        private void RowDelete()
        {
            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "�I���s���폜���Ă���낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            int rowIndex = this.GetActiveRowIndex();

            if (rowIndex == -1)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._orderPointStDataTable.BeginLoadData();
                OrderPointStDataSet.OrderPointStRow targetRow = (OrderPointStDataSet.OrderPointStRow)this._orderPointStDataTable.Rows[rowIndex];
                this._orderPointStDataTable.RemoveOrderPointStRow(targetRow);

                this.InitializeDetailRowNoColumn();

                this.FillDetailRow();

                this._orderPointStDataTable.EndLoadData();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ActiveRow�C���f�b�N�X�擾����
        /// </summary>
        /// <returns>ActiveRow�C���f�b�N�X</returns>
        private int GetActiveRowIndex()
        {
            if (this.Detail_uGrid.ActiveCell != null)
            {
                return this.Detail_uGrid.ActiveCell.Row.Index;
            }
            else if (this.Detail_uGrid.ActiveRow != null)
            {
                return this.Detail_uGrid.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// ���׃f�[�^�e�[�u��RowNo�񏉊�������
        /// </summary>
        public void InitializeDetailRowNoColumn()
        {
            this._orderPointStDataTable.BeginLoadData();
            for (int i = 0; i < this._orderPointStDataTable.Rows.Count; i++)
            {
                if (this._orderPointStDataTable[i].RowNo != 0)
                {
                    // ���̍s�ԍ����V�����s�ԍ����擾����
                    this._orderPointStDataTable[i].RowNo = i + 1;
                }
            }
            this._orderPointStDataTable.EndLoadData();
        }

        /// <summary>
        /// ���׍s�ǉ�����
        /// </summary>
        public void FillDetailRow()
        {
            int rowCount = this._orderPointStDataTable.Rows.Count;

            for (int index = rowCount; index < ROW_COUNT; index++)
            {
                OrderPointStDataSet.OrderPointStRow row = this._orderPointStDataTable.NewOrderPointStRow();
                row.RowNo = index + 1;
                this._orderPointStDataTable.AddOrderPointStRow(row);
            }
        }
        # endregion �s�̍폜�����̊֘A����
        # endregion

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>				
        /// ���O�I�����I�����C����ԃ`�F�b�N����				
        /// </summary>				
        /// <returns>�`�F�b�N��������</returns>				
        public static bool CheckOnline()
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
        private static bool CheckRemoteOn()
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
    }
}