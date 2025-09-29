//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Ώۓ��Ӑ�ݒ���
// �v���O�����T�v   : �Ώۓ��Ӑ�ݒ���
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/05/20  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �Ώۓ��Ӑ�ݒ��ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ώۓ��Ӑ�ݒ��ʂ��s���܂��B</br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2011/05/20</br>
    /// </remarks>
    public partial class PMKHN09631UB : Form
    {

        # region Private Constant

        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_UPDATEBUTTON_KEY = "ButtonTool_Update";
       
        // UI��Grid�\���p
        private const string MY_SCREEN_CUSTOMER_CODE = "CustomerCode";
        private const string MY_SCREEN_CUSTOMER_NAME = "CustomerName";
        private const string MY_SCREEN_ODER = "NO";
        private const string MY_SCREEN_GUID = "CustomerGuid";
        private const string MY_SCREEN_TABLE = "MY_SCREEN_TABLE";
        private const string I_CAMPAIGN_TABLE = "CAMPAIGN_TABLE";
        
        // �A�Z���u�����
        private const string PG_ID = "PMKHN09531U";
        private const string PG_NAME = "�Ώۓ��Ӑ�ݒ�";
      
        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// �X�V�{�^��
        private string _enterpriseCode;
        private bool _gridUpdFlg = true;�@�@�@�@�@�@�@�@�@�@// Grid�ύX�t���O
        private CustomerInfoAcs _customerInfoAcs = null;    // ���Ӑ���A�N�Z�X�N���X
        private CampaignLinkDataSet.CampaignLinkDataTable _campaignLinkDataTable;
        private PMKHN09631UA _PMKHN09631UA = null;
        private Image _guideButtonImage;
        private int _customerCode;�@�@�@�@�@�@�@�@�@�@�@�@   // ���Ӑ���_�C�A���O
        private ArrayList _customerList;�@�@�@�@�@�@�@�@�@�@// ���Ӑ���L���b�V��
        private string _customerName;
        private int campaignLinkFlag = -1;
        private CampaignLinkWork _campaignLinkWork = null;
        private int _closeFlag = -1;

        #endregion
        
        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region�@Constructor
        /// <summary>
        /// �Ώۓ��Ӑ�ݒ��ʃt�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �Ώۓ��Ӑ�ݒ��ʃt�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        public PMKHN09631UB()
        {
            InitializeComponent();
            
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_UPDATEBUTTON_KEY];
         
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; ;
            this._customerInfoAcs = new CustomerInfoAcs();
            this._PMKHN09631UA = new PMKHN09631UA();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //�L���b�V�����擾
            this.GetCacheData();

            this._campaignLinkDataTable = new CampaignLinkDataSet.CampaignLinkDataTable();
            this.uGrid_Customer.DataSource = this._campaignLinkDataTable;
            ScreenInitialSetting();
       
            CampaignLinkToCampaignLinklist();
            this.campaignLinkFlag = this._campaignLinkDataTable.Rows.Count;
        }

        /// <summary>
        /// �L�����y�[�������NTO�L�����y�[�������N���X�g
        /// </summary>
        public void CampaignLinkToCampaignLinklist()
        {
            if (this._PMKHN09631UA._campaignGoodsStAcs._precampaignLinkList == null)
            {
                ScreenReconstruction();
                return;
            }

            foreach (CampaignLinkWork work in this._PMKHN09631UA._campaignGoodsStAcs._precampaignLinkList)
            {

                CampaignLinkDataSet.CampaignLinkRow row = this._campaignLinkDataTable.NewCampaignLinkRow();
                row.CustomerCode = work.CustomerCode.ToString("00000000");
                this._campaignLinkDataTable.AddCampaignLinkRow(row);
            }

            // �X�V���[�h
            this.Mode_Label.Text = UPDATE_MODE;

            // ��ʓW�J����
            CampaignLinkToScreen();
            DataUpdate();
        }

        #endregion

        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region�@Private Methods

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            ToolBarInitilSetting();

            GridInitialSetting();�@�@�@�@// GRID�̏����ݒ�
        }

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������A�c�[���o�[�����ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
        }

        /// <summary>
        /// �O���g�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ̃O���g�ݒ���s���܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // �O���b�h�̔w�i�F
            this.uGrid_Customer.DisplayLayout.Appearance.BackColor = Color.White;
            this.uGrid_Customer.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.uGrid_Customer.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �s�̒ǉ��s��
            this.uGrid_Customer.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // �s�̃T�C�Y�ύX�s��
            this.uGrid_Customer.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // �s�̍폜�s��
            this.uGrid_Customer.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // ��̈ړ��s��
            this.uGrid_Customer.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            this.uGrid_Customer.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // ��̌����s��
            this.uGrid_Customer.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // �t�B���^�̎g�p�s��
            this.uGrid_Customer.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �^�C�g���̊O�ϐݒ�
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // �O���b�h�̑I����@��ݒ�i�Z���P�̂̑I���̂݋��j
            this.uGrid_Customer.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Customer.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // �݂��Ⴂ�̍s�̐F��ύX
            this.uGrid_Customer.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // �s�Z���N�^�\������
            this.uGrid_Customer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.uGrid_Customer.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid_Customer.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // �uID�v�͕ҏW�s�i�Œ荀�ڂƂ��Đݒ�j
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].TabStop = false;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.ForeColor = Color.White;

            // ���Ӑ�R�[�h��̐ݒ�
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellActivation = Activation.AllowEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].TabStop = true;

            // �K�C�h�{�^���̐ݒ�
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].TabStop = true;

            // BL�i����̐ݒ�
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].CellActivation = Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].TabStop = false;

            // �Z���̕��̐ݒ�
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].Width = 50;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].Width = 100;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Width = 20;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].Width = 380;

            // �I���s�̊O�ϐݒ�
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // �A�N�e�B�u�s�̊O�ϐݒ�
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // �s�Z���N�^�̊O�ϐݒ�
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �r���̐F��ύX
            this.uGrid_Customer.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
        }

        /// <summary>
        /// �Ώۓ��Ӑ�ݒ� �N���X��ʓW�J����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �Ώۓ��Ӑ�ݒ� �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private void CampaignLinkToScreen()
        {
            int i = 0;
            string NameValue = string.Empty;
            int maxRow = this._campaignLinkDataTable.Rows.Count;
            if (maxRow > 0)
            {
                NameValue = this._campaignLinkDataTable.Rows[maxRow - 1]["CustomerCode"].ToString();
                if (NameValue == string.Empty)
                {
                    maxRow = maxRow - 1;
                }
            }
            // ���Ӑ���
            for (i = 0; i < maxRow; i++)
            {

                this._campaignLinkDataTable.Rows[i]["NO"] = i + 1;// �\������

                this._campaignLinkDataTable.Rows[i]["CustomerName"] = GetCustomerName(Convert.ToInt32(this._campaignLinkDataTable.Rows[i]["CustomerCode"]));   // ���Ӑ於
            }
            if (maxRow > 0)
            {
                this.uGrid_Customer.Rows[0].Selected = false;
                this.uGrid_Customer.ActiveCell = null;
                this.uGrid_Customer.ActiveRow = null;
            }

        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note		: ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            return GetCustomerName(customerCode, false);
        }

        /// <summary>
        /// ���Ӑ於�̂��擾���܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="throwsExceptionWhenCodeIsNotFound">�Y�����链�Ӑ�R�[�h���Ȃ��ꍇ�A��O�𓊓�����t���O</param>
        /// <returns>���Ӑ於��</returns>
        /// <exception cref="ArgumentException">
        /// <c>throwsExceptionWhenCodeIsNotFound</c>��<c>true</c>�̂Ƃ��A
        /// ���Ӑ�}�X�^�ɊY�����链�Ӑ�R�[�h�����݂��Ȃ��ꍇ�A��������܂��B
        /// </exception>
        /// <remarks>
        /// <br>Note		: ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private string GetCustomerName(
            int customerCode,
            bool throwsExceptionWhenCodeIsNotFound
        )
        {
            string customerName = string.Empty;
            CustomerInfo customerInfo = new CustomerInfo();

            bool codeIsFound = false;
            try
            {
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode && customerSearchRet.LogicalDeleteCode == 0)
                    {
                        codeIsFound = true;
                        customerName = customerSearchRet.Snm.Trim();
                        break;
                    }
                }

                if (customerName == "")
                {
                    int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        codeIsFound = true;
                        customerName = customerInfo.CustomerSnm.Trim();
                    }
                }
            }
            catch
            {
                customerName = string.Empty;
            }

            if (!codeIsFound && throwsExceptionWhenCodeIsNotFound)
            {
                throw new ArgumentException("customerCode(=" + customerCode.ToString() + ") is not found.");
            }

            return customerName;
        }


        /// <summary>
        /// �L���b�V�����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�̖��̂��L���b�V�����B</br>
        /// </remarks>
        private void GetCacheData()
        {
            // ���Ӑ於�̃��X�g�擾
            this.GetCustomerNameList();

        }

        /// <summary>
        /// ���Ӑ於�̃��X�g�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂̃��X�g���擾���܂��B</br>
        /// </remarks>
        private void GetCustomerNameList()
        {
            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;
            this._customerList = new ArrayList();

            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                {
                    // �_���폜�f�[�^�͓ǂݍ��܂Ȃ�
                    if (customerSearchRet.LogicalDeleteCode != 1)
                    {
                        this._customerList.Add(customerSearchRet);
                    }
                }
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            _customerCode = 0;
            _customerName = "";

            if (customerSearchRet == null)
            {
                return;
            }

            // ���Ӑ�R�[�h
            _customerCode = customerSearchRet.CustomerCode;

            // ���Ӑ於��
            _customerName = customerSearchRet.Snm.Trim();
        }


        private void SetGridColVisible()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Customer.DisplayLayout.Bands[0];
            if (editBand == null) return;


            CampaignLinkDataSet.CampaignLinkDataTable table = this._campaignLinkDataTable;
            ColumnsCollection columns = editBand.Columns;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
            }

            columns[table.NOColumn.ColumnName].Hidden = false;
            columns[table.CustomerCodeColumn.ColumnName].Hidden = false;
            columns[table.CustomerGuidColumn.ColumnName].Hidden = false;
            columns[table.CustomerNameColumn.ColumnName].Hidden = false;

        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	���̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// <br></br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Customer.ActiveCell != null))
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
                            int rowIdx = this.uGrid_Customer.ActiveCell.Row.Index;
                            if ((this._campaignLinkDataTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "") &&
                                (this._gridUpdFlg))
                            {
                                // ���Ӑ�R�[�h�������͂̏ꍇ(���Ӑ�R�[�h�擾���s���͏���)
                                break;
                            }
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        ///	Grid �V�K�s�̒ǉ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�ɐV�K�s��ǉ����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void tbsPartsList_AddRow()
        {
            if (this._campaignLinkDataTable.Rows.Count == 99)
            {
                // MAX99�s�Ƃ���
                return;
            }

            // �K�C�h�őI���������Ӑ�R�[�h��ǉ�
            CampaignLinkDataSet.CampaignLinkRow row = this._campaignLinkDataTable.NewCampaignLinkRow();

            row["NO"] = this._campaignLinkDataTable.Rows.Count + 1;
            row["CustomerCode"] = "";
            row["CustomerName"] = "";

            this._campaignLinkDataTable.AddCampaignLinkRow(row);
        }


        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            int recordCount = this._campaignLinkDataTable.Rows.Count;
            string NameValue = string.Empty;
            if (recordCount > 0)
            {
                NameValue = this._campaignLinkDataTable.Rows[recordCount - 1]["CustomerCode"].ToString();
            }

            if (this._campaignLinkDataTable.Rows.Count < 1)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                if (recordCount == 0)
                {
                    // �O���b�h�s��ǉ�
                    this.tbsPartsList_AddRow();
                }
            }
            else
            {
                // �X�V���[�h
                this.Mode_Label.Text = UPDATE_MODE;

                if (NameValue != string.Empty)
                {
                    this.tbsPartsList_AddRow();
                }
            }
        }

        /// <summary>
        /// ��̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z������̃Z���Ɉړ����܂��B</br>
        /// <br></br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;


            // ��̃Z���Ɉړ�
            performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
            if (performActionResult)
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            return null;
        }
        /// <summary>
        /// ���̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
        /// <br></br>
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;


            // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
            int prevCol = this.uGrid_Customer.ActiveCell.Column.Index;
            int prevRow = this.uGrid_Customer.ActiveCell.Row.Index;

            // ���̃Z���Ɉړ�
            performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
            if (performActionResult)
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            return null;
        }


        /// <summary>
        /// ��ʍX�V
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void DataUpdate()
        {
            
            int maxRow = this._campaignLinkDataTable.Rows.Count;
            string NameValue = string.Empty;
            string campaignCodeValue=string.Empty;
            int AddRow = maxRow;
            _closeFlag = -1;
            ArrayList addCampaignList = new ArrayList();

            // ���Ӑ���
            for (int i = 0; i < maxRow; i++)
            {
                campaignCodeValue = this._campaignLinkDataTable.Rows[i]["CustomerCode"].ToString();
                if (campaignCodeValue != string.Empty)
                {
                   _campaignLinkWork = new CampaignLinkWork();
                   _campaignLinkWork.CustomerCode = Convert.ToInt32(this._campaignLinkDataTable.Rows[i]["CustomerCode"]);
                   addCampaignList.Add(_campaignLinkWork);
                }
                
            }

            if (addCampaignList.Count == 0)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���Ӑ�R�[�h���o�^����Ă��܂���B",
                            -1,
                            MessageBoxButtons.OK);
                _closeFlag = 1;

            }
            else
            {
                this._PMKHN09631UA._campaignGoodsStAcs._precampaignLinkList = addCampaignList;
            }

        }

        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Customer.ActiveCell != null))
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
                            int rowIdx = this.uGrid_Customer.ActiveCell.Row.Index;
                            if (this._campaignLinkDataTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                            {
                                // ���Ӑ�R�[�h�������͂̏ꍇ
                                break;
                            }
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }
        #endregion
        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region Control Event Methods

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09631UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Customer.DataSource = this._campaignLinkDataTable;
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // �I������
                        Close();

                        break;
                    }
                // �X�V
                case TOOLBAR_UPDATEBUTTON_KEY:
                    {
                        this.uGrid_Customer_AfterExitEditMode(sender, e);
                        this.DataUpdate();
                        if (_closeFlag != 1)
                        {
                            Close();
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void DeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this._campaignLinkDataTable.Rows.Count < 1)
            {
                 //�f�o�b�O�p
                 this.tbsPartsList_AddRow();
            }

            if (this.uGrid_Customer.ActiveRow == null)
            {
                // �폜����s�����I��
                message = "�폜���链�Ӑ�R�[�h��I�����ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.uGrid_Customer.Focus();
            }
            else if (this.uGrid_Customer.Rows.Count == 1)
            {
                // Grid�̍s����1�s�̏ꍇ�͍폜�s��
                message = "�S�Ă̓��Ӑ���폜�͂ł��܂���";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.uGrid_Customer.Focus();
            }
            else
            {
                // UI��ʂ�Grid����I���s���폜
                // �I���s��index���擾
                int delIndex = (int)this.uGrid_Customer.ActiveRow.Cells[MY_SCREEN_ODER].Value - 1;

                // �I���s�̍폜
                this.uGrid_Customer.ActiveRow.Delete();

                // �폜���Grid�s�����擾
                int maxRow = this._campaignLinkDataTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // �폜�����s�ȍ~�̕\�����ʂ��X�V����
                    this._campaignLinkDataTable.Rows[index][MY_SCREEN_ODER] = index + 1;
                }
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Guid_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Guid_Button_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult res = customerSearchForm.ShowDialog(this);

            if (res.Equals(System.Windows.Forms.DialogResult.Cancel))
            {
                _customerCode = 0;
            }

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._campaignLinkDataTable.Rows.Count;

                // ���Ӑ�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    string code = this._campaignLinkDataTable.Rows[i][MY_SCREEN_CUSTOMER_CODE].ToString();
                    if ((code != "") && (int.Parse(code) == _customerCode))
                    {
                        // �d���R�[�h�L
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    int lastRow = this._campaignLinkDataTable.Rows.Count - 1;

                    if (this._campaignLinkDataTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                    {
                        // �ŏI�s����
                        this._campaignLinkDataTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE] = _customerCode.ToString("d08");
                        this._campaignLinkDataTable.Rows[lastRow][MY_SCREEN_CUSTOMER_NAME] = _customerName;
                    }
                    else
                    {
                        // �K�C�h�őI���������Ӑ�R�[�h��ǉ�
                        CampaignLinkDataSet.CampaignLinkRow row = this._campaignLinkDataTable.NewCampaignLinkRow();

                        row["NO"] = this._campaignLinkDataTable.Rows.Count + 1;
                        row["CustomerCode"] = _customerCode.ToString("d08"); ;
                        row["CustomerName"] = _customerName;

                        this._campaignLinkDataTable.AddCampaignLinkRow(row);
                    }

                    // �V�K�s��ǉ�
                    this.tbsPartsList_AddRow();

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else 
                {

                    // �d���G���[��\��
                    string message = "�I���������Ӑ�R�[�h�͑I���ςł��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    ((Control)sender).Focus();

                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }
        /// <summary>
        /// Control.VisibleChange �C�x���g(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_VisibleChanged(object sender, System.EventArgs e)
        {
            // �A�N�e�B�u�Z���E�A�N�e�B�u�s�𖳌�
            this.uGrid_Customer.ActiveCell = null;
        }

        /// <summary>
        /// Timer.Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            ScreenReconstruction();�@�@�@// ��ʍč\�z����
        }

        private void uGrid_Customer_ClickCellButton(object sender, CellEventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult res = customerSearchForm.ShowDialog(this);

            if (res.Equals(System.Windows.Forms.DialogResult.Cancel))
            {
                _customerCode = 0;
            }
         
            if (_customerCode != 0)
            {
                bool AddFlg = true;     // �ǉ��t���O

                int maxRow = this._campaignLinkDataTable.Rows.Count;

                // ���Ӑ�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    string code = (string)this._campaignLinkDataTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                    if (code == "")
                    {
                        continue;
                    }

                    int customerCode = Int32.Parse(code);
                    if (customerCode == _customerCode)
                    {
                        // �d���R�[�h�L
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // �I����������Cell�ɐݒ�
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = _customerCode.ToString("d08");    // ���Ӑ�R�[�h
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = _customerName;                    // ���Ӑ於

                    if ((int)e.Cell.Row.Cells[MY_SCREEN_ODER].Value == this._campaignLinkDataTable.Rows.Count)
                    {
                        // �ŏI�s�̏ꍇ�A�s��ǉ�
                        this.tbsPartsList_AddRow();
                    }

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.MoveNextAllowEditCell(false);
                }
                else
                {
                    // �d���G���[��\��
                    TMsgDisp.Show(
                        this,								    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                        PG_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�I���������Ӑ�R�[�h���d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				    // �\������{�^��

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }


        /// <summary>
        ///	ultraGrid.AfterExitEditMode �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃Z���ҏW�I���C�x���g�����B</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Customer.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Customer.ActiveCell;

            // ���Ӑ�R�[�h
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                string code = cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Text;
                this._gridUpdFlg = true;

                int customerCode = 0;
                string customerName = "";
                try
                {
                    // ���͗L
                    customerCode = int.Parse(code);
                    customerName = GetCustomerName(customerCode);

                }
                catch
                {
                    customerCode = 0;
                    customerName = "";
                }
                if (customerCode == 0)
                {
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";                    // ���Ӑ�R�[�h
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";                   // ���Ӑ�i��
                }
                else if (customerName != "")
                {
                    bool AddFlg = true;     // �ǉ��t���O
                    int maxRow = this._campaignLinkDataTable.Rows.Count;

                    // ���Ӑ�R�[�h�̏d���`�F�b�N
                    for (int i = 0; i < maxRow; i++)
                    {
                        if (cell.Row.Index == i)
                        {
                            // �����s����SKIP
                            continue;
                        }

                        string wkTbsPartsCode = this._campaignLinkDataTable.Rows[i][MY_SCREEN_CUSTOMER_CODE].ToString();
                        if ((wkTbsPartsCode != "") && (int.Parse(wkTbsPartsCode) == customerCode))
                        {
                            // �d���R�[�h�L
                            AddFlg = false;
                            break;
                        }
                    }

                    if (AddFlg)
                    {
                        // ���Ӑ�R�[�h�̒ǉ�
                        // �I����������Cell�ɐݒ�
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = customerCode.ToString("d08");   // ���Ӑ�R�[�h
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = customerName;                   // ���Ӑ�i��

                        if ((int)cell.Row.Cells[MY_SCREEN_ODER].Value == this._campaignLinkDataTable.Rows.Count)
                        {
                            // �ŏI�s�̏ꍇ�A�s��ǉ�
                            this.tbsPartsList_AddRow();
                        }
                    }
                    else
                    {
                        // �d���G���[��\��
                        TMsgDisp.Show(
                            this,								    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                            PG_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            "�I���������Ӑ�R�[�h���d�����Ă��܂��B",	    // �\�����郁�b�Z�[�W 
                            0,									    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				    // �\������{�^��

                        // ���Ӑ�R�[�h�A���Ӑ於���N���A
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // ���Ӑ�R�[�h
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // ���Ӑ於

                        // Grid�ύX�Ȃ�
                        this._gridUpdFlg = false;
                    }
                }
                else
                {
                    // �_���폜�f�[�^�͐ݒ�s��
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���Ӑ�R�[�h [" + customerCode.ToString("d08") + "] �ɊY������f�[�^�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    // ���Ӑ�R�[�h�A���Ӑ於���N���A
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // ���Ӑ�R�[�h
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // ���Ӑ於

                    // Grid�ύX�Ȃ�
                    this._gridUpdFlg = false;
                }              
            }
        }

        /// <summary>
        /// Control.KeyDown �C�x���g (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // �A�N�e�B�u�Z����null�̎��͏������s�킸�I��
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return;
            }

            // �O���b�h��Ԏ擾()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

            //�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ���L�[
                    case Keys.Up:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = MoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Down:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = MoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Left:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = MoveAboveCell();
                            e.Handled = true;

                            break;
                        }
                    // ���L�[
                    case Keys.Right:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = MoveBelowCell();
                            e.Handled = true;

                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.uGrid_Customer.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                uGrid_Customer_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                    case Keys.F3:
                        {
                            //�폜�{�^�����N���b�N
                            this.DeleteRow_Button_Click(sender,e);
                            break;
                        }
                    case Keys.F5:
                        {
                            //�K�C�h�{�^�����N���b�N
                            this.Guid_Button_Click(sender, e);
                            break;
                        }
                }

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃L�[�����C�x���g�����B</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Customer.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Customer.ActiveCell;

            // ���Ӑ�R�[�h�̓��͌����`�F�b�N
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
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
        /// <param name="NumberFlg">���l���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// Note			:	�����ꂽ�L�[�����l�̂ݗL���ɂ��鏈�����s���܂��B<br />
        /// <br></br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            // �����ꂽ�L�[�����l�ȊO�A�����l�ȊO���͕s��
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                // �}�C�i�X(�����_)�����͉\���H
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                // �����_�ȉ�������0���H
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // �����_�����ɑ��݂��邩�H
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // �����_�����ɑ��݂��邩�H
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // �����������͉\�����ȏ�ŁA�J�[�\���ʒu�������_�ȍ~
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // �������̌��������͉\�����𒴂���
                        return false;
                    }
                }
                else
                {
                    // �����_������O��ɐ������̌���������
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart) + key
                       + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ���^�[���L�[�ړ��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���^�[���L�[�������̐�����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "DeleteRow_Button":            // GRID�폜�{�^��
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        this.uGrid_Customer.Rows[0].Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                                        this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "uGrid_Customer":      // �O���b�h
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �K�C�h�{�^���Ƀt�H�[�J�X������
                                        if (this.uGrid_Customer.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

                                            if ((this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // �Z���̃X�^�C�����{�^���ŁA�Z���̍ŏI�s�̏ꍇ
                                                if ((int)this.uGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_ODER].Value == this._campaignLinkDataTable.Rows.Count)
                                                {
                                                    // �ŏI�s�̏ꍇ�A�s��ǉ�
                                                    this.tbsPartsList_AddRow();
                                                }
                                            }
                                        }

                                        // ���̃Z���ֈړ�
                                        bool moveFlg = this.MoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (!this._gridUpdFlg)
                                        {
                                            this.MovePrevAllowEditCell(false);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if (this.MovePrevAllowEditCell(false))
                                        {
                                            // �O���b�h���̃t�H�[�J�X����
                                            e.NextCtrl = null;
                                        }

                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
          
        }

        # endregion

    }
}