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
	/// 同一番号仕入伝票選択フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入伝票検索で同一番号が複数存在する場合に1伝票を選択するクラスです。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men 新規作成</br>
	/// </remarks>
	public partial class MAKON01110UH : Form
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MAKON01110UH()
		{
			InitializeComponent();

			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

		}

		#endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		#region ■Const

		// -------------------------------------------------------------------------------
		#region < グリッド列用 >

		/// <summary>抽出結果・入庫入力テーブル</summary>
        private const string CT_SELECT_TBL = "SelectTable";
		/// <summary>仕入日</summary>
        public const string CT_StockDate = "StockDate";
		/// <summary>入荷日</summary>
        public const string CT_ArrivalGoodsDay = "ArrivalGoodsDay";
		/// <summary>伝票番号</summary>
        public const string CT_PartySalesSlipNum = "PartySalesSlipNum";
		/// <summary>仕入先コード</summary>
        public const string CT_SupplierCd = "SupplierCd";
		/// <summary>仕入先名</summary>
        public const string CT_SupplierName = "SupplierName";
		/// <summary>仕入SEQ番号</summary>
        public const string CT_SupplierSlipNo = "SupplierSlipNo";
		/// <summary>備考</summary>
        public const string CT_SupplierSlipNote1 = "SupplierSlipNote1";
		/// <summary>リマーク1</summary>
        public const string CT_UoeRemark1 = "UoeRemark1";
		/// <summary>仕入データクラス格納</summary>
        public const string CT_StockSlip = "StockSlip";

		#endregion

		// -------------------------------------------------------------------------------
		#region < ツールバーキー情報 >

		// ツールバーキー情報    
		private const string CT_TOOLBAR_DECISION_KEY = "ButtonTool_Decision";
		private const string CT_TOOLBAR_BACK_KEY = "ButtonTool_Back";
		#endregion

		#endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		/// <summary>選択用データテーブル</summary>
		private DataTable _selDataTable;
		/// <summary>選択用データビュー</summary>
		private DataView _selDataView;
		/// <summary>表示するデータリスト</summary>
		private List<StockSlip> _dspDataLst;
		/// <summary>選択したデータリスト</summary>
		private List<StockSlip> _selDataList;
		/// <summary>画面デザイン変更クラス</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
		/// <summary>起動カウンター</summary>
		private int _initialCount = 0;
		/// <summary>仕入形式</summary>
		private int _supplierFormal;

		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties

		/// <summary>選択データリスト</summary>
		public List<StockSlip> SelectDataList
		{
			get { return _selDataList; }
		}

		#endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		#region ■Public Methods

		/// <summary>
		/// 画面呼出し処理
		/// </summary>
		/// <param name="owner">オーナーフォーム</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="stockSlipList">仕入データリスト</param>
		/// <returns></returns>
		public DialogResult ShowDialog( IWin32Window owner, int supplierFormal, List<StockSlip> stockSlipList )
		{
			// 表示用のデータリストを作成する
			this._dspDataLst = new List<StockSlip>(stockSlipList);

			this._supplierFormal = supplierFormal;

			return this.ShowDialog(owner);
		}

		#endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		#region ■Private Methods

		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーの初期設定を行います。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private void InitializeToolbarsSetting()
		{
			// イメージリスト設定
			this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

			// 確定ボタンのアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool decButton = this.tToolbarsManager_MainMenu.Tools[CT_TOOLBAR_DECISION_KEY] as Infragistics.Win.UltraWinToolbars.ButtonTool;
			if (decButton != null)
			{
				decButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			}

			// 戻るボタンのアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool backButton = this.tToolbarsManager_MainMenu.Tools[CT_TOOLBAR_BACK_KEY] as Infragistics.Win.UltraWinToolbars.ButtonTool;
			if (backButton != null)
			{
				backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			}
		}

		/// <summary>
		/// 選択用データテーブル作成
		/// </summary>
		/// <remarks>
		/// <br>Note       : DataTableの設定を行います。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private void CreatSelectDadaTable()
		{
			// ----------------------------------------

			// DataTableの作成
			this._selDataTable = new DataTable(CT_SELECT_TBL);
			this._selDataView = new DataView(this._selDataTable);

			// ----------------------------------------
			// DataColumnの作成

			//// 選択
			//DataColumn Select = new DataColumn(CT_Select, typeof(Boolean), "", MappingType.Element);
			//Select.Caption = "選択";

			// 仕入日
			DataColumn StockDate = new DataColumn(CT_StockDate, typeof(DateTime), "", MappingType.Element);
			StockDate.Caption = "仕入日";

			// 入荷日
			DataColumn ArrivalGoodsDay = new DataColumn(CT_ArrivalGoodsDay, typeof(DateTime), "", MappingType.Element);
			ArrivalGoodsDay.Caption = "入荷日";

			// 伝票番号
			DataColumn PartySalesSlipNum = new DataColumn(CT_PartySalesSlipNum, typeof(string), "", MappingType.Element);
			PartySalesSlipNum.Caption = "伝票番号";

			// 仕入先コード
			DataColumn SupplierCd = new DataColumn(CT_SupplierCd, typeof(Int32), "", MappingType.Element);
			SupplierCd.Caption = "仕入先コード";

			// 仕入先名
			DataColumn SupplierName = new DataColumn(CT_SupplierName, typeof(string), "", MappingType.Element);
			SupplierName.Caption = "仕入先名";

			// 仕入SEQ番号
			DataColumn SupplierSlipNo = new DataColumn(CT_SupplierSlipNo, typeof(Int32), "", MappingType.Element);
			SupplierSlipNo.Caption = "仕入SEQ番号";

			// 備考
			DataColumn SupplierSlipNote1 = new DataColumn(CT_SupplierSlipNote1, typeof(string), "", MappingType.Element);
			SupplierSlipNote1.Caption = "備考";

			// リマーク1
			DataColumn UoeRemark1 = new DataColumn(CT_UoeRemark1, typeof(string), "", MappingType.Element);
			UoeRemark1.Caption = "リマーク1";

			// 仕入データクラス格納
			DataColumn stockSlip = new DataColumn(CT_StockSlip, typeof(StockSlip), "", MappingType.Element);
			stockSlip.Caption = "仕入データクラス格納";


			// ----------------------------------------
			// DataTableの初期化
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
		/// 選択用テーブル作成
		/// </summary>
		/// <param name="stockSlipList">仕入データリスト</param>
		/// <remarks>
		/// <br>Note       : 選択用テーブルを作成します。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
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
		/// 仕入データ(stockSlip)　⇒　選択用テーブルDataRow
		/// </summary>
		/// <param name="stockSlip">仕入データ</param>
		/// <remarks>
		/// <br>Note       : 選択用テーブルのDataRowを作成します。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private DataRow SelStockSlipDataDataRow( StockSlip stockSlip )
		{
			DataRow row = this._selDataTable.NewRow();

			//// 選択
			//row[CT_Select] = false;

			// 仕入日
			row[CT_StockDate] = stockSlip.StockDate;

			// 入荷日
			row[CT_ArrivalGoodsDay] = stockSlip.ArrivalGoodsDay;

			// 伝票番号
			row[CT_PartySalesSlipNum] = stockSlip.PartySaleSlipNum;

			// 仕入先コード
			row[CT_SupplierCd] = stockSlip.SupplierCd;

			// 仕入先名
			row[CT_SupplierName] = stockSlip.SupplierSnm;

			// 仕入SEQ番号
			row[CT_SupplierSlipNo] = stockSlip.SupplierSlipNo;

			// 備考
			row[CT_SupplierSlipNote1] = stockSlip.SupplierSlipNote1;

			// リマーク
			row[CT_UoeRemark1] = stockSlip.UoeRemark1;

			// 仕入データクラス格納
			row[CT_StockSlip] = stockSlip.Clone();

			return row;
		}

		/// <summary>
		/// 選択用グリッドカラム情報設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 選択用グリッドに表示するカラム情報を設定します。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private void SettingSelGridColumn()
		{
			// バンドを取得
			Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Select.DisplayLayout.Bands[0];
			Infragistics.Win.UltraWinGrid.ColumnsCollection columns = band.Columns;

			//---------------------------------------------------------------------
			//　カラム表示・非表示
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
			//　ヘッダーキャプション
			//---------------------------------------------------------------------

			//---------------------------------------------------------------------
			//　アクティブ時動作
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
			//　セルクリックアクション
			//---------------------------------------------------------------------
			//columns[CT_Select].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			//columns[CT_MakerName].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			//columns[CT_GoodsCode].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			//columns[CT_GoodsName].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			//columns[CT_CpBodyColorSName].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

			//---------------------------------------------------------------------
			//　テキストの表示位置
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
			//　セルの幅
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
			//　フォーマット
			//---------------------------------------------------------------------
			string dateFormat = "yyyy/MM/dd";
			columns[CT_StockDate].Format = dateFormat;
			columns[CT_ArrivalGoodsDay].Format= dateFormat;

		}
		#endregion

		// ===================================================================================== //
		// コントロールのイベント
		// ===================================================================================== //
		#region ■Control Events

		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MAKON01110UI_Load( object sender, EventArgs e )
		{
			try
			{
				// 初回起動時のみ
				if (this._initialCount == 0)
				{
					// ツールバー初期設定 
					this.InitializeToolbarsSetting();

					// データテーブルの作成
					this.CreatSelectDadaTable();

					// データソース設定
					this.uGrid_Select.DataSource = this._selDataView;
				}
				else
				{
					if (this._selDataTable != null)
						this._selDataTable.Rows.Clear();
				}

				// データリストから表示用のデータテーブル作成
				this.SettingSelStockSlipDataTable(this._dspDataLst);

				this._initialCount++;

				this.timer_InitialFocus.Enabled = true;
			}
			catch (Exception ex)
			{
				// メッセージ表示
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,      // エラーレベル
					this.GetType().ToString(),            // アセンブリＩＤまたはクラスＩＤ
					this.Text,                            // プログラム名称
					"Load",                               // 処理名称
					"",                                   // オペレーション
					ex.Message,                           // 表示するメッセージ
					-1,                                   // ステータス値
					null,                                 // エラーが発生したオブジェクト
					MessageBoxButtons.OK,                 // 表示するボタン
					MessageBoxDefaultButton.Button1);     // 初期表示ボタン
			}
			finally
			{
			}
		}


		/// <summary>
		/// グリッドレイアウト初期化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uGrid_Select_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
		{
			// スクロールバースタイル
			e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Deferred;

			// 列の自動サイ調整
			e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

			// 列ヘッダの表示スタイル
			e.Layout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Default;

			// セルの境界線スタイルの設定 
			e.Layout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;

			// 行の境界線スタイルの設定 
			e.Layout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;

			// データ行の追加許可
			e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			// データ行の削除許可
			e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			// データ行の更新許可
			e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			// 列移動の変更
			e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			// 固定列ヘッダ
			e.Layout.UseFixedHeaders = false;

			// セルクリック時実行アクション
			//if (this._isMultiSelect)
			//    e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
			//else
			//    e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

			// ActiveCellの外観設定
			e.Layout.Override.ActiveCellAppearance.BackColor = Color.FromArgb(247, 227, 156);

			//// ヘッダーの外観設定
			//e.Layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			//e.Layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			//e.Layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			//e.Layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
			//e.Layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
			//e.Layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

			// 行の外観設定
			e.Layout.Override.RowAppearance.BackColor = Color.White;

			// 1行おきの外観設定
			e.Layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

			// 行セレクターの表示非表示
			e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

			//// 行セレクターの外観設定
			//e.Layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			//e.Layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			//e.Layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// 行選択設定 行選択無しモード(アクティブのみ)
			e.Layout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
			e.Layout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
			e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;

			// 選択行の外観設定
			//e.Layout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(255, 255, 255);
			//e.Layout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(0, 0, 0);
			//e.Layout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			//e.Layout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(255, 255, 255);
			//e.Layout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(0, 0, 0);
			//e.Layout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			e.Layout.Override.ActiveRowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

			// 選択行の外観設定
			//e.Layout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(255, 255, 255);
			//e.Layout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(0, 0, 0);
			//e.Layout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;

			// 行選択時は、全ての列の文字色は黒とする(この記述ないと白色になって見難いとの批判があったため。)
			e.Layout.Override.SelectedRowAppearance.ForeColor = Color.Black;

			// 行フィルターの設定
			e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

			// テキストのレンタリング設定
			e.Layout.Override.CellAppearance.TextTrimming = Infragistics.Win.TextTrimming.Character;

			this.SettingSelGridColumn();
		}
		
		/// <summary>
		/// グリッドキーダウンイベント
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
						// キーが押されたことによるデフォルトのグリッド動作をキャンセルする
						e.Handled = true;
						// グリッド表示を右にスクロール
						this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position + 40;
						break;
					}
				case Keys.Left:
					{
						// キーが押されたことによるデフォルトのグリッド動作をキャンセルする
						e.Handled = true;

						if (this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position == 0)
						{
						}
						else
						{
							// グリッド表示を左にスクロール
							this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Select.DisplayLayout.ColScrollRegions[0].Position - 40;

						}
						break;
					}
				default:
					break;
			}
		}

		/// <summary>
		/// グリッドダブルクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uGrid_Select_DoubleClick( object sender, EventArgs e )
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

			if (objRow != null)
			{
				// 商品連結データクラス格納
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
		/// ツールバークリックイベント
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
		/// 初期フォーカスタイマーTickイベント
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