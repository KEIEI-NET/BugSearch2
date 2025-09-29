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
using Broadleaf.Library.Text;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d���挟�����[�U�[�R���g���[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ�Ǝd����̃A�N�Z�X�N���X�����������אV�K�ǉ����܂����B</br>
	/// <br>Programmer : 21024�@���X�؁@��</br>
	/// <br>Date       : 2008.05.22</br>
    /// <br>Update Note: 2012/12/24 ���N</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>             Redmine#33741�̑Ή�</br>
	/// <br></br>
	/// </remarks>
	internal partial class SFCMN00221UQ : System.Windows.Forms.UserControl
	{
		// ===================================================================================== //
		// �d���挟���t�H�[���N���X�̃f�t�H���g�R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// �d���挟�����[�U�[�R���g���[���N���X�f�t�H���g�R���X�g���N�^
		/// </summary>
		public SFCMN00221UQ( ControlScreenSkin controlScreenSkin )
		{
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			InitializeComponent();

			// �X�L���ݒ�
			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Condition.Name);
			controlScreenSkin.SetExceptionCtrl(ctrlNameList);
			controlScreenSkin.SettingScreenSkin(this);
		}
		# endregion

		// ===================================================================================== //
		// �����Ŏg�p����萔�Q
		// ===================================================================================== //
		# region Const
		private const int EDIT_TYPE_Kana = 1;														// �d����J�i
		private const int EDIT_TYPE_SupplierCd = 2;													// �d����R�[�h

		private const string SEARCH_TABLE = "SupplierSearchTable";
		internal const string SEARCH_COL_EnterpriseCode = "EnterpriseCode";							// ��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)
		internal const string SEARCH_COL_SupplierCd = "SupplierCd";									// �d����R�[�h
		internal const string SEARCH_COL_Name = "SupplierNm1";										// ����
		internal const string SEARCH_COL_Name2 = "SupplierNm2";										// ���̂Q
		internal const string SEARCH_COL_HonorificTitle = "SuppHonorificTitle";						// �h��
		internal const string SEARCH_COL_Kana = "Kana";												// �J�i
		internal const string SEARCH_COL_TelNo = "TelNo";											// �d�b�ԍ�
		internal const string SEARCH_COL_PostNo = "PostNo";											// �X�֔ԍ�
		internal const string SEARCH_COL_Address1 = "Address1";										// �Z���P�i�s���{���s��S�E�����E���j
		internal const string SEARCH_COL_Address3 = "Address3";										// �Z���R�i�Ԓn�j
		internal const string SEARCH_COL_Address4 = "Address4";										// �Z���S�i�A�p�[�g���́j
		internal const string SEARCH_COL_Address = "Address";										// �Z��
		internal const string SEARCH_COL_CustomerSearchRet = "CustomerSearchRet";					// �d���挟�����ʃN���X
		private const string RECORD_KEY_SUPPLIER = "SupplierRecord";

		//private const int DEFAULT_EDIT_WIDTH = 224;
        private const int DEFAULT_EDIT_WIDTH = 320;
		private const int GUIDE_WIDTH_DIFFERENCE = 26;

		private const string FILENAME_COLDISPLAYSTATUS = "SFCMN00221U_ColSetting4.DAT";				// ��\����ԃZ�b�e�B���OXML�t�@�C����
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private DataTable _searchDataTable;
		private DataView _searchDataView;
		private string _enterpriseCode = "";						// ��ƃR�[�h
		private SFCMN00221UL _customControl_ExtractWait;
		private ColDisplayStatusList _colDisplayStatusList;			// ��\����ԃR���N�V�����N���X
		private bool _isInitial = true;								// �����t���O
		private SFCMN00221UAParam _param;
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		/// <summary>�p�l���ύX�C�x���g</summary>
		internal event PanelChangeEventHandler PanelChange;

		/// <summary>�d����I����C�x���g</summary>
		internal event SupplierSelectedHandler SupplierSelected;
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// ��\����ԃN���X�ۑ�����
		/// </summary>
		internal void SaveColDisplayStatus()
		{
            if (this.uGrid_Search.DataSource != null)
            {
                // ��\����ԃN���X���X�g�\�z����
                List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns);
                this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

                // ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
                ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
            }
		}
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// �����ݒ菈��
        /// <br>Update Note: 2013/02/07 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
		/// </summary>
		internal void InitialSetting(SFCMN00221UAParam param)
		{
			this._param = param;

			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Condition.Name);

			if (this._isInitial)
			{
				// �ϐ�������
				this._searchDataTable = new DataTable(SEARCH_TABLE);
				this._searchDataView = new DataView(this._searchDataTable);
				this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;		// ��ƃR�[�h���擾

				// ���o���\���R���g���[����������
				this._customControl_ExtractWait = new Broadleaf.Windows.Forms.SFCMN00221UL();
				this._customControl_ExtractWait.BringToFront();
				this._customControl_ExtractWait.BackColor = System.Drawing.Color.GhostWhite;
				this._customControl_ExtractWait.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				this._customControl_ExtractWait.Location = new System.Drawing.Point(5, 245);
				this._customControl_ExtractWait.Name = "customControl_ExtractWait";
				this._customControl_ExtractWait.Size = new System.Drawing.Size(250, 40);
				this._customControl_ExtractWait.TabIndex = 22;
				this._customControl_ExtractWait.Visible = false;
				this._customControl_ExtractWait.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.panel_Main.Controls.Add(this._customControl_ExtractWait);

				// �O���b�h�Ƀf�[�^�Z�b�g���o�C���h
				this.uGrid_Search.DataSource = this.dataSet_CustomerSearch;

				// �R���|�[�l���g�����ݒ�
				this.tEdit_CustomerFindCondition.Top = 50;
				this.tEdit_CustomerFindCondition.Left = 11;
				this.tNedit_CustomerFindCondition.Top = 50;
				this.tNedit_CustomerFindCondition.Left = 11;

				this.uLabel_CustomerFindCondition.Top = 49;
				this.uLabel_CustomerFindCondition.Left = 10;

                // ----- ADD ���N 2013/02/07 for Redmine#33741 ----->>>>>
                this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
                this.tEdit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                this.tNedit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                // ----- ADD ���N 2013/02/07 for Redmine#33741 -----<<<<<

				this.tComboEditor_CustomerFindCondition.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.uButton_Find.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));

				this.tComboEditor_CustomerFindCondition.Value = EDIT_TYPE_Kana;

				// �C���[�W�A�C�R���ݒ菈��
				ImageList imglist = IconResourceManagement.ImageList16;

				// �O���b�h�̃t�H���g�T�C�Y��ݒ�
				this.tComboEditor_GridFontSize.Value = 11;

				// �d���挟�����ʃf�[�^�e�[�u���ݒ菈��
				this.SettingDataTable();

				// �d���挟�����ʃO���b�h�J�������ݒ菈��
				this.SettingGridColumns();

				this._isInitial = false;
			}

			// ���o�����^�C�g���ݒ�
			string dataType1 = "";
			//string dataType2 = "";
			this._customControl_ExtractWait.DataType = dataType1;
		}

		/// <summary>
		/// �p�l���A�N�e�B�u���\�b�h
		/// </summary>
		internal void PanelActivated()
		{
			this.timer_Activated.Enabled = true;
		}

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// �d���挟�����ʃf�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d���挟�����ʃf�[�^�e�[�u����ݒ肵�܂��B</br>
		/// <br>Programer  : 21024  ���X�� ��</br>
		/// <br>Date       : 2008.05.22</br>
		/// </remarks>
		private void SettingDataTable()
		{
			DataColumn enterpriseCodeColumn = new DataColumn(SEARCH_COL_EnterpriseCode, typeof(String), "", MappingType.Element);		// ��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)
			DataColumn customerCodeColumn = new DataColumn(SEARCH_COL_SupplierCd, typeof(Int32), "", MappingType.Element);				// �d����R�[�h
			DataColumn nameColumn = new DataColumn(SEARCH_COL_Name, typeof(String), "", MappingType.Element);							// ����
			DataColumn name2Column = new DataColumn(SEARCH_COL_Name2, typeof(String), "", MappingType.Element);							// ���̂Q
			DataColumn honorificTitleColumn = new DataColumn(SEARCH_COL_HonorificTitle, typeof(String), "", MappingType.Element);		// �h��
			DataColumn kanaColumn = new DataColumn(SEARCH_COL_Kana, typeof(String), "", MappingType.Element);							// �J�i
			DataColumn homeTelNoColumn = new DataColumn(SEARCH_COL_TelNo, typeof(String), "", MappingType.Element);						// �d�b�ԍ�
			DataColumn postNoColumn = new DataColumn(SEARCH_COL_PostNo, typeof(String), "", MappingType.Element);						// �X�֔ԍ�
			DataColumn address1Column = new DataColumn(SEARCH_COL_Address1, typeof(String), "", MappingType.Element);					// �Z���P�i�s���{���s��S�E�����E���j
			DataColumn address3Column = new DataColumn(SEARCH_COL_Address3, typeof(String), "", MappingType.Element);					// �Z���R�i�Ԓn�j
			DataColumn address4Column = new DataColumn(SEARCH_COL_Address4, typeof(String), "", MappingType.Element);					// �Z���S�i�A�p�[�g���́j
			DataColumn addressColumn = new DataColumn(SEARCH_COL_Address, typeof(String), "", MappingType.Element);						// �Z���S�i�A�p�[�g���́j
			DataColumn customerSearchRetColumn = new DataColumn(SEARCH_COL_CustomerSearchRet, typeof(Supplier), "", MappingType.Element);	// �d���挟�����ʃN���X

			// �f�[�^�Z�b�g�̏�����
			this.dataSet_CustomerSearch.Tables.AddRange(new DataTable[] { this._searchDataTable });

			// �f�[�^�e�[�u���̏�����
			this._searchDataTable.Columns.AddRange(new DataColumn[] {
																				    nameColumn,
																					name2Column,
																				    customerCodeColumn,
																				    kanaColumn,
																				    homeTelNoColumn,
																					postNoColumn,
																					address1Column,
																					address3Column,
																					address4Column,
																					addressColumn,
																				    enterpriseCodeColumn,
																					honorificTitleColumn,
																					customerSearchRetColumn
			});

			// ��L�[�ݒ�(�d���挟���p�e�[�u���j
			DataColumn[] columns = new DataColumn[] {customerCodeColumn};
			this._searchDataTable.PrimaryKey = columns;

			// �\�[�g���ݒ�(�d���挟���p�e�[�u���j�J�i�̏����Ƃ���
			this._searchDataView.Sort = SEARCH_COL_Kana + " DESC";
		}

		/// <summary>
		/// �d���挟���f�[�^�e�[�u���s�ǉ�����
		/// </summary>
		/// <param name="supplierSearchRet">�d���挟�����ʃN���X</param>
		/// <returns>�l���ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note       : �d���挟�����ʃN���X���f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer  : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.05.22</br>
		/// </remarks>
		private void AddSupplierSearchTableRow(Supplier supplierSearchRet)
		{
			DataRow row = this._searchDataTable.NewRow();

			row[SEARCH_COL_EnterpriseCode] = supplierSearchRet.EnterpriseCode;		// ��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)
			row[SEARCH_COL_SupplierCd] = supplierSearchRet.SupplierCd;				// �d����R�[�h
			row[SEARCH_COL_Name] = supplierSearchRet.SupplierNm1;					// ����
			row[SEARCH_COL_Name2] = supplierSearchRet.SupplierNm2;					// ���̂Q
			row[SEARCH_COL_HonorificTitle] = supplierSearchRet.SuppHonorificTitle;	// �h��
			row[SEARCH_COL_Kana] = supplierSearchRet.SupplierKana;					// �J�i
			row[SEARCH_COL_TelNo] = supplierSearchRet.SupplierTelNo;				// �d�b�ԍ�
			row[SEARCH_COL_PostNo] = supplierSearchRet.SupplierPostNo;				// �X�֔ԍ�
			row[SEARCH_COL_Address1] = supplierSearchRet.SupplierAddr1;				// �Z���P�i�s���{���s��S�E�����E���j
			row[SEARCH_COL_Address3] = supplierSearchRet.SupplierAddr3;				// �Z���R�i�Ԓn�j
			row[SEARCH_COL_Address4] = supplierSearchRet.SupplierAddr4;				// �Z���S�i�A�p�[�g���́j
			row[SEARCH_COL_CustomerSearchRet] = supplierSearchRet.Clone();			// �d���挟�����ʃN���X
			row[SEARCH_COL_Address] =
				supplierSearchRet.SupplierAddr1 +
				supplierSearchRet.SupplierAddr3 +
				supplierSearchRet.SupplierAddr4;									// �Z��

			this._searchDataTable.Rows.Add(row);
		}

		/// <summary>
		/// �d���挟�����ʃO���b�h�J�������ݒ菈��
		/// </summary>
		/// <param name="Columns">�O���b�h�̃J�����R���N�V����</param>
		private void SettingGridColumns()
		{
			if (!this.uGrid_Search.DisplayLayout.Bands.Exists(SEARCH_TABLE))
			{
				return;
			}

			Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns;

			// ��U�A�S�Ă̗���\���ɐݒ肵�A�\���ʒu�𓝈ꂳ����
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				column.Hidden = true;
				column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
			}

			// �\������J��������ݒ肷��
			// ���� ��ݒ�
			columns[SEARCH_COL_Name].Header.Caption = "�d���於";
			columns[SEARCH_COL_Name].Hidden = false;
			columns[SEARCH_COL_Name].CellAppearance.Cursor = Cursors.Hand;

			// �d����R�[�h ��ݒ�
			columns[SEARCH_COL_SupplierCd].Header.Caption = "�R�[�h";
			columns[SEARCH_COL_SupplierCd].Hidden = false;
			columns[SEARCH_COL_SupplierCd].CellAppearance.Cursor = Cursors.Hand;
			columns[SEARCH_COL_SupplierCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

			// �J�i ��ݒ�
			columns[SEARCH_COL_Kana].Header.Caption = "�J�i";
			columns[SEARCH_COL_Kana].Hidden = false;
			columns[SEARCH_COL_Kana].CellAppearance.Cursor = Cursors.Hand;

			// ����TEL ��ݒ�
			columns[SEARCH_COL_TelNo].Header.Caption = "�s�d�k";
			columns[SEARCH_COL_TelNo].Hidden = false;
			columns[SEARCH_COL_TelNo].CellAppearance.Cursor = Cursors.Hand;

			// �Z�� ��ݒ�
			columns[SEARCH_COL_Address].Header.Caption = "�Z��";
			columns[SEARCH_COL_Address].Hidden = false;
			columns[SEARCH_COL_Address].CellAppearance.Cursor = Cursors.Hand;

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
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.22</br>
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
		/// <param name="mode">���[�h</param>
		private void TEditChangeEdit(Broadleaf.Library.Windows.Forms.TEdit edit, int mode)
		{
			switch (mode)
			{
				case EDIT_TYPE_Kana:													// �d����J�i
				{
					edit.CharacterCasing = CharacterCasing.Normal;
                    edit.ExtEdit =
                        new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 21, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
					edit.ImeMode = ImeMode.KatakanaHalf;
					break;
				}
			}
		}

		/// <summary>
		/// TNedit���̓��[�h�ϊ�����
		/// </summary>
		/// <param name="edit">�ύX����Edit�R���|�[�l���g</param>
		/// <param name="mode">���[�h</param>
        ///<remarks>
        /// <br>Update Note : 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        ///</remarks>
		private void TNeditChangeEdit(Broadleaf.Library.Windows.Forms.TNedit nEdit, int mode)
		{
			switch (mode)
			{
				case EDIT_TYPE_SupplierCd:											// �d����R�[�h
				{
                    nEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
                    nEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
                    // ----- DEL ���N 2012/12/24 Redmine#33741 ----->>>>>
                    //nEdit.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    //nEdit.ActiveAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    // ----- DEL ���N 2012/12/24 Redmine#33741 -----<<<<<
					break;
				}
			}
		}

		/// <summary>
		/// �d���挟�������N���X�擾����
		/// </summary>
		private Supplier GetSupplierSearchPara()
		{
			Supplier para = new Supplier();

			para.EnterpriseCode = this._enterpriseCode;									// ��ƃR�[�h

			int customerMode = Convert.ToInt32(this.tComboEditor_CustomerFindCondition.SelectedItem.DataValue);

			switch (customerMode)
			{
				// �ڋq�R�[�h
				case EDIT_TYPE_SupplierCd:
				{
					para.SupplierCd = this.tNedit_CustomerFindCondition.GetInt();
					break;
				}
				// �d����J�i
				case EDIT_TYPE_Kana:
				{
					para.SupplierKana = this.tEdit_CustomerFindCondition.Text.ToString();
					break;
				}
			}

			return para;
		}

		/// <summary>
		/// �d���挟������
		/// </summary>
		/// <param name="para">�d���挟�������p�����[�^</param>
		private void Search(Supplier para)
		{
			// �O���b�h�̃t�B���^������
			this.uGrid_Search.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();

			// �f�[�^�e�[�u���̍s���N���A
			this._searchDataTable.Rows.Clear();

			this.uGrid_Search.Refresh();

			SupplierAcs supplierAcs = new SupplierAcs();
			ArrayList retArray;

			// �����������s
			int status = supplierAcs.Search(out retArray, para, (int)SupplierAcs.SearchMode.Contains);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (Supplier supplier in retArray)
				{
					this.AddSupplierSearchTableRow(supplier);
				}
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
			{
				this._customControl_ExtractWait.Visible = true;
				this._customControl_ExtractWait.mode = 1;
				this._customControl_ExtractWait.Top = this.uGrid_Search.Top + 60;
				this._customControl_ExtractWait.Refresh();

				this.timer_MessageUnDisp.Enabled = true;
			}
			else
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"�d����̌����Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// �d���挟���p�����[�^�N���X�`�F�b�N����
		/// </summary>
		/// <param name="para">�d����}�X�^�N���X</param>
		/// <returns>true:�`�F�b�N�n�j false:�`�F�b�N�m�f</returns>
		private bool CheckSupplierSearchPara(Supplier para)
		{
			return true;
		}
		# endregion

		// ===================================================================================== //
		// �R���g���[���C�x���g���\�b�h
		// ===================================================================================== //
		# region Control Event Methods
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

				// �d���挟�������N���X�擾����
				Supplier para = this.GetSupplierSearchPara();

				// �d���挟���p�����[�^�N���X�`�F�b�N����
				if (!this.CheckSupplierSearchPara(para)) return;

				this._customControl_ExtractWait.Visible = true;
				this._customControl_ExtractWait.mode = 0;
				this._customControl_ExtractWait.Top = this.uGrid_Search.Top + 60;
				this._customControl_ExtractWait.Refresh();

				// �d���挟������
				this.Search(para);
			}
			finally
			{
				if (this._customControl_ExtractWait.mode == 0)
				{
					this._customControl_ExtractWait.Visible = false;
					this.Cursor = Cursors.Default;
				}
			}
		}

		/// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
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
								e.NextCtrl = this.tComboEditor_CustomerFindCondition;
							}
							break;
						}
					}

					break;
				}
				case "tNedit_CustomerFindCondition":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tNedit_CustomerFindCondition.GetInt() != 0)
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
				case "tEdit_CustomerFindCondition":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tEdit_CustomerFindCondition.Text != "")
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
			}
		}

		/// <summary>
		/// �����{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_Find_Click(object sender, System.EventArgs e)
		{
			this.timer_Search.Enabled = true;
		}

		/// <summary>
		/// �d���挟�����ʃO���b�h�G�������g�}�E�X�G���^�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Search_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			if ((this.ActiveControl != this.uGrid_Search) && (this.uGrid_Search.Rows.Count > 0))
			{
				this.uGrid_Search.Focus();
			}

			// �d��������|�b�v�A�b�v�\��
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

				this.uGrid_Search.ActiveRow = row;
				this.uGrid_Search.ActiveRow.Selected = true;

				string tipString = "";

				if (row.Cells[0] != null)
				{
					int totalWidth = 6;

					// �d���於��
					tipString += this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Name].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Name].Value.ToString();

					// �J�i
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Kana].Value.ToString();

					// �R�[�h
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_SupplierCd].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_SupplierCd].Value.ToString();

					// ����TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_TelNo].Header.Caption).PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_TelNo].Value.ToString();

					// �Z��
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Address].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Address].Value.ToString();
				}

				Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
				ultraToolTipInfo.ToolTipTitle = "�d������";
				ultraToolTipInfo.ToolTipText = tipString;

				this.uToolTipManager_Information.Appearance.FontData.Name = "�l�r �S�V�b�N";
				this.uToolTipManager_Information.SetUltraToolTip(this.uGrid_Search, ultraToolTipInfo);
				this.uToolTipManager_Information.Enabled = true;

				return;
			}
		}

		/// <summary>
		/// �d���挟�����ʃO���b�h�G�������g�}�E�X���[���C�x���g
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
		/// �d���挟�����ʃO���b�h�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Search_Click(object sender, System.EventArgs e)
		{
			//
		}

		/// <summary>
		/// �A�N�e�B�u�^�C�}�[�N������
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_Activated_Tick(object sender, System.EventArgs e)
		{
			this.timer_Activated.Enabled = false;

			if (this.tEdit_CustomerFindCondition.Visible)
			{
				this.tEdit_CustomerFindCondition.Focus();
			}
			else if (this.tNedit_CustomerFindCondition.Visible)
			{
				this.tNedit_CustomerFindCondition.Focus();
			}
		}

		/// <summary>
		/// ���������R���{�G�f�B�^�l�ύX�㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Update Note: 2013/02/07 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// </remarks>
		private void tComboEditor_FindCondition_ValueChanged(object sender, System.EventArgs e)
		{
			if (!(sender is TComboEditor)) return;

			int mode = 0;

			TComboEditor tComboEditor = (TComboEditor)sender;

			if (tComboEditor.SelectedItem.DataValue is Int32)
			{
				mode = Convert.ToInt32(tComboEditor.SelectedItem.DataValue);
			}

			switch (mode)
			{
				// �d����J�i
				case EDIT_TYPE_Kana:
				{
					this.tEdit_CustomerFindCondition.Clear();
					this.tNedit_CustomerFindCondition.Clear();
					this.uLabel_CustomerFindCondition.Text = "";

					this.tEdit_CustomerFindCondition.Visible = true;
					this.tNedit_CustomerFindCondition.Visible = false;
					this.uLabel_CustomerFindCondition.Visible = true;

					this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;
                    /* ----- DEL ���N 2013/02/07 for Redmine#33741 ----->>>>>
					this.tEdit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
					this.tNedit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
                       ----- DEL ���N 2013/02/07 for Redmine#33741 -----<<<<< */
					this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
                    // ----- ADD ���N 2013/02/07 for Redmine#33741 ----->>>>>
                    this.tEdit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                    this.tNedit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                    // ----- ADD ���N 2013/02/07 for Redmine#33741 -----<<<<<

					// TEdit���̓v���p�e�B�h�ϊ�����
					this.TEditChangeEdit(this.tEdit_CustomerFindCondition, mode);
					break;
				}
				// �ڋq�R�[�h
				case EDIT_TYPE_SupplierCd:
				{
					this.tEdit_CustomerFindCondition.Clear();
					this.tNedit_CustomerFindCondition.Clear();
					this.uLabel_CustomerFindCondition.Text = "";

					this.tEdit_CustomerFindCondition.Visible = false;
					this.tNedit_CustomerFindCondition.Visible = true;
					this.uLabel_CustomerFindCondition.Visible = true;

					this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;
                    /* ----- DEL ���N 2013/02/07 for Redmine#33741 ----->>>>>
					this.tEdit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
					this.tNedit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
                       ----- DEL ���N 2013/02/07 for Redmine#33741 -----<<<<< */
                    this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
                    // ----- ADD ���N 2013/02/07 for Redmine#33741 ----->>>>>
                    this.tEdit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                    this.tNedit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                    // ----- ADD ���N 2013/02/07 for Redmine#33741 -----<<<<<

					// TNedit���̓v���p�e�B�h�ϊ�����
					this.TNeditChangeEdit(this.tNedit_CustomerFindCondition, mode);
					break;
				}
			}
		}

		/// <summary>
		/// ���o�������x���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uLabel_CustomerFindCondition_Click(object sender, System.EventArgs e)
		{
			if (this.tEdit_CustomerFindCondition.Visible)
			{
				this.tEdit_CustomerFindCondition.Focus();
			}
			else if (this.tNedit_CustomerFindCondition.Visible)
			{
				this.tNedit_CustomerFindCondition.Focus();
			}
		}

		/// <summary>
		/// ���o������������̓G�f�B�^�G���^�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tEdit_CustomerFindCondition_Enter(object sender, System.EventArgs e)
		{
			this.uLabel_CustomerFindCondition.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
		}

		/// <summary>
		/// ���o�������l���̓G�f�B�^�G���^�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tNedit_CustomerFindCondition_Enter(object sender, System.EventArgs e)
		{
			this.uLabel_CustomerFindCondition.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
			this.tNedit_CustomerFindCondition.Left = this.uLabel_CustomerFindCondition.Left + 1;
		}

		/// <summary>
		/// ���o������������̓G�f�B�^���[�u�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tEdit_CustomerFindCondition_Leave(object sender, System.EventArgs e)
		{
			this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;
		}

		/// <summary>
		/// ���o�������l���̓G�f�B�^���[�u�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tNedit_CustomerFindCondition_Leave(object sender, System.EventArgs e)
		{
			this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;


			if (this.tNedit_CustomerFindCondition.NormalAppearance.TextHAlign == Infragistics.Win.HAlign.Right)
			{
				int left = this.uLabel_CustomerFindCondition.Width - this.tNedit_CustomerFindCondition.Width;
				if (left > this.uLabel_CustomerFindCondition.Left)
				{
					this.tNedit_CustomerFindCondition.Left = left;
				}
			}
			else
			{
				this.tNedit_CustomerFindCondition.Left = this.uLabel_CustomerFindCondition.Left + 1;
			}
		}

		/// <summary>
		/// ���o�����R���{�G�f�B�^�T�C�Y�ύX�㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Update Note: 2013/02/07 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// </remarks>
		private void tComboEditor_CustomerFindCondition_SizeChanged(object sender, System.EventArgs e)
		{
            /* ----- DEL ���N 2013/02/07 for Redmine#33741 ----->>>>>
			if (this.tComboEditor_CustomerFindCondition.Width > this.tEdit_CustomerFindCondition.Width)
			{
				this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
			}
			else
			{
				this.uLabel_CustomerFindCondition.Width = this.tEdit_CustomerFindCondition.Width + 2;
			}
               ----- DEL ���N 2013/02/07 for Redmine#33741 ----->>>>> */
            // ----- ADD ���N 2013/02/07 for Redmine#33741 ----->>>>>
            this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
            this.tEdit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
            this.tNedit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
            // ----- ADD ���N 2013/02/07 for Redmine#33741 -----<<<<<
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

			if (objElement == null)
			{
				return;
			}

			element = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// �Z���ȊO�̏ꍇ�͈ȉ��̏������L�����Z������
			if (element == null)
			{
				return;
			}

			object oContextRow = null;

			oContextRow = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

			if (oContextRow == null)
			{
				return;
			}

			Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;

			Supplier supplierSearchRet = (Supplier)row.Cells[SEARCH_COL_CustomerSearchRet].Value;

			if (this.SupplierSelected != null)
			{
				this.SupplierSelected(this, supplierSearchRet.Clone());

				// �p�l���ύX�C�x���g�R�[������
				this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_CustomerLuncher);
			}
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
		/// ���b�Z�[�W��\���^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_MessageUnDisp_Tick(object sender, System.EventArgs e)
		{
			this.timer_MessageUnDisp.Enabled = false;

			this._customControl_ExtractWait.Visible = false;
		}
		# endregion
	}
}
