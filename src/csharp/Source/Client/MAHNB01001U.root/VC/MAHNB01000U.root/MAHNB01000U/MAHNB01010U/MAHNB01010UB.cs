using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上入力明細入力コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の明細入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 20056 對馬　大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 對馬 大輔 新規作成</br>
    /// <br>2009.07.14 22018 鈴木 正臣 MANTIS[0013803] 在庫検索ボタンで在庫照会表示時に自動的に検索しないよう変更。</br>
    /// <br>2009.07.15 22018 鈴木 正臣 MANTIS[0013801] ＢＬコードガイドの初期表示モードを設定可能に変更。</br>
    /// <br>2009/09/04 20056 對馬 大輔 1.無効要素のバックカラー設定に項目追加</br>
    /// <br>                           2.品番検索後のフォーカス制御で品名がセットされているときの制御追加</br>
    /// <br>2009/09/09 20056 對馬 大輔 MANTIS[0014258] 保存後、続けて入力した場合のフォーカス位置を修正</br>
    /// <br>2009/09/10 20056 對馬 大輔 MANTIS[0014172] 計上時の発注は、受注計上時のみ可能とする</br>
    /// <br>Update Note  : 2009/09/08 張凱</br>
    /// <br>               PM.NS-2-A・車輌管理</br>
    /// <br>               車種変更ボタンの対応</br>
    /// <br></br>
    /// <br>Update Note : 2009/10/19 張凱</br>
    /// <br>              PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>              PM.NS保守依頼②を追加</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/18 鈴木正臣</br>
    /// <br>              MANTIS[0014656] （表示区分）標準価格選択ＵＩで選択後に売価が表示されない不具合の修正</br>
    /// <br>Update Note : 2009/11/24 張凱 保守依頼③対応</br>
    /// <br>              売価率、売単価の入力チェックを追加</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/25 21024 佐々木 健</br>
    /// <br>              ・検索ＢＬコードを複数選択・セット子部品選択時も正しく取得できるように修正(MANTIS[0014690])</br>
    /// <br>Update Note : 2009/12/17 對馬 大輔 保守依頼③対応</br>
    /// <br>             MANTIS[14785] BLコードガイドから標準価格選択を行った場合も選択した標準価格を有効にする</br>
    /// <br>             MANTIS[14756] 既存修正時、伝票タイプの明細数に従い明細数を制限する</br>
    /// <br>             MANTIS[14755] 伝票修正時でも、追加明細は印刷用品番をセットするように変更</br>
    /// <br>             MANTIS[14717] 標準価格選択で選択した価格を売価へ反映するように変更</br>
    /// <br>Update Note : 2009/12/23 張凱</br>
    /// <br>              PM.NS-5-A・PM.NS保守依頼④</br>
    /// <br>              PM.NS保守依頼④を追加</br>
    /// <br></br>
    /// <br>Update Note : 2010/01/14 對馬 大輔 障害対応</br>
    /// <br>             MANTIS[14717] 標準価格選択で選択した場合、掛率算出した売価を標準価格で上書きしてしまう件の対応</br>
    /// <br>Update Note : 2010/01/27 張凱 ４次改良対応</br>
    /// <br>              PM.NS保守依頼４次改良対応を追加</br>
    /// <br>Update Note : 2010/01/28 對馬 大輔 障害対応</br>
    /// <br>             MANTIS[14961] 用品入力した伝票を修正呼出し、品名を変更した場合の不具合修正</br>
    /// <br>Update Note : 2010/02/08 對馬 大輔 障害対応</br>
    /// <br>             MANTIS[14977] 修正呼出で品名を修正した場合、修正した品名が伝票に印字されない不具合修正</br>
    /// <br>Update Note : 2010/02/22 對馬 大輔 障害対応</br>
    /// <br>             MANTIS[15013] 注釈行で売価率・売単価ゼロチェックを行わないように変更</br>   
    /// <br>Update Note : 2010/02/26 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note : 2010/03/16 張凱 障害対応</br>
    /// <br>             redmin#3852 品名未入力時のフォーカス制御の変更(保守依頼４)　仕様変更修正</br>
    /// <br>Update Note : 2010/03/22 李侠 障害対応</br>
    /// <br>             redmin#4075 原価計算処理の不具合対応　仕様変更修正</br>
    /// <br>Update Note : 2010/03/31 對馬 大輔 障害対応</br>
    /// <br>             MANTIS[15236] BLコードガイドにて複数選択した場合、選択したコード全てで検索するように修正</br>   
    /// <br>Update Note : 2010/04/14 鈴木 正臣</br>
    /// <br>             MANTIS[15284] 品名が入力変更された時、品名カナにはＵＩ上の品名を半角変換してセットするよう変更</br>
    /// <br>Update Note : 2010/04/27 對馬 大輔 </br>
    /// <br>              差分組込対応</br>
    /// <br>Update Note : 2010/04/28 20056 對馬 大輔</br>
    /// <br>              検索速度アップ対応</br>
    /// <br>Update Note : 2010/05/04 王海立 PM1007・6次改良</br>
    /// <br>              発行者チェック、入力倉庫チェック等処理を追加</br>
    /// <br>Update Note : 2010/05/20 姜凱</br>
    /// <br>            : Redmine#7774の入力倉庫チェック処理、発注処理を対応</br>
    /// <br>Update Note : 2010/06/26 李占川 </br>
    /// <br>              BLコード変換処理のロジックの削除</br>
    /// <br>Update Note : 2010/06/09　20056 對馬 大輔</br>
    /// <br>              仕入先変更時、数量が固定で再セットされる不具合対応</br>   
    /// <br>Update Note: 2010/07/21 20056 對馬 大輔 </br>
    /// <br>             用品入力で品名・メーカー変更時の明細情報クリア処理変更(一部内容をクリアしない)</br>
    /// <br>UpdateNote : 2011/07/06 譚洪 Redmine#22774 キャンペーンにヒットして売価が算出された場合(売価≠0)、色が変わるの対応</br>
    /// <br>Update Note: 2012/10/04 脇田 靖之</br>
    /// <br>             伝票種別が貸出の場合の"前行複写"、"一括複写"の障害を修正</br>
    /// </remarks>
    public partial class MAHNB01010UB : UserControl
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private ControlScreenSkin _controlScreenSkin;
        private ImageList _imageList16 = null;									// イメージリスト
        private SalesSlipInputAcs _salesSlipInputAcs;
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private SalesInputDataSet.SalesDetailDataTable _salesDetailDataTable;
        private SalesInputDataSet.CompleteInfoDataTable _completeInfoDataTable;
        private SalesSlipInputConstructionAcs _salesInputConstructionAcs;
        private SalesSlipStockInfoInputAcs _salesSlipStockInfoInputAcs;
        private SupplierAcs _supplierAcs;
        private UOESupplierAcs _uoeSupplierAcs;
        private UOEGuideNameAcs _uoeGuideNameAcs;
        private UserGuideAcs _userGuideAcs;
        private DateGetAcs _dateGetAcs;
        private Image _guideButtonImage;
        private SalesDetailRowVisibleControl _salesDetailRowVisibleControl = new SalesDetailRowVisibleControl();
        private int _verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _beforeGoodsNo = string.Empty;
        private long _beforeSalesMoney = 0;
        private long _beforeCost = 0;
        private string _beforeWarehouseCode = string.Empty;
        private double _beforeShipmentCnt = 0;
        private double _beforeAcptAnOdrCnt = 0;
        private int _beforeGoodsMakerCd = 0;
        private int _beforeSupplierCd = 0;
        private int _beforeBLGoodsCode = 0;
        private string _beforeGoodsName = string.Empty;
        private double _beforeListPrice = 0;
        private double _beforeSalesUnitCost = 0;
        private double _beforeCostRate = 0;
        private double _beforeSalesUnitPrice = 0;
        private double _beforeSalesRate = 0;
        private string _beforeUOEDeliGoodsDiv = string.Empty;
        private string _beforeFollowDeliGoodsDiv = string.Empty;
        private string _beforeUOEResvdSection = string.Empty;
        private int _beforeUOESupplierCd = 0;
        private string _beforeBoCode = string.Empty;
        private double _beforeAcptAnOdrCntForOrder = 0;
        private int _beforeSalesCode = 0;
        //>>>2010/02/26
        private int _beforeRecycleDiv = 0;
        private int _beforeGoodsMngNo = 0;
        //<<<2010/02/26
        private bool _cannotGoodsRead = false;
        private bool _cannotGoodsMakerRead = false;
        private bool _cannotSupplierInfoRead = false;
        private bool _cannotBLGoodsRead = false;
        private bool _cannotListPrice = false;
        private bool _cannotSalesUnitCost = false;
        private bool _cannotCostRate = false;
        private bool _cannotSalesUnitPrice = false;
        private bool _cannotSalesRate = false;
        private bool _cannotUOEDeliGoodsDiv = false;
        private bool _cannotFollowDeligoodsDiv = false;
        private bool _cannotUOESupplierCd = false;
        private bool _cannotBoCode = false;
        private bool _cannotUOEResvdSection = false;
        private bool _cannotSalesCode = false;
        //>>>2010/02/26
        private bool _cannotRecycleDiv = false;
        //<<<2010/02/26

        private List<Control> _detailButtonControlList; // 明細ボタンコントロールリスト

        private bool _beforeCellUpdateCancel = false; // BeforeCellUpdateイベントでの入力エラー判定用
        private bool _isOverFlow = false;
        private ColDisplayStatusList _colDisplayStatusList;	// 列表示状態コレクションクラス
        private bool _firstEnter = true;

        private Infragistics.Win.UltraWinGrid.UltraGridCell _beforeCell;
        private Int32 _InputType = 0; // 0:通常入力 1:切替入力
        private Hashtable _upperBerth; // 上段項目テーブル
        private Hashtable _lowerBerth; // 下段項目テーブル
        private Dictionary<string, EnterMoveValue> _enterMoveTable; // 移動先テーブル(key:対象項目 value:移動先情報)
        private Dictionary<string, EnterMoveValue> _enterMoveTableInit; // 初期設定移動先テーブル(key:対象項目 value:移動先項目)
        private string _startKeyName;
        private string _startKeyNameInit;
        private ArrayList _endKeyNameList;
        private ArrayList _endKeyNameListInit;
        private ArrayList _effectiveList;
        private ArrayList _specialKeyNameList;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowInsertButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDeleteButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCutButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCopyButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowPasteButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowSpreadButton;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _inputChangeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _lineDiscountButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _annotationButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _salesReferenceButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _shipmentReferenceButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _acceptAnOrderReferenceButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _estimateReferenceButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchChangeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _newCompleteButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _addCompleteButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _delCompleteButton;
        private Infragistics.Win.UltraWinToolbars.PopupMenuTool _popupMenuTool_Complete;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _inputOrderInfo;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _inputStockInfo;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _goodsDiscountButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _tboButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _changeCarInfoButton;
        //>>>2010/02/26
        private Infragistics.Win.UltraWinToolbars.ButtonTool _SCM;
        //<<<2010/02/26

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト

        # endregion
        
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constroctors
        /// <summary>
        /// 売上入力明細入力コントロールクラス デフォルトコンストラクタ
        /// </summary>
        /// <param name="opeCtrl">操作権限制御オブジェクト</param>
        public MAHNB01010UB(IOperationAuthority opeCtrl)
        {
            InitializeComponent();

            // 変数初期化
            this._rowInsertButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowInsert"];
            this._rowDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowDelete"];
            this._rowCutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCut"];
            this._rowCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCopy"];
            this._rowPasteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowPaste"];
            this._rowSpreadButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowSpread"];

            this._controlScreenSkin = new ControlScreenSkin();

            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
            this._salesSlipStockInfoInputAcs = SalesSlipStockInfoInputAcs.GetInstance();
            this._salesDetailDataTable = this._salesSlipInputAcs.SalesDetailDataTable;
            this._completeInfoDataTable = this._salesSlipInputAcs.CompleteInfoDataTable;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this._salesInputConstructionAcs = SalesSlipInputConstructionAcs.GetInstance();

            this._inputChangeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_InputChange"]; // 入力切替
            this._lineDiscountButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_LineDiscount"]; // 行値引き
            this._annotationButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Annotation"]; // 注釈
            this._salesReferenceButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_SalesReference"]; // 売上照会
            this._shipmentReferenceButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_ShipmentReference"]; // 出荷照会
            this._acceptAnOrderReferenceButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_AcceptAnOrderReference"]; // 受注照会
            this._estimateReferenceButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_EstimateReference"]; // 見積照会
            this._searchChangeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_SearchChange"]; // 検索切替

            this._newCompleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_NewComplete"];
            this._addCompleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_AddComplete"];
            this._delCompleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_DelComplete"];

            this._popupMenuTool_Complete = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Complete"];

            this._goodsDiscountButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_GoodsDiscount"];
            this._tboButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_TBO"];
            this._changeCarInfoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_ChangeCarInfo"];

            this._inputOrderInfo = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_InputOrderInfo"];
            this._inputStockInfo = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_InputStockInfo"];
            //>>>2010/02/26
            this._SCM = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_SCM"];
            //<<<2010/02/26

            this._salesInputConstructionAcs.DataChanged += new EventHandler(this.SalesInputConstructionAcs_DataChanged);

            this._InputType = 0;
            this._upperBerth = new Hashtable(); // 上段テーブル
            this._lowerBerth = new Hashtable(); // 下段テーブル
            this._enterMoveTable = new Dictionary<string,EnterMoveValue>(); // 移動先テーブル
            this._enterMoveTableInit = new Dictionary<string,EnterMoveValue>(); // 初期設定移動先テーブル

            this._supplierAcs = new SupplierAcs();
            this._supplierAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
            this._uoeSupplierAcs = new UOESupplierAcs();
            this._uoeGuideNameAcs = new UOEGuideNameAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();

            //this._startKeyName = this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName;
            //this._startKeyNameInit = this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName;
            this._startKeyName = this._salesDetailDataTable.GoodsNoColumn.ColumnName;
            this._startKeyNameInit = this._salesDetailDataTable.GoodsNoColumn.ColumnName;
            this._endKeyNameList = new ArrayList();
            this._endKeyNameList.Add(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName);
            this._endKeyNameList.Add(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName);
            // --- ADD 2010/01/27 -------------->>>>>
            this._endKeyNameList.Add(this._salesDetailDataTable.DtlNoteColumn.ColumnName);
            // --- ADD 2010/01/27 --------------<<<<<
            this._endKeyNameList.Add(this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName);
            this._endKeyNameList.Add(this._salesDetailDataTable.SlipMemoExistColumn.ColumnName);
            this._endKeyNameList.Add(this._salesDetailDataTable.SupplierSlipExistColumn.ColumnName);
            this._endKeyNameList.Add(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName);
            this._endKeyNameList.Add(this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName);
            this._endKeyNameList.Add(this._salesDetailDataTable.GoodsMngNoColumn.ColumnName); // 2010/02/26
            this._endKeyNameListInit = new ArrayList();
            this._endKeyNameListInit.Add(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName);
            this._endKeyNameListInit.Add(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName);
            this._endKeyNameListInit.Add(this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName);
            this._endKeyNameListInit.Add(this._salesDetailDataTable.SlipMemoExistColumn.ColumnName);
            this._endKeyNameListInit.Add(this._salesDetailDataTable.SupplierSlipExistColumn.ColumnName);
            this._endKeyNameListInit.Add(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName);
            this._endKeyNameListInit.Add(this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName);
            this._endKeyNameListInit.Add(this._salesDetailDataTable.GoodsMngNoColumn.ColumnName); // 2010/02/26

            this._specialKeyNameList = new ArrayList();
            this._specialKeyNameList.Add(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName);

            this._effectiveList = new ArrayList();
            this._effectiveList.Add(this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName);               // BLコード
            this._effectiveList.Add(this._salesDetailDataTable.GoodsNameColumn.ColumnName);                 // 品名
            this._effectiveList.Add(this._salesDetailDataTable.GoodsNoColumn.ColumnName);                   // 品番
            this._effectiveList.Add(this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName);             // 商品属性(純正優良)
            this._effectiveList.Add(this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName);              // メーカー
            this._effectiveList.Add(this._salesDetailDataTable.SupplierCdColumn.ColumnName);                // 仕入先
            this._effectiveList.Add(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName);   // 受注数
            this._effectiveList.Add(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName);        // 出荷数
            this._effectiveList.Add(this._salesDetailDataTable.SalesCodeColumn.ColumnName);                 // 販売区分
            this._effectiveList.Add(this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName);          // 定価
            this._effectiveList.Add(this._salesDetailDataTable.CostRateColumn.ColumnName);                  // 原価率
            this._effectiveList.Add(this._salesDetailDataTable.SalesUnitCostColumn.ColumnName);             // 原価単価
            this._effectiveList.Add(this._salesDetailDataTable.SalesRateColumn.ColumnName);                 // 売価率
            this._effectiveList.Add(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName);         // 売上単価
            this._effectiveList.Add(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName);         // 売上金額
            this._effectiveList.Add(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName);             // 倉庫

            // 売上明細データテーブル列表示設定クラスセッティング処理
            this.SettingSalesDetailRowVisibleControl();

            this._detailButtonControlList = new List<Control>();
            this._detailButtonControlList.Add(this.uButton_InputChange);
            this._detailButtonControlList.Add(this.uButton_InputStockInfo);
            this._detailButtonControlList.Add(this.uButton_SCM); // 2010/02/26
            this._detailButtonControlList.Add(this.uButton_InputOrderInfo);
            this._detailButtonControlList.Add(this.uButton_LineDiscount);
            this._detailButtonControlList.Add(this.uButton_GoodsDiscount);
            this._detailButtonControlList.Add(this.uButton_Annotation);
            this._detailButtonControlList.Add(this.uButton_ChangeCarInfo);
            this._detailButtonControlList.Add(this.uButton_StockSearch);
            this._detailButtonControlList.Add(this.uButton_ChangeWarehouse);
            this._detailButtonControlList.Add(this.uButton_CopyStockBefLine);
            this._detailButtonControlList.Add(this.uButton_CopyStockAllLine);
            
            this._operationAuthority = opeCtrl;
        }
        # endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region Const Members
        internal static readonly string ct_ITEM_NAME_CUSTOMERCODE = "CustomerCode";
        internal static readonly string ct_ITEM_NAME_CARMNGCODE = "CarMngCode";
        internal static readonly string ct_ITEM_NAME_SALESDETAIL = "SalesDetail";
        internal const int ct_SettingActiveCell_ShipmentCntError = 1;
        internal const int ct_SettingActiveCell_AcptAnOdrCntError = 2;
        internal const int ct_SettingActiveCell_SalesUnitPriceError = 3;
        internal const int ct_SettingActiveCell_SalesUnitCostError = 4;
        internal const int ct_SettingActiveCell_ListPriceError = 5;
        internal const int ct_SettingActiveCell_SalesMoneyError = 6;
        internal const int ct_SettingActiveCell_CostError = 7;
        internal const int ct_SettingActiveCell_SalesRateError = 8;
        internal const int ct_SettingActiveCell_BLGoodsCdError = 9;
        internal const int ct_SettingActiveCell_GoodsMakerCdError = 10;
        internal const int ct_SettingActiveCell_SupplierCdError = 11;
        internal const int ct_SettingActiveCell_GoodsName = 12;
        internal const int ct_SettingActiveCell_DeliveredGoodsDiv = 13;
        internal const int ct_SettingActiveCell_FollowDeliGoodsDiv = 14;
        internal const int ct_SettingActiveCell_UOEResvdSection = 15;

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ct_ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ct_ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color ct_REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color ct_MINUS_FONT_COLOR = Color.Red;
        private static readonly Color ct_GOODSDISCOUNT_CELL_COLOR = Color.Pink;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        private static readonly Color ct_ALLWAYS_CELL_COLOR = Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));

        private static readonly Color ct_MARGIN_LESS_COLOR = Color.Orchid;
        private static readonly Color ct_MARGIN_NORMAL_COLOR = Color.Gainsboro;
        private static readonly Color ct_MARGIN_OVER_COLOR = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));

        private static readonly Color ct_UNITPRICE_NORMAL_COLOR = Color.Gainsboro;
        private static readonly Color ct_UNITPRICE_CHANGE_COLOR = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));

        private static readonly Color ct_STOCK_BACKCOLOR = Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(192)))), ((int)(((byte)(48)))));
        private static readonly Color ct_STOCK_BACKCOLOR2 = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(97)))), ((int)(((byte)(25)))));
        private static readonly Color ct_ORDER_BACKCOLOR = Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(120)))), ((int)(((byte)(216)))));
        private static readonly Color ct_ORDER_BACKCOLOR2 = Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(49)))), ((int)(((byte)(168)))));
        //>>>2010/02/26
        private static readonly Color ct_SCM_BACKCOLOR = Color.PaleVioletRed;
        private static readonly Color ct_SCM_BACKCOLOR2 = Color.Crimson;
        //<<<2010/02/26

        private static readonly Color ct_REV_FORECOLOR = System.Drawing.SystemColors.ControlText;


        private const string ct_FILENAME_COLDISPLAYSTATUS = "MAHNB01010U_ColSetting.DAT";				// 列表示状態セッティングXMLファイル名
        private const string MESSAGE_GoodsCode = "前方一致検索：最後に*を入力[例:A*]";
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
        /// フッタ部明細情報設定デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="row"></param>
        internal delegate void SettingFooterEventHandler(object sender, Int32 salesRowNo);

        /// <summary>
        /// ツールバーボタン制御デリゲート
        /// </summary>
        internal delegate void SettingToolbarEventHandler();

        /// <summary>
        /// 残検索デリゲート
        /// </summary>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="makerCode">検索結果</param>
        /// <returns></returns>
        private delegate int RemainSearchProc(GoodsUnitData goodsUnitData, out object retObj);

        /// <summary>
        /// 車両情報設定デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesRowNo"></param>
        internal delegate void SettingCarInfoEventHandler(object sender, Int32 salesRowNo);

        /// <summary>
        /// Visible設定デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesRowNo"></param>
        internal delegate void SettingVisibleEventHandler();
        # endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region Event
        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>グリッド最下層行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownButtomRow;

        /// <summary>売上金額変更後イベント</summary>
        internal event EventHandler SalesPriceChanged;

        /// <summary>ステータスバーメッセージ表示イベント</summary>
        internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;

        /// <summary>フォーカス設定イベント</summary>
        internal event SettingFocusEventHandler FocusSetting;

        /// <summary>フッタ部明細情報設定イベント</summary>
        internal event SettingFooterEventHandler SettingFooter;

        /// <summary>ツールバー設定イベント</summary>
        internal event SettingToolbarEventHandler SetToolbarButton;

        /// <summary>車両情報設定イベント</summary>
        internal event SettingCarInfoEventHandler SettingCarInfo;

        /// <summary>Visible設定イベント</summary>
        internal event SettingVisibleEventHandler SettingVisible;
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>ガイドボタン</summary>
        internal bool GuideButtonEnabled
        {
            get { return this.uButton_Guide.Enabled; }
        }

        /// <summary>在庫検索ボタン</summary>
        internal bool StockSearchButtonEnabled
        {
            get { return this.uButton_StockSearch.Enabled; }
        }

        /// <summary>売上履歴ボタン</summary>
        internal bool SalesReferenceButtonEnabled
        {
            get { return this.uButton_SalesReference.Enabled; }
        }

        /// <summary>出荷計上ボタン</summary>
        internal bool ShipmentReferenceButtonEnabled
        {
            get { return this.uButton_ShipmentReference.Enabled; }
        }

        /// <summary>受注計上ボタン</summary>
        internal bool AcceptAnOrderReferenceButtonEnabled
        {
            get { return this.uButton_AcceptAnOrderReference.Enabled; }
        }

        /// <summary>見積計上ボタン</summary>
        internal bool EstimateReferenceButtonEnabled
        {
            get { return this.uButton_EstimateReference.Enabled; }
        }

        /// <summary>検索切替ボタン</summary>
        internal bool SearchChangeButtonEnabled
        {
            get { return this.uButton_SearchChange.Enabled; }
        }

        /// <summary>操作権限の制御オブジェクト</summary>
        internal IOperationAuthority MyOpeCtrl
        {
            get { return _operationAuthority; }
        }

        // 2009/09/09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ADD
        /// <summary>初回起動フラグ</summary>
        public bool FirstEnter
        {
            set { this._firstEnter = value; }
            get { return this._firstEnter; }
        }
        // 2009/09/09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ADD
        # endregion

        // ===================================================================================== //
        // プライベート・インターナルメソッド
        // ===================================================================================== //
        # region Private Methods and Internal Methods
        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
        /// <br>Update Note: 2010/01/27 張凱 明細部の入力制御およびフォーカス制御を行う対応</br>
        /// <br>Update Note: 2010/03/16 張凱 品名未入力時のフォーカス制御の変更(保守依頼４)　仕様変更</br>
        /// <br>Update Note: 2010/05/04 王海立 セキュリティの操作権限で「単価変更」が「許可する」設定の場合、金額マイナスのチェック</br>
        /// <br>Update Note: 2010/06/02 呉元嘯 PM.NS障害・改良対応（７月リリース案件）</br>
        /// <br>             No.13注釈入力後にエンターキーで次明細を進むように修正する。現状、入力不可のＢＬコードへフォーカスが移動する。</br>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int stockRowNo = this._salesDetailDataTable[cell.Row.Index].SalesRowNo;

            this.uGrid_Details.BeginUpdate();

            try
            {

                bool canMove = true;

                if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                    (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
                {
                    canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                }
                else
                {
                    #region ●BLコード
                    //-----------------------------------------------------
                    // BLコード
                    //-----------------------------------------------------
                    if (cell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName)
                    {
                        int beforeBLGoodsCode = this._salesDetailDataTable[cell.Row.Index].BLGoodsCode;

                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._salesSlipInputAcs.SearchPartsModeProperty != SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
                                {
                                    if (this._cannotBLGoodsRead)
                                    {
                                        // BLコードの取得に失敗した場合はPerformActionを実行しない
                                        this._cannotBLGoodsRead = false;
                                    }
                                    else
                                    {
                                        canMove = this.MoveReturnCell();
                                    }
                                }
                                else
                                {
                                    if (TStrConv.StrToIntDef(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName].Text, 0) == 0)
                                    //if (this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Text == string.Empty)
                                    {
                                        // BLコードの取得に失敗した場合はPerformActionを実行しない
                                        //this._cannotBLGoodsRead = false;

                                        if (this._cannotBLGoodsRead)
                                        {
                                            // BLコードの取得に失敗した場合はPerformActionを実行しない
                                            this._cannotBLGoodsRead = false;
                                        }
                                        else
                                        {
                                            // 2009/11/18 >>>
                                            //// --- UPD 2009/10/19 ---------->>>>>
                                            //if (this._salesDetailDataTable[cell.Row.Index].BLGoodsCode != 0)
                                            //{
                                            //canMove = this.MoveReturnCell();
                                            //}
                                            //// --- UPD 2009/10/19 ----------<<<<<


                                            if (( this._salesDetailDataTable[cell.Row.Index].BLGoodsCode != 0 ) ||
                                                ( ( this._salesDetailDataTable[cell.Row.Index].BLGoodsCode == 0 ) &&
                                                  ( this._salesSlipInputInitDataAcs.GetSalesTtlSt().BLGoodsCdInpDiv == 0 ) &&
                                                  !string.IsNullOrEmpty(this._salesDetailDataTable[cell.Row.Index].GoodsName) ))
                                            {
                                                // 商品情報取得成功
                                                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay)
                                            {
                                                    case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                                                        break;
                                                    case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName];
                                                        break;
                                                    case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                                                        break;
                                                    case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                canMove = this.MoveReturnCell(true);
                                        }
                                            // 2009/11/18 <<<
                                        }
                                    }
                                    else if (beforeBLGoodsCode != this._salesDetailDataTable[cell.Row.Index].BLGoodsCode)
                                    {
                                        // 商品情報取得成功
                                        switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay)
                                        {
                                            case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                                                break;
                                            case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName];
                                                break;
                                            case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                                                break;
                                            case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                                                break;
                                            default:
                                                break;
                                        }
                                        canMove = this.MoveReturnCell(true);
                                    }
                                    else
                                    {
                                        canMove = this.MoveReturnCell();
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●品番
                    //-----------------------------------------------------
                    // 品番
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
                    {
                        string beforeGoodsNo = this._salesDetailDataTable[cell.Row.Index].GoodsNo;

                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
                        {
                            // --- DEL m.suzuki 2010/03/10 ---------->>>>>
                            //// --- ADD 2009/12/23 ---------->>>>>
                            //if (!CheckRowEffective(cell.Row.Index))
                            //{
                            //    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];

                            //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            //    return canMove;
                            //}
                            //// --- ADD 2009/12/23 ----------<<<<<
                            // --- DEL m.suzuki 2010/03/10 ----------<<<<<

                            if (string.IsNullOrEmpty(this._salesDetailDataTable[cell.Row.Index].GoodsNo))
                            {
                                if (this._cannotGoodsRead)
                                {
                                    // 商品情報の取得に失敗した場合はPerformActionを実行しない
                                    this._cannotGoodsRead = false;
                                }
                                else
                                {
                                    // --- UPD m.suzuki 2010/03/10 ---------->>>>>
                                    //canMove = this.MoveReturnCell();
                                    if ( string.IsNullOrEmpty( this._salesDetailDataTable[cell.Row.Index].GoodsName ) )
                                    {
                                        // [品名＝空白]
                                        // 品番⇒品名へ移動
                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                                        canMove = this.MoveReturnCell( true );
                                    }
                                    else
                                    {
                                        // [品名≠空白]
                                        // 品番⇒次項目へ移動
                                    canMove = this.MoveReturnCell();
                                }
                                    // --- UPD m.suzuki 2010/03/10 ----------<<<<<
                                }
                            }
                            else
                            {
                                if (this._cannotGoodsRead)
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName];
                                    this._cannotGoodsRead = false;
                                }
                                else if (TStrConv.StrToIntDef(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName].Text, 0) == 0)
                                {
                                    // --- UPD m.suzuki 2010/03/10 ---------->>>>>
                                    //// 商品情報取得失敗
                                    //this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                                    //canMove = this.MoveReturnCell(true);

                                    if ( string.IsNullOrEmpty( this._salesDetailDataTable[cell.Row.Index].GoodsName ) )
                                    {
                                        // [品名＝空白]
                                        // 品番⇒品名へ移動
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                                    canMove = this.MoveReturnCell(true);
                                }
                                    else
                                    {
                                        // [品名≠空白]
                                        // 品番⇒次項目へ移動
                                        canMove = this.MoveReturnCell();
                                    }
                                    // --- UPD m.suzuki 2010/03/10 ----------<<<<<
                                }
                                // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                else if (string.IsNullOrEmpty(this._salesDetailDataTable[cell.Row.Index].GoodsName.Trim()))
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                                    canMove = this.MoveReturnCell(true);
                                }
                                // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                else if (beforeGoodsNo != this._salesDetailDataTable[cell.Row.Index].GoodsNo)
                                {
                                    // 商品情報取得成功
                                    switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay)
                                    {
                                        case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                                            break;
                                        case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName];
                                            break;
                                        case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                                            break;
                                        case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                                            break;
                                        default:
                                            break;
                                    }
                                    canMove = this.MoveReturnCell(true);
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }

                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            }
                        }
                    }                    
                    #endregion

                    #region ●品名
                    //-----------------------------------------------------
                    // 品名
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.GoodsNameColumn.ColumnName)
                    {
                        if (cell.IsInEditMode)
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }

                        // 行値引の場合のみフォーカス直接指定
                        if (this._salesDetailDataTable[cell.Row.Index].EditStatus == SalesSlipInputAcs.ctEDITSTATUS_RowDiscount)
                        {
                            if (this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.SalesCodeColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.SalesCodeColumn.ColumnName];
                            }
                            else
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName];
                            }
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            canMove = true;
                        }
                        // --- ADD 2010/06/02 ---------->>>>>
                        // 注釈行の場合
                        else if (this._salesDetailDataTable[cell.Row.Index].EditStatus == SalesSlipInputAcs.ctEDITSTATUS_Annotation)
                        {
                            if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
                            {
                                if (this.uGrid_Details.Rows[cell.Row.Index + 1].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index + 1].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                    canMove = true;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString()))
                                    {
                                        canMove = this.MoveReturnCell();
                                    }
                                }
                            }
                            else if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
                            {
                                if (this.uGrid_Details.Rows[cell.Row.Index + 1].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index + 1].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                                    canMove = true;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString()))
                                    {
                                        canMove = this.MoveReturnCell();
                                    }
                                }
                            }
                            //---------------------------------------------
                            // 編集モードセット
                            //---------------------------------------------
                            if (this.uGrid_Details.ActiveCell != null)
                            {
                                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        // --- ADD 2010/06/02 ----------<<<<<
                        else
                        {
                            // --- UPD 2009/12/23 ---------->>>>>
                            //canMove = this.MoveReturnCell();
                            if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString()))
                            {
                                canMove = this.MoveReturnCell();
                            }
                            // --- UPD 2009/12/23 ----------<<<<<
                        }
                    }
                    #endregion

                    #region ●販売区分
                    //-----------------------------------------------------
                    // 販売区分
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.SalesCodeColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SalesCodeColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotSalesCode)
                                {
                                    this._cannotSalesCode = false;
                                }
                                else
                                {
                                    // 行値引の場合のみフォーカス直接指定
                                    if (this._salesDetailDataTable[cell.Row.Index].EditStatus == SalesSlipInputAcs.ctEDITSTATUS_RowDiscount)
                                    {
                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName];
                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        canMove = true;
                                    }
                                    else
                                    {
                                        canMove = this.MoveReturnCell();
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●出荷数
                    //-----------------------------------------------------
                    // 出荷数
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        if (this._isOverFlow)
                        {
                            this._isOverFlow = false;
                        }
                        else if (this._beforeCellUpdateCancel)
                        {
                            this._beforeCellUpdateCancel = false;
                        }
                        else
                        {
                            canMove = this.MoveReturnCell();
                        }
                    }
                    #endregion

                    #region ●受注数
                    //-----------------------------------------------------
                    // 受注数
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        if (this._isOverFlow)
                        {
                            this._isOverFlow = false;
                        }
                        else if (this._beforeCellUpdateCancel)
                        {
                            this._beforeCellUpdateCancel = false;
                        }
                        else
                        {
                            canMove = this.MoveReturnCell();

                            //switch (this._InputType)
                            //{
                            //    //-----------------------------------
                            //    // 通常入力
                            //    //-----------------------------------
                            //    case 0:
                            //        canMove = this.MoveReturnCell();
                            //        break;
                            //    //-----------------------------------
                            //    // 切替入力
                            //    //-----------------------------------
                            //    case 1:
                            //        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.DtlNoteColumn.ColumnName];
                            //        canMove = this.MoveReturnCell(true);
                            //        break;
                            //}
                        }
                    }
                    #endregion

                    #region ●メーカー
                    //-----------------------------------------------------
                    // メーカー
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotGoodsMakerRead)
                                {
                                    // メーカーの取得に失敗した場合はPerformActionを実行しない
                                    this._cannotGoodsMakerRead = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●仕入先
                    //-----------------------------------------------------
                    // 仕入先
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.SupplierCdColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SupplierCdColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotSupplierInfoRead)
                                {
                                    // 仕入先の取得に失敗した場合はPerformActionを実行しない
                                    this._cannotSupplierInfoRead = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●定価
                    //-----------------------------------------------------
                    // 定価
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotListPrice)
                                {
                                    this._cannotListPrice = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●売単価
                    //-----------------------------------------------------
                    // 売単価
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotSalesUnitPrice)
                                {
                                    this._cannotSalesUnitPrice = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●売価率
                    //-----------------------------------------------------
                    // 売価率
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotSalesRate)
                                {
                                    this._cannotSalesRate = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●原単価
                    //-----------------------------------------------------
                    // 原単価
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotSalesUnitCost)
                                {
                                    this._cannotSalesUnitCost = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●原価率
                    //-----------------------------------------------------
                    // 原価率
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.CostRateColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.CostRateColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotCostRate)
                                {
                                    this._cannotCostRate = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●売上金額
                    //-----------------------------------------------------
                    // 売上金額
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // --- ADD 2010/05/04 ---------->>>>>
                        if (this._isOverFlow)
                        {
                            this._isOverFlow = false;
                        }
                        else
                        {
                            // --- ADD 2010/05/04 ----------<<<<<

                            //-----------------------------------------------------
                            // 商品区分
                            //-----------------------------------------------------
                            switch ((SalesSlipInputAcs.SalesGoodsCd)this._salesSlipInputAcs.SalesSlip.SalesGoodsCd)
                            {
                                case SalesSlipInputAcs.SalesGoodsCd.Goods:
                                    canMove = this.MoveReturnCell();
                                    break;
                                default:
                                    int afterRowIndex = cell.Row.Index + 1;
                                    // 不正移動チェック
                                    if (afterRowIndex > this.uGrid_Details.Rows.Count - 1) afterRowIndex = cell.Row.Index;

                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName];
                                    canMove = this.MoveReturnCell(true);
                                    break;
                            }
                        }// ADD 2010/05/04
                    }                    
                    #endregion

                    #region ●ＢＯ区分
                    //-----------------------------------------------------
                    // ＢＯ区分
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotBoCode)
                                {
                                    this._cannotBoCode = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●発注先
                    //-----------------------------------------------------
                    // 発注先
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotUOESupplierCd)
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.BoCodeColumn.ColumnName];
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    this._cannotUOESupplierCd = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●発注数
                    //-----------------------------------------------------
                    // 発注数
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        if (this._isOverFlow)
                        {
                            this._isOverFlow = false;
                        }
                        else if (this._beforeCellUpdateCancel)
                        {
                            this._beforeCellUpdateCancel = false;
                        }
                        else
                        {
                            canMove = this.MoveReturnCell();
                        }
                    }
                    #endregion

                    #region ●納品区分
                    //-----------------------------------------------------
                    // 納品区分
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotUOEDeliGoodsDiv)
                                {
                                    this._cannotUOEDeliGoodsDiv = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●Ｈ納品区分
                    //-----------------------------------------------------
                    // Ｈ納品区分
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotFollowDeligoodsDiv)
                                {
                                    this._cannotFollowDeligoodsDiv = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●指定拠点
                    //-----------------------------------------------------
                    // 指定拠点
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotUOEResvdSection)
                                {
                                    this._cannotUOEResvdSection = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion

                    //>>>2010/02/26
                    #region ●RC区分
                    //-----------------------------------------------------
                    // RC区分
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.RecycleDivNmColumn.ColumnName)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.RecycleDivNmColumn.ColumnName)
                        {
                            if (this._beforeCellUpdateCancel)
                            {
                                this._beforeCellUpdateCancel = false;
                            }
                            else
                            {
                                if (this._cannotRecycleDiv)
                                {
                                    this._cannotRecycleDiv = false;
                                }
                                else
                                {
                                    canMove = this.MoveReturnCell();
                                }
                            }
                        }
                    }
                    #endregion
                    //<<<2010/02/26

                    #region ●納品完了予定日
                    //-----------------------------------------------------
                    // 納品完了予定日
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
                    {
                        bool errorFlg = false;
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
                        {
                            try
                            {
                                //>>>2010/02/26
                                //DateTime datetime = this._salesDetailDataTable[cell.Row.Index].DeliGdsCmpltDueDate;
                                string datetime = this._salesDetailDataTable[cell.Row.Index].DeliGdsCmpltDueDate;
                                //<<<2010/02/26
                            }
                            catch (Exception)
                            {
                                errorFlg = true;
                            }

                            //>>>2010/02/26
                            //if ((errorFlg) ||
                            //    (this._salesDetailDataTable[cell.Row.Index].DeliGdsCmpltDueDate == DateTime.MinValue))
                            //{
                            //    this._salesDetailDataTable[cell.Row.Index].DeliGdsCmpltDueDate = this._salesSlipInputAcs.SalesSlip.SalesDate;
                            //}
                            if ((errorFlg) ||
                                (this._salesDetailDataTable[cell.Row.Index].DeliGdsCmpltDueDate == string.Empty))
                            {
                                this._salesDetailDataTable[cell.Row.Index].DeliGdsCmpltDueDate = string.Empty;
                            }
                            //<<<2010/02/26
                            else
                            {
                                canMove = this.MoveReturnCell();
                            }
                            
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    #endregion

                    // --- ADD 2010/01/27 -------------->>>>>
                    #region ●明細備考
                    //-----------------------------------------------------
                    // 明細備考
                    //-----------------------------------------------------
                    else if (cell.Column.Key == this._salesDetailDataTable.DtlNoteColumn.ColumnName)
                    {
                        //一式明細
                        if (this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled
                            && this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.NoEdit)
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName];
                        }
                        //得意先注番
                        else if (this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled
                            && this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.NoEdit)
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName];
                        }
                        //納品完了予定日
                        else if (this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled
                            && this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.NoEdit)
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName];
                        }
                        else
                        {
                            // 次入力可能セル移動処理
                            canMove = this.MoveReturnCell();
                        }
                    }
                    #endregion ●明細備考
                    // --- ADD 2010/01/27 --------------<<<<<

                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MoveReturnCell();
                    }
                }

                return canMove;
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }

        }

        /// <summary>
        /// Returnキーセル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:次移動先算出を行わない</param>
        /// <returns></returns>
        internal bool MoveReturnCell()
        {
            return MoveReturnCell(false);
        }

        /// <summary>
        /// Returnキーセル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:次移動先算出を行わない</param>
        /// <returns></returns>
        /// <br>Update Note: 2010/01/27 張凱 明細部の入力制御およびフォーカス制御を行う対応</br>
        /// <br>Update Note: 2010/05/08 王海立 入力倉庫チェック処理の追加</br>
        internal bool MoveReturnCell(bool activeCellCheck)
        {
            try
            {
                //---------------------------------------------
                // 初期処理
                //---------------------------------------------
                // レイアウトロジック、グリッド描画停止
                this.uGrid_Details.SuspendLayout();
                this.uGrid_Details.BeginUpdate();

                //---------------------------------------------
                // セル移動不可
                //---------------------------------------------
                if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                    (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
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
                    int beforeEditStatus = this._salesDetailDataTable[beforeRowIndex].EditStatus;
                    int afterRowIndex = 0;
                    string afterColKeyName = this._startKeyName;
                    
                    //---------------------------------------------
                    // 移動先Row取得
                    //---------------------------------------------
                    if ((this._endKeyNameList.Contains(beforeColKeyName)) ||
                        ((this._specialKeyNameList.Contains(beforeColKeyName)) && (GetEffectiveJudgment(beforeColKeyName)))) // フォーカス移動無しの特殊移動項目
                    {
                        afterRowIndex = beforeRowIndex + 1;
                        // 不正移動チェック
                        if (afterRowIndex > this.uGrid_Details.Rows.Count - 1) return false;
                    }
                    else
                    {
                        afterRowIndex = beforeRowIndex;
                    }

                    //---------------------------------------------
                    // 移動先Col取得
                    //---------------------------------------------
                    this.GetNextMovePosition(beforeColKeyName, out afterColKeyName);

                    //---------------------------------------------
                    // 移動先補正
                    //---------------------------------------------
                    if (beforeRowIndex != afterRowIndex) // 次行移動の場合、補正
                    {
                        if ((beforeColKeyName != this._salesDetailDataTable.WarehouseCodeColumn.ColumnName) &&
                            (beforeColKeyName != this._salesDetailDataTable.WarehouseNameColumn.ColumnName) &&
                            (beforeColKeyName != this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName) &&
                            (beforeColKeyName != this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName))
                        {
                            switch (this._InputType)
                            {
                                case 0: // 通常入力
                                    afterColKeyName = this._startKeyName;
                                    break;
                                case 1: // 切替
                                    break;
                                case 2: // 仕入
                                    if (!((this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled) ||
                                          (this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                                          (this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].Column.Hidden == true)))
                                    {
                                        afterRowIndex = beforeRowIndex;
                                        afterColKeyName = this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName;
                                    }
                                    break;
                                case 3: // 発注
                                    if (!((this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.BoCodeColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled) ||
                                          (this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.BoCodeColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                                          (this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.BoCodeColumn.ColumnName].Column.Hidden == true)))
                                    {
                                        afterRowIndex = beforeRowIndex;
                                        afterColKeyName = this._salesDetailDataTable.BoCodeColumn.ColumnName;
                                    }
                                    break;
                                //>>>2010/04/27
                                case 4: // scm
                                    if (!((this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.RecycleDivNmColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled) ||
                                          (this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.RecycleDivNmColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                                          (this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.RecycleDivNmColumn.ColumnName].Column.Hidden == true)))
                                    {
                                        afterRowIndex = beforeRowIndex;
                                        afterColKeyName = this._salesDetailDataTable.BoCodeColumn.ColumnName;
                                    }
                                    break;
                                //<<<2010/04/27
                            }
                        }
                    }

                    //---------------------------------------------
                    // アクティブ位置セット
                    //---------------------------------------------
                    if ((this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled) ||
                        (this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                        (this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName].Column.Hidden == true))
                    {
                        //---------------------------------------------
                        // 移動先移動不可
                        //---------------------------------------------
                        //---------------------------------------------
                        // 移動先が有効になるまで移動
                        //---------------------------------------------
                        // --- UPD 2009/10/19 ---------->>>>>
                        //this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
                        //return MoveReturnCell(); // 再帰
                        //this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName]; //DEL 2010/01/27
                        // --- UPD 2009/10/19 ----------<<<<<

                        // --- ADD 2010/01/27 -------------->>>>>
                        //0:通常入力、且つ受注数が入力可
                        if (this._InputType == 0 && this._salesSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrInputDiv == 1)
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                        }
                        //1:切替入力
                        else if (this._InputType == 1)
                        {
                            //得意先注番は入力可、納品完了予定日は入力不可場合
                            if ((this.uGrid_Details.ActiveCell == this.uGrid_Details.Rows[beforeRowIndex].Cells[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName]) && 
                                (this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit
                                || this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                && (this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.NoEdit
                                && this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled))
                            {
                                //次行移動の場合
                                afterRowIndex = beforeRowIndex + 1;
                            }

                            //有効行のみ
                            if (CheckRowEffective(afterRowIndex))
                            {
                                //明細備考
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.DtlNoteColumn.ColumnName];
                            }
                            else
                            {
                                if (this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.NoEdit 
                                    && this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                {
                                    //商品コード
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                                }
                                else
                                {
                                    //BLコード
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                                    return MoveReturnCell(); // 再帰
                                }
                            }
                        }
                        //2:仕入、3:発注
                        else
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
                            if (afterColKeyName != beforeColKeyName)
                            {
                                return MoveReturnCell(); // 再帰
                            }
                        }
                        // --- ADD 2010/01/27 --------------<<<<<
                    }
                    else
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
                        this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName].Selected = true; // 編集不可項目のフォーカスカラー対応
                        // --- DEL 2009/10/19 ---------->>>>>
                        //this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[afterRowIndex];
                        // --- DEL 2009/10/19 ----------<<<<<
                    }
                }

                //---------------------------------------------
                // 編集モードセット
                //---------------------------------------------
                if (this.uGrid_Details.ActiveCell != null)
                {
                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
                return true;

            }
            finally
            {
                //---------------------------------------------
                // 終了処理
                //---------------------------------------------
                this.uGrid_Details.EndUpdate();
                this.uGrid_Details.ResumeLayout();
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="currentCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            // セル移動不可
            if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
            {
                return false;
            }

            this.uGrid_Details.BeginUpdate();
            this.uGrid_Details.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            // ActiveCellが入力可能の場合、Next処理しない
            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                // ActiveCellあり
                if (this.uGrid_Details.ActiveCell != null)
                {
                    int editMode = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._salesDetailDataTable.EditStatusColumn.ColumnName].Value;

                    if ((editMode == SalesSlipInputAcs.ctEDITSTATUS_AllDisable) || (editMode == SalesSlipInputAcs.ctEDITSTATUS_AllReadOnly))
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

                        if ((performActionResult) && (this.uGrid_Details.ActiveRow != null))
                        {
                            int index = this.uGrid_Details.ActiveRow.Index;

                            if (!(this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Hidden))
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                            }
                            else
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
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
                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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

            this.uGrid_Details.ResumeLayout();
            this.uGrid_Details.EndUpdate();
            return performActionResult;

        }

        /// <summary>
        /// Up/Downキーセル移動処理
        /// </summary>
        /// <param name="keys">入力キーコード</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MoveUpDownCell(Keys keys)
        {
            return this.MoveUpDownCell(keys, false, false);
        }

        /// <summary>
        /// Up/Downキーセル移動処理
        /// </summary>
        /// <param name="keys">入力キーコード</param>
        /// <param name="upperBerthCancel">現在位置上段からの移動キャンセル</param>
        /// <param name="lowerBerthCnacel">現在位置下段からの移動キャンセル</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MoveUpDownCell(Keys keys, bool upperBerthCancel, bool lowerBerthCnacel)
        {

            try
            {
                //---------------------------------------------
                // 初期処理
                //---------------------------------------------
                // レイアウトロジック、グリッド描画停止
                this.uGrid_Details.SuspendLayout();
                this.uGrid_Details.BeginUpdate();

                //---------------------------------------------
                // セル移動不可
                //---------------------------------------------
                if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                    (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
                {
                    return false;
                }

                //---------------------------------------------
                // 項目不正時デフォルト移動位置
                //---------------------------------------------
                string defaultKeyName = this._startKeyNameInit;

                //---------------------------------------------
                // 移動前位置保持
                //---------------------------------------------
                int beforeRowIndex = this.uGrid_Details.ActiveRow.Index;
                int beforeColIndex = this.uGrid_Details.ActiveCell.Column.Index;
                int beforeEditStatus = this._salesDetailDataTable[beforeRowIndex].EditStatus;
                string beforeColKeyName = this.uGrid_Details.ActiveCell.Column.Key;
                int afterRowIndex = 0;
                string afterColKeyName = defaultKeyName;
                int positionDiv = this.GetMovePosition(this.uGrid_Details.ActiveCell.Column.Key, out afterColKeyName); // 現在位置(0:上段／1:下段)

                //---------------------------------------------
                // 移動先取得
                //---------------------------------------------
                switch (keys)
                {
                    //-----------------------------------------
                    // ↓
                    //-----------------------------------------
                    case Keys.Down:
                        switch (positionDiv)
                        {
                            case 0:
                                //-----------------------------------------
                                // 現在位置上段
                                //-----------------------------------------
                                // 移動キャンセルチェック
                                if (upperBerthCancel) return false;
                                // Row移動なし
                                afterRowIndex = beforeRowIndex;
                                break;
                            case 1:
                                //-----------------------------------------
                                // 現在位置下段
                                //-----------------------------------------
                                // 移動キャンセルチェック
                                if (lowerBerthCnacel) return false;
                                // Row次行移動
                                afterRowIndex = beforeRowIndex + 1;
                                // 不正移動チェック
                                if (afterRowIndex > this.uGrid_Details.Rows.Count - 1) return false;
                                break;
                            default:
                                //-----------------------------------------
                                // 例外
                                //-----------------------------------------
                                return false;
                        }
                        break;
                    //-----------------------------------------
                    // ↑
                    //-----------------------------------------
                    case Keys.Up:
                        switch (positionDiv)
                        {
                            case 0:
                                //-----------------------------------------
                                // 現在位置上段
                                //-----------------------------------------
                                // 移動キャンセルチェック
                                if (upperBerthCancel) return false;
                                // Row前行移動
                                afterRowIndex = beforeRowIndex - 1;
                                // 不正移動チェック
                                if (afterRowIndex < 0) return false;
                                break;
                            case 1:
                                //-----------------------------------------
                                // 現在位置下段
                                //-----------------------------------------
                                // 移動キャンセルチェック
                                if (lowerBerthCnacel) return false;
                                // Row移動なし
                                afterRowIndex = beforeRowIndex;
                                break;
                            default:
                                //-----------------------------------------
                                // 例外
                                //-----------------------------------------
                                return false;
                        }
                        break;
                }

                // 移動後情報取得
                int afterEditStatus = this._salesDetailDataTable[afterRowIndex].EditStatus;

                //---------------------------------------------
                // アクティブ位置セット
                //---------------------------------------------
                if (this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled) // 使用不可
                {
                    //---------------------------------------------
                    // 移動先移動不可
                    //---------------------------------------------
                    if ((afterEditStatus == SalesSlipInputAcs.ctEDITSTATUS_RowDiscount) || // 注釈
                        (afterEditStatus == SalesSlipInputAcs.ctEDITSTATUS_Annotation))    // 行値引
                    {
                        if ((keys == Keys.Down) && (positionDiv == 0)) // 上段↓
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
                            return MoveUpDownCell(keys);
                        }
                        else if ((keys == Keys.Up) && (positionDiv == 1)) // 下段↑
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
                            return MoveUpDownCell(keys);
                        }
                        else
                        {
                            if ((beforeEditStatus == SalesSlipInputAcs.ctEDITSTATUS_RowDiscount) &&
                                (beforeColKeyName == this._salesDetailDataTable.SalesCodeColumn.ColumnName) ||
                                (beforeColKeyName == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName))
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
                                return MoveUpDownCell(keys);
                            }
                            else
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                            }
                        }
                    }
                    else if (this._salesSlipInputAcs.SalesSlip.SalesGoodsCd != (int)SalesSlipInputAcs.SalesGoodsCd.Goods)
                    {
                        //---------------------------------------------
                        // 移動先が有効になるまで移動
                        //---------------------------------------------
                        // [移動先 行値引行 注釈行]
                        // [商品区分 商品以外]
                        //---------------------------------------------
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
                        return MoveUpDownCell(keys); // 再帰
                    }
                    else
                    {
                        // 「↓」／「↑」で移動不可の場合、次行／前行のデフォルト位置へ移動
                        if ((keys == Keys.Down) && (positionDiv == 0))
                        {
                            // 次行デフォルト移動先へ移動
                            afterRowIndex = (afterRowIndex + 1 > this.uGrid_Details.Rows.Count - 1) ? afterRowIndex : afterRowIndex + 1;
                            if (this.uGrid_Details.Rows[afterRowIndex].Cells[this.uGrid_Details.ActiveCell.Column.Key].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this.uGrid_Details.ActiveCell.Column.Key];
                            }
                            else
                            {
                                // デフォルト移動先へ移動
                                if (this.uGrid_Details.Rows[afterRowIndex].Cells[defaultKeyName].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[defaultKeyName];
                                }
                                else
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                                }
                            }
                        }
                        else if ((keys == Keys.Up) && (positionDiv == 1))
                        {
                            // 前行デフォルト移動先へ移動
                            afterRowIndex = (afterRowIndex - 1 < 0) ? afterRowIndex : afterRowIndex - 1;
                            if (this.uGrid_Details.Rows[afterRowIndex].Cells[this.uGrid_Details.ActiveCell.Column.Key].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this.uGrid_Details.ActiveCell.Column.Key];
                            }
                            else
                            {
                                // デフォルト移動先へ移動
                                if (this.uGrid_Details.Rows[afterRowIndex].Cells[defaultKeyName].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[defaultKeyName];
                                }
                                else
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                                }
                            }
                        }
                        else
                        {
                            // デフォルト移動先へ移動
                            if (this.uGrid_Details.Rows[afterRowIndex].Cells[defaultKeyName].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[defaultKeyName];
                            }
                            else
                            {
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                            }
                        }

                    }
                }
                else
                {
                    // --- UPD 2009/10/19 ---------->>>>>
                    int rowindex = beforeRowIndex;

                    if (keys == Keys.Down)
                    {
                        rowindex = (beforeRowIndex + 1 > this.uGrid_Details.Rows.Count - 1) ? beforeRowIndex : beforeRowIndex + 1;
                    }
                    else
                    {
                        rowindex = (beforeRowIndex - 1 < 0) ? beforeRowIndex : beforeRowIndex - 1; ;
                    }

                    if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName
                        || this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
                    {
                        #region 行移動時のフォーカス制御の変更
                        string errMsg = string.Empty;
                        bool checkFlag = false;
                        if (this._salesDetailDataTable != null)
                        {
                            checkFlag = CheckRowEffective(rowindex);

                            if (checkFlag == true)
                            {
                                if (keys == Keys.Down)
                                {
                                    // デフォルト移動先へ移動
                                    if (this._salesDetailDataTable[rowindex].SearchPartsModeState == 2)
                                    {
                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[defaultKeyName];
                                    }
                                    else
                                    {
                                        // 次行デフォルト移動先へ移動
                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                    }
                                }
                                else if (keys == Keys.Up)
                                {
                                    if (this.uGrid_Details.ActiveRow.Index == 0 && this.GridKeyDownTopRow != null)
                                    {
                                        if (!string.IsNullOrEmpty(this.uGrid_Details.ActiveCell.Text))
                                        {
                                            // --- UPD 2009/11/24 ---------->>>>>
                                            //if (this.CheckSalesUnitCost())
                                            if (this.CheckSalesUnitCost() && this.CheckSalesRateAndUnPrcDisplay())
                                            // --- UPD 2009/11/24 ----------<<<<<
                                            {
                                                this.GridKeyDownTopRow(this, new EventArgs());
                                            }
                                        }
                                        return true;
                                    }
                                    else
                                    {
                                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
                                        {
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex + 1].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                        }
                                        else
                                        {
                                            // 前行デフォルト移動先へ移動
                                            if (this._salesDetailDataTable[rowindex].SearchPartsModeState == 2)
                                            {
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                                            }
                                            else
                                            {
                                                // 次行デフォルト移動先へ移動
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (keys == Keys.Down)
                                {
                                    // デフォルト移動先へ移動
                                    if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
                                    {
                                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName)
                                        {
                                            if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                                            {
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                                            }
                                            else
                                            {
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                                            }
                                        }
                                        else
                                        {
                                            if (CheckRowEffective(beforeRowIndex))
                                            {
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[defaultKeyName];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                    }
                                }
                                else if (keys == Keys.Up)
                                {
                                    // デフォルト移動先へ移動
                                    if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
                                    {
                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[defaultKeyName];
                                    }
                                    else
                                    {
                                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName
                            || this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName
                            || this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SupplierCdColumn.ColumnName)
                        {
                            if (keys == Keys.Down)
                            {
                                // デフォルト移動先へ移動
                                if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[defaultKeyName];
                                }
                                else
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                }
                            }
                            else if (keys == Keys.Up)
                            {
                                // デフォルト移動先へ移動
                                if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[defaultKeyName];
                                }
                                else
                                {
                                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowindex].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                }
                            }
                        }
                        else
                        {
                            //---------------------------------------------
                            // 移動先移動可
                            //---------------------------------------------
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName];
                        }
                    }
                    // --- UPD 2009/10/19 ----------<<<<<
                }

                // --- DEL 2009/10/19 ---------->>>>>
                //this.uGrid_Details.Rows[afterRowIndex].Cells[afterColKeyName].Selected = true; // 編集不可項目のフォーカスカラー対応
                //this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[afterRowIndex];
                // --- DEL 2009/10/19 ----------<<<<<

                //---------------------------------------------
                // 編集モードセット
                //---------------------------------------------
                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.uGrid_Details.EndUpdate();
                this.uGrid_Details.ResumeLayout();
            }

        }

        /// <summary>
        /// 移動位置取得処理(上段／下段／セル)
        /// </summary>
        /// <param name="p">現在位置KeyName</param>
        /// <param name="afterColKeyName">移動位置KeyName</param>
        /// <returns>現在位置情報  0:上段 1:下段 -1:例外</returns>
        private int GetMovePosition(string p, out string afterColKeyName)
        {
            afterColKeyName = string.Empty;

            if (this._upperBerth[p] != null)
            {
                //---------------------------------------------
                // 現在位置上段
                //---------------------------------------------
                afterColKeyName = this._upperBerth[p].ToString();
                return 0;
            }
            else if (this._lowerBerth[p] != null)
            {
                //---------------------------------------------
                // 現在位置下段
                //---------------------------------------------
                afterColKeyName = this._lowerBerth[p].ToString();
                return 1;
            }
            else
            {
                //---------------------------------------------
                // 例外
                //---------------------------------------------
                return -1;
            }
        }

        /// <summary>
        /// 移動位置取得処理(Enterキー移動時)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="afterColKeyName"></param>
        /// <returns>0:正常取得 -1:例外</returns>
        private int GetNextMovePosition(string p, out string afterColKeyName)
        {
            afterColKeyName = string.Empty;

            if (this._enterMoveTable[p].Key != null)
            {
                afterColKeyName = this._enterMoveTable[p].Key;
            }

            if (!string.IsNullOrEmpty(afterColKeyName))
            {
                //---------------------------------------------
                // 正常取得
                //---------------------------------------------
                if (SalesSlipInputConstructionAcs.ct_StartPosittion == afterColKeyName) afterColKeyName = this._enterMoveTable[afterColKeyName].Key;
                return 0;
            }
            else
            {
                //---------------------------------------------
                // 例外
                //---------------------------------------------
                return -1;
            }
        }

        /// <summary>
        /// フォーカス移動対象判定処理
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns>True:移動対象 False:移動対象外</returns>
        private bool GetEffectiveJudgment(string keyName)
        {
            ICollection keys = this._enterMoveTable.Keys;
            foreach (object key in keys)
            {
                if (keyName == key.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 売上明細データテーブル列表示設定クラスセッティング処理
        /// </summary>
        private void SettingSalesDetailRowVisibleControl()
        {
            //------------------------------------------------------------------------
            // StatusType:Default
            //------------------------------------------------------------------------
            #region ●StatusType:Default
            // №
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName, StatusType.Default, 0, false);
            // BLコード
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName, StatusType.Default, 0, false);
            // 商品コード
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 0, false);
            // 商品名
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 0, false);
            // メーカー
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, 0, false);
            // 仕入先
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdColumn.ColumnName, StatusType.Default, 0, false);
            // メモイメージ
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SlipMemoExistColumn.ColumnName, StatusType.Default, 0, false);
            // 仕入伝票イメージ
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierSlipExistColumn.ColumnName, StatusType.Default, 0, false);
            // 商品属性(純優)
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName, StatusType.Default, 0, false);
            #endregion

            //------------------------------------------------------------------------
            // StatusType:AcptAnOdrStatusAndSalesSlipCd
            //------------------------------------------------------------------------
            #region ●StatusType:AcptAnOdrStatusAndSalesSlipCd
            // 出荷数
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 100, false); // 100 見積売上
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 101, false); // 101 見積返品
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 150, false);  // 150 単価見積売上
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 151, false);  // 151 単価見積返品
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 300, false); // 300 売上売上
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 301, false); // 301 売上返品
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 400, false); // 400 出荷売上
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 401, false); // 401 出荷返品
            // 受注数
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 100, false); // 100 見積売上
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 101, false); // 101 見積返品
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 150, false); // 150 単価見積売上
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 151, false); // 151 単価見積返品
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 300, false); // 300 売上売上
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 301, false); // 301 売上返品
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 400, false); // 400 出荷売上
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, StatusType.AcptAnOdrStatusAndSalesSlipCd, 401, false); // 401 出荷返品
            #endregion

            //------------------------------------------------------------------------
            // StatusType:InputChange(0:通常明細 1:切替明細 2:仕入情報 3:発注選択)
            //------------------------------------------------------------------------
            #region ●StatusType:InputChange
            // 販売区分
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesCodeColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesCodeColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesCodeColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesCodeColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesCodeColumn.ColumnName, StatusType.InputChange, 4, false); // 2010/02/26
            // 定価
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName, StatusType.InputChange, 4, false); // 2010/02/26
            // オープン価格区分
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, StatusType.InputChange, 4, false); // 2010/02/26
            // 仕入率
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CostRateColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CostRateColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CostRateColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CostRateColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CostRateColumn.ColumnName, StatusType.InputChange, 4, false); // 2010/02/26
            // 原価単価
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnitCostColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnitCostColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnitCostColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnitCostColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnitCostColumn.ColumnName, StatusType.InputChange, 4, false); // 2010/02/26
            // ダミー(未使用項目)
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DummyColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DummyColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DummyColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DummyColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DummyColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 売価率
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesRateColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesRateColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesRateColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesRateColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesRateColumn.ColumnName, StatusType.InputChange, 4, false); // 2010/02/26
            // 売上単価
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName, StatusType.InputChange, 4, false); // 2010/02/26
            // 売上金額
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 倉庫
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName, StatusType.InputChange, 1, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 棚番
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName, StatusType.InputChange, 1, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 現在庫数
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName, StatusType.InputChange, 0, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName, StatusType.InputChange, 1, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 明細備考
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DtlNoteColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DtlNoteColumn.ColumnName, StatusType.InputChange, 1, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DtlNoteColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DtlNoteColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DtlNoteColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 一式明細
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName, StatusType.InputChange, 1, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 得意先注番
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName, StatusType.InputChange, 1, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 納品完了予定日
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName, StatusType.InputChange, 1, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 仕入情報　仕入先
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 仕入情報　仕入日
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.StockDateColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.StockDateColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.StockDateColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.StockDateColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.StockDateColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 仕入情報　仕入先伝票番号
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName, StatusType.InputChange, 2, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 発注情報　BO
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.BoCodeColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.BoCodeColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.BoCodeColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.BoCodeColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.BoCodeColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 発注情報　発注先
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 発注情報　発注数
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 発注情報　発注先名称
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 発注情報　納品区分
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 発注情報　H納品区分
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            // 発注情報　指定拠点
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName, StatusType.InputChange, 3, false);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName, StatusType.InputChange, 4, true); // 2010/02/26
            //>>>2010/02/26
            // SCM RC区分
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.RecycleDivNmColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.RecycleDivNmColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.RecycleDivNmColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.RecycleDivNmColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.RecycleDivNmColumn.ColumnName, StatusType.InputChange, 4, false);
            //// SCM 回答納期
            //this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AnswerDelivDateColumn.ColumnName, StatusType.InputChange, 0, true);
            //this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AnswerDelivDateColumn.ColumnName, StatusType.InputChange, 1, true);
            //this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AnswerDelivDateColumn.ColumnName, StatusType.InputChange, 2, true);
            //this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AnswerDelivDateColumn.ColumnName, StatusType.InputChange, 3, true);
            //this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.AnswerDelivDateColumn.ColumnName, StatusType.InputChange, 4, false);
            // SCM PS管理番号
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.GoodsMngNoColumn.ColumnName, StatusType.InputChange, 0, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.GoodsMngNoColumn.ColumnName, StatusType.InputChange, 1, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.GoodsMngNoColumn.ColumnName, StatusType.InputChange, 2, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.GoodsMngNoColumn.ColumnName, StatusType.InputChange, 3, true);
            this._salesDetailRowVisibleControl.Add(this._salesDetailDataTable.GoodsMngNoColumn.ColumnName, StatusType.InputChange, 4, false);
            //<<<2010/02/26
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

                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                }
            }

            // グリッド列表示非表示設定処理
            this.SettingGridColVisible(StatusType.Default, 0);

            // 列幅の自動調整方法
            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_Details.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatusExp> colDisplayStatusList = ColDisplayStatusList.Deserialize(ct_FILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._salesDetailDataTable);
            this._salesInputConstructionAcs.NameTable = new Hashtable();
            EnterMoveValue enterMoveValue = null;

            foreach (ColDisplayStatusExp colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
            {
                // 明細部フォーカス開始項目
                if (colDisplayStatus.Key == SalesSlipInputConstructionAcs.ct_StartPosittion) this._startKeyName = colDisplayStatus.MoveEnterKeyName;
                // 明細部フォーカス終了項目
                if (colDisplayStatus.Key == SalesSlipInputConstructionAcs.ct_EndPosittion) this._endKeyNameList[0] = colDisplayStatus.MoveEnterKeyName;

                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns.Exists(colDisplayStatus.Key))
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.Reset();

                    System.Drawing.Size sizeHeader = new Size();
                    System.Drawing.Size sizeCell = new Size();
                    this.uGrid_Details.DisplayLayout.Bands[0].RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                    this.uGrid_Details.DisplayLayout.Bands[0].RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                    sizeCell.Height = 22;
                    sizeCell.Width = colDisplayStatus.Width;
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                    sizeHeader.Height = 20;
                    sizeHeader.Width = colDisplayStatus.Width;
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.LabelSpan = colDisplayStatus.LabelSpan;
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.OriginX = colDisplayStatus.OriginX;
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.OriginY = colDisplayStatus.OriginY;
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.SpanX = colDisplayStatus.SpanX;
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.SpanY = colDisplayStatus.SpanY;

                    if (colDisplayStatus.OriginY == 0)
                    {
                        // 上段テーブル
                        this._upperBerth[colDisplayStatus.Key] = colDisplayStatus.MoveLineKeyName;
                    }
                    else
                    {
                        // 下段テーブル
                        this._lowerBerth[colDisplayStatus.Key] = colDisplayStatus.MoveLineKeyName;
                    }

                    // 移動先テーブル
                    enterMoveValue = new EnterMoveValue();
                    enterMoveValue.Key = colDisplayStatus.MoveEnterKeyName;
                    enterMoveValue.Enabled = colDisplayStatus.Enabled;
                    enterMoveValue.EnabledControl = colDisplayStatus.EnabledControl;
                    enterMoveValue.EnterStopControl = colDisplayStatus.EnterStopControl;
                    this._enterMoveTable[colDisplayStatus.Key] = enterMoveValue;

                    // 項目名称リスト
                    // 有効項目リストに存在する項目のみ対象とする
                    if (_effectiveList.Contains(colDisplayStatus.Key))
                    {
                        //if (colDisplayStatus.Key == this._salesDetailDataTable.GoodsGuideButtonColumn.ColumnName)
                        //{
                        //    this._salesInputConstructionAcs.NameTable[colDisplayStatus.Key] = "商品番号ガイドボタン";
                        //    this._salesInputConstructionAcs.NameTable["商品番号ガイドボタン"] = colDisplayStatus.Key;
                        //}
                        //else
                        //{
                            this._salesInputConstructionAcs.NameTable[colDisplayStatus.Key] = this._salesDetailDataTable.Columns[colDisplayStatus.Key].Caption;
                            this._salesInputConstructionAcs.NameTable[this._salesDetailDataTable.Columns[colDisplayStatus.Key].Caption] = colDisplayStatus.Key;
                        //}
                    }
                }
            }
            // 開始終了項目設定
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = this._startKeyName;
            enterMoveValue.Enabled = true;
            enterMoveValue.EnabledControl = false;
            enterMoveValue.EnterStopControl = false;
            this._enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion] = enterMoveValue;
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = this._endKeyNameList[0].ToString();
            enterMoveValue.Enabled = true;
            enterMoveValue.EnabledControl = false;
            enterMoveValue.EnterStopControl = false;
            this._enterMoveTable[SalesSlipInputConstructionAcs.ct_EndPosittion] = enterMoveValue;

            // ユーザー設定アクセスクラスに反映
            this._salesInputConstructionAcs.EffectiveList = this._effectiveList;
            this._salesInputConstructionAcs.EnterMoveTable = this._enterMoveTable;
            this._salesInputConstructionAcs.EndKeyNameList = this._endKeyNameList;
            this._salesInputConstructionAcs.EndKeyNameListInit = this._endKeyNameListInit;

            // 初期設定移動先テーブル作成
            Dictionary<string, ColDisplayStatusExp> colDisplayStatusExpDic = this._colDisplayStatusList.GetColDisplayInitDictionary();
            ICollection keys = colDisplayStatusExpDic.Keys;
            foreach (string key in keys)
            {
                enterMoveValue = new EnterMoveValue();
                enterMoveValue.Key = colDisplayStatusExpDic[key].MoveEnterKeyName;
                enterMoveValue.Enabled = colDisplayStatusExpDic[key].Enabled;
                enterMoveValue.EnabledControl = colDisplayStatusExpDic[key].EnabledControl;
                enterMoveValue.EnterStopControl = colDisplayStatusExpDic[key].EnterStopControl;
                this._enterMoveTableInit.Add(colDisplayStatusExpDic[key].Key, enterMoveValue);
                //this._enterMoveTableInit[colDisplayStatusExpDic[key].Key].Key = colDisplayStatusExpDic[key].MoveEnterKeyName;
                //this._enterMoveTableInit[colDisplayStatusExpDic[key].Key].Enabled = colDisplayStatusExpDic[key].Enabled;
            }
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = this._startKeyNameInit;
            enterMoveValue.Enabled = true;
            enterMoveValue.EnabledControl = false;
            enterMoveValue.EnterStopControl = false;
            this._enterMoveTableInit[SalesSlipInputConstructionAcs.ct_StartPosittion] = enterMoveValue;
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = this._endKeyNameListInit[0].ToString();
            enterMoveValue.Enabled = true;
            enterMoveValue.EnabledControl = false;
            enterMoveValue.EnterStopControl = false;
            this._enterMoveTableInit[SalesSlipInputConstructionAcs.ct_EndPosittion] = enterMoveValue;
            this._salesInputConstructionAcs.EnterMoveTableInit = this._enterMoveTableInit;

            #region ●CellAppearance
            //---------------------------------------------------------------------
            // CellAppearance設定
            //---------------------------------------------------------------------
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;         // №
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;                // BLコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;                  // 品名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;                    // 品番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;            // 商品属性(純正優良)
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;               // メーカー
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;                 // 仕入先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   // 受注数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;        // 出荷数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;                     // 販売区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;          // 定価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;     // オープン価格区分イメージ
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                  // 原価率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;             // 原価単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                 // 売価率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;         // 売上単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;         // 売上金額
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;              // 倉庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;           // 棚番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      // 現在庫数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;                    // 明細備考
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;            // 得意先注番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;           // 一式番号
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        // 納品完了予定日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;           // メモ存在イメージ
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierSlipExistColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;       // 仕入情報存在イメージ
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;         // 仕入先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.StockDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;                  // 仕入日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;          // 仕入伝票番号

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.BoCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;                  // BO
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        // 発注先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 発注数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;       // 発注先名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;       // 納品区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;      // H納品区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;         // 指定拠点

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            #region ●CellActivation
            //---------------------------------------------------------------------
            // 入力許可設定
            //---------------------------------------------------------------------
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;    // No
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;        // 一式番号
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // 棚番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;   // 現在庫数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;          // メモ存在イメージ
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierSlipExistColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // 仕入情報存在イメージ
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // オープン価格区分イメージ
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DummyColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;                  // ダミー
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 発注先名称
            #endregion

            #region ●Style
            //---------------------------------------------------------------------
            // Style設定
            //---------------------------------------------------------------------
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;          // BLコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;            // 品名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // 品番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // 商品属性(純正優良)
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // メーカー
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;           // 仕入先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // 受注数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // 出荷数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;               // 販売区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // 定価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;             // 原価率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // 原価単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;            // 売価率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // 売上単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // 売上金額
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DtlNoteColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			    // 備考
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 得意先注番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 一式番号
            //>>>2010/02/26
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;  // 納品完了予定日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // 納品完了予定日
            //<<<2010/02/26
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.WarehouseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // 倉庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // 棚番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; // 現在庫数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // 仕入先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.StockDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;            // 仕入日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // 仕入伝票番号
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.BoCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;               // BO
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // 発注先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; // 発注数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // 発注先名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // 納品区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; // H納品区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // 指定拠点
            //>>>2010/02/26
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.RecycleDivNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // RC区分
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AnswerDelivDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 回答納期
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsMngNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;           // PS管理番号
            //<<<2010/02/26
            #endregion

            #region ●Format
            //---------------------------------------------------------------------
            // フォーマット設定
            //---------------------------------------------------------------------
            string countFormat = "#,##0;-#,##0;";
            string moneyFormat = "#,##0;-#,##0;''";
            string moneyFormatFl = "#,##0.00;-#,##0.00;''";
            string rateFormatFl = "###0.00;-###0.00;''";
            string codeFormat = "#0;-#0;''";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName].Format = moneyFormatFl;			// 出荷数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].Format = moneyFormatFl;		// 受注数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName].Format = moneyFormat;		// 発注数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName].Format = moneyFormat;               // 定価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].Format = rateFormatFl;                      // 原価率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Format = moneyFormatFl;                // 原価単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRateColumn.ColumnName].Format = rateFormatFl;                     // 売価率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName].Format = moneyFormatFl;	        // 売上単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName].Format = moneyFormat;		        // 売上金額
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName].Format = codeFormat;                     // BLコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdColumn.ColumnName].Format = codeFormat;                      // 仕入先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName].Format = codeFormat;                    // メーカー
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName].Format = codeFormat;                 // 一式番号
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].Format = codeFormat;              // 仕入先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName].Format = codeFormat;             // 発注先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName].Format = countFormat;		    // 現在庫数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsMngNoColumn.ColumnName].Format = codeFormat;                      // PS管理番号 // 2010/02/26
            #endregion

            #region ●MaxLength
            //---------------------------------------------------------------------
            // MaxLength設定
            //---------------------------------------------------------------------
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName].MaxLength = 7;      // 定価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNoColumn.ColumnName].MaxLength = 40;              // 品番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNameColumn.ColumnName].MaxLength = 40;            // 品名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName].MaxLength = 5;           // BLコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName].MaxLength = 6;          // メーカーコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdColumn.ColumnName].MaxLength = 9;            // 仕入先コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName].MaxLength = 10;   // 出荷数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].MaxLength = 10; // 受注数
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesRateColumn.ColumnName].MaxLength = 12;            // 売価率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName].MaxLength = 11;    // 売上単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName].MaxLength = 12;    // 売上金額
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].MaxLength = 12;             // 原価率
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].MaxLength = 11;        // 原価単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DtlNoteColumn.ColumnName].MaxLength = 40;              // 明細備考
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].MaxLength = 19;      // 得意先注番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.WarehouseCodeColumn.ColumnName].MaxLength = 6;         // 倉庫コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.BoCodeColumn.ColumnName].MaxLength = 1;                // BO区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName].MaxLength = 1;   // 納品区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName].MaxLength = 1;  // Ｈ納品区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName].MaxLength = 3;     // 指定拠点
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName].MaxLength = 3; // 発注数
            //>>>2010/02/26
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName].MaxLength = 10;      // 回答納期
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsMngNoColumn.ColumnName].MaxLength = 8;                // PS管理番号
            //<<<2010/02/26
            #endregion

            #region ●UI設定からMaxLength,TextHAlignの再セット
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                int maxLength = uiSetControl1.GetSettingColumnCount(col.Key);

                if (maxLength > 0)
                {
                    col.MaxLength = maxLength;
                    col.CellAppearance.TextHAlign = uiSetControl1.GetSettingHAlign(col.Key);
                    col.Format = this.GetCodeFormat(col.Key);
                }
            }
            #endregion

            #region ●Header.Appearance.BackColor
            // 仕入先コード（仕入情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].Header.Appearance.BackColor = ct_STOCK_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].Header.Appearance.BackColor2 = ct_STOCK_BACKCOLOR2;
            // 仕入日（仕入情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.StockDateColumn.ColumnName].Header.Appearance.BackColor = ct_STOCK_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.StockDateColumn.ColumnName].Header.Appearance.BackColor2 = ct_STOCK_BACKCOLOR2;
            // 仕入先伝票番号（仕入情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName].Header.Appearance.BackColor = ct_STOCK_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName].Header.Appearance.BackColor2 = ct_STOCK_BACKCOLOR2;

            // 発注先コード（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            // ＢＯ区分（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.BoCodeColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.BoCodeColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            // 発注数（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            // 発注先名称（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            // 納品区分（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.UOEDeliGoodsDivColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.UOEDeliGoodsDivColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            // 納品区分（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            // Ｈ納品区分（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.FollowDeliGoodsDivColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.FollowDeliGoodsDivColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            // Ｈ納品区分（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            // 指定拠点（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.UOEResvdSectionColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.UOEResvdSectionColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            // 指定拠点（発注情報）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName].Header.Appearance.BackColor = ct_ORDER_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName].Header.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
            //>>>2010/02/26
            // RC区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.RecycleDivNmColumn.ColumnName].Header.Appearance.BackColor = ct_SCM_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.RecycleDivNmColumn.ColumnName].Header.Appearance.BackColor2 = ct_SCM_BACKCOLOR2;
            //// 回答納期
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AnswerDelivDateColumn.ColumnName].Header.Appearance.BackColor = ct_SCM_BACKCOLOR;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AnswerDelivDateColumn.ColumnName].Header.Appearance.BackColor2 = ct_SCM_BACKCOLOR2;
            // PS管理番号
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsMngNoColumn.ColumnName].Header.Appearance.BackColor = ct_SCM_BACKCOLOR;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsMngNoColumn.ColumnName].Header.Appearance.BackColor2 = ct_SCM_BACKCOLOR2;
            //<<<2010/02/26
            #endregion
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
                return string.Format("{0};-{0};''", new string('0', uiset.Column));
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 移動先テーブル再設定処理
        /// </summary>
        public void ReSettingEnterMoveTable()
        {

            //-----------------------------------------------------------------------------
            // 移動先頭項目再設定
            //-----------------------------------------------------------------------------
            //if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
            //{
            //    //-----------------------------------------------------------------------------
            //    // BLコード検索時
            //    //-----------------------------------------------------------------------------
            //    this._startKeyName = this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName;
            //    this._startKeyNameInit = this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName;

            //}
            //else
            //{
                //-----------------------------------------------------------------------------
                // 品番検索時
                //-----------------------------------------------------------------------------
                this._startKeyName = this._salesDetailDataTable.GoodsNoColumn.ColumnName;
                this._startKeyNameInit = this._salesDetailDataTable.GoodsNoColumn.ColumnName;
            //}

            //-----------------------------------------------------------------------------
            // 移動先テーブルクリア
            //-----------------------------------------------------------------------------
            this._enterMoveTable.Clear();
            this._enterMoveTableInit.Clear();

            //-----------------------------------------------------------------------------
            // 移動先テーブル作成
            //-----------------------------------------------------------------------------
            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatusExp> colDisplayStatusList = ColDisplayStatusList.Deserialize(ct_FILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._salesDetailDataTable);
            EnterMoveValue enterMoveValue = null;

            foreach (ColDisplayStatusExp colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
            {
                // 明細部フォーカス開始項目
                if (colDisplayStatus.Key == SalesSlipInputConstructionAcs.ct_StartPosittion) this._startKeyName = colDisplayStatus.MoveEnterKeyName;
                // 明細部フォーカス終了項目
                if (colDisplayStatus.Key == SalesSlipInputConstructionAcs.ct_EndPosittion) this._endKeyNameList[0] = colDisplayStatus.MoveEnterKeyName;

                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns.Exists(colDisplayStatus.Key))
                {
                    // 移動先テーブル
                    enterMoveValue = new EnterMoveValue();
                    enterMoveValue.Key = colDisplayStatus.MoveEnterKeyName;
                    enterMoveValue.Enabled = colDisplayStatus.Enabled;
                    enterMoveValue.EnabledControl = colDisplayStatus.EnabledControl;
                    enterMoveValue.EnterStopControl = colDisplayStatus.EnterStopControl;
                    this._enterMoveTable[colDisplayStatus.Key] = enterMoveValue;
                }
            }
            // 開始終了項目設定
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = this._startKeyName;
            enterMoveValue.Enabled = true;
            enterMoveValue.EnabledControl = false;
            enterMoveValue.EnterStopControl = false;
            this._enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion] = enterMoveValue;
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = this._endKeyNameList[0].ToString();
            enterMoveValue.Enabled = true;
            enterMoveValue.EnabledControl = false;
            enterMoveValue.EnterStopControl = false;
            this._enterMoveTable[SalesSlipInputConstructionAcs.ct_EndPosittion] = enterMoveValue;

            // ユーザー設定アクセスクラスに反映
            this._salesInputConstructionAcs.EnterMoveTable = this._enterMoveTable;

            //-----------------------------------------------------------------------------
            // 初期設定移動先テーブル作成
            //-----------------------------------------------------------------------------
            Dictionary<string, ColDisplayStatusExp> colDisplayStatusExpDic = this._colDisplayStatusList.GetColDisplayInitDictionary();
            ICollection keys = colDisplayStatusExpDic.Keys;
            foreach (string key in keys)
            {
                enterMoveValue = new EnterMoveValue();
                enterMoveValue.Key = colDisplayStatusExpDic[key].MoveEnterKeyName;
                enterMoveValue.Enabled = colDisplayStatusExpDic[key].Enabled;
                enterMoveValue.EnabledControl = colDisplayStatusExpDic[key].EnabledControl;
                enterMoveValue.EnterStopControl = colDisplayStatusExpDic[key].EnterStopControl;
                this._enterMoveTableInit.Add(colDisplayStatusExpDic[key].Key, enterMoveValue);
                //this._enterMoveTableInit[colDisplayStatusExpDic[key].Key].Key = colDisplayStatusExpDic[key].MoveEnterKeyName;
                //this._enterMoveTableInit[colDisplayStatusExpDic[key].Key].Enabled = colDisplayStatusExpDic[key].Enabled;
            }
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = this._startKeyNameInit;
            enterMoveValue.Enabled = true;
            enterMoveValue.EnabledControl = false;
            enterMoveValue.EnterStopControl = false;
            this._enterMoveTableInit[SalesSlipInputConstructionAcs.ct_StartPosittion] = enterMoveValue;
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = this._endKeyNameListInit[0].ToString();
            enterMoveValue.Enabled = true;
            enterMoveValue.EnabledControl = false;
            enterMoveValue.EnterStopControl = false;
            this._enterMoveTableInit[SalesSlipInputConstructionAcs.ct_EndPosittion] = enterMoveValue;

            // ユーザー設定アクセスクラスに反映
            this._salesInputConstructionAcs.EnterMoveTableInit = this._enterMoveTableInit;

        }

        /// <summary>
        /// グリッド設定処理（ユーザー設定より）
        /// </summary>
        /// <param name="stockInputConstruction">売上入力用ユーザー設定クラス</param>
        /// <br>Update Note: 2010/01/27 高峰 明細部ボタンの表示／非表示の対応</br>
        internal void GridSetting(SalesSlipInputConstruction salesInputConstruction)
        {

            SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
            if (salesSlip != null)
            {
                // グリッド列表示非表示設定処理
                this.SettingGridColVisible(StatusType.SalesGoodsCd, salesSlip.SalesGoodsCd);
                this.SettingGridColVisible(StatusType.AcptAnOdrStatus, salesSlip.AcptAnOdrStatus);
                this.SettingGridColVisible(StatusType.AcptAnOdrStatusAndSalesSlipCd, salesSlip.AcptAnOdrStatus * 10 + salesSlip.SalesSlipCd);
                this.SettingGridColVisible(StatusType.InputChange, 0);
                this.ChangeInputType(0);
            }

            // フォントサイズ
            this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = salesInputConstruction.FontSizeValue;

            // ---------- ADD 2010/01/27 ---------->>>>>>>>>>
            if (this._salesInputConstructionAcs.UltraOptionSetValue == 0)
            {
                this.tToolbarsManager_Main.Visible = false;
            }
            else
            {
                this.tToolbarsManager_Main.Visible = true;
            }
            // ---------- ADD 2010/01/27 ----------<<<<<<<<<<
        }

        /// <summary>
        /// Enterキー移動先項目テーブルセット処理
        /// </summary>
        internal void EnterMoveSetting()
        {
            this._enterMoveTable = this._salesInputConstructionAcs.EnterMoveTable; // Enterキー移動先項目テーブル
        }

        /// <summary>
        /// クローズ処理
        /// </summary>
        internal void Closing()
        {
            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatusExp> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

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
                if (this._salesDetailRowVisibleControl.GetHidden(col.Key, statusType, value, out hidden) == 0)
                {
                    col.Hidden = hidden;
                }
            }
        }

        /// <summary>
        /// 各InputTypeにより、明細グリッド・行単位でのセル設定
        /// </summary>
        /// <remarks>
        /// <returns>各InputTypeにより、フォーカス移動行の収得</returns>
        /// <br>Note       : 各InputTypeにより、明細グリッド・行単位でのセル設定を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2010/01/27</br> 
        /// </remarks>
        private int SettingGridRowFromInputChange()
        {
            int rowEffectiveIndex = -1;
            foreach(Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
            {
                //有効行のみ
                if (!CheckRowEffective(row.Index)) return rowEffectiveIndex;

                Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
                if (editBand == null) return rowEffectiveIndex;

                //0:通常入力
                SettingGridRow(row.Index, this._salesSlipInputAcs.SalesSlip);

                // 指定行の全ての列に対して設定を行う。
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                {
                    // セル情報を取得
                    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[row.Index].Cells[col];
                    if (cell == null) continue;

                    //1:切替入力
                    if (this._InputType == 1)
                    {
                        // 明細備考、得意先注番、納品完了予定日以外、入力不可
                        if (!(col.Key == this._salesDetailDataTable.DtlNoteColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName))
                        {
                            if (cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                            }
                        }
                    }
                    //2:仕入
                    else if (this._InputType == 2)
                    {
                        // 仕入先、仕入日、仕入伝票番号以外、入力不可
                        if (!(col.Key == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.StockDateColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName))
                        {
                            if (cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                            }
                        }
                    }
                    //3:発注
                    else if (this._InputType == 3)
                    {
                        // BO、発注先、数量(発注数)、納品区分、H納品区分、指定拠点以外、入力不可
                        if (!(col.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName))
                        {
                            if (cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                            }
                        }
                    }
                    //>>>2010/04/27
                    else if (this._InputType == 4)
                    {
                        // RC区分、PS管理番号
                        if (!(col.Key == this._salesDetailDataTable.RecycleDivNmColumn.ColumnName
                            || col.Key == this._salesDetailDataTable.GoodsMngNoColumn.ColumnName))
                        {
                            if (cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled)
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                            }
                        }
                    }
                    //<<<2010/04/27
                }

                if (rowEffectiveIndex < 0)
                {
                    rowEffectiveIndex = row.Index;
                }
            }

            return rowEffectiveIndex;
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
        internal void SettingActiveCell(int mode, int rowNo, SalesInputDataSet.SalesDetailDataTable salesTable)
        {
            if ((rowNo > 0) && (rowNo <= salesTable.Rows.Count))
            {
                for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
                {
                    SalesInputDataSet.SalesDetailRow row = (SalesInputDataSet.SalesDetailRow)salesTable.Rows[i];

                    if (row.SalesRowNo == rowNo)
                    {
                        string columnKey = string.Empty;
                        switch (mode)
                        {
                            case ct_SettingActiveCell_ShipmentCntError:
                                columnKey = salesTable.ShipmentCntDisplayColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_AcptAnOdrCntError:
                                columnKey = salesTable.AcceptAnOrderCntDisplayColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_SalesUnitPriceError:
                                columnKey = salesTable.SalesUnPrcDisplayColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_SalesUnitCostError:
                                columnKey = salesTable.SalesUnitCostColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_ListPriceError:
                                columnKey = salesTable.ListPriceDisplayColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_SalesMoneyError:
                                columnKey = salesTable.SalesMoneyDisplayColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_CostError:
                                columnKey = salesTable.CostColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_SalesRateError:
                                columnKey = salesTable.SalesRateColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_BLGoodsCdError:
                                columnKey = salesTable.BLGoodsCodeColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_GoodsMakerCdError:
                                columnKey = salesTable.GoodsMakerCdColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_SupplierCdError:
                                columnKey = salesTable.SupplierCdColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_GoodsName:
                                columnKey = salesTable.GoodsNameColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_DeliveredGoodsDiv:
                                columnKey = salesTable.DeliveredGoodsDivNmColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_FollowDeliGoodsDiv:
                                columnKey = salesTable.FollowDeliGoodsDivNmColumn.ColumnName;
                                break;
                            case ct_SettingActiveCell_UOEResvdSection:
                                columnKey = salesTable.UOEResvdSectionNmColumn.ColumnName;
                                break;
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
        /// 引数のモードを元にActiveCellを設定します。
        /// </summary>
        /// <param name="mode">モード</param>
        internal void SettingActiveCell(int mode, int rowNo, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesTable)
        {
            if (rowNo > 0)
            {
                SalesInputDataSet.SalesDetailAcceptAnOrderRow[] rows = this._salesSlipInputAcs.SelectSalesDetailAcptAnOdrRows(string.Format("{0}={1}", salesTable.SalesRowNoColumn.ColumnName, rowNo), salesTable);
                SalesInputDataSet.SalesDetailAcceptAnOrderRow row = rows[0];

                if (row.SalesRowNo == rowNo)
                {
                    string columnKey = string.Empty;
                    switch (mode)
                    {
                        case ct_SettingActiveCell_ShipmentCntError:
                            columnKey = salesTable.ShipmentCntDisplayColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_AcptAnOdrCntError:
                            columnKey = salesTable.AcceptAnOrderCntDisplayColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_SalesUnitPriceError:
                            columnKey = salesTable.SalesUnPrcDisplayColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_SalesUnitCostError:
                            columnKey = salesTable.SalesUnitCostColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_ListPriceError:
                            columnKey = salesTable.ListPriceDisplayColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_SalesMoneyError:
                            columnKey = salesTable.SalesMoneyDisplayColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_CostError:
                            columnKey = salesTable.CostColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_SalesRateError:
                            columnKey = salesTable.SalesRateColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_BLGoodsCdError:
                            columnKey = salesTable.BLGoodsCodeColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_GoodsMakerCdError:
                            columnKey = salesTable.GoodsMakerCdColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_SupplierCdError:
                            columnKey = salesTable.SupplierCdColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_GoodsName:
                            columnKey = salesTable.GoodsNameColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_DeliveredGoodsDiv:
                            columnKey = salesTable.DeliveredGoodsDivNmColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_FollowDeliGoodsDiv:
                            columnKey = salesTable.FollowDeliGoodsDivNmColumn.ColumnName;
                            break;
                        case ct_SettingActiveCell_UOEResvdSection:
                            columnKey = salesTable.UOEResvdSectionNmColumn.ColumnName;
                            break;
                    }

                    if (!string.IsNullOrEmpty(columnKey))
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowNo -1].Cells[columnKey];
                        this.CellExitEnterEditEnter();
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
                SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
                if (salesSlip == null) return;

                this.uGrid_Details.InitializeLayout -= new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
                this.uGrid_Details.DataSource = this._salesDetailDataTable;
                this.uGrid_Details.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
                
                if ((salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                    (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
                {
                    this.tToolbarsManager_Main.Enabled = false;
                }
                else
                {
                    this.tToolbarsManager_Main.Enabled = true;
                }

                // グリッド列表示非表示設定処理
                this.SettingGridColVisible(StatusType.SalesGoodsCd, salesSlip.SalesGoodsCd);
                this.SettingGridColVisible(StatusType.AcptAnOdrStatusAndSalesSlipCd, salesSlip.AcptAnOdrStatus * 10 + salesSlip.SalesSlipCd);
                this.SettingGridColVisible(StatusType.InputChange, 0);
                this.ChangeInputType(0);

                // グリッドヘッダ情報設定処理
                this.SettingGridHeader(salesSlip);

                // 描画が必要な明細件数を取得する。
                int cnt = this._salesDetailDataTable.Count;

                // 各行ごとの設定
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i, salesSlip);
                }

                // 表示用行番号調整処理
                this._salesSlipInputAcs.AdjustRowNo();

            }
            finally
            {
            }
        }

        /// <summary>
        /// グリッドヘッダ情報設定
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <br>Update Note: 2010/01/27 張凱 受注数の入力制御を行う対応</br>
        private void SettingGridHeader(SalesSlip salesSlip)
        {
            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlip.AcptAnOdrStatusDisplay)
            {
                //----------------------------------------------
                // 見積
                //----------------------------------------------
                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                    if (salesSlip.EstimateDivide == 1)
                    {
                        // 通常見積
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName].Header.Caption = "見積数"; // 出荷数
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].Header.Caption = string.Empty; // 受注数
                    }
                    else
                    {
                        // 単価見積
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName].Header.Caption = string.Empty; // 出荷数
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].Header.Caption = string.Empty; // 受注数
                    }
                    break;
                //----------------------------------------------
                // 売上
                // 出荷
                //----------------------------------------------
                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                    switch ((SalesSlipInputAcs.SalesSlipCd)salesSlip.SalesSlipCd)
                    {
                        case SalesSlipInputAcs.SalesSlipCd.Sales:
                            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName].Header.Caption = "出荷数"; // 出荷数
                            // --- UPD 2010/01/27 -------------->>>>>
                            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].Header.Caption = "受注数"; // 受注数
                            if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrInputDiv == 1) // 売上全体設定マスタ 受注数入力 0:しない　1:する)
                            {
                                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].Header.Caption = "受注数"; // 受注数
                            }
                            else
                            {
                                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].Header.Caption = string.Empty; // 受注数
                            }
                            // --- UPD 2010/01/27 --------------<<<<<
                            break;
                        case SalesSlipInputAcs.SalesSlipCd.RetGoods:
                            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName].Header.Caption = "出荷数"; // 出荷数
                            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName].Header.Caption = string.Empty; // 受注数
                            break;
                    }
                    break;
            }

            // 原単価、原価率
            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd)
            {
                // しない
                case 0:
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Header.Caption = string.Empty;
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].Header.Caption = string.Empty;
                    break;
                // する
                case 1:
                    if (this._salesSlipInputAcs.CostDisplay == false) // HOMEキーによる制御
                    {
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Header.Caption = string.Empty;
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].Header.Caption = string.Empty;
                    }
                    else
                    {
                        if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                        {
                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost)
                            {
                                // 未使用
                                case 2:
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Header.Caption = string.Empty;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].Header.Caption = string.Empty;
                                    break;
                                default:
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Header.Caption = this._salesDetailDataTable.SalesUnitCostColumn.Caption;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].Header.Caption = this._salesDetailDataTable.CostRateColumn.Caption;
                                    break;
                            }
                        }
                        else
                        {
                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost)
                            {
                                // 未使用
                                case 2:
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Header.Caption = string.Empty;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].Header.Caption = string.Empty;
                                    break;
                                default:
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Header.Caption = this._salesDetailDataTable.SalesUnitCostColumn.Caption;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.CostRateColumn.ColumnName].Header.Caption = this._salesDetailDataTable.CostRateColumn.Caption;
                                    break;
                            }
                        }
                    }

                    break;
            }

            // 明細備考
            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().DtlNoteDispDiv)
            {
                // 入力あり
                case 0:
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DtlNoteColumn.ColumnName].Header.Caption = this._salesDetailDataTable.DtlNoteColumn.Caption;
                    break;
                // 非表示
                case 1:
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DtlNoteColumn.ColumnName].Header.Caption = string.Empty;
                    break;
                default:
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.DtlNoteColumn.ColumnName].Header.Caption = this._salesDetailDataTable.DtlNoteColumn.Caption;
                    break;
            }

            // 得意先注番
            switch (this._salesSlipInputAcs.SalesSlip.CustOrderNoDispDiv)
            {
                // 表示しない
                case 0:
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].Header.Caption = string.Empty;
                    break;
                // 表示する
                case 1:
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].Header.Caption = this._salesDetailDataTable.PartySlipNumDtlColumn.Caption;
                    break;
                default:
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName].Header.Caption = this._salesDetailDataTable.PartySlipNumDtlColumn.Caption;
                    break;
            }

        }

        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <param name="salesSlip">仕入データクラスオブジェクト</param>
        /// <br>Update Note: 2010/01/27 張凱 受注数の入力制御を行う対応</br>
        /// <br>　　　　　　　　　　　　　　 品名が入力されている行でBLコード検索を行うと次行に検索内容が設定される対応</br>
        private void SettingGridRow(int rowIndex, SalesSlip salesSlip)
        {
            if (salesSlip == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            switch ((SalesSlipInputAcs.SalesGoodsCd)salesSlip.SalesGoodsCd)
            {
                #region 商品
                //-----------------------------------------------------------------------------
                // 商品
                //-----------------------------------------------------------------------------
                case SalesSlipInputAcs.SalesGoodsCd.Goods:
                    {
                        // 行番号
                        int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;

                        // 品名
                        string goodsName = this._salesDetailDataTable[rowIndex].GoodsName;

                        // 品番
                        string goodsNo = this._salesDetailDataTable[rowIndex].GoodsNo;

                        // 商品種別
                        int goodsKindCode = this._salesDetailDataTable[rowIndex].GoodsKindCode;

                        // 変更可能ステータス
                        int editStatus = this._salesDetailDataTable[rowIndex].EditStatus;

                        // 行ステータス
                        int rowStatus = this._salesDetailDataTable[rowIndex].RowStatus;

                        // 受注数
                        double acceptAnOrderCntDisplay = this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay;

                        // 出荷数
                        double shipmentCntDisplay = this._salesDetailDataTable[rowIndex].ShipmentCntDisplay;
                        double shipmentCnt = this._salesDetailDataTable[rowIndex].ShipmentCnt;

                        // 売上伝票区分(明細)
                        int salesSlipCdDtl = this._salesDetailDataTable[rowIndex].SalesSlipCdDtl;

                        // 指定行の全ての列に対して設定を行う。
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // セル情報を取得
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                            if (cell == null) continue;

                            // アンダーラインを全てのセルに対して非表示とする
                            cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                            if ((salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                                (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
                            {
                                #region ●入力モード(読み取り専用or締め済み)
                                //------------------------------------------------
                                // 入力モード(読み取り専用or締め済み)
                                //------------------------------------------------
                                // 商品名未入力
                                if (string.IsNullOrEmpty(goodsName.Trim()))
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                                }
                                else
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                                }
                                #endregion
                            }
                            else
                            {
                                #region 全項目無効
                                //------------------------------------------------
                                // 全項目無効
                                //------------------------------------------------
                                if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AllDisable)
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                                    #region メモ入力
                                    if (col.Key == this._salesDetailDataTable.SlipMemoExistColumn.ColumnName)
                                    {
                                        // メモ存在チェック(メモ有無イメージ設定)
                                        if (this._salesSlipInputAcs.SlipMemoInputCheck(salesRowNo) == true)
                                        {
                                            this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = this._guideButtonImage;
                                        }
                                        else
                                        {
                                            this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = null;
                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                #region 参照のみ
                                //------------------------------------------------
                                // 参照のみ
                                //------------------------------------------------
                                else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AllReadOnly) // 参照のみ
                                {
                                    if (col.Key == this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName)
                                    {
                                        //
                                    }
                                    else if (col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName)
                                    {
                                        cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                    #region メモ入力
                                    else if (col.Key == this._salesDetailDataTable.SlipMemoExistColumn.ColumnName)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可

                                        // メモ存在チェック(メモ有無イメージ設定)
                                        if (this._salesSlipInputAcs.SlipMemoInputCheck(salesRowNo) == true)
                                        {
                                            this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = this._guideButtonImage;
                                        }
                                        else
                                        {
                                            this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = null;
                                        }
                                    }
                                    #endregion
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }


                                }
                                #endregion

                                #region 数量のみ編集可
                                //------------------------------------------------
                                // 数量のみ編集可
                                //------------------------------------------------
                                else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_ShipmentCountOnly) // 出荷数のみ編集可能
                                {
                                    // 数量 明細備考
                                    if ((col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.DtlNoteColumn.ColumnName))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                    }
                                    #region 倉庫
                                    else if (col.Key == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName)          // 倉庫コード
                                    {
                                        if ((this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetGoodsStockEtyDiv == 0) &&   // 返品時在庫登録区分(0:する 1:しない)
                                            (salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) &&       // 返品
                                            (this._salesDetailDataTable[rowIndex].SalesSlipDtlNumSrc != 0) &&               // 元データあり
                                            (salesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum))            // 新規登録
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                        }
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                                        }
                                    }
                                    #endregion

                                    #region メモ入力
                                    //-----------------------------------------------------------------------------
                                    // メモ入力
                                    //-----------------------------------------------------------------------------
                                    else if (col.Key == this._salesDetailDataTable.SlipMemoExistColumn.ColumnName)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可

                                        // メモ存在チェック(メモ有無イメージ設定)
                                        if (this._salesSlipInputAcs.SlipMemoInputCheck(salesRowNo) == true)
                                        {
                                            this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = this._guideButtonImage;
                                        }
                                        else
                                        {
                                            this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = null;
                                        }
                                    }
                                    #endregion

                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                                    }
                                }
                                #endregion

                                #region 計上新規
                                //------------------------------------------------
                                // 計上新規
                                //------------------------------------------------
                                else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
                                {
                                    if ((col.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName) ||                 // 品番
                                        (col.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName) ||            // メーカー
                                        (col.Key == this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName) ||           // 純優区分
                                        (col.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName) ||              // BLコード
                                        (col.Key == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName) ||           // 倉庫コード
                                        (col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName) ||       // 売上金額
                                        (col.Key == this._salesDetailDataTable.CostColumn.ColumnName))                      // 原価金額
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                                    }

                                    #region 受注数
                                    // 「受注数」は見積計上時のみ編集可能
                                    else if (col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName) // 受注数
                                    {

                                        if (this._salesDetailDataTable[rowIndex].AcptAnOdrStatusSrc == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) // 
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                        }
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                                        }
                                        if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                        {
                                            // 発注選択済み明細判定
                                            if (this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                        }
                                    }
                                    #endregion

                                    #region 出荷数
                                    else if (col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName) // 受注数
                                    {
                                        // 発注選択済み明細判定
                                        if (this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                        }
                                    }
                                    #endregion

                                    #region 定価
                                    //-----------------------------------------------------------------------------
                                    // 定価
                                    //-----------------------------------------------------------------------------
                                    else if (col.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
                                    {
                                        switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivLPrice)
                                        {
                                            // 修正可能
                                            case 0:
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                break;
                                            // 修正不可
                                            case 1:
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                break;
                                            default:
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                break;
                                        }
                                    }
                                    #endregion

                                    #region 原単価／原価率
                                    //-----------------------------------------------------------------------------
                                    // 原単価／原価率
                                    //-----------------------------------------------------------------------------
                                    else if ((col.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                             (col.Key == this._salesDetailDataTable.CostRateColumn.ColumnName))
                                    {
                                        switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd)
                                        {
                                            // しない
                                            case 0:
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                break;
                                            // する
                                            case 1:
                                                if (this._salesSlipInputAcs.CostDisplay == false) // HOMEキーによる制御
                                                {
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                }
                                                else
                                                {
                                                    if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                                                    {
                                                        switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost)
                                                        {
                                                            // 修正可能
                                                            case 0:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                break;
                                                            // 修正不可
                                                            case 1:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                break;
                                                            // 未使用
                                                            case 2:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                break;
                                                            // 在庫時不可
                                                            case 3:
                                                                if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                                {
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                }
                                                                else
                                                                {
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                }
                                                                break;
                                                            default:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost)
                                                        {
                                                            // 修正可能
                                                            case 0:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                break;
                                                            // 修正不可
                                                            case 1:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                break;
                                                            // 未使用
                                                            case 2:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                break;
                                                            // 在庫時不可
                                                            case 3:
                                                                if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                                {
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                }
                                                                else
                                                                {
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                }
                                                                break;
                                                            default:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                break;
                                                        }
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    #endregion

                                    #region 売単価／売価率
                                    //-----------------------------------------------------------------------------
                                    // 売単価／売価率
                                    //-----------------------------------------------------------------------------
                                    else if ((col.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                                       (col.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName) ||
                                       (col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName))
                                    {
                                        if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                                        {
                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivUnPrc)
                                            {
                                                // 修正可能
                                                case 0:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                                // 修正不可
                                                case 1:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                // 在庫時不可
                                                case 2:
                                                    if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                    else
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    }
                                                    break;
                                                default:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivUnPrc)
                                            {
                                                // 修正可能
                                                case 0:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                                // 修正不可
                                                case 1:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                // 在庫時不可
                                                case 2:
                                                    if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                    else
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    }
                                                    break;
                                                default:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                            }
                                        }
                                    }
                                    #endregion

                                    #region 納品完了予定日
                                    //-----------------------------------------------------------------------------
                                    // 納品完了予定日
                                    //-----------------------------------------------------------------------------
                                    else if (col.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
                                    {
                                        //>>>2010/02/26
                                        //if (acceptAnOrderCntDisplay != 0)
                                        if (((acceptAnOrderCntDisplay != 0) ||
                                             (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) ||
                                             (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.SearchEstimate)) &&
                                            (salesSlip.OnlineKindDiv != 1))
                                        //<<<2010/02/26
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                        }
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                        }
                                    }
                                    #endregion

                                    #region 得意先注番
                                    //-----------------------------------------------------------------------------
                                    // 得意先注番
                                    //-----------------------------------------------------------------------------
                                    else if (col.Key == this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName)
                                    {
                                        switch (salesSlip.CustOrderNoDispDiv)
                                        {
                                            // 表示しない
                                            case 0:
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                break;
                                            // 表示する
                                            case 1:
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                break;
                                            default:
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                break;
                                        }
                                    }
                                    #endregion

                                    #region メモ入力
                                    //-----------------------------------------------------------------------------
                                    // メモ入力
                                    //-----------------------------------------------------------------------------
                                    else if (col.Key == this._salesDetailDataTable.SlipMemoExistColumn.ColumnName)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可

                                        // メモ存在チェック(メモ有無イメージ設定)
                                        if (this._salesSlipInputAcs.SlipMemoInputCheck(salesRowNo) == true)
                                        {
                                            this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = this._guideButtonImage;
                                        }
                                        else
                                        {
                                            this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = null;
                                        }
                                    }
                                    #endregion

                                    #region その他
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                    }
                                    #endregion

                                    #region 発注情報入力不可
                                    // 納品区分
                                    if ((col.Key == this._salesDetailDataTable.UOEDeliGoodsDivColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName))
                                    {
                                        if (!this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                        else
                                        {
                                            if (!this._salesSlipInputAcs.CheckEnabledDeliveredGoodsDiv(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                            }
                                        }
                                    }
                                    // Ｈ納品区分
                                    if ((col.Key == this._salesDetailDataTable.FollowDeliGoodsDivColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName))
                                    {
                                        if (!this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                        else
                                        {
                                            if (!this._salesSlipInputAcs.CheckEnabledFollowDeliGoodsDiv(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                            }
                                        }
                                    }
                                    // 指定拠点
                                    if ((col.Key == this._salesDetailDataTable.UOEResvdSectionColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName))
                                    {
                                        if (!this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                        else
                                        {
                                            if (!this._salesSlipInputAcs.CheckEnabledUOEResvdSection(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                            }
                                        }
                                    }
                                    // ＢＯ区分、発注先、発注数
                                    if ((col.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName))
                                    {
                                        if ((this._salesSlipInputAcs.ExistStockTempForStock(salesRowNo)) ||
                                            (!this._salesSlipInputAcs.ExistSalesDetailSupplierCd(salesRowNo)) ||
                                            (!this._salesSlipInputAcs.ExistSalesDetailEnableOdrMakerCd(salesRowNo)) ||
                                            (editStatus == SalesSlipInputAcs.ctEDITSTATUS_GoodsDiscount))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                    }
                                    #endregion

                                    #region 仕入情報入力不可
                                    if ((col.Key == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.StockDateColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName))
                                    {
                                        if ((this._salesSlipInputAcs.ExistOrderInfo(salesRowNo)) ||
                                            (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo)) ||
                                            (!this._salesSlipInputAcs.ExistSalesDetail(salesRowNo)) ||
                                            (!this._salesSlipInputAcs.ExistSalesDetailShipmentCnt(salesRowNo)) ||
                                            (editStatus == SalesSlipInputAcs.ctEDITSTATUS_GoodsDiscount))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                    }
                                    #endregion

                                }
                                #endregion

                                #region 通常修正、計上編集
                                //------------------------------------------------
                                // 通常修正、計上編集
                                //------------------------------------------------
                                else if ((editStatus == SalesSlipInputAcs.ctEDITSTATUS_ExistSlip) ||
                                         (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpEdit))
                                {
                                    if (this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                    {
                                        // 発注情報存在時は、全項目変更不可
                                        if ((col.Key == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.StockDateColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName))
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
                                        if ((col.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName) ||                 // 品番
                                            (col.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName) ||            // メーカー
                                            (col.Key == this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName) ||           // 純優区分
                                            (col.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName) ||             // BLコード
                                            (col.Key == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName) ||           // 倉庫コード
                                            (col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName) ||       // 売上金額
                                            (col.Key == this._salesDetailDataTable.CostColumn.ColumnName))                      // 原価金額
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可
                                        }

                                        #region 受注数
                                        //-----------------------------------------------------------------------------
                                        // 受注数
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName)
                                        {
                                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlip.AcptAnOdrStatusDisplay)
                                            {
                                                //------------------------------------------------
                                                // 見積 見積単価
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                //------------------------------------------------
                                                // 売上 出荷
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                                    if ((salesSlip.AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) &&
                                                        (salesSlip.SalesSlipNum.PadLeft(9, '0') != SalesSlipInputAcs.ctDefaultSalesSlipNum))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                    else
                                                    {
                                                        switch ((SalesSlipInputAcs.SalesSlipCd)salesSlip.SalesSlipCd)
                                                        {
                                                            case SalesSlipInputAcs.SalesSlipCd.Sales:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                                                break;
                                                            case SalesSlipInputAcs.SalesSlipCd.RetGoods:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                break;
                                                        }
                                                    }
                                                    break;
                                            }

                                            // 発注選択済み明細判定
                                            if (this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                        }
                                        #endregion

                                        #region 出荷数
                                        //-----------------------------------------------------------------------------
                                        // 出荷数
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName)
                                        {
                                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlip.AcptAnOdrStatusDisplay)
                                            {
                                                //------------------------------------------------
                                                // 見積
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                                    break;
                                                //------------------------------------------------
                                                // 単価見積
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                //------------------------------------------------
                                                // 売上 出荷
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                                    if ((salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) &&
                                                        (salesSlip.SalesSlipNum.PadLeft(9, '0') != SalesSlipInputAcs.ctDefaultSalesSlipNum))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                    else
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                                    }
                                                    break;
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                                    break;
                                            }

                                            // 発注選択済み明細判定
                                            if (this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                        }
                                        #endregion

                                        #region 定価
                                        //-----------------------------------------------------------------------------
                                        // 定価
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
                                        {
                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivLPrice)
                                            {
                                                // 修正可能
                                                case 0:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                                // 修正不可
                                                case 1:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                default:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region 原単価／原価率
                                        //-----------------------------------------------------------------------------
                                        // 原単価／原価率
                                        //-----------------------------------------------------------------------------
                                        else if ((col.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                                 (col.Key == this._salesDetailDataTable.CostRateColumn.ColumnName))
                                        {
                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd)
                                            {
                                                // しない
                                                case 0:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                // する
                                                case 1:
                                                    if (this._salesSlipInputAcs.CostDisplay == false) // HOMEキーによる制御
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                    else
                                                    {
                                                        if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                                                        {
                                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost)
                                                            {
                                                                // 修正可能
                                                                case 0:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    break;
                                                                // 修正不可
                                                                case 1:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    break;
                                                                // 未使用
                                                                case 2:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    break;
                                                                // 在庫時不可
                                                                case 3:
                                                                    if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                                    {
                                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    }
                                                                    else
                                                                    {
                                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    }
                                                                    break;
                                                                default:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost)
                                                            {
                                                                // 修正可能
                                                                case 0:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    break;
                                                                // 修正不可
                                                                case 1:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    break;
                                                                // 未使用
                                                                case 2:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    break;
                                                                // 在庫時不可
                                                                case 3:
                                                                    if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                                    {
                                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    }
                                                                    else
                                                                    {
                                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    }
                                                                    break;
                                                                default:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region 売単価／売価率
                                        //-----------------------------------------------------------------------------
                                        // 売単価／売価率
                                        //-----------------------------------------------------------------------------
                                        else if ((col.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                                       (col.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName) ||
                                       (col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName))
                                        {
                                            if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                                            {
                                                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivUnPrc)
                                                {
                                                    // 修正可能
                                                    case 0:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        break;
                                                    // 修正不可
                                                    case 1:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                        break;
                                                    // 在庫時不可
                                                    case 2:
                                                        if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                        {
                                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                        }
                                                        else
                                                        {
                                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        }
                                                        break;
                                                    default:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivUnPrc)
                                                {
                                                    // 修正可能
                                                    case 0:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        break;
                                                    // 修正不可
                                                    case 1:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                        break;
                                                    // 在庫時不可
                                                    case 2:
                                                        if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                        {
                                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                        }
                                                        else
                                                        {
                                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        }
                                                        break;
                                                    default:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        break;
                                                }
                                            }
                                        }
                                        #endregion

                                        #region 納品完了予定日
                                        //-----------------------------------------------------------------------------
                                        // 納品完了予定日
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
                                        {
                                            //>>>2010/02/26
                                            //if (acceptAnOrderCntDisplay != 0)
                                            if (((acceptAnOrderCntDisplay != 0) ||
                                                 (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) ||
                                                 (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.SearchEstimate)) &&
                                                (salesSlip.OnlineKindDiv != 1))
                                            //<<<2010/02/26
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                            }
                                            else
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                        }
                                        #endregion

                                        #region 得意先注番
                                        //-----------------------------------------------------------------------------
                                        // 得意先注番
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName)
                                        {
                                            switch (salesSlip.CustOrderNoDispDiv)
                                            {
                                                // 表示しない
                                                case 0:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                // 表示する
                                                case 1:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                                default:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region メモ入力
                                        //-----------------------------------------------------------------------------
                                        // メモ入力
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.SlipMemoExistColumn.ColumnName)
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可

                                            // メモ存在チェック(メモ有無イメージ設定)
                                            if (this._salesSlipInputAcs.SlipMemoInputCheck(salesRowNo) == true)
                                            {
                                                this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = this._guideButtonImage;
                                            }
                                            else
                                            {
                                                this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = null;
                                            }
                                        }
                                        #endregion

                                        #region その他
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                        }
                                        #endregion

                                        #region 発注情報入力不可
                                        if ((col.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.UOEDeliGoodsDivColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.FollowDeliGoodsDivColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.UOEResvdSectionColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                        #endregion

                                        #region 仕入情報入力不可
                                        if ((col.Key == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.StockDateColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName))
                                        {
                                            if ((this._salesSlipInputAcs.ExistOrderInfo(salesRowNo)) ||
                                                (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo)) ||
                                                (!this._salesSlipInputAcs.ExistSalesDetail(salesRowNo)) ||
                                                (!this._salesSlipInputAcs.ExistSalesDetailShipmentCnt(salesRowNo)) ||
                                                (editStatus == SalesSlipInputAcs.ctEDITSTATUS_GoodsDiscount))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                #endregion

                                #region 行値引
                                //------------------------------------------------
                                // 行値引
                                //------------------------------------------------
                                else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_RowDiscount)
                                {
                                    // 売上金額、品名、販売区分は入力可
                                    if ((col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.GoodsNameColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.SalesCodeColumn.ColumnName))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    // 「課税・非課税区分」は課税・非課税区分変更可能フラグを参照
                                    else if (col.Key == this._salesDetailDataTable.TaxDivColumn.ColumnName)
                                    {
                                        cell.Activation = GetTaxActivation(rowIndex);
                                    }
                                    else if ((col.Key == this._salesDetailDataTable.TaxDivColumn.ColumnName) ||
                                             (col.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                                             (col.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                             (col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName) ||
                                             (col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName))
                                    {
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                }
                                #endregion

                                #region 注釈
                                //------------------------------------------------
                                // 注釈
                                //------------------------------------------------
                                else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_Annotation)
                                {
                                    // 品名は入力可
                                    if (col.Key == this._salesDetailDataTable.GoodsNameColumn.ColumnName)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    // 「課税・非課税区分」は課税・非課税区分変更可能フラグを参照
                                    else if (col.Key == this._salesDetailDataTable.TaxDivColumn.ColumnName)
                                    {
                                        cell.Activation = GetTaxActivation(rowIndex);
                                    }
                                    else if ((col.Key == this._salesDetailDataTable.TaxDivColumn.ColumnName))
                                    {
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }
                                }
                                #endregion

                                #region 通常入力
                                //------------------------------------------------
                                // 通常入力
                                //------------------------------------------------
                                else
                                {
                                    #region 明細行数
                                    //-----------------------------------------------------------------------------
                                    // 明細行数
                                    //-----------------------------------------------------------------------------
                                    if (col.Key == this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                    }
                                    #endregion

                                    #region 品番
                                    //-----------------------------------------------------------------------------
                                    // 品番
                                    //-----------------------------------------------------------------------------
                                    else if (col.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
                                    {
                                        if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                        }
                                        else
                                        {
                                            if ((string.IsNullOrEmpty(goodsNo)) && (string.IsNullOrEmpty(goodsName)))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                                            }
                                            else
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                            }
                                        }
                                    }
                                    #endregion

                                    #region 品名
                                    //-----------------------------------------------------------------------------
                                    // 品名
                                    //-----------------------------------------------------------------------------
                                    else if (col.Key == this._salesDetailDataTable.GoodsNameColumn.ColumnName)
                                    {
                                        //cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能 // DEL 2010/01/27
                                        // ---------- ADD 2010/01/27 ---------->>>>>>>>>>
                                        if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
                                        {
                                            //cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                                            if (!CheckRowEffective(rowIndex))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                                            }
                                            else
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                            }
                                        }
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                            
                                        }
                                        // ---------- ADD 2010/01/27 ----------<<<<<<<<<<
                                    }
                                    #endregion

                                    #region BLコード
                                    //-----------------------------------------------------------------------------
                                    // BLコード
                                    //-----------------------------------------------------------------------------
                                    else if (col.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                    }
                                    #endregion

                                    #region その他
                                    //-----------------------------------------------------------------------------
                                    // その他
                                    //-----------------------------------------------------------------------------
                                    else
                                    {
                                        #region 品番必須モード＆品番入力なし
                                        //-----------------------------------------------------------------------------
                                        // 品番必須モードand(品番入力なしor品名入力なし)
                                        //-----------------------------------------------------------------------------
                                        if ((this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo) &&
                                            ((string.IsNullOrEmpty(goodsNo)) ||
                                             (string.IsNullOrEmpty(goodsName))))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                                        }
                                        #endregion

                                        #region ！品番必須モード＆品番入力なし＆品名入力なし
                                        //-----------------------------------------------------------------------------
                                        // ！品番必須モード＆品番入力なし＆品名入力なし
                                        //-----------------------------------------------------------------------------
                                        else if ((this._salesSlipInputInitDataAcs.InputMode != SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo) &&
                                                 (string.IsNullOrEmpty(goodsName)))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                                        }
                                        #endregion

                                        #region 受注数
                                        //-----------------------------------------------------------------------------
                                        // 受注数
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName)
                                        {
                                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlip.AcptAnOdrStatusDisplay)
                                            {
                                                //------------------------------------------------
                                                // 見積 見積単価
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                //------------------------------------------------
                                                // 売上 出荷
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                                    if ((salesSlip.AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) &&
                                                        (salesSlip.SalesSlipNum.PadLeft(9, '0') != SalesSlipInputAcs.ctDefaultSalesSlipNum))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                    else
                                                    {
                                                        switch ((SalesSlipInputAcs.SalesSlipCd)salesSlip.SalesSlipCd)
                                                        {
                                                            case SalesSlipInputAcs.SalesSlipCd.Sales:
                                                                // --- UPD 2010/01/27 -------------->>>>>
                                                                //cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                                                if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrInputDiv == 1) // 売上全体設定マスタ 受注数入力  0:しない　1:する)
                                                                {
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                                                }
                                                                else
                                                                {
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                }
                                                                // --- UPD 2010/01/27 --------------<<<<<
                                                                break;
                                                            case SalesSlipInputAcs.SalesSlipCd.RetGoods:
                                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                break;
                                                        }
                                                    }
                                                    break;
                                            }

                                            // 商品値引き判定                                
                                            if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_GoodsDiscount)
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }

                                            // 発注選択済み明細判定
                                            if (this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                        }
                                        #endregion

                                        #region 出荷数
                                        //-----------------------------------------------------------------------------
                                        // 出荷数
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName)
                                        {
                                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlip.AcptAnOdrStatusDisplay)
                                            {
                                                //------------------------------------------------
                                                // 見積
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                                    break;
                                                //------------------------------------------------
                                                // 単価見積
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                //------------------------------------------------
                                                // 売上 出荷
                                                //------------------------------------------------
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                                    if ((salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) &&
                                                        (salesSlip.SalesSlipNum.PadLeft(9, '0') != SalesSlipInputAcs.ctDefaultSalesSlipNum))
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                    else
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                                    }
                                                    break;
                                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                                    break;
                                            }

                                            // 発注選択済み明細判定
                                            if (this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                        }
                                        #endregion

                                        #region 納品完了予定日
                                        //-----------------------------------------------------------------------------
                                        // 納品完了予定日
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
                                        {
                                            //>>>2010/02/26
                                            //if (acceptAnOrderCntDisplay != 0)]
                                            if (((acceptAnOrderCntDisplay != 0) ||
                                                 (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) ||
                                                 (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.SearchEstimate)) &&
                                                (salesSlip.OnlineKindDiv != 1))
                                            //<<<2010/02/26
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                            }
                                            else
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                        }
                                        #endregion

                                        #region 明細備考
                                        //-----------------------------------------------------------------------------
                                        // 明細備考
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.DtlNoteColumn.ColumnName)
                                        {
                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().DtlNoteDispDiv)
                                            {
                                                // 入力あり
                                                case 0:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                                // 非表示
                                                case 1:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                default:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region 得意先注番
                                        //-----------------------------------------------------------------------------
                                        // 得意先注番
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName)
                                        {
                                            switch (salesSlip.CustOrderNoDispDiv)
                                            {
                                                // 表示しない
                                                case 0:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                // 表示する
                                                case 1:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                                default:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region メモ入力
                                        //-----------------------------------------------------------------------------
                                        // メモ入力
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.SlipMemoExistColumn.ColumnName)
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 編集不可

                                            // メモ存在チェック(メモ有無イメージ設定)
                                            if (this._salesSlipInputAcs.SlipMemoInputCheck(salesRowNo) == true)
                                            {
                                                this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = this._guideButtonImage;
                                            }
                                            else
                                            {
                                                this.uGrid_Details.DisplayLayout.Rows[rowIndex].Cells[this._salesDetailDataTable.SlipMemoExistColumn.ColumnName].Appearance.Image = null;
                                            }
                                        }
                                        #endregion

                                        #region 売上金額
                                        //-----------------------------------------------------------------------------
                                        // 売上金額
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName)
                                        {
                                            if ((this._salesDetailDataTable[rowIndex].ShipmentCntDisplay != 0) &&
                                                (this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay != 0) &&
                                                (this._salesDetailDataTable[rowIndex].AcceptAnOrderCntForOrder != 0))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                            }
                                            else
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                            }
                                        }
                                        #endregion

                                        #region 定価
                                        //-----------------------------------------------------------------------------
                                        // 定価
                                        //-----------------------------------------------------------------------------
                                        else if (col.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
                                        {
                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivLPrice)
                                            {
                                                // 修正可能
                                                case 0:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                                // 修正不可
                                                case 1:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                default:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region 原単価／原価率
                                        //-----------------------------------------------------------------------------
                                        // 原単価／原価率
                                        //-----------------------------------------------------------------------------
                                        else if ((col.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                                 (col.Key == this._salesDetailDataTable.CostRateColumn.ColumnName))
                                        {
                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd)
                                            {
                                                // しない
                                                case 0:
                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    break;
                                                // する
                                                case 1:
                                                    if (this._salesSlipInputAcs.CostDisplay == false) // HOMEキーによる制御
                                                    {
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                    }
                                                    else
                                                    {
                                                        if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                                                        {
                                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost)
                                                            {
                                                                // 修正可能
                                                                case 0:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    break;
                                                                // 修正不可
                                                                case 1:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    break;
                                                                // 未使用
                                                                case 2:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    break;
                                                                // 在庫時不可
                                                                case 3:
                                                                    if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                                    {
                                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    }
                                                                    else
                                                                    {
                                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    }
                                                                    break;
                                                                default:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost)
                                                            {
                                                                // 修正可能
                                                                case 0:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    break;
                                                                // 修正不可
                                                                case 1:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    break;
                                                                // 未使用
                                                                case 2:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    break;
                                                                // 在庫時不可
                                                                case 3:
                                                                    if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                                    {
                                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                                    }
                                                                    else
                                                                    {
                                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    }
                                                                    break;
                                                                default:
                                                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region 売単価／売価率
                                        //-----------------------------------------------------------------------------
                                        // 売単価／売価率
                                        //-----------------------------------------------------------------------------
                                        else if ((col.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName))
                                        {
                                            if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                                            {
                                                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivUnPrc)
                                                {
                                                    // 修正可能
                                                    case 0:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        break;
                                                    // 修正不可
                                                    case 1:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                        break;
                                                    // 在庫時不可
                                                    case 2:
                                                        if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                        {
                                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                        }
                                                        else
                                                        {
                                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        }
                                                        break;
                                                    default:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivUnPrc)
                                                {
                                                    // 修正可能
                                                    case 0:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        break;
                                                    // 修正不可
                                                    case 1:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                        break;
                                                    // 在庫時不可
                                                    case 2:
                                                        if (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo))
                                                        {
                                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                                        }
                                                        else
                                                        {
                                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        }
                                                        break;
                                                    default:
                                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                                        break;
                                                }
                                            }
                                        }
                                        #endregion

                                        #region その他
                                        //-----------------------------------------------------------------------------
                                        // その他
                                        //-----------------------------------------------------------------------------
                                        else
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                                        }
                                        #endregion

                                    }
                                    #endregion

                                    #region 発注情報入力不可
                                    // 納品区分
                                    if ((col.Key == this._salesDetailDataTable.UOEDeliGoodsDivColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName))
                                    {
                                        if (!this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                        else
                                        {
                                            if (!this._salesSlipInputAcs.CheckEnabledDeliveredGoodsDiv(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                            }
                                        }
                                    }
                                    // Ｈ納品区分
                                    if ((col.Key == this._salesDetailDataTable.FollowDeliGoodsDivColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName))
                                    {
                                        if (!this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                        else
                                        {
                                            if (!this._salesSlipInputAcs.CheckEnabledFollowDeliGoodsDiv(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                            }
                                        }
                                    }
                                    // 指定拠点
                                    if ((col.Key == this._salesDetailDataTable.UOEResvdSectionColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName))
                                    {
                                        if (!this._salesSlipInputAcs.ExistOrderInfo(salesRowNo))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                        else
                                        {
                                            if (!this._salesSlipInputAcs.CheckEnabledUOEResvdSection(salesRowNo))
                                            {
                                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                            }
                                        }
                                    }
                                    // ＢＯ区分、発注先、発注数
                                    if ((col.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName))
                                    {
                                        if ((this._salesSlipInputAcs.ExistStockTempForStock(salesRowNo)) ||
                                            (!this._salesSlipInputAcs.ExistSalesDetailSupplierCd(salesRowNo)) ||
                                            (!this._salesSlipInputAcs.ExistSalesDetailEnableOdrMakerCd(salesRowNo)) ||
                                            (editStatus == SalesSlipInputAcs.ctEDITSTATUS_GoodsDiscount))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                    }

                                    // 金額手入力時、発注不可
                                    if (this._salesDetailDataTable[rowIndex].SalesMoneyInputDiv == (int)SalesSlipInputAcs.SalesMoneyInputDiv.Input)
                                    {
                                        if ((col.Key == this._salesDetailDataTable.UOEDeliGoodsDivColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.FollowDeliGoodsDivColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.UOEResvdSectionColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                            (col.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                    }
                                    #endregion

                                    #region 仕入情報入力不可
                                    if ((col.Key == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.StockDateColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName))
                                    {
                                        if ((this._salesSlipInputAcs.ExistOrderInfo(salesRowNo)) ||
                                            (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(salesRowNo)) ||
                                            (!this._salesSlipInputAcs.ExistSalesDetail(salesRowNo)) ||
                                            (!this._salesSlipInputAcs.ExistSalesDetailShipmentCnt(salesRowNo)) ||
                                            (editStatus == SalesSlipInputAcs.ctEDITSTATUS_GoodsDiscount))
                                        {
                                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                        }
                                    }
                                    #endregion

                                    #region ユーザー設定項目別反映
                                    //-----------------------------------------------------------------------------
                                    // ユーザー設定項目別反映
                                    //-----------------------------------------------------------------------------
                                    if (!GetCellEnabled(col.Key))
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 編集不可
                                    }
                                    #endregion
                                }
                                #endregion
                            }

                            #region セキュリティ設定
                            // 数量
                            if ((col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName) ||
                                (col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName) ||
                                (col.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName))
                            {
                                if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.CountChange))
                                {
                                    if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                }
                            }

                            // 売単価、売価率、売上金額
                            if ((col.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                                (col.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName) ||
                                (col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName))
                            {
                                if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.UnitPriceChange))
                                {
                                    if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                }
                            }

                            // 原単価、原価率
                            if ((col.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                (col.Key == this._salesDetailDataTable.CostRateColumn.ColumnName))
                            {
                                if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.UnitCostChange))
                                {
                                    if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                }
                            }
                            #endregion

                            #region ●無効要素のテキストカラー設定
                            //------------------------------------------------
                            // 無効要素のテキストカラー設定
                            //------------------------------------------------
                            // 行値引、注釈以外
                            if ((editStatus != SalesSlipInputAcs.ctEDITSTATUS_RowDiscount) &&
                                (editStatus != SalesSlipInputAcs.ctEDITSTATUS_Annotation))
                            {
                                // 課税・非課税 単位 BLコード 仕入先コード 受注数 メーカーコード 商品属性 現在庫数 販売区分
                                if ((col.Key == this._salesDetailDataTable.TaxDivColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.StockDateColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) || // 2009/09/04 ADD
                                    (col.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName) || // 2009/09/04 ADD
                                    (col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName) || // 2009/09/04 ADD
                                    (col.Key == this._salesDetailDataTable.SalesCodeColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.GoodsMngNoColumn.ColumnName) || // 2010/02/26
                                    (col.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)) // ADD 2009/12/23
                                {
                                    if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled) &&
                                        (salesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Red))
                                    {
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                    }
                                    else
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

                                // 現在庫数
                                if (col.Key == this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName)
                                {
                                    if (string.IsNullOrEmpty(this._salesDetailDataTable[rowIndex].WarehouseCode.Trim()))
                                    {
                                        cell.Appearance.ForeColor = Color.Transparent;
                                    }
                                    else
                                    {
                                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                    }
                                }

                                #region 納品完了予定日
                                // 納品完了予定日
                                else if (col.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
                                {
                                    //>>>2010/02/26
                                    //if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                    //{
                                    //    cell.Appearance.ForeColor = Color.Transparent;
                                    //    cell.Appearance.ForeColorDisabled = Color.Transparent;
                                    //}
                                    //else
                                    //{
                                    //    if (acceptAnOrderCntDisplay == 0)
                                    //    {
                                    //        cell.Appearance.ForeColor = Color.Transparent;
                                    //        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                    //    }
                                    //    else
                                    //    {
                                    //        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                    //        cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled; ;
                                    //    }
                                    //}
                                    if ((salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) ||
                                        (salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment))
                                    {
                                        cell.Appearance.ForeColor = Color.Transparent;
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                    }
                                    else
                                    {
                                        if (acceptAnOrderCntDisplay == 0)
                                        {
                                            cell.Appearance.ForeColor = Color.Transparent;
                                            cell.Appearance.ForeColorDisabled = Color.Transparent;
                                        }
                                        else
                                        {
                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                            cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled; ;
                                        }
                                    }
                                    //<<<2010/02/26
                                }
                                #endregion

                                #region 明細備考
                                // 明細備考
                                else if (col.Key == this._salesDetailDataTable.DtlNoteColumn.ColumnName)
                                {
                                    if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                    {
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                    }
                                    else
                                    {
                                        switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().DtlNoteDispDiv)
                                        {
                                            // 入力あり
                                            case 0:
                                                cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                break;
                                            // 非表示
                                            case 1:
                                                cell.Appearance.ForeColor = Color.Transparent;
                                                break;
                                            default:
                                                cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                break;
                                        }
                                    }
                                }
                                #endregion

                                #region 得意先注番
                                // 得意先注番
                                else if (col.Key == this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName)
                                {
                                    switch (salesSlip.CustOrderNoDispDiv)
                                    {
                                        // 表示しない
                                        case 0:
                                            cell.Appearance.ForeColor = Color.Transparent;
                                            break;
                                        // 表示する
                                        case 1:
                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                            break;
                                        default:
                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                            break;
                                    }
                                }
                                #endregion

                                #region 原単価、原価率
                                // 原単価、原価率
                                else if ((col.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.CostRateColumn.ColumnName))
                                {
                                    switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd)
                                    {
                                        // しない
                                        case 0:
                                            cell.Appearance.ForeColor = Color.Transparent;
                                            cell.Appearance.ForeColorDisabled = Color.Transparent;
                                            break;
                                        // する
                                        case 1:
                                            if (this._salesSlipInputAcs.CostDisplay == false) // HOMEキーによる制御
                                            {
                                                cell.Appearance.ForeColor = Color.Transparent;
                                                cell.Appearance.ForeColorDisabled = Color.Transparent;
                                            }
                                            else
                                            {
                                                cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

                                                if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                                                {
                                                    switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost)
                                                    {
                                                        // 修正可能
                                                        case 0:
                                                        // 修正不可
                                                        case 1:
                                                        // 在庫時不可
                                                        case 3:
                                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                            break;
                                                        // 未使用
                                                        case 2:
                                                            cell.Appearance.ForeColor = Color.Transparent;
                                                            break;
                                                        default:
                                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost)
                                                    {
                                                        // 修正可能
                                                        case 0:
                                                        // 修正不可
                                                        case 1:
                                                        // 在庫時不可
                                                        case 3:
                                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                            break;
                                                        // 未使用
                                                        case 2:
                                                            cell.Appearance.ForeColor = Color.Transparent;
                                                            break;
                                                        default:
                                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                            break;
                                                    }
                                                }
                                            }
                                            break;
                                    }

                                    // --- ADD 2009/12/23 ---------->>>>>
                                    if (string.IsNullOrEmpty(goodsName))
                                    {
                                        cell.Appearance.ForeColor = Color.Transparent;
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                    }
                                    // --- ADD 2009/12/23 ----------<<<<<
                                }
                                #endregion

                                #region 発注情報入力不可
                                else if ((col.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.UOEDeliGoodsDivColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.FollowDeliGoodsDivColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.UOEResvdSectionColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName))
                                {
                                    if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                    {
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                    }
                                    else
                                    {
                                        cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                    }
                                }
                                #endregion

                                #region 仕入情報入力不可
                                // 仕入情報入力不可
                                else if ((col.Key == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.StockDateColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName))
                                {
                                    if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                    {
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                    }
                                    else
                                    {
                                        cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                    }
                                }
                                #endregion
                            }
                            else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AllDisable)
                            {
                                cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                            }
                            else
                            {
                                // 行値引、注釈
                                if ((col.Key != this._salesDetailDataTable.GoodsNameColumn.ColumnName) &&
                                    (col.Key != this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName))
                                {
                                    cell.Appearance.ForeColorDisabled = Color.Transparent;
                                }
                            }

                            if ((cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled) &&
                                (cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled))
                            {
                                //cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                                //if (cell.Appearance.ForeColor != Color.Transparent) cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                // コピー対象行
                                if (rowStatus == SalesSlipInputAcs.ctROWSTATUS_COPY)
                                {
                                    cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                    if (cell.Appearance.ForeColor != Color.Transparent) cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                }
                                // 切り取り対象行
                                else if (rowStatus == SalesSlipInputAcs.ctROWSTATUS_CUT)
                                {
                                    cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                    if (cell.Appearance.ForeColor != Color.Transparent) cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
                                }
                                else
                                {
                                    if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                                        (cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit))
                                    {
                                        if (cell.Appearance.ForeColor != Color.Transparent) cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                    }
                                }
                            }

                            //if ((cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled) &&
                            //    (cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled))
                            //{
                            //    cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                            //    if (cell.Appearance.ForeColor != Color.Transparent) cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                            //    // コピー対象行
                            //    if (rowStatus == SalesSlipInputAcs.ctROWSTATUS_COPY)
                            //    {
                            //        cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                            //        if (cell.Appearance.ForeColor != Color.Transparent) cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                            //    }
                            //    // 切り取り対象行
                            //    else if (rowStatus == SalesSlipInputAcs.ctROWSTATUS_CUT)
                            //    {
                            //        cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                            //        if (cell.Appearance.ForeColor != Color.Transparent) cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
                            //    }
                            //    else
                            //    {
                            //        cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                            //        if ((goodsKindCode == 38) || (goodsKindCode == 39))
                            //        {
                            //            if (cell.Appearance.ForeColor != Color.Transparent) cell.Appearance.ForeColor = ct_REDUCTION_FONT_COLOR;
                            //        }

                            //        if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                            //            (cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit))
                            //        {
                            //            if (cell.Appearance.ForeColor != Color.Transparent) cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                            //        }
                            //    }
                            //}

                            // 行番号の色変更
                            if (cell.Column.Key == this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName)
                            {
                                if ((salesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount) && (shipmentCnt != 0))
                                {
                                    // 商品値引行
                                    cell.Appearance.BackColor = ct_GOODSDISCOUNT_CELL_COLOR;
                                    cell.Appearance.BackColor2 = ct_GOODSDISCOUNT_CELL_COLOR;
                                    cell.Appearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
                                    cell.Appearance.ForeColor = ct_DISABLE_FONT_COLOR;
                                    cell.Appearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;

                                }
                                else if ((this._salesSlipInputAcs.ExistStockTempForStock(salesRowNo)) &&
                                         (this._salesSlipInputAcs.ExistSalesDetail(salesRowNo)))
                                {
                                    cell.Appearance.BackColor = ct_STOCK_BACKCOLOR;
                                    cell.Appearance.BackColor2 = ct_STOCK_BACKCOLOR2;
                                    cell.Appearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
                                    cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
                                    cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
                                }
                                else if ((this._salesSlipInputAcs.ExistOrderInfo(salesRowNo)) &&
                                         (this._salesSlipInputAcs.ExistSalesDetail(salesRowNo)))
                                {
                                    cell.Appearance.BackColor = ct_ORDER_BACKCOLOR;
                                    cell.Appearance.BackColor2 = ct_ORDER_BACKCOLOR2;
                                    cell.Appearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
                                    cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
                                    cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
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
                            #endregion

                            #region 返品、商品値引きの出荷数、受注数、売上金額のテキストカラー設定
                            if ((col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName) ||
                                (col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName) ||
                                (col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName))
                            {
                                if (salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                                {
                                    cell.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
                                }
                                else
                                {
                                    // --- UPD 2010/01/27 -------------->>>>>
                                    //cell.Appearance.ForeColor = ct_DISABLE_FONT_COLOR;
                                    if(col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName)
                                    {
                                        if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrInputDiv == 1) // 売上全体設定マスタ 受注数入力 0:しない　1:する)
                                        {
                                            cell.Appearance.ForeColor = ct_DISABLE_FONT_COLOR;
                                        }
                                        else
                                        {
                                            // 非表示
                                            cell.Appearance.ForeColor = Color.Transparent;
                                        }
                                    }
                                    else
                                    {
                                        cell.Appearance.ForeColor = ct_DISABLE_FONT_COLOR;
                                    }
                                    // --- UPD 2010/01/27 --------------<<<<<
                                }
                            }
                            #endregion

                            #region オープン価格情報表示
                            if (col.Key == this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName)
                            {
                                this.DisplayOpenPrice(rowIndex);
                            }
                            #endregion
                        }

                        #region 売単価、原単価、定価のバックカラー設定
                        this.SalesUnitCostColorSetting(rowIndex, salesRowNo);
                        this.SalesUnitPriceColorSetting(rowIndex, salesRowNo);
                        this.ListPriceColorSetting(rowIndex, salesRowNo);
                        #endregion

                        break;
                    }
                #endregion

                #region 消費税調整、残高調整、売掛消費税調整、売掛残高調整
                //-----------------------------------------------------------------------------
                // 消費税調整、残高調整、売掛消費税調整、売掛残高調整
                //-----------------------------------------------------------------------------
                case SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust:
                case SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust:
                case SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust:
                case SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust:
                    {
                        // 品名
                        string goodsName = this._salesDetailDataTable[rowIndex].GoodsName;

                        // 商品種別
                        int goodsKindCode = this._salesDetailDataTable[rowIndex].GoodsKindCode;

                        // 変更可能ステータス
                        int editStatus = this._salesDetailDataTable[rowIndex].EditStatus;

                        // 行ステータス
                        int rowStatus = this._salesDetailDataTable[rowIndex].RowStatus;

                        // 受注数
                        double acceptAnOrderCntDisplay = this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay;

                        // 出荷数
                        double shipmentCntDisplay = this._salesDetailDataTable[rowIndex].ShipmentCntDisplay;
                        double shipmentCnt = this._salesDetailDataTable[rowIndex].ShipmentCnt;

                        // 売上伝票区分(明細)
                        int salesSlipCdDtl = this._salesDetailDataTable[rowIndex].SalesSlipCdDtl;

                        // 指定行の全ての列に対して設定を行う。
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // セル情報を取得
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                            if (cell == null) continue;

                            if ((salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                                (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
                            {
                                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                                if (col.Key == this._salesDetailDataTable.TaxDivColumn.ColumnName)
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
                                if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AllDisable)
                                {
                                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                }
                                else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AllReadOnly)
                                {
                                    if (col.Key != this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName)
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                                    }
                                }
                                else
                                {
                                    if ((col.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName) ||
                                        (col.Key == this._salesDetailDataTable.DtlNoteColumn.ColumnName))
                                    {
                                        // 「売上金額」「備考」のみを有効にする
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    }
                                    else
                                    {
                                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                                    }

                                    if (rowStatus == SalesSlipInputAcs.ctROWSTATUS_COPY)
                                    {
                                        cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                    }
                                    else if (rowStatus == SalesSlipInputAcs.ctROWSTATUS_CUT)
                                    {
                                        cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                        cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

                                        if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                                            (cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit))
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

                            #region ●無効要素のテキストカラー設定
                            //------------------------------------------------
                            // 無効要素のテキストカラー設定
                            //------------------------------------------------
                            // 行値引、注釈以外
                            if ((editStatus != SalesSlipInputAcs.ctEDITSTATUS_RowDiscount) &&
                                (editStatus != SalesSlipInputAcs.ctEDITSTATUS_Annotation))
                            {
                                // 課税・非課税 単位 BLコード 仕入先コード 受注数 メーカーコード 商品属性 現在庫数 販売区分
                                if ((col.Key == this._salesDetailDataTable.TaxDivColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.StockDateColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.SalesCodeColumn.ColumnName))
                                {
                                    //if (string.IsNullOrEmpty(goodsName))
                                    //{
                                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                                    //}
                                    //else
                                    //{
                                    //    cell.Appearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                    //}
                                }

                                // 納品完了予定日
                                if (col.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
                                {
                                    //>>>2010/02/26
                                    //if (acceptAnOrderCntDisplay == 0)
                                    if (((acceptAnOrderCntDisplay != 0) ||
                                         (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) ||
                                         (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.SearchEstimate)) &&
                                        (salesSlip.OnlineKindDiv != 1))
                                    //<<<2010/02/26
                                    {
                                        cell.Appearance.ForeColor = Color.Transparent;
                                    }
                                    else
                                    {
                                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                    }
                                }

                                // 明細備考
                                if (col.Key == this._salesDetailDataTable.DtlNoteColumn.ColumnName)
                                {
                                    switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().DtlNoteDispDiv)
                                    {
                                        // 入力あり
                                        case 0:
                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                            break;
                                        // 非表示
                                        case 1:
                                            cell.Appearance.ForeColor = Color.Transparent;
                                            break;
                                        default:
                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                            break;
                                    }
                                }

                                #region 得意先注番
                                // 得意先注番
                                if (col.Key == this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName)
                                {
                                    switch (salesSlip.CustOrderNoDispDiv)
                                    {
                                        // 表示しない
                                        case 0:
                                            cell.Appearance.ForeColor = Color.Transparent;
                                            break;
                                        // 表示する
                                        case 1:
                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                            break;
                                        default:
                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                            break;
                                    }
                                }
                                #endregion

                                // 原単価、原価率
                                if ((col.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                    (col.Key == this._salesDetailDataTable.CostRateColumn.ColumnName))
                                {
                                    switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd)
                                    {
                                        // しない
                                        case 0:
                                            cell.Appearance.ForeColor = Color.Transparent;
                                            break;
                                        // する
                                        case 1:
                                            if (this._salesSlipInputAcs.CostDisplay == false) // HOMEキーによる制御
                                            {
                                                cell.Appearance.ForeColor = Color.Transparent;
                                            }
                                            else
                                            {
                                                if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                                                {
                                                    switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost)
                                                    {
                                                        // 修正可能
                                                        case 0:
                                                        // 修正不可
                                                        case 1:
                                                        // 在庫時不可
                                                        case 3:
                                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                            break;
                                                        // 未使用
                                                        case 2:
                                                            cell.Appearance.ForeColor = Color.Transparent;
                                                            break;
                                                        default:
                                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost)
                                                    {
                                                        // 修正可能
                                                        case 0:
                                                        // 修正不可
                                                        case 1:
                                                        // 在庫時不可
                                                        case 3:
                                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                            break;
                                                        // 未使用
                                                        case 2:
                                                            cell.Appearance.ForeColor = Color.Transparent;
                                                            break;
                                                        default:
                                                            cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                                                            break;
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                // 行値引、注釈
                                if ((col.Key != this._salesDetailDataTable.GoodsNameColumn.ColumnName) &&
                                    (col.Key != this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName))
                                {
                                    cell.Appearance.ForeColorDisabled = Color.Transparent;
                                }
                            }

                            if ((cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled) &&
                                (cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled))
                            {
                                // コピー対象行
                                if (rowStatus == SalesSlipInputAcs.ctROWSTATUS_COPY)
                                {
                                    cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                    cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                }
                                // 切り取り対象行
                                else if (rowStatus == SalesSlipInputAcs.ctROWSTATUS_CUT)
                                {
                                    cell.Appearance.BackColor = ct_ROWSTATUS_COPY_COLOR;
                                    cell.Appearance.ForeColor = ct_ROWSTATUS_CUT_COLOR;
                                }
                                else
                                {
                                    cell.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                                    if ((goodsKindCode == 38) || (goodsKindCode == 39))
                                    {
                                        cell.Appearance.ForeColor = ct_REDUCTION_FONT_COLOR;
                                    }

                                    if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                                        (cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit))
                                    {
                                        cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                    }
                                }
                            }

                            // 行番号の色変更
                            if (cell.Column.Key == this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName)
                            {
                                if ((salesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount) && (shipmentCnt != 0))
                                {
                                    cell.Appearance.BackColor = ct_GOODSDISCOUNT_CELL_COLOR;
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
                            #endregion
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
        private Infragistics.Win.UltraWinGrid.Activation GetTaxActivation(int rowIndex)
        {
            if (this._salesDetailDataTable[rowIndex].CanTaxDivChange)
            {
                return Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                return Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
        }

        /// <summary>
        /// 売上金額計算処理
        /// </summary>
        internal void CalculationSalesPrice()
        {
            bool bCalc = false;

            try
            {
                // 描画を一時停止
                this.uGrid_Details.BeginUpdate();

                // 描画が必要な明細件数を取得する。
                int cnt = this._salesDetailDataTable.Count;

                for (int i = 0; i < cnt; i++)
                {
                    if (!this._salesSlipInputAcs.ExistSalesDetailComp(this._salesSlipInputAcs.SalesDetailDataTable[i].SalesRowNo)) continue;
                    this._salesSlipInputAcs.CalculationSalesMoney(i);
                    this._salesSlipInputAcs.CalculationCost(i);
                    this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRateByIndex(i);
                    bCalc = true;
                }

            }
            finally
            {
                // 描画を開始
                this.uGrid_Details.EndUpdate();
            }

            if (bCalc)
            {
                // 売上金額変更後発生イベントコール処理
                this.SalesPriceChangedEventCall();
            }
        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        public void ButtonInitialSetting()
        {
            this.uButton_RowInsert.ImageList = this._imageList16;
            this.uButton_RowDelete.ImageList = this._imageList16;
            this.uButton_RowCut.ImageList = this._imageList16;
            this.uButton_RowCopy.ImageList = this._imageList16;
            this.uButton_RowPaste.ImageList = this._imageList16;
            this.uButton_Guide.ImageList = this._imageList16;

            this.uButton_Guide.Appearance.Image = (int)Size16_Index.GUIDE;

            this.uButton_RowInsert.Enabled = false;
            this.uButton_RowDelete.Enabled = false;
            this.uButton_RowCut.Enabled = false;
            this.uButton_RowCopy.Enabled = false;
            this.uButton_RowPaste.Enabled = false;
            this.uButton_Guide.Enabled = false;

            this.uButton_InputChange.Enabled = false;               // 入力切替
            this.uButton_InputStockInfo.Enabled = false;            // 仕入
            this.uButton_SCM.Enabled = false;                       // SCM // 2010/02/26
            this.uButton_InputOrderInfo.Enabled = false;            // 発注
            this.uButton_LineDiscount.Enabled = false;              // 行値引
            this.uButton_GoodsDiscount.Enabled = false;             // 商品値引
            this.uButton_Annotation.Enabled = false;                // 注釈
            // --- UPD 2009/09/08 -------------->>>
            //this.uButton_ChangeCarInfo.Enabled = false;             // 車種変更
            this.uButton_ChangeCarInfo.Enabled = true;
            // --- UPD 2009/09/08 --------------<<<
            this.uButton_StockSearch.Enabled = false;               // 在庫検索
            this.uButton_ChangeWarehouse.Enabled = false;           // 倉庫切替
            this.uButton_TBO.Enabled = false;                       // TBO
            this.uButton_NewComplete.Enabled = false;               // 一式登録
            this.uButton_AddComplete.Enabled = false;               // 一式追加
            this.uButton_DelComplete.Enabled = false;               // 一式削除

            this.uButton_SalesReference.Enabled = true;             // 売上履歴
            this.uButton_ShipmentReference.Enabled = false;         // 出荷照会
            this.uButton_EstimateReference.Enabled = false;         // 見積照会
            this.uButton_AcceptAnOrderReference.Enabled = false;    // 受注照会

            this.uButton_SearchChange.Enabled = false;              // 検索切替

            this.uButton_CopyStockAllLine.Enabled = false;          // 一括複写
            this.uButton_CopyStockBefLine.Enabled = false;          // 前行複写

            if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SalesStockDiv == 0) // 売上全体設定マスタ 売上仕入区分 0:しない 1:する 2:必須入力
            {
                this.uButton_InputStockInfo.Enabled = false; // 仕入
                this.uButton_CopyStockAllLine.Enabled = false;          // 一括複写
                this.uButton_CopyStockBefLine.Enabled = false;          // 前行複写
            }

            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._rowInsertButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWINSERT;
            this._rowDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
            this._rowCutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCUT;
            this._rowCopyButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCOPY;
            this._rowPasteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWPASTE;
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
        /// 選択済み売上行番号リスト取得処理
        /// </summary>
        /// <returns>選択済み売上行番号リスト</returns>
        private List<int> GetSelectedSalesRowNoList()
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            if ((cell == null) && (rows == null)) return null;

            List<int> selectedSalesRowNoList = new List<int>();
            List<int> selectedIndexList = new List<int>();

            if (cell != null)
            {
                selectedSalesRowNoList.Add(this._salesDetailDataTable[cell.Row.Index].SalesRowNo);
                selectedIndexList.Add(cell.Row.Index);
            }
            else if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    selectedSalesRowNoList.Add(this._salesDetailDataTable[row.Index].SalesRowNo);
                    selectedIndexList.Add(row.Index);
                }
            }

            return selectedSalesRowNoList;
        }

        /// <summary>
        /// 入力済行数取得処理
        /// </summary>
        /// <returns>入力済行数</returns>
        private int GetAlreadyInputRowCount()
        {
            int count = 0;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
            {
                if (!string.IsNullOrEmpty(this._salesDetailDataTable[row.Index].GoodsName))
                {
                    count++;
                }
            }

            return count;
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

            return this._salesDetailDataTable[rowIndex].SalesRowNo;
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        internal void Clear()
        {
            // 売上明細DataTable行クリア処理
            this._salesDetailDataTable.Rows.Clear();

            // 一式情報DataTable行クリア処理
            this._completeInfoDataTable.Rows.Clear();

            // グリッド行初期設定処理
            this._salesSlipInputAcs.SalesDetailRowInitialSetting(this._salesInputConstructionAcs.SalesInputConstruction.DataInputCountValue);

            // 明細グリッドセル設定処理
            this.SettingGrid();

            // 売上金額変更後発生イベントコール処理
            this.SalesPriceChangedEventCall();
        }

        /// <summary>
        /// 売上数量０行削除処理
        /// </summary>
        /// <param name="changeRowCount">true:行数を変更する false:行数を変更しない</param>
        internal void DeleteShipmentCountZeroRow(bool changeRowCount)
        {
            List<int> deleteStockRowNoList = this._salesSlipInputAcs.GetShipmentCntZeroSalesRowNoList();

            if (deleteStockRowNoList.Count > 0)
            {
                // 売上明細行削除処理
                this._salesSlipInputAcs.DeleteSalesDetailRow(deleteStockRowNoList, changeRowCount);
            }
        }

        /// <summary>
        /// 受注残数０行削除処理
        /// </summary>
        /// <param name="changeRowCount">true:行数を変更する false:行数を変更しない</param>
        internal void DeleteAcptAnOdrRemainCntZeroRow(bool changeRowCount)
        {
            List<int> deleteSalesRowNoList = this._salesSlipInputAcs.GetAcptAnOdrRemainCntZeroSalesRowNoList();

            if (deleteSalesRowNoList.Count > 0)
            {
                // 売上明細行削除処理
                this._salesSlipInputAcs.DeleteSalesDetailRow(deleteSalesRowNoList, changeRowCount);
            }
        }

        /// <summary>
        /// 空白行削除処理
        /// </summary>
        /// <param name="changeRowCount">true:行数を変更する false:行数を変更しない</param>
        internal void DeleteEmptyRow(bool changeRowCount)
        {
            List<int> deleteStockRowNoList = this._salesSlipInputAcs.GetEmptySalesRowNoList();

            if (deleteStockRowNoList.Count > 0)
            {
                // 売上明細行削除処理
                this._salesSlipInputAcs.DeleteSalesDetailRow(deleteStockRowNoList, changeRowCount);
            }
        }

        /// <summary>
        /// ユーザー設定値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void SalesInputConstructionAcs_DataChanged(object sender, EventArgs e)
        {
            // グリッド列設定処理（ユーザー設定より）
            this.GridSetting(this._salesInputConstructionAcs.SalesInputConstruction);
        }

        /// <summary>
        /// 売上金額変更後発生イベントコール処理
        /// </summary>
        private void SalesPriceChangedEventCall()
        {
            if (this.SalesPriceChanged != null)
            {
                this.SalesPriceChanged(this, new EventArgs());
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
        /// フッタ部明細情報設定イベントコール処理
        /// </summary>
        private void SettingFooterEventCall(Int32 salesRowNo)
        {
            if ((this.SettingFooter != null) && (salesRowNo != -1))
            {
                this.SettingFooter(this, salesRowNo);
            }
        }

        /// <summary>
        /// 車両情報設定イベントコール処理
        /// </summary>
        private void SettingCarInfoEventCall(Int32 salesRowNo)
        {
            if ((this.SettingCarInfo != null) && (salesRowNo != -1))
            {
                this.SettingCarInfo(this, salesRowNo);
            }
        }

        /// <summary>
        /// Visible設定イベントコール処理
        /// </summary>
        private void SettingVisibleEventCall()
        {
            if (this.SettingVisible != null)
            {
                this.SettingVisible();
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
                // 小数点または、マイナス以外
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
                //int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                int _Rketa = SalesSlipInputAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
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
        /// 得意先入力チェック処理
        /// </summary>
        /// <returns>true:得意先入力済み false:得意先未入力</returns>
        private bool CheckCustomerCodeInput()
        {
            // 得意先入力チェック
            SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
            if (salesSlip == null)
            {
                return false;
            }

            if (salesSlip.CustomerCode == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "得意先が選択されていません。",
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
        /// 注釈行チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckOnlyAnnotation()
        {
            if (this._salesSlipInputAcs.ExistSalesDetailExceptAnnotation() != true)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "売上情報が存在しない明細に注釈を追加します。　　",
                    1,
                    MessageBoxButtons.OK);
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
        /// セルアクティブ時ボタン有効無効コントロール処理
        /// </summary>
        public void ActiveCellButtonEnabledControl()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.ActiveCellButtonEnabledControl(this.uGrid_Details.ActiveCell.Row.Index, this.uGrid_Details.ActiveCell.Column.Key);
            }
            else
            {
                this.ActiveCellButtonEnabledControl(0, this._salesDetailDataTable.GoodsNoColumn.ColumnName);
            }
        }

        /// <summary>
        /// セルアクティブ時ボタン有効無効コントロール処理
        /// </summary>
        /// <param name="index">行インデックス</param>
        /// <param name="colKey">セルキー文字列</param>
        /// <br>Update Note: 2009/09/08 張凱 車種変更ボタン対応</br>
        /// <br>Update Note: 2010/05/04 王海立 明細の「商品値引(N)」ボタンを無効にする</br>
        /// <br>Update Note: 2010/06/02 呉元嘯 PM.NS障害・改良対応（７月リリース案件）No.11</br>
        /// <br>            「車種変更」機能の動作変更対応</br> 
        private void ActiveCellButtonEnabledControl(int index, string colKey)
        {
            if (_salesDetailDataTable.Count == 0) return;

            try
            {
                this.tToolbarsManager_Main.BeginUpdate();

                #region 読取専用、締済
                if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                    (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
                {
                    this.uButton_Guide.Enabled = false; // ガイド

                    this.uButton_RowInsert.Enabled = false; // 挿入
                    this.uButton_RowDelete.Enabled = false; // 削除
                    this.uButton_RowCut.Enabled = false; // 切取
                    this.uButton_RowCopy.Enabled = false; // コピー

                    this.uButton_InputChange.Enabled = true; // 入力切替
                    this.uButton_InputStockInfo.Enabled = false; // 仕入入力
                    this.uButton_SCM.Enabled = false; // SCM // 2010/02/26
                    this.uButton_InputOrderInfo.Enabled = false; // 発注入力

                    this.uButton_LineDiscount.Enabled = false; // 行値引
                    this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                    this.uButton_Annotation.Enabled = false; // 注釈
                    this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                    this.uButton_StockSearch.Enabled = false; // 在庫検索
                    this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                    this.uButton_TBO.Enabled = false; // TBO

                    this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                    this.uButton_SalesReference.Enabled = false; // 伝票複写
                    this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                    this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                    this.uButton_EstimateReference.Enabled = false; // 見積計上
                    this.uButton_SearchChange.Enabled = false; // 検索切替
                }
                #endregion

                #region 計上
                // 出荷計上 受注計上 見積計上
                else if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
                         (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
                         (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp))
                {
                    this.uButton_Guide.Enabled = false; // ガイド

                    this.uButton_RowInsert.Enabled = false; // 挿入
                    this.uButton_RowDelete.Enabled = true; // 削除
                    this.uButton_RowCut.Enabled = false; // 切取
                    this.uButton_RowCopy.Enabled = false; // コピー

                    this.uButton_InputChange.Enabled = true; // 入力切替
                    this.uButton_InputStockInfo.Enabled = true; // 仕入入力
                    this.uButton_SCM.Enabled = true; // SCM // 2010/02/26
                    // 2009/09/10 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //this.uButton_InputOrderInfo.Enabled = true; // 発注入力
                    if (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp)
                    {
                        this.uButton_InputOrderInfo.Enabled = true; // 発注入力
                    }
                    else
                    {
                        this.uButton_InputOrderInfo.Enabled = false; // 発注入力
                    }
                    // 2009/09/10 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    this.uButton_LineDiscount.Enabled = false; // 行値引
                    this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                    this.uButton_Annotation.Enabled = false; // 注釈
                    this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                    this.uButton_StockSearch.Enabled = false; // 在庫検索
                    this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                    this.uButton_TBO.Enabled = false; // TBO

                    this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                    this.uButton_SalesReference.Enabled = false; // 伝票複写
                    this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                    this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                    this.uButton_EstimateReference.Enabled = false; // 見積計上
                    this.uButton_SearchChange.Enabled = false; // 検索切替

                    // ガイドボタンの有効無効を設定する
                    if ((colKey != null) &&
                        (colKey == this._salesDetailDataTable.SalesCodeColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.SupplierSnmColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
                        )
                    {
                        this.uButton_Guide.Enabled = true;
                        this.uButton_Guide.Tag = colKey;
                    }
                    else
                    {
                        this.uButton_Guide.Enabled = false;
                    }
                }
                #endregion

                #region 返品
                else if (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Return)
                {
                    this.uButton_Guide.Enabled = false; // ガイド

                    this.uButton_RowInsert.Enabled = false; // 挿入
                    this.uButton_RowDelete.Enabled = true; // 削除
                    this.uButton_RowCut.Enabled = false; // 切取
                    this.uButton_RowCopy.Enabled = false; // コピー

                    this.uButton_InputChange.Enabled = true; // 入力切替
                    this.uButton_InputStockInfo.Enabled = false; // 仕入入力
                    this.uButton_SCM.Enabled = false; // SCM // 2010/02/26
                    this.uButton_InputOrderInfo.Enabled = false; // 発注入力

                    this.uButton_LineDiscount.Enabled = false; // 行値引
                    this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                    this.uButton_Annotation.Enabled = false; // 注釈
                    this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                    this.uButton_StockSearch.Enabled = false; // 在庫検索
                    this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                    this.uButton_TBO.Enabled = false; // TBO

                    this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                    this.uButton_SalesReference.Enabled = false; // 伝票複写
                    this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                    this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                    this.uButton_EstimateReference.Enabled = false; // 見積計上
                    this.uButton_SearchChange.Enabled = false; // 検索切替

                    // 返品時在庫登録時、倉庫切替有効
                    if ((this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetGoodsStockEtyDiv == 0) &&   // 返品時在庫登録区分(0:する 1:しない)
                        (this._salesSlipInputAcs.SalesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) &&                         // 返品
                        (this._salesDetailDataTable[index].SalesSlipDtlNumSrc != 0) &&                                        // 元データあり
                        (this._salesSlipInputAcs.SalesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum))          // 新規登録
                    {
                        this.uButton_ChangeWarehouse.Enabled = true; // 倉庫切替
                    }

                    // ガイドボタンの有効無効を設定する
                    if ((colKey != null) &&
                        (colKey == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
                        )
                    {
                        this.uButton_Guide.Enabled = true;
                        this.uButton_Guide.Tag = colKey;
                    }
                    else
                    {
                        this.uButton_Guide.Enabled = false;
                    }
                }
                #endregion
                #region 赤伝
                else if (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Red)
                {
                    this.uButton_Guide.Enabled = false; // ガイド

                    this.uButton_RowInsert.Enabled = false; // 挿入
                    this.uButton_RowDelete.Enabled = false; // 削除
                    this.uButton_RowCut.Enabled = false; // 切取
                    this.uButton_RowCopy.Enabled = false; // コピー

                    this.uButton_InputChange.Enabled = true; // 入力切替
                    this.uButton_InputStockInfo.Enabled = false; // 仕入入力
                    this.uButton_SCM.Enabled = false; // SCM // 2010/02/26
                    this.uButton_InputOrderInfo.Enabled = false; // 発注入力

                    this.uButton_LineDiscount.Enabled = false; // 行値引
                    this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                    this.uButton_Annotation.Enabled = false; // 注釈
                    this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                    this.uButton_StockSearch.Enabled = false; // 在庫検索
                    this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                    this.uButton_TBO.Enabled = false; // TBO

                    this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                    this.uButton_SalesReference.Enabled = false; // 伝票複写
                    this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                    this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                    this.uButton_EstimateReference.Enabled = false; // 見積計上
                    this.uButton_SearchChange.Enabled = false; // 検索切替

                    // ガイドボタンの有効無効を設定する
                    if ((colKey != null) &&
                        (colKey == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                        (colKey == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
                        )
                    {
                        this.uButton_Guide.Enabled = true;
                        this.uButton_Guide.Tag = colKey;
                    }
                    else
                    {
                        this.uButton_Guide.Enabled = false;
                    }
                }
                #endregion
                else
                {
                    string goodsCode = this._salesDetailDataTable[index].GoodsNo;
                    string goodsName = this._salesDetailDataTable[index].GoodsName;
                    int editStatus = this._salesDetailDataTable[index].EditStatus;

                    // ----------ADD 2010/06/02----------->>>>>
                    if (this.uGrid_Details.ContainsFocus && (this.uGrid_Details.ActiveRow != null || this.uGrid_Details.ActiveCell != null))
                    {
                        //新規登録
                        if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Normal)
                            && (this._salesSlipInputAcs.SalesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum))
                        {
                            //有効行のみ
                            if (CheckRowEffective(index))
                            {
                                this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                            }
                            else
                            {
                                this.uButton_ChangeCarInfo.Enabled = true; // 車種変更
                            }
                        }
                    }
                    // ----------ADD 2010/06/02-----------<<<<<

                    // 行操作ボタンの有効無効チェック
                    if (string.IsNullOrEmpty(goodsName))
                    {
                        this.uButton_RowInsert.Enabled = true;
                        this.uButton_RowDelete.Enabled = true;
                        this.uButton_RowCut.Enabled = false;
                        this.uButton_RowCopy.Enabled = false;
                    }
                    else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AllReadOnly)
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
                    if ((this._salesSlipInputAcs.ExistCopySalesDetailRow()) && (editStatus != SalesSlipInputAcs.ctEDITSTATUS_AllReadOnly))
                    {
                        this.uButton_RowPaste.Enabled = true;
                    }
                    else
                    {
                        this.uButton_RowPaste.Enabled = false;
                    }

                    // 入力補助ボタンの有効無効チェック
                    switch ((SalesSlipInputAcs.SalesGoodsCd)this._salesSlipInputAcs.SalesSlip.SalesGoodsCd)
                    {
                        case SalesSlipInputAcs.SalesGoodsCd.Goods:
                            if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AllDisable)
                            {
                                this.uButton_Guide.Enabled = false; // ガイド

                                this.uButton_InputChange.Enabled = true; // 入力切替
                                this.uButton_InputStockInfo.Enabled = true; // 仕入入力
                                this.uButton_SCM.Enabled = true; // SCM // 2010/02/26
                                this.uButton_InputOrderInfo.Enabled = true; // 発注入力

                                this.uButton_LineDiscount.Enabled = false; // 行値引
                                this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                this.uButton_Annotation.Enabled = false; // 注釈
                                this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                                this.uButton_StockSearch.Enabled = false; // 在庫検索
                                this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                                this.uButton_TBO.Enabled = false; // TBO

                                this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                                this.uButton_SalesReference.Enabled = false; // 伝票複写
                                this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                                this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                                this.uButton_EstimateReference.Enabled = false; // 見積計上
                                this.uButton_SearchChange.Enabled = false; // 検索切替
                            }
                            else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AllReadOnly)
                            {
                                this.uButton_Guide.Enabled = false; // ガイド

                                this.uButton_InputChange.Enabled = true; // 入力切替
                                this.uButton_InputStockInfo.Enabled = true; // 仕入入力
                                this.uButton_SCM.Enabled = true; // SCM // 2010/02/26
                                this.uButton_InputOrderInfo.Enabled = true; // 発注入力

                                this.uButton_LineDiscount.Enabled = false; // 行値引
                                this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                this.uButton_Annotation.Enabled = false; // 注釈
                                this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                                this.uButton_StockSearch.Enabled = false; // 在庫検索
                                this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                                this.uButton_TBO.Enabled = false; // TBO

                                this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                                this.uButton_SalesReference.Enabled = false; // 伝票複写
                                this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                                this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                                this.uButton_EstimateReference.Enabled = false; // 見積計上
                                this.uButton_SearchChange.Enabled = false; // 検索切替
                            }
                            else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_ShipmentCountOnly)
                            {
                                this.uButton_Guide.Enabled = false; // ガイド

                                this.uButton_InputChange.Enabled = true; // 入力切替
                                this.uButton_InputStockInfo.Enabled = true; // 仕入入力
                                this.uButton_SCM.Enabled = true; // SCM // 2010/02/26
                                this.uButton_InputOrderInfo.Enabled = true; // 発注入力

                                this.uButton_LineDiscount.Enabled = false; // 行値引
                                this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                this.uButton_Annotation.Enabled = false; // 注釈
                                this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                                this.uButton_StockSearch.Enabled = false; // 在庫検索
                                this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                                this.uButton_TBO.Enabled = false; // TBO

                                this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                                this.uButton_SalesReference.Enabled = false; // 伝票複写
                                this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                                this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                                this.uButton_EstimateReference.Enabled = false; // 見積計上
                                this.uButton_SearchChange.Enabled = false; // 検索切替
                            }
                            else if (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
                            {
                                this.uButton_Guide.Enabled = false; // ガイド

                                this.uButton_InputChange.Enabled = true; // 入力切替
                                this.uButton_InputStockInfo.Enabled = true; // 仕入入力
                                this.uButton_SCM.Enabled = true; // SCM // 2010/02/26

                                // 2009/09/10 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                //this.uButton_InputOrderInfo.Enabled = true; // 発注入力
                                if ((this._salesDetailDataTable[index].AcptAnOdrStatusSrc != 0) &&
                                    (this._salesDetailDataTable[index].AcptAnOdrStatusSrc != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder))
                                {
                                    this.uButton_InputOrderInfo.Enabled = false; // 発注入力
                                }
                                else
                                {
                                    this.uButton_InputOrderInfo.Enabled = true; // 発注入力
                                }
                                // 2009/09/10 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                this.uButton_LineDiscount.Enabled = false; // 行値引
                                this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                this.uButton_Annotation.Enabled = false; // 注釈
                                this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                                this.uButton_StockSearch.Enabled = false; // 在庫検索
                                this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                                this.uButton_TBO.Enabled = false; // TBO

                                this._popupMenuTool_Complete.SharedProps.Enabled = true; // 一式

                                this.uButton_SalesReference.Enabled = false; // 伝票複写
                                this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                                this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                                this.uButton_EstimateReference.Enabled = false; // 見積計上
                                this.uButton_SearchChange.Enabled = false; // 検索切替

                                if ((colKey != null) &&
                                    (colKey == this._salesDetailDataTable.SalesCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.WarehouseNameColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierSnmColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.MakerNameColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
                                    )
                                {
                                    this.uButton_Guide.Enabled = true;
                                    this.uButton_Guide.Tag = colKey;
                                }
                            }
                            else if ((editStatus == SalesSlipInputAcs.ctEDITSTATUS_ExistSlip) ||
                                    (editStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpEdit))
                            {
                                this.uButton_Guide.Enabled = false; // ガイド

                                this.uButton_InputChange.Enabled = true; // 入力切替
                                this.uButton_InputStockInfo.Enabled = true; // 仕入入力
                                this.uButton_SCM.Enabled = true; // SCM // 2010/02/26
                                this.uButton_InputOrderInfo.Enabled = true; // 発注入力

                                this.uButton_LineDiscount.Enabled = false; // 行値引
                                this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                this.uButton_Annotation.Enabled = false; // 注釈
                                this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                                this.uButton_StockSearch.Enabled = false; // 在庫検索
                                this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                                this.uButton_TBO.Enabled = false; // TBO

                                this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                                this.uButton_SalesReference.Enabled = false; // 伝票複写
                                this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                                this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                                this.uButton_EstimateReference.Enabled = false; // 見積計上
                                this.uButton_SearchChange.Enabled = false; // 検索切替

                                // ガイドボタンの有効無効を設定する
                                if ((colKey != null) &&
                                    (colKey == this._salesDetailDataTable.SalesCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierSnmColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
                                    )
                                {
                                    this.uButton_Guide.Enabled = true;
                                    this.uButton_Guide.Tag = colKey;
                                }
                                else
                                {
                                    this.uButton_Guide.Enabled = false;
                                }

                                if (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                                {
                                    this.uButton_LineDiscount.Enabled = false; // 行値引
                                    this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                    this.uButton_Annotation.Enabled = false; // 注釈
                                }
                            }
                            else
                            {
                                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay)
                                {
                                    case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate: // 見積
                                    case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate: // 単価見積
                                        {
                                            this.uButton_Guide.Enabled = false; // ガイド

                                            this.uButton_InputChange.Enabled = true; // 入力切替
                                            this.uButton_InputStockInfo.Enabled = false; // 仕入入力
                                            this.uButton_SCM.Enabled = true; // SCM // 2010/02/26
                                            this.uButton_InputOrderInfo.Enabled = false; // 発注入力

                                            this.uButton_LineDiscount.Enabled = false; // 行値引
                                            this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                            this.uButton_Annotation.Enabled = false; // 注釈
                                            // --- UPD 2009/09/08 -------------->>>
                                            //// 車種変更ボタン処理に変更
                                            //this.uButton_ChangeCarInfo.Enabled = true; // 車種変更
                                            // --- UPD 2009/09/08 --------------<<<
                                            this.uButton_StockSearch.Enabled = true; // 在庫検索
                                            this.uButton_ChangeWarehouse.Enabled = true; // 倉庫切替
                                            this.uButton_TBO.Enabled = true; // TBO

                                            this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                                            this.uButton_SalesReference.Enabled = true; // 伝票複写
                                            this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                                            this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                                            this.uButton_EstimateReference.Enabled = false; // 見積計上
                                            this.uButton_SearchChange.Enabled = true; // 検索切替

                                            break;
                                        }
                                    case SalesSlipInputAcs.AcptAnOdrStatusState.Sales: // 売上
                                        {
                                            this.uButton_Guide.Enabled = false; // ガイド

                                            this.uButton_InputChange.Enabled = true; // 入力切替
                                            this.uButton_InputStockInfo.Enabled = true; // 仕入入力
                                            this.uButton_SCM.Enabled = true; // SCM // 2010/02/26

                                            if ((this._salesSlipInputAcs.SalesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.Sales) &&
                                                (editStatus != SalesSlipInputAcs.ctEDITSTATUS_GoodsDiscount))
                                            {
                                                this.uButton_InputOrderInfo.Enabled = true; // 発注入力
                                            }
                                            else
                                            {
                                                this.uButton_InputOrderInfo.Enabled = false; // 発注入力
                                            }

                                            this.uButton_LineDiscount.Enabled = true; // 行値引
                                            // --- UPD 2010/05/04 ---------->>>>>
                                            //this.uButton_GoodsDiscount.Enabled = true; // 商品値引
                                            if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.SlipDiscount))
                                            {
                                                this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                            }
                                            else
                                            {
                                                this.uButton_GoodsDiscount.Enabled = true; // 商品値引
                                            }
                                            // --- UPD 2010/05/04 ----------<<<<<
                                            this.uButton_Annotation.Enabled = true; // 注釈
                                            // --- UPD 2009/09/08 -------------->>>
                                            //// 車種変更ボタン処理に変更
                                            //this.uButton_ChangeCarInfo.Enabled = true; // 車種変更
                                            // --- UPD 2009/09/08 --------------<<<
                                            this.uButton_StockSearch.Enabled = true; // 在庫検索
                                            this.uButton_ChangeWarehouse.Enabled = true; // 倉庫切替
                                            this.uButton_TBO.Enabled = true; // TBO

                                            // 売上で出荷数ありのときのみ一式操作可能(行値引、注釈は対象外)
                                            if (this._salesSlipInputAcs.ExistSalesDetail(this._salesDetailDataTable[index].SalesRowNo))
                                            {
                                                this._popupMenuTool_Complete.SharedProps.Enabled = true;
                                            }
                                            else
                                            {
                                                this._popupMenuTool_Complete.SharedProps.Enabled = false;
                                            }

                                            this.uButton_SalesReference.Enabled = true; // 伝票複写
                                            this.uButton_ShipmentReference.Enabled = true; // 貸出計上
                                            this.uButton_AcceptAnOrderReference.Enabled = true; // 受注計上
                                            this.uButton_EstimateReference.Enabled = true; // 見積計上
                                            this.uButton_SearchChange.Enabled = true; // 検索切替

                                            break;
                                        }
                                    case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment: // 出荷
                                        {
                                            this.uButton_Guide.Enabled = false; // ガイド

                                            this.uButton_InputChange.Enabled = true; // 入力切替
                                            this.uButton_InputStockInfo.Enabled = false; // 仕入入力
                                            this.uButton_SCM.Enabled = true; // SCM // 2010/02/26
                                            this.uButton_InputOrderInfo.Enabled = false; // 発注入力

                                            this.uButton_LineDiscount.Enabled = false; // 行値引
                                            this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                            this.uButton_Annotation.Enabled = false; // 注釈
                                            // --- UPD 2009/09/08 -------------->>>
                                            //// 車種変更ボタン処理に変更
                                            //this.uButton_ChangeCarInfo.Enabled = true; // 車種変更
                                            // --- UPD 2009/09/08 --------------<<<
                                            this.uButton_StockSearch.Enabled = true; // 在庫検索
                                            this.uButton_ChangeWarehouse.Enabled = true; // 倉庫切替
                                            this.uButton_TBO.Enabled = true; // TBO

                                            this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                                            this.uButton_SalesReference.Enabled = true; // 伝票複写
                                            this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                                            this.uButton_AcceptAnOrderReference.Enabled = true; // 受注計上
                                            this.uButton_EstimateReference.Enabled = true; // 見積計上
                                            this.uButton_SearchChange.Enabled = true; // 検索切替

                                            break;
                                        }
                                }
                                // ガイドボタンの有効無効を設定する
                                if ((colKey != null) &&
                                    (colKey == this._salesDetailDataTable.SalesCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.WarehouseNameColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierSnmColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.MakerNameColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName) ||
                                    (colKey == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
                                    )
                                {
                                    this.uButton_Guide.Enabled = true;
                                    this.uButton_Guide.Tag = colKey;
                                }
                                else
                                {
                                    this.uButton_Guide.Enabled = false;
                                }

                                // 修正明細
                                if (this._salesDetailDataTable[index].SalesSlipDtlNum != 0)
                                {
                                    this.uButton_LineDiscount.Enabled = false; // 行値引
                                    this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                    this.uButton_Annotation.Enabled = false; // 注釈
                                    this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                                    this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                                }

                                if (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                                {
                                    this.uButton_LineDiscount.Enabled = false; // 行値引
                                    this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                                    this.uButton_Annotation.Enabled = false; // 注釈
                                }
                            }
                            break;
                        default:
                            this.uButton_Guide.Enabled = false; // ガイド

                            this.uButton_InputChange.Enabled = false; // 入力切替
                            this.uButton_InputStockInfo.Enabled = false; // 仕入入力
                            this.uButton_SCM.Enabled = false; // SCM // 2010/02/26
                            this.uButton_InputOrderInfo.Enabled = false; // 発注入力

                            this.uButton_LineDiscount.Enabled = false; // 行値引
                            this.uButton_GoodsDiscount.Enabled = false; // 商品値引
                            this.uButton_Annotation.Enabled = false; // 注釈
                            this.uButton_ChangeCarInfo.Enabled = false; // 車種変更
                            this.uButton_StockSearch.Enabled = false; // 在庫検索
                            this.uButton_ChangeWarehouse.Enabled = false; // 倉庫切替
                            this.uButton_TBO.Enabled = false; // TBO

                            this._popupMenuTool_Complete.SharedProps.Enabled = false; // 一式

                            this.uButton_SalesReference.Enabled = false; // 伝票複写
                            this.uButton_ShipmentReference.Enabled = false; // 貸出計上
                            this.uButton_AcceptAnOrderReference.Enabled = false; // 受注計上
                            this.uButton_EstimateReference.Enabled = false; // 見積計上
                            this.uButton_SearchChange.Enabled = false; // 検索切替
                            break;
                    }

                    // 仕入入力
                    if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SalesStockDiv == 0) // 売上全体設定マスタ 売上仕入区分 0:しない 1:する 2:必須入力
                    {
                        this.uButton_InputStockInfo.Enabled = false; // 仕入
                    }

                    // 車種変更
                    if ((this._salesSlipInputAcs.GetSearchPartsMode(this._salesDetailDataTable[index].SalesRowNo) == SalesSlipInputAcs.SearchPartsModeState.BLCodeSearch) &&
                        (this._salesDetailDataTable[index].AcceptAnOrderNo != 0))
                    {
                        this.uButton_ChangeCarInfo.Enabled = false;
                    }
                    //>>>2010/02/26
                    // SCM
                    if (this._salesSlipInputAcs.SalesSlip.OnlineKindDiv != 10)
                    {
                        this.uButton_SCM.Enabled = false;
                    }
                    //<<<2010/02/26
                }

                // 前行複写、一括複写
                if ((this._salesSlipInputAcs.ExistOrderInfo(this._salesDetailDataTable[index].SalesRowNo)) ||
                    (this._salesSlipInputAcs.ExistSalesDetailWarehouseCode(this._salesDetailDataTable[index].SalesRowNo)) ||
                    (!this._salesSlipInputAcs.ExistSalesDetailGoodsNoAndGoodsMakerCd(this._salesDetailDataTable[index].SalesRowNo)) ||
                    (this._salesDetailDataTable[index].EditStatus == SalesSlipInputAcs.ctEDITSTATUS_GoodsDiscount) ||
                    (this.uButton_InputStockInfo.Enabled == false))

                {
                    this.uButton_CopyStockBefLine.Enabled = false;
                    this.uButton_CopyStockAllLine.Enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        this.uButton_CopyStockBefLine.Enabled = false;
                        this.uButton_CopyStockAllLine.Enabled = false;
                    }
                    else
                    {
                        this.uButton_CopyStockBefLine.Enabled = true;
                        this.uButton_CopyStockAllLine.Enabled = true;
                    }
                }

                if (this.SetToolbarButton != null)
                {
                    this.SetToolbarButton();
                }
            }
            finally
            {
                this.tToolbarsManager_Main.EndUpdate();
            }
        }

        /// <summary>
        /// 商品コードを自動で設定します。（バーコード用）
        /// </summary>
        /// <param name="goodsCode">商品コード</param>
        internal void AutoSettingGoodsCode(string goodsCode)
        {
            //>>>ddd
            //if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.ProductNumberColumn.ColumnName) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
            //{
            //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            //    int salesRowNo = this._salesDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].SalesRowNo;
            //    //StockInputDataSet.SalesDetailRow targetRow = this._salesDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlipInputAcs.SalesSlip.SupplierSlipNo, salesRowNo);//ddd
            //    StockInputDataSet.SalesDetailRow targetRow = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._stockSlipInputAcs.SalesSlip.SalesSlipNum, salesRowNo);//ddd

            //    if (targetRow != null)
            //    {
            //        Infragistics.Win.UltraWinGrid.UltraGridCell targetCell = null;
            //        targetRow.ProductNumber = goodsCode;

            //        foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
            //        {
            //            if ((int)row.Cells[this._salesDetailDataTable.SalesRowNoColumn.ColumnName].Value == targetRow.SalesRowNo)
            //            {
            //                targetCell = row.Cells[this._salesDetailDataTable.ProductNumberColumn.ColumnName];
            //                break;
            //            }
            //        }

            //        if (targetCell != null)
            //        {
            //            Infragistics.Win.UltraWinGrid.CellEventArgs ea = new Infragistics.Win.UltraWinGrid.CellEventArgs(targetCell);
            //            this.uGrid_Details_AfterCellUpdate(this.uGrid_Details, ea);

            //            this.ReturnKeyDown();
            //        }
            //    }
            //}
            //else
            //{
            //    bool isGoodsCodeColumn = false;
            //    if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
            //    {
            //        isGoodsCodeColumn = true;
            //        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            //    }

            //    // 仕入商品区分チェック
            //    if (this._stockSlipInputAcs.SalesSlip.SalesGoodsCd != 0)
            //    {
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "仕入商品区分が商品以外の為、商品情報を取得する事ができません。",
            //            -1,
            //            MessageBoxButtons.OK);

            //        return;
            //    }

            //    // 仕入先入力チェック処理
            //    bool customerCodeCheck = this.CheckCustomerCodeInput();

            //    if (!customerCodeCheck)
            //    {
            //        return;
            //    }

            //    StockInputDataSet.SalesDetailRow targetRow = null;
            //    foreach (StockInputDataSet.SalesDetailRow row in this._salesDetailDataTable)
            //    {
            //        if ((row.GoodsNo == "") && (row.GoodsName == ""))
            //        {
            //            targetRow = row;
            //            break;
            //        }
            //    }

            //    if (targetRow != null)
            //    {
            //        Infragistics.Win.UltraWinGrid.UltraGridCell targetCell = null;
            //        targetRow.GoodsNo = goodsCode;

            //        foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
            //        {
            //            if ((int)row.Cells[this._salesDetailDataTable.SalesRowNoColumn.ColumnName].Value == targetRow.SalesRowNo)
            //            {
            //                targetCell = row.Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
            //                break;
            //            }
            //        }

            //        if (targetCell != null)
            //        {
            //            Infragistics.Win.UltraWinGrid.CellEventArgs ea = new Infragistics.Win.UltraWinGrid.CellEventArgs(targetCell);
            //            this.uGrid_Details_AfterCellUpdate(this.uGrid_Details, ea);
            //        }

            //        if (isGoodsCodeColumn)
            //        {
            //            this.ReturnKeyDown();
            //        }
            //    }
            //}
            //<<<ddd
        }

        /// <summary>
        /// セルの編集モードを一度解除し、再度編集モードに設定します。
        /// </summary>
        private void CellExitEnterEditEnter()
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);

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
        private List<ColDisplayStatusExp> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatusExp> colDisplayStatusList = new List<ColDisplayStatusExp>();

            ColDisplayStatusExp colDisplayStatus;

            // グリッドから列表示状態クラスリストを構築
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                colDisplayStatus = new ColDisplayStatusExp();

                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;
                colDisplayStatus.LabelSpan = column.RowLayoutColumnInfo.LabelSpan;
                colDisplayStatus.OriginX = column.RowLayoutColumnInfo.OriginX;
                colDisplayStatus.OriginY = column.RowLayoutColumnInfo.OriginY;
                colDisplayStatus.SpanX = column.RowLayoutColumnInfo.SpanX;
                colDisplayStatus.SpanY = column.RowLayoutColumnInfo.SpanY;
                if (this._upperBerth[column.Key] != null)
                {
                    colDisplayStatus.MoveLineKeyName = this._upperBerth[column.Key].ToString();
                }
                else if (this._lowerBerth[column.Key] != null)
                {
                    colDisplayStatus.MoveLineKeyName = this._lowerBerth[column.Key].ToString();
                }
                if (this._enterMoveTable.ContainsKey(column.Key))
                {
                    colDisplayStatus.MoveEnterKeyName = this._enterMoveTable[column.Key].Key;
                    colDisplayStatus.Enabled = this._enterMoveTable[column.Key].Enabled;
                    colDisplayStatus.EnabledControl = this._enterMoveTable[column.Key].EnabledControl;
                    colDisplayStatus.EnterStopControl = this._enterMoveTable[column.Key].EnterStopControl;
                }

                colDisplayStatusList.Add(colDisplayStatus);
            }

            // 明細部先頭項目
            colDisplayStatus = new ColDisplayStatusExp();
            colDisplayStatus.Key = SalesSlipInputConstructionAcs.ct_StartPosittion;
            colDisplayStatus.MoveEnterKeyName = this._enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
            colDisplayStatusList.Add(colDisplayStatus);

            // 明細部最終項目
            colDisplayStatus = new ColDisplayStatusExp();
            colDisplayStatus.Key = SalesSlipInputConstructionAcs.ct_EndPosittion;
            colDisplayStatus.MoveEnterKeyName = this._enterMoveTable[SalesSlipInputConstructionAcs.ct_EndPosittion].Key;
            colDisplayStatusList.Add(colDisplayStatus);

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

                if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString()))
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
        /// ガイド起動処理
        /// </summary>
        internal void ExecuteGuide()
        {
            this.uButton_Guide_Click(this.uGrid_Details, new EventArgs());
        }

        #region ●商品検索関係
        /// <summary>
        /// 商品・出荷残・受注残検索と行設定処理
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <returns></returns>
        private int SearchGoodsAndRemain_And_RowSetting(int rowIndex)
        {
            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;
            string goodsName = this._salesDetailDataTable[rowIndex].GoodsName;
            string goodsNo = this._salesDetailDataTable[rowIndex].GoodsNo;
            int makerCode = this._salesDetailDataTable[rowIndex].GoodsMakerCd;
            int blGoodsCode = this._salesDetailDataTable[rowIndex].BLGoodsCode;

            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            List<Stock> stockList = new List<Stock>();

            object retObj;

            // --- UPD 2009/10/19 ---------->>>>>
            int status = this.SearchGoodsAndRemain(goodsNo, goodsName, makerCode, blGoodsCode, salesRowNo, out retObj);
            // --- UPD 2009/10/19 ----------<<<<<
            switch (status)
            {
                case 0:
                    {
                        if (retObj != null)
                        {
                            // 商品検索
                            if (retObj is ArrayList)
                            {
                                ArrayList retList = (ArrayList)retObj;

                                for (int cnt = 0; cnt < retList.Count; cnt++)
                                {
                                    // 通常商品情報
                                    if (retList[cnt] is GoodsUnitData)
                                    {
                                        goodsUnitDataList.Clear();
                                        goodsUnitDataList.Add((GoodsUnitData)retList[cnt]);

                                        List<int> settingSalesRowNoList;
                                        this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBase(this.GetActiveRowSalesRowNo(), salesRowNo + cnt, goodsUnitDataList, stockList, out settingSalesRowNoList, true, true);
                                    }
                                    // 受注照会(受注残検索)
                                    else if (retList[cnt] is AcptAnOdrRemainRefData)
                                    {
                                        List<AcptAnOdrRemainRefData> acptAnOdrRemainRefDataList = new List<AcptAnOdrRemainRefData>();
                                        acptAnOdrRemainRefDataList.Add((AcptAnOdrRemainRefData)retList[cnt]);
                                        int st = this._salesSlipInputAcs.SalesDetailRowSettingFromAcptAnOdrRemainRefList(salesRowNo + cnt, acptAnOdrRemainRefDataList, SalesSlipInputAcs.WayToDetailExpand.AddUpRemainder);
                                        if (st == -1)
                                        {
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "「計上」または「発注選択」済み明細がが選択されましたので、" + Environment.NewLine +
                                                "明細への展開を行いません。",
                                                -1,
                                                MessageBoxButtons.OK);
                                        }
                                    }
                                    // 出荷照会(出荷残検索)
                                    else if (retList[cnt] is SalHisRefResultParamWork)
                                    {
                                        List<SalHisRefResultParamWork> salHisRefResultParamWorkList = new List<SalHisRefResultParamWork>();
                                        salHisRefResultParamWorkList.Add((SalHisRefResultParamWork)retList[cnt]);
                                        int st = this._salesSlipInputAcs.SalesDetailRowSettingFromSalHisRefResultParamWorkListForAddUp(salesRowNo + cnt, salHisRefResultParamWorkList, SalesSlipInputAcs.WayToDetailExpand.AddUpRemainder);
                                        if (st == -1)
                                        {
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "「計上」済み明細が選択されましたので、" + Environment.NewLine +
                                                "明細への展開を行いません。",
                                                -1,
                                                MessageBoxButtons.OK);
                                        }
                                    }
                                }
                            }

                            // 明細グリッド設定処理
                            this.SettingGrid();

                            // 現在庫数調整
                            this._salesSlipInputAcs.SalesDetailStockInfoAdjust();
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
        /// 商品・出荷残・受注残検索処理（オーバーロード）
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="searchResult">検索結果</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 商品検索後、残数自動表示区分に従って受注残照会、出荷残照会を起動します。</br>
        /// <br>             検索結果については、ヒットした処理（商品or出荷残or受注残）によってクラスが異なります。</br>
        /// </remarks>
        private int SearchGoodsAndRemain(string goodsNo, string goodsName, int makerCode, int blGoodsCode, int salesRowNo, out object searchResult)
        {
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            searchResult = null;
            List<GoodsUnitData> goodsUnitDataList;
            List<Stock> stockList;
            int searchStatus;
            int retStasus = -1;

            //-----------------------------------------------------------------------------
            // 部品検索
            //-----------------------------------------------------------------------------
            searchStatus = this.SearchPartsFromGoodsNo(goodsNo, makerCode, goodsName, blGoodsCode, salesRowNo, out goodsUnitDataList, out stockList);

            //-----------------------------------------------------------------------------
            // 部品検索でヒットした場合は残検索
            //-----------------------------------------------------------------------------
            if ((searchStatus == 0) && (goodsUnitDataList.Count > 0))
            {
                ArrayList retList = new ArrayList();
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    retStasus = 0;
                    object reamainResult;
                    int reamainSearchStatus = this.SearchRemain(goodsUnitData, out reamainResult);

                    if ((reamainSearchStatus == 0) && (reamainResult != null))
                    {
                        retList.Add(reamainResult);
                    }
                    else
                    {
                        retList.Add(goodsUnitData);
                    }

                    //>>>2010/06/26
                    ////>>>2010/02/26
                    //#region BLコード変換
                    //if ((this._salesSlipInputInitDataAcs.GetScmTtlSt().BLCodeChgDiv == 0) &&
                    //    (this._salesSlipInputAcs.SalesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM))
                    //{
                    //    // BLコード変換テーブル更新
                    //    this._salesSlipInputAcs.MakeBLCodeChgDataTable(goodsUnitData.BLGoodsCode);

                    //    // BLコード変換選択ウインドウ表示
                    //    if (this._salesSlipInputAcs.GetBLCodeChgCount() > 1)
                    //    {
                    //        // BLコード枝番選択ウインドウ表示
                    //        MAHNB01010UN selectBLCodeChgDialog = new MAHNB01010UN();
                    //        selectBLCodeChgDialog.SettingOrgInfo(goodsUnitData.BLGoodsCode, goodsUnitData.BLGoodsFullName);
                    //        DialogResult dialogResult = selectBLCodeChgDialog.ShowDialog(this);
                    //        switch (dialogResult)
                    //        {
                    //            case DialogResult.Cancel: // 選択無し
                    //                break;
                    //            case DialogResult.OK: // 通常処理
                    //                int blCode = this._salesSlipInputAcs.GetSelectBLCodeChg();
                    //                goodsUnitData.BLGoodsCodeChange = blCode;
                    //                break;
                    //            default:
                    //                break;
                    //        }
                    //    }
                    //}
                    //#endregion
                    ////<<<2010/02/26
                    //<<<2010/06/26
                }
                searchResult = retList;
            }
            //-----------------------------------------------------------------------------
            // 部品検索でキャンセル場合（空商品を返す）
            //-----------------------------------------------------------------------------
            else if (searchStatus == -1)
            {
                retStasus = -1;
                searchResult = null;
            }
            //-----------------------------------------------------------------------------
            // 部品検索でヒットしなかった場合（空商品を返す）
            //-----------------------------------------------------------------------------
            else if ((searchStatus == -2) && (goodsUnitDataList.Count > 0))
            {
                retStasus = 0;

                ArrayList retList = new ArrayList();
                retList.Add(goodsUnitDataList[0]);
                searchResult = retList;
            }

            return retStasus;
        }

        /// <summary>
        /// 残検索
        /// </summary>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>0:検索OK</returns>
        /// <br>Note       : 残数自動表示区分に従って受注残照会、出荷残照会を起動します。</br>
        /// <br>             検索結果については、ヒットした処理（出荷残or受注残）によってクラスが異なります。</br>
        private int SearchRemain(GoodsUnitData goodsUnitData, out object retObj)
        {
            retObj = null;

            int index = this.GetActiveRowIndex();
            if (this._salesDetailDataTable[index].SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount) return -1;
            if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) return -1;
            if ((this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) ||
                (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate) ||
                (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)) return -1;

            List<RemainSearchProc> remainSearchProcList = new List<RemainSearchProc>();

            // 残検索メソッドの設定（全体初期値設定マスタの残数自動表示区分によって分岐）
            switch ((SalesSlipInputAcs.RemCntAutoDspDiv)this._salesSlipInputInitDataAcs.GetAllDefSet().RemCntAutoDspDiv)
            {
                // 出入荷残のみ
                case SalesSlipInputAcs.RemCntAutoDspDiv.ShipmentAndArrivalOnly:
                    remainSearchProcList.Add(this.SearchShipmentRemain);
                    break;
                // 受発注残のみ
                case SalesSlipInputAcs.RemCntAutoDspDiv.AcptAnOrderAndOrderOnly:
                    remainSearchProcList.Add(this.SearchAcceptAnOrderRemain);
                    break;
                // 出入荷残→受発注残
                case SalesSlipInputAcs.RemCntAutoDspDiv.ShipmentAndArrivalNextAcptAnOrderAndOrder:
                    remainSearchProcList.Add(this.SearchShipmentRemain);
                    remainSearchProcList.Add(this.SearchAcceptAnOrderRemain);
                    break;
                // 受発注残→出入荷残
                case SalesSlipInputAcs.RemCntAutoDspDiv.AcptAnOrderAndOrderNextShipmentAndArrival:
                    remainSearchProcList.Add(this.SearchAcceptAnOrderRemain);
                    remainSearchProcList.Add(this.SearchShipmentRemain);
                    break;
            }

            // 出荷伝票の場合は出荷残を検索しない
            if (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment)
            {
                if (remainSearchProcList.Contains(this.SearchShipmentRemain))
                {
                    remainSearchProcList.Remove(this.SearchShipmentRemain);
                }
            }

            foreach (RemainSearchProc remainSearch in remainSearchProcList)
            {
                int st = remainSearch(goodsUnitData, out retObj);
                if ((st == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (retObj != null))
                {
                    return 0;
                }
            }
            return -1;
        }

        /// <summary>
        /// 受注残検索
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="retObj"></param>
        /// <returns></returns>
        private int SearchAcceptAnOrderRemain(GoodsUnitData goodsUnitData, out object retObj)
        {
            retObj = null;

            DCJUT04110UA acceptAnOrderGuide = new DCJUT04110UA();
            try
            {
                acceptAnOrderGuide.Standard_UGroupBox_Expand = false;
                acceptAnOrderGuide.AutoSearch = false;
                acceptAnOrderGuide.MaxSelectCount = 1;

                acceptAnOrderGuide.SearchCndtn.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
                acceptAnOrderGuide.SearchCndtn.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
                acceptAnOrderGuide.SearchCndtn.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
                acceptAnOrderGuide.SearchCndtn.CustomerName = this._salesSlipInputAcs.SalesSlip.CustomerSnm;
                acceptAnOrderGuide.SearchCndtn.GoodsNo = goodsUnitData.GoodsNo;
                acceptAnOrderGuide.SearchCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                acceptAnOrderGuide.SearchCndtn.MakerName = goodsUnitData.MakerName;
                acceptAnOrderGuide.SearchCndtn.ArrivalStateDiv = DCJUT04110UA.ArrivalState.NonArrival;
                acceptAnOrderGuide.SearchCndtn.St_SalesDate = this._salesSlipInputAcs.SalesSlip.SalesDate;
                acceptAnOrderGuide.SearchCndtn.Ed_SalesDate = this._salesSlipInputAcs.SalesSlip.SalesDate;

                acceptAnOrderGuide.CustomerCodeFix = true;

                int retSt;
                if (acceptAnOrderGuide.InitialSearch())
                {
                    retSt = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    DialogResult dialogResult = acceptAnOrderGuide.ShowDialog(this);
                    if (DialogResult.OK == dialogResult)
                    {
                        List<AcptAnOdrRemainRefData> acptList = acceptAnOrderGuide.GetSelectDataList();
                        AcptAnOdrRemainRefData acptAnOdrRemainRefData = acptList[0];
                        retObj = acptAnOdrRemainRefData;
                    }
                }
                else
                {
                    retSt = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                return retSt;
            }
            finally
            {
                acceptAnOrderGuide.Dispose();
            }

        }

        /// <summary>
        /// 出荷残検索
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="retObj"></param>
        /// <returns></returns>
        private int SearchShipmentRemain(GoodsUnitData goodsUnitData, out object retObj)
        {
            int retSt;
            retObj = null;
            List<SalHisRefResultParamWork> salHisRefResultParamWorkList;
            DCHNB04101UA salesHisGuide = new DCHNB04101UA();
            try
            {
                salesHisGuide.AcptAnOdrStatus = (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment;
                salesHisGuide.AcptAnOdrStatusFix = true;
                salesHisGuide.AutoSearch = true;
                salesHisGuide.MaxSelectCount = 1;
                salesHisGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
                salesHisGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
                salesHisGuide.CustomerCodeFix = true;
                salesHisGuide.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
                salesHisGuide.CustomerName = this._salesSlipInputAcs.SalesSlip.CustomerSnm;
                salesHisGuide.SalesEmployeeCd = this._salesSlipInputAcs.SalesSlip.SalesEmployeeCd;
                salesHisGuide.SalesEmployeeName = this._salesSlipInputAcs.SalesSlip.SalesEmployeeNm;
                salesHisGuide.SalesInputCode = this._salesSlipInputAcs.SalesSlip.SalesInputCode;
                salesHisGuide.SalesInputName = this._salesSlipInputAcs.SalesSlip.SalesInputName;
                salesHisGuide.FrontEmployeeCd = this._salesSlipInputAcs.SalesSlip.FrontEmployeeCd;
                salesHisGuide.FrontEmployeeName = this._salesSlipInputAcs.SalesSlip.FrontEmployeeNm;
                salesHisGuide.GoodsNo = goodsUnitData.GoodsNo;
                salesHisGuide.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                salesHisGuide.GoodsMakerName = goodsUnitData.MakerName;
                salesHisGuide.SalesSlipCd = (this._salesSlipInputAcs.SalesSlip.AccRecDivCd == (int)SalesSlipInputAcs.AccRecDivCd.AccRec) ? 0 : 100; // 0: 掛売上 1:掛返品 100:現金売上 101:現金返品
                salesHisGuide.SalesSlipCdFix = true;

                if (salesHisGuide.SearchData())
                {
                    retSt = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    DialogResult dialogResult = salesHisGuide.ShowDialog(this, (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment, this._salesSlipInputAcs.SalesSlip.CustomerCode);
                    if (dialogResult == DialogResult.OK)
                    {
                        salHisRefResultParamWorkList = salesHisGuide.StcHisRefDataWork;
                        SalHisRefResultParamWork salHisRefResultParamWork = salHisRefResultParamWorkList[0];
                        retObj = salHisRefResultParamWork;
                    }
                }
                else
                {
                    retSt = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                return retSt;
            }
            finally
            {
                salesHisGuide.Dispose();
            }

        }

        /// <summary>
        /// 品番検索
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsName">品名</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns>0:検索OK -1:キャンセル</returns>
        private int SearchPartsFromGoodsNo(string goodsNo, int goodsMakerCd, string goodsName, int blGoodsCode, int salesRowNo, out List<GoodsUnitData> goodsUnitDataList, out List<Stock> stockList)
        {
            //-------------------------------------------------------------
            // 初期処理
            //-------------------------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            goodsUnitDataList = new List<GoodsUnitData>();
            stockList = new List<Stock>();

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "SearchPartsFromGoodsNo", "●品番検索　開始");
            #region ●品番検索
            //-------------------------------------------------------------
            // 品番検索
            //-------------------------------------------------------------
            status = this._salesSlipInputAcs.SearchPartsFromGoodsNo(this._enterpriseCode, this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd, goodsMakerCd, goodsNo, salesRowNo, out goodsUnitDataList);
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "SearchPartsFromGoodsNo", "○品番検索　終了");

            //-------------------------------------------------------------
            // 部品検索後処理
            //-------------------------------------------------------------
            if ((status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
            {
                return 0;
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                // キャンセル
                return -1;
            }
            else
            {
                // 空情報セット
                goodsUnitDataList.Add(this._salesSlipInputAcs.CreateEmptyGoods(goodsNo, goodsName, goodsMakerCd, blGoodsCode));
                return -2;
            }
        }

        /// <summary>
        /// BLコード検索
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="searchResult">検索結果</param>
        /// <returns></returns>
        private int SearchPartsFromBLCode(int salesRowNo, int bLGoodsCode, out object searchResult)
        {
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            searchResult = null;
            List<GoodsUnitData> goodsUnitDataList;
            List<Stock> stockList;
            int searchStatus;
            int retStasus = -1;

            //-----------------------------------------------------------------------------
            // BLコード検索
            //-----------------------------------------------------------------------------
            searchStatus = this.SearchPartsFromBLCodeProc(salesRowNo, bLGoodsCode, out goodsUnitDataList, out stockList);

            //-----------------------------------------------------------------------------
            // BLコード検索でヒットした場合
            //-----------------------------------------------------------------------------
            if ((searchStatus == 0) && (goodsUnitDataList.Count > 0))
            {
                ArrayList retList = new ArrayList();
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    if (this._salesInputConstructionAcs.SalesInputConstruction.DataInputCountValue <= retList.Count) break;

                    retStasus = 0;
                    object reamainResult;
                    int reamainSearchStatus = this.SearchRemain(goodsUnitData, out reamainResult);

                    if ((reamainSearchStatus == 0) && (reamainResult != null))
                    {
                        retList.Add(reamainResult);
                    }
                    else
                    {
                        retList.Add(goodsUnitData);
                    }

                    //>>>2010/06/26
                    ////>>>2010/02/26
                    //#region BLコード変換
                    ////>>>2010/04/27
                    ////if (this._salesSlipInputAcs.SalesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM)
                    //if ((this._salesSlipInputInitDataAcs.GetScmTtlSt().BLCodeChgDiv != 0) &&
                    //    (this._salesSlipInputAcs.SalesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM))
                    ////<<<2010/04/27
                    //{
                    //    goodsUnitData.BLGoodsCodeChange = bLGoodsCode;
                    //}
                    //#endregion
                    ////<<<2010/02/26
                    //<<<2010/06/26
                }
                searchResult = retList;
            }
            //-----------------------------------------------------------------------------
            // BLコード検索でヒットしなかった場合（空商品を返す）
            //-----------------------------------------------------------------------------
            else if ((searchStatus == -2) && (goodsUnitDataList.Count <= 0))
            {
                retStasus = -2;

                ArrayList retList = new ArrayList();
                //retList.Add(goodsUnitDataList[0]);
                searchResult = retList;
            }
            //-----------------------------------------------------------------------------
            // 車両情報無し
            //-----------------------------------------------------------------------------
            else if (searchStatus == -3)
            {
                retStasus = -3;
                ArrayList retList = new ArrayList();
                searchResult = retList;
            }

            return retStasus;
        }

        /// <summary>
        /// BLコード検索
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="stockList">在庫データオブジェクトリスト</param>
        /// <returns></returns>
        private int SearchPartsFromBLCodeProc(int salesRowNo, int bLGoodsCode, out List<GoodsUnitData> goodsUnitDataList, out List<Stock> stockList)
        {
            //-------------------------------------------------------------
            // 初期処理
            //-------------------------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            goodsUnitDataList = new List<GoodsUnitData>();
            stockList = new List<Stock>();

            //>>>2010/02/26
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "▽ＢＬコード枝番処理　開始");
            #region ●BLコード枝番処理
            int blGoodsDrCode = 0;

            // BLコード枝番データテーブル反映
            this._salesSlipInputAcs.MakeBLGoodsDrDataTable(bLGoodsCode);
            if ((this._salesSlipInputAcs.BLGoodsDrDataTable != null) &&
                (this._salesSlipInputAcs.BLGoodsDrDataTable.Count != 0) &&
                (this._salesSlipInputAcs.BLGoodsDrDataTable.Count != 1))
            {
                // BLコード枝番選択ウインドウ表示
                MAHNB01010UM selectBLGoodsDrDialog = new MAHNB01010UM();
                DialogResult dialogResult = selectBLGoodsDrDialog.ShowDialog(this);
                switch (dialogResult)
                {
                    case DialogResult.Cancel: // 選択無し
                        break;
                    case DialogResult.OK: // 通常処理
                        blGoodsDrCode = this._salesSlipInputAcs.GetSelectBLGoodsDrCd();
                        break;
                    default:
                        break;
                }
            }
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "△ＢＬコード枝番処理　終了");
            //<<<2010/02/26

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "SearchPartsFromBLCode", "●BLコード検索　開始");
            #region ●BLコード検索
            //-------------------------------------------------------------
            // BLコード検索
            //-------------------------------------------------------------
            //>>>2010/02/26
            //status = this._salesSlipInputAcs.SearchPartsFromBLCode(salesRowNo, this._enterpriseCode, this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd, bLGoodsCode, out goodsUnitDataList);
            status = this._salesSlipInputAcs.SearchPartsFromBLCode(salesRowNo, this._enterpriseCode, this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd, bLGoodsCode, blGoodsDrCode, out goodsUnitDataList);
            //<<<2010/02/26
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "SearchPartsFromBLCode", "○BLコード検索　終了");

            //-------------------------------------------------------------
            // 部品検索後処理
            //-------------------------------------------------------------
            if ((status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
            {
            }
            else if (status == -3)
            {
                // 車両情報無し
                return -3;
            }
            else if (status == -1)
            {
                // キャンセル
                return -1;
            }
            else
            {
                // 該当なし
                return -2;
            }

            return 0;
        }

        /// <summary>
        /// TBO検索
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="searchResult">検索結果</param>
        /// <returns></returns>
        private int SearchTBO(int salesRowNo, out object searchResult)
        {
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            searchResult = null;
            List<GoodsUnitData> goodsUnitDataList;
            int searchStatus;
            int retStasus = -1;

            //-----------------------------------------------------------------------------
            // TBO検索
            //-----------------------------------------------------------------------------
            searchStatus = this.SearchTBO(salesRowNo, out goodsUnitDataList);

            //-----------------------------------------------------------------------------
            // TBO検索でヒットした場合
            //-----------------------------------------------------------------------------
            if ((searchStatus == 0) && (goodsUnitDataList.Count > 0))
            {
                ArrayList retList = new ArrayList();
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    retStasus = 0;
                    retList.Add(goodsUnitData);
                }
                searchResult = retList;
            }
            //-----------------------------------------------------------------------------
            // TBO検索でヒットしなかった場合（空商品を返す）
            //-----------------------------------------------------------------------------
            else if ((searchStatus == -2) && (goodsUnitDataList.Count > 0))
            {
                retStasus = 0;

                ArrayList retList = new ArrayList();
                //retList.Add(goodsUnitDataList[0]);
                searchResult = retList;
            }
            //-----------------------------------------------------------------------------
            // 車両情報無し
            //-----------------------------------------------------------------------------
            else if (searchStatus == -3)
            {
                retStasus = -3;
                ArrayList retList = new ArrayList();
                searchResult = retList;
            }


            return retStasus;
        }

        /// <summary>
        /// TBO検索
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        private int SearchTBO(int salesRowNo, out List<GoodsUnitData> goodsUnitDataList)
        {
            //-------------------------------------------------------------
            // 初期処理
            //-------------------------------------------------------------
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            goodsUnitDataList = new List<GoodsUnitData>();

            //-------------------------------------------------------------
            // TBO検索
            //-------------------------------------------------------------
            status = this._salesSlipInputAcs.SearchTBO(salesRowNo, this._enterpriseCode, this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd, out goodsUnitDataList);

            //-------------------------------------------------------------
            // TBO検索後処理
            //-------------------------------------------------------------
            if ((status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
            {
                return 0;
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else if (status == -3)
            {
                // 車両情報無し
                return -3;
            }
            else
            {
                //// 空情報セット
                //goodsUnitDataList.Add(this._salesSlipInputAcs.CreateEmptyGoods(string.Empty));
                return -2;
            }
        }
        #endregion

        /// <summary>
        /// 仕入表示処理
        /// </summary>
        internal void DisplayStockInfo()
        {
            this.DisplayStockInfo(this.GetActiveRowIndex());
        }

        /// <summary>
        /// 仕入表示処理
        /// </summary>
        /// <param name="rowIndex">対象行</param>
        private void DisplayStockInfo(int rowIndex)
        {
            if (this._salesDetailDataTable[rowIndex] != null)
            {
                if (this._salesSlipInputAcs.ExistStockTemp(this._salesDetailDataTable[rowIndex].SalesRowNo) == true)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.SupplierSlipExistColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.SupplierSlipExistColumn.ColumnName].Appearance.Image = null;
                }

                //this._salesSlipInputAcs.SalesUnitCostSetting(this._salesDetailDataTable[rowIndex].SalesRowNo);
            }
        }

        /// <summary>
        /// オープン価格情報表示
        /// </summary>
        internal void DisplayOpenPrice()
        {
            this.DisplayOpenPrice(this.GetActiveRowIndex());
        }

        /// <summary>
        /// オープン価格情報表示
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayOpenPrice(int rowIndex)
        {
            if (rowIndex == -1) return;
            if (this._salesDetailDataTable[rowIndex] != null)
            {
                if ((Int32)this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.OpenPriceDivColumn.ColumnName].Value == 1)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName].Appearance.Image = null;
                }
            }
        }

        /// <summary>
        /// 最終行に空白行を追加します。
        /// </summary>
        private void AddLastEmptyRow()
        {
            // 最終行に商品コード、商品名称が設定されている場合は１行追加
            if ((!string.IsNullOrEmpty(this._salesDetailDataTable[this._salesDetailDataTable.Count - 1].GoodsName)) ||
                (!string.IsNullOrEmpty(this._salesDetailDataTable[this._salesDetailDataTable.Count - 1].GoodsNo)))
            {
                this._salesSlipInputAcs.AddSalesDetailRow();

                // 表示用行番号調整処理
                this._salesSlipInputAcs.AdjustRowNo();

                // 明細グリッド・行単位でのセル設定
                this.SettingGridRow(this._salesDetailDataTable.Count - 1, this._salesSlipInputAcs.SalesSlip);
            }
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region Public Methods
        /// <summary>
        /// 売上履歴ボタンクリック処理(明細選択)
        /// </summary>
        public void SalesReferenceSearch()
        {
            this.uButton_SalesReference_Click(this.uGrid_Details, new EventArgs());
        }

        /// <summary>
        /// 受注照会ボタンクリック処理(明細選択)
        /// </summary>
        public void AcceptAnOrderReferenceSearch()
        {
            this.uButton_AcceptAnOrderReference_Click(this.uGrid_Details, new EventArgs());
        }

        /// <summary>
        /// 出荷照会ボタンクリック処理(明細選択)
        /// </summary>
        public void ShipmentReferenceSearch()
        {
            this.uButton_ShipmentReference_Click(this.uGrid_Details, new EventArgs());
        }

        /// <summary>
        /// 見積照会ボタンクリック処理(明細選択)
        /// </summary>
        public void EstimateReferenceSearch()
        {
            this.uButton_EstimateReference_Click(this.uGrid_Details, new EventArgs());
        }

        /// <summary>
        ///  明細部フォーカス位置設定処理
        /// </summary>
        /// <param name="columnName"></param>
        public void SettingFocus(string columnName)
        {
            int index = this.GetActiveRowIndex();
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable[index];
            if ((row.EditStatus != SalesSlipInputAcs.ctEDITSTATUS_RowDiscount) &&
                (row.EditStatus != SalesSlipInputAcs.ctEDITSTATUS_Annotation))
            {
                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[columnName];
            }
            else
            {
                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
            }
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// データテーブル設定処理
        /// </summary>
        public void SettingDataTable(SalesInputDataSet.SalesDetailDataTable salesDetailDataTableSave)
        {
            this._salesDetailDataTable = salesDetailDataTableSave;
        }
        #endregion

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
            this.uGrid_Details.DataSource = this._salesDetailDataTable;

            // ツールチップ初期設定処理
            this.ToolTipInfoInitialSetting();

            // グリッドキーマッピング設定処理
            this.MakeKeyMappingForGrid(this.uGrid_Details);
        }

        /// <summary>
        /// オプション情報反映処理
        /// </summary>
        public void SettingOptionInfo()
        {
            #region ●ＵＯＥオプション
            if (this._salesSlipInputInitDataAcs.Opt_UOE == (int)SalesSlipInputInitDataAcs.Option.ON)
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["ControlContainerTool_InputOrderInfo"].CustomizedVisible = Infragistics.Win.DefaultableBoolean.True;
            }
            else
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["ControlContainerTool_InputOrderInfo"].CustomizedVisible = Infragistics.Win.DefaultableBoolean.False;
            }
            #endregion

            #region ●仕入支払管理オプション
            if (this._salesSlipInputInitDataAcs.Opt_StockingPayment == (int)SalesSlipInputInitDataAcs.Option.ON)
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["ControlContainerTool_InputStockInfo"].CustomizedVisible = Infragistics.Win.DefaultableBoolean.True;
            }
            else
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["ControlContainerTool_InputStockInfo"].CustomizedVisible = Infragistics.Win.DefaultableBoolean.False;
            }
            #endregion

            //>>>2010/02/26
            #region ●SCMオプション
            if (this._salesSlipInputInitDataAcs.Opt_SCM == (int)SalesSlipInputInitDataAcs.Option.ON)
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["ControlContainerTool_SCM"].CustomizedVisible = Infragistics.Win.DefaultableBoolean.True;
            }
            else
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["ControlContainerTool_SCM"].CustomizedVisible = Infragistics.Win.DefaultableBoolean.False;
            }
            #endregion
            //<<<2010/02/26
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
            this.GridSetting(this._salesInputConstructionAcs.SalesInputConstruction);
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
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            if (this._beforeCell != null)
            {
                if (this._beforeCell.Column.DataType == typeof(string) &&
                    this._beforeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // ゼロ詰め実行
                    this._salesDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key] = uiSetControl1.GetZeroPaddedText(this._beforeCell.Column.Key, (string)this._salesDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key].ToString().Trim());
                }

                // ForeColor戻し
                this._beforeCell.Band.Override.ActiveCellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
            }

            //// ここ
            //if (((_beforeCell.Column.DataType == typeof(Int32)) || (_beforeCell.Column.DataType == typeof(Int64)) || (_beforeCell.Column.DataType == typeof(double))) && (_beforeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit))
            //{
            //    if (_beforeCell.Value == DBNull.Value)
            //    {
            //        this._salesDetailDataTable.Rows[_beforeCell.Row.Index][_beforeCell.Column.Key] = 0;
            //    }
            //}

            //--------------------------------------------
            // 表示内容切替
            //--------------------------------------------
            // 納品区分名称
            if (this._beforeCell.Column.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName)
            {
                this._salesDetailDataTable[this._beforeCell.Row.Index].DeliveredGoodsDivNm = this._salesDetailDataTable[this._beforeCell.Row.Index].DeliveredGoodsDivNmSave;
            }
            // Ｈ納品区分名称
            if (this._beforeCell.Column.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName)
            {
                this._salesDetailDataTable[this._beforeCell.Row.Index].FollowDeliGoodsDivNm = this._salesDetailDataTable[this._beforeCell.Row.Index].FollowDeliGoodsDivNmSave;
            }
            // 指定拠点名称
            if (this._beforeCell.Column.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
            {
                this._salesDetailDataTable[this._beforeCell.Row.Index].UOEResvdSectionNm = this._salesDetailDataTable[this._beforeCell.Row.Index].UOEResvdSectionNmSave;
            }
            //>>>2010/02/26
            // RC区分
            if (this._beforeCell.Column.Key == this._salesDetailDataTable.RecycleDivNmColumn.ColumnName)
            {
                this._salesDetailDataTable[this._beforeCell.Row.Index].RecycleDivNm = this._salesDetailDataTable[this._beforeCell.Row.Index].RecycleDivNmSave;
            }
            //<<<2010/02/26
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2010/03/16 張凱 品名未入力時のフォーカス制御の変更(保守依頼４)　仕様変更</br>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ComponentBlanketControl.BeginUpdate(this._detailButtonControlList);

                #region ActiveCell判定
                //--------------------------------------------------
                // ActivCell判定
                //--------------------------------------------------
                if (this.uGrid_Details.ActiveCell != null)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

                    #region ESC
                    //--------------------------------------------------
                    // ESC
                    //--------------------------------------------------
                    if (e.KeyCode == Keys.Escape)
                    {
                        // 売上明細データテーブルRowStatus列初期化処理
                        this._salesSlipInputAcs.InitializeSalesDetailRowStatusColumn();

                        // 明細グリッドセル設定処理
                        this.SettingGrid();

                        // 日付項目でESC入力された場合、処理キャンセル
                        if ((cell.Column.Key == this._salesDetailDataTable.StockDateColumn.ColumnName) ||
                            (cell.Column.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName))
                        {
                            e.Handled = true;
                        }
                    }
                    #endregion

                    #region HOME
                    //--------------------------------------------------
                    // HOME
                    //--------------------------------------------------
                    if (e.KeyCode == Keys.Home)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];

                        if (this._salesSlipInputAcs.CostDisplay == false)
                        {
                            this._salesSlipInputAcs.CostDisplay = true;
                        }
                        else
                        {
                            this._salesSlipInputAcs.CostDisplay = false;
                        }
                        // 明細再表示
                        this.SettingGrid();

                        // Visible設定
                        this.SettingVisibleEventCall();
                    }
                    #endregion

                    #region Shift
                    //--------------------------------------------------
                    // Shift
                    //--------------------------------------------------
                    if (e.Shift)
                    {
                        switch (e.KeyCode)
                        {
                            //--------------------------------------------------
                            // Down
                            //--------------------------------------------------
                            case Keys.Down:
                                {
                                    this.uGrid_Details.ActiveCell = null;
                                    this.uGrid_Details.ActiveRow = cell.Row;
                                    this.uGrid_Details.Selected.Rows.Clear();
                                    this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                    break;
                                }
                            //--------------------------------------------------
                            // Up
                            //--------------------------------------------------
                            case Keys.Up:
                                {
                                    this.uGrid_Details.ActiveCell = null;
                                    this.uGrid_Details.ActiveRow = cell.Row;
                                    this.uGrid_Details.Selected.Rows.Clear();
                                    this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                    break;
                                }
                            //--------------------------------------------------
                            // Home
                            //--------------------------------------------------
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
                            //--------------------------------------------------
                            // End
                            //--------------------------------------------------
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

                                        if (this.uGrid_Details.Rows[lastInputRowIndex].Cells[this._salesDetailDataTable.DtlNoteColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
                                        {
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[lastInputRowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                                        }
                                        else
                                        {
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[lastInputRowIndex].Cells[this._salesDetailDataTable.DtlNoteColumn.ColumnName];
                                        }

                                        this.MoveNextAllowEditCell(true);
                                    }
                                    break;
                                }
                        }
                    }
                    #endregion

                    #region Alt
                    //--------------------------------------------------
                    // Alt
                    //--------------------------------------------------
                    else if (e.Alt)
                    {
                        switch (e.KeyCode)
                        {
                            //--------------------------------------------------
                            // Down
                            //--------------------------------------------------
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
                    #endregion

                    #region その他
                    else
                    {
                        // 編集中であった場合
                        if (cell.IsInEditMode)
                        {
                            // セルのスタイルにて判定
                            switch (this.uGrid_Details.ActiveCell.StyleResolved)
                            {
                                // テキストボックス・テキストボックス(ボタン付)・日付
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.Date:
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
                                                    // --- UPD 2009/10/19 ---------->>>>>
                                                    if (cell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName)
                                                    {
                                                        // 2009/11/18 >>>
                                                        //if (!string.IsNullOrEmpty(this.uGrid_Details.ActiveCell.Text) &&
                                                        //    !"0".Equals(this.uGrid_Details.ActiveCell.Text))

                                                        if (!string.IsNullOrEmpty(this.uGrid_Details.ActiveCell.Text) &&
                                                           ((!"0".Equals(this.uGrid_Details.ActiveCell.Text)||
                                                            ( ( "0".Equals(this.uGrid_Details.ActiveCell.Text) ) &&
                                                              (( this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch ) ||
                                                               (( this._salesSlipInputInitDataAcs.GetSalesTtlSt().BLGoodsCdInpDiv == 0 ) &&
                                                               !string.IsNullOrEmpty((string)this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Value) ) ) ) ) ))
                                                        // 2009/11/18 <<<
                                                        {
                                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                            e.Handled = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // --- UPD 2009/12/23 ---------->>>>>
                                                        //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                        //e.Handled = true;
                                                        if (cell.Column.Key == this._salesDetailDataTable.GoodsNameColumn.ColumnName
                                                            && (string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString())))
                                                        {
                                                            e.Handled = true;
                                                        }
                                                        else if (cell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
                                                        {
                                                            if (CheckRowEffective(cell.Row.Index))
                                                            {
                                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                                e.Handled = true;
                                                            }
                                                            // --- ADD 2010/03/16 ---------->>>>>
                                                            else
                                                            {
                                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                                                e.Handled = true;
                                                            }
                                                            // --- ADD 2010/03/16 ----------<<<<<
                                                        }
                                                        else
                                                        {
                                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                            e.Handled = true;
                                                        }
                                                        // --- UPD 2009/12/23 ----------<<<<<
                                                    }
                                                  // --- UPD 2009/10/19 ----------<<<<<
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
                                    if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                    {
                                        // 編集モードの場合はなにもしない
                                    }
                                    else
                                    {
                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                        this.MoveNextAllowEditCell(true);
                                    }
                                    break;
                                }
                            case Keys.End:
                                {
                                    // 編集モードの場合はなにもしない
                                    if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                    {
                                        //
                                    }
                                    else
                                    {
                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                        this.MoveNextAllowEditCell(true);
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if ((this.uGrid_Details.ActiveCell != null) && (!this.uGrid_Details.ActiveCell.DroppedDown))
                                    {
                                        //--------------------------------------------------
                                        // 先頭行(上段はヘッダ部移動 下段はセル移動)
                                        //--------------------------------------------------
                                        #region
                                        if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                                        {
                                            if (this.MoveUpDownCell(e.KeyCode, true, false) == true)
                                            {
                                                e.Handled = true;
                                            }
                                            else
                                            {
                                                if (this.GridKeyDownTopRow != null)
                                                {
                                                    // --- UPD 2009/11/16 ---------->>>>>
                                                    // --- UPD 2009/11/24 ---------->>>>>
                                                    //if (this.CheckSalesUnitCost())
                                                    if (this.CheckSalesUnitCost() && this.CheckSalesRateAndUnPrcDisplay())
                                                    // --- UPD 2009/11/24 ----------<<<<<
                                                    {
                                                        this.GridKeyDownTopRow(this, new EventArgs());
                                                        e.Handled = true;
                                                    }
                                                    else
                                                    {
                                                        e.Handled = true;
                                                    }
                                                    // --- UPD 2009/11/16 ----------<<<<<
                                                }
                                            }
                                        }

                                        //--------------------------------------------------
                                        // 先頭行以外(上段は前行移動 下段はセル移動)
                                        //--------------------------------------------------
                                        else
                                        {
                                            if (this.MoveUpDownCell(e.KeyCode) == true)
                                            {
                                                e.Handled = true;
                                            }
                                        }
                                        #endregion
                                    }
                                    break;
                                }
                            case Keys.Down:
                                {
                                    //--------------------------------------------------
                                    // 最終行(上段はセル移動 下段はフッタ部移動)
                                    //--------------------------------------------------
                                    if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                                    {
                                        if (e.KeyCode == Keys.Down)
                                        {
                                            // --- ADD 2009/12/23 ---------->>>>>
                                            if (cell.Column.Key == this._salesDetailDataTable.GoodsNameColumn.ColumnName
                                                && (string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString())))
                                            {
                                                e.Handled = true;
                                                break;
                                            }
                                            // --- ADD 2009/12/23 ----------<<<<<

                                            if (this.MoveUpDownCell(e.KeyCode, false, true) == true)
                                            {
                                                e.Handled = true;
                                            }
                                            else
                                            {
                                                // --- ADD 2009/12/23 ---------->>>>>
                                                #region 最終行 移動無し
                                                bool checkFlag = false;
                                                if (this._salesDetailDataTable != null)
                                                {
                                                    checkFlag = CheckRowEffective(cell.Row.Index);

                                                    if (checkFlag == false)
                                                    {
                                                        e.Handled = true;
                                                        break;
                                                    }
                                                }
                                                #endregion
                                                // --- ADD 2009/12/23 ----------<<<<<

                                                if (this.GridKeyDownButtomRow != null)
                                                {
                                                    // --- UPD 2009/11/16 ---------->>>>>
                                                    // --- UPD 2009/11/24 ---------->>>>>
                                                    //if (this.CheckSalesUnitCost())
                                                    if (this.CheckSalesUnitCost() && this.CheckSalesRateAndUnPrcDisplay())
                                                    // --- UPD 2009/11/24 ----------<<<<<
                                                    {
                                                        this.GridKeyDownButtomRow(this, new EventArgs());
                                                        e.Handled = true;
                                                    }
                                                    else
                                                    {
                                                        e.Handled = true;
                                                    }
                                                    // --- UPD 2009/11/16 ----------<<<<<
                                                }
                                            }
                                        }
                                    }
                                    //--------------------------------------------------
                                    // 最終行以外(上段はセル移動 下段は次行移動)
                                    //--------------------------------------------------
                                    else
                                    {
                                        //// 単位でアクティブ時はフォーカス移動しない
                                        //if ((this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.UnitCodeColumn.ColumnName) &&
                                        //    (this.uGrid_Details.ActiveCell.Activated == true))
                                        //{
                                        //    e.Handled = false;
                                        //}
                                        //else
                                        //{
                                        // --- UPD 2009/10/19 ---------->>>>>
                                        if (cell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName)
                                        {
                                            if (!string.IsNullOrEmpty(this.uGrid_Details.ActiveCell.Text) &&
                                                !"0".Equals(this.uGrid_Details.ActiveCell.Text))
                                            {
                                                if (this.MoveUpDownCell(e.KeyCode) == true)
                                                {
                                                    e.Handled = true;
                                                }
                                            }
                                            else
                                            {
                                                // 2009/11/18 >>>
                                                //if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().BLGoodsCdInpDiv == 0) // 売上全体設定マスタ BL商品コード入力区分 0:任意　1:必須

                                                if (( this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch ) &&    // BL検索モード
                                                    ( ( this._salesSlipInputInitDataAcs.GetSalesTtlSt().BLGoodsCdInpDiv == 1 ) ||                               // 売上全体設定マスタ BL商品コード入力区分 0:任意　1:必須
                                                      ( string.IsNullOrEmpty((string)this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Value)) )) // 部品検索無し
                                                {
                                                }
                                                else
                                                // 2009/11/18 <<<
                                                {
                                            if (this.MoveUpDownCell(e.KeyCode) == true)
                                            {
                                                e.Handled = true;
                                            }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // --- UPD m.suzuki 2010/03/10 ---------->>>>>
                                            //// --- UPD 2009/12/23 ---------->>>>>
                                            ////if (this.MoveUpDownCell(e.KeyCode) == true)
                                            ////{
                                            ////    e.Handled = true;
                                            ////}
                                            //if (cell.Column.Key == this._salesDetailDataTable.GoodsNameColumn.ColumnName
                                            //    && (string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString())))
                                            //{
                                            //    e.Handled = true;
                                            //}
                                            //else
                                            //{
                                            //if (this.MoveUpDownCell(e.KeyCode) == true)
                                            //{
                                            //    e.Handled = true;
                                            //}
                                            //}
                                            //// --- UPD 2009/12/23 ----------<<<<<

                                                if (this.MoveUpDownCell(e.KeyCode) == true)
                                                {
                                                    e.Handled = true;
                                                }
                                            // --- UPD m.suzuki 2010/03/10 ----------<<<<<
                                        }
                                        // --- UPD 2009/10/19 ----------<<<<<
                                        //}
                                    }

                                    break;
                                }
                        }
                    }
                    #endregion
                }
                #endregion

                #region ActiveRow判定
                //--------------------------------------------------
                // ActivRow判定
                //--------------------------------------------------
                else if (this.uGrid_Details.ActiveRow != null)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

                    switch (e.KeyCode)
                    {
                        case Keys.Delete:
                            {
                                if (this.uButton_RowDelete.Enabled)
                                {
                                    this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                                }
                                break;
                            }
                    }

                    // --- ADD 2009/12/23 ---------->>>>>
                    if (string.IsNullOrEmpty(this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName].Value.ToString()))
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                        e.Handled = true;
                        return;
                    }
                    // --- ADD 2009/12/23 ----------<<<<<

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
                #endregion

            }
            finally
            {
                ComponentBlanketControl.EndUpdate(this._detailButtonControlList);
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

            //// ActiveCellが商品ガイドボタンの場合
            //if (cell.Column.Key == this._salesDetailDataTable.GoodsGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyCode == Keys.Space)
            //    {
            //        Infragistics.Win.UltraWinGrid.CellEventArgs ce = new Infragistics.Win.UltraWinGrid.CellEventArgs(cell);
            //        this.uGrid_Details_ClickCellButton(this.uGrid_Details, ce);
            //    }
            //}
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

            //----------------------------------------------
            // コード関係はUI設定でチェック
            //----------------------------------------------
            if (cell.IsInEditMode)
            {
                // ＵＩ設定を参照
                if (uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが売単価の場合
            //----------------------------------------------
            if (cell.Column.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName)
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
            //----------------------------------------------
            // ActiveCellが原単価の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName)
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
            //----------------------------------------------
            // ActiveCellが定価の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
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
            //----------------------------------------------
            // ActiveCellが出荷数の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // --- UPD 2009/12/23 ---------->>>>>
                    //if (!this.KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    if (!this.KeyPressNumCheck(_salesInputConstructionAcs.SalesInputConstruction.ShipmentMaxCnt + 3, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    // --- UPD 2009/12/23 ----------<<<<<
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            //----------------------------------------------
            // ActiveCellが受注数の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // --- UPD 2009/12/23 ---------->>>>>
                    //if (!this.KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    if (!this.KeyPressNumCheck(_salesInputConstructionAcs.SalesInputConstruction.AcceptAnOrderMaxCnt + 3, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    // --- UPD 2009/12/23 ----------<<<<<
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            ////----------------------------------------------
            //// ActiveCellが商品ガイドボタンの場合
            ////----------------------------------------------
            //else if (cell.Column.Key == this._salesDetailDataTable.GoodsGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyChar == (char)Keys.Space)
            //    {
            //        //
            //    }
            //}
            ////----------------------------------------------
            //// ActiveCellがメーカーコードの場合
            ////----------------------------------------------
            //else if (cell.Column.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName)
            //{
            //    // 編集モード中？
            //    if (cell.IsInEditMode)
            //    {
            //        if (!this.KeyPressNumCheck(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}

            //----------------------------------------------
            // ActiveCellが売価率の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName)
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
            //----------------------------------------------
            // ActiveCellが仕入率の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.CostRateColumn.ColumnName)
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
            ////----------------------------------------------
            //// ActiveCellがBLコードの場合
            ////----------------------------------------------
            //else if (cell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName)
            //{
            //    // 編集モード中？
            //    if (cell.IsInEditMode)
            //    {
            //        if (!this.KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}
            ////----------------------------------------------
            //// ActiveCellが仕入先コードの場合
            ////----------------------------------------------
            //else if (cell.Column.Key == this._salesDetailDataTable.SupplierCdColumn.ColumnName)
            //{
            //    // 編集モード中？
            //    if (cell.IsInEditMode)
            //    {
            //        if (!this.KeyPressNumCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}
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

            SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

            if (salesSlip == null)
            {
                e.Cancel = true;
                return;
            }

            #region 品番
            //------------------------------------------------------------
            // ActiveCellが「品番」の場合
            //------------------------------------------------------------
            if (cell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
            {
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

            #region 品名
            //------------------------------------------------------------
            // ActiveCellが「品名」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.GoodsNameColumn.ColumnName)
            {
                this._beforeGoodsName = e.Cell.Value.ToString();
            }
            #endregion

            #region 売上金額
            //------------------------------------------------------------
            // ActiveCellが「売上金額」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName)
            {
                this._beforeSalesMoney = (e.Cell.Value is DBNull) ? 0 : Convert.ToInt64(e.Cell.Value);
            }
            #endregion

            #region 原価金額
            //------------------------------------------------------------
            // ActiveCellが「原価金額」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.CostColumn.ColumnName)
            {
                this._beforeCost = (e.Cell.Value is DBNull) ? 0 : Convert.ToInt64(e.Cell.Value);
            }
            #endregion

            #region 倉庫コード
            //------------------------------------------------------------
            // ActiveCellが「倉庫コード」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName)
            {
                this._beforeWarehouseCode = (e.Cell.Value is DBNull) ? string.Empty : e.Cell.Value.ToString();
            }
            #endregion

            #region 販売区分
            //------------------------------------------------------------
            // ActiveCellが「販売区分」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesCodeColumn.ColumnName)
            {
                this._beforeSalesCode = (e.Cell.Value is DBNull) ? 0 : Convert.ToInt32(e.Cell.Value);
            }
            #endregion

            #region 定価
            //------------------------------------------------------------
            // ActiveCellが「定価」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
            {
                this._beforeListPrice = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }
            #endregion

            #region 売単価
            //------------------------------------------------------------
            // ActiveCellが「売単価」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName)
            {
                this._beforeSalesUnitPrice = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }            
            #endregion

            #region 売価率
            //------------------------------------------------------------
            // ActiveCellが「売価率」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName)
            {
                this._beforeSalesRate = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }
            #endregion

            #region 原単価
            //------------------------------------------------------------
            // ActiveCellが「原単価」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName)
            {
                this._beforeSalesUnitCost = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }
            #endregion

            #region 原価率
            //------------------------------------------------------------
            // ActiveCellが「原価率」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.CostRateColumn.ColumnName)
            {
                this._beforeCostRate = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }
            #endregion

            #region メーカーコード
            //------------------------------------------------------------
            // ActiveCellが「メーカーコード」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName)
            {
                if (e.Cell.Value is DBNull)
                {
                    this._beforeGoodsMakerCd = 0;
                }
                else
                {
                    this._beforeGoodsMakerCd = this._salesDetailDataTable[e.Cell.Row.Index].GoodsMakerCd;
                }

                int editStatus = this._salesDetailDataTable[e.Cell.Row.Index].EditStatus;
                if ((editStatus != SalesSlipInputAcs.ctEDITSTATUS_RowDiscount) ||
                    (editStatus != SalesSlipInputAcs.ctEDITSTATUS_Annotation))
                {
                    switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().MakerInpDiv)
                    {
                        // 入力任意
                        case 0:
                            break;
                        // 入力必須
                        case 1:
                            if ((e.NewValue != null) && (!(e.NewValue is System.DBNull)))
                            {
                                if ((int)e.NewValue == 0)
                                {
                                    this._beforeCellUpdateCancel = true;
                                    e.Cancel = true;
                                    return;
                                }
                            }
                            else
                            {
                                this._beforeCellUpdateCancel = true;
                                e.Cancel = true;
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region 仕入先
            //------------------------------------------------------------
            // ActiveCellが「仕入先」の場合
            //------------------------------------------------------------
            else if ((cell.Column.Key == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                     (cell.Column.Key == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName))
            {
                if (e.Cell.Value is DBNull)
                {
                    this._beforeSupplierCd = 0;
                }
                else
                {
                    this._beforeSupplierCd = this._salesDetailDataTable[e.Cell.Row.Index].SupplierCd;
                }

                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SupplierInpDiv)
                {
                    // 入力任意
                    case 0:
                        break;
                    // 入力必須
                    case 1:
                        if ((e.NewValue != null) && (!(e.NewValue is System.DBNull)))
                        {
                            if ((int)e.NewValue == 0)
                            {
                                this._beforeCellUpdateCancel = true;
                                e.Cancel = true;
                                return;
                            }
                        }
                        else
                        {
                            this._beforeCellUpdateCancel = true;
                            e.Cancel = true;
                            return;
                        }
                        break;
                    default:
                        break;
                }

            }
            #endregion

            #region BLコード
            //------------------------------------------------------------
            // ActiveCellが「BLコード」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName)
            {
                this._beforeBLGoodsCode = (e.Cell.Value is DBNull) ? 0 : Convert.ToInt32(e.Cell.Value);

                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().BLGoodsCdInpDiv)
                {
                    // 入力任意
                    case 0:
                        break;
                    // 入力必須
                    case 1:
                        if ((e.NewValue != null) && (!(e.NewValue is System.DBNull)))
                        {
                            if ((int)e.NewValue == 0)
                            {
                                this._beforeCellUpdateCancel = true;
                                e.Cancel = true;
                                return;
                            }
                        }
                        else
                        {
                            this._beforeCellUpdateCancel = true;
                            e.Cancel = true;
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
            #endregion

            #region 受注数
            //------------------------------------------------------------
            // ActiveCellが「受注数」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName)
            {
                this._beforeAcptAnOdrCnt = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }            
            #endregion

            #region 出荷数
            //------------------------------------------------------------
            // ActiveCellが「出荷数」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName)
            {
                this._beforeShipmentCnt = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }            
            #endregion

            #region 得意先注番
            //------------------------------------------------------------
            // ActiveCellが「得意先注番」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName)
            {
                string partySlipNumDtl;

                if (e.NewValue is DBNull)
                {
                    partySlipNumDtl = string.Empty;
                }
                else
                {
                    partySlipNumDtl = (string)e.NewValue;
                }

                if (!this.uiSetControl1.CheckMatchingSet("tEdit_PartySlipNumDtl", partySlipNumDtl))
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "得意先注番に不正な文字が入力されています。",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                    this._beforeCellUpdateCancel = true;
                    e.Cancel = true;
                    return;
                }
            }		 
            #endregion

            #region 納品完了予定日
            //------------------------------------------------------------
            // 納品完了予定日
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
            {
                //>>>2010/02/26
                //int iDate = TStrConv.StrToIntDef(e.NewValue.ToString(), 0);

                //TDateEdit tempDate = new TDateEdit();// = (this.tDateEdit_FirstEntryDate as TDateEdit);
                //tempDate.SetLongDate(iDate);
                //DateGetAcs.CheckDateResult res = this._dateGetAcs.CheckDate(ref tempDate);
                //if (res == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_INFO,
                //        this.Name,
                //        "日付が不正です。",
                //        -1,
                //        MessageBoxButtons.OK);
                //    //this._cannotBLGoodsRead = true;
                //}
                //<<<2010/02/26
            }
            #endregion

            #region 仕入日
            //-----------------------------------------------------------------------------
            // 仕入日
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.StockDateColumn.ColumnName)
            {
            }
            #endregion

            #region 仕入伝票番号
            //-----------------------------------------------------------------------------
            // 仕入伝票番号
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName)
            {
            }
            #endregion

            #region ＢＯ区分
            //-----------------------------------------------------------------------------
            // ＢＯ区分
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName)
            {
                this._beforeBoCode = (e.Cell.Value is DBNull) ? string.Empty : e.Cell.Value.ToString();
            }
            #endregion

            #region 発注先
            //-----------------------------------------------------------------------------
            // 発注先
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName)
            {
                this._beforeUOESupplierCd = (e.Cell.Value is DBNull) ? 0 : Convert.ToInt32(e.Cell.Value);
            }
            #endregion

            #region 発注数
            //-----------------------------------------------------------------------------
            // 発注数
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName)
            {
                this._beforeAcptAnOdrCntForOrder = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }
            #endregion

            #region 納品区分
            //-----------------------------------------------------------------------------
            // 納品区分
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName)
            {
                this._beforeUOEDeliGoodsDiv = (e.Cell.Value is DBNull) ? string.Empty : e.Cell.Value.ToString();
            }
            #endregion

            #region Ｈ納品区分
            //-----------------------------------------------------------------------------
            // Ｈ納品区分
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName)
            {
                this._beforeFollowDeliGoodsDiv = (e.Cell.Value is DBNull) ? string.Empty : e.Cell.Value.ToString();
            }
            #endregion

            #region 指定拠点
            //-----------------------------------------------------------------------------
            // 指定拠点
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
            {
                this._beforeUOEResvdSection = (e.Cell.Value is DBNull) ? string.Empty : e.Cell.Value.ToString();
            }            
            #endregion

            //>>>2010/02/26
            #region RC区分
            //-----------------------------------------------------------------------------
            // RC区分
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.RecycleDivNmColumn.ColumnName)
            {
                this._beforeRecycleDiv = ((string)e.Cell.Value == string.Empty) ? 0 : Convert.ToInt32(e.Cell.Value);
            }
            #endregion

            //#region PS管理番号
            ////-----------------------------------------------------------------------------
            //// PS管理番号
            ////-----------------------------------------------------------------------------
            //else if (cell.Column.Key == this._salesDetailDataTable.GoodsMngNoColumn.ColumnName)
            //{
            //    this._beforeGoodsMngNo = (e.Cell.Value is DBNull) ? 0 : Convert.ToInt32(e.Cell.Value);
            //}
            //#endregion
            //<<<2010/02/26

        }

        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
        /// <br>Update Note: 2010/03/22 李侠 原価計算処理の不具合対応</br>
        /// <br>Update Note: 2010/05/04 王海立 入力倉庫チェック処理の追加、UOE発注時のBO区分入力の不具合対応</br>
        private void uGrid_Details_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region ●初期処理
            if (e.Cell == null) return;

            // 文字列項目ならばゼロ詰め処理実行
            if (e.Cell.Column.DataType == typeof(string))
            {
                if (e.Cell.Value != null)
                {
                    // セル値更新
                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                    this.uGrid_Details.BeforeCellUpdate -= this.uGrid_Details_BeforeCellUpdate;
                    e.Cell.Value = uiSetControl1.GetZeroPaddedText(e.Cell.Column.Key, e.Cell.Value.ToString().Trim());
                    this.uGrid_Details.BeforeCellUpdate += this.uGrid_Details_BeforeCellUpdate;
                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                }
            }

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            int salesRowNo = this._salesDetailDataTable[cell.Row.Index].SalesRowNo;
            int rowIndex = e.Cell.Row.Index;
            this._cannotGoodsRead = false;
            this._cannotGoodsMakerRead = false;
            this._cannotSupplierInfoRead = false;
            this._cannotBLGoodsRead = false;
            this._cannotListPrice = false;
            this._cannotSalesUnitCost = false;
            this._cannotCostRate = false;
            this._cannotSalesUnitPrice = false;
            this._cannotSalesRate = false;
            this._isOverFlow = false;
            bool reCalcUnitPrice = false;		// 掛率による売上単価、定価、売上原価単価再計算有無
            bool reCalcStockPrice = false;		// 売上金額再計算有無
            bool taxChange = false;
            bool changeUOEOrderDtl = false;     // 発注情報項目変更区分
            bool changeSCMInfo = false;         // SCM情報項目変更区分 // 2010/02/26

            SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
            if (salesSlip == null) return;

            if (e.Cell.Value is DBNull)
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.BeforeCellUpdate -= this.uGrid_Details_BeforeCellUpdate;
                if ((e.Cell.Column.DataType == typeof(Int32)) ||
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
            #endregion

            #region ●仕入情報設定
            this._salesSlipInputAcs.SettingStockTempInfo(salesRowNo);
            StockTemp stockTempCurrent = new StockTemp();
            StockTemp stockTemp = new StockTemp();
            if (this._salesSlipStockInfoInputAcs.StockTemp != null)
            {
                stockTempCurrent = this._salesSlipStockInfoInputAcs.StockTemp.Clone();
                stockTemp = stockTempCurrent.Clone();
            }
            #endregion

            #region ●発注情報設定
            this._salesSlipInputAcs.SettingUOEOrderDtlRow(salesRowNo);
            #endregion

            #region 品番
            //------------------------------------------------------------
            // ActiveCellが品番の場合
            //------------------------------------------------------------
            if (cell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
            {
                string goodsNo = cell.Value.ToString();
                string goodsName = this._salesDetailDataTable[cell.Row.Index].GoodsName;
                int goodsMakerCd = this._salesDetailDataTable[cell.Row.Index].GoodsMakerCd;
                int blGoodsCode = this._salesDetailDataTable[cell.Row.Index].BLGoodsCode;

                if (!String.IsNullOrEmpty(goodsNo))
                {
                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    List<Stock> stockList = new List<Stock>();
                    
                    object retObj;

                    // --- UPD 2009/10/19 ---------->>>>>
                    switch (this.SearchGoodsAndRemain(goodsNo, string.Empty, 0, 0, salesRowNo, out retObj))
                    {
                        // --- UPD 2009/10/19 ----------<<<<<
                        case 0:
                            {
                                if (retObj != null)
                                {
                                    // 品番検索
                                    if (retObj is ArrayList)
                                    {
                                        ArrayList retList = (ArrayList)retObj;

                                        for (int cnt = 0; cnt < retList.Count; cnt++)
                                        {
                                            // 通常商品情報
                                            if (retList[cnt] is GoodsUnitData)
                                            {
                                                SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UB", "", "●品番検索後　各種設定　開始");
                                                #region 各種設定
                                                goodsUnitDataList.Clear();
                                                goodsUnitDataList.Add((GoodsUnitData)retList[cnt]);
                                                List<int> settingSalesRowNoList;
                                                this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBase(this.GetActiveRowSalesRowNo(), salesRowNo + cnt, goodsUnitDataList, stockList, out settingSalesRowNoList, true, true);
                                                foreach (int rowNo in settingSalesRowNoList)
                                                {
                                                    // 売上金額計算処理
                                                    this._salesSlipInputAcs.CalculationSalesMoney(rowNo - 1);

                                                    // 原価金額計算処理
                                                    this._salesSlipInputAcs.CalculationCost(rowNo - 1);

                                                    // --- ADD 2009/10/19 ---------->>>>>
                                                    if (((GoodsUnitData)retList[cnt]).SelectedListPriceDiv == 1)
                                                    {
                                                        double tempReturnListPrice = ((GoodsUnitData)retList[cnt]).SelectedListPrice;
                                                        this._salesDetailDataTable[rowNo - 1].ListPriceDisplay = (double)tempReturnListPrice;
                                                        // --- ADD 2010/03/22 ---------->>>>>
                                                        this._salesDetailDataTable[rowNo - 1].SelectedListPriceDiv = ((GoodsUnitData)retList[cnt]).SelectedListPriceDiv;
                                                        // --- ADD 2010/03/22 ----------<<<<<
                                                        // 売上明細データセッティング処理（定価設定）
                                                        this._salesSlipInputAcs.SalesDetailRowListPriceSetting(rowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowNo - 1].ListPriceDisplay);

                                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/18 DEL
                                                        //// 売単価再設定処理
                                                        //this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceReSetting(salesRowNo);
                                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/18 DEL

                                                        // 売価率が入力されている場合は単価再計算
                                                        if (this._salesDetailDataTable[rowNo - 1].SalesRate != 0)
                                                        {
                                                            // 売上明細データセッティング処理（単価設定）
                                                            this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSettingbyRate(rowNo, this._salesDetailDataTable[rowNo - 1].SalesRate, false);

                                                            // 売上金額計算処理
                                                            this._salesSlipInputAcs.CalculationSalesMoney(rowNo - 1);
                                                        }
                                                        // 2009/12/17 ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                                        else
                                                        {
                                                            // 2010/01/14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                                            //if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1) // 売価＝定価
                                                            //{
                                                            //    this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSetting(rowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPrice, this._salesDetailDataTable[rowNo - 1].ListPriceDisplay, 0);
                                                            //}

                                                            if (string.IsNullOrEmpty(this._salesDetailDataTable[rowNo - 1].RateDivSalUnPrc))
                                                            {
                                                            if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1) // 売価＝定価
                                                            {
                                                                this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSetting(rowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPrice, this._salesDetailDataTable[rowNo - 1].ListPriceDisplay, 0);
                                                            }
                                                        }
                                                            // 2010/01/14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                                        }
                                                        // 2009/12/17 ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                                        this._salesDetailDataTable[rowNo - 1].PrtGoodsNo = ((GoodsUnitData)retList[cnt]).PrtGoodsNo;
                                                        this._salesDetailDataTable[rowNo - 1].PrtMakerCode = ((GoodsUnitData)retList[cnt]).PrtMakerCode;
                                                        this._salesDetailDataTable[rowNo - 1].PrtMakerName = ((GoodsUnitData)retList[cnt]).PrtMakerName;
                                                    }

                                                    this._salesDetailDataTable[rowNo - 1].SelectedGoodsNoDiv = ((GoodsUnitData)retList[cnt]).SelectedGoodsNoDiv;
                                                    // --- ADD 2009/10/19 ----------<<<<<

                                                    // 明細粗利率設定処理
                                                    this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(rowNo);

                                                    // 一式情報設定処理
                                                    this._salesSlipInputAcs.ConstructionCompleteInfo(rowNo);

                                                    // 車両情報設定イベントコール処理
                                                    this.SettingCarInfoEventCall(rowNo);

                                                    // 発注情報設定処理
                                                    this._salesSlipInputAcs.SettingUOEOrderDtlRowForNew(rowNo);
                                                    this._salesSlipInputAcs.DefaultSettingUOEOrderDtlRow(rowNo);
                                                }
                                                #endregion
                                                SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UB", "", "○品番検索後　各種設定　終了");
                                            }
                                            // 受注照会(受注残検索)
                                            else if(retList[cnt] is AcptAnOdrRemainRefData)
                                            {
                                                List<AcptAnOdrRemainRefData> acptAnOdrRemainRefDataList = new List<AcptAnOdrRemainRefData>();
                                                acptAnOdrRemainRefDataList.Add((AcptAnOdrRemainRefData)retList[cnt]);
                                                int st = this._salesSlipInputAcs.SalesDetailRowSettingFromAcptAnOdrRemainRefList(salesRowNo + cnt, acptAnOdrRemainRefDataList, SalesSlipInputAcs.WayToDetailExpand.AddUpRemainder);
                                                if (st == -1)
                                                {
                                                    TMsgDisp.Show(
                                                        this,
                                                        emErrorLevel.ERR_LEVEL_INFO,
                                                        this.Name,
                                                        "「計上」または「発注選択」済み明細がが選択されましたので、" + Environment.NewLine +
                                                        "明細への展開を行いません。",
                                                        -1,
                                                        MessageBoxButtons.OK);
                                                }

                                            }
                                            // 出荷照会(出荷残検索)
                                            else if (retList[cnt] is SalHisRefResultParamWork)
                                            {
                                                List<SalHisRefResultParamWork> salHisRefResultParamWorkList = new List<SalHisRefResultParamWork>();
                                                salHisRefResultParamWorkList.Add((SalHisRefResultParamWork)retList[cnt]);
                                                int st = this._salesSlipInputAcs.SalesDetailRowSettingFromSalHisRefResultParamWorkListForAddUp(salesRowNo + cnt, salHisRefResultParamWorkList, SalesSlipInputAcs.WayToDetailExpand.AddUpRemainder);
                                                if (st == -1)
                                                {
                                                    TMsgDisp.Show(
                                                        this,
                                                        emErrorLevel.ERR_LEVEL_INFO,
                                                        this.Name,
                                                        "「計上」済み明細が選択されましたので、" + Environment.NewLine +
                                                        "明細への展開を行いません。",
                                                        -1,
                                                        MessageBoxButtons.OK);
                                                }
                                            }
                                        }
                                    }

                                    //>>>2010/04/28
                                    //// 明細グリッド設定処理
                                    //this.SettingGrid();
                                    //<<<2010/04/28

                                    // 在庫調整
                                    this._salesSlipInputAcs.SalesDetailStockInfoAdjust();
                                }

                                break;
                            }
                        case -1:
                            {
                                // キャンセル
                                this._salesSlipInputAcs.ClearSalesDetailRow(salesRowNo, false);
                                this._cannotGoodsRead = true;
                                return;
                            }
                    }

                }
                else
                {
                    this._salesSlipInputAcs.ClearSalesDetailRow(salesRowNo);
                    this._cannotGoodsRead = true;
                }

                // 明細グリッド設定処理
                this.SettingGrid();

                // データ変更フラグプロパティをTrueにする
                this._salesSlipInputAcs.IsDataChanged = true;

                // 売上金額変更後発生イベントコール処理
                this.SalesPriceChangedEventCall();

                // フッタ部明細情報更新イベントコール処理
                this.SettingFooterEventCall(salesRowNo);

                #region 明細チェック
                bool errorFlg = false;

                // 在庫切れ出荷区分による在庫数チェック
                bool setInputError = false;
                bool showMessage = false;
                if (!this._salesSlipInputAcs.CheckStockCountForShipmentCnt(salesRowNo, out setInputError, out showMessage))
                {
                    if (showMessage)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "出荷数が在庫数を上回ります。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    if (setInputError)
                    {
                        this._cannotGoodsRead = true;
                        errorFlg = true;
                    }
                }

                // 在庫切れ出荷区分による在庫数チェック
                setInputError = false;
                showMessage = false;
                if (!this._salesSlipInputAcs.CheckStockCountForAcceptAnOrderCnt(salesRowNo, out setInputError, out showMessage))
                {
                    if (showMessage)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "受注数が在庫数を上回ります。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    if (setInputError)
                    {
                        this._cannotGoodsRead = true;
                        errorFlg = true;
                    }
                }

                string errMsg = string.Empty;
                SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckListPrice(salesRowNo, out errMsg);

                if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                    {
                        this._cannotGoodsRead = true;
                        errorFlg = true;
                    }
                }
                if (errorFlg) return;
                #endregion
            }
            #endregion

            #region 品名
            //------------------------------------------------------------
            // ActiveCellが品名の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.GoodsNameColumn.ColumnName)
            {
                if (((string.IsNullOrEmpty(this._beforeGoodsName)) && (!string.IsNullOrEmpty(e.Cell.Value.ToString()))) ||
                    (string.IsNullOrEmpty(e.Cell.Value.ToString())))
                {
                    // --- UPD 2009/12/23 ---------->>>>>
                    // 売上明細データセッティング処理（売上商品区分設定）
                    //this._salesSlipInputAcs.SalesDetailRowSalesGoodsCdSetting(salesRowNo, salesSlip.SalesGoodsCd);
                    this._salesSlipInputAcs.SalesDetailRowSalesGoodsCdSetting(salesRowNo, salesSlip.SalesGoodsCd,false);
                    // --- UPD 2009/12/23 ----------<<<<<
                }

                // --- UPD 2009/12/23 ---------->>>>>
                if (string.IsNullOrEmpty(e.Cell.Value.ToString()))
                {
                    this._salesDetailDataTable[cell.Row.Index].GoodsName = this._beforeGoodsName.Trim();

                    return;
                }
                // --- UPD 2009/12/23 ----------<<<<<

                // 商品名称セット
                // 2010/02/08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// 2010/01/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ////if (this._beforeGoodsName.Trim() != e.Cell.Value.ToString().Trim())
                //if ((this._beforeGoodsName.Trim() != e.Cell.Value.ToString().Trim()) &&
                //    (this._salesSlipInputAcs.SalesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum))
                //// 2010/01/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (this._beforeGoodsName.Trim() != e.Cell.Value.ToString().Trim())
                // 2010/02/08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    // 2010/01/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //// 商品コード、メーカーコードが設定されていない場合は空情報セット(用品入力)
                    //if (((string.IsNullOrEmpty(this._salesDetailDataTable[cell.Row.Index].GoodsNo)) ||
                    //     (this._salesDetailDataTable[cell.Row.Index].GoodsMakerCd == 0)) &&
                    //    ((this._salesDetailDataTable[cell.Row.Index].EditStatus != SalesSlipInputAcs.ctEDITSTATUS_RowDiscount) &&
                    //     (this._salesDetailDataTable[cell.Row.Index].EditStatus != SalesSlipInputAcs.ctEDITSTATUS_Annotation)))
                    //{
                    //    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    //    List<Stock> stockList = new List<Stock>();
                    //    List<int> settingSalesRowNoList;
                    //    goodsUnitDataList.Add(this._salesSlipInputAcs.CreateEmptyGoods(this._salesDetailDataTable[cell.Row.Index].GoodsNo, this._salesDetailDataTable[cell.Row.Index].GoodsName, this._salesDetailDataTable[cell.Row.Index].GoodsMakerCd, this._salesDetailDataTable[cell.Row.Index].BLGoodsCode));
                    //    this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBase(this.GetActiveRowSalesRowNo(), salesRowNo, goodsUnitDataList, stockList, out settingSalesRowNoList, true, true);
                    //}
                    //this._salesDetailDataTable[cell.Row.Index].GoodsNameKana = e.Cell.Value.ToString();


                    // 2010/02/08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //if ((this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) &&
                    //    (this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp) &&
                    //    (this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp))
                    if ((this._salesSlipInputAcs.SalesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum) &&
                        (this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) &&
                        (this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp) &&
                        (this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp))
                    // 2010/02/08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    // 商品コード、メーカーコードが設定されていない場合は空情報セット(用品入力)
                    if (((string.IsNullOrEmpty(this._salesDetailDataTable[cell.Row.Index].GoodsNo)) ||
                         (this._salesDetailDataTable[cell.Row.Index].GoodsMakerCd == 0)) &&
                        ((this._salesDetailDataTable[cell.Row.Index].EditStatus != SalesSlipInputAcs.ctEDITSTATUS_RowDiscount) &&
                         (this._salesDetailDataTable[cell.Row.Index].EditStatus != SalesSlipInputAcs.ctEDITSTATUS_Annotation)))
                    {
                        List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                        List<Stock> stockList = new List<Stock>();
                        List<int> settingSalesRowNoList;
                        goodsUnitDataList.Add(this._salesSlipInputAcs.CreateEmptyGoods(this._salesDetailDataTable[cell.Row.Index].GoodsNo, this._salesDetailDataTable[cell.Row.Index].GoodsName, this._salesDetailDataTable[cell.Row.Index].GoodsMakerCd, this._salesDetailDataTable[cell.Row.Index].BLGoodsCode));
                        this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBase(this.GetActiveRowSalesRowNo(), salesRowNo, goodsUnitDataList, stockList, out settingSalesRowNoList, true, true);
                    }

                        //this._salesDetailDataTable[cell.Row.Index].GoodsNameKana = e.Cell.Value.ToString(); // 2010/02/08
                    }

                    // --- UPD m.suzuki 2010/04/14 ---------->>>>>
                    //this._salesDetailDataTable[cell.Row.Index].GoodsNameKana = e.Cell.Value.ToString(); // 2010/02/08
                    
                    // 全角⇒半角変換
                    string goodsNameKana = GetKanaString( e.Cell.Value.ToString() );
                    
                    // ガ(1文字)⇒ｶﾞ(2文字)のような変換もあるので、長さをチェックする。
                    int kanaMaxLength = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNameColumn.ColumnName].MaxLength;
                    if ( goodsNameKana.Length > kanaMaxLength )
                    {
                        goodsNameKana = goodsNameKana.Substring( 0, kanaMaxLength );
                    }
                    this._salesDetailDataTable[cell.Row.Index].GoodsNameKana = goodsNameKana;
                    // --- UPD m.suzuki 2010/04/14 ----------<<<<<
                    // 2010/01/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            #endregion

            #region 倉庫コード
            //------------------------------------------------------------
            // ActiveCellが倉庫コードの場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName)
            {
                string warehouseCode = cell.Value.ToString();
                this._beforeWarehouseCode = uiSetControl1.GetZeroPaddedText(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName, this._beforeWarehouseCode.Trim());

                if (!String.IsNullOrEmpty(warehouseCode))
                {
                    
                    string name = this._salesSlipInputInitDataAcs.GetName_FromWarehouse(warehouseCode);

                    // 在庫情報取得
                    Stock stock = this._salesSlipInputAcs.GetGoodsUnitDataDicStock(this._salesDetailDataTable[cell.Row.Index].GoodsMakerCd,
                                                                                   this._salesDetailDataTable[cell.Row.Index].GoodsNo,
                                                                                   this._salesDetailDataTable[cell.Row.Index].WarehouseCode);

                    if (stock != null)
                    {
                        // --- ADD 2010/05/04 ---------->>>>>
                        if (!string.IsNullOrEmpty(stock.SectionCode) && !string.IsNullOrEmpty(LoginInfoAcquisition.Employee.BelongSectionCode))
                        {
                            if (!stock.SectionCode.Trim().Equals(LoginInfoAcquisition.Employee.BelongSectionCode.Trim()))
                            {
                                // 入力倉庫チェック区分 0:無視 1:再入力 2:警告
                                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().InpWarehChkDiv)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            "不正な値が存在するため、登録できません。"
                                            + "\r\n"
                                            + "\r\n"
                                            + this.GetActiveRowSalesRowNo()
                                            + "行目の在庫管理拠点とログイン拠点が不一致です。",
                                            0,
                                            MessageBoxButtons.OK);

                                            // 倉庫コードを元に戻す
                                            this._salesDetailDataTable[cell.Row.Index].WarehouseCode = this._beforeWarehouseCode;
                                            warehouseCode = this._beforeWarehouseCode;
                                            name = this._salesSlipInputInitDataAcs.GetName_FromWarehouse(warehouseCode);
                                            // 在庫情報再取得
                                            stock = this._salesSlipInputAcs.GetGoodsUnitDataDicStock(this._salesDetailDataTable[cell.Row.Index].GoodsMakerCd,
                                                                                                           this._salesDetailDataTable[cell.Row.Index].GoodsNo,
                                                                                                           this._salesDetailDataTable[cell.Row.Index].WarehouseCode);

                                            break;
                                        }
                                    case 2:
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            "在庫管理拠点とログイン拠点が不一致です。",
                                            0,
                                            MessageBoxButtons.OK);

                                            break;
                                        }
                                }
                            }
                        }
                        // --- ADD 2010/05/04 ----------<<<<<
                        this._salesSlipInputAcs.SettingSalesDetailWarehouseInfo(salesRowNo, warehouseCode, name);
                        this._salesSlipInputAcs.SettingSalesDetailStockInfo(salesRowNo, stock);
                        this._salesSlipInputAcs.SalesDetailStockInfoAdjust(this._beforeWarehouseCode, this._salesDetailDataTable[cell.Row.Index].GoodsNo, this._salesDetailDataTable[cell.Row.Index].GoodsMakerCd);
                    }
                    else
                    {
                        if ((this._salesSlipInputAcs.SalesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) &&
                            (this._salesSlipInputAcs.SalesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum) &&
                            (this._salesDetailDataTable[rowIndex].SalesSlipDtlNumSrc != 0))
                        {
                            if (name != string.Empty)
                            {
                                this._salesSlipInputAcs.ClearSalesDetailStockInfo(salesRowNo);
                                this._salesSlipInputAcs.SettingSalesDetailWarehouseInfo(salesRowNo, warehouseCode, name);
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "倉庫コード [" + warehouseCode + "] に該当する倉庫マスタが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                // 倉庫コードを元に戻す
                                this._salesDetailDataTable[cell.Row.Index].WarehouseCode = this._beforeWarehouseCode;
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "倉庫コード [" + warehouseCode + "] に該当する在庫情報が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // 倉庫コードを元に戻す
                            this._salesDetailDataTable[cell.Row.Index].WarehouseCode = this._beforeWarehouseCode;
                        }
                    }
                }
                else
                {
                    // 倉庫名称設定処理
                    this._salesSlipInputAcs.ClearSalesDetailStockInfo(salesRowNo);

                    // 現在庫数調整
                    this._salesSlipInputAcs.SalesDetailStockInfoAdjust();
                }
            }            
            #endregion

            #region 販売区分
            //-----------------------------------------------------------------------------
            // 販売区分
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesCodeColumn.ColumnName)
            {
                int code = TStrConv.StrToIntDef(cell.Value.ToString(), 0);
                string name = string.Empty;

                if ((code != 0) && (this._beforeSalesCode != code))
                {
                    name = this._salesSlipInputInitDataAcs.GetName_FromUserGdBd(SalesSlipInputInitDataAcs.ctDIVCODE_UserGuideDivCd_SalesCode, code);

                    if (name != string.Empty)
                    {
                        this._salesSlipInputAcs.SettingSalesDetailRowSalesCodeInfo(salesRowNo, code, name);
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "販売区分 [" + code + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        name = this._salesSlipInputInitDataAcs.GetName_FromUserGdBd(SalesSlipInputInitDataAcs.ctDIVCODE_UserGuideDivCd_SalesCode, this._beforeSalesCode);
                        if (name != string.Empty)
                        {
                            this._salesSlipInputAcs.SettingSalesDetailRowSalesCodeInfo(salesRowNo, this._beforeSalesCode, name);
                        }
                        else
                        {
                            this._salesSlipInputAcs.SettingSalesDetailRowSalesCodeInfo(salesRowNo, 0, string.Empty);
                        }
                        this._cannotSalesCode = true;
                    }
                }
            }
            #endregion

            #region 出荷数
            //------------------------------------------------------------
            // ActiveCellが「出荷数」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName)
            {
                int cnt = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                if (cnt != this._beforeShipmentCnt)
                {

                    #region 数量のチェック
                    string errMsg = string.Empty;
                    SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckShipmentCnt(salesRowNo, out errMsg);

                    if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            errMsg,
                            -1,
                            MessageBoxButtons.OK);

                        if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                        {
                            this._salesDetailDataTable[rowIndex].ShipmentCntDisplay = this._beforeShipmentCnt;
                            this._isOverFlow = true;
                            return;
                        }
                    }

                    // 在庫切れ出荷区分による在庫数チェック
                    bool setInputError = false;
                    bool showMessage = false;
                    if (!this._salesSlipInputAcs.CheckStockCountForShipmentCnt(salesRowNo, out setInputError, out showMessage))
                    {
                        if (showMessage)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "出荷数が在庫数を上回ります。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        if (setInputError)
                        {
                            this._salesDetailDataTable[rowIndex].ShipmentCntDisplay = this._beforeShipmentCnt;
                            this._isOverFlow = true;
                            return;
                        }
                    }
                    #endregion

                    // 数量設定処理
                    this._salesSlipInputAcs.SettingSalesDetailShipmentCnt(salesRowNo);

                    // 売上金額計算処理
                    this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                    // 原価金額計算処理
                    this._salesSlipInputAcs.CalculationCost(rowIndex);

                    // 明細粗利率設定処理
                    this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                    // 一式情報設定処理
                    this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
                }
            }
            #endregion

            #region 受注数
            //------------------------------------------------------------
            // ActiveCellが「受注数」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName)
            {
                // 受注情報設定
                this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);

                #region 数量のチェック
                string errMsg = string.Empty;
                SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckAcptAnOdrCntCnt(salesRowNo, out errMsg);

                if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                    {
                        this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay = this._beforeAcptAnOdrCnt;
                        this._isOverFlow = true;
                        return;
                    }
                }

                // 在庫切れ出荷区分による在庫数チェック
                bool setInputError = false;
                bool showMessage = false;
                if (!this._salesSlipInputAcs.CheckStockCountForAcceptAnOrderCnt(salesRowNo, out setInputError, out showMessage))
                {
                    if (showMessage)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "受注数が在庫数を上回ります。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    if (setInputError)
                    {
                        this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay = this._beforeAcptAnOdrCnt;
                        this._isOverFlow = true;
                        return;
                    }
                }
                #endregion

                // 数量設定処理
                this._salesSlipInputAcs.SettingAcptAnOdrDetailRowShipmentCnt(salesRowNo);

                // 数量設定処理
                this._salesSlipInputAcs.SettingSalesDetailShipmentCnt(salesRowNo);

                //// 受注単価情報設定処理
                //this._salesSlipInputAcs.AcptAnOdrDetailRowGoodsPriceReSetting();

                // 受注売上金額計算処理
                this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                // 受注原価金額計算処理
                this._salesSlipInputAcs.CalculationCost(rowIndex);

                // 一式情報設定処理
                this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);

            }            
            #endregion

            #region 定価
            //------------------------------------------------------------
            // ActiveCellが「定価」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
            {
                long tempListPrice = (long)this._salesDetailDataTable[rowIndex].ListPriceDisplay;
                this._salesDetailDataTable[rowIndex].ListPriceDisplay = (double)tempListPrice;

                #region 原価チェック区分
                string errMsg = string.Empty;
                SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckListPrice(salesRowNo, out errMsg);

                if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                    {
                        this._salesDetailDataTable[rowIndex].ListPriceDisplay = this._beforeListPrice;
                        this._cannotListPrice = true;
                        return;
                    }
                }
                #endregion
                // --- ADD 2010/03/22 -------------->>>>>
                // 標準価格を変更する場合、「ListPriceChngCd = 1:変更あり」を設定する。
                if (this._salesDetailDataTable[rowIndex].ListPriceDisplay != this._beforeListPrice)
                {
                    this._salesDetailDataTable[rowIndex].ListPriceChngCd = 1;
                    this._salesDetailDataTable[rowIndex].SelectedListPriceDiv = 0;
                }
                // --- ADD 2010/03/22 --------------<<<<<
                // 売上明細データセッティング処理（定価設定）
                this._salesSlipInputAcs.SalesDetailRowListPriceSetting(salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowIndex].ListPriceDisplay);

                // 売単価再設定処理
                this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceReSetting(salesRowNo);

                // 売上金額計算処理
                this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                // 売価率が入力されている場合は単価再計算
                if (this._salesDetailDataTable[rowIndex].SalesRate != 0)
                {
                    // 売上明細データセッティング処理（単価設定）
                    this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSettingbyRate(salesRowNo, this._salesDetailDataTable[rowIndex].SalesRate, false);

                    // 売上金額計算処理
                    this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);
                }

                // 原価率が入力されている場合は単価再計算
                if (this._salesDetailDataTable[rowIndex].CostRate != 0)
                {
                    // 売上明細データセッティング処理（原単価設定）
                    this._salesSlipInputAcs.SalesDetailRowSalesUnitCostSettingbyRate(salesRowNo, this._salesDetailDataTable[rowIndex].CostRate, false);

                    // 原価金額計算処理
                    this._salesSlipInputAcs.CalculationCost(rowIndex);
                }

                // 明細粗利率設定処理
                this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                // 一式情報設定処理
                this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
            }            
            #endregion

            #region 売単価
            //------------------------------------------------------------
            // ActiveCellが「売単価」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName)
            {
                #region 原価チェック区分
                string errMsg = string.Empty;
                SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckSalesUnitPrice(salesRowNo, 0, out errMsg);
                if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                    {
                        this._salesDetailDataTable[rowIndex].SalesUnPrcDisplay = this._beforeSalesUnitPrice;
                        this._cannotSalesUnitPrice = true;
                        return;
                    }
                }
                #endregion

                // 売上明細データセッティング処理（単価設定）
                this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSetting(salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowIndex].SalesUnPrcDisplay, 0);

                // 売上金額計算処理
                this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                // 明細粗利率設定処理
                this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                // 一式情報設定処理
                this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
            }
            #endregion

            #region 売価率
            //------------------------------------------------------------
            // ActiveCellが「売価率」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesRateColumn.ColumnName)
            {
                // --- UPD 2009/10/19 ---------->>>>>
                if (this._salesDetailDataTable[rowIndex].SalesRate != 0)
                {
                    #region 原価チェック区分
                    string errMsg = string.Empty;
                    SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckSalesUnitPrice(salesRowNo, 1, out errMsg);
                    if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            errMsg,
                            -1,
                            MessageBoxButtons.OK);

                        if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                        {
                            this._salesDetailDataTable[rowIndex].SalesRate = this._beforeSalesRate;
                            this._cannotSalesRate = true;
                            return;
                        }
                    }
                    #endregion
                }
                // --- UPD 2009/10/19 ----------<<<<<

                // 売上明細データセッティング処理（売価率より単価設定）
                this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSettingbyRate(salesRowNo, this._salesDetailDataTable[rowIndex].SalesRate, true);

                // 売上金額計算処理
                this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                // 明細粗利率設定処理
                this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                // 一式情報設定処理
                this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
            }
            #endregion

            #region 原単価
            //------------------------------------------------------------
            // ActiveCellが「原単価」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName)
            {
                #region 原価チェック区分
                string errMsg = string.Empty;
                // --- UPD 2009/10/19 ---------->>>>>
                //SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckSalesUnitCost(salesRowNo, 0, out errMsg);
                SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckSalesUnitCost(salesRowNo, 0, out errMsg, 0);
                // --- UPD 2009/10/19 ----------<<<<<

                if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                    {
                        this._salesDetailDataTable[rowIndex].SalesUnitCost = this._beforeSalesUnitCost;
                        this._cannotSalesUnitCost = true;
                        return;
                    }
                }
                #endregion

                // 売上明細データセッティング処理（原価設定）
                this._salesSlipInputAcs.SalesDetailRowSalesUnitCostSetting(salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowIndex].SalesUnitCost);

                // 売単価再設定処理
                this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceReSetting(salesRowNo);

                // 売上明細データセッティング処理（単価設定）
                this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSetting(salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowIndex].SalesUnPrcDisplay, 1);

                // 売上金額計算処理
                this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                // 原価金額計算処理
                this._salesSlipInputAcs.CalculationCost(rowIndex);

                // 明細粗利率設定処理
                this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                // 一式情報設定処理
                this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
            }
            #endregion

            #region 原価率
            //------------------------------------------------------------
            // ActiveCellが「原価率」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.CostRateColumn.ColumnName)
            {
                #region 原価チェック区分
                string errMsg = string.Empty;
                // --- UPD 2009/10/19 ---------->>>>>
                //SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckSalesUnitCost(salesRowNo, 1, out errMsg);
                SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckSalesUnitCost(salesRowNo, 1, out errMsg, 0);
                // --- UPD 2009/10/19 ----------<<<<<
                if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                    {
                        this._salesDetailDataTable[rowIndex].CostRate = this._beforeCostRate;
                        this._cannotCostRate = true;
                        return;
                    }
                }
                #endregion

                // 売上明細データセッティング処理（原単価設定）
                this._salesSlipInputAcs.SalesDetailRowSalesUnitCostSettingbyRate(salesRowNo, this._salesDetailDataTable[rowIndex].CostRate, true);

                // 売上明細データセッティング処理（原価設定）
                this._salesSlipInputAcs.SalesDetailRowSalesUnitCostSetting(salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowIndex].SalesUnitCost);

                // 売単価再設定処理
                this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceReSetting(salesRowNo);

                // 売上明細データセッティング処理（単価設定）
                this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSetting(salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowIndex].SalesUnPrcDisplay, 1);

                // 売上金額計算処理
                this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                // 原価金額計算処理
                this._salesSlipInputAcs.CalculationCost(rowIndex);

                // 明細粗利率設定処理
                this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                // 一式情報設定処理
                this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
            }
            #endregion

            #region 売上金額
            //------------------------------------------------------------
            // ActiveCellが「売上金額」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName)
            {
                if (this._beforeSalesMoney != (long)e.Cell.Value)
                {
                    // --- ADD 2010/05/04 ---------->>>>>
                    // セキュリティの操作権限
                    if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.MoneyMinus))
                    {
                        // 金額にマイナスが入力不可
                        if ((long)e.Cell.Value < 0)
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "マイナス値の入力はできません。",
                            -1,
                            MessageBoxButtons.OK);

                            this._salesDetailDataTable[rowIndex].SalesMoneyDisplay = this._beforeSalesMoney;
                            this._isOverFlow = true;
                            return;
                        }
                    }
                    // --- ADD 2010/05/04 ----------<<<<<

                    // 売上明細データセッティング処理（売上商品区分設定）
                    // --- UPD 2009/12/23 ---------->>>>>
                    //this._salesSlipInputAcs.SalesDetailRowSalesGoodsCdSetting(salesRowNo, salesSlip.SalesGoodsCd);
                    this._salesSlipInputAcs.SalesDetailRowSalesGoodsCdSetting(salesRowNo, salesSlip.SalesGoodsCd,true);
                    // --- UPD 2009/12/23 ----------<<<<<

                    // 明細粗利率設定処理
                    this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                    // 一式情報設定処理
                    this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
                }
            }
            #endregion

            #region 原価金額
            //------------------------------------------------------------
            // ActiveCellが「原価金額」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.CostColumn.ColumnName)
            {
                if (this._beforeCost != (long)e.Cell.Value)
                {
                    // 原価設定処理
                    this._salesSlipInputAcs.SalesDetailRowCostSetting(salesRowNo);

                    // 明細粗利率設定処理
                    this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                    // 一式情報設定処理
                    this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
                }
            }
            #endregion

            #region メーカーコード
            //------------------------------------------------------------
            // ActiveCellが「メーカー」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName)
            {
                int goodsMakerCd = TStrConv.StrToIntDef(cell.Value.ToString(), 0);
                string beforeMakerName = this._salesDetailDataTable[cell.Row.Index].MakerName;
                string beforeMakerKanaName = this._salesDetailDataTable[cell.Row.Index].MakerKanaName; // 2010/07/21

                if (goodsMakerCd != 0)
                {
                    // 先にメーカー情報を取得する
                    string name = this._salesSlipInputInitDataAcs.GetName_FromMaker(goodsMakerCd);
                    string kanaName = this._salesSlipInputInitDataAcs.GetKanaName_FromMaker(goodsMakerCd); // 2010/07/21

                    if (!String.IsNullOrEmpty(name))
                    {
                        //>>>2010/07/21
                        //this._salesSlipInputAcs.SettingSalesDetailMakerInfo(salesRowNo, goodsMakerCd, name);
                        this._salesSlipInputAcs.SettingSalesDetailMakerInfo(salesRowNo, goodsMakerCd, name, kanaName);
                        //<<<2010/07/21
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
                        this._salesDetailDataTable[cell.Row.Index].GoodsMakerCd = this._beforeGoodsMakerCd;

                        this._cannotGoodsMakerRead = true;
                    }
                }
                else
                {
                    // メーカー名称設定処理
                    //>>>2010/07/21
                    //this._salesSlipInputAcs.SettingSalesDetailMakerInfo(salesRowNo, 0, string.Empty);
                    this._salesSlipInputAcs.SettingSalesDetailMakerInfo(salesRowNo, 0, string.Empty, string.Empty);
                    //<<<2010/07/21
                }

                string goodsNo = this._salesDetailDataTable[cell.Row.Index].GoodsNo;

                // 商品コード有りでメーカーが変わった場合
                if ((!this._cannotGoodsMakerRead) && (goodsMakerCd != this._beforeGoodsMakerCd) && (!String.IsNullOrEmpty(goodsNo)))
                {
                    switch (this.SearchGoodsAndRemain_And_RowSetting(rowIndex))
                    {
                        case 0:
                            break;
                        case -1:
                            //>>>2010/07/21
                            //this._salesSlipInputAcs.SettingSalesDetailMakerInfo(salesRowNo, this._beforeGoodsMakerCd, beforeMakerName);
                            this._salesSlipInputAcs.SettingSalesDetailMakerInfo(salesRowNo, this._beforeGoodsMakerCd, beforeMakerName, beforeMakerKanaName);
                            //<<<2010/07/21
                            break;
                    }
                    // 売上金額計算処理
                    this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                    // 原価金額計算処理
                    this._salesSlipInputAcs.CalculationCost(rowIndex);

                    // 明細粗利率設定処理
                    this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                    // 一式情報設定処理
                    this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);

                    // 車両情報設定イベントコール処理
                    this.SettingCarInfoEventCall(salesRowNo);

                    // 発注情報設定処理
                    this._salesSlipInputAcs.SettingUOEOrderDtlRowForNew(salesRowNo);

                    // 現在庫数調整
                    this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

                    // 明細グリッド設定処理
                    this.SettingGrid();

                    // データ変更フラグプロパティをTrueにする
                    this._salesSlipInputAcs.IsDataChanged = true;

                    // 売上金額変更後発生イベントコール処理
                    this.SalesPriceChangedEventCall();

                    // フッタ部明細情報更新イベントコール処理
                    this.SettingFooterEventCall(salesRowNo);

                    // --- ADD 2010/01/27 -------------->>>
                    //発注選択が不可となった場合,受注数と出荷数をクリア
                    if ((this._salesSlipInputAcs.ExistStockTempForStock(salesRowNo)) ||
                        (!this._salesSlipInputAcs.ExistSalesDetailSupplierCd(salesRowNo)) ||
                        (!this._salesSlipInputAcs.ExistSalesDetailEnableOdrMakerCd(salesRowNo)))
                    {
                        this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay = 0;
                        this._salesDetailDataTable[rowIndex].ShipmentCntDisplay = 1;
                    }
                    // --- ADD 2010/01/27 --------------<<<
                }
            }
            #endregion

            #region 納品完了予定日
            //------------------------------------------------------------
            // 納品完了予定日
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
            {
                //>>>2010/02/26
                //DateTime dt = new DateTime();
                //dt = (DateTime)cell.Value;
                //string shortdt = dt.ToShortDateString().Replace("/","");
                //int iDate = TStrConv.StrToIntDef(shortdt, 0);

                //if (iDate == 0)
                //{
                //    this._salesSlipInputAcs.SalesDetailDataTable[cell.Row.Index].DeliGdsCmpltDueDate = this._salesSlipInputAcs.SalesSlip.SalesDate;
                //}
                //<<<2010/02/26
            }
            #endregion

            #region BLコード
            //------------------------------------------------------------
            // ActiveCellが「BLコード」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName)
            {
                int blCode = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                if (blCode != 0)
                {
                    if ((this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch) ||
                        (this._salesSlipInputAcs.GetSearchPartsMode(salesRowNo) != SalesSlipInputAcs.SearchPartsModeState.NonSearch))
                    {
                        if (this._salesSlipInputAcs.SettingSalesDetailBLGoodsInfo(salesRowNo, blCode))
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
                            this._salesSlipInputAcs.ClearBLGoodsInfo(salesRowNo);
                            this._salesDetailDataTable[cell.Row.Index].BLGoodsCode = this._beforeBLGoodsCode;
                            
                            this._cannotBLGoodsRead = true;
                        }
                    }
                    else
                    {
                        //-----------------------------------------------------------------------------
                        // BLコード検索
                        //-----------------------------------------------------------------------------
                        List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                        List<Stock> stockList = new List<Stock>();

                        object retObj;

                        // --- ADD 2010/01/27 -------------->>>>>
                        if (this.CheckRowEffective(cell.Row.Index))
                        {
                            if (this._salesSlipInputAcs.SettingSalesDetailBLGoodsInfo(salesRowNo, blCode))
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
                                this._salesSlipInputAcs.ClearBLGoodsInfo(salesRowNo);
                                this._salesDetailDataTable[cell.Row.Index].BLGoodsCode = this._beforeBLGoodsCode;

                                this._cannotBLGoodsRead = true;
                            }
                        }
                        else
                        {
                        // --- ADD 2010/01/27 --------------<<<<<

                            switch (this.SearchPartsFromBLCode(salesRowNo, blCode, out retObj))
                            {
                                case 0:
                                    {
                                        if (retObj != null)
                                        {
                                            // BLコード検索
                                            if (retObj is ArrayList)
                                            {
                                                ArrayList retList = (ArrayList)retObj;
                                                int settingRowCnt = 0;

                                                for (int cnt = 0; cnt < retList.Count; cnt++)
                                                {
                                                    // 通常商品情報
                                                    if (retList[cnt] is GoodsUnitData)
                                                    {
                                                        SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UB", "", "●ＢＬコード検索後　各種設定　開始");
                                                        #region ●各種設定
                                                        goodsUnitDataList.Clear();
                                                        goodsUnitDataList.Add((GoodsUnitData)retList[cnt]);

                                                        // 商品情報設定処理
                                                        List<int> settingSalesRowNoList;
                                                        // 2009/11/25 >>>
                                                        //this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(this.GetActiveRowSalesRowNo(), salesRowNo + settingRowCnt, goodsUnitDataList, stockList, out settingSalesRowNoList, true, false);
                                                        this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(this.GetActiveRowSalesRowNo(), salesRowNo + settingRowCnt, goodsUnitDataList, stockList, out settingSalesRowNoList, true, false, blCode);
                                                        // 2009/11/25 <<<
                                                        settingRowCnt += settingSalesRowNoList.Count;
                                                        foreach (int rowNo in settingSalesRowNoList)
                                                        {
                                                            // 売上金額計算処理
                                                            this._salesSlipInputAcs.CalculationSalesMoney(rowNo - 1);

                                                            // 原価金額計算処理
                                                            this._salesSlipInputAcs.CalculationCost(rowNo - 1);

                                                            // --- ADD 2009/10/19 ---------->>>>>
                                                            if (((GoodsUnitData)retList[cnt]).SelectedListPriceDiv == 1)
                                                            {
                                                                double tempReturnListPrice = ((GoodsUnitData)retList[cnt]).SelectedListPrice;
                                                                this._salesDetailDataTable[rowNo - 1].ListPriceDisplay = (double)tempReturnListPrice;
                                                                // --- ADD 2010/03/22 ---------->>>>>
                                                                this._salesDetailDataTable[rowNo - 1].SelectedListPriceDiv = ((GoodsUnitData)retList[cnt]).SelectedListPriceDiv;
                                                                // --- ADD 2010/03/22 ----------<<<<<
                                                                // 売上明細データセッティング処理（定価設定）
                                                                this._salesSlipInputAcs.SalesDetailRowListPriceSetting(rowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowNo - 1].ListPriceDisplay);

                                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/18 DEL
                                                                //// 売単価再設定処理
                                                                //this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceReSetting(salesRowNo);
                                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/18 DEL

                                                                // 売価率が入力されている場合は単価再計算
                                                                if (this._salesDetailDataTable[rowNo - 1].SalesRate != 0)
                                                                {
                                                                    // 売上明細データセッティング処理（単価設定）
                                                                    this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSettingbyRate(rowNo, this._salesDetailDataTable[rowNo - 1].SalesRate, false);

                                                                    // 売上金額計算処理
                                                                    this._salesSlipInputAcs.CalculationSalesMoney(rowNo - 1);
                                                                }
                                                                // 2009/12/17 ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                                                else
                                                                {
                                                                    // 2010/01/14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                                                    //if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1) // 売価＝定価
                                                                    //{
                                                                    //    this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSetting(rowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPrice, this._salesDetailDataTable[rowNo - 1].ListPriceDisplay, 0);
                                                                    //}

                                                                    if (string.IsNullOrEmpty(this._salesDetailDataTable[rowNo - 1].RateDivSalUnPrc))
                                                                    {
                                                                        if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1) // 売価＝定価
                                                                        {
                                                                            this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSetting(rowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPrice, this._salesDetailDataTable[rowNo - 1].ListPriceDisplay, 0);
                                                                        }
                                                                    }
                                                                    // 2010/01/14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                                                }
                                                                // 2009/12/17 ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                                                this._salesDetailDataTable[rowNo - 1].PrtGoodsNo = ((GoodsUnitData)retList[cnt]).PrtGoodsNo;
                                                                this._salesDetailDataTable[rowNo - 1].PrtMakerCode = ((GoodsUnitData)retList[cnt]).PrtMakerCode;
                                                                this._salesDetailDataTable[rowNo - 1].PrtMakerName = ((GoodsUnitData)retList[cnt]).PrtMakerName;
                                                            }

                                                            this._salesDetailDataTable[rowNo - 1].SelectedGoodsNoDiv = ((GoodsUnitData)retList[cnt]).SelectedGoodsNoDiv;
                                                            // --- ADD 2009/10/19 ----------<<<<<

                                                            // 明細粗利率設定処理
                                                            this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(rowNo);

                                                            // 一式情報設定処理
                                                            this._salesSlipInputAcs.ConstructionCompleteInfo(rowNo);

                                                            // 車両情報設定イベントコール処理
                                                            this.SettingCarInfoEventCall(rowNo);

                                                            // 発注情報設定処理
                                                            this._salesSlipInputAcs.SettingUOEOrderDtlRowForNew(rowNo);
                                                        }
                                                        #endregion
                                                        SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UB", "", "○ＢＬコード検索後　各種設定　終了");
                                                    }
                                                    // 受注照会(受注残検索)
                                                    else if (retList[cnt] is AcptAnOdrRemainRefData)
                                                    {
                                                        List<AcptAnOdrRemainRefData> acptAnOdrRemainRefDataList = new List<AcptAnOdrRemainRefData>();
                                                        acptAnOdrRemainRefDataList.Add((AcptAnOdrRemainRefData)retList[cnt]);
                                                        int st = this._salesSlipInputAcs.SalesDetailRowSettingFromAcptAnOdrRemainRefList(salesRowNo + cnt, acptAnOdrRemainRefDataList, SalesSlipInputAcs.WayToDetailExpand.AddUpRemainder);
                                                        if (st == -1)
                                                        {
                                                            TMsgDisp.Show(
                                                                this,
                                                                emErrorLevel.ERR_LEVEL_INFO,
                                                                this.Name,
                                                                "「計上」または「発注選択」済み明細がが選択されましたので、" + Environment.NewLine +
                                                                "明細への展開を行いません。",
                                                                -1,
                                                                MessageBoxButtons.OK);
                                                        }
                                                        else
                                                        {
                                                            settingRowCnt++;
                                                        }
                                                    }
                                                    // 出荷照会(出荷残検索)
                                                    else if (retList[cnt] is SalHisRefResultParamWork)
                                                    {
                                                        List<SalHisRefResultParamWork> salHisRefResultParamWorkList = new List<SalHisRefResultParamWork>();
                                                        salHisRefResultParamWorkList.Add((SalHisRefResultParamWork)retList[cnt]);
                                                        int st = this._salesSlipInputAcs.SalesDetailRowSettingFromSalHisRefResultParamWorkListForAddUp(salesRowNo + cnt, salHisRefResultParamWorkList, SalesSlipInputAcs.WayToDetailExpand.AddUpRemainder);
                                                        if (st == -1)
                                                        {
                                                            TMsgDisp.Show(
                                                                this,
                                                                emErrorLevel.ERR_LEVEL_INFO,
                                                                this.Name,
                                                                "「計上」済み明細が選択されましたので、" + Environment.NewLine +
                                                                "明細への展開を行いません。",
                                                                -1,
                                                                MessageBoxButtons.OK);
                                                        }
                                                        else
                                                        {
                                                            settingRowCnt++;
                                                        }
                                                    }
                                                }
                                            }

                                            // 明細グリッド設定処理
                                            this.SettingGrid();

                                            // 在庫調整
                                            this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

                                            // データ変更フラグプロパティをTrueにする
                                            this._salesSlipInputAcs.IsDataChanged = true;

                                            // 売上金額変更後発生イベントコール処理
                                            this.SalesPriceChangedEventCall();

                                            // フッタ部明細情報更新イベントコール処理
                                            this.SettingFooterEventCall(salesRowNo);
                                        }

                                        break;
                                    }
                                case -1: // 選択キャンセル
                                    {
                                        // BLコードを元に戻す
                                        this._salesDetailDataTable[cell.Row.Index].BLGoodsCode = this._beforeBLGoodsCode;

                                        this._cannotBLGoodsRead = true;
                                        return;
                                    }
                                case -2: // ヒットなし
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "BLコード [" + blCode.ToString() + "] に該当するデータが存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        this._cannotBLGoodsRead = true;
                                        this._salesDetailDataTable[cell.Row.Index].BLGoodsCode = this._beforeBLGoodsCode;
                                        break;
                                    }
                                case -3: // 車両情報未設定
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "車輌情報が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        this._cannotBLGoodsRead = true;
                                        this._salesDetailDataTable[cell.Row.Index].BLGoodsCode = this._beforeBLGoodsCode;
                                        break;
                                    }
                            }
                        }
                    }
                }
                else
                {
                    // BLコード名称設定処理
                    this._salesSlipInputAcs.SettingSalesDetailBLGoodsInfo(salesRowNo, 0);
                }
            }
            #endregion

            #region 仕入先コード(売上情報、仕入情報共通)
            //-----------------------------------------------------------------------------
            // ActiveCellが「仕入先コード」の場合
            //-----------------------------------------------------------------------------
            else if ((cell.Column.Key == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                     (cell.Column.Key == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName))
            {
                int code = TStrConv.StrToIntDef(cell.Value.ToString(), 0);
                string name = string.Empty;
                Supplier supplier;
                UOESupplier uoeSupplier;
                int supplierCd = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                if (code != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);
                    this.Cursor = Cursors.Default;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (this._beforeSupplierCd != supplierCd)
                        {
                            // 仕入先情報設定
                            this._salesSlipInputAcs.SettingSalesDetailSupplierInfo(salesRowNo, supplier);

                            // 仕入先情報設定(仕入情報)
                            this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplier(ref stockTemp, supplier);

                            // 発注先情報設定(発注情報)
                            //>>>2010/07/01
                            //int st = this._uoeSupplierAcs.Read(out uoeSupplier, this._enterpriseCode, code, salesSlip.SectionCode);
                            int st = this._uoeSupplierAcs.ReadCache(out uoeSupplier, this._enterpriseCode, code, salesSlip.SectionCode);
                            //<<<2010/07/01
                            if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);
                                changeUOEOrderDtl = true;
                            }

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
                                // 価格情報再設定
                                this._salesSlipInputAcs.SalesDetailRowGoodsPriceReSetting(salesRowNo);
                                
                                // 受注情報設定
                                this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);

                                // 売上金額計算処理
                                this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                                // 原価金額計算処理
                                this._salesSlipInputAcs.CalculationCost(rowIndex);

                                // 明細粗利率設定処理
                                this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                                // 一式情報設定処理
                                this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);

                                reCalcUnitPrice = true;
                            }
                            else
                            {
                                this._salesSlipInputAcs.ClearRateInfo(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                this._salesSlipInputAcs.ClearRateInfo(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                this._salesSlipInputAcs.ClearRateInfo(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                            }

                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "仕入先コード [" + code.ToString() + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // 仕入先情報再設定
                        status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this._beforeSupplierCd);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._salesSlipInputAcs.SettingSalesDetailSupplierInfo(salesRowNo, supplier);

                            // 仕入先情報設定
                            this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplier(ref stockTemp, supplier);

                            // 発注先情報設定(発注情報)
                            //>>>2010/07/01
                            //int st = this._uoeSupplierAcs.Read(out uoeSupplier, this._enterpriseCode, code, salesSlip.SectionCode);
                            int st = this._uoeSupplierAcs.ReadCache(out uoeSupplier, this._enterpriseCode, code, salesSlip.SectionCode);
                            //<<<2010/07/01
                            if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);
                                changeUOEOrderDtl = true;
                            }
                        }
                        else
                        {
                            supplier = new Supplier();
                            this._salesSlipInputAcs.SettingSalesDetailSupplierInfo(salesRowNo, supplier);

                            // 仕入先情報設定
                            this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplier(ref stockTemp, supplier);

                            // 発注先情報設定(発注情報)
                            uoeSupplier = new UOESupplier();
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);
                            changeUOEOrderDtl = true;
                        }
                        this._cannotSupplierInfoRead = true;

                    }
                }
                else
                {
                    if (this._beforeSupplierCd != supplierCd)
                    {

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
                            name = cell.Value.ToString();

                            // 仕入先情報設定
                            supplier = new Supplier();
                            _salesSlipInputAcs.SettingSalesDetailSupplierInfo(salesRowNo, supplier);

                            // 仕入先情報設定
                            this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplier(ref stockTemp, supplier);

                            // 発注先情報設定(発注情報)
                            uoeSupplier = new UOESupplier();
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);
                            changeUOEOrderDtl = true;

                            // 価格情報再設定
                            this._salesSlipInputAcs.SalesDetailRowGoodsPriceReSetting(salesRowNo);

                            // 受注情報設定
                            this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);

                            // 売上金額計算処理
                            this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                            // 原価金額計算処理
                            this._salesSlipInputAcs.CalculationCost(rowIndex);

                            // 明細粗利率設定処理
                            this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                            // 一式情報設定処理
                            this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);

                            reCalcUnitPrice = true;
                        }
                        else
                        {
                            this._salesSlipInputAcs.ClearRateInfo(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                            this._salesSlipInputAcs.ClearRateInfo(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                            this._salesSlipInputAcs.ClearRateInfo(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                        }
                    }
                }
            }
            #endregion

            #region 仕入日(仕入情報)
            //-----------------------------------------------------------------------------
            // 仕入日(仕入情報)
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.StockDateColumn.ColumnName)
            {
                DateTime dt = new DateTime();
                dt = (DateTime)cell.Value;
                string shortdt = dt.ToShortDateString().Replace("/", "");
                int iDate = TStrConv.StrToIntDef(shortdt, 0);

                if (iDate == 0)
                {
                    this._salesSlipInputAcs.SalesDetailDataTable[cell.Row.Index].StockDate = this._salesSlipInputAcs.SalesSlip.SalesDate;
                }

                DateTime stockDate = (DateTime)cell.Value;

                if (stockTempCurrent.StockDate != stockDate)
                {
                    stockTemp.StockDate = stockDate;

                    // 計上日の再セット
                    this._salesSlipStockInfoInputAcs.SettingAddUpDate(ref stockTemp);

                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "仕入日が変更されました。" + "\r\n" + "\r\n" +
                        "商品価格を再取得しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        reCalcUnitPrice = true;
                    }

                    double taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(stockDate);

                    // 税率が変わった場合、商品価格を再取得しない時のみ税率再計算
                    if (taxRate != stockTempCurrent.SupplierConsTaxRate)
                    {
                        stockTemp.SupplierConsTaxRate = taxRate;

                        if (!reCalcUnitPrice)
                        {
                            taxChange = true;
                        }
                    }
                }
            }
            #endregion

            #region 仕入伝票番号(仕入情報)
            //-----------------------------------------------------------------------------
            // 仕入伝票番号(仕入情報)
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName)
            {
                string partySaleSlipNum = cell.Value.ToString();

                if (stockTempCurrent.PartySaleSlipNum != partySaleSlipNum)
                {
                    stockTemp.PartySaleSlipNum = partySaleSlipNum;
                    this._salesSlipInputAcs.ClearStockTempRowForNew(stockTemp);
                }
            }
            #endregion

            #region ＢＯ区分(発注情報)
            //-----------------------------------------------------------------------------
            // ＢＯ区分(発注情報)
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName)
            {
                string code = cell.Value.ToString().Trim();
                string name = string.Empty;

                if (code == SalesSlipInputAcs.ctDefaultBoCode)
                {
                    this._salesSlipInputAcs.SettingUOEOrderDtlRowFromBoCode(salesRowNo, code);
                    changeUOEOrderDtl = true;
                }
                // --- UPD 2010/05/08 ---------->>>>>
                //else if (this._beforeUOEDeliGoodsDiv != code)
                else if (this._beforeBoCode != code)
                // --- UPD 2010/05/08 ----------<<<<<
                {
                    name = this._salesSlipInputInitDataAcs.GetName_FromUOEGuideName((int)SalesSlipInputAcs.UOEGuideDivCd.BoCode, this._salesDetailDataTable[rowIndex].SupplierCdForOrder, code.ToString());

                    if (name != string.Empty)
                    {
                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromBoCode(salesRowNo, code);
                        this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplierFormal(ref stockTemp, (int)SalesSlipStockInfoInputAcs.SupplierFormal.Order); // 仕入形式設定(発注)
                        this._salesSlipStockInfoInputAcs.SettingStockTempFromPartySalesSilpNum(ref stockTemp, SalesSlipStockInfoInputAcs.ctDummyPartySalesSilpNum);
                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromAcceptAnOrderCnt(salesRowNo); // 発注数設定
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "ＢＯ区分 [" + code + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        if (this._beforeBoCode == SalesSlipInputAcs.ctDefaultBoCode)
                        {
                            // BO区分情報設定(変更前コードへ)
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromBoCode(salesRowNo, this._beforeBoCode);
                        }
                        else
                        {
                            name = this._salesSlipInputInitDataAcs.GetName_FromUOEGuideName((int)SalesSlipInputAcs.UOEGuideDivCd.BoCode, this._salesDetailDataTable[rowIndex].SupplierCdForOrder, this._beforeBoCode);
                            if (name != string.Empty)
                            {
                                // BO区分情報設定(変更前コードへ)
                                this._salesSlipInputAcs.SettingUOEOrderDtlRowFromBoCode(salesRowNo, this._beforeBoCode);
                            }
                            else
                            {
                                // BO区分情報設定(クリア)
                                this._salesSlipInputAcs.SettingUOEOrderDtlRowFromBoCode(salesRowNo, string.Empty);
                                this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplierFormal(ref stockTemp, (int)SalesSlipStockInfoInputAcs.SupplierFormal.Stock); // 仕入形式設定(仕入)
                                this._salesSlipStockInfoInputAcs.SettingStockTempFromPartySalesSilpNum(ref stockTemp, string.Empty);
                            }
                        }
                        this._cannotBoCode = true;
                    }
                    changeUOEOrderDtl = true;
                }
            }
            #endregion

            #region 発注先(発注情報)
            //-----------------------------------------------------------------------------
            // 発注先(発注情報)
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName)
            {
                int code = TStrConv.StrToIntDef(cell.Value.ToString(), 0);
                UOESupplier uoeSupplier;

                if (this._beforeUOESupplierCd != code)
                {
                    if (code != 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        //>>>2010/07/01
                        //int status = this._uoeSupplierAcs.Read(out uoeSupplier, this._enterpriseCode, code, salesSlip.SectionCode);
                        int status = this._uoeSupplierAcs.ReadCache(out uoeSupplier, this._enterpriseCode, code, salesSlip.SectionCode);
                        //<<<2010/07/01
                        this.Cursor = Cursors.Default;
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (!this._salesSlipInputAcs.ExistSalesDetailEnableOdrMakerCd(salesRowNo)) // 発注可能メーカーチェック
                            {
                                int makerCode = this._salesSlipInputAcs.SalesDetailDataTable[rowIndex].GoodsMakerCd;
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "発注先コード [" + code.ToString() + "] の発注可能メーカーに  " + Environment.NewLine + Environment.NewLine + "メーカーコード [" + makerCode.ToString() + "] が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this._salesDetailDataTable[rowIndex].SupplierCdForOrder = this._beforeUOESupplierCd;
                                this._cannotUOESupplierCd = true;
                            }
                            else
                            {
                                this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);
                                changeUOEOrderDtl = true;
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "発注先コード [" + code.ToString() + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            this._salesDetailDataTable[rowIndex].SupplierCdForOrder = this._beforeUOESupplierCd;
                            this._cannotUOESupplierCd = true;
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "発注先が入力されていません。",
                            -1,
                            MessageBoxButtons.OK);
                        uoeSupplier = new UOESupplier();
                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);
                        this._cannotUOESupplierCd = true;
                    }
                }
            }
            #endregion

            #region 発注数(発注情報)
            //-----------------------------------------------------------------------------
            // 発注数(発注情報)
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName)
            {
                double beforeShipmentCnt = this._salesSlipInputAcs.SalesDetailDataTable[rowIndex].ShipmentCntDisplay;
                double beforeAcceptAnOdrCnt = this._salesSlipInputAcs.SalesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay;

                #region 発注数設定
                //-----------------------------------------------------------------------------
                // 発注数設定
                //-----------------------------------------------------------------------------
                int count = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                #region 数量のチェック
                string errMsg = string.Empty;
                SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckAcptAnOdrCntCntForOrder(salesRowNo, out errMsg);

                if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);

                    if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                    {
                        this._salesDetailDataTable[rowIndex].AcceptAnOrderCntForOrder = this._beforeAcptAnOdrCntForOrder;
                        this._isOverFlow = true;
                        return;
                    }
                }
                #endregion

                // 発注数設定
                this._salesSlipInputAcs.SettingUOEOrderDtlRowFromAcceptAnOrderCnt(salesRowNo, count);

                // 出荷数、受注数設定
                this._salesSlipInputAcs.SettingSalesDetailRowInputOrderCnt(salesRowNo);
                #endregion

                #region 受注数設定
                //-----------------------------------------------------------------------------
                // 受注数設定
                //-----------------------------------------------------------------------------
                if (beforeAcceptAnOdrCnt != this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay)
                {
                    #region 数量のチェック
                    errMsg = string.Empty;
                    checkResult = this._salesSlipInputAcs.CheckAcptAnOdrCntCnt(salesRowNo, out errMsg);

                    if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            errMsg,
                            -1,
                            MessageBoxButtons.OK);

                        if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                        {
                            this._salesDetailDataTable[rowIndex].AcceptAnOrderCntForOrder = this._beforeAcptAnOdrCntForOrder;
                            this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay = beforeAcceptAnOdrCnt;
                            this._salesDetailDataTable[rowIndex].ShipmentCntDisplay = beforeShipmentCnt;
                            // 発注数設定
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromAcceptAnOrderCnt(salesRowNo, this._beforeAcptAnOdrCntForOrder);
                            // 受注情報設定
                            this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);
                            // 数量設定処理
                            this._salesSlipInputAcs.SettingAcptAnOdrDetailRowShipmentCnt(salesRowNo);
                            // 数量設定処理
                            this._salesSlipInputAcs.SettingSalesDetailShipmentCnt(salesRowNo);
                            this._isOverFlow = true;
                            return;
                        }
                    }
                    #endregion

                    #region 在庫切れチェック
                    // 在庫切れ出荷区分による在庫数チェック
                    bool setInputError = false;
                    bool showMessage = false;
                    if (!this._salesSlipInputAcs.CheckStockCountForAcceptAnOrderCnt(salesRowNo, out setInputError, out showMessage))
                    {
                        if (showMessage)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "受注数が在庫数を上回ります。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        if (setInputError)
                        {
                            this._salesDetailDataTable[rowIndex].AcceptAnOrderCntForOrder = this._beforeAcptAnOdrCntForOrder;
                            this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay = beforeAcceptAnOdrCnt;
                            this._salesDetailDataTable[rowIndex].ShipmentCntDisplay = beforeShipmentCnt;
                            // 発注数設定
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromAcceptAnOrderCnt(salesRowNo, this._beforeAcptAnOdrCntForOrder);
                            // 受注情報設定
                            this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);
                            // 数量設定処理
                            this._salesSlipInputAcs.SettingAcptAnOdrDetailRowShipmentCnt(salesRowNo);
                            // 数量設定処理
                            this._salesSlipInputAcs.SettingSalesDetailShipmentCnt(salesRowNo);
                            this._isOverFlow = true;
                            return;
                        }
                    }
                    #endregion

                    // 受注情報設定
                    this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);
                    // 数量設定処理
                    this._salesSlipInputAcs.SettingAcptAnOdrDetailRowShipmentCnt(salesRowNo);
                    //// 数量設定処理
                    //this._salesSlipInputAcs.SettingSalesDetailShipmentCnt(salesRowNo);
                }
                #endregion

                #region 出荷数設定
                //-----------------------------------------------------------------------------
                // 出荷数設定
                //-----------------------------------------------------------------------------
                if (beforeShipmentCnt != this._salesDetailDataTable[rowIndex].ShipmentCntDisplay)
                {
                    #region 数量のチェック
                    errMsg = string.Empty;
                    checkResult = this._salesSlipInputAcs.CheckShipmentCnt(salesRowNo, out errMsg);

                    if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            errMsg,
                            -1,
                            MessageBoxButtons.OK);

                        if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                        {
                            this._salesDetailDataTable[rowIndex].AcceptAnOrderCntForOrder = this._beforeAcptAnOdrCntForOrder;
                            this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay = beforeAcceptAnOdrCnt;
                            this._salesDetailDataTable[rowIndex].ShipmentCntDisplay = beforeShipmentCnt;
                            // 発注数設定
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromAcceptAnOrderCnt(salesRowNo, this._beforeAcptAnOdrCntForOrder);
                            // 受注情報設定
                            this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);
                            // 数量設定処理
                            this._salesSlipInputAcs.SettingAcptAnOdrDetailRowShipmentCnt(salesRowNo);
                            // 数量設定処理
                            this._salesSlipInputAcs.SettingSalesDetailShipmentCnt(salesRowNo);
                            this._isOverFlow = true;
                            return;
                        }
                    }
                    #endregion

                    #region 在庫切れチェック
                    // 在庫切れ出荷区分による在庫数チェック
                    bool setInputError = false;
                    bool showMessage = false;
                    if (!this._salesSlipInputAcs.CheckStockCountForShipmentCnt(salesRowNo, out setInputError, out showMessage))
                    {
                        if (showMessage)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "出荷数が在庫数を上回ります。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        if (setInputError)
                        {
                            this._salesDetailDataTable[rowIndex].AcceptAnOrderCntForOrder = this._beforeAcptAnOdrCntForOrder;
                            this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay = beforeAcceptAnOdrCnt;
                            this._salesDetailDataTable[rowIndex].ShipmentCntDisplay = beforeShipmentCnt;
                            // 発注数設定
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromAcceptAnOrderCnt(salesRowNo, this._beforeAcptAnOdrCntForOrder);
                            // 受注情報設定
                            this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);
                            // 数量設定処理
                            this._salesSlipInputAcs.SettingAcptAnOdrDetailRowShipmentCnt(salesRowNo);
                            // 数量設定処理
                            this._salesSlipInputAcs.SettingSalesDetailShipmentCnt(salesRowNo);
                            this._isOverFlow = true;
                            return;
                        }
                    }
                    #endregion

                    //// 受注情報設定
                    //this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);
                    //// 数量設定処理
                    //this._salesSlipInputAcs.SettingAcptAnOdrDetailRowShipmentCnt(salesRowNo);
                    // 数量設定処理
                    this._salesSlipInputAcs.SettingSalesDetailShipmentCnt(salesRowNo);

                    // 売上金額計算処理
                    this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                    // 原価金額計算処理
                    this._salesSlipInputAcs.CalculationCost(rowIndex);

                    // 明細粗利率設定処理
                    this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                    // 一式情報設定処理
                    this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
                }
                #endregion

                changeUOEOrderDtl = true;

            }
            #endregion

            #region 納品区分(発注情報)
            //-----------------------------------------------------------------------------
            // 納品区分(発注情報)
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName)
            {
                string code = cell.Value.ToString().Trim();
                UOEGuideName uoeGuideName;

                if (this._beforeUOEDeliGoodsDiv != code)
                {
                    uoeGuideName = this._salesSlipInputInitDataAcs.GetUOEGuideNameRow_FromUOEGuideName((int)SalesSlipInputAcs.UOEGuideDivCd.DeliveredGoodsDiv, this._salesDetailDataTable[rowIndex].SupplierCdForOrder, code.ToString());

                    if (uoeGuideName != null)
                    {
                        // 納品区分情報設定
                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOEDeliGoodsDiv(salesRowNo, code, uoeGuideName.UOEGuideNm);
                        changeUOEOrderDtl = true;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "納品区分 [" + code.ToString() + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        uoeGuideName = this._salesSlipInputInitDataAcs.GetUOEGuideNameRow_FromUOEGuideName((int)SalesSlipInputAcs.UOEGuideDivCd.DeliveredGoodsDiv, this._salesDetailDataTable[rowIndex].SupplierCdForOrder, this._beforeUOEDeliGoodsDiv);
                        if (uoeGuideName != null)
                        {
                            // 納品区分情報設定(変更前コードへ)
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOEDeliGoodsDiv(salesRowNo, this._beforeUOEDeliGoodsDiv, uoeGuideName.UOEGuideNm);
                        }
                        else
                        {
                            // 納品区分情報設定(クリア)
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOEDeliGoodsDiv(salesRowNo, string.Empty, string.Empty);
                            changeUOEOrderDtl = true;
                        }
                        this._cannotUOEDeliGoodsDiv = true;
                    }
                }
            }
            #endregion

            #region Ｈ納品区分(発注情報)
            //-----------------------------------------------------------------------------
            // Ｈ納品区分(発注情報)
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName)
            {
                string code = cell.Value.ToString().Trim();
                UOEGuideName uoeGuideName;

                if (this._beforeFollowDeliGoodsDiv != code)
                {
                    uoeGuideName = this._salesSlipInputInitDataAcs.GetUOEGuideNameRow_FromUOEGuideName((int)SalesSlipInputAcs.UOEGuideDivCd.DeliveredGoodsDiv, this._salesDetailDataTable[rowIndex].SupplierCdForOrder, code);

                    if (uoeGuideName != null)
                    {
                        // Ｈ納品区分情報設定
                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromFollowDeliGoodsDiv(salesRowNo, code, uoeGuideName.UOEGuideNm);
                        changeUOEOrderDtl = true;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "Ｈ納品区分 [" + code + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        uoeGuideName = this._salesSlipInputInitDataAcs.GetUOEGuideNameRow_FromUOEGuideName((int)SalesSlipInputAcs.UOEGuideDivCd.DeliveredGoodsDiv, this._salesDetailDataTable[rowIndex].SupplierCdForOrder, this._beforeFollowDeliGoodsDiv);
                        if (uoeGuideName != null)
                        {
                            // Ｈ納品区分情報設定(変更前コードへ)
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromFollowDeliGoodsDiv(salesRowNo, this._beforeFollowDeliGoodsDiv, uoeGuideName.UOEGuideNm);
                        }
                        else
                        {
                            // Ｈ納品区分情報設定(クリア)
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromFollowDeliGoodsDiv(salesRowNo, string.Empty, string.Empty);
                            changeUOEOrderDtl = true;
                        }
                        this._cannotFollowDeligoodsDiv = true;
                    }
                }
            }
            #endregion

            #region 指定拠点(発注情報)
            //-----------------------------------------------------------------------------
            // 指定拠点(発注情報)
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
            {
                string code = cell.Value.ToString().Trim();
                UOEGuideName uoeGuideName;

                if (this._beforeUOEResvdSection != code)
                {
                    uoeGuideName = this._salesSlipInputInitDataAcs.GetUOEGuideNameRow_FromUOEGuideName((int)SalesSlipInputAcs.UOEGuideDivCd.UOEResvdSection, this._salesDetailDataTable[rowIndex].SupplierCdForOrder, code);

                    if (uoeGuideName != null)
                    {
                        // 指定拠点情報設定
                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOEResvdSection(salesRowNo, code, uoeGuideName.UOEGuideNm);
                        changeUOEOrderDtl = true;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "指定拠点 [" + code + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        uoeGuideName = this._salesSlipInputInitDataAcs.GetUOEGuideNameRow_FromUOEGuideName((int)SalesSlipInputAcs.UOEGuideDivCd.UOEResvdSection, this._salesDetailDataTable[rowIndex].SupplierCdForOrder, this._beforeUOEResvdSection);
                        if (uoeGuideName != null)
                        {
                            // 指定拠点設定(変更前コードへ)
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOEResvdSection(salesRowNo, this._beforeUOEResvdSection, uoeGuideName.UOEGuideNm);
                        }
                        else
                        {
                            // 指定拠点設定(クリア)
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOEResvdSection(salesRowNo, string.Empty, string.Empty);
                            changeUOEOrderDtl = true;
                        }
                        this._cannotUOEResvdSection = true;
                    }
                }
            }
            #endregion

            //>>>2010/02/26
            #region RC区分(SCM情報)
            //-----------------------------------------------------------------------------
            // RC区分(SCM情報)
            //-----------------------------------------------------------------------------
            else if (cell.Column.Key == this._salesDetailDataTable.RecycleDivNmColumn.ColumnName)
            {
                int code = TStrConv.StrToIntDef(cell.Value.ToString().Trim(), 0);
                string name;

                if (this._beforeRecycleDiv != code)
                {
                    name = this._salesSlipInputAcs.GetKind_FromSobaInfo(code);

                    if (name != string.Empty)
                    {
                        // RC区分情報設定
                        this._salesSlipInputAcs.SettingSalesDetailRowRecycleDiv(salesRowNo, code, name);
                        changeSCMInfo = true;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "RC区分[" + code + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        name = this._salesSlipInputAcs.GetKind_FromSobaInfo(this._beforeRecycleDiv);
                        if (name != null)
                        {
                            // 指定拠点設定(変更前コードへ)
                            this._salesSlipInputAcs.SettingSalesDetailRowRecycleDiv(salesRowNo, this._beforeRecycleDiv, name);
                        }
                        else
                        {
                            // 指定拠点設定(クリア)
                            this._salesSlipInputAcs.SettingSalesDetailRowRecycleDiv(salesRowNo, 0, string.Empty);
                            changeSCMInfo = true;
                        }
                        //this._cannotRecycleDiv = true;
                    }
                }
            }
            #endregion
            //<<<2010/02/26

            #region 売上情報
            //-----------------------------------------------------------------------------
            // 売上情報
            //-----------------------------------------------------------------------------
            // 売上金額変更後発生イベントコール処理
            this.SalesPriceChangedEventCall();

            // フッタ部明細情報更新イベントコール処理
            this.SettingFooterEventCall(salesRowNo);
            #endregion

            #region 仕入情報
            //-----------------------------------------------------------------------------
            // 仕入情報
            //-----------------------------------------------------------------------------
            // 税率変更
            if (taxChange) reCalcStockPrice = true;

            // 単価再計算有り(掛率から一括取得)
            if (reCalcUnitPrice)
            {
                this._salesSlipStockInfoInputAcs.CalclationUnitPrice(ref stockTemp);
                reCalcStockPrice = true;
            }

            // 仕入金額再計算
            if (reCalcStockPrice)
            {
                this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);
            }

            // メモリ上の内容と比較する
            if (stockTempCurrent != null)
            {
                ArrayList arRetList = stockTemp.Compare(stockTempCurrent);
                if (arRetList.Count > 0)
                {
                    this._salesSlipStockInfoInputAcs.Cache(stockTemp);
                }
            }
            #endregion

            #region 発注情報
            //-----------------------------------------------------------------------------
            // 発注情報
            //-----------------------------------------------------------------------------
            if (changeUOEOrderDtl)
            {
                this._salesSlipInputAcs.SettingSalesDetailRowUOEOrderDtl(salesRowNo);

                //>>>2010/06/09
                //// --- ADD 2010/01/27 -------------->>>
                ////発注選択が不可となった場合,受注数と出荷数をクリア
                //if ((this._salesSlipInputAcs.ExistStockTempForStock(salesRowNo)) ||
                //    (!this._salesSlipInputAcs.ExistSalesDetailSupplierCd(salesRowNo)) ||
                //    (!this._salesSlipInputAcs.ExistSalesDetailEnableOdrMakerCd(salesRowNo)))
                //{
                //    this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay = 0;
                //    this._salesDetailDataTable[rowIndex].ShipmentCntDisplay = 1;
                //}
                //// --- ADD 2010/01/27 --------------<<<

                if ((cell.Column.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName) ||
                    (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName))
                {

                    string bo = SalesSlipInputAcs.ctDefaultBoCode;
                    if (cell.Column.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName)
                    {
                        bo = this._beforeBoCode;
                    }
                    else
                    {
                        bo = this._salesDetailDataTable[rowIndex].BoCode;
                    }

                    double acptAnOdrCntForOrder = 0;
                    if (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName)
                    {
                        acptAnOdrCntForOrder = this._beforeAcptAnOdrCntForOrder;
                    }
                    else
                    {
                        acptAnOdrCntForOrder = this._salesDetailDataTable[rowIndex].AcceptAnOrderCntForOrder;
                    }


                //発注選択が不可となった場合,受注数と出荷数をクリア
                if ((this._salesSlipInputAcs.ExistStockTempForStock(salesRowNo)) ||
                    (!this._salesSlipInputAcs.ExistSalesDetailSupplierCd(salesRowNo)) ||
                        (!this._salesSlipInputAcs.ExistSalesDetailEnableOdrMakerCd(salesRowNo)) ||
                        ((!this._salesSlipInputAcs.ExistOrderInfo(salesRowNo)) &&
                         (this._salesSlipInputAcs.ExistOrderInfo(bo, this._salesDetailDataTable[rowIndex].SupplierCdForOrder, acptAnOdrCntForOrder))))
                {
                    this._salesDetailDataTable[rowIndex].AcceptAnOrderCntDisplay = 0;
                        this._salesDetailDataTable[rowIndex].ShipmentCntDisplay = this._salesDetailDataTable[rowIndex].ShipmentCntDefForChk;

                        // 受注情報設定
                        this._salesSlipInputAcs.SettingSalesDetailAcceptAnOrder(salesRowNo);

                        // 数量設定処理
                        this._salesSlipInputAcs.SettingAcptAnOdrDetailRowShipmentCnt(salesRowNo);

                        // 数量設定処理
                        this._salesSlipInputAcs.SettingSalesDetailShipmentCnt(salesRowNo);

                        // 売上金額計算処理
                        this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                        // 原価金額計算処理
                        this._salesSlipInputAcs.CalculationCost(rowIndex);

                        // 明細粗利率設定処理
                        this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                        // 一式情報設定処理
                        this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
                    }
                }
                //<<<2010/06/09
            }
            #endregion

            // 明細グリッド・行単位でのセル設定
            // --- UPD 2010/01/27 -------------->>>>>
            //this.SettingGridRow(rowIndex, this._salesSlipInputAcs.SalesSlip);

            int rowEffectiveIndex = SettingGridRowFromInputChange();

            // --- UPD 2010/01/27 --------------<<<<<

            // データ変更フラグプロパティをTrueにする
            this._salesSlipInputAcs.IsDataChanged = true;
        }

        // --- ADD m.suzuki 2010/04/14 ---------->>>>>
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
        // --- ADD m.suzuki 2010/04/14 ----------<<<<<

        /// <summary>
        /// グリッドセルアクティブ化前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            // 項目に従いIMEモード設定
            this.uGrid_Details.ImeMode = uiSetControl1.GetSettingImeMode(e.Cell.Column.Key);

            // ゼロ詰め解除実行
            if (e.Cell.Column.DataType == typeof(string) && e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if (e.Cell.Value != null)
                {
                    this._salesDetailDataTable.Rows[e.Cell.Row.Index][e.Cell.Column.Key] = uiSetControl1.GetZeroPadCanceledText(e.Cell.Column.Key, (string)this._salesDetailDataTable.Rows[e.Cell.Row.Index][e.Cell.Column.Key]);
                }
            }

            //// ここ
            //if (((e.Cell.Column.DataType == typeof(Int32)) || (e.Cell.Column.DataType == typeof(Int64)) || (e.Cell.Column.DataType == typeof(double))) && (e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit))
            //{
            //    if (e.Cell.Value.ToString() == "0")
            //    {
            //        this._salesDetailDataTable.Rows[e.Cell.Row.Index][e.Cell.Column.Key] = DBNull.Value;
            //    }
            //}
                
            //-----------------------------------------------------------------------------
            // NoEdit項目のアクティブ状態の文字色指定
            //-----------------------------------------------------------------------------
            e.Cell.Band.Override.ActiveCellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

            #region 原単価、原価率
            if ((e.Cell.Column.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName) ||
                (e.Cell.Column.Key == this._salesDetailDataTable.CostRateColumn.ColumnName))
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd)
                {
                    case 0: // 表示しない
                        e.Cell.Band.Override.ActiveCellAppearance.ForeColor = Color.Transparent;
                        break;
                    case 1: // 表示する

                        if (this._salesSlipInputAcs.CostDisplay == false) // HOMEキーによる制御
                        {
                            e.Cell.Band.Override.ActiveCellAppearance.ForeColor = Color.Transparent;
                        }
                        else
                        {
                            if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                            {
                                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost)
                                {
                                    // 未使用
                                    case 2:
                                        e.Cell.Band.Override.ActiveCellAppearance.ForeColor = Color.Transparent;
                                        break;
                                }
                            }
                            else
                            {
                                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost)
                                {
                                    // 未使用
                                    case 2:
                                        e.Cell.Band.Override.ActiveCellAppearance.ForeColor = Color.Transparent;
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
            #endregion

            #region 現在庫数
            if (e.Cell.Column.Key == this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName)
            {
                if (string.IsNullOrEmpty(this._salesDetailDataTable[e.Cell.Row.Index].WarehouseCode.Trim()))
                {
                    e.Cell.Band.Override.ActiveCellAppearance.ForeColor = Color.Transparent;
                }
            }
            #endregion

            // 納品完了予定日
            if (e.Cell.Column.Key == this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName)
            {
                //>>>2010/02/26
                //if (this._salesDetailDataTable[e.Cell.Row.Index].AcceptAnOrderCntDisplay == 0)
                if ((this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) &&
                    (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.SearchEstimate))
                //<<<2010/02/26
                {
                    e.Cell.Band.Override.ActiveCellAppearance.ForeColor = Color.Transparent;
                }
            }

            // 納品区分名称
            if (e.Cell.Column.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName)
            {
                this._salesDetailDataTable[e.Cell.Row.Index].DeliveredGoodsDivNmSave = this._salesDetailDataTable[e.Cell.Row.Index].DeliveredGoodsDivNm;
                if (this._salesDetailDataTable[e.Cell.Row.Index].DeliveredGoodsDivNmSave != string.Empty)
                {
                    this._salesDetailDataTable[e.Cell.Row.Index].DeliveredGoodsDivNm = this._salesDetailDataTable[e.Cell.Row.Index].UOEDeliGoodsDiv.ToString();
                }
                else
                {
                    this._salesDetailDataTable[e.Cell.Row.Index].DeliveredGoodsDivNm = this._salesDetailDataTable[e.Cell.Row.Index].DeliveredGoodsDivNm;
                }
            }

            // Ｈ納品区分名称
            if (e.Cell.Column.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName)
            {
                this._salesDetailDataTable[e.Cell.Row.Index].FollowDeliGoodsDivNmSave = this._salesDetailDataTable[e.Cell.Row.Index].FollowDeliGoodsDivNm;
                if (this._salesDetailDataTable[e.Cell.Row.Index].FollowDeliGoodsDivNmSave.Trim() != string.Empty)
                {
                    this._salesDetailDataTable[e.Cell.Row.Index].FollowDeliGoodsDivNm = this._salesDetailDataTable[e.Cell.Row.Index].FollowDeliGoodsDiv.ToString();
                }
                else
                {
                    this._salesDetailDataTable[e.Cell.Row.Index].FollowDeliGoodsDivNm = this._salesDetailDataTable[e.Cell.Row.Index].FollowDeliGoodsDivNm;
                }
            }

            // 指定拠点名称
            if (e.Cell.Column.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
            {
                this._salesDetailDataTable[e.Cell.Row.Index].UOEResvdSectionNmSave = this._salesDetailDataTable[e.Cell.Row.Index].UOEResvdSectionNm;
                if (this._salesDetailDataTable[e.Cell.Row.Index].UOEResvdSectionNmSave.Trim() != string.Empty)
                {
                    this._salesDetailDataTable[e.Cell.Row.Index].UOEResvdSectionNm = this._salesDetailDataTable[e.Cell.Row.Index].UOEResvdSection.ToString();
                }
                else
                {
                    this._salesDetailDataTable[e.Cell.Row.Index].UOEResvdSectionNm = this._salesDetailDataTable[e.Cell.Row.Index].UOEResvdSectionNm;
                }
            }

            //>>>2010/02/26
            // RC区分
            if (e.Cell.Column.Key == this._salesDetailDataTable.RecycleDivNmColumn.ColumnName)
            {
                this._salesDetailDataTable[e.Cell.Row.Index].RecycleDivNmSave = this._salesDetailDataTable[e.Cell.Row.Index].RecycleDivNm;
                if (this._salesDetailDataTable[e.Cell.Row.Index].RecycleDivNmSave.Trim() != string.Empty)
                {
                    this._salesDetailDataTable[e.Cell.Row.Index].RecycleDivNm = this._salesDetailDataTable[e.Cell.Row.Index].RecycleDiv.ToString();
                }
                else
                {
                    this._salesDetailDataTable[e.Cell.Row.Index].RecycleDivNm = this._salesDetailDataTable[e.Cell.Row.Index].RecycleDivNm;
                }
            }
            //<<<2010/02/26

            this._beforeCell = e.Cell;
        }

        /// <summary>
        /// uGrid_Details_BeforeSelectChange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeSelectChange(object sender, Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs e)
        {
            #region 原価率、原単価
            Infragistics.Win.UltraWinGrid.UltraGridCell cellSalesUnitCost = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName];
            Infragistics.Win.UltraWinGrid.UltraGridCell cellCostRate = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.CostRateColumn.ColumnName];

            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd)
            {
                case 0: // 表示しない
                    cellSalesUnitCost.SelectedAppearance.ForeColor = Color.Transparent;
                    cellSalesUnitCost.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                    cellCostRate.SelectedAppearance.ForeColor = Color.Transparent;
                    cellCostRate.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                    break;
                case 1: // 表示する

                    if (this._salesSlipInputAcs.CostDisplay == false) // HOMEキーによる制御
                    {
                        cellSalesUnitCost.SelectedAppearance.ForeColor = Color.Transparent;
                        cellSalesUnitCost.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                        cellCostRate.SelectedAppearance.ForeColor = Color.Transparent;
                        cellCostRate.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                    }
                    else
                    {
                        if (this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
                        {
                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost)
                            {
                                // 未使用
                                case 2:
                                    cellSalesUnitCost.SelectedAppearance.ForeColor = Color.Transparent;
                                    cellSalesUnitCost.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                                    cellCostRate.SelectedAppearance.ForeColor = Color.Transparent;
                                    cellCostRate.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                                    break;
                                default:
                                    cellSalesUnitCost.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                    cellSalesUnitCost.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                    cellCostRate.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                    cellCostRate.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                    break;
                            }
                        }
                        else
                        {
                            switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost)
                            {
                                // 未使用
                                case 2:
                                    cellSalesUnitCost.SelectedAppearance.ForeColor = Color.Transparent;
                                    cellSalesUnitCost.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                                    cellCostRate.SelectedAppearance.ForeColor = Color.Transparent;
                                    cellCostRate.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                                    break;
                                default:
                                    cellSalesUnitCost.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                    cellSalesUnitCost.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                    cellCostRate.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                    cellCostRate.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                                    break;
                            }
                        }
                    }
                    break;
                default:
                    cellSalesUnitCost.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                    cellSalesUnitCost.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                    cellCostRate.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                    cellCostRate.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;

                    break;
            }
            #endregion

            #region 現在庫数
            Infragistics.Win.UltraWinGrid.UltraGridCell cellSupplierStockDisplay = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName];
            if (string.IsNullOrEmpty(this._salesDetailDataTable[uGrid_Details.ActiveRow.Index].WarehouseCode.Trim()))
            {
                cellSupplierStockDisplay.SelectedAppearance.ForeColor = Color.Transparent;
                cellSupplierStockDisplay.SelectedAppearance.ForeColorDisabled = Color.Transparent;
            }
            else
            {
                cellSupplierStockDisplay.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                cellSupplierStockDisplay.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
            }
            #endregion

            #region 納品完了予定日
            Infragistics.Win.UltraWinGrid.UltraGridCell cellDeliGdsCmpltDueDate = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName];
            double acceptAnOrderCntDisplay = this._salesDetailDataTable[uGrid_Details.ActiveRow.Index].AcceptAnOrderCntDisplay;
            if (cellDeliGdsCmpltDueDate.Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
            {
                cellDeliGdsCmpltDueDate.SelectedAppearance.ForeColor = Color.Transparent;
                cellDeliGdsCmpltDueDate.SelectedAppearance.ForeColorDisabled = Color.Transparent;
            }
            else
            {
                //>>>2010/02/26
                //if (acceptAnOrderCntDisplay == 0)
                //{
                //    cellDeliGdsCmpltDueDate.SelectedAppearance.ForeColor = Color.Transparent;
                //    cellDeliGdsCmpltDueDate.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                //}
                //else
                //{
                //    cellDeliGdsCmpltDueDate.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                //    cellDeliGdsCmpltDueDate.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                //}

                cellDeliGdsCmpltDueDate.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                cellDeliGdsCmpltDueDate.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                //<<<2010/02/26
            }
            #endregion

            #region 明細備考
            Infragistics.Win.UltraWinGrid.UltraGridCell cellDtlNote = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.DtlNoteColumn.ColumnName];
            if (cellDtlNote.Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled)
            {
                cellDtlNote.SelectedAppearance.ForeColor = Color.Transparent;
                cellDtlNote.SelectedAppearance.ForeColorDisabled = Color.Transparent;
            }
            else
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().DtlNoteDispDiv)
                {
                    // 入力あり
                    case 0:
                        cellDtlNote.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                        cellDtlNote.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                        break;
                    // 非表示
                    case 1:
                        cellDtlNote.SelectedAppearance.ForeColor = Color.Transparent;
                        cellDtlNote.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                        break;
                    default:
                        cellDtlNote.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                        cellDtlNote.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                        break;
                }
            }
            #endregion

            #region 得意先注番
            Infragistics.Win.UltraWinGrid.UltraGridCell cellPartySlipNumDtl = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName];
            switch (this._salesSlipInputAcs.SalesSlip.CustOrderNoDispDiv)
            {
                // 表示しない
                case 0:
                    cellPartySlipNumDtl.SelectedAppearance.ForeColor = Color.Transparent;
                    cellPartySlipNumDtl.SelectedAppearance.ForeColorDisabled = Color.Transparent;
                    break;
                // 表示する
                case 1:
                    cellPartySlipNumDtl.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                    cellPartySlipNumDtl.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                    break;
                default:
                    cellPartySlipNumDtl.SelectedAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                    cellPartySlipNumDtl.SelectedAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.RowAppearance.ForeColor;
                    break;
            }
            #endregion
        }

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (_firstEnter == false)
            {
                if (this.uGrid_Details.ActiveCell == null)
                {
                    if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_Details.ActiveCell == null))
                    {
                        if (this.uGrid_Details.Rows.Count > 0)
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                            
                            if ((this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                                (this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
                            {
                                // 次入力可能セル移動処理
                                this.MoveNextAllowEditCell(true);
                            }
                        }
                    }
                }

                if ((this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
                    (this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
                {
                    if (this.uGrid_Details.ActiveCell != null)
                    {
                        if ((!this.uGrid_Details.ActiveCell.IsInEditMode) &&
                            (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.Hidden == false)) // 非表示項目は移動可能セル探索
                        {
                            // --- ADD 2009/10/19 ---------->>>>>

                            if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Normal)
                                && (this._salesSlipInputAcs.SalesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum))
                            {
                                #region 行移動時のフォーカス制御の変更
                                string errMsg = string.Empty;
                                bool checkFlag = false;
                                if (this._salesDetailDataTable != null && _beforeCell != null && _beforeCell.Row != null
                                    && _beforeCell.Row.Index >= 0)
                                {
                                    checkFlag = CheckRowEffective(_beforeCell.Row.Index);

                                    if (checkFlag == true)
                                    {
                                        if (this._salesDetailDataTable[_beforeCell.Row.Index].SearchPartsModeState == 1)
                                        {
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                        }
                                        else if (this._salesDetailDataTable[_beforeCell.Row.Index].SearchPartsModeState == 2)
                                        {
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                                        }
                                    }
                                    else
                                    {
                                        if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
                                        {
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                                        }
                                        else
                                        {
                                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                                        }
                                    }
                                }
                                #endregion

                                // --- ADD 2009/10/19 ----------<<<<<
                            }
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            // 次入力可能セル移動処理
                            this.MoveNextAllowEditCell(true);
                        }
                    }
                }
            }
            else
            {
                // 初回Enter時のみ動作
                _firstEnter = false;

                if (this._salesSlipInputAcs.SalesSlip.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.Goods)
                {
                    if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                    }
                    else
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
                    }
                }
                else
                {
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName];
                }

                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
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
            if (cell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
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

            // 横スクロールバー位置設定
            if (cell.Column.Key == this._salesDetailDataTable.GoodsNoColumn.ColumnName)
            {
                this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
            }

            this._cannotGoodsRead = false;
            this._beforeCellUpdateCancel = false;
            this._isOverFlow = false;

            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

        }

        /// <summary>
        /// グリッド行アクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

            // セルアクティブ時ボタン有効無効コントロール処理
            this.ActiveCellButtonEnabledControl(row.Index, null);

            // フッタ部明細情報更新イベントコール処理
            this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

            // 車両情報設定イベントコール処理
            this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

            this.uButton_Guide.Enabled = false;

            // --- ADD 2009/10/19 ---------->>>>>
            #region 粗利率チェック
            string errMsg = string.Empty;
            bool checkFlag = false;
            if (this._salesDetailDataTable != null && _beforeCell != null && _beforeCell.Row != null
                && _beforeCell.Row.Index >= 0)
            {
                int salesRowNo = this._salesDetailDataTable[_beforeCell.Row.Index].SalesRowNo;

                if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo)
                {
                    if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsNo) &&
                        !string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                    {
                        checkFlag = true;
                    }
                }
                else if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_VoluntaryGoodsNo)
                {
                    if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                    {
                        checkFlag = true;
                    }
                }

                if (checkFlag == true)
                {
                    //原単価
                    SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckSalesUnitCost(salesRowNo, 0, out errMsg, 1);

                    if (this.uGrid_Details.ActiveCell != this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName])
                    {
                        if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                        {
                            TMsgDisp.Show(
                                //this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                errMsg,
                                -1,
                                MessageBoxButtons.OK);

                            if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                            {
                                this.uGrid_Details.AfterRowActivate -= this.uGrid_Details_AfterRowActivate;
                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName];
                                this.uGrid_Details.AfterRowActivate += this.uGrid_Details_AfterRowActivate;
                            }

                            // セルアクティブ時ボタン有効無効コントロール処理
                            this.ActiveCellButtonEnabledControl(row.Index, null);

                            // フッタ部明細情報更新イベントコール処理
                            this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                            // 車両情報設定イベントコール処理
                            this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

                            this.uButton_Guide.Enabled = false;

                            //粗利率下限チェック
                            // 警告
                            if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().InpGrsProfChkLowDiv == 1)
                            {
                                // --- ADD 2009/11/24 ---------->>>>>
                                #region 売価率および売単価が未入力チェック
                                if (this._salesDetailDataTable != null && _beforeCell != null && _beforeCell.Row != null
                                    && _beforeCell.Row.Index >= 0)
                                {
                                    checkFlag = false;
                                    if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo)
                                    {
                                        if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsNo) &&
                                            !string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                                        {
                                            checkFlag = true;
                                        }
                                    }
                                    else if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_VoluntaryGoodsNo)
                                    {
                                        if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                                        {
                                            checkFlag = true;
                                        }
                                    }

                                    //>>>2010/02/22
                                    if (this._salesDetailDataTable[_beforeCell.Row.Index].EditStatus == SalesSlipInputAcs.ctEDITSTATUS_Annotation) checkFlag = false;
                                    //<<<2010/02/22

                                    if (checkFlag == true)
                                    {
                                        if (this._salesDetailDataTable[_beforeCell.Row.Index].SalesRate == 0 &&
                                            this._salesDetailDataTable[_beforeCell.Row.Index].SalesUnPrcDisplay == 0)
                                        {
                                            DialogResult dialogResult = TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_QUESTION,
                                                this.Name,
                                                "売価率・売単価共に0ですがよろしいですか",
                                                0,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxDefaultButton.Button1);

                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                return;
                                            }
                                            else
                                            {
                                                this.uGrid_Details.AfterRowActivate -= this.uGrid_Details_AfterRowActivate;
                                                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName];
                                                this.uGrid_Details.AfterRowActivate += this.uGrid_Details_AfterRowActivate;

                                                // セルアクティブ時ボタン有効無効コントロール処理
                                                this.ActiveCellButtonEnabledControl(row.Index, null);

                                                // フッタ部明細情報更新イベントコール処理
                                                this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                                                // 車両情報設定イベントコール処理
                                                this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

                                                this.uButton_Guide.Enabled = false;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                // --- ADD 2009/11/24 ----------<<<<<
                            }

                            return;
                        }
                    }
                }
            }
            #endregion
            // --- ADD 2009/10/19 ----------<<<<<

            // --- ADD 2009/11/24 ---------->>>>>
            #region 売価率および売単価が未入力チェック
            if (this._salesDetailDataTable != null && _beforeCell != null && _beforeCell.Row != null
                && _beforeCell.Row.Index >= 0)
            {
                checkFlag = false;
                if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo)
                {
                    if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsNo) &&
                        !string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                    {
                        checkFlag = true;
                    }
                }
                else if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_VoluntaryGoodsNo)
                {
                    if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                    {
                        checkFlag = true;
                    }
                }

                //>>>2010/02/22
                if (this._salesDetailDataTable[_beforeCell.Row.Index].EditStatus == SalesSlipInputAcs.ctEDITSTATUS_Annotation) checkFlag = false;
                //<<<2010/02/22

                if (checkFlag == true)
                {
                    if (this._salesDetailDataTable[_beforeCell.Row.Index].SalesRate == 0 &&
                        this._salesDetailDataTable[_beforeCell.Row.Index].SalesUnPrcDisplay == 0)
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "売価率・売単価共に0ですがよろしいですか",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.Yes)
                        {
                            return;
                        }
                        else
                        {
                            this.uGrid_Details.AfterRowActivate -= this.uGrid_Details_AfterRowActivate;
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName];
                            this.uGrid_Details.AfterRowActivate += this.uGrid_Details_AfterRowActivate;

                            // セルアクティブ時ボタン有効無効コントロール処理
                            this.ActiveCellButtonEnabledControl(row.Index, null);

                            // フッタ部明細情報更新イベントコール処理
                            this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                            // 車両情報設定イベントコール処理
                            this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

                            this.uButton_Guide.Enabled = false;
                        }
                    }
                }
            }
            #endregion
            // --- ADD 2009/11/24 ----------<<<<<
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
                    if (editorBase.CurrentEditText.Trim() == string.Empty)
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
                else if (this.uGrid_Details.ActiveCell.Column.DataType == typeof(DateTime))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;
                    int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;

                    try
                    {
                        DateTime dateTime = (DateTime)editorBase.Value;
                    }
                    catch (Exception)
                    {
                        editorBase.Value = this._salesSlipInputAcs.SalesSlip.SalesDate;
                        e.RaiseErrorEvent = false;
                    }
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
                if ((this._salesSlipInputAcs.SalesSlip == null) || (this._salesSlipInputAcs.SalesSlip.SalesGoodsCd != 0)) return;

                Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;

                if (cell.Column.Key == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName)
                {
                    cell.Appearance.Cursor = Cursors.Default;

                    string tipString = string.Empty;
                    if (cell.Appearance.FontData.Underline == Infragistics.Win.DefaultableBoolean.True)
                    {
                        tipString = "在庫移動が行われている為、編集できません。";
                    }

                    if (!string.IsNullOrEmpty(tipString))
                    {
                        cell.Appearance.Cursor = Cursors.Help;

                        Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = this.uToolTipManager_Information.GetUltraToolTip(this.uGrid_Details);
                        if (ultraToolTipInfo != null)
                        {
                            ultraToolTipInfo.ToolTipTitle = "倉庫情報";
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
                else if (cell.Column.Key == this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName)
                {
                    if ((this._salesDetailDataTable[cell.Row.Index].AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) &&
                        (!this._salesSlipInputAcs.ExistOrderInfo(this._salesDetailDataTable[cell.Row.Index].SalesRowNo)))
                    {
                        cell.Appearance.Cursor = Cursors.Default;
                        string tipString = this._salesSlipInputAcs.CreateStockCountInfoString(this._salesDetailDataTable[cell.Row.Index].SalesRowNo);

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
                else if (cell.Column.Key == this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName)
                {
                    if (((this._salesDetailDataTable[cell.Row.Index].AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) ||
                         (this._salesDetailDataTable[cell.Row.Index].AcptAnOdrStatusSrc == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate)) &&
                        (!this._salesSlipInputAcs.ExistOrderInfo(this._salesDetailDataTable[cell.Row.Index].SalesRowNo)))
                    {

                        cell.Appearance.Cursor = Cursors.Default;
                        string tipString = this._salesSlipInputAcs.CreateStockCountInfoString(this._salesDetailDataTable[cell.Row.Index].SalesRowNo);

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
            this._salesDetailDataTable.AcceptChanges();

            // ActiveRowインデックス取得処理
            int rowIndex = e.Cell.Row.Index;
            if (rowIndex == -1) return;

            //// 得意先入力チェック処理
            //bool customerCodeCheck = this.CheckCustomerCodeInput();
            //if (!customerCodeCheck)
            //{
            //    return;
            //}

            // 売上行番号を取得
            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;

            //#region ●商品ガイド
            //if (e.Cell.Column.Key == this._salesDetailDataTable.GoodsGuideButtonColumn.ColumnName)
            //{
            //    this.ExecuteGoodsGuide(rowIndex);
            //}
            //#endregion
        }

        /// <summary>
        /// 明細グリッドリーヴイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            if (this.StatusBarMessageSetting != null)
            {
                this.StatusBarMessageSetting(this, string.Empty);
            }

            if ((this._beforeCell != null) && (this._beforeCell.Row.Index != -1))
            {
                if (this._beforeCell.Column.DataType == typeof(string) && this._beforeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // ゼロ詰め実行
                    this._salesDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key] = uiSetControl1.GetZeroPaddedText(this._beforeCell.Column.Key, (string)this._salesDetailDataTable.Rows[this._beforeCell.Row.Index][this._beforeCell.Column.Key].ToString().Trim());
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
            this._salesDetailDataTable.AcceptChanges();

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            string message;
            bool judge = this._salesSlipInputAcs.InsertSalesDetailRowCheck(out message);
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

                // 売上明細行挿入処理
                this._salesSlipInputAcs.InsertSalesDetailRow(rowIndex);

                // 明細グリッドセル設定処理
                this.SettingGrid();

                // 現在庫数調整
                this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

                // 売上金額変更後発生イベントコール処理
                this.SalesPriceChangedEventCall();

                // フッタ部明細情報更新イベントコール処理
                this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                // 車両情報設定イベントコール処理
                this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());


                // 次入力可能セル移動処理
                this.MoveNextAllowEditCell(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            this._salesDetailDataTable.AcceptChanges();

            // 選択済み売上行番号リスト取得処理
            List<int> selectedSalesRowNoList = this.GetSelectedSalesRowNoList();
            if ((selectedSalesRowNoList == null) || (selectedSalesRowNoList.Count == 0))
            {
                return;
            }

            string message;
            bool exist = this._salesSlipInputAcs.DeleteSalesDetailRowCheck(selectedSalesRowNoList, out message);

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

                // 売上明細行削除処理
                this._salesSlipInputAcs.DeleteSalesDetailRow(selectedSalesRowNoList, false);

                // 明細グリッドセル設定処理
                this.SettingGrid();

                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.Rows.Count > rowIndex))
                {
                    if ((this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled) ||
                        (this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                        (this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Column.Hidden == true))
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                    }
                    else
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                    }

                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }

                // 現在庫数調整
                this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

                // 売上金額変更後発生イベントコール処理
                this.SalesPriceChangedEventCall();

                // フッタ部明細情報更新イベントコール処理
                this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                // 車両情報設定イベントコール処理
                this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

                // データ変更フラグプロパティをTrueにする
                this._salesSlipInputAcs.IsDataChanged = true;
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
            this._salesDetailDataTable.AcceptChanges();

            // 選択済み仕入行番号リスト取得処理
            List<int> selectedStockRowNoList = this.GetSelectedSalesRowNoList();
            if (selectedStockRowNoList == null) return;

            // 売上明細データテーブルRowStatus列初期化処理
            this._salesSlipInputAcs.InitializeSalesDetailRowStatusColumn();

            // 売上明細データテーブルRowStatus列値設定処理
            this._salesSlipInputAcs.SettingSalesDetailRowStatus(selectedStockRowNoList, SalesSlipInputAcs.ctROWSTATUS_CUT);

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
            this._salesDetailDataTable.AcceptChanges();

            // 選択済み売上行番号リスト取得処理
            List<int> selectedSalesRowNoList = this.GetSelectedSalesRowNoList();
            if (selectedSalesRowNoList == null) return;

            // 売上明細データテーブルRowStatus列初期化処理
            this._salesSlipInputAcs.InitializeSalesDetailRowStatusColumn();

            // 売上明細データテーブルRowStatus列値設定処理
            this._salesSlipInputAcs.SettingSalesDetailRowStatus(selectedSalesRowNoList, SalesSlipInputAcs.ctROWSTATUS_COPY);

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
            this._salesDetailDataTable.AcceptChanges();

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            // コピー売上明細行番号取得処理
            List<int> copySalesRowNoList = this._salesSlipInputAcs.GetCopySalesDetailRowNo();
            if (copySalesRowNoList == null) return;

            int pasteCheck = this._salesSlipInputAcs.CheckPasteSalesDetailRow(copySalesRowNoList, rowIndex);

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
            else if (pasteCheck == 3)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "対象行数が明細最大行数を超える為、貼り付け処理を行う事ができません。",
                    0,
                    MessageBoxButtons.OK);

                return;
            }

            // 表示行数取得処理
            int prevVisibleRowCount = this.GetVisibleRowCount();

            // 売上明細行貼り付け処理
            this._salesSlipInputAcs.PasteSalesDetailRow(copySalesRowNoList, rowIndex);

            // 明細グリッドセル設定処理
            this.SettingGrid();

            // 現在庫数調整
            this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

            // 売上金額変更後発生イベントコール処理
            this.SalesPriceChangedEventCall();

            // フッタ部明細情報更新イベントコール処理
            this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

            // 車両情報設定イベントコール処理
            this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

            // 次入力可能セル移動処理
            this.MoveNextAllowEditCell(true);

            // 表示行数取得処理
            int afterVisibleRowCount = this.GetVisibleRowCount();

            //// 表示する行数が減った場合、調整する
            //if (afterVisibleRowCount < prevVisibleRowCount)
            //{
            //    for (int i = afterVisibleRowCount; i < prevVisibleRowCount; i++)
            //    {
            //        this._salesSlipInputAcs.AddSalesDetailRow();
            //    }

            //    // 明細グリッドセル設定処理
            //    this.SettingGrid();
            //}

            // セルの編集モードを一度解除し、再度編集モードに設定する
            this.CellExitEnterEditEnter();

            // 現在庫数調整
            this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

            // データ変更フラグプロパティをTrueにする
            this._salesSlipInputAcs.IsDataChanged = true;

            this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
        }

        /// <summary>
        /// ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_Guide_Click(object sender, EventArgs e)
        {
            this._salesDetailDataTable.AcceptChanges();

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            // ガイド入力チェック
            if (this.uButton_Guide.Tag == null) return;

            // 売上行番号を取得
            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;

            #region ●仕入情報設定
            this._salesSlipInputAcs.SettingStockTempInfo(salesRowNo);
            #endregion

            try
            {
                #region 販売区分
                //---------------------------------------------
                // 販売区分
                //---------------------------------------------
                if (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.SalesCodeColumn.ColumnName)
                {
                    UserGdHd userGdHd;
                    UserGdBd userGdBd;
                    int st = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, SalesSlipInputInitDataAcs.ctDIVCODE_UserGuideDivCd_SalesCode);

                    if (st == 0)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        this._salesSlipInputAcs.SettingSalesDetailRowSalesCodeInfo(salesRowNo, userGdBd.GuideCode, userGdBd.GuideName);

                        if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SalesCodeColumn.ColumnName))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }

                        this._salesSlipInputAcs.IsDataChanged = true;

                        this.MoveReturnCell();

                        return;
                    }
                }
                #endregion

                #region 倉庫
                //---------------------------------------------
                // 倉庫
                //---------------------------------------------
                if ((this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName) ||
                    (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.WarehouseNameColumn.ColumnName))
                {
                    MAZAI04117U warehouseGuide = new MAZAI04117U();
                    Stock stock;
                    DialogResult status = warehouseGuide.ShowGuide(this, this._enterpriseCode, this._salesDetailDataTable[rowIndex].GoodsNo, this._salesDetailDataTable[rowIndex].GoodsMakerCd, out stock);

                    switch (status)
                    {
                        case DialogResult.OK:
                            if (stock != null)
                            {
                                // --- ADD 2010/05/20 ---------->>>>>
                                if (!string.IsNullOrEmpty(stock.SectionCode) && !string.IsNullOrEmpty(LoginInfoAcquisition.Employee.BelongSectionCode))
                                {
                                    if (!stock.SectionCode.Trim().Equals(LoginInfoAcquisition.Employee.BelongSectionCode.Trim()))
                                    {
                                        // 入力倉庫チェック区分 0:無視 1:再入力 2:警告
                                        switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().InpWarehChkDiv)
                                        {
                                            case 0:
                                                break;
                                            case 1:
                                                {
                                                    TMsgDisp.Show(
                                                    this,
                                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                    this.Name,
                                                    "不正な値が存在するため、登録できません。"
                                                    + "\r\n"
                                                    + "\r\n"
                                                    + this.GetActiveRowSalesRowNo()
                                                    + "行目の在庫管理拠点とログイン拠点が不一致です。",
                                                    0,
                                                    MessageBoxButtons.OK);
                                                    return;
                                                }
                                            case 2:
                                                {
                                                    TMsgDisp.Show(
                                                    this,
                                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                    this.Name,
                                                    "在庫管理拠点とログイン拠点が不一致です。",
                                                    0,
                                                    MessageBoxButtons.OK);

                                                    break;
                                                }
                                        }
                                    }
                                }
                                // --- ADD 2010/05/20 ----------<<<<<
                            }
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                            // 現在庫数調整処理
                            this._salesSlipInputAcs.SalesDetailStockInfoAdjust(uiSetControl1.GetZeroPaddedText(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName, this._salesDetailDataTable[rowIndex].WarehouseCode.Trim()), this._salesDetailDataTable[rowIndex].GoodsNo, this._salesDetailDataTable[rowIndex].GoodsMakerCd);

                            // 在庫情報設定処理
                            this._salesSlipInputAcs.SettingSalesDetailStockInfo(salesRowNo, stock);

                            // ActiveCellが倉庫コードの場合
                            if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.WarehouseCodeColumn.ColumnName))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            }

                            // 明細グリッド設定処理
                            this.SettingGridRow(rowIndex, this._salesSlipInputAcs.SalesSlip);

                            // データ変更フラグプロパティをTrueにする
                            this._salesSlipInputAcs.IsDataChanged = true;

                            this.MoveReturnCell();

                            return;
                        default:
                            break;
                    }
                }
                #endregion

                #region BLコード
                //---------------------------------------------
                // BLコード
                //---------------------------------------------
                else if ((this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName) ||
                   (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.BLGoodsFullNameColumn.ColumnName))
                {

                    if ((this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch) ||
                        (this._salesSlipInputAcs.GetSearchPartsMode(salesRowNo) != SalesSlipInputAcs.SearchPartsModeState.NonSearch))
                    {
                        BLGoodsCdAcs blGoodsCdAcs = new BLGoodsCdAcs();
                        BLGoodsCdUMnt blGoodsCdUMnt;

                        int status = blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                            // BLコード関連情報設定
                            this._salesSlipInputAcs.SettingSalesDetailBLGoodsInfo(salesRowNo, blGoodsCdUMnt);

                            // ActiveCellがBLコードの場合
                            if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            }

                            // データ変更フラグプロパティをTrueにする
                            this._salesSlipInputAcs.IsDataChanged = true;

                            this.MoveReturnCell();

                            return;
                        }
                    }
                    else
                    {
                        List<BLGoodsCdUMnt> bLGoodsCdUMntList;

                        // BLコードガイド起動
                        int status = this.ExecuteBLGoodsCd(out bLGoodsCdUMntList, salesRowNo);

                        if (status == -3)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "車輌情報が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                            // BLコードガイド情報設定
                            this._salesSlipInputInitDataAcs.SettingBLGoodsInfo(ref bLGoodsCdUMntList);

                            int settingRowCnt = 0;
                            foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLGoodsCdUMntList)
                            {
                                int blCode = bLGoodsCdUMnt.BLGoodsCode;

                                //-----------------------------------------------------------------------------
                                // BLコード検索
                                //-----------------------------------------------------------------------------
                                List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                                List<Stock> stockList = new List<Stock>();

                                object retObj;

                                //>>>2010/03/31
                                //// --- ADD 2010/01/27 -------------->>>>>
                                //if (this.CheckRowEffective(rowIndex)) return;
                                //// --- ADD 2010/01/27 --------------<<<<<
                                if (this.CheckRowEffective(rowIndex + settingRowCnt)) return;
                                //<<<2010/03/31

                                switch (this.SearchPartsFromBLCode(salesRowNo, blCode, out retObj))
                                {
                                    case 0:
                                        {
                                            if (retObj != null)
                                            {
                                                // BLコード検索
                                                if (retObj is ArrayList)
                                                {
                                                    ArrayList retList = (ArrayList)retObj;

                                                    for (int cnt = 0; cnt < retList.Count; cnt++)
                                                    {
                                                        // 通常商品情報
                                                        if (retList[cnt] is GoodsUnitData)
                                                        {
                                                            goodsUnitDataList.Clear();
                                                            goodsUnitDataList.Add((GoodsUnitData)retList[cnt]);

                                                            // 商品情報設定処理
                                                            List<int> settingSalesRowNoList;
                                                            // 2009/11/25 >>>
                                                            //this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(this.GetActiveRowSalesRowNo(), salesRowNo + settingRowCnt, goodsUnitDataList, stockList, out settingSalesRowNoList, true, false);
                                                            this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(this.GetActiveRowSalesRowNo(), salesRowNo + settingRowCnt, goodsUnitDataList, stockList, out settingSalesRowNoList, true, false, blCode);
                                                            // 2009/11/25 <<<
                                                            settingRowCnt += settingSalesRowNoList.Count;

                                                            foreach (int rowNo in settingSalesRowNoList)
                                                            {
                                                                // 売上金額計算処理
                                                                this._salesSlipInputAcs.CalculationSalesMoney(rowNo - 1);

                                                                // 原価金額計算処理
                                                                this._salesSlipInputAcs.CalculationCost(rowNo - 1);

                                                                // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                                                if (((GoodsUnitData)retList[cnt]).SelectedListPriceDiv == 1)
                                                                {
                                                                    double tempReturnListPrice = ((GoodsUnitData)retList[cnt]).SelectedListPrice;
                                                                    this._salesDetailDataTable[rowNo - 1].ListPriceDisplay = (double)tempReturnListPrice;
                                                                    // 売上明細データセッティング処理（定価設定）
                                                                    this._salesSlipInputAcs.SalesDetailRowListPriceSetting(rowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowNo - 1].ListPriceDisplay);

                                                                    // 売価率が入力されている場合は単価再計算
                                                                    if (this._salesDetailDataTable[rowNo - 1].SalesRate != 0)
                                                                    {
                                                                        // 売上明細データセッティング処理（単価設定）
                                                                        this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSettingbyRate(rowNo, this._salesDetailDataTable[rowNo - 1].SalesRate, false);

                                                                        // 売上金額計算処理
                                                                        this._salesSlipInputAcs.CalculationSalesMoney(rowNo - 1);
                                                                    }
                                                                    else
                                                                    {
                                                                        // 2010/01/14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                                                        //if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1) // 売価＝定価
                                                                        //{
                                                                        //    this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSetting(rowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPrice, this._salesDetailDataTable[rowNo - 1].ListPriceDisplay, 0);
                                                                        //}

                                                                        if (string.IsNullOrEmpty(this._salesDetailDataTable[rowNo - 1].RateDivSalUnPrc))
                                                                        {
                                                                        if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1) // 売価＝定価
                                                                        {
                                                                            this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSetting(rowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPrice, this._salesDetailDataTable[rowNo - 1].ListPriceDisplay, 0);
                                                                        }
                                                                    }
                                                                        // 2010/01/14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                                                    }
                                                                    this._salesDetailDataTable[rowNo - 1].PrtGoodsNo = ((GoodsUnitData)retList[cnt]).PrtGoodsNo;
                                                                    this._salesDetailDataTable[rowNo - 1].PrtMakerCode = ((GoodsUnitData)retList[cnt]).PrtMakerCode;
                                                                    this._salesDetailDataTable[rowNo - 1].PrtMakerName = ((GoodsUnitData)retList[cnt]).PrtMakerName;
                                                                }

                                                                this._salesDetailDataTable[rowNo - 1].SelectedGoodsNoDiv = ((GoodsUnitData)retList[cnt]).SelectedGoodsNoDiv;
                                                                // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                                                // 明細粗利率設定処理
                                                                this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(rowNo);

                                                                // 一式情報設定処理
                                                                this._salesSlipInputAcs.ConstructionCompleteInfo(rowNo);

                                                                // 車両情報設定イベントコール処理
                                                                this.SettingCarInfoEventCall(rowNo);
                                                            }
                                                        }
                                                        // 受注照会(受注残検索)
                                                        else if (retList[cnt] is AcptAnOdrRemainRefData)
                                                        {
                                                            List<AcptAnOdrRemainRefData> acptAnOdrRemainRefDataList = new List<AcptAnOdrRemainRefData>();
                                                            acptAnOdrRemainRefDataList.Add((AcptAnOdrRemainRefData)retList[cnt]);
                                                            int st = this._salesSlipInputAcs.SalesDetailRowSettingFromAcptAnOdrRemainRefList(salesRowNo + cnt, acptAnOdrRemainRefDataList, SalesSlipInputAcs.WayToDetailExpand.AddUpRemainder);
                                                            if (st == -1)
                                                            {
                                                                TMsgDisp.Show(
                                                                    this,
                                                                    emErrorLevel.ERR_LEVEL_INFO,
                                                                    this.Name,
                                                                    "「計上」または「発注選択」済み明細がが選択されましたので、" + Environment.NewLine +
                                                                    "明細への展開を行いません。",
                                                                    -1,
                                                                    MessageBoxButtons.OK);
                                                            }
                                                        }
                                                        // 出荷照会(出荷残検索)
                                                        else if (retList[cnt] is SalHisRefResultParamWork)
                                                        {
                                                            List<SalHisRefResultParamWork> salHisRefResultParamWorkList = new List<SalHisRefResultParamWork>();
                                                            salHisRefResultParamWorkList.Add((SalHisRefResultParamWork)retList[cnt]);
                                                            int st = this._salesSlipInputAcs.SalesDetailRowSettingFromSalHisRefResultParamWorkListForAddUp(salesRowNo + cnt, salHisRefResultParamWorkList, SalesSlipInputAcs.WayToDetailExpand.AddUpRemainder);
                                                            if (st == -1)
                                                            {
                                                                TMsgDisp.Show(
                                                                    this,
                                                                    emErrorLevel.ERR_LEVEL_INFO,
                                                                    this.Name,
                                                                    "「計上」済み明細が選択されましたので、" + Environment.NewLine +
                                                                    "明細への展開を行いません。",
                                                                    -1,
                                                                    MessageBoxButtons.OK);
                                                            }
                                                        }

                                                        if (this._salesInputConstructionAcs.DataInputCountValue <= settingRowCnt) break;
                                                    }
                                                }

                                                // 明細グリッド設定処理
                                                this.SettingGrid();

                                                // データ変更フラグプロパティをTrueにする
                                                this._salesSlipInputAcs.IsDataChanged = true;

                                                // 売上金額変更後発生イベントコール処理
                                                this.SalesPriceChangedEventCall();

                                                // フッタ部明細情報更新イベントコール処理
                                                this.SettingFooterEventCall(salesRowNo);

                                                // ActiveCellがBLコードの場合
                                                if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName))
                                                {
                                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                                }

                                                if (this._salesInputConstructionAcs.DataInputCountValue <= settingRowCnt) break;

                                            }

                                            break;
                                        }
                                    case -1:
                                        {
                                            //// 商品コードを元に戻す
                                            //this._salesDetailDataTable[cell.Row.Index].GoodsNo = this._beforeGoodsNo;

                                            //this._cannotGoodsRead = true;
                                            //return;
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
                                            return;
                                        }
                                }

                                if (this._salesInputConstructionAcs.DataInputCountValue <= settingRowCnt)
                                {
                                    //TMsgDisp.Show(
                                    //    this,
                                    //    emErrorLevel.ERR_LEVEL_INFO,
                                    //    this.Name,
                                    //    "選択数が明細行数を超える為、検索を終了します。　",
                                    //    -1,
                                    //    MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            // ActiveCellがBLコードの場合
                            if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                }
                #endregion

                #region メーカーコード
                //---------------------------------------------
                // メーカーコード
                //---------------------------------------------
                else if ((this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName) ||
                   (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.MakerNameColumn.ColumnName))
                {
                    MakerAcs makerAcs = new MakerAcs();
                    makerAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
                    MakerUMnt makerUMnt;

                    int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        // メーカー名称設定処理
                        //>>>2010/07/21
                        //bool makerChanged = this._salesSlipInputAcs.SettingSalesDetailMakerInfo(salesRowNo, makerUMnt.GoodsMakerCd, makerUMnt.MakerName);
                        bool makerChanged = this._salesSlipInputAcs.SettingSalesDetailMakerInfo(salesRowNo, makerUMnt.GoodsMakerCd, makerUMnt.MakerName, makerUMnt.MakerKanaName);
                        //<<<2010/07/21

                        // ActiveCellがメーカーコードの場合
                        if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }

                        string goodsNo = this._salesDetailDataTable[rowIndex].GoodsNo;
                        // メーカーが変わった場合は商品を再検索
                        if ((makerChanged) && (!string.IsNullOrEmpty(goodsNo)))
                        {
                            if (!String.IsNullOrEmpty(goodsNo))
                            {
                                switch (this.SearchGoodsAndRemain_And_RowSetting(rowIndex))
                                {
                                    case 0:
                                        break;
                                    case -1:
                                        //this._salesSlipInputAcs.SettingSalesDetailMakerInfo(salesRowNo, this._beforeGoodsMakerCd, beforeMakerName);
                                        break;
                                }
                                // 売上金額計算処理
                                this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                                // 原価金額計算処理
                                this._salesSlipInputAcs.CalculationCost(rowIndex);

                                // 明細粗利率設定処理
                                this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                                // 一式情報設定処理
                                this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);

                                // 車両情報設定イベントコール処理
                                this.SettingCarInfoEventCall(salesRowNo);

                                // 発注情報設定処理
                                this._salesSlipInputAcs.SettingUOEOrderDtlRowForNew(salesRowNo);

                                // 現在庫数調整
                                this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

                                // 明細グリッド設定処理
                                this.SettingGrid();

                                // データ変更フラグプロパティをTrueにする
                                this._salesSlipInputAcs.IsDataChanged = true;

                                // 売上金額変更後発生イベントコール処理
                                this.SalesPriceChangedEventCall();

                                // フッタ部明細情報更新イベントコール処理
                                this.SettingFooterEventCall(salesRowNo);
                            }
                        }

                        // データ変更フラグプロパティをTrueにする
                        this._salesSlipInputAcs.IsDataChanged = true;

                        this.MoveReturnCell();

                        return;
                    }
                }
                #endregion

                #region 仕入先
                //---------------------------------------------
                // 仕入先
                //---------------------------------------------
                else if ((this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                    (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName))
                {
                    SupplierAcs supplierAcs = new SupplierAcs();
                    Supplier supplier;
                    supplierAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
                    supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);

                    SalesInputDataSet.SalesDetailRow row = this._salesSlipInputAcs.GetSalesDetailRow(salesRowNo);
                    if ((row != null) && (row.SupplierCd != supplier.SupplierCd))
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        // 仕入先情報設定
                        this._salesSlipInputAcs.SettingSalesDetailSupplierInfo(salesRowNo, supplier);

                        StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();
                            
                        // 仕入先情報設定(仕入情報)
                        this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplier(ref stockTemp, supplier);

                        // 発注先情報設定(発注情報)
                        UOESupplier uoeSupplier;
                        //>>>2010/07/01
                        //int st = this._uoeSupplierAcs.Read(out uoeSupplier, this._enterpriseCode, supplier.SupplierCd, this._salesSlipInputAcs.SalesSlip.SectionCode);
                        int st = this._uoeSupplierAcs.ReadCache(out uoeSupplier, this._enterpriseCode, supplier.SupplierCd, this._salesSlipInputAcs.SalesSlip.SectionCode);
                        //<<<2010/07/01
                        if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);
                            this._salesSlipInputAcs.SettingSalesDetailRowUOEOrderDtl(salesRowNo);
                        }

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
                            // 価格情報再設定
                            this._salesSlipInputAcs.SalesDetailRowGoodsPriceReSetting(salesRowNo);

                            // 売上金額計算処理
                            this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                            // 原価金額計算処理
                            this._salesSlipInputAcs.CalculationCost(rowIndex);

                            // 明細粗利率設定処理
                            this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                            // 一式情報設定処理
                            this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);

                            // 単価再計算有り(掛率から一括取得)
                            this._salesSlipStockInfoInputAcs.CalclationUnitPrice(ref stockTemp);

                            // 仕入金額再計算
                            this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);

                            // メモリ上の内容と比較する
                            this._salesSlipStockInfoInputAcs.Cache(stockTemp);

                            // 売上金額変更後発生イベントコール処理
                            this.SalesPriceChangedEventCall();
                        }
                        else
                        {
                            this._salesSlipInputAcs.ClearRateInfo(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                            this._salesSlipInputAcs.ClearRateInfo(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                            this._salesSlipInputAcs.ClearRateInfo(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                        }

                        if ((this.uGrid_Details.ActiveCell != null) &&
                            ((this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SupplierCdColumn.ColumnName) ||
                             (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName)))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }

                        this.SettingGridRow(rowIndex, this._salesSlipInputAcs.SalesSlip);

                        this._salesSlipInputAcs.IsDataChanged = true;

                        this.MoveReturnCell();

                        return;

                    }
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                #endregion

                #region 売単価
                //---------------------------------------------
                // 売単価
                //---------------------------------------------
                else if (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName)
                {
                    DCKHN01050UA unitPriceInfoGuide = new DCKHN01050UA();

                    UnPrcInfoConf unPrcInfoConf = this._salesSlipInputAcs.GetUnitPriceInfoConf(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                    if ((unPrcInfoConf.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(unPrcInfoConf.GoodsNo)))// メーカー・品番未入力時は、表示なし
                    {
                        DialogResult dialogResult = unitPriceInfoGuide.ShowDialog(this, DCKHN01050UA.DisplayType.SalesUnitPrice, unPrcInfoConf);

                        if (dialogResult == DialogResult.OK)
                        {
                            //this._salesSlipInputAcs.SalesDetailRowUnPrcInfoSetting(salesRowNo, unitPriceInfoGuide.UnPrcInfoConfRet, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);

                            //// 売上金額計算処理
                            //this.CalculationSalesPrice();

                            //// 一式情報設定処理
                            //this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);

                            //// 売上金額変更後発生イベントコール処理
                            //this.SalesPriceChangedEventCall();

                            //// フッタ部明細情報更新イベントコール処理
                            //this.SettingFooterEventCall(salesRowNo);

                            //// 車両情報設定イベントコール処理
                            //this.SettingCarInfoEventCall(salesRowNo);

                            //this._salesSlipInputAcs.IsDataChanged = true;
                        }

                        // ActiveCellが単価の場合
                        if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "商品番号およびメーカーが入力されていない為、" + "\r\n" +
                            "単価情報画面を表示できません。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                }
                #endregion

                #region 原単価
                //---------------------------------------------
                // 原単価
                //---------------------------------------------
                else if (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName)
                {
                    DCKHN01050UA unitPriceInfoGuide = new DCKHN01050UA();

                    UnPrcInfoConf unPrcInfoConf = this._salesSlipInputAcs.GetUnitPriceInfoConf(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                    if ((unPrcInfoConf.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(unPrcInfoConf.GoodsNo)))// メーカー・品番未入力時は、表示なし
                    {
                        DialogResult dialogResult = unitPriceInfoGuide.ShowDialog(this, DCKHN01050UA.DisplayType.UnitCost, unPrcInfoConf);

                        if (dialogResult == DialogResult.OK)
                        {
                            //this._salesSlipInputAcs.SalesDetailRowUnPrcInfoSetting(salesRowNo, unitPriceInfoGuide.UnPrcInfoConfRet, UnitPriceCalculation.ctUnitPriceKind_UnitCost);

                            //// 原価金額計算処理
                            //this._salesSlipInputAcs.CalculationCost(rowIndex);

                            //// 明細粗利率設定処理
                            //this._salesSlipInputAcs.SettingGrossProfitRate(salesRowNo);

                            //// 一式情報設定処理
                            //this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);

                            //// 売上金額変更後発生イベントコール処理
                            //this.SalesPriceChangedEventCall();

                            //// フッタ部明細情報更新イベントコール処理
                            //this.SettingFooterEventCall(salesRowNo);

                            //// 車両情報設定イベントコール処理
                            //this.SettingCarInfoEventCall(salesRowNo);

                            //this._salesSlipInputAcs.IsDataChanged = true;
                        }

                        // ActiveCellが単価の場合
                        if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SalesUnitCostColumn.ColumnName))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "商品番号およびメーカーが入力されていない為、" + "\r\n" +
                            "単価情報画面を表示できません。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                }
                #endregion

                #region 定価
                //---------------------------------------------
                // 定価
                //---------------------------------------------
                else if (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName)
                {
                    DCKHN01050UA unitPriceInfoGuide = new DCKHN01050UA();

                    UnPrcInfoConf unPrcInfoConf = this._salesSlipInputAcs.GetUnitPriceInfoConf(salesRowNo, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                    if ((unPrcInfoConf.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(unPrcInfoConf.GoodsNo)))// メーカー・品番未入力時は、表示なし
                    {
                        DialogResult dialogResult = unitPriceInfoGuide.ShowDialog(this, DCKHN01050UA.DisplayType.ListPrice, unPrcInfoConf);

                        if (dialogResult == DialogResult.OK)
                        {
                            //this._salesSlipInputAcs.SalesDetailRowUnPrcInfoSetting(salesRowNo, unitPriceInfoGuide.UnPrcInfoConfRet, UnitPriceCalculation.ctUnitPriceKind_ListPrice);

                            //// 売上明細データセッティング処理（定価設定）
                            //this._salesSlipInputAcs.SalesDetailRowListPriceSetting(salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, this._salesDetailDataTable[rowIndex].ListPriceDisplay);

                            //// 売価率が入力されている場合は単価再計算
                            //if (this._salesDetailDataTable[rowIndex].SalesRate != 0)
                            //{
                            //    // 売上明細データセッティング処理（単価設定）
                            //    this._salesSlipInputAcs.SalesDetailRowSalesUnitPriceSettingbyRate(salesRowNo, this._salesDetailDataTable[rowIndex].SalesRate);

                            //    // 売上金額計算処理
                            //    this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                            //    // 一式情報設定処理
                            //    this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
                            //}
                            //// 原価率が入力されている場合は単価再計算
                            //if (this._salesDetailDataTable[rowIndex].CostRate != 0)
                            //{
                            //    // 売上明細データセッティング処理（原単価設定）
                            //    this._salesSlipInputAcs.SalesDetailRowSalesUnitCostSettingbyRate(salesRowNo, this._salesDetailDataTable[rowIndex].CostRate);

                            //    // 原価金額計算処理
                            //    this._salesSlipInputAcs.CalculationCost(rowIndex);

                            //    // 明細粗利率設定処理
                            //    this._salesSlipInputAcs.SettingGrossProfitRate(salesRowNo);

                            //    // 一式情報設定処理
                            //    this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);
                            //}

                            //// 売上金額変更後発生イベントコール処理
                            //this.SalesPriceChangedEventCall();

                            //// フッタ部明細情報更新イベントコール処理
                            //this.SettingFooterEventCall(salesRowNo);

                            //// 車両情報設定イベントコール処理
                            //this.SettingCarInfoEventCall(salesRowNo);

                            //this._salesSlipInputAcs.IsDataChanged = true;
                        }

                        // ActiveCellが単価の場合
                        if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "商品番号およびメーカーが入力されていない為、" + "\r\n" +
                            "単価情報画面を表示できません。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                }
                #endregion

                #region BO区分
                if (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.BoCodeColumn.ColumnName)
                {
                    UOEGuideName uoeGuideName;
                    UOEGuideName inUOEGuideName = new UOEGuideName();
                    inUOEGuideName.EnterpriseCode = this._enterpriseCode;
                    inUOEGuideName.SectionCode = this._salesSlipInputAcs.SalesSlip.SectionCode;
                    inUOEGuideName.UOESupplierCd = this._salesDetailDataTable[rowIndex].SupplierCdForOrder;
                    inUOEGuideName.UOEGuideDivCd = (int)SalesSlipInputAcs.UOEGuideDivCd.BoCode;
                    int st = this._uoeGuideNameAcs.ExecuteGuid(inUOEGuideName, out uoeGuideName);

                    if (st == 0)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        StockTemp stockTemp = this._salesSlipStockInfoInputAcs.StockTemp.Clone();

                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromBoCode(salesRowNo, uoeGuideName.UOEGuideCode);
                        this._salesSlipStockInfoInputAcs.SettingStockTempFromSupplierFormal(ref stockTemp, (int)SalesSlipStockInfoInputAcs.SupplierFormal.Order); // 仕入形式設定(発注)

                        // --- ADD 2010/05/20 ---------->>>>>
                        this._salesSlipStockInfoInputAcs.SettingStockTempFromPartySalesSilpNum(ref stockTemp, SalesSlipStockInfoInputAcs.ctDummyPartySalesSilpNum);
                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromAcceptAnOrderCnt(salesRowNo); // 発注数設定 
                        // --- ADD 2010/05/20 ----------<<<<<

                        this._salesSlipStockInfoInputAcs.Cache(stockTemp);
                        this._salesSlipInputAcs.SettingSalesDetailRowUOEOrderDtl(salesRowNo);

                        if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.BoCodeColumn.ColumnName))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                        // --- UPD 2010/05/20 ---------->>>>>
                        //this.SettingGridRow(rowIndex, this._salesSlipInputAcs.SalesSlip);
                        int rowEffectiveIndex = SettingGridRowFromInputChange();
                        // --- UPD 2010/05/20 ----------<<<<<

                        this._salesSlipInputAcs.IsDataChanged = true;

                        this.MoveReturnCell();

                        return;
                    }
                }
                #endregion

                #region 発注先
                if (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName)
                {
                    UOESupplier uoeSupplier;
                    int st = this._uoeSupplierAcs.ExecuteGuid(this._enterpriseCode, this._salesSlipInputAcs.SalesSlip.SectionCode, out uoeSupplier);
                    if (st == 0)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        if (!this._salesSlipInputAcs.ExistSalesDetailEnableOdrMakerCd(salesRowNo, uoeSupplier.UOESupplierCd)) // 発注可能メーカーチェック
                        {
                            int makerCode = this._salesSlipInputAcs.SalesDetailDataTable[rowIndex].GoodsMakerCd;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "発注先コード [" + uoeSupplier.UOESupplierCd.ToString() + "] の発注可能メーカーに  " + Environment.NewLine + Environment.NewLine + "メーカーコード [" + makerCode.ToString() + "] が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        else
                        {
                            this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);
                            this._salesSlipInputAcs.SettingSalesDetailRowUOEOrderDtl(salesRowNo);

                            if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            }

                            this._salesSlipInputAcs.IsDataChanged = true;

                            this.SettingGridRow(rowIndex, this._salesSlipInputAcs.SalesSlip);

                            this.MoveReturnCell();
                        }

                        return;
                    }
                }
                #endregion

                #region 納品区分
                if (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName)
                {
                    UOEGuideName uoeGuideName;
                    UOEGuideName inUOEGuideName = new UOEGuideName();
                    inUOEGuideName.EnterpriseCode = this._enterpriseCode;
                    inUOEGuideName.SectionCode = this._salesSlipInputAcs.SalesSlip.SectionCode;
                    inUOEGuideName.UOESupplierCd = this._salesDetailDataTable[rowIndex].SupplierCdForOrder;
                    inUOEGuideName.UOEGuideDivCd = (int)SalesSlipInputAcs.UOEGuideDivCd.DeliveredGoodsDiv;
                    int st = this._uoeGuideNameAcs.ExecuteGuid(inUOEGuideName, out uoeGuideName);

                    if (st == 0)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOEDeliGoodsDiv(salesRowNo, uoeGuideName.UOEGuideCode, uoeGuideName.UOEGuideNm);
                        this._salesSlipInputAcs.SettingSalesDetailRowUOEOrderDtl(salesRowNo);
                        this._salesSlipInputAcs.SettingSalesDetailRowDeliveredGoodsDivNm(salesRowNo);

                        if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }

                        this._salesSlipInputAcs.IsDataChanged = true;

                        this.MoveReturnCell();

                        return;
                    }
                }
                #endregion

                #region H納品区分
                if (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName)
                {
                    UOEGuideName uoeGuideName;
                    UOEGuideName inUOEGuideName = new UOEGuideName();
                    inUOEGuideName.EnterpriseCode = this._enterpriseCode;
                    inUOEGuideName.SectionCode = this._salesSlipInputAcs.SalesSlip.SectionCode;
                    inUOEGuideName.UOESupplierCd = this._salesDetailDataTable[rowIndex].SupplierCdForOrder;
                    inUOEGuideName.UOEGuideDivCd = (int)SalesSlipInputAcs.UOEGuideDivCd.DeliveredGoodsDiv;
                    int st = this._uoeGuideNameAcs.ExecuteGuid(inUOEGuideName, out uoeGuideName);

                    if (st == 0)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromFollowDeliGoodsDiv(salesRowNo, uoeGuideName.UOEGuideCode, uoeGuideName.UOEGuideNm);
                        this._salesSlipInputAcs.SettingSalesDetailRowUOEOrderDtl(salesRowNo);
                        this._salesSlipInputAcs.SettingSalesDetailRowFollowDeliGoodsDivNm(salesRowNo);

                        if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }

                        this._salesSlipInputAcs.IsDataChanged = true;

                        this.MoveReturnCell();

                        return;
                    }
                }
                #endregion

                #region 指定拠点
                if (this.uButton_Guide.Tag.ToString() == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName)
                {
                    UOEGuideName uoeGuideName;
                    UOEGuideName inUOEGuideName = new UOEGuideName();
                    inUOEGuideName.EnterpriseCode = this._enterpriseCode;
                    inUOEGuideName.SectionCode = this._salesSlipInputAcs.SalesSlip.SectionCode;
                    inUOEGuideName.UOESupplierCd = this._salesDetailDataTable[rowIndex].SupplierCdForOrder;
                    inUOEGuideName.UOEGuideDivCd = (int)SalesSlipInputAcs.UOEGuideDivCd.UOEResvdSection;
                    int st = this._uoeGuideNameAcs.ExecuteGuid(inUOEGuideName, out uoeGuideName);

                    if (st == 0)
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);

                        this._salesSlipInputAcs.SettingUOEOrderDtlRowFromUOEResvdSection(salesRowNo, uoeGuideName.UOEGuideCode, uoeGuideName.UOEGuideNm);
                        this._salesSlipInputAcs.SettingSalesDetailRowUOEOrderDtl(salesRowNo);
                        this._salesSlipInputAcs.SettingSalesDetailRowUOEResvdSectionNm(salesRowNo);

                        if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.Key == this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName))
                        {
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }

                        this._salesSlipInputAcs.IsDataChanged = true;

                        this.MoveReturnCell();

                        return;
                    }
                }
                #endregion

            }
            finally
            {
                // セルアクティブ時ボタン有効無効コントロール処理
                this.ActiveCellButtonEnabledControl(rowIndex, this.uGrid_Details.ActiveCell.Column.Key);

                this._salesSlipInputAcs.SalesDetailDataTable.AcceptChanges();
            }

        }

        /// <summary>
        /// BLコードガイド起動処理
        /// </summary>
        /// <param name="bLGoodsCdUMntList"></param>
        /// <param name="salesRowNo"></param>
        /// <returns></returns>
        private int ExecuteBLGoodsCd(out List<BLGoodsCdUMnt> bLGoodsCdUMntList, int salesRowNo)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
            //return this._salesSlipInputAcs.ExecuteBLGoodsCd( out bLGoodsCdUMntList, salesRowNo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            return this._salesSlipInputAcs.ExecuteBLGoodsCd( out bLGoodsCdUMntList, salesRowNo, this.GetBLGuideMode( _salesInputConstructionAcs.SalesInputConstruction.BLGuideMode ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
        /// <summary>
        /// BLガイドモード取得
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        private GoodsAcs.BLGuideMode GetBLGuideMode( int mode )
        {
            try
            {
                return (GoodsAcs.BLGuideMode)mode;
            }
            catch
            {
                return GoodsAcs.BLGuideMode.BLCode;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD

        /// <summary>
        /// 仕入先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void SupplierSearchForm_SupplierSelect(Supplier supplier)
        {
            if (supplier == null) return;
            int rowIndex = this.GetActiveRowIndex();
            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;

            // 仕入先情報設定
            Supplier supplierTemp = new Supplier();
            supplierTemp.SupplierCd = supplier.SupplierCd;
            supplierTemp.SupplierSnm = supplier.SupplierSnm;

            _salesSlipInputAcs.SettingSalesDetailSupplierInfo(salesRowNo, supplierTemp);
        }

        /// <summary>
        /// 在庫検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_StockSearch_Click(object sender, EventArgs e)
        {
            this._salesDetailDataTable.AcceptChanges();

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            // 売上行番号を取得
            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;

            // メーカーコード／商品コードを取得
            string goodsCode = this._salesDetailDataTable[rowIndex].GoodsNo;
            int makerCode = this._salesDetailDataTable[rowIndex].GoodsMakerCd;

            // 在庫検索ガイドを起動
            object retObj;
            StockSearchGuide stockSearchGuide = new StockSearchGuide();
            stockSearchGuide.IsMultiSelect = true;
            StockSearchPara para = new StockSearchPara();
            para.EnterpriseCode = this._enterpriseCode;
            para.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.14 DEL
            //DialogResult dialogResult = stockSearchGuide.ShowGuide(this, StockSearchGuide.emSearchMode.GoodsStock, true, para, out retObj);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.14 ADD
            DialogResult dialogResult = stockSearchGuide.ShowGuide(this, StockSearchGuide.emSearchMode.GoodsStock, false, para, out retObj);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.14 ADD

            if (dialogResult == DialogResult.OK)
            {
                #region 明細へデータ展開
                List<Stock> stockList = retObj as List<Stock>;

                if ((stockList != null) && (stockList.Count > 0))
                {
                    List<int> makerCodeList = new List<int>();
                    List<string> goodsCodeList = new List<string>();
                    List<GoodsUnitData> goodsUnitDataList;
                    List<List<GoodsUnitData>> goodsUnitDataListList;
                    string msg;

                    foreach (Stock ret in stockList)
                    {
                        makerCodeList.Add(ret.GoodsMakerCd);
                        goodsCodeList.Add(ret.GoodsNo);
                    }

                    this._salesSlipInputAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(this._salesSlipInputAcs.SalesSlip, makerCodeList, goodsCodeList, out goodsUnitDataListList, out msg);
                    this._salesSlipInputInitDataAcs.GetGoodsUnitDataListFromListList(goodsUnitDataListList, out goodsUnitDataList);

                    // 商品マスタ情報設定処理
                    List<int> settingSalesRowNoList;
                    int activeSalesRowNo = this.GetActiveRowSalesRowNo();
                    this._salesSlipInputAcs.SalesDetailRowGoodsSetting_StockBase(this.GetActiveRowSalesRowNo(), activeSalesRowNo, goodsUnitDataList, stockList, out settingSalesRowNoList, true, false);

                    // 明細グリッド設定処理
                    this.SettingGrid();

                    foreach (int rowNo in settingSalesRowNoList)
                    {
                        // 売上金額計算処理
                        this._salesSlipInputAcs.CalculationSalesMoney(rowNo - 1);

                        // 原価金額計算処理
                        this._salesSlipInputAcs.CalculationCost(rowNo - 1);

                        // 明細粗利率設定処理
                        this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(rowNo);

                        // 一式情報設定処理
                        this._salesSlipInputAcs.ConstructionCompleteInfo(rowNo);

                        // 車両情報設定イベントコール処理
                        this.SettingCarInfoEventCall(rowNo);
                    }

                    // 現在庫数調整
                    this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

                    //// 最終行に商品名称が設定されている場合は１行追加
                    //if (!string.IsNullOrEmpty(this._salesDetailDataTable[this._salesDetailDataTable.Count - 1].GoodsName))
                    //{
                    //    this._salesSlipInputAcs.AddSalesDetailRow();

                    //    // 表示用行番号調整処理
                    //    this._salesSlipInputAcs.AdjustRowNo();

                    //    // 明細グリッド・行単位でのセル設定
                    //    this.SettingGridRow(rowIndex + 1, this._salesSlipInputAcs.SalesSlip);
                    //}

                    // 売上金額変更後発生イベントコール処理
                    this.SalesPriceChangedEventCall();

                    // フッタ部明細情報更新イベントコール処理
                    this.SettingFooterEventCall(salesRowNo);

                    // データ変更フラグプロパティをTrueにする
                    this._salesSlipInputAcs.IsDataChanged = true;
                }
                #endregion

                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// 売上履歴ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SalesReference_Click(object sender, EventArgs e)
        {
            this._salesDetailDataTable.AcceptChanges();

            // 得意先入力チェック処理
            bool customerCodeCheck = this.CheckCustomerCodeInput();
            if (!customerCodeCheck) return;

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            List<SalHisRefResultParamWork> salHisRefResultParamWorkList;
            DCHNB04101UA salesHisGuide = new DCHNB04101UA();
            salesHisGuide.AcptAnOdrStatus = (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales;
            salesHisGuide.AutoSearch = true;
            salesHisGuide.MaxSelectCount = this._salesInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            salesHisGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
            salesHisGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
            salesHisGuide.CustomerCodeFix = true;
            salesHisGuide.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
            salesHisGuide.CustomerName = this._salesSlipInputAcs.SalesSlip.CustomerSnm;
            salesHisGuide.SalesEmployeeCd = this._salesSlipInputAcs.SalesSlip.SalesEmployeeCd;
            salesHisGuide.SalesEmployeeName = this._salesSlipInputAcs.SalesSlip.SalesEmployeeNm;
            salesHisGuide.SalesInputCode = this._salesSlipInputAcs.SalesSlip.SalesInputCode;
            salesHisGuide.SalesInputName = this._salesSlipInputAcs.SalesSlip.SalesInputName;
            salesHisGuide.FrontEmployeeCd = this._salesSlipInputAcs.SalesSlip.FrontEmployeeCd;
            salesHisGuide.FrontEmployeeName = this._salesSlipInputAcs.SalesSlip.FrontEmployeeNm;

            DialogResult dialogResult = salesHisGuide.ShowDialog(this, (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales, this._salesSlipInputAcs.SalesSlip.CustomerCode);
            int retSt = 0;

            if (dialogResult == DialogResult.OK)
            {
                #region 明細へのデータ展開
                salHisRefResultParamWorkList = salesHisGuide.StcHisRefDataWork;
                int lastInputSalesRow = this._salesSlipInputAcs.GetLastInputSalesRowNo();
                retSt = this._salesSlipInputAcs.SalesDetailRowSettingFromSalHisRefResultParamWorkList(lastInputSalesRow + 1, salHisRefResultParamWorkList, SalesSlipInputAcs.WayToDetailExpand.Normal);

                if (retSt == -1)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "注釈および行値引き、商品値引きは、売上伝票以外では複写対象外です。    ",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                }

                // 売上金額計算処理
                this.CalculationSalesPrice();

                // データ変更フラグプロパティをTrueにする
                this._salesSlipInputAcs.IsDataChanged = true;

                // 売上金額変更後発生イベントコール処理
                this.SalesPriceChangedEventCall();

                // フッタ部明細情報更新イベントコール処理
                this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                // 車両情報設定イベントコール処理
                this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

                // 明細グリッド設定処理
                this.SettingGrid();

                // 現在庫数調整
                this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

                // --- UPD 2009/09/08 ---------->>>>>
                this._salesSlipInputAcs.CreateSlipCopyCarInfo();
                // --- UPD 2009/09/08 ---------->>>>>

                #endregion

                #region フォーカス位置
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                #endregion
            }
        }

        /// <summary>
        /// 受注照会ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_AcceptAnOrderReference_Click(object sender, EventArgs e)
        {
            this._salesDetailDataTable.AcceptChanges();

            // 得意先入力チェック処理
            bool customerCodeCheck = this.CheckCustomerCodeInput();
            if (!customerCodeCheck) return;

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            List<AcptAnOdrRemainRefData> acptAnOdrRemainRefList;
            DCJUT04110UA acceptAnOrderGuide = new DCJUT04110UA();
            acceptAnOrderGuide.Standard_UGroupBox_Expand = true;
            acceptAnOrderGuide.AutoSearch = true;
            acceptAnOrderGuide.MaxSelectCount = this._salesInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();

            acceptAnOrderGuide.SearchCndtn.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
            acceptAnOrderGuide.SearchCndtn.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
            acceptAnOrderGuide.SearchCndtn.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
            acceptAnOrderGuide.SearchCndtn.CustomerName = this._salesSlipInputAcs.SalesSlip.CustomerSnm;
            acceptAnOrderGuide.SearchCndtn.ArrivalStateDiv = DCJUT04110UA.ArrivalState.NonArrival;
            acceptAnOrderGuide.CustomerCodeFix = true;

            DialogResult dialogResult = acceptAnOrderGuide.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                #region 明細へのデータ展開
                acptAnOdrRemainRefList = acceptAnOrderGuide.GetSelectDataList();

                int lastInputSalesRow = this._salesSlipInputAcs.GetLastInputSalesRowNo();
                int st = this._salesSlipInputAcs.SalesDetailRowSettingFromAcptAnOdrRemainRefList(lastInputSalesRow + 1, acptAnOdrRemainRefList, SalesSlipInputAcs.WayToDetailExpand.AddUp);

                if (st == -1)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "「計上」または「発注選択」済み明細がが選択されましたので、" + Environment.NewLine +
                        "明細への展開を行いません。",
                        -1,
                        MessageBoxButtons.OK);
                }
                else
                {
                    //// 最終行に商品名称が設定されている場合は１行追加
                    //if (!string.IsNullOrEmpty(this._salesDetailDataTable[this._salesDetailDataTable.Count - 1].GoodsName))
                    //{
                    //    this._salesSlipInputAcs.AddSalesDetailRow();

                    //    // 表示用行番号調整処理
                    //    this._salesSlipInputAcs.AdjustRowNo();

                    //    // 明細グリッド・行単位でのセル設定
                    //    this.SettingGridRow(rowIndex + 1, this._salesSlipInputAcs.SalesSlip);
                    //}

                    // 売上金額計算処理
                    this.CalculationSalesPrice();

                    // データ変更フラグプロパティをTrueにする
                    this._salesSlipInputAcs.IsDataChanged = true;

                    // 売上金額変更後発生イベントコール処理
                    this.SalesPriceChangedEventCall();

                    // フッタ部明細情報更新イベントコール処理
                    this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                    // 車両情報設定イベントコール処理
                    this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

                    // 明細グリッド設定処理
                    this.SettingGrid();

                    // 現在庫数調整
                    this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

                    #region フォーカス位置
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    #endregion
                }
                #endregion

            }
        }

        /// <summary>
        /// 出荷照会ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ShipmentReference_Click(object sender, EventArgs e)
        {
            this._salesDetailDataTable.AcceptChanges();

            // 得意先入力チェック処理
            bool customerCodeCheck = this.CheckCustomerCodeInput();
            if (!customerCodeCheck) return;

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            List<SalHisRefResultParamWork> salHisRefResultParamWorkList;
            DCHNB04101UA salesHisGuide = new DCHNB04101UA();
            salesHisGuide.AcptAnOdrStatus = (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment;
            salesHisGuide.AcptAnOdrStatusFix = true;
            salesHisGuide.AutoSearch = true;
            salesHisGuide.MaxSelectCount = this._salesInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            salesHisGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
            salesHisGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
            salesHisGuide.CustomerCodeFix = true;
            salesHisGuide.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
            salesHisGuide.CustomerName = this._salesSlipInputAcs.SalesSlip.CustomerSnm;
            salesHisGuide.SalesEmployeeCd = this._salesSlipInputAcs.SalesSlip.SalesEmployeeCd;
            salesHisGuide.SalesEmployeeName = this._salesSlipInputAcs.SalesSlip.SalesEmployeeNm;
            salesHisGuide.SalesInputCode = this._salesSlipInputAcs.SalesSlip.SalesInputCode;
            salesHisGuide.SalesInputName = this._salesSlipInputAcs.SalesSlip.SalesInputName;
            salesHisGuide.FrontEmployeeCd = this._salesSlipInputAcs.SalesSlip.FrontEmployeeCd;
            salesHisGuide.FrontEmployeeName = this._salesSlipInputAcs.SalesSlip.FrontEmployeeNm;

            DialogResult dialogResult = salesHisGuide.ShowDialog(this, (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment, this._salesSlipInputAcs.SalesSlip.CustomerCode);


            if (dialogResult == DialogResult.OK)
            {
                #region 明細へのデータ展開
                salHisRefResultParamWorkList = salesHisGuide.StcHisRefDataWork;
                int lastInputSalesRow = this._salesSlipInputAcs.GetLastInputSalesRowNo();
                int st = this._salesSlipInputAcs.SalesDetailRowSettingFromSalHisRefResultParamWorkListForAddUp(lastInputSalesRow + 1, salHisRefResultParamWorkList, SalesSlipInputAcs.WayToDetailExpand.AddUp);

                if (st == -1)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "「計上」済み明細が選択されましたので、" + Environment.NewLine +
                        "明細への展開を行いません。",
                        -1,
                        MessageBoxButtons.OK);
                }
                else
                {
                    //// 最終行に商品名称が設定されている場合は１行追加
                    //if (!string.IsNullOrEmpty(this._salesDetailDataTable[this._salesDetailDataTable.Count - 1].GoodsName))
                    //{
                    //    this._salesSlipInputAcs.AddSalesDetailRow();

                    //    // 表示用行番号調整処理
                    //    this._salesSlipInputAcs.AdjustRowNo();

                    //    // 明細グリッド・行単位でのセル設定
                    //    this.SettingGridRow(rowIndex + 1, this._salesSlipInputAcs.SalesSlip);
                    //}

                    // 売上金額計算処理
                    this.CalculationSalesPrice();

                    // データ変更フラグプロパティをTrueにする
                    this._salesSlipInputAcs.IsDataChanged = true;

                    // 売上金額変更後発生イベントコール処理
                    this.SalesPriceChangedEventCall();

                    // フッタ部明細情報更新イベントコール処理
                    this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                    // 車両情報設定イベントコール処理
                    this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

                    // 明細グリッド設定処理
                    this.SettingGrid();

                    // 現在庫数調整
                    this._salesSlipInputAcs.SalesDetailStockInfoAdjust();
    
                    #region フォーカス位置
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    #endregion
                }
                #endregion
            }
        }

        /// <summary>
        /// 見積照会ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_EstimateReference_Click(object sender, EventArgs e)
        {
            this._salesDetailDataTable.AcceptChanges();

            // 得意先入力チェック処理
            bool customerCodeCheck = this.CheckCustomerCodeInput();
            if (!customerCodeCheck) return;

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            List<SalHisRefResultParamWork> salHisRefResultParamWorkList;
            DCHNB04101UA salesHisGuide = new DCHNB04101UA();
            salesHisGuide.AcptAnOdrStatus = (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate;
            salesHisGuide.AcptAnOdrStatusFix = true;
            salesHisGuide.AutoSearch = true;
            salesHisGuide.MaxSelectCount = this._salesInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            salesHisGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
            salesHisGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
            salesHisGuide.CustomerCodeFix = true;
            salesHisGuide.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
            salesHisGuide.CustomerName = this._salesSlipInputAcs.SalesSlip.CustomerSnm;
            salesHisGuide.SalesEmployeeCd = this._salesSlipInputAcs.SalesSlip.SalesEmployeeCd;
            salesHisGuide.SalesEmployeeName = this._salesSlipInputAcs.SalesSlip.SalesEmployeeNm;
            salesHisGuide.SalesInputCode = this._salesSlipInputAcs.SalesSlip.SalesInputCode;
            salesHisGuide.SalesInputName = this._salesSlipInputAcs.SalesSlip.SalesInputName;
            salesHisGuide.FrontEmployeeCd = this._salesSlipInputAcs.SalesSlip.FrontEmployeeCd;
            salesHisGuide.FrontEmployeeName = this._salesSlipInputAcs.SalesSlip.FrontEmployeeNm;

            DialogResult dialogResult = salesHisGuide.ShowDialog(this, (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate, this._salesSlipInputAcs.SalesSlip.CustomerCode);

            if (dialogResult == DialogResult.OK)
            {
                #region 明細へのデータ展開
                salHisRefResultParamWorkList = salesHisGuide.StcHisRefDataWork;
                int lastInputSalesRow = this._salesSlipInputAcs.GetLastInputSalesRowNo();
                int st = this._salesSlipInputAcs.SalesDetailRowSettingFromSalHisRefResultParamWorkListForAddUp(lastInputSalesRow + 1, salHisRefResultParamWorkList, SalesSlipInputAcs.WayToDetailExpand.AddUp);

                if (st == -1)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "「計上」済み明細が選択されましたので、" + Environment.NewLine +
                        "明細への展開を行いません。",
                        -1,
                        MessageBoxButtons.OK);
                }
                else
                {
                    //// 最終行に商品名称が設定されている場合は１行追加
                    //if (!string.IsNullOrEmpty(this._salesDetailDataTable[this._salesDetailDataTable.Count - 1].GoodsName))
                    //{
                    //    this._salesSlipInputAcs.AddSalesDetailRow();

                    //    // 表示用行番号調整処理
                    //    this._salesSlipInputAcs.AdjustRowNo();

                    //    // 明細グリッド・行単位でのセル設定
                    //    this.SettingGridRow(rowIndex + 1, this._salesSlipInputAcs.SalesSlip);
                    //}

                    // 売上金額計算処理
                    this.CalculationSalesPrice();

                    // データ変更フラグプロパティをTrueにする
                    this._salesSlipInputAcs.IsDataChanged = true;

                    // 売上金額変更後発生イベントコール処理
                    this.SalesPriceChangedEventCall();

                    // フッタ部明細情報更新イベントコール処理
                    this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

                    // 車両情報設定イベントコール処理
                    this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

                    // 明細グリッド設定処理
                    this.SettingGrid();

                    // 現在庫数調整
                    this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

                    #region フォーカス位置
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName];
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    #endregion
                }
                #endregion
            }
        }

        /// <summary>
        /// 行値引きボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_LineDiscount_Click(object sender, EventArgs e)
        {
            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;

            List<int> checkStockRowNoList = new List<int>();
            checkStockRowNoList.Add(salesRowNo);
            int pasteCheck = this._salesSlipInputAcs.CheckPasteSalesDetailRow(checkStockRowNoList, rowIndex);

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


            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this._salesDetailDataTable.AcceptChanges();

            // 在庫情報のみクリア
            this._salesSlipInputAcs.ClearSalesDetailStockInfo(salesRowNo);

            // 行値引情報をセット
            this._salesSlipInputAcs.SettingSalesDetailRowLineDiscount(salesRowNo);
            this.SettingGrid();
            this.MoveNextAllowEditCell(true);
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

            // 品名へ移動
            this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
            this.MoveNextAllowEditCell(true);

            // 現在庫数調整
            this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

            // フッタ部明細情報更新イベントコール処理
            this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

            // 車両情報設定イベントコール処理
            this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

            this.SettingGrid();
        }

        /// <summary>
        /// 商品値引きボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_GoodsDiscount_Click(object sender, EventArgs e)
        {
            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;

            List<int> checkStockRowNoList = new List<int>();
            checkStockRowNoList.Add(salesRowNo);
            int pasteCheck = this._salesSlipInputAcs.CheckPasteSalesDetailRow(checkStockRowNoList, rowIndex);

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

            this._salesDetailDataTable.AcceptChanges();

            // 行値引情報をセット
            this._salesSlipInputAcs.SettingSalesDetailRowGoodsDiscount(salesRowNo);

            if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
            {
                this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
            }
            else
            {
                this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName];
            }
            this.MoveNextAllowEditCell(true);

            // 現在庫数調整
            this._salesSlipInputAcs.SalesDetailStockInfoAdjust();

            // フッタ部明細情報更新イベントコール処理
            this.SettingFooterEventCall(this.GetActiveRowSalesRowNo());

            // 車両情報設定イベントコール処理
            this.SettingCarInfoEventCall(this.GetActiveRowSalesRowNo());

            if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
            {
                this.SettingFocus(this._salesSlipInputAcs.SalesDetailDataTable.GoodsNoColumn.ColumnName);
            }
            else if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
            {
                this.SettingFocus(this._salesSlipInputAcs.SalesDetailDataTable.BLGoodsCodeColumn.ColumnName);
            }

            this.SettingGrid();

            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        }
        
        /// <summary>
        /// 注釈ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_Annotation_Click(object sender, EventArgs e)
        {
            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;

            List<int> checkStockRowNoList = new List<int>();
            checkStockRowNoList.Add(salesRowNo);
            int pasteCheck = this._salesSlipInputAcs.CheckPasteSalesDetailRow(checkStockRowNoList, rowIndex);

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

            this._salesDetailDataTable.AcceptChanges();

            // 注釈情報をセット
            this._salesSlipInputAcs.SettingSalesDetailRowAnnotation(salesRowNo);

            // 品名へ移動
            this.uGrid_Details.ActiveCell = this.uGrid_Details.ActiveRow.Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
            this.MoveNextAllowEditCell(true);

            // フッタ部明細情報更新イベントコール処理
            this.SettingFooterEventCall(salesRowNo);

            // 車両情報設定イベントコール処理
            this.SettingCarInfoEventCall(salesRowNo);

            #region ●注釈行チェック
            CheckOnlyAnnotation();
            #endregion

            this.SettingGrid();
        }

        /// <summary>
        /// 倉庫切替ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2010/05/04 王海立 入力倉庫チェック処理の追加</br>
        private void uButton_ChangeWarehouse_Click(object sender, EventArgs e)
        {
            //this._salesSlipInputAcs.ChangeWarehouse(this.GetActiveRowSalesRowNo());//DEL 2010/05/04
            // --- ADD 2010/05/04 ---------->>>>>
            string msg = "";
            this._salesSlipInputAcs.ChangeWarehouse(this.GetActiveRowSalesRowNo(), out msg);
            if (!string.IsNullOrEmpty(msg))
            {
                // 入力倉庫チェック区分 0:無視 1:再入力 2:警告
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().InpWarehChkDiv)
                {
                    case 0:
                        break;
                    case 1:
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            msg,
                            0,
                            MessageBoxButtons.OK);

                            return;
                        }
                    case 2:
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            msg,
                            0,
                            MessageBoxButtons.OK);

                            break;
                        }
                }
            }
            // --- ADD 2010/05/04 ----------<<<<<

            // 明細グリッド・行単位でのセル設定
            this.SettingGridRow(this.GetActiveRowIndex(), this._salesSlipInputAcs.SalesSlip);

            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// 入力切替ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/01/27 張凱 明細部の入力制御およびフォーカス制御を行う対応</br>
        private void uButton_InputChange_Click(object sender, EventArgs e)
        {
            switch (this._InputType)
            {
                case 0:
                    {
                        this._InputType = 1;
                        break;
                    }
                case 1:
                    {
                        this._InputType = 0;
                        break;
                    }
                case 2:
                    {
                        this._InputType = 0;
                        break;
                    }
                case 3:
                    {
                        this._InputType = 0;
                        break;
                    }
                //>>>2010/02/26
                case 4:
                    {
                        this._InputType = 0;
                        break;
                    }
                //<<<2010/02/26
            }

            this.SettingGridColVisible(StatusType.InputChange, this._InputType);

            // --- ADD 2010/01/27 -------------->>>>>
            int rowEffectiveIndex = this.SettingGridRowFromInputChange();

            if (rowEffectiveIndex >= 0)
            {
                //1:切替入力
                if (this._InputType == 1)
                {
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.DtlNoteColumn.ColumnName];
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            // --- ADD 2010/01/27 --------------<<<<<

        }

        /// <summary>
        /// 仕入情報ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/01/27 張凱 明細部の入力制御およびフォーカス制御を行う対応</br>
        private void uButton_InputStockInfo_Click(object sender, EventArgs e)
        {
            switch (this._InputType)
            {
                case 0:
                    {
                        this._InputType = 2;
                        break;
                    }
                case 1:
                    {
                        this._InputType = 2;
                        break;
                    }
                case 2:
                    {
                        this._InputType = 0;
                        break;
                    }
                case 3:
                    {
                        this._InputType = 2;
                        break;
                    }
                //>>>2010/02/26
                case 4:
                    {
                        this._InputType = 2;
                        break;
                    }
                //<<<2010/02/26
            }

            this.SettingGridColVisible(StatusType.InputChange, this._InputType);

            // --- ADD 2010/01/27 -------------->>>>>
            int rowEffectiveIndex = this.SettingGridRowFromInputChange();

            if (rowEffectiveIndex >= 0)
            {
                //2:仕入
                if (this._InputType == 2)
                {
                    this.uGrid_Details.AfterRowActivate -= this.uGrid_Details_AfterRowActivate;
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.AfterRowActivate += this.uGrid_Details_AfterRowActivate;
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName];
                    if (this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled
                        || this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit)
                    {
                        ReturnKeyDown();
                    }
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            // --- ADD 2010/01/27 --------------<<<<<

        }

        /// <summary>
        /// 発注情報ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/01/27 張凱 明細部の入力制御およびフォーカス制御を行う対応</br>
        private void uButton_InputOrderInfo_Click(object sender, EventArgs e)
        {
            switch (this._InputType)
            {
                case 0:
                    {
                        this._InputType = 3;
                        break;
                    }
                case 1:
                    {
                        this._InputType = 3;
                        break;
                    }
                case 2:
                    {
                        this._InputType = 3;
                        break;
                    }
                case 3:
                    {
                        this._InputType = 0;
                        break;
                    }
                //>>>2010/02/26
                case 4:
                    {
                        this._InputType = 3;
                        break;
                    }
                //<<<2010/02/26
            }

            this.SettingGridColVisible(StatusType.InputChange, this._InputType);

            // --- ADD 2010/01/27 -------------->>>>>
            int rowEffectiveIndex = this.SettingGridRowFromInputChange();

            if (rowEffectiveIndex >= 0)
            {
                //3:発注
                if (this._InputType == 3)
                {
                    this.uGrid_Details.AfterRowActivate -= this.uGrid_Details_AfterRowActivate;
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.AfterRowActivate += this.uGrid_Details_AfterRowActivate;
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.BoCodeColumn.ColumnName];
                    if (this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.BoCodeColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled
                        || this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.BoCodeColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit)
                    {
                        ReturnKeyDown();
                    }
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            // --- ADD 2010/01/27 --------------<<<<<

        }

        //>>>2010/02/26
        /// <summary>
        /// SCMボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SCM_Click(object sender, EventArgs e)
        {
            switch (this._InputType)
            {
                case 0:
                    {
                        this._InputType = 4;
                        break;
                    }
                case 1:
                    {
                        this._InputType = 4;
                        break;
                    }
                case 2:
                    {
                        this._InputType = 4;
                        break;
                    }
                case 3:
                    {
                        this._InputType = 4;
                        break;
                    }
                case 4:
                    {
                        this._InputType = 0;
                        break;
                    }
            }

            this.SettingGridColVisible(StatusType.InputChange, this._InputType);

            //>>>2010/04/27
            int rowEffectiveIndex = this.SettingGridRowFromInputChange();

            if (rowEffectiveIndex >= 0)
            {
                //4:SCM
                if (this._InputType == 4)
                {
                    this.uGrid_Details.AfterRowActivate -= this.uGrid_Details_AfterRowActivate;
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.AfterRowActivate += this.uGrid_Details_AfterRowActivate;
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.RecycleDivNmColumn.ColumnName];
                    if (this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.RecycleDivNmColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled
                        || this.uGrid_Details.Rows[rowEffectiveIndex].Cells[this._salesDetailDataTable.RecycleDivNmColumn.ColumnName].Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit)
                    {
                        ReturnKeyDown();
                    }
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            //<<<2010/04/27
        }
        //<<<2010/02/26

        /// <summary>
        /// InputType再設定処理
        /// </summary>
        /// <param name="InputType"></param>
        private void ChangeInputType(int InputType)
        {
            this._InputType = InputType;
        }

        /// <summary>
        /// 一式登録ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_NewComplete_Click(object sender, EventArgs e)
        {
            ////----------------------------------------------------
            //// 得意先入力チェック
            ////----------------------------------------------------
            //bool customerCodeCheck = this.CheckCustomerCodeInput();
            //if (!customerCodeCheck) return;

            //----------------------------------------------------
            // 明細情報入力チェック
            //----------------------------------------------------
            List<int> selectedSalesRowNoList = this.GetSelectedSalesRowNoList();
            if ((selectedSalesRowNoList == null) || 
                (selectedSalesRowNoList.Count == 0)||
                (!this._salesSlipInputAcs.ExistSalesDetailShipmentCnt(selectedSalesRowNoList)))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "明細情報が入力されていない為、一式登録できません。",
                    0,
                    MessageBoxButtons.OK);
                return;
            }

            //----------------------------------------------------
            // 一式情報チェック
            //----------------------------------------------------
            if (this._salesSlipInputAcs.CheckingSalesDetailPluralCompleteInfo(selectedSalesRowNoList) == false)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "複数の一式情報を含む為、一式情報の更新ができません。",
                    0,
                    MessageBoxButtons.OK);
                return;

            }

            if (this._salesSlipInputAcs.CheckingSalesDetailCompleteInfo(selectedSalesRowNoList) == false)
            {
                //----------------------------------------------------
                // 新規登録
                //----------------------------------------------------
                this._salesSlipInputAcs.GetCompleteInfo(selectedSalesRowNoList);
                
                MAHNB01010UH newCompleteInfoDialog = new MAHNB01010UH();
                this._controlScreenSkin.SettingScreenSkin(newCompleteInfoDialog);
                DialogResult dialogResult = newCompleteInfoDialog.ShowDialog(this);

                switch (dialogResult)
                {
                    case DialogResult.Cancel:
                        this._salesSlipInputAcs.DeleteCompleteInfoRow(this._salesSlipInputAcs.TargetRowNo);
                        break;
                    case DialogResult.OK:
                        // 一式情報を明細へ展開
                        this._salesSlipInputAcs.SettingSalesDetailCompleteInfo(selectedSalesRowNoList);
                        break;
                }
            }
            else
            {
                //----------------------------------------------------
                // 既存更新
                //----------------------------------------------------
                MAHNB01010UH newCompleteInfoDialog = new MAHNB01010UH();
                this._controlScreenSkin.SettingScreenSkin(newCompleteInfoDialog);
                DialogResult dialogResult = newCompleteInfoDialog.ShowDialog(this);

                switch (dialogResult)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        // 一式情報を明細へ展開
                        this._salesSlipInputAcs.SettingSalesDetailCompleteInfo(selectedSalesRowNoList);
                        break;
                }
            }
        }

        /// <summary>
        /// 一式追加ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_AddComplete_Click(object sender, EventArgs e)
        {
            //----------------------------------------------------
            // 一式情報データテーブル存在チェック
            //----------------------------------------------------
            if ((this._completeInfoDataTable == null) ||
                (this._completeInfoDataTable.Count == 0))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "一式情報が存在しない為、一式追加できません。",
                    0,
                    MessageBoxButtons.OK);
                return;
            }
                        
            //----------------------------------------------------
            // 明細情報入力チェック
            //----------------------------------------------------
            List<int> selectedSalesRowNoList = this.GetSelectedSalesRowNoList();
            if ((selectedSalesRowNoList == null) ||
                (selectedSalesRowNoList.Count == 0) ||
                (!this._salesSlipInputAcs.ExistSalesDetailShipmentCnt(selectedSalesRowNoList)))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "明細情報が入力されていない為、一式追加できません。",
                    0,
                    MessageBoxButtons.OK);
                return;
            }

            //----------------------------------------------------
            // 一式情報チェック
            //----------------------------------------------------
            if (this._salesSlipInputAcs.CheckingSalesDetailCompleteInfo(selectedSalesRowNoList) == true)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "既に一式登録されている明細を含む為、一式追加はできません。",
                    0,
                    MessageBoxButtons.OK);
                return;

            }

            //----------------------------------------------------
            // 一式情報選択画面表示
            //----------------------------------------------------
            MAHNB01010UI addCompleteInfoDialog = new MAHNB01010UI();
            this._controlScreenSkin.SettingScreenSkin(addCompleteInfoDialog);
            DialogResult dialogResult = addCompleteInfoDialog.ShowDialog(this);

            switch (dialogResult)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.OK:
                    // 一式情報を明細へ展開
                    this._salesSlipInputAcs.SettingSalesDetailCompleteInfo(selectedSalesRowNoList);

                    // 売上明細データテーブルおよび一式情報データテーブル再構築
                    this._salesSlipInputAcs.ConstructionCompleteInfo(this._salesSlipInputAcs.GetEffectiveSalesRowNoList());
                    break;
            }
        }

        /// <summary>
        /// 一式削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_DelComplete_Click(object sender, EventArgs e)
        {
            // 明細情報入力チェック
            List<int> selectedSalesRowNoList = this.GetSelectedSalesRowNoList();
            if ((selectedSalesRowNoList == null) ||
                (selectedSalesRowNoList.Count == 0) ||
                (!this._salesSlipInputAcs.ExistSalesDetailShipmentCnt(selectedSalesRowNoList)))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "明細情報が入力されていない為、一式削除できません。",
                    0,
                    MessageBoxButtons.OK);
                return;
            }

            // 売上明細データテーブルの一式情報クリア
            this._salesSlipInputAcs.ClearSalesDetailCompleteInfoRow(selectedSalesRowNoList);

            // 売上明細データテーブルおよび一式情報データテーブル再構築
            this._salesSlipInputAcs.ConstructionCompleteInfo(this._salesSlipInputAcs.GetEffectiveSalesRowNoList());
        }

        /// <summary>
        /// ＴＢＯボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/01/27 張凱 TBO検索で複数選択した場合、２行目からの売上金額の算出を正常に行う対応</br>
        private void uButton_TBO_Click(object sender, EventArgs e)
        {
            int rowIndex = this.GetActiveRowIndex();
            int salesRowNo = this.GetActiveRowSalesRowNo();
            List<GoodsUnitData> goodsUnitDataList;
            List<int> settingSalesRowNoList;

            // TBO検索
            int status = this.SearchTBO(salesRowNo, out goodsUnitDataList);

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "該当データが存在しません。",
                            -1,
                            MessageBoxButtons.OK);
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
            }

            // 検索結果設定処理
            if ((goodsUnitDataList != null) && (goodsUnitDataList.Count != 0))
            {
                // 2009/11/25 >>>
                //this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(this.GetActiveRowSalesRowNo(), salesRowNo, goodsUnitDataList, null, out settingSalesRowNoList, true, false);
                this._salesSlipInputAcs.SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(this.GetActiveRowSalesRowNo(), salesRowNo, goodsUnitDataList, null, out settingSalesRowNoList, true, false, 0);
                // 2009/11/25 <<<
                
                // 明細グリッド設定処理
                this.SettingGrid();

                // --- UPD 2010/01/27 -------------->>>>>
                //// 売上金額計算処理
                //this._salesSlipInputAcs.CalculationSalesMoney(rowIndex);

                //// 原価金額計算処理
                //this._salesSlipInputAcs.CalculationCost(rowIndex);

                //// 明細粗利率設定処理
                //this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNo);

                //// 一式情報設定処理
                //this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNo);

                //// 車両情報設定イベントコール処理
                //this.SettingCarInfoEventCall(salesRowNo);

                //// 売上金額変更後発生イベントコール処理
                //this.SalesPriceChangedEventCall();

                //// フッタ部明細情報更新イベントコール処理
                //this.SettingFooterEventCall(salesRowNo);
                foreach (int salesRowNoIndex in settingSalesRowNoList)
                {
                    // 売上金額計算処理
                    this._salesSlipInputAcs.CalculationSalesMoney(salesRowNoIndex - 1);

                    // 原価金額計算処理
                    this._salesSlipInputAcs.CalculationCost(salesRowNoIndex - 1);

                    // 明細粗利率設定処理
                    this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesRowNoIndex);

                    // 一式情報設定処理
                    this._salesSlipInputAcs.ConstructionCompleteInfo(salesRowNoIndex);

                    // 車両情報設定イベントコール処理
                    this.SettingCarInfoEventCall(salesRowNoIndex);

                    // 売上金額変更後発生イベントコール処理
                    this.SalesPriceChangedEventCall();

                    // フッタ部明細情報更新イベントコール処理
                    this.SettingFooterEventCall(salesRowNoIndex);
                }
                // --- UPD 2010/01/27 --------------<<<<<
            }
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// 車種変更ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ChangeCarInfo_Click(object sender, EventArgs e)
        {
            int salesRowNo = this.GetActiveRowSalesRowNo();

            // 車両情報データ→画面
            SalesInputDataSet.CarInfoRow row = this._salesSlipInputAcs.GetCarInfoRow(salesRowNo, SalesSlipInputAcs.GetCarInfoMode.NewInsertMode);
            this.SettingCarInfoEventCall(salesRowNo);
            this.SettingFocusEventCall(MAHNB01010UB.ct_ITEM_NAME_CARMNGCODE);
        }

        /// <summary>
        /// 車種変更ボタンEnabledイベント
        /// </summary>
        /// <param name="flag">0:選択不可,1:選択可</param>
        /// <remarks>
        /// <br>Note       : 車種変更ボタンをEnabledします。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/09/08</br>
        /// </remarks>
        internal void uButton_ChangeCarInfoChangeEnable(int flag)
        {
            //0:選択不可
            if (flag == 0)
            {
                this.uButton_ChangeCarInfo.Enabled = false;
            }
            else
            {
                this.uButton_ChangeCarInfo.Enabled = true;
            }
        }

        /// <summary>
        /// 前行複写ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CopyStockBefLine_Click(object sender, EventArgs e)
        {
            #region 初期処理
            bool reCalcUnitPrice = false;
            bool reCalcStockPrice = false;
            bool taxChange = false;

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;
            if (rowIndex == 0) return;

            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;
            int befSalesRowNo = this._salesSlipInputAcs.GetInputStockInfoSalesRowNo(salesRowNo);

            if (befSalesRowNo == -1)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "前行情報が存在しない為、複写を行いません。　",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            // 売上明細データテーブル更新
            this._salesDetailDataTable.AcceptChanges();

            // 仕入情報取得
            this._salesSlipInputAcs.SettingStockTempInfo(salesRowNo);
            StockTemp stockTempCurrent = new StockTemp();
            StockTemp stockTemp = new StockTemp();
            if (this._salesSlipStockInfoInputAcs.StockTemp != null)
            {
                stockTempCurrent = this._salesSlipStockInfoInputAcs.StockTemp.Clone();
                stockTemp = stockTempCurrent.Clone();
            }

            // 前行売上明細情報取得
            SalesInputDataSet.SalesDetailRow beforeSalesDetailRow = this._salesSlipInputAcs.GetSalesDetailRow(befSalesRowNo);
            #endregion

            #region 前行情報セット
            stockTemp.StockDate = beforeSalesDetailRow.StockDate; // 仕入日
            stockTemp.PartySaleSlipNum = beforeSalesDetailRow.PartySalesSlipNum; // 仕入伝票番号
            #endregion

            #region 仕入日変更チェック
            if (stockTempCurrent.StockDate != stockTemp.StockDate)
            {
                // 計上日の再セット
                this._salesSlipStockInfoInputAcs.SettingAddUpDate(ref stockTemp);

                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "仕入日が変更されました。" + "\r\n" + "\r\n" +
                    "商品価格を再取得しますか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes) reCalcUnitPrice = true;

                double taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(stockTemp.StockDate);

                if (taxRate != stockTempCurrent.SupplierConsTaxRate)
                {
                    stockTemp.SupplierConsTaxRate = taxRate;
                    if (!reCalcUnitPrice) taxChange = true;
                }
            }
            #endregion

            #region 各種情報更新
            // 税率変更
            if (taxChange) reCalcStockPrice = true;

            // 単価再計算有り(掛率から一括取得)
            if (reCalcUnitPrice)
            {
                this._salesSlipStockInfoInputAcs.CalclationUnitPrice(ref stockTemp);
                reCalcStockPrice = true;
            }

            // 仕入金額再計算
            if (reCalcStockPrice)
            {
                this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);
            }

            // メモリ上の内容と比較する
            if (stockTempCurrent != null)
            {
                ArrayList arRetList = stockTemp.Compare(stockTempCurrent);
                if (arRetList.Count > 0)
                {
                    this._salesSlipStockInfoInputAcs.Cache(stockTemp);
                    // --- UPD 2012/10/04 Y.Wakita ---------->>>>>
                    //this._salesSlipInputAcs.SettingSalesDetailRowStockTempInfo(salesRowNo);
                    this._salesSlipInputAcs.SettingSalesDetailRowStockTempInfo(salesRowNo, true);
                    // --- UPD 2012/10/04 Y.Wakita ----------<<<<<
                }
            }

            // 明細グリッド・行単位でのセル設定
            this.SettingGridRow(rowIndex, this._salesSlipInputAcs.SalesSlip);

            // データ変更フラグプロパティをTrueにする
            this._salesSlipInputAcs.IsDataChanged = true;
            #endregion
        }

        /// <summary>
        /// 一括複写ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CopyStockAllLine_Click(object sender, EventArgs e)
        {
            #region 初期処理
            bool reCalcUnitPrice = false;
            bool reCalcStockPrice = false;
            bool taxChange = false;
            bool firstFlg = true;
            DialogResult dialogResult = DialogResult.None;

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;
            if (rowIndex == 0) return;

            int salesRowNo = this._salesDetailDataTable[rowIndex].SalesRowNo;
            int befSalesRowNo = this._salesSlipInputAcs.GetInputStockInfoSalesRowNo(salesRowNo);
            if (befSalesRowNo < 0) return;

            // 売上明細データテーブル更新
            this._salesDetailDataTable.AcceptChanges();

            // 前行売上明細情報取得
            SalesInputDataSet.SalesDetailRow beforeSalesDetailRow = this._salesSlipInputAcs.GetSalesDetailRow(befSalesRowNo);
            #endregion

            // 複写対象行番号リスト取得
            List<int> salesRowNoList = this._salesSlipInputAcs.GetInputStockInfoSalesRowNoList();

            foreach (int rowNo in salesRowNoList)
            {
                if (rowNo < salesRowNo) continue;

                reCalcUnitPrice = false;
                reCalcStockPrice = false;
                taxChange = false;

                // 仕入情報取得
                this._salesSlipInputAcs.SettingStockTempInfo(rowNo);
                StockTemp stockTempCurrent = new StockTemp();
                StockTemp stockTemp = new StockTemp();
                if (this._salesSlipStockInfoInputAcs.StockTemp != null)
                {
                    stockTempCurrent = this._salesSlipStockInfoInputAcs.StockTemp.Clone();
                    stockTemp = stockTempCurrent.Clone();
                }

                #region 前行情報セット
                stockTemp.StockDate = beforeSalesDetailRow.StockDate; // 仕入日
                stockTemp.PartySaleSlipNum = beforeSalesDetailRow.PartySalesSlipNum; // 仕入伝票番号
                #endregion

                #region 仕入日変更チェック
                if (stockTempCurrent.StockDate != stockTemp.StockDate)
                {
                    // 計上日の再セット
                    this._salesSlipStockInfoInputAcs.SettingAddUpDate(ref stockTemp);

                    if (firstFlg)
                    {
                        dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "仕入日が変更されました。" + "\r\n" + "\r\n" +
                            "商品価格を再取得しますか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);
                        firstFlg = false;
                    }
                    if (dialogResult == DialogResult.Yes) reCalcUnitPrice = true;

                    double taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(stockTemp.StockDate);

                    if (taxRate != stockTempCurrent.SupplierConsTaxRate)
                    {
                        stockTemp.SupplierConsTaxRate = taxRate;
                        if (!reCalcUnitPrice) taxChange = true;
                    }
                }
                #endregion

                #region 各種情報更新
                // 税率変更
                if (taxChange) reCalcStockPrice = true;

                // 単価再計算有り(掛率から一括取得)
                if (reCalcUnitPrice)
                {
                    this._salesSlipStockInfoInputAcs.CalclationUnitPrice(ref stockTemp);
                    reCalcStockPrice = true;
                }

                // 仕入金額再計算
                if (reCalcStockPrice)
                {
                    this._salesSlipStockInfoInputAcs.CalculationStockPrice(ref stockTemp);
                }

                // メモリ上の内容と比較する
                if (stockTempCurrent != null)
                {
                    ArrayList arRetList = stockTemp.Compare(stockTempCurrent);
                    if (arRetList.Count > 0)
                    {
                        this._salesSlipStockInfoInputAcs.Cache(stockTemp);
                        // --- UPD 2012/10/04 Y.Wakita ---------->>>>>
                        //this._salesSlipInputAcs.SettingSalesDetailRowStockTempInfo(rowNo);
                        this._salesSlipInputAcs.SettingSalesDetailRowStockTempInfo(rowNo, true);
                        // --- UPD 2012/10/04 Y.Wakita ----------<<<<<
                    }
                }

                // 明細グリッド・行単位でのセル設定
                this.SettingGridRow(rowNo - 1, this._salesSlipInputAcs.SalesSlip);

                // データ変更フラグプロパティをTrueにする
                this._salesSlipInputAcs.IsDataChanged = true;
                #endregion
            }
        }

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
        /// 入力切替ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_InputChange_EnabledChanged(object sender, EventArgs e)
        {
            this._inputChangeButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 仕入ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_InputStockInfo_EnabledChanged(object sender, EventArgs e)
        {
            this._inputStockInfo.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 発注切替ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_InputOrderInfo_EnabledChanged(object sender, EventArgs e)
        {
            this._inputOrderInfo.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }
        
        /// <summary>
        /// 一式登録ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_NewComplete_EnabledChanged(object sender, EventArgs e)
        {
            this._newCompleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 一式追加ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_AddComplete_EnabledChanged(object sender, EventArgs e)
        {
            this._addCompleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 一式削除ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_DelComplete_EnabledChanged(object sender, EventArgs e)
        {
            this._delCompleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 行値引ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_LineDiscount_EnabledChanged(object sender, EventArgs e)
        {
            this._lineDiscountButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 注釈ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_Annotation_EnabledChanged(object sender, EventArgs e)
        {
            this._annotationButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 売上履歴ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SalesReference_EnabledChanged(object sender, EventArgs e)
        {
            this._salesReferenceButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 出荷照会ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_ShipmentReference_EnabledChanged(object sender, EventArgs e)
        {
            this._shipmentReferenceButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 受注照会ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_AcceptAnOrderReference_EnabledChanged(object sender, EventArgs e)
        {
            this._acceptAnOrderReferenceButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 見積照会ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_EstimateReference_EnabledChanged(object sender, EventArgs e)
        {
            this._estimateReferenceButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 検索切替ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SearchChange_EnabledChanged(object sender, EventArgs e)
        {
            this._searchChangeButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 商品値引ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_GoodsDiscount_EnabledChanged(object sender, EventArgs e)
        {
            this._goodsDiscountButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// ＴＢＯボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_TBO_EnabledChanged(object sender, EventArgs e)
        {
            this._tboButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 車種変更ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_ChangeCarInfo_EnabledChanged(object sender, EventArgs e)
        {
            this._changeCarInfoButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_RowInsert":
                    {
                        this.uButton_RowInsert_Click(this.uButton_RowInsert, new EventArgs());
                        break;
                    }
                case "ButtonTool_RowDelete":
                    {
                        this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                        break;
                    }
                case "ButtonTool_RowCut":
                    {
                        this.uButton_RowCut_Click(this.uButton_RowCut, new EventArgs());
                        break;
                    }
                case "ButtonTool_RowCopy":
                    {
                        this.uButton_RowCopy_Click(this.uButton_RowCopy, new EventArgs());
                        break;
                    }
                case "ButtonTool_RowPaste":
                    {
                        this.uButton_RowPaste_Click(this.uButton_RowPaste, new EventArgs());
                        break;
                    }
                case "ButtonTool_InputChange":
                    {
                        this.uButton_InputChange_Click(this.uButton_InputChange, new EventArgs());
                        break;
                    }
                case "ButtonTool_InputStockInfo":
                    {
                        this.uButton_InputStockInfo_Click(this.uButton_InputStockInfo, new EventArgs());
                        break;
                    }
                case "ButtonTool_InputOrderInfo":
                    {
                        this.uButton_InputOrderInfo_Click(this.uButton_InputOrderInfo, new EventArgs());
                        break;
                    }
                case "ButtonTool_LineDiscount":
                    {
                        this.uButton_LineDiscount_Click(this.uButton_LineDiscount, new EventArgs());
                        break;
                    }
                case "ButtonTool_GoodsDiscount":
                    {
                        this.uButton_GoodsDiscount_Click(this.uButton_GoodsDiscount, new EventArgs());
                        break;
                    }
                case "ButtonTool_Annotation":
                    {
                        this.uButton_Annotation_Click(this.uButton_Annotation, new EventArgs());
                        break;
                    }
                case "ButtonTool_NewComplete":
                    {
                        this.uButton_NewComplete_Click(this.uButton_NewComplete, new EventArgs());
                        break;
                    }
                case "ButtonTool_AddComplete":
                    {
                        this.uButton_AddComplete_Click(this.uButton_AddComplete, new EventArgs());
                        break;
                    }
                case "ButtonTool_DelComplete":
                    {
                        this.uButton_DelComplete_Click(this.uButton_DelComplete, new EventArgs());
                        break;
                    }
                case "ButtonTool_TBO":
                    {
                        this.uButton_TBO_Click(this.uButton_TBO, new EventArgs());
                        break;
                    }
                case "ButtonTool_ChangeCarInfo":
                    {
                        this.uButton_ChangeCarInfo_Click(this.uButton_ChangeCarInfo, new EventArgs());
                        break;
                    }
                // --- ADD 2009/12/23 ---------->>>>>
                case "ButtonTool_ChangeWarehouse":
                    {
                        this.uButton_ChangeWarehouse_Click(this.uButton_ChangeWarehouse, new EventArgs());
                        break;
                    }
                // --- ADD 2009/12/23 ----------<<<<<

                //>>>2010/02/26
                case "ButtonTool_SCM":
                    {
                        this.uButton_SCM_Click(this.uButton_SCM, new EventArgs());
                        break;
                    }
                //<<<2010/02/26

                //case "ButtonTool_RowConcentrate":
                //    {
                //        this.uButton_Concentrate_Click(this.uButton_Concentrate, new EventArgs());
                //        break;
                //    }
                //case "ButtonTool_RowSpread":
                //    {
                //        this.uButton_Spread_Click(this.uButton_Concentrate, new EventArgs());
                //        break;
                //    }
            }
        }

        /// <summary>
        /// グリッド行、列選択後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            //
        }

        /// <summary>
        /// 明細部開始項目セット処理
        /// </summary>
        internal void SetStartKeyNameList()
        {
            this._startKeyName = this._enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
        }

        /// <summary>
        /// 明細部最終項目セット処理
        /// </summary>
        internal void SetEndKeyNameList()
        {
            this._endKeyNameList[0] = this._enterMoveTable[SalesSlipInputConstructionAcs.ct_EndPosittion].Key;
        }

        /// <summary>
        /// Enterキー移動項目テーブルセット処理
        /// </summary>
        internal void SetEnterMoveTable()
        {

            ICollection keys = this._enterMoveTable.Keys;
            EnterMoveValue enterMoveValue = null;
            foreach (object key in keys)
            {
                if (!this._salesInputConstructionAcs.EnterMoveTable.ContainsKey(key.ToString()))
                {
                    enterMoveValue = new EnterMoveValue();
                    enterMoveValue.Key = this._enterMoveTable[key.ToString()].Key;
                    enterMoveValue.Enabled = this._enterMoveTable[key.ToString()].Enabled;
                    this._salesInputConstructionAcs.EnterMoveTable[key.ToString()] = enterMoveValue;
                }
            }

            this._enterMoveTable = this._salesInputConstructionAcs.EnterMoveTable;

        }

        /// <summary>
        /// セルEnabled設定取得処理
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        internal bool GetCellEnabled(string keyName)
        {
            bool enabled = false;

            if (this._enterMoveTable.ContainsKey(keyName))
            {
                enabled = this._enterMoveTable[keyName].Enabled;
            }
            return enabled;
        }

        /// <summary>
        /// 原単価の色設定
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="salesRowNo"></param>
        private void SalesUnitCostColorSetting(int rowIndex, int salesRowNo)
        {
            if (this._salesSlipInputAcs.CheckChangeColorForSalesUnitCost(salesRowNo))
            {
                this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Appearance.BackColor = ct_UNITPRICE_CHANGE_COLOR;
            }
            else
            {
                this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.SalesUnitCostColumn.ColumnName].Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
            }
        }

        /// <summary>
        /// 売単価の色設定
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="salesRowNo"></param>
        /// <br>UpdateNote : 2011/07/06 譚洪 Redmine#22774 キャンペーンにヒットして売価が算出された場合(売価≠0)、色が変わるの対応</br>
        private void SalesUnitPriceColorSetting(int rowIndex, int salesRowNo)
        {
            // --- UPD 2011/07/06  ---- >>>>>>
            if (this.uGrid_Details.ActiveRow != null && this.uGrid_Details.ActiveRow.Index == rowIndex)
            {
                if (this._salesSlipInputAcs.CheckChangeColorForSalesUnitPriceForCampaign(salesRowNo))
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName].Appearance.BackColor = ct_UNITPRICE_CHANGE_COLOR;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName].Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                }
            }
            else
            {
                if (this._salesSlipInputAcs.CheckChangeColorForSalesUnitPrice(salesRowNo))
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName].Appearance.BackColor = ct_UNITPRICE_CHANGE_COLOR;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName].Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                }
            }
            // --- UPD 2011/07/06  ---- <<<<<<
        }

        /// <summary>
        /// 定価の色設定
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="salesRowNo"></param>
        private void ListPriceColorSetting(int rowIndex, int salesRowNo)
        {
            if (this._salesSlipInputAcs.CheckChangeColorForListPrice(salesRowNo))
            {
                this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName].Appearance.BackColor = ct_UNITPRICE_CHANGE_COLOR;
            }
            else
            {
                this.uGrid_Details.Rows[rowIndex].Cells[this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName].Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
            }
        }
        # endregion

        // --- ADD 2009/10/19 ---------->>>>>
        /// <summary>
        /// 粗利率チェック
        /// </summary>
        public bool CheckSalesUnitCost()
        {
            bool ret = true;

            #region 粗利率チェック
            string errMsg = string.Empty;
            bool checkFlag = false;
            if (this._salesDetailDataTable != null && _beforeCell != null && _beforeCell.Row != null
                && _beforeCell.Row.Index >= 0)
            {
                int salesRowNo = this._salesDetailDataTable[_beforeCell.Row.Index].SalesRowNo;

                if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo)
                {
                    if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsNo) &&
                        !string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                    {
                        checkFlag = true;
                    }
                }
                else if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_VoluntaryGoodsNo)
                {
                    if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                    {
                        checkFlag = true;
                    }
                }

                if (checkFlag == true)
                {
                    this.uGrid_Details.UpdateData();
                    //原単価
                    SalesSlipInputAcs.CheckResult checkResult = this._salesSlipInputAcs.CheckSalesUnitCost(salesRowNo, 0, out errMsg, 1);

                    if (checkResult != SalesSlipInputAcs.CheckResult.Ok)
                    {
                        TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            errMsg,
                            -1,
                            MessageBoxButtons.OK);

                        if (checkResult == SalesSlipInputAcs.CheckResult.Error)
                        {
                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName];

                            ret = false;
                        }
                    }

                }
            }
            #endregion
            return ret;
        }
        // --- ADD 2009/10/19 ----------<<<<<

        // --- ADD 2009/11/24 ---------->>>>>
        /// <summary>
        /// 売価率および売単価が未入力チェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売価率および売単価が未入力の場合、メッセージ表示を行い、フォーカスの制御を行う。。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/11/24</br>
        /// </remarks>
        public bool CheckSalesRateAndUnPrcDisplay()
        {
            bool ret = true;

            #region 売価率および売単価が未入力チェック
            bool checkFlag = false;
            if (this._salesDetailDataTable != null && _beforeCell != null && _beforeCell.Row != null
                && _beforeCell.Row.Index >= 0)
            {
                if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo)
                {
                    if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsNo) &&
                        !string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                    {
                        checkFlag = true;
                    }
                }
                else if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_VoluntaryGoodsNo)
                {
                    if (!string.IsNullOrEmpty(this._salesDetailDataTable[_beforeCell.Row.Index].GoodsName))
                    {
                        checkFlag = true;
                    }
                }

                //>>>2010/02/22
                if (this._salesDetailDataTable[_beforeCell.Row.Index].EditStatus == SalesSlipInputAcs.ctEDITSTATUS_Annotation) checkFlag = false;
                //<<<2010/02/22

                if (checkFlag == true)
                {
                    if (this._salesDetailDataTable[_beforeCell.Row.Index].SalesRate == 0 &&
                        this._salesDetailDataTable[_beforeCell.Row.Index].SalesUnPrcDisplay == 0)
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "売価率・売単価共に0ですがよろしいですか",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.Yes)
                        {
                            //
                        }
                        else
                        {
                            ret = false;

                            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[_beforeCell.Row.Index].Cells[this._salesDetailDataTable.SalesRateColumn.ColumnName];
                        }
                    }
                }
            }
            #endregion

            return ret;
        }
        // --- ADD 2009/11/24 ----------<<<<<

        // -------ADD 2009/12/15------->>>>>
        /// <summary>
        /// 有効行チェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 有効行チェックを行う。。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/12/15</br>
        /// </remarks>
        public bool CheckRowEffective(int rowindex)
        {
            bool checkFlag = false;
            int salesRowNo = this._salesDetailDataTable[rowindex].SalesRowNo;

            if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo)
            {
                if (!string.IsNullOrEmpty(this._salesDetailDataTable[rowindex].GoodsNo) &&
                    !string.IsNullOrEmpty(this._salesDetailDataTable[rowindex].GoodsName))
                {
                    checkFlag = true;
                }
            }
            else if (this._salesSlipInputInitDataAcs.InputMode == SalesSlipInputInitDataAcs.ctINPUTMODE_VoluntaryGoodsNo)
            {
                if (!string.IsNullOrEmpty(this._salesDetailDataTable[rowindex].GoodsName))
                {
                    checkFlag = true;
                }
            }

            return checkFlag;
        }
        // -------ADD 2009/12/15-------<<<<<
    }
}
