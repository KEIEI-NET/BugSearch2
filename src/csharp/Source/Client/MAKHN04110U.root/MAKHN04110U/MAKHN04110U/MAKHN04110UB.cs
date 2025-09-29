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
	/// 複数商品選択フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 複数の商品から選択を行う為のＵＩクラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.1.18</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2008.06.18 20056 對馬 大輔</br>
    /// <br>           : PM.NS対応(コメント無し)</br>
    /// </remarks>
	public partial class MAKHN04110UB : Form
	{
		
		//================================================================================
		//  コンストラクタ
		//================================================================================
		#region Constructor
		
		/// <summary>
		/// 複数商品選択フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 複数商品選択フォームクラスの新しいインスタンスを初期化します。</br>
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
		//  定数定義
		//================================================================================
		#region Constant

		// -------------------------------------------------------------------------------
		#region < グリッド列用 >
		
		/// <summary>抽出結果・入庫入力テーブル</summary>
		private const string CT_SELECT_TBL = "SelectTable";

		/// <summary>選択</summary>
		public const string CT_Select = "Select";
		/// <summary>メーカーコード</summary>
		public const string CT_MakerCode = "MakerCode";
		/// <summary>メーカー名</summary>
		public const string CT_MakerName = "MakerName";
		/// <summary>商品コード</summary>
		public const string CT_GoodsCode = "GoodsNo";
		/// <summary>商品名称</summary>
		public const string CT_GoodsName = "GoodsName";
		/// <summary>商品連結データクラス格納</summary>
		public const string CT_GoodsUitData = "GoodsUitData";

		#endregion

		// -------------------------------------------------------------------------------
		#region < ツールバーキー情報 >
		// ツールバーキー情報    
		private const string CT_TOOLBAR_DECISION_KEY = "Decision_ButtonTool";
		private const string CT_TOOLBAR_BACK_KEY = "Back_ButtonTool";
		private const string CT_TOOLBAR_ALLSELECT_KEY = "AllSelect_ButtonTool";
		#endregion

		#endregion

		//================================================================================
		//  内部メンバー
		//================================================================================
		#region Private Members

		/// <summary>起動カウンター</summary>
		private int _initialCount = 0;

		/// <summary>複数商品選択用データテーブル</summary>
		private DataTable _selDataTable;

		/// <summary>複数商品選択用データビュー</summary>
		private DataView _selDataView;

		/// <summary>表示するデータリスト</summary>
		private List<GoodsUnitData> _dspDataLst;

		/// <summary>選択データリスト</summary>
		private List<GoodsUnitData> _selDataLst;

		/// <summary>デフォルト行の外観設定</summary>
		Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

		/// <summary>選択時の行外観設定</summary>
		private readonly Color _selBackColor = Color.FromArgb(251, 230, 148);
		private readonly Color _selBackColor2 = Color.FromArgb(238, 149, 21);
		private readonly Infragistics.Win.GradientStyle _selBackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

		/// <summary>複数選択</summary>
		private bool _isMultiSelect = false;

		/// <summary>画面デザイン変更クラス</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
		#endregion

		//================================================================================
		//  外部プロパティ
		//================================================================================
		#region Public Methods
		/// <summary>複数選択フラグ</summary>
		public bool IsMultiSelect
		{
			set { this._isMultiSelect = value; }
		}
		#endregion

		//================================================================================
		//  外部提供関数
		//================================================================================
		#region Public Methods

		/// <summary>
		/// 複数商品選択ガイド起動
		/// </summary>
		/// <param name="owner">オーナーフォーム</param>
		/// <param name="goodsUnitDataLst">商品連結データリスト</param>
		/// <returns>DialogResult</returns>
		public DialogResult SelectGoodsGuideShow(IWin32Window owner, ref List<GoodsUnitData> goodsUnitDataLst)
		{
			// 表示用のデータリストを作成する
			this._dspDataLst = new List<GoodsUnitData>(goodsUnitDataLst);
			this._selDataLst = new List<GoodsUnitData>();

			DialogResult dr = base.ShowDialog(owner);

			goodsUnitDataLst = new List<GoodsUnitData>(this._selDataLst);

			return dr;
		}

		#endregion


		//================================================================================
		//  内部関数
		//================================================================================
		#region Private Methods

		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーの初期設定を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.11</br>
		/// </remarks>
		private void InitializeToolbarsSetting()
		{
			// イメージリスト設定
			this.Main_UToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

			// 確定ボタンのアイコン設定
			ButtonTool decButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_DECISION_KEY] as ButtonTool;
			if (decButton != null)
			{
				decButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			}

			// 全選択ボタンのアイコン設定
			ButtonTool allSelButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_ALLSELECT_KEY] as ButtonTool;
			if (allSelButton != null)
			{
				allSelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
				allSelButton.SharedProps.Visible = this._isMultiSelect;
			}
		
			// 戻るボタンのアイコン設定
			ButtonTool backButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_BACK_KEY] as ButtonTool;
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.18</br>
		/// </remarks>
		private void CreatSelectDadaTable()
		{
			// ----------------------------------------

			// DataTableの作成
			this._selDataTable = new DataTable(CT_SELECT_TBL);
			this._selDataView = new DataView();

			// ----------------------------------------
			// DataColumnの作成

			// 選択
			DataColumn Select = new DataColumn(CT_Select, typeof(Boolean), "", MappingType.Element);
			Select.Caption = "選択";

			// メーカー名
			DataColumn MakerName = new DataColumn(CT_MakerName, typeof(string), "", MappingType.Element);
			MakerName.Caption = "メーカー";

			// 商品コード
			DataColumn GoodsCode = new DataColumn(CT_GoodsCode, typeof(string), "", MappingType.Element);
			GoodsCode.Caption = "品番";

			// 商品名称
			DataColumn GoodsName = new DataColumn(CT_GoodsName, typeof(string), "", MappingType.Element);
			GoodsName.Caption = "品名";

			// 商品連結データクラス格納
			DataColumn GoodsUitData = new DataColumn(CT_GoodsUitData, typeof(GoodsUnitData), "", MappingType.Element);
			GoodsUitData.Caption = "商品連結データクラス格納";


			// ----------------------------------------
			// DataTableの初期化
			this._selDataTable.Columns.AddRange(new DataColumn[] {
				Select,
				MakerName,
				GoodsCode,
				GoodsName,
				GoodsUitData});

			this._selDataView.Table = this._selDataTable;

		}

		/// <summary>
		/// 選択用グリッドカラム情報設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 選択用グリッドに表示するカラム情報を設定します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.18</br>
		/// </remarks>
		private void SettingSelGridColumn()
		{
			// バンドを取得
			Infragistics.Win.UltraWinGrid.UltraGridBand band = this.SELECTGrid.DisplayLayout.Bands[0];
			Infragistics.Win.UltraWinGrid.ColumnsCollection columns = band.Columns;

			//---------------------------------------------------------------------
			//　カラム表示・非表示
			//---------------------------------------------------------------------
			columns[CT_Select].Hidden = !this._isMultiSelect;
			columns[CT_GoodsUitData].Hidden = true;

			//---------------------------------------------------------------------
			//　ヘッダーキャプション
			//---------------------------------------------------------------------

			//---------------------------------------------------------------------
			//　アクティブ時動作
			//---------------------------------------------------------------------
			columns[CT_Select].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
			columns[CT_MakerName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_GoodsCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			columns[CT_GoodsName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

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
			columns[CT_Select].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			columns[CT_MakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			columns[CT_GoodsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			columns[CT_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//columns[CT_CpBodyColorSName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

		}

		/// <summary>
		/// グリッドのセッティング描画処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッド全体のセルスタイル・文字色を設定する。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.18</br>
		/// </remarks>
		private void SettingGridRowEditor()
		{
			int cnt = this.SELECTGrid.Rows.Count;

			// 描画を一時停止
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
				// 描画を開始
				this.SELECTGrid.EndUpdate();
			}
		}
		
		/// <summary>
		/// 表示グリッド行単位でのセル描画処理
		/// </summary>
		/// <param name="row">指定行</param>
		/// <remarks>
		/// <br>Note       : グリッド全体のセルスタイル・文字色を設定する。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.18</br>
		/// </remarks>
		private void SettingGridRowEditor(int row)
		{
			// デフォルト行の前景色
			this.SELECTGrid.Rows[row].Appearance.ForeColor = Color.Black;
			this.SELECTGrid.Rows[row].Appearance.ForeColorDisabled = Color.Black;
		}

		
		/// <summary>
		/// 選択用テーブル作成
		/// </summary>
		/// <param name="goodsUnitDataList">商品連結データリスト</param>
		/// <remarks>
		/// <br>Note       : 選択用テーブルを作成します。</br>
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
		/// 商品連結マスタ(goodsUnitData)　⇒　選択用テーブルDataRow
		/// </summary>
		/// <param name="goodsUnitData">商品連結マスタ</param>
		/// <remarks>
		/// <br>Note       : 選択用テーブルのDataRowを作成します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.18</br>
		/// </remarks>
		private DataRow SelGoodUnitDataDataRow(GoodsUnitData goodsUnitData)
		{
			DataRow row = this._selDataTable.NewRow();

			// 選択
			row[CT_Select] = false;

			// メーカー名
			row[CT_MakerName] = goodsUnitData.MakerName;

			// 商品コード
			row[CT_GoodsCode] = goodsUnitData.GoodsNo;

			// 商品名称
			row[CT_GoodsName] = goodsUnitData.GoodsName;

			// 商品連結データクラス格納
			row[CT_GoodsUitData] = goodsUnitData.Clone();

			return row;
		}

		/// <summary>
		/// 商品全選択
		/// </summary>
		/// <remarks>
		/// <br>Note       :表示されているDataRowを全選択します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.18</br>
		/// </remarks>
		private void SelectAllDataRow()
		{
			for (int i = 0; i < this._selDataView.Count; i++)
			{
				// 選択状態にする
				this._selDataView[i][CT_Select] = true;
			}

			// 全行の背景色変更
			this.ChangedRowBackColor();
		}

		/// <summary>
		/// 選択用テーブルDataRow ⇒　商品連結マスタ(goodsUnitData)
		/// </summary>
		/// <param name="row">対象行</param>
		/// <param name="goodsUnitData">商品連結マスタ</param>
		/// <remarks>
		/// <br>Note       : 選択用テーブルのDataRowを作成します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.1.18</br>
		/// </remarks>
		private void SelDataRowToGoodsUnitDataLst()
		{
			for (int i = 0; i < this._selDataView.Count; i++)
			{
				// 選択されているか
				bool select = (this._selDataView[i][CT_Select] != DBNull.Value) ? (Boolean)this._selDataView[i][CT_Select] : false;

				if (select)
				{
					// 商品連結データクラス格納
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
		/// 全行背景色変更処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 対象行の背景色を変更します。</br>
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
		/// 該当行背景色変更処理
		/// </summary>
		/// <param name="row">対象行インデックス</param>
		/// <remarks>
		/// <br>Note       : 対象行の背景色を変更します。</br>
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
		/// カラム列幅調整
		/// </summary>
		/// <remarks>
		/// <br>Note       : カラムの列幅を調整します。</br>
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
		//  コントロールイベント
		//================================================================================
		#region Control Event

		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MAKHN04110UB_Load(object sender, EventArgs e)
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
					this.SELECTGrid.DataSource = this._selDataView;
				}
				else
				{
					if (this._selDataTable != null)
						this._selDataTable.Rows.Clear();
				}

				// データリストから表示用のデータテーブル作成
				this.SettingSelGoodUnitDataTable(this._dspDataLst);

				// データ再設定
				this.SELECTGrid.DataBind();

				// グリッドの描画
				this.SettingGridRowEditor();

				// デフォルト行の外観を取得する
				this._defRowAppearance = (Infragistics.Win.Appearance)this.SELECTGrid.DisplayLayout.Override.RowAppearance.Clone();

				this._initialCount++;

				this.ColReSize_Timer.Enabled = true;
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
		private void SELECTGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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
			if (this._isMultiSelect)
				e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
			else
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
		/// 選択グリッドKeyDownイベン
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

						// 商品連結データクラス格納
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

						// 該当行の背景色を変更します
						this.ChangedRowBackColor(this.SELECTGrid.ActiveRow);

						break;
					}
				default:
					break;
			}
		}

		/// <summary>
		/// 選択用グリッドセル変更イベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		private void SELECTGrid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			if (e.Cell.Column.Key == CT_Select)
			{
				// セルの値を更新する。
				e.Cell.Row.Update();

				if (!this._isMultiSelect) return;

				// 該当行の背景色を変更します
				this.ChangedRowBackColor(e.Cell.Row);
			}
		}

		/// <summary>
		/// グリッドクリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note       : 一覧グリッドがクリックされた際に発生します。</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		private void SELECTGrid_Click(object sender, EventArgs e)
		{
			if (!this._isMultiSelect) return;

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
				bool select = (Boolean)objRow.Cells[CT_Select].Value;
				objRow.Cells[CT_Select].Value = !select;

				// 該当行の背景色を変更します
				this.ChangedRowBackColor(objRow);
			}
		}

		/// <summary>
		/// グリッドだ物クリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note       : 一覧グリッドがダブルクリックされた際に発生します。</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.05.11</br>
		/// </remarks>
		private void SELECTGrid_DoubleClick(object sender, EventArgs e)
		{
			if (this._isMultiSelect) return;

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
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		private void Main_UToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case CT_TOOLBAR_DECISION_KEY:
					{
						// データ選択
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
						// 全行選択
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