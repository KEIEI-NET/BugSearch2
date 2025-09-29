using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���Ӑ�ȈՌ����t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ挟���t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2007.02.12</br>
	/// <br>Update Note: ���ו\�����ʂ̕ύX( ���Ӑ�J�i�̏������瓾�Ӑ�R�[�h�����ɕύX )</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2009/07/10</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/25 ���юR</br>
    /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/27 ���юR</br>
    /// <br>             PM1107C:�i�荞�݃t�B���^�[�ǉ�(#9)</br>
    /// <br>------------------------------------------------------------------------------------</br> 
    /// <br>Update Note: 2011/08/11 ���J</br>
    /// <br>             redmine #23479 �i�荞�݃t�B���^�[�ǉ�(#9)</br>
    /// <br>------------------------------------------------------------------------------------</br> 
    ///<br>Update Note: 2011/08/19 ���C��</br>
    /// <br>             redmine #23705 PCC���Зp���Ӑ�K�C�h�ǉ� for #23705</br>
    /// <br>------------------------------------------------------------------------------------</br>  
    /// </remarks>
	public partial class PMKHN04005UA : System.Windows.Forms.Form
	{
        /// <summary>
        /// ���Ӑ�I���C�x���g�f���Q�[�g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        public delegate void CustomerSelectEventHandler( object sender, CustomerSearchRet customerSearchRet );
        
        // ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// ���Ӑ挟���t�H�[���t���[���N���X�f�t�H���g�R���X�g���N�^
		/// </summary>
		public PMKHN04005UA()
		{
			InitializeComponent();

			// �ϐ�������
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._imageList16 = IconResourceManagement.ImageList16;
			this._searchDataView = new DataView();
			this._initialDataRead = new InitialDataReadHandler(this.InitialDataRead);
			this._extractConditionItemControlDictionary = new Dictionary<string, Panel>();
            this._extractionConditionInfo = new CustomerSimpleSearchCndtn();
			this._extractConditionList.Add(this._extractionConditionInfo.Clone());
			this._controlScreenSkin = new ControlScreenSkin();
            this._salesTtlStAcs = new SalesTtlStAcs();
            this._paraMngSectionCode = string.Empty;
            this._paraMngSectionName = string.Empty;
            this._autoSearch = true;
            this._secInfoSetAcs = new SecInfoSetAcs();
		}

		/// <summary>
		/// ���Ӑ挟���t�H�[���t���[���N���X�R���X�g���N�^
		/// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
		public PMKHN04005UA(int searchMode, int executeMode) : this()
		{
			this._searchMode = searchMode;
			this._executeMode = executeMode;
		}

        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
        /// <summary>
        /// PCC���Зp���Ӑ挟���t�H�[���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
        public PMKHN04005UA(int searchMode, int executeMode, int pccuoeMode)
            : this()
        {
            this._searchMode = searchMode;
            this._executeMode = executeMode;
            this._pccuoeMode = pccuoeMode;
        }
        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
		
		# endregion

		// ===================================================================================== //
		// �C���i�[�N���X
		// ===================================================================================== //
		# region Inner Class
		/// <summary>
		/// �Z�����������N���X�iIMergedCellEvaluator �C���^�t�F�[�X���C���v�������g�j
		/// </summary>
		private class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
		{
			/// <summary>
			/// �Z�������������菈��
			/// </summary>
			/// <param name="row1">�s�P</param>
			/// <param name="row2">�s�Q</param>
			/// <param name="column">��</param>
			/// <returns>��Ɋ֘A�t����ꂽrow1��row2�̃Z�������������ꍇ�ATrue��Ԃ��܂�</returns>
			public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
			{
				int customerCode1 = Convert.ToInt32(row1.Cells[SEARCH_COL_CustomerCode].Value);
				int customerCode2 = Convert.ToInt32(row2.Cells[SEARCH_COL_CustomerCode].Value);

				if ((customerCode1 == 0) || (customerCode2 == 0)) return false;
				return customerCode1 == customerCode2;
			}
		}
		# endregion

		// ===================================================================================== //
		// �񋓌^
		// ===================================================================================== //
		# region Enum
		/// <summary>�f�[�^������s���Ώۂ̗񋓌^�ł��B</summary>
		private enum DataControlType : int
		{
			Customer = 0
		}

		/// <summary>�f�[�^�̑I���ςݐݒ�̗񋓌^�ł��B</summary>
		private enum RowSelected : int
		{
			No = 0,
			Customer = 1
		}

		# endregion

		// ===================================================================================== //
		// �����Ŏg�p����萔�Q
		// ===================================================================================== //
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/27 ���юR</br>
        /// <br>             PM1107C:�i�荞�݃t�B���^�[�ǉ�(#9)</br>
        /// <br>------------------------------------------------------------------------------------</br> 
		#region Const
		// �f�[�^�e�[�u�����`�i���Ӑ挟�����ʏ��j
		internal const string SEARCH_TABLE							= "SEARCHTABLE";
		internal const string SEARCH_COL_EnterpriseCode				= "EnterpriseCode";				// ��ƃR�[�h(�J��������)
		internal const string SEARCH_COL_CustomerCode				= "CustomerCode";				// ���Ӑ�R�[�h
		internal const string SEARCH_COL_CustomerSubCode			= "CustomerSubCode";			// ���Ӑ�T�u�R�[�h
		internal const string SEARCH_COL_Name						= "Name";						// ����
		internal const string SEARCH_COL_Name2						= "Name2";						// ���̂Q
        // 2011/7/25 XUJS ADD STA>>>>>>
        internal const string SEARCH_COL_Snm                        = "Snm";						// ����
        // 2011/7/25 XUJS ADD END<<<<<<
		internal const string SEARCH_COL_Kana						= "Kana";						// �J�i
		internal const string SEARCH_COL_CustomerSearchRet			= "CustomerSearchRet";			// ���Ӑ挟���߂�l�N���X
		internal const string SEARCH_COL_HtmlString					= "HtmlString";					// �ڍו\���pHTML������
		internal const string SEARCH_COL_SelectedFlg				= "SelectedFlg";				// �I���ς݃t���O
		internal const string SEARCH_COL_LogicalDeleteCode			= "LogicalDeleteCode";			// �_���폜�敪�i���Ӑ�j

		private const string EXTRACT_CONDITION_XML_FILE_NAME = "PMKHN04005U_ExtractCondition.XML";	// ���o�����Z�b�e�B���O�w�l�k�t�@�C���p�X
		private const string FILENAME_COLDISPLAYSTATUS = "PMKHN04005U_ColSetting.DAT";				// ��\����ԃZ�b�e�B���OXML�t�@�C����
		private const string TEMP_FOLDER_NAME = "Temp";												// Temp�t�H���_����
		//private const string MESSAGE_NONDATA = "�Y������f�[�^��������܂���ł����B";			// �Y���f�[�^�������b�Z�[�W  //DEL 2011/08/11
		private const string RETURN_BUTTON_TOOLTIPTEXT	= "�O��̒��o�����ɖ߂��܂��B";				// �߂��{�^���c�[���`�b�v�e�L�X�g

		private const int EXIST_CODE_CHECKED = 1;
		private const int EXIST_CODE_UNCHECKED = 0;
		# endregion

		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		#region Const
        /// <summary>SEARCHMODE �ʏ�</summary>
        public const int SEARCHMODE_NORMAL = 0;
        /// <summary>SEARCHMODE �[����</summary>
        public const int SEARCHMODE_RECEIVER = 2;   // �[����
        /// <summary>SEARCHMODE ���Ӑ�̂�</summary>
        public const int SEARCHMODE_CUSTOMER_ONLY = 3;
        /// <summary>EXECUTEMODE �ʏ�</summary>
        public const int EXECUTEMODE_NORMAL = 0;
        /// <summary>EXECUTEMODE �K�C�h�̂�</summary>
        public const int EXECUTEMODE_GUIDE_ONLY = 1;
        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
        /// <summary>
        /// 0:�ʏ�
        /// </summary>
        public const int PCCUOEN_NORMAL_ONLY = 0;
        /// <summary>
        /// 1:PCC���Зp
        /// </summary>
        public const int PCCUOE_CMPNYST_ONLY = 1;
        /// <summary>
        /// 2:PCC�}�X�����p
        /// </summary>
        public const int PCCUOE_MASTER_ONLY = 2;
        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
        
        # endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = "";												// ��ƃR�[�h
		private ImageList _imageList16 = null;												// �C���[�W���X�g
        private CustomerSimpleSearchCndtn _extractionConditionInfo = null;		// ���o�������͏��N���X
		private delegate void InitialDataReadHandler();
		InitialDataReadHandler _initialDataRead = null;
		private DataView _searchDataView = null;											// ���Ӑ挟�����ʃf�[�^�r���[
		private Dictionary<string, Panel> _extractConditionItemControlDictionary = null;	// ���o�������͍���Dictionary
        private List<CustomerSimpleSearchCndtn> _extractConditionList = new List<CustomerSimpleSearchCndtn>();	// ���o�����������X�g
		private ColDisplayStatusList _colDisplayStatusList = null;							// ��\����ԃR���N�V�����N���X
		private int _selectedRowIndex = -1;													// �I���sIndex
		private int _searchMode = SEARCHMODE_NORMAL;										// �������[�h
		private int _executeMode = EXECUTEMODE_NORMAL;										// �N�����[�h
		private ControlScreenSkin _controlScreenSkin;
        private string _paraMngSectionCode;                                                 // �i���o�����j�Ǘ����_�R�[�h
        private string _paraMngSectionName;                                                 // �i���o�����j�Ǘ����_����
        private bool _autoSearch;                                                           // ���������敪�i�t�h����j
        private SalesTtlStAcs _salesTtlStAcs = null;
        // 2011/07/27 XUJS ADD STA>>>>>>
        private SecInfoSetAcs _secInfoSetAcs = null;                                        // ���_�A�N�Z�X�N���X
        private int _praCustomerCode = -1;
        // 2011/07/27 XUJS ADD END<<<<<<
        private int _pccuoeMode;                                                            //PCC���Зp�^�C�v ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19
        
		# endregion

        // ===================================================================================== //
        // �p�u���b�N�@�v���p�e�B
        // ===================================================================================== //
        # region Public Propaty
        /// <summary>
        /// �Ǘ����_�R�[�h�@�v���p�e�B
        /// </summary>
        public string MngSectionCode
        {
            get { return _paraMngSectionCode; }
            set { _paraMngSectionCode = value; }
        }
        /// <summary>
        /// �Ǘ����_���́@�v���p�e�B
        /// </summary>
        public string MngSectionName
        {
            get { return _paraMngSectionName; }
            set { _paraMngSectionName = value; }
        }
        /// <summary>
        /// ���������J�n�敪�@�v���p�e�B
        /// </summary>
        public bool AutoSearch
        {
            get { return _autoSearch; }
            set { _autoSearch = value; }
        }
        # endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Events
		/// <summary>
		/// ���Ӑ�I�����C�x���g
		/// </summary>
		public event CustomerSelectEventHandler CustomerSelect;
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// ���Ӑ挟������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟�����������s���܂��B</br>
		/// <br>Programer  : 22018�@��ؐ��b</br>
		/// <br>Date       : 2005.09.05</br>
		/// </remarks>
		public void Search()
		{
			this.Search_UButton_Click(this, new EventArgs());
		}

		/// <summary>
		/// ���Ӑ挟�������i���Ӑ�R�[�h�w��j
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ�R�[�h���w�肵�ē��Ӑ挟�����������s���܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.09.05</br>
		/// </remarks>
		public void Search(string enterpriseCode, int customerCode)
		{
			this.Search_UButton_Click(this, new EventArgs());
		}

		/// <summary>
		/// �I�����i��ƃR�[�h�E���Ӑ�R�[�h�j�擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS[0:�擾���� 0�ȊO:�擾���s]</returns>
		/// <remarks>
		/// <br>Note       : ���ݑI�𒆂̊�ƃR�[�h�A���Ӑ�R�[�h���擾���܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		public int GetSelectInfo(out string enterpriseCode, out int customerCode)
		{
			enterpriseCode = "";
			customerCode = 0;
			CustomerSearchRet customerSearchRet;

			int status = this.GetSelectInfo(out customerSearchRet);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				enterpriseCode = customerSearchRet.EnterpriseCode;
				customerCode = customerSearchRet.CustomerCode;
			}

			return status;
		}

		/// <summary>
		/// �I�����i��ƃR�[�h�E���Ӑ�R�[�h�j�擾����
		/// </summary>
		/// <param name="customerSearchRet">���Ӑ挟�����ʃN���X</param>
		/// <returns>STATUS[0:�擾���� 0�ȊO:�擾���s]</returns>
		/// <remarks>
		/// <br>Note       : ���ݑI�𒆂̓��Ӑ挟�����ʃN���X���擾���܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		public int GetSelectInfo(out CustomerSearchRet customerSearchRet)
		{
			customerSearchRet = null;

			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				return -1;
			}

			// �I���s�̃C���f�b�N�X���擾
			CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
			int index = cm.Position;	

			// �w��s�̓��e���擾
			DataRow row = this._searchDataView[index].Row;

			// ���Ӑ挟�����ʃN���X�擾�����i�O���b�h�s���j
			customerSearchRet = this.DataRowToCustomerSearchRet(row);

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}

		/// <summary>
		/// �I���ςݓ��Ӑ�R�[�h���X�g�ݒ菈��
		/// </summary>
		/// <param name="customerCodeList">���Ӑ�R�[�h���X�g</param>
		/// <remarks>
		/// <br>Note       : ���݂l�c�h�e��ʂŕ\������Ă��链�Ӑ�R�[�h��ݒ肵�܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		public void SetSelectedList(ArrayList customerCodeList)
		{
			// �I���ς݃t���O�ݒ菈��
			this.SetSelectedFlg(customerCodeList);

			// �O���b�h�s�\���ݒ菈��
			this.SettingGridRowAppearance();
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// �����ݒ�n�f�[�^���[�h����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ݒ�n�f�[�^�����[�h���܂��B�񓯊������ł��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void InitialDataRead()
		{
			//
		}

		/// <summary>
		/// �����ݒ�n�f�[�^���[�h�����R�[���o�b�N���\�b�h
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ݒ�n�f�[�^���[�h����������������Ɏ��s����܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void InitialDataReadCallBack(IAsyncResult ar)
		{
			InitialDataReadHandler initialDataReadHandler = (InitialDataReadHandler)ar.AsyncState;
			initialDataReadHandler.EndInvoke(ar);
		}

		/// <summary>
		/// �c�[���o�[�����ݒ菈��
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�̏����ݒ���s���܂�</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void SetToolbar()
		{
			// �C���[�W���X�g��ݒ肷��
			Main_ToolbarsManager.ImageListSmall = this._imageList16;

			// ���O�C���S���҂̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginTitle_LabelTool"];
			loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			
			// ����̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
			closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

			// �߂�̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Return_ButtonTool"];
			returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
			
			// ���Ӑ�V�K�̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool customerNewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerNew_ButtonTool"];
			customerNewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERNEW;
			
			// ���Ӑ�ҏW�̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool customerEditButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerEdit_ButtonTool"];
			customerEditButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERINPUT1;

			// ���Ӑ�폜�̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool customerDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerDelete_ButtonTool"];
			customerDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERDELETE;
			
			// ���Ӑ敜���̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool customerRevivalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerRevival_ButtonTool"];
			customerRevivalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

			// �ݒ�̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["SetUp_ButtonTool"];
			setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

			// �ڍו\���̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.PopupMenuTool detailViewPopUpMenu = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["DetailView_PopupMenuTool"];
			detailViewPopUpMenu.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;

			// �I���̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
			selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

			// ����̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool clearButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Clear_ButtonTool"];
			clearButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;

			// �����̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool searchButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Search_ButtonTool"];
			searchButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

            //if (this._executeMode == EXECUTEMODE_GUIDE_ONLY)
            //{
            //    selectButton.SharedProps.Visible = true;
            //    customerNewButton.SharedProps.Visible = false;
            //    customerEditButton.SharedProps.Visible = false;
            //    customerDeleteButton.SharedProps.Visible = false;
            //}
            //else
            //{
            //    selectButton.SharedProps.Visible = false;
            //    customerNewButton.SharedProps.Visible = true;
            //    customerEditButton.SharedProps.Visible = true;
            //    customerDeleteButton.SharedProps.Visible = true;
            //}
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.09.03</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/27 ���юR</br>
        /// <br>             PM1107C:�i�荞�݃t�B���^�[�ǉ�(#9)</br>
        /// <br>------------------------------------------------------------------------------------</br> 
		/// </remarks>
		private void InitialSetting()
		{
			// �X�L�����[�h
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
			CustomControlAppearance controlAppearance = this._controlScreenSkin.GetControlAppearance();

			this.SearchResultHeader_ULabel.Appearance.BackColor = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.SearchResultHeader_ULabel.Appearance.BackColor2 = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.SearchResultHeader_ULabel.Appearance.BackGradientStyle = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.SearchResultHeader_ULabel.Appearance.ForeColor = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;

			// �c�[���o�[�����ݒ菈��
			this.SetToolbar();

			// MDI�^SDI�t�H�[���ݒ菈��
			this.MdiSdiFormSetting();

			// �e�R���g���[�������ݒ�
			this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;
			this.GridFontSize_TComboEditor.Value = 10;
			
			// ���Ӑ挟�����ʃf�[�^�e�[�u���ݒ菈��
			this.SettingCustomerSearchDataTable();

			// �Œ�w�b�_�[�@�\�̗L���ɂ���
			this.SearchResult_UGrid.DisplayLayout.UseFixedHeaders = true;

			// ���Ӑ挟�����ʃO���b�h�J�������ݒ菈��
			this.SettingSearchGridColumn(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);

			// �s�T�C�Y��ݒ�
            this.SearchResult_UGrid.DisplayLayout.Override.DefaultRowHeight = 20;

            // �C�� 2009/07/10 >>>
			//this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerCode].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            // �C�� 2009/07/10 <<<

            // 2011/07/27 XUJS ADD STA>>>>>>
            this.FilterResult_Panel.Dock = DockStyle.Top;
            // 2011/07/27 XUJS ADD END<<<<<<
			this.ExtractResult_Panel.Dock = DockStyle.Fill;

            // ����S�̐ݒ���Q��
            SalesTtlSt salesTtlSt;
            // 2008.08.28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //int status = this._salesTtlStAcs.Read(out salesTtlSt, this._enterpriseCode);
            int status = this._salesTtlStAcs.Read(out salesTtlSt, this._enterpriseCode, this._paraMngSectionCode);
            // 2008.08.28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            if (status == 0)
            {
                // �u�����_�̂ݕ\���v�̏ꍇ�̂݁A�Ǘ����_�������͂n�m�ɂ���
                if ( salesTtlSt.CustGuideDispDiv == 1 )
                {
                    // �Ǘ����_��������
                    this._extractionConditionInfo.MngSectionCode = _paraMngSectionCode;
                    this._extractionConditionInfo.MngSectionName = _paraMngSectionName;
                    
                    //// �����I���`�F�b�N
                    //this.MultiSelect_UCheckEditor.Checked = true;

                    this._paraMngSectionCode = string.Empty;
                    this._paraMngSectionName = string.Empty;
                }
                else
                {
                    // �v���p�e�B���N���A����
                    this._paraMngSectionCode = string.Empty;
                    this._paraMngSectionName = string.Empty;

                    // ���������J�n���L�����Z������
                    this._autoSearch = false;
                }
            }
            this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "F3�F�����ݒ�@F6�F�i���@ESC�F�I��"; //ADD 2011/08/11
		}

		/// <summary>
		/// �c�[���o�[�{�^���L�������ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�{�^���L�������ݒ���s���܂�</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.05.19</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting()
		{
			Infragistics.Win.UltraWinToolbars.ButtonTool returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Return_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool customerEditButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerEdit_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool customerDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerDelete_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool customerRevivalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerRevival_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

			string enterpriseCode;
			int customerCode;
			Infragistics.Win.UltraWinGrid.UltraGridRow row = this.SearchResult_UGrid.ActiveRow;

			// �I�����i��ƃR�[�h�E���Ӑ�R�[�h�j�擾����
			int status = this.GetSelectInfo(out enterpriseCode, out customerCode);
			
			if ((row == null) || (status != 0))
			{
				customerEditButton.SharedProps.Enabled = false;
				customerDeleteButton.SharedProps.Enabled = false;
				customerRevivalButton.SharedProps.Enabled = false;
				selectButton.SharedProps.Enabled = false;

			}
			else
			{
				// ���Ӑ�ҏW�A���Ӑ�폜�A���Ӑ敜���{�^������
				if (customerCode == 0)
				{
					customerEditButton.SharedProps.Enabled = false;
					customerDeleteButton.SharedProps.Enabled = false;
					customerRevivalButton.SharedProps.Enabled = false;
					selectButton.SharedProps.Enabled = false;
				}
				else
				{
					int logicalDeleteCodeCustomer = Convert.ToInt32(row.Cells[SEARCH_COL_LogicalDeleteCode].Text.ToString());
					if (logicalDeleteCodeCustomer != 0)
					{
						customerEditButton.SharedProps.Enabled = false;
						customerDeleteButton.SharedProps.Enabled = false;
						customerRevivalButton.SharedProps.Enabled = true;
						selectButton.SharedProps.Enabled = false;
					}
					else
					{
						customerEditButton.SharedProps.Enabled = true;
						customerDeleteButton.SharedProps.Enabled = true;
						selectButton.SharedProps.Enabled = true;
						customerRevivalButton.SharedProps.Enabled = false;
					}
				}
			}

			// �߂�{�^������
			if (this._extractConditionList.Count > 1)
			{
				if (returnButton != null)
				{
					returnButton.SharedProps.Enabled = true;

					int lastIndex = this._extractConditionList.Count - 1;
					returnButton.SharedProps.ToolTipText = RETURN_BUTTON_TOOLTIPTEXT + this._extractConditionList[lastIndex - 1].ToString();
				}
			}
			else
			{
				if (returnButton != null)
				{
					returnButton.SharedProps.Enabled = false;
					returnButton.SharedProps.ToolTipText = RETURN_BUTTON_TOOLTIPTEXT;
				}
			}
		}

	
		/// <summary>
		/// MDI�^SDI�t�H�[���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t�H�[���̂l�c�h�^�r�c�h�X�^�C���Ɋ�Â�����ʐ�����s���܂��B</br>
		/// <br>Programmer : 980079 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void MdiSdiFormSetting()
		{
			if (this.MdiParent == null)
			{
				// ����̃A�C�R���ݒ�
				Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
				if (closeButton != null)
				{
					closeButton.SharedProps.Caption = "����(&X)";
					closeButton.SharedProps.Visible = true;
				}

			}
			else
			{
				// ����̃A�C�R���ݒ�
				Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
				if (closeButton != null)
				{
					closeButton.SharedProps.Visible = false;
				}
			}
		}

		/// <summary>
		/// ���Ӑ挟�����ʃf�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟�����ʂ̃f�[�^�e�[�u����ݒ肵�܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		internal void SettingCustomerSearchDataTable()
		{
			//--------------------------------------------------
			//  �f�[�^�Z�b�g�A�f�[�^�e�[�u���̐���
			//--------------------------------------------------
			// �f�[�^�e�[�u���̍쐬
			DataTable searchTable = new DataTable(SEARCH_TABLE);

			//--------------------------------------------------
			// �f�[�^�J�������̐���
			//--------------------------------------------------
			// ��ƃR�[�h
			DataColumn EnterpriseCode = new DataColumn(SEARCH_COL_EnterpriseCode, typeof(String), "", MappingType.Element);
			EnterpriseCode.Caption = "��ƃR�[�h";
			
			// ���Ӑ�R�[�h
			DataColumn CustomerCode = new DataColumn(SEARCH_COL_CustomerCode, typeof(Int32), "", MappingType.Element);
			CustomerCode.Caption = "���Ӑ�R�[�h";

			// ���Ӑ�T�u�R�[�h
			DataColumn CustomerSubCode = new DataColumn(SEARCH_COL_CustomerSubCode, typeof(String), "", MappingType.Element);
			CustomerSubCode.Caption = "���Ӑ�T�u�R�[�h";

			// ����
			DataColumn Name = new DataColumn(SEARCH_COL_Name, typeof(String), "", MappingType.Element);
			Name.Caption = "���Ӑ於��";

			// ���̂Q
			DataColumn Name2 = new DataColumn(SEARCH_COL_Name2, typeof(String), "", MappingType.Element);
			Name.Caption = "���Ӑ於�̂Q";

            // 2011/7/25 XUJS ADD STA>>>>>>
            // ����
            DataColumn Snm = new DataColumn(SEARCH_COL_Snm, typeof(String), "", MappingType.Element);
            Snm.Caption = "���Ӑ旪��";
            // 2011/7/25 XUJS ADD END<<<<<<

			// �J�i
			DataColumn Kana = new DataColumn(SEARCH_COL_Kana, typeof(String), "", MappingType.Element);
			Kana.Caption = "���Ӑ於(��)";

			// ���Ӑ挟�����ʃN���X
			DataColumn CustomerSearchRetCol = new DataColumn(SEARCH_COL_CustomerSearchRet, typeof(CustomerSearchRet), "", MappingType.Element);
			CustomerSearchRetCol.Caption = "���Ӑ挟�����ʃN���X";

			// �ڍו\���pHTML������
			DataColumn HtmlString = new DataColumn(SEARCH_COL_HtmlString, typeof(String), "", MappingType.Element);
			HtmlString.Caption = "�ڍו\���pHTML������";

			// �I���ς݃t���O
			DataColumn SelectedFlg = new DataColumn(SEARCH_COL_SelectedFlg, typeof(Int32), "", MappingType.Element);
			HtmlString.Caption = "�I���ς݃t���O";

			// �_���폜�敪�i���Ӑ�j
			DataColumn LogicalDeleteCodeCustomer = new DataColumn(SEARCH_COL_LogicalDeleteCode, typeof(Int32), "", MappingType.Element);
			HtmlString.Caption = "�_���폜�敪�i���Ӑ�j";

			//--------------------------------------------------
			//  �f�[�^�Z�b�g�A�f�[�^�e�[�u���̏�����
			//--------------------------------------------------
			// �f�[�^�Z�b�g�̏�����
			this.Search_DataSet.Tables.AddRange(new DataTable[] {searchTable});

			// �f�[�^�e�[�u���̏�����
			searchTable.Columns.AddRange(new DataColumn[] {
															  CustomerCode,					// ���Ӑ�R�[�h
															  CustomerSubCode,				// ���Ӑ�T�u�R�[�h
															  Name,							// ����
                                                              // 2011/7/25 XUJS ADD STA>>>>>>
                                                              Snm,                          // ����
                                                              // 2011/7/25 XUJS ADD END<<<<<<
															  Kana,							// �J�i
															  EnterpriseCode,				// ��ƃR�[�h(�J��������)
															  Name2,						// ���̂Q
															  CustomerSearchRetCol,			// ���Ӑ挟�����ʃN���X
															  HtmlString,					// �ڍו\���pHTML������
															  SelectedFlg,					// �I���ς݃t���O
															  LogicalDeleteCodeCustomer,	// �_���폜�敪�i���Ӑ�j
															});

			this._searchDataView.Table = searchTable;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._searchDataView.Sort = string.Format( "{0} ASC", SEARCH_COL_CustomerCode );
            this._searchDataView.RowFilter = string.Format( "{0}=0", SEARCH_COL_LogicalDeleteCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			//�@�O���b�h�Ƀf�[�^�Z�b�g���o�C���h
			//this.SearchResult_UGrid.DataSource = this.Search_DataSet.Tables[SEARCH_TABLE];
            this.SearchResult_UGrid.DataSource = _searchDataView;

		}

		/// <summary>
		/// ���Ӑ挟�����ʃN���X�擾�����i�O���b�h�s���j
		/// </summary>
		/// <param name="row">�f�[�^�s���</param>
		/// <returns>�擾�������Ӑ挟�����ʃN���X�f�[�^</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�s�̏�񂩂瓾�Ӑ挟�����ʃN���X���擾���܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private CustomerSearchRet DataRowToCustomerSearchRet(DataRow row)
		{
			return (CustomerSearchRet)row[SEARCH_COL_CustomerSearchRet];
		}

		/// <summary>
		/// �I���ς݃t���O�ݒ菈��
		/// </summary>
		/// <param name="customerCodeList">���Ӑ�R�[�h���X�g</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ�R�[�h���X�g�����ɁA�I���ς݃t���O��ݒ肵�܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private void SetSelectedFlg(ArrayList customerCodeList)
		{
			// �I���s�̃C���f�b�N�X���擾
			for(int i = 0; i < this._searchDataView.Count; i++)
			{
				// �w��s�̓��e���擾
				DataRow row = this._searchDataView[i].Row;

				int customerCode = (int)row[SEARCH_COL_CustomerCode];

				row[SEARCH_COL_SelectedFlg] = (int)RowSelected.No;

				foreach(int listCustomerCode in customerCodeList)
				{
					if (customerCode == listCustomerCode)
					{
						row[SEARCH_COL_SelectedFlg] = (int)RowSelected.Customer;
						break;
					}
				}
			}
		}

		/// <summary>
		/// ���Ӑ挟�����ʃO���b�h�s�ݒ菈��
		/// </summary>
		/// <param name="searchRet">�ݒ茳�̓��Ӑ挟�����ʃN���X</param>
		/// <param name="row">�ݒ��̃f�[�^�s</param>
		/// <returns>�l���ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟�����ʃN���X���f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer  : 22018�@��ؐ��b</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private DataRow CustomerSearchRetToDataRow(CustomerSearchRet searchRet, DataRow row)
		{
			if (row == null)
			{
				row = this.Search_DataSet.Tables[SEARCH_TABLE].NewRow();
			}

			row[SEARCH_COL_EnterpriseCode]				= searchRet.EnterpriseCode;					// ��ƃR�[�h(�J��������)
			row[SEARCH_COL_CustomerCode]				= searchRet.CustomerCode;					// ���Ӑ�R�[�h
			row[SEARCH_COL_CustomerSubCode]				= searchRet.CustomerSubCode;				// ���Ӑ�T�u�R�[�h
			row[SEARCH_COL_Name]						= searchRet.Name + " " + searchRet.Name2;	// ����
			row[SEARCH_COL_Name2]						= searchRet.Name2;							// ���̂Q
            // 2011/7/25 XUJS ADD STA>>>>>>
            row[SEARCH_COL_Snm]                         = searchRet.Snm;                            // ����
            // 2011/7/25 XUJS ADD END<<<<<<
			row[SEARCH_COL_Kana]						= searchRet.Kana;							// �J�i
			row[SEARCH_COL_CustomerSearchRet]			= searchRet.Clone();						// ���Ӑ挟���߂�l�N���X
			row[SEARCH_COL_HtmlString]					= "";										// �ڍו\���pHTML������
			row[SEARCH_COL_SelectedFlg]					= (int)RowSelected.No;						// �I���ς݃t���O
			row[SEARCH_COL_LogicalDeleteCode]			= searchRet.LogicalDeleteCode;				// �_���폜�敪�i���Ӑ�j

			return row;
		}

		/// <summary>
		/// ���Ӑ挟�����ʃO���b�h�J�������ݒ菈��
		/// </summary>
        /// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟�����ʃO���b�h�ɕ\������J��������ݒ肵�܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private void SettingSearchGridColumn(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            UiSet uiset;
            uiSetControl1.ReadUISet( out uiset, "tNedit_CustomerCode" );
            string customerFormat = new string( '0', uiset.Column );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


			// ��U�A�S�Ă̗���\���ɐݒ肵�A�\���ʒu�𓝈ꂳ����
			foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				column.Hidden = true;
				column.CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageHAlign	= Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageVAlign	= Infragistics.Win.VAlign.Middle;
			}

			// �\������J��������ݒ肷��
			// ���� ��ݒ�
			columns[SEARCH_COL_Name].Header.Caption							= "���Ӑ於";
			columns[SEARCH_COL_Name].Hidden									= false;
			columns[SEARCH_COL_Name].Width									= 150;

            // 2011/7/25 XUJS ADD STA>>>>>>
            // ���� ��ݒ�
            columns[SEARCH_COL_Snm].Header.Caption = "���Ӑ旪��";
            columns[SEARCH_COL_Snm].Hidden = false;
            columns[SEARCH_COL_Snm].Width = 120;
            // 2011/7/25 XUJS ADD END<<<<<<

			// ���Ӑ�R�[�h ��ݒ�
            columns[SEARCH_COL_CustomerCode].Header.Caption = "���Ӑ�R�[�h";
			columns[SEARCH_COL_CustomerCode].Hidden							= false;
			columns[SEARCH_COL_CustomerCode].CellAppearance.TextHAlign		= Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            columns[SEARCH_COL_CustomerCode].Format = customerFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// ���Ӑ�T�u�R�[�h ��ݒ�
            columns[SEARCH_COL_CustomerSubCode].Header.Caption = "���Ӑ�T�u�R�[�h";
			columns[SEARCH_COL_CustomerSubCode].Hidden						= false;

			// ���Ӑ�J�i ��ݒ�
			columns[SEARCH_COL_Kana].Header.Caption							= "���Ӑ於(��)";
			columns[SEARCH_COL_Kana].Hidden									= false;

			// ��\����ԃN���X���X�gXML�t�@�C�����f�V���A���C�Y
			List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(FILENAME_COLDISPLAYSTATUS);

			// ��\����ԃR���N�V�����N���X���C���X�^���X��
			this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList);

			foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (colDisplayStatus.Key == this.GridFontSize_TComboEditor.Name)
				{
					this.GridFontSize_TComboEditor.Value = colDisplayStatus.Width;
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
		/// �O���b�h�s�\���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h�s�̕\���ݒ���s���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void SettingGridRowAppearance()
		{
			foreach(Infragistics.Win.UltraWinGrid.UltraGridRow row in this.SearchResult_UGrid.Rows)
			{
				int selectedFlg = Convert.ToInt32(row.Cells[SEARCH_COL_SelectedFlg].Text.ToString());

				switch (selectedFlg)
				{
					case (int)RowSelected.Customer:
					{
						row.Appearance.ForeColor = Color.Red;
						break;
					}
					default:
					{
						row.Appearance.ForeColor = Color.Black;
						break;
					}
				}

				int logicalDeleteCodeCustomer = Convert.ToInt32(row.Cells[SEARCH_COL_LogicalDeleteCode].Text.ToString());

				if (logicalDeleteCodeCustomer != 0)
				{
					row.Appearance.ForeColor = Color.DarkGray;
				}
				else
				{
					row.Appearance.ForeColor = Color.Black;
				}
			}
		}

		/// <summary>
		/// ���Ӑ挟�����ʔz�񁨉�ʊi�[����
		/// </summary>
		/// <param name="customerSearchRetArray">���Ӑ挟�����ʔz��</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟�����ʔz��̏�����ʂɕ\�����܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/27 ���юR</br>
        /// <br>             PM1107C:�i�荞�݃t�B���^�[�ǉ�(#9)</br>
        /// <br>------------------------------------------------------------------------------------</br> 
		/// </remarks>
		private void SetDisplayFormSearchRetArray(CustomerSearchRet[] customerSearchRetArray)
		{
			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();

			if ((customerSearchRetArray == null) || (customerSearchRetArray.Length == 0))
			{
				// �f�[�^����
				//this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = MESSAGE_NONDATA; //DEL 2011/08/11
				this.MessageUnDisp_Timer.Enabled = true;
			}
			else
			{
				// ���Ӑ挟�����ʃO���b�h�s�ݒ菈��
				foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
				{
					DataRow dataRow = null;

					// ���Ӑ挟�����ʃO���b�h�s�ݒ菈��
                    // 2011/07/27 XUJS ADD STA>>>>>>
                    if (_praCustomerCode != -1)
                    {
                        if (customerSearchRet.CustomerCode < _praCustomerCode) continue;
                    }
                    // 2011/07/27 XUJS ADD END<<<<<<
					dataRow = this.CustomerSearchRetToDataRow(customerSearchRet, dataRow);
					this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Add(dataRow);
				}

				//this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "���o�����F" + this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Count.ToString() + " ��";
                //this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "���o�����F" + _searchDataView.Count + " ��"; //DEL 2011/08/11
			}

			if (this.SearchResult_UGrid.Rows.Count == 0)
			{
				this.DetailView_Timer.Enabled = true;
			}
			else
			{
				this.SearchResult_UGrid.ActiveRow = this.SearchResult_UGrid.Rows[0];
				this.SearchResult_UGrid.ActiveRow.Selected = true;

				this.DetailView_Timer.Enabled = true;
			}
		}

		/// <summary>
		/// ���Ӑ挟������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�̌����������s���܂��B(�f���Q�[�g���񓯊����s���܂�)</br>
		/// <br>Programmer : 22018�@��ؐ��b</br>
		/// <br>Date       : 2005.05.24</br>
		/// </remarks>
		private int SearchCustomerData()
		{
			CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
			CustomerSearchPara para = new CustomerSearchPara();
			CustomerSearchRet[] retArray;
			
			// �p�����[�^�𐶐�
			para = this._extractionConditionInfo;

			// �����������s
			int status = customerSearchAcs.Serch(out retArray, para);

			// ���Ӑ挟�����ʔz�񁨉�ʊi�[����
			this.SetDisplayFormSearchRetArray(retArray);

			return status;
		}

		/// <summary>
		/// ���o�������͏��N���X�Z�b�e�B���O����
		/// </summary>
		/// <param name="conditionInfo">���o�������͏��N���X</param>
		/// <remarks>
		/// <br>Note       : �����������̓R���g���[�����璊�o�������͏��N���X��ݒ肵�܂�</br>
		/// <br>Programmer : 22018�@��ؐ��b</br>
		/// <br>Date       : 2005.05.24</br>
        /// <br>Update Note: 2011.08.19 ���C��</br>
        /// <br>             PCC���Зp���Ӑ�K�C�h�ǉ� for #23705</br>
		/// </remarks>
        private void SettingExtractionConditionClass( ref CustomerSimpleSearchCndtn conditionInfo )
		{
            if ( conditionInfo == null ) conditionInfo = new CustomerSimpleSearchCndtn();

			// ��ƃR�[�h
			conditionInfo.EnterpriseCode = this._enterpriseCode;

			// �_���폜�f�[�^���o�敪
			conditionInfo.LogicalDeleteDataPickUp = 0;

            // �Ɣ̐�敪
            switch ( _searchMode )
            {
                case SEARCHMODE_CUSTOMER_ONLY:
                    {
                        conditionInfo.AcceptWholeSale = 1;  // ���Ӑ�i�̂݁j
                    }
                    break;
                case SEARCHMODE_RECEIVER:
                    {
                        conditionInfo.AcceptWholeSale = 2;  // �[����i�̂݁j
                    }
                    break;
                case SEARCHMODE_NORMAL:
                default:
                    {
                        conditionInfo.AcceptWholeSale = -1; // �`�k�k
                    }
                    break;
            }
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
            //PCC���Зp�^�C�v
            switch (_pccuoeMode)
            {
                case PCCUOE_CMPNYST_ONLY:
                    {
                        conditionInfo.PccuoeMode = 1;  // 1:PCC���Зp
                    }
                    break;
                case PCCUOE_MASTER_ONLY:
                    {
                        conditionInfo.PccuoeMode = 2;  // 2:PCC�}�X�����p
                    }
                    break;
                default:
                    {
                        conditionInfo.PccuoeMode = 0; // �`�k�k
                    }
                    break;
            }
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<

            // 2008.08.28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ���_�R�[�h
            //conditionInfo.MngSectionCode = this.MngSectionCode;
            // 2008.08.28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
			fontStatus.Key = this.GridFontSize_TComboEditor.Name;
			fontStatus.VisiblePosition = -1;
			fontStatus.Width = (int)this.GridFontSize_TComboEditor.Value;
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
		/// �N���A����
		/// </summary>
		private void Clear()
		{
			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();
			this._extractConditionList.Clear();
            this._extractionConditionInfo = new CustomerSimpleSearchCndtn();

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// �L�[������擾����
		/// </summary>
		/// <returns>�L�[������</returns>
		private string GetKey(string enterpriseCode, int customerCode)
		{
			if (customerCode == 0)
			{
				return "";
			}
			else
			{
				return enterpriseCode + "-" + customerCode.ToString();
			}
		}

		/// <summary>
		/// �I���{�^���N���b�N����
		/// </summary>
		private void SelectButtonClick()
		{
			CustomerSearchRet customerSearchRet;
			int stauts = this.GetSelectInfo(out customerSearchRet);

			if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (this.CustomerSelect != null)
				{
					this.CustomerSelect(this, customerSearchRet);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                    this.DialogResult = DialogResult.OK;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
					this.Close();
				}
			}
		}

		/// <summary>
		/// �ŏ�ʐe�t�H�[���擾����
		/// </summary>
		/// <returns>�ŏ�ʐe�t�H�[���N���X</returns>
		private Form GetTopLevelOwnerForm()
		{
			bool exists = true;
			Form ownerForm = this.Owner;

			if (ownerForm != null)
			{
				while (exists)
				{
					if ((ownerForm.Owner != null) && (ownerForm.Owner is Form))
					{
						ownerForm = ownerForm.Owner;
					}
					else
					{
						break;
					}
				}

			}

			return ownerForm;
		}

		/// <summary>
		/// ���O�o��(DEBUG)����
		/// </summary>
		/// <param name="pMode">���[�h</param>
		/// <param name="pMsg">���b�Z�[�W</param>
		public static void LogWrt(int pMode, string pMsg)
		{
			#if DEBUG
			System.IO.FileStream _fs;										// �t�@�C���X�g���[��
			System.IO.StreamWriter _sw;										// �X�g���[��writer
			_fs = new FileStream( "PMKHN04005U.Log", FileMode.Append, FileAccess.Write, FileShare.Write );
			_sw = new System.IO.StreamWriter( _fs, System.Text.Encoding.GetEncoding( "shift_jis" ) );
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine( string.Format( "{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg ) );
			if( _sw != null )
				_sw.Close();
			if( _fs != null )
				_fs.Close();
			#endif
		}
		# endregion

		// ===================================================================================== //
		// �e�R���|�[�l���g�C�x���g����
		// ===================================================================================== //
		# region Component Event Methods
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void PMKHN04005UA_Load(object sender, System.EventArgs e)
		{
			// ��ʏ���������
			this.InitialSetting();

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// �^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

            // �������s
            if ( _autoSearch )
            {
                Search_Timer_Tick( this, new EventArgs() );
            }
		}

		/// <summary>
		/// �^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void MessageUnDisp_Timer_Tick(object sender, System.EventArgs e)
		{
			this.MessageUnDisp_Timer.Enabled = false;
			//this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = ""; //DEL 2011/08/11
		}

		/// <summary>
		/// �c�[���o�[�c�[���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
            switch ( e.Tool.Key )
            {
                case "Close_ButtonTool":
                    {
                        this.Close();
                        break;
                    }
                case "Return_ButtonTool":
                    {
                        int maxIndex = this._extractConditionList.Count - 1;
                        if ( maxIndex < 1 ) return;

                        // �ŏI�̃A�C�e�����폜����
                        CustomerSimpleSearchCndtn removeInfo = this._extractConditionList[maxIndex];
                        this._extractConditionList.Remove( removeInfo );

                        // ���݂���P�ȑO�̃A�C�e�����擾���A�Č������s���B
                        CustomerSimpleSearchCndtn targetInfo = this._extractConditionList[maxIndex - 1];

                        if ( targetInfo != null )
                        {
                            this._extractionConditionInfo = targetInfo.Clone();
                        }

                        break;
                    }
                case "Clear_ButtonTool":
                    {
                        // �N���A����
                        this.Clear();

                        break;
                    }
                case "Select_ButtonTool":
                    {
                        // �I���{�^���N���b�N����
                        this.SelectButtonClick();

                        break;
                    }
            }
        }

		/// <summary>
		/// �����{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void Search_UButton_Click(object sender, System.EventArgs e)
		{
			this.Search_Timer.Enabled = true;
		}

		/// <summary>
		/// �����^�C�}�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void Search_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Search_Timer.Enabled = false;

			this.Cursor = Cursors.WaitCursor;

			this._selectedRowIndex = -1;

			// ���Ӑ挟���p�����[�^�N���X��������
			this.SettingExtractionConditionClass(ref this._extractionConditionInfo);

			if (this._extractionConditionInfo == null) return;


			// ���Ӑ挟������
			this.SearchCustomerData();

			// �O���b�h�s�\���ݒ菈��
			this.SettingGridRowAppearance();

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			this.Cursor = Cursors.Default;
		}

		/// <summary>
		/// ��T�C�Y�ύX�^�C�}�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ColSizeChange_Timer_Tick(object sender, System.EventArgs e)
		{
			this.ColSizeChange_Timer.Enabled = false;
			this.SearchResult_UGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

			for (int i = 0; i < this.SearchResult_UGrid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				this.SearchResult_UGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
			}
			this.SearchResult_UGrid.Refresh();
		}

		/// <summary>
		/// �t�H�[���N���[�W���O�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void PMKHN04005UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// ��\����ԃN���X���X�g�\�z����
			List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

			// ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
			ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
		}

		/// <summary>
		/// ���o���ʃO���b�h�L�[�A�b�v�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SearchResult_UGrid_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.DetailView_Timer.Enabled = true;
		}

		/// <summary>
		/// ���o���ʃO���b�h�L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SearchResult_UGrid_KeyDown(object sender, KeyEventArgs e)
		{
            if ( !e.Shift )
            {
                switch ( e.KeyCode )
                {
                    case Keys.Return:
                        {
                            Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

                            if ( selectButton.SharedProps.Visible )
                            {
                                // �I���{�^���N���b�N����
                                this.SelectButtonClick();

                            }
                            break;  //ADD 2011/08/11
                        }
                    // -------------------- ADD 2011/08/11 --------------->>>>>
                    case Keys.F3:
                        {
                            this.ActiveControl = this.TEdit_Kana;
                            this.TEdit_Kana.Focus();
                            break;
                        }
                    default:
                    // -------------------- ADD 2011/08/11 ---------------<<<<<
                        break;
                }
            }
		}

		/// <summary>
		/// ���o���ʃO���b�h�}�E�X�A�b�v�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SearchResult_UGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.DetailView_Timer.Enabled = true;
		}

		/// <summary>
		/// �f�[�^�\���^�C�}�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void DetailView_Timer_Tick(object sender, System.EventArgs e)
		{
			this.DetailView_Timer.Enabled = false;

			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				Control activeControl = this.ActiveControl;
			}
			else
			{
				// �I���s�̃C���f�b�N�X���擾
				CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
				int index = cm.Position;

				if (this._selectedRowIndex == index) return;

				this._selectedRowIndex = index;

				// �w��s�̓��e���擾
				DataRow row = this._searchDataView[index].Row;
			}
		}

		/// <summary>
		/// ���o���ʃO���b�h�s�I���㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SearchResult_UGrid_AfterRowActivate(object sender, System.EventArgs e)
		{
			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();
		}

        ///// <summary>
        ///// �t�H�[�J�X�R���g���[���C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^�N���X</param>
        //private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        //{
        //    if (this._extractionConditionInfo == null) return;
        //    if (e.PrevCtrl == null || e.NextCtrl == null) return;

        //    switch ( e.PrevCtrl.Name )
        //    {
        //        // Grid
        //        case "SearchResult_UGrid":
        //            {
        //                if ( e.Key == Keys.Return )
        //                {
        //                    Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

        //                    if ( selectButton.SharedProps.Visible )
        //                    {
        //                        // �I���{�^���N���b�N����
        //                        this.SelectButtonClick();

        //                    }
        //                }
        //            }
        //            break;
        //    }
        //}

		/// <summary>
		/// �O���b�h�t�H���g�T�C�Y�R���{�G�f�B�^�l�ύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void GridFontSize_TComboEditor_ValueChanged(object sender, System.EventArgs e)
		{
			if (this.GridFontSize_TComboEditor.Value is int)
			{
				int fontSize = (int)this.GridFontSize_TComboEditor.Value;

				if (fontSize != 0)
				{
					this.SearchResult_UGrid.Font = new System.Drawing.Font("�l�r �S�V�b�N", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				}
			}
		}

		/// <summary>
		/// �������ʃO���b�h�}�E�X�G���^�[�G�������g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		private void SearchResult_UGrid_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			// ���Ӑ�����|�b�v�A�b�v�\��
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
				Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;
				string tipString = "";

				if (row.Cells[0] != null)
				{
					int totalWidth = 6;

					// ���Ӑ於��
					tipString += this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Name].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Name].Value.ToString();

                    // 2011/7/25 XUJS ADD STA>>>>>>
                    // ���Ӑ旪��
                    tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Snm].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Snm].Value.ToString();
                    // 2011/7/25 XUJS ADD END<<<<<<

					// �J�i
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Kana].Value.ToString();

					// ���Ӑ�R�[�h
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerCode].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_CustomerCode].Value.ToString();

					// ���Ӑ�T�u�R�[�h
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerSubCode].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_CustomerSubCode].Value.ToString();
				}

				Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
				ultraToolTipInfo.ToolTipTitle = "���Ӑ���";
				ultraToolTipInfo.ToolTipText = tipString;

				this.uToolTipManager_Information.Appearance.FontData.Name = "�l�r �S�V�b�N";
				this.uToolTipManager_Information.SetUltraToolTip(this.SearchResult_UGrid, ultraToolTipInfo);
				this.uToolTipManager_Information.Enabled = true;

				return;
			}
		}

		/// <summary>
		/// �������ʃO���b�h�}�E�X���[�u�G�������g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SearchResult_UGrid_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			this.uToolTipManager_Information.Enabled = false;

			Infragistics.Win.UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
				cell.Appearance.ForeColor = this.SearchResult_UGrid.DisplayLayout.Override.CellAppearance.ForeColor;
				cell.Appearance.FontData.Underline = this.SearchResult_UGrid.DisplayLayout.Override.CellAppearance.FontData.Underline;
			}
		}

		/// <summary>
		/// �O���b�h�Z���A�N�e�B�u��C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SearchResult_UGrid_AfterCellActivate(object sender, EventArgs e)
		{
			if (this.SearchResult_UGrid.ActiveCell != null)
			{
				this.SearchResult_UGrid.ActiveRow = this.SearchResult_UGrid.ActiveCell.Row;
				this.SearchResult_UGrid.ActiveRow.Selected = true;
			}
		}

		/// <summary>
		/// �O���b�h�_�u���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SearchResult_UGrid_DoubleClick(object sender, EventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			// �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
			objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

			objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// �w�b�_���̏ꍇ�͈ȉ��̏������L�����Z������
			if (objRowCellAreaUIElement == null)
			{
				return;
			}

			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool customerEditButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerEdit_ButtonTool"];

			if (selectButton.SharedProps.Visible)
			{
				// �I���{�^���N���b�N����
				this.SelectButtonClick();
			}
			else
			{
			}

		}

		/// <summary>
		/// �t�H�[���N���㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void PMKHN04005UA_Shown(object sender, EventArgs e)
		{
		}
		# endregion

        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/27 ���юR</br>
        /// <br>             PM1107C:�i�荞�݃t�B���^�[�ǉ�(#9)</br>
        /// <br>------------------------------------------------------------------------------------</br> 
        // 2011/07/27 XUJS ADD STA>>>>>>
        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //todo
            if (this._extractionConditionInfo == null) return;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if (_extractionConditionInfo == null) return;

            try
            {
                CustomerSimpleSearchCndtn extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

                switch (e.PrevCtrl.Name)
                {
                    // ���Ӑ於�́i�J�i�j ============================================ //
                    case "TEdit_Kana":
                        {
                            if (this._extractionConditionInfo.Kana != this.TEdit_Kana.DataText)
                            {
                                extractionConditionInfoBuff.Kana = this.TEdit_Kana.DataText;
                                extractionConditionInfoBuff.KanaSearchType = 1;
                            }
                            break;
                        }
                    // ���Ӑ於�� ============================================ //
                    case "TEdit_Name":
                        {
                            if (this._extractionConditionInfo.Name != this.TEdit_Name.DataText)
                            {
                                extractionConditionInfoBuff.Name = this.TEdit_Name.DataText;
                                extractionConditionInfoBuff.NameSearchType = 1;
                            }
                            break;
                        }
                    // ���Ӑ於�́i���́j ============================================ //
                    case "TEdit_Snm":
                        {
                            if (this._extractionConditionInfo.CustomerSnm != this.TEdit_Snm.DataText)
                            {
                                extractionConditionInfoBuff.CustomerSnm = this.TEdit_Snm.DataText;
                                extractionConditionInfoBuff.CustomerSnmSearchType = 1;
                            }
                            break;
                        }
                    // �J�n�R�[�h ============================================ //
                    case "TEdit_Code":
                        {
                            int tempCode = _praCustomerCode;
                            if (this.TEdit_Code.DataText.Trim() != string.Empty)
                            {
                                _praCustomerCode = Convert.ToInt32(this.TEdit_Code.DataText.Trim());
                                if (_praCustomerCode == 0)
                                {
                                    this.TEdit_Code.DataText = string.Empty;
                                    _praCustomerCode = -1;
                                }
                                else
                                    this.TEdit_Code.DataText = GetInputCode(TEdit_Code);
                            }
                            else
                            {
                                _praCustomerCode = -1;
                            }
                            if (tempCode != _praCustomerCode)
                            {
                                this.Search();
                                //e.NextCtrl = SearchResult_UGrid; //DEL 2011/08/11
                            }
                            //return;  //DEL 2011/08/11
                            break;
                        }
                    // �Ǘ����_ ============================================ //
                    case "TEdit_MngSectionNm":
                        {

                            if (this.TEdit_MngSectionNm.DataText.Trim() != string.Empty)
                            {
                                if (this._extractionConditionInfo.MngSectionName.CompareTo(this.TEdit_MngSectionNm.DataText.Trim()) != 0)
                                {
                                    SecInfoSet secInfoSet;
                                    string section = GetInputCode(TEdit_MngSectionNm);
                                    int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, section);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        extractionConditionInfoBuff.MngSectionCode = section;
                                        extractionConditionInfoBuff.MngSectionName = secInfoSet.SectionGuideNm;
                                        this.TEdit_MngSectionNm.DataText = extractionConditionInfoBuff.MngSectionName;
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        extractionConditionInfoBuff.MngSectionCode = string.Empty;
                                        extractionConditionInfoBuff.MngSectionName = string.Empty;
                                        this.TEdit_MngSectionNm.DataText = string.Empty;
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
                                    }
                                }
                            }
                            else
                            {
                                // ���̓N���A
                                extractionConditionInfoBuff.MngSectionCode = string.Empty;
                                extractionConditionInfoBuff.MngSectionName = string.Empty;
                                this.TEdit_MngSectionNm.DataText = string.Empty;
                            }

                            break;
                        }
                    //--------------------ADD 2011/08/11--------------->>>>>
                    // �������ʃO���b�h ======================================== //
                    case "SearchResult_UGrid":
                        {
                            if (e.Key == Keys.Return)
                            {
                                Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

                                if (selectButton.SharedProps.Visible)
                                {
                                    // �I���{�^���N���b�N����
                                    this.SelectButtonClick();
                                }
                            }
                            break;
                        }
                    //--------------------ADD 2011/08/11---------------<<<<<
                }

                // ���Ӑ挟���p�����[�^�N���X��������
                this.SettingExtractionConditionClass(ref extractionConditionInfoBuff);

                // ��������̓��e�Ɣ�r����
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    this.Search();
                    //e.NextCtrl = SearchResult_UGrid;  //DEL 2011/08/11
                }
            }
            catch { 
            }
            finally { 
            }
        }

        /// <summary>
        /// �����񍀖ڂ̃R�[�h�ϊ�����(��ۋl�ߑΉ�)
        /// </summary>
        /// <param name="targetEdit"></param>
        /// <returns></returns>
        private string GetInputCode(TEdit targetEdit)
        {
            // �ݒ�Ɋ�Â��[���l��
            // �i�{�����̏�����s�v�ɂ���ׂ̃R���|�[�l���g�����A���͕���������Ȃ̂Ŏ蓮�Ή�����j
            return targetEdit.DataText.TrimEnd().PadLeft(targetEdit.ExtEdit.Column, '0');
        }
        // 2011/07/27 XUJS ADD END<<<<<<

        //--------------------ADD 2011/08/11--------------->>>>>
        /// <summary>
        /// �O���b�h�ւ̃t�H�[�J�X�i���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchResult_UGrid_Enter(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in SearchResult_UGrid.Rows)
            {
                this.SearchResult_UGrid.Focus();
                this.SearchResult_UGrid.ActiveRow = row;
                this.SearchResult_UGrid.ActiveRow.Selected = true;

                break;
            }
        }

        /// <summary>
        /// �L�[�����C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN04005UA_KeyDown(object sender, KeyEventArgs e)
        {
            // ESC�L�[�����ɂ���ʕ��鏈��
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            //F6�L�[����
            if (e.KeyCode == Keys.F6)
            {
                CustomerSimpleSearchCndtn extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

                // ���Ӑ於�́i�J�i
                if (this._extractionConditionInfo.Kana != this.TEdit_Kana.DataText)
                {
                    extractionConditionInfoBuff.Kana = this.TEdit_Kana.DataText;
                    extractionConditionInfoBuff.KanaSearchType = 1;
                }

                // ���Ӑ於��
                if (this._extractionConditionInfo.Name != this.TEdit_Name.DataText)
                {
                    extractionConditionInfoBuff.Name = this.TEdit_Name.DataText;
                    extractionConditionInfoBuff.NameSearchType = 1;
                }

                // ���Ӑ於�́i���́j
                if (this._extractionConditionInfo.CustomerSnm != this.TEdit_Snm.DataText)
                {
                    extractionConditionInfoBuff.CustomerSnm = this.TEdit_Snm.DataText;
                    extractionConditionInfoBuff.CustomerSnmSearchType = 1;
                }

                // �J�n�R�[�h
                int tempCode = _praCustomerCode;
                if (this.TEdit_Code.DataText.Trim() != string.Empty)
                {
                    _praCustomerCode = Convert.ToInt32(this.TEdit_Code.DataText.Trim());
                    if (_praCustomerCode == 0)
                    {
                        this.TEdit_Code.DataText = string.Empty;
                        _praCustomerCode = -1;
                    }
                    else
                        this.TEdit_Code.DataText = GetInputCode(TEdit_Code);
                }
                else
                {
                    _praCustomerCode = -1;
                }

                // �Ǘ����_
                if (this.TEdit_MngSectionNm.DataText.Trim() != string.Empty)
                {
                    if (this._extractionConditionInfo.MngSectionName.CompareTo(this.TEdit_MngSectionNm.DataText.Trim()) != 0)
                    {
                        SecInfoSet secInfoSet;
                        string section = GetInputCode(TEdit_MngSectionNm);
                        int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, section);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            extractionConditionInfoBuff.MngSectionCode = section;
                            extractionConditionInfoBuff.MngSectionName = secInfoSet.SectionGuideNm;
                            this.TEdit_MngSectionNm.DataText = extractionConditionInfoBuff.MngSectionName;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            extractionConditionInfoBuff.MngSectionCode = string.Empty;
                            extractionConditionInfoBuff.MngSectionName = string.Empty;
                            this.TEdit_MngSectionNm.DataText = string.Empty;
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
                        }
                    }
                }
                else
                {
                    // ���̓N���A
                    extractionConditionInfoBuff.MngSectionCode = string.Empty;
                    extractionConditionInfoBuff.MngSectionName = string.Empty;
                    this.TEdit_MngSectionNm.DataText = string.Empty;
                }

                // ���Ӑ挟���p�����[�^�N���X��������
                this.SettingExtractionConditionClass(ref extractionConditionInfoBuff);

                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
                this.Search();
                this.SearchResult_UGrid.Focus();
            }
        }
        //--------------------ADD 2011/08/11---------------<<<<<
	}
}
