using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
//using Infragistics.Win.UltraWinGrid;//  ADD 鄭慕鈞　Redmine#34434 2013/01/29  //DEL 譚洪 Redmine#34994 2013/03/10

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 検索見積明細入力コントロールクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 検索見積の明細入力を行うコントロールクラスです。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.09.06</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men 新規作成</br>
    /// <br>2009.07.16 22018 鈴木 正臣 MANTIS[0013802] ＢＬコードガイドの初期表示モードを設定可能に変更。</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/22 呉元嘯</br>
    /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>             保守依頼②の追加</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/05 呉元嘯</br>
    /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>             Redmine#1087、#1134対応</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/12 呉元嘯</br>
    /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>             Redmine#1233、#1234、#1238対応</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/13 呉元嘯</br>
    /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>             Redmine#1238対応</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/15 鈴木 正臣</br>
    /// <br>             MANTIS[0015285] 品名が変更された時、半角に変換して品名ｶﾅをセットするよう変更。</br>
    /// <br></br>
    /// <br>Update Note: 2010/08/05　張凱　障害改良対応（８月リリース分）の対応</br>
    /// <br>             ①優良品の結合情報を表示する可能にするため、ファンクションを追加して結合情報を表示可能にする修正</br>
    /// <br>Update Note: 2011/02/14　鄧潘ハン</br>
    /// <br>             ＢＬコード複数検索時に空白行を詰めるように修正</br>
    /// <br>             得意先掛率グループ取得処理対応</br>
    /// <br>             明細グリッドが表示されていない場合のエラー修正</br>
    /// <br>Update Note: 2011/03/28 曹文傑</br>
    /// <br>             Redmine #20177の対応</br>
    /// <br>Update Note: 2011/12/19 鄧潘ハン</br>
    /// <br>           : redmine#8034、外車データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正</br>
    /// <br>Update Note: 2012/04/09 zhangy3</br>
    /// <br>管理番号   : 10801804-00 2012/05/24配信分</br>
    /// <br>           : redmine#29312、検索見積発行　売価の掛率が反映されない</br>
    /// <br>Update Note: 2012/04/27 wangf</br>
    /// <br>管理番号   : 10801804-00 2012/05/24配信分</br>
    /// <br>           : redmine#29640、検索見積発行　得意先掛率Ｇが適用されないの対応</br>
    /// <br>Update Note: 2013/01/29 鄭慕鈞</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine#34434、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
    /// <br>Update Note: 2013/02/08 yangyi</br>
    /// <br>管理番号   : 10801804-00 2013/03/13 配信分の緊急対応</br>
    /// <br>           : redmine#34604、マウスポインタで制御 砂時計にする　</br>
    /// <br>Update Note: 2013/03/10 譚洪</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine#34994、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
    /// <br>Update Note: 2013/02/27 許培珠</br>
    /// <br>管理番号   : 10801804-00 2013/05/15 配信分</br>
    /// <br>           : redmine#34803、明細行のチェックボックスのエラー</br>
    /// <br>Update Note: 2013/05/07 xujx</br>
    /// <br>管理番号   : 10801804-00 2013/05/15 配信分</br>
    /// <br>           : redmine#34803、発注データの明細を作成した後、その明細を削除し、別の車両で新規にデータを作成してから印刷しようとすると「インデックスが配列の境界外です。」の対応</br>
    /// <br>           :　明細表示を「規格/オプション情報」に変更後、明細を削除するとフォーカスが最終行まで移動してしまいますの対応</br>
    /// <br>Update Note: 2013/05/08 chenw</br>
    /// <br>管理番号   : 10801804-00 2013/05/15 配信分</br>
    /// <br>           : redmine#34803、明細表示を「規格/オプション情報」に変更後、明細を削除するとフォーカスが最終行まで移動してしまいますの対応</br>
    /// <br>Update Note: 2014/09/01 譚洪</br>
    /// <br>管理番号   : 11070184-00　SCM障害対応 №190　RedMine#43289</br>
    /// <br>         　: SFから問合せの車輌情報・備考を売上伝票入力に表示する</br>
    /// </remarks>
	public partial class PMMIT01010UB : UserControl
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constroctors

		/// <summary>
        /// 検索見積明細入力コントロールクラス コンストラクタ
		/// </summary>
		public PMMIT01010UB( EstimateInputAcs estimateInputAcs )
		{
            InitializeComponent();

			this._estimateInputAcs = estimateInputAcs;
			// 変数初期化
			this._rowInsertButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowInsert"];
			this._rowDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowDelete"];
			this._rowCutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCut"];
			this._rowCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCopy"];
			this._rowPasteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowPaste"];

			this._detailPatternComboBox = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager_Main.Tools["ComboBoxTool_DetailPattern"];
            this._partsSelectComboBox = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager_Main.Tools["ComboBoxTool_PartsSelect"];
            this._priceSelectComboBox = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager_Main.Tools["ComboBoxTool_PriceSelect"];// ADD 2009/10/22
			// ボタンリスト
			this._buttonList = new List<Infragistics.Win.Misc.UltraButton>();
			this._buttonList.Add(this.uButton_Guide);
			this._buttonList.Add(this.uButton_RowCopy);
			this._buttonList.Add(this.uButton_RowCut);
			this._buttonList.Add(this.uButton_RowDelete);
			this._buttonList.Add(this.uButton_RowInsert);
			this._buttonList.Add(this.uButton_RowPaste);
			this._buttonList.Add(this.uButton_EstimateReference);
            this._buttonList.Add(this.uButton_SetDisplay);
            this._buttonList.Add(this.uButton_WarehouseChange);
            this._buttonList.Add(this.uButton_TBO);

			this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();
			this._estimateDetailDataTable = this._estimateInputAcs.EstimateDetailDataTable;
			this._imageList16 = IconResourceManagement.ImageList16;
			this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			this._estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();
			this._estimateInputConstructionAcs.DataChanged += new EventHandler(this.EstimateInputConstructionAcs_DataChanged);

			// 列表示状態クラスリストXMLファイルをデシリアライズ
			List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(ct_FILENAME_COLDISPLAYSTATUS);

			// 列表示状態コレクションクラスをインスタンス化
			this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._estimateDetailDataTable);

            this._estimateInputAcs.PimeInfoSelectChanged += new EventHandler(this.PrimeInfoSelectChanged);

			//this._estimateInputConstructionAcs.GetColDisplayInfoInitList += new EstimateInputConstructionAcs.GetColDisplayInfoEventHandler(this._colDisplayStatusList.GetColDisplayInfoInitList);
			//this._estimateInputConstructionAcs.GetColDisplayInfoList += new EstimateInputConstructionAcs.GetColDisplayInfoEventHandler(this._colDisplayStatusList.GetColDisplayInfoList);
			//this._estimateInputConstructionAcs.SetColDisplayInfoList += new EstimateInputConstructionAcs.SetColDisplayInfoEventHandler(this.ReflectionColDisplayList);

            this._guideDspCellList = new List<string>();
            this._guideDspCellList.Add(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName);
            this._guideDspCellList.Add(this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName);
            this._guideDspCellList.Add(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName);
            this._guideDspCellList.Add(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName);
            this._guideDspCellList.Add(this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName);
            this._guideDspCellList.Add(this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName);
            this._guideDspCellList.Add(this._estimateDetailDataTable.SupplierCdColumn.ColumnName);
            this._guideDspCellList.Add(this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName);

            this._estimateInputColInfoInitialSetting = EstimateInputColInfoInitialSetting.GetInstance();

			// 仕入明細データテーブル列表示設定クラスセッティング処理
            this._ownerForm = new Form();
		}

		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;									// イメージリスト
		private EstimateInputAcs _estimateInputAcs;
		private EstimateInputInitDataAcs _estimateInputInitDataAcs;
		private EstimateInputDataSet.EstimateDetailDataTable _estimateDetailDataTable;
        private EstimateInputConstructionAcs _estimateInputConstructionAcs;
        private SupplierAcs _supplierAcs;
		private Image _guideButtonImage;
		private int _verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private Int32 _beforeInt32Value = 0;
        private Int64 _beforeInt64Value = 0;
        private string _beforeStringValue = "";
        private double _beforeDoubleValue = 0;
		private bool _beforeCellUpdateCancel = false;
        private bool _afterCellUpdateCancel = false;
        private bool _blPartsSearched = false;
        private int _searchedLastRowIndex = 0;
		private Infragistics.Win.UltraWinGrid.UltraGridCell _beforeCell;
		private ColDisplayStatusList _colDisplayStatusList;						// 列表示状態コレクションクラス

		private EstmDtlPtnInfo _estmDtlPtnInfo = new EstmDtlPtnInfo();

        private EstimateInputColInfoInitialSetting _estimateInputColInfoInitialSetting;
		
		private List<Infragistics.Win.Misc.UltraButton> _buttonList;			// ボタンのリスト
        private List<string> _guideDspCellList;

		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowInsertButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDeleteButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCutButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCopyButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowPasteButton;
		private Infragistics.Win.UltraWinToolbars.ComboBoxTool _detailPatternComboBox;
        
		private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
		private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
		private static readonly Color ct_READONLY_COLOR = Color.WhiteSmoke;
		private static readonly Color ct_ROWSTATUS_COPY_COLOR = Color.Pink;
		private static readonly Color ct_ROWSTATUS_CUT_COLOR = Color.Gray;
		private static readonly Color ct_REDUCTION_FONT_COLOR = Color.Green;
		private static readonly Color ct_MINUS_FONT_COLOR = Color.Red;
		private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
		private static readonly Color ct_ALLWAYS_CELL_COLOR = Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
		private const string ct_FILENAME_COLDISPLAYSTATUS = "PMMIT01010U_ColSetting.DAT";				// 列表示状態セッティングXMLファイル名

		private static readonly Color ct_PRIME_HEADER_BACKCOLOR = Color.Orange;
		private static readonly Color ct_PRIME_HEADER_BACKCOLOR2 = Color.OrangeRed;

		private const string cUIDataKey_BLGoodsCode = "gridCell_BLGoodsCode";
		private const string cUIDataKey_CustomerCode = "gridCell_CustomerCode";
		private const string cUIDataKey_GoodsMakerCd = "gridCell_GoodsMakerCd";
		private const string cUIDataKey_GoodsName = "gridCell_GoodsName";
		private const string cUIDataKey_GoodsNo = "gridCell_GoodsNo";
		private const string cUIDataKey_WarehouseCode = "gridCell_WarehouseCode";

        private Infragistics.Win.UltraWinToolbars.ComboBoxTool _partsSelectComboBox;		// 部品選択コンボボックス
        // 標準価格選択選択コンボボックス
        private Infragistics.Win.UltraWinToolbars.ComboBoxTool _priceSelectComboBox;     // ADD 2009/10/22
        private System.Windows.Forms.Form _ownerForm;

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		internal static readonly string ct_ITEM_NAME_CUSTOMERCODE = "CustomerCode";
        internal static readonly string ct_ITEM_NAME_CARMNGCODE = "CarMngCode";
        internal const int ct_SettingActiveCell_ShipmentCntError = 1;
		internal const int ct_SettingActiveCell_ShipmentCntError_Prime = 2;
		private const string MESSAGE_GoodsCode = "前方一致検索：最後に*を入力[例:A*]、後方一致検索：最初に*を入力[例:*A]、曖昧検索：前後に*を入力[例:*A*]、全件検索：*を入力";
		# endregion

		// ===================================================================================== //
		// 列挙体
		// ===================================================================================== //
		# region Enums
		internal enum DisplayType : int
		{
			/// <summary>通常モード</summary>
			Normal = 0,
			/// <summary>売上同時入力モード</summary>
			SalesInput = 1
		}
		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		/// <summary>
		/// ステータスバーメッセージ表示デリゲート
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="message">表示メッセージ</param>
		internal delegate void SettingStatusBarMessageEventHandler(object sender, string message);
		
		/// <summary>
		/// フォーカス設定デリゲート
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="itemName">項目名称</param>
		internal delegate void SettingFocusEventHandler(object sender, string itemName);

		/// <summary>
		/// 仕入拠点取得デリゲート
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="stockSectionCd">仕入拠点</param>
		internal delegate void GetStockSectionCdEventHandler(object sender, ref string stockSectionCd);

        /// <summary>
        /// 行変更デリゲート
        /// </summary>
        /// <param name="salesRowNo"></param>
        internal delegate void SettingFooterEventHandler( int salesRowNo );

		/// <summary>
		/// ツールバーボタン制御デリゲート
		/// </summary>
		internal delegate void SettingToolbarEventHandler();

        /// <summary>
        /// 車輌情報設定デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesRowNo"></param>
        internal delegate void SettingCarInfoEventHandler( object sender, Int32 salesRowNo );

		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		/// <summary>グリッド最上位行キーダウンイベント</summary>
		internal event EventHandler GridKeyDownTopRow;
		
		/// <summary>グリッド最下層行キーダウンイベント</summary>
		internal event EventHandler GridKeyDownButtomRow;
		
		/// <summary>ステータスバーメッセージ表示イベント</summary>
		internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;

		/// <summary>フォーカス設定イベント</summary>
		internal event SettingFocusEventHandler FocusSetting;

        /// <summary>行変更イベント</summary>
        internal event SettingFooterEventHandler SettingFooter;

		/// <summary>ツールバー設定デリゲート</summary>
		internal event SettingToolbarEventHandler SetToolbarButton;

        /// <summary>車輌情報設定イベント</summary>
        internal event SettingCarInfoEventHandler SettingCarInfo;

		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties

		/// <summary>ガイドボタンEnabledプロパティ</summary>
		internal bool GuideButtonEnabled
		{
			get
			{
				return this.uButton_Guide.Enabled;
			}
		}

		/// <summary>履歴ボタンEnabledプロパティ</summary>
		internal bool EstimateReferenceButtonEnabled
		{
			get
			{
				return this.uButton_EstimateReference.Enabled;
			}
		}

        /// <summary>セットボタンEnabledプロパティ</summary>
        internal bool SetButtonEnabled
        {
            get
            {
                return this.uButton_SetDisplay.Enabled;
            }
        }

        /// <summary>オーナーフォームプロパティ</summary>
        internal Form OwnerForm
        {
            set { this._ownerForm = value; }
        }
		# endregion

		// ===================================================================================== //
		// プライベート・インターナルメソッド
		// ===================================================================================== //
		# region Private Methods and Internal Methods

		/// <summary>
		/// 初期処理（処理データリモートの初期読み込み後に行う処理）
		/// </summary>
		internal void SettingAfterInitDataRead()
		{
            EstimateDefSet estimateDefSet = this._estimateInputInitDataAcs.GetEstimateDefSet();

            this.SetComboBoxToolValue(this._partsSelectComboBox, estimateDefSet.PartsSelectDivCd, 0);
            this._priceSelectComboBox.SelectedIndex = 0; // ADD 2009/10/22
            this.Clear();
        }

		/// <summary>
		/// Returnキーダウン処理
		/// </summary>
		/// <returns>true:セル移動完了 false:セル移動失敗</returns>
		internal bool ReturnKeyDown()
		{
			if (this.uGrid_Details.ActiveCell == null) return false;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
			int salesRowNo = this._estimateDetailDataTable[cell.Row.Index].SalesRowNo;
            int rowIndex = cell.Row.Index;

            try
            {
                this.uGrid_Details.SuspendLayout();
                this.uGrid_Details.BeginUpdate();

                bool canMove = true;

                if (this._estimateInputAcs.SalesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly)
                {
                    canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                }
                else
                {
                    if (( cell.Column.Key == this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName ) ||
                        ( cell.Column.Key == this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName ))
                    {
                        // セルを更新する
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // BeforeCellUpdateでキャンセルフラグがたっている場合はセル移動無し
                        if (this._beforeCellUpdateCancel)
                        {
                            this._beforeCellUpdateCancel = false;
                        }
                        // AfterCellUpdateでキャンセルフラグがたっている場合はセル移動無し
                        else if (this._afterCellUpdateCancel)
                        {
                            this._afterCellUpdateCancel = false;
                        }
                        else
                        {
                            if (( this._blPartsSearched ) &&
                                ( this._searchedLastRowIndex >= 0 ) &&
                                ( this._estimateDetailDataTable.Rows.Count > ( this._searchedLastRowIndex + 1 ) ))
                            {
                                if (( !this.uGrid_Details.Rows[this._searchedLastRowIndex + 1].Cells[cell.Column.Key].Hidden ) &&
                                    ( this.uGrid_Details.Rows[this._searchedLastRowIndex + 1].Cells[cell.Column.Key].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                {
                                    this._blPartsSearched = false;
                                    canMove = true;
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[this._searchedLastRowIndex + 1].Cells[cell.Column.Key];
                                    this.uGrid_Details.Rows[this._searchedLastRowIndex + 1].Cells[cell.Column.Key].Selected = true;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                canMove = this.MoveReturnCell();
                            }
                        }
                    }
                    else
                    {
                        // セル編集モードの場合
                        if (cell.IsInEditMode)
                        {
                            string beforeCellKey = cell.Column.Key;

                            // セルを更新する
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            // ActiveCellが変更していない場合はNextCellを取得する
                            if (this.uGrid_Details.ActiveCell.Column.Key == beforeCellKey)
                            {
                                // BeforeCellUpdateでキャンセルフラグがたっている場合はセル移動無し
                                if (this._beforeCellUpdateCancel)
                                {
                                    this._beforeCellUpdateCancel = false;
                                }
                                // AfterCellUpdateでキャンセルフラグがたっている場合はセル移動無し
                                else if (this._afterCellUpdateCancel)
                                {
                                    this._afterCellUpdateCancel = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                        else
                        {
                            // 次入力可能セル移動処理
                            canMove = this.MoveReturnCell();
                        }
                    }

                }

                if (!canMove)
                {
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[cell.Column.Key];
                    this.uGrid_Details.Rows[rowIndex].Cells[cell.Column.Key].Selected = true; // 編集不可項目のフォーカスカラー対応
                    this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[rowIndex];
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }

                return canMove;
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
				this.uGrid_Details.ResumeLayout();
            }

            
		}

		/// <summary>
		/// Returnキーセル移動処理
		/// </summary>
		/// <param name="activeCellCheck">true:次移動先算出を行わない</param>
		/// <returns></returns>
		internal bool MoveReturnCell()
		{
			return MoveReturnCell(false, false);
		}

		/// <summary>
		/// Returnキーセル移動処理
		/// </summary>
		/// <param name="activeCellCheck">true:次移動先算出を行わない</param>
		/// <returns></returns>
		internal bool MoveReturnCell( bool activeCellCheck, bool layoutUpdate )
		{
			try
			{

				//---------------------------------------------
				// 初期処理
				//---------------------------------------------
				// レイアウトロジック、グリッド描画停止
				if (layoutUpdate)
				{
					this.uGrid_Details.SuspendLayout();
					this.uGrid_Details.BeginUpdate();
				}

				//---------------------------------------------
				// セル移動不可
				//---------------------------------------------
				if ( this._estimateInputAcs.SalesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly )
				{
					return false;
				}

				if (!activeCellCheck)
				{
					//---------------------------------------------
					// 移動前位置保持
					//---------------------------------------------
					int beforeRowIndex = this.uGrid_Details.ActiveRow.Index;
					int beforeColIndex = this.uGrid_Details.ActiveCell.Column.Index;
					string beforeColKeyName = this.uGrid_Details.ActiveCell.Column.Key;
					int afterRowIndex = beforeRowIndex;
					string afterColKeyName;

					//---------------------------------------------
					// 移動先Col取得
					//---------------------------------------------
					switch (this.GetNextMovePosition(beforeColKeyName, out afterColKeyName))
					{
						// 正常取得
						case 0:
							{
								break;
							}
						// 次の行
						case 1:
							{
								afterRowIndex++;
								if (afterRowIndex > this.uGrid_Details.Rows.Count - 1) return false;
								break;
							}
                        case -1:
                            {
                                return false;
                            }
						default:
							{
								break;
							}
					}

					//---------------------------------------------
					// アクティブ位置セット
					//---------------------------------------------
					// 使用不可か編集不可
					if (( this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled ) ||
						( this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ))
					{
						//---------------------------------------------
						// 移動先移動不可
						//---------------------------------------------
						// 移動先が有効になるまで移動
						//---------------------------------------------
						this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
						return MoveReturnCell(); // 再帰
					}
					else
					{
						//---------------------------------------------
						// 移動先移動可
						//---------------------------------------------
						this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
						this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName].Selected = true; // 編集不可項目のフォーカスカラー対応
						this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[afterRowIndex];
					}
				}

				//---------------------------------------------
				// 編集モードセット
				//---------------------------------------------
				if (( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) &&
					( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
				//if (( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
				{
					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}

				return true;

			}
			finally
			{
				//---------------------------------------------
				// 終了処理
				//---------------------------------------------
				if (layoutUpdate)
				{
					this.uGrid_Details.EndUpdate();
					this.uGrid_Details.ResumeLayout();
				}
			}
		}

		/// <summary>
		/// 移動位置取得処理(Enterキー移動時)
		/// </summary>
		/// <param name="key"></param>
		/// <param name="afterColKeyName"></param>
		/// <returns>0:正常取得,1:次の行,-1:例外</returns>
		private int GetNextMovePosition( string key, out string afterColKeyName )
		{
			afterColKeyName = "";

            List<EstmDtlColInfo> estmDtlColInfoList = this._estmDtlPtnInfo.EstimateDetailColInfoList;

            int colIndex = 0;
            foreach (EstmDtlColInfo estmDtlColInfo in estmDtlColInfoList)
            {
                if (estmDtlColInfo.Key == key)
                {
                    colIndex = estmDtlColInfo.VisiblePosition;
                }
            }

            // 同一行内の後ろの項目に移動可能セルがあるか検索する
            foreach (EstmDtlColInfo estmDtlColInfo in estmDtlColInfoList)
            {
                if (( estmDtlColInfo.VisiblePosition > colIndex ) &&
                    ( estmDtlColInfo.Visible == true ) &&
                    ( estmDtlColInfo.EnterStop == true ))
                {
                    afterColKeyName = estmDtlColInfo.Key;
                    return 0;
                }
            }

            // 次の行の最初の移動可能セルを検索する
            afterColKeyName = this.GetFirstCell(estmDtlColInfoList, true);
            if (!string.IsNullOrEmpty(afterColKeyName))
            {
                return 1;
            }

			return -1;
		}

        /// <summary>
        /// 見積明細カラムリストより、入力可能先頭セルを取得します。
        /// </summary>
        /// <param name="estmDtlColInfoList"></param>
        /// <returns></returns>
        private string GetFirstCell(List<EstmDtlColInfo> estmDtlColInfoList, bool enterStop)
        {
            string retKey = string.Empty;
            // 最初の移動可能セルを検索する
            foreach (EstmDtlColInfo estmDtlColInfo in estmDtlColInfoList)
            {
                if ( estmDtlColInfo.Visible == true )
                {
                    if (enterStop)
                    {
                        if (estmDtlColInfo.EnterStop == true)
                        {
                            retKey = estmDtlColInfo.Key;
                            break;
                        }
                    }
                    else
                    {
                        retKey = estmDtlColInfo.Key;
                        break;
                    }
                }
            }
            return retKey;
        }


		/// <summary>
		/// 次入力可能セル移動処理
		/// </summary>
		/// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
		/// <returns>true:セル移動完了 false:セル移動失敗</returns>
		private bool MoveNextAllowEditCell(bool activeCellCheck)
		{
			if ( this._estimateInputAcs.SalesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly ) 
			{
				return false;
			}

			bool moved = false;
			bool performActionResult = false;

			try
			{
                this.uGrid_Details.BeginUpdate();

				if (( activeCellCheck ) && ( this.uGrid_Details.ActiveCell != null ))
				{
					if (( !this.uGrid_Details.ActiveCell.Column.Hidden ) &&
						( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) &&
						( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
					{
						moved = true;
					}
				}

				while (!moved)
				{
					if (this.uGrid_Details.ActiveCell != null)
					{
						int editMode = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._estimateDetailDataTable.EditStatusColumn.ColumnName].Value;

						if (( editMode == EstimateInputAcs.ctEDITSTATUS_AllDisable ) || ( editMode == EstimateInputAcs.ctEDITSTATUS_AllReadOnly ))
						{
							performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

							if (( performActionResult ) && ( this.uGrid_Details.ActiveRow != null ))
							{
								int index = this.uGrid_Details.ActiveRow.Index;

								if (!( this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNoColumn.ColumnName].Hidden ))
								{
									this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._estimateDetailDataTable.GoodsNoColumn.ColumnName];
								}
								else
								{
									this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._estimateDetailDataTable.GoodsNameColumn.ColumnName];
								}

								// 再帰処理
								this.MoveNextAllowEditCell(true);

								return true;
							}
						}
					}

					performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

					if (performActionResult)
					{
						if (( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) &&
							( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
						{
							moved = true;
						}
						else
						{
							moved = false;
						}
					}
					else
					{
						break;
					}
				}

				if (moved)
				{
					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}
			}
			finally
			{
				this.uGrid_Details.EndUpdate();
			}

			return performActionResult;
		}

        /// <summary>
        /// 移動位置取得処理(Shift+Tabキー移動時)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="afterColKeyName"></param>
        /// <returns>0:正常取得,1:前の行,-1:例外</returns>
        private int GetPrevMovePosition(string key, out string afterColKeyName)
        {
            afterColKeyName = "";

            List<EstmDtlColInfo> estmDtlColInfoList = this._estmDtlPtnInfo.EstimateDetailColInfoList;

            if (this._estmDtlPtnInfo.ContainsEstmDtlColInfo(key))
            {
                EstmDtlColInfo baseEstmDtlColInfo = this._estmDtlPtnInfo.GetEstmDtlColInfo(key);

                int colIndex = -1;
                string name = string.Empty;

                // 同一行内の前の項目に移動可能セルがあるか検索する
                foreach (EstmDtlColInfo estmDtlColInfo in estmDtlColInfoList)
                {
                    if (( estmDtlColInfo.VisiblePosition < baseEstmDtlColInfo.VisiblePosition ) &&
                        ( estmDtlColInfo.VisiblePosition > colIndex ) &&
                        ( estmDtlColInfo.Visible == true ) &&
                        ( estmDtlColInfo.EnterStop == true ))
                    {
                        colIndex = estmDtlColInfo.VisiblePosition;
                        name = estmDtlColInfo.Key;
                    }
                }

                if (!string.IsNullOrEmpty(name))
                {
                    afterColKeyName = name;
                    return 0;
                }


                // 最終の移動可能セルを検索する
                afterColKeyName = this.GetLastCell(estmDtlColInfoList, true);
                if (!string.IsNullOrEmpty(afterColKeyName))
                {
                    return 1;
                }
            }


            return -1;
        }

        /// <summary>
        /// 見積明細カラムリストより、入力可能最終セルを取得します。
        /// </summary>
        /// <param name="estmDtlColInfoList"></param>
        /// <returns></returns>
        private string GetLastCell(List<EstmDtlColInfo> estmDtlColInfoList, bool enterStop)
        {
            string retKey = string.Empty;
            int position = -1;
            // 最後の移動可能セルを検索する
            foreach (EstmDtlColInfo estmDtlColInfo in estmDtlColInfoList)
            {
                if (( estmDtlColInfo.Visible ) && ( ( position < estmDtlColInfo.VisiblePosition ) ))
                {
                    if (enterStop)
                    {
                        if (estmDtlColInfo.EnterStop == true)
                        {
                            retKey = estmDtlColInfo.Key;
                            position = estmDtlColInfo.VisiblePosition;
                        }
                    }
                    else
                    {
                        retKey = estmDtlColInfo.Key;
                        position = estmDtlColInfo.VisiblePosition;
                    }
                }
            }
            return retKey;
        }



		/// <summary>
		/// グリッド列初期設定処理
		/// </summary>
        /// <br>Update Note: 2013/01/29 鄭慕鈞</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine#34434、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
		private void InitialSettingGridCol()
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
			if (editBand == null) return;

			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				// 全ての列をいったん非表示にする。
				col.Hidden = true;
				col.Header.Fixed = false;

				// 「No列」以外の全てのセルのDiabledColorを設定する。
				if (col.Key != this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName)
				{
					col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
					col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
				}
			}

            #region ●表示幅設定
#if false
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].Width = 44;		// №
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderNumberColumn.ColumnName].Width = 70;				// 発注番号
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNoColumn.ColumnName].Width = 100;			    	// 商品コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNameColumn.ColumnName].Width = 140;				// 商品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName].Width = 70;		    	// メーカーコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName].Width = 90;			// 定価
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.StockCountRemainderColumn.ColumnName].Width = 60;	// 残数量
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCntDisplayColumn.ColumnName].Width = 60;		// 数量
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRateColumn.ColumnName].Width = 70;				// 仕入率
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesUnPrcDisplayColumn.ColumnName].Width = 90;	// 単価（表示用）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesMoneyDisplayColumn.ColumnName].Width = 130;		// 仕入金額（表示用）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.TaxDivColumn.ColumnName].Width = 25;					// 課税区分
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName].Width = 120;			// 倉庫コード
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseNameColumn.ColumnName].Width = 120;			// 倉庫名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName].Width = 55;			// 棚番
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SupplierStockDisplayColumn.ColumnName].Width = 55;		// 現在庫数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName].Width = 70;				// BLコード
#endif
            #endregion

			#region ●固定列設定
#if false
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].Header.Fixed = true;	// №
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderNumberColumn.ColumnName].Header.FixedCol = true;			// 発注番号
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNoColumn.ColumnName].Header.Fixed = true;			// 商品コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;			// 商品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;			// 商品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
#endif
			#endregion

			#region ●CellAppearance設定
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;              // 行番号

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                    // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;               // 標準価格
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                    // QTY
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                   // メーカーコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                  // 倉庫コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                 // 現在庫数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                     // 仕入先コード

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;              // BLコード（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;         // 標準価格（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;              // QTY（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;             // メーカーコード（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;            // 倉庫コード（優良）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;           // 現在庫数（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;               // 仕入先コード（優良）

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;          // OP
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderSelectColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;                  // 発注
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;          // セット
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;    // OP（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;            // 発注（優良）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;    // セット（優良）

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;

			// 優良項目の色設定
			// BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// 品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// 品番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// メーカー
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// メーカー名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// QTY
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// 標準価格
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// OP
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// 倉庫
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// 棚番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// 現在庫数
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// 仕入先
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// 発注
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// 印刷
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
			// セット
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;
            // 発注
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName].Header.Appearance.BackColor = ct_PRIME_HEADER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName].Header.Appearance.BackColor2 = ct_PRIME_HEADER_BACKCOLOR2;

			#endregion

			#region ●入力許可設定
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;         // No
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // OP
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.MakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;                   // メーカー名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;            // 棚番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;              // 現在庫数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // セット
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderSelectColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;                 // 発注
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;   // OP（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;             // メーカー名（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // 棚番（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;        // 現在庫数（優良）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;   // セット（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;           // 発注（優良）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SpecialNoteColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;                 // オプション
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.StandardNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;                // 規格

			#endregion

			#region ●Style設定
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;               // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                 // 品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                   // 品番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // メーカーコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;             // 倉庫コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;               // QTY
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;          // 標準価格

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // BLコード（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;           // 品名（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;             // 品番（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // メーカーコード（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;       // 倉庫コード（優良）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // QTY（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // 標準価格

			#endregion

			#region ●CharacterCasing設定
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNoColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ProductNumberColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            #endregion

			#region ●Button用個別設定

			#endregion

			#region ●フォーマット設定
			string moneyFormat = "#,##0;-#,##0;''";
			//string moneyFormat_Zero = "#,##0;-#,##0;'0'";
			string decimalFormat = "#,##0.00;-#,##0.00;''";
			//string decimalFormat_Zero = "#,##0.00;-#,##0.00;'0'";
            string codeFormat = "#0;-#0;''";
            //string countFormat = "#,##0;-#,##0;";// ADD 鄭慕鈞　Redmine#34434 2013/01/29　現在庫数のフォーマットを修正  //DEL 譚洪 Redmine#34994 2013/03/10

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName].Format = codeFormat;                  // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName].Format = codeFormat;                 // メーカーコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCntColumn.ColumnName].Format = decimalFormat;               // 数量
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName].Format = moneyFormat;            // 標準価格
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName].Format = decimalFormat;          // DEL 鄭慕鈞　Redmine#34434 2013/01/29　現在庫数
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName].Format = countFormat;              // ADD 鄭慕鈞　Redmine#34434 2013/01/29　現在庫数  // DEL 譚洪 Redmine#34994 2013/03/10
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SupplierCdColumn.ColumnName].Format = codeFormat;                   // 仕入先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName].Format = codeFormat;            // BLコード（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName].Format = codeFormat;           // メーカーコード（優良）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName].Format = decimalFormat;         // 数量（優良）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName].Format = moneyFormat;      // 標準価格（優良）
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName].Format = decimalFormat;      // DEL 鄭慕鈞　Redmine#34434 2013/01/29 現在庫数（優良）
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName].Format = countFormat;          // ADD 鄭慕鈞　Redmine#34434 2013/01/29 現在庫数（優良）// DEL 譚洪 Redmine#34994 2013/03/10
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName].Format = codeFormat;             // 仕入先（優良）

            #endregion

			#region ●MaxLength設定

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNoColumn.ColumnName].MaxLength = 40;                   // 商品コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNameColumn.ColumnName].MaxLength = 100;                // 商品名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCntColumn.ColumnName].MaxLength = 10;               // 数量
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName].MaxLength = 8;           // 定価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRateColumn.ColumnName].MaxLength = 6;                 // 仕入率

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName].MaxLength = 5;                // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName].MaxLength = 6;              // 倉庫
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName].MaxLength = 6;               // メーカー


            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName].MaxLength = 40;             // 商品コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName].MaxLength = 100;          // 商品名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName].MaxLength = 10;         // 数量
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName].MaxLength = 8;     // 定価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.SalesRate_PrimeColumn.ColumnName].MaxLength = 6;            // 仕入率

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName].MaxLength = 5;          // BLコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName].MaxLength = 6;        // 倉庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName].MaxLength = 6;         // メーカー


			#endregion

			#region ●DropDownList設定
            //// DropDownList設定
            //Infragistics.Win.ValueList list = new Infragistics.Win.ValueList();
            //list.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
            //list.DropDownListMinWidth = 0;
            //list.MaxDropDownItems     = 10;

            //Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
            //listItem0.DataValue = 0;
            //listItem0.DisplayText = "課税";

            //Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
            //listItem1.DataValue = 1;
            //listItem1.DisplayText = "非課税";

            //Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
            //listItem2.DataValue = 2;
            //listItem2.DisplayText = "課税(内税)";

            //list.ValueListItems.Add(listItem0);
            //list.ValueListItems.Add(listItem1);
            //list.ValueListItems.Add(listItem2);

            //this.uGrid_Details.DisplayLayout.ValueLists.Add(list);
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._estimateDetailDataTable.TaxDivColumn.ColumnName].ValueList = list;

            #endregion

			#region ●UI設定からMaxLength,TextHAlignの再セット
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				int maxLength = uiSetControl1.GetSettingColumnCount(col.Key);

				if (maxLength > 0)
				{
					col.MaxLength = maxLength;
					col.CellAppearance.TextHAlign = uiSetControl1.GetSettingHAlign(col.Key);

                    string format = this.GetCodeFormat(col.Key);
                    if (!string.IsNullOrEmpty(format))
                    {
                        col.Format = format;
                    }
				}
			}
			#endregion

			foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (this.uGrid_Details.DisplayLayout.Bands[0].Columns.Exists(colDisplayStatus.Key))
				{
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;

					//this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;

					//this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;

					//this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Hidden = !colDisplayStatus.Visible;
				}
			}

			// グリッド列表示非表示設定処理
			//this.SettingGridColVisible(StatusType.Default, 0);
		}

        /// <summary>
        /// ＵＩ設定ＸＭＬからのコードフォーマット取得(00,000,0000… etc.)
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        private string GetCodeFormat(string editName)
        {
            UiSet uiset;
            int status = uiSetControl1.ReadUISet(out uiset, editName);
            if (status == 0)
            {
                return ( uiset.PadZero ) ? string.Format("{0};-{0};''", new string('0', uiset.Column)) : string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

		/// <summary>
		/// グリッド設定処理（ユーザー設定より）
		/// </summary>
		/// <param name="estimateInputConstruction">検索見積入力用ユーザー設定クラス</param>
		internal void GridSetting(EstimateInputConstruction estimateInputConstruction)
		{
			// フォントサイズ
            this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = estimateInputConstruction.FontSizeValue;
        }

		/// <summary>
		/// クローズ処理
		/// </summary>
		internal void Closing()
		{
			// 列表示状態クラスリスト構築処理
			List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

			// 列表示状態クラスリストをXMLにシリアライズする
			ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ct_FILENAME_COLDISPLAYSTATUS);
		}


		/// <summary>
		/// グリッド列表示非表示設定処理
		/// </summary>
		/// <param name="estmDtlPtnInfo">明細パターン情報</param>
		/// <param name="value">値</param>
		private void SettingGridColVisible( EstmDtlPtnInfo estmDtlPtnInfo )
		{
			// すべての列の表示非表示設定
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
			if (editBand == null) return;

			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				// 全ての列をいったん非表示にする。
				col.Hidden = true;
				col.Header.Fixed = false;
			}

			// 行№は固定
			editBand.Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].Header.VisiblePosition = 0;
			editBand.Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].Hidden = false;
			editBand.Columns[this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName].Header.Fixed = true;

			foreach (EstmDtlColInfo estmDtlColInfo in estmDtlPtnInfo.EstimateDetailColInfoList)
			{
				if (editBand.Columns.Exists(estmDtlColInfo.Key))
				{
					editBand.Columns[estmDtlColInfo.Key].Hidden = !estmDtlColInfo.Visible;
					editBand.Columns[estmDtlColInfo.Key].Header.Fixed = estmDtlColInfo.FixedCol;
					editBand.Columns[estmDtlColInfo.Key].Header.VisiblePosition = estmDtlColInfo.VisiblePosition;
				}
			}
		}

		/// <summary>
		/// グリッド列表示幅設定処理
		/// </summary>
		private void SettingGridColWidth()
		{
			int totalWidth = this.uGrid_Details.DisplayLayout.Override.RowSelectorWidth;
			int lastColumnIndex = 0;
			int visiblePosition = 0;

			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
			{
				if (!column.Hidden)
				{
					totalWidth += column.Width;

					if (visiblePosition < column.Header.VisiblePosition)
					{
						visiblePosition = column.Header.VisiblePosition;
						lastColumnIndex = column.Index;
					}
				}
			}

			int difference = (this.uGrid_Details.Width - this._verticalScrollBarWidth) - totalWidth - 2;		// -2は微調整

			if ((difference > 0) && (difference < this._verticalScrollBarWidth))
			{
				this.uGrid_Details.DisplayLayout.Bands[0].Columns[lastColumnIndex].Width += difference;
			}
		}

		/// <summary>
		/// 引数のモードを元にActiveCellを設定します。
		/// </summary>
		/// <param name="mode">モード</param>
        /// <param name="rowNo">行番号</param>
        internal void SettingActiveCell( int mode, int rowNo )
		{
            if (( rowNo >= 0 ) && ( rowNo < this._estimateDetailDataTable.Rows.Count ))
            {
                for (int i = 0; i < this._estimateDetailDataTable.Rows.Count; i++)
                {
                    EstimateInputDataSet.EstimateDetailRow row = (EstimateInputDataSet.EstimateDetailRow)this._estimateDetailDataTable.Rows[i];

                    if (row.SalesRowNo == rowNo)
                    {
                        string columnKey = string.Empty;
                        switch (mode)
                        {
                            case ct_SettingActiveCell_ShipmentCntError:
                                {
                                    columnKey = this._estimateDetailDataTable.ShipmentCntColumn.ColumnName;
                                    break;
                                }
                            case ct_SettingActiveCell_ShipmentCntError_Prime:
                                {
                                    columnKey = this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName;
                                    break;
                                }
                        }

                        if (!string.IsNullOrEmpty(columnKey))
                        {
                            if (!this.uGrid_Details.Rows[i].Cells[columnKey].Hidden)
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[i].Cells[columnKey];
                                this.CellExitEnterEditEnter();
                            }
                        }

                        break;
                    }
                }
            }
		}

		/// <summary>
		/// 明細グリッド設定処理
		/// </summary>
		internal void SettingGrid()
		{
			try
			{
				// 描画を一時停止
				this.uGrid_Details.BeginUpdate();
				SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;
				if (salesSlip == null) return;

				if (salesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly)
				{
					//this.tToolbarsManager_Main.Enabled = false;
				}
				else
				{
					//this.tToolbarsManager_Main.Enabled = true;
				}

				// 描画が必要な明細件数を取得する。
				int cnt = this._estimateDetailDataTable.Count;

                // 各行ごとの設定
				for (int i = 0; i < cnt; i++)
				{
					this.SettingGridRow(i, salesSlip);
				}

                // 表示用行番号調整処理
				this._estimateInputAcs.AdjustRowNo();
            }
			finally
			{
				// 描画を開始
				this.uGrid_Details.EndUpdate();
			}
		}

		/// <summary>
		/// 明細グリッド・行単位でのセル設定
		/// </summary>
		/// <param name="rowIndex">対象行インデックス</param>
		/// <param name="stockSlip">仕入データクラスオブジェクト</param>
        /// <br>Update Note: 2013/01/29 鄭慕鈞</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine#34434、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
		private void SettingGridRow(int rowIndex, SalesSlip salesSlip)
		{
			if (salesSlip == null) return;

			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
			if (editBand == null) return;

            if (this._estmDtlPtnInfo.PartsSearchType == EstmDtlPtnInfo.SearchType.None)
            {
                // 指定行の全ての列に対して設定を行う。
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                {
                    // セル情報を取得
                    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                    if (cell == null) continue;

                    cell.Row.Hidden = false;

                    // アンダーラインを全てのセルに対して非表示とする
                    cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                    // 行ステータスを取得
                    int rowStatus = this._estimateDetailDataTable[rowIndex].RowStatus;

                    #region セル背景色変更
                    if (( cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled ) &&
                        ( cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled ))
                    {
                        if (rowStatus == EstimateInputAcs.ctROWSTATUS_COPY)
                        {
                            cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                            // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                            //行ステータスがコピーの場合、倉庫コードが空白の時、現在庫数は空白で表示される
                            //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode) && col.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                            //{
                            //    cell.Appearance.ForeColor = Color.Transparent;
                            //}
                            //if ( string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime) && col.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                            //{
                            //    cell.Appearance.ForeColor = Color.Transparent;
                            //}
                            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                            // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                        }
                        else if (rowStatus == EstimateInputAcs.ctROWSTATUS_CUT)
                        {
                            cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                            cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
                            // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                            //行ステータスがカットの場合、倉庫コードが空白の時、現在庫数は空白で表示される
                            //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode) && col.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                            //{
                            //    cell.Appearance.ForeColor = Color.Transparent;
                            //}
                            //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime) && col.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                            //{
                            //    cell.Appearance.ForeColor = Color.Transparent;
                            //}
                            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                            // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                        }
                        else
                        {
                            cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

                            if (( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ) ||
                                ( cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ))
                            {
                                cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                            }
                            else
                            {
                                cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.BackColor;
                            }
                            // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                            // 現在庫数
                            //倉庫がある場合のみ、現在庫数がｾﾞﾛに表示される
                            //if (col.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                            //{
                            //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode.Trim()))
                            //    {
                            //        cell.Appearance.ForeColor = Color.Transparent;
                            //    }
                            //    else
                            //    {
                            //        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                            //    }
                            //}
                            //// 現在庫数（優良）
                            ////倉庫がある場合のみ、現在庫数（優良）がｾﾞﾛに表示される
                            //if (col.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                            //{
                            //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime.Trim()))
                            //    {
                            //        cell.Appearance.ForeColor = Color.Transparent;
                            //    }
                            //    else
                            //    {
                            //        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                            //    }
                            //}
                            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                            // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                        }
                    }
                    #endregion

                    #region アイコン表示

                    // オープン価格
                    if (col.Key == this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName)
                    {
                        this.DisplayOpenPrice(rowIndex);
                    }
                    // オープン価格（優良）
                    if (col.Key == this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName)
                    {
                        this.DisplayOpenPrice_Prime(rowIndex);
                    }

                    // セット
                    if (col.Key == this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName)
                    {
                        this.DisplayExistSetInfo(rowIndex);
                    }
                    // セット（優良）
                    if (col.Key == this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName)
                    {
                        this.DisplayExistSetInfo_Prime(rowIndex);
                    }
                    // 発注
                    if (col.Key == this._estimateDetailDataTable.OrderSelectColumn.ColumnName)
                    {
                        this.DisplayOrderSelectInfo(rowIndex);
                    }
                    // 発注（優良）
                    if (col.Key == this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName)
                    {
                        this.DisplayOrderSelectInfoPrime(rowIndex);
                    }

                    #endregion
                }
            }

            else
            {
                switch (salesSlip.SearchMode)
                {
                    #region ●部品検索(BLコード検索)
                    case 0:
                        {
                            // 行番号を取得
                            int salesRowNo = this._estimateDetailDataTable[rowIndex].SalesRowNo;

                            // BL商品コード(純正)
                            int blGoodsCode = this._estimateDetailDataTable[rowIndex].BLGoodsCode;

                            // BL商品コード(優良)
                            int blGoodsCode_Prime = this._estimateDetailDataTable[rowIndex].BLGoodsCode_Prime;

                            // 品名(純正)
                            string goodsName = this._estimateDetailDataTable[rowIndex].GoodsName;

                            // 品番(純正)
                            string goodsNo = this._estimateDetailDataTable[rowIndex].GoodsNo;

                            // 品名(優良)
                            string goodsName_Prime = this._estimateDetailDataTable[rowIndex].GoodsName_Prime;

                            // 品番(優良)
                            string goodsNo_Prime = this._estimateDetailDataTable[rowIndex].GoodsNo_Prime;

                            // 純正品番計上フラグ
                            bool addUp_Pure = ( this._estimateDetailDataTable[rowIndex].AlreadyAddUpCnt != 0 );

                            // 優良品番計上フラグ
                            bool addUp_Prime = ( this._estimateDetailDataTable[rowIndex].AlreadyAddUpCnt_Prime != 0 );

                            // 変更可能ステータスを取得
                            int editStatus = this._estimateDetailDataTable[rowIndex].EditStatus;

                            // 行ステータスを取得
                            int rowStatus = this._estimateDetailDataTable[rowIndex].RowStatus;

                            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                            // 倉庫コード(純正)
                            //string warehouseCode = this._estimateDetailDataTable[rowIndex].WarehouseCode;// DEL 譚洪 Redmine#34994 2013/03/10

                            // 倉庫(優良)
                            //string warehouseCode_Prime = this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime;// DEL 譚洪 Redmine#34994 2013/03/10
                            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<

                            // 指定行の全ての列に対して設定を行う。
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                            {
                                // セル情報を取得
                                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                                if (cell == null) continue;

                                cell.Row.Hidden = false;

                                // アンダーラインを全てのセルに対して非表示とする
                                cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                                #region 伝票入力モード：読取専用
                                if (salesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly)
                                {
                                    if (cell.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                }
                                #endregion

                                #region 伝票入力モード：通常
                                else
                                {
                                    #region 明細入力モード：全項目無効
                                    if (editStatus == EstimateInputAcs.ctEDITSTATUS_AllDisable)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                    #endregion

                                    #region 明細入力モード：全項目読み取り専用
                                    else if (editStatus == EstimateInputAcs.ctEDITSTATUS_AllReadOnly)
                                    {
                                    }
                                    #endregion

                                    #region 明細入力モード：計上されている
                                    //else if (editStatus == EstimateInputAcs.ctEDITSTATUS_AddUped)
                                    //{
                                    //    // 品番・メーカーは入力不可
                                    //    if (( col.Key == this._estimateDetailDataTable.GoodsNoColumn.Caption ) ||
                                    //        ( col.Key == this._estimateDetailDataTable.GoodsMakerCdColumn.Caption ))
                                    //    {
                                    //        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    //    }
                                    //    else
                                    //    {
                                    //        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    //    }
                                    //}
                                    #endregion

                                    #region 明細入力モード：通常
                                    else
                                    {
                                        // BL検索時はBLコードが常時入力可能
                                        if (( col.Key == this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName ) ||
                                            ( col.Key == this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                        }
                                        // 上記以外
                                        else
                                        {
                                            // BLコードが入力されいない場合はBLコード以外は入力不可
                                            // 品番任意時は「品番」「品名」が入力されていない場合は他の項目は入力不可
                                            if (( string.IsNullOrEmpty(goodsNo) ) && ( string.IsNullOrEmpty(goodsNo_Prime) ))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                            }
                                            else
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                                                if (addUp_Pure)
                                                {
                                                    if (( col.Key == this._estimateDetailDataTable.GoodsNoColumn.ColumnName ) ||
                                                        ( col.Key == this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName ))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                }
                                                if (addUp_Prime)
                                                {
                                                    if (( col.Key == this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName ) ||
                                                        ( col.Key == this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName ))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                }

                                #endregion

                                //グリッド初期化の時、現在庫数(0)は空白で表示され処理を追加する
                                // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                                // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                                //if (string.IsNullOrEmpty(warehouseCode) && cell.Column.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                                //{
                                //    cell.Appearance.ForeColorDisabled = Color.Transparent;
                                //}
                                //if (string.IsNullOrEmpty(warehouseCode_Prime) && cell.Column.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                                //{
                                //    cell.Appearance.ForeColorDisabled = Color.Transparent;
                                //}
                                // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                                // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<

                                #region セル背景色変更

                                if (( cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled ) &&
                                    ( cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled ))
                                {
                                    if (rowStatus == EstimateInputAcs.ctROWSTATUS_COPY)
                                    {
                                        cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                                        //行ステータスがコピーの場合、倉庫コードが空白の時、現在庫数は空白で表示される
                                        //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode) && col.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                                        //{
                                        //    cell.Appearance.ForeColor = Color.Transparent;
                                        //}
                                        //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime) && col.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                                        //{
                                        //    cell.Appearance.ForeColor = Color.Transparent;
                                        //}
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                                    }
                                    else if (rowStatus == EstimateInputAcs.ctROWSTATUS_CUT)
                                    {
                                        cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                        cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                                        //行ステータスがカットの場合、倉庫コードが空白の時、現在庫数は空白で表示される
                                        //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode) && col.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                                        //{
                                        //    cell.Appearance.ForeColor = Color.Transparent;
                                        //}
                                        //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime) && col.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                                        //{
                                        //    cell.Appearance.ForeColor = Color.Transparent;
                                        //}
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

                                        if (( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ) ||
                                            ( cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ))
                                        {
                                            cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                        }
                                        else
                                        {
                                            cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.BackColor;
                                        }
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                                        // 現在庫数
                                        //倉庫がある場合のみ、現在庫数がｾﾞﾛに表示される
                                        //if (col.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                                        //{
                                        //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode.Trim()))
                                        //    {
                                        //        cell.Appearance.ForeColor = Color.Transparent;
                                        //    }
                                        //    else
                                        //    {
                                        //        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                        //    }
                                        //}
                                        //// 現在庫数（優良）
                                        ////倉庫がある場合のみ、現在庫数（優良）がｾﾞﾛに表示される
                                        //if (col.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                                        //{
                                        //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime.Trim()))
                                        //    {
                                        //        cell.Appearance.ForeColor = Color.Transparent;
                                        //    }
                                        //    else
                                        //    {
                                        //        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                        //    }
                                        //}
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                                    }
                                }

                                #endregion

                                #region アイコン表示

                                // オープン価格
                                if (col.Key == this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName)
                                {
                                    this.DisplayOpenPrice(rowIndex);
                                }
                                // オープン価格（優良）
                                if (col.Key == this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName)
                                {
                                    this.DisplayOpenPrice_Prime(rowIndex);
                                }

                                // セット
                                if (col.Key == this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName)
                                {
                                    this.DisplayExistSetInfo(rowIndex);
                                }
                                // セット（優良）
                                if (col.Key == this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName)
                                {
                                    this.DisplayExistSetInfo_Prime(rowIndex);
                                }
                                // 発注
                                if (col.Key == this._estimateDetailDataTable.OrderSelectColumn.ColumnName)
                                {
                                    this.DisplayOrderSelectInfo(rowIndex);
                                }
                                // 発注（優良）
                                if (col.Key == this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName)
                                {
                                    this.DisplayOrderSelectInfoPrime(rowIndex);
                                }
                                #endregion
                            }

                            break;
                        }
                    #endregion

                    #region ●品番検索
                    case 1:
                        {
                            // 行番号を取得
                            int salesRowNo = this._estimateDetailDataTable[rowIndex].SalesRowNo;

                            // BL商品コード(純正)
                            int blGoodsCode = this._estimateDetailDataTable[rowIndex].BLGoodsCode;

                            // BL商品コード(優良)
                            int blGoodsCode_Prime = this._estimateDetailDataTable[rowIndex].BLGoodsCode_Prime;

                            // 品名(純正)
                            string goodsName = this._estimateDetailDataTable[rowIndex].GoodsName;

                            // 品名(優良)
                            string goodsName_Prime = this._estimateDetailDataTable[rowIndex].GoodsName_Prime;

                            // 品番(純正)
                            string goodsNo = this._estimateDetailDataTable[rowIndex].GoodsNo;

                            // 品番(優良)
                            string goodsNo_Prime = this._estimateDetailDataTable[rowIndex].GoodsNo_Prime;

                            // 純正品番計上フラグ
                            bool addUp_Pure = ( this._estimateDetailDataTable[rowIndex].AlreadyAddUpCnt != 0 );

                            // 優良品番計上フラグ
                            bool addUp_Prime = ( this._estimateDetailDataTable[rowIndex].AlreadyAddUpCnt_Prime != 0 );

                            // 変更可能ステータスを取得
                            int editStatus = this._estimateDetailDataTable[rowIndex].EditStatus;

                            // 行ステータスを取得
                            int rowStatus = this._estimateDetailDataTable[rowIndex].RowStatus;

                            // 指定行の全ての列に対して設定を行う。
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                            {
                                // セル情報を取得
                                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                                if (cell == null) continue;

                                cell.Row.Hidden = false;

                                // アンダーラインを全てのセルに対して非表示とする
                                cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                                #region 伝票入力モード：読取専用
                                if (salesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly)
                                {
                                    if (cell.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                }
                                #endregion

                                #region 伝票入力モード：通常
                                else
                                {
                                    #region 明細入力モード：全項目無効
                                    if (editStatus == EstimateInputAcs.ctEDITSTATUS_AllDisable)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                    #endregion

                                    #region 明細入力モード：全項目読み取り専用
                                    else if (editStatus == EstimateInputAcs.ctEDITSTATUS_AllReadOnly)
                                    {
                                    }
                                    #endregion

                                    #region 明細入力モード：計上されている
                                    //else if (editStatus == EstimateInputAcs.ctEDITSTATUS_AddUped)
                                    //{
                                    //    // 品番・メーカーは入力不可
                                    //    if (( col.Key == this._estimateDetailDataTable.GoodsNoColumn.Caption ) ||
                                    //        ( col.Key == this._estimateDetailDataTable.GoodsMakerCdColumn.Caption ))
                                    //    {
                                    //        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    //    }
                                    //    else
                                    //    {
                                    //        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    //    }
                                    //}
                                    #endregion

                                    #region 明細入力モード：通常
                                    else
                                    {
                                        // 品番検索時は品番が常に入力常時可能
                                        if (( col.Key == this._estimateDetailDataTable.GoodsNoColumn.ColumnName ) ||
                                            ( col.Key == this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                        }
                                        // 品番任意入力の場合は、品名、品名(優良)は常時入力可能
                                        else if (( this._estimateInputInitDataAcs.InputMode != EstimateInputInitDataAcs.ctINPUTMODE_GoodsNoNecessary ) &&
                                                 ( ( col.Key == this._estimateDetailDataTable.GoodsNameColumn.ColumnName ) || ( col.Key == this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName ) ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                        }
                                        // 上記以外
                                        else
                                        {
                                            // 品番必須で、品番、品番(優良)が入力されていない
                                            // もしくは、品番任意で、品番、品番(優良)、品名、品名(優良)が入力されていない
                                            if (( ( this._estimateInputInitDataAcs.InputMode == EstimateInputInitDataAcs.ctINPUTMODE_GoodsNoNecessary ) && ( string.IsNullOrEmpty(goodsNo) ) && ( string.IsNullOrEmpty(goodsNo_Prime) ) ) ||
                                                ( ( this._estimateInputInitDataAcs.InputMode != EstimateInputInitDataAcs.ctINPUTMODE_GoodsNoNecessary ) && ( string.IsNullOrEmpty(goodsNo) ) && ( string.IsNullOrEmpty(goodsNo_Prime) && ( string.IsNullOrEmpty(goodsName) ) && ( string.IsNullOrEmpty(goodsName_Prime) ) ) ))
                                            {
                                                // 全て入力不可
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                            }
                                            else
                                            {


                                                if (addUp_Pure)
                                                {
                                                    if (( col.Key == this._estimateDetailDataTable.GoodsNoColumn.ColumnName ) ||
                                                        ( col.Key == this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName ))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                }
                                                if (addUp_Prime)
                                                {
                                                    if (( col.Key == this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName ) ||
                                                        ( col.Key == this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName ))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                }

                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                            }
                                        }
                                    }
                                    #endregion
                                }

                                #endregion

                                #region セル背景色変更

                                if (( cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled ) &&
                                    ( cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled ))
                                {
                                    if (rowStatus == EstimateInputAcs.ctROWSTATUS_COPY)
                                    {
                                        cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                                        //行ステータスがコピーの場合、倉庫コードが空白の時、現在庫数は空白で表示される
                                        //if ( string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode) && col.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                                        //{
                                        //    cell.Appearance.ForeColor = Color.Transparent;
                                        //}
                                        //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime) && col.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                                        //{
                                        //    cell.Appearance.ForeColor = Color.Transparent;
                                        //}
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                                    }
                                    else if (rowStatus == EstimateInputAcs.ctROWSTATUS_CUT)
                                    {
                                        cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                        cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                                        //行ステータスがカットの場合、倉庫コードが空白の時、現在庫数は空白で表示される
                                        //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode) && col.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                                        //{
                                        //    cell.Appearance.ForeColor = Color.Transparent;
                                        //}
                                        //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime) && col.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                                        //{
                                        //    cell.Appearance.ForeColor = Color.Transparent;
                                        //}
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

                                        if (( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ) ||
                                            ( cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ))
                                        {
                                            cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                        }
                                        else
                                        {
                                            cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.BackColor;
                                        }
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                                        // 現在庫数
                                        //倉庫がある場合のみ、現在庫数がｾﾞﾛに表示される
                                        //if (col.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
                                        //{
                                        //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode.Trim()))
                                        //    {
                                        //        cell.Appearance.ForeColor = Color.Transparent;
                                        //    }
                                        //    else
                                        //    {
                                        //        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                        //    }
                                        //}
                                        //// 現在庫数（優良）
                                        ////倉庫がある場合のみ、現在庫数（優良）がｾﾞﾛに表示される
                                        //if (col.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
                                        //{
                                        //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime.Trim()))
                                        //    {
                                        //        cell.Appearance.ForeColor = Color.Transparent;
                                        //    }
                                        //    else
                                        //    {
                                        //        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                        //    }
                                        //}
                                        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                                        // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                                    }
                                }

                                #endregion

                                #region アイコン表示

                                // オープン価格
                                if (col.Key == this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName)
                                {
                                    this.DisplayOpenPrice(rowIndex);
                                }
                                // オープン価格（優良）
                                if (col.Key == this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName)
                                {
                                    this.DisplayOpenPrice_Prime(rowIndex);
                                }

                                // セット
                                if (col.Key == this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName)
                                {
                                    this.DisplayExistSetInfo(rowIndex);
                                }
                                // セット（優良）
                                if (col.Key == this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName)
                                {
                                    this.DisplayExistSetInfo_Prime(rowIndex);
                                }
                                // 発注
                                if (col.Key == this._estimateDetailDataTable.OrderSelectColumn.ColumnName)
                                {
                                    this.DisplayOrderSelectInfo(rowIndex);
                                }
                                // 発注（優良）
                                if (col.Key == this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName)
                                {
                                    this.DisplayOrderSelectInfoPrime(rowIndex);
                                }
                                #endregion
                            }

                            break;
                        }
                    #endregion
                }
            }
		}

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			this.uButton_RowInsert.ImageList = this._imageList16;
			this.uButton_RowDelete.ImageList = this._imageList16;
			this.uButton_RowCut.ImageList = this._imageList16;
			this.uButton_RowCopy.ImageList = this._imageList16;
			this.uButton_RowPaste.ImageList = this._imageList16;
			this.uButton_Guide.ImageList = this._imageList16;

            this.uButton_EstimateReference.ImageList = this._imageList16;
            this.uButton_SetDisplay.ImageList = this._imageList16;
            this.uButton_TBO.ImageList = this._imageList16;
            this.uButton_WarehouseChange.ImageList = this._imageList16;

			//this.uButton_RowInsert.Appearance.Image = (int)Size16_Index.ROWINSERT;
			//this.uButton_RowDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;
			//this.uButton_RowCut.Appearance.Image = (int)Size16_Index.ROWCUT;
			//this.uButton_RowCopy.Appearance.Image = (int)Size16_Index.ROWCOPY;
			//this.uButton_RowPaste.Appearance.Image = (int)Size16_Index.ROWPASTE;
			this.uButton_Guide.Appearance.Image = (int)Size16_Index.GUIDE;

			this.uButton_RowInsert.Enabled = false;
			this.uButton_RowDelete.Enabled = false;
			this.uButton_RowCut.Enabled = false;
			this.uButton_RowCopy.Enabled = false;
			this.uButton_RowPaste.Enabled = false;
			this.uButton_Guide.Enabled = false;

            this.uButton_EstimateReference.Enabled = false;
            this.uButton_SetDisplay.Enabled = false;
            this.uButton_TBO.Enabled = false;
            this.uButton_WarehouseChange.Enabled = false;
            
			this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
			this._rowInsertButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWINSERT;
			this._rowDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
			this._rowCutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCUT;
			this._rowCopyButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCOPY;
			this._rowPasteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWPASTE;

            this.uButton_NextCandidate.Enabled = false; //ADD 2010/08/05
            this.uButton_AllCandidate.Enabled = true; //ADD 2010/08/05
		}

		/// <summary>
		/// ツールチップ初期設定処理
		/// </summary>
		private void ToolTipInfoInitialSetting()
		{
			Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo_uGrid_Details = this.uToolTipManager_Information.GetUltraToolTip(this.uGrid_Details);
			ultraToolTipInfo_uGrid_Details.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
			ultraToolTipInfo_uGrid_Details.ToolTipTitle = "";
			ultraToolTipInfo_uGrid_Details.ToolTipText = "";
			ultraToolTipInfo_uGrid_Details.Appearance.FontData.Name = "ＭＳ ゴシック";
			this.uToolTipManager_Information.SetUltraToolTip(this.uGrid_Details, ultraToolTipInfo_uGrid_Details);

			Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo_uGrid_Details2 = this.uToolTipManager_Hint.GetUltraToolTip(this.uGrid_Details);
			ultraToolTipInfo_uGrid_Details2.ToolTipImage = Infragistics.Win.ToolTipImage.None;
			ultraToolTipInfo_uGrid_Details2.ToolTipTitle = "";
			ultraToolTipInfo_uGrid_Details2.ToolTipText = "";
			ultraToolTipInfo_uGrid_Details2.Appearance.FontData.Name = "ＭＳ ゴシック";
			this.uToolTipManager_Hint.SetUltraToolTip(this.uGrid_Details, ultraToolTipInfo_uGrid_Details2);
		}

		/// <summary>
		/// グリッドキーマッピング設定処理
		/// </summary>
		/// <param name="grid">設定対象のグリッド</param>
		private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
		{
			Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

			//----- Enterキー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Enter,
				Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- Shift + Enterキー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Enter,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
				Infragistics.Win.SpecialKeys.AltCtrl,
				Infragistics.Win.SpecialKeys.Shift,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

            ////----- Ctrl + Homeキー
            //enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //    Keys.Home,
            //    Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid,
            //    0,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
            //    Infragistics.Win.SpecialKeys.AltShift,
            //    Infragistics.Win.SpecialKeys.Ctrl,
            //    true);
            //this.uGrid_Details.KeyActionMappings.Add(enterMap);

            ////----- Ctrl + Endキー
            //enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //    Keys.End,
            //    Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid,
            //    0,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
            //    Infragistics.Win.SpecialKeys.AltShift,
            //    Infragistics.Win.SpecialKeys.Ctrl,
            //    true);
            //this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- ↑キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Up,
				Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Up,
				Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Down,
				Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- ↓キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Down,
				Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- 前頁キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Prior,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);

			//----- 次頁キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Next,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0,
				true);
			this.uGrid_Details.KeyActionMappings.Add(enterMap);
		}

		/// <summary>
		/// 明細パターンコンボボックスアイテム生成処理
		/// </summary>
		private void DetailPatternComboBoxItemSetting()
		{
			this._detailPatternComboBox.ValueList.ValueListItems.Clear();
			SortedDictionary<int, EstmDtlPtnInfo> estmDtlPtnInfoDictionary = this._estimateInputConstructionAcs.EstimateDetailPatternInfoDictionary;

			Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
			foreach (int patternOrder in estmDtlPtnInfoDictionary.Keys)
			{
				Infragistics.Win.ValueListItem dtlPtnInfoItem = new Infragistics.Win.ValueListItem();
				dtlPtnInfoItem.DataValue = patternOrder;
				dtlPtnInfoItem.DisplayText = estmDtlPtnInfoDictionary[patternOrder].PatternName;
				valueList.ValueListItems.Add(dtlPtnInfoItem);
			}

			if (valueList != null)
			{
				this._detailPatternComboBox.ValueList = valueList;
				this._detailPatternComboBox.ValueList.MaxDropDownItems = this._detailPatternComboBox.ValueList.ValueListItems.Count;
			}
		}

		/// <summary>
		/// コンボボックスツールアイテムインデックス設定処理
		/// </summary>
		/// <param name="sender">対象コンボボックスツール</param>
		/// <param name="dataValue">設定値</param>
		/// <param name="defaultIndex">初期値</param>
		private void SetComboBoxToolValue( Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, int dataValue, int defaultIndex )
		{
			bool isSetting = false;

			if (sender.ValueList.ValueListItems.Count > 0)
			{
				sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

				// 1つしかない場合は先頭を選択
				if (sender.ValueList.ValueListItems.Count == 1)
				{
					sender.SelectedIndex = 0;
					isSetting = true;
				}
				else
				{
					for (int i = 0; i < sender.ValueList.ValueListItems.Count; i++)
					{
						if (( sender.ValueList.ValueListItems[i].DataValue is int ) && ( (int)sender.ValueList.ValueListItems[i].DataValue == dataValue ))
						{
							sender.Value = dataValue;
							isSetting = true;
							break;
						}
					}
				}

				if (!isSetting)
				{
					sender.SelectedIndex = defaultIndex;
				}
			}
		}

        /// <summary>
        /// コンボボックスツール設定処理
        /// </summary>
        /// <param name="sender">対象コンボボックスツール</param>
        /// <param name="dataValue">設定値</param>
        /// <param name="defaultIndex">初期値</param>
        private int GetComboBoxToolValue( Infragistics.Win.UltraWinToolbars.ComboBoxTool sender)
        {
            return TStrConv.StrToIntDef(sender.ValueList.ValueListItems[sender.SelectedIndex].DataValue.ToString().Trim(), 0);
        }

		/// <summary>
		/// 選択済み行番号リスト取得処理
		/// </summary>
		/// <returns>選択済み行番号リスト</returns>
		private List<int> GetSelectedSalesRowNoList()
		{
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
			Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
			if ((cell == null) && (rows == null)) return null;

			List<int> selectedSalesRowNoList = new List<int>();
			List<int> selectedIndexList = new List<int>();
			
			if (cell != null)
			{
				selectedSalesRowNoList.Add(this._estimateDetailDataTable[cell.Row.Index].SalesRowNo);
				selectedIndexList.Add(cell.Row.Index);
			}
			else if (rows != null)
			{
				foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
				{
					selectedSalesRowNoList.Add(this._estimateDetailDataTable[row.Index].SalesRowNo);
					selectedIndexList.Add(row.Index);
				}
			}

			return selectedSalesRowNoList;
		}

        /// <summary>
        /// アクティブセル変更
        /// </summary>
        /// <param name="mode">0:無条件で検索モード、部品検索タイプによって変更</param>
        internal void ChangeActiveCell( int mode )
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
                bool setFirstCell=false;
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                if (mode == 0)
                {
                    int salesRowNo = this._estimateDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].SalesRowNo;
                    string activeCellKey = string.Empty;
                    int rowIndex=this.uGrid_Details.ActiveCell.Row.Index;

                    // フォーカス行が未入力行の場合のみ処理する
                    if (!this._estimateInputAcs.ExistDetailInput(salesRowNo))
                    {

                        // 部品検索モード
                        if (this._estimateInputAcs.SalesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                        {
                            // 表示中の画面タイプによってアクティブセルを変更する
                            switch (this._estmDtlPtnInfo.PartsSearchType)
                            {
                                // 純正部品検索
                                case EstmDtlPtnInfo.SearchType.Pure:
                                    activeCellKey = this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName;
                                    break;
                                // 優良部品検索
                                case EstmDtlPtnInfo.SearchType.Prime:
                                    activeCellKey = this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName;
                                    break;
                                // 無し
                                case EstmDtlPtnInfo.SearchType.None:
                                    setFirstCell = true;
                                    break;
                            }
                        }
                        // 品番入力モード
                        else
                        {
                            // 表示中の画面タイプによってアクティブセルを変更する
                            switch (this._estmDtlPtnInfo.PartsSearchType)
                            {
                                // 純正部品検索
                                case EstmDtlPtnInfo.SearchType.Pure:
                                    activeCellKey = this._estimateDetailDataTable.GoodsNoColumn.ColumnName;
                                    break;
                                // 優良部品検索
                                case EstmDtlPtnInfo.SearchType.Prime:
                                    activeCellKey = this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName;
                                    break;
                                // 無し
                                case EstmDtlPtnInfo.SearchType.None:
                                    setFirstCell = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        setFirstCell = true;
                    }

                    if (setFirstCell)
                    {
                        activeCellKey = this.GetFirstCell(this._estmDtlPtnInfo.EstimateDetailColInfoList, false);
                    }
                    if (( !string.IsNullOrEmpty(activeCellKey) ) && ( !editBand.Columns[activeCellKey].Hidden ) )
                    {

                        switch (this.uGrid_Details.Rows[rowIndex].Cells[activeCellKey].Activation)
                        {
                            case Infragistics.Win.UltraWinGrid.Activation.AllowEdit:
                            case Infragistics.Win.UltraWinGrid.Activation.NoEdit:
                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[activeCellKey].Activated = true;
                                break;
                            default:
                                this.uGrid_Details.ActiveCell = null;
                                break;
                        }
                    }
                    else
                    {
                        this.uGrid_Details.ActiveCell = null;
                    }
                }
                else
                {
                }

                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ContainsFocus ))
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
        }

		/// <summary>
		/// ActiveRowインデックス取得処理
		/// </summary>
		/// <returns>ActiveRowインデックス</returns>
		private int GetActiveRowIndex()
		{
			if (this.uGrid_Details.ActiveCell != null)
			{
				return this.uGrid_Details.ActiveCell.Row.Index;
			}
			else if (this.uGrid_Details.ActiveRow != null)
			{
				return this.uGrid_Details.ActiveRow.Index;
			}
			else
			{
				return -1;
			}
		}

        /// <summary>
        /// ActiveRowの行番号取得処理
        /// </summary>
        /// <returns></returns>
        internal int GetActiveRowSalesRowNo()
        {
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex < 0) return -1;

			return this._estimateDetailDataTable[rowIndex].SalesRowNo;
            //return rowIndex;
        }

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		internal void Clear()
		{
			// 仕入明細DataTable行クリア処理
			//this._estimateDetailDataTable.Rows.Clear();

			// グリッド行初期設定処理
			this._estimateInputAcs.EstimateDetailRowInitialSetting(this._estimateInputConstructionAcs.EstimateInputConstruction.DataInputCountValue);

			// 明細グリッドセル設定処理
			this.SettingGrid();
		}

		/// <summary>
		/// 仕入数量０行削除処理
		/// </summary>
		/// <param name="changeRowCount">true:行数を変更する false:行数を変更しない</param>
		/// <returns>true:削除した,false:削除していない</returns>
		internal bool DeleteStockCountZeroRow(bool changeRowCount)
		{
			bool ret = false;
			List<int> deleteSalesRowNoList = this._estimateInputAcs.GetStockCountZeroSalesRowNoList();

			if (deleteSalesRowNoList.Count > 0)
			{
				// 仕入明細行削除処理
				this._estimateInputAcs.DeleteEstimateDetailRow(deleteSalesRowNoList, changeRowCount);

				ret = true;
			}

			return ret;
		}

		/// <summary>
		/// 空白行削除処理
		/// </summary>
		/// <param name="changeRowCount">true:行数を変更する false:行数を変更しない</param>
		internal void DeleteEmptyRow(bool changeRowCount)
		{
			List<int> deleteSalesRowNoList = this._estimateInputAcs.GetEmptySalesRowNoList();

			if (deleteSalesRowNoList.Count > 0)
			{
				// 仕入明細行削除処理
				this._estimateInputAcs.DeleteEstimateDetailRow(deleteSalesRowNoList, changeRowCount);
			}
		}

		/// <summary>
		/// ユーザー設定値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void EstimateInputConstructionAcs_DataChanged(object sender, EventArgs e)
		{
			// グリッド列設定処理（ユーザー設定より）
			this.GridSetting(this._estimateInputConstructionAcs.EstimateInputConstruction);

			#region 明細表示パターンの再設定

			this.tToolbarsManager_Main.ToolValueChanged -= this.tToolbarsManager_Main_ToolValueChanged;

			// 明細パターンコンボボックスツールを再設定
			this.DetailPatternComboBoxItemSetting();

			EstmDtlPtnInfo newEstmDtlPtnInfo = this._estimateInputConstructionAcs.GetEstmDtlPtnInfo(this._estmDtlPtnInfo.PatternGuid);

			if (newEstmDtlPtnInfo != null)
			{
				// 明細パターンの選択値を再設定
				this.SetComboBoxToolValue(this._detailPatternComboBox, newEstmDtlPtnInfo.PatternOrder, 0);

                Infragistics.Win.UltraWinToolbars.ToolEventArgs eventArges = new Infragistics.Win.UltraWinToolbars.ToolEventArgs(this.tToolbarsManager_Main.Tools["ComboBoxTool_DetailPattern"]);
                this.tToolbarsManager_Main_ToolValueChanged(sender, eventArges);
			}
            this.tToolbarsManager_Main.ToolValueChanged += this.tToolbarsManager_Main_ToolValueChanged;

            //this._estmDtlPtnInfo = newEstmDtlPtnInfo;

			#endregion
		}

        /// <summary>
        /// 優良情報の選択データが変更された場合に発生します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeInfoSelectChanged( object sender, EventArgs e )
        {
            this.DisplayExistSetInfo_Prime(this.GetActiveRowIndex());
            this.DisplayOpenPrice_Prime(this.GetActiveRowIndex());
            this.SettingGridRow(this.GetActiveRowIndex(), this._estimateInputAcs.SalesSlip);
        }

		/// <summary>
		/// フォーカス設定イベントコール処理
		/// </summary>
		/// <param name="name">項目名称</param>
		private void SettingFocusEventCall(string itemName)
		{
			if (this.FocusSetting != null)
			{
				this.FocusSetting(this, itemName);
			}
		}

		/// <summary>
		/// フッター部設定イベントコール処理
		/// </summary>
		/// <param name="salesRowNo">行番号</param>
		private void SettingFooterEventCall( int salesRowNo )
		{
			if (this.SettingFooter != null)
			{
				this.SettingFooter(salesRowNo);
			}
		}

		/// <summary>
		/// フッター部設定イベントコール処理
		/// </summary>
		internal void SettingFooterEventCall()
		{
			this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());
		}

        /// <summary>
        /// 車輌情報設定イベントコール処理
        /// </summary>
        private void SettingCarInfoEventCall( Int32 salesRowNo )
        {
            if (( this.SettingCarInfo != null ) && ( salesRowNo != -1 ))
            {
                this.SettingCarInfo(this, salesRowNo);
            }
        }


		/// <summary>
		/// 数値入力チェック処理
		/// </summary>
		/// <param name="keta">桁数(マイナス符号を含まず)</param>
		/// <param name="priod">小数点以下桁数</param>
		/// <param name="prevVal">現在の文字列</param>
		/// <param name="key">入力されたキー値</param>
		/// <param name="selstart">カーソル位置</param>
		/// <param name="sellength">選択文字長</param>
		/// <param name="minusFlg">マイナス入力可？</param>
		/// <returns>true=入力可,false=入力不可</returns>
		private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// 制御キーが押された？
			if (Char.IsControl(key))
			{
				return true;
			}
			// 数値以外は、ＮＧ
			if (!Char.IsDigit(key))
			{
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

			// キーが押されたと仮定した場合の文字列を生成する。
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// マイナスのチェック
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// 小数点のチェック
			if (key == '.')
			{
				if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// キーが押された結果の文字列を生成する。
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// 桁数チェック！
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// 小数点以下のチェック
			if (priod > 0)
			{
				// 小数点の位置決定
				int _pointPos = _strResult.IndexOf('.');

				// 整数部に入力可能な桁数を決定！
				int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// 整数部の桁数をチェック
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// 小数部の桁数をチェック
				if (_pointPos != -1)
				{
					// 小数部の桁数を計算
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}

        /// <summary>
        /// 表示行数取得処理
        /// </summary>
        /// <returns>表示行数</returns>
        private int GetVisibleRowCount()
        {
            int count = 0;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
            {
                if (!row.Hidden)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// アクティブセルのボタンの有効無効をコントロールします。
        /// </summary>
        internal void ActiveCellButtonEnabledControl()
        {
            int rowIndex = -1;
            string colKey = string.Empty;

            if (this.uGrid_Details.ActiveCell == null)
            {
                if (this.uGrid_Details.ActiveRow == null)
                {
                    return;
                }
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                colKey = this.uGrid_Details.ActiveCell.Column.Key;
            }
            if (rowIndex >= 0)
            {
                this.ActiveCellButtonEnabledControl(rowIndex, colKey);
            }
        }

		/// <summary>
		/// セルアクティブ時ボタン有効無効コントロール処理
		/// </summary>
		/// <param name="index">行インデックス</param>
		/// <param name="colKey">セルキー文字列</param>
		private void ActiveCellButtonEnabledControl( int index, string colKey )
		{
			foreach (Infragistics.Win.Misc.UltraButton uButton in this._buttonList)
			{
				uButton.BeginUpdate();
			}

			EstimateInputDataSet.EstimateDetailRow row = this._estimateInputAcs.EstimateDetailDataTable[index];

			if ( this._estimateInputAcs.SalesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly ) 
			{
				this.uButton_RowInsert.Enabled = false;
				this.uButton_RowDelete.Enabled = false;
				this.uButton_RowCut.Enabled = false;
				this.uButton_RowCopy.Enabled = false;

				this.uButton_Guide.Enabled = false;

                this.uButton_SetDisplay.Enabled = false;
                this.uButton_WarehouseChange.Enabled = false;
                this.uButton_EstimateReference.Enabled = false;
                this.uButton_WarehouseChange.Enabled = false;
                this.uButton_TBO.Enabled = false;
			}
			else
			{
				// 行操作ボタンの有効無効を設定する
				string goodsCode = row.GoodsNo;
				string goodsName = row.GoodsName;
                double stockCount = row.ShipmentCnt;
				int editStatus = row.EditStatus;
				
				// 行操作ボタンの有効無効チェック
				if (( goodsName == "" ) && ( goodsCode == "" ))
				{
					this.uButton_RowInsert.Enabled = true;
					this.uButton_RowDelete.Enabled = true;
					this.uButton_RowCut.Enabled = false;
					this.uButton_RowCopy.Enabled = false;
					}
				else if (editStatus == EstimateInputAcs.ctEDITSTATUS_AllReadOnly)
				{
					this.uButton_RowInsert.Enabled = true;
					this.uButton_RowDelete.Enabled = false;
					this.uButton_RowCut.Enabled = false;
					this.uButton_RowCopy.Enabled = false;
				}
				else
				{
					this.uButton_RowInsert.Enabled = true;
					this.uButton_RowDelete.Enabled = true;
					this.uButton_RowCut.Enabled = true;
					this.uButton_RowCopy.Enabled = true;
				}

				// コピー仕入明細行存在チェック処理
				if (( this._estimateInputAcs.ExistCopyEstimateDetailRow() ) && ( editStatus != EstimateInputAcs.ctEDITSTATUS_AllReadOnly ))
				{
					this.uButton_RowPaste.Enabled = true;
				}
				else
				{
					this.uButton_RowPaste.Enabled = false;
				}

                // 入力補助ボタンの有効無効チェック
                this.uButton_WarehouseChange.Enabled = true;
                this.uButton_EstimateReference.Enabled = true;
                this.uButton_WarehouseChange.Enabled = true;
                this.uButton_TBO.Enabled = true;

                if (this._estimateInputAcs.SalesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                {
                    
                    this.uButton_ChangeCarInfo.Enabled = !(this._estimateInputAcs.ExistDetailInput(row));
                }
                else
                {
                    this.uButton_ChangeCarInfo.Enabled = false;
                }

                
                if (colKey != null)
                {

                    if (this._guideDspCellList.Contains(colKey))
                    {
                        this.uButton_Guide.Enabled = true;
                        this.uButton_Guide.Tag = colKey;
                    }
                    else
                    {
                        this.uButton_Guide.Enabled = false;
                    }
                }

                // フォーカス位置によって有効無効が変わるボタンの制御
                switch (this._estimateInputColInfoInitialSetting.GetAttr(colKey))
                {
                    // 純正部品
                    case ColDisplayBasicInfo.DataAttribute.PureParts:
                        {
                            // 倉庫切替
                            this.uButton_WarehouseChange.Enabled = this._estimateInputAcs.ExistStockInfo(row.GoodsNo, row.GoodsMakerCd);
                            // セット
                            this.uButton_SetDisplay.Enabled = row.ExistSetInfo;

                            break;
                        }
                    // 優良部品
                    case ColDisplayBasicInfo.DataAttribute.PrimeParts:
                        {
                            // 倉庫切替
                            this.uButton_WarehouseChange.Enabled = this._estimateInputAcs.ExistStockInfo(row.GoodsNo_Prime, row.GoodsMakerCd_Prime);
                            // セット
                            this.uButton_SetDisplay.Enabled = row.ExistSetInfo_Prime;

                            break;
                        }
                    // 無し、その他
                    case ColDisplayBasicInfo.DataAttribute.None:
                    default:
                        {
                            this.uButton_WarehouseChange.Enabled = false;
                            this.uButton_SetDisplay.Enabled = false;
                            break;
                        }
                }
                if (colKey == this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName)
                {
                    this.uButton_Guide.Enabled = ( !string.IsNullOrEmpty(row.GoodsNo) && ( row.GoodsMakerCd != 0 ) );
                }
                if (colKey == this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName)
                {
                    this.uButton_Guide.Enabled = ( !string.IsNullOrEmpty(row.GoodsNo_Prime) && ( row.GoodsMakerCd_Prime != 0 ) );
                }

			}


			foreach (Infragistics.Win.Misc.UltraButton uButton in this._buttonList)
			{
				uButton.EndUpdate();
			}

			if (this.SetToolbarButton != null)
			{
				this.SetToolbarButton();
			}

            // --- ADD 2010/08/05 ---------->>>>>
            if (this._estimateInputAcs.isCanCandidateSetting(row.SalesRowNo))
            {
                this.uButton_NextCandidate.Enabled = true;
            }
            else
            {
                this.uButton_NextCandidate.Enabled = false;
            }
            // --- ADD 2010/08/05 ----------<<<<<
		}



		/// <summary>
		/// セルの編集モードを一度解除し、再度編集モードに設定します。
		/// </summary>
		internal void CellExitEnterEditEnter()
		{
			if (this.uGrid_Details.ActiveCell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

			this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

			if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
				(cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
			{
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
			}
		}

		/// <summary>
		/// 列表示状態クラスリスト構築処理
		/// </summary>
		/// <param name="columns">グリッドのカラムコレクション</param>
		/// <returns>列表示状態クラスリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.05.31</br>
		/// </remarks>
		private List<ColDisplayStatus> ColDisplayStatusListConstruction( Infragistics.Win.UltraWinGrid.ColumnsCollection columns )
		{
			List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

			// グリッドから列表示状態クラスリストを構築
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

				colDisplayStatus.Key = column.Key;  
				colDisplayStatus.Width = column.Width;          //
				colDisplayStatusList.Add(colDisplayStatus);
			}

			return colDisplayStatusList;
		}

		/// <summary>
		/// 最終入力行Index取得処理
		/// </summary>
		/// <returns>最終入力行Index</returns>
		private int GetLastInputRowIndex()
		{
			int lastInputRowIndex = 0;

			for (int i = this.uGrid_Details.Rows.Count - 1; i >= 0; i--)
			{
				if (this.uGrid_Details.Rows[i].Hidden) continue;

				if (this.uGrid_Details.Rows[i].Cells[this._estimateDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString() != "")
				{
					lastInputRowIndex = i;
					break;
				}
			}

			return lastInputRowIndex;
		}

		/// <summary>
		/// 見積履歴検索
		/// </summary>
		internal void EstimateReferenceSearch()
		{
			this.uButton_EstimateReference_Click(this.uGrid_Details, new EventArgs());
		}

		/// <summary>
		/// ガイド起動処理
		/// </summary>
		internal void ExecuteGuide()
		{
			this.uButton_Guide_Click(this.uGrid_Details, new EventArgs());
		}

        /// <summary>
        /// セット表示処理
        /// </summary>
        internal void ShowSetWindow()
        {
            this.uButton_SetDisplay_Click(this.uGrid_Details, new EventArgs());
        }

		/// <summary>
		/// 明細パターンを次の順位に切り替えます
		/// </summary>
		internal void ChangeNextDetailPattern()
		{
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
            }

            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

			//this.tToolbarsManager_Main.ToolValueChanged -= this.tToolbarsManager_Main_ToolValueChanged;

			this._estmDtlPtnInfo = this._estimateInputConstructionAcs.GetNextEstmDtlPtnInfo(this._estmDtlPtnInfo.PatternOrder);

			// 明細パターンの選択値を再設定
			this.SetComboBoxToolValue(this._detailPatternComboBox, this._estmDtlPtnInfo.PatternOrder, 0);

			//// 明細パターンに従って画面を再描画
			//this.SettingGridColVisible(this._estmDtlPtnInfo);

			//this.tToolbarsManager_Main.ToolValueChanged += this.tToolbarsManager_Main_ToolValueChanged;

            //this.CellExitEnterEditEnter();
            //if (this.uGrid_Details.ActiveCell != null)
            //{
            //    //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
            //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            //}

		}

		#region ●商品検索関係

		/// <summary>
        /// 部品検索＋行設定処理
		/// </summary>
		/// <param name="rowIndex">行インデックス</param>
        /// <param name="targetData">対象データ</param>
		/// <returns></returns>
        private int SearchPartsAndRowSetting( int rowIndex, EstimateInputAcs.TargetData targetData )
        {
            int salesRowNo = this._estimateDetailDataTable[rowIndex].SalesRowNo;

            string goodsNo = ( targetData == EstimateInputAcs.TargetData.PrimeParts ) ? this._estimateDetailDataTable[rowIndex].GoodsNo_Prime : this._estimateDetailDataTable[rowIndex].GoodsNo;
            int makerCode = ( targetData == EstimateInputAcs.TargetData.PrimeParts ) ? this._estimateDetailDataTable[rowIndex].GoodsMakerCd_Prime : this._estimateDetailDataTable[rowIndex].GoodsMakerCd;

            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            List<int> settingSalesRowNoList = new List<int>();

            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList;
            //------UPD 2009/11/05------>>>>>
            PMKEN01010E searchCarInfo = this._estimateInputAcs.GetSearchCarInfoNew(salesRowNo);
            int status = this.SearchPartsFromGoodsNo(goodsNo, makerCode, GoodsCndtn.JoinSearchDivType.NoSearch, out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList, searchCarInfo);
            //------UPD 2009/11/05------<<<<<
            switch (status)
            {
                // 該当データ有り
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        if (( goodsUnitDataList != null ) && ( goodsUnitDataList.Count > 0 ))
                        {
                            if (targetData == EstimateInputAcs.TargetData.PureParts)
                            {
                                if (this._estimateInputAcs.EstimateDetailRowPurePartsSearchResultSetting(salesRowNo, EstimateInputAcs.GoodsSearchDiv.PartsNoSerach, goodsUnitDataList, partsInfoDataSet, unitPriceCalcRetList, false, out settingSalesRowNoList, true, 0) == EstimateInputAcs.DataSettingResult.OverRowCount)
                                {
                                }
                            }
                            else
                            {
                                this._estimateInputAcs.EstimateDetailRowPrimePartsSearchResultSetting(salesRowNo, EstimateInputAcs.GoodsSearchDiv.PartsNoSerach, goodsUnitDataList[0], partsInfoDataSet, unitPriceCalcRetList, out settingSalesRowNoList, 0);
                            }

                            // 明細グリッド設定処理
                            this.SettingGrid();

                            // 最終行に空行を追加
                            this.AddLastEmptyRow();
                        }

                        break;
                    }
                // キャンセル
                case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                    {
                        break;
                    }
                // 該当データ無し
                default:
                    {

                        break;
                    }
            }
            return status;
        }

		/// <summary>
		/// 部品検索（オーバーロード）
		/// </summary>
		/// <param name="goodsNo">商品コード</param>
        /// <param name="joinSearchDivType">結合検索タイプ</param>
        /// <param name="goodsUnitDataList">商品情報リスト</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="carInfo">車輌検索結果</param>
		/// <returns>0:検索OK、-1:キャンセル,-2:検索データ無し</returns>
        /// <remarks>
        /// <br>Update Note: 2009/11/05 呉元嘯</br>
        /// <br>             Redmine#1087対応</br>
        /// </remarks>
        private int SearchPartsFromGoodsNo( string goodsNo, GoodsCndtn.JoinSearchDivType joinSearchDivType, out List<GoodsUnitData> goodsUnitDataList, out PartsInfoDataSet partsInfoDataSet, out List<UnitPriceCalcRet> unitPriceCalcRetList, PMKEN01010E carInfo )
        {
            return this.SearchPartsFromGoodsNo(goodsNo, 0, joinSearchDivType, out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList, carInfo);
        }

        /// <summary>
        /// 部品検索（商品コード＋メーカー）（オーバーロード）
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="joinSearchDivType">結合検索タイプ</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="carInfo">車輌検索結果</param>
        /// <returns>0:検索OK、-1:キャンセル,-2:検索データ無し</returns>
        /// <remarks>
        /// <br>Update Note: 2009/11/05 呉元嘯</br>
        /// <br>             Redmine#1087対応</br>
        /// </remarks>
        private int SearchPartsFromGoodsNo( string goodsNo, int goodsMakerCd, GoodsCndtn.JoinSearchDivType joinSearchDivType, out List<GoodsUnitData> goodsUnitDataList, out PartsInfoDataSet partsInfoDataSet, out List<UnitPriceCalcRet> unitPriceCalcRetList, PMKEN01010E carInfo )
        {
            return this._estimateInputAcs.SearchPartsFromGoodsNo(this, this._enterpriseCode, this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd, goodsMakerCd, goodsNo, joinSearchDivType, out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList, carInfo);
        }

        /// <summary>
        /// BLコード検索
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="carInfo">車輌情報</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <returns>STATUS(ConstantManagement.MethodResult)</returns>
        private int BLPartsSearch( int blGoodsCode, PMKEN01010E carInfo, out List<GoodsUnitData> goodsUnitDataList, out PartsInfoDataSet partsInfoDataSet, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            return this._estimateInputAcs.SearchPartsFromBLCode(this, this._enterpriseCode, this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd, blGoodsCode, carInfo, this.GetComboBoxToolValue(this._partsSelectComboBox), out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList);
        }
        
        /// <summary>
        /// TBO検索
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <returns></returns>
        private int SearchTBO( int salesRowNo, out List<GoodsUnitData> goodsUnitDataList, out PartsInfoDataSet partsInfoDataSet, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            //-------------------------------------------------------------
            // 初期処理
            //-------------------------------------------------------------
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            PMKEN01010E searchCarInfo = this._estimateInputAcs.GetSearchCarInfo(salesRowNo);

            //-------------------------------------------------------------
            // TBO検索
            //-------------------------------------------------------------
            status = this._estimateInputAcs.SearchTBO(this, this._enterpriseCode, this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd, searchCarInfo, out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList);

            //-------------------------------------------------------------
            // TBO検索後処理
            //-------------------------------------------------------------
            if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) && ( goodsUnitDataList != null ) && ( goodsUnitDataList.Count > 0 ))
            {
            }
            else
            {
                return -2;
            }
            return 0;
        }


		#endregion

		/// <summary>
		/// オープン価格情報表示
		/// </summary>
		/// <param name="rowIndex"></param>
		private void DisplayOpenPrice( int rowIndex )
		{
            if (rowIndex == -1) return;

			if (this._estimateDetailDataTable[rowIndex] != null)
			{
                // 純正情報
				if ((Int32)this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OpenPriceDivColumn.ColumnName].Value == 1)
				{
					this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
				}
				else
				{
					this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName].Appearance.Image = null;
				}
            }
		}

        /// <summary>
        /// オープン価格情報表示（優良）
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayOpenPrice_Prime( int rowIndex )
        {
            if (rowIndex == -1) return;

            if (this._estimateDetailDataTable[rowIndex] != null)
            {
                // 優良情報
                if ((Int32)this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OpenPriceDiv_PrimeColumn.ColumnName].Value == 1)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName].Appearance.Image = null;
                }
            }
        }

        /// <summary>
        /// セット情報アイコン表示
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayExistSetInfo( int rowIndex )
        {
            if (rowIndex == -1) return;
            if (this._estimateDetailDataTable[rowIndex] != null)
            {
                if ((bool)this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.ExistSetInfoColumn.ColumnName].Value == true)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName].Appearance.Image = null;
                }
            }
        }

        /// <summary>
        /// セット情報アイコン表示（優良）
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayExistSetInfo_Prime( int rowIndex )
        {
            if (rowIndex == -1) return;
            if (this._estimateDetailDataTable[rowIndex] != null)
            {
                if ((bool)this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.ExistSetInfo_PrimeColumn.ColumnName].Value == true)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName].Appearance.Image = null;
                }
            }
        }

        /// <summary>
        /// 発注情報アイコン表示
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayOrderSelectInfo(int rowIndex)
        {
            if (rowIndex == -1) return;
            if (this._estimateDetailDataTable[rowIndex] != null)
            {
                if ( (Guid)(this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.UOEOrderGuidColumn.ColumnName].Value) != Guid.Empty )
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OrderSelectColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OrderSelectColumn.ColumnName].Appearance.Image = null;
                }
            }
        }

        /// <summary>
        /// 発注情報アイコン表示（優良）
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayOrderSelectInfoPrime(int rowIndex)
        {
            if (rowIndex == -1) return;
            if (this._estimateDetailDataTable[rowIndex] != null)
            {
                if ((Guid)( this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.UOEOrderGuid_PrimeColumn.ColumnName].Value) != Guid.Empty )
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName].Appearance.Image = null;
                }
            }
        }

		/// <summary>
		/// 最終行に空白行を追加します。
		/// </summary>
		private void AddLastEmptyRow()
		{
            //// 最終行に商品コード、商品名称が設定されている場合は１行追加
            //if (this._estimateInputAcs.ExistDetailInput(this._estimateDetailDataTable[this._estimateDetailDataTable.Count - 1]))
            //{
            //    this._estimateInputAcs.AddEstimateDetailRow();

            //    // 表示用行番号調整処理
            //    this._estimateInputAcs.AdjustRowNo();

            //    // 明細グリッド・行単位でのセル設定
            //    this.SettingGridRow(this._estimateDetailDataTable.Count - 1, this._estimateInputAcs.SalesSlip);
            //}
		}

        // --- ADD 2010/08/05 ---------->>>>>
        /// <summary>
        /// 「候補」処理を追加します。
		/// </summary>
        /// <param name="rowIndex"> 0:次候補、1:全候補</returns></param>
        /// <br>Update Note: 2011/12/19 鄧潘ハン</br>
        /// <br>           : データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正</br>
        internal void SetCandidate(int candidate)
        {
            int activeRowIndex = 0;
            this._estimateDetailDataTable.AcceptChanges();

            if (this.uGrid_Details.ActiveCell != null)
            {
                activeRowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Details.ActiveRow.Index;
            }
            if (candidate == 0)
            {
                if (this.uButton_NextCandidate.Enabled == true)
                {
                    this._estimateInputAcs.CandidateSetting(this._estimateDetailDataTable[activeRowIndex].SalesRowNo);
                }
            }
            else
            {
                if (this.uButton_AllCandidate.Enabled == true)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        this._estimateInputAcs.GoodsEstimateNo = this._estimateDetailDataTable[row.Index].GoodsNo; // ADD 鄧潘ハン 2011/12/19 Redmine#8034
                        this._estimateInputAcs.CandidateSetting(this._estimateDetailDataTable[row.Index].SalesRowNo);
                    }
                }
            }

            this.CellExitEnterEditEnter();
        }

        // --- ADD 2010/08/05 ----------<<<<<

        //--------- ADD 2013/05/08 chenw FOR Redmine#34803 --------------->>>>>
        /// <summary>
        /// グリッドに入力可のチェックを追加します。
        /// </summary>
        /// <returns>true:入力可 false:入力不可</returns>
        /// <br>Update Note: 2013/05/08 chenw</br>
        /// <br>           : グリッドに入力可のチェック</br>
        private bool GridAllowEditCheck()
        {
            bool isGridAllowEdit = false;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow in this.uGrid_Details.Rows)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridCell ultraGridCell in ultraGridRow.Cells)
                {
                    if (ultraGridCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                    {
                        isGridAllowEdit = true;
                        return isGridAllowEdit;
                    }
                }
            }
            return isGridAllowEdit;
        }
        //--------- ADD 2013/05/08 chenw FOR Redmine#34803 ---------------<<<<<

        # endregion

		// ===================================================================================== //
		// 各コントロールイベント処理
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// コントロールロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void InputDetails_Load(object sender, EventArgs e)
		{
			this.uGrid_Details.DataSource = this._estimateDetailDataTable;

			this.DetailPatternComboBoxItemSetting();

			this._detailPatternComboBox.SelectedIndex = 0;


			// ボタン初期設定処理
			this.ButtonInitialSetting();

			// ツールチップ初期設定処理
			this.ToolTipInfoInitialSetting();

			// グリッドキーマッピング設定処理
			this.MakeKeyMappingForGrid(this.uGrid_Details);

            //// クリア処理
            //this.Clear();

			this._estimateDetailDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.StockDetail_ColumnChanged);
		}

		/// <summary>
		/// 仕入明細データテーブル列変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockDetail_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			//
		}

		/// <summary>
		/// グリッド初期レイアウト設定イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// グリッド列初期設定処理
			this.InitialSettingGridCol();

			// グリッド列設定処理（ユーザー設定より）
			this.GridSetting(this._estimateInputConstructionAcs.EstimateInputConstruction);
		}

		/// <summary>
		/// Gridアクション処理前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_BeforePerformAction(object sender, Infragistics.Win.UltraWinGrid.BeforeUltraGridPerformActionEventArgs e)
		{
			//
		}

		/// <summary>
		/// Gridアクション処理後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2011/02/14 曹文傑</br>
        /// <br>             明細グリッドが表示されていない場合のエラー修正（MANTIS: 13995）</br>
		private void uGrid_Details_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
		{
			switch (e.UltraGridAction)
			{
				case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
				case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:
				
				// アクティブなセルがあるか？または編集可能セルか？
				if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
				{
					// アクティブセルのスタイルを取得
					switch (this.uGrid_Details.ActiveCell.StyleResolved)
					{
						// エディット系スタイル
						case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
						case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
						case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
						{
							// 編集モードにある？
							if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
							{
                                // ---UPD 2011/02/14-------------->>>>
                                //if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull))
                                if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull) && this.uGrid_Details.ActiveCell.IsInEditMode)
                                // ---UPD 2011/02/14--------------<<<<
								{
									// 全選択状態にする。
									this.uGrid_Details.ActiveCell.SelStart = 0;
									this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
								}
							}
							break;
						}
						default:
						{
							// エディット系以外のスタイルであれば、編集状態にする。
							this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
							break;
						}
					}
				}
				break;
			}
		}

		/// <summary>
		/// グリッドセル編集モード終了時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
		{
			//
		}

		/// <summary>
		/// グリッドセル編集モード終了前発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
		{
			//
		}

		/// <summary>
		/// グリッドセル非アクティブ化前発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2013/01/29 鄭慕鈞</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine#34434、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
		private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
		{
			if ( this._beforeCell != null )
			{
                if (this._beforeCell.Column.DataType == typeof(string) &&
                    this._beforeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // ゼロ詰め実行
                    this._estimateDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key] = uiSetControl1.GetZeroPaddedText(this._beforeCell.Column.Key, (string)this._estimateDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key]);
                }
            }
            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
            // ForeColor戻し
            this._beforeCell.Band.Override.ActiveCellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
		}

		/// <summary>
		/// グリッドキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

				if (e.KeyCode == Keys.Escape)
				{
					// 仕入明細データテーブルRowStatus列初期化処理
					this._estimateInputAcs.InitializeEstimateDetailRowStatusColumn();

					// 明細グリッドセル設定処理
					this.SettingGrid();
				}

				if (e.Shift)
				{
					switch (e.KeyCode)
					{
						case Keys.Down:
						{
							this.uGrid_Details.ActiveCell = null;
							this.uGrid_Details.ActiveRow = cell.Row;
							this.uGrid_Details.Selected.Rows.Clear();
							this.uGrid_Details.Selected.Rows.Add(cell.Row);
							break;
						}
						case Keys.Up:
						{
							this.uGrid_Details.ActiveCell = null;
							this.uGrid_Details.ActiveRow = cell.Row;
							this.uGrid_Details.Selected.Rows.Clear();
							this.uGrid_Details.Selected.Rows.Add(cell.Row);
							break;
						}
						case Keys.Home:
						{
							if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
							{
								// 編集モードの場合はなにもしない
							}
							else
							{
								this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
								this.MoveNextAllowEditCell(true);
							}
							break;
						}
						case Keys.End:
						{
							if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
							{
								// 編集モードの場合はなにもしない
							}
							else
							{
								// 最終入力行番号取得処理
								int lastInputRowIndex = this.GetLastInputRowIndex();

								//if (this.uGrid_Details.Rows[lastInputRowIndex].Cells[this._estimateDetailDataTable.StockDtiSlipNote1Column.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
								//{
								//    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[lastInputRowIndex].Cells[this._estimateDetailDataTable.GoodsNoColumn.ColumnName];
								//}
								//else
								//{
								//    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[lastInputRowIndex].Cells[this._estimateDetailDataTable.StockDtiSlipNote1Column.ColumnName];
								//}
								this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
								//this.MoveNextAllowEditCell(true);
							}
							break;
						}
					}
				}
				else if (e.Alt)
				{
					switch (e.KeyCode)
					{
						case Keys.Down:
						{
							if ((cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown) &&
								(cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList) &&
								(cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate))
							{
								((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);
							}

							break;
						}
					}
				}
                else if (e.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                e.Handled = true;
                                break;
                            }
                        case Keys.End:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                e.Handled = true;
                                break;
                            }
                    }
                }
                else
                {
                    // 編集中であった場合
                    if (cell.IsInEditMode)
                    {
                        // セルのスタイルにて判定
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // テキストボックス・テキストボックス(ボタン付)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.uGrid_Details.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            // 上記以外のスタイル
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                    //this.MoveNextAllowEditCell(true);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    //
                                }
                                else
                                {
                                    //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                    //this.MoveNextAllowEditCell(true);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.Up:
                            {
                                if (( this.uGrid_Details.ActiveCell != null ) && ( !this.uGrid_Details.ActiveCell.DroppedDown ))
                                {
                                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                                    {
                                        if (this.GridKeyDownTopRow != null)
                                        {
                                            this.GridKeyDownTopRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                }

                                break;
                            }
                        case Keys.Down:
                            {
                                if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                                {
                                    if (e.KeyCode == Keys.Down)
                                    {
                                        if (this.GridKeyDownButtomRow != null)
                                        {
                                            this.GridKeyDownButtomRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                }

                                break;
                            }
                        case Keys.Space:
                            {
                                // 「印刷」でスペースキーは純正・優良を切り替える
                                if (( this.uGrid_Details.ActiveCell.Column.Key == this._estimateDetailDataTable.PrintSelectColumn.ColumnName ) ||
                                    ( this.uGrid_Details.ActiveCell.Column.Key == this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName ))
                                {
                                    this._estimateInputAcs.EstimateDetailRowPrintSelectInfoSetting(this._estimateDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].SalesRowNo, this.uGrid_Details.ActiveCell.Column.Key);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                    }
                }
			}
			else if (this.uGrid_Details.ActiveRow != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

				switch (e.KeyCode)
				{
					case Keys.Delete:
					{
						this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
						break;
					}
				}

				if (this.uGrid_Details.ActiveRow.Index == 0)
				{
					if (e.KeyCode == Keys.Up)
					{
						if (this.GridKeyDownTopRow != null)
						{
							this.GridKeyDownTopRow(this, new EventArgs());
							e.Handled = true;
						}
					}
				}
				else if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
				{
					if (e.KeyCode == Keys.Down)
					{
						if (this.GridKeyDownButtomRow != null)
						{
							this.GridKeyDownButtomRow(this, new EventArgs());
							e.Handled = true;
						}
					}
				}
			}
		}

		/// <summary>
		/// グリッドキーアップイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_KeyUp(object sender, KeyEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
		}

		/// <summary>
		/// グリッドキープレスイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // コード関係はUI設定でチェック
            if (cell.IsInEditMode)
            {
                // ＵＩ設定を参照
                if (uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
            // ActiveCellが数量の場合
            if ((cell.Column.Key == this._estimateDetailDataTable.ShipmentCntColumn.ColumnName) ||
                (cell.Column.Key == this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName))
			{
				// 編集モード中？
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}
            // ActiveCellが定価の場合
            else if ((cell.Column.Key == this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName)||
                     (cell.Column.Key == this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName))
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // ActiveCellが仕入率の場合
			else if ((cell.Column.Key == this._estimateDetailDataTable.SalesRateColumn.ColumnName)||
                     (cell.Column.Key == this._estimateDetailDataTable.SalesRate_PrimeColumn.ColumnName))
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

		/// <summary>
		/// グリッドセルアップデート前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
		{
			if (e.Cell == null) return;

			this._beforeCellUpdateCancel = false;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

			SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

			if (salesSlip == null)
			{
				e.Cancel = true;
				return;
			}

            this._beforeStringValue = string.Empty;
            this._beforeInt32Value = 0;
            this._beforeInt64Value = 0;
            this._beforeDoubleValue = 0;

            if (this._estimateDetailDataTable.Columns.Contains(cell.Column.Key))
            {
                if (this._estimateDetailDataTable.Columns[cell.Column.Key].DataType == typeof(System.String))
                {
                    this._beforeStringValue = ( e.Cell.Value is DBNull ) ? string.Empty : e.Cell.Value.ToString();
                }
                else if (this._estimateDetailDataTable.Columns[cell.Column.Key].DataType == typeof(System.Int32))
                {
                    this._beforeInt32Value = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToInt32(e.Cell.Value);
                }
                else if (this._estimateDetailDataTable.Columns[cell.Column.Key].DataType == typeof(System.Int64))
                {
                    this._beforeInt64Value = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToInt64(e.Cell.Value);
                }
                else if (this._estimateDetailDataTable.Columns[cell.Column.Key].DataType == typeof(System.Double))
                {
                    this._beforeDoubleValue = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToDouble(e.Cell.Value);
                }
            }
        }

		/// <summary>
		/// グリッドセルアップデート後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note: 2009/10/22 呉元嘯</br>
        /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
        /// <br>             保守依頼②の追加</br>
        /// <br>Update Note: 2009/11/05 呉元嘯</br>
        /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
        /// <br>             Redmine#1087、#1134対応</br>
        /// <br>Update Note: 2009/11/12 呉元嘯</br>
        /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
        /// <br>             Redmine#1233、#1234、#1238対応</br>
        /// <br>Update Note: 2009/11/13 呉元嘯</br>
        /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
        /// <br>             Redmine#1238対応</br>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             得意先掛率グループ取得処理対応</br>
        /// <br>Update Note: 2013/02/08 yangyi</br>
        /// <br>管理番号   : 10801804-00 2013/03/13 配信分の緊急対応</br>
        /// <br>           : redmine#34604、マウスポインタで制御 砂時計にする　</br>
        /// </remarks>
		private void uGrid_Details_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			if (e.Cell == null) return;

            // 文字列項目ならばゼロ詰め処理実行
            if (e.Cell.Column.DataType == typeof(string))
            {
                if (e.Cell.Value != null)
                {
                    // セル値更新
                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                    this.uGrid_Details.BeforeCellUpdate -= this.uGrid_Details_BeforeCellUpdate;
                    e.Cell.Value = uiSetControl1.GetZeroPaddedText(e.Cell.Column.Key, e.Cell.Value.ToString());
                    this.uGrid_Details.BeforeCellUpdate += this.uGrid_Details_BeforeCellUpdate;
                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                }
            }

			Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
			int salesRowNo = this._estimateDetailDataTable[cell.Row.Index].SalesRowNo;
            string goodsNo_Pure = this._estimateDetailDataTable[cell.Row.Index].GoodsNo;
            string goodsNo_Prime = this._estimateDetailDataTable[cell.Row.Index].GoodsNo_Prime;
            bool partsSearched = false;
			int rowIndex = e.Cell.Row.Index;
            this._afterCellUpdateCancel = false;
            this._blPartsSearched = false;
            this._searchedLastRowIndex = 0;
            PartsInfoDataSet _partsInfoDataSet = null;  // ADD 2009/10/22
            PMKEN01010E copySearchCar = null;

            bool primeInfoUpdate = false;
			
			SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;
			if (salesSlip == null) return;

			if (e.Cell.Value is DBNull) 
			{
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.BeforeCellUpdate -= this.uGrid_Details_BeforeCellUpdate;
                if (( e.Cell.Column.DataType == typeof(Int32) ) ||
					(e.Cell.Column.DataType == typeof(Int64)) ||
					(e.Cell.Column.DataType == typeof(double)))
				{
					e.Cell.Value = 0;
				}
				else if (e.Cell.Column.DataType == typeof(string))
				{
					e.Cell.Value = "";
				}
                this.uGrid_Details.BeforeCellUpdate += this.uGrid_Details_BeforeCellUpdate;
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }

			List<int> settingSalesRowNoList = new List<int>();

            // --- ADD 2011/02/14 ---------->>>>>
            bool custRateGrpCheckFlag = false;
            // --- ADD 2011/02/14 ----------<<<<<

            #region ●純正品番
            if (cell.Column.Key == this._estimateDetailDataTable.GoodsNoColumn.ColumnName)
            {
                // --- ADD  2011/02/14 ---------->>>>>
                custRateGrpCheckFlag = true;
                // --- ADD  2011/02/14 ----------<<<<<

                string goodsNo = cell.Value.ToString();

                if (this._estimateInputAcs.ExistOrderSelect(salesRowNo,EstimateInputAcs.TargetData.PureParts))
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "発注選択済みの為、変更できません。",
                            -1,
                            MessageBoxButtons.OK);

                    // 品番を元に戻す
                    this._estimateDetailDataTable[cell.Row.Index].GoodsNo = this._beforeStringValue;
                    this._afterCellUpdateCancel = true;
                }
                // 純正品番新規入力
                else if (!String.IsNullOrEmpty(goodsNo))
                {
                    // 優良品番も空白の状態であれば、結合も取得する
                    List<GoodsUnitData> goodsUnitDataList;
                    List<UnitPriceCalcRet> unitPriceCalcRetList;
                    PartsInfoDataSet partsInfoDataSet;
                    bool expandJoinInfo = false;
                    GoodsCndtn.JoinSearchDivType joinSearchDivType = GoodsCndtn.JoinSearchDivType.NoSearch;

                    if (string.IsNullOrEmpty(goodsNo_Prime))
                    {
                        joinSearchDivType = GoodsCndtn.JoinSearchDivType.Search;
                        expandJoinInfo = true;
                    }

                    //--------UPD 2009/11/05--------->>>>>
                    PMKEN01010E searchCarInfo = this._estimateInputAcs.GetSearchCarInfoNew(salesRowNo);
                    //---------- ADD 2013/02/08 #34604 yangyi------------------->>>>>
                    if (this.ParentForm != null)
                    {
                        this.ParentForm.Cursor = Cursors.WaitCursor; //読み込み時に砂時計を表示する  
                    }
                    //---------- ADD 2013/02/08 #34604 yangyi-------------------<<<<<
                    int status = this.SearchPartsFromGoodsNo(goodsNo, joinSearchDivType, out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList, searchCarInfo);
                    //---------- ADD 2013/02/08 #34604 yangyi------------------->>>>>
                    if (this.ParentForm != null)
                    {
                        this.ParentForm.Cursor = Cursors.Default;   //読み込み終わったので砂時計を解除する。
                    }
                    //---------- ADD 2013/02/08 #34604 yangyi-------------------<<<<<

                    //--------UPD 2009/11/05---------<<<<<
                    switch (status)
                    {
                        // 検索OK
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            {
                                if (( partsInfoDataSet != null ) && ( goodsUnitDataList != null ) && ( goodsUnitDataList.Count > 0 ))
                                {
                                    _partsInfoDataSet = partsInfoDataSet;// ADD 2009/10/22
                                    //------UPD 2009/11/05------->>>>>
                                    // _partsInfoDataSet.SearchCarInfo = null;// ADD 2009/10/22
                                    _partsInfoDataSet.SearchCarInfo = searchCarInfo;
                                    copySearchCar = searchCarInfo;
                                    //------UPD 2009/11/05-------<<<<<
                                    if (this._estimateInputAcs.EstimateDetailRowPurePartsSearchResultSetting(salesRowNo, EstimateInputAcs.GoodsSearchDiv.PartsNoSerach, goodsUnitDataList, partsInfoDataSet, unitPriceCalcRetList, expandJoinInfo, out settingSalesRowNoList, true, 0) == EstimateInputAcs.DataSettingResult.OverRowCount)
                                    {

                                    }
                                    partsSearched = true;
                                }
                                break;
                            }
                        // キャンセル
                        case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                            {
                                // 品番を元に戻す
                                this._estimateDetailDataTable[cell.Row.Index].GoodsNo = this._beforeStringValue;
                                this._afterCellUpdateCancel = true;
                                break;
                            }
                        // 該当データ無し
                        case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                            {
                                // 一旦品番を戻す
                                this._estimateDetailDataTable[cell.Row.Index].GoodsNo = this._beforeStringValue;

                                if (this._estimateInputAcs.ExistDetailInput(salesRowNo))
                                {
                                    this._estimateDetailDataTable[cell.Row.Index].GoodsNo = goodsNo;

                                    // 既に明細入力済みの場合は商品情報をクリアする
                                    this._estimateInputAcs.EstimateDetailRowGoodsInfoClear(salesRowNo, EstimateInputAcs.TargetData.PureParts);
                                }
                                else
                                {
                                    this._estimateDetailDataTable[cell.Row.Index].GoodsNo = goodsNo;

                                    // 明細新規入力
                                    this._estimateInputAcs.EstimateDetailRowNonGoodsInfoSetting(salesRowNo, EstimateInputAcs.TargetData.PureParts);

                                }
                                break;
                            }
                        default:
                            {
                                // 品番を元に戻す
                                this._estimateDetailDataTable[cell.Row.Index].GoodsNo = this._beforeStringValue;
                                this._afterCellUpdateCancel = true;
                                break;
                            }
                    }
                }
                else
                {
                    // 明細入力済みの場合
                    if (this._estimateInputAcs.ExistDetailInput(salesRowNo))
                    {
                        this._estimateInputAcs.EstimateDretailRowGoodsInfoClear(salesRowNo, EstimateInputAcs.TargetData.PureParts);
                    }
                    else
                    {
                        this._estimateInputAcs.ClearEstimateDetailRow(salesRowNo);
                    }
                    settingSalesRowNoList.Add(salesRowNo);
                }

            }
            #endregion

            #region ●優良品番
            else if (cell.Column.Key == this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName)
            {
                // --- ADD  2011/02/14 ---------->>>>>
                custRateGrpCheckFlag = true;
                // --- ADD  2011/02/14 ----------<<<<<

                string goodsNo = cell.Value.ToString();

                if (this._estimateInputAcs.ExistOrderSelect(salesRowNo, EstimateInputAcs.TargetData.PrimeParts))
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "発注選択済みの為、変更できません。",
                            -1,
                            MessageBoxButtons.OK);

                    // 品番を元に戻す
                    this._estimateDetailDataTable[cell.Row.Index].GoodsNo_Prime = this._beforeStringValue;
                    this._afterCellUpdateCancel = true;
                } 
                // 品番検索
                else if (!String.IsNullOrEmpty(goodsNo))
                {
                    List<GoodsUnitData> goodsUnitDataList;
                    List<UnitPriceCalcRet> unitPriceCalcRetList;
                    PartsInfoDataSet partsInfoDataSet;

                    //--------UPD 2009/11/05--------->>>>>
                    PMKEN01010E searchCarInfo = this._estimateInputAcs.GetSearchCarInfoNew(salesRowNo);
                    //---------- ADD 2013/02/08 #34604 yangyi------------------->>>>>
                    if (this.ParentForm != null)
                    {
                        this.ParentForm.Cursor = Cursors.WaitCursor; //読み込み時に砂時計を表示する  
                    }
                    //---------- ADD 2013/02/08 #34604 yangyi-------------------<<<<<
                    int status = this.SearchPartsFromGoodsNo(goodsNo, GoodsCndtn.JoinSearchDivType.NoSearch, out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList, searchCarInfo);
                    //---------- ADD 2013/02/08 #34604 yangyi------------------->>>>>
                    if (this.ParentForm != null)
                    {
                        this.ParentForm.Cursor = Cursors.Default;   //読み込み終わったので砂時計を解除する。
                    }
                    //---------- ADD 2013/02/08 #34604 yangyi-------------------<<<<<

                    switch (status)
                    {
                        // 検索OK
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            {
                                if (( partsInfoDataSet != null ) && ( goodsUnitDataList != null ) && ( goodsUnitDataList.Count > 0 ))
                                {
                                    _partsInfoDataSet = partsInfoDataSet;// ADD 2009/10/22
                                    //------UPD 2009/11/05------->>>>>
                                    // _partsInfoDataSet.SearchCarInfo = null;// ADD 2009/10/22
                                    _partsInfoDataSet.SearchCarInfo = searchCarInfo;
                                    copySearchCar = searchCarInfo;
                                    //------UPD 2009/11/05-------<<<<<
                                    //------UPD 2009/11/13------->>>>>
                                    this._estimateInputAcs.EstimateDetailRowPrimePartsSearchResultSetting(salesRowNo, EstimateInputAcs.GoodsSearchDiv.PartsNoSerach, goodsUnitDataList[0], partsInfoDataSet, unitPriceCalcRetList, out settingSalesRowNoList, 0);
                                    //------UPD 2009/11/13-------<<<<<
                                    primeInfoUpdate = true;
                                    settingSalesRowNoList.Add(salesRowNo);
                                }
                                break;
                            }
                        // 検索キャンセル
                        case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                            {
                                // 品番を元に戻す
                                this._estimateDetailDataTable[cell.Row.Index].GoodsNo_Prime = this._beforeStringValue;
                                this._afterCellUpdateCancel = true;

                                break;
                            }
                        // 該当データ無し
                        case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                            {
                                // 一旦品番を戻す
                                this._estimateDetailDataTable[cell.Row.Index].GoodsNo_Prime = this._beforeStringValue;

                                if (this._estimateInputAcs.ExistDetailInput(salesRowNo))
                                {
                                    this._estimateDetailDataTable[cell.Row.Index].GoodsNo_Prime = goodsNo;

                                    // 既に明細入力済みの場合は商品情報をクリアする
                                    this._estimateInputAcs.EstimateDetailRowGoodsInfoClear(salesRowNo, EstimateInputAcs.TargetData.PrimeParts);

                                    primeInfoUpdate = true;
                                }
                                else
                                {
                                    this._estimateDetailDataTable[cell.Row.Index].GoodsNo_Prime = goodsNo;

                                    // 明細新規入力
                                    this._estimateInputAcs.EstimateDetailRowNonGoodsInfoSetting(salesRowNo, EstimateInputAcs.TargetData.PrimeParts);
                                    primeInfoUpdate = true;
                                }
                                break;
                            }
                        default:
                            {
                                // 品番を元に戻す
                                this._estimateDetailDataTable[cell.Row.Index].GoodsNo_Prime = this._beforeStringValue;
                                this._afterCellUpdateCancel = true;

                                break;
                            }
                    }
                }
                else
                {
                    // 明細入力済みの場合
                    if (this._estimateInputAcs.ExistDetailInput(salesRowNo))
                    {
                        this._estimateInputAcs.EstimateDretailRowGoodsInfoClear(salesRowNo, EstimateInputAcs.TargetData.PrimeParts);
                    }
                    else
                    {
                        this._estimateInputAcs.ClearEstimateDetailRow(salesRowNo);
                    }
                    settingSalesRowNoList.Add(salesRowNo);
                }
            }
            #endregion

            #region ●BLコード

            else if (( cell.Column.Key == this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName ) ||
                     ( cell.Column.Key == this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName ))
            {
                // --- ADD  2011/02/14 ---------->>>>>
                custRateGrpCheckFlag = true;
                // --- ADD  2011/02/14 ----------<<<<<

                EstimateInputInitDataAcs.LogWrite("PMMIT01010UB", "AfterCellUpdate", "START");
                EstimateInputAcs.TargetData targetData = ( cell.Column.Key == this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;
                int blCode = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                bool blPartsSearch = false;

                // BL検索モード
                if (this._estimateInputAcs.SalesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                {
                    if (blCode != 0)
                    {
                        // 新規でBLコード入力時はBLコード検索
                        if (!this._estimateInputAcs.ExistDetailInput(salesRowNo))
                        {
                            blPartsSearch = true;
                            PartsInfoDataSet partsInfoDataSet;
                            List<GoodsUnitData> goodsUnitDataList;
                            List<UnitPriceCalcRet> unitPriceCalcRetList;

                            PMKEN01010E searchCarInfo = this._estimateInputAcs.GetSearchCarInfo(salesRowNo);

                            EstimateInputInitDataAcs.LogWrite("PMMIT01010UB", "AfterCellUpdate", "検索 START");
                            //---------- ADD 2013/02/08 #34604 yangyi------------------->>>>>
                            if (this.ParentForm != null)
                            {
                                this.ParentForm.Cursor = Cursors.WaitCursor; //読み込み時に砂時計を表示する  
                            }
                            //---------- ADD 2013/02/08 #34604 yangyi-------------------<<<<<
                            int status = this.BLPartsSearch(blCode, searchCarInfo, out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList);
                            //---------- ADD 2013/02/08 #34604 yangyi------------------->>>>>
                            if (this.ParentForm != null)
                            {
                                this.ParentForm.Cursor = Cursors.Default;   //読み込み終わったので砂時計を解除する。
                            }
                            //---------- ADD 2013/02/08 #34604 yangyi-------------------<<<<<

                            EstimateInputInitDataAcs.LogWrite("PMMIT01010UB", "AfterCellUpdate", "検索 END");

                            switch (status)
                            {
                                // 検索OK
                                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    {
                                        EstimateInputInitDataAcs.LogWrite("PMMIT01010UB", "AfterCellUpdate", "検索結果展開 START");
                                        if (( partsInfoDataSet != null ) && ( goodsUnitDataList != null ) && ( goodsUnitDataList.Count > 0 ))
                                        {
                                            _partsInfoDataSet = partsInfoDataSet;// ADD 2009/10/22
                                            _partsInfoDataSet.SearchCarInfo = searchCarInfo;// ADD 2009/10/22
                                            copySearchCar = searchCarInfo;

                                            //if (this._estimateInputAcs.EstimateDetailRowPurePartsSearchResultSetting(salesRowNo, EstimateInputAcs.GoodsSearchDiv.BLPartsSearch, goodsUnitDataList, partsInfoDataSet, unitPriceCalcRetList, true, out settingSalesRowNoList, false, blCode) == EstimateInputAcs.DataSettingResult.OverRowCount)
                                            if (this._estimateInputAcs.EstimateDetailRowBLPartsSearchResultSetting(salesRowNo, EstimateInputAcs.GoodsSearchDiv.BLPartsSearch, goodsUnitDataList, partsInfoDataSet, unitPriceCalcRetList, true, out settingSalesRowNoList, false, blCode) == EstimateInputAcs.DataSettingResult.OverRowCount)
                                            {
                                                TMsgDisp.Show(
                                                    this,
                                                    emErrorLevel.ERR_LEVEL_INFO,
                                                    this.Name,
                                                    "明細行数が最大行数を超える為、検索を中断しました。",
                                                    -1,
                                                    MessageBoxButtons.OK);
                                            }
                                        }
                                        EstimateInputInitDataAcs.LogWrite("PMMIT01010UB", "AfterCellUpdate", "検索結果展開 END");

                                        int lastRowNo = 0;
                                        foreach (int targetRow in settingSalesRowNoList)
                                        {
                                            if (lastRowNo <= targetRow)
                                            {
                                                lastRowNo = targetRow;
                                            }
                                        }

                                        if (lastRowNo > 0)
                                        {
                                            this._searchedLastRowIndex = this._estimateInputAcs.GetIndexFromSalesRowNo(lastRowNo);
                                        }

                                        partsSearched = true;
                                        this._blPartsSearched = true;
                                        break;
                                    }
                                // キャンセル
                                case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                                    {
                                        // BLコードを元に戻す
                                        this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeInt32Value;
                                        this._afterCellUpdateCancel = true;
                                        break;
                                    }
                                // 車輌無し
                                case -3:
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "車輌情報が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeInt32Value;
                                        this._afterCellUpdateCancel = true;
                                        break;
                                    }
                                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "該当データがありません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        // BLコードを元に戻す
                                        this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeInt32Value;
                                        this._afterCellUpdateCancel = true;
                                        break;
                                    }
                                default:
                                    {
                                        // BLコードを元に戻す
                                        this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeInt32Value;
                                        this._afterCellUpdateCancel = true;
                                        break;
                                    }
                            }
                        }
                    }
                }
                if (!blPartsSearch)
                {
                    if (blCode != 0)
                    {
                        if (this._estimateInputAcs.EstimateDetailBLGoodsInfoSetting(salesRowNo, targetData, blCode))
                        {
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "BLコード [" + blCode.ToString() + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // BLコードを元に戻す
                            this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeInt32Value;

                            this._afterCellUpdateCancel = true;

                            return;
                        }
                    }
                    else
                    {
                        // BLコード関連の情報をクリア
                        this._estimateInputAcs.EstimateDetailBLGoodsInfoClear(salesRowNo, targetData);
                    }
                }
                primeInfoUpdate = ( targetData == EstimateInputAcs.TargetData.PrimeParts );
                EstimateInputInitDataAcs.LogWrite("PMMIT01010UB", "AfterCellUpdate", "END");
            }
            #endregion

            #region ●商品名称
            //--------------------
            // 商品名称 
            //--------------------
            else if (( cell.Column.Key == this._estimateDetailDataTable.GoodsNameColumn.ColumnName ) ||
                     ( cell.Column.Key == this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName ))
            {
                EstimateInputAcs.TargetData targetData = ( cell.Column.Key == this._estimateDetailDataTable.GoodsNameColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;
                string goodsName = e.Cell.Value.ToString();

                // --- UPD m.suzuki 2010/04/15 ---------->>>>>
                //this._estimateInputAcs.EstimateDetailGoodsNameSetting(salesRowNo, targetData, goodsName, goodsName);

                string goodsNameKana = GetKanaString( goodsName );

                // ガ(1文字)⇒ｶﾞ(2文字)のような変換もあるので、長さをチェックする。
                int kanaMaxLength = 40;
                if ( goodsNameKana.Length > kanaMaxLength )
                {
                    goodsNameKana = goodsNameKana.Substring( 0, kanaMaxLength );
                }
                this._estimateInputAcs.EstimateDetailGoodsNameSetting( salesRowNo, targetData, goodsName, goodsNameKana );
                // --- UPD m.suzuki 2010/04/15 ----------<<<<<

                primeInfoUpdate = ( targetData == EstimateInputAcs.TargetData.PrimeParts );
            }
            #endregion

            #region ●倉庫コード
            //--------------------
            // 倉庫コード
            //--------------------
            else if (( cell.Column.Key == this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName ) ||
                     ( cell.Column.Key == this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName ))
            {
                EstimateInputAcs.TargetData targetData = ( cell.Column.Key == this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;

                string warehouseCode = cell.Value.ToString();

                if (warehouseCode != this._beforeStringValue)
                {
                    string errorMsg = string.Empty;
                    bool inputError = false;

                    if (!string.IsNullOrEmpty(warehouseCode))
                    {
                        string warehouseName = this._estimateInputInitDataAcs.GetName_FromWarehouse(warehouseCode);

                        if (!string.IsNullOrEmpty(warehouseName))
                        {
                            List<Stock> stockList = this._estimateInputAcs.SearchStock(salesRowNo, targetData);

                            if (( stockList == null ) || ( stockList.Count == 0 ))
                            {
                                errorMsg = "倉庫 [" + warehouseCode + "] に該当する商品の在庫が存在しません。";
                                inputError = true;
                            }
                            else
                            {
                                // 倉庫名称設定処理
                                this._estimateInputAcs.EstimateDetailWarehouseInfoSetting(salesRowNo, targetData, warehouseCode, warehouseName);
                                // 在庫情報設定処理
                                this._estimateInputAcs.EstimateDetailRowStockSetting(salesRowNo, targetData, stockList);
                            }
                        }
                        else
                        {
                            inputError = true;
                            errorMsg = "倉庫コード [" + warehouseCode + "] に該当するデータが存在しません。";
                        }
                    }
                    else
                    {
                        // 在庫情報をクリア
                        this._estimateInputAcs.EstimateDetailRowClearStockInfo(salesRowNo, targetData);
                    }

                    if (inputError)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            errorMsg,
                            -1,
                            MessageBoxButtons.OK);

                        // 倉庫コードを元に戻す
                        this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeStringValue;

                        this._afterCellUpdateCancel = true;

                        return;
                    }

                    primeInfoUpdate = ( targetData == EstimateInputAcs.TargetData.PrimeParts );
                }
            }
            #endregion

            #region ●QTY
            else if (( cell.Column.Key == this._estimateDetailDataTable.ShipmentCntColumn.ColumnName ) ||
                     ( cell.Column.Key == this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName ))
            {
                EstimateInputAcs.TargetData targetData = ( cell.Column.Key == this._estimateDetailDataTable.ShipmentCntColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;

                string errMsg;
                EstimateInputAcs.CheckResult checkResult = this._estimateInputAcs.ShipmentCntCheck(salesRowNo, targetData, out errMsg);

                if (checkResult != EstimateInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == EstimateInputAcs.CheckResult.Error)
                    {
                        this._estimateDetailDataTable[rowIndex][cell.Column.Key] = this._beforeDoubleValue;
                        this._afterCellUpdateCancel = true;
                        return;
                    }
                }

                // 仕入明細行オブジェクトの数量調整
                this._estimateInputAcs.EstimateDetailRowCountInfoSetting(targetData, salesRowNo);

                // 原価再計算
                this._estimateInputAcs.CalculateCost(targetData, salesRowNo);

                settingSalesRowNoList.Add(salesRowNo);

                primeInfoUpdate = ( targetData == EstimateInputAcs.TargetData.PrimeParts );
            }
            #endregion

            #region ●メーカー
            else if (( cell.Column.Key == this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName ) ||
                     ( cell.Column.Key == this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName ))
            {
                // --- ADD  2011/02/14 ---------->>>>>
                custRateGrpCheckFlag = true;
                // --- ADD  2011/02/14 ----------<<<<<

                EstimateInputAcs.TargetData targetData = ( cell.Column.Key == this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;

                string goodsNo = string.Empty;
                int goodsMakerCd = TStrConv.StrToIntDef(cell.Value.ToString(), 0);
                string beforeMakerName = string.Empty;
                string beforeMakreKanaName = string.Empty;


                if (targetData == EstimateInputAcs.TargetData.PureParts)
                {
                    goodsNo = this._estimateDetailDataTable[cell.Row.Index].GoodsNo;
                    beforeMakerName = this._estimateDetailDataTable[cell.Row.Index].MakerName;
                    beforeMakreKanaName = this._estimateDetailDataTable[cell.Row.Index].MakerKanaName;
                }
                else
                {
                    goodsNo = this._estimateDetailDataTable[cell.Row.Index].GoodsNo_Prime;
                    beforeMakerName = this._estimateDetailDataTable[cell.Row.Index].MakerName_Prime;
                    beforeMakreKanaName = this._estimateDetailDataTable[cell.Row.Index].MakerKanaName_Prime;
                }

                if (this._estimateInputAcs.ExistOrderSelect(salesRowNo, targetData))
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "発注選択済みの為、変更できません。",
                            -1,
                            MessageBoxButtons.OK);

                    // メーカーコードを元に戻す
                    this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeInt32Value;

                    this._afterCellUpdateCancel = true;
                } 
                else if (goodsMakerCd != 0)
                {
                    string makerName, makerKanaName;
                    // 先にメーカー情報を取得する
                    this._estimateInputInitDataAcs.GetName_FromMaker(goodsMakerCd, out makerName, out makerKanaName);

                    if (!String.IsNullOrEmpty(makerName))
                    {
                        this._estimateInputAcs.EstimateDetailMakerInfoSetting(salesRowNo, targetData, goodsMakerCd, makerName, makerKanaName);
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "メーカーコード [" + goodsMakerCd.ToString() + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // メーカーコードを元に戻す
                        this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeInt32Value;

                        this._afterCellUpdateCancel = true;
                    }
                }
                else
                {
                    // メーカー名称設定処理
                    this._estimateInputAcs.EstimateDetailMakerInfoSetting(salesRowNo, targetData, 0, string.Empty, string.Empty);
                }

                // 品番入力済みでメーカーが変わった場合
                if (( !this._afterCellUpdateCancel ) && ( goodsMakerCd != this._beforeInt32Value ) && ( !String.IsNullOrEmpty(goodsNo) ))
                {
                    switch (this.SearchPartsAndRowSetting(rowIndex, targetData))
                    {
                        case 0:     // 検索OK
                            break;
                        case -1:    // キャンセル
                            this._estimateInputAcs.EstimateDetailMakerInfoSetting(salesRowNo, targetData, this._beforeInt32Value, beforeMakerName, beforeMakreKanaName);
                            break;
                        default:    // エラー
                            this._estimateInputAcs.EstimateDretailRowGoodsInfoClear(salesRowNo, targetData);
                            break;
                    }
                    settingSalesRowNoList.Add(salesRowNo);
                }
                primeInfoUpdate = ( targetData == EstimateInputAcs.TargetData.PrimeParts );
            }
            #endregion

            #region ●定価
            else if (( cell.Column.Key == this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName ) ||
                     ( cell.Column.Key == this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName ))
            {
                EstimateInputAcs.TargetData target = ( cell.Column.Key == this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;

                double newListPriceDisplay = TStrConv.StrToDoubleDef(e.Cell.Value.ToString(), 0);

                // 見積明細データセッティング処理（定価設定）
                this._estimateInputAcs.EstimateDetailRowListPriceSetting(salesRowNo, target, EstimateInputAcs.PriceInputType.PriceDisplay, newListPriceDisplay);

                primeInfoUpdate = ( target == EstimateInputAcs.TargetData.PrimeParts );
            }
            #endregion

            #region ●仕入先
            else if (( cell.Column.Key == this._estimateDetailDataTable.SupplierCdColumn.ColumnName ) ||
                     ( cell.Column.Key == this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName ))
            {
                EstimateInputAcs.TargetData target = ( cell.Column.Key == this._estimateDetailDataTable.SupplierCdColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;

                int supplierCd = TStrConv.StrToIntDef(cell.Value.ToString(), 0);
                Supplier supplier = null;
                bool isSupplierInfoSet = false;

                if (this._estimateInputAcs.ExistOrderSelect(salesRowNo, target))
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "発注選択済みの為、変更できません。",
                            -1,
                            MessageBoxButtons.OK);

                    // コードを元に戻す
                    this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeInt32Value;

                    this._afterCellUpdateCancel = true;
                }
                else if (supplierCd != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                    int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCd);
                    this.Cursor = Cursors.Default;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        isSupplierInfoSet = true;

                        //// 仕入先情報設定
                        //this._estimateInputAcs.EstimateDetailSupplierInfoSetting(salesRowNo, target, supplier);
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "仕入先コード [" + supplierCd.ToString() + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // コードを元に戻す
                        this._estimateDetailDataTable[cell.Row.Index][cell.Column.Key] = this._beforeInt32Value;

                        this._afterCellUpdateCancel = true;

                        return;
                    }
                }
                else
                {
                    isSupplierInfoSet = true;
                    supplier = new Supplier();
                }

                if (isSupplierInfoSet)
                {
                    // 仕入先情報設定
                    this._estimateInputAcs.EstimateDetailSupplierInfoSetting(salesRowNo, target, supplier);

                    DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "仕入先が変更されました。" + "\r\n" + "\r\n" +
                                "商品価格を再取得しますか？",
                                0,
                                MessageBoxButtons.YesNo,
                                MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        this._estimateInputAcs.EstimateDetailRowPriceReSetting(target, salesRowNo);
                    }
                    else
                    {
                        this._estimateInputAcs.EstimateDetailRowClearRateInfo(salesRowNo, UnitPriceCalculation.UnitPriceKind.ListPrice, target, false);
                        this._estimateInputAcs.EstimateDetailRowClearRateInfo(salesRowNo, UnitPriceCalculation.UnitPriceKind.UnitCost, target, false);
                    }

                }

                primeInfoUpdate = ( target == EstimateInputAcs.TargetData.PrimeParts );
            }
            #endregion

            if (partsSearched)
            {
                this.AddLastEmptyRow();
            }

            if (primeInfoUpdate)
            {
                this._estimateInputAcs.SettingPrimeInfoRowFromEstimateDetailRow(salesRowNo);
            }

            // 明細の描画
            this.uGrid_Details.BeginUpdate();
            this.SettingGridRow(rowIndex, this._estimateInputAcs.SalesSlip);
            if (( settingSalesRowNoList != null ) && ( settingSalesRowNoList.Count > 0 ))
            {
                List<int> settingRowIndexList = this._estimateInputAcs.GetRowIndexListFromSalesRowNoList(settingSalesRowNoList);
                foreach (int index in settingRowIndexList)
                {
                    this.SettingGridRow(index, this._estimateInputAcs.SalesSlip);
                }
            }
            this.uGrid_Details.EndUpdate();

			// フッタ部明細情報更新イベントコール処理
            this.SettingFooterEventCall(salesRowNo);

            // 車輌情報設定イベントコール処理
            this.SettingCarInfoEventCall(salesRowNo);
            foreach (int rowNo in settingSalesRowNoList)
            {
                this.SettingCarInfoEventCall(rowNo);
            }
            // --- ADD 2011/02/14 ---------->>>>>
            if (custRateGrpCheckFlag)
            {
                /* -------- DEL START wangf 2012/04/27 For Redmine#29640 ------->>>>>>
                // 改修方法は変わるので、Redmin#29312改修前ソースを戻り、このチケットの対応が「PMMIT01012AA.cs」へ移動する
                // Redmin#29640の対応したら、Redmin#29312も一緒に対応します、ご迷惑を御かけてして申し訳ございません
                /* -------- Del Start zhangy3 2012/04/09 For Redmine#29312 ------->>>>>>
                -------- DEL END wangf 2012/04/27 For Redmine#29640 -------<<<<<<<< */
                if (_partsInfoDataSet != null)
                {
                    // 純正
                    this._estimateDetailDataTable[cell.Row.Index].CustRateGrpCode
                        = GetCustRateGrpCode(_partsInfoDataSet,
                                              this._estimateDetailDataTable[cell.Row.Index].GoodsNo,
                                              this._estimateDetailDataTable[cell.Row.Index].GoodsMakerCd);
                    // 優良
                    this._estimateDetailDataTable[cell.Row.Index].CustRateGrpCode_Prime
                        = GetCustRateGrpCode(_partsInfoDataSet,
                                              this._estimateDetailDataTable[cell.Row.Index].GoodsNo_Prime,
                                              this._estimateDetailDataTable[cell.Row.Index].GoodsMakerCd_Prime);

                }
                //-------- Del End zhangy3 2012/04/09 For Redmine#29312 -------<<<<<<<< */ // DEL wangf 2012/04/27 FOR Redmine#29640
                /* -------- DEL START wangf 2012/04/27 For Redmine#29640 ------->>>>>>
                // -------- Add Start zhangy3 2012/04/09 For Redmine#29312 ------->>>>>>
                if (_partsInfoDataSet != null)
                {
                    foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable.Rows)
                    {
                        //if (row.GoodsMakerCd > 0 && (!string.Empty.Equals(row.GoodsNo)||!string.Empty.Equals(row.GoodsNo_Prime))) // DEL wangf 2012/04/27 FOR Redmine#29640
                        // ------------ADD START wangf 2012/04/27 FOR Redmine#29640--------->>>>
                        // 純正部品また優良部品が存在すれば、得意先掛率グループを取得する、両方も存在しない場合は、繰り返すのをブレイク
                        if ((row.GoodsMakerCd > 0 && !string.Empty.Equals(row.GoodsNo)) ||
                            ((row.GoodsMakerCd_Prime > 0) && !string.Empty.Equals(row.GoodsNo_Prime)))
                        // ------------ADD END wangf 2012/04/27 FOR Redmine#29640---------<<<<<
                        {
                            // 純正
                            row.CustRateGrpCode
                                = GetCustRateGrpCode(_partsInfoDataSet,
                                                      row.GoodsNo,
                                                      row.GoodsMakerCd);
                            // 優良
                            row.CustRateGrpCode_Prime
                                = GetCustRateGrpCode(_partsInfoDataSet,
                                                      row.GoodsNo_Prime,
                                                      row.GoodsMakerCd_Prime);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                // -------- Add End zhangy3 2012/04/09 For Redmine#29312 -------<<<<<<<<
                -------- DEL END wangf 2012/04/27 For Redmine#29640 -------<<<<<<<< */
            }
            // --- ADD 2011/02/14 ----------<<<<<
            
            #region 標準価格選択ウインドウ
            //------------------ADD 2009/10/22----------------->>>>>
            // BLコード/品番検索で情報の取得
            EstimateInputDataSet.EstimateDetailRow selectedRow = this._estimateInputAcs.GetRow(salesRowNo);
            // BLコード/品番検索で情報がない
            if (selectedRow == null)
            {
                return;
            }
            PartsInfoDataSet copyPartsInfoDataSet = null;
            if (_partsInfoDataSet == null) return; // ADD 2009/11/12
            if (this._estimateInputAcs._primeRelationDic.ContainsKey(selectedRow.PrimeInfoRelationGuid))
            {
                copyPartsInfoDataSet = (PartsInfoDataSet)_partsInfoDataSet.Copy();
                copyPartsInfoDataSet.SearchCarInfo = copySearchCar;
                this._estimateInputAcs._primeRelationDic[selectedRow.PrimeInfoRelationGuid] = copyPartsInfoDataSet;
            }
            else
            {
                copyPartsInfoDataSet = (PartsInfoDataSet)_partsInfoDataSet.Copy();
                copyPartsInfoDataSet.SearchCarInfo = copySearchCar;
                this._estimateInputAcs._primeRelationDic.Add(selectedRow.PrimeInfoRelationGuid, copyPartsInfoDataSet);
            }
            // 画面入力値の標準価格選択が「する」の場合
            if (this._priceSelectComboBox.SelectedIndex == 1)
            {
                EstimateInputDataSet.PrimeInfoRow[] primeInfoRowArray = null;
                EstimateInputDataSet.PrimeInfoRow row = null;
                GoodsCndtn cndtn = null;
                int goodMaker = 0;
                string goodMakerNm = string.Empty;
                string goodNo = string.Empty;
                string goodNoNm = string.Empty;
                int bLGoodCd = 0;
                double listPriceTaxExcFl = 0;
                primeInfoRowArray = (EstimateInputDataSet.PrimeInfoRow[])this._estimateInputAcs.PrimeInfoDataTable.Select(string.Format("{0}='{1}'", this._estimateInputAcs.PrimeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, selectedRow.PrimeInfoRelationGuid));
                // 優良部品情報を含む時
                if ((primeInfoRowArray != null) && (primeInfoRowArray.Length > 0))
                {
                    for (int i = 0; i < primeInfoRowArray.Length; i++)
                    {
                        row = primeInfoRowArray[i];
                        if (row.SelectionState == true)
                        {
                            goodMaker = row.GoodsMakerCd;
                            goodNo = row.GoodsNo;
                            bLGoodCd = row.BLGoodsCode;
                            goodMakerNm = row.MakerName;
                            goodNoNm = row.GoodsName;
                            listPriceTaxExcFl = row.ListPriceTaxExcFl;
                            break;

                        }
                    }
                    if (row == null) return;
                }
                // 優良部品情報を含まない時（品番検索(優良)）
                else
                {
                    //---------UPD 2009/11/13--------->>>>>
                    if (cell.Column.Key == this._estimateDetailDataTable.GoodsNoColumn.ColumnName)
                    {
                        return;
                    }
                    goodMaker = selectedRow.GoodsMakerCd_Prime;
                    goodNo = selectedRow.GoodsNo_Prime;
                    bLGoodCd = selectedRow.BLGoodsCode_Prime;
                    goodMakerNm = selectedRow.MakerName_Prime;
                    goodNoNm = selectedRow.GoodsName_Prime;
                    listPriceTaxExcFl = selectedRow.ListPriceTaxExcFl_Prime;
                    //---------UPD 2009/11/13---------<<<<<
                }
                // 抽出条件設定
                cndtn = new GoodsCndtn();
                cndtn.EnterpriseCode = this._enterpriseCode;
                cndtn.SectionCode = this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd;
                cndtn.GoodsMakerCd = goodMaker;
                cndtn.GoodsNo = goodNo;

                //---------UPD 2009/11/05------>>>>>
                ArrayList custRateGroupList;
                ArrayList displayDivList;

                // 得意先掛率グループコードマスタの全件取得
                this._estimateInputAcs.GetCustRateGrpList(out custRateGroupList, this._enterpriseCode);
                // 標準価格選択設定マスタの取得
                this._estimateInputAcs.GetDisplayDivList(out displayDivList, this._enterpriseCode);
                List<PriceSelectSet> priceSelectSet = new List<PriceSelectSet>((PriceSelectSet[])displayDivList.ToArray(typeof(PriceSelectSet)));

                //結合元検索ﾃﾞﾘｹﾞｰﾄ
                // if (_partsInfoDataSet == null) return; // DEL 2009/11/12
                if (_partsInfoDataSet.SearchPartsForSrcParts == null)
                {
                    _partsInfoDataSet.SearchPartsForSrcParts += new PartsInfoDataSet.SearchPartsForSrcPartsCallBack(this._estimateInputAcs.SearchPartsForSrcParts);
                }
                //得意先掛率ｸﾞﾙｰﾌﾟ取得ﾃﾞﾘｹﾞｰﾄ
                if (_partsInfoDataSet.GetCustRateGrp == null)
                {
                    _partsInfoDataSet.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(this._estimateInputAcs.GetCustRateGrp);
                }
                //表示区分取得ﾃﾞﾘｹﾞｰﾄ
                if (_partsInfoDataSet.GetDisplayDiv == null)
                {
                    _partsInfoDataSet.GetDisplayDiv += new PartsInfoDataSet.GetDisplayDivCallBack(this._estimateInputAcs.GetDisplayDiv);
                }
                // 結合元検索
                _partsInfoDataSet.SettingSrcPartsInfo(cndtn);
                if (_partsInfoDataSet.PartsInfoDataSetSrcParts == null) return;
                // 得意先掛率ｸﾞﾙｰﾌﾟｺｰﾄﾞ取得
                _partsInfoDataSet.SettingCustRateGrpCode(custRateGroupList, this._estimateInputAcs.SalesSlip.CustomerCode, goodNo, goodMaker);
                PartsInfoDataSet.UsrGoodsInfoRow urrentRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodMaker, goodNo);
                // 表示区分取得ﾞ取得
                _partsInfoDataSet.SettingDisplayDiv(priceSelectSet, goodNo, goodMaker, bLGoodCd, this._estimateInputAcs.SalesSlip.CustomerCode, urrentRow.CustRateGrpCode);
                urrentRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodMaker, goodNo);

                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                // 標準価格選択ウインドウ表示処理
                SelectionListPrice selectionListPrice = new SelectionListPrice(goodMaker, goodMakerNm, goodNo, goodNoNm, listPriceTaxExcFl, _partsInfoDataSet, urrentRow.PriceSelectDiv);
                //---------UPD 2009/11/05------<<<<<
                selectionListPrice.ShowDialog(this);
                PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodMaker, goodNo);
                // 1:定価(選択)を使用する
                if (usrGoodsInfoRow.SelectedListPriceDiv == 1)
                {
                    // 優良部品情報を含む時(品番検索(純正)とBL検索)
                    if (row != null)
                    {
                        // 純正価格と優良価格設定
                        row.ListPriceDisplay = usrGoodsInfoRow.SelectedListPrice;
                        row.AcceptChanges();
                        selectedRow.ListPriceDisplay_Prime = usrGoodsInfoRow.SelectedListPrice;// ADD 2009/11/12
                        selectedRow.AcceptChanges();// ADD 2009/11/12

                        // 見積明細データセッティング処理（定価設定）
                        this._estimateInputAcs.EstimateDetailRowListPriceSetting(salesRowNo, EstimateInputAcs.TargetData.PrimeParts, EstimateInputAcs.PriceInputType.PriceDisplay, selectedRow.ListPriceDisplay_Prime);// ADD 2009/11/13

                    }
                    else
                    {
                        //selectedRow.ListPriceDisplay = usrGoodsInfoRow.SelectedListPrice;// DEL 2009/11/13
                        // 優良部品情報を含まない時（品番検索(優良)）
                        // 優良価格設定
                        selectedRow.ListPriceDisplay_Prime = usrGoodsInfoRow.SelectedListPrice;// ADD 2009/11/13
                        selectedRow.AcceptChanges();

                        this._estimateInputAcs.EstimateDetailRowListPriceSetting(salesRowNo, EstimateInputAcs.TargetData.PrimeParts, EstimateInputAcs.PriceInputType.PriceDisplay, selectedRow.ListPriceDisplay_Prime);// ADD 2009/11/13

                    }

                }
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

            }
            //------------------ADD 2009/10/22----------------->>>>>
            #endregion
            
			// データ変更フラグプロパティをTrueにする
			this._estimateInputAcs.IsDataChanged = true;
		}

        // --- ADD 2011/02/14 ---------->>>>>
        /// <summary>
        /// 得意先掛率グループコードの取得
        /// </summary>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodNo">品番</param>
        /// <param name="goodMaker">メーカー</param>
        /// <returns></returns>
        /// <br>Note       : 得意先掛率グループコードを取得する</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/02/14</br>
        /// </remarks>
        private int GetCustRateGrpCode(PartsInfoDataSet partsInfoDataSet, string goodNo, int goodMaker)
        {
            ArrayList custRateGroupList;

            // 得意先掛率グループコードマスタの全件取得
            this._estimateInputAcs.GetCustRateGrpList(out custRateGroupList, this._enterpriseCode);

            if (partsInfoDataSet.GetCustRateGrp == null)
            {
                //得意先掛率ｸﾞﾙｰﾌﾟ取得ﾃﾞﾘｹﾞｰﾄ
                partsInfoDataSet.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(this._estimateInputAcs.GetCustRateGrp);
            }

            // 得意先掛率ｸﾞﾙｰﾌﾟｺｰﾄﾞ取得
            partsInfoDataSet.SettingCustRateGrpCode(custRateGroupList, this._estimateInputAcs.SalesSlip.CustomerCode, goodNo, goodMaker);

            // partsInfoDataSetから行取得
            Broadleaf.Application.UIData.PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow
                    = partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodMaker, goodNo);
            if (usrGoodsInfoRow != null)
            {
                return usrGoodsInfoRow.CustRateGrpCode;
            }
            else
            {
                return -1;
            }
        }
        // --- ADD 2011/02/14 ----------<<<<<

        // --- ADD m.suzuki 2010/04/15 ---------->>>>>
        /// <summary>
        /// 全角⇒半角変換
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private string GetKanaString( string orgString )
        {
            // 全角⇒半角変換（途中に含まれる変換できない文字はそのまま）
            return Microsoft.VisualBasic.Strings.StrConv( orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0 );
        }
        // --- ADD m.suzuki 2010/04/15 ----------<<<<<

		/// <summary>
		/// グリッドセルアクティブ化前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2013/01/29 鄭慕鈞</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine#34434、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
		private void uGrid_Details_BeforeCellActivate( object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e )
		{
            // 項目に従いIMEモード設定
            this.uGrid_Details.ImeMode = uiSetControl1.GetSettingImeMode(e.Cell.Column.Key);

            // ゼロ詰め解除実行
            if (e.Cell.Column.DataType == typeof(string) && e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if (e.Cell.Value != null)
                {
                    this._estimateDetailDataTable.Rows[e.Cell.Row.Index][e.Cell.Column.Key] = uiSetControl1.GetZeroPadCanceledText(e.Cell.Column.Key, (string)this._estimateDetailDataTable.Rows[e.Cell.Row.Index][e.Cell.Column.Key]);
                }
            }
            // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
            //-----------------------------------------------------------------------------
            // NoEdit項目のアクティブ状態の文字色指定
            //-----------------------------------------------------------------------------
            //e.Cell.Band.Override.ActiveCellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

            //#region 現在庫数
            ////倉庫がある場合のみ、現在庫数がｾﾞﾛに表示される
            //if (e.Cell.Column.Key == this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName)
            //{
            //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[e.Cell.Row.Index].WarehouseCode.Trim()))
            //    {
            //        e.Cell.Band.Override.ActiveCellAppearance.ForeColor = Color.Transparent;
            //    }
            //}
            //#endregion
            //#region 現在庫数（優良）
            ////倉庫がある場合のみ、現在庫数（優良）がｾﾞﾛに表示される
            //if (e.Cell.Column.Key == this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName)
            //{
            //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[e.Cell.Row.Index].WarehouseCode_Prime.Trim()))
            //    {
            //        e.Cell.Band.Override.ActiveCellAppearance.ForeColor = Color.Transparent;
            //    }
            //}
            //#endregion
            // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
            // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
            this._beforeCell = e.Cell;
		}

        // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
        /// <summary>
        /// uGrid_Details_BeforeSelectChange
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        //private void uGrid_Details_BeforeSelectChange(object sender, Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs e)
        //{
        //    #region 現在庫数
        //    //倉庫がある場合のみ、現在庫数がｾﾞﾛに表示される
        //    Infragistics.Win.UltraWinGrid.UltraGridCell cellShipmentPosCnt = this.uGrid_Details.ActiveRow.Cells[this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName];
        //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[uGrid_Details.ActiveRow.Index].WarehouseCode.Trim()))
        //    {
        //        cellShipmentPosCnt.SelectedAppearance.ForeColor = Color.Transparent;
        //        cellShipmentPosCnt.SelectedAppearance.ForeColorDisabled = Color.Transparent;
        //    }
        //    else
        //    {
        //        cellShipmentPosCnt.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
        //        cellShipmentPosCnt.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
        //    }
        //    #endregion

        //    #region 現在庫数（優良）
        //    //倉庫がある場合のみ、現在庫数（優良）がｾﾞﾛに表示される
        //    Infragistics.Win.UltraWinGrid.UltraGridCell cellShipmentPosCnt_Prime = this.uGrid_Details.ActiveRow.Cells[this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName];
        //    if (string.IsNullOrEmpty(this._estimateDetailDataTable[uGrid_Details.ActiveRow.Index].WarehouseCode_Prime.Trim()))
        //    {
        //        cellShipmentPosCnt_Prime.SelectedAppearance.ForeColor = Color.Transparent;
        //        cellShipmentPosCnt_Prime.SelectedAppearance.ForeColorDisabled = Color.Transparent;
        //    }
        //    else
        //    {
        //        cellShipmentPosCnt_Prime.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
        //        cellShipmentPosCnt_Prime.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
        //    }
        //    #endregion
        //}
        // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------<<<<< 
        // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<

		/// <summary>
		/// グリッドエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_Enter(object sender, EventArgs e)
		{
			if (this.uGrid_Details.ActiveCell == null)
			{
				if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_Details.ActiveCell == null))
				{
					if (this.uGrid_Details.Rows.Count > 0)
					{
						this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._estimateDetailDataTable.GoodsNoColumn.ColumnName];

						//if (( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_Estimate_ReadOnly ) ||
						//    ( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ) ||
						//    ( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_TotalInput ))
						if ( this._estimateInputAcs.SalesSlip.InputMode != EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly ) 

						{
							// 次入力可能セル移動処理
							this.MoveNextAllowEditCell(true);
						}
					}
				}
			}

			//if (( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_Estimate_ReadOnly ) ||
			//    ( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ) ||
			//    ( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_TotalInput ))
			if ( this._estimateInputAcs.SalesSlip.InputMode != EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly ) 
			{
				if (this.uGrid_Details.ActiveCell != null)
				{
                    if (( !this.uGrid_Details.ActiveCell.IsInEditMode ) && ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) && ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        //// 次入力可能セル移動処理
                        //this.MoveNextAllowEditCell(true);
                    }
				}
			}

			// グリッドセルアクティブ後発生イベント
			this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
		}

		/// <summary>
		/// グリッドセルリスト選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_CellListSelect(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			if (e.Cell == null) return;
			//this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
			//this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
		}

		/// <summary>
		/// グリッドセルアクティブ後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
		{
			if (this.uGrid_Details.ActiveCell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

			// StatusBarメッセージ表示設定
			if (cell.Column.Key == this._estimateDetailDataTable.GoodsNoColumn.ColumnName)
			{
				if (this.StatusBarMessageSetting != null)
				{
					this.StatusBarMessageSetting(this, MESSAGE_GoodsCode);
				}
			}
			else
			{
				if (this.StatusBarMessageSetting != null)
				{
					this.StatusBarMessageSetting(this, "");
				}
			}

			// セルアクティブ時ボタン有効無効コントロール処理
			this.ActiveCellButtonEnabledControl(cell.Row.Index, cell.Column.Key);

            // フッタ部明細情報更新イベントコール処理
			this.SettingFooterEventCall();

			// 横スクロールバー位置設定
			if (cell.Column.Key == this._estimateDetailDataTable.GoodsNoColumn.ColumnName)
			{
				this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
			}

            this._beforeCellUpdateCancel = false;
            this._afterCellUpdateCancel = false;

			//if (this.uGrid_Details.ActiveRow != null)
			//    this.SettingFooter(this.GetActiveRowSalesRowNo());
		}

		/// <summary>
		/// グリッド行アクティブ後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
		{
			if (this.uGrid_Details.ActiveRow == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

			// セルアクティブ時ボタン有効無効コントロール処理
            this.ActiveCellButtonEnabledControl(row.Index, null);

			// フッタ部明細情報更新イベントコール処理
			this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

            // 車輌情報設定イベントコール処理
            this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

			this.uButton_Guide.Enabled = false;
		}

		/// <summary>
		/// グリッドデータエラー発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell != null)
			{
				// 数値項目の場合
				if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
					(this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
					(this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
				{
					Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

					// 未入力は0にする
					if (editorBase.CurrentEditText.Trim() == "")
					{
						editorBase.Value = 0;				// 0をセット
						this.uGrid_Details.ActiveCell.Value = 0;
					}
					// 数値項目に「-」or「.」だけしか入ってなかったら駄目です
					else if ((editorBase.CurrentEditText.Trim() == "-") ||
						(editorBase.CurrentEditText.Trim() == ".") ||
						(editorBase.CurrentEditText.Trim() == "-."))
					{
						editorBase.Value = 0;				// 0をセット
						this.uGrid_Details.ActiveCell.Value = 0;
					}
					// 通常入力
					else
					{
						try
						{
							editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
							this.uGrid_Details.ActiveCell.Value = editorBase.Value;
						}
						catch
						{
							editorBase.Value = 0;
							this.uGrid_Details.ActiveCell.Value = 0;
						}
					}
					e.RaiseErrorEvent = false;			// エラーイベントは発生させない
					e.RestoreOriginalValue = false;		// セルの値を元に戻さない
					e.StayInEditMode = false;			// 編集モードは抜ける
				}
			}
		}

		/// <summary>
		/// グリッドマウスクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_MouseClick(object sender, MouseEventArgs e)
		{
			// 右クリック以外の場合
			if (e.Button != MouseButtons.Right) return;

			System.Drawing.Point nowPos = new Point(e.X, e.Y);

			Infragistics.Win.UIElement objElement = this.uGrid_Details.DisplayLayout.UIElement.ElementFromPoint(nowPos);

			// クリック位置が列ヘッダーか判定
			bool isColumnHeader = false;

			if (objElement != null)
			{
				if ((objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader) ||
					(objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement))
				{
					isColumnHeader = true;
					// string columnName = ((Infragistics.Win.UltraWinGrid.ColumnHeader)objElement.SelectableItem).Column.Key;
				}
			}

			if (isColumnHeader)
			{
				// 列ヘッダー右クリック時は何もしない
			}
			else
			{
				// それ以外で右クリックされた場合は、編集のポップアップを表示する
				((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);

				if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow != null))
				{
					if (this.uGrid_Details.ActiveRow.Selected)
					{
						//
					}
					else
					{
						this.uGrid_Details.Selected.Rows.Clear();
						this.uGrid_Details.ActiveRow.Selected = true;
					}
				}
			}
		}

        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2013/02/27 許培珠</br>
        /// <br>             redmine#34803 2013/05/15配信分 明細行のチェックボックスのエラー</br>
        private void uGrid_Details_Click( object sender, EventArgs e )
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
                // マウスポインターが印刷有無セル上にあるか？
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
                if (objCell != null)
                {
                    // 印刷フラグ列
                    if (( objCell.Column.Key == this._estimateDetailDataTable.PrintSelectColumn.ColumnName ) ||
                        ( objCell.Column.Key == this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName ))
                    {
                        // ----- ADD 2013/02/27 xupz for redmine#34803----->>>>>
                        //チェックボックスは編集可
                        if (objCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                        {
                            this._estimateInputAcs.EstimateDetailRowPrintSelectInfoSetting(this._estimateDetailDataTable[targetGrid.ActiveCell.Row.Index].SalesRowNo, targetGrid.ActiveCell.Column.Key);
                        }
                        else
                        {
                            //何もしない
                        }
                        // ----- ADD 2013/02/27 xupz for redmine#34803-----<<<<<
                        //this._estimateInputAcs.EstimateDetailRowPrintSelectInfoSetting(this._estimateDetailDataTable[targetGrid.ActiveCell.Row.Index].SalesRowNo, targetGrid.ActiveCell.Column.Key);// DEL 2013/02/27 xupz for redmine#34803
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.CommitRow);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
            }

        }

		/// <summary>
		/// グリッド 列位置、幅変更後イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uGrid_Details_AfterColPosChanged( object sender, Infragistics.Win.UltraWinGrid.AfterColPosChangedEventArgs e )
		{
			//
		}

		/// <summary>
		/// グリッド 列位置、幅変更前イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uGrid_Details_BeforeColPosChanged( object sender, Infragistics.Win.UltraWinGrid.BeforeColPosChangedEventArgs e )
		{
			if (( this.uGrid_Details.Focused ) && ( this.uGrid_Details.ActiveCell != null ))
			{
				if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[e.ColumnHeaders[0].Column.Key].Header.Fixed == true)
				{
					if (e.PosChanged == Infragistics.Win.UltraWinGrid.PosChanged.Moved)
					{
						e.Cancel = true;
					}
				}
			}
		}

		/// <summary>
		/// グリッドマウスエンターエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			Infragistics.Win.UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				//    if (( this._stockSlipInputAcs.SalesSlip == null ) || ( this._stockSlipInputAcs.SalesSlip.StockGoodsCd > 1 )) return;

				//    Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;

				//    if (cell.Column.Key == this._estimateDetailDataTable.GoodsGuideButtonColumn.ColumnName)
				//    {
				//        Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = this.uToolTipManager_Hint.GetUltraToolTip(this.uGrid_Details);
				//        if (ultraToolTipInfo != null)
				//        {
				//            ultraToolTipInfo.ToolTipTitle = "";
				//            ultraToolTipInfo.ToolTipText = "商品検索";
				//            this.uToolTipManager_Hint.Enabled = true;
				//        }

				//        this.uToolTipManager_Information.Enabled = false;
				//        this.uToolTipManager_Information.HideToolTip();
				//    }
				//    else if (cell.Column.Key == this._estimateDetailDataTable.GoodsNameColumn.ColumnName)
				//    {
				//        cell.Appearance.Cursor = Cursors.Default;
				//        string tipString = this._stockSlipInputAcs.CreateGoodsInfoString(this._estimateDetailDataTable[cell.Row.Index].StockRowNo);

				//        if (tipString != "")
				//        {
				//            cell.Appearance.Cursor = Cursors.Help;

				//            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = this.uToolTipManager_Information.GetUltraToolTip(this.uGrid_Details);
				//            if (ultraToolTipInfo != null)
				//            {
				//                ultraToolTipInfo.ToolTipTitle = "商品情報";
				//                ultraToolTipInfo.ToolTipText = tipString;
				//                this.uToolTipManager_Information.Enabled = true;
				//            }
				//        }
				//        else
				//        {
				//            this.uToolTipManager_Information.Enabled = false;
				//            this.uToolTipManager_Information.HideToolTip();
				//        }

				//        this.uToolTipManager_Hint.Enabled = false;
				//        this.uToolTipManager_Hint.HideToolTip();
				//    }
				//    else if (cell.Column.Key == this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName)
				//    {
				//        cell.Appearance.Cursor = Cursors.Default;

				//        string tipString = "";
				//        if (cell.Appearance.FontData.Underline == Infragistics.Win.DefaultableBoolean.True)
				//        {
				//            tipString = "在庫移動が行われている為、編集できません。";
				//        }

				//        if (tipString != "")
				//        {
				//            cell.Appearance.Cursor = Cursors.Help;

				//            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = this.uToolTipManager_Information.GetUltraToolTip(this.uGrid_Details);
				//            if (ultraToolTipInfo != null)
				//            {
				//                ultraToolTipInfo.ToolTipTitle = "倉庫情報";
				//                ultraToolTipInfo.ToolTipText = tipString;
				//                this.uToolTipManager_Information.Enabled = true;
				//            }
				//        }
				//        else
				//        {
				//            this.uToolTipManager_Information.Enabled = false;
				//            this.uToolTipManager_Information.HideToolTip();
				//        }

				//        this.uToolTipManager_Hint.Enabled = false;
				//        this.uToolTipManager_Hint.HideToolTip();
				//    }
				//    else if (cell.Column.Key == this._estimateDetailDataTable.StockCountDisplayColumn.ColumnName)
				//    {
				//        cell.Appearance.Cursor = Cursors.Default;
				//        string tipString = this._stockSlipInputAcs.CreateStockCountInfoString(this._estimateDetailDataTable[cell.Row.Index].StockRowNo);

				//        if (tipString != "")
				//        {
				//            cell.Appearance.Cursor = Cursors.Help;

				//            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = this.uToolTipManager_Information.GetUltraToolTip(this.uGrid_Details);
				//            if (ultraToolTipInfo != null)
				//            {
				//                ultraToolTipInfo.ToolTipTitle = "数量情報";
				//                ultraToolTipInfo.ToolTipText = tipString;
				//                this.uToolTipManager_Information.Enabled = true;
				//            }
				//        }
				//        else
				//        {
				//            this.uToolTipManager_Information.Enabled = false;
				//            this.uToolTipManager_Information.HideToolTip();
				//        }

				//        this.uToolTipManager_Hint.Enabled = false;
				//        this.uToolTipManager_Hint.HideToolTip();
				//    }
				//    else
				//    {
				//        this.uToolTipManager_Information.Enabled = false;
				//        this.uToolTipManager_Information.HideToolTip();

				//        this.uToolTipManager_Hint.Enabled = false;
				//        this.uToolTipManager_Hint.HideToolTip();
				//    }
				//}
			}
		}

		/// <summary>
		/// グリッドマウスリーヴエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			this.uToolTipManager_Hint.Enabled = false;
			this.uToolTipManager_Hint.HideToolTip();
			this.uToolTipManager_Information.Enabled = false;
			this.uToolTipManager_Information.HideToolTip();

			Infragistics.Win.UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
            }
		}

		/// <summary>
		/// グリッド行、列選択後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterSelectChange( object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e )
		{

		}

		/// <summary>
		/// セルボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			this._estimateDetailDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = e.Cell.Row.Index;
			if (rowIndex == -1) return;

			// 行番号を取得
			int salesRowNo = this._estimateDetailDataTable[rowIndex].SalesRowNo;

		}

		/// <summary>
		/// 明細グリッドリーヴイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Leave( object sender, EventArgs e )
        {
            if (this.StatusBarMessageSetting != null)
            {
                this.StatusBarMessageSetting(this, "");
            }
            if (( this._beforeCell != null ) && ( this._beforeCell.Row.Index >= 0 ))
            {
                if (this._beforeCell.Column.DataType == typeof(string) && this._beforeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // ゼロ詰め実行
                    this._estimateDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key] = uiSetControl1.GetZeroPaddedText(this._beforeCell.Column.Key, (string)this._estimateDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key]);
                }
            }
        }

		/// <summary>
		/// ツールバーツール値変更時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_Main_ToolValueChanged( object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e )
		{
			switch (e.Tool.Key)
			{
				// 明細パターン
				case "ComboBoxTool_DetailPattern":
					int selectOrder = (int)this._detailPatternComboBox.ValueList.ValueListItems[this._detailPatternComboBox.SelectedIndex].DataValue;
					this._estmDtlPtnInfo = this._estimateInputConstructionAcs.GetEstmDtlPtnInfo(selectOrder);
					SettingGridColVisible(this._estmDtlPtnInfo);
                    this.SettingGrid();
                    if (this.uGrid_Details.ActiveCell != null)
                    {
                        this.ChangeActiveCell(0);
                        //switch (this._estmDtlPtnInfo.PartsSearchType)
                        //{
                        //    case EstmDtlPtnInfo.SearchType.Pure:
                        //        if (this._estimateInputAcs.SalesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                        //        {
                        //            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName];
                        //        }
                        //        else
                        //        {
                        //            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._estimateDetailDataTable.GoodsNoColumn.ColumnName];
                        //        }
                                
                        //        //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        //        break;
                        //    case EstmDtlPtnInfo.SearchType.Prime:
                        //        if (this._estimateInputAcs.SalesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                        //        {
                        //            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName];
                        //        }
                        //        else
                        //        {
                        //            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName];
                        //        }
                        //        //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        //        break;
                        //    case EstmDtlPtnInfo.SearchType.None:
                        //        break;
                        //}
                    }
                    break;
                //-----------ADD 2009/10/22---------->>>>>
                case "ComboBoxTool_PriceSelect":
                    this._estimateInputAcs.SetPriceSelectComboBox(this._priceSelectComboBox.SelectedIndex);
                    break;
                //-----------ADD 2009/10/22----------<<<<<
				default:
					break;
			}
		}
		
		/// <summary>
		/// 挿入ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowInsert_Click(object sender, EventArgs e)
		{
			this._estimateDetailDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;

            string message;
            bool judge = this._estimateInputAcs.InsertEstimateDetailRowCheck(out message);
            if (!judge)
            {
                TMsgDisp.Show(
                     this,
                     emErrorLevel.ERR_LEVEL_INFO,
                     this.Name,
                     message,
                     0,
                     MessageBoxButtons.OK);

                return;
            }
			try
			{
				this.Cursor = Cursors.WaitCursor;

				// 仕入明細行挿入処理
				this._estimateInputAcs.InsertEstimateDetailRow(rowIndex, true);

				// 明細グリッドセル設定処理
				this.SettingGrid();

				// 次入力可能セル移動処理
                //this.MoveNextAllowEditCell(true); //DEL chenw 2013.05.08 FOR Redmine#34803
                //--------- ADD chenw 2013.05.08 FOR Redmine#34803 --------------->>>>>
                if (GridAllowEditCheck())
                {
                    this.MoveNextAllowEditCell(true);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Selected = true;
                    this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[rowIndex];
                }
                //--------- ADD chenw 2013.05.08 FOR Redmine#34803 ---------------<<<<<
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}

            this.CellExitEnterEditEnter();

		}

		/// <summary>
		/// 削除ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowDelete_Click(object sender, EventArgs e)
		{
           
			this._estimateDetailDataTable.AcceptChanges();

			// 選択済み行番号リスト取得処理
			List<int> selectedSalesRowNoList = this.GetSelectedSalesRowNoList();
			if ((selectedSalesRowNoList == null) || (selectedSalesRowNoList.Count == 0))
			{
				return;
			}

			string message;
			bool exist = this._estimateInputAcs.DeleteEstimateDetailRowCheck(selectedSalesRowNoList, out message);

			if (!exist)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);

				return;
			}

            bool orderExist = this._estimateInputAcs.ExistOrderSelect(selectedSalesRowNoList);

            message = "選択行を削除してもよろしいですか？";

            if (orderExist)
            {
                message += (Environment.NewLine + Environment.NewLine + "※発注選択したデータが含まれています。");
            }

			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
                message,
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button1);

			if (dialogResult != DialogResult.Yes)
			{
				return;
			}

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();

			try
			{
				this.Cursor = Cursors.WaitCursor;
                /*----DEL 2013/05/08 chenw FOR Redmine#34803 -------------------------->>>>>
                //--------- ADD 2013/05/07 xujx FOR Redmine#34803 --------------->>>>>
                bool isGridAllowEdit = false;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow in this.uGrid_Details.Rows)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridCell ultraGridCell in ultraGridRow.Cells)
                    {
                        if (ultraGridCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                        {
                            isGridAllowEdit = true;
                            break;
                        }
                    }
                    if (isGridAllowEdit == true) break;
                }
                //--------- ADD 2013/05/07 xujx FOR Redmine#34803 ---------------<<<<<
                ------DEL 2013/05/08 chenw FOR Redmine#34803 -------------------------<<<<<*/

                this._estimateInputAcs.UpdateUoeOrderDetailDT(selectedSalesRowNoList);// ADD 2013/05/07 xujx FOR Redmine#34803
				// 明細行削除処理
				this._estimateInputAcs.DeleteEstimateDetailRow(selectedSalesRowNoList, false);

				// 明細グリッドセル設定処理
				this.SettingGrid();

				if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.Rows.Count > rowIndex))
				{
                    /* --------------- DEL 2013/05/07 xujx FOR Redmine#34803 --------------->>>>>
                         this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.GoodsNoColumn.ColumnName];

                         if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                             (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                         {
                             this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                         }
                    --------------- ADD 2013/05/07 xujx FOR Redmine#34803 ---------------<<<<<*/

                    //--------- ADD 2013/05/07 xujx FOR Redmine#34803 --------------->>>>>
                    //if (isGridAllowEdit == true) // DEL 2013/05/08 chenw FOR Redmine#34803 
                    if (GridAllowEditCheck()) // ADD 2013/05/08 chenw FOR Redmine#34803 
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.GoodsNoColumn.ColumnName];
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    //--------- ADD 2013/05/07 xujx FOR Redmine#34803 ---------------<<<<<
				}

				// 次入力可能セル移動処理
                //this.MoveNextAllowEditCell(true); //DEL 2013/05/07 xujx FOR Redmine#34803
                //--------- ADD 2013/05/07 xujx FOR Redmine#34803 --------------->>>>>
                //if (isGridAllowEdit == true) // DEL 2013/05/08 chenw FOR Redmine#34803 
                if (GridAllowEditCheck()) //  ADD 2013/05/08 chenw FOR Redmine#34803 
                {
                    this.MoveNextAllowEditCell(true);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Selected = true;
                    this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[rowIndex];
                }
                //--------- ADD 2013/05/07 xujx FOR Redmine#34803 ---------------<<<<<

				// 在庫調整数量調整
				this._estimateInputAcs.EstimateDetailStockInfoAdjust();

				// データ変更フラグプロパティをTrueにする
				this._estimateInputAcs.IsDataChanged = true;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
            this.CellExitEnterEditEnter();
            this._estimateInputAcs.UpdateUoeOrderDT();//ADD 2013/05/07 xujx FOR Redmine#34803
		}

		/// <summary>
		/// 切り取りボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCut_Click(object sender, EventArgs e)
		{
			this._estimateDetailDataTable.AcceptChanges();

			// 選択済み行番号リスト取得処理
			List<int> selectedSalesRowNoList = this.GetSelectedSalesRowNoList();
			if (selectedSalesRowNoList == null) return;

			// 仕入明細データテーブルRowStatus列初期化処理
			this._estimateInputAcs.InitializeEstimateDetailRowStatusColumn();

			// 仕入明細データテーブルRowStatus列値設定処理
			this._estimateInputAcs.SetEstimateDetailRowStatusColumn(selectedSalesRowNoList, EstimateInputAcs.ctROWSTATUS_CUT);

			// 明細グリッドセル設定処理
			this.SettingGrid();

			// 次入力可能セル移動処理
            //this.MoveNextAllowEditCell(true); //DEL chenw 2013.05.08 FOR Redmine#34803
            //--------- ADD chenw 2013.05.08 FOR Redmine#34803 --------------->>>>>
            if (GridAllowEditCheck())
            {
                this.MoveNextAllowEditCell(true);
            }
            //--------- ADD chenw 2013.05.08 FOR Redmine#34803 ---------------<<<<<
		}

		/// <summary>
		/// コピーボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCopy_Click(object sender, EventArgs e)
		{
			this._estimateDetailDataTable.AcceptChanges();

			// 選択済み行番号リスト取得処理
			List<int> selectedSalesRowNoList = this.GetSelectedSalesRowNoList();
			if (selectedSalesRowNoList == null) return;

			// 仕入明細データテーブルRowStatus列初期化処理
			this._estimateInputAcs.InitializeEstimateDetailRowStatusColumn();

			// 仕入明細データテーブルRowStatus列値設定処理
			this._estimateInputAcs.SetEstimateDetailRowStatusColumn(selectedSalesRowNoList, EstimateInputAcs.ctROWSTATUS_COPY);

			// 明細グリッドセル設定処理
			this.SettingGrid();

			// 次入力可能セル移動処理
            //this.MoveNextAllowEditCell(true); //DEL chenw 2013.05.08 FOR Redmine#34803
            //--------- ADD chenw 2013.05.08 FOR Redmine#34803 --------------->>>>>
            if (GridAllowEditCheck())
            {
                this.MoveNextAllowEditCell(true);
            }
            //--------- ADD chenw 2013.05.08 FOR Redmine#34803 ---------------<<<<<
		}

		/// <summary>
		/// 貼り付けボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowPaste_Click(object sender, EventArgs e)
		{

			this._estimateDetailDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;

			// コピー行番号取得処理
			List<int> copySalesRowNoList = this._estimateInputAcs.GetCopyEstimateDetailRowNo();
			if (copySalesRowNoList == null) return;

			int pasteCheck = this._estimateInputAcs.CheckPasteEstimateDetailRow(copySalesRowNoList, rowIndex);

			if (pasteCheck == 1)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"貼り付け対象行に商品が入力されています。" + "\r\n" + "\r\n" +
					"上書きされますが、よろしいですか？",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button1);

				if (dialogResult != DialogResult.Yes)
				{
					return;
				}
			}
			else if (pasteCheck == 2)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"貼り付け対象行に編集不可商品が存在するため、貼り付け処理を行う事ができません。",
					0,
					MessageBoxButtons.OK);

				return;
			}
	
			// 表示行数取得処理
			int prevVisibleRowCount = this.GetVisibleRowCount();

			// 仕入明細行貼り付け処理
			this._estimateInputAcs.PasteEstimateDetailRow(copySalesRowNoList, rowIndex);

			// 明細グリッドセル設定処理
			this.SettingGrid();

			// 在庫調整
			this._estimateInputAcs.EstimateDetailStockInfoAdjust();

			// 次入力可能セル移動処理
            //this.MoveNextAllowEditCell(true); //DEL chenw 2013.05.08 FOR Redmine#34803
            //--------- ADD chenw 2013.05.08 FOR Redmine#34803 --------------->>>>>
            if (GridAllowEditCheck())
            {
                this.MoveNextAllowEditCell(true);
            }
            else
            {
                this.uGrid_Details.Rows[rowIndex].Selected = true;
                this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[rowIndex];
            }
            //--------- ADD chenw 2013.05.08 FOR Redmine#34803 ---------------<<<<<

			// 表示行数取得処理
			int afterVisibleRowCount = this.GetVisibleRowCount();

			// 表示する行数が減った場合、調整する
			if (afterVisibleRowCount < prevVisibleRowCount)
			{
				for (int i = afterVisibleRowCount; i < prevVisibleRowCount; i++)
				{
					this._estimateInputAcs.AddEstimateDetailRow();
				}

				// 明細グリッドセル設定処理
				this.SettingGrid();
			}

			// セルの編集モードを一度解除し、再度編集モードに設定する
			this.CellExitEnterEditEnter();

            // 車輌情報設定イベントコール処理
            this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

			// データ変更フラグプロパティをTrueにする
			this._estimateInputAcs.IsDataChanged = true;

            //UoeOrderDataTableを更新処理
            this._estimateInputAcs.UpdateUoeOrderDT();// ADD 2013/05/07 xujx FOR Redmine#34803

			this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
		}

		/// <summary>
		/// ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2011/02/14　鄧潘ハン</br>
        /// <br>             ＢＬコード複数検索時に空白行を詰めるように修正</br>
        /// <br>Update Note: 2013/01/29 鄭慕鈞</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine#34434、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
        private void uButton_Guide_Click(object sender, EventArgs e)
		{
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
            }

			this._estimateDetailDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;

			if (this.uButton_Guide.Tag == null) return;

			// 行番号を取得
			int salesRowNo = this._estimateDetailDataTable[rowIndex].SalesRowNo;

            #region ●倉庫ガイド
            //---------------------
			// 倉庫ガイド
			//---------------------
			if ((this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName)||
                (this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName))
			{
                EstimateInputAcs.TargetData targetData = ( ( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName ) ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;

                string goodsNo = ( targetData == EstimateInputAcs.TargetData.PureParts ) ? this._estimateDetailDataTable[rowIndex].GoodsNo : this._estimateDetailDataTable[rowIndex].GoodsNo_Prime;
                int goodsMakerCd = ( targetData == EstimateInputAcs.TargetData.PureParts ) ? this._estimateDetailDataTable[rowIndex].GoodsMakerCd : this._estimateDetailDataTable[rowIndex].GoodsMakerCd_Prime;
                Stock retStock;

                MAZAI04117U goodsStockGuide = new MAZAI04117U();
                DialogResult dialogResult = goodsStockGuide.ShowGuide(this, this._enterpriseCode, goodsNo, goodsMakerCd, out retStock);

                if (dialogResult == DialogResult.OK)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                    // 在庫情報設定処理
                    this._estimateInputAcs.EstimateDetailRowStockSetting(salesRowNo, targetData, retStock);

                    if (targetData == EstimateInputAcs.TargetData.PrimeParts)
                    {
                        this._estimateInputAcs.SettingPrimeInfoRowFromEstimateDetailRow(salesRowNo);
                    }

                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                    if (targetData == EstimateInputAcs.TargetData.PrimeParts)
                    {
                        this._estimateInputAcs.SettingPrimeInfoRowFromEstimateDetailRow(salesRowNo);
                    }

                    // データ変更フラグプロパティをTrueにする
                    this._estimateInputAcs.IsDataChanged = true;

                    // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                    // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                    // セル情報を取得
                    //Infragistics.Win.UltraWinGrid.UltraGridCell cell = (targetData == EstimateInputAcs.TargetData.PureParts) ? 
                    //    this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName]
                    //    :this.uGrid_Details.Rows[rowIndex].Cells[this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName];

                    //if (!string.IsNullOrEmpty(retStock.WarehouseCode))
                    //{
                    //    cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                    //}
                    // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                    // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
                }
			}
			#endregion

			#region ●BLコードガイド
			//---------------------
			// BLコードガイド
			//---------------------
			else if (( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName )||
                     ( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName ))

			{
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                string columnKey = this.uButton_Guide.Tag.ToString();

                if (( this._estimateInputAcs.SalesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch ) &&
                    ( !this._estimateInputAcs.ExistDetailInput(salesRowNo) ))
                {
                    List<BLGoodsCdUMnt> bLGoodsCdUMntList;

                    int lastRowNo = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
                    //int status = this._estimateInputAcs.ExecuteBLGoodsGuide(this, out bLGoodsCdUMntList, salesRowNo);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
                    int status = this._estimateInputAcs.ExecuteBLGoodsGuide( this, out bLGoodsCdUMntList, salesRowNo, LoginInfoAcquisition.Employee.BelongSectionCode.Trim(), _estimateInputAcs.SalesSlip.CustomerCode, _estimateInputConstructionAcs.BLGuideModeValue );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

                    switch (status)
                    {
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            {
                                int index = 0;
                                bool dispProgressForm = ( this.GetComboBoxToolValue(this._partsSelectComboBox) == 1 );

                                // 共通処理中画面生成
                                SFCMN00299CA progressForm = new SFCMN00299CA();
                                progressForm.DispCancelButton = false;
                                progressForm.Title = "データ検索中";
                                progressForm.Message = "現在、データ検索中です．．．";

                                try
                                {
                                    System.Windows.Forms.Application.DoEvents();
                                    if (dispProgressForm)
                                    {

                                        progressForm.Show(this._ownerForm);
                                    }
                                    foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLGoodsCdUMntList)
                                    {

                                        int blCode = bLGoodsCdUMnt.BLGoodsCode;

                                        PartsInfoDataSet partsInfoDataSet;
                                        List<GoodsUnitData> goodsUnitDataList;
                                        List<UnitPriceCalcRet> unitPriceCalcRetList;
                                        EstimateInputAcs.DataSettingResult dataSettingResult = EstimateInputAcs.DataSettingResult.Ok;

                                        PMKEN01010E searchCarInfo = this._estimateInputAcs.GetSearchCarInfo(salesRowNo);

                                        status = this.BLPartsSearch(blCode, searchCarInfo, out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList);

                                        List<int> settingSalesRowNoList = new List<int>();


                                        switch (status)
                                        {
                                            // 検索OK
                                            case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                                {
                                                    if (( partsInfoDataSet != null ) && ( goodsUnitDataList != null ) && ( goodsUnitDataList.Count > 0 ))
                                                    {
                                                        //this._estimateInputAcs.EstimateDetailRowFromPurePartsSearchResult(salesRowNo + index, EstimateInputAcs.GoodsSearchDiv.BLPartsSearch, goodsUnitDataList, partsInfoDataSet, unitPriceCalcRetList, true, out settingSalesRowNoList);

                                                        //dataSettingResult = this._estimateInputAcs.EstimateDetailRowPurePartsSearchResultSetting(salesRowNo + index, EstimateInputAcs.GoodsSearchDiv.BLPartsSearch, goodsUnitDataList, partsInfoDataSet, unitPriceCalcRetList, true, out settingSalesRowNoList, false, blCode);
                                                        dataSettingResult = this._estimateInputAcs.EstimateDetailRowBLPartsSearchResultSetting(salesRowNo + index, EstimateInputAcs.GoodsSearchDiv.BLPartsSearch, goodsUnitDataList, partsInfoDataSet, unitPriceCalcRetList, true, out settingSalesRowNoList, false, blCode);

                                                        foreach (int targetRow in settingSalesRowNoList)
                                                        {
                                                            // 車輌情報設定イベントコール処理
                                                            this.SettingCarInfoEventCall(targetRow);

                                                            if (lastRowNo <= targetRow)
                                                            {
                                                                lastRowNo = targetRow;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                            // キャンセル
                                            case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                                                {
                                                    break;
                                                }
                                            // 車輌無し
                                            case -3:
                                                {
                                                    break;
                                                }
                                            default:
                                                {
                                                    break;
                                                }
                                        }

                                        // UPD 2011/02/14--------------------------->>>>>
                                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                        {
                                           index += goodsUnitDataList.Count;
                                        }
                                        // UPD 2011/02/14---------------------------<<<<<

                                        this.SettingGrid();

                                        if (dataSettingResult == EstimateInputAcs.DataSettingResult.OverRowCount)
                                        {
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "明細行数が最大行数を超える為、検索を中断しました。",
                                                -1,
                                                MessageBoxButtons.OK);
                                            break;
                                        }
                                    }

                                    // 最終行に空行を追加
                                    this.AddLastEmptyRow();

                                    // データ変更フラグプロパティをTrueにする
                                    this._estimateInputAcs.IsDataChanged = true;
                                }
                                finally
                                {
                                    if (dispProgressForm)
                                    {
                                        // 共通処理中画面終了
                                        progressForm.Close();
                                    }
                                }
                               
                                if (lastRowNo > 0)
                                {
                                    int lastRowIndex = this._estimateInputAcs.GetIndexFromSalesRowNo(lastRowNo);
                                    if (lastRowIndex >= 0)
                                    {
                                        if (this._estimateDetailDataTable.Rows.Count > ( lastRowIndex + 1 ))
                                        {
                                            if (( !this.uGrid_Details.Rows[lastRowIndex + 1].Cells[columnKey].Hidden ) &&
                                                ( this.uGrid_Details.Rows[lastRowIndex + 1].Cells[columnKey].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                            {
                                                this.uGrid_Details.Rows[lastRowIndex + 1].Cells[columnKey].Activated = true;
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            }
                                        }
                                        else
                                        {
                                            this.uGrid_Details.Rows[lastRowIndex].Cells[columnKey].Activated = true;
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }

                                break;
                            }
                        case -3:
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "車輌情報が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {

                    BLGoodsCdAcs blGoodsCdAcs = new BLGoodsCdAcs();

                    BLGoodsCdUMnt blGoodsCdUMnt;

                    int status = blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        EstimateInputAcs.TargetData target = ( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;

                        // BLコード名称設定処理
                        this._estimateInputAcs.EstimateDetailBLGoodsInfoSetting(salesRowNo, target, blGoodsCdUMnt);

                        if (target == EstimateInputAcs.TargetData.PrimeParts)
                        {
                            this._estimateInputAcs.SettingPrimeInfoRowFromEstimateDetailRow(salesRowNo);
                        }

                        // データ変更フラグプロパティをTrueにする
                        this._estimateInputAcs.IsDataChanged = true;
                    }

                }
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
			#endregion

			#region ●メーカーガイド
			//---------------------
			// メーカーガイド
			//---------------------
            else if (( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName ) ||
                     ( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName ))
            {
                EstimateInputAcs.TargetData targetdata = ( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;

                if (this._estimateInputAcs.ExistOrderSelect(salesRowNo, targetdata))
                {
                    TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "発注選択済みの為、変更できません。",
                           -1,
                           MessageBoxButtons.OK);

                }
                else
                {
                    int beforeMakerCd = (int)this._estimateDetailDataTable[rowIndex][this.uButton_Guide.Tag.ToString()];
                    string beforeMakerName = ( targetdata == EstimateInputAcs.TargetData.PureParts ) ? this._estimateDetailDataTable[rowIndex].MakerName : this._estimateDetailDataTable[rowIndex].MakerName_Prime;
                    string beforeMakerKanaName = ( targetdata == EstimateInputAcs.TargetData.PureParts ) ? this._estimateDetailDataTable[rowIndex].MakerKanaName : this._estimateDetailDataTable[rowIndex].MakerKanaName;

                    MakerAcs makerAcs = new MakerAcs();

                    MakerUMnt makerUMnt;

                    int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        // メーカー名称設定処理
                        bool isMakerChangd;
                        this._estimateInputAcs.EstimateDetailMakerInfoSetting(salesRowNo, targetdata, makerUMnt.GoodsMakerCd, makerUMnt.MakerName, makerUMnt.MakerKanaName, out isMakerChangd);

                        string goodsNo = this._estimateDetailDataTable[rowIndex].GoodsNo;

                        // メーカーが変わった場合は商品を再検索
                        if (( isMakerChangd ) && ( !String.IsNullOrEmpty(goodsNo) ))
                        {
                            switch (this.SearchPartsAndRowSetting(rowIndex, targetdata))
                            {
                                case 0:
                                    break;
                                case -1:
                                    this._estimateInputAcs.EstimateDetailMakerInfoSetting(salesRowNo, targetdata, beforeMakerCd, beforeMakerName, beforeMakerKanaName);
                                    break;
                            }
                        }

                        if (targetdata == EstimateInputAcs.TargetData.PrimeParts)
                        {
                            this._estimateInputAcs.SettingPrimeInfoRowFromEstimateDetailRow(salesRowNo);
                        }
                        // データ変更フラグプロパティをTrueにする
                        this._estimateInputAcs.IsDataChanged = true;

                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
            }
			#endregion

            #region ●仕入先ガイド
            //---------------------
            // 仕入先ガイド
            //---------------------
            else if (( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.SupplierCdColumn.ColumnName ) ||
                ( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName ))
            {
                EstimateInputAcs.TargetData targetdata = ( this.uButton_Guide.Tag.ToString() == this._estimateDetailDataTable.SupplierCdColumn.ColumnName ) ? EstimateInputAcs.TargetData.PureParts : EstimateInputAcs.TargetData.PrimeParts;

                if (this._estimateInputAcs.ExistOrderSelect(salesRowNo, targetdata))
                {
                    TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "発注選択済みの為、変更できません。",
                           -1,
                           MessageBoxButtons.OK);

                }
                else
                {
                    int beforeSupplierCd = (int)this._estimateDetailDataTable[rowIndex][this.uButton_Guide.Tag.ToString()];
                    string beforeSupplierSnm = ( targetdata == EstimateInputAcs.TargetData.PureParts ) ? this._estimateDetailDataTable[rowIndex].SupplierSnm: this._estimateDetailDataTable[rowIndex].SupplierSnm_Prime;

                    SupplierAcs supplierAcs = new SupplierAcs();

                    Supplier supplier;
                    int status = supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        if (supplier.SupplierCd != beforeSupplierCd)
                        {
                            this._estimateInputAcs.EstimateDetailSupplierInfoSetting(salesRowNo, targetdata, supplier);

                            DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "仕入先が変更されました。" + "\r\n" + "\r\n" +
                                        "商品価格を再取得しますか？",
                                        0,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                this._estimateInputAcs.EstimateDetailRowPriceReSetting(targetdata, salesRowNo);
                            }
                            else
                            {
                                this._estimateInputAcs.EstimateDetailRowClearRateInfo(salesRowNo, UnitPriceCalculation.UnitPriceKind.ListPrice, targetdata, false);
                                this._estimateInputAcs.EstimateDetailRowClearRateInfo(salesRowNo, UnitPriceCalculation.UnitPriceKind.UnitCost, targetdata, false);
                            }

                            if (targetdata == EstimateInputAcs.TargetData.PrimeParts)
                            {
                                this._estimateInputAcs.SettingPrimeInfoRowFromEstimateDetailRow(salesRowNo);
                            }

                            // データ変更フラグプロパティをTrueにする
                            this._estimateInputAcs.IsDataChanged = true;
                        }

                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
            }
            #endregion

        }

        /// <summary>
        /// 見積履歴ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2011/03/28 曹文傑</br>
        /// <br>             Redmine #20177の対応</br>
        private void uButton_EstimateReference_Click( object sender, EventArgs e )
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
            }

            this._estimateDetailDataTable.AcceptChanges();

            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            List<SalHisRefResultParamWork> salHisRefResultParamWorkList;
            DCHNB04101UA salesHisGuide = new DCHNB04101UA();
            salesHisGuide.AcptAnOdrStatus = 10;
            salesHisGuide.AutoSearch = true;
            //salesHisGuide.MaxSelectCount = this._salesInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            salesHisGuide.MaxSelectCount = this.uGrid_Details.Rows.Count - this._estimateInputAcs.GetAlreadyInputRowCount();
            salesHisGuide.SectionCode = this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd;
            salesHisGuide.SectionName = this._estimateInputAcs.SalesSlip.ResultsAddUpSecNm;
            salesHisGuide.CustomerCode = this._estimateInputAcs.SalesSlip.CustomerCode;
            salesHisGuide.CustomerName = this._estimateInputAcs.SalesSlip.CustomerSnm;
            // ---ADD 2011/03/28------------>>>>>
            salesHisGuide.SalesSlipCd = -1;
            // ---ADD 2011/03/28------------<<<<<

            DialogResult dialogResult = salesHisGuide.ShowDialog(this, 10, this._estimateInputAcs.SalesSlip.CustomerCode);

            if (dialogResult == DialogResult.OK)
            {
                salHisRefResultParamWorkList = salesHisGuide.StcHisRefDataWork;
                int lastInputStockRow = this._estimateInputAcs.GetLastInputSalesRowNo();
                this._estimateInputAcs.EstimateDetailRowSettingFromSalHisRefResultParamWorkList(lastInputStockRow + 1, salHisRefResultParamWorkList);

                // データ変更フラグプロパティをTrueにする
                this._estimateInputAcs.IsDataChanged = true;

                //// 売上金額変更後発生イベントコール処理
                //this.SalesPriceChangedEventCall();

                //// フッタ部明細情報更新イベントコール処理
                //this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                // 車輌情報設定イベントコール処理
                this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

                // コピー伝票車輌情報生成処理
                this._estimateInputAcs.CreateSlipCopyCarInfo();

                // 明細グリッド設定処理
                this.SettingGrid();

                // 最終行に空行を追加
                this.AddLastEmptyRow();
            }

            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// セットボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SetDisplay_Click( object sender, EventArgs e )
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                int salesRowNo = this._estimateDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].SalesRowNo;
                string goodsNo = string.Empty;
                int goodsMakerCd = 0;
                bool existSetInfo = false;
                Guid partsInfoLinkGuid = Guid.Empty;
                PartsInfoDataSet partsInfo = null;
                EstimateInputAcs.TargetData targetData = EstimateInputAcs.TargetData.PureParts;

                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;

                // アクティブセルが優良部品項目の場合

                switch (this._estimateInputColInfoInitialSetting.GetAttr(this.uGrid_Details.ActiveCell.Column.Key))
                {
                    // 純正部品
                    case ColDisplayBasicInfo.DataAttribute.PureParts:
                        {
                            goodsNo = this._estimateDetailDataTable[rowIndex].GoodsNo;
                            goodsMakerCd = this._estimateDetailDataTable[rowIndex].GoodsMakerCd;
                            existSetInfo = this._estimateDetailDataTable[rowIndex].ExistSetInfo;
                            partsInfoLinkGuid = this._estimateDetailDataTable[rowIndex].PartsInfoLinkGuid;
                            targetData = EstimateInputAcs.TargetData.PureParts;
                            break;
                        }
                    // 優良部品
                    case ColDisplayBasicInfo.DataAttribute.PrimeParts:
                        {
                            goodsNo = this._estimateDetailDataTable[rowIndex].GoodsNo_Prime;
                            goodsMakerCd = this._estimateDetailDataTable[rowIndex].GoodsMakerCd_Prime;
                            existSetInfo = this._estimateDetailDataTable[rowIndex].ExistSetInfo_Prime;
                            partsInfoLinkGuid = this._estimateDetailDataTable[rowIndex].PartsInfoLinkGuid_Prime;
                            targetData = EstimateInputAcs.TargetData.PrimeParts;
                            break;
                        }
                    // 無し
                    default:
                        {
                            break;
                        }
                }

                partsInfo = this._estimateInputAcs.GetPartsInfoDataSet(partsInfoLinkGuid);
                rowIndex++;

                if (( existSetInfo ) && ( partsInfo != null ))
                {
                    // 車両情報補正
                    #region 車両情報補正
                    // --- ADD 譚洪 2014/09/01 ---------->>>>>
                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.SearchCarInfo = partsInfo.SearchCarInfo;
                    this._estimateInputAcs.SetCarInfoToThread(cndtn);
                    // --- ADD 譚洪 2014/09/01 ----------<<<<<
                    #endregion

                    DialogResult dialogResult = UIDisplayControl.SESetUI(this, partsInfo, goodsMakerCd, goodsNo);

                    if (dialogResult == DialogResult.OK)
                    {
                        List<GoodsUnitData> goodsUnitDataList;
                        List<UnitPriceCalcRet> unitPriceCalcRetList;
                        this._estimateInputAcs.GetSelectedDataFromPartsInfoSet(partsInfo, out goodsUnitDataList, out unitPriceCalcRetList);

                        foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                        {
                            // 行挿入処理
                            this._estimateInputAcs.InsertEstimateDetailRow(rowIndex, true);

                            this._estimateInputAcs.EstimateDetailRowSetGoodsSetting(rowIndex, targetData, goodsUnitData, partsInfoLinkGuid, unitPriceCalcRetList);

                            // 明細グリッドセル設定処理
                            this.SettingGrid();

                            rowIndex++;
                        }

                        this.AddLastEmptyRow();
                    }
                }
            }
            this.CellExitEnterEditEnter();

        }

        /// <summary>
        /// TBOボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_TBO_Click( object sender, EventArgs e )
        {
            int rowIndex = this.GetActiveRowIndex();
            int salesRowNo = this._estimateDetailDataTable[rowIndex].SalesRowNo;
            List<GoodsUnitData> goodsUnitDataList;
            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList;
            List<int> settingSalesRowNoList;

            // TBO検索
            this.SearchTBO(salesRowNo, out goodsUnitDataList, out partsInfoDataSet, out unitPriceCalcRetList);

            // 検索結果設定処理
            if (( goodsUnitDataList != null ) && ( goodsUnitDataList.Count != 0 ))
            {
                this._estimateInputAcs.EstimateDetailRowPurePartsSearchResultSetting(salesRowNo, EstimateInputAcs.GoodsSearchDiv.BLPartsSearch, goodsUnitDataList, partsInfoDataSet, unitPriceCalcRetList, false, out settingSalesRowNoList, false, 0);

                // データ変更フラグプロパティをTrueにする
                this._estimateInputAcs.IsDataChanged = true;

                // 明細グリッド設定処理
                this.SettingGrid();

                this._estimateInputAcs.EstimateDetailStockInfoAdjust();

                // 最終行に空行を追加
                this.AddLastEmptyRow();
            }
        }

        /// <summary>
        /// 車種変更ボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ChangeCarInfo_Click( object sender, EventArgs e )
        {
            int salesRowNo = this.GetActiveRowSalesRowNo();

            // 車輌情報データ→画面
            EstimateInputDataSet.CarInfoRow row = this._estimateInputAcs.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.NewInsertMode);

            this.SettingCarInfoEventCall(salesRowNo);

            this.SettingFocusEventCall(ct_ITEM_NAME_CARMNGCODE);
        }

        /// <summary>
        /// 倉庫切替ボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2013/01/29 鄭慕鈞</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine#34434、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
        private void uButton_WarehouseChange_Click( object sender, EventArgs e )
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                int salesRowNo = this._estimateDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].SalesRowNo;

                EstimateInputAcs.TargetData targetData = EstimateInputAcs.TargetData.All;

                switch (this._estimateInputColInfoInitialSetting.GetAttr(this.uGrid_Details.ActiveCell.Column.Key))
                {
                    case ColDisplayBasicInfo.DataAttribute.None:
                        return;
                    case ColDisplayBasicInfo.DataAttribute.PureParts:
                        targetData = EstimateInputAcs.TargetData.PureParts;
                        break;
                    case ColDisplayBasicInfo.DataAttribute.PrimeParts:
                        targetData = EstimateInputAcs.TargetData.PrimeParts;
                        break;
                    default:
                        break;
                }
                // 2009.06.18 Add >>>
                List<Stock> stockList = this._estimateInputAcs.SearchStock(salesRowNo, targetData, false);
                if (stockList != null)
                {
                    this._estimateInputAcs.CacheStockInfo(stockList);
                }
                // 2009.06.18 Add <<<

                this._estimateInputAcs.EstimateDetailRowWarehouseChange(salesRowNo, targetData);

                if (targetData == EstimateInputAcs.TargetData.PrimeParts)
                {
                    this._estimateInputAcs.SettingPrimeInfoRowFromEstimateDetailRow(salesRowNo);
                }
                // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ >>>>>
                //UltraGridColumn col = this.uGrid_Details.Rows[salesRowNo].Cells[this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName].Column;
                //UltraGridColumn col_Prime = this.uGrid_Details.Rows[salesRowNo].Cells[this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName].Column;
                //int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                //Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                //Infragistics.Win.UltraWinGrid.UltraGridCell cell_Prime = this.uGrid_Details.Rows[rowIndex].Cells[col_Prime];
                //Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.uGrid_Details.ActiveCell;
                //if (this.uGrid_Details.ActiveCell.Column == col || this.uGrid_Details.ActiveCell.Column == col_Prime)
                //{
                //    activeCell.Activated = false;

                //}
                ////倉庫がある場合のみ、現在庫数がｾﾞﾛに表示される
                //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode.Trim()))
                //{
                //    cell.Appearance.ForeColor = Color.Transparent;
                //}
                //else
                //{
                //    cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                //}

                ////倉庫がある場合のみ、現在庫数（優良）がｾﾞﾛに表示される
                //if (string.IsNullOrEmpty(this._estimateDetailDataTable[rowIndex].WarehouseCode_Prime.Trim()))
                //{
                //    cell_Prime.Appearance.ForeColor = Color.Transparent;
                //}
                //else
                //{
                //    cell_Prime.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                //}
                //activeCell.Activated = true;

                // -----ADD 鄭慕鈞　Redmine#34434 2013/01/29------ <<<<<
                // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<
            }
            this.CellExitEnterEditEnter();

        }

        // --- ADD 2010/08/05 ---------->>>>>
        /// <summary>
        /// 次候補ボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_NextCandidate_Click(object sender, EventArgs e)
        {
            this.SetCandidate(0);
        }

        /// <summary>
        /// 全候補ボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_AllCandidate_Click(object sender, EventArgs e)
        {
            this.SetCandidate(1);
        }
        // --- ADD 2010/08/05 ----------<<<<<

        #region ◎各ボタンのEnabled発生後イベント
        /// <summary>
		/// 挿入ボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowInsert_EnabledChanged(object sender, EventArgs e)
		{
			this._rowInsertButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}

		/// <summary>
		/// 削除ボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowDelete_EnabledChanged(object sender, EventArgs e)
		{
			this._rowDeleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}

		/// <summary>
		/// 切り取りボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCut_EnabledChanged(object sender, EventArgs e)
		{
			this._rowCutButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}

		/// <summary>
		/// コピーボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCopy_EnabledChanged(object sender, EventArgs e)
		{
			this._rowCopyButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}

		/// <summary>
		/// 削除ボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowPaste_EnabledChanged(object sender, EventArgs e)
		{
			this._rowPasteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
		}

		/// <summary>
		/// ツールバーツールクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_Main_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			switch (e.Tool.Key)
			{
				// 行挿入
				case "ButtonTool_RowInsert":
					{
						this.uButton_RowInsert_Click(this.uButton_RowInsert, new EventArgs());
						break;
					}
				// 行削除
				case "ButtonTool_RowDelete":
					{
						this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
						break;
					}
				// 切り取り
				case "ButtonTool_RowCut":
					{
						this.uButton_RowCut_Click(this.uButton_RowCut, new EventArgs());
						break;
					}
				// コピー
				case "ButtonTool_RowCopy":
					{
						this.uButton_RowCopy_Click(this.uButton_RowCopy, new EventArgs());
						break;
					}
				// 貼り付け
				case "ButtonTool_RowPaste":
					{
						this.uButton_RowPaste_Click(this.uButton_RowPaste, new EventArgs());
						break;
					}
			}
		}

        #endregion
       
       
		# endregion
		
	}
}
