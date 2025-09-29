using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
//using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 検索見積アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 検索見積の制御全般を行います。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
    /// <br>2008.05.21 men 新規作成</br>
    /// <br>2009.03.25 20056 對馬 大輔 MANTIS[0012638] 転嫁方式が伝票転嫁時、売上部品合計(税込)と売上部品小計(税込)のｾｯﾄ方法修正</br>
    /// <br>                           MANTIS[0012771] 単価情報がﾋｯﾄしない場合、ｵｰﾌﾟﾝ価格区分がｾｯﾄされない対応</br>
    /// <br>                           MANTIS[0012772] 優良情報に種別名称を表示</br>
    /// <br>2009.06.18 21024 佐々木 健 MANTIS[0013556] 車台番号の範囲チェックメソッドを追加</br>
    /// <br>                           MANTIS[0013560] 保存後に、在庫情報がクリアされないように修正</br>
    /// <br>2009.07.16 22018 鈴木 正臣 MANTIS[0013802] ＢＬコードガイドの初期表示モードを設定可能に変更。</br>
    /// <br>2009.07.16 22018 鈴木 正臣 明細ゼロ件で得意先コードを"ゼロ以外"→"ゼロ"へ変更したときクラッシュしないよう修正。</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/22 呉元嘯</br>
    /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>             PM.NS保守依頼②の追加</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/05 呉元嘯</br>
    /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>             Redmine#1134対応</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/25　21024 佐々木 健</br>
    /// <br>             ①販売区分コード、販売区分名称をセットするように修正(MANTIS[0014689])</br>
    /// <br>             ②BLコード検索結果、純正部品のBLコードが検索したコードと異なる場合に、検索BLコードから実績関連項目をセットするように修正(MANTIS[0014674])</br>
    /// <br>Update Note: 2010/06/08　李占川　障害改良対応（７月リリース分）の対応</br>
    /// <br>             ①ＢＬコード入力時の品名取得変更</br>
    /// <br>Update Note: 2010/06/17　李占川　Redmine#9946の対応</br>
    /// <br>Update Note: 2010/08/05　張凱　障害改良対応（８月リリース分）の対応</br>
    /// <br>             ①優良品の結合情報を表示する可能にするため、ファンクションを追加して結合情報を表示可能にする修正</br>
    /// <br>Update Note: 2010/10/01　20056 對馬 大輔</br>
    /// <br>             印刷用品番、印刷用メーカーコード、印刷用メーカー名称をセットする</br>
    /// <br>UpdateNote : 2011/02/14 liyp</br>
    /// <br>           ユーザー登録分商品に対する優良部品情報表示の修正（MANTIS: 14853）</br>
    /// <br>UpdateNote : 2011/02/14 yangmj</br>
    /// <br>           得意先掛率グループ取得処理の修正（MANTIS : 14533、15632、15825）</br>
    /// <br>           売価計算を掛率設定にした場合、売価率が正常にセットされない。（MANTIS:16906）</br>
    /// <br>           標準価格選択ＵＩ表示の速度改善（MANTIS: 14604）</br>
    /// <br>UpdateNote : 2011/06/07 鄧潘ハン</br>
    /// <br>           検索見積発行の改良、キャンペーン売価適用処理の追加（キャンペーン対応）</br>
    /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22773 キャンペーンにヒットして売価が算出された場合の対応</br>
    /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22773 掛率なしで、キャンペーン値引率≠0の場合の対応</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// <br>UpdateNote : 2011/08/12 譚洪 Redmine#23555 キャンペーンの売価「売価率、値引率、売価額」が設定されている場合は、掛率マスタの売価の設定をクリアするように仕様変更の対応</br>
    /// <br>Update Note: 2011/08/15 譚洪 Redmine#23554 掛率マスタの売価率設定ありで且つ、キャンペーンの売価額設定ありの場合、売価率はクリアの対応</br>
    /// <br>Update Note: 2011/11/12 李占川 Redmine#26535 BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑの在庫確認で作成された見積伝票の対応</br>
    /// <br>Update Note: 2011/11/24 鄧潘ハン</br>
    /// <br>           : redmine#8034、外車データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正</br>
    /// <br>Update Note: 2011/12/19 鄧潘ハン</br>
    /// <br>           : redmine#8034、外車データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正</br>
    /// <br>Update Note: 2012/04/06 wangf</br>
    /// <br>管理番号   : 10801804-00 2012/05/24配信分</br>
    /// <br>           : redmine#29227、検索見積発行にて掛率が反映されない場合がありますので修正</br>
    /// <br>Update Note: 2012/04/09 zhangy3</br>
    /// <br>管理番号   : 10801804-00 2012/05/24配信分</br>
    /// <br>           : redmine#29312、検索見積発行　売価の掛率が反映されない</br>
    /// <br>Update Note: 2012/04/27 wangf</br>
    /// <br>管理番号   : 10801804-00 2012/05/24配信分</br>
    /// <br>           : redmine#29640、検索見積発行　得意先掛率Ｇが適用されないの対応</br>
    /// <br>Update Note: 2012/05/08 吉岡 孝憲</br>
    /// <br>           : 障害No.125 検索見積発行で見積データを作成した場合、特記事項がセットされない件の対応</br>
    /// <br>Update Note: 2012/08/20 30744 湯上 千加子</br>
    /// <br>           : 2012/09/12配信 システムテスト障害No.8対応</br>
    /// <br>Update Note: 2012/09/13 30744 湯上 千加子</br>
    /// <br>           : 2012/09/19配信 SCM障害№125対応</br>
    /// <br>           :                特記事項40桁以上カット対応</br>
    /// <br>Update Note: 2012/10/24 田建委</br>
    /// <br>管理番号   : 10801804-00、2012/11/14配信分</br>
    /// <br>             Redmine#32862 #9の障害 仕入先変更した変更前価格をクリアしないように修正</br>
    /// <br>Update Note: 2012/10/25 宮本 利明</br>
    /// <br>           : 障害対応 セットガイド選択時のQTYを明細に反映</br>
    /// <br>Update Note: 2012/12/20 宮本 利明</br>
    /// <br>           : 障害対応 優良品手入力時に純正情報をクリアしない</br>
    /// <br>Update Note: 2012/12/25 宮本 利明</br>
    /// <br>           : 障害対応 優良品に対してのセットガイド選択時のQTYを明細(優良品表示部)に反映</br>
    /// <br>Update Note: 2012/12/27 宮本 利明</br>
    /// <br>           : 障害対応 優良品変更時に純正表示欄に優良品名・BLコードを表示する条件を修正</br>
    /// <br>Update Note: 2013/01/09 宮本 利明</br>
    /// <br>           : 障害対応 セット品のQTYを明細に反映する条件を追加（商品種別がセット子の場合）</br>
    /// <br>Update Note: 2013/02/20 譚洪</br>
    /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
    /// <br>             Redmine#34434 No.1180 現在庫数が０のとき在庫数が空白で表示されるの対応</br>
    /// <br>Update Note: 2013/03/10 譚洪</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine#34994、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
    /// <br>Update Note: 2013/05/03 xujx</br>
    /// <br>管理番号   : 10801804-00 2013/05/15 配信分</br>
    /// <br>           : redmine#34803、明細が入力されていない場合は"有効な明細が入力されていません。"と表示するように修正の対応</br>
    /// <br>           :　既存伝票を呼び出して、明細データをコピー/挿入する場合、「印刷」ボタンを押下して、エラーが発生することの対応</br>
    /// <br>Update Note: 2013/05/07 xujx</br>
    /// <br>管理番号   : 10801804-00 2013/05/15 配信分</br>
    /// <br>           : redmine#34803、発注データの明細を作成した後、その明細を削除し、別の車両で新規にデータを作成してから印刷しようとすると「インデックスが配列の境界外です。」の対応</br>
    /// <br>           :　明細表示を「規格/オプション情報」に変更後、明細を削除するとフォーカスが最終行まで移動してしまいますの対応</br>
    /// <br>Update Note: 2013/11/05 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : 仕掛一覧 №2119</br>
    /// <br>           : 見積時に値引行が入力できない。入力できるようにする。</br>
    /// <br>Update Note: 2013/12/16 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : 純正定価印字対応</br>
    /// </remarks>
	public partial class EstimateInputAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region ■Constructor
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public EstimateInputAcs()
		{
			// 変数初期化
            this._dataSet = new EstimateInputDataSet();
            this._estimateDetailDataTable = this._dataSet.EstimateDetail;
            this._stockInfoDataTable = this._dataSet.StockInfo;
            this._primeInfoDataTable = this._dataSet.PrimeInfo;
            this._uoeOrderDataTable = this._dataSet.UOEOrder;
            this._uoeOrderDetailDataTable = this._dataSet.UOEOrderDetail;
            this._primeInfoDisplayView = new DataView(this._primeInfoDataTable);
            this._primeInfoDisplayView.Sort = this._primeInfoDataTable.JoinDispOrderColumn.ColumnName;
            this._salesSlip = new SalesSlip();
			this._salesSlipDBData = new SalesSlip();
			this._salesDetailDBDataList = new List<SalesDetail>();
            this._salesPriceCalculate = new SalesPriceCalculate();
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._stockPriceCalculate = new StockPriceCalculate();
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();

            this._estimateInputInitDataAcs.CacheStockProcMoneyList += new EstimateInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._unitPriceCalculation.CacheStockProcMoneyList);
            this._estimateInputInitDataAcs.CacheSalesProcMoneyList += new EstimateInputInitDataAcs.CacheSalesProcMoneyListEventHandler(this._unitPriceCalculation.CacheSalesProcMoneyList);
            this._estimateInputInitDataAcs.CacheStockProcMoneyList += new EstimateInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._stockPriceCalculate.CacheStockProcMoneyList);
            this._estimateInputInitDataAcs.CacheSalesProcMoneyList += new EstimateInputInitDataAcs.CacheSalesProcMoneyListEventHandler(this._salesPriceCalculate.CacheSalesProcMoneyList);
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();

            //-------------ADD 2009/10/22---------->>>>>
            this._priceSelectSetAcs = new PriceSelectSetAcs();
            this._custRateGroupAcs = new CustRateGroupAcs();
            this._goodsAcs = new GoodsAcs();
            //-------------ADD 2009/10/22----------<<<<<

            // 優良情報テーブルのColumnChangedイベントにメソッド追加
            this._primeInfoDataTable.ColumnChanged += new DataColumnChangeEventHandler(PrimeInfoTableDataTable_ColumnChanged);

			this._estimateDetailDataView = new DataView(this._estimateDetailDataTable);

            this._carInfoDataTable = new EstimateInputDataSet.CarInfoDataTable();
			this._colorInfoDic = new Dictionary<Guid, PMKEN01010E.ColorCdInfoDataTable>();
			this._trimInfoDic = new Dictionary<Guid, PMKEN01010E.TrimCdInfoDataTable>();
			this._cEqpDspInfoDic = new Dictionary<Guid, PMKEN01010E.CEqpDefDspInfoDataTable>();

            this._partsInfoDictionary = new Dictionary<Guid, PartsInfoDataSet>();

            this._carInfoDictionary = new Dictionary<Guid, PMKEN01010E>();

            //this._goodsDictionary = new Dictionary<GoodsInfoKey, GoodsUnitData>();//DEL 2011/02/14
            this._goodsDictionary = new Dictionary<string, GoodsUnitData>();//ADD 2011/02/14

            this._carRelationDic = new Dictionary<int, Guid>();

			this._beforeCarRelationGuid = new Guid();
            this._carSearchController = new CarSearchController();
            this._priceSelectValue = 0; // ADD 2009/10/22
            this._primeRelationDic = new Dictionary<Guid, PartsInfoDataSet>(); // ADD 2009/10/22

            this.campaignObjGoodsSt = new CampaignObjGoodsSt();  //ADD 2011/08/15
        }

		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region ■Private Members
		private EstimateInputInitDataAcs _estimateInputInitDataAcs;
		private StockPriceCalculate _stockPriceCalculate;
		private EstimateInputDataSet _dataSet;
		private SalesSlip _salesSlip;
		private SalesSlip _salesSlipDBData;
		private string _currentSalesSlipNum = ctDefaultSalesSlipNum;
		private EstimateInputDataSet.EstimateDetailDataTable _estimateDetailDataTable;
		private EstimateInputDataSet.StockInfoDataTable _stockInfoDataTable;
        private EstimateInputDataSet.PrimeInfoDataTable _primeInfoDataTable;
        private EstimateInputDataSet.UOEOrderDataTable _uoeOrderDataTable;
        private EstimateInputDataSet.UOEOrderDetailDataTable _uoeOrderDetailDataTable;

        DataView _primeInfoDisplayView;
        DataView _primeInfoControlView;

        private List<SalesDetail> _salesDetailDBDataList;
        private IIOWriteControlDB _iIOWriteControlDB;
		private string _enterpriseCode;
		private bool _isDataCanged = false;

		private CustomerInfoAcs _customerInfoAcs;
        private SupplierAcs _supplierAcs;
        private ModelNameUAcs _modelNameUAcs;
        private SearchStockAcs _searchStockAcs;
        private SalesPriceCalculate _salesPriceCalculate;
		private UnitPriceCalculation _unitPriceCalculation;
		private EstimateInputConstructionAcs _estimateInputConstructionAcs;
		private DataView _estimateDetailDataView;
        private CarSearchController _carSearchController;
        private bool _searchCarDiv = false;                                             // 車輌検索区分(true:検索する,false:検索しない)
        //---------------ADD 2009/10/22---------->>>>>
        // 標準価格選択設定マスタアクセス
        private PriceSelectSetAcs _priceSelectSetAcs;
        // 得意先掛率グループコードマスタアクセス
        private CustRateGroupAcs _custRateGroupAcs;
        // 商品マスタアクセスクラス
        private GoodsAcs _goodsAcs;
        //---------------ADD 2009/10/22----------<<<<<
		private EstimateInputDataSet.CarInfoDataTable _carInfoDataTable;                // 車輌情報テーブル
		private Dictionary<Guid, PMKEN01010E.ColorCdInfoDataTable> _colorInfoDic;       // カラー情報
		private Dictionary<Guid, PMKEN01010E.TrimCdInfoDataTable> _trimInfoDic;         // トリム情報
		private Dictionary<Guid, PMKEN01010E.CEqpDefDspInfoDataTable> _cEqpDspInfoDic;  // 装備情報
		private Guid _beforeCarRelationGuid;                                            // 前回車輌情報共通キー

        private Dictionary<Guid, PartsInfoDataSet> _partsInfoDictionary;
        private Dictionary<Guid, PMKEN01010E> _carInfoDictionary;
        //private Dictionary<GoodsInfoKey, GoodsUnitData> _goodsDictionary; //DEL 2011/02/14
        private Dictionary<string, GoodsUnitData> _goodsDictionary; //ADD 2011/02/14
        private Dictionary<int, Guid> _carRelationDic;                                  // 車輌連結情報

        public int _priceSelectValue; // ADD 2009/10/22
        public Dictionary<Guid, PartsInfoDataSet> _primeRelationDic;                                  // 優良連結情報 // ADD 2009/10/22

        private ArrayList _custRateGroupList;//ADD 2011/02/14
        private ArrayList _displayDivList;//ADD 2011/02/14

        private CampaignObjGoodsSt campaignObjGoodsSt;  //ADD 2011/08/15

        //---ADD 鄧潘ハン 2011/11/24 Redmine#8034-------------------->>>>>
        private string _goodsEstimateNo;

        public string GoodsEstimateNo
        {
            get
            {
                return _goodsEstimateNo;
            }
            set
            {
                this._goodsEstimateNo = value;
            }
        }
        //---ADD 鄧潘ハン 2011/11/24 Redmine#8034--------------------<<<<<

        private bool _isDiscount = false;   // ADD 2013/11/05 Y.Wakita
        
		# endregion

		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		# region ■Public Readonly Members
		/// <summary>行ステータス（通常行）</summary>
		public static readonly int ctROWSTATUS_NORMAL = 0;

		/// <summary>行ステータス（コピー行）</summary>
		public static readonly int ctROWSTATUS_COPY = 1;

		/// <summary>行ステータス（カット行）</summary>
		public static readonly int ctROWSTATUS_CUT = 2;

		/// <summary>行編集ステータス（全項目編集可能）</summary>
		public static readonly int ctEDITSTATUS_AllOK = 0;

		/// <summary>行編集ステータス（全項目無効）</summary>
		public static readonly int ctEDITSTATUS_AllDisable = 2;

		/// <summary>行編集ステータス（全項目参照のみ）</summary>
		public static readonly int ctEDITSTATUS_AllReadOnly = 3;

		/// <summary>入力モード（通常）</summary>
		public static readonly int ctINPUTMODE_Estimate_Normal = 0;

		/// <summary>入力モード（読み取り専用）</summary>
		public static readonly int ctINPUTMODE_Estimate_ReadOnly = 9;

		/// <summary>最大仕入数量</summary>
		public static readonly double ctMAXVALUE_StockCount = 9999999.99;
		/// <summary>最大仕入数量(明細)</summary>
		public static readonly double ctMAXVALUE_StockCountDetail = 9999999.99;
		/// <summary>最大金額</summary>
		public static readonly long ctMAXVALUE_StockPrice = 9999999999;
		/// <summary>最大金額(明細)</summary>
		public static readonly long ctMAXVALUE_StockPriceDetail = 999999999;
		/// <summary>最大単価</summary>
		public static readonly double ctMAXVALUE_StockUnitPrice = 99999999.99;
		/// <summary>売上伝票番号初期値</summary>
		public static readonly string ctDefaultSalesSlipNum = "".PadLeft(9, '0');
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region ■Events
		/// <summary>データ変更後発生イベント</summary>
		public event EventHandler DataChanged;
        /// <summary>優良データフィルター変更時発生イベント</summary>
        public event EventHandler PimeInfoFilterChanged;
        /// <summary>優良データ選択データ変更時発生イベント</summary>
        public event EventHandler PimeInfoSelectChanged;

		# endregion

		// ===================================================================================== //
		// 列挙体
		// ===================================================================================== //
		# region ■Enums

        /// <summary>
        /// 検索モード列挙型
        /// </summary>
        public enum SearchMode : int
        {
            /// <summary>BLコード検索</summary>
            BLSearch = 0,
            /// <summary>品番検索</summary>
            GoodsNoSearch = 1
        }

		/// <summary>
		/// 単価入力モード列挙型
		/// </summary>
		public enum PriceInputType : int
		{
			/// <summary>税抜き価格入力</summary>
			PriceTaxExc = 0,
            /// <summary>税込み価格入力</summary>
			PriceTaxInc = 1,
            /// <summary>表示価格入力</summary>
			PriceDisplay = 2
		}

		/// <summary>
		/// フォーカス移動方法(通常コントロール)
		/// </summary>
		public enum MoveMethod : int
		{
			/// <summary>上から下へ</summary>
			NextMove = 0,
			/// <summary>下から上へ</summary>
			PrevMove = 1,
		}

		/// <summary>
		/// メモ複写区分（履歴からコピー、計上する際にメモを複写するか設定）
		/// </summary>
		public enum MemoMoveDiv : int
		{
			/// <summary>全て</summary>
			All = 0,
			/// <summary>伝票メモのみ</summary>
			SlipMemoOnly = 1,
			/// <summary>しない</summary>
			None = 2
		}

		/// <summary>
		/// 車輌情報取得モード
		/// </summary>
		public enum GetCarInfoMode : int
		{
			/// <summary>追加</summary>
			NewInsertMode = 0,
			/// <summary>既存を取得</summary>
			ExistGetMode = 1,
			/// <summary>車種変更</summary>
			CarInfoChangeMode = 2,
		}

        /// <summary>
        /// 車輌検索モード
        /// </summary>
        public enum SearchCarMode : int
        {
            /// <summary>型式検索</summary>
            FullModelSearch = 0,
            /// <summary>モデルプレート検索</summary>
            ModelPlateSearch = 1,
        }

        /// <summary>
        /// 商品検索区分
        /// </summary>
        public enum GoodsSearchDiv : int
        {
            /// <summary>BLコード検索</summary>
            BLPartsSearch = 0,
            /// <summary>品番検索</summary>
            PartsNoSerach = 1,
            /// <summary>直接入力(手入力)</summary>
            DirectInput = 2,
        }

        /// <summary>
        /// データ取得モード
        /// </summary>
        private enum DataGetMode : int
        {
            /// <summary>全て</summary>
            All =0,
            /// <summary>純正部品のみ</summary>
            PurePartsOnly=1,
            /// <summary>優良部品のみ</summary>
            PrimePartsOnly=2,
            /// <summary>選択中の部品のみ</summary>
            SelectedPartsOnly=3,
        }

        /// <summary>
        /// データ入力タイプ
        /// </summary>
        public enum TargetData : int
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>純正部品</summary>
            PureParts = 1,
            /// <summary>優良部品</summary>
            PrimeParts = 2,
        }

        /// <summary>
        /// 明細枝番
        /// </summary>
        private enum SalesRowDerivNo : int
        {
            /// <summary>純正部品</summary>
            PureParts = 0,
            /// <summary>優良部品</summary>
            PrimeParts = 1
        }

        /// <summary>
        /// チェック戻り値
        /// </summary>
        public enum CheckResult : int
        {
            /// <summary>OK</summary>
            Ok = 0,
            /// <summary>エラー</summary>
            Error = 1,
            /// <summary>警告</summary>
            Warning = 2,
            /// <summary>確認</summary>
            Confirm = 3
        }

        /// <summary>
        /// データセット結果（検索結果を明細に展開時に使用)
        /// </summary>
        public enum DataSettingResult : int
        {
            Ok = 0,
            Error = 1,
            OverRowCount = 2
        }

		#endregion

        // ===================================================================================== //
        // 構造体
        // ===================================================================================== //
        #region ■Struct

        # region [商品キー情報]
        /// <summary>
        /// 商品情報キー
        /// </summary>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        private struct GoodsInfoKey
        {
            /// <summary>商品コード</summary>
            private string _goodsNo;
            /// <summary>メーカーコード</summary>
            private int _goodsMakerCd;
            /// <summary>
            /// 商品コード
            /// </summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>
            /// メーカーコード
            /// </summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="goodsNo">商品コード</param>
            /// <param name="goodsMakerCd">メーカーコード</param>
            public GoodsInfoKey( string goodsNo, int goodsMakerCd )
            {
                _goodsNo = goodsNo;
                _goodsMakerCd = goodsMakerCd;
            }

            // --- ADD 2011/02/14---------->>>>>
            /// <summary>
            /// KEYの取得
            /// </summary>
            public string GetKey()
            {
                return _goodsMakerCd.ToString("0000") + _goodsNo;
            }
            // --- ADD 2011/02/14----------<<<<<
        }

        /// <summary>
        /// 明細情報キー
        /// </summary>
        private struct DetailInfoKey
        {
            /// <summary>売上伝票番号</summary>
            private string _salesSlipNum;
            /// <summary>行番号</summary>
            private int _salesRowNo;
            /// <summary>
            /// 売上伝票番号
            /// </summary>
            public string SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }
            /// <summary>
            /// 行番号
            /// </summary>
            public int SalesRowNo
            {
                get { return _salesRowNo; }
                set { _salesRowNo = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="salesSlipNum">売上伝票番号</param>
            /// <param name="salesRowNo">行番号</param>
            public DetailInfoKey(string salesSlipNum, int salesRowNo)
            {
                _salesSlipNum = salesSlipNum;
                _salesRowNo = salesRowNo;
            }
        }
        # endregion

        #endregion

        // ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region ■Properties
        // --- ADD 2011/11/12---------->>>>>
        /// <summary>
        /// ＤＢから取得した売上明細データオブジェクトを取得します。
        /// </summary>
        public List<SalesDetail> SalesDetailList
        {
            get { return _salesDetailDBDataList; }
        }
        // --- ADD 2011/11/12----------<<<<<

		/// <summary>
		/// 見積明細データテーブルオブジェクトを取得します。
		/// </summary>
		public EstimateInputDataSet.EstimateDetailDataTable EstimateDetailDataTable
		{
			get { return _estimateDetailDataTable; }
		}

		/// <summary>データ変更フラグの取得、設定を行います。（true:変更あり false:変更なし）</summary>
		public bool IsDataChanged
		{
			get
			{
				return this._isDataCanged;
			}
			set
			{
				this._isDataCanged = value;

				if (this.DataChanged != null)
				{
					this.DataChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>現在の売上データオブジェクトの取得を行います。</summary>
		public SalesSlip SalesSlip
		{
			get
			{
				return this._salesSlip;
			}
		}

		/// <summary>車輌情報データテーブル</summary>
		public EstimateInputDataSet.CarInfoDataTable CarInfoDataTable
		{
			set { this._carInfoDataTable = value; }
			get { return this._carInfoDataTable; }
		}

		/// <summary>車輌情報データテーブル</summary>
		public Guid BeforeCarRelationGuid
		{
			set { this._beforeCarRelationGuid = value; }
			get { return this._beforeCarRelationGuid; }
		}

        /// <summary>優良情報データビュー</summary>
        public DataView PrimeInfoView
        {
            get { return this._primeInfoDisplayView; }
        }

        /// <summary>優良情報データテーブル</summary>
        public EstimateInputDataSet.PrimeInfoDataTable PrimeInfoDataTable
        {
            set { this._primeInfoDataTable = value; }
            get { return this._primeInfoDataTable; }
        }

        /// <summary>ＵＯＥ発注データテーブル</summary>
        public EstimateInputDataSet.UOEOrderDataTable UOEOrderDataTable
        {
            set { this._uoeOrderDataTable = value; }
            get { return this._uoeOrderDataTable; }
        }

        /// <summary>ＵＯＥ発注明細データテーブル</summary>
        public EstimateInputDataSet.UOEOrderDetailDataTable UOEOrderDetailDataTable
        {
            set { this._uoeOrderDetailDataTable = value; }
            get { return this._uoeOrderDetailDataTable; }
        }

        /// <summary>車輌検索区分(true:検索する,false:検索しない)</summary>
        public bool SearchCarDiv
        {
            set { this._searchCarDiv = value; }
            get { return this._searchCarDiv; }
        }

        // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
        /// <summary>値引きデータ有無の取得、設定を行います。（true:値引あり false:値引なし）</summary>
        public bool IsDiscount
        {
            set { this._isDiscount = value; }
            get { return this._isDiscount; }
        }
        // --- ADD 2013/11/05 Y.Wakita ----------<<<<<
		# endregion

		// ===================================================================================== //
		// DBデータアクセス処理
		// ===================================================================================== //
		# region ■DataBase Access Methods
		/// <summary>
		/// 見積データの保存を行います。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
		/// <param name="retMessage">メッセージ（out）</param>
		/// <returns>STATUS</returns>
        public int SaveDBData( string enterpriseCode, string salesSlipNum, out string retMessage )
		{
			List<SalesDetail> salesDetailList;

            SalesSlip salesSlip = this._salesSlip;
            Dictionary<int, Dictionary<string, object>> detailAddInfoDictionary;
            this.GetCurrentData(DataGetMode.All, ref salesSlip, out salesDetailList, out detailAddInfoDictionary);

            ArrayList carManagementWorkList = new ArrayList();   // 車輌管理ワークオブジェクトリスト
            this.GetCurrentCarManagementWorkList(out carManagementWorkList); // 車輌管理ワークオブジェクトリスト取得

            ArrayList uoeOederDataList = null;

            this.GetUOEOrderData(out uoeOederDataList);

			retMessage = "";

            int status = this.SaveDBData(salesSlip, salesDetailList, carManagementWorkList, uoeOederDataList, out retMessage);

            // 退避情報の復元
            this.EstimateDetailTableRestoreRowInfo(detailAddInfoDictionary);

            return status;
			//return this.SaveDBData(this._salesSlip, salesDetailList, out retMessage);
        }

        /// <summary>
        /// 見積データの保存を行います。（オーバーロード）
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        /// <param name="carManagementWorkList">車輌管理ワークオブジェクトリスト</param>
        /// <param name="uoeDataList">ＵＯＥ発注データリスト</param>
        /// <param name="retMessage">メッセージ</param>
        /// <returns>STATUS</returns>
        private int SaveDBData(SalesSlip salesSlip, List<SalesDetail> salesDetailList, ArrayList carManagementWorkList, ArrayList uoeDataList, out string retMessage)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --CustomSerializeArrayList      売上リスト
            //          --SalesSlipWork             売上データオブジェクト
            //          --ArrayList                 売上明細リスト
            //              --SalesDetailWork       売上明細データオブジェクト
            //          --DepsitMainWork            入金データオブジェクト
            //          --DepositAlwWork            入金引当データオブジェクト
            //          --CarManagementWork         車輌管理データオブジェクト
            //      --CustomSerializeArrayList      受注リスト
            //          --SalesSlipWork             受注データオブジェクト
            //          --ArrayList                 受注明細リスト
            //              --SalesDetailWork       受注明細データオブジェクト
            //          --CarManagementWork         車輌管理データオブジェクト
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --PaymentSlpWork            支払データオブジェクト
            //      --CustomSerializeArrayList      発注リスト
            //          --StockSlipWork             発注データオブジェクト(※リモート参照用。実データは作成されません。)
            //          --ArrayList                 発注明細リスト
            //              --StockDetailWork       発注明細データオブジェクト
            //------------------------------------------------------------------------------------
            ArrayList salesDataList = new ArrayList();
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();             // 統合リスト
            CustomSerializeArrayList salesSlipDataList = new CustomSerializeArrayList();    // データ格納用リスト
            ArrayList salesDetailArrayList = new ArrayList();                               // 明細データ格納用リスト
            ArrayList carManagementWorkListForSave = new ArrayList();                       // 車輌情報構成情報リスト
            ArrayList slipDetailAddInfoWorkList = new ArrayList();                          // 伝票明細追加情報リスト
            IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();
            // 2009.06.18 Add >>>
            List<StockWork> saveBeforeStockWorkList = this.GetStockInfoList();
            // 2009.06.18 Add <<<

            #region データの補正

            salesSlip.EnterpriseCode = this._enterpriseCode;
            salesSlip.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            salesSlip.DetailRowCount = salesDetailList.Count;
            salesSlip.AddUpADate = DateTime.MinValue;
            salesSlip.DelayPaymentDiv = 0;
            salesSlip.EstimateDivide = 3;
            salesSlip.SlipPrintDivCd = ( this._estimateInputInitDataAcs.GetEstimateDefSet().EstimatePrtDiv == 0 ) ? 1 : 0;
            salesSlip.SlipPrtSetPaperId = this.GetSlipPrtSetPaperId(salesSlip); // 伝票印刷設定用帳票ＩＤ
            salesSlip.SlipPrintFinishCd = salesSlip.SlipPrintDivCd; // 伝票発行済区分
            salesSlip.SalesSlipPrintDate = ( salesSlip.SlipPrintDivCd == 1 ) ? DateTime.Today : DateTime.MinValue; // 売上伝票発行日
            salesSlip.SalesSlipUpdateCd = ( salesSlip.SalesSlipNum != ctDefaultSalesSlipNum ) ? 1 : 0;  // 売上伝票更新区分(0:未更新 1:更新あり)

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                salesDetail.EnterpriseCode = this._enterpriseCode;                                          // 企業コード
                salesDetail.SectionCode = salesSlip.SectionCode;                                            // 拠点コード
                salesDetail.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus;                                    // 受注ステータス
                salesDetail.SalesSlipNum = salesSlip.SalesSlipNum;                                          // 売上伝票番号
                salesDetail.SalesDate = salesSlip.SalesDate;                                                // 売上日付
                salesDetail.DeliGdsCmpltDueDate = DateTime.MinValue;                                        // 納品完了予定日
                salesDetail.SalesOrderDivCd = ( string.IsNullOrEmpty(salesDetail.WarehouseCode) ) ? 0 : 1;  // 売上在庫取寄せ区分
                if (salesDetail.DtlRelationGuid == Guid.Empty)
                {
                    salesDetail.DtlRelationGuid = Guid.NewGuid();
                }
                //>>>2010/10/01
                salesDetail.PrtGoodsNo = salesDetail.GoodsNo; // 印刷用品番
                salesDetail.PrtMakerCode = salesDetail.GoodsMakerCd; // 印刷用メーカーコード
                salesDetail.PrtMakerName = salesDetail.MakerName; // 印刷用メーカー名称
                //<<<2010/10/01
                salesDetailArrayList.Add(ConvertSalesSlip.ParamDataFromUIData(salesDetail));                // 明細情報
                CarManagementWork carManagementWork;
                this.GetCarManagementWorkFromCarManagementWorkList(out carManagementWork, salesDetail.CarRelationGuid, carManagementWorkList);
                if (carManagementWork != null) carManagementWorkListForSave.Add(carManagementWork);

                SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
                slipDetailAddInfoWork.CarRelationGuid = salesDetail.CarRelationGuid;
                slipDetailAddInfoWork.DtlRelationGuid = salesDetail.DtlRelationGuid;
                slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
            }

            #endregion

            // UIWrite制御ワーク
            paraList.Add(iOWriteCtrlOptWork);
            // 売上データ
            salesSlipDataList.Add(ConvertSalesSlip.ParamDataFromUIData(salesSlip));
            // 売上明細データ情報セット(CustomSerializeArrayList)
            if (salesDetailArrayList.Count > 0) salesSlipDataList.Add(salesDetailArrayList);
            // 車輌管理ワークオブジェクトリストセット
            if (carManagementWorkListForSave.Count > 0) salesSlipDataList.Add(carManagementWorkListForSave);
            // 伝票明細追加情報リストセット
            if (slipDetailAddInfoWorkList.Count > 0) salesSlipDataList.Add(slipDetailAddInfoWorkList);

            paraList.Add(salesSlipDataList);

            // UOE発注データ
            if (( uoeDataList != null ) && ( uoeDataList.Count > 0 ))
            {
                foreach (CustomSerializeArrayList data in uoeDataList)
                {
                    paraList.Add(data);
                }
            }

            retMessage = string.Empty;
            string retItemInfo = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object paraObj = (object)paraList;

            //status = 0;
            if (_iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            status = this._iIOWriteControlDB.Write(ref paraObj, out retMessage, out retItemInfo);

            //------------------------------------------------------
            // 保存後戻りデータ分割
            //------------------------------------------------------
            salesDataList = new ArrayList(); // 売上データ(伝票リスト情報)
            ArrayList acptDataList = new ArrayList(); // 受注データ(伝票リスト情報)
            ArrayList retStockSlipInfoList = new ArrayList();
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWriting((CustomSerializeArrayList)paraObj, out salesDataList, out acptDataList, out retStockSlipInfoList);
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlipWork salesSlipWork;
                SalesDetailWork[] salesDetailWorkArray;
                StockWork[] stockWorkArray;
                AcceptOdrCarWork[] acceptOdrCarWorkArray;
				List<StockWork> stockWorkList = new List<StockWork>();

                CustomSerializeArrayList salesData = ( salesDataList.Count > 0 ) ? (CustomSerializeArrayList)salesDataList[0] : new CustomSerializeArrayList();

                // CustomSerializeArrayList分割処理
                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWriting(salesData, out salesSlipWork, out salesDetailWorkArray, out stockWorkArray, out acceptOdrCarWorkArray);

                if (( stockWorkArray != null ) && ( stockWorkArray.Length > 0 ))
                {
                    stockWorkList.AddRange(stockWorkArray);
                }

                // 売上データワークオブジェクト→売上データオブジェクト
                salesSlip = ConvertSalesSlip.UIDataFromParamData(salesSlipWork);

                // 売上明細データワークオブジェクトリスト→売上明細データオブジェクトリスト
                salesDetailList = ConvertSalesSlip.UIDataFromParamData(salesDetailWorkArray);

                //// 計上元売上明細データワークオブジェクトリスト→計上元売上明細データオブジェクトリスト
                //List<SalesDetail> addUpSrcDetailList = ConvertSalesSlip.UIDataFromParamData(addUpOrgSalesDetailWorkArray);

                // 受注マスタ(車輌)ワークオブジェクト配列→受注マスタ(車輌)オブジェクトリスト
                List<AcceptOdrCar> acceptOdrCarList = ConvertSalesSlip.UIDataFromParamData(acceptOdrCarWorkArray);

                // データ調整
                this.AdjustSalesSaveDBData(ref salesSlip, ref salesDetailList);

                // データキャッシュ
                // 2009.06.18 >>>
                //this.Cache(salesSlip, salesSlip, salesDetailList, stockWorkList, acceptOdrCarList);
                this.Cache(salesSlip, salesSlip, salesDetailList, saveBeforeStockWorkList, acceptOdrCarList);
                // 2009.06.18 <<<

                // 車輌情報キャッシュ処理
                this.CacheCarInfo(salesSlip, salesDetailList, acceptOdrCarList);

                // 売上明細行初期行数追加処理
                this.AddEstimateDetailRowInitialRowCount();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                //salesSlipDataList = salesList;
                SalesSlipWork salesSlipWork;
                SalesDetailWork[] salesDetailWorkArray;
                StockWork[] stockWorkArray;
                AcceptOdrCarWork[] acceptOdrCarWorkArray;

                CustomSerializeArrayList salesData = ( salesDataList.Count > 0 ) ? (CustomSerializeArrayList)salesDataList[0] : new CustomSerializeArrayList();

                // CustomSerializeArrayList分割処理
                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWriting(salesData, out salesSlipWork, out salesDetailWorkArray, out stockWorkArray, out acceptOdrCarWorkArray);

                // 売上データワーククラス→売上データクラス
                salesSlip = ConvertSalesSlip.UIDataFromParamData(salesSlipWork);

                // 売上明細データワーククラス→売上明細データクラス
                List<SalesDetail> salesDetailLisk = ConvertSalesSlip.UIDataFromParamData(salesDetailWorkArray);

                // データ調整
                this.AdjustSalesSaveDBData(ref salesSlip, ref salesDetailList);

                // 売上明細行初期行数追加処理
                this.AddEstimateDetailRowInitialRowCount();
            }

            return status;
        }

		/// <summary>
		/// 見積データの削除を行います。
		/// </summary>
		/// <param name="salesSlip">仕入データオブジェクト</param>
		/// <param name="retMessage">メッセージ</param>
		/// <returns>STATUS</returns>
		public int DeleteDBData( SalesSlip salesSlip, out string retMessage )
		{
			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

            CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            IOWriteMAHNBDeleteWork deleteWork =new IOWriteMAHNBDeleteWork();
            
            deleteWork.EnterpriseCode=salesSlip.EnterpriseCode;
            deleteWork.UpdateDateTime=salesSlip.UpdateDateTime;
            deleteWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // 受注ステータス
            deleteWork.SalesSlipNum = salesSlip.SalesSlipNum.PadLeft(9, '0');
            paraList.Add(deleteWork);

			CustomSerializeArrayList dataList = new CustomSerializeArrayList();

			dataList.Add(iOWriteCtrlOptWork);
            dataList.Add(paraList);

            CustomSerializeArrayList detailList = new CustomSerializeArrayList();
            foreach (SalesDetail salesDetail in this._salesDetailDBDataList)
            {
                detailList.Add(ConvertSalesSlip.ParamDataFromUIData(salesDetail));
            }

            dataList.Add(detailList);

			object dataObj = (object)dataList;

			retMessage = "";
			string retItemInfo;
            if (_iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
			int status = this._iIOWriteControlDB.Delete(ref dataObj, out retMessage, out retItemInfo);

			return status;
		}

        /// <summary>
        /// 売上データのリードを行います。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <returns>STATUS</returns>
        public int ReadDBData( string enterpriseCode, int acptAnOdrStatus, string salesSlipNum )
        {
            SalesSlip salesSlip;
            List<SalesDetail> salesDetailList;
            List<StockWork> stockWorkList;
            List<AcceptOdrCar> acceptOdrCarList;
            return this.ReadDBData(enterpriseCode, acptAnOdrStatus, salesSlipNum, true, out salesSlip, out salesDetailList, out stockWorkList, out acceptOdrCarList);
        }

        /// <summary>
        /// 売上データのリードを行います。（オーバーロード）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="isCache">キャッシュ有無</param>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        /// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        /// <param name="acceptOdrCarList">受注マスタ（車輌）オブジェクトリスト</param>
        /// <returns></returns>
        public int ReadDBData( string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, bool isCache, out SalesSlip salesSlip, out List<SalesDetail> salesDetailList, out List<StockWork> stockWorkList, out List<AcceptOdrCar> acceptOdrCarList )
        {
            int status = this.ReadDBDataProc(ConstantManagement.LogicalMode.GetData0, enterpriseCode, acptAnOdrStatus, salesSlipNum, out salesSlip, out salesDetailList, out stockWorkList, out acceptOdrCarList);

            // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
            this._isDiscount = false;
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (salesSlip.EstimateDivide != 3)
                {
                    for (int i = 0; i < salesDetailList.Count; i++)
				    {
                        if (salesDetailList[i].SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount)
                        {
                            this._isDiscount = true;
                            return status;
                        }
				    }
                }
            }
            // --- ADD 2013/11/05 Y.Wakita ----------<<<<<

            if (( isCache ) && ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ))
            {
                // 入力モード設定処理
                this.SettingInputMode(ref salesSlip);

                // 売上データキャッシュ処理
                this.Cache(salesSlip, salesSlip, salesDetailList, stockWorkList, acceptOdrCarList);

            }
            return status;
        }

        /// <summary>
        /// 売上データのリードを行います。（オーバーロード）
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        /// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        /// <param name="acceptOdrCarList">受注マスタ（車輌）オブジェクトリスト</param>
        /// <returns></returns>
        public int ReadDBData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlip salesSlip, out List<SalesDetail> salesDetailList, out List<StockWork> stockWorkList, out List<AcceptOdrCar> acceptOdrCarList )
        {
            return this.ReadDBDataProc(logicalMode, enterpriseCode, acptAnOdrStatus, salesSlipNum, out salesSlip, out salesDetailList, out stockWorkList, out acceptOdrCarList);
        }

        /// <summary>
        /// 売上データのリードを行います。（オーバーロード）
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        /// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        /// <param name="acceptOdrCarList">受注マスタ（車輌）オブジェクトリスト</param>
        /// <returns></returns>
        private int ReadDBDataProc( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlip salesSlip, out List<SalesDetail> salesDetailList, out List<StockWork> stockWorkList, out List<AcceptOdrCar> acceptOdrCarList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            salesSlip = null;
            salesDetailList = null;
            stockWorkList = null;
            acceptOdrCarList = null;
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            IOWriteMAHNBReadWork readPara = new IOWriteMAHNBReadWork();
            readPara.EnterpriseCode = enterpriseCode;
            readPara.AcptAnOdrStatus = acptAnOdrStatus;
            readPara.SalesSlipNum = salesSlipNum;
            paraList.Add(readPara);

            #region ●リモート参照用パラメータ
            //------------------------------------------------------
            // リモート参照用パラメータ
            //------------------------------------------------------
            IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();
            paraList.Add(iOWriteCtrlOptWork);
            #endregion


            object paraObj = (object)paraList;
            object retObj1;
            object retObj2;
            if (_iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            status = this._iIOWriteControlDB.Read(ref paraObj, out retObj1, out retObj2);

            CustomSerializeArrayList retList1 = (CustomSerializeArrayList)retObj1;
            CustomSerializeArrayList retList2 = (CustomSerializeArrayList)retObj2;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlipWork salesSlipWork;                                // 売上データワークオブジェクト
                SalesDetailWork[] salesDetailWorkArray;                     // 売上明細データワークオブジェクト配列
                StockWork[] stockWorkArray;                                 // 在庫ワークデータオブジェクト配列
                AcceptOdrCarWork[] acceptOdrCarWorkArray;                   // 受注マスタ（車輌）ワークオブジェクト配列

                // CustomSerializeArrayList分割処理
                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForReading(retList1, out salesSlipWork, out salesDetailWorkArray, out stockWorkArray, out acceptOdrCarWorkArray);

                salesSlip = ConvertSalesSlip.UIDataFromParamData(salesSlipWork);
                salesDetailList = ConvertSalesSlip.UIDataFromParamData(salesDetailWorkArray);
                salesDetailList.Sort(new SalesDetail.SalesDetailComparer());
                acceptOdrCarList = ConvertSalesSlip.UIDataFromParamData(acceptOdrCarWorkArray);
                if (( stockWorkArray != null ) && ( stockWorkArray.Length > 0 ))
                {
                    if (stockWorkList == null) stockWorkList = new List<StockWork>();
                    stockWorkList.AddRange(stockWorkArray);
                }

#if DEBUG
                //XmlByteSerializer.Serialize(salesSlip, @"d:\SalesSlip.xml"); // ここ
                //XmlByteSerializer.Serialize(salesDetailList[0], @"d:\SalesDetail.xml"); // ここ
#endif
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 読込用売上データ調整処理
                this.AdjustSalesReadDBData(ref salesSlip, ref salesDetailList);
            }

            return status;

        }

        /// <summary>
        /// ＤＢから取得したデータをデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="baseSalesSlip"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="stockWorkList"></param>
        /// <param name="acceptOdrCarList"></param>
        public void Cache( SalesSlip salesSlip, SalesSlip baseSalesSlip, List<SalesDetail> salesDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList )
        {
            // データテーブルクリア処理
            this.ClearDetailTables();

            // 仕入データキャッシュ処理
            this.Cache(salesSlip);

            // 仕入データキャッシュ処理（DB読込データ）
            this.CacheDBData(salesSlip);

            // 売上明細データキャッシュ処理
            this.CacheEstimateDetail(salesSlip, baseSalesSlip, salesDetailList, this._estimateDetailDataTable);

            // 在庫データキャッシュ処理
            this.CacheStockInfo(stockWorkList);

            // 在庫調整
            this.EstimateDetailStockInfoAdjust(ref this._estimateDetailDataTable, ref this._primeInfoDataTable, this._stockInfoDataTable);

            // 車輌情報キャッシュ処理
            this.CacheCarInfo(baseSalesSlip, salesDetailList, acceptOdrCarList);

            // 売上明細データキャッシュ処理（DB読込データ）
            this.CacheEstimateDetailDBData(salesDetailList);

            // 見積明細行初期行数追加処理
            this.AddEstimateDetailRowInitialRowCount();

            // データ変更フラグプロパティをfalseにする
            this.IsDataChanged = false;

        }

		/// <summary>
		/// 在庫情報をキャッシュします。
		/// </summary>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		private void CacheStockInfo( List<StockWork> stockWorkList )
		{
			if (( stockWorkList != null ) && ( stockWorkList.Count > 0 ))
			{
				foreach (StockWork stockWork in stockWorkList)
				{
                    this.CacheStockInfo(stockWork);
				}
			}
		}

        /// <summary>
        /// 在庫情報をキャッシュします。
        /// </summary>
        /// <param name="stockWork">在庫ワークオブジェクトリスト</param>
        private void CacheStockInfo( StockWork stockWork )
        {
            if (stockWork != null)
            {
                EstimateInputDataSet.StockInfoRow row = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(stockWork.WarehouseCode.Trim(), stockWork.GoodsNo.Trim(), stockWork.GoodsMakerCd);
                if (row == null)
                {
                    row = this._stockInfoDataTable.NewStockInfoRow();
                    row.WarehouseCode = stockWork.WarehouseCode.Trim();
                    row.GoodsNo = stockWork.GoodsNo.Trim();
                    row.GoodsMakerCd = stockWork.GoodsMakerCd;
                    this._stockInfoDataTable.AddStockInfoRow(row);
                }
                row.WarehouseName = stockWork.WarehouseName;
                row.WarehouseShelfNo = stockWork.WarehouseShelfNo.Trim();
                row.ShipmentPosCnt = stockWork.ShipmentPosCnt;
            }
        }

        /// <summary>
        /// 在庫情報をキャッシュします。
        /// </summary>
        /// <param name="stockList">在庫情報オブジェクトリスト</param>
        // 2009.06.18 >>>
        //private void CacheStockInfo( List<Stock> stockList )
        public void CacheStockInfo(List<Stock> stockList)
        // 2009.06.18 <<<
        {
            if (( stockList != null ) && ( stockList.Count > 0 ))
            {
                foreach (Stock stock in stockList)
                {
                    this.CacheStockInfo(stock);
                }
            }
        }

		/// <summary>
		/// 在庫情報をキャッシュします。
		/// </summary>
		/// <param name="stock">在庫情報オブジェクト</param>
		private void CacheStockInfo( Stock stock )
		{
			if (stock != null)
			{
				EstimateInputDataSet.StockInfoRow row = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(stock.WarehouseCode.Trim(), stock.GoodsNo.Trim(), stock.GoodsMakerCd);
				if (row == null)
				{
					row = this._stockInfoDataTable.NewStockInfoRow();
					row.WarehouseCode = stock.WarehouseCode.Trim();
					row.GoodsNo = stock.GoodsNo.Trim();
					row.GoodsMakerCd = stock.GoodsMakerCd;
                    this._stockInfoDataTable.AddStockInfoRow(row);
                }
				row.WarehouseName = stock.WarehouseName;
				row.WarehouseShelfNo = stock.WarehouseShelfNo.Trim();
				row.ShipmentPosCnt = stock.ShipmentPosCnt;
			}
		}

        // 2009.06.18 Add >>>
        /// <summary>
        /// 在庫情報を一括取得します。
        /// </summary>
        /// <returns></returns>
        private List<StockWork> GetStockInfoList()
        {
            List<StockWork> retList = new List<StockWork>();
        
            foreach (EstimateInputDataSet.StockInfoRow row in this._stockInfoDataTable)
            {
                StockWork stockWork = new StockWork();
                stockWork.WarehouseCode = row.WarehouseCode;
                stockWork.WarehouseName = row.WarehouseName;
                stockWork.GoodsNo = row.GoodsNo;
                stockWork.GoodsMakerCd = row.GoodsMakerCd;
                stockWork.WarehouseShelfNo = row.WarehouseShelfNo;
                stockWork.ShipmentPosCnt = row.ShipmentPosCnt;
                retList.Add(stockWork);
            }

            return retList;
        }
        // 2009.06.18 Add <<<

		/// <summary>
		/// 見積明細データオブジェクトリストの現在庫数を調整します。
		/// </summary>
		/// <param name="estimateDetailDataTable">見積明細データテーブル</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		private void EstimateDetailStockInfoAdjust( ref EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable, List<StockWork> stockWorkList )
		{
			if (( stockWorkList != null ) && ( stockWorkList.Count > 0 ))
			{
				//foreach (EstimateInputDataSet.EstimateDetailRow stockDetailRow in estimateDetailDataTable.Rows)
				//{
				//    if (!string.IsNullOrEmpty(stockDetailRow.WarehouseCode.Trim()))
				//    {
				//        foreach (StockWork stockWork in stockWorkList)
				//        {
				//            if (( stockDetailRow.WarehouseCode.Trim() == stockWork.WarehouseCode.Trim() ) &&
				//                ( stockDetailRow.GoodsNo.Trim() == stockWork.GoodsNo.Trim() ) &&
				//                ( stockDetailRow.GoodsMakerCd == stockWork.GoodsMakerCd ))
				//            {
				//                stockDetailRow.ShipmentPosCnt = stockWork.ShipmentPosCnt;
				//                stockDetailRow.ShipmentPosCntDisplay = stockWork.ShipmentPosCnt;
				//                stockDetailRow.StockExist = true;
				//            }
				//        }
				//    }
				//}
			}
		}

		/// <summary>
		/// 見積明細データテーブルの現在庫数を調整します。
		/// </summary>
		public void EstimateDetailStockInfoAdjust()
		{
            this.EstimateDetailStockInfoAdjust(ref this._estimateDetailDataTable, ref this._primeInfoDataTable, this._stockInfoDataTable);
		}

        /// <summary>
        /// 対象部品の在庫が存在するかチェックします。
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <returns></returns>
        public bool ExistStockInfo( string goodsNo, int goodsMakerCd )
        {
            if (( string.IsNullOrEmpty(goodsNo) ) || ( goodsMakerCd == 0 ))
                return false;

            EstimateInputDataSet.StockInfoRow[] rows = (EstimateInputDataSet.StockInfoRow[])this._stockInfoDataTable.Select(string.Format("{0}='{1}' AND {2}={3}", this._stockInfoDataTable.GoodsNoColumn.ColumnName, goodsNo, this._stockInfoDataTable.GoodsMakerCdColumn.ColumnName, goodsMakerCd), this._stockInfoDataTable.WarehouseCodeColumn.ColumnName);
            return ( ( rows != null ) && ( rows.Length > 0 ) );
        }

		/// <summary>
		/// 見積明細データオブジェクトリストの現在庫数を調整します。
		/// </summary>
		/// <param name="estimateDetailDataTable">見積明細データテーブル</param>
        /// <param name="primeInfoDataTable">優良部品情報データたーブル</param>
        /// <param name="stockInfoDataTable"></param>
        /// <br>Update Note: 2013/02/20 譚洪</br>
        /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
        /// <br>             Redmine#34434 No.1180 現在庫数が０のとき在庫数が空白で表示されるの対応</br>
        private void EstimateDetailStockInfoAdjust( ref EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable, ref EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable, EstimateInputDataSet.StockInfoDataTable stockInfoDataTable )
        {
            if (estimateDetailDataTable.Rows.Count > 0)
            {
                try
                {
                    estimateDetailDataTable.BeginLoadData();
                    primeInfoDataTable.BeginLoadData();

                    // 見積テーブルの調整
                    EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])estimateDetailDataTable.Select(string.Format("{0}<>''OR {1}<>''", estimateDetailDataTable.WarehouseCodeColumn.ColumnName, estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName));

                    if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                    {
                        foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailRows)
                        {
                            if (!string.IsNullOrEmpty(row.WarehouseCode))
                            {
                                EstimateInputDataSet.StockInfoRow stockInfoRow = this.GetStockInfoRow(row.WarehouseCode, row.GoodsNo, row.GoodsMakerCd, stockInfoDataTable);
                                if (stockInfoRow != null)
                                {
                                    row.WarehouseShelfNo = stockInfoRow.WarehouseShelfNo;
                                    //row.ShipmentPosCnt = stockInfoRow.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                                    row.ShipmentPosCnt = stockInfoRow.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                                }
                            }

                            if (!string.IsNullOrEmpty(row.WarehouseCode_Prime))
                            {
                                EstimateInputDataSet.StockInfoRow stockInfoRow = this.GetStockInfoRow(row.WarehouseCode_Prime, row.GoodsNo_Prime, row.GoodsMakerCd_Prime, stockInfoDataTable);
                                if (stockInfoRow != null)
                                {
                                    row.WarehouseShelfNo_Prime = stockInfoRow.WarehouseShelfNo;
                                    //row.ShipmentPosCnt_Prime = stockInfoRow.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                                    row.ShipmentPosCnt_Prime = stockInfoRow.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                                }
                            }
                        }
                    }

                    // 優良部品テーブルの調整
                    EstimateInputDataSet.PrimeInfoRow[] primeInfoRows = (EstimateInputDataSet.PrimeInfoRow[])primeInfoDataTable.Select(string.Format("{0}<>''", primeInfoDataTable.WarehouseCodeColumn.ColumnName));

                    if (( primeInfoRows != null ) && ( primeInfoRows.Length > 0 ))
                    {
                        foreach (EstimateInputDataSet.PrimeInfoRow row in primeInfoRows)
                        {
                            EstimateInputDataSet.StockInfoRow stockInfoRow = this.GetStockInfoRow(row.WarehouseCode, row.GoodsNo, row.GoodsMakerCd, stockInfoDataTable);
                            if (stockInfoRow != null)
                            {
                                row.WarehouseShelfNo = stockInfoRow.WarehouseShelfNo;
                                //row.ShipmentPosCnt = stockInfoRow.ShipmentPosCnt; // DEL 2013/02/20 tanh Redmine#34434 No.1180 

                                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- >>>>>>>>>>>>
                                if (string.IsNullOrEmpty(row.WarehouseCode.Trim()))
                                {
                                    row.ShipmentPosCnt = string.Empty;
                                }
                                else
                                {
                                    row.ShipmentPosCnt = stockInfoRow.ShipmentPosCnt.ToString("N");
                                }
                                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- <<<<<<<<<<<<
                            }
                        }
                    }
                }
                finally
                {
                    estimateDetailDataTable.EndLoadData();
                    primeInfoDataTable.EndLoadData();
                }
            }
        }

        /// <summary>
        /// 在庫情報テーブルより、対象在庫の行オブジェクトを取得します。
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCode">メーカー</param>
        /// <param name="stockInfoTableDataTable">在庫情報テーブル</param>
        /// <returns></returns>
        private EstimateInputDataSet.StockInfoRow GetStockInfoRow( string warehouseCode, string goodsNo, int goodsMakerCode, EstimateInputDataSet.StockInfoDataTable stockInfoTableDataTable )
        {
            EstimateInputDataSet.StockInfoRow[] rows = (EstimateInputDataSet.StockInfoRow[])stockInfoTableDataTable.Select(string.Format("{0}='{1}' AND {2}='{3}' AND {4}={5}", stockInfoTableDataTable.WarehouseCodeColumn.ColumnName, warehouseCode, stockInfoTableDataTable.GoodsNoColumn.ColumnName, goodsNo, stockInfoTableDataTable.GoodsMakerCdColumn.ColumnName, goodsMakerCode));

            return ( ( rows != null ) && ( rows.Length > 0 ) ) ? rows[0] : null;
        }

        /// <summary>
        /// 在庫情報テーブルより、次倉庫の在庫行オブジェクトを取得します。
        /// </summary>
        /// <param name="warehouseCode"></param>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCode"></param>
        /// <param name="stockInfoTableDataTable"></param>
        /// <returns></returns>
        private EstimateInputDataSet.StockInfoRow GetNextWarehouseStockInfo( string warehouseCode, string goodsNo, int goodsMakerCode, EstimateInputDataSet.StockInfoDataTable stockInfoTableDataTable )
        {
            EstimateInputDataSet.StockInfoRow[] rows = (EstimateInputDataSet.StockInfoRow[])stockInfoTableDataTable.Select(string.Format("{0}='{1}' AND {2}={3} AND {4}>'{5}'", stockInfoTableDataTable.GoodsNoColumn.ColumnName, goodsNo, stockInfoTableDataTable.GoodsMakerCdColumn.ColumnName, goodsMakerCode, stockInfoTableDataTable.WarehouseCodeColumn.ColumnName, warehouseCode));

            return ( ( rows != null ) && ( rows.Length > 0 ) ) ? rows[0] : null;
        }

		/// <summary>
		/// 見積明細データオブジェクトリストの現在庫数を調整します。
		/// </summary>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="goodsNo">商品コード</param>
		/// <param name="goodsMakerCode">メーカーコード</param>
		private void EstimateDetailStockInfoAdjust( string warehouseCode, string goodsNo, int goodsMakerCode )
		{
			if (( string.IsNullOrEmpty(warehouseCode) ) || ( string.IsNullOrEmpty(goodsNo) ) || ( goodsMakerCode == 0 )) return;

            EstimateInputDataSet.StockInfoRow stockInfoTableRow = this.GetStockInfoRow(warehouseCode, goodsNo, goodsMakerCode, this._stockInfoDataTable);

			if (stockInfoTableRow != null)
			{
                //// 見積テーブルの調整
                //EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])estimateDetailDataTable.Select(string.Format("{0}=''AND {1}=''", estimateDetailDataTable.WarehouseCodeColumn.ColumnName, estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName));

                //if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                //{
                //    foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailRows)
                //    {
                //        if (!string.IsNullOrEmpty(row.WarehouseCode))
                //        {
                //            EstimateInputDataSet.StockInfoTableRow stockInfoRow = this.GetStockInfoRow(row.WarehouseCode, row.GoodsNo, row.GoodsMakerCd, stockInfoDataTable);
                //            if (stockInfoRow != null)
                //            {
                //                row.WarehouseShelfNo = stockInfoRow.WarehouseShelfNo;
                //                row.ShipmentPosCnt = stockInfoRow.ShipmentPosCnt;
                //            }
                //        }

                //        if (!string.IsNullOrEmpty(row.WarehouseCode_Prime))
                //        {
                //            EstimateInputDataSet.StockInfoTableRow stockInfoRow = this.GetStockInfoRow(row.WarehouseCode_Prime, row.GoodsNo_Prime, row.GoodsMakerCd_Prime, stockInfoDataTable);
                //            if (stockInfoRow != null)
                //            {
                //                row.WarehouseShelfNo_Prime = stockInfoRow.WarehouseShelfNo;
                //                row.ShipmentPosCnt_Prime = stockInfoRow.ShipmentPosCnt;
                //            }
                //        }
                //    }
                //}

                //// 優良部品テーブルの調整
                //EstimateInputDataSet.PrimeInfoRow[] primeInfoRows = (EstimateInputDataSet.PrimeInfoRow[])primeInfoDataTable.Select(string.Format("{0}<>''", primeInfoDataTable.WarehouseCodeColumn.ColumnName));

                //if (( primeInfoRows != null ) && ( primeInfoRows.Length > 0 ))
                //{
                //    foreach (EstimateInputDataSet.PrimeInfoRow row in primeInfoRows)
                //    {
                //        EstimateInputDataSet.StockInfoTableRow stockInfoRow = this.GetStockInfoRow(row.WarehouseCode, row.GoodsNo, row.GoodsMakerCd, stockInfoDataTable);
                //        if (stockInfoRow != null)
                //        {
                //            row.WarehouseShelfNo = stockInfoRow.WarehouseShelfNo;
                //            row.ShipmentPosCnt = stockInfoRow.ShipmentPosCnt;
                //        }
                //    }
                //}
			}
		}

		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region ■Public Methods

		#region チェック処理関連
		/// <summary>
		/// 保存用データのチェックを行います。
		/// </summary>
		/// <param name="mainMessage">メッセージ（out）</param>
		/// <param name="itemNameList">項目名称リスト</param>
		/// <param name="itemList">項目リスト</param>
        /// <param name="errorRowNoList">エラー行番号リスト</param>
		/// <returns>true:保存可 false:保存不可</returns>
        public bool CheckSaveData( out string mainMessage, out List<string> itemNameList, out List<string> itemList, out List<int> errorRowNoList )
		{
			mainMessage = "";
			itemNameList = new List<string>();
			itemList = new List<string>();
            errorRowNoList = new List<int>();
			bool insufficiency = false;
			bool overFlow = false;
            bool dishonestValue = false;

            // 拠点
            if (string.IsNullOrEmpty(this.SalesSlip.ResultsAddUpSecCd))
            {
                itemNameList.Add("拠点");
                itemList.Add("SectionCode");
                insufficiency = true;
            }

            // 担当者
            if (string.IsNullOrEmpty(this.SalesSlip.SalesEmployeeCd))
            {
                itemNameList.Add("担当者");
                itemList.Add("SalesEmployeeCd");
                insufficiency = true;
            }

            //// 得意先
            //if (( this.SalesSlip.CustomerCode == 0 ) &&
            //    ( string.IsNullOrEmpty(this.SalesSlip.CustomerName) ) &&
            //    ( string.IsNullOrEmpty(this.SalesSlip.CustomerName2) ) &&
            //    ( string.IsNullOrEmpty(this.SalesSlip.CustomerSnm) ))
            //{
            //    itemNameList.Add("得意先");
            //    itemList.Add("CustomerCode");
            //    insufficiency = true;
            //}


            // 見積日
            if (this.SalesSlip.SalesDate == DateTime.MinValue)
            {
                itemNameList.Add("見積日");
                itemList.Add("SalesDate");
                insufficiency = true;
            }

            // 見積有効期限
            if (this.SalesSlip.EstimateValidityDate == DateTime.MinValue)
            {
                itemNameList.Add("見積有効期限");
                itemList.Add("EstimateValidityDate");
                insufficiency = true;
            }

            // 見積有効期限＜見積日
            if (( this.SalesSlip.SalesDate != DateTime.MinValue ) && 
                ( this.SalesSlip.EstimateValidityDate != DateTime.MinValue ) && 
                ( this.SalesSlip.EstimateValidityDate < this.SalesSlip.SalesDate ))
            {
                itemNameList.Add("見積有効期限が見積日より前になっています。");
                itemList.Add("EstimateValidityDate");
                dishonestValue = true;
            }

            if (!this.ExistDetailData())
            {
                itemNameList.Add("明細");
                itemList.Add("EstimateDetail");
                insufficiency = true;
            }
            else
            {
                foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
                {
                    // 入力済み行に対してのチェック
                    if (this.ExistDetailInput(row))
                    {
                        if (Math.Abs(row.ShipmentCnt) > ctMAXVALUE_StockCountDetail)
                        {
                            itemNameList.Add(string.Format("{0}行の{1}が{2:###,##0.00}を超えています。", row.SalesRowNo, this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, ctMAXVALUE_StockCountDetail));
                            itemList.Add(string.Format("{0},{1}", this._estimateDetailDataTable.TableName, this._estimateDetailDataTable.ShipmentCntColumn.ColumnName));
                            if (!errorRowNoList.Contains(row.SalesRowNo)) errorRowNoList.Add(row.SalesRowNo);
                            overFlow = true;
                        }

                        if (Math.Abs(row.ShipmentCnt_Prime) > ctMAXVALUE_StockCountDetail)
                        {
                            itemNameList.Add(string.Format("{0}行の{1}が{2:###,##0.00}を超えています。", row.SalesRowNo, this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, ctMAXVALUE_StockCountDetail));
                            itemList.Add(string.Format("{0},{1}", this._estimateDetailDataTable.TableName, this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName));
                            if (!errorRowNoList.Contains(row.SalesRowNo)) errorRowNoList.Add(row.SalesRowNo);
                            overFlow = true;
                        }
                    }
                }
            }

            errorRowNoList.Sort();

			if (itemNameList.Count > 0)
			{
                // ----- ADD 2013/05/03 xujx for redmine#34803----->>>>>
                if (itemNameList.Contains("明細"))
                {
                    mainMessage += "有効な明細が入力されていません。";
                    itemNameList.Clear();
                    return false;
                }
                // ----- ADD 2013/05/03 xujx for redmine#34803-----<<<<<

				if (insufficiency)
				{
					mainMessage = "未入力の項目";
				}

				if (overFlow)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
					mainMessage += "有効桁数を超える項目";
				}

                if (dishonestValue)
                {
                    if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
                    mainMessage += "不正な値";
                }

				mainMessage += "が存在するため、印刷できません。" + "\r\n" + "\r\n";
				return false;
			}

			return true;

		}

		/// <summary>
		/// 仕入データの削除チェックを行います。
		/// </summary>
		/// <param name="salesSlip">仕入データオブジェクト</param>
		/// <param name="mainMessage">メインメッセージ（out）</param>
		/// <param name="itemNameList">項目名称リスト（out）</param>
		/// <param name="itemList">項目リスト（out）</param>
		/// <returns>true:削除可 false:削除不可</returns>
		public bool CheckDeleteData( SalesSlip salesSlip, out string mainMessage, out List<string> itemNameList, out List<string> itemList )
		{
			itemList = new List<string>();
			itemNameList = new List<string>();
			mainMessage = "";
			bool canDelete = true;

			if (canDelete)
			{
				// 赤伝区分「0:黒伝」
				if (salesSlip.DebitNoteDiv == 0)
				{
                    foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
                    {
                        if (( row.EditStatus == ctEDITSTATUS_AllReadOnly ) || 
                            ( row.EditStatus == ctEDITSTATUS_AllDisable ))
                        {
                            mainMessage = "編集不可能な明細行が存在する為、削除できません。";
                            canDelete = false;
                            break;
                        }
                        else if ((row.AlreadyAddUpCnt != 0)||(row.AlreadyAddUpCnt_Prime != 0))
                        {
                            mainMessage = "計上伝票が入力されている為、削除できません。";
                            canDelete = false;
                            break;
                        }
                    }
				}
				// 赤伝区分「1:赤伝」
				else if (salesSlip.DebitNoteDiv == 1)
				{
				}
				// 赤伝区分「2:元黒」
				else if (salesSlip.DebitNoteDiv == 2)
				{
					canDelete = false;
				}
			}

			return canDelete;
		}

        /// <summary>
        /// 数量チェック
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="message">メッセージ</param>
        /// <returns>CheckResult</returns>
        public CheckResult ShipmentCntCheck( int salesRowNo, TargetData targetData, out string message )
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;

            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null)
            {
                // 数量チェック用
                string basicCheckMsg = string.Empty;
                CheckResult basicCheckResult = CheckResult.Ok;

                // 数量チェック
                basicCheckResult = this.ShipmentCntBasicCheck(row, targetData, out basicCheckMsg);

                if (basicCheckResult != CheckResult.Ok)
                {
                    message = basicCheckMsg;
                    return basicCheckResult;
                }

            }
            return checkReslt;
        }


        /// <summary>
        /// 数量の基本チェック
        /// </summary>
        /// <param name="row">見積明細行</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="message">メッセージ</param>
        /// <returns>CheckResult</returns>
        private CheckResult ShipmentCntBasicCheck( EstimateInputDataSet.EstimateDetailRow row, TargetData targetData, out string message )
        {
            message = string.Empty;

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                CheckResult purePartsCheckResult = this.ShipmentCntBasicCheckProc(row.ShipmentCnt, row.AlreadyAddUpCnt, out message);

                if (purePartsCheckResult != CheckResult.Ok)
                {
                    return purePartsCheckResult;
                }
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                CheckResult primePartsCheckResult = this.ShipmentCntBasicCheckProc(row.ShipmentCnt_Prime, row.AlreadyAddUpCnt_Prime, out message);

                if (primePartsCheckResult != CheckResult.Ok)
                {
                    return primePartsCheckResult;
                }
            }

            return CheckResult.Ok;
        }

        /// <summary>
        /// 数量チェック
        /// </summary>
        /// <param name="shipmentCnt">数量</param>
        /// <param name="alreadyAddUpCnt">計上済み数量</param>
        /// <param name="message">メッセージ</param>
        /// <returns>CheckResult</returns>
        private CheckResult ShipmentCntBasicCheckProc( double shipmentCnt, double alreadyAddUpCnt, out string message )
        {
            message = string.Empty;
            // ゼロ入力チェック
            if (shipmentCnt == 0)
            {
                message = "数量が入力されていません。";
                return CheckResult.Error;
            }
            // 桁あふれチェック
            else if (Math.Abs(shipmentCnt) > Math.Abs(ctMAXVALUE_StockCountDetail))
            {
                message = "数量が最大桁数を超える為、入力できません。" + Environment.NewLine + string.Format("{1} 以下の値を入力して下さい。", Math.Abs(ctMAXVALUE_StockCountDetail));
                return CheckResult.Error;
            }
            else
            {
                // 計上済み数量がある場合はチェック
                if (( alreadyAddUpCnt != 0 ) && ( Math.Abs(shipmentCnt) < Math.Abs(alreadyAddUpCnt) ))
                {
                    message = "数量が計上済みの数量を下回る為、入力できません。" + Environment.NewLine + string.Format("{0} 以上の値を入力して下さい。", alreadyAddUpCnt);
                    return CheckResult.Error;
                }
            }

            return CheckResult.Ok;
        }

        /// <summary>
        /// 発注選択データが存在するかチェックします。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <returns>True:発注選択有り</returns>
        public bool ExistOrderSelect(int salesRowNo, TargetData targetData)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            return this.ExistOrderSelect(row, targetData);
        }

        /// <summary>
        /// 発注選択データが存在するかチェックします。
        /// </summary>
        /// <param name="salesRowNoList">行番号リスト</param>
        /// <returns>True:発注選択有り</returns>
        public bool ExistOrderSelect(List<int> salesRowNoList)
        {
            bool exist = false;
            foreach (int salesRowNo in salesRowNoList)
            {
                exist = this.ExistOrderSelect(salesRowNo);

                if (exist) break;
            }

            return exist;
        }

        /// <summary>
        /// 発注選択データが存在するかチェックします。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <returns>True:発注選択有り</returns>
        private bool ExistOrderSelect(int salesRowNo)
        {
            bool exist = false;

            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null)
            {
                exist = this.ExistOrderSelect(salesRowNo, TargetData.All);

                if (!exist)
                {
                    EstimateInputDataSet.PrimeInfoRow[] primeInfoRows = this.GetPrimeInfoRows(row.PrimeInfoRelationGuid);
                    if (( primeInfoRows != null ) && ( primeInfoRows.Length > 0 ))
                    {
                        foreach (EstimateInputDataSet.PrimeInfoRow primeInfoRow in primeInfoRows)
                        {
                            if (primeInfoRow.UOEOrderGuid != Guid.Empty)
                            {
                                exist = true;
                                break;
                            }
                        }
                    }
                }
            }
            return exist;
        }

        /// <summary>
        /// 発注選択データが存在するかチェックします。
        /// </summary>
        /// <param name="row">対象行</param>
        /// <param name="targetData">対象データ</param>
        /// <returns>True:発注選択有り</returns>
        private bool ExistOrderSelect(EstimateInputDataSet.EstimateDetailRow row, TargetData targetData)
        {
            bool exist = false;

            if (row != null)
            {
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    if (row.UOEOrderGuid != Guid.Empty)
                    {
                        exist = true;
                    }
                }
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    if (row.UOEOrderGuid_Prime != Guid.Empty)
                    {
                        exist = true;
                    }
                }
            }
            return exist;
        }

		#endregion

		/// <summary>
		/// 売上データの初期インスタンスを生成します。
		/// </summary>
		/// <param name="keepDate">true:日付保持する</param>
		public void CreateSalesSlipInitialData( bool keepDate )
		{
			string msg;
			if (!this._estimateInputInitDataAcs.InitialReadDataCheck(out msg))
			{
				throw new ApplicationException(msg);
			}

			AllDefSet allDefSet = this._estimateInputInitDataAcs.GetAllDefSet();
			EstimateDefSet estimateDefSet = this._estimateInputInitDataAcs.GetEstimateDefSet();
            TaxRateSet taxRateSet = this._estimateInputInitDataAcs.GetTaxRateSet();

            DateTime keepSalesDate = this._salesSlip.SalesDate;
            DateTime keepEstimateValidityDate = this._salesSlip.EstimateValidityDate;

			//------------------------------------------------
			// 売上データ
			//------------------------------------------------
			SalesSlip salesSlip = new SalesSlip();

			// 受注ステータス
			salesSlip.AcptAnOdrStatus = 10;

			// 担当者(ログイン担当者)
			salesSlip.SalesEmployeeCd = LoginInfoAcquisition.Employee.EmployeeCode.Trim();									// 仕入担当者コード[ログイン担当]
			salesSlip.SalesEmployeeNm = this._estimateInputInitDataAcs.GetName_FromEmployee(salesSlip.SalesEmployeeCd);		// 仕入担当者名称[ログイン担当]
            if (salesSlip.SalesEmployeeNm.Length > 16)
			{
                salesSlip.SalesEmployeeNm = salesSlip.SalesEmployeeNm.Substring(0, 16);
			}
             
            // 拠点コード
            salesSlip.SectionCode = this._estimateInputInitDataAcs.OwnSectionCode.Trim();
            salesSlip.SectionName = this._estimateInputInitDataAcs.OwnSectionName;
            // 売上入力拠点コード
            salesSlip.SalesInpSecCd = this._estimateInputInitDataAcs.OwnSectionCode.Trim();
            // 実績計上拠点コード
            salesSlip.ResultsAddUpSecCd = this._estimateInputInitDataAcs.OwnSectionCode.Trim();
            salesSlip.ResultsAddUpSecNm = this._estimateInputInitDataAcs.OwnSectionName;
            // 更新拠点コード
            salesSlip.UpdateSecCd = this._estimateInputInitDataAcs.OwnSectionCode.Trim();

			// 部門
			int subSectionCode;
			this._estimateInputInitDataAcs.GetSubSection_FromEmployeeDtl(salesSlip.SalesEmployeeCd, out subSectionCode);
			salesSlip.SubSectionCode = subSectionCode;																	// 部門コード
			salesSlip.SubSectionName = this._estimateInputInitDataAcs.GetName_FromSubSection(subSectionCode);			// 部門名称

            // 入力担当者(ログイン担当者)
            salesSlip.InputAgenCd = LoginInfoAcquisition.Employee.EmployeeCode.Trim(); ;
            salesSlip.InputAgenNm = this._estimateInputInitDataAcs.GetName_FromEmployee(salesSlip.InputAgenCd);
            if (salesSlip.InputAgenNm.Length > 16) salesSlip.InputAgenNm = salesSlip.InputAgenNm.Substring(0, 16);

			// 売上日
            salesSlip.SalesDate = ( keepDate ) ? keepSalesDate : DateTime.Today;
			// 見積有効期限
            salesSlip.EstimateValidityDate = ( keepDate ) ? keepEstimateValidityDate : salesSlip.SalesDate.AddMonths(estimateDefSet.EstimateValidityTerm);
			// 計上日
			salesSlip.AddUpADate = DateTime.MinValue;
			// 伝票検索日
			salesSlip.SearchSlipDate = DateTime.Today;
			// 伝票区分
			salesSlip.SalesSlipCd = 0;
			// 商品区分
			salesSlip.SalesGoodsCd = 0;
			// 売掛区分
			salesSlip.AccRecDivCd = 0;
			// 来勘区分
			salesSlip.DelayPaymentDiv = 0;
			// 見積区分
			salesSlip.EstimateDivide = 0;
			// 総額表示方法区分(0:総額表示しない 1:総額表示する)
			//salesSlip.TotalAmountDispWayCd = allDefSet.TotalAmountDispWayCd;
            salesSlip.TotalAmountDispWayCd = 0;
            // 消費税転嫁方式(0:伝票単位 1:明細単位 2:請求親 3:請求子 9:非課税)
            salesSlip.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;
            // 定価印刷区分
			salesSlip.ListPricePrintDiv = estimateDefSet.ListPricePrintDiv;
			// 品番印字区分
			salesSlip.PartsNoPrtCd = estimateDefSet.PartsNoPrtCd;
			// オプション印字区分
			salesSlip.OptionPringDivCd = estimateDefSet.OptionPringDivCd;
			// 掛率使用区分
			salesSlip.RateUseCode = estimateDefSet.RateUseCode;
			// 見積タイトル１
			salesSlip.EstimateTitle1 = estimateDefSet.EstimateTitle1;
			// 見積備考１
			salesSlip.EstimateNote1 = estimateDefSet.EstimateNote1;
			// 見積備考２
			salesSlip.EstimateNote2 = estimateDefSet.EstimateNote2;
			// 見積備考３
			salesSlip.EstimateNote3 = estimateDefSet.EstimateNote3;
            // 部品検索
            salesSlip.SearchMode= estimateDefSet.PartsSearchDivCd;
            // 見積データ作成区分
            salesSlip.EstimateDtCreateDiv = estimateDefSet.EstimateDtCreateDiv;
            // 売価率
            salesSlip.SalesRate = 0;

			// データキャッシュ処理
			this.Cache(salesSlip);

			// DB読込時データキャッシュ処理
			this.CacheDBData(salesSlip);
		}

        // ----  ADD 2011/07/25 ------>>>>
        /// <summary>
        /// 掛率優先区分をセットします。
        /// </summary>
        /// <remarks>掛率優先区分をセットします。</remarks>
        public void SetUnitPriceCalculation()
        {
            if (this._estimateInputInitDataAcs.GetCompanyInf() != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._estimateInputInitDataAcs.GetCompanyInf().RatePriorityDiv;
            }
        }
        // ----  ADD 2011/07/25 ------<<<<

        /// <summary>
        /// 伝票印刷設定用帳票ＩＤ取得処理
        /// </summary>
        /// <param name="slipInfo"></param>
        /// <returns></returns>
        private string GetSlipPrtSetPaperId(SalesSlip slipInfo)
        {
            string slipPrtSetPaperId = string.Empty;

            SlipPrtSet slipPrtSet = new SlipPrtSet();
            slipPrtSet = this.GetPrtSlipSet(SlipTypeController.SlipKind.EstimateForm, slipInfo.SectionCode.Trim(), slipInfo.CustomerCode);
            if (slipPrtSet != null) slipPrtSetPaperId = slipPrtSet.SlipPrtSetPaperId;
            return slipPrtSetPaperId;
        }

        /// <summary>
        /// 伝票印刷設定情報取得処理
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private SlipPrtSet GetPrtSlipSet(SlipTypeController.SlipKind slipKind, string sectionCode, int customerCode)
        {
            SlipTypeController stc = new SlipTypeController();
            stc.EnterpriseCode = this._enterpriseCode;
            stc.SlipPrtSetList = this._estimateInputInitDataAcs.SlipPrintSetList;
            stc.CustSlipMngList = this._estimateInputInitDataAcs.CustSlipMngList;

            SlipPrtSet slipPrtSet;
            int status = stc.GetSlipType(slipKind, out slipPrtSet, sectionCode, customerCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                slipPrtSet = null;
            }
            return slipPrtSet;
        }

		#region 伝票複写関連
		/// <summary>
        /// 複写伝票の仕入データオブジェクトを生成します。
        /// </summary>
		/// <param name="salesSlip">仕入データオブジェクト（ref）</param>
        public void CreateSlipCopyInfo( ref SalesSlip salesSlip )
        {
            if (salesSlip == null) return;

            salesSlip.CreateDateTime = DateTime.MinValue;
            salesSlip.UpdateDateTime = DateTime.MinValue;
            salesSlip.InputMode = ctINPUTMODE_Estimate_Normal;     // 入力モード ← 通常モード
            //salesSlip.DebitNLnkSalesSlNum = string.Empty;
            salesSlip.SalesSlipNum = ctDefaultSalesSlipNum;         // 売上伝票番号 ← 0
        }

        /// <summary>
        /// 複写伝票の見積明細データテーブルを生成します。
        /// </summary>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		public void CreateSlipCopyDetailInfo( List<StockWork> stockWorkList )
        {
			this.CreateSlipCopyDetailInfo(stockWorkList, this._estimateDetailDataTable);
        }

        /// <summary>
        /// 複写伝票の見積明細データテーブルを生成します。（オーバーロード）
        /// </summary>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        /// <param name="estimateDetailDataTable">見積明細データテーブルオブジェクト</param>
		public void CreateSlipCopyDetailInfo( List<StockWork> stockWorkList, EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable )
		{
			for (int i = 0; i < estimateDetailDataTable.Count; i++)
			{
				EstimateInputDataSet.EstimateDetailRow row = estimateDetailDataTable[i];

                row.SalesSlipNum = ctDefaultSalesSlipNum;	// 売上伝票番号 ← 0
                row.AcceptAnOrderNo = 0;                    // 受注番号 ← 0

                // 純正情報
                row.CommonSeqNo = 0;						// 共通通番 ← 0
                row.SalesSlipDtlNum = 0;					// 売上明細通番 ← 0
                row.AcptAnOdrStatusSrc = 0;					// 受注ステータス(元) ← 0
                row.SalesSlipDtlNumSrc = 0;					// 売上明細通番(元) ← 0
                row.SupplierFormalSync = -1;				// 仕入形式(同時) ← 0
                row.StockSlipDtlNumSync = 0;				// 仕入明細通番(同時) ← 0
                row.UOEOrderGuid = Guid.Empty;
                row.AcceptAnOrderCnt = 0;
                row.AcptAnOdrAdjustCnt = 0;
                row.AcptAnOdrRemainCnt = 0;

                // 優良情報
                row.CommonSeqNo_Prime = 0;						// 共通通番 ← 0
                row.SalesSlipDtlNum_Prime = 0;					// 売上明細通番 ← 0
                row.AcptAnOdrStatusSrc_Prime = 0;					// 受注ステータス(元) ← 0
                row.SalesSlipDtlNumSrc_Prime = 0;					// 売上明細通番(元) ← 0
                row.SupplierFormalSync_Prime = -1;				// 仕入形式(同時) ← 0
                row.StockSlipDtlNumSync_Prime = 0;				// 仕入明細通番(同時) ← 0
                row.AcceptAnOrderCnt_Prime = 0;
                row.AcptAnOdrAdjustCnt_Prime = 0;
                row.AcptAnOdrRemainCnt_Prime = 0;
                row.UOEOrderGuid_Prime = Guid.Empty;
			}
			this.EstimateDetailStockInfoAdjust();
		}
		#endregion

		/// <summary>
		/// 仕入データオブジェクトをインスタンス変数にキャッシュします。
		/// </summary>
		/// <param name="source">仕入データオブジェクト</param>
		public void Cache( SalesSlip source )
		{
            this._salesSlip = source.Clone();
            this._currentSalesSlipNum = source.SalesSlipNum.PadLeft(9, '0');
		}

		/// <summary>
		/// 売上データに得意先の情報を設定します。
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト（ref）</param>
		/// <param name="customerInfo">得意先マスタオブジェクト</param>
		public void DataSettingSalesSlip( ref SalesSlip salesSlip, CustomerInfo customerInfo )
		{
			if (salesSlip == null)
            {
                salesSlip.CustomerCode = 0;         // 得意先コード
                salesSlip.CustomerName = "";        // 得意先名称１
                salesSlip.CustomerName2 = "";       // 得意先名称２
                salesSlip.CustomerSnm = "";         // 略称
                salesSlip.HonorificTitle = "";      // 敬称
                salesSlip.OutputNameCode = 0;       // 諸口コード
                salesSlip.BusinessTypeCode = 0;     // 業種コード
                salesSlip.BusinessTypeName = "";    // 業種名称
                salesSlip.SalesAreaCode = 0;        // 販売エリアコード
                salesSlip.SalesAreaName = "";       // 販売エリア名称
                salesSlip.CustRateGrpCode = 0;      // 得意先掛率グループコード
                salesSlip.ClaimCode = 0;            // 請求先コード
                salesSlip.ClaimSnm = "";            // 請求先略称
                salesSlip.ClaimName = "";           // 請求先名称
                salesSlip.ClaimName2 = "";          // 請求先名称２
                salesSlip.ConsTaxRate = this._estimateInputInitDataAcs.GetTaxRate(salesSlip.SalesDate);                 // 消費税税率
                //salesSlip.TotalAmountDispWayCd = this._estimateInputInitDataAcs.GetAllDefSet().TotalAmountDispWayCd;    // 総額表示方法区分
                salesSlip.TotalAmountDispWayCd = 0;    // 総額表示方法区分
                salesSlip.ConsTaxLayMethod = this._estimateInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod;           // 消費税転嫁方式
                salesSlip.TtlAmntDispRateApy = this._estimateInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;       // 総額表示掛率適用区分
                salesSlip.DemandAddUpSecCd = "";    // 請求計上拠点コード
                SalesSlip.CreditMngCode = 0;        // 与信管理区分
                salesSlip.TotalDay = 0;				// 締日
                salesSlip.NTimeCalcStDate = 0;  	// 次回勘定開始日
				salesSlip.CarMngDivCd = 0;			// 車輌管理有無区分
            }
            else
            {

                if (customerInfo == null) customerInfo = new CustomerInfo();

                //-----------------------------------------------------
                // 請求先情報取得
                //-----------------------------------------------------
                CustomerInfo claim;
                if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();
                int status = this._customerInfoAcs.ReadDBData(customerInfo.EnterpriseCode, customerInfo.ClaimCode, true, out claim);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    claim = new CustomerInfo();
                }

                //-----------------------------------------------------
                // 得意先情報
                //-----------------------------------------------------
                salesSlip.CustomerCode = customerInfo.CustomerCode;			// 得意先コード
                salesSlip.CustomerName = customerInfo.Name;					// 得意先名称１
                salesSlip.CustomerName2 = customerInfo.Name2;				// 得意先名称２
                salesSlip.CustomerSnm = customerInfo.CustomerSnm;			// 略称
                salesSlip.HonorificTitle = customerInfo.HonorificTitle;		// 敬称
                salesSlip.OutputNameCode = customerInfo.OutputNameCode;		// 諸口コード
                salesSlip.BusinessTypeCode = customerInfo.BusinessTypeCode;	// 業種コード
                salesSlip.BusinessTypeName = customerInfo.BusinessTypeName;	// 業種名称
                salesSlip.SalesAreaCode = customerInfo.SalesAreaCode;		// 販売エリアコード
                salesSlip.SalesAreaName = customerInfo.SalesAreaName;		// 販売エリア名称
				salesSlip.CarMngDivCd = customerInfo.CarMngDivCd;			// 車輌管理有無区分

				salesSlip.AccRecDivCd = customerInfo.AccRecDivCd;			// 売掛区分

                if (( this._estimateInputInitDataAcs.GetSalesTtlSt().SectDspDivCd == 0 ) || ( this._estimateInputInitDataAcs.GetSalesTtlSt().SectDspDivCd == 2 ))
                {
                    if (!string.IsNullOrEmpty(customerInfo.MngSectionCode.Trim()))
                    {
                        salesSlip.ResultsAddUpSecCd = customerInfo.MngSectionCode.Trim();
                        SecInfoSet secInfoSet = this._estimateInputInitDataAcs.GetSecInfo(salesSlip.ResultsAddUpSecCd);
                        if (secInfoSet != null)
                        {
                            salesSlip.ResultsAddUpSecNm = secInfoSet.SectionGuideNm;
                        }
                    }
                    else
                    {
                        salesSlip.ResultsAddUpSecCd = this._estimateInputInitDataAcs.OwnSectionCode.Trim();
                        salesSlip.ResultsAddUpSecNm = this._estimateInputInitDataAcs.OwnSectionName;
                    }
                }

                //salesSlip.ClaimType = customerInfo.ClaimType; // 請求先区分
                //salesSlip.CustRateGrpCode = customerInfo.CustRateGrpCode; // 得意先掛率グループコード

                if (!string.IsNullOrEmpty(customerInfo.CustomerAgentCd))
                {
                    string employeeName = this._estimateInputInitDataAcs.GetName_FromEmployee(customerInfo.CustomerAgentCd);
                    if (!string.IsNullOrEmpty(employeeName.Trim()))
                    {
                        salesSlip.SalesEmployeeCd = customerInfo.CustomerAgentCd; // 担当者コード
                        salesSlip.SalesEmployeeNm = customerInfo.CustomerAgentNm; // 担当者名称
                    }
                }
				salesSlip.ConsTaxRate = this._estimateInputInitDataAcs.GetTaxRate(salesSlip.SalesDate); // 消費税税率

                //-----------------------------------------------------
                // 請求先情報
                //-----------------------------------------------------
                // 得意先マスタの総額表示方法参照区分が
                // ｢1:得意先参照」の場合は得意先マスタの「総額表示方法区分」を設定する
                // ｢0:全体設定参照」の場合は全体初期値設定マスタの「総額表示方法区分」を設定する
				//salesSlip.TotalAmountDispWayCd = ( claim.TotalAmntDspWayRef == 0 ) ? this._estimateInputInitDataAcs.GetAllDefSet().TotalAmountDispWayCd : claim.TotalAmountDispWayCd;
                salesSlip.TotalAmountDispWayCd = 0;
                
                // 消費税転嫁方式
				salesSlip.ConsTaxLayMethod = ( claim.CustCTaXLayRefCd == 1 ) ? claim.ConsTaxLayMethod : this._estimateInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod;

                // 総額表示掛率適用区分
				salesSlip.TtlAmntDispRateApy = this._estimateInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;

                salesSlip.ClaimCode = claim.CustomerCode;           // 請求先コード
                salesSlip.ClaimSnm = claim.CustomerSnm;             // 略称
                salesSlip.ClaimName = claim.Name;                   // 請求先名称
                salesSlip.ClaimName2 = claim.Name2;                 // 請求先名称２
                salesSlip.CreditMngCode = claim.CreditMngCode;      // 与信管理区分
                salesSlip.TotalDay = claim.TotalDay;				// 締日
                salesSlip.NTimeCalcStDate = claim.NTimeCalcStDate;	// 次回勘定開始日

                // 計上日の再セット
                this.SettingAddUpDate(ref salesSlip);

                string sectionCode;
                string sectionName;
				this._estimateInputInitDataAcs.GetOwnSeCtrlCode(claim.MngSectionCode, out sectionCode, out sectionName);
                salesSlip.DemandAddUpSecCd = sectionCode; // 請求計上拠点コード
            }
        }

		/// <summary>
		/// 計上日を設定します。
		/// </summary>
		/// <param name="salesSlip">仕入データオブジェクト</param>
		public void SettingAddUpDate( ref SalesSlip salesSlip )
		{
			DateTime addUpDate;
			int delayPaymentDiv;
			EstimateInputAcs.CalcAddUpDate(salesSlip.SalesDate, salesSlip.TotalDay, salesSlip.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

			salesSlip.AddUpADate = addUpDate;
			salesSlip.DelayPaymentDiv = delayPaymentDiv;
		}

		#region ●売上データの項目セット関連

		/// <summary>
		/// 所属情報設定処理
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		public void SalesEmployeeBelongInfoSetting( ref SalesSlip salesSlip )
		{
			string belongSecCd;
			int belongSubSecCd;
			this._estimateInputInitDataAcs.GetBelongInfo_FromEmployee(salesSlip.SalesEmployeeCd, out belongSecCd, out belongSubSecCd);

			salesSlip.ResultsAddUpSecCd = belongSecCd;

			salesSlip.SubSectionCode = belongSubSecCd;
			salesSlip.SubSectionName = this._estimateInputInitDataAcs.GetName_FromSubSection(belongSubSecCd);
		}

		#endregion

		/// <summary>
		/// 指定された売上データの状態を元に入力モードの設定を行います。
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		public void SettingInputMode(ref SalesSlip salesSlip)
		{
			salesSlip.InputMode = ctINPUTMODE_Estimate_Normal;
        }

        /// <summary>
        /// 現在の売上データ、見積明細テーブルから、金額等を集計した売上データ、売上明細データを取得します。
        /// </summary>
        /// <param name="dataGetMode">データ取得モード</param>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="detailAddInfoDictionary">明細追加情報ディクショナリ</param>
        private void GetCurrentData(DataGetMode dataGetMode, ref SalesSlip salesSlip, out List<SalesDetail> salesDetailList, out  Dictionary<int, Dictionary<string, object>> detailAddInfoDictionary)
        {

            // 表示テーブルから対象の売上データリストを取得
            this.GetUIDataFromTable(dataGetMode, this._estimateDetailDataTable, out salesDetailList, out detailAddInfoDictionary);

            // 合計金額計算
            this.TotalPriceSetting(ref salesSlip, salesDetailList);

            // 入金引当残高のセット
            if (salesSlip.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.NoTotalAmount)
            {
                // 総額表示しない
                switch (salesSlip.ConsTaxLayMethod)
                {
                    case 0: // 伝票転嫁
                    case 1: // 明細転嫁
                        salesSlip.DepositAlwcBlnce = salesSlip.SalesTotalTaxInc; // 入金引当残高
                        break;
                    case 2: // 請求親
                    case 3: // 請求子
                    case 9: // 非課税
                        // 総合計
                        salesSlip.DepositAlwcBlnce = salesSlip.ItdedSalesInTax + salesSlip.ItdedSalesOutTax + salesSlip.SalSubttlSubToTaxFre +
                            salesSlip.ItdedSalesDisOutTax + salesSlip.ItdedSalesDisInTax + salesSlip.ItdedSalesDisTaxFre +
                            salesSlip.SalAmntConsTaxInclu + salesSlip.SalesDisTtlTaxInclu;
                        break;
                }
            }

            #region 総額表示の場合の売上金額補正（コメントアウト）
#if false　
            // 総額表示の場合は、売上金額の補正
            if (salesSlip.TotalAmountDispWayCd == 1)
            {
                //----------------------------------------
                // 金額補正
                //----------------------------------------
                long salesTotalTaxInc = 0;      // 売上伝票合計（税込）
                long salesTotalTaxExc = 0;      // 売上伝票合計（税抜）
                long salesSubtotalTax = 0;      // 売上小計（税）
                long itdedSalesOutTax = 0;      // 売上外税対象額
                long itdedSalesInTax = 0;       // 売上内税対象額
                long salSubttlSubToTaxFre = 0;  // 売上小計非課税対象額
                long salesOutTax = 0;           // 売上金額消費税額（外税）
                long salAmntConsTaxInclu = 0;   // 売上金額消費税額（内税）
                long salesDisTtlTaxExc = 0;     // 売上値引金額計（税抜）
                long itdedSalesDisOutTax = 0;   // 売上値引外税対象額合計
                long itdedSalesDisInTax = 0;    // 売上値引内税対象額合計
                long itdedSalesDisTaxFre = 0;   // 売上値引非課税対象額合計
                long salesDisOutTax = 0;        // 売上値引消費税額（外税）
                long salesDisTtlTaxInclu = 0;   // 売上値引消費税額（内税）
                long totalCost = 0;             // 原価金額計
                long stockGoodsTtlTaxExc = 0;   // 在庫商品合計金額（税抜）
                long pureGoodsTtlTaxExc = 0;    // 純正商品合計金額（税抜）
                long taxAdjust = 0;             // 消費税調整額
                long balanceAdjust = 0;         // 残高調整額
                long salesPrtSubttlInc = 0;     // 売上部品小計（税込）
                long salesPrtSubttlExc = 0;     // 売上部品小計（税抜）
                long salesWorkSubttlInc = 0;    // 売上作業小計（税込）
                long salesWorkSubttlExc = 0;    // 売上作業小計（税抜）
                long itdedPartsDisInTax = 0;    // 部品値引対象額合計（税込）
                long itdedPartsDisOutTax = 0;   // 部品値引対象額合計（税抜）
                long itdedWorkDisInTax = 0;     // 作業値引対象額合計（税込）
                long itdedWorkDisOutTax = 0;    // 作業値引対象額合計（税抜）
                long grossProfitTotalMoney = 0; // 粗利合計金額

                int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 消費税端数処理コード

                this.CalculationSalesTotalPrice(
                    salesDetailList,
                    salesSlip.ConsTaxRate,
                    salesTaxFrcProcCd,
                    salesSlip.TotalAmountDispWayCd,
                    salesSlip.ConsTaxLayMethod,
                    out salesTotalTaxInc,
                    out salesTotalTaxExc,
                    out salesSubtotalTax,
                    out itdedSalesOutTax,
                    out itdedSalesInTax,
                    out salSubttlSubToTaxFre,
                    out salesOutTax,
                    out salAmntConsTaxInclu,
                    out salesDisTtlTaxExc,
                    out itdedSalesDisOutTax,
                    out itdedSalesDisInTax,
                    out itdedSalesDisTaxFre,
                    out salesDisOutTax,
                    out salesDisTtlTaxInclu,
                    out totalCost,
                    out stockGoodsTtlTaxExc,
                    out pureGoodsTtlTaxExc,
                    out balanceAdjust,
                    out taxAdjust,
                    out salesPrtSubttlInc,
                    out salesPrtSubttlExc,
                    out salesWorkSubttlInc,
                    out salesWorkSubttlExc,
                    out itdedPartsDisInTax,
                    out itdedPartsDisOutTax,
                    out itdedWorkDisInTax,
                    out itdedWorkDisOutTax,
                    out grossProfitTotalMoney);

                // 消費税の差異を計算：売上金額消費税額（外税）+ 売上金額消費税額（内税）+ 売上値引消費税額（外税）+ 売上値引消費税額（内税）- 売上小計（税）
                long differenceTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu - salesSubtotalTax;

                if (differenceTax != 0)
                {
                    int targetRowCount = 0;
                    foreach (SalesDetail salesDetail in salesDetailList)
                    {
                        if (salesDetail.TaxationDivCd != (int)CalculateTax.TaxationCode.TaxNone)
                        {
                            targetRowCount++;
                        }
                    }
                    if (targetRowCount == 0) return;

                    // 平均して振り分ける分
                    long av = differenceTax / targetRowCount;

                    // 先頭行から1円ずつ振り分ける行
                    long adjustCount = Math.Abs(differenceTax % targetRowCount);

                    int sign = ( differenceTax > 0 ) ? 1 : -1;

                    foreach (SalesDetail salesDetail in salesDetailList)
                    {
                        if (salesDetail.TaxationDivCd != (int)CalculateTax.TaxationCode.TaxNone)
                        {
                            salesDetail.SalesPriceConsTax -= ( av + ( ( adjustCount > 0 ) ? sign : 0 ) );
                            salesDetail.SalesMoneyTaxExc += ( av + ( ( adjustCount > 0 ) ? sign : 0 ) );
                            adjustCount--;
                        }
                    }
                    // 合計金額の再設定
                    this.TotalPriceSetting(ref salesSlip, salesDetailList);
                }
            }
#endif
            #endregion

            ////// 対象となるデータを売上データテーブルに変換して取得
            ////EstimateInputDataSet.SalesDetailDataTable salesDetailTable = this.GetSalesDetailTable(dataGetMode, this._estimateDetailDataTable);

            //// 売上データテーブルより売上合計金額を再計算
            //this.TotalPriceSetting(ref salesSlip, salesDetailTable);

            //// 売上データテーブルより売上データオブジェクトリストを取得
            //this.GetUIDataFromTable(salesDetailTable, out salesDetailList);
        }



        /// <summary>
        /// ＵＯＥ発注データのリストを取得します。
        /// </summary>
        /// <param name="uoeOrderDataList">ＵＯＥ発注データリスト</param>
        private void GetUOEOrderData(out ArrayList uoeOrderDataList)
        {
            uoeOrderDataList = null;
            // ログイン担当者の部門を取得
            int subSectionCode;
            this._estimateInputInitDataAcs.GetSubSection_FromEmployeeDtl(LoginInfoAcquisition.Employee.EmployeeCode, out subSectionCode);

            Dictionary<int, Supplier> supplierDictionary = new Dictionary<int, Supplier>();
            //ArrayList stockDetailList = new ArrayList();
            CustomSerializeArrayList stockDetailList = new CustomSerializeArrayList();
            ArrayList allStockDetailWorkArrayList = null;

            int seqNo = 1;
            foreach (EstimateInputDataSet.UOEOrderRow uoeOrderRow in this._uoeOrderDataTable.Rows)
            {
                ArrayList stockDetailWorkArrayList = new ArrayList();
                ArrayList uoeOrderDtlWorkArrayList = new ArrayList();
                ArrayList detailAddInofArrayList = new ArrayList();

                this.GetUOEOrderData(uoeOrderRow.OrderGuid, subSectionCode, ref supplierDictionary, out stockDetailWorkArrayList, out uoeOrderDtlWorkArrayList);

                if (( stockDetailWorkArrayList != null ) && ( uoeOrderDtlWorkArrayList != null ))
                {
                    if (allStockDetailWorkArrayList == null) allStockDetailWorkArrayList = new ArrayList();

                    allStockDetailWorkArrayList.AddRange(stockDetailWorkArrayList.ToArray());

                    //ArrayList uoeOrderData = new ArrayList();
                    CustomSerializeArrayList uoeOrderData = new CustomSerializeArrayList();

                    foreach (UOEOrderDtlWork uoeOrderDtlWork in uoeOrderDtlWorkArrayList)
                    {
                        SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
                        slipDetailAddInfoWork.DtlRelationGuid = uoeOrderDtlWork.DtlRelationGuid;
                        slipDetailAddInfoWork.SlipDtlRegOrder = seqNo;
                        detailAddInofArrayList.Add(slipDetailAddInfoWork);
                        seqNo++;
                    }

                    uoeOrderData.Add(uoeOrderDtlWorkArrayList);
                    uoeOrderData.Add(detailAddInofArrayList);

                    if (uoeOrderDataList == null) uoeOrderDataList = new ArrayList();
                    uoeOrderDataList.Add(uoeOrderData);
                }
            }

            if (( allStockDetailWorkArrayList != null ) && ( uoeOrderDataList != null ))
            {
                stockDetailList.Add(allStockDetailWorkArrayList);
                uoeOrderDataList.Add(stockDetailList);
            }
        }

        /// <summary>
        /// 指定した発注GUIDの発注データを取得します。
        /// </summary>
        /// <param name="uoeOrderGuid"></param>
        /// <param name="subSectionCode"></param>
        /// <param name="supplierDictionary"></param>
        /// <param name="stockDetailWorkArrayList"></param>
        /// <param name="uoeOrderDtlWorkArrayList"></param>
        private void GetUOEOrderData(Guid uoeOrderGuid, int subSectionCode, ref Dictionary<int, Supplier> supplierDictionary, out ArrayList stockDetailWorkArrayList, out ArrayList uoeOrderDtlWorkArrayList)
        {
            stockDetailWorkArrayList = null;
            uoeOrderDtlWorkArrayList = null;
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
            List<UOEOrderDtlWork> uoeOrderDtlWorkList = new List<UOEOrderDtlWork>();
            if (_supplierAcs == null) _supplierAcs = new SupplierAcs();

            EstimateInputDataSet.UOEOrderRow uoeOrderRow = this._uoeOrderDataTable.FindByOrderGuid(uoeOrderGuid);

            if (uoeOrderRow != null)
            {
                EstimateInputDataSet.UOEOrderDetailRow[] uoeOrderDetailRows = (EstimateInputDataSet.UOEOrderDetailRow[])this._uoeOrderDetailDataTable.Select(string.Format("{0}='{1}'", this._uoeOrderDetailDataTable.OrderGuidColumn.ColumnName, uoeOrderRow.OrderGuid));
                int rowNo = 1;
                foreach (EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow in uoeOrderDetailRows)
                {
                    StockDetailWork stockDetailWork = null;
                    UOEOrderDtlWork uoeOrderDtlWork = null;

                    // 見積の純正データから対象明細GUIDのデータを取得
                    EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = this.SelectEstimateDetailRows(string.Format("{0}='{1}'", this._estimateDetailDataTable.DtlRelationGuidColumn.ColumnName, uoeOrderDetailRow.DtlRelationGuid), this._estimateDetailDataTable);
                    if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                    {
                        this.GetUOEOrderDataFromRow(TargetData.PureParts, this._salesSlip, uoeOrderRow, uoeOrderDetailRow, estimateDetailRows[0], out stockDetailWork, out uoeOrderDtlWork);
                    }
                    else
                    {
                        // 見積の優良データから対象明細GUIDのデータを取得
                        estimateDetailRows = this.SelectEstimateDetailRows(string.Format("{0}='{1}'", this._estimateDetailDataTable.DtlRelationGuid_PrimeColumn.ColumnName, uoeOrderDetailRow.DtlRelationGuid), this._estimateDetailDataTable);
                        if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                        {
                            this.GetUOEOrderDataFromRow(TargetData.PrimeParts, this._salesSlip, uoeOrderRow, uoeOrderDetailRow, estimateDetailRows[0], out stockDetailWork, out uoeOrderDtlWork);
                        }
                        else
                        {
                            EstimateInputDataSet.PrimeInfoRow[] primeInfoRows = this.SelectPrimeInfoRows(string.Format("{0}='{1}'", this._primeInfoDataTable.DtlRelationGuidColumn.ColumnName, uoeOrderDetailRow.DtlRelationGuid), this._primeInfoDataTable);

                            //if (( primeInfoRows != null ) || ( primeInfoRows.Length > 0 ))//ADD 2013/05/07 xujx FOR Redmine#34803
                            if ((primeInfoRows != null) && (primeInfoRows.Length > 0)) //ADD 2013/05/07 xujx FOR Redmine#34803
                            {
                                this.GetUOEOrderDataFromRow(this._salesSlip, uoeOrderRow, uoeOrderDetailRow, primeInfoRows[0], out stockDetailWork, out uoeOrderDtlWork);
                            }
                        }
                    }

                    // データ行以外からセットする項目
                    if (( stockDetailWork != null ) && ( uoeOrderDtlWork != null ))
                    {
                        Supplier supplier = null;
                        if (supplierDictionary.ContainsKey(stockDetailWork.SupplierCd))
                        {
                            supplier = supplierDictionary[stockDetailWork.SupplierCd];
                        }
                        else
                        {
                            int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, stockDetailWork.SupplierCd);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                supplier = new Supplier();
                            }
                            supplierDictionary.Add(stockDetailWork.SupplierCd, supplier);
                        }
                        
                        Guid dtlRelationGuid = Guid.NewGuid();

                        // 仕入明細データの補足情報をセット
                        stockDetailWork.DtlRelationGuid = dtlRelationGuid;                              // 明細連結GUID
                        stockDetailWork.EnterpriseCode = this._enterpriseCode;                          // 企業コード
                        stockDetailWork.StockRowNo = rowNo;                                             // 行番号
                        stockDetailWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;  // 拠点コード
                        stockDetailWork.SubSectionCode = subSectionCode;                                // 部門コード
                        stockDetailWork.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;    // 仕入入力者コード
                        stockDetailWork.StockInputName = this._estimateInputInitDataAcs.GetName_FromEmployee(LoginInfoAcquisition.Employee.EmployeeCode);   // 仕入担当者名称
                        

                        // 仕入単価再計算
                        double fractionProcUnit;
                        int fractionProcCd;
                        this._estimateInputInitDataAcs.GetStockFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, supplier.StockCnsTaxFrcProcCd, 0, out fractionProcUnit, out fractionProcCd);
                        double targetMoney = (stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc) ? stockDetailWork.StockUnitTaxPriceFl:stockDetailWork.StockUnitPriceFl;
                        double unitPriceTaxExc, unitPriceTaxInc;
                        double unitPriceConsTax;
                        CalculateTax.CalculatePrice(stockDetailWork.TaxationCode, targetMoney, this._salesSlip.ConsTaxRate, fractionProcUnit, fractionProcCd, out unitPriceTaxExc, out unitPriceTaxInc, out unitPriceConsTax);
                        stockDetailWork.StockUnitPriceFl = unitPriceTaxExc;                             // 仕入単価（税抜き、浮動）
                        stockDetailWork.StockUnitTaxPriceFl = unitPriceTaxInc;                          // 仕入単価（税込、浮動）

                        // 仕入金額計算
                        long stockPriceTaxExc, stockPriceTaxInc, stockPriceConsTax;
                        this.CalculateCost(stockDetailWork.OrderCnt, targetMoney, stockDetailWork.TaxationCode, this._salesSlip.ConsTaxRate, supplier.StockMoneyFrcProcCd, fractionProcUnit, fractionProcCd, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);
                        stockDetailWork.StockPriceTaxInc = stockPriceTaxInc;
                        stockDetailWork.StockPriceTaxExc= stockPriceTaxExc;
                        stockDetailWork.StockPriceConsTax= stockPriceConsTax;

                        stockDetailWork.SupplierSnm = supplier.SupplierSnm;                             // 仕入先略称

                        // UOE発注データの補足情報をセット
                        uoeOrderDtlWork.DtlRelationGuid = dtlRelationGuid;                              // 明細連結GUID
                        uoeOrderDtlWork.UOESalesOrderRowNo = rowNo;                                     // オンライン行番号
                        uoeOrderDtlWork.EnterpriseCode = this._enterpriseCode;                          // 企業コード
                        uoeOrderDtlWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;  // 拠点コード
                        uoeOrderDtlWork.SubSectionCode = subSectionCode;                                // 部門コード
                        uoeOrderDtlWork.CashRegisterNo = this._estimateInputInitDataAcs.GetPosTerminalMg().CashRegisterNo;  // レジ番号
                        uoeOrderDtlWork.SupplierSnm = supplier.SupplierSnm;                             // 仕入先略称

                        // 売上データよりセット
                        uoeOrderDtlWork.EmployeeCode = this._salesSlip.SalesEmployeeCd;                 // 担当者コード
                        uoeOrderDtlWork.EmployeeName = this._salesSlip.SalesEmployeeNm;                 // 担当者名称
                        if (uoeOrderDtlWork.EmployeeName.Length > 30)
                        {
                            uoeOrderDtlWork.EmployeeName = uoeOrderDtlWork.EmployeeName.Substring(0, 30);
                        }
                        uoeOrderDtlWork.CustomerCode = this._salesSlip.CustomerCode;                    // 得意先コード
                        uoeOrderDtlWork.CustomerSnm = this._salesSlip.CustomerSnm;                      // 得意先名称

                        #region 桁数調整

                        if (stockDetailWork.StockAgentName.Length > 16)
                        {
                            stockDetailWork.StockAgentName = stockDetailWork.StockAgentName.Substring(0, 16);
                        }
                        if (stockDetailWork.StockInputName.Length > 16)
                        {
                            stockDetailWork.StockInputName = stockDetailWork.StockInputName.Substring(0, 16);
                        }

                        if (uoeOrderDtlWork.EmployeeName.Length > 30)
                        {
                            uoeOrderDtlWork.EmployeeName = uoeOrderDtlWork.EmployeeName.Substring(0, 30);
                        }
                        if (uoeOrderDtlWork.DeliveredGoodsDivNm.Length > 10)
                        {
                            uoeOrderDtlWork.DeliveredGoodsDivNm = uoeOrderDtlWork.DeliveredGoodsDivNm.Substring(0, 10);
                        }
                        if (uoeOrderDtlWork.DeliveredGoodsDivNm.Length > 10)
                        {
                            uoeOrderDtlWork.DeliveredGoodsDivNm = uoeOrderDtlWork.DeliveredGoodsDivNm.Substring(0, 10);
                        }
                        if (uoeOrderDtlWork.FollowDeliGoodsDivNm.Length > 10)
                        {
                            uoeOrderDtlWork.FollowDeliGoodsDivNm = uoeOrderDtlWork.FollowDeliGoodsDivNm.Substring(0, 10);
                        }
                        if (uoeOrderDtlWork.UOEResvdSectionNm.Length > 20)
                        {
                            uoeOrderDtlWork.UOEResvdSectionNm = uoeOrderDtlWork.UOEResvdSectionNm.Substring(0, 20);
                        }
                        #endregion

                        stockDetailWorkList.Add(stockDetailWork);
                        uoeOrderDtlWorkList.Add(uoeOrderDtlWork);

                    }
                }
            }

            if (( stockDetailWorkList.Count > 0 ) && ( uoeOrderDtlWorkList.Count > 0 ))
            {
                stockDetailWorkArrayList = new ArrayList();
                uoeOrderDtlWorkArrayList = new ArrayList();

                foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
                {
                    stockDetailWorkArrayList.Add(stockDetailWork);
                }

                foreach (UOEOrderDtlWork uoeOrderDtlWork in uoeOrderDtlWorkList)
                {
                    uoeOrderDtlWorkArrayList.Add(uoeOrderDtlWork);
                }
            }
        }

		/// <summary>
		/// 見積明細データテーブルの初期設定を行います。
		/// </summary>
		/// <param name="defaultRowCount">初期行数</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        public void EstimateDetailRowInitialSetting(int defaultRowCount)
		{
			this._estimateDetailDataTable.BeginLoadData();
			//this._estimateDetailDataTable.Rows.Clear();
			this.ClearDetailTables();
			this._salesDetailDBDataList.Clear();

			for (int i = 1; i <= defaultRowCount; i++)
			{
				EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.NewEstimateDetailRow();
				row.SalesSlipNum = this._currentSalesSlipNum;
                row.CarRelationGuid = Guid.Empty;
                row.DtlRelationGuid = Guid.Empty;
                row.DtlRelationGuid_Prime = Guid.Empty;
                row.DtlRelationGuid = Guid.NewGuid();
                row.DtlRelationGuid_Prime = Guid.NewGuid();
                row.UOEOrderGuid = Guid.Empty;
                row.UOEOrderGuid_Prime = Guid.Empty;
                row.PartsInfoLinkGuid = Guid.Empty;
                row.PartsInfoLinkGuid_Prime = Guid.Empty;
                row.PrimeInfoRelationGuid = Guid.Empty;
                //this.SettingEstimateDetailRowDtlRelationGuid(TargetData.All, row);//DEL 2011/02/14
                SettingEstimateDetailRowDtlRelationGuid(TargetData.All, row);//ADD 2011/02/14

                row.SalesRowNo = i;

				this._estimateDetailDataTable.AddEstimateDetailRow(row);
			}
			this._estimateDetailDataTable.EndLoadData();
		}

        /// <summary>
        /// 共通キーセット処理
        /// </summary>
        /// <param name="targetData">対象データ</param>
        /// <param name="row">対象行</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        // -----UPD 2011/02/14----->>>>>
        //private void SettingEstimateDetailRowDtlRelationGuid(TargetData targetData, EstimateInputDataSet.EstimateDetailRow row)
        private static void SettingEstimateDetailRowDtlRelationGuid(TargetData targetData, EstimateInputDataSet.EstimateDetailRow row)
        // -----UPD 2011/02/14-----<<<<<
        {
            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                row.DtlRelationGuid = Guid.NewGuid();
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                row.DtlRelationGuid_Prime = Guid.NewGuid();
            }
        }

		/// <summary>
		/// ＤＢに保存する仕入データを調整します。
		/// </summary>
		public void AdjustSaveData()
		{
            if (!this._estimateInputInitDataAcs.Opt_CarMng) this._salesSlip.CarMngDivCd = 0;
			List<int> deleteSalesRowNoList = new List<int>();
			foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
			{
                if (!this.ExistDetailInput(row))
				{
					deleteSalesRowNoList.Add(row.SalesRowNo);
				}
			}

			// 見積明細行削除処理
			this.DeleteEstimateDetailRow(deleteSalesRowNoList, true);
		}

		#region 明細情報設定

		#region 商品・在庫関連

        /// <summary>
        /// 見積明細商品情報クリア
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <param name="targetData"></param>
        public void EstimateDetailRowGoodsInfoClear( int salesRowNo ,TargetData targetData)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row == null) return;

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                row.RateBLGoodsCode = 0;
                row.RateBLGoodsName = string.Empty;
                row.RateGoodsRateGrpCd = 0;
                row.RateGoodsRateGrpNm = string.Empty;
                row.RateBLGroupCode = 0;
                row.RateBLGroupName = string.Empty;
                row.PartsInfoLinkGuid = Guid.Empty;

                row.WarehouseCode = string.Empty;
                row.WarehouseName = string.Empty;
                row.WarehouseShelfNo = string.Empty;
                row.ExistSetInfo = false;
                //row.ShipmentPosCnt = 0;// DEL 譚洪 Redmine#34994 2013/03/10
                row.ShipmentPosCnt = string.Empty;// ADD 譚洪 Redmine#34994 2013/03/10

                // 定価の掛率情報をクリア
                this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.ListPrice, TargetData.PureParts, false);

                // 原価単価の掛率情報をクリア
                this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.UnitCost, TargetData.PureParts, false);
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                row.RateBLGoodsCode_Prime = 0;
                row.RateBLGoodsName_Prime = string.Empty;
                row.RateGoodsRateGrpCd_Prime = 0;
                row.RateGoodsRateGrpNm_Prime = string.Empty;
                row.RateBLGroupCode_Prime = 0;
                row.RateBLGroupName_Prime = string.Empty;
                row.PartsInfoLinkGuid_Prime = Guid.Empty;
                row.WarehouseCode_Prime = string.Empty;
                row.WarehouseName_Prime = string.Empty;
                row.WarehouseShelfNo_Prime = string.Empty;
                row.ExistSetInfo_Prime = false;
                //row.ShipmentPosCnt_Prime = 0;// DEL 譚洪 Redmine#34994 2013/03/10
                row.ShipmentPosCnt_Prime = string.Empty;// ADD 譚洪 Redmine#34994 2013/03/10
                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                row.PrmSetDtlName2_Prime = string.Empty;
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 定価の掛率情報をクリア
                this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.ListPrice, TargetData.PrimeParts, false);
                // 原価単価の掛率情報をクリア
                this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.UnitCost, TargetData.PrimeParts, false);
            }
        }

        /// <summary>
        /// 見積明細商品情報クリア
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <param name="targetData"></param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        public void EstimateDetailRowNonGoodsInfoSetting( int salesRowNo, TargetData targetData )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row == null) return;

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                string goodsNo = row.GoodsNo;
                //this.ClearEstimateDetailRowPureInfo(row);//DEL 2011/02/14
                ClearEstimateDetailRowPureInfo(row);//ADD 2011/02/14

                row.GoodsNo = goodsNo;
                row.ShipmentCnt= 1;
                row.EditStatus = ctEDITSTATUS_AllOK;
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                string goodsNo = row.GoodsNo_Prime;
                //this.ClearEstimateDetailRowPrimeInfo(row);//DEL 2011/02/14
                ClearEstimateDetailRowPrimeInfo(row);//ADD 2011/02/14
                row.GoodsNo_Prime = goodsNo;
                row.ShipmentCnt_Prime = 1;
            }
        }

        /// <summary>
        /// 見積明細行にセット情報を設定します。
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="targetData"></param>
        /// <param name="goodsUnitData"></param>
        /// <param name="partsInfoLinkGuid"></param>
        /// <param name="unitPriceCalcRetList"></param>
        public void EstimateDetailRowSetGoodsSetting( int rowIndex, TargetData targetData, GoodsUnitData goodsUnitData, Guid partsInfoLinkGuid, List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable[rowIndex];
            string[] warehouseCodeArray = this.GetSearchWarehouseArray();

            this.ClearEstimateDetailRow(row.SalesRowNo);

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                this.EstimateDetailRowPurePartsSearchResultSetting(row.SalesRowNo, GoodsSearchDiv.PartsNoSerach, goodsUnitData, null, partsInfoLinkGuid, this.GetPartsInfoDataSet(partsInfoLinkGuid), unitPriceCalcRetList, warehouseCodeArray, false, 0);
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                this.EstimateDetailRowPrimePartsSearchResultSetting(row.SalesRowNo, GoodsSearchDiv.PartsNoSerach, goodsUnitData, this.GetPartsInfoDataSet(partsInfoLinkGuid), unitPriceCalcRetList, warehouseCodeArray, 0);
            }
        }

        /// <summary>
        /// 部品検索した結果を明細データ行オブジェクトに設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="goodsSearchDiv">商品検索区分</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="partsInfoDataSet">部品情報データセット(検索結果)</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="expandJoinInfo">true:結合情報展開する,false:結合情報展開しない</param>
        /// <param name="settingRowNoList">設定した行番号のリスト</param>
        /// <param name="overWriteRow">True:上書きする</param>
        /// <param name="searchBLCode">検索BL商品コード</param>
        /// <br>UpdateNote : 2011/02/14 liyp</br>
        /// <br>           ユーザー登録分商品に対する優良部品情報表示の修正（MANTIS: 14853）</br>
        public DataSettingResult EstimateDetailRowPurePartsSearchResultSetting(int salesRowNo, GoodsSearchDiv goodsSearchDiv, List<GoodsUnitData> goodsUnitDataList, PartsInfoDataSet partsInfoDataSet, List<UnitPriceCalcRet> unitPriceCalcRetList, bool expandJoinInfo, out List<int> settingRowNoList, bool overWriteRow, int searchBLCode)
        {
            DataSettingResult ret = DataSettingResult.Ok;
            try
            {
                this._estimateDetailDataTable.BeginLoadData();

                settingRowNoList = new List<int>();
                List<int> deletingSalesRowNoList = new List<int>();

                // 純正品番リストの取得
                // List<GenuinePartsRet> genuinePartsRetList = partsInfoDataSet.GetSelectedGenuineParts();//DEL 2011/02/14
                List<GenuinePartsRet> genuinePartsRetList = partsInfoDataSet.GetSelectedGenuineParts(true);//ADD 2011/02/14

                EstimateInputConstructionAcs estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();
//                                if (this._estimateDetailDataTable.Rows.Count < estimateInputConstructionAcs.DataInputCountValue)
                int addRowCnt = goodsUnitDataList.Count;
                int salesRowNoWk = salesRowNo;
                while (addRowCnt > 0)
                {
                    EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNoWk);

                    try
                    {
                        // 行が存在しない場合は新規に追加する
                        if (row == null)
                        {
                            //this.AddEstimateDetailRow();

                            //row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNoWk);
                            addRowCnt = 0;
                            ret = DataSettingResult.OverRowCount;
                            break;
                        }
                        else
                        {
                            if (!overWriteRow)
                            {
                                if (this.ExistDetailInput(row))
                                {
                                    continue;
                                }
                            }
                        }

                        settingRowNoList.Add(row.SalesRowNo);

                        deletingSalesRowNoList.Add(row.SalesRowNo);

                        row.AcceptChanges();

                        addRowCnt--;
                    }
                    finally
                    {
                        salesRowNoWk++;
                    }
                }

                // 見積明細行削除処理
                if (expandJoinInfo)
                {
                    this.ClearEstimateDetailRow(deletingSalesRowNoList);
                }

                // 検索対象倉庫配列を取得
                string[] warehouseCodeArray = this.GetSearchWarehouseArray();

                Guid partsInfoLinkGuid = Guid.NewGuid();


                for (int i = 0; i < goodsUnitDataList.Count; i++)
                {
                    if (settingRowNoList.Count - 1 < i) break;
                    GoodsUnitData goodsUnitData = goodsUnitDataList[i];

                    GenuinePartsRet genuinePartsRet = new GenuinePartsRet();

                    if (( genuinePartsRetList != null ) && ( genuinePartsRetList.Count > i ))
                    {
                        genuinePartsRet = genuinePartsRetList[i];
                    }

                    int targetSalesRowNo = settingRowNoList[i];

                    // 商品、在庫情報設定処理
                    this.EstimateDetailRowPurePartsSearchResultSetting(targetSalesRowNo, goodsSearchDiv, goodsUnitData, genuinePartsRet, partsInfoLinkGuid, partsInfoDataSet, unitPriceCalcRetList, warehouseCodeArray, expandJoinInfo, searchBLCode);
                }
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
            }
            return ret;
        }

        /// <summary>
        /// 部品検索した結果を明細データ行オブジェクトに設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="goodsSearchDiv">商品検索区分</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="partsInfoDataSet">部品情報データセット(検索結果)</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="expandJoinInfo">true:結合情報展開する,false:結合情報展開しない</param>
        /// <param name="settingRowNoList">設定した行番号のリスト</param>
        /// <param name="overWriteRow">True:上書きする</param>
        /// <param name="searchBLCode">検索BL商品コード</param>
        /// <br>UpdateNote : 2011/02/14 liyp</br>
        /// <br>           ユーザー登録分商品に対する優良部品情報表示の修正（MANTIS: 14853）</br>
        public DataSettingResult EstimateDetailRowBLPartsSearchResultSetting(int salesRowNo, GoodsSearchDiv goodsSearchDiv, List<GoodsUnitData> goodsUnitDataList, PartsInfoDataSet partsInfoDataSet, List<UnitPriceCalcRet> unitPriceCalcRetList, bool expandJoinInfo, out List<int> settingRowNoList, bool overWriteRow, int searchBLCode)
        {
            DataSettingResult ret = DataSettingResult.Ok;
            try
            {
                this._estimateDetailDataTable.BeginLoadData();

                settingRowNoList = new List<int>();
                List<int> deletingSalesRowNoList = new List<int>();

                // 純正品番リストの取得
                // List<GenuinePartsRet> genuinePartsRetList = partsInfoDataSet.GetSelectedGenuineParts(); //DEL 2011/02/14
                List<GenuinePartsRet> genuinePartsRetList = partsInfoDataSet.GetSelectedGenuineParts(true); //ADD 2011/02/14

                EstimateInputConstructionAcs estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();
                //                                if (this._estimateDetailDataTable.Rows.Count < estimateInputConstructionAcs.DataInputCountValue)
                int addRowCnt = goodsUnitDataList.Count;
                int salesRowNoWk = salesRowNo;
                while (addRowCnt > 0)
                {
                    EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNoWk);

                    try
                    {
                        // 行が存在しない場合は新規に追加する
                        if (row == null)
                        {
                            //this.AddEstimateDetailRow();

                            //row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNoWk);
                            addRowCnt = 0;
                            ret = DataSettingResult.OverRowCount;
                            break;
                        }
                        else
                        {
                            if (!overWriteRow)
                            {
                                if (this.ExistDetailInput(row))
                                {
                                    continue;
                                }
                            }
                        }

                        settingRowNoList.Add(row.SalesRowNo);

                        deletingSalesRowNoList.Add(row.SalesRowNo);

                        row.AcceptChanges();

                        addRowCnt--;
                    }
                    finally
                    {
                        salesRowNoWk++;
                    }
                }

                // 見積明細行削除処理
                if (expandJoinInfo)
                {
                    this.ClearEstimateDetailRow(deletingSalesRowNoList);
                }

                // 検索対象倉庫配列を取得
                string[] warehouseCodeArray = this.GetSearchWarehouseArray();

                Guid partsInfoLinkGuid = Guid.NewGuid();


                for (int i = 0; i < goodsUnitDataList.Count; i++)
                {
                    if (settingRowNoList.Count - 1 < i) break;
                    GoodsUnitData goodsUnitData = goodsUnitDataList[i];

                    GenuinePartsRet genuinePartsRet = new GenuinePartsRet();

                    if (( genuinePartsRetList != null ) && ( genuinePartsRetList.Count > i ))
                    {
                        genuinePartsRet = genuinePartsRetList[i];
                    }

                    int targetSalesRowNo = settingRowNoList[i];

                    if (( goodsUnitData.OfferKubun != 0 ) && 
                        ( goodsUnitData.OfferKubun != 1 ) && 
                        ( goodsUnitData.OfferKubun != 3 ) && 
                        ( goodsUnitData.OfferKubun != 5 ) )
                    {
                        // 商品、在庫情報設定処理
                        this.EstimateDetailRowPrimePartsSearchResultSetting(targetSalesRowNo, goodsSearchDiv, goodsUnitData, partsInfoDataSet, unitPriceCalcRetList, warehouseCodeArray, searchBLCode);
                    }
                    else
                    {
                        // 商品、在庫情報設定処理
                        this.EstimateDetailRowPurePartsSearchResultSetting(targetSalesRowNo, goodsSearchDiv, goodsUnitData, genuinePartsRet, partsInfoLinkGuid, partsInfoDataSet, unitPriceCalcRetList, warehouseCodeArray, expandJoinInfo, searchBLCode);
                    }
                }
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
            }
            return ret;
        }


        /// <summary>
        /// 純正部品を品番検索した結果を明細データ行オブジェクトに設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="goodsSearchDiv">商品検索区分</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="genuinePartsRet"></param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="partsInfoLinkGuid">部品情報リンクGUID</param>
        /// <param name="warehouseCodeArray">倉庫コード配列</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="expandJoinInfo">True:結合データ展開する</param>
        /// <param name="searchBLCode">検索BLコード</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        private void EstimateDetailRowPurePartsSearchResultSetting( int salesRowNo, GoodsSearchDiv goodsSearchDiv, GoodsUnitData goodsUnitData, GenuinePartsRet genuinePartsRet, Guid partsInfoLinkGuid, PartsInfoDataSet partsInfoDataSet, List<UnitPriceCalcRet> unitPriceCalcRetList, string[] warehouseCodeArray, bool expandJoinInfo, int searchBLCode )
        {
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "EstimateDetailRowPurePartsSearchResultSetting", "START");

            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                Guid primeInfoRelationGuid = row.PrimeInfoRelationGuid;

                // 結合情報連結GUIDがセットされている場合
                if (primeInfoRelationGuid != Guid.Empty)
                {
                    // 結合情報展開する場合は、既存の結合情報を削除する
                    if (expandJoinInfo)
                    {
                        this.DeletePrimeInfoRow(primeInfoRelationGuid);
                    }
                }
                else
                {
                    primeInfoRelationGuid = Guid.NewGuid();
                }

                // 純正部品情報をクリアする
                // --- UPD 2011/02/14---------->>>>>
                //this.ClearEstimateDetailRow(row, TargetData.PureParts);
                if (!string.IsNullOrEmpty(row.GoodsNo) || !string.IsNullOrEmpty(row.GoodsName) || row.GoodsMakerCd != 0)
                {
                    ClearEstimateDetailRow(row, TargetData.PureParts);
                }
                // --- UPD 2011/02/14----------<<<<<

                // 結合展開する場合は優良部品情報をクリア
                if (expandJoinInfo)
                {
                    // --- UPD 2011/02/14---------->>>>>
                    //this.ClearEstimateDetailRow(row, TargetData.PrimeParts);
                    if (!string.IsNullOrEmpty(row.GoodsNo_Prime) || !string.IsNullOrEmpty(row.GoodsName_Prime) || row.GoodsMakerCd_Prime != 0)
                    {
                        ClearEstimateDetailRow(row, TargetData.PrimeParts);
                    }
                    // --- UPD 2011/02/14----------<<<<<
                }

                this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitData, true);

                // 商品連結データからセットする項目
                row.GoodsNo = goodsUnitData.GoodsNo;                                // 品番
                row.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                      // メーカーコード
                row.MakerName = goodsUnitData.MakerName;                            // メーカー名称
                row.MakerKanaName = goodsUnitData.MakerKanaName;                    // メーカー名称カナ
                row.GoodsName = goodsUnitData.GoodsName;                            // 品名
                row.GoodsNameKana = goodsUnitData.GoodsNameKana;                    // 品名カナ
                row.GoodsKindCode = goodsUnitData.GoodsKindCode;                    // 商品属性
                row.GoodsLGroup = goodsUnitData.GoodsLGroup;                        // 商品大分類名称
                row.GoodsLGroupName = goodsUnitData.GoodsLGroupName;                // 商品大分類コード
                row.GoodsMGroup = goodsUnitData.GoodsMGroup;                        // 商品中分類コード
                row.GoodsMGroupName = goodsUnitData.GoodsMGroupName;                // 商品中分類名称
                row.BLGroupCode = goodsUnitData.BLGroupCode;                        // BLグループコード
                row.BLGroupName = goodsUnitData.BLGroupName;                        // BLグループコード名称
                row.BLGoodsCode = goodsUnitData.BLGoodsCode;                        // BL商品コード
                row.BLGoodsFullName = goodsUnitData.BLGoodsFullName;                // BL商品コード名称（全角）
                row.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;        // 自社分類コード
                row.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;        // 自社分類名称
                row.GoodsRateRank = goodsUnitData.GoodsRateRank;                    // 商品掛率ランク
                row.RateBLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL商品コード（掛率）
                row.RateBLGoodsName = goodsUnitData.BLGoodsFullName;                // BL商品コード名称（掛率）
                row.RateGoodsRateGrpCd = goodsUnitData.GoodsRateGrpCode;            // 商品掛率グループコード（掛率）
                row.RateGoodsRateGrpNm = goodsUnitData.GoodsRateGrpName;            // 商品掛率グループ名称（掛率）
                row.RateBLGroupCode = goodsUnitData.BLGroupCode;                    // BLグループコード（掛率）
                row.RateBLGroupName = goodsUnitData.BLGroupName;                    // BLグループ名称（掛率）
                row.TaxationDivCd = goodsUnitData.TaxationDivCd;                    // 課税区分
                // 2009/11/25 Add >>>
                row.SalesCode = goodsUnitData.SalesCode;                            // 販売区分コード
                row.SalesCdNm = goodsUnitData.SalesCodeName;                        // 販売区分名称
                // 2009/11/25 Add <<<

                row.ShipmentCnt = ( goodsUnitData.PartsQty == 0 ) ? 1 : goodsUnitData.PartsQty;
                // UPD 2013/01/09 T.Miyamoto ------------------------------>>>>>
                //row.ShipmentCnt = (goodsUnitData.SetQty == 0) ? 1 : goodsUnitData.SetQty; // 2012/10/25 ADD T.MIyamoto
                if ((GoodsKind)goodsUnitData.GoodsKindResolved == GoodsKind.Set)
                {
                    row.ShipmentCnt = (goodsUnitData.SetQty == 0) ? 1 : goodsUnitData.SetQty;
                }
                // UPD 2013/01/09 T.Miyamoto ------------------------------<<<<<
                row.PartsInfoLinkGuid = partsInfoLinkGuid;                          // 部品情報リンクGUID
                row.GoodsSearchDivCd = (int)goodsSearchDiv;                         // 商品検索区分

                // 2009/11/25 Add >>>
                if (( goodsSearchDiv == GoodsSearchDiv.BLPartsSearch ) && ( goodsUnitData.SearchBLCode != 0 ) && ( goodsUnitData.BLGoodsCode != goodsUnitData.SearchBLCode ))
                {
                    GoodsUnitData wkGoodsUnitData = goodsUnitData.Clone();

                    // 実績は検索BLコードで集計する
                    wkGoodsUnitData.BLGoodsCode = wkGoodsUnitData.SearchBLCode;
                    this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref wkGoodsUnitData, false);

                    row.BLGoodsCode = wkGoodsUnitData.BLGoodsCode;                    // BLコード
                    row.BLGoodsFullName = wkGoodsUnitData.BLGoodsFullName;            // BLコード名称(全角)
                    row.GoodsLGroup = wkGoodsUnitData.GoodsLGroup;                    // 商品大分類コード
                    row.GoodsLGroupName = wkGoodsUnitData.GoodsLGroupName;            // 商品大分類名称
                    row.GoodsMGroup = wkGoodsUnitData.GoodsMGroup;                    // 商品中分類コード
                    row.GoodsMGroupName = wkGoodsUnitData.GoodsMGroupName;            // 商品中分類名称
                    row.BLGroupCode = wkGoodsUnitData.BLGroupCode;                    // BLグループコード
                    row.BLGroupName = wkGoodsUnitData.BLGroupName;                    // BLグループコード名称
                    row.GoodsRateRank = wkGoodsUnitData.GoodsRateRank;                // 商品掛率ランク
                    row.SalesCode = wkGoodsUnitData.SalesCode;                        // 販売区分コード
                    row.SalesCdNm = wkGoodsUnitData.SalesCodeName;                    // 販売区分名称
                }
                // 2009/11/25 Add <<<

                // 印刷用BLコードの決定
                // BLコード検索、印刷用BL商品コード区分「検索」、BLコード有り
                int prtBLGoodsCode = 0;
                string prtBLGoodsName = string.Empty;
                if (( goodsSearchDiv == GoodsSearchDiv.BLPartsSearch ) &&
                    ( this._estimateInputInitDataAcs.GetSalesTtlSt().PrtBLGoodsCodeDiv == 1 ) &&
                    ( searchBLCode > 0 ))
                {
                    prtBLGoodsCode = searchBLCode;
                    string blGoodsHalfName;
                    this._estimateInputInitDataAcs.GetName_FromBLGoods(searchBLCode, out prtBLGoodsName, out blGoodsHalfName);
                }
                else
                {
                    prtBLGoodsCode = goodsUnitData.BLGoodsCode;
                    prtBLGoodsName = goodsUnitData.BLGoodsFullName;
                }
                row.PrtBLGoodsCode = prtBLGoodsCode;                                // BL商品コード（印刷）
                row.PrtBLGoodsName = prtBLGoodsName;                                // BL商品コード名称（印刷）

                row.SupplierCd = goodsUnitData.SupplierCd;                          // 仕入先コード
                row.SupplierSnm = goodsUnitData.SupplierSnm;                        // 仕入先名称

                row.ExistSetInfo = partsInfoDataSet.UsrSetParts.SetExist(goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo);   // セット存在有無

                row.PrintSelect = true;                                                 // 印刷(純正をTrue)

                row.PrimeInfoRelationGuid = primeInfoRelationGuid;                      // 

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                GoodsPrice goodsPrice = this._estimateInputInitDataAcs.GetGoodsPrice(this._salesSlip.SalesDate, goodsUnitData);
                if (goodsPrice != null) row.OpenPriceDiv = goodsPrice.OpenPriceDiv; // オープン価格区分
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 価格情報の設定
                this.EstimateDetailRowPriceInfoSettingFromUnitPriceCalcRetList(TargetData.PureParts, row, unitPriceCalcRetList, false, false, true, true);
                //this.EstimateDetailRowPurePartsPriceInfoSettingFromUnitPriceCalcRetList(row, unitPriceCalcRetList, false, true, true);

                // 原価計算
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "EstimateDetailRowPurePartsSearchResultSetting", "原価計算 START");
                this.CalculateCost(TargetData.PureParts, row);
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "EstimateDetailRowPurePartsSearchResultSetting", "原価計算 END");

                // 純正部品検索結果からセットする項目
                if (genuinePartsRet != null)
                {
                    row.StandardName = genuinePartsRet.StandardName;                        // 規格
                    row.CtlgPartsNo = genuinePartsRet.CtlgPartsNo;                          // カタログ品番
                    // --- UPDATE 2012/05/08 ----------------->>>>>>>>>>>>>>>>>>>
                    // row.SpecialNote = genuinePartsRet.PartsOpNm;                            // 特記事項
                    row.SpecialNote = genuinePartsRet.GoodsSpecialNote;                        // 特記事項
                    // ADD 2012/09/13 2012/09/19配信 SCM障害一覧№125対応 ------------------------------>>>>>
                    if (genuinePartsRet.GoodsSpecialNote.Length > 40) row.SpecialNote = genuinePartsRet.GoodsSpecialNote.Substring(0, 40);
                    // ADD 2012/09/13 2012/09/19配信 SCM障害一覧№125対応 ------------------------------<<<<<
                    // --- UPDATE 2012/05/08 -----------------<<<<<<<<<<<<<<<<<<<

                    // 結合データ展開
                    if (expandJoinInfo)
                    {
                        EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "EstimateDetailRowPurePartsSearchResultSetting", "結合データ展開 START");
                        //this.MakePrimeInfoTable(primeInfoRelationGuid, goodsSearchDiv, genuinePartsRet, partsInfoLinkGuid, partsInfoDataSet, unitPriceCalcRetList, warehouseCodeArray, searchBLCode);
                        this.MakePrimeInfoTable(primeInfoRelationGuid, goodsSearchDiv, genuinePartsRet, partsInfoLinkGuid, partsInfoDataSet, warehouseCodeArray, searchBLCode);
                        EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "EstimateDetailRowPurePartsSearchResultSetting", "結合データ展開 END");
                    }
                    else
                    {
                        this.SettingEstimateDetailRowFromPrimeInfoRow(ref row, this.GetSelectedPrimeInfoRow(primeInfoRelationGuid));
                    }
                }

                this.CachePartsInfoDataSet(partsInfoLinkGuid, partsInfoDataSet);        // 部品情報キャッシュ

                if (( goodsUnitData.StockList != null ) &&
                    ( goodsUnitData.StockList.Count > 0 ))
                {
                    this.CacheStockInfo(goodsUnitData.StockList);

                    if (( warehouseCodeArray != null ) && ( warehouseCodeArray.Length > 0 ))
                    {
                        Stock stock = this._estimateInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray);
                        if (stock != null)
                        {
                            row.WarehouseCode = stock.WarehouseCode.Trim();
                            row.WarehouseName = stock.WarehouseName;
                            row.WarehouseShelfNo = stock.WarehouseShelfNo;
                            //row.ShipmentPosCnt = stock.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                            row.ShipmentPosCnt = stock.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                        }
                    }
                }

                row.EditStatus = ctEDITSTATUS_AllOK;                                    // 変更可能ステータス

                // 商品情報をキャッシュ
                this.CacheGoodsUnitData(goodsUnitData);

                row.AcceptChanges();

                // 優良情報が無い場合はBLコード、品名に純正情報をセットする
                if (string.IsNullOrEmpty(row.GoodsName_Prime))
                {
                    row.GoodsName_Prime = row.GoodsName;
                    row.BLGoodsCode_Prime = row.BLGoodsCode;
                }
            }
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "EstimateDetailRowPurePartsSearchResultSetting", "END");
        }

        // --- UPD 2010/08/27 ---------->>>>>
        // --- ADD 2010/08/05 ---------->>>>>
        /// <summary>
        /// 優良品の結合情報が存在している場合,結合情報を切り替えて表示設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <br>Update Note: 2011/12/19 鄧潘ハン</br>
        /// <br>           : データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正</br>
        public void CandidateSetting(int salesRowNo)
        {
            EstimateInputDataSet.EstimateDetailRow estimateDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (estimateDetailRow != null)
            {
                Guid primeInfoRelationGuid = estimateDetailRow.PrimeInfoRelationGuid;

                // 結合情報連結GUIDがセットされている場合
                if (primeInfoRelationGuid != Guid.Empty)
                {

                    EstimateInputDataSet.PrimeInfoRow primeInfoRow = this.PrimeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeInfoRelationGuid, estimateDetailRow.JoinDispOrder);
                    if (primeInfoRelationGuid == Guid.Empty || primeInfoRow == null) return;

                    EstimateInputDataSet.PrimeInfoRow row = null;
                    if (this.SelectPrimeInfo(primeInfoRelationGuid, estimateDetailRow.JoinDispOrder + 1) == false)
                    {
                        this.SelectPrimeInfo(primeInfoRelationGuid, 1);
                        row = this.PrimeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeInfoRelationGuid, 1);
                    }
                    else
                    {
                        this.SelectPrimeInfo(primeInfoRelationGuid, estimateDetailRow.JoinDispOrder);
                        row = this.PrimeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeInfoRelationGuid, estimateDetailRow.JoinDispOrder);
                    }

                    if (row != null)
                    {
                        #region 標準価格選択ウインドウ
                        // 画面入力値の標準価格選択が「する」の場合
                        if (this._priceSelectValue == 1)
                        {
                            // 抽出条件設定
                            GoodsCndtn cndtn = new GoodsCndtn();
                            cndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                            cndtn.SectionCode = this.SalesSlip.ResultsAddUpSecCd;
                            cndtn.GoodsMakerCd = row.GoodsMakerCd;
                            cndtn.GoodsNo = row.GoodsNo;

                            PartsInfoDataSet _partsInfoDataSet = null;
                            ArrayList custRateGroupList;
                            ArrayList displayDivList;

                            // 結合元検索
                            if (this._primeRelationDic.ContainsKey(row.PrimeInfoRelationGuid))
                            {
                                _partsInfoDataSet = this._primeRelationDic[row.PrimeInfoRelationGuid];
                            }

                            _partsInfoDataSet.GoodsNoSel = this.GoodsEstimateNo;// ADD 鄧潘ハン 2011/12/19 Redmine#8034

                            if (_partsInfoDataSet == null) return;
                            // 得意先掛率グループコードマスタの全件取得
                            this.GetCustRateGrpList(out custRateGroupList, cndtn.EnterpriseCode);
                            // 標準価格選択設定マスタの取得
                            this.GetDisplayDivList(out displayDivList, cndtn.EnterpriseCode);
                            List<PriceSelectSet> priceSelectSet = new List<PriceSelectSet>((PriceSelectSet[])displayDivList.ToArray(typeof(PriceSelectSet)));

                            //結合元検索ﾃﾞﾘｹﾞｰﾄ
                            if (_partsInfoDataSet.SearchPartsForSrcParts == null)
                            {
                                _partsInfoDataSet.SearchPartsForSrcParts += new PartsInfoDataSet.SearchPartsForSrcPartsCallBack(this.SearchPartsForSrcParts);
                            }
                            //得意先掛率ｸﾞﾙｰﾌﾟ取得ﾃﾞﾘｹﾞｰﾄ
                            if (_partsInfoDataSet.GetCustRateGrp == null)
                            {
                                _partsInfoDataSet.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(this.GetCustRateGrp);
                            }
                            //表示区分取得ﾃﾞﾘｹﾞｰﾄ
                            if (_partsInfoDataSet.GetDisplayDiv == null)
                            {
                                _partsInfoDataSet.GetDisplayDiv += new PartsInfoDataSet.GetDisplayDivCallBack(this.GetDisplayDiv);
                            }
                            // 結合元検索
                            _partsInfoDataSet.SettingSrcPartsInfo(cndtn);
                            if (_partsInfoDataSet.PartsInfoDataSetSrcParts == null) return;
                            // 得意先掛率ｸﾞﾙｰﾌﾟｺｰﾄﾞ取得
                            _partsInfoDataSet.SettingCustRateGrpCode(custRateGroupList, this.SalesSlip.CustomerCode, row.GoodsNo, row.GoodsMakerCd);
                            PartsInfoDataSet.UsrGoodsInfoRow urrentRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.GoodsNo);
                            // 表示区分取得ﾞ取得
                            _partsInfoDataSet.SettingDisplayDiv(priceSelectSet, row.GoodsNo, row.GoodsMakerCd, row.BLGoodsCode, this.SalesSlip.CustomerCode, urrentRow.CustRateGrpCode);
                            urrentRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.GoodsNo);
                            // 標準価格選択ウインドウ表示処理
                            SelectionListPrice selectionListPrice = new SelectionListPrice(row.GoodsMakerCd, row.MakerName, row.GoodsNo, row.GoodsName, row.ListPriceTaxExcFl, _partsInfoDataSet, urrentRow.PriceSelectDiv);
                            DialogResult dr = selectionListPrice.ShowDialog();

                            if (dr == DialogResult.Cancel)
                            {
                                return;
                            }

                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.GoodsNo);
                            // 1:定価(選択)を使用する
                            if (usrGoodsInfoRow.SelectedListPriceDiv == 1)
                            {
                                row.ListPriceDisplay = usrGoodsInfoRow.SelectedListPrice;

                                EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])this.EstimateDetailDataTable.Select(string.Format("{0}='{1}'", this.EstimateDetailDataTable.PrimeInfoRelationGuidColumn.ColumnName, row.PrimeInfoRelationGuid));
                                if ((estimateDetailRows != null) && (estimateDetailRows.Length > 0))
                                {

                                    estimateDetailRows[0].ListPriceDisplay_Prime = usrGoodsInfoRow.SelectedListPrice;
                                    estimateDetailRows[0].AcceptChanges();
                                    this.EstimateDetailRowListPriceSetting(estimateDetailRows[0].SalesRowNo, EstimateInputAcs.TargetData.PrimeParts, EstimateInputAcs.PriceInputType.PriceDisplay, estimateDetailRows[0].ListPriceDisplay_Prime);// ADD 2009/11/13

                                }
                                row.AcceptChanges();
                            }
                        }

                        #endregion
                    }

                    this._primeInfoDataTable.EndLoadData();
                }
            }

        }
        // --- UPD 2010/08/27 ----------<<<<<

        /// <summary>
        /// 優良品の結合情報が存在判断します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <returns>優良品の結合情報が　false:存在なし、true:存在する</returns>
        public bool isCanCandidateSetting(int salesRowNo)
        {
            bool primeInfoResult = false;

            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                Guid primeInfoRelationGuid = row.PrimeInfoRelationGuid;

                // 結合情報連結GUIDがセットされている場合
                if (primeInfoRelationGuid != Guid.Empty && this._primeInfoDataTable != null)
                {
                    EstimateInputDataSet.PrimeInfoRow primeInfoRow = this._primeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeInfoRelationGuid, 1);

                    if (primeInfoRow != null)
                    {
                        primeInfoResult = true;
                    }
                }
            }

            return primeInfoResult;
        }
        // --- ADD 2010/08/05 ----------<<<<<

        /// <summary>
        /// 結合元情報を取得する
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="goodsCndt">商品抽出条件クラス</param>
        /// <param name="partsInfoDataSet">部品検索結果データクラス</param>
        /// <param name="goodsUnitDataList">商品連結データクラス</param>
        /// <param name="msg">メッセージ</param>
        /// <remarks>
        /// <br>Note       : 結合元情報を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// </remarks>
        public void SearchPartsForSrcParts(int mode, GoodsCndtn goodsCndt, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out String msg)
        {
            SearchPartsForSrcPartsProc(mode, goodsCndt, out partsInfoDataSet, out goodsUnitDataList, out msg);

        }

        /// <summary>
        /// 結合元情報を取得する
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="goodsCndt">商品抽出条件クラス</param>
        /// <param name="partsInfoDataSet">部品検索結果データクラス</param>
        /// <param name="goodsUnitDataList">商品連結データクラス</param>
        /// <param name="msg">メッセージ</param>
        /// <remarks>
        /// <br>Note       : 結合元情報を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// <br>Update note :2009/11/05 呉元嘯</br>
        /// <br>Date       : Redmine#1134対応</br>
        /// </remarks>
        private void SearchPartsForSrcPartsProc(int mode, GoodsCndtn goodsCndt, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out String msg)
        {
            GoodsAcs goodsAcs = new GoodsAcs();
            //----------ADD 2009/11/05--------->>>>>
            partsInfoDataSet = null;
            goodsUnitDataList = null;
            msg = string.Empty;
            //----------ADD 2009/11/05---------<<<<<

            goodsAcs.SearchInitial(this._enterpriseCode, this._salesSlip.ResultsAddUpSecCd, out msg);

            goodsAcs.SearchPartsForSrcParts(mode, goodsCndt, out partsInfoDataSet, out goodsUnitDataList, out msg);

            //----------ADD 2009/11/05--------->>>>>
            // 価格適用日のセット
            partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;
            // 価格計算デリゲート追加
            if (partsInfoDataSet.CalculatePrice == null)
            {
                partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(CalcPriceForSearch);
            }
            //----------ADD 2009/11/05---------<<<<<
            // ADD 2010/05/17 品名表示対応 ---------->>>>>
            if (partsInfoDataSet.GetBLGoodsInfo == null)
            {
                partsInfoDataSet.SetPartsNameDisplayPattern(this._estimateInputInitDataAcs.GetSalesTtlSt());

                // BL商品情報
                if (partsInfoDataSet.GetBLGoodsInfo == null)
                {
                    partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                }
            }
            // ADD 2010/05/17 品名表示対応 ----------<<<<<
        }

        /// <summary>
        /// 得意先掛率グループコード取得
        /// </summary>
        /// <param name="custRateGrpCodeList">得意先掛率グループコードリスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループコードを取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// </remarks>
        public void GetCustRateGrp(ArrayList custRateGrpCodeList, Int32 customerCode, Int32 goodsMakerCode, out Int32 custRateGrpCode)
        {
            // 得意先掛率グループコードを取得する
            GetCustRateGrpProc(custRateGrpCodeList, customerCode, goodsMakerCode, out custRateGrpCode);

        }

        /// <summary>
        /// 得意先掛率グループコード取得
        /// </summary>
        /// <param name="custRateGrpCodeList">得意先掛率グループコードリスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループコードを取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// <br>Update note: 2011/02/14 yangmj</br>
        /// <br>Date       : 得意先掛率グループ取得処理の修正</br>
        /// </remarks>
        private void GetCustRateGrpProc(ArrayList custRateGrpCodeList, Int32 customerCode, Int32 goodsMakerCode, out Int32 custRateGrpCode)
        {
            // --- UPD 2011/02/14 ---------->>>>>
            //// 得意先掛率グループコードを取得する
            //this._custRateGroupAcs.GetCustRateGrp(custRateGrpCodeList, customerCode, goodsMakerCode, out custRateGrpCode);

            custRateGrpCode = -1;

            // 純正／優良情報取得
            int pureCode = (goodsMakerCode < 1000) ? 0 : 1;

            // 単独キー判定
            foreach ( CustRateGroup custRateGroup in custRateGrpCodeList )
            {
                if ( (customerCode == custRateGroup.CustomerCode) && 
                     (goodsMakerCode == custRateGroup.GoodsMakerCd) && 
                     (pureCode == custRateGroup.PureCode) && 
                     (custRateGroup.CustRateGrpCode >= 0) )
                {
                    custRateGrpCode = custRateGroup.CustRateGrpCode;
                    return;
                }
            }

            // 共通キー判定
            foreach ( CustRateGroup custRateGroup in custRateGrpCodeList )
            {
                if ( (customerCode == custRateGroup.CustomerCode) && (0 == custRateGroup.GoodsMakerCd) && (pureCode == custRateGroup.PureCode) )
                {
                    custRateGrpCode = custRateGroup.CustRateGrpCode;
                    return;
                }
            }
            // --- UPD 2011/02/14 ----------<<<<<

        }

        /// <summary>
        /// 得意先掛率グループコードマスタの全件取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先掛率グループコードリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループコードマスタの全件を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// </remarks>
        public void GetCustRateGrpList(out ArrayList custRateGroupList, String enterpriseCode)
        {
            // 得意先掛率グループコードマスタの全件取得
            GetCustRateGrpListProc(out custRateGroupList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);

        }

        /// <summary>
        /// 得意先掛率グループコードマスタの全件取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先掛率グループコードリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループコードマスタの全件を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             得意先掛率グループ取得処理の修正</br>
        /// </remarks>
        private void GetCustRateGrpListProc(out ArrayList custRateGroupList, String enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            // --- UPD 2011/02/14 ---------->>>>>
            //// 得意先掛率グループコードマスタの全件取得
            //this._custRateGroupAcs.Search(out custRateGroupList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
            if (_custRateGroupList == null)
            {
                // 得意先掛率グループコードマスタの全件取得
                this._custRateGroupAcs.Search(out custRateGroupList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
                _custRateGroupList = custRateGroupList;
            }
            else
            {
                custRateGroupList = _custRateGroupList;
            }
            // --- UPD 2011/02/14 ----------<<<<<
        }
        // --- ADD 2011/02/14---------->>>>>
        /// <summary>
        /// 得意先掛率グループ設定の全件を保持するリストを更新する処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ設定の全件を保持するリストを更新する</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/02/14</br>
        /// </remarks>
        public void ReNewalCustRateGroupList(string enterpriseCode)
        {
            if (_custRateGroupList != null)
            {
                _custRateGroupList.Clear();
                _custRateGroupList = null;
            }

            GetCustRateGrpListProc(out _custRateGroupList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // --- ADD 2011/02/14----------<<<<<

        /// <summary>
        /// 標準価格選択設定マスタの全件取得処理
        /// </summary>
        /// <param name="displayDivList">標準価格マスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 標準価格選択設定マスタの全件を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// </remarks>
        public void GetDisplayDivList(out ArrayList displayDivList, String enterpriseCode)
        {
            // 標準価格選択設定マスタの全件取得処理
            GetDisplayDivListProc(out displayDivList, enterpriseCode);

        }

        /// <summary>
        /// 標準価格選択設定マスタの全件取得処理
        /// </summary>
        /// <param name="displayDivList">標準価格マスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 標準価格選択設定マスタの全件を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             得意先掛率グループ取得処理の修正</br>
        /// </remarks>
        private void GetDisplayDivListProc(out ArrayList displayDivList, String enterpriseCode)
        {
            // --- UPD 2011/02/14---------->>>>>
            //// 標準価格選択設定マスタの全件取得処理
            //this._priceSelectSetAcs.Search( out displayDivList, enterpriseCode );
            if (_displayDivList == null)
            {
                // 標準価格選択設定マスタの全件取得処理
                this._priceSelectSetAcs.Search(out displayDivList, enterpriseCode);
                _displayDivList = displayDivList;
            }
            else
            {
                displayDivList = _displayDivList;
            }
            // --- UPD 2011/02/14----------<<<<<
        }

        // --- ADD 2011/02/14---------->>>>>
        /// <summary>
        /// 標準価格選択設定マスタの全件取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 標準価格選択設定マスタの全件を取得する</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/02/14</br>
        /// </remarks>
        public void ReNewalDisplayDivList(string enterpriseCode)
        {
            if (_displayDivList != null)
            {
                _displayDivList.Clear();
                _displayDivList = null;
            }

            this._priceSelectSetAcs.Search(out _displayDivList, enterpriseCode);
        }
        // --- ADD 2011/02/14----------<<<<<

        /// <summary>
        /// 標準価格選択区分取得
        /// </summary>
        /// <param name="displayDivList">表示区分リスト</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="priceSelectDiv">標準価格選択区分</param>
        /// <remarks>
        /// <br>Note       : 標準価格選択区分を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// </remarks>
        public void GetDisplayDiv(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32 priceSelectDiv)
        {
            // 標準価格選択区分を取得する
            GetDisplayDivProc(displayDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, out priceSelectDiv);

        }

        /// <summary>
        /// 標準価格選択区分取得
        /// </summary>
        /// <param name="displayDivList">表示区分リスト</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="priceSelectDiv">標準価格選択区分</param>
        /// <remarks>
        /// <br>Note       : 標準価格選択区分を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// </remarks>
        private void GetDisplayDivProc(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32 priceSelectDiv)
        {
            // 標準価格選択区分を取得する
            this._priceSelectSetAcs.GetDisplayDiv(displayDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, out priceSelectDiv);

        }

        /// <summary>
        /// 画面の標準価格選択取得
        /// </summary>
        /// <param name="priceSelectValue">priceSelectValue</param>
        /// <returns>標準価格選択</returns>
        /// <remarks>
        /// <br>Note       : 画面の標準価格選択を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/10/22</br>
        /// </remarks>
        public void SetPriceSelectComboBox(int priceSelectValue)
        {
            this._priceSelectValue = priceSelectValue;
        }

        public EstimateInputDataSet.EstimateDetailRow GetRow(int salesRowNo)
        {
            return this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
        }

        /// <summary>
        /// 優良部品を品番検索した結果を明細データ行オブジェクトに設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="goodsSearchDiv">商品検索区分</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="partsInfoDataSet">部品情報データセット(検索結果)</param>
        /// <param name="searchBLGoodsCode">検索BL商品コード</param>
        /// <param name="settingSalesRowNoList">設定した行リスト</param>
        public void EstimateDetailRowPrimePartsSearchResultSetting( int salesRowNo, GoodsSearchDiv goodsSearchDiv, GoodsUnitData goodsUnitData, PartsInfoDataSet partsInfoDataSet, List<UnitPriceCalcRet> unitPriceCalcRetList, out List<int> settingSalesRowNoList, int searchBLGoodsCode )
        {
            try
            {
                this._estimateDetailDataTable.BeginLoadData();

                List<int> deletingSalesRowNoList = new List<int>();
                settingSalesRowNoList = new List<int>();

                settingSalesRowNoList.Add(salesRowNo);

                // 検索対象倉庫配列を取得
                string[] warehouseCodeArray = this.GetSearchWarehouseArray();

                this.EstimateDetailRowPrimePartsSearchResultSetting(salesRowNo, goodsSearchDiv, goodsUnitData, partsInfoDataSet, unitPriceCalcRetList, warehouseCodeArray, searchBLGoodsCode);

            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
            }
        }

        /// <summary>
        /// 優良部品を品番検索した結果を明細データ行オブジェクトに設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="goodsSearchDiv">商品検索区分</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="warehouseCodeArray">倉庫配列</param>
        /// <param name="searchBLGoodsCode">検索BL商品コード</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>              標準価格選択ＵＩ表示の速度改善</br>
        private void EstimateDetailRowPrimePartsSearchResultSetting(int salesRowNo, GoodsSearchDiv goodsSearchDiv, GoodsUnitData goodsUnitData, PartsInfoDataSet partsInfoDataSet, List<UnitPriceCalcRet> unitPriceCalcRetList, string[] warehouseCodeArray, int searchBLGoodsCode)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            List<int> deleteRowNoList = new List<int>();

            if (row != null)
            {
                // 明細情報クリア
                //this.ClearEstimateDetailRow(row, TargetData.PrimeParts);//DEL 2011/02/14
                ClearEstimateDetailRow(row, TargetData.PrimeParts);//ADD 2011/02/14

                if (goodsUnitData == null)
                {
                    //
                }
                else
                {
                    row.GoodsNo_Prime = goodsUnitData.GoodsNo;                                // 品番
                    row.GoodsMakerCd_Prime = goodsUnitData.GoodsMakerCd;                      // メーカーコード
                    row.MakerName_Prime = goodsUnitData.MakerName;                            // メーカー名称
                    row.MakerKanaName_Prime = goodsUnitData.MakerKanaName;                    // メーカー名称カナ
                    row.GoodsName_Prime = goodsUnitData.GoodsName;                            // 品名
                    row.GoodsNameKana_Prime = goodsUnitData.GoodsNameKana;                    // 品名カナ
                    row.GoodsKindCode_Prime = goodsUnitData.GoodsKindCode;                    // 商品属性
                    row.GoodsLGroup_Prime = goodsUnitData.GoodsLGroup;                        // 商品大分類名称
                    row.GoodsLGroupName_Prime = goodsUnitData.GoodsLGroupName;                // 商品大分類コード
                    row.GoodsMGroup_Prime = goodsUnitData.GoodsMGroup;                        // 商品中分類コード
                    row.GoodsMGroupName_Prime = goodsUnitData.GoodsMGroupName;                // 商品中分類名称
                    row.BLGroupCode_Prime = goodsUnitData.BLGroupCode;                        // BLグループコード
                    row.BLGroupName_Prime = goodsUnitData.BLGroupName;                        // BLグループコード名称
                    row.BLGoodsCode_Prime = goodsUnitData.BLGoodsCode;                        // BL商品コード
                    row.BLGoodsFullName_Prime = goodsUnitData.BLGoodsFullName;                // BL商品コード名称（全角）
                    row.EnterpriseGanreCode_Prime = goodsUnitData.EnterpriseGanreCode;        // 自社分類コード
                    row.EnterpriseGanreName_Prime = goodsUnitData.EnterpriseGanreName;        // 自社分類名称
                    row.GoodsRateRank_Prime = goodsUnitData.GoodsRateRank;                    // 商品掛率ランク
                    row.RateBLGoodsCode_Prime = goodsUnitData.BLGoodsCode;                    // BL商品コード（掛率）
                    row.RateBLGoodsName_Prime = goodsUnitData.BLGoodsFullName;                // BL商品コード名称（掛率）
                    row.RateGoodsRateGrpCd_Prime = goodsUnitData.GoodsRateGrpCode;            // 商品掛率グループコード（掛率）
                    row.RateGoodsRateGrpNm_Prime = goodsUnitData.GoodsRateGrpName;            // 商品掛率グループ名称（掛率）
                    row.RateBLGroupCode_Prime = goodsUnitData.BLGroupCode;                    // BLグループコード（掛率）
                    row.RateBLGroupName_Prime = goodsUnitData.BLGroupName;                    // BLグループ名称（掛率）
                    row.TaxationDivCd_Prime = goodsUnitData.TaxationDivCd;                    // 課税区分
                    // 2009/11/25 Add >>>
                    row.SalesCode_Prime = goodsUnitData.SalesCode;                            // 販売区分コード
                    row.SalesCdNm_Prime = goodsUnitData.SalesCodeName;                        // 販売区分名称
                    // 2009/11/25 Add <<<

                    row.PartsInfoLinkGuid_Prime = Guid.NewGuid();                                // 部品検索データセットリンクGUID
                    row.ExistSetInfo_Prime = partsInfoDataSet.UsrSetParts.SetExist(row.GoodsMakerCd_Prime, row.GoodsNo_Prime);  // セット存在有無
                    this.CachePartsInfoDataSet(row.PartsInfoLinkGuid_Prime, partsInfoDataSet);

                    row.GoodsSearchDivCd_Prime = (int)goodsSearchDiv;
                    row.ShipmentCnt_Prime = ( goodsUnitData.PartsQty == 0 ) ? 1 : goodsUnitData.PartsQty;
                    // UPD 2013/01/09 T.Miyamoto ------------------------------>>>>>
                    //row.ShipmentCnt_Prime = (goodsUnitData.SetQty == 0) ? 1 : goodsUnitData.SetQty; // 2012/12/25 ADD T.MIyamoto
                    if ((GoodsKind)goodsUnitData.GoodsKindResolved == GoodsKind.Set)
                    {
                        row.ShipmentCnt_Prime = (goodsUnitData.SetQty == 0) ? 1 : goodsUnitData.SetQty;
                    }
                    // UPD 2013/01/09 T.Miyamoto ------------------------------<<<<<

                    // 印刷用BLコードの決定
                    // BLコード検索、印刷用BL商品コード区分「検索」、BLコード有り
                    int prtBLGoodsCode = 0;
                    string prtBLGoodsName = string.Empty;
                    if (( goodsSearchDiv == GoodsSearchDiv.BLPartsSearch ) &&
                        ( this._estimateInputInitDataAcs.GetSalesTtlSt().PrtBLGoodsCodeDiv == 1 ) &&
                        ( searchBLGoodsCode > 0 ))
                    {
                        prtBLGoodsCode = searchBLGoodsCode;
                        string blGoodsHalfName;
                        this._estimateInputInitDataAcs.GetName_FromBLGoods(searchBLGoodsCode, out prtBLGoodsName, out blGoodsHalfName);
                    }
                    else
                    {
                        prtBLGoodsCode = goodsUnitData.BLGoodsCode;
                        prtBLGoodsName = goodsUnitData.BLGoodsFullName;
                    }
                    row.PrtBLGoodsCode_Prime = prtBLGoodsCode;                                // BL商品コード（印刷）
                    row.PrtBLGoodsName_Prime = prtBLGoodsName;                                // BL商品コード名称（印刷）

                    row.SupplierCd_Prime = goodsUnitData.SupplierCd;                          // 仕入先コード
                    row.SupplierSnm_Prime = goodsUnitData.SupplierSnm;                        // 仕入先名称

                    // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    GoodsPrice goodsPrice = this._estimateInputInitDataAcs.GetGoodsPrice(this._salesSlip.SalesDate, goodsUnitData);
                    if (goodsPrice != null) row.OpenPriceDiv_Prime = goodsPrice.OpenPriceDiv; // オープン価格区分
                    // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // ------------ADD START wangf 2012/04/06 FOR Redmine#29227--------->>>>
                    // 純正情報が無い場合はBLコード、品名に優良情報をセットする
                    if (string.IsNullOrEmpty(row.GoodsName))
                    {
                        row.GoodsName = row.GoodsName_Prime;
                        row.BLGoodsCode = row.BLGoodsCode_Prime;
                    }
                    // ------------ADD END wangf 2012/04/06 FOR Redmine#29227---------<<<<<

                    // 優良部品価格情報設定
                    this.EstimateDetailRowPriceInfoSettingFromUnitPriceCalcRetList(TargetData.PrimeParts, row, unitPriceCalcRetList, false, false, true, true);

                    // 原価計算
                    this.CalculateCost(TargetData.PrimeParts, row);

                    // 商品情報をキャッシュ
                    this.CacheGoodsUnitData(goodsUnitData);

                    /* ------------DEL START wangf 2012/04/06 FOR Redmine#29227--------->>>>
                    // 純正情報が無い場合はBLコード、品名に優良情報をセットする
                    if (string.IsNullOrEmpty(row.GoodsName))
                    {
                        row.GoodsName = row.GoodsName_Prime;
                        row.BLGoodsCode = row.BLGoodsCode_Prime;
                    }
                    // ------------DEL END wangf 2012/04/06 FOR Redmine#29227---------<<<<<*/

                    if (( goodsUnitData.StockList != null ) &&
                        ( goodsUnitData.StockList.Count > 0 ))
                    {
                        this.CacheStockInfo(goodsUnitData.StockList);

                        if (( warehouseCodeArray != null ) && ( warehouseCodeArray.Length > 0 ))
                        {
                            Stock stock = this._estimateInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray);
                            if (stock != null)
                            {
                                row.WarehouseCode_Prime = stock.WarehouseCode.Trim();
                                row.WarehouseName_Prime = stock.WarehouseName;
                                row.WarehouseShelfNo_Prime = stock.WarehouseShelfNo;
                                //row.ShipmentPosCnt_Prime = stock.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                                row.ShipmentPosCnt_Prime = stock.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 見積明細行の商品情報をクリアします。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        public void EstimateDretailRowGoodsInfoClear( int salesRowNo, TargetData targetData )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                // 定価の掛率情報をクリア
                this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.ListPrice, targetData, false);
                // 原価の掛率情報をクリア(原価金額もクリア)
                this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, targetData, false);
                // 在庫情報をクリア
                this.EstimateDetailRowClearStockInfo(row, targetData);

                // その他情報のクリア
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    row.PartsInfoLinkGuid = Guid.Empty;             // 部品情報リンクGUID
                    row.ExistSetInfo = false;                       // セット存在フラグ
                }
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    row.PartsInfoLinkGuid_Prime = Guid.Empty;       // 部品情報リンクGUID
                    row.ExistSetInfo_Prime = false;                 // セット存在フラグ
                }
            }
        }

		/// <summary>
		/// 指定した在庫情報オブジェクトを元に、見積明細データ行オブジェクトに在庫情報を設定します。
		/// </summary>
		/// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
		/// <param name="stockList">在庫リスト</param>
        public void EstimateDetailRowStockSetting( int salesRowNo, TargetData targetData, List<Stock> stockList )
        {
            // 2009.06.18 >>>
            // 在庫データキャッシュ処理
            this.CacheStockInfo(stockList);
            // 2009.06.18 <<<

            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    Stock purePartsStock = null;
                    foreach (Stock stockWk in stockList)
                    {
                        if (( stockWk.WarehouseCode.Trim() == row.WarehouseCode.Trim() ) &&
                            ( stockWk.GoodsNo == row.GoodsNo ) &&
                            ( stockWk.GoodsMakerCd == row.GoodsMakerCd ))
                        {
                            purePartsStock = stockWk;
                            break;
                        }
                    }

                    if (purePartsStock != null)
                    {
                        this.EstimateDetailRowStockSetting(row, TargetData.PureParts, purePartsStock);

                        // 2009.06.18 Add >>>
                        // 在庫調整
                        this.EstimateDetailStockInfoAdjust(purePartsStock.WarehouseCode.Trim(), purePartsStock.GoodsNo.Trim(), purePartsStock.GoodsMakerCd);
                        // 2009.06.18 Add <<<

                    }
                    else
                    {
                        this.EstimateDetailRowClearStockInfo(row, TargetData.PureParts);
                    }

                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    Stock primePartsStock = null;

                    foreach (Stock stockWk in stockList)
                    {
                        if (( stockWk.WarehouseCode.Trim() == row.WarehouseCode_Prime.Trim() ) &&
                            ( stockWk.GoodsNo == row.GoodsNo_Prime ) &&
                            ( stockWk.GoodsMakerCd == row.GoodsMakerCd_Prime ))
                        {
                            primePartsStock = stockWk;
                            break;
                        }
                    }

                    if (primePartsStock != null)
                    {
                        this.EstimateDetailRowStockSetting(row, TargetData.PrimeParts, primePartsStock);
                        // 2009.06.18 Add >>>
                        // 在庫調整
                        this.EstimateDetailStockInfoAdjust(primePartsStock.WarehouseCode.Trim(), primePartsStock.GoodsNo.Trim(), primePartsStock.GoodsMakerCd);
                        // 2009.06.18 Add <<<
                    }
                    else
                    {
                        this.EstimateDetailRowClearStockInfo(row, TargetData.PrimeParts);
                    }
                }
            }
        }

        /// <summary>
        /// 指定した在庫情報オブジェクトを元に、見積明細データ行オブジェクトに在庫情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="stock">在庫</param>
        public void EstimateDetailRowStockSetting( int salesRowNo, TargetData targetData, Stock stock )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                this.EstimateDetailRowStockSetting(row, targetData, stock);
            }
        }

        /// <summary>
        /// 指定した在庫情報オブジェクトを元に、見積明細データ行オブジェクトに在庫情報を設定します。
        /// </summary>
        /// <param name="row">見積明細行オブジェクト</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="stock">在庫オブジェクト</param>
        private void EstimateDetailRowStockSetting( EstimateInputDataSet.EstimateDetailRow row, TargetData targetData, Stock stock )
        {
            if (( row != null ) && ( stock != null ))
            {
                this.CacheStockInfo(stock);
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    row.WarehouseCode = stock.WarehouseCode.Trim();
                    row.WarehouseName = stock.WarehouseName.Trim();
                    row.WarehouseShelfNo = stock.WarehouseShelfNo.Trim();
                    //row.ShipmentPosCnt = stock.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                    row.ShipmentPosCnt = stock.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    row.WarehouseCode_Prime = stock.WarehouseCode.Trim();
                    row.WarehouseName_Prime = stock.WarehouseName.Trim();
                    row.WarehouseShelfNo_Prime = stock.WarehouseShelfNo.Trim();
                    //row.ShipmentPosCnt_Prime = stock.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                    row.ShipmentPosCnt_Prime = stock.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                    row.SalesOrderDivCd_Prime = 1;
                }
            }
        }



        /// <summary>
        /// 指定した行の倉庫を切り替えます。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        public void EstimateDetailRowWarehouseChange( int salesRowNo,TargetData targetData )
        {
            
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    EstimateInputDataSet.StockInfoRow stockInfoRow = this.GetNextWarehouseStockInfo(row.WarehouseCode, row.GoodsNo, row.GoodsMakerCd, this._stockInfoDataTable);

                    if (stockInfoRow == null)
                    {
                        row.WarehouseCode = string.Empty;
                        row.WarehouseName = string.Empty;
                        row.WarehouseShelfNo = string.Empty;
                        //row.ShipmentPosCnt = 0;// DEL 譚洪 Redmine#34994 2013/03/10
                        row.ShipmentPosCnt = string.Empty;// ADD 譚洪 Redmine#34994 2013/03/10
                    }
                    else
                    {
                        row.WarehouseCode = stockInfoRow.WarehouseCode;
                        row.WarehouseName = stockInfoRow.WarehouseName;
                        row.WarehouseShelfNo = stockInfoRow.WarehouseShelfNo;
                        //row.ShipmentPosCnt = stockInfoRow.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                        row.ShipmentPosCnt = stockInfoRow.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                    }
                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    EstimateInputDataSet.StockInfoRow stockInfoRow = this.GetNextWarehouseStockInfo(row.WarehouseCode_Prime, row.GoodsNo_Prime, row.GoodsMakerCd_Prime, this._stockInfoDataTable);

                    if (stockInfoRow == null)
                    {
                        row.WarehouseCode_Prime = string.Empty;
                        row.WarehouseName_Prime = string.Empty;
                        row.WarehouseShelfNo_Prime = string.Empty;
                        //row.ShipmentPosCnt_Prime = 0;
                        row.ShipmentPosCnt_Prime = string.Empty;
                    }
                    else
                    {
                        row.WarehouseCode_Prime = stockInfoRow.WarehouseCode;
                        row.WarehouseName_Prime = stockInfoRow.WarehouseName;
                        row.WarehouseShelfNo_Prime = stockInfoRow.WarehouseShelfNo;
                        //row.ShipmentPosCnt_Prime = stockInfoRow.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                        row.ShipmentPosCnt_Prime = stockInfoRow.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                    }
                }
                if (row != null)
                {
                    this._estimateDetailDataTable.AcceptChanges();
                }
            }
        }

		/// <summary>
		/// 指定した行の在庫情報をクリアします。
		/// </summary>
		/// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        public void EstimateDetailRowClearStockInfo( int salesRowNo, TargetData targetData )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                this.EstimateDetailRowClearStockInfo(row, targetData);
            }
        }

        /// <summary>
        /// 見積明細行の在庫情報をクリアします。
        /// </summary>
        /// <param name="row">見積明細行オブジェクト</param>
        /// <param name="targetData">対象データ</param>
        private void EstimateDetailRowClearStockInfo( EstimateInputDataSet.EstimateDetailRow row, TargetData targetData )
        {
            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                row.WarehouseCode = string.Empty;
                row.WarehouseName = string.Empty;
                row.WarehouseShelfNo = string.Empty;
                //row.ShipmentPosCnt = 0;// DEL 譚洪 Redmine#34994 2013/03/10
                row.ShipmentPosCnt = string.Empty;// ADD 譚洪 Redmine#34994 2013/03/10
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                row.WarehouseCode_Prime = string.Empty;
                row.WarehouseName_Prime = string.Empty;
                row.WarehouseShelfNo_Prime = string.Empty;
                //row.ShipmentPosCnt_Prime = 0;// DEL 譚洪 Redmine#34994 2013/03/10
                row.ShipmentPosCnt_Prime = string.Empty;// ADD 譚洪 Redmine#34994 2013/03/10
            }
        }

		#endregion

        #region 履歴照会からのデータ展開

        /// <summary>
        /// 売上履歴照会ワークオブジェクトリストを元に、見積明細データ行オブジェクトを設定します。（明細選択）
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="salHisRefResultParamWorkList">ワークオブジェクトリスト</param>
        public void EstimateDetailRowSettingFromSalHisRefResultParamWorkList(int salesRowNo, List<SalHisRefResultParamWork> salHisRefResultParamWorkList)
        {
            //---------------------------------------------------
            // 売上データ読込パラメータセット
            //---------------------------------------------------
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();
            foreach (SalHisRefResultParamWork salHisRefResultParamWork in salHisRefResultParamWorkList)
            {
                SalesDetailWork salesDetailWork = new SalesDetailWork();
                salesDetailWork.EnterpriseCode = salHisRefResultParamWork.EnterpriseCode;
                salesDetailWork.AcptAnOdrStatus = salHisRefResultParamWork.AcptAnOdrStatus;
                salesDetailWork.SalesSlipDtlNum = salHisRefResultParamWork.SalesSlipDtlNum;
                paraList.Add(salesDetailWork);
            }

            #region ●リモート参照用パラメータ
            //------------------------------------------------------
            // リモート参照用パラメータ
            //------------------------------------------------------
            IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();   // リモート参照用パラメータ
            paraList.Add(iOWriteCtrlOptWork);
            #endregion

            object paraObj = (object)paraList;
            object retObj = null;
            object retObj2 = null;

            //---------------------------------------------------
            // 売上データ再読込
            //---------------------------------------------------
            if (_iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            int status = this._iIOWriteControlDB.ReadDetail(ref paraObj, out retObj, out retObj2);

            CustomSerializeArrayList retList = (CustomSerializeArrayList)retObj;
            CustomSerializeArrayList retList2 = (CustomSerializeArrayList)retObj2;

            if (retList != null) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //---------------------------------------------------
                // データリスト分割
                //---------------------------------------------------
                SalesDetailWork[] salesDetailWorkArray;
                StockSlipWork[] stockSlipWorkArray = null;
                AcceptOdrCarWork[] acceptOdrCarWorkArray = null;
                StockDetailWork[] stockDetailWorkArray = null;
                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForDetailsReading(retList, retList2, out salesDetailWorkArray, out acceptOdrCarWorkArray, out stockSlipWorkArray, out stockDetailWorkArray);

                //---------------------------------------------------
                // 売上明細データワークオブジェクト→売上明細データオブジェクト
                //---------------------------------------------------
                this.EstimateDetailRowSettingFromSalesDetailWorkArray(salesRowNo, salesDetailWorkArray, acceptOdrCarWorkArray);
            }
        }

        /// <summary>
        /// コピー元売上明細ワークオブジェクト配列を元に、売上明細データ行オブジェクトを設定します。（明細選択）
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車輌）ワークオブジェクト配列</param>
        public void EstimateDetailRowSettingFromSalesDetailWorkArray(int salesRowNo, SalesDetailWork[] salesDetailWorkArray, AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            List<int> settingSalesRowNoList = new List<int>();
            List<SalesDetail> salesDetailList = ConvertSalesSlip.UIDataFromParamData(salesDetailWorkArray);

            salesDetailList.Sort(new SalesDetail.SalesDetailComparer());

            List<DetailInfoKey> settingKeyList = new List<DetailInfoKey>();
            Dictionary<DetailInfoKey, Dictionary<int, SalesDetail>> addRowDictionary = new Dictionary<DetailInfoKey, Dictionary<int, SalesDetail>>();

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                DetailInfoKey key = new DetailInfoKey(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);
                if (!addRowDictionary.ContainsKey(key))
                {
                    settingKeyList.Add(key);
                    addRowDictionary.Add(key, new Dictionary<int, SalesDetail>());
                }
                if (addRowDictionary[key].ContainsKey(salesDetail.SalesRowDerivNo))
                {
                    addRowDictionary[key][salesDetail.SalesRowDerivNo] = salesDetail;
                }
                else
                {
                    addRowDictionary[key].Add(salesDetail.SalesRowDerivNo, salesDetail);
                }
            }

            List<AcceptOdrCar> acceptOdrCarList = ConvertSalesSlip.UIDataFromParamData(acceptOdrCarWorkArray);
            List<Stock> stockList = this.SearchStock(salesDetailList);
            List<int> deletingSalesRowNoList = new List<int>();
            int salesRowNoWk = salesRowNo;
            //int addRowCnt = salesDetailWorkArray.Length;
            int addRowCnt = settingKeyList.Count;
            while (addRowCnt > 0)
            {
                EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNoWk);

                try
                {
                    // 行が存在しない場合は新規に追加する
                    if (row == null)
                    {
                        this.AddEstimateDetailRow();

                        row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNoWk);
                    }
                    else
                    {
                        if (this.ExistDetailInput(row))
                        {
                            continue;
                        }
                    }

                    settingSalesRowNoList.Add(row.SalesRowNo);

                    deletingSalesRowNoList.Add(row.SalesRowNo);

                    row.AcceptChanges();

                    addRowCnt--;
                }
                finally
                {
                    salesRowNoWk++;
                }
            }

            // 見積明細行クリア処理
            this.ClearEstimateDetailRow(deletingSalesRowNoList);

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();

            //-----------------------------------------------------------------------------
            // 商品情報キャッシュ
            //-----------------------------------------------------------------------------
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            string msg;

            int status = this.SearchPartsFromGoodsNoNonVariousSearchWholeWord(this._salesSlip, salesDetailList, out goodsUnitDataList, out msg);

            this.CacheGoodsUnitData(goodsUnitDataList);

            for (int i = 0; i < settingKeyList.Count; i++)
            {
                int targetSalesRowNo = settingSalesRowNoList[i];

                // 明細情報設定処理
                this.EstimateDetailRowSettingFromSalesDetail(targetSalesRowNo, addRowDictionary[settingKeyList[i]], goodsUnitDataList);

                // 車輌情報キャッシュ
                this.CacheCarInfo(targetSalesRowNo, salesDetailList[i], acceptOdrCarList);

                // 受注番号のクリア
                this.ClearCarInfoRowClearAcceptAnOrderNo(targetSalesRowNo);
            }
        }


        /// <summary>
        /// コピー元売上明細行オブジェクトを元に売上明細行オブジェクトを設定します。（明細選択）
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="salesDetailDictionary">コピー元明細ディクショナリ</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>              標準価格選択ＵＩ表示の速度改善</br>
        public void EstimateDetailRowSettingFromSalesDetail(int salesRowNo, Dictionary<int, SalesDetail> salesDetailDictionary, List<GoodsUnitData> goodsUnitDataList)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesDetail salesDetail = null;
            if (row != null)
            {
                //this.ClearEstimateDetailRow(row, TargetData.All);//DEL 2011/02/14
                ClearEstimateDetailRow(row, TargetData.All);//ADD 2011/02/14

                salesDetail = ( salesDetailDictionary.ContainsKey(0) ) ? salesDetailDictionary[0] : null;

                if (salesDetail != null)
                {
                    this.SetRowFromUIData(TargetData.PureParts, ref row, this._salesSlip, salesDetail, false);
                    
                    // 純正情報
                    row.CommonSeqNo = 0;						// 共通通番 ← 0
                    row.SalesSlipDtlNum = 0;					// 売上明細通番 ← 0
                    row.AcptAnOdrStatusSrc = 0;					// 受注ステータス(元) ← 0
                    row.SalesSlipDtlNumSrc = 0;					// 売上明細通番(元) ← 0
                    row.SupplierFormalSync = -1;				// 仕入形式(同時) ← 0
                    row.StockSlipDtlNumSync = 0;				// 仕入明細通番(同時) ← 0
                    row.UOEOrderGuid = Guid.Empty;
                    row.AcceptAnOrderCnt = 0;
                    row.AcptAnOdrAdjustCnt = 0;
                    row.AcptAnOdrRemainCnt = 0;


                    if (( !string.IsNullOrEmpty(salesDetail.GoodsNo) ) &&
                        ( salesDetail.GoodsMakerCd != 0 ) &&
                        ( !string.IsNullOrEmpty(salesDetail.WarehouseCode.Trim()) ))
                    {
                        foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                        {
                            if (( goodsUnitData.GoodsNo == salesDetail.GoodsNo ) &&
                                ( goodsUnitData.GoodsMakerCd == salesDetail.GoodsMakerCd ))
                            {
                                if (goodsUnitData.StockList != null)
                                {
                                    Stock stock = this._estimateInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, new string[] { salesDetail.WarehouseCode.Trim() });

                                    if (stock != null)
                                    {
                                        this.CacheStockInfo(stock);

                                        row.WarehouseCode = stock.WarehouseCode.Trim();
                                        row.WarehouseName = stock.WarehouseName;
                                        row.WarehouseShelfNo = stock.WarehouseShelfNo;
                                        //row.ShipmentPosCnt = stock.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                                        row.ShipmentPosCnt = stock.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                                    }
                                }
                                break;
                            }
                        }
                    }
                }

                salesDetail = ( salesDetailDictionary.ContainsKey(1) ) ? salesDetailDictionary[1] : null;

                if (salesDetail != null)
                {
                    this.SetRowFromUIData(TargetData.PrimeParts, ref row, this._salesSlip, salesDetail, false);

                    row.CommonSeqNo_Prime = 0;						// 共通通番 ← 0
                    row.SalesSlipDtlNum_Prime = 0;					// 売上明細通番 ← 0
                    row.AcptAnOdrStatusSrc_Prime = 0;					// 受注ステータス(元) ← 0
                    row.SalesSlipDtlNumSrc_Prime = 0;					// 売上明細通番(元) ← 0
                    row.SupplierFormalSync_Prime = -1;				// 仕入形式(同時) ← 0
                    row.StockSlipDtlNumSync_Prime = 0;				// 仕入明細通番(同時) ← 0
                    row.AcceptAnOrderCnt_Prime = 0;
                    row.AcptAnOdrAdjustCnt_Prime = 0;
                    row.AcptAnOdrRemainCnt_Prime = 0;
                    row.UOEOrderGuid_Prime = Guid.Empty;

                    if (( !string.IsNullOrEmpty(salesDetail.GoodsNo) ) &&
                        ( salesDetail.GoodsMakerCd != 0 ) &&
                        ( !string.IsNullOrEmpty(salesDetail.WarehouseCode.Trim()) ))
                    {
                        foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                        {
                            if (( goodsUnitData.GoodsNo == salesDetail.GoodsNo ) &&
                                ( goodsUnitData.GoodsMakerCd == salesDetail.GoodsMakerCd ))
                            {
                                if (goodsUnitData.StockList != null)
                                {
                                    Stock stock = this._estimateInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, new string[] { salesDetail.WarehouseCode.Trim() });

                                    if (stock != null)
                                    {
                                        this.CacheStockInfo(stock);

                                        row.WarehouseCode_Prime = stock.WarehouseCode.Trim();
                                        row.WarehouseName_Prime = stock.WarehouseName;
                                        row.WarehouseShelfNo_Prime = stock.WarehouseShelfNo;
                                        //row.ShipmentPosCnt_Prime = stock.ShipmentPosCnt;// DEL 譚洪 Redmine#34994 2013/03/10
                                        row.ShipmentPosCnt_Prime = stock.ShipmentPosCnt.ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                                    }
                                }
                                break;
                            }
                        }
                    }

                }
            }

            row.AcceptAnOrderNo = 0;
            row.CarRelationGuid = Guid.Empty;
            row.EditStatus = ctEDITSTATUS_AllOK;

            // RowStatus
            row.RowStatus = ctROWSTATUS_NORMAL;
            row.AcceptChanges();
        }
        #endregion

        #region 各項目の入力設定(商品・在庫を除く)

        /// <summary>
        /// 見積明細行オブジェクトに品名、品名カナを設定します。
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <param name="targetData"></param>
        /// <param name="goodsName"></param>
        /// <param name="goodsNameKana"></param>
        public void EstimateDetailGoodsNameSetting( int salesRowNo, TargetData targetData, string goodsName, string goodsNameKana )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row == null) return;

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                row.GoodsName = goodsName;
                row.GoodsNameKana = goodsNameKana;
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                row.GoodsName_Prime = goodsName;
                row.GoodsNameKana_Prime = goodsNameKana;
            }
        }

		/// <summary>
		/// 見積明細行オブジェクトに倉庫名称、倉庫コードを設定します。
		/// </summary>
		/// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="warehouseName">倉庫名称</param>
        public void EstimateDetailWarehouseInfoSetting( int salesRowNo, TargetData targetData, string warehouseCode, string warehouseName )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row == null) return;

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                row.WarehouseCode = warehouseCode.Trim();
                row.WarehouseName = warehouseName;

                if (String.IsNullOrEmpty(warehouseCode.Trim()))
                {
                    row.WarehouseShelfNo = "";
                    //row.ShipmentPosCnt = 0;// DEL 譚洪 Redmine#34994 2013/03/10
                    row.ShipmentPosCnt = string.Empty;// ADD 譚洪 Redmine#34994 2013/03/10
                }
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                row.WarehouseCode_Prime = warehouseCode.Trim();
                row.WarehouseName_Prime = warehouseName;

                if (String.IsNullOrEmpty(warehouseCode.Trim()))
                {
                    row.WarehouseShelfNo_Prime = "";
                    //row.ShipmentPosCnt_Prime = 0;// DEL 譚洪 Redmine#34994 2013/03/10
                    row.ShipmentPosCnt_Prime = string.Empty;// ADD 譚洪 Redmine#34994 2013/03/10
                }
            }
        }

        /// <summary>
        /// 見積明細行オブジェクトにメーカーコードとメーカー名称を設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="makerKanaName">メーカー名称カナ</param>
        public void EstimateDetailMakerInfoSetting( int salesRowNo, TargetData targetData, int goodsMakerCd, string makerName, string makerKanaName )
        {
            bool isMakerChanged;
            this.EstimateDetailMakerInfoSetting(salesRowNo, targetData, goodsMakerCd, makerName, makerKanaName, out isMakerChanged);
        }

		/// <summary>
        /// 見積明細行オブジェクトにメーカーコードとメーカー名称を設定します。
		/// </summary>
		/// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
		/// <param name="makerName">メーカー名称</param>
        /// <param name="makerKanaName">メーカー名称カナ</param>
        /// <param name="isMakerChanged">データ変更有無</param>
        public void EstimateDetailMakerInfoSetting( int salesRowNo, TargetData targetData, int goodsMakerCd, string makerName, string makerKanaName, out bool isMakerChanged )
        {
            isMakerChanged = false;

            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                isMakerChanged = ( row.GoodsMakerCd != goodsMakerCd );
                row.GoodsMakerCd = goodsMakerCd;
                row.MakerName = makerName;
                row.MakerKanaName = makerKanaName;
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                if (!isMakerChanged)
                {
                    isMakerChanged = ( row.GoodsMakerCd != goodsMakerCd );
                }
                row.GoodsMakerCd_Prime = goodsMakerCd;
                row.MakerName_Prime = makerName;
                row.MakerKanaName_Prime = makerKanaName;
            }
        }

        /// <summary>
        /// 見積明細行オブジェクトに仕入先情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="supplier">仕入先マスタ</param>
        public void EstimateDetailSupplierInfoSetting( int salesRowNo, TargetData targetData, Supplier supplier )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                row.SupplierCd = supplier.SupplierCd;
                row.SupplierSnm = supplier.SupplierSnm;
                row.AcceptChanges();
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                row.SupplierCd_Prime = supplier.SupplierCd;
                row.SupplierSnm_Prime = supplier.SupplierSnm;
                row.AcceptChanges();
            }
        }

        /// <summary>
        /// 見積明細行オブジェクトにBLコード関連の情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="blCode">BLコード</param>
        /// <returns>False:BLコードマスタ取得失敗</returns>
        public bool EstimateDetailBLGoodsInfoSetting( int salesRowNo, TargetData targetData, int blCode )
        {
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            BLGroupU bLGroupU = new BLGroupU();
            GoodsGroupU goodsGroupU = new GoodsGroupU();
            UserGdBdU userGdBdU = new UserGdBdU();

            if (blCode != 0)
            {
                // BLグループ、中分類、大分類情報を取得
                if (!this._estimateInputInitDataAcs.GetBLGoodsRelation(blCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU))
                {
                    // 失敗時は
                    return false;
                }
            }

            this.EstimateDetailBLGoodsInfoSetting(salesRowNo, targetData, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, true);

            return true;
        }

        /// <summary>
        /// 見積明細行オブジェクトにBLコード関連の情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="bLGoodsCdUMnt">BLコードマスタ</param>
        public void EstimateDetailBLGoodsInfoSetting( int salesRowNo, TargetData targetData, BLGoodsCdUMnt bLGoodsCdUMnt )
        {
            BLGoodsCdUMnt bLGoodsCdUMntWk = new BLGoodsCdUMnt();
            BLGroupU bLGroupU = new BLGroupU();
            GoodsGroupU goodsGroupU = new GoodsGroupU();
            UserGdBdU userGdBdU = new UserGdBdU();

            // BLグループ、中分類、大分類情報を取得
            this._estimateInputInitDataAcs.GetBLGoodsRelation(bLGoodsCdUMnt.BLGoodsCode, out bLGoodsCdUMntWk, out bLGroupU, out goodsGroupU, out userGdBdU);

            this.EstimateDetailBLGoodsInfoSetting(salesRowNo, targetData, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, true);
        }

        /// <summary>
        /// 見積明細行オブジェクトのBLコード関連の情報をクリアします。
        /// </summary>
        /// <param name="salesRowNo">明細行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <returns></returns>
        public void EstimateDetailBLGoodsInfoClear( int salesRowNo, TargetData targetData )
        {
            this.EstimateDetailBLGoodsInfoSetting(salesRowNo, targetData, new BLGoodsCdUMnt(), new BLGroupU(), new GoodsGroupU(), new UserGdBdU(), false);
        }

        /// <summary>
        /// 見積明細行オブジェクトにBLコード関連の情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="bLGoodsCdUMnt">BLコードマスタ</param>
        /// <param name="bLGroupU">グループコードマスタ</param>
        /// <param name="goodsGroupU">中分類マスタ</param>
        /// <param name="userGdBdU">ユーザーガイドマスタ（大分類情報）</param>
        /// <param name="changeGoodsName">True:品名を変更する</param>
        /// <remarks>
        /// <br>Update Note: 2010/06/08　李占川　ＢＬコード入力時の品名取得変更</br>
        /// <br>Update Note: 2010/06/17　李占川　Redmine#9946の対応</br>
        /// </remarks>
        private void EstimateDetailBLGoodsInfoSetting(int salesRowNo, TargetData targetData, BLGoodsCdUMnt bLGoodsCdUMnt, BLGroupU bLGroupU, GoodsGroupU goodsGroupU, UserGdBdU userGdBdU, bool changeGoodsName)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                // 純正情報のセット
                if (( targetData == TargetData.All ) || ( ( targetData == TargetData.PureParts ) ))
                {
                    row.BLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
                    row.BLGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;

                    row.BLGroupCode = bLGroupU.BLGroupCode;
                    row.BLGroupName = bLGroupU.BLGroupName;

                    row.GoodsMGroup = goodsGroupU.GoodsMGroup;
                    row.GoodsMGroupName = goodsGroupU.GoodsMGroupName;

                    row.GoodsLGroup = userGdBdU.GuideCode;
                    row.GoodsLGroupName = userGdBdU.GuideName;

                    if (changeGoodsName)
                    {
                        // --- UPD 2010/06/08 ---------->>>>>
                        //row.GoodsName = bLGoodsCdUMnt.BLGoodsFullName;
                        row.GoodsName = bLGoodsCdUMnt.BLGoodsHalfName;
                        // --- UPD 2010/06/08 ----------<<<<<
                        row.GoodsNameKana = bLGoodsCdUMnt.BLGoodsHalfName;
                    }
                }

                // 優良情報のセット
                if (( targetData == TargetData.All ) || ( ( targetData == TargetData.PrimeParts ) ))
                {
                    row.BLGoodsCode_Prime = bLGoodsCdUMnt.BLGoodsCode;
                    row.RateBLGoodsCode_Prime = bLGoodsCdUMnt.BLGoodsCode; // ADD wangf 2012/04/06 FOR Redmine#29227
                    row.BLGoodsFullName_Prime = bLGoodsCdUMnt.BLGoodsFullName;

                    row.BLGroupCode_Prime = bLGroupU.BLGroupCode;
                    row.BLGroupName_Prime = bLGroupU.BLGroupName;

                    row.GoodsMGroup_Prime = goodsGroupU.GoodsMGroup;
                    row.GoodsMGroupName_Prime = goodsGroupU.GoodsMGroupName;

                    row.GoodsLGroup_Prime = userGdBdU.GuideCode;
                    row.GoodsLGroupName_Prime = userGdBdU.GuideName;

                    if (changeGoodsName)
                    {
                        // --- UPD 2010/06/17 ---------->>>>>
                        //row.GoodsName_Prime = bLGoodsCdUMnt.BLGoodsFullName;
                        row.GoodsName_Prime = bLGoodsCdUMnt.BLGoodsHalfName;
                        // --- UPD 2010/06/17 ----------<<<<<

                        row.GoodsNameKana_Prime = bLGoodsCdUMnt.BLGoodsHalfName;
                    }
                }
            }
        }

		#endregion

		#endregion

        #region 掛率関連情報のクリア

        /// <summary>
        /// 全ての掛率情報をクリアします。
        /// </summary>
        public void AllTableClearRateInfo()
        {
            this.EstimateDataTableClearRateInfo(this._estimateDetailDataTable);
            this.PrimeInfoTableClearRateInfo(this._primeInfoDataTable);
        }

        /// <summary>
        /// 優良情報データテーブルの掛率情報クリア
        /// </summary>
        private void PrimeInfoTableClearRateInfo(EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable)
        {
            primeInfoDataTable.BeginLoadData();
            foreach (EstimateInputDataSet.PrimeInfoRow row in primeInfoDataTable)
            {
                row.RateSectPriceUnPrc = string.Empty;  // 掛率設定拠点（定価）
                row.RateDivLPrice = string.Empty;       // 掛率設定区分（定価）

                row.RateSectCstUnPrc = string.Empty;    // 掛率設定拠点（原価単価）
                row.RateDivUnCst = string.Empty;        // 掛率設定区分（原価単価）

            }
            primeInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// 見積明細データテーブルの掛率情報クリア
        /// </summary>
        private void EstimateDataTableClearRateInfo(EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable)
        {
            estimateDetailDataTable.BeginLoadData();
            foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailDataTable)
            {
                row.RateSectPriceUnPrc = string.Empty;  // 掛率設定拠点（定価）
                row.RateDivLPrice = string.Empty;       // 掛率設定区分（定価）

                row.RateSectCstUnPrc = string.Empty;    // 掛率設定拠点（原価単価）
                row.RateDivUnCst = string.Empty;        // 掛率設定区分（原価単価）

                row.RateSectPriceUnPrc_Prime = string.Empty;  // 掛率設定拠点（定価）（優良）
                row.RateDivLPrice_Prime = string.Empty;       // 掛率設定区分（定価）（優良）

                row.RateSectCstUnPrc_Prime = string.Empty;    // 掛率設定拠点（原価単価）（優良）
                row.RateDivUnCst_Prime = string.Empty;        // 掛率設定区分（原価単価）（優良）
            }
            estimateDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// 見積明細行の掛率に関連する項目をクリアします。
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="targetData"></param>
        /// <param name="clearPrice"></param>
        /// <remarks>
        /// <br>Update Note : 2012/10/24 田建委</br>
        /// <br>管理番号    : 10801804-00、2012/11/14配信分</br>
        /// <br>              Redmine#32862 #9の障害 仕入先変更した変更前価格をクリアしないように修正</br>
        /// </remarks>
        public void EstimateDetailRowClearRateInfo(int salesRowNo, UnitPriceCalculation.UnitPriceKind unitPriceKind, TargetData targetData, bool clearPrice)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                //this.EstimateDetailRowClearRateInfo(row, unitPriceKind, targetData, clearPrice); // DEL 2012/10/24 田建委 redmine#32862
                this.EstimateDetailRowClearRateInfo2(row, unitPriceKind, targetData, clearPrice); // ADD 2012/10/24 田建委 redmine#32862
            }
        }

        //----- ADD 2012/10/24 田建委 redmine#32862 -------------------->>>>>
        /// <summary>
        /// 見積明細行の単価に関連する項目をクリアします。
        /// </summary>
        /// <param name="row">見積明細行</param>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="clearPrice">価格のクリア</param>
        /// <remarks>
        /// <br>Note       : 見積明細行の単価に関連する項目をクリアします。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/10/24</br>
        /// <br>管理番号   : 10801804-00、2012/11/14配信分</br>
        /// </remarks>
        private void EstimateDetailRowClearRateInfo2(EstimateInputDataSet.EstimateDetailRow row, UnitPriceCalculation.UnitPriceKind unitPriceKind, TargetData targetData, bool clearPrice)
        {
            if (row == null) return;

            #region ●定価
            if (unitPriceKind == UnitPriceCalculation.UnitPriceKind.ListPrice)
            {
                if ((targetData == TargetData.All) || (targetData == TargetData.PureParts))
                {
                    row.ListPriceRate = 0;                      // 定価率
                    row.RateSectPriceUnPrc = string.Empty;      // 掛率設定拠点（定価）
                    row.RateDivLPrice = string.Empty;           // 掛率設定区分（定価）
                    row.UnPrcCalcCdLPrice = 0;                  // 単価算出区分（定価）
                    row.PriceCdLPrice = 0;                      // 価格区分（定価）
                    row.StdUnPrcLPrice = 0;                     // 基準単価（定価）
                    row.FracProcUnitLPrice = 0;                 // 端数処理単位（定価）
                    row.FracProcLPrice = 0;                     // 端数処理（定価）
                    if (clearPrice)
                    {
                        row.ListPriceTaxIncFl = 0;              // 定価（税込，浮動）
                        row.ListPriceTaxExcFl = 0;              // 定価（税抜，浮動）
                    }
                    row.ListPriceChngCd = (row.ListPriceTaxExcFl == row.BfListPrice) ? 0 : 1;
                }

                if ((targetData == TargetData.All) || (targetData == TargetData.PrimeParts))
                {
                    row.ListPriceRate_Prime = 0;                      // 定価率
                    row.RateSectPriceUnPrc_Prime = string.Empty;      // 掛率設定拠点（定価）
                    row.RateDivLPrice_Prime = string.Empty;           // 掛率設定区分（定価）
                    row.UnPrcCalcCdLPrice_Prime = 0;                  // 単価算出区分（定価）
                    row.PriceCdLPrice_Prime = 0;                      // 価格区分（定価）
                    row.StdUnPrcLPrice_Prime = 0;                     // 基準単価（定価）
                    row.FracProcUnitLPrice_Prime = 0;                 // 端数処理単位（定価）
                    row.FracProcLPrice_Prime = 0;                     // 端数処理（定価）
                    if (clearPrice)
                    {
                        row.ListPriceTaxIncFl_Prime = 0;              // 定価（税込，浮動）
                        row.ListPriceTaxExcFl_Prime = 0;              // 定価（税抜，浮動）
                    }
                    row.ListPriceChngCd_Prime = (row.ListPriceTaxExcFl_Prime == row.BfListPrice_Prime) ? 0 : 1;
                }
            }
            #endregion

            #region ●原単価
            if (unitPriceKind == UnitPriceCalculation.UnitPriceKind.UnitCost)
            {
                if ((targetData == TargetData.All) || (targetData == TargetData.PureParts))
                {
                    row.CostRate = 0;                           // 原価率
                    row.RateSectCstUnPrc = string.Empty;        // 掛率設定拠点（原価単価）
                    row.RateDivUnCst = string.Empty;　          // 掛率設定区分（原価単価）
                    row.UnPrcCalcCdUnCst = 0;                   // 単価算出区分（原価単価）
                    row.PriceCdUnCst = 0;                       // 価格区分（原価単価）
                    row.StdUnPrcUnCst = 0;                      // 基準単価（原価単価）
                    row.FracProcUnitUnCst = 0;                  // 端数処理単位（原価単価）
                    row.FracProcUnCst = 0;                      // 端数処理（原価単価）
                    if (clearPrice)
                    {
                        row.SalesUnitCost = 0;                  // 原価単価
                        row.Cost = 0;                           // 原価
                    }
                    row.SalesUnitCostChngDiv = (row.SalesUnitCost == row.BfUnitCost) ? 0 : 1;
                }

                if ((targetData == TargetData.All) || (targetData == TargetData.PrimeParts))
                {
                    row.CostRate_Prime = 0;                           // 原価率
                    row.RateSectCstUnPrc_Prime = string.Empty;        // 掛率設定拠点（原価単価）
                    row.RateDivUnCst_Prime = string.Empty;　          // 掛率設定区分（原価単価）
                    row.UnPrcCalcCdUnCst_Prime = 0;                   // 単価算出区分（原価単価）
                    row.PriceCdUnCst_Prime = 0;                       // 価格区分（原価単価）
                    row.StdUnPrcUnCst_Prime = 0;                      // 基準単価（原価単価）
                    row.FracProcUnitUnCst_Prime = 0;                  // 端数処理単位（原価単価）
                    row.FracProcUnCst_Prime = 0;                      // 端数処理（原価単価）
                    if (clearPrice)
                    {
                        row.SalesUnitCost_Prime = 0;                  // 原価単価
                        row.Cost_Prime = 0;                           // 原価
                    }
                    row.SalesUnitCostChngDiv_Prime = (row.SalesUnitCost_Prime == row.BfUnitCost_Prime) ? 0 : 1;
                }
            }
            #endregion

            #region ●売上単価
            if (unitPriceKind == UnitPriceCalculation.UnitPriceKind.SalesUnitPrice)
            {
                if ((targetData == TargetData.All) || (targetData == TargetData.PureParts))
                {
                    // UPD 2011/08/15 ---- >>>>>
                    //row.SalesRate = 0;                          // 売価率
                    if (this.campaignObjGoodsSt == null || (this.campaignObjGoodsSt != null && this.campaignObjGoodsSt.RateVal == 0))
                    {
                        row.SalesRate = 0;
                    }
                    // UPD 2011/08/15 ---- <<<<<

                    row.RateSectSalUnPrc = string.Empty;        // 掛率設定拠点（売上単価）
                    row.RateDivSalUnPrc = string.Empty;         // 掛率設定区分（売上単価）
                    row.UnPrcCalcCdSalUnPrc = 0;                // 単価算出区分（売上単価）
                    row.PriceCdSalUnPrc = 0;                    // 価格区分（売上単価）
                    row.StdUnPrcSalUnPrc = 0;                   // 基準単価（売上単価）
                    row.FracProcUnitSalUnPrc = 0;               // 端数処理単位（売上単価）
                    row.FracProcSalUnPrc = 0;                   // 端数処理（売上単価）
                    if (clearPrice)
                    {
                        row.SalesUnPrcTaxIncFl = 0;                 // 売上単価（税込，浮動）
                        row.SalesUnPrcTaxExcFl = 0;                 // 売上単価（税抜，浮動）
                    }
                    row.SalesUnPrcChngCd = (row.SalesUnPrcTaxExcFl == row.BfSalesUnitPrice) ? 0 : 1;
                }

                if ((targetData == TargetData.All) || (targetData == TargetData.PrimeParts))
                {
                    // UPD 2011/08/15 ---- >>>>>
                    //row.SalesRate_Prime = 0;                         // 売価率
                    if (this.campaignObjGoodsSt == null || (this.campaignObjGoodsSt != null && this.campaignObjGoodsSt.RateVal == 0))
                    {
                        row.SalesRate_Prime = 0;
                    }

                    // UPD 2011/08/15 ---- <<<<<// 売価率
                    row.RateSectSalUnPrc_Prime = string.Empty;        // 掛率設定拠点（売上単価）
                    row.RateDivSalUnPrc_Prime = string.Empty;         // 掛率設定区分（売上単価）
                    row.UnPrcCalcCdSalUnPrc_Prime = 0;                // 単価算出区分（売上単価）
                    row.PriceCdSalUnPrc_Prime = 0;                    // 価格区分（売上単価）
                    row.StdUnPrcSalUnPrc_Prime = 0;                   // 基準単価（売上単価）
                    row.FracProcUnitSalUnPrc_Prime = 0;               // 端数処理単位（売上単価）
                    row.FracProcSalUnPrc_Prime = 0;                   // 端数処理（売上単価）
                    if (clearPrice)
                    {
                        row.SalesUnPrcTaxIncFl_Prime = 0;                 // 売上単価（税込，浮動）
                        row.SalesUnPrcTaxExcFl_Prime = 0;                 // 売上単価（税抜，浮動）
                    }
                    row.SalesUnPrcChngCd_Prime = (row.SalesUnPrcTaxExcFl_Prime == row.BfSalesUnitPrice_Prime) ? 0 : 1;
                }
            }
            #endregion
        }
        //----- ADD 2012/10/24 田建委 redmine#32862 --------------------<<<<<

        /// <summary>
        /// 見積明細行の単価に関連する項目をクリアします。
        /// </summary>
        /// <param name="row">見積明細行</param>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="clearPrice">価格のクリア</param>
        /// <br>Update Note: 2011/08/15 譚洪 Redmine#23554 掛率マスタの売価率設定ありで且つ、キャンペーンの売価額設定ありの場合、売価率はクリアの対応</br>
        private void EstimateDetailRowClearRateInfo(EstimateInputDataSet.EstimateDetailRow row, UnitPriceCalculation.UnitPriceKind unitPriceKind, TargetData targetData, bool clearPrice)
        {
            if (row == null) return;

            #region ●定価
            if (unitPriceKind == UnitPriceCalculation.UnitPriceKind.ListPrice)
            {
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    row.ListPriceRate = 0;                      // 定価率
                    row.RateSectPriceUnPrc = string.Empty;      // 掛率設定拠点（定価）
                    row.RateDivLPrice = string.Empty;           // 掛率設定区分（定価）
                    row.UnPrcCalcCdLPrice = 0;                  // 単価算出区分（定価）
                    row.PriceCdLPrice = 0;                      // 価格区分（定価）
                    row.StdUnPrcLPrice = 0;                     // 基準単価（定価）
                    row.FracProcUnitLPrice = 0;                 // 端数処理単位（定価）
                    row.FracProcLPrice = 0;                     // 端数処理（定価）
                    row.BfListPrice = 0;                        // 変更前定価
                    if (clearPrice)
                    {
                        row.ListPriceTaxIncFl = 0;              // 定価（税込，浮動）
                        row.ListPriceTaxExcFl = 0;              // 定価（税抜，浮動）
                    }
                    row.ListPriceChngCd = ( row.ListPriceTaxExcFl == row.BfListPrice ) ? 0 : 1;
                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    row.ListPriceRate_Prime = 0;                      // 定価率
                    row.RateSectPriceUnPrc_Prime = string.Empty;      // 掛率設定拠点（定価）
                    row.RateDivLPrice_Prime = string.Empty;           // 掛率設定区分（定価）
                    row.UnPrcCalcCdLPrice_Prime = 0;                  // 単価算出区分（定価）
                    row.PriceCdLPrice_Prime = 0;                      // 価格区分（定価）
                    row.StdUnPrcLPrice_Prime = 0;                     // 基準単価（定価）
                    row.FracProcUnitLPrice_Prime = 0;                 // 端数処理単位（定価）
                    row.FracProcLPrice_Prime = 0;                     // 端数処理（定価）
                    row.BfListPrice_Prime = 0;                        // 変更前定価
                    if (clearPrice)
                    {
                        row.ListPriceTaxIncFl_Prime = 0;              // 定価（税込，浮動）
                        row.ListPriceTaxExcFl_Prime = 0;              // 定価（税抜，浮動）
                    }
                    row.ListPriceChngCd_Prime = ( row.ListPriceTaxExcFl_Prime == row.BfListPrice_Prime ) ? 0 : 1;
                }
            }
            #endregion

            #region ●原単価
            if (unitPriceKind == UnitPriceCalculation.UnitPriceKind.UnitCost)
            {
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    row.CostRate = 0;                           // 原価率
                    row.RateSectCstUnPrc = string.Empty;        // 掛率設定拠点（原価単価）
                    row.RateDivUnCst = string.Empty;　          // 掛率設定区分（原価単価）
                    row.UnPrcCalcCdUnCst = 0;                   // 単価算出区分（原価単価）
                    row.PriceCdUnCst = 0;                       // 価格区分（原価単価）
                    row.StdUnPrcUnCst = 0;                      // 基準単価（原価単価）
                    row.FracProcUnitUnCst = 0;                  // 端数処理単位（原価単価）
                    row.FracProcUnCst = 0;                      // 端数処理（原価単価）
                    row.BfUnitCost = 0;                         // 変更前原価
                    if (clearPrice)
                    {
                        row.SalesUnitCost = 0;                  // 原価単価
                        row.Cost = 0;                           // 原価
                    }
                    row.SalesUnitCostChngDiv = ( row.SalesUnitCost == row.BfUnitCost ) ? 0 : 1;
                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    row.CostRate_Prime = 0;                           // 原価率
                    row.RateSectCstUnPrc_Prime = string.Empty;        // 掛率設定拠点（原価単価）
                    row.RateDivUnCst_Prime = string.Empty;　          // 掛率設定区分（原価単価）
                    row.UnPrcCalcCdUnCst_Prime = 0;                   // 単価算出区分（原価単価）
                    row.PriceCdUnCst_Prime = 0;                       // 価格区分（原価単価）
                    row.StdUnPrcUnCst_Prime = 0;                      // 基準単価（原価単価）
                    row.FracProcUnitUnCst_Prime = 0;                  // 端数処理単位（原価単価）
                    row.FracProcUnCst_Prime = 0;                      // 端数処理（原価単価）
                    row.BfUnitCost_Prime = 0;                         // 変更前原価
                    if (clearPrice)
                    {
                        row.SalesUnitCost_Prime = 0;                  // 原価単価
                        row.Cost_Prime = 0;                           // 原価
                    }
                    row.SalesUnitCostChngDiv_Prime = ( row.SalesUnitCost_Prime == row.BfUnitCost_Prime ) ? 0 : 1;
                }
            }
            #endregion

            #region ●売上単価
            if (unitPriceKind == UnitPriceCalculation.UnitPriceKind.SalesUnitPrice)
            {
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    // UPD 2011/08/15 ---- >>>>>
                    //row.SalesRate = 0;                          // 売価率
                    if (this.campaignObjGoodsSt == null || (this.campaignObjGoodsSt != null && this.campaignObjGoodsSt.RateVal == 0))
                    {
                        row.SalesRate = 0;
                    }
                    // UPD 2011/08/15 ---- <<<<<

                    row.RateSectSalUnPrc = string.Empty;        // 掛率設定拠点（売上単価）
                    row.RateDivSalUnPrc = string.Empty;         // 掛率設定区分（売上単価）
                    row.UnPrcCalcCdSalUnPrc = 0;                // 単価算出区分（売上単価）
                    row.PriceCdSalUnPrc = 0;                    // 価格区分（売上単価）
                    row.StdUnPrcSalUnPrc = 0;                   // 基準単価（売上単価）
                    row.FracProcUnitSalUnPrc = 0;               // 端数処理単位（売上単価）
                    row.FracProcSalUnPrc = 0;                   // 端数処理（売上単価）
                    row.BfSalesUnitPrice = 0;                   // 変更前売価
                    if (clearPrice)
                    {
                        row.SalesUnPrcTaxIncFl = 0;                 // 売上単価（税込，浮動）
                        row.SalesUnPrcTaxExcFl = 0;                 // 売上単価（税抜，浮動）
                    }
                    row.SalesUnPrcChngCd = ( row.SalesUnPrcTaxExcFl == row.BfSalesUnitPrice ) ? 0 : 1;
                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    // UPD 2011/08/15 ---- >>>>>
                    //row.SalesRate_Prime = 0;                         // 売価率
                    if (this.campaignObjGoodsSt == null || (this.campaignObjGoodsSt != null && this.campaignObjGoodsSt.RateVal == 0))
                    {
                        row.SalesRate_Prime = 0;
                    }

                    // UPD 2011/08/15 ---- <<<<<// 売価率
                    row.RateSectSalUnPrc_Prime = string.Empty;        // 掛率設定拠点（売上単価）
                    row.RateDivSalUnPrc_Prime = string.Empty;         // 掛率設定区分（売上単価）
                    row.UnPrcCalcCdSalUnPrc_Prime = 0;                // 単価算出区分（売上単価）
                    row.PriceCdSalUnPrc_Prime = 0;                    // 価格区分（売上単価）
                    row.StdUnPrcSalUnPrc_Prime = 0;                   // 基準単価（売上単価）
                    row.FracProcUnitSalUnPrc_Prime = 0;               // 端数処理単位（売上単価）
                    row.FracProcSalUnPrc_Prime = 0;                   // 端数処理（売上単価）
                    row.BfSalesUnitPrice_Prime = 0;                   // 変更前売価
                    if (clearPrice)
                    {
                        row.SalesUnPrcTaxIncFl_Prime = 0;                 // 売上単価（税込，浮動）
                        row.SalesUnPrcTaxExcFl_Prime = 0;                 // 売上単価（税抜，浮動）
                    }
                    row.SalesUnPrcChngCd_Prime = ( row.SalesUnPrcTaxExcFl_Prime == row.BfSalesUnitPrice_Prime ) ? 0 : 1;
                }
            }
            #endregion
        }

        /// <summary>
        /// 優良情報行の単価に関連する項目をクリアします。
        /// </summary>
        /// <param name="row">優良情報行</param>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="clearPrice">価格のクリア</param>
        private void PrimeInfoRowClearRateInfo(EstimateInputDataSet.PrimeInfoRow row, UnitPriceCalculation.UnitPriceKind unitPriceKind, bool clearPrice)
        {
            if (row == null) return;

            #region ●定価
            if (unitPriceKind == UnitPriceCalculation.UnitPriceKind.ListPrice)
            {
                row.ListPriceRate = 0;                      // 定価率
                row.RateSectPriceUnPrc = string.Empty;      // 掛率設定拠点（定価）
                row.RateDivLPrice = string.Empty;           // 掛率設定区分（定価）
                row.UnPrcCalcCdLPrice = 0;                  // 単価算出区分（定価）
                row.PriceCdLPrice = 0;                      // 価格区分（定価）
                row.StdUnPrcLPrice = 0;                     // 基準単価（定価）
                row.FracProcUnitLPrice = 0;                 // 端数処理単位（定価）
                row.FracProcLPrice = 0;                     // 端数処理（定価）
                row.BfListPrice = 0;                        // 変更前定価
                if (clearPrice)
                {
                    row.ListPriceTaxIncFl = 0;              // 定価（税込，浮動）
                    row.ListPriceTaxExcFl = 0;              // 定価（税抜，浮動）
                }
                row.ListPriceChngCd = ( row.ListPriceTaxExcFl == row.BfListPrice ) ? 0 : 1;

            }
            #endregion

            #region ●原単価
            if (unitPriceKind == UnitPriceCalculation.UnitPriceKind.UnitCost)
            {
                row.CostRate = 0;                           // 原価率
                row.RateSectCstUnPrc = string.Empty;        // 掛率設定拠点（原価単価）
                row.RateDivUnCst = string.Empty;　          // 掛率設定区分（原価単価）
                row.UnPrcCalcCdUnCst = 0;                   // 単価算出区分（原価単価）
                row.PriceCdUnCst = 0;                       // 価格区分（原価単価）
                row.StdUnPrcUnCst = 0;                      // 基準単価（原価単価）
                row.FracProcUnitUnCst = 0;                  // 端数処理単位（原価単価）
                row.FracProcUnCst = 0;                      // 端数処理（原価単価）
                row.BfUnitCost = 0;                         // 変更前原価
                if (clearPrice)
                {
                    row.SalesUnitCost = 0;                  // 原価単価
                    row.Cost = 0;                           // 原価
                }
                row.SalesUnitCostChngDiv = ( row.SalesUnitCost == row.BfUnitCost ) ? 0 : 1;
            }
            #endregion

            #region ●売上単価
            if (unitPriceKind == UnitPriceCalculation.UnitPriceKind.SalesUnitPrice)
            {
                row.SalesRate = 0;                          // 売価率
                row.RateSectSalUnPrc = string.Empty;        // 掛率設定拠点（売上単価）
                row.RateDivSalUnPrc = string.Empty;         // 掛率設定区分（売上単価）
                row.UnPrcCalcCdSalUnPrc = 0;                // 単価算出区分（売上単価）
                row.PriceCdSalUnPrc = 0;                    // 価格区分（売上単価）
                row.StdUnPrcSalUnPrc = 0;                   // 基準単価（売上単価）
                row.FracProcUnitSalUnPrc = 0;               // 端数処理単位（売上単価）
                row.FracProcSalUnPrc = 0;                   // 端数処理（売上単価）
                row.BfSalesUnitPrice = 0;                   // 変更前売価
                if (clearPrice)
                {
                    row.SalesUnPrcTaxIncFl = 0;                 // 売上単価（税込，浮動）
                    row.SalesUnPrcTaxExcFl = 0;                 // 売上単価（税抜，浮動）
                }
                row.SalesUnPrcChngCd = ( row.SalesUnPrcTaxExcFl == row.BfSalesUnitPrice ) ? 0 : 1;
            }
            #endregion
        }


        #endregion


		/// <summary>
		/// 商品価格の再設定を行います。
		/// </summary>
		public void PriceReSetting()
		{
            this.PriceReSetting(this._estimateDetailDataTable, this._primeInfoDataTable);
		}

        /// <summary>
        /// 商品価格の再設定を行います。
        /// </summary>
        /// <param name="estimateDetailDataTable"></param>
        /// <param name="primeInfoDataTable"></param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>              標準価格選択ＵＩ表示の速度改善</br>
        /// <br>              得意先掛率グループ取得処理の修正</br>
        private void PriceReSetting(EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable, EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable)
        {

            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsUnitData> goodsUnitDataList;
            //Dictionary<GoodsInfoKey, GoodsCndtn> goodsCndtnDictionary = new Dictionary<GoodsInfoKey, GoodsCndtn>();//DEL 2011/02/14
            Dictionary<string, GoodsCndtn> goodsCndtnDictionary = new Dictionary<string, GoodsCndtn>();//ADD 2011/02/14
            List<UnitPriceCalcRet> unitPriceCalcRetList;
            List<int> settingRowNoList = new List<int>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            try
            {
                estimateDetailDataTable.BeginLoadData();
                primeInfoDataTable.EndLoadData();

                #region 商品検索条件の生成

                foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailDataTable)
                {
                    if (( !string.IsNullOrEmpty(row.GoodsNo) ) && ( row.GoodsMakerCd != 0 ))
                    {
                        GoodsInfoKey goodsInfoKey = new GoodsInfoKey(row.GoodsNo, row.GoodsMakerCd);
                        //if (!(goodsCndtnDictionary.ContainsKey(goodsInfoKey))) //DEL 2011/02/14
                        if (!(goodsCndtnDictionary.ContainsKey(goodsInfoKey.GetKey()))) //ADD 2011/02/14
                        {
                            GoodsCndtn goodsCndtn = new GoodsCndtn();
                            goodsCndtn.EnterpriseCode = this._enterpriseCode;
                            goodsCndtn.GoodsNo = row.GoodsNo;
                            goodsCndtn.GoodsMakerCd = row.GoodsMakerCd;
                            goodsCndtn.SectionCode = this._salesSlip.ResultsAddUpSecCd;
                            //goodsCndtnDictionary.Add(goodsInfoKey, goodsCndtn);//DEL 2011/02/14
                            goodsCndtnDictionary.Add(goodsInfoKey.GetKey(), goodsCndtn);//ADD 2011/02/14
                        }
                    }

                    if (( !string.IsNullOrEmpty(row.GoodsNo_Prime) ) && ( row.GoodsMakerCd_Prime != 0 ))
                    {
                        GoodsInfoKey goodsInfoKey = new GoodsInfoKey(row.GoodsNo_Prime, row.GoodsMakerCd_Prime);
                        //if (!( goodsCndtnDictionary.ContainsKey(goodsInfoKey) ))//DEL 2011/02/14
                        if (!(goodsCndtnDictionary.ContainsKey(goodsInfoKey.GetKey())))//ADD 2011/02/14
                        {
                            GoodsCndtn goodsCndtn = new GoodsCndtn();
                            goodsCndtn.EnterpriseCode = this._enterpriseCode;
                            goodsCndtn.GoodsNo = row.GoodsNo_Prime;
                            goodsCndtn.GoodsMakerCd = row.GoodsMakerCd_Prime;
                            goodsCndtn.SectionCode = this._salesSlip.ResultsAddUpSecCd;
                            goodsCndtn.IsSettingSupplier = 1;
                            //goodsCndtnDictionary.Add(goodsInfoKey, goodsCndtn);//DEL 2011/02/14
                            goodsCndtnDictionary.Add(goodsInfoKey.GetKey(), goodsCndtn);//ADD 2011/02/14
                        }
                    }
                }

                foreach (EstimateInputDataSet.PrimeInfoRow row in primeInfoDataTable)
                {
                    if (( !string.IsNullOrEmpty(row.GoodsNo) ) && ( row.GoodsMakerCd != 0 ))
                    {
                        GoodsInfoKey goodsInfoKey = new GoodsInfoKey(row.GoodsNo, row.GoodsMakerCd);
                        //if (!(goodsCndtnDictionary.ContainsKey(goodsInfoKey)))//DEL 2011/02/14
                        if (!(goodsCndtnDictionary.ContainsKey(goodsInfoKey.GetKey())))//ADD 2011/02/14
                        {
                            GoodsCndtn goodsCndtn = new GoodsCndtn();
                            goodsCndtn.EnterpriseCode = this._enterpriseCode;
                            goodsCndtn.GoodsNo = row.GoodsNo;
                            goodsCndtn.GoodsMakerCd = row.GoodsMakerCd;
                            goodsCndtn.SectionCode = this._salesSlip.ResultsAddUpSecCd;
                            goodsCndtn.IsSettingSupplier = 1;
                            //goodsCndtnDictionary.Add(goodsInfoKey, goodsCndtn);//DEL 2011/02/14
                            goodsCndtnDictionary.Add(goodsInfoKey.GetKey(), goodsCndtn);//ADD 2011/02/14
                        }
                    }
                }

                foreach (GoodsCndtn goodsCndtn in goodsCndtnDictionary.Values)
                {
                    goodsCndtnList.Add(goodsCndtn);
                }

                #endregion

                #region 商品検索

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
                // goodsCndtnList＝ゼロ件の場合は検索不要
                if ( goodsCndtnList.Count == 0 )
                {
                    return;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

                string msg;
                int status = this.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataList, out msg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this.CacheGoodsUnitData(goodsUnitDataList);
                }
                #endregion

                #region 単価モジュール用パラメータ生成

                foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailDataTable)
                {

                    if (( !string.IsNullOrEmpty(row.GoodsNo) ) && ( row.GoodsMakerCd != 0 ))
                    {
                        // --- ADD 2011/02/14---------->>>>>
                        // 得意先掛率グループコード再セット
                        row.CustRateGrpCode = GetCustRateGroupForReSetting(_salesSlip.CustomerCode, row.GoodsMakerCd);
                        // --- ADD 2011/02/14----------<<<<<

                        GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd);
                        this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.UnitCost, TargetData.PureParts, true);
                        this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.ListPrice, TargetData.PureParts, false);
                        if (goodsUnitData != null)
                        {
                            unitPriceCalcParamList.Add(this.CreateUnitPriceCalcParam(TargetData.PureParts, row));
                        }
                    }

                    if (( !string.IsNullOrEmpty(row.GoodsNo_Prime) ) && ( row.GoodsMakerCd_Prime != 0 ))
                    {
                        // --- ADD 2011/02/14---------->>>>>
                        // 得意先掛率グループコード再セット
                        row.CustRateGrpCode_Prime = GetCustRateGroupForReSetting(_salesSlip.CustomerCode, row.GoodsMakerCd_Prime);
                        // --- ADD 2011/02/14----------<<<<<

                        GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(row.GoodsNo_Prime, row.GoodsMakerCd_Prime);
                        this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.UnitCost, TargetData.PrimeParts, true);
                        this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.ListPrice, TargetData.PrimeParts, false);
                        if (goodsUnitData != null)
                        {
                            unitPriceCalcParamList.Add(this.CreateUnitPriceCalcParam(TargetData.PrimeParts, row));
                        }
                    }
                }

                foreach (EstimateInputDataSet.PrimeInfoRow row in primeInfoDataTable)
                {
                    if (( !string.IsNullOrEmpty(row.GoodsNo) ) && ( row.GoodsMakerCd != 0 ))
                    {
                        // ------------ADD START wangf 2012/04/27 FOR Redmine#29640--------->>>>
                        // 得意先掛率グループコード再セット
                        row.CustRateGrpCode = GetCustRateGroupForReSetting(_salesSlip.CustomerCode, row.GoodsMakerCd);
                        // ------------ADD END wangf 2012/04/27 FOR Redmine#29640---------<<<<<
                        GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd);
                        this.PrimeInfoRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.UnitCost, true);
                        this.PrimeInfoRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.ListPrice, false);

                        if (goodsUnitData != null)
                        {
                            unitPriceCalcParamList.Add(this.CreateUnitPriceCalcParam(row));
                        }
                    }
                }

                #endregion

                // 単価一括再計算
                this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

                #region 算出結果のセット

                foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailDataTable)
                {
                    bool isTarget = false;
                    TargetData targetData = TargetData.All;
                    if (( !string.IsNullOrEmpty(row.GoodsNo) ) && ( row.GoodsMakerCd != 0 ))
                    {
                        targetData = TargetData.PureParts;
                        isTarget = true;
                    }

                    if (( !string.IsNullOrEmpty(row.GoodsNo_Prime) ) && ( row.GoodsMakerCd_Prime != 0 ))
                    {
                        targetData = ( targetData == TargetData.PureParts ) ? TargetData.All : TargetData.PrimeParts;
                        isTarget = true;
                    }

                    if (isTarget)
                    {
                        this.EstimateDetailRowPriceInfoSettingFromUnitPriceCalcRetList(targetData, row, unitPriceCalcRetList, true, false, true, true);
                    }
                }

                foreach (EstimateInputDataSet.PrimeInfoRow row in primeInfoDataTable)
                {
                    if (( !string.IsNullOrEmpty(row.GoodsNo) ) && ( row.GoodsMakerCd != 0 ))
                    {
                        this.PrimeInfoRowPriceInfoSettingFromUnitPriceCalcRetList(row, unitPriceCalcRetList, true, false, true, true);
                    }
                }
                #endregion
            }
            finally
            {
                estimateDetailDataTable.EndLoadData();
                primeInfoDataTable.EndLoadData();
            }
        }

        // --- ADD 2011/02/14---------->>>>>
        /// <summary>
        /// 得意先掛率グループコードを取得する処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカー</param>
        private int GetCustRateGroupForReSetting(int customerCode, int goodsMakerCode)
        {
            int custRateGrpCode;
            this.GetCustRateGrp(_custRateGroupList, customerCode, goodsMakerCode, out custRateGrpCode);

            return custRateGrpCode;
        }
        // --- ADD 2011/02/14----------<<<<<

		/// <summary>
		/// 明細の商品価格の再設定を行います。
		/// </summary>
        /// <param name="targetData">対象データ</param>
        /// <param name="salesRowNo">行番号</param>
        public void EstimateDetailRowPriceReSetting(TargetData targetData, int salesRowNo)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null)
            {
                this.EstimateDetailRowPriceReSetting(targetData, row);
            }
        }

        /// <summary>
        /// 明細の商品価格の再設定を行います。
        /// </summary>
        /// <param name="targetData"></param>
        /// <param name="row"></param>
        private void EstimateDetailRowPriceReSetting(TargetData targetData, EstimateInputDataSet.EstimateDetailRow row)
        {
            this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.ListPrice, targetData, false);
            this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.UnitCost, targetData, false);

            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            List<UnitPriceCalcRet> unitPriceCalcRetList;
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                GoodsUnitData goodsUnitDataPure = this.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd);
                if (goodsUnitDataPure != null)
                {
                    unitPriceCalcParamList.Add(this.CreateUnitPriceCalcParam(TargetData.PureParts, row));
                    goodsUnitDataList.Add(goodsUnitDataPure);
                }
            }
            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                GoodsUnitData goodsUnitDataPrime = this.GetGoodsUnitDataFromCache(row.GoodsNo_Prime, row.GoodsMakerCd_Prime);
                if (goodsUnitDataPrime != null)
                {
                    unitPriceCalcParamList.Add(this.CreateUnitPriceCalcParam(TargetData.PrimeParts, row));
                    goodsUnitDataList.Add(goodsUnitDataPrime);
                }
            }

            // 単価一括再計算
            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

            // 単価算出結果のセット
            this.EstimateDetailRowPriceInfoSettingFromUnitPriceCalcRetList(targetData, row, unitPriceCalcRetList, true, false, true, true);

        }

        /// <summary>
        /// 指定した定価を元に優良情報行オブジェクトの定価情報を設定します。
        /// </summary>
        /// <param name="row">優良情報行オブジェクト</param>
        /// <param name="priceInputType">金額入力モード</param>
        /// <param name="listPrice">単価</param>
        private void PrimeInfoRowListPriceSetting(EstimateInputDataSet.PrimeInfoRow row, PriceInputType priceInputType, double listPrice)
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();
            if (row != null)
            {
                // 消費税端数処理コード
                int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);

                double listPriceDisplay;
                double listPriceTaxExcFl;
                double listPriceTaxIncFl;
                int taxationDivCd;

                taxationDivCd = row.TaxationDivCd;
                this.CalclatePrice(priceInputType, listPrice, taxationDivCd, this._salesSlip.TotalAmountDispWayCd, this._salesSlip.ConsTaxLayMethod, this._salesSlip.ConsTaxRate, salesCnsTaxFrcProcCd, out listPriceTaxExcFl, out listPriceTaxIncFl, out listPriceDisplay);

                row.ListPriceTaxExcFl = listPriceTaxExcFl;
                row.ListPriceTaxIncFl = listPriceTaxIncFl;
                row.ListPriceDisplay = listPriceDisplay;
            }
        }

        /// <summary>
        /// 指定した定価を元に見積明細行オブジェクトの定価情報を設定します。
        /// </summary>
        /// <param name="row">見積明細行オブジェクト</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="priceInputType">金額入力モード</param>
        /// <param name="listPrice">単価</param>
        private void EstimateDetailRowListPriceSetting(EstimateInputDataSet.EstimateDetailRow row, TargetData targetData, PriceInputType priceInputType, double listPrice)
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            if (row != null)
            {
                // 消費税端数処理コード
                int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);

                double listPriceDisplay;
                double listPriceTaxExcFl;
                double listPriceTaxIncFl;
                int taxationDivCd;

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    taxationDivCd = row.TaxationDivCd;
                    this.CalclatePrice(priceInputType, listPrice, taxationDivCd, this._salesSlip.TotalAmountDispWayCd, this._salesSlip.ConsTaxLayMethod, this._salesSlip.ConsTaxRate, salesCnsTaxFrcProcCd, out listPriceTaxExcFl, out listPriceTaxIncFl, out listPriceDisplay);

                    row.ListPriceTaxExcFl = listPriceTaxExcFl;
                    row.ListPriceTaxIncFl = listPriceTaxIncFl;
                    row.ListPriceDisplay = listPriceDisplay;
                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    taxationDivCd = row.TaxationDivCd_Prime;
                    this.CalclatePrice(priceInputType, listPrice, taxationDivCd, this._salesSlip.TotalAmountDispWayCd, this._salesSlip.ConsTaxLayMethod, this._salesSlip.ConsTaxRate, salesCnsTaxFrcProcCd, out listPriceTaxExcFl, out listPriceTaxIncFl, out listPriceDisplay);

                    row.ListPriceTaxExcFl_Prime = listPriceTaxExcFl;
                    row.ListPriceTaxIncFl_Prime = listPriceTaxIncFl;
                    row.ListPriceDisplay_Prime = listPriceDisplay;
                }
            }
        }

		/// <summary>
		/// 指定した定価の値を元に見積明細行オブジェクトの定価情報を設定します。
		/// </summary>
		/// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="priceInputType">金額入力モード</param>
        /// <param name="listPrice">単価</param>
        public void EstimateDetailRowListPriceSetting( int salesRowNo, TargetData targetData, PriceInputType priceInputType, double listPrice )
		{
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            this.EstimateDetailRowListPriceSetting(row, targetData, priceInputType, listPrice);
		}

		/// <summary>
		/// 消費税率や課税区分が変更された場合に見積明細データテーブルの単価の調整を行います。
		/// </summary>
		public void EstimateDetailRowPriceAdjust()
		{
            this.EstimateDetailRowPriceAdjust(this._estimateDetailDataTable, this._primeInfoDataTable);
		}

		/// <summary>
		/// 消費税率や課税区分が変更された場合に見積明細データテーブルの単価の調整を行います。（オーバーロード）
		/// </summary>
		/// <param name="estimateDetailDataTable">見積明細データテーブルオブジェクト</param>
        /// <param name="primeInfoDataTable">優良情報データテーブル</param>
        private void EstimateDetailRowPriceAdjust(EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable, EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable)
		{
			foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailDataTable.Rows)
			{
				// 見積明細データセッティング処理（単価調整）
				this.EstimateDetailRowPriceAdjust(row);
                if (( row.PrimeInfoRelationGuid != null ) && ( row.PrimeInfoRelationGuid != Guid.Empty ))
                {
                    this.PrimeInfoTablePriceAdjust(row.PrimeInfoRelationGuid, primeInfoDataTable);
                }
			}
		}

		/// <summary>
		/// 消費税率や課税区分が変更された場合に見積明細データ行オブジェクトの単価の調整を行います。（オーバーロード）
		/// </summary>
        /// <param name="row">見積明細データテーブル行オブジェクト</param>
        public void EstimateDetailRowPriceAdjust(EstimateInputDataSet.EstimateDetailRow row)
		{

            if (row != null)
            {
                #region ○純正部品の価格設定

                #region 定価計算
                if (( row.ListPriceTaxExcFl != 0 ) || ( row.ListPriceTaxIncFl != 0 ))
                {
                    // 課税区分：「外税」
                    if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        // 定価計算
                        this.EstimateDetailRowListPriceSetting(row, TargetData.PureParts, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);
                    }
                    // 課税区分：「内税」
                    else if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        this.EstimateDetailRowListPriceSetting(row, TargetData.PureParts, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl);
                    }
                    // 課税区分：「非課税」
                    else
                    {
                        if (this._salesSlip.TotalAmountDispWayCd == 0)
                        {
                            this.EstimateDetailRowListPriceSetting(row, TargetData.PureParts, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);
                        }
                        else
                        {
                            this.EstimateDetailRowListPriceSetting(row, TargetData.PureParts, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl);
                        }
                    }
                }
                #endregion

                #region 原価計算
                if (row.SalesUnitCost != 0)
                {
                    this.CalculateCost(TargetData.PureParts, row);
                }
                #endregion

                #endregion

                #region ○優良部品の価格設定

                #region 定価計算
                if (( row.ListPriceTaxExcFl_Prime != 0 ) || ( row.ListPriceTaxIncFl_Prime != 0 ))
                {
                    // 課税区分：「外税」
                    if (row.TaxationDivCd_Prime == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        // 定価計算
                        this.EstimateDetailRowListPriceSetting(row, TargetData.PrimeParts, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl_Prime);
                    }
                    // 課税区分：「内税」
                    else if (row.TaxationDivCd_Prime == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        this.EstimateDetailRowListPriceSetting(row, TargetData.PrimeParts, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl_Prime);
                    }
                    // 課税区分：「非課税」
                    else
                    {
                        if (this._salesSlip.TotalAmountDispWayCd == 0)
                        {
                            this.EstimateDetailRowListPriceSetting(row, TargetData.PrimeParts, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl_Prime);
                        }
                        else
                        {
                            this.EstimateDetailRowListPriceSetting(row, TargetData.PrimeParts, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl_Prime);
                        }
                    }
                }
                #endregion

                #region 原価計算
                if (row.SalesUnitCost_Prime != 0)
                {
                    this.CalculateCost(TargetData.PrimeParts, row);
                }
                #endregion

                #endregion
            }
		}

        /// <summary>
        /// 消費税率や課税区分が変更された場合に指定された優良情報の単価の調整を行います。（オーバーロード）
        /// </summary>
        /// <param name="primeInfoRelationGuid">優良連結ＧＵＩＤ</param>
        /// <param name="primeInfoDataTable">優良情報データテーブル</param>
        public void PrimeInfoTablePriceAdjust(Guid primeInfoRelationGuid, EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable)
        {
            EstimateInputDataSet.PrimeInfoRow[] rows = (EstimateInputDataSet.PrimeInfoRow[])primeInfoDataTable.Select(string.Format("{0}='{1}'", primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeInfoRelationGuid));

            if (( rows != null ) && ( rows.Length > 0 ))
            {
                foreach (EstimateInputDataSet.PrimeInfoRow row in rows)
                {
                    #region 定価計算
                    if (( row.ListPriceTaxExcFl != 0 ) || ( row.ListPriceTaxIncFl != 0 ))
                    {
                        // 課税区分：「外税」
                        if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                        {
                            // 定価計算
                            this.PrimeInfoRowListPriceSetting(row, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);
                        }
                        // 課税区分：「内税」
                        else if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                        {
                            this.PrimeInfoRowListPriceSetting(row, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl);
                        }
                        // 課税区分：「非課税」
                        else
                        {
                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                this.PrimeInfoRowListPriceSetting(row, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);
                            }
                            else
                            {
                                this.PrimeInfoRowListPriceSetting(row, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl);
                            }
                        }
                    }
                    #endregion

                    #region 原価計算
                    if (row.SalesUnitCost != 0)
                    {
                        this.CalculateCost(row);
                    }
                    #endregion
                }
            }
        }

		/// <summary>
		/// 見積明細行オブジェクトの数量関係の情報を設定します。
		/// </summary>
        /// <param name="targetData">対象データ</param>
		/// <param name="salesRowNo">行番号</param>
        public void EstimateDetailRowCountInfoSetting( TargetData targetData, int salesRowNo )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row == null)
            {
                // 新規入力行
                if (row.SalesSlipDtlNum == 0)
                {
                    if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                    {
                        row.AcceptAnOrderCnt = row.ShipmentCnt;   // 受注数に出荷数をセット
                    }
                    if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                    {
                        row.AcceptAnOrderCnt_Prime = row.ShipmentCnt_Prime;   // 受注数に出荷数をセット
                    }
                }
                // 修正行
                else
                {
                    // 特に何もしない
                }
            }
        }


        /// <summary>
        /// 見積明細行の「印刷」の情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="columnName">カラム名</param>
        /// <param name="select">選択状態</param>
        public void EstimateDetailRowPrintSelectInfoSetting(int salesRowNo, string columnName)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                string target = columnName;
                string other = ( columnName == this._estimateDetailDataTable.PrintSelectColumn.ColumnName ) ? this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName : this._estimateDetailDataTable.PrintSelectColumn.ColumnName;
                bool select = !(bool)row[columnName];
                row[target] = select;
                row[other] = !select;
            }
        }

        /// <summary>
        /// 指定した総額表示方法区分を元に、見積明細データオブジェクトの表示価格を設定します。
        /// </summary>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        public void DisplayPriceSetting(int totalAmountDispWayCd)
        {
            this.EstimateDetailTableDisplayPriceSetting(totalAmountDispWayCd);
            this.PrimeInfoTableDisplayPriceSetting(totalAmountDispWayCd);
        }

		/// <summary>
		/// 指定した総額表示方法区分を元に、見積明細データオブジェクトの表示価格を設定します。
		/// </summary>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        private void EstimateDetailTableDisplayPriceSetting(int totalAmountDispWayCd)
		{
            for (int i = 0; i < this._estimateDetailDataTable.Rows.Count; i++)
            {
                EstimateInputDataSet.EstimateDetailRow row = (EstimateInputDataSet.EstimateDetailRow)this._estimateDetailDataTable.Rows[i];

                if (totalAmountDispWayCd == 0)
                {
                    switch (row.TaxationDivCd)
                    {
                        case (int)CalculateTax.TaxationCode.TaxExc:
                        case (int)CalculateTax.TaxationCode.TaxNone:
                            {
                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                break;
                            }
                        case (int)CalculateTax.TaxationCode.TaxInc:
                            {
                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                break;
                            }
                    }

                    switch (row.TaxationDivCd_Prime)
                    {
                        case (int)CalculateTax.TaxationCode.TaxExc:
                        case (int)CalculateTax.TaxationCode.TaxNone:
                            {
                                row.ListPriceDisplay_Prime = row.ListPriceTaxExcFl_Prime;
                                break;
                            }
                        case (int)CalculateTax.TaxationCode.TaxInc:
                            {
                                row.ListPriceDisplay_Prime = row.ListPriceTaxIncFl_Prime;
                                break;
                            }
                    }
                }
                else
                {
                    row.ListPriceDisplay = row.ListPriceTaxIncFl;
                    row.ListPriceDisplay_Prime = row.ListPriceTaxIncFl_Prime;
                }
            }
		}

        /// <summary>
        /// 指定した総額表示方法区分を元に、優良データオブジェクトの課税区分を設定します。
        /// </summary>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        private void PrimeInfoTableDisplayPriceSetting(int totalAmountDispWayCd)
        {
            for (int i = 0; i < this._primeInfoDataTable.Rows.Count; i++)
            {
                EstimateInputDataSet.PrimeInfoRow row = (EstimateInputDataSet.PrimeInfoRow)this._primeInfoDataTable.Rows[i];

                if (totalAmountDispWayCd == 0)
                {
                    switch (row.TaxationDivCd)
                    {
                        case (int)CalculateTax.TaxationCode.TaxExc:
                        case (int)CalculateTax.TaxationCode.TaxNone:
                            {
                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                break;
                            }
                        case (int)CalculateTax.TaxationCode.TaxInc:
                            {
                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                break;
                            }
                    }
                }
                else
                {
                    row.ListPriceDisplay = row.ListPriceTaxIncFl;
                }
            }
        }



        /// <summary>
        /// 指定した消費税率を元に見積明細データ行オブジェクトの金額情報を更新します。
        /// </summary>
        /// <param name="taxRate">消費税率</param>
        public void StockDetailRowTaxRateChanged(double taxRate)
		{
			// 仕入金額端数処理コード
			//int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._salesSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd); 
			int stockMoneyFrcProcCd = 0;

			// 消費税端数処理区分
			//int taxFracProcCode = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._salesSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd); 
			int taxFracProcCode = 0;

#if false
			for (int i = 0; i < this._stockDetailDataTable.Rows.Count; i++)
			{
				EstimateInputDataSet.EstimateDetailRow row = (EstimateInputDataSet.EstimateDetailRow)this._stockDetailDataTable.Rows[i];

				if (row.SalesGoodsCd == 6)
				{
					this.CalculationStockPrice(ref row);
				}
				else
				{
					// 課税区分が「外税」の場合
					if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
					{
						long stockPriceTaxInc;
						long stockPriceTaxExc;
						long stockPriceConsTax;
						double stockUnitPrice = row.StockUnitPriceFl;

						if (this.CalculationStockPrice(
							row.ShipmentCntDisplay,
							stockUnitPrice,
							row.TaxationDivCd,
							taxRate,
							stockMoneyFrcProcCd,
							taxFracProcCode,
							out stockPriceTaxInc,
							out stockPriceTaxExc,
							out stockPriceConsTax))
						{
							if (row.SalesGoodsCd <= 1)
							{
								row.StockPriceTaxInc = stockPriceTaxInc;
							}
						}
					}
					// 課税区分が「内税」の場合
					else if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
					{
						long stockPriceTaxInc;
						long stockPriceTaxExc;
						long stockPriceConsTax;
						double stockUnitPrice = row.StockUnitPriceFl;

						if (this.CalculationStockPrice(
							row.ShipmentCntDisplay,
							stockUnitPrice,
							row.TaxationDivCd,
							taxRate,
							stockMoneyFrcProcCd,
							taxFracProcCode,
							out stockPriceTaxInc,
							out stockPriceTaxExc,
							out stockPriceConsTax))
						{
							if (row.SalesGoodsCd <= 1)
							{
								row.StockPriceTaxExc = stockPriceTaxExc;
							}
						}
					}
				}
			}
#endif
		}

		/// <summary>
		/// 見積明細データテーブルの行番号を初期化（再採番）します。
		/// </summary>
		public void InitializeEstimateDetailSalesRowNoColumn()
		{
            try
            {
                this._estimateDetailDataTable.BeginLoadData();

                for (int i = 0; i < this._estimateDetailDataTable.Rows.Count; i++)
                {
                    int oldSalesRowNo = this._estimateDetailDataTable[i].SalesRowNo;
                    this._estimateDetailDataTable[i].SalesRowNo = i + 1;
                }
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
            }
        }

		/// <summary>
		/// 見積明細データテーブルの行ステータス列の値を初期化します。
		/// </summary>
		public void InitializeEstimateDetailRowStatusColumn()
		{
			EstimateInputDataSet.EstimateDetailRow[] rows = (EstimateInputDataSet.EstimateDetailRow[])this._estimateDetailDataTable.Select(this._estimateDetailDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

            try
            {
                this._estimateDetailDataTable.BeginLoadData();

                foreach (EstimateInputDataSet.EstimateDetailRow row in rows)
                {
                    row.RowStatus = 0;
                }
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
            }
		}

		/// <summary>
		/// 指定した行番号のリストを元に、該当する見積明細行オブジェクトの行ステータスに値を設定します。
		/// </summary>
		/// <param name="salesRowNoList">行番号リスト</param>
		/// <param name="rowStatus">RowStatus値</param>
		public void SetEstimateDetailRowStatusColumn(List<int> salesRowNoList, int rowStatus)
		{
            try
            {
                this._estimateDetailDataTable.BeginLoadData();

                foreach (int salesRowNo in salesRowNoList)
                {
                    EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

                    if (( row.GoodsName == "" ) && ( row.GoodsNo == "" )) continue;

                    row.RowStatus = rowStatus;
                }
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
            }
		}

		/// <summary>
		/// 見積明細データテーブルにコピー行が存在するかどうかをチェックします。
		/// </summary>
		/// <returns>true:コピーデータが存在する false:存在しない</returns>
		public bool ExistCopyEstimateDetailRow()
		{
			object value = this._estimateDetailDataTable.Compute("COUNT(" + this._estimateDetailDataTable.RowStatusColumn.ColumnName + ")", this._estimateDetailDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());
			if (value is System.DBNull) return false;

			int count = (int)value;

			if (count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 見積明細データテーブルにコピー行の行番号リストを取得します。
		/// </summary>
		/// <returns>行番号リスト</returns>
		public List<int> GetCopyEstimateDetailRowNo()
		{
			EstimateInputDataSet.EstimateDetailRow[] rows = (EstimateInputDataSet.EstimateDetailRow[])this._estimateDetailDataTable.Select(this._estimateDetailDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

			if ((rows != null) && (rows.Length > 0))
			{
				List<int> salesRowNoList = new List<int>();
				foreach (EstimateInputDataSet.EstimateDetailRow row in rows)
				{
					salesRowNoList.Add(row.SalesRowNo);
				}

				return salesRowNoList;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 指定したインデックスの見積明細データ行に対して行貼り付けを行う際、確認が必要かどうかをチェックします。
		/// </summary>
		/// <param name="copySalesRowNoList">コピー行行番号リスト</param>
		/// <param name="pasteIndex">貼り付け行Index</param>
		/// <returns>0:チェック不要 1:チェック必要 2:貼り付け不可</returns>
		public int CheckPasteEstimateDetailRow(List<int> copySalesRowNoList, int pasteIndex)
		{
			int check = 0;
			int pasteSalesRowNo = this._estimateDetailDataTable[pasteIndex].SalesRowNo;

			//for (int i = 0; i < copySalesRowNoList.Count; i++)
			//{
			//    EstimateInputDataSet.StockDetailRow sourceRow = this._estimateDetailDataTable.FindBySupplierSlipNoStockRowNo(this._salesSlip.SupplierSlipNo, copySalesRowNoList[i]);

			//    if (sourceRow == null)
			//    {
			//        continue;
			//    }

			//    EstimateInputDataSet.StockDetailRow row = this._estimateDetailDataTable.FindBySupplierSlipNoStockRowNo(this._salesSlip.SupplierSlipNo, pasteSalesRowNo + i);

			//    if (row != null)
			//    {
			//        if (( row.EditStatus != ctEDITSTATUS_AllOK ) && ( row.EditStatus != ctEDITSTATUS_RowDiscount ))
			//        {
			//            check = 2;
			//            break;
			//        }
			//        else if (( row.GoodsName != "" ) || ( row.GoodsNo != "" ))
			//        {
			//            check = 1;
			//        }
			//    }
			//}
			
			return check;
		}

		/// <summary>
		/// 見積明細データ行オブジェクトの貼り付けを行います。
		/// </summary>
		/// <param name="copySalesRowNoList">コピー行行番号リスト</param>
		/// <param name="pasteIndex">貼り付け行Index</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>              標準価格選択ＵＩ表示の速度改善</br>
        /// <br>Update Note: 2013/05/03 xujx</br>
        /// <br>管理番号   : 10801804-00 2013/05/15配信分</br>
        /// <br>           : Redmine#34803</br>
        /// <br>           : ①既存伝票を呼び出して、明細データをコピーする場合、「印刷」ボタンを押下して、エラーが発生することの対応</br>
        public void PasteEstimateDetailRow(List<int> copySalesRowNoList, int pasteIndex)
		{
			int pasteTargetSalesRowNo = this._estimateDetailDataTable[pasteIndex].SalesRowNo;

            try
            {
                this._estimateDetailDataTable.BeginLoadData();

                List<int> cutSalesRowNoList = new List<int>();
                List<int> pasteSalesRowNoList = new List<int>();
                List<int> deleteSalesRowNoList = new List<int>();
                List<EstimateInputDataSet.EstimateDetailRow> copyStockRowList = new List<EstimateInputDataSet.EstimateDetailRow>();

                foreach (int salesRowNo in copySalesRowNoList)
                {
                    EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

                    if (row != null)
                    {

                        Guid oldDtlRelationGuid = row.DtlRelationGuid;// ADD 2013/05/07 xujx FOR Redmine#34803
                        copyStockRowList.Add(this.CloneEstimateDetailRow(row));
                        row.DtlRelationGuid = oldDtlRelationGuid;// ADD 2013/05/07 xujx FOR Redmine#34803

                        if (row.RowStatus == ctROWSTATUS_CUT)
                        {
                            cutSalesRowNoList.Add(row.SalesRowNo);
                        }
                    }
                }

                if (cutSalesRowNoList.Count > 0)
                {
                    //UoeOrderDetailDataTableを更新処理
                    this.UpdateUoeOrderDetailDT(cutSalesRowNoList);// ADD 2013/05/07 xujx FOR Redmine#34803

                    // 見積明細行クリア処理
                    for (int i = 0; i < cutSalesRowNoList.Count; i++)
                    {
                        //this.ClearEstimateDetailRow(this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, cutSalesRowNoList[i]), TargetData.All);//DEL 2011/02/14
                        ClearEstimateDetailRow(this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, cutSalesRowNoList[i]), TargetData.All);//ADD 2011/02/14
                    }
                }

                for (int i = 0; i < copyStockRowList.Count; i++)
                {
                    EstimateInputDataSet.EstimateDetailRow sourceRow = copyStockRowList[i];
                    EstimateInputDataSet.EstimateDetailRow targetRow = null;

                    //this.AddEstimateDetailRow();
                    if (( pasteIndex + i ) < this._estimateDetailDataTable.Count)
                    {

                        targetRow = this._estimateDetailDataTable[pasteIndex + i];

                        this.CopyEstimateDetailRow(sourceRow, targetRow);

                        // コピー＆ペーストの場合にクリアする情報
                        if (!cutSalesRowNoList.Contains(copyStockRowList[i].SalesRowNo))
                        {
                            targetRow.CommonSeqNo = 0;
                            targetRow.SupplierFormalSync = 0;
                            targetRow.StockSlipDtlNumSync = 0;
                            targetRow.SalesSlipDtlNumSrc = 0;
                            targetRow.AcptAnOdrStatusSrc = 0;

                            targetRow.CommonSeqNo_Prime = 0;
                            targetRow.SupplierFormalSync_Prime = 0;
                            targetRow.StockSlipDtlNumSync_Prime = 0;
                            targetRow.SalesSlipDtlNumSrc_Prime = 0;
                            targetRow.AcptAnOdrStatusSrc_Prime = 0;

                            targetRow.PrimeInfoRelationGuid = Guid.Empty;
                            // --------------- ADD 2013/05/03 xujx FOR Redmine#34803 ---------->>>>
                            // 「貼り付け」する場合、売上明細通番を「0」に設定する
                            targetRow.SalesSlipDtlNum = 0;
                            targetRow.SalesSlipDtlNum_Prime = 0;
                            // --------------- ADD 2013/05/03 xujx FOR Redmine#34803 ----------<<<<

                            //targetRow.CommonSeqNo = 0;			// 共通通番
                            //targetRow.SalesSlipDtlNum = 0;		// 明細通番
                            //targetRow.SupplierFormalSrc = 0;	// 仕入形式（元）
                            //targetRow.StockSlipDtlNumSrc = 0;	// 仕入明細通番（元）
                            //targetRow.AcptAnOdrStatusSync = 0;	// 受注ステータス（同時）
                            //targetRow.SalesSlipDtlNumSync = 0;	// 売上明細通番（同時）
                            //targetRow.StockSlipCdDtl = 0;		// 仕入伝票区分（明細）
                            //targetRow.ShipmentCntDefault = 0;
                            //targetRow.StockCountMin = 0;
                            //targetRow.DtlRelationGuid = Guid.Empty;
                            //targetRow.EditStatus = ( targetRow.StockSlipCdDtl == 2 ) ? ctEDITSTATUS_RowDiscount : ctEDITSTATUS_AllOK;

                            //this.MemoInfoAdjust(ref targetRow);
                        }

                        pasteSalesRowNoList.Add(targetRow.SalesRowNo);
                    }
                }

                // 不要な行を削除する
                this.DeleteEstimateDetailRow(deleteSalesRowNoList, true);
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
            }

			/*
			// 最終行に商品名称が設定されている場合は１行追加
			if (this._estimateDetailDataTable[this._estimateDetailDataTable.Count - 1].GoodsName != "")
			{
				this.AddEstimateDetailRow();
			}
			*/
		}

        /// <summary>
        /// 見積明細行に行挿入可能かどうかチェックします。
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true:挿入可能 false:挿入不可</returns>
        public bool InsertEstimateDetailRowCheck(out string message)
        {
            message = string.Empty;
            EstimateInputDataSet.EstimateDetailRow row = (EstimateInputDataSet.EstimateDetailRow)this._estimateDetailDataTable.Rows[this._estimateDetailDataTable.Rows.Count - 1];

            if (row != null)
            {
                if (this.ExistDetailInput(row))
                {
                    message = "最終行が入力済みの為、行挿入できません。";
                    return false;
                }
            }
            return true;
        }

		/// <summary>
		/// 削除しようとする見積明細行オブジェクトが削除可能かどうかをチェックします。
		/// </summary>
		/// <param name="salesRowNoList">削除対象行番号リスト</param>
		/// <param name="message">メッセージ（out）</param>
		/// <returns>true:削除可能 false:削除不可</returns>
		public bool DeleteEstimateDetailRowCheck(List<int> salesRowNoList, out string message)
		{
			bool canDelete = true;
			bool exist = false;
			message = "";

			// 削除行の存在チェック
			int lastInputSalesRowNo = this.GetLastInputSalesRowNo();

			foreach (int salesRowNo in salesRowNoList)
			{
				if (salesRowNo < lastInputSalesRowNo)
				{
					exist = true;
					break;
				}
			}

			if (!exist)
			{
				foreach (int salesRowNo in salesRowNoList)
				{
                    EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

                    if (( row != null ) &&
                        ( ( !string.IsNullOrEmpty(row.GoodsName) ) || ( !string.IsNullOrEmpty(row.GoodsNo) ) || ( !string.IsNullOrEmpty(row.GoodsNo_Prime) )||(!string.IsNullOrEmpty(row.GoodsName_Prime) )))
                    {
						exist = true;
						break;
					}
				}
			}

			if (!exist)
			{
				message = "削除対象行が存在しません。";
				canDelete = false;
			}

			// 削除不可行が含まれているかどうかをチェックする。
			if (canDelete)
			{
				foreach (int salesRowNo in salesRowNoList)
				{
				    EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

                    if (( row != null ) && ( ( row.AlreadyAddUpCnt != 0 ) || ( row.AlreadyAddUpCnt_Prime != 0 ) ))
                    {
                        message = "計上されている為、削除できません。";
                        canDelete = false;
                        break;
                    }
                }
			}

			return canDelete;
		}

		/// <summary>
		/// 見積明細行オブジェクトの削除を行います。
		/// </summary>
		/// <param name="salesRowNoList">削除行StockRowNoリスト</param>
		public void DeleteEstimateDetailRow(List<int> salesRowNoList)
		{
			this.DeleteEstimateDetailRow(salesRowNoList, false);
		}

		/// <summary>
		/// 見積明細行オブジェクトの削除を行います。（オーバーロード）
		/// </summary>
        /// <param name="salesRowNoList">削除行SalesRowNoリスト</param>
		/// <param name="changeRowCount">true:行数を変更する false:行数を変更するは変更しない</param>
		public void DeleteEstimateDetailRow(List<int> salesRowNoList, bool changeRowCount)
		{
			if (salesRowNoList.Count == 0) return;

            try
            {
                this._estimateDetailDataTable.BeginLoadData();

                foreach (int salesRowNo in salesRowNoList)
                {
                    EstimateInputDataSet.EstimateDetailRow targetRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
                    if (targetRow == null) targetRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(ctDefaultSalesSlipNum, salesRowNo);
                    if (targetRow == null) continue;

                    this._estimateDetailDataTable.RemoveEstimateDetailRow(targetRow);
                }

                // 見積明細データテーブルSalesRowNo列初期化処理
                this.InitializeEstimateDetailSalesRowNoColumn();

                if (!changeRowCount)
                {
                    // 削除した分だけ新規に行を追加する
                    for (int i = 0; i < salesRowNoList.Count; i++)
                    {
                        this.AddEstimateDetailRow();
                    }
                }
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
            }
        }

		/// <summary>
		/// 見積明細行オブジェクトの追加を行います。
		/// </summary>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>              標準価格選択ＵＩ表示の速度改善</br>
        public void AddEstimateDetailRow()
		{
			int rowCount = this._estimateDetailDataTable.Rows.Count;

			EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.NewEstimateDetailRow();
			row.SalesSlipNum = this._currentSalesSlipNum;
			row.SalesRowNo = rowCount + 1;
            row.PrimeInfoRelationGuid = Guid.Empty;
			row.CarRelationGuid = Guid.Empty;
            row.UOEOrderGuid = Guid.Empty;
            row.UOEOrderGuid_Prime = Guid.Empty;
            row.PartsInfoLinkGuid = Guid.Empty;
            row.PartsInfoLinkGuid_Prime = Guid.Empty;
            //this.SettingEstimateDetailRowDtlRelationGuid(TargetData.All, row);//DEL 2011/02/14
            SettingEstimateDetailRowDtlRelationGuid(TargetData.All, row);//ADD 2011/02/14
            //row.DtlRelationGuid = Guid.Empty;
            //row.DtlRelationGuid_Prime = Guid.Empty;
            this._estimateDetailDataTable.AddEstimateDetailRow(row);
		}

		/// <summary>
		/// 見積明細データテーブルに初期表示行数分の行を追加します。
		/// </summary>
		public void AddEstimateDetailRowInitialRowCount()
		{
			EstimateInputDataSet.EstimateDetailRow[] estimateDetailRowArray = this.SelectEstimateDetailRows("", this._estimateDetailDataTable);

			int count = 1;
			if ((estimateDetailRowArray != null) && (estimateDetailRowArray.Length > 0))
			{
				count = estimateDetailRowArray.Length;
			}

			EstimateInputConstructionAcs estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();

			if (count < estimateInputConstructionAcs.DataInputCountValue)
			{
				for (int i = count; i < estimateInputConstructionAcs.DataInputCountValue; i++)
				{
					this.AddEstimateDetailRow();
				}
			}
			else
			{
				//this.AddEstimateDetailRow();
			}
		}


		/// <summary>
		/// 表示用の行番号を再採番します。
		/// </summary>
		public void AdjustRowNo()
		{
			int no = 1;
			foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
			{
                if ( row != null )
                {
                    row.SalesRowNoDisplay = no;
                    no++;
                }
            }
		}

		/// <summary>
		/// 指定した行番号から見積明細データ行オブジェクトのＩｎｄｅｘを取得します。
		/// </summary>
		/// <param name="salesRowNo">行番号</param>
		/// <returns>見積明細データ行オブジェクトのＩｎｄｅｘ</returns>
		public int GetIndexFromSalesRowNo(int salesRowNo)
		{
			int index = this._estimateDetailDataTable.Count - 1;
			
			for (int i = 0; i < this._estimateDetailDataTable.Count; i++)
			{
				if (this._estimateDetailDataTable[i].SalesRowNo == salesRowNo)
				{
					index = i;
					break;
				}
			}

			return index;
		}

		/// <summary>
		/// 見積明細行オブジェクトの挿入を行います。
		/// </summary>
		/// <param name="insertIndex">挿入行Index</param>
		/// <param name="explaDataInsert">詳細データ挿入処理</param>
		public void InsertEstimateDetailRow(int insertIndex, bool explaDataInsert)
		{
			this.InsertEstimateDetailRow(insertIndex, 1, explaDataInsert);
		}

		/// <summary>
		/// 見積明細行オブジェクトの挿入を行います。（オーバーロード）
		/// </summary>
		/// <param name="insertIndex">挿入行Index</param>
		/// <param name="line">挿入段数</param>
		/// <param name="explaDataInsert">詳細データ挿入処理</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>              標準価格選択ＵＩ表示の速度改善</br>
        public void InsertEstimateDetailRow(int insertIndex, int line, bool explaDataInsert)
		{
			if (line == 0) return;

            try
            {
                this._estimateDetailDataTable.BeginLoadData();

                int lastRowIndex = this._estimateDetailDataTable.Rows.Count - 1;
                int salesRowNo = this._estimateDetailDataTable[insertIndex].SalesRowNo;

                EstimateInputConstructionAcs estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();

                // 見積明細行追加処理
                for (int i = 0; i < line; i++)
                {
                    if (this._estimateDetailDataTable.Rows.Count < estimateInputConstructionAcs.DataInputCountValue)
                    {

                        this.AddEstimateDetailRow();
                    }
                }

                // 最終行から挿入対象行までの行情報を指定段ずつ下にコピーする
                for (int i = lastRowIndex; i >= insertIndex; i--)
                {
                    if (( i + line ) < this._estimateDetailDataTable.Rows.Count)
                    {
                        EstimateInputDataSet.EstimateDetailRow sourceRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, this._estimateDetailDataTable[i].SalesRowNo);
                        EstimateInputDataSet.EstimateDetailRow targetRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, this._estimateDetailDataTable[i + line].SalesRowNo);

                        this.CopyEstimateDetailRow(sourceRow, targetRow);
                    }
                }

                // 挿入対象行をクリアする
                EstimateInputDataSet.EstimateDetailRow clearRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, this._estimateDetailDataTable[insertIndex].SalesRowNo);
                //this.ClearEstimateDetailRow(clearRow, TargetData.All);//DEL 2011/02/14
                ClearEstimateDetailRow(clearRow, TargetData.All);//ADD 2011/02/14

                //// 最大行数を超えた行を削除する
                //if (this._estimateDetailDataTable.Rows.Count > this._estimateInputConstructionAcs.DataInputCountValue)
                //{
                //    while (this._estimateDetailDataTable.Rows.Count > this._estimateInputConstructionAcs.DataInputCountValue)
                //    {
                //        this._estimateDetailDataTable.Rows[this._estimateDetailDataTable.Rows.Count - 1].Delete();
                //    }
                //}
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
            }
        }

		/// <summary>
		/// 行取得処理
		/// </summary>
		/// <param name="salesRowNo"></param>
		/// <returns></returns>
		public EstimateInputDataSet.EstimateDetailRow GetEstimateDetailRow( int salesRowNo )
		{
			return this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
		}

		/// <summary>
		/// 商品名称が入力されている見積明細行オブジェクトが存在するかどうかをチェックします。
		/// </summary>
		/// <returns>true:存在する false:存在しない</returns>
		public bool ExistDetailData()
		{
			bool exist = false;

            foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
            {
                if (this.ExistDetailInput(row))
                {
                    exist = true;
                    break;
                }
            }

			return exist;
		}

        /// <summary>
        /// 対象行にデータが入力済みかチェックします。
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <returns></returns>
        public bool ExistDetailInput( int salesRowNo )
        {
            EstimateInputDataSet.EstimateDetailRow row = this.GetEstimateDetailRow(salesRowNo);
            return ( row == null ) ? false : this.ExistDetailInput(row);
        }

        /// <summary>
        /// 行にデータが入力済みかチェックします。
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ExistDetailInput( EstimateInputDataSet.EstimateDetailRow row )
        {
            //return ( !string.IsNullOrEmpty(row.GoodsNo) || !string.IsNullOrEmpty(row.GoodsName) || !string.IsNullOrEmpty(row.GoodsNo_Prime) || ( !string.IsNullOrEmpty(row.GoodsName_Prime) ) );
            return ( !string.IsNullOrEmpty(row.GoodsNo) || !string.IsNullOrEmpty(row.GoodsNo_Prime) );
        }

		/// <summary>
		/// 商品価格の再設定を行う必要がある商品が入力されている見積明細行オブジェクトが存在するかどうかをチェックします。
		/// </summary>
		/// <returns>true:存在する false:存在しない</returns>
		public bool ExistEstimateDetailCanGoodsPriceReSettingData()
		{
			bool exist = false;

            string filterString = string.Format("{0}={1} AND ({2} <> '{3}' OR {4} <> '{5}'", this._estimateDetailDataTable.EditStatusColumn.ColumnName, ctEDITSTATUS_AllOK, this._estimateDetailDataTable.GoodsNoColumn.ColumnName, string.Empty, this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, string.Empty);

			foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
			{
                //if (( row.EditStatus == ctEDITSTATUS_AllOK ) && ( row.GoodsNo != "" ))//Del zhangy3 2012/04/09 For Redmine#29312
                if ((row.EditStatus == ctEDITSTATUS_AllOK) && ((row.GoodsNo != "") || (row.GoodsNo_Prime != "")))//Add zhangy3 2012/04/09 For Redmine#29312
                {
                    exist = true;
                    break;
                }
			}

			return exist;
		}

        /// <summary>
        /// 見積明細テーブルで印刷選択されている行のリストを取得します。
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<int>> GetPrintSelectedRowNoList()
        {
            Dictionary<int, List<int>> retDictionary = new Dictionary<int, List<int>>();

            foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
            {
                bool purePartsSelect = false;
                bool primePartsSelect = false;
                if (row.PrintSelect)
                {
                    purePartsSelect = true;
                }

                if (row.PrintSelect_Prime)
                {
                    primePartsSelect = true;
                }

                if (purePartsSelect || primePartsSelect)
                {
                    List<int> derivNoList = new List<int>();
                    if (purePartsSelect) derivNoList.Add(0);
                    if (primePartsSelect) derivNoList.Add(1);

                    retDictionary.Add(row.SalesRowNo, derivNoList);
                }
            }
            return retDictionary;
        }

        /// <summary>
        /// 見積明細テーブルの追加情報を復元します。
        /// </summary>
        /// <param name="rowAddInfoDictionary"></param>
        public void EstimateDetailTableRestoreRowInfo(Dictionary<int, Dictionary<string, object>> rowAddInfoDictionary)
        {
            if (rowAddInfoDictionary == null) return;

            foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
            {
                if (rowAddInfoDictionary.ContainsKey(row.SalesRowNo))
                {
                    Dictionary<string, object> rowAddInfo = rowAddInfoDictionary[row.SalesRowNo];

                    // 印刷（純正）
                    if (rowAddInfo.ContainsKey(this._estimateDetailDataTable.PrintSelectColumn.ColumnName))
                    {
                        row.PrintSelect = (bool)rowAddInfo[this._estimateDetailDataTable.PrintSelectColumn.ColumnName];
                    }
                    
                    // 印刷(優良）
                    if (rowAddInfo.ContainsKey(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName))
                    {
                        row.PrintSelect_Prime = (bool)rowAddInfo[this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName];
                    }

                    // オプション
                    if (rowAddInfo.ContainsKey(this._estimateDetailDataTable.SpecialNoteColumn.ColumnName))
                    {
                        row.SpecialNote = (string)rowAddInfo[this._estimateDetailDataTable.SpecialNoteColumn.ColumnName];
                    }
                    // 規格
                    if (rowAddInfo.ContainsKey(this._estimateDetailDataTable.StandardNameColumn.ColumnName))
                    {
                        row.StandardName = (string)rowAddInfo[this._estimateDetailDataTable.StandardNameColumn.ColumnName];
                    }
                    // カタログ品番
                    if (rowAddInfo.ContainsKey(this._estimateDetailDataTable.CtlgPartsNoColumn.ColumnName))
                    {
                        row.CtlgPartsNo = (string)rowAddInfo[this._estimateDetailDataTable.CtlgPartsNoColumn.ColumnName];
                    }
                    // 結合元品番
                    if (rowAddInfo.ContainsKey(this._estimateDetailDataTable.JoinSourPartsNoWithHColumn.ColumnName))
                    {
                        row.JoinSourPartsNoWithH = (string)rowAddInfo[this._estimateDetailDataTable.JoinSourPartsNoWithHColumn.ColumnName];
                    }
                }
            }
        }

        /// <summary>
        /// 見積明細テーブルの印刷選択情報を復元します。
        /// </summary>
        /// <param name="printSelectedRowDictionary"></param>
        public void EstimateDetailTableRestorePrintSelectInfo(Dictionary<int, List<int>> printSelectedRowDictionary)
        {
            foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
            {
                if (printSelectedRowDictionary.ContainsKey(row.SalesRowNo))
                {
                    if (printSelectedRowDictionary[row.SalesRowNo].Contains(0))
                    {
                        row.PrintSelect = true;
                    }

                    if (printSelectedRowDictionary[row.SalesRowNo].Contains(1))
                    {
                        row.PrintSelect_Prime = true;
                    }
                }
            }
        }


		/// <summary>
		/// 指定したフィルタ文字列を使用して見積明細データテーブルの選択を行い、該当する見積明細行オブジェクト配列を取得します。
		/// </summary>
		/// <param name="filterExpression">フィルタをかけるための基準となる文字列</param>
		/// <param name="estimateDetailDataTable">見積明細データテーブルオブジェクト</param>
		/// <returns>見積明細行オブジェクト配列</returns>
		public EstimateInputDataSet.EstimateDetailRow[] SelectEstimateDetailRows( string filterExpression, EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable )
		{
			EstimateInputDataSet.EstimateDetailRow[] estimateDetailRowArray = null;

			try
			{
				DataRow[] rowArray = estimateDetailDataTable.Select(filterExpression);

				if (rowArray != null)
				{
					estimateDetailRowArray = (EstimateInputDataSet.EstimateDetailRow[])rowArray;
				}
			}
			catch { }

			return estimateDetailRowArray;
		}



		/// <summary>
		/// 商品が入力されている最終行の行番号を取得します。
		/// </summary>
		/// <returns>商品が入力されている最終行の行番号</returns>
		public int GetLastInputSalesRowNo()
		{
			DataRow[] rows = this._estimateDetailDataTable.Select(this._estimateDetailDataTable.GoodsNameColumn.ColumnName + " <> " + "''", this._estimateDetailDataTable.SalesRowNoColumn.ColumnName + " ASC");

			if ((rows == null) || (rows.Length == 0))
			{
				return 0;
			}
			else
			{
				EstimateInputDataSet.EstimateDetailRow row = (EstimateInputDataSet.EstimateDetailRow)rows[rows.Length - 1];
				return row.SalesRowNo;
			}
		}

		/// <summary>
		/// 見積明細行オブジェクトのクリアを行います。
		/// </summary>
		/// <param name="salesRowNoList">クリア対象行番号リスト</param>
		public void ClearEstimateDetailRow(List<int> salesRowNoList)
		{
			foreach (int salesRowNo in salesRowNoList)
			{
                //this.EstimateDetailRowClearStockInfo(salesRowNo);

				// 見積明細行クリア処理
                this.ClearEstimateDetailRow(salesRowNo);

			}
		}

		/// <summary>
		/// 見積明細行オブジェクトのクリアを行います。（オーバーロード）
		/// </summary>
		/// <param name="salesRowNo">クリア対象行番号</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>              標準価格選択ＵＩ表示の速度改善</br>
        public void ClearEstimateDetailRow(int salesRowNo)
		{
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

			if (row != null)
			{
                //this.ClearEstimateDetailRow(row, TargetData.All);//DEL 2011/02/14
                ClearEstimateDetailRow(row, TargetData.All);//ADD 2011/02/14
			}
		}

        /// <summary>
        /// 入力可能数量情報ツールチップ文字列を生成します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <returns>入力可能数量情報ツールチップ文字列</returns>
		public string CreateStockCountInfoString( int salesRowNo )
		{
			//EstimateInputDataSet.StockDetailRow stockDetailRow = this._estimateDetailDataTable.FindBySupplierSlipNoStockRowNo(this._salesSlip.SalesSlipNum, salesRowNo);
			EstimateInputDataSet.EstimateDetailRow estimateDetailRow = null;
			if (( estimateDetailRow == null ) ||
				( estimateDetailRow.GoodsName == "" ) ||
				//( stockDetailRow.SalesSlipCdDtl == 2 ) ||
				( estimateDetailRow.GoodsNo == "" ) ||
				( estimateDetailRow.GoodsMakerCd == 0 )) return "";

			int totalWidth = 4;

			StringBuilder toolTip = new StringBuilder();

			//if (( stockDetailRow.StockSlipDtlNumSrc != 0 ) && ( stockDetailRow.StockCountMax != 0 ))
			//{
			//    toolTip.Append("　");
			//    toolTip.Append("\r\n");

			//    string name = "";
			//    if (this._salesSlip.SupplierSlipCd == 20)
			//    {
			//        name = "返品可能数";
			//    }
			//    else if (stockDetailRow.SupplierFormalSrc == 1)
			//    {
			//        name = "入荷残";
			//    }
			//    else
			//    {
			//        name = "発注残";
			//    }

			//    toolTip.Append(string.Format("{0}", name.PadRight(totalWidth, '　') + "：" + stockDetailRow.StockCountMax.ToString("#0.00")));
			//    toolTip.Append("\r\n");
			//}

			//if (stockDetailRow.StockCountMin != 0)
			//{
			//    if (String.IsNullOrEmpty(toolTip.ToString().Trim()))
			//    {
			//        toolTip.Append("　");
			//        toolTip.Append("\r\n");
			//    }
			//    toolTip.Append("最低入力数".PadRight(totalWidth, '　') + "：" + stockDetailRow.StockCountMin.ToString() + "\r\n");
			//}

			return toolTip.ToString();
		}


		/// <summary>
		/// 読み取り専用行の存在チェックを行います。
		/// </summary>
		/// <returns>true:存在する false:存在しない</returns>
		public bool ExistAllReadonlyRow()
		{
            string expressionString = string.Format("COUNT({0}", this._estimateDetailDataTable.RowStatusColumn.ColumnName);
            string filterString = string.Format("{0}={1}", this._estimateDetailDataTable.EditStatusColumn.ColumnName, ctEDITSTATUS_AllReadOnly);
            object value = this._estimateDetailDataTable.Compute(expressionString, filterString);

			if (value is System.DBNull) return false;

			int count = (int)value;

			if (count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 見積明細データテーブル内で数量が０の明細行オブジェクトの行番号リストを取得します。
		/// </summary>
		/// <returns>行番号リスト</returns>
		public List<int> GetStockCountZeroSalesRowNoList()
		{
			List<int> deleteSalesRowNoList = new List<int>();

			DataRow[] rows = this._estimateDetailDataTable.Select(
                this._estimateDetailDataTable.ShipmentCntColumn.ColumnName + " = 0");

			if ((rows != null) && (rows.Length > 0))
			{
				EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])rows;

				foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailRows)
				{
					deleteSalesRowNoList.Add(row.SalesRowNo);
				}
			}

			return deleteSalesRowNoList;
		}

        /// <summary>
        /// 見積行番号リストより、テーブル上のインデックスのリストを取得します。
        /// </summary>
        /// <returns>行番号リスト</returns>
        public List<int> GetRowIndexListFromSalesRowNoList(List<int> salesRowNoList)
        {
            List<int> salesRowIndexList = new List<int>();

            for (int i = 0; i < this._estimateDetailDataTable.Rows.Count - 1; i++)
            {
                if (salesRowNoList.Contains(this._estimateDetailDataTable[i].SalesRowNo))
                {
                    salesRowIndexList.Add(i);
                }
            }

            return salesRowIndexList;
        }
        
        /// <summary>
        /// 見積明細データテーブル内で入力済みの行数を取得します。
        /// </summary>
        /// <returns>仕入行番号リスト</returns>
        public int GetAlreadyInputRowCount()
        {
            int cnt = 0;

            EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = this.SelectEstimateDetailRows(string.Format("{0}<>'' OR {1}<>'' OR {2}<>'' OR {3}<>''", this._estimateDetailDataTable.GoodsNameColumn.ColumnName, this._estimateDetailDataTable.GoodsNoColumn.ColumnName, this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName), this._estimateDetailDataTable);
            if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 )) cnt = estimateDetailRows.Length;

            return cnt;
        }

        /// <summary>
        /// 見積明細データテーブル内で商品名称が空白の見積明細行オブジェクトの行番号リストを取得します。
        /// </summary>
        /// <returns>行番号リスト</returns>
        public List<int> GetEmptySalesRowNoList()
		{
			List<int> deleteSalesRowNoList = new List<int>();

			DataRow[] rows = this._estimateDetailDataTable.Select(
				this._estimateDetailDataTable.GoodsNameColumn.ColumnName + " = ''");

			if ((rows != null) && (rows.Length > 0))
			{
				EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])rows;

				foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailRows)
				{
					deleteSalesRowNoList.Add(row.SalesRowNo);
				}
			}

			return deleteSalesRowNoList;
		}

		/// <summary>
		/// 見積明細データテーブル内で商品名称が入力されているの見積明細行オブジェクトの行番号リストを取得します。
		/// </summary>
		/// <returns>行番号リスト</returns>
		public List<int> GetInputSalesRowNoList
            ()
		{
			List<int> salesRowNoList = new List<int>();

			DataRow[] rows = this._estimateDetailDataTable.Select(
				this._estimateDetailDataTable.GoodsNameColumn.ColumnName + " <> ''",
				this._estimateDetailDataTable.SalesRowNoColumn.ColumnName + " ASC");

			if ((rows != null) && (rows.Length > 0))
			{
				EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])rows;

				foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailRows)
				{
					salesRowNoList.Add(row.SalesRowNo);
				}
			}

			return salesRowNoList;
		}

        // --------------- ADD 2013/05/07 xujx FOR Redmine#34803 ---------->>>>>>
        /// <summary>
        /// UoeOrderDataTableを更新処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : UoeOrderDataTable更新処理を実行します。</br>
        /// <br>Programmer : xujx</br>
        /// <br>Date       : 2013/05/07</br>
        /// </remarks>
        public void UpdateUoeOrderDT()
        {
            //商品が入力されている最終行の行番号
            int gridrows = this.GetLastInputSalesRowNo();
            //今のUOEGuidディクショナリ
            Dictionary<Guid, Guid> uoeDic = new Dictionary<Guid, Guid>();
            for (int salesRowNo = 1; salesRowNo <= gridrows; salesRowNo++)
            {
                EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

                if ((row != null) &&
                    ((!string.IsNullOrEmpty(row.GoodsName)) || (!string.IsNullOrEmpty(row.GoodsNo)) || (!string.IsNullOrEmpty(row.GoodsNo_Prime)) || (!string.IsNullOrEmpty(row.GoodsName_Prime))))
                {
                    if (!uoeDic.ContainsKey(row.UOEOrderGuid) && row.UOEOrderGuid != Guid.Empty)
                    {
                        uoeDic.Add(row.UOEOrderGuid, row.UOEOrderGuid_Prime);
                    }
                }
            }

            //UOEOrderDataTableを更新処理
            if (_uoeOrderDataTable != null)
            {
                DataTable tempDT = _uoeOrderDataTable.Copy();
                foreach (DataRow row in tempDT.Rows)
                {
                    //_uoeOrderDataTable明細のuoeOrderGuidを取得します。
                    Guid uoeOrderGuid = (Guid)row.ItemArray[0];
                    if (!uoeDic.ContainsKey(uoeOrderGuid))
                    {
                        EstimateInputDataSet.UOEOrderRow uoeOrderRow = this._uoeOrderDataTable.FindByOrderGuid(uoeOrderGuid);

                        if (uoeOrderRow != null)
                        {
                            //_uoeOrderDataTable削除処理
                            this._uoeOrderDataTable.RemoveUOEOrderRow(uoeOrderRow);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// UoeOrderDetailDataTableを更新処理
        /// </summary>
        /// <param name="salesRowNoList">削除対象行番号リスト</param>
        /// <remarks>
        /// <br>Note       : UoeOrderDetailDataTable更新処理を実行します。</br>
        /// <br>Programmer : xujx</br>
        /// <br>Date       : 2013/05/07</br>
        /// </remarks>
        public void UpdateUoeOrderDetailDT(List<int> salesRowNoList)
        {
            if (salesRowNoList != null)
            {
                foreach (int salesRowNo in salesRowNoList)
                {
                    EstimateInputDataSet.EstimateDetailRow targetRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
                    if (targetRow == null) targetRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(ctDefaultSalesSlipNum, salesRowNo);
                    if (targetRow == null) continue;


                    EstimateInputDataSet.UOEOrderDetailRow targetUoeOrderDetailRow = this._uoeOrderDetailDataTable.FindByDtlRelationGuid(targetRow.DtlRelationGuid);
                    if (targetUoeOrderDetailRow != null)
                    {
                        //_uoeOrderDetailDataTable削除処理
                        this._uoeOrderDetailDataTable.RemoveUOEOrderDetailRow(targetUoeOrderDetailRow);
                    }
                }
            }
        }

        // --------------- ADD 2013/05/07 xujx FOR Redmine#34803 ----------<<<<<<

		/// <summary>
		/// 見積明細データテーブル内で商品名称が入力されているの見積明細行オブジェクトの行番号リストを取得します。
		/// </summary>
		/// <param name="taxationCode">課税区分</param>
		/// <returns>行番号リスト</returns>
		private List<int> GetSalesRowNoListDesignateTaxationCode( CalculateTax.TaxationCode taxationCode )
		{
			List<int> salesRowNoList = new List<int>();

			string selectString = string.Format("{0}<>'' AND {1}={2}", this._estimateDetailDataTable.GoodsNameColumn.ColumnName, this._estimateDetailDataTable.TaxationDivCdColumn, (int)taxationCode);

			DataRow[] rows = this._estimateDetailDataTable.Select(selectString, this._estimateDetailDataTable.SalesRowNoColumn.ColumnName + " ASC");

			if (( rows != null ) && ( rows.Length > 0 ))
			{
				EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])rows;

				foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailRows)
				{
					salesRowNoList.Add(row.SalesRowNo);
				}
			}

			return salesRowNoList;
		}

        /// <summary>
        /// 合計金額設定処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        public void TotalPriceSetting(ref SalesSlip salesSlip, List<SalesDetail> salesDetailList)
        {
            if (salesSlip == null) return;
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 消費税端数処理コード

            long salesTotalTaxInc = 0;      // 売上伝票合計（税込）
            long salesTotalTaxExc = 0;      // 売上伝票合計（税抜）
            long salesSubtotalTax = 0;      // 売上小計（税）
            long itdedSalesOutTax = 0;      // 売上外税対象額
            long itdedSalesInTax = 0;       // 売上内税対象額
            long salSubttlSubToTaxFre = 0;  // 売上小計非課税対象額
            long salesOutTax = 0;           // 売上金額消費税額（外税）
            long salAmntConsTaxInclu = 0;   // 売上金額消費税額（内税）
            long salesDisTtlTaxExc = 0;     // 売上値引金額計（税抜）
            long itdedSalesDisOutTax = 0;   // 売上値引外税対象額合計
            long itdedSalesDisInTax = 0;    // 売上値引内税対象額合計
            long itdedSalesDisTaxFre = 0;   // 売上値引非課税対象額合計
            long salesDisOutTax = 0;        // 売上値引消費税額（外税）
            long salesDisTtlTaxInclu = 0;   // 売上値引消費税額（内税）
            long totalCost = 0;             // 原価金額計
            long stockGoodsTtlTaxExc = 0;   // 在庫商品合計金額（税抜）
            long pureGoodsTtlTaxExc = 0;    // 純正商品合計金額（税抜）
            long taxAdjust = 0;             // 消費税調整額
            long balanceAdjust = 0;         // 残高調整額
            long salesPrtSubttlInc = 0;     // 売上部品小計（税込）
            long salesPrtSubttlExc = 0;     // 売上部品小計（税抜）
            long salesWorkSubttlInc = 0;    // 売上作業小計（税込）
            long salesWorkSubttlExc = 0;    // 売上作業小計（税抜）
            long itdedPartsDisInTax = 0;    // 部品値引対象額合計（税込）
            long itdedPartsDisOutTax = 0;   // 部品値引対象額合計（税抜）
            long itdedWorkDisInTax = 0;     // 作業値引対象額合計（税込）
            long itdedWorkDisOutTax = 0;    // 作業値引対象額合計（税抜）
            long totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            this.CalculationSalesTotalPrice(
                salesDetailList,
                salesSlip.ConsTaxRate,
                salesTaxFrcProcCd,
                salesSlip.TotalAmountDispWayCd,
                salesSlip.ConsTaxLayMethod,
                out salesTotalTaxInc,
                out salesTotalTaxExc,
                out salesSubtotalTax,
                out itdedSalesOutTax,
                out itdedSalesInTax,
                out salSubttlSubToTaxFre,
                out salesOutTax,
                out salAmntConsTaxInclu,
                out salesDisTtlTaxExc,
                out itdedSalesDisOutTax,
                out itdedSalesDisInTax,
                out itdedSalesDisTaxFre,
                out salesDisOutTax,
                out salesDisTtlTaxInclu,
                out totalCost,
                out stockGoodsTtlTaxExc,
                out pureGoodsTtlTaxExc,
                out balanceAdjust,
                out taxAdjust,
                out salesPrtSubttlInc,
                out salesPrtSubttlExc,
                out salesWorkSubttlInc,
                out salesWorkSubttlExc,
                out itdedPartsDisInTax,
                out itdedPartsDisOutTax,
                out itdedWorkDisInTax,
                out itdedWorkDisOutTax,
                out totalMoneyForGrossProfit);


            salesSlip.SalesSubtotalTaxInc = salesTotalTaxInc;       // 売上小計（税込）
            salesSlip.SalesSubtotalTaxExc = salesTotalTaxExc;       // 売上小計（税抜）
            salesSlip.SalesSubtotalTax = salesSubtotalTax;          // 売上小計（税）
            salesSlip.ItdedSalesOutTax = itdedSalesOutTax;          // 売上外税対象額
            salesSlip.ItdedSalesInTax = itdedSalesInTax;            // 売上内税対象額
            salesSlip.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // 売上小計非課税対象額
            salesSlip.SalesOutTax = salesOutTax;                    // 売上金額消費税額（外税）
            salesSlip.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // 売上金額消費税額（内税）
            salesSlip.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // 売上値引金額計（税抜）
            salesSlip.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // 売上値引外税対象額合計
            salesSlip.ItdedSalesDisInTax = itdedSalesDisInTax;      // 売上値引内税対象額合計
            salesSlip.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // 売上値引非課税対象額合計
            salesSlip.SalesDisOutTax = salesDisOutTax;              // 売上値引消費税額（外税）
            salesSlip.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // 売上値引消費税額（内税）
            salesSlip.TotalCost = totalCost;                        // 原価金額計
            salesSlip.StockGoodsTtlTaxExc = stockGoodsTtlTaxExc;    // 在庫商品合計金額（税抜）
            salesSlip.PureGoodsTtlTaxExc = pureGoodsTtlTaxExc;      // 純正商品合計金額（税抜）
            salesSlip.SalesPrtSubttlInc = salesPrtSubttlInc;                // 売上部品小計（税込）
            salesSlip.SalesPrtSubttlExc = salesPrtSubttlExc;                // 売上部品小計（税抜）
            salesSlip.SalesWorkSubttlInc = salesWorkSubttlInc;              // 売上作業小計（税込）
            salesSlip.SalesWorkSubttlExc = salesWorkSubttlExc;              // 売上作業小計（税抜）
            salesSlip.ItdedPartsDisInTax = itdedPartsDisInTax;              // 部品値引対象額合計（税込）
            salesSlip.ItdedPartsDisOutTax = itdedPartsDisOutTax;            // 部品値引対象額合計（税抜）
            salesSlip.ItdedWorkDisInTax = itdedWorkDisInTax;                // 作業値引対象額合計（税込）
            salesSlip.ItdedWorkDisOutTax = itdedWorkDisOutTax;              // 作業値引対象額合計（税抜）
            salesSlip.TotalMoneyForGrossProfit = totalMoneyForGrossProfit; // 粗利計算用売上金額

            salesSlip.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;                   // 売上伝票合計（税込）= 売上伝票合計（税込） + 売上小計非課税対象額
            salesSlip.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;                   // 売上伝票合計（税抜）= 売上伝票合計（税抜） + 売上小計非課税対象額
            salesSlip.SalesNetPrice = itdedSalesOutTax + itdedSalesInTax + salSubttlSubToTaxFre;    // 売上正価金額 = 売上外税対象額 + 売上内税対象額 + 売上小計非課税対象額
            salesSlip.AccRecConsTax = salesSubtotalTax;                                             // 売掛消費税
            salesSlip.SalesPrtTotalTaxInc = salesPrtSubttlInc + itdedPartsDisInTax;                 // 売上部品合計（税込）
            salesSlip.SalesPrtTotalTaxExc = salesPrtSubttlExc + itdedPartsDisOutTax;                // 売上部品合計（税抜）
            salesSlip.SalesWorkTotalTaxInc = salesWorkSubttlInc + itdedWorkDisInTax;                // 売上作業合計（税込）
            salesSlip.SalesWorkTotalTaxExc = salesWorkSubttlExc + itdedWorkDisOutTax;               // 売上作業合計（税抜）
        }

        /// <summary>
        /// 売上金額の合計を計算します。
        /// </summary>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="pureGoodsTtlTaxExc">純正商品合計金額(税抜)</param>
        /// <param name="stockGoodsTtlTaxExc">在庫商品合計金額(税抜)</param>
        /// <param name="consTaxRate">消費税税率</param>
        /// <param name="salesTaxFrcProcCd">消費税端数処理コード</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <param name="salesTotalTaxInc">売上伝票合計（税込）</param>
        /// <param name="salesTotalTaxExc">売上伝票合計（税抜）</param>
        /// <param name="salesSubtotalTax">売上小計（税）</param>
        /// <param name="itdedSalesOutTax">売上外税対象額</param>
        /// <param name="itdedSalesInTax">売上内税対象額</param>
        /// <param name="salSubttlSubToTaxFre">売上小計非課税対象額</param>
        /// <param name="salesOutTax">売上金額消費税額（外税）</param>
        /// <param name="salAmntConsTaxInclu">売上金額消費税額（内税）</param>
        /// <param name="salesDisTtlTaxExc">売上値引金額計（税抜）</param>
        /// <param name="itdedSalesDisOutTax">売上値引外税対象額合計</param>
        /// <param name="itdedSalesDisInTax">売上値引内税対象額合計</param>
        /// <param name="itdedSalesDisTaxFre">売上値引非課税対象額合計</param>
        /// <param name="salesDisOutTax">売上値引消費税額（外税）</param>
        /// <param name="salesDisTtlTaxInclu">売上値引消費税額（内税）</param>
        /// <param name="totalCost">原価金額計</param>
        /// <param name="balanceAdjust">消費税調整額</param>
        /// <param name="taxAdjust">残高調整額</param>
        /// <param name="salesPrtSubttlInc">売上部品小計（税込）</param>
        /// <param name="salesPrtSubttlExc">売上部品小計（税抜）</param>
        /// <param name="salesWorkSubttlInc">売上作業小計（税込）</param>
        /// <param name="salesWorkSubttlExc">売上作業小計（税抜）</param>
        /// <param name="itdedPartsDisInTax">部品値引対象額合計（税込）</param>
        /// <param name="itdedPartsDisOutTax">部品値引対象額合計（税抜）</param>
        /// <param name="itdedWorkDisInTax">作業値引対象額合計（税込）</param>
        /// <param name="itdedWorkDisOutTax">作業値引対象額合計（税抜）</param>
        /// <param name="totalMoneyForGrossProfit">粗利計算用売上金額</param>
        public void CalculationSalesTotalPrice( List<SalesDetail> salesDetailList, double consTaxRate, int salesTaxFrcProcCd, int totalAmountDispWayCd, int consTaxLayMethod, out long salesTotalTaxInc, out long salesTotalTaxExc, out long salesSubtotalTax, out long itdedSalesOutTax, out long itdedSalesInTax, out long salSubttlSubToTaxFre, out long salesOutTax, out long salAmntConsTaxInclu, out long salesDisTtlTaxExc, out long itdedSalesDisOutTax, out long itdedSalesDisInTax, out long itdedSalesDisTaxFre, out long salesDisOutTax, out long salesDisTtlTaxInclu, out long totalCost, out long stockGoodsTtlTaxExc, out long pureGoodsTtlTaxExc, out long balanceAdjust, out long taxAdjust, out long salesPrtSubttlInc, out long salesPrtSubttlExc, out long salesWorkSubttlInc, out long salesWorkSubttlExc, out long itdedPartsDisInTax, out long itdedPartsDisOutTax, out long itdedWorkDisInTax, out long itdedWorkDisOutTax, out long totalMoneyForGrossProfit )
        {
            // 消費税端数処理単位、端数処理区分を取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._estimateInputInitDataAcs.GetSalesFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            salesTotalTaxInc = 0;       // 売上伝票合計（税込）
            salesTotalTaxExc = 0;       // 売上伝票合計（税抜）
            salesSubtotalTax = 0;       // 売上小計（税）
            itdedSalesOutTax = 0;       // 売上外税対象額
            itdedSalesInTax = 0;        // 売上内税対象額
            salSubttlSubToTaxFre = 0;   // 売上小計非課税対象額
            salesOutTax = 0;            // 売上金額消費税額（外税）
            salAmntConsTaxInclu = 0;    // 売上金額消費税額（内税）
            salesDisTtlTaxExc = 0;      // 売上値引金額計（税抜）
            itdedSalesDisOutTax = 0;    // 売上値引外税対象額合計
            itdedSalesDisInTax = 0;     // 売上値引内税対象額合計
            itdedSalesDisTaxFre = 0;    // 売上値引非課税対象額合計
            salesDisOutTax = 0;         // 売上値引消費税額（外税）
            salesDisTtlTaxInclu = 0;    // 売上値引消費税額（内税）
            stockGoodsTtlTaxExc = 0;    // 在庫商品合計金額（税抜）
            pureGoodsTtlTaxExc = 0;     // 純正商品合計金額（税抜）
            totalCost = 0;              // 原価金額計
            taxAdjust = 0;              // 消費税調整額
            balanceAdjust = 0;          // 残高調整額
            salesPrtSubttlInc = 0;      // 売上部品小計（税込）
            salesPrtSubttlExc = 0;      // 売上部品小計（税抜）
            salesWorkSubttlInc = 0;     // 売上作業小計（税込）
            salesWorkSubttlExc = 0;     // 売上作業小計（税抜）
            itdedPartsDisInTax = 0;     // 部品値引対象額合計（税込）
            itdedPartsDisOutTax = 0;    // 部品値引対象額合計（税抜）
            itdedWorkDisInTax = 0;      // 作業値引対象額合計（税込）
            itdedWorkDisOutTax = 0;     // 作業値引対象額合計（税抜）
            totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            long itdedSalesInTax_TaxInc = 0;    // 売上内税対象額（税込）
            long itdedSalesDisInTax_TaxInc = 0; // 売上値引内税対象額合計（税込）
            long totalMoney_TaxInc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（内税商品分）
            long totalMoney_TaxExc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（外税商品分）
            long totalMoney_TaxNone_ForGrossProfitMoney = 0;    // 粗利計算用売上金額計（非課税商品分）
            long stockGoodsTtlTaxExc_TaxInc = 0;                // 在庫商品合計金額（税抜）（内税商品分）
            long stockGoodsTtlTaxExc_TaxExc = 0;                // 在庫商品合計金額（税抜）（外税商品分）
            long stockGoodsTtlTaxExc_TaxNone = 0;               // 在庫商品合計金額（税抜）（非課税商品分）
            long pureGoodsTtlTaxExc_TaxInc = 0;                 // 純正商品合計金額（税抜）（内税商品分）
            long pureGoodsTtlTaxExc_TaxExc = 0;                 // 純正商品合計金額（税抜）（外税商品分）
            long pureGoodsTtlTaxExc_TaxNone = 0;                // 純正商品合計金額（税抜）（非課税商品分）

            //-----------------------------------------------------------------------------
            // 計算に必要な金額の計算
            //-----------------------------------------------------------------------------
            #region ●計算に必要な金額の計算

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // 売上伝票区分（明細）によって集計方法が変わる分
                switch (salesDetail.SalesSlipCdDtl)
                {
                    // 売上、返品
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales:
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods:
                        {
                            // 税区分：外税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // 売上外税対象額
                                itdedSalesOutTax += salesDetail.SalesMoneyTaxExc;

                                // 売上金額消費税額（外税）
                                salesOutTax += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（外税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（外税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                            }
                            // 税区分：内税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // 売上内税対象額
                                itdedSalesInTax += salesDetail.SalesMoneyTaxExc;

                                // 売上内税対象額（税込）
                                itdedSalesInTax_TaxInc += salesDetail.SalesMoneyTaxInc;

                                // 売上金額消費税額（内税）
                                salAmntConsTaxInclu += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（内税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（内税商品分）
                                if ( salesDetail.GoodsKindCode == 0 )
                                    pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                            }
                            // 税区分：非課税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // 売上小計非課税対象額
                                salSubttlSubToTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 在庫商品合計金額（税抜）（非課税商品分）
                                if ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock )
                                    stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（非課税商品分）
                                if( salesDetail.GoodsKindCode == 0 )
                                    pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                            }

                            // 売上部品小計（税込）
                            salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc;
                            // 売上部品小計（税抜）
                            salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // 値引き
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount:
                        {
                            // 税区分：外税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // 売上値引外税対象額合計
                                itdedSalesDisOutTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引消費税額（外税）
                                salesDisOutTax += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（外税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（外税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：内税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // 売上値引内税対象額合計
                                itdedSalesDisInTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引内税対象額合計（税込）
                                itdedSalesDisInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                                // 売上値引消費税額（内税）
                                salesDisTtlTaxInclu += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（内税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（内税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：非課税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // 売上値引非課税対象額合計
                                itdedSalesDisTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（非課税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（非課税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                }
                            }

                            // 部品値引対象額合計（税込）
                            itdedPartsDisInTax += salesDetail.SalesMoneyTaxInc;

                            // 部品値引対象額合計（税抜）
                            itdedPartsDisOutTax += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }
                            
                            break;
                        }
                    // 注釈
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Annotation:
                        {
                            break;
                        }
                    // 作業
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Work:
                        {
                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }
                            break;
                        }
                    // 小計
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal:
                        {
                            break;
                        }
                }

                if (salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal)
                {
                    // 残高調整額
                    if (( salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust ) ||
                        ( salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust ))
                    {
                        balanceAdjust += salesDetail.SalesMoneyTaxInc;
                    }

                    // 消費税調整額
                    if (( salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust ) ||
                        ( salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust ))
                    {
                        taxAdjust += salesDetail.SalesPriceConsTax;
                    }
                }

                //// 売上外税対象額
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc ) &&
                //    ( ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales ) ||
                //      ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods ) ))
                //{
                //    itdedSalesOutTax += salesDetail.SalesMoneyTaxExc;
                //}

                //// 売上金額消費税額（外税）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc ) &&
                //    ( ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales ) ||
                //      ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods ) ))
                //{
                //    salesOutTax += salesDetail.SalesPriceConsTax;
                //}

                //// 売上内税対象額
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) &&
                //    ( ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales ) ||
                //      ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods ) ))
                //{
                //    itdedSalesInTax += salesDetail.SalesMoneyTaxExc;
                //}

                //// 売上内税対象額（税込）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) &&
                //    ( ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales ) ||
                //      ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods ) ))
                //{
                //    itdedSalesInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                //}

                //// 売上金額消費税額（内税）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) &&
                //    ( ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales ) ||
                //      ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods ) ))
                //{
                //    salAmntConsTaxInclu += salesDetail.SalesPriceConsTax;
                //}

                //// 売上小計非課税対象額
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone ) &&
                //    ( ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales ) ||
                //      ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods ) ))
                //{
                //    salSubttlSubToTaxFre += salesDetail.SalesMoneyTaxInc;
                //}

                //// 売上値引外税対象額合計
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc ) &&
                //    ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount ))
                //{
                //    itdedSalesDisOutTax += salesDetail.SalesMoneyTaxExc;
                //}

                //// 売上値引消費税額（外税）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc ) &&
                //    ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount ))
                //{
                //    salesDisOutTax += salesDetail.SalesPriceConsTax;
                //}

                //// 売上値引内税対象額合計
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) &&
                //    ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount ))
                //{
                //    itdedSalesDisInTax += salesDetail.SalesMoneyTaxExc;
                //}

                //// 売上値引内税対象額合計（税込）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) &&
                //    ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount ))
                //{
                //    itdedSalesDisInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                //}

                //// 売上値引消費税額（内税）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) &&
                //    ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount ))
                //{
                //    salesDisTtlTaxInclu += salesDetail.SalesPriceConsTax;
                //}

                //// 売上値引非課税対象額合計
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone ) &&
                //    ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount ))
                //{
                //    itdedSalesDisTaxFre += salesDetail.SalesMoneyTaxInc;
                //}

                //// 残高調整額
                //if (( salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust ) ||
                //    ( salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust ))
                //{
                //    balanceAdjust += salesDetail.SalesMoneyTaxInc;
                //}

                //// 消費税調整額
                //if (( salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust ) ||
                //    ( salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust ))
                //{
                //    taxAdjust += salesDetail.SalesPriceConsTax;
                //}

                //// 原価金額計
                //totalCost += salesDetail.Cost;

                //// 粗利計算用売上金額計（内税商品分）
                //if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                //{
                //    totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                //}

                //// 粗利計算用売上金額計（外税商品分）
                //if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                //{
                //    totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                //}

                //// 粗利計算用売上金額計（非課税商品分）
                //if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                //{
                //    totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                //}

                //// 在庫商品合計金額（税抜）（内税商品分）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) &&
                //    ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock ))
                //{
                //    stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                //}

                //// 在庫商品合計金額（税抜）（外税商品分）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc ) &&
                //    ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock ))
                //{
                //    stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                //}

                //// 在庫商品合計金額（税抜）（非課税商品分）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone ) &&
                //    ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock ))
                //{
                //    stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                //}

                //// 純正商品合計金額（税抜）（内税商品分）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) &&
                //    ( salesDetail.GoodsKindCode == 0 ))
                //{
                //    pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                //}

                //// 純正商品合計金額（税抜）（外税商品分）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc ) &&
                //    ( salesDetail.GoodsKindCode == 0 ))
                //{
                //    pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                //}

                //// 純正商品合計金額（税抜）（非課税商品分）
                //if (( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone ) &&
                //    ( salesDetail.GoodsKindCode == 0 ))
                //{
                //    pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                //}

                //// 売上部品小計（税込）
                //if (( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales ) ||
                //    ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods ))
                //{
                //    salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc;
                //}

                //// 売上部品小計（税抜）
                //if (( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales ) ||
                //    ( salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods ))
                //{
                //    salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc;
                //}

                //// 部品値引対象額合計（税込）
                //if (salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount)
                //{
                //    itdedPartsDisInTax += salesDetail.SalesMoneyTaxInc;
                //}

                //// 部品値引対象額合計（税抜）
                //if (salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount)
                //{
                //    itdedPartsDisOutTax += salesDetail.SalesMoneyTaxExc;
                //}
            }

            // 売上値引金額計（税抜）
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // 粗利計算用売上金額計
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // 在庫商品合計金額（税抜）
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone;

            // 純正商品合計金額（税抜）
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone;

            #endregion

            #region ●転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            // 転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == 9)
            {
                // 売上金額消費税額（外税）
                salesOutTax = 0;

                // 売上金額消費税額（内税）
                salAmntConsTaxInclu = 0;

                // 売上小計非課税対象額
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // 売上外税対象額
                itdedSalesOutTax = 0;

                // 売上内税対象額
                itdedSalesInTax = 0;

                // 売上内税対象額（税込）
                itdedSalesInTax_TaxInc = 0;

                // 売上値引消費税額（外税）
                salesDisOutTax = 0;

                // 売上値引消費税額（内税）
                salesDisTtlTaxInclu = 0;

                // 売上値引非課税対象額合計
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // 売上値引外税対象額合計
                itdedSalesDisOutTax = 0;

                // 売上値引内税対象額合計
                itdedSalesDisInTax = 0;

                // 売上値引内税対象額合計（税込）
                itdedSalesDisInTax_TaxInc = 0;

                // 売上値引金額計（税抜）
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ●各種金額算出
            //-----------------------------------------------------------------------------
            // 各種金額算出
            //-----------------------------------------------------------------------------

            // 明細転嫁以外
            if (consTaxLayMethod != 1)
            {
                //-----------------------------------------------------------------------------
                // ① 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計 + 売上値引非課税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税込）： 売上内税対象額（税込） + 売上外税対象額 + 売上値引内税対象額合計（税込） + 売上値引外税対象額合計 + 売上値引非課税対象額合計 + (売上外税対象額 + 売上値引外税対象額合計)×税率)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ③ 売上小計（税）：② - ①
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // ④ 売上金額消費税額（外税）：売上外税対象額 × 税率
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // ⑤ 売上金額消費税額（外税）(税抜、値引き含む) ：(売上外税対象額 + 売上値引外税対象額合計) × 税率
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑥ 売上値引消費税額（外税）：④ - ⑤
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //-----------------------------------------------------------------------------
                // ⑦ 売上部品小計（税込）：(売上部品小計（税抜）+ 部品値引対象額合計（税抜）) × 税率
                //-----------------------------------------------------------------------------
                salesPrtSubttlInc = salesPrtSubttlExc + itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc + itdedPartsDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑧ 部品値引対象額合計（税込）：部品値引対象額合計（税抜）× 税率
                //-----------------------------------------------------------------------------
                itdedPartsDisInTax = itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedPartsDisOutTax);
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // 明細転嫁
            else 
            {
                //-----------------------------------------------------------------------------
                // ① 売上小計（税）：売上金額消費税額（外税） + 売上金額消費税額（内税） +  売上値引消費税額（外税） + 売上値引消費税額（内税）
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // ③ 売上伝票合計（税込）：① + ②
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion
        }

        /// <summary>
        /// 原価金額を計算します。
        /// </summary>
        /// <param name="targetData">対象データ</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <remarks>
        /// <br>Call：商品検索／定価／原単価／原価率 変更時</br>
        /// </remarks>
        public void CalculateCost( TargetData targetData, int salesRowNo )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            this.CalculateCost(targetData, row);
        }

        /// <summary>
        /// 原価計算
        /// </summary>
        /// <param name="targetData">対象データ</param>
        /// <param name="row">見積明細行</param>
        private void CalculateCost( TargetData targetData, EstimateInputDataSet.EstimateDetailRow row )
        {
            if (row != null)
            {
                if (_supplierAcs == null) _supplierAcs = new SupplierAcs();

                double taxRate = this._salesSlip.ConsTaxRate;
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    int stockMoneyFrcProcCd = ( row.SupplierCd == 0 ) ? 0 : this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);
                    int taxFracProcCode = ( row.SupplierCd == 0 ) ? 0 : this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);

                    long costTaxInc = 0;
                    long costTaxExc = 0;
                    long costConsTax = 0;
                    this.CalculateCost(row.ShipmentCnt, row.SalesUnitCost, row.TaxationDivCd, taxRate, stockMoneyFrcProcCd, taxFracProcCode, out costTaxInc, out costTaxExc, out costConsTax);
                    row.Cost = ( row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? costTaxInc : costTaxExc;
                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    int stockMoneyFrcProcCd = ( row.SupplierCd_Prime == 0 ) ? 0 : this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd_Prime, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);
                    int taxFracProcCode = ( row.SupplierCd_Prime == 0 ) ? 0 : this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd_Prime, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);

                    long costTaxInc = 0;
                    long costTaxExc = 0;
                    long costConsTax = 0;
                    this.CalculateCost(row.ShipmentCnt_Prime, row.SalesUnitCost_Prime, row.TaxationDivCd_Prime, taxRate, stockMoneyFrcProcCd, taxFracProcCode, out costTaxInc, out costTaxExc, out costConsTax);
                    row.Cost_Prime = ( row.TaxationDivCd_Prime == (int)CalculateTax.TaxationCode.TaxInc ) ? costTaxInc : costTaxExc;
                }
            }
        }

        /// <summary>
        /// 原価計算処理
        /// </summary>
        /// <param name="row">優良情報行</param>
        private void CalculateCost( EstimateInputDataSet.PrimeInfoRow row )
        {
            if (row != null)
            {
                if (_supplierAcs == null) _supplierAcs = new SupplierAcs();
            
                double taxRate = this._salesSlip.ConsTaxRate;
                int stockMoneyFrcProcCd = ( row.SupplierCd == 0 ) ? 0 : this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);
                int taxFracProcCode = ( row.SupplierCd == 0 ) ? 0 : this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);

                long costTaxInc = 0;
                long costTaxExc = 0;
                long costConsTax = 0;
                this.CalculateCost(row.ShipmentCnt, row.SalesUnitCost, row.TaxationDivCd, taxRate, stockMoneyFrcProcCd, taxFracProcCode, out costTaxInc, out costTaxExc, out costConsTax);
                row.Cost = ( row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? costTaxInc : costTaxExc;
            }
        }

        /// <summary>
        /// 売上金額を計算します。
        /// </summary>
        /// <param name="shipmentCnt">数量</param>
        /// <param name="salesUnPrcTaxExcFl">売単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="salesMoneyFrcProcCd">売上金額端数処理コード</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード</param>
        /// <param name="salesMoneyTaxInc">売上金額（税込み）</param>
        /// <param name="salesMoneyTaxExc">売上金額（税抜き）</param>
        /// <param name="salesPriceConsTax">売上金額消費税額</param>
        /// <returns>true:算定完了 false:算定失敗</returns>
        /// <remarks>
        /// <br>Call：商品検索／定価／売単価／売価率／原単価／原価率／売上金額 変更時</br>
        /// </remarks>
        private bool CalculateSalesMoney( double shipmentCnt, double salesUnPrcTaxExcFl, int taxationCode, double taxRate, int salesMoneyFrcProcCd, int salesCnsTaxFrcProcCd,
            out long salesMoneyTaxInc, out long salesMoneyTaxExc,out long salesPriceConsTax )
        {
            salesMoneyTaxInc = 0;
            salesMoneyTaxExc = 0;
            salesPriceConsTax = 0;

            double unitPriceExc = 0;    // 単価（税抜き）
            double unitPriceInc = 0;	// 単価（税込み）
            double unitPriceTax = 0;	// 単価（消費税）
            long priceExc = 0;			// 価格（税抜き）
            long priceInc = 0;			// 価格（税込み）
            long priceTax = 0;			// 価格（消費税）

            // 出荷数が0または売上単価が0の場合はすべて0で終了
            if (( shipmentCnt == 0 ) || ( salesUnPrcTaxExcFl == 0 )) return true;

            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._estimateInputInitDataAcs.GetSalesFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            switch ((CalculateTax.TaxationCode)taxationCode)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // 外税
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// 単価（税抜き）
                    priceExc = 0;					    // 価格（税抜き）

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                    salesMoneyTaxInc = priceInc;		// 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		// 売上金額（税抜き）		
                    salesPriceConsTax = priceTax;       // 売上消費税金額
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // 内税
                    //---------------------------------
                    unitPriceInc = salesUnPrcTaxExcFl;	// 単価（税込み）
                    priceInc = 0;					    // 価格（税込み）

                    this._salesPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, salesMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                    salesMoneyTaxInc = priceInc;		// 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		// 売上金額（税抜き）
                    salesPriceConsTax = priceTax;       // 売上消費税金額
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // 非課税
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// 単価（税抜き）
                    priceExc = 0;					    // 価格（税抜き）

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                    salesMoneyTaxInc = priceExc;		// 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		// 売上金額（税込み）
                    salesPriceConsTax = priceTax;       // 売上消費税金額
                    break;
            }
            return true;
        }

        /// <summary>
        /// 見積明細行の売上金額を計算します。
        /// </summary>
        /// <param name="row">見積明細行</param>
        private void CalculateSalesMoney( EstimateInputDataSet.EstimateDetailRow row )
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            long salesMoneyTaxInc;                              // 売上金額(税込み)
            long salesMoneyTaxExc;                              // 売上金額(税抜き)
            long salesPriceConsTax;                             // 売上消費税金額
            double taxRate = this._salesSlip.ConsTaxRate;       // 税率
            int taxationCode = 0;                               // 課税区分
            double salesUnPrc = 0;                              // 売上単価(税抜)

            // 売上金額端数処理コード(得意先マスタより取得)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._estimateInputInitDataAcs.GetSalesFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            #region ○純正部品の金額

            if (( !string.IsNullOrEmpty(row.GoodsNo) ) || ( !string.IsNullOrEmpty(row.GoodsName) ))
            {

                // 課税区分
                taxationCode = row.TaxationDivCd;
                salesUnPrc = 0;// 売上単価(税抜)

                // 転嫁方式：非課税は税抜き単価基準に計算
                if (this._salesSlip.ConsTaxLayMethod == 9)
                {
                    // 外税/非課税
                    salesUnPrc = row.SalesUnPrcTaxExcFl;
                }
                // 内税、総額表示は内税基準で計算
                else if (( row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) || ( this._salesSlip.TotalAmountDispWayCd == 1 ))
                {
                    // 内税
                    salesUnPrc = row.SalesUnPrcTaxIncFl;
                }
                // 外税/非課税
                else
                {
                    salesUnPrc = row.SalesUnPrcTaxExcFl;
                }

                // 転嫁方式：非課税は非課税として計算
                if (this._salesSlip.ConsTaxLayMethod == 9)
                {
                    taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                }
                // 総額表示時は内税で計算する
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {
                    // 総額表示する
                    if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                    }
                }

                if (this.CalculateSalesMoney(
                    row.ShipmentCnt,
                    salesUnPrc,
                    taxationCode,
                    taxRate,
                    salesMoneyFrcProcCode,
                    salesCnsTaxFrcProcCd,
                    out salesMoneyTaxInc,
                    out salesMoneyTaxExc,
                    out salesPriceConsTax))
                {
                    row.SalesMoneyTaxExc = salesMoneyTaxExc;        // 外税
                    row.SalesMoneyTaxInc = salesMoneyTaxInc;        // 内税
                    row.SalesPriceConsTax = salesPriceConsTax;      // 消費税
                }
            }
            #endregion

            #region ○優良部品の金額

            if (( !string.IsNullOrEmpty(row.GoodsNo_Prime) ) || ( !string.IsNullOrEmpty(row.GoodsName_Prime) ))
            {

                taxationCode = 0;        // 課税区分
                salesMoneyTaxInc = 0;    // 売上金額(税込み)
                salesMoneyTaxExc = 0;    // 売上金額(税抜き)
                salesPriceConsTax = 0;   // 売上消費税金額
                salesUnPrc = 0;          // 売上単価(税抜)

                // 課税区分
                taxationCode = row.TaxationDivCd_Prime;

                // 転嫁方式：非課税は税抜き単価基準に計算
                if (this._salesSlip.ConsTaxLayMethod == 9)
                {
                    salesUnPrc = row.SalesUnPrcTaxExcFl_Prime;
                }
                // 内税、総額表示は内税基準で計算
                else if (( row.TaxationDivCd_Prime == (int)CalculateTax.TaxationCode.TaxInc ) || ( this._salesSlip.TotalAmountDispWayCd == 1 ))
                {
                    // 内税
                    salesUnPrc = row.SalesUnPrcTaxIncFl_Prime;
                }
                // 外税/非課税
                else
                {
                    salesUnPrc = row.SalesUnPrcTaxExcFl_Prime;
                }

                // 転嫁方式：非課税は非課税として計算
                if (this._salesSlip.ConsTaxLayMethod == 9)
                {
                    taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                }
                // 総額表示時は内税で計算する
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {
                    // 総額表示する
                    if (row.TaxationDivCd_Prime == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                    }
                }

                if (this.CalculateSalesMoney(
                    row.ShipmentCnt_Prime,
                    salesUnPrc,
                    taxationCode,
                    taxRate,
                    salesMoneyFrcProcCode,
                    salesCnsTaxFrcProcCd,
                    out salesMoneyTaxInc,
                    out salesMoneyTaxExc,
                    out salesPriceConsTax))
                {
                    row.SalesMoneyTaxExc_Prime = salesMoneyTaxExc;        // 外税
                    row.SalesMoneyTaxInc_Prime = salesMoneyTaxInc;        // 内税
                    row.SalesPriceConsTax_Prime = salesPriceConsTax;      // 消費税
                }
            }
            #endregion
        }

		#region 在庫検索

        /// <summary>
        /// 検索用倉庫コード配列を取得します。
        /// </summary>
        /// <returns>倉庫コード配列</returns>
        private string[] GetSearchWarehouseArray()
        {
            List<string> warehouseList = new List<string>();

            SecInfoSet secInfoSet = this._estimateInputInitDataAcs.GetSecInfo(this._salesSlip.SectionCode);

            // --- ADD 2013/12/16 Y.Wakita ---------->>>>>
            if (secInfoSet != null)
            {
                // --- ADD 2013/12/16 Y.Wakita ----------<<<<<

            if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd1.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd1.Trim());
            if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd2.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd2.Trim());
            if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd3.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd3.Trim());

                // --- ADD 2013/12/16 Y.Wakita ---------->>>>>
            }
            // --- ADD 2013/12/16 Y.Wakita ----------<<<<<
            
            return warehouseList.ToArray();
        }

        /// <summary>
        /// 明細情報リストより在庫マスタを検索し、在庫リストを取得します。
        /// </summary>
		/// <param name="salesDetailList">明細情報リスト</param>
        public List<Stock> SearchStock( List<SalesDetail> salesDetailList )
        {
            if (( salesDetailList == null ) || ( salesDetailList.Count == 0 )) return new List<Stock>(); 

			string[] goodsNos = new string[salesDetailList.Count];
			int[] goodsMakerCds = new int[salesDetailList.Count];
			string[] warehouseCodes = new string[salesDetailList.Count];


			// パラメータ設定
			for (int cnt = 0; cnt < salesDetailList.Count; cnt++)
            {
				goodsNos[cnt] = salesDetailList[cnt].GoodsNo;
				goodsMakerCds[cnt] = salesDetailList[cnt].GoodsMakerCd;
				warehouseCodes[cnt] = salesDetailList[cnt].WarehouseCode;
            }
			
            StockSearchPara stockSearchPara = new StockSearchPara();
            stockSearchPara.EnterpriseCode = this._enterpriseCode;
			//stockSearchPara.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            stockSearchPara.GoodsNos = goodsNos;
            stockSearchPara.GoodsMakerCds = goodsMakerCds;
            stockSearchPara.WarehouseCodes = warehouseCodes;

			return SearchStock(stockSearchPara);
		}

        /// <summary>
		/// 倉庫コード、商品コード、メーカーコードより在庫マスタを検索し、在庫リストを取得します。
		/// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="targetData">対象データ</param>
        public List<Stock> SearchStock( int salesRowNo, TargetData targetData )
		{
            // 2009.06.18 >>>
            //List<Stock> retStockList = new List<Stock>();
            //EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            //if (row != null)
            //{


            //    if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            //    {
            //        if (!string.IsNullOrEmpty(row.WarehouseCode))
            //        {
            //            StockSearchPara stockSearchPara = new StockSearchPara();
            //            stockSearchPara.EnterpriseCode = this._enterpriseCode;
            //            stockSearchPara.GoodsNo = row.GoodsNo;
            //            stockSearchPara.GoodsMakerCd = row.GoodsMakerCd;
            //            stockSearchPara.WarehouseCode = row.WarehouseCode;

            //            List<Stock> purePartsStockList = SearchStock(stockSearchPara);
            //            if (purePartsStockList != null)
            //            {
            //                retStockList.AddRange(purePartsStockList);
            //            }
            //        }
            //    }

            //    if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            //    {
            //        if (!string.IsNullOrEmpty(row.WarehouseCode_Prime))
            //        {
            //            StockSearchPara stockSearchPara = new StockSearchPara();
            //            stockSearchPara.EnterpriseCode = this._enterpriseCode;
            //            stockSearchPara.GoodsNo = row.GoodsNo_Prime;
            //            stockSearchPara.GoodsMakerCd = row.GoodsMakerCd_Prime;
            //            stockSearchPara.WarehouseCode = row.WarehouseCode_Prime;

            //            List<Stock> primePartsStockList = SearchStock(stockSearchPara);
            //            if (primePartsStockList != null)
            //            {
            //                retStockList.AddRange(primePartsStockList);
            //            }
            //        }
            //    }
            //}
            //return retStockList;

            return this.SearchStock(salesRowNo, targetData, true);
            // 2009.06.18 <<<
        }

        // 2009.06.18 Add >>>
        /// <summary>
        /// 倉庫コード、商品コード、メーカーコードより在庫マスタを検索し、在庫リストを取得します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="useWarehouse">True:倉庫有りの在庫検索</param>
        public List<Stock> SearchStock(int salesRowNo, TargetData targetData, bool useWarehouse)
        {
            List<Stock> retStockList = new List<Stock>();
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {


                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    if (!string.IsNullOrEmpty(row.WarehouseCode))
                    {
                        StockSearchPara stockSearchPara = new StockSearchPara();
                        stockSearchPara.EnterpriseCode = this._enterpriseCode;
                        stockSearchPara.GoodsNo = row.GoodsNo;
                        stockSearchPara.GoodsMakerCd = row.GoodsMakerCd;
                        //stockSearchPara.WarehouseCode = row.WarehouseCode;

                        List<Stock> purePartsStockList = SearchStock(stockSearchPara);
                        if (purePartsStockList != null)
                        {
                            retStockList.AddRange(purePartsStockList);
                        }
                    }
                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    if (!string.IsNullOrEmpty(row.WarehouseCode_Prime))
                    {
                        StockSearchPara stockSearchPara = new StockSearchPara();
                        stockSearchPara.EnterpriseCode = this._enterpriseCode;
                        stockSearchPara.GoodsNo = row.GoodsNo_Prime;
                        stockSearchPara.GoodsMakerCd = row.GoodsMakerCd_Prime;
                        //stockSearchPara.WarehouseCode = row.WarehouseCode_Prime;

                        List<Stock> primePartsStockList = SearchStock(stockSearchPara);
                        if (primePartsStockList != null)
                        {
                            retStockList.AddRange(primePartsStockList);
                        }
                    }
                }
            }
            return retStockList;
        }
        // 2009.06.18 Add <<<

        /// <summary>
        /// 倉庫コード、商品コード、メーカーコードより在庫マスタを検索し、在庫リストを取得します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="targetData">対象データ</param>
        /// <param name="warehouseCode">倉庫コード</param>
        public List<Stock> SearchStock( int salesRowNo, TargetData targetData, string warehouseCode )
        {
            List<Stock> retStockList = new List<Stock>();
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
                {
                    if (!string.IsNullOrEmpty(warehouseCode))
                    {
                        StockSearchPara stockSearchPara = new StockSearchPara();
                        stockSearchPara.EnterpriseCode = this._enterpriseCode;
                        stockSearchPara.GoodsNo = row.GoodsNo;
                        stockSearchPara.GoodsMakerCd = row.GoodsMakerCd;
                        stockSearchPara.WarehouseCode = warehouseCode;

                        List<Stock> purePartsStockList = SearchStock(stockSearchPara);
                        if (purePartsStockList != null)
                        {
                            retStockList.AddRange(purePartsStockList);
                        }
                    }
                }

                if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
                {
                    if (!string.IsNullOrEmpty(warehouseCode))
                    {
                        StockSearchPara stockSearchPara = new StockSearchPara();
                        stockSearchPara.EnterpriseCode = this._enterpriseCode;
                        stockSearchPara.GoodsNo = row.GoodsNo_Prime;
                        stockSearchPara.GoodsMakerCd = row.GoodsMakerCd_Prime;
                        stockSearchPara.WarehouseCode = warehouseCode;

                        List<Stock> primePartsStockList = SearchStock(stockSearchPara);
                        if (primePartsStockList != null)
                        {
                            retStockList.AddRange(primePartsStockList);
                        }
                    }
                }
            }
            return retStockList;
        }

		/// <summary>
		/// 在庫検索パラメータより在庫検索を行い、在庫リストを取得します。
		/// </summary>
		/// <param name="stockSearchPara">在庫検索パラメータ</param>
		/// <returns>在庫リスト</returns>
        private List<Stock> SearchStock( StockSearchPara stockSearchPara )
		{
            List<Stock> retStockList=new List<Stock>();

			string msg;
            if (_searchStockAcs == null) _searchStockAcs = new SearchStockAcs();
			int status = this._searchStockAcs.Search(stockSearchPara, out retStockList, out msg);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                retStockList = new List<Stock>();
			}

			return retStockList;
		}
		#endregion
		
        /// <summary>
        /// 優良情報設定
        /// </summary>
        /// <param name="salesRowNo"></param>
        public void PrimeInfoSetting( int salesRowNo )
        {
            EstimateInputDataSet.EstimateDetailRow estimateDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (estimateDetailRow != null)
            {

                Guid primeRelationGuid = this.GetPrimeInfoRelationGuid(estimateDetailRow);

                this._primeInfoDisplayView.RowFilter = string.Format("{0}='{1}'", this._primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeRelationGuid);

                if (this.PimeInfoFilterChanged != null)
                {
                    this.PimeInfoFilterChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// BLコードガイド起動処理
        /// </summary>
        /// <param name="bLGoodsCdUMntList"></param>
        /// <param name="salesRowNo"></param>
        /// <returns>ConstantManagement.MethodResult(-3:車輌無し)</returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
        //public int ExecuteBLGoodsGuide(IWin32Window owner, out List<BLGoodsCdUMnt> bLGoodsCdUMntList, int salesRowNo )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        public int ExecuteBLGoodsGuide( IWin32Window owner, out List<BLGoodsCdUMnt> bLGoodsCdUMntList, int salesRowNo, string sectionCode, int customerCode, int blGuideMode )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
        {
            bLGoodsCdUMntList = new List<BLGoodsCdUMnt>();

            PMKEN01010E carInfo = new PMKEN01010E();
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (( row != null ) && ( row.CarRelationGuid != Guid.Empty ))
                carInfo = this.GetCarInfoFromDic(row.CarRelationGuid);
            else
                carInfo = this.GetCarInfoFromDic(this._beforeCarRelationGuid);

            if (carInfo == null)
            {
                return -3;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
            //return this._estimateInputInitDataAcs.ExecuteBLGoodsCd(owner, out bLGoodsCdUMntList, carInfo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            return this._estimateInputInitDataAcs.ExecuteBLGoodsCd( owner, out bLGoodsCdUMntList, carInfo, sectionCode, customerCode, this.GetBLGuideMode( blGuideMode ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

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

        # endregion

        // ===================================================================================== //
        // スタティックメソッド
        // ===================================================================================== //
        # region ■Static Method
        
		#region ●締日計算関連
		/// <summary>
		/// 計上日計算処理
		/// </summary>
		/// <param name="targetDate">対象日</param>
		/// <param name="totalDay">締日</param>
		/// <param name="nTimeCalcStDate">来月勘定開始日</param>
		/// <param name="addUpADate">計上日(算出結果)</param>
		/// <param name="delayPaymentDiv">来勘区分(算出	結果)</param>
		public static void CalcAddUpDate( DateTime targetDate, int totalDay, int nTimeCalcStDate, out DateTime addUpADate, out int delayPaymentDiv )
		{
			// 基本的に対象日が計上日で当月請求
			addUpADate = targetDate;
			delayPaymentDiv = 0;

			// 締日、来月勘定開始日が設定されていない場合はそのまま終了
			if (( totalDay == 0 ) || ( nTimeCalcStDate == 0 ) || ( targetDate == DateTime.MinValue ))
			{
				return;
			}

			DateTime thisTimeAddUpDate = EstimateInputAcs.GetNextTotalDate(0, targetDate, totalDay);
			// 来月請求の場合は、今回請求日の翌日が計上日
			DateTime nextTimeAddUpDate = thisTimeAddUpDate.AddDays(1);


			// 来月勘定開始日 ≦ 締日
			if (nTimeCalcStDate <= totalDay)
			{
				// 対象日の日付が来月勘定開始日～締日の場合に来月勘定
				if (( nTimeCalcStDate <= targetDate.Day ) && ( targetDate.Day <= totalDay ))
				{
					addUpADate = nextTimeAddUpDate;
					delayPaymentDiv = 1;
				}
			}
			// 来月勘定開始日 ＞ 締日
			else
			{
				// 対象日の日付が1日～締日、来月勘定開始日～末日の場合に来月勘定
				if (( 1 <= targetDate.Day ) && ( targetDate.Day <= totalDay ) ||
					( nTimeCalcStDate <= targetDate.Day ))
				{
					addUpADate = nextTimeAddUpDate;
					delayPaymentDiv = 1;
				}
			}
		}

		/// <summary>
		/// 指定日付の次回以降の締日を算出します。
		/// </summary>
		/// <param name="loopCnt">0:当月,1:翌月,2:翌々月...</param>
		/// <param name="targetdate">対象日</param>
		/// <param name="totalDay">締日</param>
		/// <returns></returns>
		private static DateTime GetNextTotalDate( int loopCnt, DateTime targetdate, int totalDay )
		{

			DateTime retDate = targetdate;

			// 対象月の実際の締日を取得
			int totalDayR = GetRealTotalDay(retDate, totalDay);

			// 対象日が実際の締日より大きい場合は1ヵ月加算
			if (targetdate.Day > totalDayR)
			{
				retDate = retDate.AddMonths(1);

				totalDayR = GetRealTotalDay(retDate, totalDay);
			}
			retDate = new DateTime(retDate.Year, retDate.Month, totalDayR);

			return ( loopCnt == 0 ) ? retDate : GetNextTotalDate(loopCnt - 1, retDate.AddDays(1), totalDay);
		}

		/// <summary>
		/// 対象年月日、締日から、実際に締対象となる日付を算出します。
		/// </summary>
		/// <param name="targetDate">対象年月日</param>
		/// <param name="totalDay">設定上の締日</param>
		/// <returns>対象月の実際の締日</returns>
		private static int GetRealTotalDay( DateTime targetDate, int totalDay )
		{
			int retValue = totalDay;
			// 対象月の末日取得
			int lastDayofMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);

			if (lastDayofMonth < totalDay) retValue = lastDayofMonth;

			return retValue;
		}

		/// <summary>
		/// IOWriter制御オプションワーク取得処理
		/// </summary>
		/// <returns></returns>
		private IOWriteCtrlOptWork GetIOWriteCtrlOptWork()
		{
			IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();

            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;          // 制御起点(0:売上 1:仕入 2:仕入売上同時計上)

			return iOWriteCtrlOptWork;
		}

		#endregion

		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region ■Private Methods

        /// <summary>
        /// 優良情報連結GUIDを取得します。
        /// </summary>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">行番号</param>
        /// <returns>優良情報連結GUID</returns>
        private Guid GetPrimeInfoRelationGuid( string salesSlipNum, int salesRowNo )
        {
            return this.GetPrimeInfoRelationGuid(this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, salesRowNo));
        }

        /// <summary>
        /// 見積明細行の優良情報連結GUIDを取得します。
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        /// <br>Update Note : 鄧潘ハン 2011/11/24</br>
        /// <br>            : redmine#8034,外車データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正</br>
        private Guid GetPrimeInfoRelationGuid( EstimateInputDataSet.EstimateDetailRow row )
        {
            if (row == null)
                return Guid.Empty;
            this._goodsEstimateNo = row.GoodsNo;// ADD 鄧潘ハン 2011/11/24 Redmine#8034
            return row.PrimeInfoRelationGuid;
        }

        /// <summary>
        /// 対象価格から、税抜金額、税込金額、表示金額を計算します
        /// </summary>
        /// <param name="priceInputType">価格入力モード</param>
        /// <param name="targetPrice">対象価格</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="taxRate">税率</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <param name="priceTaxExc">税抜金額</param>
        /// <param name="priceTaxInc">税込金額</param>
        /// <param name="priceDisplay">表示金額</param>
        private void CalclateCostPrice(PriceInputType priceInputType, double targetPrice, int taxationCode, int totalAmountDispWayCd, double taxRate, int stockCnsTaxFrcProcCd, out  double priceTaxExc, out  double priceTaxInc, out  double priceDisplay)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            priceDisplay = 0;

            if (targetPrice == 0) return;

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._estimateInputInitDataAcs.GetStockFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // 入力タイプ
            switch (priceInputType)
            {
                // 税抜き価格
                case PriceInputType.PriceTaxExc:
                    {
                        if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
                        {
                            priceTaxExc = targetPrice;
                            priceTaxInc = targetPrice;
                        }
                        else
                        {
                            priceTaxExc = targetPrice;
                            priceTaxInc = targetPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                        }

                        break;
                    }
                // 税込み価格
                case PriceInputType.PriceTaxInc:
                    {
                        if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
                        {
                            priceTaxExc = targetPrice;
                            priceTaxInc = targetPrice;
                        }
                        else
                        {
                            priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                            priceTaxInc = targetPrice;
                        }

                        break;
                    }
                // 表示価格
                case PriceInputType.PriceDisplay:
                    {
                        // 総額表示しない
                        if (totalAmountDispWayCd == 0)
                        {
                            // 課税区分が「課税（内税）」の場合
                            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                                priceTaxInc = targetPrice;
                            }
                            // 課税区分が「課税」の場合
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                priceTaxExc = targetPrice;
                                priceTaxInc = targetPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                            }
                            // 課税区分が「非課税」の場合
                            else
                            {
                                priceTaxExc = targetPrice;
                                priceTaxInc = targetPrice;
                            }
                        }
                        // 総額表示する
                        else
                        {
                            // 課税区分が「課税（内税）」の場合
                            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                                priceTaxInc = targetPrice;
                            }
                            // 課税区分が「課税」の場合
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                                priceTaxInc = targetPrice;
                            }
                            // 課税区分が「非課税」の場合
                            else
                            {
                                priceTaxExc = targetPrice;
                                priceTaxInc = targetPrice;
                            }
                        }
                        break;
                    }
            }
            // 総額表示か内税は税込み金額を表示する
            if (( totalAmountDispWayCd == 1 ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
            {
                priceDisplay = priceTaxInc;
            }
            else
            {
                priceDisplay = priceTaxExc;
            }
        }

        /// <summary>
        /// 対象価格から、税抜金額、税込金額、表示金額を計算します
        /// </summary>
        /// <param name="priceInputType">価格入力モード</param>
        /// <param name="targetPrice">対象価格</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <param name="taxRate">税率</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード</param>
        /// <param name="priceTaxExc">税抜金額</param>
        /// <param name="priceTaxInc">税込金額</param>
        /// <param name="priceDisplay">表示金額</param>
        private void CalclatePrice(PriceInputType priceInputType, double targetPrice, int taxationCode, int totalAmountDispWayCd, int consTaxLayMethod, double taxRate, int salesCnsTaxFrcProcCd, out  double priceTaxExc, out  double priceTaxInc, out  double priceDisplay)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            priceDisplay = 0;

            if (targetPrice == 0) return;

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._estimateInputInitDataAcs.GetSalesFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // 入力タイプ
            switch (priceInputType)
            {
                // 税抜き価格
                case PriceInputType.PriceTaxExc:
                    {
                        // 非課税品、転嫁方式：非課税
                        if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ) || ( consTaxLayMethod == 9 ))
                        {
                            priceTaxExc = targetPrice;
                            priceTaxInc = targetPrice;
                        }
                        else
                        {
                            priceTaxExc = targetPrice;
                            priceTaxInc = targetPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                        }

                        break;
                    }
                // 税込み価格
                case PriceInputType.PriceTaxInc:
                    {
                        // 非課税品、転嫁方式：非課税
                        if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ) || ( consTaxLayMethod == 9 ))
                        {
                            priceTaxExc = targetPrice;
                            priceTaxInc = targetPrice;
                        }
                        else
                        {
                            priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                            priceTaxInc = targetPrice;
                        }

                        break;
                    }
                // 表示価格
                case PriceInputType.PriceDisplay:
                    {
                        // 総額表示しない
                        if (totalAmountDispWayCd == 0)
                        {
                            // 課税区分「非課税」、転嫁方式：非課税
                            if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ) || ( consTaxLayMethod == 9 ))
                            {
                                priceTaxExc = targetPrice;
                                priceTaxInc = targetPrice;
                            }
                            // 課税区分が「課税（内税）」の場合
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                                priceTaxInc = targetPrice;
                            }
                            // 課税区分が「課税」の場合
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                priceTaxExc = targetPrice;
                                priceTaxInc = targetPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                            }
                        }
                        // 総額表示する
                        else
                        {
                            // 課税区分「非課税」、転嫁方式：非課税
                            if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ) || ( consTaxLayMethod == 9 ))
                            {
                                priceTaxExc = targetPrice;
                                priceTaxInc = targetPrice;
                            }
                            // 課税区分が「課税（内税）」の場合
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                                priceTaxInc = targetPrice;
                            }
                            // 課税区分が「課税」の場合
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                                priceTaxInc = targetPrice;
                            }
                        }
                        break;
                    }
            }
            // 総額表示か内税は税込み金額を表示する
            if (( consTaxLayMethod != 9 ) && ( ( totalAmountDispWayCd == 1 ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ))
            {
                priceDisplay = priceTaxInc;
            }
            else
            {
                priceDisplay = priceTaxExc;
            }
        }

        /// <summary>
        /// 売価率を使用して定価から売上単価を算出します。
        /// </summary>
        /// <param name="listPriceTaxExcFl">定価(税抜)</param>
        /// <param name="listPriceTaxIncFl">定価(税込)</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="salesRate">売価率</param>
        /// <param name="unitPriceTaxExc">売上単価(税抜)</param>
        /// <param name="unitPriceTaxInc">売上単価(税込)</param>
        /// <param name="unitPriceDisplay">売上単価(表示)</param>
        /// <param name="fracProcUnitSalUnPrc">売上単価端数処理単位</param>
        /// <param name="fracProcSalUnPrc">売上単価端数処理区分</param>
        private void CalclateSalesUnitPriceByRate(double listPriceTaxExcFl, double listPriceTaxIncFl, int taxationCode, double salesRate, out double unitPriceTaxExc, out double unitPriceTaxInc, out double unitPriceDisplay, ref double fracProcUnitSalUnPrc, ref int fracProcSalUnPrc)
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);    // 売上単価端数処理コード
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);  // 売上消費税端数処理コード

            double stdPrice = 0;
            int totalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;

            // 転嫁方式：非課税
            if (this._salesSlip.ConsTaxLayMethod == 9)
            {
                // 基準とする定価は税抜き
                stdPrice = listPriceTaxExcFl;
                // 総額表示「しない」扱い
                totalAmountDispWayCd = 0;
                // 課税区分：非課税
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            else
            {
                stdPrice = ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? listPriceTaxIncFl : listPriceTaxExcFl;
            }

            this.CalclateSalesUnitPriceByRate(
                stdPrice,
                salesRate,
                taxationCode,
                totalAmountDispWayCd,
                this._salesSlip.TtlAmntDispRateApy,
                this._salesSlip.ConsTaxLayMethod,
                this._salesSlip.ConsTaxRate,
                salesUnPrcFrcProcCd,
                salesCnsTaxFrcProcCd,
                out unitPriceTaxExc,
                out unitPriceTaxInc,
                ref fracProcUnitSalUnPrc,
                ref fracProcSalUnPrc);

            // 転嫁方式：非課税
            if (this._salesSlip.ConsTaxLayMethod == 9)
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
            // 「総額表示する」か、「内税商品」の場合は税込み単価を表示単価に設定
            else if (( this._salesSlip.TotalAmountDispWayCd == 1 ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
            {
                unitPriceDisplay = unitPriceTaxInc;
            }
            else
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
        }

        /// <summary>
        /// 売価率を使用して定価から仕入単価を算出します。（オーバーロード）
        /// </summary>
        /// <param name="listPrice">定価</param>
        /// <param name="salesRate">売価率</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="ttlAmntDspRateDivCd">総額表示掛率適用区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <param name="taxRate">税率</param>
        /// <param name="salesUnPrcFrcProcCd">単価端数処理コード</param>
        /// <param name="salesCnsTaxFrcProcCd">消費税端数処理コード</param>
        /// <param name="unitPriceTaxExc">税抜単価</param>
        /// <param name="unitPriceTaxInc">税込単価</param>
        /// <param name="fracProcUnitStcUnPrc">端数処理単位</param>
        /// <param name="fracProcStckUnPrc">端数処理区分</param>
        private void CalclateSalesUnitPriceByRate(double listPrice, double salesRate, int taxationCode, int totalAmountDispWayCd, int ttlAmntDspRateDivCd, int consTaxLayMethod, double taxRate, int salesUnPrcFrcProcCd, int salesCnsTaxFrcProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc, ref double fracProcUnitStcUnPrc, ref int fracProcStckUnPrc)
        {
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._estimateInputInitDataAcs.GetSalesFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._unitPriceCalculation.CalculateUnitPriceByRate(
                UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
                UnitPriceCalculation.UnitPrcCalcDiv.RateVal,
                totalAmountDispWayCd,
                ttlAmntDspRateDivCd,
                salesUnPrcFrcProcCd,
                taxationCode,
                listPrice,
                taxRate,
                taxFracProcUnit,
                taxFracProcCd,
                salesRate,
                ref fracProcUnitStcUnPrc,
                ref fracProcStckUnPrc,
                out unitPriceTaxExc,
                out unitPriceTaxInc);
        }


        /// <summary>
        /// 明細の売上金額を計算します。
        /// </summary>
        public void CalsclateDetialSalesPrice()
        {
            this.CalclateAllSalesPrice();
        }

        /// <summary>
        /// 全明細の売上単価を計算します。
        /// </summary>
        /// <br>UpdateNote : 2011/06/07 鄧潘ハン</br>
        /// <br>          キャンペーン売価適用処理の追加。</br>
        /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22773 キャンペーンにヒットして売価が算出された場合の対応</br>
        /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22773 掛率なしで、キャンペーン値引率≠0の場合の対応</br>
        /// <br>UpdateNote : 2011/08/12 譚洪 Redmine#23555 キャンペーンの売価「売価率、値引率、売価額」が設定されている場合は、掛率マスタの売価の設定をクリアするように仕様変更の対応</br>
        private void CalclateAllSalesPrice()
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            CampaignObjGoodsStAcs campaignObjGoodsStAcs = null;　// ADD 2011/06/07
            

            // 売上単価端数処理コード(得意先マスタより取得)
            int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            
            // 売上消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);

            // 掛率使用区分によって処理分岐
            switch (this._salesSlip.RateUseCode)
            {
                #region 売価＝定価
                case 0:
                    {
                        foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
                        {
                            if (!this.ExistDetailInput(row)) continue;

                            // 売上単価情報をクリア
                            this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, TargetData.All, true);

                            // 純正部品
                            if (( !string.IsNullOrEmpty(row.GoodsNo) ) || ( !string.IsNullOrEmpty(row.GoodsName) ))
                            {
                                row.SalesUnPrcTaxIncFl = row.ListPriceTaxIncFl;                 // 売単価(税抜)←定価(税抜)
                                row.SalesUnPrcTaxExcFl = row.ListPriceTaxExcFl;                 // 売単価(税込)←定価(税込)
                                row.BfSalesUnitPrice = row.SalesUnPrcTaxExcFl;                  // 変更前売価
                            }

                            // 優良部品
                            if (( !string.IsNullOrEmpty(row.GoodsNo_Prime) ) || 
                                ( !string.IsNullOrEmpty(row.GoodsName_Prime) ))
                            {
                                row.SalesUnPrcTaxIncFl_Prime = row.ListPriceTaxIncFl_Prime;     // 売単価(税抜)←定価(税抜)
                                row.SalesUnPrcTaxExcFl_Prime = row.ListPriceTaxExcFl_Prime;     // 売単価(税込)←定価(税込)
                                row.BfSalesUnitPrice_Prime = row.SalesUnPrcTaxExcFl_Prime;      // 変更前売価
                            }
                            this.CalculateSalesMoney(row);
                        }
                        break;
                    }
                #endregion

                #region 掛率指定
                case 1:
                    {
                        foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
                        {
                            if (!this.ExistDetailInput(row)) continue;

                            // 売上単価情報をクリア
                            this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, TargetData.All, true);

                            // 純正部品
                            if (( !string.IsNullOrEmpty(row.GoodsNo) ) || ( !string.IsNullOrEmpty(row.GoodsName) ))
                            {
                                double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                int fracProcSalUnPrc = 0;
                                double fracProcUnitSalUnPrc = 0;
                                this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl, row.ListPriceTaxIncFl, row.TaxationDivCd, this._salesSlip.SalesRate, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                row.SalesRate = this._salesSlip.SalesRate;              // 売価率
                                row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;            // 売単価(税抜)
                                row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;            // 売単価(税込)
                                row.BfSalesUnitPrice = salesUnPrcTaxExcFl;              // 変更前売価
                                row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                row.FracProcSalUnPrc = fracProcSalUnPrc;                // 端数処理（売上単価）
                            }

                            // 優良部品
                            if (( !string.IsNullOrEmpty(row.GoodsNo_Prime) ) ||
                                ( !string.IsNullOrEmpty(row.GoodsName_Prime) ))
                            {
                                double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                int fracProcSalUnPrc = 0;
                                double fracProcUnitSalUnPrc = 0;
                                this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl_Prime, row.ListPriceTaxIncFl_Prime, row.TaxationDivCd_Prime, this._salesSlip.SalesRate, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                row.SalesRate_Prime = this._salesSlip.SalesRate;        // 売価率
                                row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;      // 売単価(税抜)
                                row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;      // 売単価(税込)
                                row.BfSalesUnitPrice_Prime = salesUnPrcTaxExcFl;        // 変更前売価
                                row.FracProcUnitSalUnPrc_Prime = fracProcUnitSalUnPrc;  // 端数処理単位（売上単価）
                                row.FracProcSalUnPrc_Prime = fracProcSalUnPrc;          // 端数処理（売上単価）
                            }
                            this.CalculateSalesMoney(row);
                        }
                        break;
                    }
                #endregion

                #region 掛率設定
                case 2:
                    {
                        // ---ADD 2011/06/07---------------->>>>>
                        //CampaignObjGoodsSt campaignObjGoodsSt = new CampaignObjGoodsSt();  // DEL 2011/08/15
                        campaignObjGoodsSt = new CampaignObjGoodsSt();  // ADD 2011/08/15
                        campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
                        // ---ADD 2011/06/07----------------<<<<<

                        // 単価算出モジュールに従って、明細の全部品の金額を取得する

                        #region 単価算出モジュールのパラメータ、商品連結データを取得
                        foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
                        {
                            if (!this.ExistDetailInput(row)) continue;

                            // 純正部品情報
                            if (( !string.IsNullOrEmpty(row.GoodsNo) ) && ( row.GoodsMakerCd != 0 ))
                            {
                                // ------------ADD START wangf 2012/04/27 FOR Redmine#29640--------->>>>
                                // 得意先掛率グループコード再セット
                                row.CustRateGrpCode = GetCustRateGroupForReSetting(_salesSlip.CustomerCode, row.GoodsMakerCd);
                                // ------------ADD END wangf 2012/04/27 FOR Redmine#29640---------<<<<<
                                // 売上単価情報をクリア
                                this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, TargetData.PureParts, true);

                                #region ○純正部品の単価算出パラメータ生成

                                unitPriceCalcParamList.Add(this.CreateUnitPriceCalcParam(TargetData.PureParts, row));
                                goodsUnitDataList.Add(this.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd));

                                #endregion
                            }
                            // 優良部品情報
                            if (( !string.IsNullOrEmpty(row.GoodsNo_Prime) ) && ( row.GoodsMakerCd_Prime != 0 ))
                            {
                                // ------------ADD START wangf 2012/04/27 FOR Redmine#29640--------->>>>
                                // 得意先掛率グループコード再セット
                                row.CustRateGrpCode_Prime = GetCustRateGroupForReSetting(_salesSlip.CustomerCode, row.GoodsMakerCd_Prime);
                                // ------------ADD END wangf 2012/04/27 FOR Redmine#29640---------<<<<<
                                // 売上単価情報をクリア
                                this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, TargetData.PrimeParts, true);

                                #region ○優良部品の単価算出パラメータ生成

                                unitPriceCalcParamList.Add(this.CreateUnitPriceCalcParam(TargetData.PrimeParts, row));
                                goodsUnitDataList.Add(this.GetGoodsUnitDataFromCache(row.GoodsNo_Prime, row.GoodsMakerCd_Prime));

                                #endregion
                            }
                        }
                        #endregion

                        List<UnitPriceCalcRet> unitPriceCalcRetList;

                        this._unitPriceCalculation.CalculateSalesUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

                        foreach (EstimateInputDataSet.EstimateDetailRow row in this._estimateDetailDataTable)
                        {
                            if (!this.ExistDetailInput(row)) continue;

                            // 純正部品情報
                            if (( !string.IsNullOrEmpty(row.GoodsNo) ) && ( row.GoodsMakerCd != 0 ))
                            {
                                #region ○純正部品の単価算出結果の展開
                                // ---ADD 2011/06/07--------------->>>>>
                                campaignObjGoodsStAcs.GetRatePriceOfCampaignMng(out campaignObjGoodsSt, this._enterpriseCode, this._salesSlip.ResultsAddUpSecCd, this._salesSlip.CustomerCode, row.GoodsMakerCd, row.BLGroupCode, row.BLGoodsCode, row.SalesCode, row.GoodsNo, this._salesSlip.SalesDate);

                                bool isSetting = this.EstimateDetailRowPriceInfoSettingFromUnitPriceCalcRetList(TargetData.PureParts, row, unitPriceCalcRetList, true, true, false, false);

                                if (campaignObjGoodsSt == null)
                                {
                                // ---ADD 2011/06/07---------------<<<<<
                                   
                                    // 単価がセットされなかった場合
                                    if (!isSetting)
                                    {
                                        // 売上全体設定マスタの売価未設定時区分に従って設定
                                        switch (this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                                        {
                                            // ゼロ表示
                                            case 0:
                                                {
                                                    break;
                                                }
                                            // 定価を表示
                                            case 1:
                                                {
                                                    row.SalesUnPrcTaxIncFl = row.ListPriceTaxIncFl;
                                                    row.SalesUnPrcTaxExcFl = row.ListPriceTaxExcFl;
                                                    row.BfSalesUnitPrice = row.ListPriceTaxExcFl;
                                                    break;
                                                }
                                        }
                                    }
                                    // 単価算出区分が「掛率」で、税込み定価、税抜き定価と異なる場合は単価再計算
                                    if ((row.UnPrcCalcCdSalUnPrc == (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal) &&
                                        ((row.StdUnPrcSalUnPrc != row.ListPriceTaxExcFl) && (row.StdUnPrcSalUnPrc != row.ListPriceTaxIncFl)))
                                    {
                                        double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                        int fracProcSalUnPrc = 0;
                                        double fracProcUnitSalUnPrc = 0;
                                        this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl, row.ListPriceTaxIncFl, row.TaxationDivCd, row.SalesRate, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                        row.StdUnPrcSalUnPrc = row.ListPriceTaxExcFl;           // 基準単価
                                        row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;            // 売単価(税抜)
                                        row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;            // 売単価(税込)
                                        row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                        row.FracProcSalUnPrc = fracProcSalUnPrc;                // 端数処理（売上単価）
                                        row.SalesUnPrcChngCd = 1;
                                    }
                                // ---ADD 2011/06/07------------------>>>>>
                                }
                                else
                                {
                                    //キャンペーン対象商品設定が売価率設定の場合
                                    if (campaignObjGoodsSt.RateVal != 0)
                                    {
                                        double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                        int fracProcSalUnPrc = 0;
                                        double fracProcUnitSalUnPrc = 0;
                                        this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl, row.ListPriceTaxIncFl, row.TaxationDivCd, campaignObjGoodsSt.RateVal, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                        if (!isSetting)
                                        {
                                            // 売上全体設定マスタの売価未設定時区分に従って設定
                                            switch (this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                                            {
                                                // ゼロ表示
                                                case 0:
                                                    {
                                                        // ----- ADD 2011/07/07 ------- >>>>>>>>>
                                                        row.SalesRate = campaignObjGoodsSt.RateVal;             // 売価率
                                                        row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;            // 売単価(税込)
                                                        row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;            // 売単価(税抜)
                                                        row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                                        row.FracProcSalUnPrc = fracProcSalUnPrc;                // 端数処理（売上単価）
                                                        row.SalesUnPrcChngCd = 1;
                                                        // ----- ADD 2011/07/07 ------- <<<<<<<<<
                                                        break;
                                                    }
                                                // 定価を表示
                                                case 1:
                                                    {
                                                        row.BfSalesUnitPrice = row.ListPriceTaxExcFl;          // 変更前売価
                                                        row.SalesRate = campaignObjGoodsSt.RateVal;             // 売価率
                                                        row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;            // 売単価(税込)
                                                        row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;            // 売単価(税抜)
                                                        row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                                        row.FracProcSalUnPrc = fracProcSalUnPrc;                // 端数処理（売上単価）
                                                        row.SalesUnPrcChngCd = 1;
                                                        break;
                                                    }
                                            }
                                        }
                                        else
                                        {
                                            row.BfSalesUnitPrice = row.SalesUnPrcTaxExcFl;          // 変更前売価
                                            row.SalesRate = campaignObjGoodsSt.RateVal;             // 売価率
                                            row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;            // 売単価(税込)
                                            row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;            // 売単価(税抜)
                                            row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                            row.FracProcSalUnPrc = fracProcSalUnPrc;                // 端数処理（売上単価）
                                            row.SalesUnPrcChngCd = 1;
                                        }

                                    }
                                    //キャンペーン対象商品設定が売価額設定の場合
                                    if (campaignObjGoodsSt.PriceFl != 0)
                                    {
                                        //CalclateSalesUnitPriceByRateを呼び出して売上単価を算出する。
                                        double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                        int fracProcSalUnPrc = 0;
                                        double fracProcUnitSalUnPrc = 0;
                                        this.CalclateSalesUnitPriceByRate(campaignObjGoodsSt.PriceFl, campaignObjGoodsSt.PriceFl, row.TaxationDivCd, 100, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                        if (!isSetting)
                                        {
                                            // 売上全体設定マスタの売価未設定時区分に従って設定
                                            switch (this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                                            {
                                                // ゼロ表示
                                                case 0:
                                                    {
                                                        // ----- ADD 2011/07/07 ------- >>>>>>>>>
                                                        row.SalesUnPrcTaxExcFl = campaignObjGoodsSt.PriceFl;  
                                                        row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;           // 売単価(税込)←定価(税込)
                                                        row.SalesUnPrcChngCd = 1;
                                                        // ----- ADD 2011/07/07 ------- <<<<<<<<<
                                                        break;
                                                    }
                                                // 定価を表示
                                                case 1:
                                                    {
                                                        row.BfSalesUnitPrice = row.ListPriceTaxExcFl;          // 変更前売価
                                                        row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;           // 売単価(税込)←定価(税込)
                                                        row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;           // 売単価(税抜)←定価(税抜)
                                                        row.SalesUnPrcChngCd = 1;
                                                        break;
                                                    }
                                            }
                                        }
                                        else
                                        {
                                            row.BfSalesUnitPrice = row.SalesUnPrcTaxExcFl;          // 変更前売価
                                            row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;            // 売単価(税込)←定価(税込)
                                            row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;            // 売単価(税抜)←定価(税抜)
                                            row.SalesUnPrcChngCd = 1;
                                        }

                                      
                                    }
                                    //キャンペーン対象商品設定が値引率設定の場合
                                    if (campaignObjGoodsSt.DiscountRate != 0)
                                    {
                                        if (!isSetting)
                                        {
                                            // 売上全体設定マスタの売価未設定時区分に従って設定
                                            switch (this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                                            {
                                                // ゼロ表示
                                                case 0:
                                                    {
                                                        // ----- ADD 2011/07/07 ------- >>>>>>>>>
                                                        // ----- UPD 2011/07/13 ------- >>>>>>>>>
                                                        //double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                                        //int fracProcSalUnPrc = 0;
                                                        //double fracProcUnitSalUnPrc = 0;
                                                        //this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl, row.ListPriceTaxIncFl, row.TaxationDivCd, 100 - campaignObjGoodsSt.DiscountRate, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);
                                                        //row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;            // 売単価(税込)
                                                        //row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;            // 売単価(税抜)
                                                        //row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                                        //row.FracProcSalUnPrc = fracProcSalUnPrc;                // 端数処理（売上単価）
                                                        //row.SalesUnPrcChngCd = 1;
                                                        row.SalesUnPrcTaxIncFl = 0;            // 売単価(税込)
                                                        row.SalesUnPrcTaxExcFl = 0;            // 売単価(税抜)
                                                        // ----- UPD 2011/07/13 ------- <<<<<<<<<
                                                        // ----- ADD 2011/07/07 ------- <<<<<<<<<
                                                        break;
                                                    }
                                                // 定価を表示
                                                case 1:
                                                    {
                                                        //CalclateSalesUnitPriceByRateを呼び出して売上単価を算出する。
                                                        double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                                        int fracProcSalUnPrc = 0;
                                                        double fracProcUnitSalUnPrc = 0;
                                                        this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl, row.ListPriceTaxIncFl, row.TaxationDivCd, 100 - campaignObjGoodsSt.DiscountRate, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                                        row.BfSalesUnitPrice = row.ListPriceTaxExcFl;          // 変更前売価
                                                        row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;            // 売単価(税込)
                                                        row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;            // 売単価(税抜)
                                                        row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                                        row.FracProcSalUnPrc = fracProcSalUnPrc;                // 端数処理（売上単価）
                                                        row.SalesUnPrcChngCd = 1;
                                                        break;
                                                    }
                                            }
                                        }
                                        // 単価算出区分が「掛率」で、税込み定価、税抜き定価と異なる場合は単価再計算
                                        if ((row.UnPrcCalcCdSalUnPrc == (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal) &&
                                            ((row.StdUnPrcSalUnPrc != row.ListPriceTaxExcFl) && (row.StdUnPrcSalUnPrc != row.ListPriceTaxIncFl)))
                                        {
                                            double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                            int fracProcSalUnPrc = 0;
                                            double fracProcUnitSalUnPrc = 0;
                                            this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl, row.ListPriceTaxIncFl, row.TaxationDivCd, row.SalesRate, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                            row.StdUnPrcSalUnPrc = row.ListPriceTaxExcFl;           // 基準単価
                                            row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;            // 売単価(税抜)
                                            row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;            // 売単価(税込)
                                            row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                            row.FracProcSalUnPrc = fracProcSalUnPrc;                // 端数処理（売上単価）
                                            row.SalesUnPrcChngCd = 1;
                                        }
                                        else
                                        {
                                            if (isSetting)
                                            {
                                                //CalclateSalesUnitPriceByRateを呼び出して売上単価を算出する。
                                                double salesUnPrcTaxIncFl2, salesUnPrcTaxExcFl2, salesUnPrcDisplay2;
                                                int fracProcSalUnPrc2 = 0;
                                                double fracProcUnitSalUnPrc2 = 0;
                                                this.CalclateSalesUnitPriceByRate(row.SalesUnPrcTaxExcFl, row.SalesUnPrcTaxIncFl, row.TaxationDivCd, 100 - campaignObjGoodsSt.DiscountRate, out salesUnPrcTaxExcFl2, out salesUnPrcTaxIncFl2, out salesUnPrcDisplay2, ref fracProcUnitSalUnPrc2, ref fracProcSalUnPrc2);

                                                double price = row.SalesUnPrcTaxExcFl;
                                                row.BfSalesUnitPrice = price;          // 変更前売価
                                                row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl2;            // 売単価(税込)
                                                row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl2;            // 売単価(税抜)
                                                row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc2;        // 端数処理単位（売上単価）
                                                row.FracProcSalUnPrc = fracProcSalUnPrc2;                // 端数処理（売上単価）
                                                row.SalesUnPrcChngCd = 1;
                                            }
                                        }
                                    }

                                    this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, EstimateInputAcs.TargetData.PureParts, false);   // ADD 2011/08/12

                                }
                                // ---ADD 2011/06/07------------------<<<<<

                                #endregion
                            }
                            // 優良部品情報
                            if (( !string.IsNullOrEmpty(row.GoodsNo_Prime) ) && ( row.GoodsMakerCd_Prime != 0 ))
                            {
                                #region ○優良部品の単価算出結果の展開

                                bool isSetting = this.EstimateDetailRowPriceInfoSettingFromUnitPriceCalcRetList(TargetData.PrimeParts, row, unitPriceCalcRetList, true, true, false, false);

                                // ---ADD 2011/06/07--------------->>>>>
                                campaignObjGoodsStAcs.GetRatePriceOfCampaignMng(out campaignObjGoodsSt, this._enterpriseCode, this._salesSlip.ResultsAddUpSecCd, this._salesSlip.CustomerCode, row.GoodsMakerCd_Prime, row.BLGroupCode_Prime, row.BLGoodsCode_Prime, row.SalesCode_Prime, row.GoodsNo_Prime, this._salesSlip.SalesDate);

                                if (campaignObjGoodsSt == null)
                                {
                                // ---ADD 2011/06/07---------------<<<<<

                                    // 単価がセットされなかった場合
                                    if (!isSetting)
                                    {
                                        // 売上全体設定マスタの売価未設定時区分に従って設定
                                        switch (this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                                        {
                                            // ゼロ表示
                                            case 0:
                                                {
                                                    break;
                                                }
                                            // 定価を表示
                                            case 1:
                                                {
                                                    row.SalesUnPrcTaxIncFl_Prime = row.ListPriceTaxIncFl_Prime;
                                                    row.SalesUnPrcTaxExcFl_Prime = row.ListPriceTaxExcFl_Prime;
                                                    row.BfSalesUnitPrice_Prime = row.ListPriceTaxExcFl_Prime;
                                                    break;
                                                }
                                        }
                                    }

                                    // 単価算出区分が「掛率」で、税込み定価、税抜き定価と異なる場合は単価再計算
                                    if ((row.UnPrcCalcCdSalUnPrc_Prime == (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal) &&
                                        ((row.StdUnPrcSalUnPrc_Prime != row.ListPriceTaxExcFl_Prime) && (row.StdUnPrcSalUnPrc_Prime != row.ListPriceTaxIncFl_Prime)))
                                    {
                                        double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                        int fracProcSalUnPrc = 0;
                                        double fracProcUnitSalUnPrc = 0;
                                        this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl_Prime, row.ListPriceTaxIncFl_Prime, row.TaxationDivCd_Prime, row.SalesRate_Prime, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                        row.StdUnPrcSalUnPrc_Prime = row.ListPriceTaxExcFl;           // 基準単価
                                        row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;            // 売単価(税抜)
                                        row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;            // 売単価(税込)
                                        row.FracProcUnitSalUnPrc_Prime = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                        row.FracProcSalUnPrc_Prime = fracProcSalUnPrc;                // 端数処理（売上単価）
                                        row.SalesUnPrcChngCd_Prime = 1;
                                    }
                                // ---ADD 2011/06/07------------------>>>>>
                                }
                                else
                                {
                                    //キャンペーン対象商品設定が売価率設定の場合
                                    if (campaignObjGoodsSt.RateVal != 0)
                                    {
                                        double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                        int fracProcSalUnPrc = 0;
                                        double fracProcUnitSalUnPrc = 0;
                                        this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl_Prime, row.ListPriceTaxIncFl_Prime, row.TaxationDivCd_Prime, campaignObjGoodsSt.RateVal, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                        // 単価がセットされなかった場合
                                        if (!isSetting)
                                        {
                                            // 売上全体設定マスタの売価未設定時区分に従って設定
                                            switch (this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                                            {
                                                // ゼロ表示
                                                case 0:
                                                    {
                                                        // ----- ADD 2011/07/07 ------- >>>>>>>>>
                                                        row.SalesRate_Prime = campaignObjGoodsSt.RateVal;   // 売価率
                                                        row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;      // 売単価(税込)
                                                        row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;      // 売単価(税抜)
                                                        row.FracProcUnitSalUnPrc_Prime = fracProcUnitSalUnPrc;  // 端数処理単位（売上単価）
                                                        row.FracProcSalUnPrc_Prime = fracProcSalUnPrc;          // 端数処理（売上単価）
                                                        row.SalesUnPrcChngCd_Prime = 1;
                                                        // ----- ADD 2011/07/07 ------- <<<<<<<<<
                                                        break;
                                                    }
                                                // 定価を表示
                                                case 1:
                                                    {
                                                        row.BfSalesUnitPrice_Prime = row.ListPriceTaxExcFl_Prime;  // 変更前売価
                                                        row.SalesRate_Prime = campaignObjGoodsSt.RateVal;   // 売価率
                                                        row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;      // 売単価(税込)
                                                        row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;      // 売単価(税抜)
                                                        row.FracProcUnitSalUnPrc_Prime = fracProcUnitSalUnPrc;  // 端数処理単位（売上単価）
                                                        row.FracProcSalUnPrc_Prime = fracProcSalUnPrc;          // 端数処理（売上単価）
                                                        row.SalesUnPrcChngCd_Prime = 1;
                                                        break;
                                                    }
                                            }
                                        }
                                        else
                                        {
                                            row.BfSalesUnitPrice_Prime = row.SalesUnPrcTaxExcFl_Prime;  // 変更前売価
                                            row.SalesRate_Prime = campaignObjGoodsSt.RateVal;       // 売価率
                                            row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;      // 売単価(税込)
                                            row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;      // 売単価(税抜)
                                            row.FracProcUnitSalUnPrc_Prime = fracProcUnitSalUnPrc;  // 端数処理単位（売上単価）
                                            row.FracProcSalUnPrc_Prime = fracProcSalUnPrc;          // 端数処理（売上単価）
                                            row.SalesUnPrcChngCd_Prime = 1;
                                        }

                                    }
                                    //キャンペーン対象商品設定が売価額設定の場合
                                    if (campaignObjGoodsSt.PriceFl != 0)
                                    {
                                        //CalclateSalesUnitPriceByRateを呼び出して売上単価を算出する。
                                        double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                        int fracProcSalUnPrc = 0;
                                        double fracProcUnitSalUnPrc = 0;
                                        this.CalclateSalesUnitPriceByRate(campaignObjGoodsSt.PriceFl, campaignObjGoodsSt.PriceFl, row.TaxationDivCd_Prime, 100, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                        // 単価がセットされなかった場合
                                        if (!isSetting)
                                        {
                                            // 売上全体設定マスタの売価未設定時区分に従って設定
                                            switch (this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                                            {
                                                // ゼロ表示
                                                case 0:
                                                    {
                                                        // ----- ADD 2011/07/07 ------- <<<<<<<<<
                                                        row.SalesUnPrcTaxExcFl_Prime = campaignObjGoodsSt.PriceFl;
                                                        row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;
                                                        row.SalesUnPrcChngCd_Prime = 1;
                                                        // ----- ADD 2011/07/07 ------- >>>>>>>>>
                                                        break;
                                                    }
                                                // 定価を表示
                                                case 1:
                                                    {
                                                        row.BfSalesUnitPrice_Prime = row.ListPriceTaxExcFl_Prime;      // 変更前売価
                                                        row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;     // 売単価(税抜)←定価(税抜)
                                                        row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;     // 売単価(税込)←定価(税込)
                                                        row.SalesUnPrcChngCd_Prime = 1;
                                                        break;
                                                    }
                                            }
                                        }
                                        else
                                        {
                                            row.BfSalesUnitPrice_Prime = row.SalesUnPrcTaxExcFl_Prime;     // 変更前売価
                                            row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;     // 売単価(税抜)←定価(税抜)
                                            row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;     // 売単価(税込)←定価(税込)
                                            row.SalesUnPrcChngCd_Prime = 1;
                                        }

                                    }
                                    //キャンペーン対象商品設定が値引率設定の場合
                                    if (campaignObjGoodsSt.DiscountRate != 0)
                                    {
                                        if (!isSetting)
                                        {
                                            // 売上全体設定マスタの売価未設定時区分に従って設定
                                            switch (this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                                            {
                                                // ゼロ表示
                                                case 0:
                                                    {
                                                        // ----- ADD 2011/07/07 ------- >>>>>>>>>
                                                        // ----- UPD 2011/07/13 ------- >>>>>>>>>
                                                        //double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                                        
                                                        //int fracProcSalUnPrc = 0;
                                                        //double fracProcUnitSalUnPrc = 0;
                                                        //this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl_Prime, row.ListPriceTaxIncFl_Prime, row.TaxationDivCd_Prime, 100 - campaignObjGoodsSt.DiscountRate, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                                        //row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;            // 売単価(税込)
                                                        //row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;            // 売単価(税抜)
                                                        //row.FracProcUnitSalUnPrc_Prime = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                                        //row.FracProcSalUnPrc_Prime = fracProcSalUnPrc;                // 端数処理（売上単価）
                                                        //row.SalesUnPrcChngCd_Prime = 1;
                                                        row.SalesUnPrcTaxIncFl_Prime = 0;            // 売単価(税込)
                                                        row.SalesUnPrcTaxExcFl_Prime = 0;            // 売単価(税抜)
                                                        // ----- UPD 2011/07/13 ------- <<<<<<<<<
                                                        // ----- ADD 2011/07/07 ------- <<<<<<<<<
                                                        break;
                                                    }
                                                // 定価を表示
                                                case 1:
                                                    {
                                                        //CalclateSalesUnitPriceByRateを呼び出して売上単価を算出する。
                                                        double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                                        int fracProcSalUnPrc = 0;
                                                        double fracProcUnitSalUnPrc = 0;
                                                        this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl_Prime, row.ListPriceTaxIncFl_Prime, row.TaxationDivCd_Prime, 100 - campaignObjGoodsSt.DiscountRate, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                                        row.BfSalesUnitPrice_Prime = row.ListPriceTaxExcFl_Prime;          // 変更前売価
                                                        row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;            // 売単価(税込)
                                                        row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;            // 売単価(税抜)
                                                        row.FracProcUnitSalUnPrc_Prime = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                                        row.FracProcSalUnPrc_Prime = fracProcSalUnPrc;                // 端数処理（売上単価）
                                                        row.SalesUnPrcChngCd_Prime = 1;
                                                        break;
                                                    }
                                            }
                                        }
                                        // 単価算出区分が「掛率」で、税込み定価、税抜き定価と異なる場合は単価再計算
                                        if ((row.UnPrcCalcCdSalUnPrc_Prime == (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal) &&
                                            ((row.StdUnPrcSalUnPrc_Prime != row.ListPriceTaxExcFl_Prime) && (row.StdUnPrcSalUnPrc_Prime != row.ListPriceTaxIncFl_Prime)))
                                        {
                                            double salesUnPrcTaxIncFl, salesUnPrcTaxExcFl, salesUnPrcDisplay;
                                            int fracProcSalUnPrc = 0;
                                            double fracProcUnitSalUnPrc = 0;
                                            this.CalclateSalesUnitPriceByRate(row.ListPriceTaxExcFl_Prime, row.ListPriceTaxIncFl_Prime, row.TaxationDivCd_Prime, row.SalesRate_Prime, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl, out salesUnPrcDisplay, ref fracProcUnitSalUnPrc, ref fracProcSalUnPrc);

                                            row.StdUnPrcSalUnPrc_Prime = row.ListPriceTaxExcFl;           // 基準単価
                                            row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl;            // 売単価(税抜)
                                            row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl;            // 売単価(税込)
                                            row.FracProcUnitSalUnPrc_Prime = fracProcUnitSalUnPrc;        // 端数処理単位（売上単価）
                                            row.FracProcSalUnPrc_Prime = fracProcSalUnPrc;                // 端数処理（売上単価）
                                            row.SalesUnPrcChngCd_Prime = 1;
                                        }
                                        else
                                        {
                                            if (isSetting)
                                            {
                                                //CalclateSalesUnitPriceByRateを呼び出して売上単価を算出する。
                                                double salesUnPrcTaxIncFl2, salesUnPrcTaxExcFl2, salesUnPrcDisplay2;
                                                int fracProcSalUnPrc2 = 0;
                                                double fracProcUnitSalUnPrc2 = 0;
                                                this.CalclateSalesUnitPriceByRate(row.SalesUnPrcTaxExcFl_Prime, row.SalesUnPrcTaxIncFl_Prime, row.TaxationDivCd_Prime, 100 - campaignObjGoodsSt.DiscountRate, out salesUnPrcTaxExcFl2, out salesUnPrcTaxIncFl2, out salesUnPrcDisplay2, ref fracProcUnitSalUnPrc2, ref fracProcSalUnPrc2);

                                                double price = row.SalesUnPrcTaxExcFl_Prime;
                                                row.BfSalesUnitPrice_Prime = price;               // 変更前売価
                                                row.SalesUnPrcTaxIncFl_Prime = salesUnPrcTaxIncFl2;            // 売単価(税込)
                                                row.SalesUnPrcTaxExcFl_Prime = salesUnPrcTaxExcFl2;            // 売単価(税抜)
                                                row.FracProcUnitSalUnPrc_Prime = fracProcUnitSalUnPrc2;        // 端数処理単位（売上単価）
                                                row.FracProcSalUnPrc_Prime = fracProcSalUnPrc2;                // 端数処理（売上単価）
                                                row.SalesUnPrcChngCd_Prime = 1;
                                            }
                                        }
                                    }

                                    this.EstimateDetailRowClearRateInfo(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, EstimateInputAcs.TargetData.PrimeParts, false);   // ADD 2011/08/12
                                }
                                // ---ADD 2011/06/07------------------<<<<<
                                #endregion
                            }
                            this.CalculateSalesMoney(row);
                        }

                        break;
                    }
                #endregion
            }
        }

        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="salesUnitCost">原価単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="taxFracProcCode">消費税端数処理区分</param>
        /// <param name="costTaxInc">原価金額（税込み）</param>
        /// <param name="costTaxExc">原価金額（税抜き）</param>
        /// <param name="costConsTax">原価消費税</param>
        /// <returns></returns>
        private bool CalculateCost( double count, double salesUnitCost, int taxationCode, double taxRate, int stockMoneyFrcProcCd, int taxFracProcCode,
            out long costTaxInc, out long costTaxExc, out long costConsTax )
        {
            double taxFracProcUnit;
            int taxFracProcCd;
            this._estimateInputInitDataAcs.GetStockFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

            this.CalculateCost(count, salesUnitCost, taxationCode, taxRate, stockMoneyFrcProcCd, taxFracProcUnit, taxFracProcCd, out costTaxInc, out costTaxExc, out costConsTax);

            return true;
        }

        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="salesUnitCost">原価単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="taxFracProcCd">仕入消費税端数処理区分</param>
        /// <param name="taxFracProcUnit">仕入消費税端数処理単位</param>
        /// <param name="costTaxInc">原価金額（税込み）</param>
        /// <param name="costTaxExc">原価金額（税抜き）</param>
        /// <param name="costConsTax">原価消費税</param>
        /// <returns></returns>
        private bool CalculateCost(double count, double salesUnitCost, int taxationCode, double taxRate, int stockMoneyFrcProcCd, 
            double taxFracProcUnit, int taxFracProcCd,out long costTaxInc, out long costTaxExc, out long costConsTax)
        {
            costTaxInc = 0;
            costTaxExc = 0;
            costConsTax = 0;

            // 仕入数が0または仕入単価が0の場合はすべて0で終了
            if (( count == 0 ) || ( salesUnitCost == 0 )) return true;

            // 外税の場合
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                double unitPriceExc = salesUnitCost;	// 単価（税抜き）
                double unitPriceInc;					// 単価（税込み）
                double unitPriceTax;					// 単価（消費税）
                long priceExc = 0;						// 価格（税抜き）
                long priceInc;							// 価格（税込み）
                long priceTax;							// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxExc, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                costTaxInc = priceInc;			// 原価金額（税込み）
                costTaxExc = priceExc;			// 原価金額（税抜き）		
                costConsTax = priceTax;			// 原価消費税
            }
            // 内税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                double unitPriceExc;					// 単価（税抜き）
                double unitPriceInc = salesUnitCost;	// 単価（税込み）
                double unitPriceTax;					// 単価（消費税）
                long priceExc;							// 価格（税抜き）
                long priceInc = 0;						// 価格（税込み）
                long priceTax;							// 価格（消費税）

                this._stockPriceCalculate.CalcTaxExcFromTaxInc((int)CalculateTax.TaxationCode.TaxInc, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                costTaxInc = priceInc;			// 原価金額（税込み）
                costTaxExc = priceExc;			// 原価金額（税抜き）
                costConsTax = priceTax;			// 原価消費税
            }
            // 非課税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                double unitPriceExc = salesUnitCost;	// 単価（税抜き）
                double unitPriceInc;					// 単価（税込み）
                double unitPriceTax;					// 単価（消費税）
                long priceExc = 0;						// 価格（税抜き）
                long priceInc;							// 価格（税込み）
                long priceTax;							// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxNone, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                costTaxInc = priceExc;			// 原価金額（税込み）
                costTaxExc = priceExc;			// 原価金額（税込み）
                costConsTax = priceTax;			// 原価消費税
            }

            return true;
        }

        /// <summary>
        /// 単価算出結果リストより、純正部品の単価情報を設定します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceCalcRetList"></param>
        /// <param name="setListPrice"></param>
        /// <param name="setSalUnCst"></param>
        /// <param name="setSalUnPrc"></param>
        private void EstimateDetailRowPurePartsPriceInfoSettingFromUnitPriceCalcRetList(EstimateInputDataSet.EstimateDetailRow row, List<UnitPriceCalcRet> unitPriceCalcRetList, bool setSalUnPrc, bool setListPrice, bool setSalUnCst)
        {
            if (( unitPriceCalcRetList == null ) || ( unitPriceCalcRetList.Count == 0 )) return;
            if (( string.IsNullOrEmpty(row.GoodsNo) ) || ( row.GoodsMakerCd == 0 )) return;

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (( unitPriceCalcRet.GoodsNo == row.GoodsNo ) && ( unitPriceCalcRet.GoodsMakerCd == row.GoodsMakerCd ) && ( unitPriceCalcRet.SupplierCd == row.SupplierCd ))
                {
                    switch (unitPriceCalcRet.UnitPriceKind)
                    {
                        // 売上単価
                        case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice:
                            {
                                if (setSalUnPrc)
                                {
                                    row.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                    row.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;       // 掛率設定区分
                                    row.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;      // 単価算出区分
                                    row.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;                // 価格区分
                                    row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // 基準単価
                                    row.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // 売単価(税抜)
                                    row.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;    // 売単価(税込)
                                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                                    {
                                        // 基準価格×売価率
                                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                            row.SalesRate = unitPriceCalcRet.RateVal;               // 売価率
                                            break;
                                        // 原価UP率
                                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                            row.SalesRate = unitPriceCalcRet.RateVal;               // 原価UP率
                                            break;
                                        // 粗利確保率
                                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                            row.SalesRate = unitPriceCalcRet.RateVal;               // 粗利確保率
                                            break;
                                        // 単価直接指定
                                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                            break;
                                    }
                                    row.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;  // 端数処理単位
                                    row.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;       // 端数処理区分
                                    row.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;      // 変更前売価

                                }
                                break;
                            }
                        // 定価
                        case UnitPriceCalculation.ctUnitPriceKind_ListPrice:
                            {
                                if (setListPrice)
                                {
                                    row.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;          // 掛率設定拠点
                                    row.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;         // 掛率設定区分
                                    row.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;        // 単価算出区分
                                    row.PriceCdLPrice = unitPriceCalcRet.PriceDiv;                  // 価格区分
                                    row.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;             // 基準単価
                                    row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)
                                    row.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;     // 定価(税込)
                                    row.ListPriceRate = unitPriceCalcRet.RateVal;                   // 定価率
                                    row.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;    // 端数処理単位
                                    row.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;         // 端数処理区分
                                    row.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;           // 変更前定価

                                    //--------------------------------------------
                                    // 総額表示しない
                                    //--------------------------------------------
                                    if (this._salesSlip.TotalAmountDispWayCd == 0)
                                    {
                                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        {
                                            case CalculateTax.TaxationCode.TaxExc:
                                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxInc:
                                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxNone:
                                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                                break;
                                        }
                                    }
                                    //--------------------------------------------
                                    // 総額表示する
                                    //--------------------------------------------
                                    else
                                    {
                                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                    }
                                }
                                break;
                            }
                        // 原価単価
                        case UnitPriceCalculation.ctUnitPriceKind_UnitCost:
                            {
                                if (setSalUnCst)
                                {
                                    row.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                    row.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;          // 掛率設定区分
                                    row.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;         // 単価算出区分
                                    row.PriceCdUnCst = unitPriceCalcRet.PriceDiv;                   // 価格区分
                                    row.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;              // 基準単価
                                    //row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // 原単価(税抜)
                                    //row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // 原単価(税込)
                                    row.CostRate = unitPriceCalcRet.RateVal;                        // 原価率
                                    row.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;     // 端数処理単位
                                    row.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;          // 端数処理区分
                                    row.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;            // 変更前原価

                                    //--------------------------------------------
                                    // 総額表示しない
                                    //--------------------------------------------
                                    if (this._salesSlip.TotalAmountDispWayCd == 0)
                                    {
                                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        {
                                            case CalculateTax.TaxationCode.TaxExc:
                                                row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxInc:
                                                row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxNone:
                                                row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                                break;
                                        }
                                    }
                                    //--------------------------------------------
                                    // 総額表示する
                                    //--------------------------------------------
                                    else
                                    {
                                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        {
                                            case CalculateTax.TaxationCode.TaxExc:
                                                row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxInc:
                                                row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxNone:
                                                row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                                break;
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }
        }


        /// <summary>
        /// 単価算出結果リストより、単価情報を設定します。
        /// </summary>
        /// <param name="tagetData">対象データ</param>
        /// <param name="row">見積明細行オブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="isCheckSupplierCd">True:仕入先コードもチェックする</param>
        /// <param name="setSalUnPrc">True:売上単価の算出結果をセットする</param>
        /// <param name="setListPrice">True:定価の算出結果をセットする</param>
        /// <param name="setSalUnCst">True:原価単価の算出結果をセットする</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             売価計算を掛率設定にした場合、売価率が正常にセットされない。</br>
        private bool EstimateDetailRowPriceInfoSettingFromUnitPriceCalcRetList(TargetData tagetData, EstimateInputDataSet.EstimateDetailRow row, List<UnitPriceCalcRet> unitPriceCalcRetList, bool isCheckSupplierCd, bool setSalUnPrc, bool setListPrice, bool setSalUnCst)
        {
            if (( unitPriceCalcRetList == null ) || ( unitPriceCalcRetList.Count == 0 )) return false;

            bool isSetting = false;
            bool isSetPureParts = ( ( ( tagetData == TargetData.All ) || ( tagetData == TargetData.PureParts ) ) && ( ( !string.IsNullOrEmpty(row.GoodsNo) ) && ( row.GoodsMakerCd != 0 ) ) );
            bool isSetPrimeParts = ( ( ( tagetData == TargetData.All ) || ( tagetData == TargetData.PrimeParts ) ) && ( ( !string.IsNullOrEmpty(row.GoodsNo_Prime) ) && ( row.GoodsMakerCd_Prime != 0 ) ) );

            if (( !isSetPureParts ) && ( !isSetPrimeParts )) return false;

            #region セット判定用に使用するキー
            const string ctSetSalUnPrc_Pure = "SetSalUnPrc_Pure";
            const string ctSetListPrice_Pure = "SetListPrice_Pure";
            const string ctSetSalUnCst_Pure = "SetSalUnCst_Pure";

            const string ctSetSalUnPrc_Prime = "SetSalUnPrc_Prime";
            const string ctSetListPrice_Prime = "SetListPrice_Prime";
            const string ctSetSalUnCst_Prime = "SetSalUnCst_Prime";

            #endregion

            Dictionary<string, bool> setList = new Dictionary<string, bool>();
            if (isSetPureParts)
            {
                if (setSalUnPrc) setList.Add(ctSetSalUnPrc_Pure, false);
                if (setListPrice) setList.Add(ctSetListPrice_Pure, false);
                if (setSalUnCst) setList.Add(ctSetSalUnCst_Pure, false);
            }
            if (isSetPrimeParts)
            {
                if (setSalUnPrc) setList.Add(ctSetSalUnPrc_Prime, false);
                if (setListPrice) setList.Add(ctSetListPrice_Prime, false);
                if (setSalUnCst) setList.Add(ctSetSalUnCst_Prime, false);
            }

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                #region 純正部品の算出結果セット
                if (isSetPureParts)
                {
                    if (( unitPriceCalcRet.GoodsNo == row.GoodsNo ) &&
                        ( unitPriceCalcRet.GoodsMakerCd == row.GoodsMakerCd ) &&
                        ( ( !isCheckSupplierCd ) || ( ( isCheckSupplierCd ) && ( unitPriceCalcRet.SupplierCd == row.SupplierCd ) ) ))
                    {
                        switch (unitPriceCalcRet.UnitPriceKind)
                        {
                            #region 売上単価
                            case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice:
                                {
                                    if (setSalUnPrc)
                                    {
                                        row.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                        row.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;       // 掛率設定区分
                                        row.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;      // 単価算出区分
                                        row.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;                // 価格区分
                                        row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // 基準単価
                                        row.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // 売単価(税抜)
                                        row.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;    // 売単価(税込)
                                        switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                                        {
                                            // 基準価格×売価率
                                            case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                                row.SalesRate = unitPriceCalcRet.RateVal;               // 売価率
                                                break;
                                            // 原価UP率
                                            case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                                row.SalesRate = unitPriceCalcRet.RateVal;               // 原価UP率
                                                break;
                                            // 粗利確保率
                                            case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                                row.SalesRate = unitPriceCalcRet.RateVal;               // 粗利確保率
                                                break;
                                            // 単価直接指定
                                            case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                                break;
                                        }
                                        row.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;  // 端数処理単位
                                        row.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;       // 端数処理区分
                                        row.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;      // 変更前売価

                                        row.SalesUnPrcChngCd = ( row.SalesUnPrcTaxExcFl == row.BfSalesUnitPrice ) ? 0 : 1;

                                        if (setList.ContainsKey(ctSetSalUnPrc_Pure)) setList[ctSetSalUnPrc_Pure] = true;

                                        isSetting = true;
                                    }
                                    break;
                                }
                            #endregion

                            #region 定価
                            case UnitPriceCalculation.ctUnitPriceKind_ListPrice:
                                {
                                    if (setListPrice)
                                    {
                                        row.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;          // 掛率設定拠点
                                        row.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;         // 掛率設定区分
                                        row.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;        // 単価算出区分
                                        row.PriceCdLPrice = unitPriceCalcRet.PriceDiv;                  // 価格区分
                                        row.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;             // 基準単価
                                        row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)
                                        row.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;     // 定価(税込)
                                        row.ListPriceRate = unitPriceCalcRet.RateVal;                   // 定価率
                                        row.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;    // 端数処理単位
                                        row.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;         // 端数処理区分
                                        row.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;           // 変更前定価
                                        row.OpenPriceDiv= unitPriceCalcRet.OpenPriceDiv;               // オープン価格区分

                                        // 転嫁方式：非課税
                                        if (this._salesSlip.ConsTaxLayMethod == 9)
                                        {
                                            row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        }
                                        //--------------------------------------------
                                        // 総額表示しない
                                        //--------------------------------------------
                                        else if (this._salesSlip.TotalAmountDispWayCd == 0)
                                        {
                                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                            {
                                                case CalculateTax.TaxationCode.TaxExc:
                                                    row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                                    break;
                                                case CalculateTax.TaxationCode.TaxInc:
                                                    row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                                    break;
                                                case CalculateTax.TaxationCode.TaxNone:
                                                    row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                                    break;
                                            }
                                        }
                                        //--------------------------------------------
                                        // 総額表示する
                                        //--------------------------------------------
                                        else
                                        {
                                            row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                        }

                                        row.ListPriceChngCd = ( row.ListPriceTaxExcFl == row.BfListPrice ) ? 0 : 1;

                                        // --- ADD 2013/12/16 Y.Wakita ---------->>>>>
                                        row.CmpltSalesRowNo_Prime = row.BLGoodsCode;          // 純正-BL商品コード
                                        row.CmpltGoodsMakerCd_Prime = row.GoodsMakerCd;       // 純正-メーカー
                                        row.CmpltGoodsName_Prime = unitPriceCalcRet.GoodsNo;  // 純正-商品番号
                                        row.CmpltSalesUnPrcFl_Prime = row.ListPriceDisplay;   // 純正-定価
                                        // --- ADD 2013/12/16 Y.Wakita ----------<<<<<

                                        if (setList.ContainsKey(ctSetListPrice_Pure)) setList[ctSetListPrice_Pure] = true;
                                        isSetting = true;

                                    }
                                    break;
                                }
                            #endregion

                            #region 原価単価
                            case UnitPriceCalculation.ctUnitPriceKind_UnitCost:
                                {
                                    if (setSalUnCst)
                                    {
                                        row.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                        row.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;          // 掛率設定区分
                                        row.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;         // 単価算出区分
                                        row.PriceCdUnCst = unitPriceCalcRet.PriceDiv;                   // 価格区分
                                        row.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;              // 基準単価
                                        //row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // 原単価(税抜)
                                        //row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // 原単価(税込)
                                        row.CostRate = unitPriceCalcRet.RateVal;                        // 原価率
                                        row.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;     // 端数処理単位
                                        row.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;          // 端数処理区分
                                        row.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;            // 変更前原価

                                        row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        ////--------------------------------------------
                                        //// 総額表示しない
                                        ////--------------------------------------------
                                        //if (this._salesSlip.TotalAmountDispWayCd == 0)
                                        //{
                                        //    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        //    {
                                        //        case CalculateTax.TaxationCode.TaxExc:
                                        //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        //            break;
                                        //        case CalculateTax.TaxationCode.TaxInc:
                                        //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;
                                        //            break;
                                        //        case CalculateTax.TaxationCode.TaxNone:
                                        //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        //            break;
                                        //    }
                                        //}
                                        ////--------------------------------------------
                                        //// 総額表示する
                                        ////--------------------------------------------
                                        //else
                                        //{
                                        //    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        //    {
                                        //        case CalculateTax.TaxationCode.TaxExc:
                                        //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        //            break;
                                        //        case CalculateTax.TaxationCode.TaxInc:
                                        //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;
                                        //            break;
                                        //        case CalculateTax.TaxationCode.TaxNone:
                                        //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        //            break;
                                        //    }
                                        //}

                                        row.SalesUnitCostChngDiv = ( row.SalesUnitCost == row.BfUnitCost ) ? 0 : 1;

                                        if (setList.ContainsKey(ctSetSalUnCst_Pure)) setList[ctSetSalUnCst_Pure] = true;

                                        isSetting = true;
                                    }
                                    break;
                                }
                            #endregion
                        }
                    }
                }
                #endregion

                #region 優良部品の算出結果セット

                if (isSetPrimeParts)
                {
                    if (( unitPriceCalcRet.GoodsNo == row.GoodsNo_Prime ) &&
                        ( unitPriceCalcRet.GoodsMakerCd == row.GoodsMakerCd_Prime ) &&
                        ( ( !isCheckSupplierCd ) || ( ( isCheckSupplierCd ) && ( unitPriceCalcRet.SupplierCd == row.SupplierCd_Prime ) ) ))
                    {
                        switch (unitPriceCalcRet.UnitPriceKind)
                        {
                            #region 売上単価
                            case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice:
                                {
                                    if (setSalUnPrc)
                                    {
                                        // 売価を手入力で変更している場合は掛率再取得は行わない
                                        row.RateSectSalUnPrc_Prime = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                        row.RateDivSalUnPrc_Prime = unitPriceCalcRet.RateSettingDivide;       // 掛率設定区分
                                        row.UnPrcCalcCdSalUnPrc_Prime = unitPriceCalcRet.UnitPrcCalcDiv;      // 単価算出区分
                                        row.PriceCdSalUnPrc_Prime = unitPriceCalcRet.PriceDiv;                // 価格区分
                                        row.StdUnPrcSalUnPrc_Prime = unitPriceCalcRet.StdUnitPrice;           // 基準単価
                                        row.SalesUnPrcTaxExcFl_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;    // 売単価(税抜)
                                        row.SalesUnPrcTaxIncFl_Prime = unitPriceCalcRet.UnitPriceTaxIncFl;    // 売単価(税込)
                                        switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                                        {
                                            // 基準価格×売価率
                                            case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                                //-----2011/02/14----->>>>>
                                                //row.SalesRate = unitPriceCalcRet.RateVal;               // 売価率
                                                row.SalesRate_Prime = unitPriceCalcRet.RateVal;               // 売価率
                                                //-----2011/02/14-----<<<<<
                                                break;
                                            // 原価UP率
                                            case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                                //-----2011/02/14----->>>>>
                                                //row.SalesRate = unitPriceCalcRet.RateVal;               // 原価UP率
                                                row.SalesRate_Prime = unitPriceCalcRet.RateVal;               // 原価UP率
                                                //-----2011/02/14-----<<<<<
                                                break;
                                            // 粗利確保率
                                            case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                                //-----2011/02/14----->>>>>
                                                //row.SalesRate = unitPriceCalcRet.RateVal;               // 粗利確保率
                                                row.SalesRate_Prime = unitPriceCalcRet.RateVal;               // 粗利確保率
                                                //-----2011/02/14-----<<<<<
                                                break;
                                            // 単価直接指定
                                            case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                                break;
                                        }
                                        row.FracProcUnitSalUnPrc_Prime = unitPriceCalcRet.UnPrcFracProcUnit;  // 端数処理単位
                                        row.FracProcSalUnPrc_Prime = unitPriceCalcRet.UnPrcFracProcDiv;       // 端数処理区分
                                        row.BfSalesUnitPrice_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;      // 変更前売価

                                        row.SalesUnPrcChngCd_Prime = ( row.SalesUnPrcTaxExcFl_Prime == row.BfSalesUnitPrice_Prime ) ? 0 : 1;

                                        if (setList.ContainsKey(ctSetSalUnPrc_Prime)) setList[ctSetSalUnPrc_Prime] = true;
                                        isSetting = true;

                                    }
                                    break;
                                }
                            #endregion

                            #region 定価
                            case UnitPriceCalculation.ctUnitPriceKind_ListPrice:
                                {
                                    if (setListPrice)
                                    {
                                        row.RateSectPriceUnPrc_Prime = unitPriceCalcRet.SectionCode;          // 掛率設定拠点
                                        row.RateDivLPrice_Prime = unitPriceCalcRet.RateSettingDivide;         // 掛率設定区分
                                        row.UnPrcCalcCdLPrice_Prime = unitPriceCalcRet.UnitPrcCalcDiv;        // 単価算出区分
                                        row.PriceCdLPrice_Prime = unitPriceCalcRet.PriceDiv;                  // 価格区分
                                        row.StdUnPrcLPrice_Prime = unitPriceCalcRet.StdUnitPrice;             // 基準単価
                                        row.ListPriceTaxExcFl_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)
                                        row.ListPriceTaxIncFl_Prime = unitPriceCalcRet.UnitPriceTaxIncFl;     // 定価(税込)
                                        row.ListPriceRate_Prime = unitPriceCalcRet.RateVal;                   // 定価率
                                        row.FracProcUnitLPrice_Prime = unitPriceCalcRet.UnPrcFracProcUnit;    // 端数処理単位
                                        row.FracProcLPrice_Prime = unitPriceCalcRet.UnPrcFracProcDiv;         // 端数処理区分
                                        row.BfListPrice_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;           // 変更前定価
                                        row.OpenPriceDiv_Prime = unitPriceCalcRet.OpenPriceDiv;               // オープン価格区分
                                        /* ------------DEL START wangf 2012/04/06 FOR Redmine#29227--------->>>>
                                        row.RateBLGoodsCode_Prime = row.BLGoodsCode;                          // BL商品コード(掛率)
                                        row.RateBLGoodsName_Prime = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                                        // ------------DEL END wangf 2012/04/06 FOR Redmine#29227---------<<<<<*/

                                        // 転嫁方式：非課税
                                        if (this._salesSlip.ConsTaxLayMethod == 9)
                                        {
                                            row.ListPriceDisplay_Prime = row.ListPriceTaxExcFl_Prime;
                                        }
                                        //--------------------------------------------
                                        // 総額表示しない
                                        //--------------------------------------------
                                        else if (this._salesSlip.TotalAmountDispWayCd == 0)
                                        {
                                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                            {
                                                case CalculateTax.TaxationCode.TaxExc:
                                                    row.ListPriceDisplay_Prime = row.ListPriceTaxExcFl_Prime;
                                                    break;
                                                case CalculateTax.TaxationCode.TaxInc:
                                                    row.ListPriceDisplay_Prime = row.ListPriceTaxIncFl_Prime;
                                                    break;
                                                case CalculateTax.TaxationCode.TaxNone:
                                                    row.ListPriceDisplay_Prime = row.ListPriceTaxExcFl_Prime;
                                                    break;
                                            }
                                        }
                                        //--------------------------------------------
                                        // 総額表示する
                                        //--------------------------------------------
                                        else
                                        {
                                            row.ListPriceDisplay_Prime = row.ListPriceTaxIncFl_Prime;
                                        }

                                        row.ListPriceChngCd_Prime = ( row.ListPriceTaxExcFl_Prime == row.BfListPrice_Prime ) ? 0 : 1;

                                        if (setList.ContainsKey(ctSetListPrice_Prime)) setList[ctSetListPrice_Prime] = true;
                                        isSetting = true;

                                    }
                                    break;
                                }
                            #endregion

                            #region 原価単価
                            case UnitPriceCalculation.ctUnitPriceKind_UnitCost:
                                {
                                    if (setSalUnCst)
                                    {
                                        row.RateSectCstUnPrc_Prime = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                        row.RateDivUnCst_Prime = unitPriceCalcRet.RateSettingDivide;          // 掛率設定区分
                                        row.UnPrcCalcCdUnCst_Prime = unitPriceCalcRet.UnitPrcCalcDiv;         // 単価算出区分
                                        row.PriceCdUnCst_Prime = unitPriceCalcRet.PriceDiv;                   // 価格区分
                                        row.StdUnPrcUnCst_Prime = unitPriceCalcRet.StdUnitPrice;              // 基準単価
                                        //row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // 原単価(税抜)
                                        //row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // 原単価(税込)
                                        row.CostRate_Prime = unitPriceCalcRet.RateVal;                        // 原価率
                                        row.FracProcUnitUnCst_Prime = unitPriceCalcRet.UnPrcFracProcUnit;     // 端数処理単位
                                        row.FracProcUnCst_Prime = unitPriceCalcRet.UnPrcFracProcDiv;          // 端数処理区分
                                        row.BfUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;            // 変更前原価

                                        row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        ////--------------------------------------------
                                        //// 総額表示しない
                                        ////--------------------------------------------
                                        //if (this._salesSlip.TotalAmountDispWayCd == 0)
                                        //{
                                        //    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        //    {
                                        //        case CalculateTax.TaxationCode.TaxExc:
                                        //            row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        //            break;
                                        //        case CalculateTax.TaxationCode.TaxInc:
                                        //            row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxIncFl;
                                        //            break;
                                        //        case CalculateTax.TaxationCode.TaxNone:
                                        //            row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        //            break;
                                        //    }
                                        //}
                                        ////--------------------------------------------
                                        //// 総額表示する
                                        ////--------------------------------------------
                                        //else
                                        //{
                                        //    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        //    {
                                        //        case CalculateTax.TaxationCode.TaxExc:
                                        //            row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        //            break;
                                        //        case CalculateTax.TaxationCode.TaxInc:
                                        //            row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxIncFl;
                                        //            break;
                                        //        case CalculateTax.TaxationCode.TaxNone:
                                        //            row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;
                                        //            break;
                                        //    }
                                        //}
                                        if (setList.ContainsKey(ctSetSalUnCst_Prime)) setList[ctSetSalUnCst_Prime] = true;

                                        row.SalesUnitCostChngDiv_Prime = ( row.SalesUnitCost_Prime == row.BfUnitCost_Prime ) ? 0 : 1;
                                        isSetting = true;
                                    }
                                    break;
                                }
                            #endregion
                        }
                    }
                }
                #endregion

                // セット対象データが全てセットされていれば処理終了
                if (!setList.ContainsValue(false))
                {
                    break;
                }
            }

            return isSetting;
        }

        /* ------------DEL START wangf 2012/04/06 FOR Redmine#29227--------->>>>
        /// <summary>
        /// 単価算出結果リストより、優良部品の単価情報を設定します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceCalcRetList"></param>
        /// <param name="setListPrice"></param>
        /// <param name="setSalUnCst"></param>
        /// <param name="setSalUnPrc"></param>
        private void EstimateDetailRowPrimePartsPriceInfoSettingFromUnitPriceCalcRetList( EstimateInputDataSet.EstimateDetailRow row, List<UnitPriceCalcRet> unitPriceCalcRetList, bool setSalUnPrc, bool setListPrice, bool setSalUnCst )
        {
            if (( unitPriceCalcRetList == null ) || ( unitPriceCalcRetList.Count == 0 )) return;
            if (( string.IsNullOrEmpty(row.GoodsNo_Prime) ) || ( row.GoodsMakerCd_Prime == 0 )) return;

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (( unitPriceCalcRet.GoodsNo == row.GoodsNo_Prime ) && ( unitPriceCalcRet.GoodsMakerCd == row.GoodsMakerCd_Prime ) && ( unitPriceCalcRet.SupplierCd == row.SupplierCd_Prime ))
                {
                    switch (unitPriceCalcRet.UnitPriceKind)
                    {
                        // 売上単価
                        case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice:
                            {
                                if (setSalUnPrc)
                                {
                                    // 売価を手入力で変更している場合は掛率再取得は行わない
                                    row.RateSectSalUnPrc_Prime = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                    row.RateDivSalUnPrc_Prime = unitPriceCalcRet.RateSettingDivide;       // 掛率設定区分
                                    row.UnPrcCalcCdSalUnPrc_Prime = unitPriceCalcRet.UnitPrcCalcDiv;      // 単価算出区分
                                    row.PriceCdSalUnPrc_Prime = unitPriceCalcRet.PriceDiv;                // 価格区分
                                    row.StdUnPrcSalUnPrc_Prime = unitPriceCalcRet.StdUnitPrice;           // 基準単価
                                    row.SalesUnPrcTaxExcFl_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;    // 売単価(税抜)
                                    row.SalesUnPrcTaxIncFl_Prime = unitPriceCalcRet.UnitPriceTaxIncFl;    // 売単価(税込)
                                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                                    {
                                        // 基準価格×売価率
                                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                            row.SalesRate = unitPriceCalcRet.RateVal;               // 売価率
                                            break;
                                        // 原価UP率
                                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                            row.SalesRate = unitPriceCalcRet.RateVal;               // 原価UP率
                                            break;
                                        // 粗利確保率
                                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                            row.SalesRate = unitPriceCalcRet.RateVal;               // 粗利確保率
                                            break;
                                        // 単価直接指定
                                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                            break;
                                    }
                                    row.FracProcUnitSalUnPrc_Prime = unitPriceCalcRet.UnPrcFracProcUnit;  // 端数処理単位
                                    row.FracProcSalUnPrc_Prime = unitPriceCalcRet.UnPrcFracProcDiv;       // 端数処理区分
                                    row.BfSalesUnitPrice_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;      // 変更前売価
                                }
                                break;
                            }
                        // 定価
                        case UnitPriceCalculation.ctUnitPriceKind_ListPrice:
                            {
                                if (setListPrice)
                                {
                                    row.RateSectPriceUnPrc_Prime = unitPriceCalcRet.SectionCode;          // 掛率設定拠点
                                    row.RateDivLPrice_Prime = unitPriceCalcRet.RateSettingDivide;         // 掛率設定区分
                                    row.UnPrcCalcCdLPrice_Prime = unitPriceCalcRet.UnitPrcCalcDiv;        // 単価算出区分
                                    row.PriceCdLPrice_Prime = unitPriceCalcRet.PriceDiv;                  // 価格区分
                                    row.StdUnPrcLPrice_Prime = unitPriceCalcRet.StdUnitPrice;             // 基準単価
                                    row.ListPriceTaxExcFl_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)
                                    row.ListPriceTaxIncFl_Prime = unitPriceCalcRet.UnitPriceTaxIncFl;     // 定価(税込)
                                    row.ListPriceRate_Prime = unitPriceCalcRet.RateVal;                   // 定価率
                                    row.FracProcUnitLPrice_Prime = unitPriceCalcRet.UnPrcFracProcUnit;    // 端数処理単位
                                    row.FracProcLPrice_Prime = unitPriceCalcRet.UnPrcFracProcDiv;         // 端数処理区分
                                    row.BfListPrice_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;           // 変更前定価
                                    row.RateBLGoodsCode_Prime = row.BLGoodsCode;                          // BL商品コード(掛率)
                                    row.RateBLGoodsName_Prime = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                                    row.OpenPriceDiv_Prime = unitPriceCalcRet.OpenPriceDiv;               // オープン価格区分

                                    //--------------------------------------------
                                    // 総額表示しない
                                    //--------------------------------------------
                                    if (this._salesSlip.TotalAmountDispWayCd == 0)
                                    {
                                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        {
                                            case CalculateTax.TaxationCode.TaxExc:
                                                row.ListPriceDisplay_Prime = row.ListPriceTaxExcFl_Prime;
                                                break;
                                            case CalculateTax.TaxationCode.TaxInc:
                                                row.ListPriceDisplay_Prime = row.ListPriceTaxIncFl_Prime;
                                                break;
                                            case CalculateTax.TaxationCode.TaxNone:
                                                row.ListPriceDisplay_Prime = row.ListPriceTaxExcFl_Prime;
                                                break;
                                        }
                                    }
                                    //--------------------------------------------
                                    // 総額表示する
                                    //--------------------------------------------
                                    else
                                    {
                                        row.ListPriceDisplay_Prime = row.ListPriceTaxIncFl_Prime;
                                    }
                                }
                                break;
                            }
                        // 原価単価
                        case UnitPriceCalculation.ctUnitPriceKind_UnitCost:
                            {
                                if (setSalUnCst)
                                {
                                    row.RateSectCstUnPrc_Prime = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                    row.RateDivUnCst_Prime = unitPriceCalcRet.RateSettingDivide;          // 掛率設定区分
                                    row.UnPrcCalcCdUnCst_Prime = unitPriceCalcRet.UnitPrcCalcDiv;         // 単価算出区分
                                    row.PriceCdUnCst_Prime = unitPriceCalcRet.PriceDiv;                   // 価格区分
                                    row.StdUnPrcUnCst_Prime = unitPriceCalcRet.StdUnitPrice;              // 基準単価
                                    //row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // 原単価(税抜)
                                    //row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // 原単価(税込)
                                    row.CostRate_Prime = unitPriceCalcRet.RateVal;                        // 原価率
                                    row.FracProcUnitUnCst_Prime = unitPriceCalcRet.UnPrcFracProcUnit;     // 端数処理単位
                                    row.FracProcUnCst_Prime = unitPriceCalcRet.UnPrcFracProcDiv;          // 端数処理区分
                                    row.BfUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;            // 変更前原価

                                    //--------------------------------------------
                                    // 総額表示しない
                                    //--------------------------------------------
                                    if (this._salesSlip.TotalAmountDispWayCd == 0)
                                    {
                                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        {
                                            case CalculateTax.TaxationCode.TaxExc:
                                                row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxInc:
                                                row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxIncFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxNone:
                                                row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;
                                                break;
                                        }
                                    }
                                    //--------------------------------------------
                                    // 総額表示する
                                    //--------------------------------------------
                                    else
                                    {
                                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        {
                                            case CalculateTax.TaxationCode.TaxExc:
                                                row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxInc:
                                                row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxIncFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxNone:
                                                row.SalesUnitCost_Prime = unitPriceCalcRet.UnitPriceTaxExcFl;
                                                break;
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }
        }
        // ------------DEL END wangf 2012/04/06 FOR Redmine#29227---------<<<<<*/

        /// <summary>
        /// 単価算出結果リストより、優良データ行オブジェクトに単価情報を設定します。
        /// </summary>
        /// <param name="row">優良データ行オブジェクト</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="isCheckSupplierCd">True:仕入先をチェックする</param>
        /// <param name="setSalUnPrc">True:売上単価の算出結果をセットする</param>
        /// <param name="setListPrice">True:定価の算出結果をセットする</param>
        /// <param name="setSalUnCst">True:原価単価の算出結果をセットする</param>
        private void PrimeInfoRowPriceInfoSettingFromUnitPriceCalcRetList(EstimateInputDataSet.PrimeInfoRow row, List<UnitPriceCalcRet> unitPriceCalcRetList, bool isCheckSupplierCd, bool setSalUnPrc, bool setListPrice, bool setSalUnCst)
        {
            if (( unitPriceCalcRetList == null ) || ( unitPriceCalcRetList.Count == 0 )) return;
            if (( string.IsNullOrEmpty(row.GoodsNo) ) || ( row.GoodsMakerCd == 0 )) return;


            #region セット判定用に使用するキー
            const string ctSetSalUnPrc = "SetSalUnPrc";
            const string ctSetListPrice = "SetListPrice";
            const string ctSetSalUnCst = "SetSalUnCst";

            #endregion

            Dictionary<string, bool> setList = new Dictionary<string, bool>();
            if (setSalUnPrc) setList.Add(ctSetSalUnPrc, false);
            if (setListPrice) setList.Add(ctSetListPrice, false);
            if (setSalUnCst) setList.Add(ctSetSalUnCst, false);

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (( unitPriceCalcRet.GoodsNo == row.GoodsNo ) && ( unitPriceCalcRet.GoodsMakerCd == row.GoodsMakerCd ) &&
                    ( ( !isCheckSupplierCd ) || ( ( isCheckSupplierCd ) && ( unitPriceCalcRet.SupplierCd == row.SupplierCd ) ) ))
                {
                    switch (unitPriceCalcRet.UnitPriceKind)
                    {
                        #region 売上単価
                        case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice:
                            {
                                if (setSalUnPrc)
                                {
                                    row.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                    row.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;       // 掛率設定区分
                                    row.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;      // 単価算出区分
                                    row.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;                // 価格区分
                                    row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // 基準単価
                                    row.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // 売単価(税抜)
                                    row.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;    // 売単価(税込)
                                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                                    {
                                        // 基準価格×売価率
                                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                            row.SalesRate = unitPriceCalcRet.RateVal;               // 売価率
                                            break;
                                        // 原価UP率
                                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                            row.SalesRate = unitPriceCalcRet.RateVal;               // 原価UP率
                                            break;
                                        // 粗利確保率
                                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                            row.SalesRate = unitPriceCalcRet.RateVal;               // 粗利確保率
                                            break;
                                        // 単価直接指定
                                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                            break;
                                    }
                                    row.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;  // 端数処理単位
                                    row.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;       // 端数処理区分
                                    row.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;      // 変更前売価

                                    row.SalesUnPrcChngCd = ( row.SalesUnPrcTaxExcFl == row.BfSalesUnitPrice ) ? 0 : 1;

                                    if (setList.ContainsKey(ctSetSalUnPrc)) setList[ctSetSalUnPrc] = true;
                                }
                                break;
                            }
                        #endregion

                        #region 定価
                        case UnitPriceCalculation.ctUnitPriceKind_ListPrice:
                            {
                                if (setListPrice)
                                {
                                    row.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;          // 掛率設定拠点
                                    row.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;         // 掛率設定区分
                                    row.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;        // 単価算出区分
                                    row.PriceCdLPrice = unitPriceCalcRet.PriceDiv;                  // 価格区分
                                    row.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;             // 基準単価
                                    row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)
                                    row.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;     // 定価(税込)
                                    row.ListPriceRate = unitPriceCalcRet.RateVal;                   // 定価率
                                    row.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;    // 端数処理単位
                                    row.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;         // 端数処理区分
                                    row.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;           // 変更前定価
                                    row.RateBLGoodsCode = row.BLGoodsCode;                          // BL商品コード(掛率)
                                    row.RateBLGoodsName = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                                    row.OpenPriceDiv = unitPriceCalcRet.OpenPriceDiv;               // オープン価格区分

                                    // 転嫁方式：非課税
                                    if (this._salesSlip.ConsTaxLayMethod == 9)
                                    {
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                    }
                                    //--------------------------------------------
                                    // 総額表示しない
                                    //--------------------------------------------
                                    else if (this._salesSlip.TotalAmountDispWayCd == 0)
                                    {
                                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                        {
                                            case CalculateTax.TaxationCode.TaxExc:
                                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxInc:
                                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                                break;
                                            case CalculateTax.TaxationCode.TaxNone:
                                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                                break;
                                        }
                                    }
                                    //--------------------------------------------
                                    // 総額表示する
                                    //--------------------------------------------
                                    else
                                    {
                                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                    }

                                    row.ListPriceChngCd = ( row.ListPriceTaxExcFl == row.BfListPrice ) ? 0 : 1;

                                    if (setList.ContainsKey(ctSetListPrice)) setList[ctSetListPrice] = true;

                                }
                                break;
                            }
                        #endregion

                        #region 原価単価
                        case UnitPriceCalculation.ctUnitPriceKind_UnitCost:
                            {
                                if (setSalUnCst)
                                {
                                    row.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                                    row.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;          // 掛率設定区分
                                    row.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;         // 単価算出区分
                                    row.PriceCdUnCst = unitPriceCalcRet.PriceDiv;                   // 価格区分
                                    row.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;              // 基準単価
                                    //row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // 原単価(税込)
                                    row.CostRate = unitPriceCalcRet.RateVal;                        // 原価率
                                    row.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;     // 端数処理単位
                                    row.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;          // 端数処理区分
                                    row.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;            // 変更前原価


                                    row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                    ////--------------------------------------------
                                    //// 総額表示しない
                                    ////--------------------------------------------
                                    //if (this._salesSlip.TotalAmountDispWayCd == 0)
                                    //{
                                    //    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                    //    {
                                    //        case CalculateTax.TaxationCode.TaxExc:
                                    //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                    //            break;
                                    //        case CalculateTax.TaxationCode.TaxInc:
                                    //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;
                                    //            break;
                                    //        case CalculateTax.TaxationCode.TaxNone:
                                    //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                    //            break;
                                    //    }
                                    //}
                                    ////--------------------------------------------
                                    //// 総額表示する
                                    ////--------------------------------------------
                                    //else
                                    //{
                                    //    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                    //    {
                                    //        case CalculateTax.TaxationCode.TaxExc:
                                    //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                    //            break;
                                    //        case CalculateTax.TaxationCode.TaxInc:
                                    //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;
                                    //            break;
                                    //        case CalculateTax.TaxationCode.TaxNone:
                                    //            row.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                                    //            break;
                                    //    }
                                    //}

                                    row.SalesUnitCostChngDiv = ( row.SalesUnitCost == row.BfUnitCost ) ? 0 : 1;

                                    if (setList.ContainsKey(ctSetSalUnCst)) setList[ctSetSalUnCst] = true;
                                }
                                break;
                            }
                        #endregion
                    }

                    if (!setList.ContainsValue(false)) break;
                }
            }
        }

        
        /// <summary>
        /// 単価算出モジュールより、商品リストから定価を算出します。
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalculateSalesRelevanceUnitPrice( List<GoodsUnitData> goodsUnitDataList )
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();
            if (_supplierAcs == null) _supplierAcs = new SupplierAcs();
            
            // 仕入単価端数処理コードディクショナリ
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();
            // 仕入消費税端数処理コードディクショナリ
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();
            // 売上単価端数処理コード(得意先マスタより取得)
            int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            // 売上消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 仕入単価端数処理コード
            int stockUnPrcFrcProcCd = 0;
            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = 0;
            // ------------ADD START wangf 2012/04/06 FOR Redmine#29227--------->>>>
            // 得意先掛率グループコード
            int custRateGrpCode = 0;
            // ------------ADD END wangf 2012/04/06 FOR Redmine#29227---------<<<<<

            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "CalculateSalesRelevanceUnitPrice", "単価算出パラメータ作成 START");

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                if (( goodsUnitData.GoodsMakerCd != 0 ) && ( !string.IsNullOrEmpty(goodsUnitData.GoodsNo) ))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
                    // ------------ADD START wangf 2012/04/06 FOR Redmine#29227--------->>>>
                    // 得意先掛率グループコードを取得する
                    GetCustRateGrp(_custRateGroupList, this._salesSlip.CustomerCode, goodsUnitData.GoodsMakerCd, out custRateGrpCode);
                    // ------------ADD END wangf 2012/04/06 FOR Redmine#29227---------<<<<

                    unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;             // 拠点コード
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // メーカーコード
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // 商品番号
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // 商品掛率ランク
                    unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // 商品掛率グループコード
                    unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                     // BLグループコード
                    unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BLコード
                    unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                 // 得意先コード
                    //unitPriceCalcParam.CustRateGrpCode = this._salesSlip.CustRateGrpCode;           // 得意先掛率グループコード // DEL wangf 2012/04/06 FOR Redmine#29227
                    unitPriceCalcParam.CustRateGrpCode = custRateGrpCode;                           // 得意先掛率グループコード // ADD wangf 2012/04/06 FOR Redmine#29227
                    unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                       // 仕入先コード
                    unitPriceCalcParam.CountFl = 0;                                                 // 数量
                    unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate;                  // 価格適用日
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // 課税区分
                    unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // 税率
                    unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;         // 消費税転嫁方式
                    unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // 総額表示方法区分

                    unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // 売上単価端数処理コード

                    // 仕入単価端数処理コード(ディクショナリか仕入先マスタから取得)
                    if (stockUnPrcFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                    {
                        stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[goodsUnitData.SupplierCd];
                    }
                    else
                    {
                        stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                        stockUnPrcFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockUnPrcFrcProcCd);
                    }

                    unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // 仕入単価端数処理コード


                    // 0:(税込金額×掛率)
                    // 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)
                    unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;	// 総額表示掛率適用区分

                    unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;                 // 売上消費税端数処理コード
                    // 仕入消費税端数処理コード(ディクショナリか仕入先マスタから取得)
                    if (stockCnsTaxFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                    {
                        stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[goodsUnitData.SupplierCd];
                    }
                    else
                    {
                        stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        stockCnsTaxFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockCnsTaxFrcProcCd);
                    }
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }
            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "CalculateSalesRelevanceUnitPrice", "単価算出パラメータ作成 END");

            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "CalculateSalesRelevanceUnitPrice", "単価算出 START");
            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "CalculateSalesRelevanceUnitPrice", "単価算出 END");

            return unitPriceCalcRetList;
        }

        /// <summary>
        /// 単価算出パラメータ生成
        /// </summary>
        /// <param name="targetData">対象データ(Allはnullを返します)</param>
        /// <param name="row">見積明細行</param>
        /// <returns>単価算出パラメータ</returns>
        /// <br>Update note: 2011/02/14 yangmj</br>
        /// <br>Date       : 得意先掛率グループ取得処理の修正</br>
        private UnitPriceCalcParam CreateUnitPriceCalcParam(TargetData targetData, EstimateInputDataSet.EstimateDetailRow row)
        {
            UnitPriceCalcParam unitPriceCalcParam = null;
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();
            if (_supplierAcs == null) _supplierAcs = new SupplierAcs();
            
            switch (targetData)
            {
                #region 純正部品
                case TargetData.PureParts:
                    {
                        unitPriceCalcParam = new UnitPriceCalcParam();
                        unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;                 // 拠点コード
                        unitPriceCalcParam.GoodsMakerCd = row.GoodsMakerCd;                                 // 商品メーカーコード
                        unitPriceCalcParam.GoodsNo = row.GoodsNo;                                           // 商品番号
                        unitPriceCalcParam.GoodsRateRank = row.GoodsRateRank;                               // 商品掛率ランク
                        unitPriceCalcParam.GoodsRateGrpCode = row.RateGoodsRateGrpCd;                       // 商品掛率グループコード
                        unitPriceCalcParam.BLGroupCode = row.RateBLGroupCode;                               // BLグループコード
                        unitPriceCalcParam.BLGoodsCode = row.RateBLGoodsCode;                               // BL商品コード
                        unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                     // 得意先コード
                        // --- UPD 2011/02/14 ---------->>>>>
                        //unitPriceCalcParam.CustRateGrpCode = this._salesSlip.CustRateGrpCode;               // 得意先掛率グループコード
                        unitPriceCalcParam.CustRateGrpCode = row.CustRateGrpCode;                           // 得意先掛率グループコード
                        // --- UPD 2011/02/14 ----------<<<<<
                        unitPriceCalcParam.SupplierCd = row.SupplierCd;                                     // 仕入先コード
                        unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate;                      // 価格適用日
                        unitPriceCalcParam.CountFl = row.ShipmentCnt;                                       // 数量
                        unitPriceCalcParam.TaxationDivCd = row.TaxationDivCd;                               // 課税区分
                        unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                           // 税率
                        unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;     // 総額表示方法区分
                        unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;        // 総額表示掛率適用区分
                        unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;             // 消費税転嫁方式

                        if (this._salesSlip.CustomerCode != 0)
                        {
                            // 売上消費税端数処理コード
                            unitPriceCalcParam.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
                            // 売上単価端数処理コード
                            unitPriceCalcParam.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                        }

                        if (row.SupplierCd != 0)
                        {
                            // 仕入単価端数処理コード
                            unitPriceCalcParam.StockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            // 仕入消費税端数処理コード
                            unitPriceCalcParam.StockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        }
                        break;
                    }
                #endregion

                #region 優良部品
                case TargetData.PrimeParts:
                    {
                        unitPriceCalcParam = new UnitPriceCalcParam();
                        unitPriceCalcParam.SectionCode = this._salesSlip.SectionCode;                       // 拠点コード
                        unitPriceCalcParam.GoodsMakerCd = row.GoodsMakerCd_Prime;                           // 商品メーカーコード
                        unitPriceCalcParam.GoodsNo = row.GoodsNo_Prime;                                     // 商品番号
                        unitPriceCalcParam.GoodsRateRank = row.GoodsRateRank_Prime;                         // 商品掛率ランク
                        unitPriceCalcParam.GoodsRateGrpCode = row.RateGoodsRateGrpCd_Prime;                 // 商品掛率グループコード
                        unitPriceCalcParam.BLGroupCode = row.RateBLGroupCode_Prime;                         // BLグループコード
                        unitPriceCalcParam.BLGoodsCode = row.RateBLGoodsCode_Prime;                         // BL商品コード
                        unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                     // 得意先コード
                        // --- UPD 2011/02/14 ---------->>>>>
                        //unitPriceCalcParam.CustRateGrpCode = this._salesSlip.CustRateGrpCode;               // 得意先掛率グループコード
                        unitPriceCalcParam.CustRateGrpCode = row.CustRateGrpCode_Prime;                     // 得意先掛率グループコード
                        // --- UPD 2011/02/14 ----------<<<<<
                        unitPriceCalcParam.SupplierCd = row.SupplierCd_Prime;                               // 仕入先コード
                        unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate;                      // 価格適用日
                        unitPriceCalcParam.CountFl = row.ShipmentCnt_Prime;                                 // 数量
                        unitPriceCalcParam.TaxationDivCd = row.TaxationDivCd_Prime;                         // 課税区分
                        unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                           // 税率
                        unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;     // 総額表示方法区分
                        unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;        // 総額表示掛率適用区分
                        unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;             // 消費税転嫁方式

                        if (this._salesSlip.CustomerCode != 0)
                        {
                            // 売上消費税端数処理コード
                            unitPriceCalcParam.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
                            // 売上単価端数処理コード
                            unitPriceCalcParam.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                        }

                        if (row.SupplierCd_Prime != 0)
                        {
                            // 仕入単価端数処理コード
                            unitPriceCalcParam.StockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd_Prime, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            // 仕入消費税端数処理コード
                            unitPriceCalcParam.StockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd_Prime, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        }
                        break;
                    }
                #endregion
            }

            return unitPriceCalcParam;
        }


        /// <summary>
        /// 単価算出パラメータ生成
        /// </summary>
        /// <param name="row">優良情報行</param>
        /// <returns>単価算出パラメータ</returns>
        private UnitPriceCalcParam CreateUnitPriceCalcParam(EstimateInputDataSet.PrimeInfoRow row)
        {
            UnitPriceCalcParam unitPriceCalcParam = null;
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();
            if (_supplierAcs == null) _supplierAcs = new SupplierAcs();
            
            unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;                 // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = row.GoodsMakerCd;                                 // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = row.GoodsNo;                                           // 商品番号
            unitPriceCalcParam.GoodsRateRank = row.GoodsRateRank;                               // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = row.RateGoodsRateGrpCd;                       // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = row.RateBLGroupCode;                               // BLグループコード
            unitPriceCalcParam.BLGoodsCode = row.RateBLGoodsCode;                               // BL商品コード
            unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                     // 得意先コード
            //unitPriceCalcParam.CustRateGrpCode = this._salesSlip.CustRateGrpCode;               // 得意先掛率グループコード // DEL wangf 2012/04/27 FOR Redmine#29640
            unitPriceCalcParam.CustRateGrpCode = row.CustRateGrpCode;                           // 得意先掛率グループコード // ADD wangf 2012/04/27 FOR Redmine#29640
            unitPriceCalcParam.SupplierCd = row.SupplierCd;                                     // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate;                      // 価格適用日
            unitPriceCalcParam.CountFl = row.ShipmentCnt;                                       // 数量
            unitPriceCalcParam.TaxationDivCd = row.TaxationDivCd;                               // 課税区分
            unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                           // 税率
            unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;     // 総額表示方法区分
            unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;        // 総額表示掛率適用区分
            unitPriceCalcParam.ConsTaxLayMethod= this._salesSlip.ConsTaxLayMethod;              // 消費税転嫁方式

            if (this._salesSlip.CustomerCode != 0)
            {
                // 売上消費税端数処理コード
                unitPriceCalcParam.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
                // 売上単価端数処理コード
                unitPriceCalcParam.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            }

            if (row.SupplierCd != 0)
            {
                // 仕入単価端数処理コード
                unitPriceCalcParam.StockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                // 仕入消費税端数処理コード
                unitPriceCalcParam.StockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            }
            return unitPriceCalcParam;
        }


		/// <summary>
		/// 見積明細行オブジェクトのコピーを行います。
		/// </summary>
        /// <param name="sourceRow">コピー元見積明細行オブジェクト</param>
        /// <param name="targetRow">コピー先見積明細行オブジェクト</param>
		private void CopyEstimateDetailRow( EstimateInputDataSet.EstimateDetailRow sourceRow, EstimateInputDataSet.EstimateDetailRow targetRow )
		{
			if ((sourceRow == null) || (targetRow == null)) return;

			#region ●項目セット

            //targetRow.CreateDateTime = sourceRow.CreateDateTime;                                        // 作成日時
            //targetRow.UpdateDateTime = sourceRow.UpdateDateTime;                                        // 更新日時
            //targetRow.EnterpriseCode = sourceRow.EnterpriseCode;                                        // 企業コード
            //targetRow.FileHeaderGuid = sourceRow.FileHeaderGuid;                                        // GUID
            //targetRow.UpdEmployeeCode = sourceRow.UpdEmployeeCode;                                      // 更新従業員コード
            //targetRow.UpdAssemblyId1 = sourceRow.UpdAssemblyId1;                                        // 更新アセンブリID1
            //targetRow.UpdAssemblyId2 = sourceRow.UpdAssemblyId2;                                        // 更新アセンブリID2
            //targetRow.LogicalDeleteCode = sourceRow.LogicalDeleteCode;                                  // 論理削除区分
            targetRow.AcceptAnOrderNo = sourceRow.AcceptAnOrderNo;                                      // 受注番号
            targetRow.AcptAnOdrStatus = sourceRow.AcptAnOdrStatus;                                      // 受注ステータス
            targetRow.SalesSlipNum = sourceRow.SalesSlipNum;                                            // 売上伝票番号
            //targetRow.SalesRowNo = sourceRow.SalesRowNo;                                                // 売上行番号
            //targetRow.SalesRowDerivNo = sourceRow.SalesRowDerivNo;                                      // 売上行番号枝番
            //targetRow.SectionCode = sourceRow.SectionCode;                                              // 拠点コード
            //targetRow.SubSectionCode = sourceRow.SubSectionCode;                                        // 部門コード
            //targetRow.SalesDate = sourceRow.SalesDate;                                                  // 売上日付
            targetRow.CommonSeqNo = sourceRow.CommonSeqNo;                                              // 共通通番
            targetRow.SalesSlipDtlNum = sourceRow.SalesSlipDtlNum;                                      // 売上明細通番
            targetRow.AcptAnOdrStatusSrc = sourceRow.AcptAnOdrStatusSrc;                                // 受注ステータス（元）
            targetRow.SalesSlipDtlNumSrc = sourceRow.SalesSlipDtlNumSrc;                                // 売上明細通番（元）
            targetRow.SupplierFormalSync = sourceRow.SupplierFormalSync;                                // 仕入形式（同時）
            targetRow.StockSlipDtlNumSync = sourceRow.StockSlipDtlNumSync;                              // 仕入明細通番（同時）
            //targetRow.SalesSlipCdDtl = sourceRow.SalesSlipCdDtl;                                        // 売上伝票区分（明細）
            //targetRow.DeliGdsCmpltDueDate = sourceRow.DeliGdsCmpltDueDate;                              // 納品完了予定日
            targetRow.GoodsKindCode = sourceRow.GoodsKindCode;                                          // 商品属性
            targetRow.GoodsSearchDivCd = sourceRow.GoodsSearchDivCd;                                    // 商品検索区分
            targetRow.GoodsMakerCd = sourceRow.GoodsMakerCd;                                            // 商品メーカーコード
            targetRow.MakerName = sourceRow.MakerName;                                                  // メーカー名称
            targetRow.MakerKanaName = sourceRow.MakerKanaName;                                          // メーカーカナ名称
            targetRow.GoodsNo = sourceRow.GoodsNo;                                                      // 商品番号
            targetRow.GoodsName = sourceRow.GoodsName;                                                  // 商品名称
            targetRow.GoodsNameKana = sourceRow.GoodsNameKana;                                          // 商品名称カナ
            targetRow.GoodsLGroup = sourceRow.GoodsLGroup;                                              // 商品大分類コード
            targetRow.GoodsLGroupName = sourceRow.GoodsLGroupName;                                      // 商品大分類名称
            targetRow.GoodsMGroup = sourceRow.GoodsMGroup;                                              // 商品中分類コード
            targetRow.GoodsMGroupName = sourceRow.GoodsMGroupName;                                      // 商品中分類名称
            targetRow.BLGroupCode = sourceRow.BLGroupCode;                                              // BLグループコード
            targetRow.BLGroupName = sourceRow.BLGroupName;                                              // BLグループコード名称
            targetRow.BLGoodsCode = sourceRow.BLGoodsCode;                                              // BL商品コード
            targetRow.BLGoodsFullName = sourceRow.BLGoodsFullName;                                      // BL商品コード名称（全角）
            targetRow.EnterpriseGanreCode = sourceRow.EnterpriseGanreCode;                              // 自社分類コード
            targetRow.EnterpriseGanreName = sourceRow.EnterpriseGanreName;                              // 自社分類名称
            targetRow.WarehouseCode = sourceRow.WarehouseCode;                                          // 倉庫コード
            targetRow.WarehouseName = sourceRow.WarehouseName;                                          // 倉庫名称
            targetRow.WarehouseShelfNo = sourceRow.WarehouseShelfNo;                                    // 倉庫棚番
            targetRow.SalesOrderDivCd = sourceRow.SalesOrderDivCd;                                      // 売上在庫取寄せ区分
            targetRow.OpenPriceDiv = sourceRow.OpenPriceDiv;                                            // オープン価格区分
            targetRow.GoodsRateRank = sourceRow.GoodsRateRank;                                          // 商品掛率ランク
            targetRow.CustRateGrpCode = sourceRow.CustRateGrpCode;                                      // 得意先掛率グループコード
            targetRow.ListPriceRate = sourceRow.ListPriceRate;                                          // 定価率
            targetRow.RateSectPriceUnPrc = sourceRow.RateSectPriceUnPrc;                                // 掛率設定拠点（定価）
            targetRow.RateDivLPrice = sourceRow.RateDivLPrice;                                          // 掛率設定区分（定価）
            targetRow.UnPrcCalcCdLPrice = sourceRow.UnPrcCalcCdLPrice;                                  // 単価算出区分（定価）
            targetRow.PriceCdLPrice = sourceRow.PriceCdLPrice;                                          // 価格区分（定価）
            targetRow.StdUnPrcLPrice = sourceRow.StdUnPrcLPrice;                                        // 基準単価（定価）
            targetRow.FracProcUnitLPrice = sourceRow.FracProcUnitLPrice;                                // 端数処理単位（定価）
            targetRow.FracProcLPrice = sourceRow.FracProcLPrice;                                        // 端数処理（定価）
            targetRow.ListPriceTaxIncFl = sourceRow.ListPriceTaxIncFl;                                  // 定価（税込，浮動）
            targetRow.ListPriceTaxExcFl = sourceRow.ListPriceTaxExcFl;                                  // 定価（税抜，浮動）
            targetRow.ListPriceChngCd = sourceRow.ListPriceChngCd;                                      // 定価変更区分
            targetRow.SalesRate = sourceRow.SalesRate;                                                  // 売価率
            targetRow.RateSectSalUnPrc = sourceRow.RateSectSalUnPrc;                                    // 掛率設定拠点（売上単価）
            targetRow.RateDivSalUnPrc = sourceRow.RateDivSalUnPrc;                                      // 掛率設定区分（売上単価）
            targetRow.UnPrcCalcCdSalUnPrc = sourceRow.UnPrcCalcCdSalUnPrc;                              // 単価算出区分（売上単価）
            targetRow.PriceCdSalUnPrc = sourceRow.PriceCdSalUnPrc;                                      // 価格区分（売上単価）
            targetRow.StdUnPrcSalUnPrc = sourceRow.StdUnPrcSalUnPrc;                                    // 基準単価（売上単価）
            targetRow.FracProcUnitSalUnPrc = sourceRow.FracProcUnitSalUnPrc;                            // 端数処理単位（売上単価）
            targetRow.FracProcSalUnPrc = sourceRow.FracProcSalUnPrc;                                    // 端数処理（売上単価）
            targetRow.SalesUnPrcTaxIncFl = sourceRow.SalesUnPrcTaxIncFl;                                // 売上単価（税込，浮動）
            targetRow.SalesUnPrcTaxExcFl = sourceRow.SalesUnPrcTaxExcFl;                                // 売上単価（税抜，浮動）
            targetRow.SalesUnPrcChngCd = sourceRow.SalesUnPrcChngCd;                                    // 売上単価変更区分
            targetRow.CostRate = sourceRow.CostRate;                                                    // 原価率
            targetRow.RateSectCstUnPrc = sourceRow.RateSectCstUnPrc;                                    // 掛率設定拠点（原価単価）
            targetRow.RateDivUnCst = sourceRow.RateDivUnCst;                                            // 掛率設定区分（原価単価）
            targetRow.UnPrcCalcCdUnCst = sourceRow.UnPrcCalcCdUnCst;                                    // 単価算出区分（原価単価）
            targetRow.PriceCdUnCst = sourceRow.PriceCdUnCst;                                            // 価格区分（原価単価）
            targetRow.StdUnPrcUnCst = sourceRow.StdUnPrcUnCst;                                          // 基準単価（原価単価）
            targetRow.FracProcUnitUnCst = sourceRow.FracProcUnitUnCst;                                  // 端数処理単位（原価単価）
            targetRow.FracProcUnCst = sourceRow.FracProcUnCst;                                          // 端数処理（原価単価）
            targetRow.SalesUnitCost = sourceRow.SalesUnitCost;                                          // 原価単価
            targetRow.SalesUnitCostChngDiv = sourceRow.SalesUnitCostChngDiv;                            // 原価単価変更区分
            targetRow.RateBLGoodsCode = sourceRow.RateBLGoodsCode;                                      // BL商品コード（掛率）
            targetRow.RateBLGoodsName = sourceRow.RateBLGoodsName;                                      // BL商品コード名称（掛率）
            targetRow.RateGoodsRateGrpCd = sourceRow.RateGoodsRateGrpCd;                                // 商品掛率グループコード（掛率）
            targetRow.RateGoodsRateGrpNm = sourceRow.RateGoodsRateGrpNm;                                // 商品掛率グループ名称（掛率）
            targetRow.RateBLGroupCode = sourceRow.RateBLGroupCode;                                      // BLグループコード（掛率）
            targetRow.RateBLGroupName = sourceRow.RateBLGroupName;                                      // BLグループ名称（掛率）
            targetRow.PrtBLGoodsCode = sourceRow.PrtBLGoodsCode;                                        // BL商品コード（印刷）
            targetRow.PrtBLGoodsName = sourceRow.PrtBLGoodsName;                                        // BL商品コード名称（印刷）
            targetRow.SalesCode = sourceRow.SalesCode;                                                  // 販売区分コード
            targetRow.SalesCdNm = sourceRow.SalesCdNm;                                                  // 販売区分名称
            targetRow.WorkManHour = sourceRow.WorkManHour;                                              // 作業工数
            targetRow.ShipmentCnt = sourceRow.ShipmentCnt;                                              // 出荷数
            targetRow.AcceptAnOrderCnt = sourceRow.AcceptAnOrderCnt;                                    // 受注数量
            targetRow.AcptAnOdrAdjustCnt = sourceRow.AcptAnOdrAdjustCnt;                                // 受注調整数
            targetRow.AcptAnOdrRemainCnt = sourceRow.AcptAnOdrRemainCnt;                                // 受注残数
            targetRow.RemainCntUpdDate = sourceRow.RemainCntUpdDate;                                    // 残数更新日
            targetRow.SalesMoneyTaxInc = sourceRow.SalesMoneyTaxInc;                                    // 売上金額（税込み）
            targetRow.SalesMoneyTaxExc = sourceRow.SalesMoneyTaxExc;                                    // 売上金額（税抜き）
            targetRow.Cost = sourceRow.Cost;                                                            // 原価
            targetRow.GrsProfitChkDiv = sourceRow.GrsProfitChkDiv;                                      // 粗利チェック区分
            targetRow.SalesGoodsCd = sourceRow.SalesGoodsCd;                                            // 売上商品区分
            targetRow.SalesPriceConsTax = sourceRow.SalesPriceConsTax;                                  // 売上金額消費税額
            targetRow.TaxationDivCd = sourceRow.TaxationDivCd;                                          // 課税区分
            targetRow.PartySlipNumDtl = sourceRow.PartySlipNumDtl;                                      // 相手先伝票番号（明細）
            targetRow.DtlNote = sourceRow.DtlNote;                                                      // 明細備考
            targetRow.SupplierCd = sourceRow.SupplierCd;                                                // 仕入先コード
            targetRow.SupplierSnm = sourceRow.SupplierSnm;                                              // 仕入先略称
            targetRow.OrderNumber = sourceRow.OrderNumber;                                              // 発注番号
            targetRow.WayToOrder = sourceRow.WayToOrder;                                                // 注文方法
            targetRow.SlipMemo1 = sourceRow.SlipMemo1;                                                  // 伝票メモ１
            targetRow.SlipMemo2 = sourceRow.SlipMemo2;                                                  // 伝票メモ２
            targetRow.SlipMemo3 = sourceRow.SlipMemo3;                                                  // 伝票メモ３
            targetRow.InsideMemo1 = sourceRow.InsideMemo1;                                              // 社内メモ１
            targetRow.InsideMemo2 = sourceRow.InsideMemo2;                                              // 社内メモ２
            targetRow.InsideMemo3 = sourceRow.InsideMemo3;                                              // 社内メモ３
            targetRow.BfListPrice = sourceRow.BfListPrice;                                              // 変更前定価
            targetRow.BfSalesUnitPrice = sourceRow.BfSalesUnitPrice;                                    // 変更前売価
            targetRow.BfUnitCost = sourceRow.BfUnitCost;                                                // 変更前原価
            targetRow.CmpltSalesRowNo = sourceRow.CmpltSalesRowNo;                                      // 一式明細番号
            targetRow.CmpltGoodsMakerCd = sourceRow.CmpltGoodsMakerCd;                                  // メーカーコード（一式）
            targetRow.CmpltMakerName = sourceRow.CmpltMakerName;                                        // メーカー名称（一式）
            targetRow.CmpltMakerKanaName = sourceRow.CmpltMakerKanaName;                                // メーカーカナ名称（一式）
            targetRow.CmpltGoodsName = sourceRow.CmpltGoodsName;                                        // 商品名称（一式）
            targetRow.CmpltShipmentCnt = sourceRow.CmpltShipmentCnt;                                    // 数量（一式）
            targetRow.CmpltSalesUnPrcFl = sourceRow.CmpltSalesUnPrcFl;                                  // 売上単価（一式）
            targetRow.CmpltSalesMoney = sourceRow.CmpltSalesMoney;                                      // 売上金額（一式）
            targetRow.CmpltSalesUnitCost = sourceRow.CmpltSalesUnitCost;                                // 原価単価（一式）
            targetRow.CmpltCost = sourceRow.CmpltCost;                                                  // 原価金額（一式）
            targetRow.CmpltPartySalSlNum = sourceRow.CmpltPartySalSlNum;                                // 相手先伝票番号（一式）
            targetRow.CmpltNote = sourceRow.CmpltNote;                                                  // 一式備考
            targetRow.PrtGoodsNo = sourceRow.PrtGoodsNo;                                                // 印刷用品番
            targetRow.PrtMakerCode = sourceRow.PrtMakerCode;                                            // 印刷用メーカーコード
            targetRow.PrtMakerName = sourceRow.PrtMakerName;                                            // 印刷用メーカー名称
            //targetRow.CreateDateTime_Prime = sourceRow.CreateDateTime_Prime;                            // 作成日時
            //targetRow.UpdateDateTime_Prime = sourceRow.UpdateDateTime_Prime;                            // 更新日時
            //targetRow.EnterpriseCode_Prime = sourceRow.EnterpriseCode_Prime;                            // 企業コード
            //targetRow.FileHeaderGuid_Prime = sourceRow.FileHeaderGuid_Prime;                            // GUID
            //targetRow.UpdEmployeeCode_Prime = sourceRow.UpdEmployeeCode_Prime;                          // 更新従業員コード
            //targetRow.UpdAssemblyId1_Prime = sourceRow.UpdAssemblyId1_Prime;                            // 更新アセンブリID1
            //targetRow.UpdAssemblyId2_Prime = sourceRow.UpdAssemblyId2_Prime;                            // 更新アセンブリID2
            //targetRow.LogicalDeleteCode_Prime = sourceRow.LogicalDeleteCode_Prime;                      // 論理削除区分
            //targetRow.AcceptAnOrderNo_Prime = sourceRow.AcceptAnOrderNo_Prime;                          // 受注番号
            //targetRow.AcptAnOdrStatus_Prime = sourceRow.AcptAnOdrStatus_Prime;                          // 受注ステータス
            //targetRow.SalesSlipNum_Prime = sourceRow.SalesSlipNum_Prime;                                // 売上伝票番号
            //targetRow.SalesRowNo_Prime = sourceRow.SalesRowNo_Prime;                                    // 売上行番号
            //targetRow.SalesRowDerivNo_Prime = sourceRow.SalesRowDerivNo_Prime;                          // 売上行番号枝番
            //targetRow.SectionCode_Prime = sourceRow.SectionCode_Prime;                                  // 拠点コード
            //targetRow.SubSectionCode_Prime = sourceRow.SubSectionCode_Prime;                            // 部門コード
            //targetRow.SalesDate_Prime = sourceRow.SalesDate_Prime;                                      // 売上日付
            targetRow.CommonSeqNo_Prime = sourceRow.CommonSeqNo_Prime;                                  // 共通通番
            targetRow.SalesSlipDtlNum_Prime = sourceRow.SalesSlipDtlNum_Prime;                          // 売上明細通番
            targetRow.AcptAnOdrStatusSrc_Prime = sourceRow.AcptAnOdrStatusSrc_Prime;                    // 受注ステータス（元）
            targetRow.SalesSlipDtlNumSrc_Prime = sourceRow.SalesSlipDtlNumSrc_Prime;                    // 売上明細通番（元）
            targetRow.SupplierFormalSync_Prime = sourceRow.SupplierFormalSync_Prime;                    // 仕入形式（同時）
            targetRow.StockSlipDtlNumSync_Prime = sourceRow.StockSlipDtlNumSync_Prime;                  // 仕入明細通番（同時）
            //targetRow.SalesSlipCdDtl_Prime = sourceRow.SalesSlipCdDtl_Prime;                            // 売上伝票区分（明細）
            //targetRow.DeliGdsCmpltDueDate_Prime = sourceRow.DeliGdsCmpltDueDate_Prime;                  // 納品完了予定日
            //targetRow.GoodsKindCode_Prime = sourceRow.GoodsKindCode_Prime;                              // 商品属性
            //targetRow.GoodsSearchDivCd_Prime = sourceRow.GoodsSearchDivCd_Prime;                        // 商品検索区分
            targetRow.GoodsMakerCd_Prime = sourceRow.GoodsMakerCd_Prime;                                // 商品メーカーコード
            targetRow.MakerName_Prime = sourceRow.MakerName_Prime;                                      // メーカー名称
            targetRow.MakerKanaName_Prime = sourceRow.MakerKanaName_Prime;                              // メーカーカナ名称
            targetRow.GoodsNo_Prime = sourceRow.GoodsNo_Prime;                                          // 商品番号
            targetRow.GoodsName_Prime = sourceRow.GoodsName_Prime;                                      // 商品名称
            targetRow.GoodsNameKana_Prime = sourceRow.GoodsNameKana_Prime;                              // 商品名称カナ
            targetRow.GoodsLGroup_Prime = sourceRow.GoodsLGroup_Prime;                                  // 商品大分類コード
            targetRow.GoodsLGroupName_Prime = sourceRow.GoodsLGroupName_Prime;                          // 商品大分類名称
            targetRow.GoodsMGroup_Prime = sourceRow.GoodsMGroup_Prime;                                  // 商品中分類コード
            targetRow.GoodsMGroupName_Prime = sourceRow.GoodsMGroupName_Prime;                          // 商品中分類名称
            targetRow.BLGroupCode_Prime = sourceRow.BLGroupCode_Prime;                                  // BLグループコード
            targetRow.BLGroupName_Prime = sourceRow.BLGroupName_Prime;                                  // BLグループコード名称
            targetRow.BLGoodsCode_Prime = sourceRow.BLGoodsCode_Prime;                                  // BL商品コード
            targetRow.BLGoodsFullName_Prime = sourceRow.BLGoodsFullName_Prime;                          // BL商品コード名称（全角）
            targetRow.EnterpriseGanreCode_Prime = sourceRow.EnterpriseGanreCode_Prime;                  // 自社分類コード
            targetRow.EnterpriseGanreName_Prime = sourceRow.EnterpriseGanreName_Prime;                  // 自社分類名称
            targetRow.WarehouseCode_Prime = sourceRow.WarehouseCode_Prime;                              // 倉庫コード
            targetRow.WarehouseName_Prime = sourceRow.WarehouseName_Prime;                              // 倉庫名称
            targetRow.WarehouseShelfNo_Prime = sourceRow.WarehouseShelfNo_Prime;                        // 倉庫棚番
            targetRow.SalesOrderDivCd_Prime = sourceRow.SalesOrderDivCd_Prime;                          // 売上在庫取寄せ区分
            targetRow.OpenPriceDiv_Prime = sourceRow.OpenPriceDiv_Prime;                                // オープン価格区分
            targetRow.GoodsRateRank_Prime = sourceRow.GoodsRateRank_Prime;                              // 商品掛率ランク
            targetRow.CustRateGrpCode_Prime = sourceRow.CustRateGrpCode_Prime;                          // 得意先掛率グループコード
            targetRow.ListPriceRate_Prime = sourceRow.ListPriceRate_Prime;                              // 定価率
            targetRow.RateSectPriceUnPrc_Prime = sourceRow.RateSectPriceUnPrc_Prime;                    // 掛率設定拠点（定価）
            targetRow.RateDivLPrice_Prime = sourceRow.RateDivLPrice_Prime;                              // 掛率設定区分（定価）
            targetRow.UnPrcCalcCdLPrice_Prime = sourceRow.UnPrcCalcCdLPrice_Prime;                      // 単価算出区分（定価）
            targetRow.PriceCdLPrice_Prime = sourceRow.PriceCdLPrice_Prime;                              // 価格区分（定価）
            targetRow.StdUnPrcLPrice_Prime = sourceRow.StdUnPrcLPrice_Prime;                            // 基準単価（定価）
            targetRow.FracProcUnitLPrice_Prime = sourceRow.FracProcUnitLPrice_Prime;                    // 端数処理単位（定価）
            targetRow.FracProcLPrice_Prime = sourceRow.FracProcLPrice_Prime;                            // 端数処理（定価）
            targetRow.ListPriceTaxIncFl_Prime = sourceRow.ListPriceTaxIncFl_Prime;                      // 定価（税込，浮動）
            targetRow.ListPriceTaxExcFl_Prime = sourceRow.ListPriceTaxExcFl_Prime;                      // 定価（税抜，浮動）
            targetRow.ListPriceChngCd_Prime = sourceRow.ListPriceChngCd_Prime;                          // 定価変更区分
            targetRow.SalesRate_Prime = sourceRow.SalesRate_Prime;                                      // 売価率
            targetRow.RateSectSalUnPrc_Prime = sourceRow.RateSectSalUnPrc_Prime;                        // 掛率設定拠点（売上単価）
            targetRow.RateDivSalUnPrc_Prime = sourceRow.RateDivSalUnPrc_Prime;                          // 掛率設定区分（売上単価）
            targetRow.UnPrcCalcCdSalUnPrc_Prime = sourceRow.UnPrcCalcCdSalUnPrc_Prime;                  // 単価算出区分（売上単価）
            targetRow.PriceCdSalUnPrc_Prime = sourceRow.PriceCdSalUnPrc_Prime;                          // 価格区分（売上単価）
            targetRow.StdUnPrcSalUnPrc_Prime = sourceRow.StdUnPrcSalUnPrc_Prime;                        // 基準単価（売上単価）
            targetRow.FracProcUnitSalUnPrc_Prime = sourceRow.FracProcUnitSalUnPrc_Prime;                // 端数処理単位（売上単価）
            targetRow.FracProcSalUnPrc_Prime = sourceRow.FracProcSalUnPrc_Prime;                        // 端数処理（売上単価）
            targetRow.SalesUnPrcTaxIncFl_Prime = sourceRow.SalesUnPrcTaxIncFl_Prime;                    // 売上単価（税込，浮動）
            targetRow.SalesUnPrcTaxExcFl_Prime = sourceRow.SalesUnPrcTaxExcFl_Prime;                    // 売上単価（税抜，浮動）
            targetRow.SalesUnPrcChngCd_Prime = sourceRow.SalesUnPrcChngCd_Prime;                        // 売上単価変更区分
            targetRow.CostRate_Prime = sourceRow.CostRate_Prime;                                        // 原価率
            targetRow.RateSectCstUnPrc_Prime = sourceRow.RateSectCstUnPrc_Prime;                        // 掛率設定拠点（原価単価）
            targetRow.RateDivUnCst_Prime = sourceRow.RateDivUnCst_Prime;                                // 掛率設定区分（原価単価）
            targetRow.UnPrcCalcCdUnCst_Prime = sourceRow.UnPrcCalcCdUnCst_Prime;                        // 単価算出区分（原価単価）
            targetRow.PriceCdUnCst_Prime = sourceRow.PriceCdUnCst_Prime;                                // 価格区分（原価単価）
            targetRow.StdUnPrcUnCst_Prime = sourceRow.StdUnPrcUnCst_Prime;                              // 基準単価（原価単価）
            targetRow.FracProcUnitUnCst_Prime = sourceRow.FracProcUnitUnCst_Prime;                      // 端数処理単位（原価単価）
            targetRow.FracProcUnCst_Prime = sourceRow.FracProcUnCst_Prime;                              // 端数処理（原価単価）
            targetRow.SalesUnitCost_Prime = sourceRow.SalesUnitCost_Prime;                              // 原価単価
            targetRow.SalesUnitCostChngDiv_Prime = sourceRow.SalesUnitCostChngDiv_Prime;                // 原価単価変更区分
            targetRow.RateBLGoodsCode_Prime = sourceRow.RateBLGoodsCode_Prime;                          // BL商品コード（掛率）
            targetRow.RateBLGoodsName_Prime = sourceRow.RateBLGoodsName_Prime;                          // BL商品コード名称（掛率）
            targetRow.RateGoodsRateGrpCd_Prime = sourceRow.RateGoodsRateGrpCd_Prime;                    // 商品掛率グループコード（掛率）
            targetRow.RateGoodsRateGrpNm_Prime = sourceRow.RateGoodsRateGrpNm_Prime;                    // 商品掛率グループ名称（掛率）
            targetRow.RateBLGroupCode_Prime = sourceRow.RateBLGroupCode_Prime;                          // BLグループコード（掛率）
            targetRow.RateBLGroupName_Prime = sourceRow.RateBLGroupName_Prime;                          // BLグループ名称（掛率）
            targetRow.PrtBLGoodsCode_Prime = sourceRow.PrtBLGoodsCode_Prime;                            // BL商品コード（印刷）
            targetRow.PrtBLGoodsName_Prime = sourceRow.PrtBLGoodsName_Prime;                            // BL商品コード名称（印刷）
            targetRow.SalesCode_Prime = sourceRow.SalesCode_Prime;                                      // 販売区分コード
            targetRow.SalesCdNm_Prime = sourceRow.SalesCdNm_Prime;                                      // 販売区分名称
            targetRow.WorkManHour_Prime = sourceRow.WorkManHour_Prime;                                  // 作業工数
            targetRow.ShipmentCnt_Prime = sourceRow.ShipmentCnt_Prime;                                  // 出荷数
            targetRow.AcceptAnOrderCnt_Prime = sourceRow.AcceptAnOrderCnt_Prime;                        // 受注数量
            targetRow.AcptAnOdrAdjustCnt_Prime = sourceRow.AcptAnOdrAdjustCnt_Prime;                    // 受注調整数
            targetRow.AcptAnOdrRemainCnt_Prime = sourceRow.AcptAnOdrRemainCnt_Prime;                    // 受注残数
            targetRow.RemainCntUpdDate_Prime = sourceRow.RemainCntUpdDate_Prime;                        // 残数更新日
            targetRow.SalesMoneyTaxInc_Prime = sourceRow.SalesMoneyTaxInc_Prime;                        // 売上金額（税込み）
            targetRow.SalesMoneyTaxExc_Prime = sourceRow.SalesMoneyTaxExc_Prime;                        // 売上金額（税抜き）
            targetRow.Cost_Prime = sourceRow.Cost_Prime;                                                // 原価
            targetRow.GrsProfitChkDiv_Prime = sourceRow.GrsProfitChkDiv_Prime;                          // 粗利チェック区分
            targetRow.SalesGoodsCd_Prime = sourceRow.SalesGoodsCd_Prime;                                // 売上商品区分
            targetRow.SalesPriceConsTax_Prime = sourceRow.SalesPriceConsTax_Prime;                      // 売上金額消費税額
            targetRow.TaxationDivCd_Prime = sourceRow.TaxationDivCd_Prime;                              // 課税区分
            targetRow.PartySlipNumDtl_Prime = sourceRow.PartySlipNumDtl_Prime;                          // 相手先伝票番号（明細）
            targetRow.DtlNote_Prime = sourceRow.DtlNote_Prime;                                          // 明細備考
            targetRow.SupplierCd_Prime = sourceRow.SupplierCd_Prime;                                    // 仕入先コード
            targetRow.SupplierSnm_Prime = sourceRow.SupplierSnm_Prime;                                  // 仕入先略称
            targetRow.OrderNumber_Prime = sourceRow.OrderNumber_Prime;                                  // 発注番号
            targetRow.WayToOrder_Prime = sourceRow.WayToOrder_Prime;                                    // 注文方法
            targetRow.SlipMemo1_Prime = sourceRow.SlipMemo1_Prime;                                      // 伝票メモ１
            targetRow.SlipMemo2_Prime = sourceRow.SlipMemo2_Prime;                                      // 伝票メモ２
            targetRow.SlipMemo3_Prime = sourceRow.SlipMemo3_Prime;                                      // 伝票メモ３
            targetRow.InsideMemo1_Prime = sourceRow.InsideMemo1_Prime;                                  // 社内メモ１
            targetRow.InsideMemo2_Prime = sourceRow.InsideMemo2_Prime;                                  // 社内メモ２
            targetRow.InsideMemo3_Prime = sourceRow.InsideMemo3_Prime;                                  // 社内メモ３
            targetRow.BfListPrice_Prime = sourceRow.BfListPrice_Prime;                                  // 変更前定価
            targetRow.BfSalesUnitPrice_Prime = sourceRow.BfSalesUnitPrice_Prime;                        // 変更前売価
            targetRow.BfUnitCost_Prime = sourceRow.BfUnitCost_Prime;                                    // 変更前原価
            targetRow.CmpltSalesRowNo_Prime = sourceRow.CmpltSalesRowNo_Prime;                          // 一式明細番号
            targetRow.CmpltGoodsMakerCd_Prime = sourceRow.CmpltGoodsMakerCd_Prime;                      // メーカーコード（一式）
            targetRow.CmpltMakerName_Prime = sourceRow.CmpltMakerName_Prime;                            // メーカー名称（一式）
            targetRow.CmpltMakerKanaName_Prime = sourceRow.CmpltMakerKanaName_Prime;                    // メーカーカナ名称（一式）
            targetRow.CmpltGoodsName_Prime = sourceRow.CmpltGoodsName_Prime;                            // 商品名称（一式）
            targetRow.CmpltShipmentCnt_Prime = sourceRow.CmpltShipmentCnt_Prime;                        // 数量（一式）
            targetRow.CmpltSalesUnPrcFl_Prime = sourceRow.CmpltSalesUnPrcFl_Prime;                      // 売上単価（一式）
            targetRow.CmpltSalesMoney_Prime = sourceRow.CmpltSalesMoney_Prime;                          // 売上金額（一式）
            targetRow.CmpltSalesUnitCost_Prime = sourceRow.CmpltSalesUnitCost_Prime;                    // 原価単価（一式）
            targetRow.CmpltCost_Prime = sourceRow.CmpltCost_Prime;                                      // 原価金額（一式）
            targetRow.CmpltPartySalSlNum_Prime = sourceRow.CmpltPartySalSlNum_Prime;                    // 相手先伝票番号（一式）
            targetRow.CmpltNote_Prime = sourceRow.CmpltNote_Prime;                                      // 一式備考
            targetRow.PrtGoodsNo_Prime = sourceRow.PrtGoodsNo_Prime;                                    // 印刷用品番
            targetRow.PrtMakerCode_Prime = sourceRow.PrtMakerCode_Prime;                                // 印刷用メーカーコード
            targetRow.PrtMakerName_Prime = sourceRow.PrtMakerName_Prime;                                // 印刷用メーカー名称

            targetRow.CarRelationGuid = sourceRow.CarRelationGuid;
            targetRow.CtlgPartsNo = sourceRow.CtlgPartsNo;
            targetRow.SpecialNote = sourceRow.SpecialNote;
            targetRow.StandardName = sourceRow.StandardName;
            targetRow.PrimeInfoRelationGuid = sourceRow.PrimeInfoRelationGuid;

            targetRow.ShipmentPosCnt = sourceRow.ShipmentPosCnt;
            targetRow.ListPriceDisplay = sourceRow.ListPriceDisplay;
            targetRow.ExistSetInfo = sourceRow.ExistSetInfo;
            targetRow.PartsInfoLinkGuid = sourceRow.PartsInfoLinkGuid;
            targetRow.PrintSelect = sourceRow.PrintSelect;

            targetRow.ShipmentPosCnt_Prime = sourceRow.ShipmentPosCnt_Prime;
            targetRow.ExistSetInfo_Prime = sourceRow.ExistSetInfo_Prime;
            targetRow.ListPriceDisplay_Prime = sourceRow.ListPriceDisplay_Prime;
            targetRow.PartsInfoLinkGuid_Prime = sourceRow.PartsInfoLinkGuid_Prime;
            targetRow.PrintSelect_Prime = sourceRow.PrintSelect_Prime;

            // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            targetRow.PrmSetDtlName2_Prime = sourceRow.PrmSetDtlName2_Prime;
            // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            targetRow.EditStatus = sourceRow.EditStatus;
            targetRow.RowStatus = ctROWSTATUS_NORMAL;

			#endregion
		}

		/// <summary>
		/// ＤＢから読み込んだ仕入データオブジェクトをインスタンス変数にキャッシュします。
		/// </summary>
		/// <param name="source">仕入データオブジェクト</param>
		private void CacheDBData( SalesSlip source )
		{
			this._salesSlipDBData = source.Clone();
		}

		/// <summary>
		/// 見積明細データテーブルと、関連するデータテーブル、ディクショナリをクリアします。
		/// </summary>
		private void ClearDetailTables()
		{
            this._estimateDetailDataTable.Rows.Clear();
            this._primeInfoDataTable.Rows.Clear();
            this._stockInfoDataTable.Rows.Clear();
            this._carInfoDataTable.Rows.Clear();
            this._cEqpDspInfoDic.Clear();
            this._colorInfoDic.Clear();
            this._trimInfoDic.Clear();
            this._partsInfoDictionary.Clear();
            this._carInfoDictionary.Clear();
            this._primeRelationDic.Clear();// ADD 2009/10/22
            this._goodsDictionary.Clear();
            this._uoeOrderDataTable.Rows.Clear();
            this._uoeOrderDetailDataTable.Rows.Clear();
            this._carRelationDic.Clear();

		}

        /// <summary>
        /// 新規入力用に各種テーブルをクリアします。
        /// </summary>
        public void ClearDataForNew()
        {
            this.ClearDetailTables();
        }

        /// <summary>
        /// 部品情報データセットをキャッシュします。
        /// </summary>
        /// <param name="partsInfoLinkGuid"></param>
        /// <param name="partsInfoDataSet"></param>
        private void CachePartsInfoDataSet( Guid partsInfoLinkGuid, PartsInfoDataSet partsInfoDataSet )
        {
            if (this._partsInfoDictionary.ContainsKey(partsInfoLinkGuid))
            {
                this._partsInfoDictionary[partsInfoLinkGuid] = (PartsInfoDataSet)partsInfoDataSet.Copy();
            }
            else
            {
                this._partsInfoDictionary.Add(partsInfoLinkGuid, (PartsInfoDataSet)partsInfoDataSet.Copy());
            }
        }

        /// <summary>
        /// 部品情報データセットディクショナリから部品情報データセットを取得します。
        /// </summary>
        /// <param name="partsInfoLinkGuid">部品情報リンクGUID</param>
        /// <returns>検索部品データセット</returns>
        public PartsInfoDataSet GetPartsInfoDataSet( Guid partsInfoLinkGuid )
        {
            if (this._partsInfoDictionary.ContainsKey(partsInfoLinkGuid))
            {
                return this._partsInfoDictionary[partsInfoLinkGuid];
            }
            else
            {
                return null;
            }
        }

        #region 商品連結データディクショナリ制御

        /// <summary>
        /// 商品連結データリストをディクショナリにキャッシュします。
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        public void CacheGoodsUnitData( List<GoodsUnitData> goodsUnitDataList )
        {
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                this.CacheGoodsUnitData(goodsUnitData);
            }
        }

        /// <summary>
        /// 商品連結データをディクショナリにキャッシュします。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        public void CacheGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
            //if (this._goodsDictionary.ContainsKey(goodsInfoKey))//DEL 2011/02/14
            if (this._goodsDictionary.ContainsKey(goodsInfoKey.GetKey()))//ADD 2011/02/14
            {
                //this._goodsDictionary[goodsInfoKey] = goodsUnitData;//DEL 2011/02/14
                this._goodsDictionary[goodsInfoKey.GetKey()] = goodsUnitData;//ADD 2011/02/14
            }
            else
            {
                //this._goodsDictionary.Add(goodsInfoKey, goodsUnitData);//DEL 2011/02/14
                this._goodsDictionary.Add(goodsInfoKey.GetKey(), goodsUnitData);//ADD 2011/02/14
            }
        }

        /// <summary>
        /// 商品連結データディクショナリから対象商品のデータを取得します。
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>商品連結データ</returns>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        public GoodsUnitData GetGoodsUnitDataFromCache(string goodsNo, int goodsMakerCd)
        {
            if (( string.IsNullOrEmpty(goodsNo) ) || ( goodsMakerCd == 0 )) return null;

            GoodsInfoKey goodsInfokey = new GoodsInfoKey(goodsNo, goodsMakerCd);

            //-----UPD 2011/02/14----->>>>>
            //return ( this._goodsDictionary.ContainsKey(goodsInfokey) ) ? this._goodsDictionary[goodsInfokey] : null;
            GoodsUnitData goodsUnitData;
            //if (this._goodsDictionary.ContainsKey(goodsInfokey))//DEL 2011/02/14
            if (this._goodsDictionary.ContainsKey(goodsInfokey.GetKey()))//ADD 2011/02/14
            {
                //goodsUnitData = this._goodsDictionary[goodsInfokey];//DEL 2011/02/14
                goodsUnitData = this._goodsDictionary[goodsInfokey.GetKey()];//ADD 2011/02/14
            }
            else
            {
                goodsUnitData = new GoodsUnitData();
                goodsUnitData.GoodsNo = goodsNo;
                goodsUnitData.GoodsMakerCd = goodsMakerCd;
            }
            return goodsUnitData;
            //-----UPD 2011/02/14-----<<<<<
        }

        /// <summary>
        /// キャッシュしている商品連結データの全リストを取得します。
        /// </summary>
        /// <returns>商品連結データリスト</returns>
        public List<GoodsUnitData> GetGoodsUnitDataListFromCache()
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            goodsUnitDataList.AddRange(this._goodsDictionary.Values);

            return goodsUnitDataList;
        }

        #endregion

        /// <summary>
        /// 売上明細データを見積明細データテーブルにキャッシュします。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="baseSalesSlip">処理元売上データ</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="estimateDetailDataTable">見積明細データテーブル</param>
		private void CacheEstimateDetail( SalesSlip salesSlip, SalesSlip baseSalesSlip, List<SalesDetail> salesDetailList, EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable )
		{
			// 売上明細データをキャッシュ
			foreach (SalesDetail salesDetail in salesDetailList)
			{
				this.CacheEstimateDetailDataTable(salesSlip, salesDetail, estimateDetailDataTable);
			}

            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            string msg;

            int status = this.SearchPartsFromGoodsNoNonVariousSearchWholeWord(salesSlip, salesDetailList, out goodsUnitDataList, out msg);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.CacheGoodsUnitData(goodsUnitDataList);
            }

		}

		/// <summary>
		/// ＤＢから取得した売上明細データをデータテーブルにキャッシュします。
		/// </summary>
		/// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
		private void CacheEstimateDetailDBData(List<SalesDetail> salesDetailList)
		{
			this._salesDetailDBDataList.Clear();

			foreach (SalesDetail salesDetail in salesDetailList)
			{
				this._salesDetailDBDataList.Add(salesDetail.Clone());
			}
		}

        /// <summary>
        /// ＤＢへ保存した売上データを調整します。
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        private void AdjustSalesSaveDBData(ref SalesSlip salesSlip, ref List<SalesDetail> salesDetailList)
        {
            this.AdjustSalesDBData(ref salesSlip, ref salesDetailList);
        }

		/// <summary>
		/// ＤＢから取得した仕入データを調整します。
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
		private void AdjustSalesReadDBData( ref SalesSlip salesSlip, ref List<SalesDetail> salesDetailList)
        {
            this.AdjustSalesDBData(ref salesSlip, ref salesDetailList);

            // 伝票検索日
            salesSlip.SearchSlipDate = DateTime.Today;
        }


        /// <summary>
        /// ＤＢから取得した仕入データを調整します。
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        private void AdjustSalesDBData(ref SalesSlip salesSlip, ref List<SalesDetail> salesDetailList)
        {

            #region 拠点情報
            SecInfoSet secInfoSet = this._estimateInputInitDataAcs.GetSecInfo(salesSlip.ResultsAddUpSecCd);
            if (secInfoSet != null)
            {
                salesSlip.ResultsAddUpSecNm = secInfoSet.SectionGuideNm;
            }
            #endregion

            #region 部門情報

            if (salesSlip.SubSectionCode != 0)
            {
                salesSlip.SubSectionName = this._estimateInputInitDataAcs.GetName_FromSubSection(salesSlip.SubSectionCode);
            }

            #endregion

            #region 請求先情報
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            CustomerInfo claim;
            int status = this._customerInfoAcs.ReadDBData(salesSlip.EnterpriseCode, salesSlip.ClaimCode, true, out claim);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                claim = new CustomerInfo();
            }

            salesSlip.ClaimName = claim.Name;
            salesSlip.ClaimName2 = claim.Name2;
            salesSlip.CreditMngCode = claim.CreditMngCode;

            #endregion

            #region 見積初期値設定

            EstimateDefSet estimateDefSet = this._estimateInputInitDataAcs.GetEstimateDefSet();
            if (estimateDefSet != null)
            {
                salesSlip.EstimateDtCreateDiv = estimateDefSet.EstimateDtCreateDiv;
            }

            #endregion

        }

        /// <summary>
        /// 見積明細データオブジェクトをデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="estimateDetailDataTable">見積明細データテーブル</param>
		private void CacheEstimateDetailDataTable( SalesSlip salesSlip, SalesDetail salesDetail, EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable )
		{
            TargetData targetData = ( salesDetail.SalesRowDerivNo == (int)SalesRowDerivNo.PureParts ) ? TargetData.PureParts : TargetData.PrimeParts;

            EstimateInputDataSet.EstimateDetailRow row = estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);
            if (row != null)
            {
                this.SetRowFromUIData(targetData, ref row, salesSlip, salesDetail);
            }
            else
            {
                try
                {
                    estimateDetailDataTable.AddEstimateDetailRow(this.CreateRowFromUIData(salesSlip, salesDetail, estimateDetailDataTable));
                }
                catch (ConstraintException)
                {
                    //EstimateInputDataSet.EstimateDetailRow row = estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);
                    this.SetRowFromUIData(targetData, ref row, salesSlip, salesDetail);
                }

            }
		}

        /// <summary>
        /// 見積明細データテーブルを生成し、データをキャッシュします。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <returns>見積明細データテーブル</returns>
        private EstimateInputDataSet.EstimateDetailDataTable CreateEstimateDetailDataTable( SalesSlip salesSlip, List<SalesDetail> salesDetailList )
        {
            EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable = new EstimateInputDataSet.EstimateDetailDataTable();
            this.CacheEstimateDetail(salesSlip, salesSlip, salesDetailList, estimateDetailDataTable);
            return estimateDetailDataTable;
        }

        /// <summary>
        /// 売上明細データオブジェクトから見積明細データ行オブジェクトに項目を設定します。
        /// </summary>
        /// <param name="targetData">対象データ</param>
        /// <param name="row">見積明細行</param>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetail">売上明細データ</param>
        private void SetRowFromUIData(TargetData targetData, ref EstimateInputDataSet.EstimateDetailRow row, SalesSlip salesSlip, SalesDetail salesDetail)
        {
            this.SetRowFromUIData(targetData, ref row, salesSlip, salesDetail, true);
        }

        /// <summary>
        /// 売上明細データオブジェクトから見積明細データ行オブジェクトに項目を設定します。
        /// </summary>
        /// <param name="targetData">対象データ</param>
        /// <param name="row">見積明細行</param>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="numCopy">True:番号をコピーする</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        private void SetRowFromUIData(TargetData targetData, ref EstimateInputDataSet.EstimateDetailRow row, SalesSlip salesSlip, SalesDetail salesDetail, bool numCopy)
		{
            //row.SectionCode = salesDetail.SectionCode; // 拠点コード
            //row.SubSectionCode = salesDetail.SubSectionCode; // 部門コード
            //row.SalesDate = salesDetail.SalesDate; // 売上日付
            if (numCopy)
            {
                row.SalesSlipNum = salesDetail.SalesSlipNum; // 売上伝票番号
                row.SalesRowNo = salesDetail.SalesRowNo; // 売上行番号
            }
            row.AcceptAnOrderNo = salesDetail.AcceptAnOrderNo; // 受注番号
            row.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus; // 受注ステータス

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PureParts ))
            {
                //row.SalesRowDerivNo = salesDetail.SalesRowDerivNo; // 売上行番号枝番
                row.CommonSeqNo = salesDetail.CommonSeqNo; // 共通通番
                row.SalesSlipDtlNum = salesDetail.SalesSlipDtlNum; // 売上明細通番
                row.AcptAnOdrStatusSrc = salesDetail.AcptAnOdrStatusSrc; // 受注ステータス（元）
                row.SalesSlipDtlNumSrc = salesDetail.SalesSlipDtlNumSrc; // 売上明細通番（元）
                row.SupplierFormalSync = salesDetail.SupplierFormalSync; // 仕入形式（同時）
                row.StockSlipDtlNumSync = salesDetail.StockSlipDtlNumSync; // 仕入明細通番（同時）
                //row.SalesSlipCdDtl = salesDetail.SalesSlipCdDtl; // 売上伝票区分（明細）
                //row.DeliGdsCmpltDueDate = salesDetail.DeliGdsCmpltDueDate; // 納品完了予定日
                row.GoodsKindCode = salesDetail.GoodsKindCode; // 商品属性
                row.GoodsSearchDivCd = salesDetail.GoodsSearchDivCd; // 商品検索区分
                row.GoodsMakerCd = salesDetail.GoodsMakerCd; // 商品メーカーコード
                row.MakerName = salesDetail.MakerName; // メーカー名称
                row.MakerKanaName = salesDetail.MakerKanaName; // メーカーカナ名称
                row.GoodsNo = salesDetail.GoodsNo; // 商品番号
                row.GoodsName = salesDetail.GoodsName; // 商品名称
                row.GoodsNameKana = salesDetail.GoodsNameKana; // 商品名称カナ
                row.GoodsLGroup = salesDetail.GoodsLGroup; // 商品大分類コード
                row.GoodsLGroupName = salesDetail.GoodsLGroupName; // 商品大分類名称
                row.GoodsMGroup = salesDetail.GoodsMGroup; // 商品中分類コード
                row.GoodsMGroupName = salesDetail.GoodsMGroupName; // 商品中分類名称
                row.BLGroupCode = salesDetail.BLGroupCode; // BLグループコード
                row.BLGroupName = salesDetail.BLGroupName; // BLグループコード名称
                row.BLGoodsCode = salesDetail.BLGoodsCode; // BL商品コード
                row.BLGoodsFullName = salesDetail.BLGoodsFullName; // BL商品コード名称（全角）
                row.EnterpriseGanreCode = salesDetail.EnterpriseGanreCode; // 自社分類コード
                row.EnterpriseGanreName = salesDetail.EnterpriseGanreName; // 自社分類名称
                row.WarehouseCode = salesDetail.WarehouseCode.Trim(); // 倉庫コード
                row.WarehouseName = salesDetail.WarehouseName; // 倉庫名称
                row.WarehouseShelfNo = salesDetail.WarehouseShelfNo; // 倉庫棚番
                row.SalesOrderDivCd = salesDetail.SalesOrderDivCd; // 売上在庫取寄せ区分
                row.OpenPriceDiv = salesDetail.OpenPriceDiv; // オープン価格区分
                row.GoodsRateRank = salesDetail.GoodsRateRank; // 商品掛率ランク
                row.CustRateGrpCode = salesDetail.CustRateGrpCode; // 得意先掛率グループコード
                row.ListPriceRate = salesDetail.ListPriceRate; // 定価率
                row.RateSectPriceUnPrc = salesDetail.RateSectPriceUnPrc; // 掛率設定拠点（定価）
                row.RateDivLPrice = salesDetail.RateDivLPrice; // 掛率設定区分（定価）
                row.UnPrcCalcCdLPrice = salesDetail.UnPrcCalcCdLPrice; // 単価算出区分（定価）
                row.PriceCdLPrice = salesDetail.PriceCdLPrice; // 価格区分（定価）
                row.StdUnPrcLPrice = salesDetail.StdUnPrcLPrice; // 基準単価（定価）
                row.FracProcUnitLPrice = salesDetail.FracProcUnitLPrice; // 端数処理単位（定価）
                row.FracProcLPrice = salesDetail.FracProcLPrice; // 端数処理（定価）
                row.ListPriceTaxIncFl = salesDetail.ListPriceTaxIncFl; // 定価（税込，浮動）
                row.ListPriceTaxExcFl = salesDetail.ListPriceTaxExcFl; // 定価（税抜，浮動）
                row.ListPriceChngCd = salesDetail.ListPriceChngCd; // 定価変更区分
                row.SalesRate = salesDetail.SalesRate; // 売価率
                row.RateSectSalUnPrc = salesDetail.RateSectSalUnPrc; // 掛率設定拠点（売上単価）
                row.RateDivSalUnPrc = salesDetail.RateDivSalUnPrc; // 掛率設定区分（売上単価）
                row.UnPrcCalcCdSalUnPrc = salesDetail.UnPrcCalcCdSalUnPrc;              // 単価算出区分（売上単価）
                row.PriceCdSalUnPrc = salesDetail.PriceCdSalUnPrc; // 価格区分（売上単価）
                row.StdUnPrcSalUnPrc = salesDetail.StdUnPrcSalUnPrc; // 基準単価（売上単価）
                row.FracProcUnitSalUnPrc = salesDetail.FracProcUnitSalUnPrc; // 端数処理単位（売上単価）
                row.FracProcSalUnPrc = salesDetail.FracProcSalUnPrc; // 端数処理（売上単価）
                row.SalesUnPrcTaxIncFl = salesDetail.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
                row.SalesUnPrcTaxExcFl = salesDetail.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
                row.SalesUnPrcChngCd = salesDetail.SalesUnPrcChngCd; // 売上単価変更区分
                row.CostRate = salesDetail.CostRate; // 原価率
                row.RateSectCstUnPrc = salesDetail.RateSectCstUnPrc; // 掛率設定拠点（原価単価）
                row.RateDivUnCst = salesDetail.RateDivUnCst; // 掛率設定区分（原価単価）
                row.UnPrcCalcCdUnCst = salesDetail.UnPrcCalcCdUnCst; // 単価算出区分（原価単価）
                row.PriceCdUnCst = salesDetail.PriceCdUnCst; // 価格区分（原価単価）
                row.StdUnPrcUnCst = salesDetail.StdUnPrcUnCst; // 基準単価（原価単価）
                row.FracProcUnitUnCst = salesDetail.FracProcUnitUnCst; // 端数処理単位（原価単価）
                row.FracProcUnCst = salesDetail.FracProcUnCst; // 端数処理（原価単価）
                row.SalesUnitCost = salesDetail.SalesUnitCost; // 原価単価
                row.SalesUnitCostChngDiv = salesDetail.SalesUnitCostChngDiv; // 原価単価変更区分
                row.RateBLGoodsCode = salesDetail.RateBLGoodsCode; // BL商品コード（掛率）
                row.RateBLGoodsName = salesDetail.RateBLGoodsName; // BL商品コード名称（掛率）
                row.RateGoodsRateGrpCd = salesDetail.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
                row.RateGoodsRateGrpNm = salesDetail.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
                row.RateBLGroupCode = salesDetail.RateBLGroupCode; // BLグループコード（掛率）
                row.RateBLGroupName = salesDetail.RateBLGroupName; // BLグループ名称（掛率）
                row.PrtBLGoodsCode = salesDetail.PrtBLGoodsCode; // BL商品コード（印刷）
                row.PrtBLGoodsName = salesDetail.PrtBLGoodsName; // BL商品コード名称（印刷）
                row.SalesCode = salesDetail.SalesCode; // 販売区分コード
                row.SalesCdNm = salesDetail.SalesCdNm; // 販売区分名称
                row.WorkManHour = salesDetail.WorkManHour; // 作業工数
                row.ShipmentCnt = salesDetail.ShipmentCnt; // 出荷数
                row.AcceptAnOrderCnt = salesDetail.AcceptAnOrderCnt; // 受注数量
                row.AcptAnOdrAdjustCnt = salesDetail.AcptAnOdrAdjustCnt; // 受注調整数
                row.AcptAnOdrRemainCnt = salesDetail.AcptAnOdrRemainCnt; // 受注残数
                row.RemainCntUpdDate = salesDetail.RemainCntUpdDate; // 残数更新日
                row.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxInc; // 売上金額（税込み）
                row.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc; // 売上金額（税抜き）
                row.Cost = salesDetail.Cost; // 原価
                row.GrsProfitChkDiv = salesDetail.GrsProfitChkDiv; // 粗利チェック区分
                row.SalesGoodsCd = salesDetail.SalesGoodsCd; // 売上商品区分
                row.SalesPriceConsTax = salesDetail.SalesPriceConsTax; // 売上金額消費税額
                row.TaxationDivCd = salesDetail.TaxationDivCd; // 課税区分
                row.PartySlipNumDtl = salesDetail.PartySlipNumDtl; // 相手先伝票番号（明細）
                row.DtlNote = salesDetail.DtlNote; // 明細備考
                row.SupplierCd = salesDetail.SupplierCd; // 仕入先コード
                row.SupplierSnm = salesDetail.SupplierSnm; // 仕入先略称
                row.OrderNumber = salesDetail.OrderNumber; // 発注番号
                row.WayToOrder = salesDetail.WayToOrder; // 注文方法
                row.SlipMemo1 = salesDetail.SlipMemo1; // 伝票メモ１
                row.SlipMemo2 = salesDetail.SlipMemo2; // 伝票メモ２
                row.SlipMemo3 = salesDetail.SlipMemo3; // 伝票メモ３
                row.InsideMemo1 = salesDetail.InsideMemo1; // 社内メモ１
                row.InsideMemo2 = salesDetail.InsideMemo2; // 社内メモ２
                row.InsideMemo3 = salesDetail.InsideMemo3; // 社内メモ３
                row.BfListPrice = salesDetail.BfListPrice; // 変更前定価
                row.BfSalesUnitPrice = salesDetail.BfSalesUnitPrice; // 変更前売価
                row.BfUnitCost = salesDetail.BfUnitCost; // 変更前原価
                row.CmpltSalesRowNo = salesDetail.CmpltSalesRowNo; // 一式明細番号
                row.CmpltGoodsMakerCd = salesDetail.CmpltGoodsMakerCd; // メーカーコード（一式）
                row.CmpltMakerName = salesDetail.CmpltMakerName; // メーカー名称（一式）
                row.CmpltMakerKanaName = salesDetail.CmpltMakerKanaName; // メーカーカナ名称（一式）
                row.CmpltGoodsName = salesDetail.CmpltGoodsName; // 商品名称（一式）
                row.CmpltShipmentCnt = salesDetail.CmpltShipmentCnt; // 数量（一式）
                row.CmpltSalesUnPrcFl = salesDetail.CmpltSalesUnPrcFl; // 売上単価（一式）
                row.CmpltSalesMoney = salesDetail.CmpltSalesMoney; // 売上金額（一式）
                row.CmpltSalesUnitCost = salesDetail.CmpltSalesUnitCost; // 原価単価（一式）
                row.CmpltCost = salesDetail.CmpltCost; // 原価金額（一式）
                row.CmpltPartySalSlNum = salesDetail.CmpltPartySalSlNum; // 相手先伝票番号（一式）
                row.CmpltNote = salesDetail.CmpltNote; // 一式備考
                row.PrtGoodsNo = salesDetail.PrtGoodsNo; // 印刷用品番
                row.PrtMakerCode = salesDetail.PrtMakerCode; // 印刷用メーカーコード
                row.PrtMakerName = salesDetail.PrtMakerName; // 印刷用メーカー名称

                row.DtlRelationGuid = salesDetail.DtlRelationGuid; // 共通キー
                row.CarRelationGuid = salesDetail.CarRelationGuid; // 車輌情報共通キー
                //row.SalesRowNoDisplay = salesDetail.SalesRowNoDisplay; // 行番号（表示用）
                //row.SupplierStock = salesDetail.SupplierStock; // 現在庫数
                //row.SupplierStockDisplay = salesDetail.SupplierStockDisplay; // 現在庫数（表示用）
                //row.OpenPriceDivDisplay = salesDetail.OpenPriceDivDisplay; // オープン価格区分（表示用）
                //row.ListPriceDisplay = salesDetail.ListPriceDisplay; // 定価（表示用）
                //row.SalesUnPrcDisplay = salesDetail.SalesUnPrcDisplay; // 売上単価（表示用）
                //row.SalesUnitCostTaxExc = salesDetail.SalesUnitCostTaxExc; // 原価単価（税抜）
                //row.SalesUnitCostTaxInc = salesDetail.SalesUnitCostTaxInc; // 原価単価（税込）
                //row.ShipmentCntDisplay = salesDetail.ShipmentCntDisplay; // 出荷数（表示用）
                //row.AddUpEnableCnt = salesDetail.AddUpEnableCnt; // 計上可能数
                //row.AlreadyAddUpCnt = salesDetail.AlreadyAddUpCnt; // 計上済数
                //row.ShipmentCntDefault = salesDetail.ShipmentCntDefault; // 出荷数（初期値）
                //row.SalesMoneyDisplay = salesDetail.SalesMoneyDisplay; // 売上金額（表示用）
                //row.CostTaxInc = salesDetail.CostTaxInc; // 原価金額（税込）
                //row.CostTaxExc = salesDetail.CostTaxExc; // 原価金額（税抜）
                //row.AcceptAnOrderCntDisplay = salesDetail.AcceptAnOrderCntDisplay; // 受注数（表示用）
                //row.AcceptAnOrderCntDefault = salesDetail.AcceptAnOrderCntDefault; // 受注数（初期値）
                //row.TaxDiv = salesDetail.TaxDiv; // 課税区分（UI用）
                //row.CanTaxDivChange = salesDetail.CanTaxDivChange; // 課税非課税区分変更可能フラグ
                //row.RowStatus = salesDetail.RowStatus; // 行ステータス
                //row.EditStatus = salesDetail.EditStatus; // エディットステータス
                //row.SlipMemoExist = salesDetail.SlipMemoExist; // メモ存在フラグ
                //row.SupplierSlipExist = salesDetail.SupplierSlipExist; // 仕入情報存在フラグ
                //row.DetailGrossProfitRate = salesDetail.DetailGrossProfitRate; // 明細粗利率
                //row.CostUpRate = salesDetail.CostUpRate; // 原価アップ率
                //row.GrossProfitSecureRate = salesDetail.GrossProfitSecureRate; // 粗利確保率
                //row.SupplierCdForStock = salesDetail.SupplierCdForStock; // 仕入先コード
                //row.StockDate = salesDetail.StockDate; // 仕入日
                //row.PartySalesSlipNum = salesDetail.PartySalesSlipNum; // 仕入伝票番号
                //row.BoCode = salesDetail.BoCode; // BO区分
                //row.SupplierCdForOrder = salesDetail.SupplierCdForOrder; // 発注先
                //row.AcceptAnOrderCntForOrder = salesDetail.AcceptAnOrderCntForOrder; // 発注数
                //row.SupplierSnmForOrder = salesDetail.SupplierSnmForOrder; // 発注先名称
                //row.DeliveredGoodsDiv = salesDetail.DeliveredGoodsDiv; // 納品区分
                //row.DeliveredGoodsDivNm = salesDetail.DeliveredGoodsDivNm; // 納品区分名称
                //row.DeliveredGoodsDivNmSave = salesDetail.DeliveredGoodsDivNmSave; // 納品区分名称（保存用）
                //row.FollowDeliGoodsDiv = salesDetail.FollowDeliGoodsDiv; // H納品区分
                //row.FollowDeliGoodsDivNm = salesDetail.FollowDeliGoodsDivNm; // H納品区分名称
                //row.FollowDeliGoodsDivNmSave = salesDetail.FollowDeliGoodsDivNmSave; // H納品区分名称（保存用）
                //row.UOEResvdSection = salesDetail.UOEResvdSection; // 指定拠点
                //row.UOEResvdSectionNm = salesDetail.UOEResvdSectionNm; // 指定拠点名称
                //row.UOEResvdSectionNmSave = salesDetail.UOEResvdSectionNmSave; // 指定拠点名称（保存用）
                //row.PriceStartDate = salesDetail.PriceStartDate; // 新定価適用日
                //row.Dummy = salesDetail.Dummy; // ダミー（空欄表示用）
                //row.SearchPartsModeState = salesDetail.SearchPartsModeState; // 部品検索状態

                //-----------------------------------------------------------------------------
                // 定価（表示用）
                //-----------------------------------------------------------------------------
                if (salesSlip.ConsTaxLayMethod == 9)
                {
                    // 転嫁方式：非課税
                    row.ListPriceDisplay = salesDetail.ListPriceTaxExcFl;
                }
                else if (salesSlip.TotalAmountDispWayCd == 0)
                {
                    // 総額表示しない
                    switch ((CalculateTax.TaxationCode)salesDetail.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            row.ListPriceDisplay = salesDetail.ListPriceTaxExcFl;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            row.ListPriceDisplay = salesDetail.ListPriceTaxIncFl;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            row.ListPriceDisplay = salesDetail.ListPriceTaxExcFl;
                            break;
                    }
                }
                else
                {
                    // 総額表示する
                    switch ((CalculateTax.TaxationCode)salesDetail.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            row.ListPriceDisplay = salesDetail.ListPriceTaxIncFl;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            row.ListPriceDisplay = salesDetail.ListPriceTaxIncFl;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            row.ListPriceDisplay = salesDetail.ListPriceTaxIncFl;
                            break;
                    }
                }

                //-----------------------------------------------------------------------------
                // 数量関係
                //-----------------------------------------------------------------------------
                row.ShipmentCnt = salesDetail.ShipmentCnt;
                row.ShipmentCntDefault = salesDetail.ShipmentCnt;
                row.AcceptAnOrderCnt = salesDetail.AcceptAnOrderCnt;
                row.AlreadyAddUpCnt = (double)( (decimal)salesDetail.ShipmentCnt - (decimal)salesDetail.AcptAnOdrRemainCnt );

                //-----------------------------------------------------------------------------
                // その他補正
                //-----------------------------------------------------------------------------
                // 車輌情報共通キー
                row.CarRelationGuid = Guid.Empty;
                // 検索部品データセットリンクGUID
                row.PartsInfoLinkGuid = Guid.Empty;
                // 優良情報連結GUID
                row.PrimeInfoRelationGuid = Guid.Empty;
                // 発注情報GUID
                row.UOEOrderGuid = Guid.Empty;

                if (string.IsNullOrEmpty(row.GoodsName_Prime))
                {
                    row.GoodsName_Prime = row.GoodsName;
                    row.BLGoodsCode_Prime = row.BLGoodsCode;
                }

                row.EditStatus = ctEDITSTATUS_AllOK;

                // RowStatus
                row.RowStatus = ctROWSTATUS_NORMAL;
            }

            if (( targetData == TargetData.All ) || ( targetData == TargetData.PrimeParts ))
            {
                //row.SalesRowDerivNo = salesDetail.SalesRowDerivNo; // 売上行番号枝番
                row.CommonSeqNo_Prime = salesDetail.CommonSeqNo; // 共通通番
                row.SalesSlipDtlNum_Prime = salesDetail.SalesSlipDtlNum; // 売上明細通番
                row.AcptAnOdrStatusSrc_Prime = salesDetail.AcptAnOdrStatusSrc; // 受注ステータス（元）
                row.SalesSlipDtlNumSrc_Prime = salesDetail.SalesSlipDtlNumSrc; // 売上明細通番（元）
                row.SupplierFormalSync_Prime = salesDetail.SupplierFormalSync; // 仕入形式（同時）
                row.StockSlipDtlNumSync_Prime = salesDetail.StockSlipDtlNumSync; // 仕入明細通番（同時）
                //row.SalesSlipCdDtl = salesDetail.SalesSlipCdDtl; // 売上伝票区分（明細）
                //row.DeliGdsCmpltDueDate = salesDetail.DeliGdsCmpltDueDate; // 納品完了予定日
                row.GoodsKindCode_Prime = salesDetail.GoodsKindCode; // 商品属性
                row.GoodsSearchDivCd_Prime = salesDetail.GoodsSearchDivCd; // 商品検索区分
                row.GoodsMakerCd_Prime = salesDetail.GoodsMakerCd; // 商品メーカーコード
                row.MakerName_Prime = salesDetail.MakerName; // メーカー名称
                row.MakerKanaName_Prime = salesDetail.MakerKanaName; // メーカーカナ名称
                row.GoodsNo_Prime = salesDetail.GoodsNo; // 商品番号
                row.GoodsName_Prime = salesDetail.GoodsName; // 商品名称
                row.GoodsNameKana_Prime = salesDetail.GoodsNameKana; // 商品名称カナ
                row.GoodsLGroup_Prime = salesDetail.GoodsLGroup; // 商品大分類コード
                row.GoodsLGroupName_Prime = salesDetail.GoodsLGroupName; // 商品大分類名称
                row.GoodsMGroup_Prime = salesDetail.GoodsMGroup; // 商品中分類コード
                row.GoodsMGroupName_Prime = salesDetail.GoodsMGroupName; // 商品中分類名称
                row.BLGroupCode_Prime = salesDetail.BLGroupCode; // BLグループコード
                row.BLGroupName_Prime = salesDetail.BLGroupName; // BLグループコード名称
                row.BLGoodsCode_Prime = salesDetail.BLGoodsCode; // BL商品コード
                row.BLGoodsFullName_Prime = salesDetail.BLGoodsFullName; // BL商品コード名称（全角）
                row.EnterpriseGanreCode_Prime = salesDetail.EnterpriseGanreCode; // 自社分類コード
                row.EnterpriseGanreName_Prime = salesDetail.EnterpriseGanreName; // 自社分類名称
                row.WarehouseCode_Prime = salesDetail.WarehouseCode.Trim(); // 倉庫コード
                row.WarehouseName_Prime = salesDetail.WarehouseName; // 倉庫名称
                row.WarehouseShelfNo_Prime = salesDetail.WarehouseShelfNo; // 倉庫棚番
                row.SalesOrderDivCd_Prime = salesDetail.SalesOrderDivCd; // 売上在庫取寄せ区分
                row.OpenPriceDiv_Prime = salesDetail.OpenPriceDiv; // オープン価格区分
                row.GoodsRateRank_Prime = salesDetail.GoodsRateRank; // 商品掛率ランク
                row.CustRateGrpCode_Prime = salesDetail.CustRateGrpCode; // 得意先掛率グループコード
                row.ListPriceRate_Prime = salesDetail.ListPriceRate; // 定価率
                row.RateSectPriceUnPrc_Prime = salesDetail.RateSectPriceUnPrc; // 掛率設定拠点（定価）
                row.RateDivLPrice_Prime = salesDetail.RateDivLPrice; // 掛率設定区分（定価）
                row.UnPrcCalcCdLPrice_Prime = salesDetail.UnPrcCalcCdLPrice; // 単価算出区分（定価）
                row.PriceCdLPrice_Prime = salesDetail.PriceCdLPrice; // 価格区分（定価）
                row.StdUnPrcLPrice_Prime = salesDetail.StdUnPrcLPrice; // 基準単価（定価）
                row.FracProcUnitLPrice_Prime = salesDetail.FracProcUnitLPrice; // 端数処理単位（定価）
                row.FracProcLPrice_Prime = salesDetail.FracProcLPrice; // 端数処理（定価）
                row.ListPriceTaxIncFl_Prime = salesDetail.ListPriceTaxIncFl; // 定価（税込，浮動）
                row.ListPriceTaxExcFl_Prime = salesDetail.ListPriceTaxExcFl; // 定価（税抜，浮動）
                row.ListPriceChngCd_Prime = salesDetail.ListPriceChngCd; // 定価変更区分
                row.SalesRate_Prime = salesDetail.SalesRate; // 売価率
                row.RateSectSalUnPrc_Prime = salesDetail.RateSectSalUnPrc; // 掛率設定拠点（売上単価）
                row.RateDivSalUnPrc_Prime = salesDetail.RateDivSalUnPrc; // 掛率設定区分（売上単価）
                row.UnPrcCalcCdSalUnPrc_Prime = salesDetail.UnPrcCalcCdSalUnPrc; // 単価算出区分（売上単価）
                row.PriceCdSalUnPrc_Prime = salesDetail.PriceCdSalUnPrc; // 価格区分（売上単価）
                row.StdUnPrcSalUnPrc_Prime = salesDetail.StdUnPrcSalUnPrc; // 基準単価（売上単価）
                row.FracProcUnitSalUnPrc_Prime = salesDetail.FracProcUnitSalUnPrc; // 端数処理単位（売上単価）
                row.FracProcSalUnPrc_Prime = salesDetail.FracProcSalUnPrc; // 端数処理（売上単価）
                row.SalesUnPrcTaxIncFl_Prime = salesDetail.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
                row.SalesUnPrcTaxExcFl_Prime = salesDetail.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
                row.SalesUnPrcChngCd_Prime = salesDetail.SalesUnPrcChngCd; // 売上単価変更区分
                row.CostRate_Prime = salesDetail.CostRate; // 原価率
                row.RateSectCstUnPrc_Prime = salesDetail.RateSectCstUnPrc; // 掛率設定拠点（原価単価）
                row.RateDivUnCst_Prime = salesDetail.RateDivUnCst; // 掛率設定区分（原価単価）
                row.UnPrcCalcCdUnCst_Prime = salesDetail.UnPrcCalcCdUnCst; // 単価算出区分（原価単価）
                row.PriceCdUnCst_Prime = salesDetail.PriceCdUnCst; // 価格区分（原価単価）
                row.StdUnPrcUnCst_Prime = salesDetail.StdUnPrcUnCst; // 基準単価（原価単価）
                row.FracProcUnitUnCst_Prime = salesDetail.FracProcUnitUnCst; // 端数処理単位（原価単価）
                row.FracProcUnCst_Prime = salesDetail.FracProcUnCst; // 端数処理（原価単価）
                row.SalesUnitCost_Prime = salesDetail.SalesUnitCost; // 原価単価
                row.SalesUnitCostChngDiv_Prime = salesDetail.SalesUnitCostChngDiv; // 原価単価変更区分
                row.RateBLGoodsCode_Prime = salesDetail.RateBLGoodsCode; // BL商品コード（掛率）
                row.RateBLGoodsName_Prime = salesDetail.RateBLGoodsName; // BL商品コード名称（掛率）
                row.RateGoodsRateGrpCd_Prime = salesDetail.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
                row.RateGoodsRateGrpNm_Prime = salesDetail.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
                row.RateBLGroupCode_Prime = salesDetail.RateBLGroupCode; // BLグループコード（掛率）
                row.RateBLGroupName_Prime = salesDetail.RateBLGroupName; // BLグループ名称（掛率）
                row.PrtBLGoodsCode_Prime = salesDetail.PrtBLGoodsCode; // BL商品コード（印刷）
                row.PrtBLGoodsName_Prime = salesDetail.PrtBLGoodsName; // BL商品コード名称（印刷）
                row.SalesCode_Prime = salesDetail.SalesCode; // 販売区分コード
                row.SalesCdNm_Prime = salesDetail.SalesCdNm; // 販売区分名称
                row.WorkManHour_Prime = salesDetail.WorkManHour; // 作業工数
                row.ShipmentCnt_Prime = salesDetail.ShipmentCnt; // 出荷数
                row.AcceptAnOrderCnt_Prime = salesDetail.AcceptAnOrderCnt; // 受注数量
                row.AcptAnOdrAdjustCnt_Prime = salesDetail.AcptAnOdrAdjustCnt; // 受注調整数
                row.AcptAnOdrRemainCnt_Prime = salesDetail.AcptAnOdrRemainCnt; // 受注残数
                row.RemainCntUpdDate_Prime = salesDetail.RemainCntUpdDate; // 残数更新日
                row.SalesMoneyTaxInc_Prime = salesDetail.SalesMoneyTaxInc; // 売上金額（税込み）
                row.SalesMoneyTaxExc_Prime = salesDetail.SalesMoneyTaxExc; // 売上金額（税抜き）
                row.Cost_Prime = salesDetail.Cost; // 原価
                row.GrsProfitChkDiv_Prime = salesDetail.GrsProfitChkDiv; // 粗利チェック区分
                row.SalesGoodsCd_Prime = salesDetail.SalesGoodsCd; // 売上商品区分
                row.SalesPriceConsTax_Prime = salesDetail.SalesPriceConsTax; // 売上金額消費税額
                row.TaxationDivCd_Prime = salesDetail.TaxationDivCd; // 課税区分
                row.PartySlipNumDtl_Prime = salesDetail.PartySlipNumDtl; // 相手先伝票番号（明細）
                row.DtlNote_Prime = salesDetail.DtlNote; // 明細備考
                row.SupplierCd_Prime = salesDetail.SupplierCd; // 仕入先コード
                row.SupplierSnm_Prime = salesDetail.SupplierSnm; // 仕入先略称
                row.OrderNumber_Prime = salesDetail.OrderNumber; // 発注番号
                row.WayToOrder_Prime = salesDetail.WayToOrder; // 注文方法
                row.SlipMemo1_Prime = salesDetail.SlipMemo1; // 伝票メモ１
                row.SlipMemo2_Prime = salesDetail.SlipMemo2; // 伝票メモ２
                row.SlipMemo3_Prime = salesDetail.SlipMemo3; // 伝票メモ３
                row.InsideMemo1_Prime = salesDetail.InsideMemo1; // 社内メモ１
                row.InsideMemo2_Prime = salesDetail.InsideMemo2; // 社内メモ２
                row.InsideMemo3_Prime = salesDetail.InsideMemo3; // 社内メモ３
                row.BfListPrice_Prime = salesDetail.BfListPrice; // 変更前定価
                row.BfSalesUnitPrice_Prime = salesDetail.BfSalesUnitPrice; // 変更前売価
                row.BfUnitCost_Prime = salesDetail.BfUnitCost; // 変更前原価
                row.CmpltSalesRowNo_Prime = salesDetail.CmpltSalesRowNo; // 一式明細番号
                row.CmpltGoodsMakerCd_Prime = salesDetail.CmpltGoodsMakerCd; // メーカーコード（一式）
                row.CmpltMakerName_Prime = salesDetail.CmpltMakerName; // メーカー名称（一式）
                row.CmpltMakerKanaName_Prime = salesDetail.CmpltMakerKanaName; // メーカーカナ名称（一式）
                row.CmpltGoodsName_Prime = salesDetail.CmpltGoodsName; // 商品名称（一式）
                row.CmpltShipmentCnt_Prime = salesDetail.CmpltShipmentCnt; // 数量（一式）
                row.CmpltSalesUnPrcFl_Prime = salesDetail.CmpltSalesUnPrcFl; // 売上単価（一式）
                row.CmpltSalesMoney_Prime = salesDetail.CmpltSalesMoney; // 売上金額（一式）
                row.CmpltSalesUnitCost_Prime = salesDetail.CmpltSalesUnitCost; // 原価単価（一式）
                row.CmpltCost_Prime = salesDetail.CmpltCost; // 原価金額（一式）
                row.CmpltPartySalSlNum_Prime = salesDetail.CmpltPartySalSlNum; // 相手先伝票番号（一式）
                row.CmpltNote_Prime = salesDetail.CmpltNote; // 一式備考
                row.PrtGoodsNo_Prime = salesDetail.PrtGoodsNo; // 印刷用品番
                row.PrtMakerCode_Prime = salesDetail.PrtMakerCode; // 印刷用メーカーコード
                row.PrtMakerName_Prime = salesDetail.PrtMakerName; // 印刷用メーカー名称

                row.DtlRelationGuid_Prime = salesDetail.DtlRelationGuid; // 共通キー
                //row.SalesRowNoDisplay = salesDetail.SalesRowNoDisplay; // 行番号（表示用）
                //row.SupplierStock = salesDetail.SupplierStock; // 現在庫数
                //row.SupplierStockDisplay = salesDetail.SupplierStockDisplay; // 現在庫数（表示用）
                //row.OpenPriceDivDisplay = salesDetail.OpenPriceDivDisplay; // オープン価格区分（表示用）
                //row.ListPriceDisplay = salesDetail.ListPriceDisplay; // 定価（表示用）
                //row.SalesUnPrcDisplay = salesDetail.SalesUnPrcDisplay; // 売上単価（表示用）
                //row.SalesUnitCostTaxExc = salesDetail.SalesUnitCostTaxExc; // 原価単価（税抜）
                //row.SalesUnitCostTaxInc = salesDetail.SalesUnitCostTaxInc; // 原価単価（税込）
                //row.ShipmentCntDisplay = salesDetail.ShipmentCntDisplay; // 出荷数（表示用）
                //row.AddUpEnableCnt = salesDetail.AddUpEnableCnt; // 計上可能数
                //row.AlreadyAddUpCnt = salesDetail.AlreadyAddUpCnt; // 計上済数
                //row.ShipmentCntDefault = salesDetail.ShipmentCntDefault; // 出荷数（初期値）
                //row.SalesMoneyDisplay = salesDetail.SalesMoneyDisplay; // 売上金額（表示用）
                //row.CostTaxInc = salesDetail.CostTaxInc; // 原価金額（税込）
                //row.CostTaxExc = salesDetail.CostTaxExc; // 原価金額（税抜）
                //row.AcceptAnOrderCntDisplay = salesDetail.AcceptAnOrderCntDisplay; // 受注数（表示用）
                //row.AcceptAnOrderCntDefault = salesDetail.AcceptAnOrderCntDefault; // 受注数（初期値）
                //row.TaxDiv = salesDetail.TaxDiv; // 課税区分（UI用）
                //row.CanTaxDivChange = salesDetail.CanTaxDivChange; // 課税非課税区分変更可能フラグ
                //row.RowStatus = salesDetail.RowStatus; // 行ステータス
                //row.EditStatus = salesDetail.EditStatus; // エディットステータス
                //row.SlipMemoExist = salesDetail.SlipMemoExist; // メモ存在フラグ
                //row.SupplierSlipExist = salesDetail.SupplierSlipExist; // 仕入情報存在フラグ
                //row.DetailGrossProfitRate = salesDetail.DetailGrossProfitRate; // 明細粗利率
                //row.CostUpRate = salesDetail.CostUpRate; // 原価アップ率
                //row.GrossProfitSecureRate = salesDetail.GrossProfitSecureRate; // 粗利確保率
                //row.SupplierCdForStock = salesDetail.SupplierCdForStock; // 仕入先コード
                //row.StockDate = salesDetail.StockDate; // 仕入日
                //row.PartySalesSlipNum = salesDetail.PartySalesSlipNum; // 仕入伝票番号
                //row.BoCode = salesDetail.BoCode; // BO区分
                //row.SupplierCdForOrder = salesDetail.SupplierCdForOrder; // 発注先
                //row.AcceptAnOrderCntForOrder = salesDetail.AcceptAnOrderCntForOrder; // 発注数
                //row.SupplierSnmForOrder = salesDetail.SupplierSnmForOrder; // 発注先名称
                //row.DeliveredGoodsDiv = salesDetail.DeliveredGoodsDiv; // 納品区分
                //row.DeliveredGoodsDivNm = salesDetail.DeliveredGoodsDivNm; // 納品区分名称
                //row.DeliveredGoodsDivNmSave = salesDetail.DeliveredGoodsDivNmSave; // 納品区分名称（保存用）
                //row.FollowDeliGoodsDiv = salesDetail.FollowDeliGoodsDiv; // H納品区分
                //row.FollowDeliGoodsDivNm = salesDetail.FollowDeliGoodsDivNm; // H納品区分名称
                //row.FollowDeliGoodsDivNmSave = salesDetail.FollowDeliGoodsDivNmSave; // H納品区分名称（保存用）
                //row.UOEResvdSection = salesDetail.UOEResvdSection; // 指定拠点
                //row.UOEResvdSectionNm = salesDetail.UOEResvdSectionNm; // 指定拠点名称
                //row.UOEResvdSectionNmSave = salesDetail.UOEResvdSectionNmSave; // 指定拠点名称（保存用）
                //row.PriceStartDate = salesDetail.PriceStartDate; // 新定価適用日
                //row.Dummy = salesDetail.Dummy; // ダミー（空欄表示用）
                //row.SearchPartsModeState = salesDetail.SearchPartsModeState; // 部品検索状態

                //-----------------------------------------------------------------------------
                // 売単価、定価（表示用）
                //-----------------------------------------------------------------------------
                if (salesSlip.TotalAmountDispWayCd == 0)
                {
                    // 総額表示しない
                    switch ((CalculateTax.TaxationCode)salesDetail.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            row.ListPriceDisplay_Prime = salesDetail.ListPriceTaxExcFl;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            row.ListPriceDisplay_Prime = salesDetail.ListPriceTaxIncFl;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            row.ListPriceDisplay_Prime = salesDetail.ListPriceTaxExcFl;
                            break;
                    }
                }
                else
                {
                    // 総額表示する
                    switch ((CalculateTax.TaxationCode)salesDetail.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            row.ListPriceDisplay_Prime = salesDetail.ListPriceTaxIncFl;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            row.ListPriceDisplay_Prime = salesDetail.ListPriceTaxIncFl;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            row.ListPriceDisplay_Prime = salesDetail.ListPriceTaxIncFl;
                            break;
                    }
                }

                //-----------------------------------------------------------------------------
                // 数量関係
                //-----------------------------------------------------------------------------
                row.ShipmentCnt_Prime = salesDetail.ShipmentCnt;
                row.AcceptAnOrderCnt_Prime = salesDetail.AcceptAnOrderCnt;
                row.AlreadyAddUpCnt_Prime = (double)( (decimal)salesDetail.ShipmentCnt - (decimal)salesDetail.AcptAnOdrRemainCnt );

                //-----------------------------------------------------------------------------
                // その他補正
                //-----------------------------------------------------------------------------

                // 車輌情報共通キー
                row.CarRelationGuid = Guid.Empty;
                // 検索部品データセットリンクGUID
                row.PartsInfoLinkGuid_Prime = Guid.Empty;
                // 優良情報連結GUID
                row.PrimeInfoRelationGuid = Guid.Empty;
                // 発注情報GUID
                row.UOEOrderGuid_Prime = Guid.Empty;

                // UPD 2012/12/27 T.Miyamoto ------------------------------>>>>>
                //if (string.IsNullOrEmpty(row.GoodsName))
                if (string.IsNullOrEmpty(row.GoodsName) && row.BLGoodsCode == 0 && row.BLGoodsCode_Prime != 0)
                // UPD 2012/12/27 T.Miyamoto ------------------------------<<<<<
                {
                    row.GoodsName = row.GoodsName_Prime;
                    row.BLGoodsCode = row.BLGoodsCode_Prime;
                }

                // RowStatus
                row.RowStatus = ctROWSTATUS_NORMAL;
            }
            // 明細共通キー
            //this.SettingEstimateDetailRowDtlRelationGuid(targetData, row);//DEL 2011/02/14
            SettingEstimateDetailRowDtlRelationGuid(targetData, row);//ADD 2011/02/14
        }

        /// <summary>
        /// 見積明細データテーブルより売上明細データオブジェクトリストを取得します。
        /// </summary>
        /// <param name="dataGetMode">データ取得モード</param>
        /// <param name="estmDtlTable">見積明細データテーブル</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="detailAddInfoDictionary">明細追加情報ディクショナリ</param>
        private void GetUIDataFromTable(DataGetMode dataGetMode, EstimateInputDataSet.EstimateDetailDataTable estmDtlTable, out List<SalesDetail> salesDetailList, out Dictionary<int, Dictionary<string, object>> detailAddInfoDictionary)
        {
            salesDetailList = new List<SalesDetail>();
            detailAddInfoDictionary = new Dictionary<int, Dictionary<string, object>>();

            foreach (EstimateInputDataSet.EstimateDetailRow row in estmDtlTable)
            {
                if (!this.ExistDetailInput(row)) continue;
                SalesDetail salesDetail_PureParts = null;
                SalesDetail salesDetail_PrimeParts = null;
                bool inputData_PureParts = ( !string.IsNullOrEmpty(row.GoodsNo) );
                bool inputData_PrimeParts = ( !string.IsNullOrEmpty(row.GoodsNo_Prime) );

                switch (dataGetMode)
                {
                    // 全て
                    case DataGetMode.All:
                        salesDetail_PureParts = ( inputData_PureParts ) ? this.GetUIDataFromRow(TargetData.PureParts, (int)SalesRowDerivNo.PureParts, row) : null;
                        salesDetail_PrimeParts = ( inputData_PrimeParts ) ? this.GetUIDataFromRow(TargetData.PrimeParts, (int)SalesRowDerivNo.PrimeParts, row) : null;
                        break;
                    // 純正部品のみ
                    case DataGetMode.PurePartsOnly:
                        salesDetail_PureParts = ( inputData_PureParts ) ? this.GetUIDataFromRow(TargetData.PureParts, (int)SalesRowDerivNo.PureParts, row) : null;
                        break;
                    // 優良部品のみ
                    case DataGetMode.PrimePartsOnly:
                        salesDetail_PrimeParts = ( inputData_PrimeParts ) ? this.GetUIDataFromRow(TargetData.PrimeParts, (int)SalesRowDerivNo.PureParts, row) : null;
                        break;
                    // 選択分のみ
                    case DataGetMode.SelectedPartsOnly:
                        salesDetail_PureParts = ( inputData_PureParts && row.PrintSelect ) ? this.GetUIDataFromRow(TargetData.PureParts, (int)SalesRowDerivNo.PureParts, row) : null;
                        salesDetail_PrimeParts = ( inputData_PrimeParts && row.PrintSelect_Prime ) ? this.GetUIDataFromRow(TargetData.PrimeParts, (int)SalesRowDerivNo.PrimeParts, row) : null;

                        break;
                }

                if (salesDetail_PureParts != null)
                {
                    salesDetailList.Add(salesDetail_PureParts);
                }

                if (salesDetail_PrimeParts != null)
                {
                    salesDetailList.Add(salesDetail_PrimeParts);
                }

                // 明細追加情報の設定
                if (inputData_PureParts || inputData_PrimeParts)
                {
                    Dictionary<string, object> rowAddInfo = new Dictionary<string, object>();
                    rowAddInfo.Add(estmDtlTable.PrintSelectColumn.ColumnName, row.PrintSelect);                     // 印刷(純正)
                    rowAddInfo.Add(estmDtlTable.PrintSelect_PrimeColumn.ColumnName, row.PrintSelect_Prime);         // 印刷(優良)
                    rowAddInfo.Add(estmDtlTable.CtlgPartsNoColumn.ColumnName, row.CtlgPartsNo);                     // カタログ品番
                    rowAddInfo.Add(estmDtlTable.JoinSourPartsNoWithHColumn.ColumnName, row.JoinSourPartsNoWithH);   // 結合元品番
                    rowAddInfo.Add(estmDtlTable.SpecialNoteColumn.ColumnName, row.SpecialNote);                     // オプション
                    rowAddInfo.Add(estmDtlTable.StandardNameColumn.ColumnName, row.StandardName);                   // 規格
                    detailAddInfoDictionary.Add(row.SalesRowNo, rowAddInfo);
                }
            }
        }

        /// <summary>
        /// 売上明細データ行オブジェクトより売上明細データオブジェクトを取得します。
        /// </summary>
        /// <param name="targetData">対象データ</param>
        /// <param name="salesRowDerivNo">売上行枝番</param>
        /// <param name="row">売上明細データ行オブジェクト</param>
        /// <returns>売上明細データオブジェクト</returns>
        private SalesDetail GetUIDataFromRow(TargetData targetData, int salesRowDerivNo, EstimateInputDataSet.EstimateDetailRow row)
        {
            SalesDetail salesDetail = null;

            // 売上明細データを取得
            salesDetail = new SalesDetail();

            //-----------------------------------------------------------------------------
            // 共通ファイルヘッダ情報
            //-----------------------------------------------------------------------------
            //salesDetail.CreateDateTime = row.CreateDateTime; // 作成日時
            //salesDetail.UpdateDateTime = row.UpdateDateTime; // 更新日時
            //salesDetail.EnterpriseCode = row.EnterpriseCode; // 企業コード
            //salesDetail.FileHeaderGuid = row.FileHeaderGuid; // GUID
            //salesDetail.UpdEmployeeCode = row.UpdEmployeeCode; // 更新従業員コード
            //salesDetail.UpdAssemblyId1 = row.UpdAssemblyId1; // 更新アセンブリID1
            //salesDetail.UpdAssemblyId2 = row.UpdAssemblyId2; // 更新アセンブリID2
            //salesDetail.LogicalDeleteCode = row.LogicalDeleteCode; // 論理削除区分

            //-----------------------------------------------------------------------------
            // テーブル項目（共通）
            //-----------------------------------------------------------------------------
            salesDetail.AcceptAnOrderNo = row.AcceptAnOrderNo; // 受注番号
            salesDetail.AcptAnOdrStatus = row.AcptAnOdrStatus; // 受注ステータス
            salesDetail.SalesSlipNum = row.SalesSlipNum; // 売上伝票番号
            salesDetail.SalesRowNo = row.SalesRowNo; // 売上行番号
            //salesDetail.SectionCode = row.SectionCode; // 拠点コード
            //salesDetail.SubSectionCode = row.SubSectionCode; // 部門コード
            //salesDetail.SalesDate = row.SalesDate; // 売上日付
            // DEL 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------>>>>>
            // --- ADD 2012/05/08 ---------------->>>>>>>>>>>>>>
            //salesDetail.GoodsSpecialNote = row.SpecialNote;
            // --- ADD 2012/05/08 ----------------<<<<<<<<<<<<<<
            // DEL 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------<<<<<

            if (targetData == TargetData.PureParts)
            {
                //-----------------------------------------------------------------------------
                // テーブル項目
                //-----------------------------------------------------------------------------
                salesDetail.SalesRowDerivNo = salesRowDerivNo; // 売上行番号枝番
                salesDetail.CommonSeqNo = row.CommonSeqNo; // 共通通番
                salesDetail.SalesSlipDtlNum = row.SalesSlipDtlNum; // 売上明細通番
                salesDetail.AcptAnOdrStatusSrc = row.AcptAnOdrStatusSrc; // 受注ステータス（元）
                salesDetail.SalesSlipDtlNumSrc = row.SalesSlipDtlNumSrc; // 売上明細通番（元）
                salesDetail.SupplierFormalSync = row.SupplierFormalSync; // 仕入形式（同時）
                salesDetail.StockSlipDtlNumSync = row.StockSlipDtlNumSync; // 仕入明細通番（同時）
                //salesDetail.SalesSlipCdDtl = row.SalesSlipCdDtl; // 売上伝票区分（明細）
                //salesDetail.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate; // 納品完了予定日
                salesDetail.GoodsKindCode = row.GoodsKindCode; // 商品属性
                salesDetail.GoodsSearchDivCd = row.GoodsSearchDivCd; // 商品検索区分
                salesDetail.GoodsMakerCd = row.GoodsMakerCd; // 商品メーカーコード
                salesDetail.MakerName = row.MakerName; // メーカー名称
                salesDetail.MakerKanaName = row.MakerKanaName; // メーカーカナ名称
                salesDetail.CmpltMakerKanaName = row.CmpltMakerKanaName; // メーカーカナ名称（一式）
                salesDetail.GoodsNo = row.GoodsNo; // 商品番号
                salesDetail.GoodsName = row.GoodsName; // 商品名称
                salesDetail.GoodsNameKana = row.GoodsNameKana; // 商品名称カナ
                salesDetail.GoodsLGroup = row.GoodsLGroup; // 商品大分類コード
                salesDetail.GoodsLGroupName = row.GoodsLGroupName; // 商品大分類名称
                salesDetail.GoodsMGroup = row.GoodsMGroup; // 商品中分類コード
                salesDetail.GoodsMGroupName = row.GoodsMGroupName; // 商品中分類名称
                salesDetail.BLGroupCode = row.BLGroupCode; // BLグループコード
                salesDetail.BLGroupName = row.BLGroupName; // BLグループコード名称
                salesDetail.BLGoodsCode = row.BLGoodsCode; // BL商品コード
                salesDetail.BLGoodsFullName = row.BLGoodsFullName; // BL商品コード名称（全角）
                salesDetail.EnterpriseGanreCode = row.EnterpriseGanreCode; // 自社分類コード
                salesDetail.EnterpriseGanreName = row.EnterpriseGanreName; // 自社分類名称
                salesDetail.WarehouseCode = row.WarehouseCode; // 倉庫コード
                salesDetail.WarehouseName = row.WarehouseName; // 倉庫名称
                salesDetail.WarehouseShelfNo = row.WarehouseShelfNo; // 倉庫棚番
                salesDetail.SalesOrderDivCd = row.SalesOrderDivCd; // 売上在庫取寄せ区分
                salesDetail.OpenPriceDiv = row.OpenPriceDiv; // オープン価格区分
                salesDetail.GoodsRateRank = row.GoodsRateRank; // 商品掛率ランク
                salesDetail.CustRateGrpCode = row.CustRateGrpCode; // 得意先掛率グループコード
                salesDetail.ListPriceRate = row.ListPriceRate; // 定価率
                salesDetail.RateSectPriceUnPrc = row.RateSectPriceUnPrc; // 掛率設定拠点（定価）
                salesDetail.RateDivLPrice = row.RateDivLPrice; // 掛率設定区分（定価）
                salesDetail.UnPrcCalcCdLPrice = row.UnPrcCalcCdLPrice; // 単価算出区分（定価）
                salesDetail.PriceCdLPrice = row.PriceCdLPrice; // 価格区分（定価）
                salesDetail.StdUnPrcLPrice = row.StdUnPrcLPrice; // 基準単価（定価）
                salesDetail.FracProcUnitLPrice = row.FracProcUnitLPrice; // 端数処理単位（定価）
                salesDetail.FracProcLPrice = row.FracProcLPrice; // 端数処理（定価）
                salesDetail.ListPriceTaxIncFl = row.ListPriceTaxIncFl; // 定価（税込，浮動）
                salesDetail.ListPriceTaxExcFl = row.ListPriceTaxExcFl; // 定価（税抜，浮動）
                salesDetail.ListPriceChngCd = row.ListPriceChngCd; // 定価変更区分
                salesDetail.SalesRate = row.SalesRate; // 売価率
                salesDetail.RateSectSalUnPrc = row.RateSectSalUnPrc; // 掛率設定拠点（売上単価）
                salesDetail.RateDivSalUnPrc = row.RateDivSalUnPrc; // 掛率設定区分（売上単価）
                salesDetail.UnPrcCalcCdSalUnPrc = row.UnPrcCalcCdSalUnPrc; // 単価算出区分（売上単価）
                salesDetail.PriceCdSalUnPrc = row.PriceCdSalUnPrc; // 価格区分（売上単価）
                salesDetail.StdUnPrcSalUnPrc = row.StdUnPrcSalUnPrc; // 基準単価（売上単価）
                salesDetail.FracProcUnitSalUnPrc = row.FracProcUnitSalUnPrc; // 端数処理単位（売上単価）
                salesDetail.FracProcSalUnPrc = row.FracProcSalUnPrc; // 端数処理（売上単価）
                salesDetail.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
                salesDetail.SalesUnPrcTaxExcFl = row.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
                salesDetail.SalesUnPrcChngCd = row.SalesUnPrcChngCd; // 売上単価変更区分
                salesDetail.CostRate = row.CostRate; // 原価率
                salesDetail.RateSectCstUnPrc = row.RateSectCstUnPrc; // 掛率設定拠点（原価単価）
                salesDetail.RateDivUnCst = row.RateDivUnCst; // 掛率設定区分（原価単価）
                salesDetail.UnPrcCalcCdUnCst = row.UnPrcCalcCdUnCst; // 単価算出区分（原価単価）
                salesDetail.PriceCdUnCst = row.PriceCdUnCst; // 価格区分（原価単価）
                salesDetail.StdUnPrcUnCst = row.StdUnPrcUnCst; // 基準単価（原価単価）
                salesDetail.FracProcUnitUnCst = row.FracProcUnitUnCst; // 端数処理単位（原価単価）
                salesDetail.FracProcUnCst = row.FracProcUnCst; // 端数処理（原価単価）
                salesDetail.SalesUnitCost = row.SalesUnitCost; // 原価単価
                salesDetail.SalesUnitCostChngDiv = row.SalesUnitCostChngDiv; // 原価単価変更区分
                salesDetail.RateBLGoodsCode = row.RateBLGoodsCode; // BL商品コード（掛率）
                salesDetail.RateBLGoodsName = row.RateBLGoodsName; // BL商品コード名称（掛率）
                salesDetail.RateGoodsRateGrpCd = row.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
                salesDetail.RateGoodsRateGrpNm = row.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
                salesDetail.RateBLGroupCode = row.RateBLGroupCode; // BLグループコード（掛率）
                salesDetail.RateBLGroupName = row.RateBLGroupName; // BLグループ名称（掛率）
                salesDetail.PrtBLGoodsCode = row.PrtBLGoodsCode; // BL商品コード（印刷）
                salesDetail.PrtBLGoodsName = row.PrtBLGoodsName; // BL商品コード名称（印刷）
                salesDetail.SalesCode = row.SalesCode; // 販売区分コード
                salesDetail.SalesCdNm = row.SalesCdNm; // 販売区分名称
                salesDetail.WorkManHour = row.WorkManHour; // 作業工数
                salesDetail.ShipmentCnt = row.ShipmentCnt; // 出荷数
                salesDetail.AcceptAnOrderCnt = row.AcceptAnOrderCnt; // 受注数量
                salesDetail.AcptAnOdrAdjustCnt = row.AcptAnOdrAdjustCnt; // 受注調整数
                salesDetail.AcptAnOdrRemainCnt = row.AcptAnOdrRemainCnt; // 受注残数
                salesDetail.RemainCntUpdDate = row.RemainCntUpdDate; // 残数更新日
                salesDetail.SalesMoneyTaxInc = row.SalesMoneyTaxInc; // 売上金額（税込み）
                salesDetail.SalesMoneyTaxExc = row.SalesMoneyTaxExc; // 売上金額（税抜き）
                salesDetail.Cost = row.Cost; // 原価
                salesDetail.GrsProfitChkDiv = row.GrsProfitChkDiv; // 粗利チェック区分
                salesDetail.SalesGoodsCd = row.SalesGoodsCd; // 売上商品区分
                salesDetail.SalesPriceConsTax = row.SalesPriceConsTax; // 売上金額消費税額
                salesDetail.TaxationDivCd = row.TaxationDivCd; // 課税区分
                salesDetail.PartySlipNumDtl = row.PartySlipNumDtl; // 相手先伝票番号（明細）
                salesDetail.DtlNote = row.DtlNote; // 明細備考
                salesDetail.SupplierCd = row.SupplierCd; // 仕入先コード
                salesDetail.SupplierSnm = row.SupplierSnm; // 仕入先略称
                salesDetail.OrderNumber = row.OrderNumber; // 発注番号
                salesDetail.WayToOrder = row.WayToOrder; // 注文方法

                salesDetail.BfListPrice = row.BfListPrice; // 変更前定価
                salesDetail.BfSalesUnitPrice = row.BfSalesUnitPrice; // 変更前売価
                salesDetail.BfUnitCost = row.BfUnitCost; // 変更前原価

                salesDetail.PrtGoodsNo = row.PrtGoodsNo; // 印刷用品番
                salesDetail.PrtMakerCode = row.PrtMakerCode; // 印刷用メーカーコード
                salesDetail.PrtMakerName = row.PrtMakerName; // 印刷用メーカー名称

                //-----------------------------------------------------------------------------
                // ＰＧ間使用項目
                //-----------------------------------------------------------------------------
                salesDetail.DtlRelationGuid = row.DtlRelationGuid; // 共通キー
                salesDetail.CarRelationGuid = row.CarRelationGuid; // 車輌情報共通キー
                //salesDetail.SalesRowNoDisplay = row.SalesRowNoDisplay; // 行番号（表示用）
                //salesDetail.SupplierStock = row.SupplierStock; // 現在庫数
                //salesDetail.SupplierStockDisplay = row.SupplierStockDisplay; // 現在庫数（表示用）
                //salesDetail.OpenPriceDivDisplay = row.OpenPriceDivDisplay; // オープン価格区分（表示用）
                //salesDetail.ListPriceDisplay = row.ListPriceDisplay; // 定価（表示用）
                //salesDetail.SalesUnPrcDisplay = row.SalesUnPrcDisplay; // 売上単価（表示用）
                //salesDetail.SalesUnitCostTaxExc = row.SalesUnitCostTaxExc; // 原価単価（税抜）
                //salesDetail.SalesUnitCostTaxInc = row.SalesUnitCostTaxInc; // 原価単価（税込）
                //salesDetail.ShipmentCntDisplay = row.ShipmentCntDisplay; // 出荷数（表示用）
                //salesDetail.AddUpEnableCnt = row.AddUpEnableCnt; // 計上可能数
                //salesDetail.AlreadyAddUpCnt = row.AlreadyAddUpCnt; // 計上済数
                //salesDetail.ShipmentCntDefault = row.ShipmentCntDefault; // 出荷数（初期値）
                //salesDetail.SalesMoneyDisplay = row.SalesMoneyDisplay; // 売上金額（表示用）
                //salesDetail.CostTaxInc = row.CostTaxInc; // 原価金額（税込）
                //salesDetail.CostTaxExc = row.CostTaxExc; // 原価金額（税抜）
                //salesDetail.AcceptAnOrderCntDisplay = row.AcceptAnOrderCntDisplay; // 受注数（表示用）
                //salesDetail.AcceptAnOrderCntDefault = row.AcceptAnOrderCntDefault; // 受注数（初期値）
                //salesDetail.TaxDiv = row.TaxDiv; // 課税区分（UI用）
                //salesDetail.CanTaxDivChange = row.CanTaxDivChange; // 課税非課税区分変更可能フラグ
                //salesDetail.RowStatus = row.RowStatus; // 行ステータス
                //salesDetail.EditStatus = row.EditStatus; // エディットステータス
                //salesDetail.SlipMemoExist = row.SlipMemoExist; // メモ存在フラグ
                //salesDetail.SupplierSlipExist = row.SupplierSlipExist; // 仕入情報存在フラグ
                //salesDetail.DetailGrossProfitRate = row.DetailGrossProfitRate; // 明細粗利率
                //salesDetail.CostUpRate = row.CostUpRate; // 原価アップ率
                //salesDetail.GrossProfitSecureRate = row.GrossProfitSecureRate; // 粗利確保率
                //salesDetail.SupplierCdForStock = row.SupplierCdForStock; // 仕入先コード
                //salesDetail.StockDate = row.StockDate; // 仕入日
                //salesDetail.PartySalesSlipNum = row.PartySalesSlipNum; // 仕入伝票番号
                //salesDetail.BoCode = row.BoCode; // BO区分
                //salesDetail.SupplierCdForOrder = row.SupplierCdForOrder; // 発注先
                //salesDetail.AcceptAnOrderCntForOrder = row.AcceptAnOrderCntForOrder; // 発注数
                //salesDetail.SupplierSnmForOrder = row.SupplierSnmForOrder; // 発注先名称
                //salesDetail.DeliveredGoodsDiv = row.DeliveredGoodsDiv; // 納品区分
                //salesDetail.DeliveredGoodsDivNm = row.DeliveredGoodsDivNm; // 納品区分名称
                //salesDetail.DeliveredGoodsDivNmSave = row.DeliveredGoodsDivNmSave; // 納品区分名称（保存用）
                //salesDetail.FollowDeliGoodsDiv = row.FollowDeliGoodsDiv; // H納品区分
                //salesDetail.FollowDeliGoodsDivNm = row.FollowDeliGoodsDivNm; // H納品区分名称
                //salesDetail.FollowDeliGoodsDivNmSave = row.FollowDeliGoodsDivNmSave; // H納品区分名称（保存用）
                //salesDetail.UOEResvdSection = row.UOEResvdSection; // 指定拠点
                //salesDetail.UOEResvdSectionNm = row.UOEResvdSectionNm; // 指定拠点名称
                //salesDetail.UOEResvdSectionNmSave = row.UOEResvdSectionNmSave; // 指定拠点名称（保存用）
                //salesDetail.PriceStartDate = row.PriceStartDate; // 新定価適用日
                //salesDetail.Dummy = row.Dummy; // ダミー（空欄表示用）
                //salesDetail.SearchPartsModeState = row.SearchPartsModeState; // 部品検索状態


                salesDetail.GoodsSearchDivCd = row.GoodsSearchDivCd;            // 商品検索区分
                salesDetail.SalesOrderDivCd = ( string.IsNullOrEmpty(salesDetail.WarehouseCode) ) ? 0 : 1;  // 売上在庫取寄せ区分

                // 受注数量
                salesDetail.AcceptAnOrderCnt = ( salesDetail.SalesSlipDtlNum == 0 ) ? row.ShipmentCnt : row.AcceptAnOrderCnt; // 新規作成or既存修正
                // ADD 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------>>>>>
                salesDetail.GoodsSpecialNote = row.SpecialNote;
                // ADD 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------<<<<<
            }
            else if (targetData == TargetData.PrimeParts)
            {
                //-----------------------------------------------------------------------------
                // テーブル項目
                //-----------------------------------------------------------------------------
                salesDetail.SalesRowDerivNo = salesRowDerivNo; // 売上行番号枝番
                salesDetail.CommonSeqNo = row.CommonSeqNo_Prime; // 共通通番
                salesDetail.SalesSlipDtlNum = row.SalesSlipDtlNum_Prime; // 売上明細通番
                salesDetail.AcptAnOdrStatusSrc = row.AcptAnOdrStatusSrc_Prime; // 受注ステータス（元）
                salesDetail.SalesSlipDtlNumSrc = row.SalesSlipDtlNumSrc_Prime; // 売上明細通番（元）
                salesDetail.SupplierFormalSync = row.SupplierFormalSync_Prime; // 仕入形式（同時）
                salesDetail.StockSlipDtlNumSync = row.StockSlipDtlNumSync_Prime; // 仕入明細通番（同時）
                //salesDetail.SalesSlipCdDtl = row.SalesSlipCdDtl; // 売上伝票区分（明細）
                //salesDetail.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate; // 納品完了予定日
                salesDetail.GoodsKindCode = row.GoodsKindCode_Prime; // 商品属性
                salesDetail.GoodsSearchDivCd = row.GoodsSearchDivCd_Prime; // 商品検索区分
                salesDetail.GoodsMakerCd = row.GoodsMakerCd_Prime; // 商品メーカーコード
                salesDetail.MakerName = row.MakerName_Prime; // メーカー名称
                salesDetail.MakerKanaName = row.MakerKanaName_Prime; // メーカーカナ名称
                salesDetail.CmpltMakerKanaName = row.CmpltMakerKanaName_Prime; // メーカーカナ名称（一式）
                salesDetail.GoodsNo = row.GoodsNo_Prime; // 商品番号
                salesDetail.GoodsName = row.GoodsName_Prime; // 商品名称
                salesDetail.GoodsNameKana = row.GoodsNameKana_Prime; // 商品名称カナ
                salesDetail.GoodsLGroup = row.GoodsLGroup_Prime; // 商品大分類コード
                salesDetail.GoodsLGroupName = row.GoodsLGroupName_Prime; // 商品大分類名称
                salesDetail.GoodsMGroup = row.GoodsMGroup_Prime; // 商品中分類コード
                salesDetail.GoodsMGroupName = row.GoodsMGroupName_Prime; // 商品中分類名称
                salesDetail.BLGroupCode = row.BLGroupCode_Prime; // BLグループコード
                salesDetail.BLGroupName = row.BLGroupName_Prime; // BLグループコード名称
                salesDetail.BLGoodsCode = row.BLGoodsCode_Prime; // BL商品コード
                salesDetail.BLGoodsFullName = row.BLGoodsFullName_Prime; // BL商品コード名称（全角）
                salesDetail.EnterpriseGanreCode = row.EnterpriseGanreCode_Prime; // 自社分類コード
                salesDetail.EnterpriseGanreName = row.EnterpriseGanreName_Prime; // 自社分類名称
                salesDetail.WarehouseCode = row.WarehouseCode_Prime; // 倉庫コード
                salesDetail.WarehouseName = row.WarehouseName_Prime; // 倉庫名称
                salesDetail.WarehouseShelfNo = row.WarehouseShelfNo_Prime; // 倉庫棚番
                salesDetail.SalesOrderDivCd = row.SalesOrderDivCd_Prime; // 売上在庫取寄せ区分
                salesDetail.OpenPriceDiv = row.OpenPriceDiv_Prime; // オープン価格区分
                salesDetail.GoodsRateRank = row.GoodsRateRank_Prime; // 商品掛率ランク
                salesDetail.CustRateGrpCode = row.CustRateGrpCode_Prime; // 得意先掛率グループコード
                salesDetail.ListPriceRate = row.ListPriceRate_Prime; // 定価率
                salesDetail.RateSectPriceUnPrc = row.RateSectPriceUnPrc_Prime; // 掛率設定拠点（定価）
                salesDetail.RateDivLPrice = row.RateDivLPrice_Prime; // 掛率設定区分（定価）
                salesDetail.UnPrcCalcCdLPrice = row.UnPrcCalcCdLPrice_Prime; // 単価算出区分（定価）
                salesDetail.PriceCdLPrice = row.PriceCdLPrice_Prime; // 価格区分（定価）
                salesDetail.StdUnPrcLPrice = row.StdUnPrcLPrice_Prime; // 基準単価（定価）
                salesDetail.FracProcUnitLPrice = row.FracProcUnitLPrice_Prime; // 端数処理単位（定価）
                salesDetail.FracProcLPrice = row.FracProcLPrice_Prime; // 端数処理（定価）
                salesDetail.ListPriceTaxIncFl = row.ListPriceTaxIncFl_Prime; // 定価（税込，浮動）
                salesDetail.ListPriceTaxExcFl = row.ListPriceTaxExcFl_Prime; // 定価（税抜，浮動）
                salesDetail.ListPriceChngCd = row.ListPriceChngCd_Prime; // 定価変更区分
                salesDetail.SalesRate = row.SalesRate_Prime; // 売価率
                salesDetail.RateSectSalUnPrc = row.RateSectSalUnPrc_Prime; // 掛率設定拠点（売上単価）
                salesDetail.RateDivSalUnPrc = row.RateDivSalUnPrc_Prime; // 掛率設定区分（売上単価）
                salesDetail.UnPrcCalcCdSalUnPrc = row.UnPrcCalcCdSalUnPrc_Prime; // 単価算出区分（売上単価）
                salesDetail.PriceCdSalUnPrc = row.PriceCdSalUnPrc_Prime; // 価格区分（売上単価）
                salesDetail.StdUnPrcSalUnPrc = row.StdUnPrcSalUnPrc_Prime; // 基準単価（売上単価）
                salesDetail.FracProcUnitSalUnPrc = row.FracProcUnitSalUnPrc_Prime; // 端数処理単位（売上単価）
                salesDetail.FracProcSalUnPrc = row.FracProcSalUnPrc_Prime; // 端数処理（売上単価）
                salesDetail.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxIncFl_Prime; // 売上単価（税込，浮動）
                salesDetail.SalesUnPrcTaxExcFl = row.SalesUnPrcTaxExcFl_Prime; // 売上単価（税抜，浮動）
                salesDetail.SalesUnPrcChngCd = row.SalesUnPrcChngCd_Prime; // 売上単価変更区分
                salesDetail.CostRate = row.CostRate_Prime; // 原価率
                salesDetail.RateSectCstUnPrc = row.RateSectCstUnPrc_Prime; // 掛率設定拠点（原価単価）
                salesDetail.RateDivUnCst = row.RateDivUnCst_Prime; // 掛率設定区分（原価単価）
                salesDetail.UnPrcCalcCdUnCst = row.UnPrcCalcCdUnCst_Prime; // 単価算出区分（原価単価）
                salesDetail.PriceCdUnCst = row.PriceCdUnCst_Prime; // 価格区分（原価単価）
                salesDetail.StdUnPrcUnCst = row.StdUnPrcUnCst_Prime; // 基準単価（原価単価）
                salesDetail.FracProcUnitUnCst = row.FracProcUnitUnCst_Prime; // 端数処理単位（原価単価）
                salesDetail.FracProcUnCst = row.FracProcUnCst_Prime; // 端数処理（原価単価）
                salesDetail.SalesUnitCost = row.SalesUnitCost_Prime; // 原価単価
                salesDetail.SalesUnitCostChngDiv = row.SalesUnitCostChngDiv_Prime; // 原価単価変更区分
                salesDetail.RateBLGoodsCode = row.RateBLGoodsCode_Prime; // BL商品コード（掛率）
                salesDetail.RateBLGoodsName = row.RateBLGoodsName_Prime; // BL商品コード名称（掛率）
                salesDetail.RateGoodsRateGrpCd = row.RateGoodsRateGrpCd_Prime; // 商品掛率グループコード（掛率）
                salesDetail.RateGoodsRateGrpNm = row.RateGoodsRateGrpNm_Prime; // 商品掛率グループ名称（掛率）
                salesDetail.RateBLGroupCode = row.RateBLGroupCode_Prime; // BLグループコード（掛率）
                salesDetail.RateBLGroupName = row.RateBLGroupName_Prime; // BLグループ名称（掛率）
                salesDetail.PrtBLGoodsCode = row.PrtBLGoodsCode_Prime; // BL商品コード（印刷）
                salesDetail.PrtBLGoodsName = row.PrtBLGoodsName_Prime; // BL商品コード名称（印刷）
                salesDetail.SalesCode = row.SalesCode_Prime; // 販売区分コード
                salesDetail.SalesCdNm = row.SalesCdNm_Prime; // 販売区分名称
                salesDetail.WorkManHour = row.WorkManHour_Prime; // 作業工数
                salesDetail.ShipmentCnt = row.ShipmentCnt_Prime; // 出荷数
                salesDetail.AcceptAnOrderCnt = row.AcceptAnOrderCnt_Prime; // 受注数量
                salesDetail.AcptAnOdrAdjustCnt = row.AcptAnOdrAdjustCnt_Prime; // 受注調整数
                salesDetail.AcptAnOdrRemainCnt = row.AcptAnOdrRemainCnt_Prime; // 受注残数
                salesDetail.RemainCntUpdDate = row.RemainCntUpdDate_Prime; // 残数更新日
                salesDetail.SalesMoneyTaxInc = row.SalesMoneyTaxInc_Prime; // 売上金額（税込み）
                salesDetail.SalesMoneyTaxExc = row.SalesMoneyTaxExc_Prime; // 売上金額（税抜き）
                salesDetail.Cost = row.Cost_Prime; // 原価
                salesDetail.GrsProfitChkDiv = row.GrsProfitChkDiv_Prime; // 粗利チェック区分
                salesDetail.SalesGoodsCd = row.SalesGoodsCd_Prime; // 売上商品区分
                salesDetail.SalesPriceConsTax = row.SalesPriceConsTax_Prime; // 売上金額消費税額
                salesDetail.TaxationDivCd = row.TaxationDivCd_Prime; // 課税区分
                salesDetail.PartySlipNumDtl = row.PartySlipNumDtl_Prime; // 相手先伝票番号（明細）
                salesDetail.DtlNote = row.DtlNote_Prime; // 明細備考
                salesDetail.SupplierCd = row.SupplierCd_Prime; // 仕入先コード
                salesDetail.SupplierSnm = row.SupplierSnm_Prime; // 仕入先略称
                salesDetail.OrderNumber = row.OrderNumber_Prime; // 発注番号
                salesDetail.WayToOrder = row.WayToOrder_Prime; // 注文方法

                salesDetail.BfListPrice = row.BfListPrice_Prime; // 変更前定価
                salesDetail.BfSalesUnitPrice = row.BfSalesUnitPrice_Prime; // 変更前売価
                salesDetail.BfUnitCost = row.BfUnitCost_Prime; // 変更前原価

                salesDetail.PrtGoodsNo = row.PrtGoodsNo_Prime; // 印刷用品番
                salesDetail.PrtMakerCode = row.PrtMakerCode_Prime; // 印刷用メーカーコード
                salesDetail.PrtMakerName = row.PrtMakerName_Prime; // 印刷用メーカー名称

                //-----------------------------------------------------------------------------
                // ＰＧ間使用項目
                //-----------------------------------------------------------------------------
                salesDetail.DtlRelationGuid = row.DtlRelationGuid_Prime; // 共通キー
                salesDetail.CarRelationGuid = row.CarRelationGuid; // 車輌情報共通キー
                //salesDetail.SalesRowNoDisplay = row.SalesRowNoDisplay; // 行番号（表示用）
                //salesDetail.SupplierStock = row.SupplierStock; // 現在庫数
                //salesDetail.SupplierStockDisplay = row.SupplierStockDisplay; // 現在庫数（表示用）
                //salesDetail.OpenPriceDivDisplay = row.OpenPriceDivDisplay; // オープン価格区分（表示用）
                //salesDetail.ListPriceDisplay = row.ListPriceDisplay; // 定価（表示用）
                //salesDetail.SalesUnPrcDisplay = row.SalesUnPrcDisplay; // 売上単価（表示用）
                //salesDetail.SalesUnitCostTaxExc = row.SalesUnitCostTaxExc; // 原価単価（税抜）
                //salesDetail.SalesUnitCostTaxInc = row.SalesUnitCostTaxInc; // 原価単価（税込）
                //salesDetail.ShipmentCntDisplay = row.ShipmentCntDisplay; // 出荷数（表示用）
                //salesDetail.AddUpEnableCnt = row.AddUpEnableCnt; // 計上可能数
                //salesDetail.AlreadyAddUpCnt = row.AlreadyAddUpCnt; // 計上済数
                //salesDetail.ShipmentCntDefault = row.ShipmentCntDefault; // 出荷数（初期値）
                //salesDetail.SalesMoneyDisplay = row.SalesMoneyDisplay; // 売上金額（表示用）
                //salesDetail.CostTaxInc = row.CostTaxInc; // 原価金額（税込）
                //salesDetail.CostTaxExc = row.CostTaxExc; // 原価金額（税抜）
                //salesDetail.AcceptAnOrderCntDisplay = row.AcceptAnOrderCntDisplay; // 受注数（表示用）
                //salesDetail.AcceptAnOrderCntDefault = row.AcceptAnOrderCntDefault; // 受注数（初期値）
                //salesDetail.TaxDiv = row.TaxDiv; // 課税区分（UI用）
                //salesDetail.CanTaxDivChange = row.CanTaxDivChange; // 課税非課税区分変更可能フラグ
                //salesDetail.RowStatus = row.RowStatus; // 行ステータス
                //salesDetail.EditStatus = row.EditStatus; // エディットステータス
                //salesDetail.SlipMemoExist = row.SlipMemoExist; // メモ存在フラグ
                //salesDetail.SupplierSlipExist = row.SupplierSlipExist; // 仕入情報存在フラグ
                //salesDetail.DetailGrossProfitRate = row.DetailGrossProfitRate; // 明細粗利率
                //salesDetail.CostUpRate = row.CostUpRate; // 原価アップ率
                //salesDetail.GrossProfitSecureRate = row.GrossProfitSecureRate; // 粗利確保率
                //salesDetail.SupplierCdForStock = row.SupplierCdForStock; // 仕入先コード
                //salesDetail.StockDate = row.StockDate; // 仕入日
                //salesDetail.PartySalesSlipNum = row.PartySalesSlipNum; // 仕入伝票番号
                //salesDetail.BoCode = row.BoCode; // BO区分
                //salesDetail.SupplierCdForOrder = row.SupplierCdForOrder; // 発注先
                //salesDetail.AcceptAnOrderCntForOrder = row.AcceptAnOrderCntForOrder; // 発注数
                //salesDetail.SupplierSnmForOrder = row.SupplierSnmForOrder; // 発注先名称
                //salesDetail.DeliveredGoodsDiv = row.DeliveredGoodsDiv; // 納品区分
                //salesDetail.DeliveredGoodsDivNm = row.DeliveredGoodsDivNm; // 納品区分名称
                //salesDetail.DeliveredGoodsDivNmSave = row.DeliveredGoodsDivNmSave; // 納品区分名称（保存用）
                //salesDetail.FollowDeliGoodsDiv = row.FollowDeliGoodsDiv; // H納品区分
                //salesDetail.FollowDeliGoodsDivNm = row.FollowDeliGoodsDivNm; // H納品区分名称
                //salesDetail.FollowDeliGoodsDivNmSave = row.FollowDeliGoodsDivNmSave; // H納品区分名称（保存用）
                //salesDetail.UOEResvdSection = row.UOEResvdSection; // 指定拠点
                //salesDetail.UOEResvdSectionNm = row.UOEResvdSectionNm; // 指定拠点名称
                //salesDetail.UOEResvdSectionNmSave = row.UOEResvdSectionNmSave; // 指定拠点名称（保存用）
                //salesDetail.PriceStartDate = row.PriceStartDate; // 新定価適用日
                //salesDetail.Dummy = row.Dummy; // ダミー（空欄表示用）
                //salesDetail.SearchPartsModeState = row.SearchPartsModeState; // 部品検索状態


                salesDetail.GoodsSearchDivCd = row.GoodsSearchDivCd_Prime;            // 商品検索区分

                salesDetail.SalesOrderDivCd = ( string.IsNullOrEmpty(salesDetail.WarehouseCode) ) ? 0 : 1;  // 売上在庫取寄せ区分


                // 受注数量
                salesDetail.AcceptAnOrderCnt = ( salesDetail.SalesSlipDtlNum == 0 ) ? row.ShipmentCnt_Prime : row.AcceptAnOrderCnt_Prime; // 新規作成or既存修正
                // ADD 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------>>>>>
                salesDetail.GoodsSpecialNote = row.SpecialNote_Prime;
                // ADD 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------<<<<<

                // --- ADD 2013/12/16 Y.Wakita ---------->>>>>
                salesDetail.CmpltSalesRowNo = row.CmpltSalesRowNo_Prime;      // 純正-BL商品コード
                salesDetail.CmpltGoodsMakerCd = row.CmpltGoodsMakerCd_Prime;  // 純正-メーカー
                salesDetail.CmpltGoodsName = row.CmpltGoodsName_Prime;        // 純正-商品番号
                salesDetail.CmpltSalesUnPrcFl = row.CmpltSalesUnPrcFl_Prime;  // 純正-定価
                // --- ADD 2013/12/16 Y.Wakita ----------<<<<<

            }


            //-----------------------------------------------------------------------------
            // 補正
            //-----------------------------------------------------------------------------
            salesDetail.SupplierFormalSync = -1;                            // 仕入形式(同時)：-1
            salesDetail.AcptAnOdrStatus = this._salesSlip.AcptAnOdrStatus;  // 受注ステータス
            salesDetail.SalesSlipNum = this._salesSlip.SalesSlipNum;        // 売上伝票番号
            salesDetail.SectionCode = this._salesSlip.SectionCode;          // 拠点コード
            salesDetail.SubSectionCode = this._salesSlip.SubSectionCode;    // 部門コード
            salesDetail.SalesDate = this._salesSlip.SalesDate;              // 売上日付

            // 売上金額消費税額
            salesDetail.SalesPriceConsTax = salesDetail.SalesMoneyTaxInc - salesDetail.SalesMoneyTaxExc;

            return salesDetail;
        }

        /// <summary>
        /// ＵＯＥ発注データを取得します。
        /// </summary>
        /// <param name="targetData">対象データ</param>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="uoeOrderRow">UOE発注データ行オブジェクト</param>
        /// <param name="uoeOrderDetailRow">UOE発注明細データ行オブジェクト</param>
        /// <param name="estimateDetailRow">見積データ行オブジェクト</param>
        /// <param name="stockDetailWork">仕入明細データワークオブジェクト</param>
        /// <param name="uoeOrderDtlWork">ＵＯＥ発注データワークオブジェクト</param>
        /// <remarks>
        /// <br>Update Note: 2012/10/24 田建委</br>
        /// <br>管理番号   : 10801804-00、2012/11/14配信分</br>
        /// <br>             Redmine#32862 #13の障害 優良データ行ＵＯＥ発注データの変更前定価のセット不正の対応</br>
        /// </remarks>
        private void GetUOEOrderDataFromRow(TargetData targetData, SalesSlip salesSlip, EstimateInputDataSet.UOEOrderRow uoeOrderRow, EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow, EstimateInputDataSet.EstimateDetailRow estimateDetailRow, out StockDetailWork stockDetailWork, out UOEOrderDtlWork uoeOrderDtlWork)
        {
            stockDetailWork = null;
            uoeOrderDtlWork = null;

            if (( uoeOrderRow == null ) || ( uoeOrderDetailRow == null ) || ( estimateDetailRow == null )) return;

            stockDetailWork = new StockDetailWork();
            uoeOrderDtlWork = new UOEOrderDtlWork();

            #region 仕入明細データのセット

            //-----------------------------------------------------------------------------
            // 見積明細データ行からセット
            //-----------------------------------------------------------------------------
            switch (targetData)
            {
                // 純正部品情報からセット
                case TargetData.PureParts:
                    {
                        stockDetailWork.GoodsKindCode = estimateDetailRow.GoodsKindCode;                // 商品属性
                        stockDetailWork.GoodsMakerCd = estimateDetailRow.GoodsMakerCd;                  // 商品メーカーコード
                        stockDetailWork.MakerName = estimateDetailRow.MakerName;                        // メーカー名称
                        stockDetailWork.MakerKanaName = estimateDetailRow.MakerKanaName;                // メーカーカナ名称
                        stockDetailWork.GoodsNo = estimateDetailRow.GoodsNo;                            // 商品番号
                        stockDetailWork.GoodsName = estimateDetailRow.GoodsName;                        // 商品名称
                        stockDetailWork.GoodsNameKana = estimateDetailRow.GoodsNameKana;                // 商品名称カナ
                        stockDetailWork.GoodsLGroup = estimateDetailRow.GoodsLGroup;                    // 商品大分類コード
                        stockDetailWork.GoodsLGroupName = estimateDetailRow.GoodsLGroupName;            // 商品大分類名称
                        stockDetailWork.GoodsMGroup = estimateDetailRow.GoodsMGroup;                    // 商品中分類コード
                        stockDetailWork.GoodsMGroupName = estimateDetailRow.GoodsMGroupName;            // 商品中分類名称
                        stockDetailWork.BLGroupCode = estimateDetailRow.BLGroupCode;                    // BLグループコード
                        stockDetailWork.BLGroupName = estimateDetailRow.BLGroupName;                    // BLグループコード名称
                        stockDetailWork.BLGoodsCode = estimateDetailRow.BLGoodsCode;                    // BL商品コード
                        stockDetailWork.BLGoodsFullName = estimateDetailRow.BLGoodsFullName;            // BL商品コード名称（全角）
                        stockDetailWork.EnterpriseGanreCode = estimateDetailRow.EnterpriseGanreCode;    // 自社分類コード
                        stockDetailWork.EnterpriseGanreName = estimateDetailRow.EnterpriseGanreName;    // 自社分類名称
                        stockDetailWork.WarehouseCode = estimateDetailRow.WarehouseCode;                // 倉庫コード
                        stockDetailWork.WarehouseName = estimateDetailRow.WarehouseName;                // 倉庫名称
                        stockDetailWork.WarehouseShelfNo = estimateDetailRow.WarehouseShelfNo;          // 倉庫棚番
                        stockDetailWork.OpenPriceDiv = estimateDetailRow.OpenPriceDiv;                  // オープン価格区分
                        stockDetailWork.GoodsRateRank = estimateDetailRow.GoodsRateRank;                // 商品掛率ランク
                        stockDetailWork.CustRateGrpCode = estimateDetailRow.CustRateGrpCode;            // 得意先掛率グループコード
                        stockDetailWork.ListPriceTaxExcFl = estimateDetailRow.ListPriceTaxExcFl;        // 定価（税抜，浮動）
                        stockDetailWork.ListPriceTaxIncFl = estimateDetailRow.ListPriceTaxIncFl;        // 定価（税込，浮動）
                        stockDetailWork.StockRate = estimateDetailRow.CostRate;                         // 仕入率
                        stockDetailWork.RateSectStckUnPrc = estimateDetailRow.RateSectCstUnPrc;         // 掛率設定拠点（仕入単価）
                        stockDetailWork.RateDivStckUnPrc = estimateDetailRow.RateDivUnCst;              // 掛率設定区分（仕入単価）
                        stockDetailWork.UnPrcCalcCdStckUnPrc = estimateDetailRow.UnPrcCalcCdUnCst;      // 単価算出区分（仕入単価）
                        stockDetailWork.PriceCdStckUnPrc = estimateDetailRow.PriceCdUnCst;              // 価格区分（仕入単価）
                        stockDetailWork.StdUnPrcStckUnPrc = estimateDetailRow.StdUnPrcUnCst;            // 基準単価（仕入単価）
                        stockDetailWork.FracProcUnitStcUnPrc = estimateDetailRow.FracProcUnitUnCst;     // 端数処理単位（仕入単価）
                        stockDetailWork.FracProcStckUnPrc = estimateDetailRow.FracProcUnCst;            // 端数処理（仕入単価）
                        //stockDetailWork.StockUnitPriceFl = estimateDetailRow.SalesUnitCost;         // 仕入単価（税抜，浮動）
                        if (estimateDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                        {
                            stockDetailWork.StockUnitTaxPriceFl = estimateDetailRow.SalesUnitCost;      // 仕入単価（税込，浮動）
                        }
                        else
                        {
                            stockDetailWork.StockUnitPriceFl = estimateDetailRow.SalesUnitCost;         // 仕入単価（税抜，浮動）
                        }
                        stockDetailWork.StockUnitChngDiv = estimateDetailRow.SalesUnitCostChngDiv;      // 仕入単価変更区分
                        stockDetailWork.BfStockUnitPriceFl = estimateDetailRow.BfUnitCost;              // 変更前仕入単価（浮動）
                        stockDetailWork.BfListPrice = estimateDetailRow.BfListPrice;                    // 変更前定価
                        stockDetailWork.RateBLGoodsCode = estimateDetailRow.RateBLGoodsCode;            // BL商品コード（掛率）
                        stockDetailWork.RateBLGoodsName = estimateDetailRow.RateBLGoodsName;            // BL商品コード名称（掛率）
                        stockDetailWork.RateGoodsRateGrpCd = estimateDetailRow.RateGoodsRateGrpCd;      // 商品掛率グループコード（掛率）
                        stockDetailWork.RateGoodsRateGrpNm = estimateDetailRow.RateGoodsRateGrpNm;      // 商品掛率グループ名称（掛率）
                        stockDetailWork.RateBLGroupCode = estimateDetailRow.RateBLGroupCode;            // BLグループコード（掛率）
                        stockDetailWork.RateBLGroupName = estimateDetailRow.RateBLGroupName;            // BLグループ名称（掛率）
                        stockDetailWork.TaxationCode = estimateDetailRow.TaxationDivCd;                 // 課税区分
                        break;
                    }
                // 優良部品情報からセット
                case TargetData.PrimeParts:
                    {
                        stockDetailWork.GoodsKindCode = estimateDetailRow.GoodsKindCode_Prime;                // 商品属性
                        stockDetailWork.GoodsMakerCd = estimateDetailRow.GoodsMakerCd_Prime;                  // 商品メーカーコード
                        stockDetailWork.MakerName = estimateDetailRow.MakerName_Prime;                        // メーカー名称
                        stockDetailWork.MakerKanaName = estimateDetailRow.MakerKanaName_Prime;                // メーカーカナ名称
                        stockDetailWork.GoodsNo = estimateDetailRow.GoodsNo_Prime;                            // 商品番号
                        stockDetailWork.GoodsName = estimateDetailRow.GoodsName_Prime;                        // 商品名称
                        stockDetailWork.GoodsNameKana = estimateDetailRow.GoodsNameKana_Prime;                // 商品名称カナ
                        stockDetailWork.GoodsLGroup = estimateDetailRow.GoodsLGroup_Prime;                    // 商品大分類コード
                        stockDetailWork.GoodsLGroupName = estimateDetailRow.GoodsLGroupName_Prime;            // 商品大分類名称
                        stockDetailWork.GoodsMGroup = estimateDetailRow.GoodsMGroup_Prime;                    // 商品中分類コード
                        stockDetailWork.GoodsMGroupName = estimateDetailRow.GoodsMGroupName_Prime;            // 商品中分類名称
                        stockDetailWork.BLGroupCode = estimateDetailRow.BLGroupCode_Prime;                    // BLグループコード
                        stockDetailWork.BLGroupName = estimateDetailRow.BLGroupName_Prime;                    // BLグループコード名称
                        stockDetailWork.BLGoodsCode = estimateDetailRow.BLGoodsCode_Prime;                    // BL商品コード
                        stockDetailWork.BLGoodsFullName = estimateDetailRow.BLGoodsFullName_Prime;            // BL商品コード名称（全角）
                        stockDetailWork.EnterpriseGanreCode = estimateDetailRow.EnterpriseGanreCode_Prime;    // 自社分類コード
                        stockDetailWork.EnterpriseGanreName = estimateDetailRow.EnterpriseGanreName_Prime;    // 自社分類名称
                        stockDetailWork.WarehouseCode = estimateDetailRow.WarehouseCode_Prime;                // 倉庫コード
                        stockDetailWork.WarehouseName = estimateDetailRow.WarehouseName_Prime;                // 倉庫名称
                        stockDetailWork.WarehouseShelfNo = estimateDetailRow.WarehouseShelfNo_Prime;          // 倉庫棚番
                        stockDetailWork.OpenPriceDiv = estimateDetailRow.OpenPriceDiv_Prime;                  // オープン価格区分
                        stockDetailWork.GoodsRateRank = estimateDetailRow.GoodsRateRank_Prime;                // 商品掛率ランク
                        stockDetailWork.CustRateGrpCode = estimateDetailRow.CustRateGrpCode_Prime;            // 得意先掛率グループコード
                        stockDetailWork.ListPriceTaxExcFl = estimateDetailRow.ListPriceTaxExcFl_Prime;        // 定価（税抜，浮動）
                        stockDetailWork.ListPriceTaxIncFl = estimateDetailRow.ListPriceTaxIncFl_Prime;        // 定価（税込，浮動）
                        stockDetailWork.StockRate = estimateDetailRow.CostRate_Prime;                         // 仕入率
                        stockDetailWork.RateSectStckUnPrc = estimateDetailRow.RateSectCstUnPrc_Prime;         // 掛率設定拠点（仕入単価）
                        stockDetailWork.RateDivStckUnPrc = estimateDetailRow.RateDivUnCst_Prime;              // 掛率設定区分（仕入単価）
                        stockDetailWork.UnPrcCalcCdStckUnPrc = estimateDetailRow.UnPrcCalcCdUnCst_Prime;      // 単価算出区分（仕入単価）
                        stockDetailWork.PriceCdStckUnPrc = estimateDetailRow.PriceCdUnCst_Prime;              // 価格区分（仕入単価）
                        stockDetailWork.StdUnPrcStckUnPrc = estimateDetailRow.StdUnPrcUnCst_Prime;            // 基準単価（仕入単価）
                        stockDetailWork.FracProcUnitStcUnPrc = estimateDetailRow.FracProcUnitUnCst_Prime;     // 端数処理単位（仕入単価）
                        stockDetailWork.FracProcStckUnPrc = estimateDetailRow.FracProcUnCst_Prime;            // 端数処理（仕入単価）

                        //stockDetailWork.StockUnitPriceFl = estimateDetailRow.SalesUnitCost_Prime;             // 仕入単価（税抜，浮動）
                        if (estimateDetailRow.TaxationDivCd_Prime == (int)CalculateTax.TaxationCode.TaxInc)
                        {
                            stockDetailWork.StockUnitTaxPriceFl = estimateDetailRow.SalesUnitCost_Prime;      // 仕入単価（税込，浮動）
                        }
                        else
                        {
                            stockDetailWork.StockUnitPriceFl = estimateDetailRow.SalesUnitCost_Prime;         // 仕入単価（税抜，浮動）
                        }
                        stockDetailWork.StockUnitChngDiv = estimateDetailRow.SalesUnitCostChngDiv_Prime;      // 仕入単価変更区分
                        stockDetailWork.BfStockUnitPriceFl = estimateDetailRow.BfUnitCost_Prime;              // 変更前仕入単価（浮動）
                        //stockDetailWork.BfListPrice = estimateDetailRow.BfUnitCost_Prime;                     // 変更前定価 // DEL 2012/10/24 田建委 Redmine#32862
                        stockDetailWork.BfListPrice = estimateDetailRow.BfListPrice_Prime;                     // 変更前定価 // ADD 2012/10/24 田建委 Redmine#32862
                        stockDetailWork.RateBLGoodsCode = estimateDetailRow.RateBLGoodsCode_Prime;            // BL商品コード（掛率）
                        stockDetailWork.RateBLGoodsName = estimateDetailRow.RateBLGoodsName_Prime;            // BL商品コード名称（掛率）
                        stockDetailWork.RateGoodsRateGrpCd = estimateDetailRow.RateGoodsRateGrpCd_Prime;      // 商品掛率グループコード（掛率）
                        stockDetailWork.RateGoodsRateGrpNm = estimateDetailRow.RateGoodsRateGrpNm_Prime;      // 商品掛率グループ名称（掛率）
                        stockDetailWork.RateBLGroupCode = estimateDetailRow.RateBLGroupCode_Prime;            // BLグループコード（掛率）
                        stockDetailWork.RateBLGroupName = estimateDetailRow.RateBLGroupName_Prime;            // BLグループ名称（掛率）
                        stockDetailWork.TaxationCode = estimateDetailRow.TaxationDivCd_Prime;                 // 課税区分
                        break;
                    }
            }

            //-----------------------------------------------------------------------------
            // ＵＯＥ発注データ行からセット
            //-----------------------------------------------------------------------------
            stockDetailWork.SupplierCd = uoeOrderRow.SupplierCd;                            // 仕入先コード

            //-----------------------------------------------------------------------------
            // ＵＯＥ発注明細データ行からセット
            //-----------------------------------------------------------------------------
            stockDetailWork.StockCount = uoeOrderDetailRow.OrderCnt;                       // 仕入数
            stockDetailWork.OrderCnt = uoeOrderDetailRow.OrderCnt;                         // 発注数量
            //stockDetailWork.OrderAdjustCnt = uoeOrderDetailRow.OrderCnt;                   // 発注残数量

            //-----------------------------------------------------------------------------
            // 売上データからセット
            //-----------------------------------------------------------------------------
            stockDetailWork.StockAgentCode = salesSlip.SalesEmployeeCd;                     // 仕入担当者コード
            stockDetailWork.StockAgentName = salesSlip.SalesEmployeeNm;                     // 仕入担当者名称

            //-----------------------------------------------------------------------------
            // 直接セット（固定）
            //-----------------------------------------------------------------------------
            stockDetailWork.SupplierFormal = 2;                                             // 仕入形式
            stockDetailWork.SupplierFormalSrc = 2;                                          // 仕入形式（元）
            stockDetailWork.StockGoodsCd = 0;                                               // 仕入商品区分
            stockDetailWork.WayToOrder = 2;                                                 // 注文方法
            stockDetailWork.OrderDataCreateDate = DateTime.Today;                           // 発注データ作成日
            stockDetailWork.StockOrderDivCd = ( string.IsNullOrEmpty(stockDetailWork.WarehouseCode) ) ? 0 : 1; // 仕入在庫取寄せ区分

            #endregion

            #region ＵＯＥ発注データのセット

            //-----------------------------------------------------------------------------
            // 見積明細データ行からセット
            ////-----------------------------------------------------------------------------
            switch (targetData)
            {
                // 純正部品
                case TargetData.PureParts:
                    {
                        uoeOrderDtlWork.GoodsMakerCd = estimateDetailRow.GoodsMakerCd;                      // 商品メーカーコード
                        uoeOrderDtlWork.MakerName = estimateDetailRow.MakerName;                            // メーカー名称
                        uoeOrderDtlWork.GoodsNo = estimateDetailRow.GoodsNo;                                // 商品番号
                        uoeOrderDtlWork.GoodsNoNoneHyphen = estimateDetailRow.GoodsNo.Replace("-", "");     // ハイフン無商品番号
                        uoeOrderDtlWork.GoodsName = estimateDetailRow.GoodsName;                            // 商品名称
                        uoeOrderDtlWork.WarehouseCode = estimateDetailRow.WarehouseCode;                    // 倉庫コード
                        uoeOrderDtlWork.WarehouseName = estimateDetailRow.WarehouseName;                    // 倉庫名称
                        uoeOrderDtlWork.WarehouseShelfNo = estimateDetailRow.WarehouseShelfNo;              // 倉庫棚番
                        uoeOrderDtlWork.ListPrice = estimateDetailRow.ListPriceTaxExcFl;                    // 定価（浮動）
                        uoeOrderDtlWork.SalesUnitCost = estimateDetailRow.SalesUnitCost;                    // 原価単価
                        break;
                    }
                // 優良部品
                case TargetData.PrimeParts:
                    {
                        uoeOrderDtlWork.GoodsMakerCd = estimateDetailRow.GoodsMakerCd_Prime;                      // 商品メーカーコード
                        uoeOrderDtlWork.MakerName = estimateDetailRow.MakerName_Prime;                            // メーカー名称
                        uoeOrderDtlWork.GoodsNo = estimateDetailRow.GoodsNo_Prime;                                // 商品番号
                        uoeOrderDtlWork.GoodsNoNoneHyphen = estimateDetailRow.GoodsNo_Prime.Replace("-", "");     // ハイフン無商品番号
                        uoeOrderDtlWork.GoodsName = estimateDetailRow.GoodsName_Prime;                            // 商品名称
                        uoeOrderDtlWork.WarehouseCode = estimateDetailRow.WarehouseCode_Prime;                    // 倉庫コード
                        uoeOrderDtlWork.WarehouseName = estimateDetailRow.WarehouseName_Prime;                    // 倉庫名称
                        uoeOrderDtlWork.WarehouseShelfNo = estimateDetailRow.WarehouseShelfNo_Prime;              // 倉庫棚番
                        uoeOrderDtlWork.ListPrice = estimateDetailRow.ListPriceTaxExcFl_Prime;                    // 定価（浮動）
                        uoeOrderDtlWork.SalesUnitCost = estimateDetailRow.SalesUnitCost_Prime;                    // 原価単価

                        break;
                    }
            }

            //-----------------------------------------------------------------------------
            // ＵＯＥ発注データ行からセット
            //-----------------------------------------------------------------------------
            uoeOrderDtlWork.UOESupplierCd = uoeOrderRow.UOESupplierCd;                          // UOE発注先コード
            uoeOrderDtlWork.UOESupplierName = uoeOrderRow.UOESupplierName;                      // UOE発注先名称
            uoeOrderDtlWork.CommAssemblyId = uoeOrderRow.CommAssemblyId;                        // 通信アセンブリID
            uoeOrderDtlWork.UOEDeliGoodsDiv = uoeOrderRow.UOEDeliGoodsDiv;                      // 納品区分
            uoeOrderDtlWork.DeliveredGoodsDivNm = uoeOrderRow.DeliveredGoodsDivNm;              // 納品区分名称
            uoeOrderDtlWork.FollowDeliGoodsDiv = uoeOrderRow.FollowDeliGoodsDiv;                // フォロー納品区分
            uoeOrderDtlWork.FollowDeliGoodsDivNm = uoeOrderRow.FollowDeliGoodsDivNm;            // フォロー納品区分名称
            uoeOrderDtlWork.UOEResvdSection = uoeOrderRow.UOEResvdSection;                      // UOE指定拠点
            uoeOrderDtlWork.UOEResvdSectionNm = uoeOrderRow.UOEResvdSectionNm;                  // UOE指定拠点名称
            uoeOrderDtlWork.UoeRemark1 = uoeOrderRow.UoeRemark1;                                // ＵＯＥリマーク１
            uoeOrderDtlWork.UoeRemark2 = uoeOrderRow.UoeRemark2;                                // ＵＯＥリマーク２
            uoeOrderDtlWork.SupplierCd = uoeOrderRow.SupplierCd;                                // 仕入先コード

            //-----------------------------------------------------------------------------
            // ＵＯＥ発注明細データ行からセット
            //-----------------------------------------------------------------------------
            uoeOrderDtlWork.BoCode = uoeOrderDetailRow.BoCode;                                  // BO区分
            uoeOrderDtlWork.AcceptAnOrderCnt = uoeOrderDetailRow.OrderCnt;                      // 受注数量

            //-----------------------------------------------------------------------------
            // 売上データからセット
            //-----------------------------------------------------------------------------
            uoeOrderDtlWork.CustomerCode = salesSlip.CustomerCode;                              // 得意先コード
            uoeOrderDtlWork.CustomerSnm = salesSlip.CustomerSnm;                                // 得意先略称
            uoeOrderDtlWork.SalesDate = salesSlip.SalesDate;                                    // 売上日付

            //-----------------------------------------------------------------------------
            // 直接セット（固定）
            //-----------------------------------------------------------------------------
            uoeOrderDtlWork.SystemDivCd = 2;                                                    // システム区分
            uoeOrderDtlWork.UOEKind = 0;                                                        // UOE種別
            uoeOrderDtlWork.InputDay = DateTime.Today;                                          // 入力日
            uoeOrderDtlWork.DataUpdateDateTime = DateTime.Now;                                  // データ更新日時
            uoeOrderDtlWork.SupplierFormal = 2;                                                 // 仕入形式


            #endregion
        }

        /// <summary>
        /// ＵＯＥ発注データを取得します。
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="uoeOrderRow">UOE発注データ行オブジェクト</param>
        /// <param name="uoeOrderDetailRow">UOE発注明細データ行オブジェクト</param>
        /// <param name="primeInfoRow">優良データ行オブジェクト</param>
        /// <param name="stockDetailWork">仕入明細データワークオブジェクト</param>
        /// <param name="uoeOrderDtlWork">ＵＯＥ発注データワークオブジェクト</param>
        /// <remarks>
        /// <br>Update Note: 2012/10/24 田建委</br>
        /// <br>管理番号   : 10801804-00、2012/11/14配信分</br>
        /// <br>             Redmine#32862 #13の障害 優良データ行ＵＯＥ発注データの変更前定価のセット不正の対応</br>
        /// </remarks>
        private void GetUOEOrderDataFromRow(SalesSlip salesSlip, EstimateInputDataSet.UOEOrderRow uoeOrderRow, EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow, EstimateInputDataSet.PrimeInfoRow primeInfoRow, out StockDetailWork stockDetailWork, out UOEOrderDtlWork uoeOrderDtlWork)
        {
            stockDetailWork = null;
            uoeOrderDtlWork = null;

            if (( uoeOrderRow == null ) || ( uoeOrderDetailRow == null ) || ( primeInfoRow == null )) return;

            stockDetailWork = new StockDetailWork();
            uoeOrderDtlWork = new UOEOrderDtlWork();

            #region 仕入明細データのセット

            //-----------------------------------------------------------------------------
            // 見積明細データ行からセット
            //-----------------------------------------------------------------------------
            stockDetailWork.GoodsKindCode = primeInfoRow.GoodsKindCode;                // 商品属性
            stockDetailWork.GoodsMakerCd = primeInfoRow.GoodsMakerCd;                  // 商品メーカーコード
            stockDetailWork.MakerName = primeInfoRow.MakerName;                        // メーカー名称
            stockDetailWork.MakerKanaName = primeInfoRow.MakerKanaName;                // メーカーカナ名称
            stockDetailWork.GoodsNo = primeInfoRow.GoodsNo;                            // 商品番号
            stockDetailWork.GoodsName = primeInfoRow.GoodsName;                        // 商品名称
            stockDetailWork.GoodsNameKana = primeInfoRow.GoodsNameKana;                // 商品名称カナ
            stockDetailWork.GoodsLGroup = primeInfoRow.GoodsLGroup;                    // 商品大分類コード
            stockDetailWork.GoodsLGroupName = primeInfoRow.GoodsLGroupName;            // 商品大分類名称
            stockDetailWork.GoodsMGroup = primeInfoRow.GoodsMGroup;                    // 商品中分類コード
            stockDetailWork.GoodsMGroupName = primeInfoRow.GoodsMGroupName;            // 商品中分類名称
            stockDetailWork.BLGroupCode = primeInfoRow.BLGroupCode;                    // BLグループコード
            stockDetailWork.BLGroupName = primeInfoRow.BLGroupName;                    // BLグループコード名称
            stockDetailWork.BLGoodsCode = primeInfoRow.BLGoodsCode;                    // BL商品コード
            stockDetailWork.BLGoodsFullName = primeInfoRow.BLGoodsFullName;            // BL商品コード名称（全角）
            stockDetailWork.EnterpriseGanreCode = primeInfoRow.EnterpriseGanreCode;    // 自社分類コード
            stockDetailWork.EnterpriseGanreName = primeInfoRow.EnterpriseGanreName;    // 自社分類名称
            stockDetailWork.WarehouseCode = primeInfoRow.WarehouseCode;                // 倉庫コード
            stockDetailWork.WarehouseName = primeInfoRow.WarehouseName;                // 倉庫名称
            stockDetailWork.WarehouseShelfNo = primeInfoRow.WarehouseShelfNo;          // 倉庫棚番
            stockDetailWork.OpenPriceDiv = primeInfoRow.OpenPriceDiv;                  // オープン価格区分
            stockDetailWork.GoodsRateRank = primeInfoRow.GoodsRateRank;                // 商品掛率ランク
            stockDetailWork.CustRateGrpCode = primeInfoRow.CustRateGrpCode;            // 得意先掛率グループコード
            stockDetailWork.ListPriceTaxExcFl = primeInfoRow.ListPriceTaxExcFl;        // 定価（税抜，浮動）
            stockDetailWork.ListPriceTaxIncFl = primeInfoRow.ListPriceTaxIncFl;        // 定価（税込，浮動）
            stockDetailWork.StockRate = primeInfoRow.CostRate;                         // 仕入率
            stockDetailWork.RateSectStckUnPrc = primeInfoRow.RateSectCstUnPrc;         // 掛率設定拠点（仕入単価）
            stockDetailWork.RateDivStckUnPrc = primeInfoRow.RateDivUnCst;              // 掛率設定区分（仕入単価）
            stockDetailWork.UnPrcCalcCdStckUnPrc = primeInfoRow.UnPrcCalcCdUnCst;      // 単価算出区分（仕入単価）
            stockDetailWork.PriceCdStckUnPrc = primeInfoRow.PriceCdUnCst;              // 価格区分（仕入単価）
            stockDetailWork.StdUnPrcStckUnPrc = primeInfoRow.StdUnPrcUnCst;            // 基準単価（仕入単価）
            stockDetailWork.FracProcUnitStcUnPrc = primeInfoRow.FracProcUnitUnCst;     // 端数処理単位（仕入単価）
            stockDetailWork.FracProcStckUnPrc = primeInfoRow.FracProcUnCst;            // 端数処理（仕入単価）
            //stockDetailWork.StockUnitPriceFl = primeInfoRow.SalesUnitCost;             // 仕入単価（税抜，浮動）
            if (primeInfoRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
            {
                stockDetailWork.StockUnitTaxPriceFl = primeInfoRow.SalesUnitCost;      // 仕入単価（税込，浮動）
            }
            else
            {
                stockDetailWork.StockUnitPriceFl = primeInfoRow.SalesUnitCost;         // 仕入単価（税抜，浮動）
            }

            stockDetailWork.StockUnitChngDiv = primeInfoRow.SalesUnitCostChngDiv;      // 仕入単価変更区分
            stockDetailWork.BfStockUnitPriceFl = primeInfoRow.BfUnitCost;              // 変更前仕入単価（浮動）
            //stockDetailWork.BfListPrice = primeInfoRow.BfUnitCost;                     // 変更前定価 // DEL 2012/10/24 田建委 Redmine#32862
            stockDetailWork.BfListPrice = primeInfoRow.BfListPrice;                     // 変更前定価 // ADD 2012/10/24 田建委 Redmine#32862
            stockDetailWork.RateBLGoodsCode = primeInfoRow.RateBLGoodsCode;            // BL商品コード（掛率）
            stockDetailWork.RateBLGoodsName = primeInfoRow.RateBLGoodsName;            // BL商品コード名称（掛率）
            stockDetailWork.RateGoodsRateGrpCd = primeInfoRow.RateGoodsRateGrpCd;      // 商品掛率グループコード（掛率）
            stockDetailWork.RateGoodsRateGrpNm = primeInfoRow.RateGoodsRateGrpNm;      // 商品掛率グループ名称（掛率）
            stockDetailWork.RateBLGroupCode = primeInfoRow.RateBLGroupCode;            // BLグループコード（掛率）
            stockDetailWork.RateBLGroupName = primeInfoRow.RateBLGroupName;            // BLグループ名称（掛率）
            stockDetailWork.TaxationCode = primeInfoRow.TaxationDivCd;                 // 課税区分

            //-----------------------------------------------------------------------------
            // ＵＯＥ発注データ行からセット
            //-----------------------------------------------------------------------------
            stockDetailWork.SupplierCd = uoeOrderRow.SupplierCd;                         // 仕入先コード


            //-----------------------------------------------------------------------------
            // ＵＯＥ発注明細データ行からセット
            //-----------------------------------------------------------------------------
            stockDetailWork.StockCount = uoeOrderDetailRow.OrderCnt;                       // 仕入数
            stockDetailWork.OrderCnt = uoeOrderDetailRow.OrderCnt;                         // 発注数量
            stockDetailWork.OrderRemainCnt = uoeOrderDetailRow.OrderCnt;                   // 発注残数

            //-----------------------------------------------------------------------------
            // 売上データからセット
            //-----------------------------------------------------------------------------
            stockDetailWork.StockAgentCode = salesSlip.SalesEmployeeCd;                     // 仕入担当者コード
            stockDetailWork.StockAgentName = salesSlip.SalesEmployeeNm;                     // 仕入担当者名称


            //-----------------------------------------------------------------------------
            // 直接セット（固定）
            //-----------------------------------------------------------------------------
            stockDetailWork.SupplierFormal = 2;                                             // 仕入形式
            stockDetailWork.SupplierFormalSrc = 2;                                          // 仕入形式（元）
            stockDetailWork.StockGoodsCd = 0;                                               // 仕入商品区分
            stockDetailWork.WayToOrder = 2;                                                 // 注文方法
            stockDetailWork.OrderDataCreateDate = DateTime.Today;                           // 発注データ作成日
            stockDetailWork.StockOrderDivCd = ( string.IsNullOrEmpty(stockDetailWork.WarehouseCode) ) ? 0 : 1; // 仕入在庫取寄せ区分

            #endregion

            #region ＵＯＥ発注データのセット

            //-----------------------------------------------------------------------------
            // 見積明細データ行からセット
            ////-----------------------------------------------------------------------------
            uoeOrderDtlWork.GoodsMakerCd = primeInfoRow.GoodsMakerCd;                      // 商品メーカーコード
            uoeOrderDtlWork.MakerName = primeInfoRow.MakerName;                            // メーカー名称
            uoeOrderDtlWork.GoodsNo = primeInfoRow.GoodsNo;                                // 商品番号
            uoeOrderDtlWork.GoodsNoNoneHyphen = primeInfoRow.GoodsNo.Replace("-", "");     // ハイフン無商品番号
            uoeOrderDtlWork.GoodsName = primeInfoRow.GoodsName;                            // 商品名称
            uoeOrderDtlWork.WarehouseCode = primeInfoRow.WarehouseCode;                    // 倉庫コード
            uoeOrderDtlWork.WarehouseName = primeInfoRow.WarehouseName;                    // 倉庫名称
            uoeOrderDtlWork.WarehouseShelfNo = primeInfoRow.WarehouseShelfNo;              // 倉庫棚番
            uoeOrderDtlWork.ListPrice = primeInfoRow.ListPriceTaxExcFl;                    // 定価（浮動）
            uoeOrderDtlWork.SalesUnitCost = primeInfoRow.SalesUnitCost;                    // 原価単価

            //-----------------------------------------------------------------------------
            // ＵＯＥ発注データ行からセット
            //-----------------------------------------------------------------------------
            uoeOrderDtlWork.UOESupplierCd = uoeOrderRow.UOESupplierCd;                          // UOE発注先コード
            uoeOrderDtlWork.UOESupplierName = uoeOrderRow.UOESupplierName;                      // UOE発注先名称
            uoeOrderDtlWork.CommAssemblyId = uoeOrderRow.CommAssemblyId;                        // 通信アセンブリID
            uoeOrderDtlWork.UOEDeliGoodsDiv = uoeOrderRow.UOEDeliGoodsDiv;                      // 納品区分
            uoeOrderDtlWork.DeliveredGoodsDivNm = uoeOrderRow.DeliveredGoodsDivNm;              // 納品区分名称
            uoeOrderDtlWork.FollowDeliGoodsDiv = uoeOrderRow.FollowDeliGoodsDiv;                // フォロー納品区分
            uoeOrderDtlWork.FollowDeliGoodsDivNm = uoeOrderRow.FollowDeliGoodsDivNm;            // フォロー納品区分名称
            uoeOrderDtlWork.UOEResvdSection = uoeOrderRow.UOEResvdSection;                      // UOE指定拠点
            uoeOrderDtlWork.UOEResvdSectionNm = uoeOrderRow.UOEResvdSectionNm;                  // UOE指定拠点名称
            uoeOrderDtlWork.UoeRemark1 = uoeOrderRow.UoeRemark1;                                // ＵＯＥリマーク１
            uoeOrderDtlWork.UoeRemark2 = uoeOrderRow.UoeRemark2;                                // ＵＯＥリマーク２
            uoeOrderDtlWork.SupplierCd = uoeOrderRow.SupplierCd;                                // 仕入先コード

            //-----------------------------------------------------------------------------
            // ＵＯＥ発注明細データ行からセット
            //-----------------------------------------------------------------------------
            uoeOrderDtlWork.BoCode = uoeOrderDetailRow.BoCode;                                  // BO区分
            uoeOrderDtlWork.AcceptAnOrderCnt = uoeOrderDetailRow.OrderCnt;                      // 受注数量

            //-----------------------------------------------------------------------------
            // 売上データからセット
            //-----------------------------------------------------------------------------
            uoeOrderDtlWork.CustomerCode = salesSlip.CustomerCode;                              // 得意先コード
            uoeOrderDtlWork.CustomerSnm = salesSlip.CustomerSnm;                                // 得意先略称
            uoeOrderDtlWork.SalesDate = salesSlip.SalesDate;                                    // 売上日付

            //-----------------------------------------------------------------------------
            // 直接セット（固定）
            //-----------------------------------------------------------------------------
            uoeOrderDtlWork.SystemDivCd = 2;                                                    // システム区分
            uoeOrderDtlWork.UOEKind = 0;                                                        // UOE種別
            uoeOrderDtlWork.InputDay = DateTime.Today;                                          // 入力日
            uoeOrderDtlWork.DataUpdateDateTime = DateTime.Today;                                // データ更新日時
            uoeOrderDtlWork.SupplierFormal = 2;                                                 // 仕入形式


            #endregion
        }


        /// <summary>
        /// 指定した売上明細データを元に見積明細データテーブル行を生成します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="estimateDetailDataTable">見積明細データテーブル</param>
        /// <returns>見積明細行</returns>
		private EstimateInputDataSet.EstimateDetailRow CreateRowFromUIData( SalesSlip salesSlip, SalesDetail salesDetail, EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable )
		{
            TargetData targetData = ( salesDetail.SalesRowDerivNo == 0 ) ? TargetData.PureParts : TargetData.PrimeParts;
			EstimateInputDataSet.EstimateDetailRow row = estimateDetailDataTable.NewEstimateDetailRow();

            row.DtlRelationGuid = Guid.Empty;
            row.DtlRelationGuid_Prime = Guid.Empty;
            row.PrimeInfoRelationGuid = Guid.Empty;
            row.PartsInfoLinkGuid = Guid.Empty;
            row.PartsInfoLinkGuid_Prime = Guid.Empty;
            row.CarRelationGuid = Guid.Empty;
            row.UOEOrderGuid = Guid.Empty;
            row.UOEOrderGuid_Prime = Guid.Empty;
                 
            this.SetRowFromUIData(targetData, ref row, salesSlip, salesDetail);
			return row;
		}

        /// <summary>
        /// 見積明細行オブジェクトのクリアを行います。（オーバーロード）
        /// </summary>
        /// <param name="row">見積明細行オブジェクト</param>
        /// <param name="targetData">対象データ</param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        /// <br>Update Note: 2013/05/03 xujx</br>
        /// <br>管理番号   : 10801804-00 2013/05/15配信分</br>
        /// <br>           : Redmine#34803</br>
        /// <br>           : ①既存伝票を呼び出して、明細データを挿入する場合、「印刷」ボタンを押下して、エラーが発生することの対応</br>
        //-----UPD 2011/02/14----->>>>>
        //private void ClearEstimateDetailRow( EstimateInputDataSet.EstimateDetailRow row, TargetData targetData )
        private static void ClearEstimateDetailRow(EstimateInputDataSet.EstimateDetailRow row, TargetData targetData)
        //-----UPD 2011/02/14-----<<<<<
        {
            if (row == null) return;

            // 対象データに従って処理分岐
            switch (targetData)
            {
                // 全て
                case TargetData.All:
                    //this.ClearEstimateDetailRowPureInfo(row);       // 純正部品情報クリア//DEL 2011/02/14
                    //this.ClearEstimateDetailRowPrimeInfo(row);      // 優良部品情報クリア//DEL 2011/02/14
                    ClearEstimateDetailRowPureInfo(row);              // 純正部品情報クリア//ADD 2011/02/14
                    ClearEstimateDetailRowPrimeInfo(row);             // 優良部品情報クリア//ADD 2011/02/14


                    #region ●項目クリア

                    row.AcceptAnOrderNo = 0;                        // 受注番号
                    row.AcptAnOdrStatus = 0;                        // 受注ステータス

                    row.PrimeInfoRelationGuid = Guid.Empty;         // 優良情報リレーションGUID
                    row.PartsInfoLinkGuid = Guid.Empty;             // 部品情報リンクGUID
                    row.PartsInfoLinkGuid_Prime = Guid.Empty;       // 部品情報リンクGUID（優良）

                    row.EditStatus = ctEDITSTATUS_AllOK;
                    row.RowStatus = ctROWSTATUS_NORMAL;

                    #endregion

                    break;
                // 純正部品
                case TargetData.PureParts:
                    //this.ClearEstimateDetailRowPureInfo(row);       // 純正部品情報クリア//DEL 2011/02/14
                    ClearEstimateDetailRowPureInfo(row);       // 純正部品情報クリア//ADD 2011/02/14
                    break;
                // 優良部品
                case TargetData.PrimeParts:
                    // --- UPD 2012/12/20 T.Miyamoto ------------------------------>>>>>
                    ////this.ClearEstimateDetailRowPrimeInfo(row);      // 優良部品情報クリア//DEL 2011/02/14
                    //ClearEstimateDetailRowPureInfo(row);       // 純正部品情報クリア//ADD 2011/02/14
                    ClearEstimateDetailRowPrimeInfo(row);      // 優良部品情報クリア
                    // --- UPD 2012/12/20 T.Miyamoto ------------------------------<<<<<
                    break;
            }
        }

        /// <summary>
        /// 見積明細行の優良部品情報をクリアします。
        /// </summary>
        /// <param name="row"></param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        /// <br>Update Note: 2013/05/03 xujx</br>
        /// <br>管理番号   : 10801804-00 2013/05/15配信分</br>
        /// <br>           : Redmine#34803</br>
        /// <br>           : ①既存伝票を呼び出して、明細データを挿入する場合、「印刷」ボタンを押下して、エラーが発生することの対応</br>
        //-----UPD 2011/02/14----->>>>>
        //private void ClearEstimateDetailRowPureInfo( EstimateInputDataSet.EstimateDetailRow row )
        private static void ClearEstimateDetailRowPureInfo(EstimateInputDataSet.EstimateDetailRow row)
        //-----UPD 2011/02/14-----<<<<<
        {
            //this.SettingEstimateDetailRowDtlRelationGuid(TargetData.PureParts, row);//DEL 2011/02/14
            SettingEstimateDetailRowDtlRelationGuid(TargetData.PureParts, row);//ADD 2011/02/14
            row.GoodsKindCode = 0;                          // 商品属性
            row.GoodsSearchDivCd = 0;                       // 商品検索区分
            row.GoodsMakerCd = 0;                           // 商品メーカーコード
            row.MakerName = "";                             // メーカー名称
            row.MakerKanaName = "";                         // メーカーカナ名称
            row.GoodsNo = "";                               // 商品番号
            row.GoodsName = "";                             // 商品名称
            row.GoodsNameKana = "";                         // 商品名称カナ
            row.GoodsLGroup = 0;                            // 商品大分類コード
            row.GoodsLGroupName = "";                       // 商品大分類名称
            row.GoodsMGroup = 0;                            // 商品中分類コード
            row.GoodsMGroupName = "";                       // 商品中分類名称
            row.BLGroupCode = 0;                            // BLグループコード
            row.BLGroupName = "";                           // BLグループコード名称
            row.BLGoodsCode = 0;                            // BL商品コード
            row.BLGoodsFullName = "";                       // BL商品コード名称（全角）
            row.EnterpriseGanreCode = 0;                    // 自社分類コード
            row.EnterpriseGanreName = "";                   // 自社分類名称
            row.WarehouseCode = "";                         // 倉庫コード
            row.WarehouseName = "";                         // 倉庫名称
            row.WarehouseShelfNo = "";                      // 倉庫棚番
            row.SalesOrderDivCd = 0;                        // 売上在庫取寄せ区分
            row.OpenPriceDiv = 0;                           // オープン価格区分
            row.GoodsRateRank = "";                         // 商品掛率ランク
            row.CustRateGrpCode = 0;                        // 得意先掛率グループコード
            row.ListPriceRate = 0;                          // 定価率
            row.RateSectPriceUnPrc = "";                    // 掛率設定拠点（定価）
            row.RateDivLPrice = "";                         // 掛率設定区分（定価）
            row.UnPrcCalcCdLPrice = 0;                      // 単価算出区分（定価）
            row.PriceCdLPrice = 0;                          // 価格区分（定価）
            row.StdUnPrcLPrice = 0;                         // 基準単価（定価）
            row.FracProcUnitLPrice = 0;                     // 端数処理単位（定価）
            row.FracProcLPrice = 0;                         // 端数処理（定価）
            row.ListPriceTaxIncFl = 0;                      // 定価（税込，浮動）
            row.ListPriceTaxExcFl = 0;                      // 定価（税抜，浮動）
            row.ListPriceChngCd = 0;                        // 定価変更区分
            row.SalesRate = 0;                              // 売価率
            row.RateSectSalUnPrc = "";                      // 掛率設定拠点（売上単価）
            row.RateDivSalUnPrc = "";                       // 掛率設定区分（売上単価）
            row.UnPrcCalcCdSalUnPrc = 0;                    // 単価算出区分（売上単価）
            row.PriceCdSalUnPrc = 0;                        // 価格区分（売上単価）
            row.StdUnPrcSalUnPrc = 0;                       // 基準単価（売上単価）
            row.FracProcUnitSalUnPrc = 0;                   // 端数処理単位（売上単価）
            row.FracProcSalUnPrc = 0;                       // 端数処理（売上単価）
            row.SalesUnPrcTaxIncFl = 0;                     // 売上単価（税込，浮動）
            row.SalesUnPrcTaxExcFl = 0;                     // 売上単価（税抜，浮動）
            row.SalesUnPrcChngCd = 0;                       // 売上単価変更区分
            row.CostRate = 0;                               // 原価率
            row.RateSectCstUnPrc = "";                      // 掛率設定拠点（原価単価）
            row.RateDivUnCst = "";                          // 掛率設定区分（原価単価）
            row.UnPrcCalcCdUnCst = 0;                       // 単価算出区分（原価単価）
            row.PriceCdUnCst = 0;                           // 価格区分（原価単価）
            row.StdUnPrcUnCst = 0;                          // 基準単価（原価単価）
            row.FracProcUnitUnCst = 0;                      // 端数処理単位（原価単価）
            row.FracProcUnCst = 0;                          // 端数処理（原価単価）
            row.SalesUnitCost = 0;                          // 原価単価
            row.SalesUnitCostChngDiv = 0;                   // 原価単価変更区分
            row.RateBLGoodsCode = 0;                        // BL商品コード（掛率）
            row.RateBLGoodsName = "";                       // BL商品コード名称（掛率）
            row.PrtBLGoodsCode = 0;                         // BL商品コード（印刷）
            row.PrtBLGoodsName = "";                        // BL商品コード名称（印刷）
            row.SalesCode = 0;                              // 販売区分コード
            row.SalesCdNm = "";                             // 販売区分名称
            row.WorkManHour = 0;                            // 作業工数
            row.ShipmentCnt = 0;                            // 出荷数
            row.AcceptAnOrderCnt = 0;                       // 受注数量
            row.AcptAnOdrAdjustCnt = 0;                     // 受注調整数
            row.AcptAnOdrRemainCnt = 0;                     // 受注残数
            row.RemainCntUpdDate = DateTime.MinValue;       // 残数更新日
            row.SalesMoneyTaxInc = 0;                       // 売上金額（税込み）
            row.SalesMoneyTaxExc = 0;                       // 売上金額（税抜き）
            row.Cost = 0;                                   // 原価
            row.GrsProfitChkDiv = 0;                        // 粗利チェック区分
            row.SalesGoodsCd = 0;                           // 売上商品区分
            row.SalesPriceConsTax = 0;                      // 売上金額消費税額
            row.TaxationDivCd = 0;                          // 課税区分
            row.PartySlipNumDtl = "";                       // 相手先伝票番号（明細）
            row.DtlNote = "";                               // 明細備考
            row.SupplierCd = 0;                             // 仕入先コード
            row.SupplierSnm = "";                           // 仕入先略称
            row.OrderNumber = "";                           // 発注番号
            row.WayToOrder = 0;                             // 注文方法
            row.SlipMemo1 = "";                             // 伝票メモ１
            row.SlipMemo2 = "";                             // 伝票メモ２
            row.SlipMemo3 = "";                             // 伝票メモ３
            row.InsideMemo1 = "";                           // 社内メモ１
            row.InsideMemo2 = "";                           // 社内メモ２
            row.InsideMemo3 = "";                           // 社内メモ３
            row.BfListPrice = 0;                            // 変更前定価
            row.BfSalesUnitPrice = 0;                       // 変更前売価
            row.BfUnitCost = 0;                             // 変更前原価
            row.CmpltSalesRowNo = 0;                        // 一式明細番号
            row.CmpltGoodsMakerCd = 0;                      // メーカーコード（一式）
            row.CmpltMakerName = "";                        // メーカー名称（一式）
            row.CmpltMakerKanaName = "";                    // メーカーカナ名称（一式）
            row.CmpltGoodsName = "";                        // 商品名称（一式）
            row.CmpltShipmentCnt = 0;                       // 数量（一式）
            row.CmpltSalesUnPrcFl = 0;                      // 売上単価（一式）
            row.CmpltSalesMoney = 0;                        // 売上金額（一式）
            row.CmpltSalesUnitCost = 0;                     // 原価単価（一式）
            row.CmpltCost = 0;                              // 原価金額（一式）
            row.CmpltPartySalSlNum = "";                    // 相手先伝票番号（一式）
            row.CmpltNote = "";                             // 一式備考
            row.PrtGoodsNo = "";                            // 印刷用品番
            row.PrtMakerCode = 0;                           // 印刷用メーカーコード
            row.PrtMakerCode = 0;                           // 印刷用メーカー名称
            row.PartsInfoLinkGuid = Guid.Empty;             // 部品情報リンクGUID（優良）

            row.UOEOrderGuid = Guid.Empty;
            //row.ShipmentPosCnt = 0;// DEL 譚洪 Redmine#34994 2013/03/10
            row.ShipmentPosCnt = string.Empty;// ADD 譚洪 Redmine#34994 2013/03/10
            row.AlreadyAddUpCnt = 0;
            row.CtlgPartsNo = string.Empty;
            row.SpecialNote = string.Empty;
            row.StandardName = string.Empty;
            row.ListPriceDisplay = 0;
            row.ExistSetInfo = false;
            // --------------- ADD 2013/05/03 xujx FOR Redmine#34803 ---------->>>>
            row.SalesSlipDtlNum = 0; // 売上明細通番
            // --------------- ADD 2013/05/03 xujx FOR Redmine#34803 ----------<<<<
        }


        /// <summary>
        /// 見積明細行の優良部品情報をクリアします。
        /// </summary>
        /// <param name="row"></param>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        /// <br>Update Note: 2013/05/03 xujx</br>
        /// <br>管理番号   : 10801804-00 2013/05/15配信分</br>
        /// <br>           : Redmine#34803</br>
        /// <br>           : ①既存伝票を呼び出して、明細データを挿入する場合、「印刷」ボタンを押下して、エラーが発生することの対応</br>
        //-----UPD 2011/02/14----->>>>>
        //private void ClearEstimateDetailRowPrimeInfo( EstimateInputDataSet.EstimateDetailRow row )
        private static void ClearEstimateDetailRowPrimeInfo(EstimateInputDataSet.EstimateDetailRow row)
        //-----UPD 2011/02/14-----<<<<<
        {
            //this.SettingEstimateDetailRowDtlRelationGuid(TargetData.PrimeParts, row);//DEL 2011/02/14
            SettingEstimateDetailRowDtlRelationGuid(TargetData.PrimeParts, row);//ADD 2011/02/14
            row.GoodsKindCode_Prime = 0;                    // 商品属性（優良）
            row.GoodsSearchDivCd_Prime = 0;                 // 商品検索区分（優良）
            row.GoodsMakerCd_Prime = 0;                     // 商品メーカーコード（優良）
            row.MakerName_Prime = "";                       // メーカー名称（優良）
            row.MakerKanaName_Prime = "";                   // メーカーカナ名称（優良）
            row.GoodsNo_Prime = "";                         // 商品番号（優良）
            row.GoodsName_Prime = "";                       // 商品名称（優良）
            row.GoodsNameKana_Prime = "";                   // 商品名称カナ（優良）
            row.GoodsLGroup_Prime = 0;                      // 商品大分類コード（優良）
            row.GoodsLGroupName_Prime = "";                 // 商品大分類名称（優良）
            row.GoodsMGroup_Prime = 0;                      // 商品中分類コード（優良）
            row.GoodsMGroupName_Prime = "";                 // 商品中分類名称（優良）
            row.BLGroupCode_Prime = 0;                      // BLグループコード（優良）
            row.BLGroupName_Prime = "";                     // BLグループコード名称（優良）
            row.BLGoodsCode_Prime = 0;                      // BL商品コード（優良）
            row.BLGoodsFullName_Prime = "";                 // BL商品コード名称（全角）（優良）
            row.EnterpriseGanreCode_Prime = 0;              // 自社分類コード（優良）
            row.EnterpriseGanreName_Prime = "";             // 自社分類名称（優良）
            row.WarehouseCode_Prime = "";                   // 倉庫コード（優良）
            row.WarehouseName_Prime = "";                   // 倉庫名称（優良）
            row.WarehouseShelfNo_Prime = "";                // 倉庫棚番（優良）
            row.SalesOrderDivCd_Prime = 0;                  // 売上在庫取寄せ区分（優良）
            row.OpenPriceDiv_Prime = 0;                     // オープン価格区分（優良）
            row.GoodsRateRank_Prime = "";                   // 商品掛率ランク（優良）
            row.CustRateGrpCode_Prime = 0;                  // 得意先掛率グループコード（優良）
            row.ListPriceRate_Prime = 0;                    // 定価率（優良）
            row.RateSectPriceUnPrc_Prime = "";              // 掛率設定拠点（定価）（優良）
            row.RateDivLPrice_Prime = "";                   // 掛率設定区分（定価）（優良）
            row.UnPrcCalcCdLPrice_Prime = 0;                // 単価算出区分（定価）（優良）
            row.PriceCdLPrice_Prime = 0;                    // 価格区分（定価）（優良）
            row.StdUnPrcLPrice_Prime = 0;                   // 基準単価（定価）（優良）
            row.FracProcUnitLPrice_Prime = 0;               // 端数処理単位（定価）（優良）
            row.FracProcLPrice_Prime = 0;                   // 端数処理（定価）（優良）
            row.ListPriceTaxIncFl_Prime = 0;                // 定価（税込，浮動）（優良）
            row.ListPriceTaxExcFl_Prime = 0;                // 定価（税抜，浮動）（優良）
            row.ListPriceChngCd_Prime = 0;                  // 定価変更区分（優良）
            row.SalesRate_Prime = 0;                        // 売価率（優良）
            row.RateSectSalUnPrc_Prime = "";                // 掛率設定拠点（売上単価）（優良）
            row.RateDivSalUnPrc_Prime = "";                 // 掛率設定区分（売上単価）（優良）
            row.UnPrcCalcCdSalUnPrc_Prime = 0;              // 単価算出区分（売上単価）（優良）
            row.PriceCdSalUnPrc_Prime = 0;                  // 価格区分（売上単価）（優良）
            row.StdUnPrcSalUnPrc_Prime = 0;                 // 基準単価（売上単価）（優良）
            row.FracProcUnitSalUnPrc_Prime = 0;             // 端数処理単位（売上単価）（優良）
            row.FracProcSalUnPrc_Prime = 0;                 // 端数処理（売上単価）（優良）
            row.SalesUnPrcTaxIncFl_Prime = 0;               // 売上単価（税込，浮動）（優良）
            row.SalesUnPrcTaxExcFl_Prime = 0;               // 売上単価（税抜，浮動）（優良）
            row.SalesUnPrcChngCd_Prime = 0;                 // 売上単価変更区分（優良）
            row.CostRate_Prime = 0;                         // 原価率（優良）
            row.RateSectCstUnPrc_Prime = "";                // 掛率設定拠点（原価単価）（優良）
            row.RateDivUnCst_Prime = "";                    // 掛率設定区分（原価単価）（優良）
            row.UnPrcCalcCdUnCst_Prime = 0;                 // 単価算出区分（原価単価）（優良）
            row.PriceCdUnCst_Prime = 0;                     // 価格区分（原価単価）（優良）
            row.StdUnPrcUnCst_Prime = 0;                    // 基準単価（原価単価）（優良）
            row.FracProcUnitUnCst_Prime = 0;                // 端数処理単位（原価単価）（優良）
            row.FracProcUnCst_Prime = 0;                    // 端数処理（原価単価）（優良）
            row.SalesUnitCost_Prime = 0;                    // 原価単価（優良）
            row.SalesUnitCostChngDiv_Prime = 0;             // 原価単価変更区分（優良）
            row.RateBLGoodsCode_Prime = 0;                  // BL商品コード（掛率）（優良）
            row.RateBLGoodsName_Prime = "";                 // BL商品コード名称（掛率）（優良）
            row.PrtBLGoodsCode_Prime = 0;                   // BL商品コード（印刷）（優良）
            row.PrtBLGoodsName_Prime = "";                  // BL商品コード名称（印刷）（優良）
            row.SalesCode_Prime = 0;                        // 販売区分コード（優良）
            row.SalesCdNm_Prime = "";                       // 販売区分名称（優良）
            row.WorkManHour_Prime = 0;                      // 作業工数（優良）
            row.ShipmentCnt_Prime = 0;                      // 出荷数（優良）
            row.AcceptAnOrderCnt_Prime = 0;                 // 受注数量（優良）
            row.AcptAnOdrAdjustCnt_Prime = 0;               // 受注調整数（優良）
            row.AcptAnOdrRemainCnt_Prime = 0;               // 受注残数（優良）
            row.RemainCntUpdDate_Prime = DateTime.MinValue; // 残数更新日（優良）
            row.SalesMoneyTaxInc_Prime = 0;                 // 売上金額（税込み）（優良）
            row.SalesMoneyTaxExc_Prime = 0;                 // 売上金額（税抜き）（優良）
            row.Cost_Prime = 0;                             // 原価（優良）
            row.GrsProfitChkDiv_Prime = 0;                  // 粗利チェック区分（優良）
            row.SalesGoodsCd_Prime = 0;                     // 売上商品区分（優良）
            row.SalesPriceConsTax_Prime = 0;                // 売上金額消費税額（優良）
            row.TaxationDivCd_Prime = 0;                    // 課税区分（優良）
            row.PartySlipNumDtl_Prime = "";                 // 相手先伝票番号（明細）（優良）
            row.DtlNote_Prime = "";                         // 明細備考（優良）
            row.SupplierCd_Prime = 0;                       // 仕入先コード（優良）
            row.SupplierSnm_Prime = "";                     // 仕入先略称（優良）
            row.OrderNumber_Prime = "";                     // 発注番号（優良）
            row.WayToOrder_Prime = 0;                       // 注文方法（優良）
            row.SlipMemo1_Prime = "";                       // 伝票メモ１（優良）
            row.SlipMemo2_Prime = "";                       // 伝票メモ２（優良）
            row.SlipMemo3_Prime = "";                       // 伝票メモ３（優良）
            row.InsideMemo1_Prime = "";                     // 社内メモ１（優良）
            row.InsideMemo2_Prime = "";                     // 社内メモ２（優良）
            row.InsideMemo3_Prime = "";                     // 社内メモ３（優良）
            row.BfListPrice_Prime = 0;                      // 変更前定価（優良）
            row.BfSalesUnitPrice_Prime = 0;                 // 変更前売価（優良）
            row.BfUnitCost_Prime = 0;                       // 変更前原価（優良）
            row.CmpltSalesRowNo_Prime = 0;                  // 一式明細番号（優良）
            row.CmpltGoodsMakerCd_Prime = 0;                // メーカーコード（一式）（優良）
            row.CmpltMakerName_Prime = "";                  // メーカー名称（一式）（優良）
            row.CmpltMakerKanaName_Prime = "";              // メーカーカナ名称（一式）（優良）
            row.CmpltGoodsName_Prime = "";                  // 商品名称（一式）（優良）
            row.CmpltShipmentCnt_Prime = 0;                 // 数量（一式）（優良）
            row.CmpltSalesUnPrcFl_Prime = 0;                // 売上単価（一式）（優良）
            row.CmpltSalesMoney_Prime = 0;                  // 売上金額（一式）（優良）
            row.CmpltSalesUnitCost_Prime = 0;               // 原価単価（一式）（優良）
            row.CmpltCost_Prime = 0;                        // 原価金額（一式）（優良）
            row.CmpltPartySalSlNum_Prime = "";              // 相手先伝票番号（一式）（優良）
            row.CmpltNote_Prime = "";                       // 一式備考（優良）
            row.PrtGoodsNo_Prime = "";                      // 印刷用品番（優良）
            row.PrtMakerCode_Prime = 0;                     // 印刷用メーカーコード（優良）
            row.PrtMakerCode_Prime = 0;                     // 印刷用メーカー名称（優良）
            row.PartsInfoLinkGuid_Prime = Guid.Empty;       // 部品情報リンクGUID（優良）

            row.UOEOrderGuid_Prime = Guid.Empty;
            //row.ShipmentPosCnt_Prime = 0;// DEL 譚洪 Redmine#34994 2013/03/10
            row.ShipmentPosCnt_Prime = string.Empty;// ADD 譚洪 Redmine#34994 2013/03/10
            row.JoinSourPartsNoWithH = string.Empty;
            row.ListPriceDisplay_Prime = 0;
            row.AlreadyAddUpCnt_Prime = 0;
            row.ExistSetInfo_Prime = false;
            // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            row.PrmSetDtlName2_Prime = string.Empty;
            // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // --------------- ADD 2013/05/03 xujx FOR Redmine#34803 ---------->>>>
            row.SalesSlipDtlNum_Prime = 0; // 売上明細通番
            // --------------- ADD 2013/05/03 xujx FOR Redmine#34803 ----------<<<<


        }

        /// <summary>
		/// 見積明細行オブジェクトを複製します。
		/// </summary>
		/// <param name="sourceRow">見積明細行オブジェクト</param>
		/// <returns>複製後見積明細行オブジェクト</returns>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             標準価格選択ＵＩ表示の速度改善</br>
        private EstimateInputDataSet.EstimateDetailRow CloneEstimateDetailRow(EstimateInputDataSet.EstimateDetailRow sourceRow)
		{
			EstimateInputDataSet.EstimateDetailRow targetRow = this._estimateDetailDataTable.NewEstimateDetailRow();

            //this.SettingEstimateDetailRowDtlRelationGuid(TargetData.All, sourceRow);//DEL 2011/02/14
            SettingEstimateDetailRowDtlRelationGuid(TargetData.All, sourceRow);//ADD 2011/02/14

			#region ●項目セット
            //targetRow.CreateDateTime = sourceRow.CreateDateTime;                                        // 作成日時
            //targetRow.UpdateDateTime = sourceRow.UpdateDateTime;                                        // 更新日時
            //targetRow.EnterpriseCode = sourceRow.EnterpriseCode;                                        // 企業コード
            //targetRow.FileHeaderGuid = sourceRow.FileHeaderGuid;                                        // GUID
            //targetRow.UpdEmployeeCode = sourceRow.UpdEmployeeCode;                                      // 更新従業員コード
            //targetRow.UpdAssemblyId1 = sourceRow.UpdAssemblyId1;                                        // 更新アセンブリID1
            //targetRow.UpdAssemblyId2 = sourceRow.UpdAssemblyId2;                                        // 更新アセンブリID2
            //targetRow.LogicalDeleteCode = sourceRow.LogicalDeleteCode;                                  // 論理削除区分
            targetRow.AcceptAnOrderNo = sourceRow.AcceptAnOrderNo;                                      // 受注番号
            targetRow.AcptAnOdrStatus = sourceRow.AcptAnOdrStatus;                                      // 受注ステータス
            targetRow.SalesSlipNum = sourceRow.SalesSlipNum;                                            // 売上伝票番号
            targetRow.SalesRowNo = sourceRow.SalesRowNo;                                                // 売上行番号
            //targetRow.SalesRowDerivNo = sourceRow.SalesRowDerivNo;                                      // 売上行番号枝番
            //targetRow.SectionCode = sourceRow.SectionCode;                                              // 拠点コード
            //targetRow.SubSectionCode = sourceRow.SubSectionCode;                                        // 部門コード
            //targetRow.SalesDate = sourceRow.SalesDate;                                                  // 売上日付
            targetRow.CommonSeqNo = sourceRow.CommonSeqNo;                                              // 共通通番
            targetRow.SalesSlipDtlNum = sourceRow.SalesSlipDtlNum;                                      // 売上明細通番
            targetRow.AcptAnOdrStatusSrc = sourceRow.AcptAnOdrStatusSrc;                                // 受注ステータス（元）
            targetRow.SalesSlipDtlNumSrc = sourceRow.SalesSlipDtlNumSrc;                                // 売上明細通番（元）
            targetRow.SupplierFormalSync = sourceRow.SupplierFormalSync;                                // 仕入形式（同時）
            targetRow.StockSlipDtlNumSync = sourceRow.StockSlipDtlNumSync;                              // 仕入明細通番（同時）
            //targetRow.SalesSlipCdDtl = sourceRow.SalesSlipCdDtl;                                        // 売上伝票区分（明細）
            //targetRow.DeliGdsCmpltDueDate = sourceRow.DeliGdsCmpltDueDate;                              // 納品完了予定日
            targetRow.GoodsKindCode = sourceRow.GoodsKindCode;                                          // 商品属性
            targetRow.GoodsSearchDivCd = sourceRow.GoodsSearchDivCd;                                    // 商品検索区分
            targetRow.GoodsMakerCd = sourceRow.GoodsMakerCd;                                            // 商品メーカーコード
            targetRow.MakerName = sourceRow.MakerName;                                                  // メーカー名称
            targetRow.MakerKanaName = sourceRow.MakerKanaName;                                          // メーカーカナ名称
            targetRow.GoodsNo = sourceRow.GoodsNo;                                                      // 商品番号
            targetRow.GoodsName = sourceRow.GoodsName;                                                  // 商品名称
            targetRow.GoodsNameKana = sourceRow.GoodsNameKana;                                          // 商品名称カナ
            targetRow.GoodsLGroup = sourceRow.GoodsLGroup;                                              // 商品大分類コード
            targetRow.GoodsLGroupName = sourceRow.GoodsLGroupName;                                      // 商品大分類名称
            targetRow.GoodsMGroup = sourceRow.GoodsMGroup;                                              // 商品中分類コード
            targetRow.GoodsMGroupName = sourceRow.GoodsMGroupName;                                      // 商品中分類名称
            targetRow.BLGroupCode = sourceRow.BLGroupCode;                                              // BLグループコード
            targetRow.BLGroupName = sourceRow.BLGroupName;                                              // BLグループコード名称
            targetRow.BLGoodsCode = sourceRow.BLGoodsCode;                                              // BL商品コード
            targetRow.BLGoodsFullName = sourceRow.BLGoodsFullName;                                      // BL商品コード名称（全角）
            targetRow.EnterpriseGanreCode = sourceRow.EnterpriseGanreCode;                              // 自社分類コード
            targetRow.EnterpriseGanreName = sourceRow.EnterpriseGanreName;                              // 自社分類名称
            targetRow.WarehouseCode = sourceRow.WarehouseCode;                                          // 倉庫コード
            targetRow.WarehouseName = sourceRow.WarehouseName;                                          // 倉庫名称
            targetRow.WarehouseShelfNo = sourceRow.WarehouseShelfNo;                                    // 倉庫棚番
            targetRow.SalesOrderDivCd = sourceRow.SalesOrderDivCd;                                      // 売上在庫取寄せ区分
            targetRow.OpenPriceDiv = sourceRow.OpenPriceDiv;                                            // オープン価格区分
            targetRow.GoodsRateRank = sourceRow.GoodsRateRank;                                          // 商品掛率ランク
            targetRow.CustRateGrpCode = sourceRow.CustRateGrpCode;                                      // 得意先掛率グループコード
            targetRow.ListPriceRate = sourceRow.ListPriceRate;                                          // 定価率
            targetRow.RateSectPriceUnPrc = sourceRow.RateSectPriceUnPrc;                                // 掛率設定拠点（定価）
            targetRow.RateDivLPrice = sourceRow.RateDivLPrice;                                          // 掛率設定区分（定価）
            targetRow.UnPrcCalcCdLPrice = sourceRow.UnPrcCalcCdLPrice;                                  // 単価算出区分（定価）
            targetRow.PriceCdLPrice = sourceRow.PriceCdLPrice;                                          // 価格区分（定価）
            targetRow.StdUnPrcLPrice = sourceRow.StdUnPrcLPrice;                                        // 基準単価（定価）
            targetRow.FracProcUnitLPrice = sourceRow.FracProcUnitLPrice;                                // 端数処理単位（定価）
            targetRow.FracProcLPrice = sourceRow.FracProcLPrice;                                        // 端数処理（定価）
            targetRow.ListPriceTaxIncFl = sourceRow.ListPriceTaxIncFl;                                  // 定価（税込，浮動）
            targetRow.ListPriceTaxExcFl = sourceRow.ListPriceTaxExcFl;                                  // 定価（税抜，浮動）
            targetRow.ListPriceChngCd = sourceRow.ListPriceChngCd;                                      // 定価変更区分
            targetRow.SalesRate = sourceRow.SalesRate;                                                  // 売価率
            targetRow.RateSectSalUnPrc = sourceRow.RateSectSalUnPrc;                                    // 掛率設定拠点（売上単価）
            targetRow.RateDivSalUnPrc = sourceRow.RateDivSalUnPrc;                                      // 掛率設定区分（売上単価）
            targetRow.UnPrcCalcCdSalUnPrc = sourceRow.UnPrcCalcCdSalUnPrc;                              // 単価算出区分（売上単価）
            targetRow.PriceCdSalUnPrc = sourceRow.PriceCdSalUnPrc;                                      // 価格区分（売上単価）
            targetRow.StdUnPrcSalUnPrc = sourceRow.StdUnPrcSalUnPrc;                                    // 基準単価（売上単価）
            targetRow.FracProcUnitSalUnPrc = sourceRow.FracProcUnitSalUnPrc;                            // 端数処理単位（売上単価）
            targetRow.FracProcSalUnPrc = sourceRow.FracProcSalUnPrc;                                    // 端数処理（売上単価）
            targetRow.SalesUnPrcTaxIncFl = sourceRow.SalesUnPrcTaxIncFl;                                // 売上単価（税込，浮動）
            targetRow.SalesUnPrcTaxExcFl = sourceRow.SalesUnPrcTaxExcFl;                                // 売上単価（税抜，浮動）
            targetRow.SalesUnPrcChngCd = sourceRow.SalesUnPrcChngCd;                                    // 売上単価変更区分
            targetRow.CostRate = sourceRow.CostRate;                                                    // 原価率
            targetRow.RateSectCstUnPrc = sourceRow.RateSectCstUnPrc;                                    // 掛率設定拠点（原価単価）
            targetRow.RateDivUnCst = sourceRow.RateDivUnCst;                                            // 掛率設定区分（原価単価）
            targetRow.UnPrcCalcCdUnCst = sourceRow.UnPrcCalcCdUnCst;                                    // 単価算出区分（原価単価）
            targetRow.PriceCdUnCst = sourceRow.PriceCdUnCst;                                            // 価格区分（原価単価）
            targetRow.StdUnPrcUnCst = sourceRow.StdUnPrcUnCst;                                          // 基準単価（原価単価）
            targetRow.FracProcUnitUnCst = sourceRow.FracProcUnitUnCst;                                  // 端数処理単位（原価単価）
            targetRow.FracProcUnCst = sourceRow.FracProcUnCst;                                          // 端数処理（原価単価）
            targetRow.SalesUnitCost = sourceRow.SalesUnitCost;                                          // 原価単価
            targetRow.SalesUnitCostChngDiv = sourceRow.SalesUnitCostChngDiv;                            // 原価単価変更区分
            targetRow.RateBLGoodsCode = sourceRow.RateBLGoodsCode;                                      // BL商品コード（掛率）
            targetRow.RateBLGoodsName = sourceRow.RateBLGoodsName;                                      // BL商品コード名称（掛率）
            targetRow.RateGoodsRateGrpCd = sourceRow.RateGoodsRateGrpCd;                                // 商品掛率グループコード（掛率）
            targetRow.RateGoodsRateGrpNm = sourceRow.RateGoodsRateGrpNm;                                // 商品掛率グループ名称（掛率）
            targetRow.RateBLGroupCode = sourceRow.RateBLGroupCode;                                      // BLグループコード（掛率）
            targetRow.RateBLGroupName = sourceRow.RateBLGroupName;                                      // BLグループ名称（掛率）
            targetRow.PrtBLGoodsCode = sourceRow.PrtBLGoodsCode;                                        // BL商品コード（印刷）
            targetRow.PrtBLGoodsName = sourceRow.PrtBLGoodsName;                                        // BL商品コード名称（印刷）
            targetRow.SalesCode = sourceRow.SalesCode;                                                  // 販売区分コード
            targetRow.SalesCdNm = sourceRow.SalesCdNm;                                                  // 販売区分名称
            targetRow.WorkManHour = sourceRow.WorkManHour;                                              // 作業工数
            targetRow.ShipmentCnt = sourceRow.ShipmentCnt;                                              // 出荷数
            targetRow.AcceptAnOrderCnt = sourceRow.AcceptAnOrderCnt;                                    // 受注数量
            targetRow.AcptAnOdrAdjustCnt = sourceRow.AcptAnOdrAdjustCnt;                                // 受注調整数
            targetRow.AcptAnOdrRemainCnt = sourceRow.AcptAnOdrRemainCnt;                                // 受注残数
            targetRow.RemainCntUpdDate = sourceRow.RemainCntUpdDate;                                    // 残数更新日
            targetRow.SalesMoneyTaxInc = sourceRow.SalesMoneyTaxInc;                                    // 売上金額（税込み）
            targetRow.SalesMoneyTaxExc = sourceRow.SalesMoneyTaxExc;                                    // 売上金額（税抜き）
            targetRow.Cost = sourceRow.Cost;                                                            // 原価
            targetRow.GrsProfitChkDiv = sourceRow.GrsProfitChkDiv;                                      // 粗利チェック区分
            targetRow.SalesGoodsCd = sourceRow.SalesGoodsCd;                                            // 売上商品区分
            targetRow.SalesPriceConsTax = sourceRow.SalesPriceConsTax;                                  // 売上金額消費税額
            targetRow.TaxationDivCd = sourceRow.TaxationDivCd;                                          // 課税区分
            targetRow.PartySlipNumDtl = sourceRow.PartySlipNumDtl;                                      // 相手先伝票番号（明細）
            targetRow.DtlNote = sourceRow.DtlNote;                                                      // 明細備考
            targetRow.SupplierCd = sourceRow.SupplierCd;                                                // 仕入先コード
            targetRow.SupplierSnm = sourceRow.SupplierSnm;                                              // 仕入先略称
            targetRow.OrderNumber = sourceRow.OrderNumber;                                              // 発注番号
            targetRow.WayToOrder = sourceRow.WayToOrder;                                                // 注文方法
            targetRow.SlipMemo1 = sourceRow.SlipMemo1;                                                  // 伝票メモ１
            targetRow.SlipMemo2 = sourceRow.SlipMemo2;                                                  // 伝票メモ２
            targetRow.SlipMemo3 = sourceRow.SlipMemo3;                                                  // 伝票メモ３
            targetRow.InsideMemo1 = sourceRow.InsideMemo1;                                              // 社内メモ１
            targetRow.InsideMemo2 = sourceRow.InsideMemo2;                                              // 社内メモ２
            targetRow.InsideMemo3 = sourceRow.InsideMemo3;                                              // 社内メモ３
            targetRow.BfListPrice = sourceRow.BfListPrice;                                              // 変更前定価
            targetRow.BfSalesUnitPrice = sourceRow.BfSalesUnitPrice;                                    // 変更前売価
            targetRow.BfUnitCost = sourceRow.BfUnitCost;                                                // 変更前原価
            targetRow.CmpltSalesRowNo = sourceRow.CmpltSalesRowNo;                                      // 一式明細番号
            targetRow.CmpltGoodsMakerCd = sourceRow.CmpltGoodsMakerCd;                                  // メーカーコード（一式）
            targetRow.CmpltMakerName = sourceRow.CmpltMakerName;                                        // メーカー名称（一式）
            targetRow.CmpltMakerKanaName = sourceRow.CmpltMakerKanaName;                                // メーカーカナ名称（一式）
            targetRow.CmpltGoodsName = sourceRow.CmpltGoodsName;                                        // 商品名称（一式）
            targetRow.CmpltShipmentCnt = sourceRow.CmpltShipmentCnt;                                    // 数量（一式）
            targetRow.CmpltSalesUnPrcFl = sourceRow.CmpltSalesUnPrcFl;                                  // 売上単価（一式）
            targetRow.CmpltSalesMoney = sourceRow.CmpltSalesMoney;                                      // 売上金額（一式）
            targetRow.CmpltSalesUnitCost = sourceRow.CmpltSalesUnitCost;                                // 原価単価（一式）
            targetRow.CmpltCost = sourceRow.CmpltCost;                                                  // 原価金額（一式）
            targetRow.CmpltPartySalSlNum = sourceRow.CmpltPartySalSlNum;                                // 相手先伝票番号（一式）
            targetRow.CmpltNote = sourceRow.CmpltNote;                                                  // 一式備考
            targetRow.PrtGoodsNo = sourceRow.PrtGoodsNo;                                                // 印刷用品番
            targetRow.PrtMakerCode = sourceRow.PrtMakerCode;                                            // 印刷用メーカーコード
            targetRow.PrtMakerName = sourceRow.PrtMakerName;                                            // 印刷用メーカー名称
            //targetRow.CreateDateTime_Prime = sourceRow.CreateDateTime_Prime;                            // 作成日時
            //targetRow.UpdateDateTime_Prime = sourceRow.UpdateDateTime_Prime;                            // 更新日時
            //targetRow.EnterpriseCode_Prime = sourceRow.EnterpriseCode_Prime;                            // 企業コード
            //targetRow.FileHeaderGuid_Prime = sourceRow.FileHeaderGuid_Prime;                            // GUID
            //targetRow.UpdEmployeeCode_Prime = sourceRow.UpdEmployeeCode_Prime;                          // 更新従業員コード
            //targetRow.UpdAssemblyId1_Prime = sourceRow.UpdAssemblyId1_Prime;                            // 更新アセンブリID1
            //targetRow.UpdAssemblyId2_Prime = sourceRow.UpdAssemblyId2_Prime;                            // 更新アセンブリID2
            //targetRow.LogicalDeleteCode_Prime = sourceRow.LogicalDeleteCode_Prime;                      // 論理削除区分
            //targetRow.AcceptAnOrderNo_Prime = sourceRow.AcceptAnOrderNo_Prime;                          // 受注番号
            //targetRow.AcptAnOdrStatus_Prime = sourceRow.AcptAnOdrStatus_Prime;                          // 受注ステータス
            //targetRow.SalesSlipNum_Prime = sourceRow.SalesSlipNum_Prime;                                // 売上伝票番号
            //targetRow.SalesRowNo_Prime = sourceRow.SalesRowNo_Prime;                                    // 売上行番号
            //targetRow.SalesRowDerivNo_Prime = sourceRow.SalesRowDerivNo_Prime;                          // 売上行番号枝番
            //targetRow.SectionCode_Prime = sourceRow.SectionCode_Prime;                                  // 拠点コード
            //targetRow.SubSectionCode_Prime = sourceRow.SubSectionCode_Prime;                            // 部門コード
            //targetRow.SalesDate_Prime = sourceRow.SalesDate_Prime;                                      // 売上日付
            targetRow.CommonSeqNo_Prime = sourceRow.CommonSeqNo_Prime;                                  // 共通通番
            targetRow.SalesSlipDtlNum_Prime = sourceRow.SalesSlipDtlNum_Prime;                          // 売上明細通番
            targetRow.AcptAnOdrStatusSrc_Prime = sourceRow.AcptAnOdrStatusSrc_Prime;                    // 受注ステータス（元）
            targetRow.SalesSlipDtlNumSrc_Prime = sourceRow.SalesSlipDtlNumSrc_Prime;                    // 売上明細通番（元）
            targetRow.SupplierFormalSync_Prime = sourceRow.SupplierFormalSync_Prime;                    // 仕入形式（同時）
            targetRow.StockSlipDtlNumSync_Prime = sourceRow.StockSlipDtlNumSync_Prime;                  // 仕入明細通番（同時）
            //targetRow.SalesSlipCdDtl_Prime = sourceRow.SalesSlipCdDtl_Prime;                            // 売上伝票区分（明細）
            //targetRow.DeliGdsCmpltDueDate_Prime = sourceRow.DeliGdsCmpltDueDate_Prime;                  // 納品完了予定日
            //targetRow.GoodsKindCode_Prime = sourceRow.GoodsKindCode_Prime;                              // 商品属性
            //targetRow.GoodsSearchDivCd_Prime = sourceRow.GoodsSearchDivCd_Prime;                        // 商品検索区分
            targetRow.GoodsMakerCd_Prime = sourceRow.GoodsMakerCd_Prime;                                // 商品メーカーコード
            targetRow.MakerName_Prime = sourceRow.MakerName_Prime;                                      // メーカー名称
            targetRow.MakerKanaName_Prime = sourceRow.MakerKanaName_Prime;                              // メーカーカナ名称
            targetRow.GoodsNo_Prime = sourceRow.GoodsNo_Prime;                                          // 商品番号
            targetRow.GoodsName_Prime = sourceRow.GoodsName_Prime;                                      // 商品名称
            targetRow.GoodsNameKana_Prime = sourceRow.GoodsNameKana_Prime;                              // 商品名称カナ
            targetRow.GoodsLGroup_Prime = sourceRow.GoodsLGroup_Prime;                                  // 商品大分類コード
            targetRow.GoodsLGroupName_Prime = sourceRow.GoodsLGroupName_Prime;                          // 商品大分類名称
            targetRow.GoodsMGroup_Prime = sourceRow.GoodsMGroup_Prime;                                  // 商品中分類コード
            targetRow.GoodsMGroupName_Prime = sourceRow.GoodsMGroupName_Prime;                          // 商品中分類名称
            targetRow.BLGroupCode_Prime = sourceRow.BLGroupCode_Prime;                                  // BLグループコード
            targetRow.BLGroupName_Prime = sourceRow.BLGroupName_Prime;                                  // BLグループコード名称
            targetRow.BLGoodsCode_Prime = sourceRow.BLGoodsCode_Prime;                                  // BL商品コード
            targetRow.BLGoodsFullName_Prime = sourceRow.BLGoodsFullName_Prime;                          // BL商品コード名称（全角）
            targetRow.EnterpriseGanreCode_Prime = sourceRow.EnterpriseGanreCode_Prime;                  // 自社分類コード
            targetRow.EnterpriseGanreName_Prime = sourceRow.EnterpriseGanreName_Prime;                  // 自社分類名称
            targetRow.WarehouseCode_Prime = sourceRow.WarehouseCode_Prime;                              // 倉庫コード
            targetRow.WarehouseName_Prime = sourceRow.WarehouseName_Prime;                              // 倉庫名称
            targetRow.WarehouseShelfNo_Prime = sourceRow.WarehouseShelfNo_Prime;                        // 倉庫棚番
            targetRow.SalesOrderDivCd_Prime = sourceRow.SalesOrderDivCd_Prime;                          // 売上在庫取寄せ区分
            targetRow.OpenPriceDiv_Prime = sourceRow.OpenPriceDiv_Prime;                                // オープン価格区分
            targetRow.GoodsRateRank_Prime = sourceRow.GoodsRateRank_Prime;                              // 商品掛率ランク
            targetRow.CustRateGrpCode_Prime = sourceRow.CustRateGrpCode_Prime;                          // 得意先掛率グループコード
            targetRow.ListPriceRate_Prime = sourceRow.ListPriceRate_Prime;                              // 定価率
            targetRow.RateSectPriceUnPrc_Prime = sourceRow.RateSectPriceUnPrc_Prime;                    // 掛率設定拠点（定価）
            targetRow.RateDivLPrice_Prime = sourceRow.RateDivLPrice_Prime;                              // 掛率設定区分（定価）
            targetRow.UnPrcCalcCdLPrice_Prime = sourceRow.UnPrcCalcCdLPrice_Prime;                      // 単価算出区分（定価）
            targetRow.PriceCdLPrice_Prime = sourceRow.PriceCdLPrice_Prime;                              // 価格区分（定価）
            targetRow.StdUnPrcLPrice_Prime = sourceRow.StdUnPrcLPrice_Prime;                            // 基準単価（定価）
            targetRow.FracProcUnitLPrice_Prime = sourceRow.FracProcUnitLPrice_Prime;                    // 端数処理単位（定価）
            targetRow.FracProcLPrice_Prime = sourceRow.FracProcLPrice_Prime;                            // 端数処理（定価）
            targetRow.ListPriceTaxIncFl_Prime = sourceRow.ListPriceTaxIncFl_Prime;                      // 定価（税込，浮動）
            targetRow.ListPriceTaxExcFl_Prime = sourceRow.ListPriceTaxExcFl_Prime;                      // 定価（税抜，浮動）
            targetRow.ListPriceChngCd_Prime = sourceRow.ListPriceChngCd_Prime;                          // 定価変更区分
            targetRow.SalesRate_Prime = sourceRow.SalesRate_Prime;                                      // 売価率
            targetRow.RateSectSalUnPrc_Prime = sourceRow.RateSectSalUnPrc_Prime;                        // 掛率設定拠点（売上単価）
            targetRow.RateDivSalUnPrc_Prime = sourceRow.RateDivSalUnPrc_Prime;                          // 掛率設定区分（売上単価）
            targetRow.UnPrcCalcCdSalUnPrc_Prime = sourceRow.UnPrcCalcCdSalUnPrc_Prime;                  // 単価算出区分（売上単価）
            targetRow.PriceCdSalUnPrc_Prime = sourceRow.PriceCdSalUnPrc_Prime;                          // 価格区分（売上単価）
            targetRow.StdUnPrcSalUnPrc_Prime = sourceRow.StdUnPrcSalUnPrc_Prime;                        // 基準単価（売上単価）
            targetRow.FracProcUnitSalUnPrc_Prime = sourceRow.FracProcUnitSalUnPrc_Prime;                // 端数処理単位（売上単価）
            targetRow.FracProcSalUnPrc_Prime = sourceRow.FracProcSalUnPrc_Prime;                        // 端数処理（売上単価）
            targetRow.SalesUnPrcTaxIncFl_Prime = sourceRow.SalesUnPrcTaxIncFl_Prime;                    // 売上単価（税込，浮動）
            targetRow.SalesUnPrcTaxExcFl_Prime = sourceRow.SalesUnPrcTaxExcFl_Prime;                    // 売上単価（税抜，浮動）
            targetRow.SalesUnPrcChngCd_Prime = sourceRow.SalesUnPrcChngCd_Prime;                        // 売上単価変更区分
            targetRow.CostRate_Prime = sourceRow.CostRate_Prime;                                        // 原価率
            targetRow.RateSectCstUnPrc_Prime = sourceRow.RateSectCstUnPrc_Prime;                        // 掛率設定拠点（原価単価）
            targetRow.RateDivUnCst_Prime = sourceRow.RateDivUnCst_Prime;                                // 掛率設定区分（原価単価）
            targetRow.UnPrcCalcCdUnCst_Prime = sourceRow.UnPrcCalcCdUnCst_Prime;                        // 単価算出区分（原価単価）
            targetRow.PriceCdUnCst_Prime = sourceRow.PriceCdUnCst_Prime;                                // 価格区分（原価単価）
            targetRow.StdUnPrcUnCst_Prime = sourceRow.StdUnPrcUnCst_Prime;                              // 基準単価（原価単価）
            targetRow.FracProcUnitUnCst_Prime = sourceRow.FracProcUnitUnCst_Prime;                      // 端数処理単位（原価単価）
            targetRow.FracProcUnCst_Prime = sourceRow.FracProcUnCst_Prime;                              // 端数処理（原価単価）
            targetRow.SalesUnitCost_Prime = sourceRow.SalesUnitCost_Prime;                              // 原価単価
            targetRow.SalesUnitCostChngDiv_Prime = sourceRow.SalesUnitCostChngDiv_Prime;                // 原価単価変更区分
            targetRow.RateBLGoodsCode_Prime = sourceRow.RateBLGoodsCode_Prime;                          // BL商品コード（掛率）
            targetRow.RateBLGoodsName_Prime = sourceRow.RateBLGoodsName_Prime;                          // BL商品コード名称（掛率）
            targetRow.RateGoodsRateGrpCd_Prime = sourceRow.RateGoodsRateGrpCd_Prime;                    // 商品掛率グループコード（掛率）
            targetRow.RateGoodsRateGrpNm_Prime = sourceRow.RateGoodsRateGrpNm_Prime;                    // 商品掛率グループ名称（掛率）
            targetRow.RateBLGroupCode_Prime = sourceRow.RateBLGroupCode_Prime;                          // BLグループコード（掛率）
            targetRow.RateBLGroupName_Prime = sourceRow.RateBLGroupName_Prime;                          // BLグループ名称（掛率）
            targetRow.PrtBLGoodsCode_Prime = sourceRow.PrtBLGoodsCode_Prime;                            // BL商品コード（印刷）
            targetRow.PrtBLGoodsName_Prime = sourceRow.PrtBLGoodsName_Prime;                            // BL商品コード名称（印刷）
            targetRow.SalesCode_Prime = sourceRow.SalesCode_Prime;                                      // 販売区分コード
            targetRow.SalesCdNm_Prime = sourceRow.SalesCdNm_Prime;                                      // 販売区分名称
            targetRow.WorkManHour_Prime = sourceRow.WorkManHour_Prime;                                  // 作業工数
            targetRow.ShipmentCnt_Prime = sourceRow.ShipmentCnt_Prime;                                  // 出荷数
            targetRow.AcceptAnOrderCnt_Prime = sourceRow.AcceptAnOrderCnt_Prime;                        // 受注数量
            targetRow.AcptAnOdrAdjustCnt_Prime = sourceRow.AcptAnOdrAdjustCnt_Prime;                    // 受注調整数
            targetRow.AcptAnOdrRemainCnt_Prime = sourceRow.AcptAnOdrRemainCnt_Prime;                    // 受注残数
            targetRow.RemainCntUpdDate_Prime = sourceRow.RemainCntUpdDate_Prime;                        // 残数更新日
            targetRow.SalesMoneyTaxInc_Prime = sourceRow.SalesMoneyTaxInc_Prime;                        // 売上金額（税込み）
            targetRow.SalesMoneyTaxExc_Prime = sourceRow.SalesMoneyTaxExc_Prime;                        // 売上金額（税抜き）
            targetRow.Cost_Prime = sourceRow.Cost_Prime;                                                // 原価
            targetRow.GrsProfitChkDiv_Prime = sourceRow.GrsProfitChkDiv_Prime;                          // 粗利チェック区分
            targetRow.SalesGoodsCd_Prime = sourceRow.SalesGoodsCd_Prime;                                // 売上商品区分
            targetRow.SalesPriceConsTax_Prime = sourceRow.SalesPriceConsTax_Prime;                      // 売上金額消費税額
            targetRow.TaxationDivCd_Prime = sourceRow.TaxationDivCd_Prime;                              // 課税区分
            targetRow.PartySlipNumDtl_Prime = sourceRow.PartySlipNumDtl_Prime;                          // 相手先伝票番号（明細）
            targetRow.DtlNote_Prime = sourceRow.DtlNote_Prime;                                          // 明細備考
            targetRow.SupplierCd_Prime = sourceRow.SupplierCd_Prime;                                    // 仕入先コード
            targetRow.SupplierSnm_Prime = sourceRow.SupplierSnm_Prime;                                  // 仕入先略称
            targetRow.OrderNumber_Prime = sourceRow.OrderNumber_Prime;                                  // 発注番号
            targetRow.WayToOrder_Prime = sourceRow.WayToOrder_Prime;                                    // 注文方法
            targetRow.SlipMemo1_Prime = sourceRow.SlipMemo1_Prime;                                      // 伝票メモ１
            targetRow.SlipMemo2_Prime = sourceRow.SlipMemo2_Prime;                                      // 伝票メモ２
            targetRow.SlipMemo3_Prime = sourceRow.SlipMemo3_Prime;                                      // 伝票メモ３
            targetRow.InsideMemo1_Prime = sourceRow.InsideMemo1_Prime;                                  // 社内メモ１
            targetRow.InsideMemo2_Prime = sourceRow.InsideMemo2_Prime;                                  // 社内メモ２
            targetRow.InsideMemo3_Prime = sourceRow.InsideMemo3_Prime;                                  // 社内メモ３
            targetRow.BfListPrice_Prime = sourceRow.BfListPrice_Prime;                                  // 変更前定価
            targetRow.BfSalesUnitPrice_Prime = sourceRow.BfSalesUnitPrice_Prime;                        // 変更前売価
            targetRow.BfUnitCost_Prime = sourceRow.BfUnitCost_Prime;                                    // 変更前原価
            targetRow.CmpltSalesRowNo_Prime = sourceRow.CmpltSalesRowNo_Prime;                          // 一式明細番号
            targetRow.CmpltGoodsMakerCd_Prime = sourceRow.CmpltGoodsMakerCd_Prime;                      // メーカーコード（一式）
            targetRow.CmpltMakerName_Prime = sourceRow.CmpltMakerName_Prime;                            // メーカー名称（一式）
            targetRow.CmpltMakerKanaName_Prime = sourceRow.CmpltMakerKanaName_Prime;                    // メーカーカナ名称（一式）
            targetRow.CmpltGoodsName_Prime = sourceRow.CmpltGoodsName_Prime;                            // 商品名称（一式）
            targetRow.CmpltShipmentCnt_Prime = sourceRow.CmpltShipmentCnt_Prime;                        // 数量（一式）
            targetRow.CmpltSalesUnPrcFl_Prime = sourceRow.CmpltSalesUnPrcFl_Prime;                      // 売上単価（一式）
            targetRow.CmpltSalesMoney_Prime = sourceRow.CmpltSalesMoney_Prime;                          // 売上金額（一式）
            targetRow.CmpltSalesUnitCost_Prime = sourceRow.CmpltSalesUnitCost_Prime;                    // 原価単価（一式）
            targetRow.CmpltCost_Prime = sourceRow.CmpltCost_Prime;                                      // 原価金額（一式）
            targetRow.CmpltPartySalSlNum_Prime = sourceRow.CmpltPartySalSlNum_Prime;                    // 相手先伝票番号（一式）
            targetRow.CmpltNote_Prime = sourceRow.CmpltNote_Prime;                                      // 一式備考
            targetRow.PrtGoodsNo_Prime = sourceRow.PrtGoodsNo_Prime;                                    // 印刷用品番
            targetRow.PrtMakerCode_Prime = sourceRow.PrtMakerCode_Prime;                                // 印刷用メーカーコード
            targetRow.PrtMakerName_Prime = sourceRow.PrtMakerName_Prime;                                // 印刷用メーカー名称

            targetRow.CarRelationGuid = sourceRow.CarRelationGuid;
            targetRow.ShipmentPosCnt = sourceRow.ShipmentPosCnt;
            targetRow.CtlgPartsNo = sourceRow.CtlgPartsNo;
            targetRow.SpecialNote = sourceRow.SpecialNote;
            targetRow.StandardName = sourceRow.StandardName;
            targetRow.PrimeInfoRelationGuid = sourceRow.PrimeInfoRelationGuid;

            targetRow.ListPriceDisplay = sourceRow.ListPriceDisplay;
            targetRow.ExistSetInfo = sourceRow.ExistSetInfo;
            targetRow.PartsInfoLinkGuid = sourceRow.PartsInfoLinkGuid;
            targetRow.PrintSelect = sourceRow.PrintSelect;

            targetRow.ShipmentPosCnt_Prime = sourceRow.ShipmentPosCnt_Prime;
            targetRow.ExistSetInfo_Prime = sourceRow.ExistSetInfo_Prime;
            targetRow.ListPriceDisplay_Prime = sourceRow.ListPriceDisplay_Prime;
            targetRow.PartsInfoLinkGuid_Prime = sourceRow.PartsInfoLinkGuid_Prime;
            targetRow.PrintSelect_Prime = sourceRow.PrintSelect_Prime;
            // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            targetRow.PrmSetDtlName2_Prime = sourceRow.PrmSetDtlName2_Prime;
            // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            targetRow.EditStatus = sourceRow.EditStatus;
            targetRow.RowStatus = ctROWSTATUS_NORMAL;

			#endregion

			return targetRow;
		}

		/// <summary>
		/// 文字列の右詰処理を行います。
		/// </summary>
		/// <param name="sjisEnc">エンコード</param>
		/// <param name="totalLength">最大レングス</param>
		/// <param name="sourceString">元文字列</param>
		/// <param name="paddingChar">追加文字</param>
		/// <returns>編集後文字列</returns>
		private string PadRight(Encoding sjisEnc, int totalLength, string sourceString, char paddingChar)
		{
			int currentLength = sjisEnc.GetByteCount(sourceString.Trim());

			StringBuilder builder = new StringBuilder(sourceString);

			for (int i = currentLength; i < totalLength; i++)
			{
				builder.Append(paddingChar);
			}

			return builder.ToString();
		}


		/// <summary>
        /// 商品連結データリストより、指定された商品の情報を取得します。
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsUnitDataList">商品情報データリスト</param>
        /// <returns>商品情報データ</returns>
        private GoodsUnitData GetGoodsUnitDataFromList( string goodsNo, int goodsMakerCd, List<GoodsUnitData> goodsUnitDataList )
        {
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                if (( goodsUnitData.GoodsMakerCd == goodsMakerCd ) && ( goodsUnitData.GoodsNo == goodsNo ))
                {
                    return goodsUnitData;
                }
            }
            return null;
		}


		/// <summary>
        /// 在庫データリストより、指定された商品の情報を取得します。
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="stockList">在庫データリスト</param>
        /// <returns>商品連結データ</returns>
        private Stock GetStockDataFromList( string goodsNo, int goodsMakerCd, List<Stock> stockList )
        {
            foreach (Stock stock in stockList)
            {
                if (( stock.GoodsMakerCd == goodsMakerCd ) && ( stock.GoodsNo == goodsNo ))
                {
                    return stock;
                }
            }
            return null;
        }

        # endregion


       
    }
}
	