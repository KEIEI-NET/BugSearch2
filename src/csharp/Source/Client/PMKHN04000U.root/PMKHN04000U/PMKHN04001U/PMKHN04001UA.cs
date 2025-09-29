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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���Ӑ�I���C�x���g�n���h��
	/// </summary>
	/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
	/// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
	public delegate void CustomerSelectEventHandler(object sender, CustomerSearchRet customerSearchRet);

	/// <summary>
	/// ���Ӑ挟���t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ挟���t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2007.02.12</br>
	/// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2008.08.28 20056 ���n ���</br>
    /// <br>             ����S�̐ݒ�}�X�^�A�N�Z�X�N���X�ύX�ɔ����Ή�(���\�b�h�����̕ύX)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2008.09.04 30452 ��� �r��</br>
    /// <br>             �폜�s�̕\������ǉ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/07/10 23012 ���� �[���N</br>
    /// <br>             ���ו\�����ʂ̕ύX( ���Ӑ�J�i�̏������瓾�Ӑ�R�[�h�����ɕύX )</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/10/07 22018 ��� ���b</br>
    /// <br>             ����S�̐ݒ�ɂ�炸�A�����I�ɃK�C�h�\���ł���@�\�̒ǉ��i���Ӑ�d�q�����̔[����K�C�h�Ŏg�p�j</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 �Ė� �x��</br>
    /// <br>             MANTIS:14720 ���Ӑ於�����ǉ�</br>
    /// <br>             MANTIS:14721 ���Ӑ挟�����ʂ̕\�����ڂɎ���FAX�ƋΖ���FAX��ǉ�</br>
    /// <br>             MANTIS:14678 ���������C�����I���̏����l�ݒ���\�Ƃ���</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2010/08/06 �� ��</br>
    /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/16 ���J  �A�� 972,973,825</br>
    /// <br>             PM1107C:���Ӑ�K�C�h�̍i�������C��</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/22 ���юR   �A�� 826</br>
    /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/08/18 ���юR   �A�� 826</br>
    /// <br>             PM1107C:���Ӑ旪�̕\����C��(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	public partial class PMKHN04001UA : System.Windows.Forms.Form
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// ���Ӑ挟���t�H�[���t���[���N���X�f�t�H���g�R���X�g���N�^
		/// </summary>
		public PMKHN04001UA()
		{
			InitializeComponent();

			// �ϐ�������
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._imageList16 = IconResourceManagement.ImageList16;
			this._searchDataView = new DataView();
			this._initialDataRead = new InitialDataReadHandler(this.InitialDataRead);
			this._extractConditionItemControlDictionary = new Dictionary<string, Panel>();
			this._extractionConditionInfo = new CustomerSearchExtractionConditionInfo();
			this._extractConditionList.Add(this._extractionConditionInfo.Clone());
			this._ultraTree_DropHightLight_DrawFilter = new UltraTree_DropHightLight_DrawFilter_Class();
			this._customerSearchSetUp = new CustomerSearchSetUp();
			this._customerSearchConstructionAcs = new CustomerSearchConstructionAcs();
			this._customerFormList = new List<PMKHN09000UA>();
			this._customerFormDictionary = new Dictionary<string, PMKHN09000UA>();
			this._employeeAcs = new EmployeeAcs();
			this._controlScreenSkin = new ControlScreenSkin();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._salesTtlStAcs = new SalesTtlStAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._paraMngSectionCode = string.Empty;
            this._paraMngSectionName = string.Empty;
            this._autoSearch = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
            this._forcedAutoSearch = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

			this._ultraTree_DropHightLight_DrawFilter.Invalidate += new EventHandler(this.UltraTree_DropHightLight_DrawFilter_Invalidate);
			this._ultraTree_DropHightLight_DrawFilter.QueryStateAllowedForNode += new UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventHandler(this.UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode);
		}

		/// <summary>
		/// ���Ӑ挟���t�H�[���t���[���N���X�R���X�g���N�^
		/// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
		public PMKHN04001UA(int searchMode, int executeMode) : this()
		{
			this._searchMode = searchMode;
			this._executeMode = executeMode;
		}
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

        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		// ===================================================================================== //
		// �����Ŏg�p����萔�Q
		// ===================================================================================== //
		#region Const
		// �f�[�^�e�[�u�����`�i���Ӑ挟�����ʏ��j
		internal const string SEARCH_TABLE							= "SEARCHTABLE";
		internal const string SEARCH_COL_EnterpriseCode				= "EnterpriseCode";				// ��ƃR�[�h(�J��������)
		internal const string SEARCH_COL_CustomerCode				= "CustomerCode";				// ���Ӑ�R�[�h
		internal const string SEARCH_COL_CustomerSubCode			= "CustomerSubCode";			// ���Ӑ�T�u�R�[�h
		internal const string SEARCH_COL_Name						= "Name";						// ����
		internal const string SEARCH_COL_Name2						= "Name2";						// ���̂Q
        // 2011/7/22 XUJS ADD STA>>>>>>
        internal const string SEARCH_COL_Snm                        = "Snm";						// ����
        // 2011/7/22 XUJS ADD END<<<<<<
		internal const string SEARCH_COL_Kana						= "Kana";						// �J�i
		internal const string SEARCH_COL_SearchTelNo				= "SearchTelNo";				// �d�b�ԍ��i�����p��4���j
		internal const string SEARCH_COL_HomeTelNo					= "HomeTelNo";					// �d�b�ԍ��i����j
		internal const string SEARCH_COL_OfficeTelNo				= "OfficeTelNo";				// �d�b�ԍ��i�Ζ���j
		internal const string SEARCH_COL_PortableTelNo				= "PortableTelNo";				// �d�b�ԍ��i�g�сj
        // 2009/12/02 Add >>>
        internal const string SEARCH_COL_HomeFaxNo = "HomeFaxNo";					// FAX�ԍ��i����j
        internal const string SEARCH_COL_OfficeFaxNo = "OfficeFaxNo";				// FAX�ԍ��i�Ζ���j
        // 2009/12/02 Add <<<
		internal const string SEARCH_COL_PostNo						= "PostNo";						// �X�֔ԍ�
		internal const string SEARCH_COL_Address1					= "Address1";					// �Z���P
		internal const string SEARCH_COL_Address3					= "Address3";					// �Z���R
		internal const string SEARCH_COL_Address4					= "Address4";					// �Z���S
		internal const string SEARCH_COL_Address					= "Address";					// �Z��
		internal const string SEARCH_COL_CustomerSearchRet			= "CustomerSearchRet";			// ���Ӑ挟���߂�l�N���X
		internal const string SEARCH_COL_HtmlString					= "HtmlString";					// �ڍו\���pHTML������
		internal const string SEARCH_COL_SelectedFlg				= "SelectedFlg";				// �I���ς݃t���O
		internal const string SEARCH_COL_LogicalDeleteCode			= "LogicalDeleteCode";			// �_���폜�敪�i���Ӑ�j
        // --- ADD 2008/09/04 -------------------------------->>>>>
        internal const string SEARCH_COL_LogicalDeleteDate          = "LogicalDeleteDate";			// �_���폜�敪�i���Ӑ�j
        // --- ADD 2008/09/04 --------------------------------<<<<< 

		private const string EXTRACT_CONDITION_XML_FILE_NAME = "PMKHN04001U_ExtractCondition.XML";	// ���o�����Z�b�e�B���O�w�l�k�t�@�C���p�X
		private const string FILENAME_COLDISPLAYSTATUS = "PMKHN04001U_ColSetting.DAT";				// ��\����ԃZ�b�e�B���OXML�t�@�C����
		private const string TEMP_FOLDER_NAME = "Temp";												// Temp�t�H���_����
		private const string MESSAGE_NONDATA = "�Y������f�[�^��������܂���ł����B";			// �Y���f�[�^�������b�Z�[�W
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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 DEL
        //public const int SEARCHMODE_SUPPLIER = 1;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 DEL
        /// <summary>SEARCHMODE �[����</summary>
        public const int SEARCHMODE_RECEIVER = 2;   // �[����
        /// <summary>SEARCHMODE ���Ӑ�̂�</summary>
        public const int SEARCHMODE_CUSTOMER_ONLY = 3;
        /// <summary>EXECUTEMODE �ʏ�</summary>
        public const int EXECUTEMODE_NORMAL = 0;
        /// <summary>EXECUTEMODE �K�C�h�̂�</summary>
        public const int EXECUTEMODE_GUIDE_ONLY = 1;
        /// <summary>EXECUTEMODE �K�C�h�{�ҏW</summary>
        public const int EXECUTEMODE_GUIDE_AND_EDIT = 2;
		# endregion

		// ===================================================================================== //
		// �X�^�e�B�b�N�ȕϐ��Q
		// ===================================================================================== //
		# region Static Members
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = "";												// ��ƃR�[�h
		private ImageList _imageList16 = null;												// �C���[�W���X�g
		private CustomerSearchExtractionConditionInfo _extractionConditionInfo = null;		// ���o�������͏��N���X
		private delegate void InitialDataReadHandler();
		InitialDataReadHandler _initialDataRead = null;
		private DataView _searchDataView = null;											// ���Ӑ挟�����ʃf�[�^�r���[
		private string _initHtmlString = "";												// �����ڍו\���p�g�s�l�k������
		private ExtractConditionItems _extractConditionItems = null;						// ���o�����ݒ�R���N�V�����N���X
		private Dictionary<string, Panel> _extractConditionItemControlDictionary = null;	// ���o�������͍���Dictionary
		private DetailViewForm _detailViewForm = null;										// �ڍו\���p�_�C�A���O
		private List<CustomerSearchExtractionConditionInfo> _extractConditionList = new List<CustomerSearchExtractionConditionInfo>();	// ���o�����������X�g
		private UltraTree_DropHightLight_DrawFilter_Class _ultraTree_DropHightLight_DrawFilter = new UltraTree_DropHightLight_DrawFilter_Class(); // DropHighlight�^DropLines��`�����߂�DrawFilter�N���X
		private bool _noBeforeCheckEvent = false;											// �E���g���c���[�`�F�b�N�C�x���g�������~�t���O
		private ColDisplayStatusList _colDisplayStatusList = null;							// ��\����ԃR���N�V�����N���X
		private int _selectedRowIndex = -1;													// �I���sIndex
		private CustomerSearchConstructionAcs _customerSearchConstructionAcs;				// ���Ӑ挟���p�ݒ���A�N�Z�X�N���X
		private CustomerSearchSetUp _customerSearchSetUp;									// ���Ӑ挟���p����ݒ�
		private List<PMKHN09000UA> _customerFormList;										// ���Ӑ���̓t�H�[�����X�g
		private Dictionary<string, PMKHN09000UA> _customerFormDictionary;					// ���Ӑ���̓t�H�[���f�B�N�V���i��
		private EmployeeAcs _employeeAcs;													// �]�ƈ��A�N�Z�X�N���X
		private int _searchMode = SEARCHMODE_NORMAL;										// �������[�h
		private int _executeMode = EXECUTEMODE_NORMAL;										// �N�����[�h
		private ControlScreenSkin _controlScreenSkin;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private SecInfoSetAcs _secInfoSetAcs = null;                                        // ���_�A�N�Z�X�N���X
        private string _paraMngSectionCode;                                                 // �i���o�����j�Ǘ����_�R�[�h
        private string _paraMngSectionName;                                                 // �i���o�����j�Ǘ����_����
        private bool _autoSearch;                                                           // ���������敪�i�t�h����j
        private SalesTtlStAcs _salesTtlStAcs = null;
        private Dictionary<string, Control> _nextControlDic;
        private List<string> _nextControlList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
        private bool _forcedAutoSearch;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
		# endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
        /// <summary>
        /// �����I�����������s�iAutoSearch�̐���ɂ�炸��Ɏ������������s����j
        /// </summary>
        public bool ForcedAutoSearch
        {
            get { return _forcedAutoSearch; }
            set { _forcedAutoSearch = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

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
		// �f���Q�[�g�p���\�b�h
		// ===================================================================================== //
		# region Delegate Method
		/// <summary>
		/// ���Ӑ���ύX�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="customerInfo">���Ӑ�N���X</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ�A�N�Z�X�N���X�ŁA���Ӑ���iStatic�̈�j���ύX���ꂽ�ۂɃR�[�������C�x���g�ł��B</br>
		/// <br>Programer  : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void InfoCustomerChangeEvent(object sender, ref CustomerInfo customerInfo)
		{
		}

		/// <summary>
		/// ���Ӑ���폜�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="customerInfo">���Ӑ�N���X</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ�A�N�Z�X�N���X�ŁA���Ӑ���iStatic�̈�j��DB����_���폜���ꂽ�ۂɃR�[�������C�x���g�ł��B</br>
		/// <br>Programer  : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void InfoDeleteCustomerEvent(object sender, ref CustomerInfo customerInfo)
		{
		}
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
			this.tNedit_CustomerCode.SetInt(customerCode);
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

			if (this._executeMode == EXECUTEMODE_GUIDE_ONLY)
			{
				selectButton.SharedProps.Visible = true;
				customerNewButton.SharedProps.Visible = false;
				customerEditButton.SharedProps.Visible = false;
				customerDeleteButton.SharedProps.Visible = false;
			}
			else if (this._executeMode == EXECUTEMODE_GUIDE_AND_EDIT)
			{
				selectButton.SharedProps.Visible = true;
				customerNewButton.SharedProps.Visible = true;
				customerEditButton.SharedProps.Visible = true;
				customerDeleteButton.SharedProps.Visible = true;
			}
			else
			{
				selectButton.SharedProps.Visible = false;
				customerNewButton.SharedProps.Visible = true;
				customerEditButton.SharedProps.Visible = true;
				customerDeleteButton.SharedProps.Visible = true;
			}
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void InitialSetting()
		{
			// �X�L�����[�h
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
			CustomControlAppearance controlAppearance = this._controlScreenSkin.GetControlAppearance();

            //# region �����ݒ�
            //this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            //this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            //this.tEdit_CustomerSubCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            //this.tEdit_CustomerKana.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 21, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            //this.SearchTelNo_TEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            //# endregion

			// �C���[�W�ݒ�
			this.Search_UButton.ImageList = this._imageList16;
			this.Search_UButton.Appearance.Image = Size16_Index.SEARCH;
			this.CustomerAgentCdGuide_UButton.ImageList = this._imageList16;
			this.CustomerAgentCdGuide_UButton.Appearance.Image = Size16_Index.STAR1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.MngSectionCodeGuide_UButton.ImageList = this._imageList16;
            this.MngSectionCodeGuide_UButton.Appearance.Image = Size16_Index.STAR1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			this.Main_ExplorerBar.ImageListSmall = _imageList16;
			this.Main_ExplorerBar.Groups["ExtractCondition"].Settings.AppearancesSmall.HeaderAppearance.Image = Size16_Index.PREVIEW;
			this.Main_ExplorerBar.Groups["ExtractConditionSetting"].Settings.AppearancesSmall.HeaderAppearance.Image = Size16_Index.SETUP1;
			this.Main_ExplorerBar.UseLargeGroupHeaderImages = Infragistics.Win.DefaultableBoolean.False;

			this.SearchResultHeader_ULabel.Appearance.BackColor = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.SearchResultHeader_ULabel.Appearance.BackColor2 = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.SearchResultHeader_ULabel.Appearance.BackGradientStyle = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.SearchResultHeader_ULabel.Appearance.ForeColor = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;

			// DrawFilter���c���[�ɐݒ肷��
			this.ExtractConditionSetting_UTree.DrawFilter = this._ultraTree_DropHightLight_DrawFilter;
			this.ExtractConditionSetting_UTree.Override.SelectionType = Infragistics.Win.UltraWinTree.SelectType.ExtendedAutoDrag;

			this.ExtractConditionSetting_UTree.Appearances.Add("DropHighLightAppearance");
			this.ExtractConditionSetting_UTree.Appearances["DropHighLightAppearance"].BackColor = Color.Cyan;

			// �c�[���o�[�����ݒ菈��
			this.SetToolbar();

			// MDI�^SDI�t�H�[���ݒ菈��
			this.MdiSdiFormSetting();

			// �e�R���g���[�������ݒ�
			this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;
			this.GridFontSize_TComboEditor.Value = 10;
			
			if (controlAppearance != null)
			{
				this.Center_Splitter.BackColor = controlAppearance.BackColor;
			}

			Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginName_LabelTool"];
			if (LoginInfoAcquisition.Employee != null)
			{
				if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}

			// ���Ӑ挟�����ʃf�[�^�e�[�u���ݒ菈��
			this.SettingCustomerSearchDataTable();

			// �Œ�w�b�_�[�@�\�̗L���ɂ���
			this.SearchResult_UGrid.DisplayLayout.UseFixedHeaders = true;

			// ���Ӑ挟�����ʃO���b�h�J�������ݒ菈��
			this.SettingSearchGridColumn(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);

			// �s�T�C�Y��ݒ�
            this.SearchResult_UGrid.DisplayLayout.Override.DefaultRowHeight = 20;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            bool errorFlag = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            try
			{
				// ���o�����ݒ���w�l�k�t�@�C�����f�V���A���C�Y
				List<ExtractConditionItem> extractConditionItemList = ExtractConditionItems.Deserialize(EXTRACT_CONDITION_XML_FILE_NAME);

				// ���o�����ݒ�R���N�V�����N���X���C���X�^���X��
				this._extractConditionItems = new ExtractConditionItems(extractConditionItemList);
			}
			catch (Exception ex)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //MessageBox.Show(ex.Message + "\r\n" + "�ēx�N���������ĉ������B");
                //return;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                errorFlag = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }

			// ���o�����ݒ�c���[�\�z����
			this.ExtractConditionTreeConstruction(this._extractConditionItems.GetExtractConditionItemList());

			// ���o�������͍���Dictionary�𐶐�
			foreach (ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
			{
				string name = this.GetExtractConditionPanelName(item);
				Control targetControl = FindControl(this, name);

                if ( (targetControl != null) && (targetControl is Panel) )
                {
                    this._extractConditionItemControlDictionary.Add( name, (Panel)targetControl );
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                else
                {
                    // �P�ł��t�h�����ƍ���Ȃ����ڂ�����΃G���[�Ƃ���
                    errorFlag = true;
                    break;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
			}
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            if ( errorFlag )
            {
                // �G���[�Ȃ�΍Đ�������

                // ���o�����ݒ���w�l�k�t�@�C�����f�V���A���C�Y
                List<ExtractConditionItem> extractConditionItemList = new List<ExtractConditionItem>();

                // ���o�����ݒ�R���N�V�����N���X���C���X�^���X��
                this._extractConditionItems = new ExtractConditionItems( extractConditionItemList );

                // ���o�����ݒ�c���[�\�z����
                this.ExtractConditionTreeConstruction( this._extractConditionItems.GetExtractConditionItemList() );

                // ���o�������͍���Dictionary�𐶐�
                _extractConditionItemControlDictionary.Clear();
                foreach ( ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList() )
                {
                    string name = this.GetExtractConditionPanelName( item );
                    Control targetControl = FindControl( this, name );

                    if ( (targetControl != null) && (targetControl is Panel) )
                    {
                        this._extractConditionItemControlDictionary.Add( name, (Panel)targetControl );
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

			// ���o�������̓p�l����S�Ĕ�\���Ƃ���
			foreach (Control control in this.Condition_Panel.Controls)
			{
				if (!(control is Panel)) continue;

				control.Visible = false;
			}

			// ���o�����ݒ���͍��ڍ\�z����
			this.ExtractConditionInputItemConstruction(this._extractConditionItems.GetExtractConditionItemList());

            // �C�� 2009/07/10 >>>
			//this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerCode].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            // �C�� 2009/07/10 <<<

			this.DetailView_Panel.Visible = false;
			this.DetailView_Splitter.Visible = false;
			this.ExtractResult_Panel.Dock = DockStyle.Fill;

            // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// ����S�̐ݒ���Q��
            //SalesTtlSt salesTtlSt;
            //// 2008.08.28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ////int status = this._salesTtlStAcs.Read(out salesTtlSt, this._enterpriseCode);
            //int status = this._salesTtlStAcs.Read(out salesTtlSt, this._enterpriseCode, this._paraMngSectionCode);
            //// 2008.08.28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //if (status == 0)
            //{
            //    // �u�����_�̂ݕ\���v�̏ꍇ�̂݁A�Ǘ����_�������͂n�m�ɂ���
            //    if ( salesTtlSt.CustGuideDispDiv == 1 )
            //    {
            //        // �Ǘ����_��������
            //        this._extractionConditionInfo.MngSectionCode = _paraMngSectionCode;
            //        this._extractionConditionInfo.MngSectionName = _paraMngSectionName;
                    
            //        // �����I���`�F�b�N
            //        this.MultiSelect_UCheckEditor.Checked = true;

            //        this._paraMngSectionCode = string.Empty;
            //        this._paraMngSectionName = string.Empty;
            //    }
            //    else
            //    {
            //        // �v���p�e�B���N���A����
            //        this._paraMngSectionCode = string.Empty;
            //        this._paraMngSectionName = string.Empty;

            //        // ���������J�n���L�����Z������
            //        this._autoSearch = false;
            //    }
            //}
            // ����S�̐ݒ���Q��
            bool existFlg = false;
            ArrayList retList;
            int status = this._salesTtlStAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (SalesTtlSt salesTtlSt in retList)
                {
                    if (salesTtlSt.SectionCode.Trim() == LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
                    {
                        // �u�����_�̂ݕ\���v�̏ꍇ�̂݁A�Ǘ����_�������͂n�m�ɂ���
                        if (salesTtlSt.CustGuideDispDiv == 1)
                        {
                            // �Ǘ����_��������
                            this._extractionConditionInfo.MngSectionCode = _paraMngSectionCode;
                            this._extractionConditionInfo.MngSectionName = _paraMngSectionName;

                            // �����I���`�F�b�N
                            this.MultiSelect_UCheckEditor.Checked = true;

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
                        existFlg = true;
                        break;
                    }
                }

                if (!existFlg)
                {
                    foreach (SalesTtlSt salesTtlSt in retList)
                    {
                        if (salesTtlSt.SectionCode.Trim() == "00")
                        {
                            // �u�����_�̂ݕ\���v�̏ꍇ�̂݁A�Ǘ����_�������͂n�m�ɂ���
                            if (salesTtlSt.CustGuideDispDiv == 1)
                            {
                                // �Ǘ����_��������
                                this._extractionConditionInfo.MngSectionCode = _paraMngSectionCode;
                                this._extractionConditionInfo.MngSectionName = _paraMngSectionName;

                                // �����I���`�F�b�N
                                this.MultiSelect_UCheckEditor.Checked = true;

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
                            break;
                        }
                    }
                }
            }
            // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<

            // �����������̓R���g���[�����ݒ�
            this.SettingExtractConditionItemInfo( this._extractionConditionInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // --- ADD 2008/09/04 -------------------------------->>>>>
            this.AddGridFiltering();
            // --- ADD 2008/09/04 --------------------------------<<<<<
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

                    /* --- DEL 2008/09/04 -------------------------------->>>>>
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
                     
                    --- DEL 2008/09/04 -------------------------------->>>>> */
                    // --- ADD 2008/09/04 -------------------------------->>>>>
                    if (logicalDeleteCodeCustomer == 0)
                    {
                        customerEditButton.SharedProps.Enabled = true;
                        customerDeleteButton.SharedProps.Enabled = true;
                        selectButton.SharedProps.Enabled = true;
                        customerRevivalButton.SharedProps.Enabled = false;
                    }
                    else if (logicalDeleteCodeCustomer == 1)
                    {
                        customerEditButton.SharedProps.Enabled = true;
                        customerDeleteButton.SharedProps.Enabled = false;
                        selectButton.SharedProps.Enabled = false;
                        customerRevivalButton.SharedProps.Enabled = true;
                    }
                    else
                    {
                        customerEditButton.SharedProps.Enabled = false;
                        customerDeleteButton.SharedProps.Enabled = false;
                        selectButton.SharedProps.Enabled = false;
                        customerRevivalButton.SharedProps.Enabled = false;
                    }
                    // --- ADD 2008/09/04 --------------------------------<<<<<

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
		/// �f�[�^�폜�m�F����
		/// </summary>
		/// <returns>TRUE:�`�F�b�N���䊮�� FALSE:�L�����Z��</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�폜�m�F���������s���܂��B</br>
		/// <br>Programmer : 980079 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private bool DataDeleteDialogCheck()
		{
			bool result = true;
			string targetName = "���Ӑ�";

			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"���ݑI�𒆂�" + targetName + "���폜���܂��B" + "\r\n" +
				"��낵���ł����H",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			switch (dialogResult)
			{
				case (DialogResult.Yes):
				{
					result = true;
					break;
				}
				case (DialogResult.No):
				{
					result = false;
					break;
				}
				default:
				{
					result = false;
					break;
				}
			}

			return result;
		}
			
		/// <summary>
		/// �f�[�^�����m�F����
		/// </summary>
		/// <returns>TRUE:�`�F�b�N���䊮�� FALSE:�L�����Z��</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�����m�F���������s���܂��B</br>
		/// <br>Programmer : 980079 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private bool DataRevivalDialogCheck()
		{
			bool result = true;
			string targetName = "���Ӑ�";

			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"���ݑI�𒆂�" + targetName + "�𕜌����܂��B" + "\r\n" +
				"��낵���ł����H",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			switch (dialogResult)
			{
				case (DialogResult. Yes):
				{
					result = true;
					break;
				}
				case (DialogResult.No):
				{
					result = false;
					break;
				}
				default:
				{
					result = false;
					break;
				}
			}

			return result;
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
//					closeButton.SharedProps.Caption = "����(&C)";
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
        /// <br>Update Note: 2011/07/22 ���юR</br>
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
            DataColumn CustomerCode = new DataColumn( SEARCH_COL_CustomerCode, typeof( Int32 ), "", MappingType.Element );
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

            // 2011/7/22 XUJS ADD STA>>>>>>
            //���Ӑ旪��
            DataColumn Snm = new DataColumn(SEARCH_COL_Snm, typeof(String), "", MappingType.Element);
            Name.Caption = "���Ӑ旪��";
            // 2011/7/22 XUJS ADD END<<<<<<

			// �J�i
			DataColumn Kana = new DataColumn(SEARCH_COL_Kana, typeof(String), "", MappingType.Element);
			Kana.Caption = "���Ӑ於(��)";

			// �d�b�ԍ��i�����p��4���j
			DataColumn SearchTelNo = new DataColumn(SEARCH_COL_SearchTelNo, typeof(String), "", MappingType.Element);
			SearchTelNo.Caption = "�d�b�ԍ��i�����p��4���j";

			// �d�b�ԍ��i����j
			DataColumn HomeTelNo = new DataColumn(SEARCH_COL_HomeTelNo, typeof(String), "", MappingType.Element);
			HomeTelNo.Caption = PMKHN04001UA.GetTelNoDspName(0);

			// �d�b�ԍ��i�Ζ���j
			DataColumn OfficeTelNo = new DataColumn(SEARCH_COL_OfficeTelNo, typeof(String), "", MappingType.Element);
			OfficeTelNo.Caption = PMKHN04001UA.GetTelNoDspName(1);

			// �d�b�ԍ��i�g�сj
			DataColumn PortableTelNo = new DataColumn(SEARCH_COL_PortableTelNo, typeof(String), "", MappingType.Element);
			PortableTelNo.Caption = PMKHN04001UA.GetTelNoDspName(2);

            // 2009/12/02 Add >>>
            // FAX�ԍ��i����j
            DataColumn HomeFaxNo = new DataColumn(SEARCH_COL_HomeFaxNo, typeof(String), "", MappingType.Element);
            HomeFaxNo.Caption = PMKHN04001UA.GetTelNoDspName(3);

            // FAX�ԍ��i�Ζ���j
            DataColumn OfficeFaxNo = new DataColumn(SEARCH_COL_OfficeFaxNo, typeof(String), "", MappingType.Element);
            OfficeFaxNo.Caption = PMKHN04001UA.GetTelNoDspName(4);
            // 2009/12/02 Add <<<

			// �X�֔ԍ�
			DataColumn PostNo = new DataColumn(SEARCH_COL_PostNo, typeof(String), "", MappingType.Element);
			PostNo.Caption = "�X�֔ԍ�";

			// �Z���P
			DataColumn Address1 = new DataColumn(SEARCH_COL_Address1, typeof(String), "", MappingType.Element);
			Address1.Caption = "�Z���P";

			// �Z���R
			DataColumn Address3 = new DataColumn(SEARCH_COL_Address3, typeof(String), "", MappingType.Element);
			Address3.Caption = "�Z���R";

			// �Z���S
			DataColumn Address4 = new DataColumn(SEARCH_COL_Address4, typeof(String), "", MappingType.Element);
			Address4.Caption = "�Z���S";

			// �Z��
			DataColumn Address = new DataColumn(SEARCH_COL_Address, typeof(String), "", MappingType.Element);
			Address.Caption = "�Z��";

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

            // --- ADD 2008/09/04 -------------------------------->>>>>
            // �폜��
            DataColumn LogicalDeleteDateCustomer = new DataColumn(SEARCH_COL_LogicalDeleteDate, typeof(string), "", MappingType.Element);
            HtmlString.Caption = "�폜��";
            // --- ADD 2008/09/04 --------------------------------<<<<<

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
                                                              // 2011/7/22 XUJS ADD STA>>>>>>
                                                              Snm,                          //����
                                                              // 2011/7/22 XUJS ADD END<<<<<<
															  Kana,							// �J�i
															  HomeTelNo,					// �d�b�ԍ��i����j
															  OfficeTelNo,					// �d�b�ԍ��i�Ζ���j
															  PortableTelNo,				// �d�b�ԍ��i�g�сj
                                                              // 2009/12/02 Add >>>
															  HomeFaxNo,					// �d�b�ԍ��i����j
															  OfficeFaxNo,					// �d�b�ԍ��i�Ζ���j
                                                              // 2009/12/02 Add <<<
															  EnterpriseCode,				// ��ƃR�[�h(�J��������)
															  Name2,						// ���̂Q
															  SearchTelNo,					// �d�b�ԍ��i�����p��4���j
															  PostNo,						// �X�֔ԍ�
															  Address1,						// �Z���P
															  Address3,						// �Z���R
															  Address4,						// �Z���S
															  Address,						// �Z��
															  CustomerSearchRetCol,			// ���Ӑ挟�����ʃN���X
															  HtmlString,					// �ڍו\���pHTML������
															  SelectedFlg,					// �I���ς݃t���O
															  LogicalDeleteCodeCustomer,	// �_���폜�敪�i���Ӑ�j
            // --- ADD 2008/09/04 -------------------------------->>>>>
															  LogicalDeleteDateCustomer,	// �폜��
            // --- ADD 2008/09/04 --------------------------------<<<<< 
															});

			this._searchDataView.Table = searchTable;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._searchDataView.RowFilter = string.Format( "{0}=0", SEARCH_COL_LogicalDeleteCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			//�@�O���b�h�Ƀf�[�^�Z�b�g���o�C���h
			//this.SearchResult_UGrid.DataSource = this.Search_DataSet.Tables[SEARCH_TABLE];
            this.SearchResult_UGrid.DataSource = this._searchDataView;
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
		/// �ڍו\���pHTML������擾�����i�O���b�h�s���j
		/// </summary>
		/// <param name="row">�f�[�^�s���</param>
		/// <returns>�擾�����ڍו\���pHTML������f�[�^</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�s�̏�񂩂�ڍו\���pHTML��������擾���܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private string DataRowToHtmlString(DataRow row)
		{
			return (string)row[SEARCH_COL_HtmlString];
		}

		/// <summary>
		/// �ڍו\���p������f�[�^�s�ݒ菈��
		/// </summary>
		/// <param name="row">�f�[�^�s���</param>
		/// <remarks>
		/// <br>Note       : �ڍו\���p��������f�[�^�s�ɐݒ肵�܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private void SetHtmlStringToDataRow(DataRow row)
		{
			/*
			string enterpriseCode = (string)row[SEARCH_COL_EnterpriseCode];
			int customerCode = Convert.ToInt32(row[SEARCH_COL_CustomerCode]);

			SFCMN00017UA htmlViewDialog = new SFCMN00017UA();
			string htmlString = htmlViewDialog.GetHtmlString(enterpriseCode, customerCode, carMngNo);

			row[SEARCH_COL_HtmlString] = htmlString;
			*/
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
        /// <br>Update Note: 2011/07/22 ���юR</br>
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
            // 2011/7/22 XUJS ADD STA>>>>>>
            row[SEARCH_COL_Snm]                         = searchRet.Snm;	                        //����
            // 2011/7/22 XUJS ADD END<<<<<<
			row[SEARCH_COL_Kana]						= searchRet.Kana;							// �J�i
			row[SEARCH_COL_SearchTelNo]					= searchRet.SearchTelNo;					// �d�b�ԍ��i�����p��4���j
			row[SEARCH_COL_HomeTelNo]					= searchRet.HomeTelNo;						// �d�b�ԍ��i����j
			row[SEARCH_COL_OfficeTelNo]					= searchRet.OfficeTelNo;					// �d�b�ԍ��i�Ζ���j
			row[SEARCH_COL_PortableTelNo]				= searchRet.PortableTelNo;					// �d�b�ԍ��i�g�сj
            // 2009/12/02 Add >>>
            row[SEARCH_COL_HomeFaxNo] = searchRet.HomeFaxNo;                      // FAX�ԍ��i����j
            row[SEARCH_COL_OfficeFaxNo] = searchRet.OfficeFaxNo;                    // FAX�ԍ��i�Ζ���j
            // 2009/12/02 Add <<<
			row[SEARCH_COL_PostNo]						= searchRet.PostNo;							// �X�֔ԍ�
			row[SEARCH_COL_Address1]					= searchRet.Address1;						// �Z���P
			row[SEARCH_COL_Address3]					= searchRet.Address3;						// �Z���R
			row[SEARCH_COL_Address4]					= searchRet.Address4;						// �Z���S
			row[SEARCH_COL_Address] =
				searchRet.Address1 +
				searchRet.Address3 +
				searchRet.Address4;																	// �Z��
			row[SEARCH_COL_CustomerSearchRet]			= searchRet.Clone();						// ���Ӑ挟���߂�l�N���X
			row[SEARCH_COL_HtmlString]					= "";										// �ڍו\���pHTML������
			row[SEARCH_COL_SelectedFlg]					= (int)RowSelected.No;						// �I���ς݃t���O
			row[SEARCH_COL_LogicalDeleteCode]			= searchRet.LogicalDeleteCode;				// �_���폜�敪�i���Ӑ�j
            // --- ADD 2008/09/04 -------------------------------->>>>>
            if (searchRet.LogicalDeleteCode == 0)
            {
                row[SEARCH_COL_LogicalDeleteDate]       = "";
            }
            else
            {
                // �X�V�����폜���Ƃ���B
                row[SEARCH_COL_LogicalDeleteDate] = TDateTime.DateTimeToString("ggYY/MM/DD", searchRet.UpdateDate);
            }
            // --- ADD 2008/09/04 --------------------------------<<<<< 

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
		/// </remarks>
		private void SettingSearchGridColumn(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            UiSet uiset;
            uiSetControl1.ReadUISet( out uiset, this.tNedit_CustomerCode.Name );
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
            columns[SEARCH_COL_Name].Header.Caption = "���Ӑ於";
            columns[SEARCH_COL_Name].Hidden = false;
            columns[SEARCH_COL_Name].Width = 150;

            // 2011/7/22 XUJS ADD STA>>>>>>
            // ���Ӑ旪�� ��ݒ�
            columns[SEARCH_COL_Snm].Header.Caption = "���Ӑ旪��";
            columns[SEARCH_COL_Snm].Hidden = false;
            columns[SEARCH_COL_Snm].Width = 120;
            // 2011/7/22 XUJS ADD END<<<<<<

            // ���Ӑ�R�[�h ��ݒ�
            columns[SEARCH_COL_CustomerCode].Header.Caption = "���Ӑ�R�[�h";
            columns[SEARCH_COL_CustomerCode].Hidden = false;
            columns[SEARCH_COL_CustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            columns[SEARCH_COL_CustomerCode].Format = customerFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ���Ӑ�T�u�R�[�h ��ݒ�
            columns[SEARCH_COL_CustomerSubCode].Header.Caption = "���Ӑ�T�u�R�[�h";
            columns[SEARCH_COL_CustomerSubCode].Hidden = false;

            // ���Ӑ�J�i ��ݒ�
            columns[SEARCH_COL_Kana].Header.Caption = "���Ӑ於(��)";
            columns[SEARCH_COL_Kana].Hidden = false;

            // ����s�d�k ��ݒ�
            columns[SEARCH_COL_HomeTelNo].Header.Caption = PMKHN04001UA.GetTelNoDspName( 0 );
            columns[SEARCH_COL_HomeTelNo].Hidden = false;

            // �Ζ���s�d�k ��ݒ�
            columns[SEARCH_COL_OfficeTelNo].Header.Caption = PMKHN04001UA.GetTelNoDspName( 1 );
            columns[SEARCH_COL_OfficeTelNo].Hidden = false;

            // �g�тs�d�k ��ݒ�
            columns[SEARCH_COL_PortableTelNo].Header.Caption = PMKHN04001UA.GetTelNoDspName( 2 );
            columns[SEARCH_COL_PortableTelNo].Hidden = false;

            // 2009/12/02 Add >>>
            // ����s�d�k ��ݒ�
            columns[SEARCH_COL_HomeFaxNo].Header.Caption = PMKHN04001UA.GetTelNoDspName(3);
            columns[SEARCH_COL_HomeFaxNo].Hidden = false;

            // �Ζ���s�d�k ��ݒ�
            columns[SEARCH_COL_OfficeFaxNo].Header.Caption = PMKHN04001UA.GetTelNoDspName(4);
            columns[SEARCH_COL_OfficeFaxNo].Hidden = false;
            // 2009/12/02 Add <<<


            // �Z�� ��ݒ�
            columns[SEARCH_COL_Address].Header.Caption = "�Z��";
            columns[SEARCH_COL_Address].Hidden = false;

            // --- ADD 2008/09/04 -------------------------------->>>>>
            // �폜�� ��ݒ�
            columns[SEARCH_COL_LogicalDeleteDate].Header.Caption = "�폜��";
            columns[SEARCH_COL_LogicalDeleteDate].CellAppearance.ForeColor = Color.Red;
            if ( this.DeleteIndication_CheckEditor.Checked )
            {
                columns[SEARCH_COL_LogicalDeleteDate].Hidden = false;
            }
            else
            {
                columns[SEARCH_COL_LogicalDeleteDate].Hidden = true;
            }
            // --- ADD 2008/09/04 --------------------------------<<<<<

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

                /* --- DEL 2008/09/04 -------------------------------->>>>>
				int logicalDeleteCodeCustomer = Convert.ToInt32(row.Cells[SEARCH_COL_LogicalDeleteCode].Text.ToString());

				if (logicalDeleteCodeCustomer != 0)
				{
					row.Appearance.ForeColor = Color.DarkGray;
				}
				else
				{
					row.Appearance.ForeColor = Color.Black;
				}
                --- DEL 2008/09/04 -------------------------------->>>>> */
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
		/// </remarks>
		private void SetDisplayFormSearchRetArray(CustomerSearchRet[] customerSearchRetArray)
		{

			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();

			if ((customerSearchRetArray == null) || (customerSearchRetArray.Length == 0))
			{
				// �f�[�^����
				this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = MESSAGE_NONDATA;
				this.MessageUnDisp_Timer.Enabled = true;
			}
			else
			{
				// ���Ӑ挟�����ʃO���b�h�s�ݒ菈��
				foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
				{
					DataRow dataRow = null;

					// ���Ӑ挟�����ʃO���b�h�s�ݒ菈��
					dataRow = this.CustomerSearchRetToDataRow(customerSearchRet, dataRow);
					this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Add(dataRow);
				}

                // --- DEL 2008/09/04 -------------------------------->>>>>
                //this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "���o�����F" + this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Count.ToString() + " ��";
                // --- DEL 2008/09/04 --------------------------------<<<<<
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
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 �� ��</br>
        /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private void SettingExtractionConditionClass(ref CustomerSearchExtractionConditionInfo conditionInfo)
		{
			if (conditionInfo == null) conditionInfo = new CustomerSearchExtractionConditionInfo();

			// ��ƃR�[�h
			conditionInfo.EnterpriseCode = this._enterpriseCode;

			// ���Ӑ�R�[�h
			if (this.Condition_CustomerCode_Panel.Visible)
			{
				conditionInfo.CustomerCode = this.tNedit_CustomerCode.GetInt();
			}
			else
			{
				conditionInfo.CustomerCode = 0;
			}

			// ���Ӑ�T�u�R�[�h
			if (this.Condition_CustomerSubCode_Panel.Visible)
			{
				conditionInfo.CustomerSubCode = this.tEdit_CustomerSubCode.DataText;

				if (this.CustomerSubCodeSearchType_UCheckEditor.Checked)
				{
					conditionInfo.CustomerSubCodeSearchType = 1;
				}
				else
				{
					conditionInfo.CustomerSubCodeSearchType = 0;
				}
			}
			else
			{
				conditionInfo.CustomerSubCode = "";
				conditionInfo.CustomerSubCodeSearchType = 0;
			}

			// ���Ӑ�J�i
			if (this.Condition_Kana_Panel.Visible)
			{
				conditionInfo.Kana = this.tEdit_CustomerKana.DataText;

				if (this.KanaSearchType_UCheckEditor.Checked)
				{
					conditionInfo.KanaSearchType = 1;
				}
				else
				{
					conditionInfo.KanaSearchType = 0;
				}
			}
			else
			{
				conditionInfo.Kana = "";
				conditionInfo.KanaSearchType = 0;
			}

			// �d�b�ԍ��i�d�b�ԍ����S���j
			if (this.Condition_SearchTelNo_Panel.Visible)
			{
				conditionInfo.SearchTelNo = this.SearchTelNo_TEdit.DataText;
			}
			else
			{
				conditionInfo.SearchTelNo = "";
			}

			// �_���폜�f�[�^���o�敪
			conditionInfo.LogicalDeleteDataPickUp = 0;
			
			// ���Ӑ���
			this.SetCustomerDivStatus(ref conditionInfo);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �Ǘ����_
            //conditionInfo.MngSectionCode = this.MngSectionCode;
            //conditionInfo.MngSectionName = this.MngSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			//conditionInfo.SupplierDiv = this.GetCheckEditorValue(this.SupplierDiv_UCheckEditor, EXIST_CODE_CHECKED, EXIST_CODE_UNCHECKED);
			//conditionInfo.AcceptWholeSale = this.GetCheckEditorValue(this.AcceptWholeSale_UCheckEditor, EXIST_CODE_CHECKED, EXIST_CODE_UNCHECKED);

            // 2009/12/02 Add >>>
            // ���Ӑ於
            if (this.Condition_Name_Panel.Visible)
            {
                conditionInfo.Name = this.tEdit_CustomerName.DataText;

                if (this.NameSearchType_UCheckEditor.Checked)
                {
                    conditionInfo.NameSearchType = 1;
                }
                else
                {
                    conditionInfo.NameSearchType = 0;
                }
            }
            else
            {
                conditionInfo.Name = "";
                conditionInfo.NameSearchType = 0;
            }
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            // ���Ӑ旪��
            if (this.Condition_CustomerSnm_Panel.Visible)
            {
                conditionInfo.CustomerSnm = this.tEdit_CustomerSnm.DataText;

                if (this.SnmSearchType_UCheckEditor.Checked)
                {
                    conditionInfo.CustomerSnmSearchType = 1;
                }
                else
                {
                    conditionInfo.CustomerSnmSearchType = 0;
                }
            }
            else
            {
                conditionInfo.CustomerSnm = "";
                conditionInfo.CustomerSnmSearchType = 0;
            }
            // 2011/7/22 XUJS ADD END<<<<<<

            // ---ADD 2010/08/06-------------------->>>
            // �d�b�ԍ�
            if (this.Condition_TelNum_Panel.Visible)
            {
                conditionInfo.TelNum = this.tEdit_TelNum.DataText;

                if (this.TelNum_UCheckEditor.Checked)
                {
                    conditionInfo.TelNumSearchType = 1;
                }
                else
                {
                    conditionInfo.TelNumSearchType = 0;
                }
            }
            else
            {
                conditionInfo.TelNum = "";
                conditionInfo.TelNumSearchType = 0;
            }
            // ---ADD 2010/08/06--------------------<<<
            //ADD START ���J 2011/07/16 �A�� 972,973,825
            if (conditionInfo.MngSectionCode.Length == 1)
                conditionInfo.MngSectionCode = "0" + conditionInfo.MngSectionCode;
            //ADD END ���J 2011/07/16 �A�� 972,973,825
        }

		/// <summary>
		/// ���o�������͏��N���X�Z�b�e�B���O�L���擾����
		/// </summary>
		/// <param name="conditionInfo">���o�������͏��N���X</param>
		/// <remarks>
		/// <br>Note       : ���o�������͏��N���X�ɒl���ݒ肳��Ă��邩�ǂ������擾���܂�</br>
		/// <br>Programmer : 22018�@��ؐ��b</br>
		/// <br>Date       : 2005.05.24</br>
		/// </remarks>
		private bool IsExtractionConditionClassSetting(CustomerSearchExtractionConditionInfo conditionInfo)
		{
			/*
			if ((conditionInfo.CustomerCode != 0) ||				// ���Ӑ�R�[�h
				(conditionInfo.CustomerSubCode != "") ||			// ���Ӑ�T�u�R�[�h
				(conditionInfo.Kana != "") ||						// ���Ӑ�J�i
				(conditionInfo.SearchTelNo != "") ||				// �d�b�ԍ��i�d�b�ԍ����S���j
				(conditionInfo.SupplierDiv != 0) ||					// �d����敪
				(conditionInfo.AcceptWholeSale != 0) ||				// �Ɣ̐�敪
				(conditionInfo.CustAnalysCode1 != 0) ||				// ���̓R�[�h�P
				(conditionInfo.CustAnalysCode2 != 0) ||				// ���̓R�[�h�Q
				(conditionInfo.CustAnalysCode3 != 0) ||				// ���̓R�[�h�R
				(conditionInfo.CustAnalysCode4 != 0) ||				// ���̓R�[�h�S
				(conditionInfo.CustAnalysCode5 != 0) ||				// ���̓R�[�h�T
				(conditionInfo.CustAnalysCode6 != 0) ||				// ���̓R�[�h�U
				(conditionInfo.CustomerAgentCd != "") ||			// ���Ӑ�S��
				((conditionInfo.CustomerSubCode != "") && (conditionInfo.CustomerSubCodeSearchType != 0)) ||		// ���Ӑ�T�u�R�[�h�����^�C�v
				((conditionInfo.Kana != "") && (conditionInfo.KanaSearchType != 0))									// ���Ӑ�J�i�����^�C�v
				)
			{
				return true;
			}
			else
			{
				return false;
			}
			*/
			return true;
		}

		/// <summary>
		/// �����������̓R���g���[�����ݒ�
		/// </summary>
		/// <param name="conditionInfo">���o�������͏��N���X</param>
		/// <remarks>
		/// <br>Note       : ���o�������͏��N���X���猟���������̓R���g���[���ɒl��ݒ肵�܂��B</br>
		/// <br>Programmer : 22018�@��ؐ��b</br>
		/// <br>Date       : 2005.05.24</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 �� ��</br>
        /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private void SettingExtractConditionItemInfo(CustomerSearchExtractionConditionInfo conditionInfo)
		{
			if (conditionInfo == null) return;

			// �C�x���g������
            //this.SupplierDiv_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.Customer_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.Receiver_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.CustomerSubCodeSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged);
			this.KanaSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.KanaSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2009/12/02 Add >>>
            this.NameSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.NameSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            this.SnmSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.SnmSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2011/7/22 XUJS ADD END<<<<<<

			// ���Ӑ�R�[�h
			if (this.Condition_CustomerCode_Panel.Visible)
			{
				this.tNedit_CustomerCode.SetInt(conditionInfo.CustomerCode);
			}
			else
			{
				this.tNedit_CustomerCode.Clear();
			}

			// ���Ӑ�T�u�R�[�h
			if (this.Condition_CustomerSubCode_Panel.Visible)
			{
				this.tEdit_CustomerSubCode.DataText = conditionInfo.CustomerSubCode;

				if (conditionInfo.CustomerSubCodeSearchType == 1)
				{
					this.CustomerSubCodeSearchType_UCheckEditor.Checked = true;
				}
				else
				{
					this.CustomerSubCodeSearchType_UCheckEditor.Checked = false;
				}
			}
			else
			{
				this.tEdit_CustomerSubCode.Clear();
				this.CustomerSubCodeSearchType_UCheckEditor.Checked = false;
			}

			// ���Ӑ�J�i
			if (this.Condition_Kana_Panel.Visible)
			{
				this.tEdit_CustomerKana.DataText = conditionInfo.Kana;

				if (conditionInfo.KanaSearchType == 1)
				{
					this.KanaSearchType_UCheckEditor.Checked = true;
				}
				else
				{
					this.KanaSearchType_UCheckEditor.Checked = false;
				}
			}
			else
			{
				this.tEdit_CustomerKana.Clear();
				this.KanaSearchType_UCheckEditor.Checked = false;
			}

			// �d�b�ԍ��i�d�b�ԍ����S���j
			if (this.Condition_SearchTelNo_Panel.Visible)
			{
				this.SearchTelNo_TEdit.DataText = conditionInfo.SearchTelNo;
			}
			else
			{
				this.SearchTelNo_TEdit.Clear();
			}

			// ���Ӑ���
			this.SetCustomerDivCheckEditor(conditionInfo);

			//this.SetCheckEditorChecked(this.SupplierDiv_UCheckEditor, EXIST_CODE_CHECKED, conditionInfo.SupplierDiv);			// �d����敪
			//this.SetCheckEditorChecked(this.AcceptWholeSale_UCheckEditor, EXIST_CODE_CHECKED, conditionInfo.AcceptWholeSale);	// �Ɣ̐�敪

			// ���̓R�[�h
			this.CustAnalysCode1_TNedit.SetInt(conditionInfo.CustAnalysCode1);
			this.CustAnalysCode2_TNedit.SetInt(conditionInfo.CustAnalysCode2);
			this.CustAnalysCode3_TNedit.SetInt(conditionInfo.CustAnalysCode3);
			this.CustAnalysCode4_TNedit.SetInt(conditionInfo.CustAnalysCode4);
			this.CustAnalysCode5_TNedit.SetInt(conditionInfo.CustAnalysCode5);
			this.CustAnalysCode6_TNedit.SetInt(conditionInfo.CustAnalysCode6);

			// ���Ӑ�S��
			this.tEdit_EmployeeNm.Text = conditionInfo.CustomerAgentNm;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �Ǘ����_
            this.tEdit_MngSectionNm.Text = conditionInfo.MngSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            // ���Ӑ於
            if (this.Condition_Name_Panel.Visible)
            {
                this.tEdit_CustomerName.DataText = conditionInfo.Name;

                if (conditionInfo.NameSearchType == 1)
                {
                    this.NameSearchType_UCheckEditor.Checked = true;
                }
                else
                {
                    this.NameSearchType_UCheckEditor.Checked = false;
                }
            }
            else
            {
                this.tEdit_CustomerName.Clear();
                this.NameSearchType_UCheckEditor.Checked = false;
            }
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            // ���Ӑ旪��
            if (this.Condition_CustomerSnm_Panel.Visible)
            {
                this.tEdit_CustomerSnm.DataText = conditionInfo.CustomerSnm;

                if (conditionInfo.CustomerSnmSearchType == 1)
                {
                    this.SnmSearchType_UCheckEditor.Checked = true;
                }
                else
                {
                    this.SnmSearchType_UCheckEditor.Checked = false;
                }
            }
            else
            {
                this.tEdit_CustomerSnm.Clear();
                this.SnmSearchType_UCheckEditor.Checked = false;
            }
            // 2011/7/22 XUJS ADD END<<<<<<

            // ---ADD 2010/08/06-------------------->>>
            // �d�b�ԍ�
            if (this.Condition_TelNum_Panel.Visible)
            {
                this.tEdit_TelNum.DataText = conditionInfo.TelNum;

                if (conditionInfo.TelNumSearchType == 1)
                {
                    this.TelNum_UCheckEditor.Checked = true;
                }
                else
                {
                    this.TelNum_UCheckEditor.Checked = false;
                }
            }
            else
            {
                this.tEdit_TelNum.Clear();
                this.TelNum_UCheckEditor.Checked = false;
            }
            // ---ADD 2010/08/06--------------------<<<

			// �C�x���g���Đݒ�
            //this.SupplierDiv_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.Customer_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.Receiver_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.CustomerSubCodeSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged);
			this.KanaSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.KanaSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2009/12/02 Add >>>
            this.NameSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.NameSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            this.SnmSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.SnmSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2011/7/22 XUJS ADD END<<<<<<


            // ---ADD 2010/08/06-------------------->>>
            this.TelNum_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.TelNum_UCheckEditor_AfterCheckStateChanged);
            // ---ADD 2010/08/06--------------------<<<
		}

		/// <summary>
		/// DrawFilter�ɂ��R���g���[���̍ĕ`��ʒm�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void UltraTree_DropHightLight_DrawFilter_Invalidate(object sender, System.EventArgs e)
		{
			// DropHighLight���ύX�����ꍇ�A�R���g���[���ɍĕ`��̒ʒm���K�v�ɂȂ�܂�
			// �����ł́A�R���g���[���̍ĕ`���ʒm���܂�
			this.ExtractConditionSetting_UTree.Invalidate();
		}

		//�I������Ă���m�[�h�̐e�����I������Ă��邩���m�F���܂��B
		private bool IsAnyParentSelected(Infragistics.Win.UltraWinTree.UltraTreeNode Node) 
		{
			Infragistics.Win.UltraWinTree.UltraTreeNode parentNode;
			bool returnValue = false;

			parentNode = Node.Parent;
			while (parentNode != null)
			{
				if (parentNode.Selected)
				{
					returnValue = true;
					break;
				}
				else
				{
					parentNode = parentNode.Parent;
				}
			} 

			return returnValue;
		}

		//���̃C�x���g�ł́A����̃m�[�h�ɂ����Ăǂ̂悤�ȃh���b�v�����
		//���邩�A�w��ł��܂��B
		private void UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode(Object sender, UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventArgs e )
		{
			e.StatesAllowed = DropLinePositionEnum.AboveNode | DropLinePositionEnum.BelowNode;
		}

		/// <summary>
		/// ���o�����ݒ�c���[�\�z����
		/// </summary>
		/// <param name="extractConditionItemList">���o�����ݒ�N���X���X�g</param>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�N���X���X�g�����ɁA���o�����ݒ�c���[���\�z���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void ExtractConditionTreeConstruction(List<ExtractConditionItem> extractConditionItemList)
		{
			// ���o�����c���[�m�[�h��������
			this.ExtractConditionSetting_UTree.Nodes.Clear();

			// ���o�����N���X���X�g����c���[�m�[�h���\�z
			foreach(ExtractConditionItem item in extractConditionItemList)
			{
				Infragistics.Win.UltraWinTree.UltraTreeNode node = new Infragistics.Win.UltraWinTree.UltraTreeNode(item.Key, item.Name);

				/*
				// �ǉ����Q�^�C�g���ύX
				if (item.Key == "CarNo")
				{
					node.Text = PMKHN04001UA.GetAddInfoDspName(2);
				}
				*/

				node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;

				if (item.IsDisplay())
				{
					node.CheckedState = CheckState.Checked;
				}
				else
				{
					node.CheckedState = CheckState.Unchecked;
				}

				this.ExtractConditionSetting_UTree.Nodes.Add(node);
			}
		}

		/// <summary>
		/// ���o�����ݒ���͍��ڍ\�z����
		/// </summary>
		/// <param name="extractConditionItemList">���o�����ݒ�N���X���X�g</param>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�N���X���X�g�����ɁA���o�����ݒ���͍��ڂ��\�z���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void ExtractConditionInputItemConstruction(List<ExtractConditionItem> extractConditionItemList)
		{
			foreach (ExtractConditionItem item in extractConditionItemList)
			{
				string name = this.GetExtractConditionPanelName(item);
				if (!(this._extractConditionItemControlDictionary.ContainsKey(name))) continue;

				Panel targetPanel = this._extractConditionItemControlDictionary[name];

				targetPanel.Visible = false;
				targetPanel.Dock = DockStyle.Top;
				targetPanel.TabIndex = 0;
			}

			int tabIndex = 0;
			foreach (ExtractConditionItem item in extractConditionItemList)
			{
				if (!item.IsDisplay()) continue;

				string name = this.GetExtractConditionPanelName(item);
				if (!(this._extractConditionItemControlDictionary.ContainsKey(name))) continue;

				Panel targetPanel = this._extractConditionItemControlDictionary[name];

				targetPanel.Visible = item.DisplayFlg;
				targetPanel.BringToFront();
				targetPanel.TabIndex = tabIndex++;
			}

			this.Condition_Header_Panel.SendToBack();
			this.Condition_CustomerCode_Panel.Refresh();
		}

		/// <summary>
		/// ���o�����ݒ�N���X���X�g�\�z����
		/// </summary>
		/// <returns>���o�����ݒ�N���X���X�g</returns>
		/// <remarks>
		/// <br>Note       : ���o�����ݒ�c���[�����ɒ��o�����ݒ�N���X���X�g���\�z���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private List<ExtractConditionItem> ExtractConditionItemListConstruction()
		{
			List<ExtractConditionItem> extractConditionItemList = new List<ExtractConditionItem>();

			int no = 0;
			foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.ExtractConditionSetting_UTree.Nodes)
			{
				ExtractConditionItem item = new ExtractConditionItem();
				item.Key = node.Key.ToString();
				item.No = ++no;
				item.Name = node.Text;

				if (node.CheckedState == CheckState.Checked)
				{
					item.DisplayFlg = true;
				}
				else
				{
					item.DisplayFlg = false;
				}

				extractConditionItemList.Add(item);
			}

			return extractConditionItemList;
		}

		private string GetExtractConditionPanelName(ExtractConditionItem extractConditionItem)
		{
			return "Condition_" + extractConditionItem.Key + "_Panel";
		}

		private static Control FindControl(Control hParent, string nSearchName) 
		{
			// hParent ���̂��ׂẴR���g���[����񋓂���
			foreach (Control hControl in hParent.Controls) 
			{
				// �񋓂����R���g���[���ɃR���g���[�����܂܂�Ă���ꍇ�͍ċA�Ăяo������
				if (hControl.HasChildren) 
				{
					Control hFindControl = FindControl(hControl, nSearchName);

					// �ċA�Ăяo����ŃR���g���[�������������ꍇ�͂��̂܂ܕԂ�
					if (hFindControl != null) 
					{
						return hFindControl;
					}
				}

				// �R���g���[���������v�����ꍇ�͂��̃R���g���[���̃C���X�^���X��Ԃ�
				if (hControl.Name == nSearchName) 
				{
					return hControl;
				}
			}

			return null;
		}

		/// <summary>
		/// ���o�������͍��ڃp�l���\���ʒu�ݒ菈��
		/// </summary>
		private void ExtractConditionItemPositionSetting()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            //// ���o�������͍��ڃp�l���������v�擾����
            //int totalHeight = this.GetExtractConditionPanelTotalHeight();

            //if (totalHeight > this.Condition_Panel.Height)
            //{
            //    // �c�X�N���[���o�[���\������Ă���ꍇ
            //    this.tEdit_CustomerSubCode.Left = 15;
            //    this.SearchTelNo_TEdit.Left = 15;
            //    this.tNedit_CustomerCode.Left = 15;
            //    this.tEdit_CustomerKana.Left = 15;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //this.SupplierDiv_UCheckEditor.Left = 15;
            //    this.Customer_UCheckEditor.Left = 15;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    this.CustAnalysCode1_TNedit.Left = 15;
            //    this.tEdit_EmployeeNm.Left = 15;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    this.tEdit_MngSectionNm.Left = 15;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}
            //else
            //{
            //    // �c�X�N���[���o�[���\������Ă��Ȃ��ꍇ
            //    this.tEdit_CustomerSubCode.Left = 25;
            //    this.SearchTelNo_TEdit.Left = 25;
            //    this.tNedit_CustomerCode.Left = 25;
            //    this.tEdit_CustomerKana.Left = 25;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //this.SupplierDiv_UCheckEditor.Left = 25;
            //    this.Customer_UCheckEditor.Left = 25;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    this.CustAnalysCode1_TNedit.Left = 25;
            //    this.tEdit_EmployeeNm.Left = 25;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    this.tEdit_MngSectionNm.Left = 25;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////this.AcceptWholeSale_UCheckEditor.Left = this.SupplierDiv_UCheckEditor.Left + this.AcceptWholeSale_UCheckEditor.Width + 5;
            ////this.Customer_UCheckEditor.Left = this.AcceptWholeSale_UCheckEditor.Left + this.Customer_UCheckEditor.Width + 5;
            ////this.SupplierDiv_UCheckEditor.Left = this.Customer_UCheckEditor.Left + this.Customer_UCheckEditor.Width + 5;
            //this.Receiver_UCheckEditor.Left = this.Customer_UCheckEditor.Left + this.Customer_UCheckEditor.Width + 5;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //this.CustAnalysCode2_TNedit.Left = this.CustAnalysCode1_TNedit.Left + this.CustAnalysCode1_TNedit.Width + 3;
            //this.CustAnalysCode3_TNedit.Left = this.CustAnalysCode2_TNedit.Left + this.CustAnalysCode2_TNedit.Width + 3;
            //this.CustAnalysCode4_TNedit.Left = this.CustAnalysCode3_TNedit.Left + this.CustAnalysCode3_TNedit.Width + 3;
            //this.CustAnalysCode5_TNedit.Left = this.CustAnalysCode4_TNedit.Left + this.CustAnalysCode4_TNedit.Width + 3;
            //this.CustAnalysCode6_TNedit.Left = this.CustAnalysCode5_TNedit.Left + this.CustAnalysCode5_TNedit.Width + 3;
            //this.CustomerAgentCdGuide_UButton.Left = this.tEdit_EmployeeNm.Left + this.tEdit_EmployeeNm.Width + 2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.MngSectionCodeGuide_UButton.Left = this.tEdit_MngSectionNm.Left + this.tEdit_MngSectionNm.Width + 2;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/// <summary>
		/// ���o�������͍��ڃp�l���������v�擾����
		/// </summary>
		/// <returns>�������v�l</returns>
		private int GetExtractConditionPanelTotalHeight()
		{
			int totalHeight = this.Condition_Header_Panel.Height;

			// ���o�������͍���Dictionary�𐶐�
			foreach(ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
			{
				string name = this.GetExtractConditionPanelName(item);
				Control targetControl = FindControl(this, name);

				if ((targetControl != null) && (targetControl is Panel))
				{
					if (targetControl.Visible)
					{
						totalHeight = totalHeight + targetControl.Height;
					}
				}
			}

			return totalHeight;
		}

		/// <summary>
		/// ���o�������͍��ڃp�l�����X�g�擾����
		/// </summary>
		/// <param name="visibleCheck">�\���ݒ蔻��t���O</param>
		/// <returns>���o�������͍��ڃp�l�����X�g</returns>
		private List<Control> GetExtractConditionPanelList(bool visibleCheck)
		{
			List<Control> controlList = new List<Control>();

			// ���o�������͍���Dictionary�𐶐�
			foreach(ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
			{
				string name = this.GetExtractConditionPanelName(item);
				Control targetControl = FindControl(this, name);

				if ((targetControl != null) && (targetControl is Panel))
				{
					if (visibleCheck)
					{
						if (targetControl.Visible)
						{
							controlList.Add(targetControl);
						}
					}
					else
					{
						controlList.Add(targetControl);
					}
				}
			}

			return controlList;
		}

		/// <summary>
		/// �Ώۃp�l���R���g���[���擾�����i�e�L�X�g�G�f�B�^�j
		/// </summary>
		/// <param name="sender">�Ώۃp�l��</param>
		/// <returns>�e�L�X�g�G�f�B�^�I�u�W�F�N�g</returns>
		private Infragistics.Win.UltraWinEditors.UltraTextEditor GetTextEditorOnPanel(Panel sender)
		{
			Infragistics.Win.UltraWinEditors.UltraTextEditor target = null;

			foreach (Control control in sender.Controls)
			{
				if (control is Infragistics.Win.UltraWinEditors.UltraTextEditor)
				{
					target = (Infragistics.Win.UltraWinEditors.UltraTextEditor)control;
					break;
				}
			}

			return target;
		}

		/// <summary>
		/// ���o�����������X�g ���R�[�h�ǉ�����
		/// </summary>
        /// <param name="para">���o�������͏��N���X</param>
		private void AddExtractConditionList(CustomerSearchExtractionConditionInfo para)
		{
			int count = this._extractConditionList.Count;
			if (count == 0)
			{
				this._extractConditionList.Add(para.Clone());
				return;
			}

			// �ŏI�A�C�e���Ə�񂪈Ⴄ�ꍇ�̂݁A�V���ɒ��o�������͏��N���X��ǉ�����
			CustomerSearchExtractionConditionInfo buff = this._extractConditionList[count - 1];

			if (!(buff.Equals(para)))
			{
				this._extractConditionList.Add(para.Clone());
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
		/// �`�F�b�N�G�f�B�^�`�F�b�N���l�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�`�F�b�N�G�f�B�^</param>
		/// <param name="checkedValue">�`�F�b�N�L�莞�ݒ�l</param>
		/// <param name="unCheckedValue">�`�F�b�N�������ݒ�l</param>
		/// <returns>�ݒ�l</returns>
		private int GetCheckEditorValue(Infragistics.Win.UltraWinEditors.UltraCheckEditor sender, int checkedValue, int unCheckedValue)
		{
			if (sender.Checked)
			{
				return checkedValue;
			}
			else
			{
				return unCheckedValue;
			}
		}

		/// <summary>
		/// ���Ӑ��ʃX�e�[�^�X�ݒ菈��
		/// </summary>
		/// <param name="conditionInfo">���o�����N���X</param>
		private void SetCustomerDivCheckEditor(CustomerSearchExtractionConditionInfo conditionInfo)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 DEL
            //if ((conditionInfo.SupplierDiv == -1) && (conditionInfo.AcceptWholeSale == -1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == 0) && (conditionInfo.AcceptWholeSale == 0))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = false;
            //}
            //else if ((conditionInfo.SupplierDiv == 1) && (conditionInfo.AcceptWholeSale == 1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //    this.Customer_UCheckEditor.Checked = true;
            //    this.Receiver_UCheckEditor.Checked = false;
            //}
            //else if ((conditionInfo.SupplierDiv == -1) && (conditionInfo.AcceptWholeSale == 0))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = true;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == 0) && (conditionInfo.AcceptWholeSale == 1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = true;
            //    this.Receiver_UCheckEditor.Checked = false;
            //}
            //else if ((conditionInfo.SupplierDiv == 1) && (conditionInfo.AcceptWholeSale == -1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == -1) && (conditionInfo.AcceptWholeSale == 1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = true;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == 0) && (conditionInfo.AcceptWholeSale == -1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == 1) && (conditionInfo.AcceptWholeSale == 0))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = false;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
            if ( conditionInfo.AcceptWholeSale == 2 )
            {
                // �[����
                this.Receiver_UCheckEditor.Checked = true;
                this.Customer_UCheckEditor.Checked = false;
            }
            else if ( conditionInfo.AcceptWholeSale == 1 )
            {
                // ���Ӑ�
                this.Customer_UCheckEditor.Checked = true;
                this.Receiver_UCheckEditor.Checked = false;
            }
            else
            {
                // �S��
                this.Customer_UCheckEditor.Checked = false;
                this.Receiver_UCheckEditor.Checked = false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
		}

		/// <summary>
		/// ���Ӑ��ʃX�e�[�^�X�ݒ菈��
		/// </summary>
		/// <param name="conditionInfo">���o�����N���X</param>
		private void SetCustomerDivStatus(ref CustomerSearchExtractionConditionInfo conditionInfo)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 DEL
            //if ((!this.Receiver_UCheckEditor.Checked) && (!this.SupplierDiv_UCheckEditor.Checked) && (!this.Customer_UCheckEditor.Checked))
            //{
            //    conditionInfo.SupplierDiv = 0;
            //    conditionInfo.AcceptWholeSale = 0;
            //}
            //else if (this.Receiver_UCheckEditor.Checked)
            //{
            //    if (!this.SupplierDiv_UCheckEditor.Checked)
            //    {
            //        conditionInfo.SupplierDiv = -1;
            //    }
            //    else
            //    {
            //        conditionInfo.SupplierDiv = 0;
            //    }

            //    if (!this.Customer_UCheckEditor.Checked)
            //    {
            //        conditionInfo.AcceptWholeSale = -1;
            //    }
            //    else
            //    {
            //        conditionInfo.AcceptWholeSale = 0;
            //    }
            //}
            //else
            //{
            //    if (!this.SupplierDiv_UCheckEditor.Checked)
            //    {
            //        conditionInfo.SupplierDiv = 0;
            //    }
            //    else
            //    {
            //        conditionInfo.SupplierDiv = 1;
            //    }

            //    if (!this.Customer_UCheckEditor.Checked)
            //    {
            //        conditionInfo.AcceptWholeSale = 0;
            //    }
            //    else
            //    {
            //        conditionInfo.AcceptWholeSale = 1;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
            if ( this.Receiver_UCheckEditor.Checked )
            {
                if ( this.Customer_UCheckEditor.Checked )
                {
                    // ���Ӑ�E�[����̗������`�F�b�N
                    conditionInfo.AcceptWholeSale = -1;
                }
                else
                {
                    // �[����̂݃`�F�b�N
                    conditionInfo.AcceptWholeSale = 2;
                }
            }
            else if ( this.Customer_UCheckEditor.Checked )
            {
                // ���Ӑ�̂݃`�F�b�N
                conditionInfo.AcceptWholeSale = 1;
            }
            else
            {
                // �ǂ�������`�F�b�N
                conditionInfo.AcceptWholeSale = -1;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
		}

		/// <summary>
		/// �`�F�b�N�G�f�B�^�`�F�b�N�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�`�F�b�N�G�f�B�^</param>
		/// <param name="checkedValue">�`�F�b�N��t����Ă̒l</param>
		/// <param name="dataValue">�ݒ�l</param>
		private void SetCheckEditorChecked(Infragistics.Win.UltraWinEditors.UltraCheckEditor sender, int checkedValue, int dataValue)
		{
			if (checkedValue == dataValue)
			{
				sender.Checked = true;
			}
			else
			{
				sender.Checked = false;
			}
		}

		/// <summary>
		/// �ڍו\���t�H�[���ݒ菈��
		/// </summary>
		/// <param name="detailsFormType">�ڍ׃t�H�[���\���^�C�v</param>
		private void SetDetailsFormSetting(int detailsFormType)
		{
			if (detailsFormType == CustomerSearchConstructionAcs.FIRST_DISPLAY_DETAILS_0)
			{
				this.DetailView_Panel.Controls.Add(this._detailViewForm.webBrowser_DetailView);
				this._detailViewForm.Hide();
				this.DetailView_Panel.Visible = true;
				this.DetailView_Splitter.Visible = true;
				this.ExtractResult_Panel.Dock = DockStyle.Top;

				this.DetailView_Timer.Enabled = true;
			}
			else if (detailsFormType == CustomerSearchConstructionAcs.FIRST_DISPLAY_DETAILS_1)
			{
				this._detailViewForm.Controls.Add(this._detailViewForm.webBrowser_DetailView);
				this._detailViewForm.Show();
				this.DetailView_Panel.Visible = false;
				this.DetailView_Splitter.Visible = false;
				this.ExtractResult_Panel.Dock = DockStyle.Fill;

				this.DetailView_Timer.Enabled = true;
			}
			else if (detailsFormType == CustomerSearchConstructionAcs.FIRST_DISPLAY_DETAILS_2)
			{
				this.DetailView_Panel.Visible = false;
				this.DetailView_Splitter.Visible = false;
				this._detailViewForm.Hide();
				this.ExtractResult_Panel.Dock = DockStyle.Fill;
			}
		}

		/// <summary>
		/// �S�̍��ڕ\�����̃}�X�^�擾����
		/// </summary>
		/// <param name="alItmDspNm">�S�̍��ڕ\�����̃}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		private static int GetAlItmDspNm(out AlItmDspNm alItmDspNm)
		{
			// �\�����̐ݒ�
			AlItmDspNmAcs alItmDspNmAcs = new AlItmDspNmAcs();
			int status = alItmDspNmAcs.ReadStatic(out alItmDspNm, LoginInfoAcquisition.EnterpriseCode);

			if (alItmDspNm == null) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			return status;
		}

		/// <summary>
		/// �ǉ����\�����̎擾����
		/// </summary>
		/// <param name="no">��</param>
		/// <returns>�ǉ����\������</returns>
		internal static string GetAddInfoDspName(int no)
		{
			string addInfoDspName = "";

			AlItmDspNm alItmDspNm;
			if (PMKHN04001UA.GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				switch (no)
				{
					case 1:
					{
						addInfoDspName = alItmDspNm.AddInfo1DspName;
						break;
					}
					case 2:
					{
						addInfoDspName = alItmDspNm.AddInfo2DspName;
						break;
					}
					case 3:
					{
						addInfoDspName = alItmDspNm.AddInfo3DspName;
						break;
					}
				}
			}

			return addInfoDspName;
		}

		/// <summary>
		/// �d�b�ԍ��\�����̎擾����
		/// </summary>
		/// <param name="no">��</param>
		/// <returns>�d�b�ԍ��\������</returns>
		internal static string GetTelNoDspName(int no)
		{
			string telNoDspName = "";

			AlItmDspNm alItmDspNm;
			if (PMKHN04001UA.GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				switch (no)
				{
					case 0:
					{
						telNoDspName = alItmDspNm.HomeTelNoDspName;
						break;
					}
					case 1:
					{
						telNoDspName = alItmDspNm.OfficeTelNoDspName;
						break;
					}
					case 2:
					{
						telNoDspName = alItmDspNm.MobileTelNoDspName;
						break;
					}
					case 3:
					{
						telNoDspName = alItmDspNm.HomeFaxNoDspName;
						break;
					}
					case 4:
					{
						telNoDspName = alItmDspNm.OfficeFaxNoDspName;
						break;
					}
					case 5:
					{
						telNoDspName = alItmDspNm.OtherTelNoDspName;
						break;
					}
				}
			}

			return telNoDspName;
		}

		/// <summary>
		/// ���Ӑ挟���p�����[�^�N���X�`�F�b�N����
		/// </summary>
		/// <param name="para">���Ӑ挟���p�����[�^�N���X</param>
		/// <returns>true:�`�F�b�N�n�j false:�`�F�b�N�m�f</returns>
		private bool CheckCustomerSearchPara(CustomerSearchExtractionConditionInfo para)
		{
			if (!this.IsExtractionConditionClassSetting(para))
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"���o������ݒ肵�Ă��������B",
					0,
					MessageBoxButtons.OK);

				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// ���Ӑ�V�K���͋N������
		/// </summary>
		private void ShowCustomerNew()
		{
			PMKHN09000UA customerInputForm = new PMKHN09000UA();
			customerInputForm.FormClosing += new FormClosingEventHandler(this.CustomerInputForm_FormClosing);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
            // �f�[�^�X�V�C�x���g
            customerInputForm.AfterCustomerRecordUpdate += new PMKHN09000UA.AfterCustomerRecordUpdateEventHandler( this.CustomerInputForm_AfterCustomerRecordUpdate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

			this._customerFormList.Add(customerInputForm);
			this._customerFormDictionary.Add(customerInputForm.Key, customerInputForm);
			customerInputForm.Show();
		}

		/// <summary>
		/// ���Ӑ�ҏW�N������
		/// </summary>
		/// <param name="sender">�N�����I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		private void ShowCustomerEdit(object sender, string enterpriseCode, int customerCode)
		{
			this.Cursor = Cursors.AppStarting;
			bool exist = false;
			string key = this.GetKey(enterpriseCode, customerCode);

			foreach (PMKHN09000UA customerInputForm in this._customerFormList)
			{
				if (!customerInputForm.IsDisposed)
				{
					if (customerInputForm.GetSelectedInfoKey() == key)
					{
						customerInputForm.BringToFront();
						exist = true;
						break;
					}
				}
			}

			if (!exist)
			{
				PMKHN09000UA customerInputForm = new PMKHN09000UA(PMKHN09000UA.EXEC_MODE_EDIT, enterpriseCode, customerCode);
				customerInputForm.FormClosing += new FormClosingEventHandler(this.CustomerInputForm_FormClosing);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                // �f�[�^�X�V�C�x���g
                customerInputForm.AfterCustomerRecordUpdate += new PMKHN09000UA.AfterCustomerRecordUpdateEventHandler( this.CustomerInputForm_AfterCustomerRecordUpdate );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

				this._customerFormList.Add(customerInputForm);
				customerInputForm.Show();
				customerInputForm.BringToFront();
			}
			this.Cursor = Cursors.Default;
		}

		/// <summary>
		/// �N���A����
		/// </summary>
		private void Clear()
		{
			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();
			this._extractConditionList.Clear();
			this._extractionConditionInfo = new CustomerSearchExtractionConditionInfo();

			// �����������̓R���g���[�����ݒ�
			this.SettingExtractConditionItemInfo(this._extractionConditionInfo);

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// ���Ӑ���̓t�H�[���I���C�x���g����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void CustomerInputForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!(sender is PMKHN09000UA)) return;

			if (this._customerFormDictionary.ContainsKey(((PMKHN09000UA)sender).Key))
			{
				try
				{
					this._customerFormList.Remove(this._customerFormDictionary[((PMKHN09000UA)sender).Key]);
					this._customerFormDictionary.Remove(((PMKHN09000UA)sender).Key);
				}
				catch { }
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        /// <summary>
        /// ���Ӑ���̓t�H�[���f�[�^�X�V�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        private void CustomerInputForm_AfterCustomerRecordUpdate( object sender, CustomerSearchRet customerSearchRet )
        {
            if ( !(sender is PMKHN09000UA) ) return;

            // TODO:���̓t�H�[���Ńf�[�^�X�V���ꂽ��f�[�^�r���[���X�V����B
            DataRow targetRow = null;
            foreach ( DataRow row in this.Search_DataSet.Tables[SEARCH_TABLE].Rows )
            {
                if ( (Int32)row[SEARCH_COL_CustomerCode] == customerSearchRet.CustomerCode )
                {
                    targetRow = row;
                    break;
                }
            }
            // �Ώۍs�̍X�V
            if ( targetRow != null )
            {
                if ( customerSearchRet.LogicalDeleteCode != 3 )
                {
                    // �X�Vor�_���폜
                    CustomerSearchRetToDataRow( customerSearchRet, targetRow );
                }
                else
                {
                    // ���S�폜
                    this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Remove( targetRow );
                }
            }
            else
            {
                // �ǉ�
                targetRow = CustomerSearchRetToDataRow( customerSearchRet, null );
                this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Add( targetRow );
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

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

        // --- ADD 2009/09/02 -------------------------------->>>>>
        /// <summary>
        /// �O���b�h�̃t�B���^�����O����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �_���폜�t���O�ɂ��O���b�h��̃t�B���^�����O���s���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        private void AddGridFiltering()
        {

            int index = -1;

            // �폜�����index���擾
            for (int i = 0; i < this.Search_DataSet.Tables[SEARCH_TABLE].Columns.Count; i++)
            {
                if (Search_DataSet.Tables[SEARCH_TABLE].Columns[i].ColumnName == SEARCH_COL_LogicalDeleteDate)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                // �s�t�B���^���o���h�Ɋ�Â��Ă���ꍇ�A�o���h�̗�t�B���^���O���B
                Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.SearchResult_UGrid.DisplayLayout.Bands[0].ColumnFilters;
                columnFilters.ClearAllFilters();

                this._searchDataView.RowFilter = string.Empty;

                if (DeleteIndication_CheckEditor.Checked == false)
                {
                    // �󔒂�Null�ȊO���t�B���^�ɐݒ肷��
                    columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
                    columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
                    columnFilters[index].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;

                    this._searchDataView.RowFilter = string.Format( "{0}=0", SEARCH_COL_LogicalDeleteCode );
                }
            }
        }
        // --- ADD 2009/09/02 --------------------------------<<<<<

		/// <summary>
		/// �]�ƈ���������(SFTOK09382A.DLL)
		/// </summary>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="employeeName">�]�ƈ�����</param>
		/// <returns>STATUS [0:�擾���� 0�ȊO:�擾���s]</returns>
		public int GetEmployeeFromEmployeeCode(string employeeCode, out string employeeName)
		{
			employeeName = "";
			Employee employee = new Employee();

			int status = this._employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				employeeName = employee.Name;
			}

			return status;
		}

		/// <summary>
		/// �]�ƈ��K�C�h�\������(SFTOK09382A.DLL)
		/// </summary>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="employeeName">�]�ƈ�����</param>
		/// <returns>STATUS [0:�I�� 0�ȊO:���I��]</returns>
		public int ShowEmployeeGuide(out string employeeCode, out string employeeName)
		{
			Employee employee = new Employee();
			employeeCode = "";
			employeeName = "";

			int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				employeeCode = employee.EmployeeCode;
				employeeName = employee.Name;
			}

			return status;
		}

		/// <summary>
		/// ���Ӑ�ҏW�{�^���N���b�N����
		/// </summary>
		private void CustomerEditButtonClick()
		{
			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"���Ӑ悪�I������Ă��܂���B",
					0,
					MessageBoxButtons.OK);
				return;
			}

			// �I���s�̃C���f�b�N�X���擾
			CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
			int index = cm.Position;

			// �w��s�̓��e���擾
			DataRow row = this._searchDataView[index].Row;

			// ���Ӑ挟�����ʃN���X�擾�����i�O���b�h�s���j
			CustomerSearchRet customerSearchRet = this.DataRowToCustomerSearchRet(row);

			// ���Ӑ�ҏW�N������
			this.ShowCustomerEdit(this, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);
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
			_fs = new FileStream( "PMKHN04001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write );
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
		private void PMKHN04001UA_Load(object sender, System.EventArgs e)
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
        /// <br>Update Note: 2010/08/06 �� ��</br>
        /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/08/18 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����C��(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			// �����t�H�[�J�X�ݒ�
			List<Control> controls = this.GetExtractConditionPanelList(true);
			
			if (controls.Count > 0)
			{
				Infragistics.Win.UltraWinEditors.UltraTextEditor textEditor = this.GetTextEditorOnPanel((Panel)controls[0]);

				if (textEditor != null)
				{
					this.Search_UButton.Focus();
					this.ActiveControl = textEditor;
					textEditor.Focus();
				}
			}

			this.CustomerSubCodeSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged);
            this.KanaSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.KanaSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2009/12/02 Add >>>
            this.NameSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.NameSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            this.SnmSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.SnmSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2011/7/22 XUJS ADD END<<<<<<

			// �B�������`�F�b�N�{�b�N�X�����l�ݒ�
			if (this._customerSearchConstructionAcs.StringSearchInitialType == CustomerSearchConstructionAcs.STRING_SEARCH_INITIAL_TYPE_0)
			{
				this.CustomerSubCodeSearchType_UCheckEditor.Checked = false;
				this.KanaSearchType_UCheckEditor.Checked = false;

                // 2009/12/02 Add >>>
                this.NameSearchType_UCheckEditor.Checked = false;
                // 2009/12/02 Add <<<

                // 2011/7/22 XUJS ADD STA>>>>>>
                this.SnmSearchType_UCheckEditor.Checked = false;
                // 2011/7/22 XUJS ADD END<<<<<<

                // ---ADD 2010/08/06-------------------->>>
                this.TelNum_UCheckEditor.Checked = false;
                // ---ADD 2010/08/06--------------------<<<
            }
			else
			{
				this.CustomerSubCodeSearchType_UCheckEditor.Checked = true;
				this.KanaSearchType_UCheckEditor.Checked = true;

                // 2009/12/02 Add >>>
                this.NameSearchType_UCheckEditor.Checked = true;
                // 2009/12/02 Add <<<

                // 2011/7/22 XUJS ADD STA>>>>>>
                this.SnmSearchType_UCheckEditor.Checked = true;
                // 2011/7/22 XUJS ADD END<<<<<<

                // ---ADD 2010/08/06-------------------->>>
                this.TelNum_UCheckEditor.Checked = true;
                // ---ADD 2010/08/06--------------------<<<


				this._extractionConditionInfo.CustomerSubCodeSearchType = 1;
				this._extractionConditionInfo.KanaSearchType = 1;

                // 2009/12/02 Add >>>
                this._extractionConditionInfo.NameSearchType = 1;
                // 2009/12/02 Add <<<

                // ---ADD 2010/08/06-------------------->>>
                this._extractionConditionInfo.TelNumSearchType = 1;
                // ---ADD 2010/08/06--------------------<<<
			}

			this.CustomerSubCodeSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged);
			this.KanaSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.KanaSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2009/12/02 Add >>>
            this.NameSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.NameSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2011/7/22 XUJS ADD STA>>>>>>
            this.SnmSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.SnmSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2011/7/22 XUJS ADD END<<<<<<


            // ���������`�F�b�N�{�b�N�X�����l�ݒ�
            if (this._customerSearchConstructionAcs.AutoSearch == CustomerSearchConstructionAcs.AUTO_SEARCH_0)
            {
                this.AutoSearch_UCheckEditor.Checked = true;
            }
            else
            {
                this.AutoSearch_UCheckEditor.Checked = false;
            }

            // �����I���`�F�b�N�{�b�N�X�����l
            if (this._customerSearchConstructionAcs.MultiSelect == CustomerSearchConstructionAcs.MULTI_SEARCH_0)
            {
                this.MultiSelect_UCheckEditor.Checked = true;
            }
            else
            {
                this.MultiSelect_UCheckEditor.Checked = false;
            }
            // 2009/12/02 Add <<<


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 DEL
            //if ( this._searchMode == SEARCHMODE_SUPPLIER )
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //}
            //else if ( this._searchMode == SEARCHMODE_RECEIVER )
            //{
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ( this._searchMode == SEARCHMODE_CUSTOMER_ONLY )
            //{
            //    this.Customer_UCheckEditor.Checked = true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
            if ( this._searchMode == SEARCHMODE_RECEIVER )
            {
                this.Receiver_UCheckEditor.Checked = true;
            }
            else if ( this._searchMode == SEARCHMODE_CUSTOMER_ONLY )
            {
                this.Customer_UCheckEditor.Checked = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            _nextControlDic = new Dictionary<string, Control>();
            _nextControlDic.Add( Condition_CustAnalysCode_Panel.Name, this.CustAnalysCode1_TNedit );
            _nextControlDic.Add( Condition_CustomerAgentCd_Panel.Name, this.tEdit_EmployeeNm );
            _nextControlDic.Add( Condition_CustomerCode_Panel.Name, this.tNedit_CustomerCode );
            _nextControlDic.Add( Condition_CustomerKind_Panel.Name, this.Customer_UCheckEditor );
            _nextControlDic.Add( Condition_CustomerSubCode_Panel.Name, this.tEdit_CustomerSubCode );
            _nextControlDic.Add( Condition_Kana_Panel.Name, this.tEdit_CustomerKana );
            _nextControlDic.Add( Condition_MngSectionCode_Panel.Name, this.tEdit_MngSectionNm );
            _nextControlDic.Add( Condition_SearchTelNo_Panel.Name, this.SearchTelNo_TEdit );

            // 2009/12/02 Add >>>
            _nextControlDic.Add(Condition_Name_Panel.Name, this.tEdit_CustomerName);
            // 2009/12/02 Add <<<

            // ---ADD 2010/08/06------------------>>>
            _nextControlDic.Add(Condition_TelNum_Panel.Name, this.tEdit_TelNum);
            // ---ADD 2010/08/06------------------<<<

            // 2011/08/18 XUJS ADD STA------>>>>>>
            _nextControlDic.Add(Condition_CustomerSnm_Panel.Name, this.tEdit_CustomerSnm);
            // 2011/08/18 XUJS ADD END------<<<<<<

            _nextControlList = new List<string>();
            List<ExtractConditionItem> extractconditioItemList = this._extractConditionItems.GetExtractConditionItemList();
            for ( int index = 0; index < extractconditioItemList.Count; index++ )
            {
                if ( extractconditioItemList[index].IsDisplay() )
                {
                    _nextControlList.Add( "Condition_" + extractconditioItemList[index].Key.TrimEnd() + "_Panel" );
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �������s
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
            //if ( _autoSearch )
            if ( _autoSearch || _forcedAutoSearch )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD
            {
                //Search_Timer_Tick( this, new EventArgs() );
                SearchProc();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/// <summary>
		/// �^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void MessageUnDisp_Timer_Tick(object sender, System.EventArgs e)
		{
			this.MessageUnDisp_Timer.Enabled = false;
			this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "";
		}

		/// <summary>
		/// �c�[���o�[�c�[���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Close_ButtonTool":
				{
					this.Close();
					break;
				}
				case "Setup_ButtonTool":
				{
					this._customerSearchSetUp.ShowDialog();
					break;
				}
				case "Return_ButtonTool":
				{
					int maxIndex = this._extractConditionList.Count - 1;
					if (maxIndex < 1) return;

					// �ŏI�̃A�C�e�����폜����
					CustomerSearchExtractionConditionInfo removeInfo = this._extractConditionList[maxIndex];
					this._extractConditionList.Remove(removeInfo);

					// ���݂���P�ȑO�̃A�C�e�����擾���A�Č������s���B
					CustomerSearchExtractionConditionInfo targetInfo = this._extractConditionList[maxIndex - 1];

					if (targetInfo != null)
					{
						this._extractionConditionInfo = targetInfo.Clone();

						// �����������̓R���g���[�����ݒ�
						this.SettingExtractConditionItemInfo(this._extractionConditionInfo);

						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
					}

					break;
				}
				case "CustomerNew_ButtonTool":
				{
					// ���Ӑ�V�K���͋N������ 
					this.ShowCustomerNew();

					break;
				}
				case "Clear_ButtonTool":
				{
					// �N���A����
					this.Clear();

					break;
				}
				case "CustomerRevival_ButtonTool":
				{
					if (this.SearchResult_UGrid.ActiveRow == null)
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"���Ӑ悪�I������Ă��܂���B",
							0,
							MessageBoxButtons.OK);
						return;
					}

					// �I���s�̃C���f�b�N�X���擾
					CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
					int index = cm.Position;	

					// �w��s�̓��e���擾
					DataRow row = this._searchDataView[index].Row;

					// ���Ӑ挟�����ʃN���X�擾�����i�O���b�h�s���j
					CustomerSearchRet customerSearchRet = this.DataRowToCustomerSearchRet(row);

					// �f�[�^�����m�F����
					if (!this.DataRevivalDialogCheck()) return;

					// ���Ӑ敜������
					CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
					int status = customerInfoAcs.RevivalDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);

					if (status == 0)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"���Ӑ�̕����Ɏ��s���܂����B",
							status,
							MessageBoxButtons.OK);
					}

					break;
				}
				case "CustomerEdit_ButtonTool":
				{
					// ���Ӑ�ҏW�{�^���N���b�N����
					this.CustomerEditButtonClick();

					break;
				}
				case "CustomerDelete_ButtonTool":
				{
					if (this.SearchResult_UGrid.ActiveRow == null)
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"���Ӑ悪�I������Ă��܂���B",
							0,
							MessageBoxButtons.OK);
						return;
					}

					// �I���s�̃C���f�b�N�X���擾
					CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
					int index = cm.Position;	

					// �w��s�̓��e���擾
					DataRow row = this._searchDataView[index].Row;

					// ���Ӑ挟�����ʃN���X�擾�����i�O���b�h�s���j
					CustomerSearchRet customerSearchRet = this.DataRowToCustomerSearchRet(row);

					// �f�[�^�폜�m�F����
					if (!this.DataDeleteDialogCheck()) return;

					// ���Ӑ�폜�`�F�b�N����
					CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
					string message = "";
					bool checkFlg = false;
					int status = customerInfoAcs.DeleteCheck(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, out message, out checkFlg);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						if (!checkFlg)
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"���Ӑ���폜���邱�Ƃ��o���܂���B" + "\r\n" + "\r\n" + 
								message,
								status,
								MessageBoxButtons.OK);

							return;
						}
					}
					else
					{
						return;
					}

					status = customerInfoAcs.LogicalDeleteDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true);

					if (status == 0)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"���Ӑ�̍폜�Ɏ��s���܂����B",
							status,
							MessageBoxButtons.OK);
					}

					break;
				}
				case "Select_ButtonTool":
				{
					// �I���{�^���N���b�N����
					this.SelectButtonClick();

					break;
				}
				case "Search_ButtonTool":
				{
					// �I���{�^���N���b�N����
					this.Search_UButton_Click(this.Search_UButton, EventArgs.Empty);

					break;
				}
				// �f�o�b�O�p
				#if DEBUG 
				case "LoginTitle_LabelTool":
				{
					break;
				}
				# endif
			}
		}

		/// <summary>
		/// �����{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void Search_UButton_Click(object sender, System.EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.Search_Timer.Enabled = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            //*********************************************************************:
            // TimerTick���g�p���Ȃ��悤�ɕύX
            // 
            // TimerTick���g�p����ƕʃX���b�h������̂ŁA
            // �����������́��V�K�{�^�������̂悤�ȃI�y���[�V�������ƁA
            // �ꍇ�ɂ���Ă�
            // �V�K�t�H�[���\����������ʂɃt�H�[�J�X���߂�A
            // �Ƃ������ۂ��������A�D�܂����Ȃ��B
            //*********************************************************************:
            
            // �������s
            SearchProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        ///// <summary>
        ///// �����^�C�}�[�C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^�N���X</param>
        //private void Search_Timer_Tick(object sender, System.EventArgs e)
        //{
        //    this.Search_Timer.Enabled = false;
        //    SearchProc();
        //}
        /// <summary>
        /// �������C������
        /// </summary>
        private void SearchProc()
        {
            // ADD 2009/07/10 >>>
            SearchResult_UGrid.DisplayLayout.Bands[0].SortedColumns.Clear();
            SearchResult_UGrid.DisplayLayout.Bands[0].SortedColumns.Add(SEARCH_COL_CustomerCode, false);
            // ADD 2009/07/10 <<<

			this.Cursor = Cursors.WaitCursor;

			this._selectedRowIndex = -1;

			// ���Ӑ挟���p�����[�^�N���X��������

			this.SettingExtractionConditionClass(ref this._extractionConditionInfo);

			if (this._extractionConditionInfo == null) return;

			//if (!this.CheckCustomerSearchPara(this._extractionConditionInfo)) return;

			// ���o�����������X�g ���R�[�h�ǉ�����
			this.AddExtractConditionList(this._extractionConditionInfo);

			// ���Ӑ挟������
			this.SearchCustomerData();

			// �O���b�h�s�\���ݒ菈��
			this.SettingGridRowAppearance();

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			//this.ColSizeChange_Timer.Enabled = true;
			// ���o��t�H�[�J�X�ݒ�
			if (!this.MultiSelect_UCheckEditor.Checked)
			{
				if (this.SearchResult_UGrid.Rows.Count > 0)
				{
					string firstColumnKey = "";

					foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns)
					{
						if (column.Header.VisiblePosition == 0)
						{
							firstColumnKey = column.Key;
                            break;
						}
					}

					try
					{
						this.SearchResult_UGrid.Focus();
						this.SearchResult_UGrid.ActiveCell = this.SearchResult_UGrid.Rows[0].Cells[firstColumnKey];
						this.SearchResult_UGrid.ActiveCell.Selected = true;
						this.SearchResult_UGrid.ActiveRow = this.SearchResult_UGrid.Rows[0];
						this.SearchResult_UGrid.ActiveRow.Selected = true;
					}
					catch { }
				}
			}
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
		/// ���o�����ݒ�c���[�h���b�O�X�^�[�g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ExtractConditionSetting_UTree_SelectionDragStart(object sender, System.EventArgs e)
		{
			// �h���b�O�h���b�v����J�n�C�x���g
			this.ExtractConditionSetting_UTree.DoDragDrop(this.ExtractConditionSetting_UTree.SelectedNodes, DragDropEffects.Move); 
		}

		/// <summary>
		/// ���o�����ݒ�c���[�h���b�O�h���b�v�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ExtractConditionSetting_UTree_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			// �͋[�m�[�h�ϐ���錾���܂�
			Infragistics.Win.UltraWinTree.UltraTreeNode aNode;
			
			// �h���b�O�����m�[�hSelectedNodes��ۑ����邽�߂̕ϐ�
			Infragistics.Win.UltraWinTree.SelectedNodesCollection selectedNodes;
			
			// �h���b�v��̃m�[�h��ۑ�����ϐ�
			Infragistics.Win.UltraWinTree.UltraTreeNode dropNode;
			
			// ���[�v�Ɏg�p���鐮��
			int i;

			// DropNode��ݒ肵�܂��B�i�h���b�v����m�[�h�j
			dropNode = this._ultraTree_DropHightLight_DrawFilter.DropHightLightNode;

			// �f�[�^���擾���AselectedNodes�R���N�V�����ɕۑ����܂�
			// �����̓h���b�O�h���b�v�����m�[�h�ł�
			selectedNodes = (Infragistics.Win.UltraWinTree.SelectedNodesCollection)e.Data.GetData(typeof(Infragistics.Win.UltraWinTree.SelectedNodesCollection));
			selectedNodes = (Infragistics.Win.UltraWinTree.SelectedNodesCollection)selectedNodes.Clone();

			// �I�����ꂽ�m�[�h��\���ʒu���Ƀ\�[�g���܂��B
			// ���Ȃ킿�A�ړ�����������ŕ\�������悤�ɂ��邽�߂ł�
			selectedNodes.SortByPosition();

			// �h���b�v���Ă���ʒu��DrawFilter��DropLinePosition����m�F���܂�
			switch (this._ultraTree_DropHightLight_DrawFilter.DropLinePosition)
			{
				// �m�[�h�Ƀh���b�v�����ꍇ
				case DropLinePositionEnum.OnNode: 
				{
					// �������Ȃ�
					break;
				}
				// �m�[�h�̉��Ƀh���b�v�����ꍇ
				case DropLinePositionEnum.BelowNode: 
				{					
					for (i = 0; i <= (selectedNodes.Count - 1); i++)
					{
						aNode = selectedNodes[i];						
						aNode.Reposition(dropNode,Infragistics.Win.UltraWinTree.NodePosition.Next);

						// dropNode���ʒu�ύX���ꂽ�m�[�h�ɐݒ肵�܂�
						// �������邱�Ƃɂ��A���ɒǉ������m�[�h�͎����I�ɂ��̉��ɒǉ�����܂�
						dropNode = aNode;
					}	
					break;
				}
				case DropLinePositionEnum.AboveNode: // �V�K�C���f�b�N�X��Drop�Ɠ����łȂ���΂����܂���
				{
					for (i = 0; i <= (selectedNodes.Count - 1); i++)
					{
						aNode = selectedNodes[i];						
						aNode.Reposition(dropNode,Infragistics.Win.UltraWinTree.NodePosition.Previous);
					}

					break;
				}
			}

			// �h���b�v���삪����������A���݂̃h���b�v�n�C���C�g����������
			this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();

			// ���o�����ݒ�N���X���X�g�\�z����
			List<ExtractConditionItem> extractConditionItemList = this.ExtractConditionItemListConstruction();
			this._extractConditionItems.SetExtractConditionItemList(extractConditionItemList);

			// ���o�����ݒ���͍��ڍ\�z����
			this.ExtractConditionInputItemConstruction(this._extractConditionItems.GetExtractConditionItemList());
		}

		/// <summary>
		/// ���o�����ݒ�c���[�h���b�O���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ExtractConditionSetting_UTree_DragLeave(object sender, System.EventArgs e)
		{
			//�}�E�X���R���g���[���̊O�Ƀh���b�O���ꂽ�ꍇ�ADropHighLight����������
			this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();
		}

		/// <summary>
		/// ���o�����ݒ�c���[�h���b�O�I�[�o�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ExtractConditionSetting_UTree_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			// �͋[�m�[�h�ϐ���錾���܂�
			Infragistics.Win.UltraWinTree.UltraTreeNode aNode;
			
			// �}�E�X�J�[�\��������c���[���W
			// ���̃C�x���g�ł́A�t�H�[����X��Y���W�������n���܂�
			System.Drawing.Point pointInTree;

			// �c���[�ɂ�����}�E�X�̈ʒu���擾���܂�
			pointInTree = this.ExtractConditionSetting_UTree.PointToClient(new Point(e.X, e.Y));

			// �}�E�X�|�C���^�̂���m�[�h���擾���܂�
			aNode = this.ExtractConditionSetting_UTree.GetNodeFromPoint(pointInTree);

			// �}�E�X�|�C���^���m�[�h��ɂ��邱�Ƃ��m�F
			if (aNode == null)
			{
				// �}�E�X���m�[�h��ɂȂ��̂ŁA�����ł̓h���b�v����͋����Ȃ�
				e.Effect = DragDropEffects.None;

				// DropHighlight�̏���
				this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();

				// �C�x���g���I��
				return;
			}

			// ���ɑI������Ă���m�[�h�̃`���C���h�m�[�h�Ƀh���b�v���Ă��邩���m�F����
			//�i����̃m�[�h�Ƀh���b�v���邱�Ƃ𖢑R�ɖh�~���邽��
			if (IsAnyParentSelected(aNode))
			{
				// �e�m�[�h�����ɑI������Ă���m�[�h��Ƀ}�E�X������ꍇ
				// �h���b�v����𖳌��ɐݒ�
				e.Effect = DragDropEffects.None;

				// DropHighlight���������܂��B
				this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();
				
				// �C�x���g���I���B
				return;
			}
			
			// ���̒i�K�܂ŗ����̂ŁA�h���b�v������s���܂�
			this._ultraTree_DropHightLight_DrawFilter.SetDropHighlightNode(aNode, pointInTree);

			// �h���b�v�����L���ɐݒ�
			e.Effect = DragDropEffects.Move;
		}

		/// <summary>
		/// ���o�����ݒ�c���[�h���b�O�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ExtractConditionSetting_UTree_QueryContinueDrag(object sender, System.Windows.Forms.QueryContinueDragEventArgs e)
		{
			//���[�U�[��ESC�������������m�F
			if (e.EscapePressed)
			{
				// �h���b�O���L�����Z������
				e.Action = DragAction.Cancel;

				// �h���b�v�n�C���C�g������
				this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();
			}
		}

		/// <summary>
		/// �t�H�[���N���[�W���O�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void PMKHN04001UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// ���o�����ݒ�N���X���X�g�\�z����
			List<ExtractConditionItem> extractConditionItemList = this.ExtractConditionItemListConstruction();
			this._extractConditionItems.SetExtractConditionItemList(extractConditionItemList);

			// ���o�����ݒ�����w�l�k�t�@�C���ɃV���A���C�Y
			ExtractConditionItems.Serialize(this._extractConditionItems.GetExtractConditionItemList(), EXTRACT_CONDITION_XML_FILE_NAME);

			// ��\����ԃN���X���X�g�\�z����
			List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

			// ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
			ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
		}

		/// <summary>
		/// ���o�����ݒ�c���[�`�F�b�N�{�b�N�X�`�F�b�N�㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ExtractConditionSetting_UTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
		{
			// ���o�����ݒ�N���X���X�g�\�z����
			List<ExtractConditionItem> extractConditionItemList = this.ExtractConditionItemListConstruction();
			this._extractConditionItems.SetExtractConditionItemList(extractConditionItemList);

			// ���o�����ݒ���͍��ڍ\�z����
			this.ExtractConditionInputItemConstruction(this._extractConditionItems.GetExtractConditionItemList());
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
			if (e.KeyCode == Keys.Left)
			{
				if ((this.SearchResult_UGrid.ActiveCell != null) &&
					(this.SearchResult_UGrid.ActiveCell.Row.Index == 0) && (this.SearchResult_UGrid.ActiveCell.Column.Header.VisiblePosition == 0))
				{
					List<Control> controls = this.GetExtractConditionPanelList(true);

					if (controls.Count > 0)
					{
						Infragistics.Win.UltraWinEditors.UltraTextEditor textEditor = this.GetTextEditorOnPanel((Panel)controls[0]);

						if (textEditor != null)
						{
							this.Search_UButton.Focus();
							this.ActiveControl = textEditor;
							textEditor.Focus();
						}
					}
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
		/// ���o�����p�l�����T�C�Y�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void Condition_Panel_Resize(object sender, System.EventArgs e)
		{
			// ���o�������͍��ڃp�l���\���ʒu�ݒ菈��
			this.ExtractConditionItemPositionSetting();
		}

		/// <summary>
		/// �f�[�^�\���^�C�}�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void DetailView_Timer_Tick(object sender, System.EventArgs e)
		{
			this.DetailView_Timer.Enabled = false;

			if ((this._detailViewForm == null) || ((!this._detailViewForm.Visible) && (!this.DetailView_Panel.Visible))) return;

			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				Control activeControl = this.ActiveControl;
				
				try
				{
					this._detailViewForm.DataView(this._initHtmlString);
				}
				catch
				{
					// ��O�͑Ώ����Ȃ�
				}
				finally
				{
					if ((activeControl != null) && (this.DetailView_Panel.Visible))
					{
						activeControl.Focus();
					}
				}
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

				// �ڍו\���pHTML������擾�����i�O���b�h�s���j
				string htmlString = this.DataRowToHtmlString(row);

				if (htmlString == "")
				{
					// �ڍו\���p������f�[�^�s�ݒ菈��
					this.SetHtmlStringToDataRow(row);

					// �ڍו\���pHTML������擾�����i�O���b�h�s���j
					htmlString = this.DataRowToHtmlString(row);
				}

				Control activeControl = this.ActiveControl;

				if (htmlString != "")
				{
					try
					{
						this._detailViewForm.DataView(htmlString);
					}
					catch
					{
						// ��O�͑Ώ����Ȃ�
					}
					finally
					{
						if ((activeControl != null) && (this.DetailView_Panel.Visible))
						{
							if (activeControl == this.SearchResult_UGrid)
							{
								if (this.SearchResult_UGrid.Rows.Count > 0)
								{
									activeControl.Focus();
								}
							}
							else
							{
								activeControl.Focus();
							}
						}
					}
				}
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

		/// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 �� ��</br>
        /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (this._extractionConditionInfo == null) return;
			if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if ( _extractionConditionInfo == null ) return;

            try
            {
                // �����_�ł̒��o�������͏��N���X�̏���ޔ�����
                CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

                switch ( e.PrevCtrl.Name )
                {
                    // ���Ӑ�R�[�h ============================================ //
                    case "tNedit_CustomerCode":
                        {
                            if ( this._extractionConditionInfo.CustomerCode != this.tNedit_CustomerCode.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                }

                                extractionConditionInfoBuff.CustomerCode = this.tNedit_CustomerCode.GetInt();

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // �t�H�[�J�X����
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // ���Ӑ�T�u�R�[�h ======================================== //
                    case "tEdit_CustomerSubCode":
                        {
                            if ( this._extractionConditionInfo.CustomerSubCode != this.tEdit_CustomerSubCode.DataText )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                }

                                extractionConditionInfoBuff.CustomerSubCode = this.tEdit_CustomerSubCode.DataText;

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // �t�H�[�J�X����
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // �J�i ==================================================== //
                    case "tEdit_CustomerKana":
                        {
                            if ( this._extractionConditionInfo.Kana != this.tEdit_CustomerKana.DataText )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                }

                                extractionConditionInfoBuff.Kana = this.tEdit_CustomerKana.DataText;

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // �t�H�[�J�X����
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // �d�b�ԍ��i�����p��4���j ================================= //
                    case "SearchTelNo_TEdit":
                        {
                            if ( this._extractionConditionInfo.SearchTelNo != this.SearchTelNo_TEdit.Text )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                }

                                extractionConditionInfoBuff.SearchTelNo = this.SearchTelNo_TEdit.Text;

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // �t�H�[�J�X����
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // ���̓R�[�h1 ============================================= //
                    case "CustAnalysCode1_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode1 != this.CustAnalysCode1_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // ���̓R�[�h2 ============================================= //
                    case "CustAnalysCode2_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode2 != this.CustAnalysCode2_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // ���̓R�[�h3 ============================================= //
                    case "CustAnalysCode3_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode3 != this.CustAnalysCode3_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // ���̓R�[�h4 ============================================= //
                    case "CustAnalysCode4_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode4 != this.CustAnalysCode4_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // ���̓R�[�h5 ============================================= //
                    case "CustAnalysCode5_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode5 != this.CustAnalysCode5_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // ���̓R�[�h6 ============================================= //
                    case "CustAnalysCode6_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode6 != this.CustAnalysCode6_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // �t�H�[�J�X����
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // ���Ӑ�S�� ============================================== //
                    case "tEdit_EmployeeNm":
                        {
                            if ( this.tEdit_EmployeeNm.Text.TrimEnd() != string.Empty )
                            {
                                if ( this._extractionConditionInfo.CustomerAgentNm.CompareTo( this.tEdit_EmployeeNm.Text ) != 0 )
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    if ( !this.MultiSelect_UCheckEditor.Checked )
                                    {
                                        extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                                    string employeeName;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                                    //int status = this.GetEmployeeFromEmployeeCode( this.tEdit_EmployeeNm.Text.Trim(), out employeeName );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                                    string employeeCode = GetInputCode( tEdit_EmployeeNm );
                                    int status = this.GetEmployeeFromEmployeeCode( employeeCode, out employeeName );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                    {
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                                        //extractionConditionInfoBuff.CustomerAgentCd = this.tEdit_EmployeeNm.Text;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                                        extractionConditionInfoBuff.CustomerAgentCd = employeeCode;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD
                                        extractionConditionInfoBuff.CustomerAgentNm = employeeName;

                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                        // �t�H�[�J�X����
                                        GetNextPanelControl( e );
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                    }
                                    else if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                                    {
                                        extractionConditionInfoBuff.CustomerAgentCd = string.Empty;
                                        extractionConditionInfoBuff.CustomerAgentNm = string.Empty;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_STOPDISP,
                                            this.Name,
                                            "�]�ƈ����̎擾�Ɏ��s���܂����B",
                                            status,
                                            MessageBoxButtons.OK );
                                    }

                                    // �����������̓R���g���[�����ݒ�
                                    this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                                }
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    // �t�H�[�J�X����
                                    GetNextPanelControl( e );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                }
                            }
                            else
                            {
                                // ���̓N���A
                                extractionConditionInfoBuff.CustomerAgentCd = string.Empty;
                                extractionConditionInfoBuff.CustomerAgentNm = string.Empty;
                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // �Ǘ����_ ============================================== //
                    case "tEdit_MngSectionNm":
                        {

                            if ( this.tEdit_MngSectionNm.Text.Trim() != string.Empty )
                            {
                                if ( this._extractionConditionInfo.MngSectionName.CompareTo( this.tEdit_MngSectionNm.Text ) != 0 )
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    if ( !this.MultiSelect_UCheckEditor.Checked )
                                    {
                                        extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                                    SecInfoSet secInfoSet;

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                                    //int status = this._secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, this.tEdit_MngSectionNm.Text.Trim() );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                                    int status = this._secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, GetInputCode( tEdit_MngSectionNm ) );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                    {
                                        extractionConditionInfoBuff.MngSectionCode = this.tEdit_MngSectionNm.Text;
                                        extractionConditionInfoBuff.MngSectionName = secInfoSet.SectionGuideNm;

                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                        // �t�H�[�J�X����
                                        GetNextPanelControl( e );
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                    }
                                    else if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                                    {
                                        extractionConditionInfoBuff.MngSectionCode = string.Empty;
                                        extractionConditionInfoBuff.MngSectionName = string.Empty;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_STOPDISP,
                                            this.Name,
                                            "���_���̎擾�Ɏ��s���܂����B",
                                            status,
                                            MessageBoxButtons.OK );
                                    }

                                    // �����������̓R���g���[�����ݒ�
                                    this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                                }
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    // �t�H�[�J�X����
                                    GetNextPanelControl( e );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                }
                            }
                            else
                            {
                                // ���̓N���A
                                extractionConditionInfoBuff.MngSectionCode = string.Empty;
                                extractionConditionInfoBuff.MngSectionName = string.Empty;
                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


                    // 2009/12/02 Add >>>
                    // ���Ӑ於 ==================================================== //
                    case "tEdit_CustomerName":
                        {
                            if (this._extractionConditionInfo.Name != this.tEdit_CustomerName.DataText)
                            {
                                if (!this.MultiSelect_UCheckEditor.Checked)
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
                                }

                                extractionConditionInfoBuff.Name = this.tEdit_CustomerName.DataText;

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);
                            }
                            // �t�H�[�J�X����
                            GetNextPanelControl(e);

                            break;
                        }
                    // 2009/12/02 Add <<<
                    /*
                    case "SupplierDiv_UCheckEditor":
                    case "AcceptWholeSale_UCheckEditor":
                    case "Customer_UCheckEditor":
                    {
                        return;
                        //break;
                    }
                    */
                    // �������ʃO���b�h ======================================== //
                    case "SearchResult_UGrid":
                        {
                            if ( e.Key == Keys.Return )
                            {
                                Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
                                Infragistics.Win.UltraWinToolbars.ButtonTool customerEditButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerEdit_ButtonTool"];

                                if ( selectButton.SharedProps.Visible )
                                {
                                    // �I���{�^���N���b�N����
                                    this.SelectButtonClick();
                                }
                                else
                                {
                                    if ( customerEditButton.SharedProps.Enabled )
                                    {
                                        e.NextCtrl = null;

                                        // ���Ӑ�ҏW�{�^���N���b�N����
                                        this.CustomerEditButtonClick();
                                    }
                                }
                            }

                            break;
                        }
                    // ---ADD 2010/08/06-------------------->>>
                    // �d�b�ԍ� ======================================== //
                    case "tEdit_TelNum":
                        {
                            if (this._extractionConditionInfo.TelNum != this.tEdit_TelNum.Text)
                            {
                                if (!this.MultiSelect_UCheckEditor.Checked)
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
                                }

                                extractionConditionInfoBuff.TelNum = this.tEdit_TelNum.Text;

                                // �����������̓R���g���[�����ݒ�
                                this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);
                            }
                            // �t�H�[�J�X����
                            GetNextPanelControl(e);

                            break;
                        }
                    // ---ADD 2010/08/06--------------------<<<
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // �t�H�[�J�X�����ڕ␳
                # region [�t�H�[�J�X�����ڕ␳]
                if ( e.PrevCtrl == Search_UButton && e.Key == Keys.Up && !e.ShiftKey )
                {
                    e.NextCtrl = _nextControlDic[_nextControlList[_nextControlList.Count - 1]];
                }
                else if ( e.PrevCtrl != null && e.PrevCtrl.Parent != null && !e.ShiftKey )
                {
                    bool nextCtrlSetted = false;

                    # region [�t�H�[�J�X����]
                    switch ( e.PrevCtrl.Name )
                    {
                        case "tNedit_CustomerCode":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Right:
                                        e.NextCtrl = e.PrevCtrl;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "Receiver_UCheckEditor":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Right:
                                        e.NextCtrl = e.PrevCtrl;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "CustomerSubCodeSearchType_UCheckEditor":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_CustomerSubCode;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "tEdit_CustomerSubCode":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Right:
                                        e.NextCtrl = CustomerSubCodeSearchType_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "KanaSearchType_UCheckEditor":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_CustomerKana;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "tEdit_CustomerKana":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Right:
                                        e.NextCtrl = KanaSearchType_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;

                        // 2009/12/02 Add >>>
                        case "NameSearchType_UCheckEditor":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_CustomerName;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "tEdit_CustomerName":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Right:
                                        e.NextCtrl = NameSearchType_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        // 2009/12/02 Add <<<

                        // 2011/7/22 XUJS ADD STA>>>>>>
                        case "SnmSearchType_UCheckEditor":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_CustomerSnm;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "tEdit_CustomerSnm":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Right:
                                        e.NextCtrl = SnmSearchType_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        // 2011/7/22 XUJS ADD END<<<<<<

                        // ---ADD 2010/08/06-------------------->>>
                        // �d�b�ԍ�
                        case "tEdit_TelNum":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Right:
                                        e.NextCtrl = TelNum_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        // �d�b�ԍ��B������
                        case "TelNum_UCheckEditor":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_TelNum;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        // ---ADD 2010/08/06--------------------<<<

                        default:
                            break;
                    }
                    # endregion

                    if ( !nextCtrlSetted )
                    {
                        if ( e.NextCtrl == Receiver_UCheckEditor && (e.Key == Keys.Up || e.Key == Keys.Down) )
                        {
                            e.NextCtrl = Customer_UCheckEditor;
                        }
                        else
                        {
                            # region [�����ƂȂ�p�l���P�ʂ̈ړ��𐧌�]
                            int panelIndex = _nextControlList.IndexOf( e.PrevCtrl.Parent.Name );
                            if ( panelIndex >= 0 )
                            {
                                if ( e.Key == Keys.Up )
                                {
                                    if ( panelIndex - 1 >= 0 )
                                    {
                                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex - 1]];
                                    }
                                    else if ( panelIndex == 0 )
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                                else if ( e.Key == Keys.Down )
                                {
                                    if ( panelIndex + 1 <= _nextControlList.Count - 1 )
                                    {
                                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex + 1]];
                                    }
                                    else
                                    {
                                        e.NextCtrl = Search_UButton;
                                    }
                                }
                            }
                            # endregion
                        }
                    }
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if ( this.Main_ExplorerBar.SelectedGroup.Key == "ExtractCondition" )
                {
                    // ���Ӑ挟���p�����[�^�N���X��������
                    this.SettingExtractionConditionClass( ref extractionConditionInfoBuff );

                    bool isSetting = this.IsExtractionConditionClassSetting( extractionConditionInfoBuff );

                    if ( isSetting )
                    {
                        // ��������̓��e�Ɣ�r����
                        ArrayList arRetList = extractionConditionInfoBuff.Compare( this._extractionConditionInfo );

                        if ( arRetList.Count > 0 )
                        {
                            // �����������̓R���g���[�����ݒ�
                            this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );

                            this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                            if ( this.AutoSearch_UCheckEditor.Checked )
                            {
                                this.Search_UButton_Click( this.Search_UButton, new EventArgs() );
                                e.NextCtrl = SearchResult_UGrid;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
		}
        /// <summary>
        /// ���p�l���t�H�[�J�X�ړ�����
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private void GetNextPanelControl( ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == null ) return;
            if ( e.PrevCtrl.Parent == null ) return;
            if ( _nextControlList == null ) return;
            if ( _nextControlDic == null ) return;

            int panelIndex = _nextControlList.IndexOf( e.PrevCtrl.Parent.Name );
            if ( panelIndex >= 0 )
            {
                if ( e.Key == Keys.Up )
                {
                    if ( panelIndex - 1 >= 0 )
                    {
                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex - 1]];
                    }
                    else if ( panelIndex == 0 )
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                else if ( e.Key == Keys.Down || e.Key == Keys.Tab || e.Key == Keys.Return )
                {
                    if ( panelIndex + 1 <= _nextControlList.Count - 1 )
                    {
                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex + 1]];
                    }
                    else
                    {
                        e.NextCtrl = Search_UButton;
                    }
                }
            }
        }
        /// <summary>
        /// ���p�l���t�H�[�J�X�ړ�����i�K�C�h�p�j
        /// </summary>
        /// <param name="prevCtrl"></param>
        private Control GetNextPanelControl( Control prevCtrl )
        {
            if ( prevCtrl == null ) return prevCtrl;
            if ( prevCtrl.Parent == null ) return prevCtrl;


            int panelIndex = _nextControlList.IndexOf( prevCtrl.Parent.Name );
            if ( panelIndex >= 0 )
            {
                if ( panelIndex + 1 <= _nextControlList.Count - 1 )
                {
                    return _nextControlDic[_nextControlList[panelIndex + 1]];
                }
                else
                {
                    return Search_UButton;
                }
            }
            else
            {
                return prevCtrl;
            }
        }


		/// <summary>
		/// ���o�����p�l���y�C���g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void Condition_Panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// ���o�������͍��ڃp�l���\���ʒu�ݒ菈��
			this.ExtractConditionItemPositionSetting();
		}

		/// <summary>
		/// ���o�����ݒ�c���[�`�F�b�N�{�b�N�X�`�F�b�N�O�����C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ExtractConditionSetting_UTree_BeforeCheck(object sender, Infragistics.Win.UltraWinTree.BeforeCheckEventArgs e)
		{
			// �C�x���g�����s�̎��́A�������Ȃ�
			if (this._noBeforeCheckEvent == true) 
			{
				this._noBeforeCheckEvent = false;
				return;
			}
		}

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
		/// ���Ӑ��ʃ`�F�b�N�{�b�N�X�`�F�b�N�ύX�㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void CustomerKind_AfterCheckStateChanged(object sender, EventArgs e)
		{
			if (!(sender is Infragistics.Win.UltraWinEditors.UltraCheckEditor))
			{
				return;
			}

			CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

			if (!this.MultiSelect_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
			}

			Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender;

			// ���Ӑ���
			this.SetCustomerDivStatus(ref extractionConditionInfoBuff);

			/*
			if (uCheckEditor == this.SupplierDiv_UCheckEditor)
			{
				extractionConditionInfoBuff.SupplierDiv = this.GetCheckEditorValue(this.SupplierDiv_UCheckEditor, EXIST_CODE_CHECKED, EXIST_CODE_UNCHECKED);
			}
			else if (uCheckEditor == this.AcceptWholeSale_UCheckEditor)
			{
				extractionConditionInfoBuff.AcceptWholeSale = this.GetCheckEditorValue(this.AcceptWholeSale_UCheckEditor, EXIST_CODE_CHECKED, EXIST_CODE_UNCHECKED);
			}
			*/

			bool isSetting = this.IsExtractionConditionClassSetting(extractionConditionInfoBuff);

			if (isSetting)
			{
				// ��������̓��e�Ɣ�r����
				ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

				if (arRetList.Count > 0)
				{
					// �����������̓R���g���[�����ݒ�
					this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

					this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

					if (this.AutoSearch_UCheckEditor.Checked)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
					}
				}
			}
		}

		/// <summary>
		/// �������ʃO���b�h�}�E�X�G���^�[�G�������g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                UiSet uiset;
                uiSetControl1.ReadUISet( out uiset, this.tNedit_CustomerCode.Name );
                string customerFormat = new string( '0', uiset.Column );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;
				string tipString = "";

				if (row.Cells[0] != null)
				{
					int totalWidth = 6;

					// ���Ӑ於��
					tipString += this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Name].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Name].Value.ToString();

                    // 2011/7/22 XUJS ADD STA>>>>>>
                    //���Ӑ旪��
                    tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Snm].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Snm].Value.ToString();
                    // 2011/7/22 XUJS ADD END<<<<<<

					// �J�i
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Kana].Value.ToString();

					// ���Ӑ�R�[�h
                    tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerCode].Header.Caption.PadRight( totalWidth, '�@' ) + "�F" + ((Int32)row.Cells[SEARCH_COL_CustomerCode].Value).ToString( customerFormat );

					// ���Ӑ�T�u�R�[�h
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerSubCode].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_CustomerSubCode].Value.ToString();

					// ����TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_HomeTelNo].Header.Caption).PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_HomeTelNo].Value.ToString();

					// �Ζ���TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_OfficeTelNo].Header.Caption).PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_OfficeTelNo].Value.ToString();

					// �g��TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_PortableTelNo].Header.Caption).PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_PortableTelNo].Value.ToString();

                    // 2009/12/02 Add >>>
                    // ����FAX
                    tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_HomeFaxNo].Header.Caption).PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_HomeFaxNo].Value.ToString();

                    // �Ζ���FAX
                    tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_OfficeFaxNo].Header.Caption).PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_OfficeFaxNo].Value.ToString();
                    // 2009/12/02 Add <<<

					// �Z��
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Address].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Address].Value.ToString();
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
		/// ���Ӑ�T�u�R�[�h�B�������`�F�b�N�G�f�B�^�`�F�b�N�m���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
		{
			CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

			if (!this.MultiSelect_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
			}

			extractionConditionInfoBuff.CustomerSubCode = this.tEdit_CustomerSubCode.Text;

			if (this.CustomerSubCodeSearchType_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff.CustomerSubCodeSearchType = 1;
			}
			else
			{
				extractionConditionInfoBuff.CustomerSubCodeSearchType = 0;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //bool isSetting = this.IsExtractionConditionClassSetting(extractionConditionInfoBuff);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // ���Ӑ�T�u�R�[�h�����͍ς݂Ȃ�΁A�B���`�F�b�N�{�b�N�X�ύX���������ʂɉe������̂ŁA�������s��
            bool isSetting = (this.tEdit_CustomerSubCode.Text.TrimEnd() != string.Empty);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			if (isSetting)
			{
				// ��������̓��e�Ɣ�r����
				ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

				if (arRetList.Count > 0)
				{
					// �����������̓R���g���[�����ݒ�
					this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

					this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

					if (this.AutoSearch_UCheckEditor.Checked)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
					}
				}
			}
			else
			{
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
			}
		}

		/// <summary>
		/// ���Ӑ�J�i�B�������`�F�b�N�G�f�B�^�`�F�b�N�m���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void KanaSearchType_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
		{
			CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

			if (!this.MultiSelect_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
			}

			extractionConditionInfoBuff.Kana = this.tEdit_CustomerKana.Text;

			if (this.KanaSearchType_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff.KanaSearchType = 1;
			}
			else
			{
				extractionConditionInfoBuff.KanaSearchType = 0;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //bool isSetting = this.IsExtractionConditionClassSetting(extractionConditionInfoBuff);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // ���Ӑ�ł����͍ς݂Ȃ�΁A�B���`�F�b�N�{�b�N�X�ύX���������ʂɉe������̂ŁA��������B
            bool isSetting = (this.tEdit_CustomerKana.Text.TrimEnd() != string.Empty);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			if (isSetting)
			{
				// ��������̓��e�Ɣ�r����
				ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

				if (arRetList.Count > 0)
				{
					// �����������̓R���g���[�����ݒ�
					this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

					this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

					if (this.AutoSearch_UCheckEditor.Checked)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
					}
				}
			}
			else
			{
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
			}
		}


        // 2009/12/02 Add >>>
        /// <summary>
        /// ���Ӑ於�B�������`�F�b�N�G�f�B�^�`�F�b�N�m���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void NameSearchType_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
        {
            CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

            if (!this.MultiSelect_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
            }

            extractionConditionInfoBuff.Name = this.tEdit_CustomerName.Text;

            if (this.NameSearchType_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff.NameSearchType = 1;
            }
            else
            {
                extractionConditionInfoBuff.NameSearchType = 0;
            }

            // ���Ӑ�ł����͍ς݂Ȃ�΁A�B���`�F�b�N�{�b�N�X�ύX���������ʂɉe������̂ŁA��������B
            bool isSetting = (this.tEdit_CustomerName.Text.TrimEnd() != string.Empty);

            if (isSetting)
            {
                // ��������̓��e�Ɣ�r����
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    // �����������̓R���g���[�����ݒ�
                    this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    if (this.AutoSearch_UCheckEditor.Checked)
                    {
                        this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
                    }
                }
            }
            else
            {
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
            }

        }
        // 2009/12/02 Add <<<


        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        // 2011/7/22 XUJS ADD STA>>>>>>
        /// <summary>
        /// ���Ӑ旪�̞B�������`�F�b�N�G�f�B�^�`�F�b�N�m���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void SnmSearchType_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
        {
            CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

            if (!this.MultiSelect_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
            }

            extractionConditionInfoBuff.CustomerSnm = this.tEdit_CustomerSnm.Text;

            if (this.SnmSearchType_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff.CustomerSnmSearchType = 1;
            }
            else
            {
                extractionConditionInfoBuff.CustomerSnmSearchType = 0;
            }

            // ���Ӑ�ł����͍ς݂Ȃ�΁A�B���`�F�b�N�{�b�N�X�ύX���������ʂɉe������̂ŁA��������B
            bool isSetting = (this.tEdit_CustomerSnm.Text.TrimEnd() != string.Empty);

            if (isSetting)
            {
                // ��������̓��e�Ɣ�r����
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    // �����������̓R���g���[�����ݒ�
                    this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    if (this.AutoSearch_UCheckEditor.Checked)
                    {
                        this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
                    }
                }
            }
            else
            {
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
            }
        }
        // 2011/7/22 XUJS ADD END<<<<<<

        // ---ADD 2010/08/06-------------------->>>
        /// <summary>
        /// �d�b�ԍ��B�������`�F�b�N�G�f�B�^�`�F�b�N�m���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void TelNum_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
        {
            CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

            if (!this.MultiSelect_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
            }

            extractionConditionInfoBuff.TelNum = this.tEdit_TelNum.Text;

            if (this.TelNum_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff.TelNumSearchType = 1;
            }
            else
            {
                extractionConditionInfoBuff.TelNumSearchType = 0;
            }

            // �d�b�ԍ������͍ς݂Ȃ�΁A�B���`�F�b�N�{�b�N�X�ύX���������ʂɉe������̂ŁA��������B
            bool isSetting = (this.tEdit_TelNum.Text.TrimEnd() != string.Empty);

            if (isSetting)
            {
                // ��������̓��e�Ɣ�r����
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    // �����������̓R���g���[�����ݒ�
                    this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    if (this.AutoSearch_UCheckEditor.Checked)
                    {
                        this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
                    }
                }
            }
            else
            {
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
            }
        }
        // ---ADD 2010/08/06--------------------<<<

		/// <summary>
		/// �t�H�[���I���������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void PMKHN04001UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			List<PMKHN09000UA> customerFormList = new List<PMKHN09000UA>();
			foreach (PMKHN09000UA customerInputForm in this._customerFormList)
			{
				customerFormList.Add(customerInputForm);
			}

			foreach (PMKHN09000UA customerInputForm in customerFormList)
			{
				if ((customerInputForm == null) || (customerInputForm.IsDisposed)) continue;

				if ((this._executeMode == EXECUTEMODE_GUIDE_ONLY) ||
					(this._executeMode == EXECUTEMODE_GUIDE_AND_EDIT))
				{
					customerInputForm.Close();
				}
				else 
				{
					customerInputForm.Show();
					customerInputForm.BringToFront();

					int status = customerInputForm.DispClose();

					if (status == 1)
					{
						e.Cancel = true;
						return;
					}
				}
			}
		}

		/// <summary>
		/// �]�ƈ��K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void CustomerAgentCdGuide_UButton_Click(object sender, EventArgs e)
		{
			string employeeCode;
			string employeeName;

			// �]�ƈ��K�C�h�\������
			int status = this.ShowEmployeeGuide(out employeeCode, out employeeName);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                if ( !this.MultiSelect_UCheckEditor.Checked )
                {
                    _extractionConditionInfo = CustomerSearchExtractionConditionInfo.Create( _extractionConditionInfo );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				this._extractionConditionInfo.CustomerAgentCd = employeeCode;
				this._extractionConditionInfo.CustomerAgentNm = employeeName;

				// �����������̓R���g���[�����ݒ�
				this.SettingExtractConditionItemInfo(this._extractionConditionInfo);

				// ���Ӑ挟���p�����[�^�N���X��������
				this.SettingExtractionConditionClass(ref this._extractionConditionInfo);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // �t�H�[�J�X�ړ�
                GetNextPanelControl( tEdit_EmployeeNm ).Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				bool isSetting = this.IsExtractionConditionClassSetting(this._extractionConditionInfo);

				if (isSetting)
				{
					if (this.AutoSearch_UCheckEditor.Checked)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
					}
				}
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

        /// <summary>
        /// �Ǘ����_�R�[�h�K�C�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MngSectionCodeGuide_UButton_Click( object sender, EventArgs e )
        {
            SecInfoSet secInfoSet;
            int status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out secInfoSet );

            if ( status == 0 )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                if ( !this.MultiSelect_UCheckEditor.Checked )
                {
                    _extractionConditionInfo = CustomerSearchExtractionConditionInfo.Create( _extractionConditionInfo );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                this._extractionConditionInfo.MngSectionCode = secInfoSet.SectionCode;
                this._extractionConditionInfo.MngSectionName = secInfoSet.SectionGuideNm;

                // �����������̓R���g���[�����ݒ�
                this.SettingExtractConditionItemInfo( this._extractionConditionInfo );

                // ���Ӑ挟���p�����[�^�N���X��������
                this.SettingExtractionConditionClass( ref this._extractionConditionInfo );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // �t�H�[�J�X�ړ�
                GetNextPanelControl( tEdit_MngSectionNm ).Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                bool isSetting = this.IsExtractionConditionClassSetting( this._extractionConditionInfo );

                if ( isSetting )
                {
                    if ( this.AutoSearch_UCheckEditor.Checked )
                    {
                        this.Search_UButton_Click( this.Search_UButton, new EventArgs() );
                        SearchResult_UGrid.Focus();
                    }
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

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
				if (customerEditButton.SharedProps.Enabled)
				{
					// ���Ӑ�ҏW�{�^���N���b�N����
					this.CustomerEditButtonClick();
				}
			}

		}

		/// <summary>
		/// �t�H�[���N���㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void PMKHN04001UA_Shown(object sender, EventArgs e)
		{
			if ((this._executeMode == EXECUTEMODE_GUIDE_AND_EDIT) || (this._executeMode == EXECUTEMODE_GUIDE_ONLY))
			{
				// �ŏ�ʐe�t�H�[���擾����
				Form ownerForm = this.GetTopLevelOwnerForm();

				if (ownerForm != null)
				{
					if ((ownerForm.Height < this.Height) && (ownerForm.Width < this.Width)) return;

					int afterHeight = Convert.ToInt32(ownerForm.Height * 0.95);
					int afterWidth = Convert.ToInt32(ownerForm.Width * 0.95);

					int afterTop = Convert.ToInt32(ownerForm.Top + ((ownerForm.Height - afterHeight) * 0.5));
					int afterLeft = Convert.ToInt32(ownerForm.Left + ((ownerForm.Width - afterWidth) * 0.5));

					this.Size = new Size(afterWidth, afterHeight);
					this.Location = new Point(afterLeft, afterTop);
				}
			}
		}

		/// <summary>
		/// ���o�����ݒ�c���[�}�E�X�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ExtractConditionSetting_UTree_MouseClick(object sender, MouseEventArgs e)
		{
			// �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
			Point point = System.Windows.Forms.Cursor.Position;
			point = this.ExtractConditionSetting_UTree.PointToClient(point);

			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinTree.NodeCheckBoxUIElement objNodeCheckBoxElement = null;
			objElement = this.ExtractConditionSetting_UTree.UIElement.ElementFromPoint(point);

			objNodeCheckBoxElement = (Infragistics.Win.UltraWinTree.NodeCheckBoxUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinTree.NodeCheckBoxUIElement)));

			// �`�F�b�N�{�b�N�X�̏ꍇ�͈ȉ��̏������L�����Z������
			if (objNodeCheckBoxElement != null)
			{
				return;
			}

			Infragistics.Win.UltraWinTree.UltraTreeNode clickedNode =
											this.ExtractConditionSetting_UTree.GetNodeFromPoint(point);

			if (clickedNode == null) return;

			if (clickedNode.CheckedState == CheckState.Checked)
			{
				clickedNode.CheckedState = CheckState.Unchecked;
			}
			else
			{
				clickedNode.CheckedState = CheckState.Checked;
			}
		}

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>
        /// CheckEditor.CheckedChanged �C�x���g(DeleteIndication_CheckEditor)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �폜�ς݃f�[�^��\������`�F�b�N�G�f�B�^�R���g���[����Checked
        ///					�@�v���p�e�B���ύX�����Ƃ��ɔ������܂��B
        ///					�@�폜�ς݃f�[�^�̃t�B���^���������A�폜�ς݃f�[�^��\�����܂��B</br>
        /// <br>Programmer  : 30452 ��� �r��</br>
        /// <br>Date        : 2008.09.04</br>
        /// </remarks>
        private void DeleteIndication_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // 0�s�̏ꍇ�͏����Ȃ�
            if (this.Search_DataSet.Tables[SEARCH_TABLE].DefaultView.Count == 0)
            {
                return;
            }

            // ��̕\���ݒ�
            if (this.DeleteIndication_CheckEditor.Checked)
            {
                this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_LogicalDeleteDate].Hidden = false;
            }
            else
            {
                this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_LogicalDeleteDate].Hidden = true;
            }

            // �_���폜�t�B���^�ݒ�
            this.AddGridFiltering();
        }
        // --- ADD 2008/09/04 --------------------------------<<<<< 

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// �A�N�e�B�u�O���[�v�ύX�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_ExplorerBar_ActiveGroupChanged( object sender, Infragistics.Win.UltraWinExplorerBar.GroupEventArgs e )
        {
            // �t�H�[�J�X�ړ��p�̃R���g���[���ꗗ���X�V����
            _nextControlList = new List<string>();
            List<ExtractConditionItem> extractconditioItemList = this._extractConditionItems.GetExtractConditionItemList();
            for ( int index = 0; index < extractconditioItemList.Count; index++ )
            {
                if ( extractconditioItemList[index].IsDisplay() )
                {
                    _nextControlList.Add( "Condition_" + extractconditioItemList[index].Key.TrimEnd() + "_Panel" );
                }
            }
        }

        /// <summary>
        /// �`�F�b�N�ύX�C�x���g�����i�l���ς��O�ɔ����j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Customer_UCheckEditor_BeforeCheckStateChanged( object sender, CancelEventArgs e )
        {
            if ( sender == this.Customer_UCheckEditor )
            {
                if ( !Customer_UCheckEditor.Checked )
                {
                    // ���Ӑ�Ƀ`�F�b�N��t���āA�[����̃`�F�b�N���O��
                    Customer_UCheckEditor.BeforeCheckStateChanged -= Customer_UCheckEditor_BeforeCheckStateChanged;
                    Customer_UCheckEditor.Checked = true;
                    Customer_UCheckEditor.BeforeCheckStateChanged += Customer_UCheckEditor_BeforeCheckStateChanged;

                    Receiver_UCheckEditor.BeforeCheckStateChanged -= Customer_UCheckEditor_BeforeCheckStateChanged;
                    Receiver_UCheckEditor.Checked = false;
                    Receiver_UCheckEditor.BeforeCheckStateChanged += Customer_UCheckEditor_BeforeCheckStateChanged;
                }
            }
            else if ( sender == this.Receiver_UCheckEditor )
            {
                if ( !Receiver_UCheckEditor.Checked )
                {
                    // �[����Ƀ`�F�b�N��t���āA���Ӑ�̃`�F�b�N���O��
                    Receiver_UCheckEditor.BeforeCheckStateChanged -= Customer_UCheckEditor_BeforeCheckStateChanged;
                    Receiver_UCheckEditor.Checked = true;
                    Receiver_UCheckEditor.BeforeCheckStateChanged += Customer_UCheckEditor_BeforeCheckStateChanged;
                    
                    Customer_UCheckEditor.BeforeCheckStateChanged -= Customer_UCheckEditor_BeforeCheckStateChanged;
                    Customer_UCheckEditor.Checked = false;
                    Customer_UCheckEditor.BeforeCheckStateChanged += Customer_UCheckEditor_BeforeCheckStateChanged;
                }
            }
        }

        /// <summary>
        /// �O���b�h����̃t�H�[�J�X�E�o�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchResult_UGrid_Leave( object sender, EventArgs e )
        {
            if ( SearchResult_UGrid.ActiveRow != null )
            {
                SearchResult_UGrid.ActiveRow.Selected = false;
                SearchResult_UGrid.ActiveRow = null;
            }
        }
        /// <summary>
        /// �O���b�h�ւ̃t�H�[�J�X�i���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchResult_UGrid_Enter( object sender, EventArgs e )
        {
            string firstColumnKey = "";

            foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns )
            {
                if ( column.Header.VisiblePosition == 0 )
                {
                    firstColumnKey = column.Key;
                    break;
                }
            }

            foreach ( Infragistics.Win.UltraWinGrid.UltraGridRow row in SearchResult_UGrid.Rows )
            {
                if ( (int)row.Cells[SEARCH_COL_LogicalDeleteCode].Value != 0 ) continue;
                
                this.SearchResult_UGrid.Focus();
                this.SearchResult_UGrid.ActiveCell = row.Cells[firstColumnKey];
                this.SearchResult_UGrid.ActiveCell.Selected = true;
                this.SearchResult_UGrid.ActiveRow = row;
                this.SearchResult_UGrid.ActiveRow.Selected = true;

                break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
        /// <summary>
        /// �����񍀖ڂ̃R�[�h�ϊ�����(��ۋl�ߑΉ�)
        /// </summary>
        /// <param name="targetEdit"></param>
        /// <returns></returns>
        private string GetInputCode( TEdit targetEdit )
        {
            UiSet uiset;
            if ( uiSetControl1.ReadUISet( out uiset, targetEdit.Name ) == 0 )
            {
                // �ݒ�Ɋ�Â��[���l��
                // �i�{�����̏�����s�v�ɂ���ׂ̃R���|�[�l���g�����A���͕���������Ȃ̂Ŏ蓮�Ή�����j

                return targetEdit.Text.TrimEnd().PadLeft( uiset.Column, '0' );
            }
            else
            {
                // �ݒ���擾�ł��Ȃ������ꍇ�͂��̂܂ܕԂ��B
                return targetEdit.Text.TrimEnd();
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

        // ---ADD 2010/08/06-------------------->>>
        /// <summary>
        /// �L�[�����C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN04001UA_KeyDown(object sender, KeyEventArgs e)
        {
            // ESC�L�[�����ɂ���ʕ��鏈��
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        // ---ADD 2010/08/06--------------------<<<

		# endregion
	}
}
