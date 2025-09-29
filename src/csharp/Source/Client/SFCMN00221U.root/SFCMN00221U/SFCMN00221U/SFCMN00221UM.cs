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
	/// ���Ӑ挟�����[�U�[�R���g���[���N���X
	/// </summary>
	internal partial class SFCMN00221UM : System.Windows.Forms.UserControl
	{
		// ===================================================================================== //
		// ���Ӑ挟���t�H�[���N���X�̃f�t�H���g�R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// ���Ӑ挟�����[�U�[�R���g���[���N���X�f�t�H���g�R���X�g���N�^
		/// </summary>
		public SFCMN00221UM(ControlScreenSkin controlScreenSkin)
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
		private const int EDIT_TYPE_Kana = 1;														// ���Ӑ�J�i
		private const int EDIT_TYPE_CustomerCode = 2;												// ���Ӑ�R�[�h
		private const int EDIT_TYPE_CustomerSubCode = 4;											// ���Ӑ�T�u�R�[�h
		private const int EDIT_TYPE_SearchTelNo = 6;												// �����d�b�ԍ�

		private const string SEARCH_TABLE = "CustomerSearchTable";
		internal const string SEARCH_COL_EnterpriseCode = "EnterpriseCode";							// ��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)
		internal const string SEARCH_COL_CustomerCode = "CustomerCode";								// ���Ӑ�R�[�h
		internal const string SEARCH_COL_CustomerSubCode = "CustomerSubCode";						// ���Ӑ�T�u�R�[�h
		internal const string SEARCH_COL_Name = "Name";												// ����
		internal const string SEARCH_COL_Name2 = "Name2";											// ���̂Q
		internal const string SEARCH_COL_HonorificTitle = "HonorificTitle";							// �h��
		internal const string SEARCH_COL_Kana = "Kana";												// �J�i
		internal const string SEARCH_COL_SearchTelNo = "SearchTelNo";								// �d�b�ԍ��i�����p��4���j
		internal const string SEARCH_COL_HomeTelNo = "HomeTelNo";									// �d�b�ԍ��i����j
		internal const string SEARCH_COL_OfficeTelNo = "OfficeTelNo";								// �d�b�ԍ��i�Ζ���j
		internal const string SEARCH_COL_PortableTelNo = "PortableTelNo";							// �d�b�ԍ��i�g�сj
		internal const string SEARCH_COL_PostNo = "PostNo";											// �X�֔ԍ�
		internal const string SEARCH_COL_Address1 = "Address1";										// �Z���P�i�s���{���s��S�E�����E���j
		internal const string SEARCH_COL_Address3 = "Address3";										// �Z���R�i�Ԓn�j
		internal const string SEARCH_COL_Address4 = "Address4";										// �Z���S�i�A�p�[�g���́j
		internal const string SEARCH_COL_Address = "Address";										// �Z��
		internal const string SEARCH_COL_SupplierSearchRet = "SupplierSearchRet";					// ���Ӑ挟�����ʃN���X
		private const string RECORD_KEY_SUPPLIER = "CustomerRecord";

		private const int DEFAULT_EDIT_WIDTH = 224;
		private const int GUIDE_WIDTH_DIFFERENCE = 26;

		private const string FILENAME_COLDISPLAYSTATUS = "SFCMN00221U_ColSetting3.DAT";				// ��\����ԃZ�b�e�B���OXML�t�@�C����
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

		/// <summary>���Ӑ�I����C�x���g</summary>
		internal event CustomerSelectedHandler CustomerSelected;
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
            if ( this.uGrid_Search.DataSource != null ) 
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

				this.tComboEditor_CustomerFindCondition.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.uButton_Find.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));

				this.tComboEditor_CustomerFindCondition.Value = EDIT_TYPE_Kana;

				// �C���[�W�A�C�R���ݒ菈��
				ImageList imglist = IconResourceManagement.ImageList16;

				// �O���b�h�̃t�H���g�T�C�Y��ݒ�
				this.tComboEditor_GridFontSize.Value = 11;

				// ���Ӑ挟�����ʃf�[�^�e�[�u���ݒ菈��
				this.SettingDataTable();

				// ���Ӑ挟�����ʃO���b�h�J�������ݒ菈��
				this.SettingGridColumns();

				this._isInitial = false;
			}

			// ���o�����^�C�g���ݒ�
			string dataType1 = "";
			string dataType2 = "";
			if (param.SupplierDiv == 1)
			{
				dataType1 = "�d����";
				dataType2 = "�d �� ��";
			}
			else
			{
				dataType1 = "���Ӑ�";
				dataType2 = "�� �� ��";
			}
			this.uLabel_CustomerTitle.Text = dataType1 + "���";
			this.uExplorerBar_Condition.Groups[RECORD_KEY_SUPPLIER].Text = dataType2 + " �� ��";
			this._customControl_ExtractWait.DataType = dataType1;
		}

		/// <summary>
		/// �p�l���A�N�e�B�u���\�b�h
		/// </summary>
		internal void PanelActivated()
		{
			this.timer_Activated.Enabled = true;
		}

		/// <summary>
		/// ���Ӑ��񌟍�����
		/// </summary>
		/// <param name="para">���Ӑ挟���p�����[�^</param>
		/// <param name="retArray">���Ӑ挟�����ʃN���X�z��</param>
		/// <returns>STATUS</returns>
		internal int Search(CustomerSearchPara para, out CustomerSearchRet[] retArray)
		{
			CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();

			// �����������s
			int status = customerSearchAcs.Serch(out retArray, para);

			return status;
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// ���Ӑ挟�����ʃf�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟�����ʃf�[�^�e�[�u����ݒ肵�܂��B</br>
		/// <br>Programer  : 980076  �Ȓ�  ����Y</br>
		/// <br>Date       : 2006.02.17</br>
		/// </remarks>
		private void SettingDataTable()
		{
			DataColumn enterpriseCodeColumn = new DataColumn(SEARCH_COL_EnterpriseCode, typeof(String), "", MappingType.Element);		// ��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)
			DataColumn customerCodeColumn = new DataColumn(SEARCH_COL_CustomerCode, typeof(Int32), "", MappingType.Element);			// ���Ӑ�R�[�h
			DataColumn customerSubCodeColumn = new DataColumn(SEARCH_COL_CustomerSubCode, typeof(String), "", MappingType.Element);		// ���Ӑ�T�u�R�[�h
			DataColumn nameColumn = new DataColumn(SEARCH_COL_Name, typeof(String), "", MappingType.Element);							// ����
			DataColumn name2Column = new DataColumn(SEARCH_COL_Name2, typeof(String), "", MappingType.Element);							// ���̂Q
			DataColumn honorificTitleColumn = new DataColumn(SEARCH_COL_HonorificTitle, typeof(String), "", MappingType.Element);		// �h��
			DataColumn kanaColumn = new DataColumn(SEARCH_COL_Kana, typeof(String), "", MappingType.Element);							// �J�i
			DataColumn searchTelNoColumn = new DataColumn(SEARCH_COL_SearchTelNo, typeof(String), "", MappingType.Element);				// �d�b�ԍ��i�����p��4���j
			DataColumn homeTelNoColumn = new DataColumn(SEARCH_COL_HomeTelNo, typeof(String), "", MappingType.Element);					// �d�b�ԍ��i����j
			DataColumn officeTelNoColumn = new DataColumn(SEARCH_COL_OfficeTelNo, typeof(String), "", MappingType.Element);				// �d�b�ԍ��i�Ζ���j
			DataColumn portableTelNoColumn = new DataColumn(SEARCH_COL_PortableTelNo, typeof(String), "", MappingType.Element);			// �d�b�ԍ��i�g�сj
			DataColumn postNoColumn = new DataColumn(SEARCH_COL_PostNo, typeof(String), "", MappingType.Element);						// �X�֔ԍ�
			DataColumn address1Column = new DataColumn(SEARCH_COL_Address1, typeof(String), "", MappingType.Element);					// �Z���P�i�s���{���s��S�E�����E���j
			DataColumn address3Column = new DataColumn(SEARCH_COL_Address3, typeof(String), "", MappingType.Element);					// �Z���R�i�Ԓn�j
			DataColumn address4Column = new DataColumn(SEARCH_COL_Address4, typeof(String), "", MappingType.Element);					// �Z���S�i�A�p�[�g���́j
			DataColumn addressColumn = new DataColumn(SEARCH_COL_Address, typeof(String), "", MappingType.Element);						// �Z���S�i�A�p�[�g���́j
			DataColumn customerSearchRetColumn = new DataColumn(SEARCH_COL_SupplierSearchRet, typeof(CustomerSearchRet), "", MappingType.Element);	// ���Ӑ挟�����ʃN���X

			// �f�[�^�Z�b�g�̏�����
			this.dataSet_CustomerSearch.Tables.AddRange(new DataTable[] { this._searchDataTable });

			// �f�[�^�e�[�u���̏�����
			this._searchDataTable.Columns.AddRange(new DataColumn[] {
																				    nameColumn,
																					name2Column,
																				    customerCodeColumn,
																					customerSubCodeColumn,
																				    kanaColumn,
																				    homeTelNoColumn,
																				    officeTelNoColumn,
																				    portableTelNoColumn,
																					postNoColumn,
																					address1Column,
																					//address2Column,
																					address3Column,
																					address4Column,
																					addressColumn,

																				    enterpriseCodeColumn,
																					honorificTitleColumn,
																					searchTelNoColumn,
																					customerSearchRetColumn
			});

			// ��L�[�ݒ�(���Ӑ挟���p�e�[�u���j
			DataColumn[] columns = new DataColumn[] {customerCodeColumn};
			this._searchDataTable.PrimaryKey = columns;

			// �\�[�g���ݒ�(���Ӑ挟���p�e�[�u���j�J�i�̏����Ƃ���
			this._searchDataView.Sort = SEARCH_COL_Kana + " DESC";
		}

		/// <summary>
		/// ���Ӑ挟���f�[�^�e�[�u���s�ǉ�����
		/// </summary>
		/// <param name="customerSearchRet">���Ӑ挟�����ʃN���X</param>
		/// <returns>�l���ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟�����ʃN���X���f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer  : 980076�@�Ȓ�  ����Y</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private void AddCustomerSearchTableRow(CustomerSearchRet customerSearchRet)
		{
			DataRow row = this._searchDataTable.NewRow();

			row[SEARCH_COL_EnterpriseCode] = customerSearchRet.EnterpriseCode;		// ��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)
			row[SEARCH_COL_CustomerCode] = customerSearchRet.CustomerCode;			// ���Ӑ�R�[�h
			row[SEARCH_COL_CustomerSubCode] = customerSearchRet.CustomerSubCode;		// ���Ӑ�T�u�R�[�h
			row[SEARCH_COL_Name] = customerSearchRet.Name;							// ����
			row[SEARCH_COL_Name2] = customerSearchRet.Name2;							// ���̂Q
			row[SEARCH_COL_HonorificTitle] = customerSearchRet.HonorificTitle;		// �h��
			row[SEARCH_COL_Kana] = customerSearchRet.Kana;							// �J�i
			row[SEARCH_COL_SearchTelNo] = customerSearchRet.SearchTelNo;				// �d�b�ԍ��i�����p��4���j
			row[SEARCH_COL_HomeTelNo] = customerSearchRet.HomeTelNo;					// �d�b�ԍ��i����j
			row[SEARCH_COL_OfficeTelNo] = customerSearchRet.OfficeTelNo;				// �d�b�ԍ��i�Ζ���j
			row[SEARCH_COL_PortableTelNo] = customerSearchRet.PortableTelNo;			// �d�b�ԍ��i�g�сj
			row[SEARCH_COL_PostNo] = customerSearchRet.PostNo;						// �X�֔ԍ�
			row[SEARCH_COL_Address1] = customerSearchRet.Address1;					// �Z���P�i�s���{���s��S�E�����E���j
			row[SEARCH_COL_Address3] = customerSearchRet.Address3;					// �Z���R�i�Ԓn�j
			row[SEARCH_COL_Address4] = customerSearchRet.Address4;					// �Z���S�i�A�p�[�g���́j
			row[SEARCH_COL_SupplierSearchRet] = customerSearchRet.Clone();		// ���Ӑ挟�����ʃN���X
			row[SEARCH_COL_Address] = 
				customerSearchRet.Address1 +
				// 2008.05.22 Update >>>
				//AddressConverter.CombineAddress(customerSearchRet.Address2, customerSearchRet.Address3) +
				customerSearchRet.Address3 +
				// 2008.05.22 Update <<<
				customerSearchRet.Address4;									// �Z��

			this._searchDataTable.Rows.Add(row);
		}

		/// <summary>
		/// ���Ӑ挟�����ʃO���b�h�J�������ݒ菈��
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
			columns[SEARCH_COL_Name].Header.Caption = "���Ӑ於";
			columns[SEARCH_COL_Name].Hidden = false;
			columns[SEARCH_COL_Name].CellAppearance.Cursor = Cursors.Hand;

			// ���Ӑ�R�[�h ��ݒ�
			columns[SEARCH_COL_CustomerCode].Header.Caption = "�R�[�h";
			columns[SEARCH_COL_CustomerCode].Hidden = false;
			columns[SEARCH_COL_CustomerCode].CellAppearance.Cursor = Cursors.Hand;
			columns[SEARCH_COL_CustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

			// ���Ӑ�T�u�R�[�h ��ݒ�
			columns[SEARCH_COL_CustomerSubCode].Header.Caption = "�T�u�R�[�h";
			columns[SEARCH_COL_CustomerSubCode].Hidden = false;
			columns[SEARCH_COL_CustomerSubCode].CellAppearance.Cursor = Cursors.Hand;

			// �J�i ��ݒ�
			columns[SEARCH_COL_Kana].Header.Caption = "�J�i";
			columns[SEARCH_COL_Kana].Hidden = false;
			columns[SEARCH_COL_Kana].CellAppearance.Cursor = Cursors.Hand;

			// ����TEL ��ݒ�
			columns[SEARCH_COL_HomeTelNo].Header.Caption = SFCMN00221UA.GetTelNoDspName(0);
			columns[SEARCH_COL_HomeTelNo].Hidden = false;
			columns[SEARCH_COL_HomeTelNo].CellAppearance.Cursor = Cursors.Hand;

			// �Ζ���TEL ��ݒ�
			columns[SEARCH_COL_OfficeTelNo].Header.Caption = SFCMN00221UA.GetTelNoDspName(1);
			columns[SEARCH_COL_OfficeTelNo].Hidden = false;
			columns[SEARCH_COL_OfficeTelNo].CellAppearance.Cursor = Cursors.Hand;

			// �g��TEL ��ݒ�
			columns[SEARCH_COL_PortableTelNo].Header.Caption = SFCMN00221UA.GetTelNoDspName(2);
			columns[SEARCH_COL_PortableTelNo].Hidden = false;
			columns[SEARCH_COL_PortableTelNo].CellAppearance.Cursor = Cursors.Hand;

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
				case EDIT_TYPE_CustomerSubCode:											// ���Ӑ�T�u�R�[�h
				{
					edit.CharacterCasing = CharacterCasing.Upper;
					edit.ExtEdit =
						new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
					edit.ImeMode = ImeMode.Off;
					break;
				}
				case EDIT_TYPE_Kana:													// ���Ӑ�J�i
				{
					edit.CharacterCasing = CharacterCasing.Normal;
					edit.ExtEdit =
						new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 21, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
					edit.ImeMode = ImeMode.Katakana;
					break;
				}
				case EDIT_TYPE_SearchTelNo:												// �����d�b�ԍ�
				{
					edit.CharacterCasing = CharacterCasing.Upper;
					edit.ExtEdit =
						new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
					edit.ImeMode = ImeMode.Off;
					break;
				}
			}
		}

		/// <summary>
		/// TNedit���̓��[�h�ϊ�����
		/// </summary>
		/// <param name="edit">�ύX����Edit�R���|�[�l���g</param>
		/// <param name="mode">���[�h</param>
		private void TNeditChangeEdit(Broadleaf.Library.Windows.Forms.TNedit nEdit, int mode)
		{
			switch (mode)
			{
				case EDIT_TYPE_CustomerCode:											// ���Ӑ�R�[�h
				{
					nEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
					nEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
					break;
				}
			}
		}

		/// <summary>
		/// ���Ӑ挟�������N���X�擾����
		/// </summary>
		private CustomerSearchPara GetCustomerSearchPara()
		{
			CustomerSearchPara para = new CustomerSearchPara();

			para.EnterpriseCode = this._enterpriseCode;									// ��ƃR�[�h

			// 2008.05.22 Del >>>
			//if (this._param != null)
			//{
			//    para.SupplierDiv = this._param.SupplierDiv;								// �d����敪
			//}
			// 2008.05.22 Del <<<

			int customerMode = Convert.ToInt32(this.tComboEditor_CustomerFindCondition.SelectedItem.DataValue);

			switch (customerMode)
			{
				// �ڋq�R�[�h
				case EDIT_TYPE_CustomerCode:
				{
					para.CustomerCode = this.tNedit_CustomerFindCondition.GetInt();
					break;
				}
				// ���Ӑ�T�u�R�[�h
				case EDIT_TYPE_CustomerSubCode:
				{
					para.CustomerSubCode = this.tEdit_CustomerFindCondition.Text.ToString();
					break;
				}
				// ���Ӑ�J�i
				case EDIT_TYPE_Kana:
				{
					para.Kana = this.tEdit_CustomerFindCondition.Text.ToString();
					break;
				}
				// �����d�b�ԍ�
				case EDIT_TYPE_SearchTelNo:
				{
					para.SearchTelNo = this.tEdit_CustomerFindCondition.Text.ToString();
					break;
				}
			}

			return para;
		}

		/// <summary>
		/// ���Ӑ挟������
		/// </summary>
		/// <param name="para">���Ӑ挟���p�����[�^�N���X</param>
		private void Search(CustomerSearchPara para)
		{
			// �O���b�h�̃t�B���^������
			this.uGrid_Search.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();

			// �f�[�^�e�[�u���̍s���N���A
			this._searchDataTable.Rows.Clear();

			this.uGrid_Search.Refresh();

			CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
			
			CustomerSearchRet[] customerSearchRetArray;

			// �����������s
			int status = customerSearchAcs.Serch(out customerSearchRetArray, para);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
				{
					this.AddCustomerSearchTableRow(customerSearchRet);
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
					"���Ӑ�̌����Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// ���Ӑ挟���p�����[�^�N���X�`�F�b�N����
		/// </summary>
		/// <param name="para">���Ӑ挟���p�����[�^�N���X</param>
		/// <returns>true:�`�F�b�N�n�j false:�`�F�b�N�m�f</returns>
		private bool CheckCustomerSearchPara(CustomerSearchPara para)
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

				// ���Ӑ挟�������N���X�擾����
				CustomerSearchPara para = this.GetCustomerSearchPara();

				// ���Ӑ挟���p�����[�^�N���X�`�F�b�N����
				if (!this.CheckCustomerSearchPara(para)) return;

				this._customControl_ExtractWait.Visible = true;
				this._customControl_ExtractWait.mode = 0;
				this._customControl_ExtractWait.Top = this.uGrid_Search.Top + 60;
				this._customControl_ExtractWait.Refresh();

				// ���Ӑ挟������
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
		/// ���Ӑ挟�����ʃO���b�h�G�������g�}�E�X�G���^�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Search_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			if ((this.ActiveControl != this.uGrid_Search) && (this.uGrid_Search.Rows.Count > 0))
			{
				this.uGrid_Search.Focus();
			}

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

				this.uGrid_Search.ActiveRow = row;
				this.uGrid_Search.ActiveRow.Selected = true;

				string tipString = "";

				if (row.Cells[0] != null)
				{
					int totalWidth = 6;

					// ���Ӑ於��
					tipString += this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Name].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Name].Value.ToString();

					// �J�i
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Kana].Value.ToString();

					// �R�[�h
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerCode].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_CustomerCode].Value.ToString();

					// �T�u�R�[�h
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerSubCode].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_CustomerSubCode].Value.ToString();

					// ����TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_HomeTelNo].Header.Caption).PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_HomeTelNo].Value.ToString();

					// �Ζ���TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_OfficeTelNo].Header.Caption).PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_OfficeTelNo].Value.ToString();

					// �g��TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_PortableTelNo].Header.Caption).PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_PortableTelNo].Value.ToString();

					// �Z��
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Address].Header.Caption.PadRight(totalWidth, '�@') + "�F" + row.Cells[SEARCH_COL_Address].Value.ToString();
				}

				Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
				ultraToolTipInfo.ToolTipTitle = "���Ӑ���";
				ultraToolTipInfo.ToolTipText = tipString;

				this.uToolTipManager_Information.Appearance.FontData.Name = "�l�r �S�V�b�N";
				this.uToolTipManager_Information.SetUltraToolTip(this.uGrid_Search, ultraToolTipInfo);
				this.uToolTipManager_Information.Enabled = true;

				return;
			}
		}

		/// <summary>
		/// ���Ӑ挟�����ʃO���b�h�G�������g�}�E�X���[���C�x���g
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
		/// ���Ӑ挟�����ʃO���b�h�N���b�N�C�x���g
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
				// ���Ӑ�J�i
				// ���Ӑ�T�u�R�[�h
				// �����d�b�ԍ�
				case EDIT_TYPE_Kana:
				case EDIT_TYPE_CustomerSubCode:
				case EDIT_TYPE_SearchTelNo:
				{
					this.tEdit_CustomerFindCondition.Clear();
					this.tNedit_CustomerFindCondition.Clear();
					this.uLabel_CustomerFindCondition.Text = "";

					this.tEdit_CustomerFindCondition.Visible = true;
					this.tNedit_CustomerFindCondition.Visible = false;
					this.uLabel_CustomerFindCondition.Visible = true;

					this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;

					this.tEdit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
					this.tNedit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
					this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;

					// TEdit���̓v���p�e�B�h�ϊ�����
					this.TEditChangeEdit(this.tEdit_CustomerFindCondition, mode);
					break;
				}
				// �ڋq�R�[�h
				case EDIT_TYPE_CustomerCode:
				{
					this.tEdit_CustomerFindCondition.Clear();
					this.tNedit_CustomerFindCondition.Clear();
					this.uLabel_CustomerFindCondition.Text = "";

					this.tEdit_CustomerFindCondition.Visible = false;
					this.tNedit_CustomerFindCondition.Visible = true;
					this.uLabel_CustomerFindCondition.Visible = true;

					this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;

					this.tEdit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
					this.tNedit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
					this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;

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
		private void tComboEditor_CustomerFindCondition_SizeChanged(object sender, System.EventArgs e)
		{
			if (this.tComboEditor_CustomerFindCondition.Width > this.tEdit_CustomerFindCondition.Width)
			{
				this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
			}
			else
			{
				this.uLabel_CustomerFindCondition.Width = this.tEdit_CustomerFindCondition.Width + 2;
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

			CustomerSearchRet customerSearchRet = (CustomerSearchRet)row.Cells[SEARCH_COL_SupplierSearchRet].Value;

			if (this.CustomerSelected != null)
			{
				this.CustomerSelected(this, customerSearchRet.Clone());

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
