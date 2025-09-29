using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���׃p�^�[���ҏW���
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������ς̖��׃p�^�[���ҏW�t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.07.03</br>
	/// <br>Update Note: </br>
	/// </remarks>
	public partial class PMMIT01019UE : Form
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public PMMIT01019UE()
		{
			InitializeComponent();

			this._searchType = 0;
			this._patternName = "";
			this._estimateDetailColInfoList = new List<EstmDtlColInfo>();
			this._estimateDetailColInfoDictionary = new Dictionary<string, EstmDtlColInfo>();
			this._controlScreenSkin = new ControlScreenSkin();

			DetailPatternSettingTable.CreateTable(ref this._colDataTable);
			this._colDataView = new DataView(this._colDataTable);
			this._colDataView.Sort = DetailPatternSettingTable.ctColName_RowNo;

			this._estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();

			this.uGrid_Detail.DataSource = this._colDataView;

			this.SettingColDataTableFromColDisplayBasicInfoList();
		}
		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private List<EstmDtlColInfo> _estimateDetailColInfoList;
		private Dictionary<string, EstmDtlColInfo> _estimateDetailColInfoDictionary;
		private EstmDtlPtnInfo.SearchType _searchType;
		private string _patternName;
		private DataTable _colDataTable;
		private DataView _colDataView;

		private EstimateInputConstructionAcs _estimateInputConstructionAcs;
		private ControlScreenSkin _controlScreenSkin;
        private DisplayType _displayType = DisplayType.New;

		private const string ctPrimeInfoKey = "_Prime";
		private const string ctPrimeInfoName = "�i�D�ǁj";

		#endregion


        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        #region ��Enum
        /// <summary>��ʃ^�C�v</summary>
        internal enum DisplayType : int
        {
            /// <summary>�V�K</summary>
            New = 0,
            /// <summary>�C��</summary>
            Revision = 1
        }
        #endregion

        // ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties

		/// <summary>���׏�񃊃X�g</summary>
		public List<EstmDtlColInfo> EstimateDetailColInfoList
		{
			get { return _estimateDetailColInfoList; }
			set 
			{ 
				this._estimateDetailColInfoList = value;
				this._estimateDetailColInfoDictionary = new Dictionary<string, EstmDtlColInfo>();
				if (this._estimateDetailColInfoList != null)
				{
					foreach (EstmDtlColInfo estimateDetailColInfo in this._estimateDetailColInfoList)
					{
						this._estimateDetailColInfoDictionary.Add(estimateDetailColInfo.Key, estimateDetailColInfo);
					}
				}
			}
		}

		/// <summary>�����^�C�v</summary>
		public EstmDtlPtnInfo.SearchType SearchType
		{
			get { return _searchType; }
			set { _searchType = value; }
		}

		/// <summary>���׃p�^�[����</summary>
		public string PatternName
		{
			get { return _patternName; }
			set { _patternName = value; }
		}

		#endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		#region �� Public Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="owner"></param>
        /// <param name="displayType"></param>
		/// <param name="patternName"></param>
		/// <param name="searchType"></param>
		/// <param name="estimateDetailColInfoList"></param>
		/// <returns></returns>
        internal DialogResult ShowDialog(IWin32Window owner, DisplayType displayType, string patternName, EstmDtlPtnInfo.SearchType searchType, List<EstmDtlColInfo> estimateDetailColInfoList)
		{
			this._patternName = patternName;
			this._searchType = searchType;
            this._displayType = displayType;

			this.EstimateDetailColInfoList = estimateDetailColInfoList;
			
			return this.ShowDialog(owner);
		}

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		#region �� Private Methods
		/// <summary>
		/// ���׍��ڃ��X�g���A�����e�[�u����ݒ肵�܂��B
		/// </summary>
		private void SettingColDataTableFromColDisplayBasicInfoList()
		{
			if (this._colDataTable == null)
			{
				DetailPatternSettingTable.CreateTable(ref this._colDataTable);
			}

			int no = 1;

			this._colDataTable.Rows.Clear();
			foreach (ColDisplayBasicInfo colDisplayBasicInfo in this._estimateInputConstructionAcs.ColDisplayBasicInfoList)
			{
				DataRow row = this._colDataTable.NewRow();
				row[DetailPatternSettingTable.ctColName_RowNo] = no;
				row[DetailPatternSettingTable.ctColName_Key] = colDisplayBasicInfo.Key;
				string colCaption = colDisplayBasicInfo.Caption;
				if (colDisplayBasicInfo.Key.Contains(ctPrimeInfoKey))
				{
					colCaption += ctPrimeInfoName;
				}
				row[DetailPatternSettingTable.ctColName_ColCaption] = colCaption;
				row[DetailPatternSettingTable.ctColName_VisiblePosition] = 99;
				row[DetailPatternSettingTable.ctColName_Visible] = false;
				row[DetailPatternSettingTable.ctColName_VisibleControl] = true;
				row[DetailPatternSettingTable.ctColName_FixedCol] = false;
				row[DetailPatternSettingTable.ctColName_EnterStop] = false;
				row[DetailPatternSettingTable.ctColName_ReadOnlyCol] = colDisplayBasicInfo.ReadOnly;
				no++;
				this._colDataTable.Rows.Add(row);
			}
		}

		/// <summary>
		/// �������@�ɏ]���āA���׃e�[�u���̊e���ڒl��ݒ肵�܂��B
		/// </summary>
		/// <param name="searchType">�������@</param>
		private void SettingColDataTableFromColDisplayAddInfoList( EstmDtlPtnInfo.SearchType searchType )
		{
            if (( this._colDataTable == null ) || ( this._colDataTable.Rows.Count == 0 ))
            {
                this.SettingColDataTableFromColDisplayBasicInfoList();
            }

            int visiblePosition = this._colDataTable.Rows.Count;
			List<ColDisplayAddInfo> colDisplayAddInfoList = null;

			if (this._estimateInputConstructionAcs.ColDisplayAddInfoDictionary.ContainsKey(searchType))
			{
				colDisplayAddInfoList = this._estimateInputConstructionAcs.ColDisplayAddInfoDictionary[searchType];
			}

			foreach (DataRow row in this._colDataTable.Rows)
			{
				ColDisplayAddInfo colDisplayAddInfo = null;

				if (( colDisplayAddInfoList == null ) || ( colDisplayAddInfoList.Count == 0 ))
				{
					row[DetailPatternSettingTable.ctColName_FixedCol] = false;
					row[DetailPatternSettingTable.ctColName_VisiblePosition] = 99;
					row[DetailPatternSettingTable.ctColName_Visible] = true;
					row[DetailPatternSettingTable.ctColName_VisibleControl] = true;
					row[DetailPatternSettingTable.ctColName_EnterStop] = false;
					row[DetailPatternSettingTable.ctColName_EnterStopControl] = false;
					row[DetailPatternSettingTable.ctColName_FixedColControl] = true;
				}
				else
				{
					foreach (ColDisplayAddInfo colDisplayAddInfoWk in colDisplayAddInfoList)
					{
						if ((string)row[DetailPatternSettingTable.ctColName_Key] == colDisplayAddInfoWk.Key)
						{
							colDisplayAddInfo = colDisplayAddInfoWk;
							break;
						}
					}
					if (colDisplayAddInfo != null)
					{
						row[DetailPatternSettingTable.ctColName_FixedCol] = colDisplayAddInfo.FixedCol;
						row[DetailPatternSettingTable.ctColName_Visible] = colDisplayAddInfo.Visible;
						row[DetailPatternSettingTable.ctColName_VisibleControl] = true;
						row[DetailPatternSettingTable.ctColName_VisiblePosition] = colDisplayAddInfo.VisiblePosition;
						row[DetailPatternSettingTable.ctColName_EnterStop] = colDisplayAddInfo.EnterStop;
						row[DetailPatternSettingTable.ctColName_EnterStopControl] = true;
						if (colDisplayAddInfo.FixedCol)
						{
							row[DetailPatternSettingTable.ctColName_VisibleControl] = false;
							row[DetailPatternSettingTable.ctColName_FixedColControl] = false;
							row[DetailPatternSettingTable.ctColName_EnterStopControl] = false;
						}
						else
						{
							row[DetailPatternSettingTable.ctColName_FixedColControl] = true;
						}
					}
                    else
                    {
                        row[DetailPatternSettingTable.ctColName_VisiblePosition] = visiblePosition;
                        row[DetailPatternSettingTable.ctColName_FixedColControl] = true;
                        if ((bool)row[DetailPatternSettingTable.ctColName_ReadOnlyCol])
                        {
                            row[DetailPatternSettingTable.ctColName_EnterStopControl] = false;
                        }
                        else
                        {
                            row[DetailPatternSettingTable.ctColName_EnterStopControl] = true;
                        }
                        visiblePosition++;
                    }
                    //else
                    //{
                    //    row[DetailPatternSettingTable.ctColName_VisiblePosition] = 99;
                    //    row[DetailPatternSettingTable.ctColName_Visible] = false;
                    //    row[DetailPatternSettingTable.ctColName_VisibleControl] = true;
                    //    row[DetailPatternSettingTable.ctColName_FixedCol] = false;
                    //    row[DetailPatternSettingTable.ctColName_EnterStop] = false;
                    //    row[DetailPatternSettingTable.ctColName_EnterStopControl] = true;
                    //    row[DetailPatternSettingTable.ctColName_FixedColControl] = true;
                    //}
				}
			}
			this.DetailPatternSettingTableRowNoReSetting();
		}

		/// <summary>
		/// ���׃p�^�[�����A�O���b�h�̊e�퍀�ڂ�ݒ肵�܂��B
		/// </summary>
		private void SettingColDataTableFromEstimateDetailColInfoList()
		{
			if (this._colDataTable == null)
			{
				this.SettingColDataTableFromColDisplayBasicInfoList();
			}

			this.SettingColDataTableFromColDisplayAddInfoList(this._searchType);

			if (this._estimateDetailColInfoDictionary != null)
			{

				foreach (DataRow row in this._colDataTable.Rows)
				{
                    if (this._estimateDetailColInfoDictionary.ContainsKey((string)row[DetailPatternSettingTable.ctColName_Key]))
                    {
                        EstmDtlColInfo estimateDetailColInfo = null;

                        estimateDetailColInfo = this._estimateDetailColInfoDictionary[(string)row[DetailPatternSettingTable.ctColName_Key]];

                        if (estimateDetailColInfo != null)
                        {
                            row[DetailPatternSettingTable.ctColName_VisiblePosition] = estimateDetailColInfo.VisiblePosition;
                            row[DetailPatternSettingTable.ctColName_Visible] = estimateDetailColInfo.Visible;
                            row[DetailPatternSettingTable.ctColName_FixedCol] = estimateDetailColInfo.FixedCol;
                            row[DetailPatternSettingTable.ctColName_EnterStop] = estimateDetailColInfo.EnterStop;
                        }
                        else
                        {
                            row[DetailPatternSettingTable.ctColName_VisiblePosition] = 99;
                            row[DetailPatternSettingTable.ctColName_Visible] = false;
                            row[DetailPatternSettingTable.ctColName_FixedCol] = false;
                            row[DetailPatternSettingTable.ctColName_EnterStop] = false;
                        }
                    }
                    else
                    {
                        row[DetailPatternSettingTable.ctColName_VisiblePosition] = 99;
                        row[DetailPatternSettingTable.ctColName_Visible] = false;
                        row[DetailPatternSettingTable.ctColName_FixedCol] = false;
                        row[DetailPatternSettingTable.ctColName_EnterStop] = false;
                    }
                }
			}
			this.DetailPatternSettingTableRowNoReSetting();
		}

		/// <summary>
		/// ���׃e�[�u���̍s����VisiblePosition����ɍĐݒ肵�܂��B
		/// </summary>
		private void DetailPatternSettingTableRowNoReSetting()
		{
			DataView dv = new DataView(this._colDataTable);

			dv.Sort = DetailPatternSettingTable.ctColName_VisiblePosition;

			int rowNo = 1;
			foreach (DataRowView drv in dv)
			{
				drv[DetailPatternSettingTable.ctColName_RowNo] = rowNo++;
			}

		}

		/// <summary>
		/// ���݂̖��׃p�^�[���ݒ胊�X�g���擾���܂��B
		/// </summary>
		/// <returns>���݂̖��׃p�^�[���ݒ胊�X�g</returns>
		private List<EstmDtlColInfo> GetCurrentEstimateDetailColInfoList()
		{
			List<EstmDtlColInfo> estimateDetailColInfoList = new List<EstmDtlColInfo>();

			int visiblePosition = 1;
			foreach (DataRowView drv in this._colDataView)
			{
				EstmDtlColInfo estimateDetailColInfo = new EstmDtlColInfo();
				estimateDetailColInfo.Key = (string)drv[DetailPatternSettingTable.ctColName_Key];
				estimateDetailColInfo.EnterStop = (bool)drv[DetailPatternSettingTable.ctColName_EnterStop];
				estimateDetailColInfo.FixedCol = (bool)drv[DetailPatternSettingTable.ctColName_FixedCol];
				estimateDetailColInfo.Visible = (bool)drv[DetailPatternSettingTable.ctColName_Visible];
				estimateDetailColInfo.VisiblePosition = visiblePosition++;

				estimateDetailColInfoList.Add(estimateDetailColInfo);
			}

			return estimateDetailColInfoList;
		}

		/// <summary>
		/// �O���b�h�Z���ݒ菈��
		/// </summary>
		private void SettingDetailControlGrid()
		{
			// �e�s���Ƃ̐ݒ�
			for (int i = 0; i < this.uGrid_Detail.Rows.Count; i++)
			{
				this.SettingDetailControlGridRow(i);
			}
		}

		/// <summary>
		/// �O���b�h�s�ݒ菈��
		/// </summary>
		/// <param name="rowIndex">�s�C���f�b�N�X</param>
		private void SettingDetailControlGridRow( int rowIndex )
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Detail.DisplayLayout.Bands[0];
			if (editBand == null) return;

			Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Detail.Rows[rowIndex];

			row.Cells[DetailPatternSettingTable.ctColName_Visible].Activation = ( (bool)row.Cells[DetailPatternSettingTable.ctColName_VisibleControl].Value ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.Disabled;
			row.Cells[DetailPatternSettingTable.ctColName_EnterStop].Activation = ( ( (bool)row.Cells[DetailPatternSettingTable.ctColName_EnterStopControl].Value ) && ( !(bool)row.Cells[DetailPatternSettingTable.ctColName_ReadOnlyCol].Value ) ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.Disabled;
			row.Cells[DetailPatternSettingTable.ctColName_FixedCol].Activation = ( (bool)row.Cells[DetailPatternSettingTable.ctColName_FixedColControl].Value ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.Disabled;
		}

		/// <summary>
		/// �����^�C�v�A�C�e���ݒ菈��
		/// </summary>
		/// <param name="itemDictionary">�A�C�e���f�B�N�V���i��</param>
		private void SetSearchTypeComboEditorItem( List<EstmDtlPtnInfo.SearchType> searchTypeList )
		{
			this.tComboEditor_SearchType.Items.Clear();
			int tag = 1;
			foreach (EstmDtlPtnInfo.SearchType searchType in searchTypeList)
			{
				Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
				item.Tag = item;
				item.DataValue = (int)searchType;
				item.DisplayText = EstmDtlPtnInfo.PartsSearchTypeName(searchType);
				this.tComboEditor_SearchType.Items.Add(item);
				tag++;
			}
		}

		/// <summary>
		/// �R���{�G�f�B�^�A�C�e���C���f�b�N�X�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
		/// <param name="dataValue">�ݒ�l</param>
		/// <param name="defaultIndex">�����l</param>
		private void SetComboEditorItemIndex( TComboEditor sender, int dataValue, int defaultIndex )
		{
			int index = defaultIndex;

			for (int i = 0; i < sender.Items.Count; i++)
			{
				if (( sender.Items[i].DataValue is int ) && ( (int)sender.Items[i].DataValue == dataValue ))
				{
					index = i;
					break;
				}
			}

			sender.SelectedIndex = index;

			if (( index == -1 ) && ( sender.DropDownStyle == Infragistics.Win.DropDownStyle.DropDown ))
			{
				sender.Text = dataValue.ToString();
			}
		}

		/// <summary>
		/// �R���{�G�f�B�^�I��l�擾����
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
		/// <returns>�I��l</returns>
		private int GetComboEditorValue( TComboEditor sender )
		{
			if (sender.SelectedIndex >= 0)
			{
				return (int)sender.SelectedItem.DataValue;
			}
			else
			{
				int index = -1;

				// ���l�݂̂����͂���Ă���ꍇ�́A���͒l��value���r����B
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
				if (regex.IsMatch(sender.Text.Trim()))
				{
					int dataValue = 0;

					try
					{
						dataValue = Convert.ToInt32(sender.Text.Trim());
					}
					catch (OverflowException)
					{
						// 
					}

					for (int i = 0; i < sender.Items.Count; i++)
					{
						if (( sender.Items[i].DataValue is int ) && ( (int)sender.Items[i].DataValue == dataValue ))
						{
							index = i;
							break;
						}
					}
				}

				// ��L�̔�r�ŊY���f�[�^�����݂��Ȃ������ꍇ�́A���͒l��DisplayText���r����B
				if (index == -1)
				{
					string selectText = sender.Text.Trim();

					for (int i = 0; i < sender.Items.Count; i++)
					{
						if (sender.Items[i].DisplayText.Trim() == selectText)
						{
							index = i;
							break;
						}
					}
				}

				// �Y���f�[�^�����݂��Ȃ��ꍇ��0�Ƃ���B
				if (index == -1)
				{
					return 0;
				}
				else
				{
					return (int)sender.Items[index].DataValue;
				}
			}
		}

		/// <summary>
		/// ���̓f�[�^�`�F�b�N����
		/// </summary>
		/// <returns>true:�`�F�b�NOK false:�`�F�b�NNG</returns>
		private bool InputDataCheck()
		{
			bool check = true;

			if (string.IsNullOrEmpty(this.tEdit_PatternName.Text.Trim()))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"���ו\���p�^�[��������͂��ĉ������B",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);


				this.tEdit_PatternName.Focus();
				check = false;
			}

			DataView dv = new DataView(this._colDataTable);
			dv.RowFilter = string.Format("{0}='{1}'", DetailPatternSettingTable.ctColName_Visible, true);
			if (dv.Count == 0)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�\�����鍀�ڂ�I�����ĉ������B",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);


				this.uGrid_Detail.Focus();
				check = false;
			}

			return check;
		}

		/// <summary>
		/// �s�ړ�����
		/// </summary>
		/// <param name="mode">0:��Ɉړ�,0�ȊO:���Ɉړ�</param>
		/// <param name="rowIndex">�Ώۍs�ԍ�</param>
		/// <returns></returns>
		private bool DetailFocusTableUpDownRow( int mode, int rowIndex)
		{
			if (this._colDataView[rowIndex] == null) return false;

			// �Ώۍs�̏����擾����
			string key = (string)this._colDataView[rowIndex][DetailPatternSettingTable.ctColName_Key];
			int no = (int)this._colDataView[rowIndex][DetailPatternSettingTable.ctColName_RowNo];
			int patternOrder = (int)this._colDataView[rowIndex][DetailPatternSettingTable.ctColName_RowNo];

			if (string.IsNullOrEmpty(key)) return false;

			string formatString = ( mode == 0 ) ? "{0}<{1}" : "{0}>{1}";
			string sortString = ( mode == 0 ) ? "{0} DESC" : "{0}";
			DataRow[] rows = this._colDataTable.Select(string.Format(formatString, DetailPatternSettingTable.ctColName_RowNo, no), string.Format(sortString, DetailPatternSettingTable.ctColName_RowNo));

			if (( rows != null ) && ( rows.Length > 0 ))
			{
				DetailFocusTableChangeRowNo(key, (int)rows[0][DetailPatternSettingTable.ctColName_RowNo]);
				DetailFocusTableChangeRowNo((string)rows[0][DetailPatternSettingTable.ctColName_Key], no);

			}
			return true;
		}

		/// <summary>
		/// �s�ԍ��ύX����
		/// </summary>
		/// <param name="key">�ΏۃL�[</param>
		/// <param name="no">�ύX����ԍ�</param>
		private void DetailFocusTableChangeRowNo( string key, int no)
		{
			DataView dv = new DataView(this._colDataTable);
			dv.RowFilter = string.Format("{0}='{1}'", DetailPatternSettingTable.ctColName_Key, key);

			if (dv.Count > 0)
			{
				dv[0][DetailPatternSettingTable.ctColName_RowNo] = no;
			}
		}

		#endregion

		// ===================================================================================== //
		// �e�R���g���[���̃C�x���g
		// ===================================================================================== //
		#region ��Control Events

		/// <summary>
		/// ��� Load�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void PMMIT01019UE_Load( object sender, EventArgs e )
		{
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			this.tEdit_PatternName.Text = this._patternName;

			this.SetSearchTypeComboEditorItem(EstmDtlPtnInfo.GetSearchTypeList());

			if (this._estimateDetailColInfoDictionary != null)
			{
				this.SettingColDataTableFromEstimateDetailColInfoList();
			}
			else
			{
				this.SettingColDataTableFromColDisplayAddInfoList(this._searchType);
			}

            this.tComboEditor_SearchType.SelectionChangeCommitted -= this.tComboEditor_SearchType_SelectionChangeCommitted;
			this.SetComboEditorItemIndex(this.tComboEditor_SearchType, (int)this._searchType, (int)EstmDtlPtnInfo.SearchType.Pure);
            this.tComboEditor_SearchType.SelectionChangeCommitted += this.tComboEditor_SearchType_SelectionChangeCommitted;

			this.SettingDetailControlGrid();

            if (this._displayType == DisplayType.New)
            {
                this._colDataTable.Rows.Clear();
                this.SettingColDataTableFromColDisplayAddInfoList(EstmDtlPtnInfo.SearchType.Pure);

                this.SettingDetailControlGrid();
            }
        }

		/// <summary>
		/// ��� Closing�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void PMMIT01019UE_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (this.DialogResult == DialogResult.Retry)
			{
				e.Cancel = true;
			}
		}

		/// <summary>
		/// ���׃O���b�h InitializeLayout�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_DetailPattern_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
		{
			Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Detail.DisplayLayout.Bands[0].Columns;

			// ��U�A�S�Ă̗���\���ɂ���B
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
			{
				//��\���ݒ�
				column.Hidden = true;
			}

			int visiblePosition = 0;

			//--------------------------------------------------------------------------------
			//  �\������J�������
			//--------------------------------------------------------------------------------

			this.uGrid_Detail.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

			// ��
			Columns[DetailPatternSettingTable.ctColName_RowNo].Header.Fixed = true;				// �Œ荀��
			Columns[DetailPatternSettingTable.ctColName_RowNo].Header.Caption = "��";
			Columns[DetailPatternSettingTable.ctColName_RowNo].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			Columns[DetailPatternSettingTable.ctColName_RowNo].CellAppearance.BackColor = this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.BackColor;
			Columns[DetailPatternSettingTable.ctColName_RowNo].CellAppearance.BackColor2 = this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.BackColor2;
			Columns[DetailPatternSettingTable.ctColName_RowNo].CellAppearance.BackGradientStyle = this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			Columns[DetailPatternSettingTable.ctColName_RowNo].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			Columns[DetailPatternSettingTable.ctColName_RowNo].CellAppearance.ForeColor = this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.ForeColor;
			Columns[DetailPatternSettingTable.ctColName_RowNo].CellAppearance.ForeColorDisabled = this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.ForeColor;

			Columns[DetailPatternSettingTable.ctColName_RowNo].Hidden = false;
			Columns[DetailPatternSettingTable.ctColName_RowNo].Width = 25;
			Columns[DetailPatternSettingTable.ctColName_RowNo].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			Columns[DetailPatternSettingTable.ctColName_RowNo].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			Columns[DetailPatternSettingTable.ctColName_RowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			Columns[DetailPatternSettingTable.ctColName_RowNo].CellAppearance.BackColor = this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.BackColor;
			Columns[DetailPatternSettingTable.ctColName_RowNo].Header.VisiblePosition = visiblePosition++;

			// ���ږ�
			Columns[DetailPatternSettingTable.ctColName_ColCaption].Header.Fixed = true;			// �Œ荀��
			Columns[DetailPatternSettingTable.ctColName_ColCaption].Header.Caption = "����";
			Columns[DetailPatternSettingTable.ctColName_ColCaption].Hidden = false;
			Columns[DetailPatternSettingTable.ctColName_ColCaption].Width = 100;
			Columns[DetailPatternSettingTable.ctColName_ColCaption].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			Columns[DetailPatternSettingTable.ctColName_ColCaption].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			Columns[DetailPatternSettingTable.ctColName_ColCaption].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			Columns[DetailPatternSettingTable.ctColName_ColCaption].Header.VisiblePosition = visiblePosition++;

			// �\���L��
			Columns[DetailPatternSettingTable.ctColName_Visible].Header.Fixed = false;				// �Œ荀��
			Columns[DetailPatternSettingTable.ctColName_Visible].Hidden = false;
			Columns[DetailPatternSettingTable.ctColName_Visible].Header.Caption = "�\��";
			Columns[DetailPatternSettingTable.ctColName_Visible].Width = 40;
			Columns[DetailPatternSettingTable.ctColName_Visible].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			Columns[DetailPatternSettingTable.ctColName_Visible].Header.VisiblePosition = visiblePosition++;

			// �Œ�
			Columns[DetailPatternSettingTable.ctColName_FixedCol].Header.Fixed = false;				// �Œ荀��
			Columns[DetailPatternSettingTable.ctColName_FixedCol].Hidden = false;
			Columns[DetailPatternSettingTable.ctColName_FixedCol].Header.Caption = "�Œ�";
			Columns[DetailPatternSettingTable.ctColName_FixedCol].Width = 40;
			Columns[DetailPatternSettingTable.ctColName_FixedCol].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			Columns[DetailPatternSettingTable.ctColName_FixedCol].Header.VisiblePosition = visiblePosition++;

			// �ړ��L��
			Columns[DetailPatternSettingTable.ctColName_EnterStop].Header.Fixed = false;			// �Œ荀��
			Columns[DetailPatternSettingTable.ctColName_EnterStop].Hidden = false;
			Columns[DetailPatternSettingTable.ctColName_EnterStop].Header.Caption = "�ړ�";
			Columns[DetailPatternSettingTable.ctColName_EnterStop].Width = 40;
			Columns[DetailPatternSettingTable.ctColName_EnterStop].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			Columns[DetailPatternSettingTable.ctColName_EnterStop].Header.VisiblePosition = visiblePosition++;


			// �Œ���؂���ݒ�
			this.uGrid_Detail.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.BackColor2;
		}

		/// <summary>
		/// �������@�R���{�G�f�B�^ SelectionChangeCommitted�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tComboEditor_SearchType_SelectionChangeCommitted( object sender, EventArgs e )
		{
			int searchType = this.GetComboEditorValue(this.tComboEditor_SearchType);

            this._colDataTable.Rows.Clear();
			this.SettingColDataTableFromColDisplayAddInfoList((EstmDtlPtnInfo.SearchType)searchType);

			this.SettingDetailControlGrid();
		}

		/// <summary>
		/// OK�{�^�� �N���b�N�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_Ok_Click( object sender, EventArgs e )
		{
			if (!this.InputDataCheck())
			{
				this.DialogResult = DialogResult.Retry;
				return;
			}

			this._patternName = this.tEdit_PatternName.Text.Trim();
			this._searchType = (EstmDtlPtnInfo.SearchType)this.GetComboEditorValue(this.tComboEditor_SearchType);
			this._estimateDetailColInfoList = this.GetCurrentEstimateDetailColInfoList();
		}

		/// <summary>
		/// ���{�^�� �N���b�N�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_UpDetailItem_Click( object sender, EventArgs e )
		{
			if (this.uGrid_Detail.ActiveRow != null)
			{
				uGrid_Detail.BeginUpdate();
				try
				{
					if (this.DetailFocusTableUpDownRow(0, this.uGrid_Detail.ActiveRow.Index))
					{
						this.uGrid_Detail.ActiveCell = null;
						this.uGrid_Detail.Rows[this.uGrid_Detail.ActiveRow.Index].Selected = true;
					}
				}
				finally
				{
					uGrid_Detail.EndUpdate();
				}
			}
		}

		/// <summary>
		/// ���{�^�� �N���b�N�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_DownDetailItem_Click( object sender, EventArgs e )
		{
			if (this.uGrid_Detail.ActiveRow != null)
			{
				uGrid_Detail.BeginUpdate();
				try
				{
					if (this.DetailFocusTableUpDownRow(1, this.uGrid_Detail.ActiveRow.Index))
					{
						this.uGrid_Detail.ActiveCell = null;
						this.uGrid_Detail.Rows[this.uGrid_Detail.ActiveRow.Index].Selected = true;
					}
				}
				finally
				{
					uGrid_Detail.EndUpdate();
				}
			}
		}

		/// <summary>
		/// �O���b�h�Z���A�b�v�f�[�g��C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Detail_AfterCellUpdate( object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e )
		{
			switch (e.Cell.Column.Key)
			{
				case DetailPatternSettingTable.ctColName_FixedCol:
					break;
				default:
					break;
			}

		}

		/// <summary>
		/// �O���b�h�}�E�X�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uGrid_Detail_MouseClick( object sender, MouseEventArgs e )
		{
			// �E�N���b�N�ȊO�̏ꍇ
			if (e.Button != MouseButtons.Left) return;

			System.Drawing.Point nowPos = new Point(e.X, e.Y);

			Infragistics.Win.UIElement objElement = this.uGrid_Detail.DisplayLayout.UIElement.ElementFromPoint(nowPos);

			// �N���b�N�ʒu����w�b�_�[������
			bool isColumnHeader = false;

			if (objElement != null)
			{
				if (( objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader ) ||
					( objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement ))
				{
					isColumnHeader = true;
				}
			}

			if (isColumnHeader)
			{
				// ��w�b�_�[�E�N���b�N���͉������Ȃ�
			}
			else
			{
				if ( this.uGrid_Detail.ActiveCell != null )
				{
					if (this.uGrid_Detail.ActiveCell.Column.Key == DetailPatternSettingTable.ctColName_FixedCol)
					{
						this.FixedChange(this.uGrid_Detail.ActiveCell.Row.Index);
					}
				}
			}
		}

		/// <summary>
		/// �Œ�s�I��ύX
		/// </summary>
		/// <param name="rowIndex"></param>
		private void FixedChange( int rowIndex )
		{
			bool select = (bool)this._colDataView[rowIndex][DetailPatternSettingTable.ctColName_FixedCol];
			int rowNo = (int)this._colDataView[rowIndex][DetailPatternSettingTable.ctColName_RowNo];
			DataView dv = new DataView(this._colDataTable);

			string filterString;
			if (select)
			{
				// �A�N�e�B�u�Z���̇��ȏ�̃Z���́u�Œ�v���O��
				filterString = string.Format("{0}>={1}", DetailPatternSettingTable.ctColName_RowNo, rowNo);
			}
			else
			{
				// �A�N�e�B�u�Z���̇��ȉ��̃Z���́u�Œ�v���`�F�b�N
				filterString = string.Format("{0}<={1}", DetailPatternSettingTable.ctColName_RowNo, rowNo);
			}
			dv.RowFilter = filterString;

			foreach (DataRowView drv in dv)
			{
				drv[DetailPatternSettingTable.ctColName_FixedCol] = !select;
			}
		}
		#endregion

		
		
	}
}