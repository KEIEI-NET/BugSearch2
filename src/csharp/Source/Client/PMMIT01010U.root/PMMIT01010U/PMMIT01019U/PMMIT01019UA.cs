using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;


using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 検索見積用ユーザー設定クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 検索見積用のユーザー設定フォームクラスです。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br>Update Note: </br>
    /// <br>2009.07.16 22018 鈴木 正臣 MANTIS[0013802] ＢＬコードガイドの初期表示モードを設定可能に変更。</br>
    /// <br>Update Note: 2011/02/14  鄧潘ハン</br>
    /// <br>             Redmine#19351 車種コードと車種呼称コードのフォーカス移動順位の対応</br>
    /// <br>Update Note: 2017/01/22 王飛</br>
    /// <br>管理番号   : 11270046-00</br>
    /// <br>           : Redmine#48967 車輌検索改良の対応</br>
    /// </remarks>
	public partial class EstimateInputSetup : Form
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2017/01/22 王飛</br>
        /// <br>管理番号    : 11270046-00</br>
        /// <br>            : Redmine#48967 車輌検索改良の対応</br>
        /// </remarks>
        public EstimateInputSetup()
		{
			InitializeComponent();

			// 変数初期化
			this._imageList16 = IconResourceManagement.ImageList16;
			this._stockSlipInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();
			this._controlScreenSkin = new ControlScreenSkin();

			// ヘッダ項目制御用
			this._headerFocusDataTable = new EstimateInputSetupDataSet.HeaderFocusDataTable();
			this._headerFocusView = this._headerFocusDataTable.DefaultView;
			this._headerFocusView.Sort = this._headerFocusDataTable.RowNoColumn.ColumnName;
			this._headerFocusConstructionList = new HeaderFocusConstructionList();
			this._headerItemsDictionary = new Dictionary<string, Control>();

			// 明細パターン制御用
			DetailPatternTable.CreateTable(ref this._detailPatternDataTable);
			this._detailPatternView = this._detailPatternDataTable.DefaultView;
			this._detailPatternView.Sort = DetailPatternTable.ctColName_RowNo;

			this.SetComboEditorItemIndex(this.tComboEditor_FocusPosition, this._stockSlipInputConstructionAcs.FocusPositionValue, 0);
			this.tNedit_DataInputCount.SetInt(this._stockSlipInputConstructionAcs.DataInputCountValue);
			this.SetComboEditorItemIndex(this.tComboEditor_FontSize, this._stockSlipInputConstructionAcs.FontSizeValue, 11);
			this.SetOptionSetItemIndex(this.uOptionSet_ShowEstimateInfo, this._stockSlipInputConstructionAcs.ShowEstimateInfoValue);
			this.SetOptionSetItemIndex(this.uOptionSet_ClearAfterSave, this._stockSlipInputConstructionAcs.ClearAfterSaveValue);
			this.SetOptionSetItemIndex(this.uOptionSet_DateClearAfterSave, this._stockSlipInputConstructionAcs.DateClearAfterSaveValue);
			this.SetOptionSetItemIndex(this.uOptionSet_SaveInfoStore, this._stockSlipInputConstructionAcs.SaveInfoStoreValue);
            this.SetComboEditorItemIndex(this.tComboEditor_FocusPositionAfterCarSearch, this._stockSlipInputConstructionAcs.FocusPositionAfterCarSearchValue, 2);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            this.SetComboEditorItemIndex( this.tComboEditor_BLGuideMode, this._stockSlipInputConstructionAcs.BLGuideModeValue, 0 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

			if (this.uTabControl_Setup.Tabs.Count > 1)
			{
				this.uTabControl_Setup.TabStop = true;
			}
			else
			{
				this.uTabControl_Setup.TabStop = false;
			}
            //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            this.ModelSelectionSetting = new PMKEN08020UF();
            this.ModelSelectionSetting.Deserialize();
            //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;
		private EstimateInputConstructionAcs _stockSlipInputConstructionAcs;
		private ControlScreenSkin _controlScreenSkin;

		private EstimateInputSetupDataSet.HeaderFocusDataTable _headerFocusDataTable;
		private HeaderFocusConstructionList _headerFocusConstructionList;
		private Dictionary<string, Control> _headerItemsDictionary;
		private DataView _headerFocusView = null;

		//private StockSlipInputSetupDataSet.DetailFocusDataTable _detailFocusDataTable = null;
		private DataTable _detailPatternDataTable;
		private DataView _detailPatternView = null;
        private PMKEN08020UF ModelSelectionSetting;// ADD 2017/01/22 王飛 Redmine#48967

		private const int ct_MaxDetailPattern = 20;

		/// <summary>DropHighLightのAppearance</summary>
		private const string CT_APPEARANCE_DROPHIGHLIGHT = "DropHighLightAppearance";
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Method
		/// <summary>
		/// コンボエディタアイテムインデックス設定処理
		/// </summary>
		/// <param name="sender">対象となるコンボエディタ</param>
		/// <param name="dataValue">設定値</param>
		/// <param name="defaultIndex">初期値</param>
		private void SetComboEditorItemIndex(TComboEditor sender, int dataValue, int defaultIndex)
		{
			int index = defaultIndex;

			for (int i = 0; i < sender.Items.Count; i++)
			{
				if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
				{
					index = i;
					break;
				}
			}

			sender.SelectedIndex = index;

			if ((index == -1) && (sender.DropDownStyle == Infragistics.Win.DropDownStyle.DropDown))
			{
				sender.Text = dataValue.ToString();
			}
		}

		/// <summary>
		/// オプションセットアイテムインデックス設定処理
		/// </summary>
		/// <param name="sender">対象となるオプションセット</param>
		/// <param name="dataValue">設定値</param>
		private void SetOptionSetItemIndex(Infragistics.Win.UltraWinEditors.UltraOptionSet sender, int dataValue)
		{
			int index = -1;
			for (int i = 0; i < sender.Items.Count; i++)
			{
				if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
				{
					index = i;
					break;
				}
			}

			sender.CheckedIndex = index;
		}

		/// <summary>
		/// オプションセット選択値取得処理
		/// </summary>
		/// <param name="sender">対象となるオプションセット</param>
		/// <returns>選択値</returns>
		private int GetOptionSetValue(Infragistics.Win.UltraWinEditors.UltraOptionSet sender)
		{
			if (sender.CheckedIndex >= 0)
			{
				return (int)sender.CheckedItem.DataValue;
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// コンボエディタ選択値取得処理
		/// </summary>
		/// <param name="sender">対象となるコンボエディタ</param>
		/// <returns>選択値</returns>
		private int GetComboEditorValue(TComboEditor sender)
		{
			if (sender.SelectedIndex >= 0)
			{
				return (int)sender.SelectedItem.DataValue;
			}
			else
			{
				int index = -1;

				// 数値のみが入力されている場合は、入力値とvalueを比較する。
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
						if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
						{
							index = i;
							break;
						}
					}
				}

				// 上記の比較で該当データが存在しなかった場合は、入力値とDisplayTextを比較する。
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

				// 該当データが存在しない場合は0とする。
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
		/// 入力データチェック処理
		/// </summary>
		/// <returns>true:チェックOK false:チェックNG</returns>
		private bool InputDataCheck()
		{
			bool check = true;

			if ((this.tNedit_DataInputCount.GetInt() <= 0) || (this.tNedit_DataInputCount.GetInt() > 999))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"入力行数は1から999の値を入力して下さい。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				this.tNedit_DataInputCount.Focus();
				check = false;
			}

			return check;
		}

		# region 明細項目制御
		/// <summary>
		/// 明細項目制御テーブル設定処理
		/// </summary>
		/// <param name="colDisplayInfoList"></param>
		/// <param name="detailPatternDataTable"></param>
		private void SettingDetailPatternDataTableFromEstimateDetailPatternInfoList( List<EstmDtlPtnInfo> estimateDetailPatternInfoList, ref DataTable detailPatternDataTable )
		{
			if (detailPatternDataTable == null)
			{
				DetailPatternTable.CreateTable(ref detailPatternDataTable);
			}

			detailPatternDataTable.Rows.Clear();

			SortedDictionary<int, EstmDtlPtnInfo> sortedEstimateDetailPatternInfoList = new SortedDictionary<int, EstmDtlPtnInfo>();

			// 一旦、表示順にソートする
			foreach (EstmDtlPtnInfo estimateDetailPatternInfo in estimateDetailPatternInfoList)
			{
				sortedEstimateDetailPatternInfoList.Add(estimateDetailPatternInfo.PatternOrder, estimateDetailPatternInfo);
			}

			int no = 1;
			foreach (EstmDtlPtnInfo estimateDetailPatternInfo in sortedEstimateDetailPatternInfoList.Values)
			{
				DataRow row = detailPatternDataTable.NewRow();
				DetailPatternRowFromEstimateDetailPatternInfo(no, estimateDetailPatternInfo, ref row);
				detailPatternDataTable.Rows.Add(row);
				no++;
			}
		}

		/// <summary>
		/// 明細パターンテーブル行番号再設定
		/// </summary>
		private void DetailPatternTableReSetRowNo( )
		{
			int rowNo = 1;
			foreach (DataRowView drv in this._detailPatternView)
			{
				drv[DetailPatternTable.ctColName_RowNo] = rowNo++;
			}
		}

		/// <summary>
		/// 列表示情報テーブルからリストを生成します。
		/// </summary>
		/// <param name="list"></param>
		/// <param name="dataTable"></param>
		private List<EstmDtlPtnInfo> GetCurrentEstimateDetailPatternInfoList()
		{
			List<EstmDtlPtnInfo> estimateDetailPatternInfoList = new List<EstmDtlPtnInfo>();

			int patternOrder = 1;
			foreach (DataRowView drv in this._detailPatternView)
			{
				EstmDtlPtnInfo estimateDetailPatternInfo = new EstmDtlPtnInfo();
				estimateDetailPatternInfo.PatternOrder = patternOrder++;
				estimateDetailPatternInfo.PatternGuid = (Guid)drv[DetailPatternTable.ctColName_PatternGuid];
				estimateDetailPatternInfo.PatternName = (string)drv[DetailPatternTable.ctColName_PatternName];
				estimateDetailPatternInfo.PartsSearchType = (EstmDtlPtnInfo.SearchType)drv[DetailPatternTable.ctColName_SearchMode];
				estimateDetailPatternInfo.EstimateDetailColInfoList = (List<EstmDtlColInfo>)drv[DetailPatternTable.ctColName_EstimateDetailColInfoList];

				estimateDetailPatternInfoList.Add(estimateDetailPatternInfo);
			}

			return estimateDetailPatternInfoList;
		}

		/// <summary>
		/// 行移動処理
		/// </summary>
		/// <param name="mode">0:上に移動,0以外:下に移動</param>
		/// <param name="rowIndex">対象行番号</param>
		/// <returns></returns>
		private bool DetailFocusTableUpDownRow( int mode, int rowIndex)
		{
			if (this._detailPatternView[rowIndex] == null) return false;

			// 対象行の情報を取得する
			Guid guid = (Guid)this._detailPatternView[rowIndex][DetailPatternTable.ctColName_PatternGuid];
			int no = (int)this._detailPatternView[rowIndex][DetailPatternTable.ctColName_RowNo];
			int patternOrder = (int)this._detailPatternView[rowIndex][DetailPatternTable.ctColName_PatternOrder];

			if (guid == Guid.Empty) return false;

			string formatString = ( mode == 0 ) ? "{0}<{1}" : "{0}>{1}";
			string sortString = ( mode == 0 ) ? "{0} DESC" : "{0}";
			DataRow[] rows = this._detailPatternDataTable.Select(string.Format(formatString, DetailPatternTable.ctColName_RowNo, no), string.Format(sortString, DetailPatternTable.ctColName_RowNo));

			if (( rows != null ) && ( rows.Length > 0 ))
			{
				DetailFocusTableChangeRowNo(guid, (int)rows[0][DetailPatternTable.ctColName_RowNo], (int)rows[0][DetailPatternTable.ctColName_PatternOrder]);
				DetailFocusTableChangeRowNo((Guid)rows[0][DetailPatternTable.ctColName_PatternGuid], no, patternOrder);

			}
			return true;
		}

		/// <summary>
		/// 行番号変更処理
		/// </summary>
		/// <param name="key">対象キー</param>
		/// <param name="no">変更する番号</param>
		/// <param name="patternOrder">列表示位置</param>
		private void DetailFocusTableChangeRowNo( Guid guid, int no, int patternOrder )
		{
			DataView dv = new DataView(this._detailPatternDataTable);
			dv.RowFilter = string.Format("{0}='{1}'", DetailPatternTable.ctColName_PatternGuid, guid);

			if (dv.Count > 0)
			{
				dv[0][DetailPatternTable.ctColName_RowNo] = no;
				dv[0][DetailPatternTable.ctColName_PatternOrder] = patternOrder;
			}
		}

		# endregion

		# region ヘッダ項目制御
		/// <summary>
		/// ヘッダ項目制御リスト設定処理(Dictionary)
		/// </summary>
		/// <param name="headerItemsDictionary"></param>
		private void SettingHeaderFocusConstructionListFromDictionary( Dictionary<string, Control> headerItemsDictionary, ref List<HeaderFocusConstruction> headerFocusConstructionList )
		{
			int index = 0;
			SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
			foreach (string key in headerItemsDictionary.Keys)
			{
				Control control = headerItemsDictionary[key];
				sortedDictionary.Add(index, key);
				index++;
			}

			//List<HeaderFocusConstruction> headerFocusConstructionList = this._headerFocusConstructionList.headerFocusConstruction;
			foreach (int keyIndex in sortedDictionary.Keys)
			{
				string key = sortedDictionary[keyIndex];
				HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
				Control control = headerItemsDictionary[key];
				headerFocusConstruction.Key = control.Name;
				headerFocusConstruction.Caption = key;
				headerFocusConstruction.EnterStop = true;
				headerFocusConstructionList.Add(headerFocusConstruction);
			}
			this._headerFocusConstructionList.headerFocusConstruction = headerFocusConstructionList;
		}

		/// <summary>
		/// ヘッダ項目設定処理(DataTable)
		/// </summary>
		/// <param name="headerFocusDataTableDataTable"></param>
        private void SettingHeaderFocusConstructionListFromDataTable( EstimateInputSetupDataSet.HeaderFocusDataTable headerFocusDataTable )
		{
			List<HeaderFocusConstruction> headerFocusConstructionList = new List<HeaderFocusConstruction>();
			DataRow[] rows = headerFocusDataTable.Select("", string.Format("{0}", headerFocusDataTable.RowNoColumn.ColumnName));
            foreach (EstimateInputSetupDataSet.HeaderFocusRow row in rows)
			{
				HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
				headerFocusConstruction.Key = row.Key;
                // --- UPD 2011/02/14 ---------->>>>>
                //headerFocusConstruction.Caption = row.DisplayName;
                switch (row.DisplayName)
                {
                    case "車種コード":
                        headerFocusConstruction.Caption = "車種呼称コード";
                        break;
                    case "車種呼称コード":
                        headerFocusConstruction.Caption = "車種コード";
                        break;
                    default:
                        headerFocusConstruction.Caption = row.DisplayName;
                        break;
                }
                // --- UPD 2011/02/14 ----------<<<<<
				headerFocusConstruction.EnterStop = row.CanMove;
				headerFocusConstructionList.Add(headerFocusConstruction);
			}
			this._headerFocusConstructionList.headerFocusConstruction = headerFocusConstructionList;
		}
		/// <summary>
		/// 明細データテーブル設定処理
		/// </summary>
		/// <param name="headerFocusConstructionList"></param>
		private void SettingDataTableFromHeaderFocusConstructionList( HeaderFocusConstructionList headerFocusConstructionList )
		{
			int rowNo = 1;
			this._headerFocusDataTable.Clear();
			this._headerFocusDataTable.DefaultView.Sort = this._headerFocusDataTable.RowNoColumn.ColumnName;

			foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
			{
                EstimateInputSetupDataSet.HeaderFocusRow row = this._headerFocusDataTable.NewHeaderFocusRow();
				row.RowNo = rowNo;
				row.Key = headerFocusConstruction.Key;
                // --- UPD 2011/02/14 ---------->>>>>
                //row.DisplayName = headerFocusConstruction.Caption;
                switch (headerFocusConstruction.Caption)
                {
                    case "車種コード":
                        row.DisplayName = "車種呼称コード";
                        break;
                    case "車種呼称コード":
                        row.DisplayName = "車種コード";
                        break;
                    default:
                        row.DisplayName = headerFocusConstruction.Caption;
                        break;
                }
                // --- UPD 2011/02/14 ----------<<<<<
				row.CanMove = headerFocusConstruction.EnterStop;
				this._headerFocusDataTable.AddHeaderFocusRow(row);
				rowNo++;
			}
		}

		/// <summary>
		/// 行移動処理
		/// </summary>
		/// <param name="mode">0:上に移動,0以外:下に移動</param>
		/// <param name="rowIndex">対象行番号</param>
		/// <returns></returns>
		private bool HeaderFocusTableUpDownRow( int mode, int rowIndex )
		{
			if (this._headerFocusView[rowIndex] == null) return false;

			// 対象行の情報を取得する
			string key = (string)this._headerFocusView[rowIndex][this._headerFocusDataTable.KeyColumn.ColumnName];
			int no = (int)this._headerFocusView[rowIndex][this._headerFocusDataTable.RowNoColumn.ColumnName];

			if (no == 0) return false;

			string formatString = ( mode == 0 ) ? "{0}<{1}" : "{0}>{1}";
			string sortString = ( mode == 0 ) ? "{0} DESC" : "{0}";

			DataRow[] rows = this._headerFocusDataTable.Select(string.Format(formatString, this._headerFocusDataTable.RowNoColumn.ColumnName, no), string.Format(sortString, this._headerFocusDataTable.RowNoColumn.ColumnName));

			if (( rows != null ) && ( rows.Length > 0 ))
			{
				HeaderFocusTableChangeRowNo(key, (int)rows[0][this._headerFocusDataTable.RowNoColumn.ColumnName]);
				HeaderFocusTableChangeRowNo((string)rows[0][this._headerFocusDataTable.KeyColumn.ColumnName], no);
			}
			return true;
		}

		/// <summary>
		/// 行番号変更処理
		/// </summary>
		/// <param name="key">対象キー</param>
		/// <param name="no">変更する番号</param>
		/// <param name="visiblePosition">列表示位置</param>
		private void HeaderFocusTableChangeRowNo( string key, int no )
		{
			DataRow[] rows = this._headerFocusDataTable.Select(string.Format("{0}='{1}'", this._headerFocusDataTable.KeyColumn.ColumnName, key));
			if (rows != null)
			{
				rows[0][this._headerFocusDataTable.RowNoColumn.ColumnName] = no;
			}
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// 各種コンポーネントイベント処理郡
		// ===================================================================================== //
		# region Event Methods
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note : 2017/01/22 王飛</br>
        /// <br>管理番号    : 11270046-00</br>
        /// <br>            : Redmine#48967 車輌検索改良の対応</br>
        /// </remarks>
		private void EstimateInputSetup_Load(object sender, EventArgs e)
		{
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
			
			this.uButton_Ok.ImageList = this._imageList16;
			this.uButton_Cancel.ImageList = this._imageList16;

			this.uButton_Ok.Appearance.Image = (int)Size16_Index.DECISION;
			this.uButton_Cancel.Appearance.Image = (int)Size16_Index.BEFORE;


			//------------------------------------------------------
			// ヘッダ項目制御
			//------------------------------------------------------
			this._headerFocusView = this._headerFocusDataTable.DefaultView;
			this.uGrid_HeaderControl.DataSource = this._headerFocusView;
			// グリッドキーマッピング設定処理
			this._headerFocusConstructionList = this._stockSlipInputConstructionAcs.HeaderFocusConstructionListValue;
			this._headerItemsDictionary = this._stockSlipInputConstructionAcs.HeaderItemsDictionary;
			if (this._headerFocusConstructionList.headerFocusConstruction.Count == 0)
			{
				this.SettingHeaderFocusConstructionListFromDictionary(this._headerItemsDictionary, ref this._headerFocusConstructionList.headerFocusConstruction);
			}
			this.SettingDataTableFromHeaderFocusConstructionList(this._headerFocusConstructionList);

			//------------------------------------------------------
			// 明細項目制御
			//------------------------------------------------------
			this.SettingDetailPatternDataTableFromEstimateDetailPatternInfoList(this._stockSlipInputConstructionAcs.EstimateDetailPatternInfoList, ref this._detailPatternDataTable);
			this.uGrid_DetailPattern.DataSource = this._detailPatternView;

            //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            if (this.ModelSelectionSetting != null
                && this.ModelSelectionSetting.SettingItemInfo != null)
            {
                this.tComboEditor_FocusPositionDiv.SelectedIndex = this.ModelSelectionSetting.SettingItemInfo.FocusPositionDiv;
                this.tComboEditor_EnterActionDiv.SelectedIndex = this.ModelSelectionSetting.SettingItemInfo.EnterActionDiv;
            }
            //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<

			this.timer_Initial.Enabled = true;
		}
		/// <summary>
		/// Control.Click イベント(uButton_Ok)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note : 2017/01/22 王飛</br>
        /// <br>管理番号    : 11270046-00</br>
        /// <br>            : Redmine#48967 車輌検索改良の対応</br>
        /// </remarks>
		private void uButton_Ok_Click(object sender, EventArgs e)
		{
			if (!this.InputDataCheck())
			{
				this.DialogResult = DialogResult.Retry;
				return;
			}

			this._stockSlipInputConstructionAcs.FocusPositionValue = this.GetComboEditorValue(this.tComboEditor_FocusPosition);
			this._stockSlipInputConstructionAcs.ShowEstimateInfoValue = this.GetOptionSetValue(this.uOptionSet_ShowEstimateInfo);
			this._stockSlipInputConstructionAcs.DataInputCountValue = this.tNedit_DataInputCount.GetInt();
			this._stockSlipInputConstructionAcs.FontSizeValue = this.GetComboEditorValue(this.tComboEditor_FontSize);
			this._stockSlipInputConstructionAcs.ClearAfterSaveValue = this.GetOptionSetValue(this.uOptionSet_ClearAfterSave);
			this._stockSlipInputConstructionAcs.DateClearAfterSaveValue = this.GetOptionSetValue(this.uOptionSet_DateClearAfterSave);
			this._stockSlipInputConstructionAcs.SaveInfoStoreValue = this.GetOptionSetValue(this.uOptionSet_SaveInfoStore);
            this._stockSlipInputConstructionAcs.FocusPositionAfterCarSearchValue = this.GetComboEditorValue(this.tComboEditor_FocusPositionAfterCarSearch);
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            this._stockSlipInputConstructionAcs.BLGuideModeValue = this.GetComboEditorValue( this.tComboEditor_BLGuideMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

			// ヘッダ項目制御
			this.SettingHeaderFocusConstructionListFromDataTable(this._headerFocusDataTable);
			this._stockSlipInputConstructionAcs.HeaderFocusConstructionListValue = this._headerFocusConstructionList;

			// 明細項目制御
			this._stockSlipInputConstructionAcs.EstimateDetailPatternInfoList = this.GetCurrentEstimateDetailPatternInfoList();

			this._stockSlipInputConstructionAcs.Serialize();
            //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            if (this.ModelSelectionSetting != null
                && this.ModelSelectionSetting.SettingItemInfo != null)
            {
                this.ModelSelectionSetting.SettingItemInfo.FocusPositionDiv = this.tComboEditor_FocusPositionDiv.SelectedIndex;
                this.ModelSelectionSetting.SettingItemInfo.EnterActionDiv = this.tComboEditor_EnterActionDiv.SelectedIndex;
                this.ModelSelectionSetting.Serialize();
            }
            //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<
		}

		/// <summary>
		/// 初期処理タイマー起動処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Initial_Tick(object sender, EventArgs e)
		{
			this.timer_Initial.Enabled = false;

			//this.SettingDetailControlGrid();

			this.tComboEditor_FocusPosition.Focus();
		}

		/// <summary>
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void EstimateInputSetup_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.Retry)
			{
				e.Cancel = true;
			}
		}

		# region ヘッダ項目制御画面関連
		/// <summary>
		/// ヘッダ制御グリッド InitializeLayoutイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_HeaderControl_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
		{
			Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_HeaderControl.DisplayLayout.Bands[0].Columns;

			// 一旦、全ての列を非表示にする。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
			{
				//非表示設定
				column.Hidden = true;
			}

			int visiblePosition = 0;

			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------

			this.uGrid_HeaderControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

			// №
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Hidden = false;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Width = 25;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
			Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			// 項目名
			Columns[this._headerFocusDataTable.DisplayNameColumn.ColumnName].Header.Fixed = true;				// 固定項目
			Columns[this._headerFocusDataTable.DisplayNameColumn.ColumnName].Hidden = false;
			Columns[this._headerFocusDataTable.DisplayNameColumn.ColumnName].Width = 100;
			Columns[this._headerFocusDataTable.DisplayNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			Columns[this._headerFocusDataTable.DisplayNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			Columns[this._headerFocusDataTable.DisplayNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			Columns[this._headerFocusDataTable.DisplayNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			// 移動有無
			Columns[this._headerFocusDataTable.CanMoveColumn.ColumnName].Header.Fixed = false;				// 固定項目
			Columns[this._headerFocusDataTable.CanMoveColumn.ColumnName].Hidden = false;
			Columns[this._headerFocusDataTable.CanMoveColumn.ColumnName].Width = 40;
			Columns[this._headerFocusDataTable.CanMoveColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			Columns[this._headerFocusDataTable.CanMoveColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			// 固定列区切り線設定
			this.uGrid_HeaderControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
		}

		/// <summary>
		/// ▲ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_UpHeaderItem_Click( object sender, EventArgs e )
		{
			if (this.uGrid_HeaderControl.ActiveRow != null)
			{
				uGrid_HeaderControl.BeginUpdate();
				try
				{
					if (this.HeaderFocusTableUpDownRow(0, this.uGrid_HeaderControl.ActiveRow.Index))
					{
						this.uGrid_HeaderControl.ActiveCell = this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Cells[this._headerFocusDataTable.CanMoveColumn.ColumnName];
						this.uGrid_HeaderControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
						this.uGrid_HeaderControl.ActiveCell = null;
						this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Selected = true;
					}
				}
				finally
				{
					uGrid_HeaderControl.EndUpdate();
				}
			}
		}

		/// <summary>
		/// ▼ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_DownHeaderItem_Click( object sender, EventArgs e )
		{
			if (this.uGrid_HeaderControl.ActiveRow != null)
			{
				uGrid_HeaderControl.BeginUpdate();
				try
				{
					if (this.HeaderFocusTableUpDownRow(1, this.uGrid_HeaderControl.ActiveRow.Index))
					{
						this.uGrid_HeaderControl.ActiveCell = this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Cells[this._headerFocusDataTable.CanMoveColumn.ColumnName];
						this.uGrid_HeaderControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
						this.uGrid_HeaderControl.ActiveCell = null;
						this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Selected = true;
					}
				}
				finally
				{
					uGrid_HeaderControl.EndUpdate();
				}
			}
		}

		/// <summary>
		/// 初期値に戻す
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_HeaderFocusUndo_Click( object sender, EventArgs e )
		{
			this._headerFocusConstructionList.headerFocusConstruction.Clear();
			this.SettingHeaderFocusConstructionListFromDictionary(this._headerItemsDictionary, ref this._headerFocusConstructionList.headerFocusConstruction);
			this.SettingDataTableFromHeaderFocusConstructionList(this._headerFocusConstructionList);
			this._headerFocusView = this._headerFocusDataTable.DefaultView;
			this.uGrid_HeaderControl.DataSource = this._headerFocusView;
		}
		# endregion

		#region 明細制御グリッド関連
		/// <summary>
		/// InitializeLayoutイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_DetailPattern_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
		{
			Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_DetailPattern.DisplayLayout.Bands[0].Columns;

			// 一旦、全ての列を非表示にする。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
			{
				//非表示設定
				column.Hidden = true;
			}

			int visiblePosition = 0;

			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------

			this.uGrid_DetailPattern.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

			// №
			Columns[DetailPatternTable.ctColName_RowNo].Header.Fixed = true;				// 固定項目
			Columns[DetailPatternTable.ctColName_RowNo].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			Columns[DetailPatternTable.ctColName_RowNo].CellAppearance.BackColor = this.uGrid_DetailPattern.DisplayLayout.Override.HeaderAppearance.BackColor;
			Columns[DetailPatternTable.ctColName_RowNo].CellAppearance.BackColor2 = this.uGrid_DetailPattern.DisplayLayout.Override.HeaderAppearance.BackColor2;
			Columns[DetailPatternTable.ctColName_RowNo].CellAppearance.BackGradientStyle = this.uGrid_DetailPattern.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			Columns[DetailPatternTable.ctColName_RowNo].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			Columns[DetailPatternTable.ctColName_RowNo].CellAppearance.ForeColor = this.uGrid_DetailPattern.DisplayLayout.Override.HeaderAppearance.ForeColor;
			Columns[DetailPatternTable.ctColName_RowNo].CellAppearance.ForeColorDisabled = this.uGrid_DetailPattern.DisplayLayout.Override.HeaderAppearance.ForeColor;


			Columns[DetailPatternTable.ctColName_RowNo].Hidden = false;
			Columns[DetailPatternTable.ctColName_RowNo].Header.Caption = "№";
			Columns[DetailPatternTable.ctColName_RowNo].Width = 25;
			Columns[DetailPatternTable.ctColName_RowNo].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			Columns[DetailPatternTable.ctColName_RowNo].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			Columns[DetailPatternTable.ctColName_RowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			Columns[DetailPatternTable.ctColName_RowNo].CellAppearance.BackColor = this.uGrid_DetailPattern.DisplayLayout.Override.HeaderAppearance.BackColor;

			//Columns[ColDisplayInfo.ct_Col_No].AutoEdit = true;
			Columns[DetailPatternTable.ctColName_RowNo].Header.VisiblePosition = visiblePosition++;

			// 項目名
			Columns[DetailPatternTable.ctColName_PatternName].Header.Fixed = true;			// 固定項目
			Columns[DetailPatternTable.ctColName_PatternName].Header.Caption = "表示パターン";
			Columns[DetailPatternTable.ctColName_PatternName].Hidden = false;
			Columns[DetailPatternTable.ctColName_PatternName].Width = 200;
			Columns[DetailPatternTable.ctColName_PatternName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			Columns[DetailPatternTable.ctColName_PatternName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			Columns[DetailPatternTable.ctColName_PatternName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//Columns[ColDisplayInfo.ct_Col_Caption].AutoEdit = true;
			Columns[DetailPatternTable.ctColName_PatternName].Header.VisiblePosition = visiblePosition++;

			// 固定列区切り線設定
			this.uGrid_DetailPattern.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_DetailPattern.DisplayLayout.Override.HeaderAppearance.BackColor2;
		}

		/// <summary>
		/// ▲ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_UpDetailItem_Click( object sender, EventArgs e )
		{
			if (this.uGrid_DetailPattern.ActiveRow != null)
			{
				uGrid_DetailPattern.BeginUpdate();
				try
				{
					if (this.DetailFocusTableUpDownRow(0, this.uGrid_DetailPattern.ActiveRow.Index))
					{
						this.uGrid_DetailPattern.ActiveCell = null;
						this.uGrid_DetailPattern.Rows[this.uGrid_DetailPattern.ActiveRow.Index].Selected = true;
					}
				}
				finally
				{
					uGrid_DetailPattern.EndUpdate();
				}
			}
		}
		
		/// <summary>
		/// ▼ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_DownDetailItem_Click( object sender, EventArgs e )
		{
			if (this.uGrid_DetailPattern.ActiveRow != null)
			{
				uGrid_DetailPattern.BeginUpdate();
				try
				{
					if (this.DetailFocusTableUpDownRow(1, this.uGrid_DetailPattern.ActiveRow.Index))
					{
						this.uGrid_DetailPattern.ActiveCell = null;
						this.uGrid_DetailPattern.Rows[this.uGrid_DetailPattern.ActiveRow.Index].Selected = true;
					}
				}
				finally
				{
					uGrid_DetailPattern.EndUpdate();
				}
			}
		}

        /// <summary>
        /// 明細パターングリッドダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_DetailPattern_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));


            this.uButton_EditDetailPattern_Click(this.uButton_EditDetailPattern, new EventArgs());
        }


		/// <summary>
		/// 初期値に戻す
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_DetailFocusUndo_Click( object sender, EventArgs e )
		{
			this.SettingDetailPatternDataTableFromEstimateDetailPatternInfoList(this._stockSlipInputConstructionAcs.EstimateDetailPatternInfoDetaultList,ref this._detailPatternDataTable);
		}

		/// <summary>
		/// 明細パターン追加ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_AddDetailPattern_Click( object sender, EventArgs e )
		{
			if (this.uGrid_DetailPattern.Rows.Count > ct_MaxDetailPattern - 1)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					string.Format("設定可能な明細パターンは{0}パターンまでです。", ct_MaxDetailPattern),
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return;
			}

			PMMIT01019UE patternEditForm = new PMMIT01019UE();

			EstmDtlPtnInfo.SearchType searchType = EstmDtlPtnInfo.SearchType.Pure;
            DialogResult dialogResult = patternEditForm.ShowDialog(this, PMMIT01019UE.DisplayType.New, "", searchType, null);
			if (dialogResult == DialogResult.OK)
			{
				Guid guid = Guid.NewGuid();
				DataRow row = this._detailPatternDataTable.NewRow();
				row[DetailPatternTable.ctColName_PatternGuid] = guid;
				row[DetailPatternTable.ctColName_PatternName] = patternEditForm.PatternName;
				row[DetailPatternTable.ctColName_PatternOrder] = this._detailPatternDataTable.Rows.Count + 1;
				row[DetailPatternTable.ctColName_RowNo] = this._detailPatternDataTable.Rows.Count + 1;
				row[DetailPatternTable.ctColName_SearchMode] = patternEditForm.SearchType;
				row[DetailPatternTable.ctColName_EstimateDetailColInfoList] = patternEditForm.EstimateDetailColInfoList;
				this._detailPatternDataTable.Rows.Add(row);
			}
		}

		/// <summary>
		/// 明細パターン編集ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_EditDetailPattern_Click( object sender, EventArgs e )
		{
			if (this.uGrid_DetailPattern.ActiveRow == null)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"編集するパターンを選択して下さい。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				return;
			}

			PMMIT01019UE patternEditForm = new PMMIT01019UE();

			DataRowView drv = this._detailPatternView[this.uGrid_DetailPattern.ActiveRow.Index];
            DialogResult dialogResult = patternEditForm.ShowDialog(this, PMMIT01019UE.DisplayType.Revision, (string)drv[DetailPatternTable.ctColName_PatternName], (EstmDtlPtnInfo.SearchType)drv[DetailPatternTable.ctColName_SearchMode], (List<EstmDtlColInfo>)drv[DetailPatternTable.ctColName_EstimateDetailColInfoList]);
			if (dialogResult == DialogResult.OK)
			{
				drv[DetailPatternTable.ctColName_PatternName] = patternEditForm.PatternName;
				drv[DetailPatternTable.ctColName_SearchMode] = patternEditForm.SearchType;
				drv[DetailPatternTable.ctColName_EstimateDetailColInfoList] = patternEditForm.EstimateDetailColInfoList;
			}
		}

		/// <summary>
		/// 明細パターン削除ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_DeleteDetailPattern_Click( object sender, EventArgs e )
		{
			if (this.uGrid_DetailPattern.ActiveRow == null)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"削除するパターンを選択して下さい。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				return;
			}
			if (( this.uGrid_DetailPattern.Rows.Count - this.uGrid_DetailPattern.Selected.Rows.Count ) <= 0)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"明細パターンが無くなる為、削除出来ません。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return;
			}

			DialogResult dialogResult = TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_QUESTION,
											this.Name,
											"選択中のパターンを削除します。宜しいですか？",
											0,
											MessageBoxButtons.YesNo,
											MessageBoxDefaultButton.Button2);
			if (dialogResult == DialogResult.Yes)
			{
				// 選択行のGuidリストを取得
				List<Guid> deleteGuidList = this.GetSelectedGuidList();

				DataView dv = new DataView(this._detailPatternDataTable);

				string rowFilter = string.Empty;
				// フィルター文字列生成
				foreach (Guid targetGuid in deleteGuidList)
				{
					if (!string.IsNullOrEmpty(rowFilter))
					{
						rowFilter += " OR ";
					}
					rowFilter += string.Format("{0}='{1}'", DetailPatternTable.ctColName_PatternGuid, targetGuid);
				}
				dv.RowFilter = rowFilter;

				// フィルターがかかった行を全て削除する
				while (dv.Count > 0)
				{
					dv.Delete(0);
				}

				this.DetailPatternTableReSetRowNo();
			}
		}

		/// <summary>
		/// 選択されている行のGuidリストを取得します。
		/// </summary>
		/// <returns></returns>
		private List<Guid> GetSelectedGuidList()
		{
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_DetailPattern.ActiveCell;
			Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_DetailPattern.Selected.Rows;
			if (( cell == null ) && ( rows == null )) return null;

			List<Guid> selectedGuidList = new List<Guid>();

			if (cell != null)
			{
				selectedGuidList.Add((Guid)this._detailPatternView[cell.Row.Index][DetailPatternTable.ctColName_PatternGuid]);
			}
			else if (rows != null)
			{
				foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
				{
					selectedGuidList.Add((Guid)this._detailPatternView[row.Index][DetailPatternTable.ctColName_PatternGuid]);
				}
			}

			return selectedGuidList;
		}

		#endregion

		#endregion

		#region Private Static Methods
		/// <summary>
		/// 列表示情報オブジェクトから明細フォーカス制御行オブジェクトを生成します。
		/// </summary>
		/// <param name="no">番号</param>
		/// <param name="colDisplayInfo">列表示情報オブジェクト</param>
		/// <returns>明細フォーカス制御行オブジェクト</returns>
		private static void DetailPatternRowFromEstimateDetailPatternInfo( int no, EstmDtlPtnInfo estimateDetailPatternInfo, ref DataRow row )
		{
			row[DetailPatternTable.ctColName_RowNo] = no;
			row[DetailPatternTable.ctColName_PatternName] = estimateDetailPatternInfo.PatternName;
			row[DetailPatternTable.ctColName_PatternGuid] = estimateDetailPatternInfo.PatternGuid;
			row[DetailPatternTable.ctColName_SearchMode] = estimateDetailPatternInfo.PartsSearchType;
			row[DetailPatternTable.ctColName_EstimateDetailColInfoList] = estimateDetailPatternInfo.EstimateDetailColInfoList;
		}
	
		#endregion

       
	}
}