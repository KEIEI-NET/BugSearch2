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
	/// 仕入入力用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入入力用のユーザー設定フォームクラスです。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>Update Note: 2009.07.10 21024 佐々木 健 MANTIS[0013757] 仕入日変更時、入荷伝票も変更する区分を追加</br>
    /// <br>Update Note: 2009.11.13 30434 工藤 恵優 MANTIS[0013983] 入力区分の保持機能を追加</br>
    /// <br>Update Note: 2010.01.06 30434 工藤 恵優 MANTIS[0014857] 担当者を保存後も保持する設定を追加</br>
    /// <br>Update Note: 2014/09/01 衛忠明</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : redmine　#43374 仕入伝票入力(保存後ロゴ表示制御)の追加対応</br>
    /// </remarks>
	public partial class StockSlipInputSetup : Form
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		public StockSlipInputSetup()
		{
			InitializeComponent();

			// 変数初期化
			this._imageList16 = IconResourceManagement.ImageList16;
			this._stockSlipInputConstructionAcs = StockSlipInputConstructionAcs.GetInstance();
            this._stockSlipInputConstructionAcsLog = StockSlipInputConstructionAcsLog.GetInstance(); // ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)
			this._controlScreenSkin = new ControlScreenSkin();
			this._toolBarCaptionAcs = new ToolBarCaptionAcs();

			// ヘッダ項目制御用
			this._headerFocusDataTable = new StockSlipInputSetupDataSet.HeaderFocusDataTable();
			this._headerFocusView = this._headerFocusDataTable.DefaultView;
			this._headerFocusView.Sort = this._headerFocusDataTable.RowNoColumn.ColumnName;
			this._headerFocusConstructionList = new HeaderFocusConstructionList();
			this._headerItemsDictionary = new Dictionary<string, Control>();
			this.SettingDetailFocusDataTableFromColDisplayInfoList(this._stockSlipInputConstructionAcs.ColDisplayInfoInitList, ref this._detailFocusDataInitTable);

			// 明細項目制御用
			this._detailFocusDataTable = new StockSlipInputSetupDataSet.DetailFocusDataTable();
			this._detailFocusView = this._detailFocusDataTable.DefaultView;
			this._detailFocusView.Sort = this._headerFocusDataTable.RowNoColumn.ColumnName;

			this.SetComboEditorItemIndex(this.tComboEditor_FocusPosition, this._stockSlipInputConstructionAcs.FocusPositionValue, 0);
			this.tNedit_DataInputCount.SetInt(this._stockSlipInputConstructionAcs.DataInputCountValue);
			this.SetComboEditorItemIndex(this.tComboEditor_FontSize, this._stockSlipInputConstructionAcs.FontSizeValue, 11);
			this.SetOptionSetItemIndex(this.uOptionSet_ClearAfterSave, this._stockSlipInputConstructionAcs.ClearAfterSaveValue);
			this.SetOptionSetItemIndex(this.uOptionSet_SaveInfoStore, this._stockSlipInputConstructionAcs.SaveInfoStoreValue);
            // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
            this.SetOptionSetItemIndex(this.uOptionSet_SaveAgentStore, this._stockSlipInputConstructionAcs.SaveAgentStoreValue);
            // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<
            this.SetOptionSetItemIndex(this.uOptionSet_UseStockAgent, this._stockSlipInputConstructionAcs.UseStockAgentValue);
            this.SetComboEditorItemIndex(this.tComboEditor_SupplierFormalAfterSave, this._stockSlipInputConstructionAcs.SupplierFormalAfterSaveValue, 0);
            this.SetComboEditorItemIndex(this.tComboEditor_StockGoodsCdAfterSave, this._stockSlipInputConstructionAcs.StockGoodsCdAfterSaveValue, 0);   // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
			this.SetComboEditorItemIndex(this.tComboEditor_SupplierFormal, this._stockSlipInputConstructionAcs.SupplierFormalValue, 10);
			this.SetItemtStockGoodsCd(this.GetComboEditorValue(this.tComboEditor_SupplierFormal));	// 伝票種別に従ってコンボエディタのアイテム設定
			this.SetComboEditorItemIndex(this.tComboEditor_StockGoodsCd, this._stockSlipInputConstructionAcs.StockGoodsCdValue, 0);
			this.SetComboEditorItemIndex(this.tComboEditor_DateClearAfterSave, this._stockSlipInputConstructionAcs.DateClearAfterSaveValue, 0);
            this.SetComboEditorItemIndex(this.tComboEditor_FocusPositionAfterSave, this._stockSlipInputConstructionAcs.FocusPositionAfterSaveValue, 1);
            this.SetComboEditorItemIndex(this.tComboEditor_ReflectArrivalGoodsDay, this._stockSlipInputConstructionAcs.ReflectArrivalGoodsDayValue, 0);     // 2009.07.10 Add
            // --- ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) --------->>>>>
            this.SetComboEditorItemIndex(this.tComboEditor_LogoDisp, this._stockSlipInputConstructionAcsLog.LogoDispValue, 0);
            this.tNedit_LogoDispTime.SetInt(this._stockSlipInputConstructionAcsLog.LogoDispTimeValue);
            // --- ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) ---------<<<<<

			if (this.uTabControl_Setup.Tabs.Count > 1)
			{
				this.uTabControl_Setup.TabStop = true;
			}
			else
			{
				this.uTabControl_Setup.TabStop = false;
			}

		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;
		private StockSlipInputConstructionAcs _stockSlipInputConstructionAcs;
        private StockSlipInputConstructionAcsLog _stockSlipInputConstructionAcsLog; // ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)
		private ControlScreenSkin _controlScreenSkin;
		private ToolBarCaptionAcs _toolBarCaptionAcs;

		private StockSlipInputSetupDataSet.HeaderFocusDataTable _headerFocusDataTable;
		private HeaderFocusConstructionList _headerFocusConstructionList;
		private Dictionary<string, Control> _headerItemsDictionary;
		private DataView _headerFocusView = null;

		private StockSlipInputSetupDataSet.DetailFocusDataTable _detailFocusDataTable = null;
		private StockSlipInputSetupDataSet.DetailFocusDataTable _detailFocusDataInitTable = null;
		private DataView _detailFocusView = null;


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

			if ((this.tNedit_DataInputCount.GetInt() <= 0) || (this.tNedit_DataInputCount.GetInt() > 99))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
                    "入力行数は1から99の値を入力して下さい。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				this.tNedit_DataInputCount.Focus();
				check = false;
			}

			return check;
		}

        //---ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) ------->>>>>
        /// <summary>
        /// 保存後のロゴ表示時間入力データチェック処理
        /// </summary>
        /// <returns>true:チェックOK false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : データチェック処理を行う。</br>
        /// <br>Programmer : 衛忠明</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private bool InputDataCheck2()
        {
            bool check = true;

            if ((this.tNedit_LogoDispTime.GetInt() <= 0) || (this.tNedit_LogoDispTime.GetInt() > 5))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "保存後のロゴ表示時間は1から5の値を入力して下さい。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                this.tNedit_LogoDispTime.Focus();
                check = false;
            }

            return check;
        }
        //---ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) -------<<<<<

		# region 明細項目制御
		/// <summary>
		/// 明細項目制御テーブル設定処理
		/// </summary>
		/// <param name="colDisplayInfoList"></param>
		/// <param name="detailFocusDataTable"></param>
		private void SettingDetailFocusDataTableFromColDisplayInfoList( List<ColDisplayInfo> colDisplayInfoList, ref StockSlipInputSetupDataSet.DetailFocusDataTable detailFocusDataTable )
		{
			if (detailFocusDataTable == null)
			{
				detailFocusDataTable = new StockSlipInputSetupDataSet.DetailFocusDataTable();
			}

			detailFocusDataTable.Rows.Clear();

			SortedDictionary<int, ColDisplayInfo> sortedcolDisplayInfoList = new SortedDictionary<int, ColDisplayInfo>();

			// 一旦、表示順にソートする
			foreach (ColDisplayInfo colDisplayInfo in colDisplayInfoList)
			{
				sortedcolDisplayInfoList.Add(colDisplayInfo.VisiblePosition, colDisplayInfo);
			}

			int no = 1;
			foreach (ColDisplayInfo colDisplayInfo in sortedcolDisplayInfoList.Values)
			{
				StockSlipInputSetupDataSet.DetailFocusRow row = detailFocusDataTable.NewDetailFocusRow();
				DetailFocusRowFromColDisplayInfo(no, colDisplayInfo, ref row);
				detailFocusDataTable.AddDetailFocusRow(row);
				no++;
			}
		}

		/// <summary>
		/// 列表示情報テーブルからリストを生成します。
		/// </summary>
		/// <param name="list"></param>
		/// <param name="dataTable"></param>
		private List<ColDisplayInfo> ColDisplayInfoListToSettingDetailFocusDataTable( StockSlipInputSetupDataSet.DetailFocusDataTable detailFocusDataTable )
		{
			List<ColDisplayInfo> colDisplayInfoList = new List<ColDisplayInfo>();
			foreach (StockSlipInputSetupDataSet.DetailFocusRow row in detailFocusDataTable)
			{
				colDisplayInfoList.Add(ColDisplayInfoFromDetailFocusRow(row));
			}
			return colDisplayInfoList;
		}
		
		/// <summary>
		/// 表示位置変更可能チェック
		/// </summary>
		/// <param name="rowIndex"></param>
		/// <returns></returns>
		private bool DetailFocusTableVisiblePositionChangeCheck( int rowIndex )
		{
			if (this._detailFocusView[rowIndex] == null) return false;

			if ((bool)this._detailFocusView[rowIndex][this._detailFocusDataTable.FixedColColumn.ColumnName])
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"変更できない項目です。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return false;
			}

			return true;
		}

		/// <summary>
		/// 行移動処理
		/// </summary>
		/// <param name="mode">0:上に移動,0以外:下に移動</param>
		/// <param name="rowIndex">対象行番号</param>
		/// <returns></returns>
		private bool DetailFocusTableUpDownRow( int mode, int rowIndex)
		{
			if (this._detailFocusView[rowIndex] == null) return false;

			// 対象行の情報を取得する
			string key = (string)this._detailFocusView[rowIndex][this._detailFocusDataTable.KeyColumn.ColumnName];
			int no = (int)this._detailFocusView[rowIndex][this._detailFocusDataTable.RowNoColumn.ColumnName];
			int visiblePosition = (int)this._detailFocusView[rowIndex][this._detailFocusDataTable.VisiblePositionColumn.ColumnName];

			if (key == "") return false;

			string formatString = ( mode == 0 ) ? "{0}<{1}" : "{0}>{1}";
			string sortString = ( mode == 0 ) ? "{0} DESC" : "{0}";
			DataRow[] rows = this._detailFocusDataTable.Select(string.Format(formatString, this._detailFocusDataTable.RowNoColumn.ColumnName, no), string.Format(sortString, this._detailFocusDataTable.RowNoColumn.ColumnName));

			if (( rows != null ) && ( rows.Length > 0 ))
			{
				if ((bool)rows[0][this._detailFocusDataTable.FixedColColumn.ColumnName])
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"移動出来ません。",
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);

					return false;
				}
				else
				{
					DetailFocusTableChangeRowNo(key, (int)rows[0][this._detailFocusDataTable.RowNoColumn.ColumnName], (int)rows[0][this._detailFocusDataTable.VisiblePositionColumn.ColumnName]);
					DetailFocusTableChangeRowNo((string)rows[0][this._detailFocusDataTable.KeyColumn.ColumnName], no, visiblePosition);
				}
			}
			return true;
		}

		/// <summary>
		/// 行番号変更処理
		/// </summary>
		/// <param name="key">対象キー</param>
		/// <param name="no">変更する番号</param>
		/// <param name="visiblePosition">列表示位置</param>
		private void DetailFocusTableChangeRowNo( string key, int no, int visiblePosition )
		{
			DataRow[] rows = this._detailFocusDataTable.Select(string.Format("{0}='{1}'", this._detailFocusDataTable.KeyColumn.ColumnName, key));
			if (rows != null)
			{
				rows[0][this._detailFocusDataTable.RowNoColumn.ColumnName] = no;
				rows[0][this._detailFocusDataTable.VisiblePositionColumn.ColumnName] = visiblePosition;
			}
		}

		/// <summary>
		/// グリッドセル設定処理
		/// </summary>
		private void SettingDetailControlGrid()
		{
			// 各行ごとの設定
			for (int i = 0; i < this.uGrid_DetailControl.Rows.Count; i++)
			{
				this.SettingDetailControlGridRow(i);
			}
		}

		/// <summary>
		/// グリッド行設定処理
		/// </summary>
		/// <param name="rowIndex">行インデックス</param>
		private void SettingDetailControlGridRow( int rowIndex )
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_DetailControl.DisplayLayout.Bands[0];
			if (editBand == null) return;

			Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_DetailControl.Rows[rowIndex];

			row.Cells[this._detailFocusDataTable.VisibleColumn.ColumnName].Activation = ( (bool)row.Cells[this._detailFocusDataTable.VisibleControlColumn.ColumnName].Value ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.Disabled;
			row.Cells[this._detailFocusDataTable.EnterStopColumn.ColumnName].Activation = ( (bool)row.Cells[this._detailFocusDataTable.EnterStopControlColumn.ColumnName].Value ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.Disabled;
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
		private void SettingHeaderFocusConstructionListFromDataTable( StockSlipInputSetupDataSet.HeaderFocusDataTable headerFocusDataTable )
		{
			List<HeaderFocusConstruction> headerFocusConstructionList = new List<HeaderFocusConstruction>();
			DataRow[] rows = headerFocusDataTable.Select("", string.Format("{0}", headerFocusDataTable.RowNoColumn.ColumnName));
			foreach (StockSlipInputSetupDataSet.HeaderFocusRow row in rows)
			{
				HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
				headerFocusConstruction.Key = row.Key;
				headerFocusConstruction.Caption = row.DisplayName;
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
				StockSlipInputSetupDataSet.HeaderFocusRow row = this._headerFocusDataTable.NewHeaderFocusRow();
				row.RowNo = rowNo;
				row.Key = headerFocusConstruction.Key;
				row.DisplayName = headerFocusConstruction.Caption;
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
		private void StockInputSetup_Load(object sender, EventArgs e)
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

            if (this.uGrid_HeaderControl.Rows.Count > 0)
            {
                this.uGrid_HeaderControl.Rows[0].Selected = true;
            }

			//------------------------------------------------------
			// 明細項目制御
			//------------------------------------------------------
			this.SettingDetailFocusDataTableFromColDisplayInfoList(this._stockSlipInputConstructionAcs.ColDisplayInfoList, ref this._detailFocusDataTable);

            #region 途中で削除した項目があった場合の対応（初期テーブルにない項目は削除)
            List<StockSlipInputSetupDataSet.DetailFocusRow> deleteRowList = new List<StockSlipInputSetupDataSet.DetailFocusRow>();
            foreach (StockSlipInputSetupDataSet.DetailFocusRow row in this._detailFocusDataTable)
            {
                StockSlipInputSetupDataSet.DetailFocusRow initRow = this._detailFocusDataInitTable.FindByKey(row.Key);
                if (initRow == null)
                {
                    deleteRowList.Add(row);
                }
            }
            if (deleteRowList.Count > 0)
            {
                foreach (StockSlipInputSetupDataSet.DetailFocusRow row in deleteRowList)
                {
                    this._detailFocusDataTable.RemoveDetailFocusRow(row);
                }
            }
            #endregion

            //this.uGrid_DetailControl.DataSource = this._detailFocusView;
			this.uGrid_DetailControl.DataSource = this._detailFocusView;
            if (this.uGrid_DetailControl.Rows.Count > 0)
            {
                this.uGrid_DetailControl.Rows[0].Selected = true;
            }


			this.timer_Initial.Enabled = true;
		}
		/// <summary>
		/// Control.Click イベント(uButton_Ok)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		private void uButton_Ok_Click(object sender, EventArgs e)
		{
			if (!this.InputDataCheck())
			{
				this.DialogResult = DialogResult.Retry;
				return;
			}
            // --- ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) ------->>>>>
            //保存後のロゴ表示時間
            if (this.GetComboEditorValue(this.tComboEditor_LogoDisp) == 0)  
            {
                if (!this.InputDataCheck2())
                {
                    this.DialogResult = DialogResult.Retry;
                    return;
                }
            }
            //--- ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) -------<<<<<

			this._stockSlipInputConstructionAcs.FocusPositionValue = this.GetComboEditorValue(this.tComboEditor_FocusPosition);
			this._stockSlipInputConstructionAcs.DataInputCountValue = this.tNedit_DataInputCount.GetInt();
			this._stockSlipInputConstructionAcs.FontSizeValue = this.GetComboEditorValue(this.tComboEditor_FontSize);
			this._stockSlipInputConstructionAcs.ClearAfterSaveValue = this.GetOptionSetValue(this.uOptionSet_ClearAfterSave);
			this._stockSlipInputConstructionAcs.SaveInfoStoreValue = this.GetOptionSetValue(this.uOptionSet_SaveInfoStore);
            // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
            this._stockSlipInputConstructionAcs.SaveAgentStoreValue = this.GetOptionSetValue(this.uOptionSet_SaveAgentStore);
            // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<
			this._stockSlipInputConstructionAcs.SupplierFormalAfterSaveValue = this.GetComboEditorValue(this.tComboEditor_SupplierFormalAfterSave);
            this._stockSlipInputConstructionAcs.StockGoodsCdAfterSaveValue = this.GetComboEditorValue(this.tComboEditor_StockGoodsCdAfterSave); // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
			this._stockSlipInputConstructionAcs.SupplierFormalValue = this.GetComboEditorValue(this.tComboEditor_SupplierFormal);
			this._stockSlipInputConstructionAcs.StockGoodsCdValue = this.GetComboEditorValue(this.tComboEditor_StockGoodsCd);
			this._stockSlipInputConstructionAcs.DateClearAfterSaveValue = this.GetComboEditorValue(this.tComboEditor_DateClearAfterSave);
            this._stockSlipInputConstructionAcs.FocusPositionAfterSaveValue = this.GetComboEditorValue(this.tComboEditor_FocusPositionAfterSave);
            this._stockSlipInputConstructionAcs.UseStockAgentValue = this.GetOptionSetValue(this.uOptionSet_UseStockAgent);
            this._stockSlipInputConstructionAcs.ReflectArrivalGoodsDayValue = this.GetComboEditorValue(this.tComboEditor_ReflectArrivalGoodsDay);   // 2009.07.10 Add
            // --- ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) ---------->>>>>
            this._stockSlipInputConstructionAcsLog.LogoDispValue = this.GetComboEditorValue(this.tComboEditor_LogoDisp);
            this._stockSlipInputConstructionAcsLog.LogoDispTimeValue = this.tNedit_LogoDispTime.GetInt();
            // --- ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) ----------<<<<<

			// ヘッダ項目制御
			this.SettingHeaderFocusConstructionListFromDataTable(this._headerFocusDataTable);
			this._stockSlipInputConstructionAcs.HeaderFocusConstructionListValue = this._headerFocusConstructionList;

			// 明細項目制御
			this._stockSlipInputConstructionAcs.ColDisplayInfoList = this.ColDisplayInfoListToSettingDetailFocusDataTable(this._detailFocusDataTable);

			this._stockSlipInputConstructionAcs.Serialize();
            this._stockSlipInputConstructionAcsLog.Serialize(); // ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)
		}

		/// <summary>
		/// 初期処理タイマー起動処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Initial_Tick(object sender, EventArgs e)
		{
			this.timer_Initial.Enabled = false;

			this.SettingDetailControlGrid();

			this.tComboEditor_FocusPosition.Focus();
		}

		/// <summary>
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockInputSetup_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.Retry)
			{
				e.Cancel = true;
			}
		}

		/// <summary>
		/// 伝票種別コンボエディタ選択値変更確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_SupplierFormal_SelectionChangeCommitted( object sender, EventArgs e )
		{
			int supplieFormal = this.GetComboEditorValue(this.tComboEditor_SupplierFormal);
			int stockGoodsCd = this.GetComboEditorValue(this.tComboEditor_StockGoodsCd);
			this.SetItemtStockGoodsCd(supplieFormal);
			this.SetComboEditorItemIndex(this.tComboEditor_StockGoodsCd, stockGoodsCd, 0);
		}

		/// <summary>
		/// 伝票種別変更処理
		/// </summary>
		/// 
		private void SetItemtStockGoodsCd( int supplierFormal )
		{
			switch (supplierFormal)
			{
				case 0:
					{
						this.tComboEditor_StockGoodsCd.Items.Clear();

						Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
						item0.Tag = 1;
						item0.DataValue = 0;
						item0.DisplayText = "明細";
						this.tComboEditor_StockGoodsCd.Items.Add(item0);

                        //Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                        //item2.Tag = 2;
                        //item2.DataValue = 2;
                        //item2.DisplayText = "消費税調整";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item2);

                        //Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
                        //item3.Tag = 3;
                        //item3.DataValue = 3;
                        //item3.DisplayText = "残高調整";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item3);

                        //Infragistics.Win.ValueListItem item4 = new Infragistics.Win.ValueListItem();
                        //item4.Tag = 4;
                        //item4.DataValue = 4;
                        //item4.DisplayText = "消費税調整(買掛用)";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item4);

                        //Infragistics.Win.ValueListItem item5 = new Infragistics.Win.ValueListItem();
                        //item5.Tag = 5;
                        //item5.DataValue = 5;
                        //item5.DisplayText = "残高調整(買掛用)";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item5);

						Infragistics.Win.ValueListItem item6 = new Infragistics.Win.ValueListItem();
						item6.Tag = 2;
						item6.DataValue = 6;
						item6.DisplayText = "合計";
						this.tComboEditor_StockGoodsCd.Items.Add(item6);

						this.tComboEditor_StockGoodsCd.Value = 0;

						break;
					}
				case 1:
					{
						this.tComboEditor_StockGoodsCd.Items.Clear();

						Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
						item0.Tag = 1;
						item0.DataValue = 0;
						item0.DisplayText = "明細";
						this.tComboEditor_StockGoodsCd.Items.Add(item0);
						break;
					}
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
		private void uGrid_DetailControl_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
		{
			Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_DetailControl.DisplayLayout.Bands[0].Columns;

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

			this.uGrid_DetailControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

			// №
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;


			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Hidden = false;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Width = 25;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;

			//Columns[ColDisplayInfo.ct_Col_No].AutoEdit = true;
			Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			// 項目名
			Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Header.Fixed = true;			// 固定項目
			Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Hidden = false;
			Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Width = 100;
			Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//Columns[ColDisplayInfo.ct_Col_Caption].AutoEdit = true;
			Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			// 表示有無
			Columns[this._detailFocusDataTable.VisibleColumn.ColumnName].Header.Fixed = false;				// 固定項目
			Columns[this._detailFocusDataTable.VisibleColumn.ColumnName].Hidden = false;
			Columns[this._detailFocusDataTable.VisibleColumn.ColumnName].Width = 40;
			Columns[this._detailFocusDataTable.VisibleColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			//Columns[ColDisplayInfo.ct_Col_Visible].AutoEdit = true;
			Columns[this._detailFocusDataTable.VisibleColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			// 移動有無
			Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Header.Fixed = false;			// 固定項目
			Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Hidden = false;
			Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Width = 40;
			Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			//Columns[ColDisplayInfo.ct_Col_EnterStop].AutoEdit = true;
			Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			// 固定列区切り線設定
			this.uGrid_DetailControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
		}

		/// <summary>
		/// ▲ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_UpDetailItem_Click( object sender, EventArgs e )
		{
			if (this.uGrid_DetailControl.ActiveRow != null)
			{
				uGrid_DetailControl.BeginUpdate();
				try
				{
					if (DetailFocusTableVisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
					{
						if (this.DetailFocusTableUpDownRow(0, this.uGrid_DetailControl.ActiveRow.Index))
						{
							this.uGrid_DetailControl.ActiveCell = this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Cells[this._detailFocusDataTable.EnterStopControlColumn.ColumnName];
							this.uGrid_DetailControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
							this.uGrid_DetailControl.ActiveCell = null;
							this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Selected = true;
						}
					}
				}
				finally
				{
					uGrid_DetailControl.EndUpdate();
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
			if (this.uGrid_DetailControl.ActiveRow != null)
			{
				uGrid_DetailControl.BeginUpdate();
				try
				{
					if (DetailFocusTableVisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
					{
						if (this.DetailFocusTableUpDownRow(1, this.uGrid_DetailControl.ActiveRow.Index))
						{
							this.uGrid_DetailControl.ActiveCell = this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Cells[this._detailFocusDataTable.EnterStopControlColumn.ColumnName];
							this.uGrid_DetailControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
							this.uGrid_DetailControl.ActiveCell = null;
							this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Selected = true;
						}
					}
				}
				finally
				{
					uGrid_DetailControl.EndUpdate();
				}
			}
		}

		/// <summary>
		/// 初期値に戻す
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_DetailFocusUndo_Click( object sender, EventArgs e )
		{
			this._detailFocusDataTable = (StockSlipInputSetupDataSet.DetailFocusDataTable)this._detailFocusDataInitTable.Copy();
			this._detailFocusView = this._detailFocusDataTable.DefaultView;
			this._detailFocusView.Sort = this._headerFocusDataTable.RowNoColumn.ColumnName;
			this.uGrid_DetailControl.DataSource = _detailFocusView;
			this.SettingDetailControlGrid();
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
		private static void DetailFocusRowFromColDisplayInfo( int no, ColDisplayInfo colDisplayInfo, ref StockSlipInputSetupDataSet.DetailFocusRow row )
		{
			row.RowNo = no;
			row.Key = colDisplayInfo.Key;
			row.Caption = colDisplayInfo.Caption;
			row.EnterStop = colDisplayInfo.EnterStop;
			row.EnterStopControl = colDisplayInfo.EnterStopControl;
			row.FixedCol = colDisplayInfo.FixedCol;
			row.Visible = colDisplayInfo.Visible;
			row.VisibleControl = colDisplayInfo.VisibleControl;
			row.VisiblePosition = colDisplayInfo.VisiblePosition;
		}

		/// <summary>
		/// 明細フォーカス制御行オブジェクトから列表示情報オブジェクトを生成します。
		/// </summary>
		/// <param name="row">明細フォーカス制御行オブジェクト</param>
		/// <returns>列表示情報オブジェクト</returns>
		private static ColDisplayInfo ColDisplayInfoFromDetailFocusRow( StockSlipInputSetupDataSet.DetailFocusRow row )
		{
			ColDisplayInfo colDisplayInfo = new ColDisplayInfo();

			colDisplayInfo.Key = row.Key;
			colDisplayInfo.Caption = row.Caption;
			colDisplayInfo.EnterStop = row.EnterStop;
			colDisplayInfo.EnterStopControl = row.EnterStopControl;
			colDisplayInfo.FixedCol = row.FixedCol;
			colDisplayInfo.Visible = row.Visible;
			colDisplayInfo.VisibleControl = row.VisibleControl;
			colDisplayInfo.VisiblePosition = row.VisiblePosition;

			return colDisplayInfo;
		}
		#endregion		

		private void tComboEditor_StockGoodsCd_ValueChanged( object sender, EventArgs e )
		{

		}

        // --- ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) -------->>>>>
        /// <summary>
        /// 保存後のロゴ表示「しない」の場合は無効化処理
        /// </summary>
        /// <param name="sender">保存後のロゴ表示時間・無効化</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note	   : 保存後のロゴ表示「しない」の場合は無効化します。</br>
        /// <br>Programmer : 衛忠明</br>
        /// <br>Date       : K2014/09/01</br>
        /// </remarks>
        private void tComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)((TComboEditor)sender).Value;

            if (value == 1)
            {
                // tNedit1
                this.tNedit_LogoDispTime.Enabled = false;
            }
            else
            {
                // tNedit1
                this.tNedit_LogoDispTime.Enabled = true;
            }
        }
        // --- ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) --------<<<<<
	}
}