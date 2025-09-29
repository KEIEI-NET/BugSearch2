//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^�t�H�[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10602352-00 �쐬�S�� : �я���
// �� �� ��  2010/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �� �� ��  2010/05/16  �C�����e : #7517 �������̎擾�A#7604 �e��d�l�ύX�^��Q�Ή��A#7635 �e��d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �� �� ��  2010/05/20  �C�����e : �X�V���[�h�̏������A���Y�ԑ�ԍ��`�b�N�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �� �� ��  2010/06/22  �C�����e : #10097 ���R�����^���}�X�^�@�e��d�l�ύX�^��Q�Ή�
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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Globarization;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R�����^���}�X�^�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R�����^���}�X�^�̃t�H�[���N���X�ł��B</br>
	/// <br>Programmer : �я���</br>
	/// <br>Date       : 2010.04.26</br>
	/// <br>UpdateNote : 2010/05/16 �I�M redmine#7517�A7604�A7635�̑Ή�</br>
	/// <br></br>
	public partial class PMJKN09001UA : Form
	{

		# region Private Members
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		// ���݂̃R���g���[��
		private Control _prevControl = null;
		// �������O���b�h
		private DataSet _carSpecDataSet;
		//�O���[�h���X�g
		private ValueList _modelGradeValueList;
		//�{�f�B���X�g
		private ValueList _bodyNameValueList;
		//�h�A���X�g
		private ValueList _doorCountValueList;
		//�G���W�����X�g
		private ValueList _engineModelValueList;
		//�r�C�ʃ��X�g
		private ValueList _engineDisplaceValueList;
		//E�敪���X�g
		private ValueList _eDivValueList;
		//�~�b�V�������X�g
		private ValueList _transmissionValueList;
		//�쓮�`�����X�g
		private ValueList _wheelDriveMethodValueList;
		//�V�t�g���X�g
		private ValueList _shiftValueList;
		// ������̓A�N�Z�X�N���X
		private PMKEN01010E.CarModelInfoDataTable _carModelInfoDataTable;
		// ���R�����^���}�X�^�e�[�u���A�N�Z�X�N���X
		private FreeSearchModelAcs _freeSearchModelAcs;
		// ���R�����^���Œ�ԍ�
		private string _freeSrchMdlFxdNo;
		// �X�V����
		private DateTime _updateTime;
		// ImageList
		private ImageList _imageList16 = null;
		// ��ʃC���[�W�R���g���[�����i
		private ControlScreenSkin _controlScreenSkin;
		// �r�K�X�L��
		private string _exhaustGasSign;
		// �V���[�Y�^��
		private string _seriesModel;
		// �^���i�ޕʋL���j
		private string _categorySignModel;
		// ----- ADD 2010/05/16 ------------------->>>>>
		// ��ʍ��ڍĐݒ�t���O
		private bool _valueChageFlg = false;
		// �V�K���[�h��ʍ��ڍĐݒ�t���O
		private bool _clearChangeFlg = false;
		// ----- ADD 2010/05/16 -------------------<<<<<
		// ----- ADD 2010/05/20 ------------------->>>>>
		// �X�V���[�h��ʍ��ڍĐݒ�t���O
		private bool _clearUpdateFlg = false;
		// ----- ADD 2010/05/20 -------------------<<<<<
		# endregion


		# region Private Fields
		// ===================================================================================== //
		// �v���C�x�[�g�萔
		// ===================================================================================== //
		// ��ƃR�[�h
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		// ���_�R�[�h
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
		// �N���X��
		private string ct_PRINTNAME = "���R�����^���}�X�^";
		// �h�A�t�H�[�}�b�g
		private const string FORMAT_DOORNO = "nn";
		// ���o�^
		private const string un_INSERT = "���o�^";
		# endregion


		# region Constructors
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		/// <summary>
		/// ���R�����^���}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
		/// </summary>
		public PMJKN09001UA()
		{
			InitializeComponent();

			_carSpecDataSet = new DataSet();

			_carModelInfoDataTable = new PMKEN01010E.CarModelInfoDataTable();
			_controlScreenSkin = new ControlScreenSkin();

			this.ClearValueList();

			this._imageList16 = IconResourceManagement.ImageList16;

			this._freeSearchModelAcs = new FreeSearchModelAcs();
			this._freeSrchMdlFxdNo = string.Empty;
			this._updateTime = new DateTime();
		}
		#endregion


		# region  �t�H�[�����[�h
		/// <summary>
		/// ��ʂ̏���������
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>  
		/// <br>Note  : ��ʂ̏��������s���B</br>
		/// <br>Programmer : �я���</br> 
		/// <br>Date  : 2010/04/26</br>
		/// </remarks>
		private void PMJKN09000UA_Load(object sender, EventArgs e)
		{
			// ��ʃC���[�W���� 
			// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.LoadSkin();

			// ��ʃX�L���ύX
			this._controlScreenSkin.SettingScreenSkin(this);

			// �������f�[�^�\�[�X�ǉ�
			PMJKN09001UB.DataSetColumnConstruction(ref this._carSpecDataSet);
			DataRow row = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].NewRow();
			this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].Rows.Add(row);
			this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].DefaultView;

			//�c�[���o�[�����ݒ菈��
			this.ToolBarInitilSetting();

			// �{�^�������ݒ菈��
			this.ButtonInitialSetting();

			// �^���O���b�h�\���ݒ菈��
			this.SettingCarSpecGrid();

			// ���[�h�I��
			this.tComboEditor_Model.SelectedIndex = 0;
			this.tComboEditor_Model.Focus();
			this.Mode_Label.Text = "�V�K���[�h";

			// �{�^���c�[���L�������ݒ菈��
			this.SettingToolBarButtonEnabled();

			// ----- ADD 2010/05/16 ------------------->>>>>
			// �{�^���L�������ݒ菈��
			this.InitialSettingButtonEnabled();
			this._clearChangeFlg = false;
			// ----- ADD 2010/05/16 -------------------<<<<<
			this._clearUpdateFlg = false;�@// ADD 2010/05/20

			// ��ʍ��ڂ̐ݒ�
			this.tNedit_ModelDesignationNo.Clear();
			this.tNedit_CategoryNo.Clear();

			this.tEdit_FullModel.Clear();

			this.tDateEdit_StartEntryYearDate.Clear();
			this.tDateEdit_StartEntryMonthDate.Clear();
			this.tDateEdit_EndEntryYearDate.Clear();
			this.tDateEdit_EndEntryMonthDate.Clear();

			this.tEdit_StartProduceFrameNo.Clear();
			this.tEdit_EndProduceFrameNo.Clear();

		}
		# endregion


		# region Private Methods
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //

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
			this._modelGradeValueList.ValueListItems.Add("", "");
			this._modelGradeValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._bodyNameValueList = new ValueList();
			this._bodyNameValueList.ValueListItems.Clear();
			this._bodyNameValueList.ValueListItems.Add("", "");
			this._bodyNameValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._doorCountValueList = new ValueList();
			this._doorCountValueList.ValueListItems.Clear();
			this._doorCountValueList.ValueListItems.Add("", "");
			this._doorCountValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._engineModelValueList = new ValueList();
			this._engineModelValueList.ValueListItems.Clear();
			this._engineModelValueList.ValueListItems.Add("", "");
			this._engineModelValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._engineDisplaceValueList = new ValueList();
			this._engineDisplaceValueList.ValueListItems.Clear();
			this._engineDisplaceValueList.ValueListItems.Add("", "");
			this._engineDisplaceValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._eDivValueList = new ValueList();
			this._eDivValueList.ValueListItems.Clear();
			this._eDivValueList.ValueListItems.Add("", "");
			this._eDivValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._transmissionValueList = new ValueList();
			this._transmissionValueList.ValueListItems.Clear();
			this._transmissionValueList.ValueListItems.Add("", "");
			this._transmissionValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._wheelDriveMethodValueList = new ValueList();
			this._wheelDriveMethodValueList.ValueListItems.Clear();
			this._wheelDriveMethodValueList.ValueListItems.Add("", "");
			this._wheelDriveMethodValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._shiftValueList = new ValueList();
			this._shiftValueList.ValueListItems.Clear();
			this._shiftValueList.ValueListItems.Add("", "");
			this._shiftValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			// --- ADD m.suzuki 2010/06/22 ---------->>>>>
			// �\�[�g�w��
			this._modelGradeValueList.SortStyle = ValueListSortStyle.Ascending;
			this._bodyNameValueList.SortStyle = ValueListSortStyle.Ascending;
			this._doorCountValueList.SortStyle = ValueListSortStyle.Ascending;
			this._engineModelValueList.SortStyle = ValueListSortStyle.Ascending;
			this._engineDisplaceValueList.SortStyle = ValueListSortStyle.Ascending;
			this._eDivValueList.SortStyle = ValueListSortStyle.Ascending;
			this._transmissionValueList.SortStyle = ValueListSortStyle.Ascending;
			this._wheelDriveMethodValueList.SortStyle = ValueListSortStyle.Ascending;
			this._shiftValueList.SortStyle = ValueListSortStyle.Ascending;
			// --- ADD m.suzuki 2010/06/22 ----------<<<<<
		}

		/// <summary>
		/// �^���O���b�h�\���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����O���b�h�̕\���ݒ���s���܂��B</br>
		/// <br>Programmer : �я���</br> 
		/// <br>Date  : 2010/04/26</br>
		/// </remarks>
		private void SettingCarSpecGrid()
		{
			// --- �^���ꗗ�o���h --- //
			ColumnsCollection pareColumns = ultraGrid_CarSpec.DisplayLayout.Bands[PMJKN09001UB.TBL_CARSPECVIEW].Columns;
			//�O���[�h
			pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].ValueList = this._modelGradeValueList;
			// ----- UPD 2010/05/16 ------------------->>>>>
			//pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Width = 130;
			pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Width = 100;
			// ----- UPD 2010/05/16 -------------------<<<<<
			pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].MaxLength = 20;
			//�{�f�B
			pareColumns[PMJKN09001UB.COL_BODYNAME_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_BODYNAME_TITLE].ValueList = this._bodyNameValueList;
			pareColumns[PMJKN09001UB.COL_BODYNAME_TITLE].Width = 80;
			pareColumns[PMJKN09001UB.COL_BODYNAME_TITLE].MaxLength = 10;
			//�h�A
			pareColumns[PMJKN09001UB.COL_DOORCOUNT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_DOORCOUNT_TITLE].ValueList = this._doorCountValueList;
			pareColumns[PMJKN09001UB.COL_DOORCOUNT_TITLE].Width = 60;
			pareColumns[PMJKN09001UB.COL_DOORCOUNT_TITLE].MaxLength = 2;
			//�G���W��
			pareColumns[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].ValueList = this._engineModelValueList;
			pareColumns[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].Width = 110;
			pareColumns[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].MaxLength = 12;
			//�r�C��
			pareColumns[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].ValueList = this._engineDisplaceValueList;
			pareColumns[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].Width = 95;
			pareColumns[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].MaxLength = 8;
			//E�敪
			pareColumns[PMJKN09001UB.COL_EDIVNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_EDIVNM_TITLE].ValueList = this._eDivValueList;
			pareColumns[PMJKN09001UB.COL_EDIVNM_TITLE].Width = 95;
			pareColumns[PMJKN09001UB.COL_EDIVNM_TITLE].MaxLength = 8;
			//�~�b�V����
			pareColumns[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].ValueList = this._transmissionValueList;
			pareColumns[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].Width = 95;
			pareColumns[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].MaxLength = 8;
			//�쓮�`��
			pareColumns[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].ValueList = this._wheelDriveMethodValueList;
			pareColumns[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].Width = 120;
			pareColumns[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].MaxLength = 15;
			//�V�t�g
			pareColumns[PMJKN09001UB.COL_SHIFTNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_SHIFTNM_TITLE].ValueList = this._shiftValueList;
			pareColumns[PMJKN09001UB.COL_SHIFTNM_TITLE].Width = 95;
			pareColumns[PMJKN09001UB.COL_SHIFTNM_TITLE].MaxLength = 8;
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
		/// �����_���̎擾������
		/// </summary>
		/// <param name="belongSectionCode">�����_�R�[�h</param>
		/// <returns>�����_����</returns>
		private string GetOwnSectionName(string belongSectionCode)
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
		#endregion


		#region �c�[���o�[�����ݒ菈��
		/// <summary>
		/// �c�[���o�[�����ݒ菈��
		/// </summary>
		private void ToolBarInitilSetting()
		{
			// ���O�C�����_����
			this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionName"].SharedProps.Caption = GetOwnSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
			// ���O�C���S���Җ���
			this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
		}
		#endregion


		#region  �{�^�������ݒ菈��
		/// <summary>
		/// �{�^�������ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Ȃ�</br>
		/// <br>Programmer : ���`</br>
		/// <br>Date  : 2010/04/22</br>
		/// </remarks>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this.uButton_ModelFullGuide.ImageList = this._imageList16;
			this.uButton_ModelFullGuide.Appearance.Image = (int)Size16_Index.STAR1;

			Infragistics.Win.UltraWinToolbars.LabelTool loginTitleLabel;
			Infragistics.Win.UltraWinToolbars.LabelTool loginSectionTitle;

			loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
			loginSectionTitle = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionTitle"];

			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool saveButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool clearButton;

			Infragistics.Win.UltraWinToolbars.ButtonTool modelAddButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool deleteButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool addButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool newInfoButton;

			closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
			clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];

			modelAddButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"];
			deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"];
			addButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"];
			newInfoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_NewInfo"];

			loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			loginSectionTitle.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

			closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

			modelAddButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CAR;
			deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
			addButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			newInfoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
		}
		# endregion

		/// <summary>
		/// �Ԏ�K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
		{
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
			ModelNameU modelNameU;
			int makerCode = this.tNedit_MakerCode.GetInt();

			int status = modelNameUAcs.ExecuteGuid2(makerCode, this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt(),
				this._enterpriseCode, out modelNameU);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tNedit_MakerCode.SetInt(modelNameU.MakerCode);
				this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
				this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
				this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;

				// ���̍��ڂփt�H�[�J�X�ړ�
				ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_ModelFullGuide, this.uButton_ModelFullGuide);
				//this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
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

			if (this.tNedit_ModelDesignationNo.ExtEdit.Column <= modelDesignationNo.Length)
			{
				this.tNedit_CategoryNo.Enabled = true;
				this.tNedit_CategoryNo.Focus();
			}
			if (string.IsNullOrEmpty(modelDesignationNo))
			{
				this.tNedit_CategoryNo.Enabled = false;
				this.tNedit_CategoryNo.Clear();
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
			this._prevControl = e.NextCtrl;

			// PrevCtrl�ݒ�
			Control prevCtrl = new Control();
			if (e.PrevCtrl is Control) prevCtrl = (Control)e.PrevCtrl;

			// �e��ϐ�������
			Control nextCtrl = null;
			// ----- ADD 2010/05/16 ------------------->>>>>
			if (e.NextCtrl is Control) nextCtrl = (Control)e.NextCtrl;

			if (e.NextCtrl == tEdit_FullModel)
			{
				tDateEdit_StartEntryYearDate.Enabled = true;
				tDateEdit_StartEntryYearDate.Appearance.BackColor = Color.Gainsboro;
			}
			// ----- ADD 2010/05/16 -------------------<<<<<

			switch (prevCtrl.Name)
			{
				#region �^���w��ԍ�
				//---------------------------------------------------------------
				// �^���w��ԍ�
				//---------------------------------------------------------------
				case "tNedit_ModelDesignationNo":
					{
						if ((this.tNedit_ModelDesignationNo.GetInt() != 0)
							&& (this.tNedit_CategoryNo.GetInt() == 0))
						{
							DialogResult dialogResult = TMsgDisp.Show(
							   this,
							   emErrorLevel.ERR_LEVEL_EXCLAMATION,
							   this.Name,
							   "�^���w����͎��́A�ޕʋ敪�͕K�{���͂ł��B",
							   0,
							   MessageBoxButtons.OK,
							   MessageBoxDefaultButton.Button1);
							e.NextCtrl = this.tNedit_CategoryNo;
							this.tNedit_CategoryNo.Enabled = true;
							this._prevControl = e.NextCtrl;
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
						if (this.tComboEditor_Model.SelectedIndex != 0)
						{
							if ((this.tNedit_ModelDesignationNo.GetInt() != 0) &&
								(this.tNedit_CategoryNo.GetInt() != 0))
							{
								if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
								{
									CarSearchCondition con = new CarSearchCondition();
									con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
									con.CategoryNo = this.tNedit_CategoryNo.GetInt();
									con.Type = CarSearchType.csCategory;
									con.FreeSearchModelOnly = true;

									int result = this.CarSearch(con);

									switch ((ConstantManagement.MethodResult)result)
									{
										case ConstantManagement.MethodResult.ctFNC_CANCEL:
											e.NextCtrl = this.tNedit_ModelDesignationNo;
											this._prevControl = e.NextCtrl;
											this.tNedit_ModelDesignationNo.Clear();
											this.tNedit_CategoryNo.Clear();
											break;
										case ConstantManagement.MethodResult.ctFNC_NORMAL:
											nextCtrl = this.tDateEdit_StartEntryYearDate;
											e.NextCtrl = nextCtrl;
											this.tDateEdit_StartEntryYearDate.Focus();
											this._prevControl = this.tDateEdit_StartEntryYearDate;
											// ----- ADD 2010/05/16 ------------------->>>>>
											this.SettingButtonEnabled();
											this.tNedit_ModelDesignationNo.Enabled = false;
											this.tNedit_CategoryNo.Enabled = false;
											// this.tEdit_EndProduceFrameNo.Enabled = true; // DEL 2010/05/20
											//this._clearUpdateFlg = true; // ADD 2010/05/20 DEL 2010/05/25
											// ----- ADD 2010/05/16 -------------------<<<<<
											break;
										case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
											if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
											{
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
													e.NextCtrl = this.tNedit_ModelDesignationNo;
													this.tNedit_ModelDesignationNo.Clear();
													this.tNedit_CategoryNo.Clear();
												}
											}
											break;
										default:
											break;
									}
								}
							}
							else if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() == 0))
							{
								if (this._prevControl.Name != "tNedit_ModelDesignationNo")
								{
									DialogResult dialogResult = TMsgDisp.Show(
									   this,
									   emErrorLevel.ERR_LEVEL_EXCLAMATION,
									   this.Name,
									   "�^���w����͎��́A�ޕʋ敪�͕K�{���͂ł��B",
									   0,
									   MessageBoxButtons.OK,
									   MessageBoxDefaultButton.Button1);
									e.NextCtrl = this.tNedit_CategoryNo;
									this._prevControl = e.NextCtrl;
								}
							}
							else
							{
								prevCtrl = this.tNedit_ModelDesignationNo;
								break;
							}
							prevCtrl = this.tNedit_ModelDesignationNo;
							this._prevControl = prevCtrl;
						}
						else
						{
							if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() == 0))
							{
								if (this._prevControl.Name != "tNedit_ModelDesignationNo")
								{
									DialogResult dialogResult = TMsgDisp.Show(
									   this,
									   emErrorLevel.ERR_LEVEL_EXCLAMATION,
									   this.Name,
									   "�^���w����͎��́A�ޕʋ敪�͕K�{���͂ł��B",
									   0,
									   MessageBoxButtons.OK,
									   MessageBoxDefaultButton.Button1);
									e.NextCtrl = this.tNedit_CategoryNo;
									this._prevControl = e.NextCtrl;
								}
							}
						}
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
						if (this.tComboEditor_Model.SelectedIndex != 0)
						{
							if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim()))
							{
								this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();

								CarSearchCondition con = new CarSearchCondition();
								con.CarModel.FullModel = this.tEdit_FullModel.Text;
								con.Type = CarSearchType.csModel;
								con.FreeSearchModelOnly = true;

								int result = this.CarSearch(con);

								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										e.NextCtrl = e.PrevCtrl;
										this.tEdit_FullModel.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										nextCtrl = this.tDateEdit_StartEntryYearDate;
										e.NextCtrl = nextCtrl;
										this.tDateEdit_StartEntryYearDate.Focus();
										this._prevControl = this.tDateEdit_StartEntryYearDate;
										// ----- ADD 2010/05/16 ------------------->>>>>
										this.SettingButtonEnabled();
										this.tNedit_ModelDesignationNo.Enabled = false;
										this.tNedit_CategoryNo.Enabled = false;
										// this.tEdit_EndProduceFrameNo.Enabled = true;  // DEL 2010/05/20
										//this._clearUpdateFlg = true; // ADD 2010/05/20 DEL 2010/05/25
										// ----- ADD 2010/05/16 -------------------<<<<<
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
										{
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
												e.NextCtrl = this.tEdit_FullModel;
												this.tEdit_FullModel.Clear();
											}
										}
										break;
									default:
										break;
								}
							}
						}
						// ----- ADD 2010/05/16 ------------------->>>>>
						else if (this.tComboEditor_Model.SelectedIndex == 0)
						{
							if (nextCtrl.Name.Equals("tDateEdit_StartEntryYearDate") || e.Key == Keys.Right || e.Key == Keys.Down)
							{
								// �Ԏ�
								if (String.IsNullOrEmpty(this.tEdit_ModelFullName.Text) || un_INSERT.Equals(this.tEdit_ModelFullName.Text))
								{
									if (this.tNedit_MakerCode.GetInt() == 0
										&& this.tNedit_ModelCode.GetInt() == 0
										&& this.tNedit_ModelSubCode.GetInt() == 0)
									{
										DialogResult dialogResult = TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_EXCLAMATION,
											this.Name,
											"�Ԏ����͂��ĉ������B",
											0,
											MessageBoxButtons.OK,
											MessageBoxDefaultButton.Button1);
									}
									else
									{
										DialogResult dialogResult = TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_EXCLAMATION,
											this.Name,
											"�Ԏ킪���͕s���ł��B",
											0,
											MessageBoxButtons.OK,
											MessageBoxDefaultButton.Button1);
									}
									// �w��t�H�[�J�X�ݒ菈��
									this.tNedit_MakerCode.Focus();
									e.NextCtrl = this.tNedit_MakerCode;
									break;

								}
								// �^��
								if (String.IsNullOrEmpty(this.tEdit_FullModel.Text))
								{
									DialogResult dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"�^������͂��ĉ������B",
										0,
										MessageBoxButtons.OK,
										MessageBoxDefaultButton.Button1);

									// �w��t�H�[�J�X�ݒ菈��
									this.tEdit_FullModel.Focus();
									e.NextCtrl = this.tEdit_FullModel;
									break;

								}

								if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
								{
									bool errorFlag = false;
									char[] chs = this.tEdit_FullModel.Text.ToCharArray();
									foreach (char ch in chs)
									{
										if (!(this.IsNum(ch) || this.IsNumSign(ch) || this.IsAlpha(ch)))
										{
											DialogResult dialogResult = TMsgDisp.Show(
																	this,
																	emErrorLevel.ERR_LEVEL_EXCLAMATION,
																	this.Name,
																	"�p��������͂��ĉ������B",
																	0,
																	MessageBoxButtons.OK,
																	MessageBoxDefaultButton.Button1);
											// �w��t�H�[�J�X�ݒ菈��
											this.tEdit_FullModel.Focus();
											e.NextCtrl = this.tEdit_FullModel;
											errorFlag = true;
											break;
										}
									}

									if (errorFlag)
										break;
								}

								// �^���̔��f
								if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
								{
									string fullModel = this.tEdit_FullModel.Text;

									bool flag = false;
									flag = this.CheckModelName(fullModel);

									if (!flag)
									{
										this.tEdit_FullModel.Focus();
										e.NextCtrl = this.tEdit_FullModel;
										break;
									}
								}

								CarSearchCondition con = new CarSearchCondition();
								con.CarModel.FullModel = this.tEdit_FullModel.Text;
								con.Type = CarSearchType.csModel;
								// --- UPD m.suzuki 2010/06/22 ---------->>>>>
								//con.FreeSearchModelOnly = true;
								con.FreeSearchModelOnly = false;
								// --- UPD m.suzuki 2010/06/22 ----------<<<<<

								int result = this.CarSearchNew(con);
								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										e.NextCtrl = e.PrevCtrl;
										this.tEdit_FullModel.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										SettingButtonEnabled();
										nextCtrl = this.tDateEdit_StartEntryYearDate;
										e.NextCtrl = nextCtrl;
										this.tDateEdit_StartEntryYearDate.Focus();
										this._prevControl = this.tDateEdit_StartEntryYearDate;
										this._clearChangeFlg = true;
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
										{
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
												e.NextCtrl = this.tEdit_FullModel;
												this.tEdit_FullModel.Clear();
											}
										}
										break;
									default:
										break;
								}
							}
						}
						// ----- ADD 2010/05/16 -------------------<<<<<

						switch (e.Key)
						{
							case Keys.Down:
								e.NextCtrl = this.tDateEdit_StartEntryYearDate;
								break;
							case Keys.Up:
								e.NextCtrl = this.tNedit_MakerCode;
								break;
							default:
								break;
						}
						break;
					}
				#endregion

				#region �ԑ�ԍ�
				//�ԑ�ԍ�
				case "tEdit_StartProduceFrameNo":
					{
						switch (e.Key)
						{
							case Keys.Down:
								e.NextCtrl = this.ultraGrid_CarSpec;
								this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
								this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
								break;
							case Keys.Up:
								e.NextCtrl = this.tDateEdit_StartEntryYearDate;
								break;
							default:
								break;
						}
						break;
					}

				case "tEdit_EndProduceFrameNo":
					{
						switch (e.Key)
						{
							case Keys.Down:
								e.NextCtrl = this.ultraGrid_CarSpec;
								this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
								this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
								break;
							case Keys.Up:
								e.NextCtrl = this.tDateEdit_EndEntryMonthDate;
								break;
							default:
								break;
						}
						break;
					}
				#endregion
				// ----- ADD 2010/05/16 ------------------->>>>>
				//�N���I��(�N)
				case "tDateEdit_EndEntryYearDate":
					{
						if (e.NextCtrl != this.tDateEdit_EndEntryMonthDate)
						{
							if ((!string.IsNullOrEmpty(tDateEdit_StartEntryYearDate.Text)) && (!string.IsNullOrEmpty(tDateEdit_StartEntryMonthDate.Text))
								&& (string.IsNullOrEmpty(tDateEdit_EndEntryYearDate.Text)) && (string.IsNullOrEmpty(tDateEdit_EndEntryMonthDate.Text)))
							{
								this.tDateEdit_EndEntryYearDate.Text = this.tDateEdit_StartEntryYearDate.Text;
								this.tDateEdit_EndEntryMonthDate.Text = this.tDateEdit_StartEntryMonthDate.Text;
							}
						}
						break;
					}
				//�N���I��(��)
				case "tDateEdit_EndEntryMonthDate":
					{
						if (e.NextCtrl != this.tDateEdit_EndEntryYearDate)
						{
							if ((!string.IsNullOrEmpty(tDateEdit_StartEntryYearDate.Text)) && (!string.IsNullOrEmpty(tDateEdit_StartEntryMonthDate.Text))
								&& (string.IsNullOrEmpty(tDateEdit_EndEntryYearDate.Text)) && (string.IsNullOrEmpty(tDateEdit_EndEntryMonthDate.Text)))
							{
								this.tDateEdit_EndEntryYearDate.Text = this.tDateEdit_StartEntryYearDate.Text;
								this.tDateEdit_EndEntryMonthDate.Text = this.tDateEdit_StartEntryMonthDate.Text;
							}
						}
						break;
					}
				// ----- ADD 2010/05/16 -------------------<<<<<
			}

			//---------------------------------------------------------------
			// �{�^���c�[���L�������ݒ菈��
			//---------------------------------------------------------------
			if (e.NextCtrl != null && e.NextCtrl.Name != "_Form1_Toolbars_Dock_Area_Top")
			{
				this.SettingToolBarButtonEnabled();
			}

		}

		/// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			// ----- ADD 2010/05/16 ------------------->>>>>
			if (e.NextCtrl == tEdit_FullModel)
			{
				tDateEdit_StartEntryYearDate.Enabled = true;
				tDateEdit_StartEntryYearDate.Appearance.BackColor = Color.Gainsboro;
			}
			// ----- ADD 2010/05/16 -------------------<<<<<

			// Grid��Control�����鎞��Return/Tab�̓����ݒ�
			if (e.PrevCtrl != null)
			{
				if (e.PrevCtrl.Name == "ultraGrid_CarSpec")
				{
					// ���^�[���L�[�̎�
					if ((e.Key == Keys.Return) ||
						(e.Key == Keys.Tab))
					{
						e.NextCtrl = null;

						if (this.ultraGrid_CarSpec.ActiveCell != null)
						{
							// ----- UPD 2010/05/16 ------------------->>>>>
							if (!e.ShiftKey)
							{
								// �ŏI�Z���̎�
								if ((this.ultraGrid_CarSpec.ActiveCell.Row.Index == this.ultraGrid_CarSpec.Rows.Count - 1)
									  && (this.ultraGrid_CarSpec.ActiveCell.Column.Index == this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[PMJKN09001UB.COL_SHIFTNM_TITLE].Index))
								{
									if (e.Key == Keys.Tab)
									{
										// ���[�h�Ƀt�H�[�J�X�J��
										e.NextCtrl = this.tDateEdit_StartEntryYearDate;
									}

									if (e.Key == Keys.Return)
									{
										this.Save(); // �ۑ�����
									}
								}
								else
								{
									// ����Cell�Ƀt�H�[�J�X�J��
									this.ultraGrid_CarSpec.PerformAction(UltraGridAction.NextCell);
									this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
							else
							{
								// �ŏ��Z���̎�
								if ((this.ultraGrid_CarSpec.ActiveCell.Row.Index == 0)
									  && (this.ultraGrid_CarSpec.ActiveCell.Column.Index == this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Index))
								{
									if (e.Key == Keys.Tab)
									{
										if (this.tEdit_EndProduceFrameNo.Enabled == true)
										{
											// ���[�h�Ƀt�H�[�J�X�J��
											e.NextCtrl = this.tEdit_EndProduceFrameNo;
										}
										else
										{
											// ���[�h�Ƀt�H�[�J�X�J��
											e.NextCtrl = this.tEdit_StartProduceFrameNo;
										}
									}
								}
								else
								{
									// ����Cell�Ƀt�H�[�J�X�J��
									this.ultraGrid_CarSpec.PerformAction(UltraGridAction.PrevCell);
									this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
						}
						// ----- UPD 2010/05/16 -------------------<<<<<
					}
				}
				//�ԑ�ԍ�����O���b�h�֑J��
				else if (e.PrevCtrl.Name == "tEdit_EndProduceFrameNo")
				{
					if (e.NextCtrl.Name == "ultraGrid_CarSpec")
					{
						if (this.ultraGrid_CarSpec.Rows.Count != 0)
						{
							e.NextCtrl = null;
							switch (e.Key)
							{
								case Keys.Return:
									{
										this.ultraGrid_CarSpec.Focus();
										this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
										this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
										break;
									}
								case Keys.Tab:
									{
										this.ultraGrid_CarSpec.Focus();
										this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
										this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
										break;
									}
								case Keys.Up:
									{
										this.tEdit_StartProduceFrameNo.Focus();
										break;
									}
							}
						}
					}
				}
				else if (e.PrevCtrl.Name == "tEdit_EndProduceFrameNo")
				{
					//SHIFT+TAB�̏ꍇ
					if (e.NextCtrl == this.ultraGrid_CarSpec)
					{
						e.NextCtrl = null;
						this.ultraGrid_CarSpec.PerformAction(UltraGridAction.ActivateCell);
						this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
					}
				}
				else if (e.PrevCtrl.Name == "tNedit_CategoryNo")
				{
					int model = this.tComboEditor_Model.SelectedIndex;
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

						e.NextCtrl = this.tNedit_CategoryNo;
						this._prevControl = e.NextCtrl;
					}
					if (model == 1) // �X�V�ꍇ
					{
						if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() != 0))
						{
							if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
							{
								CarSearchCondition con = new CarSearchCondition();
								con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
								con.CategoryNo = this.tNedit_CategoryNo.GetInt();
								con.Type = CarSearchType.csCategory;
								con.FreeSearchModelOnly = true;

								int result = this.CarSearch(con);

								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										e.NextCtrl = this.tNedit_ModelDesignationNo;
										this._prevControl = e.NextCtrl;
										this.tNedit_ModelDesignationNo.Clear();
										this.tNedit_CategoryNo.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										this.tDateEdit_StartEntryYearDate.Focus();
										this._prevControl = this.tDateEdit_StartEntryYearDate;
										e.NextCtrl = this.tDateEdit_StartEntryYearDate;
										// ----- ADD 2010/05/16 ------------------->>>>>
										this.SettingButtonEnabled();
										this.tNedit_ModelDesignationNo.Enabled = false;
										this.tNedit_CategoryNo.Enabled = false;
										// this.tEdit_EndProduceFrameNo.Enabled = true; // DEL 2010/05/20
										//this._clearUpdateFlg = true; // ADD 2010/05/20 DEL 2010/05/25
										// ----- ADD 2010/05/16 -------------------<<<<<
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
										{
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
												e.NextCtrl = this.tNedit_ModelDesignationNo;
												this.tNedit_ModelDesignationNo.Clear();
												this.tNedit_CategoryNo.Clear();
											}
										}

										break;
									default:
										break;
								}
							}
						}
					}
				}
				else if (e.PrevCtrl.Name == "tEdit_FullModel")
				{

					// ----- ADD 2010/05/16 ------------------->>>>>
					//TAB�̏ꍇ
					if (e.NextCtrl != this.uButton_ModelFullGuide)
					{
						// ----- ADD 2010/05/16 -------------------<<<<<
						if (this.tComboEditor_Model.SelectedIndex != 0)
						{
							if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim()))
							{
								this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();

								CarSearchCondition con = new CarSearchCondition();
								con.CarModel.FullModel = this.tEdit_FullModel.Text;
								con.Type = CarSearchType.csModel;
								con.FreeSearchModelOnly = true;

								int result = this.CarSearch(con);

								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										e.NextCtrl = e.PrevCtrl;
										this.tEdit_FullModel.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										this.tDateEdit_StartEntryYearDate.Focus();
										e.NextCtrl = this.tDateEdit_StartEntryYearDate;
										// ----- ADD 2010/05/16 ------------------->>>>>
										this.SettingButtonEnabled();
										this.tNedit_ModelDesignationNo.Enabled = false;
										this.tNedit_CategoryNo.Enabled = false;
										// this.tEdit_EndProduceFrameNo.Enabled = true; // DEL 2010/05/20
										//this._clearUpdateFlg = true;  // ADD 2010/05/20
										// ----- ADD 2010/05/16 -------------------<<<<<
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
										{
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
												e.NextCtrl = this.tEdit_FullModel;
												this.tEdit_FullModel.Clear();
											}
										}
										break;
									default:
										break;
								}
							}
						}
						// ----- ADD 2010/05/16 ------------------->>>>>
						else if (this.tComboEditor_Model.SelectedIndex == 0) // �V�K�ꍇ
						{
							// �Ԏ�
							if (String.IsNullOrEmpty(this.tEdit_ModelFullName.Text) || un_INSERT.Equals(this.tEdit_ModelFullName.Text))
							{
								if (this.tNedit_MakerCode.GetInt() == 0
									&& this.tNedit_ModelCode.GetInt() == 0
									&& this.tNedit_ModelSubCode.GetInt() == 0)
								{
									DialogResult dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"�Ԏ����͂��ĉ������B",
										0,
										MessageBoxButtons.OK,
										MessageBoxDefaultButton.Button1);
								}
								else
								{
									DialogResult dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"�Ԏ킪���͕s���ł��B",
										0,
										MessageBoxButtons.OK,
										MessageBoxDefaultButton.Button1);
								}
								// �w��t�H�[�J�X�ݒ菈��
								this.tNedit_MakerCode.Focus();
								e.NextCtrl = this.tNedit_MakerCode;
								return;

							}
							// �^��
							if (String.IsNullOrEmpty(this.tEdit_FullModel.Text))
							{
								DialogResult dialogResult = TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									this.Name,
									"�^������͂��ĉ������B",
									0,
									MessageBoxButtons.OK,
									MessageBoxDefaultButton.Button1);

								// �w��t�H�[�J�X�ݒ菈��
								this.tEdit_FullModel.Focus();
								e.NextCtrl = this.tEdit_FullModel;
								return;

							}

							if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
							{
								bool errorFlag = false;
								char[] chs = this.tEdit_FullModel.Text.ToCharArray();
								foreach (char ch in chs)
								{
									if (!(this.IsNum(ch) || this.IsNumSign(ch) || this.IsAlpha(ch)))
									{
										DialogResult dialogResult = TMsgDisp.Show(
																this,
																emErrorLevel.ERR_LEVEL_EXCLAMATION,
																this.Name,
																"�p��������͂��ĉ������B",
																0,
																MessageBoxButtons.OK,
																MessageBoxDefaultButton.Button1);
										// �w��t�H�[�J�X�ݒ菈��
										this.tEdit_FullModel.Focus();
										e.NextCtrl = this.tEdit_FullModel;
										errorFlag = true;
										break;
									}
								}

								if (errorFlag)
									return;
							}

							// �^���̔��f
							if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
							{
								string fullModel = this.tEdit_FullModel.Text;

								bool flag = false;
								flag = this.CheckModelName(fullModel);

								if (!flag)
								{
									this.tEdit_FullModel.Focus();
									e.NextCtrl = this.tEdit_FullModel;
									return;
								}
							}

							CarSearchCondition con = new CarSearchCondition();
							con.CarModel.FullModel = this.tEdit_FullModel.Text;
							con.Type = CarSearchType.csModel;
							// --- UPD m.suzuki 2010/06/22 ---------->>>>>
							//con.FreeSearchModelOnly = true;
							con.FreeSearchModelOnly = false;
							// --- UPD m.suzuki 2010/06/22 ----------<<<<<

							int result = this.CarSearchNew(con);
							SettingButtonEnabled();
							e.NextCtrl = this.tDateEdit_StartEntryYearDate;
							this.tDateEdit_StartEntryYearDate.Focus();
							this._prevControl = this.tDateEdit_StartEntryYearDate;
							this._clearChangeFlg = true;
						}
					}
				}
				//�N���I��(�N)
				else if (e.PrevCtrl.Name == "tDateEdit_EndEntryYearDate")
				{
					if (e.NextCtrl == this.tDateEdit_StartEntryMonthDate)
					{
						if ((!string.IsNullOrEmpty(tDateEdit_StartEntryYearDate.Text)) && (!string.IsNullOrEmpty(tDateEdit_StartEntryMonthDate.Text))
							&& (string.IsNullOrEmpty(tDateEdit_EndEntryYearDate.Text)) && (string.IsNullOrEmpty(tDateEdit_EndEntryMonthDate.Text)))
						{
							this.tDateEdit_EndEntryYearDate.Text = this.tDateEdit_StartEntryYearDate.Text;
							this.tDateEdit_EndEntryMonthDate.Text = this.tDateEdit_StartEntryMonthDate.Text;
						}
					}
				}
				//�N���I��(��)
				else if (e.PrevCtrl.Name == "tDateEdit_EndEntryMonthDate")
				{
					if (e.NextCtrl == this.tEdit_StartProduceFrameNo)
					{
						if ((!string.IsNullOrEmpty(tDateEdit_StartEntryYearDate.Text)) && (!string.IsNullOrEmpty(tDateEdit_StartEntryMonthDate.Text))
							&& (string.IsNullOrEmpty(tDateEdit_EndEntryYearDate.Text)) && (string.IsNullOrEmpty(tDateEdit_EndEntryMonthDate.Text)))
						{
							this.tDateEdit_EndEntryYearDate.Text = this.tDateEdit_StartEntryYearDate.Text;
							this.tDateEdit_EndEntryMonthDate.Text = this.tDateEdit_StartEntryMonthDate.Text;
						}
					}
					// ----- ADD 2010/05/16 -------------------<<<<<
				}
				else if (e.PrevCtrl.Name == "tNedit_ModelDesignationNo")
				{
					// ���^�[���L�[�̎�
					if ((e.Key == Keys.Return) ||
						(e.Key == Keys.Tab))
					{
						// ----- UPD 2010/05/16 ------------------->>>>>
						if (!e.ShiftKey)
						{
							if (!String.IsNullOrEmpty(this.tNedit_ModelDesignationNo.Text))
							{
								e.NextCtrl = this.tNedit_CategoryNo;
								this.tNedit_CategoryNo.Enabled = true;
								this.tNedit_CategoryNo.Focus();
							}
						}
						else
						{
							e.NextCtrl = this.tComboEditor_Model;

						}
						// ----- UPD 2010/05/16 -------------------<<<<<

					}
				}
			}

			if (e.NextCtrl != null)
			{
				// [�Ԏ�ǉ�(A)]�{�^���͉����s��
				if (e.NextCtrl.Name == "tNedit_MakerCode"
					 || e.NextCtrl.Name == "tNedit_ModelCode"
								|| e.NextCtrl.Name == "tNedit_ModelSubCode")
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = true;
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
				}

				// �폜�{�^���͉�����
				if (this.tComboEditor_Model.SelectedIndex == 1)
				{
					if (!String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
					}
					else
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					}
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
				}

				// �ǉ��{�^���͉�����
				if (this.tComboEditor_Model.SelectedIndex == 1)
				{
					if (e.NextCtrl.TabIndex > 7 || e.NextCtrl.Name == "ultraGrid_CarSpec")
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = true;
					}
					else
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = false;
					}
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = false;
				}
			}
		}

		// ----- ADD 2010/05/16 ------------------->>>>>
		/// <summary>
		/// �{�^���L�������ݒ菈��
		/// </summary>
		private void InitialSettingButtonEnabled()
		{
			tComboEditor_Model.Enabled = true;
			tNedit_ModelDesignationNo.Enabled = true;
			tNedit_CategoryNo.Enabled = false;
			tNedit_MakerCode.Enabled = true;
			tNedit_ModelCode.Enabled = false;
			tNedit_ModelSubCode.Enabled = false;
			tEdit_FullModel.Enabled = true;
			uButton_ModelFullGuide.Enabled = true;

			tDateEdit_StartEntryYearDate.Enabled = false;
			tDateEdit_StartEntryMonthDate.Enabled = false;
			tDateEdit_EndEntryYearDate.Enabled = false;
			tDateEdit_EndEntryMonthDate.Enabled = false;
			tEdit_StartProduceFrameNo.Enabled = false;
			tEdit_EndProduceFrameNo.Enabled = false;
			ultraGrid_CarSpec.Enabled = false;
		}

		/// <summary>
		/// �{�^���L�������ݒ菈��
		/// </summary>
		private void SettingButtonEnabled()
		{

			// �X�V���[�h
			tComboEditor_Model.Enabled = false;
			tNedit_ModelDesignationNo.Enabled = false;
			tNedit_CategoryNo.Enabled = false;
			tNedit_MakerCode.Enabled = false;
			tNedit_ModelCode.Enabled = false;
			tNedit_ModelSubCode.Enabled = false;
			tEdit_FullModel.Enabled = false;
			uButton_ModelFullGuide.Enabled = false;

			tDateEdit_StartEntryYearDate.Enabled = true;
			tDateEdit_StartEntryMonthDate.Enabled = true;
			tDateEdit_EndEntryYearDate.Enabled = true;
			tDateEdit_EndEntryMonthDate.Enabled = true;
			tEdit_StartProduceFrameNo.Enabled = true;
			// ----- UPD 2010/05/20 ------------------->>>>>
			if ((!string.IsNullOrEmpty(tEdit_EndProduceFrameNo.Text)) ||
				(!string.IsNullOrEmpty(tEdit_StartProduceFrameNo.Text)))
			{
				tEdit_EndProduceFrameNo.Enabled = true;
			}
			else
			{
				tEdit_EndProduceFrameNo.Enabled = false;
			}
			// ----- UPD 2010/05/20 -------------------<<<<<
			ultraGrid_CarSpec.Enabled = true;
		}
		// ----- ADD 2010/05/16 -------------------<<<<<

		/// <summary>
		/// �c�[���o�[�{�^���L�������ݒ菈��
		/// </summary>
		private void SettingToolBarButtonEnabled()
		{
			int modelFlg = 0;
			modelFlg = this.tComboEditor_Model.SelectedIndex; // ��ʃ��[�h�̎擾

			if (modelFlg == 0) // �V�K�ꍇ  
			{
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;

				if (this._prevControl != null)
				{
					if (this._prevControl.TabStop == true)
					{
						if (this._prevControl.Name == "tNedit_MakerCode"
							|| this._prevControl.Name == "tNedit_ModelCode"
							|| this._prevControl.Name == "tNedit_ModelSubCode") // �J�[�\�����Ԏ�ɑ��ݎ��̂ݎ��s�\
						{
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = true;
						}
						else
						{
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
						}
					}
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
				}

				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = false;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_NewInfo"].SharedProps.Enabled = true;
			}
			else
			{
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;

				if (this._prevControl != null)
				{
					if (this._prevControl.TabStop == true)
					{
						if (this._prevControl.Name == "tNedit_MakerCode"
							|| this._prevControl.Name == "tNedit_ModelCode"
							|| this._prevControl.Name == "tNedit_ModelSubCode") // �J�[�\�����Ԏ�ɑ��ݎ��̂ݎ��s�\
						{
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = true;
						}
						else
						{
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
						}
					}
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
				}

				if (!String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
				}

				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = false;
				// �X�V���[�h�ŁA�J�[�\�����N���ȍ~�ɑ��ݎ��̂ݎ��s�\
				if (this._prevControl != null)
				{
					if (this._prevControl.TabIndex > 7 || this._prevControl.Name == "ultraGrid_CarSpec")
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = true;
					}
				}

				this.tToolbarsManager_MainMenu.Tools["ButtonTool_NewInfo"].SharedProps.Enabled = true;
			}
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

			this._freeSrchMdlFxdNo = String.Empty;
			this._updateTime = new DateTime();

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
				for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
				{
					PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];

					//�O���[�h
					if (!modelGradeNmList.Contains((string)carModelInfoRow["ModelGradeNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ModelGradeNm"]))
					{
						this._modelGradeValueList.ValueListItems.Add(i, (string)carModelInfoRow["ModelGradeNm"]);
						modelGradeNmList.Add((string)carModelInfoRow["ModelGradeNm"]);
					}
					//�{�f�B
					if (!bodyNameList.Contains((string)carModelInfoRow["BodyName"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["BodyName"]))
					{
						this._bodyNameValueList.ValueListItems.Add(i, (string)carModelInfoRow["BodyName"]);
						bodyNameList.Add((string)carModelInfoRow["BodyName"]);
					}
					//�h�A
					int doorCout = (int)carModelInfoRow["DoorCount"];
					if (!doorCoutList.Contains(doorCout.ToString())
						&& ((int)carModelInfoRow["DoorCount"] != 0))
					{
						this._doorCountValueList.ValueListItems.Add(i, doorCout.ToString());
						doorCoutList.Add(doorCout.ToString());
					}
					//�G���W��
					if (!engineModelList.Contains((string)carModelInfoRow["EngineModelNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineModelNm"]))
					{
						this._engineModelValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineModelNm"]);
						engineModelList.Add((string)carModelInfoRow["EngineModelNm"]);
					}
					//�r�C��
					if (!engineDisplaceList.Contains((string)carModelInfoRow["EngineDisplaceNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineDisplaceNm"]))
					{
						this._engineDisplaceValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineDisplaceNm"]);
						engineDisplaceList.Add((string)carModelInfoRow["EngineDisplaceNm"]);
					}
					//E�敪
					if (!eDivList.Contains((string)carModelInfoRow["EDivNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EDivNm"]))
					{
						this._eDivValueList.ValueListItems.Add(i, (string)carModelInfoRow["EDivNm"]);
						eDivList.Add((string)carModelInfoRow["EDivNm"]);
					}
					//�~�b�V����
					if (!transmissionList.Contains((string)carModelInfoRow["TransmissionNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["TransmissionNm"]))
					{
						this._transmissionValueList.ValueListItems.Add(i, (string)carModelInfoRow["TransmissionNm"]);
						transmissionList.Add((string)carModelInfoRow["TransmissionNm"]);
					}
					//�쓮�`��
					if (!wheelDriveMethodList.Contains((string)carModelInfoRow["WheelDriveMethodNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["WheelDriveMethodNm"]))
					{
						this._wheelDriveMethodValueList.ValueListItems.Add(i, (string)carModelInfoRow["WheelDriveMethodNm"]);
						wheelDriveMethodList.Add((string)carModelInfoRow["WheelDriveMethodNm"]);
					}
					//�V�t�g
					if (!shiftList.Contains((string)carModelInfoRow["ShiftNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ShiftNm"]))
					{
						this._shiftValueList.ValueListItems.Add(i, (string)carModelInfoRow["ShiftNm"]);
						shiftList.Add((string)carModelInfoRow["ShiftNm"]);
					}
				}
				// �^���O���b�h�\���ݒ菈��
				this.SettingCarSpecGrid();
				for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
				{
					PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];
					if ((bool)carModelInfoRow["SelectionState"] == true)
					{
						// ���R�����^���Œ�ԍ�
						this._freeSrchMdlFxdNo = (string)carModelInfoRow["FreeSrchMdlFxdNo"];
						this.tNedit_MakerCode.SetInt((int)carModelInfoRow["MakerCode"]);
						this.tNedit_ModelCode.SetInt((int)carModelInfoRow["ModelCode"]);
						this.tNedit_ModelSubCode.SetInt((int)carModelInfoRow["ModelSubCode"]);

						// �X�V�����̎擾
						ArrayList retList = new ArrayList();
						FreeSearchModel freeSearchModel = new FreeSearchModel();
						freeSearchModel.EnterpriseCode = this._enterpriseCode;
						freeSearchModel.FreeSrchMdlFxdNo = this._freeSrchMdlFxdNo;

						int status = this._freeSearchModelAcs.Search(out retList, freeSearchModel);
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							FreeSearchModel freeSearchModel1 = (FreeSearchModel)retList[0];
							this._updateTime = freeSearchModel1.UpdateDateTime;
							// �ޕ�
							this.tNedit_ModelDesignationNo.SetInt(freeSearchModel1.ModelDesignationNo);
							this.tNedit_CategoryNo.SetInt(freeSearchModel1.CategoryNo);
						}

						this.tEdit_ModelFullName.Text = (string)carModelInfoRow["ModelFullName"];
						//�^��
						this.tEdit_FullModel.Text = (string)carModelInfoRow["FullModel"];

						// �Ԏ�ƌ^���͓��͕s��
						this.tNedit_MakerCode.Enabled = false;
						this.tNedit_ModelCode.Enabled = false;
						this.tNedit_ModelSubCode.Enabled = false;
						this.uButton_ModelFullGuide.Enabled = false;
						this.tEdit_FullModel.Enabled = false;

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
						PMJKN09001UB.DataSetColumnConstruction(ref this._carSpecDataSet);
						DataRow row = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].NewRow();
						//�������
						//�O���[�h
						if (!String.IsNullOrEmpty((string)carModelInfoRow["ModelGradeNm"]))
						{
							row[PMJKN09001UB.COL_MODELGRADENM_TITLE] = i;
						}
						//�{�f�B
						if (!String.IsNullOrEmpty((string)carModelInfoRow["BodyName"]))
						{
							row[PMJKN09001UB.COL_BODYNAME_TITLE] = i;
						}
						//�h�A
						if ((int)carModelInfoRow["DoorCount"] != 0)
						{
							row[PMJKN09001UB.COL_DOORCOUNT_TITLE] = i;
						}
						//�G���W��
						if (!String.IsNullOrEmpty((string)carModelInfoRow["EngineModelNm"]))
						{
							row[PMJKN09001UB.COL_ENGINEMODELNM_TITLE] = i;
						}
						//�r�C��
						if (!String.IsNullOrEmpty((string)carModelInfoRow["EngineDisplaceNm"]))
						{
							row[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE] = i;
						}
						//E�敪
						if (!String.IsNullOrEmpty((string)carModelInfoRow["EDivNm"]))
						{
							row[PMJKN09001UB.COL_EDIVNM_TITLE] = i;
						}
						//�~�b�V����
						if (!String.IsNullOrEmpty((string)carModelInfoRow["TransmissionNm"]))
						{
							row[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE] = i;
						}
						//�쓮�`��
						if (!String.IsNullOrEmpty((string)carModelInfoRow["WheelDriveMethodNm"]))
						{
							row[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE] = i;
						}
						//�V�t�g
						if (!String.IsNullOrEmpty((string)carModelInfoRow["ShiftNm"]))
						{
							row[PMJKN09001UB.COL_SHIFTNM_TITLE] = i;
						}

						this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].Rows.Add(row);
						this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].DefaultView;
						break;
					}
				}
			}
		}

		// ----- ADD 2010/05/16 ------------------->>>>>
		/// <summary>
		/// �ԗ���������
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		private int CarSearchNew(CarSearchCondition condition)
		{
			//------------------------------------------------------
			// ��������
			//------------------------------------------------------
			int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			this._freeSrchMdlFxdNo = String.Empty;
			this._updateTime = new DateTime();

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

			if ((ret == CarSearchResultReport.retSingleCarModel) || (ret == CarSearchResultReport.retMultipleCarModel))
			{
				SetCarInfoNew(dat);

				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			// --- ADD m.suzuki 2010/06/22 ---------->>>>>
			else if (ret == CarSearchResultReport.retMultipleCarKind)
			{
				MultipleCarSearch(carSearchController, condition, dat);
			}
			// --- ADD m.suzuki 2010/06/22 ----------<<<<<

			return retStatus;
		}

		// --- ADD m.suzuki 2010/06/22 ---------->>>>>
		/// <summary>
		/// �����Ԏ�Y�����̏������W�J
		/// </summary>
		/// <param name="condition"></param>
		private void MultipleCarSearch(CarSearchController carSearchController, CarSearchCondition condition, PMKEN01010E dat)
		{
			CarSearchResultReport ret = new CarSearchResultReport();

			// �d���`�F�b�N�p���X�g������(��ڰ�ށ`��Ă�9��)
			ArrayList itemLists = new ArrayList();
			for (int i = 0; i < 9; i++)
			{
				itemLists.Add(new ArrayList());
			}

			// ������
			this.ClearValueList();

			// �Y���̎Ԏ핪�J��Ԃ�
			foreach (PMKEN01010E.CarKindInfoRow row in dat.CarKindInfo)
			{
				PMKEN01010E retDat = new PMKEN01010E();

				condition.MakerCode = row.MakerCode;
				condition.ModelCode = row.ModelCode;
				condition.ModelSubCode = row.ModelSubCode;

				ret = carSearchController.Search(condition, ref retDat);
				SetCarInfoAppend(retDat, ref itemLists);
			}
		}
		/// <summary>
		/// �������W�J�����i�ǉ��^�j
		/// </summary>
		/// <param name="dat"></param>
		/// <param name="itemLists"></param>
		private void SetCarInfoAppend(PMKEN01010E dat, ref ArrayList itemLists)
		{
			//�Ԏ�^�����
			_carModelInfoDataTable = dat.CarModelInfo;

			if (_carModelInfoDataTable != null && _carModelInfoDataTable.Rows.Count > 0)
			{
				//�O���[�h
				ArrayList modelGradeNmList = (ArrayList)itemLists[0];
				//�{�f�B
				ArrayList bodyNameList = (ArrayList)itemLists[1];
				//�h�A
				ArrayList doorCoutList = (ArrayList)itemLists[2];
				//�G���W��
				ArrayList engineModelList = (ArrayList)itemLists[3];
				//�r�C��
				ArrayList engineDisplaceList = (ArrayList)itemLists[4];
				//E�敪
				ArrayList eDivList = (ArrayList)itemLists[5];
				//�~�b�V����
				ArrayList transmissionList = (ArrayList)itemLists[6];
				//�쓮�`��
				ArrayList wheelDriveMethodList = (ArrayList)itemLists[7];
				//�V�t�g
				ArrayList shiftList = (ArrayList)itemLists[8];
				for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
				{
					PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];

					//�O���[�h
					if (!modelGradeNmList.Contains((string)carModelInfoRow["ModelGradeNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ModelGradeNm"]))
					{
						this._modelGradeValueList.ValueListItems.Add(i, (string)carModelInfoRow["ModelGradeNm"]);
						modelGradeNmList.Add((string)carModelInfoRow["ModelGradeNm"]);
					}
					//�{�f�B
					if (!bodyNameList.Contains((string)carModelInfoRow["BodyName"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["BodyName"]))
					{
						this._bodyNameValueList.ValueListItems.Add(i, (string)carModelInfoRow["BodyName"]);
						bodyNameList.Add((string)carModelInfoRow["BodyName"]);
					}
					//�h�A
					int doorCout = (int)carModelInfoRow["DoorCount"];
					if (!doorCoutList.Contains(doorCout.ToString())
						&& ((int)carModelInfoRow["DoorCount"] != 0))
					{
						this._doorCountValueList.ValueListItems.Add(i, doorCout.ToString());
						doorCoutList.Add(doorCout.ToString());
					}
					//�G���W��
					if (!engineModelList.Contains((string)carModelInfoRow["EngineModelNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineModelNm"]))
					{
						this._engineModelValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineModelNm"]);
						engineModelList.Add((string)carModelInfoRow["EngineModelNm"]);
					}
					//�r�C��
					if (!engineDisplaceList.Contains((string)carModelInfoRow["EngineDisplaceNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineDisplaceNm"]))
					{
						this._engineDisplaceValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineDisplaceNm"]);
						engineDisplaceList.Add((string)carModelInfoRow["EngineDisplaceNm"]);
					}
					//E�敪
					if (!eDivList.Contains((string)carModelInfoRow["EDivNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EDivNm"]))
					{
						this._eDivValueList.ValueListItems.Add(i, (string)carModelInfoRow["EDivNm"]);
						eDivList.Add((string)carModelInfoRow["EDivNm"]);
					}
					//�~�b�V����
					if (!transmissionList.Contains((string)carModelInfoRow["TransmissionNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["TransmissionNm"]))
					{
						this._transmissionValueList.ValueListItems.Add(i, (string)carModelInfoRow["TransmissionNm"]);
						transmissionList.Add((string)carModelInfoRow["TransmissionNm"]);
					}
					//�쓮�`��
					if (!wheelDriveMethodList.Contains((string)carModelInfoRow["WheelDriveMethodNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["WheelDriveMethodNm"]))
					{
						this._wheelDriveMethodValueList.ValueListItems.Add(i, (string)carModelInfoRow["WheelDriveMethodNm"]);
						wheelDriveMethodList.Add((string)carModelInfoRow["WheelDriveMethodNm"]);
					}
					//�V�t�g
					if (!shiftList.Contains((string)carModelInfoRow["ShiftNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ShiftNm"]))
					{
						this._shiftValueList.ValueListItems.Add(i, (string)carModelInfoRow["ShiftNm"]);
						shiftList.Add((string)carModelInfoRow["ShiftNm"]);
					}
				}
				// �^���O���b�h�\���ݒ菈��
				this.SettingCarSpecGrid();
			}
		}
		// --- ADD m.suzuki 2010/06/22 ----------<<<<<

		/// <summary>
		/// �ԗ����L���b�V���i�ԗ�������񂩂�L���b�V���j
		/// </summary>
		/// <param name="dat">�Ԏ�^�����</param>
		private void SetCarInfoNew(PMKEN01010E dat)
		{
			//�Ԏ�^�����
			_carModelInfoDataTable = dat.CarModelInfo;

			this.ClearValueList();

			if (_carModelInfoDataTable != null && _carModelInfoDataTable.Rows.Count > 0)
			{
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
				for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
				{
					PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];

					//�O���[�h
					if (!modelGradeNmList.Contains((string)carModelInfoRow["ModelGradeNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ModelGradeNm"]))
					{
						this._modelGradeValueList.ValueListItems.Add(i, (string)carModelInfoRow["ModelGradeNm"]);
						modelGradeNmList.Add((string)carModelInfoRow["ModelGradeNm"]);
					}
					//�{�f�B
					if (!bodyNameList.Contains((string)carModelInfoRow["BodyName"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["BodyName"]))
					{
						this._bodyNameValueList.ValueListItems.Add(i, (string)carModelInfoRow["BodyName"]);
						bodyNameList.Add((string)carModelInfoRow["BodyName"]);
					}
					//�h�A
					int doorCout = (int)carModelInfoRow["DoorCount"];
					if (!doorCoutList.Contains(doorCout.ToString())
						&& ((int)carModelInfoRow["DoorCount"] != 0))
					{
						this._doorCountValueList.ValueListItems.Add(i, doorCout.ToString());
						doorCoutList.Add(doorCout.ToString());
					}
					//�G���W��
					if (!engineModelList.Contains((string)carModelInfoRow["EngineModelNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineModelNm"]))
					{
						this._engineModelValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineModelNm"]);
						engineModelList.Add((string)carModelInfoRow["EngineModelNm"]);
					}
					//�r�C��
					if (!engineDisplaceList.Contains((string)carModelInfoRow["EngineDisplaceNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineDisplaceNm"]))
					{
						this._engineDisplaceValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineDisplaceNm"]);
						engineDisplaceList.Add((string)carModelInfoRow["EngineDisplaceNm"]);
					}
					//E�敪
					if (!eDivList.Contains((string)carModelInfoRow["EDivNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EDivNm"]))
					{
						this._eDivValueList.ValueListItems.Add(i, (string)carModelInfoRow["EDivNm"]);
						eDivList.Add((string)carModelInfoRow["EDivNm"]);
					}
					//�~�b�V����
					if (!transmissionList.Contains((string)carModelInfoRow["TransmissionNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["TransmissionNm"]))
					{
						this._transmissionValueList.ValueListItems.Add(i, (string)carModelInfoRow["TransmissionNm"]);
						transmissionList.Add((string)carModelInfoRow["TransmissionNm"]);
					}
					//�쓮�`��
					if (!wheelDriveMethodList.Contains((string)carModelInfoRow["WheelDriveMethodNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["WheelDriveMethodNm"]))
					{
						this._wheelDriveMethodValueList.ValueListItems.Add(i, (string)carModelInfoRow["WheelDriveMethodNm"]);
						wheelDriveMethodList.Add((string)carModelInfoRow["WheelDriveMethodNm"]);
					}
					//�V�t�g
					if (!shiftList.Contains((string)carModelInfoRow["ShiftNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ShiftNm"]))
					{
						this._shiftValueList.ValueListItems.Add(i, (string)carModelInfoRow["ShiftNm"]);
						shiftList.Add((string)carModelInfoRow["ShiftNm"]);
					}
				}
				// �^���O���b�h�\���ݒ菈��
				this.SettingCarSpecGrid();
			}
		}
		// ----- ADD 2010/05/16 -------------------<<<<<

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

		/// <summary>
		/// �c�[���o�[�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
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
						this.Save();
						break;
					}
				#endregion

				#region �Ԏ�ǉ�����
				//--------------------------------------------------
				// �Ԏ�ǉ�����
				//--------------------------------------------------
				case "ButtonTool_ModelAdd":
					{
						this.ModelAdd();
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

				#region �폜����
				//--------------------------------------------------
				// �폜����
				//--------------------------------------------------
				case "ButtonTool_Delete":
					{
						this.Delete();
						break;
					}
				#endregion

				#region �ǉ�����
				//--------------------------------------------------
				// �ǉ�����
				//--------------------------------------------------
				case "ButtonTool_Add":
					{
						this.Add();
						break;
					}
				#endregion

				#region �ŐV��񏈗�
				//--------------------------------------------------
				// �ŐV��񏈗�
				//--------------------------------------------------
				case "ButtonTool_NewInfo":
					{
						this.Renewal();
						break;
					}
				#endregion
			}

			this.SettingToolBarButtonEnabled();
		}

		/// <summary>
		/// �I������
		/// </summary>
		/// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
		private void Close(bool isConfirm)
		{
			if ((isConfirm) && (this.CheckChangedData()))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
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
			// ----- ADD 2010/05/16 ------------------->>>>>
			else
			{
				this.Close();
			}
			// ----- ADD 2010/05/16 -------------------<<<<<
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		private int Save()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			#region �ۑ��`�F�b�N
			//---------------------------------------------------------------
			// �ۑ��f�[�^�`�F�b�N����
			//---------------------------------------------------------------
			bool check = this.CheckSaveData();

			#endregion

			if (check)
			{
				int model = this.tComboEditor_Model.SelectedIndex;

				FreeSearchModel freeSearchModel = new FreeSearchModel();
				this.DispToFreeSearchModel(ref freeSearchModel, model);

				status = this._freeSearchModelAcs.Write(ref freeSearchModel);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // �ۑ��������ꍇ
				{
					// ���͉�ʂ�V�K���[�h�̏������������s��
					this.Clear(false);

					// ----- ADD 2010/05/16 ------------------->>>>>
					// �ޕ�
					this.tNedit_ModelDesignationNo.Clear();
					this.tNedit_CategoryNo.Clear();

					// �Ԏ�i��Ұ�����ޥ�Ԏ��ޥ�Ԏ�ď̺��ށj
					this.tNedit_MakerCode.Clear();
					this.tNedit_ModelCode.Clear();
					this.tNedit_ModelSubCode.Clear();

					// �^��
					this.tEdit_FullModel.Clear();
					// ----- ADD 2010/05/16 -------------------<<<<<

					this.tComboEditor_Model.SelectedIndex = 0; // �V�K
					this.tComboEditor_Model.Focus();

					// �{�^���c�[���L�������ݒ菈��
					this.SettingToolBarButtonEnabled();

					// ----- ADD 2010/05/16 ------------------->>>>>
					// �o�^�����_�C�A���O�\��
					SaveCompletionDialog dialog = new SaveCompletionDialog();
					dialog.ShowDialog(2);
					// ----- ADD 2010/05/16 -------------------<<<<<
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"�ۑ��Ɏ��s���܂����B",
						status,
						MessageBoxButtons.OK);
				}
			}

			return status;
		}

		/// <summary>
		/// ��ʏ�񎩗R�����^���}�X�^ �N���X�i�[����
		/// </summary>
		/// <param name="freeSearchModel">���R�����^���}�X�^ �I�u�W�F�N�g</param>
		/// <param name="model">���[�h</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂玩�R�����^���}�X�^ �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : �я���</br>
		/// <br>Date       : 2010.04.26</br>
		/// </remarks>
		private void DispToFreeSearchModel(ref FreeSearchModel freeSearchModel, int model)
		{
			freeSearchModel.LogicalDeleteCode = 0;

			freeSearchModel.EnterpriseCode = this._enterpriseCode;

			string freeSrchMdlFxdNo = string.Empty;
			if (model == 0)
			{
				freeSrchMdlFxdNo = Guid.NewGuid().ToString().Replace("-", "");
			}
			else
			{
				freeSrchMdlFxdNo = this._freeSrchMdlFxdNo;
				freeSearchModel.UpdateDateTime = this._updateTime;
			}
			freeSearchModel.FreeSrchMdlFxdNo = freeSrchMdlFxdNo; // ���R�����^���Œ�ԍ�

			freeSearchModel.MakerCode = this.tNedit_MakerCode.GetInt(); //���[�J�[�R�[�h
			freeSearchModel.ModelCode = this.tNedit_ModelCode.GetInt(); // �Ԏ�R�[�h
			freeSearchModel.ModelSubCode = this.tNedit_ModelSubCode.GetInt(); // �Ԏ�T�u�R�[�h

			freeSearchModel.FullModel = this.tEdit_FullModel.Text.ToUpper(); // �^���i�t���^�j

			freeSearchModel.ExhaustGasSign = this._exhaustGasSign;
			freeSearchModel.SeriesModel = this._seriesModel;
			freeSearchModel.CategorySignModel = this._categorySignModel;

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
			string modelGradeNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Text.ToString();
			freeSearchModel.ModelGradeNm = modelGradeNm;

			// �{�f�B�[����
			string bodyName = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_BODYNAME_TITLE].Text.ToString();
			freeSearchModel.BodyName = bodyName;

			// �h�A��
			string doorCount = (string)this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_DOORCOUNT_TITLE].Text.ToString();
			freeSearchModel.DoorCount = String.IsNullOrEmpty(doorCount) ? 0 : Convert.ToInt32(doorCount);

			// �G���W���^������
			string engineModelNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].Text.ToString();
			freeSearchModel.EngineModelNm = engineModelNm;

			// �r�C�ʖ���
			string engineDisplaceNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].Text.ToString();
			freeSearchModel.EngineDisplaceNm = engineDisplaceNm;

			// E�敪����
			string eDivNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_EDIVNM_TITLE].Text.ToString();
			freeSearchModel.EDivNm = eDivNm;

			// �~�b�V��������
			string transmissionNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].Text.ToString();
			freeSearchModel.TransmissionNm = transmissionNm;

			// �쓮��������
			string wheelDriveMethodNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].Text.ToString();
			freeSearchModel.WheelDriveMethodNm = wheelDriveMethodNm;

			// �V�t�g����
			string shiftNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_SHIFTNM_TITLE].Text.ToString();
			freeSearchModel.ShiftNm = shiftNm;

			if (model == 0)
			{
				// �쐬���t
				int createDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.Now);
				freeSearchModel.CreateDate = createDate;

				// �X�V�N����
				freeSearchModel.UpdateDate = createDate;
			}
			else
			{
				// �X�V���t
				int updateDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.Now);

				// �X�V�N����
				freeSearchModel.UpdateDate = updateDate;
			}
		}

		#region [�^���i�t���^�j�̔��f]
		/// <summary>
		/// �^���i�t���^�j�̔��f����
		/// </summary>
		/// <param name="fullModels">�^������</param>
		/// <param name="modelName">�^���i�t���^�j</param>
		/// <returns>��������</returns>
		/// <remarks>
		/// <br>Programmer : �я���</br>
		/// <br>Date       : 2010/04/30</br>
		/// </remarks>
		private bool CheckModelName(string modelName)
		{
			string msg = string.Empty;

			if (string.IsNullOrEmpty(modelName))
			{
				msg = "�^������͂��ĉ������B";
				// ���b�Z�[�W��\��
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
				return false;
			}

			//�^���i�t���^�j
			string[] fullModels = modelName.Split('-');

			string zrModel = string.Empty;
			string frModel = string.Empty;
			string sdModel = string.Empty;

			//�擪�̗v�f���S���ȏ�̂��߁A��P�v�f�����݂��Ȃ�
			if (fullModels[0].Length >= 4)
			{
				frModel = fullModels[0]; // �^���P�ɂ���
				for (int i = 1; i < fullModels.Length; i++)
				{
					sdModel += fullModels[i];
					if (i != fullModels.Length - 1)
					{
						sdModel += "-";
					}
				} // �^���Q
			}
			else
			{
				zrModel = fullModels[0]; // �^���O
				if (fullModels.Length > 1)
				{
					frModel = fullModels[1]; // �^���P
					for (int i = 2; i < fullModels.Length; i++)
					{
						sdModel += fullModels[i];
						if (i != fullModels.Length - 1)
						{
							sdModel += "-";
						}
					} // �^���Q
				}
			}

			if (zrModel.Length >= 5)
			{
				msg = "�^���O���S�����ȉ��ɂ��ĉ������B";
				// ���b�Z�[�W��\��
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
				return false;
			}
			if (frModel.Length >= 16)
			{
				msg = "�^���P���P�T�����ȉ��ɂ��ĉ������B";
				// ���b�Z�[�W��\��
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
				return false;
			}
			if (sdModel.Length >= 16)
			{
				msg = "�^���Q���P�T�����ȉ��ɂ��ĉ������B";
				// ���b�Z�[�W��\��
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
				return false;
			}

			// �����������ʁA�^���Q��0���̏ꍇ
			if (String.IsNullOrEmpty(sdModel))
			{
				// �^���P�̌�����0���̏ꍇ�́A�^���O���^���P�Ƃ���
				if (String.IsNullOrEmpty(frModel))
				{
					frModel = zrModel;
					zrModel = string.Empty;
				}
				// �^���O�����݂��A�^���P�������Ŏn�܂�ꍇ�́A�^���O���^���P�A�^���P���^���Q�Ƃ���
				if (!String.IsNullOrEmpty(zrModel)
					&& (!String.IsNullOrEmpty(frModel) && frModel.ToCharArray()[0] <= '9' && frModel.ToCharArray()[0] >= '0'))
				{
					sdModel = frModel;
					frModel = zrModel;
					zrModel = string.Empty;
				}
			}

			this._exhaustGasSign = zrModel;
			this._seriesModel = frModel;
			this._categorySignModel = sdModel;

			return true;
		}
		#endregion

		/// <summary>
		/// �ۑ��f�[�^�`�F�b�N����
		/// </summary>
		/// <returns></returns>
		private bool CheckSaveData()
		{
			bool flg = true;

			#region ��ʓ��͒l�`�F�b�N
			// �ޕ�(�^���w��)
			if (!String.IsNullOrEmpty(this.tNedit_ModelDesignationNo.Text))
			{
				char[] chs = this.tNedit_ModelDesignationNo.Text.ToCharArray();
				foreach (char ch in chs)
				{
					if (!this.IsNum(ch))
					{
						DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"���l����͂��ĉ������B",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);

						this.tNedit_ModelDesignationNo.Focus();
						this._prevControl = this.tNedit_ModelDesignationNo;
						return false;
					}
				}
			}

			// �ޕ�(�ޕʋ敪) 
			if (!String.IsNullOrEmpty(this.tNedit_CategoryNo.Text))
			{
				char[] chs = this.tNedit_CategoryNo.Text.ToCharArray();
				foreach (char ch in chs)
				{
					if (!this.IsNum(ch))
					{
						DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"���l����͂��ĉ������B",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);

						this.tNedit_CategoryNo.Focus();
						this._prevControl = this.tNedit_CategoryNo;
						return false;
					}
				}
			}

			// �Ԏ�
			if (String.IsNullOrEmpty(this.tEdit_ModelFullName.Text) || un_INSERT.Equals(this.tEdit_ModelFullName.Text))
			{
				if (this.tNedit_MakerCode.GetInt() == 0
					&& this.tNedit_ModelCode.GetInt() == 0
					&& this.tNedit_ModelSubCode.GetInt() == 0)
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"�Ԏ����͂��ĉ������B",
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
				}
				else
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"�Ԏ킪���͕s���ł��B",
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
				}

				// �w��t�H�[�J�X�ݒ菈��
				this.tNedit_MakerCode.Focus();
				this._prevControl = this.tNedit_MakerCode;
				return false;
			}

			// �^��
			if (String.IsNullOrEmpty(this.tEdit_FullModel.Text))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�^������͂��ĉ������B",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// �w��t�H�[�J�X�ݒ菈��
				this.tEdit_FullModel.Focus();
				this._prevControl = this.tEdit_FullModel;

				return false;
			}

			if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
			{
				char[] chs = this.tEdit_FullModel.Text.ToCharArray();
				foreach (char ch in chs)
				{
					if (!(this.IsNum(ch) || this.IsNumSign(ch) || this.IsAlpha(ch)))
					{
						DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"�p��������͂��ĉ������B",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);
						// �w��t�H�[�J�X�ݒ菈��
						this.tEdit_FullModel.Focus();
						this._prevControl = this.tEdit_FullModel;

						return false;
					}
				}
			}

			// �^���̔��f
			if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
			{
				string fullModel = this.tEdit_FullModel.Text;

				bool flag = false;
				flag = this.CheckModelName(fullModel);

				if (!flag)
				{
					this.tEdit_FullModel.Focus();
					this._prevControl = this.tEdit_FullModel;
					return false;
				}
			}
			// ----- UPD 2010/05/16 ------------------->>>>>
			string stYM = this.tDateEdit_StartEntryYearDate.Text + "." + this.tDateEdit_StartEntryMonthDate.Text;
			// �J�n�N��
			if ((!String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text) && String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text)) ||
				(String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text) && !String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text)) ||
				("0001.01".Equals(stYM)) || ("0001.1".Equals(stYM)) || ("1.01".Equals(stYM)))
			// ----- UPD 2010/05/16 -------------------<<<<<
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�J�n�N�������͕s���ł��B",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// �w��t�H�[�J�X�ݒ菈��
				this.tDateEdit_StartEntryYearDate.Focus();
				this._prevControl = this.tDateEdit_StartEntryYearDate;

				return false;
			}

			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text)
				&& this.tDateEdit_StartEntryMonthDate.Text.CompareTo("12") > 0)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�J�n�N�������͕s���ł��B",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// �w��t�H�[�J�X�ݒ菈��
				this.tDateEdit_StartEntryMonthDate.Focus();
				this._prevControl = this.tDateEdit_StartEntryMonthDate;

				return false;
			}
			// ----- UPD 2010/05/16 ------------------->>>>>
			string endYM = this.tDateEdit_EndEntryYearDate.Text + "." + this.tDateEdit_EndEntryMonthDate.Text;

			// �I���N��
			if ((!String.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text) && String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text)) ||
				(String.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text) && !String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text)) ||
				("0001.01".Equals(endYM)) || ("0001.1".Equals(endYM)) || ("1.01".Equals(endYM)))
			// ----- UPD 2010/05/16 -------------------<<<<<
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�I���N�������͕s���ł��B",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// �w��t�H�[�J�X�ݒ菈��
				this.tDateEdit_EndEntryYearDate.Focus();
				this._prevControl = this.tDateEdit_EndEntryYearDate;

				return false;
			}

			if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text)
				&& this.tDateEdit_EndEntryMonthDate.Text.CompareTo("12") > 0)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�I���N�������͕s���ł��B",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// �w��t�H�[�J�X�ݒ菈��
				this.tDateEdit_EndEntryMonthDate.Focus();
				this._prevControl = this.tDateEdit_EndEntryMonthDate;

				return false;
			}


			string stDate = string.Empty;
			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text))
			{
				stDate = this.tDateEdit_StartEntryYearDate.Text;
			}
			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text))
			{
				stDate += this.tDateEdit_StartEntryMonthDate.Text;
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
			if (!string.IsNullOrEmpty(edDate) && !string.IsNullOrEmpty(stDate))
			{
				// �J�n���t���I�����t�ƂȂ���t������
				if (stDate.CompareTo(edDate) > 0)
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"�J�n���t�ȏ�̓��t����͂��ĉ������B",
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);

					// �w��t�H�[�J�X�ݒ菈��
					this.tDateEdit_EndEntryYearDate.Focus();
					this._prevControl = this.tDateEdit_EndEntryYearDate;
					return false;
				}
			}

			// ���Y�ԑ�ԍ�
			int stProduceFrameNo = 0;
			if (!string.IsNullOrEmpty(this.tEdit_StartProduceFrameNo.Text))
			{
				stProduceFrameNo = Convert.ToInt32(this.tEdit_StartProduceFrameNo.Text); // ���Y�ԑ�ԍ��J�n
			}

			// int edProduceFrameNo = 0; // DEL 2010/05/20
			int edProduceFrameNo = 99999999; // ADD 2010/05/20
			if (!string.IsNullOrEmpty(this.tEdit_EndProduceFrameNo.Text))
			{
				edProduceFrameNo = Convert.ToInt32(this.tEdit_EndProduceFrameNo.Text); //���Y�ԑ�ԍ��I��
			}
			if (stProduceFrameNo > edProduceFrameNo)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�J�n�ԍ��ȏ�̔ԍ�����͂��ĉ������B",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// �w��t�H�[�J�X�ݒ菈��
				this.tEdit_EndProduceFrameNo.Focus();

				this._prevControl = this.tEdit_EndProduceFrameNo;

				return false;
			}

			// �h�A
			string dorCnt = this.ultraGrid_CarSpec.Rows[0].Cells[2].Text.ToString();

			if (!String.IsNullOrEmpty(dorCnt))
			{
				char[] chars = dorCnt.ToCharArray();
				foreach (char ch in chars)
				{
					if (ch.CompareTo('0') < 0 || ch.CompareTo('9') > 0)
					{
						DialogResult dialogResult = TMsgDisp.Show(
							 this,
							 emErrorLevel.ERR_LEVEL_EXCLAMATION,
							 this.Name,
							 "��������͂��ĉ������B",
							 0,
							 MessageBoxButtons.OK,
							 MessageBoxDefaultButton.Button1);

						this.ultraGrid_CarSpec.Focus();
						this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_DOORCOUNT_TITLE].Activate();
						this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);

						return false;
					}
				}
			}
			#endregion

			return flg;
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

			if (this.ultraGrid_CarSpec.Rows.Count > 1 && !this.ultraGrid_CarSpec.Rows[1].IsEmptyRow)
			{
				return true;
			}
			#endregion

			return flg;
		}

		/// <summary>
		/// �ۑ��m�F�_�C�A���O�\������
		/// </summary>
		/// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
		/// <returns>�m�F��OK �m�F��NG</returns>
		private bool ShowSaveCheckDialog(bool isConfirm)
		{
			bool checkedValue = false;

			if ((isConfirm) && (this.CheckChangedData()))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
					"�o�^���Ă���낵���ł����H",
					0,
					MessageBoxButtons.YesNoCancel,
					MessageBoxDefaultButton.Button1);

				if (dialogResult == DialogResult.Yes)
				{
					this.Save();
				}
				else if (dialogResult == DialogResult.No)
				{
					// ���͉�ʂ�V�K���[�h�̏������������s��
					this.Clear(false);

					// ----- UPD 2010/05/16 ------------------->>>>>
					//�@��ʒl�Đݒ�t���O
					this._valueChageFlg = true;
					this.tComboEditor_Model.SelectedIndex = 0; // �V�K
					this.tComboEditor_Model.Focus();
					//�@��ʒl�Đݒ�t���O
					this._valueChageFlg = false;
					if (this._clearChangeFlg == true)
					{
						// ----- UPD 2010/05/20 ------------------->>>>>
						if (!string.IsNullOrEmpty(tNedit_ModelCode.Text))
						{
							this.tNedit_ModelCode.Enabled = true;
							this.tNedit_ModelSubCode.Enabled = true;
						}
						else
						{
							this.tNedit_ModelCode.Enabled = true;
						}
						// ----- UPD 2010/05/20 -------------------<<<<<
						//this.tEdit_FullModel.Focus(); // DEL 2010/06/22
					}
					this._clearChangeFlg = false;
					// ----- ADD 2010/05/20 ------------------->>>>>
					if (this._clearUpdateFlg == true)
					{
						this.tComboEditor_Model.SelectedIndex = 1;//�X�V
					}
					this._clearUpdateFlg = false;
					// ----- ADD 2010/05/20 -------------------<<<<<
					// ----- UPD 2010/05/16 -------------------<<<<<

					// �{�^���c�[���L�������ݒ菈��
					this.SettingToolBarButtonEnabled();
				}
				else
				{
					return false;
				}
			}
			else
			{
				checkedValue = true;
			}

			return checkedValue;
		}

		/// <summary>
		/// �N���A����
		/// </summary>
		/// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
		/// <remarks>
		/// <br>Note        : �N���A���N���b�N���ɔ������܂��B</br>      
		/// <br>Programmer  : �я���</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void Clear(bool isConfirm)
		{
			bool canClear = this.ShowSaveCheckDialog(isConfirm);
			if (canClear)
			{
				// ----- UPD 2010/05/16 ------------------->>>>>
				//if ((this.tEdit_FullModel.Enabled == true) || (this.tComboEditor_Model.SelectedIndex == 1)) // DEL 2010/06/22
				//{ // DEL 2010/06/22
				// �ޕ�
				this.tNedit_ModelDesignationNo.Clear();
				this.tNedit_CategoryNo.Clear();

				// �Ԏ�i��Ұ�����ޥ�Ԏ��ޥ�Ԏ�ď̺��ށj
				this.tNedit_MakerCode.Clear();
				this.tNedit_ModelCode.Clear();
				this.tNedit_ModelSubCode.Clear();

				// �^��
				this.tEdit_FullModel.Clear();
				//} // DEL 2010/06/22
				// ----- UPD 2010/05/16 -------------------<<<<<
				if (this.tComboEditor_Model.SelectedIndex == 1)
				{
					this._clearUpdateFlg = true;
				}

				// ���Y�N��
				this.tDateEdit_StartEntryYearDate.Clear();
				this.tDateEdit_StartEntryMonthDate.Clear();
				this.tDateEdit_EndEntryYearDate.Clear();
				this.tDateEdit_EndEntryMonthDate.Clear();

				// �ԑ�ԍ�
				this.tEdit_StartProduceFrameNo.Clear();
				this.tEdit_EndProduceFrameNo.Clear();

				this._carSpecDataSet.Clear();
				this.ClearValueList();

				PMJKN09001UB.DataSetColumnConstruction(ref this._carSpecDataSet);
				DataRow row = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].NewRow();
				this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].Rows.Add(row);
				this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].DefaultView;
				// �^���O���b�h�\���ݒ菈��
				this.SettingCarSpecGrid();

				this._updateTime = new DateTime();
				this._freeSrchMdlFxdNo = string.Empty;

				this.SettingToolBarButtonEnabled();
				// ----- ADD 2010/05/16 ------------------->>>>>
				// �{�^���L�������ݒ菈��
				this.InitialSettingButtonEnabled();
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
				this.tComboEditor_Model.Focus();
				// ----- ADD 2010/05/16 -------------------<<<<<
			}
		}

		/// <summary>
		/// �Ԏ�ǉ�����
		/// </summary>
		/// <remarks>
		/// <br>Note        : �Ԏ�ǉ����N���b�N���ɔ������܂��B</br>      
		/// <br>Programmer  : �я���</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void ModelAdd()
		{
			// ���[�J�[�A�Ԏ�R�[�h�A�ď̃R�[�h
			string maker = this.tNedit_MakerCode.Text;
			string modelCode = this.tNedit_ModelCode.Text;
			string modelSubCode = this.tNedit_ModelSubCode.Text;

			// flg(true:���̉�ʂ���Afalse:���g)
			bool flg = true;
			PMKHN09030UA pMKHN09030UA = new PMKHN09030UA(maker, modelCode, modelSubCode, flg);
			pMKHN09030UA.Show();
		}

		/// <summary>
		/// �폜����
		/// </summary>
		/// <remarks>
		/// <br>Note        : �폜���N���b�N���ɔ������܂��B</br>      
		/// <br>Programmer  : �я���</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void Delete()
		{
			if (true)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"�f�[�^�𕨗��폜���܂��B" + "\r\n" + "\r\n" +
					"��낵���ł����H",
					0,
					MessageBoxButtons.OKCancel,
					MessageBoxDefaultButton.Button2);

				if (dialogResult == DialogResult.OK)
				{
					int isDelete = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

					FreeSearchModel freeSearchModel = new FreeSearchModel();

					if (!String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
					{
						freeSearchModel.FreeSrchMdlFxdNo = this._freeSrchMdlFxdNo;
						freeSearchModel.UpdateDateTime = this._updateTime;
					}
					else
					{

					}

					freeSearchModel.EnterpriseCode = this._enterpriseCode;

					isDelete = this._freeSearchModelAcs.Delete(freeSearchModel);
					// �A�N�Z�X�N���X�̕����폜����
					if (isDelete == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						//���͉�ʂ�V�K���[�h�̏������������s��
						// �N���A����
						this.Clear(false);
						this.tComboEditor_Model.SelectedIndex = 0;
						this.tComboEditor_Model.Focus();
					}
				}
				else if (dialogResult == DialogResult.Cancel)
				{
					this._prevControl = this.tDateEdit_StartEntryYearDate;//ADD 2010/05/16
					return;
				}
			}

		}

		/// <summary>
		/// �ǉ�����
		/// </summary>
		/// <remarks>
		/// <br>Note        : �ǉ����N���b�N���ɔ������܂��B</br>      
		/// <br>Programmer  : �я���</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void Add()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			#region �ۑ��`�F�b�N
			//---------------------------------------------------------------
			// �ۑ��f�[�^�`�F�b�N����
			//---------------------------------------------------------------
			bool check = this.CheckSaveData();

			if (check)
			{
				if (check)
				{
					int model = 0; // �ǉ�(�V�K)

					FreeSearchModel freeSearchModel = new FreeSearchModel();
					this.DispToFreeSearchModel(ref freeSearchModel, model);

					status = this._freeSearchModelAcs.Write(ref freeSearchModel);

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // �ۑ��������ꍇ
					{
						// ���͉�ʂ�V�K���[�h�̏������������s��
						this.Clear(false);

						this.tComboEditor_Model.SelectedIndex = 0; // �V�K
						this.tComboEditor_Model.Focus();

						// �{�^���c�[���L�������ݒ菈��
						this.SettingToolBarButtonEnabled();

						// ----- ADD 2010/05/16 ------------------->>>>>
						// �o�^�����_�C�A���O�\��
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
						// ----- ADD 2010/05/16 -------------------<<<<<
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"�ۑ��Ɏ��s���܂����B",
							status,
							MessageBoxButtons.OK);
					}
				}

			}
			#endregion
		}

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
			// ���[�J�[�}�X�^
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

			string msg = "�ŐV�����擾���܂����B";
			// ���b�Z�[�W��\��
			this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, msg, 0);
		}
		# endregion

		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note        : �G���[���b�Z�[�W�\������</br>
		/// <br>Programmer  : �я���</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks>
		private void MsgDispProc(emErrorLevel iLevel, string message, int status)
		{
			TMsgDisp.Show(
				iLevel,        // �G���[���x��
				"PMJKN09000UA",      // �A�Z���u���h�c�܂��̓N���X�h�c
				ct_PRINTNAME,            // �v���O��������
				"",         // ��������
				"",         // �I�y���[�V����
				message,       // �\�����郁�b�Z�[�W
				status,        // �X�e�[�^�X�l
				null,         // �G���[�����������I�u�W�F�N�g
				MessageBoxButtons.OK,     // �\������{�^��
				MessageBoxDefaultButton.Button1); // �����\���{�^��
		}

		/// <summary>
		/// ���[�h�h���b�v�_�E���ύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tComboEditor_Model_ValueChanged(object sender, EventArgs e)
		{
			// ----- ADD 2010/05/16 ------------------->>>>>
			// ��ʒl�Đݒ�����s���ł������f
			if (true == _valueChageFlg)
				return;
			// ----- ADD 2010/05/16 -------------------<<<<<

			bool isChanged = false;

			isChanged = this.CheckChangedData();

			if (isChanged)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
					"�o�^���Ă��悢�ł����H",
					0,
					MessageBoxButtons.YesNoCancel);

				if (dialogResult == DialogResult.Yes)
				{
					// �ۑ�����
					this.CheckSaveData();

					FreeSearchModel freeSearchModel = new FreeSearchModel();
					this.DispToFreeSearchModel(ref freeSearchModel, 1 - this.tComboEditor_Model.SelectedIndex);

					int status = this._freeSearchModelAcs.Write(ref freeSearchModel);

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // �ۑ��������ꍇ
					{
						// ���͉�ʂ�V�K���[�h�̏������������s��
						this.Clear(false);

						this.tComboEditor_Model.SelectedIndex = 0; // �V�K
						this.tComboEditor_Model.Focus();

						// �{�^���c�[���L�������ݒ菈��
						this.SettingToolBarButtonEnabled();
						// ----- ADD 2010/05/16 ------------------->>>>>
						// �{�^���L�������ݒ菈��
						this.InitialSettingButtonEnabled();
						// �o�^�����_�C�A���O�\��
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
						// ----- ADD 2010/05/16 -------------------<<<<<
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"�ۑ��Ɏ��s���܂����B",
							status,
							MessageBoxButtons.OK);
					}
				}
				else if (dialogResult == DialogResult.No)
				{
					// �ۑ������͍s�킸�A���͉�ʂ�V�K���[�h�̏������������s��
					this.Clear(false);

					this.tComboEditor_Model.Focus();

					// �{�^���c�[���L�������ݒ菈��
					this.SettingToolBarButtonEnabled();
					// ----- ADD 2010/05/16 ------------------->>>>>
					// �{�^���L�������ݒ菈��
					this.InitialSettingButtonEnabled();
					// ----- ADD 2010/05/16 -------------------<<<<<
				}
				else
				{
					this.tComboEditor_Model.ValueChanged -= new EventHandler(tComboEditor_Model_ValueChanged);
					if (this.tComboEditor_Model.SelectedIndex == 0)
					{
						this.tComboEditor_Model.SelectedIndex = 1;
					}
					else
					{
						this.tComboEditor_Model.SelectedIndex = 0;
					}
					this.tComboEditor_Model.ValueChanged += new EventHandler(tComboEditor_Model_ValueChanged);

					// �ۑ������͍s�킸�A�f�[�^���͉�ʂɖ߂�
					return;
				}
			}

			if (this.tComboEditor_Model.SelectedIndex == 0)
			{
				this.Mode_Label.Text = "�V�K���[�h";
			}
			else
			{
				this.Mode_Label.Text = "�X�V���[�h";
			}
			this.SettingToolBarButtonEnabled();
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

		// ----- ADD 2010/05/16 ------------------->>>>>
		/// <summary>
		/// tEdit_StartProduceFrameNo_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_StartProduceFrameNo_ValueChanged(object sender, EventArgs e)
		{
			string produceFrameNo = this.tEdit_StartProduceFrameNo.Text;
			if (string.IsNullOrEmpty(produceFrameNo))
			{
				this.tEdit_EndProduceFrameNo.Enabled = false;
			}
			else
			{
				this.tEdit_EndProduceFrameNo.Enabled = true;
			}
		}
		// ----- ADD 2010/05/16 -------------------<<<<<

		// ----- ADD 2010/06/22 ------------------->>>>>
		/// <summary>
		/// tEdit_EndProduceFrameNo_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_EndProduceFrameNo_ValueChanged(object sender, EventArgs e)
		{
			string endProduceFrameNo = this.tEdit_EndProduceFrameNo.Text;
			if (string.IsNullOrEmpty(endProduceFrameNo))
			{
				this.tEdit_EndProduceFrameNo.Enabled = false;
			}
			else
			{
				this.tEdit_EndProduceFrameNo.Enabled = true;
			}
		}

		/// <summary>
		/// tDateEdit_StartEntryYearDate_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDateEdit_StartEntryYearDate_ValueChanged(object sender, EventArgs e)
		{
			if (("0001".Equals(tDateEdit_StartEntryYearDate.Text)) && ("01".Equals(tDateEdit_StartEntryMonthDate.Text)))
			{
				tDateEdit_StartEntryYearDate.Clear();
				tDateEdit_StartEntryMonthDate.Clear();
			}
		}

		/// <summary>
		/// tDateEdit_StartEntryMonthDate_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDateEdit_StartEntryMonthDate_ValueChanged(object sender, EventArgs e)
		{
			if (("0001".Equals(tDateEdit_StartEntryYearDate.Text)) && ("01".Equals(tDateEdit_StartEntryMonthDate.Text)))
			{
				tDateEdit_StartEntryYearDate.Clear();
				tDateEdit_StartEntryMonthDate.Clear();
			}
		}

		/// <summary>
		/// tDateEdit_EndEntryYearDate_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDateEdit_EndEntryYearDate_ValueChanged(object sender, EventArgs e)
		{
			if (("0001".Equals(tDateEdit_EndEntryYearDate.Text)) && ("01".Equals(tDateEdit_EndEntryMonthDate.Text)))
			{
				tDateEdit_EndEntryYearDate.Clear();
				tDateEdit_EndEntryMonthDate.Clear();
			}
		}

		/// <summary>
		/// tDateEdit_EndEntryMonthDate_ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDateEdit_EndEntryMonthDate_ValueChanged(object sender, EventArgs e)
		{
			if (("0001".Equals(tDateEdit_EndEntryYearDate.Text)) && ("01".Equals(tDateEdit_EndEntryMonthDate.Text)))
			{
				tDateEdit_EndEntryYearDate.Clear();
				tDateEdit_EndEntryMonthDate.Clear();
			}
		}
		// ----- ADD 2010/06/22 -------------------<<<<<

		/// <summary>
		/// tNedit_ModelSubCode_AfterExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_ModelSubCode_AfterExitEditMode(object sender, EventArgs e)
		{
			//��Ұ�����
			string makerCode = this.tNedit_MakerCode.Text;
			//�Ԏ��
			string modelCode = this.tNedit_ModelCode.Text;
			//�Ԏ�ď̺��
			string modelSubCode = this.tNedit_ModelSubCode.Text;
			// ----- ADD 2010/05/16 ------------------->>>>>
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;
			// ----- ADD 2010/05/16 -------------------<<<<<
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
			ModelNameU modelNameU;
			if (!string.IsNullOrEmpty(makerCode))
			{

				// ----- UPD 2010/05/16 ------------------->>>>>
				if ((this.tNedit_MakerCode.GetInt() != 0) && (this.tNedit_ModelCode.GetInt() == 0))
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
						this.tEdit_ModelFullName.Text = un_INSERT;
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
						this.tEdit_ModelFullName.Text = un_INSERT;
					}
				}
				// ----- UPD 2010/05/16 -------------------<<<<<
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

			// ----- ADD 2010/05/16 ------------------->>>>>
			if (tEdit_FullModel.Enabled == true)
			{
				this.tDateEdit_StartEntryYearDate.Enabled = false;
			}
			this.tDateEdit_StartEntryYearDate.Appearance.BackColor = Color.White;
			// ----- ADD 2010/05/16 -------------------<<<<<
		}

		/// <summary>
		/// ultraGrid_CarSpec_KeyDown�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid_CarSpec_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Right)
			{
				// ----- ADD 2010/06/22 ------------------->>>>>
				if (this.ultraGrid_CarSpec.ActiveCell.IsInEditMode)
				{
					if (this.ultraGrid_CarSpec.ActiveCell.SelStart >= this.ultraGrid_CarSpec.ActiveCell.Text.Length)
					{
						// ----- ADD 2010/06/22 -------------------<<<<<
						// �ŏI�Z���̎�
						if ((this.ultraGrid_CarSpec.ActiveCell.Row.Index == this.ultraGrid_CarSpec.Rows.Count - 1)
							  && (this.ultraGrid_CarSpec.ActiveCell.Column.Index == this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[PMJKN09001UB.COL_SHIFTNM_TITLE].Index))
						{
							this.ultraGrid_CarSpec.Focus();
							this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
						}
						else
						{
							// ����Cell�Ƀt�H�[�J�X�J��
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.NextCell);
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
						}
					}
					// ----- ADD 2010/06/22 ------------------->>>>>
				}
			}
			// ----- ADD 2010/06/22 -------------------<<<<<

			if (e.KeyCode == Keys.Left)
			{
				// ----- ADD 2010/06/22 ------------------->>>>>
				if (this.ultraGrid_CarSpec.ActiveCell.IsInEditMode)
				{
					if (this.ultraGrid_CarSpec.ActiveCell.SelStart <= 0)
					{
						// ----- ADD 2010/06/22 -------------------<<<<<
						// ���Z���̎�
						if ((this.ultraGrid_CarSpec.ActiveCell.Row.Index == 0)
							  && (this.ultraGrid_CarSpec.ActiveCell.Column.Index == this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Index))
						{
							this.ultraGrid_CarSpec.Focus();
							this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_SHIFTNM_TITLE].Activate();
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
						}
						else
						{
							// ����Cell�Ƀt�H�[�J�X�J��
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.PrevCell);
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
						}
					}
					// ----- ADD 2010/06/22 ------------------->>>>>
				}
			}
			// ----- ADD 2010/06/22 -------------------<<<<<
			if (e.KeyCode == Keys.Up)
			{
				// this.tEdit_EndProduceFrameNo.Focus(); // DEL 2010/06/22
				this.tEdit_StartProduceFrameNo.Focus();  // ADD 2010/06/22
				e.Handled = true; // ADD 2010/06/22
			}
			// ----- UPD 2010/06/22 ------------------->>>>>
			// ----- DEL 2010/06/22 ------------------->>>>>
			if (e.KeyCode == Keys.Down)
			{
				e.Handled = true; // ADD 2010/06/22
			}
			if (e.KeyCode == Keys.F2)
			{
				if (this.ultraGrid_CarSpec.ActiveCell.IsInEditMode)
				{
					this.ultraGrid_CarSpec.ActiveCell.SelStart = this.ultraGrid_CarSpec.ActiveCell.Text.Length;
				}
			}
			// ----- DEL 2010/06/22 -------------------<<<<<
			// ----- UPD 2010/06/22 -------------------<<<<<
		}

		#region �`�F�b�N���\�b�h
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="key">����</param>
		/// <param name="arChk">����OK�����z��</param>
		/// <returns>bool(true=OK,false=NG)</returns>
		/// <remarks>
		/// <br>Note       : ��������</br>
		/// <br>Programmer : zhshh</br>
		/// <br>Date       : 2010.03.17</br>
		/// </remarks>
		private bool IsCharCheck(char key, char[] arChk)
		{
			if (arChk != null)
			{
				for (int widx = 0; widx < arChk.Length; widx++)
				{
					if (arChk[widx] == key) return true;
				}
			}
			return false;
		}

		/// <summary>
		/// ���l�L������
		/// </summary>
		/// <param name="key">����</param>
		/// <returns>bool(true=���l�L��,false=���l�L���ȊO)</returns>
		/// <remarks>
		/// <br>Note       : ���l�L������</br>
		/// <br>Programmer : xiaoxd</br>
		/// <br>Date       : 2010.03.23</br>
		/// </remarks>
		private bool IsNumSign(char key)
		{
			char[] arnumsign = { '-' };
			return IsCharCheck(key, arnumsign);
		}

		/// <summary>
		/// ���䕶������
		/// </summary>
		/// <param name="key">����</param>
		/// <returns>bool(true=���䕶��,false=���䕶���ȊO)</returns>
		/// <remarks>
		/// <br>Note       : ���䕶������</br>
		/// <br>Programmer : xiaoxd</br>
		/// <br>Date       : 2010.03.23</br>
		/// </remarks>
		private bool IsCtrl(char key)
		{
			return Char.IsControl(key);
		}


		// ADD 2010.03.23 xiaoxd for Redmine#4072>>>>>>
		/// <summary>
		/// �p������
		/// </summary>
		/// <param name="key">����</param>
		/// <returns>bool(true=�p��,false=�p���ȊO)</returns>
		/// <remarks>
		/// <br>Note       : �p������</br>
		/// <br>Programmer : xiaoxd</br>
		/// <br>Date       : 2010.03.23</br>
		/// </remarks>
		private bool IsAlpha(char key)
		{
			char[] arAlpha = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
								'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
								'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
								'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
			return IsCharCheck(key, arAlpha);
		}

		/// <summary>
		/// ���l����
		/// </summary>
		/// <param name="key">����</param>
		/// <returns>bool(true=���l,false=���l�ȊO)</returns>
		/// <remarks>
		/// <br>Note       : ���l����</br>
		/// <br>Programmer : xiaoxd</br>
		/// <br>Date       : 2010.03.23</br>
		/// </remarks>
		private bool IsNum(char key)
		{
			char[] arnum = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
			return IsCharCheck(key, arnum);
		}
		#endregion

		// ----- ADD 2010/06/22 ------------------->>>>>
		private void ultraGrid_CarSpec_Layout(object sender, LayoutEventArgs e)
		{
			for (int index = 0; index < this.ultraGrid_CarSpec.KeyActionMappings.Count; index++)
			{
				GridKeyActionMapping keyActionMap = this.ultraGrid_CarSpec.KeyActionMappings[index];
				if (keyActionMap != null && keyActionMap.KeyCode == Keys.F2)
				{
					this.ultraGrid_CarSpec.KeyActionMappings.Remove(index);
				}
			}
		}
		// ----- ADD 2010/06/22 -------------------<<<<<

	}
}