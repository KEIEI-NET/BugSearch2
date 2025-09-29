using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Globarization;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Broadleaf.Library.Text;


namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R�������i�}�X�^�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R�������i�}�X�^�̃t�H�[���N���X�ł��B</br>
	/// <br>Programmer : �я���</br>
	/// <br>Date       : 2010.04.26</br>
    /// <br>UpDate Note: 2010.05.24 ���R </br>
    /// <br>RedMine#8049</br>
    /// <br>Update Note: 2010/06/01  22018 ��� ���b</br>
    /// <br>RedMine#8016 �^���������ʂ̃\�[�g���C�� </br>
    /// <br>Update Note: 2010/07/02 ���R</br>
    /// <br>RedMine#10103 �e��d�l�ύX�^��Q�Ή�</br>
    /// </remarks>
	public partial class PMJKN09011UA : Form
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
		private Control _prevControl = null;									// ���݂̃R���g���[��
		private Control _lastControl = null;									// �ȑO�̃R���g���[��
		private BeforeCarSearchBuffer _beforeCarSearchBuffer;
		private ColDisplayStatusList _colDisplayStatusList;	// ��\����ԃR���N�V�����N���X
		private DataSet _carSpecDataSet;

		private DataSet _detailDataSet;                     // ���׍s�f�[�^�Z�b�g
		private DataTable _detailDataTable;                 // ���׍s�f�[�^�e�[�u��

		private Dictionary<string, FreeSearchParts> _freeSearchPartsDty = null;       // ���׃f�[�^�o�b�t�@
        private Dictionary<string, int> _newLineRowIndexDic = null;          // ���אV�K�s�o�b�t�@
		private Hashtable _upperBerth; // ��i���ڃe�[�u��
		private Hashtable _lowerBerth; // ���i���ڃe�[�u��

		private FreeSearchPartsAcs _freeSearchPartsAcs;                                 // ���R�������i�}�X�^ �A�N�Z�X�N���X
		private PMKEN01010E.CarModelInfoDataTable _carModelInfoDataTable;               // �^���f�[�^
        private PMKEN01010E.CarModelInfoDataTable _selectCarModelInfoDataTable;         // �I�����ꂽ�̌^���f�[�^
		private PMKEN01010E _carInfo;                                                   // �ԗ����

		private MakerAcs _makerAcs;
		private BLGoodsCdAcs _bLGoodsCdAcs;

        // ��r�p�ޕ�
        private string _categoryNo = "";
        // ��r�p�Ԏ�
        private string _fullCarType = "";
        // ��r�p�^��
        private string _designationNo = "";
        // ��r�p�����ԍ�
        private int _searchNo = 0;
		// �O���[�h���X�g
		private ValueList _modelGradeValueList;
		// �{�f�B���X�g
		private ValueList _bodyNameValueList;
		// �h�A���X�g
		private ValueList _doorCountValueList;
		// �G���W�����X�g
		private ValueList _engineModelValueList;
		// �r�C�ʃ��X�g
		private ValueList _engineDisplaceValueList;
		// E�敪���X�g
		private ValueList _eDivValueList;
		// �~�b�V�������X�g
		private ValueList _transmissionValueList;
		// �쓮�`�����X�g
		private ValueList _wheelDriveMethodValueList;
		// �V�t�g���X�g
		private ValueList _shiftValueList;

		// ���[�J�[�R�[�h
		private int _makerCode = 0;
		// �Ԏ�R�[�h
		private int _modelCode = 0;
		// �Ԏ�T�u�R�[�h
		private int _modelSubCode = 0;
		// �^���i�t���^�j
		private string _fullModel = String.Empty;
        private int _activeRowIndex = 0;
        private int _endSearchGoodsNo = 0;
        private int _beforeRecordNum = 0;
        private int _singleIndex = 0;

        private bool goodsSearchFlg = false; //add 2010/06/21 by gejun for RedMine #10103
        private int focusMoveType = 0; //add 2010/06/22 by gejun for RedMine #10103
        private bool existCheckFlg = false; //add 2010/06/24 by gejun for RedMine #10103
        private Hashtable goodsNoComp = new Hashtable();    //add 2010/06/24 by gejun for RedMine #10103
        private bool updateModeFlg = false; // ADD 2010/07/01 -------->>>                    
    	# endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		# region Const Members

		private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
		private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;

		// ���Y�N���t�H�[�}�b�g
		private const string FORMAT_CREATEYEAR = "####.## - ####.##";
		// ���Y�ԑ�ԍ��t�H�[�}�b�g
		private const string FORMAT_CREATECARNO = "nnnnnnnn - nnnnnnnn";
		// �f�t�H���g�s��
		private const int DEFAULT_ROW_COUNT = 1;
		// Max�s��
		private const int MAX_ROW_COUNT = 9999;
		// �Ԏ�K�C�h
		private const string ctGUIDE_NAME_ModelFullGuide = "ModelFullGuide";
		// ���[�J�[�K�C�h
		private const string ctGUIDE_NAME_MakerGuide = "MakerGuide";
		// BL�R�[�h�K�C�h
		private const string ctGUIDE_NAME_BlCodeGuide = "BlCodeGuide";
		// ���o�^
		private const string un_INSERT = "���o�^";

		// �f�[�^�X�e�[�^�X:�@0 �����C
		private const int DATASTATUSCODE_0 = 0;
		// �f�[�^�X�e�[�^�X:�@1 ���C
		private const int DATASTATUSCODE_1 = 1;
		// �f�[�^�X�e�[�^�X:�@2 �V�K�ǉ��f�[�^
		private const int DATASTATUSCODE_2 = 2;
		// �f�[�^�X�e�[�^�X:�@3 �폜����f�[�^
		private const int DATASTATUSCODE_3 = 3;
		// �f�[�^�X�e�[�^�X:�@4 DB���݂��Ȃ��A���폜����f�[�^
		private const int DATASTATUSCODE_4 = 4;
		# endregion
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// ���R�������i�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
		/// </summary>
		public PMJKN09011UA()
		{
			InitializeComponent();
			this._carSpecDataSet = new DataSet();
			this._detailDataSet = new DataSet();
			this._upperBerth = new Hashtable();
			this._lowerBerth = new Hashtable();
			this._controlScreenSkin = new ControlScreenSkin();
			this._carModelInfoDataTable = new PMKEN01010E.CarModelInfoDataTable();
            this._selectCarModelInfoDataTable = new PMKEN01010E.CarModelInfoDataTable();
			this._imageList16 = IconResourceManagement.ImageList16;
			this._freeSearchPartsAcs = new FreeSearchPartsAcs();
			this._freeSearchPartsDty = new Dictionary<string, FreeSearchParts>();
            this._newLineRowIndexDic = new Dictionary<string, int>();
			this._makerAcs = new MakerAcs();
			this._bLGoodsCdAcs = new BLGoodsCdAcs();
			this._freeSearchPartsAcs.Owner = this;
			this._modelGradeValueList = new ValueList();
			this._bodyNameValueList = new ValueList();
			this._doorCountValueList = new ValueList();
			this._engineModelValueList = new ValueList();
			this._engineDisplaceValueList = new ValueList();
			this._eDivValueList = new ValueList();
			this._transmissionValueList = new ValueList();
			this._wheelDriveMethodValueList = new ValueList();
			this._shiftValueList = new ValueList();
		}
		#endregion

		# region private field
		private ImageList _imageList16 = null;
		// ��ʃC���[�W�R���g���[�����i
		private ControlScreenSkin _controlScreenSkin;
		# endregion

		# region  �t�H�[�����[�h
		/// <summary>
		/// ��ʂ̏���������
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>		
		/// <br>Note		: ��ʂ̏��������s���B</br>
		/// <br>Programmer	: �я���</br>	
		/// <br>Date		: 2010/04/26</br>
		/// </remarks>
		private void PMJKN09011UA_Load(object sender, EventArgs e)
		{
			// ��ʃC���[�W���� 
			// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.LoadSkin();

			// ��ʃX�L���ύX
			this._controlScreenSkin.SettingScreenSkin(this);

			// �������f�[�^�\�[�X�ǉ�
			PMJKN09011UB.DataSetColumnConstruction(ref this._carSpecDataSet);
            DataRow row = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].NewRow();
            this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Add(row);
			this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].DefaultView;
            this.SetCarSpecGridColWidth(this.ultraGrid_CarSpec.Rows[0].Band); //ADD 2009/05/20 GEJUN FOR REDMINE#8049
            this.ultraGrid_CarSpec.Rows[0].Activation = Activation.Disabled;

			//�c�[���o�[�����ݒ菈��
			this.ToolBarInitilSetting();

			// �{�^�������ݒ菈��
			this.ButtonInitialSetting();

			this.tComboEditor_GoodsNoFuzzy.SelectedIndex = 0;

			// ���׃f�[�^�e�[�u���̏����ݒ���s���܂��B
			PMJKN09011UC detail = new PMJKN09011UC();
			detail.DataSetColumnConstruction(ref this._detailDataSet);
			this.DetailRowInitialSetting(DEFAULT_ROW_COUNT);

			// �O���b�h�񏉊��ݒ菈��
			this.InitialSettingGridCol();

			// �I��
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
			// �N���A
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
			// �ŐV���
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
			// �ۑ�
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
			// ����
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
			// �s�폜
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
            // �S�폜
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
			// �K�C�h
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
			// ���p�o�^
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
		}
		# endregion

		#region �c�[���o�[�����ݒ菈��
		/// <summary>
		/// �c�[���o�[�����ݒ菈��
		/// </summary>
		private void ToolBarInitilSetting()
		{
			// ���O�C�����_����
			this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionName"].SharedProps.Caption = GetOwnSectionName(LoginInfoAcquisition.Employee.BelongSectionCode); ;
			// ���O�C���S���Җ���
			this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
		}
		#endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		#region Public Methods

		/// <summary>
		/// �����_���̎擾������
		/// </summary>
		/// <param name="belongSectionCode">�����_�R�[�h</param>
		/// <returns>�����_����</returns>
		public string GetOwnSectionName(string belongSectionCode)
		{
			// �����_�̎擾
			string ownSectionName = string.Empty;
			SecInfoSet secInfoSet;
			SecInfoAcs secInfoAcs = new SecInfoAcs();
			secInfoAcs.GetSecInfo(belongSectionCode, out secInfoSet);
			if (secInfoSet != null)
			{
				// �����_���̂̕ۑ�
				ownSectionName = secInfoSet.SectionGuideNm;
			}

			return ownSectionName;
		}

		/// <summary>
		/// ���׃f�[�^�e�[�u���̏����ݒ���s���܂��B
		/// </summary>
		/// <param name="defaultRowCount">�����s��</param>
		public void DetailRowInitialSetting(int defaultRowCount)
		{
			if (this._detailDataTable != null)
				this._detailDataTable.Clear();
			if (this._freeSearchPartsDty != null)
				this._freeSearchPartsDty.Clear();

            //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
            if(this._newLineRowIndexDic != null)
                this._newLineRowIndexDic.Clear();
            //ADD END 2009/05/24 GEJUN FOR REDMINE#8049

			this._detailDataTable = this._detailDataSet.Tables[PMJKN09011UC.TBL_DETAILVIEW];

			for (int i = 1; i <= defaultRowCount; i++)
			{
				string guidStr = Guid.NewGuid().ToString().Replace("-", "");

				DataRow row = this._detailDataTable.NewRow();
				row[PMJKN09011UC.COL_NO_TITLE] = i;
				row[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = guidStr;

				this._detailDataTable.Rows.Add(row);
                //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
                FreeSearchParts freeSearchParts = new FreeSearchParts();
                // ���R�������i�ŗL�ԍ�
                freeSearchParts.FreSrchPrtPropNo = guidStr;
                // ��ƃR�[�h
                freeSearchParts.EnterpriseCode = this._enterpriseCode;
                // ���[�J�[�R�[�h
                freeSearchParts.MakerCode = this._makerCode;
                // �Ԏ�R�[�h
                freeSearchParts.ModelCode = this._modelCode;
                // �Ԏ�T�u�R�[�h
                freeSearchParts.ModelSubCode = this._modelSubCode;
                // �^���i�t���^�j
                freeSearchParts.FullModel = this._fullModel;
                // �f�[�^�X�e�[�^�X:�@2 �V�K�ǉ��f�[�^
                freeSearchParts.DataStatus = DATASTATUSCODE_2;
                if (!_freeSearchPartsDty.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                    this._freeSearchPartsDty.Add(freeSearchParts.FreSrchPrtPropNo, freeSearchParts);

                if(!this._newLineRowIndexDic.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                    this._newLineRowIndexDic.Add(freeSearchParts.FreSrchPrtPropNo, 0);
                //ADD END 2009/05/24 GEJUN FOR REDMINE#8049
			}
		}
		#endregion

		// ===================================================================================== //
		// �e�R���g���[���C�x���g����
		// ===================================================================================== //
		#region Control Event Methods
        //ADD START 2009/05/20 GEJUN FOR REDMINE#8049----->>>
        /// <summary>
        /// �������O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <param name="band">�������O���b�h�o���h</param>
        private void SetCarSpecGridColWidth(UltraGridBand band)
        {
            // �O���[�h 20����
            band.Columns[0].Width = 170;
            // �{�f�B 10����
            band.Columns[1].Width = 90;
            // �h�A 2����
            band.Columns[2].Width = 40;
            // �G���W�� 12����
            band.Columns[3].Width = 104;
            // �r�C�� 8����
            band.Columns[4].Width = 76;
            // E�敪 8����
            band.Columns[5].Width = 76;
            // �~�b�V���� 8����
            band.Columns[6].Width = 76;
            // �쓮�`�� 15����
            band.Columns[7].Width = 130;
            // �V�t�g 8����
            band.Columns[8].Width = 76;
        }
        //ADD END  2009/05/20 GEJUN FOR REDMINE#8049----<<<
		/// <summary>
		/// �O���b�h�񏉊��ݒ菈��tptp
		/// </summary>
		private void InitialSettingGridCol()
		{
            // add start 2010/06/21 by gejun for RedMine #10103
            // �񕝂̎����������@(�������f�[�^)
            this.ultraGrid_CarSpec.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.ultraGrid_CarSpec.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.ultraGrid_CarSpec.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid_CarSpec.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // add end 2010/06/21 by gejun for RedMine #10103   

			this.uGrid_Details.DataSource = this._detailDataTable.DefaultView;

			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
			if (editBand == null) return;

			editBand.UseRowLayout = true;
			// ���Y�N��
			EmbeddableEditorBase editorPty = getEditor(FORMAT_CREATEYEAR);
			// ���Y�ԑ�ԍ�
			EmbeddableEditorBase editorPfn = getEditor(FORMAT_CREATECARNO);

            // �񕝂̎����������@
            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_Details.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
          
            // ���Y�N��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATEYEAR_TITLE].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATEYEAR_TITLE].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            // ���Y�ԑ�ԍ�
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATECARNO_TITLE].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATECARNO_TITLE].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

			// ��\����ԃR���N�V�����N���X���C���X�^���X��
			this._colDisplayStatusList = new ColDisplayStatusList();

			foreach (ColDisplayStatusExp colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (this.uGrid_Details.DisplayLayout.Bands[0].Columns.Exists(colDisplayStatus.Key))
				{
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.Reset();

					System.Drawing.Size sizeHeader = new Size();
					System.Drawing.Size sizeCell = new Size();
					this.uGrid_Details.DisplayLayout.Bands[0].RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
					this.uGrid_Details.DisplayLayout.Bands[0].RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

					sizeCell.Height = 22;
					sizeCell.Width = colDisplayStatus.Width;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
					sizeHeader.Height = 20;
					sizeHeader.Width = colDisplayStatus.Width;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.LabelSpan = colDisplayStatus.LabelSpan;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.OriginX = colDisplayStatus.OriginX;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.OriginY = colDisplayStatus.OriginY;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.SpanX = colDisplayStatus.SpanX;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.SpanY = colDisplayStatus.SpanY;

					if (colDisplayStatus.OriginY == 0)
					{
						// ��i�e�[�u��
						this._upperBerth[colDisplayStatus.Key] = colDisplayStatus.MoveLineKeyName;
					}
					else
					{
						// ���i�e�[�u��
						this._lowerBerth[colDisplayStatus.Key] = colDisplayStatus.MoveLineKeyName;
					}
				}
			}
			//---------------------------------------------------------------------
			// CellAppearance�ݒ�
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;            // No.
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        // �i��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MAKER_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;         // ���[�J�[�R�[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BLCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;        // BL�R�[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        // �i��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_PARTSQTY_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      // QTY
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      // �W�����i
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATEYEAR_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;   // ���Y�N��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATECARNO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;  // ���Y�ԑ�ԍ�

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MODELGRADENM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;     // �O���[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BODYNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;         // �{�f�B
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_DOORCOUNT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;       // �h�A
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;    // �G���W��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left; // �r�C��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_EDIVNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;           // E�敪
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;   // �~�b�V����
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;// �쓮�`��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_SHIFTNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;          // �V�t�g
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ADDICARSPEC_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;      // �E�v

			//---------------------------------------------------------------------
			// Color�ݒ�
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;

			//---------------------------------------------------------------------
			// Editor�ݒ�
			//---------------------------------------------------------------------
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATEYEAR_TITLE].Editor = editorPty;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATECARNO_TITLE].Editor = editorPfn;

			//---------------------------------------------------------------------
			// ���͋��ݒ�
			//---------------------------------------------------------------------
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;              // No
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNM_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;         // �i��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;        // �W�����i
           
            //---------------------------------------------------------------------
			// Style�ݒ�
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;       // �i��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MAKER_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;          // ���[�J�[�R�[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BLCODE_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // BL�R�[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_PARTSQTY_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;       // QTY
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;       // �W�����i

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MODELGRADENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // �O���[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BODYNAME_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // �{�f�B
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_DOORCOUNT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // �h�A
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // �G���W��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; // �r�C��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_EDIVNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;           // E�敪
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // �~�b�V����
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;// �쓮�`��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_SHIFTNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;          // �V�t�g
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // �E�v


			//---------------------------------------------------------------------
			// �t�H�[�}�b�g�ݒ�
			//---------------------------------------------------------------------        
			string moneyFormat = "#,##0;-#,##0;''";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MAKER_TITLE].Format = "0##0;-0##0;''";       // ���[�J�[�R�[�h
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BLCODE_TITLE].Format = "0###0;-0###0;''";      // BL�R�[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].Format = moneyFormat;   // �W�����i

			//---------------------------------------------------------------------
			// MaxLength�ݒ�
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNO_TITLE].MaxLength = 24;       // �i��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MAKER_TITLE].MaxLength = 4;          // ���[�J�[�R�[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BLCODE_TITLE].MaxLength = 5;         // BL�R�[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNM_TITLE].MaxLength = 40;       // �i��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_PARTSQTY_TITLE].MaxLength = 2;       // QTY
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].MaxLength = 9;       // �W�����i

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MODELGRADENM_TITLE].MaxLength = 20;    // �O���[�h
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BODYNAME_TITLE].MaxLength = 10;        // �{�f�B
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_DOORCOUNT_TITLE].MaxLength = 2;        // �h�A
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].MaxLength = 12;   // �G���W��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].MaxLength = 8; // �r�C��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_EDIVNM_TITLE].MaxLength = 8;           // E�敪
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].MaxLength = 8;   // �~�b�V����
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].MaxLength = 15;// �쓮�`��
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_SHIFTNM_TITLE].MaxLength = 8;          // �V�t�g
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ADDICARSPEC_TITLE].MaxLength = 60;     // �E�v

			//---------------------------------------------------------------------
			// Hidden�ݒ�
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Hidden = true;  // ���R�������i�ŗL�ԍ�
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_FULLMODELGROUP_TITLE].Hidden = true;    // �^���O���[�v�敪

			// ���׃O���b�h�\���ݒ菈��
			SettingDetailsGridCol();

		}

		/// <summary>
		/// �Ԏ�K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
		{
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            MakerAcs makerAcs = new MakerAcs();
			ModelNameU modelNameU;
            ModelNameU modelNameU2;
            MakerUMnt makerUMnt;
			int makerCode = this.tNedit_MakerCode.GetInt();

			int status = modelNameUAcs.ExecuteGuid2(makerCode, this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt(),
				this._enterpriseCode, out modelNameU);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tNedit_MakerCode.SetInt(modelNameU.MakerCode);
				this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
				this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                // modify start 2010/06/24 by gejun for RedMine #10103
                if ("".Equals(modelNameU.ModelFullName.Trim()))
                {
                    if (modelNameU.ModelCode != 0)
                    {
                        status = modelNameUAcs.Read(out modelNameU2, this._enterpriseCode, modelNameU.MakerCode, modelNameU.ModelCode, modelNameU.ModelSubCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            this.tEdit_ModelFullName.Text = modelNameU2.ModelFullName;
                    }
                    else
                    {
                        status = makerAcs.Read(out makerUMnt, this._enterpriseCode, modelNameU.MakerCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            this.tEdit_ModelFullName.Text = makerUMnt.MakerName;
                    }
                }
                else
				    this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
                // modify end 2010/06/24 by gejun for RedMine #10103
				// ���̍��ڂփt�H�[�J�X�ړ�
                ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_ModelFullGuide, this.tEdit_FullModel);
				if (changeFocusEventArgs.NextCtrl != null)
				{
					changeFocusEventArgs.NextCtrl.Focus();
				}
			}
		}

		/// <summary>
		/// tNedit_ModelDesignationNo_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_ModelDesignationNo_ValueChanged(object sender, EventArgs e)
		{
            string modelDesignationNo = this.tNedit_ModelDesignationNo.Text;

            if (string.IsNullOrEmpty(modelDesignationNo))
            {
                this.tNedit_CategoryNo.Enabled = false;
                this.tNedit_CategoryNo.Clear();
            }
            else
            {
                this.tNedit_CategoryNo.Enabled = true;
                if (this.tNedit_ModelDesignationNo.ExtEdit.Column <= modelDesignationNo.Length)
                {
                    this.tNedit_CategoryNo.Focus();
                }
            }
		}

        // ADD 2010/07/01------------>>>
        /// <summary>						
        /// �^���L�[�_�E���C�x���g						
        /// </summary>						
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>						
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>						
        /// <remarks>						
        /// <br>Note		: �^���L�[�_�E�����A�������s���܂��B</br>				
        /// <br>Programmer	: gejun</br>					
        /// <br>Date		: 2010.07.01</br>				
        /// </remarks>	
        private void tNedit_ModelDesignationNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.tNedit_MakerCode.Focus();
            }
        }
        // ADD 2010/07/01------------>>>

        /// <summary>						
        /// �O���b�h�L�[�_�E���C�x���g						
        /// </summary>						
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>						
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>						
        /// <remarks>						
        /// <br>Note		: �O���b�h�L�[�_�E�����A�������s���܂��B</br>				
        /// <br>Programmer	: gejun</br>					
        /// <br>Date		: 2010.05.19</br>				
        /// </remarks>	
        private void ultraGrid_CarSpec_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    // �����ԍ��Ƀt�H�[�J�X�Ɉړ�
                    tNedit_SearchGoodsNo.Focus();
                    break;
                case Keys.Up:
                    // �^���Ƀt�H�[�J�X�Ɉړ�
                    tEdit_FullModel.Focus();
                    break;
            }
        }

		/// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
			this._prevControl = e.PrevCtrl;
            this._lastControl = e.NextCtrl;

			// PrevCtrl�ݒ�
			Control prevCtrl = new Control();
			if (e.PrevCtrl is Control) prevCtrl = (Control)e.PrevCtrl;

			Control nextCtrl = new Control();
			if (e.NextCtrl is Control) nextCtrl = (Control)e.NextCtrl;

            // �`�F�b�N�p����
            int checkRst = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // add 2010/06/24 by gejun for RedMine #10103

			#region prevCtrl
			switch (prevCtrl.Name)
			{
				#region �^���w��
				//�^���w��
				case "tNedit_ModelDesignationNo":
					{
						if (!string.IsNullOrEmpty(this.tNedit_ModelDesignationNo.Text)
                            && string.IsNullOrEmpty(this.tNedit_CategoryNo.Text))
						{
                            if (!nextCtrl.Name.Equals("tNedit_CategoryNo") && !"_Form1_Toolbars_Dock_Area_Top".Equals(nextCtrl.Name))
                            {
                                DialogResult dialogResult = TMsgDisp.Show(
                                                   this,
                                                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                   this.Name,
                                                   "�ޕʋ敪����͂��Ă��������B",
                                                   0,
                                                   MessageBoxButtons.OK,
                                                   MessageBoxDefaultButton.Button1);
                                nextCtrl = e.NextCtrl = this.tNedit_CategoryNo;
                            }
						}
						break;
					}
				#endregion
                #region �ޕʋ敪�ԍ�
                //---------------------------------------------------------------
				// �ޕʋ敪�ԍ�
				//---------------------------------------------------------------
				case "tNedit_CategoryNo":
					{

						if ((this.tNedit_ModelDesignationNo.GetInt() != 0) &&
							(this.tNedit_CategoryNo.GetInt() != 0))
						{
							CarSearchCondition con = new CarSearchCondition();
							con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
							con.CategoryNo = this.tNedit_CategoryNo.GetInt();
							con.Type = CarSearchType.csCategory;
                            con.FreeSearchModelOnly = false;
                            //int result = this.CarSearch(con); // del 2010/06/24 by gejun for RedMine #10103
                            checkRst = this.CarSearch(con); // add 2010/06/24 by gejun for RedMine #10103
							//switch ((ConstantManagement.MethodResult)result)// del 2010/06/24 by gejun for RedMine #10103
							switch ((ConstantManagement.MethodResult)checkRst)// add 2010/06/24 by gejun for RedMine #10103
							{
								case ConstantManagement.MethodResult.ctFNC_CANCEL:
									e.NextCtrl = this.tNedit_ModelDesignationNo;
									this.tNedit_ModelDesignationNo.Clear();
									this.tNedit_CategoryNo.Clear();
                                    this._beforeRecordNum = 0;
									break;
								case ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    nextCtrl = tNedit_SearchGoodsNo;
                                    e.NextCtrl = null;
                                    this.tNedit_SearchGoodsNo.Focus();
                                    this._beforeRecordNum = 1;
                                    this.SettingDetailsGridCol();
									break;
								case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
									DialogResult dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
                                        "�Y���f�[�^������܂���B",
										0,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                                    if (dialogResult == DialogResult.OK)
									{
                                        this.tNedit_ModelDesignationNo.Focus();
										this.tNedit_ModelDesignationNo.Clear();
										this.tNedit_CategoryNo.Clear();
                                        nextCtrl = e.NextCtrl = null;
									}
                                    this._beforeRecordNum = 0;
									break;
								default:
									break;
							}
						}
						else if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() == 0))
						{
                            if(!"_Form1_Toolbars_Dock_Area_Top".Equals(nextCtrl.Name))
                            {
							    DialogResult dialogResult = TMsgDisp.Show(
									       this,
									       emErrorLevel.ERR_LEVEL_EXCLAMATION,
									       this.Name,
									       "�^���w����͎��́A�ޕʋ敪�͕K�{���͂ł��B",
									       0,
                                           MessageBoxButtons.OK,
									       MessageBoxDefaultButton.Button1);
                                nextCtrl = e.NextCtrl = this.tNedit_CategoryNo;
                            }
						}
						else
						{
							prevCtrl = this.tNedit_ModelDesignationNo;
							break;
						}
                        // ��r�p���ۑ�

                        // ��r�p�ޕ�
                        this._categoryNo = this.tNedit_ModelDesignationNo.Text + this.tNedit_CategoryNo.Text;
                        // ��r�p�Ԏ�
                        this._fullCarType = this.tNedit_MakerCode.Text + this.tNedit_ModelCode.Text + this.tNedit_ModelSubCode.Text;
                        // ��r�p�^��
                        this. _designationNo = this.tEdit_FullModel.Text;
                        // ��r�p�����ԍ�
                        this._searchNo = this.tNedit_SearchGoodsNo.GetInt();
						prevCtrl = this.tNedit_ModelDesignationNo;
						break;
					}
				#endregion

				#region �^���^���f���v���[�g
				//---------------------------------------------------------------
				// �^���^���f���v���[�g
				//---------------------------------------------------------------
				case "tEdit_FullModel":
					{

						//---------------------------------------------------------------
						// �^������
						//---------------------------------------------------------------
						if ((!string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())))
						{
							this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();
							CarSearchCondition con = new CarSearchCondition();
							con.CarModel.FullModel = this.tEdit_FullModel.Text;
							con.Type = CarSearchType.csModel;
                            con.FreeSearchModelOnly = false;
                            //int result = this.CarSearch(con); // del 2010/06/24 by gejun for RedMine #10103
                            checkRst = this.CarSearch(con); // add 2010/06/24 by gejun for RedMine #10103
							//switch ((ConstantManagement.MethodResult)result)// del 2010/06/24 by gejun for RedMine #10103
							switch ((ConstantManagement.MethodResult)checkRst)// add 2010/06/24 by gejun for RedMine #10103
							{
								case ConstantManagement.MethodResult.ctFNC_CANCEL:
									e.NextCtrl = e.PrevCtrl;
                                    //this.tEdit_FullModel.Clear();// del 2010/06/24 by gejun for RedMine #10103
                                    this.tEdit_FullModel.Text = this._designationNo;// add 2010/06/24 by gejun for RedMine #10103
									break;
								case ConstantManagement.MethodResult.ctFNC_NORMAL:
									nextCtrl = tNedit_SearchGoodsNo;
									e.NextCtrl = null;
									this.tNedit_SearchGoodsNo.Focus();
									break;
								case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                    TMsgDisp.Show(this,
                                       emErrorLevel.ERR_LEVEL_INFO,
                                       this.Name,
                                       "�Y���f�[�^������܂���B",
                                       -1,
                                       MessageBoxButtons.OK);
                                    this.tEdit_FullModel.Text = this._designationNo;
                                    e.NextCtrl = tEdit_FullModel;
									
									break;
                                case ConstantManagement.MethodResult.ctFNC_DO_END:
                                    //DEL 2010/07/01
                                    //if (Keys.Enter == e.Key || Keys.Tab == e.Key)
                                    //{
                                    //    nextCtrl = tNedit_SearchGoodsNo;
                                    //    e.NextCtrl = null;
                                    //    this.tNedit_SearchGoodsNo.Focus();
                                    //}
                                    //DEL 2010/07/01
                                    //�@�t�H�[�J�X�ݒ�̂���
                                    checkRst = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; //ADD 2010/07/01
                                    break;
								default:
									break;
							}
						}
                        // add start 2010/06/24 by gejun for RedMine #10103
                        if ((ConstantManagement.MethodResult)checkRst == ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                        // end add 2010/06/24 by gejun for RedMine #10103
					        switch (e.Key)
					        {
						        case Keys.Down:
                                case Keys.Right:
                                case Keys.Enter:
                                    e.NextCtrl = this.tNedit_SearchGoodsNo;
							        break;
						        case Keys.Up:
                                    e.NextCtrl = this.tNedit_MakerCode;
							        break;
                                case Keys.Tab:
                                    if (e.ShiftKey)
                                        e.NextCtrl = this.uButton_ModelFullGuide;
                                    else
                                        e.NextCtrl = this.tNedit_SearchGoodsNo;
                                    break;
						        default:
							        break;
					        }
                        }// add 2010/06/24 by gejun for RedMine #10103
                        // ��r�p���ۑ�

                        // ��r�p�ޕ�
                        this._categoryNo = this.tNedit_ModelDesignationNo.Text + this.tNedit_CategoryNo.Text;
                        // ��r�p�Ԏ�
                        this._fullCarType = this.tNedit_MakerCode.Text + this.tNedit_ModelCode.Text + this.tNedit_ModelSubCode.Text;
                        // ��r�p�^��
                        this._designationNo = this.tEdit_FullModel.Text;
                        // ��r�p�����ԍ�
                        this._searchNo = this.tNedit_SearchGoodsNo.GetInt();
						break;
					}
				#endregion
                // ADD 2010/07/01------------------------>>>
                #region �Ԏ�R�[�h
                case "tNedit_ModelCode":
                    {
                        if(e.Key == Keys.Up)
                            e.NextCtrl = nextCtrl = this.tNedit_ModelDesignationNo;
                        break;
                    }
                #endregion  
                case "uButton_CmpltGoodsMakerGuide":
                case "tNedit_BlCd":
                case "BlCdGuide":
                    {
                        if (e.Key == Keys.Up)
                            e.NextCtrl = nextCtrl = this.tNedit_SearchGoodsNo;
                        // ADD 2010/07/02------------------------>>>
                        if ("BlCdGuide".Equals(prevCtrl.Name) && e.Key == Keys.Down)
                            e.NextCtrl = nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                        // ADD 2010/07/02------------------------>>>
                        break;
                    }
                // ADD 2010/07/01------------------------>>>
                #region �i�ԏ���
                case "tComboEditor_GoodsNoFuzzy":
                    {
                        //if (e.Key == Keys.Enter || e.Key == Keys.Tab) //del 2010/06/29 by gejun for RedMine #10103
                        if (e.Key == Keys.Enter || e.Key == Keys.Tab || e.Key == Keys.Down) //add 2010/06/29 by gejun for RedMine #10103
                        {
                            // �����iR)�̎��s
                            //this.Search();// del 2010/06/24 by gejun for RedMine #10103
                            // add start 2010/06/24 by gejun for RedMine #10103
                            if ((int)ConstantManagement.MethodResult.ctFNC_NORMAL != this.Search())
                            {
                                 if (string.IsNullOrEmpty(tEdit_FullModel.Text.Trim()))
                                     nextCtrl = e.NextCtrl = tEdit_FullModel;
                                 else if (string.IsNullOrEmpty(tNedit_MakerCode.Text.Trim()))
                                     nextCtrl = e.NextCtrl = tNedit_MakerCode;
                            }
                            // add end  2010/06/24 by gejun for RedMine #10103
                        }
                        break;
                    }
                #endregion
                // Add 2010/06/30------------------------>>>
                #region �i��
                case "tEdit_GoodsNo":
                    {
                        if (e.Key == Keys.Down)
                        {
                            // �����iR)�̎��s
                            if ((int)ConstantManagement.MethodResult.ctFNC_NORMAL != this.Search())
                            {
                                if (string.IsNullOrEmpty(tEdit_FullModel.Text.Trim()))
                                    nextCtrl = e.NextCtrl = tEdit_FullModel;
                                else if (string.IsNullOrEmpty(tNedit_MakerCode.Text.Trim()))
                                    nextCtrl = e.NextCtrl = tNedit_MakerCode;
                            }
                        }
                        break;
                    }
                #endregion
                // Add 2010/06/30------------------------>>>
                #region �����ԍ�
                case "tNedit_SearchGoodsNo":
                    {
                        if (e.ShiftKey || e.Key == Keys.Up)
                            e.NextCtrl = this.tEdit_FullModel;

                        if (this._searchNo == this.tNedit_SearchGoodsNo.GetInt())
                            break;

                        if (!this.tNedit_SearchGoodsNo_TextChanged())
                        {
                            e.NextCtrl = null;
                        }

                        this._searchNo = this.tNedit_SearchGoodsNo.GetInt();
                        break;
                    }
                #endregion
                #region uGrid_Details
                case "uGrid_Details":
					{
						if (!e.NextCtrl.Name.Equals("_Form1_Toolbars_Dock_Area_Top"))
						{
							e.NextCtrl = null;
						}

                        this._activeRowIndex = this.GetActiveRowIndex();

						// ���ו��Ƀt�H�[�J�X�L��(GridActive)
						if (this.uGrid_Details.ActiveCell != null)
						{
							int rowIndex = uGrid_Details.ActiveCell.Row.Index;
							int colIndex = uGrid_Details.ActiveCell.Column.Index;
							string colKey = uGrid_Details.ActiveCell.Column.Key;
                            string colKeyNext = uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Column.Key;

							if (e.Key == Keys.Return || e.Key == Keys.Tab)
							{
								// �i��
								if (uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_GOODSNO_TITLE && String.IsNullOrEmpty(uGrid_Details.ActiveCell.Text))
								{
                                    nextCtrl = e.NextCtrl = null;            //ADD 2009/05/24 GEJUN FOR REDMINE#8049
									break;
								}
                                //del start 2010/06/21 by gejun for RedMine #10103
                                //// ���[�J�[
                                //if (uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE && String.IsNullOrEmpty(uGrid_Details.ActiveCell.Text))
                                //{
                                //    break;
                                //}
                                //// BL�R�[�h
                                //if (uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE && String.IsNullOrEmpty(uGrid_Details.ActiveCell.Text))
                                //{
                                //    break;
                                //}
                                //del end 2010/06/21 by gejun for RedMine #10103
							}

							switch (e.Key)
							{
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (!e.ShiftKey)
                                        {
                                            if (colIndex < 18)
                                            {
                                                if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE))
                                                {
                                                    string yearDiv = this.uGrid_Details.ActiveCell.Text;
                                                    if (CheckYearDiv(yearDiv))
                                                    {
                                                        this.uGrid_Details.ActiveCell.Value = yearDiv;
                                                        uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                    else
                                                    {
                                                        SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                        return;
                                                    }
                                                }
                                                //add start 2010/06/25 by gejun for RedMine #10103
                                                else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATECARNO_TITLE))
                                                {
                                                    if (CheckCarNoWithErrorHandle(this.uGrid_Details.ActiveCell.Text, rowIndex, colIndex))
                                                    {
                                                        uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                    else
                                                    {
                                                        return;
                                                    }
                                                }
                                                //add end 2010/06/25 by gejun for RedMine #10103
                                                else
                                                {
                                                    if (CheckNumber(uGrid_Details.Rows[rowIndex].Cells[colIndex].Text, rowIndex, uGrid_Details.Rows[rowIndex].Cells[colIndex].Column.Key))
                                                    {
                                                        // �i���A�W�����i�̏ꍇ�A���̃O�����Ɉړ�
                                                        if (colKeyNext == PMJKN09011UC.COL_GOODSNM_TITLE || colKeyNext == PMJKN09011UC.COL_COSTRATE_TITLE)
                                                        {
                                                            if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                                                                uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                                                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                        }
                                                        else
                                                        {
                                                            //add start 2010/06/21 by gejun for RedMine #10103
                                                            if (colKey == PMJKN09011UC.COL_GOODSNO_TITLE)
                                                            {
                                                                UltraGridCell cell = this.uGrid_Details.ActiveCell;
                                                                CellEventArgs cellEventArgs = new CellEventArgs(cell);
                                                                this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                                                uGrid_Details_AfterCellUpdate(this, cellEventArgs);
                                                                if (goodsSearchFlg)
                                                                {
                                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                                                    goodsSearchFlg = false;
                                                                }
                                                                else
                                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                                this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                                                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                            }
                                                            else
                                                            {
                                                                //add end 2010/06/21 by gejun for RedMine #10103
                                                                if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                            }//add 2010/06/21 by gejun for RedMine #10103
                                                        }
                                                    }
                                                    else
                                                    {
                                                        SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                    }
                                                    
                                                }
                                                nextCtrl = e.NextCtrl = null; //ADD 2009/05/21 GEJUN FOR REDMINE#8049
                                            }
                                            else if (rowIndex < uGrid_Details.Rows.Count - 1)
                                            {
                                                uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                nextCtrl = e.NextCtrl = null;//ADD 2009/05/21 GEJUN FOR REDMINE#8049
                                            }
                                            else if (rowIndex == uGrid_Details.Rows.Count - 1 && this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_ADDICARSPEC_TITLE))
                                            {
                                                //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
                                                if (e.Key == Keys.Return)
                                                {
                                                    nextCtrl = e.NextCtrl = null;//ADD 2009/05/24 GEJUN FOR REDMINE#8049
                                                    AddNewDetailRow();
                                                    SettingGrid();
                                                    uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                                    uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
                                                    this.tNedit_ModelDesignationNo.Focus();
                                                    nextCtrl = e.NextCtrl = this.tNedit_ModelDesignationNo;//ADD 2009/05/21 GEJUN FOR REDMINE#8049
                                                }//ADD 2009/05/21 GEJUN FOR REDMINE#8049
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            if (rowIndex == 0 && colIndex == 1)
                                            {
                                                this.tComboEditor_GoodsNoFuzzy.Focus();
                                                nextCtrl = e.NextCtrl = this.tComboEditor_GoodsNoFuzzy;
                                            }
                                            else if(colIndex == 1)
                                            {
                                                uGrid_Details.Rows[rowIndex - 1].Cells[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Activate();
                                                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            }
                                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE))
                                            {
                                                string yearDiv = this.uGrid_Details.ActiveCell.Text;
                                                if (CheckYearDiv(yearDiv))
                                                {
                                                    this.uGrid_Details.ActiveCell.Value = yearDiv;
                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                    return;
                                                }
                                            }
                                            //add start 2010/06/25 by gejun for RedMine #10103
                                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATECARNO_TITLE))
                                            {
                                                if (CheckCarNoWithErrorHandle(this.uGrid_Details.ActiveCell.Text, rowIndex, colIndex))
                                                {
                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            //add end 2010/06/25 by gejun for RedMine #10103
                                            else if (this.uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_CREATEYEAR_TITLE 
                                                || this.uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_PARTSQTY_TITLE)
                                            {
                                                if (CheckNumber(uGrid_Details.Rows[rowIndex].Cells[colIndex].Text, rowIndex, uGrid_Details.Rows[rowIndex].Cells[colIndex].Column.Key))
                                                {
                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex - 2].Activate();
                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                }
                                            }
                                            else
                                            {
                                                if (CheckNumber(uGrid_Details.Rows[rowIndex].Cells[colIndex].Text, rowIndex, uGrid_Details.Rows[rowIndex].Cells[colIndex].Column.Key))
                                                {
                                                    if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                                                        uGrid_Details.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                }
                                            }
                                            break;
                                        }
                                    }
                                case Keys.LButton:
                                case Keys.RButton:
                                    {
                                        if (this.uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_CREATEYEAR_TITLE)
                                        {
                                            if (!CheckYearDiv(this.uGrid_Details.ActiveCell.Text))
                                                SetCellBeforeValue(colKey, rowIndex, colIndex);
                                        }
                                        break;
                                    }
                            }

                            // ���ו��Ƀt�H�[�J�X�L��(GridActive)
                            // �I��
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                            // �N���A
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
                            // �ŐV���
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
                            // �ۑ�
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                            // �s�폜
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                            // ADD 2010/07/01----->>>
                            // �S�폜
                            if (updateModeFlg)
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = true;
                            // ADD 2010/07/01----->>>

                            // ���ׂ̃��[�J�[�ABL�R�[�h
                            if ((uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_MAKER_TITLE)) ||
                                (uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_BLCODE_TITLE)))
                            {
                                // �K�C�h
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
                            }
                            else
                            {
                                // �K�C�h
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;

                            }
                            //MODIFY START 2009/05/24 GEJUN FOR REDMINE#8049
                            // ���ׂ̕i��
                            //if (!string.IsNullOrEmpty(uGrid_Details.ActiveCell.Row.Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Text))
                            //{
                            // ���p�o�^
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = true;
                            //}
                            //else
                            //{
                            //    // ���p�o�^
                            //    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                            //}
                            //MODIFY END  2009/05/24 GEJUN FOR REDMINE#8049
						}                        
						break;
                    }
                #endregion
            }
			#endregion

			#region nextCtrl
			if (nextCtrl != null)
			{
				switch (nextCtrl.Name)
				{
					// �ޕ�
					case "tNedit_ModelDesignationNo":
					case "tNedit_CategoryNo":
					// �^��
					case "tEdit_FullModel":
						{
							// �I��
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// �N���A
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// �ŐV���
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// �ۑ�
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// ����
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
							// �s�폜
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // �S�폜
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// �K�C�h
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
							// ���p�o�^
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
					case "tNedit_MakerCode":
					case "tNedit_ModelCode":
					case "tNedit_ModelSubCode":
						{
							// �I��
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// �N���A
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// �ŐV���
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// �K�C�h
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
							// ����
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
							// �ۑ�
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// �s�폜
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // �S�폜
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// ���p�o�^
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
					// ���[�J�[
					case "tNedit_CmpltGoodsMakerCd":
					// �a�k�R�[�h
					case "tNedit_BlCd":
						{
							// �I��
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// �N���A
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// �ŐV���
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// ����
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;
							// �K�C�h
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
							// �ۑ�
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// �s�폜
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // �S�폜
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// ���p�o�^
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
                    case "uButton_CmpltGoodsMakerGuide":
                    case "BlCdGuide":
					case "tEdit_GoodsNo":
						{
							// �I��
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// �N���A
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// �ŐV���
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// ����
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;
							// �K�C�h
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
							// �ۑ�
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// �s�폜
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // �S�폜
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// ���p�o�^
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
                    case "tNedit_SearchGoodsNo":
                    case "uButton_ModelFullGuide":
						{
							// �I��
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// �N���A
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// �ŐV���
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// �ۑ�
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// ����
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
							// �s�폜
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // �S�폜
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// �K�C�h
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
							// ���p�o�^
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
                    case "uGrid_Details":
                        {
                            // ����
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                            // add start 2009/06/25 by gejun for RedMine #10103
                            // �ۑ�
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                            // �s�폜
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                            // ADD 2010/07/01----->>>
                            // �S�폜
                            if (updateModeFlg)
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = true;
                            // ADD 2010/07/01----->>>                            // ���p�o�^
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = true;
                            // add end 2009/06/25 by gejun for RedMine #10103

                            e.NextCtrl = null;
                            uGrid_Details.Rows[0].Cells[1].Activate();
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            break;
                        }
                    case "tComboEditor_GoodsNoFuzzy":
                        {
                            // ����
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;

                            // add start 2009/06/25 by gejun for RedMine #10103
                            // �I��
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                            // �N���A
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
                            // �ŐV���
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
                            // �K�C�h
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                            // �ۑ�
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                            // �s�폜
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // �S�폜
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
                            // ���p�o�^
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                            // add end 2009/06/25 by gejun for RedMine #10103
                            break;
                        }
                    case "ultraGrid_CarSpec":
                        {
                            // �K�C�h
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                            // ����
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                            break;
                        }
      				}
			}
			#endregion
		}

        /// <summary>
        /// ���[�J�[�ABL�R�[�h�̃`�F�b�N�B
        /// </summary>
        /// <param name="seisanYearDiv">���Y�N��</param>
        /// <returns>�`�F�b�N����</returns>
        private bool CheckMakeBlCode(UltraGridCell activeCell)
        {
            int rowIndex, colIndex = 0;
            FreeSearchParts freeSearchParts = null;
	        // �X�V�����DataRow
			DataRow dr = null;

            UltraGridCell cell = activeCell;

            if (activeCell == null)
                return false;

            if (!PMJKN09011UC.COL_BLCODE_TITLE.Equals(cell.Column.Key) 
                    && !PMJKN09011UC.COL_MAKER_TITLE.Equals(cell.Column.Key))
                return true;

            rowIndex = cell.Row.Index;
            colIndex = cell.Column.Index;//del 2010/06/29 by gejun for RedMine #10103
            dr = this._detailDataTable.Rows[rowIndex];

            if (this._freeSearchPartsDty.ContainsKey(dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].ToString()))
                freeSearchParts = this._freeSearchPartsDty[dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].ToString()];
            else
                return false;

            #region BL�R�[�h
            //------------------------------------------------------------
            // ActiveCell���uBL�R�[�h�v�̏ꍇ
            //------------------------------------------------------------
            if (cell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE)
            {
                int blCode = TStrConv.StrToIntDef(cell.Text, 0);

                //>>>2010/07/02
                //if (blCode != 0)
                if ((blCode != 0) && (blCode.ToString().PadLeft(5, '0') != this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE].ToString().Trim()))
                //<<<2010/07/02
                {
                    //-----------------------------------------------------------------------------
                    // BL�R�[�h����
                    //-----------------------------------------------------------------------------
                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    List<Stock> stockList = new List<Stock>();

                    //del  start  2010/06/29 by gejun for RedMine #10103
                    //// BL�R�[�h�̐ݒ�
                    //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = blCode.ToString().PadLeft(5, '0');
                    //freeSearchParts.TbsPartsCode = blCode;
                    //del  end  2010/06/29 by gejun for RedMine #10103
                    BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
                    BLGoodsCdUMnt bLGoodsCdUMnt;

                    int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //add  start  2010/06/29 by gejun for RedMine #10103
                        // BL�R�[�h�̐ݒ�
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = blCode.ToString().PadLeft(5, '0');
                        freeSearchParts.TbsPartsCode = blCode;
                        //add  end  2010/06/29 by gejun for RedMine #10103
                        //>>>2010/07/02
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = bLGoodsCdUMnt.BLGoodsFullName;
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName;
                        //<<<2010/07/02
                    }
                    else
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "BL�R�[�h [" + blCode.ToString() + "] �ɊY������f�[�^�����݂��܂���B",
                           -1,
                           MessageBoxButtons.OK);

                        SetCellBeforeValue(cell.Column.Key, rowIndex, colIndex);//add 2010/06/29 by gejun for RedMine #10103

                        return false;
                    }
                }
            }
            # endregion

            #region ���[�J�[
            //------------------------------------------------------------
            // ActiveCell���u���[�J�[�v�̏ꍇ
            //------------------------------------------------------------
            if (cell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE)
            {
                if (TStrConv.StrToIntDef(cell.Text.ToString(), 0) != 0)
                {
                    if (!String.IsNullOrEmpty(cell.Text))
                    {
                        MakerAcs makerAcs = new MakerAcs();
                        MakerUMnt makerUMnt;
                        //���[�J�[�f�[�^�̎擾
                        int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, TStrConv.StrToIntDef(cell.Text, 0));
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "���[�J�[�R�[�h [" + cell.Text + "] �ɊY������f�[�^�����݂��܂���B",
                               -1,
                               MessageBoxButtons.OK);

                            SetCellBeforeValue(cell.Column.Key, rowIndex, colIndex);//add 2010/06/29 by gejun for RedMine #10103

                            return false;
                        }
                        dr[PMJKN09011UC.COL_MAKER_TITLE] = cell.Text.PadLeft(4, '0');
                        freeSearchParts.GoodsMakerCd = Convert.ToInt32(cell.Text);

                    }
                    else
                    {
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_MAKER_TITLE] = 0;
                        freeSearchParts.GoodsMakerCd = 0;
                    }
                }
            }

            return true;
            # endregion
        }

		/// <summary>
		/// ���Y�N���̃`�F�b�N�B
		/// </summary>
		/// <param name="seisanYearDiv">���Y�N��</param>
		/// <returns>�`�F�b�N����</returns>
		private bool CheckYearDiv(string seisanYearDiv)
		{
			bool bNext = true;
			String[] createYear = seisanYearDiv.Split('-');
			createYear[0] = createYear[0].Trim();
			createYear[1] = createYear[1].Trim();

			if (!createYear[0].Equals("____.__") && !IsDate(createYear[0]))
			{
			    TMsgDisp.Show(this,
						       emErrorLevel.ERR_LEVEL_INFO,
						       this.Name,
						       "�J�n���t�̓��͂��s���ł��B",
						       -1,
						       MessageBoxButtons.OK);
				bNext = false;
			}
			if (bNext && !createYear[1].Equals("____.__") && !IsDate(createYear[1]))
			{
			    TMsgDisp.Show(this,
						       emErrorLevel.ERR_LEVEL_INFO,
						       this.Name,
						       "�I�����t�̓��͂��s���ł��B",
						       -1,
						       MessageBoxButtons.OK);
				bNext = false;
			}
			if (bNext && (!createYear[0].Equals("____.__") || !createYear[1].Equals("____.__")))
			{
                DateTime stCreateYear = DateTime.MinValue;
                DateTime edCreateYear = DateTime.MinValue;
                if (!createYear[0].Equals("____.__"))
                    stCreateYear = DateTime.Parse(createYear[0]);
                if (!createYear[1].Equals("____.__"))
				    edCreateYear = DateTime.Parse(createYear[1]);

				if (stCreateYear.CompareTo(edCreateYear) > 0)
				{
				    TMsgDisp.Show(this,
							       emErrorLevel.ERR_LEVEL_INFO,
							       this.Name,
							       "�J�n���t�ȏ�̓��t����͂��ĉ������B",
							       -1,
							       MessageBoxButtons.OK);
					bNext = false;
				}
                else if (stCreateYear == DateTime.MinValue)
                {
                    TMsgDisp.Show(this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "�J�n���t����͂��ĉ������B",
                                   -1,
                                   MessageBoxButtons.OK);
                    bNext = false;
                }

			}

			return bNext;
		}

		/// <summary>
        /// �ԑ�ԍ��̃`�F�b�N�B
        /// </summary>
        /// <param name="createNo">�ԑ�ԍ�</param>
        /// <returns>�`�F�b�N����</returns>
        private bool CheckCarNo(string createNo)
        {
            bool retFlg = true;

            // ADD 2010/07/02 ------>>>
            if(string.IsNullOrEmpty(createNo.Trim()))
                return retFlg;
            // ADD 2010/07/02 ------>>>

            String[] createCarNo = createNo.Trim().Split('-');
            int stCreateCarNo = 0;
            int EdCreateCarNo = 0;
            if (!string.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
            {
                stCreateCarNo = Convert.ToInt32(createCarNo[0].Trim().Replace("_", string.Empty));

                if (stCreateCarNo == 0)
                {
                    TMsgDisp.Show(this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�J�n�ԍ�����͂��ĉ������B",
                       -1,
                       MessageBoxButtons.OK);

                    retFlg = false;
                }
            }

            if (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________"))
            {
                EdCreateCarNo = Convert.ToInt32(createCarNo[1].Trim().Replace("_", string.Empty));

                if (EdCreateCarNo == 0)
                {
                    TMsgDisp.Show(this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�I���ԍ�����͂��ĉ������B",
                       -1,
                       MessageBoxButtons.OK);
                    retFlg = false;
                }
            }

            if ((!String.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
                && (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________")))
            {
                if (stCreateCarNo > EdCreateCarNo)
                {
                    TMsgDisp.Show(this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "�J�n�ԍ��ȏ�̔ԍ�����͂��ĉ������B",
                                   -1,
                                   MessageBoxButtons.OK);
                    retFlg = false;
                }
            }
            return retFlg;
        }

        /// <summary>
        /// �ԑ�ԍ��̃`�F�b�N�B
        /// </summary>
        /// <param name="createNo">�ԑ�ԍ�</param>
        /// <param name="rowIndex">�s�ԍ�/param>
        /// <param name="colIndex">��ԍ�/param>
        /// <returns>�`�F�b�N����</returns>
        private bool CheckCarNoWithErrorHandle(string createNo, int rowIndex, int colIndex)
        {
            string createcarNo = "";
            bool retFlg = true;
            String[] createCarNo = createNo.Trim().Split('-');
            int stCreateCarNo = 0;
            int EdCreateCarNo = 0;
            if (!string.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
            {
                stCreateCarNo = Convert.ToInt32(createCarNo[0].Trim().Replace("_", string.Empty));

                if (stCreateCarNo == 0)
                {
                    TMsgDisp.Show(this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�J�n�ԍ�����͂��ĉ������B",
                       -1,
                       MessageBoxButtons.OK);

                    retFlg = false;
                }
            }

            if (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________"))
            {
                EdCreateCarNo = Convert.ToInt32(createCarNo[1].Trim().Replace("_", string.Empty));

                if (EdCreateCarNo == 0)
                {
                    TMsgDisp.Show(this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�I���ԍ�����͂��ĉ������B",
                       -1,
                       MessageBoxButtons.OK);
                    retFlg = false;
                }
            }

            if ((!String.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
                && (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________")))
            {
                if (stCreateCarNo > EdCreateCarNo)
                {
                    TMsgDisp.Show(this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "�J�n�ԍ��ȏ�̔ԍ�����͂��ĉ������B",
                                   -1,
                                   MessageBoxButtons.OK);
                    retFlg = false;
                }
            }

            if (retFlg)
            {
                if (stCreateCarNo != 0)
                {
                    createcarNo = createcarNo + stCreateCarNo.ToString().PadLeft(8, '_');
                }
                else
                {
                    createcarNo = createcarNo + "________";
                }
                createcarNo = createcarNo + " - ";
                if (EdCreateCarNo != 0)
                {
                    createcarNo = createcarNo + EdCreateCarNo.ToString().PadLeft(8, '_');
                }
                else
                {
                    createcarNo = createcarNo + "________";
                }
                uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = createcarNo;
            }
            return retFlg;
        }

		/// <summary>
		/// �ԗ���������
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		private int CarSearch(CarSearchCondition condition)
		{
			//------------------------------------------------------
			// ��������
			//------------------------------------------------------
			int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            // add start 2009/06/22 by gejun for RedMine #10103
            if (this._categoryNo.Equals(this.tNedit_ModelDesignationNo.Text + this.tNedit_CategoryNo.Text)
                && this._fullCarType.Equals(this.tNedit_MakerCode.Text + this.tNedit_ModelCode.Text + this.tNedit_ModelSubCode.Text)
                && this._designationNo.Equals(this.tEdit_FullModel.Text) && this.tEdit_FullModel.Text.Trim() != "")
            {
                return retStatus = (int)ConstantManagement.MethodResult.ctFNC_DO_END;
            }
            // add end 2009/06/22 by gejun for RedMine #10103 

			this._beforeCarSearchBuffer.StartProduceFrameNo = tEdit_StartProduceFrameNo.Text.Trim();
			this._beforeCarSearchBuffer.EndProduceFrameNo = tEdit_EndProduceFrameNo.Text.Trim();
			string startDate = string.Empty;
			if (!string.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text))
			{
				startDate += this.tDateEdit_StartEntryYearDate.Text;
			}
			if (!string.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text))
			{
				startDate += this.tDateEdit_StartEntryMonthDate.Text;
			}
			if (!string.IsNullOrEmpty(startDate))
			{
				this._beforeCarSearchBuffer.StartEntryDate = Convert.ToInt32(startDate);
			}

			string endDate = string.Empty;
			if (!string.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text))
			{
				endDate += this.tDateEdit_EndEntryYearDate.Text;
			}
			if (!string.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text))
			{
				endDate += this.tDateEdit_EndEntryMonthDate.Text;
			}
			if (!string.IsNullOrEmpty(endDate))
			{
				this._beforeCarSearchBuffer.EndEntryDate = Convert.ToInt32(endDate);
			}

			//------------------------------------------------------
			// �J�[���[�J�[�R�[�h�A�Ԏ�R�[�h�A�Ԏ�ď̃R�[�h�ݒ�
			//------------------------------------------------------
			if (condition.Type != CarSearchType.csCategory)
			{
				int makerCd, modelCd, modelSubCd;
				if (int.TryParse(this.tNedit_MakerCode.Text, out makerCd))
				{
					condition.MakerCode = makerCd;
				}
				if (int.TryParse(this.tNedit_ModelCode.Text, out modelCd))
				{
					condition.ModelCode = modelCd;
				}
				if (int.TryParse(this.tNedit_ModelSubCode.Text, out modelSubCd))
				{
					condition.ModelSubCode = modelSubCd;
				}
			}
			//------------------------------------------------------
			// �e�팟������
			//------------------------------------------------------
			//  CarSearchCondition �̌����^�C�v�ɂ��w��
			//------------------------------------------------------
			CarSearchResultReport ret = new CarSearchResultReport();
			PMKEN01010E dat = new PMKEN01010E();
			this._carInfo = dat;
			CarSearchController carSearchController = new CarSearchController();
			ret = carSearchController.Search(condition, ref dat);
			if (ret == CarSearchResultReport.retFailed)
			{

				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			}
			else if (ret == CarSearchResultReport.retError)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�������ɃG���[���������܂����B",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			if (ret == CarSearchResultReport.retMultipleCarKind)
			{
    			//------------------------------------------------------
				// �Ԏ�I����ʋN��
				//------------------------------------------------------
				if (SelectionCarKind.ShowDialog(dat.CarKindInfo, condition) == DialogResult.OK)
				{
					ret = carSearchController.Search(condition, ref dat);

				}
				else
				{
					return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}
			if (ret == CarSearchResultReport.retMultipleCarModel)
			{
                // add start 2009/06/22 by gejun for RedMine #10103
                //if(this._categoryNo.Equals(this.tNedit_ModelDesignationNo.Text + this.tNedit_CategoryNo.Text)
                //    && this._fullCarType.Equals(this.tNedit_MakerCode.Text + this.tNedit_ModelCode.Text + this.tNedit_ModelSubCode.Text)
                //    && this._designationNo.Equals(this.tEdit_FullModel.Text) && this.tEdit_FullModel.Text.Trim() != "")
                //{
                //   return retStatus = (int)ConstantManagement.MethodResult.ctFNC_DO_END;
                //}
                // add end 2009/06/22 by gejun for RedMine #10103
				//------------------------------------------------------
				// �^���I����ʋN��
				//------------------------------------------------------
				if (SelectionCarModel.ShowDialog(dat) == DialogResult.OK)
				{
					SetCarInfo(dat);
				}
				else
				{
					return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}

			if ((ret == CarSearchResultReport.retSingleCarModel) || (ret == CarSearchResultReport.retMultipleCarModel))
			{
				SetCarInfo(dat);

				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}

			return retStatus;
		}

		/// <summary>
		/// tNedit_MakerCode_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_MakerCode_ValueChanged(object sender, EventArgs e)
		{
			string makerCode = this.tNedit_MakerCode.Text;
			if (string.IsNullOrEmpty(makerCode))
			{
				//�Ԏ��
				this.tNedit_ModelCode.Clear();
				this.tNedit_ModelCode.Enabled = false;
				//�Ԏ�ď̺��
				this.tNedit_ModelSubCode.Clear();
				this.tNedit_ModelSubCode.Enabled = false;
				//�Ԏ햼��
				this.tEdit_ModelFullName.Clear();
			}
			else
			{
				//�Ԏ��
				this.tNedit_ModelCode.Enabled = true;
			}
		}

		/// <summary>
		/// tNedit_ModelCode_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_ModelCode_ValueChanged(object sender, EventArgs e)
		{
			string modelCode = this.tNedit_ModelCode.Text;
			if (string.IsNullOrEmpty(modelCode))
			{
				//�Ԏ�ď̺��
				this.tNedit_ModelSubCode.Clear();
				this.tNedit_ModelSubCode.Enabled = false;
				//�Ԏ햼��
				this.tEdit_ModelFullName.Clear();
			}
			else
			{
				//�Ԏ�ď̺��
				this.tNedit_ModelSubCode.Enabled = true;
			}
		}

		/// <summary>
		/// tNedit_ModelSubCode_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_ModelSubCode_ValueChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.tNedit_ModelSubCode.Text))
			{
				//�Ԏ햼��
				this.tEdit_ModelFullName.Clear();
			}
		}

		/// <summary>
		/// tNedit_ModelSubCode_AfterExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void tNedit_ModelSubCode_AfterExitEditMode(object sender, EventArgs e)
		{
            TNedit tNedit = (TNedit)sender;
			//��Ұ�����
			string makerCode = this.tNedit_MakerCode.Text;
			//�Ԏ��
			string modelCode = this.tNedit_ModelCode.Text;
			//�Ԏ�ď̺��
			string modelSubCode = this.tNedit_ModelSubCode.Text;
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
			ModelNameU modelNameU;
			if (!string.IsNullOrEmpty(makerCode))
			{
				if ((this.tNedit_MakerCode.GetInt() != 0)&&(this.tNedit_ModelCode.GetInt() == 0))
				{
					//���[�J�[�f�[�^�̎擾
					int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_MakerCode.GetInt());
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						//���[�J�[
						this.tNedit_MakerCode.SetInt(makerUMnt.GoodsMakerCd);
						this.tEdit_ModelFullName.Text = makerUMnt.MakerName;
					}
					else
					{
                        TMsgDisp.Show(this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "�Y���f�[�^������܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        tNedit.Clear();
                        tNedit.Focus();
					}
				}
				else if (this.tNedit_ModelCode.GetInt() != 0)
				{
					int status = modelNameUAcs.Read(out modelNameU, this._enterpriseCode, this.tNedit_MakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
						if (modelNameU.ModelCode != 0)
						{
							this.tNedit_ModelCode.Text = modelNameU.ModelCode.ToString("000");
						}
						if (modelNameU.ModelSubCode != 0)
						{
							this.tNedit_ModelSubCode.Text = modelNameU.ModelSubCode.ToString("000");
						}
					}
					else
					{
                        TMsgDisp.Show(this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "�Y���f�[�^������܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        tNedit.Clear();
                        tNedit.Focus();
					}
				}
			}
		}

		/// <summary>
		/// tEdit_FullModel_Leave�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_FullModel_Leave(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.tEdit_FullModel.Text))
			{
				this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();
			}
		}

		/// <summary>
		/// tNedit_SearchGoodsNo_TextChanged�C�x���g
		/// </summary>
        private bool tNedit_SearchGoodsNo_TextChanged()
		{
			if (!string.IsNullOrEmpty(this.tNedit_SearchGoodsNo.Text) && !string.IsNullOrEmpty(this.EndSearchGoodsNo.Text))
			{
				if (this.tNedit_SearchGoodsNo.GetInt() > Convert.ToInt32(this.EndSearchGoodsNo.Text)
                    || this.tNedit_SearchGoodsNo.GetInt() < Convert.ToInt32(this.StartSearchGoodsNo.Text))
				{
					TMsgDisp.Show(this,
								   emErrorLevel.ERR_LEVEL_INFO,
								   this.Name,
								   "�͈͓��̔ԍ�����͂��ĉ������B",
								   -1,
								   MessageBoxButtons.OK);
                    if (_beforeRecordNum == 0)
                    {
                        this.tNedit_SearchGoodsNo.SetInt(1);
                    }
                    else
                    {
                        this.tNedit_SearchGoodsNo.SetInt(_beforeRecordNum);
                    }

                    tNedit_SearchGoodsNo.Focus();
                    return false;
				}
				else
				{
                    // --- UPD m.suzuki 2010/06/01 ---------->>>>>
                    //if (this.tNedit_SearchGoodsNo.GetInt() <= this._carModelInfoDataTable.Rows.Count)
                    if ( this.tNedit_SearchGoodsNo.GetInt() <= this._selectCarModelInfoDataTable.Rows.Count )
                    // --- UPD m.suzuki 2010/06/01 ----------<<<<<
					{
                        this._beforeRecordNum = this.tNedit_SearchGoodsNo.GetInt();
                        DataRow carModelInfoRow = null;

                        // --- UPD m.suzuki 2010/06/01 ---------->>>>>
                        //if (_singleIndex == 0)
                        //{
                        //    carModelInfoRow = this._carModelInfoDataTable.Rows[this.tNedit_SearchGoodsNo.GetInt() - 1];
                        //}
                        //else
                        //{
                        //    carModelInfoRow = this._carModelInfoDataTable.Rows[_singleIndex - 1];
                        //}
                        //_singleIndex = 0;
                        carModelInfoRow = this._selectCarModelInfoDataTable.Rows[this.tNedit_SearchGoodsNo.GetInt() - 1];
                        // --- UPD m.suzuki 2010/06/01 ----------<<<<<

						this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Clear();
						DataRow carSpecDr = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].NewRow();
                        this.tEdit_FullModel.Text = carModelInfoRow["FullModel"].ToString();
                        this._fullModel = carModelInfoRow["FullModel"].ToString();
                        //�O���[�h
						carSpecDr[PMJKN09011UB.COL_MODELGRADENM_TITLE] = carModelInfoRow["ModelGradeNm"].ToString();
						//�{�f�B
						carSpecDr[PMJKN09011UB.COL_BODYNAME_TITLE] = carModelInfoRow["BodyName"].ToString();
						//�h�A
                        carSpecDr[PMJKN09011UB.COL_DOORCOUNT_TITLE] = carModelInfoRow["DoorCount"].ToString();
						//�G���W��
						carSpecDr[PMJKN09011UB.COL_ENGINEMODELNM_TITLE] = carModelInfoRow["EngineModelNm"].ToString();
						//�r�C��
						carSpecDr[PMJKN09011UB.COL_ENGINEDISPLACENM_TITLE] = carModelInfoRow["EngineDisplaceNm"].ToString();
						//E�敪
						carSpecDr[PMJKN09011UB.COL_EDIVNM_TITLE] = carModelInfoRow["EDivNm"].ToString();
						//�~�b�V����
						carSpecDr[PMJKN09011UB.COL_TRANSMISSIONNM_TITLE] = carModelInfoRow["TransmissionNm"].ToString();
						//�쓮�`��
						carSpecDr[PMJKN09011UB.COL_WHEELDRIVEMETHODNM_TITLE] = carModelInfoRow["WheelDriveMethodNm"].ToString();
						//�V�t�g
						carSpecDr[PMJKN09011UB.COL_SHIFTNM_TITLE] = carModelInfoRow["ShiftNm"].ToString();

						this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Add(carSpecDr);

						this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].DefaultView;

                        this.ultraGrid_CarSpec.Rows[0].Activation = Activation.Disabled;
      
                        tNedit_SearchGoodsNo.Focus();
					}

				}
    		}
			else
			{
                this.tNedit_SearchGoodsNo.Clear();
				this.tNedit_SearchGoodsNo.Focus();
			}

            return true;
		}


        // ADD START 2010/05/21 GEJUN FOR REDMINE#8049
        /// <summary>
		/// �O���b�h�L�[�_�E���A�L�[�A�b�v����
		/// </summary>
        /// <param name="activeCellKey">�ΏۃI�u�W�F�N�g�̃L�[</param>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <param name="eventType">�C�x���g�^�C�v</param>
        /// <param name="wrapFlg">���s�t���O</param>
        private void GridDownUpControl(String activeCellKey, int rowIndex, int eventType, bool wrapFlg)
        {
            int rowInx = rowIndex;
            if (wrapFlg)
            {
                // ��Key�����s
                if (eventType == 0)
                    rowInx--;
                // ��Key�����s
                else
                    rowInx++;
            }
            switch (activeCellKey)
            {
                // ��ڰ�ށA���ި�A�ޱ
                case PMJKN09011UC.COL_MODELGRADENM_TITLE:
                case PMJKN09011UC.COL_BODYNAME_TITLE:
                case PMJKN09011UC.COL_DOORCOUNT_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // �ݼ��
                case PMJKN09011UC.COL_ENGINEMODELNM_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_MAKER_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // �r�C��
                case PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // E�敪�AЯ��݁A�쓮����
                case PMJKN09011UC.COL_EDIVNM_TITLE:
                case PMJKN09011UC.COL_TRANSMISSIONNM_TITLE:
                case PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // ���
                case PMJKN09011UC.COL_SHIFTNM_TITLE:
                    {

                        // uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_COSTRATE_TITLE].Activate(); del 2010/06/21 by gejun for RedMine #10103
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Activate();//add 2010/06/21 by gejun for RedMine #10103
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // �E�v
                case PMJKN09011UC.COL_ADDICARSPEC_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // �i��
                case PMJKN09011UC.COL_GOODSNO_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_MODELGRADENM_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // Ұ��
                case PMJKN09011UC.COL_MAKER_TITLE:
                    {
                        if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                        {
                            uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].Activate();
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                // BL����
                case PMJKN09011UC.COL_BLCODE_TITLE:
                    {
                        if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                        {
                            uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].Activate();
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;

                    }
                // QTY
                case PMJKN09011UC.COL_PARTSQTY_TITLE:
                    {
                        //uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_EDIVNM_TITLE].Activate();del 2010/06/21 by gejun for RedMine #10103
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].Activate();//add 2010/06/21 by gejun for RedMine #10103
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // �W�����i
                case PMJKN09011UC.COL_COSTRATE_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_SHIFTNM_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // ���Y�N���A���Y�ԑ�ԍ�
                case PMJKN09011UC.COL_CREATEYEAR_TITLE:
                case PMJKN09011UC.COL_CREATECARNO_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                default:
                    break;
            }
        }


        //add start 2010/06/25 by gejun for RedMine #10103
        /// <summary>
        /// �O���b�h�E�L�[�A���L�[����
        /// </summary>
        /// <param name="keyDiv">�L�[�敪/param>
        /// <param name="activeCell">�ΏۃZ��</param>
        /// <param name="rowIndex">�Ώۍs�ԍ�</param>
        /// <param name="columnIndex">�Ώۗ�ԍ�</param>
        /// <param name="performActionFlg">�A�N�V�������s�敪</param>
        private void GridRightLeftControl(int keyDiv, UltraGridCell activeCell, int rowIndex, int columnIndex, bool performActionFlg)
        {
            // �E�L�[
            if (keyDiv == 0)
            {
                if (activeCell.SelStart < activeCell.Text.Length)
                {
                    if (activeCell.SelText.Length > 0)
                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart +
                            activeCell.SelLength;
                    else
                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart++;
                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                }
                else
                {
                    if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                    {
                        uGrid_Details.Rows[rowIndex].Cells[columnIndex].Activate();
                        if (performActionFlg)
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            else
            {
                if (activeCell.SelStart > 0 )
                {
                    if (activeCell.SelLength == 0)
                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart--; 
                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                }
                else
                {
                    if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                    {
                        uGrid_Details.Rows[rowIndex].Cells[columnIndex].Activate();
                        if (performActionFlg)
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
        }
        //add end 2010/06/25 by gejun for RedMine #10103

        /// <summary>
        /// �ҏW���[�h����O���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }
            int rowIndex = uGrid.ActiveCell.Row.Index;
            int colIndex = uGrid.ActiveCell.Column.Index;
            string colKey = uGrid.ActiveCell.Column.Key;

            if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(colKey))
            {
                if (!CheckYearDiv(this.uGrid_Details.ActiveCell.Text))
                {
                    SetCellBeforeValue(colKey, rowIndex, colIndex);
                    return;
                }
            }
        }

		/// <summary>
		/// �O���b�h�L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
		{
            // ��i���f�t���O
            bool upperFlg = false;// ADD 2010/05/21 GEJUN FOR REDMINE#8049
            // �����Z���̃L�[
            string activeCellKey;// ADD 2010/05/21 GEJUN FOR REDMINE#8049
			UltraGrid uGrid = (UltraGrid)sender;

			if (uGrid.ActiveCell == null)
			{
				return;
			}

			int rowIndex = uGrid.ActiveCell.Row.Index;
			int colIndex = uGrid.ActiveCell.Column.Index;
			string colKey = uGrid.ActiveCell.Column.Key;

            // ADD START 2010/05/21 GEJUN FOR REDMINE#8049
            // �O���b�h��i�A���i�̔��f
            activeCellKey = uGrid.ActiveCell.Column.Key;
            UltraGridCell activeCell = this.uGrid_Details.ActiveCell;

            switch (activeCellKey)
            {
                case PMJKN09011UC.COL_GOODSNO_TITLE:
                case PMJKN09011UC.COL_MAKER_TITLE:
                case PMJKN09011UC.COL_BLCODE_TITLE:
                case PMJKN09011UC.COL_GOODSNM_TITLE:
                case PMJKN09011UC.COL_PARTSQTY_TITLE:
                case PMJKN09011UC.COL_COSTRATE_TITLE:
                case PMJKN09011UC.COL_CREATEYEAR_TITLE:
                case PMJKN09011UC.COL_CREATECARNO_TITLE:
                    {
                        upperFlg = true;
                        break;
                    }
                default:
                    {
                        upperFlg = false;
                        break;
                    }
            }
            // ADD END 2010/05/21 GEJUN FOR REDMINE#8049

			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
			{
				// �i��
				if (uGrid.ActiveCell.Column.Key == PMJKN09011UC.COL_GOODSNO_TITLE && String.IsNullOrEmpty(uGrid.ActiveCell.Text))
				{
					return;
				}
                //del start 2010/06/21 by gejun for RedMine #10103
                //// ���[�J�[
                //if (uGrid.ActiveCell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE && String.IsNullOrEmpty(uGrid.ActiveCell.Text))
                //{
                //    return;
                //}
                //// BL�R�[�h
                //if (uGrid.ActiveCell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE && String.IsNullOrEmpty(uGrid.ActiveCell.Text))
                //{
                //    return;
                //}
                //del end 2010/06/21 by gejun for RedMine #10103
			}
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (!CheckNumber(uGrid_Details.Rows[rowIndex].Cells[colIndex].Text, rowIndex, activeCellKey))
                {
                    SetCellBeforeValue(activeCellKey, rowIndex, colIndex);
                    return;
                }
                // ADD 2010/07/01----->>>>
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                // ADD 2010/07/01----->>>>
                    if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(activeCellKey))
                    {
                        if (!CheckYearDiv(this.uGrid_Details.ActiveCell.Text))
                        {
                            SetCellBeforeValue(activeCellKey, rowIndex, colIndex);
                            return;
                        }
                    }
                }  // ADD 2010/07/01----->>>>
            }


			switch (e.KeyCode)
			{
            	case Keys.Up:
					{
						if (rowIndex == 0)
						{
                            // ADD START 2010/05/21 GEJUN FOR REDMINE#8049
							// ���ו��̕i�ԏ��Ƀt�H�[�J�X������
                            if (upperFlg)
                            {
                                if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                                {        
                                    // add start 2009/06/25 by gejun for RedMine #10103
                                    // �ۑ�
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                                    // ����
                                    //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false; //DEL 2010/07/01 ----->>>
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;//ADD 2010/07/01 ----->>>
                                    // �s�폜
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                                    // �S�폜
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
                                    // �K�C�h
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                                    // ���p�o�^
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                                     // add end 2009/06/25 by gejun for RedMine #10103
                                    // �u���������|�i�ԁv�ֈړ�
                                    this.tComboEditor_GoodsNoFuzzy.Focus();
                                }
                            }
                            else
                            {
                                this.GridDownUpControl(activeCellKey, rowIndex, 0, false);
                            }
                            // ADD END 2010/05/21 GEJUN FOR REDMINE#8049
						}
						else
						{
							e.Handled = true;
                            // ���ו��̕i�ԏ��Ƀt�H�[�J�X������
                            // MODIFY START 2010/05/21 GEJUN FOR REDMINE#8049
                            if (upperFlg)
                            {
                                //uGrid.Rows[rowIndex - 1].Cells[colIndex].Activate();
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this.GridDownUpControl(activeCellKey, rowIndex, 0, true);
                            } 
                            else
                            {
                                this.GridDownUpControl(activeCellKey, rowIndex, 0, false);
                            }
                            // MODIFY END 2010/05/21 GEJUN FOR REDMINE#8049
						}
						break;
					}
				case Keys.Down:
					{
						e.Handled = true;
                        // MODIFY START 2010/05/21 GEJUN FOR REDMINE#8049
                        if (upperFlg)
                        {
                           this.GridDownUpControl(activeCellKey, rowIndex, 1, false);
                        }
                        else
                        {
                            if (rowIndex != uGrid.Rows.Count - 1)
                            {
                                //uGrid.Rows[rowIndex + 1].Cells[colIndex].Activate();
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this.GridDownUpControl(activeCellKey, rowIndex, 1, true);
                            }
                        }
                        // MODIFY END 2010/05/21 GEJUN FOR REDMINE#8049
						break;
					}
				case Keys.Left:
					{
						if (colIndex == 1)
						{
							if (rowIndex == 0)
							{
                                //tEdit_GoodsNo.Focus();//DEL 2010/05/21 GEJUN FOR REDMINE#8049
                                if (activeCell.SelStart <= 0)
                                {
                                    // add start 2009/06/25 by gejun for RedMine #10103
                                    // �ۑ�
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                                    // ����
                                    //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;//DEL 2010/07/01 ----->>>
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;//ADD 2010/07/01 ----->>>
                                    // �s�폜
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                                    // �S�폜
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
                                    // �K�C�h
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                                    // ���p�o�^
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                                    // add end 2009/06/25 by gejun for RedMine #10103
                                    tComboEditor_GoodsNoFuzzy.Focus();//ADD 2010/05/21 GEJUN FOR REDMINE#8049
                                }    
							}
                            //ADD START 2010/05/21 GEJUN FOR REDMINE#8049
                            else
                            {

                                GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex - 1, 
                                    uGrid_Details.Rows[rowIndex - 1].Cells[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Column.Index, true);
                                //uGrid_Details.Rows[rowIndex - 1].Cells[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Activate();
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            //ADD END 2010/05/21 GEJUN FOR REDMINE#8049
						}
						else
						{
							e.Handled = true;
                            if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE))
                            {
                                
                                // add start 2009/06/22 by gejun for RedMine #10103
                                if (activeCell.SelStart > 0)
                                {
                                    if (this.uGrid_Details.ActiveCell.SelStart == 10)
                                        //uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart - 3; //DEL 2010/07/01
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = 0; //ADD 2010/07/01
                                    else if (this.uGrid_Details.ActiveCell.SelStart == 9)
                                        //uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart - 2; //DEL 2010/07/01
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = 0; //ADD 2010/07/01
                                    else
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart--;
                                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    // add end 2009/06/22 by gejun for RedMine #10103
                                    GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 2, true);
                                    //uGrid_Details.Rows[rowIndex].Cells[colIndex - 2].Activate();
                                    //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }// add 2009/06/22 by gejun for RedMine #10103
                            }
                            // del start 2009/06/23 by gejun for RedMine #10103
                            ///else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_PARTSQTY_TITLE)
                            //    || PMJKN09011UC.COL_MODELGRADENM_TITLE.Equals(activeCellKey)) //ADD 2010/05/21 GEJUN FOR REDMINE#8049
                            // add end 2009/06/23 by gejun for RedMine #10103
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_PARTSQTY_TITLE)) // add 2009/06/23 by gejun for RedMine #10103
                            {
                                // del start 2009/06/23 by gejun for RedMine #10103
                                // add start 2009/06/22 by gejun for RedMine #10103
                                //if (PMJKN09011UC.COL_MODELGRADENM_TITLE.Equals(activeCellKey))
                                //   this.focusMoveType = 2;
                                // add end 2009/06/22 by gejun for RedMine #10103
                                // del end 2009/06/23 by gejun for RedMine #10103
                                GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 2, true);
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex - 2].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            // add start 2009/06/22 by gejun for RedMine #10103
                            // �O���[�h
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_MODELGRADENM_TITLE))
                            {
                                this.focusMoveType = 2;
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 1, true);
                            }
                            // ���Y�ԑ�ԍ�
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATECARNO_TITLE))
                            {

                                if (activeCell.SelStart > 0)
                                {
                                    if (this.uGrid_Details.ActiveCell.SelStart == 11)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart - 3;
                                    else if (this.uGrid_Details.ActiveCell.SelStart == 10)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart - 2;
                                    else
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart--;
                                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    this.focusMoveType = 2;
                                    GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 1, true);
                                }
                                
                            }
                            // add end 2009/06/22 by gejun for RedMine #10103
                            else
                            {
                                GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 1, true);
                                //uGrid.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
						}
						break;
					}
                case Keys.F2:
				case Keys.Right:
					{
						e.Handled = true;
						if (colIndex < 18)
						{
                            if (this.uGrid_Details.ActiveCell.Column.Key.Equals("�i��"))
                            {
                                //add start 2010/06/21 by gejun for RedMine #10103
                                UltraGridCell cell = this.uGrid_Details.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(cell);
                                this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                if (cell.SelStart + cell.SelLength >= cell.Value.ToString().Length)
                                {
                                    uGrid_Details_AfterCellUpdate(this, cellEventArgs);
                                    if (goodsSearchFlg)
                                    {
                                        GridRightLeftControl(0, cell, rowIndex, colIndex + 2, false);
                                        //uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                        goodsSearchFlg = false;
                                    }
                                    else
                                        GridRightLeftControl(0, cell, rowIndex, colIndex + 1, false);
                                    //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                    this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                    GridRightLeftControl(0, cell, rowIndex, colIndex, false);

                                //add end 2010/06/21 by gejun for RedMine #10103
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals("���Y�N��"))
                            {
                                int selEnd = activeCell.SelStart + activeCell.SelLength;
                                // add start 2009/06/22 by gejun for RedMine #10103
                                if (selEnd < 17)
                                {
                                    if (selEnd == 7)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = selEnd + 3;
                                    else if (selEnd == 8)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = selEnd + 2;
                                    else
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart++;
                                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    // add end 2009/06/22 by gejun for RedMine #10103
                                    string yearDiv = this.uGrid_Details.ActiveCell.Text;
                                    if (CheckYearDiv(yearDiv))
                                    {
                                        this.uGrid_Details.ActiveCell.Value = yearDiv;
                                        this.focusMoveType = 1; // add 2009/06/23 by gejun for RedMine #10103
                                        //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();  //DEL 2010/05/21 GEJUN FOR REDMINE#8049
                                        //uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate(); //ADD 2010/05/21 GEJUN FOR REDMINE#8049 DEL 2010/06/23 GEJUN FOR REDMINE#10103
                                        //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate(); // ADD 2010/06/23 GEJUN FOR REDMINE#10103
                                        //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 1, true);
                                    }
                                    // ADD 2010/07/01------>>>
                                    else
                                    {
                                        SetCellBeforeValue(colKey, rowIndex, colIndex);
                                        return;
                                    }
                                    // ADD 2010/07/01------>>>
                                }// add 2009/06/22 by gejun for RedMine #10103
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals("���Y�ԑ�ԍ�"))
                            {
                                // add start 2009/06/23 by gejun for RedMine #10103
                                int selEnd = activeCell.SelStart + activeCell.SelLength;
                                if (selEnd < 19)
                                {
                                    if (selEnd == 8)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = selEnd + 3;
                                    else if (selEnd == 9)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = selEnd + 2;
                                    else
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart++;
                                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    // add end 2009/06/23 by gejun for RedMine #10103
                                    //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                    //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 1, true);
                                } // add 2009/06/23 by gejun for RedMine #10103
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_BLCODE_TITLE))
                            {
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 2, true);
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_PARTSQTY_TITLE))
                            {
                                this.focusMoveType = 1;// add 2009/06/22 by gejun for RedMine #10103
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 2, true);
                            }
                            else
                            {
                                GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 1, true);
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
						}
						else
						{
                            if (this.uGrid_Details.Rows.Count < MAX_ROW_COUNT
                                && rowIndex == (this.uGrid_Details.Rows.Count - 1))//ADD 2010/05/21 GEJUN FOR REDMINE#8049
							{
                                if (activeCell.SelStart < activeCell.Value.ToString().Length)
                                {
                                    if (activeCell.SelText.Length > 0)
                                        uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelLength + activeCell.SelStart;
                                    else
                                        uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[activeCell.Column.Index].SelStart++;
                                    uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    AddNewDetailRow();
                                    SettingGrid();
                                    uGrid.Rows[rowIndex + 1].Cells[1].Activate();
                                    uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
							}
                            //ADD START 2010/05/21 GEJUN FOR REDMINE#8049
                            else if(rowIndex < (this.uGrid_Details.Rows.Count - 1))
                            {
                                //uGrid.Rows[rowIndex + 1].Cells[1].Activate();
                                //uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                                GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex + 1, 1, true);
                            }
                            //ADD END 2010/05/21 GEJUN FOR REDMINE#8049
						}
						break;
					}
               }
		}

		/// <summary>
		/// �O���b�h�L�[�v���X�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

			//----------------------------------------------
			// �R�[�h�֌W��UI�ݒ�Ń`�F�b�N
			//----------------------------------------------
			if (cell.IsInEditMode)
			{
				// �t�h�ݒ���Q��
				if (uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
				{
					e.Handled = true;
					return;
				}
			}

			//----------------------------------------------
			// ActiveCell�����[�J�[�̏ꍇ
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE)
			{
				// �ҏW���[�h���H
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}

			//----------------------------------------------
			// ActiveCell��BL�R�[�h�̏ꍇ
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE)
			{
				// �ҏW���[�h���H
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}

			//----------------------------------------------
			// ActiveCell��QTY�̏ꍇ
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_PARTSQTY_TITLE)
			{
				// �ҏW���[�h���H
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}

			//----------------------------------------------
			// ActiveCell���W�����i�̏ꍇ
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_COSTRATE_TITLE)
			{
				// �ҏW���[�h���H
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(7, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}

			//----------------------------------------------
			// ActiveCell���ޱ�̏ꍇ
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_DOORCOUNT_TITLE)
			{
				// �ҏW���[�h���H
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}
		}
        // add start 2009/06/22 by gejun for RedMine #10103
        /// <summary>
        /// �O���b�h�Z���ҏW���[�h������C�x���g
        /// </summar>y
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_AfterEnterEditMode(object sender, EventArgs e)
        {
            UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = 0;
            if (cell == null) return;
            rowIndex = cell.Row.Index;
            if (focusMoveType != 0)
            {
                // ���Y�N��
                if (uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].IsInEditMode)
                {
                    if (focusMoveType == 1)
                        cell.SelStart = 0;
                    else
                        cell.SelStart = 10;
                    cell.SelLength = 7;
                }
                // ���Y�ԑ�ԍ�
                if (uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_CREATECARNO_TITLE].IsInEditMode)
                {
                    if (focusMoveType == 1)
                        cell.SelStart = 0;
                    else
                        cell.SelStart = 11;
                    cell.SelLength = 8;
                }
                focusMoveType = 0;
            }
        }

        // add end 2009/06/22 by gejun for RedMine #10103
		/// <summary>
		/// �O���b�h�Z���A�b�v�f�[�g��C�x���g
		/// </summar>y
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

			// �s�C���f�b�N�X
			int rowIndex = GetActiveRowIndex();
            // �O���[�v�̃f�[�^���X�V����
            string fullModelGroup = this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_FULLMODELGROUP_TITLE].Text;
			// �X�V�����DataRow
			DataRow dr = this._detailDataTable.Rows[rowIndex];
			FreeSearchParts freeSearchParts = null;
			if (this._freeSearchPartsDty.ContainsKey(dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].ToString()))
			{

				freeSearchParts = this._freeSearchPartsDty[dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].ToString()];
				if (freeSearchParts.DataStatus == DATASTATUSCODE_0)
				{
					// �f�[�^�X�e�[�^�X:�@1 ���C
					freeSearchParts.DataStatus = DATASTATUSCODE_1;
				}

				// ���[�J�[�R�[�h
				if (freeSearchParts.MakerCode == 0)
				{
					freeSearchParts.MakerCode = this._makerCode;
				}
				// �Ԏ�R�[�h
				if (freeSearchParts.ModelCode == 0)
				{
					freeSearchParts.ModelCode = this._modelCode;
				}
				// �Ԏ�T�u�R�[�h
				if (freeSearchParts.ModelSubCode == 0)
				{
					freeSearchParts.ModelSubCode = this._modelSubCode;
				}
				// �^���i�t���^�j
				if (string.IsNullOrEmpty(freeSearchParts.FullModel))
				{
					freeSearchParts.FullModel = this._fullModel;
				}
			}
			else
			{
				freeSearchParts = new FreeSearchParts();
				// ���R�������i�ŗL�ԍ�
				freeSearchParts.FreSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");
				dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = freeSearchParts.FreSrchPrtPropNo;
				// ��ƃR�[�h
				freeSearchParts.EnterpriseCode = this._enterpriseCode;
				// ���[�J�[�R�[�h
				freeSearchParts.MakerCode = this._makerCode;
				// �Ԏ�R�[�h
				freeSearchParts.ModelCode = this._modelCode;
				// �Ԏ�T�u�R�[�h
				freeSearchParts.ModelSubCode = this._modelSubCode;
				// �^���i�t���^�j
				freeSearchParts.FullModel = this._fullModel;
				// �f�[�^�X�e�[�^�X:�@2 �V�K�ǉ��f�[�^
				freeSearchParts.DataStatus = DATASTATUSCODE_2;
				this._freeSearchPartsDty.Add(freeSearchParts.FreSrchPrtPropNo, freeSearchParts);

                //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
                if (!_newLineRowIndexDic.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                    this._newLineRowIndexDic.Add(freeSearchParts.FreSrchPrtPropNo, this._detailDataTable.Rows.Count);
                //ADD END 2009/05/24 GEJUN FOR REDMINE#8049
			}

			#region �i��
			//------------------------------------------------------------
			// ActiveCell���i�Ԃ̏ꍇ
			//------------------------------------------------------------
            if (cell.Column.Key == PMJKN09011UC.COL_GOODSNO_TITLE  && !existCheckFlg)
            {
                //add start 2010/06/24 by gejun for RedMine #10103
                string blCode, makeCode;
                string goodsNoCompStr = "";
                blCode= this.uGrid_Details.Rows[cell.Row.Index].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Value.ToString();
                makeCode = this.uGrid_Details.Rows[cell.Row.Index].Cells[PMJKN09011UC.COL_MAKER_TITLE].Value.ToString();
                if (goodsNoComp.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                    goodsNoCompStr = (string)goodsNoComp[freeSearchParts.FreSrchPrtPropNo];
                //if (!goodsNoCompStr.Equals(cell.Text + makeCode + blCode)) // del 2010/06/29 by gejun for RedMine #10103
                if (!goodsNoCompStr.Equals(cell.Text.Replace("-", string.Empty) + makeCode + blCode)) // add 2010/06/29 by gejun for RedMine #10103
                {
                    //add end 2010/06/24 by gejun for RedMine #10103
                    //string goodsNo = cell.Value.ToString(); del 2010/06/21 by gejun for RedMine #10103
                    string goodsNo = cell.Text; //add 2010/06/21 by gejun for RedMine #10103

                    if (!String.IsNullOrEmpty(goodsNo))
                    {
                        // ���i�ԍ��̐ݒ�
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNO_TITLE] = e.Cell.Text;
                        freeSearchParts.GoodsNo = e.Cell.Text;
                        freeSearchParts.GoodsNoNoneHyphen = e.Cell.Text.Replace("-", string.Empty);
                        // ���i���[�J�[�R�[�h
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_MAKER_TITLE] = 0; //del  2010/06/21 by gejun for RedMine #10103 start
                        //freeSearchParts.GoodsMakerCd = 0;
                        // BL�R�[�h
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = 0; //del  2010/06/21 by gejun for RedMine #10103 start
                        //freeSearchParts.TbsPartsCode = 0;
                        // add start 2010/06/24 by gejun for RedMine #10103
                        // �i��
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = string.Empty;
                        // add end 2010/06/24 by gejun for RedMine #10103
                        // ���iQTY
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_PARTSQTY_TITLE] = string.Empty;
                        //freeSearchParts.PartsQty = 0;
                        // �W�����i
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_COSTRATE_TITLE] = "0";

                        object retObj;

                        switch (this.SearchGoodsAndRemain(goodsNo, out retObj))
                        {
                            case 0:
                                {
                                    if (retObj != null)
                                    {
                                        // ���i����
                                        if (retObj is List<GoodsUnitData>)
                                        {
                                            List<GoodsUnitData> goodsUnitDataList = (List<GoodsUnitData>)retObj;
                                            //���i�ԍ�
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNO_TITLE] = ((GoodsUnitData)goodsUnitDataList[0]).GoodsNo;
                                            freeSearchParts.GoodsNo = ((GoodsUnitData)goodsUnitDataList[0]).GoodsNo;
                                            this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Value = ((GoodsUnitData)goodsUnitDataList[0]).GoodsNo;// add 2010/06/24 by gejun for RedMine #10103

                                            // ���i���[�J�[�R�[�h
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_MAKER_TITLE] = ((GoodsUnitData)goodsUnitDataList[0]).GoodsMakerCd.ToString().PadLeft(4, '0');
                                            freeSearchParts.GoodsMakerCd = ((GoodsUnitData)goodsUnitDataList[0]).GoodsMakerCd;
                                            // BL�R�[�h
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = ((GoodsUnitData)goodsUnitDataList[0]).BLGoodsCode.ToString().PadLeft(5, '0');
                                            freeSearchParts.TbsPartsCode = ((GoodsUnitData)goodsUnitDataList[0]).BLGoodsCode;
                                            // �i��
                                            //>>>2010/07/02
                                            //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = this.GetBLGoodsFullName(Convert.ToInt32(((GoodsUnitData)goodsUnitDataList[0]).BLGoodsCode));
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = ((GoodsUnitData)goodsUnitDataList[0]).GoodsName;
                                            //<<<2010/07/02
                                            // ���iQTY
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_PARTSQTY_TITLE] = 1;
                                            freeSearchParts.PartsQty = 1;

                                            if (((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList != null && ((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList.Count > 0)
                                            {

                                                // �W�����i
                                                GoodsPrice gp = ((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList[0];
                                                if (gp.ListPrice > 999)
                                                    this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_COSTRATE_TITLE] = String.Format("{0:0,0}", gp.ListPrice);
                                                else
                                                    this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_COSTRATE_TITLE] = gp.ListPrice.ToString();
                                            }

                                            this.goodsSearchFlg = true; //add 2010/06/21 by gejun for RedMine #10103
                                            //add 2010/06/25 by gejun for RedMine #10103
                                            //add 2010/06/24 by gejun for RedMine #10103
                                            if (goodsNoComp.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                                                goodsNoComp.Remove(freeSearchParts.FreSrchPrtPropNo);
                                            //goodsNoComp.Add(freeSearchParts.FreSrchPrtPropNo, goodsNo + freeSearchParts.GoodsMakerCd.ToString().PadLeft(4, '0') + freeSearchParts.TbsPartsCode.ToString().PadLeft(5, '0')); // del 2010/06/29 by gejun for RedMine #10103
                                            goodsNoComp.Add(freeSearchParts.FreSrchPrtPropNo, goodsNo.Replace("-", string.Empty) + freeSearchParts.GoodsMakerCd.ToString().PadLeft(4, '0') + freeSearchParts.TbsPartsCode.ToString().PadLeft(5, '0')); // add 2010/06/29 by gejun for RedMine #10103
                                        }
                                    }
                                    break;

                                }
                                // ADD 2010/07/01-------------------->>>
                            case -2:
                                {
                                    if (goodsNoComp.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                                        goodsNoComp.Remove(freeSearchParts.FreSrchPrtPropNo);
                                    goodsNoComp.Add(freeSearchParts.FreSrchPrtPropNo, goodsNo.Replace("-", string.Empty) + freeSearchParts.GoodsMakerCd.ToString().PadLeft(4, '0') + freeSearchParts.TbsPartsCode.ToString().PadLeft(5, '0'));
                                    break;
                                }
                                // ADD 2010/07/01-------------------->>>
                            //case -1:
                            //    {
                            //        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_COSTRATE_TITLE] = String.Empty;�@//ADD 2009/05/20 GEJUN FOR REDMINE#8049
                            //        break;
                            //    }

                        }

                    }

                }//add 2010/06/24 by gejun for RedMine #10103
            }
			#endregion

            #region �Z���̓��e�`�F�b�N
            if (!CheckNumber(cell.Value.ToString(), rowIndex, cell.Column.Key))
            {
                SetCellBeforeValue(cell.Column.Key, rowIndex, uGrid_Details.ActiveCell.Column.Index);
                return;
            }
            if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(cell.Column.Key))
            {

                // if (!CheckYearDiv(this.uGrid_Details.ActiveCell.Text))// del 2009/06/22 by gejun for RedMine #10103
                if (!CheckYearDiv(cell.Text))// add 2009/06/22 by gejun for RedMine #10103
                {
                    //SetCellBeforeValue(cell.Column.Key, rowIndex, uGrid_Details.ActiveCell.Column.Index);// del 2009/06/22 by gejun for RedMine #10103
                    SetCellBeforeValue(cell.Column.Key, rowIndex, cell.Column.Index);// add 2009/06/22 by gejun for RedMine #10103
                    return;
                }
            }
            #endregion

            #region BL�R�[�h
            //------------------------------------------------------------
            // ActiveCell���uBL�R�[�h�v�̏ꍇ
            //------------------------------------------------------------
            else if (cell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE && !existCheckFlg)
            {
                int blCode = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                if (blCode != 0)
                {
                    //-----------------------------------------------------------------------------
                    // BL�R�[�h����
                    //-----------------------------------------------------------------------------
                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    List<Stock> stockList = new List<Stock>();
                    // del start 2010/06/29 by gejun for RedMine #10103
                    //// BL�R�[�h�̐ݒ�
                    //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = blCode.ToString().PadLeft(5, '0');
                    //freeSearchParts.TbsPartsCode = blCode;
                    // del end 2010/06/29 by gejun for RedMine #10103
                    BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
                    BLGoodsCdUMnt bLGoodsCdUMnt;

                    int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //>>>2010/07/02
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = bLGoodsCdUMnt.BLGoodsFullName;
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName;
                        //<<<2010/07/02
                        // add start 2010/06/29 by gejun for RedMine #10103
                        // BL�R�[�h�̐ݒ�
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = blCode.ToString().PadLeft(5, '0');
                        freeSearchParts.TbsPartsCode = blCode;
                        // add end 2010/06/29 by gejun for RedMine #10103
                    }
                    else
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "BL�R�[�h [" + blCode.ToString() + "] �ɊY������f�[�^�����݂��܂���B",
                           -1,
                           MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            #endregion

            #region ���[�J�[
            //------------------------------------------------------------
            // ActiveCell���u���[�J�[�v�̏ꍇ
            //------------------------------------------------------------
            if (cell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE && !existCheckFlg)
            {
                //add start 2010/06/21 by gejun for RedMine #10103
                if (TStrConv.StrToIntDef(cell.Value.ToString(), 0) != 0)
                {
                    //add end 2010/06/21 by gejun for RedMine #10103
                    if (!String.IsNullOrEmpty(e.Cell.Text))
                    {
                        // add start 2010/06/24 by gejun for RedMine #10103
                        MakerAcs makerAcs = new MakerAcs();
                        MakerUMnt makerUMnt;
                        //���[�J�[�f�[�^�̎擾
                        int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, TStrConv.StrToIntDef(e.Cell.Text, 0));
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "���[�J�[�R�[�h [" + e.Cell.Text + "] �ɊY������f�[�^�����݂��܂���B",
                               -1,
                               MessageBoxButtons.OK);
                        }
                        // add�@end 2010/06/24 by gejun for RedMine #10103
                        dr[PMJKN09011UC.COL_MAKER_TITLE] = e.Cell.Text.PadLeft(4, '0');
                        freeSearchParts.GoodsMakerCd = Convert.ToInt32(e.Cell.Text);
                    }
                    else
                    {
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_MAKER_TITLE] = 0;
                        freeSearchParts.GoodsMakerCd = 0;
                    }
                }//add  2010/06/21 by gejun for RedMine #10103
            }
            #endregion

			#region QTY
			//------------------------------------------------------------
			// ActiveCell���uQTY�v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_PARTSQTY_TITLE)
			{
                if (!String.IsNullOrEmpty(e.Cell.Text))
                {
                    dr[PMJKN09011UC.COL_PARTSQTY_TITLE] = Convert.ToInt32(e.Cell.Text);
                    freeSearchParts.PartsQty = Convert.ToInt32(e.Cell.Text);
                }
                else
                {
                    dr[PMJKN09011UC.COL_PARTSQTY_TITLE] = 0;
                    freeSearchParts.PartsQty = 0;
                }
			}
			#endregion

			#region ���Y�N��
			//------------------------------------------------------------
			// ActiveCell���u���Y�N���v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_CREATEYEAR_TITLE)
			{

				if (!String.IsNullOrEmpty(e.Cell.Text))
				{

                    // string yearDiv = this.uGrid_Details.ActiveCell.Text;// del 2009/06/22 by gejun for RedMine #10103
                    string yearDiv = cell.Text;// add 2009/06/22 by gejun for RedMine #10103
					String[] createYear = e.Cell.Text.Split('-');
					createYear[0] = createYear[0].Trim();
					createYear[1] = createYear[1].Trim();
                    // �`�F�b�N
                    if (!CheckYearDiv(yearDiv))
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }

                    if (!createYear[0].Equals("____.__") && !createYear[1].Equals("____.__"))
                    {
                        DateTime stCreateYear = DateTime.Parse(createYear[0]);
                        DateTime edCreateYear = DateTime.Parse(createYear[1]);
                        dr[PMJKN09011UC.COL_CREATEYEAR_TITLE] = e.Cell.Text;
                        // �^���ʕ��i�̗p�N��
                        freeSearchParts.ModelPrtsAdptYm = stCreateYear;
                        // �^���ʕ��i�p�~�N��
                        freeSearchParts.ModelPrtsAblsYm = edCreateYear;
                    }
                    // ADD 2010/07/02 ------>>>
                    else
                    {
                        // �^���ʕ��i�̗p�N��
                        freeSearchParts.ModelPrtsAdptYm = DateTime.MinValue;
                        // �^���ʕ��i�p�~�N��
                        freeSearchParts.ModelPrtsAblsYm = DateTime.MinValue;
                    }
                    // ADD 2010/07/02 ------>>>    
                    return;
				}
			}
			#endregion

			#region ���Y�ԑ�ԍ�
			//------------------------------------------------------------
			// ActiveCell���u���Y�ԑ�ԍ��v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_CREATECARNO_TITLE)
			{

				if (!String.IsNullOrEmpty(e.Cell.Value.ToString()))
                {
                    String[] createCarNo = e.Cell.Value.ToString().Trim().Split('-');
					int stCreateCarNo = 0;
                    int EdCreateCarNo = 0;
                    if (!CheckCarNo(e.Cell.Value.ToString()))
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_CREATECARNO_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }

                    // ADD 2010/07/02 ------>>>
                    if (!string.IsNullOrEmpty(e.Cell.Value.ToString().Trim()))
                    {
                    // ADD 2010/07/02 ------>>>
                        if (!string.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
                        {
                            stCreateCarNo = Convert.ToInt32(createCarNo[0].Trim().Replace("_", string.Empty));
                        }

                        if (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________"))
                        {
                            EdCreateCarNo = Convert.ToInt32(createCarNo[1].Trim().Replace("_", string.Empty));
                        }
                    } // ADD 2010/07/02 ------>>>

                    string createcarNo = "";
                    if (stCreateCarNo != 0)
                    {
                        createcarNo = createcarNo + stCreateCarNo.ToString().PadLeft(8, '_');
                    }
                    else
                    {
                        createcarNo = createcarNo + "________";
                    }
                    createcarNo = createcarNo + " - ";
                    if (EdCreateCarNo != 0)
                    {
                        createcarNo = createcarNo + EdCreateCarNo.ToString().PadLeft(8, '_');
                    }
                    else
                    {
                        createcarNo = createcarNo + "________";
                    }

                    //dr[PMJKN09011UC.COL_CREATECARNO_TITLE] = e.Cell.Text;
                    dr[PMJKN09011UC.COL_CREATECARNO_TITLE] = createcarNo;
					// �^���ʕ��i�̗p�ԑ�ԍ�
					freeSearchParts.ModelPrtsAdptFrameNo = stCreateCarNo;
					// �^���ʕ��i�p�~�ԑ�ԍ�
					freeSearchParts.ModelPrtsAblsFrameNo = EdCreateCarNo;
				}
			}
			#endregion

			#region �O���[�h
			//------------------------------------------------------------
			// ActiveCell���u�O���[�h�v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_MODELGRADENM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_MODELGRADENM_TITLE] = e.Cell.Text;
					freeSearchParts.ModelGradeNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_MODELGRADENM_TITLE] = string.Empty;
					freeSearchParts.ModelGradeNm = string.Empty;
				}
			}
			#endregion

			#region �{�f�B
			//------------------------------------------------------------
			// ActiveCell���u�{�f�B�v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_BODYNAME_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_BODYNAME_TITLE] = e.Cell.Text;
					freeSearchParts.BodyName = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_BODYNAME_TITLE] = string.Empty;
					freeSearchParts.BodyName = string.Empty;
				}
			}
			#endregion

			#region �h�A
			//------------------------------------------------------------
			// ActiveCell���u�h�A�v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_DOORCOUNT_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text) && e.Cell.Text != "0")
				{
					dr[PMJKN09011UC.COL_DOORCOUNT_TITLE] = Convert.ToInt32(e.Cell.Text);
					freeSearchParts.DoorCount = Convert.ToInt32(e.Cell.Text);
				}
				else
				{
					dr[PMJKN09011UC.COL_DOORCOUNT_TITLE] = string.Empty;
					freeSearchParts.DoorCount = 0;
				}
			}
			#endregion

			#region �G���W��
			//------------------------------------------------------------
			// ActiveCell���u�G���W���v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_ENGINEMODELNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_ENGINEMODELNM_TITLE] = e.Cell.Text;
					freeSearchParts.EngineModelNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_ENGINEMODELNM_TITLE] = string.Empty;
					freeSearchParts.EngineModelNm = string.Empty;
				}
			}
			#endregion

			#region �r�C��
			//------------------------------------------------------------
			// ActiveCell���u�r�C�ʁv�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE] = e.Cell.Text;
					freeSearchParts.EngineDisplaceNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE] = string.Empty;
					freeSearchParts.EngineDisplaceNm = string.Empty;
				}
			}
			#endregion

			#region E�敪
			//------------------------------------------------------------
			// ActiveCell���uE�敪�v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_EDIVNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_EDIVNM_TITLE] = e.Cell.Text;
					freeSearchParts.EDivNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_EDIVNM_TITLE] = string.Empty;
					freeSearchParts.EDivNm = string.Empty;
				}
			}
			#endregion

			#region �~�b�V����
			//------------------------------------------------------------
			// ActiveCell���u�~�b�V�����v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_TRANSMISSIONNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE] = e.Cell.Text;
					freeSearchParts.TransmissionNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE] = string.Empty;
					freeSearchParts.TransmissionNm = string.Empty;
				}
			}
			#endregion

			#region �쓮�`��
			//------------------------------------------------------------
			// ActiveCell���u�쓮�`���v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE] = e.Cell.Text;
					freeSearchParts.WheelDriveMethodNm = e.Cell.Text;

				}
				else
				{
					dr[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE] = string.Empty;
					freeSearchParts.WheelDriveMethodNm = string.Empty;
				}
			}
			#endregion

			#region �V�t�g
			//------------------------------------------------------------
			// ActiveCell���u�V�t�g�v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_SHIFTNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_SHIFTNM_TITLE] = e.Cell.Text;
					freeSearchParts.ShiftNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_SHIFTNM_TITLE] = string.Empty;
					freeSearchParts.ShiftNm = string.Empty;
				}
			}
			#endregion

			#region �E�v
			//------------------------------------------------------------
			// ActiveCell���u�E�v�v�̏ꍇ
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_ADDICARSPEC_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_ADDICARSPEC_TITLE] = e.Cell.Text;
					freeSearchParts.PartsOpNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_ADDICARSPEC_TITLE] = string.Empty;
					freeSearchParts.PartsOpNm = string.Empty;
				}
			}
			#endregion

			if (!string.IsNullOrEmpty(fullModelGroup))
			{
				foreach (FreeSearchParts fsp in this._freeSearchPartsDty.Values)
				{
					if (fullModelGroup == fsp.FullModelGroup)
					{
						// �i��
						fsp.GoodsNo = freeSearchParts.GoodsNo;
						// ���[�J�[
						fsp.GoodsMakerCd = freeSearchParts.GoodsMakerCd;
						// BL�R�[�h
						fsp.TbsPartsCode = freeSearchParts.TbsPartsCode;
						// QTY
						fsp.PartsQty = freeSearchParts.PartsQty;
						// ���Y�N��
						fsp.ModelPrtsAdptYm = freeSearchParts.ModelPrtsAdptYm;
						fsp.ModelPrtsAblsYm = freeSearchParts.ModelPrtsAblsYm;
						// ���Y�ԑ�ԍ�
						fsp.ModelPrtsAdptFrameNo = freeSearchParts.ModelPrtsAdptFrameNo;
						fsp.ModelPrtsAblsFrameNo = freeSearchParts.ModelPrtsAblsFrameNo;
						// ��ڰ��
						fsp.ModelGradeNm = freeSearchParts.ModelGradeNm;
						// ���ި
						fsp.BodyName = freeSearchParts.BodyName;
						// �ޱ
						fsp.DoorCount = freeSearchParts.DoorCount;
						// �ݼ��
						fsp.EngineModelNm = freeSearchParts.EngineModelNm;
						// �r�C��
						fsp.EngineDisplaceNm = freeSearchParts.EngineDisplaceNm;
						// E�敪
						fsp.EDivNm = freeSearchParts.EDivNm;
						// Я���
						fsp.TransmissionNm = freeSearchParts.TransmissionNm;
						// �쓮�`��
						fsp.WheelDriveMethodNm = freeSearchParts.WheelDriveMethodNm;
						// ���
						fsp.ShiftNm = freeSearchParts.ShiftNm;
						// �E�v
						fsp.PartsOpNm = freeSearchParts.PartsOpNm;

						if (fsp.DataStatus == DATASTATUSCODE_0)
						{
							// �f�[�^�X�e�[�^�X:�@1 ���C
							fsp.DataStatus = DATASTATUSCODE_1;
						}
					}
				}
			}


			// ���׃O���b�h�ݒ菈��
			this.SettingGrid();
		}

		/// <summary>
		/// �c�[���o�[�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
            if (!("ButtonTool_Guid".Equals(e.Tool.Key) || "ButtonTool_RowDelete".Equals(e.Tool.Key)
                || "ButtonTool_AllDelete".Equals(e.Tool.Key) // ADD 2010/07/01
                || "ButtonTool_Insert".Equals(e.Tool.Key) || "ButtonTool_Save".Equals(e.Tool.Key))) // ADD 2009/05/21 GEJUN FOR REDMINE#8049
            {
                //ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(true, true, true, Keys.Enter, _prevControl, _lastControl); //DEL 2010/07/01 -------------->>
                ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(true, true, true, Keys.None, _prevControl, _lastControl); //ADD 2010/07/01 -------------->>
                this.tArrowKeyControl1_ChangeFocus(sender, changeFocusEventArgs);
            }// ADD 2009/05/21 GEJUN FOR REDMINE#8049

            // add start 2009/06/24 by gejun for RedMine #10103
            if ("ButtonTool_Save".Equals(e.Tool.Key))
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    UltraGridCell cell = this.uGrid_Details.ActiveCell;
                    CellEventArgs cellEventArgs = new CellEventArgs(cell);
                    existCheckFlg = true;
                    uGrid_Details_AfterCellUpdate(this, cellEventArgs);
                }
            }
            // add end 2009/06/24 by gejun for RedMine #10103
			switch (e.Tool.Key)
			{
				#region �I������
				//--------------------------------------------------
				// �I������
				//--------------------------------------------------
				case "ButtonTool_Close":
					{
						this.Close(true);
						break;
					}
				#endregion

				#region �ۑ�����
				//--------------------------------------------------
				// �ۑ�����
				//--------------------------------------------------
				case "ButtonTool_Save":
					{

                        //this.Save(); // DEL 2010/07/01------------>>>
                        this.Save(true); // ADD 2010/07/01------------>>>
						break;
					}
				#endregion

				#region ��������
				//--------------------------------------------------
				// ��������
				//--------------------------------------------------
				case "ButtonTool_Search":
					{
						this.Search();
						break;
					}
				#endregion

				#region �N���A����
				//--------------------------------------------------
				// �N���A����
				//--------------------------------------------------
				case "ButtonTool_Clear":
					{
						this.Clear(true);
						break;
					}
				#endregion

				#region �s�폜����
				//--------------------------------------------------
				// �s�폜����
				//--------------------------------------------------
				case "ButtonTool_RowDelete":
					{
						this.DeleteDetailRow();
						break;
					}
				#endregion
                // ADD 2010/07/01------------>>>
                #region �S�폜����
                //--------------------------------------------------
                // �S�폜����
                //--------------------------------------------------
                case "ButtonTool_AllDelete":
                    {
                        this.DeleteAllDetailRow();
                        break;
                    }
                #endregion
                // ADD 2010/07/01------------>>>
				#region �K�C�h
				//--------------------------------------------------
				// �K�C�h
				//--------------------------------------------------
				case "ButtonTool_Guid":
					{
						// �K�C�h�N������
						this.ExecuteGuide();
						break;
					}
				#endregion

				#region ���p�o�^����
				//--------------------------------------------------
				// ���p�o�^����
				//--------------------------------------------------
				case "ButtonTool_Insert":
					{
						this.QuoteWrite();
						break;
					}
				#endregion


				#region �ŐV��񏈗�
				//--------------------------------------------------
				// �ŐV��񏈗�
				//--------------------------------------------------
				case "ButtonTool_LoadData":
					{
						this.Renewal();
						break;
					}
				#endregion
			}
		}

		#region ���K�C�h�{�^���N���b�N�C�x���g
		/// <summary>
		/// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_CmpltGoodsMakerGuide_Click(object sender, EventArgs e)
		{
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;

			//���[�J�[�f�[�^�̎擾
			int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //���[�J�[
                this.tNedit_CmpltGoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                this.tEdit_CmpltMakerName.Text = makerUMnt.MakerName;
				// ���̍��ڂփt�H�[�J�X�ړ�
			}
		}

		/// <summary>
		/// BL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_BlCodeGuide_Click(object sender, EventArgs e)
		{
			BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
			BLGoodsCdUMnt bLGoodsCdUMnt;
			//BL�R�[�h�f�[�^�̎擾
			int status = bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //BL�R�[�h
                this.tNedit_BlCd.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                //>>>2010/07/02
                //this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsFullName;
                this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsHalfName;
                //<<<<2010/07/02
                // ���̍��ڂփt�H�[�J�X�ړ�
			}
		}

		/// <summary>
		/// tNedit_CmpltGoodsMakerCd_AfterExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_CmpltGoodsMakerCd_AfterExitEditMode(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.tNedit_CmpltGoodsMakerCd.Text))
			{
				MakerAcs makerAcs = new MakerAcs();
				MakerUMnt makerUMnt;
				int makerCode = this.tNedit_CmpltGoodsMakerCd.GetInt();
				//���[�J�[�f�[�^�̎擾
				int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					//���[�J�[
					this.tNedit_CmpltGoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
					this.tEdit_CmpltMakerName.Text = makerUMnt.MakerName;
				}
				else
				{
                    DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�Y���f�[�^������܂���B",
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                    this.tEdit_CmpltMakerName.Clear();
                    this.tNedit_CmpltGoodsMakerCd.Clear();
					this.tNedit_CmpltGoodsMakerCd.Focus();
                    // �K�C�h
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
				}
			}
			else
			{
				this.tEdit_CmpltMakerName.Clear();
			}

		}

		/// <summary>
		/// tNedit_BlCd_AfterExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_BlCd_AfterExitEditMode(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.tNedit_BlCd.Text))
			{
				BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
				BLGoodsCdUMnt bLGoodsCdUMnt;
				int blcd = this.tNedit_BlCd.GetInt();
				//BL�R�[�h�f�[�^�̎擾
				int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blcd);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					//BL�R�[�h
					this.tNedit_BlCd.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                    //>>>2010/07/02
                    //this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsFullName;
                    this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsHalfName;
                    //<<<2010/07/02
                }
				else
				{
                    DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�Y���f�[�^������܂���B",
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                    this.tEdit_BlName.Clear();
                    this.tNedit_BlCd.Clear();
					this.tNedit_BlCd.Focus();
                    // �K�C�h
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
				}
			}
			else
			{
				this.tEdit_BlName.Clear();
			}
		}

		/// <summary>
		/// �O���b�h�������C�A�E�g�ݒ�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// �O���b�h�񏉊��ݒ菈��
			this.InitialSettingGridCol();
		}
		#endregion

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�E�C���^�[�i�����\�b�h
		// ===================================================================================== //
		# region Private Methods and Internal Methods

		# region [���q���ێ��p]
		/// <summary>
		/// ���q���ێ��p
		/// </summary>
		private struct BeforeCarSearchBuffer
		{
			/// <summary>�ԑ�ԍ�(�J�n)</summary>
			private string _startProduceFrameNo;
			/// <summary>�ԑ�ԍ�(�I��)</summary>
			private string _endProduceFrameNo;
			/// <summary>���Y�N��(�J�n)</summary>
			private int _startEntryDate;
			/// <summary>���Y�N��(�I��)</summary>
			private int _endEntryDate;
			/// <summary>
			/// �ԑ�ԍ�(�J�n)
			/// </summary>
			public string StartProduceFrameNo
			{
				get { return _startProduceFrameNo; }
				set { _startProduceFrameNo = value; }
			}
			/// <summary>
			/// �ԑ�ԍ�(�I��)
			/// </summary>
			public string EndProduceFrameNo
			{
				get { return _endProduceFrameNo; }
				set { _endProduceFrameNo = value; }
			}
			/// <summary>
			/// ���Y�N��(�J�n)
			/// </summary>
			public int StartEntryDate
			{
				get { return _startEntryDate; }
				set { _startEntryDate = value; }
			}
			/// <summary>
			/// ���Y�N��(�I��)
			/// </summary>
			public int EndEntryDate
			{
				get { return _endEntryDate; }
				set { _endEntryDate = value; }
			}
			/// <summary>
			/// ������
			/// </summary>
			public void Clear()
			{
				_startProduceFrameNo = string.Empty;
				_endProduceFrameNo = string.Empty;
				_startEntryDate = 0;
				_endEntryDate = 0;
			}
		}
		# endregion

		# region �� �ŐV��񏈗� ��
		/// <summary>
		/// ��ʍŐV��񏈗�
		/// </summary>
		/// <remarks>
		/// <br>Note        : �ŐV�����N���b�N���ɔ������܂��B</br>      
		/// <br>Programmer  : �я���</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void Renewal()
		{
			this.RenewalProc();
		}

		/// <summary>
		/// ��ʍŐV��񏈗�
		/// </summary>
		/// <remarks>
		/// <br>Note        : �ŐV�����N���b�N���ɔ������܂��B</br>      
		/// <br>Programmer  : �я���</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void RenewalProc()
		{
			// �Ԏ햼�̃}�X�^
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			ModelNameU modelNameU = new ModelNameU();
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
			if (this.tNedit_MakerCode.GetInt() != 0)
			{
				status = modelNameUAcs.Read(out modelNameU, this._enterpriseCode, this.tNedit_MakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt()); ;
			}
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tNedit_MakerCode.SetInt(modelNameU.MakerCode);
				this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
				this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
				this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
			}

			// ���[�J�[�}�X�^
			int status1 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			MakerUMnt makerUMnt = new MakerUMnt();
			if (this.tNedit_CmpltGoodsMakerCd.GetInt() != 0)
			{
				status1 = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_CmpltGoodsMakerCd.GetInt());
			}
			if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tEdit_CmpltMakerName.Text = makerUMnt.MakerName;
			}

			// BL�R�[�h�}�X�^
			int status2 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
			if (this.tNedit_BlCd.GetInt() != 0)
			{
				status2 = this._bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, this.tNedit_BlCd.GetInt());
			}
			if (status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //>>>2010/07/02
                //this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsFullName;
                this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsHalfName;
                //<<<2010/07/02
            }

			string msg = "�ŐV�����擾���܂����B";
			// ���b�Z�[�W��\��
			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_INFO,
				this.Name,
				msg,
				0,
				MessageBoxButtons.OK,
				MessageBoxDefaultButton.Button1);
			if (dialogResult == DialogResult.Yes)
			{
				return;
			}
		}
		# endregion

		# region ����ʏ��擾

		/// <summary>
		/// ��ʌ���������񎩗R�������i�N���X�i�[����
		/// </summary>
		/// <returns>���R�������i�N���X�i���������j</returns>
		/// <remarks>
		/// <br>Note       : ��ʌ���������񂩂玩�R�������i�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer	: �я���</br>	
		/// <br>Date		: 2010/04/26</br>
		/// </remarks>
		private FreeSearchParts DispCondToFreeSearchParts()
		{
			FreeSearchParts freeSearchParts = new FreeSearchParts();
			freeSearchParts.EnterpriseCode = _enterpriseCode;
			//�Ԏ�R�[�h
			freeSearchParts.ModelCode = this.tNedit_ModelCode.GetInt();
			//�Ԏ�T�u�R�[�h
			freeSearchParts.ModelSubCode = this.tNedit_ModelSubCode.GetInt();
			//���[�J�[�R�[�h
			freeSearchParts.MakerCode = this.tNedit_MakerCode.GetInt();
            //�^���z��i�t���^�j
            List<string> fullModelList = new List<string>();
            string fullModel;
            StringBuilder fullModelSb = new StringBuilder();
            foreach (DataRow carModelInfoRow in this._selectCarModelInfoDataTable.Rows)
            {
                fullModel = carModelInfoRow["FullModel"].ToString();
                if (!string.IsNullOrEmpty(fullModel))
                {
                    if (!fullModelList.Contains(fullModel))
                    {
                        fullModelList.Add(fullModel);
                    }
                }
            }
            for(int i = 0; i < fullModelList.Count; i++)
            {
                if (i != 0)
                {
                    fullModelSb.Append('\t');
                }
                fullModelSb.Append(fullModelList[i]);
            }
            freeSearchParts.FullModel = fullModelSb.ToString();
			// ���i���[�J�[�R�[�h
			freeSearchParts.GoodsMakerCd = this.tNedit_CmpltGoodsMakerCd.GetInt();
			//BL�R�[�h
			freeSearchParts.TbsPartsCode = this.tNedit_BlCd.GetInt();
			//���i�ԍ�
			freeSearchParts.GoodsNo = this.tEdit_GoodsNo.Text.ToString();
			//�i�ԏ���
			freeSearchParts.GoodsNoFuzzy = Convert.ToInt32(this.tComboEditor_GoodsNoFuzzy.SelectedIndex);

			return freeSearchParts;
		}
		#endregion

		/// <summary>
		/// �ۑ��f�[�^�`�F�b�N����
		/// </summary>
		/// <returns></returns>
		private bool CheckSaveData()
		{
			bool flg = true;
            bool checkFlg = false;
            bool checkFlgTemp = false;
            int lastRowIndex = 0;

			#region ��ʓ��͒l�`�F�b�N

            if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() == 0))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�^���w����͎��́A�ޕʋ敪�͕K�{���͂ł��B",
                           0,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
                this.tNedit_CategoryNo.Focus();
                return false;
            }
            // add start 2009/06/24 by gejun for RedMine #10103
            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                UltraGridRow row = this.uGrid_Details.Rows[i];
                for(int j = 1; j < row.Cells.Count; j++)
                {
                    if (PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE.Equals(row.Cells[j].Column.Key) ||
                       PMJKN09011UC.COL_FULLMODELGROUP_TITLE.Equals(row.Cells[j].Column.Key))
                        continue;

                    if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(row.Cells[j].Column.Key))
                    {
                        if (!"____.__ - ____.__".Equals(row.Cells[j].Text.Trim()))
                        {
                            checkFlgTemp = true;
                            break;
                        }
                    }
                    else if (PMJKN09011UC.COL_CREATECARNO_TITLE.Equals(row.Cells[j].Column.Key))
                    {
                        if (!"________ - ________".Equals(row.Cells[j].Text.Trim()))
                        {
                            checkFlgTemp = true;
                            break;
                        }
                    }
                    else if (!"".Equals(row.Cells[j].Text.Trim()))
                    {
                        checkFlgTemp = true;
                        break;
                    }
                }
                // �Y�����R�[�h�����͂���
                if (checkFlgTemp)
                {
                    checkFlg = true;
                    lastRowIndex = -1;
                    checkFlgTemp = false;
                }
                // �Y�����R�[�h��
                else
                {
                    if(lastRowIndex < 0)
                        lastRowIndex = i; 
                }

            }

            if (!checkFlg)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                  this,
                  emErrorLevel.ERR_LEVEL_EXCLAMATION,
                  this.Name,
                  "���ׂ����͂���Ă��܂���B",
                  0,
                  MessageBoxButtons.OK,
                  MessageBoxDefaultButton.Button1);

                // �w��t�H�[�J�X�ݒ菈��
                this.uGrid_Details.Rows[0].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Activate();
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return false;
            }
            // add end 2009/06/24 by gejun for RedMine #10103


			for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
			{
                if (lastRowIndex >= 0 && i >= lastRowIndex )
                    continue;
                // del start 2010/06/24 by gejun for RedMine #10103
                //checkFlg = false;
                //if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text) ||
                //           !string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text) ||
                //           !string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Text) ||
                //           !string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Text))
                // del end 2010/06/24 by gejun for RedMine #10103

                // ���R�������i�ŗL�ԍ�
                string freeSearchParts = this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;

                if (_freeSearchPartsDty.Keys.Count == 0 || this._freeSearchPartsDty.ContainsKey(freeSearchParts))
                {
                    //�i��
                    if (string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Text))
                    {
                        // del start 2010/06/24 by gejun for RedMine #10103
                        //if ((this._newLineRowIndexDic.ContainsKey(freeSearchParts) && checkFlg) || !this._newLineRowIndexDic.ContainsKey(freeSearchParts))
                        //{
                        // del end 2010/06/24 by gejun for RedMine #10103
                       
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�i�Ԃ���͂��ĉ������B",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            // �w��t�H�[�J�X�ݒ菈��
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            return false;
                     //} del 2010/06/24 by gejun for RedMine #10103
                    }
                    //���[�J�[
                    if (string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text)
                        || (this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text != null
                        && Convert.ToInt32(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text) == 0))
                    {
                        // del start 2010/06/24 by gejun for RedMine #10103
                        //if ((this._newLineRowIndexDic.ContainsKey(freeSearchParts) && checkFlg) || !this._newLineRowIndexDic.ContainsKey(freeSearchParts))
                        //{
                        // del end 2010/06/24 by gejun for RedMine #10103
                        DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "���[�J�[����͂��ĉ������B",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                        // �w��t�H�[�J�X�ݒ菈��
                        this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        return false;
                        //} del 2010/06/24 by gejun for RedMine #10103
                    }
                    // add start 2010/06/24 by gejun for RedMine #10103
                    else
                    {
                        MakerAcs makerAcs = new MakerAcs();
                        MakerUMnt makerUMnt;
                        int makeCd = TStrConv.StrToIntDef(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text, 0);
                        int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makeCd);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                         
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "���[�J�[�R�[�h [" + makeCd.ToString() + "] �ɊY������f�[�^�����݂��܂���B",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                            // �w��t�H�[�J�X�ݒ菈��
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            SetCellBeforeValue(PMJKN09011UC.COL_MAKER_TITLE, i, this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Column.Index); // add  2010/06/29 by gejun for RedMine #10103

                            return false;
                        }
                    }
                    // add end 2010/06/24 by gejun for RedMine #10103
                    //BL�R�[�h
                    if (string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text)
                        || (this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text != null
                        && Convert.ToInt32(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text) == 0))
                    {
                        // del start 2010/06/24 by gejun for RedMine #10103
                        //if ((this._newLineRowIndexDic.ContainsKey(freeSearchParts) && checkFlg) || !this._newLineRowIndexDic.ContainsKey(freeSearchParts))
                        //{
                        // del end 2010/06/24 by gejun for RedMine #10103
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "BL�R�[�h����͂��ĉ������B",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            // �w��t�H�[�J�X�ݒ菈��
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            return false;
                        //} del 2010/06/24 by gejun for RedMine #10103
                    }
                    // add start 2010/06/24 by gejun for RedMine #10103
                    else
                    {
                        BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
                        BLGoodsCdUMnt bLGoodsCdUMnt;
                        int blCode = TStrConv.StrToIntDef(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text, 0);
                        int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "BL�R�[�h [" + blCode.ToString() + "] �ɊY������f�[�^�����݂��܂���B",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            // �w��t�H�[�J�X�ݒ菈��
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            SetCellBeforeValue(PMJKN09011UC.COL_BLCODE_TITLE, i, this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Column.Index);// add  2010/06/29 by gejun for RedMine #10103
                            return false;
                        }
                    }
                    //QTY
                    if (string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Text)
                        || (this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Text != null
                        && Convert.ToInt32(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Text) == 0))
                    {
                        // del start 2010/06/24 by gejun for RedMine #10103
                        //if ((this._newLineRowIndexDic.ContainsKey(freeSearchParts) && checkFlg) || !this._newLineRowIndexDic.ContainsKey(freeSearchParts))
                        //{
                        // del end 2010/06/24 by gejun for RedMine #10103
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "QTY����͂��ĉ������B",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            // �w��t�H�[�J�X�ݒ菈��
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            return false;
                        //} del 2010/06/24 by gejun for RedMine #10103
                    }


                    //���Y�N���i�J�n���t�|�I�����t�j
                    if (!CheckYearDiv(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Text))
                    {
                        //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
                        this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
                        return false;
                    }
                    //�ԑ�ԍ�
                    if (!CheckCarNo(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_CREATECARNO_TITLE].Text))
                    {
                        //ADD START 2009/05/21 GEJUN FOR REDMINE#8049t
                        this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_CREATECARNO_TITLE].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
                        return false;
                    }
                }
			}
			#endregion

			return flg;
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		private bool Save(bool checkFlg)
		{
			#region �ۑ��`�F�b�N
			//---------------------------------------------------------------
			// �ۑ��f�[�^�`�F�b�N����
			//---------------------------------------------------------------

            //bool check = this.CheckSaveData();  // DEL 2010/07/01------------>>>

            // ADD 2010/07/01------------>>>
            bool check = true;
            if (checkFlg)
                check = this.CheckSaveData();
            // ADD 2010/07/01------------>>>

            existCheckFlg = false;
			if (check)
			{
                // �X�V�p���X�g
				ArrayList freeSearchPartsList = new ArrayList();
				// �폜�p���X�g
				ArrayList freeSearchPartsDeleteList = new ArrayList();
				foreach (FreeSearchParts freeSearchParts in _freeSearchPartsDty.Values)
				{
                    if (string.IsNullOrEmpty(freeSearchParts.GoodsNo) || (freeSearchParts.MakerCode == 0)
                        || (freeSearchParts.ModelCode == 0) || (freeSearchParts.PartsQty == 0))
                        continue;
					
                    
                    if (freeSearchParts.DataStatus == DATASTATUSCODE_1)
					{
						freeSearchPartsList.Add(freeSearchParts);
					}
					else if (freeSearchParts.DataStatus == DATASTATUSCODE_2)
					{
						// �^���i�t���^�j�����͂����ꍇ
						if (!string.IsNullOrEmpty(freeSearchParts.FullModel)
							&& !string.IsNullOrEmpty(freeSearchParts.GoodsNo))     // ���i�ԍ�
							//&& freeSearchParts.TbsPartsCode != 0                 // BL�R�[�h
							//&& freeSearchParts.GoodsMakerCd != 0)                // ���i���[�J�[�R�[�h
							//&& freeSearchParts.PartsQty != 0)                    // ���iQTY
						{
							string fullModel = string.Empty;
                            foreach (DataRow carModelInfoRow in this._selectCarModelInfoDataTable.Rows)
							{
								if (!string.IsNullOrEmpty(carModelInfoRow["FullModel"].ToString()))
								{
									if (fullModel == string.Empty && fullModel != carModelInfoRow["FullModel"].ToString())
									{
										freeSearchParts.FullModel = carModelInfoRow["FullModel"].ToString();
										freeSearchPartsList.Add(freeSearchParts);
										fullModel = carModelInfoRow["FullModel"].ToString();
									}
									else if (fullModel != carModelInfoRow["FullModel"].ToString())
									{
										FreeSearchParts fSPCopy = freeSearchParts.Clone();
										fSPCopy.FullModel = carModelInfoRow["FullModel"].ToString();
										fSPCopy.FreSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");
                                        freeSearchPartsList.Add(fSPCopy);
										fullModel = carModelInfoRow["FullModel"].ToString();
									}
								}
							}
						}
					}
					else if (freeSearchParts.DataStatus == DATASTATUSCODE_3)
					{
						freeSearchPartsDeleteList.Add(freeSearchParts);
					}
				}

				int status = this._freeSearchPartsAcs.WriteAndDelete(ref freeSearchPartsList, freeSearchPartsDeleteList);

				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					foreach (FreeSearchParts updateFSParts in freeSearchPartsList)
					{
						updateFSParts.DataStatus = DATASTATUSCODE_0;
						((FreeSearchParts)this._freeSearchPartsDty[updateFSParts.FreSrchPrtPropNo]) = updateFSParts;
					}
					foreach (FreeSearchParts deletefSParts in freeSearchPartsDeleteList)
					{
						this._freeSearchPartsDty.Remove(deletefSParts.FreSrchPrtPropNo);
					}

                    this.Clear(false);
                    //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);

                    updateModeFlg = false; // ADD 2010/07/01----->>>>
                    //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
				}

                //add start 2009/06/22 by gejun for RedMine #10103
                // ��r�p�ޕ�
                this._categoryNo = "";
                // ��r�p�Ԏ�
                this._fullCarType = "";
                // ��r�p�^��
                this._designationNo = "";
                // ��r�p�����ԍ�
                this._searchNo = 0;
                //add end 2009/06/22 by gejun for RedMine #10103
			}
			#endregion

            return check;
		}

		#region  �{�^�������ݒ菈��
		/// <summary>
		/// �{�^�������ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Ȃ�</br>
		/// <br>Programmer : ���`</br>
		/// <br>Date		: 2010/04/22</br>
		/// </remarks>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this.uButton_ModelFullGuide.ImageList = this._imageList16;
			this.uButton_ModelFullGuide.Appearance.Image = (int)Size16_Index.STAR1;

			this.uButton_CmpltGoodsMakerGuide.ImageList = this._imageList16;
			this.uButton_CmpltGoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;

			this.BlCdGuide.ImageList = this._imageList16;
			this.BlCdGuide.Appearance.Image = (int)Size16_Index.STAR1;
			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool saveButton;
			Infragistics.Win.UltraWinToolbars.LabelTool loginTitleLabel;
			Infragistics.Win.UltraWinToolbars.LabelTool loginSectionTitle;
			Infragistics.Win.UltraWinToolbars.ButtonTool searchButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool clearButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool rowDeleteButton;
            Infragistics.Win.UltraWinToolbars.ButtonTool allDeleteButton; // ADD 2010/07/01----->>>
			Infragistics.Win.UltraWinToolbars.ButtonTool guidButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool insertButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool newDatatButton;
			closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
			loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
			loginSectionTitle = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionTitle"];

			searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
			clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
			rowDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"];
            allDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"];// ADD 2010/07/01------>>>
            guidButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"];
			insertButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"];
			newDatatButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"];

			closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			loginSectionTitle.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

			searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
			clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
			rowDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            allDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;  // ADD 2010/07/01----->>>
			guidButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
			insertButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			newDatatButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
		}
		# endregion


		/// <summary>
		/// ���׃O���b�h�\���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h�̕\���ݒ���s���܂��B</br>
		/// <br>Programmer	: �я���</br>	
		/// <br>Date		: 2010/04/26</br>
		/// </remarks>
		private void SettingDetailsGridCol()
		{
			// --- �^���ꗗ�o���h --- //
			ColumnsCollection pareColumns = this.uGrid_Details.DisplayLayout.Bands[PMJKN09011UC.TBL_DETAILVIEW].Columns;

			// �O���[�h
			pareColumns[PMJKN09011UC.COL_MODELGRADENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_MODELGRADENM_TITLE].ValueList = this._modelGradeValueList;
			pareColumns[PMJKN09011UC.COL_MODELGRADENM_TITLE].MaxLength = 20;
			pareColumns[PMJKN09011UC.COL_MODELGRADENM_TITLE].Width = 130;

			// �{�f�B
			pareColumns[PMJKN09011UC.COL_BODYNAME_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_BODYNAME_TITLE].ValueList = this._bodyNameValueList;
			pareColumns[PMJKN09011UC.COL_BODYNAME_TITLE].MaxLength = 10;
			pareColumns[PMJKN09011UC.COL_BODYNAME_TITLE].Width = 80;

			// �h�A
			pareColumns[PMJKN09011UC.COL_DOORCOUNT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_DOORCOUNT_TITLE].ValueList = this._doorCountValueList;
			pareColumns[PMJKN09011UC.COL_DOORCOUNT_TITLE].MaxLength = 2;
			pareColumns[PMJKN09011UC.COL_DOORCOUNT_TITLE].Width = 60;

			// �G���W��
			pareColumns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].ValueList = this._engineModelValueList;
			pareColumns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].Width = 110;
			pareColumns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].MaxLength = 12;

			// �r�C��
			pareColumns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].ValueList = this._engineDisplaceValueList;
			pareColumns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].Width = 95;
			pareColumns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].MaxLength = 8;

			// E�敪
			pareColumns[PMJKN09011UC.COL_EDIVNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_EDIVNM_TITLE].ValueList = this._eDivValueList;
			pareColumns[PMJKN09011UC.COL_EDIVNM_TITLE].Width = 95;
			pareColumns[PMJKN09011UC.COL_EDIVNM_TITLE].MaxLength = 8;

			// �~�b�V����
			pareColumns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].ValueList = this._transmissionValueList;
			pareColumns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].Width = 95;
			pareColumns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].MaxLength = 8;

			// �쓮�`��
			pareColumns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].ValueList = this._wheelDriveMethodValueList;
			pareColumns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].Width = 120;
			pareColumns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].MaxLength = 15;

			// �V�t�g
			pareColumns[PMJKN09011UC.COL_SHIFTNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_SHIFTNM_TITLE].ValueList = this._shiftValueList;
			pareColumns[PMJKN09011UC.COL_SHIFTNM_TITLE].Width = 95;
			pareColumns[PMJKN09011UC.COL_SHIFTNM_TITLE].MaxLength = 8;
		}

		/// <summary>
		/// ���׃O���b�h��DropDownValue�ǉ�����
		/// </summary>
		private void AddDetailsGridValueList()
		{
			bool addFlg = true;
			foreach (DataRow dr in this._detailDataTable.Rows)
			{
				// �O���[�h
				string modelGrade = dr[PMJKN09011UC.COL_MODELGRADENM_TITLE].ToString();
				foreach (ValueListItem vItem in this._modelGradeValueList.ValueListItems)
				{
					if (vItem.DisplayText == modelGrade)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// �O���[�h���X�g
					if (!string.IsNullOrEmpty(modelGrade))
					{
						this._modelGradeValueList.ValueListItems.Add(modelGrade, modelGrade);
					}
				}
				addFlg = true;

				// �{�f�B
				string bodyName = dr[PMJKN09011UC.COL_BODYNAME_TITLE].ToString();
				foreach (ValueListItem vItem in this._bodyNameValueList.ValueListItems)
				{
					if (vItem.DisplayText == bodyName)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// �{�f�B���X�g
					if (!string.IsNullOrEmpty(bodyName))
					{
						this._bodyNameValueList.ValueListItems.Add(bodyName, bodyName);
					}
				}
				addFlg = true;

				// �h�A
				string doorCount = dr[PMJKN09011UC.COL_DOORCOUNT_TITLE].ToString();
				foreach (ValueListItem vItem in this._doorCountValueList.ValueListItems)
				{
					if (vItem.DisplayText == doorCount)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// �h�A���X�g
					if (!string.IsNullOrEmpty(doorCount))
					{
						this._doorCountValueList.ValueListItems.Add(doorCount, doorCount);
					}
				}
				addFlg = true;

				// �G���W��
				string engineModel = dr[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._engineModelValueList.ValueListItems)
				{
					if (vItem.DisplayText == engineModel)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// �G���W�����X�g
					if (!string.IsNullOrEmpty(engineModel))
					{
						this._engineModelValueList.ValueListItems.Add(engineModel, engineModel);
					}
				}
				addFlg = true;

				// �r�C��
				string engineDisplace = dr[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].ToString();
				foreach (ValueListItem vItem in this._engineDisplaceValueList.ValueListItems)
				{
					if (vItem.DisplayText == engineDisplace)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// �r�C�ʃ��X�g
					if (!string.IsNullOrEmpty(engineDisplace))
					{
						this._engineDisplaceValueList.ValueListItems.Add(engineDisplace, engineDisplace);
					}
				}
				addFlg = true;


				// E�敪
				string eDiv = dr[PMJKN09011UC.COL_EDIVNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._eDivValueList.ValueListItems)
				{
					if (vItem.DisplayText == eDiv)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// E�敪���X�g
					if (!string.IsNullOrEmpty(eDiv))
					{
						this._eDivValueList.ValueListItems.Add(eDiv, eDiv);
					}
				}
				addFlg = true;

				// �~�b�V����
				string transmission = dr[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._transmissionValueList.ValueListItems)
				{
					if (vItem.DisplayText == transmission)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// �~�b�V�������X�g
					if (!string.IsNullOrEmpty(transmission))
					{
						this._transmissionValueList.ValueListItems.Add(transmission, transmission);
					}
				}
				addFlg = true;

				// �쓮�`��
				string wheelDriveMethod = dr[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._wheelDriveMethodValueList.ValueListItems)
				{
					if (vItem.DisplayText == wheelDriveMethod)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// �쓮�`�����X�g
					if (!string.IsNullOrEmpty(wheelDriveMethod))
					{
						this._wheelDriveMethodValueList.ValueListItems.Add(wheelDriveMethod, wheelDriveMethod);
					}
				}
				addFlg = true;

				// �V�t�g
				string shift = dr[PMJKN09011UC.COL_SHIFTNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._shiftValueList.ValueListItems)
				{
					if (vItem.DisplayText == shift)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// �V�t�g���X�g
					if (!string.IsNullOrEmpty(shift))
					{
						this._shiftValueList.ValueListItems.Add(shift, shift);
					}
				}
				addFlg = true;
			}
		}

		/// <summary>
		/// �G�f�B�^���擾���܂��B
		/// </summary>
		/// <param name="format">�t�H�[�}�b�g</param>
		/// <returns>�G�f�B�^</returns>
		private EmbeddableEditorBase getEditor(string format)
		{
			EmbeddableEditorBase editor = null;
			DefaultEditorOwnerSettings editorSettings = null;
			editorSettings = new DefaultEditorOwnerSettings();
			editorSettings.DataType = typeof(string);
			editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
			editorSettings.MaskInput = format;
			return editor;
		}

		/// <summary>
		/// �����͉\�Z���ړ�����
		/// </summary>
		/// <param name="currentCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
		/// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
		private bool MoveNextAllowEditCell(bool activeCellCheck)
		{

			this.uGrid_Details.BeginUpdate();
			this.uGrid_Details.SuspendLayout();
			bool moved = false;
			bool performActionResult = false;

			// ActiveCell�����͉\�̏ꍇ�ANext�������Ȃ�
			if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
			{
				if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
					(this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
					(this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
				{
					moved = true;
				}
			}

			while (!moved)
			{
				// ActiveCell����
				if (this.uGrid_Details.ActiveCell != null)
				{
					performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

					if (performActionResult)
					{
						if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
							(this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
						{
							moved = true;
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

				if (moved)
				{
					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}
			}
			this.uGrid_Details.ResumeLayout();
			this.uGrid_Details.EndUpdate();
			return performActionResult;

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

            if (key > '9' || key < '0')
            {
                return false;
            }

			// �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
			string _strResult = string.Empty;
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
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// �����_�̃`�F�b�N
			if (key == '.')
			{
				if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// �L�[�������ꂽ���ʂ̕�����𐶐�����B
			_strResult = prevVal.Substring(0, selstart)
				+ key
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
				else
				{
					return false;
				}
			}

			// �����_�ȉ��̃`�F�b�N
			if (priod > 0)
			{
				// �����_�̈ʒu����
				int _pointPos = _strResult.IndexOf('.');

				// �������ɓ��͉\�Ȍ���������I
				//int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				int _Rketa = SalesSlipInputAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
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
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// �������̌������`�F�b�N
				if (_pointPos != -1)
				{
					// �������̌������v�Z
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}

        /// <summary>
        /// ���i�A���ׁE�����c���������i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="goodsNo">���i�R�[�h</param>
        /// <param name="searchResult">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���i������A�c�������\���敪�ɏ]���Ĕ����c�Ɖ�A���׎c�Ɖ���N�����܂��B</br>
        /// <br>             �������ʂɂ��ẮA�q�b�g���������i���ior���׎cor�����c�j�ɂ���ăN���X���قȂ�܂��B</br>
        /// </remarks>
        private int SearchGoodsAndRemain(string goodsNo, out object searchResult)
        {
            return this.SearchGoodsAndRemain(goodsNo, string.Empty, 0, out searchResult);
        }

        /// <summary>
        /// ���i�A���ׁE�����c���������i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="goodsNo">���i�R�[�h</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="searchResult">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���i������A�c�������\���敪�ɏ]���Ĕ����c�Ɖ�A���׎c�Ɖ���N�����܂��B</br>
        /// <br>             �������ʂɂ��ẮA�q�b�g���������i���ior���׎cor�����c�j�ɂ���ăN���X���قȂ�܂��B</br>
        /// </remarks>
        private int SearchGoodsAndRemain(string goodsNo, string goodsName, int makerCode, out object searchResult)
        {
            searchResult = null;

            List<GoodsUnitData> goodsUnitDataList;
            int searchStatus;
            int retStasus = -1;

            // ���i����
            if (makerCode == 0)
            {
                searchStatus = this.SearchGoods(goodsNo, out goodsUnitDataList);
            }
            else
            {
                searchStatus = this.SearchGoods(goodsNo, goodsName, makerCode, out goodsUnitDataList);
            }

            // ���i�����Ńq�b�g�����ꍇ
            if ((searchStatus == 0) && (goodsUnitDataList.Count > 0))
            {
                retStasus = 0;
                searchResult = goodsUnitDataList;
            }
            // ���i�����Ńq�b�g���Ȃ������ꍇ�i�󏤕i��Ԃ��j
            else if ((searchStatus == -2) && (goodsUnitDataList.Count > 0))
            {
                retStasus = 0;
                searchResult = goodsUnitDataList;
            }
            // ADD 2010/07/01 ------>>
            else
            {
                retStasus = searchStatus;
            }
            // ADD 2010/07/01 ------>>
            return retStasus;
        }

        /// <summary>
        /// ���i���������i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="goodsNo">���i�R�[�h</param>
        /// <param name="goodsUnitDataList">���i��񃊃X�g</param>
        /// <param name="stockList">�݌ɏ�񃊃X�g</param>
        /// <returns>0:����OK�A-1:�L�����Z��,-2:�����f�[�^����</returns>
        private int SearchGoods(string goodsNo, out List<GoodsUnitData> goodsUnitDataList)
        {
            return this.SearchGoods(goodsNo, string.Empty, 0, out goodsUnitDataList);
        }

        /// <summary>
        /// ���i���������i���i�R�[�h�{���[�J�[�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="goodsNo">���i�R�[�h</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsUnitDataList">���i��񃊃X�g</param>
        /// <returns>0:����OK�A-1:�L�����Z��,-2:�����f�[�^����</returns>
        private int SearchGoods(string goodsNo, string goodsName, int goodsMakerCd, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            goodsUnitDataList = new List<GoodsUnitData>();

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            string message;

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;                   // ��ƃR�[�h
            goodsCndtn.SectionCode = this._loginSectionCode;                    // ���_�R�[�h
            goodsCndtn.GoodsNo = goodsNo;                                       // ���i�R�[�h
            goodsCndtn.GoodsMakerCd = goodsMakerCd;                             // ���i���[�J�[�R�[�h
            goodsCndtn.PriceApplyDate = DateTime.Now;                           // ADD 2009/05/22 GEJUN FOR REDMINE#8049
            status = this._freeSearchPartsAcs.GetGoodsUnitData(goodsCndtn, out goodsUnitData, out message);

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        goodsUnitDataList.Add(goodsUnitData);
                        return 0;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                    {
                        return -1;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        return -2;
                    }
            }
            return 0;
        }

		/// <summary>
		/// ActiveRow�C���f�b�N�X�擾����
		/// </summary>
		/// <returns>ActiveRow�C���f�b�N�X</returns>
		private int GetActiveRowIndex()
		{
			if (this.uGrid_Details.ActiveCell != null)
			{
				return this.uGrid_Details.ActiveCell.Row.Index;
			}
			else if (this.uGrid_Details.ActiveRow != null)
			{
				return this.uGrid_Details.ActiveRow.Index;
			}
			else
			{
				return -1;
			}
		}
        // add start 2010/06/24 by gejun for RedMine #10103
		/// <summary>
		/// �I�������s�C���f�b�N�X���X�g�擾����
		/// </summary>
        /// <returns>�I�������s�C���f�b�N�X</returns>
        private List<int> GetSelectRowIndex()
        {
            List<int> SelRowInxList = new List<int>();
            for (int i = this.uGrid_Details.Rows.Count - 1; i > -1; i--)
            {
                if(this.uGrid_Details.Rows[i].Selected)
                    SelRowInxList.Add(i);
            }
            if ( SelRowInxList.Count == 0 && this.uGrid_Details.ActiveCell != null)
                SelRowInxList.Add(this.uGrid_Details.ActiveCell.Row.Index);

            return SelRowInxList;
        }
        // add end 2010/06/24 by gejun for RedMine #10103
		/// DetailDataTable�C���f�b�N�X�擾����
		/// </summary>
		/// <returns>DetailDataTable�C���f�b�N�X</returns>
		private int GetDetailDataTableRowIndex(string colTitle, string colValue)
		{
			int dataTableIndex = -1;
			for (int i = 0; i < this._detailDataTable.Rows.Count; i++)
			{
				if (colValue == this._detailDataTable.Rows[i][colTitle].ToString())
				{
					dataTableIndex = i;
					break;
				}
			}
			return dataTableIndex;
		}

		/// <summary>
		/// BL�R�[�h����
		/// </summary>
		/// <param name="salesRowNo">����s�ԍ�</param>
		/// <param name="bLGoodsCode">BL�R�[�h</param>
		/// <param name="searchResult">��������</param>
		/// <returns></returns>
		private int SearchPartsFromBLCode(int salesRowNo, int bLGoodsCode, out object searchResult)
		{
			//-----------------------------------------------------------------------------
			// ��������
			//-----------------------------------------------------------------------------
			searchResult = null;
			List<GoodsUnitData> goodsUnitDataList;
			List<Stock> stockList;
			int searchStatus;
			int retStasus = -1;

			//-----------------------------------------------------------------------------
			// BL�R�[�h����
			//-----------------------------------------------------------------------------
			searchStatus = this.SearchPartsFromBLCodeProc(salesRowNo, bLGoodsCode, out goodsUnitDataList, out stockList);

			//-----------------------------------------------------------------------------
			// BL�R�[�h�����Ńq�b�g�����ꍇ
			//-----------------------------------------------------------------------------
			if ((searchStatus == 0) && (goodsUnitDataList.Count > 0))
			{
				ArrayList retList = new ArrayList();
				foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
				{
					retList.Add(goodsUnitData);
				}
				searchResult = retList;
			}
			//-----------------------------------------------------------------------------
			// BL�R�[�h�����Ńq�b�g���Ȃ������ꍇ�i�󏤕i��Ԃ��j
			//-----------------------------------------------------------------------------
			else if ((searchStatus == -2) && (goodsUnitDataList.Count <= 0))
			{
				retStasus = -2;

				ArrayList retList = new ArrayList();
				searchResult = retList;
			}
			//-----------------------------------------------------------------------------
			// �ԗ���񖳂�
			//-----------------------------------------------------------------------------
			else if (searchStatus == -3)
			{
				retStasus = -3;
				ArrayList retList = new ArrayList();
				searchResult = retList;
			}

			return retStasus;
		}

		/// <summary>
		/// �ԗ����L���b�V���i�ԗ�������񂩂�L���b�V���j
		/// </summary>
		/// <param name="dat">�Ԏ�^�����</param>
		private void SetCarInfo(PMKEN01010E dat)
		{
			//�Ԏ�^�����
			_carModelInfoDataTable = dat.CarModelInfo;

			this.ClearValueList();

			if (_carModelInfoDataTable != null && _carModelInfoDataTable.Rows.Count > 0)
			{
				this.StartSearchGoodsNo.Text = "1";

				//�O���[�h
				ArrayList modelGradeNmList = new ArrayList();
				//�{�f�B
				ArrayList bodyNameList = new ArrayList();
				//�h�A
				ArrayList doorCoutList = new ArrayList();
				//�G���W��
				ArrayList engineModelList = new ArrayList();
				//�r�C��
				ArrayList engineDisplaceList = new ArrayList();
				//E�敪
				ArrayList eDivList = new ArrayList();
				//�~�b�V����
				ArrayList transmissionList = new ArrayList();
				//�쓮�`��
				ArrayList wheelDriveMethodList = new ArrayList();
				//�V�t�g
				ArrayList shiftList = new ArrayList();

                _endSearchGoodsNo = 0;
                this._selectCarModelInfoDataTable.Rows.Clear();
                _singleIndex = 0;
                this._modelGradeValueList.ValueListItems.Add("", "");
                this._bodyNameValueList.ValueListItems.Add("", "");
                this._doorCountValueList.ValueListItems.Add("", "");
                this._engineModelValueList.ValueListItems.Add("", "");
                this._engineDisplaceValueList.ValueListItems.Add("", "");
                this._eDivValueList.ValueListItems.Add("", "");
                this._transmissionValueList.ValueListItems.Add("", "");
                this._wheelDriveMethodValueList.ValueListItems.Add("", "");
                this._shiftValueList.ValueListItems.Add("", "");

                // --- UPD m.suzuki 2010/06/01 ---------->>>>>
                //for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
                for ( int i = 0; i < _carModelInfoDataTable.DefaultView.Count; i++ )
                // --- UPD m.suzuki 2010/06/01 ----------<<<<<
				{
                    // --- UPD m.suzuki 2010/06/01 ---------->>>>>
                    //PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];
                    PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.DefaultView[i].Row;
                    // --- UPD m.suzuki 2010/06/01 ----------<<<<<

					if ((bool)carModelInfoRow["SelectionState"] == true)
					{
                        this._selectCarModelInfoDataTable.ImportRow(carModelInfoRow);
 						//�O���[�h
						if (!modelGradeNmList.Contains((string)carModelInfoRow["ModelGradeNm"]))
						{
                            this._modelGradeValueList.ValueListItems.Add((string)carModelInfoRow["ModelGradeNm"], (string)carModelInfoRow["ModelGradeNm"]);
							modelGradeNmList.Add((string)carModelInfoRow["ModelGradeNm"]);
						}
						//�{�f�B
						if (!bodyNameList.Contains((string)carModelInfoRow["BodyName"]))
						{
                            this._bodyNameValueList.ValueListItems.Add((string)carModelInfoRow["BodyName"], (string)carModelInfoRow["BodyName"]);
							bodyNameList.Add((string)carModelInfoRow["BodyName"]);
						}
						//�h�A
						int doorCout = (int)carModelInfoRow["DoorCount"];
						if (!doorCoutList.Contains(doorCout.ToString()))
						{
                            this._doorCountValueList.ValueListItems.Add(doorCout.ToString(), doorCout.ToString());
							doorCoutList.Add(doorCout.ToString());
						}
						//�G���W��
						if (!engineModelList.Contains((string)carModelInfoRow["EngineModelNm"]))
						{
                            this._engineModelValueList.ValueListItems.Add((string)carModelInfoRow["EngineModelNm"], (string)carModelInfoRow["EngineModelNm"]);
							engineModelList.Add((string)carModelInfoRow["EngineModelNm"]);
						}
						//�r�C��
						if (!engineDisplaceList.Contains((string)carModelInfoRow["EngineDisplaceNm"]))
						{
                            this._engineDisplaceValueList.ValueListItems.Add((string)carModelInfoRow["EngineDisplaceNm"], (string)carModelInfoRow["EngineDisplaceNm"]);
							engineDisplaceList.Add((string)carModelInfoRow["EngineDisplaceNm"]);
						}
						//E�敪
						if (!eDivList.Contains((string)carModelInfoRow["EDivNm"]))
						{
                            this._eDivValueList.ValueListItems.Add((string)carModelInfoRow["EDivNm"], (string)carModelInfoRow["EDivNm"]);
							eDivList.Add((string)carModelInfoRow["EDivNm"]);
						}
						//�~�b�V����
						if (!transmissionList.Contains((string)carModelInfoRow["TransmissionNm"]))
						{
                            this._transmissionValueList.ValueListItems.Add((string)carModelInfoRow["TransmissionNm"], (string)carModelInfoRow["TransmissionNm"]);
							transmissionList.Add((string)carModelInfoRow["TransmissionNm"]);
						}
						//�쓮�`��
						if (!wheelDriveMethodList.Contains((string)carModelInfoRow["WheelDriveMethodNm"]))
						{
                            this._wheelDriveMethodValueList.ValueListItems.Add((string)carModelInfoRow["WheelDriveMethodNm"], (string)carModelInfoRow["WheelDriveMethodNm"]);
							wheelDriveMethodList.Add((string)carModelInfoRow["WheelDriveMethodNm"]);
						}
						//�V�t�g
						if (!shiftList.Contains((string)carModelInfoRow["ShiftNm"]))
						{
                            this._shiftValueList.ValueListItems.Add((string)carModelInfoRow["ShiftNm"], (string)carModelInfoRow["ShiftNm"]);
							shiftList.Add((string)carModelInfoRow["ShiftNm"]);
						}

                        if (_endSearchGoodsNo == 0)
                        {
                            this.tNedit_MakerCode.SetInt((int)carModelInfoRow["MakerCode"]);
                            this._makerCode = (int)carModelInfoRow["MakerCode"];
                            this.tNedit_ModelCode.SetInt((int)carModelInfoRow["ModelCode"]);
                            this._modelCode = (int)carModelInfoRow["ModelCode"];
                            this.tNedit_ModelSubCode.SetInt((int)carModelInfoRow["ModelSubCode"]);
                            this._modelSubCode = (int)carModelInfoRow["ModelSubCode"];
                            this.tEdit_ModelFullName.Text = (string)carModelInfoRow["ModelFullName"];
                            //�^��
                            this.tEdit_FullModel.Text = (string)carModelInfoRow["FullModel"];
                            this._fullModel = (string)carModelInfoRow["FullModel"];
                            //�N��from
                            if ((int)carModelInfoRow["StProduceTypeOfYear"] > 0)
                            {
                                DateTime startEntryDate = TDateTime.LongDateToDateTime("yyyymm", (int)carModelInfoRow["StProduceTypeOfYear"]);
                                this.tDateEdit_StartEntryYearDate.Text = startEntryDate.Year.ToString("0000");
                                this.tDateEdit_StartEntryMonthDate.Text = startEntryDate.Month.ToString("00");
                            }
                            //�N��to
                            if ((int)carModelInfoRow["EdProduceTypeOfYear"] > 0)
                            {
                                DateTime edEntryDate = TDateTime.LongDateToDateTime("yyyymm", (int)carModelInfoRow["EdProduceTypeOfYear"]);
                                this.tDateEdit_EndEntryYearDate.Text = edEntryDate.Year.ToString("0000");
                                this.tDateEdit_EndEntryMonthDate.Text = edEntryDate.Month.ToString("00");
                            }
                            //�ԑ�ԍ�
                            if ((int)carModelInfoRow["StProduceFrameNo"] > 0)
                            {
                                this.tEdit_StartProduceFrameNo.Text = ((int)carModelInfoRow["StProduceFrameNo"]).ToString();
                            }
                            if ((int)carModelInfoRow["EdProduceFrameNo"] > 0)
                            {
                                this.tEdit_EndProduceFrameNo.Text = ((int)carModelInfoRow["EdProduceFrameNo"]).ToString();
                            }
                            this._carSpecDataSet = new DataSet();
                            PMJKN09011UB.DataSetColumnConstruction(ref this._carSpecDataSet);
                            DataRow row = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].NewRow();
                            //�������
                            //�O���[�h
                            row[PMJKN09011UB.COL_MODELGRADENM_TITLE] = carModelInfoRow["ModelGradeNm"].ToString();
                            //�{�f�B
                            row[PMJKN09011UB.COL_BODYNAME_TITLE] = carModelInfoRow["BodyName"].ToString();
                            //�h�A
                            if ((int)carModelInfoRow["DoorCount"] == 0)
                            {
                                // row[PMJKN09011UB.COL_DOORCOUNT_TITLE] = "0";  del by gejun for RedMine #10103
                                row[PMJKN09011UB.COL_DOORCOUNT_TITLE] = "";  // add by gejun for RedMine #10103
                            }
                            else
                            {
                                row[PMJKN09011UB.COL_DOORCOUNT_TITLE] = carModelInfoRow["DoorCount"].ToString();
                            }
                            //�G���W��
                            row[PMJKN09011UB.COL_ENGINEMODELNM_TITLE] = carModelInfoRow["EngineModelNm"].ToString();
                            //�r�C��
                            row[PMJKN09011UB.COL_ENGINEDISPLACENM_TITLE] = carModelInfoRow["EngineDisplaceNm"].ToString();
                            //E�敪
                            row[PMJKN09011UB.COL_EDIVNM_TITLE] = carModelInfoRow["EDivNm"].ToString();
                            //�~�b�V����
                            row[PMJKN09011UB.COL_TRANSMISSIONNM_TITLE] = carModelInfoRow["TransmissionNm"].ToString();
                            //�쓮�`��
                            row[PMJKN09011UB.COL_WHEELDRIVEMETHODNM_TITLE] = carModelInfoRow["WheelDriveMethodNm"].ToString();
                            //�V�t�g
                            row[PMJKN09011UB.COL_SHIFTNM_TITLE] = carModelInfoRow["ShiftNm"].ToString();                       
                            this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Add(row);
                            this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].DefaultView;
                            this.ultraGrid_CarSpec.Rows[0].Activation = Activation.Disabled;
                        
                        }
                        _endSearchGoodsNo++;
                    }

                    _singleIndex++; 
                    
				}

                if (_endSearchGoodsNo > 1)
                {
                    _singleIndex = 0;
                }

                this.tNedit_SearchGoodsNo.SetInt(1);
                this.EndSearchGoodsNo.Text = _endSearchGoodsNo.ToString();
			}

		}


		/// <summary>
		/// BL�R�[�h����
		/// </summary>
		/// <param name="salesRowNo">����s�ԍ�</param>
		/// <param name="bLGoodsCode">BL�R�[�h</param>
		/// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="stockList">�݌Ƀf�[�^�I�u�W�F�N�g���X�g</param>
		/// <returns></returns>
		private int SearchPartsFromBLCodeProc(int salesRowNo, int bLGoodsCode, out List<GoodsUnitData> goodsUnitDataList, out List<Stock> stockList)
		{
			//-------------------------------------------------------------
			// ��������
			//-------------------------------------------------------------
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			goodsUnitDataList = new List<GoodsUnitData>();
			stockList = new List<Stock>();

			#region ��BL�R�[�h����
			//-------------------------------------------------------------
			// BL�R�[�h����
			//-------------------------------------------------------------
			//status = this._freeSearchPartsAcs.SearchPartsFromBLCode(salesRowNo, this._enterpriseCode, this._loginSectionCode, bLGoodsCode, out goodsUnitDataList, this._carInfo);
			#endregion

			//-------------------------------------------------------------
			// ���i�����㏈��
			//-------------------------------------------------------------
			if ((status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
			{
			}
			else if (status == -3)
			{
				// �ԗ���񖳂�
				return -3;
			}
			else if (status == -1)
			{
				// �L�����Z��
				return -1;
			}
			else
			{
				// �Y���Ȃ�
				return -2;
			}

			return 0;
		}
        // ADD 2010/07/01----->>>>>
        /// <summary>
		/// ���׃O���b�h�S�폜����
		/// </summary>
        private void DeleteAllDetailRow()
        {
            if (this.CheckChangedData())
            {
                DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
                    "�S���׍폜���Ă��悢�ł����H",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (FreeSearchParts freeSearchParts in _freeSearchPartsDty.Values)
                    {
                        if (string.IsNullOrEmpty(freeSearchParts.GoodsNo) || (freeSearchParts.MakerCode == 0)
                                || (freeSearchParts.ModelCode == 0) || (freeSearchParts.PartsQty == 0))
                            continue;

                        if (freeSearchParts.DataStatus == DATASTATUSCODE_1 || freeSearchParts.DataStatus == DATASTATUSCODE_0)
                        {
                            freeSearchParts.DataStatus = DATASTATUSCODE_3;
                        }
                        else if (freeSearchParts.DataStatus == DATASTATUSCODE_2)
                            _freeSearchPartsDty.Remove(freeSearchParts.FreSrchPrtPropNo);
                    }
                    // DB����
                    this.Save(false);
                }
                else
                    return;
                
            }
        }
        // ADD 2010/07/01----->>>>>
		/// <summary>
		/// ���׃O���b�h�폜����
		/// </summary>
		private void DeleteDetailRow()
		{
            List<int> selRowInxList = GetSelectRowIndex(); // add 2010/06/24 by gejun for RedMine #10103
            
            //if (GetActiveRowIndex() != -1) // del start 2010/06/24 by gejun for RedMine #10103
            if (selRowInxList.Count != 0)  // add start 2010/06/24 by gejun for RedMine #10103
			{
                // modify start 2010/06/24 by gejun for RedMine #10103
                foreach(int rowIndex in selRowInxList)
                {
				    //string fullModelGroup = this.uGrid_Details.Rows[GetActiveRowIndex()].Cells[PMJKN09011UC.COL_FULLMODELGROUP_TITLE].Text;
                    string fullModelGroup = this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_FULLMODELGROUP_TITLE].Text;
                    if (string.IsNullOrEmpty(fullModelGroup))
				    {
                        //string freSrchPrtPropNo = this.uGrid_Details.Rows[GetActiveRowIndex()].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
                        string freSrchPrtPropNo = this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
                        // modify end 2010/06/24 by gejun for RedMine #10103
                        FreeSearchParts freeSearchParts = null;
					    if (this._freeSearchPartsDty.ContainsKey(freSrchPrtPropNo))
					    {
						    freeSearchParts = (FreeSearchParts)this._freeSearchPartsDty[freSrchPrtPropNo];
						    if (freeSearchParts.DataStatus == DATASTATUSCODE_0 || freeSearchParts.DataStatus == DATASTATUSCODE_1)
						    {
							    // �폜����f�[�^
							    freeSearchParts.DataStatus = DATASTATUSCODE_3;
						    }
						    else if (freeSearchParts.DataStatus == DATASTATUSCODE_2)
						    {
							    // DB���݂��Ȃ��A���폜����f�[�^
							    freeSearchParts.DataStatus = DATASTATUSCODE_4;
						    }
						    // ���׃e�[�u���̃f�[�^���폜����B
						    this._detailDataTable.Rows.RemoveAt(GetDetailDataTableRowIndex(PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE, freSrchPrtPropNo));


                            if (goodsNoComp.ContainsKey(freSrchPrtPropNo))
                                goodsNoComp.Remove(freSrchPrtPropNo);
					    }
                        //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
                        if (_newLineRowIndexDic.ContainsKey(freSrchPrtPropNo))
                            this._newLineRowIndexDic.Remove(freSrchPrtPropNo);
                        //ADD END 2009/05/24 GEJUN FOR REDMINE#8049
				    }
				    else
				    {
					    foreach (FreeSearchParts fsp in _freeSearchPartsDty.Values)
					    {
						    if (fullModelGroup == fsp.FullModelGroup)
						    {
							    if (fsp.DataStatus == DATASTATUSCODE_0 || fsp.DataStatus == DATASTATUSCODE_1)
							    {
								    // �폜����f�[�^
								    fsp.DataStatus = DATASTATUSCODE_3;
							    }
							    else if (fsp.DataStatus == DATASTATUSCODE_2)
							    {
								    // DB���݂��Ȃ��A���폜����f�[�^
								    fsp.DataStatus = DATASTATUSCODE_4;
							    }
						    }
					    }
					    // ���׃e�[�u���̃f�[�^���폜����B
					    this._detailDataTable.Rows.RemoveAt(GetDetailDataTableRowIndex(PMJKN09011UC.COL_FULLMODELGROUP_TITLE, fullModelGroup));

                        if (goodsNoComp.ContainsKey(fullModelGroup))
                            goodsNoComp.Remove(fullModelGroup);
				    }
				    if (this._detailDataTable.Rows.Count == 0)
				    {
                        DataRow row = this._detailDataTable.NewRow();
                        row[PMJKN09011UC.COL_NO_TITLE] = 1;
                        row[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = Guid.NewGuid().ToString().Replace("-", "");
                        this._detailDataTable.Rows.Add(row);
				    }
				    // ���׃O���b�h�ݒ菈��
				    this.SettingGrid();
			    }

            }// add 2010/06/24 by gejun for RedMine #10103

		}

		/// <summary>
		/// ���p�o�^����
		/// </summary>
		private void QuoteWrite()
		{
			//---------------------------------------------------------------
			// �ۑ��f�[�^�`�F�b�N����
			//---------------------------------------------------------------
			bool check = this.CheckSaveData();
			if (!check)
			{
				return;
			}
            // �J�[�\���s�݂̂̃f�[�^
			ArrayList fspOneRowRestList = new ArrayList();
            // ���׍s�S�Ẵf�[�^
            ArrayList fspFullRowRestList = new ArrayList();
            // ���R�������i�ŗL�ԍ�
            string freSrchPrtPropNo = this.uGrid_Details.Rows[GetActiveRowIndex()].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
            if (!string.IsNullOrEmpty(freSrchPrtPropNo))
            {
                if (this._freeSearchPartsDty.ContainsKey(freSrchPrtPropNo))
                {
                    FreeSearchParts freeSearchParts = this._freeSearchPartsDty[freSrchPrtPropNo];
                    fspOneRowRestList.Add(freeSearchParts);
                }
            }
            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty((string)this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Value) || this.uGrid_Details.Rows.Count == 1)
                {
                    freSrchPrtPropNo = this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
                    if (!string.IsNullOrEmpty(freSrchPrtPropNo) && this._freeSearchPartsDty.ContainsKey(freSrchPrtPropNo))
                    {
                        FreeSearchParts freeSearchParts = this._freeSearchPartsDty[freSrchPrtPropNo];
                        fspFullRowRestList.Add(this._freeSearchPartsDty[freSrchPrtPropNo]);
                    }
                }
            }
			//��ʖ��ו��̓f�[�^����
            if (fspFullRowRestList.Count > 0 && fspOneRowRestList.Count > 0)
			{
                //ADD START 2009/05/22 GEJUN FOR REDMINE#8049
                // ���R�����^���}�X�^�X�V�p�f�[�^�̏���
                FreeSearchModel freeSearchModel = new FreeSearchModel();

                freeSearchModel.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt(); // �^���w��ԍ�
                freeSearchModel.CategoryNo = this.tNedit_CategoryNo.GetInt(); // �ޕʔԍ�

                string stDate = string.Empty;
                if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text))
                {
                    stDate = this.tDateEdit_StartEntryYearDate.Text;
                }
                if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text))
                {
                    stDate += this.tDateEdit_StartEntryMonthDate.Text;
                }
                if (!string.IsNullOrEmpty(stDate))
                {
                    freeSearchModel.StProduceTypeOfYear = TDateTime.LongDateToDateTime("YYYYMM", Convert.ToInt32(stDate)); // �J�n���Y�N��
                }

                string edDate = string.Empty;
                if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text))
                {
                    edDate = this.tDateEdit_EndEntryYearDate.Text;
                }
                if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text))
                {
                    edDate += this.tDateEdit_EndEntryMonthDate.Text;
                }
                if (!string.IsNullOrEmpty(edDate))
                {
                    freeSearchModel.EdProduceTypeOfYear = TDateTime.LongDateToDateTime("YYYYMM", Convert.ToInt32(edDate)); // �I�����Y�N��
                }

                if (!string.IsNullOrEmpty(this.tEdit_StartProduceFrameNo.Text))
                {
                    freeSearchModel.StProduceFrameNo = Convert.ToInt32(this.tEdit_StartProduceFrameNo.Text); // ���Y�ԑ�ԍ��J�n
                }

                if (!string.IsNullOrEmpty(this.tEdit_EndProduceFrameNo.Text))
                {
                    freeSearchModel.EdProduceFrameNo = Convert.ToInt32(this.tEdit_EndProduceFrameNo.Text); //���Y�ԑ�ԍ��I��
                }

                // �������
                // �^���O���[�h����
                freeSearchModel.ModelGradeNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_MODELGRADENM_TITLE].Text.ToString();

                // �{�f�B�[����
                freeSearchModel.BodyName = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_BODYNAME_TITLE].Text.ToString();

                // �h�A��
                string doorCount = (string)this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_DOORCOUNT_TITLE].Text.ToString();
                freeSearchModel.DoorCount = String.IsNullOrEmpty(doorCount) ? 0 : Convert.ToInt32(doorCount);

                // �G���W���^������
                freeSearchModel.EngineModelNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_ENGINEMODELNM_TITLE].Text.ToString();

                // �r�C�ʖ���
                freeSearchModel.EngineDisplaceNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_ENGINEDISPLACENM_TITLE].Text.ToString();

                // E�敪����
                freeSearchModel.EDivNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_EDIVNM_TITLE].Text.ToString();

                // �~�b�V��������
                freeSearchModel.TransmissionNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_TRANSMISSIONNM_TITLE].Text.ToString();

                // �쓮��������
                freeSearchModel.WheelDriveMethodNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_WHEELDRIVEMETHODNM_TITLE].Text.ToString();

                // �V�t�g����
                freeSearchModel.ShiftNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_SHIFTNM_TITLE].Text.ToString();
                //ADD END 2009/05/22 GEJUN FOR REDMINE#8049

                //PMJKN09011UF PMJKN09011UF = new PMJKN09011UF(fspFullRowRestList, fspOneRowRestList);//DEL 2009/05/22 GEJUN FOR REDMINE#8049
                PMJKN09011UF PMJKN09011UF = new PMJKN09011UF(fspFullRowRestList, fspOneRowRestList, freeSearchModel);//ADD 2009/05/22 GEJUN FOR REDMINE#8049
				PMJKN09011UF.ShowDialog();

			}
		}

		/// <summary>
		/// ��������
		/// </summary>
        //private void Search()// del 2010/06/24 by gejun for RedMine #10103
        private int Search()// add 2010/06/24 by gejun for RedMine #10103
		{
            int result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;// add 2010/06/24 by gejun for RedMine #10103

            if (this.CheckSearchParam())
            {

                this._detailDataTable.Clear();
                FreeSearchParts rowInfo = null;
                // ��ʏ��擾
                FreeSearchParts cond = DispCondToFreeSearchParts();
                // �������{
                ArrayList retList = null;
                int status = this._freeSearchPartsAcs.Search(out retList, cond);
                this._newLineRowIndexDic.Clear();                //ADD 2009/05/24 GEJUN FOR REDMINE#8049
                this._freeSearchPartsDty.Clear();
                this._detailDataTable.Rows.Clear();
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ���[�J�[�R�[�h
                    this._makerCode = this.tNedit_MakerCode.GetInt();
                    // �Ԏ�R�[�h
                    this._modelCode = this.tNedit_ModelCode.GetInt();
                    // �Ԏ�T�u�R�[�h
                    this._modelSubCode = this.tNedit_ModelSubCode.GetInt();
                    // �^���i�t���^�j
                    this._fullModel = this.tEdit_FullModel.Text;

                    if (retList != null && retList.Count > 0)
                    {

                        goodsNoComp.Clear(); //ADD 2010/07/01 ------------------>>>

                        Dictionary<string, List<FreeSearchParts>> checkGroupDty = new Dictionary<string, List<FreeSearchParts>>();
                        List<FreeSearchParts> list = null;
                        foreach (object obj in retList)
                        {
                            rowInfo = (FreeSearchParts)obj;
                            StringBuilder keySBuilder = new StringBuilder();
                            // �i��
                            keySBuilder.Append(rowInfo.GoodsNo);
                            // ���[�J�[
                            keySBuilder.Append(rowInfo.GoodsMakerCd);
                            // BL�R�[�h
                            keySBuilder.Append(rowInfo.TbsPartsCode);
                            // QTY
                            keySBuilder.Append(rowInfo.PartsQty);
                            // ���Y�N��
                            keySBuilder.Append(rowInfo.ModelPrtsAdptYm);
                            keySBuilder.Append(rowInfo.ModelPrtsAblsYm);
                            // ���Y�ԑ�ԍ�
                            keySBuilder.Append(rowInfo.ModelPrtsAdptFrameNo);
                            keySBuilder.Append(rowInfo.ModelPrtsAblsFrameNo);
                            // ��ڰ��
                            keySBuilder.Append(rowInfo.ModelGradeNm);
                            // ���ި
                            keySBuilder.Append(rowInfo.BodyName);
                            // �ޱ
                            keySBuilder.Append(rowInfo.DoorCount);
                            // �ݼ��
                            keySBuilder.Append(rowInfo.EngineModelNm);
                            // �r�C��
                            keySBuilder.Append(rowInfo.EngineDisplaceNm);
                            // E�敪
                            keySBuilder.Append(rowInfo.EDivNm);
                            // Я���
                            keySBuilder.Append(rowInfo.TransmissionNm);
                            // �쓮�`��
                            keySBuilder.Append(rowInfo.WheelDriveMethodNm);
                            // ���
                            keySBuilder.Append(rowInfo.ShiftNm);
                            // �E�v
                            keySBuilder.Append(rowInfo.PartsOpNm);

                            if (!checkGroupDty.ContainsKey(keySBuilder.ToString()))
                            {
                                list = new List<FreeSearchParts>();
                                list.Add(rowInfo);
                                checkGroupDty.Add(keySBuilder.ToString(), list);
                            }
                            else
                            {
                                list = checkGroupDty[keySBuilder.ToString()];
                                list.Add(rowInfo);
                            }
                        }
                        foreach (List<FreeSearchParts> lst in checkGroupDty.Values)
                        {
                            if (lst.Count == 1)
                            {
                                this._freeSearchPartsDty.Add(lst[0].FreSrchPrtPropNo, lst[0]);
                                FreeSearchPartsToDataSet(lst[0]);
                                //ADD 2010/07/01 ------------------>>>
                                if (goodsNoComp.ContainsKey(lst[0].FreSrchPrtPropNo))
                                    goodsNoComp.Remove(lst[0].FreSrchPrtPropNo);

                                goodsNoComp.Add(lst[0].FreSrchPrtPropNo, lst[0].GoodsNo.Replace("-", string.Empty) + lst[0].GoodsMakerCd.ToString().PadLeft(4, '0') + lst[0].TbsPartsCode.ToString().PadLeft(5, '0'));
                                //ADD 2010/07/01 ------------------>>>
                            }
                            else
                            {
                                // �^���O���[�v�敪
                                string fullModelGroup = Guid.NewGuid().ToString();
                                bool addFlg = true;
                                foreach (FreeSearchParts fsp in lst)
                                {
                                    fsp.FullModelGroup = fullModelGroup;
                                    this._freeSearchPartsDty.Add(fsp.FreSrchPrtPropNo, fsp);
                                    if (addFlg)
                                    {
                                        FreeSearchPartsToDataSet(fsp);

                                        //ADD 2010/07/01 ------------------>>>
                                        if(goodsNoComp.ContainsKey(fsp.FreSrchPrtPropNo))
                                            goodsNoComp.Remove(fsp.FreSrchPrtPropNo);

                                        goodsNoComp.Add(fsp.FreSrchPrtPropNo, fsp.GoodsNo.Replace("-", string.Empty) + fsp.GoodsMakerCd.ToString().PadLeft(4, '0') + fsp.TbsPartsCode.ToString().PadLeft(5, '0'));
                                        //ADD 2010/07/01 ------------------>>>
                                        addFlg = false;
                                    }
                                }
                            }
                        }
                        updateModeFlg = true; // ADD 2010/07/01----->>>>
                    }
                }
                // 
                if (this._detailDataTable.Rows.Count == 0)
                {
                    this.DetailRowInitialSetting(1);
                }
                else
                {
                    string guidStr = Guid.NewGuid().ToString().Replace("-", "");

                    DataRow row = this._detailDataTable.NewRow();
                    row[PMJKN09011UC.COL_NO_TITLE] = this._detailDataTable.Rows.Count + 1;
                    row[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = guidStr;

                    //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
                    FreeSearchParts freeSearchParts = new FreeSearchParts();
                    // ���R�������i�ŗL�ԍ�
                    freeSearchParts.FreSrchPrtPropNo = guidStr;
                    // ��ƃR�[�h
                    freeSearchParts.EnterpriseCode = this._enterpriseCode;
                    // ���[�J�[�R�[�h
                    freeSearchParts.MakerCode = this._makerCode;
                    // �Ԏ�R�[�h
                    freeSearchParts.ModelCode = this._modelCode;
                    // �Ԏ�T�u�R�[�h
                    freeSearchParts.ModelSubCode = this._modelSubCode;
                    // �^���i�t���^�j
                    freeSearchParts.FullModel = this._fullModel;
                    // �f�[�^�X�e�[�^�X:�@2 �V�K�ǉ��f�[�^
                    freeSearchParts.DataStatus = DATASTATUSCODE_2;
                    if (!this._freeSearchPartsDty.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                        this._freeSearchPartsDty.Add(freeSearchParts.FreSrchPrtPropNo, freeSearchParts);

                    if (!_newLineRowIndexDic.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                        this._newLineRowIndexDic.Add(freeSearchParts.FreSrchPrtPropNo, this._detailDataTable.Rows.Count);
                    //ADD END 2009/05/24 GEJUN FOR REDMINE#8049

                    this._detailDataTable.Rows.Add(row);
                }
                // ���׃O���b�h��DropDownValue�ǉ�����
                this.AddDetailsGridValueList();
                // ���׃O���b�h��DropDown�\���ݒ菈��
                this.SettingDetailsGridCol();
                // ���׃O���b�h�ݒ菈��
                this.SettingGrid();

                this.uGrid_Details.Rows[0].Cells[1].Activate();
                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
            // add start 2010/06/24 by gejun for RedMine #10103
            else
                result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            return result;
            // add end 2010/06/24 by gejun for RedMine #10103
		}

		/// <summary>
		/// ���R�������i�I�u�W�F�N�g�W�J����
		/// </summary>
		/// <param name="rowInfo">���R�������i�I�u�W�F�N�g</param>
		private void FreeSearchPartsToDataSet(FreeSearchParts rowInfo)
		{
			DataRow dataRow = this._detailDataTable.NewRow();
			this._detailDataTable.Rows.Add(dataRow);

			//�i��
			dataRow[PMJKN09011UC.COL_GOODSNO_TITLE] = rowInfo.GoodsNo;
			//���[�J�[
			dataRow[PMJKN09011UC.COL_MAKER_TITLE] = rowInfo.GoodsMakerCd.ToString().PadLeft(4, '0');
			//BL�R�[�h
            dataRow[PMJKN09011UC.COL_BLCODE_TITLE] = rowInfo.TbsPartsCode.ToString().PadLeft(5, '0');

            object retObj;
            switch (this.SearchGoodsAndRemain(rowInfo.GoodsNo, string.Empty, rowInfo.GoodsMakerCd, out retObj))
            {
                case 0:
                    {
                        if (retObj != null)
                        {
                            // ���i����
                            if (retObj is List<GoodsUnitData>)
                            {
                                List<GoodsUnitData> goodsUnitDataList = (List<GoodsUnitData>)retObj;

                                if (((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList != null && ((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList.Count > 0)
                                {
                                    GoodsPrice gp = ((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList[0];

                                    // �W�����i
                                    if (gp.ListPrice > 999)
                                        dataRow[PMJKN09011UC.COL_COSTRATE_TITLE] = String.Format("{0:0,0}", gp.ListPrice);
                                    else
                                        dataRow[PMJKN09011UC.COL_COSTRATE_TITLE] = gp.ListPrice.ToString();
                                }
                                else
                                {
                                    // �W�����i
                                    dataRow[PMJKN09011UC.COL_COSTRATE_TITLE] = "0";
                                }
                            }
                        }
                        break;
                    }
                case -1:
                    {
                        //�W�����i
                        dataRow[PMJKN09011UC.COL_COSTRATE_TITLE] = string.Empty;
                        break;
                    }
            }

            //�i��
            dataRow[PMJKN09011UC.COL_GOODSNM_TITLE] = this.GetBLGoodsFullName(Convert.ToInt32(rowInfo.TbsPartsCode)); 

			//QTY
			dataRow[PMJKN09011UC.COL_PARTSQTY_TITLE] = rowInfo.PartsQty;
            //���Y�N���i�J�n���t�|�I�����t�j
            string strModelPrts = "";
            string endModelPrts = "";
            if (rowInfo.ModelPrtsAdptYm != DateTime.MinValue)
            {
                strModelPrts = String.Format("{0:yyyyMM}", rowInfo.ModelPrtsAdptYm);
            }
            else
            {
                strModelPrts = "      ";
            }
            if (rowInfo.ModelPrtsAblsYm != DateTime.MinValue)
            {
                endModelPrts = String.Format("{0:yyyyMM}", rowInfo.ModelPrtsAblsYm);
            }
            else
            {
                endModelPrts = "      ";
            }
            //���Y�N���i�J�n���t�|�I�����t�j
            dataRow[PMJKN09011UC.COL_CREATEYEAR_TITLE] = strModelPrts + endModelPrts;

            //���Y�ԑ�ԍ��i�J�n�ԍ��|�I���ԍ��j
            StringBuilder strModelPrtsAdpt = new StringBuilder();
            StringBuilder strModelPrtsAbls = new StringBuilder();
            if (rowInfo.ModelPrtsAdptFrameNo == 0)
            {
                strModelPrtsAdpt.Append("        ");
            }
            else if (rowInfo.ModelPrtsAdptFrameNo.ToString().Length < 8)
            {
                strModelPrtsAdpt.Append(rowInfo.ModelPrtsAdptFrameNo.ToString());
                for (int i = rowInfo.ModelPrtsAdptFrameNo.ToString().Length; i < 8; i++)
                {
                    strModelPrtsAdpt.Append(" ");
                }
            }
            else
            {
                strModelPrtsAdpt.Append(rowInfo.ModelPrtsAdptFrameNo.ToString());
            }
            if (rowInfo.ModelPrtsAblsFrameNo == 0)
            {
                strModelPrtsAbls.Append("        ");
            }
            else if (rowInfo.ModelPrtsAblsFrameNo.ToString().Length < 8)
            {
                strModelPrtsAbls.Append(rowInfo.ModelPrtsAblsFrameNo.ToString());
                for (int i = rowInfo.ModelPrtsAdptFrameNo.ToString().Length; i < 8; i++)
                {
                    strModelPrtsAbls.Append(" ");
                }
            }
            else
            {
                strModelPrtsAbls.Append(rowInfo.ModelPrtsAblsFrameNo.ToString());
            }
            dataRow[PMJKN09011UC.COL_CREATECARNO_TITLE] = strModelPrtsAdpt.ToString() + strModelPrtsAbls.ToString();

			//�O���[�h
			dataRow[PMJKN09011UC.COL_MODELGRADENM_TITLE] = rowInfo.ModelGradeNm;
			//�{�f�B
			dataRow[PMJKN09011UC.COL_BODYNAME_TITLE] = rowInfo.BodyName;
			//�h�A
            if (rowInfo.DoorCount == 0)
            {
                dataRow[PMJKN09011UC.COL_DOORCOUNT_TITLE] = string.Empty;
            }
            else
            {
                dataRow[PMJKN09011UC.COL_DOORCOUNT_TITLE] = rowInfo.DoorCount;
            }
			//�G���W��
			dataRow[PMJKN09011UC.COL_ENGINEMODELNM_TITLE] = rowInfo.EngineModelNm;
			//�r�C��
			dataRow[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE] = rowInfo.EngineDisplaceNm;
			//E�敪
			dataRow[PMJKN09011UC.COL_EDIVNM_TITLE] = rowInfo.EDivNm;
			//�~�b�V����
			dataRow[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE] = rowInfo.TransmissionNm;
			//�쓮�`��
			dataRow[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE] = rowInfo.WheelDriveMethodNm;
			//�V�t�g
			dataRow[PMJKN09011UC.COL_SHIFTNM_TITLE] = rowInfo.ShiftNm;
			//�E�v
			dataRow[PMJKN09011UC.COL_ADDICARSPEC_TITLE] = rowInfo.PartsOpNm;
			//���R�������i�ŗL�ԍ�
			dataRow[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = rowInfo.FreSrchPrtPropNo;
			//�^���O���[�v�敪
			dataRow[PMJKN09011UC.COL_FULLMODELGROUP_TITLE] = rowInfo.FullModelGroup;
		}

		/// <summary>
		/// �I������
		/// </summary>
		/// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
		private void Close(bool isConfirm)
		{
			bool canClose = this.ShowSaveCheckDialog(isConfirm);

			if (canClose)
			{
				this.Close();
			}
		}

		/// <summary>
		/// �ۑ��m�F�_�C�A���O�\������
		/// </summary>
		/// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
		/// <returns>�m�F��OK �m�F��NG</returns>
		private bool ShowSaveCheckDialog(bool isConfirm)
		{
			bool checkedValue = false;

            if (this.CheckChangedData())
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
					"�o�^���Ă���낵���ł����H",
					0,
					MessageBoxButtons.YesNoCancel,
					MessageBoxDefaultButton.Button2);

				if (dialogResult == DialogResult.Yes)
				{
                    //checkedValue = this.Save(); // DEL 2010/07/01------------>>>
                    checkedValue = this.Save(true); // ADD 2010/07/01------------>>>
				}
				else if (dialogResult == DialogResult.No)
				{
                    if (isConfirm)
				    {
                        this.Close();
                    }
                    checkedValue = true;
				}
			}
			else
			{
				checkedValue = true;
			}

			return checkedValue;
		}


        /// <summary>
        /// �������͂̂݃Z���̃`�F�b�N����
        /// </summary>
        /// <param name="numStr">�Z�����e</param>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <param name="columnKey">��L�[</param>
        private bool CheckNumber(String numStr, int rowIndex, string columnKey)
        {
            char[] numChar = null;

            if (!PMJKN09011UC.COL_MAKER_TITLE.Equals(columnKey) && !PMJKN09011UC.COL_BLCODE_TITLE.Equals(columnKey)
                && !PMJKN09011UC.COL_PARTSQTY_TITLE.Equals(columnKey)
                && !PMJKN09011UC.COL_DOORCOUNT_TITLE.Equals(columnKey))
                return true;

            if (numStr != null)
                numChar = numStr.ToCharArray();
     
            if(numChar != null)
            {
                foreach (char obj in numChar)
                {
                    if (obj > '9' || obj < '0')
                    {
                        TMsgDisp.Show(this,
                                       emErrorLevel.ERR_LEVEL_INFO,
                                       this.Name,
                                       columnKey�@+ "�̓��͂��s���ł��B",
                                       -1,
                                       MessageBoxButtons.OK);

                        return false;

                    }
                }

            }
            return true;
        }

        /// <summary>
        /// �Z���̑O����e�ݒ菈��
        /// </summary>
        /// <param name="columnKey">�O�����L�[</param>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <param name="colIndex">��ԍ�</param>
        private void SetCellBeforeValue(string columnKey, int rowIndex, int colIndex)
        {
            string freSrchPrtPropNo = this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
            this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            if (this._freeSearchPartsDty != null)
            {
                if (this._freeSearchPartsDty.ContainsKey(freSrchPrtPropNo))
                {
                    FreeSearchParts freeSearchParts = (FreeSearchParts)this._freeSearchPartsDty[freSrchPrtPropNo];
                    if (PMJKN09011UC.COL_MAKER_TITLE.Equals(columnKey))
                    {
                        if (freeSearchParts.GoodsMakerCd == 0)
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                        else
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = freeSearchParts.GoodsMakerCd.ToString().PadLeft(4, '0');
                    }
                    else if (PMJKN09011UC.COL_BLCODE_TITLE.Equals(columnKey))
                    {
                        if (freeSearchParts.TbsPartsCode == 0)
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                        else
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = freeSearchParts.TbsPartsCode.ToString().PadLeft(5, '0');
                    }
                    else if (PMJKN09011UC.COL_PARTSQTY_TITLE.Equals(columnKey))
                    {
                        if (freeSearchParts.PartsQty == 0)
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                        else
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = freeSearchParts.PartsQty.ToString();
                    }
                    else if (PMJKN09011UC.COL_DOORCOUNT_TITLE.Equals(columnKey))
                    {
                        if (freeSearchParts.DoorCount == 0)
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                        else
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = freeSearchParts.DoorCount.ToString();
                    }
                    else if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(columnKey))
                    {
                        if (this._freeSearchPartsDty[freSrchPrtPropNo].ModelPrtsAblsYm == DateTime.MinValue
                                            && this._freeSearchPartsDty[freSrchPrtPropNo].ModelPrtsAdptYm == DateTime.MinValue)
                        {
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "____.__ - ____.__";
                        }
                        else
                        {
                            string modelPrtsAdptYm = String.Format("{0:yyyyMM}", this._freeSearchPartsDty[freSrchPrtPropNo].ModelPrtsAdptYm);
                            string modelPrtsAblsYm = String.Format("{0:yyyyMM}", this._freeSearchPartsDty[freSrchPrtPropNo].ModelPrtsAblsYm);
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = modelPrtsAdptYm + " - " + modelPrtsAblsYm;
                        }
                    }
                    else
                        uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                }
                else
                {
                    if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(columnKey))
                        uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "____.__ - ____.__";
                    else
                        uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                }
                this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            }
        }


		/// <summary>
        /// �ҏW���f�[�^�`�F�b�N����
        /// </summary>
        /// <returns></returns>
        private bool CheckChangedData()
        {
            bool flg = false;

            #region ��ʓ��͒l�`�F�b�N
            if (this.tNedit_MakerCode.GetInt() != 0)//���[�J�[�R�[�h
            {
                return true;
            }

            if (this.tNedit_ModelCode.GetInt() != 0) // �Ԏ�R�[�h
            {
                return true;
            }

            if (this.tNedit_ModelSubCode.GetInt() != 0) // �Ԏ�T�u�R�[�h
            {
                return true;
            }

            if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text)) // �^���i�t���^�j
            {
                return true;
            }

            if (this.tNedit_ModelDesignationNo.GetInt() != 0)// �^���w��ԍ�
            {
                return true;
            }

            if (this.tNedit_CategoryNo.GetInt() != 0) // �ޕʔԍ�
            {
                return true;
            }

            if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text))
            {
                return true;
            }

            if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text))
            {
                return true;
            }

            if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text))
            {
                return true;
            }

            if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text))
            {
                return true;
            }

            if (!String.IsNullOrEmpty(this.tEdit_StartProduceFrameNo.Text))
            {
                return true;
            }

            if (!String.IsNullOrEmpty(this.tEdit_EndProduceFrameNo.Text))
            {
                return true;
            }

            if (this.tNedit_SearchGoodsNo.GetInt() != 0)
            {
                return true;
            }

            if (tNedit_CmpltGoodsMakerCd.GetInt() != 0)
            {
                return true;
            }

            if (this.tNedit_BlCd.GetInt() != 0)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()))
            {
                return true;
            }

            if (this.tNedit_CmpltGoodsMakerCd.GetInt() != 0)
            {
                return true;
            }

            if (this.tNedit_BlCd.GetInt() != 0)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text))
            {
                return true;
            }

            if (this.tComboEditor_GoodsNoFuzzy.SelectedIndex != 0)
            {
                return true;
            }

            if (this.uGrid_Details.Rows.Count > 1)
            {
                return true;
            }
            else
            {
                foreach (UltraGridCell cell in this.uGrid_Details.Rows[0].Cells)
                {
                    if (!cell.Column.Key.Equals("No.")
                        && !cell.Column.Hidden)
                    {
                        if (!cell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE)
                            && !cell.Column.Key.Equals(PMJKN09011UC.COL_CREATECARNO_TITLE))
                        {
                            if (!string.IsNullOrEmpty(cell.Text))
                            {
                                return true;
                            }
                        }
                        else if (cell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE))
                        {
                            if (!cell.Text.Equals("____.__ - ____.__"))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (!cell.Text.Equals("________ - ________"))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            #endregion

            return flg;
        }

		/// <summary>
		/// �K�C�h�N������
		/// </summary>
		private void ExecuteGuide()
		{
			if (this._lastControl == null) return;

            string key = this._lastControl.Name;
            if (_lastControl.Name.Equals("_Form1_Toolbars_Dock_Area_Top"))
            {
                key = this._prevControl.Name;
            }
            //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
            int columnIndex = 0;
            if(uGrid_Details.ActiveCell != null)
                columnIndex = uGrid_Details.ActiveCell.Column.Index;
            
            // Ұ���Ƀt�H�[�J�X������
            if(tNedit_CmpltGoodsMakerCd.Focused)
                key = "tNedit_CmpltGoodsMakerCd";
            else if (tNedit_BlCd.Focused)
                key = "tNedit_BlCd";
            else if (columnIndex == 2 || columnIndex == 3)
                key = "uGrid_Details";
            // BL��ĂɃt�H�[�J�X������
            //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
                switch (key)
                {
                    // �Ԏ�K�C�h�N��
                    case "tNedit_MakerCode":
                    case "tNedit_ModelCode":
                    case "tNedit_ModelSubCode":
                        {
                            this.uButton_ModelFullGuide_Click(this, new EventArgs());
                            break;
                        }
                    // ���[�J�[�K�C�h�N��
                    case "tNedit_CmpltGoodsMakerCd":
                        {
                            this.uButton_CmpltGoodsMakerGuide_Click(this, new EventArgs());
                            break;
                        }
                    // BL�R�[�h�K�C�h�N��
                    case "tNedit_BlCd":
                        {
                            this.uButton_BlCodeGuide_Click(this, new EventArgs());
                            break;
                        }
                    case "uGrid_Details":
                        {
                            ExecuteGridGuide();
                            break;
                        }
                }

		}

		/// <summary>
		/// �O�b���h�K�C�h�N������
		/// </summary>
		private void ExecuteGridGuide()
		{
			UltraGridCell cell = this.uGrid_Details.ActiveCell;

			if (cell == null) return;

			// �}�[�J�[�̏ꍇ
			if (cell.Column.Key.Equals(PMJKN09011UC.COL_MAKER_TITLE))
			{
				MakerAcs makerAcs = new MakerAcs();
				MakerUMnt makerUMnt;

				//���[�J�[�f�[�^�̎擾
				int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					//���[�J�[
					cell.Value = makerUMnt.GoodsMakerCd;

                    // add start 2010/06/21 by gejun for RedMine #10103
                    uGrid_Details.Rows[cell.Row.Index].Cells[cell.Column.Index + 1].Activate();
                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    // add end 2010/06/21 by gejun for RedMine #10103
				}
			}
			// BL�R�[�h�̏ꍇ
			else if (cell.Column.Key.Equals(PMJKN09011UC.COL_BLCODE_TITLE))
			{
				BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
				BLGoodsCdUMnt bLGoodsCdUMnt;
				//BL�R�[�h�f�[�^�̎擾
				int status = bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					//BL�R�[�h
					cell.Value = bLGoodsCdUMnt.BLGoodsCode;

                    // add start 2010/06/21 by gejun for RedMine #10103
                    uGrid_Details.Rows[cell.Row.Index].Cells[cell.Column.Index + 2].Activate(); 
                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    // add end 2010/06/21 by gejun for RedMine #10103
				}
			}
		}


		/// <summary>
		/// ValueList�̃N���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ValueList�̃N���A�������s���܂��B</br>
		/// <br>Programmer : �я���</br> 
		/// <br>Date  : 2010/04/26</br>
		/// </remarks>
		private void ClearValueList()
		{
			this._modelGradeValueList = new ValueList();
			this._modelGradeValueList.ValueListItems.Clear();
			this._modelGradeValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._bodyNameValueList = new ValueList();
			this._bodyNameValueList.ValueListItems.Clear();
			this._bodyNameValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._doorCountValueList = new ValueList();
			this._doorCountValueList.ValueListItems.Clear();
			this._doorCountValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._engineModelValueList = new ValueList();
			this._engineModelValueList.ValueListItems.Clear();
			this._engineModelValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._engineDisplaceValueList = new ValueList();
			this._engineDisplaceValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._eDivValueList = new ValueList();
			this._eDivValueList.ValueListItems.Clear();
			this._eDivValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._transmissionValueList = new ValueList();
			this._transmissionValueList.ValueListItems.Clear();
			this._transmissionValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._wheelDriveMethodValueList = new ValueList();
			this._wheelDriveMethodValueList.ValueListItems.Clear();
			this._wheelDriveMethodValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._shiftValueList = new ValueList();
			this._shiftValueList.ValueListItems.Clear();
			this._shiftValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);
		}

		/// <summary>
		/// �N���A����
		/// </summary>
		/// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
		private void Clear(bool isConfirm)
		{
            bool canClear = false;

            if (isConfirm)
            {
                canClear = this.ShowSaveCheckDialog(false);
            }
            else
            {
                canClear = true;
            }

			if (canClear)
			{
				// �ޕ�
				this.tNedit_ModelDesignationNo.Clear();
				this.tNedit_CategoryNo.Clear();

				this.tNedit_MakerCode.Clear();
				this.tNedit_ModelCode.Clear();
				this.tNedit_ModelSubCode.Clear();
				this.tEdit_ModelFullName.Clear();

				this.tEdit_FullModel.Clear();


				this.tDateEdit_StartEntryYearDate.Clear();
				this.tDateEdit_StartEntryMonthDate.Clear();
				this.tDateEdit_EndEntryYearDate.Clear();
				this.tDateEdit_EndEntryMonthDate.Clear();

				this.tEdit_StartProduceFrameNo.Clear();
				this.tEdit_EndProduceFrameNo.Clear();

				this._carSpecDataSet.Clear();

				this.tNedit_SearchGoodsNo.Clear();
				this.StartSearchGoodsNo.Clear();
				this.EndSearchGoodsNo.Clear();

                this.tNedit_CmpltGoodsMakerCd.Clear();
                this.tEdit_CmpltMakerName.Clear();
                this.tNedit_BlCd.Clear();
                this.tEdit_BlName.Clear();
                this.tEdit_GoodsNo.Clear();
                this.tComboEditor_GoodsNoFuzzy.SelectedIndex = 0;

				// ValueList�̃N���A����
				this.ClearValueList();
				this.SettingDetailsGridCol();
				// ���׃f�[�^�e�[�u���̏����ݒ���s���܂��B
				this.DetailRowInitialSetting(DEFAULT_ROW_COUNT);

                this.SettingGrid();
                this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Clear();
                DataRow row = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].NewRow();
                this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Add(row);
                this._selectCarModelInfoDataTable.Rows.Clear();
                this.ultraGrid_CarSpec.Rows[0].Activation = Activation.Disabled;

                // �I��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                // �N���A
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
                // �ŐV���
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
                // �ۑ�
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                // ����
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                // �s�폜
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                // �S�폜
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
                // �K�C�h
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                // ���p�o�^
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                this.tNedit_ModelDesignationNo.Focus();

                //add start 2009/06/22 by gejun for RedMine #10103
                // ��r�p�ޕ�
                this._categoryNo = "";
                // ��r�p�Ԏ�
                this._fullCarType = "";
                // ��r�p�^��
                this._designationNo = "";
                // ��r�p�����ԍ�
                this._searchNo = 0;

                updateModeFlg = false; // ADD 2010/07/01----->>>>
                //add end 2009/06/22 by gejun for RedMine #10103
			}
		}

		/// <summary>
		/// IsDate
		/// </summary>
		/// <param name="date">date</param>
		/// <returns>bool</returns>
		public bool IsDate(string date)
		{
			DateTime dt;
			bool isDate = true;
			try
			{
				dt = DateTime.Parse(date);
			}
			catch (FormatException)
			{
				isDate = false;
			}

			return isDate;
		}

		/// <summary>
		/// ���׍s�ǉ�����
		/// </summary>
		internal void AddNewDetailRow()
		{
			// ���R�������i�ŗL�ԍ�
			string freSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");

			DataRow dr = this._detailDataTable.NewRow();
			dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = freSrchPrtPropNo;

            //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
            FreeSearchParts freeSearchParts = new FreeSearchParts();
            // ���R�������i�ŗL�ԍ�
            freeSearchParts.FreSrchPrtPropNo = freSrchPrtPropNo;
            // ��ƃR�[�h
            freeSearchParts.EnterpriseCode = this._enterpriseCode;
            // ���[�J�[�R�[�h
            freeSearchParts.MakerCode = this._makerCode;
            // �Ԏ�R�[�h
            freeSearchParts.ModelCode = this._modelCode;
            // �Ԏ�T�u�R�[�h
            freeSearchParts.ModelSubCode = this._modelSubCode;
            // �^���i�t���^�j
            freeSearchParts.FullModel = this._fullModel;
            // �f�[�^�X�e�[�^�X:�@2 �V�K�ǉ��f�[�^
            freeSearchParts.DataStatus = DATASTATUSCODE_2;
            if(!_freeSearchPartsDty.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                this._freeSearchPartsDty.Add(freeSearchParts.FreSrchPrtPropNo, freeSearchParts);

            if (!_newLineRowIndexDic.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                this._newLineRowIndexDic.Add(freeSearchParts.FreSrchPrtPropNo, this._detailDataTable.Rows.Count);
            //ADD END 2009/05/24 GEJUN FOR REDMINE#8049

			this._detailDataTable.Rows.Add(dr);
		}

		/// <summary>
		/// ActiveRow�̍s�ԍ��擾����
		/// </summary>
		/// <returns>�s�ԍ�</returns>
		internal int GetActiveDetailRowNo()
		{
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex < 0) return -1;

			return Convert.ToInt32(this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_NO_TITLE]);
		}

		/// <summary>
		/// ���׃O���b�h�ݒ菈��
		/// </summary>
		internal void SettingGrid()
		{
			try
			{
				this.uGrid_Details.InitializeLayout -= new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
				// �s���̍Đݒ�
				DataRow dr = null;
				for (int rowNum = 0; rowNum < this._detailDataTable.Rows.Count; rowNum++)
				{
					dr = this._detailDataTable.Rows[rowNum];
					dr[PMJKN09011UC.COL_NO_TITLE] = rowNum + 1;
				}
				foreach (DataRow row in _detailDataTable.Rows)
				{
					if (string.IsNullOrEmpty(row[PMJKN09011UC.COL_CREATEYEAR_TITLE].ToString()))
					{
						row[PMJKN09011UC.COL_CREATEYEAR_TITLE] = "____.__-____.__";
					}
                    else if (string.IsNullOrEmpty(row[PMJKN09011UC.COL_CREATECARNO_TITLE].ToString()))
                    {
                        row[PMJKN09011UC.COL_CREATECARNO_TITLE] = "________ - ________";
                    }
				}

                this.uGrid_Details.DataSource = this._detailDataTable;
				this.uGrid_Details.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
                //del start  START 2010/06/24 GEJUN FOR REDMINE #10103
                //if (this.uGrid_Details.Rows.Count >= 0)
                //{
                //    this.uGrid_Details.Rows[0].Cells[1].Activate();
                //    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                //}
                //del end  START 2010/06/24 GEJUN FOR REDMINE #10103
			}
			finally
			{
			}
		}
		# endregion

		/// <summary>
		/// Grid�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
		{
            // ���ו��Ƀt�H�[�J�X�L��(GridActive)
            // �I��
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
            // �N���A
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
            // �ŐV���
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
            // �ۑ�
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
            // �s�폜
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
            // ADD 2010/07/01----->>>
            // �S�폜
            if(updateModeFlg)
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = true;
            // ADD 2010/07/01----->>>

            //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
            //IME�̃`�F���W
            if ((e.Cell.Column.Key.Equals(PMJKN09011UC.COL_ADDICARSPEC_TITLE)))
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            else
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Close;
            //ADD END 2009/05/21 GEJUN FOR REDMINE#8049

            // ���ׂ̃��[�J�[�ABL�R�[�h
            if ((e.Cell.Column.Key.Equals(PMJKN09011UC.COL_MAKER_TITLE)) ||
                (e.Cell.Column.Key.Equals(PMJKN09011UC.COL_BLCODE_TITLE)))
            {
                // �K�C�h
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
            }
            else
            {
                // �K�C�h
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;

            }
            //MODIFY START 2009/05/24 GEJUN FOR REDMINE#8049
            // ���ׂ̕i��
            //if (!string.IsNullOrEmpty(e.Cell.Row.Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Text))
            //{
            // ���p�o�^
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = true;
            //}
            //else
            //{
            //    // ���p�o�^
            //    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
            //}
            //MODIFY START 2009/05/24 GEJUN FOR REDMINE#8049
            // add start 2009/06/22 by gejun for RedMine #10103
            if ("".Equals(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Text))
            {
                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Value = "____.__ - ____.__";
            }
            // add end 2009/06/22 by gejun for RedMine #10103
		}

        /// <summary>
        /// BeforeEnterEditMode
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // ����
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
        }

        /// <summary>
        /// BLGoodsFullName�̎擾
        /// </summary>
        /// <param name="blCode">BL�R�[�h</param>
        /// <returns>BLGoodsFullName</returns>
        private string GetBLGoodsFullName(int blCode)
        {
            //-----------------------------------------------------------------------------
            // BL�R�[�h����
            //-----------------------------------------------------------------------------
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            List<Stock> stockList = new List<Stock>();

            // BL�R�[�h�̐ݒ�

            BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
            BLGoodsCdUMnt bLGoodsCdUMnt;

            int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //>>>2010/07/02
                //return bLGoodsCdUMnt.BLGoodsFullName;
                return bLGoodsCdUMnt.BLGoodsHalfName;
                //<<<2010/07/02
            }

            return "";
        }

        /// <summary>
        /// �p�����[�^�̃`�F�b�N
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        private bool CheckSearchParam()
        {

            if (string.IsNullOrEmpty(tEdit_FullModel.Text.Trim()))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�^������͂��ĉ������B",
                           0,
                           MessageBoxButtons.OK,
                          MessageBoxDefaultButton.Button1);
                this.tEdit_FullModel.Focus();
                // ����
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                // �K�C�h
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                return false;
            }


            if (string.IsNullOrEmpty(tNedit_MakerCode.Text.Trim()))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�Ԏ����͂��ĉ������B",
                           0,
                           MessageBoxButtons.OK,
                          MessageBoxDefaultButton.Button1);
                this.tNedit_MakerCode.Focus();
                // ����
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                return false;
            }

            return true;
        }
	}
}
