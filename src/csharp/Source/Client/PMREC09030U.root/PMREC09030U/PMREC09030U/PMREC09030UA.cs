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
    /// ���������i�O���[�v�����t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���������i�O���[�v�����t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 20073 �� �B</br>
	/// <br>Date       : 2015.02.24</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/05 ���� ��Y</br>
    /// <br>             RedMine#331:���[�U�[�ݒ蕪���擾����Ȃ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/06 ���I ���</br>
    /// <br>             RedMine#331:�����[�g�𐳂����ĂԂ悤�ɏC��</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/06 ���� ��Y</br>
    /// <br>             RedMine#331:�ʏ탂�[�h�ł̓��Ӑ揉���ݒ��\��</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/09 �e�c ���V</br>
    /// <br>            �@�@�@�@�@�@:�ʏ탂�[�h�̏ꍇ�A���Ӑ���g�p�s�ɐݒ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/11 ���I ���</br>
    /// <br>                        :�ʏ탂�[�h�̏ꍇ��Enter�Ŋm��ł��Ȃ����ۂ��C��</br>
    /// <br>                         �Ɖ�[�h�œ��Ӑ�̍i�����s���Ȃ����ۂ��C��</br>
    /// <br>                         �ʏ탂�[�h�̏ꍇ�ɃO���b�h�擪�s�����������ƃt�H�[�J�X��</br>
    /// <br>                         �����錻�ۂ��C��</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/19 �e�c ���V</br>
    /// <br>                        :�i��Redmine#3295 �ۑ�Ǘ��\��38</br>
    /// <br>                         ���[�U�[�o�^����BL�񋟕����d�����Ă���ꍇ�A</br>
    /// <br>                         ���[�U�[�o�^����D�悵�ĕ\������</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	public partial class PMREC09030UA : System.Windows.Forms.Form
	{
        // ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
        /// ���������i�O���[�v�����t�H�[���t���[���N���X�f�t�H���g�R���X�g���N�^
		/// </summary>
		public PMREC09030UA()
		{
			InitializeComponent();

			// �ϐ�������
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._imageList16 = IconResourceManagement.ImageList16;
			this._searchDataView = new DataView();
			this._initialDataRead = new InitialDataReadHandler(this.InitialDataRead);
			this._extractConditionItemControlDictionary = new Dictionary<string, Panel>();
            //this._extractionConditionInfo = new CustomerSimpleSearchCndtn();
			//this._extractConditionList.Add(this._extractionConditionInfo.Clone());
			//this._controlScreenSkin = new ControlScreenSkin();
            //this._salesTtlStAcs = new SalesTtlStAcs();
            this._paraMngSectionCode = string.Empty;
            this._paraMngSectionName = string.Empty;
            this._autoSearch = true;
            //this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerCodeList = new ArrayList();
            this._customerSearchAcs = new CustomerSearchAcs();
            this.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
        }

		/// <summary>
        /// ���������i�O���[�v�����t�H�[���t���[���N���X�R���X�g���N�^
		/// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
        public PMREC09030UA(int GuideType, int CustomerCode)
            : this()
		{
            this._guideType = GuideType;
            this._customerCode = CustomerCode;
            //------ ADD 2015/03/06 ���I ----->>>>>>
            this._praCustomerCode = this._customerCode;
            //------ ADD 2015/03/06 ���I -----<<<<<<

        }

        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
        /// <summary>
        /// ���������i�O���[�v�����t�H�[���t���[���N���X�R���X�g���N�^�i���Ӑ惊�X�g�n���j
        /// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
        public PMREC09030UA(int GuideType, int CustomerCode, ArrayList customerCodeList)
            : this()
        {
            this._guideType = GuideType;
            this._customerCode = CustomerCode;
            //------ ADD 2015/03/06 ���I ----->>>>>>
            this._praCustomerCode = this._customerCode;
            //------ ADD 2015/03/06 ���I -----<<<<<<
            this._customerCodeList = customerCodeList;
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
                /*
				int customerCode1 = Convert.ToInt32(row1.Cells[SEARCH_COL_CustomerCode].Value);
				int customerCode2 = Convert.ToInt32(row2.Cells[SEARCH_COL_CustomerCode].Value);

				if ((customerCode1 == 0) || (customerCode2 == 0)) return false;
				return customerCode1 == customerCode2;
                 */
                return true;
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
        // �f�[�^�e�[�u�����`�i���������i�O���[�v�������ʏ��j
		internal const string SEARCH_TABLE							= "SEARCHTABLE";
        internal const string SEARCH_COL_CustomerName = "CustomerName";				// ���Ӑ�R�[�h
        internal const string SEARCH_COL_BrgnGoodsGrpCode = "BrgnGoodsGrpCode";			// ���Ӑ�T�u�R�[�h
        internal const string SEARCH_COL_BrgnGoodsGrpTitle = "BrgnGoodsGrpTitle";						// ����
        internal const string SEARCH_COL_BrgnGoodsGrpComment = "BrgnGoodsGrpComment";						// ���̂Q
        internal const string SEARCH_COL_LogicalDeleteCode = "LogicalDeleteCode";						// ���̂Q
        internal const string SEARCH_COL_SelectedFlg = "SelectedFlg";						// ���̂Q

		private const string EXTRACT_CONDITION_XML_FILE_NAME = "PMREC09030U_ExtractCondition.XML";	// ���o�����Z�b�e�B���O�w�l�k�t�@�C���p�X
		private const string FILENAME_COLDISPLAYSTATUS = "PMREC09030U_ColSetting.DAT";				// ��\����ԃZ�b�e�B���OXML�t�@�C����
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
        public const int GUIDETYPE_NORMAL = 0;
        /// <summary>SEARCHMODE �[����</summary>
        public const int GUIDETYPE_READONLY = 1;   // �ǎ��p
        
        # endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members

        /// <summary> ��ƃR�[�h</summary>
        private string _enterpriseCode = "";												// ��ƃR�[�h
        /// <summary> �C���[�W���X�g</summary>
        private ImageList _imageList16 = null;												// �C���[�W���X�g

        //private CustomerSimpleSearchCndtn _extractionConditionInfo = null;		// ���o�������͏��N���X
        //private List<CustomerSimpleSearchCndtn> _extractConditionList = new List<CustomerSimpleSearchCndtn>();	// ���o�����������X�g

        /// <summary> ���������i�O���[�v�������ʃf�[�^�r���[</summary>
        private DataView _searchDataView = null;
        /// <summary> ���o�������͍���Dictionary</summary>
        private Dictionary<string, Panel> _extractConditionItemControlDictionary = null;
        /// <summary> ��\����ԃR���N�V�����N���X</summary>
        private ColDisplayStatusList _colDisplayStatusList = null;
        /// <summary> �I���sIndex</summary>
        private int _selectedRowIndex = -1;													// �I���sIndex

        InitialDataReadHandler _initialDataRead = null;
        private ControlScreenSkin _controlScreenSkin;

        #region �R���X�g���N�^�����i�[�p

        /// <summary> �����^�C�v�i0:�ʏ�̃K�C�h�A1:���������i�O���[�v�󋵏Ɖ�j </summary>
        private int _guideType = GUIDETYPE_NORMAL;
        /// <summary> ���Ӑ�R�[�h </summary>
		private int _customerCode = 0;
        /// <summary> ���Ӑ惊�X�g </summary>
        private ArrayList _customerCodeList;

        #endregion

        #region ���o����

        private string _paraMngSectionCode;                                                 // �i���o�����j�Ǘ����_�R�[�h
        private string _paraMngSectionName;                                                 // �i���o�����j�Ǘ����_����
        private bool _autoSearch;                                                           // ���������敪�i�t�h����j
        //private SalesTtlStAcs _salesTtlStAcs = null;
        // 2011/07/27 XUJS ADD STA>>>>>>
        //private SecInfoSetAcs _secInfoSetAcs = null;                                        // ���_�A�N�Z�X�N���X
        private int _praCustomerCode = -1;
        // 2011/07/27 XUJS ADD END<<<<<<
        //private int _pccuoeMode;                                                            //PCC���Зp�^�C�v ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19
        private CustomerSearchAcs _customerSearchAcs;

        private bool _cusotmerGuideSelected; // ���Ӑ�K�C�h�I���t���O

        # endregion

        #endregion

        // ===================================================================================== //
        // �p�u���b�N�@�v���p�e�B
        // ===================================================================================== //
        # region Public Propaty
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
        #region Event Hndlers

        /// <summary> ���������i�O���[�v�I���C�x���g </summary>
        public event RecBgnGrpSelectEventHandler RecBgnGrpSelect;
        /// <summary> ���������i�O���[�v�I���C�x���g�f���Q�[�g </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���������i�O���[�v�����߂�l�N���X</param>
        public delegate void RecBgnGrpSelectEventHandler(object sender, RecBgnGrpRet recBgnGrpRet);
        /// <summary>�t�H�[�J�X�̕ω�</summary>
        internal event EventHandler GridKeyUpTopRow;
        /// <summary></summary>
        private delegate void InitialDataReadHandler();

        # endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
        /// ���������i�O���[�v��������
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���������i�O���[�v�������������s���܂��B</br>
		/// <br>Programer  : 22018�@��ؐ��b</br>
		/// <br>Date       : 2005.09.05</br>
		/// </remarks>
		public void Search()
		{
			this.Search_UButton_Click(this, new EventArgs());
		}

		/// <summary>
		/// �I�����i��ƃR�[�h�E���Ӑ�R�[�h�j�擾����
		/// </summary>
        /// <param name="customerSearchRet">���������i�O���[�v�������ʃN���X</param>
		/// <returns>STATUS[0:�擾���� 0�ȊO:�擾���s]</returns>
		/// <remarks>
        /// <br>Note       : ���ݑI�𒆂̂��������i�O���[�v�������ʃN���X���擾���܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
        public int GetSelectInfo(out RecBgnGrpRet recBgnGrpRet)
		{

            recBgnGrpRet = null;

			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				return -1;
			}

			// �I���s�̃C���f�b�N�X���擾
			CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
			int index = cm.Position;	

			// �w��s�̓��e���擾
			DataRow row = this._searchDataView[index].Row;

			// ���������i�O���[�v�������ʃN���X�擾�����i�O���b�h�s���j
            recBgnGrpRet = this.DataRowTorecBgnGrpRet(row);

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //recBgnGrpRet = null;
            //return 0;
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
			// ����̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
			closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // �I���̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
			selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
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

			// �c�[���o�[�����ݒ菈��
			this.SetToolbar();

			// MDI�^SDI�t�H�[���ݒ菈��
			this.MdiSdiFormSetting();

			// �e�R���g���[�������ݒ�
			this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;
			this.GridFontSize_TComboEditor.Value = 10;

            // ���������i�O���[�v�������ʃf�[�^�e�[�u���ݒ菈��
			this.SettingCustomerSearchDataTable();

			// �Œ�w�b�_�[�@�\�̗L���ɂ���
			this.SearchResult_UGrid.DisplayLayout.UseFixedHeaders = true;

            // ���������i�O���[�v�������ʃO���b�h�J�������ݒ菈��
			this.SettingSearchGridColumn(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);

			// �s�T�C�Y��ݒ�
            this.SearchResult_UGrid.DisplayLayout.Override.DefaultRowHeight = 20;

            // �C�� 2009/07/10 >>>
			//this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerName].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            // �C�� 2009/07/10 <<<

            // 2011/07/27 XUJS ADD STA>>>>>>
            this.FilterResult_Panel.Dock = DockStyle.Top;
            // 2011/07/27 XUJS ADD END<<<<<<
			this.ExtractResult_Panel.Dock = DockStyle.Fill;
            //this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "F3�F�����ݒ�@F6�F�i���@ESC�F�I��"; //ADD 2011/08/11
            this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "F3�F�����ݒ�@F5�F�޲�ށ@F6�F�i���@ESC�F�I��"; //ADD 2011/08/11
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
			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

            //string enterpriseCode;
			Infragistics.Win.UltraWinGrid.UltraGridRow row = this.SearchResult_UGrid.ActiveRow;

            if (this._guideType == GUIDETYPE_READONLY)
            {
                selectButton.SharedProps.Enabled = false;
            }
            else
            {
                if (row == null)
                {
                    selectButton.SharedProps.Enabled = false;

                }
                else
                {
                    selectButton.SharedProps.Enabled = true;
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
        /// ���������i�O���[�v�������ʃf�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���������i�O���[�v�������ʂ̃f�[�^�e�[�u����ݒ肵�܂��B</br>
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
			// ����
            DataColumn CustomerName = new DataColumn(SEARCH_COL_CustomerName, typeof(String), "", MappingType.Element);
            CustomerName.Caption = "���Ӑ於��";

            //  
            DataColumn BrgnGoodsGrpCode = new DataColumn(SEARCH_COL_BrgnGoodsGrpCode, typeof(String), "", MappingType.Element);
            BrgnGoodsGrpCode.Caption = "�R�[�h";

            // ���������i�O���[�v�^�C�g��
            DataColumn BrgnGoodsGrpTitle = new DataColumn(SEARCH_COL_BrgnGoodsGrpTitle, typeof(String), "", MappingType.Element);
            BrgnGoodsGrpTitle.Caption = "���������i�O���[�v�^�C�g��";

            // ���������i�O���[�v�R�����g
            DataColumn BrgnGoodsGrpComment = new DataColumn(SEARCH_COL_BrgnGoodsGrpComment, typeof(String), "", MappingType.Element);
            BrgnGoodsGrpComment.Caption = "���������i�O���[�v�R�����g";
            /*
			// ���������i�O���[�v�������ʃN���X
            DataColumn CustomerSearchRetCol = new DataColumn(SEARCH_COL_CustomerSearchRet, typeof(RecBgnGrpRet), "", MappingType.Element);
			CustomerSearchRetCol.Caption = "���������i�O���[�v�������ʃN���X";

			// �ڍו\���pHTML������
			DataColumn HtmlString = new DataColumn(SEARCH_COL_HtmlString, typeof(String), "", MappingType.Element);
			HtmlString.Caption = "�ڍו\���pHTML������";

            */
            // �I���ς݃t���O
			DataColumn SelectedFlg = new DataColumn(SEARCH_COL_SelectedFlg, typeof(Int32), "", MappingType.Element);
            SelectedFlg.Caption = "�I���ς݃t���O";

			// �_���폜�敪�i���Ӑ�j
			DataColumn LogicalDeleteCodeCustomer = new DataColumn(SEARCH_COL_LogicalDeleteCode, typeof(Int32), "", MappingType.Element);
            LogicalDeleteCodeCustomer.Caption = "�_���폜�敪�i���Ӑ�j";
			//--------------------------------------------------
			//  �f�[�^�Z�b�g�A�f�[�^�e�[�u���̏�����
			//--------------------------------------------------
			// �f�[�^�Z�b�g�̏�����
			this.Search_DataSet.Tables.AddRange(new DataTable[] {searchTable});

			// �f�[�^�e�[�u���̏�����
			searchTable.Columns.AddRange(new DataColumn[] {
															  CustomerName,					// ���Ӑ�R�[�h
															  BrgnGoodsGrpCode,				// ���Ӑ�T�u�R�[�h
															  BrgnGoodsGrpTitle,							// ����
                                                              BrgnGoodsGrpComment,
                                                              SelectedFlg,
                                                              LogicalDeleteCodeCustomer
															});

			this._searchDataView.Table = searchTable;
            this._searchDataView.Sort = string.Format("{0} ASC", SEARCH_COL_CustomerName);
            //this._searchDataView.RowFilter = string.Format( "{0}=0", SEARCH_COL_LogicalDeleteCode );

			//�@�O���b�h�Ƀf�[�^�Z�b�g���o�C���h
			//this.SearchResult_UGrid.DataSource = this.Search_DataSet.Tables[SEARCH_TABLE];
            this.SearchResult_UGrid.DataSource = _searchDataView;

		}

		/// <summary>
        /// ���������i�O���[�v�������ʃN���X�擾�����i�O���b�h�s���j
		/// </summary>
		/// <param name="row">�f�[�^�s���</param>
        /// <returns>�擾�������������i�O���[�v�������ʃN���X�f�[�^</returns>
		/// <remarks>
        /// <br>Note       : �f�[�^�s�̏�񂩂炨�������i�O���[�v�������ʃN���X���擾���܂��B</br>
		/// <br>Programer  : 22018  ��ؐ��b</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
        private RecBgnGrpRet DataRowTorecBgnGrpRet(DataRow row)
		{
            /*
            if (_customerSearchRetDic.ContainsKey(customerCode))
            {
                retCustomerInfo = _customerSearchRetDic[customerCode];
            }
            */
            RecBgnGrpRet recBgnGrpRet = new RecBgnGrpRet();
            Int16 brgnGoodsGrpCode = 0;
            Int16.TryParse(row[SEARCH_COL_BrgnGoodsGrpCode].ToString(), out brgnGoodsGrpCode);
            recBgnGrpRet.BrgnGoodsGrpCode = brgnGoodsGrpCode;
            recBgnGrpRet.BrgnGoodsGrpComment = row[SEARCH_COL_BrgnGoodsGrpComment].ToString();
            recBgnGrpRet.BrgnGoodsGrpTitle = row[SEARCH_COL_BrgnGoodsGrpTitle].ToString();

            return recBgnGrpRet;
        }

		/// <summary>
        /// ���������i�O���[�v�������ʃO���b�h�s�ݒ菈��
		/// </summary>
        /// <param name="searchRet">�ݒ茳�̂��������i�O���[�v�������ʃN���X</param>
		/// <param name="row">�ݒ��̃f�[�^�s</param>
		/// <returns>�l���ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
        /// <br>Note       : ���������i�O���[�v�������ʃN���X���f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer  : 22018�@��ؐ��b</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        private DataRow RecBgnGrpRetToDataRow(RecBgnGrpRet searchRet, DataRow row)
		{
			if (row == null)
			{
				row = this.Search_DataSet.Tables[SEARCH_TABLE].NewRow();
			}

            //row[SEARCH_COL_EnterpriseCode] = searchRet.LogicalDeleteCode.ToString();					// �_���폜�敪
            //row[SEARCH_COL_CustomerCode] = searchRet.InqOriginalEpCd;					// �⍇������ƃR�[�h
            //row[SEARCH_COL_CustomerSubCode] = searchRet.InqOriginalSecCd;				// �⍇�������_�R�[�h
            row[SEARCH_COL_BrgnGoodsGrpCode] = searchRet.BrgnGoodsGrpCode.ToString().PadLeft(4,'0');	// ���������i�O���[�v�R�[�h
            //row[SEARCH_COL_Name2] = searchRet.DisplayOrder;							// �\������
            row[SEARCH_COL_BrgnGoodsGrpTitle] = searchRet.BrgnGoodsGrpTitle;                            // ���������i�O���[�v�^�C�g��
            //row[SEARCH_COL_Kana] = searchRet.BrgnGoodsGrpTag;							// ���������i�O���[�v�R�����g�^�O
            row[SEARCH_COL_BrgnGoodsGrpComment] = searchRet.BrgnGoodsGrpComment;						// ���������i�O���[�v�R�����g

            if (searchRet.InqOriginalEpCd == ""
             && searchRet.InqOriginalSecCd == "")
            {
                row[SEARCH_COL_CustomerName] = "����";
            }
            else
            {
                foreach (CustomerSearchRet customerSearchRet in _customerCodeList)
                {
                    if (customerSearchRet.LogicalDeleteCode == 0)
                    {
                        if (customerSearchRet.CustomerEpCode == searchRet.InqOriginalEpCd
                         && customerSearchRet.CustomerSecCode == searchRet.InqOriginalSecCd)
                        {
                            row[SEARCH_COL_CustomerName] = customerSearchRet.Snm;
                            break;
                        }
                    }
                }
            }

			return row;
		}

		/// <summary>
        /// ���������i�O���[�v�������ʃO���b�h�J�������ݒ菈��
		/// </summary>
        /// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
		/// <remarks>
        /// <br>Note       : ���������i�O���[�v�������ʃO���b�h�ɕ\������J��������ݒ肵�܂��B</br>
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
			columns[SEARCH_COL_CustomerName].Header.Caption							= "���Ӑ�";
            columns[SEARCH_COL_CustomerName].Hidden = false;
            columns[SEARCH_COL_CustomerName].Width = 150;

            // 2011/7/25 XUJS ADD STA>>>>>>
            // ���� ��ݒ�
            columns[SEARCH_COL_BrgnGoodsGrpCode].Header.Caption = "��ٰ�ߺ���";
            columns[SEARCH_COL_BrgnGoodsGrpCode].Hidden = false;
            columns[SEARCH_COL_BrgnGoodsGrpCode].Width = 120;
            // 2011/7/25 XUJS ADD END<<<<<<

			// ���Ӑ�R�[�h ��ݒ�
            columns[SEARCH_COL_BrgnGoodsGrpTitle].Header.Caption = "�^�C�g��";
            columns[SEARCH_COL_BrgnGoodsGrpTitle].Hidden = false;
            columns[SEARCH_COL_BrgnGoodsGrpTitle].Format = customerFormat;

			// ���Ӑ�T�u�R�[�h ��ݒ�
            columns[SEARCH_COL_BrgnGoodsGrpComment].Header.Caption = "�R�����g";
            columns[SEARCH_COL_BrgnGoodsGrpComment].Hidden = false;


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
            /*
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
             */ 
		}

		/// <summary>
        /// ���������i�O���[�v�������ʔz�񁨉�ʊi�[����
		/// </summary>
        /// <param name="customerSearchRetArray">���������i�O���[�v�������ʔz��</param>
		/// <remarks>
        /// <br>Note       : ���������i�O���[�v�������ʔz��̏�����ʂɕ\�����܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2005.07.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        private void SetDisplayFormSearchRetArray(RecBgnGrpRet[] recBgnGrpRetArray)
		{
			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();

            if ((recBgnGrpRetArray == null) || (recBgnGrpRetArray.Length == 0))
			{
				// �f�[�^����
				//this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = MESSAGE_NONDATA; //DEL 2011/08/11
				this.MessageUnDisp_Timer.Enabled = true;
			}
			else
			{
                // ���������i�O���[�v�������ʃO���b�h�s�ݒ菈��
                foreach (RecBgnGrpRet recBgnGrpRet in recBgnGrpRetArray)
				{
					DataRow dataRow = null;
                    // ���������i�O���[�v�������ʃO���b�h�s�ݒ菈��
                    /*
                    // 2011/07/27 XUJS ADD STA>>>>>>
                    if (_praCustomerCode != -1)
                    {
                        if (recBgnGrpRet.CustomerCode < _praCustomerCode) continue;
                    }
                    // 2011/07/27 XUJS ADD END<<<<<<
                     */

                    // --- ADD 2015/03/19 Y.Wakita ---------->>>>>
                    if (0 < this._praCustomerCode)
                    {
                        // �񋟃f�[�^�̏ꍇ�A���[�U�[�f�[�^�Əd���`�F�b�N����
                        if (string.IsNullOrEmpty(recBgnGrpRet.InqOriginalEpCd) &&
                            string.IsNullOrEmpty(recBgnGrpRet.InqOriginalSecCd))
                        {
                            // �񋟃f�[�^�̏ꍇ
                            bool flg = false;
                            foreach (RecBgnGrpRet recBgnGrpRet2 in recBgnGrpRetArray)
                            {
                                if (string.IsNullOrEmpty(recBgnGrpRet2.InqOriginalEpCd) &&
                                    string.IsNullOrEmpty(recBgnGrpRet2.InqOriginalSecCd))
                                {
                                    // �񋟃f�[�^���m�̓`�F�b�N���Ȃ�
                                    continue;
                                }

                                if (recBgnGrpRet.BrgnGoodsGrpCode == recBgnGrpRet2.BrgnGoodsGrpCode)
                                {
                                    // �񋟃f�[�^�ƃ��[�U�[�f�[�^������̏ꍇ
                                    flg = true;
                                    break;
                                }
                            }

                            if (flg) continue;
                        }
                    }
                    // --- ADD 2015/03/19 Y.Wakita ----------<<<<<

                    dataRow = this.RecBgnGrpRetToDataRow(recBgnGrpRet, dataRow);
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
        /// ���������i�O���[�v��������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���������i�O���[�v�̌����������s���܂��B(�f���Q�[�g���񓯊����s���܂�)</br>
        /// <br>Programmer : 20073�@�� �B</br>
        /// <br>Date       : 2005.05.24</br>
        /// </remarks>
        private int SearchRecBgnGrpData()
        {
            RecBgnGrpAcs recBgnGrpAcs = new RecBgnGrpAcs();
            RecBgnGrpPara para = new RecBgnGrpPara();
            RecBgnGrpRet[] retArray;
            int status = 0;

            // �p�����[�^�𐶐�
            //para = this._extractionConditionInfo;

            // --- DEL 2015/03/05 Kaniwa Redmine#331 ---------->>>>>
            //para.InqOriginalEpCd = _enterpriseCode;
            // --- DEL 2015/03/05 Kaniwa Redmine#331 ----------<<<<<

            //���Ӑ�R�[�h���ݒ肳��Ă���ꍇ�́A���Ӑ�f�B�N�V���i������ڑ�������擾����B
            if (this._praCustomerCode > 0)
            {
                foreach (CustomerSearchRet customerSearchRet in _customerCodeList)
                {
                    if (customerSearchRet.LogicalDeleteCode == 0)
                    {
                        if (customerSearchRet.CustomerCode == this._praCustomerCode)
                        {
                            para.InqOriginalEpCd = customerSearchRet.CustomerEpCode;
                            para.InqOriginalSecCd = customerSearchRet.CustomerSecCode;
                        }
                    }
                }
            }

            //------ UPD 2015/03/11 ���I ----->>>>>>
            //if (this._guideType == GUIDETYPE_READONLY) 
            if ((this._guideType == GUIDETYPE_READONLY) & (para.InqOriginalEpCd.Trim() == string.Empty))
            //------ UPD 2015/03/11 ���I -----<<<<<<
            {
                // �����������s
                //------ UPD 2015/03/06 ���I ----->>>>>>
                //status = recBgnGrpAcs.Search(out retArray, para);
                status = recBgnGrpAcs.Search(out retArray, _enterpriseCode);
                //------ UPD 2015/03/06 ���I -----<<<<<<
            }
            else
            {
                // �����������s
                //------ UPD 2015/03/06 ���I ----->>>>>>
                //status = recBgnGrpAcs.Search(out retArray, new RecBgnGrpPara());
                status = recBgnGrpAcs.Search(out retArray, para);
                //------ UPD 2015/03/06 ���I -----<<<<<<
            }

            // ���������i�O���[�v�������ʔz�񁨉�ʊi�[����
            this.SetDisplayFormSearchRetArray(retArray);

            return status;
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
			//this._extractConditionList.Clear();
            //this._extractionConditionInfo = new CustomerSimpleSearchCndtn();

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
            RecBgnGrpRet recBgnGrpRet;
            int stauts = this.GetSelectInfo(out recBgnGrpRet);

			if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                if (this.RecBgnGrpSelect != null)
				{
                    this.RecBgnGrpSelect(this, recBgnGrpRet);
                    this.DialogResult = DialogResult.OK;
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
			_fs = new FileStream( "PMREC09030U.Log", FileMode.Append, FileAccess.Write, FileShare.Write );
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
		private void PMREC09030UA_Load(object sender, System.EventArgs e)
		{
            // Skin�ݒ�
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            
            // ��ʏ���������
			this.InitialSetting();

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			this.Initial_Timer.Enabled = true;
            if (this._customerCodeList.Count == 0)
            {
                // ���Ӑ���Ǎ�����
                this.ReadCustomerSearchRet();
            }

            // �ʏ탂�[�h�͓��Ӑ�R�[�h������
            if (this._guideType==GUIDETYPE_NORMAL)
            {
                // --- ADD 2015/03/09 Y.Wakita ---------->>>>>
                tNedit_CustomerCodeAllowZero.Enabled = false;
                uButton_CustomerGuide.Enabled = false;
                // --- ADD 2015/03/09 Y.Wakita ----------<<<<<
                
                if (this._customerCode != 0)
                {
                    tNedit_CustomerCodeAllowZero.Text = this._customerCode.ToString().PadLeft(8, '0');
                    //tNedit_CustomerCodeAllowZero.Enabled = false;   // --- DEL 2015/03/09 Y.Wakita

                    //------ ADD 2015/03/06 ���� ----->>>>>>
                    //uButton_CustomerGuide.Enabled = false;    // --- DEL 2015/03/09 Y.Wakita
                    this.CustomerCheck(this._customerCode);
                    //------ ADD 2015/03/06 ���� -----<<<<<<
                }
            }

            //if (this._customerCode != 0)
            //{
            //    tNedit_CustomerCodeAllowZero.Enabled = false;
            //}
        }

        /// <summary>
        /// ���Ӑ���Ǎ�����
        /// </summary>
        private void ReadCustomerSearchRet()
        {
            //this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            //ArrayList _customerCodeList = new ArrayList();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            _customerCodeList.Add(ret);

                        }
                    }
                }
            }
            catch
            {
                //this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
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

			// ���������i�O���[�v��������
            this.SearchRecBgnGrpData();

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
		private void PMREC09030UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

            //------ ADD 2015/03/11 ���I ----->>>>>>
            if (tNedit_CustomerCodeAllowZero.Enabled == false)
            {
                if (!e.Shift)
                {
                    if (e.KeyCode == Keys.Return)
                    {
                                Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

                                if (selectButton.SharedProps.Visible)
                                {
                                    // �I���{�^���N���b�N����
                                    this.SelectButtonClick();
                                }
                    }
                }
            }
            //------ ADD 2015/03/11 ���I -----<<<<<<
            
           
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
                            break;
                        }
                    case Keys.Up:
                        {
                            if (this.SearchResult_UGrid.ActiveRow != null)
                            {
                                if (this.SearchResult_UGrid.ActiveRow.Selected && this.SearchResult_UGrid.ActiveRow.Index == 0)
                                {
                                    if (e.KeyCode == Keys.Up)
                                    {
                                        //------ ADD 2015/03/11 ���I ----->>>>>>
                                        //if (this.GridKeyUpTopRow != null)
                                        if ((this.GridKeyUpTopRow != null) & (tNedit_CustomerCodeAllowZero.Enabled == true))
                                        //------ ADD 2015/03/11 ���I -----<<<<<<
                                        {
                                            this.GridKeyUpTopRow(this, new EventArgs());
                                            this.SearchResult_UGrid.ActiveRow.Selected = false;
                                            this.SearchResult_UGrid.ActiveRow = null;
                                            e.Handled = true;
                                        }
                                    }
                                }
                            }
                            if (this.SearchResult_UGrid.ActiveCell == null)
                            {
                                return;
                            }
                            //if (this.GridKeyUpTopRow != null)
                            //{
                            //    this.GridKeyUpTopRow(this, new EventArgs());
                            //    e.Handled = true;
                            //}
                            break;
                        }
                    // -------------------- ADD 2011/08/11 --------------->>>>>
                    case Keys.F3:
                        {
                            this.ActiveControl = this.tNedit_CustomerCodeAllowZero;
                            this.tNedit_CustomerCodeAllowZero.Focus();
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
            //MessageBox.Show("SearchResult_UGrid_MouseEnterElement");
            /*
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
             */ 
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
		private void PMREC09030UA_Shown(object sender, EventArgs e)
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
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            try
            {
                switch (e.PrevCtrl.Name)
                {
                    // �J�n�R�[�h ============================================ //
                    case "tNedit_CustomerCodeAllowZero":
                        {
                            int tempCode = _praCustomerCode;
                            if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() != string.Empty)
                            {
                                _praCustomerCode = Convert.ToInt32(this.tNedit_CustomerCodeAllowZero.DataText.Trim());
                                if (_praCustomerCode == 0)
                                {
                                    this.tNedit_CustomerCodeAllowZero.DataText = string.Empty;
                                    _praCustomerCode = -1;
                                }
                            }
                            //------ UPD 2015/03/11 ���I ----->>>>>>
                            else
                            {
                              _praCustomerCode = -1;
                            }
                            //------ UPD 2015/03/11 ���I -----<<<<<<

                            if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()) == false)
                            {
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            if (tempCode != _praCustomerCode)
                            {
                                this.Search();
                            }
                            break;
                        }
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
                            if (e.Key == Keys.Up)
                            {

                            }
                            break;
                        }
                }

                /*
                // ��������̓��e�Ɣ�r����
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    this.Search();
                }
                 */ 
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
        private void PMREC09030UA_KeyDown(object sender, KeyEventArgs e)
        {
            // ESC�L�[�����ɂ���ʕ��鏈��
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            //F5�L�[����
            if (e.KeyCode == Keys.F5)
            {
                this.Cursor = Cursors.WaitCursor;
                this._cusotmerGuideSelected = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // �t�H�[�J�X�ݒ�
                if (this._cusotmerGuideSelected == true)
                {
                    if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()))
                    {
                        //tEdit_BlGoodsCodeSt.Focus();
                        this.Search();
                        this.SearchResult_UGrid.Focus();
                    }
                }
            }
            //F6�L�[����
            if (e.KeyCode == Keys.F6)
            {

                //���Ӑ�R�[�h
                int tempCode = _praCustomerCode;
                if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() != string.Empty)
                {
                    _praCustomerCode = Convert.ToInt32(this.tNedit_CustomerCodeAllowZero.DataText.Trim());
                    if (_praCustomerCode == 0)
                    {
                        this.tNedit_CustomerCodeAllowZero.DataText = string.Empty;
                        _praCustomerCode = -1;
                    }
                    else
                        this.tNedit_CustomerCodeAllowZero.DataText = GetInputCode(tNedit_CustomerCodeAllowZero);
                }
                else
                {
                    _praCustomerCode = -1;
                }

                this.Search();
                this.SearchResult_UGrid.Focus();
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^��</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        /// <summary>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // �t�H�[�J�X�ݒ�
                if (this._cusotmerGuideSelected == true)
                {
                    if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()))
                    {
                        //tEdit_BlGoodsCodeSt.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�`�F�b�N����
        /// </summary>
        public bool CustomerCheck(int customerCode)
        {
            string errMsg;
            CustomerSearchRet retCustomerInfo;

            bool checkResult = this.CheckCustomer(customerCode, out errMsg, out retCustomerInfo);
            if (checkResult)
            {
                //���Ӑ�N���A
                this.tNedit_CustomerCodeAllowZero.Clear();
                this.uLabel_CustomerName.Text = "";

                //this._prevCusotmerCd = 0;
                if (customerCode == 0)
                {
                    this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //���Ӑ�R�[�h
                    this.uLabel_CustomerName.Text = "�S���Ӑ�"; //���Ӑ旪��
                }
                else if (retCustomerInfo != null)
                {
                    //this._prevCusotmerCd = customerCode;
                    this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //���Ӑ�R�[�h
                    this.uLabel_CustomerName.Text = retCustomerInfo.Snm; //���Ӑ旪��
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                //this.tNedit_CustomerCodeAllowZero.SetInt(this._prevCusotmerCd);
            }
            return checkResult;
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // ���Ӑ�R�[�h
            this.tNedit_CustomerCodeAllowZero.SetInt(customerSearchRet.CustomerCode);

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// ���Ӑ�`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="chkFlg">�K�{�`�F�b�N�敪(ture:�L,false:��)</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckCustomer(int customerCode, out string errMsg, out CustomerSearchRet retCustomerInfo)
        {
            retCustomerInfo = null;

            bool bRet = true;
            errMsg = string.Empty;

            if (customerCode == 0)
            {
                return true;
            }
            else
            {
                if (GetCustomerInfo(customerCode, out retCustomerInfo) == false )
                {
                    bRet = false;
                    errMsg = "���Ӑ悪���݂��܂���B";
                }
                else
                {
                    if (retCustomerInfo.OnlineKindDiv == 0       //�I�����C����ʋ敪
                     || retCustomerInfo.CustomerEpCode == null   //���Ӑ��ƃR�[�h
                     || retCustomerInfo.CustomerSecCode == null) //���Ӑ拒�_�R�[�h
                    {
                        // SCM��ƘA���f�[�^�Y���`�F�b�N
                        bRet = false;
                        errMsg = "�A�g���Ă��链�Ӑ�ł͂���܂���B";
                    }
                    else 
                    {
                        /*
                        foreach (ScmEpScCnt wk in this._scmEpScCntList)
                        {
                            if (!wk.LogicalDeleteCode.Equals(0)) continue;                              // �_���폜�F�L���ȊO
                            if (wk.DiscDivCd.Equals(1)) continue;                                       // �A������
                            if (wk.ScmCommMethod.Equals(0) && wk.PccUoeCommMethod.Equals(0)) continue;  // �ʐM����������

                            // �I�����C����ʋ敪�A���Ӑ��ƃR�[�h�A���Ӑ拒�_�R�[�h�̔���
                            if (retCustomerInfo.OnlineKindDiv == 10  // 10:SCM
                               && retCustomerInfo.CustomerEpCode.Trim().Equals(wk.CnectOriginalEpCd.Trim())
                               && retCustomerInfo.CustomerSecCode.Trim().Equals(wk.CnectOriginalSecCd.Trim())
                                 )
                            {
                         */
                                bRet = true;
//                                break;
                            //}
//                        }
                    }
                }
            }
            return bRet;
        }

        /// <summary>
        /// ���Ӑ���擾�����i���Ӑ�R�[�h���̓p���j
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool GetCustomerInfo(int customerCode, out CustomerSearchRet retCustomerInfo)
        {
            retCustomerInfo = null;
            foreach (CustomerSearchRet customerSearchRet in _customerCodeList)
            {
                if (customerSearchRet.LogicalDeleteCode == 0)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        retCustomerInfo = customerSearchRet;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// �ڍ׃O���b�h�ŏ�ʍs�A�v�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ڍ׃O���b�h�ŏ�ʍs�A�v�E�����ɔ������܂��B</br>      
        /// <br>Programmer : �{�{����</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks> 
        private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        {
            tNedit_CustomerCodeAllowZero.Focus();
            //e._prevControl = this.ActiveControl;
        }
    }
}
