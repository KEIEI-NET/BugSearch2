using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;



namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �������i�I���t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����̏��i����I�����s���ׂ̂t�h�N���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.1.18</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2008.06.18 20056 ���n ���</br>
    /// <br>           : PM.NS�Ή�(�R�����g����)</br>
    /// </remarks>
	public partial class MAKHN04110UB : Form
	{
		
		//================================================================================
		//  �R���X�g���N�^
		//================================================================================
		#region Constructor
		
		/// <summary>
		/// �������i�I���t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �������i�I���t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.18</br>
		/// </remarks>
		public MAKHN04110UB()
		{
			InitializeComponent();

			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
		}

		#endregion

		//================================================================================
		//  �萔��`
		//================================================================================
		#region Constant

		// -------------------------------------------------------------------------------
		#region < �O���b�h��p >
		
		/// <summary>���o���ʁE���ɓ��̓e�[�u��</summary>
		private const string CT_SELECT_TBL = "SelectTable";

		/// <summary>�I��</summary>
		public const string CT_Select = "Select";
		/// <summary>���[�J�[�R�[�h</summary>
		public const string CT_MakerCode = "MakerCode";
		/// <summary>���[�J�[��</summary>
		public const string CT_MakerName = "MakerName";
		/// <summary>���i�R�[�h</summary>
		public const string CT_GoodsCode = "GoodsNo";
		/// <summary>���i����</summary>
		public const string CT_GoodsName = "GoodsName";
		/// <summary>���i�A���f�[�^�N���X�i�[</summary>
		public const string CT_GoodsUitData = "GoodsUitData";

		#endregion

		// -------------------------------------------------------------------------------
		#region < �c�[���o�[�L�[��� >
		// �c�[���o�[�L�[���    
		private const string CT_TOOLBAR_DECISION_KEY = "Decision_ButtonTool";
		private const string CT_TOOLBAR_BACK_KEY = "Back_ButtonTool";
		private const string CT_TOOLBAR_ALLSELECT_KEY = "AllSelect_ButtonTool";
		#endregion

		#endregion

		//================================================================================
		//  ���������o�[
		//================================================================================
		#region Private Members

		/// <summary>�N���J�E���^�[</summary>
		private int _initialCount = 0;

		/// <summary>�������i�I��p�f�[�^�e�[�u��</summary>
		private DataTable _selDataTable;

		/// <summary>�������i�I��p�f�[�^�r���[</summary>
		private DataView _selDataView;

		/// <summary>�\������f�[�^���X�g</summary>
		private List<GoodsUnitData> _dspDataLst;

		/// <summary>�I���f�[�^���X�g</summary>
		private List<GoodsUnitData> _selDataLst;

		/// <summary>�f�t�H���g�s�̊O�ϐݒ�</summary>
		Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

		/// <summary>�I�����̍s�O�ϐݒ�</summary>
		private readonly Color _selBackColor = Color.FromArgb(251, 230, 148);
		private readonly Color _selBackColor2 = Color.FromArgb(238, 149, 21);
		private readonly Infragistics.Win.GradientStyle _selBackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

		/// <summary>�����I��</summary>
		private bool _isMultiSelect = false;

		/// <summary>��ʃf�U�C���ύX�N���X</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
		#endregion

		//================================================================================
		//  �O���v���p�e�B
		//================================================================================
		#region Public Methods
		/// <summary>�����I���t���O</summary>
		public bool IsMultiSelect
		{
			set { this._isMultiSelect = value; }
		}
		#endregion

		//================================================================================
		//  �O���񋟊֐�
		//================================================================================
		#region Public Methods

		/// <summary>
		/// �������i�I���K�C�h�N��
		/// </summary>
		/// <param name="owner">�I�[�i�[�t�H�[��</param>
		/// <param name="goodsUnitDataLst">���i�A���f�[�^���X�g</param>
		/// <returns>DialogResult</returns>
		public DialogResult SelectGoodsGuideShow(IWin32Window owner, ref List<GoodsUnitData> goodsUnitDataLst)
		{
			// �\���p�̃f�[�^���X�g���쐬����
			this._dspDataLst = new List<GoodsUnitData>(goodsUnitDataLst);
			this._selDataLst = new List<GoodsUnitData>();

			DialogResult dr = base.ShowDialog(owner);

			goodsUnitDataLst = new List<GoodsUnitData>(this._selDataLst);

			return dr;
		}

		#endregion


		//================================================================================
		//  �����֐�
		//================================================================================
		#region Private Methods

		/// <summary>
		/// �c�[���o�[�����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		private void InitializeToolbarsSetting()
		{
			// �C���[�W���X�g�ݒ�
			this.Main_UToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

			// �m��{�^���̃A�C�R���ݒ�
			ButtonTool decButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_DECISION_KEY] as ButtonTool;
			if (decButton != null)
			{
				decButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			}

			// �S�I���{�^���̃A�C�R���ݒ�
			ButtonTool allSelButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_ALLSELECT_KEY] as ButtonTool;
			if (allSelButton != null)
			{
				allSelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
				allSelButton.SharedProps.Visible = this._isMultiSelect;
			}
		
			// �߂�{�^���̃A�C�R���ݒ�
			ButtonTool backButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_BACK_KEY] as ButtonTool;
			if (backButton != null)
			{
				backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			}
		}

		/// <summary>
		/// �I��p�f�[�^�e�[�u���쐬
		/// </summary>
		/// <remarks>
		/// <br>Note       : DataTable�̐ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.18</br>
		/// </remarks>
		private void CreatSelectDadaTable()
		{
			// ----------------------------------------

			// DataTable�̍쐬
			this._selDataTable = new DataTable(CT_SELECT_TBL);
			this._selDataView = new DataView();

			// ----------------------------------------
			// DataColumn�̍쐬

			// �I��
			DataColumn Select = new DataColumn(CT_Select, typeof(Boolean), "", MappingType.Element);
			Select.Caption = "�I��";

			// ���[�J�[��
			DataColumn MakerName = new DataColumn(CT_MakerName, typeof(string), "", MappingType.Element);
			MakerName.Caption = "���[�J�[";

			// ���i�R�[�h
			DataColumn GoodsCode = new DataColumn(CT_GoodsCode, typeof(string), "", MappingType.Element);
			GoodsCode.Caption = "�i��";

			// ���i����
			DataColumn GoodsName = new DataColumn(CT_GoodsName, typeof(string), "", MappingType.Element);
			GoodsName.Caption = "�i��";

			// ���i�A���f�[�^�N���X�i�[
			DataColumn GoodsUitData = new DataColumn(CT_GoodsUitData, typeof(GoodsUnitData), "", MappingType.Element);
			GoodsUitData.Caption = "���i�A���f�[�^�N���X�i�[";


			// ----------------------------------------
			// DataTable�̏�����
			this._selDataTable.Columns.AddRange(new DataColumn[] {
				Select,
				MakerName,
				GoodsCode,
				GoodsName,
				GoodsUitData});

			this._selDataView.Table = this._selDataTable;

		}

		/// <summary>
		/// �I��p�O���b�h�J�������ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �I��p�O���b�h�ɕ\������J��������ݒ肵�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.18</br>
		/// </remarks>
		private void SettingSelGridColumn()
		{
			// �o���h���擾
			Infragistics.Win.UltraWinGrid.UltraGridBand band = this.SELECTGrid.DisplayLayout.Bands[0];
			Infragistics.Win.UltraWinGrid.ColumnsCollection columns = band.Columns;

			//---------------------------------------------------------------------
			//�@�J�����\���E��\��
			//---------------------------------------------------------------------
			columns[CT_Select].Hidden = !this._isMultiSelect;
			columns[CT_GoodsUitData].Hidden = true;

			//---------------------------------------------------------------------
			//�@�w�b�_�[�L���v�V����
			//---------------------------------------------------------------------

			//---------------------------------------------------------------------
			//�@�A�N�e�B�u������
			//---------------------------------------------------------------------
			columns[CT_Select].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			columns[CT_MakerName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_GoodsCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_GoodsName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

			//---------------------------------------------------------------------
			//�@�Z���N���b�N�A�N�V����
			//---------------------------------------------------------------------
			//columns[CT_Select].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			//columns[CT_MakerName].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			//columns[CT_GoodsCode].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			//columns[CT_GoodsName].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			//columns[CT_CpBodyColorSName].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
		
			//---------------------------------------------------------------------
			//�@�e�L�X�g�̕\���ʒu
			//---------------------------------------------------------------------
			columns[CT_Select].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			columns[CT_MakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			columns[CT_GoodsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			columns[CT_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//columns[CT_CpBodyColorSName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

		}

		/// <summary>
		/// �O���b�h�̃Z�b�e�B���O�`�揈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h�S�̂̃Z���X�^�C���E�����F��ݒ肷��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.18</br>
		/// </remarks>
		private void SettingGridRowEditor()
		{
			int cnt = this.SELECTGrid.Rows.Count;

			// �`����ꎞ��~
			this.SELECTGrid.BeginUpdate();
			try
			{
				for (int i = 0; i < cnt; i++)
				{
					SettingGridRowEditor(i);
				}
			}
			finally
			{
				// �`����J�n
				this.SELECTGrid.EndUpdate();
			}
		}
		
		/// <summary>
		/// �\���O���b�h�s�P�ʂł̃Z���`�揈��
		/// </summary>
		/// <param name="row">�w��s</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�S�̂̃Z���X�^�C���E�����F��ݒ肷��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.18</br>
		/// </remarks>
		private void SettingGridRowEditor(int row)
		{
			// �f�t�H���g�s�̑O�i�F
			this.SELECTGrid.Rows[row].Appearance.ForeColor = Color.Black;
			this.SELECTGrid.Rows[row].Appearance.ForeColorDisabled = Color.Black;
		}

		
		/// <summary>
		/// �I��p�e�[�u���쐬
		/// </summary>
		/// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
		/// <remarks>
		/// <br>Note       : �I��p�e�[�u�����쐬���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.18</br>
		/// </remarks>
		private void SettingSelGoodUnitDataTable(List<GoodsUnitData> goodsUnitDataList)
		{
			foreach (GoodsUnitData data in goodsUnitDataList)
			{
				DataRow row = this.SelGoodUnitDataDataRow(data);

				if (row != null)
					this._selDataTable.Rows.Add(row);
			}
		}
		
		/// <summary>
		/// ���i�A���}�X�^(goodsUnitData)�@�ˁ@�I��p�e�[�u��DataRow
		/// </summary>
		/// <param name="goodsUnitData">���i�A���}�X�^</param>
		/// <remarks>
		/// <br>Note       : �I��p�e�[�u����DataRow���쐬���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.18</br>
		/// </remarks>
		private DataRow SelGoodUnitDataDataRow(GoodsUnitData goodsUnitData)
		{
			DataRow row = this._selDataTable.NewRow();

			// �I��
			row[CT_Select] = false;

			// ���[�J�[��
			row[CT_MakerName] = goodsUnitData.MakerName;

			// ���i�R�[�h
			row[CT_GoodsCode] = goodsUnitData.GoodsNo;

			// ���i����
			row[CT_GoodsName] = goodsUnitData.GoodsName;

			// ���i�A���f�[�^�N���X�i�[
			row[CT_GoodsUitData] = goodsUnitData.Clone();

			return row;
		}

		/// <summary>
		/// ���i�S�I��
		/// </summary>
		/// <remarks>
		/// <br>Note       :�\������Ă���DataRow��S�I�����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.18</br>
		/// </remarks>
		private void SelectAllDataRow()
		{
			for (int i = 0; i < this._selDataView.Count; i++)
			{
				// �I����Ԃɂ���
				this._selDataView[i][CT_Select] = true;
			}

			// �S�s�̔w�i�F�ύX
			this.ChangedRowBackColor();
		}

		/// <summary>
		/// �I��p�e�[�u��DataRow �ˁ@���i�A���}�X�^(goodsUnitData)
		/// </summary>
		/// <param name="row">�Ώۍs</param>
		/// <param name="goodsUnitData">���i�A���}�X�^</param>
		/// <remarks>
		/// <br>Note       : �I��p�e�[�u����DataRow���쐬���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.18</br>
		/// </remarks>
		private void SelDataRowToGoodsUnitDataLst()
		{
			for (int i = 0; i < this._selDataView.Count; i++)
			{
				// �I������Ă��邩
				bool select = (this._selDataView[i][CT_Select] != DBNull.Value) ? (Boolean)this._selDataView[i][CT_Select] : false;

				if (select)
				{
					// ���i�A���f�[�^�N���X�i�[
					GoodsUnitData goodsUnitData = (this._selDataView[i][CT_GoodsUitData] != DBNull.Value) ? ((GoodsUnitData)this._selDataView[i][CT_GoodsUitData]).Clone() : null;

					if (goodsUnitData != null)
					{
						if (this._selDataLst == null)
							this._selDataLst = new List<GoodsUnitData>();

						this._selDataLst.Add(goodsUnitData);
					}
				}
			}

		}

		/// <summary>
		/// �S�s�w�i�F�ύX����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Ώۍs�̔w�i�F��ύX���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.19</br>
		/// </remarks>
		private void ChangedRowBackColor()
		{
			Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
				this.SELECTGrid.Rows.GetFilteredInNonGroupByRows();

			foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
			{
				this.ChangedRowBackColor(_row);
			}
		}
		
		/// <summary>
		/// �Y���s�w�i�F�ύX����
		/// </summary>
		/// <param name="row">�Ώۍs�C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �Ώۍs�̔w�i�F��ύX���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.19</br>
		/// </remarks>
		private void ChangedRowBackColor(Infragistics.Win.UltraWinGrid.UltraGridRow row)
		{
			if ((Boolean)row.Cells[CT_Select].Value == true)
			{
				row.Appearance.BackColor = this._selBackColor;
				row.Appearance.BackColor2 = this._selBackColor2;
				row.Appearance.BackGradientStyle = this._selBackGradientStyle;
			}
			else
			{
				row.Appearance.BackColor = _defRowAppearance.BackColor;
				row.Appearance.BackColor2 = _defRowAppearance.BackColor2;
				row.Appearance.BackGradientStyle = _defRowAppearance.BackGradientStyle;
			}
		}

		/// <summary>
		/// �J�����񕝒���
		/// </summary>
		/// <remarks>
		/// <br>Note       : �J�����̗񕝂𒲐����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.05.11</br>
		/// </remarks>
		private void ColumnPerformAutoResize()
		{
			for (int i = 0; i < this.SELECTGrid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				this.SELECTGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, true);
			}
		}


		#endregion


		//================================================================================
		//  �R���g���[���C�x���g
		//================================================================================
		#region Control Event

		/// <summary>
		/// ��ʃ��[�h�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MAKHN04110UB_Load(object sender, EventArgs e)
		{
			try
			{
				// ����N�����̂�
				if (this._initialCount == 0)
				{
					// �c�[���o�[�����ݒ� 
					this.InitializeToolbarsSetting();

					// �f�[�^�e�[�u���̍쐬
					this.CreatSelectDadaTable();

					// �f�[�^�\�[�X�ݒ�
					this.SELECTGrid.DataSource = this._selDataView;
				}
				else
				{
					if (this._selDataTable != null)
						this._selDataTable.Rows.Clear();
				}

				// �f�[�^���X�g����\���p�̃f�[�^�e�[�u���쐬
				this.SettingSelGoodUnitDataTable(this._dspDataLst);

				// �f�[�^�Đݒ�
				this.SELECTGrid.DataBind();

				// �O���b�h�̕`��
				this.SettingGridRowEditor();

				// �f�t�H���g�s�̊O�ς��擾����
				this._defRowAppearance = (Infragistics.Win.Appearance)this.SELECTGrid.DisplayLayout.Override.RowAppearance.Clone();

				this._initialCount++;

				this.ColReSize_Timer.Enabled = true;
			}
			catch (Exception ex)
			{
				// ���b�Z�[�W�\��
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,      // �G���[���x��
					this.GetType().ToString(),            // �A�Z���u���h�c�܂��̓N���X�h�c
					this.Text,                            // �v���O��������
					"Load",                               // ��������
					"",                                   // �I�y���[�V����
					ex.Message,                           // �\�����郁�b�Z�[�W
					-1,                                   // �X�e�[�^�X�l
					null,                                 // �G���[�����������I�u�W�F�N�g
					MessageBoxButtons.OK,                 // �\������{�^��
					MessageBoxDefaultButton.Button1);     // �����\���{�^��
			}
			finally
			{
			}
		}

		/// <summary>
		/// �O���b�h���C�A�E�g������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SELECTGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// �X�N���[���o�[�X�^�C��
			e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Deferred;

			// ��̎����T�C����
			e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

			// ��w�b�_�̕\���X�^�C��
			e.Layout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Default;

			// �Z���̋��E���X�^�C���̐ݒ� 
			e.Layout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;

			// �s�̋��E���X�^�C���̐ݒ� 
			e.Layout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;

			// �f�[�^�s�̒ǉ�����
			e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			// �f�[�^�s�̍폜����
			e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			// �f�[�^�s�̍X�V����
			e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			// ��ړ��̕ύX
			e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			// �Œ��w�b�_
			e.Layout.UseFixedHeaders = false;

			// �Z���N���b�N�����s�A�N�V����
			if (this._isMultiSelect)
				e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
			else
				e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

			// ActiveCell�̊O�ϐݒ�
			e.Layout.Override.ActiveCellAppearance.BackColor = Color.FromArgb(247, 227, 156);

			//// �w�b�_�[�̊O�ϐݒ�
			//e.Layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			//e.Layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			//e.Layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			//e.Layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
			//e.Layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
			//e.Layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

			// �s�̊O�ϐݒ�
			e.Layout.Override.RowAppearance.BackColor = Color.White;

			// 1�s�����̊O�ϐݒ�
			e.Layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

			// �s�Z���N�^�[�̕\����\��
			e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

			//// �s�Z���N�^�[�̊O�ϐݒ�
			//e.Layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			//e.Layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			//e.Layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// �s�I��ݒ� �s�I�𖳂����[�h(�A�N�e�B�u�̂�)
			e.Layout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
			e.Layout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
			e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;

			// �I���s�̊O�ϐݒ�
			//e.Layout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(255, 255, 255);
			//e.Layout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(0, 0, 0);
			//e.Layout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			//e.Layout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(255, 255, 255);
			//e.Layout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(0, 0, 0);
			//e.Layout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			e.Layout.Override.ActiveRowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			
			// �I���s�̊O�ϐݒ�
			//e.Layout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(255, 255, 255);
			//e.Layout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(0, 0, 0);
			//e.Layout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;

			// �s�I�����́A�S�Ă̗�̕����F�͍��Ƃ���(���̋L�q�Ȃ��Ɣ��F�ɂȂ��Č���Ƃ̔ᔻ�����������߁B)
			e.Layout.Override.SelectedRowAppearance.ForeColor = Color.Black;

			// �s�t�B���^�[�̐ݒ�
			e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

			// �e�L�X�g�̃����^�����O�ݒ�
			e.Layout.Override.CellAppearance.TextTrimming = Infragistics.Win.TextTrimming.Character;


			this.SettingSelGridColumn();

		}

		/// <summary>
		/// �I���O���b�hKeyDown�C�x��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SELECTGrid_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Return:
					{
						if (this._isMultiSelect) return;

						// ���i�A���f�[�^�N���X�i�[
						GoodsUnitData goodsUnitData = (this.SELECTGrid.ActiveRow.Cells[CT_GoodsUitData].Value != DBNull.Value) ? (GoodsUnitData)this.SELECTGrid.ActiveRow.Cells[CT_GoodsUitData].Value : null;

						if (goodsUnitData != null)
						{
							if (this._selDataLst == null)
								this._selDataLst = new List<GoodsUnitData>();

							this._selDataLst.Add(goodsUnitData.Clone());
							this.DialogResult = DialogResult.OK;
						}

						break;
					}
				case Keys.Space:
					{
						if (this.SELECTGrid.ActiveRow == null) return;
						if (!this._isMultiSelect) return;

						bool select = (Boolean)this.SELECTGrid.ActiveRow.Cells[CT_Select].Value;
						this.SELECTGrid.ActiveRow.Cells[CT_Select].Value = !select;

						// �Y���s�̔w�i�F��ύX���܂�
						this.ChangedRowBackColor(this.SELECTGrid.ActiveRow);

						break;
					}
				default:
					break;
			}
		}

		/// <summary>
		/// �I��p�O���b�h�Z���ύX�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		private void SELECTGrid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			if (e.Cell.Column.Key == CT_Select)
			{
				// �Z���̒l���X�V����B
				e.Cell.Row.Update();

				if (!this._isMultiSelect) return;

				// �Y���s�̔w�i�F��ύX���܂�
				this.ChangedRowBackColor(e.Cell.Row);
			}
		}

		/// <summary>
		/// �O���b�h�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note       : �ꗗ�O���b�h���N���b�N���ꂽ�ۂɔ������܂��B</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		private void SELECTGrid_Click(object sender, EventArgs e)
		{
			if (!this._isMultiSelect) return;

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			// �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);

			// UIElement���擾����B
			Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
			if (objUIElement == null)
				return;

			// �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
			Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
				(Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

			if (objHeader != null) return;

			// �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
			Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
				(Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

			if (objRow != null)
			{
				bool select = (Boolean)objRow.Cells[CT_Select].Value;
				objRow.Cells[CT_Select].Value = !select;

				// �Y���s�̔w�i�F��ύX���܂�
				this.ChangedRowBackColor(objRow);
			}
		}

		/// <summary>
		/// �O���b�h�����N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note       : �ꗗ�O���b�h���_�u���N���b�N���ꂽ�ۂɔ������܂��B</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.05.11</br>
		/// </remarks>
		private void SELECTGrid_DoubleClick(object sender, EventArgs e)
		{
			if (this._isMultiSelect) return;

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			// �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);

			// UIElement���擾����B
			Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
			if (objUIElement == null)
				return;

			// �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
			Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
				(Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

			if (objHeader != null) return;

			// �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
			Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
				(Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

			if (objRow != null)
			{
				// ���i�A���f�[�^�N���X�i�[
				GoodsUnitData goodsUnitData = (objRow.Cells[CT_GoodsUitData].Value != DBNull.Value) ? (GoodsUnitData)objRow.Cells[CT_GoodsUitData].Value : null;

				if (goodsUnitData != null)
				{
					if (this._selDataLst == null)
						this._selDataLst = new List<GoodsUnitData>();

					this._selDataLst.Add(goodsUnitData.Clone());
					this.DialogResult = DialogResult.OK;
				}
			}
		}


		/// <summary>
		/// 
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		private void Main_UToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case CT_TOOLBAR_DECISION_KEY:
					{
						// �f�[�^�I��
						if (this._isMultiSelect)
						{
							this.SelDataRowToGoodsUnitDataLst();
						}
						else
						{
							if (this.SELECTGrid.ActiveRow == null) return;

							GoodsUnitData goodsUnitData = (this.SELECTGrid.ActiveRow.Cells[CT_GoodsUitData].Value != DBNull.Value) ? (GoodsUnitData)this.SELECTGrid.ActiveRow.Cells[CT_GoodsUitData].Value : null;

							if (goodsUnitData != null)
							{
								if (this._selDataLst == null)
									this._selDataLst = new List<GoodsUnitData>();

								this._selDataLst.Add(goodsUnitData.Clone());
							}
						}

						this.DialogResult = DialogResult.OK;

						break;
					}
				case CT_TOOLBAR_BACK_KEY:
					{
						this.DialogResult = DialogResult.Cancel;
						
						break;
					}
				case CT_TOOLBAR_ALLSELECT_KEY:
					{
						// �S�s�I��
						this.SelectAllDataRow();
						
						break;
					}
			}


		}

		private void ColReSize_Timer_Tick(object sender, EventArgs e)
		{
			this.ColReSize_Timer.Enabled = false;

			this.SELECTGrid.Refresh();
			this.ColumnPerformAutoResize();
		}

		#endregion











	}
}