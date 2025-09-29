using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.IO;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d���`�[�������[�U�[�R���g���[���N���X
	/// </summary>
    /// <remarks>
    /// <br>Update Note: 2015/02/04 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
    /// <br>           : �n���h���G���[���o���Q�̍ďC��</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/12 30757 ���X�� �M�p</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
    /// <br>           : �V�X�e���e�X�g��Q�Ή��F�V�K�{�^���������Ɏd���`�[�������ʂ��N���A������Q�Ή�</br>
    /// <br></br>
    /// </remarks>
    internal partial class SFCMN00221UI : System.Windows.Forms.UserControl
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// �d���`�[�����t�H�[���N���X�̃f�t�H���g�R���X�g���N�^
		/// </summary>
		public SFCMN00221UI(ControlScreenSkin controlScreenSkin)
		{
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			InitializeComponent();

			// �ϐ�������
			this._searchSlipAcs = new SearchSlipAcs();
			this._customerSearchAcs = new CustomerSearchAcs();
			this._searchParaStockSlip = new SearchParaStockSlip();
			this._employeeAcs = new EmployeeAcs();
			this._warehouseAcs = new WarehouseAcs();
			this._goodsAcs = new GoodsAcs();
            this._supplierAcs = new SupplierAcs();

			// �X�L���ݒ�
			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Condition.Name);
			controlScreenSkin.SetExceptionCtrl(ctrlNameList);
			controlScreenSkin.SettingScreenSkin(this);

			try
			{
				this.uExplorerBar_Condition.Appearance.BackColor = controlScreenSkin.GetControlAppearance().BackColor;
			}
			catch (NullReferenceException) { }

            uiSetControl1.SettingFormBeforeLoad();
		}

        // --- ADD 杍^ 2015/02/04 ------ >>>
        /// <summary>
        /// ���������b�\�h�i�R���|�|�l���g�����j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
        /// <br>             �R���|�[�l���g�n���h�������G���[�Ή��i�āj</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2015/02/04 </br>
        /// <br></br>
        /// <br>Update Note: 2015/02/12 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
        /// <br>           : �V�X�e���e�X�g��Q�Ή��F�V�K�{�^���������Ɏd���`�[�������ʂ��N���A������Q�Ή�</br>
        /// <br></br>
        /// </remarks>
        public void InitForNoComponent()
        {
            // �ϐ�������
            // --- DEL 30757 ���X�� �M�p 2015/02/12 �V�X�e���e�X�g��Q�Ή��F�V�K�{�^���������Ɏd���`�[�������ʂ��N���A������Q�Ή�------ >>>
            //this._searchSlipAcs = new SearchSlipAcs();
            // --- DEL 30757 ���X�� �M�p 2015/02/12 �V�X�e���e�X�g��Q�Ή��F�V�K�{�^���������Ɏd���`�[�������ʂ��N���A������Q�Ή�------ <<<
            // --- ADD 30757 ���X�� �M�p 2015/02/12 �V�X�e���e�X�g��Q�Ή��F�V�K�{�^���������Ɏd���`�[�������ʂ��N���A������Q�Ή�------ >>>
            if (null == this._searchSlipAcs)
            {
                this._searchSlipAcs = new SearchSlipAcs();
            }
            // --- ADD 30757 ���X�� �M�p 2015/02/12 �V�X�e���e�X�g��Q�Ή��F�V�K�{�^���������Ɏd���`�[�������ʂ��N���A������Q�Ή�------ <<<
            this._customerSearchAcs = new CustomerSearchAcs();
            this._searchParaStockSlip = new SearchParaStockSlip();
            this._employeeAcs = new EmployeeAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._goodsAcs = new GoodsAcs();
            this._supplierAcs = new SupplierAcs();

            // �ϐ�������
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;		// ��ƃR�[�h���擾
            this._secInfoAcs = new SecInfoAcs();

             //�O���b�h�Ƀf�[�^�Z�b�g���o�C���h
            this.uGrid_Search.DataSource = this._searchSlipAcs.DataSet.StockSlip.DefaultView;
        }
        // --- ADD 杍^ 2015/02/04 ------ <<<

        // --- DEL 杍^ 2015/02/04 ------ >>>
        // --- ADD 杍^ 2014/11/01 ------ >>>
        /// <summary>
        /// �����[�X����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����[�X�������s���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/11/01</br>
        /// </remarks>
        //public void DisposeForm()
        //{
        //    this._searchSlipAcs = null;
        //    this._customerSearchAcs = null;
        //    this._searchParaStockSlip = null;
        //    this._employeeAcs = null;
        //    this._warehouseAcs = null;
        //    this._goodsAcs = null;
        //    this._supplierAcs = null;

        //    GC.Collect();
        //}
        // --- ADD 杍^ 2014/11/01 ------ <<<
        // --- DEL 杍^ 2015/02/04 ------ <<<
		# endregion

		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		# region public static readonly
		public static readonly int EDIT_TYPE_StockDate = 1;									// �d����
		public static readonly int EDIT_TYPE_InputDay = 2;									// ���͓�
		public static readonly int EDIT_TYPE_SupplierSlipNo = 3;							// �`�[�ԍ�
		public static readonly int EDIT_TYPE_StockAgentCode = 4;							// �d���S��
		public static readonly int EDIT_TYPE_CustomerCode = 5;								// �d����R�[�h
		//public static readonly int EDIT_TYPE_CarrierEpCode = 6;								// ���Ǝ҃R�[�h
		public static readonly int EDIT_TYPE_WarehouseCode = 7;								// �q�ɃR�[�h
		public static readonly int EDIT_TYPE_PartySaleSlipNum = 8;							// �����`��
		public static readonly int EDIT_TYPE_GoodsCode = 21;								// ���i�R�[�h
		public static readonly int EDIT_TYPE_StockTelNo1 = 22;								// ���i�d�b�ԍ�
		//public static readonly int EDIT_TYPE_ProductNumber1 = 23;							// �����ԍ�
		# endregion

		// ===================================================================================== //
		// �����Ŏg�p����萔�Q
		// ===================================================================================== //
		# region Const
		private const int DEFAULT_EDIT_WIDTH = 224;
		private const int GUIDE_WIDTH_DIFFERENCE = 26;
		private const int CONDITION_PANEL_SECTION_ON = 32;
		private const int CONDITION_PANEL_HEIGHT_DEFAULT = 177;
		private const int CONDITION_PANEL_HEIGHT_SLIPDATE = 195;

		private const int INDEX_MakerCode = 0;
		private const int INDEX_AiraMakerCode = 1;
		private const int INDEX_ModelCode = 2;
		private const int INDEX_ModelSubCode = 3;
		
		private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă��������B";

		private readonly Color COLOR_REDSLIP = Color.Red;					// �ԓ`��ʐF
		private readonly Color COLOR_OFFSETBLACKSLIP = Color.DarkOrchid;	// ���E�ςݍ��`��ʐF

		private const string FILENAME_COLDISPLAYSTATUS = "SFCMN00221U_ColSetting2.DAT";				// ��\����ԃZ�b�e�B���OXML�t�@�C����
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = "";								// ��ƃR�[�h
		private int _xmlNo = 0;
		private NoMngSetAcs _noMngSetAcs;
		private SFCMN00221UL customControl_ExtractWait;
		private SecInfoAcs _secInfoAcs;
		private string _ownSectionCode = "";
		private bool _sectionOption	= false;
		private Color _enabledColor = Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
		private ColDisplayStatusList _colDisplayStatusList;					// ��\����ԃR���N�V�����N���X
		private bool _isInitial = true;										// �����t���O
		private SearchSlipAcs _searchSlipAcs;
		private CustomerSearchAcs _customerSearchAcs;
		private SearchParaStockSlip _searchParaStockSlip;
		private EmployeeAcs _employeeAcs;
		private WarehouseAcs _warehouseAcs;
		private GoodsAcs _goodsAcs;
        private SupplierAcs _supplierAcs;
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		/// <summary>�p�l���ύX�C�x���g</summary>
		internal event PanelChangeEventHandler PanelChange;

		/// <summary>�d���`�[�I���C�x���g</summary>
		internal event SearchRetStockSlipSelectedHandler SearchRetStockSlipSelected;
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// �����ݒ菈��
		/// </summary>
		/// <param name="param">�N���p�����[�^</param>
		internal void InitialSetting(SFCMN00221UAParam param)
		{
			if (this._isInitial)
			{
				// ���o���R���g���[���C���X�^���X��
				this.customControl_ExtractWait = new Broadleaf.Windows.Forms.SFCMN00221UL();
				this.panel_Main.Controls.Add(this.customControl_ExtractWait);
				this.customControl_ExtractWait.BringToFront();
				this.customControl_ExtractWait.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(252)), ((System.Byte)(248)));
				this.customControl_ExtractWait.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				this.customControl_ExtractWait.Location = new System.Drawing.Point(50, 300);
				this.customControl_ExtractWait.Name = "customControl_ExtractWait";
				this.customControl_ExtractWait.Size = new System.Drawing.Size(250, 40);
				this.customControl_ExtractWait.TabIndex = 22;
				this.customControl_ExtractWait.Visible = false;
				this.customControl_ExtractWait.DataType = "�d���`�[";
				this.customControl_ExtractWait.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));

				// �ϐ�������
				this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;		// ��ƃR�[�h���擾
				this._secInfoAcs = new SecInfoAcs();

				// �O���b�h�Ƀf�[�^�Z�b�g���o�C���h
				this.uGrid_Search.DataSource = this._searchSlipAcs.DataSet.StockSlip.DefaultView;

				// �R���|�[�l���g�����ݒ�
				this.tEdit_FindCondition.Top = 90;
				this.tEdit_FindCondition.Left = 10;
				this.tEdit_FindConditionCodeType.Top = 89;
                this.tEdit_FindConditionCodeType.Left = 10;
				this.tNedit_FindCondition.Top = 90;
                this.tNedit_FindCondition.Left = 10;
				this.tNedit_FindConditionCodeType.Top = 89;
                this.tNedit_FindConditionCodeType.Left = 10;
				this.tDateEdit_DateSta.Top = 90;
                this.tDateEdit_DateSta.Left = 10;
				this.tDateEdit_DateEnd.Top = 132;
				this.tDateEdit_DateEnd.Left = 10;
				this.uLabel_SlipDate.Top = 115;
				this.uLabel_SlipDate.Left = 95;
				this.uLabel_FindCondition.Top = 89;
				this.uLabel_FindCondition.Left = 10;

                this.tEdit_PartySaleSlipNum.Top = 89;
                this.tEdit_PartySaleSlipNum.Left = 10;
                this.tEdit_EmployeeCode.Top = 89;
                this.tEdit_EmployeeCode.Left = 10;
                this.tNedit_SupplierCd.Top = 89;
                this.tNedit_SupplierCd.Left = 10;
                this.tNedit_SupplierSlipNo_St.Top = 89;
                this.tNedit_SupplierSlipNo_Ed.Top = 89;
                this.ulabel_SupplierSlipNoCndtn.Top = 89;

                this.uLabel_EmployeeName.Top = 89;
                this.uLabel_EmployeeName.Left = 10;

                this.uLabel_SupplierName.Top = 89;
                this.uLabel_SupplierName.Left = 10;

				this.uButton_Guide.Top = 88;
				// 2007.10.12 sasaki >>
				//this.uButton_Guide.Left = 302;
				this.uButton_Guide.Left = 308;
				// 2007.10.12 sasaki <<

				this.tComboEditor_StockSectionCd.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.tLine_SectionPanel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.tLine_ConditionPanel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.tComboEditor_SupplierSlipCd.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.tComboEditor_FindCondition.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.uButton_Guide.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
				this.uButton_Find.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
				this.uLabel_FindCondition.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));

				this.tComboEditor_SupplierFormal.Value = 0;
				this.tComboEditor_SupplierSlipCd.Value = 99;
				this.tComboEditor_StockGoodsCd.Value = 99;

				if (param.StockSlipDefaultEditType == 0)
				{
					param.StockSlipDefaultEditType = 1;
					this.tDateEdit_DateSta.SetDateTime(DateTime.Today.AddDays(-7));
					this.tDateEdit_DateEnd.SetDateTime(DateTime.Today);
				}
				this.tComboEditor_FindCondition.Value = param.StockSlipDefaultEditType;
				this.tComboEditor_FindCondition_ValueChanged(this.tComboEditor_FindCondition, EventArgs.Empty);
				this._isInitial = false;
			}

			this._xmlNo = param.XmlNo;

			// �ԍ��ҏW���擾����
			if (this._noMngSetAcs == null)
			{
				this.GetNoMng();
			}

			// ���_�I�v�V�����`�F�b�N
			if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
			{
				// ���_�I�v�V�����L
				this._sectionOption	= true;
			}

			// ��ʏ����\���ݒ菈��
			this.DisplayInitialSetting();

			// �O���b�h�񏉊��ݒ菈��
			//this.GridColInitialSetting();
		}

		/// <summary>
		/// ������������
		/// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierNm">�d���於��</param>
        // 2008.09.05 Update >>>
		//internal void AutoSearch(int customerCode)
        internal void AutoSearch( int supplierCd,string supplierNm )
        // 2008.09.05 Update <<<
        {
			this.tComboEditor_FindCondition.Value = EDIT_TYPE_CustomerCode;
            // 2008.09.05 Update >>>
            //this.tNedit_FindConditionCodeType.SetInt(customerCode);

            this.tNedit_SupplierCd.SetInt(supplierCd);
            this.uLabel_SupplierName.Text = supplierNm;
            // 2008.09.05 Update <<<
			this.tNedit_FindConditionCodeType.Focus();

			this.uButton_Find_Click(this.uButton_Find, new EventArgs());
		}

		/// <summary>
		/// �p�l���A�N�e�B�u���\�b�h
		/// </summary>
		internal void PanelActivated()
		{
			this.timer_Activated.Enabled = true;
		}

		/// <summary>
		/// �d���`�[��������
		/// </summary>
		/// <param name="para">�d���`�[�����p�����[�^</param>
		/// <param name="retList">�d���`�[�������ʃN���X�z��</param>
		/// <returns>STATUS</returns>
		internal int Search(SearchParaStockSlip para, out List<StockSlip> retList)
		{
			retList = null;
			
			// �����������s
			return this._searchSlipAcs.SetSearchData(para);
		}

		/// <summary>
		/// ��\����ԃN���X�ۑ�����
		/// </summary>
		internal void SaveColDisplayStatus()
		{
            if (this.uGrid_Search.DataSource != null)
            {
                // ��\����ԃN���X���X�g�\�z����
                List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Search.DisplayLayout.Bands[0].Columns);
                this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

                // ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
                ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
            }
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// �d���`�[�������ʃO���b�h�J�������ݒ菈��
		/// </summary>
		/// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
		private void SettingGridColumns()
		{
			Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.uGrid_Search.DisplayLayout.Bands[0].Columns;

			// ��U�A�S�Ă̗���\���ɐݒ肵�A�\���ʒu�𓝈ꂳ����
			foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				column.Hidden = true;
				column.CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageHAlign	= Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageVAlign	= Infragistics.Win.VAlign.Middle;
				column.CellAppearance.Cursor = Cursors.Hand;
			}

			// �\����\���ݒ�
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Hidden = false;
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Hidden = false;
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Hidden = false;
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Hidden = false;
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Hidden = false;
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.AccPayDivCdNameColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Hidden = false;

			// �\���ʒu�ݒ�
			int visiblePosition = 0;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = ++visiblePosition;

			// �\�����ݒ�
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].Width = 35;			// ��
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Width = 80;		// �`�[�ԍ�
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Width = 90; 	// �v���
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Width = 90;    		// �d����
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Width = 90;  	// �S���Җ�
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Width = 120;  	// �d���於
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Width = 90;  	// �q�ɖ�
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierFomalNameColumn.ColumnName].Width = 70;	// �`�[��ʖ�
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Width = 70;	// �`�[�敪��
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Width = 70;	// �ԓ`�敪��
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Width = 90;	// ���i�敪��
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Width = 80;		// �L�����A��
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Width = 100;	// ���z���v
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Width = 90;	// �����`��
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Width = 120;	// �`�[���l1
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Width = 120;	// �`�[���l2

			// CellAppearance�ݒ�
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierFomalNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockSubttlPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Search.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Search.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Search.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.ForeColor = Color.White;

			// �t�H�[�}�b�g�ݒ�
			string dateFormat = "yyyy/MM/dd";
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Format = dateFormat;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Format = dateFormat;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.InputDayColumn.ColumnName].Format = dateFormat;
			string moneyFormat = "#,##0;-#,##0;''";
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Format = moneyFormat;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockSubttlPriceColumn.ColumnName].Format = moneyFormat;

			// ��\����ԃN���X���X�gXML�t�@�C�����f�V���A���C�Y
			List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(FILENAME_COLDISPLAYSTATUS);

			// ��\����ԃR���N�V�����N���X���C���X�^���X��
			this._colDisplayStatusList = new ColDisplayStatusList(this, colDisplayStatusList);

			foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (colDisplayStatus.Key == this.tComboEditor_GridFontSize.Name)
				{
					this.tComboEditor_GridFontSize.Value = colDisplayStatus.Width;
				}
				else if (columns.Exists(colDisplayStatus.Key))
				{
					columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
					columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
					columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
				}
			}
		}

		/// <summary>
		/// ��\����ԃN���X���X�g�\�z����
		/// </summary>
		/// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
		/// <returns>��\����ԃN���X���X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃J�����R���N�V���������ɁA��\����ԃN���X���X�g���\�z���܂��B</br>
		/// <br>Programmer : 22014 �F�J�@�F�F</br>
		/// <br>Date       : 2006.05.31</br>
		/// </remarks>
		private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
			List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

			// �t�H���g�T�C�Y���i�[
			ColDisplayStatus fontStatus = new ColDisplayStatus();
			fontStatus.Key = this.tComboEditor_GridFontSize.Name;
			fontStatus.VisiblePosition = -1;
			fontStatus.Width = (int)this.tComboEditor_GridFontSize.Value;
			colDisplayStatusList.Add(fontStatus);

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

		/// <summary>
		/// ��ʏ����\���ݒ菈��
		/// </summary>
		private void DisplayInitialSetting()
		{
			// �V�X�e���R���{�G�f�B�^�A�C�e���ݒ�
			Infragistics.Win.ValueListItem valueListItem0 = new Infragistics.Win.ValueListItem();
			valueListItem0.DataValue = 0;
			valueListItem0.DisplayText = "�d��";

			Infragistics.Win.ValueListItem alueListItem1 = new Infragistics.Win.ValueListItem();
			alueListItem1.DataValue = 1;
			alueListItem1.DisplayText = "����";

			this.tComboEditor_SupplierFormal.Items.Clear();
			this.tComboEditor_SupplierFormal.Items.Add(valueListItem0);
			this.tComboEditor_SupplierFormal.Items.Add(alueListItem1);

			// �C���[�W�A�C�R���ݒ菈��
			ImageList imglist = IconResourceManagement.ImageList16;

			this.uButton_Guide.Appearance.Image = imglist.Images[(int)Size16_Index.STAR1];

			// �O���b�h�̃t�H���g�T�C�Y��ݒ�
			this.tComboEditor_GridFontSize.Value = 11;

			// �d���`�[�������ʃO���b�h�J�������ݒ菈��
			this.SettingGridColumns();

			// �����v�㋒�_���X�g�ݒ菈��
			this.SetDemandAddUpSecList();
	
			// �����v�㋒�_�R���{�{�b�N�X�擾
			if (this.panel_ConditionSection.Visible)
			{
				if (this.tComboEditor_StockSectionCd.Items.Count > 0)
				{
					this.tComboEditor_StockSectionCd.MaxDropDownItems = this.tComboEditor_StockSectionCd.Items.Count;

					// 1�̋��_�����Ȃ��ꍇ�͐擪��I��
					if (this.tComboEditor_StockSectionCd.Items.Count == 1)
					{
						this.tComboEditor_StockSectionCd.SelectedIndex = 0;
					}
					else
					{
						// �����_�̐����v�㋒�_��I��
						SecInfoSet secInfoSet;
                        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //this._secInfoAcs.GetSecInfo(SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out secInfoSet);
                        this._secInfoAcs.GetSecInfo(out secInfoSet);
                        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
						if ((secInfoSet != null) && (secInfoSet.SectionCode != ""))
						{
							this.tComboEditor_StockSectionCd.Value = secInfoSet.SectionCode;
						}
						else
						{
							// �����v�㋒�_���ݒ肳��Ă��Ȃ��ꍇ�͎����_��I��
							if (this._ownSectionCode != "")
							{
								this.tComboEditor_StockSectionCd.Value = this._ownSectionCode;
							}
							else
							{
								// �����v�㋒�_�E�����_���Ȃ���ΐ擪��I���i���ʏ�̓G���[�j
								this.tComboEditor_StockSectionCd.SelectedIndex = 0;
							}
						}
					}
				}
			}

			// �I�t���C������
			if (!LoginInfoAcquisition.OnlineFlag)
			{
				this.panel_ConditionSection.Enabled = false;
				this.tComboEditor_SupplierFormal.Enabled = false;
				this.tComboEditor_FindCondition.Enabled = false;
				this.tNedit_FindCondition.Enabled = false;
				this.tNedit_FindConditionCodeType.Enabled = false;
				this.tEdit_FindCondition.Enabled = false;
				this.tEdit_FindConditionCodeType.Enabled = false;
				this.uLabel_FindCondition.Enabled = false;
				this.tDateEdit_DateSta.Enabled = false;
				this.tDateEdit_DateEnd.Enabled = false;
				this.uButton_Guide.Enabled = false;

				this.uLabel_FindCondition.Appearance.BackColor = this._enabledColor;
			}
		}

		/// <summary>
		/// �d���`�[�����p�����[�^�N���X�擾����
		/// </summary>
		/// <returns>�d���`�[�����p�����[�^�N���X</returns>
		private SearchParaStockSlip GetSearchParaStockSlip()
		{
			SearchParaStockSlip para = new SearchParaStockSlip();
			
			para.EnterpriseCode = this._enterpriseCode;
			
			// �d�����_�R���{�{�b�N�X�擾
			if (this.panel_ConditionSection.Visible)
			{
				para.StockSectionCd = "";

				// �d�����_���Z�b�g
				if (this.tComboEditor_StockSectionCd.SelectedItem != null)
				{
					para.StockSectionCd = (string)this.tComboEditor_StockSectionCd.SelectedItem.DataValue;
				}
				else
				{
					para.StockSectionCd = "";
				}
			}
			else
			{
				// �d�����_�Ɏ����_���Z�b�g
				para.StockSectionCd = this._ownSectionCode;
			}

			// �d���`��
			para.SupplierFormal = this.GetSelectedValue(this.tComboEditor_SupplierFormal);

			// 2007.10.12 sasaki >>
			//// �d���`�[�敪
			//para.SupplierSlipCd = this.GetSelectedValue(this.tComboEditor_SupplierSlipCd);

			// ��ʂ̎d���`�[�敪����A���o�p�̎d���`�[�敪�Ɣ��|�敪��ݒ肷��
			int supplierSlipCd = this.GetSelectedValue(this.tComboEditor_SupplierSlipCd);
			if ((supplierSlipCd == 99) || (supplierSlipCd == 0))
			{
				para.SupplierSlipCd = 99;
				para.AccPayDivCd = 99;
			}
			else
			{
				para.SupplierSlipCd = (supplierSlipCd / 10) * 10;
				para.AccPayDivCd = supplierSlipCd % 10;
			}
			// 2007.10.12 sasaki <<

			// �ԓ`�敪
			para.DebitNoteDiv = 99;

			// �d�����i�敪
			para.StockGoodsCd = this.GetSelectedValue(this.tComboEditor_StockGoodsCd);

			// 2007.10.12 sasaki >>
			//// ���|�敪
			//para.AccPayDivCd = this.GetSelectedValue(this.tComboEditor_AccPayDivCd);
			// 2007.10.12 sasaki <<

			// �R���{�G�f�B�^�I��l�擾����(���o�����敪)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			// �d�����E���ד�
			if (findConditionCode == EDIT_TYPE_StockDate)
			{
				// 2007.10.12 sasaki >>
				//para.ArrivalGoodsDayStart = this.tDateEdit_DateSta.GetDateTime();
				//para.ArrivalGoodsDayEnd = this.tDateEdit_DateEnd.GetDateTime();

				// �d���̏ꍇ�͎d�����A���ׂ̏ꍇ�͓��ד����w��
				para.StockDateSt = TDateTime.DateTimeToLongDate(this.tDateEdit_DateSta.GetDateTime());
				para.StockDateEd = TDateTime.DateTimeToLongDate(this.tDateEdit_DateEnd.GetDateTime());
				// 2007.10.12 sasaki <<
			}
			// �v���
			else if (findConditionCode == EDIT_TYPE_InputDay)
			{
				// 2007.10.12 sasaki >>
				//para.StockAddUpADateStart = this.tDateEdit_DateSta.GetDateTime();
				//para.StockAddUpADateEnd = this.tDateEdit_DateEnd.GetDateTime();
				para.InputDaySt = TDateTime.DateTimeToLongDate(this.tDateEdit_DateSta.GetDateTime());
				para.InputDayEd = TDateTime.DateTimeToLongDate(this.tDateEdit_DateEnd.GetDateTime());
				// 2007.10.12 sasaki <<
			}
			// �d���`�[�ԍ�
			else if (findConditionCode == EDIT_TYPE_SupplierSlipNo)
			{
                para.SupplierSlipNoSt = this.tNedit_SupplierSlipNo_St.GetInt();
                para.SupplierSlipNoEd= this.tNedit_SupplierSlipNo_Ed.GetInt();
            }
			// �d���S��
			else if (findConditionCode == EDIT_TYPE_StockAgentCode)
			{
                para.StockAgentCode = this.tEdit_EmployeeCode.Text;
			}
			// �d����R�[�h
			else if (findConditionCode == EDIT_TYPE_CustomerCode)
			{
                para.SupplierCd = this.tNedit_SupplierCd.GetInt();
			}
			// 2007.10.12 sasaki >>
			//// ���Ǝ҃R�[�h
			//else if (findConditionCode == EDIT_TYPE_CarrierEpCode)
			//{
			//    para.CarrierEpCode = this.tNedit_FindConditionCodeType.GetInt();
			//}
			//// �q�ɃR�[�h
			//else if (findConditionCode == EDIT_TYPE_WarehouseCode)
			//{
			//    para.WarehouseCode = this.tEdit_FindConditionCodeType.Text.ToString();
			//}
			// 2007.10.12 sasaki <<
			// �����`��
			else if (findConditionCode == EDIT_TYPE_PartySaleSlipNum)
			{
                para.PartySaleSlipNum = this.tEdit_PartySaleSlipNum.Text;
			}
			// ���i�R�[�h
			else if (findConditionCode == EDIT_TYPE_GoodsCode)
			{
				para.GoodsNo = this.tEdit_FindConditionCodeType.Text.ToString();
			}
			// 2007.10.12 sasaki >>
			//// ���i�d�b�ԍ�
			//else if (findConditionCode == EDIT_TYPE_StockTelNo1)
			//{
			//    para.StockTelNo1Start = this.tEdit_FindCondition.Text.ToString();
			//    para.StockTelNo1End = this.tEdit_FindCondition.Text.ToString();
			//}
			//// �����ԍ�
			//else if (findConditionCode == EDIT_TYPE_ProductNumber1)
			//{
			//    para.ProductNumber1Start = this.tEdit_FindCondition.Text.ToString();
			//    para.ProductNumber1End = this.tEdit_FindCondition.Text.ToString();
			//}
			// 2007.10.12 sasaki <<

			return para;
		}

		/// <summary>
		/// �d���`�[�����p�����[�^�N���X�`�F�b�N����
		/// </summary>
		/// <param name="para">�d���`�[�����p�����[�^�N���X</param>
		/// <returns>true:�`�F�b�N�n�j false:�`�F�b�N�m�f</returns>
		private bool CheckSearchParaStockSlip(SearchParaStockSlip para)
		{
			// �R���{�G�f�B�^�I��l�擾����(���o�����敪)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);
			/*
			if (para.AcptAnOdrStatus10 == 0 &&
				para.AcptAnOdrStatus20 == 0 &&
				para.AcptAnOdrStatus30 == 0 )
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�`�[��ʂ��I������Ă��܂���",
					0,
					MessageBoxButtons.OK);
				
				this.uCheckBox_OrderStatus1.Focus();
				return false;
			}

			// �`�[�ԍ�
			if (findConditionCode == EDIT_TYPE_SlipNo)
			{
				if (para.SlipNo == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�`�[�ԍ�����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// �`�[���t
			else if (findConditionCode == EDIT_TYPE_SlipDate)
			{
				if ((para.StSearchSlipDate == DateTime.MinValue) && (para.EdSearchSlipDate == DateTime.MinValue))
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�`�[���t����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tDateEdit_StockDateSta.Focus();

					return false;
				}
				else if ((para.StSearchSlipDate != DateTime.MinValue) && (para.EdSearchSlipDate != DateTime.MinValue) && (para.StSearchSlipDate > para.EdSearchSlipDate))
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�`�[���t�͈͎̔w�肪�s���ł��B",
						-1,
						MessageBoxButtons.OK);

					this.tDateEdit_StockDateEnd.Focus();

					return false;
				}
			}
			// �d���`�[�ԍ�
			else if (findConditionCode == EDIT_TYPE_AcceptAnOrderNo)
			{
				if (para.AcceptAnOrderNo == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�d���`�[�ԍ�����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tNedit_FindCondition.Focus();

					return false;
				}
			}
			// ���Ӑ�J�i
			else if (findConditionCode == EDIT_TYPE_Kana)
			{
				if (para.Kana == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"���Ӑ�J�i����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// ���Ӑ�R�[�h
			else if (findConditionCode == EDIT_TYPE_CustomerCode)
			{
				if (para.CustomerCode == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"���Ӑ�R�[�h����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tNedit_FindCondition.Focus();

					return false;
				}
			}
			// �v���[�g�ԍ��S
			else if (findConditionCode == EDIT_TYPE_NumberPlate4)
			{
				if (para.NumberPlate4 == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�v���[�g�ԍ�����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tNedit_FindCondition.Focus();

					return false;
				}
			}
			// ���Ӑ�T�u�R�[�h
			else if (findConditionCode == EDIT_TYPE_CustomerSubCode)
			{
				if (para.CustomerSubCode == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"���Ӑ�T�u�R�[�h����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// �d�b�ԍ�
			else if (findConditionCode == EDIT_TYPE_SearchTelNo)
			{
				if (para.SearchTelNo == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�d�b�ԍ�����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// �^��
			else if (findConditionCode == EDIT_TYPE_CarInspectCertModel)
			{
				if (para.CarInspectCertModel == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�^������͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// �ԑ�ԍ�
			else if (findConditionCode == EDIT_TYPE_FrameNo)
			{
				if (para.FrameNo == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�ԑ�ԍ�����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// �݌Ɏԗ��Ǘ��ԍ�
			else if (findConditionCode == EDIT_TYPE_StockCarMngNo)
			{
				if (para.StockCarMngNo == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�݌Ɏԗ��Ǘ��ԍ�����͂��Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// ���[�J�[�R�[�h
			else if (findConditionCode == EDIT_TYPE_MakerCode)
			{
				if (para.MakerCode == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"���[�J�[���w�肵�Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.uButton_Guide.Focus();

					return false;
				}
			}
			// �Ԏ�R�[�h
			else if (findConditionCode == EDIT_TYPE_ModelCode)
			{
				if (para.ModelCode == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�Ԏ���w�肵�Ă��������B",
						-1,
						MessageBoxButtons.OK);

					this.uButton_Guide.Focus();

					return false;
				}
			}
			*/

			return true;
		}

		/// <summary>
		/// �d���`�[��������
		/// </summary>
		/// <param name="para">�d���`�[�����p�����[�^�N���X</param>
		private void Search(SearchParaStockSlip para)
		{
			// �O���b�h�̃t�B���^������
			this.uGrid_Search.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();

			// �����������s
			int status = this._searchSlipAcs.SetSearchData(para);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �f�[�^�r���[�\�[�g�ݒ菈��
				this.DataViewSortSetting();

				if (this.uGrid_Search.Rows.Count == 0)
				{
					this.customControl_ExtractWait.Visible = true;
					this.customControl_ExtractWait.mode = 1;
					this.customControl_ExtractWait.Top = this.uGrid_Search.Top + 25;
					this.customControl_ExtractWait.Refresh();

					this.timer_MessageUnDisp.Enabled = true;

					if (this.tEdit_FindCondition.Visible)
					{
						this.tEdit_FindCondition.Focus();
					}
					else if (this.tEdit_FindConditionCodeType.Visible)
					{
						this.tEdit_FindConditionCodeType.Focus();
					}
					else if (this.tNedit_FindCondition.Visible)
					{
						this.tNedit_FindCondition.Focus();
					}
					else if (this.tNedit_FindConditionCodeType.Visible)
					{
						this.tNedit_FindConditionCodeType.Focus();
					}
				}
			}
			else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
			{
				this.customControl_ExtractWait.Visible = true;
				this.customControl_ExtractWait.mode = 1;
				this.customControl_ExtractWait.Top = this.uGrid_Search.Top + 60;
				this.customControl_ExtractWait.Refresh();

				this.timer_MessageUnDisp.Enabled = true;

				if (this.tEdit_FindCondition.Visible)
				{
					this.tEdit_FindCondition.Focus();
				}
				else if (this.tEdit_FindConditionCodeType.Visible)
				{
					this.tEdit_FindConditionCodeType.Focus();
				}
				else if (this.tNedit_FindCondition.Visible)
				{
					this.tNedit_FindCondition.Focus();
				}
				else if (this.tNedit_FindConditionCodeType.Visible)
				{
					this.tNedit_FindConditionCodeType.Focus();
				}
			}
			else
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"�d���`�[�f�[�^�̌����Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);
			}

			this._searchParaStockSlip = para;
		}

		/// <summary>
		/// �p�l���ύX�C�x���g�R�[������
		/// </summary>
		/// <param name="mode">���[�h</param>
		private void PanelChangeEventCall(int dispNo)
		{
			if (this.PanelChange != null)
			{
				PanelChangeEventArgs e = new PanelChangeEventArgs(PanelChangeEventArgs.MODE_UPDATE, dispNo);
				this.PanelChange(this, e);
			}
		}

		/// <summary>
		/// TEdit���̓v���p�e�B�h�ϊ�����
		/// </summary>
		/// <param name="edit">�ύX����Edit�R���|�[�l���g</param>
		/// <param name="findConditionCode">���o�����敪</param>
		private void TEditChangeEdit(Broadleaf.Library.Windows.Forms.TEdit tEdit, int findConditionCode)
		{
			if (findConditionCode == EDIT_TYPE_PartySaleSlipNum)				// �����`��
			{
				tEdit.CharacterCasing = CharacterCasing.Normal;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 19, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
				tEdit.ImeMode = System.Windows.Forms.ImeMode.Close;
			}
			else if (findConditionCode == EDIT_TYPE_GoodsCode)					// ���i�R�[�h
			{
				tEdit.CharacterCasing = CharacterCasing.Upper;
				tEdit.ImeMode = ImeMode.Off;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
			}
			else if (findConditionCode == EDIT_TYPE_StockTelNo1)				// ���i�d�b�ԍ�
			{
				tEdit.CharacterCasing = CharacterCasing.Upper;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
				tEdit.ImeMode = ImeMode.Off;
			}
            //else if (findConditionCode == EDIT_TYPE_ProductNumber1)				// �����ԍ�
            //{
            //    tEdit.CharacterCasing = CharacterCasing.Upper;
            //    tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            //    tEdit.ImeMode = ImeMode.Off;
            //}
			else if (findConditionCode == EDIT_TYPE_StockAgentCode)				// �d���S��
			{
				tEdit.CharacterCasing = CharacterCasing.Upper;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
				tEdit.ImeMode = ImeMode.Off;
			}
			else if (findConditionCode == EDIT_TYPE_WarehouseCode)				// �q��
			{
				tEdit.CharacterCasing = CharacterCasing.Upper;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
				tEdit.ImeMode = ImeMode.Off;
			}
		}

		/// <summary>
		/// TNedit���̓��[�h�ϊ�����
		/// </summary>
		/// <param name="edit">�ύX����Edit�R���|�[�l���g</param>
		/// <param name="mode">���[�h</param>
		private void TNeditChangeEdit(Broadleaf.Library.Windows.Forms.TNedit nEdit, int mode)
		{
			if ((mode == EDIT_TYPE_SupplierSlipNo) ||		// �d���`�[�ԍ�
				(mode == EDIT_TYPE_CustomerCode))			// ���Ӑ�R�[�h
			{
				nEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
				nEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
			}
            //else if (mode == EDIT_TYPE_CarrierEpCode)		// ���Ǝ҃R�[�h
            //{
            //    nEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            //    nEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            //}
		}

		/// <summary>
		/// �ԍ��ҏW���擾����
		/// </summary>
		private void GetNoMng()
		{
			if (!LoginInfoAcquisition.OnlineFlag)
			{
				return;
			}

			//�ԍ��^�C�v�Ǘ��}�X�^���擾�����i��Static�o�b�t�@�փZ�b�g
			this._noMngSetAcs = new NoMngSetAcs();
			ArrayList retNoTypMngList;
			int status = this._noMngSetAcs.Search(out retNoTypMngList,LoginInfoAcquisition.EnterpriseCode);
			if (status == 0)
			{
				NumberControl.NoTypeMngList = retNoTypMngList.ToArray(typeof(NoTypeMng)) as NoTypeMng[];
			}
			else
			{
				//
			}
		}

		/// <summary>
		/// �R���{�G�f�B�^�I��l�擾����
		/// </summary>
		/// <param name="sender">�ΏۃR���{�G�f�B�^</param>
		/// <returns>�I��l</returns>
		private int GetSelectedValue(TComboEditor sender)
		{
			int findConditionCode = 0;
			if ((sender.SelectedItem != null) && (sender.SelectedItem.DataValue is Int32))
			{
				findConditionCode = (int)sender.SelectedItem.DataValue;
			}

			return findConditionCode;
		}

		/// <summary>
		/// �`�[�ԍ��R���o�[�g����
		/// </summary>
		private void NumberConvertProc()
		{
			/*
			// �R���{�G�f�B�^�I��l�擾����(�f�[�^���̓V�X�e���^���o�����敪)
			int dataInputSystem = this.GetSelectedValue(this.tComboEditor_SupplierFormal);
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			// �`�[�ԍ��̏ꍇ
			if (findConditionCode == (int)EDIT_TYPE_SlipNo)
			{
				string before = this.tEdit_FindCondition.DataText;
				int acptAnOdrStatus10 = 0;
				int acptAnOdrStatus20 = 0;
				int acptAnOdrStatus30 = 0;
				if (this.uCheckBox_OrderStatus1.Checked == true) acptAnOdrStatus10 = 1;
				if (this.uCheckBox_OrderStatus2.Checked == true) acptAnOdrStatus20 = 1;
				if (this.uCheckBox_OrderStatus3.Checked == true) acptAnOdrStatus30 = 1;
				string after = before;

				if (dataInputSystem == 0)
				{
					string after1 = this.SlipNoNumberConvert(before, 1, acptAnOdrStatus10, acptAnOdrStatus20, acptAnOdrStatus30);
					string after2 = this.SlipNoNumberConvert(before, 2, acptAnOdrStatus10, acptAnOdrStatus20, acptAnOdrStatus30);
					string after3 = this.SlipNoNumberConvert(before, 3, acptAnOdrStatus10, acptAnOdrStatus20, acptAnOdrStatus30);

					if ((after1 == after2) && (after2 == after3))
					{
						after = after1;
					}
				}
				else
				{
					after = this.SlipNoNumberConvert(before, dataInputSystem, acptAnOdrStatus10, acptAnOdrStatus20, acptAnOdrStatus30);
				}
				this.tEdit_FindCondition.DataText = after;
			}
			*/
		}

		/// <summary>
		/// �f�[�^�r���[�\�[�g�ݒ菈��
		/// </summary>
		private void DataViewSortSetting()
		{
			// �R���{�G�f�B�^�I��l�擾����(���o�����敪)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			// ���ד�
			if (findConditionCode == EDIT_TYPE_StockDate)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort = 
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName + " DESC";
			}
			// �v���
			else if (findConditionCode == EDIT_TYPE_InputDay)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName + " DESC";
			}
			// �d���`�[�ԍ�
			else if (findConditionCode == EDIT_TYPE_SupplierSlipNo)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort = 
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			}
			// �d���S��
			else if (findConditionCode == EDIT_TYPE_StockAgentCode)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort = 
					this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName + " ASC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			}
			// �d����
			else if (findConditionCode == EDIT_TYPE_CustomerCode)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName + " ASC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			}
			// 2007.10.12 sasaki >>
			//// ���Ǝ�
			//else if (findConditionCode == EDIT_TYPE_CarrierEpCode)
			//{
			//    this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
			//        this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName + " ASC" + " , " +
			//        this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			//}
			// 2007.10.12 sasaki <<
			// �����`��
			else if (findConditionCode == EDIT_TYPE_PartySaleSlipNum)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName + " ASC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			}
			// ���i�R�[�h
			else if (findConditionCode == EDIT_TYPE_GoodsCode)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName + " DESC";
			}
			// ���i�d�b�ԍ�
			else if (findConditionCode == EDIT_TYPE_StockTelNo1)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName + " DESC";
			}
            //// �����ԍ�
            //else if (findConditionCode == EDIT_TYPE_ProductNumber1)
            //{
            //    this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
            //        this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
            //        this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName + " DESC";
            //}
		}

		/// <summary>
		/// �����v�㋒�_���X�g�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����v�㋒�_���X�g�̐ݒ���s���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ��@����Y</br>
		/// <br>Date       : 2006.04.11</br>
		/// </remarks>
		private void SetDemandAddUpSecList()
		{
			// ��U���ׂĂ̋��_���N���A
			this.tComboEditor_StockSectionCd.Items.Clear();

			// �f�t�H���g�͔�\���ɂ���
			this.panel_ConditionSection.Visible = false;

			// �����_�̎擾
			SecInfoSet secInfoSet;
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this._secInfoAcs.GetSecInfo(SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
            this._secInfoAcs.GetSecInfo(out secInfoSet);
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			if (secInfoSet != null)
			{
				// �����_�R�[�h�̕ۑ�
				this._ownSectionCode = secInfoSet.SectionCode;

				// ���_�I�v�V�����L�H
				if (!this._sectionOption)
				{
					return;
				}

				// �{�Ћ@�\���H
				if (secInfoSet.MainOfficeFuncFlag == 1)
				{
					this.panel_ConditionSection.Visible = true;
				}
				// ���_�@�\���H
				else
				{
					return;
				}
			}
			else
			{
				// �����_���ݒ肳��Ă��Ȃ��ꍇ�̓��O�C���]�ƈ��̋��_�����擾
				if (this._secInfoAcs.SecInfoSet != null)
				{
					// �����_�R�[�h�̕ۑ�
					this._ownSectionCode = this._secInfoAcs.SecInfoSet.SectionCode;

					// ���_�I�v�V�����L�H
					if (!this._sectionOption)
					{
						return;
					}

					// �{�Ћ@�\���H
					if (this._secInfoAcs.SecInfoSet.MainOfficeFuncFlag == 1)
					{
						this.panel_ConditionSection.Visible = true;
					}
					// ���_�@�\���H
					else
					{
						return;
					}
				}
				else
				{
					// �x�����b�Z�[�W��\������i�����_���Ȃ��j
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						MESSAGE_NONOWNSECTION,
						0,
						MessageBoxButtons.OK);
				}
			}

			// TODO: �S�Ђ��Z�b�g����ꍇ�͈ȉ�����
			// this.tComboEditor_DemandAddUpSecCd.Items.Add("", "�S��");

			// ���_��񃊃X�g�̎擾
			if ((this._secInfoAcs.SecInfoSetList != null) && (this._secInfoAcs.SecInfoSetList.Length > 0))
			{
				foreach (SecInfoSet setSecInfoSet in this._secInfoAcs.SecInfoSetList)
				{
					this.tComboEditor_StockSectionCd.Items.Add(setSecInfoSet.SectionCode, setSecInfoSet.SectionGuideNm);
				}
			}
			else
			{
				// TODO: �S�Ђ��Z�b�g����ꍇ�͈ȉ��폜
				this.tComboEditor_StockSectionCd.Items.Add("", "�S��");
			}

			tComboEditor_FindCondition_ValueChanged(this.tComboEditor_FindCondition, new EventArgs());
		}

		/// <summary>
		/// ��ʃZ���t�H���g�J���[�擾����
		/// </summary>
		/// <param name="row">�O���b�hRow</param>
		/// <returns>��ʃZ���t�H���g�J���[</returns>
		private Color GetKindCellForeColor(Infragistics.Win.UltraWinGrid.UltraGridRow row)
		{
			Color cellForeColor = this.uGrid_Search.DisplayLayout.Override.CellAppearance.ForeColor;

			/*
			// �ԓ`
			if ((int)row.Cells[SEARCH_COL_DebitNoteDiv].Value == 1)
			{
				cellForeColor = COLOR_REDSLIP;
				return cellForeColor;
			}

			// ���E�ςݍ��`
			if (((int)row.Cells[SEARCH_COL_DebitNoteDiv].Value == 0) &&
				((int)row.Cells[SEARCH_COL_DebitNLnkAcptAnOdr].Value != 0))
			{
				cellForeColor = COLOR_OFFSETBLACKSLIP;
				return cellForeColor;
			}

			// ���C�`�[
			if ((int)row.Cells[SEARCH_COL_StockRepairCd].Value == 1)
			{
				cellForeColor = COLOR_STOCKREPAIR;
				return cellForeColor;
			}

			// �d���`�[�X�e�[�^�X�ɉ������F�̐ݒ�
			switch ((int)row.Cells[SEARCH_COL_AcptAnOdrStatus].Value)
			{
				case 10:
				{
					cellForeColor = COLOR_ESTIMATE;
					return cellForeColor;
				}
				case 20:
				{
					cellForeColor = COLOR_ACPTANODR;
					return cellForeColor;
				}
				case 30:
				{
					cellForeColor = COLOR_SETTLEMENT;
					return cellForeColor;
				}
			}
			*/
			return cellForeColor;
		}

		/// <summary>
		/// �݌Ɏԗ��Ǘ��ԍ����̓G�f�B�b�g�v���p�e�B�ύX����
		/// </summary>
		private void StockCarMngNoEditPropatyChange(Broadleaf.Library.Windows.Forms.TEdit tEdit)
		{
			// �f�t�H���g�ݒ�
			tEdit.ExtEdit = new TExtEdit(emCursorPosition.Prev, false, true, 9, new TEnableChars(false, false, false, false, true, true, true));

			if (NumberControl.NoTypeMngList != null)
			{
				NumberControl numberControl = new NumberControl();

				Int32 maxLength = numberControl.GetLength((int)ConstantManagement_SF_AP.NoCode.StockCarMngNo);
				Int32 inputType = numberControl.GetInputType((int)ConstantManagement_SF_AP.NoCode.StockCarMngNo);

				if (maxLength > 0)
				{
					// ���l�̏ꍇ
					if (inputType == 0)
					{
						tEdit.ExtEdit = new TExtEdit(emCursorPosition.Prev, false, true, maxLength, new TEnableChars(false, false, false, false, false, false, true));
					}
					// �����̏ꍇ
					else
					{
						tEdit.ExtEdit = new TExtEdit(emCursorPosition.Prev, false, true, maxLength, new TEnableChars(false, false, true, false, true, true, true));
					}
				}

				tEdit.MaxLength = maxLength;

				Int32 posi = numberControl.GetDispPosition((int)ConstantManagement_SF_AP.NoCode.StockCarMngNo);

				if (posi == 0)
				{
					tEdit.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
				}
				else
				{
					tEdit.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
				}
			}
		}

        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ���Ӑ�I���������C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        //private void CustomerSearchGuide_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    this.tNedit_FindConditionCodeType.SetInt(customerSearchRet.CustomerCode);
        //    this.uLabel_FindCondition.Text = customerSearchRet.Name + " " + customerSearchRet.Name2;

        //    this.uButton_Find.Focus();
        //    this.uButton_Find_Click(this.uButton_Find, new EventArgs());
        //}
        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void SupplierSearchGuide_SupplierSelect(Supplier supplier)
        {
            if (supplier == null) return;

            this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);
            this.uLabel_SupplierName.Text = supplier.SupplierNm1 + " " + supplier.SupplierNm2;

            this.tNedit_FindConditionCodeType.SetInt(supplier.SupplierCd);
            this.uLabel_FindCondition.Text = supplier.SupplierNm1 + " " + supplier.SupplierNm2;

            this.uButton_Find.Focus();
            this.uButton_Find_Click(this.uButton_Find, new EventArgs());
        }
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		# endregion

		// ===================================================================================== //
		// �R���g���[���C�x���g����
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// ���o�����R���{�G�f�B�^�l�ύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tComboEditor_FindCondition_ValueChanged(object sender, System.EventArgs e)
		{
			if (!(sender is TComboEditor)) return;

			TComboEditor tComboEditor = (TComboEditor)sender;
			if (tComboEditor.SelectedItem == null) return;

            this.tEdit_FindCondition.BeginUpdate();
            this.tEdit_FindConditionCodeType.BeginUpdate();
            this.tNedit_FindCondition.BeginUpdate();
            this.tNedit_FindConditionCodeType.BeginUpdate();
            this.uLabel_SlipDate.BeginUpdate();
            this.uButton_Guide.BeginUpdate();
            this.uLabel_FindCondition.BeginUpdate();
            this.tNedit_SupplierCd.BeginUpdate();
            this.uLabel_SupplierName.BeginUpdate();
            this.tEdit_EmployeeCode.BeginUpdate();
            this.uLabel_EmployeeName.BeginUpdate();
            this.tEdit_PartySaleSlipNum.BeginUpdate();
            this.tNedit_SupplierSlipNo_St.BeginUpdate();
            this.tNedit_SupplierSlipNo_Ed.BeginUpdate();
            this.ulabel_SupplierSlipNoCndtn.BeginUpdate();

            bool tEdit_FindConditionVisible = false;
            bool tEdit_FindConditionCodeTypeVisible = false;
            bool tNedit_FindConditionVisible = false;
            bool tNedit_FindConditionCodeTypeVisible = false;
            bool tDateEdit_DateStaVisible = false;
            bool tDateEdit_DateEndVisible = false;
            bool uLabel_SlipDateVisible = false;
            bool uButton_GuideVisible = false;
            bool uLabel_FindConditionVisible = false;
            bool tNedit_SupplierCdVisible = false;
            bool uLabel_SupplierNameVisible = false;
            bool tEdit_EmployeeCdVisible = false;
            bool uLabel_EmployeeNameVisible = false;
            bool tEdit_PartySaleSlipNumVisible = false;
            bool tNedit_SupplierSlipNoVisible = false;

            try
            {

                // ���o�����l���N���A
                this.uLabel_FindCondition.Text = "";
                this.tEdit_FindCondition.Clear();
                this.tEdit_FindConditionCodeType.Clear();
                this.tNedit_FindCondition.Clear();
                this.tNedit_FindConditionCodeType.Clear();
                this.tNedit_SupplierCd.Clear();
                this.uLabel_SupplierName.Text = "";
                this.tEdit_EmployeeCode.Clear();
                this.uLabel_EmployeeName.Text = "";
                this.tEdit_PartySaleSlipNum.Clear();
                this.tNedit_SupplierSlipNo_Ed.Clear();
                this.tNedit_SupplierSlipNo_St.Clear();

                int mode = 0;
                if (tComboEditor.SelectedItem.DataValue is Int32)
                {
                    mode = Convert.ToInt32(tComboEditor.SelectedItem.DataValue);
                }

                SecInfoSet secInfoSet;
                // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //this._secInfoAcs.GetSecInfo(SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
                this._secInfoAcs.GetSecInfo(out secInfoSet);
                // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //// �`�[�ԍ�
                //if (mode == EDIT_TYPE_SupplierSlipNo)
                //{
                //    this.tNedit_FindCondition.Visible = true;
                //    this.uLabel_FindCondition.Visible = true;
                //    this.uLabel_FindCondition.ContextMenu = null;
                //    this.uLabel_FindCondition.Cursor = Cursors.Default;
                //    this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                //    this.uLabel_FindCondition.Appearance.BackColor = Color.White;
                //    this.uLabel_FindCondition.Left = 10;

                //    this.tNedit_FindCondition.Width = DEFAULT_EDIT_WIDTH;
                //    this.uLabel_FindCondition.Width = this.tComboEditor_FindCondition.Width;

                //    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                //    {
                //        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                //    }
                //    else
                //    {
                //        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                //    }

                //    // TNedit���̓v���p�e�B�h�ϊ�����
                //    this.TNeditChangeEdit(this.tNedit_FindCondition, mode);
                //}
                // �`�[�ԍ�
                if (mode == EDIT_TYPE_SupplierSlipNo)
                {
                    tNedit_SupplierSlipNoVisible = true;
                    
                    this.tNedit_SupplierSlipNo_St.Left = this.tComboEditor_FindCondition.Left;

                    this.tNedit_SupplierSlipNo_Ed.Left = this.tComboEditor_FindCondition.Left + this.tComboEditor_FindCondition.Width - this.tNedit_SupplierSlipNo_Ed.Width;

                    this.ulabel_SupplierSlipNoCndtn.Left = this.tNedit_SupplierSlipNo_St.Left + this.tNedit_SupplierSlipNo_St.Width + ( ( this.tComboEditor_FindCondition.Width - this.tNedit_SupplierSlipNo_Ed.Width - this.tNedit_SupplierSlipNo_St.Width - this.ulabel_SupplierSlipNoCndtn.Width ) / 2 );

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_SLIPDATE + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_SLIPDATE;
                    }

                    //// TNedit���̓v���p�e�B�h�ϊ�����
                    //this.TNeditChangeEdit(this.tNedit_FindCondition, mode);
                }
                // �����`��
                else if ( mode == EDIT_TYPE_PartySaleSlipNum )
                {
                    tEdit_PartySaleSlipNumVisible = true;
                    this.tEdit_PartySaleSlipNum.ContextMenu = null;
                    this.tEdit_PartySaleSlipNum.Width = this.tComboEditor_FindCondition.Width;
                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                    }

                }
                //// �����`��
                //// ���i�d�b�ԍ�
                //else if (( mode == EDIT_TYPE_PartySaleSlipNum ) ||
                //    ( mode == EDIT_TYPE_StockTelNo1 ) ||
                //    ( mode == EDIT_TYPE_ProductNumber1 ))
                //{
                //    this.tEdit_FindCondition.Visible = true;
                //    this.tEdit_FindConditionCodeType.Visible = false;
                //    this.tNedit_FindCondition.Visible = false;
                //    this.tNedit_FindConditionCodeType.Visible = false;
                //    this.tDateEdit_DateSta.Visible = false;
                //    this.tDateEdit_DateEnd.Visible = false;
                //    this.uLabel_SlipDate.Visible = false;
                //    this.uButton_Guide.Visible = false;
                //    this.uLabel_FindCondition.Visible = true;
                //    this.uLabel_FindCondition.ContextMenu = null;
                //    this.uLabel_FindCondition.Cursor = Cursors.Default;
                //    this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                //    this.uLabel_FindCondition.Appearance.BackColor = Color.White;
                //    this.uLabel_FindCondition.Left = 10;

                //    this.tEdit_FindCondition.Width = DEFAULT_EDIT_WIDTH;
                //    this.uLabel_FindCondition.Width = this.tComboEditor_FindCondition.Width;

                //    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                //    {
                //        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                //    }
                //    else
                //    {
                //        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                //    }

                //    // TEdit���̓v���p�e�B�h�ϊ�����
                //    this.TEditChangeEdit(this.tEdit_FindCondition, mode);
                //}
                // �d����
                else if (mode == EDIT_TYPE_CustomerCode)
                {
                    uButton_GuideVisible = true;
                    tNedit_SupplierCdVisible = true;
                    uLabel_SupplierNameVisible = true;
                    this.uLabel_SupplierName.Visible = true;

                    this.toolTip_Hint.SetToolTip(this.uLabel_SupplierName, "");

                    if (mode == EDIT_TYPE_CustomerCode)
                    {
                        this.toolTip_Hint.SetToolTip(this.uButton_Guide, "�d���挟��");
                        this.tNedit_FindConditionCodeType.Size = new Size(84, 22);
                    }

                    this.uLabel_SupplierName.Appearance.BackColor = SystemColors.ControlLight;
                    this.uLabel_SupplierName.Left = this.tNedit_SupplierCd.Left + this.tNedit_SupplierCd.Width + 3;
                    this.uLabel_SupplierName.Width = this.tComboEditor_FindCondition.Width - GUIDE_WIDTH_DIFFERENCE - this.tNedit_SupplierCd.Width - 3;

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                    }
                }
                // �S����
                else if (mode == EDIT_TYPE_StockAgentCode)
                {
                    tEdit_EmployeeCdVisible = true;
                    uLabel_EmployeeNameVisible = true;
                    uButton_GuideVisible = true;
                    this.uLabel_EmployeeName.Cursor = Cursors.Default;
                    //this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                    this.toolTip_Hint.SetToolTip(this.uButton_Guide, "�S���҃K�C�h");
                    //this.tEdit_FindConditionCodeType.Size = new Size(84, 22);

                    this.uLabel_EmployeeName.Appearance.BackColor = SystemColors.ControlLight;

                    this.uLabel_EmployeeName.Appearance.BackColor = SystemColors.ControlLight;
                    this.uLabel_EmployeeName.Left = this.tEdit_EmployeeCode.Left + this.tEdit_EmployeeCode.Width + 3;
                    this.uLabel_EmployeeName.Width = this.tComboEditor_FindCondition.Width - GUIDE_WIDTH_DIFFERENCE - this.tEdit_EmployeeCode.Width - 3;

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                    }

                    //// TEdit���̓v���p�e�B�h�ϊ�����
                    //this.TEditChangeEdit(this.tEdit_FindConditionCodeType, mode);
                }

                // �q��
                // ���i
                else if (( mode == EDIT_TYPE_WarehouseCode ) ||
                         ( mode == EDIT_TYPE_GoodsCode ))
                {
                    this.tEdit_FindCondition.Visible = false;
                    this.tEdit_FindConditionCodeType.Visible = true;
                    this.tNedit_FindCondition.Visible = false;
                    this.tNedit_FindConditionCodeType.Visible = false;
                    this.tDateEdit_DateSta.Visible = false;
                    this.tDateEdit_DateEnd.Visible = false;
                    this.uLabel_SlipDate.Visible = false;
                    this.uButton_Guide.Visible = true;
                    this.uLabel_FindCondition.Visible = true;
                    //this.uLabel_FindCondition.ContextMenu = this.contextMenu_Condition;
                    this.uLabel_FindCondition.Cursor = Cursors.Default;
                    //this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, SFCMN00221UA.MESSAGE_CONDITION_CLEAR);
                    this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                    if (mode == EDIT_TYPE_StockAgentCode)
                    {
                        this.toolTip_Hint.SetToolTip(this.uButton_Guide, "�S���҃K�C�h");
                        this.tEdit_FindConditionCodeType.Size = new Size(84, 22);
                    }
                    else if (mode == EDIT_TYPE_WarehouseCode)
                    {
                        this.toolTip_Hint.SetToolTip(this.uButton_Guide, "�q�ɃK�C�h");
                        this.tEdit_FindConditionCodeType.Size = new Size(68, 22);
                    }
                    else if (mode == EDIT_TYPE_GoodsCode)
                    {
                        this.toolTip_Hint.SetToolTip(this.uButton_Guide, "���i����");
                        this.tEdit_FindConditionCodeType.Size = new Size(147, 22);
                    }

                    this.uLabel_FindCondition.Appearance.BackColor = SystemColors.ControlLight;
                    this.uLabel_FindCondition.Left = this.tEdit_FindConditionCodeType.Left + this.tEdit_FindConditionCodeType.Width + 3;
                    this.uLabel_FindCondition.Width = this.tComboEditor_FindCondition.Width - GUIDE_WIDTH_DIFFERENCE - this.tEdit_FindConditionCodeType.Width - 3;

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                    }

                    // TEdit���̓v���p�e�B�h�ϊ�����
                    this.TEditChangeEdit(this.tEdit_FindConditionCodeType, mode);
                }
                // �d����
                // �v���
                else if (( mode == EDIT_TYPE_InputDay ) ||
                        ( mode == EDIT_TYPE_StockDate ))
                {
                    tDateEdit_DateStaVisible = true;
                    tDateEdit_DateEndVisible = true;

                    this.uLabel_FindCondition.ContextMenu = null;
                    this.uLabel_FindCondition.Cursor = Cursors.Default;
                    this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                    this.uLabel_FindCondition.Appearance.BackColor = Color.White;
                    this.uLabel_FindCondition.Left = 10;

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_SLIPDATE + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_SLIPDATE;
                    }

                    this.tDateEdit_DateSta.Refresh();
                    this.tDateEdit_DateEnd.Refresh();
                }
            }
            finally
            {
                this.tEdit_FindCondition.Visible = tEdit_FindConditionVisible;
                this.tEdit_FindConditionCodeType.Visible = tEdit_FindConditionCodeTypeVisible;
                this.tNedit_FindCondition.Visible = tNedit_FindConditionVisible;
                this.tNedit_FindConditionCodeType.Visible = tNedit_FindConditionCodeTypeVisible;
                this.tDateEdit_DateSta.Visible = tDateEdit_DateStaVisible;
                this.tDateEdit_DateEnd.Visible = tDateEdit_DateEndVisible;
                this.uLabel_SlipDate.Visible = uLabel_SlipDateVisible;
                this.uButton_Guide.Visible = uButton_GuideVisible;
                this.uLabel_FindCondition.Visible = uLabel_FindConditionVisible;
                this.tNedit_SupplierCd.Visible = tNedit_SupplierCdVisible;
                this.uLabel_SupplierName.Visible = uLabel_SupplierNameVisible;
                this.tEdit_EmployeeCode.Visible = tEdit_EmployeeCdVisible;
                this.uLabel_EmployeeName.Visible = uLabel_EmployeeNameVisible;
                this.tEdit_PartySaleSlipNum.Visible = tEdit_PartySaleSlipNumVisible;
                this.tNedit_SupplierSlipNo_St.Visible = tNedit_SupplierSlipNoVisible;
                this.tNedit_SupplierSlipNo_Ed.Visible = tNedit_SupplierSlipNoVisible;
                this.ulabel_SupplierSlipNoCndtn.Visible = tNedit_SupplierSlipNoVisible;

                this.tEdit_FindCondition.EndUpdate();
                this.tEdit_FindConditionCodeType.EndUpdate();
                this.tNedit_FindCondition.EndUpdate();
                this.tNedit_FindConditionCodeType.EndUpdate();
                this.uLabel_SlipDate.EndUpdate();
                this.uButton_Guide.EndUpdate();
                this.uLabel_FindCondition.EndUpdate();
                this.tNedit_SupplierCd.EndUpdate();
                this.uLabel_SupplierName.EndUpdate();
                this.tEdit_EmployeeCode.EndUpdate();
                this.uLabel_EmployeeName.EndUpdate();
                this.tEdit_PartySaleSlipNum.EndUpdate();
                this.tNedit_SupplierSlipNo_St.EndUpdate();
                this.tNedit_SupplierSlipNo_Ed.EndUpdate();
                this.ulabel_SupplierSlipNoCndtn.EndUpdate();
            }
		}

		/// <summary>
		/// �����^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_Search_Tick(object sender, System.EventArgs e)
		{
			this.timer_Search.Enabled = false;

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// �d���`�[�����p�����[�^�N���X�擾����
				SearchParaStockSlip para = this.GetSearchParaStockSlip();

				// �d���`�[�����p�����[�^�N���X�`�F�b�N����
				if (!this.CheckSearchParaStockSlip(para)) return;
			
				this.customControl_ExtractWait.Visible = true;
				this.customControl_ExtractWait.mode = 0;
				this.customControl_ExtractWait.Top = this.uGrid_Search.Top + 60;
				this.customControl_ExtractWait.Refresh();

				// �d���`�[��������
				this.Search(para);
			}
			finally
			{
				if (this.customControl_ExtractWait.mode == 0)
				{
					this.customControl_ExtractWait.Visible = false;
					this.Cursor = Cursors.Default;
				}
			}
		}

		/// <summary>
		/// ���o�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_Find_Click(object sender, System.EventArgs e)
		{
			this.timer_Search.Enabled = true;
		}

		/// <summary>
		/// �������ʃO���b�h�G�������g�}�E�X�G���^�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Search_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			if ((this.ActiveControl != this.uGrid_Search) && (this.uGrid_Search.Rows.Count > 0))
			{
				this.uGrid_Search.Focus();
			}

			// �d���`�[�����|�b�v�A�b�v�\��
			Infragistics.Win.UIElement element = e.Element;
			object oContextRow = null;
			object oContextCell = null;

			oContextRow = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
				cell.Appearance.ForeColor = Color.Blue;
				cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
			}

			if (oContextRow != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridRow row =(Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;

				this.uGrid_Search.ActiveRow = row;
				this.uGrid_Search.ActiveRow.Selected = true;

				string tipString = "";

				if (row.Cells[0] != null )
				{
					int totalLength = 16;

					// �u�����N
					tipString += "�@\r\n";
					// �d���`�[�ԍ�
					tipString += SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Value.ToString();

                    // �d����
                    tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockDateColumn.ColumnName].Header.Caption, ' ') + "�F" + string.Format("{0:yyyy/MM/dd}", (DateTime)row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockDateColumn.ColumnName].Value);

					// ���ד�
                    tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Header.Caption, ' ') + "�F" + string.Format("{0:yyyy/MM/dd}", (DateTime)row.Cells[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Value);

					// �v���
                    tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Header.Caption, ' ') + "�F" + string.Format("{0:yyyy/MM/dd}", (DateTime)row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Value);

					// �d���S��
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Value.ToString();

					// �d����
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Value.ToString();

					// 2007.10.12 sasaki >>
					//// �q��
					//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Value.ToString();

					//// ���Ǝ�
					//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Value.ToString();
					// 2007.10.12 sasaki <<

					// �����`��
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Value.ToString();

					// �Z�p���[�^
					tipString += "\r\n";

					// �d���`��
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierFomalNameColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierFomalNameColumn.ColumnName].Value.ToString();

					// �`�[�敪
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Value.ToString();

					// �ԓ`�敪
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Value.ToString();

                    //// ���i�敪
                    //tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Value.ToString();

                    //// ���|�敪
                    //tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.AccPayDivCdNameColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.AccPayDivCdNameColumn.ColumnName].Value.ToString();

					// �Z�p���[�^
					tipString += "\r\n";

					// �d�����z
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Value.ToString() + "�~";

					// �Z�p���[�^
					tipString += "\r\n";

					// ���l�P
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Value.ToString();

					// ���l�Q
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Header.Caption, ' ') + "�F" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Value.ToString();
				}

				Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
				ultraToolTipInfo.ToolTipTitle = "�d���`�[���";
				ultraToolTipInfo.ToolTipText = tipString;

				this.uToolTipManager_Information.Appearance.FontData.Name = "�l�r �S�V�b�N";
				this.uToolTipManager_Information.SetUltraToolTip(this.uGrid_Search, ultraToolTipInfo);
				this.uToolTipManager_Information.Enabled = true;

				return;
			}
		}

		/// <summary>
		/// �d���`�[�������ʃO���b�h�G�������g�}�E�X���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Search_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			Infragistics.Win.UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
				cell.Appearance.ForeColor = this.uGrid_Search.DisplayLayout.Override.CellAppearance.ForeColor;
				cell.Appearance.FontData.Underline = this.uGrid_Search.DisplayLayout.Override.CellAppearance.FontData.Underline;
			}
		}

		/// <summary>
		/// �d���`�[�������ʃO���b�h�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Search_Click(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		/// �A�N�e�B�u�^�C�}�[�N������
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_Activated_Tick(object sender, System.EventArgs e)
		{
			this.timer_Activated.Enabled = false;
			this.tComboEditor_SupplierFormal.Focus();
		}

		/// <summary>
		/// �K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_Guide_Click(object sender, System.EventArgs e)
		{
			// �R���{�G�f�B�^�I��l�擾����(���o�����敪)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			if (findConditionCode == EDIT_TYPE_StockAgentCode)				// �d���S��
			{
				EmployeeAcs employeeAcs = new EmployeeAcs();
				Employee employee;
				int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this.tEdit_EmployeeCode.Text = employee.EmployeeCode.Trim();
                    this.uLabel_EmployeeName.Text = employee.Name;
					this.uButton_Find_Click(this.uButton_Find, new EventArgs());
				}
			}
			else if (findConditionCode == EDIT_TYPE_GoodsCode)				// ���i�R�[�h
			{
				MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

				GoodsUnitData goodsUnitData;
				DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

				if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
				{
					this.uLabel_FindCondition.Text = goodsUnitData.GoodsName;
					// 2007.10.12 sasaki >>
					//this.uLabel_FindCondition.Tag = goodsUnitData.MakerCode;
					//this.tEdit_FindConditionCodeType.Text = goodsUnitData.GoodsCode;
					this.uLabel_FindCondition.Tag = goodsUnitData.GoodsMakerCd;
					this.tEdit_FindConditionCodeType.Text = goodsUnitData.GoodsNo;					
					// 2007.10.12 sasaki <<
					this.uButton_Find_Click(this.uButton_Find, new EventArgs());
				}
			}
			else if (findConditionCode == EDIT_TYPE_CustomerCode)
			{
                // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //SFTOK01370UA customerSearchGuide = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
                //customerSearchGuide.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchGuide_CustomerSelect);
                //customerSearchGuide.ShowDialog(this);
                Supplier supplier;
                SupplierAcs supplierAcs = new SupplierAcs();
                int status = supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.SupplierSearchGuide_SupplierSelect(supplier);
                }
                // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}
			else if (findConditionCode == EDIT_TYPE_WarehouseCode)
			{
				string sectionCode = this._ownSectionCode;

				if (this.tComboEditor_StockSectionCd.SelectedItem != null)
				{
					sectionCode = (string)this.tComboEditor_StockSectionCd.SelectedItem.DataValue;
				}

				Warehouse warehouse;
				int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, sectionCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this.uLabel_FindCondition.Text = warehouse.WarehouseName;
					this.tEdit_FindConditionCodeType.Text = warehouse.WarehouseCode.Trim();
					this.uButton_Find_Click(this.uButton_Find, new EventArgs());
				}
			}
		}

		/// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

			switch (e.PrevCtrl.Name)
			{
				case "uButton_Find":
				{
					switch (e.Key)
					{
						case Keys.Return:
						{
							e.NextCtrl = e.PrevCtrl;

							this.uButton_Find_Click(this.uButton_Find, new EventArgs());

							break;
						}
						case Keys.Tab:
						{
							if (this.uGrid_Search.Rows.Count > 0)
							{
								e.NextCtrl = this.uGrid_Search;
							}
							else
							{
								e.NextCtrl = this.tComboEditor_FindCondition;
							}
							break;
						}
					}

					break;
				}
				case "tNedit_FindCondition":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tNedit_FindCondition.GetInt() != 0)
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
                case "tEdit_EmployeeCode":
                {
                    
                    string employeeCode = this.tEdit_EmployeeCode.Text;
                    if (string.IsNullOrEmpty(employeeCode))
                    {
                        this.uLabel_EmployeeName.Text = "";
                    }
                    else
                    {
                        Employee employee;
                        int status = this._employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.tEdit_EmployeeCode.Text = employee.EmployeeCode.Trim();
                            this.uLabel_EmployeeName.Text = employee.Name;
                            //if (this.uLabel_EmployeeName.Text.Length > 10) this.uLabel_EmployeeName.Text = this.uLabel_EmployeeName.Text.Substring(0, 10);

                            this.uButton_Find_Click(this.uButton_Find, new EventArgs());
                        }
                        else if (( status == (int)ConstantManagement.DB_Status.ctDB_EOF ) ||
                            ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�Y������S���҂����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            this.tEdit_EmployeeCode.Text = string.Empty;
                            this.tEdit_EmployeeCode.Select(0, this.tEdit_EmployeeCode.DataText.Length);
                            this.uLabel_EmployeeName.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "�S���ҏ��̎擾�Ɏ��s���܂����B",
                                status,
                                MessageBoxButtons.OK);

                            this.tEdit_EmployeeCode.Text = employeeCode;
                            this.tEdit_EmployeeCode.Select(0, this.tEdit_EmployeeCode.DataText.Length);
                            this.uLabel_EmployeeName.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                }
                case "tNedit_SupplierCd":
                {
                    int newCode = this.tNedit_SupplierCd.GetInt();
                    if (newCode == 0)
                    {
                        this.uLabel_SupplierName.Text = "";
                    }
                    else 
                    {
                        Supplier supplier;

                        int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, newCode);

                        if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) && ( supplier != null ))
                        {
                            this.uLabel_SupplierName.Text = supplier.SupplierNm1 + "" + supplier.SupplierNm2;

                            if (this._searchParaStockSlip.SupplierCd != newCode)
                            {
                                this.uButton_Find_Click(this.uButton_Find, new EventArgs());
                            }
                        }
                        else if (( status == (int)ConstantManagement.DB_Status.ctDB_EOF ) ||
                            ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�Y������d���悪���݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            this.tNedit_SupplierCd.SetInt(0);
                            this.tNedit_SupplierCd.Select(0, this.tNedit_SupplierCd.DataText.Length);
                            this.uLabel_SupplierName.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "�d������̎擾�Ɏ��s���܂����B",
                                status,
                                MessageBoxButtons.OK);

                            this.tNedit_SupplierCd.Select(0, this.tNedit_SupplierCd.DataText.Length);
                            this.uLabel_SupplierName.Text = "";

                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                }
				case "tNedit_FindConditionCodeType":
				{
					int mode = 0;
					if (this.tComboEditor_FindCondition.SelectedItem.DataValue is Int32)
					{
						mode = Convert.ToInt32(this.tComboEditor_FindCondition.SelectedItem.DataValue);
					}

					if (mode == EDIT_TYPE_CustomerCode)
					{
						if (this.tNedit_FindConditionCodeType.GetInt() == 0)
						{
							this.uLabel_FindCondition.Text = "";
						}
                        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //else if (this._searchParaStockSlip.CustomerCode != this.tNedit_FindConditionCodeType.GetInt())
                        else if (this._searchParaStockSlip.SupplierCd != this.tNedit_FindConditionCodeType.GetInt())
                        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
						{
							CustomerSearchPara customerSearchPara = new CustomerSearchPara();
							// 2008.05.22 Del >>>
							//customerSearchPara.SupplierDiv = 1;
							// 2008.05.22 Del <<<
							customerSearchPara.EnterpriseCode = this._enterpriseCode;
							customerSearchPara.CustomerCode = this.tNedit_FindConditionCodeType.GetInt();

							CustomerSearchRet[] customerSearchRetArray;
							int status = this._customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);

							if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (customerSearchRetArray.Length > 0))
							{
								this.uLabel_FindCondition.Text = customerSearchRetArray[0].Name + " " + customerSearchRetArray[0].Name2;
								this.uButton_Find_Click(this.uButton_Find, new EventArgs());
							}
							else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
								(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"�Y������d���悪���݂��܂���B",
									-1,
									MessageBoxButtons.OK);

								this.tNedit_FindConditionCodeType.Select(0, this.tNedit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
							else
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_STOPDISP,
									this.Name,
									"�d������̎擾�Ɏ��s���܂����B",
									status,
									MessageBoxButtons.OK);

								this.tNedit_FindConditionCodeType.Select(0, this.tNedit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
						}
					}
                    //else if (mode == EDIT_TYPE_CarrierEpCode)
                    //{
                    //    // ���E�E�E�K�C�h����������g�ݍ���
                    //}
					break;
				}
				case "tEdit_FindCondition":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tEdit_FindCondition.Text != "")
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
				case "tEdit_FindConditionCodeType":
				{
					int mode = 0;
					if (this.tComboEditor_FindCondition.SelectedItem.DataValue is Int32)
					{
						mode = Convert.ToInt32(this.tComboEditor_FindCondition.SelectedItem.DataValue);

					}
					else if (mode == EDIT_TYPE_GoodsCode)
					{
						if (this.tEdit_FindConditionCodeType.Text == "")
						{
							this.uLabel_FindCondition.Text = "";
						}
						else if (this._searchParaStockSlip.GoodsNo != this.tEdit_FindConditionCodeType.Text)
						{
							List<GoodsUnitData> goodsUnitDataList;
							int status = this._goodsAcs.Read(this._enterpriseCode, this.tEdit_FindConditionCodeType.Text, out goodsUnitDataList);

							if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
							{
								string goodsName = goodsUnitDataList[0].GoodsName;
								
								if (goodsUnitDataList.Count > 1)
								{
									goodsName += " ��";
								}

								this.uLabel_FindCondition.Text = goodsName;
								this.uLabel_FindCondition.Tag = 0;

								this.uButton_Find_Click(this.uButton_Find, new EventArgs());
							}
							else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
								(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"�Y�����鏤�i�����݂��܂���B",
									-1,
									MessageBoxButtons.OK);

								this.tEdit_FindConditionCodeType.Select(0, this.tEdit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
							else
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_STOPDISP,
									this.Name,
									"���i���̎擾�Ɏ��s���܂����B",
									status,
									MessageBoxButtons.OK);

								this.tEdit_FindConditionCodeType.Select(0, this.tEdit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
						}
					}
					else if (mode == EDIT_TYPE_WarehouseCode)
					{
						if (this.tEdit_FindConditionCodeType.Text == "")
						{
							this.uLabel_FindCondition.Text = "";
						}
						else
						{
							string sectionCode = this._ownSectionCode;

							if (this.tComboEditor_StockSectionCd.SelectedItem != null)
							{
								sectionCode = (string)this.tComboEditor_StockSectionCd.SelectedItem.DataValue;
							}

							Warehouse warehouse;
							int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, sectionCode, this.tEdit_FindConditionCodeType.Text);

							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							{
								this.uLabel_FindCondition.Text = warehouse.WarehouseName;
								this.uLabel_FindCondition.Tag = 0;

								this.uButton_Find_Click(this.uButton_Find, new EventArgs());
							}
							else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
								(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"�Y������q�ɂ����݂��܂���B",
									-1,
									MessageBoxButtons.OK);

								this.tEdit_FindConditionCodeType.Select(0, this.tEdit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
							else
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_STOPDISP,
									this.Name,
									"�q�ɏ��̎擾�Ɏ��s���܂����B",
									status,
									MessageBoxButtons.OK);

								this.tEdit_FindConditionCodeType.Select(0, this.tEdit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
						}
					}

					break;
				}
                case "tNedit_SupplierSlipNo_Ed":
                {
                    if (e.Key == Keys.Return)
                    {
                        if (this.tNedit_SupplierSlipNo_Ed.GetInt() != 0)
                        {
                            this.uButton_Find_Click(this.uButton_Find, new EventArgs());
                        }
                    }
                    break;
                }
				case "tDateEdit_DateEnd":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tDateEdit_DateEnd.GetDateTime() != DateTime.MinValue)
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
				case "tComboEditor_FindCondition":
				{
					if (e.Key == Keys.Down)
					{
						if (this.tEdit_FindCondition.Visible)
						{
							e.NextCtrl = this.tEdit_FindCondition;
						}
						else if (this.tNedit_FindCondition.Visible)
						{
							e.NextCtrl = this.tNedit_FindCondition;
						}
						else if (this.tNedit_FindConditionCodeType.Visible)
						{
							e.NextCtrl = this.tNedit_FindConditionCodeType;
						}
					}

					break;
				}
                case "tEdit_PartySaleSlipNum":
                {
                    break;
                }
			}
		}

		/// <summary>
		/// ���o�������l���̓G�f�B�^�G���^�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tNedit_FindCondition_Enter(object sender, System.EventArgs e)
		{
			this.uLabel_FindCondition.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
			this.tNedit_FindCondition.Left = this.uLabel_FindCondition.Left + 1;
		}

		/// <summary>
		/// ���o������������̓G�f�B�^�G���^�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tEdit_FindCondition_Enter(object sender, System.EventArgs e)
		{
			this.uLabel_FindCondition.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
			this.tEdit_FindCondition.Left = this.uLabel_FindCondition.Left + 1;
		}

		/// <summary>
		/// ���o�������l���̓G�f�B�^���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tNedit_FindCondition_Leave(object sender, System.EventArgs e)
		{
			this.uLabel_FindCondition.Appearance.BackColor = Color.White;

			if (this.tNedit_FindCondition.NormalAppearance.TextHAlign == Infragistics.Win.HAlign.Right)
			{
				int left = this.uLabel_FindCondition.Width - this.tNedit_FindCondition.Width;
				if (left > this.uLabel_FindCondition.Left)
				{
					this.tNedit_FindCondition.Left = left;
				}
			}
			else
			{
				this.tNedit_FindCondition.Left = this.uLabel_FindCondition.Left + 1;
			}
		}

		/// <summary>
		/// ���o������������̓G�f�B�^���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tEdit_FindCondition_Leave(object sender, System.EventArgs e)
		{
			this.uLabel_FindCondition.Appearance.BackColor = Color.White;

			if (this.tEdit_FindCondition.NormalAppearance.TextHAlign == Infragistics.Win.HAlign.Right)
			{
				int left = this.uLabel_FindCondition.Width - this.tEdit_FindCondition.Width;
				if (left > this.uLabel_FindCondition.Left)
				{
					this.tEdit_FindCondition.Left = left;
				}
			}
			else
			{
				this.tEdit_FindCondition.Left = this.uLabel_FindCondition.Left + 1;
			}
		}

		/// <summary>
		/// ���o�������x���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uLabel_FindCondition_Click(object sender, System.EventArgs e)
		{
			if (this.tEdit_FindCondition.Visible)
			{
				this.tEdit_FindCondition.Focus();
			}
			else if (this.tNedit_FindCondition.Visible)
			{
				this.tNedit_FindCondition.Focus();
			}
			else if (this.tNedit_FindConditionCodeType.Visible)
			{
				this.tNedit_FindConditionCodeType.Focus();
			}
		}

		/// <summary>
		/// �������ʃO���b�h�}�E�X�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Search_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
			
			// �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement element = null;

			objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

			element = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// �Z���ȊO�̏ꍇ�͈ȉ��̏������L�����Z������
			if(element == null)
			{
				return;
			}
			
			object oContextRow = null;

			oContextRow = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

			if (oContextRow == null)
			{
				return;
			}

			Infragistics.Win.UltraWinGrid.UltraGridRow row =(Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;

			StockDataSet.StockSlipRow stockSlipRow = this._searchSlipAcs.DataSet.StockSlip.FindByStockRowNo(Convert.ToInt32(row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].Value));

			SearchRetStockSlip searchRetStockSlip = this.CreateSearchRetStockSlip(stockSlipRow);

			if (this.SearchRetStockSlipSelected != null)
			{
				this.SearchRetStockSlipSelected(this, searchRetStockSlip);

				// �p�l���ύX�C�x���g�R�[������
				this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_StockSlipLuncher);
			}
		}

		/// <summary>
		/// �d���f�[�^�N���X��������
		/// </summary>
		/// <param name="row">�d���f�[�^�s�N���X</param>
		/// <returns>�d���f�[�^�N���X</returns>
		private SearchRetStockSlip CreateSearchRetStockSlip(StockDataSet.StockSlipRow row)
		{
			SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();
			//searchRetStockSlip.StockRowNo = row.StockRowNo;
			searchRetStockSlip.EnterpriseCode = row.EnterpriseCode;
			searchRetStockSlip.SectionCode = row.SectionCode;
			//searchRetStockSlip.SectionName = row.SectionName;
			searchRetStockSlip.SupplierSlipNo = row.SupplierSlipNo;
			searchRetStockSlip.StockAddUpADate = row.StockAddUpADate;
			searchRetStockSlip.ArrivalGoodsDay = row.ArrivalGoodsDay;
			searchRetStockSlip.StockAgentCode = row.StockAgentCode;
            searchRetStockSlip.StockDate = row.StockDate;
			searchRetStockSlip.StockAgentName = row.StockAgentName;
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //searchRetStockSlip.CustomerCode = row.CustomerCode;
            //searchRetStockSlip.CustomerName = row.CustomerName;
            searchRetStockSlip.SupplierCd = row.CustomerCode;
            searchRetStockSlip.SupplierNm1 = row.CustomerName;
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			// 2007.10.12 sasaki >>
			//searchRetStockSlip.WarehouseCode = row.WarehouseCode;
			//searchRetStockSlip.WarehouseName = row.WarehouseName;
			// 2007.10.12 sasaki <<
			searchRetStockSlip.SupplierFormal = row.SupplierFomal;
			//searchRetStockSlip.SupplierFomalName = row.SupplierFomalName;
			searchRetStockSlip.SupplierSlipCd = row.SupplierSlipCd;
			//searchRetStockSlip.SupplierSlipCdName = row.SupplierSlipCdName;
			searchRetStockSlip.DebitNoteDiv = row.DebitNoteDiv;
			//searchRetStockSlip.DebitNoteDivName = row.DebitNoteDivName;
			searchRetStockSlip.StockGoodsCd = row.StockGoodsCd;
			//searchRetStockSlip.StockGoodsCdName = row.StockGoodsCdName;
			searchRetStockSlip.AccPayDivCd = row.AccPayDivCd;
			//searchRetStockSlip.AccPayDivCdName = row.AccPayDivCdName;
			// 2007.10.12 sasaki >>
			//searchRetStockSlip.CarrierEpCode = row.CarrierCode;
			//searchRetStockSlip.CarrierEpName = row.CarrierName;
			// 2007.10.12 sasaki <<
			searchRetStockSlip.InputDay = row.InputDay;
			searchRetStockSlip.StockTotalPrice = row.StockTotalPrice;
			searchRetStockSlip.StockSubttlPrice = row.StockSubttlPrice;
			searchRetStockSlip.PartySaleSlipNum = row.PartySaleSlipNum;
			searchRetStockSlip.SupplierSlipNote1 = row.SupplierSlipNote1;
			searchRetStockSlip.SupplierSlipNote2 = row.SupplierSlipNote2;
			return searchRetStockSlip;
		}

		/// <summary>
		/// �O���b�h�t�H���g�T�C�Y�R���{�{�b�N�X�I��l�ύX�㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tComboEditor_GridFontSize_ValueChanged(object sender, System.EventArgs e)
		{
			if (this.tComboEditor_GridFontSize.Value is int)
			{
				int fontSize = (int)this.tComboEditor_GridFontSize.Value;

				if (fontSize != 0)
				{
					this.uGrid_Search.Font = new System.Drawing.Font("�l�r �S�V�b�N", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				}
			}
		}

		/// <summary>
		/// ���l���̓G�f�B�^���͒l�ύX�㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tNedit_FindCondition_ValueChanged(object sender, System.EventArgs e)
		{
			/*
			if (!this.tNedit_FindCondition.Modified)
			{
				return;
			}

			// �R���{�G�f�B�^�I��l�擾����(���o�����敪)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			if (findConditionCode ==EDIT_TYPE_NumberPlate4)
			{
				if (this.tNedit_FindCondition.GetInt() != 0)
				{
					this.uCheckEditor_NumberPlate4.Checked = false;
				}
			}
			*/
		}

		/// <summary>
		/// ���b�Z�[�W��\���^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_MessageUnDisp_Tick(object sender, System.EventArgs e)
		{
			this.timer_MessageUnDisp.Enabled = false;
			
			this.customControl_ExtractWait.Visible = false;
		}

		/// <summary>
		/// �������ʃO���b�h�s�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Search_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			//e.Row.Cells[SEARCH_COL_AcptAnOdrStatusName].Appearance.ForeColor = this.GetKindCellForeColor(e.Row);
		}

		/// <summary>
		/// �R���{�G�f�B�^�I���m���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tComboEditor_FindCondition_SelectionChangeCommitted(object sender, EventArgs e)
		{
			//
		}

        /// <summary>
        /// �`�[��ʃR���{�G�f�B�^�ύX�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SupplierFormal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int supplierFormal = this.GetSelectedValue(this.tComboEditor_SupplierFormal);
            this.SetItemtStockGoodsCd(supplierFormal);
            this.SetItemtSupplierSlipCd(supplierFormal);
        }


        /// <summary>
        /// �v��敪�R���{�G�f�B�^�A�C�e���ݒ菈��
        /// </summary>
        /// <param name="supplierFormal">�d���`��</param>
        private void SetItemtStockGoodsCd(int supplierFormal)
        {
            switch (supplierFormal)
            {
                case 0:
                    {
                        this.tComboEditor_StockGoodsCd.Items.Clear();

                        Infragistics.Win.ValueListItem item99 = new Infragistics.Win.ValueListItem();
                        item99.Tag = 1;
                        item99.DataValue = 99;
                        item99.DisplayText = "�S��";
                        this.tComboEditor_StockGoodsCd.Items.Add(item99);

                        Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                        item0.Tag = 2;
                        item0.DataValue = 0;
                        item0.DisplayText = "����";
                        this.tComboEditor_StockGoodsCd.Items.Add(item0);

                        //Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                        //item2.Tag = 3;
                        //item2.DataValue = 2;
                        //item2.DisplayText = "����Œ���";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item2);

                        //Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
                        //item3.Tag = 4;
                        //item3.DataValue = 3;
                        //item3.DisplayText = "�c������";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item3);

                        //Infragistics.Win.ValueListItem item4 = new Infragistics.Win.ValueListItem();
                        //item4.Tag = 5;
                        //item4.DataValue = 4;
                        //item4.DisplayText = "����Œ���(���|�p)";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item4);

                        //Infragistics.Win.ValueListItem item5 = new Infragistics.Win.ValueListItem();
                        //item5.Tag = 6;
                        //item5.DataValue = 5;
                        //item5.DisplayText = "�c������(���|�p)";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item5);

                        Infragistics.Win.ValueListItem item6 = new Infragistics.Win.ValueListItem();
                        item6.Tag = 3;
                        item6.DataValue = 6;
                        item6.DisplayText = "���v";
                        this.tComboEditor_StockGoodsCd.Items.Add(item6);

                        this.tComboEditor_StockGoodsCd.Value = 99;

                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_StockGoodsCd.Items.Clear();

                        Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                        item0.Tag = 1;
                        item0.DataValue = 0;
                        item0.DisplayText = "����";
                        this.tComboEditor_StockGoodsCd.Items.Add(item0);

                        this.tComboEditor_StockGoodsCd.Value = 0;

                        break;
                    }
            }
        }

        /// <summary>
        /// �v��敪�R���{�G�f�B�^�A�C�e���ݒ菈��
        /// </summary>
        /// <param name="supplierFormal">�d���`��</param>
        private void SetItemtSupplierSlipCd(int supplierFormal)
        {
            //switch (supplierFormal)
            //{
            //    case 0:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();

            //            Infragistics.Win.ValueListItem item99 = new Infragistics.Win.ValueListItem();
            //            item99.Tag = 1;
            //            item99.DataValue = 99;
            //            item99.DisplayText = "�S��";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item99);

            //            Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
            //            item0.Tag = 2;
            //            item0.DataValue = 11;
            //            item0.DisplayText = "�|�d��";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item0);

            //            Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
            //            item2.Tag = 3;
            //            item2.DataValue = 21;
            //            item2.DisplayText = "�|�ԕi";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item2);

            //            Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
            //            item3.Tag = 4;
            //            item3.DataValue = 10;
            //            item3.DisplayText = "�����d��";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item3);

            //            Infragistics.Win.ValueListItem item4 = new Infragistics.Win.ValueListItem();
            //            item4.Tag = 5;
            //            item4.DataValue = 20;
            //            item4.DisplayText = "�����ԕi";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item4);

            //            this.tComboEditor_SupplierSlipCd.Value = 99;

            //            break;
            //        }
            //    case 1:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();

            //            Infragistics.Win.ValueListItem item99 = new Infragistics.Win.ValueListItem();
            //            item99.Tag = 1;
            //            item99.DataValue = 99;
            //            item99.DisplayText = "�S��";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item99);

            //            Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
            //            item0.Tag = 2;
            //            item0.DataValue = 11;
            //            item0.DisplayText = "�|�d��";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item0);

            //            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
            //            item1.Tag = 3;
            //            item1.DataValue = 21;
            //            item1.DisplayText = "�|�ԕi";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item1);

            //            this.tComboEditor_SupplierSlipCd.Value = 99;

            //            break;
            //        }
            //}
        }

		# endregion
	}
}
