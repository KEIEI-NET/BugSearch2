using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ����ԍ��d���`�[�I���t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d���`�[�����œ���ԍ����������݂���ꍇ��1�`�[��I������N���X�ł��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men �V�K�쐬</br>
	/// </remarks>
	public partial class MAKON01110UH : Form
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MAKON01110UH()
		{
			InitializeComponent();

			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

		}

		#endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		#region ��Const

		// -------------------------------------------------------------------------------
		#region < �O���b�h��p >

		/// <summary>���o���ʁE���ɓ��̓e�[�u��</summary>
        private const string CT_SELECT_TBL = "SelectTable";
		/// <summary>�d����</summary>
        public const string CT_StockDate = "StockDate";
		/// <summary>���ד�</summary>
        public const string CT_ArrivalGoodsDay = "ArrivalGoodsDay";
		/// <summary>�`�[�ԍ�</summary>
        public const string CT_PartySalesSlipNum = "PartySalesSlipNum";
		/// <summary>�d����R�[�h</summary>
        public const string CT_SupplierCd = "SupplierCd";
		/// <summary>�d���於</summary>
        public const string CT_SupplierName = "SupplierName";
		/// <summary>�d��SEQ�ԍ�</summary>
        public const string CT_SupplierSlipNo = "SupplierSlipNo";
		/// <summary>���l</summary>
        public const string CT_SupplierSlipNote1 = "SupplierSlipNote1";
		/// <summary>���}�[�N1</summary>
        public const string CT_UoeRemark1 = "UoeRemark1";
		/// <summary>�d���f�[�^�N���X�i�[</summary>
        public const string CT_StockSlip = "StockSlip";

		#endregion

		// -------------------------------------------------------------------------------
		#region < �c�[���o�[�L�[��� >

		// �c�[���o�[�L�[���    
		private const string CT_TOOLBAR_DECISION_KEY = "ButtonTool_Decision";
		private const string CT_TOOLBAR_BACK_KEY = "ButtonTool_Back";
		#endregion

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		/// <summary>�I��p�f�[�^�e�[�u��</summary>
		private DataTable _selDataTable;
		/// <summary>�I��p�f�[�^�r���[</summary>
		private DataView _selDataView;
		/// <summary>�\������f�[�^���X�g</summary>
		private List<StockSlip> _dspDataLst;
		/// <summary>�I�������f�[�^���X�g</summary>
		private List<StockSlip> _selDataList;
		/// <summary>��ʃf�U�C���ύX�N���X</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
		/// <summary>�N���J�E���^�[</summary>
		private int _initialCount = 0;
		/// <summary>�d���`��</summary>
		private int _supplierFormal;

		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties

		/// <summary>�I���f�[�^���X�g</summary>
		public List<StockSlip> SelectDataList
		{
			get { return _selDataList; }
		}

		#endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		#region ��Public Methods

		/// <summary>
		/// ��ʌďo������
		/// </summary>
		/// <param name="owner">�I�[�i�[�t�H�[��</param>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="stockSlipList">�d���f�[�^���X�g</param>
		/// <returns></returns>
		public DialogResult ShowDialog( IWin32Window owner, int supplierFormal, List<StockSlip> stockSlipList )
		{
			// �\���p�̃f�[�^���X�g���쐬����
			this._dspDataLst = new List<StockSlip>(stockSlipList);

			this._supplierFormal = supplierFormal;

			return this.ShowDialog(owner);
		}

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		#region ��Private Methods

		/// <summary>
		/// �c�[���o�[�����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private void InitializeToolbarsSetting()
		{
			// �C���[�W���X�g�ݒ�
			this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

			// �m��{�^���̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool decButton = this.tToolbarsManager_MainMenu.Tools[CT_TOOLBAR_DECISION_KEY] as Infragistics.Win.UltraWinToolbars.ButtonTool;
			if (decButton != null)
			{
				decButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			}

			// �߂�{�^���̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool backButton = this.tToolbarsManager_MainMenu.Tools[CT_TOOLBAR_BACK_KEY] as Infragistics.Win.UltraWinToolbars.ButtonTool;
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
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private void CreatSelectDadaTable()
		{
			// ----------------------------------------

			// DataTable�̍쐬
			this._selDataTable = new DataTable(CT_SELECT_TBL);
			this._selDataView = new DataView(this._selDataTable);

			// ----------------------------------------
			// DataColumn�̍쐬

			//// �I��
			//DataColumn Select = new DataColumn(CT_Select, typeof(Boolean), "", MappingType.Element);
			//Select.Caption = "�I��";

			// �d����
			DataColumn StockDate = new DataColumn(CT_StockDate, typeof(DateTime), "", MappingType.Element);
			StockDate.Caption = "�d����";

			// ���ד�
			DataColumn ArrivalGoodsDay = new DataColumn(CT_ArrivalGoodsDay, typeof(DateTime), "", MappingType.Element);
			ArrivalGoodsDay.Caption = "���ד�";

			// �`�[�ԍ�
			DataColumn PartySalesSlipNum = new DataColumn(CT_PartySalesSlipNum, typeof(string), "", MappingType.Element);
			PartySalesSlipNum.Caption = "�`�[�ԍ�";

			// �d����R�[�h
			DataColumn SupplierCd = new DataColumn(CT_SupplierCd, typeof(Int32), "", MappingType.Element);
			SupplierCd.Caption = "�d����R�[�h";

			// �d���於
			DataColumn SupplierName = new DataColumn(CT_SupplierName, typeof(string), "", MappingType.Element);
			SupplierName.Caption = "�d���於";

			// �d��SEQ�ԍ�
			DataColumn SupplierSlipNo = new DataColumn(CT_SupplierSlipNo, typeof(Int32), "", MappingType.Element);
			SupplierSlipNo.Caption = "�d��SEQ�ԍ�";

			// ���l
			DataColumn SupplierSlipNote1 = new DataColumn(CT_SupplierSlipNote1, typeof(string), "", MappingType.Element);
			SupplierSlipNote1.Caption = "���l";

			// ���}�[�N1
			DataColumn UoeRemark1 = new DataColumn(CT_UoeRemark1, typeof(string), "", MappingType.Element);
			UoeRemark1.Caption = "���}�[�N1";

			// �d���f�[�^�N���X�i�[
			DataColumn stockSlip = new DataColumn(CT_StockSlip, typeof(StockSlip), "", MappingType.Element);
			stockSlip.Caption = "�d���f�[�^�N���X�i�[";


			// ----------------------------------------
			// DataTable�̏�����
			this._selDataTable.Columns.AddRange(new DataColumn[] {
				//Select,
				StockDate,
				ArrivalGoodsDay,
				PartySalesSlipNum,
				SupplierCd,
				SupplierName,
				SupplierSlipNo,
				SupplierSlipNote1,
				UoeRemark1,
				stockSlip});
		}

		/// <summary>
		/// �I��p�e�[�u���쐬
		/// </summary>
		/// <param name="stockSlipList">�d���f�[�^���X�g</param>
		/// <remarks>
		/// <br>Note       : �I��p�e�[�u�����쐬���܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private void SettingSelStockSlipDataTable( List<StockSlip> stockSlipList )
		{
			foreach (StockSlip data in stockSlipList)
			{
				DataRow row = this.SelStockSlipDataDataRow(data);

				if (row != null)
					this._selDataTable.Rows.Add(row);
			}
		}

		/// <summary>
		/// �d���f�[�^(stockSlip)�@�ˁ@�I��p�e�[�u��DataRow
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^</param>
		/// <remarks>
		/// <br>Note       : �I��p�e�[�u����DataRow���쐬���܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private DataRow SelStockSlipDataDataRow( StockSlip stockSlip )
		{
			DataRow row = this._selDataTable.NewRow();

			//// �I��
			//row[CT_Select] = false;

			// �d����
			row[CT_StockDate] = stockSlip.StockDate;

			// ���ד�
			row[CT_ArrivalGoodsDay] = stockSlip.ArrivalGoodsDay;

			// �`�[�ԍ�
			row[CT_PartySalesSlipNum] = stockSlip.PartySaleSlipNum;

			// �d����R�[�h
			row[CT_SupplierCd] = stockSlip.SupplierCd;

			// �d���於
			row[CT_SupplierName] = stockSlip.SupplierSnm;

			// �d��SEQ�ԍ�
			row[CT_SupplierSlipNo] = stockSlip.SupplierSlipNo;

			// ���l
			row[CT_SupplierSlipNote1] = stockSlip.SupplierSlipNote1;

			// ���}�[�N
			row[CT_UoeRemark1] = stockSlip.UoeRemark1;

			// �d���f�[�^�N���X�i�[
			row[CT_StockSlip] = stockSlip.Clone();

			return row;
		}

		/// <summary>
		/// �I��p�O���b�h�J�������ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �I��p�O���b�h�ɕ\������J��������ݒ肵�܂��B</br>
		/// <br>Programmer : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private void SettingSelGridColumn()
		{
			// �o���h���擾
			Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Select.DisplayLayout.Bands[0];
			Infragistics.Win.UltraWinGrid.ColumnsCollection columns = band.Columns;

			//---------------------------------------------------------------------
			//�@�J�����\���E��\��
			//---------------------------------------------------------------------
			//columns[CT_Select].Hidden = !this._isMultiSelect;
			columns[CT_StockSlip].Hidden = true;

			if (this._supplierFormal == 0)
			{
				columns[CT_ArrivalGoodsDay].Hidden = true;
			}
			else
			{
				columns[CT_StockDate].Hidden = true;
			}

			//---------------------------------------------------------------------
			//�@�w�b�_�[�L���v�V����
			//---------------------------------------------------------------------

			//---------------------------------------------------------------------
			//�@�A�N�e�B�u������
			//---------------------------------------------------------------------
			columns[CT_StockDate].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			columns[CT_ArrivalGoodsDay].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_PartySalesSlipNum].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_SupplierCd].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_SupplierName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_SupplierSlipNo].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_SupplierSlipNote1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_UoeRemark1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

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
			columns[CT_StockDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			columns[CT_ArrivalGoodsDay].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			columns[CT_PartySalesSlipNum].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			columns[CT_SupplierCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			columns[CT_SupplierName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			columns[CT_SupplierSlipNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			columns[CT_SupplierSlipNote1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			columns[CT_UoeRemark1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

			//---------------------------------------------------------------------
			//�@�Z���̕�
			//---------------------------------------------------------------------
			columns[CT_StockDate].Width = 90;
			columns[CT_ArrivalGoodsDay].Width = 90;
			columns[CT_PartySalesSlipNum].Width = 120;
			columns[CT_SupplierCd].Width = 120;
			columns[CT_SupplierName].Width = 170;
			columns[CT_SupplierSlipNo].Width = 100;
			columns[CT_SupplierSlipNote1].Width = 200;
			columns[CT_UoeRemark1].Width = 160;

			//---------------------------------------------------------------------
			//�@�t�H�[�}�b�g
			//---------------------------------------------------------------------
			string dateFormat = "yyyy/MM/dd";
			columns[CT_StockDate].Format = dateFormat;
			columns[CT_ArrivalGoodsDay].Format= dateFormat;

		}
		#endregion

		// ===================================================================================== //
		// �R���g���[���̃C�x���g
		// ===================================================================================== //
		#region ��Control Events

		/// <summary>
		/// ��ʃ��[�h�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MAKON01110UI_Load( object sender, EventArgs e )
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
					this.uGrid_Select.DataSource = this._selDataView;
				}
				else
				{
					if (this._selDataTable != null)
						this._selDataTable.Rows.Clear();
				}

				// �f�[�^���X�g����\���p�̃f�[�^�e�[�u���쐬
				this.SettingSelStockSlipDataTable(this._dspDataLst);

				this._initialCount++;

				this.timer_InitialFocus.Enabled = true;
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
		private void uGrid_Select_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
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
			//if (this._isMultiSelect)
			//    e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
			//else
			//    e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
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
		/// �O���b�h�L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uGrid_Select_KeyDown( object sender, KeyEventArgs e )
		{
			switch (e.KeyCode)
			{
				case Keys.Return:
					{
						StockSlip stockslip = ( this.uGrid_Select.ActiveRow.Cells[CT_StockSlip].Value != DBNull.Value ) ? (StockSlip)this.uGrid_Select.ActiveRow.Cells[CT_StockSlip].Value : null;

						if (stockslip != null)
						{
							if (this._selDataList == null)
								this._selDataList = new List<StockSlip>();

							this._selDataList.Add(stockslip.Clone());
							this.DialogResult = DialogResult.OK;
						}

						break;
					}
				case Keys.Right:
					{
						// �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
						e.Handled = true;
						// �O���b�h�\�����E�ɃX�N���[��
						this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position + 40;
						break;
					}
				case Keys.Left:
					{
						// �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
						e.Handled = true;

						if (this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position == 0)
						{
						}
						else
						{
							// �O���b�h�\�������ɃX�N���[��
							this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position - 40;

						}
						break;
					}
				default:
					break;
			}
		}

		/// <summary>
		/// �O���b�h�_�u���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uGrid_Select_DoubleClick( object sender, EventArgs e )
		{
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
				StockSlip stockSlip = ( objRow.Cells[CT_StockSlip].Value != DBNull.Value ) ? (StockSlip)objRow.Cells[CT_StockSlip].Value : null;

				if (stockSlip != null)
				{
					if (this._selDataList == null)
						this._selDataList = new List<StockSlip>();

					this._selDataList.Add(stockSlip.Clone());
					this.DialogResult = DialogResult.OK;
				}
			}
		}

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tToolbarsManager_MainMenu_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			switch (e.Tool.Key)
			{
				case CT_TOOLBAR_DECISION_KEY:
					{

						if (this.uGrid_Select.ActiveRow == null) return;

						StockSlip stockSlip = ( this.uGrid_Select.ActiveRow.Cells[CT_StockSlip].Value != DBNull.Value ) ? (StockSlip)this.uGrid_Select.ActiveRow.Cells[CT_StockSlip].Value : null;

						if (stockSlip != null)
						{
							if (this._selDataList == null)
								this._selDataList = new List<StockSlip>();

							this._selDataList.Add(stockSlip.Clone());
							this.DialogResult = DialogResult.OK;
						}


						this.DialogResult = DialogResult.OK;

						break;
					}
				case CT_TOOLBAR_BACK_KEY:
					{
						this.DialogResult = DialogResult.Cancel;

						break;
					}
			}
		}

		/// <summary>
		/// �����t�H�[�J�X�^�C�}�[Tick�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_InitialFocus_Tick( object sender, EventArgs e )
		{
			this.timer_InitialFocus.Enabled = false;
			if (this.uGrid_Select.Rows.Count > 0)
			{
				this.uGrid_Select.ActiveRow = this.uGrid_Select.Rows[0];
				this.uGrid_Select.Rows[0].Selected = true;
			}
		}

		#endregion
	}
}