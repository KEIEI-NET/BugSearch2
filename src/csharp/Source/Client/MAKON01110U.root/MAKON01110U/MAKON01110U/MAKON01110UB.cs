using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 仕入入力明細入力コントロールクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入入力の明細入力を行うコントロールクラスです。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.09.06</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men 新規作成</br>
    /// <br>2009.03.25 20056 對馬 大輔 MANTIS[0010871] 現在庫数のｾﾞﾛ表示制御(倉庫がある場合のみｾﾞﾛ表示あり)</br>
    /// <br>2009.04.02 20056 對馬 大輔 MANTIS[0013054] 現在庫数のｶﾝﾏ編集追加</br>
    /// <br>2009.07.10 21024 佐々木 健 MANTIS[0013756] 下方向に入力行が無い場合に、１行下の品番にフォーカス移動するように修正</br>
    /// <br>2009.08.03 21024 佐々木 健 MANTIS[0013909] 先頭行が行値引きで２行目で↑押下時、エラーになる不具合の修正</br>
    /// <br>2010.05.04 gaoyh 1007E セキュリティ管理「数量マイナス」「商品値引」の追加（６次改良）</br>
    /// <br>2010.05.18 gaoyh #7833 ６次改良　仕入伝票入力の仕様追加について</br>
    /// <br>2010/12/03 yangmj 障害改良対応</br>
    /// <br>2011/07/18 曹文傑 MANTIS[17500] 連番1028、Redmine22936</br>
    /// <br>              仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される</br>
    /// <br>2011/12/16 凌小青 Redmine#26856の対応。</br>
    /// <br>Update Note : 2012/06/15 tianjw</br>
    /// <br>管理番号    : 10801804-00 2012/07/25配信分</br>
    /// <br>              Redmine#30517 品名未入力行の不具合の対応</br>
    /// <br>Update Note : 2012/10/15 田建委</br>
    /// <br>管理番号    : 10801804-00、2012/11/14配信分</br>
    /// <br>              Redmine#32862 価格変更した明細、色を変えるように修正</br>
    //----------------------------------------------------------------------------//
    // 管理番号              作成担当 : FSI千田 晃久
    // 修 正 日  2013/01/07  修正内容 : 仕入返品予定機能対応
    //----------------------------------------------------------------------------//
    /// <br>UpdateNote : 2014/04/24　鄧潘ハン</br>
    /// <br>管理番号   : 11070071-00 システムテスト障害一覧No.2312の対応</br>
    /// <br>             Redmine#42258　仕入伝票入力で該当データなしになる件の修正</br>
    /// <br>Update Note: 2015/08/26 cheq</br>　
    /// <br>管理番号   : 11170129-00 Redmine#47008</br>
    /// <br>             メーカー名称の値がメーカーコードになるの障害対応</br>
    /// <br>Update Note: 2020/06/22 陳艶丹</br>
    /// <br>管理番号   : 11670231-00</br>
    /// <br>           : PMKOBETSU-4017 東邦車両サービス(仕入データテキスト入力)</br>
    /// <br>Update Note: 2021/10/26 譚洪</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応</br> 
    /// <br>Update Note: 2022/01/20 陳艶丹</br>
    /// <br>管理番号   : 11800082-00</br>
    /// <br>           : BLINCIDENT-3254 再度同一品番選択画面が表示される対応</br> 
    /// </remarks>
	public partial class MAKON01110UB : UserControl
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constroctors
		/// <summary>
		/// 仕入入力明細入力コントロールクラス デフォルトコンストラクタ
		/// </summary>
        public MAKON01110UB(IOperationAuthority opeCtrl)
		{
            InitializeComponent();

            // 変数初期化
            this._rowInsertButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowInsert"];
            this._rowDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowDelete"];
            this._rowCutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCut"];
            this._rowCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCopy"];
            this._rowPasteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowPaste"];
            this._rowDiscountButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowDiscount"];
            //this._goodsDiscountButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_GoodsDiscount"];


            // ボタンリスト
            this._buttonList = new List<Infragistics.Win.Misc.UltraButton>();
            this._buttonList.Add(this.uButton_ArrivalReference);
            this._buttonList.Add(this.uButton_Guide);
            this._buttonList.Add(this.uButton_OrderReference);
            this._buttonList.Add(this.uButton_RowCopy);
            this._buttonList.Add(this.uButton_RowCut);
            this._buttonList.Add(this.uButton_RowDelete);
            this._buttonList.Add(this.uButton_RowDiscount);
            this._buttonList.Add(this.uButton_GoodsDiscount);
            this._buttonList.Add(this.uButton_RowInsert);
            this._buttonList.Add(this.uButton_RowPaste);
            this._buttonList.Add(this.uButton_StockReference);
            this._buttonList.Add(this.uButton_StockSearch);
            this._buttonList.Add(this.uButton_InputChange);

            this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
            this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();
            this._stockDetailDataTable = this._stockSlipInputAcs.StockDetailDataTable;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this._stockInputConstructionAcs = StockSlipInputConstructionAcs.GetInstance();
            this._stockInputConstructionAcs.DataChanged += new EventHandler(this.StockInputConstructionAcs_DataChanged);

            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatusExp> colDisplayStatusList = ColDisplayStatusList.Deserialize(ct_FILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._stockDetailDataTable);

            this._stockInputConstructionAcs.GetColDisplayInfoInitList += new StockSlipInputConstructionAcs.GetColDisplayInfoEventHandler(this._colDisplayStatusList.GetColDisplayInfoInitList);
            this._stockInputConstructionAcs.GetColDisplayInfoList += new StockSlipInputConstructionAcs.GetColDisplayInfoEventHandler(this._colDisplayStatusList.GetColDisplayInfoList);
            this._stockInputConstructionAcs.SetColDisplayInfoList += new StockSlipInputConstructionAcs.SetColDisplayInfoEventHandler(this.RestoreColDisplayList);

            // 仕入明細データテーブル列表示設定クラスセッティング処理
            this.SettingStockDetailRowVisibleControl();

            this._salesInputList = new List<string>();
            this._salesInputList.Add(this._stockDetailDataTable.CustomerCodeColumn.ColumnName);
            this._salesInputList.Add(this._stockDetailDataTable.CustomerCodeColumn.ColumnName);
            this._salesInputList.Add(this._stockDetailDataTable.SalesListPriceDisplayColumn.ColumnName);
            this._salesInputList.Add(this._stockDetailDataTable.SalesPriceDisplayColumn.ColumnName);
            this._salesInputList.Add(this._stockDetailDataTable.SalesRateColumn.ColumnName);
            this._salesInputList.Add(this._stockDetailDataTable.SalesUnitPriceDisplayColumn.ColumnName);

            this._operationAuthority = opeCtrl;
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;									// イメージリスト
		private StockSlipInputAcs _stockSlipInputAcs;
		private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;
		private StockInputDataSet.StockDetailDataTable _stockDetailDataTable;
        private StockSlipInputConstructionAcs _stockInputConstructionAcs;
		private CustomerInfoAcs _customerInfoAcs;
		private Image _guideButtonImage;
		private StockDetailRowVisibleControl _stockDetailRowVisibleControl = new StockDetailRowVisibleControl();
		private int _verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _beforeGoodsNo = string.Empty;
        private string _beforeWarehouseCode = string.Empty;
		private double _beforeStockCount = 0;
        private double _beforeListPriceDisplay = 0;
        private int _beforeGoodsMakerCd = 0;
        private int _beforeBLGoodsCode = 0;
		private int _beforeSalesCustomerCode = 0;
		private int _beforeCustomerCode = 0;
        private string _beforeGoodsName = string.Empty;
        private string _beforeOrderNumber = string.Empty;
        private double _beforeStockRate = 0;
		private double _beforeStockUnitPriceDisplay = 0;
        private Int64 _beforeStockPrice = 0;
		private bool _cannotGoodsRead = false;
        private bool _supplierSelectError = false;
        private bool _beforeCellUpdateCancel = false;   // BeforeCellUpdateイベントでの入力エラー判定用
        private bool _afterCellUpdateCancel = false;    // AfterCellUpdateイベントでの入力エラー判定用
		private Infragistics.Win.UltraWinGrid.UltraGridCell _beforeCell;
		//private OLEScannerController _OLEScannerController;
		private ColDisplayStatusList _colDisplayStatusList;						// 列表示状態コレクションクラス
		private DisplayType _displayType = DisplayType.Normal;
		private List<string> _salesInputList = new List<string>();
        //private Thread _deserializeThread;

        private string _prevGoodsName = string.Empty; // 前回の品名 // ADD 2012/06/15 tianjw Redmine#30517

        //private List<ColDisplayStatusExp> _colDisplayStatusDefList;
        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト

		private List<Infragistics.Win.Misc.UltraButton> _buttonList;			// ボタンのリスト

		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowInsertButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDeleteButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCutButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCopyButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowPasteButton;
		private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDiscountButton;
		//private Infragistics.Win.UltraWinToolbars.ButtonTool _goodsDiscountButton;

		private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
		private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
		private static readonly Color ct_READONLY_COLOR = Color.WhiteSmoke;
		private static readonly Color ct_ROWSTATUS_COPY_COLOR = Color.Pink;
		private static readonly Color ct_ROWSTATUS_CUT_COLOR = Color.Gray;
		private static readonly Color ct_REDUCTION_FONT_COLOR = Color.Green;
		private static readonly Color ct_MINUS_FONT_COLOR = Color.Red;
		private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
		private static readonly Color ct_ALLWAYS_CELL_COLOR = Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
		private static readonly Color ct_GOODSDISCOUNT_CELL_COLOR = Color.Pink;

        /// <summary>単価、原価背景色</summary>
        private static readonly Color _CellReadOnlyColor2 = Color.FromArgb(210, 255, 210); // ADD 2012/10/15 田建委 Redmine#32862

		private const string ct_FILENAME_COLDISPLAYSTATUS = "MAKON01110U_ColSetting.DAT";				// 列表示状態セッティングXMLファイル名

		private const string cUIDataKey_BLGoodsCode = "gridCell_BLGoodsCode";
		private const string cUIDataKey_CustomerCode = "gridCell_CustomerCode";
		private const string cUIDataKey_GoodsMakerCd = "gridCell_GoodsMakerCd";
		private const string cUIDataKey_GoodsName = "gridCell_GoodsName";
		private const string cUIDataKey_GoodsNo = "gridCell_GoodsNo";
		private const string cUIDataKey_WarehouseCode = "gridCell_WarehouseCode";

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		internal static readonly string ct_ITEM_NAME_CUSTOMERCODE = "CustomerCode";
		internal const int ct_SettingActiveCell_StockCountError = 1;
        internal const int ct_SettingActiveCell_StockUnitPriceError = 2;
        internal const int ct_SettingActiveCell_StockPriceError = 3;
        internal const int ct_SettingActiveCell_GoodsNameError = 4;
        private const string MESSAGE_GoodsCode = "前方一致検索：最後に*を入力[例:A*]";
        //--- ADD 譚洪 2021/10/26 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 ----->>>>>
        private const string StrResearchErrMsg = "商品検索でエラーが発生しました。\n\r商品を再度入力してください。";
        //--- ADD 譚洪 2021/10/26 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 -----<<<<<
        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 ----->>>>>
        // アスタリスク
        private const string CTASTER = "*";
        // ハイフン
        private const string CTHYPHEN = "-";
        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 -----<<<<<
		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
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
        /// 行変更デリゲート
        /// </summary>
        /// <param name="stockRowno"></param>
        internal delegate void SettingFooterEventHandler( int stockRowno );

		/// <summary>
		/// ツールバーボタン制御デリゲート
		/// </summary>
		internal delegate void SettingToolbarEventHandler();

		/// <summary>
		/// 得意先変更デリゲート
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		/// <param name="salesTempRow">同時売上オブジェクト</param>
		/// <param name="customerInfo">得意先情報オブジェクト</param>
		internal delegate void StockDetailCustomerChangeEventHandler( int stockRowNo, SalesTemp salesTemp, CustomerInfo customerInfo );

		/// <summary>
		/// 残検索デリゲート
		/// </summary>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="makerCode">検索結果</param>
		/// <returns></returns>
		private delegate int RemainSearchProc( GoodsUnitData goodsUnitData, out object retObj );

		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		/// <summary>グリッド最上位行キーダウンイベント</summary>
		internal event EventHandler GridKeyDownTopRow;
		
		/// <summary>グリッド最下層行キーダウンイベント</summary>
		internal event EventHandler GridKeyDownButtomRow;

        /// <summary>仕入先選択イベントイベント</summary>
        internal event EventHandler SupplierSelect;
		
		/// <summary>仕入金額変更後イベント</summary>
		internal event EventHandler StockPriceChanged;
		
		/// <summary>ステータスバーメッセージ表示イベント</summary>
		internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;

		/// <summary>フォーカス設定イベント</summary>
		internal event SettingFocusEventHandler FocusSetting;

        /// <summary>行変更イベント</summary>
        internal event SettingFooterEventHandler SettingFooter;

		/// <summary>ツールバー設定デリゲート</summary>
		internal event SettingToolbarEventHandler SetToolbarButton;

		/// <summary>得意先情報変更デリゲート</summary>
		internal event StockDetailCustomerChangeEventHandler StockDetailCustomerChange;

		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
#if false
		/// <summary>
		/// OLEControllerオブジェクトプロパティ
		/// </summary>
		internal OLEScannerController OLEScannerControllerObject
		{
			get
			{
				return this._OLEScannerController;
			}
			set
			{
				this._OLEScannerController = value;

				this._OLEScannerController.DataEvent += new DataEventHandler(this.OLEScanner_DataEvent);
				this._OLEScannerController.ErrorEvent += new ErrorEventHandler(this.OLEScanner_ErrorEvent);
			}
		}
#endif

		/// <summary>ガイドボタンEnabledプロパティ</summary>
		internal bool GuideButtonEnabled
		{
			get
			{
				return this.uButton_Guide.Enabled;
			}
		}

		/// <summary>入荷履歴ボタンEnabledプロパティ</summary>
		internal bool ArrivalReferenceButtonEnabled
		{
			get
			{
				return this.uButton_ArrivalReference.Enabled;
			}
		}

		/// <summary>仕入履歴ボタンEnabledプロパティ</summary>
		internal bool StockReferenceButtonEnabled
		{
			get
			{
				return this.uButton_StockReference.Enabled;
			}
		}
		
		/// <summary>発注ボタンEnabledプロパティ</summary>
		internal bool OrderReferenceButtonEnabled
		{
			get
			{
				return this.uButton_OrderReference.Enabled;
			}
		}

        /// <summary>操作権限の制御オブジェクト</summary>
        internal IOperationAuthority MyOpeCtrl
        {
            get
            {
                return _operationAuthority;
            }
        }

		# endregion

		// ===================================================================================== //
		// プライベート・インターナルメソッド
		// ===================================================================================== //
		# region Private Methods and Internal Methods

        private void DeserializeThread()
        {
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UB", "DeserializeThread", "ST");
            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatusExp> colDisplayStatusList = ColDisplayStatusList.Deserialize(ct_FILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._stockDetailDataTable);

            this._stockInputConstructionAcs.GetColDisplayInfoInitList += new StockSlipInputConstructionAcs.GetColDisplayInfoEventHandler(this._colDisplayStatusList.GetColDisplayInfoInitList);
            this._stockInputConstructionAcs.GetColDisplayInfoList += new StockSlipInputConstructionAcs.GetColDisplayInfoEventHandler(this._colDisplayStatusList.GetColDisplayInfoList);
            this._stockInputConstructionAcs.SetColDisplayInfoList += new StockSlipInputConstructionAcs.SetColDisplayInfoEventHandler(this.RestoreColDisplayList);
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UB", "DeserializeThread", "ED");

        }

		/// <summary>
		/// 共通設定情報によるセルの設定
		/// </summary>
		internal void SettingColDisplayStatusByCommonSetting()
		{
			StockTtlSt stockTtlSt = this._stockSlipInputInitDataAcs.GetStockTtlSt();

			ColDisplayStatusExp colDisplayStatusExp_StockDtiSlipNote1 = this._colDisplayStatusList.GetColDisplayStatus(this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName);

			if (stockTtlSt.DtlNoteDispDiv == 1)
			{
				colDisplayStatusExp_StockDtiSlipNote1.ReadOnly = true;
				colDisplayStatusExp_StockDtiSlipNote1.Visible = false;
				this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName].Hidden = true;
			}
			else
			{
				colDisplayStatusExp_StockDtiSlipNote1.ReadOnly = false;
			}
		}

		/// <summary>
		/// Returnキーダウン処理
		/// </summary>
		/// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <br>Update Note: 2010/12/03 yangmj ユーザー設定画面の明細制御を変更しても効かないの修正</br>
        internal bool ReturnKeyDown()
		{
			if (this.uGrid_Details.ActiveCell == null) return false;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
			int stockRowNo = this._stockDetailDataTable[cell.Row.Index].StockRowNo;
            int rowIndex = cell.Row.Index;

            try
            {
                this.uGrid_Details.SuspendLayout();
                this.uGrid_Details.BeginUpdate();

                bool canMove = true;

                if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
                    ( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
				{
					canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
				}
				else
                {
                    #region ●商品コード
					if (cell.Column.Key == this._stockDetailDataTable.GoodsNoColumn.ColumnName)
					{
                        //----ADD 2010/12/03----->>>>>
                        String beforeGoodsNo = this._stockDetailDataTable[cell.Row.Index].GoodsNo;
                        //----ADD 2010/12/03-----<<<<<
						this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
						this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

						// ActiveCellが変更していない場合はNextCellを実行する
						if (this.uGrid_Details.ActiveCell.Column.Key == this._stockDetailDataTable.GoodsNoColumn.ColumnName)
						{
                            // 仕入先選択エラーフラグがたっている場合はセル移動無し
                            if (this._supplierSelectError)
                            {
                                this._supplierSelectError = false;
                                if (this.SupplierSelect != null)
                                {
                                    this.SupplierSelect(this.uGrid_Details, new EventArgs());
                                }

                            }
                            else if (string.IsNullOrEmpty(this._stockDetailDataTable[cell.Row.Index].GoodsNo))
                            {
                                if (this._cannotGoodsRead)
                                {
                                    // 商品情報の取得に失敗した場合はPerformActionを実行しない
                                    this._cannotGoodsRead = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                            else
                            {
                                canMove = this.MoveReturnCell();
         
                                if (string.IsNullOrEmpty(this._stockDetailDataTable[cell.Row.Index].GoodsName))
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName];
                                    //if (this._colDisplayStatusList.GetColDisplayStatus(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName).Visible)
                                    //{
                                    //    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName];
                                    //}
                                    //else
                                    //{
                                    //    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName];
                                    //}
                                }
                                else
                                {
                                    //----UPD 2010/12/03----->>>>>
                                    if (!beforeGoodsNo.Equals(this._stockDetailDataTable[cell.Row.Index].GoodsNo))
                                    {
                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._stockDetailDataTable.StockCountDisplayColumn.ColumnName];
                                    }
                                    //this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._stockDetailDataTable.StockCountDisplayColumn.ColumnName];
                                    //----UPD 2010/12/03-----<<<<<
                                }
                                canMove = this.MoveReturnCell(true, false);
                            }
						}
                    }
                    #endregion

                    #region ●BLコード、メーカー（コメントアウト中）
#if false
                    else if (( cell.Column.Key == this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName ) ||
                             ( cell.Column.Key == this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName ))
                    {
                        if (cell.IsInEditMode)
                        {
                            string beforeCellKey = cell.Column.Key;

                            // セルを更新する
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            // ActiveCellが変更していない場合はNextCellを取得する
                            if (this.uGrid_Details.ActiveCell.Column.Key == beforeCellKey)
                            {
                                // 仕入先選択エラーフラグがたっている場合はセル移動無し
                                if (this._supplierSelectError)
                                {
                                    this._supplierSelectError = false;
                                    if (this.SupplierSelect != null)
                                    {
                                        this.SupplierSelect(this.uGrid_Details, new EventArgs());
                                    }
                                }
                                // BeforeCellUpdateでキャンセルフラグがたっている場合はセル移動無し
                                else if (this._beforeCellUpdateCancel)
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
                                    if (string.IsNullOrEmpty(this._stockDetailDataTable[cell.Row.Index].GoodsName))
                                    {
                                        if (cell.Column.Key == this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName)
                                        {
                                            //if (( this._colDisplayStatusList.GetColDisplayStatus(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName).Visible ) &&
                                            //    ( this._colDisplayStatusList.GetColDisplayStatus(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName).EnterStop ))
                                            if (this._colDisplayStatusList.GetColDisplayStatus(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName).Visible)
                                            {
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                            }
                                            else
                                            {
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName];
                                            }
                                        }
                                        else
                                        {
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName];
                                        }

                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        //this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName];
                                    }
                                    else
                                    {
                                        canMove = this.MoveReturnCell();
                                    }
                                    
                                }
                            }
                        }
                        else
                        {
                            // 次入力可能セル移動処理
                            canMove = this.MoveReturnCell();
                        }
                    }
#endif
                    #endregion

                    #region ●通常項目
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
                                // 仕入先選択エラーフラグがたっている場合はセル移動無し
                                if (this._supplierSelectError)
                                {
                                    this._supplierSelectError = false;
                                    if (this.SupplierSelect != null)
                                    {
                                        this.SupplierSelect(this.uGrid_Details, new EventArgs());
                                    }
                                }
                                // BeforeCellUpdateでキャンセルフラグがたっている場合はセル移動無し
                                else if (this._beforeCellUpdateCancel)
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
                    #endregion
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
				if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
					( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
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
								//if (afterRowIndex > this.uGrid_Details.Rows.Count - 1) return false;
                                if (afterRowIndex > this.uGrid_Details.Rows.Count - 1) return false;
								break;
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
				//if (( this.uGrid_Details.ActiveCell.Activation == Infragisticzs.Win.UltraWinGrid.Activation.AllowEdit ))
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
            afterColKeyName = string.Empty;

			List<ColDisplayStatusExp> colDisplayStatusList = this._colDisplayStatusList.GetColDisplayStatusList();

			int colIndex = this._colDisplayStatusList.GetColDisplayStatus(key).VisiblePosition;

			// 同一行内の後ろの項目に移動可能セルがあるか検索する
			foreach (ColDisplayStatusExp colDisplayStatusExp in colDisplayStatusList)
			{
				if (( colDisplayStatusExp.ReadOnly == false ) &&
					( colDisplayStatusExp.VisiblePosition > colIndex ) &&
					( colDisplayStatusExp.Visible == true ) &&
					( colDisplayStatusExp.EnterStop == true ))
				{
					afterColKeyName = colDisplayStatusExp.Key;
					return 0;
				}
			}

			// 次の行の最初の移動可能セルを検索する
			foreach (ColDisplayStatusExp colDisplayStatusExp in colDisplayStatusList)
			{
				if (( colDisplayStatusExp.ReadOnly == false ) &&
					( colDisplayStatusExp.Visible == true ) &&
					( colDisplayStatusExp.EnterStop == true ))
				{
					afterColKeyName = colDisplayStatusExp.Key;
					return 1;
				}
			}

			return -1;
		}

#if false
        /// <summary>
        /// 移動位置取得処理(Shift+Tabキー移動時)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="afterColKeyName"></param>
        /// <returns>0:正常取得,1:次の行,-1:例外</returns>
        internal void GetPrevMovePosition()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                try
                {
                    this.uGrid_Details.BeginUpdate();

                    this.MovePrevCell();
                    //List<ColDisplayStatusExp> colDisplayStatusList = this._colDisplayStatusList.GetColDisplayStatusList();

                    //string activeKey = this.uGrid_Details.ActiveCell.Column.Key;
                    //int index = this.uGrid_Details.ActiveCell.Row.Index;

                    //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);

                    //if (this.uGrid_Details.ActiveCell != null)
                    //{
                    //    if (( this.uGrid_Details.ActiveCell.Column.Key == activeKey ) &&
                    //        ( this.uGrid_Details.ActiveCell.Row.Index == index ))
                    //    {
                    //        MessageBox.Show("NG");
                    //    }
                    //    else
                    //    {
                    //        this._colDisplayStatusList.GetColDisplayStatus(key)
                    //    }
                    //}
                }
                finally
                {
                    this.uGrid_Details.EndUpdate();
                }
            }
            //if (this.uGrid_Details.ActiveCell != null) MessageBox.Show(this.uGrid_Details.ActiveCell.Column.Key);
            
            //if (this.uGrid_Details.ActiveCell != null) MessageBox.Show(this.uGrid_Details.ActiveCell.Column.Key);

            //afterColKeyName = string.Empty;


            //int colIndex = this._colDisplayStatusList.GetColDisplayStatus(key).VisiblePosition;
            //int targetIndex = -1;

            //int aa = this.uGrid_Details.DisplayLayout.Bands[0].Columns[key].Index;
            //string bb = ( aa > 0 ) ? this.uGrid_Details.DisplayLayout.Bands[0].Columns[aa - 1].Key : string.Empty;

            //// 同一行内の前の項目に移動可能セルがあるか検索する
            //foreach (ColDisplayStatusExp colDisplayStatusExp in colDisplayStatusList)
            //{
            //    if (( colDisplayStatusExp.ReadOnly == false ) &&
            //        ( colDisplayStatusExp.VisiblePosition < colIndex ) &&
            //        ( colDisplayStatusExp.VisiblePosition > targetIndex ) &&
            //        ( colDisplayStatusExp.Visible == true ) &&
            //        ( colDisplayStatusExp.EnterStop == true ))
            //    {
            //        afterColKeyName = colDisplayStatusExp.Key;
            //    }
            //}

            //if (targetIndex >= 0) return 0;

            //// 次の行の最初の移動可能セルを検索する
            //foreach (ColDisplayStatusExp colDisplayStatusExp in colDisplayStatusList)
            //{
            //    if (( colDisplayStatusExp.ReadOnly == false ) &&
            //        ( colDisplayStatusExp.Visible == true ) &&
            //        ( colDisplayStatusExp.EnterStop == true ))
            //    {
            //        afterColKeyName = colDisplayStatusExp.Key;
            //        return 1;
            //    }
            //}

            //return -1;
        }

        private bool MovePrevCell()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                string activeKey = this.uGrid_Details.ActiveCell.Column.Key;
                int index = this.uGrid_Details.ActiveCell.Row.Index;

                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);

                if (this.uGrid_Details.ActiveCell != null)
                {
                    if (( this.uGrid_Details.ActiveCell.Column.Key == activeKey ) &&
                        ( this.uGrid_Details.ActiveCell.Row.Index == index ))
                    {
                        return false;
                    }
                    else
                    {
                        ColDisplayStatusExp colDisplayStatusExp = this._colDisplayStatusList.GetColDisplayStatus(this.uGrid_Details.ActiveCell.Column.Key);
                        if (( this.uGrid_Details.ActiveCell.Activation != Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) ||
                            ( colDisplayStatusExp.Visible == false ) ||
                            ( colDisplayStatusExp.EnterStop == false ))
                        {
                            return MovePrevCell();
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

#endif

		/// <summary>
		/// 次入力可能セル移動処理
		/// </summary>
		/// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
		/// <returns>true:セル移動完了 false:セル移動失敗</returns>
		private bool MoveNextAllowEditCell(bool activeCellCheck)
		{
			if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
				( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))

			{
				return false;
			}

			//this.uGrid_Details.SuspendLayout();
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
						int editMode = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._stockDetailDataTable.EditStatusColumn.ColumnName].Value;

						if (( editMode == StockSlipInputAcs.ctEDITSTATUS_AllDisable ) || ( editMode == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly ))
						{
							performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

							if (( performActionResult ) && ( this.uGrid_Details.ActiveRow != null ))
							{
								int index = this.uGrid_Details.ActiveRow.Index;

								if (!( this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Hidden ))
								{
									this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName];
								}
								else
								{
									this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName];
								}

								// 再帰処理
								this.MoveNextAllowEditCell(true);

								return true;
							}
						}
					}

					performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
					//performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

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
        /// 列表示情報復元処理
        /// </summary>
        /// <param name="colDisplayInfoList"></param>
		private void RestoreColDisplayList(List<ColDisplayInfo> colDisplayInfoList)
		{
			this._colDisplayStatusList.SetColDisplayStatusListFromColDisplayInfoList(colDisplayInfoList);
			this.SettingGridColSetting();
		}

        /// <summary>
        /// 列表示情報取得処理
        /// </summary>
        /// <returns></returns>
		private List<ColDisplayInfo> GetDisplayInfoInitList()
		{
			return this._colDisplayStatusList.GetColDisplayInfoInitList();
		}

		/// <summary>
		/// 仕入明細データテーブル列表示設定クラスセッティング処理
		/// </summary>
		private void SettingStockDetailRowVisibleControl()
		{
			// デバッグ用
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockCountMaxColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockCountMinColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.OrderRemainCntColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.OrderAdjustCntColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.ListPriceTaxExcColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.ListPriceTaxIncColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockUnitTaxPriceColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockUnitPriceColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.OrderCntColumn.ColumnName, StatusType.Default, 0, false);

			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockUnitTaxPriceColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockUnitPriceColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName, StatusType.Default, 0, false);

			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockPriceColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockUnitPriceColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StckInnerTaxColumn.ColumnName, StatusType.Default, 0, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StckOuterTaxColumn.ColumnName, StatusType.Default, 0, false);

			#region ●StatusType : Default

			// №
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName, StatusType.Default, 0, false);
			// 商品コード
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 0, false);
			// 商品名
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 0, false);

			#endregion

			#region ●StatusType : InputChange

			// BLコード
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// メーカー
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// 定価
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// 数量
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockCountDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockCountDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			//// 単位
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.UnitCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.UnitCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// 仕入率
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockRateColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockRateColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// 単価（表示用）
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// 仕入金額（表示用）
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			//// 課税区分
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.TaxDivColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.TaxDivColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// 仕入伝票明細備考1
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// 倉庫名
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.WarehouseCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.WarehouseCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// 棚番
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.WarehouseShelfNoColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.WarehouseShelfNoColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// 現在庫数
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			//// 特売区分
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.BargainCdColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.BargainCdColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// メモ
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.MemoExistColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.MemoExistColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			//// 売上
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesInfoExistColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			//this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesInfoExistColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);
			// OP
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.OpenPriceColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.OpenPriceColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);

            // 得意先
            this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
            this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);

            // 発注番号
            //this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.OrderNumberColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, false);
            //this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, true);

			//↓↓↓ 同時売上入力用 ↓↓↓
			// 得意先コード
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.CustomerCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, true);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.CustomerCodeColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, false);
			// 得意先名称
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.CustomerNameColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, true);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.CustomerNameColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, false);
			// 定価
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesListPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, true);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesListPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, false);
			// 売価率
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesRateColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, true);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesRateColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, false);
			// 売単価
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesUnitPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, true);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesUnitPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, false);
			// 売上金額
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.Normal, true);
			this._stockDetailRowVisibleControl.Add(this._stockDetailDataTable.SalesPriceDisplayColumn.ColumnName, StatusType.InputChange, (int)DisplayType.SalesInput, false);

			#endregion
		}

		/// <summary>
		/// グリッド列初期設定処理
		/// </summary>
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
				if (col.Key != this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName)
				{
					col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
					col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
				}
			}

            #region ●表示幅設定
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].Width = 44;		// №
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.OrderNumberColumn.ColumnName].Width = 70;				// 発注番号
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Width = 100;			    	// 商品コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Width = 140;				// 商品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName].Width = 70;		    	// メーカーコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName].Width = 90;			// 定価
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountRemainderColumn.ColumnName].Width = 60;	// 残数量
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountDisplayColumn.ColumnName].Width = 60;		// 数量
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRateColumn.ColumnName].Width = 70;				// 仕入率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName].Width = 90;	// 単価（表示用）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName].Width = 130;		// 仕入金額（表示用）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.TaxDivColumn.ColumnName].Width = 25;					// 課税区分
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseCodeColumn.ColumnName].Width = 120;			// 倉庫コード
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseNameColumn.ColumnName].Width = 120;			// 倉庫名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseShelfNoColumn.ColumnName].Width = 55;			// 棚番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName].Width = 55;		// 現在庫数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName].Width = 366;		// 仕入伝票明細備考1
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName].Width = 70;				// BLコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName].Width = 74;			// 得意先

			//↓↓↓ 同時売上入力用 ↓↓↓
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.CustomerCodeColumn.ColumnName].Width = 100;			// 得意先コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.CustomerNameColumn.ColumnName].Width = 150;			// 得意先名称
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesListPriceDisplayColumn.ColumnName].Width = 90;	// 定価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesRateColumn.ColumnName].Width = 70;				// 売価率
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesUnitPriceDisplayColumn.ColumnName].Width = 90;	// 単価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesPriceDisplayColumn.ColumnName].Width = 130;		// 金額

            #endregion

			#region ●固定列設定
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].Header.Fixed = true;	// №
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.OrderNumberColumn.ColumnName].Header.Fixed = true;			// 発注番号
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Header.Fixed = true;			// 商品コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;			// 商品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;			// 商品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			#endregion

			#region ●CellAppearance設定
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// 行番号
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// 倉庫コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// 数量
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountRemainderColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// 仕入単価（表示用）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// 仕入金額（表示用）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// メーカーコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// 定価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;				// 仕入率
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// 現在庫数
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.OrderNumberColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 発注番号
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		// 得意先

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.MemoExistColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.OpenPriceColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesInfoExistColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;

			//↓↓↓ 同時売上入力用 ↓↓↓
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// 得意先コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 得意先名称
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesListPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// 定価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;				// 売価率
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesUnitPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// 単価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// 金額


			#endregion

			#region ●入力許可設定
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;    // No
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;        // 倉庫名称
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountRemainderColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;  // 入荷残数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockUnitPriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // 単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockUnitTaxPriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 単価（税込み）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseShelfNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // 棚番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;  // 現在庫数
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.MemoExistColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;              // メモ
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesInfoExistColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // 売上
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.OpenPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;              // OP
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.OrderNumberColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;            // 発注番号

			//↓↓↓ 同時売上入力用 ↓↓↓
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.CustomerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// 得意先名称
;			// 得意先名称

			#endregion

			#region ●Style設定
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			    		// 商品コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// 商品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;				// 倉庫コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			// 数量
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountRemainderColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;	    // 残数量
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		// 単価（表示用）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;            // 仕入金額（表示用）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.TaxDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;				// 課税・非課税区分
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			// 備考
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;	        		// BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			        // メーカーコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        		// 定価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		        	// 仕入率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseShelfNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		    	// 棚番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		// 現在庫数
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.OrderNumberColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// 発注番号
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			// 得意先
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.MemoExistColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// メモ
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesInfoExistColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;				// 売上
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.OpenPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// OP

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.CustomerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// 得意先コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.CustomerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// 得意先名称
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesListPriceDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		// 定価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// 売価率
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesUnitPriceDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		// 単価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesPriceDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			// 金額
			#endregion

			#region ●CharacterCasing設定
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNoColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ProductNumberColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            #endregion

			#region ●Button用個別設定

			#endregion

			#region ●フォーマット設定
            string countFormat = "#,##0;-#,##0;"; // 2009.04.02
            string moneyFormat = "#,##0;-#,##0;''";
			//string moneyFormat_Zero = "#,##0;-#,##0;'0'";
			string decimalFormat = "#,##0.00;-#,##0.00;''";
			//string decimalFormat_Zero = "#,##0.00;-#,##0.00;'0'";
            string codeFormat = "#0;-#0;''";

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountDisplayColumn.ColumnName].Format = decimalFormat;        // 数量
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountRemainderColumn.ColumnName].Format = decimalFormat_Zero;	// 入荷残数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName].Format = decimalFormat;    // 単価（表示用）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName].Format = moneyFormat;          // 仕入金額（表示用）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName].Format = codeFormat;                 // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName].Format = codeFormat;                // メーカーコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName].Format = moneyFormat;           // 定価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRateColumn.ColumnName].Format = decimalFormat;                // 仕入率
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName].Format = decimalFormat;    // 現在庫数 // 2009.03.25
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName].Format = codeFormat;           // 得意先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName].Format = countFormat;      // 現在庫数 // 2009.04.02

			//↓↓↓ 同時売上入力用 ↓↓↓
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.CustomerCodeColumn.ColumnName].Format = codeFormat;                // 得意先コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesListPriceDisplayColumn.ColumnName].Format = moneyFormat;	    // 定価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesRateColumn.ColumnName].Format = decimalFormat;                // 売価率
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesUnitPriceDisplayColumn.ColumnName].Format = decimalFormat;    // 単価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesPriceDisplayColumn.ColumnName].Format = moneyFormat;          // 金額

            #endregion

			#region ●MaxLength設定

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNoColumn.ColumnName].MaxLength = 40;                  // 商品コード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNameColumn.ColumnName].MaxLength = 100;               // 商品名称
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountDisplayColumn.ColumnName].MaxLength = 11;        // 数量
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockCountRemainderColumn.ColumnName].MaxLength = 10;    // 入荷残数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName].MaxLength = 14;    // 単価（表示用）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockUnitPriceFlColumn.ColumnName].MaxLength = 11;         // 単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockUnitTaxPriceFlColumn.ColumnName].MaxLength = 12;      // 単価（税込み）
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName].MaxLength = 12;      // 仕入金額（表示用）
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName].MaxLength = 12;       // 仕入金額（税込み）
			//this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName].MaxLength = 12;       // 仕入金額（税抜き）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName].MaxLength = 10;        // 仕入金額（表示用）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName].MaxLength = 9;          // 仕入金額（税込み）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName].MaxLength = 9;          // 仕入金額（税抜き）
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName].MaxLength = 8;          // 定価
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockRateColumn.ColumnName].MaxLength = 6;                 // 仕入率
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName].MaxLength = 20;        // 発注番号

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName].MaxLength = 5;               // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName].MaxLength = 9;         // 得意先
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseCodeColumn.ColumnName].MaxLength = 6;             // 倉庫
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName].MaxLength = 6;              // メーカー

			#endregion

			#region ●DropDownList設定
			// DropDownList設定
			Infragistics.Win.ValueList list = new Infragistics.Win.ValueList();
			list.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
			list.DropDownListMinWidth = 0;
			list.MaxDropDownItems     = 10;

			Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
			listItem0.DataValue = 0;
			listItem0.DisplayText = "課税";

			Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
			listItem1.DataValue = 1;
			listItem1.DisplayText = "非課税";

            Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
            listItem2.DataValue = 2;
            listItem2.DisplayText = "課税(内税)";

			list.ValueListItems.Add(listItem0);
			list.ValueListItems.Add(listItem1);
            list.ValueListItems.Add(listItem2);

			this.uGrid_Details.DisplayLayout.ValueLists.Add(list);
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.TaxDivColumn.ColumnName].ValueList = list;

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

			foreach (ColDisplayStatusExp colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (this.uGrid_Details.DisplayLayout.Bands[0].Columns.Exists(colDisplayStatus.Key))
				{
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;

					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;

					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;

                    //this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].TabStop = colDisplayStatus.EnterStop;
					//this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Hidden = !colDisplayStatus.Visible;
				}
			}

			// グリッド列表示非表示設定処理
			this.SettingGridColVisible(StatusType.Default, 0);
			this.SettingGridColVisible(StatusType.InputChange, (int)DisplayType.Normal);
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
		/// <param name="stockInputConstruction">仕入入力用ユーザー設定クラス</param>
		internal void GridSetting(StockSlipInputConstruction stockInputConstruction)
		{
			// フォントサイズ
            this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = stockInputConstruction.FontSizeValue;

            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatusExp> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            bool saveHidden = ( this._displayType == DisplayType.Normal ) ? true : false;
            this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList, saveHidden);

            // 列表示状態クラスリストをXMLにシリアライズする
            ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ct_FILENAME_COLDISPLAYSTATUS);
        }

		/// <summary>
		/// クローズ処理
		/// </summary>
		internal void Closing()
		{
			// 列表示状態クラスリスト構築処理
			List<ColDisplayStatusExp> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
			bool saveHidden = ( this._displayType == DisplayType.Normal ) ? true : false;
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList, saveHidden);
            
            // 列表示状態クラスリストをXMLにシリアライズする
			ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ct_FILENAME_COLDISPLAYSTATUS);
		}

		/// <summary>
		/// グリッド列表示非表示設定処理
		/// </summary>
		/// <param name="statusType">ステータスタイププロパティ</param>
		/// <param name="value">値</param>
		private void SettingGridColVisible(StatusType statusType, int value)
		{
			// すべての列の表示非表示設定
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
			if (editBand == null) return;

			// 指定行の全ての列に対して設定を行う。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				bool hidden;
				if (this._stockDetailRowVisibleControl.GetHidden(col.Key, statusType, value, out hidden) == 0)
				{
					if (!hidden)
					{
						// 画面切り替えの場合は、ユーザー設定に従ってHiddenを設定する
						if (( statusType == StatusType.InputChange ) )
						{
							if (value == (int)DisplayType.Normal)
							{
								if (this._colDisplayStatusList.ContainsKey(col.Key))
								{
									ColDisplayStatusExp colDisplayStatusExp = this._colDisplayStatusList.GetColDisplayStatus(col.Key);
									hidden = !( colDisplayStatusExp.Visible );
								}
							}
						}
					}

					col.Hidden = hidden;

					//if (( statusType == StatusType.InputChange ) && ( value == (int)DisplayType.Normal ))
					//{
					//    if (this._salesInputList.Contains(col.Key))
					//    {
					//        col.Hidden == true;
					//    }
					//    if (this._colDisplayStatusList.ContainsKey(col.Key))
					//    {
					//        ColDisplayStatusExp colDisplayStatusExp = this._colDisplayStatusList.GetColDisplayStatus(col.Key);
					//        hidden = !( colDisplayStatusExp.Visible );
					//    }
					//}
					//else
					//{
					//    col.Hidden = hidden;
					//}
				}
				//if ((col.Key == this._stockDetailDataTable.StockCountColumn.ColumnName)||
				//    (col.Key == this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName))
				//{
				//    col.Hidden = false;
				//}
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
		/// グリッド列表示幅設定処理
		/// </summary>
		private void SettingGridColSetting()
		{
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
			{

				if (this._colDisplayStatusList.ContainsKey(column.Key))
				{
					ColDisplayStatusExp colDisplayStatusExp = this._colDisplayStatusList.GetColDisplayStatus(column.Key);
					column.Header.VisiblePosition = colDisplayStatusExp.VisiblePosition;
                    //column.TabStop = colDisplayStatusExp.EnterStop;

					if (( this._displayType == DisplayType.Normal ) || ( colDisplayStatusExp.HeaderFixed ))
					{
						column.Hidden = !( colDisplayStatusExp.Visible );
					}
					else
					{
						if (this._salesInputList.Contains(column.Key))
						{
							column.Hidden = false;
						}
						else
						{
							column.Hidden = true;
						}
					}

				}
				else
				{
					if (this._displayType == DisplayType.Normal)
					{

						column.Hidden = true;
					}
					else
					{
						if (this._salesInputList.Contains(column.Key))
						{
							column.Hidden = false;
						}
						else
						{
							column.Hidden = true;
						}
					}
				}
			}
		}

		/// <summary>
		/// 引数のモードを元にActiveCellを設定します。
		/// </summary>
		/// <param name="mode">モード</param>
        internal void SettingActiveCell( int mode, int rowNo )
        {
            if (( rowNo >= 0 ) && ( rowNo < this._stockDetailDataTable.Rows.Count ))
            {
                for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
                {
                    StockInputDataSet.StockDetailRow row = (StockInputDataSet.StockDetailRow)this._stockDetailDataTable.Rows[i];

                    if (row.StockRowNo == rowNo)
                    {
                        string columnKey = string.Empty;
                        switch (mode)
                        {
                            case ct_SettingActiveCell_StockCountError:
                                {
                                    columnKey = this._stockDetailDataTable.StockCountDisplayColumn.ColumnName;
                                    break;
                                }
                            case ct_SettingActiveCell_StockUnitPriceError:
                                {
                                    columnKey = this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName;
                                    break;
                                }
                            case ct_SettingActiveCell_StockPriceError:
                                {
                                    columnKey = this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName;
                                    break;
                                }
                            case ct_SettingActiveCell_GoodsNameError:
                                {
                                    columnKey = this._stockDetailDataTable.GoodsNameColumn.ColumnName;
                                    break;
                                }
                        }

                        if (!string.IsNullOrEmpty(columnKey))
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[i].Cells[columnKey];
                            this.CellExitEnterEditEnter();
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
				StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;
				if (stockSlip == null) return;

				if ((stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly) ||
					(stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp))
				{
					//this.tToolbarsManager_Main.Enabled = false;
				}
				else
				{
					//this.tToolbarsManager_Main.Enabled = true;
				}

                // グリッド列表示非表示設定処理
				this.SettingGridColVisible(StatusType.Default, 0);
				this.SettingGridColVisible(StatusType.InputChange, (int)this._displayType);
				//this.SettingGridColVisible(StatusType.StockGoodsCd, stockSlip.StockGoodsCd);
				//this.SettingGridColVisible(StatusType.SupplierFormal, stockSlip.SupplierFormal);
				//this.SettingGridColVisible(StatusType.SupplierSlipCdAndSupplierFormal, stockSlip.SupplierSlipCd * 10 + stockSlip.SupplierFormal);

				// 描画が必要な明細件数を取得する。
				int cnt = this._stockDetailDataTable.Count;

                // 各行ごとの設定
				for (int i = 0; i < cnt; i++)
				{
					this.SettingGridRow(i, stockSlip);
				}

                // 表示用行番号調整処理
				this._stockSlipInputAcs.AdjustRowNo();
            }
			finally
			{
				// 描画を開始
				this.uGrid_Details.EndUpdate();
			}
            this.ActiveCellButtonEnabledControl();
        }

		/// <summary>
		/// 明細グリッド・行単位でのセル設定
		/// </summary>
		/// <param name="rowIndex">対象行インデックス</param>
        /// <param name="stockSlip">仕入データクラスオブジェクト</param>
        /// <remarks>
        /// <br>Update Note : 2012/10/15 田建委</br>
        /// <br>管理番号    : 10801804-00、2012/11/14配信分</br>
        /// <br>              Redmine#32862 価格変更した明細、色を変えるように修正</br>
        /// </remarks>
		private void SettingGridRow( int rowIndex, StockSlip stockSlip )
		{
			if (stockSlip == null) return;

			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
			if (editBand == null) return;
			StockTtlSt stockTtlSt = this._stockSlipInputInitDataAcs.GetStockTtlSt();

			switch (stockSlip.StockGoodsCd)
			{
				#region ●商品
				case 0:		// 商品
					{
						// 行番号を取得
						int stockRowNo = this._stockDetailDataTable[rowIndex].StockRowNo;

						// 仕入明細通番
						long stockSlipDtlNum = this._stockDetailDataTable[rowIndex].StockSlipDtlNum;

						// 商品名称を取得
						string goodsName = this._stockDetailDataTable[rowIndex].GoodsName;

						// 商品コードを取得
						string goodsNo = this._stockDetailDataTable[rowIndex].GoodsNo;

                        // メーカーコード
                        int goodsMakerCd = this._stockDetailDataTable[rowIndex].GoodsMakerCd;

						// 数量を取得
						double stockCount = this._stockDetailDataTable[rowIndex].StockCount;

						// 商品種別を取得
						int goodsKindCode = this._stockDetailDataTable[rowIndex].GoodsKindCode;

						// 変更可能ステータスを取得
						int editStatus = this._stockDetailDataTable[rowIndex].EditStatus;

						// 行ステータスを取得
						int rowStatus = this._stockDetailDataTable[rowIndex].RowStatus;

						// 仕入伝票区分を取得
						int stockSlipCdDtl = this._stockDetailDataTable[rowIndex].StockSlipCdDtl;

						// 指定行の全ての列に対して設定を行う。
						foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
						{
							// セル情報を取得
							Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                            
							if (cell == null) continue;

							cell.Row.Hidden = false;

							// アンダーラインを全てのセルに対して非表示とする
							cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

							// 行番号の色変更
							if (cell.Column.Key == this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName)
							{
								//if (( stockSlipCdDtl == 2 ) && ( !string.IsNullOrEmpty(goodsNo.Trim()) ))
								if (( stockSlipCdDtl == 2 ) && ( stockCount != 0 ))
								{
									cell.Appearance.BackColor = ct_GOODSDISCOUNT_CELL_COLOR;
									//cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
									cell.Appearance.BackColor2 = ct_GOODSDISCOUNT_CELL_COLOR;
									cell.Appearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
									cell.Appearance.ForeColor = ct_DISABLE_FONT_COLOR;
									cell.Appearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;

								}
								else
								{
									cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
									cell.Appearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
									cell.Appearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
									cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
									cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
								}
							}

							#region 入力モード：赤伝
							if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
							{
								cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

							}
							#endregion

							#region 入力モード：読み取り専用or締め済み
                            else if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
                                ( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
                            {
                                if (string.IsNullOrEmpty(goodsName.Trim()))
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                }
                                else
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                }
                            }
                            #endregion

                            else
                            {
                                #region 全項目無効
                                if (editStatus == StockSlipInputAcs.ctEDITSTATUS_AllDisable)
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                }
                                #endregion

                                #region 全て読み取り専用
                                else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly)
                                {
                                    if (col.Key == this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName)
                                    {
                                        //
                                    }
                                    else if (col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
                                    {
                                        cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                }
                                #endregion

                                #region 数量のみ編集可
                                else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_StockCountOnly)
                                {
                                    if (( col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName ) ||
                                        ( col.Key == this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName ))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                }
                                #endregion

                                #region 計上新規
                                else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpNew)
                                {
                                    // 「課税・非課税区分」は課税・非課税区分変更可能フラグを参照
                                    if (col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
                                    {
                                        cell.Activation = GetTaxActivation(rowIndex);
                                    }
                                    // 「単価」、「仕入率」、「仕入金額」は仕入在庫全体設定を参照
                                    else if (( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) || 
                                        ( col.Key == this._stockDetailDataTable.StockRateColumn.ColumnName )||
                                        ( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ))
                                    {
                                        cell.Activation = ( stockTtlSt.UnitPriceInpDiv == 0 ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                    // 「定価」は仕入在庫全体設定を参照
                                    else if (col.Key == this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName)
                                    {
                                        cell.Activation = ( stockTtlSt.ListPriceInpDiv == 0 ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                    // 数量、備考、得意先は入力可
                                    else if (( col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName ) ||
                                             ( col.Key == this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName ) ||
                                             ( col.Key == this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName ))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }

                                    // セキュリティ権限の「単価変更」に従って、「単価」、「仕入率」の入力可否を再セット
                                    if (( stockSlipCdDtl != 2 ) &&
                                        ( ( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) || ( col.Key == this._stockDetailDataTable.StockRateColumn.ColumnName ) ))
                                    {
                                        if (( MyOpeCtrl.Disabled((int)OperationCode.UnitPriceChange) ) &&
                                            ( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }

                                    // セキュリティ権限の「金額変更」に従って、「仕入金額」の入力可否を再セット
                                    if (( stockSlipCdDtl != 2 ) && ( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ))
                                    {
                                        if (( MyOpeCtrl.Disabled((int)OperationCode.PriceChange) ) &&
                                            ( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }
                                }
                                #endregion

                                #region 計上編集
                                else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpEdit)
                                {
                                    // 「単価」、「仕入率」、「仕入金額」は仕入在庫全体設定を参照
                                    if (( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) || 
                                        ( col.Key == this._stockDetailDataTable.StockRateColumn.ColumnName )||
                                        ( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ))
                                    {
                                        cell.Activation = ( stockTtlSt.UnitPriceInpDiv == 0 ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                    //// 「定価」は仕入在庫全体設定を参照
                                    //else if (col.Key == this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName)
                                    //{
                                    //    cell.Activation = ( stockTtlSt.ListPriceInpDiv == 0 ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    //}
                                    // 数量、備考は入力可
                                    else if (( col.Key == this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName ) ||
                                             ( col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName ))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }

                                    // セキュリティ権限の「単価変更」に従って、「単価」、「仕入率」の入力可否を再セット
                                    if (( stockSlipCdDtl != 2 ) &&
                                        ( ( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) || ( col.Key == this._stockDetailDataTable.StockRateColumn.ColumnName ) ))
                                    {
                                        if (( MyOpeCtrl.Disabled((int)OperationCode.UnitPriceChange) ) &&
                                            ( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }

                                    // セキュリティ権限の「金額変更」に従って、「仕入金額」の入力可否を再セット
                                    if (( stockSlipCdDtl != 2 ) && ( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ))
                                    {
                                        if (( MyOpeCtrl.Disabled((int)OperationCode.PriceChange) ) &&
                                            ( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }
                                }
                                #endregion

                                #region 行値引き
                                else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_RowDiscount)
                                {
                                    // 仕入金額、商品名は入力可
                                    if (( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ) ||
                                            ( col.Key == this._stockDetailDataTable.GoodsNameColumn.ColumnName ))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    // 課税・非課税区分、単価、数量は入力不可
                                    else if (( col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName ) ||
                                             ( col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName ) ||
                                             ( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ))
                                    {
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                    else if (( col.Key == this._stockDetailDataTable.MemoExistColumn.ColumnName ) ||
                                             ( col.Key == this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName ))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                }
                                #endregion

                                #region 修正明細
                                else if (stockSlipDtlNum != 0)
                                {
                                    // 数量、備考は入力ＯＫ
                                    if (( col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName ) ||
                                        ( col.Key == this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName ))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    // 「単価」、「仕入率」、「仕入金額」は仕入在庫全体設定を参照
                                    else if (( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) ||
                                             ( col.Key == this._stockDetailDataTable.StockRateColumn.ColumnName ) ||
                                             ( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ))
                                    {
                                        cell.Activation = ( stockTtlSt.UnitPriceInpDiv == 0 ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                    // 上記以外は入力不可
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }

                                    // セキュリティ権限の「単価変更」に従って、「単価」、「仕入率」の入力可否を再セット
                                    if (( stockSlipCdDtl != 2 ) &&
                                        ( ( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) || ( col.Key == this._stockDetailDataTable.StockRateColumn.ColumnName ) ))
                                    {
                                        if (( MyOpeCtrl.Disabled((int)OperationCode.UnitPriceChange) ) &&
                                            ( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }

                                    // セキュリティ権限の「金額変更」に従って、「仕入金額」の入力可否を再セット
                                    if (( stockSlipCdDtl != 2 ) && ( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ))
                                    {
                                        if (( MyOpeCtrl.Disabled((int)OperationCode.PriceChange) ) &&
                                            ( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }
                                    // ------ ADD 2010/05/18 -------------------->>>>>
                                    #region 商品値引行
                                    if (editStatus == StockSlipInputAcs.ctEDITSTATUS_GoodsDiscount)
                                    {
                                        // セキュリティ権限の「金額変更」に従って、「仕入金額」の入力可否を再セット
                                        if ((stockSlipCdDtl == 2) && (col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName))
                                        {
                                            if ((MyOpeCtrl.Disabled((int)OperationCode.PriceChange)) &&
                                                (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                        }
                                    }
                                    #endregion
                                    // ------ ADD 2010/05/18 --------------------<<<<<
                                }
                                #endregion

                                #region 通常入力

                                else
                                {
                                    if (( col.Key == this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName ) ||
                                        ( col.Key == this._stockDetailDataTable.GoodsNoColumn.ColumnName ))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    else if (( col.Key == this._stockDetailDataTable.GoodsNameColumn.ColumnName ) &&
                                        ( this._stockSlipInputInitDataAcs.InputMode != StockSlipInputInitDataAcs.ctINPUTMODE_GoodsNoNecessary ))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    else
                                    {
                                        // 品名が入力されていない場合は「品番」以外を無効にする
                                        if (( ( this._stockSlipInputInitDataAcs.InputMode == StockSlipInputInitDataAcs.ctINPUTMODE_GoodsNoNecessary ) && ( string.IsNullOrEmpty(goodsNo.Trim()) ) ) || ( ( this._stockSlipInputInitDataAcs.InputMode != StockSlipInputInitDataAcs.ctINPUTMODE_GoodsNoNecessary ) && ( ( string.IsNullOrEmpty(goodsName.Trim()) ) && ( string.IsNullOrEmpty(goodsNo.Trim()) ) ) ))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                        else
                                        {
                                            // 「課税・非課税区分」は課税・非課税区分変更可能フラグを参照
                                            if (col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
                                            {
                                                cell.Activation = GetTaxActivation(rowIndex);
                                            }
                                            // 「定価」は仕入在庫全体設定を参照
                                            else if (col.Key == this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName)
                                            {
                                                cell.Activation = ( stockTtlSt.ListPriceInpDiv == 0 ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                            // 「単価」、「仕入率」、「仕入金額」は仕入在庫全体設定を参照
                                            else if (( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) ||
                                                ( col.Key == this._stockDetailDataTable.StockRateColumn.ColumnName ) ||
                                                ( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ))
                                            {
                                                cell.Activation = ( stockTtlSt.UnitPriceInpDiv == 0 ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                            // 倉庫は、品番、メーカーが入力済みの場合のみ入力可
                                            else if (col.Key == this._stockDetailDataTable.WarehouseCodeColumn.ColumnName)
                                            {
                                                if (( cell.Appearance.FontData.Underline == Infragistics.Win.DefaultableBoolean.True ) ||
                                                    ( string.IsNullOrEmpty(goodsNo) ) ||
                                                    ( goodsMakerCd == 0 ))
                                                {
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                }
                                                else
                                                {
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                }
                                            }
                                            // 同時売上入力の項目
                                            else if (( col.Key == this._stockDetailDataTable.CustomerCodeColumn.ColumnName ) ||
                                                ( col.Key == this._stockDetailDataTable.CustomerNameColumn.ColumnName ) ||
                                                ( col.Key == this._stockDetailDataTable.SalesListPriceDisplayColumn.ColumnName ) ||
                                                ( col.Key == this._stockDetailDataTable.SalesRateColumn.ColumnName ) ||
                                                ( col.Key == this._stockDetailDataTable.SalesUnitPriceDisplayColumn.ColumnName ) ||
                                                ( col.Key == this._stockDetailDataTable.SalesPriceDisplayColumn.ColumnName ))
                                            {
                                                // 新規で入力する場合のみ入力可
                                                if (stockSlipDtlNum == 0)
                                                {
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                }
                                                else
                                                {
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                }
                                            }
                                            else
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                            }

                                            // セキュリティ権限の「単価変更」に従って、「単価」、「仕入率」の入力可否を再セット
                                            if (( stockSlipCdDtl != 2 ) &&
                                                ( ( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) || ( col.Key == this._stockDetailDataTable.StockRateColumn.ColumnName ) ))
                                            {
                                                if (( MyOpeCtrl.Disabled((int)OperationCode.UnitPriceChange) ) &&
                                                    ( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                                {
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                }
                                            }

                                            // セキュリティ権限の「金額変更」に従って、「仕入金額」の入力可否を再セット
                                            if (( stockSlipCdDtl != 2 ) && ( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ))
                                            {
                                                if (( MyOpeCtrl.Disabled((int)OperationCode.PriceChange) ) &&
                                                    ( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                                                {
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                }
                                            }
                                            // ------ ADD 2010/05/18 -------------------->>>>>
                                            #region 商品値引行
                                            if (editStatus == StockSlipInputAcs.ctEDITSTATUS_GoodsDiscount)
                                            {
                                                // セキュリティ権限の「金額変更」に従って、「仕入金額」の入力可否を再セット
                                                if ((stockSlipCdDtl == 2) && (col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName))
                                                {
                                                    if ((MyOpeCtrl.Disabled((int)OperationCode.PriceChange)) &&
                                                        (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                }
                                            }
                                            #endregion
                                            // ------ ADD 2010/05/18 --------------------<<<<<
                                        }
                                    }
                                }
                                #endregion
                            }

							#region ●無効要素のテキストカラー設定

							// 行値引き
							if (editStatus != StockSlipInputAcs.ctEDITSTATUS_RowDiscount)
							{
								if (( col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName ) ||
                                    (col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName) ||
                                    (col.Key == this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName) || // 2009.03.25
                                    (col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName))
								{
									if (string.IsNullOrEmpty(goodsName))
									{
										cell.Appearance.ForeColorDisabled = Color.Transparent;
									}
									else
									{
										cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
									}
								}
                            }
							if (( cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled ) &&
								( cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled ))
							{
								if (rowStatus == StockSlipInputAcs.ctROWSTATUS_COPY)
								{
									cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
									cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
								}
								else if (rowStatus == StockSlipInputAcs.ctROWSTATUS_CUT)
								{
									cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
									cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
								}
								else
								{
									cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
									if (( goodsKindCode == 38 ) || ( goodsKindCode == 39 ))
									{
										cell.Appearance.ForeColor = ct_REDUCTION_FONT_COLOR;
									}
									else
									{
										cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
									}

                                    // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                    // 現在庫数
                                    if (col.Key == this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName)
                                    {
                                        if (string.IsNullOrEmpty(this._stockDetailDataTable[rowIndex].WarehouseCode.Trim()))
                                        {
                                            cell.Appearance.ForeColor = Color.Transparent;
                                        }
                                        else
                                        {
                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                        }
                                    }
                                    // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

									if (( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ) ||
										( cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ))
									{
										cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
									}
									else
									{
										cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.BackColor;
									}
								}
							}

							if ((col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)||
                                ( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ))
							{
                                if ( stockSlip.SupplierSlipCd == 20 )
                                {
                                    cell.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
                                }
							}

							#endregion

                            //if (col.Key == this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName)
                            //{
                            //    if (!string.IsNullOrEmpty(this._stockDetailDataTable[rowIndex].WarehouseCode.Trim()))
                            //    {
                            //        cell.Column.Format = "#,##0.00;-#,##0.00;'0.00'";
                            //    }
                            //    else
                            //    {
                            //        col.Format = "#,##0.00;-#,##0.00;''";
                            //    }
                            //}

							// メモ存在アイコン
							if (col.Key == this._stockDetailDataTable.MemoExistColumn.ColumnName)
							{
								this.DisplayMemo(rowIndex);
							}
							// 売上存在アイコン
							if (col.Key == this._stockDetailDataTable.SalesInfoExistColumn.ColumnName)
							{
								this.DisplaySalesInfo(rowIndex);
							}
							// オープン価格区分
							if (col.Key == this._stockDetailDataTable.OpenPriceColumn.ColumnName)
							{
								this.DisplayOpenPrice(rowIndex);
							}
						}

                        // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------>>>>>
                        #region 原単価、定価のバックカラー設定
                        this.DetailGridSalesUnitPriceColorSetting(rowIndex, stockRowNo);
                        this.DetailGridListPriceColorSetting(rowIndex, stockRowNo);
                        #endregion
                        // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------<<<<<

						break;
					}
				#endregion

				#region ●商品外
				case 1:			// 商品外
					{
#if false
						// 商品名称を取得
						string goodsName = this._stockDetailDataTable[rowIndex].GoodsName;

						// 商品コードを取得
						string goodsNo = this._stockDetailDataTable[rowIndex].GoodsNo;

						// 商品種別を取得
						int goodsKindCode = this._stockDetailDataTable[rowIndex].GoodsKindCode;

						// 変更可能ステータスを取得
						int editStatus = this._stockDetailDataTable[rowIndex].EditStatus;

						// 行ステータスを取得
						int rowStatus = this._stockDetailDataTable[rowIndex].RowStatus;

						// 仕入伝票区分を取得
						int stockSlipCdDtl = this._stockDetailDataTable[rowIndex].StockSlipCdDtl;

						// 指定行の全ての列に対して設定を行う。
						foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
						{
							// セル情報を取得
							Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
							if (cell == null) continue;

							// 行№
							if (col.Key == this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName)
							{
								cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
							}
							else
							{
								if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
								{
									cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
								}
								else if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
									( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
								{
									if (goodsName.Trim() == string.Empty)
									{
										cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
									}
									else
									{
										cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
									}
								}
								else
								{

									if (editStatus == StockSlipInputAcs.ctEDITSTATUS_AllDisable)
									{
										cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
									}
									else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly)
									{
										cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
									}
									else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_StockCountOnly)
									{
										if (( col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName ) ||
											( col.Key == this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName ))
										{
											cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
										}
										else if (col.Key == this._stockDetailDataTable.GoodsGuideButtonColumn.ColumnName)
										{
											cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
										}
										else
										{
											cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
										}
									}
									else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpNew)
									{
										if (col.Key == this._stockDetailDataTable.GoodsNameColumn.ColumnName)
										{
											cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
										}
										// 「課税・非課税区分」
										else if (col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
										{
											cell.Activation = GetTaxActivation(rowIndex);
										}
										else
										{
											cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
										}
									}
									else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpEdit)
									{
										if (col.Key == this._stockDetailDataTable.GoodsNameColumn.ColumnName)
										{
											cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
										}
										// 「課税・非課税区分」
										else if (col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
										{
											cell.Activation = GetTaxActivation(rowIndex);
										}
										// 「仕入数量」は編集不可
										else if (col.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
										{
											cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
										}
										else
										{
											cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
										}
									}
									else
									{
										if (( col.Key == this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName ) ||
											( col.Key == this._stockDetailDataTable.GoodsNoColumn.ColumnName ) ||
											( col.Key == this._stockDetailDataTable.GoodsNameColumn.ColumnName ) ||
											( col.Key == this._stockDetailDataTable.GoodsGuideButtonColumn.ColumnName ))
										{
											cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
										}
										else
										{
											// 商品名称が入力されていない場合は「商品名称」
											if (( goodsName.Trim() == string.Empty ) && ( goodsNo.Trim() == string.Empty ))
											{
												cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
											}
											else
											{
												// 「課税・非課税区分」
												if (col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
												{
													cell.Activation = GetTaxActivation(rowIndex);
												}
												// 「定価」は仕入在庫全体設定を参照
												else if (col.Key == this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName)
												{
													cell.Activation = ( stockTtlSt.ListPriceInpDiv == 0 ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
												}
												// 「単価」は仕入在庫全体設定を参照
												else if (col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName)
												{
													cell.Activation = ( stockTtlSt.UnitPriceInpDiv == 0 ) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.NoEdit;
												}
												// 「倉庫」は在庫管理有無に従う
												else if (col.Key == this._stockDetailDataTable.WarehouseCodeColumn.ColumnName)
												{
													//if (stockMngExistCd == 0)
													//{
													//    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
													//}
													//else
													//{
													//    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
													//}
													cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
												}
												else
												{
													cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
												}
											}
										}
									}
								}
							}

							// 課税区分
							if (col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
							{
								if (goodsName == string.Empty)
								{
									cell.Appearance.ForeColorDisabled = Color.Transparent;
								}
								else
								{
									cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
								}
							}

							// メモ存在アイコン
							if (col.Key == this._stockDetailDataTable.MemoExistColumn.ColumnName)
							{
								this.DisplayMemo(rowIndex);
							}

							// 売上存在アイコン
							if (col.Key == this._stockDetailDataTable.SalesInfoExistColumn.ColumnName)
							{
								this.DisplaySalesInfo(rowIndex);
							}

							// オープン価格区分
							if (col.Key == this._stockDetailDataTable.OpenPriceColumn.ColumnName)
							{
								this.DisplayOpenPrice(rowIndex);
							}

							if (( cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled ) &&
								( cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled ))
							{
								if (rowStatus == StockSlipInputAcs.ctROWSTATUS_COPY)
								{
									cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
									cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
								}
								else if (rowStatus == StockSlipInputAcs.ctROWSTATUS_CUT)
								{
									cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
									cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
								}
								else
								{
									cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
									if (( goodsKindCode == 38 ) || ( goodsKindCode == 39 ))
									{
										cell.Appearance.ForeColor = ct_REDUCTION_FONT_COLOR;
									}
									else
									{
										cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
									}

									if (( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ) ||
										( cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ))
									{
										cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
									}
									else
									{
										cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.BackColor;
									}
								}
							}
						}
#endif
                        break;
					}
				#endregion

				#region ●消費税調整、残高調整
				case 2:						// 消費税調整
				case 3:						// 残高調整
				case 4:						// 消費税調整（買掛用）
				case 5:						// 残高調整（買掛用）
					{
						// 商品名称を取得
						string goodsName = this._stockDetailDataTable[rowIndex].GoodsName;

						// 商品種別を取得
						int goodsKindCode = this._stockDetailDataTable[rowIndex].GoodsKindCode;

						// 商品種別を取得
						double stockPriceDisplay = this._stockDetailDataTable[rowIndex].StockPriceDisplay;

						// 変更可能ステータスを取得
						int editStatus = this._stockDetailDataTable[rowIndex].EditStatus;

						// 行ステータスを取得
						int rowStatus = this._stockDetailDataTable[rowIndex].RowStatus;

						// 指定行の全ての列に対して設定を行う。
						foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
						{
							// セル情報を取得
							Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
							if (cell == null) continue;

							if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
							{
								cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
							}
							else if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
								( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
							{
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

								if (col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
								{
									if (string.IsNullOrEmpty(goodsName))
									{
										cell.Appearance.ForeColorDisabled = Color.Transparent;
									}
									else
									{
										cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
									}
								}
							}
							else
							{
								if (editStatus == StockSlipInputAcs.ctEDITSTATUS_AllDisable)
								{
									cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
								}
								else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly)
								{
									if (col.Key != this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName)
									{
										cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
									}
								}
								else
								{
									if (( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ) ||
										( col.Key == this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName ))
									{
										// 「仕入金額」「備考」のみを有効にする
										cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
									}
									else
									{
										cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
										cell.Appearance.ForeColorDisabled = Color.Transparent;
									}

									if (rowStatus == StockSlipInputAcs.ctROWSTATUS_COPY)
									{
										cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
										cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
									}
									else if (rowStatus == StockSlipInputAcs.ctROWSTATUS_CUT)
									{
										cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
										cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
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
									}
								}
							}


							if (( col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName ))
							{
								cell.Appearance.ForeColorDisabled = Color.Transparent;
                                //if (goodsName == string.Empty)
								//{
								//    cell.Appearance.ForeColorDisabled = Color.Transparent;
								//}
								//else
								//{
								//    cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
								//}
							}
							// メモ存在アイコン
							if (col.Key == this._stockDetailDataTable.MemoExistColumn.ColumnName)
							{
								this.DisplayMemo(rowIndex);
							}
							// 売上存在アイコン
							if (col.Key == this._stockDetailDataTable.SalesInfoExistColumn.ColumnName)
							{
								this.DisplaySalesInfo(rowIndex);
							}

							// オープン価格区分
							if (col.Key == this._stockDetailDataTable.OpenPriceColumn.ColumnName)
							{
								this.DisplayOpenPrice(rowIndex);
							}
						}

						break;
					}
				#endregion

				#region ●合計入力
				case 6:                     // 合計入力
					{
						//// 商品名称を取得
						//string goodsName = this._stockDetailDataTable[rowIndex].GoodsName;

						//// 変更可能ステータスを取得
						//int editStatus = this._stockDetailDataTable[rowIndex].EditStatus;

						//// 行ステータスを取得
						//int rowStatus = this._stockDetailDataTable[rowIndex].RowStatus;

						// 指定行の全ての列に対して設定を行う。
						foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
						{
							// セル情報を取得
							Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
							if (cell == null) continue; ;

							cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

							if (col.Key == this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName)
							{

							}
							else
							{
								cell.Appearance.ForeColorDisabled = Color.Transparent;
							}
							//cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;

							//if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
							//{
							//    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
							//}
							//else if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
							//    ( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
							//{
							//    if (col.Key == this._stockDetailDataTable.GoodsGuideButtonColumn.ColumnName)
							//    {
							//        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
							//    }
							//    else
							//    {
							//        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
							//    }

							//    if (col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
							//    {
                            //        if (goodsName == string.Empty)
							//        {
							//            cell.Appearance.ForeColorDisabled = Color.Transparent;
							//        }
							//        else
							//        {
							//            cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
							//        }
							//    }
							//}
							//else
							//{
							//    if (editStatus == StockSlipInputAcs.ctEDITSTATUS_AllDisable)
							//    {
							//        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
							//    }
							//    else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly)
							//    {
							//        if (col.Key != this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName)
							//        {
							//            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
							//        }
							//    }
							//    else
							//    {
							//        //if (( col.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) ||
							//        //    ( col.Key == this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName ))
							//        if (( col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName ) ||
							//            ( col.Key == this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName ))
							//        {
							//            // 「仕入単価」「備考」のみを有効にする
							//            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
							//        }
							//        else if (col.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName)
							//        {
							//            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
							//        }
							//        else
							//        {
							//            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
							//        }

							//        if (rowStatus == StockSlipInputAcs.ctROWSTATUS_COPY)
							//        {
							//            cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
							//            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
							//        }
							//        else if (rowStatus == StockSlipInputAcs.ctROWSTATUS_CUT)
							//        {
							//            cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
							//            cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
							//        }
							//        else
							//        {
							//            cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
							//            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

							//            if (( cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ) ||
							//                ( cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit ))
							//            {
							//                cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
							//            }
							//            else
							//            {
							//                cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.BackColor;
							//            }
							//        }
							//    }
							//}

							//if (col.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
							//{
							//    cell.Appearance.ForeColorDisabled = Color.Transparent;
							//}

							//// メモ存在アイコン
							//if (col.Key == this._stockDetailDataTable.MemoExistColumn.ColumnName)
							//{
							//    this.DisplayMemo(rowIndex);
							//}
							//// 売上存在アイコン
							//if (col.Key == this._stockDetailDataTable.SalesInfoExistColumn.ColumnName)
							//{
							//    this.DisplaySalesInfo(rowIndex);
							//}

							//// オープン価格区分
							//if (col.Key == this._stockDetailDataTable.OpenPriceColumn.ColumnName)
							//{
							//    this.DisplayOpenPrice(rowIndex);
							//}
						}

						break;
					}
				#endregion
			}
		}


        /// <summary>
        /// 対象行の課税区分のActivationを取得します。（課税・非課税区分変更可能フラグを参照）
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private Infragistics.Win.UltraWinGrid.Activation GetTaxActivation( int rowIndex )
        {
            if (this._stockDetailDataTable[rowIndex].CanTaxDivChange)
            {
                return Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                return Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
        }

		/// <summary>
		/// 仕入金額計算処理
		/// </summary>
		internal void CalculationStockPrice()
		{
			try
			{
				// 描画を一時停止
				this.uGrid_Details.BeginUpdate();

				// 描画が必要な明細件数を取得する。
				int cnt = this._stockDetailDataTable.Count;

				for (int i = 0; i < cnt; i++)
				{
					this._stockSlipInputAcs.CalculateStockPriceBasedOnRowIndex(i);
				}
			}
			finally
			{
				// 描画を開始
				this.uGrid_Details.EndUpdate();
			}

			// 仕入金額変更後発生イベントコール処理
			this.StockPriceChangedEventCall();
		}

		/// <summary>
		/// 仕入金額計算処理(行指定)
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		internal void CalculationStockPrice(int stockRowNo)
		{
			try
			{
				// 描画を一時停止
				this.uGrid_Details.BeginUpdate();

				this._stockSlipInputAcs.CalculateStockPriceBasedOnStockRowNo(stockRowNo);
			}
			finally
			{
				// 描画を開始
				this.uGrid_Details.EndUpdate();
			}

			// 仕入金額変更後発生イベントコール処理
			this.StockPriceChangedEventCall();
		}

		/// <summary>
		/// 仕入金額計算処理（行番号リスト指定
		/// </summary>
		/// <param name="stockRowNoList">行番号リスト</param>
		internal void CalculationStockPrice( List<int> stockRowNoList )
		{
			try
			{
				// 描画を一時停止
				this.uGrid_Details.BeginUpdate();

				foreach (int stockRowNo in stockRowNoList)
				{
					this._stockSlipInputAcs.CalculateStockPriceBasedOnStockRowNo(stockRowNo);
				}
			}
			finally
			{
				// 描画を開始
				this.uGrid_Details.EndUpdate();
			}

			// 仕入金額変更後発生イベントコール処理
			this.StockPriceChangedEventCall();
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
			this.uButton_StockSearch.Enabled = false;
			this.uButton_Guide.Enabled = false;
            this.uButton_ArrivalReference.Enabled = false;
            this.uButton_OrderReference.Enabled = false;
            this.uButton_StockReference.Enabled = false;
            this.uButton_RowDiscount.Enabled = false;
            this.uButton_GoodsDiscount.Enabled = false;

			this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
			this._rowInsertButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWINSERT;
			this._rowDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
			this._rowCutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCUT;
			this._rowCopyButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCOPY;
			this._rowPasteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWPASTE;
			this._rowDiscountButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DISCOUNT;
			//this._goodsDiscountButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DISCOUNT;
		}

		/// <summary>
		/// ツールチップ初期設定処理
		/// </summary>
		private void ToolTipInfoInitialSetting()
		{
			Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo_uGrid_Details = this.uToolTipManager_Information.GetUltraToolTip(this.uGrid_Details);
			ultraToolTipInfo_uGrid_Details.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
            ultraToolTipInfo_uGrid_Details.ToolTipTitle = string.Empty;
            ultraToolTipInfo_uGrid_Details.ToolTipText = string.Empty;
			ultraToolTipInfo_uGrid_Details.Appearance.FontData.Name = "ＭＳ ゴシック";
			this.uToolTipManager_Information.SetUltraToolTip(this.uGrid_Details, ultraToolTipInfo_uGrid_Details);

			Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo_uGrid_Details2 = this.uToolTipManager_Hint.GetUltraToolTip(this.uGrid_Details);
			ultraToolTipInfo_uGrid_Details2.ToolTipImage = Infragistics.Win.ToolTipImage.None;
            ultraToolTipInfo_uGrid_Details2.ToolTipTitle = string.Empty;
            ultraToolTipInfo_uGrid_Details2.ToolTipText = string.Empty;
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
		/// 選択済み仕入行番号リスト取得処理
		/// </summary>
		/// <returns>選択済み仕入行番号リスト</returns>
		private List<int> GetSelectedStockRowNoList()
		{
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
			Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
			if ((cell == null) && (rows == null)) return null;

			List<int> selectedStockRowNoList = new List<int>();
			List<int> selectedIndexList = new List<int>();
			
			if (cell != null)
			{
				selectedStockRowNoList.Add(this._stockDetailDataTable[cell.Row.Index].StockRowNo);
				selectedIndexList.Add(cell.Row.Index);
			}
			else if (rows != null)
			{
				foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
				{
					selectedStockRowNoList.Add(this._stockDetailDataTable[row.Index].StockRowNo);
					selectedIndexList.Add(row.Index);
				}
			}

			return selectedStockRowNoList;
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
        internal int GetActiveRowStockRowNo()
        {
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex < 0) return -1;

            return this._stockDetailDataTable[rowIndex].StockRowNo;
            //return rowIndex;
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        internal void Clear(bool settingGrid)
        {
            // 仕入明細DataTable行クリア処理
            this._stockDetailDataTable.Rows.Clear();

            // グリッド行初期設定処理
            this._stockSlipInputAcs.StockDetailRowInitialSetting(this._stockInputConstructionAcs.StockInputConstruction.DataInputCountValue);

            if (settingGrid)
            {
                // 明細グリッドセル設定処理
                this.SettingGrid();
            }

            // 仕入金額変更後発生イベントコール処理
            this.StockPriceChangedEventCall();
        }

		/// <summary>
		/// 画面初期化処理
		/// </summary>
        internal void Clear()
        {
            // 仕入明細DataTable行クリア処理
            this._stockDetailDataTable.Rows.Clear();

            // グリッド行初期設定処理
            this._stockSlipInputAcs.StockDetailRowInitialSetting(this._stockInputConstructionAcs.StockInputConstruction.DataInputCountValue);

            // 明細グリッドセル設定処理
            this.SettingGrid();

            // 仕入金額変更後発生イベントコール処理
            this.StockPriceChangedEventCall();
        }

		/// <summary>
		/// 仕入数量０行削除処理
		/// </summary>
		/// <param name="changeRowCount">true:行数を変更する false:行数を変更しない</param>
		/// <returns>true:削除した,false:削除していない</returns>
		internal bool DeleteStockCountZeroRow(bool changeRowCount)
		{
			bool ret = false;
			List<int> deleteStockRowNoList = this._stockSlipInputAcs.GetStockCountZeroStockRowNoList();

			if (deleteStockRowNoList.Count > 0)
			{
				// 仕入明細行削除処理
				this._stockSlipInputAcs.DeleteStockDetailRow(deleteStockRowNoList, changeRowCount);

				ret = true;
			}

			return ret;
		}

		/// <summary>
		/// 発注残数量０行削除処理
		/// </summary>
		/// <param name="changeRowCount">true:行数を変更する false:行数を変更しない</param>
		internal void DeleteOrderRemainCountZeroRow( bool changeRowCount )
		{
			List<int> deleteStockRowNoList = this._stockSlipInputAcs.GetOrderRemainCountZeroStockRowNoList();

			if (deleteStockRowNoList.Count > 0)
			{
				// 仕入明細行削除処理
				this._stockSlipInputAcs.DeleteStockDetailRow(deleteStockRowNoList, changeRowCount);
			}
		}

		/// <summary>
		/// 空白行削除処理
		/// </summary>
		/// <param name="changeRowCount">true:行数を変更する false:行数を変更しない</param>
		internal void DeleteEmptyRow(bool changeRowCount)
		{
			List<int> deleteStockRowNoList = this._stockSlipInputAcs.GetEmptyStockRowNoList();

			if (deleteStockRowNoList.Count > 0)
			{
				// 仕入明細行削除処理
				this._stockSlipInputAcs.DeleteStockDetailRow(deleteStockRowNoList, changeRowCount);
			}
		}

		/// <summary>
		/// ユーザー設定値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockInputConstructionAcs_DataChanged(object sender, EventArgs e)
		{
			// グリッド列設定処理（ユーザー設定より）
			this.GridSetting(this._stockInputConstructionAcs.StockInputConstruction);
		}

		/// <summary>
		/// 仕入金額変更後発生イベントコール処理
		/// </summary>
		private void StockPriceChangedEventCall()
		{
			if (this.StockPriceChanged != null)
			{
				this.StockPriceChanged(this, new EventArgs());
			}
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
		/// <param name="stockRowNo">行番号</param>
		private void SettingFooterEventCall( int stockRowNo )
		{
			if (this.SettingFooter != null)
			{
				this.SettingFooter(stockRowNo);
			}
		}

		/// <summary>
		/// フッター部設定イベントコール処理
		/// </summary>
		internal void SettingFooterEventCall()
		{
			this.SettingFooterEventCall(this.GetActiveRowStockRowNo());
		}

		/// <summary>
		/// 得意先情報変更イベントコール処理
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		/// <param name="customerInfo">得意先情報オブジェクト</param>
		private void StockDetailCustomerChangeCall( int stockRowNo, CustomerInfo customerInfo )
		{
			if (this.StockDetailCustomerChange != null)
			{
                //SalesTemp salesTemp = this._stockSlipInputAcs.GetSelesTemp(stockRowNo);
                //this.StockDetailCustomerChange(stockRowNo, salesTemp, customerInfo);
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
            string _strResult = string.Empty;
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
		/// 仕入先入力チェック処理
		/// </summary>
		/// <returns>true:仕入先入力済み false:仕入先未入力</returns>
		private bool CheckCustomerCodeInput()
		{
			// 仕入先入力チェック
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;
			if (stockSlip == null)
			{
				return false;
			}

			if (stockSlip.SupplierCd == 0)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"仕入先が選択されていません。",
					-1,
					MessageBoxButtons.OK);

				return false;
			}
			else
			{
				return true;
			}
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
        /// アクティブセルのボタン有効無効コントロール処理
        /// </summary>
        internal void ActiveCellButtonEnabledControl()
        {
            int index = 0;
            string colKey = string.Empty;
            if (this.uGrid_Details.ActiveCell != null)
            {
                index = this.uGrid_Details.ActiveCell.Row.Index;
                colKey = this.uGrid_Details.ActiveCell.Column.Key;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                index = this.uGrid_Details.ActiveRow.Index;
            }
            this.ActiveCellButtonEnabledControl(index, colKey);
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

			StockInputDataSet.StockDetailRow row = this._stockSlipInputAcs.StockDetailDataTable[index];

            // 読取専用、赤伝、締済み
			if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
				( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ) ||
				( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
			{
				this.uButton_RowInsert.Enabled = false;
				this.uButton_RowDelete.Enabled = false;
				this.uButton_RowCut.Enabled = false;
				this.uButton_RowCopy.Enabled = false;

				this.uButton_Guide.Enabled = false;
				this.uButton_StockSearch.Enabled = false;

				this.uButton_RowDiscount.Enabled = false;
				this.uButton_GoodsDiscount.Enabled = false;
				this.uButton_StockReference.Enabled = false;
				this.uButton_OrderReference.Enabled = false;
				this.uButton_ArrivalReference.Enabled = false;
			}
            //// 入荷計上
            //else if (this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp)
            //{
            //    this.uButton_RowInsert.Enabled = false;
            //    this.uButton_RowDelete.Enabled = true;
            //    this.uButton_RowCut.Enabled = false;
            //    this.uButton_RowCopy.Enabled = false;

            //    this.uButton_Guide.Enabled = false;
            //    this.uButton_StockSearch.Enabled = false;

            //    this.uButton_RowDiscount.Enabled = false;
            //    this.uButton_GoodsDiscount.Enabled = false;
            //    this.uButton_StockReference.Enabled = false;
            //    this.uButton_OrderReference.Enabled = false;
            //    this.uButton_ArrivalReference.Enabled = false;
            //}
			else
			{
				// 行操作ボタンの有効無効を設定する
				string goodsNo = row.GoodsNo;
				string goodsName = row.GoodsName;
				double stockCount = row.StockCountDisplay;
				int editStatus = row.EditStatus;
				
				// 行操作ボタンの有効無効チェック
				if (( string.IsNullOrEmpty(goodsName) ) && ( string.IsNullOrEmpty(goodsNo) ))
				{
					this.uButton_RowInsert.Enabled = true;
					this.uButton_RowDelete.Enabled = true;
					this.uButton_RowCut.Enabled = false;
					this.uButton_RowCopy.Enabled = false;
					}
				else if (editStatus == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly)
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
				if (( this._stockSlipInputAcs.ExistCopyStockDetailRow() ) && ( editStatus != StockSlipInputAcs.ctEDITSTATUS_AllReadOnly ))
				{
					this.uButton_RowPaste.Enabled = true;
				}
				else
				{
					this.uButton_RowPaste.Enabled = false;
				}

				// 入力補助ボタンの有効無効チェック
				// 仕入商品区分が「2:消費税調整」「3:残高調整」「4:消費税調整（買掛用）」「5:残高調整（買掛用）」の場合
				if (this._stockSlipInputAcs.StockSlip.StockGoodsCd > 1)
				{
					this.uButton_Guide.Enabled = false;
					this.uButton_StockSearch.Enabled = false;

					this.uButton_ArrivalReference.Enabled = false;
					this.uButton_OrderReference.Enabled = false;
					this.uButton_StockReference.Enabled = false;
					this.uButton_GoodsDiscount.Enabled = false;
					this.uButton_RowDiscount.Enabled = false;
				}
				// 仕入商品区分が「0:商品」の場合
				else
				{
                    if (( row.StockSlipDtlNum != 0 ) || ( this._stockSlipInputAcs.StockSlip.SupplierFormal != 0 ))
                    {
                        this.uButton_GoodsDiscount.Enabled = false;
                        this.uButton_RowDiscount.Enabled = false;
                    }
                    else
                    {
                        // ----------- UPD 2010/05/04 ------------------->>>>>
                        //this.uButton_GoodsDiscount.Enabled = true;
                        if (MyOpeCtrl.Enabled((int)StockSlipInputAcs.OperationCode.Discount))
                        {
                            this.uButton_GoodsDiscount.Enabled = true;
                        }
                        // ----------- UPD 2010/05/04 -------------------<<<<<
                        this.uButton_RowDiscount.Enabled = true;
                    }
					this.uButton_StockReference.Enabled = true;

					// 返品以外は基本的に履歴ボタンを有効にする
					if (this._stockSlipInputAcs.StockSlip.SupplierSlipCd != 20)
					{
						this.uButton_OrderReference.Enabled = true;
                        //this.uButton_GoodsDiscount.Enabled = true;
                        //this.uButton_RowDiscount.Enabled = true;

						switch (this._stockSlipInputAcs.StockSlip.SupplierFormal)
						{
							case 0:
								{
									this.uButton_ArrivalReference.Enabled = true;
									//this.uButton_RowDiscount.Enabled = true;
									break;
								}
							default:
								{
									this.uButton_ArrivalReference.Enabled = false;
                                    //this.uButton_RowDiscount.Enabled = false;
                                    //this.uButton_GoodsDiscount.Enabled = false;
									break;
								}
						}
					}
					else
					{
						this.uButton_OrderReference.Enabled = false;
						this.uButton_ArrivalReference.Enabled = false;
                        //this.uButton_RowDiscount.Enabled = false;
                        //this.uButton_GoodsDiscount.Enabled = false;
					}
					// 全て入力不可
					if (row.EditStatus == StockSlipInputAcs.ctEDITSTATUS_AllDisable)
					{
						this.uButton_Guide.Enabled = false;
						this.uButton_StockSearch.Enabled = false;

						this.uButton_ArrivalReference.Enabled = false;
						this.uButton_OrderReference.Enabled = false;
						this.uButton_StockReference.Enabled = false;
						this.uButton_RowDiscount.Enabled = false;
						this.uButton_GoodsDiscount.Enabled = false;
					}
					// 読取専用
					else if (row.EditStatus == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly)
					{
						this.uButton_Guide.Enabled = false;
						this.uButton_StockSearch.Enabled = false;

						this.uButton_ArrivalReference.Enabled = false;
						this.uButton_OrderReference.Enabled = false;
						this.uButton_StockReference.Enabled = false;
						this.uButton_RowDiscount.Enabled = false;
						this.uButton_GoodsDiscount.Enabled = false;
					}
					// 数量のみ入力可
					else if (row.EditStatus == StockSlipInputAcs.ctEDITSTATUS_StockCountOnly)
					{
						this.uButton_Guide.Enabled = false;
						this.uButton_StockSearch.Enabled = false;

						this.uButton_ArrivalReference.Enabled = false;
						this.uButton_OrderReference.Enabled = false;
						this.uButton_StockReference.Enabled = false;
						this.uButton_RowDiscount.Enabled = false;
						this.uButton_GoodsDiscount.Enabled = false;

					}
					// 計上(新規)
					else if (row.EditStatus == StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpNew)
					{
						//this.uButton_Guide.Enabled = false;
						this.uButton_StockSearch.Enabled = false;
						this.uButton_ArrivalReference.Enabled = false;
						this.uButton_OrderReference.Enabled = false;
						this.uButton_StockReference.Enabled = false;
						this.uButton_RowDiscount.Enabled = false;
						this.uButton_GoodsDiscount.Enabled = false;

						// 商品コード、メーカー入力済みは単価ガイド有り
						if (( ( colKey == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) ) &&
							( ( !string.IsNullOrEmpty(row.GoodsNo.Trim()) ) && ( row.GoodsMakerCd != 0 ) ))
						{
							this.uButton_Guide.Enabled = true;
							this.uButton_Guide.Tag = colKey;
						}

					}
					// 計上(修正)
					else if (row.EditStatus == StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpEdit)
					{
						//this.uButton_Guide.Enabled = false;
						this.uButton_StockSearch.Enabled = false;
						this.uButton_ArrivalReference.Enabled = false;
						this.uButton_OrderReference.Enabled = false;
						this.uButton_StockReference.Enabled = false;
						this.uButton_RowDiscount.Enabled = false;
						this.uButton_GoodsDiscount.Enabled = false;

						// 商品コード、メーカー入力済みは単価ガイド有り
						if (( ( colKey == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) ) &&
							( ( !string.IsNullOrEmpty(row.GoodsNo.Trim()) ) && ( row.GoodsMakerCd != 0 ) ))
						{
							this.uButton_Guide.Enabled = true;
							this.uButton_Guide.Tag = colKey;
						}
					}
					else
					{
						// 在庫検索ボタンの有効無効を設定する
						this.uButton_StockSearch.Enabled = true;

						// ガイドボタンの有効無効を設定する
						if (( colKey != null ) &&
							( colKey == this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName ) ||
							( colKey == this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName ) ||
							( colKey == this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName ) ||
							( colKey == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) ||
							( colKey == this._stockDetailDataTable.WarehouseCodeColumn.ColumnName )
						   )
						{
							// 商品コードかメーカーが未入力の場合は単価ガイド無し
							if (( ( colKey == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName ) ) &&
								( ( string.IsNullOrEmpty(row.GoodsNo.Trim()) ) || ( row.GoodsMakerCd == 0 ) ))
							{
								this.uButton_Guide.Enabled = false;
							}
							else
							{
                                if (( ( colKey == this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName ) ||
                                      ( colKey == this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName )||
                                      ( colKey == this._stockDetailDataTable.WarehouseCodeColumn.ColumnName ) ) &&
                                    ( row.StockSlipDtlNum != 0 ))
                                {
                                    this.uButton_Guide.Enabled = false;
                                }
                                else
                                {
                                    this.uButton_Guide.Enabled = true;
                                    this.uButton_Guide.Tag = colKey;
                                }
							}
						}
						else
						{
							this.uButton_Guide.Enabled = false;
						}
					}
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
		}

#if false
		/// <summary>
		/// 商品コードを自動で設定します。（バーコード用）
		/// </summary>
		/// <param name="goodsNo">商品コード</param>
		internal void AutoSettingGoodsCode(string goodsCode)
		{
                bool isGoodsNoColumn = false;
                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.Column.Key == this._stockDetailDataTable.GoodsNoColumn.ColumnName ) && ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) && ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                {
                    isGoodsNoColumn = true;
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                }

                // 仕入商品区分チェック
                if (this._stockSlipInputAcs.StockSlip.StockGoodsCd != 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "仕入商品区分が商品以外の為、商品情報を取得する事ができません。",
                        -1,
                        MessageBoxButtons.OK);

                    return;
                }

                // 仕入先入力チェック処理
                bool customerCodeCheck = this.CheckCustomerCodeInput();

                if (!customerCodeCheck)
                {
                    return;
                }

                StockInputDataSet.StockDetailRow targetRow = null;
                foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
                {
                    if (( string.IsNullOrEmpty(row.GoodsNo) ) && ( string.IsNullOrEmpty(row.GoodsName) ))
                    {
                        targetRow = row;
                        break;
                    }
                }

                if (targetRow != null)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridCell targetCell = null;
                    targetRow.GoodsNo = goodsCode;

                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if ((int)row.Cells[this._stockDetailDataTable.StockRowNoColumn.ColumnName].Value == targetRow.StockRowNo)
                        {
                            targetCell = row.Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName];
                            break;
                        }
                    }

                    if (targetCell != null)
                    {
                        Infragistics.Win.UltraWinGrid.CellEventArgs ea = new Infragistics.Win.UltraWinGrid.CellEventArgs(targetCell);
                        this.uGrid_Details_AfterCellUpdate(this.uGrid_Details, ea);
                    }

                    if (isGoodsNoColumn)
                    {
                        this.ReturnKeyDown();
                    }
                }
		}
#endif

		/// <summary>
		/// セルの編集モードを一度解除し、再度編集モードに設定します。
		/// </summary>
		private void CellExitEnterEditEnter()
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
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		private List<ColDisplayStatusExp> ColDisplayStatusListConstruction( Infragistics.Win.UltraWinGrid.ColumnsCollection columns )
		{
			List<ColDisplayStatusExp> colDisplayStatusList = new List<ColDisplayStatusExp>();

			// グリッドから列表示状態クラスリストを構築
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				ColDisplayStatusExp colDisplayStatus = new ColDisplayStatusExp();

				colDisplayStatus.Key = column.Key;
				colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
				colDisplayStatus.HeaderFixed = column.Header.Fixed;
				colDisplayStatus.Width = column.Width;
				colDisplayStatus.Visible = !(column.Hidden);
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

				if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString()))
				{
					lastInputRowIndex = i;
					break;
				}
			}

			return lastInputRowIndex;
		}

		/// <summary>
		/// 在庫検索処理
		/// </summary>
		internal void StockSearch()
		{
			this.uButton_StockSearch_Click(this.uGrid_Details, new EventArgs());
		}

		/// <summary>
		/// 仕入履歴検索
		/// </summary>
		internal void StockReferenceSearch()
		{
			this.uButton_StockReference_Click(this.uGrid_Details, new EventArgs());
		}

		/// <summary>
		/// 発注履歴検索
		/// </summary>
		internal void OrderReferenceSearch()
		{
			this.uButton_OrderReference_Click(this.uGrid_Details, new EventArgs());
		}

		/// <summary>
		/// 入荷履歴検索
		/// </summary>
		internal void ArrivalReferenceSearch()
		{
			this.uButton_ArrivalReference_Click(this.uGrid_Details, new EventArgs());
		}

		/// <summary>
		/// ガイド起動処理
		/// </summary>
		internal void ExecuteGuide()
		{
			this.uButton_Guide_Click(this.uGrid_Details, new EventArgs());
		}

		/// <summary>
		/// アクティブ行得意先情報設定処理
		/// </summary>
		/// <param name="customerInfo"></param>
		internal void ActiveRowCustomerInfoSetting( CustomerInfo customerInfo )
		{
			int stockRowNo = this.GetActiveRowStockRowNo();
			int rowIndex = this.GetActiveRowIndex();
			Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.uGrid_Details.ActiveCell;
			if (( customerInfo != null ) && ( activeCell != null ))
			{
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                this._stockSlipInputAcs.StockDetailSalesCustomerInfoSetting(stockRowNo, customerInfo);

				if (activeCell.Column.Key == this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName)
				{
					this._stockDetailDataTable[rowIndex].SalesCustomerSnm = customerInfo.CustomerCode.ToString();
				}

				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
			}
			else
			{
                this._stockSlipInputAcs.StockDetailSalesCustomerInfoSetting(stockRowNo, new CustomerInfo());
			}
		}

		#region ●商品検索関係

		/// <summary>
		/// 商品・入荷残・発注残検索と行設定処理
		/// </summary>
		/// <param name="rowIndex">行インデックス</param>
		/// <returns></returns>
		private int SearchGoodsAndRemain_And_RowSetting( int rowIndex )
		{
			int stockRowNo = this._stockDetailDataTable[rowIndex].StockRowNo;
			string goodsName = this._stockDetailDataTable[rowIndex].GoodsName;
			string goodsNo = this._stockDetailDataTable[rowIndex].GoodsNo;
			int makerCode = this._stockDetailDataTable[rowIndex].GoodsMakerCd;
            bool searchRemain = ( this._stockDetailDataTable[rowIndex].StockSlipCdDtl != 2 );

			List<int> settingStockRowNoList = new List<int>();

			object retObj;
            int status = this.SearchGoodsAndRemain(goodsNo, goodsName, makerCode, searchRemain, out retObj);
			switch (status)
			{
				case 0:
					{
						if (retObj != null)
						{
							// 商品検索
							if (retObj is List<GoodsUnitData>)
							{
                                List<GoodsUnitData> goodsUnitDataList = (List<GoodsUnitData>)retObj;

                                this._stockSlipInputAcs.StockDetailRowGoodsSettingBasedOnGoodsUnitData(stockRowNo, goodsUnitDataList, out settingStockRowNoList, true);
							}
							// 発注残検索
							else if (retObj is OrderListResultWork)
							{
								List<OrderListResultWork> addOrderListResultWorkList = new List<OrderListResultWork>();
								addOrderListResultWorkList.Add((OrderListResultWork)retObj);
                                // 2009.04.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                //int readStatus = this._stockSlipInputAcs.StockDetailRowSettingFromOrderListResultWorkList(stockRowNo, addOrderListResultWorkList, StockSlipInputAcs.WayToDetailExpand.AddUp, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                int readStatus = this._stockSlipInputAcs.StockDetailRowSettingFromOrderListResultWorkList(stockRowNo, addOrderListResultWorkList, StockSlipInputAcs.WayToDetailExpand.AddUpRemainder, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                // 2009.04.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                //if (( readStatus == -999 ) && ( wayToDetailExpand == StockSlipInputAcs.WayToDetailExpand.AddUpAndSync ))
                                //{
                                //    TMsgDisp.Show(
                                //        this,
                                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                //        this.Name,
                                //        "発注と同時入力したデータは展開されませんでした。",
                                //        0,
                                //        MessageBoxButtons.OK);
                                //}
							}
							// 入荷残検索
							else if (retObj is StcHisRefDataWork)
							{
								List<StcHisRefDataWork> addStcHisRefDataWorkList = new List<StcHisRefDataWork>();
								addStcHisRefDataWorkList.Add((StcHisRefDataWork)retObj);
                                // 2009.04.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                //this._stockSlipInputAcs.StockDetailRowSettingFromstcHisRefDataWorkList(stockRowNo, addStcHisRefDataWorkList, StockSlipInputAcs.WayToDetailExpand.AddUp, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                this._stockSlipInputAcs.StockDetailRowSettingFromstcHisRefDataWorkList(stockRowNo, addStcHisRefDataWorkList, StockSlipInputAcs.WayToDetailExpand.AddUpRemainder, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                // 2009.04.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            }

							// 明細グリッド設定処理
							this.SettingGrid();

                            // ---UPD 2011/07/18--------------->>>>>
                            // 在庫数量調整
                            //this._stockSlipInputAcs.StockDetailStockInfoAdjust();

                            if (this._stockSlipInputInitDataAcs.GetAllDefSet().DtlCalcStckCntDsp == 0)
                            {
                                // 在庫数量調整
                                this._stockSlipInputAcs.StockDetailStockInfoAdjust();
                            }
                            else
                            {
                                //なし。
                            }
                            // ---UPD 2011/07/18---------------<<<<<

							// 最終行に空行を追加
							this.AddLastEmptyRow();
						}

						break;
					}
				case -1:
					{
						break;
					}
			}
			return status;
		}

		/// <summary>
		/// 商品、入荷・発注残検索処理（オーバーロード）
		/// </summary>
		/// <param name="goodsNo">商品コード</param>
		/// <param name="searchResult">検索結果</param>
        /// <param name="searchRemain">True:残検索する</param>
        /// <returns></returns>
		/// <remarks>
		/// <br>Note       : 商品検索後、残数自動表示区分に従って発注残照会、入荷残照会を起動します。</br>
		/// <br>             検索結果については、ヒットした処理（商品or入荷残or発注残）によってクラスが異なります。</br>
		/// </remarks>
        private int SearchGoodsAndRemain(string goodsNo, bool searchRemain, out object searchResult)
		{
            return this.SearchGoodsAndRemain(goodsNo, string.Empty, 0, searchRemain, out searchResult);
		}

		/// <summary>
		/// 商品、入荷・発注残検索処理（オーバーロード）
		/// </summary>
		/// <param name="goodsNo">商品コード</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="makerCode">メーカーコード</param>
        /// <param name="searchRemain">True:残検索する</param>
		/// <param name="searchResult">検索結果</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 商品検索後、残数自動表示区分に従って発注残照会、入荷残照会を起動します。</br>
		/// <br>             検索結果については、ヒットした処理（商品or入荷残or発注残）によってクラスが異なります。</br>
		/// </remarks>
        // ------ UPD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
        //private int SearchGoodsAndRemain(string goodsNo, string goodsName, int makerCode, bool searchRemain, out object searchResult)
        public int SearchGoodsAndRemain(string goodsNo, string goodsName, int makerCode, bool searchRemain, out object searchResult)
        // ------ UPD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<
		{
			searchResult = null;

			List<GoodsUnitData> goodsUnitDataList;
			int searchStatus;
			int retStasus = -1;

			// 商品検索
			if (makerCode == 0)
			{
                searchStatus = this.SearchGoods(goodsNo, out goodsUnitDataList);
			}
			else
			{
                searchStatus = this.SearchGoods(goodsNo, goodsName, makerCode, out goodsUnitDataList);
			}

			// 商品検索でヒットした場合
            if (( searchStatus == 0 ) && ( goodsUnitDataList.Count > 0 ))
            {
                // 残検索する場合
                if (searchRemain)
                {
                    retStasus = 0;

                    object reamainResult;

                    int reamainSearchStatus = this.SearchRemain(goodsUnitDataList[0], out reamainResult);

                    if (( reamainSearchStatus == 0 ) && ( reamainResult != null ))
                    {
                        searchResult = reamainResult;
                    }
                    else
                    {
                        searchResult = goodsUnitDataList;
                    }
                }
                else
                {
                    retStasus = 0;
                    searchResult = goodsUnitDataList;
                }
            }
            // 商品検索でヒットしなかった場合（空商品を返す）
            else if (( searchStatus == -2 ) && ( goodsUnitDataList.Count > 0 ))
            {
                retStasus = 0;
                searchResult = goodsUnitDataList;
            }

			return retStasus;
		}

		/// <summary>
		/// 残検索
		/// </summary>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		/// <param name="retObj">検索結果</param>
		/// <returns>0:検索OK</returns>
		/// <br>Note       : 残数自動表示区分に従って発注残照会、入荷残照会を起動します。</br>
		/// <br>             検索結果については、ヒットした処理（入荷残or発注残）によってクラスが異なります。</br>
		private int SearchRemain( GoodsUnitData goodsUnitData, out object retObj )
		{
			retObj = null;
			if (this._stockSlipInputAcs.StockSlip.SupplierSlipCd == 20) return -1;

			List<RemainSearchProc> remainSearchProcList = new List<RemainSearchProc>();

			// 残検索メソッドの設定（全体初期値設定マスタの残数自動表示区分によって分岐）
			switch (this._stockSlipInputInitDataAcs.GetAllDefSet().RemCntAutoDspDiv)
			{
				// 出荷残、入荷残のみ
				case 1:
					remainSearchProcList.Add(this.SearchArrivalRemain);
					break;
				// 受発注残のみ
				case 2:
					remainSearchProcList.Add(this.SearchOrderRemain);
					break;
				// 出荷残、入荷残→受発注残
				case 3:
					remainSearchProcList.Add(this.SearchArrivalRemain);
					remainSearchProcList.Add(this.SearchOrderRemain);
					break;
				// 受発注残→出荷残、入荷残
				case 4:
					remainSearchProcList.Add(this.SearchOrderRemain);
					remainSearchProcList.Add(this.SearchArrivalRemain);
					break;
			}

			// 入荷伝票の場合は入荷残を検索しない
			if (this._stockSlipInputAcs.StockSlip.SupplierFormal == 1)
			{
				if (remainSearchProcList.Contains(this.SearchArrivalRemain))
				{
					remainSearchProcList.Remove(this.SearchArrivalRemain);
				}
			}

			foreach (RemainSearchProc remainSearch in remainSearchProcList)
			{
				int st = remainSearch(goodsUnitData, out retObj);
				if (( st == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) && ( retObj != null ))
				{
					return 0;
				}
			}
			return -1;
		}

		/// <summary>
		/// 商品検索処理（オーバーロード）
		/// </summary>
		/// <param name="goodsNo">商品コード</param>
		/// <param name="goodsUnitDataList">商品情報リスト</param>
		/// <param name="stockList">在庫情報リスト</param>
		/// <returns>0:検索OK、-1:キャンセル,-2:検索データ無し</returns>
		private int SearchGoods( string goodsNo, out List<GoodsUnitData> goodsUnitDataList)
		{
            return this.SearchGoods(goodsNo, string.Empty, 0, out goodsUnitDataList);
		}

        /// <summary>
        /// 商品検索処理（商品コード＋メーカー）（オーバーロード）
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsUnitDataList">商品情報リスト</param>
        /// <returns>0:検索OK、-1:キャンセル,-2:検索データ無し</returns>
        /// <remarks>
        /// <br>Update Note: 2021/10/26 譚洪</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応</br> 
        /// <br>Update Note: 2022/01/20 陳艶丹</br>
        /// <br>管理番号   : 11800082-00</br>
        /// <br>           : BLINCIDENT-3254 再度同一品番選択画面が表示される対応</br> 
        /// </remarks>
        private int SearchGoods( string goodsNo, string goodsName, int goodsMakerCd, out List<GoodsUnitData> goodsUnitDataList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			goodsUnitDataList = new List<GoodsUnitData>();

			GoodsUnitData goodsUnitData = new GoodsUnitData();
            string message;

            StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;                   // 企業コード
            goodsCndtn.SectionCode = stockSlip.StockSectionCd;                  // 拠点コード
            goodsCndtn.GoodsNo = goodsNo;                                       // 商品コード
            goodsCndtn.GoodsMakerCd = goodsMakerCd;                             // 商品メーカーコード
            goodsCndtn.PriceApplyDate = ( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;    // 価格適用日
            goodsCndtn.TaxRate = stockSlip.SupplierConsTaxRate;                 // 税率
            goodsCndtn.TotalAmountDispWayCd = stockSlip.SuppTtlAmntDspWayCd;    // 総額表示区分
            goodsCndtn.TtlAmntDspRateDivCd = stockSlip.TtlAmntDispRateApy;      // 総額表示掛率適用区分
            goodsCndtn.ListPriorWarehouse = new List<string>(this._stockSlipInputAcs.GetSearchWarehouseArray());

            status = this._stockSlipInputInitDataAcs.GetGoodsUnitData(goodsCndtn, out goodsUnitData, out message);

            //--- ADD 譚洪 2021/10/26 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 ----->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                try
                {
                    // --- UPD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 ----->>>>>
                    //// 入力品番が大文字 且つ 検索された品番が入力品番と不一致の場合
                    //if (goodsNo.ToUpper().Equals(goodsNo) &&
                    //    !goodsNo.Equals(goodsUnitData.GoodsNo))
                    string chkInputGoodsNo = string.Empty;
                    string chkSearchGoodsNo = string.Empty;
                    // 比較用品番取得
                    GetCompareGoodsNo(goodsNo, goodsUnitData.GoodsNo, out chkInputGoodsNo, out chkSearchGoodsNo);
                    // 入力品番が大文字 且つ 検索された品番が入力品番と不一致の場合
                    if (chkInputGoodsNo.ToUpper().Equals(chkInputGoodsNo) &&
                        !chkInputGoodsNo.Equals(chkSearchGoodsNo))
                    // --- UPD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 -----<<<<<
                    {
                        // ユーザー分品番検索
                        GoodsUnitData goodsUnitDataCk;
                        int ckStatus = this._stockSlipInputInitDataAcs.ReadGoodsUnitData(goodsCndtn, goodsUnitData, out goodsUnitDataCk);

                        // ユーザー分商品登録される場合
                        if (ckStatus == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 小文字品番で再検索
                            goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
                            goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd; // ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応

                            // 商品検索
                            status = this._stockSlipInputInitDataAcs.GetGoodsUnitData(goodsCndtn, out goodsUnitData, out message);
                        }
                    }
                }
                catch
                {
                    // エラーメッセージを表示
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(
                            form,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            StrResearchErrMsg,
                            0,
                            MessageBoxButtons.OK);
                    form.TopMost = false;

                    return -1;
                }
            }
            //--- ADD 譚洪 2021/10/26 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 -----<<<<<

            switch (status )
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        goodsUnitDataList.Add(goodsUnitData);
                        return 0;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                    {
                        return -1;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        goodsUnitDataList.Add(this._stockSlipInputAcs.CreateEmptyGoods(goodsNo, goodsName, goodsMakerCd));
                        return -2;
                    }
            }
			return 0;
		}

        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 ----->>>>>
        /// <summary>
        /// 比較用品番取得(ハイフン「-」と前方一致検索用の「*」を除き)
        /// </summary>
        /// <param name="inputGoodsNo">入力品番</param>
        /// <param name="searchGoodsNo">検索品番</param>
        /// <param name="compareInputGoodsNo">比較用入力品番</param>
        /// <param name="compareSearchGoodsNo">比較用検索品番</param>
        /// <remarks>
        /// <br>Note       : 2022/01/20 陳艶丹</br>
        /// <br>管理番号   : 11800082-00</br>
        /// <br>           : 比較用品番取得</br> 
        /// </remarks>
        private void GetCompareGoodsNo(string inputGoodsNo, string searchGoodsNo, out string compareInputGoodsNo, out string compareSearchGoodsNo)
        {
            compareInputGoodsNo = string.Empty;
            compareSearchGoodsNo = string.Empty;
            try
            {
                // 入力品番
                // ハイフンを除き
                string rstStr = string.Empty;
                rstStr = inputGoodsNo.Replace(CTHYPHEN, string.Empty);
                // 曖昧検索の場合、前方一致検索用"*"を除き
                if (inputGoodsNo.EndsWith(CTASTER)) rstStr = rstStr.Substring(0, rstStr.Length - 1);
                compareInputGoodsNo = rstStr;

                // 検索品番
                // ハイフンを除き
                rstStr = string.Empty;
                rstStr = searchGoodsNo.Replace(CTHYPHEN, string.Empty);
                // 曖昧検索の場合、入力品番より一部品番で比較
                if (inputGoodsNo.EndsWith(CTASTER) && rstStr.Length > compareInputGoodsNo.Length)
                {
                    rstStr = rstStr.Substring(0, compareInputGoodsNo.Length);
                }
                compareSearchGoodsNo = rstStr;
            }
            catch
            {
                // 取得失敗時、既存処理に影響しない為、比較しない
                compareInputGoodsNo = string.Empty;
                compareSearchGoodsNo = string.Empty;
            }
        }
        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 -----<<<<<

		/// <summary>
		/// 発注残検索
		/// </summary>
		/// <param name="goodsNo"></param>
		/// <param name="goodsMakerCode"></param>
		/// <param name="?"></param>
		/// <returns></returns>
        /// <br>UpdateNote : 2014/04/24　鄧潘ハン</br>
        /// <br>管理番号   : 11070071-00 システムテスト障害一覧No.2312の対応</br>
        /// <br>             Redmine#42258　仕入伝票入力で該当データなしになる件の修正</br>
        private int SearchOrderRemain( GoodsUnitData goodsUnitData, out object retObj )
		{
			retObj = null;
			DCHAT04110UA orderHisGuide = new DCHAT04110UA();
			orderHisGuide.SearchConditionDsp = false;

            orderHisGuide.SectionCode = this._stockSlipInputAcs.StockSlip.StockSectionCd;
            orderHisGuide.SectionName = this._stockSlipInputAcs.StockSlip.StockSectionNm;
			orderHisGuide.SupplierCode = this._stockSlipInputAcs.StockSlip.SupplierCd;
			orderHisGuide.SupplierName = this._stockSlipInputAcs.StockSlip.SupplierSnm;
			orderHisGuide.GoodsNo = goodsUnitData.GoodsNo;
			orderHisGuide.GoodsName = goodsUnitData.GoodsName;
			orderHisGuide.GoodsMakerCode = goodsUnitData.GoodsMakerCd;
			orderHisGuide.GoodsMakerName = goodsUnitData.MakerName;
			orderHisGuide.OrderDateStart = DateTime.MinValue;
			orderHisGuide.OrderDateEnd = DateTime.MinValue;
            // --- ADD 2014/04/24 仕入伝票入力で該当データなしになる件 システムテスト障害一覧No.2312とRedmine#42258 ---------->>>>>
            // 発注残データ検索処理条件更新
            orderHisGuide.SearchOrderRemainDataCndn(DCHAT04110UA.DisplayType.DisplayAndSelect);
            // --- ADD 2014/04/24 仕入伝票入力で該当データなしになる件 システムテスト障害一覧No.2312とRedmine#42258 ----------<<<<<
			int st = orderHisGuide.SearchOrderRemainData();

			if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				DialogResult dialogResult = orderHisGuide.ShowDialog(this, DCHAT04110UA.DisplayType.DisplayAndSelect);

				if (dialogResult == DialogResult.OK)
				{
					List<OrderListResultWork> retOrderListResultWorkList = new List<OrderListResultWork>();
					retOrderListResultWorkList = orderHisGuide.orderListResultWorkList;

					if (( retOrderListResultWorkList != null ) && ( retOrderListResultWorkList.Count > 0 ))
					{
						retObj = (object)retOrderListResultWorkList[0];
					}
				}
			}
			return st;
		}

		/// <summary>
		/// 入荷残検索
		/// </summary>
		/// <param name="goodsNo"></param>
		/// <param name="goodsMakerCode"></param>
		/// <param name="?"></param>
		/// <returns></returns>
		private int SearchArrivalRemain( GoodsUnitData goodsUnitData, out object retObj )
		{
			retObj = null;

			DCKOU04101UA stockHisGuide = new DCKOU04101UA();

			// プロパティの設定
			stockHisGuide.IsMultiSelect = false;
			stockHisGuide.Standard_UGroupBox_Expand = false;
			stockHisGuide.Detail_UGroupBox_Expand = false;

            stockHisGuide.SectionCode = this._stockSlipInputAcs.StockSlip.StockSectionCd;
            stockHisGuide.SectionName = this._stockSlipInputAcs.StockSlip.StockSectionNm;
			stockHisGuide.SupplierCd = this._stockSlipInputAcs.StockSlip.SupplierCd;
            stockHisGuide.SupplierName = this._stockSlipInputAcs.StockSlip.SupplierSnm;
			stockHisGuide.GoodsNo = goodsUnitData.GoodsNo;
			stockHisGuide.GoodsName = goodsUnitData.GoodsName;
			stockHisGuide.GoodsMakerCode = goodsUnitData.GoodsMakerCd;
			stockHisGuide.GoodsMakerName = goodsUnitData.MakerName;

			bool ret = stockHisGuide.SearchData(1); //0:仕入 1:入荷

			if (ret)
			{
                DialogResult dialogResult = stockHisGuide.ShowDialog(this, 1);

				if (dialogResult == DialogResult.OK)
				{
					List<StcHisRefDataWork> stcHisRefDataWorkList = new List<StcHisRefDataWork>();

					stcHisRefDataWorkList = stockHisGuide.stcHisRefDataWork;

					if (( stcHisRefDataWorkList != null ) && ( stcHisRefDataWorkList.Count > 0 ))
					{
						retObj = (object)stcHisRefDataWorkList[0];
					}
				}
			}

			return ( retObj != null ) ? 0 : -1;
		}

		#endregion

		/// <summary>
		/// メモ表示処理
		/// </summary>
		internal void DisplayMemo()
		{
			this.DisplayMemo(this.GetActiveRowIndex());
		}

		/// <summary>
		/// メモ表示処理
		/// </summary>
		/// <param name="rowIndex">対象行</param>
		private void DisplayMemo( int rowIndex )
		{
			if (this._stockDetailDataTable[rowIndex] != null)
			{
				if (this._stockSlipInputAcs.MemoExist(this._stockDetailDataTable[rowIndex].StockRowNo) == true)
				{
					this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.MemoExistColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
				}
				else
				{
					this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.MemoExistColumn.ColumnName].Appearance.Image = null;
				}
			}
		}

		/// <summary>
		/// 売上表示処理
		/// </summary>
		internal void DisplaySalesInfo()
		{
			this.DisplaySalesInfo(this.GetActiveRowIndex());
		}

		/// <summary>
		/// 売上表示処理
		/// </summary>
		/// <param name="rowIndex">対象行</param>
		private void DisplaySalesInfo( int rowIndex )
		{
			if (this._stockDetailDataTable[rowIndex] != null)
			{
				if (this._stockSlipInputAcs.SalesTempExist(this._stockDetailDataTable[rowIndex].StockRowNo) == true)
				{
					this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.SalesInfoExistColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
				}
				else
				{
					this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.SalesInfoExistColumn.ColumnName].Appearance.Image = null;
				}
			}
		}

		/// <summary>
		/// オープン価格情報表示
		/// </summary>
		/// <param name="rowIndex"></param>
		private void DisplayOpenPrice( int rowIndex )
		{
			if (this._stockDetailDataTable[rowIndex] != null)
			{
				if ((Int32)this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.OpenPriceDivColumn.ColumnName].Value == 1)
				{
					this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.OpenPriceColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
				}
				else
				{
					this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.OpenPriceColumn.ColumnName].Appearance.Image = null;
				}
			}
		}

		/// <summary>
		/// 最終行に空白行を追加します。
		/// </summary>
		private void AddLastEmptyRow()
		{

            //// 最終行が入力済みの場合は１行追加
            //if (this._stockSlipInputAcs.ExistStockDetailInput(this._stockDetailDataTable[this._stockDetailDataTable.Count - 1]))
            //{
            //    this._stockSlipInputAcs.AddStockDetailRow();

            //    // 表示用行番号調整処理
            //    this._stockSlipInputAcs.AdjustRowNo();

            //    // 明細グリッド・行単位でのセル設定
            //    this.SettingGridRow(this._stockDetailDataTable.Count - 1, this._stockSlipInputAcs.StockSlip);
            //}
		}

        // 2009.07.10 Add >>>
        /// <summary>
        /// セルの移動が可能かチェックします。
        /// </summary>
        /// <param name="move">0:上方向、1:下方向</param>
        /// <param name="rowIndex">対象セルのIndex</param>
        /// <param name="colKey">対象セルのKey</param>
        /// <returns>0:移動可能,-1:先頭or最終行,-2:移動不可</returns>
        private int CheckCellMoveUpDown(int move, int rowIndex, string colKey)
        {
            int ret = 0;

            switch (move)
            {
                // 上方向に対するチェック
                case 0:
                    if (rowIndex == 0) return -1;

                    ret = -2;
                    for (int index = rowIndex - 1; index >= 0; index--)
                    {
                        // 移動可能なセルがあった場合は終了
                        if (this.uGrid_Details.Rows[index].Cells[colKey].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                        {
                            ret = 0;
                            break;
                        }
                    }
                    break;
                // 下方向に対するチェック
                case 1:
                    if (rowIndex == this.uGrid_Details.Rows.Count - 1) return -1;

                    ret = -2;
                    for (int index = rowIndex + 1; index < uGrid_Details.Rows.Count; index++)
                    {
                        // 移動可能なセルがあった場合は終了
                        if (this.uGrid_Details.Rows[index].Cells[colKey].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                        {
                            ret = 0;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            return ret;
        }
        // 2009.07.10 Add <<<

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
#if false
            while (this._deserializeThread.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(100);
            }

			this.uGrid_Details.DataSource = this._stockDetailDataTable;

			// ボタン初期設定処理
			this.ButtonInitialSetting();

			// ツールチップ初期設定処理
			this.ToolTipInfoInitialSetting();

			// グリッドキーマッピング設定処理
			this.MakeKeyMappingForGrid(this.uGrid_Details);

			// クリア処理
			this.Clear();

			this._stockDetailDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.StockDetail_ColumnChanged);
#endif
            this.uGrid_Details.DataSource = this._stockDetailDataTable;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // ツールチップ初期設定処理
            this.ToolTipInfoInitialSetting();

            // グリッドキーマッピング設定処理
            this.MakeKeyMappingForGrid(this.uGrid_Details);

            // グリッドクリア
            this.Clear(false);

            this._stockDetailDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.StockDetail_ColumnChanged);
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

#if false 
		/// <summary>
		/// OLEScannerデータ読み込みイベント
		/// </summary>
		/// <param name="status"></param>
		private void OLEScanner_DataEvent(int status)
		{
			this.AutoSettingGoodsCode(this._OLEScannerController.ScanDataLabel);

			// イベントイネーブル実行
			this._OLEScannerController.DataEventEnabled = true;
        }
#endif

#if false 
		/// <summary>
		/// OLEScannerエラー発生イベント
		/// </summary>
		/// <param name="ResultCode"></param>
		/// <param name="ResultCodeExtended"></param>
		/// <param name="ErrorLocus"></param>
		/// <param name="pErrorResponse"></param>
		private void OLEScanner_ErrorEvent(int ResultCode, int ResultCodeExtended, int ErrorLocus, ref int pErrorResponse)
		{
			//
		}
#endif
        /// <summary>
		/// グリッド初期レイアウト設定イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
            this.uGrid_Details.BeginUpdate();

			// グリッド列初期設定処理
			this.InitialSettingGridCol();

			// グリッド列設定処理（ユーザー設定より）
			this.GridSetting(this._stockInputConstructionAcs.StockInputConstruction);

            this.uGrid_Details.EndUpdate();
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
								if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull))
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
		private void uGrid_Details_BeforeCellDeactivate( object sender, CancelEventArgs e )
		{
			if (this._beforeCell != null)
			{
				if (this._beforeCell.Column.DataType == typeof(string) &&
					this._beforeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
				{
					// ゼロ詰め実行
					this._stockDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key] = uiSetControl1.GetZeroPaddedText(this._beforeCell.Column.Key, (string)this._stockDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key]);
				}

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // ForeColor戻し
                this._beforeCell.Band.Override.ActiveCellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
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
					this._stockSlipInputAcs.InitializeStockDetailRowStatusColumn();

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

								//if (this.uGrid_Details.Rows[lastInputRowIndex].Cells[this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
								//{
								//    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[lastInputRowIndex].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName];
								//}
								//else
								//{
								//    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[lastInputRowIndex].Cells[this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName];
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
                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);  // ADD 2011/07/18
                                        this._stockSlipInputAcs.StockDetailStockInfoAdjust();  // ADD 2011/07/18
                                        if (this.GridKeyDownTopRow != null)
                                        {
                                            this.GridKeyDownTopRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                    // 2009.07.10 Add >>>
                                    else
                                    {
                                        // 上方向に移動可能なセルがあるかチェック
                                        switch (this.CheckCellMoveUpDown(0, this.uGrid_Details.ActiveCell.Row.Index, this.uGrid_Details.ActiveCell.Column.Key))
                                        {
                                            // 有り
                                            case 0:
                                                break;
                                            // 無し
                                            case -2:
                                                // 2009.08.03 >>>
                                                //// 下の行の品番をアクティブに設定
                                                //this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index - 1].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Activated = true;
                                                //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                                //e.Handled = true;

                                                // 品番、品名共に入力不可の行の場合は、先頭行で↑押下時と同じイベントを走らせる
                                                if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index - 1].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled &&
                                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index - 1].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                                {
                                                    if (this.GridKeyDownTopRow != null)
                                                    {
                                                        this.GridKeyDownTopRow(this, new EventArgs());
                                                        e.Handled = true;
                                                    }
                                                }
                                                else
                                                {
                                                    // １行上の品番が入力できる場合は、品番へ移動
                                                    if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index - 1].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                                    {
                                                        this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index - 1].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Activated = true;
                                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                                        e.Handled = true;
                                                    }
                                                    // １行上の品名が入力できる場合は、品名へ移動
                                                    else if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index - 1].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                                    {
                                                        this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index - 1].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Activated = true;
                                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                                        e.Handled = true;
                                                    }

                                                }
                                                // 2009.08.03 <<<
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    // 2009.07.10 Add <<<
                                }
                                break;
                            }
                        case Keys.Down:
                            {
                                if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);  // ADD 2011/07/18
                                    this._stockSlipInputAcs.StockDetailStockInfoAdjust();  // ADD 2011/07/18
                                    if (e.KeyCode == Keys.Down)
                                    {
                                        if (this.GridKeyDownButtomRow != null)
                                        {
                                            this.GridKeyDownButtomRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                }
                                // 2009.07.10 Add >>>
                                else
                                {
                                    // 下方向に移動可能なセルがあるかチェック
                                    switch (this.CheckCellMoveUpDown(1, this.uGrid_Details.ActiveCell.Row.Index, this.uGrid_Details.ActiveCell.Column.Key))
                                    {
                                        // 有り
                                        case 0:
                                            break;
                                        // 無し
                                        case -2:
                                            // 2009.08.03 >>>
                                            //// 下の行の品番をアクティブに設定
                                            //this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index + 1].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Activated = true;
                                            //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            //e.Handled = true;

                                            // 品番、品名共に入力不可の行の場合は、最終行で↓押下時と同じイベントを走らせる
                                            if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index + 1].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled &&
                                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index + 1].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                            {
                                                if (this.GridKeyDownButtomRow != null)
                                                {
                                                    this.GridKeyDownButtomRow(this, new EventArgs());
                                                    e.Handled = true;
                                                }
                                            }
                                            else
                                            {
                                                // １行下の品番が入力できる場合は、品名へ移動
                                                if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index + 1].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                                {
                                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index + 1].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Activated = true;
                                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                                    e.Handled = true;
                                                }
                                                // １行下の品名が入力できる場合は、品名へ移動
                                                else if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index + 1].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                                {
                                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index + 1].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName].Activated = true;
                                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                                    e.Handled = true;
                                                }
                                            }
                                            // 2009.08.03 <<<
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                // 2009.07.10 Add <<<
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
			// ActiveCellが単価の場合
			if (cell.Column.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName)
			{
				// 編集モード中？
				if (cell.IsInEditMode)
				{
                    if (!this.KeyPressNumCheck(11, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
						e.Handled = true;
						return;
					}
				}
			}
			// ActiveCellが仕入金額の場合
			else if (cell.Column.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName)
			{
				// 編集モード中？
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
					{
						e.Handled = true;
						return;
					}
				}
			}
			// ActiveCellが数量の場合
			else if (cell.Column.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
			{
				// 編集モード中？
				if (cell.IsInEditMode)
				{
                    if (!this.KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
				}
			}
            // ActiveCellが定価の場合
            else if (cell.Column.Key == this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(7, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // ActiveCellが仕入率の場合
            else if (cell.Column.Key == this._stockDetailDataTable.StockRateColumn.ColumnName)
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
            this._supplierSelectError = false;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

			// 仕入先入力チェック処理
			bool customerCodeCheck = this.CheckCustomerCodeInput();

			if (!customerCodeCheck)
			{
                this._supplierSelectError = true;
				e.Cancel = true;
				return;
			}

			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

			if (stockSlip == null)
			{
				e.Cancel = true;
				return;
			}

#if false
			// 同時入力済みの場合は変更確認
			if (( this._stockDetailDataTable[cell.Row.Index].AcptAnOdrStatusSync != 0 ) &&
				( this._stockDetailDataTable[cell.Row.Index].SalesSlipDtlNumSync != 0 ) &&
				( !this._stockDetailDataTable[cell.Row.Index].SyncCheckFlg ))
			{
				DialogResult dialogRet = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"売上情報と不整合になります。" + Environment.NewLine + "変更してもよろしいですか？",
												-1,
												MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
				if (dialogRet == DialogResult.Yes)
				{
					this._stockDetailDataTable[cell.Row.Index].SyncCheckFlg = true;
				}
				else
				{
					e.Cancel = true;
				}
			}
#endif

			#region ●商品コード
			if (cell.Column.Key == this._stockDetailDataTable.GoodsNoColumn.ColumnName)
			{
                string newGoodsNo = ( e.NewValue is System.DBNull ) ? string.Empty : e.NewValue.ToString();
                if (!uiSetControl1.CheckMatchingSet(this._stockDetailDataTable.GoodsNoColumn.ColumnName, newGoodsNo))
                {
                    e.Cancel = true;
                    return;
                }

				if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
				{
					this._beforeGoodsNo = e.Cell.Value.ToString();
				}
				else
				{
                    this._beforeGoodsNo = string.Empty;
				}
			}
			#endregion

			#region ●商品名称
			else if (cell.Column.Key == this._stockDetailDataTable.GoodsNameColumn.ColumnName)
			{

                if (( e.Cell.Value != null ) && ( !( e.Cell.Value is System.DBNull ) ))
                {
                    this._beforeGoodsName = e.Cell.Value.ToString();
                }
                else
                {
                    this._beforeGoodsName = string.Empty;
                }
			}
			#endregion

			#region ●倉庫
			else if (cell.Column.Key == this._stockDetailDataTable.WarehouseCodeColumn.ColumnName)
			{
                if (( e.Cell.Value != null ) && ( !( e.Cell.Value is System.DBNull ) ))
                {
                    this._beforeWarehouseCode = e.Cell.Value.ToString();
                }
                else
                {
                    this._beforeWarehouseCode = string.Empty;
                }
			}

			#endregion

			#region ●発注番号
			else if (cell.Column.Key == this._stockDetailDataTable.OrderNumberColumn.ColumnName)
			{
                if (( e.Cell.Value != null ) && ( !( e.Cell.Value is System.DBNull ) ))
                {
                    this._beforeOrderNumber = e.Cell.Value.ToString();
                }
                else
                {
                    this._beforeOrderNumber = string.Empty;
                }
			}
			#endregion

			#region ●単価
			else if (cell.Column.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName)
			{
				this._beforeStockUnitPriceDisplay = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToDouble(e.Cell.Value);
			}
			#endregion

			#region ●メーカーコード
			else if (cell.Column.Key == this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName)
			{
                this._beforeGoodsMakerCd = ( e.Cell.Value is DBNull ) ? 0 : this._stockDetailDataTable[e.Cell.Row.Index].GoodsMakerCd;
			}
			#endregion

			#region ●BLコード
			else if (cell.Column.Key == this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName)
			{
                this._beforeBLGoodsCode = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToInt32(e.Cell.Value);
            }
			#endregion

			#region ●販売先
			else if (cell.Column.Key == this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName)
			{
                this._beforeSalesCustomerCode = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToInt32(e.Cell.Value);
            }
			#endregion

            #region ●定価
            else if (cell.Column.Key == this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName)
            {
                this._beforeListPriceDisplay = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToDouble(e.Cell.Value);
            }
            #endregion

            #region ●仕入率
            else if (cell.Column.Key == this._stockDetailDataTable.StockRateColumn.ColumnName)
            {
                this._beforeStockRate = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToDouble(e.Cell.Value);
            }
            #endregion

            #region ●仕入金額
            else if (cell.Column.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName)
            {
                this._beforeStockPrice = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToInt64(e.Cell.Value);
            }
            #endregion

            #region ●得意先
            else if (cell.Column.Key == this._stockDetailDataTable.CustomerCodeColumn.ColumnName)
            {
                this._beforeCustomerCode = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToInt32(e.Cell.Value);
            }
            #endregion

            #region ●数量
            else if (cell.Column.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
            {
                this._beforeStockCount = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToDouble(e.Cell.Value); 
            }
			#endregion

		}

		/// <summary>
		/// グリッドセルアップデート後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note : 2012/06/15 tianjw</br>
        /// <br>管理番号    : 10801804-00 2012/07/25配信分</br>
        /// <br>              Redmine#30517 品名未入力行の不具合の対応</br>
        /// <br>Update Note : 2015/08/26 cheq</br>
        /// <br>管理番号    : 11170129-00 Redmine#47008</br>
        /// <br>              メーカー名称の値がメーカーコードになるの障害対応</br>
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
			int stockRowNo = this._stockDetailDataTable[cell.Row.Index].StockRowNo;
			int rowIndex = e.Cell.Row.Index;
			bool reCalcStockPrice = false;          // 仕入金額再計算フラグ
            bool adjustStockPrice = false;          // 仕入金額調整フラグ
            this._afterCellUpdateCancel = false;
			this._cannotGoodsRead = false;
			
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;
			if (stockSlip == null) return;

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
                    e.Cell.Value = string.Empty;
				}
                this.uGrid_Details.BeforeCellUpdate += this.uGrid_Details_BeforeCellUpdate;
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }

			List<int> settingStockRowNoList = new List<int>();

			#region ●品番
			//--------------------
            // 品番
			//--------------------
			if (cell.Column.Key == this._stockDetailDataTable.GoodsNoColumn.ColumnName)
			{
                string goodsNo = cell.Value.ToString();
                bool searchRemain = ( this._stockDetailDataTable[rowIndex].StockSlipCdDtl != 2 );

                if (!String.IsNullOrEmpty(goodsNo))
                {
                    object retObj;

                    // 商品＆残検索
                    switch (this.SearchGoodsAndRemain(goodsNo, searchRemain, out retObj))
                    {
                        case 0:
                            {
                                if (retObj != null)
                                {
                                    // 商品検索
                                    if (retObj is List<GoodsUnitData>)
                                    {
                                        List<GoodsUnitData> goodsUnitDataList = (List<GoodsUnitData>)retObj;
                                        this._stockSlipInputAcs.StockDetailRowGoodsSettingBasedOnGoodsUnitData(stockRowNo, goodsUnitDataList, out settingStockRowNoList, true);
                                    }
                                    // 発注残検索
                                    else if (retObj is OrderListResultWork)
                                    {
                                        List<OrderListResultWork> addOrderListResultWorkList = new List<OrderListResultWork>();
                                        addOrderListResultWorkList.Add((OrderListResultWork)retObj);
                                        // 2009.04.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                        //int readStatus = this._stockSlipInputAcs.StockDetailRowSettingFromOrderListResultWorkList(stockRowNo, addOrderListResultWorkList, StockSlipInputAcs.WayToDetailExpand.AddUp, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                        int readStatus = this._stockSlipInputAcs.StockDetailRowSettingFromOrderListResultWorkList(stockRowNo, addOrderListResultWorkList, StockSlipInputAcs.WayToDetailExpand.AddUpRemainder, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                        // 2009.04.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                        //if (( readStatus == -999 ) && ( wayToDetailExpand == StockSlipInputAcs.WayToDetailExpand.AddUpAndSync ))
                                        //{
                                        //    TMsgDisp.Show(
                                        //        this,
                                        //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        //        this.Name,
                                        //        "発注と同時入力したデータは展開されませんでした。",
                                        //        0,
                                        //        MessageBoxButtons.OK);
                                        //}
                                    }
                                    // 入荷残検索
                                    else if (retObj is StcHisRefDataWork)
                                    {
                                        List<StcHisRefDataWork> addStcHisRefDataWorkList = new List<StcHisRefDataWork>();
                                        addStcHisRefDataWorkList.Add((StcHisRefDataWork)retObj);
                                        // 2009.04.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                        //this._stockSlipInputAcs.StockDetailRowSettingFromstcHisRefDataWorkList(stockRowNo, addStcHisRefDataWorkList, StockSlipInputAcs.WayToDetailExpand.AddUp, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                        this._stockSlipInputAcs.StockDetailRowSettingFromstcHisRefDataWorkList(stockRowNo, addStcHisRefDataWorkList, StockSlipInputAcs.WayToDetailExpand.AddUpRemainder, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                        // 2009.04.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    }

                                    // 明細グリッド設定処理
                                    this.SettingGrid();

                                    // ---UPD 2011/07/18------------->>>>>
                                    // 在庫調整
                                    //this._stockSlipInputAcs.StockDetailStockInfoAdjust();

                                    if (this._stockSlipInputInitDataAcs.GetAllDefSet().DtlCalcStckCntDsp == 0)
                                    {
                                        // 在庫調整
                                        this._stockSlipInputAcs.StockDetailStockInfoAdjust();
                                    }
                                    else
                                    {
                                        this._stockSlipInputAcs.StockRowNo = stockRowNo;
                                        this._stockSlipInputAcs.HasStockInfo = true;
                                        // 在庫調整
                                        this._stockSlipInputAcs.StockDetailStockInfoAdjust();
                                    }
                                    // ---UPD 2011/07/18-------------<<<<<

                                    // 最終行に空行を追加
                                    this.AddLastEmptyRow();
                                }

                                break;
                            }
                        case -1:
                            {
                                // 商品コードを元に戻す
                                this._stockDetailDataTable[cell.Row.Index].GoodsNo = this._beforeGoodsNo;

                                this._cannotGoodsRead = true;
                                return;
                            }
                    }

                }
                else
                {
                    // 商品マスタ情報設定処理
                    this._stockSlipInputAcs.StockDetailRowGoodsSetting(stockRowNo, null);
                    settingStockRowNoList.Add(stockRowNo);
                }

				reCalcStockPrice = true;
			}
			#endregion

			#region ●商品名称
			//--------------------
			// 商品名称 
			//--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.GoodsNameColumn.ColumnName)
            {
                string goodsName = cell.Value.ToString();

                // ----- ADD 2012/06/15 tianjw Redmine#30517 ---------->>>>>
                // 品名をクリアすると、品名が元に戻る。(前回入力内容に戻る。)
                if (string.IsNullOrEmpty(goodsName))
                {
                    goodsName = this._prevGoodsName;
                    this._stockDetailDataTable[cell.Row.Index].GoodsName = goodsName;

                    this._afterCellUpdateCancel = true;
                    return;
                }
                // ----- ADD 2012/06/15 tianjw Redmine#30517 ----------<<<<<

                if (( this._stockDetailDataTable[rowIndex].EditStatus != StockSlipInputAcs.ctEDITSTATUS_RowDiscount ) &&
                    ( string.IsNullOrEmpty(this._beforeGoodsName) ) &&
                    ( string.IsNullOrEmpty(this._stockDetailDataTable[rowIndex].GoodsNo.Trim()) ) &&
                    ( !string.IsNullOrEmpty(goodsName) ) &&
                      ( this._stockSlipInputInitDataAcs.InputMode != StockSlipInputInitDataAcs.ctINPUTMODE_GoodsNoNecessary ))
                {
                    // 仕入明細データセッティング処理（用品入力用）
                    this._stockSlipInputAcs.StockDetailRowUtensilsInput(stockRowNo);
                }

                this._stockDetailDataTable[rowIndex][this._stockDetailDataTable.GoodsNameKanaColumn.ColumnName] = goodsName;

                // 商品で品番必須以外
                if (( this._stockSlipInputAcs.StockSlip.StockGoodsCd == 0 ) && ( this._stockSlipInputInitDataAcs.InputMode != StockSlipInputInitDataAcs.ctINPUTMODE_GoodsNoNecessary ))
                {
                    // 最終行に空行を追加
                    this.AddLastEmptyRow();
                }
            }

            #endregion

            #region ●倉庫コード
            //--------------------
            // 倉庫コード
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.WarehouseCodeColumn.ColumnName)
            {
                string warehouseCode = cell.Value.ToString();
                string goodsNo = this._stockDetailDataTable[rowIndex].GoodsNo;
                int goodsMakerCd = this._stockDetailDataTable[rowIndex].GoodsMakerCd;

                if (!String.IsNullOrEmpty(warehouseCode))
                {
                    string name = this._stockSlipInputInitDataAcs.GetName_FromWarehouse(warehouseCode);

                    string errorMsg = string.Empty;
                    bool inputError = false;
                    if (!String.IsNullOrEmpty(name))
                    {
                        // 在庫検索
                        List<Stock> stockList;
                        stockList = this._stockSlipInputAcs.SearchStock(warehouseCode.Trim(), this._stockDetailDataTable[rowIndex].GoodsNo, this._stockDetailDataTable[rowIndex].GoodsMakerCd);

                        if (( stockList == null ) || ( stockList.Count == 0 ))
                        {
                            errorMsg = "倉庫 [" + warehouseCode + "] に該当する商品の在庫が存在しません。";
                            inputError = true;
                        }
                        else
                        {
                            // 倉庫名称設定処理
                            this._stockSlipInputAcs.StockDetialWarehouseInfoSetting(stockRowNo, warehouseCode, name);
                            this._stockSlipInputAcs.HasStockInfo = true; // ADD 2011/07/18 在庫情報を設定処理場合、現在庫数加算しません。 
                            // 在庫情報設定処理
                            this._stockSlipInputAcs.StockDetailRowStockSetting(stockRowNo, stockList);

                            // 変更前倉庫の在庫を調整
                            this._stockSlipInputAcs.StockDetailStockInfoAdjust(uiSetControl1.GetZeroPaddedText(e.Cell.Column.Key, this._beforeWarehouseCode), goodsNo, goodsMakerCd);
                        }
                    }
                    else
                    {
                        inputError = true;
                        errorMsg = "倉庫コード [" + warehouseCode + "] に該当するデータが存在しません。";
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
                        this._stockDetailDataTable[cell.Row.Index].WarehouseCode = this._beforeWarehouseCode;

                        this._afterCellUpdateCancel = true;

                        return;
                    }
                }
                else
                {
                    // 在庫情報クリア
                    this._stockSlipInputAcs.StockDetailRowClearStockInfo(stockRowNo);

                    // 在庫数調整
                    this._stockSlipInputAcs.StockDetailStockInfoAdjust();
                }
            }
            #endregion

            #region ●発注番号
            //--------------------
            // 発注番号
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.OrderNumberColumn.ColumnName)
            {
#if false
				string orderNumber = cell.Value.ToString();

				if (!String.IsNullOrEmpty(orderNumber))
				{
					
					// 発注残検索
					string sectionCode = this._stockSlipInputAcs.StockSlip.SectionCode;

					OrderListResultWork orderListResultWork;
					DCHAT04120UA orderRemainSearch = new DCHAT04120UA();
					string msg;
					int status = orderRemainSearch.SearchOrderNumber(this, this._enterpriseCode, sectionCode, this._stockSlipInputAcs.StockSlip.SupplierCd, this._stockSlipInputAcs.StockSlip.SupplierSnm, orderNumber, out orderListResultWork, out msg);

					switch (status)
					{
						case (int)(int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								List<OrderListResultWork> orderListResultWorkList = new List<OrderListResultWork>();
								orderListResultWorkList.Add(orderListResultWork);

								StockSlipInputAcs.WayToDetailExpand wayToDetailExpand = ( this._stockSlipInputInitDataAcs.GetAcptAnOdrTtlSt().AodrOrderAddUpDiv == 0 ) ? StockSlipInputAcs.WayToDetailExpand.AddUpAndSync : StockSlipInputAcs.WayToDetailExpand.AddUp;

								int readStatus = this._stockSlipInputAcs.StockDetailRowSettingFromOrderListResultWorkList(stockRowNo, orderListResultWorkList, wayToDetailExpand, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);

								if (( readStatus == -999 ) && ( wayToDetailExpand == StockSlipInputAcs.WayToDetailExpand.AddUpAndSync ))
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"発注と同時入力したデータは展開されませんでした。",
										0,
										MessageBoxButtons.OK);
								}


								reCalcStockPrice = true;

								// 明細グリッド設定処理
								this.SettingGrid();

								// 最終行に空行を追加
								this.AddLastEmptyRow();


								break;
							}
						case -1:
							{
								this._stockDetailDataTable[cell.Row.Index].OrderNumber = this._beforeOrderNumber;

								this._afterCellUpdateCancel = true;
								break;
							}
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF:
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"発注番号[" + orderNumber + "] に該当するデータが存在しません。",
									-1,
									MessageBoxButtons.OK);
								this._stockDetailDataTable[cell.Row.Index].OrderNumber = this._beforeOrderNumber;

								this._afterCellUpdateCancel = true;
								break;
							}
						default:
							break;
					}
				}
				else
				{
					// 倉庫名称設定処理
					this._stockDetailDataTable[cell.Row.Index].OrderNumber = string.Empty;
				}
#endif
            }
            #endregion

            #region ●仕入金額
            //--------------------
            // 仕入金額
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName)
            {
                string errMsg;
                StockSlipInputAcs.CheckResult checkResult = this._stockSlipInputAcs.StockPriceCheck(stockRowNo, out errMsg);

                if (checkResult != StockSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == StockSlipInputAcs.CheckResult.Error)
                    {
                        this._stockDetailDataTable[rowIndex].StockPriceDisplay = this._beforeStockPrice;
                        this._afterCellUpdateCancel = true;
                        return;
                    }
                }

                // 仕入明細データセッティング処理（仕入商品区分設定）
                this._stockSlipInputAcs.StockDetailRowStockGoodsCdSetting(stockRowNo, stockSlip.StockGoodsCd);
                reCalcStockPrice = true;
            }
            #endregion

            #region ●数量
            //--------------------
            // 数量
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
            {

                #region 数量のチェック

                string errMsg = string.Empty;
                //StockSlipInputAcs.CheckResult checkResult = this._stockSlipInputAcs.StockCountCheck(stockRowNo, out errMsg);                        // DEL 2013/01/07
                StockSlipInputAcs.CheckResult checkResult = this._stockSlipInputAcs.StockCountCheck(stockRowNo, out errMsg, this._beforeStockCount);  // ADD 2013/01/07
                
                if (checkResult != StockSlipInputAcs.CheckResult.Ok)
                {
                    emErrorLevel errorLevel = emErrorLevel.ERR_LEVEL_CONFIRM;
                    switch (checkResult)
                    {
                        case StockSlipInputAcs.CheckResult.Error:
                            errorLevel = emErrorLevel.ERR_LEVEL_EXCLAMATION;
                            break;
                        case StockSlipInputAcs.CheckResult.Warning:
                            errorLevel = emErrorLevel.ERR_LEVEL_EXCLAMATION;
                            break;
                        case StockSlipInputAcs.CheckResult.Confirm:
                            errorLevel = emErrorLevel.ERR_LEVEL_INFO;
                            break;
                        default:
                            break;
                    }

                    TMsgDisp.Show(
                        this,
                        errorLevel,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == StockSlipInputAcs.CheckResult.Error)
                    {
                        this._stockDetailDataTable[rowIndex].StockCountDisplay = this._beforeStockCount;
                        this._afterCellUpdateCancel = true;
                        return;
                    }
                    else if (checkResult != StockSlipInputAcs.CheckResult.Ok)
                    {
                        adjustStockPrice = true;
                    }
                }

                #endregion
                // ---UPD 2011/07/18------------->>>>>
                // 仕入明細行オブジェクトの数量調整
                //this._stockSlipInputAcs.StockDetailRowStockCountSetting(stockRowNo);

                if (this._stockSlipInputInitDataAcs.GetAllDefSet().DtlCalcStckCntDsp == 0)
                {
                    // 仕入明細行オブジェクトの数量調整
                    this._stockSlipInputAcs.StockDetailRowStockCountSetting(stockRowNo);
                }
                else
                {
                    this._stockSlipInputAcs.HasStockInfo = true;
                    this._stockSlipInputAcs.IsShipmentChange = true;
                    // 仕入明細行オブジェクトの数量調整
                    this._stockSlipInputAcs.StockDetailRowStockCountSetting(stockRowNo);
                }
                // ---UPD 2011/07/18-------------<<<<<

                settingStockRowNoList.Add(stockRowNo);

                reCalcStockPrice = true;
            }
            #endregion

            #region ●単価
            //--------------------
            // 単価
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName)
            {
                double newStockUnitPriceDisplay = TStrConv.StrToDoubleDef(e.Cell.Value.ToString(), 0);

                #region 単価チェック

                string errMsg = string.Empty;
                StockSlipInputAcs.CheckResult checkResult = this._stockSlipInputAcs.StockUnitPriceCheck(stockRowNo, 0, out errMsg);

                if (checkResult != StockSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == StockSlipInputAcs.CheckResult.Error)
                    {
                        this._stockDetailDataTable[rowIndex].StockUnitPriceDisplay = this._beforeStockUnitPriceDisplay;
                        this._afterCellUpdateCancel = true;
                        return;
                    }
                }

                #endregion

                // 仕入明細データセッティング処理（単価設定）
                this._stockSlipInputAcs.StockDetailRowStockUnitPriceSetting(stockRowNo, this._stockDetailDataTable[rowIndex].StockUnitPriceDisplay);
                settingStockRowNoList.Add(stockRowNo);

                reCalcStockPrice = true;
            }
            #endregion

            #region ●課税・非課税区分
            //--------------------
            // 課税・非課税区分
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.TaxDivColumn.ColumnName)
            {
                int newValue = Convert.ToInt32(e.Cell.Value);

                if (newValue != this._stockDetailDataTable[rowIndex].TaxationCode)
                {
                    this._stockDetailDataTable[rowIndex].TaxationCode = newValue;

                    // 仕入明細データセッティング処理（単価調整）
                    this._stockSlipInputAcs.StockDetailRowPriceAdjust(stockRowNo);
                    settingStockRowNoList.Add(stockRowNo);
                    reCalcStockPrice = true;
                }
            }
            #endregion

            #region ●メーカー
            //--------------------
            // メーカーコード
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName)
            {
                int goodsMakerCd = TStrConv.StrToIntDef(cell.Value.ToString(), 0);
                string beforeMakerName = this._stockDetailDataTable[cell.Row.Index].MakerName;
                string beforeMakerKanaName = this._stockDetailDataTable[cell.Row.Index].MakerKanaName;

                if (goodsMakerCd != 0)
                {
                    // 先にメーカー情報を取得する
                    string makerName, makerKanaName;
                    this._stockSlipInputInitDataAcs.GetName_FromMaker(goodsMakerCd, out makerName, out makerKanaName);

                    if (!String.IsNullOrEmpty(makerName))
                    {
                        this._stockSlipInputAcs.StockDetailMakerInfoSetting(stockRowNo, goodsMakerCd, makerName, makerKanaName);
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
                        this._stockDetailDataTable[cell.Row.Index].GoodsMakerCd = this._beforeGoodsMakerCd;

                        this._afterCellUpdateCancel = true;
                        return;
                    }
                }
                else
                {
                    // メーカー名称設定処理
                    this._stockSlipInputAcs.StockDetailMakerInfoSetting(stockRowNo, 0, string.Empty, string.Empty);
                }

                string goodsNo = this._stockDetailDataTable[cell.Row.Index].GoodsNo;

                // 商品コード有りでメーカーが変わった場合
                if (( goodsMakerCd != this._beforeGoodsMakerCd ) && ( !String.IsNullOrEmpty(goodsNo) ))
                {
                    switch (this.SearchGoodsAndRemain_And_RowSetting(rowIndex))
                    {
                        case 0:
                            break;
                        case -1:
                            this._stockSlipInputAcs.StockDetailMakerInfoSetting(stockRowNo, this._beforeGoodsMakerCd, beforeMakerName, beforeMakerKanaName);
                            break;
                    }
                    settingStockRowNoList.Add(stockRowNo);

                    // ---UPD 2011/07/18--------------->>>>>
                    // 在庫調整
                    //this._stockSlipInputAcs.StockDetailStockInfoAdjust();

                    if (this._stockSlipInputInitDataAcs.GetAllDefSet().DtlCalcStckCntDsp == 0)
                    {
                        // 在庫調整
                        this._stockSlipInputAcs.StockDetailStockInfoAdjust();
                    }
                    else
                    {
                        this._stockSlipInputAcs.StockRowNo = stockRowNo;
                        this._stockSlipInputAcs.HasStockInfo = true;
                        // 在庫調整
                        this._stockSlipInputAcs.StockDetailStockInfoAdjust();
                    }
                    // ---UPD 2011/07/18---------------<<<<<

                    reCalcStockPrice = true;
                    //this._stockDetailDataTable[cell.Row.Index].MakerName = this._stockDetailDataTable[cell.Row.Index].GoodsMakerCd.ToString(); // DEL 2015/08/26 cheq for Redmine#47008 メーカー名称の値がメーカーコードになるの障害対応
                }
            }
            #endregion

            #region ●BLコード

            //--------------------
            // BLコード
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName)
            {
                int blCode = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                if (blCode != 0)
                {
                    if (this._stockSlipInputAcs.StockDetailBLGoodsInfoSetting(stockRowNo, blCode))
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
                        this._stockDetailDataTable[cell.Row.Index].BLGoodsCode = this._beforeBLGoodsCode;

                        this._afterCellUpdateCancel = true;
                        return;
                    }
                }
                else
                {
                    // BLコード関連の情報をクリア
                    this._stockSlipInputAcs.StockDetailBLGoodsInfoClear(stockRowNo);
                }
            }
            #endregion

            #region ●仕入率
            //--------------------
            // 仕入率
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.StockRateColumn.ColumnName)
            {
                double newStockRate = TStrConv.StrToDoubleDef(e.Cell.Value.ToString(), 0);

                #region 単価チェック

                string errMsg = string.Empty;
                StockSlipInputAcs.CheckResult checkResult = this._stockSlipInputAcs.StockUnitPriceCheck(stockRowNo, 1, out errMsg);

                if (checkResult != StockSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == StockSlipInputAcs.CheckResult.Error)
                    {
                        this._stockDetailDataTable[rowIndex].StockRate = this._beforeStockRate;
                        this._afterCellUpdateCancel = true;
                        return;
                    }
                }

                #endregion

                // ----------ADD 2013/01/07----------->>>>>
                // 更新時 数量=0 AND 単価=0 AND 金額<>0 AND 仕入返品予定機能=0(する)の場合、金額計算しない
                if (this._stockDetailDataTable[rowIndex].StockSlipDtlNum != 0 &&
                    this._stockDetailDataTable[rowIndex].StockCountDisplay == 0 &&
                    this._stockDetailDataTable[rowIndex].StockUnitPriceDisplay == 0 && 
                    this._stockDetailDataTable[rowIndex].StockPriceDisplay != 0 )
                {
                    // 金額計算しない
                } 
                else
                {
                // ----------ADD 2013/01/07-----------<<<<<

                    // 仕入明細データセッティング処理（単価設定）
                    this._stockSlipInputAcs.StockDetailRowStockUnitPriceSettingbyRate(stockRowNo, this._stockDetailDataTable[rowIndex].StockRate);
                }  // ADD 2013/01/07

                settingStockRowNoList.Add(stockRowNo);
                reCalcStockPrice = true;
            }
            #endregion

            #region ●定価
            //--------------------
            // 定価
            //--------------------
            else if (cell.Column.Key == this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName)
            {
                double newListPriceDisplay = TStrConv.StrToDoubleDef(e.Cell.Value.ToString(), 0);

                #region 定価チェック区分による定価・単価チェック

                string errMsg = string.Empty;
                StockSlipInputAcs.CheckResult checkResult = this._stockSlipInputAcs.ListPriceCheck(stockRowNo, out errMsg);

                if (checkResult != StockSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == StockSlipInputAcs.CheckResult.Error)
                    {
                        this._stockDetailDataTable[rowIndex].ListPriceDisplay = this._beforeListPriceDisplay;
                        this._afterCellUpdateCancel = true;
                        return;
                    }
                }


                #endregion

                // 仕入明細データセッティング処理（定価設定）
                this._stockSlipInputAcs.StockDetailListPriceSetting(stockRowNo, StockSlipInputAcs.PriceInputType.PriceDisplay, this._stockDetailDataTable[rowIndex].ListPriceDisplay);

                // 仕入率が入力されている場合は単価再計算
                if (this._stockDetailDataTable[rowIndex].StockRate != 0)
                {
                    // 仕入明細データセッティング処理（単価設定）
                    this._stockSlipInputAcs.StockDetailRowStockUnitPriceSettingbyRate(stockRowNo, this._stockDetailDataTable[rowIndex].StockRate);

                    settingStockRowNoList.Add(stockRowNo);
                    reCalcStockPrice = true;
                }
            }
            #endregion

            #region ●得意先
            else if (cell.Column.Key == this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName)
            {
                int customerCode = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                if (customerCode != 0)
                {
                    CustomerInfo customerInfo;
                    if (this._customerInfoAcs == null)
                    {
                        this._customerInfoAcs = new CustomerInfoAcs();
                        this._customerInfoAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
                    }
                    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, true, out customerInfo);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._stockSlipInputAcs.StockDetailSalesCustomerInfoSetting(stockRowNo, customerInfo);

                        // 得意先変更イベントコール
                        this.StockDetailCustomerChangeCall(stockRowNo, customerInfo);
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先コード [" + customerCode.ToString() + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // 得意先コードを元に戻す
                        this._stockDetailDataTable[cell.Row.Index].SalesCustomerCode = this._beforeSalesCustomerCode;

                        this._afterCellUpdateCancel = true;
                        return;
                    }
                }
                else
                {
                    // 得意先名称設定処理
                    this._stockSlipInputAcs.StockDetailSalesCustomerInfoSetting(stockRowNo, new CustomerInfo());

                    // 得意先変更イベントコール
                    this.StockDetailCustomerChangeCall(stockRowNo, new CustomerInfo());
                }
            }
			#endregion

            #region ●得意先（売上同時入力）
#if false
            else if (cell.Column.Key == this._stockDetailDataTable.CustomerCodeColumn.ColumnName)
            {
                int customerCode = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                if (customerCode != 0)
                {
                    CustomerInfo customerInfo;
                    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, true, out customerInfo);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._stockSlipInputAcs.SetCustomerInfo(stockRowNo, customerInfo);

                        //// 得意先変更イベントコール
                        //this.StockDetailCustomerChangeCall(stockRowNo, customerInfo);
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先コード [" + customerCode.ToString() + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // 得意先コードを元に戻す
                        this._stockDetailDataTable[cell.Row.Index].CustomerCode = this._beforeCustomerCode;

                        this._afterCellUpdateCancel = true;
                    }
                }
            }
#endif
            #endregion

            // 仕入金額調整
            if (adjustStockPrice)
            {
                this._stockSlipInputAcs.AdjustStockPriceSignBasedOnRowIndex(rowIndex);
            }

            // 仕入金額計算処理
			if (reCalcStockPrice)
			{
				this._stockSlipInputAcs.CalculateStockPriceBasedOnRowIndex(rowIndex);

				// 仕入金額変更後発生イベントコール処理
				this.StockPriceChangedEventCall();
			}

			this.uGrid_Details.BeginUpdate();
			// 明細グリッド・行単位でのセル設定
			this.SettingGridRow(rowIndex, this._stockSlipInputAcs.StockSlip);
			this.uGrid_Details.EndUpdate();

			// 売上データ(仕入同時計上)調整
			this._stockSlipInputAcs.SalesTempRowAdjust(stockRowNo);

			// フッタ部明細情報更新イベントコール処理
			this.SettingFooterEventCall(this._stockDetailDataTable[cell.Row.Index].StockRowNo);

			// データ変更フラグプロパティをTrueにする
			this._stockSlipInputAcs.IsDataChanged = true;
		}

        // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------>>>>>
        /// <summary>
        /// 単価背景色設定(明細表示グリッド)
        /// </summary>
        /// <param name="rowIndex">rowIndex</param>
        /// <param name="stockRowNo">stockRowNo</param>
        /// <remarks>
        /// <br>Note		: 単価背景色設定を行いします。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2012/10/15</br>
        /// <br>管理番号    : 10801804-00、2012/11/14配信分</br>
        /// </remarks>
        private void DetailGridSalesUnitPriceColorSetting(int rowIndex, int stockRowNo)
        {
            bool ret = true;

            StockInputDataSet.StockDetailRow row = this._stockSlipInputAcs.GetStockDetailRow(stockRowNo);
            if ((row != null) && (row.StockUnitPriceDisplay != 0))
            {
                //仕入明細データ（仕入履歴明細データ）.変更前単価 ≠ 画面単価
                if (row.StockUnitPriceDisplay != row.BfStockUnitPriceFl)
                    ret = false;
            }
            if (ret == false)
            {
                //単価背景色設定
                this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName].Appearance.BackColor = _CellReadOnlyColor2;
                this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName].Appearance.BackColor2 = _CellReadOnlyColor2;
            }
        }

        /// <summary>
        /// 定価背景色設定(明細表示グリッド)
        /// </summary>
        /// <param name="rowIndex">rowIndex</param>
        /// <param name="stockRowNo">stockRowNo</param>
        /// <remarks>
        /// <br>Note		: 定価背景色設定を行いします。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2012/10/15</br>
        /// <br>管理番号    : 10801804-00、2012/11/14配信分</br>
        /// </remarks>
        private void DetailGridListPriceColorSetting(int rowIndex, int stockRowNo)
        {
            bool ret = true;

            StockInputDataSet.StockDetailRow row = this._stockSlipInputAcs.GetStockDetailRow(stockRowNo);
            if ((row != null) && (row.ListPriceDisplay != 0))
            {
                //仕入明細データ（仕入履歴明細データ）.変更前定価 ≠ 画面定価
                if (row.ListPriceDisplay != row.BfListPrice)
                    ret = false;

            }

            if (ret == false)
            {
                //定価背景色設定
                this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName].Appearance.BackColor = _CellReadOnlyColor2;
                this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName].Appearance.BackColor2 = _CellReadOnlyColor2;
            }
        }
        // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------<<<<<

		/// <summary>
		/// グリッドセルアクティブ化前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note : 2012/06/15 tianjw</br>
        /// <br>管理番号    : 10801804-00 2012/07/25配信分</br>
        /// <br>              Redmine#30517 品名未入力行の不具合の対応</br>
        /// </remarks>
		private void uGrid_Details_BeforeCellActivate( object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e )
		{
		
			// 項目に従いIMEモード設定
			this.uGrid_Details.ImeMode = uiSetControl1.GetSettingImeMode(e.Cell.Column.Key);

			// ゼロ詰め解除実行
			if (e.Cell.Column.DataType == typeof(string) && e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
			{
				if (e.Cell.Value != null)
				{
					this._stockDetailDataTable.Rows[e.Cell.Row.Index][e.Cell.Column.Key] = uiSetControl1.GetZeroPadCanceledText(e.Cell.Column.Key, (string)this._stockDetailDataTable.Rows[e.Cell.Row.Index][e.Cell.Column.Key]);
				}
			}

            // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //-----------------------------------------------------------------------------
            // NoEdit項目のアクティブ状態の文字色指定
            //-----------------------------------------------------------------------------
            e.Cell.Band.Override.ActiveCellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

            #region 現在庫数
            if (e.Cell.Column.Key == this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName)
            {
                if (string.IsNullOrEmpty(this._stockDetailDataTable[e.Cell.Row.Index].WarehouseCode.Trim()))
                {
                    e.Cell.Band.Override.ActiveCellAppearance.ForeColor = Color.Transparent;
                }
            }
            #endregion
            // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // ----- ADD 2012/06/15 tianjw Redmine#30517 -------------------------------------------->>>>>
            if (e.Cell.Column.Key == this._stockDetailDataTable.GoodsNameColumn.ColumnName)
            {
                this._prevGoodsName = e.Cell.Value.ToString(); // 前回入力品名を格納する。
            }
            // ----- ADD 2012/06/15 tianjw Redmine#30517 --------------------------------------------<<<<<

			this._beforeCell = e.Cell;
		}

        // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// uGrid_Details_BeforeSelectChange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeSelectChange(object sender, Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs e)
        {
            #region 現在庫数
            Infragistics.Win.UltraWinGrid.UltraGridCell cellShipmentPosCnt = this.uGrid_Details.ActiveRow.Cells[this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName];
            if (string.IsNullOrEmpty(this._stockDetailDataTable[uGrid_Details.ActiveRow.Index].WarehouseCode.Trim()))
            {
                cellShipmentPosCnt.SelectedAppearance.ForeColor = Color.Transparent;
                cellShipmentPosCnt.SelectedAppearance.ForeColorDisabled = Color.Transparent;
            }
            else
            {
                cellShipmentPosCnt.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                cellShipmentPosCnt.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
            }
            #endregion
        }
        // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
						this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName];

						//if (( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
						//    ( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ) ||
						//    ( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_TotalInput ))
						if (( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
							( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))

						{
							// 次入力可能セル移動処理
							this.MoveNextAllowEditCell(true);
						}
					}
				}
			}

			//if (( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
			//    ( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ) ||
			//    ( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_TotalInput ))
			if (( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
				( this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
			{
				if (this.uGrid_Details.ActiveCell != null)
				{
					if (( !this.uGrid_Details.ActiveCell.IsInEditMode ) && ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) && ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
					{
						this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
					}
					else
					{
						// 次入力可能セル移動処理
						this.MoveNextAllowEditCell(true);
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
			if (cell.Column.Key == this._stockDetailDataTable.GoodsNoColumn.ColumnName)
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
                    this.StatusBarMessageSetting(this, string.Empty);
				}
			}

			// セルアクティブ時ボタン有効無効コントロール処理
			this.ActiveCellButtonEnabledControl(cell.Row.Index, cell.Column.Key);

			this.SettingFooterEventCall();

			// 横スクロールバー位置設定
			if (cell.Column.Key == this._stockDetailDataTable.GoodsNoColumn.ColumnName)
			{
				this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
			}

			this._cannotGoodsRead = false;
			this._beforeCellUpdateCancel = false;
            this._afterCellUpdateCancel = false;
			
			//if (this.uGrid_Details.ActiveRow != null)
			//    this.SettingFooter(this.GetActiveRowStockRowNo());
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
			this.SettingFooterEventCall(this.GetActiveRowStockRowNo());

			this.uButton_Guide.Enabled = false;
            // ---ADD 2011/07/18------------>>>>>
            if (this._stockSlipInputInitDataAcs.GetAllDefSet().DtlCalcStckCntDsp == 1)
            {
                // 在庫調整
                this._stockSlipInputAcs.StockDetailStockInfoAdjust();
            }
            else
            {
                //なし
            }
            // ---ADD 2011/07/18------------<<<<<
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
					if (string.IsNullOrEmpty(editorBase.CurrentEditText.Trim()))
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
		/// グリッド 列位置、幅変更後イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uGrid_Details_AfterColPosChanged( object sender, Infragistics.Win.UltraWinGrid.AfterColPosChangedEventArgs e )
		{
			if (this.uGrid_Details.Focused)
			{
				// 列表示状態クラスリスト構築処理
				List<ColDisplayStatusExp> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Details.DisplayLayout.Bands[0].Columns);

				bool saveHidden = ( this._displayType == DisplayType.Normal ) ? true : false;

				this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList, saveHidden);
			}
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
                if (( this._stockSlipInputAcs.StockSlip == null ) || ( this._stockSlipInputAcs.StockSlip.StockGoodsCd > 1 )) return;

				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;

                if (cell.Column.Key == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
                {
                    cell.Appearance.Cursor = Cursors.Default;
                    string tipString = this._stockSlipInputAcs.CreateStockCountInfoString(this._stockDetailDataTable[cell.Row.Index].StockRowNo);

                    if (!string.IsNullOrEmpty(tipString))
                    {
                        cell.Appearance.Cursor = Cursors.Help;

                        Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = this.uToolTipManager_Information.GetUltraToolTip(this.uGrid_Details);
                        if (ultraToolTipInfo != null)
                        {
                            ultraToolTipInfo.ToolTipTitle = "数量情報";
                            ultraToolTipInfo.ToolTipText = tipString;
                            this.uToolTipManager_Information.Enabled = true;
                        }
                    }
                    else
                    {
                        this.uToolTipManager_Information.Enabled = false;
                        this.uToolTipManager_Information.HideToolTip();
                    }

                    this.uToolTipManager_Hint.Enabled = false;
                    this.uToolTipManager_Hint.HideToolTip();
                }
                else
                {
                    this.uToolTipManager_Information.Enabled = false;
                    this.uToolTipManager_Information.HideToolTip();

                    this.uToolTipManager_Hint.Enabled = false;
                    this.uToolTipManager_Hint.HideToolTip();
                }
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
		/// セルボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			this._stockDetailDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = e.Cell.Row.Index;
			if (rowIndex == -1) return;

			// 仕入先入力チェック処理
			bool customerCodeCheck = this.CheckCustomerCodeInput();

			if (!customerCodeCheck)
			{
				return;
			}

			// 仕入行番号を取得
			int stockRowNo = this._stockDetailDataTable[rowIndex].StockRowNo;

			#region ●商品ガイド
			#endregion
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
                this.StatusBarMessageSetting(this, string.Empty);
            }
            if (( this._beforeCell != null ) && ( this._beforeCell.Row.Index >= 0 ))
            {
                if (this._beforeCell.Column.DataType == typeof(string) && this._beforeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // ゼロ詰め実行
                    this._stockDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key] = uiSetControl1.GetZeroPaddedText(this._beforeCell.Column.Key, (string)this._stockDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key]);
                }
            }
        }

		/// <summary>
		/// 挿入ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowInsert_Click(object sender, EventArgs e)
		{
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
            }
			this._stockDetailDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;

            string message;
            bool judge = this._stockSlipInputAcs.InsertStockDetailRowCheck(out message);
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
                this._stockSlipInputAcs.InsertStockDetailRow(rowIndex);

				// 明細グリッドセル設定処理
				this.SettingGrid();

                // 在庫調整数量調整
                this._stockSlipInputAcs.StockDetailStockInfoAdjust();

				// 次入力可能セル移動処理
				this.MoveNextAllowEditCell(true);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}

            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
		}

		/// <summary>
		/// 削除ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowDelete_Click(object sender, EventArgs e)
		{
			this._stockDetailDataTable.AcceptChanges();

			// 選択済み仕入行番号リスト取得処理
			List<int> selectedStockRowNoList = this.GetSelectedStockRowNoList();
			if ((selectedStockRowNoList == null) || (selectedStockRowNoList.Count == 0))
			{
				return;
			}

			string message;
			bool exist = this._stockSlipInputAcs.DeleteStockDetailRowCheck(selectedStockRowNoList, out message);

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

			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"選択行を削除してもよろしいですか？",
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

				//if (this._stockSlipInputAcs.StockSlip.TrustAddUpSpCd == 1)
				//{
				//    // 仕入明細行削除処理
				//    this._stockSlipInputAcs.DeleteStockDetailRow(selectedStockRowNoList, true);
				//}
				//else
				//{
				//    // 仕入明細行削除処理
				//    this._stockSlipInputAcs.DeleteStockDetailRow(selectedStockRowNoList, false);
				//}
				// 仕入明細行削除処理
				this._stockSlipInputAcs.DeleteStockDetailRow(selectedStockRowNoList, false);

				// 明細グリッドセル設定処理
				this.SettingGrid();

				if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.Rows.Count > rowIndex))
				{
					this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName];

					if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
						(this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
					{
						this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
					}
				}

				// 次入力可能セル移動処理
				this.MoveNextAllowEditCell(true);

				// 在庫調整数量調整
				this._stockSlipInputAcs.StockDetailStockInfoAdjust();

				// 仕入金額変更後発生イベントコール処理
				this.StockPriceChangedEventCall();

				// データ変更フラグプロパティをTrueにする
				this._stockSlipInputAcs.IsDataChanged = true;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// 切り取りボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCut_Click(object sender, EventArgs e)
		{
			this._stockDetailDataTable.AcceptChanges();

			// 選択済み仕入行番号リスト取得処理
			List<int> selectedStockRowNoList = this.GetSelectedStockRowNoList();
			if (selectedStockRowNoList == null) return;

			// 仕入明細データテーブルRowStatus列初期化処理
			this._stockSlipInputAcs.InitializeStockDetailRowStatusColumn();

			// 仕入明細データテーブルRowStatus列値設定処理
			this._stockSlipInputAcs.SetStockDetailRowStatusColumn(selectedStockRowNoList, StockSlipInputAcs.ctROWSTATUS_CUT);

			// 明細グリッドセル設定処理
			this.SettingGrid();

			// 次入力可能セル移動処理
			this.MoveNextAllowEditCell(true);
		}

		/// <summary>
		/// コピーボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowCopy_Click(object sender, EventArgs e)
		{
			this._stockDetailDataTable.AcceptChanges();

			// 選択済み仕入行番号リスト取得処理
			List<int> selectedStockRowNoList = this.GetSelectedStockRowNoList();
			if (selectedStockRowNoList == null) return;

			// 仕入明細データテーブルRowStatus列初期化処理
			this._stockSlipInputAcs.InitializeStockDetailRowStatusColumn();

			// 仕入明細データテーブルRowStatus列値設定処理
			this._stockSlipInputAcs.SetStockDetailRowStatusColumn(selectedStockRowNoList, StockSlipInputAcs.ctROWSTATUS_COPY);

			// 明細グリッドセル設定処理
			this.SettingGrid();

			// 次入力可能セル移動処理
			this.MoveNextAllowEditCell(true);
		}

		/// <summary>
		/// 貼り付けボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RowPaste_Click(object sender, EventArgs e)
		{
            try
            {
                this._stockDetailDataTable.AcceptChanges();

                // ActiveRowインデックス取得処理
                int rowIndex = this.GetActiveRowIndex();
                if (rowIndex == -1) return;

                // コピー仕入明細行番号取得処理
                List<int> copyStockRowNoList = this._stockSlipInputAcs.GetCopyStockDetailRowNo();
                if (copyStockRowNoList == null) return;

                int pasteCheck = this._stockSlipInputAcs.CheckPasteStockDetailRow(copyStockRowNoList, rowIndex);

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
                this._stockSlipInputAcs.PasteStockDetailRow(copyStockRowNoList, rowIndex);

                // 明細グリッドセル設定処理
                this.SettingGrid();

                // 在庫調整
                this._stockSlipInputAcs.StockDetailStockInfoAdjust();

                // 仕入金額変更後発生イベントコール処理
                this.StockPriceChangedEventCall();

                // 次入力可能セル移動処理
                this.MoveNextAllowEditCell(true);

                // 表示行数取得処理
                int afterVisibleRowCount = this.GetVisibleRowCount();

                // 表示する行数が減った場合、調整する
                if (afterVisibleRowCount < prevVisibleRowCount)
                {
                    for (int i = afterVisibleRowCount; i < prevVisibleRowCount; i++)
                    {
                        this._stockSlipInputAcs.AddStockDetailRow();
                    }

                    // 明細グリッドセル設定処理
                    this.SettingGrid();
                }

                // セルの編集モードを一度解除し、再度編集モードに設定する
                this.CellExitEnterEditEnter();

                // 在庫調整
                this._stockSlipInputAcs.StockDetailStockInfoAdjust();

                // データ変更フラグプロパティをTrueにする
                this._stockSlipInputAcs.IsDataChanged = true;
            }
            finally
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
            }
		}

		/// <summary>
		/// ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note : 2015/08/26 cheq </br>
        /// <br>管理番号    : 11170129-00</br>
        /// <br>            : redmine#47008 メーカー名称の値がメーカーコードになるの障害対応</br>
        /// </remarks> 
		private void uButton_Guide_Click(object sender, EventArgs e)
		{
			this._stockDetailDataTable.AcceptChanges();

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;

			// 仕入先入力チェック処理
			bool customerCodeCheck = this.CheckCustomerCodeInput();

			if (!customerCodeCheck)
			{
				return;
			}

			if (this.uButton_Guide.Tag == null) return;

			// 仕入行番号を取得
			int stockRowNo = this._stockDetailDataTable[rowIndex].StockRowNo;

			#region ●得意先ガイド
			//---------------------
			// 得意先ガイド
			//---------------------
			if (this.uButton_Guide.Tag.ToString() == this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName)
			{
				PMKHN04001UA customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04001UA.EXECUTEMODE_GUIDE_AND_EDIT);
				customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
				customerSearchForm.ShowDialog(this);
			}
			#endregion

			#region ●倉庫ガイド
			//---------------------
			// 倉庫ガイド
			//---------------------
			else if (this.uButton_Guide.Tag.ToString() == this._stockDetailDataTable.WarehouseCodeColumn.ColumnName)
			{
                string warehouseCode = this._stockDetailDataTable[rowIndex].WarehouseCode;
                string goodsNo = this._stockDetailDataTable[rowIndex].GoodsNo;
                int goodsMakerCd = this._stockDetailDataTable[rowIndex].GoodsMakerCd;
                Stock retStock;

                MAZAI04117U goodsStockGuide = new MAZAI04117U();

                DialogResult dialogResult = goodsStockGuide.ShowGuide(this, this._enterpriseCode, goodsNo, goodsMakerCd, out retStock);

                if ( dialogResult == DialogResult.OK )
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                    // 在庫情報設定処理
                    this._stockSlipInputAcs.StockDetailRowStockSetting(stockRowNo, retStock);

                    // 変更前倉庫の在庫調整
                    this._stockSlipInputAcs.StockDetailStockInfoAdjust(warehouseCode, goodsNo, goodsMakerCd);

                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                    // データ変更フラグプロパティをTrueにする
                    this._stockSlipInputAcs.IsDataChanged = true;

                    // 売上データ(仕入同時計上)調整
                    this._stockSlipInputAcs.SalesTempRowAdjust(stockRowNo);

                }
			}
			#endregion

			#region ●BLコードガイド
			//---------------------
			// BLコードガイド
			//---------------------
			else if ( this.uButton_Guide.Tag.ToString() == this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName )
			{
				BLGoodsCdAcs blGoodsCdAcs = new BLGoodsCdAcs();
				
				BLGoodsCdUMnt blGoodsCdUMnt;

				int status = blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
					// BLコード名称設定処理
                    this._stockSlipInputAcs.StockDetailBLGoodsInfoSetting(stockRowNo, blGoodsCdUMnt);

					// データ変更フラグプロパティをTrueにする
					this._stockSlipInputAcs.IsDataChanged = true;

					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

					// 売上データ(仕入同時計上)調整
					this._stockSlipInputAcs.SalesTempRowAdjust(stockRowNo);
				}
			}
			#endregion

			#region ●メーカーガイド
			//---------------------
			// メーカーガイド
			//---------------------
			else if ( this.uButton_Guide.Tag.ToString() == this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName )
			{
				int beforeMakerCd = this._stockDetailDataTable[rowIndex].GoodsMakerCd;
				string beforeMakerName = this._stockDetailDataTable[rowIndex].MakerName;
                string beforeMakerKanaName = this._stockDetailDataTable[rowIndex].MakerKanaName;

				MakerAcs makerAcs = new MakerAcs();
				makerAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

				MakerUMnt makerUMnt;

				int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

					// メーカー名称設定処理
                    bool isMakerChanged;
                    this._stockSlipInputAcs.StockDetailMakerInfoSetting(stockRowNo, makerUMnt.GoodsMakerCd, makerUMnt.MakerName, makerUMnt.MakerKanaName, out isMakerChanged);

					string goodsNo = this._stockDetailDataTable[rowIndex].GoodsNo;

					// メーカーが変わった場合は商品を再検索
                    if (( isMakerChanged ) && ( !String.IsNullOrEmpty(goodsNo) ))
					{
						switch (this.SearchGoodsAndRemain_And_RowSetting(rowIndex))
						{
							case 0:
								break;
							case -1:
                                this._stockSlipInputAcs.StockDetailMakerInfoSetting(stockRowNo, beforeMakerCd, beforeMakerName, beforeMakerKanaName);
								break;
						}
					}

					// 仕入金額計算処理
					this._stockSlipInputAcs.CalculateStockPriceBasedOnRowIndex(rowIndex);

					// 仕入金額変更後発生イベントコール処理
					this.StockPriceChangedEventCall();

					// データ変更フラグプロパティをTrueにする
					this._stockSlipInputAcs.IsDataChanged = true;

                    //---DEL 2015/08/26 cheq for #Redmine47008 メーカー名称の値がメーカーコードになるの障害対応 --------------->>>>>
                    //if (this.uGrid_Details.ActiveCell.Column.Key == this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName)
                    //{
                    //    this._stockDetailDataTable[rowIndex].MakerName = this._stockDetailDataTable[rowIndex].GoodsMakerCd.ToString();
                    //}
                    //---DEL 2015/08/26 cheq for #Redmine47008 メーカー名称の値がメーカーコードになるの障害対応 ---------------<<<<<

					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}
			}
			#endregion

			#region ●単価ガイド
			//---------------------
			// 単価ガイド
			//---------------------
			else if ( this.uButton_Guide.Tag.ToString() == this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName )
			{
				DCKHN01050UA unitPriceInfoGuide = new DCKHN01050UA();

				//DialogResult dialogResult = unitPriceInfoGuide.ShowDialog(this, DCKHN01050UA.DisplayType.PriceTaxExc, this._stockSlipInputAcs.GetUnitPriceInfoConf(stockRowNo));
				StockTtlSt stockTtlSt = this._stockSlipInputInitDataAcs.GetStockTtlSt();
				//DialogResult dialogResult = unitPriceInfoGuide.ShowDialog(this, DCKHN01050UA.DisplayType.UnitCost, this._stockSlipInputAcs.GetUnitPriceInfoConf(stockRowNo), ( stockTtlSt.UnitPriceInpDiv == 0 ) ? false : true);
                DialogResult dialogResult = unitPriceInfoGuide.ShowDialog(this, DCKHN01050UA.DisplayType.UnitCost, this._stockSlipInputAcs.GetUnitPriceInfoConf(stockRowNo));

				if (dialogResult == DialogResult.OK)
				{
					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

					this._stockSlipInputAcs.StockDetailRowUnPrcInfoSetting(stockRowNo, unitPriceInfoGuide.UnPrcInfoConfRet);

					// 仕入金額計算処理
					this._stockSlipInputAcs.CalculateStockPriceBasedOnRowIndex(rowIndex);

					// 仕入金額変更後発生イベントコール処理
					this.StockPriceChangedEventCall();

					this._stockSlipInputAcs.IsDataChanged = true;

					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}
			}
			#endregion
		}

		/// <summary>
		/// 得意先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
		private void CustomerSearchForm_CustomerSelect( object sender, CustomerSearchRet customerSearchRet )
		{
			if (customerSearchRet == null) return;

			// 仕入先設定処理
			this.DetailCustomerSet(customerSearchRet);
		}

		/// <summary>
		/// 得意先設定処理
		/// </summary>
		/// <param name="customerSearchRet"></param>
		private void DetailCustomerSet( CustomerSearchRet customerSearchRet )
		{
			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;
			// 仕入行番号を取得
			int stockRowNo = this._stockDetailDataTable[rowIndex].StockRowNo;

			this.Cursor = Cursors.WaitCursor;
			CustomerInfo customerInfo;
            if (this._customerInfoAcs == null)
            {
                this._customerInfoAcs = new CustomerInfoAcs();
                this._customerInfoAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
            }
			int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);//ddd
			this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                this._stockSlipInputAcs.StockDetailSalesCustomerInfoSetting(stockRowNo, customerInfo);

				if (this.uGrid_Details.ActiveCell.Column.Key == this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName)
				{
                    //this._stockDetailDataTable[rowIndex].SalesCustomerSnm = customerInfo.CustomerCode.ToString();//DEL BY 凌小青 on 2011/12/16 for Redmine#26856
                    this._stockDetailDataTable[rowIndex].SalesCustomerSnm = customerInfo.CustomerSnm.Trim();//ADD BY 凌小青 on 2011/12/16 for Redmine#26856
				}

				this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

				// 得意先変更イベントコール
				this.StockDetailCustomerChangeCall(stockRowNo, new CustomerInfo());
			}
		}


		/// <summary>
		/// 在庫検索ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_StockSearch_Click(object sender, EventArgs e)
		{
            try
            {
                this._stockDetailDataTable.AcceptChanges();

                // ActiveRowインデックス取得処理
                int rowIndex = this.GetActiveRowIndex();
                if (rowIndex == -1) return;

                // 仕入先入力チェック処理
                bool customerCodeCheck = this.CheckCustomerCodeInput();

                if (!customerCodeCheck)
                {
                    return;
                }

                // 仕入行番号を取得
                int stockRowNo = this._stockDetailDataTable[rowIndex].StockRowNo;

                // メーカーコード／商品コードを取得
                string goodsNo = this._stockDetailDataTable[rowIndex].GoodsNo;
                int goodsMakerCd = this._stockDetailDataTable[rowIndex].GoodsMakerCd;

                // 在庫検索ガイドを起動
                object retObj;
                StockSearchGuide stockSearchGuide = new StockSearchGuide();
                stockSearchGuide.IsMultiSelect = true;
                StockSearchPara para = new StockSearchPara();
                para.EnterpriseCode = this._enterpriseCode;
                para.SectionCode = this._stockSlipInputAcs.StockSlip.StockSectionCd;
                para.WarehouseCode = this._stockSlipInputAcs.StockSlip.WarehouseCode;

                DialogResult dialogResult = stockSearchGuide.ShowGuide(this, StockSearchGuide.emSearchMode.GoodsStock, false, para, out retObj);

                if (dialogResult == DialogResult.OK)
                {
                    List<Stock> stockList = retObj as List<Stock>;

                    if (( stockList != null ) && ( stockList.Count > 0 ))
                    {
                        #region ●明細へのデータ展開

                        List<Stock> addStockList = new List<Stock>();

                        int addRowCount = this.uGrid_Details.Rows.Count - this._stockSlipInputAcs.GetAlreadyInputRowCount();
                        foreach (Stock stock in stockList)
                        {
                            addStockList.Add(stock);

                            addRowCount--;
                            if (addRowCount == 0)
                                break;
                        }

                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
                        foreach (Stock ret in addStockList)
                        {
                            GoodsCndtn goodsCndtn = new GoodsCndtn();
                            goodsCndtn.EnterpriseCode = this._enterpriseCode;
                            goodsCndtn.GoodsNo = ret.GoodsNo;
                            goodsCndtn.GoodsMakerCd = ret.GoodsMakerCd;
                            goodsCndtnList.Add(goodsCndtn);
                        }

                        //List<GoodsUnitData> goodsUnitDataList = this._stockSlipInputInitDataAcs.CreateGoodsUnitDataList(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, goodsCndtnList);
                        string errMgs;
                        List<GoodsUnitData> goodsUnitDataList;
                        int status = this._stockSlipInputInitDataAcs.GetGoodsUnitDataList(goodsCndtnList, out goodsUnitDataList, out errMgs);

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {

                            // 商品マスタ情報設定処理
                            List<int> settingStockRowNoList;
                            //int lastInputStockRow = this._stockSlipInputAcs.GetLastInputStockRowNo();
                            //this._stockSlipInputAcs.StockDetailRowGoodsSettingBasedOnStock(lastInputStockRow + 1, goodsUnitDataList, stockList, out settingStockRowNoList, false);
                            this._stockSlipInputAcs.StockDetailRowGoodsSettingBasedOnStock(1, goodsUnitDataList, addStockList, out settingStockRowNoList, false);
                            

                            // 明細グリッド設定処理
                            this.SettingGrid();

                            // 最終行に空行を追加
                            this.AddLastEmptyRow();

                            // 在庫調整
                            this._stockSlipInputAcs.StockDetailStockInfoAdjust();

                            // データ変更フラグプロパティをTrueにする
                            this._stockSlipInputAcs.IsDataChanged = true;

                            // 仕入金額計算処理
                            this.CalculationStockPrice(settingStockRowNoList);

                            // 仕入金額変更後発生イベントコール処理
                            this.StockPriceChangedEventCall();

                            //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            TMsgDisp.Show(
                                       this,
                                       emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       this.Name,
                                       "商品検索に失敗しました。" + Environment.NewLine + "ST=" + status.ToString() + Environment.NewLine + errMgs,
                                       -1,
                                       MessageBoxButtons.OK);
                        }

                        #endregion
                    }
                }
            }
            finally
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
		}

        /// <summary>
        /// 仕入履歴ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_StockReference_Click( object sender, EventArgs e )
        {
            this._stockDetailDataTable.AcceptChanges();

            // 仕入先入力チェック処理
            bool customerCodeCheck = this.CheckCustomerCodeInput();
            if (!customerCodeCheck) return;
            
			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;

			List<StcHisRefDataWork> stcHisRefDataWorkList = new List<StcHisRefDataWork>();
			List<StcHisRefDataWork> addStcHisRefDataWorkList = new List<StcHisRefDataWork>();
			List<int> settingStockRowNoList = new List<int>();
            DCKOU04101UA stockHisGuide = new DCKOU04101UA();
			stockHisGuide.IsMultiSelect = true;                                                 // 複数選択
            stockHisGuide.SectionCode = this._stockSlipInputAcs.StockSlip.StockSectionCd;       // 仕入拠点
            stockHisGuide.SectionName = this._stockSlipInputAcs.StockSlip.StockSectionNm;       // 仕入拠点名称
            stockHisGuide.SupplierCd = this._stockSlipInputAcs.StockSlip.SupplierCd;
            stockHisGuide.SupplierName = this._stockSlipInputAcs.StockSlip.SupplierSnm;
            stockHisGuide.MaxSelectCount = this.uGrid_Details.Rows.Count - this._stockSlipInputAcs.GetAlreadyInputRowCount();
            DialogResult dialogResult = stockHisGuide.ShowDialog(this, 0);
            if (dialogResult == DialogResult.OK)
			{
				#region ●明細へのデータ展開

				stcHisRefDataWorkList = stockHisGuide.stcHisRefDataWork;

				if (stcHisRefDataWorkList.Count > 0)
				{
                    bool isDefferentSuuplierFomral = false;
                    bool isTotalInput = false;
					// 伝票区分違いのデータを除くリストを作成する
					foreach (StcHisRefDataWork stcHisRefDataWork in stcHisRefDataWorkList)
					{
                        if (stcHisRefDataWork.StockGoodsCd == 6)
                        {
                            isTotalInput = true;
                        }
                        else if (this._stockSlipInputAcs.StockSlip.SupplierSlipCd != stcHisRefDataWork.SupplierSlipCd)
                        {
                            isDefferentSuuplierFomral = true;
                        }
                        else
                        {
                            addStcHisRefDataWorkList.Add(stcHisRefDataWork);
                        }
					}

					if (stcHisRefDataWorkList.Count != addStcHisRefDataWorkList.Count)
					{
                        string message = string.Empty;
                        if (isDefferentSuuplierFomral) message += "伝票区分が異なるデータ";
                        if (isTotalInput)
                        {
                            if (!string.IsNullOrEmpty(message)) message += "、";
                            message += "合計入力データ";
                        }
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            message + "は展開されませんでした。",
                            0,
                            MessageBoxButtons.OK);
					}

					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

					int lastInputStockRow = this._stockSlipInputAcs.GetLastInputStockRowNo();

					int status = this._stockSlipInputAcs.StockDetailRowSettingFromstcHisRefDataWorkList(lastInputStockRow + 1, addStcHisRefDataWorkList, StockSlipInputAcs.WayToDetailExpand.Normal, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);

					// 明細グリッド設定処理
					this.SettingGrid();

					// 最終行に空行を追加
					this.AddLastEmptyRow();

                    // 在庫調整数量調整
                    this._stockSlipInputAcs.StockDetailStockInfoAdjust();

					// データ変更フラグプロパティをTrueにする
					this._stockSlipInputAcs.IsDataChanged = true;

					// フッタ部明細情報更新イベントコール処理
					this.SettingFooterEventCall(this._stockDetailDataTable[rowIndex].StockRowNo);

					// 仕入金額変更後発生イベントコール処理
					this.StockPriceChangedEventCall();

					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}
				#endregion
			}

        }

        /// <summary>
        /// 入荷履歴ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_ArrivalReference_Click( object sender, EventArgs e )
        {
            this._stockDetailDataTable.AcceptChanges();

            // 仕入先入力チェック処理
            bool customerCodeCheck = this.CheckCustomerCodeInput();

            if (!customerCodeCheck)return;

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;

            List<StcHisRefDataWork> retstcHisRefDataWorkList = new List<StcHisRefDataWork>();
			List<StcHisRefDataWork> addstcHisRefDataWorkList = new List<StcHisRefDataWork>();
			List<int> settingStockRowNoList = new List<int>();
			DCKOU04101UA stockHisGuide = new DCKOU04101UA();
			stockHisGuide.IsMultiSelect = true;
            stockHisGuide.SectionCode = this._stockSlipInputAcs.StockSlip.StockSectionCd;
            stockHisGuide.SectionName= this._stockSlipInputAcs.StockSlip.StockSectionNm;
            stockHisGuide.SupplierCd = this._stockSlipInputAcs.StockSlip.SupplierCd;
            stockHisGuide.SupplierName= this._stockSlipInputAcs.StockSlip.SupplierSnm;
            stockHisGuide.MaxSelectCount = this.uGrid_Details.Rows.Count - this._stockSlipInputAcs.GetAlreadyInputRowCount();

            DialogResult dialogResult = stockHisGuide.ShowDialog(this, 1);

            if (dialogResult == DialogResult.OK)
			{
				#region ●明細へのデータ展開

				retstcHisRefDataWorkList = stockHisGuide.stcHisRefDataWork;

				if (retstcHisRefDataWorkList.Count > 0)
				{
					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                    bool isDefferentSuuplierFomral = false;
                    bool isTotalInput = false;

					// 残が０のデータを除くリストを作成する
					foreach (StcHisRefDataWork stcHisRefDataWork in retstcHisRefDataWorkList)
					{
                        if (stcHisRefDataWork.SupplierSlipCd != this._stockSlipInputAcs.StockSlip.SupplierSlipCd)
                        {
                            isDefferentSuuplierFomral = true;
                        }
                        else if (stcHisRefDataWork.StockGoodsCd == 6)
                        {
                            isTotalInput = true;
                        }
                        else
                        {
                            addstcHisRefDataWorkList.Add(stcHisRefDataWork);
                        }
					}
					if (retstcHisRefDataWorkList.Count != addstcHisRefDataWorkList.Count)
					{
                        string message = string.Empty;
                        if (isDefferentSuuplierFomral) message += "伝票区分が異なるデータ";
                        if (isTotalInput)
                        {
                            if (!string.IsNullOrEmpty(message)) message += "、";
                            message += "合計入力データ";
                        }

                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_INFO,
                             this.Name,
                             message + "は展開されませんでした。",
                             0,
                             MessageBoxButtons.OK);
                    }
					int lastInputStockRow = this._stockSlipInputAcs.GetLastInputStockRowNo();
					this._stockSlipInputAcs.StockDetailRowSettingFromstcHisRefDataWorkList(lastInputStockRow + 1, addstcHisRefDataWorkList, StockSlipInputAcs.WayToDetailExpand.AddUp, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);

					// 明細グリッド設定処理
					this.SettingGrid();

					// 最終行に空行を追加
					this.AddLastEmptyRow();

                    // 在庫調整数量調整
                    this._stockSlipInputAcs.StockDetailStockInfoAdjust();

					// データ変更フラグプロパティをTrueにする
					this._stockSlipInputAcs.IsDataChanged = true;

					// フッタ部明細情報更新イベントコール処理
					this.SettingFooterEventCall(this._stockDetailDataTable[rowIndex].StockRowNo);

					// 仕入金額変更後発生イベントコール処理
					this.StockPriceChangedEventCall();

					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}

                #endregion
            }
        }

		/// <summary>
		/// 発注履歴ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_OrderReference_Click( object sender, EventArgs e )
		{
			this._stockDetailDataTable.AcceptChanges();

			// 仕入先入力チェック処理
			bool customerCodeCheck = this.CheckCustomerCodeInput();

			if (!customerCodeCheck) return;

			// ActiveRowインデックス取得処理
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex == -1) return;

			DCHAT04110UA orderHisGuide = new DCHAT04110UA();
			orderHisGuide.IsMultiSelect = true;
			orderHisGuide.IsCacheClear = true;
			List<OrderListResultWork> retOrderListResultWorkList = new List<OrderListResultWork>();
			List<OrderListResultWork> addOrderListResultWorkList = new List<OrderListResultWork>();
			List<int> settingStockRowNoList = new List<int>();
            orderHisGuide.MaxSelectCount = this.uGrid_Details.Rows.Count - this._stockSlipInputAcs.GetAlreadyInputRowCount();


			DialogResult dialogResult = orderHisGuide.ShowDialog(this, DCHAT04110UA.DisplayType.DisplayAndSelect, this._stockSlipInputAcs.StockSlip.SupplierCd);

			if (dialogResult == DialogResult.OK)
			{
				#region ●明細へのデータ展開

				retOrderListResultWorkList = orderHisGuide.orderListResultWorkList;

				if (retOrderListResultWorkList.Count > 0)
				{
					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

					// 残が０のデータを除くリストを作成する
					foreach (OrderListResultWork orderListResultWork in retOrderListResultWorkList)
					{
						if (orderListResultWork.OrderRemainCnt != 0)
						{
							addOrderListResultWorkList.Add(orderListResultWork);
						}
					}
					if (retOrderListResultWorkList.Count != addOrderListResultWorkList.Count)
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"発注残が０のデータは展開されません。",
							0,
							MessageBoxButtons.OK);
					}

					int lastInputStockRow = this._stockSlipInputAcs.GetLastInputStockRowNo();
					int readStatus = this._stockSlipInputAcs.StockDetailRowSettingFromOrderListResultWorkList(lastInputStockRow + 1, addOrderListResultWorkList,StockSlipInputAcs.WayToDetailExpand.AddUp, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);

                    //if (( readStatus == -999 ) && ( wayToDetailExpand == StockSlipInputAcs.WayToDetailExpand.AddUpAndSync ))
                    //{
                    //    TMsgDisp.Show(
                    //        this,
                    //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    //        this.Name,
                    //        "発注と同時入力したデータは展開されませんでした。",
                    //        0,
                    //        MessageBoxButtons.OK);
                    //}
						
					// 明細グリッド設定処理
					this.SettingGrid();

					// 最終行に空行を追加
					this.AddLastEmptyRow();

                    // 在庫調整数量調整
                    this._stockSlipInputAcs.StockDetailStockInfoAdjust();

					// データ変更フラグプロパティをTrueにする
					this._stockSlipInputAcs.IsDataChanged = true;

					// フッタ部明細情報更新イベントコール処理
					this.SettingFooterEventCall(this._stockDetailDataTable[rowIndex].StockRowNo);

					// 仕入金額変更後発生イベントコール処理
					this.StockPriceChangedEventCall();

					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}
				#endregion
			}
		}

        /// <summary>
        /// 行値引きボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note : 2012/06/15 tianjw</br>
        /// <br>管理番号    : 10801804-00 2012/07/25配信分</br>
        /// <br>              Redmine#30517 品名未入力行の不具合の対応</br>
        /// </remarks>
        private void uButton_RowDiscount_Click( object sender, EventArgs e )
        {
            try
            {
                // 仕入先入力チェック処理
                bool customerCodeCheck = this.CheckCustomerCodeInput();

                if (!customerCodeCheck)
                {
                    return;
                }
                // ActiveRowインデックス取得処理
                int rowIndex = this.GetActiveRowIndex();
                if (rowIndex == -1) return;

                int stockRowNo = this._stockDetailDataTable[rowIndex].StockRowNo;

                List<int> checkStockRowNoList = new List<int>();
                checkStockRowNoList.Add(stockRowNo);
                int pasteCheck = this._stockSlipInputAcs.CheckPasteStockDetailRow(checkStockRowNoList, rowIndex);

                if (pasteCheck == 1)
                {
                    DialogResult checkDialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "対象行に商品が入力されています。" + "\r\n" + "\r\n" +
                        "上書きされますが、よろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (checkDialogResult != DialogResult.Yes)
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
                        "対象行に編集不可商品が存在するため、選択できません。",
                        0,
                        MessageBoxButtons.OK);

                    return;
                }
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                this._stockDetailDataTable.AcceptChanges();

                // 在庫情報のみクリア
                this._stockSlipInputAcs.StockDetailRowClearStockInfo(stockRowNo);

                // 行値引情報をセット
                this._stockSlipInputAcs.StockDetailRowDiscountSetting(stockRowNo);
                this._prevGoodsName = this._stockDetailDataTable[rowIndex].GoodsName; // 前回入力品名を格納する。// ADD 2012/06/15 tianjw Redmine#30517
                this.SettingGrid();
                this.MoveNextAllowEditCell(true);
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                // 仕入金額計算処理
                this.CalculationStockPrice(stockRowNo);

                // 在庫調整
                this._stockSlipInputAcs.StockDetailStockInfoAdjust();

                // 最終行に空行を追加
                this.AddLastEmptyRow();

                // 明細グリッドセル設定処理
                this.SettingGrid();

                // データ変更フラグプロパティをTrueにする
                this._stockSlipInputAcs.IsDataChanged = true;
            }
            finally
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
		}

		/// <summary>
		/// 商品値引ボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_GoodsDiscount_Click( object sender, EventArgs e )
		{
            try
            {
                // 仕入先入力チェック処理
                bool customerCodeCheck = this.CheckCustomerCodeInput();

                if (!customerCodeCheck)
                {
                    return;
                }
                // ActiveRowインデックス取得処理
                int rowIndex = this.GetActiveRowIndex();
                if (rowIndex == -1) return;

                int stockRowNo = this._stockDetailDataTable[rowIndex].StockRowNo;

                List<int> checkStockRowNoList = new List<int>();
                checkStockRowNoList.Add(stockRowNo);
                int pasteCheck = this._stockSlipInputAcs.CheckPasteStockDetailRow(checkStockRowNoList, rowIndex);

                if (pasteCheck == 1)
                {
                    DialogResult checkDialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "対象行に商品が入力されています。" + "\r\n" + "\r\n" +
                        "上書きされますが、よろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (checkDialogResult != DialogResult.Yes)
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
                        "対象行に編集不可商品が存在するため、選択できません。",
                        0,
                        MessageBoxButtons.OK);

                    if (this.uGrid_Details.ActiveCell != null)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                    return;
                }

                this._stockDetailDataTable.AcceptChanges();

                // 行値引情報をセット
                this._stockSlipInputAcs.StockDetailGoodsDiscountSetting(stockRowNo);
                this.SettingGrid();
                //this.MoveNextAllowEditCell(true);

                if (!this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Hidden)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName].Selected = true;
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._stockDetailDataTable.GoodsNoColumn.ColumnName];
                }

                // 仕入金額計算処理
                this.CalculationStockPrice(stockRowNo);

                // 在庫調整
                this._stockSlipInputAcs.StockDetailStockInfoAdjust();

                // 最終行に空行を追加
                this.AddLastEmptyRow();

                // 明細グリッドセル設定処理
                this.SettingGrid();

                // データ変更フラグプロパティをTrueにする
                this._stockSlipInputAcs.IsDataChanged = true;
            }
            finally
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
                }
            }
		}

		/// <summary>
		/// 入力切替ボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_InputChange_Click( object sender, EventArgs e )
		{
			this._displayType = ( this._displayType == DisplayType.Normal ) ? DisplayType.SalesInput : DisplayType.Normal;

			this.SettingGridColVisible(StatusType.InputChange, (int)this._displayType);
		}

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
        /// 行値引ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowDiscount_EnabledChanged( object sender, EventArgs e )
        {
            this._rowDiscountButton.SharedProps.Enabled = ( (Infragistics.Win.Misc.UltraButton)sender ).Enabled;
        }

		/// <summary>
		/// 商品値引ボタンEnabled変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_GoodsDiscount_EnabledChanged( object sender, EventArgs e )
		{
			//this._goodsDiscountButton.SharedProps.Enabled = ( (Infragistics.Win.Misc.UltraButton)sender ).Enabled;
		}


        #endregion

        /// <summary>
		/// ツールバーツールクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
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
				// 行値引き
				case "ButtonTool_RowDiscount":
					{
						this.uButton_RowDiscount_Click(this.uButton_RowDiscount, new EventArgs());
						break;
					}
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

		# endregion

	}
}
