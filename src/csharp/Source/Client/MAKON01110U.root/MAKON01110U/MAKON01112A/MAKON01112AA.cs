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
using Broadleaf.Application.Controller.Facade;
// ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
using System.IO;
using Broadleaf.Library.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
// ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 仕入入力アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入入力の制御全般を行います。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
    /// <br>2008.05.21 men 新規作成</br>
    /// <br>2009.03.27 20056 對馬 大輔 MANTIS[0012812] 価格原価更新区分の更新制御変更</br>
    /// <br>2009.03.31 20056 對馬 大輔 MANTIS[0007759] BLｺｰﾄﾞ入力時の品名再表示制御追加</br>
    /// <br>2009.04.03 20056 對馬 大輔 MANTIS[0013065] 品番検索時、選択された倉庫ｺｰﾄﾞを画面反映する</br>
    /// <br>2009.04.13 20056 對馬 大輔 MANTIS[0013170] 残検索時の明細展開の不正対応</br>
    /// <br>2009.05.12 20056 對馬 大輔 MANTIS[0013236] 仕入伝票照会からのコールを考慮する</br>
    /// <br>2009.06.17 21024 佐々木 健 MANTIS[0013506] 合計入力時、金額を入力していない場合のメッセージを修正</br>
    /// <br>2010.05.04 gaoyh 1007E セキュリティ管理「数量マイナス」「商品値引」の追加（６次改良）</br>
    /// <br>2010/09/15 20056 對馬 大輔 商品自動登録無しで商品マスタ未登録品の価格を更新しようとするとエラーになる件の対応</br>
    /// <br>2010/10/27 李占川 消費税変更時に不正にセットされる障害の修正</br>
    /// <br>2010/11/12 22018 鈴木 正臣 商品自動登録の価格開始日を前回月次更新日＋１に変更</br>
    /// <br>2010/12/03 yangmj 障害改良対応</br>
    /// <br>2011/07/18 曹文傑 MANTIS[17500] 連番1028、Redmine22936</br>
    /// <br>              仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// <br>Update Note : 2011/12/27 陳建明</br>
    /// <br>管理番号    : 10707327-00 2012/01/25配信分</br>
    /// <br>              redmine#27374 仕入伝票入力/締済のチェックの対応</br>
    /// <br>Update Note : 2012/03/13 鄧潘ハン</br>
    /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
    /// <br>              Redmine#27374 仕入伝票入力でガイドから呼出した場合削除でエラーになる件の対応</br>
    /// <br>Update Note : 2012/06/15 tianjw</br>
    /// <br>管理番号    : 10801804-00 2012/07/25配信分</br>
    /// <br>              Redmine#30517 品名未入力行の不具合の対応</br>
    //----------------------------------------------------------------------------//
    // 管理番号              作成担当 : FSI千田 晃久
    // 修 正 日  2013/01/07  修正内容 : 仕入返品予定機能対応
    //----------------------------------------------------------------------------//
    /// <br>Update Note : 2013/01/08 鄭慕鈞</br>
    /// <br>管理番号    : 10801804-00 2013/03/13配信分</br>
    /// <br>            : redmine#31984 仕入伝票入力の操作便利の対応</br>
    /// <br>Update Note: 2014/01/07 譚洪</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : Redmine#41771 仕入伝票入力消費税8%増税対応</br>
    /// <br>Update Note : 2014/09/01 衛忠明</br>
    /// <br>管理番号    : 11070149-00</br>
    /// <br>            : redmine #43374 仕入伝票入力(保存後ロゴ表示制御)</br>
    /// <br>Update Note : 2015/03/25 黄興貴</br>
    /// <br>管理番号    : 11175104-00</br>
    /// <br>            : Redmine#45073 宮田自動車商会 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応</br>
    /// <br>UpdateNote  : 2017/08/11 譚洪  </br>
    /// <br>管理番号    : 11370074-00</br>
    /// <br>              ハンディターミナル在庫仕入登録の対応</br> 
    /// <br>Update Note: 2020/06/22 陳艶丹</br>
    /// <br>管理番号   : 11670231-00</br>
    /// <br>           : PMKOBETSU-4017 11600575_東邦車両サービス(仕入データテキスト入力)</br>
    /// <br>Update Note : 2021/12/19 陳艶丹</br>
    /// <br>管理番号    : 11770181-00</br>
    /// <br>            : PMKOBETSU-4200 設定ファイルの保存場所読込順番を改良対応</br>
    /// </remarks>
	public class StockSlipInputAcs
	{ 
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region ■Constructor
		/// <summary>
		/// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
		private StockSlipInputAcs()
		{
			// 変数初期化
			this._dataSet = new StockInputDataSet();
			this._stockDetailDataTable = this._dataSet.StockDetail;
			this._addUpSrcDetailDataTable = this._dataSet.AddUpSrcDetail;
			this._salesTempDataTable = this._dataSet.SalesTemp;
			this._addUpSrcSalesSlipDataTable = this._dataSet.AddUpSrcSalesSlip;
			this._addUpSrcSalesDetailDataTable = this._dataSet.AddUpSrcSalesDetail;
			this._stockInfoDataTable = this._dataSet.StockInfo;
			this._stockSlip = new StockSlip();
			this._stockSlipDBData = new StockSlip();
			this._stockDetailDBDataList = new List<StockDetail>();
			this._unitPriceCalculation = new UnitPriceCalculation();
			//this._unitPriceCalculation.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
			this._stockPriceCalculate = new StockPriceCalculate();
			this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
			this._stockSlipInputInitDataAcs.CacheStockProcMoneyList += new StockSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._stockPriceCalculate.CacheStockProcMoneyList);
			this._stockSlipInputInitDataAcs.CacheStockProcMoneyList += new StockSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._unitPriceCalculation.CacheStockProcMoneyList);

			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._paymentSlp = new PaymentSlp();
            this._paymentDtlList = new List<PaymentDtl>();
			//this._salesTempInputAcs = SalesTempInputAcs.GetInstance();
			//this._salesTempInputAcs.CacheSalesTemp += new SalesTempInputAcs.CacheSalesTempEventHandler(this.CacheSalesTemp);
			this._stockInputConstructionAcs = StockSlipInputConstructionAcs.GetInstance();
            this._stockSlipInputConstructionAcsLog = StockSlipInputConstructionAcsLog.GetInstance(); // ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)
            this._goodsDictionary = new Dictionary<string, GoodsUnitData>();

			this._stockDetailDataView = new DataView(this._stockDetailDataTable);
        }

        // ---------- ADD 2010/05/04 ----------------->>>>>
        // 操作権限の制御オブジェクトの保有
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("MAKON01100U", this);
                }
                return _operationAuthority;
            }
        }
        // ---------- ADD 2010/05/04 -----------------<<<<<

		/// <summary>
		/// 仕入入力アクセスクラス インスタンス取得処理
		/// </summary>
		/// <returns>仕入入力アクセスクラス インスタンス</returns>
        public static StockSlipInputAcs GetInstance()
		{
			if (_stockSlipInputAcs == null)
			{
                _stockSlipInputAcs = new StockSlipInputAcs();
			}

			return _stockSlipInputAcs;
        }
		# endregion

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        #region ▼定数（ハンディターミナル用）
        
        /// <summary>ハンディターミナルコンストラクタのモード</summary>
        private const string ConstructorsModeHandy = "Handy";

        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムID</summary>
        private const string AssemblyIdPmhnd01114d = "PMHND01114D";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01114dClassName = "Broadleaf.Application.Remoting.ParamData.HandyNonUOEInspectParamWork";

        /// <summary>仕入形式「0:仕入」</summary>
        private const int SupplierFormalSupplier = 0;
        /// <summary>買掛区分「1:買掛」</summary>
        private const int AccPayDivCdNone = 1;
        /// <summary>商品区分「0:商品」</summary>
        private const int StockGoodsCdGoods = 0;

        /// <summary>仕入明細通番</summary>
        private const string StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary>更新区分</summary>
        private const string PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary>検品数</summary>
        private const string InspectCnt = "InspectCnt";
        #endregion
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
        // チェックエラー情報
        private const string CT_ERROR_MEASSSAGE00 = "項目数不正";
        private const string CT_ERROR_MEASSSAGE01 = "受注番号不正";
        private const string CT_ERROR_MEASSSAGE02 = "部品コード不正";
        private const string CT_ERROR_MEASSSAGE03 = "商品未登録";
        private const string CT_ERROR_MEASSSAGE04 = "在庫未登録";
        private const string CT_ERROR_MEASSSAGE05 = "出荷数量不正";
        private const string CT_ERROR_MEASSSAGE06 = "受注単価不正";
        private const string CT_ERROR_MEASSSAGE07 = "伝票番号不正";
        private const string CT_ERROR_MEASSSAGE08 = "環境(システム)日付不正";
        private const string CT_ERROR_MEASSSAGE09 = "汎用ＸＭＬﾌｧｲﾙを設定してください。";
        private const string CT_ERROR_MEASSSAGE10 = "汎用ＸＭＬﾌｧｲﾙの仕入先を設定してください。";
        private const string CT_ERROR_MEASSSAGE11 = "取込に失敗しました。";
        private const string CT_ERROR_MEASSSAGE12 = "取込を開始しますか？";
        private const string CT_ERROR_MEASSSAGE13 = "汎用ＸＭＬﾌｧｲﾙの仕入先が不正です。";
        private const string CT_ERROR_MEASSSAGE14 = "取込データを99件以下にしてください。";
        private const string CT_ERROR_MEASSSAGE15 = "取込数が入力行数設定値を超えています。";
        private const string CT_ERROR_MEASSSAGE16 = "該当するデータがありません。";
        private const string CT_ERROR_MEASSSAGE17 = "品番不正";
        private const string CT_ERROR_MEASSSAGE18 = "仕入先不正";

        /// <summary>取込最大行数</summary>
        private const int InPutMaxLength = 100; // 99は仕入伝票明細に登録できる明細数の上限値
        /// <summary>伝票区分：仕入</summary>
        private const string StockDiv = "10";
        /// <summary>伝票区分：返品</summary>
        private const string ReturnDiv = "20";

        // エラーデータ出力用テーブル
        DataTable ErrDataTable;

        /// <summary>XMLファイル</summary>
        private const string XmlFileName = "StockDefaultDataInputText.xml";

        #region ■ テーブルのカラム
        /// <summary> 受注番号 </summary>
        private const string CT_Col_AcceptAnOrderNo = "AcceptAnOrderNo";
        /// <summary> 部品コード </summary>
        private const string CT_Col_GoodsCode = "GoodsCode";
        /// <summary> 出荷数量① </summary>
        private const string CT_Col_ShipmentCnt1 = "ShipmentCnt1";
        /// <summary> 受注単価 </summary>
        private const string CT_Col_AcceptAnOrderUnCst = "AcceptAnOrderUnCst";
        /// <summary> 環境(システム)日付 </summary>
        private const string CT_Col_SysDate = "SysDate";
        /// <summary> エラー内容 </summary>
        private const string CT_Col_ErrContent = "ErrContent";
        /// <summary> 仕入先 </summary>
        private const string CT_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入伝票番号 </summary>
        private const string CT_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> 品番 </summary>
        private const string CT_Col_GoodsNo = "GoodsNo";

        #endregion
        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<

        // ===================================================================================== //
		// プライベート変数2
		// ===================================================================================== //
		# region ■Private Members
		private static StockSlipInputAcs _stockSlipInputAcs;
		private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;
		//private SalesTempInputAcs _salesTempInputAcs;
		private StockPriceCalculate _stockPriceCalculate;
		private StockInputDataSet _dataSet;
		private StockSlip _stockSlip;
		private StockSlip _stockSlipDBData;
		private int _currentSupplierSlipNo = 0;
		private StockInputDataSet.StockDetailDataTable _stockDetailDataTable;
		private StockInputDataSet.AddUpSrcDetailDataTable _addUpSrcDetailDataTable;
		private StockInputDataSet.SalesTempDataTable _salesTempDataTable;
		private StockInputDataSet.AddUpSrcSalesSlipDataTable _addUpSrcSalesSlipDataTable;
		private StockInputDataSet.AddUpSrcSalesDetailDataTable _addUpSrcSalesDetailDataTable;
		private StockInputDataSet.StockInfoDataTable _stockInfoDataTable;
        private List<StockDetail> _stockDetailDBDataList;
        private IIOWriteControlDB _iIOWriteControlDB;
		private IStockSlipDB _iStockSlipDB;
		private string _enterpriseCode;
		private bool _isDataCanged = false;
		private CustomerInfoAcs _customerInfoAcs;
		private SupplierAcs _supplierAcs;
		private SearchStockAcs _searchStockAcs;
		private UnitPriceCalculation _unitPriceCalculation;                         // 単価算出部品
		private PaymentSlp _paymentSlp;                                             // 支払データ
        private List<PaymentDtl> _paymentDtlList;                                   // 支払明細データ
        private TotalDayCalculator _totalDayCalculator;                             // 締日チェック部品
        // --- ADD m.suzuki 2010/11/12 ---------->>>>>
        private DateGetAcs _dateGetAcs; // 日付取得部品
        // --- ADD m.suzuki 2010/11/12 ----------<<<<<
        private StockSlipInputConstructionAcs _stockInputConstructionAcs;
        private StockSlipInputConstructionAcsLog _stockSlipInputConstructionAcsLog;　// ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)
		private DataView _stockDetailDataView;
        private Dictionary<string, GoodsUnitData> _goodsDictionary;

		private readonly string cRelation_Detail_AddUpSrcDetail = "Detail_AddUpSrcDetail";
		private readonly string cRelation_Detail_SalesTemp = "StockDetail_SalesTemp";
        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト　// ADD 2010/05/04
        // ---ADD 2011/07/18----------->>>>>
        private bool _hasStockInfo = false;
        private int _stockRowNo = 0;
        private bool _isShipmentChange = false;
        // ---ADD 2011/07/18-----------<<<<<
        //add 2011/12/27 陳建明 Redmine #27374----->>>>>
        private List<StockDetail> _stockDetailList = null;
        private List<StockDetail> _addUpSrcDetailList = null;
        private List<StockWork> _stockWorkList = null;
        //add 2011/12/27 陳建明 Redmine #27374-----<<<<<
        //ADD 2012/03/13 鄧潘ハン Redmine #27374----->>>>>
        private StockSlip _deleteStockSlip = null;
        private List<StockDetail> _deleteStockDetailList = null;
        private List<StockDetail> _deleteAddUpSrcDetailList = null;
        private PaymentSlp _deletePaymentSlp = null;
        private List<PaymentDtl> _deletePaymentDtlList = null;
        private List<StockWork> _deleteStockWorkList = null;
        private bool _isCannotModify = false;
        //ADD 2012/03/13 鄧潘ハン Redmine #27374-----<<<<<
        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
        // エラー件数
        private int ErrStockCount = 0;
        // 仕入画面に展開できるデータ
        private List<InitDataItem> CanDoStockDataWorkList = new List<InitDataItem>();
        // エラーログファイル
        private string ErrFileName = string.Empty;
        // 取込ファイル
        private string FileName = string.Empty;
        // 拠点設定の倉庫リスト
        private Dictionary<string, string> WarehouseDictionary = new Dictionary<string, string>();
        // 0:東邦車両様、1:東邦車両様以外
        private int UserDiv = 0;
        // １行目レコード
        private InitDataItem FirstInitData = new InitDataItem();
        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<

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

		/// <summary>行編集ステータス（仕入数量のみ編集可能）</summary>
		public static readonly int ctEDITSTATUS_StockCountOnly = 1;

		/// <summary>行編集ステータス（全項目無効）</summary>
		public static readonly int ctEDITSTATUS_AllDisable = 2;

		/// <summary>行編集ステータス（全項目参照のみ）</summary>
		public static readonly int ctEDITSTATUS_AllReadOnly = 3;

		/// <summary>行編集ステータス（入荷計上新規／仕入数量、単価、備考のみ編集可能）</summary>
		public static readonly int ctEDITSTATUS_ArrivalAddUpNew = 4;

		/// <summary>行編集ステータス（入荷計上編集／単価のみ編集可能）</summary>
		public static readonly int ctEDITSTATUS_ArrivalAddUpEdit = 5;

        /// <summary>行編集ステータス（行値引き／仕入金額のみ編集可能）</summary>
        public static readonly int ctEDITSTATUS_RowDiscount = 6;

		/// <summary>行編集ステータス（商品値引き）</summary>
		public static readonly int ctEDITSTATUS_GoodsDiscount = 7;

		/// <summary>入力モード（通常）</summary>
		public static readonly int ctINPUTMODE_StockSlip_Normal = 0;

		/// <summary>入力モード（返品）</summary>
		public static readonly int ctINPUTMODE_StockSlip_Return = 1;

		/// <summary>入力モード（赤伝）</summary>
		public static readonly int ctINPUTMODE_StockSlip_Red = 2;

		/// <summary>入力モード（入荷計上）</summary>
		public static readonly int ctINPUTMODE_StockSlip_ArrivalAddUp = 3;

		/// <summary>入力モード（締め済み）</summary>
		public static readonly int ctINPUTMODE_StockSlip_AddUp = 4;

		/// <summary>入力モード（読み取り専用）</summary>
		public static readonly int ctINPUTMODE_StockSlip_ReadOnly = 5;

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

        # endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region ■Events
		/// <summary>データ変更後発生イベント</summary>
		public event EventHandler DataChanged;
		# endregion

		// ===================================================================================== //
		// 列挙体
		// ===================================================================================== //
		# region ■Enums
		/// <summary>
		/// 価格入力モード列挙型
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
		/// 明細データ展開方法（各種履歴からの明細展開時に使用）
		/// </summary>
		public enum WayToDetailExpand : int
		{
			/// <summary>通常（明細のコピー）</summary>
			Normal = 0,
            /// <summary>計上（同時入力は対象外）</summary>
            AddUp = 1,
            // 2009.04.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            /// <summary>計上（残検索）</summary>
            AddUpRemainder = 2,
            // 2009.04.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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

        // ------ ADD 2010/05/04 ------------------>>>>>
        /// <summary>
        /// オペレーションコード
        /// </summary>
        public enum OperationCode : int
        {
            /// <summary>伝票値引</summary>
            Discount = 15,
            /// <summary>数量マイナス</summary>
            QuantityMinus = 16
        }
        // ------ ADD 2010/05/04 ------------------<<<<<
		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region ■Properties
		/// <summary>
		/// 仕入明細データテーブルオブジェクトを取得します。
		/// </summary>
		public StockInputDataSet.StockDetailDataTable StockDetailDataTable
		{
			get { return _stockDetailDataTable; }
		}

#if DEBUG
		/// <summary>
		/// リンク用仕入明細データテーブルオブジェクトを取得します。
		/// </summary>
		public StockInputDataSet.AddUpSrcDetailDataTable LnkStockDetailDataTable
		{
			get { return _addUpSrcDetailDataTable; }
		}
#endif

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

        /// <summary>仕入データ(読取専用)</summary>
		public StockSlip StockSlip
		{
			get
			{
				return this._stockSlip;
			}
		}
		/// <summary>支払データ(読取専用)</summary>
        public PaymentSlp PaymentSlp
		{
			get
			{
                return this._paymentSlp;
			}
		}

        /// <summary>支払明細データリスト(読取専用)</summary>
        public List<PaymentDtl> PaymentDtlList
        {
            get
            {
                return this._paymentDtlList;
            }
        }
        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
        /// <summary>ファイル仕入データ(読取専用)</summary>
        public List<InitDataItem> StockDataWorkList
        {
            get
            {
                return CanDoStockDataWorkList;
            }

        }

        /// <summary>エラー件数(読取専用)</summary>
        public int ErrorStockCount
        {
            get
            {
                return ErrStockCount;
            }

        }

        /// <summary>取込ファイル(読取専用)</summary>
        public string StockFileName
        {
            get
            {
                return FileName;
            }
        }

        /// <summary>エラーログファイル(読取専用)</summary>
        public string ErrStockFileName
        {
            get
            {
                return ErrFileName;
            }
        }

        /// <summary>0:東邦車両様、1:東邦車両様以外</summary>
        public int UserDivForForm
        {
            get
            {
                return UserDiv;
            }

        }

        /// <summary>１行目レコード</summary>
        public InitDataItem FirstInitDataForForm
        {
            get
            {
                return FirstInitData;
            }

        }
        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<

        // ---ADD 2011/07/18-------------->>>>>
        /// <summary>
        /// 在庫情報存在フラグ
        /// </summary>
        public bool HasStockInfo
        {
            get { return _hasStockInfo; }
            set { _hasStockInfo = value; }
        }
        /// <summary>
        /// 行番号フラグ
        /// </summary>
        public int StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }
        /// <summary>
        /// 数量変更フラグ
        /// </summary>
        public bool IsShipmentChange
        {
            get { return _isShipmentChange; }
            set { _isShipmentChange = value; }
        }
        //add 2011/12/27 陳建明 Redmine #27374----->>>>>
        /// <summary>
        /// 仕入明細データオブジェクトリスト(読取専用)
        /// </summary>
	    public List<StockDetail> StockDetailList
	    {
            get { return _stockDetailList; }
	    }
        /// <summary>
        /// 計上元仕入明細データオブジェクトリスト(読取専用)
        /// </summary>
	    public List<StockDetail> AddUpSrcDetailList
	    {
            get { return _addUpSrcDetailList; }
	    }
        /// <summary>
        /// 在庫ワークオブジェクトリスト(読取専用)
        /// </summary>
	    public List<StockWork> StockWorkList
	    {
            get { return _stockWorkList; }
	    }
        //add 2011/12/27 陳建明 Redmine #27374-----<<<<<
	    // ---ADD 2011/07/18--------------<<<<<

        //ADD 2012/03/13 鄧潘ハン Redmine #27374----->>>>>

        /// <summary>
        /// 削除仕入データオブジェクト
        /// </summary>
        public StockSlip DeleteStockSlip
        {
            get { return _deleteStockSlip; }
            set { _deleteStockSlip = value; }
        }

        /// <summary>
        /// 削除仕入明細データオブジェクトリスト
        /// </summary>
        public List<StockDetail>  DeleteStockDetailList
        {
            get { return _deleteStockDetailList; }
            set { _deleteStockDetailList = value; }
        }

        /// <summary>
        /// 削除計上元仕入明細データオブジェクトリスト
        /// </summary>
        public List<StockDetail> DeleteAddUpSrcDetailList
        {
            get { return _deleteAddUpSrcDetailList; }
            set { _deleteAddUpSrcDetailList = value; }
        }

        /// <summary>
        /// 削除支払データオブジェクト
        /// </summary>
        public PaymentSlp DeletePaymentSlp
        {
            get { return _deletePaymentSlp; }
            set { _deletePaymentSlp = value; }
        }

        /// <summary>
        /// 削除支払明細データリスト
        /// </summary>
        public List<PaymentDtl> DeletePaymentDtlList
        {
            get { return _deletePaymentDtlList; }
            set { _deletePaymentDtlList = value; }
        }

        /// <summary>
        /// 削除在庫ワークオブジェクトリスト
        /// </summary>
        public List<StockWork> DeleteStockWorkList
        {
            get { return _deleteStockWorkList; }
            set { _deleteStockWorkList = value; }
        }

        /// <summary>
        /// Modifyフラグ
        /// </summary>
        public bool IsCannotModify
        {
            get { return _isCannotModify; }
            set { _isCannotModify = value; }
        }
        //ADD 2012/03/13 鄧潘ハン Redmine #27374-----<<<<<
		# endregion

        // ===================================================================================== //
        // 構造体
        // ===================================================================================== //
        #region ■Struct

        #endregion

        // ===================================================================================== //
		// DBデータアクセス処理
		// ===================================================================================== //
		# region ■DataBase Access Methods
		/// <summary>
		/// 仕入データの保存を行います。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
		/// <param name="retMessage">メッセージ（out）</param>
		/// <returns>STATUS</returns>
		public int SaveDBData(string enterpriseCode, int supplierSlipNo, out string retMessage)
		{
			List<StockDetail> stockDetailList;
			List<StockDetail> addUpSrcDetailList = new List<StockDetail>();
			List<SalesTemp> salesTempList = new List<SalesTemp>();
			List<SalesTemp> savedSalesTempList = new List<SalesTemp>();
			PaymentSlp paymentSlp = null;
            List<PaymentDtl> paymentDtlList = null;

			this.GetCurrentStockDetail(out stockDetailList, out salesTempList, out savedSalesTempList);

            this.ClearGoodsCacheInfo();
            this.ReSearchGoods();

            this.GetCurrentPaymentData(this._stockSlip, out paymentSlp, out paymentDtlList);

            retMessage = string.Empty;
            return this.SaveDBData(this._stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, salesTempList, savedSalesTempList, out retMessage);
        }

		/// <summary>
		/// 仕入データの保存を行います。（オーバーロード）
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データリストオブジェクト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データリストオブジェクト</param>
		/// <param name="paymentSlp">支払データオブジェクト</param>
        /// <param name="paymentDtlList">支払明細データオブジェクトリスト</param>
		/// <param name="salesTempList">同時売上データリスト</param>
		/// <param name="savedSalesTempList">保存済みの同時売上データオブジェクト</param>
		/// <param name="retMessage">メッセージ（out）</param>
		/// <returns>STATUS</returns>
        /// <br>Update Note : 2013/01/08 鄭慕鈞</br>
        /// <br>管理番号    : 10801804-00 2013/03/13配信分</br>
        /// <br>            : redmine#31984 仕入伝票入力の操作便利の対応</br>
		private int SaveDBData( StockSlip stockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, PaymentSlp paymentSlp,List<PaymentDtl> paymentDtlList, List<SalesTemp> salesTempList, List<SalesTemp> savedSalesTempList, out string retMessage )
		{
			//------------------------------------------------------------------------------------
			// 書き込み時のCustomSerializeArrayListの構造
			//------------------------------------------------------------------------------------
			//  CustomSerializeArrayList            書き込みパラメータリスト
			//      --IOWriteCtrlOptWork			IOWrite制御ワークオブジェクト
			//      --CustomSerializeArrayList      仕入リスト
			//          --SalesSlipWork             仕入データオブジェクト
			//          --ArrayList                 仕入明細リスト
			//              --SalesDetailWork       仕入明細データオブジェクト
			//          --DepsitMainWork            支払データオブジェクト
			//      --CustomSerializeArrayList      同時売上情報
			//          --SalesTempWork             同時入力売上データオブジェクト
			//------------------------------------------------------------------------------------
			CustomSerializeArrayList dataList = new CustomSerializeArrayList();

			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			//==========<< 仕入リストのセット >>==========//
			CustomSerializeArrayList stockSlipDataList = new CustomSerializeArrayList();

			// ①仕入データの補正
			stockSlip.EnterpriseCode = this._enterpriseCode;
			stockSlip.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
			stockSlip.InputDay = DateTime.Today;
            stockSlip.StockSlipUpdateCd = ( stockSlip.SupplierSlipNo == 0 ) ? 0 : 1;    // 仕入伝票更新区分
			stockSlip.DetailRowCount = stockDetailList.Count;

			// 返品伝票の場合の伝票発行区分
			if (( stockSlip.SupplierFormal == 0 ) &&
				( stockSlip.SupplierSlipCd == 20 ) &&
				( this._stockSlipInputInitDataAcs.GetStockTtlSt().RgdsSlipPrtDiv == 1 ))
			{
				stockSlip.SlipPrintDivCd = 1;
			}

            if (( paymentSlp != null ) && ( paymentDtlList != null ) && ( paymentDtlList.Count > 0 ))
                stockSlip.AutoPayment = 1;

			// ②仕入明細データワーククラスリスト、生成
			ArrayList stockDetailArrayList = new ArrayList();
			ArrayList slipDetailAddInfoWorkList = new ArrayList();
			
			foreach (StockDetail stockDetail in stockDetailList)
			{
				stockDetail.EnterpriseCode = this._enterpriseCode;
				stockDetail.SectionCode = stockSlip.SectionCode;
				stockDetail.SupplierFormal = stockSlip.SupplierFormal;
				stockDetail.SupplierSlipNo = stockSlip.SupplierSlipNo;
				stockDetail.DtlRelationGuid = Guid.NewGuid();

				// 仕入在庫取寄せ区分
                stockDetail.StockOrderDivCd = ( string.IsNullOrEmpty(stockDetail.WarehouseCode.Trim()) ) ? 0 : 1;
				if (stockDetail.StockSlipDtlNumSrc == 0) stockDetail.SupplierFormalSrc = -1;

				stockDetailArrayList.Add(ConvertStockSlip.ParamDataFromUIData(stockDetail));

				// 明細追加情報
				SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
				slipDetailAddInfoWork.DtlRelationGuid = stockDetail.DtlRelationGuid;		// 明細関連付けGUID

                // 品番・メーカーが入力されていて、仕入行の場合
                if (( !string.IsNullOrEmpty(stockDetail.GoodsNo) && ( stockDetail.GoodsMakerCd != 0 ) ) && ( stockDetail.StockSlipCdDtl == 0 ))
                {
                    GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(stockDetail.GoodsNo, stockDetail.GoodsMakerCd);

                    // 2009.03.27 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //// 商品自動登録：する
                    //if (this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoEntryGoodsDivCd == 1)
                    //{
                    //    if (( goodsUnitData == null ) || ( goodsUnitData.OfferKubun >= 3 ))
                    //    {
                    //        if (goodsUnitData == null) goodsUnitData = new GoodsUnitData();

                    //        slipDetailAddInfoWork.GoodsEntryDiv = 1;                            // 商品登録区分
                    //        slipDetailAddInfoWork.GoodsOfferDate = goodsUnitData.OfferDate;     // 商品提供日

                    //        GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice(( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);
                    //        if (goodsPrice != null)
                    //        {
                    //            slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;    // 価格提供日
                    //        }
                    //        slipDetailAddInfoWork.PriceStartDate = ( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay; // 価格開始日
                    //        slipDetailAddInfoWork.PriceUpdateDiv = 1;
                    //    }
                    //}
                    //else
                    //{
                    //    if (( goodsUnitData != null ) && ( goodsUnitData.OfferKubun <= 2 ))
                    //    {
                    //        GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice(( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);

                    //        // 商品自動登録が「しない」場合のみ、価格更新区分を設定
                    //        slipDetailAddInfoWork.PriceUpdateDiv = stockSlip.PriceCostUpdtDiv;			// 価格更新区分

                    //        if (goodsPrice != null)
                    //        {
                    //            slipDetailAddInfoWork.PriceStartDate = goodsPrice.PriceStartDate;       // 価格開始日
                    //            slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;			// 価格提供日
                    //        }
                    //        else
                    //        {
                    //            slipDetailAddInfoWork.PriceStartDate = ( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay; // 価格開始日
                    //        }
                    //    }
                    //}

                    // 商品自動登録：する
                    if ((this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoEntryGoodsDivCd == 1) &&
                        ((goodsUnitData == null) || (goodsUnitData.OfferKubun >= 3)))
                    {
                        if (goodsUnitData == null) goodsUnitData = new GoodsUnitData();

                        slipDetailAddInfoWork.GoodsEntryDiv = 1;                            // 商品登録区分
                        slipDetailAddInfoWork.GoodsOfferDate = goodsUnitData.OfferDate;     // 商品提供日

                        GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice((stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);
                        if (goodsPrice != null)
                        {
                            slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;    // 価格提供日
                        }
                        // --- UPD m.suzuki 2010/11/12 ---------->>>>>
                        //slipDetailAddInfoWork.PriceStartDate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay; // 価格開始日
                        slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate( stockSlip ); // 価格開始日
                        // --- UPD m.suzuki 2010/11/12 ----------<<<<<
                        slipDetailAddInfoWork.PriceUpdateDiv = 1;
                    }
                    else
                    {
                        //>>>2010/09/15
                        //if (goodsUnitData != null)
                        if ((goodsUnitData != null) && (goodsUnitData.OfferKubun < 3))
                        //<<<2010/09/15
                        {
                            GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice((stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);

                            slipDetailAddInfoWork.PriceUpdateDiv = stockSlip.PriceCostUpdtDiv;			// 価格更新区分
                            if (goodsPrice != null)
                            {
                                slipDetailAddInfoWork.PriceStartDate = goodsPrice.PriceStartDate;       // 価格開始日
                                slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;			// 価格提供日
                            }
                            else
                            {
                                // --- UPD m.suzuki 2010/11/12 ---------->>>>>
                                //slipDetailAddInfoWork.PriceStartDate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay; // 価格開始日
                                slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate( stockSlip );
                                // --- UPD m.suzuki 2010/11/12 ----------<<<<<
                            }
                        }
                    }
                    // 2009.03.27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

				slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
			}

            // --- ADD 譚洪 2014/01/07 ------------ >>>>>>
            // stockSlip.SupplierSlipCd が 20:返品の場合、stockSlip.DebitNoteDiv が 1:赤伝の場合、
            if (stockSlip.DebitNoteDiv == 1 || 
                (stockSlip.SupplierSlipCd == 20 && stockDetailArrayList.Count > 0 && ((StockDetailWork)stockDetailArrayList[0]).StockSlipDtlNumSrc != 0))
            {
                // 消費税転嫁方式編集判断メソッドの返値がtrueの場合、
                if (CheckConsTaxLayMethod(stockSlip))
                {
                    // 仕入データ(StockSlipRf).仕入先消費税転嫁方式(SuppCTaxLayCdRF)＝０：伝票単位
                    stockSlip.SuppCTaxLayCd = 0;
                }
            }
            // --- ADD 譚洪 2014/01/07 ------------ <<<<<<

			stockSlipDataList.Add(ConvertStockSlip.ParamDataFromUIData(stockSlip));

			if (stockDetailArrayList.Count > 0) stockSlipDataList.Add(stockDetailArrayList);

			if (slipDetailAddInfoWorkList.Count > 0) stockSlipDataList.Add(slipDetailAddInfoWorkList);

			// ③同時支払情報ワーククラスセット
            if (( paymentSlp != null ) && ( paymentDtlList != null ) && ( paymentDtlList.Count > 0 ))
			{
                stockSlipDataList.Add(this.CreatePaymentDataWork(paymentSlp, paymentDtlList));
			}

			//==========<< 同時入力売上リスト >>==========//
			CustomSerializeArrayList salesTempDataList = new CustomSerializeArrayList();

			ArrayList salesTempArrayList = new ArrayList();
			foreach (SalesTemp salesTemp in salesTempList)
			{
				salesTemp.EnterpriseCode = this._enterpriseCode;
				salesTemp.SectionCode = stockSlip.SectionCode;
				salesTemp.SalesOrderDivCd = ( !string.IsNullOrEmpty(salesTemp.WarehouseCode.Trim()) ) ? 1 : 0;
				salesTempDataList.Add(ConvertStockSlip.ParamDataFromUIData(salesTemp));
			}


			// 書き込みパラメータのセット
			dataList.Add(iOWriteCtrlOptWork);
			dataList.Add(stockSlipDataList);
			if (salesTempDataList.Count > 0) dataList.Add(salesTempDataList);

			object dataObj = (object)dataList;

            retMessage = string.Empty;
			string retItemInfo;
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			if (stockSlip.DebitNoteDiv == 1)
			{
				// 赤伝の場合、元黒のデータを取得する
				StockSlip nLnkStockSlip = new StockSlip();
                StockSlip nLnkBaseStockSlip; // 2009.03.25
				List<StockDetail> nLnkStockDetailList;
				List<StockDetail> nLnkaddUpSrcDetailList;
                PaymentSlp nLnkPaymentSlp;
                List<PaymentDtl> nLnkPaymentDtlList;
				List<SalesTemp> nLnkSalesTempList;
				List<StockWork> nLnkStockWorkList;

                //status = this.ReadDBData(stockSlip.EnterpriseCode, stockSlip.SupplierFormal, stockSlip.DebitNLnkSuppSlipNo, false, out nLnkStockSlip, out nLnkStockDetailList, out nLnkaddUpSrcDetailList, out nLnkPaymentSlp, out nLnkPaymentDtlList, out nLnkSalesTempList, out nLnkStockWorkList); // 2009.03.25
                status = this.ReadDBData(stockSlip.EnterpriseCode, stockSlip.SupplierFormal, stockSlip.DebitNLnkSuppSlipNo, false, out nLnkStockSlip, out nLnkBaseStockSlip, out nLnkStockDetailList, out nLnkaddUpSrcDetailList, out nLnkPaymentSlp, out nLnkPaymentDtlList, out nLnkSalesTempList, out nLnkStockWorkList); // 2009.03.25

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					CustomSerializeArrayList originDataList = new CustomSerializeArrayList();

					originDataList.Add(ConvertStockSlip.ParamDataFromUIData(nLnkStockSlip));

					object originDataObj = (object)originDataList;

                    if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
					status = this._iIOWriteControlDB.RedWrite(ref originDataObj, ref dataObj, out retMessage, out retItemInfo);
				}
			}
			else
			{
                if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
				status = this._iIOWriteControlDB.Write(ref dataObj, out retMessage, out retItemInfo);
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				dataList = (CustomSerializeArrayList)dataObj;
				StockSlipWork stockSlipWork;
				StockDetailWork[] stockDetailWorkArray;
                AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray;
				PaymentDataWork paymentDataWork;
				StockWork[] stockWorkArray;
				SalesTempWork[] salesTempWorkArray;
				List<StockWork> stockWorkList = new List<StockWork>();

				// CustomSerializeArrayList分割処理
                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWritingResult(dataList, out stockSlipWork, out stockDetailWorkArray, out addUpOrgStockDetailWorkArray, out paymentDataWork, out stockWorkArray, out salesTempWorkArray);

				stockSlip = ConvertStockSlip.UIDataFromParamData(stockSlipWork);
				stockDetailList = ConvertStockSlip.UIDataFromParamData(stockDetailWorkArray);
				addUpSrcDetailList = ConvertStockSlip.UIDataFromParamData(addUpOrgStockDetailWorkArray);

                this.DivisionPaymentDataWork(paymentDataWork, out paymentSlp, out paymentDtlList);

				salesTempList = ConvertStockSlip.UIDataFromParamData(salesTempWorkArray);
				if (( stockWorkArray != null ) && ( stockWorkArray.Length > 0 ))
					stockWorkList.AddRange(stockWorkArray);

				// 同時入力分の修正データは、Saveメソッドで更新しないので、読み込む前の情報をそのまま使用する
				if (( savedSalesTempList != null ) && ( savedSalesTempList.Count > 0 ))
				{
					if (salesTempList == null) salesTempList = new List<SalesTemp>();

					salesTempList.AddRange(savedSalesTempList);
				}

                if (paymentDataWork != null)
                {
                }

                this.AdjustStockSaveDBData(ref stockSlip, ref stockDetailList);

				// 入力モード設定処理
				this.SettingInputMode(stockSlip);

                //----ADD  2013/01/08 Readmine#31984  鄭慕鈞  ----->>>>>
                //設定画面の保存後の初期化を「しない」に設定した場合、
                //明細グリッドに前回発行した仕入伝票の仕入明細データを初期化するために、
                //仕入明細データの仕入明細通番をクリアする処理を追加する
                //クリア処理範囲は赤伝以外
                if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF && stockSlip.DebitNoteDiv!=1)
                {
                    foreach (StockDetail stockDetail in stockDetailList)
                    {
                        stockDetail.AcceptAnOrderNo = 0;                   //受注番号
                        stockDetail.CommonSeqNo = 0;                       //共通通番
                        stockDetail.StockSlipDtlNum = 0;                   //仕入明細通番
                    }
                }
                //----ADD  2013/01/08 Readmine#31984  鄭慕鈞  -----<<<<<

				// 仕入データキャッシュ
                this.Cache(stockSlip, stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, salesTempList, stockWorkList);
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
			{
				dataList = (CustomSerializeArrayList)dataObj;
				StockSlipWork stockSlipWork;
				StockDetailWork[] stockDetailWorkArray;
                AddUpOrgStockDetailWork[] addUppOrgStockDetailWork;
				StockWork[] stockWorkArray;
				PaymentDataWork paymentDataWork;
				SalesTempWork[] salesTempWorkArray;

				// CustomSerializeArrayList分割処理
                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWritingResult(dataList, out stockSlipWork, out stockDetailWorkArray, out addUppOrgStockDetailWork, out paymentDataWork, out stockWorkArray, out salesTempWorkArray);

				stockSlip = ConvertStockSlip.UIDataFromParamData(stockSlipWork);
				stockDetailList = ConvertStockSlip.UIDataFromParamData(stockDetailWorkArray);
				addUpSrcDetailList = ConvertStockSlip.UIDataFromParamData(addUppOrgStockDetailWork);

                this.DivisionPaymentDataWork(paymentDataWork, out paymentSlp, out paymentDtlList);

                this.AdjustStockSaveDBData(ref stockSlip, ref stockDetailList);

				salesTempList = ConvertStockSlip.UIDataFromParamData(salesTempWorkArray);

				// 仕入明細行初期行数追加処理
				this.AddStockDetailRowInitialRowCount();
			}

			return status;
		}
        // --- ADD m.suzuki 2010/11/12 ---------->>>>>
        /// <summary>
        /// 価格開始日取得処理
        /// </summary>
        /// <param name="stockSlip"></param>
        /// <returns></returns>
        private DateTime GetPriceStartDate( StockSlip stockSlip )
        {
            try
            {
                //--------------------------------------------------
                // 通常は、前回月次更新日の翌日
                //--------------------------------------------------
                DateTime prevTotalDay = GetHisTotalDayMonthly();
                if ( prevTotalDay != DateTime.MinValue )
                {
                    // 前回月次更新日の翌日
                    return prevTotalDay.AddDays( 1 );
                }

                //--------------------------------------------------
                // （※新規搬入して一度も月次更新をしていないような場合）自社.期首日
                //--------------------------------------------------
                if ( _dateGetAcs == null )
                {
                    _dateGetAcs = DateGetAcs.GetInstance();
                }
                else
                {
                    _dateGetAcs.ReloadCompanyInf(); // 必ず再取得する
                }
                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;

                CompanyInf companyInf = _dateGetAcs.GetCompanyInf();
                if ( companyInf != null && companyInf.CompanyBiginDate != 0 )
                {
                    _dateGetAcs.GetFinancialYearTable( out startMonthDateList, out endMonthDateList );
                    if ( startMonthDateList != null && startMonthDateList.Count > 0 )
                    {
                        // 期首日←最初の月の開始日
                        return startMonthDateList[0];
                    }
                }
            }
            catch
            {
            }

            //--------------------------------------------------
            // ※通常は発生しないが前回月次更新日も期首日も取得できない場合は、
            // 　仕様変更前と同様に、仕入日or入荷日をセットする。
            //--------------------------------------------------
            return (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
        }
        /// <summary>
        /// 前回月次更新日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetHisTotalDayMonthly()
        {
            if ( _totalDayCalculator == null ) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            int status;
            DateTime prevTotalDay;

            // 締日算出モジュールのキャッシュクリア
            this._totalDayCalculator.ClearCache();

            // 買掛オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment );
            if ( ps == PurchaseStatus.Contract )
            {
                // 買掛オプションあり
                // 売上月次処理日、仕入月次処理日の古い年月取得
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly( string.Empty, out prevTotalDay );
                if ( prevTotalDay == DateTime.MinValue )
                {
                    // 売上月次処理日取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec( string.Empty, out prevTotalDay );
                    if ( prevTotalDay == DateTime.MinValue )
                    {
                        // 仕入月次処理日取得
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay( string.Empty, out prevTotalDay );
                    }
                }
            }
            else
            {
                // 買掛オプションなし
                // 売上月次処理日取得
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec( string.Empty, out prevTotalDay );
            }

            return prevTotalDay;
        }
        // --- ADD m.suzuki 2010/11/12 ----------<<<<<

        // --- ADD 譚洪 2014/01/07 ---------->>>>>
        /// <summary>
        /// 消費税転嫁方式編集判断メソッド
        /// </summary>
        /// <param name="stockSlip">仕入データ</param>
        /// <remarks>
        /// <br>Note       : 消費税転嫁方式編集判断を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/01/07</br>
        /// </remarks>
        /// <returns>true:存在する false:存在しない</returns>
        private bool CheckConsTaxLayMethod(StockSlip stockSlip)
        {
            bool consTaxLayMethodFlg = false;

            // ①元黒の消費税転嫁方式が、請求親又は請求子の場合、
            if (stockSlip.SuppCTaxLayCd == 2 || stockSlip.SuppCTaxLayCd == 3)
            {
                // ②税率設定が２件以上ある場合、
                if (this._stockSlipInputInitDataAcs.GetTaxRateSet().TaxRateStartDate2 != DateTime.MinValue
                    || this._stockSlipInputInitDataAcs.GetTaxRateSet().TaxRateStartDate3 != DateTime.MinValue)
                {
                    double taxRate = this._stockSlipInputInitDataAcs.GetTaxRate(stockSlip.StockDate);

                    // ③元黒売上日付と赤伝売上日付で、税率が違う場合、
                    if (stockSlip.SupplierConsTaxRate != taxRate)
                    {
                        consTaxLayMethodFlg = true;
                    }
                }
            }

            return consTaxLayMethodFlg;
        }
        // --- ADD 譚洪 2014/01/07 ----------<<<<<

		/// <summary>
		/// 仕入データの削除を行います。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="paymentSlp">支払データオブジェクト</param>
        /// <param name="paymentDtlList">支払明細データオブジェクトリスト</param>
		/// <param name="retMessage">メッセージ</param>
		/// <returns>STATUS</returns>
        public int DeleteDBData(StockSlip stockSlip, PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList, out string retMessage)
		{
			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			IOWriteMASIRDeleteWork deleteWork = new IOWriteMASIRDeleteWork();
			deleteWork.EnterpriseCode = stockSlip.EnterpriseCode;
			deleteWork.UpdateDateTime = stockSlip.UpdateDateTime;
			deleteWork.SupplierFormal = stockSlip.SupplierFormal;
			deleteWork.SupplierSlipNo = stockSlip.SupplierSlipNo;
			deleteWork.DebitNoteDiv = stockSlip.DebitNoteDiv;

			CustomSerializeArrayList dataList = new CustomSerializeArrayList();

			dataList.Add(iOWriteCtrlOptWork);
			dataList.Add(deleteWork);

			if (( stockSlip.AutoPayment != 0 ) && ( stockSlip.AutoPaySlipNum != 0 ))
			{
                dataList.Add(this.CreatePaymentDataWork(paymentSlp, paymentDtlList));
			}

            CustomSerializeArrayList stockDetailCustomArrayList = new CustomSerializeArrayList();
            foreach (StockDetail stockDetail in this._stockDetailDBDataList)
            {
                stockDetailCustomArrayList.Add(ConvertStockSlip.ParamDataFromUIData(stockDetail));
            }

            dataList.Add(stockDetailCustomArrayList);

			object dataObj = (object)dataList;

            retMessage = string.Empty;
			string retItemInfo;
            if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
			int status = this._iIOWriteControlDB.Delete(ref dataObj, out retMessage, out retItemInfo);

            //// 仕入明細行初期行数追加処理
            //this.AddStockDetailRowInitialRowCount();

			return status;
		}

		/// <summary>
		/// 仕入データのリードを行います。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="baseStockSlip">補正前仕入データオブジェクト</param>
        /// <returns>STATUS</returns>
        //public int ReadDBData(string enterpriseCode, int supplierFormal, int supplierSlipNo) // 2009.03.25
        public int ReadDBData(string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip baseStockSlip) // 2009.03.25
        {
			StockSlip stockSlip;
			List<StockDetail> stockDetailList;
			List<StockDetail> addUpSrcDetailList;
            PaymentSlp paymentSlp;
            List<PaymentDtl> paymentDtlList;
            List<SalesTemp> salesTempList;
			List<StockWork> stockWorkList;

            //return this.ReadDBData(enterpriseCode, supplierFormal, supplierSlipNo, true, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            return this.ReadDBData(enterpriseCode, supplierFormal, supplierSlipNo, true, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
        }

		/// <summary>
		/// 仕入データのリードを行います。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="stockDetailDataTable">仕入明細テーブル</param>
		/// <returns>STATUS</returns>
        public int ReadDBData(string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out StockInputDataSet.StockDetailDataTable stockDetailDataTable)
        {
            // このメソッドは、仕入伝票照会で使用されている為、消さないで下さい。
            List<StockDetail> addUpSrcDetailList;
            PaymentSlp paymentSlp;
            List<PaymentDtl> paymentDtlList;
            List<SalesTemp> salesTempList;
            StockSlip baseStockSlip; // 2009.03.25

            //return this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockDetailDataTable); // 2009.03.25
            return this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockDetailDataTable); // 2009.03.25
        }


		/// <summary>
		/// 仕入データのリードを行います。（オーバーロード）
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
		/// <param name="isCache">キャッシュ有無</param>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="baseStockSlip">補正前仕入データオブジェクト</param>
        /// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データオブジェクトリスト</param>
		/// <param name="paymentSlp">支払データオブジェクト</param>
        /// <param name="paymentDtlList">支払明細データオブジェクトリスト</param>
		/// <param name="salesTempList">売上データ(仕入同時計上)オブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <returns>STATUS</returns>
        /// <br>Update Note : 2011/12/27 陳建明</br>
        /// <br>管理番号    : 10707327-00 2012/01/25配信分</br>
        /// <br>              redmine#27374 仕入伝票入力/締済のチェックの対応</br>
        /// <br>Update Note : 2012/03/13 鄧潘ハン</br>
        /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
        /// <br>              Redmine#27374 仕入伝票入力でガイドから呼出した場合削除でエラーになる件の対応</br>
        //public int ReadDBData( string enterpriseCode, int supplierFormal, int supplierSlipNo, bool isCache, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList ) // 2009.03.25
        public int ReadDBData(string enterpriseCode, int supplierFormal, int supplierSlipNo, bool isCache, out StockSlip stockSlip, out StockSlip baseStockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList) // 2009.03.25
        {
            //int status = this.ReadDBDataProc(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            int status = this.ReadDBDataProc(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25

            //add 2011/12/27 陳建明 Redmine #27374----->>>>>
            this._stockDetailList = stockDetailList;
            this._paymentSlp = paymentSlp;
            this._paymentDtlList = paymentDtlList;
            this._addUpSrcDetailList = addUpSrcDetailList;
            this._stockWorkList = stockWorkList;
            //add 2011/12/27 陳建明 Redmine #27374-----<<<<<

          

			if (( isCache ) && ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ))
			{
                //add 2012/03/13 鄧潘ハン Redmine #27374----->>>>>
                stockSlip.PreStockDate = stockSlip.StockDate;
                _deleteStockSlip = stockSlip;
                _deleteStockDetailList = stockDetailList;
                _deleteAddUpSrcDetailList = addUpSrcDetailList;
                _deletePaymentSlp = paymentSlp;
                _deletePaymentDtlList = paymentDtlList;
                _deleteStockWorkList = stockWorkList;
                //add 2012/03/13 鄧潘ハン Redmine #27374-----<<<<<

				// 入力モード設定処理
				this.SettingInputMode(stockSlip);

				// 仕入データキャッシュ処理
                this.Cache(stockSlip, stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, salesTempList, stockWorkList);
			}

			return status;
		}

		/// <summary>
		/// 仕入データのリードを行います。（オーバーロード）
		/// </summary>
		/// <param name="logicalMode">論理削除区分</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="baseStockSlip">補正前仕入データオブジェクト</param>
        /// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データオブジェクトリスト</param>
		/// <param name="paymentSlp">同時支払データオブジェクト</param>
        /// <param name="paymentDtlList">同時支払明細データオブジェクトリスト</param>
		/// <param name="salesTempList">仕入データ(売上同時計上)オブジェクトリスト</param>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		/// <returns>STATUS</returns>
        //public int ReadDBData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out StockInputDataSet.StockDetailDataTable stockDetailDataTable ) // 2009.03.25
        public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out StockSlip baseStockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out StockInputDataSet.StockDetailDataTable stockDetailDataTable) // 2009.03.25
        {
			stockDetailList = null;
			stockDetailDataTable = null;
			addUpSrcDetailList = null;
			paymentSlp = null;
			List<StockWork> stockWorkList;

            //int status = this.ReadDBDataProc(logicalMode, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            int status = this.ReadDBDataProc(logicalMode, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				stockDetailDataTable = this.CreateStockDetailDataTable(stockSlip, stockDetailList, addUpSrcDetailList);
			}

			return status;
		}

		/// <summary>
		/// 仕入データのリードを行います。（オーバーロード）
		/// </summary>
		/// <param name="logicalMode">論理削除区分</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="baseStockSlip">補正前仕入データオブジェクト</param>
        /// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データオブジェクトリスト</param>
		/// <param name="paymentSlp">同時支払データオブジェクト</param>
        /// <param name="paymentDtlList">同時支払明細データオブジェクトリスト</param>
		/// <param name="salesTempList">売上データ(仕入同時計上)オブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <returns>STATUS</returns>
        //public int ReadDBData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList ) // 2009.03.25
        public int ReadDBData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out StockSlip baseStockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList ) // 2009.03.25
        {
            //return this.ReadDBDataProc(logicalMode, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            return this.ReadDBDataProc(logicalMode, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); //2009.03.25
        }

		/// <summary>
		/// 仕入データのリードを行います。（オーバーロード）
		/// </summary>
		/// <param name="logicalMode">論理削除区分</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="baseStockSlip">補正前仕入データオブジェクト</param>
        /// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元明細データオブジェクトリスト</param>
        /// <param name="paymentSlp">支払データオブジェクト</param>
        /// <param name="paymentDtlList">支払明細データオブジェクトリスト</param>
		/// <param name="salesTempList">売上データ(仕入同時)オブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <returns>STATUS</returns>
        //private int ReadDBDataProc(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList)
        private int ReadDBDataProc( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out StockSlip baseStockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList )
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			stockSlip = null;
            baseStockSlip = null; //2009.03.25
			stockDetailList = null;
			addUpSrcDetailList = null;
			paymentSlp = null;
            paymentDtlList = null;
			salesTempList = null;
			stockWorkList = null;

			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			IOWriteMASIRReadWork readPara = new IOWriteMASIRReadWork();
			readPara.EnterpriseCode = enterpriseCode;
			readPara.SupplierFormal = supplierFormal;
			readPara.SupplierSlipNo = supplierSlipNo;

			CustomSerializeArrayList paraList = new CustomSerializeArrayList();
			paraList.Add(iOWriteCtrlOptWork);
			paraList.Add(readPara);

			object paraObj = (object)paraList;
			object retObj;
			object retObj2;

            if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
			status = this._iIOWriteControlDB.Read(ref paraObj, out retObj, out retObj2);

			CustomSerializeArrayList retList = (CustomSerializeArrayList)retObj;
			CustomSerializeArrayList retList2 = (CustomSerializeArrayList)retObj2;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				StockSlipWork stockSlipWork;
				StockDetailWork[] stockDetailWorkArray;
                AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray;
				StockWork[] stockWorkArray;
				List<SalesSlipWork> salesSlipWorkListTemp;
				List<SalesDetailWork> salesDetailWorkListTemp;
				PaymentDataWork paymentDataWork;
				SalesTempWork[] salesTempWorkArray;

				// CustomSerializeArrayList分割処理
                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForReadingResult(
					retList,
					retList2,
					out stockSlipWork,
					out stockDetailWorkArray,
					out addUpOrgStockDetailWorkArray,
                    out paymentDataWork,
					out stockWorkArray,
					out salesSlipWorkListTemp,
					out salesDetailWorkListTemp,
					out salesTempWorkArray);

                stockSlip = ConvertStockSlip.UIDataFromParamData(stockSlipWork);
                baseStockSlip = ConvertStockSlip.UIDataFromParamData(stockSlipWork); // 2009.03.25
                stockDetailList = ConvertStockSlip.UIDataFromParamData(stockDetailWorkArray);
                stockDetailList.Sort(new StockDetail.StockDetailComparer());
				addUpSrcDetailList = ConvertStockSlip.UIDataFromParamData(addUpOrgStockDetailWorkArray);
				salesTempList = ConvertStockSlip.UIDataFromParamData(salesTempWorkArray);
				if (( stockWorkArray != null ) && ( stockWorkArray.Length > 0 ))
				{
                    if (stockWorkList == null) stockWorkList = new List<StockWork>();
					stockWorkList.AddRange(stockWorkArray);
				}

				// 売上データワークオブジェクトリスト、売上明細データワークオブジェクトリストから売上データ(仕入同時計上)オブジェクトリストを生成
				List<SalesTemp> salesTempList2 = ConvertStockSlip.UIDataFromParamData(stockDetailList, salesSlipWorkListTemp, salesDetailWorkListTemp);
				if (( salesTempList2 != null ) && ( salesTempList2.Count > 0 ))
				{
					if (salesTempList == null)
					{
						salesTempList = new List<SalesTemp>();
					}
					salesTempList.AddRange(salesTempList2);
				}

                // 支払データをヘッダ、明細に分ける
                if (paymentDataWork != null)
                {
                    PaymentSlpWork paymentSlpWork;
                    PaymentDtlWork[] paymentDtlWorkArray;
                    PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);

                    paymentSlp = ( paymentSlpWork != null ) ? (PaymentSlp)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlpWork, typeof(PaymentSlp)) : new PaymentSlp();

                    paymentDtlList = new List<PaymentDtl>();
                    if (( paymentDtlWorkArray != null ) && ( paymentDtlWorkArray.Length > 0 ))
                    {
                        foreach (PaymentDtlWork paymentDtlWork in paymentDtlWorkArray)
                        {
                            paymentDtlList.Add((PaymentDtl)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentDtlWork, typeof(PaymentDtl)));
                        }
                    }
                }
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 読込用仕入データ調整処理
				this.AdjustStockReadDBData(ref stockSlip, ref stockDetailList);
			}

			return status;
		}

		/// <summary>
		/// ＤＢから取得したデータをデータテーブルにキャッシュします。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="baseStockSlip">処理元仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データオブジェクトリスト</param>
		/// <param name="paymentSlp">支払データオブジェクト</param>
        /// <param name="paymentDtlList">支払明細データリスト</param>
		/// <param name="salesTempList">売上データ(仕入同時計上)オブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        public void Cache( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList, List<SalesTemp> salesTempList, List<StockWork> stockWorkList )
		{
			// データテーブルクリア処理
			this.ClearDetailTables();

			// 仕入データキャッシュ処理
			this.Cache(stockSlip);

			// 仕入データキャッシュ処理（DB読込データ）
			this.CacheDBData(stockSlip);

			// 仕入明細データキャッシュ処理
			this.CacheStockDetail(stockSlip, baseStockSlip, stockDetailList, addUpSrcDetailList, this._stockDetailDataTable);

			// 在庫データキャッシュ処理
			this.CacheStockInfo(stockWorkList);

			// 在庫調整
            this.StockDetailStockInfoAdjust();

			// 仕入明細データキャッシュ処理（DB読込データ）
			this.CacheStockDetailDBData(stockDetailList);

			// 仕入明細行初期行数追加処理
			this.AddStockDetailRowInitialRowCount();

			// 支払データキャッシュ処理
            this.Cache(paymentSlp, paymentDtlList);

			// 売上データ(仕入同時計上)キャッシュ処理
			this.CacheSalesTemp(salesTempList);

            //// 商品再検索
            //List<GoodsUnitData> goodsUnitDataList;
            //this.ReSearchGoods(this._stockDetailDataTable, out goodsUnitDataList);

            //// 商品情報キャッシュ
            //this.CacheGoodsUnitData(goodsUnitDataList);

			// データ変更フラグプロパティをfalseにする
			this.IsDataChanged = false;

		}

		/// <summary>
		/// 在庫情報をキャッシュします。
		/// </summary>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		public void CacheStockInfo( List<StockWork> stockWorkList )
		{
			if (( stockWorkList != null ) && ( stockWorkList.Count > 0 ))
			{
				foreach (StockWork stockWork in stockWorkList)
				{
                    StockInputDataSet.StockInfoRow row = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(stockWork.WarehouseCode.Trim(), stockWork.GoodsNo.Trim(), stockWork.GoodsMakerCd);
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
		}

		/// <summary>
		/// 在庫情報をキャッシュします。
		/// </summary>
		/// <param name="stock">在庫情報オブジェクト</param>
        private void CacheStockInfo( Stock stock )
		{
			if (stock != null)
			{
				StockInputDataSet.StockInfoRow row = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(stock.WarehouseCode.Trim(), stock.GoodsNo.Trim(), stock.GoodsMakerCd);
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

        /// <summary>
        /// 在庫情報に調整数をセットします。
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="adjustCount">調整数</param>
        private void StockInfoAdjustCountSetting( string warehouseCode, string goodsNo, int goodsMakerCd, double adjustCount )
        {
            StockInputDataSet.StockInfoRow row = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(warehouseCode, goodsNo, goodsMakerCd);

            if (row != null)
            {
                row.AdjustCnt += adjustCount;
            }
        }


		/// <summary>
		/// 仕入明細データオブジェクトリストの現在庫数を調整します。
		/// </summary>
		public void StockDetailStockInfoAdjust( )
		{
            if (this._stockInfoDataTable.Rows.Count > 0)
			{
                try
                {
                    this._stockDetailDataTable.AcceptChanges();
                    this._stockDetailDataTable.BeginLoadData();

                    List<string> stockKeyList = new List<string>();

                    foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable)
                    {
                        if (!string.IsNullOrEmpty(stockDetailRow.WarehouseCode.Trim()))
                        {
                            string stockKey = string.Format("{0,-6}{1,-40}{2,6}", stockDetailRow.WarehouseCode.Trim(), stockDetailRow.GoodsNo, stockDetailRow.GoodsMakerCd);
                            if (!stockKeyList.Contains(stockKey))
                            {
                                this.StockDetailStockInfoAdjust(stockDetailRow.WarehouseCode, stockDetailRow.GoodsNo, stockDetailRow.GoodsMakerCd);
                                stockKeyList.Add(stockKey);
                            }
                        }
                    }
                }
                finally
                {
                    this._stockDetailDataTable.EndLoadData();
                }
			}
		}

		/// <summary>
		/// 仕入明細データオブジェクトリストの現在庫数を調整します。
		/// </summary>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="goodsNo">商品コード</param>
		/// <param name="goodsMakerCode">メーカーコード</param>
		public void StockDetailStockInfoAdjust( string warehouseCode, string goodsNo, int goodsMakerCode )
		{
			if (( string.IsNullOrEmpty(warehouseCode) ) || ( string.IsNullOrEmpty(goodsNo) ) || ( goodsMakerCode == 0 )) return;

			StockInputDataSet.StockInfoRow stockInfoTableRow = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(warehouseCode, goodsNo, goodsMakerCode);

			if (stockInfoTableRow != null)
			{
				//this._stockDetailDataTable.BeginLoadData();

				string defaultRowFilter = this._stockDetailDataView.RowFilter;
				string defaultSort = this._stockDetailDataView.Sort;

				try
				{
					StockInputDataSet.StockDetailRow stockDetailRow;
					// 在庫マスタ上の現在庫を取得する
                    double shipmentPosCnt = (double)( (decimal)stockInfoTableRow.ShipmentPosCnt + (decimal)stockInfoTableRow.AdjustCnt );

					string selectString = string.Format("{0}='{1}' AND {2}='{3}' AND {4}={5}",
												this._stockDetailDataTable.WarehouseCodeColumn.ColumnName,
												stockInfoTableRow.WarehouseCode.Trim(),
												this._stockDetailDataTable.GoodsNoColumn.ColumnName,
												stockInfoTableRow.GoodsNo,
												this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName,
												stockInfoTableRow.GoodsMakerCd);

					this._stockDetailDataView.Sort = string.Format("{0}", this._stockDetailDataTable.StockRowNoColumn);

					// 一旦、修正分の数量を差し引いた現在庫数を計算する(全明細が削除された場合の現在庫数を算出)
					this._stockDetailDataView.RowFilter = string.Format("{0} AND {1} <> 0", selectString, this._stockDetailDataTable.StockSlipDtlNumColumn.ColumnName);

					if (this._stockDetailDataView.Count > 0)
					{
						foreach (DataRowView drv in this._stockDetailDataView)
						{
                            stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo((int)drv[this._stockDetailDataTable.SupplierSlipNoColumn.ColumnName], (int)drv[this._stockDetailDataTable.StockRowNoColumn.ColumnName]);
							bool shipmentCntChange = this.SupplierStockCountChangeCheck(stockDetailRow);

							// 現在庫数が変わる場合は元の数量分差し引く
							if (shipmentCntChange == true)
							{
                                if (stockDetailRow.StockCountDefault != 0)
                                {
                                    shipmentPosCnt = (double)( (decimal)shipmentPosCnt - (decimal)stockDetailRow.StockCountDefault );
                                }
                                else
                                {
                                    shipmentPosCnt = (double)( (decimal)shipmentPosCnt - (decimal)stockDetailRow.StockCount );
                                }
							}
						}
					}

					// 先頭明細から現在庫数を再計算する
					this._stockDetailDataView.RowFilter = selectString;

					foreach (DataRowView drv in this._stockDetailDataView)
					{
                        stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo((int)drv[this._stockDetailDataTable.SupplierSlipNoColumn.ColumnName], (int)drv[this._stockDetailDataTable.StockRowNoColumn.ColumnName]);
						bool shipmentCntChange = this.SupplierStockCountChangeCheck(stockDetailRow);

						stockDetailRow.ShipmentPosCnt = shipmentPosCnt;
                        // ---UPD 2011/07/18------------>>>>>
						// 現在庫数が変わる場合は加算
                        //if (shipmentCntChange == true)
                        //{
                        //    shipmentPosCnt = (double)( (decimal)shipmentPosCnt + (decimal)stockDetailRow.StockCount );
                        //}

                        if (this._stockSlipInputInitDataAcs.GetAllDefSet().DtlCalcStckCntDsp == 0)
                        {
                            // 現在庫数が変わる場合は加算
                            if (shipmentCntChange == true)
                            {
                                shipmentPosCnt = (double)((decimal)shipmentPosCnt + (decimal)stockDetailRow.StockCount);
                            }
                        }
                        else
                        {
                            if (this.HasStockInfo == false)
                            {
                                // 現在庫数が変わる場合は加算
                                if (shipmentCntChange == true)
                                {
                                    shipmentPosCnt = (double)((decimal)shipmentPosCnt + (decimal)stockDetailRow.StockCount);
                                }
                            }
                            else
                            {
                                if (this.StockRowNo == stockDetailRow.StockRowNo)
                                {
                                    //なし。
                                }
                                else
                                {
                                    // 現在庫数が変わる場合は加算
                                    if (shipmentCntChange == true)
                                    {
                                        shipmentPosCnt = (double)((decimal)shipmentPosCnt + (decimal)stockDetailRow.StockCount);
                                    }
                                }
                            }
                        }
                        // ---UPD 2011/07/18------------<<<<<
                        // ---UPD 2011/07/18------------>>>>>
                        //stockDetailRow.ShipmentPosCntDisplay = shipmentPosCnt;

                        if (this.HasStockInfo == true && this.IsShipmentChange == true)
                        {
                            //なし。
                        }
                        else
                        {
                            stockDetailRow.ShipmentPosCntDisplay = shipmentPosCnt;
                        }
                        // ---UPD 2011/07/18------------<<<<<
                        stockDetailRow.WarehouseShelfNo = stockInfoTableRow.WarehouseShelfNo;
					}

                    // ---ADD 2011/07/18------------->>>>>
                    if (this.HasStockInfo == true)
                    {
                        this.HasStockInfo = false;
                    }
                    if (this.IsShipmentChange == true)
                    {
                        this.IsShipmentChange = false;
                    }
                    // ---ADD 2011/07/18-------------<<<<<

				}
				finally
				{
					this._stockDetailDataView.RowFilter = defaultRowFilter;
					this._stockDetailDataView.Sort = defaultSort;
					//this._stockDetailDataTable.EndLoadData();
				}
			}
		}

        /// <summary>
        /// 明細の金額、単価のデフォルト値を退避します。
        /// </summary>
        public void CacheStockPrice()
        {
            foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            {
                // 単価、金額の初期値
                row.StockUnitPriceDefault = row.StockUnitPriceFl;
                row.StockUnitTaxPriceDefault = row.StockUnitTaxPriceFl;
                row.StockPriceTaxExcDefault = row.StockPriceTaxExc;
                row.StockPriceTaxIncDefault = row.StockPriceTaxInc;
            }
        }


		/// <summary>
		/// ＤＢから取得したデータをデータテーブルにキャッシュします。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="baseStockSlip">処理元仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データオブジェクトリスト</param>
        /// <param name="stockWorkList">在庫リスト</param>
        public void Cache( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, List<StockWork> stockWorkList )
		{
            this.Cache(stockSlip, baseStockSlip, stockDetailList, addUpSrcDetailList, null, null, null, stockWorkList);
		}

		/// <summary>
		/// ＤＢから取得したデータをデータテーブルにキャッシュします。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="baseStockSlip">処理元仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データオブジェクトリスト</param>
		/// <param name="paymentSlp">支払データオブジェクト</param>
        /// <param name="paymentDtlList">支払明細データオブジェクトリスト</param>
        public void Cache( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList )
        {
            this.Cache(stockSlip, baseStockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, null, null);
        }

		/// <summary>
		/// ＤＢから取得したデータをデータテーブルにキャッシュします。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="baseStockSlip">処理元仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
        /// <param name="stockWorkList">在庫ワークリスト</param>
        public void Cache( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockWork> stockWorkList )
		{
            this.Cache(stockSlip, baseStockSlip, stockDetailList, null, null, null, null, stockWorkList);
		}

		/// <summary>
		/// 相手先伝票番号を使用して仕入データを検索します。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="partySalesSlipNum">相手先伝票番号</param>
		/// <param name="partySalesSlipNumSearchMode">相手先伝番の検索モード(0:完全一致,1:前方一致)</param>
		/// <param name="stockSlipList">仕入データリスト</param>
		/// <returns>STATUS</returns>
		public int ReadStockSlip( string enterpriseCode, int supplierFormal, string partySalesSlipNum, int partySalesSlipNumSearchMode, out List<StockSlip> stockSlipList )
		{
            return this.ReadStockSlip(enterpriseCode, supplierFormal, string.Empty, partySalesSlipNum, DateTime.MinValue, 0, partySalesSlipNumSearchMode, out stockSlipList);
		}

		/// <summary>
		/// 仕入データを検索します。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="partySalesSlipNum">相手先伝票番号</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="targetDate">対象日</param>
        /// <param name="supplierCd">仕入先コード</param>
		/// <param name="partySalesSlipNumSearchMode">相手先伝番の検索モード(0:完全一致,1:前方一致)</param>
		/// <param name="stockSlipList">仕入データリスト</param>
		/// <returns>STATUS</returns>
		private int ReadStockSlip( string enterpriseCode, int supplierFormal, string sectionCode, string partySalesSlipNum, DateTime targetDate,int supplierCd, int partySalesSlipNumSearchMode, out List<StockSlip> stockSlipList )
		{
			StockSlipWork paraStockSlipWork = new StockSlipWork();
			paraStockSlipWork.EnterpriseCode = enterpriseCode;
			paraStockSlipWork.SupplierFormal = supplierFormal;
			paraStockSlipWork.StockSectionCd= sectionCode;
            paraStockSlipWork.SupplierCd = supplierCd;
			paraStockSlipWork.PartySaleSlipNum = partySalesSlipNum;

			if (supplierFormal == 0)
			{
				paraStockSlipWork.StockDate = targetDate;
			}
			else
			{
				paraStockSlipWork.ArrivalGoodsDay = targetDate;
			}
			return this.ReadStockSlipProc(paraStockSlipWork, partySalesSlipNumSearchMode, out stockSlipList);
		}

		/// <summary>
		/// 仕入データを検索します。
		/// </summary>
		/// <param name="stockSlipWork">検索パラメータ(仕入ワークオブジェクト)</param>
        /// <param name="readMode">相手先伝番の検索モード</param>
		/// <param name="stockSlipList">仕入データリスト</param>
		/// <returns>STATUS</returns>
		private int ReadStockSlipProc( StockSlipWork stockSlipWork, int readMode, out List<StockSlip> stockSlipList )
		{
			stockSlipList = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            object retObj = (object)retList;
			object paraObj;

			paraObj = (object)stockSlipWork;

            if (this._iStockSlipDB == null) this._iStockSlipDB = (IStockSlipDB)MediationStockSlipDB.GetStockSlipDB();
            int status = this._iStockSlipDB.SearchPartySaleSlipNum(ref retObj, paraObj, readMode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				CustomSerializeArrayList retCustomSerializeArrayList = (CustomSerializeArrayList)retObj;

				stockSlipList = new List<StockSlip>();
				for (int i = 0; i < retCustomSerializeArrayList.Count; i++)
				{
					if (retCustomSerializeArrayList[i] is StockSlipWork)
					{
						stockSlipList.Add(ConvertStockSlip.UIDataFromParamData((StockSlipWork)retCustomSerializeArrayList[i]));
					}
				}
			}
			return status;
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
        /// <remarks>
        /// <br>Update Note : 2012/06/15 tianjw</br>
        /// <br>管理番号    : 10801804-00 2012/07/25配信分</br>
        /// <br>              Redmine#30517 品名未入力行の不具合の対応</br>
        /// <br>Update Note : 2015/03/25 黄興貴</br>
        /// <br>管理番号    : 11175104-00</br>
        /// <br>              Redmine#45073 宮田自動車商会　仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応</br>
        /// </remarks>
		public bool CheckSaveData( out string mainMessage, out List<string> itemNameList, out List<string> itemList,out List<int> errorRowNoList )
		{
            mainMessage = string.Empty;
			itemNameList = new List<string>();
			itemList = new List<string>();
            errorRowNoList = new List<int>();
            bool insufficiency = false;
			bool overFlow = false;
			bool stockCountError = false;
			bool noConfirmed = false;
			bool shipmentCountError = false;
			bool customerUnmatch = false;
			bool salesDateError = false;
			bool shipmentDayError = false;
            bool dishonestValue = false;

			DateTime targetDate;
			if (this.StockSlip.SupplierFormal == 0)
			{
				targetDate = this.StockSlip.StockDate;
			}
			else
			{
				targetDate = this.StockSlip.ArrivalGoodsDay;
			}

            if (string.IsNullOrEmpty(this.StockSlip.StockSectionCd.Trim()))
            {
                itemNameList.Add("拠点");
                itemList.Add("StockSectionCd");
                insufficiency = true;
            }
			if (string.IsNullOrEmpty(this.StockSlip.StockAgentCode.Trim()))
			{
				itemNameList.Add("担当者");
				itemList.Add("StockAgentCode");
				insufficiency = true;
			}

            //if (string.IsNullOrEmpty(this.StockSlip.PartySaleSlipNum))// DEL 黄興貴 2015/03/25 Redmine#45073 宮田自動車商会 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応
            if (string.IsNullOrEmpty(this.StockSlip.PartySaleSlipNum.Trim()))// ADD 黄興貴 2015/03/25 Redmine#45073 宮田自動車商会 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応
			{
				itemNameList.Add("伝票番号");
                itemList.Add("PartySaleSlipNum");
				insufficiency = true;
			}

			if (this.StockSlip.SupplierCd == 0)
			{
				itemNameList.Add("仕入先");
				itemList.Add("SupplierCd");
				insufficiency = true;
			}


			if (this.StockSlip.ArrivalGoodsDay == DateTime.MinValue)
			{
				itemNameList.Add("入荷日");
				itemList.Add("ArrivalGoodsDay");
				insufficiency = true;
			}

			if (this.StockSlip.SupplierFormal == 0)
			{
				if ( this.StockSlip.StockDate == DateTime.MinValue )
				{
					itemNameList.Add("仕入日");
					itemList.Add("StockAddUpDate");
					insufficiency = true;
				}
				else if (this.StockSlip.StockDate < this.StockSlip.ArrivalGoodsDay)
				{
					itemNameList.Add("仕入日が入荷日より前になっています。");
					itemList.Add("StockDate");
                    dishonestValue = true;
				}
			}

			if (!this.ExistStockDetailData())
			{
                // 2009.06.17 >>>
                if (this.StockSlip.StockGoodsCd == 6)
                {
                    itemNameList.Add("仕入金額");
                    itemList.Add("StockTotalPrice");
                }
                else
                {
                    itemNameList.Add("仕入明細");
                    itemList.Add("StockDetail");
                }
                // 2009.06.17 <<<
                insufficiency = true;
			}

			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
			{
				// 入力済み行に対してのチェック
                //if (this.ExistStockDetailInput(row)) // DEL 2012/06/19 tianjw Redmine#30517
                if (this.ExistStockDetailInput(row) || row.StockSlipCdDtl == 2) // ADD 2012/06/19 tianjw Redmine#30517
				{
                    if (( row.StockGoodsCd == 0 ) || ( row.StockGoodsCd == 1 ))
                    {
                        //if (string.IsNullOrEmpty(row.GoodsName)) // DEL 2012/07/11 tianjw Redmine#30517
                        if (string.IsNullOrEmpty(row.GoodsName.Trim())) // ADD 2012/07/11 tianjw Redmine#30517
                        {
                            itemNameList.Add("品名");
                            itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.GoodsNameColumn.ColumnName));
                            if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                            insufficiency = true;
                        }

                        // 仕入伝票
                        if (( row.StockSlipCdDtl != 2 ) || ( ( row.StockSlipCdDtl == 2 )&&(row.StockCountDisplay != 0) ))
                        {
                            if (row.StockCountDisplay == 0)
                            {

                                // ----------ADD 2013/01/07----------->>>>>
                                // 更新時 単価 ＝ 0 AND 金額 ≠ 0 の場合、エラーにしない
                                if (row.StockSlipDtlNum != 0 &&
                                    row.StockUnitPriceDisplay == 0 && 
                                    row.StockPriceDisplay != 0 )
                                {
                                    // チェックOK
                                }
                                else
                                {
                                // ----------ADD 2013/01/07-----------<<<<<

                                    itemNameList.Add("数量");
                                    itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockCountDisplayColumn.ColumnName));
                                    //itemList.Add("StockDetail,StockCountDisplay");
                                    if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                    insufficiency = true;

                                } // ADD 2013/01/07
                            }
                            // ----- ADD 2010/05/04 ------------------>>>>>
                            else if (MyOpeCtrl.Disabled((int)OperationCode.QuantityMinus) && row.StockCountDisplay < 0)
                            {
                                itemNameList.Add(string.Format("{0}行目の数量がマイナスです。", row.StockRowNo));
                                itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockCountDisplayColumn.ColumnName));
                                if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                dishonestValue = true;
                            }
                            // ----- ADD 2010/05/04 ------------------<<<<<
                            if (Math.Abs(row.StockCount) > ctMAXVALUE_StockCountDetail)
                            {
                                itemNameList.Add(string.Format("{0}行の数量を{1:###,##0.00}～{2:###,##0.00}にして下さい。", row.StockRowNo, ctMAXVALUE_StockCountDetail, ctMAXVALUE_StockCountDetail * -1));
                                itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockCountDisplayColumn.ColumnName));
                                //itemList.Add("StockDetail,StockCountDisplay");
                                if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                overFlow = true;
                            }
                            // 単価チェック
                            if (Math.Abs(row.StockUnitPriceDisplay) > ctMAXVALUE_StockUnitPrice)
                            {
                                itemNameList.Add(string.Format("{0}行目の単価が{1:###,##0.00}を超えています。", row.StockRowNo, ctMAXVALUE_StockUnitPrice));
                                itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName));
                                //itemList.Add("StockDetail,StockUnitPriceDisplay");
                                if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                overFlow = true;
                            }

                            // 明細金額チェック
                            if (Math.Abs(row.StockPriceDisplay) > ctMAXVALUE_StockPriceDetail)
                            {
                                itemNameList.Add(string.Format("{0}行目の金額を{1:###,##0.00}～{2:###,##0.00}をにして下さい。", row.StockRowNo, ctMAXVALUE_StockPriceDetail, ctMAXVALUE_StockPriceDetail * -1));
                                itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName));
                                //itemList.Add("StockDetail,StockPriceDisplay");
                                if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                overFlow = true;
                            }
                        }
                    }
				}
			}
            errorRowNoList.Sort();

			if (itemNameList.Count > 0)
			{
				if (insufficiency)
				{
					mainMessage = "未入力の項目";
				}

                if (dishonestValue)
                {
                    if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
                    mainMessage += "不正な値";
                }

				if (overFlow)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
					mainMessage += "有効桁数を超える項目";
				}

				if (stockCountError)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
					mainMessage += "数量が現在庫を上回る商品";
				}
				if (shipmentCountError)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
					mainMessage += "数量が同時売上の数量を下回る行";
				}
				if (noConfirmed)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
					mainMessage += "売上明細を確認していない行";
				}
				if (customerUnmatch)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
					mainMessage += "得意先が異なる行";
				}
				if (shipmentDayError)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
					mainMessage += "売上情報の出荷日の入力に誤りがある行";
				}
				if (salesDateError)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "、";
					mainMessage += "売上情報の売上日の入力に誤りがある行";
				}

				mainMessage += "が存在するため、登録できません。" + "\r\n" + "\r\n";
				return false;
			}
			else if (this.StockSlip.StockTotalPrice > ctMAXVALUE_StockPrice)
			{
				mainMessage = string.Format("仕入金額合計が{0:###,##0}を超えている為、登録できません。", ctMAXVALUE_StockPrice) + "\r\n" + "\r\n";
				itemNameList.Add("仕入金額");
				itemList.Add("StockDetail");
				return false;
			}
			if (this.StockSlip.SupplierFormal == 0)
            {
				string retMessage;
				bool isAddUp = this.CheckAddUp(this.StockSlip, 0, out retMessage);

				if (isAddUp)
				{
					itemList.Add("StockAddUpDate");
					mainMessage = retMessage;
					return false;
				}

                if (( this.StockSlip.SupplierSlipNo != 0 ) && ( this._stockSlipDBData != null ))
                {
                    isAddUp = this.CheckAddUp(this._stockSlipDBData, 2, out retMessage);

                    if (isAddUp)
                    {
                        itemList.Add("StockAddUpDate");
                        mainMessage = retMessage;
                        return false;
                    }
                }
                else if (( this.StockSlip.DebitNoteDiv == 1 ) && ( this._stockSlipDBData != null ))
                {
                    isAddUp = this.CheckAddUp(this._stockSlipDBData, 3, out retMessage);

                    if (isAddUp)
                    {
                        itemList.Add("StockAddUpDate");
                        mainMessage = retMessage;
                        return false;
                    }
                }
			}

            if (this.StockSlip.DebitNoteDiv != 1)
            {
                string retMessage;
                bool isDuplicateRet = this.CheckPartySaleSlipNumDuplicate(this.StockSlip.SupplierFormal, this.StockSlip.StockSectionCd, this.StockSlip.PartySaleSlipNum, targetDate, this.StockSlip.SupplierSlipNo, this.StockSlip.SupplierCd, out retMessage);

                if (!isDuplicateRet)
                {
                    mainMessage = retMessage;
                    //itemNameList.Add("伝票番号");
                    itemList.Add("PartySaleSlipNum");
                    return false;
                }
            }

			return true;
		}

		/// <summary>
		/// 該当する仕入伝票が締め済みかどうかをチェックします。
		/// </summary>
		/// <param name="stockSlip">仕入伝票オブジェクト</param>
		/// <param name="mode">0:登録時モード 1:呼出時モード</param>
		/// <param name="message">メッセージ</param>
		/// <returns>true:締め済み false:未締め</returns>
		public bool CheckAddUp(StockSlip stockSlip, int mode, out string message)
		{
            message = string.Empty;
			if (stockSlip.SupplierFormal == 0)
            {
                DateTime prevTotalDay;

                if (!this.CheckPayment(stockSlip.PayeeCode, stockSlip.StockAddUpADate, out prevTotalDay))
				{
					if (mode == 0)
					{
                        message = "計上日が前回支払締日以前になっている為、登録できません。" + Environment.NewLine + Environment.NewLine +
                            string.Format("　前回支払締日 ： {0}", prevTotalDay.ToString("yyyy年MM月dd日")) + Environment.NewLine + Environment.NewLine +
                            "※計上日は、支払先確認より変更が可能です。"; 
					}
                    else if (mode == 2)
                    {
                        message = "修正前の伝票が締次集計処理済みの為、登録できません。" + Environment.NewLine + Environment.NewLine +
                            string.Format("　修正前計上日 ： {0}", stockSlip.StockAddUpADate.ToString("yyyy年MM月dd日")) + Environment.NewLine +
                            string.Format("　前回支払締日 ： {0}", prevTotalDay.ToString("yyyy年MM月dd日"));
                    }
                    else if (mode == 3)
                    {
                        message = "元伝票が締次集計処理済みの為、登録できません。" + Environment.NewLine + Environment.NewLine +
                            string.Format("　元伝票計上日 ： {0}", stockSlip.StockAddUpADate.ToString("yyyy年MM月dd日")) + Environment.NewLine +
                            string.Format("　前回支払締日 ： {0}", prevTotalDay.ToString("yyyy年MM月dd日"));
                    }
                    else
					{
                        message = "計上日が前回支払締日以前になっている為、編集できません。" + Environment.NewLine + Environment.NewLine +
                            string.Format("　前回支払締日 ： {0}", prevTotalDay.ToString("yyyy年MM月dd日")) + Environment.NewLine + Environment.NewLine +
                            "※計上日は、支払先確認より変更が可能です。";
					}
					return true;
				}

                if (!this.CheckMonthlyAccPayment(stockSlip.PayeeCode, stockSlip.StockAddUpADate, out prevTotalDay))
                {
                    if (mode == 0)
                    {
                        message = "計上日が前回月次更新日以前になっている為、登録できません。" + Environment.NewLine + Environment.NewLine +
                            string.Format("　前回月次更新日 ： {0}", prevTotalDay.ToString("yyyy年MM月dd日")) + Environment.NewLine + Environment.NewLine +
                            "※計上日は、支払先確認より変更が可能です。";
                    }
                    else if (mode == 2)
                    {
                        message = "修正前の伝票が月次更新処理済みの為、登録できません。" + Environment.NewLine + Environment.NewLine +
                            string.Format("　修正前計上日 　： {0}", stockSlip.StockAddUpADate.ToString("yyyy年MM月dd日")) + Environment.NewLine +
                            string.Format("　前回月次更新日 ： {0}", prevTotalDay.ToString("yyyy年MM月dd日"));
                    }
                    else if (mode == 3)
                    {
                        message = "元伝票が月次更新処理済みの為、登録できません。" + Environment.NewLine + Environment.NewLine +
                            string.Format("　元伝票計上日 　： {0}", stockSlip.StockAddUpADate.ToString("yyyy年MM月dd日")) + Environment.NewLine +
                            string.Format("　前回月次更新日 ： {0}", prevTotalDay.ToString("yyyy年MM月dd日"));
                    }
                    else
                    {
                        message = "計上日が前回月次更新日以前になっている為、編集できません。" + Environment.NewLine + Environment.NewLine +
                            string.Format("　前回月次更新日 ： {0}", prevTotalDay.ToString("yyyy年MM月dd日")) + Environment.NewLine + Environment.NewLine +
                            "※計上日は、支払先確認より変更が可能です。";
                    }
                    return true;
                }
            }

			return false;
		}

		/// <summary>
		/// 対象日が仕入締次更新済みかチェックします。
		/// </summary>
        /// <param name="supplierCd">支払先</param>
        /// <param name="stockAddUpDate">計上日</param>
        /// <param name="prevTotalDay">前回締日</param>
        /// <returns>true:OK false:NG</returns>
		public bool CheckPayment(int supplierCd, DateTime stockAddUpDate,out DateTime prevTotalDay)
		{
            if (_totalDayCalculator == null) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            return !this._totalDayCalculator.CheckPayment(supplierCd, stockAddUpDate, out prevTotalDay);
		}

		/// <summary>
		/// 対象日が仕入月次更新済みかチェックします。
		/// </summary>
        /// <param name="supplierCd">支払先</param>
        /// <param name="stockAddUpDate">計上日</param>
        /// <param name="prevTotalDay">前回月次更新日</param>
		/// <returns>true:OK false:NG</returns>
        public bool CheckMonthlyAccPayment(int supplierCd, DateTime stockAddUpDate, out DateTime prevTotalDay)
		{
            if (_totalDayCalculator == null) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            return !this._totalDayCalculator.CheckMonthlyAccPay(supplierCd, stockAddUpDate, out prevTotalDay);
		}

        /// <summary>
        /// 仕入伝票番号の重複チェック
        /// </summary>
        /// <returns>False:重複</returns>
        public bool CheckPartySaleSlipNumDuplicate( int supplierFormal, string sectionCode, string partySalesSlipNum, DateTime targetDate,int supplierSlipNo, int supplierCd, out string message )
        {
            message = string.Empty;
            bool ret = true;
            List<StockSlip> stockSlipList;

            int status = this.ReadStockSlip(this._enterpriseCode, supplierFormal, sectionCode, partySalesSlipNum, targetDate, supplierCd, 0, out stockSlipList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockSlipList.Count > 0)
                {
                    if (supplierSlipNo == 0)
                    {
                        message = "この伝票番号は既に登録されています。" + Environment.NewLine + string.Format("仕入SEQ番号：{0:D9}", stockSlipList[0].SupplierSlipNo);
                        return false;
                    }
                    else
                    {
                        foreach (StockSlip stockslip in stockSlipList)
                        {
                            if (stockslip.SupplierSlipNo != supplierSlipNo)
                            {
                                message = "この伝票番号は既に登録されています。" + Environment.NewLine + string.Format("仕入SEQ番号：{0:D9}", stockslip.SupplierSlipNo);
                                return false;
                            }
                        }
                    }
                }
            }
            return ret;
        }

		/// <summary>
		/// 仕入データの削除チェックを行います。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="mainMessage">メインメッセージ（out）</param>
		/// <param name="itemNameList">項目名称リスト（out）</param>
		/// <param name="itemList">項目リスト（out）</param>
		/// <returns>true:削除可 false:削除不可</returns>
		public bool CheckDeleteData( StockSlip stockSlip, out string mainMessage, out List<string> itemNameList, out List<string> itemList )
		{
			itemList = new List<string>();
			itemNameList = new List<string>();
			mainMessage = string.Empty;
			bool canDelete = true;

			if (canDelete)
			{
				// 赤伝区分「0:黒伝」
				if (stockSlip.DebitNoteDiv == 0)
				{
					foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
					{
						if (( row.EditStatus == ctEDITSTATUS_AllReadOnly ) || ( row.EditStatus == ctEDITSTATUS_AllDisable ))
						{
							mainMessage = "編集不可能な明細行が存在する為、削除できません。";
							canDelete = false;
							break;
						}
						else if (row.StockCountMin != 0)
						{
							mainMessage = "返品もしくは計上伝票が入力されている為、削除できません。";
							canDelete = false;
							break;
						}
					}
				}
				// 赤伝区分「1:赤伝」
				else if (stockSlip.DebitNoteDiv == 1)
				{
				}
				// 赤伝区分「2:元黒」
				else if (stockSlip.DebitNoteDiv == 2)
				{
					mainMessage = "該当する仕入データは「元黒伝票」の為、削除できません。";
					canDelete = false;
				}
			}

			return canDelete;
		}

        /// <summary>
        /// 原価チェック
        /// </summary>
        /// <param name="stockRowNo">行番号</param>
        /// <param name="checkType">判定タイプ（0:仕入単価、1:仕入率）</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>判定結果</returns>
        public CheckResult StockUnitPriceCheck( int stockRowNo,int checkType, out string message )
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;

            // 定価<原価チェック用
            string unPrcOvrChkMsg = string.Empty;
            CheckResult unPrcOvrChkRes = CheckResult.Ok;
            // 単価変更チェック用
            string unPrcChgChkMsg = string.Empty;
            CheckResult unPrcChgChkRes = CheckResult.Ok;


            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                double stockUnitPriceDisplay = row.StockUnitPriceDisplay;

                if (checkType == 1)
                {
                    double stockUnitPriceTaxExc;
                    double stockUnitPriceTaxInc;
                    double fracProcUnitStcUnPrc = row.FracProcUnitStcUnPrc;
                    int fracProcStckUnPrc = row.FracProcStckUnPrc;

                    this.CalculateStockUnitPriceByRate(row, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockUnitPriceDisplay, ref fracProcUnitStcUnPrc, ref fracProcStckUnPrc);
                }

                // 定価＜原価チェック
                unPrcOvrChkRes = this.UnitPriceOverCheck(row.ListPriceDisplay, stockUnitPriceDisplay, out unPrcOvrChkMsg);

                // 単価変更チェック
                unPrcChgChkRes = this.UnitPriceChangeCheck(stockUnitPriceDisplay, row.BfStockUnitPriceFl, row.RateDivStckUnPrc, row.TaxationCode, out unPrcChgChkMsg);

                // 単価変更エラー
                if (unPrcChgChkRes == CheckResult.Error)
                {
                    message = unPrcChgChkMsg;
                    return unPrcChgChkRes;
                }
                // 単価＞定価エラー
                else if (unPrcOvrChkRes == CheckResult.Error)
                {
                    message = unPrcOvrChkMsg;
                    return unPrcOvrChkRes;
                }
                // 単価＞定価警告
                else if (unPrcOvrChkRes == CheckResult.Warning)
                {
                    message = unPrcOvrChkMsg;
                    return unPrcOvrChkRes;
                }
                // 単価変更警告
                else if (unPrcChgChkRes == CheckResult.Warning)
                {
                    message = unPrcChgChkMsg;
                    return unPrcChgChkRes;
                }
                else
                {
                    // 仕入金額チェック
                    string stockPrcOvrChkMsg;
                    CheckResult stockPrcOvrChkRes = this.StockPriceOverFlowCheck(row.StockCount, stockUnitPriceDisplay, row.TaxationCode, out stockPrcOvrChkMsg);
                    if (stockPrcOvrChkRes == CheckResult.Error)
                    {
                        message = stockPrcOvrChkMsg;
                        return stockPrcOvrChkRes;
                    }
                }
            }

            return checkReslt;
        }

        /// <summary>
        /// 定価チェック
        /// </summary>
        /// <param name="stockRowNo">行番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>判定結果</returns>
        public CheckResult ListPriceCheck( int stockRowNo, out string message )
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;

            string unPrcOvrChkMsg = string.Empty;
            CheckResult unPrcOvrChkRes = CheckResult.Ok;

            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                // 定価＜原価チェック
                unPrcOvrChkMsg = string.Empty;
                unPrcOvrChkRes = this.UnitPriceOverCheck(row.ListPriceDisplay,row.StockUnitPriceDisplay, out unPrcOvrChkMsg);

                if (( unPrcOvrChkRes == CheckResult.Error ) || ( ( unPrcOvrChkRes == CheckResult.Warning ) ))
                {
                    message = unPrcOvrChkMsg;
                    return unPrcOvrChkRes;
                }
                else
                {
                    // 仕入金額チェック
                    string stockPrcOvrChkMsg;
                    CheckResult stockPrcOvrChkRes = this.StockPriceOverFlowCheck(row.StockCount, row.StockUnitPriceDisplay, row.TaxationCode, out stockPrcOvrChkMsg);
                    if (stockPrcOvrChkRes == CheckResult.Error)
                    {
                        message = stockPrcOvrChkMsg;
                        return stockPrcOvrChkRes;
                    }
                }
            }

            return checkReslt;
        }

        /// <summary>
        /// 数量チェック
        /// </summary>
        /// <param name="stockRowNo"></param>
        /// <param name="message"></param>
        /// <param name="wbeforeStockCount"></param>                                                        // ADD 2013/01/07
        /// <returns></returns>
        //public CheckResult StockCountCheck( int stockRowNo, out string message )                          // DEL 2013/01/07
        public CheckResult StockCountCheck(int stockRowNo, out string message, double wbeforeStockCount)    // ADD 2013/01/07
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;

            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            if (row != null)
            {
                // 数量チェック用
                string stkCntBscChkMsg = string.Empty;
                CheckResult stkCntBscChkRes = CheckResult.Ok;

                // 数量チェック
                //stkCntBscChkRes = this.StockCountBasicCheck(row, out stkCntBscChkMsg);                    // DEL 2013/01/07 
                stkCntBscChkRes = this.StockCountBasicCheck(row, out stkCntBscChkMsg, wbeforeStockCount);   // ADD 2013/01/07

                if (stkCntBscChkRes != CheckResult.Ok)
                {
                    message = stkCntBscChkMsg;
                    return stkCntBscChkRes;
                }

                // 仕入金額チェック
                string stockPrcOvrChkMsg;
                CheckResult stockPrcOvrChkRes = this.StockPriceOverFlowCheck(row.StockCountDisplay, row.StockUnitPriceDisplay, row.TaxationCode, out stockPrcOvrChkMsg);
                if (stockPrcOvrChkRes == CheckResult.Error)
                {
                    message = stockPrcOvrChkMsg;
                    return stockPrcOvrChkRes;
                }

                // 仕入金額符号チェック
                string stockPriceSignChkMsg;
                CheckResult stockPriceSignChkRes = this.StockPriceSignChk(row, this._stockDetailDataTable.StockCountDisplayColumn.ColumnName, out stockPriceSignChkMsg);
                if (stockPriceSignChkRes != CheckResult.Ok)
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        message += Environment.NewLine;
                    }
                    message += stockPriceSignChkMsg;

                    return stockPriceSignChkRes;
                }
            }
            return checkReslt;
        }


        /// <summary>
        /// 定価・単価チェック（仕入在庫全体設定マスタの定価チェック区分を参照)
        /// </summary>
        /// <param name="listPriceDisplay">表示定価</param>
        /// <param name="stockUnitPriceDisplay">表示単価</param>
        /// <param name="message">メッセージ</param>
        /// <returns>判定結果</returns>
        private CheckResult UnitPriceOverCheck( double listPriceDisplay, double stockUnitPriceDisplay, out string message )
        {
            message = string.Empty;

            if (listPriceDisplay == 0) return CheckResult.Ok;

            CheckResult checkReturn = CheckResult.Ok;

            // 定価チェック区分による定価・単価チェック
            switch (this._stockSlipInputInitDataAcs.GetStockTtlSt().PriceCheckDivCd)
            {
                // 無視
                case 0:
                    {
                        break;
                    }
                // 警告+再入力
                case 1:
                    {
                        checkReturn = CheckResult.Error;
                        break;
                    }
                // 警告
                case 2:
                    {
                        checkReturn = CheckResult.Warning;
                        break;
                    }
            }

            // チェック無しか、定価≧原価であればOK
            if (( checkReturn == CheckResult.Ok ) || ( listPriceDisplay >= stockUnitPriceDisplay ))
            {
                checkReturn = CheckResult.Ok;
            }

            message = ( checkReturn == CheckResult.Ok ) ? string.Empty : string.Format("{0}が{1}を超えています。", this._stockDetailDataTable.StockUnitPriceDisplayColumn.Caption, this._stockDetailDataTable.ListPriceDisplayColumn.Caption);

            return checkReturn;
        }

        /// <summary>
        /// 単価変更チェック（仕入在庫全体設定マスタの単価チェック区分を参照)
        /// </summary>
        /// <param name="bfStockUnitPriceFl">変更前単価</param>
        /// <param name="stockUnitPriceDisplay">表示単価</param>
        /// <param name="rateDivStckUnPrc">掛率設定区分（仕入単価）</param>
        /// <param name="taxationCode">課税方式</param>
        /// <param name="message">メッセージ</param>
        /// <returns>判定結果</returns>
        private CheckResult UnitPriceChangeCheck( double stockUnitPriceDisplay, double bfStockUnitPriceFl, string rateDivStckUnPrc, int taxationCode, out string message )
        {
            message = string.Empty;

            // 変更前単価がゼロ、掛率設定区分が空白でなければチェックしない
            if (( bfStockUnitPriceFl == 0 ) || ( !string.IsNullOrEmpty(rateDivStckUnPrc.Trim()) )) return CheckResult.Ok;

            CheckResult checkReturn = CheckResult.Ok;

            // 定価チェック区分による定価・単価チェック
            switch (this._stockSlipInputInitDataAcs.GetStockTtlSt().StockUnitChgDivCd)
            {
                // 無視
                case 0:
                    {
                        break;
                    }
                // 警告+再入力
                case 1:
                    {
                        checkReturn = CheckResult.Error;
                        break;
                    }
                // 警告
                case 2:
                    {
                        checkReturn = CheckResult.Warning;
                        break;
                    }
            }

            if (checkReturn != CheckResult.Ok)
            {
                // 表示単価から、税抜き単価を算出する
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード
                double unitPriceTaxExc;
                double unitPriceTaxInc;
                double unitPriceDisplay;

                this.CalculatePrice(PriceInputType.PriceDisplay, stockUnitPriceDisplay, taxationCode, this._stockSlip.SuppTtlAmntDspWayCd, this._stockSlip.SuppCTaxLayCd, this._stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, out unitPriceTaxExc, out unitPriceTaxInc, out unitPriceDisplay);

                // 「変更前単価」と「計算した表示単価から計算した税抜き単価」を比較する
                if (unitPriceTaxExc == bfStockUnitPriceFl)
                {
                    checkReturn = CheckResult.Ok;
                }
                else
                {
                }
            }

            switch (checkReturn)
            {
                case CheckResult.Ok:
                    break;
                case CheckResult.Error:
                    message = string.Format("{0}は変更できません。", this._stockDetailDataTable.StockUnitPriceDisplayColumn.Caption);
                    break;
                case CheckResult.Warning:
                    message = string.Format("{0}が変更されています。", this._stockDetailDataTable.StockUnitPriceDisplayColumn.Caption);
                    break;
                case CheckResult.Confirm:
                    break;
            }

            return checkReturn;
        }

        /// <summary>
        /// 仕入金額桁溢れチェック
        /// </summary>
        /// <param name="stockUnitPriceDisplay">仕入単価</param>
        /// <param name="stockCount">仕入数</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="message">メッセージ</param>
        /// <returns>判定結果</returns>
        private CheckResult StockPriceOverFlowCheck(double stockUnitPriceDisplay, double stockCount, int taxationCode, out string message)
        {
            message = string.Empty;
            // 仕入金額を算定
            long stockPriceTaxInc;
            long stockPriceTaxExc;
            long stockPriceConsTax;

            double stockUnitPrice = stockUnitPriceDisplay;

            // 転嫁方式「非課税」時は税抜きで計算
            if (this._stockSlip.SuppCTaxLayCd == 9)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // 総額表示時は内税で計算する
            else if (( taxationCode != (int)CalculateTax.TaxationCode.TaxNone ) && ( this._stockSlip.SuppTtlAmntDspWayCd == 1 ))
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;

            this.CalculateStockPrice(stockCount, stockUnitPrice, taxationCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);

            long stockPriceDisplay = ( ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) || ( this._stockSlip.SuppTtlAmntDspWayCd == 1 ) ) ? stockPriceTaxInc : stockPriceTaxExc;

            if (Math.Abs(stockPriceDisplay) > Math.Abs(ctMAXVALUE_StockPriceDetail))
            {
                message = "仕入金額が最大桁数を超える為、入力できません。" + Environment.NewLine + string.Format("仕入金額が「{0} ～ {1}」の範囲内になるように入力して下さい。", Math.Abs(ctMAXVALUE_StockPriceDetail) * -1, Math.Abs(ctMAXVALUE_StockPriceDetail));
                return CheckResult.Error;
            }
            return CheckResult.Ok;
        }

        /// <summary>
        /// 数量の基本チェック
        /// </summary>
        /// <param name="row"></param>
        /// <param name="message"></param>
        /// <param name="wbeforeStockCount"></param>                                                                                   // ADD 2013/01/07
        /// <returns></returns>
        //private CheckResult StockCountBasicCheck(StockInputDataSet.StockDetailRow row,out string message)                            // DEL 2013/01/07
        private CheckResult StockCountBasicCheck(StockInputDataSet.StockDetailRow row, out string message, double wbeforeStockCount)   // ADD 2013/01/07
        {
            message = string.Empty;

            double beforeStockCount = row.StockCountDefault;
            double stockCountMax = row.StockCountMax;
            double stockCountMin = row.StockCountMin;
            double stockCount = 0;
            int sign = 1;
            double stockCountRealValue = 0; // データの本当の値

            stockCount = row.StockCountDisplay;
            stockCountRealValue = stockCount;
            if (this._stockSlip.SupplierSlipCd == 20)
            {
                stockCountRealValue *= -1;	// 返品時はマイナスで扱う
                sign = -1;
            }

            // ゼロ入力チェック
            if (stockCount == 0)
            {
                // ----------ADD 2013/01/07----------->>>>>
                // 更新時 単価 ＝ 0 AND 金額 ≠ 0 AND 前回数量 ＝ 0 の場合、エラーにしない
                if (row.StockSlipDtlNum != 0 &&
                    row.StockUnitPriceDisplay == 0 &&
                    row.StockPriceDisplay != 0 &&
                    wbeforeStockCount == 0 )
                {
                    // チェックOK
                }
                else
                {

                // ----------ADD 2013/01/07-----------<<<<<

                    message="数量が入力されていません。";
                    return CheckResult.Error;

                } // ADD 2013/01/07
            }
            // ----- ADD 2010/05/04 --------------->>>>>
            else if (MyOpeCtrl.Disabled((int)OperationCode.QuantityMinus)
                && stockCount < 0)
            {
                message = "マイナス値の入力はできません。";
                return CheckResult.Error;
            }
            // ----- ADD 2010/05/04 ---------------<<<<<
            // 桁あふれチェック
            else if (Math.Abs(stockCount) > Math.Abs(ctMAXVALUE_StockCountDetail))
            {
                message = "数量が最大桁数を超える為、入力できません。" + Environment.NewLine + Environment.NewLine + string.Format("「{0:#,##0.00} ～ {1:#,##0.00}」の値を入力して下さい。", Math.Abs(StockSlipInputAcs.ctMAXVALUE_StockCountDetail) * -1, Math.Abs(StockSlipInputAcs.ctMAXVALUE_StockCountDetail));
                return CheckResult.Error;
            }
            // 入荷伝票でのマイナス抑制
            if (this._stockSlip.SupplierFormal == 1)
            {
                if (stockCount < 0)
                {
                    message = "入荷伝票はマイナス値を入力できません。";
                    return CheckResult.Error;
                }
            }
            // 返品伝票のチェック
            if (this._stockSlip.SupplierSlipCd == 20)
            {
                // 計上伝票の場合
                if (stockCountMax != 0)
                {
                    // 計上元がプラス数量の場合はマイナス入力不可
                    if (( stockCountMax > 0 ) && ( stockCountRealValue < 0 ))
                    {
                        message = "返品元の数量がマイナスなので、プラス値は入力できません。";
                        return CheckResult.Error;
                    }
                    // 計上元がマイナス数量の場合はプラス入力不可
                    else if (( stockCountMax < 0 ) && ( stockCountRealValue > 0 ))
                    {
                        message = "返品元の数量がプラスなので、マイナス値は入力できません。";
                        return CheckResult.Error;
                    }
                    //// 元伝有りの返品伝票で、数量がプラスの場合
                    //if (( stockCountMax != 0 ) && ( stockCountRealValue > 0 ))
                    //{
                    //    message = "元伝票がある為、プラス値の入力はできません。";
                    //    return CheckResult.Error;
                    //}

                }
                if (( stockCountMax != 0 ) && ( Math.Abs(stockCountMax) < Math.Abs(stockCountRealValue) ))
                {
                    int sign2 = ( stockCountMax < 0 ) ? -1 : 1;
                    message = "返品可能な数量を超えています。" + Environment.NewLine + Environment.NewLine + string.Format("{0:#,##0.00} ～ {1:#,##0.00} を入力して下さい。", 0.01 * sign * sign2, stockCountMax * sign);
                    return CheckResult.Error;
                }
            }
            else
            {
                // 計上伝票の場合
                if (stockCountMax != 0)
                {
                    // 計上元がプラス数量の場合はマイナス入力不可
                    if (( stockCountMax > 0 ) && ( stockCountRealValue < 0 ))
                    {
                        message = "計上元の数量がプラスなので、マイナス値は入力できません。";
                        return CheckResult.Error;
                    }
                    // 計上元がマイナス数量の場合はプラス入力不可
                    else if (( stockCountMax < 0 ) && ( stockCountRealValue > 0 ))
                    {
                        message = "計上元の数量がマイナスなので、プラス値は入力できません。";
                        return CheckResult.Error;
                    }
                }
                // 計上、返品済み伝票がある場合
                if (stockCountMin != 0)
                {
                    if (( stockCountMin > 0 ) && ( stockCountRealValue < 0 ))
                    {
                        message = "引当済みなので、マイナス値は入力できません。";
                        return CheckResult.Error;
                    }
                    else if (( stockCountMin < 0 ) && ( stockCountRealValue > 0 ))
                    {
                        message = "引当済みなので、プラス値は入力できません。";
                        return CheckResult.Error;
                    }
                    // 引当済み数量以下は入力不可(絶対値で判断)
                    if (( stockCountMin != 0 ) && ( Math.Abs(stockCount) < Math.Abs(stockCountMin) ))
                    {
                        string addMsg = string.Empty;
                        if (stockCountMax == 0)
                        {
                            string flgMsg = ( stockCountMin < 0 ) ? "以下" : "以上";

                            addMsg = string.Format("{0:#,##0.00} {1}を入力して下さい。", stockCountMin, flgMsg);
                        }
                        else
                        {
                            addMsg = string.Format("{0:#,##0.00} ～ {1:#,##0.00} を入力して下さい。", stockCountMin, stockCountMax);
                        }

                        message = "数量が引当済みの数量を下回っています。" + Environment.NewLine + Environment.NewLine + addMsg;
                        return CheckResult.Error;
                    }
                }
                // 計上明細の場合は残数チェック
                if (row.EditStatus == StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpNew)
                {
                    if (Math.Abs(stockCountMax) < Math.Abs(stockCount))
                    {
                        message = "数量が残数量を超えています。" + Environment.NewLine + Environment.NewLine + string.Format("{0:#,##0.00} ～ {1:#,##0.00} を入力して下さい。", ( ( stockCountMin == 0 ) ? 0.01 : stockCountMin ) * sign, stockCountMax * sign);
                        return CheckResult.Error;
                    }
                }
            }

            return CheckResult.Ok;
        }

        /// <summary>
        /// 仕入金額符号チェック
        /// </summary>
        /// <param name="row"></param>
        /// <param name="colKey"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public CheckResult StockPriceSignChk(StockInputDataSet.StockDetailRow row, string colKey, out string message)
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;
            
            // 数量ゼロ以外（行値引きはチェック対象外）
            if (row.StockCountDisplay != 0)
            {
                bool isCheck = false;
                // 数量からチェックする場合
                if (colKey == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
                {
                    // 単価がゼロで、金額がゼロ以外の場合のみチェック対象
                    isCheck = ( ( row.StockUnitTaxPriceFl == 0 ) && ( row.StockUnitPriceFl == 0 ) && ( row.StockPriceTaxExc != 0 ) && ( row.StockPriceTaxInc != 0 ) );

                }
                else
                {
                    isCheck = true;
                }
                if (isCheck)
                {
                    int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

                    double stockCountRealValue = row.StockCountDisplay * sign;
                    long stockPriceRealValue = row.StockPriceDisplay * sign;

                    if (( ( stockCountRealValue > 0 ) && ( stockPriceRealValue < 0 ) ) ||
                        ( ( stockCountRealValue < 0 ) && ( stockPriceRealValue > 0 ) ))
                    {
                        if (colKey == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
                        {
                            checkReslt = CheckResult.Confirm;
                            message = "数量と仕入金額の符号が異なる為、仕入金額を調整します。";
                        }
                        else
                        {
                            checkReslt = CheckResult.Error;
                            message = ( row.StockCount * sign > 0 ) ? "数量がプラスなので、マイナスの金額は入力できません。" : "数量がマイナスなので、プラスの金額は入力できません。";
                        }
                    }
                }
            }
        
            return checkReslt;
        }

        /// <summary>
        /// 仕入金額チェック
        /// </summary>
        /// <param name="stockRowNo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public CheckResult StockPriceCheck(int stockRowNo, out string message)
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;

            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            if (row != null)
            {
                checkReslt = this.StockPriceSignChk(row, this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName, out message);
            }
            return checkReslt;
        }
        //add 2011/12/27 陳建明 Redmine #27374----->>>>>
        /// <summary>
        /// 保存用データの締済のチェックを行います。
        /// </summary>
        /// <remarks>
        /// <param name="mainMessage">メッセージ（out）</param>
        /// <returns>true:保存可 false:保存不可</returns>
        /// <br>Note       : 保存用データの締済のチェック</br>
        /// <br>Programmer : 陳建明</br>
        /// <br>Date       : 2011/12/27</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
        /// <br>             redmine#27374 仕入伝票入力/締済のチェックの対応</br>
        /// </remarks>
        public bool CheckStockAddUpDate(out string mainMessage)
        {
            mainMessage = string.Empty;
            if (this.StockSlip.SupplierFormal == 0)
            {
                string retMessage;
                bool isAddUp = this.CheckAddUp(this.StockSlip, 0, out retMessage);
                if (isAddUp)
                {
                    mainMessage = retMessage;
                    return false;
                }
                if ((this.StockSlip.SupplierSlipNo != 0) && (this._stockSlipDBData != null))
                {
                    isAddUp = this.CheckAddUp(this._stockSlipDBData, 2, out retMessage);
                    if (isAddUp)
                    {
                        mainMessage = retMessage;
                        return false;
                    }
                }
                else if ((this.StockSlip.DebitNoteDiv == 1) && (this._stockSlipDBData != null))
                {
                    isAddUp = this.CheckAddUp(this._stockSlipDBData, 3, out retMessage);
                    if (isAddUp)
                    {
                        mainMessage = retMessage;
                        return false;
                    }
                }
            }
            return true;
        }
        //add 2011/12/27 陳建明 Redmine #27374-----<<<<<
		#endregion


        // ----  ADD 2011/07/25 ------>>>>
        /// <summary>
        /// 掛率優先区分をセットします。
        /// </summary>
        /// <remarks>掛率優先区分をセットします。</remarks>
        public void SetUnitPriceCalculation()
        {
            if (this._stockSlipInputInitDataAcs.GetCompanyInf() != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._stockSlipInputInitDataAcs.GetCompanyInf().RatePriorityDiv;
            }
        }
        // ----  ADD 2011/07/25 ------<<<<

		/// <summary>
		/// 仕入データの初期インスタンスを生成します。
		/// </summary>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="accPayDivCd">買掛区分</param>
		/// <param name="stockGoodsCd">商品区分</param>
		/// <param name="keepDate">true:日付保持する</param>
		public void CreateStockSlipInitialData( int supplierFormal, int accPayDivCd, int stockGoodsCd, bool keepDate )
		{
			string msg;
			if (!this._stockSlipInputInitDataAcs.InitialReadDataCheck(out msg))
			{
				throw new ApplicationException(msg);
			}

			StockTtlSt stockTtlSt = this._stockSlipInputInitDataAcs.GetStockTtlSt();

			AllDefSet allDefSet = this._stockSlipInputInitDataAcs.GetAllDefSet();
			//if (stockTtlSt == null)
			//{
            //    throw new ApplicationException("仕入在庫全体設定マスタの登録を行って下さい。");
			//}
			
			DateTime keepArrivalGoodsDay = this._stockSlip.ArrivalGoodsDay;
            DateTime keepStockDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;

			StockSlip stockSlip = new StockSlip();

			stockSlip.SupplierFormal = supplierFormal;
			stockSlip.StockSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
			SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
			if (secInfoSet != null)
			{
                stockSlip.StockSectionNm = secInfoSet.SectionGuideNm;
			}

			stockSlip.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();								// 仕入担当者コード[ログイン担当]
			stockSlip.StockAgentName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockSlip.StockAgentCode);	// 仕入担当者名称[ログイン担当]
			if (stockSlip.StockAgentName.Length > 16)
			{
				stockSlip.StockAgentName = stockSlip.StockAgentName.Substring(0, 16);
			}

			int subSectionCode;
			this._stockSlipInputInitDataAcs.GetSubSection_FromEmployeeDtl(stockSlip.StockAgentCode, out subSectionCode);
			stockSlip.SubSectionCode = subSectionCode;																	// 部門コード
			stockSlip.SubSectionName=	this._stockSlipInputInitDataAcs.GetName_FromSubSection(subSectionCode);			// 部門名称
			stockSlip.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();								// 仕入担当者コード[ログイン担当]
			stockSlip.StockInputName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockSlip.StockInputCode);	// 仕入担当者名称[ログイン担当]
			if (stockSlip.StockInputName.Length > 16)
			{
				stockSlip.StockInputName = stockSlip.StockInputName.Substring(0, 16);
			}

			stockSlip.SupplierSlipCd = 10;															// 仕入伝票区分[10:仕入]

			stockSlip.InputDay = DateTime.Today;													// 入力日

			stockSlip.ArrivalGoodsDay = ( keepDate ) ? keepArrivalGoodsDay : DateTime.Today;		// 入荷日:日付を保持しない場合は今日を設定

			if (stockSlip.SupplierFormal == 0)
			{
				stockSlip.StockDate = ( keepDate ) ? keepStockDate : DateTime.Today;				// 仕入日:日付を保持しない場合は今日を設定

				stockSlip.StockAddUpADate = stockSlip.StockDate;									// 仕入計上日付[仕入日]
				stockSlip.AccPayDivCd = accPayDivCd;												// 買掛区分
				stockSlip.StockGoodsCd = stockGoodsCd;												// 商品区分
			}
			else if (stockSlip.SupplierFormal == 1)
			{
				stockSlip.StockAddUpADate = DateTime.MinValue;										// 仕入計上日付
				stockSlip.StockDate = stockSlip.StockAddUpADate;									// 仕入日 ← 仕入計上日
				stockSlip.AccPayDivCd = 1;															// 買掛区分を「買掛」とする
				stockSlip.StockGoodsCd = 0;															// 商品区分を「商品」とする
			}

			stockSlip.DelayPaymentDiv = 0;															// 来勘区分 = 当月

			// 画面用伝票区分再設定
			StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

			//StockSlip.SuppTtlAmntDspWayCd = stockTtlSt.TotalAmountDispWayCd;						// 総額表示方法区分
			stockSlip.SuppTtlAmntDspWayCd = allDefSet.TotalAmountDispWayCd;							// 総額表示方法区分
			stockSlip.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;							// 総額表示掛率適用区分

			stockSlip.PriceCostUpdtDiv = ( stockTtlSt.PriceCostUpdtDiv == 1 ) ? 1 : 0;				// 定価原価更新区分

			// 仕入データキャッシュ処理
			this.Cache(stockSlip);

			// 仕入データキャッシュ処理
            this.Cache(new PaymentSlp(), new List<PaymentDtl>());

			// DB読込時仕入データキャッシュ処理
			this.CacheDBData(stockSlip);
		}


		#region 返品処理関連

		/// <summary>
		/// 返品用の仕入データオブジェクトを生成します。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト（ref）</param>
		public void CreateReturnSlipInfo(ref StockSlip stockSlip)
		{
			if (stockSlip == null) return;

			stockSlip.CreateDateTime = DateTime.MinValue;
			stockSlip.UpdateDateTime = DateTime.MinValue;
			stockSlip.SupplierSlipCd = 20;										// 仕入伝票区分 ← 20:返品
			stockSlip.InputMode = ctINPUTMODE_StockSlip_Return;					// 入力モード ← 返品入力モード
			stockSlip.SupplierSlipNo = 0;										// 仕入伝票番号 ← 0
		}

		/// <summary>
		/// 返品用の仕入明細データテーブルを生成します。
		/// </summary>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		public void CreateReturnSlipDetailInfo( List<StockWork> stockWorkList )
		{
			this.CreateReturnSlipDetailInfo(stockWorkList, this._stockDetailDataTable);
		}

		/// <summary>
		/// 返品用の仕入明細データテーブルを生成します。（オーバーロード）
		/// </summary>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		public void CreateReturnSlipDetailInfo(List<StockWork>stockWorkList,StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			for (int i = 0; i < stockDetailDataTable.Count; i++)
			{
				int sign = -1;
				StockInputDataSet.StockDetailRow row = stockDetailDataTable[i];

				row.SupplierFormalSrc = row.SupplierFormal;		// 仕入形式(元) ← 呼出伝票の仕入形式
				row.StockSlipDtlNumSrc = row.StockSlipDtlNum;	// 明細通番(元) ← 呼出伝票の明細通番
				row.SupplierSlipNo = 0;							// 仕入伝票番号 ← 0
				//row.CommonSeqNo = 0;							// 共通通番 ← 0
				row.StockSlipDtlNum = 0;						// 明細通番 ← 0
				row.AcptAnOdrStatusSync = 0;					// 受注ステータス(同時) ← 0
				row.SalesSlipDtlNumSync = 0;					// 売上明細通番(同時) ← 0
				row.StockCountMax = 0;							// 計上可能数 ← 0
				row.StockCountMin = 0;							// 計上済数量 ← 0

                row.StockPriceDisplay = row.StockPriceDisplay * sign;

				if (row.StockCount != 0)
				{
                    row.StockCount = row.OrderRemainCnt * sign;			// 仕入数 ← 元伝票の発注残 * -1
					row.StockCountDefault = Math.Abs(row.StockCount);	// 数量(初期値) ← 元伝票の発注残 
					row.StockCountDisplay = row.StockCount * sign;		// 数量(表示) ← 元伝票の発注残 
					//row.StockCountMax = Math.Abs(row.StockCount);		// 数量(最大) ← 元伝票の発注残
                    row.StockCountMax = row.StockCount;                 // 数量(最大) ← 元伝票の発注残

                    //row.StockPriceDisplay *= sign;
                    row.StockPriceTaxExc *= sign;
                    row.StockPriceTaxInc *= sign;
                    row.StockPriceConsTax *= sign;


					row.OrderCnt = row.StockCount;					// 発注数 ← 0
					row.OrderAdjustCnt = 0;							// 発注調整数 ← 0
					row.OrderRemainCnt = 0;							// 発注残 ← 0

					//row.EditStatus = ctEDITSTATUS_StockCountOnly;
					row.EditStatus = ctEDITSTATUS_ArrivalAddUpNew;
					row.CanTaxDivChange = false;
				}

				// メモ情報調整
				this.MemoInfoAdjust(ref row);
			}
			this.StockDetailStockInfoAdjust();
		}

		/// <summary>
		/// 指定された仕入データに対して返品を行うことが出来るかどうかをチェックします。
		/// </summary>
		/// <param name="stockSlip">仕入データ</param>
		/// <param name="stockDetailList">仕入明細データリスト</param>
		/// <param name="message">メッセージ（out）</param>
		/// <returns>true:返品伝票情報生成可 false:返品伝票情報生成不可</returns>
		public bool CanCreateReturnSlipInfo( StockSlip stockSlip, List<StockDetail> stockDetailList, out string message )
		{
            message = string.Empty;

			// 仕入伝票区分が「20:返品」の場合
			if (stockSlip.SupplierSlipCd == 20)
			{
				message = "該当する仕入データは「返品伝票」の為、選択できません。";
				return false;
			}

			if (stockSlip.DebitNoteDiv == 1)
			{
				message = "該当する仕入データは「赤伝」の為、返品処理を行えません。";
				return false;
			}
			else if (stockSlip.DebitNoteDiv == 2)
			{
				message = "該当する仕入データはすでに「赤伝」が発行されている為、返品処理を行えません。";
				return false;
			}

			if (( stockSlip.StockGoodsCd == 2 ) || ( stockSlip.StockGoodsCd == 4 ))
			{
				message = "該当する仕入データは「消費税調整伝票」の為、返品処理を行えません。";
				return false;
			}
			else if (( stockSlip.StockGoodsCd == 3 ) || ( stockSlip.StockGoodsCd == 5 ))
			{
				message = "該当する仕入データは「残高調整伝票」の為、返品処理を行えません。";
				return false;
			}

			if (stockDetailList != null)
			{
				bool isTrust = false;

				foreach (StockDetail stockDetail in stockDetailList)
				{
					if (stockDetail.OrderRemainCnt != 0)
					{
						isTrust = true;
						break;
					}
				}

				if (!isTrust)
				{
					message = "該当する仕入データは全て「返品」もしくは「計上」が発生している為、選択できません。";
					return false;
				}
			}

			return true;
		}

		#endregion

		#region 赤伝処理関連
		/// <summary>
		/// 赤伝用の仕入データオブジェクトを生成します。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト（ref）</param>
		public void CreateRedSlipInfo(ref StockSlip stockSlip)
		{
			if (stockSlip == null) return;

			stockSlip.CreateDateTime = DateTime.MinValue;
			stockSlip.UpdateDateTime = DateTime.MinValue;
			stockSlip.SupplierSlipCd = 10;										// 仕入伝票区分 ← 10:仕入
			stockSlip.InputMode = ctINPUTMODE_StockSlip_Red;					// 入力モード ← 赤伝入力モード
			stockSlip.DebitNLnkSuppSlipNo = stockSlip.SupplierSlipNo;			// 赤黒連結仕入伝票番号 ← 元黒の仕入伝票番号
			stockSlip.SupplierSlipNo = 0;										// 仕入伝票番号 ← 0
			stockSlip.DebitNoteDiv = 1;											// 赤伝区分 ← 赤伝
		}

		/// <summary>
		/// 赤伝用の支払データオブジェクトを生成します。
		/// </summary>
		/// <param name="paymentSlp">支払データオブジェクト（ref）</param>
		public void CreateRedSlipInfo( ref PaymentSlp paymentSlp )
		{
			if (paymentSlp == null) return;

			paymentSlp.CreateDateTime = DateTime.MinValue;
			paymentSlp.UpdateDateTime = DateTime.MinValue;
			paymentSlp.FileHeaderGuid = Guid.Empty;
			paymentSlp.UpdAssemblyId1 = string.Empty;
			paymentSlp.UpdAssemblyId2 = string.Empty;
			paymentSlp.PaymentSlipNo = 0;
			paymentSlp.SupplierSlipNo = 0;
		}

		/// <summary>
		/// 赤伝用の仕入明細データテーブルを生成します。
		/// </summary>
		public void CreateRedSlipDetailInfo( List<StockWork> stockWorkList )
		{
			this.CreateRedSlipDetailInfo(stockWorkList, this._stockDetailDataTable);
		}

		/// <summary>
		/// 赤伝用の仕入明細データテーブルを生成します。（オーバーロード）
		/// </summary>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		public void CreateRedSlipDetailInfo( List<StockWork> stockWorkList, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			for (int i = 0; i < stockDetailDataTable.Count; i++)
			{
				int sign = -1;
				StockInputDataSet.StockDetailRow row = stockDetailDataTable[i];
				row.SupplierFormalSrc = row.SupplierFormal;		// 仕入形式(元) ← 呼出伝票の仕入形式
				row.StockSlipDtlNumSrc = row.StockSlipDtlNum;	// 明細通番(元) ← 呼出伝票の明細通番
				row.SupplierSlipNo = 0;							// 仕入伝票番号 ← 0
				//salesTempRow.CommonSeqNo = 0;							// 共通通番 ← 0
				row.StockSlipDtlNum = 0;						// 明細通番 ← 0
				row.AcptAnOdrStatusSync = 0;					// 受注ステータス(同時) ← 0
				row.SalesSlipDtlNumSync = 0;					// 売上明細通番(同時) ← 0
				row.StockCountMin = 0;							// 計上済数量 ← 0

                if (row.StockCount != 0)
                {
                    row.StockCount *= sign;		// 仕入数 ← 仕入数×-1
                    row.StockPriceDisplay *= sign;
                    row.StockPriceTaxExc *= sign;
                    row.StockPriceTaxInc *= sign;
                    row.StockPriceConsTax *= sign;
                    row.StockCountMax = row.StockCount;
                    row.StockCountDisplay = row.StockCount;
                    row.StockCountDefault = row.StockCount;
                    row.OrderCnt = row.StockCount;				// 発注数 ← 仕入数
                    row.OrderAdjustCnt = 0;						// 発注調整数 ← 0
                    row.OrderRemainCnt = 0;						// 発注残 ← 0

                    row.EditStatus = ctEDITSTATUS_AllDisable;
                    row.CanTaxDivChange = false;
                }
                else if (row.StockSlipCdDtl == 2 )
                {
                    row.StockPriceDisplay *= sign;
                    row.StockPriceTaxExc *= sign;
                    row.StockPriceTaxInc *= sign;
                    row.StockPriceConsTax *= sign;
                }

				// メモ情報調整
				this.MemoInfoAdjust(ref row);

			}
			this.StockDetailStockInfoAdjust();
		}

		/// <summary>
		/// 指定された仕入データに対して赤伝を行うことが出来るかどうかをチェックします。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データクラスリスト</param>
		/// <param name="message">メッセージ（out）</param>
		/// <returns>true:赤伝票情報生成可 false:赤伝票情報生成不可</returns>
		public bool CanCreateRedSlipInfo( StockSlip stockSlip, List<StockDetail> stockDetailList, out string message )
		{
            message = string.Empty;

			// 仕入伝票区分が「20:返品」の場合
			if (stockSlip.SupplierSlipCd == 20)
			{
				message = "該当する仕入データは「返品伝票」の為、赤伝処理を行えません。";
				return false;
			}

			if (stockSlip.DebitNoteDiv == 1)
			{
				message = "該当する仕入データは「赤伝」の為、選択できません。";
				return false;
			}
			else if (stockSlip.DebitNoteDiv == 2)
			{
				message = "該当する仕入データはすでに「赤伝」が発行されている為、選択できません。";
				return false;
			}

			if (( stockSlip.StockGoodsCd == 2 ) || ( stockSlip.StockGoodsCd == 4 ))
			{
				message = "該当する仕入データは「消費税調整伝票」の為、赤伝処理を行えません。";
				return false;
			}
			else if (( stockSlip.StockGoodsCd == 3 ) || ( stockSlip.StockGoodsCd == 5 ))
			{
				message = "該当する仕入データは「残高調整伝票」の為、赤伝処理を行えません。";
				return false;
			}
			if (stockSlip.SupplierFormal == 1)
			{
				message = "該当する仕入データは「入荷伝票」の為、赤伝処理を行えません。";
				return false;
			}
			else if (stockSlip.SupplierFormal == 2)
			{
				message = "該当する仕入データは「発注データ」の為、赤伝処理を行えません。";
				return false;
			}

			if (stockDetailList != null)
			{
				bool isTrust = false;

				foreach (StockDetail stockDetail in stockDetailList)
				{
					if (stockDetail.StockCount != stockDetail.OrderRemainCnt)
					{
						isTrust = true;
						break;
					}
				}

				if (isTrust)
				{
					message = "該当する仕入データは「返品」もしくは「入荷計上」が発生している為、選択できません。";
					return false;
				}
			}

			return true;
		}
		#endregion

		#region 入荷計上関連

		/// <summary>
		/// 入荷計上用の仕入データオブジェクトを生成します。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		public void CreateArrivalAppropriateInfo(ref StockSlip stockSlip)
		{
			if (stockSlip == null) return;

			stockSlip.CreateDateTime = DateTime.MinValue;
			stockSlip.UpdateDateTime = DateTime.MinValue;
			stockSlip.SupplierSlipNo = 0;								// 仕入伝票番号 ← 0
			stockSlip.SupplierFormal = 0;								// 仕入形式 ← 0:仕入
			stockSlip.StockAddUpADate = DateTime.Today;					// 仕入計上日付[システム日付]
			stockSlip.StockDate = stockSlip.StockAddUpADate;			// 仕入日 ← 仕入計上日
			//stockSlip.TrustAddUpSpCd = 1;								// 入荷計上仕入区分 ← 1:入荷計上仕入
			stockSlip.AccPayDivCd = 1;									// 買掛区分 ← 1:買掛
			stockSlip.InputMode = ctINPUTMODE_StockSlip_ArrivalAddUp;	// 入力モード ← 入荷計上入力モード
		}

		/// <summary>
        /// 入荷計上用の仕入明細データテーブルを生成します。
		/// </summary>
        public void CreateArrivalAppropriateDetailInfo()
        {
            this.CreateArrivalAppropriateDetailInfo(this._stockDetailDataTable);

            this._stockDetailDataTable.AcceptChanges();
            // 在庫数調整
            this.StockDetailStockInfoAdjust();
        }

		/// <summary>
        /// 入荷計上用の仕入明細データテーブルを生成します。（オーバーロード）
		/// </summary>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
        public void CreateArrivalAppropriateDetailInfo( StockInputDataSet.StockDetailDataTable stockDetailDataTable )
        {
            for (int i = 0; i < stockDetailDataTable.Count; i++)
            {
                StockInputDataSet.StockDetailRow row = stockDetailDataTable[i];

                row.SupplierFormalSrc = row.SupplierFormal;		// 仕入形式(元) ← 呼出伝票の仕入形式
                row.StockSlipDtlNumSrc = row.StockSlipDtlNum;	// 明細通番(元) ← 呼出伝票の明細通番
                row.SupplierSlipNo = 0;							// 仕入伝票番号 ← 0
                //row.CommonSeqNo = 0;							// 共通通番 ← 0
                row.StockSlipDtlNum = 0;						// 明細通番 ← 0
                row.AcptAnOdrStatusSync = 0;					// 受注ステータス(同時) ← 0
                row.SalesSlipDtlNumSync = 0;					// 売上明細通番(同時) ← 0

                if (row.OrderRemainCnt != row.StockCount)
                {
                    row.StockPriceDiectInput = false;
                }

                row.StockCount = row.OrderRemainCnt;			// 仕入数 ← 発注残


                row.StockCountDisplay = row.StockCount;			// 数量 ← 発注残
                row.StockCountDefault = row.StockCount;			// 数量初期値 ← 発注残
                row.StockCountMax = row.StockCount;				// 計上可能数 ← 発注残
                row.StockCountMin = 0;							// 計上済み数量 ← 0
                row.OrderCnt = row.StockCount;					// 発注数 ← 仕入数
                row.OrderAdjustCnt = 0;							// 発注調整数 ← 0
                row.OrderRemainCnt = 0;							// 発注残 ← 0

                row.SupplierCd = 0;
                row.SupplierSnm = string.Empty;
                row.AddresseeCode = 0;
                row.AddresseeName = string.Empty;
                row.DirectSendingCd = 0;
                row.OrderNumber = string.Empty;
                row.WayToOrder = 0;
                row.DeliGdsCmpltDueDate = DateTime.MinValue;
                row.ExpectDeliveryDate = DateTime.MinValue;
                row.OrderDataCreateDiv = 0;
                row.OrderDataCreateDate = DateTime.MinValue;
                row.OrderFormIssuedDiv = 0;

                row.EditStatus = ctEDITSTATUS_ArrivalAddUpNew;

                // メモ情報調整
                this.MemoInfoAdjust(ref row);
            }
        }

		/// <summary>
		/// 入荷計上情報クリア処理
		/// </summary>
		public void ClearArrivalAppropriateInfo()
		{
			foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable.Rows)
			{
				// 仕入形式(元)が入荷、仕入明細通番(元)がセットされているデータのみ対象
				if (( stockDetailRow.SupplierFormalSrc == 1 ) && ( stockDetailRow.StockSlipDtlNumSrc != 0 ))
				{
					DataRow[] dataRows = stockDetailRow.GetChildRows(cRelation_Detail_AddUpSrcDetail);

					if (( dataRows != null ) && ( dataRows.Length > 0 ))
					{
						foreach(StockInputDataSet.AddUpSrcDetailRow addUpSrcDetailRow in dataRows)
						{
							this._addUpSrcDetailDataTable.RemoveAddUpSrcDetailRow(addUpSrcDetailRow);
						}
					}
					stockDetailRow.SupplierFormalSrc = 0;
					stockDetailRow.StockSlipDtlNumSrc = 0;
					stockDetailRow.StockCountMin = 0;
					stockDetailRow.StockCountMax = 0;
					stockDetailRow.StockCountDefault = 0;
					stockDetailRow.EditStatus = ctEDITSTATUS_AllOK;
				}
			}
			this.StockDetailStockInfoAdjust();
		}
      
		/// <summary>
		/// 指定された入荷データに対して入荷計上を行うことが出来るかどうかをチェックします。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データリスト</param>
		/// <param name="message">メッセージ（out）</param>
		/// <returns>true:入荷計上情報生成可 false:入荷計上生成不可</returns>
		public bool CanCreateArrivalAddUpInfo( StockSlip stockSlip, List<StockDetail> stockDetailList, out string message )
		{
            message = string.Empty;

			// 仕入伝票区分が「20:返品」の場合
			if (stockSlip.SupplierSlipCd == 20)
			{
				message = "該当するデータは「返品伝票」の為、入荷計上処理を行えません。";
				return false;
			}

			if (stockSlip.DebitNoteDiv == 1)
			{
				message = "該当するデータは「赤伝」の為、入荷計上処理を行えません。";
				return false;
			}
			else if (stockSlip.DebitNoteDiv == 2)
			{
				message = "該当するデータはすでに「赤伝」が発行されている為、入荷計上処理を行えません。";
				return false;
			}

			if (stockDetailList != null)
			{
				bool isTrust = false;

				foreach (StockDetail stockDetail in stockDetailList)
				{
					if (stockDetail.OrderRemainCnt != 0)
					{
						isTrust = true;
						break;
					}
				}

				if (!isTrust)
				{
					message = "該当する仕入データは全て「返品」もしくは「入荷計上」されている為、選択できません。";
					return false;
				}
			}

			return true;
		}
		#endregion

		#region 伝票複写関連
		/// <summary>
        /// 複写伝票の仕入データオブジェクトを生成します。
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト（ref）</param>
        public void CreateSlipCopyInfo( ref StockSlip stockSlip )
        {
            if (stockSlip == null) return;

            stockSlip.CreateDateTime = DateTime.MinValue;
            stockSlip.UpdateDateTime = DateTime.MinValue;
            stockSlip.InputMode = ctINPUTMODE_StockSlip_Normal;					// 入力モード ← 通常モード
            stockSlip.DebitNLnkSuppSlipNo = 0;                      			// 赤黒連結仕入伝票番号 ← 0
            stockSlip.DebitNoteDiv = 0;                      			        // 赤伝区分 ← 0

            stockSlip.SupplierSlipNo = 0;										// 仕入伝票番号 ← 0
        }

        /// <summary>
        /// 複写伝票の仕入明細データテーブルを生成します。
        /// </summary>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		public void CreateSlipCopyDetailInfo( List<StockWork> stockWorkList )
        {
			this.CreateSlipCopyDetailInfo(stockWorkList, this._stockDetailDataTable);
        }

        /// <summary>
        /// 複写伝票の仕入明細データテーブルを生成します。（オーバーロード）
        /// </summary>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        /// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		public void CreateSlipCopyDetailInfo( List<StockWork> stockWorkList, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
			for (int i = 0; i < stockDetailDataTable.Count; i++)
			{
				StockInputDataSet.StockDetailRow row = stockDetailDataTable[i];
				row.SupplierSlipNo = 0;						// 仕入伝票番号 ← 0
				row.AcceptAnOrderNo = 0;					// 受注番号 ← 0
				row.CommonSeqNo = 0;						// 共通通番 ← 0
				row.StockSlipDtlNum = 0;					// 明細通番 ← 0
				row.SupplierFormalSrc = 0;					// 仕入形式(元) ← 呼出伝票の仕入形式
				row.StockSlipDtlNumSrc = 0;					// 明細通番(元) ← 呼出伝票の明細通番
				row.AcptAnOdrStatusSync = 0;				// 受注ステータス(同時) ← 0
				row.SalesSlipDtlNumSync = 0;				// 売上明細通番(同時) ← 0

				row.SalesCustomerCode = 0;
                row.SalesCustomerSnm = string.Empty;
				row.SupplierCd = 0;
                row.SupplierSnm = string.Empty;
				row.AddresseeCode = 0;
                row.AddresseeName = string.Empty;
				row.RemainCntUpdDate = DateTime.MinValue;
				row.DirectSendingCd = 0;
                row.OrderNumber = string.Empty;
				row.WayToOrder = 0;
				row.DeliGdsCmpltDueDate = DateTime.MinValue;
				row.ExpectDeliveryDate = DateTime.MinValue;
				row.OrderCnt = row.StockCount;
				row.OrderAdjustCnt = 0;
				row.OrderRemainCnt = 0;
				row.OrderDataCreateDiv = 0;
				row.OrderDataCreateDate = DateTime.MinValue;
				row.OrderFormIssuedDiv = 0;

				row.StockCountMin = 0;
				row.StockCountMax = 0;

				row.StockCountDisplay = row.StockCount * sign;

                if (row.StockCount != 0)
                {
                    //salesTempRow.StockCountDefault = salesTempRow.StockCountDisplay;

                    if (row.StockSlipCdDtl == 2)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;
                        row.CanTaxDivChange = false;
                    }
                    else
                    {
                        row.EditStatus = ctEDITSTATUS_AllOK;
                        row.CanTaxDivChange = true;
                    }
                }
                else
                {
                    if (row.StockSlipCdDtl == 2)
                    {
                        row.EditStatus = ctEDITSTATUS_RowDiscount;
                        row.CanTaxDivChange = false;
                    }
                }

				// メモ情報調整
				this.MemoInfoAdjust(ref row);
			}
			this.StockDetailStockInfoAdjust();
		}
		#endregion

		/// <summary>
		/// 仕入形式コードより、仕入形式名称を取得します。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <returns>仕入形式名称</returns>
		public string GetSupplierFormalName(StockSlip stockSlip)
		{
			return this.GetSupplierFormalName(stockSlip.SupplierFormal);
		}

		/// <summary>
		/// 仕入形式コードより、仕入形式名称を取得します。
		/// </summary>
		/// <param name="supplierFormal">仕入形式コード</param>
		/// <returns>仕入形式名称</returns>
		public string GetSupplierFormalName( int supplierFormal )
		{
            string supplierFormalName = string.Empty;

			if (supplierFormal == 1)
			{
				supplierFormalName = "入荷";
			}
			else
			{
				supplierFormalName = "仕入";
			}
			return supplierFormalName;
		}

		/// <summary>
		/// 仕入データオブジェクトをインスタンス変数にキャッシュします。
		/// </summary>
		/// <param name="source">仕入データオブジェクト</param>
		public void Cache( StockSlip source )
		{
			this._stockSlip = source.Clone();
			this._currentSupplierSlipNo = source.SupplierSlipNo;
		}

		/// <summary>
        /// 支払データ、支払明細データリストをインスタンス変数にキャッシュします。
		/// </summary>
        /// <param name="paymentSlp">支払データ</param>
        /// <param name="paymentDtlList">支払明細データリスト</param>
        public void Cache( PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList )
        {
            this._paymentSlp = ( paymentSlp == null ) ? new PaymentSlp() : paymentSlp.Clone();

            this._paymentDtlList = new List<PaymentDtl>();
            if (paymentDtlList != null)
            {
                foreach (PaymentDtl paymentDtl in paymentDtlList)
                {
                    this._paymentDtlList.Add(paymentDtl.Clone());
                }
            }
        }

		/// <summary>
		/// 仕入データに得意先（仕入先）の情報を設定します。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト（ref）</param>
		/// <param name="supplier">仕入先マスタオブジェクト</param>
		public void DataSettingStockSlip( ref StockSlip stockSlip, Supplier supplier )
		{
			//if ((stockSlip == null) || (custSuppli == null))
			if ( supplier == null )
			{
				stockSlip.SupplierCd = 0;                       // コード
                stockSlip.SupplierNm1 = string.Empty;           // 名称１
                stockSlip.SupplierNm2 = string.Empty;           // 名称２
                stockSlip.SupplierSnm = string.Empty;           // 略称
				stockSlip.BusinessTypeCode = 0;                 // 業種コード
                stockSlip.BusinessTypeName = string.Empty;      // 業種名称
				stockSlip.SalesAreaCode = 0;                    // 販売エリアコード
                stockSlip.SalesAreaName = string.Empty;         // 販売エリア名称
				stockSlip.SuppRateGrpCode = 0;                  // 仕入先掛率グループコード
                stockSlip.StockAddUpSectionCd = string.Empty;   // 計上拠点
                stockSlip.StockAddUpSectionNm = string.Empty;   // 計上拠点名称
				stockSlip.SuppCTaxLayCd = 0;                    // 消費税転嫁方式
				stockSlip.SuppTtlAmntDspWayCd = 0;              // 総額表示区分
				stockSlip.TtlAmntDispRateApy = 0;               // 総額表示掛率適用区分
			}
			else
			{
				if (supplier == null) supplier = new Supplier();

				// 支払先情報取得
				//CustomerInfo payeeCustomerInfo;
				//CustSuppli payeeCustSuppli;
				//int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerInfo.EnterpriseCode, custSuppli.PayeeCode, true, out payeeCustomerInfo, out payeeCustSuppli);
				Supplier payeeSupplier;
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
				int status = this._supplierAcs.Read(out payeeSupplier, supplier.EnterpriseCode, supplier.PayeeCode);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					payeeSupplier = new Supplier(); 
				}


				// 得意先情報
				stockSlip.SupplierCd = supplier.SupplierCd;					// コード
				stockSlip.SupplierNm1 = supplier.SupplierNm1;				// 名称１
				stockSlip.SupplierNm2 = supplier.SupplierNm2;				// 名称２
				stockSlip.SupplierSnm = supplier.SupplierSnm;				// 略称
				stockSlip.BusinessTypeCode = supplier.BusinessTypeCode;		// 業種コード
				stockSlip.BusinessTypeName = supplier.BusinessTypeName;		// 業種名称
				stockSlip.SalesAreaCode = supplier.SalesAreaCode;			// 販売エリアコード
				stockSlip.SalesAreaName = supplier.SalesAreaName;			// 販売エリア名称
				//stockSlip.SuppRateGrpCode = custSuppli.SuppRateGrpCode;			// 仕入先掛率グループコード

				// 仕入計上拠点
                stockSlip.StockAddUpSectionCd = supplier.PaymentSectionCode;
                stockSlip.StockAddUpSectionNm = supplier.PaymentSectionName;

				// 拠点表示区分が「0:標準」、「2:表示無し」の場合は、仕入先の管理拠点をセット
				if (( this._stockSlipInputInitDataAcs.GetStockTtlSt().SectDspDivCd == 0 ) || ( this._stockSlipInputInitDataAcs.GetStockTtlSt().SectDspDivCd == 2 ))
				{
					stockSlip.StockSectionCd = supplier.MngSectionCode.Trim();
					stockSlip.StockSectionNm = supplier.MngSectionName.Trim();
				}

                if (this._stockInputConstructionAcs.UseStockAgentValue == StockSlipInputConstructionAcs.UseStockAgent_ON)
                {
                    // マスタ上の仕入担当者が存在した場合に仕入担当者を書き換える
                    if (this._stockSlipInputInitDataAcs.CodeExist_Employee(supplier.StockAgentCode))
                    {
                        if (stockSlip.StockAgentCode != supplier.StockAgentCode)
                        {
                            stockSlip.StockAgentCode = supplier.StockAgentCode;
                            stockSlip.StockAgentName = supplier.StockAgentName;

                            if (stockSlip.StockAgentName.Length > 16)
                            {
                                stockSlip.StockAgentName = stockSlip.StockAgentName.Substring(0, 16);
                            }
                            this.StockAgentBelongInfoSetting(ref stockSlip);
                        }
                    }
                }

				// 消費税の端数処理区分
                double fractionProcUnit;
                int fractionProcCd;
				this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, supplier.StockCnsTaxFrcProcCd, 999999999, out fractionProcUnit, out fractionProcCd);
                stockSlip.StockFractionProcCd = fractionProcCd;

				// 以下、支払先情報
				stockSlip.PayeeCode = payeeSupplier.SupplierCd;
				stockSlip.PayeeSnm = payeeSupplier.SupplierSnm;
				stockSlip.PayeeName = payeeSupplier.SupplierNm1;
				stockSlip.PayeeName2 = payeeSupplier.SupplierNm2;
				stockSlip.PaymentTotalDay = payeeSupplier.PaymentTotalDay;
				stockSlip.NTimeCalcStDate = payeeSupplier.NTimeCalcStDate;

				// 計上日の再セット
				this.SettingAddUpDate(ref stockSlip);

				// 仕入在庫全体設定マスタ情報取得
				StockTtlSt stockTtlSt = this._stockSlipInputInitDataAcs.GetStockTtlSt();

				// 全体初期値設定マスタ情報取得
				AllDefSet allDefSet = this._stockSlipInputInitDataAcs.GetAllDefSet();

				if (stockTtlSt == null) stockTtlSt = new StockTtlSt();

				// 得意先仕入情報マスタの仕入先消費税転嫁方式参照区分が
				// 「1:仕入先参照」の場合は得意先仕入情報マスタの「仕入先消費税転嫁方式コード」を設定する
				// 「0:仕入在庫全体設定参照」の場合は仕入在庫全体設定マスタの「仕入先消費税転嫁方式コード」を設定する
				stockSlip.SuppCTaxLayCd = ( payeeSupplier.SuppCTaxLayRefCd == 1 ) ? payeeSupplier.SuppCTaxLayCd : this._stockSlipInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod;

				// 得意先仕入情報マスタの仕入先総額表示方法参照区分が
				// ｢1:仕入先参照」の場合は得意先仕入情報マスタの「仕入先総額表示方法区分」を設定する
				// ｢0:全体設定参照」の場合は全体初期値設定マスタの「総額表示方法区分」を設定する
				stockSlip.SuppTtlAmntDspWayCd = ( supplier.StckTtlAmntDspWayRef == 1 ) ? supplier.SuppTtlAmntDspWayCd : allDefSet.TotalAmountDispWayCd;

				// 総額表示掛率適用区分
				stockSlip.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;
			}
		}

		/// <summary>
		/// 計上日を設定します。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		public void SettingAddUpDate( ref StockSlip stockSlip )
		{
			DateTime addUpDate;
			int delayPaymentDiv;
			StockSlipInputAcs.CalcAddUpDate(stockSlip.StockDate, stockSlip.PaymentTotalDay, stockSlip.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

			stockSlip.StockAddUpADate = addUpDate;
			stockSlip.DelayPaymentDiv = delayPaymentDiv;
		}

        // 2009.07.10 Add >>>
        /// <summary>
        /// 計上日がデフォルト値かチェック
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <returns></returns>
        public bool CheckDefaultAddUpDate(StockSlip stockSlip)
        {
            DateTime addUpDate;
            int delayPaymentDiv;
            StockSlipInputAcs.CalcAddUpDate(stockSlip.StockDate, stockSlip.PaymentTotalDay, stockSlip.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

            return ( stockSlip.StockAddUpADate == addUpDate );
        }
        // 2009.07.10 Add <<<

		/// <summary>
		/// 所属情報設定処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		public void StockAgentBelongInfoSetting( ref StockSlip stockSlip )
		{
			string belongSecCd;
			int belongSubSecCd;
			this._stockSlipInputInitDataAcs.GetBelongInfo_FromEmployee(stockSlip.StockAgentCode, out belongSecCd, out belongSubSecCd);

			stockSlip.SubSectionCode = belongSubSecCd;
			stockSlip.SubSectionName = this._stockSlipInputInitDataAcs.GetName_FromSubSection(belongSubSecCd);
		}

		/// <summary>
		/// 指定された仕入データの状態を元に入力モードの設定を行います。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		public void SettingInputMode(StockSlip stockSlip)
		{
			bool isAddUp = false;
			if (stockSlip.SupplierFormal == 0)
			{
				string message;
				isAddUp = this.CheckAddUp(stockSlip, 1, out message);

				if (isAddUp)
				{
					stockSlip.InputMode = ctINPUTMODE_StockSlip_AddUp;
				}
			}

			if (!isAddUp)
			{
				if (stockSlip.DebitNoteDiv == 1)
				{
					// 赤伝
					stockSlip.InputMode = ctINPUTMODE_StockSlip_Red;
				}
				else if (stockSlip.DebitNoteDiv == 2)
				{
					// 元黒
					stockSlip.InputMode = ctINPUTMODE_StockSlip_ReadOnly;
				}
				else
				{
					stockSlip.InputMode = ctINPUTMODE_StockSlip_Normal;
				}
			}
		}

		/// <summary>
		/// 現在の仕入明細データオブジェクトのリストを仕入明細データテーブルより取得します。
		/// </summary>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="salesTempList">売上データ(仕入同時計上)オブジェクトリスト</param>
		/// <param name="savedSalesTempList">売上データ(仕入同時計上)オブジェクトリスト（保存済み)</param>
		public void GetCurrentStockDetail( out List<StockDetail> stockDetailList, out List<SalesTemp> salesTempList, out List<SalesTemp> savedSalesTempList )
		{
			this.GetUIDataFromTable(this._stockDetailDataTable, out stockDetailList, out salesTempList, out savedSalesTempList);
		}

		/// <summary>
		/// 現在の仕入明細データオブジェクトのリストを仕入明細データテーブルより取得します。
		/// </summary>
		/// <returns>仕入明細データオブジェクトリスト</returns>
        public void GetCurrentPaymentData( StockSlip stockSlip, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList )
		{
            if (( this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoPayment == 1 ) &&                                         // 自動支払
                ( stockSlip.SupplierFormal == 0 ) &&                                                                            // 仕入形式:仕入
                ( stockSlip.AccPayDivCd == 0 ) &&                                                                               // 買掛無し
                ( ( StockSlip.StockGoodsCd == 0 ) || ( StockSlip.StockGoodsCd == 1 ) || ( StockSlip.StockGoodsCd == 6 ) ))      // 商品区分:商品、商品外、合計
			{
                paymentSlp = new PaymentSlp();
                paymentDtlList = new List<PaymentDtl>();
                PaymentDtl paymentDtl = new PaymentDtl();
                paymentDtl.PaymentRowNo = 1;                                                                       // 行番号(1固定)
                paymentDtl.MoneyKindCode = this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoPayMoneyKindCode;   // 支払金種コード
                paymentDtl.MoneyKindName = this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoPayMoneyKindName;   // 支払金種名称
                paymentDtl.MoneyKindDiv = this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoPayMoneyKindDiv;     // 支払金種区分

                if (stockSlip.SupplierSlipNo != 0)
                {
                    paymentSlp = this._paymentSlp.Clone();
                    paymentSlp.PayeeName = stockSlip.PayeeName;												// 支払先名称
                    paymentSlp.PayeeName2 = stockSlip.PayeeName2;											// 支払先名称2

                    if (this._paymentDtlList.Count > 0)
                    {
                        paymentDtl.MoneyKindCode = this._paymentDtlList[0].MoneyKindCode;
                        paymentDtl.MoneyKindName = this._paymentDtlList[0].MoneyKindName;
                        paymentDtl.MoneyKindDiv = this._paymentDtlList[0].MoneyKindDiv;
                    }
                        
                }
                else
                {
                    paymentSlp.PayeeName = stockSlip.PayeeName;												// 支払先名称
                    paymentSlp.PayeeName2 = stockSlip.PayeeName2;											// 支払先名称2
                }

                paymentDtlList.Add(paymentDtl);
			}
			else
			{
                paymentSlp = null;
                paymentDtlList = null;
			}
		}

		#region 売上同時入力関連

		/// <summary>
		/// 同時売上新規入力行存在チェック
		/// </summary>
		/// <returns></returns>
		public bool SalesTempNewInputExist()
		{
			bool ret = false;

			foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable.Rows)
			{
				StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(stockDetailRow);

				if (( salesTempRow != null ) && ( salesTempRow.SalesSlipDtlNum == 0 ) && ( salesTempRow.CustomerCode != 0 ))
				{
					ret = true;
					break;
				}
			}

			return ret;
		}

		/// <summary>
		/// 売上存在チェック
		/// </summary>
		/// <param name="stockRowNo">対象行</param>
		/// <returns></returns>
		public bool SalesTempExist( int stockRowNo )
		{
			bool ret = false;

			StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

			if (row != null)
			{
				StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(row);

				if (( salesTempRow != null ) && ( salesTempRow.CustomerCode != 0 ))
				{
					ret = true;
				}
			}

			return ret;
		}

		/// <summary>
		/// 売上データ(仕入同時計上)オブジェクトリストをキャッシュします。（オーバーロード）
		/// </summary>
		/// <param name="salesTempList">売上データ(仕入同時計上)オブジェクトリスト</param>
		public void CacheSalesTemp( List<SalesTemp> salesTempList )
		{
			if (( salesTempList != null ) && ( salesTempList.Count > 0 ))
			{
				foreach (SalesTemp salesTemp in salesTempList)
				{
					foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable)
					{
						if ((salesTemp.SupplierFormalSync == stockDetailRow.SupplierFormal)&&
							( salesTemp.StockSlipDtlNumSync == stockDetailRow.StockSlipDtlNum ))
						{
							this.SalesTempAddRow(this._currentSupplierSlipNo, stockDetailRow.StockRowNo);
							this.CacheSalesTemp(stockDetailRow.StockRowNo, salesTemp);
						}
					}
				}
			}
		}

		/// <summary>
		/// 売上データ(仕入同時計上)行オブジェクトを仕入明細に合わせて調整します。
		/// </summary>
		/// <param name="stockRowNo"></param>
		public void SalesTempRowAdjust( int stockRowNo )
		{
			// 商品で、通常の黒伝のみ対象
			if (( this._stockSlip.StockGoodsCd == 0 ) && ( this._stockSlip.SupplierSlipCd == 10 ) && ( this._stockSlip.DebitNoteDiv == 0 ))
			{
                StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);

				// 商品入力済みの行のみ対象
				if (( stockDetailRow != null ) && 
					( stockDetailRow.StockSlipCdDtl == 0 ) && 
					( stockDetailRow.SalesSlipDtlNumSync == 0 ) && 
					( ( !string.IsNullOrEmpty(stockDetailRow.GoodsNo) ) || ( !string.IsNullOrEmpty(stockDetailRow.GoodsName) ) ))
				{
					StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(stockDetailRow);

					if (( salesTempRow != null ) && ( salesTempRow.CustomerCode != 0 ))
					{
						salesTempRow.GoodsName = stockDetailRow.GoodsName;
						salesTempRow.BLGoodsCode = stockDetailRow.BLGoodsCode;
						salesTempRow.BLGoodsFullName = stockDetailRow.BLGoodsFullName;

						salesTempRow.WarehouseCode = stockDetailRow.WarehouseCode;
						salesTempRow.WarehouseName = stockDetailRow.WarehouseName;
						salesTempRow.WarehouseShelfNo = stockDetailRow.WarehouseShelfNo;
					}
				}
			}
		}

		/// <summary>
		/// 売上同時計上テーブル行追加
		/// </summary>
		/// <param name="supplierSlipNo"></param>
		/// <param name="stockRowNo"></param>
		/// <returns>追加した売上同時計上オブジェクト</returns>
		private StockInputDataSet.SalesTempRow SalesTempAddRow( int supplierSlipNo, int stockRowNo )
		{
			// 仕入情報キーセット
			StockInputDataSet.StockDetailRow stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(supplierSlipNo, stockRowNo);

			if (( stockDetailRow.DtlRelationGuid == null ) || ( stockDetailRow.DtlRelationGuid == Guid.Empty ))
			{
				stockDetailRow.DtlRelationGuid = Guid.NewGuid();
			}

			// 売上同時計上キーセット
			StockInputDataSet.SalesTempRow row = this._salesTempDataTable.NewSalesTempRow();
			row.DtlRelationGuid = stockDetailRow.DtlRelationGuid;

			this._salesTempDataTable.AddSalesTempRow(row);
			return row;
		}

		/// <summary>
		/// 売上データ(仕入同時計上)仕入情報設定処理
		/// </summary>
		/// <param name="reCalcMoney">True:金額再計算する</param>
		public void SalesTempSupplierSetting( bool reCalcMoney )
		{
#if false
			foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable.Rows)
			{
				if (!string.IsNullOrEmpty(stockDetailRow.GoodsNo) || ( !string.IsNullOrEmpty(stockDetailRow.GoodsName) ))
				{
					SalesTemp salesTemp = this.GetSelesTemp(stockDetailRow.StockRowNo);

					if (( salesTemp != null ) && ( salesTemp.SalesSlipDtlNum == 0 ))
					{
						salesTemp.SupplierCd = this._stockSlip.SupplierCd;
						salesTemp.SupplierSnm = this._stockSlip.SupplierSnm;
						salesTemp.SuppRateGrpCode = this._stockSlip.SuppRateGrpCode;

						if (reCalcMoney)
						{
							// 単価算出
							this._salesTempInputAcs.CalclationUnitPrice(ref salesTemp);
							// 売上金額再計算
							this._salesTempInputAcs.CalculationSalesMoney(ref salesTemp);
							// 売上原価再計算
							this._salesTempInputAcs.CalculationCost(ref salesTemp);
							// 粗利チェック区分設定
							this._salesTempInputAcs.GrsProfitChkDivSetting(ref salesTemp);
							// キャッシュ
							this.CacheSalesTemp(stockDetailRow.StockRowNo, salesTemp);
						}
					}
				}
			}
#endif
		}
		
		/// <summary>
		/// 売上同時計上テーブル削除
		/// </summary>
		/// <param name="stockRowNoList"></param>
		private void DeleteSalesTempRow( List<int> stockRowNoList )
		{
			foreach (int stockRowNo in stockRowNoList)
			{
				this.DeleteSalesTempRow(this._currentSupplierSlipNo, stockRowNo);
			}
		}

		/// <summary>
		/// 売上同時計上テーブル削除
		/// </summary>
		/// <param name="supplierSlipNo"></param>
		/// <param name="stockRowNo"></param>
		private void DeleteSalesTempRow( int supplierSlipNo, int stockRowNo )
		{
			StockInputDataSet.StockDetailRow targetStockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(supplierSlipNo, stockRowNo);
			if (( targetStockDetailRow.DtlRelationGuid != null ) && ( targetStockDetailRow.DtlRelationGuid != Guid.Empty ))
			{
				StockInputDataSet.SalesTempRow targetRow = this._salesTempDataTable.FindByDtlRelationGuid(targetStockDetailRow.DtlRelationGuid);
				if (targetRow == null) return;
				this._salesTempDataTable.RemoveSalesTempRow(targetRow);
			}
		}

		/// <summary>
		/// 売上同時計上テーブル削除
		/// </summary>
		/// <param name="dtlRelationGuid">リレーション用GUID</param>
		private void DeleteSalesTempRow( System.Guid dtlRelationGuid )
		{
			if (( dtlRelationGuid == null ) || ( dtlRelationGuid == Guid.Empty ))
				return;
			StockInputDataSet.SalesTempRow targetRow = this._salesTempDataTable.FindByDtlRelationGuid(dtlRelationGuid);
			if (targetRow == null) return;
			this._salesTempDataTable.RemoveSalesTempRow(targetRow);
		}

		/// <summary>
		/// 売上同時計上オブジェクトのクリアを行います。
		/// </summary>
		/// <param name="stockRowNoList">クリア対象仕入行番号リスト</param>
		public void ClearSalesTempRow( List<int> stockRowNoList )
		{
			foreach (int stockRowNo in stockRowNoList)
			{
				// 売上同時計上明細行クリア処理
				this.ClearSalesTempRow(stockRowNo);
			}
		}

		/// <summary>
		/// 売上同時計上オブジェクトのクリアを行います。（オーバーロード）
		/// </summary>
		/// <param name="row">売上明細行オブジェクト</param>
		private void ClearSalesTempRow( StockInputDataSet.SalesTempRow row )
		{
			if (row == null) return;

			#region ●項目セット

			row.CreateDateTime = DateTime.MinValue;			// 作成日時
			row.UpdateDateTime = DateTime.MinValue;			// 更新日時
			row.EnterpriseCode = "";						// 企業コード
			//salesTempRow.FileHeaderGuid = 0;						// GUID
			row.UpdEmployeeCode = "";						// 更新従業員コード
			//salesTempRow.UpdAssemblyId1 = "";						// 更新アセンブリID1
			//salesTempRow.UpdAssemblyId2 = "";						// 更新アセンブリID2
			//salesTempRow.LogicalDeleteCode = 0;					// 論理削除区分
			row.AcptAnOdrStatus = 0;						// 受注ステータス
			row.SalesSlipNum = "";							// 売上伝票番号
			row.SectionCode = "";							// 拠点コード
			row.SubSectionCode = 0;							// 部門コード
			row.MinSectionCode = 0;							// 課コード
			row.DebitNoteDiv = 0;							// 赤伝区分
			row.DebitNLnkSalesSlNum = 0;					// 赤黒連結売上伝票番号
			row.SalesSlipCd = 0;							// 売上伝票区分
			row.AccRecDivCd = 0;							// 売掛区分
			row.SalesInpSecCd = "";							// 売上入力拠点コード
			row.DemandAddUpSecCd = "";						// 請求計上拠点コード
			row.ResultsAddUpSecCd = "";						// 実績計上拠点コード
			row.UpdateSecCd = "";							// 更新拠点コード
			row.SearchSlipDate = DateTime.MinValue;			// 伝票検索日付
			row.ShipmentDay = DateTime.MinValue;			// 出荷日付
			row.SalesDate = DateTime.MinValue;				// 売上日付
			row.AddUpADate = DateTime.MinValue;				// 計上日付
			row.DelayPaymentDiv = 0;						// 来勘区分
			row.ClaimCode = 0;								// 請求先コード
			row.ClaimSnm = "";								// 請求先略称
			row.CustomerCode = 0;							// 得意先コード
			row.CustomerName = "";							// 得意先名称
			row.CustomerName2 = "";							// 得意先名称2
			row.CustomerSnm = "";							// 得意先略称
			row.HonorificTitle = "";						// 敬称
			row.OutputNameCode = 0;							// 諸口コード
			row.BusinessTypeCode = 0;						// 業種コード
			row.BusinessTypeName = "";						// 業種名称
			row.SalesAreaCode = 0;							// 販売エリアコード
			row.SalesAreaName = "";							// 販売エリア名称
			row.SalesInputCode = "";						// 売上入力者コード
			row.SalesInputName = "";						// 売上入力者名称
			row.FrontEmployeeCd = "";						// 受付従業員コード
			row.FrontEmployeeNm = "";						// 受付従業員名称
			row.SalesEmployeeCd = "";						// 販売従業員コード
			row.SalesEmployeeNm = "";						// 販売従業員名称
			row.TotalAmountDispWayCd = 0;					// 総額表示方法区分
			row.TtlAmntDispRateApy = 0;						// 総額表示掛率適用区分
			row.ConsTaxLayMethod = 0;						// 消費税転嫁方式
			row.ConsTaxRate = 0;							// 消費税税率
			row.FractionProcCd = 0;							// 端数処理区分
			row.AccRecConsTax = 0;							// 売掛消費税
			row.AutoDepositCd = 0;							// 自動入金区分
			row.AutoDepoSlipNum = 0;						// 自動入金伝票番号
			row.DepositAllowanceTtl = 0;					// 入金引当合計額
			row.DepositAlwcBlnce = 0;						// 入金引当残高
			row.SlipAddressDiv = 0;							// 伝票住所区分
			row.AddresseeCode = 0;							// 納品先コード
			row.AddresseeName = "";							// 納品先名称
			row.AddresseeName2 = "";						// 納品先名称2
			row.AddresseePostNo = "";						// 納品先郵便番号
			row.AddresseeAddr1 = "";						// 納品先住所1(都道府県市区郡・町村・字)
			row.AddresseeAddr2 = 0;							// 納品先住所2(丁目)
			row.AddresseeAddr3 = "";						// 納品先住所3(番地)
			row.AddresseeAddr4 = "";						// 納品先住所4(アパート名称)
			row.AddresseeTelNo = "";						// 納品先電話番号
			row.AddresseeFaxNo = "";						// 納品先FAX番号
			row.PartySaleSlipNum = "";						// 相手先伝票番号
			row.SlipNote = "";								// 伝票備考
			row.SlipNote2 = "";								// 伝票備考２
			row.RetGoodsReasonDiv = 0;						// 返品理由コード
			row.RetGoodsReason = "";						// 返品理由
			row.DetailRowCount = 0;							// 明細行数
			row.DeliveredGoodsDiv = 0;						// 納品区分
			row.DeliveredGoodsDivNm = "";					// 納品区分名称
			row.ReconcileFlag = 0;							// 消込フラグ
			row.SlipPrtSetPaperId = "";						// 伝票印刷設定用帳票ID
			row.CompleteCd = 0;								// 一式伝票区分
			row.ClaimType = 0;								// 請求先区分
			row.SalesPriceFracProcCd = 0;					// 売上金額端数処理区分
			row.ListPricePrintDiv = 0;						// 定価印刷区分
			row.EraNameDispCd1 = 0;							// 元号表示区分１
			row.CommonSeqNo = 0;							// 共通通番
			row.SalesSlipDtlNum = 0;						// 売上明細通番
			row.AcptAnOdrStatusSrc = 0;						// 受注ステータス（元）
			row.SalesSlipDtlNumSrc = 0;						// 売上明細通番（元）
			row.SupplierFormalSync = 0;						// 仕入形式（同時）
			row.StockSlipDtlNumSync = 0;					// 仕入明細通番（同時）
			row.SalesSlipCdDtl = 0;							// 売上伝票区分（明細）
			row.StockMngExistCd = 0;						// 在庫管理有無区分
			row.DeliGdsCmpltDueDate = DateTime.MinValue;	// 納品完了予定日
			row.GoodsKindCode = 0;							// 商品属性
			row.GoodsMakerCd = 0;							// 商品メーカーコード
			row.MakerName = "";								// メーカー名称
			row.GoodsNo = "";								// 商品番号
			row.GoodsName = "";								// 商品名称
			row.GoodsShortName = "";						// 商品名称略称
			row.GoodsSetDivCd = 0;							// セット商品区分
			row.LargeGoodsGanreCode = "";					// 商品区分グループコード
			row.LargeGoodsGanreName = "";					// 商品区分グループ名称
			row.MediumGoodsGanreCode = "";					// 商品区分コード
			row.MediumGoodsGanreName = "";					// 商品区分名称
			row.DetailGoodsGanreCode = "";					// 商品区分詳細コード
			row.DetailGoodsGanreName = "";					// 商品区分詳細名称
			row.BLGoodsCode = 0;							// BL商品コード
			row.BLGoodsFullName = "";						// BL商品コード名称（全角）
			row.EnterpriseGanreCode = 0;					// 自社分類コード
			row.EnterpriseGanreName = "";					// 自社分類名称
			row.WarehouseCode = "";							// 倉庫コード
			row.WarehouseName = "";							// 倉庫名称
			row.WarehouseShelfNo = "";						// 倉庫棚番
			row.SalesOrderDivCd = 0;						// 売上在庫取寄せ区分
			row.GoodsRateRank = "";							// 商品掛率ランク
			row.CustRateGrpCode = 0;						// 得意先掛率グループコード
			row.SuppRateGrpCode = 0;						// 仕入先掛率グループコード
			row.ListPriceRate = 0;							// 定価率
			row.RateSectPriceUnPrc = "";					// 掛率設定拠点（定価）
			row.RateDivLPrice = "";							// 掛率設定区分（定価）
			row.UnPrcCalcCdLPrice = 0;						// 単価算出区分（定価）
			row.PriceCdLPrice = 0;							// 価格区分（定価）
			row.StdUnPrcLPrice = 0;							// 基準単価（定価）
			row.FracProcUnitLPrice = 0;						// 端数処理単位（定価）
			row.FracProcLPrice = 0;							// 端数処理（定価）
			row.ListPriceTaxIncFl = 0;						// 定価（税込，浮動）
			row.ListPriceTaxExcFl = 0;						// 定価（税抜，浮動）
			row.ListPriceChngCd = 0;						// 定価変更区分
			row.SalesRate = 0;								// 売価率
			row.RateSectSalUnPrc = "";						// 掛率設定拠点（売上単価）
			row.RateDivSalUnPrc = "";						// 掛率設定区分（売上単価）
			row.UnPrcCalcCdSalUnPrc = 0;					// 単価算出区分（売上単価）
			row.PriceCdSalUnPrc = 0;						// 価格区分（売上単価）
			row.StdUnPrcSalUnPrc = 0;						// 基準単価（売上単価）
			row.FracProcUnitSalUnPrc = 0;					// 端数処理単位（売上単価）
			row.FracProcSalUnPrc = 0;						// 端数処理（売上単価）
			row.SalesUnPrcTaxIncFl = 0;						// 売上単価（税込，浮動）
			row.SalesUnPrcTaxExcFl = 0;						// 売上単価（税抜，浮動）
			row.SalesUnPrcChngCd = 0;						// 売上単価変更区分
			row.CostRate = 0;								// 原価率
			row.RateSectCstUnPrc = "";						// 掛率設定拠点（原価単価）
			row.RateDivUnCst = "";							// 掛率設定区分（原価単価）
			row.UnPrcCalcCdUnCst = 0;						// 単価算出区分（原価単価）
			row.PriceCdUnCst = 0;							// 価格区分（原価単価）
			row.StdUnPrcUnCst = 0;							// 基準単価（原価単価）
			row.FracProcUnitUnCst = 0;						// 端数処理単位（原価単価）
			row.FracProcUnCst = 0;							// 端数処理（原価単価）
			row.SalesUnitCost = 0;							// 原価単価
			row.SalesUnitCostChngDiv = 0;					// 原価単価変更区分
			row.RateBLGoodsCode = 0;						// BL商品コード（掛率）
			row.RateBLGoodsName = "";						// BL商品コード名称（掛率）
			row.ShipmentCnt = 0;							// 出荷数
			row.SalesMoneyTaxInc = 0;						// 売上金額（税込み）
			row.SalesMoneyTaxExc = 0;						// 売上金額（税抜き）
			row.Cost = 0;									// 原価
			row.GrsProfitChkDiv = 0;						// 粗利チェック区分
			row.SalesGoodsCd = 0;							// 売上商品区分
			row.SalsePriceConsTax = 0;						// 売上金額消費税額
			row.TaxationDivCd = 0;							// 課税区分
			row.PartySlipNumDtl = "";						// 相手先伝票番号（明細）
			row.DtlNote = "";								// 明細備考
			row.SupplierCd = 0;								// 仕入先コード
			row.SupplierSnm = "";							// 仕入先略称
			row.SlipMemo1 = "";								// 伝票メモ１
			row.SlipMemo2 = "";								// 伝票メモ２
			row.SlipMemo3 = "";								// 伝票メモ３
			row.SlipMemo4 = "";								// 伝票メモ４
			row.SlipMemo5 = "";								// 伝票メモ５
			row.SlipMemo6 = "";								// 伝票メモ６
			row.InsideMemo1 = "";							// 社内メモ１
			row.InsideMemo2 = "";							// 社内メモ２
			row.InsideMemo3 = "";							// 社内メモ３
			row.InsideMemo4 = "";							// 社内メモ４
			row.InsideMemo5 = "";							// 社内メモ５
			row.InsideMemo6 = "";							// 社内メモ６
			row.BfListPrice = 0;							// 変更前定価
			row.BfSalesUnitPrice = 0;						// 変更前売価
			row.BfUnitCost = 0;								// 変更前原価
			row.PrtGoodsNo = "";							// 印刷用商品番号
			row.PrtGoodsName = "";							// 印刷用商品名称
			row.PrtGoodsMakerCd = 0;						// 印刷用商品メーカーコード
			row.PrtGoodsMakerNm = "";						// 印刷用商品メーカー名称
			row.SupplierSlipCd = 0;							// 仕入伝票区分
			row.ConfirmedDiv = false;						// 確認区分

			#endregion
		}

		/// <summary>
		/// 売上同時計上オブジェクトのクリアを行います。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">クリア対象売上行番号</param>
		public void ClearSalesTempRow( int stockRowNo )
		{
			StockInputDataSet.StockDetailRow stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this.StockSlip.SupplierSlipNo, stockRowNo);
			if (( stockDetailRow.DtlRelationGuid == null ) || ( stockDetailRow.DtlRelationGuid == Guid.Empty ))
			{
				StockInputDataSet.SalesTempRow row = this._salesTempDataTable.FindByDtlRelationGuid(stockDetailRow.DtlRelationGuid);

				if (row != null)
				{
					this.ClearSalesTempRow(row);
				}
			}
		}

		/// <summary>
		/// 対象行の売上同時計上を取得します（オーバーロード）
		/// </summary>
		/// <param name="stockDetailRow">仕入明細データオブジェクト</param>
		/// <returns>同時売上データオブジェクト</returns>
		public StockInputDataSet.SalesTempRow GetSalesTempRow( StockInputDataSet.StockDetailRow stockDetailRow )
		{
			StockInputDataSet.SalesTempRow retSalesTempRow = null;
			if (( stockDetailRow != null ) && ( ( !string.IsNullOrEmpty(stockDetailRow.GoodsNo.Trim()) ) || ( !string.IsNullOrEmpty(stockDetailRow.GoodsName.Trim()) ) ))
			{

				DataRow[] dataRows = stockDetailRow.GetChildRows(cRelation_Detail_SalesTemp);

				foreach (StockInputDataSet.SalesTempRow salesTempRow in dataRows)
				{
					retSalesTempRow = salesTempRow;
					break;
				}

				// 存在しなかった場合は追加する
				if (retSalesTempRow == null)
				{
					retSalesTempRow = this.SalesTempAddRow(this._currentSupplierSlipNo, stockDetailRow.StockRowNo);
				}
			}
			return retSalesTempRow;
		}


		/// <summary>
		/// 対象行の売上同時計上を取得します（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		/// <returns>同時売上データオブジェクト</returns>
		public StockInputDataSet.SalesTempRow GetSalesTempRow( int stockRowNo )
		{
            return this.GetSalesTempRow(this.GetStockDetailRow(stockRowNo));
		}

		/// <summary>
		/// 対象仕入明細行の同時売上情報を取得します。
		/// </summary>
		/// <param name="stockRowNo">仕入明細行番号</param>
		public void SettingSalesTempInfo( int stockRowNo )
		{

			SalesTemp salesTemp = null;
			StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);

			if (stockDetailRow != null)
			{
				if (( ( !string.IsNullOrEmpty(stockDetailRow.GoodsNo) ) || ( !string.IsNullOrEmpty(stockDetailRow.GoodsName) ) ) && ( this._stockSlip.StockGoodsCd == 0 ))
				{
					salesTemp = this.GetSelesTemp(stockRowNo);
				}
			}
			//this._salesTempInputAcs.SettingSalesTemp(stockRowNo, salesTemp, stockDetailRow);
		}

		/// <summary>
		/// 売上同時計上情報を取得します。
		/// </summary>
		/// <param name="stockRowNo">売上同時計上データ行オブジェクト</param>
		/// <returns>売上同時データオブジェクト</returns>
		public SalesTemp GetSelesTemp( int stockRowNo )
		{
			StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);
			StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(stockDetailRow);
			SalesTemp salesTemp = null;

			if (salesTempRow != null)
			{
				if (( stockDetailRow.StockSlipCdDtl != 2 ) && ( this._stockSlip.StockGoodsCd == 0 ))
				{
					if (( stockDetailRow.GoodsNo != salesTempRow.GoodsNo ) || ( stockDetailRow.GoodsMakerCd != salesTempRow.GoodsMakerCd ) || ( salesTempRow.CustomerCode == 0 ))
					{
						this.SalesTempRowDefaultSetting(stockDetailRow, ref salesTempRow);
					}

					salesTempRow.SupplierSlipCd = this._stockSlip.SupplierSlipCd;

					this.GetUIDataFromRow(salesTempRow, out salesTemp);
				}
			}

			return salesTemp;
		}

		/// <summary>
		/// 売上同時データ行オブジェクトより、売上同時データオブジェクトを取得します。
		/// </summary>
		/// <param name="row">売上同時データ行オブジェクト</param>
		/// <param name="salesTemp">売上同時データオブジェクト</param>
		private void GetUIDataFromRow( StockInputDataSet.SalesTempRow row, out SalesTemp salesTemp )
		{
			salesTemp = GetUIDataFromRow(row);
		}

		/// <summary>
		/// 売上同時データ行オブジェクトより売上同時データオブジェクトを取得します。
		/// </summary>
		/// <param name="row">売上同時データ行オブジェクト</param>
		/// <returns>売上同時データオブジェクト</returns>
		private SalesTemp GetUIDataFromRow( StockInputDataSet.SalesTempRow row )
		{
			SalesTemp salesTemp = new SalesTemp();

			#region ●項目セット

			salesTemp.CreateDateTime = row.CreateDateTime;				// 作成日時
			salesTemp.UpdateDateTime = row.UpdateDateTime;				// 更新日時
			salesTemp.EnterpriseCode = row.EnterpriseCode;				// 企業コード
			//salesTempRow.FileHeaderGuid = salesTempRow.FileHeaderGuid;				// GUID
			salesTemp.UpdEmployeeCode = row.UpdEmployeeCode;			// 更新従業員コード
			//salesTempRow.UpdAssemblyId1 = salesTempRow.UpdAssemblyId1;				// 更新アセンブリID1
			//salesTempRow.UpdAssemblyId2 = salesTempRow.UpdAssemblyId2;				// 更新アセンブリID2
			salesTemp.LogicalDeleteCode = row.LogicalDeleteCode;		// 論理削除区分
			salesTemp.AcptAnOdrStatus = row.AcptAnOdrStatus;			// 受注ステータス
			//salesTempRow.SalesSlipNum = salesTempRow.SalesSlipNum;					// 売上伝票番号
			salesTemp.SectionCode = row.SectionCode;					// 拠点コード
			salesTemp.SubSectionCode = row.SubSectionCode;				// 部門コード
			salesTemp.MinSectionCode = row.MinSectionCode;				// 課コード
			salesTemp.DebitNoteDiv = row.DebitNoteDiv;					// 赤伝区分
			//salesTempRow.DebitNLnkSalesSlNum = salesTempRow.DebitNLnkSalesSlNum;	// 赤黒連結売上伝票番号
			salesTemp.SalesSlipCd = row.SalesSlipCd;					// 売上伝票区分
			salesTemp.AccRecDivCd = row.AccRecDivCd;					// 売掛区分
			salesTemp.SalesInpSecCd = row.SalesInpSecCd;				// 売上入力拠点コード
			salesTemp.DemandAddUpSecCd = row.DemandAddUpSecCd;			// 請求計上拠点コード
			salesTemp.ResultsAddUpSecCd = row.ResultsAddUpSecCd;		// 実績計上拠点コード
			salesTemp.UpdateSecCd = row.UpdateSecCd;					// 更新拠点コード
			salesTemp.SearchSlipDate = row.SearchSlipDate;				// 伝票検索日付
			salesTemp.ShipmentDay = row.ShipmentDay;					// 出荷日付
			salesTemp.SalesDate = row.SalesDate;						// 売上日付
			salesTemp.AddUpADate = row.AddUpADate;						// 計上日付
			salesTemp.DelayPaymentDiv = row.DelayPaymentDiv;			// 来勘区分
			salesTemp.ClaimCode = row.ClaimCode;						// 請求先コード
			salesTemp.ClaimSnm = row.ClaimSnm;							// 請求先略称
			salesTemp.CustomerCode = row.CustomerCode;					// 得意先コード
			salesTemp.CustomerName = row.CustomerName;					// 得意先名称
			salesTemp.CustomerName2 = row.CustomerName2;				// 得意先名称2
			salesTemp.CustomerSnm = row.CustomerSnm;					// 得意先略称
			salesTemp.HonorificTitle = row.HonorificTitle;				// 敬称
			salesTemp.OutputNameCode = row.OutputNameCode;				// 諸口コード
			salesTemp.BusinessTypeCode = row.BusinessTypeCode;			// 業種コード
			salesTemp.BusinessTypeName = row.BusinessTypeName;			// 業種名称
			salesTemp.SalesAreaCode = row.SalesAreaCode;				// 販売エリアコード
			salesTemp.SalesAreaName = row.SalesAreaName;				// 販売エリア名称
			salesTemp.SalesInputCode = row.SalesInputCode;				// 売上入力者コード
			salesTemp.SalesInputName = row.SalesInputName;				// 売上入力者名称
			salesTemp.FrontEmployeeCd = row.FrontEmployeeCd;			// 受付従業員コード
			salesTemp.FrontEmployeeNm = row.FrontEmployeeNm;			// 受付従業員名称
			salesTemp.SalesEmployeeCd = row.SalesEmployeeCd;			// 販売従業員コード
			salesTemp.SalesEmployeeNm = row.SalesEmployeeNm;			// 販売従業員名称
			salesTemp.TotalAmountDispWayCd = row.TotalAmountDispWayCd;	// 総額表示方法区分
			salesTemp.TtlAmntDispRateApy = row.TtlAmntDispRateApy;		// 総額表示掛率適用区分
			salesTemp.ConsTaxLayMethod = row.ConsTaxLayMethod;			// 消費税転嫁方式
			salesTemp.ConsTaxRate = row.ConsTaxRate;					// 消費税税率
			salesTemp.FractionProcCd = row.FractionProcCd;				// 端数処理区分
			//salesTempRow.AccRecConsTax = salesTempRow.AccRecConsTax;				// 売掛消費税
			salesTemp.AutoDepositCd = row.AutoDepositCd;				// 自動入金区分
			salesTemp.AutoDepoSlipNum = row.AutoDepoSlipNum;			// 自動入金伝票番号
			//salesTempRow.DepositAllowanceTtl = salesTempRow.DepositAllowanceTtl;	// 入金引当合計額
			//salesTempRow.DepositAlwcBlnce = salesTempRow.DepositAlwcBlnce;			// 入金引当残高
			salesTemp.SlipAddressDiv = row.SlipAddressDiv;				// 伝票住所区分
			salesTemp.AddresseeCode = row.AddresseeCode;				// 納品先コード
			salesTemp.AddresseeName = row.AddresseeName;				// 納品先名称
			salesTemp.AddresseeName2 = row.AddresseeName2;				// 納品先名称2
			salesTemp.AddresseePostNo = row.AddresseePostNo;			// 納品先郵便番号
			salesTemp.AddresseeAddr1 = row.AddresseeAddr1;				// 納品先住所1(都道府県市区郡・町村・字)
			salesTemp.AddresseeAddr2 = row.AddresseeAddr2;				// 納品先住所2(丁目)
			salesTemp.AddresseeAddr3 = row.AddresseeAddr3;				// 納品先住所3(番地)
			salesTemp.AddresseeAddr4 = row.AddresseeAddr4;				// 納品先住所4(アパート名称)
			salesTemp.AddresseeTelNo = row.AddresseeTelNo;				// 納品先電話番号
			salesTemp.AddresseeFaxNo = row.AddresseeFaxNo;				// 納品先FAX番号
			salesTemp.PartySaleSlipNum = row.PartySaleSlipNum;			// 相手先伝票番号
			salesTemp.SlipNote = row.SlipNote;							// 伝票備考
			salesTemp.SlipNote2 = row.SlipNote2;						// 伝票備考２
			salesTemp.RetGoodsReasonDiv = row.RetGoodsReasonDiv;		// 返品理由コード
			salesTemp.RetGoodsReason = row.RetGoodsReason;				// 返品理由
			salesTemp.DetailRowCount = row.DetailRowCount;				// 明細行数
			salesTemp.DeliveredGoodsDiv = row.DeliveredGoodsDiv;		// 納品区分
			salesTemp.DeliveredGoodsDivNm = row.DeliveredGoodsDivNm;	// 納品区分名称
			salesTemp.ReconcileFlag = row.ReconcileFlag;				// 消込フラグ
			salesTemp.SlipPrtSetPaperId = row.SlipPrtSetPaperId;		// 伝票印刷設定用帳票ID
			salesTemp.CompleteCd = row.CompleteCd;						// 一式伝票区分
			salesTemp.ClaimType = row.ClaimType;						// 請求先区分
			salesTemp.SalesPriceFracProcCd = row.SalesPriceFracProcCd;	// 売上金額端数処理区分
			salesTemp.ListPricePrintDiv = row.ListPricePrintDiv;		// 定価印刷区分
			salesTemp.EraNameDispCd1 = row.EraNameDispCd1;				// 元号表示区分１
			salesTemp.CommonSeqNo = row.CommonSeqNo;					// 共通通番
			salesTemp.SalesSlipDtlNum = row.SalesSlipDtlNum;			// 売上明細通番
			salesTemp.AcptAnOdrStatusSrc = row.AcptAnOdrStatusSrc;		// 受注ステータス（元）
			salesTemp.SalesSlipDtlNumSrc = row.SalesSlipDtlNumSrc;		// 売上明細通番（元）
			salesTemp.SupplierFormalSync = row.SupplierFormalSync;		// 仕入形式（同時）
			salesTemp.StockSlipDtlNumSync = row.StockSlipDtlNumSync;	// 仕入明細通番（同時）
			salesTemp.SalesSlipCdDtl = row.SalesSlipCdDtl;				// 売上伝票区分（明細）
			salesTemp.StockMngExistCd = row.StockMngExistCd;			// 在庫管理有無区分
			salesTemp.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate;	// 納品完了予定日
			salesTemp.GoodsKindCode = row.GoodsKindCode;				// 商品属性
			salesTemp.GoodsMakerCd = row.GoodsMakerCd;					// 商品メーカーコード
			salesTemp.MakerName = row.MakerName;						// メーカー名称
			salesTemp.GoodsNo = row.GoodsNo;							// 商品番号
			salesTemp.GoodsName = row.GoodsName;						// 商品名称
			salesTemp.GoodsShortName = row.GoodsShortName;				// 商品名称略称
			salesTemp.GoodsSetDivCd = row.GoodsSetDivCd;				// セット商品区分
			salesTemp.LargeGoodsGanreCode = row.LargeGoodsGanreCode;	// 商品区分グループコード
			salesTemp.LargeGoodsGanreName = row.LargeGoodsGanreName;	// 商品区分グループ名称
			salesTemp.MediumGoodsGanreCode = row.MediumGoodsGanreCode;	// 商品区分コード
			salesTemp.MediumGoodsGanreName = row.MediumGoodsGanreName;	// 商品区分名称
			salesTemp.DetailGoodsGanreCode = row.DetailGoodsGanreCode;	// 商品区分詳細コード
			salesTemp.DetailGoodsGanreName = row.DetailGoodsGanreName;	// 商品区分詳細名称
			salesTemp.BLGoodsCode = row.BLGoodsCode;					// BL商品コード
			salesTemp.BLGoodsFullName = row.BLGoodsFullName;			// BL商品コード名称（全角）
			salesTemp.EnterpriseGanreCode = row.EnterpriseGanreCode;	// 自社分類コード
			salesTemp.EnterpriseGanreName = row.EnterpriseGanreName;	// 自社分類名称
			salesTemp.WarehouseCode = row.WarehouseCode;				// 倉庫コード
			salesTemp.WarehouseName = row.WarehouseName;				// 倉庫名称
			salesTemp.WarehouseShelfNo = row.WarehouseShelfNo;			// 倉庫棚番
			salesTemp.SalesOrderDivCd = row.SalesOrderDivCd;			// 売上在庫取寄せ区分
			salesTemp.GoodsRateRank = row.GoodsRateRank;				// 商品掛率ランク
			salesTemp.CustRateGrpCode = row.CustRateGrpCode;			// 得意先掛率グループコード
			salesTemp.SuppRateGrpCode = row.SuppRateGrpCode;			// 仕入先掛率グループコード
			salesTemp.ListPriceRate = row.ListPriceRate;				// 定価率
			salesTemp.RateSectPriceUnPrc = row.RateSectPriceUnPrc;		// 掛率設定拠点（定価）
			salesTemp.RateDivLPrice = row.RateDivLPrice;				// 掛率設定区分（定価）
			salesTemp.UnPrcCalcCdLPrice = row.UnPrcCalcCdLPrice;		// 単価算出区分（定価）
			salesTemp.PriceCdLPrice = row.PriceCdLPrice;				// 価格区分（定価）
			salesTemp.StdUnPrcLPrice = row.StdUnPrcLPrice;				// 基準単価（定価）
			salesTemp.FracProcUnitLPrice = row.FracProcUnitLPrice;		// 端数処理単位（定価）
			salesTemp.FracProcLPrice = row.FracProcLPrice;				// 端数処理（定価）
			salesTemp.ListPriceTaxIncFl = row.ListPriceTaxIncFl;		// 定価（税込，浮動）
			salesTemp.ListPriceTaxExcFl = row.ListPriceTaxExcFl;		// 定価（税抜，浮動）
			salesTemp.ListPriceChngCd = row.ListPriceChngCd;			// 定価変更区分
			salesTemp.SalesRate = row.SalesRate;						// 売価率
			salesTemp.RateSectSalUnPrc = row.RateSectSalUnPrc;			// 掛率設定拠点（売上単価）
			salesTemp.RateDivSalUnPrc = row.RateDivSalUnPrc;			// 掛率設定区分（売上単価）
			salesTemp.UnPrcCalcCdSalUnPrc = row.UnPrcCalcCdSalUnPrc;	// 単価算出区分（売上単価）
			salesTemp.PriceCdSalUnPrc = row.PriceCdSalUnPrc;			// 価格区分（売上単価）
			salesTemp.StdUnPrcSalUnPrc = row.StdUnPrcSalUnPrc;			// 基準単価（売上単価）
			salesTemp.FracProcUnitSalUnPrc = row.FracProcUnitSalUnPrc;	// 端数処理単位（売上単価）
			salesTemp.FracProcSalUnPrc = row.FracProcSalUnPrc;			// 端数処理（売上単価）
			salesTemp.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxIncFl;		// 売上単価（税込，浮動）
			salesTemp.SalesUnPrcTaxExcFl = row.SalesUnPrcTaxExcFl;		// 売上単価（税抜，浮動）
			salesTemp.SalesUnPrcChngCd = row.SalesUnPrcChngCd;			// 売上単価変更区分
			salesTemp.CostRate = row.CostRate;							// 原価率
			salesTemp.RateSectCstUnPrc = row.RateSectCstUnPrc;			// 掛率設定拠点（原価単価）
			salesTemp.RateDivUnCst = row.RateDivUnCst;					// 掛率設定区分（原価単価）
			salesTemp.UnPrcCalcCdUnCst = row.UnPrcCalcCdUnCst;			// 単価算出区分（原価単価）
			salesTemp.PriceCdUnCst = row.PriceCdUnCst;					// 価格区分（原価単価）
			salesTemp.StdUnPrcUnCst = row.StdUnPrcUnCst;				// 基準単価（原価単価）
			salesTemp.FracProcUnitUnCst = row.FracProcUnitUnCst;		// 端数処理単位（原価単価）
			salesTemp.FracProcUnCst = row.FracProcUnCst;				// 端数処理（原価単価）
			salesTemp.SalesUnitCost = row.SalesUnitCost;				// 原価単価
			salesTemp.SalesUnitCostChngDiv = row.SalesUnitCostChngDiv;	// 原価単価変更区分
			salesTemp.RateBLGoodsCode = row.RateBLGoodsCode;			// BL商品コード（掛率）
			salesTemp.RateBLGoodsName = row.RateBLGoodsName;			// BL商品コード名称（掛率）
			salesTemp.ShipmentCnt = row.ShipmentCnt;					// 出荷数
			salesTemp.AcptAnOdrRemainCnt = row.AcceptAnOrderCnt;		// 受注残
			salesTemp.SalesMoneyTaxInc = row.SalesMoneyTaxInc;			// 売上金額（税込み）
			salesTemp.SalesMoneyTaxExc = row.SalesMoneyTaxExc;			// 売上金額（税抜き）
			salesTemp.Cost = row.Cost;									// 原価
			salesTemp.GrsProfitChkDiv = row.GrsProfitChkDiv;			// 粗利チェック区分
			salesTemp.SalesGoodsCd = row.SalesGoodsCd;					// 売上商品区分
			salesTemp.SalsePriceConsTax = row.SalsePriceConsTax;		// 売上金額消費税額
			salesTemp.TaxationDivCd = row.TaxationDivCd;				// 課税区分
			salesTemp.PartySlipNumDtl = row.PartySlipNumDtl;			// 相手先伝票番号（明細）
			salesTemp.DtlNote = row.DtlNote;							// 明細備考
			salesTemp.SupplierCd = row.SupplierCd;						// 仕入先コード
			salesTemp.SupplierSnm = row.SupplierSnm;					// 仕入先略称
			salesTemp.SlipMemo1 = row.SlipMemo1;						// 伝票メモ１
			salesTemp.SlipMemo2 = row.SlipMemo2;						// 伝票メモ２
			salesTemp.SlipMemo3 = row.SlipMemo3;						// 伝票メモ３
			salesTemp.SlipMemo4 = row.SlipMemo4;						// 伝票メモ４
			salesTemp.SlipMemo5 = row.SlipMemo5;						// 伝票メモ５
			salesTemp.SlipMemo6 = row.SlipMemo6;						// 伝票メモ６
			salesTemp.InsideMemo1 = row.InsideMemo1;					// 社内メモ１
			salesTemp.InsideMemo2 = row.InsideMemo2;					// 社内メモ２
			salesTemp.InsideMemo3 = row.InsideMemo3;					// 社内メモ３
			salesTemp.InsideMemo4 = row.InsideMemo4;					// 社内メモ４
			salesTemp.InsideMemo5 = row.InsideMemo5;					// 社内メモ５
			salesTemp.InsideMemo6 = row.InsideMemo6;					// 社内メモ６
			salesTemp.BfListPrice = row.BfListPrice;					// 変更前定価
			salesTemp.BfSalesUnitPrice = row.BfSalesUnitPrice;			// 変更前売価
			salesTemp.BfUnitCost = row.BfUnitCost;						// 変更前原価
			salesTemp.PrtGoodsNo = row.PrtGoodsNo;						// 印刷用商品番号
			salesTemp.PrtGoodsName = row.PrtGoodsName;					// 印刷用商品名称
			salesTemp.PrtGoodsMakerCd = row.PrtGoodsMakerCd;			// 印刷用商品メーカーコード
			salesTemp.PrtGoodsMakerNm = row.PrtGoodsMakerNm;			// 印刷用商品メーカー名称
			salesTemp.SupplierSlipCd = row.SupplierSlipCd;				// 仕入伝票																																								区分
			salesTemp.ConfirmedDiv = row.ConfirmedDiv;					// 確認区分

			#endregion

			if (salesTemp.GoodsShortName.Length > 15)
			{
				salesTemp.GoodsShortName = salesTemp.GoodsShortName.Substring(0, 15);
			}

			return salesTemp;
		}

		/// <summary>
		/// 売上同時計上情報初期値設定
		/// </summary>
		/// <param name="stockDetailRow"></param>
		/// <param name="salesTempRow"></param>
		private void SalesTempRowDefaultSetting( StockInputDataSet.StockDetailRow stockDetailRow, ref StockInputDataSet.SalesTempRow salesTempRow )
		{
			//salesTempRow = new StockInputDataSet.SalesTempRow();

			this.ClearSalesTempRow(salesTempRow);

			#region ●項目セット

			//salesTempRow.AcptAnOdrStatus = 30;												// 受注ステータス
            //salesTempRow.AcptAnOdrStatus = ( this._stockSlipInputInitDataAcs.GetSalesTtlSt().SalesFormalIn == 0 ) ? 30 : 40;	// 受注ステータスは売上全体設定に従ってセット
			salesTempRow.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();	// 拠点コード
			salesTempRow.SubSectionCode = this._stockSlip.SubSectionCode;						// 部門コード
			//salesTempRow.MinSectionCode = this._stockSlip.MinSectionCode;						// 課コード
			
			//salesTempRow.DebitNoteDiv = this._stockSlip.DebitNoteDiv;						// 赤伝区分
			//salesTempRow.DebitNLnkAcptAnOdr = salesTempRow.DebitNLnkAcptAnOdr;						// 赤黒連結受注番号
			salesTempRow.SalesSlipCd = ( this._stockSlip.SupplierSlipCd == 10 ) ? 0 : 1;		// 売上伝票区分
			salesTempRow.AccRecDivCd = this._stockSlip.AccPayDivCd;							// 売掛区分
			salesTempRow.SupplierFormalSync = this._stockSlip.SupplierFormal;					// 仕入形式（同時）
			//salesTempRow.ServiceSlipCd = salesTempRow.ServiceSlipCd;									// サービス伝票区分
			salesTempRow.SalesInpSecCd = this._stockSlip.StockSectionCd.Trim();				// 売上入力拠点コード
			salesTempRow.DemandAddUpSecCd = this._stockSlip.StockAddUpSectionCd.Trim();		// 請求計上拠点コード
			salesTempRow.ResultsAddUpSecCd = this._stockSlip.StockSectionCd.Trim();			// 実績計上拠点コード
			salesTempRow.UpdateSecCd = this._stockSlip.SectionCode.Trim();						// 更新拠点コード
			salesTempRow.SearchSlipDate = DateTime.Today;										// 伝票検索日付
			salesTempRow.ShipmentDay = this._stockSlip.ArrivalGoodsDay;						// 出荷日付
			salesTempRow.SalesDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;	// 売上日付
			salesTempRow.AddUpADate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;	// 計上日付
			salesTempRow.DelayPaymentDiv = 0;													// 来勘区分
			salesTempRow.SalesInputCode = this._stockSlip.StockInputCode.Trim();				// 売上入力者コード
			salesTempRow.SalesInputName = this._stockSlip.StockInputName.Trim();				// 売上入力者名称
			//salesTempRow.FrontEmployeeCd = salesTempRow.FrontEmployeeCd;								// 受付従業員コード
			//salesTempRow.FrontEmployeeNm = salesTempRow.FrontEmployeeNm;								// 受付従業員名称
			salesTempRow.SalesEmployeeCd = this._stockSlip.StockAgentCode.Trim();				// 販売従業員コード
			salesTempRow.SalesEmployeeNm = this._stockSlip.StockAgentName.Trim();				// 販売従業員名称
			//salesTempRow.TotalAmountDispWayCd = 0;											// 総額表示方法区分
			//salesTempRow.TtlAmntDispRateApy = 0;												// 総額表示掛率適用区分
			//salesTempRow.ConsTaxLayMethod = 0;												// 消費税転嫁方式
			salesTempRow.ConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay); // 消費税税率
			//salesTempRow.FractionProcCd = 0;													// 端数処理区分
			//salesTempRow.AutoDepositCd = 0;													// 自動入金区分
			//salesTempRow.ClaimCode = stockDetailRow.ClaimCode;								// 請求先コード
			//salesTempRow.ClaimSnm = stockDetailRow.ClaimSnm;									// 請求先略称
			//salesTempRow.CustomerCode = stockDetailRow.CustomerCode;							// 得意先コード
			//salesTempRow.CustomerName = stockDetailRow.CustomerName;							// 得意先名称
			//salesTempRow.CustomerName2 = stockDetailRow.CustomerName2;						// 得意先名称2
			//salesTempRow.CustomerSnm = stockDetailRow.CustomerSnm;							// 得意先略称
			//salesTempRow.HonorificTitle = stockDetailRow.HonorificTitle;						// 敬称
			//salesTempRow.OutputNameCode = stockDetailRow.OutputNameCode;						// 諸口コード
			//salesTempRow.SlipAddressDiv = stockDetailRow.SlipAddressDiv;						// 伝票住所区分
			//salesTempRow.AddresseeCode = stockDetailRow.AddresseeCode;						// 納品先コード
			//salesTempRow.AddresseeName = stockDetailRow.AddresseeName;						// 納品先名称
			//salesTempRow.AddresseeName2 = stockDetailRow.AddresseeName2;						// 納品先名称2
			//salesTempRow.PostNo = stockDetailRow.PostNo;										// 郵便番号
			//salesTempRow.AddresseeAddr1 = stockDetailRow.AddresseeAddr1;						// 納品先住所1(都道府県市区郡・町村・字)
			//salesTempRow.AddresseeAddr2 = stockDetailRow.AddresseeAddr2;						// 納品先住所2(丁目)
			//salesTempRow.AddresseeAddr3 = stockDetailRow.AddresseeAddr3;						// 納品先住所3(番地)
			//salesTempRow.AddresseeAddr4 = stockDetailRow.AddresseeAddr4;						// 納品先住所4(アパート名称)
			//salesTempRow.AddresseeTelNo = stockDetailRow.AddresseeTelNo;						// 納品先電話番号
			//salesTempRow.OfficeFaxNo = stockDetailRow.OfficeFaxNo;							// FAX番号（勤務先）
			//salesTempRow.PartySaleSlipNum = stockDetailRow.PartySaleSlipNum;					// 相手先伝票番号
			//salesTempRow.SlipNote = stockDetailRow.SlipNote;									// 伝票備考
			//salesTempRow.SlipNote2 = stockDetailRow.SlipNote2;								// 伝票備考２
			//salesTempRow.RetGoodsReasonDiv = stockDetailRow.RetGoodsReasonDiv;				// 返品理由コード
			//salesTempRow.RetGoodsReason = stockDetailRow.RetGoodsReason;						// 返品理由
			//salesTempRow.CashRegisterNo = stockDetailRow.CashRegisterNo;						// レジ番号
			//salesTempRow.DetailRowCount = stockDetailRow.DetailRowCount;						// 明細行数
			//salesTempRow.BusinessTypeCode = stockDetailRow.BusinessTypeCode;					// 業種コード
			//salesTempRow.BusinessTypeName = stockDetailRow.BusinessTypeName;					// 業種名称
			//salesTempRow.DeliveredGoodsDiv = stockDetailRow.DeliveredGoodsDiv;				// 納品区分
			//salesTempRow.DeliveredGoodsDivNm = stockDetailRow.DeliveredGoodsDivNm;			// 納品区分名称
			//salesTempRow.SalesAreaCode = stockDetailRow.SalesAreaCode;						// 販売エリアコード
			//salesTempRow.SalesAreaName = stockDetailRow.SalesAreaName;						// 販売エリア名称
			//salesTempRow.ReconcileFlag = stockDetailRow.ReconcileFlag;						// 消込フラグ
			//salesTempRow.SlipPrtSetPaperId = stockDetailRow.SlipPrtSetPaperId;				// 伝票印刷設定用帳票ID
			//salesTempRow.CompleteCd = stockDetailRow.CompleteCd;								// 一式伝票区分
			//salesTempRow.ClaimType = stockDetailRow.ClaimType;								// 請求先区分
			//salesTempRow.SalesPriceFracProcCd = stockDetailRow.SalesPriceFracProcCd;			// 売上金額端数処理区分
			//salesTempRow.ListPricePrintDiv = stockDetailRow.ListPricePrintDiv;				// 定価印刷区分
			//salesTempRow.EraNameDispCd1 = stockDetailRow.EraNameDispCd1;						// 元号表示区分１
			//salesTempRow.SalesSlipCdDtl = stockDetailRow.SalesSlipCdDtl;						// 売上伝票区分（明細）
			//salesTempRow.SalesDepositsDiv = stockDetailRow.SalesDepositsDiv;					// 売上預り金区分
			//salesTempRow.DeliGdsCmpltDueDate = stockDetailRow.DeliGdsCmpltDueDate;			// 納品完了予定日
			salesTempRow.GoodsKindCode = stockDetailRow.GoodsKindCode;							// 商品属性
			salesTempRow.GoodsMakerCd = stockDetailRow.GoodsMakerCd;							//  商品メーカーコード
			salesTempRow.MakerName = stockDetailRow.MakerName;									// メーカー名称
			salesTempRow.GoodsNo = stockDetailRow.GoodsNo;										// 商品番号
			salesTempRow.GoodsName = stockDetailRow.GoodsName;									// 商品名称
			//salesTempRow.GoodsSetDivCd = stockDetailRow.GoodsSetDivCd;						// セット商品区分
			//salesTempRow.LargeGoodsGanreCode = stockDetailRow.LargeGoodsGanreCode;				// 商品区分グループコード
			//salesTempRow.LargeGoodsGanreName = stockDetailRow.LargeGoodsGanreName;				// 商品区分グループ名称
			//salesTempRow.MediumGoodsGanreCode = stockDetailRow.MediumGoodsGanreCode;			// 商品区分コード
			//salesTempRow.MediumGoodsGanreName = stockDetailRow.MediumGoodsGanreName;			// 商品区分名称
			//salesTempRow.DetailGoodsGanreCode = stockDetailRow.DetailGoodsGanreCode;			// 商品区分詳細コード
			//salesTempRow.DetailGoodsGanreName = stockDetailRow.DetailGoodsGanreName;			// 商品区分詳細名称
			salesTempRow.BLGoodsCode = stockDetailRow.BLGoodsCode;								// BL商品コード
			salesTempRow.BLGoodsFullName = stockDetailRow.BLGoodsFullName;						// BL商品コード名称（全角）
			salesTempRow.RateBLGoodsCode = stockDetailRow.RateBLGoodsCode;						// BL商品コード(掛率)
			salesTempRow.RateBLGoodsName = stockDetailRow.RateBLGoodsName;						// BL商品コード名称(掛率)
			salesTempRow.EnterpriseGanreCode = stockDetailRow.EnterpriseGanreCode;				// 自社分類コード
			salesTempRow.EnterpriseGanreName = stockDetailRow.EnterpriseGanreName;				// 自社分類名称
			salesTempRow.WarehouseCode = stockDetailRow.WarehouseCode;							// 倉庫コード
			salesTempRow.WarehouseName = stockDetailRow.WarehouseName;							// 倉庫名称
			salesTempRow.WarehouseShelfNo = stockDetailRow.WarehouseShelfNo;					// 倉庫棚番
			//salesTempRow.SalesOrderDivCd = stockDetailRow.SalesOrderDivCd;					// 売上在庫取寄せ区分
			//salesTempRow.UnitCode = stockDetailRow.UnitCode;									// 単位コード
			//salesTempRow.UnitName = stockDetailRow.UnitName;									// 単位名称
			salesTempRow.GoodsRateRank = stockDetailRow.GoodsRateRank;							// 商品掛率ランク
			salesTempRow.CustRateGrpCode = stockDetailRow.CustRateGrpCode;						// 得意先掛率グループコード
			//salesTempRow.SuppRateGrpCode = stockDetailRow.SuppRateGrpCode;						// 仕入先掛率グループコード
			salesTempRow.SuppRateGrpCode = this._stockSlip.SuppRateGrpCode;					// 仕入先掛率グループコード
			//salesTempRow.ListPriceRate = stockDetailRow.ListPriceRate;						// 定価率
			//salesTempRow.RateDivLPrice = stockDetailRow.RateDivLPrice;						// 掛率設定区分（定価）
			//salesTempRow.UnPrcCalcCdLPrice = stockDetailRow.UnPrcCalcCdLPrice;				// 単価算出区分（定価）
			//salesTempRow.PriceCdLPrice = stockDetailRow.PriceCdLPrice;						// 価格区分（定価）
			//salesTempRow.StdUnPrcLPrice = stockDetailRow.StdUnPrcLPrice;						// 基準単価（定価）
			//salesTempRow.FracProcUnitLPrice = stockDetailRow.FracProcUnitLPrice;				// 端数処理単位（定価）
			//salesTempRow.FracProcLPrice = stockDetailRow.FracProcLPrice;						// 端数処理（定価）
			//salesTempRow.ListPriceTaxIncFl = stockDetailRow.ListPriceTaxIncFl;				// 定価（税込，浮動）
			//salesTempRow.ListPriceTaxExcFl = stockDetailRow.ListPriceTaxExcFl;				// 定価（税抜，浮動）
			//salesTempRow.ListPriceChngCd = stockDetailRow.ListPriceChngCd;					// 定価変更区分
			//salesTempRow.SalesRate = stockDetailRow.SalesRate;								// 売価率
			//salesTempRow.RateDivSalUnPrc = stockDetailRow.RateDivSalUnPrc;					// 掛率設定区分（売上単価）
			//salesTempRow.UnPrcCalcCdSalUnPrc = stockDetailRow.UnPrcCalcCdSalUnPrc;			// 単価算出区分（売上単価）
			//salesTempRow.PriceCdSalUnPrc = stockDetailRow.PriceCdSalUnPrc;					// 価格区分（売上単価）
			//salesTempRow.StdUnPrcSalUnPrc = stockDetailRow.StdUnPrcSalUnPrc;					// 基準単価（売上単価）
			//salesTempRow.FracProcUnitSalUnPrc = stockDetailRow.FracProcUnitSalUnPrc;			// 端数処理単位（売上単価）
			//salesTempRow.FracProcSalUnPrc = stockDetailRow.FracProcSalUnPrc;					// 端数処理（売上単価）
			//salesTempRow.SalesUnPrcTaxIncFl = stockDetailRow.SalesUnPrcTaxIncFl;				// 売上単価（税込，浮動）
			//salesTempRow.SalesUnPrcTaxExcFl = stockDetailRow.SalesUnPrcTaxExcFl;				// 売上単価（税抜，浮動）
			//salesTempRow.SalesUnPrcChngCd = stockDetailRow.SalesUnPrcChngCd;					// 売上単価変更区分
			//salesTempRow.CostRate = stockDetailRow.CostRate;									// 原価率
			//salesTempRow.RateDivUnCst = stockDetailRow.RateDivUnCst;							// 掛率設定区分（原価単価）
			//salesTempRow.UnPrcCalcCdUnCst = stockDetailRow.UnPrcCalcCdUnCst;					// 単価算出区分（原価単価）
			//salesTempRow.PriceCdUnCst = stockDetailRow.PriceCdUnCst;							// 価格区分（原価単価）
			//salesTempRow.StdUnPrcUnCst = stockDetailRow.StdUnPrcUnCst;						// 基準単価（原価単価）
			//salesTempRow.FracProcUnitUnCst = stockDetailRow.FracProcUnitUnCst;				// 端数処理単位（原価単価）
			//salesTempRow.FracProcUnCst = stockDetailRow.FracProcUnCst;						// 端数処理（原価単価）
			//salesTempRow.SalesUnitCost = stockDetailRow.SalesUnitCost;						// 原価単価
			//salesTempRow.SalesUnitCostChngDiv = stockDetailRow.SalesUnitCostChngDiv;			// 原価単価変更区分
			//salesTempRow.BargainCd = stockDetailRow.BargainCd;									// 特売区分コード
			//salesTempRow.BargainNm = stockDetailRow.BargainNm;									// 特売区分名称
			salesTempRow.ShipmentCnt = stockDetailRow.StockCountDisplay;						// 出荷数
			//salesTempRow.SalesMoneyTaxInc = stockDetailRow.SalesMoneyTaxInc;					// 売上金額（税込み）
			//salesTempRow.SalesMoneyTaxExc = stockDetailRow.SalesMoneyTaxExc;					// 売上金額（税抜き）
			//salesTempRow.Cost = stockDetailRow.Cost;											// 原価
			//salesTempRow.GrsProfitChkDiv = stockDetailRow.GrsProfitChkDiv;					// 粗利チェック区分
			salesTempRow.TaxationDivCd = stockDetailRow.TaxationCode;							// 課税区分
			//salesTempRow.SalesGoodsCd = stockDetailRow.SalesGoodsCd;							// 売上商品区分
			//salesTempRow.PartySlipNumDtl = stockDetailRow.PartySlipNumDtl;					// 相手先伝票番号（明細）
			//salesTempRow.DtlNote = stockDetailRow.DtlNote;									// 明細備考
			//salesTempRow.SupplierCd = stockDetailRow.SupplierCd;								// 仕入先コード
			salesTempRow.SupplierCd = this._stockSlip.SupplierCd;								// 仕入先コード
			//salesTempRow.SupplierSnm = stockDetailRow.SupplierSnm;								// 仕入先略称
			salesTempRow.SupplierSnm = this._stockSlip.SupplierSnm;								// 仕入先略称
			salesTempRow.OrderNumber = stockDetailRow.OrderNumber;								// 発注番号
			//salesTempRow.AcceptAnOrderCnt = stockDetailRow.AcceptAnOrderCnt;					// 受注数量
			//salesTempRow.AcptAnOdrAdjustCnt = stockDetailRow.AcptAnOdrAdjustCnt;				// 受注調整数
			//salesTempRow.AcptAnOdrRemainCnt = stockDetailRow.AcptAnOdrRemainCnt;				// 受注残数
			//salesTempRow.SlipMemo1 = stockDetailRow.SlipMemo1;								// 伝票メモ１
			//salesTempRow.SlipMemo2 = stockDetailRow.SlipMemo2;								// 伝票メモ２
			//salesTempRow.SlipMemo3 = stockDetailRow.SlipMemo3;								// 伝票メモ３
			//salesTempRow.SlipMemo4 = stockDetailRow.SlipMemo4;								// 伝票メモ４
			//salesTempRow.SlipMemo5 = stockDetailRow.SlipMemo5;								// 伝票メモ５
			//salesTempRow.SlipMemo6 = stockDetailRow.SlipMemo6;								// 伝票メモ６
			//salesTempRow.InsideMemo1 = stockDetailRow.InsideMemo1;							// 社内メモ１
			//salesTempRow.InsideMemo2 = stockDetailRow.InsideMemo2;							// 社内メモ２
			//salesTempRow.InsideMemo3 = stockDetailRow.InsideMemo3;							// 社内メモ３
			//salesTempRow.InsideMemo4 = stockDetailRow.InsideMemo4;							// 社内メモ４
			//salesTempRow.InsideMemo5 = stockDetailRow.InsideMemo5;							// 社内メモ５
			//salesTempRow.InsideMemo6 = stockDetailRow.InsideMemo6;							// 社内メモ６
			//salesTempRow.BfListPrice = stockDetailRow.BfListPrice;							// 変更前定価
			//salesTempRow.BfSalesUnitPrice = stockDetailRow.BfSalesUnitPrice;					// 変更前売価
			//salesTempRow.BfUnitCost = stockDetailRow.BfUnitCost;								// 変更前原価
			//salesTempRow.PrtGoodsNo = stockDetailRow.PrtGoodsNo;								// 印刷用商品番号
			//salesTempRow.PrtGoodsName = stockDetailRow.PrtGoodsName;							// 印刷用商品名称
			salesTempRow.PrtGoodsMakerCd = stockDetailRow.GoodsMakerCd;						// 印刷用商品メーカーコード
			salesTempRow.PrtGoodsMakerNm = stockDetailRow.GoodsName;							// 印刷用商品メーカー名称
			salesTempRow.ConfirmedDiv = false;

			#endregion
		}

		/// <summary>
		/// 同時売上情報をキャッシュします。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		/// <param name="salesTemp">売上同時データオブジェクト</param>
		private void CacheSalesTemp( int stockRowNo, SalesTemp salesTemp )
		{
			StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(stockRowNo);

			#region ●項目セット

			salesTempRow.CreateDateTime = salesTemp.CreateDateTime;				// 作成日時
			salesTempRow.UpdateDateTime = salesTemp.UpdateDateTime;				// 更新日時
			salesTempRow.EnterpriseCode = salesTemp.EnterpriseCode;				// 企業コード
			//salesTempRow.FileHeaderGuid = salesTempRow.FileHeaderGuid;				// GUID
			salesTempRow.UpdEmployeeCode = salesTemp.UpdEmployeeCode;			// 更新従業員コード
			//salesTempRow.UpdAssemblyId1 = salesTempRow.UpdAssemblyId1;				// 更新アセンブリID1
			//salesTempRow.UpdAssemblyId2 = salesTempRow.UpdAssemblyId2;				// 更新アセンブリID2
			salesTempRow.LogicalDeleteCode = salesTemp.LogicalDeleteCode;		// 論理削除区分
			salesTempRow.AcptAnOdrStatus = salesTemp.AcptAnOdrStatus;			// 受注ステータス
			//salesTempRow.SalesSlipNum = salesTempRow.SalesSlipNum;					// 売上伝票番号
			salesTempRow.SectionCode = salesTemp.SectionCode;					// 拠点コード
			salesTempRow.SubSectionCode = salesTemp.SubSectionCode;				// 部門コード
			salesTempRow.MinSectionCode = salesTemp.MinSectionCode;				// 課コード
			salesTempRow.DebitNoteDiv = salesTemp.DebitNoteDiv;					// 赤伝区分
			//salesTempRow.DebitNLnkSalesSlNum = salesTempRow.DebitNLnkSalesSlNum;	// 赤黒連結売上伝票番号
			salesTempRow.SalesSlipCd = salesTemp.SalesSlipCd;					// 売上伝票区分
			salesTempRow.AccRecDivCd = salesTemp.AccRecDivCd;					// 売掛区分
			salesTempRow.SalesInpSecCd = salesTemp.SalesInpSecCd;				// 売上入力拠点コード
			salesTempRow.DemandAddUpSecCd = salesTemp.DemandAddUpSecCd;			// 請求計上拠点コード
			salesTempRow.ResultsAddUpSecCd = salesTemp.ResultsAddUpSecCd;		// 実績計上拠点コード
			salesTempRow.UpdateSecCd = salesTemp.UpdateSecCd;					// 更新拠点コード
			salesTempRow.SearchSlipDate = salesTemp.SearchSlipDate;				// 伝票検索日付
			salesTempRow.ShipmentDay = salesTemp.ShipmentDay;					// 出荷日付
			salesTempRow.SalesDate = salesTemp.SalesDate;						// 売上日付
			salesTempRow.AddUpADate = salesTemp.AddUpADate;						// 計上日付
			salesTempRow.DelayPaymentDiv = salesTemp.DelayPaymentDiv;			// 来勘区分
			salesTempRow.ClaimCode = salesTemp.ClaimCode;						// 請求先コード
			salesTempRow.ClaimSnm = salesTemp.ClaimSnm;							// 請求先略称
			salesTempRow.CustomerCode = salesTemp.CustomerCode;					// 得意先コード
			salesTempRow.CustomerName = salesTemp.CustomerName;					// 得意先名称
			salesTempRow.CustomerName2 = salesTemp.CustomerName2;				// 得意先名称2
			salesTempRow.CustomerSnm = salesTemp.CustomerSnm;					// 得意先略称
			salesTempRow.HonorificTitle = salesTemp.HonorificTitle;				// 敬称
			salesTempRow.OutputNameCode = salesTemp.OutputNameCode;				// 諸口コード
			salesTempRow.BusinessTypeCode = salesTemp.BusinessTypeCode;			// 業種コード
			salesTempRow.BusinessTypeName = salesTemp.BusinessTypeName;			// 業種名称
			salesTempRow.SalesAreaCode = salesTemp.SalesAreaCode;				// 販売エリアコード
			salesTempRow.SalesAreaName = salesTemp.SalesAreaName;				// 販売エリア名称
			salesTempRow.SalesInputCode = salesTemp.SalesInputCode;				// 売上入力者コード
			salesTempRow.SalesInputName = salesTemp.SalesInputName;				// 売上入力者名称
			salesTempRow.FrontEmployeeCd = salesTemp.FrontEmployeeCd;			// 受付従業員コード
			salesTempRow.FrontEmployeeNm = salesTemp.FrontEmployeeNm;			// 受付従業員名称
			salesTempRow.SalesEmployeeCd = salesTemp.SalesEmployeeCd;			// 販売従業員コード
			salesTempRow.SalesEmployeeNm = salesTemp.SalesEmployeeNm;			// 販売従業員名称
			salesTempRow.TotalAmountDispWayCd = salesTemp.TotalAmountDispWayCd;	// 総額表示方法区分
			salesTempRow.TtlAmntDispRateApy = salesTemp.TtlAmntDispRateApy;		// 総額表示掛率適用区分
			salesTempRow.ConsTaxLayMethod = salesTemp.ConsTaxLayMethod;			// 消費税転嫁方式
			salesTempRow.ConsTaxRate = salesTemp.ConsTaxRate;					// 消費税税率
			salesTempRow.FractionProcCd = salesTemp.FractionProcCd;				// 端数処理区分
			//salesTempRow.AccRecConsTax = salesTempRow.AccRecConsTax;				// 売掛消費税
			salesTempRow.AutoDepositCd = salesTemp.AutoDepositCd;				// 自動入金区分
			salesTempRow.AutoDepoSlipNum = salesTemp.AutoDepoSlipNum;			// 自動入金伝票番号
			//salesTempRow.DepositAllowanceTtl = salesTempRow.DepositAllowanceTtl;	// 入金引当合計額
			//salesTempRow.DepositAlwcBlnce = salesTempRow.DepositAlwcBlnce;			// 入金引当残高
			salesTempRow.SlipAddressDiv = salesTemp.SlipAddressDiv;				// 伝票住所区分
			salesTempRow.AddresseeCode = salesTemp.AddresseeCode;				// 納品先コード
			salesTempRow.AddresseeName = salesTemp.AddresseeName;				// 納品先名称
			salesTempRow.AddresseeName2 = salesTemp.AddresseeName2;				// 納品先名称2
			salesTempRow.AddresseePostNo = salesTemp.AddresseePostNo;			// 納品先郵便番号
			salesTempRow.AddresseeAddr1 = salesTemp.AddresseeAddr1;				// 納品先住所1(都道府県市区郡・町村・字)
			salesTempRow.AddresseeAddr2 = salesTemp.AddresseeAddr2;				// 納品先住所2(丁目)
			salesTempRow.AddresseeAddr3 = salesTemp.AddresseeAddr3;				// 納品先住所3(番地)
			salesTempRow.AddresseeAddr4 = salesTemp.AddresseeAddr4;				// 納品先住所4(アパート名称)
			salesTempRow.AddresseeTelNo = salesTemp.AddresseeTelNo;				// 納品先電話番号
			salesTempRow.AddresseeFaxNo = salesTemp.AddresseeFaxNo;				// 納品先FAX番号
			salesTempRow.PartySaleSlipNum = salesTemp.PartySaleSlipNum;			// 相手先伝票番号
			salesTempRow.SlipNote = salesTemp.SlipNote;							// 伝票備考
			salesTempRow.SlipNote2 = salesTemp.SlipNote2;						// 伝票備考２
			salesTempRow.RetGoodsReasonDiv = salesTemp.RetGoodsReasonDiv;		// 返品理由コード
			salesTempRow.RetGoodsReason = salesTemp.RetGoodsReason;				// 返品理由
			salesTempRow.DetailRowCount = salesTemp.DetailRowCount;				// 明細行数
			salesTempRow.DeliveredGoodsDiv = salesTemp.DeliveredGoodsDiv;		// 納品区分
			salesTempRow.DeliveredGoodsDivNm = salesTemp.DeliveredGoodsDivNm;	// 納品区分名称
			salesTempRow.ReconcileFlag = salesTemp.ReconcileFlag;				// 消込フラグ
			salesTempRow.SlipPrtSetPaperId = salesTemp.SlipPrtSetPaperId;		// 伝票印刷設定用帳票ID
			salesTempRow.CompleteCd = salesTemp.CompleteCd;						// 一式伝票区分
			salesTempRow.ClaimType = salesTemp.ClaimType;						// 請求先区分
			salesTempRow.SalesPriceFracProcCd = salesTemp.SalesPriceFracProcCd;	// 売上金額端数処理区分
			salesTempRow.ListPricePrintDiv = salesTemp.ListPricePrintDiv;		// 定価印刷区分
			salesTempRow.EraNameDispCd1 = salesTemp.EraNameDispCd1;				// 元号表示区分１
			salesTempRow.CommonSeqNo = salesTemp.CommonSeqNo;					// 共通通番
			salesTempRow.SalesSlipDtlNum = salesTemp.SalesSlipDtlNum;			// 売上明細通番
			salesTempRow.AcptAnOdrStatusSrc = salesTemp.AcptAnOdrStatusSrc;		// 受注ステータス（元）
			salesTempRow.SalesSlipDtlNumSrc = salesTemp.SalesSlipDtlNumSrc;		// 売上明細通番（元）
			salesTempRow.SupplierFormalSync = salesTemp.SupplierFormalSync;		// 仕入形式（同時）
			salesTempRow.StockSlipDtlNumSync = salesTemp.StockSlipDtlNumSync;	// 仕入明細通番（同時）
			salesTempRow.SalesSlipCdDtl = salesTemp.SalesSlipCdDtl;				// 売上伝票区分（明細）
			salesTempRow.StockMngExistCd = salesTemp.StockMngExistCd;			// 在庫管理有無区分
			salesTempRow.DeliGdsCmpltDueDate = salesTemp.DeliGdsCmpltDueDate;	// 納品完了予定日
			salesTempRow.GoodsKindCode = salesTemp.GoodsKindCode;				// 商品属性
			salesTempRow.GoodsMakerCd = salesTemp.GoodsMakerCd;					// 商品メーカーコード
			salesTempRow.MakerName = salesTemp.MakerName;						// メーカー名称
			salesTempRow.GoodsNo = salesTemp.GoodsNo;							// 商品番号
			salesTempRow.GoodsName = salesTemp.GoodsName;						// 商品名称
			salesTempRow.GoodsShortName = salesTemp.GoodsShortName;				// 商品名称略称
			salesTempRow.GoodsSetDivCd = salesTemp.GoodsSetDivCd;				// セット商品区分
			salesTempRow.LargeGoodsGanreCode = salesTemp.LargeGoodsGanreCode;	// 商品区分グループコード
			salesTempRow.LargeGoodsGanreName = salesTemp.LargeGoodsGanreName;	// 商品区分グループ名称
			salesTempRow.MediumGoodsGanreCode = salesTemp.MediumGoodsGanreCode;	// 商品区分コード
			salesTempRow.MediumGoodsGanreName = salesTemp.MediumGoodsGanreName;	// 商品区分名称
			salesTempRow.DetailGoodsGanreCode = salesTemp.DetailGoodsGanreCode;	// 商品区分詳細コード
			salesTempRow.DetailGoodsGanreName = salesTemp.DetailGoodsGanreName;	// 商品区分詳細名称
			salesTempRow.BLGoodsCode = salesTemp.BLGoodsCode;					// BL商品コード
			salesTempRow.BLGoodsFullName = salesTemp.BLGoodsFullName;			// BL商品コード名称（全角）
			salesTempRow.EnterpriseGanreCode = salesTemp.EnterpriseGanreCode;	// 自社分類コード
			salesTempRow.EnterpriseGanreName = salesTemp.EnterpriseGanreName;	// 自社分類名称
			salesTempRow.WarehouseCode = salesTemp.WarehouseCode;				// 倉庫コード
			salesTempRow.WarehouseName = salesTemp.WarehouseName;				// 倉庫名称
			salesTempRow.WarehouseShelfNo = salesTemp.WarehouseShelfNo;			// 倉庫棚番
			salesTempRow.SalesOrderDivCd = salesTemp.SalesOrderDivCd;			// 売上在庫取寄せ区分
			salesTempRow.GoodsRateRank = salesTemp.GoodsRateRank;				// 商品掛率ランク
			salesTempRow.CustRateGrpCode = salesTemp.CustRateGrpCode;			// 得意先掛率グループコード
			salesTempRow.SuppRateGrpCode = salesTemp.SuppRateGrpCode;			// 仕入先掛率グループコード
			salesTempRow.ListPriceRate = salesTemp.ListPriceRate;				// 定価率
			salesTempRow.RateSectPriceUnPrc = salesTemp.RateSectPriceUnPrc;		// 掛率設定拠点（定価）
			salesTempRow.RateDivLPrice = salesTemp.RateDivLPrice;				// 掛率設定区分（定価）
			salesTempRow.UnPrcCalcCdLPrice = salesTemp.UnPrcCalcCdLPrice;		// 単価算出区分（定価）
			salesTempRow.PriceCdLPrice = salesTemp.PriceCdLPrice;				// 価格区分（定価）
			salesTempRow.StdUnPrcLPrice = salesTemp.StdUnPrcLPrice;				// 基準単価（定価）
			salesTempRow.FracProcUnitLPrice = salesTemp.FracProcUnitLPrice;		// 端数処理単位（定価）
			salesTempRow.FracProcLPrice = salesTemp.FracProcLPrice;				// 端数処理（定価）
			salesTempRow.ListPriceTaxIncFl = salesTemp.ListPriceTaxIncFl;		// 定価（税込，浮動）
			salesTempRow.ListPriceTaxExcFl = salesTemp.ListPriceTaxExcFl;		// 定価（税抜，浮動）
			salesTempRow.ListPriceChngCd = salesTemp.ListPriceChngCd;			// 定価変更区分
			salesTempRow.SalesRate = salesTemp.SalesRate;						// 売価率
			salesTempRow.RateSectSalUnPrc = salesTemp.RateSectSalUnPrc;			// 掛率設定拠点（売上単価）
			salesTempRow.RateDivSalUnPrc = salesTemp.RateDivSalUnPrc;			// 掛率設定区分（売上単価）
			salesTempRow.UnPrcCalcCdSalUnPrc = salesTemp.UnPrcCalcCdSalUnPrc;	// 単価算出区分（売上単価）
			salesTempRow.PriceCdSalUnPrc = salesTemp.PriceCdSalUnPrc;			// 価格区分（売上単価）
			salesTempRow.StdUnPrcSalUnPrc = salesTemp.StdUnPrcSalUnPrc;			// 基準単価（売上単価）
			salesTempRow.FracProcUnitSalUnPrc = salesTemp.FracProcUnitSalUnPrc;	// 端数処理単位（売上単価）
			salesTempRow.FracProcSalUnPrc = salesTemp.FracProcSalUnPrc;			// 端数処理（売上単価）
			salesTempRow.SalesUnPrcTaxIncFl = salesTemp.SalesUnPrcTaxIncFl;		// 売上単価（税込，浮動）
			salesTempRow.SalesUnPrcTaxExcFl = salesTemp.SalesUnPrcTaxExcFl;		// 売上単価（税抜，浮動）
			salesTempRow.SalesUnPrcChngCd = salesTemp.SalesUnPrcChngCd;			// 売上単価変更区分
			salesTempRow.CostRate = salesTemp.CostRate;							// 原価率
			salesTempRow.RateSectCstUnPrc = salesTemp.RateSectCstUnPrc;			// 掛率設定拠点（原価単価）
			salesTempRow.RateDivUnCst = salesTemp.RateDivUnCst;					// 掛率設定区分（原価単価）
			salesTempRow.UnPrcCalcCdUnCst = salesTemp.UnPrcCalcCdUnCst;			// 単価算出区分（原価単価）
			salesTempRow.PriceCdUnCst = salesTemp.PriceCdUnCst;					// 価格区分（原価単価）
			salesTempRow.StdUnPrcUnCst = salesTemp.StdUnPrcUnCst;				// 基準単価（原価単価）
			salesTempRow.FracProcUnitUnCst = salesTemp.FracProcUnitUnCst;		// 端数処理単位（原価単価）
			salesTempRow.FracProcUnCst = salesTemp.FracProcUnCst;				// 端数処理（原価単価）
			salesTempRow.SalesUnitCost = salesTemp.SalesUnitCost;				// 原価単価
			salesTempRow.SalesUnitCostChngDiv = salesTemp.SalesUnitCostChngDiv;	// 原価単価変更区分
			salesTempRow.RateBLGoodsCode = salesTemp.RateBLGoodsCode;			// BL商品コード（掛率）
			salesTempRow.RateBLGoodsName = salesTemp.RateBLGoodsName;			// BL商品コード名称（掛率）
			salesTempRow.ShipmentCnt = salesTemp.ShipmentCnt;					// 出荷数
			salesTempRow.AcceptAnOrderCnt = salesTemp.AcptAnOdrRemainCnt;		// 受注残
			salesTempRow.SalesMoneyTaxInc = salesTemp.SalesMoneyTaxInc;			// 売上金額（税込み）
			salesTempRow.SalesMoneyTaxExc = salesTemp.SalesMoneyTaxExc;			// 売上金額（税抜き）
			salesTempRow.Cost = salesTemp.Cost;									// 原価
			salesTempRow.GrsProfitChkDiv = salesTemp.GrsProfitChkDiv;			// 粗利チェック区分
			salesTempRow.SalesGoodsCd = salesTemp.SalesGoodsCd;					// 売上商品区分
			salesTempRow.SalsePriceConsTax = salesTemp.SalsePriceConsTax;		// 売上金額消費税額
			salesTempRow.TaxationDivCd = salesTemp.TaxationDivCd;				// 課税区分
			salesTempRow.PartySlipNumDtl = salesTemp.PartySlipNumDtl;			// 相手先伝票番号（明細）
			salesTempRow.DtlNote = salesTemp.DtlNote;							// 明細備考
			salesTempRow.SupplierCd = salesTemp.SupplierCd;						// 仕入先コード
			salesTempRow.SupplierSnm = salesTemp.SupplierSnm;					// 仕入先略称
			salesTempRow.SlipMemo1 = salesTemp.SlipMemo1;						// 伝票メモ１
			salesTempRow.SlipMemo2 = salesTemp.SlipMemo2;						// 伝票メモ２
			salesTempRow.SlipMemo3 = salesTemp.SlipMemo3;						// 伝票メモ３
			salesTempRow.SlipMemo4 = salesTemp.SlipMemo4;						// 伝票メモ４
			salesTempRow.SlipMemo5 = salesTemp.SlipMemo5;						// 伝票メモ５
			salesTempRow.SlipMemo6 = salesTemp.SlipMemo6;						// 伝票メモ６
			salesTempRow.InsideMemo1 = salesTemp.InsideMemo1;					// 社内メモ１
			salesTempRow.InsideMemo2 = salesTemp.InsideMemo2;					// 社内メモ２
			salesTempRow.InsideMemo3 = salesTemp.InsideMemo3;					// 社内メモ３
			salesTempRow.InsideMemo4 = salesTemp.InsideMemo4;					// 社内メモ４
			salesTempRow.InsideMemo5 = salesTemp.InsideMemo5;					// 社内メモ５
			salesTempRow.InsideMemo6 = salesTemp.InsideMemo6;					// 社内メモ６
			salesTempRow.BfListPrice = salesTemp.BfListPrice;					// 変更前定価
			salesTempRow.BfSalesUnitPrice = salesTemp.BfSalesUnitPrice;			// 変更前売価
			salesTempRow.BfUnitCost = salesTemp.BfUnitCost;						// 変更前原価
			salesTempRow.PrtGoodsNo = salesTemp.PrtGoodsNo;						// 印刷用商品番号
			salesTempRow.PrtGoodsName = salesTemp.PrtGoodsName;					// 印刷用商品名称
			salesTempRow.PrtGoodsMakerCd = salesTemp.PrtGoodsMakerCd;			// 印刷用商品メーカーコード
			salesTempRow.PrtGoodsMakerNm = salesTemp.PrtGoodsMakerNm;			// 印刷用商品メーカー名称
			salesTempRow.SupplierSlipCd = salesTemp.SupplierSlipCd;				// 仕入伝票区分
			salesTempRow.ConfirmedDiv = salesTemp.ConfirmedDiv;					// 確認区分

			#endregion
		}

		#endregion

		/// <summary>
		/// 仕入明細データテーブルの初期設定を行います。
		/// </summary>
		/// <param name="defaultRowCount">初期行数</param>
		public void StockDetailRowInitialSetting(int defaultRowCount)
		{
			this._stockDetailDataTable.BeginLoadData();
			//this._stockDetailDataTable.Rows.Clear();
			this.ClearDetailTables();
			this._stockDetailDBDataList.Clear();

			for (int i = 1; i <= defaultRowCount; i++)
			{
				StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.NewStockDetailRow();
				row.SupplierSlipNo = this._currentSupplierSlipNo;
				row.DtlRelationGuid = Guid.Empty;
				row.StockRowNo = i;

				this._stockDetailDataTable.AddStockDetailRow(row);
			}
			this._stockDetailDataTable.EndLoadData();
		}

        /// <summary>
        /// 仕入明細データの無効データを削除します。
        /// </summary>
        public void DeleteIinvalidStockDetailRow()
        {
            List<int> deleteStockRowNoList = new List<int>();
            foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            {
                if (string.IsNullOrEmpty(row.GoodsName))
                {
                    deleteStockRowNoList.Add(row.StockRowNo);
                }
            }

            // 仕入明細行削除処理
            this.DeleteStockDetailRow(deleteStockRowNoList, true);

        }

		/// <summary>
		/// ＤＢに保存する仕入データを調整します。
		/// </summary>
		public void AdjustStockSaveData()
		{
            this.DeleteIinvalidStockDetailRow();

			// 総額表示の場合、伝票合計消費税と明細の消費税合計の差異を調整する
			if (( this._stockSlip.SuppTtlAmntDspWayCd == 1 ) && ( ( this._stockSlip.StockGoodsCd == 0 ) || ( this._stockSlip.StockGoodsCd == 1 ) || ( this._stockSlip.StockGoodsCd == 6 ) ))
			{
				long stockTtlPricTaxInc = 0;	// 仕入金額計（税込み）
				long stockTtlPricTaxExc = 0;	// 仕入金額計（税抜き）
				long stockPriceConsTax = 0;		// 仕入金額消費税額
				long ttlItdedStcOutTax = 0;		// 仕入外税対象額合計
				long ttlItdedStcInTax = 0;		// 仕入内税対象額合計
				long ttlItdedStcTaxFree = 0;	// 仕入非課税対象額合計
				long stockOutTax = 0;			// 仕入金額消費税額（外税）
				long stckPrcConsTaxInclu = 0;	// 仕入金額消費税額（内税）
				long stckDisTtlTaxExc = 0;		// 仕入値引金額計（税抜き）
				long itdedStockDisOutTax = 0;	// 仕入値引外税対象額合計
				long itdedStockDisInTax = 0;	// 仕入値引内税対象額合計
				long itdedStockDisTaxFre = 0;	// 仕入値引非課税対象額合計
				long stockDisOutTax = 0;		// 仕入値引消費税額（外税）
				long stckDisTtlTaxInclu = 0;	// 仕入値引消費税額（内税）
				long balanceAdjust = 0;			// 残高調整額
				long taxAdjust = 0;				// 消費税合計額

				//int stockTaxFrcProcCd = this._customerInfoAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
				int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード

				this.CalculateStockTotalPrice(this._stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, this._stockSlip.SuppTtlAmntDspWayCd, this._stockSlip.SuppCTaxLayCd, out stockTtlPricTaxInc, out stockTtlPricTaxExc, out stockPriceConsTax, out ttlItdedStcOutTax, out ttlItdedStcInTax, out ttlItdedStcTaxFree, out stockOutTax, out stckPrcConsTaxInclu, out stckDisTtlTaxExc, out itdedStockDisOutTax, out itdedStockDisInTax, out itdedStockDisTaxFre, out stockDisOutTax, out stckDisTtlTaxInclu, out balanceAdjust, out taxAdjust);

				// 消費税の差異を計算：仕入金額消費税額（外税）+ 仕入金額消費税額（内税）+ 仕入値引消費税額（外税）+ 仕入値引消費税額（内税）- 仕入金額消費税額
				long differenceTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu - stockPriceConsTax;

				if (differenceTax != 0)
				{
					int targetRowCount = this.SelectStockDetailRows(string.Format("{0}<>{1}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone), this._stockDetailDataTable).Length;
					if (targetRowCount == 0) return;

					// 平均して振り分ける分
					long av = differenceTax / targetRowCount;

					// 先頭行から1円ずつ振り分ける行
					long adjustCount = Math.Abs(differenceTax % targetRowCount);

					int sign = ( differenceTax > 0 ) ? 1 : -1;

					foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
					{
						if (row.TaxationCode != (int)CalculateTax.TaxationCode.TaxNone)
						{
							row.StockPriceConsTax -= ( av + ( ( adjustCount > 0 ) ? sign : 0 ) );
							row.StockPriceTaxExc += ( av + ( ( adjustCount > 0 ) ? sign : 0 ) );
							adjustCount--;
						}
					}
					// 合計金額の再設定
					this.TotalPriceSetting(ref this._stockSlip, true);
				}
			}
		}

		#region 明細情報設定

		#region 商品・在庫関連
		/// <summary>
		/// 指定した商品、在庫情報のリストを元に、仕入明細データ行オブジェクトに商品、在庫情報を一括設定します。（在庫ベース）
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="stockList">商品情報オブジェクトリスト</param>
		/// <param name="goodsUnitDataList">在庫情報オブジェクトリスト</param>
		/// <param name="settingStockRowNoList">設定した仕入行番号のリスト</param>
        /// <param name="overWriteRow">true:行上書きあり false:行上書きなし</param>
        public void StockDetailRowGoodsSettingBasedOnStock( int stockRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingStockRowNoList, bool overWriteRow )
		{
			settingStockRowNoList = new List<int>();
			List<int> deletingStockRowNoList = new List<int>();

            int addRowCnt = goodsUnitDataList.Count;
            int stockRowNoWk = stockRowNo;
            while (addRowCnt > 0)
            {
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNoWk);

                try
                {
                    // 行が存在しない場合は新規に追加する
                    if (row == null)
                    {
                        this.AddStockDetailRow();

                        row = this.GetStockDetailRow(stockRowNoWk);
                    }
                    else
                    {
                        if (!overWriteRow)
                        {
                            if (this.ExistStockDetailInput(row))
                            {
                                continue;
                            }
                        }
                    }

                    settingStockRowNoList.Add(row.StockRowNo);

                    deletingStockRowNoList.Add(row.StockRowNo);

                    row.AcceptChanges();

                    addRowCnt--;
                }
                finally
                {
                    stockRowNoWk++;
                }
            }

			// 仕入明細行削除処理
			this.ClearStockDetailRow(deletingStockRowNoList);
			GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();
			for (int i = 0; i < stockList.Count; i++)
			{
				stock = stockList[i];
				int targetStockRowNo = settingStockRowNoList[i];
				goodsUnitData = this.GetGoodsUnitDataFromList(stock.GoodsNo, stock.GoodsMakerCd, goodsUnitDataList);

				// 商品、在庫情報設定処理
                this.StockDetailRowGoodsSetting(targetStockRowNo, goodsUnitData, stock);
			}
        }

		/// <summary>
		/// 指定した商品、在庫情報のリストを元に、仕入明細データ行オブジェクトに商品、在庫情報を一括設定します。（商品ベース）
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="goodsUnitDataList">商品情報オブジェクトリスト</param>
		/// <param name="settingStockRowNoList">設定した仕入行番号のリスト</param>
        /// <param name="overWriteRow">true:行上書きあり false:行上書きなし</param>
        public void StockDetailRowGoodsSettingBasedOnGoodsUnitData( int stockRowNo, List<GoodsUnitData> goodsUnitDataList, out List<int> settingStockRowNoList, bool overWriteRow )
		{
			settingStockRowNoList = new List<int>();
			List<int> deletingStockRowNoList = new List<int>();
			List<int> goodsDiscountRowList = new List<int>();

            int addRowCnt = goodsUnitDataList.Count;
            int stockRowNoWk = stockRowNo;
            while (addRowCnt > 0)
            {
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNoWk);

                try
                {
                    // 行が存在しない場合は新規に追加する
                    if (row == null)
                    {
                        this.AddStockDetailRow();

                        row = this.GetStockDetailRow(stockRowNoWk);
                    }
                    else
                    {
                        if (!overWriteRow)
                        {
                            if (this.ExistStockDetailInput(row))
                            {
                                continue;
                            }
                        }
                    }

                    settingStockRowNoList.Add(row.StockRowNo);

                    deletingStockRowNoList.Add(row.StockRowNo);

                    if (row.StockSlipCdDtl == 2) goodsDiscountRowList.Add(row.StockRowNo);

                    row.AcceptChanges();

                    addRowCnt--;
                }
                finally
                {
                    stockRowNoWk++;
                }
            }

            // 検索対象倉庫配列を取得
            string[] warehouseCodeArray = this.GetSearchWarehouseArray();

			// 仕入明細行削除処理
			this.ClearStockDetailRow(deletingStockRowNoList);
			GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();
			for (int i = 0; i < goodsUnitDataList.Count; i++)
			{
				goodsUnitData = goodsUnitDataList[i];

                // 2009.04.03 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //stock = ( ( warehouseCodeArray != null ) && ( warehouseCodeArray.Length > 0 ) ) ? this._stockSlipInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray) : null;
                if (goodsUnitData.SelectedWarehouseCode != null)
                {
                    stock = this._stockSlipInputInitDataAcs.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim());
                }
                else
                {
                    stock = ((warehouseCodeArray != null) && (warehouseCodeArray.Length > 0)) ? this._stockSlipInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray) : null;
                }
                // 2009.04.03 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                int targetStockRowNo = settingStockRowNoList[i];

				int stockSlipCdDtl = ( goodsDiscountRowList.Contains(settingStockRowNoList[i]) ) ? 2 : 0;

				// 商品、在庫情報設定処理
                this.StockDetailRowGoodsSetting(targetStockRowNo, goodsUnitData, stock, stockSlipCdDtl);
			}
		}

		/// <summary>
		/// 指定した商品情報オブジェクトを元に、仕入明細データ行オブジェクトに商品情報を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="goodsUnitData">商品情報オブジェクト</param>
		public void StockDetailRowGoodsSetting( int stockRowNo, GoodsUnitData goodsUnitData)
		{
			this.StockDetailRowGoodsSetting(stockRowNo, goodsUnitData, null);
		}

		/// <summary>
		/// 指定した商品情報オブジェクトを元に、仕入明細データ行オブジェクトに商品情報を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="goodsUnitData">商品情報オブジェクト</param>
		/// <param name="stock">在庫情報オブジェクト</param>
		/// <param name="stockSlipCdDtl">仕入伝票区分(明細)</param>
        private void StockDetailRowGoodsSetting( int stockRowNo, GoodsUnitData goodsUnitData, Stock stock, int stockSlipCdDtl )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			List<int> deleteRowNoList = new List<int>();

            if (row != null)
            {
                this.ClearStockDetailRow(row);

                row.StockSlipCdDtl = stockSlipCdDtl;

                if (goodsUnitData == null)
                {
                    //
                }
                else
                {
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
                    row.TaxationCode = goodsUnitData.TaxationDivCd;                     // 課税区分
                    row.GoodsOfferDate = goodsUnitData.OfferDate;                       // 提供日
                    row.TaxDiv = row.TaxationCode;                                      // 課税区分（表示）

                    if (row.StockSlipCdDtl == 2)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;                    // 変更可能ステータス
                    }
                    else
                    {
                        row.EditStatus = ctEDITSTATUS_AllOK;                            // 変更可能ステータス
                    }

                    int sign = ( row.StockSlipCdDtl == 2 ) ? -1 : 1;
                    row.StockCountDisplay = 1 * sign;
                    sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
                    row.StockCount = row.StockCountDisplay * sign;
                    row.OrderCnt = row.StockCount;

                    row.OrderRemainCnt = ( this._stockSlip.SupplierFormal == 0 ) ? 0 : row.StockCountDisplay;

                    // 在庫情報
                    if (stock != null)
                    {
                        this.CacheStockInfo(stock);

                        row.WarehouseCode = stock.WarehouseCode.Trim();
                        row.WarehouseName = stock.WarehouseName;
                        row.WarehouseShelfNo = stock.WarehouseShelfNo;
                    }
                    else
                    {
                        row.ShipmentPosCnt = 0;
                        row.ShipmentPosCntDisplay = row.ShipmentPosCnt;
                    }

                    // 品番、メーカーが入っている場合は単価算出モジュールで原価計算
                    if (( goodsUnitData.GoodsMakerCd != 0 ) && ( !string.IsNullOrEmpty(goodsUnitData.GoodsNo) ))
                    {
                        this.StockDetailRowGoodsPriceSetting(row, goodsUnitData);
                    }

                    // 商品情報キャッシュ
                    this.CacheGoodsUnitData(goodsUnitData);

                    //if (( goodsUnitData.GoodsOfferCd == 0 ) && ( goodsUnitData.CreateDateTime != DateTime.MinValue ))
                    //{
                    //    row.CanTaxDivChange = false;		// 課税非課税区分変更可能フラグ
                    //}
                    //else
                    //{
                    //    row.CanTaxDivChange = true;			// 課税非課税区分変更可能フラグ
                    //}
                }
            }

			// セット親商品の場合は子商品行をクリアする
			if (deleteRowNoList.Count > 0)
			{
				this.DeleteStockDetailRow(deleteRowNoList, true);
			}
		}

		/// <summary>
		/// 指定した商品情報オブジェクトを元に、仕入明細データ行オブジェクトに商品情報を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="goodsUnitData">商品情報オブジェクト</param>
		/// <param name="stock">在庫情報オブジェクト</param>
        private void StockDetailRowGoodsSetting( int stockRowNo, GoodsUnitData goodsUnitData, Stock stock )
        {
            this.StockDetailRowGoodsSetting(stockRowNo, goodsUnitData, stock, 0);
        }

		/// <summary>
		/// 指定した単価情報画面の結果情報を元に、仕入明細データ行オブジェクトに単価情報を設定します。
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		/// <param name="unPrcInfoConfRet">単価情報確認画面結果オブジェクト</param>
		public void StockDetailRowUnPrcInfoSetting( int stockRowNo, UnPrcInfoConfRet unPrcInfoConfRet )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				row.UnPrcCalcCdStckUnPrc = unPrcInfoConfRet.UnitPrcCalcDiv;		// 単価算出区分
				//row.PriceCdStckUnPrc = unPrcInfoConfRet.PriceDiv;				// 価格区分
				row.StockRate = unPrcInfoConfRet.RateVal;						// 掛率
				row.FracProcUnitStcUnPrc = unPrcInfoConfRet.UnPrcFracProcUnit;	// 単価端数処理単位
				row.FracProcStckUnPrc = unPrcInfoConfRet.UnPrcFracProcDiv;		// 単価端数処理区分
				row.StdUnPrcStckUnPrc = unPrcInfoConfRet.StdUnitPrice;			// 基準単価
				//row.PriceDisplay = unPrcInfoConfRet.UnitPriceFl;		// 単価（浮動）
				this.StockDetailRowListPriceSetting(row, null);
                this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceDisplay, row.StockUnitPriceDisplay);
			}
		}

		/// <summary>
		/// 指定した在庫情報オブジェクトを元に、仕入明細データ行オブジェクトに在庫情報を設定します。
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		/// <param name="stockList">在庫リスト</param>
        public void StockDetailRowStockSetting( int stockRowNo, List<Stock> stockList )
		{

            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                Stock stock = null;

                foreach (Stock stockWk in stockList)
                {
                    if (row.WarehouseCode.Trim() == stockWk.WarehouseCode.Trim())
                    {
                        stock = stockWk;
                        break;
                    }
                }

                this.StockDetailRowStockSetting(row, stock);
            }
		}

        /// <summary>
        /// 指定した在庫情報オブジェクトを元に、仕入明細データ行オブジェクトに在庫情報を設定します。
        /// </summary>
        /// <param name="stockRowNo">行番号</param>
        /// <param name="stock">在庫オブジェクト</param>
        public void StockDetailRowStockSetting( int stockRowNo, Stock stock )
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                this.StockDetailRowStockSetting(row, stock);
            }
        }

        /// <summary>
        /// 指定した在庫情報オブジェクトを元に、仕入明細データ行オブジェクトに在庫情報を設定します。
        /// </summary>
        /// <param name="row">仕入明細行オブジェクト</param>
        /// <param name="stock">在庫オブジェクト</param>
        private void StockDetailRowStockSetting( StockInputDataSet.StockDetailRow row, Stock stock )
        {
            if (row != null)
            {
                if (stock != null)
                {
                    // 在庫のキャッシュ
                    this.CacheStockInfo(stock);

                    row.WarehouseCode = stock.WarehouseCode.Trim();
                    row.WarehouseName = stock.WarehouseName;
                    row.WarehouseShelfNo = stock.WarehouseShelfNo.Trim();

                    this.StockDetailStockInfoAdjust(row.WarehouseCode, row.GoodsNo, row.GoodsMakerCd);
                }
                else
                {
                    row.WarehouseCode = string.Empty;
                    row.WarehouseName = string.Empty;
                    row.WarehouseShelfNo = string.Empty;
                    row.ShipmentPosCnt = 0;
                    row.ShipmentPosCntDisplay = 0;
                }
            }
        }

		/// <summary>
		/// 指定した行の在庫情報をクリアします。
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		public void StockDetailRowClearStockInfo( int stockRowNo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				string goodsNo = row.GoodsNo;
				string warehouseCode = row.WarehouseCode.Trim();
				int goodsmakerCode = row.GoodsMakerCd;

				row.WarehouseCode = string.Empty;
				row.WarehouseName = string.Empty;
				row.WarehouseShelfNo = string.Empty;
				row.ShipmentPosCnt = 0;
				row.ShipmentPosCntDisplay = 0;

				if (( !string.IsNullOrEmpty(warehouseCode) ) && ( !string.IsNullOrEmpty(goodsNo) ) && ( goodsmakerCode != 0 ))
				{
					this.StockDetailStockInfoAdjust(warehouseCode, goodsNo, goodsmakerCode);
				}
			}
		}

		/// <summary>
		/// 空商品情報設定
		/// </summary>
		/// <param name="goodsNo">商品コード</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="goodsMakerCd">メーカーコード</param>
		public GoodsUnitData CreateEmptyGoods( string goodsNo, string goodsName, int goodsMakerCd )
		{
			GoodsUnitData retGoodsUnitData = new GoodsUnitData();
			retGoodsUnitData.GoodsNo = goodsNo;
			retGoodsUnitData.GoodsName = goodsName;
			retGoodsUnitData.GoodsMakerCd = goodsMakerCd;

            string makerName, makerKanaName;
            this._stockSlipInputInitDataAcs.GetName_FromMaker(goodsMakerCd, out makerName, out makerKanaName);
            retGoodsUnitData.MakerName = makerName;
            retGoodsUnitData.MakerKanaName = makerKanaName;

			return retGoodsUnitData;
		}
		#endregion

		/// <summary>
		/// 仕入履歴照会ワークオブジェクトリストを元に、仕入明細データ行オブジェクトに商品、在庫情報、同時売上情報を一括設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="stcHisRefDataWorkList">仕入履歴照会ワークオブジェクトリスト</param>
		/// <param name="wayToDetailExpand">明細展開方法</param>
		/// <param name="memoMoveDiv">メモ複写区分</param>
		/// <param name="settingRowNoList">設定行リスト</param>
		/// <returns>読み込みステータス</returns>
		public int StockDetailRowSettingFromstcHisRefDataWorkList( int stockRowNo, List<StcHisRefDataWork> stcHisRefDataWorkList, WayToDetailExpand wayToDetailExpand, MemoMoveDiv memoMoveDiv, out List<int> settingRowNoList )
		{
			ArrayList arrayList = new ArrayList();
			settingRowNoList = new List<int>();

			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			CustomSerializeArrayList paraList = new CustomSerializeArrayList();

			paraList.Add(iOWriteCtrlOptWork);

			foreach (StcHisRefDataWork stcHisRefDataWork in stcHisRefDataWorkList)
			{
				StockDetailWork stockDetailWork = new StockDetailWork();
				stockDetailWork.EnterpriseCode = stcHisRefDataWork.EnterpriseCode;
				stockDetailWork.SupplierFormal = stcHisRefDataWork.SupplierFormal;
				stockDetailWork.StockSlipDtlNum = stcHisRefDataWork.StockSlipDtlNum;
				paraList.Add(stockDetailWork);
			}

			object paraObj = (object)paraList;
			object retObj = null;
			object retObj2 = null;

            if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
			int status = this._iIOWriteControlDB.ReadDetail(ref paraObj, out retObj, out retObj2);

			CustomSerializeArrayList retList = ( ( retObj != null ) && ( retObj is CustomSerializeArrayList ) ) ? (CustomSerializeArrayList)retObj : null;
			CustomSerializeArrayList retList2 = ( ( retObj2 != null ) && ( retObj2 is CustomSerializeArrayList ) ) ? (CustomSerializeArrayList)retObj2 : null;

            if (( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ) && ( retList2 == null ))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

			if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) ||
				( status == -999 ))
			{
				StockDetailWork[] stockDetailWorkArray;
				SalesSlipWork[] salesSlipWorkArray = null;
				SalesDetailWork[] salesDetailWorkArray = null;

                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForDetailsReadingResult(retList, retList2, out stockDetailWorkArray, out salesSlipWorkArray, out salesDetailWorkArray);

				this.StockDetailRowSettingFromStockDetailWorkArray(stockRowNo, stockDetailWorkArray, salesSlipWorkArray, salesDetailWorkArray, wayToDetailExpand, memoMoveDiv, out settingRowNoList);
			}
			return status;
		}

		/// <summary>
		/// 発注残照会ワークオブジェクトリストを元に、仕入明細データ行オブジェクトに商品、在庫情報、同時売上情報を一括設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="orderListResultWorkList">発注残照会ワークオブジェクトリスト</param>
		/// <param name="wayToDetailExpand">明細展開方法</param>
		/// <param name="memoMoveDiv">メモ複写区分</param>
		/// <param name="settingStockRowNoList">設定した仕入明細行リスト</param>
		/// <returns>読み込みステータス</returns>
		public int StockDetailRowSettingFromOrderListResultWorkList( int stockRowNo, List<OrderListResultWork> orderListResultWorkList, WayToDetailExpand wayToDetailExpand, MemoMoveDiv memoMoveDiv, out List<int> settingStockRowNoList )
		{
			ArrayList arrayList = new ArrayList();
			settingStockRowNoList = new List<int>();

			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			CustomSerializeArrayList paraList = new CustomSerializeArrayList();

			paraList.Add(iOWriteCtrlOptWork);

			foreach (OrderListResultWork orderListResultWork in orderListResultWorkList)
			{
				StockDetailWork stockDetailWork = new StockDetailWork();
				stockDetailWork.EnterpriseCode = this._enterpriseCode;
				stockDetailWork.SupplierFormal = orderListResultWork.SupplierFormal;
				stockDetailWork.StockSlipDtlNum = orderListResultWork.StockSlipDtlNum;
				paraList.Add(stockDetailWork);
			}

			object paraObj = (object)paraList;
			object retObj = null;
			object retObj2 = null;

            if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
			int status = this._iIOWriteControlDB.ReadDetail(ref paraObj, out retObj, out retObj2);

			CustomSerializeArrayList retList = ( ( retObj != null ) && ( retObj is CustomSerializeArrayList ) ) ? (CustomSerializeArrayList)retObj : null;
			CustomSerializeArrayList retList2 = ( ( retObj2 != null ) && ( retObj2 is CustomSerializeArrayList ) ) ? (CustomSerializeArrayList)retObj2 : null;

            if (( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ) && ( retList2 == null ))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

			if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) ||
				(status == -999))
			{

				StockDetailWork[] stockDetailWorkArray;
				SalesSlipWork[] salesSlipWorkArray = null;
				SalesDetailWork[] salesDetailWorkArray = null;

                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForDetailsReadingResult(retList, retList2, out stockDetailWorkArray, out salesSlipWorkArray, out salesDetailWorkArray);

				this.StockDetailRowSettingFromStockDetailWorkArray(stockRowNo, stockDetailWorkArray, salesSlipWorkArray, salesDetailWorkArray, wayToDetailExpand, memoMoveDiv, out settingStockRowNoList);
			}

			return status;
		}

		/// <summary>
		/// 仕入明細ワークオブジェクト配列を元に、仕入明細データ行オブジェクトに商品、在庫情報を一括設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="stockDetailWorkArray">仕入明細ワークオブジェクト配列</param>
		/// <param name="salesSlipWorkArray">売上データオブジェクト配列</param>
		/// <param name="salesDetailWorkArray">売上明細ワークオブジェクト配列</param>
		/// <param name="wayToDetailExpand">明細展開方法</param>
		/// <param name="memoMoveDiv">メモ複写区分</param>
		/// <param name="settingStockRowNoList">設定した仕入明細行番号リスト</param>
        public void StockDetailRowSettingFromStockDetailWorkArray(int stockRowNo, StockDetailWork[] stockDetailWorkArray, SalesSlipWork[] salesSlipWorkArray, SalesDetailWork[] salesDetailWorkArray, WayToDetailExpand wayToDetailExpand, MemoMoveDiv memoMoveDiv, out List<int> settingStockRowNoList)
		{
			settingStockRowNoList = new List<int>();

			List<StockDetail> stockDetailList = ConvertStockSlip.UIDataFromParamData(stockDetailWorkArray);

            List<Stock> stockList = this.SearchStock(stockDetailList);

			List<int> deletingStockRowNoList = new List<int>();

			bool isAddUp = ( wayToDetailExpand != WayToDetailExpand.Normal );

            //stockRowNo = 1; // 2009.04.13
            int addRowCnt = stockDetailList.Count;

            for (int index = 0; index < this._stockDetailDataTable.Rows.Count; index++)
            {
                // 2009.04.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //StockInputDataSet.StockDetailRow row = this._stockDetailDataTable[index];
                //if (this.ExistStockDetailInput(row))
                //{
                //    continue;
                //}
                StockInputDataSet.StockDetailRow row = null;
                if (wayToDetailExpand != WayToDetailExpand.AddUpRemainder)
                {
                    row = this._stockDetailDataTable[index];
                    if (this.ExistStockDetailInput(row)) continue;
                }
                else
                {
                    // 残検索は入力位置に展開
                    row = this._stockDetailDataTable[stockRowNo - 1 + index];
                    // 残検索時は品番入力されている
                    if (!string.IsNullOrEmpty(row.GoodsName)) continue;
                }
                // 2009.04.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                settingStockRowNoList.Add(row.StockRowNo);

                deletingStockRowNoList.Add(row.StockRowNo);

                row.AcceptChanges();

                addRowCnt--;
                if (addRowCnt == 0) break;
            }

			// 仕入明細行削除処理
			this.ClearStockDetailRow(deletingStockRowNoList);

			GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();

			for (int i = 0; i < stockDetailList.Count; i++)
			{
				stock = null;
                foreach (Stock stockWk in stockList)
				{
					if (( stockDetailList[i].GoodsNo == stockWk.GoodsNo ) &&
						( stockDetailList[i].GoodsMakerCd == stockWk.GoodsMakerCd ) &&
						( stockDetailList[i].WarehouseCode.Trim() == stockWk.WarehouseCode.Trim() ))
					{
						stock = stockWk;
						break;
					}

				}
				int targetStockRowNo = settingStockRowNoList[i];

				// 明細情報設定処理
				this.StockDetailRowSettingFromStockDetail(targetStockRowNo, stockDetailList[i], stock, isAddUp, memoMoveDiv);
                this.CacheStockInfo(stock);
#if false
				// 同時入力データの展開
				if (wayToDetailExpand == WayToDetailExpand.AddUpAndSync)
				{
					if (( ( stockDetailList[i].SalesSlipDtlNumSync != 0 ) && ( stockDetailList[i].AcptAnOdrStatusSync != 0 ) ) &&
						( ( salesSlipWorkArray != null ) && ( salesDetailWorkArray != null ) ))
					{
						SalesSlipWork addUpOrgSalesSlipWork = null;
						SalesDetailWork addUpOrgSalesDetailWork = null;

						foreach (SalesDetailWork salesDetailWork in salesDetailWorkArray)
						{
							// 受注ステータス(同時),売上明細通番(同時)が同じデータを抽出する
							if (( stockDetailList[i].AcptAnOdrStatusSync == salesDetailWork.AcptAnOdrStatus ) &&
								( stockDetailList[i].SalesSlipDtlNumSync == salesDetailWork.SalesSlipDtlNum ))
							{
								addUpOrgSalesDetailWork = salesDetailWork;
								break;
							}
						}

						if (addUpOrgSalesDetailWork != null)
						{
							foreach (SalesSlipWork salesSlipWork in salesSlipWorkArray)
							{
								if (( addUpOrgSalesDetailWork.SalesSlipNum == salesSlipWork.SalesSlipNum ) &&
									( addUpOrgSalesDetailWork.AcptAnOdrStatus == salesSlipWork.AcptAnOdrStatus ))
								{
									addUpOrgSalesSlipWork = salesSlipWork;
									break;
								}
							}
						}

						if (( addUpOrgSalesSlipWork != null ) && ( addUpOrgSalesDetailWork != null ))
						{
							this.SyncSalesInfoSetting(targetStockRowNo, addUpOrgSalesSlipWork, addUpOrgSalesDetailWork, memoMoveDiv);
						}
					}
				}
#endif
			}
		}

		/// <summary>
		/// 同時売上情報設定処理
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="salesSlipWork">売上データワークオブジェクト</param>
		/// <param name="salesDetailWork">売上明細ワークオブジェクト</param>
		/// <param name="memoMoveDiv">メモ複写区分</param>
		private void SyncSalesInfoSetting( int stockRowNo, SalesSlipWork salesSlipWork, SalesDetailWork salesDetailWork, MemoMoveDiv memoMoveDiv )
		{
			// 受注残がゼロのデータは無条件で対象外
			if (salesDetailWork.AcptAnOdrRemainCnt == 0)
			{
				return;
			}

            StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);
			stockDetailRow.SalesCustomerCode = salesSlipWork.CustomerCode;
			stockDetailRow.SalesCustomerSnm = salesSlipWork.CustomerSnm;
			
			if (stockDetailRow!= null)
			{
				#region ●売上データ(仕入同時計上)への項目セット

				SalesTemp salesTemp = ConvertStockSlip.UIDataFromParamData(salesSlipWork, salesDetailWork);

				// 請求先情報を取得する
				salesTemp.CreateDateTime = DateTime.MinValue;
				salesTemp.UpdateDateTime = DateTime.MinValue;
				salesTemp.FileHeaderGuid = Guid.Empty;
				salesTemp.LogicalDeleteCode = 0;

                //salesTemp.AcptAnOdrStatus = ( this._stockSlipInputInitDataAcs.GetSalesTtlSt().SalesFormalIn == 0 ) ? 30 : 40;	// 受注ステータスは売上全体設定に従ってセット
				salesTemp.SalesSlipDtlNum = 0;

				salesTemp.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim(); // 拠点コード
				salesTemp.SubSectionCode = this._stockSlip.SubSectionCode;                      // 部門コード
				salesTemp.SupplierFormalSync = 0;                                               // 仕入形式(同時入力)
				salesTemp.StockSlipDtlNumSync = 0;                                              // 仕入明細通番(同時入力)
				salesTemp.AcptAnOdrStatusSrc = salesDetailWork.AcptAnOdrStatus;                 // 受注ステータス(計上元)
				salesTemp.SalesSlipDtlNumSrc = salesDetailWork.SalesSlipDtlNum;                 // 売上明細通番(計上元)
				salesTemp.CommonSeqNo = salesDetailWork.CommonSeqNo;                            // 共通通番
				salesTemp.AcceptAnOrderNo = salesDetailWork.AcceptAnOrderNo;                    // 受注番号
				salesTemp.SupplierSlipCd = this._stockSlip.SupplierSlipCd;                      // 仕入伝票区分

				salesTemp.DebitNoteDiv = this._stockSlip.DebitNoteDiv;                          // 赤伝区分
				salesTemp.DebitNLnkAcptAnOdr = 0;                                               // 赤黒連結受注番号
				salesTemp.SalesSlipCd = ( this._stockSlip.SupplierSlipCd == 10 ) ? 0 : 1;       // 売上伝票区分
				salesTemp.AccRecDivCd = this._stockSlip.AccPayDivCd;                            // 売掛区分
				salesTemp.SupplierFormalSync = this._stockSlip.SupplierFormal;                  // 仕入形式（同時）
				//salesTemp.ServiceSlipCd = 0;                                                  // サービス伝票区分
				salesTemp.PartySaleSlipNum = string.Empty;
				salesTemp.SalesInpSecCd = this._stockSlip.StockSectionCd.Trim();                // 売上入力拠点コード
				salesTemp.DemandAddUpSecCd = this._stockSlip.StockAddUpSectionCd.Trim();        // 請求計上拠点コード
				salesTemp.ResultsAddUpSecCd = this._stockSlip.StockSectionCd.Trim();            // 実績計上拠点コード
				salesTemp.UpdateSecCd = this._stockSlip.SectionCode.Trim();                     // 更新拠点コード
				salesTemp.SearchSlipDate = DateTime.Today;                                      // 伝票検索日付
				salesTemp.ShipmentDay = this._stockSlip.ArrivalGoodsDay;                        // 出荷日付
				if (salesTemp.AcptAnOdrStatus == 30)
				{
					salesTemp.SalesDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;    // 売上日付
				}
				else
				{
					salesTemp.SalesDate = DateTime.MinValue;
				}
				salesTemp.ConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay); // 消費税税率

				salesTemp.SalesInputCode = this._stockSlip.StockInputCode.Trim();               // 売上入力者コード
				salesTemp.SalesInputName = this._stockSlip.StockInputName.Trim();               // 売上入力者名称
				salesTemp.SalesEmployeeCd = this._stockSlip.StockAgentCode.Trim();              // 販売従業員コード
				salesTemp.SalesEmployeeNm = this._stockSlip.StockAgentName.Trim();              // 販売従業員名称
				salesTemp.AutoDepositCd = 0;                                                    // 自動入金区分
				salesTemp.SlipNote = string.Empty;                                              // 伝票備考
                salesTemp.SlipNote2 = string.Empty;                                             // 伝票備考２
				salesTemp.ReconcileFlag = 0;                                                    // 消込フラグ
                salesTemp.SlipPrtSetPaperId = string.Empty;                                     // 伝票印刷設定用帳票ID
				salesTemp.CompleteCd = 0;                                                       // 一式伝票区分
				//salesTemp.SalesPriceFracProcCd = stockDetailRow.SalesPriceFracProcCd;         // 売上金額端数処理区分
				salesTemp.ShipmentCnt = salesDetailWork.AcptAnOdrRemainCnt;                     // 出荷数（ = 受注残）
				salesTemp.AcptAnOdrRemainCnt = salesDetailWork.AcptAnOdrRemainCnt;              // 受注残
				salesTemp.GrsProfitChkDiv = 0;                                                  // 粗利チェック区分
                salesTemp.PartySlipNumDtl = string.Empty;                                       // 相手先伝票番号（明細）
				//salesTemp.DtlNote = stockDetailRow.DtlNote;                                   // 明細備考
                salesTemp.OrderNumber = string.Empty;                                           // 発注番号

				switch (memoMoveDiv)
				{
					case MemoMoveDiv.All:
						break;
					case MemoMoveDiv.None:
						{
                            salesTemp.SlipMemo1 = string.Empty;                 // 伝票メモ１
                            salesTemp.SlipMemo2 = string.Empty;                 // 伝票メモ２
                            salesTemp.SlipMemo3 = string.Empty;                 // 伝票メモ３
                            salesTemp.SlipMemo4 = string.Empty;                 // 伝票メモ４
                            salesTemp.SlipMemo5 = string.Empty;                 // 伝票メモ５
                            salesTemp.SlipMemo6 = string.Empty;                 // 伝票メモ６
                            salesTemp.InsideMemo1 = string.Empty;               // 社内メモ１
                            salesTemp.InsideMemo2 = string.Empty;               // 社内メモ２
                            salesTemp.InsideMemo3 = string.Empty;               // 社内メモ３
                            salesTemp.InsideMemo4 = string.Empty;               // 社内メモ４
                            salesTemp.InsideMemo5 = string.Empty;               // 社内メモ５
                            salesTemp.InsideMemo6 = string.Empty;               // 社内メモ６
							break;
						}
					case MemoMoveDiv.SlipMemoOnly:
						{
                            salesTemp.InsideMemo1 = string.Empty;               // 社内メモ１
                            salesTemp.InsideMemo2 = string.Empty;               // 社内メモ２
                            salesTemp.InsideMemo3 = string.Empty;               // 社内メモ３
                            salesTemp.InsideMemo4 = string.Empty;               // 社内メモ４
                            salesTemp.InsideMemo5 = string.Empty;               // 社内メモ５
                            salesTemp.InsideMemo6 = string.Empty;               // 社内メモ６
							break;
						}
				}

				CustomerInfo claim;
                if (this._customerInfoAcs == null) this._customerInfoAcs = new CustomerInfoAcs();
				int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, salesTemp.ClaimCode, true, out claim);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					claim = new CustomerInfo();
				}

				salesTemp.TotalDay = claim.TotalDay;				// 締日
				salesTemp.NTimeCalcStDate = claim.NTimeCalcStDate;	// 次回勘定開始日

                //// 計上日、来勘区分の再セット
                //this._salesTempInputAcs.SettingAddUpDate(ref salesTemp);

                //// 売上金額再計算
                //this._salesTempInputAcs.CalculationSalesMoney(ref salesTemp);

                //// 売上原価再計算
                //this._salesTempInputAcs.CalculationCost(ref salesTemp);

                //// 粗利チェック区分設定
                //this._salesTempInputAcs.GrsProfitChkDivSetting(ref salesTemp);

				this.CacheSalesTemp(stockRowNo, salesTemp);

				#endregion
			}
		}

		/// <summary>
		/// 仕入明細行オブジェクトにコピー元明細、在庫より明細情報を一括設定します。
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		/// <param name="stockDetail">コピー元明細オブジェクト</param>
		/// <param name="stock">在庫情報オブジェクト</param>
		/// <param name="isAddUp">true:明細計上(発注残から設定) false:明細コピー</param>
		/// <param name="memoMoveDiv">メモ複写区分</param>
        public void StockDetailRowSettingFromStockDetail( int stockRowNo, StockDetail stockDetail, Stock stock, bool isAddUp, MemoMoveDiv memoMoveDiv )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				this.ClearStockDetailRow(row);

				if (stockDetail != null)
				{
					int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

					#region ●項目のセット

                    #region そのままセットする項目
                    row.StockSlipCdDtl = stockDetail.StockSlipCdDtl;                    // 仕入伝票区分（明細）
                    row.GoodsKindCode = stockDetail.GoodsKindCode;                      // 商品属性
                    row.GoodsMakerCd = stockDetail.GoodsMakerCd;                        // 商品メーカーコード
                    row.MakerName = stockDetail.MakerName;                              // メーカー名称
                    row.MakerKanaName = stockDetail.MakerKanaName;                      // メーカーカナ名称
                    row.CmpltMakerKanaName = stockDetail.CmpltMakerKanaName;            // メーカーカナ名称（一式）
                    row.GoodsNo = stockDetail.GoodsNo;                                  // 商品番号
                    row.GoodsName = stockDetail.GoodsName;                              // 商品名称
                    row.GoodsNameKana = stockDetail.GoodsNameKana;                      // 商品名称カナ
                    row.GoodsLGroup = stockDetail.GoodsLGroup;                          // 商品大分類コード
                    row.GoodsLGroupName = stockDetail.GoodsLGroupName;                  // 商品大分類名称
                    row.GoodsMGroup = stockDetail.GoodsMGroup;                          // 商品中分類コード
                    row.GoodsMGroupName = stockDetail.GoodsMGroupName;                  // 商品中分類名称
                    row.BLGroupCode = stockDetail.BLGroupCode;                          // BLグループコード
                    row.BLGroupName = stockDetail.BLGroupName;                          // BLグループコード名称
                    row.BLGoodsCode = stockDetail.BLGoodsCode;                          // BL商品コード
                    row.BLGoodsFullName = stockDetail.BLGoodsFullName;                  // BL商品コード名称（全角）
                    row.EnterpriseGanreCode = stockDetail.EnterpriseGanreCode;          // 自社分類コード
                    row.EnterpriseGanreName = stockDetail.EnterpriseGanreName;          // 自社分類名称
                    row.OpenPriceDiv = stockDetail.OpenPriceDiv;                        // オープン価格区分
                    row.GoodsRateRank = stockDetail.GoodsRateRank;                      // 商品掛率ランク
                    row.CustRateGrpCode = stockDetail.CustRateGrpCode;                  // 得意先掛率グループコード
                    row.SuppRateGrpCode = stockDetail.SuppRateGrpCode;                  // 仕入先掛率グループコード
                    row.ListPriceTaxExcFl = stockDetail.ListPriceTaxExcFl;              // 定価（税抜，浮動）
                    row.ListPriceTaxIncFl = stockDetail.ListPriceTaxIncFl;              // 定価（税込，浮動）
                    row.StockRate = stockDetail.StockRate;                              // 仕入率
                    //row.RateSectStckUnPrc = stockDetail.RateSectStckUnPrc;              // 掛率設定拠点（仕入単価）
                    //row.RateDivStckUnPrc = stockDetail.RateDivStckUnPrc;                // 掛率設定区分（仕入単価）
                    row.UnPrcCalcCdStckUnPrc = stockDetail.UnPrcCalcCdStckUnPrc;        // 単価算出区分（仕入単価）
                    row.PriceCdStckUnPrc = stockDetail.PriceCdStckUnPrc;                // 価格区分（仕入単価）
                    row.StdUnPrcStckUnPrc = stockDetail.StdUnPrcStckUnPrc;              // 基準単価（仕入単価）
                    row.FracProcUnitStcUnPrc = stockDetail.FracProcUnitStcUnPrc;        // 端数処理単位（仕入単価）
                    row.FracProcStckUnPrc = stockDetail.FracProcStckUnPrc;              // 端数処理（仕入単価）
                    row.StockUnitPriceFl = stockDetail.StockUnitPriceFl;                // 仕入単価（税抜，浮動）
                    row.StockUnitTaxPriceFl = stockDetail.StockUnitTaxPriceFl;          // 仕入単価（税込，浮動）
                    //row.StockUnitChngDiv = stockDetail.StockUnitChngDiv;                // 仕入単価変更区分
                    row.BfStockUnitPriceFl = stockDetail.BfStockUnitPriceFl;            // 変更前仕入単価（浮動）
                    row.BfListPrice = stockDetail.BfListPrice;                          // 変更前定価
                    row.RateBLGoodsCode = stockDetail.RateBLGoodsCode;                  // BL商品コード（掛率）
                    row.RateBLGoodsName = stockDetail.RateBLGoodsName;                  // BL商品コード名称（掛率）
                    row.StockCount = stockDetail.StockCount;                            // 仕入数
                    row.StockPriceTaxExc = stockDetail.StockPriceTaxExc;                // 仕入金額（税抜き）
                    row.StockPriceTaxInc = stockDetail.StockPriceTaxInc;                // 仕入金額（税込み）
                    row.StockGoodsCd = stockDetail.StockGoodsCd;                        // 仕入商品区分
                    row.StockPriceConsTax = stockDetail.StockPriceConsTax;              // 仕入金額消費税額
                    row.TaxationCode = stockDetail.TaxationCode;                        // 課税区分
                    row.StockDtiSlipNote1 = stockDetail.StockDtiSlipNote1;              // 仕入伝票明細備考1
                    row.SalesCustomerCode = stockDetail.SalesCustomerCode;              // 販売先コード
                    row.SalesCustomerSnm = stockDetail.SalesCustomerSnm;                // 販売先略称

                    #endregion

                    row.OrderRemainCnt = ( this._stockSlip.SupplierFormal == 0 ) ? 0 : row.StockCount;  // 発注残
                    row.TaxDiv = row.TaxationCode;
                    row.CanTaxDivChange = false;                                                        // 課税非課税区分変更可能フラグ

                    // メモはメモ複写区分に従ってコピーする
                    switch (memoMoveDiv)
                    {
                        // 全て
                        case MemoMoveDiv.All:
                            {
                                row.SlipMemo1 = stockDetail.SlipMemo1;                  // 伝票メモ１
                                row.SlipMemo2 = stockDetail.SlipMemo2;                  // 伝票メモ２
                                row.SlipMemo3 = stockDetail.SlipMemo3;                  // 伝票メモ３
                                row.InsideMemo1 = stockDetail.InsideMemo1;              // 社内メモ１
                                row.InsideMemo2 = stockDetail.InsideMemo2;              // 社内メモ２
                                row.InsideMemo3 = stockDetail.InsideMemo3;              // 社内メモ３
                                break;
                            }
                        // 社外メモのみ
                        case MemoMoveDiv.SlipMemoOnly:
                            {
                                row.SlipMemo1 = stockDetail.SlipMemo1;                  // 伝票メモ１
                                row.SlipMemo2 = stockDetail.SlipMemo2;                  // 伝票メモ２
                                row.SlipMemo3 = stockDetail.SlipMemo3;                  // 伝票メモ３
                                break;
                            }
                        // しない
                        case MemoMoveDiv.None:
                            break;
                    }

                    row.TaxationCode = stockDetail.TaxationCode;

                    // 表示用定価、表示用単価、表示用仕入金額（転嫁方式、総額表示により分岐）
                    if (this._stockSlip.SuppCTaxLayCd == 9)
                    {
                        row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
                        row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
                        row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
                    }
                    else if (this._stockSlip.SuppTtlAmntDspWayCd == 1)
                    {
                        // 総額表示している場合は税込み価格を表示する
                        row.StockUnitPriceDisplay = stockDetail.StockUnitTaxPriceFl;
                        row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
                        row.ListPriceDisplay = stockDetail.ListPriceTaxIncFl;
                    }
                    else
                    {
                        // 課税方式により分岐
                        if (stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                        {
                            row.StockUnitPriceDisplay = stockDetail.StockUnitTaxPriceFl;
                            row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
                            row.ListPriceDisplay = stockDetail.ListPriceTaxIncFl;
                        }
                        if (( stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) ||
                            ( stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone ))
                        {
                            row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
                            row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
                            row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
                        }
                    }

                    // 行値引きの場合
                    if ( stockDetail.StockSlipCdDtl == 2 )
                    {
                        // 仕入数＝０は行値引き
                        if (stockDetail.StockCount == 0)
                        {
                            row.StockUnitPriceDisplay = 0;	// 単価は非表示
                            row.EditStatus = StockSlipInputAcs.ctEDITSTATUS_RowDiscount;
                        }
                        else
                        {
                            row.EditStatus = StockSlipInputAcs.ctEDITSTATUS_GoodsDiscount;
                        }
                    }
                    else
                    {
                        row.EditStatus = StockSlipInputAcs.ctEDITSTATUS_AllOK;
                    }

                    // 在庫情報
                    if (stock != null)
                    {
                        this.CacheStockInfo(stock);

                        row.WarehouseCode = stock.WarehouseCode.Trim();
                        row.WarehouseName = stock.WarehouseName;
                        row.WarehouseShelfNo = stock.WarehouseShelfNo;
                        row.StockOrderDivCd = 1;
                    }
                    else
                    {
                        row.StockOrderDivCd = 0;
                    }

                    row.StockPriceDiectInput = ( ( row.StockUnitPriceDisplay == 0 ) && ( row.StockPriceDisplay != 0 ) );

                    // 計上処理の場合の補正処理
                    if (isAddUp)
                    {
                        row.EditStatus = StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpNew;
                        row.StockCount = stockDetail.OrderRemainCnt;
                        row.OrderCnt = stockDetail.OrderRemainCnt;					// 発注数
                        row.StockCountDefault = stockDetail.OrderRemainCnt;			// 数量(初期表示)←計上元明細の発注残
                        row.StockCountMax = stockDetail.OrderRemainCnt;				// 計上可能数←計上元明細の発注残
                        row.StockCountMin = 0;										// 計上済み数量←0
                        row.SupplierFormalSrc = stockDetail.SupplierFormal;			// 計上元仕入形式
                        row.StockSlipDtlNumSrc = stockDetail.StockSlipDtlNum;		// 計上元明細通番
                        row.CommonSeqNo = stockDetail.CommonSeqNo;					// 共通通番
                        row.AcceptAnOrderNo = stockDetail.AcceptAnOrderNo;			// 受注番号

                        if (( row.StockPriceDiectInput ) && ( stockDetail.OrderRemainCnt == stockDetail.StockCount ))
                        {
                        }
                        else
                        {
                            row.StockPriceDiectInput = false;
                            this.CalculateStockPrice(row);
                        }

                        this.LnkStockDetailRowSettingFromStockDetail(stockDetail);

                        // 発注番号は発注計上時のみコピーする
                        if (stockDetail.SupplierFormal == 2)
                        {
                            row.OrderNumber = stockDetail.OrderNumber;              // 発注番号
                        }
                    }

                    row.StockUnitChngDiv = ( row.BfStockUnitPriceFl != row.StockUnitPriceFl ) ? 1 : 0;  // 単価変更区分

                    // 金額初期値関係
                    row.StockUnitPriceDefault = row.StockUnitPriceFl;
                    row.StockUnitTaxPriceDefault = row.StockUnitTaxPriceFl;
                    row.StockPriceTaxExcDefault = row.StockPriceTaxExc;
                    row.StockPriceTaxIncDefault = row.StockPriceTaxInc;

                    row.StockCountDisplay = row.StockCount * sign;			// 数量(表示)


					#endregion
				}
			}
		}

		/// <summary>
		/// 計上元仕入明細行オブジェクトにコピー元明細より明細情報を設定します。
		/// </summary>
		/// <param name="stockDetail"></param>
		private void LnkStockDetailRowSettingFromStockDetail( StockDetail stockDetail )
		{
			CacheAddUpSrcStockDetailDataTable(stockDetail, this._addUpSrcDetailDataTable);
		}


		/// <summary>
		/// 仕入明細データ行オブジェクトに行値引情報を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
        public void StockDetailRowDiscountSetting(int stockRowNo)
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                this.ClearStockDetailRow(row);

                row.EditStatus = ctEDITSTATUS_RowDiscount;      // 行値引ステータス
                row.GoodsName = this._stockSlipInputInitDataAcs.GetStockTtlSt().StockDiscountName;		// 商品名称
                //row.GoodsShortName= this._stockSlipInputInitDataAcs.GetStockTtlSt().StockDiscountName;	// 商品名称略称
                row.StockSlipCdDtl = 2;                         // 仕入伝票区分(明細)

                // 総額表示する場合は内税、総額表示しない場合は外税
                row.TaxationCode = ( this._stockSlip.SuppTtlAmntDspWayCd == 0 ) ? (int)CalculateTax.TaxationCode.TaxExc : (int)CalculateTax.TaxationCode.TaxInc;
                row.TaxDiv = row.TaxationCode;
                row.CanTaxDivChange = false;
            }
        }

		/// <summary>
		/// 仕入明細データ行オブジェクトに商品値引情報を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		public void StockDetailGoodsDiscountSetting( int stockRowNo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{

			    this.ClearStockDetailRow(row);

				row.StockSlipCdDtl = 2;							// 仕入伝票区分(明細)
				row.EditStatus = ctEDITSTATUS_GoodsDiscount;	// 商品値引ステータス
				row.StockCountDisplay = -1;
				row.StockCount = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

			    // 総額表示する場合は内税、総額表示しない場合は外税
                if (this._stockSlip.SuppCTaxLayCd == 9)
                {
                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                }
                else if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                {
                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxExc;
                }
                else
                {
                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                }
			    row.TaxDiv = row.TaxationCode;
			    row.CanTaxDivChange = false;
			}
		}

		/// <summary>
		/// 用品入力情報設定処理
		/// </summary>
		/// <param name="stockRowNo"></param>
		public void StockDetailRowUtensilsInput(int stockRowNo)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				string goodsName = row.GoodsName;

				int stockSlipCdDtl = row.StockSlipCdDtl;
				this.ClearStockDetailRow(row);

				row.GoodsName = goodsName;		// 品名

				if (stockSlipCdDtl == 2)
				{
					row.StockCountDisplay = -1;
					row.StockSlipCdDtl = stockSlipCdDtl;

                    // 行値引きの場合はそのまま
                    if (row.EditStatus == ctEDITSTATUS_RowDiscount)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;
                    }
				}
				else
				{
					row.StockCountDisplay = 1;
					row.EditStatus = ctEDITSTATUS_AllOK; // 行値引ステータス
				}


				int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;


				row.StockCount = sign * row.StockCountDisplay;

				row.TaxDiv = ( this._stockSlip.SuppTtlAmntDspWayCd == 0 ) ? (int)CalculateTax.TaxationCode.TaxExc : row.TaxationCode = (int)CalculateTax.TaxationCode.TaxInc;
					
				row.CanTaxDivChange = true;
			}
		}

		#region 各項目の入力設定(商品・在庫を除く)

		/// <summary>
		/// 仕入明細行オブジェクトに倉庫名称、倉庫コードを設定します。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">仕入明細行番号</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="warehouseName">倉庫名称</param>
		public void StockDetialWarehouseInfoSetting( int stockRowNo, string warehouseCode, string warehouseName)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row == null) return;

			row.WarehouseCode = warehouseCode.Trim();
			row.WarehouseName = warehouseName;

			if (String.IsNullOrEmpty(warehouseCode.Trim()))
			{
                row.WarehouseShelfNo = string.Empty;
				row.ShipmentPosCnt = 0;
				row.ShipmentPosCntDisplay = 0;
			}
            row.AcceptChanges();
		}

        /// <summary>
		/// 仕入明細行オブジェクトにメーカーコードとメーカー名称を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入明細行番号</param>
		/// <param name="goodsMakerCd">メーカーコード</param>
		/// <param name="makerName">メーカー名称</param>
        /// <param name="makerKanaName">メーカー名称カナ</param>
        public void StockDetailMakerInfoSetting( int stockRowNo, int goodsMakerCd, string makerName, string makerKanaName )
        {
            bool isMakerChanged;
            this.StockDetailMakerInfoSetting(stockRowNo, goodsMakerCd, makerName, makerKanaName, out isMakerChanged);
        }

		/// <summary>
		/// 仕入明細行オブジェクトにメーカーコードとメーカー名称を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入明細行番号</param>
		/// <param name="goodsMakerCd">メーカーコード</param>
		/// <param name="makerName">メーカー名称</param>
        /// <param name="makerKanaName">メーカー名称カナ</param>
        /// <param name="isMakerChanged">メーカー変更有無</param>
        public void StockDetailMakerInfoSetting( int stockRowNo, int goodsMakerCd, string makerName,string makerKanaName, out bool isMakerChanged )
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            isMakerChanged = ( row.GoodsMakerCd != goodsMakerCd );
            row.GoodsMakerCd = goodsMakerCd;
            row.MakerName = makerName;
            row.MakerKanaName = makerKanaName;
        }

		/// <summary>
		/// 仕入明細行オブジェクトに販売先情報を設定します。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">仕入明細行番号</param>
        /// <param name="customerInfo">得意先マスタオブジェクト</param>
		public void StockDetailSalesCustomerInfoSetting( int stockRowNo, CustomerInfo customerInfo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            row.SalesCustomerCode = customerInfo.CustomerCode;
            row.SalesCustomerSnm = customerInfo.CustomerSnm;
		}

        /// <summary>
        /// 仕入明細行オブジェクトにBLコード関連の情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="stockRowNo">仕入明細行番号</param>
        /// <param name="blCode">BLコード</param>
        /// <returns>False:BLコードマスタ取得失敗</returns>
        public bool StockDetailBLGoodsInfoSetting( int stockRowNo, int blCode )
        {
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            BLGroupU bLGroupU = new BLGroupU();
            GoodsGroupU goodsGroupU = new GoodsGroupU();
            UserGdBdU userGdBdU = new UserGdBdU();

            if (blCode != 0)
            {
                // BLグループ、中分類、大分類情報を取得
                if (!this._stockSlipInputInitDataAcs.GetBLGoodsRelation(blCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU))
                {
                    // 失敗時は
                    return false;
                }
            }

            // 2009.03.31 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this.StockDetailBLGoodsInfoSetting(stockRowNo, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, true);

            StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);

            bool changeGoodsName = false;
            if (blCode != 0)
            {
                if ((this._stockSlipInputInitDataAcs.GetStockTtlSt().GoodsNmReDispDivCd == 1) ||
                    ((this._stockSlipInputInitDataAcs.GetStockTtlSt().GoodsNmReDispDivCd == 0) &&
                     (string.IsNullOrEmpty(stockDetailRow.GoodsName)))) changeGoodsName = true; // 品名再表示区分 0:しない 1:する
            }

            this.StockDetailBLGoodsInfoSetting(stockRowNo, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, changeGoodsName);
            // 2009.03.31 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<            

            return true;
        }

        /// <summary>
        /// 仕入明細行オブジェクトにBLコード関連の情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="stockRowNo">仕入明細行番号</param>
        /// <param name="bLGoodsCdUMnt">BLコードマスタ</param>
        public void StockDetailBLGoodsInfoSetting(int stockRowNo, BLGoodsCdUMnt bLGoodsCdUMnt)
        {
            BLGoodsCdUMnt bLGoodsCdUMntWk = new BLGoodsCdUMnt();
            BLGroupU bLGroupU = new BLGroupU();
            GoodsGroupU goodsGroupU = new GoodsGroupU();
            UserGdBdU userGdBdU = new UserGdBdU();

            // BLグループ、中分類、大分類情報を取得
            this._stockSlipInputInitDataAcs.GetBLGoodsRelation(bLGoodsCdUMnt.BLGoodsCode, out bLGoodsCdUMntWk, out bLGroupU, out goodsGroupU, out userGdBdU);

            // 2009.03.31 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this.StockDetailBLGoodsInfoSetting(stockRowNo, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, true);

            StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);

            bool changeGoodsName = false;
            if ((this._stockSlipInputInitDataAcs.GetStockTtlSt().GoodsNmReDispDivCd == 1) ||
                ((this._stockSlipInputInitDataAcs.GetStockTtlSt().GoodsNmReDispDivCd == 0) &&
                 (string.IsNullOrEmpty(stockDetailRow.GoodsName)))) changeGoodsName = true; // 品名再表示区分 0:しない 1:する

            this.StockDetailBLGoodsInfoSetting(stockRowNo, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, changeGoodsName);
            // 2009.03.31 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<   
        }

        /// <summary>
        /// 仕入明細行オブジェクトのBLコード関連の情報をクリアします。
        /// </summary>
        /// <param name="stockRowNo">仕入明細行オブジェクト</param>
        /// <returns></returns>
        public void StockDetailBLGoodsInfoClear( int stockRowNo )
        {
            this.StockDetailBLGoodsInfoSetting(stockRowNo, new BLGoodsCdUMnt(), new BLGroupU(), new GoodsGroupU(), new UserGdBdU(), false);
        }

        /// <summary>
        /// 仕入明細行オブジェクトにBLコード関連の情報を設定します。
        /// </summary>
        /// <param name="stockRowNo">仕入明細行番号</param>
        /// <param name="bLGoodsCdUMnt">BLコードマスタ</param>
        /// <param name="bLGroupU">グループコードマスタ</param>
        /// <param name="goodsGroupU">中分類マスタ</param>
        /// <param name="userGdBdU">ユーザーガイドマスタ（大分類情報）</param>
        /// <param name="changeGoodsName">True:品名を変更する</param>
        private void StockDetailBLGoodsInfoSetting( int stockRowNo, BLGoodsCdUMnt bLGoodsCdUMnt, BLGroupU bLGroupU, GoodsGroupU goodsGroupU, UserGdBdU userGdBdU, bool changeGoodsName )
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
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
                    row.GoodsName = bLGoodsCdUMnt.BLGoodsFullName;
                    row.GoodsNameKana = bLGoodsCdUMnt.BLGoodsHalfName;
                }
            }
        }

		#endregion


		#endregion

        /// <summary>
        /// 仕入明細テーブルの掛率情報をクリアします。
        /// </summary>
        public void StockDetailTableClearRateInfo()
        {
            this.StockDetailTableClearRateInfo(this._stockDetailDataTable);
        }

        /// <summary>
        /// 仕入明細テーブルの掛率情報をクリアします。
        /// </summary>
        private void StockDetailTableClearRateInfo( StockInputDataSet.StockDetailDataTable stockDetailDataTable )
        {
            stockDetailDataTable.BeginLoadData();
            foreach (StockInputDataSet.StockDetailRow row in stockDetailDataTable)
            {
                row.RateSectStckUnPrc = string.Empty;           // 掛率設定拠点（仕入単価）
                row.RateDivStckUnPrc = string.Empty;            // 掛率設定区分（仕入単価）
                //row.UnPrcCalcCdStckUnPrc = 0;                   // 単価算出区分（仕入単価）
                //row.BfStockUnitPriceFl = 0;                     // 変更前単価
                row.StockUnitChngDiv = ( row.BfStockUnitPriceFl != row.StockUnitPriceFl ) ? 1 : 0;
            }
            stockDetailDataTable.EndLoadData();
        }

		/// <summary>
        /// 仕入明細テーブルの商品価格の再設定を行います。
		/// </summary>
		public void StockDetailTableGoodsPriceReSetting()
		{
			this.StockDetailTableGoodsPriceReSetting(this._stockDetailDataTable);
		}

        /// <summary>
        /// 商品再検索処理
        /// </summary>
        /// <returns></returns>
        private int ReSearchGoods()
        {
            List<StockInputDataSet.StockDetailRow> targetRowList;
            List<GoodsUnitData> goodsUnitDataList;
            return this.ReSearchGoods(this._stockDetailDataTable, true, out targetRowList, out goodsUnitDataList);
        }

        /// <summary>
        /// 商品再検索処理
        /// </summary>
        /// <param name="stockDetailDataTable">仕入明細テーブル</param>
        /// <param name="isCache">True:キャッシュする</param>
        /// <param name="targetRowList">対象行オブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        private int ReSearchGoods(StockInputDataSet.StockDetailDataTable stockDetailDataTable, bool isCache, out List<StockInputDataSet.StockDetailRow> targetRowList, out  List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            goodsUnitDataList = null;
            targetRowList = new List<StockInputDataSet.StockDetailRow>();

            // 商品検索条件リストを生成する
            foreach (StockInputDataSet.StockDetailRow row in stockDetailDataTable)
            {
                if (( ( row.EditStatus == ctEDITSTATUS_AllOK ) || ( row.EditStatus == ctEDITSTATUS_ArrivalAddUpEdit ) || ( row.EditStatus == ctEDITSTATUS_ArrivalAddUpNew ) ) && ( ( !string.IsNullOrEmpty(row.GoodsNo) && ( row.GoodsMakerCd != 0 ) ) ))
                {
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
                    goodsCndtn.GoodsNo = row.GoodsNo;
                    goodsCndtn.GoodsMakerCd = row.GoodsMakerCd;
                    goodsCndtn.SectionCode = this._stockSlip.StockSectionCd;
                    goodsCndtn.IsSettingSupplier = 1;

                    goodsCndtnList.Add(goodsCndtn);
                    targetRowList.Add(row);
                }
            }
            if (goodsCndtnList.Count > 0)
            {
                // 商品検索を行い、単価算出のパラメータを作成する
                string message;

                status = this._stockSlipInputInitDataAcs.GetGoodsUnitDataList(goodsCndtnList, out goodsUnitDataList, out message);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (isCache)
                    {
                        this.ClearGoodsCacheInfo();
                        this.CacheGoodsUnitData(goodsUnitDataList);
                    }
                }
            }
            return status;
        }

		/// <summary>
        /// 仕入明細テーブルの商品価格の再設定を行います。
		/// </summary>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
        private void StockDetailTableGoodsPriceReSetting( StockInputDataSet.StockDetailDataTable stockDetailDataTable )
        {
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();

            List<StockInputDataSet.StockDetailRow> targetRowList = new List<StockInputDataSet.StockDetailRow>();
            List<GoodsUnitData> goodsUnitDataList;

            int status = this.ReSearchGoods(stockDetailDataTable, true, out targetRowList, out goodsUnitDataList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 商品検索を行い、単価算出のパラメータを作成する
                List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

                foreach (StockInputDataSet.StockDetailRow row in targetRowList)
                {

                    GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd);

                    if (goodsUnitData != null)
                    {
                        unitPriceCalcParamList.Add(this.CreateUnitPriceCalcParam(row, goodsUnitData));
                    }
                }

                // 単価算出モジュールで単価一括計算（リモート１回で処理する）
                List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalculateStockUnitPrice(unitPriceCalcParamList, goodsUnitDataList);

                // 結果を明細に反映
                foreach (StockInputDataSet.StockDetailRow row in targetRowList)
                {
                    GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd);
                    UnitPriceCalcRet unitPriceCalcRet = null;

                    foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
                    {
                        if (( unitPriceCalcRetWk.GoodsNo == row.GoodsNo ) &&
                            ( unitPriceCalcRetWk.GoodsMakerCd == row.GoodsMakerCd ))
                        {
                            unitPriceCalcRet = unitPriceCalcRetWk;
                            break;
                        }
                    }

                    double stockRate = row.StockRate;
                    double stockUnitPriceTaxExc = row.StockUnitPriceFl;
                    double stockUnitPriceTaxInc = row.StockUnitTaxPriceFl;

                    this.ClearStockDetailRateInfo(row, true);

                    // 商品検索に失敗した場合
                    if (( goodsUnitData == null ) || ( unitPriceCalcRet == null ))
                    {
                        this.StockDetailRowListPriceSetting(row, goodsUnitData);
                        if (goodsUnitData != null)
                        {
                            row.RateBLGoodsCode = goodsUnitData.BLGoodsCode;
                            row.RateBLGoodsName = goodsUnitData.BLGoodsName;
                        }

                        if (stockRate != 0)
                        {
                            row.StockRate = stockRate;
                            double stockUnitPriceDisplay;
                            double fracProcUnitStcUnPrc = 0;
                            int fracProcStckUnPrc = 0;
                            this.CalculateStockUnitPriceByRate(row, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockUnitPriceDisplay, ref fracProcUnitStcUnPrc, ref fracProcStckUnPrc);

                            row.UnPrcCalcCdStckUnPrc = (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal;    
                            row.StdUnPrcStckUnPrc = row.ListPriceTaxExcFl;
                            row.FracProcUnitStcUnPrc = fracProcUnitStcUnPrc;
                            row.FracProcStckUnPrc = fracProcStckUnPrc;
                        }
                        row.StockUnitPriceFl = stockUnitPriceTaxExc;
                        row.StockUnitTaxPriceFl = stockUnitPriceTaxInc;
                        row.BfStockUnitPriceFl = 0;
                        row.StockUnitChngDiv = ( row.BfStockUnitPriceFl != row.StockUnitPriceFl ) ? 1 : 0;
                        row.StockPriceDiectInput = ( ( row.StockUnitPriceFl == 0 ) && ( row.StockPriceTaxExc != 0 ) );
                    }
                    // 商品検索OK、単価算出OK
                    else
                    {
                        this.StockDetailRowGoodsPriceSettingFromUnitPriceCalcRet(row, goodsUnitData, unitPriceCalcRet);
                        row.StockPriceDiectInput = false;
                    }
                    this.CalculateStockPrice(row);
                    this.StockDetailRowTaxationCodeSetting(this._stockSlip.SuppCTaxLayCd, this._stockSlip.SuppTtlAmntDspWayCd, row);
                }
            }
        }
        
        /// <summary>
        /// 指定した仕入単価の値を元に仕入明細行オブジェクトの単価情報を設定します。
        /// </summary>
        /// <param name="row">仕入明細行オブジェクト</param>
        /// <param name="priceInputType">金額入力モード</param>
        /// <param name="stockUnitPrice">単価</param>
        private void StockDetailRowStockUnitPriceSetting(StockInputDataSet.StockDetailRow row, PriceInputType priceInputType, double stockUnitPrice)
        {
            if (row != null)
            {
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);	// 仕入消費税端数処理コード

                int taxFracProcCd = 0;
                double taxFracProcUnit = 0;
                this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

                double stockUnitPriceFl;
                double stockUnitTaxPriceFl;
                double stockUnitPriceDisplay;

                this.CalculatePrice(priceInputType, stockUnitPrice, row.TaxationCode, this._stockSlip.SuppTtlAmntDspWayCd, this._stockSlip.SuppCTaxLayCd, this._stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, out  stockUnitPriceFl, out stockUnitTaxPriceFl, out stockUnitPriceDisplay);

                row.StockUnitPriceFl = stockUnitPriceFl;
                row.StockUnitTaxPriceFl = stockUnitTaxPriceFl;
                row.StockUnitPriceDisplay = stockUnitPriceDisplay;
                row.StockPriceDiectInput = false;

                // 仕入率が入っている場合は単価を比較する
                if (row.StockRate != 0)
                {
                    double stockUnitPriceDisplayWk;
                    double stockUnitPriceTaxExcWk;
                    double stockUnitPriceTaxIncWk;
                    double fracProcUnitStcUnPrc = row.FracProcUnitStcUnPrc;
                    int fracProcStckUnPrc = row.FracProcStckUnPrc;
                    this.CalculateStockUnitPriceByRate(row, out stockUnitPriceTaxExcWk, out stockUnitPriceTaxIncWk, out stockUnitPriceDisplayWk, ref fracProcUnitStcUnPrc, ref fracProcStckUnPrc);

                    switch (row.TaxationCode)
                    {
                        case (int)CalculateTax.TaxationCode.TaxInc:
                            {
                                if (row.StockUnitTaxPriceFl != stockUnitPriceTaxIncWk)
                                {
                                    row.StockRate = 0;
                                }
                                break;
                            }
                        case (int)CalculateTax.TaxationCode.TaxExc:
                        case (int)CalculateTax.TaxationCode.TaxNone:
                            {
                                if (row.StockUnitPriceFl != stockUnitPriceTaxExcWk)
                                {
                                    row.StockRate = 0;
                                }
                                break;
                            }
                    }
                }

            }

            // 変更前単価と異なる場合は単価変更区分に1をセット
            row.StockUnitChngDiv = ( row.StockUnitPriceFl != row.BfStockUnitPriceFl ) ? 1 : 0;
            //row.StockPriceDiectInput = false;
        }

        /// <summary>
        /// 指定した定価を元に仕入明細行オブジェクトの定価情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="stockRowNo">仕入行番号</param>
        /// <param name="priceInputType">仕入単価入力モード</param>
        /// <param name="listPrice">単価</param>
        /// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
        public void StockDetailRowListPriceSetting(int stockRowNo, PriceInputType priceInputType, double listPrice, StockInputDataSet.StockDetailDataTable stockDetailDataTable)
        {
            StockInputDataSet.StockDetailRow row = stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._currentSupplierSlipNo, stockRowNo);

            this.StockDetailRowListPriceSetting(row, priceInputType, listPrice);
        }

		/// <summary>
        /// 指定した定価を元に仕入明細行オブジェクトの定価情報を設定します。（オーバーロード）
		/// </summary>
        /// <param name="row">仕入明細行オブジェクト</param>
		/// <param name="priceInputType">仕入単価入力モード</param>
		/// <param name="listPrice">単価</param>
        private void StockDetailRowListPriceSetting(StockInputDataSet.StockDetailRow row, PriceInputType priceInputType, double listPrice)
        {
            // TODO
            if (row != null)
            {
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード

                double listPriceDisplay;
                double listPriceTaxExcFl;
                double listPriceTaxIncFl;

                this.CalculatePrice(priceInputType, listPrice, row.TaxationCode, this._stockSlip.SuppTtlAmntDspWayCd, this._stockSlip.SuppCTaxLayCd, this._stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, out listPriceTaxExcFl, out listPriceTaxIncFl, out listPriceDisplay);

                row.ListPriceTaxExcFl = listPriceTaxExcFl;
                row.ListPriceTaxIncFl = listPriceTaxIncFl;
                row.ListPriceDisplay = listPriceDisplay;

                if (( ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) && ( row.StdUnPrcStckUnPrc != row.ListPriceTaxIncFl ) ) ||
                    ( ( row.TaxationCode != (int)CalculateTax.TaxationCode.TaxInc ) && ( row.StdUnPrcStckUnPrc != row.ListPriceTaxExcFl ) ))
                {
                    if (row.StockRate != 0)
                    {
                        row.PriceCdStckUnPrc = 0;
                        row.UnPrcCalcCdStckUnPrc = 1;
                        row.StdUnPrcStckUnPrc = ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? row.ListPriceTaxIncFl : row.ListPriceTaxExcFl;
                    }
                }
            }
        }

		/// <summary>
		/// 入力した仕入単価の値を元に仕入明細行オブジェクトの単価情報を設定します。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="stockUnitPrice">単価</param>
		public void StockDetailRowStockUnitPriceSetting( int stockRowNo, double stockUnitPrice )
		{
			StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            this.ClearStockDetailRateInfo(row, false);
            this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceDisplay, stockUnitPrice);
		}

		/// <summary>
		/// 指定した定価の値を元に仕入明細行オブジェクトの定価情報を設定します。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
        /// <param name="stockUnitPriceInputType">仕入単価入力モード</param>
		/// <param name="listPrice">単価</param>
		public void StockDetailListPriceSetting( int stockRowNo, PriceInputType stockUnitPriceInputType, double listPrice )
		{
			this.StockDetailRowListPriceSetting(stockRowNo, stockUnitPriceInputType, listPrice, this._stockDetailDataTable);
		}

		/// <summary>
		/// 指定した金額を元に仕入明細行オブジェクトの仕入金額を設定します。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="stockPrice">仕入金額</param>
		public void StockDetailStockPriceSetting(int stockRowNo, long stockPrice )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row != null)
			{
                row.StockPriceDisplay = stockPrice;
				this.StockDetailRowStockGoodsCdSetting(stockRowNo, this._stockSlip.StockGoodsCd);
			}
		}


		/// <summary>
		/// 指定した消費税を元に仕入明細行オブジェクトの仕入金額情報を設定します。（オーバーロード）
		/// </summary>
        /// <param name="stockSlip">仕入データ</param>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="taxPrice">消費税金額</param>
		public void StockDetailTaxPriceSetting( StockSlip stockSlip,int stockRowNo, long taxPrice )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row != null)
			{
                int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
				// 総額表示しない
				if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
				{
                    row.StockPriceTaxInc = (long)( ((decimal)( row.StockPriceDisplay ) + (decimal)( taxPrice )) * sign );
				}
				// 総額表示
				else
				{
                    row.StockPriceTaxExc = (long)( ((decimal)row.StockPriceTaxInc - (decimal)( taxPrice )) * sign );
				}
                row.StockPriceConsTax = taxPrice * sign;
				row.StockUnitPriceFl = 0;
				row.StockUnitTaxPriceFl = 0;
			}
		}


        /// <summary>
        /// 指定した仕入率の値を元に仕入明細行オブジェクトの単価情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="stockRowNo">仕入行番号</param>
        /// <param name="stockRate">仕入率</param>
        public void StockDetailRowStockUnitPriceSettingbyRate( int stockRowNo, double stockRate )
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            this.ClearStockDetailRateInfo(row, false);

			row.StockRate = stockRate;

			double stockUnitPriceTaxExc;
			double stockUnitPriceTaxInc;
			double stockUnitPriceDisplay;
			double fracProcUnitStcUnPrc = 0;
			int fracProcStckUnPrc = 0;

			this.CalculateStockUnitPriceByRate(row, out stockUnitPriceDisplay, out stockUnitPriceTaxInc, out stockUnitPriceTaxExc, ref fracProcUnitStcUnPrc, ref fracProcStckUnPrc);

			row.StockUnitPriceDisplay = stockUnitPriceDisplay;
			row.StockUnitPriceFl = stockUnitPriceTaxExc;
			row.StockUnitTaxPriceFl = stockUnitPriceTaxInc;

			if (( ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) && ( row.StdUnPrcStckUnPrc != row.ListPriceTaxIncFl ) ) ||
				( ( row.TaxationCode != (int)CalculateTax.TaxationCode.TaxInc ) && ( row.StdUnPrcStckUnPrc != row.ListPriceTaxExcFl ) ))
			{
				row.PriceCdStckUnPrc = 0;
				row.UnPrcCalcCdStckUnPrc = 1;
				row.StdUnPrcStckUnPrc = ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? row.ListPriceTaxIncFl : row.ListPriceTaxExcFl;
			}

			row.FracProcUnitStcUnPrc = fracProcUnitStcUnPrc;
			row.FracProcStckUnPrc = fracProcStckUnPrc;
            row.StockPriceDiectInput = false;
        }

		/// <summary>
		/// 消費税率や課税区分が変更された場合に仕入明細データテーブルの単価の調整を行います。
		/// </summary>
		public void StockDetailRowPriceAdjust()
		{
			this.StockDetailRowPriceAdjust(this._stockDetailDataTable);
		}

		/// <summary>
		/// 消費税率や課税区分が変更された場合に仕入明細データ行オブジェクトの単価の調整を行います。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		public void StockDetailRowPriceAdjust(int stockRowNo)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            this.StockDetailRowPriceAdjust(row);
		}

		/// <summary>
		/// 消費税率や課税区分が変更された場合に仕入明細データテーブルの単価の調整を行います。（オーバーロード）
		/// </summary>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		private void StockDetailRowPriceAdjust(StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			foreach (StockInputDataSet.StockDetailRow row in stockDetailDataTable.Rows)
			{
				// 仕入明細データセッティング処理（単価調整）
                this.StockDetailRowPriceAdjust(row);
			}
		}

		/// <summary>
		/// 消費税率や課税区分が変更された場合に仕入明細データ行オブジェクトの金額を調整します。（オーバーロード）
		/// </summary>
        /// <param name="row">仕入明細データテーブル行オブジェクト</param>
        public void StockDetailRowPriceAdjust(StockInputDataSet.StockDetailRow row)
		{
            if (row != null)
            {
                //// 転嫁方式：非課税もしくは課税区分：非課税
                //if ( this._stockSlip.SuppCTaxLayCd == 9 )
                //{
                //    // 仕入明細データ単価設定処理
                //    this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxExc, row.StockUnitPriceFl);

                //    // 仕入明細データ定価設定処理
                //    this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);
                //}
                // 課税区分：「外税」
                if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    // 仕入明細データ定価設定処理
                    this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);

                    if (row.StockUnitPriceFl != 0 || row.StockUnitTaxPriceFl != 0)
                    {
                        // 仕入明細データ単価設定処理
                        this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxExc, row.StockUnitPriceFl);
                    }
                }
                // 課税区分：「内税」
                else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    // 仕入明細データ定価設定処理
                    this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl);

                    if (row.StockUnitPriceFl != 0 || row.StockUnitTaxPriceFl != 0)
                    {
                        // 仕入明細データ単価設定処理
                        this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxInc, row.StockUnitTaxPriceFl);
                    }
                }
                // 課税区分：「非課税」
                else
                {
                    // 仕入先総額表示方法区分が「総額表示しない」の場合
                    if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                    {
                        // 仕入明細データ定価設定処理
                        this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);

                        if (row.StockUnitPriceFl != 0 || row.StockUnitTaxPriceFl != 0)
                        {
                            // 仕入明細データ単価設定処理
                            this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxExc, row.StockUnitPriceFl);
                        }
                    }
                    // 仕入先総額表示方法区分が「総額表示する」の場合
                    else if (this._stockSlip.SuppTtlAmntDspWayCd == 1)
                    {
                        // 仕入明細データ定価設定処理
                        this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl);

                        if (row.StockUnitPriceFl != 0 || row.StockUnitTaxPriceFl != 0)
                        {
                            // 仕入明細データ単価設定処理
                            this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxInc, row.StockUnitTaxPriceFl);
                        }

                    }
                }
            }
		}

		/// <summary>
		/// 指定した仕入商品区分を元に、仕入明細データ行オブジェクトに関連する項目を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="stockGoodsCd">仕入商品区分</param>
		public void StockDetailRowStockGoodsCdSetting(int stockRowNo, int stockGoodsCd)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード
			int taxFracProcCd = 0;
			double taxFracProcUnit = 0;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

			if (row != null)
			{
				switch (stockGoodsCd)
				{
					#region ●商品
					// 仕入商品区分 = 0:商品
					case 0:
						{
							if (( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ))    // 行値引き
							{
								//row.StockCountDisplay = 1;
								//row.StockCount = 1;
								// 総額表示しない
								if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
								{
									row.StockPriceTaxExc = row.StockPriceDisplay;
									row.StockPriceTaxInc = row.StockPriceDisplay + CalculateTax.GetTaxFromPriceExc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, row.StockPriceDisplay);
								}
								// 総額表示
								else
								{
									row.StockPriceTaxExc = row.StockPriceDisplay - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, row.StockPriceDisplay);
									row.StockPriceTaxInc = row.StockPriceDisplay;
								}
								row.StockPriceConsTax = (long)( (decimal)row.StockPriceTaxInc - (decimal)row.StockPriceTaxExc );
								//row.StockUnitPriceFl = row.StockPriceTaxExc;
								//row.StockUnitTaxPriceFl = row.StockPriceTaxInc;
								row.StockGoodsCd = stockGoodsCd;
								row.CanTaxDivChange = false;
								row.EditStatus = ctEDITSTATUS_RowDiscount;
							}
							// 基本動作
							else
							{
								int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
								long stockPriceRealValue = row.StockPriceDisplay * sign;

								// 総額表示しない
								if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
								{
									switch (row.TaxationCode)
									{
										case (int)CalculateTax.TaxationCode.TaxInc:
											row.StockPriceTaxExc = stockPriceRealValue - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceRealValue);
											row.StockPriceTaxInc = stockPriceRealValue;
											break;
										case (int)CalculateTax.TaxationCode.TaxExc:
											row.StockPriceTaxExc = stockPriceRealValue;
											row.StockPriceTaxInc = stockPriceRealValue + CalculateTax.GetTaxFromPriceExc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceRealValue);
											break;
										case (int)CalculateTax.TaxationCode.TaxNone:
											row.StockPriceTaxExc = stockPriceRealValue;
											row.StockPriceTaxInc = stockPriceRealValue;
											break;
									}
								}
								// 総額表示
								else
								{
									row.StockPriceTaxExc = stockPriceRealValue - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceRealValue);
									row.StockPriceTaxInc = stockPriceRealValue;
								}
								row.StockPriceConsTax = (long)( (decimal)row.StockPriceTaxInc - (decimal)row.StockPriceTaxExc );
								row.StockUnitPriceDisplay = 0;
                                this.ClearStockDetailRateInfo(row, false);
								row.StockUnitPriceFl = 0;
								row.StockUnitTaxPriceFl = 0;
								row.StockRate = 0;
                                // 変更前単価と異なる場合は単価変更区分に1をセット
                                row.StockUnitChngDiv = ( row.StockUnitPriceFl != row.BfStockUnitPriceFl ) ? 1 : 0;
                                row.StockPriceDiectInput = true;
                            }
							break;
						}
					#endregion

					#region ●商品外
					// 仕入商品区分 = 1:商品外
					case 1:								
						{
                            if (string.IsNullOrEmpty(row.GoodsName))
                            {
                                this.ClearStockDetailRow(row.StockRowNo);
                            }
                            else
                            {
                                if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                                {
                                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxExc;
                                }
                                else
                                {
                                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                                }

                                row.StockGoodsCd = stockGoodsCd;
                                row.EditStatus = ctEDITSTATUS_AllOK;
                                row.CanTaxDivChange = true;
                            }

							break;
						}
					#endregion

					#region ●消費税調整、買掛用消費税調整
					case 2:	// 仕入商品区分 = 2:消費税調整
					case 4:	// 仕入商品区分 = 4:買掛用消費税調整
						{
							if (row.StockPriceDisplay == 0)
							{
								this.ClearStockDetailRow(row.StockRowNo);
							}
							else
							{
								row.GoodsName = "消費税調整";
								row.TaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
								if (this._stockSlip.SupplierSlipCd == 20)
								{
									row.StockCount = -1;
								}
								else
								{
									row.StockCount = 1;
								}
								row.StockCountDisplay = 1;
								row.StockGoodsCd = stockGoodsCd;
								row.StockUnitTaxPriceFl = 0;
								row.StockPriceTaxInc = 0;
								//salesTempRow.TaxAdjust = salesTempRow.StockPriceDisplay;
								row.StockPriceConsTax = row.StockPriceDisplay;
								row.CanTaxDivChange = false;
								row.EditStatus = ctEDITSTATUS_AllOK;
							}
							break;
						}
					#endregion

					#region ●残高調整、買掛用残高調整
					case 3:								// 仕入商品区分 = 3:残高調整
					case 5:								// 仕入商品区分 = 5:買掛用残高調整
						{
							if (row.StockPriceDisplay == 0)
							{
								this.ClearStockDetailRow(row.StockRowNo);
							}
							else
							{
								row.GoodsName = "残高調整";
								if (this._stockSlip.SupplierSlipCd == 20)
								{
									row.StockCount = -1;
								}
								else
								{
									row.StockCount = 1;
								}
								row.StockCountDisplay = 1;
								row.StockUnitPriceFl = 0;
								row.StockUnitTaxPriceFl = 0;
								row.StockPriceTaxExc = 0;
								row.StockPriceTaxInc = row.StockPriceDisplay;
								row.StockGoodsCd = stockGoodsCd;
								//salesTempRow.BalanceAdjust = salesTempRow.StockPriceDisplay;
								row.TaxationCode = (int)CalculateTax.TaxationCode.TaxExc;
								row.CanTaxDivChange = false;
								row.EditStatus = ctEDITSTATUS_AllOK;
							}
							break;
						}
					#endregion

					#region ●合計入力
					// 仕入商品区分 = 6:合計入力
					case 6:                                     
						if (row.StockPriceDisplay == 0)
						{
							this.ClearStockDetailRow(row.StockRowNo);
						}
						else
						{
                            int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

							row.GoodsName = "合計入力";

							// 数量(通常は1,返品時は-1)
                            row.StockCountDisplay = sign;
							row.StockCount = row.StockCountDisplay;

                            long stockPriceDisplayRealValue = row.StockPriceDisplay * sign;

                            // 非課税の仕入先は非課税扱い
                            if (this._stockSlip.SuppCTaxLayCd == 9)
                            {
                                row.TaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                                row.StockPriceTaxExc = stockPriceDisplayRealValue;
                                row.StockPriceTaxInc = stockPriceDisplayRealValue;
                                row.StockPriceDisplay = row.StockPriceTaxExc;
                            }
                            // 総額表示しない場合、外税扱い
							else if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
							{
								row.TaxationCode = (int)CalculateTax.TaxationCode.TaxExc;
                                row.StockPriceTaxExc = stockPriceDisplayRealValue;
                                row.StockPriceTaxInc = stockPriceDisplayRealValue + CalculateTax.GetTaxFromPriceExc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceDisplayRealValue);
                                row.StockPriceDisplay = row.StockPriceTaxExc;
							}
							// 総額表示する場合、内税扱い
							else
							{
								row.TaxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                                row.StockPriceTaxExc = stockPriceDisplayRealValue - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceDisplayRealValue);
                                row.StockPriceTaxInc = stockPriceDisplayRealValue;
                                row.StockPriceDisplay = row.StockPriceTaxInc;
                            }
							row.StockPriceConsTax = (long)( (decimal)row.StockPriceTaxInc - (decimal)row.StockPriceTaxExc );
                            row.StockPriceDisplay = row.StockPriceDisplay * sign;

							row.StockUnitPriceFl = 0;
							row.StockUnitTaxPriceFl = 0;
							row.StockUnitPriceDisplay = 0;
							row.StockGoodsCd = stockGoodsCd;
                            // 変更前単価と異なる場合は単価変更区分に1をセット
                            row.StockUnitChngDiv = ( row.StockUnitPriceFl != row.BfStockUnitPriceFl ) ? 1 : 0;
                            row.CanTaxDivChange = false;
							row.EditStatus = ctEDITSTATUS_AllOK;
						}
						break;
					#endregion
				}
			}
		}

		/// <summary>
		/// 仕入明細行オブジェクトの発注残数の値を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		public void StockDetailRowOrderRemainCntSetting(int stockRowNo)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row == null) return;

			row.OrderRemainCnt = ( this._stockSlip.SupplierFormal == 0 ) ? 0 : row.StockCountDisplay;
		}

		/// <summary>
		/// 仕入明細行オブジェクトの数量を設定します。
		/// </summary>
		/// <param name="stockRowNo">仕入行番号</param>
		public void StockDetailRowStockCountSetting( int stockRowNo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row == null) return;

			double stockCountRealValue = row.StockCountDisplay;
			if (this._stockSlip.SupplierSlipCd == 20)
			{
				stockCountRealValue *= -1;
			}

			double adjustCnt;

			// 新規登録行の場合
			if (row.StockSlipDtlNum == 0)
			{
				adjustCnt = stockCountRealValue;
				row.StockCount = adjustCnt;					// 仕入数←画面仕入数
				row.OrderAdjustCnt = 0;						// 調整数←0
				row.OrderCnt = adjustCnt;					// 発注数←画面仕入数
				row.OrderRemainCnt = adjustCnt;				// 発注残←画面仕入数
			}
			// 修正行の場合
			else
			{
				//adjustCnt = row.StockCountDisplay - row.StockCount;			// 入力前との差分を計算する
				adjustCnt = stockCountRealValue - row.StockCount;			// 入力前との差分を計算する
				row.StockCount = stockCountRealValue;						// 仕入数←画面仕入数
                row.OrderAdjustCnt = row.OrderAdjustCnt + adjustCnt;		// 調整数←調整数+差分
				row.OrderRemainCnt = row.OrderRemainCnt + adjustCnt;		// 発注残←発注残+差分
			}

            // 在庫品の場合は数量調整
			if (!( string.IsNullOrEmpty(row.WarehouseCode.Trim()) ))
			{
                this.StockDetailStockInfoAdjust(row.WarehouseCode.Trim(), row.GoodsNo.Trim(), row.GoodsMakerCd);
			}
		}

		/// <summary>
		/// 仕入形式、計上元情報から、表示している現在庫数が、在庫マスタ上の現在庫数と変わるかチェックします。
		/// </summary>
		/// <param name="stockDetailRow"></param>
		/// <returns></returns>
		public bool SupplierStockCountChangeCheck( StockInputDataSet.StockDetailRow stockDetailRow )
		{
			bool ret = true;

            // 値引きデータは反映させない
            if (stockDetailRow.StockSlipCdDtl == 2)
            {
                ret = false;
            }
			// 計上元の明細が無い場合は単純に数量を反映させる（新規仕入(返品含む)、新規入荷(返品含む))
			else if ( stockDetailRow.StockSlipDtlNumSrc == 0 )
			{
				ret = true;
			}
			else
			{
				StockInputDataSet.AddUpSrcDetailRow addUpSrcDetailRow = this.GetAddUpSrcDataRow(stockDetailRow);

				if (addUpSrcDetailRow != null)
				{
					// 仕入形式が計上元明細と同じ場合(元伝有りの返品、赤伝)
					if (this._stockSlip.SupplierFormal == addUpSrcDetailRow.SupplierFormal)
					{
						// 入荷計上に対する赤伝、返品は、在庫数は在庫から取得した値のまま
						if (( addUpSrcDetailRow.StockSlipDtlNumSrc != 0 ) && ( addUpSrcDetailRow.SupplierFormalSrc == 1 ))
						{
							ret = false;
						}
					}
					// 計上、引当の場合
					else
					{
						// 入荷計上の場合、在庫数は在庫から取得した値のまま
						if (addUpSrcDetailRow.SupplierFormal == 1)
						{
							ret = false;
						}
					}
				}
			}

			return ret;
		}

		/// <summary>
		/// 仕入明細行オブジェクトの計上可能数量の値を設定します。
		/// </summary>
		public void StockDetailRowAddUpEnableCountSetting()
		{
			if (this._stockSlip.DebitNoteDiv != 0)
			{
				return;
			}
            int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable.Rows)
			{
				row.StockCountMin = (double)((decimal)row.StockCount - (decimal)row.OrderRemainCnt);	// 計上済み数量 = 明細の仕入数量 - 発注残

				if (row.StockSlipDtlNumSrc == 0) continue;

				StockInputDataSet.AddUpSrcDetailRow addUpSrcDetailRow = this.GetAddUpSrcDataRow(row);

				if (addUpSrcDetailRow != null)
				{
                    row.StockCountMax = (double)( (decimal)( row.StockCount * sign ) + (decimal)addUpSrcDetailRow.OrderRemainCnt ) * sign; // 計上可能数量 = 明細の仕入数(絶対値) + 計上元の発注残
				}
				else
				{
					row.StockCountMax = row.StockCount;										// 計上可能数量 = 明細の仕入数(絶対値)
				}
			}
		}

		/// <summary>
		/// 指定した仕入総額表示方法区分を元に、仕入明細データオブジェクトの課税区分を設定します。
		/// </summary>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード</param>
		/// <param name="suppTtlAmntDspWayCd">仕入先総額表示方法区分</param>
        public void StockDetailRowTaxationCodeSetting(int suppCTaxLayCd, int suppTtlAmntDspWayCd)
        {
            for (int i = 0; i < this._stockDetailDataTable.Rows.Count; i++)
            {
                StockInputDataSet.StockDetailRow row = (StockInputDataSet.StockDetailRow)this._stockDetailDataTable.Rows[i];

                
                // 行値引き分の課税区分を補正
                //if (( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ))
                //if (( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ))
                if (( row.StockCountDisplay == 0 ) && ( row.StockPriceDisplay != 0 ))
                {
                    // 非課税の仕入先は値引きも非課税にする
                    if (suppCTaxLayCd == 9)
                    {
                        row.TaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    else
                    {
                        // 総額表示しない場合は外税、総額表示する場合は内税
                        row.TaxationCode = ( suppTtlAmntDspWayCd == 0 ) ? (int)CalculateTax.TaxationCode.TaxExc : (int)CalculateTax.TaxationCode.TaxInc;
                    }
                }

                row.TaxDiv = row.TaxationCode;
                this.StockDetailRowTaxationCodeSetting(suppCTaxLayCd, suppTtlAmntDspWayCd, row);

                // 行値引きの場合は単価ゼロ
                if (( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ))
                {
                    row.StockUnitPriceDisplay = 0;
                }
            }
        }

        /// <summary>
        /// 指定した転嫁方式、仕入総額表示方法区分を元に、仕入明細データオブジェクトの課税区分を設定します。
        /// </summary>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード</param>
        /// <param name="suppTtlAmntDspWayCd">総額表示区分</param>
        /// <param name="row">仕入明細行オブジェクト</param>
        private void StockDetailRowTaxationCodeSetting(int suppCTaxLayCd, int suppTtlAmntDspWayCd, StockInputDataSet.StockDetailRow row)
        {
            if (suppCTaxLayCd == 9)
            {
                row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                row.StockPriceDisplay = row.StockPriceTaxExc;
            }
            else if (suppTtlAmntDspWayCd == 0)
            {
                switch (row.TaxationCode)
                {
                    case (int)CalculateTax.TaxationCode.TaxExc:
                    case (int)CalculateTax.TaxationCode.TaxNone:
                        {
                            row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;
                            row.StockPriceDisplay = row.StockPriceTaxExc;
                            break;
                        }
                    case (int)CalculateTax.TaxationCode.TaxInc:
                        {
                            row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            row.StockPriceDisplay = row.StockPriceTaxInc;
                            break;
                        }
                }
            }
            else
            {
                row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                row.StockPriceDisplay = row.StockPriceTaxInc;
            }
        }

		/// <summary>
		/// 指定した消費税率を元に仕入明細データ行オブジェクトの金額情報を更新します。
		/// </summary>
		/// <param name="taxRate">消費税率</param>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード</param>
        public void StockDetailRowTaxRateChanged(double taxRate, int suppCTaxLayCd)
		{
			// 仕入金額端数処理コード
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd); 
			// 消費税端数処理区分
			int taxFracProcCode = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd); 

			for (int i = 0; i < this._stockDetailDataTable.Rows.Count; i++)
			{
				StockInputDataSet.StockDetailRow row = (StockInputDataSet.StockDetailRow)this._stockDetailDataTable.Rows[i];

                // 非課税時は税込金額＝税抜き金額
                if (suppCTaxLayCd == 9)
                {
                    row.StockPriceTaxInc = row.StockPriceTaxExc;
                    row.StockUnitTaxPriceFl = row.StockUnitPriceFl;
                }
				else if (row.StockGoodsCd == 6)
				{
					this.CalculateStockPrice(row);
				}
				else
				{
                    // 課税区分が「外税」の場合
                    if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        long stockPriceTaxInc;
                        long stockPriceTaxExc;
                        long stockPriceConsTax;
                        double stockUnitPrice = row.StockUnitPriceFl;

                        if (this.CalculateStockPrice(
                            row.StockCountDisplay,
                            stockUnitPrice,
                            row.TaxationCode,
                            taxRate,
                            stockMoneyFrcProcCd,
                            taxFracProcCode,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax))
                        {
                            if (row.StockGoodsCd <= 1)
                            {
                                row.StockPriceTaxInc = stockPriceTaxInc;
                            }
                        }
                    }
                    // 課税区分が「内税」の場合
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        long stockPriceTaxInc;
                        long stockPriceTaxExc;
                        long stockPriceConsTax;
                        double stockUnitPrice = row.StockUnitPriceFl;

                        if (this.CalculateStockPrice(
                            row.StockCountDisplay,
                            stockUnitPrice,
                            row.TaxationCode,
                            taxRate,
                            stockMoneyFrcProcCd,
                            taxFracProcCode,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax))
                        {
                            if (row.StockGoodsCd <= 1)
                            {
                                row.StockPriceTaxExc = stockPriceTaxExc;
                            }
                        }
                    }
				}
			}
		}

		/// <summary>
		/// 仕入明細データテーブルの仕入行番号を初期化（再採番）します。
		/// </summary>
		public void InitializeStockDetailStockRowNoColumn()
		{
			this._stockDetailDataTable.BeginLoadData();
			for (int i = 0; i < this._stockDetailDataTable.Rows.Count; i++)
			{
                int oldStockRowNo = this._stockDetailDataTable[i].StockRowNo;
				this._stockDetailDataTable[i].StockRowNo = i + 1;
            }
			this._stockDetailDataTable.EndLoadData();
        }

		/// <summary>
		/// 仕入明細データテーブルの行ステータス列の値を初期化します。
		/// </summary>
		public void InitializeStockDetailRowStatusColumn()
		{
			StockInputDataSet.StockDetailRow[] rows = (StockInputDataSet.StockDetailRow[])this._stockDetailDataTable.Select(this._stockDetailDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

			this._stockDetailDataTable.BeginLoadData();
			foreach (StockInputDataSet.StockDetailRow row in rows)
			{
				row.RowStatus = 0;
			}
			this._stockDetailDataTable.EndLoadData();
		}

		/// <summary>
		/// 指定した仕入行番号のリストを元に、該当する仕入明細行オブジェクトの行ステータスに値を設定します。
		/// </summary>
		/// <param name="stockRowNoList">仕入明細行番号リスト</param>
		/// <param name="rowStatus">RowStatus値</param>
		public void SetStockDetailRowStatusColumn(List<int> stockRowNoList, int rowStatus)
		{
			this._stockDetailDataTable.BeginLoadData();
			foreach (int stockRowNo in stockRowNoList)
			{
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

                if (( string.IsNullOrEmpty(row.GoodsName) ) && ( string.IsNullOrEmpty(row.GoodsNo) )) continue;

				row.RowStatus = rowStatus;
			}
			this._stockDetailDataTable.EndLoadData();
		}

		/// <summary>
		/// 仕入明細データテーブルにコピー行が存在するかどうかをチェックします。
		/// </summary>
		/// <returns>true:コピーデータが存在する false:存在しない</returns>
		public bool ExistCopyStockDetailRow()
		{
			object value = this._stockDetailDataTable.Compute("COUNT(" + this._stockDetailDataTable.RowStatusColumn.ColumnName + ")", this._stockDetailDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());
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
		/// 仕入明細データテーブルにコピー行の仕入行番号リストを取得します。
		/// </summary>
		/// <returns>仕入行番号リスト</returns>
		public List<int> GetCopyStockDetailRowNo()
		{
			StockInputDataSet.StockDetailRow[] rows = (StockInputDataSet.StockDetailRow[])this._stockDetailDataTable.Select(this._stockDetailDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

			if ((rows != null) && (rows.Length > 0))
			{
				List<int> stockRowNoList = new List<int>();
				foreach (StockInputDataSet.StockDetailRow row in rows)
				{
					stockRowNoList.Add(row.StockRowNo);
				}

				return stockRowNoList;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 指定したインデックスの仕入明細データ行に対して行貼り付けを行う際、確認が必要かどうかをチェックします。
		/// </summary>
		/// <param name="copyStockRowNoList">コピー行仕入行番号リスト</param>
		/// <param name="pasteIndex">貼り付け行Index</param>
		/// <returns>0:チェック不要 1:チェック必要 2:貼り付け不可</returns>
		public int CheckPasteStockDetailRow(List<int> copyStockRowNoList, int pasteIndex)
		{
			int check = 0;
			int pasteStockRowNo = this._stockDetailDataTable[pasteIndex].StockRowNo;

			for (int i = 0; i < copyStockRowNoList.Count; i++)
			{
				StockInputDataSet.StockDetailRow sourceRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, copyStockRowNoList[i]);

				if (sourceRow == null)
				{
					continue;
				}

				StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, pasteStockRowNo + i);

				if (row != null)
				{
					if (( row.EditStatus != ctEDITSTATUS_AllOK ) && ( row.EditStatus != ctEDITSTATUS_RowDiscount ) && ( row.EditStatus != ctEDITSTATUS_GoodsDiscount ))
					{
						check = 2;
						break;
					}
                    else if (this.ExistStockDetailInput(row))
                    {
                        check = 1;
                    }
				}
			}
			
			return check;
		}

		/// <summary>
		/// 仕入明細データ行オブジェクトの貼り付けを行います。
		/// </summary>
		/// <param name="copyStockRowNoList">コピー行仕入行番号リスト</param>
		/// <param name="pasteIndex">貼り付け行Index</param>
		public void PasteStockDetailRow(List<int> copyStockRowNoList, int pasteIndex)
		{
			int pasteTargetStockRowNo = this._stockDetailDataTable[pasteIndex].StockRowNo;

			this._stockDetailDataTable.BeginLoadData();
			List<int> cutStockRowNoList = new List<int>();
			List<int> pasteStockRowNoList = new List<int>();
			List<int> deleteStockRowNoList = new List<int>();
			List<StockInputDataSet.StockDetailRow> copyStockRowList = new List<StockInputDataSet.StockDetailRow>();

			foreach (int stockRowNo in copyStockRowNoList)
			{
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

				if (row != null)
				{
					copyStockRowList.Add(this.CloneStockDetailRow(row));

					if (row.RowStatus == ctROWSTATUS_CUT)
					{
						cutStockRowNoList.Add(row.StockRowNo);
                    }
				}
			}

			if (cutStockRowNoList.Count > 0)
			{
				// 仕入明細行クリア処理
				for (int i = 0; i < cutStockRowNoList.Count; i++)
				{
                    this.ClearStockDetailRow(this.GetStockDetailRow(cutStockRowNoList[i]));
				}
			}

			for (int i = 0; i < copyStockRowList.Count; i++)
			{
				StockInputDataSet.StockDetailRow sourceRow = copyStockRowList[i];
				StockInputDataSet.StockDetailRow targetRow = null;

				//this.AddStockDetailRow();
				if (( pasteIndex + i ) < this._stockDetailDataTable.Count)
				{


					targetRow = this._stockDetailDataTable[pasteIndex + i];

					this.CopyStockDetailRow(sourceRow, targetRow);

					// コピー＆ペーストの場合、計上情報、同時入力明細情報をクリアする
					if (!cutStockRowNoList.Contains(copyStockRowList[i].StockRowNo))
					{
						targetRow.CommonSeqNo = 0;			// 共通通番
						targetRow.StockSlipDtlNum = 0;		// 明細通番
						targetRow.SupplierFormalSrc = 0;	// 仕入形式（元）
						targetRow.StockSlipDtlNumSrc = 0;	// 仕入明細通番（元）
						targetRow.AcptAnOdrStatusSync = 0;	// 受注ステータス（同時）
						targetRow.SalesSlipDtlNumSync = 0;	// 売上明細通番（同時）
						//targetRow.StockSlipCdDtl = 0;		// 仕入伝票区分（明細）
						targetRow.StockCountDefault = 0;
						targetRow.StockCountMax = 0;
						targetRow.StockCountMin = 0;
						targetRow.DtlRelationGuid = Guid.Empty;
						targetRow.EditStatus = ( targetRow.StockSlipCdDtl == 2 ) ? ctEDITSTATUS_RowDiscount : ctEDITSTATUS_AllOK;

						this.MemoInfoAdjust(ref targetRow);
					}

					pasteStockRowNoList.Add(targetRow.StockRowNo);
				}
			}
			this._stockDetailDataTable.EndLoadData();

			// 不要な行を削除する
			this.DeleteStockDetailRow(deleteStockRowNoList, true);

            //// 最終行に商品名称が設定されている場合は１行追加
            //if (this.ExistStockDetailInput(this._stockDetailDataTable[this._stockDetailDataTable.Count - 1]))
            //{
            //    this.AddStockDetailRow();
            //}
		}

        /// <summary>
        /// 仕入明細行に行挿入可能かどうかチェックします。
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true:挿入可能 false:挿入不可</returns>
        public bool InsertStockDetailRowCheck(out string message)
        {
            message = string.Empty;
            StockInputDataSet.StockDetailRow row = (StockInputDataSet.StockDetailRow)this._stockDetailDataTable.Rows[this._stockDetailDataTable.Rows.Count - 1];

            if (row != null)
            {
                if (this.ExistStockDetailInput(row))
                {
                    message = "最終行が入力済みの為、行挿入できません。";
                    return false;
                }
            }
            return true;
        }

		/// <summary>
		/// 削除しようとする仕入明細行オブジェクトが削除可能かどうかをチェックします。
		/// </summary>
		/// <param name="stockRowNoList">削除対象仕入行番号リスト</param>
		/// <param name="message">メッセージ（out）</param>
		/// <returns>true:削除可能 false:削除不可</returns>
		public bool DeleteStockDetailRowCheck(List<int> stockRowNoList, out string message)
		{
			bool canDelete = true;
			bool exist = false;
			message = string.Empty;

			// 削除行の存在チェック
			int lastInputStockRowNo = this.GetLastInputStockRowNo();

			foreach (int stockRowNo in stockRowNoList)
			{
				if (stockRowNo < lastInputStockRowNo)
				{
					exist = true;
					break;
				}
			}

            if (!exist)
            {
                foreach (int stockRowNo in stockRowNoList)
                {
                    StockInputDataSet.StockDetailRow row = this._dataSet.StockDetail.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

                    if (( row != null ) && ( ( !string.IsNullOrEmpty(row.GoodsName.Trim()) ) || ( !string.IsNullOrEmpty(row.GoodsNo.Trim()) ) || ( row.EditStatus == ctEDITSTATUS_GoodsDiscount ) ))
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
				foreach (int stockRowNo in stockRowNoList)
				{
					StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

					if ((row != null) && (row.EditStatus == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly))
					{
						message = "削除不可行が存在する為、削除できません。";
						canDelete = false;
						break;
					}

					if ((row != null) && (row.StockCountMin != 0))
					{
						message = "「返品」もしくは「計上」されている為、削除できません。";
						canDelete = false;
						break;
					}
				}
			}

			return canDelete;
		}

		/// <summary>
		/// 仕入明細行オブジェクトの削除を行います。
		/// </summary>
		/// <param name="stockRowNoList">削除行StockRowNoリスト</param>
		public void DeleteStockDetailRow(List<int> stockRowNoList)
		{
			this.DeleteStockDetailRow(stockRowNoList, false);
		}

		/// <summary>
		/// 仕入明細行オブジェクトの削除を行います。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNoList">削除行StockRowNoリスト</param>
		/// <param name="changeRowCount">true:行数を変更する false:行数を変更するは変更しない</param>
		public void DeleteStockDetailRow(List<int> stockRowNoList, bool changeRowCount)
		{
			if (stockRowNoList.Count == 0) return;

			this._stockDetailDataTable.BeginLoadData();
			foreach (int stockRowNo in stockRowNoList)
			{
                StockInputDataSet.StockDetailRow targetRow = this.GetStockDetailRow(stockRowNo);

				if (targetRow == null) continue;

                // 在庫行の場合
                if (!string.IsNullOrEmpty(targetRow.WarehouseCode))
                {
                    if (targetRow.StockSlipDtlNum != 0)
                    {
                        if (this.SupplierStockCountChangeCheck(targetRow))
                        {
                            this.StockInfoAdjustCountSetting(targetRow.WarehouseCode, targetRow.GoodsNo, targetRow.GoodsMakerCd, ( ( targetRow.StockCountDefault != 0 ) ? targetRow.StockCountDefault : targetRow.StockCount ) * -1);
                        }
                    }
                }

				// 売上同時計上情報削除
				this.DeleteSalesTempRow(targetRow.DtlRelationGuid);

				// 計上元明細オブジェクトを削除
				this.DeleteAddUpSrcDetail(targetRow);

				this._stockDetailDataTable.RemoveStockDetailRow(targetRow);
			}

			// 仕入明細データテーブルStockRowNo列初期化処理
			this.InitializeStockDetailStockRowNoColumn();

			if (!changeRowCount)
			{
				// 削除した分だけ新規に行を追加する
				for (int i = 0; i < stockRowNoList.Count; i++)
				{
					this.AddStockDetailRow();
				}
			}
			this._stockDetailDataTable.EndLoadData();
        }

		/// <summary>
		/// 仕入明細行オブジェクトに連結する計上元仕入明細行オブジェクトを取得します。
		/// </summary>
		/// <param name="stockDetailRow">仕入明細行オブジェクト</param>
		private StockInputDataSet.AddUpSrcDetailRow GetAddUpSrcDataRow( StockInputDataSet.StockDetailRow stockDetailRow )
		{
			DataRow[] dataRows = stockDetailRow.GetChildRows(cRelation_Detail_AddUpSrcDetail);
			if (dataRows == null) return null;

			foreach (StockInputDataSet.AddUpSrcDetailRow row in dataRows)
			{
				return row;
			}

			return null;
		}

		/// <summary>
		/// 仕入明細行オブジェクトに連結する計上元明細行オブジェクトを全て削除します。
		/// </summary>
		/// <param name="stockDetailRow">仕入明細行オブジェクト</param>
		private void DeleteAddUpSrcDetail( StockInputDataSet.StockDetailRow stockDetailRow )
		{

			DataRow[] dataRows = stockDetailRow.GetChildRows(cRelation_Detail_AddUpSrcDetail);
			if (dataRows == null) return;

			foreach (StockInputDataSet.AddUpSrcDetailRow row in dataRows)
			{
				this._addUpSrcDetailDataTable.RemoveAddUpSrcDetailRow(row);
			}
		}

		/// <summary>
		/// 仕入明細行オブジェクトの追加を行います。
		/// </summary>
		public void AddStockDetailRow()
		{
			int rowCount = this._stockDetailDataTable.Rows.Count;

			StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.NewStockDetailRow();
			row.SupplierSlipNo = this._currentSupplierSlipNo;
			row.StockRowNo = rowCount + 1;
			row.DtlRelationGuid = Guid.Empty;
			this._stockDetailDataTable.AddStockDetailRow(row);
		}

        /// <summary>
        /// 仕入明細データテーブルに初期表示行数分の行を追加します。
        /// </summary>
        public void AddStockDetailRowInitialRowCount()
		{
            StockInputDataSet.StockDetailRow[] stockDetailRowArray = this.SelectStockDetailRows(string.Empty, this._stockDetailDataTable);

			int count = 1;
			if ((stockDetailRowArray != null) && (stockDetailRowArray.Length > 0))
			{
				count = stockDetailRowArray.Length;
			}

			StockSlipInputConstructionAcs stockSlipInputConstructionAcs = StockSlipInputConstructionAcs.GetInstance();

			if (count < stockSlipInputConstructionAcs.DataInputCountValue)
			{
				for (int i = count; i < stockSlipInputConstructionAcs.DataInputCountValue; i++)
				{
					this.AddStockDetailRow();
				}
			}
			else
			{
				//this.AddStockDetailRow();
			}
		}


		/// <summary>
		/// 表示用の仕入行番号を再採番します。
		/// </summary>
		public void AdjustRowNo()
		{
			int no = 1;
			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
			{
                if ( row != null )
                {
                    row.StockRowNoDisplay = no;
                    no++;
                }
            }
		}

		/// <summary>
		/// 仕入明細行オブジェクトの挿入を行います。
		/// </summary>
		/// <param name="insertIndex">挿入行Index</param>
		public void InsertStockDetailRow(int insertIndex)
		{
            this.InsertStockDetailRow(insertIndex, 1);
		}

		/// <summary>
		/// 仕入明細行オブジェクトの挿入を行います。（オーバーロード）
		/// </summary>
		/// <param name="insertIndex">挿入行Index</param>
		/// <param name="line">挿入段数</param>
        public void InsertStockDetailRow( int insertIndex, int line )
        {
            if (line == 0) return;

            this._stockDetailDataTable.BeginLoadData();
            int lastRowIndex = this._stockDetailDataTable.Rows.Count - 1;
            int stockRowNo = this._stockDetailDataTable[insertIndex].StockRowNo;

            StockSlipInputConstructionAcs stockSlipInputConstructionAcs = StockSlipInputConstructionAcs.GetInstance();

            // 仕入明細行追加処理
            for (int i = 0; i < line; i++)
            {
                if (this._stockDetailDataTable.Rows.Count < stockSlipInputConstructionAcs.DataInputCountValue)
                {
                    this.AddStockDetailRow();
                }
            }

            // 最終行から挿入対象行までの行情報を指定段ずつ下にコピーする
            for (int i = lastRowIndex; i >= insertIndex; i--)
            {
                if (( i + line ) < this._stockDetailDataTable.Rows.Count)
                {
                    StockInputDataSet.StockDetailRow sourceRow = this.GetStockDetailRow(this._stockDetailDataTable[i].StockRowNo);
                    StockInputDataSet.StockDetailRow targetRow = this.GetStockDetailRow(this._stockDetailDataTable[i + line].StockRowNo);

                    this.CopyStockDetailRow(sourceRow, targetRow);
                }
            }

            // 挿入対象行をクリアする
            StockInputDataSet.StockDetailRow clearRow = this.GetStockDetailRow(this._stockDetailDataTable[insertIndex].StockRowNo);
            this.ClearStockDetailRow(clearRow);
            this._stockDetailDataTable.EndLoadData();
        }

		/// <summary>
		/// 行取得処理
		/// </summary>
		/// <param name="stockRowNo"></param>
		/// <returns></returns>
        /// <br>Update Note : 2013/01/08 鄭慕鈞</br>
        /// <br>管理番号    : 10801804-00 2013/03/13配信分</br>
        /// <br>            : redmine#31984 仕入伝票入力の操作便利の対応</br>
		public StockInputDataSet.StockDetailRow GetStockDetailRow( int stockRowNo )
		{
            //----ADD  2013/01/08 Readmine#31984  鄭慕鈞  ----->>>>>
            //設定画面の保存後の初期化を「しない」に設定した場合、明細グリッドに前回発行した仕入伝票の仕入SEQ番号のクリア処理を追加する
            //クリア処理範囲は赤伝以外
            if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF && this._stockSlip.SupplierSlipNo == 0 && this._stockSlip.DebitNoteDiv!=1)
            {
                foreach (DataRow row in this._stockDetailDataTable)
                {
                    row[this._stockDetailDataTable.SupplierSlipNoColumn] = 0;
                }
            }
            //----ADD  2013/01/08 Readmine#31984  鄭慕鈞  -----<<<<<
			return this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._currentSupplierSlipNo, stockRowNo);
		}

		/// <summary>
		/// 商品名称が入力されている仕入明細行オブジェクトが存在するかどうかをチェックします。
		/// </summary>
		/// <returns>true:存在する false:存在しない</returns>
		public bool ExistStockDetailData()
		{
			bool exist = false;

			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
			{
                if (this.ExistStockDetailInput(row))
                {
                    exist = true;
                    break;
                }
			}

			return exist;
		}

        // ----ADD 2010/12/03----->>>>>
        /// <summary>
        /// いずれかの明細行に数量のマイナス入力が存在するかどうかをチェックします。
        /// </summary>
        /// <returns>true:存在する false:存在しない</returns>
        public bool ExistStockMaitasuData()
        {
            bool exist = false;

            foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            {
                if (row.StockCountDisplay < 0)
                {
                    exist = true;
                    break;
                }
            }

            return exist;
        }
        // ----ADD 2010/12/03-----<<<<<

        /// <summary>
        /// 仕入明細行がデータ入力済みかチェックします。
        /// </summary>
        /// <returns></returns>
        public bool ExistStockDetailInput(StockInputDataSet.StockDetailRow row)
        {
            return ( ( !string.IsNullOrEmpty(row.GoodsName) ) || ( !string.IsNullOrEmpty(row.GoodsNo) ) );
        }

		/// <summary>
		/// 入荷計上対象の仕入明細行オブジェクトが存在するかどうかをチェックします。
		/// </summary>
		/// <returns>true:存在する false:存在しない</returns>
		public bool ExistArrivalAppropriateDetail()
		{
            //bool exist = false;

            StockInputDataSet.StockDetailRow[] rows = this.SelectStockDetailRows(string.Format("{0}=1 AND {1}<>0",
                this._stockDetailDataTable.SupplierFormalSrcColumn.ColumnName,
                this._stockDetailDataTable.StockSlipDtlNumSrcColumn.ColumnName), this._stockDetailDataTable);


            return ( ( rows != null ) && ( rows.Length > 0 ) );
            //foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            //{
            //    if (( row.SupplierFormalSrc == 1 ) && ( row.StockSlipDtlNumSrc != 0 ))
            //    {
            //        exist = true;
            //        break;
            //    }
            //}

            //return exist;
		}

        /// <summary>
        /// 計上（元明細がある）行の存在チェックを行います。
        /// </summary>
        /// <returns>true:存在する false:存在しない</returns>
        public bool ExistAddUpDetail()
        {
            StockInputDataSet.StockDetailRow[] rows = this.SelectStockDetailRows(string.Format("{0}<>0", 
                this._stockDetailDataTable.StockSlipDtlNumSrcColumn.ColumnName), this._stockDetailDataTable);

            return ( ( rows != null ) && ( rows.Length > 0 ) );
        }


		/// <summary>
		/// 値引き行が仕入明細行オブジェクトが存在するかどうかをチェックします。
		/// </summary>
		/// <returns>true:存在する false:存在しない</returns>
		public bool ExistStockDetailDiscountData()
		{
			bool exist = false;

			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
			{
                if (( !string.IsNullOrEmpty(row.GoodsName) ) && ( row.StockSlipCdDtl == 2 ))
                {
                    exist = true;
                    break;
                }
			}

			return exist;
		}

		/// <summary>
		/// 商品価格の再設定を行う必要がある商品が入力されている仕入明細行オブジェクトが存在するかどうかをチェックします。
		/// </summary>
		/// <returns>true:存在する false:存在しない</returns>
		public bool ExistStockDetailCanGoodsPriceReSettingData()
		{
			bool exist = false;

            foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            {
                if (( ( row.EditStatus == ctEDITSTATUS_AllOK ) || ( row.EditStatus == ctEDITSTATUS_ArrivalAddUpEdit ) || ( row.EditStatus == ctEDITSTATUS_ArrivalAddUpNew ) ) &&
                    ( !string.IsNullOrEmpty(row.GoodsNo) ))
                {
                    exist = true;
                    break;
                }
            }

			return exist;
		}


        /// <summary>
        /// 単価変更行存在チェック
        /// </summary>
        /// <param name="stockRowNoList">単価変更行リスト</param>
        /// <returns>True:単価変更行有り</returns>
        public bool ExistStockUnitPriceChangedRows(out List<int> stockRowNoList)
        {
            stockRowNoList = new List<int>();
            if (this._stockSlip.StockGoodsCd != 0) return false;

            // 値引き、金額手入力行以外を抽出
            StockInputDataSet.StockDetailRow[] rows = this.SelectStockDetailRows(string.Format("{0}<>{1} AND NOT({2}={3} AND {4}<>{5})",
                this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2,
                this._stockDetailDataTable.StockUnitPriceFlColumn.ColumnName, 0,
                this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName, 0), this._stockDetailDataTable);

            if (( rows == null ) || ( rows.Length == 0 )) return false;

            foreach (StockInputDataSet.StockDetailRow row in rows)
            {
                // 単価の初期値がゼロの場合
                if (( row.StockUnitPriceDefault == 0 ) && ( row.StockUnitTaxPriceDefault == 0 ))
                {
                    // 単価変更区分が1のデータが変更データ
                    if (row.StockUnitChngDiv == 1)
                    {
                        stockRowNoList.Add(row.StockRowNo);
                    }
                }
                // 単価の初期値がゼロで無い場合は初期値から変更されているデータが対象データ
                else
                {
                    // 総額表示、内税品は税込金額で判断
                    if (( this._stockSlip.SuppTtlAmntDspWayCd == 0 ) ||
                        ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                    {
                        if (row.StockUnitTaxPriceDefault != row.StockUnitTaxPriceFl)
                        {
                            stockRowNoList.Add(row.StockRowNo);
                        }
                    }
                    else
                    {
                        if (row.StockUnitPriceDefault != row.StockUnitPriceFl)
                        {
                            stockRowNoList.Add(row.StockRowNo);
                        }
                    }
                }
            }

            return ( stockRowNoList.Count > 0 );
        }

        /// <summary>
        /// 金額変更行存在チェック
        /// </summary>
        /// <param name="stockRowNoList">金額変更行リスト</param>
        /// <returns>True:金額変更行有り</returns>
        public bool ExistStockPriceChangedRows(out List<int> stockRowNoList)
        {
            stockRowNoList = new List<int>();
            if (this._stockSlip.StockGoodsCd != 0) return false;

            // 値引き、単価入力行以外を抽出
            StockInputDataSet.StockDetailRow[] rows = this.SelectStockDetailRows(string.Format("{0}<>{1} AND {2}={3} AND {4}<>{5}",
                this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2,
                this._stockDetailDataTable.StockUnitPriceFlColumn.ColumnName, 0,
                this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName, 0), this._stockDetailDataTable);

            if (( rows == null ) || ( rows.Length == 0 )) return false;

            foreach (StockInputDataSet.StockDetailRow row in rows)
            {
                // 金額の初期値がゼロの場合
                if (( row.StockPriceTaxExcDefault == 0 ) && ( row.StockPriceTaxIncDefault == 0 ))
                {
                    // 無条件で対象
                    stockRowNoList.Add(row.StockRowNo);
                }
                // 単価の初期値がゼロで無い場合は初期値から変更されているデータが対象データ
                else
                {
                    // 総額表示、内税品は税込金額で判断
                    if (( this._stockSlip.SuppTtlAmntDspWayCd == 0 ) ||
                        ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                    {
                        if (row.StockPriceTaxIncDefault != row.StockPriceTaxInc)
                        {
                            stockRowNoList.Add(row.StockRowNo);
                        }
                    }
                    else
                    {
                        if (row.StockPriceTaxExcDefault != row.StockPriceTaxExc)
                        {
                            stockRowNoList.Add(row.StockRowNo);
                        }
                    }
                }
            }

            return ( stockRowNoList.Count > 0 );
        }

		/// <summary>
		/// 指定したフィルタ文字列を使用して仕入明細データテーブルの選択を行い、該当する仕入明細行オブジェクト配列を取得します。
		/// </summary>
		/// <param name="filterExpression">フィルタをかけるための基準となる文字列</param>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		/// <returns>仕入明細行オブジェクト配列</returns>
		public StockInputDataSet.StockDetailRow[] SelectStockDetailRows(string filterExpression, StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			StockInputDataSet.StockDetailRow[] stockDetailRowArray = null;

			try
			{
				DataRow[] rowArray = stockDetailDataTable.Select(filterExpression);

				if (rowArray != null)
				{
					stockDetailRowArray = (StockInputDataSet.StockDetailRow[])rowArray;
				}
			}
			catch { }

			return stockDetailRowArray;
		}

		/// <summary>
		/// 商品が入力されている最終行の仕入行番号を取得します。
		/// </summary>
		/// <returns>商品が入力されている最終行の仕入行番号</returns>
		public int GetLastInputStockRowNo()
		{
			DataRow[] rows = this._stockDetailDataTable.Select(this._stockDetailDataTable.GoodsNameColumn.ColumnName + " <> " + "''", this._stockDetailDataTable.StockRowNoColumn.ColumnName + " ASC");

			if ((rows == null) || (rows.Length == 0))
			{
				return 0;
			}
			else
			{
				StockInputDataSet.StockDetailRow row = (StockInputDataSet.StockDetailRow)rows[rows.Length - 1];
				return row.StockRowNo;
			}
		}

		/// <summary>
		/// 仕入明細行オブジェクトのクリアを行います。
		/// </summary>
		/// <param name="stockRowNoList">クリア対象仕入行番号リスト</param>
		public void ClearStockDetailRow(List<int> stockRowNoList)
		{
			foreach (int stockRowNo in stockRowNoList)
			{
				this.StockDetailRowClearStockInfo(stockRowNo);

				// 仕入明細行クリア処理
				this.ClearStockDetailRow(stockRowNo);

			}
		}

		/// <summary>
		/// 仕入明細行オブジェクトのクリアを行います。（オーバーロード）
		/// </summary>
		/// <param name="stockRowNo">クリア対象仕入行番号</param>
		public void ClearStockDetailRow(int stockRowNo)
		{
			StockInputDataSet.StockDetailRow row = this.StockDetailDataTable.FindBySupplierSlipNoStockRowNo(this.StockSlip.SupplierSlipNo, stockRowNo);

			if (row != null)
			{
				this.ClearStockDetailRow(row);
			}
		}

        /// <summary>
        /// 入力可能数量情報ツールチップ文字列を生成します。
        /// </summary>
        /// <param name="stockRowNo">仕入行番号</param>
        /// <returns>入力可能数量情報ツールチップ文字列</returns>
		public string CreateStockCountInfoString( int stockRowNo )
		{
			StockInputDataSet.StockDetailRow stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);
            if (( stockDetailRow == null ) ||
                ( string.IsNullOrEmpty(stockDetailRow.GoodsName) ) ||
                ( stockDetailRow.StockSlipCdDtl == 2 ) ||
                ( string.IsNullOrEmpty(stockDetailRow.GoodsNo) ) ||
                ( stockDetailRow.GoodsMakerCd == 0 )) return string.Empty;

			int totalWidth = 5;

			StringBuilder toolTip = new StringBuilder();

            int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

			if (( stockDetailRow.StockSlipDtlNumSrc != 0 ) && ( stockDetailRow.StockCountMax != 0 ))
			{
				toolTip.Append("　");
				toolTip.Append("\r\n");

				string name = string.Empty;
				if (this._stockSlip.SupplierSlipCd == 20)
				{
					name = "返品可能数";
				}
				else if (stockDetailRow.SupplierFormalSrc == 1)
				{
					name = "入荷残";
				}
				else
				{
					name = "発注残";
				}

                toolTip.Append(string.Format("{0}：{1:#,##0.00}", name.PadRight(totalWidth, '　'), stockDetailRow.StockCountMax * sign));
				toolTip.Append("\r\n");
			}

			if (stockDetailRow.StockCountMin != 0)
			{
				if (String.IsNullOrEmpty(toolTip.ToString().Trim()))
				{
					toolTip.Append("　");
					toolTip.Append("\r\n");
				}
                toolTip.Append(string.Format("{0}：{1:#,##0.00}", "最低入力数".PadRight(totalWidth, '　'), stockDetailRow.StockCountMin * sign));
			}

			return toolTip.ToString();
        }

        /// <summary>
		/// 読み取り専用行の存在チェックを行います。
		/// </summary>
		/// <returns>true:存在する false:存在しない</returns>
		public bool ExistAllReadonlyRow()
		{
			object value = this._stockDetailDataTable.Compute(
							"COUNT(" + this._stockDetailDataTable.RowStatusColumn.ColumnName + ")",
							this._stockDetailDataTable.EditStatusColumn.ColumnName + " = " + ctEDITSTATUS_AllReadOnly
							);

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
		/// 仕入明細データテーブル内で仕入数量が０の仕入明細行オブジェクトの仕入行番号リストを取得します。
		/// </summary>
		/// <returns>仕入行番号リスト</returns>
		public List<int> GetStockCountZeroStockRowNoList()
		{
			List<int> deleteStockRowNoList = new List<int>();

			DataRow[] rows = this._stockDetailDataTable.Select(
                this._stockDetailDataTable.StockCountDisplayColumn.ColumnName + " = 0");

			if ((rows != null) && (rows.Length > 0))
			{
				StockInputDataSet.StockDetailRow[] stockDetailRows = (StockInputDataSet.StockDetailRow[])rows;

				foreach (StockInputDataSet.StockDetailRow row in stockDetailRows)
				{   
					deleteStockRowNoList.Add(row.StockRowNo);
				}
			}

			return deleteStockRowNoList;
		}

		/// <summary>
		/// 仕入明細データテーブル内で発注残数量が０の仕入明細行オブジェクトの仕入行番号リストを取得します。
		/// </summary>
		/// <returns>仕入行番号リスト</returns>
		public List<int> GetOrderRemainCountZeroStockRowNoList()
		{
			List<int> deleteStockRowNoList = new List<int>();
			DataRow[] rows = this._stockDetailDataTable.Select(
				this._stockDetailDataTable.OrderRemainCntColumn.ColumnName + " = 0");

			if (( rows != null ) && ( rows.Length > 0 ))
			{
				StockInputDataSet.StockDetailRow[] stockDetailRows = (StockInputDataSet.StockDetailRow[])rows;

				foreach (StockInputDataSet.StockDetailRow row in stockDetailRows)
				{
					deleteStockRowNoList.Add(row.StockRowNo);
				}
			}

			return deleteStockRowNoList;
		}

        /// <summary>
        /// 仕入明細データテーブル内で入力済みの行数を取得します。
        /// </summary>
        /// <returns>仕入行番号リスト</returns>
        public int GetAlreadyInputRowCount()
        {
            int cnt = 0;

            StockInputDataSet.StockDetailRow[] stockDetailRows = this.SelectStockDetailRows(string.Format("{0}<>'' OR {1}<>''", this._stockDetailDataTable.GoodsNameColumn.ColumnName, this._stockDetailDataTable.GoodsNoColumn.ColumnName), this._stockDetailDataTable);
            if (( stockDetailRows != null ) && ( stockDetailRows.Length > 0 )) cnt = stockDetailRows.Length;

            return cnt;
        }

		/// <summary>
		/// 仕入明細データテーブル内で商品名称が空白の仕入明細行オブジェクトの仕入行番号リストを取得します。
		/// </summary>
		/// <returns>仕入行番号リスト</returns>
		public List<int> GetEmptyStockRowNoList()
		{
			List<int> deleteStockRowNoList = new List<int>();

			DataRow[] rows = this._stockDetailDataTable.Select(
				this._stockDetailDataTable.GoodsNameColumn.ColumnName + " = ''");

			if ((rows != null) && (rows.Length > 0))
			{
				StockInputDataSet.StockDetailRow[] stockDetailRows = (StockInputDataSet.StockDetailRow[])rows;

				foreach (StockInputDataSet.StockDetailRow row in stockDetailRows)
				{
					deleteStockRowNoList.Add(row.StockRowNo);
				}
			}

			return deleteStockRowNoList;
		}

        // 2009.07.10 Add >>>
        /// <summary>
        /// 計上の明細行番号リストを取得します。
        /// </summary>
        /// <returns></returns>
        public List<int> GetAddUpDetailRowNoList()
        {
            List<int> rowNoList = new List<int>();
            string select = string.Format("{0} <> 0 AND {1}<>{2}", this._stockDetailDataTable.StockSlipDtlNumSrcColumn.ColumnName, this._stockDetailDataTable.SupplierFormalSrcColumn.ColumnName, this._stockSlip.SupplierFormal);
            DataRow[] rows = this._stockDetailDataTable.Select(select);

            if (rows != null && rows.Length > 0)
            {
                StockInputDataSet.StockDetailRow[] stockDetailRows = (StockInputDataSet.StockDetailRow[])rows;

                foreach (StockInputDataSet.StockDetailRow row in stockDetailRows)
                {
                    rowNoList.Add(row.StockRowNo);
                }
            }
            return rowNoList;
        }
        // 2009.07.10 Add <<<

		/// <summary>
		/// 仕入合計金額設定処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="clearTaxAdjust">消費税調整額クリア</param>
		public void TotalPriceSetting( ref StockSlip stockSlip, bool clearTaxAdjust )
		{
			if (stockSlip == null) return;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード

			long stockTtlPricTaxInc = 0;	// 仕入金額計（税込み）
			long stockTtlPricTaxExc = 0;	// 仕入金額計（税抜き）
			long stockPriceConsTax = 0;		// 仕入金額消費税額
			long ttlItdedStcOutTax = 0;		// 仕入外税対象額合計
			long ttlItdedStcInTax = 0;		// 仕入内税対象額合計
			long ttlItdedStcTaxFree = 0;	// 仕入非課税対象額合計
			long stockOutTax = 0;			// 仕入金額消費税額（外税）
			long stckPrcConsTaxInclu = 0;	// 仕入金額消費税額（内税）
			long stckDisTtlTaxExc = 0;		// 仕入値引金額計（税抜き）
			long itdedStockDisOutTax = 0;	// 仕入値引外税対象額合計
			long itdedStockDisInTax = 0;	// 仕入値引内税対象額合計
			long itdedStockDisTaxFre = 0;	// 仕入値引非課税対象額合計
			long stockDisOutTax = 0;		// 仕入値引消費税額（外税）
			long stckDisTtlTaxInclu = 0;	// 仕入値引消費税額（内税）
			long balanceAdjust = 0;			// 残高調整額
			long taxAdjust = 0;				// 消費税調整額

			this.CalculateStockTotalPrice(stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, stockSlip.SuppTtlAmntDspWayCd, stockSlip.SuppCTaxLayCd, out stockTtlPricTaxInc, out stockTtlPricTaxExc, out stockPriceConsTax, out ttlItdedStcOutTax, out ttlItdedStcInTax, out ttlItdedStcTaxFree, out stockOutTax, out stckPrcConsTaxInclu, out stckDisTtlTaxExc, out itdedStockDisOutTax, out itdedStockDisInTax, out itdedStockDisTaxFre, out stockDisOutTax, out stckDisTtlTaxInclu, out balanceAdjust, out taxAdjust);

			switch (stockSlip.StockGoodsCd)
			{
				case 2:	// 消費税調整
				case 4: // 買掛用消費税調整
					{
						stockSlip.StockTtlPricTaxInc = 0;		// 仕入金額計（税込み）
						stockSlip.StockTtlPricTaxExc = 0;		// 仕入金額計（税抜き）
						stockSlip.StockPriceConsTax = taxAdjust;// 仕入金額消費税額
						stockSlip.TtlItdedStcOutTax = 0;		// 仕入外税対象額合計
						stockSlip.TtlItdedStcInTax = 0;			// 仕入内税対象額合計
						stockSlip.TtlItdedStcTaxFree = 0;		// 仕入非課税対象額合計
						stockSlip.StockOutTax = 0;				// 仕入金額消費税額（外税）
						stockSlip.StckPrcConsTaxInclu = 0;		// 仕入金額消費税額（内税）
						stockSlip.StckDisTtlTaxExc = 0;			// 仕入値引金額計（税抜き）
						stockSlip.ItdedStockDisOutTax = 0;		// 仕入値引外税対象額合計
						stockSlip.ItdedStockDisInTax = 0;		// 仕入値引内税対象額合計
						stockSlip.ItdedStockDisTaxFre = 0;		// 仕入値引非課税対象額合計
						stockSlip.StockDisOutTax = 0;			// 仕入値引消費税額（外税）
						stockSlip.StckDisTtlTaxInclu = 0;		// 仕入値引消費税額（内税）
						stockSlip.StockNetPrice = 0;			// 仕入正価金額 = 外税対象金額 + 内税対象金額 + 非課税対象金額
						stockSlip.StockTotalPrice = 0;			// 仕入金額合計
						stockSlip.StockSubttlPrice = 0;			// 仕入金額小計
						stockSlip.AccPayConsTax = taxAdjust;	// 買掛消費税
						break;
					}
				case 3: // 残高調整
				case 5: // 買掛用残高調整
					{
						stockSlip.StockTtlPricTaxInc = 0;		// 仕入金額計（税込み）
						stockSlip.StockTtlPricTaxExc = 0;		// 仕入金額計（税抜き）
						stockSlip.StockPriceConsTax = 0;        // 仕入金額消費税額
						stockSlip.TtlItdedStcOutTax = 0;		// 仕入外税対象額合計
						stockSlip.TtlItdedStcInTax = 0;			// 仕入内税対象額合計
						stockSlip.TtlItdedStcTaxFree = 0;		// 仕入非課税対象額合計
						stockSlip.StockOutTax = 0;				// 仕入金額消費税額（外税）
						stockSlip.StckPrcConsTaxInclu = 0;		// 仕入金額消費税額（内税）
						stockSlip.StckDisTtlTaxExc = 0;			// 仕入値引金額計（税抜き）
						stockSlip.ItdedStockDisOutTax = 0;		// 仕入値引外税対象額合計
						stockSlip.ItdedStockDisInTax = 0;		// 仕入値引内税対象額合計
						stockSlip.ItdedStockDisTaxFre = 0;		// 仕入値引非課税対象額合計
						stockSlip.StockDisOutTax = 0;			// 仕入値引消費税額（外税）
						stockSlip.StckDisTtlTaxInclu = 0;		// 仕入値引消費税額（内税）
						stockSlip.StockNetPrice = 0;			// 仕入正価金額 = 外税対象金額 + 内税対象金額 + 非課税対象金額
						stockSlip.StockTotalPrice = balanceAdjust;	// 仕入金額合計
						stockSlip.StockSubttlPrice = 0;			// 仕入金額小計
						stockSlip.AccPayConsTax = 0;			// 買掛消費税
						break;
					}
				default:
					{
						if (clearTaxAdjust)
						{
							stockSlip.TaxAdjust = 0;
							stockSlip.BalanceAdjust = 0;
						}

                        // --- UPD 2010/10/27 ---------->>>>>
                        //stockSlip.StockTtlPricTaxInc = stockTtlPricTaxInc;		// 仕入金額計（税込み）
                        stockSlip.StockTtlPricTaxInc = stockTtlPricTaxInc + stockSlip.TaxAdjust;		// 仕入金額計（税込み）
                        // --- UPD 2010/10/27 ----------<<<<<
						stockSlip.StockTtlPricTaxExc = stockTtlPricTaxExc;		// 仕入金額計（税抜き）
						stockSlip.StockPriceConsTax = stockPriceConsTax + stockSlip.TaxAdjust;		// 仕入金額消費税額 + 消費税調整額
						stockSlip.TtlItdedStcOutTax = ttlItdedStcOutTax;		// 仕入外税対象額合計
						stockSlip.TtlItdedStcInTax = ttlItdedStcInTax;			// 仕入内税対象額合計
						stockSlip.TtlItdedStcTaxFree = ttlItdedStcTaxFree;		// 仕入非課税対象額合計
                        // --- UPD 2010/10/27 ---------->>>>>
						//stockSlip.StockOutTax = stockOutTax;					// 仕入金額消費税額（外税）
                        stockSlip.StockOutTax = stockOutTax + stockSlip.TaxAdjust;
                        // --- UPD 2010/10/27 ----------<<<<<
						stockSlip.StckPrcConsTaxInclu = stckPrcConsTaxInclu;	// 仕入金額消費税額（内税）
						stockSlip.StckDisTtlTaxExc = stckDisTtlTaxExc;			// 仕入値引金額計（税抜き）
						stockSlip.ItdedStockDisOutTax = itdedStockDisOutTax;	// 仕入値引外税対象額合計
						stockSlip.ItdedStockDisInTax = itdedStockDisInTax;		// 仕入値引内税対象額合計
						stockSlip.ItdedStockDisTaxFre = itdedStockDisTaxFre;	// 仕入値引非課税対象額合計
						stockSlip.StockDisOutTax = stockDisOutTax;				// 仕入値引消費税額（外税）
						stockSlip.StckDisTtlTaxInclu = stckDisTtlTaxInclu;		// 仕入値引消費税額（内税）
						stockSlip.StockNetPrice = ttlItdedStcOutTax + ttlItdedStcInTax + ttlItdedStcTaxFree;	// 仕入正価金額 = 外税対象金額 + 内税対象金額 + 非課税対象金額
                        stockSlip.StockTotalPrice = stockTtlPricTaxInc + ttlItdedStcTaxFree + itdedStockDisTaxFre + stockSlip.TaxAdjust + stockSlip.BalanceAdjust;		// 仕入金額合計 = 仕入金額計（税込み）+ 仕入非課税対象額合計 + 仕入非課税対象額合計 + 消費税調整額 + 残高調整額
                        stockSlip.StockSubttlPrice = stockTtlPricTaxExc + ttlItdedStcTaxFree + itdedStockDisTaxFre;					// 仕入金額小計 = 仕入金額計（税抜き）+ 仕入非課税対象額合計 + 仕入非課税対象額合計
						stockSlip.AccPayConsTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu + stockSlip.TaxAdjust;// 買掛消費税 = 仕入金額消費税額（外税）+ 仕入金額消費税額（内税）+ 仕入値引消費税額（外税）+ 仕入値引消費税額（内税）+ 消費税調整額
						break; 
					}
			}
        }

        #region ■合計金額集計

        /// <summary>
		/// 仕入金額の合計を計算します。
		/// </summary>
		/// <param name="supplierConsTaxRate">仕入先消費税税率</param>
		/// <param name="stockTaxFractionProcCode">仕入消費税端数処理コード</param>
		/// <param name="suppTtlAmntDspWayCd">仕入先総額表示方法区分</param>
		/// <param name="suppCTaxLayCd">消費税転嫁方式</param>
		/// <param name="stockTtlPricTaxInc">仕入金額計（税込み）</param>
		/// <param name="stockTtlPricTaxExc">仕入金額計（税抜き）</param>
		/// <param name="stockPriceConsTax">仕入金額消費税額</param>
		/// <param name="ttlItdedStcOutTax">仕入外税対象額合計</param>
		/// <param name="ttlItdedStcInTax">仕入内税対象額合計</param>
		/// <param name="ttlItdedStcTaxFree">仕入非課税対象額合計</param>
		/// <param name="stockOutTax">仕入金額消費税額（外税）</param>
		/// <param name="stckPrcConsTaxInclu">仕入金額消費税額（内税）</param>
		/// <param name="stckDisTtlTaxExc">仕入値引金額計（税抜き）</param>
		/// <param name="itdedStockDisOutTax">仕入値引外税対象額合計</param>
		/// <param name="itdedStockDisInTax">仕入値引内税対象額合計</param>
		/// <param name="itdedStockDisTaxFre">仕入値引非課税対象額合計</param>
		/// <param name="stockDisOutTax">仕入値引消費税額（外税）</param>
		/// <param name="stckDisTtlTaxInclu">仕入値引消費税額（内税）</param>
		/// <param name="balanceAdjust">残高調整合計額</param>
		/// <param name="taxAdjust">消費税合計額</param>
		public void CalculateStockTotalPrice( double supplierConsTaxRate, int stockTaxFractionProcCode, int suppTtlAmntDspWayCd, int suppCTaxLayCd, out long stockTtlPricTaxInc, out long stockTtlPricTaxExc, out long stockPriceConsTax, out long ttlItdedStcOutTax, out long ttlItdedStcInTax, out long ttlItdedStcTaxFree, out long stockOutTax, out long stckPrcConsTaxInclu, out long stckDisTtlTaxExc, out long itdedStockDisOutTax, out long itdedStockDisInTax, out long itdedStockDisTaxFre, out long stockDisOutTax, out long stckDisTtlTaxInclu, out long balanceAdjust, out long taxAdjust )
		{
			// 仕入消費税端数処理単位、端数処理区分を取得
			int taxFracProcCd = 0;
			double taxFracProcUnit = 0;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFractionProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

			// データテーブルの変更をコミットさせる
			this._stockDetailDataTable.AcceptChanges();

			stockTtlPricTaxInc = 0;		// 仕入金額計（税込み）
			stockTtlPricTaxExc = 0;		// 仕入金額計（税抜き）
			stockPriceConsTax = 0;		// 仕入金額消費税額
			ttlItdedStcOutTax = 0;		// 仕入外税対象額合計
			ttlItdedStcInTax = 0;		// 仕入内税対象額合計
			ttlItdedStcTaxFree = 0;		// 仕入非課税対象額合計
			stockOutTax = 0;			// 仕入金額消費税額（外税）
			stckPrcConsTaxInclu = 0;	// 仕入金額消費税額（内税）
			stckDisTtlTaxExc = 0;		// 仕入値引金額計（税抜き）
			itdedStockDisOutTax = 0;	// 仕入値引外税対象額合計
			itdedStockDisInTax = 0;		// 仕入値引内税対象額合計
			itdedStockDisTaxFre = 0;	// 仕入値引非課税対象額合計
			stockDisOutTax = 0;			// 仕入値引消費税額（外税）
			stckDisTtlTaxInclu = 0;		// 仕入値引消費税額（内税）
			balanceAdjust = 0;			// 残高調整額
			taxAdjust = 0;				// 消費税調整額

			object value = null;

			//--------------------------------------------------
			// 計算に必要な金額の計算
			//--------------------------------------------------
			#region 計算に必要な金額の計算
			// 仕入外税対象額合計
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			ttlItdedStcOutTax = ( value is System.DBNull ) ? 0 : (long)value;

			// 仕入金額消費税額（外税）
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			stockOutTax = ( value is System.DBNull ) ? 0 : (long)value;

			// 仕入内税対象額合計
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			ttlItdedStcInTax = ( value is System.DBNull ) ? 0 : (long)value;

			// 仕入内税対象額合計（税込）
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			long ttlItdedStcInTax_TaxInc = ( value is System.DBNull ) ? 0 : (long)value;

			// 仕入金額消費税額（内税）
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			stckPrcConsTaxInclu = ( value is System.DBNull ) ? 0 : (long)value;
			
			// 仕入非課税対象額合計
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			ttlItdedStcTaxFree = ( value is System.DBNull ) ? 0 : (long)value;

			// 仕入値引外税対象額合計
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			itdedStockDisOutTax = ( value is System.DBNull ) ? 0 : (long)value;

			// 仕入値引消費税額（外税）
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			stockDisOutTax = ( value is System.DBNull ) ? 0 : (long)value;

			// 仕入値引内税対象額合計
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			itdedStockDisInTax = ( value is System.DBNull ) ? 0 : (long)value;

			// 値引内税対象金額合計(税込み)
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			long itdedStockDisInTax_TaxInc = ( value is System.DBNull ) ? 0 : (long)value;

			// 仕入値引消費税額（内税）
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			stckDisTtlTaxInclu = ( value is System.DBNull ) ? 0 : (long)value;
			
			// 仕入値引非課税対象額合計
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			itdedStockDisTaxFre = ( value is System.DBNull ) ? 0 : (long)value;

			// 残高調整額
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} OR {2}={3}", this._stockDetailDataTable.StockGoodsCdColumn.ColumnName, 3, this._stockDetailDataTable.StockGoodsCdColumn.ColumnName, 5));
			balanceAdjust = ( value is System.DBNull ) ? 0 : (long)value;

			// 消費税調整額
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} OR {2}={3}", this._stockDetailDataTable.StockGoodsCdColumn.ColumnName, 2, this._stockDetailDataTable.StockGoodsCdColumn.ColumnName, 4));
			taxAdjust = ( value is System.DBNull ) ? 0 : (long)value;

			// 仕入値引金額計（税抜き） = 仕入値引外税対象額合計 + 仕入値引内税対象額合計 + 仕入値引非課税対象額合計
			stckDisTtlTaxExc = itdedStockDisOutTax + itdedStockDisInTax + itdedStockDisTaxFre;

			#endregion

			if (this._stockSlip.StockGoodsCd == 6)
			{
				// 総額表示
				if (suppTtlAmntDspWayCd == 1)
				{
					//--------------------------------------------------
                    // ① 仕入金額計（税込み）：仕入外税対象額合計 + 仕入金額消費税額（外税）+ 仕入値引外税対象額合計 + 仕入値引消費税額（外税） + 仕入内税対象額合計（税込） +  値引内税対象金額合計(税込み)
					//--------------------------------------------------
                    stockTtlPricTaxInc = ttlItdedStcOutTax + stockOutTax + itdedStockDisOutTax + stockDisOutTax + ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc;

					//--------------------------------------------------
					// ② 仕入金額消費税額：消費税(内税) + 消費税(外税)
					//--------------------------------------------------
					stockPriceConsTax = stckPrcConsTaxInclu + stockOutTax;

					//--------------------------------------------------
					// ③ 仕入金額計（税抜き）：① - ②
					//--------------------------------------------------
					stockTtlPricTaxExc = stockTtlPricTaxInc - stockPriceConsTax;
				}
				else
				{
					//--------------------------------------------------
                    // ① 仕入金額計(税抜き)：仕入外税対象額合計 + 仕入内税対象額合計 + 値引外税対象金額合計 + 値引内税対象金額合計
					//--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

					//--------------------------------------------------
					// ② 仕入金額消費税額：消費税(内税) + 消費税(外税)
					//--------------------------------------------------
					stockPriceConsTax = stockOutTax + stckPrcConsTaxInclu;

					//--------------------------------------------------
					// ③ 仕入金額計（税込）：① + ②
					//--------------------------------------------------
					stockTtlPricTaxInc = stockTtlPricTaxExc + stockPriceConsTax;
				}
			}
			else
			{

                //// 総額表示する
                //if (suppTtlAmntDspWayCd == 1)
                //{
                //    //--------------------------------------------------
                //    // ① 仕入金額計（税込み）：仕入外税対象額合計 + 仕入金額消費税額（外税）+ 仕入値引外税対象額合計 + 仕入値引消費税額（外税） + 仕入内税対象額合計（税込） +  値引内税対象金額合計(税込み)
                //    //--------------------------------------------------
                //    stockTtlPricTaxInc = ttlItdedStcOutTax + stockOutTax + itdedStockDisOutTax + stockDisOutTax + ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc;

                //    //--------------------------------------------------
                //    // ② 仕入金額消費税額：①から内税を計算
                //    //--------------------------------------------------
                //    stockPriceConsTax = CalculateTax.GetTaxFromPriceInc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockTtlPricTaxInc);

                //    //--------------------------------------------------
                //    // ③ 仕入金額計（税抜き）：② - ①
                //    //--------------------------------------------------
                //    stockTtlPricTaxExc = stockTtlPricTaxInc - stockPriceConsTax;
                //}
                // 転嫁方式：非課税の場合に金額を調整する
                if (suppCTaxLayCd == 9)
                {
                    // 仕入金額消費税額（外税）
                    stockOutTax = 0;

                    // 仕入金額消費税額（内税）
                    stckPrcConsTaxInclu = 0;

                    // 仕入非課税対象額合計 = 仕入非課税対象額合計 + 仕入外税対象額合計 + 仕入内税対象額合計
                    ttlItdedStcTaxFree += ttlItdedStcOutTax + ttlItdedStcInTax;

                    // 仕入外税対象額合計
                    ttlItdedStcOutTax = 0;

                    // 仕入内税対象額合計
                    ttlItdedStcInTax = 0;

                    // 仕入内税対象額合計（税込）
                    ttlItdedStcInTax_TaxInc = 0;

                    // 仕入値引消費税額（外税）
                    stockDisOutTax = 0;

                    // 仕入値引消費税額（内税）
                    stckDisTtlTaxInclu = 0;

                    // 仕入値引非課税対象額合計 = 仕入値引非課税対象額合計 + 仕入値引外税対象額合計 + 仕入値引内税対象額合計
                    itdedStockDisTaxFre += itdedStockDisOutTax + itdedStockDisInTax;

                    // 仕入値引外税対象額合計
                    itdedStockDisOutTax = 0;

                    // 仕入値引内税対象額合計
                    itdedStockDisInTax = 0;

                    // 仕入値引内税対象額合計（税込)
                    itdedStockDisInTax_TaxInc = 0;

                    // 仕入値引金額計（税抜き） = 仕入値引外税対象額合計 + 仕入値引内税対象額合計 + 仕入値引非課税対象額合計
                    stckDisTtlTaxExc = itdedStockDisOutTax + itdedStockDisInTax + itdedStockDisTaxFre;
                }

                // 明細転嫁以外
				if (suppCTaxLayCd != 1)
				{
                    //--------------------------------------------------
                    // ① 仕入金額計(税抜き)：仕入外税対象額合計 + 仕入内税対象額合計 + 値引外税対象金額合計 + 値引内税対象金額合計 
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // ② 仕入金額計(税込み)：仕入内税対象額合計(税込み) + 値引内税対象額合計(税込み) + 仕入外税対象額合計 + 値引外税対象金額合計 ＋ (仕入外税対象額合計 + 値引外税対象金額合計)×税率)
                    //--------------------------------------------------
                    stockTtlPricTaxInc = ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc + ttlItdedStcOutTax + itdedStockDisOutTax + CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax + itdedStockDisOutTax);

                    //--------------------------------------------------
                    // ③ 消費税合計：② - ①
                    //--------------------------------------------------
                    stockPriceConsTax = stockTtlPricTaxInc - stockTtlPricTaxExc;

                    //--------------------------------------------------
                    // ④ 仕入金額消費税額（外税）：仕入外税対象額合計 × 税率
                    //--------------------------------------------------
                    stockOutTax = CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax);

                    //--------------------------------------------------
                    // ⑤ 外税対象消費税(税抜き、値引き含む) ：(仕入外税対象額合計 + 仕入値引外税対象額合計) × 税率
                    //--------------------------------------------------
                    long stockOutTax_All = CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax + itdedStockDisOutTax);

                    //--------------------------------------------------
                    // ⑥ 値引外税消費税合計：④ - ⑤
                    //--------------------------------------------------
                    stockDisOutTax = stockOutTax_All - stockOutTax;
				}
				// 明細転嫁
				else
				{
                    //--------------------------------------------------
                    // ① 仕入金額消費税額：仕入金額消費税額（外税） + 仕入金額消費税額（内税） +  仕入値引消費税額（外税） + 仕入値引消費税額（内税）
                    //--------------------------------------------------
                    stockPriceConsTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu;

                    //--------------------------------------------------
                    // ② 仕入金額計(税抜き)：仕入外税対象額合計 + 仕入内税対象額合計 + 値引外税対象金額合計 + 値引内税対象金額合計
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // ③ 仕入金額計(税込み)：① + ②
                    //--------------------------------------------------
                    stockTtlPricTaxInc = stockTtlPricTaxExc + stockPriceConsTax;
				}
			}
        }

        #endregion

        /// <summary>
		/// 仕入金額を計算します。
		/// </summary>
		/// <param name="stockCount">仕入数</param>
		/// <param name="stockUnitPrice">仕入単価</param>
		/// <param name="taxationCode">課税区分</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
		/// <param name="taxFracProcCode">消費税端数処理区分</param>
		/// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
		/// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
		/// <param name="stockPriceConsTax">仕入消費税</param>
		/// <returns></returns>
		private bool CalculateStockPrice( double stockCount, double stockUnitPrice, int taxationCode, double taxRate, int stockMoneyFrcProcCd, int taxFracProcCode,
			out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax )
		{
			double taxFracProcUnit;
			int taxFracProcCd;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

			stockPriceTaxInc = 0;
			stockPriceTaxExc = 0;
			stockPriceConsTax = 0;

			// 仕入数が0または仕入単価が0の場合はすべて0で終了
			if (( stockCount == 0 ) || ( stockUnitPrice == 0 )) return true;

			// 外税の場合
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				double unitPriceExc = stockUnitPrice;	// 単価（税抜き）
				double unitPriceInc;					// 単価（税込み）
				double unitPriceTax;					// 単価（消費税）
				long priceExc = 0;						// 価格（税抜き）
				long priceInc;							// 価格（税込み）
				long priceTax;							// 価格（消費税）

				this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxExc, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

				stockPriceTaxInc = priceInc;			// 仕入金額（税込み）
				stockPriceTaxExc = priceExc;			// 仕入金額（税抜き）		
				stockPriceConsTax = priceTax;			// 仕入消費税
			}
			// 内税の場合
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				double unitPriceExc;					// 単価（税抜き）
				double unitPriceInc = stockUnitPrice;	// 単価（税込み）
				double unitPriceTax;					// 単価（消費税）
				long priceExc;							// 価格（税抜き）
				long priceInc = 0;						// 価格（税込み）
				long priceTax;							// 価格（消費税）

				this._stockPriceCalculate.CalcTaxExcFromTaxInc((int)CalculateTax.TaxationCode.TaxInc, stockCount, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

				stockPriceTaxInc = priceInc;			// 仕入金額（税込み）
				stockPriceTaxExc = priceExc;			// 仕入金額（税抜き）
				stockPriceConsTax = priceTax;			// 仕入消費税
			}
			// 非課税の場合
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
			{
				double unitPriceExc = stockUnitPrice;	// 単価（税抜き）
				double unitPriceInc;					// 単価（税込み）
				double unitPriceTax;					// 単価（消費税）
				long priceExc = 0;						// 価格（税抜き）
				long priceInc;							// 価格（税込み）
				long priceTax;							// 価格（消費税）

				this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxNone, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

				stockPriceTaxInc = priceExc;			// 仕入金額（税込み）
				stockPriceTaxExc = priceExc;			// 仕入金額（税込み）
				stockPriceConsTax = priceTax;			// 仕入消費税
			}

			return true;
		}

		/// <summary>
		/// 仕入金額を計算します。
		/// </summary>
		/// <param name="stockPrice">仕入金額</param>
		/// <param name="taxationCode">課税区分</param>
		/// <param name="taxRate">消費税率</param>
        /// <param name="stockCnsTaxFrcProcCd">消費税端数処理コード</param>
		/// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
		/// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
		/// <param name="stockPriceConsTax">仕入消費税</param>
		/// <returns></returns>
        private bool CalculateStockPrice( long stockPrice, int taxationCode, double taxRate, int stockCnsTaxFrcProcCd, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax )
		{
			double taxFracProcUnit;
			int taxFracProcCd;

            this._stockPriceCalculate.CalculatePrice(taxationCode, stockPrice, taxRate, stockCnsTaxFrcProcCd, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax, out taxFracProcUnit, out taxFracProcCd);

			return true;
		}

		/// <summary>
		/// 仕入金額を計算します。
		/// </summary>
		/// <param name="rowIndex">対象行Index</param>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		public void CalculateStockPrice(int rowIndex, StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			StockInputDataSet.StockDetailRow row = stockDetailDataTable[rowIndex];
			if (row != null)
			{
				this.CalculateStockPrice(row);
			}
		}

		/// <summary>
		/// 仕入金額を計算します。
		/// </summary>
		/// <param name="row">仕入明細データテーブルオブジェクト</param>
		public void CalculateStockPrice( StockInputDataSet.StockDetailRow row )
		{
            if (( string.IsNullOrEmpty(row.GoodsName) ) && ( string.IsNullOrEmpty(row.GoodsNo) ))
                return;

			StockSlip stockSlip = this.StockSlip;
			if (stockSlip == null) return;
			int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

			switch (stockSlip.StockGoodsCd)
			{
				case 2: // 消費税調整
				case 4: // 買掛用消費税調整
					{
						row.StockPriceDisplay = row.StockPriceConsTax * sign;
						break;
					}
				case 3: // 残高調整
				case 5: // 買掛用残高調整
					{
						row.StockPriceDisplay = row.StockPriceTaxInc * sign;
						break;
					}

                case 6: // 合計入力
                    {
                        this.StockDetailStockPriceSetting(row.StockRowNo,row.StockPriceDisplay);
                        //row.StockPriceDisplay=
                        //    //this.StockDetailRowStockGoodsCdSetting(
                        //// 仕入金額を算定
                        //long stockPriceTaxInc;
                        //long stockPriceTaxExc;
                        //long stockPriceDisplay;
                        //long stockPriceConsTax;

                        //int taxationCode = row.TaxationCode;

                        //double stockUnitPrice = 0;
                        //if (stockSlip.SuppCTaxLayCd == 9)
                        //{
                        //    stockUnitPrice = row.StockUnitPriceFl;
                        //    stockPriceTaxExc = row.StockPriceTaxExc;
                        //    stockPriceDisplay = row.StockPriceDisplay * sign;
                        //    taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        //}
                        //else if (( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) || ( stockSlip.SuppTtlAmntDspWayCd == 1 ))
                        //{
                        //    stockUnitPrice = row.StockUnitTaxPriceFl;
                        //    stockPriceTaxInc = row.StockPriceTaxInc;
                        //    //stockPriceDisplay = stockPriceTaxInc * sign;
                        //    stockPriceDisplay = row.StockPriceDisplay * sign;
                        //}
                        //else
                        //{
                        //    stockUnitPrice = row.StockUnitPriceFl;
                        //    stockPriceTaxExc = row.StockPriceTaxExc;
                        //    //stockPriceDisplay = stockPriceTaxExc * sign;
                        //    stockPriceDisplay = row.StockPriceDisplay * sign;
                        //}

                        //// 総額表示時は内税で計算する
                        //if (( taxationCode != (int)CalculateTax.TaxationCode.TaxNone ) && ( stockSlip.SuppTtlAmntDspWayCd == 1 ))
                        //    taxationCode = (int)CalculateTax.TaxationCode.TaxInc;

                        //bool stockPriceCalculated = false;

                        //stockPriceCalculated = this.CalculateStockPrice(stockPriceDisplay, taxationCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);

                        //if (stockPriceCalculated)
                        //{
                        //    row.StockPriceTaxExc = stockPriceTaxExc;
                        //    row.StockPriceTaxInc = stockPriceTaxInc;
                        //    row.StockPriceConsTax = stockPriceConsTax;

                        //    // 非課税の場合は税抜き価格を表示
                        //    if (stockSlip.SuppCTaxLayCd == 9)
                        //    {
                        //        row.StockPriceDisplay = stockPriceTaxExc * sign;
                        //    }
                        //    // 総額表示するもしくは内税商品は税込価格を表示する
                        //    else if (( stockSlip.SuppTtlAmntDspWayCd == 1 ) || ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                        //    {
                        //        row.StockPriceDisplay = stockPriceTaxInc * sign;
                        //    }
                        //    else
                        //    {
                        //        row.StockPriceDisplay = stockPriceTaxExc * sign;
                        //    }
                        //}
                        break;
                    }
				default:
					{
						// 仕入金額を算定
						long stockPriceTaxInc;
						long stockPriceTaxExc;
						long stockPriceDisplay;
						long stockPriceConsTax;

						int taxationCode = row.TaxationCode;

						double stockUnitPrice = 0;
                        if (stockSlip.SuppCTaxLayCd == 9)
                        {
                            stockUnitPrice = row.StockUnitPriceFl;
                            stockPriceTaxExc = row.StockPriceTaxExc;
                            stockPriceDisplay = row.StockPriceDisplay * sign;
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }
                        else if (( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) || ( stockSlip.SuppTtlAmntDspWayCd == 1 ))
                        {
                            stockUnitPrice = row.StockUnitTaxPriceFl;
                            stockPriceTaxInc = row.StockPriceTaxInc;
                            //stockPriceDisplay = stockPriceTaxInc * sign;
                            stockPriceDisplay = row.StockPriceDisplay * sign;
                        }
                        else
                        {
                            stockUnitPrice = row.StockUnitPriceFl;
                            stockPriceTaxExc = row.StockPriceTaxExc;
                            //stockPriceDisplay = stockPriceTaxExc * sign;
                            stockPriceDisplay = row.StockPriceDisplay * sign;
                        }

						// 総額表示時は内税で計算する
                        if (( taxationCode != (int)CalculateTax.TaxationCode.TaxNone ) && ( stockSlip.SuppTtlAmntDspWayCd == 1 )) 
                            taxationCode = (int)CalculateTax.TaxationCode.TaxInc;

                        bool stockPriceCalculated = false;

						// 金額手入力分、値引きで数量ゼロは、表示仕入金額をベースに再計算する
                        if (( row.StockPriceDiectInput ) ||
                            ( ( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ) ))
                        {
                            stockPriceCalculated = this.CalculateStockPrice(stockPriceDisplay, taxationCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);
                        }
                        else
                        {
                            stockPriceCalculated = this.CalculateStockPrice(row.StockCount, stockUnitPrice, taxationCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);
                        }

                        if (stockPriceCalculated)
                        {
                            row.StockPriceTaxExc = stockPriceTaxExc;
                            row.StockPriceTaxInc = stockPriceTaxInc;
                            row.StockPriceConsTax = stockPriceConsTax;

                            // 非課税の場合は税抜き価格を表示
                            if (stockSlip.SuppCTaxLayCd == 9)
                            {
                                row.StockPriceDisplay = stockPriceTaxExc * sign;
                            }
                            // 総額表示するもしくは内税商品は税込価格を表示する
                            else if (( stockSlip.SuppTtlAmntDspWayCd == 1 ) || ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                            {
                                row.StockPriceDisplay = stockPriceTaxInc * sign;
                            }
                            else
                            {
                                row.StockPriceDisplay = stockPriceTaxExc * sign;
                            }
                        }
						break;
					}
			}

		}

        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="stockPriceDisplay">仕入金額</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockPriceTaxInc">仕入金額(税込)</param>
        /// <param name="stockPriceTaxExc">仕入金額(税抜)</param>
        /// <param name="stockPriceConsTax">仕入消費税金額</param>
        private bool CalculateStockPrice( long stockPriceDisplay, int taxationCode, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax )
        {
            double taxRate = this._stockSlip.SupplierConsTaxRate;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);   // 仕入金額端数処理コード
            int taxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);         // 仕入消費税端数処理コード

            return this.CalculateStockPrice(stockPriceDisplay, taxationCode, taxRate, taxFrcProcCd, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);
        }


        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="stockCount">数量</param>
        /// <param name="stockUnitPrice">単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockPriceTaxInc">仕入金額(税込)</param>
        /// <param name="stockPriceTaxExc">仕入金額(税抜)</param>
        /// <param name="stockPriceConsTax">仕入消費税金額</param>
        private bool CalculateStockPrice(double stockCount, double stockUnitPrice,int taxationCode, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax )
        {
            double taxRate = this._stockSlip.SupplierConsTaxRate;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);   // 仕入金額端数処理コード
            int taxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);         // 仕入消費税端数処理コード

            return this.CalculateStockPrice(stockCount, stockUnitPrice, taxationCode, taxRate, stockMoneyFrcProcCd, taxFrcProcCd, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);
        }

        /// <summary>
        /// 仕入金額の符号を調整します。
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        public void AdjustStockPriceSignBasedOnRowIndex(int rowIndex)
        {
            StockInputDataSet.StockDetailRow row = this._stockDetailDataTable[rowIndex];

            if (row != null)
            {
                this.AdjustStockPriceSign(row);
            }
        }

        /// <summary>
        /// 仕入金額の符号を調整します。
        /// </summary>
        /// <param name="row"></param>
        private void AdjustStockPriceSign(StockInputDataSet.StockDetailRow row)
        {
            if (row.StockCount != 0)
            {
                // 単価がゼロの場合のみ対象
                if (( row.StockUnitPriceFl == 0 ) &&
                    ( row.StockUnitTaxPriceFl == 0 ))
                {
                    int displaySign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

                    int sign = ( row.StockCount < 0 ) ? -1 : 1;
                    row.StockPriceTaxExc = Math.Abs(row.StockPriceTaxExc) * sign;
                    row.StockPriceTaxInc = Math.Abs(row.StockPriceTaxInc) * sign;

                    if (( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone ) ||
                       ( this._stockSlip.SuppCTaxLayCd == 9 ))
                    {
                        row.StockPriceDisplay = row.StockPriceTaxExc * displaySign;
                    }
                    else if (( this._stockSlip.SuppTtlAmntDspWayCd == 1 ) ||
                        ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                    {
                        row.StockPriceDisplay = row.StockPriceTaxInc * displaySign;
                    }
                    else
                    {
                        row.StockPriceDisplay = row.StockPriceTaxExc * displaySign;
                    }
                }
            }
        }

		/// <summary>
		/// 仕入金額を計算します。
		/// </summary>
		/// <param name="rowIndex">対象行Index</param>
		public void CalculateStockPriceBasedOnRowIndex(int rowIndex)
		{
            
			this.CalculateStockPrice(rowIndex, this._stockDetailDataTable);
		}

		/// <summary>
		/// 仕入明細行番号を指定して仕入金額を計算します。
		/// </summary>
		/// <param name="stockRowNo"></param>
		public void CalculateStockPriceBasedOnStockRowNo( int stockRowNo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				this.CalculateStockPrice(row);
			}
		}

		#region 在庫検索

        /// <summary>
        /// 検索用倉庫コード配列を取得します。
        /// </summary>
        /// <returns>倉庫コード配列</returns>
        public string[] GetSearchWarehouseArray()
        {
            List<string> warehouseList = new List<string>();

            warehouseList.Add(this._stockSlip.WarehouseCode.Trim());

            if (this._stockSlipInputInitDataAcs.GetStockTtlSt().StockSearchDiv == 0)
            {
                SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(this._stockSlip.StockSectionCd);
                if (secInfoSet != null)
                {
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd1.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd1.Trim());
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd2.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd2.Trim());
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd3.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd3.Trim());
                }
            }

            return warehouseList.ToArray();
        }

        /// <summary>
        /// 明細情報リストより在庫マスタを検索し、在庫リストを取得します。
        /// </summary>
		/// <param name="stockDetailList">明細情報リスト</param>
        public List<Stock> SearchStock( List<StockDetail> stockDetailList )
        {
            if (( stockDetailList == null ) || ( stockDetailList.Count == 0 )) return new List<Stock>(); 

			string[] goodsNos = new string[stockDetailList.Count];
			int[] goodsMakerCds = new int[stockDetailList.Count];
			string[] warehouseCodes = new string[stockDetailList.Count];


			// パラメータ設定
			for (int cnt = 0; cnt < stockDetailList.Count; cnt++)
            {
				goodsNos[cnt] = stockDetailList[cnt].GoodsNo;
				goodsMakerCds[cnt] = stockDetailList[cnt].GoodsMakerCd;
				warehouseCodes[cnt] = stockDetailList[cnt].WarehouseCode;
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
		/// <param name="warehosueCode">倉庫コード</param>
		/// <param name="goodsNo">商品コード</param>
		/// <param name="goodsMakerCd">メーカーコード</param>
        public List<Stock> SearchStock( string warehosueCode, string goodsNo, int goodsMakerCd )
		{
			StockSearchPara stockSearchPara = new StockSearchPara();
			stockSearchPara.EnterpriseCode = this._enterpriseCode;
			stockSearchPara.GoodsNo = goodsNo;
			stockSearchPara.GoodsMakerCd = goodsMakerCd;
			stockSearchPara.WarehouseCode = warehosueCode;

			return SearchStock(stockSearchPara);
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
            if (this._searchStockAcs == null) this._searchStockAcs = new SearchStockAcs();
			int status = this._searchStockAcs.Search(stockSearchPara, out retStockList, out msg);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                retStockList = new List<Stock>();
			}

			return retStockList;
		}

		#endregion

		/// <summary>
		/// メモ存在チェック
		/// </summary>
		/// <param name="stockRowNo">対象行</param>
		/// <returns></returns>
		public bool MemoExist( int stockRowNo )
		{
			bool ret = false;

			StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

			if (row != null)
			{
                if (( !string.IsNullOrEmpty(row.SlipMemo1) ) || ( !string.IsNullOrEmpty(row.SlipMemo2) ) || ( !string.IsNullOrEmpty(row.SlipMemo3) ) ||
                    ( !string.IsNullOrEmpty(row.InsideMemo1) ) || ( !string.IsNullOrEmpty(row.InsideMemo2) ) || ( !string.IsNullOrEmpty(row.InsideMemo3) ))
                {
                    ret = true;
                }
			}

			return ret;
		}

		
		/// <summary>
		/// 単価情報確認用オブジェクト取得
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		/// <returns>単価情報確認用オブジェクト</returns>
		public UnPrcInfoConf GetUnitPriceInfoConf( int stockRowNo )
		{
			UnPrcInfoConf unPrcInfoConf = new UnPrcInfoConf();

			StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

			if (row != null)
			{
                // 仕入消費税端数処理単位、端数処理区分を取得
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード
                
                int taxFracProcCd = 0;
                double taxFracProcUnit = 0;
                this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

                unPrcInfoConf.RateSettingDivide = row.RateDivStckUnPrc;                         // 掛率設定区分
                unPrcInfoConf.SectionCode = row.RateSectStckUnPrc;                              // 拠点コード
                //unPrcInfoConf.CustomerCode = row.CustomerCode;                                // 得意先コード
                //unPrcInfoConf.CustomerSnm = row.CustomerSnm;                                  // 得意先略称
                unPrcInfoConf.SupplierCd = this._stockSlip.SupplierCd;                          // 仕入先コード
                unPrcInfoConf.SupplierSnm = this._stockSlip.SupplierSnm;                        // 仕入先略称
                //unPrcInfoConf.CustRateGrpCode = row.CustRateGrpCode;                          // 得意先掛率グループコード
                unPrcInfoConf.GoodsMakerCd = row.GoodsMakerCd;                                  // 商品メーカーコード
                unPrcInfoConf.MakerName = row.MakerName;                                        // メーカー名称
                unPrcInfoConf.GoodsNo = row.GoodsNo;                                            // 商品番号
                unPrcInfoConf.GoodsName = row.GoodsName;                                        // 商品名称
                unPrcInfoConf.GoodsRateRank = row.GoodsRateRank;                                // 商品掛率ランク
                unPrcInfoConf.GoodsRateGrpCode = row.RateGoodsRateGrpCd;                        // 商品掛率グループコード
                unPrcInfoConf.GoodsRateGrpCodeNm = row.RateGoodsRateGrpNm;                      // 商品掛率グループコード名称
                unPrcInfoConf.BLGroupCode = row.RateBLGroupCode;                                // BLグループコード
                unPrcInfoConf.BLGroupName = row.RateBLGroupName;                                // BLグループコード名称
                unPrcInfoConf.BLGoodsCode = row.RateBLGoodsCode;                                // BL商品コード
                unPrcInfoConf.BLGoodsFullName = row.RateBLGoodsName;                            // BL商品コード名称（全角）
                unPrcInfoConf.PriceApplyDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockAddUpADate : this._stockSlip.ArrivalGoodsDay;	// 価格適用日
                unPrcInfoConf.CountFl = row.StockCountDisplay;                                  // 数量
                unPrcInfoConf.UnitPrcCalcDiv = row.UnPrcCalcCdStckUnPrc;                        // 単価算出区分
                unPrcInfoConf.RateVal = row.StockRate;                                          // 掛率
                unPrcInfoConf.UnPrcFracProcUnit = row.FracProcUnitStcUnPrc;                     // 単価端数処理単位
                unPrcInfoConf.UnPrcFracProcDiv = row.FracProcStckUnPrc;                         // 単価端数処理区分
                unPrcInfoConf.StdUnitPrice = row.StdUnPrcStckUnPrc;                             // 基準単価
                unPrcInfoConf.UnitPriceTaxExcFl = row.StockUnitPriceFl;                         // 単価（税抜，浮動）
                unPrcInfoConf.UnitPriceTaxIncFl = row.StockUnitTaxPriceFl;                      // 単価（税込，浮動）
                unPrcInfoConf.ListPriceTaxIncFl = row.ListPriceTaxIncFl;                        // 定価（税込，浮動）
                unPrcInfoConf.ListPriceTaxExcFl = row.ListPriceTaxExcFl;                        // 定価（税抜，浮動）
                //unPrcInfoConf.SalesUnitCostTaxIncFl = row.SalesUnitCostTaxIncFl;              // 原価単価（税込，浮動）
                //unPrcInfoConf.SalesUnitCostTaxExcFl = row.SalesUnitCostTaxExcFl;              // 原価単価（税抜，浮動）
                unPrcInfoConf.TaxationDivCd = row.TaxationCode;                                 // 課税区分
                unPrcInfoConf.TaxFractionProcUnit = taxFracProcUnit;                            // 消費税端数処理単位
                unPrcInfoConf.TaxFractionProcCd = taxFracProcCd;                                // 消費税端数処理区分
                unPrcInfoConf.TaxRate = this._stockSlip.SupplierConsTaxRate;                    // 税率
                unPrcInfoConf.TotalAmountDispWayCd = this._stockSlip.SuppTtlAmntDspWayCd;       // 総額表示方法区分
                unPrcInfoConf.TtlAmntDspRateDivCd = this._stockSlip.TtlAmntDispRateApy;         // 総額表示掛率適用区分

			}

			return unPrcInfoConf;
		}
		
        # endregion

        // ===================================================================================== //
        // スタティックメソッド
        // ===================================================================================== //
        # region ■Static Method
        /// <summary>
        /// 表示用仕入伝票区分分より、データ用の仕入伝票区分、買掛区分をセットします
        /// </summary>
        /// <param name="stockSlip">仕入オブジェクト</param>
        static public void SetSlipCdAndAccPayDivCdFromDisplay( ref StockSlip stockSlip )
        {
            int supplierSlipCd;
            int accPayDivCd;

            GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay(stockSlip.SupplierSlipDisplay, out supplierSlipCd, out accPayDivCd);

            stockSlip.SupplierSlipCd = supplierSlipCd;
            stockSlip.AccPayDivCd = accPayDivCd;
        }

        /// <summary>
        /// 定価原価更新区分の設定
        /// </summary>
        /// <param name="stockSlip"></param>
        /// <param name="priceCostUpdtDiv"></param>
        static public void SetPriceCostUpdtDiv(ref StockSlip stockSlip, int priceCostUpdtDiv)
        {
            if (priceCostUpdtDiv == 0)
            {
                stockSlip.PriceCostUpdtDiv = 0;
            }
            else
            {
                // 仕入、黒伝、商品区分「商品」の場合
                if (( stockSlip.SupplierSlipCd == 10 ) && ( stockSlip.DebitNoteDiv == 0 ) && ( stockSlip.StockGoodsCd == 0 ))
                {
                    // 無条件更新の場合は更新するに設定
                    if (priceCostUpdtDiv == 1)
                    {
                        stockSlip.PriceCostUpdtDiv = 1;
                    }
                }
                // 上記条件以外
                else
                {
                    // 更新しない
                    stockSlip.PriceCostUpdtDiv = 0;
                }
            }
        }

        /// <summary>
        /// 定価原価更新区分の変更可否
        /// </summary>
        /// <param name="stockSlip">仕入データ</param>
        /// <param name="priceCostUpdtDiv">定価原価更新区分(仕入在庫全体設定マスタ）</param>
        static public bool CanChangePriceCostUpdtDiv(StockSlip stockSlip, int priceCostUpdtDiv)
        {
            bool canChange = false;

            // 確認更新の場合のみ
            if (priceCostUpdtDiv == 2)
            {
                // 仕入、黒伝、商品区分「商品」の場合
                if (( stockSlip.SupplierSlipCd == 10 ) && ( stockSlip.DebitNoteDiv == 0 ) && ( stockSlip.StockGoodsCd == 0 ))
                {
                    canChange = true;
                }
            }

            return canChange;
        }

        /// <summary>
        /// 表示用仕入伝票区分より、仕入伝票区分、買掛区分を取得します。
        /// </summary>
        /// <param name="supplierSlipDisplay">表示用仕入伝票区分</param>
        /// <param name="supplierSlipCd">仕入伝票区分</param>
        /// <param name="accPayDivCd">買掛区分</param>
        static public void GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay( int supplierSlipDisplay, out int supplierSlipCd, out int accPayDivCd )
        {
            // 初期値は掛仕入
            supplierSlipCd = 10;
            accPayDivCd = 1;
            switch (supplierSlipDisplay)
            {
                case 10:                                    // 掛仕入
                    {
                        supplierSlipCd = 10;
                        accPayDivCd = 1;
                        break;
                    }
                case 20:                                    // 掛返品
                    {
                        supplierSlipCd = 20;
                        accPayDivCd = 1;
                        break;
                    }
                case 30:                                    // 現金仕入
                    {
                        supplierSlipCd = 10;
                        accPayDivCd = 0;
                        break;
                    }
                case 40:                                    // 現金返品
                    {
                        supplierSlipCd = 20;
                        accPayDivCd = 0;
                        break;
                    }
            }
        }

        /// <summary>
        /// データの仕入伝票区分、買掛区分より、表示用仕入伝票区分をセットします。
        /// </summary>
        /// <param name="stockSlip">仕入オブジェクト</param>
        static public void SetDisplayFromSlipCdAndAccPayDivCd( ref StockSlip stockSlip )
        {
            stockSlip.SupplierSlipDisplay = GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(stockSlip.SupplierSlipCd, stockSlip.AccPayDivCd);
        }

        /// <summary>
        /// 仕入伝票区分、買掛区分より、表示用仕入伝票区分します。
        /// </summary>
        /// <param name="supplierSlipCd">仕入伝票区分</param>
        /// <param name="accPayDivCd">買掛区分</param>
        /// <returns>表示用仕入伝票区分</returns>
        static public int GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd( int supplierSlipCd, int accPayDivCd )
        {
            int value = 0;
            switch (supplierSlipCd)
            {
                case 10:
                    {
                        value = 10;
                        break;
                    }
                case 20:
                    {
                        value = 20;
                        break;
                    }
            }
            switch (accPayDivCd)
            {
                case 0:
                    {
                        value += 20;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return value;
		}

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

			DateTime thisTimeAddUpDate = StockSlipInputAcs.GetNextTotalDate(0, targetDate, totalDay);
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

        #endregion

        #endregion

        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region ■Private Methods

        /// <summary>
        /// IOWriter制御オプションワーク取得処理
        /// </summary>
        /// <returns></returns>
        private IOWriteCtrlOptWork GetIOWriteCtrlOptWork()
        {
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();

            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;							// 制御起点：仕入
            if (this._stockSlipInputInitDataAcs.GetSalesTtlSt() != null)
            {
                iOWriteCtrlOptWork.ShipmAddUpRemDiv = this._stockSlipInputInitDataAcs.GetSalesTtlSt().ShipmAddUpRemDiv;			// 出荷データ計上残区分(売上全体設定マスタより)
            }

            if (this._stockSlipInputInitDataAcs.GetSalesTtlSt() != null)
            {
                iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this._stockSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrrAddUpRemDiv;		// 受注データ計上残区分(売上全体設定マスタより)
            }

            // 残数管理区分は「する」固定
            iOWriteCtrlOptWork.RemainCntMngDiv = 0;
            //if (this._stockSlipInputInitDataAcs.GetAllDefSet() != null)
            //{
            //    iOWriteCtrlOptWork.RemainCntMngDiv = this._stockSlipInputInitDataAcs.GetAllDefSet().RemainCntMngDiv;			// 残数管理区分(全体初期値設定より)
            //}

            return iOWriteCtrlOptWork;
        }


		/// <summary>
		/// 仕入率を使用して定価から仕入単価を算出します。
		/// </summary>
		/// <param name="row"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceDisplay"></param>
        /// <param name="fracProcUnitStcUnPrc"></param>
		/// <param name="fracProcStckUnPrc"></param>
        private void CalculateStockUnitPriceByRate( StockInputDataSet.StockDetailRow row, out double unitPriceTaxExc, out double unitPriceTaxInc, out double unitPriceDisplay, ref double fracProcUnitStcUnPrc, ref int fracProcStckUnPrc )
		{
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);	// 仕入単価端数処理コード
			int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード

            double stdPrice = ( ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) && ( ( this._stockSlip.SuppCTaxLayCd != 9 ) ) ) ? row.ListPriceTaxIncFl : row.ListPriceTaxExcFl;

            this.CalculateStockUnitPriceByRate(
                stdPrice,
                row.StockRate,
                row.TaxationCode,
                this._stockSlip.SuppTtlAmntDspWayCd,
                this._stockSlip.TtlAmntDispRateApy,
                this._stockSlip.SuppCTaxLayCd,
                this._stockSlip.SupplierConsTaxRate,
                stockUnPrcFrcProcCd,
                stockTaxFrcProcCd,
                out unitPriceTaxExc,
                out unitPriceTaxInc,
                out unitPriceDisplay,
                ref fracProcUnitStcUnPrc,
                ref fracProcStckUnPrc);
		}

        /// <summary>
        /// 仕入率を使用して定価から仕入単価を算出します。（オーバーロード）
        /// </summary>
        /// <param name="listPrice">定価</param>
        /// <param name="stockRate">仕入率</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="ttlAmntDspRateDivCd">総額表示掛率適用区分</param>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="stockUnPrcFrcProcCd">単価端数処理コード</param>
        /// <param name="stockTaxFrcProcCd">消費税端数処理コード</param>
        /// <param name="unitPriceTaxExc">税抜単価</param>
        /// <param name="unitPriceTaxInc">税込単価</param>
        /// <param name="unitPriceDisplay">表示単価</param>
        /// <param name="fracProcUnitStcUnPrc">端数処理単位</param>
        /// <param name="fracProcStckUnPrc">端数処理区分</param>
        private void CalculateStockUnitPriceByRate(double listPrice, double stockRate, int taxationCode, int totalAmountDispWayCd, int ttlAmntDspRateDivCd, int suppCTaxLayCd, double taxRate, int stockUnPrcFrcProcCd, int stockTaxFrcProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc, out double unitPriceDisplay, ref double fracProcUnitStcUnPrc, ref int fracProcStckUnPrc)
        {
			int taxFracProcCd = 0;
			double taxFracProcUnit = 0;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // 転嫁方式「非課税」時は強制的に非課税計算する
            if (suppCTaxLayCd == 9) taxationCode = (int)CalculateTax.TaxationCode.TaxNone;

            this._unitPriceCalculation.CalculateUnitPriceByRate(
                UnitPriceCalculation.UnitPriceKind.UnitCost,
                UnitPriceCalculation.UnitPrcCalcDiv.RateVal,
                totalAmountDispWayCd,
                ttlAmntDspRateDivCd,
                stockUnPrcFrcProcCd,
                taxationCode,
                listPrice,
                taxRate,
                taxFracProcUnit,
                taxFracProcCd,
                stockRate,
                ref fracProcUnitStcUnPrc,
                ref fracProcStckUnPrc,
                out unitPriceTaxExc,
                out unitPriceTaxInc);


            // 「総額表示する」か、「内税商品」の場合は税込み単価を表示単価に設定
            if (( totalAmountDispWayCd == 1 ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
            {
                unitPriceDisplay = unitPriceTaxInc;
            }
            else
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
        }

		/// <summary>
		/// 指定した商品価格情報を元に、仕入明細データ行オブジェクトに定価を設定します。
		/// </summary>
		/// <param name="row">仕入明細行オブジェクト</param>
		/// <param name="goodsUnitData">商品価格リスト</param>
		private void StockDetailRowListPriceSetting( StockInputDataSet.StockDetailRow row, GoodsUnitData goodsUnitData )
		{
			int taxationCode = row.TaxationCode;

			double listPrice = 0;
			bool getListPrice = false;

            //// 掛率算出した場合、基準価格が設定されている場合は基準単価が定価となる
            //if (( !string.IsNullOrEmpty(row.RateDivStckUnPrc.Trim()) ) || ( row.StdUnPrcStckUnPrc != 0 ) || ( row.UnPrcCalcCdStckUnPrc > 0 ))
            //{
            //    listPrice = row.StdUnPrcStckUnPrc;	// 掛率算出した場合は基準価格が定価
            //    getListPrice = true;
            //}
            // 価格リストより定価を表示する
            if (( goodsUnitData != null ) && ( !string.IsNullOrEmpty(goodsUnitData.GoodsNo) ))// && ( row.StockRate == 0 ))
            {
                DateTime targetDate = ( this._stockSlip.SupplierFormal == 1 ) ? this._stockSlip.ArrivalGoodsDay : this._stockSlip.StockDate;
                GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsUnitData);

                if (goodsPrice != null)
                {
                    listPrice = goodsPrice.ListPrice;
                    row.OpenPriceDiv = goodsPrice.OpenPriceDiv;

                    getListPrice = true;
                }
            }

            if (getListPrice)
            {
                if (listPrice != 0)
                {
                    if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                    int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード
                    int taxFracProcCd = 0;
                    double taxFracProcUnit = 0;
                    this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

                    // 税抜き価格、税込み価格の計算
                    // 商品価格課税区分「内税」
                    if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        row.ListPriceTaxIncFl = listPrice;
                        row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);
                    }
                    // 商品価格課税区分「外税」
                    else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        row.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);
                        row.ListPriceTaxExcFl = listPrice;
                    }
                    // 商品価格課税区分「非課税」
                    else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
                    {
                        row.ListPriceTaxExcFl = listPrice;
                        row.ListPriceTaxIncFl = listPrice;
                    }

                    // ②表示定価の決定
                    // 非課税
                    if (this._stockSlip.SuppCTaxLayCd == 9)
                    {
                        // 税込み定価←税抜き定価
                        row.ListPriceTaxIncFl = row.ListPriceTaxExcFl;
                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                    }
                    // 総額表示しない
                    else if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                    {
                        // 内税商品は税込み価格を表示し、それ以外は税抜き価格を表示する
                        row.ListPriceDisplay = ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? row.ListPriceTaxIncFl : row.ListPriceTaxExcFl;
                    }
                    // 総額表示する
                    else
                    {
                        // 税込み価格を表示
                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                    }
                }
                else
                {
                    row.ListPriceDisplay = 0;
                    row.ListPriceTaxExcFl = 0;
                    row.ListPriceTaxIncFl = 0;
                }
                row.BfListPrice = row.ListPriceTaxExcFl;
            }
            else
            {
                row.BfListPrice = 0;
            }
        }

        /// <summary>
        /// 対象価格から、税抜金額、税込金額、表示金額を計算します
        /// </summary>
        /// <param name="priceInputType">価格入力モード</param>
        /// <param name="unitPrice">対象価格</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="stockTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <param name="unitPriceTaxExc">税抜金額</param>
        /// <param name="unitPriceTaxInc">税込金額</param>
        /// <param name="unitPriceDisplay">表示金額</param>
        private void CalculatePrice(PriceInputType priceInputType, double unitPrice, int taxationCode, int totalAmountDispWayCd, int suppCTaxLayCd, double taxRate, int stockTaxFrcProcCd, out  double unitPriceTaxExc, out  double unitPriceTaxInc, out  double unitPriceDisplay)
        {
            unitPriceTaxExc = 0;
            unitPriceTaxInc = 0;
            unitPriceDisplay = 0;

            if (unitPrice == 0) return;

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // 入力タイプ
            switch (priceInputType)
            {
                // 税抜き価格
                case PriceInputType.PriceTaxExc:
                    {
                        if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ) || ( suppCTaxLayCd == 9 ))
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice;
                        }
                        else
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                        }

                        break;
                    }
                // 税込み価格
                case PriceInputType.PriceTaxInc:
                    {
                        if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ) || ( suppCTaxLayCd == 9 ))
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice;
                        }
                        else
                        {
                            unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                            unitPriceTaxInc = unitPrice;
                        }

                        break;
                    }
                // 表示価格
                case PriceInputType.PriceDisplay:
                    {
                        if (suppCTaxLayCd == 9)
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice;
                        }
                        // 総額表示しない
                        else if (totalAmountDispWayCd == 0)
                        {
                            // 課税区分が「課税（内税）」の場合
                            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                                unitPriceTaxInc = unitPrice;
                            }
                            // 課税区分が「課税」の場合
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                unitPriceTaxExc = unitPrice;
                                unitPriceTaxInc = unitPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                            }
                            // 課税区分が「非課税」の場合
                            else
                            {
                                unitPriceTaxExc = unitPrice;
                                unitPriceTaxInc = unitPrice;
                            }
                        }
                        // 総額表示する
                        else
                        {
                            // 課税区分が「課税（内税）」の場合
                            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                                unitPriceTaxInc = unitPrice;
                            }
                            // 課税区分が「課税」の場合
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                                unitPriceTaxInc = unitPrice;
                            }
                            // 課税区分が「非課税」の場合
                            else
                            {
                                unitPriceTaxExc = unitPrice;
                                unitPriceTaxInc = unitPrice;
                            }
                        }
                        break;
                    }
            }

            // 非課税の仕入先は税抜き金額を表示する
            if (suppCTaxLayCd == 9)
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
            // 総額表示か内税は税込み金額を表示する
            else if (( totalAmountDispWayCd == 1 ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
            {
                unitPriceDisplay = unitPriceTaxInc;
            }
            else
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
        }

        /// <summary>
        /// 単価算出結果、商品連結データより、原価単価、定価を設定します。
        /// </summary>
        /// <param name="row">仕入明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="unitPriceCalcRet">単価算出結果オブジェクト</param>
        private void StockDetailRowGoodsPriceSettingFromUnitPriceCalcRet( StockInputDataSet.StockDetailRow row, GoodsUnitData goodsUnitData, UnitPriceCalcRet unitPriceCalcRet )
        {
            this.ClearStockDetailRateInfo(row, true);

            if (unitPriceCalcRet != null)
            {
                row.RateSectStckUnPrc = unitPriceCalcRet.SectionCode.Trim();	// 掛率設定拠点（仕入単価）
                row.RateDivStckUnPrc = unitPriceCalcRet.RateSettingDivide;		// 掛率設定区分（仕入単価）
                row.UnPrcCalcCdStckUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;		// 単価算出区分（仕入単価）
                row.StdUnPrcStckUnPrc = unitPriceCalcRet.StdUnitPrice;			// 基準単価（仕入単価）
                row.FracProcUnitStcUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;	// 単価端数処理単位
                row.FracProcStckUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;		// 端数処理（仕入単価）
                row.PriceCdStckUnPrc = unitPriceCalcRet.PriceDiv;				// 価格区分
                row.StockRate = unitPriceCalcRet.RateVal;						// 仕入率
                row.StdUnPrcStckUnPrc = unitPriceCalcRet.StdUnitPrice;			// 基準単価（仕入単価）
                row.StockUnitPriceFl = unitPriceCalcRet.UnitPriceTaxExcFl;		// 仕入単価（税抜，浮動）
                row.StockUnitTaxPriceFl = unitPriceCalcRet.UnitPriceTaxIncFl;	// 仕入単価（税込，浮動）
                row.BfStockUnitPriceFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // 変更前単価（税抜き）
                row.StockUnitChngDiv = 0;										// 仕入単価変更区分

                // 非課税品は税抜き単価を表示
                if (this._stockSlip.SuppCTaxLayCd == 9)
                {
                    row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                }
                else if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                {
                    // 商品価格課税区分「内税」
                    if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                    }
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                    }
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                    }
                }
                else if (this._stockSlip.SuppTtlAmntDspWayCd == 1)
                {
                    // 商品価格課税区分「内税」
                    if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                    }
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                    }
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                    }
                }
            }
            else
            {
            }
            this.StockDetailRowListPriceSetting(row, goodsUnitData);
        }

        /// <summary>
        /// 仕入明細の掛率に関連する項目をクリアします。
        /// </summary>
        /// <param name="row">仕入明細行オブジェクト</param>
        /// <param name="claerBfStockUnitPrice">True;変更前情報をクリアする</param>
        private void ClearStockDetailRateInfo( StockInputDataSet.StockDetailRow row, bool claerBfStockUnitPrice )
        {
            row.RateSectStckUnPrc = string.Empty;           // 掛率設定拠点（仕入単価）
            row.RateDivStckUnPrc = string.Empty;            // 掛率設定区分（仕入単価）
            row.UnPrcCalcCdStckUnPrc = 0;                   // 単価算出区分（仕入単価）
            row.PriceCdStckUnPrc = 0;                       // 価格区分
            row.StockRate = 0;                              // 仕入率
            row.FracProcUnitStcUnPrc = 0;                   // 単価端数処理単位
            row.FracProcStckUnPrc = 0;                      // 端数処理（仕入単価）
            row.StdUnPrcStckUnPrc = 0;                      // 基準単価（仕入単価）
            row.StockUnitPriceFl = 0;                       // 仕入単価（税抜，浮動）
            row.StockUnitTaxPriceFl = 0;                    // 仕入単価（税込，浮動）
            if (claerBfStockUnitPrice)
            {
                row.BfStockUnitPriceFl = 0;                     // 変更前仕入単価（浮動）
            }

            row.StockUnitChngDiv = ( row.StockUnitPriceFl != row.BfStockUnitPriceFl ) ? 1 : 0; // 仕入単価変更区分

        }

		/// <summary>
		/// 指定した商品情報オブジェクトを元に単価算出部品より商品価格を取得し、仕入明細データ行オブジェクトに商品価格情報を設定します。
		/// </summary>
		/// <param name="row">仕入明細行オブジェクト</param>
		/// <param name="goodsUnitData">商品連結データオブジェクト</param>
		private void StockDetailRowGoodsPriceSetting( StockInputDataSet.StockDetailRow row, GoodsUnitData goodsUnitData )
		{
            UnitPriceCalcRet unitPriceCalcRet = this.CalculateStockUnitPrice(this.CreateUnitPriceCalcParam(row, goodsUnitData), goodsUnitData);

            this.StockDetailRowGoodsPriceSettingFromUnitPriceCalcRet(row, goodsUnitData, unitPriceCalcRet);
		}

        /// <summary>
        /// 対象行の単価算出パラメータを生成します。
        /// </summary>
        /// <param name="row">仕入明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>単価算出パラメータ</returns>
        private UnitPriceCalcParam CreateUnitPriceCalcParam( StockInputDataSet.StockDetailRow row, GoodsUnitData goodsUnitData )
        {
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);		// 仕入単価端数処理コード
            int stockcnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);	// 仕入消費税端数処理コード

            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

            unitPriceCalcParam.SectionCode = this._stockSlip.StockSectionCd.Trim();                     // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;                       // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.CustomerCode = row.SalesCustomerCode;                                    // 得意先コード
            unitPriceCalcParam.CustRateGrpCode = row.CustRateGrpCode;                                   // 得意先掛率グループコード
            unitPriceCalcParam.SupplierCd = this._stockSlip.SupplierCd;                                 // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;  // 価格適用日
            unitPriceCalcParam.CountFl = Math.Abs(row.StockCountDisplay);                               // 数量
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = this._stockSlip.SupplierConsTaxRate;                           // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = stockcnsTaxFrcProcCd;                             // 仕入消費税端数処理コード
            unitPriceCalcParam.TotalAmountDispWayCd = this._stockSlip.SuppTtlAmntDspWayCd;              // 総額表示方法区分
            unitPriceCalcParam.TtlAmntDspRateDivCd = this._stockSlip.TtlAmntDispRateApy;                // 総額表示掛率適用区分
            unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                               // 仕入単価端数処理コード
            unitPriceCalcParam.ConsTaxLayMethod = this._stockSlip.SuppCTaxLayCd;                        // 仕入先消費税転嫁方式コード

            return unitPriceCalcParam;
        }

        /// <summary>
        /// 単価算出モジュールを使用して仕入単価を計算します。
        /// </summary>
        /// <param name="unitPriceCalcParam">単価算出パラメータ</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>単価算出結果</returns>
        private UnitPriceCalcRet CalculateStockUnitPrice( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData )
        {
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            goodsUnitDataList.Add(goodsUnitData);

            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalculateStockUnitPrice(unitPriceCalcParamList, goodsUnitDataList);

            if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count > 0 ))
            {
                foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
                {
                    if (( goodsUnitData.GoodsNo == unitPriceCalcRet.GoodsNo ) &&
                        ( goodsUnitData.GoodsMakerCd == unitPriceCalcRet.GoodsMakerCd ))
                    {
                        return unitPriceCalcRet;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 単価算出モジュールを使用して仕入単価を計算します。
        /// </summary>
        /// <param name="unitPriceCalcParamList">単価算出パラメータリスト</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <returns>単価算出結果リスト</returns>
        private List<UnitPriceCalcRet> CalculateStockUnitPrice( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList )
        {
            List<UnitPriceCalcRet> returnUnitPriceCalcRetList = new List<UnitPriceCalcRet>();

            List<UnitPriceCalcRet> unitPriceCalcRetList;

            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    returnUnitPriceCalcRetList.Add(unitPriceCalcRetWk);
                }
            }
            return returnUnitPriceCalcRetList;
        }

		/// <summary>
		/// 仕入明細行オブジェクトのコピーを行います。
		/// </summary>
		/// <param name="sourceRow">コピー元仕入明細行オブジェクト</param>
		/// <param name="targetRow">コピー先仕入明細行オブジェクト</param>
		private void CopyStockDetailRow(StockInputDataSet.StockDetailRow sourceRow, StockInputDataSet.StockDetailRow targetRow)
		{
			if ((sourceRow == null) || (targetRow == null)) return;

			#region ●項目セット

            //targetRow.CreateDateTime = sourceRow.CreateDateTime;                    // 作成日時
            //targetRow.UpdateDateTime = sourceRow.UpdateDateTime;                    // 更新日時
            //targetRow.EnterpriseCode = sourceRow.EnterpriseCode;                    // 企業コード
            //targetRow.FileHeaderGuid = sourceRow.FileHeaderGuid;                    // GUID
            //targetRow.UpdEmployeeCode = sourceRow.UpdEmployeeCode;                  // 更新従業員コード
            //targetRow.UpdAssemblyId1 = sourceRow.UpdAssemblyId1;                    // 更新アセンブリID1
            //targetRow.UpdAssemblyId2 = sourceRow.UpdAssemblyId2;                    // 更新アセンブリID2
            //targetRow.LogicalDeleteCode = sourceRow.LogicalDeleteCode;              // 論理削除区分
            targetRow.AcceptAnOrderNo = sourceRow.AcceptAnOrderNo;                  // 受注番号
            targetRow.SupplierFormal = sourceRow.SupplierFormal;                    // 仕入形式
            targetRow.SupplierSlipNo = sourceRow.SupplierSlipNo;                    // 仕入伝票番号
            //targetRow.StockRowNo = sourceRow.StockRowNo;                            // 仕入行番号
            //targetRow.SectionCode = sourceRow.SectionCode;                          // 拠点コード
            //targetRow.SubSectionCode = sourceRow.SubSectionCode;                    // 部門コード
            targetRow.CommonSeqNo = sourceRow.CommonSeqNo;                          // 共通通番
            targetRow.StockSlipDtlNum = sourceRow.StockSlipDtlNum;                  // 仕入明細通番
            targetRow.SupplierFormalSrc = sourceRow.SupplierFormalSrc;              // 仕入形式（元）
            targetRow.StockSlipDtlNumSrc = sourceRow.StockSlipDtlNumSrc;            // 仕入明細通番（元）
            targetRow.AcptAnOdrStatusSync = sourceRow.AcptAnOdrStatusSync;          // 受注ステータス（同時）
            targetRow.SalesSlipDtlNumSync = sourceRow.SalesSlipDtlNumSync;          // 売上明細通番（同時）
            targetRow.StockSlipCdDtl = sourceRow.StockSlipCdDtl;                    // 仕入伝票区分（明細）
            //targetRow.StockInputCode = sourceRow.StockInputCode;                    // 仕入入力者コード
            //targetRow.StockInputName = sourceRow.StockInputName;                    // 仕入入力者名称
            //targetRow.StockAgentCode = sourceRow.StockAgentCode;                    // 仕入担当者コード
            //targetRow.StockAgentName = sourceRow.StockAgentName;                    // 仕入担当者名称
            targetRow.GoodsKindCode = sourceRow.GoodsKindCode;                      // 商品属性
            targetRow.GoodsMakerCd = sourceRow.GoodsMakerCd;                        // 商品メーカーコード
            targetRow.MakerName = sourceRow.MakerName;                              // メーカー名称
            targetRow.MakerKanaName = sourceRow.MakerKanaName;                      // メーカーカナ名称
            targetRow.CmpltMakerKanaName = sourceRow.CmpltMakerKanaName;            // メーカーカナ名称（一式）
            targetRow.GoodsNo = sourceRow.GoodsNo;                                  // 商品番号
            targetRow.GoodsName = sourceRow.GoodsName;                              // 商品名称
            targetRow.GoodsNameKana = sourceRow.GoodsNameKana;                      // 商品名称カナ
            targetRow.GoodsLGroup = sourceRow.GoodsLGroup;                          // 商品大分類コード
            targetRow.GoodsLGroupName = sourceRow.GoodsLGroupName;                  // 商品大分類名称
            targetRow.GoodsMGroup = sourceRow.GoodsMGroup;                          // 商品中分類コード
            targetRow.GoodsMGroupName = sourceRow.GoodsMGroupName;                  // 商品中分類名称
            targetRow.BLGroupCode = sourceRow.BLGroupCode;                          // BLグループコード
            targetRow.BLGroupName = sourceRow.BLGroupName;                          // BLグループコード名称
            targetRow.BLGoodsCode = sourceRow.BLGoodsCode;                          // BL商品コード
            targetRow.BLGoodsFullName = sourceRow.BLGoodsFullName;                  // BL商品コード名称（全角）
            targetRow.EnterpriseGanreCode = sourceRow.EnterpriseGanreCode;          // 自社分類コード
            targetRow.EnterpriseGanreName = sourceRow.EnterpriseGanreName;          // 自社分類名称
            targetRow.WarehouseCode = sourceRow.WarehouseCode;                      // 倉庫コード
            targetRow.WarehouseName = sourceRow.WarehouseName;                      // 倉庫名称
            targetRow.WarehouseShelfNo = sourceRow.WarehouseShelfNo;                // 倉庫棚番
            targetRow.StockOrderDivCd = sourceRow.StockOrderDivCd;                  // 仕入在庫取寄せ区分
            targetRow.OpenPriceDiv = sourceRow.OpenPriceDiv;                        // オープン価格区分
            targetRow.GoodsRateRank = sourceRow.GoodsRateRank;                      // 商品掛率ランク
            targetRow.CustRateGrpCode = sourceRow.CustRateGrpCode;                  // 得意先掛率グループコード
            targetRow.SuppRateGrpCode = sourceRow.SuppRateGrpCode;                  // 仕入先掛率グループコード
            targetRow.ListPriceTaxExcFl = sourceRow.ListPriceTaxExcFl;              // 定価（税抜，浮動）
            targetRow.ListPriceTaxIncFl = sourceRow.ListPriceTaxIncFl;              // 定価（税込，浮動）
            targetRow.StockRate = sourceRow.StockRate;                              // 仕入率
            targetRow.RateSectStckUnPrc = sourceRow.RateSectStckUnPrc;              // 掛率設定拠点（仕入単価）
            targetRow.RateDivStckUnPrc = sourceRow.RateDivStckUnPrc;                // 掛率設定区分（仕入単価）
            targetRow.UnPrcCalcCdStckUnPrc = sourceRow.UnPrcCalcCdStckUnPrc;        // 単価算出区分（仕入単価）
            targetRow.PriceCdStckUnPrc = sourceRow.PriceCdStckUnPrc;                // 価格区分（仕入単価）
            targetRow.StdUnPrcStckUnPrc = sourceRow.StdUnPrcStckUnPrc;              // 基準単価（仕入単価）
            targetRow.FracProcUnitStcUnPrc = sourceRow.FracProcUnitStcUnPrc;        // 端数処理単位（仕入単価）
            targetRow.FracProcStckUnPrc = sourceRow.FracProcStckUnPrc;              // 端数処理（仕入単価）
            targetRow.StockUnitPriceFl = sourceRow.StockUnitPriceFl;                // 仕入単価（税抜，浮動）
            targetRow.StockUnitTaxPriceFl = sourceRow.StockUnitTaxPriceFl;          // 仕入単価（税込，浮動）
            targetRow.StockUnitChngDiv = sourceRow.StockUnitChngDiv;                // 仕入単価変更区分
            targetRow.BfStockUnitPriceFl = sourceRow.BfStockUnitPriceFl;            // 変更前仕入単価（浮動）
            targetRow.BfListPrice = sourceRow.BfListPrice;                          // 変更前定価
            targetRow.RateBLGoodsCode = sourceRow.RateBLGoodsCode;                  // BL商品コード（掛率）
            targetRow.RateBLGoodsName = sourceRow.RateBLGoodsName;                  // BL商品コード名称（掛率）
            targetRow.RateGoodsRateGrpCd = sourceRow.RateGoodsRateGrpCd;            // 商品掛率グループコード（掛率）
            targetRow.RateGoodsRateGrpNm = sourceRow.RateGoodsRateGrpNm;            // 商品掛率グループ名称（掛率）
            targetRow.RateBLGroupCode = sourceRow.RateBLGroupCode;                  // BLグループコード（掛率）
            targetRow.RateBLGroupName = sourceRow.RateBLGroupName;                  // BLグループ名称（掛率）
            targetRow.StockCount = sourceRow.StockCount;                            // 仕入数
            targetRow.OrderCnt = sourceRow.OrderCnt;                                // 発注数量
            targetRow.OrderAdjustCnt = sourceRow.OrderAdjustCnt;                    // 発注調整数
            targetRow.OrderRemainCnt = sourceRow.OrderRemainCnt;                    // 発注残数
            targetRow.RemainCntUpdDate = sourceRow.RemainCntUpdDate;                // 残数更新日
            targetRow.StockPriceTaxExc = sourceRow.StockPriceTaxExc;                // 仕入金額（税抜き）
            targetRow.StockPriceTaxInc = sourceRow.StockPriceTaxInc;                // 仕入金額（税込み）
            targetRow.StockGoodsCd = sourceRow.StockGoodsCd;                        // 仕入商品区分
            targetRow.StockPriceConsTax = sourceRow.StockPriceConsTax;              // 仕入金額消費税額
            targetRow.TaxationCode = sourceRow.TaxationCode;                        // 課税区分
            targetRow.StockDtiSlipNote1 = sourceRow.StockDtiSlipNote1;              // 仕入伝票明細備考1
            targetRow.SalesCustomerCode = sourceRow.SalesCustomerCode;              // 販売先コード
            targetRow.SalesCustomerSnm = sourceRow.SalesCustomerSnm;                // 販売先略称
            targetRow.SlipMemo1 = sourceRow.SlipMemo1;                              // 伝票メモ１
            targetRow.SlipMemo2 = sourceRow.SlipMemo2;                              // 伝票メモ２
            targetRow.SlipMemo3 = sourceRow.SlipMemo3;                              // 伝票メモ３
            targetRow.InsideMemo1 = sourceRow.InsideMemo1;                          // 社内メモ１
            targetRow.InsideMemo2 = sourceRow.InsideMemo2;                          // 社内メモ２
            targetRow.InsideMemo3 = sourceRow.InsideMemo3;                          // 社内メモ３
            targetRow.SupplierCd = sourceRow.SupplierCd;                            // 仕入先コード
            targetRow.SupplierSnm = sourceRow.SupplierSnm;                          // 仕入先略称
            targetRow.AddresseeCode = sourceRow.AddresseeCode;                      // 納品先コード
            targetRow.AddresseeName = sourceRow.AddresseeName;                      // 納品先名称
            targetRow.DirectSendingCd = sourceRow.DirectSendingCd;                  // 直送区分
            targetRow.OrderNumber = sourceRow.OrderNumber;                          // 発注番号
            targetRow.WayToOrder = sourceRow.WayToOrder;                            // 注文方法
            targetRow.DeliGdsCmpltDueDate = sourceRow.DeliGdsCmpltDueDate;          // 納品完了予定日
            targetRow.ExpectDeliveryDate = sourceRow.ExpectDeliveryDate;            // 希望納期
            targetRow.OrderDataCreateDiv = sourceRow.OrderDataCreateDiv;            // 発注データ作成区分
            targetRow.OrderDataCreateDate = sourceRow.OrderDataCreateDate;          // 発注データ作成日
            targetRow.OrderFormIssuedDiv = sourceRow.OrderFormIssuedDiv;            // 発注書発行済区分
            targetRow.DtlRelationGuid = sourceRow.DtlRelationGuid;                  // 明細関連付けGUID
            targetRow.GoodsOfferDate = sourceRow.GoodsOfferDate;                    // 商品提供日付
            targetRow.PriceStartDate = sourceRow.PriceStartDate;                    // 価格開始日付
            targetRow.PriceOfferDate = sourceRow.PriceOfferDate;                    // 価格提供日付

            targetRow.ShipmentPosCnt = sourceRow.ShipmentPosCnt;
            targetRow.ShipmentPosCntDisplay = sourceRow.ShipmentPosCntDisplay;
            targetRow.ListPriceDisplay = sourceRow.ListPriceDisplay;
            targetRow.StockUnitPriceDisplay = sourceRow.StockUnitPriceDisplay;
            targetRow.StockCountMin = sourceRow.StockCountMin;
            targetRow.StockCountDefault = sourceRow.StockCountDefault;
            targetRow.StockCountDisplay = sourceRow.StockCountDisplay;
            targetRow.StockCountMax = sourceRow.StockCountMax;
            targetRow.StockPriceDisplay = sourceRow.StockPriceDisplay;
            targetRow.TaxDiv = sourceRow.TaxDiv;
            targetRow.CanTaxDivChange = sourceRow.CanTaxDivChange;
            targetRow.StockPriceDiectInput = sourceRow.StockPriceDiectInput;


            targetRow.EditStatus = sourceRow.EditStatus;
            targetRow.RowStatus = ctROWSTATUS_NORMAL;

			#endregion
		}

		/// <summary>
		/// ＤＢから読み込んだ仕入データオブジェクトをインスタンス変数にキャッシュします。
		/// </summary>
		/// <param name="source">仕入データオブジェクト</param>
		private void CacheDBData(StockSlip source)
		{
			this._stockSlipDBData = source.Clone();
		}

		/// <summary>
		/// 仕入明細、計上元仕入明細、売上データ(仕入同時計上)テーブルをクリアします。
		/// </summary>
		private void ClearDetailTables()
		{
			this._stockDetailDataTable.Rows.Clear();
			this._salesTempDataTable.Rows.Clear();
			this._addUpSrcSalesSlipDataTable.Rows.Clear();
			this._addUpSrcSalesDetailDataTable.Rows.Clear();
			this._addUpSrcDetailDataTable.Rows.Clear();
			this._stockInfoDataTable.Rows.Clear();
            this.ClearGoodsCacheInfo();
		}

		/// <summary>
		/// 仕入明細データと計上元仕入明細データを各データテーブルにキャッシュします。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="baseStockSlip">処理元仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データオブジェクトリスト</param>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		private void CacheStockDetail( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			if (addUpSrcDetailList != null)
			{
				// 計上元仕入明細データをキャッシュ
				foreach (StockDetail stockDetail in addUpSrcDetailList)
				{
					this.CacheAddUpSrcStockDetailDataTable(stockDetail, this._addUpSrcDetailDataTable);
				}
			}

			// 仕入明細データをキャッシュ
			foreach (StockDetail stockDetail in stockDetailList)
			{
				this.CacheStockDetailDataTable(stockSlip, stockDetail, stockDetailDataTable);
			}

			// 仕入明細行オブジェクトの入荷残数の値を設定する。
			this.StockDetailRowAddUpEnableCountSetting();

            stockDetailDataTable.AcceptChanges();
		}

		/// <summary>
		/// ＤＢから取得した仕入明細データをデータテーブルにキャッシュします。
		/// </summary>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		private void CacheStockDetailDBData(List<StockDetail> stockDetailList)
		{
			this._stockDetailDBDataList.Clear();

			foreach (StockDetail stockDetail in stockDetailList)
			{
				this._stockDetailDBDataList.Add(stockDetail.Clone());
			}
		}

		/// <summary>
		/// ＤＢから取得した仕入データを調整します。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		private void AdjustStockReadDBData( ref StockSlip stockSlip, ref List<StockDetail> stockDetailList)
        {
            #region 仕入先情報の調整

            // 仕入先からの情報を調整
            Supplier supplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int status = this._supplierAcs.Read(out supplier, stockSlip.EnterpriseCode, stockSlip.SupplierCd);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return;
            }

            // 支払先の情報を調整
            status = this._supplierAcs.Read(out supplier, stockSlip.EnterpriseCode, stockSlip.PayeeCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return;
            }

            stockSlip.PayeeName = supplier.SupplierNm1;
            stockSlip.PayeeName2 = supplier.SupplierNm2;
            stockSlip.PaymentTotalDay = supplier.PaymentTotalDay;
            stockSlip.NTimeCalcStDate = supplier.NTimeCalcStDate;
            // 2009.05.12 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //stockSlip.SuppCTaxLayCd = (supplier.SuppCTaxLayRefCd == 1) ? supplier.SuppCTaxLayCd : this._stockSlipInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod; // 2009.03.25
            if (this._stockSlipInputInitDataAcs.GetTaxRateSet() == null)
            {
                stockSlip.SuppCTaxLayCd = supplier.SuppCTaxLayCd;
            }
            else
            {
                stockSlip.SuppCTaxLayCd = (supplier.SuppCTaxLayRefCd == 1) ? supplier.SuppCTaxLayCd : this._stockSlipInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod; // 2009.03.25
            }
            // 2009.05.12 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #endregion

            #region 拠点情報の調整

            SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(stockSlip.StockSectionCd);
            if (secInfoSet != null)
            {
                stockSlip.StockSectionNm = secInfoSet.SectionGuideNm;
            }

            if (stockSlip.SubSectionCode != 0)
            {
                stockSlip.SubSectionName = this._stockSlipInputInitDataAcs.GetName_FromSubSection(stockSlip.SubSectionCode);
            }

            #endregion
        }

        /// <summary>
        /// ＤＢに書き込んだ仕入データを調整します。
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
        private void AdjustStockSaveDBData(ref StockSlip stockSlip, ref List<StockDetail> stockDetailList)
        {
            #region 拠点情報の調整

            SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(stockSlip.StockSectionCd);
            if (secInfoSet != null)
            {
                stockSlip.StockSectionNm = secInfoSet.SectionGuideNm;
            }

            if (stockSlip.SubSectionCode != 0)
            {
                stockSlip.SubSectionName = this._stockSlipInputInitDataAcs.GetName_FromSubSection(stockSlip.SubSectionCode);
            }
            #endregion
        }

		/// <summary>
		/// 仕入明細データオブジェクトをデータテーブルにキャッシュします。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetail">仕入明細データオブジェクト</param>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		private void CacheStockDetailDataTable( StockSlip stockSlip, StockDetail stockDetail, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			try
			{
				stockDetailDataTable.AddStockDetailRow(this.CreateRowFromUIData(stockSlip, stockDetail, stockDetailDataTable));
			}
			catch (ConstraintException)
			{
				StockInputDataSet.StockDetailRow row = stockDetailDataTable.FindBySupplierSlipNoStockRowNo(stockDetail.SupplierSlipNo, stockDetail.StockRowNo);
				this.SetRowFromUIData(ref row, stockSlip, stockDetail);
			}
		}

		/// <summary>
		/// 仕入明細データテーブルを生成し、データをキャッシュします。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データオブジェクトリスト</param>
		private StockInputDataSet.StockDetailDataTable CreateStockDetailDataTable( StockSlip stockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList )
		{
			StockInputDataSet.StockDetailDataTable stockDetailDataTable = new StockInputDataSet.StockDetailDataTable();
			this.CacheStockDetail(stockSlip, stockSlip, stockDetailList, addUpSrcDetailList, stockDetailDataTable);
			return stockDetailDataTable;
		}

		/// <summary>
		/// 仕入明細データオブジェクトから仕入明細データ行オブジェクトに項目を設定します。
		/// </summary>
		/// <param name="row">仕入明細データ行オブジェクト</param>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetail">仕入明細データオブジェクト</param>
		private void SetRowFromUIData( ref StockInputDataSet.StockDetailRow row, StockSlip stockSlip, StockDetail stockDetail )
		{
			#region ●項目セット（そのままセットする項目）

            //row.CreateDateTime = stockDetail.CreateDateTime;                    // 作成日時
            //row.UpdateDateTime = stockDetail.UpdateDateTime;                    // 更新日時
            //row.EnterpriseCode = stockDetail.EnterpriseCode;                    // 企業コード
            //row.FileHeaderGuid = stockDetail.FileHeaderGuid;                    // GUID
            //row.UpdEmployeeCode = stockDetail.UpdEmployeeCode;                  // 更新従業員コード
            //row.UpdAssemblyId1 = stockDetail.UpdAssemblyId1;                    // 更新アセンブリID1
            //row.UpdAssemblyId2 = stockDetail.UpdAssemblyId2;                    // 更新アセンブリID2
            //row.LogicalDeleteCode = stockDetail.LogicalDeleteCode;              // 論理削除区分
            row.AcceptAnOrderNo = stockDetail.AcceptAnOrderNo;                  // 受注番号
            row.SupplierFormal = stockDetail.SupplierFormal;                    // 仕入形式
            row.SupplierSlipNo = stockDetail.SupplierSlipNo;                    // 仕入伝票番号
            row.StockRowNo = stockDetail.StockRowNo;                            // 仕入行番号
            //row.SectionCode = stockDetail.SectionCode;                          // 拠点コード
            //row.SubSectionCode = stockDetail.SubSectionCode;                    // 部門コード
            row.CommonSeqNo = stockDetail.CommonSeqNo;                          // 共通通番
            row.StockSlipDtlNum = stockDetail.StockSlipDtlNum;                  // 仕入明細通番
            row.SupplierFormalSrc = stockDetail.SupplierFormalSrc;              // 仕入形式（元）
            row.StockSlipDtlNumSrc = stockDetail.StockSlipDtlNumSrc;            // 仕入明細通番（元）
            row.AcptAnOdrStatusSync = stockDetail.AcptAnOdrStatusSync;          // 受注ステータス（同時）
            row.SalesSlipDtlNumSync = stockDetail.SalesSlipDtlNumSync;          // 売上明細通番（同時）
            row.StockSlipCdDtl = stockDetail.StockSlipCdDtl;                    // 仕入伝票区分（明細）
            //row.StockInputCode = stockDetail.StockInputCode;                    // 仕入入力者コード
            //row.StockInputName = stockDetail.StockInputName;                    // 仕入入力者名称
            //row.StockAgentCode = stockDetail.StockAgentCode;                    // 仕入担当者コード
            //row.StockAgentName = stockDetail.StockAgentName;                    // 仕入担当者名称
            row.GoodsKindCode = stockDetail.GoodsKindCode;                      // 商品属性
            row.GoodsMakerCd = stockDetail.GoodsMakerCd;                        // 商品メーカーコード
            row.MakerName = stockDetail.MakerName;                              // メーカー名称
            row.MakerKanaName = stockDetail.MakerKanaName;                      // メーカーカナ名称
            row.CmpltMakerKanaName = stockDetail.CmpltMakerKanaName;            // メーカーカナ名称（一式）
            row.GoodsNo = stockDetail.GoodsNo;                                  // 商品番号
            row.GoodsName = stockDetail.GoodsName;                              // 商品名称
            row.GoodsNameKana = stockDetail.GoodsNameKana;                      // 商品名称カナ
            row.GoodsLGroup = stockDetail.GoodsLGroup;                          // 商品大分類コード
            row.GoodsLGroupName = stockDetail.GoodsLGroupName;                  // 商品大分類名称
            row.GoodsMGroup = stockDetail.GoodsMGroup;                          // 商品中分類コード
            row.GoodsMGroupName = stockDetail.GoodsMGroupName;                  // 商品中分類名称
            row.BLGroupCode = stockDetail.BLGroupCode;                          // BLグループコード
            row.BLGroupName = stockDetail.BLGroupName;                          // BLグループコード名称
            row.BLGoodsCode = stockDetail.BLGoodsCode;                          // BL商品コード
            row.BLGoodsFullName = stockDetail.BLGoodsFullName;                  // BL商品コード名称（全角）
            row.EnterpriseGanreCode = stockDetail.EnterpriseGanreCode;          // 自社分類コード
            row.EnterpriseGanreName = stockDetail.EnterpriseGanreName;          // 自社分類名称
            row.WarehouseCode = stockDetail.WarehouseCode;                      // 倉庫コード
            row.WarehouseName = stockDetail.WarehouseName;                      // 倉庫名称
            row.WarehouseShelfNo = stockDetail.WarehouseShelfNo;                // 倉庫棚番
            row.StockOrderDivCd = stockDetail.StockOrderDivCd;                  // 仕入在庫取寄せ区分
            row.OpenPriceDiv = stockDetail.OpenPriceDiv;                        // オープン価格区分
            row.GoodsRateRank = stockDetail.GoodsRateRank;                      // 商品掛率ランク
            row.CustRateGrpCode = stockDetail.CustRateGrpCode;                  // 得意先掛率グループコード
            row.SuppRateGrpCode = stockDetail.SuppRateGrpCode;                  // 仕入先掛率グループコード
            row.ListPriceTaxExcFl = stockDetail.ListPriceTaxExcFl;              // 定価（税抜，浮動）
            row.ListPriceTaxIncFl = stockDetail.ListPriceTaxIncFl;              // 定価（税込，浮動）
            row.StockRate = stockDetail.StockRate;                              // 仕入率
            row.RateSectStckUnPrc = stockDetail.RateSectStckUnPrc;              // 掛率設定拠点（仕入単価）
            row.RateDivStckUnPrc = stockDetail.RateDivStckUnPrc;                // 掛率設定区分（仕入単価）
            row.UnPrcCalcCdStckUnPrc = stockDetail.UnPrcCalcCdStckUnPrc;        // 単価算出区分（仕入単価）
            row.PriceCdStckUnPrc = stockDetail.PriceCdStckUnPrc;                // 価格区分（仕入単価）
            row.StdUnPrcStckUnPrc = stockDetail.StdUnPrcStckUnPrc;              // 基準単価（仕入単価）
            row.FracProcUnitStcUnPrc = stockDetail.FracProcUnitStcUnPrc;        // 端数処理単位（仕入単価）
            row.FracProcStckUnPrc = stockDetail.FracProcStckUnPrc;              // 端数処理（仕入単価）
            row.StockUnitPriceFl = stockDetail.StockUnitPriceFl;                // 仕入単価（税抜，浮動）
            row.StockUnitTaxPriceFl = stockDetail.StockUnitTaxPriceFl;          // 仕入単価（税込，浮動）
            row.StockUnitChngDiv = stockDetail.StockUnitChngDiv;                // 仕入単価変更区分
            row.BfStockUnitPriceFl = stockDetail.BfStockUnitPriceFl;            // 変更前仕入単価（浮動）
            row.BfListPrice = stockDetail.BfListPrice;                          // 変更前定価
            row.RateBLGoodsCode = stockDetail.RateBLGoodsCode;                  // BL商品コード（掛率）
            row.RateBLGoodsName = stockDetail.RateBLGoodsName;                  // BL商品コード名称（掛率）
            row.RateGoodsRateGrpCd = stockDetail.RateGoodsRateGrpCd;            // 商品掛率グループコード（掛率）
            row.RateGoodsRateGrpNm = stockDetail.RateGoodsRateGrpNm;            // 商品掛率グループ名称（掛率）
            row.RateBLGroupCode = stockDetail.RateBLGroupCode;                  // BLグループコード（掛率）
            row.RateBLGroupName = stockDetail.RateBLGroupName;                  // BLグループ名称（掛率）
            row.StockCount = stockDetail.StockCount;                            // 仕入数
            row.OrderCnt = stockDetail.OrderCnt;                                // 発注数量
            row.OrderAdjustCnt = stockDetail.OrderAdjustCnt;                    // 発注調整数
            row.OrderRemainCnt = stockDetail.OrderRemainCnt;                    // 発注残数
            row.RemainCntUpdDate = stockDetail.RemainCntUpdDate;                // 残数更新日
            row.StockPriceTaxExc = stockDetail.StockPriceTaxExc;                // 仕入金額（税抜き）
            row.StockPriceTaxInc = stockDetail.StockPriceTaxInc;                // 仕入金額（税込み）
            row.StockGoodsCd = stockDetail.StockGoodsCd;                        // 仕入商品区分
            row.StockPriceConsTax = stockDetail.StockPriceConsTax;              // 仕入金額消費税額
            row.TaxationCode = stockDetail.TaxationCode;                        // 課税区分
            row.StockDtiSlipNote1 = stockDetail.StockDtiSlipNote1;              // 仕入伝票明細備考1
            row.SalesCustomerCode = stockDetail.SalesCustomerCode;              // 販売先コード
            row.SalesCustomerSnm = stockDetail.SalesCustomerSnm;                // 販売先略称
            row.SlipMemo1 = stockDetail.SlipMemo1;                              // 伝票メモ１
            row.SlipMemo2 = stockDetail.SlipMemo2;                              // 伝票メモ２
            row.SlipMemo3 = stockDetail.SlipMemo3;                              // 伝票メモ３
            row.InsideMemo1 = stockDetail.InsideMemo1;                          // 社内メモ１
            row.InsideMemo2 = stockDetail.InsideMemo2;                          // 社内メモ２
            row.InsideMemo3 = stockDetail.InsideMemo3;                          // 社内メモ３
            row.SupplierCd = stockDetail.SupplierCd;                            // 仕入先コード
            row.SupplierSnm = stockDetail.SupplierSnm;                          // 仕入先略称
            row.AddresseeCode = stockDetail.AddresseeCode;                      // 納品先コード
            row.AddresseeName = stockDetail.AddresseeName;                      // 納品先名称
            row.DirectSendingCd = stockDetail.DirectSendingCd;                  // 直送区分
            row.OrderNumber = stockDetail.OrderNumber;                          // 発注番号
            row.WayToOrder = stockDetail.WayToOrder;                            // 注文方法
            row.DeliGdsCmpltDueDate = stockDetail.DeliGdsCmpltDueDate;          // 納品完了予定日
            row.ExpectDeliveryDate = stockDetail.ExpectDeliveryDate;            // 希望納期
            row.OrderDataCreateDiv = stockDetail.OrderDataCreateDiv;            // 発注データ作成区分
            row.OrderDataCreateDate = stockDetail.OrderDataCreateDate;          // 発注データ作成日
            row.OrderFormIssuedDiv = stockDetail.OrderFormIssuedDiv;            // 発注書発行済区分
            //row.DtlRelationGuid = stockDetail.DtlRelationGuid;                  // 明細関連付けGUID
            row.GoodsOfferDate = stockDetail.GoodsOfferDate;                    // 商品提供日付
            row.PriceStartDate = stockDetail.PriceStartDate;                    // 価格開始日付
            row.PriceOfferDate = stockDetail.PriceOfferDate;                    // 価格提供日付

			#endregion

			row.DtlRelationGuid = Guid.Empty;								// 明細関連付けGUID

			int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

            row.StockCountDisplay = row.StockCount * sign;                  // 数量(表示)

			// 値引き行の場合は行ステータスを変更する
            if (stockDetail.StockSlipCdDtl == 2)
            {
                row.EditStatus = ( stockDetail.StockCount == 0 ) ? ctEDITSTATUS_RowDiscount : ctEDITSTATUS_GoodsDiscount;
            }
			// 計上元明細通番が入っていて仕入形式が計上元と異なる場合は計上明細
			else if (( stockDetail.StockSlipDtlNumSrc != 0 ) && ( stockDetail.SupplierFormalSrc != stockDetail.SupplierFormal ))
			{
                if (stockDetail.StockSlipDtlNum != 0)
                {
                    row.EditStatus = ctEDITSTATUS_ArrivalAddUpEdit;
                }
                else
                {
                    row.EditStatus = ctEDITSTATUS_ArrivalAddUpNew;
                }
			}
			else
			{
				row.EditStatus = ctEDITSTATUS_AllOK;
			}
            row.RowStatus = ctROWSTATUS_NORMAL;

			//---<< 仕入単価、定価（表示用）のセット >>---//
            if (stockSlip.SuppCTaxLayCd == 9)
            {
                row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
                row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
            }
			// 総額表示しない
			else if (stockSlip.SuppTtlAmntDspWayCd == 0)
			{
				switch (stockDetail.TaxationCode)
				{
					// 課税
					case (int)CalculateTax.TaxationCode.TaxExc:
						row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
						row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
						break;
					// 非課税
					case (int)CalculateTax.TaxationCode.TaxNone:
						row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
						row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
						break;
					// 課税（内税）
					case (int)CalculateTax.TaxationCode.TaxInc:
						row.StockUnitPriceDisplay = stockDetail.StockUnitTaxPriceFl;
						row.ListPriceDisplay = stockDetail.ListPriceTaxIncFl;
						break;
				}
			}
			// 総額表示する
			else
			{
				row.StockUnitPriceDisplay = stockDetail.StockUnitTaxPriceFl;
				row.ListPriceDisplay = stockDetail.ListPriceTaxIncFl;
			}


			//---<< 仕入金額（表示用）のセット >>---//
			switch (stockDetail.StockGoodsCd)
			{
				// 商品、商品外、合計入力
				case 0:
				case 1:
                case 6:
				{
                    // 転嫁方式：非課税
                    if (stockSlip.SuppCTaxLayCd == 9)
                    {
                        row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
                    }
					// 総額表示しない
					else if (stockSlip.SuppTtlAmntDspWayCd == 0)
					{
						switch (stockDetail.TaxationCode)
						{
							case (int)CalculateTax.TaxationCode.TaxExc:
								row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
								break;
							case (int)CalculateTax.TaxationCode.TaxNone:
								row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
								break;
							case (int)CalculateTax.TaxationCode.TaxInc:
								row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
								break;
						}
					}
					// 総額表示する
					else
					{
						row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
					}
					break;
				}
				// 消費税調整
				case 2:
				case 4:
				{
					row.StockPriceDisplay = row.StockPriceConsTax * sign;
					break;
				}
				// 残高調整
				case 3:
				case 5:
				{
					row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
					break;
				}
			}

			row.TaxDiv = stockDetail.TaxationCode;

			row.StockCountDefault = row.StockCount;

            // 金額直接入力区分
            row.StockPriceDiectInput = ( ( row.StockUnitPriceDisplay == 0 ) && ( row.StockPriceDisplay != 0 ) );

            // 単価、金額の初期値
            row.StockUnitPriceDefault = row.StockUnitPriceFl;
            row.StockUnitTaxPriceDefault = row.StockUnitTaxPriceFl;
            row.StockPriceTaxExcDefault = row.StockPriceTaxExc;
            row.StockPriceTaxIncDefault = row.StockPriceTaxInc;

			// 課税非課税区分変更可能フラグ
			if (stockDetail.StockGoodsCd == 1)
			{
				row.CanTaxDivChange = true;
			}
			else
			{
				row.CanTaxDivChange = false;
			}
		}

		/// <summary>
		/// 仕入明細データテーブルより仕入明細データオブジェクトリストを取得します。
		/// </summary>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="salesTempList">同時売上データオブジェクトリスト</param>
		/// <param name="savedSalesTempList">保存済み売上データ(仕入同時計上)オブジェクトリスト</param>
		private void GetUIDataFromTable( StockInputDataSet.StockDetailDataTable stockDetailDataTable, out List<StockDetail> stockDetailList, out List<SalesTemp> salesTempList, out List<SalesTemp> savedSalesTempList )
		{
			stockDetailList = new List<StockDetail>();
			salesTempList = new List<SalesTemp>();
			savedSalesTempList = new List<SalesTemp>();

			foreach (StockInputDataSet.StockDetailRow row in stockDetailDataTable)
			{
				StockDetail stockDetail;

				// 明細データ取得
				GetUIDataFromRow(row, out stockDetail);

				if (stockDetail != null)
				{
					// 値引き以外で、同時売上入力済み
					if (( stockDetail.StockSlipCdDtl != 2 ) &&
						( ( row.DtlRelationGuid != null ) && ( row.DtlRelationGuid != Guid.Empty ) ))
					{
						StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(row);

						if (salesTempRow != null)
						{
							// 得意先入力済み
							if (salesTempRow.CustomerCode != 0)
							{
								SalesTemp salesTemp = this.GetUIDataFromRow(stockDetail, salesTempRow);
								if (salesTemp != null)
								{
									// 同時に作成する売上情報を仕入明細にセット
									// 新規入力の場合は登録用リストに追加
									if (( stockDetail.AcptAnOdrStatusSync == 0 ) && ( stockDetail.SalesSlipDtlNumSync == 0 ))
									{
										stockDetail.AcptAnOdrStatusSync = salesTemp.AcptAnOdrStatus;
										stockDetail.SalesSlipDtlNumSync = salesTemp.SalesSlipDtlNum;

										salesTempList.Add(salesTemp);
									}
									else
									{
										savedSalesTempList.Add(salesTemp);
									}
								}
							}
						}
					}
					stockDetailList.Add(stockDetail);
				}
			}
		}

		/// <summary>
		/// 仕入明細データ行オブジェクトより、仕入明細データオブジェクトを取得します。
		/// </summary>
		/// <param name="row">仕入明細データ行オブジェクト</param>
		/// <param name="stockDetail">仕入明細データオブジェクト</param>
		private void GetUIDataFromRow( StockInputDataSet.StockDetailRow row, out StockDetail stockDetail )
		{
			stockDetail = GetUIDataFromRow(row);
		}

		/// <summary>
		/// 仕入明細データ行オブジェクトより仕入明細データオブジェクトを取得します。
		/// </summary>
		/// <param name="row">仕入明細データ行オブジェクト</param>
		/// <returns>仕入明細データオブジェクト</returns>
		private StockDetail GetUIDataFromRow(StockInputDataSet.StockDetailRow row)
		{

			StockDetail stockDetail = new StockDetail();


            // 仕入データより
			stockDetail.SectionCode = this._stockSlip.SectionCode;			// 拠点コード
			stockDetail.SubSectionCode = this._stockSlip.SubSectionCode;	// 部門コード
			stockDetail.SupplierFormal = this._stockSlip.SupplierFormal;	// 仕入形式
			stockDetail.SupplierSlipNo = this._stockSlip.SupplierSlipNo;	// 仕入伝票番号
			stockDetail.StockGoodsCd = this._stockSlip.StockGoodsCd;		// 仕入商品区分
			stockDetail.StockInputCode = this._stockSlip.StockInputCode;	// 仕入入力者コード
			stockDetail.StockInputName = this._stockSlip.StockInputName;	// 仕入入力者名称
			stockDetail.StockAgentCode = this._stockSlip.StockAgentCode;	// 仕入担当者コード
			stockDetail.StockAgentName = this._stockSlip.StockAgentName;	// 仕入担当者名称

            // 画面より
            //stockDetail.CreateDateTime = row.CreateDateTime;                    // 作成日時
            //stockDetail.UpdateDateTime = row.UpdateDateTime;                    // 更新日時
            //stockDetail.EnterpriseCode = row.EnterpriseCode;                    // 企業コード
            //stockDetail.FileHeaderGuid = row.FileHeaderGuid;                    // GUID
            //stockDetail.UpdEmployeeCode = row.UpdEmployeeCode;                  // 更新従業員コード
            //stockDetail.UpdAssemblyId1 = row.UpdAssemblyId1;                    // 更新アセンブリID1
            //stockDetail.UpdAssemblyId2 = row.UpdAssemblyId2;                    // 更新アセンブリID2
            //stockDetail.LogicalDeleteCode = row.LogicalDeleteCode;              // 論理削除区分
            stockDetail.AcceptAnOrderNo = row.AcceptAnOrderNo;                  // 受注番号
            stockDetail.SupplierFormal = row.SupplierFormal;                    // 仕入形式
            stockDetail.SupplierSlipNo = row.SupplierSlipNo;                    // 仕入伝票番号
            stockDetail.StockRowNo = row.StockRowNo;                            // 仕入行番号
            stockDetail.SectionCode = row.SectionCode;                          // 拠点コード
            stockDetail.SubSectionCode = row.SubSectionCode;                    // 部門コード
            stockDetail.CommonSeqNo = row.CommonSeqNo;                          // 共通通番
            stockDetail.StockSlipDtlNum = row.StockSlipDtlNum;                  // 仕入明細通番
            stockDetail.SupplierFormalSrc = row.SupplierFormalSrc;              // 仕入形式（元）
            stockDetail.StockSlipDtlNumSrc = row.StockSlipDtlNumSrc;            // 仕入明細通番（元）
            stockDetail.AcptAnOdrStatusSync = row.AcptAnOdrStatusSync;          // 受注ステータス（同時）
            stockDetail.SalesSlipDtlNumSync = row.SalesSlipDtlNumSync;          // 売上明細通番（同時）
            stockDetail.StockSlipCdDtl = row.StockSlipCdDtl;                    // 仕入伝票区分（明細）
            //stockDetail.StockInputCode = row.StockInputCode;                    // 仕入入力者コード
            //stockDetail.StockInputName = row.StockInputName;                    // 仕入入力者名称
            //stockDetail.StockAgentCode = row.StockAgentCode;                    // 仕入担当者コード
            //stockDetail.StockAgentName = row.StockAgentName;                    // 仕入担当者名称
            stockDetail.GoodsKindCode = row.GoodsKindCode;                      // 商品属性
            stockDetail.GoodsMakerCd = row.GoodsMakerCd;                        // 商品メーカーコード
            stockDetail.MakerName = row.MakerName;                              // メーカー名称
            stockDetail.MakerKanaName = row.MakerKanaName;                      // メーカーカナ名称
            stockDetail.CmpltMakerKanaName = row.CmpltMakerKanaName;            // メーカーカナ名称（一式）
            stockDetail.GoodsNo = row.GoodsNo;                                  // 商品番号
            stockDetail.GoodsName = row.GoodsName;                              // 商品名称
            stockDetail.GoodsNameKana = row.GoodsNameKana;                      // 商品名称カナ
            stockDetail.GoodsLGroup = row.GoodsLGroup;                          // 商品大分類コード
            stockDetail.GoodsLGroupName = row.GoodsLGroupName;                  // 商品大分類名称
            stockDetail.GoodsMGroup = row.GoodsMGroup;                          // 商品中分類コード
            stockDetail.GoodsMGroupName = row.GoodsMGroupName;                  // 商品中分類名称
            stockDetail.BLGroupCode = row.BLGroupCode;                          // BLグループコード
            stockDetail.BLGroupName = row.BLGroupName;                          // BLグループコード名称
            stockDetail.BLGoodsCode = row.BLGoodsCode;                          // BL商品コード
            stockDetail.BLGoodsFullName = row.BLGoodsFullName;                  // BL商品コード名称（全角）
            stockDetail.EnterpriseGanreCode = row.EnterpriseGanreCode;          // 自社分類コード
            stockDetail.EnterpriseGanreName = row.EnterpriseGanreName;          // 自社分類名称
            stockDetail.WarehouseCode = row.WarehouseCode;                      // 倉庫コード
            stockDetail.WarehouseName = row.WarehouseName;                      // 倉庫名称
            stockDetail.WarehouseShelfNo = row.WarehouseShelfNo;                // 倉庫棚番
            stockDetail.StockOrderDivCd = row.StockOrderDivCd;                  // 仕入在庫取寄せ区分
            stockDetail.OpenPriceDiv = row.OpenPriceDiv;                        // オープン価格区分
            stockDetail.GoodsRateRank = row.GoodsRateRank;                      // 商品掛率ランク
            stockDetail.CustRateGrpCode = row.CustRateGrpCode;                  // 得意先掛率グループコード
            stockDetail.SuppRateGrpCode = row.SuppRateGrpCode;                  // 仕入先掛率グループコード
            stockDetail.ListPriceTaxExcFl = row.ListPriceTaxExcFl;              // 定価（税抜，浮動）
            stockDetail.ListPriceTaxIncFl = row.ListPriceTaxIncFl;              // 定価（税込，浮動）
            stockDetail.StockRate = row.StockRate;                              // 仕入率
            stockDetail.RateSectStckUnPrc = row.RateSectStckUnPrc;              // 掛率設定拠点（仕入単価）
            stockDetail.RateDivStckUnPrc = row.RateDivStckUnPrc;                // 掛率設定区分（仕入単価）
            stockDetail.UnPrcCalcCdStckUnPrc = row.UnPrcCalcCdStckUnPrc;        // 単価算出区分（仕入単価）
            stockDetail.PriceCdStckUnPrc = row.PriceCdStckUnPrc;                // 価格区分（仕入単価）
            stockDetail.StdUnPrcStckUnPrc = row.StdUnPrcStckUnPrc;              // 基準単価（仕入単価）
            stockDetail.FracProcUnitStcUnPrc = row.FracProcUnitStcUnPrc;        // 端数処理単位（仕入単価）
            stockDetail.FracProcStckUnPrc = row.FracProcStckUnPrc;              // 端数処理（仕入単価）
            stockDetail.StockUnitPriceFl = row.StockUnitPriceFl;                // 仕入単価（税抜，浮動）
            stockDetail.StockUnitTaxPriceFl = row.StockUnitTaxPriceFl;          // 仕入単価（税込，浮動）
            stockDetail.StockUnitChngDiv = row.StockUnitChngDiv;                // 仕入単価変更区分
            stockDetail.BfStockUnitPriceFl = row.BfStockUnitPriceFl;            // 変更前仕入単価（浮動）
            stockDetail.BfListPrice = row.BfListPrice;                          // 変更前定価
            stockDetail.RateBLGoodsCode = row.RateBLGoodsCode;                  // BL商品コード（掛率）
            stockDetail.RateBLGoodsName = row.RateBLGoodsName;                  // BL商品コード名称（掛率）
            stockDetail.RateGoodsRateGrpCd = row.RateGoodsRateGrpCd;            // 商品掛率グループコード（掛率）
            stockDetail.RateGoodsRateGrpNm = row.RateGoodsRateGrpNm;            // 商品掛率グループ名称（掛率）
            stockDetail.RateBLGroupCode = row.RateBLGroupCode;                  // BLグループコード（掛率）
            stockDetail.RateBLGroupName = row.RateBLGroupName;                  // BLグループ名称（掛率）
            stockDetail.StockCount = row.StockCount;                            // 仕入数
            stockDetail.OrderCnt = row.OrderCnt;                                // 発注数量
            stockDetail.OrderAdjustCnt = row.OrderAdjustCnt;                    // 発注調整数
            stockDetail.OrderRemainCnt = row.OrderRemainCnt;                    // 発注残数
            stockDetail.RemainCntUpdDate = row.RemainCntUpdDate;                // 残数更新日
            stockDetail.StockPriceTaxExc = row.StockPriceTaxExc;                // 仕入金額（税抜き）
            stockDetail.StockPriceTaxInc = row.StockPriceTaxInc;                // 仕入金額（税込み）
            stockDetail.StockGoodsCd = row.StockGoodsCd;                        // 仕入商品区分
            stockDetail.StockPriceConsTax = row.StockPriceConsTax;              // 仕入金額消費税額
            stockDetail.TaxationCode = row.TaxationCode;                        // 課税区分
            stockDetail.StockDtiSlipNote1 = row.StockDtiSlipNote1;              // 仕入伝票明細備考1
            stockDetail.SalesCustomerCode = row.SalesCustomerCode;              // 販売先コード
            stockDetail.SalesCustomerSnm = row.SalesCustomerSnm;                // 販売先略称
            stockDetail.SlipMemo1 = row.SlipMemo1;                              // 伝票メモ１
            stockDetail.SlipMemo2 = row.SlipMemo2;                              // 伝票メモ２
            stockDetail.SlipMemo3 = row.SlipMemo3;                              // 伝票メモ３
            stockDetail.InsideMemo1 = row.InsideMemo1;                          // 社内メモ１
            stockDetail.InsideMemo2 = row.InsideMemo2;                          // 社内メモ２
            stockDetail.InsideMemo3 = row.InsideMemo3;                          // 社内メモ３
            //stockDetail.SupplierCd = row.SupplierCd;                            // 仕入先コード
            //stockDetail.SupplierSnm = row.SupplierSnm;                          // 仕入先略称
            //stockDetail.AddresseeCode = row.AddresseeCode;                      // 納品先コード
            //stockDetail.AddresseeName = row.AddresseeName;                      // 納品先名称
            //stockDetail.DirectSendingCd = row.DirectSendingCd;                  // 直送区分
            stockDetail.OrderNumber = row.OrderNumber;                          // 発注番号
            //stockDetail.WayToOrder = row.WayToOrder;                            // 注文方法
            //stockDetail.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate;          // 納品完了予定日
            //stockDetail.ExpectDeliveryDate = row.ExpectDeliveryDate;            // 希望納期
            //stockDetail.OrderDataCreateDiv = row.OrderDataCreateDiv;            // 発注データ作成区分
            //stockDetail.OrderDataCreateDate = row.OrderDataCreateDate;          // 発注データ作成日
            //stockDetail.OrderFormIssuedDiv = row.OrderFormIssuedDiv;            // 発注書発行済区分
            stockDetail.DtlRelationGuid = row.DtlRelationGuid;                  // 明細関連付けGUID
            stockDetail.GoodsOfferDate = row.GoodsOfferDate;                    // 商品提供日付
            stockDetail.PriceStartDate = row.PriceStartDate;                    // 価格開始日付
            stockDetail.PriceOfferDate = row.PriceOfferDate;                    // 価格提供日付

			// 新規伝票の場合は発注数に仕入数をセット
			if (stockDetail.StockSlipDtlNum == 0)
			{
				stockDetail.OrderCnt = stockDetail.StockCount;
			}

			// 未設定分
			//stockDetail.SupplierCd = row.SupplierCd;							// 仕入先コード
			//stockDetail.SupplierSnm = row.SupplierSnm;							// 仕入先略称
			//stockDetail.AddresseeCode = row.AddresseeCode;						// 納品先コード
			//stockDetail.AddresseeName = row.AddresseeName;						// 納品先名称
			//stockDetail.DirectSendingCd = row.DirectSendingCd;					// 直送区分
			stockDetail.OrderNumber = row.OrderNumber;							// 発注番号
			//stockDetail.WayToOrder = row.WayToOrder;							// 注文方法
			//stockDetail.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate;			// 納品完了予定日
			//stockDetail.ExpectDeliveryDate = row.ExpectDeliveryDate;			// 希望納期
			//stockDetail.OrderDataCreateDiv = row.OrderDataCreateDiv;			// 発注データ作成区分
			//stockDetail.OrderDataCreateDate = row.OrderDataCreateDate;			// 発注データ作成日
			//stockDetail.OrderFormIssuedDiv = row.OrderFormIssuedDiv;			// 発注書発行済区分


            // 補正分
            if ((stockDetail.StockSlipCdDtl == 0) && (this._stockSlip.SupplierSlipCd == 20))
            {
                stockDetail.StockSlipCdDtl = 1;
            }

            return stockDetail;
		}

		/// <summary>
		/// 同時売上データ行オブジェクトより同時売上データオブジェクトを取得します。
		/// </summary>
		/// <param name="stockDetail">仕入明細データオブジェクト</param>
		/// <param name="row">同時売上データ行オブジェクト</param>
		/// <returns>同時売上データオブジェクト</returns>
		private SalesTemp GetUIDataFromRow( StockDetail stockDetail, StockInputDataSet.SalesTempRow row )
		{
			SalesTemp salesTemp = new SalesTemp();

			#region ●項目セット

			//salesTempRow.CreateDateTime = salesTempRow.CreateDateTime;				// 作成日時
			//salesTempRow.UpdateDateTime = salesTempRow.UpdateDateTime;				// 更新日時
			//salesTempRow.EnterpriseCode = salesTempRow.EnterpriseCode;				// 企業コード
			//salesTempRow.FileHeaderGuid = salesTempRow.FileHeaderGuid;				// GUID
			//salesTempRow.UpdEmployeeCode = salesTempRow.UpdEmployeeCode;			// 更新従業員コード
			//salesTempRow.UpdAssemblyId1 = salesTempRow.UpdAssemblyId1;				// 更新アセンブリID1
			//salesTempRow.UpdAssemblyId2 = salesTempRow.UpdAssemblyId2;				// 更新アセンブリID2
			//salesTempRow.LogicalDeleteCode = salesTempRow.LogicalDeleteCode;		// 論理削除区分
			salesTemp.AcptAnOdrStatus = row.AcptAnOdrStatus;			// 受注ステータス
			//salesTempRow.SalesSlipNum = salesTempRow.SalesSlipNum;					// 売上伝票番号
			salesTemp.SectionCode = row.SectionCode;					// 拠点コード
			salesTemp.SubSectionCode = row.SubSectionCode;				// 部門コード
			salesTemp.MinSectionCode = row.MinSectionCode;				// 課コード
			salesTemp.DebitNoteDiv = row.DebitNoteDiv;					// 赤伝区分
			//salesTempRow.DebitNLnkSalesSlNum = salesTempRow.DebitNLnkSalesSlNum;	// 赤黒連結売上伝票番号
			salesTemp.SalesSlipCd = row.SalesSlipCd;					// 売上伝票区分
			salesTemp.AccRecDivCd = row.AccRecDivCd;					// 売掛区分
			salesTemp.SalesInpSecCd = row.SalesInpSecCd;				// 売上入力拠点コード
			salesTemp.DemandAddUpSecCd = row.DemandAddUpSecCd;			// 請求計上拠点コード
			salesTemp.ResultsAddUpSecCd = row.ResultsAddUpSecCd;		// 実績計上拠点コード
			salesTemp.UpdateSecCd = row.UpdateSecCd;					// 更新拠点コード
			salesTemp.SearchSlipDate = row.SearchSlipDate;				// 伝票検索日付
			salesTemp.ShipmentDay = row.ShipmentDay;					// 出荷日付
			salesTemp.SalesDate = row.SalesDate;						// 売上日付
			salesTemp.AddUpADate = row.AddUpADate;						// 計上日付
			salesTemp.DelayPaymentDiv = row.DelayPaymentDiv;			// 来勘区分
			salesTemp.ClaimCode = row.ClaimCode;						// 請求先コード
			salesTemp.ClaimSnm = row.ClaimSnm;							// 請求先略称
			salesTemp.CustomerCode = row.CustomerCode;					// 得意先コード
			salesTemp.CustomerName = row.CustomerName;					// 得意先名称
			salesTemp.CustomerName2 = row.CustomerName2;				// 得意先名称2
			salesTemp.CustomerSnm = row.CustomerSnm;					// 得意先略称
			salesTemp.HonorificTitle = row.HonorificTitle;				// 敬称
			salesTemp.OutputNameCode = row.OutputNameCode;				// 諸口コード
			salesTemp.BusinessTypeCode = row.BusinessTypeCode;			// 業種コード
			salesTemp.BusinessTypeName = row.BusinessTypeName;			// 業種名称
			salesTemp.SalesAreaCode = row.SalesAreaCode;				// 販売エリアコード
			salesTemp.SalesAreaName = row.SalesAreaName;				// 販売エリア名称
			salesTemp.SalesInputCode = row.SalesInputCode;				// 売上入力者コード
			salesTemp.SalesInputName = row.SalesInputName;				// 売上入力者名称
			salesTemp.FrontEmployeeCd = row.FrontEmployeeCd;			// 受付従業員コード
			salesTemp.FrontEmployeeNm = row.FrontEmployeeNm;			// 受付従業員名称
			salesTemp.SalesEmployeeCd = row.SalesEmployeeCd;			// 販売従業員コード
			salesTemp.SalesEmployeeNm = row.SalesEmployeeNm;			// 販売従業員名称
			salesTemp.TotalAmountDispWayCd = row.TotalAmountDispWayCd;	// 総額表示方法区分
			salesTemp.TtlAmntDispRateApy = row.TtlAmntDispRateApy;		// 総額表示掛率適用区分
			salesTemp.ConsTaxLayMethod = row.ConsTaxLayMethod;			// 消費税転嫁方式
			salesTemp.ConsTaxRate = row.ConsTaxRate;					// 消費税税率
			salesTemp.FractionProcCd = row.FractionProcCd;				// 端数処理区分
			//salesTempRow.AccRecConsTax = salesTempRow.AccRecConsTax;				// 売掛消費税
			salesTemp.AutoDepositCd = row.AutoDepositCd;				// 自動入金区分
			salesTemp.AutoDepoSlipNum = row.AutoDepoSlipNum;			// 自動入金伝票番号
			//salesTempRow.DepositAllowanceTtl = salesTempRow.DepositAllowanceTtl;	// 入金引当合計額
			//salesTempRow.DepositAlwcBlnce = salesTempRow.DepositAlwcBlnce;			// 入金引当残高
			salesTemp.SlipAddressDiv = row.SlipAddressDiv;				// 伝票住所区分
			salesTemp.AddresseeCode = row.AddresseeCode;				// 納品先コード
			salesTemp.AddresseeName = row.AddresseeName;				// 納品先名称
			salesTemp.AddresseeName2 = row.AddresseeName2;				// 納品先名称2
			salesTemp.AddresseePostNo = row.AddresseePostNo;			// 納品先郵便番号
			salesTemp.AddresseeAddr1 = row.AddresseeAddr1;				// 納品先住所1(都道府県市区郡・町村・字)
			salesTemp.AddresseeAddr2 = row.AddresseeAddr2;				// 納品先住所2(丁目)
			salesTemp.AddresseeAddr3 = row.AddresseeAddr3;				// 納品先住所3(番地)
			salesTemp.AddresseeAddr4 = row.AddresseeAddr4;				// 納品先住所4(アパート名称)
			salesTemp.AddresseeTelNo = row.AddresseeTelNo;				// 納品先電話番号
			salesTemp.AddresseeFaxNo = row.AddresseeFaxNo;				// 納品先FAX番号
			salesTemp.PartySaleSlipNum = row.PartySaleSlipNum;			// 相手先伝票番号
			salesTemp.SlipNote = row.SlipNote;							// 伝票備考
			salesTemp.SlipNote2 = row.SlipNote2;						// 伝票備考２
			salesTemp.RetGoodsReasonDiv = row.RetGoodsReasonDiv;		// 返品理由コード
			salesTemp.RetGoodsReason = row.RetGoodsReason;				// 返品理由
			salesTemp.DetailRowCount = row.DetailRowCount;				// 明細行数
			salesTemp.DeliveredGoodsDiv = row.DeliveredGoodsDiv;		// 納品区分
			salesTemp.DeliveredGoodsDivNm = row.DeliveredGoodsDivNm;	// 納品区分名称
			salesTemp.ReconcileFlag = row.ReconcileFlag;				// 消込フラグ
			salesTemp.SlipPrtSetPaperId = row.SlipPrtSetPaperId;		// 伝票印刷設定用帳票ID
			salesTemp.CompleteCd = row.CompleteCd;						// 一式伝票区分
			salesTemp.ClaimType = row.ClaimType;						// 請求先区分
			salesTemp.SalesPriceFracProcCd = row.SalesPriceFracProcCd;	// 売上金額端数処理区分
			salesTemp.ListPricePrintDiv = row.ListPricePrintDiv;		// 定価印刷区分
			salesTemp.EraNameDispCd1 = row.EraNameDispCd1;				// 元号表示区分１
			salesTemp.CommonSeqNo = row.CommonSeqNo;					// 共通通番
			salesTemp.SalesSlipDtlNum = row.SalesSlipDtlNum;			// 売上明細通番
			salesTemp.AcptAnOdrStatusSrc = row.AcptAnOdrStatusSrc;		// 受注ステータス（元）
			salesTemp.SalesSlipDtlNumSrc = row.SalesSlipDtlNumSrc;		// 売上明細通番（元）
			salesTemp.SalesSlipCdDtl = row.SalesSlipCdDtl;				// 売上伝票区分（明細）
			salesTemp.StockMngExistCd = row.StockMngExistCd;			// 在庫管理有無区分
			salesTemp.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate;	// 納品完了予定日
			salesTemp.GoodsKindCode = row.GoodsKindCode;				// 商品属性
			salesTemp.GoodsMakerCd = row.GoodsMakerCd;					// 商品メーカーコード
			salesTemp.MakerName = row.MakerName;						// メーカー名称
			salesTemp.GoodsNo = row.GoodsNo;							// 商品番号
			salesTemp.GoodsName = row.GoodsName;						// 商品名称
			salesTemp.GoodsShortName = row.GoodsShortName;				// 商品名称略称
			salesTemp.GoodsSetDivCd = row.GoodsSetDivCd;				// セット商品区分
			salesTemp.LargeGoodsGanreCode = row.LargeGoodsGanreCode;	// 商品区分グループコード
			salesTemp.LargeGoodsGanreName = row.LargeGoodsGanreName;	// 商品区分グループ名称
			salesTemp.MediumGoodsGanreCode = row.MediumGoodsGanreCode;	// 商品区分コード
			salesTemp.MediumGoodsGanreName = row.MediumGoodsGanreName;	// 商品区分名称
			salesTemp.DetailGoodsGanreCode = row.DetailGoodsGanreCode;	// 商品区分詳細コード
			salesTemp.DetailGoodsGanreName = row.DetailGoodsGanreName;	// 商品区分詳細名称
			salesTemp.BLGoodsCode = row.BLGoodsCode;					// BL商品コード
			salesTemp.BLGoodsFullName = row.BLGoodsFullName;			// BL商品コード名称（全角）
			salesTemp.EnterpriseGanreCode = row.EnterpriseGanreCode;	// 自社分類コード
			salesTemp.EnterpriseGanreName = row.EnterpriseGanreName;	// 自社分類名称
			salesTemp.WarehouseCode = row.WarehouseCode;				// 倉庫コード
			salesTemp.WarehouseName = row.WarehouseName;				// 倉庫名称
			salesTemp.WarehouseShelfNo = row.WarehouseShelfNo;			// 倉庫棚番
			salesTemp.SalesOrderDivCd = row.SalesOrderDivCd;			// 売上在庫取寄せ区分
			salesTemp.GoodsRateRank = row.GoodsRateRank;				// 商品掛率ランク
			salesTemp.CustRateGrpCode = row.CustRateGrpCode;			// 得意先掛率グループコード
			salesTemp.SuppRateGrpCode = row.SuppRateGrpCode;			// 仕入先掛率グループコード
			salesTemp.ListPriceRate = row.ListPriceRate;				// 定価率
			salesTemp.RateSectPriceUnPrc = row.RateSectPriceUnPrc;		// 掛率設定拠点（定価）
			salesTemp.RateDivLPrice = row.RateDivLPrice;				// 掛率設定区分（定価）
			salesTemp.UnPrcCalcCdLPrice = row.UnPrcCalcCdLPrice;		// 単価算出区分（定価）
			salesTemp.PriceCdLPrice = row.PriceCdLPrice;				// 価格区分（定価）
			salesTemp.StdUnPrcLPrice = row.StdUnPrcLPrice;				// 基準単価（定価）
			salesTemp.FracProcUnitLPrice = row.FracProcUnitLPrice;		// 端数処理単位（定価）
			salesTemp.FracProcLPrice = row.FracProcLPrice;				// 端数処理（定価）
			salesTemp.ListPriceTaxIncFl = row.ListPriceTaxIncFl;		// 定価（税込，浮動）
			salesTemp.ListPriceTaxExcFl = row.ListPriceTaxExcFl;		// 定価（税抜，浮動）
			salesTemp.ListPriceChngCd = row.ListPriceChngCd;			// 定価変更区分
			salesTemp.SalesRate = row.SalesRate;						// 売価率
			salesTemp.RateSectSalUnPrc = row.RateSectSalUnPrc;			// 掛率設定拠点（売上単価）
			salesTemp.RateDivSalUnPrc = row.RateDivSalUnPrc;			// 掛率設定区分（売上単価）
			salesTemp.UnPrcCalcCdSalUnPrc = row.UnPrcCalcCdSalUnPrc;	// 単価算出区分（売上単価）
			salesTemp.PriceCdSalUnPrc = row.PriceCdSalUnPrc;			// 価格区分（売上単価）
			salesTemp.StdUnPrcSalUnPrc = row.StdUnPrcSalUnPrc;			// 基準単価（売上単価）
			salesTemp.FracProcUnitSalUnPrc = row.FracProcUnitSalUnPrc;	// 端数処理単位（売上単価）
			salesTemp.FracProcSalUnPrc = row.FracProcSalUnPrc;			// 端数処理（売上単価）
			salesTemp.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxIncFl;		// 売上単価（税込，浮動）
			salesTemp.SalesUnPrcTaxExcFl = row.SalesUnPrcTaxExcFl;		// 売上単価（税抜，浮動）
			salesTemp.SalesUnPrcChngCd = row.SalesUnPrcChngCd;			// 売上単価変更区分
			salesTemp.CostRate = row.CostRate;							// 原価率
			salesTemp.RateSectCstUnPrc = row.RateSectCstUnPrc;			// 掛率設定拠点（原価単価）
			salesTemp.RateDivUnCst = row.RateDivUnCst;					// 掛率設定区分（原価単価）
			salesTemp.UnPrcCalcCdUnCst = row.UnPrcCalcCdUnCst;			// 単価算出区分（原価単価）
			salesTemp.PriceCdUnCst = row.PriceCdUnCst;					// 価格区分（原価単価）
			salesTemp.StdUnPrcUnCst = row.StdUnPrcUnCst;				// 基準単価（原価単価）
			salesTemp.FracProcUnitUnCst = row.FracProcUnitUnCst;		// 端数処理単位（原価単価）
			salesTemp.FracProcUnCst = row.FracProcUnCst;				// 端数処理（原価単価）
			salesTemp.SalesUnitCost = row.SalesUnitCost;				// 原価単価
			salesTemp.SalesUnitCostChngDiv = row.SalesUnitCostChngDiv;	// 原価単価変更区分
			salesTemp.RateBLGoodsCode = row.RateBLGoodsCode;			// BL商品コード（掛率）
			salesTemp.RateBLGoodsName = row.RateBLGoodsName;			// BL商品コード名称（掛率）
			salesTemp.ShipmentCnt = row.ShipmentCnt;					// 出荷数
			salesTemp.AcptAnOdrRemainCnt = row.AcceptAnOrderCnt;		// 受注残
			salesTemp.SalesMoneyTaxInc = row.SalesMoneyTaxInc;			// 売上金額（税込み）
			salesTemp.SalesMoneyTaxExc = row.SalesMoneyTaxExc;			// 売上金額（税抜き）
			salesTemp.Cost = row.Cost;									// 原価
			salesTemp.GrsProfitChkDiv = row.GrsProfitChkDiv;			// 粗利チェック区分
			salesTemp.SalesGoodsCd = row.SalesGoodsCd;					// 売上商品区分
			salesTemp.SalsePriceConsTax = row.SalsePriceConsTax;		// 売上金額消費税額
			salesTemp.TaxationDivCd = row.TaxationDivCd;				// 課税区分
			salesTemp.PartySlipNumDtl = row.PartySlipNumDtl;			// 相手先伝票番号（明細）
			salesTemp.DtlNote = row.DtlNote;							// 明細備考
			salesTemp.SupplierCd = row.SupplierCd;						// 仕入先コード
			salesTemp.SupplierSnm = row.SupplierSnm;					// 仕入先略称
			salesTemp.SlipMemo1 = row.SlipMemo1;						// 伝票メモ１
			salesTemp.SlipMemo2 = row.SlipMemo2;						// 伝票メモ２
			salesTemp.SlipMemo3 = row.SlipMemo3;						// 伝票メモ３
			salesTemp.SlipMemo4 = row.SlipMemo4;						// 伝票メモ４
			salesTemp.SlipMemo5 = row.SlipMemo5;						// 伝票メモ５
			salesTemp.SlipMemo6 = row.SlipMemo6;						// 伝票メモ６
			salesTemp.InsideMemo1 = row.InsideMemo1;					// 社内メモ１
			salesTemp.InsideMemo2 = row.InsideMemo2;					// 社内メモ２
			salesTemp.InsideMemo3 = row.InsideMemo3;					// 社内メモ３
			salesTemp.InsideMemo4 = row.InsideMemo4;					// 社内メモ４
			salesTemp.InsideMemo5 = row.InsideMemo5;					// 社内メモ５
			salesTemp.InsideMemo6 = row.InsideMemo6;					// 社内メモ６
			salesTemp.BfListPrice = row.BfListPrice;					// 変更前定価
			salesTemp.BfSalesUnitPrice = row.BfSalesUnitPrice;			// 変更前売価
			salesTemp.BfUnitCost = row.BfUnitCost;						// 変更前原価
			salesTemp.PrtGoodsNo = row.PrtGoodsNo;						// 印刷用商品番号
			salesTemp.PrtGoodsName = row.PrtGoodsName;					// 印刷用商品名称
			salesTemp.PrtGoodsMakerCd = row.PrtGoodsMakerCd;			// 印刷用商品メーカーコード
			salesTemp.PrtGoodsMakerNm = row.PrtGoodsMakerNm;			// 印刷用商品メーカー名称
			salesTemp.DtlRelationGuid = row.DtlRelationGuid;			// 明細関連付けGUID

			#endregion

			// 仕入明細データより
			salesTemp.SupplierFormalSync = stockDetail.SupplierFormal;		// 仕入形式（同時）
			salesTemp.StockSlipDtlNumSync = stockDetail.StockSlipDtlNum;	// 仕入明細通番（同時）

			return salesTemp;
		}

		/// <summary>
		/// 指定した仕入明細データを元に仕入明細データテーブル行オブジェクトを生成します。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetail">仕入明細データオブジェクト</param>
		/// <param name="stockDetailDataTable">仕入明細データテーブルオブジェクト</param>
		/// <returns>仕入明細データ行オブジェクト</returns>
		private StockInputDataSet.StockDetailRow CreateRowFromUIData( StockSlip stockSlip, StockDetail stockDetail, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			StockInputDataSet.StockDetailRow row = stockDetailDataTable.NewStockDetailRow();

			this.SetRowFromUIData(ref row, stockSlip, stockDetail);
			return row;
		}

		/// <summary>
		/// 指定した仕入明細データを元に計上元仕入明細データテーブル行オブジェクトを生成します。
		/// </summary>
		/// <param name="stockDetail">仕入明細データオブジェクト</param>
		/// <param name="addUpSrcDetailDataTable">計上元仕入明細データテーブルオブジェクト</param>
		/// <returns>仕入明細データ行オブジェクト</returns>
		private StockInputDataSet.AddUpSrcDetailRow CreateRowFromUIData( StockDetail stockDetail, StockInputDataSet.AddUpSrcDetailDataTable addUpSrcDetailDataTable )
		{
			StockInputDataSet.AddUpSrcDetailRow row = addUpSrcDetailDataTable.NewAddUpSrcDetailRow();

			this.SetRowFromUIData(ref row, stockDetail);
			return row;
		}

		/// <summary>
		/// 仕入明細データオブジェクトを計上元仕入明細データテーブルにキャッシュします。
		/// </summary>
		/// <param name="stockDetail">仕入明細データオブジェクト</param>
		/// <param name="addUpSrcDetailDataTable">計上元仕入明細データテーブルオブジェクト</param>
		private void CacheAddUpSrcStockDetailDataTable( StockDetail stockDetail, StockInputDataSet.AddUpSrcDetailDataTable addUpSrcDetailDataTable )
		{
			try
			{
				addUpSrcDetailDataTable.AddAddUpSrcDetailRow(this.CreateRowFromUIData(stockDetail, addUpSrcDetailDataTable));
			}
			catch (ConstraintException)
			{
				StockInputDataSet.AddUpSrcDetailRow row = addUpSrcDetailDataTable.FindBySupplierFormalStockSlipDtlNum(stockDetail.SupplierFormal, stockDetail.StockSlipDtlNum);
				this.SetRowFromUIData(ref row, stockDetail);
			}
		}

		/// <summary>
		/// 仕入明細データオブジェクトからリンク用仕入明細データ行オブジェクトに項目を設定します。
		/// </summary>
		/// <param name="row">仕入明細データ行オブジェクト</param>
		/// <param name="stockDetail">仕入明細データオブジェクト</param>
		private void SetRowFromUIData( ref StockInputDataSet.AddUpSrcDetailRow row, StockDetail stockDetail)
		{
			#region ●項目セット

            //row.CreateDateTime = stockDetail.CreateDateTime;                    // 作成日時
            //row.UpdateDateTime = stockDetail.UpdateDateTime;                    // 更新日時
            //row.EnterpriseCode = stockDetail.EnterpriseCode;                    // 企業コード
            //row.FileHeaderGuid = stockDetail.FileHeaderGuid;                    // GUID
            //row.UpdEmployeeCode = stockDetail.UpdEmployeeCode;                  // 更新従業員コード
            //row.UpdAssemblyId1 = stockDetail.UpdAssemblyId1;                    // 更新アセンブリID1
            //row.UpdAssemblyId2 = stockDetail.UpdAssemblyId2;                    // 更新アセンブリID2
            //row.LogicalDeleteCode = stockDetail.LogicalDeleteCode;              // 論理削除区分
            row.AcceptAnOrderNo = stockDetail.AcceptAnOrderNo;                  // 受注番号
            row.SupplierFormal = stockDetail.SupplierFormal;                    // 仕入形式
            row.SupplierSlipNo = stockDetail.SupplierSlipNo;                    // 仕入伝票番号
            row.StockRowNo = stockDetail.StockRowNo;                            // 仕入行番号
            row.SectionCode = stockDetail.SectionCode;                          // 拠点コード
            row.SubSectionCode = stockDetail.SubSectionCode;                    // 部門コード
            row.CommonSeqNo = stockDetail.CommonSeqNo;                          // 共通通番
            row.StockSlipDtlNum = stockDetail.StockSlipDtlNum;                  // 仕入明細通番
            row.SupplierFormalSrc = stockDetail.SupplierFormalSrc;              // 仕入形式（元）
            row.StockSlipDtlNumSrc = stockDetail.StockSlipDtlNumSrc;            // 仕入明細通番（元）
            row.AcptAnOdrStatusSync = stockDetail.AcptAnOdrStatusSync;          // 受注ステータス（同時）
            row.SalesSlipDtlNumSync = stockDetail.SalesSlipDtlNumSync;          // 売上明細通番（同時）
            row.StockSlipCdDtl = stockDetail.StockSlipCdDtl;                    // 仕入伝票区分（明細）
            //row.StockInputCode = stockDetail.StockInputCode;                    // 仕入入力者コード
            //row.StockInputName = stockDetail.StockInputName;                    // 仕入入力者名称
            //row.StockAgentCode = stockDetail.StockAgentCode;                    // 仕入担当者コード
            //row.StockAgentName = stockDetail.StockAgentName;                    // 仕入担当者名称
            row.GoodsKindCode = stockDetail.GoodsKindCode;                      // 商品属性
            row.GoodsMakerCd = stockDetail.GoodsMakerCd;                        // 商品メーカーコード
            row.MakerName = stockDetail.MakerName;                              // メーカー名称
            row.MakerKanaName = stockDetail.MakerKanaName;                      // メーカーカナ名称
            row.CmpltMakerKanaName = stockDetail.CmpltMakerKanaName;            // メーカーカナ名称（一式）
            row.GoodsNo = stockDetail.GoodsNo;                                  // 商品番号
            row.GoodsName = stockDetail.GoodsName;                              // 商品名称
            row.GoodsNameKana = stockDetail.GoodsNameKana;                      // 商品名称カナ
            row.GoodsLGroup = stockDetail.GoodsLGroup;                          // 商品大分類コード
            row.GoodsLGroupName = stockDetail.GoodsLGroupName;                  // 商品大分類名称
            row.GoodsMGroup = stockDetail.GoodsMGroup;                          // 商品中分類コード
            row.GoodsMGroupName = stockDetail.GoodsMGroupName;                  // 商品中分類名称
            row.BLGroupCode = stockDetail.BLGroupCode;                          // BLグループコード
            row.BLGroupName = stockDetail.BLGroupName;                          // BLグループコード名称
            row.BLGoodsCode = stockDetail.BLGoodsCode;                          // BL商品コード
            row.BLGoodsFullName = stockDetail.BLGoodsFullName;                  // BL商品コード名称（全角）
            row.EnterpriseGanreCode = stockDetail.EnterpriseGanreCode;          // 自社分類コード
            row.EnterpriseGanreName = stockDetail.EnterpriseGanreName;          // 自社分類名称
            row.WarehouseCode = stockDetail.WarehouseCode;                      // 倉庫コード
            row.WarehouseName = stockDetail.WarehouseName;                      // 倉庫名称
            row.WarehouseShelfNo = stockDetail.WarehouseShelfNo;                // 倉庫棚番
            row.StockOrderDivCd = stockDetail.StockOrderDivCd;                  // 仕入在庫取寄せ区分
            row.OpenPriceDiv = stockDetail.OpenPriceDiv;                        // オープン価格区分
            row.GoodsRateRank = stockDetail.GoodsRateRank;                      // 商品掛率ランク
            row.CustRateGrpCode = stockDetail.CustRateGrpCode;                  // 得意先掛率グループコード
            row.SuppRateGrpCode = stockDetail.SuppRateGrpCode;                  // 仕入先掛率グループコード
            row.ListPriceTaxExcFl = stockDetail.ListPriceTaxExcFl;              // 定価（税抜，浮動）
            row.ListPriceTaxIncFl = stockDetail.ListPriceTaxIncFl;              // 定価（税込，浮動）
            row.StockRate = stockDetail.StockRate;                              // 仕入率
            row.RateSectStckUnPrc = stockDetail.RateSectStckUnPrc;              // 掛率設定拠点（仕入単価）
            row.RateDivStckUnPrc = stockDetail.RateDivStckUnPrc;                // 掛率設定区分（仕入単価）
            row.UnPrcCalcCdStckUnPrc = stockDetail.UnPrcCalcCdStckUnPrc;        // 単価算出区分（仕入単価）
            row.PriceCdStckUnPrc = stockDetail.PriceCdStckUnPrc;                // 価格区分（仕入単価）
            row.StdUnPrcStckUnPrc = stockDetail.StdUnPrcStckUnPrc;              // 基準単価（仕入単価）
            row.FracProcUnitStcUnPrc = stockDetail.FracProcUnitStcUnPrc;        // 端数処理単位（仕入単価）
            row.FracProcStckUnPrc = stockDetail.FracProcStckUnPrc;              // 端数処理（仕入単価）
            row.StockUnitPriceFl = stockDetail.StockUnitPriceFl;                // 仕入単価（税抜，浮動）
            row.StockUnitTaxPriceFl = stockDetail.StockUnitTaxPriceFl;          // 仕入単価（税込，浮動）
            row.StockUnitChngDiv = stockDetail.StockUnitChngDiv;                // 仕入単価変更区分
            row.BfStockUnitPriceFl = stockDetail.BfStockUnitPriceFl;            // 変更前仕入単価（浮動）
            row.BfListPrice = stockDetail.BfListPrice;                          // 変更前定価
            row.RateBLGoodsCode = stockDetail.RateBLGoodsCode;                  // BL商品コード（掛率）
            row.RateBLGoodsName = stockDetail.RateBLGoodsName;                  // BL商品コード名称（掛率）
            row.RateGoodsRateGrpCd = stockDetail.RateGoodsRateGrpCd;            // 商品掛率グループコード（掛率）
            row.RateGoodsRateGrpNm = stockDetail.RateGoodsRateGrpNm;            // 商品掛率グループ名称（掛率）
            row.RateBLGroupCode = stockDetail.RateBLGroupCode;                  // BLグループコード（掛率）
            row.RateBLGroupName = stockDetail.RateBLGroupName;                  // BLグループ名称（掛率）
            row.StockCount = stockDetail.StockCount;                            // 仕入数
            row.OrderCnt = stockDetail.OrderCnt;                                // 発注数量
            row.OrderAdjustCnt = stockDetail.OrderAdjustCnt;                    // 発注調整数
            row.OrderRemainCnt = stockDetail.OrderRemainCnt;                    // 発注残数
            row.RemainCntUpdDate = stockDetail.RemainCntUpdDate;                // 残数更新日
            row.StockPriceTaxExc = stockDetail.StockPriceTaxExc;                // 仕入金額（税抜き）
            row.StockPriceTaxInc = stockDetail.StockPriceTaxInc;                // 仕入金額（税込み）
            row.StockGoodsCd = stockDetail.StockGoodsCd;                        // 仕入商品区分
            row.StockPriceConsTax = stockDetail.StockPriceConsTax;              // 仕入金額消費税額
            row.TaxationCode = stockDetail.TaxationCode;                        // 課税区分
            row.StockDtiSlipNote1 = stockDetail.StockDtiSlipNote1;              // 仕入伝票明細備考1
            row.SalesCustomerCode = stockDetail.SalesCustomerCode;              // 販売先コード
            row.SalesCustomerSnm = stockDetail.SalesCustomerSnm;                // 販売先略称
            row.SlipMemo1 = stockDetail.SlipMemo1;                              // 伝票メモ１
            row.SlipMemo2 = stockDetail.SlipMemo2;                              // 伝票メモ２
            row.SlipMemo3 = stockDetail.SlipMemo3;                              // 伝票メモ３
            row.InsideMemo1 = stockDetail.InsideMemo1;                          // 社内メモ１
            row.InsideMemo2 = stockDetail.InsideMemo2;                          // 社内メモ２
            row.InsideMemo3 = stockDetail.InsideMemo3;                          // 社内メモ３
            row.SupplierCd = stockDetail.SupplierCd;                            // 仕入先コード
            row.SupplierSnm = stockDetail.SupplierSnm;                          // 仕入先略称
            row.AddresseeCode = stockDetail.AddresseeCode;                      // 納品先コード
            row.AddresseeName = stockDetail.AddresseeName;                      // 納品先名称
            row.DirectSendingCd = stockDetail.DirectSendingCd;                  // 直送区分
            row.OrderNumber = stockDetail.OrderNumber;                          // 発注番号
            row.WayToOrder = stockDetail.WayToOrder;                            // 注文方法
            row.DeliGdsCmpltDueDate = stockDetail.DeliGdsCmpltDueDate;          // 納品完了予定日
            row.ExpectDeliveryDate = stockDetail.ExpectDeliveryDate;            // 希望納期
            row.OrderDataCreateDiv = stockDetail.OrderDataCreateDiv;            // 発注データ作成区分
            row.OrderDataCreateDate = stockDetail.OrderDataCreateDate;          // 発注データ作成日
            row.OrderFormIssuedDiv = stockDetail.OrderFormIssuedDiv;            // 発注書発行済区分

			#endregion
		}

		/// <summary>
		/// 仕入明細行オブジェクトのクリアを行います。（オーバーロード）
		/// </summary>
		/// <param name="row">仕入明細行オブジェクト</param>
		private void ClearStockDetailRow(StockInputDataSet.StockDetailRow row)
		{
			if (row == null) return;

			#region ●項目クリア

            row.AcceptAnOrderNo = 0;                        // 受注番号
            row.SupplierFormal = 0;                         // 仕入形式
            //row.SupplierSlipNo = 0;                         // 仕入伝票番号
            //row.StockRowNo = 0;                             // 仕入行番号
            row.SectionCode = string.Empty;                 // 拠点コード
            row.SubSectionCode = 0;                         // 部門コード
            row.CommonSeqNo = 0;                            // 共通通番
            row.StockSlipDtlNum = 0;                        // 仕入明細通番
            row.SupplierFormalSrc = 0;                      // 仕入形式（元）
            row.StockSlipDtlNumSrc = 0;                     // 仕入明細通番（元）
            row.AcptAnOdrStatusSync = 0;                    // 受注ステータス（同時）
            row.SalesSlipDtlNumSync = 0;                    // 売上明細通番（同時）
            row.StockSlipCdDtl = 0;                         // 仕入伝票区分（明細）
            row.StockInputCode = string.Empty;              // 仕入入力者コード
            row.StockInputName = string.Empty;              // 仕入入力者名称
            row.StockAgentCode = string.Empty;              // 仕入担当者コード
            row.StockAgentName = string.Empty;              // 仕入担当者名称
            row.GoodsKindCode = 0;                          // 商品属性
            row.GoodsMakerCd = 0;                           // 商品メーカーコード
            row.MakerName = string.Empty;                   // メーカー名称
            row.MakerKanaName = string.Empty;               // メーカーカナ名称
            row.CmpltMakerKanaName = string.Empty;          // メーカーカナ名称（一式）
            row.GoodsNo = string.Empty;                     // 商品番号
            row.GoodsName = string.Empty;                   // 商品名称
            row.GoodsNameKana = string.Empty;               // 商品名称カナ
            row.GoodsLGroup = 0;                            // 商品大分類コード
            row.GoodsLGroupName = string.Empty;             // 商品大分類名称
            row.GoodsMGroup = 0;                            // 商品中分類コード
            row.GoodsMGroupName = string.Empty;             // 商品中分類名称
            row.BLGroupCode = 0;                            // BLグループコード
            row.BLGroupName = string.Empty;                 // BLグループコード名称
            row.BLGoodsCode = 0;                            // BL商品コード
            row.BLGoodsFullName = string.Empty;             // BL商品コード名称（全角）
            row.EnterpriseGanreCode = 0;                    // 自社分類コード
            row.EnterpriseGanreName = string.Empty;         // 自社分類名称
            row.WarehouseCode = string.Empty;               // 倉庫コード
            row.WarehouseName = string.Empty;               // 倉庫名称
            row.WarehouseShelfNo = string.Empty;            // 倉庫棚番
            row.StockOrderDivCd = 0;                        // 仕入在庫取寄せ区分
            row.OpenPriceDiv = 0;                           // オープン価格区分
            row.GoodsRateRank = string.Empty;               // 商品掛率ランク
            row.CustRateGrpCode = 0;                        // 得意先掛率グループコード
            row.SuppRateGrpCode = 0;                        // 仕入先掛率グループコード
            row.ListPriceTaxExcFl = 0;                      // 定価（税抜，浮動）
            row.ListPriceTaxIncFl = 0;                      // 定価（税込，浮動）
            row.StockRate = 0;                              // 仕入率
            row.RateSectStckUnPrc = string.Empty;           // 掛率設定拠点（仕入単価）
            row.RateDivStckUnPrc = string.Empty;            // 掛率設定区分（仕入単価）
            row.UnPrcCalcCdStckUnPrc = 0;                   // 単価算出区分（仕入単価）
            row.PriceCdStckUnPrc = 0;                       // 価格区分（仕入単価）
            row.StdUnPrcStckUnPrc = 0;                      // 基準単価（仕入単価）
            row.FracProcUnitStcUnPrc = 0;                   // 端数処理単位（仕入単価）
            row.FracProcStckUnPrc = 0;                      // 端数処理（仕入単価）
            row.StockUnitPriceFl = 0;                       // 仕入単価（税抜，浮動）
            row.StockUnitTaxPriceFl = 0;                    // 仕入単価（税込，浮動）
            row.StockUnitChngDiv = 0;                       // 仕入単価変更区分
            row.BfStockUnitPriceFl = 0;                     // 変更前仕入単価（浮動）
            row.BfListPrice = 0;                            // 変更前定価
            row.RateBLGoodsCode = 0;                        // BL商品コード（掛率）
            row.RateBLGoodsName = string.Empty;             // BL商品コード名称（掛率）
            row.RateGoodsRateGrpCd = 0;                     // 商品掛率グループコード（掛率）
            row.RateGoodsRateGrpNm = string.Empty;          // 商品掛率グループ名称（掛率）
            row.RateBLGroupCode = 0;                        // BLグループコード（掛率）
            row.RateBLGroupName = string.Empty;             // BLグループ名称（掛率）
            row.StockCount = 0;                             // 仕入数
            row.OrderCnt = 0;                               // 発注数量
            row.OrderAdjustCnt = 0;                         // 発注調整数
            row.OrderRemainCnt = 0;                         // 発注残数
            row.RemainCntUpdDate = DateTime.MinValue;       // 残数更新日
            row.StockPriceTaxExc = 0;                       // 仕入金額（税抜き）
            row.StockPriceTaxInc = 0;                       // 仕入金額（税込み）
            row.StockGoodsCd = 0;                           // 仕入商品区分
            row.StockPriceConsTax = 0;                      // 仕入金額消費税額
            row.TaxationCode = 0;                           // 課税区分
            row.StockDtiSlipNote1 = string.Empty;           // 仕入伝票明細備考1
            row.SalesCustomerCode = 0;                      // 販売先コード
            row.SalesCustomerSnm = string.Empty;            // 販売先略称
            row.SlipMemo1 = string.Empty;                   // 伝票メモ１
            row.SlipMemo2 = string.Empty;                   // 伝票メモ２
            row.SlipMemo3 = string.Empty;                   // 伝票メモ３
            row.InsideMemo1 = string.Empty;                 // 社内メモ１
            row.InsideMemo2 = string.Empty;                 // 社内メモ２
            row.InsideMemo3 = string.Empty;                 // 社内メモ３
            row.SupplierCd = 0;                             // 仕入先コード
            row.SupplierSnm = string.Empty;                 // 仕入先略称
            row.AddresseeCode = 0;                          // 納品先コード
            row.AddresseeName = string.Empty;               // 納品先名称
            row.DirectSendingCd = 0;                        // 直送区分
            row.OrderNumber = string.Empty;                 // 発注番号
            row.WayToOrder = 0;                             // 注文方法
            row.DeliGdsCmpltDueDate = DateTime.MinValue;    // 納品完了予定日
            row.ExpectDeliveryDate = DateTime.MinValue;     // 希望納期
            row.OrderDataCreateDiv = 0;                     // 発注データ作成区分
            row.OrderDataCreateDate = DateTime.MinValue;    // 発注データ作成日
            row.OrderFormIssuedDiv = 0;                     // 発注書発行済区分
            row.DtlRelationGuid = Guid.Empty;               // 明細関連付けGUID
            row.GoodsOfferDate = DateTime.MinValue;         // 商品提供日付
            row.PriceStartDate = DateTime.MinValue;         // 価格開始日付
            row.PriceOfferDate = DateTime.MinValue;         // 価格提供日付

			row.ShipmentPosCnt = 0;
			row.ShipmentPosCntDisplay = 0;
			row.StockPriceDisplay = 0;
			row.ListPriceDisplay = 0;
			row.StockUnitPriceDisplay = 0;
			row.StockCountDisplay = 0;
			row.StockCountDefault = 0;
			row.StockCountMax = 0;
			row.StockCountMin = 0;
			row.TaxDiv = 0;
			row.CanTaxDivChange = true;
            row.StockPriceDiectInput = false;
            row.StockUnitPriceDefault = 0;
            row.StockUnitTaxPriceDefault = 0;
            row.StockPriceTaxExcDefault = 0;
            row.StockPriceTaxIncDefault = 0;

            row.EditStatus = ctEDITSTATUS_AllOK;
            row.RowStatus = ctROWSTATUS_NORMAL;

			#endregion
		}

		/// <summary>
		/// 仕入明細行オブジェクトを複製します。
		/// </summary>
		/// <param name="sourceRow">仕入明細行オブジェクト</param>
		/// <returns>複製後仕入明細行オブジェクト</returns>
		private StockInputDataSet.StockDetailRow CloneStockDetailRow(StockInputDataSet.StockDetailRow sourceRow)
		{
			StockInputDataSet.StockDetailRow targetRow = this._stockDetailDataTable.NewStockDetailRow();

			#region ●項目セット
			
			targetRow.SupplierFormal = sourceRow.SupplierFormal;				// 仕入形式
			targetRow.SupplierSlipNo = sourceRow.SupplierSlipNo;				// 仕入伝票番号
			targetRow.StockRowNo = sourceRow.StockRowNo;						// 仕入行番号
			targetRow.SectionCode = sourceRow.SectionCode;						// 拠点コード
			targetRow.SubSectionCode = sourceRow.SubSectionCode;				// 部門コード
			targetRow.CommonSeqNo = sourceRow.CommonSeqNo;						// 共通通番
			targetRow.StockSlipDtlNum = sourceRow.StockSlipDtlNum;				// 仕入明細通番
			targetRow.SupplierFormalSrc = sourceRow.SupplierFormalSrc;			// 仕入形式（元）
			targetRow.StockSlipDtlNumSrc = sourceRow.StockSlipDtlNumSrc;		// 仕入明細通番（元）
			targetRow.AcptAnOdrStatusSync = sourceRow.AcptAnOdrStatusSync;		// 受注ステータス（同時）
			targetRow.SalesSlipDtlNumSync = sourceRow.SalesSlipDtlNumSync;		// 売上明細通番（同時）
			targetRow.StockSlipCdDtl = sourceRow.StockSlipCdDtl;				// 仕入伝票区分（明細）
			targetRow.StockInputCode = sourceRow.StockInputCode;				// 仕入入力者コード
			targetRow.StockInputName = sourceRow.StockInputName;				// 仕入入力者名称
			targetRow.StockAgentCode = sourceRow.StockAgentCode;				// 仕入担当者コード
			targetRow.StockAgentName = sourceRow.StockAgentName;				// 仕入担当者名称
			targetRow.GoodsKindCode = sourceRow.GoodsKindCode;					// 商品属性
			targetRow.GoodsMakerCd = sourceRow.GoodsMakerCd;					// 商品メーカーコード
			targetRow.MakerName = sourceRow.MakerName;							// メーカー名称
			targetRow.MakerKanaName = sourceRow.MakerKanaName;					// メーカーカナ名称
			targetRow.CmpltMakerKanaName = sourceRow.CmpltMakerKanaName;		// メーカーカナ名称（一式）
			targetRow.GoodsNo = sourceRow.GoodsNo;								// 商品番号
			targetRow.GoodsName = sourceRow.GoodsName;							// 商品名称
			targetRow.GoodsNameKana = sourceRow.GoodsNameKana;					// 商品名称カナ
			targetRow.GoodsLGroup = sourceRow.GoodsLGroup;						// 商品大分類コード
			targetRow.GoodsLGroupName = sourceRow.GoodsLGroupName;				// 商品大分類名称
			targetRow.GoodsMGroup = sourceRow.GoodsMGroup;						// 商品中分類コード
			targetRow.GoodsMGroupName = sourceRow.GoodsMGroupName;				// 商品中分類名称
			targetRow.BLGroupCode = sourceRow.BLGroupCode;						// BLグループコード
			targetRow.BLGroupName = sourceRow.BLGroupName;						// BLグループコード名称
			targetRow.BLGoodsCode = sourceRow.BLGoodsCode;						// BL商品コード
			targetRow.BLGoodsFullName = sourceRow.BLGoodsFullName;				// BL商品コード名称（全角）
			targetRow.EnterpriseGanreCode = sourceRow.EnterpriseGanreCode;		// 自社分類コード
			targetRow.EnterpriseGanreName = sourceRow.EnterpriseGanreName;		// 自社分類名称
			targetRow.WarehouseCode = sourceRow.WarehouseCode;					// 倉庫コード
			targetRow.WarehouseName = sourceRow.WarehouseName;					// 倉庫名称
			targetRow.WarehouseShelfNo = sourceRow.WarehouseShelfNo;			// 倉庫棚番
			targetRow.StockOrderDivCd = sourceRow.StockOrderDivCd;				// 仕入在庫取寄せ区分
			targetRow.OpenPriceDiv = sourceRow.OpenPriceDiv;					// オープン価格区分
			targetRow.GoodsRateRank = sourceRow.GoodsRateRank;					// 商品掛率ランク
			targetRow.CustRateGrpCode = sourceRow.CustRateGrpCode;				// 得意先掛率グループコード
			targetRow.SuppRateGrpCode = sourceRow.SuppRateGrpCode;				// 仕入先掛率グループコード
			targetRow.ListPriceTaxExcFl = sourceRow.ListPriceTaxExcFl;			// 定価（税抜，浮動）
			targetRow.ListPriceTaxIncFl = sourceRow.ListPriceTaxIncFl;			// 定価（税込，浮動）
			targetRow.StockRate = sourceRow.StockRate;							// 仕入率
			targetRow.RateSectStckUnPrc = sourceRow.RateSectStckUnPrc;			// 掛率設定拠点（仕入単価）
			targetRow.RateDivStckUnPrc = sourceRow.RateDivStckUnPrc;			// 掛率設定区分（仕入単価）
			targetRow.UnPrcCalcCdStckUnPrc = sourceRow.UnPrcCalcCdStckUnPrc;	// 単価算出区分（仕入単価）
			targetRow.PriceCdStckUnPrc = sourceRow.PriceCdStckUnPrc;			// 価格区分（仕入単価）
			targetRow.StdUnPrcStckUnPrc = sourceRow.StdUnPrcStckUnPrc;			// 基準単価（仕入単価）
			targetRow.FracProcUnitStcUnPrc = sourceRow.FracProcUnitStcUnPrc;	// 端数処理単位（仕入単価）
			targetRow.FracProcStckUnPrc = sourceRow.FracProcStckUnPrc;			// 端数処理（仕入単価）
			targetRow.StockUnitPriceFl = sourceRow.StockUnitPriceFl;			// 仕入単価（税抜，浮動）
			targetRow.StockUnitTaxPriceFl = sourceRow.StockUnitTaxPriceFl;		// 仕入単価（税込，浮動）
			targetRow.StockUnitChngDiv = sourceRow.StockUnitChngDiv;			// 仕入単価変更区分
			targetRow.BfStockUnitPriceFl = sourceRow.BfStockUnitPriceFl;		// 変更前仕入単価（浮動）
			targetRow.BfListPrice = sourceRow.BfListPrice;						// 変更前定価
			targetRow.RateBLGoodsCode = sourceRow.RateBLGoodsCode;				// BL商品コード（掛率）
			targetRow.RateBLGoodsName = sourceRow.RateBLGoodsName;				// BL商品コード名称（掛率）
            targetRow.RateGoodsRateGrpCd = sourceRow.RateGoodsRateGrpCd;        // 商品掛率グループコード（掛率）
            targetRow.RateGoodsRateGrpNm = sourceRow.RateGoodsRateGrpNm;        // 商品掛率グループ名称（掛率）
            targetRow.RateBLGroupCode = sourceRow.RateBLGroupCode;              // BLグループコード（掛率）
            targetRow.RateBLGroupName = sourceRow.RateBLGroupName;              // BLグループ名称（掛率）
			targetRow.StockCount = sourceRow.StockCount;						// 仕入数
			targetRow.OrderCnt = sourceRow.OrderCnt;							// 発注数量
			targetRow.OrderAdjustCnt = sourceRow.OrderAdjustCnt;				// 発注調整数
			targetRow.OrderRemainCnt = sourceRow.OrderRemainCnt;				// 発注残数
			targetRow.RemainCntUpdDate = sourceRow.RemainCntUpdDate;			// 残数更新日
			targetRow.StockPriceTaxExc = sourceRow.StockPriceTaxExc;			// 仕入金額（税抜き）
			targetRow.StockPriceTaxInc = sourceRow.StockPriceTaxInc;			// 仕入金額（税込み）
			targetRow.StockGoodsCd = sourceRow.StockGoodsCd;					// 仕入商品区分
			targetRow.StockPriceConsTax = sourceRow.StockPriceConsTax;			// 仕入金額消費税額
			targetRow.TaxationCode = sourceRow.TaxationCode;					// 課税区分
			targetRow.StockDtiSlipNote1 = sourceRow.StockDtiSlipNote1;			// 仕入伝票明細備考1
			targetRow.SalesCustomerCode = sourceRow.SalesCustomerCode;			// 販売先コード
			targetRow.SalesCustomerSnm = sourceRow.SalesCustomerSnm;			// 販売先略称
			targetRow.SlipMemo1 = sourceRow.SlipMemo1;							// 伝票メモ１
			targetRow.SlipMemo2 = sourceRow.SlipMemo2;							// 伝票メモ２
			targetRow.SlipMemo3 = sourceRow.SlipMemo3;							// 伝票メモ３
			targetRow.InsideMemo1 = sourceRow.InsideMemo1;						// 社内メモ１
			targetRow.InsideMemo2 = sourceRow.InsideMemo2;						// 社内メモ２
			targetRow.InsideMemo3 = sourceRow.InsideMemo3;						// 社内メモ３
			targetRow.SupplierCd = sourceRow.SupplierCd;						// 仕入先コード
			targetRow.SupplierSnm = sourceRow.SupplierSnm;						// 仕入先略称
			targetRow.AddresseeCode = sourceRow.AddresseeCode;					// 納品先コード
			targetRow.AddresseeName = sourceRow.AddresseeName;					// 納品先名称
			targetRow.DirectSendingCd = sourceRow.DirectSendingCd;				// 直送区分
			targetRow.OrderNumber = sourceRow.OrderNumber;						// 発注番号
			targetRow.WayToOrder = sourceRow.WayToOrder;						// 注文方法
			targetRow.DeliGdsCmpltDueDate = sourceRow.DeliGdsCmpltDueDate;		// 納品完了予定日
			targetRow.ExpectDeliveryDate = sourceRow.ExpectDeliveryDate;		// 希望納期
			targetRow.OrderDataCreateDiv = sourceRow.OrderDataCreateDiv;		// 発注データ作成区分
			targetRow.OrderDataCreateDate = sourceRow.OrderDataCreateDate;		// 発注データ作成日
			targetRow.OrderFormIssuedDiv = sourceRow.OrderFormIssuedDiv;		// 発注書発行済区分
			targetRow.DtlRelationGuid = sourceRow.DtlRelationGuid;				// 明細関連付けGUID
			targetRow.GoodsOfferDate = sourceRow.GoodsOfferDate;				// 商品提供日付
			targetRow.PriceStartDate = sourceRow.PriceStartDate;				// 価格開始日付
			targetRow.PriceOfferDate = sourceRow.PriceOfferDate;				// 価格提供日付

			targetRow.ShipmentPosCnt = sourceRow.ShipmentPosCnt;
			targetRow.ShipmentPosCntDisplay = sourceRow.ShipmentPosCntDisplay;
			targetRow.ListPriceDisplay = sourceRow.ListPriceDisplay;
			targetRow.StockUnitPriceDisplay = sourceRow.StockUnitPriceDisplay;
			targetRow.StockCountDefault = sourceRow.StockCountDefault;
			targetRow.StockCountDisplay = sourceRow.StockCountDisplay;
			targetRow.StockCountMax = sourceRow.StockCountMax;
			targetRow.StockCountMin = sourceRow.StockCountMin;
			targetRow.StockPriceDisplay = sourceRow.StockPriceDisplay;
			targetRow.TaxDiv = sourceRow.TaxDiv;
			targetRow.CanTaxDivChange = sourceRow.CanTaxDivChange;
            targetRow.StockPriceDiectInput = sourceRow.StockPriceDiectInput;


            targetRow.EditStatus = sourceRow.EditStatus;
            targetRow.RowStatus = ctROWSTATUS_NORMAL;

			#endregion

			return targetRow;
		}

        #region 支払データ制御関連
        /// <summary>
        /// 支払データ、支払明細データから、支払データ(登録用)を生成します。
        /// </summary>
        /// <param name="paymentSlp">支払データ</param>
        /// <param name="paymentDtlList">支払明細データ</param>
        /// <returns>支払データ(登録用)</returns>
        private PaymentDataWork CreatePaymentDataWork( PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList)
        {
            PaymentDataWork paymentDataWork = new PaymentDataWork();

            PaymentSlpWork paymentSlpWork = (PaymentSlpWork)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlp, typeof(PaymentSlpWork));

            List<PaymentDtlWork> paymentDtlWorkList = new List<PaymentDtlWork>();
            foreach (PaymentDtl paymentDtl in paymentDtlList)
            {
                paymentDtlWorkList.Add((PaymentDtlWork)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentDtl, typeof(PaymentDtlWork)));
            }
            PaymentDtlWork[] paymentDtlWorkArray = paymentDtlWorkList.ToArray();
            PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);

            return paymentDataWork;
        }

        /// <summary>
        /// 支払データ(登録用)を分割し、支払データ、支払明細データを生成します。
        /// </summary>
        /// <param name="paymentDataWork">支払データ</param>
        /// <param name="paymentSlp">支払データ</param>
        /// <param name="paymentDtlList">支払明細リスト</param>
        private void DivisionPaymentDataWork( PaymentDataWork paymentDataWork, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList )
        {
            paymentSlp = new PaymentSlp();
            paymentDtlList = new List<PaymentDtl>();

            if (paymentDataWork == null) return;

            PaymentSlpWork paymentSlpWork;
            PaymentDtlWork[] paymentDtlWorkArray;
            PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);

            paymentSlp = ( paymentSlpWork != null ) ? (PaymentSlp)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlpWork, typeof(PaymentSlp)) : new PaymentSlp();

            if (( paymentDtlWorkArray != null ) && ( paymentDtlWorkArray.Length > 0 ))
            {
                foreach (PaymentDtlWork paymentDtlWork in paymentDtlWorkArray)
                {
                    paymentDtlList.Add((PaymentDtl)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentDtlWork, typeof(PaymentDtl)));
                }
            }

        }
        #endregion

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
		/// メモ複写区分に従って、メモ情報をクリアします。
		/// </summary>
		/// <param name="row"></param>
		private void MemoInfoAdjust( ref StockInputDataSet.StockDetailRow row )
		{
			// メモ複写区分によって処理分岐
			switch (this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv)
			{
				// 全て
				case (int)MemoMoveDiv.All:
					{
						break;
					}
				// 伝票メモのみ
				case (int)MemoMoveDiv.SlipMemoOnly:
					{
						row.InsideMemo1 = string.Empty;
                        row.InsideMemo2 = string.Empty;
                        row.InsideMemo3 = string.Empty;
						break;
					}
				// しない
				case (int)MemoMoveDiv.None:
					{
                        row.InsideMemo1 = string.Empty;
                        row.InsideMemo2 = string.Empty;
                        row.InsideMemo3 = string.Empty;
                        row.SlipMemo1 = string.Empty;
                        row.SlipMemo2 = string.Empty;
                        row.SlipMemo3 = string.Empty;
						break;
					}
			}
		}
        # endregion

        #region ■商品ディクショナリの操作

        /// <summary>
        /// 商品キャッシュ情報クリア
        /// </summary>
        private void ClearGoodsCacheInfo()
        {
            this._goodsDictionary.Clear();
        }

        /// <summary>
        /// 商品情報キャッシュ処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        private void CacheGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            string goodsKey = string.Format("{0,-40}{1,6}", goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);

            if (this._goodsDictionary.ContainsKey(goodsKey))
            {
                this._goodsDictionary[goodsKey] = goodsUnitData.Clone();
            }
            else
            {
                this._goodsDictionary.Add(goodsKey, goodsUnitData.Clone());
            }
        }

        /// <summary>
        /// 商品情報キャッシュ処理
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void CacheGoodsUnitData(List<GoodsUnitData> goodsUnitDataList)
        {
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                this.CacheGoodsUnitData(goodsUnitData);
            }
        }

        /// <summary>
        /// 商品キャッシュ情報削除
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        private void DeleteGoodsCacheInfo(GoodsUnitData goodsUnitData)
        {
            string goodsKey = string.Format("{0,-40}{1,6}", goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
            if (this._goodsDictionary.ContainsKey(goodsKey))
            {
                this._goodsDictionary.Remove(goodsKey);
            }
        }

        /// <summary>
        /// 商品情報取得
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <returns></returns>
        private GoodsUnitData GetGoodsUnitDataFromCache(string goodsNo, int goodsMakerCd)
        {
            string goodsKey = string.Format("{0,-40}{1,6}", goodsNo, goodsMakerCd);
            return ( this._goodsDictionary.ContainsKey(goodsKey) ) ? this._goodsDictionary[goodsKey] : null;
        }

        #endregion

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        #region ▼ハンディターミナル在庫仕入登録の対応
        // ===================================================================================== //
        // コンストラクタ（ハンディターミナル用）
        // ===================================================================================== //
        # region ■Constracter
        /// <summary>
        /// コンストラクタ（ハンディターミナル用）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="count">仕入データ件数</param>
        /// <param name="status">初期化ステータス「0：成功  0以外：失敗」</param>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public StockSlipInputAcs(string enterpriseCode, string sectionCode, int count, out int status)
        {
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 変数初期化
                this._dataSet = new StockInputDataSet();
                this._stockDetailDataTable = this._dataSet.StockDetail;
                this._addUpSrcDetailDataTable = this._dataSet.AddUpSrcDetail;
                this._salesTempDataTable = this._dataSet.SalesTemp;
                this._addUpSrcSalesSlipDataTable = this._dataSet.AddUpSrcSalesSlip;
                this._addUpSrcSalesDetailDataTable = this._dataSet.AddUpSrcSalesDetail;
                this._stockInfoDataTable = this._dataSet.StockInfo;
                this._stockSlip = new StockSlip();
                this._stockSlipDBData = new StockSlip();
                this._stockDetailDBDataList = new List<StockDetail>();
                this._unitPriceCalculation = new UnitPriceCalculation();

                this._stockPriceCalculate = new StockPriceCalculate();
                this._stockSlipInputInitDataAcs = new StockSlipInputInitDataAcs(out status);
                // 仕入入力用初期値取得アクセスクラス初期化失敗場合
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                status = this._stockSlipInputInitDataAcs.ReadInitDataForHandy(enterpriseCode, sectionCode);
                // 仕入入力用初期値取マスタデータ取得失敗場合
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                this._stockSlipInputInitDataAcs.CacheStockProcMoneyList += new StockSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._stockPriceCalculate.CacheStockProcMoneyList);
                this._stockSlipInputInitDataAcs.CacheStockProcMoneyList += new StockSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._unitPriceCalculation.CacheStockProcMoneyList);

                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                this._paymentSlp = new PaymentSlp();
                this._paymentDtlList = new List<PaymentDtl>();
                // 仕入入力用ユーザー設定クラス初期化
                this._stockInputConstructionAcs = new StockSlipInputConstructionAcs(ConstructorsModeHandy);
                this._goodsDictionary = new Dictionary<string, GoodsUnitData>();

                this._stockDetailDataView = new DataView(this._stockDetailDataTable);

                this.StockDetailRowInitialSetting(count);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            
        }
        #endregion

        /// <summary>
        /// 仕入先伝票番号の重複チェック（ハンディターミナル用）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierSlipNo">仕入先伝票番号</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns>チェック結果ステータス「0：重複  4：重複なし  810：タイムアウト  上記以外：エラー」</returns>
        /// <remarks>
        /// <br>Note       : 仕入先伝票番号を重複チェックします。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int ReadStockSlipForHandy(string enterpriseCode, string sectionCode, string supplierSlipNo, int supplierCd)
        {
            List<StockSlip> stockSlipList = null;
            // パラメータ準備：企業コード、仕入形式(0固定)、拠点コード、仕入先伝票番号、対象日(システム日付)、仕入先コード、相手先伝番の検索モード(0固定)
            return this.ReadStockSlip(enterpriseCode, 0, sectionCode, supplierSlipNo, DateTime.Today, supplierCd, 0, out stockSlipList);
        }

        /// <summary>
        /// 発注残照会ワークオブジェクトリストを元に、仕入明細データ行オブジェクトに商品、在庫情報、同時売上情報を一括設定します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="addOrderListResultWorkList">発注残照会ワークリスト</param>
        /// <returns>設定結果ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int StockDetailRowSettingFromOrderListResultWorkListForHandy(string sectionCode, List<OrderListResultWork> addOrderListResultWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 仕入データ初期インスタンス取得処理
            this.CreateStockSlipInitialData(SupplierFormalSupplier, AccPayDivCdNone, StockGoodsCdGoods, false);

            Supplier supplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            status = this._supplierAcs.Read(out supplier, this._enterpriseCode, ((OrderListResultWork)addOrderListResultWorkList[0]).SupplierCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (supplier != null)
                {
                    // 得意先（仕入先）情報設定処理
                    this.DataSettingStockSlip(ref this._stockSlip, supplier);

                    // 仕入明細データセッティング処理（課税区分設定）
                    this.StockDetailRowTaxationCodeSetting(this._stockSlip.SuppCTaxLayCd, this._stockSlip.SuppTtlAmntDspWayCd);
                }
            }

            // 税率を取得します。
            this._stockSlip.SupplierConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(DateTime.Today);

            List<int> settingStockRowNoList = new List<int>();
            status = this.StockDetailRowSettingFromOrderListResultWorkList(1, addOrderListResultWorkList, StockSlipInputAcs.WayToDetailExpand.AddUp, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);

            return status;
        }


        #endregion

        /// <summary>
        /// UOE発注データの補正（ハンディターミナル用）
        /// </summary>
        /// <param name="inspectDataAddList">検品登録データ</param>
        /// <returns>補正ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データの更新区分、検品数を補正します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SetInspectDataForHandy(ArrayList inspectDataAddList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // 検品登録データがない場合
                if (inspectDataAddList == null || inspectDataAddList.Count == 0)
                {
                    return status;
                }

                string errMessage = string.Empty;
                object searchObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassName, out errMessage);
                // 検品登録条件オブジェクトがない場合
                if (searchObj == null)
                {
                    return status;
                }

                Type searchType = searchObj.GetType();

                // 仕入明細通番
                string partySaleSlipNum = (string)searchType.GetProperty(PartySaleSlipNum).GetValue(inspectDataAddList[0], null);
                this._stockSlip.PartySaleSlipNum = partySaleSlipNum;

                // 検品登録ワークタイプを取得します。
                for (int i = 0; i < inspectDataAddList.Count; i++)
                {
                    // 仕入明細通番
                    long stockSlipDtlNum = (long)searchType.GetProperty(StockSlipDtlNum).GetValue(inspectDataAddList[i], null);
                    // 検品数
                    double inspectCnt = (double)searchType.GetProperty(InspectCnt).GetValue(inspectDataAddList[i], null);

                    string filter = string.Format("{0}={1}",
                                this._stockDetailDataTable.StockSlipDtlNumSrcColumn, stockSlipDtlNum);

                    StockInputDataSet.StockDetailRow[] stockDetailRow =
                        (StockInputDataSet.StockDetailRow[])this._stockDetailDataTable.Select(filter);

                    if (stockDetailRow.Length > 0)
                    {
                        // _gridMainTable.DivCdに引数.更新区分をセットする。
                        stockDetailRow[0].StockCount = inspectCnt;
                        stockDetailRow[0].OrderCnt = inspectCnt;
                        stockDetailRow[0].OrderRemainCnt = inspectCnt;
                        stockDetailRow[0].StockCountDisplay = inspectCnt;
                        // _gridMainTable.InputEnterCntに引数.検品数をセットする。
                        stockDetailRow[0].ShipmentPosCntDisplay = stockDetailRow[0].ShipmentPosCnt + inspectCnt;
                        // 仕入明細金額設定処理
                        this.CalculateStockPrice(stockDetailRow[0]);
                    }
                }

                // 仕入合計金額設定処理
                this.TotalPriceSetting(ref this._stockSlip, true);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 仕入保存用データの作成処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="saveDataObj">仕入保存用データオブジェクト</param>
        /// <returns>作成結果ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : 仕入保存用データを作成します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int GetSaveDataForHandy(string employeeCode, string sectionCode, out object saveDataObj)
        {
            List<StockDetail> stockDetailList;
            List<StockDetail> addUpSrcDetailList = new List<StockDetail>();
            List<SalesTemp> salesTempList = new List<SalesTemp>();
            List<SalesTemp> savedSalesTempList = new List<SalesTemp>();
            PaymentSlp paymentSlp = null;
            List<PaymentDtl> paymentDtlList = null;

            this.GetCurrentStockDetail(out stockDetailList, out salesTempList, out savedSalesTempList);

            this.ClearGoodsCacheInfo();
            this.ReSearchGoods();

            this.GetCurrentPaymentData(this._stockSlip, out paymentSlp, out paymentDtlList);

            return this.GetSaveDataForHandyProc(sectionCode, employeeCode, this._stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, salesTempList, savedSalesTempList, out saveDataObj);
        }

        /// <summary>
        /// 仕入保存用データの作成の詳細処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="stockDetailList">仕入明細データリストオブジェクト</param>
        /// <param name="addUpSrcDetailList">計上元仕入明細データリストオブジェクト</param>
        /// <param name="paymentSlp">支払データオブジェクト</param>
        /// <param name="paymentDtlList">支払明細データオブジェクトリスト</param>
        /// <param name="salesTempList">同時売上データリスト</param>
        /// <param name="savedSalesTempList">保存済みの同時売上データオブジェクト</param>
        /// <param name="dataObj">仕入保存用データオブジェクト</param>
        /// <returns>作成結果ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : 仕入保存用データを作成します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int GetSaveDataForHandyProc(string sectionCode, string employeeCode, StockSlip stockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList, List<SalesTemp> salesTempList, List<SalesTemp> savedSalesTempList, out object dataObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            dataObj = null;

            try
            {
                //------------------------------------------------------------------------------------
                // 書き込み時のCustomSerializeArrayListの構造
                //------------------------------------------------------------------------------------
                //  CustomSerializeArrayList            書き込みパラメータリスト
                //      --IOWriteCtrlOptWork			IOWrite制御ワークオブジェクト
                //      --CustomSerializeArrayList      仕入リスト
                //          --SalesSlipWork             仕入データオブジェクト
                //          --ArrayList                 仕入明細リスト
                //              --SalesDetailWork       仕入明細データオブジェクト
                //          --DepsitMainWork            支払データオブジェクト
                //      --CustomSerializeArrayList      同時売上情報
                //          --SalesTempWork             同時入力売上データオブジェクト
                //------------------------------------------------------------------------------------
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();

                IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

                //==========<< 仕入リストのセット >>==========//
                CustomSerializeArrayList stockSlipDataList = new CustomSerializeArrayList();

                // ①仕入データの補正
                stockSlip.EnterpriseCode = this._enterpriseCode;
                stockSlip.SectionCode = sectionCode;
                stockSlip.InputDay = DateTime.Today;
                stockSlip.StockSlipUpdateCd = (stockSlip.SupplierSlipNo == 0) ? 0 : 1;    // 仕入伝票更新区分
                stockSlip.DetailRowCount = stockDetailList.Count;
                stockSlip.StockInputCode = employeeCode;
                stockSlip.StockInputName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(employeeCode);
                stockSlip.StockAgentCode = employeeCode;
                stockSlip.StockAgentName = stockSlip.StockInputName;

                if ((paymentSlp != null) && (paymentDtlList != null) && (paymentDtlList.Count > 0))
                    stockSlip.AutoPayment = 1;

                // ②仕入明細データワーククラスリスト、生成
                ArrayList stockDetailArrayList = new ArrayList();
                ArrayList slipDetailAddInfoWorkList = new ArrayList();

                foreach (StockDetail stockDetail in stockDetailList)
                {
                    stockDetail.EnterpriseCode = this._enterpriseCode;
                    stockDetail.SectionCode = stockSlip.SectionCode;
                    stockDetail.SupplierFormal = stockSlip.SupplierFormal;
                    stockDetail.SupplierSlipNo = stockSlip.SupplierSlipNo;
                    stockDetail.DtlRelationGuid = Guid.NewGuid();

                    stockDetail.StockInputCode = stockSlip.StockInputCode;
                    stockDetail.StockInputName = stockSlip.StockInputName;
                    stockDetail.StockAgentCode = stockSlip.StockAgentCode;
                    stockDetail.StockAgentName = stockSlip.StockAgentName;

                    // 仕入在庫取寄せ区分
                    stockDetail.StockOrderDivCd = (string.IsNullOrEmpty(stockDetail.WarehouseCode.Trim())) ? 0 : 1;
                    if (stockDetail.StockSlipDtlNumSrc == 0) stockDetail.SupplierFormalSrc = -1;

                    stockDetailArrayList.Add(ConvertStockSlip.ParamDataFromUIData(stockDetail));

                    // 明細追加情報
                    SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
                    slipDetailAddInfoWork.DtlRelationGuid = stockDetail.DtlRelationGuid;		// 明細関連付けGUID

                    // 品番・メーカーが入力されていて、仕入行の場合
                    if ((!string.IsNullOrEmpty(stockDetail.GoodsNo) && (stockDetail.GoodsMakerCd != 0)) && (stockDetail.StockSlipCdDtl == 0))
                    {
                        GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(stockDetail.GoodsNo, stockDetail.GoodsMakerCd);

                        // 商品自動登録：する
                        if ((this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoEntryGoodsDivCd == 1) &&
                            ((goodsUnitData == null) || (goodsUnitData.OfferKubun >= 3)))
                        {
                            if (goodsUnitData == null) goodsUnitData = new GoodsUnitData();

                            slipDetailAddInfoWork.GoodsEntryDiv = 1;                            // 商品登録区分
                            slipDetailAddInfoWork.GoodsOfferDate = goodsUnitData.OfferDate;     // 商品提供日

                            GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice((stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);
                            if (goodsPrice != null)
                            {
                                slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;    // 価格提供日
                            }
                            slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate(stockSlip); // 価格開始日
                            slipDetailAddInfoWork.PriceUpdateDiv = 1;
                        }
                        else
                        {
                            if ((goodsUnitData != null) && (goodsUnitData.OfferKubun < 3))
                            {
                                GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice((stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);

                                slipDetailAddInfoWork.PriceUpdateDiv = stockSlip.PriceCostUpdtDiv;			// 価格更新区分
                                if (goodsPrice != null)
                                {
                                    slipDetailAddInfoWork.PriceStartDate = goodsPrice.PriceStartDate;       // 価格開始日
                                    slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;			// 価格提供日
                                }
                                else
                                {
                                    slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate(stockSlip);
                                }
                            }
                        }
                    }

                    slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
                }

                stockSlipDataList.Add(ConvertStockSlip.ParamDataFromUIData(stockSlip));

                if (stockDetailArrayList.Count > 0) stockSlipDataList.Add(stockDetailArrayList);

                if (slipDetailAddInfoWorkList.Count > 0) stockSlipDataList.Add(slipDetailAddInfoWorkList);

                // ③同時支払情報ワーククラスセット
                if ((paymentSlp != null) && (paymentDtlList != null) && (paymentDtlList.Count > 0))
                {
                    stockSlipDataList.Add(this.CreatePaymentDataWork(paymentSlp, paymentDtlList));
                }

                //==========<< 同時入力売上リスト >>==========//
                CustomSerializeArrayList salesTempDataList = new CustomSerializeArrayList();

                ArrayList salesTempArrayList = new ArrayList();
                foreach (SalesTemp salesTemp in salesTempList)
                {
                    salesTemp.EnterpriseCode = this._enterpriseCode;
                    salesTemp.SectionCode = stockSlip.SectionCode;
                    salesTemp.SalesOrderDivCd = (!string.IsNullOrEmpty(salesTemp.WarehouseCode.Trim())) ? 1 : 0;
                    salesTempDataList.Add(ConvertStockSlip.ParamDataFromUIData(salesTemp));
                }


                // 書き込みパラメータのセット
                dataList.Add(iOWriteCtrlOptWork);
                dataList.Add(stockSlipDataList);
                if (salesTempDataList.Count > 0) dataList.Add(salesTempDataList);

                dataObj = (object)dataList;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// アセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname, out string errMessage)
        {
            object obj = null;
            errMessage = string.Empty;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                // インスタンスタイプがある場合、インスタンスオブジェクトを生成します。
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }
            return obj;
        }
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
        /// <summary>
        /// 仕入取込み処理
        /// </summary>
        /// <param name="stockFileName">取込ファイルパス</param>
        /// <param name="errorNum">エラー件数</param>
        /// <param name="readNum">読込件数</param>
        /// <param name="logFileName">エラーファイル</param>
        /// <param name="errMsg">チェックエラー内容</param>
        /// <param name="exErrMsg">例外エラー内容</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note        : データ更新リスト処理する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        public int SearchStockData(string stockFileName, out int errorNum, out int readNum, out string logFileName, out string errMsg, out string exErrMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // エラーファイル名
            logFileName = string.Empty;

            // エラー内容
            errMsg = string.Empty;
            // 例外メッセージ
            exErrMsg = string.Empty;
            // 取込件数
            readNum = 0;
            // チェックエラー件数
            errorNum = 0;

            try
            {
                // エラー件数
                errorNum = 0;
                // 読込件数
                readNum = 0;

                // 取込ファイルのフォルダ
                string folderName = System.IO.Path.GetDirectoryName(stockFileName);
                // エラーファイル名
                string newFileName = "取込ファイルエラーリスト" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                logFileName = Path.Combine(folderName, newFileName);
                this.ErrFileName = logFileName;
                this.FileName = stockFileName;

                // 仕入データ読込処理
                status = SearchStockDataPro(stockFileName, out errorNum, out readNum, out errMsg, out exErrMsg);
            }
            catch (Exception ex)
            {
                // エラー件数
                errorNum = 0;
                // 読込件数
                readNum = 0;
                exErrMsg = ex.Message.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 仕入取込み処理
        /// </summary>
        /// <param name="stockFileName">取込ファイルパス</param>
        /// <param name="errorNum">エラー件数</param>
        /// <param name="readNum">読込件数</param>
        /// <param name="errMsg">チェックエラー内容</param>
        /// <param name="exErrMsg">例外エラー内容</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note        : データ更新リスト処理する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private int SearchStockDataPro(string stockFileName, out int errorNum, out int readNum, out string errMsg, out string exErrMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // エラー内容
            errMsg = string.Empty;
            // 例外メッセージ
            exErrMsg = string.Empty;
            // 取込件数
            readNum = 0;
            // チェックエラー件数
            errorNum = 0;

            try
            {
                // 読込データファイルチェック
                status = GetFileData(stockFileName, out errorNum, out readNum, out errMsg, out exErrMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }
            }
            catch (Exception e)
            {
                exErrMsg = e.Message;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// データチェック処理
        /// </summary>
        /// <param name="stockFileName">取込ファイルパス</param>
        /// <param name="errorNum">エラー件数</param>
        /// <param name="readNum">読込件数</param>
        /// <param name="errMsg">チェックエラー内容</param>
        /// <param name="exErrMsg">例外エラー内容</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note        : データチェック処理する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private int GetFileData(string stockFileName, out int errorNum, out int readNum, out string errMsg, out string exErrMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // エラーデータリスト
            List<ErrTxtgetWork> errWorkList =new List<ErrTxtgetWork>();
            // 成功取込データ
            CanDoStockDataWorkList = new List<InitDataItem>();

            // エラー内容
            errMsg = string.Empty;
            // 例外メッセージ
            exErrMsg = string.Empty;
            // 取込件数
            readNum = 0;
            // チェックエラー件数
            errorNum = 0;
            bool firstLine = true;
            try
            {
                // 取込データ
                List<string[]> csvDataList = new List<string[]>();
                TextFieldParser parser = new TextFieldParser(stockFileName, Encoding.GetEncoding("Shift_JIS"));

                // ユーザー区分初期化
                UserDiv = 0;

                // 取込処理開始
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    // 区切り文字はコンマ
                    parser.SetDelimiters(",");

                    //ラインでCSVの行のデータを読む
                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1行読み込み
                        csvDataList.Add(row);

                        // １レコード目の受注番号より東邦車両 OR 他のユーザーを判定
                        if (firstLine)
                        {
                            string acceptAnOrderNo = row[0].Trim();
                            firstLine = false;

                            // 1レコード目の受注番号が空欄の場合、東邦以外
                            if (string.IsNullOrEmpty(acceptAnOrderNo))
                            {
                                // 1:東邦以外
                                UserDiv = 1;
                            }
                        }
                    }
                }

                // 汎用ファイル取り込み
                InitDataItem initDataInfo = new InitDataItem();
                status = GetXmlDataInfo(ref initDataInfo, out errMsg);
                // XMLファイル取込失敗
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL && !string.IsNullOrEmpty(errMsg))
                {
                    return status;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }

                // 取込データ件数＞99の場合
                if (csvDataList.Count >= InPutMaxLength)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    errMsg = CT_ERROR_MEASSSAGE14;
                    return status;
                }
                // 取込ファイル中の明細数が設定の上限値(ユーザー設定画面.入力行数)を超える場合
                else if (csvDataList.Count > this._stockInputConstructionAcs.DataInputCountValue)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    errMsg = CT_ERROR_MEASSSAGE15;
                    return status;
                }
                else if (csvDataList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    errMsg = CT_ERROR_MEASSSAGE16;
                    return status;
                }

                // 取込件数
                readNum = csvDataList.Count;

                // 取込ファイルチェックOK後、データ処理を行う
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // データチェック
                    // [はい]ボタン
                    if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, "MAKON01112AA", CT_ERROR_MEASSSAGE12, 0, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        status = this.CheckData(csvDataList, ref errWorkList, initDataInfo, errMsg);
                    }
                    //「いいえ」ボタン
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }

                // チェックエラー件数
                errorNum = errWorkList.Count;
                this.ErrStockCount = errorNum;

                // 取込失敗の場合
                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    this.CanDoStockDataWorkList.Clear();
                }

                // エラーファイル出力
                if (errWorkList.Count != 0)
                {
                    status = WriteErrorMsg(errWorkList, out exErrMsg);
                }
            }
            catch(Exception ex)
            {
                exErrMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 東邦DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note        : DataTableのColumnsを追加する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void CreateDataTableAnnual(ref DataTable dataTable)
        {
            dataTable = new DataTable();
            // 受注番号
            dataTable.Columns.Add(CT_Col_AcceptAnOrderNo, typeof(string));
            dataTable.Columns[CT_Col_AcceptAnOrderNo].Caption = "受注番号";
            // 部品コード
            dataTable.Columns.Add(CT_Col_GoodsCode, typeof(string));
            dataTable.Columns[CT_Col_GoodsCode].Caption = "部品コード";
            // 出荷数量①
            dataTable.Columns.Add(CT_Col_ShipmentCnt1, typeof(string));
            dataTable.Columns[CT_Col_ShipmentCnt1].Caption = "出荷数量";
            // 受注単価
            dataTable.Columns.Add(CT_Col_AcceptAnOrderUnCst, typeof(string));
            dataTable.Columns[CT_Col_AcceptAnOrderUnCst].Caption = "受注単価";
            // 環境(システム)日付
            dataTable.Columns.Add(CT_Col_SysDate, typeof(string));
            dataTable.Columns[CT_Col_SysDate].Caption = "環境(システム)日付";
            // エラー内容
            dataTable.Columns.Add(CT_Col_ErrContent, typeof(string));
            dataTable.Columns[CT_Col_ErrContent].Caption = "エラー内容";
        }

        /// <summary>
        /// 東邦以外のDataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note        : DataTableのColumnsを追加する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable = new DataTable();
            // 出荷数量①
            dataTable.Columns.Add(CT_Col_ShipmentCnt1, typeof(string));
            dataTable.Columns[CT_Col_ShipmentCnt1].Caption = "出荷数量";
            // 受注単価
            dataTable.Columns.Add(CT_Col_AcceptAnOrderUnCst, typeof(string));
            dataTable.Columns[CT_Col_AcceptAnOrderUnCst].Caption = "受注単価";
            // 仕入先
            dataTable.Columns.Add(CT_Col_SupplierCd, typeof(string));
            dataTable.Columns[CT_Col_SupplierCd].Caption = "仕入先";
            // 仕入伝票番号
            dataTable.Columns.Add(CT_Col_SupplierSlipNo, typeof(string));
            dataTable.Columns[CT_Col_SupplierSlipNo].Caption = "伝票番号";
            // 品番
            dataTable.Columns.Add(CT_Col_GoodsNo, typeof(string));
            dataTable.Columns[CT_Col_GoodsNo].Caption = "品番";
            // エラー内容
            dataTable.Columns.Add(CT_Col_ErrContent, typeof(string));
            dataTable.Columns[CT_Col_ErrContent].Caption = "エラー内容";
        }

        /// <summary>
        /// エラーデータをファイルに書き込み
        /// </summary>
        /// <param name="errWorkList">エラーデータ</param>
        /// <param name="exErrMsg">例外メッセージ</param>
        /// <remarks>
        /// <br>Note        : エラーデータをファイルに書き込み</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        public int WriteErrorMsg(List<ErrTxtgetWork> errWorkList, out string exErrMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            exErrMsg = string.Empty;

            // エラーデータ出力用DataTableのColumnsを追加する
            // 東邦車両様
            if (UserDiv == 0)
            {
                this.CreateDataTableAnnual(ref ErrDataTable);
            }
            // 東邦車両様以外
            else
            {
                this.CreateDataTable(ref ErrDataTable);
            }

            // 出力されたか
            bool writeCheck = false;

            try
            {
                //エラーファイルなし
                if (File.Exists(this.ErrFileName))
                {
                    writeCheck = true;
                }

                // エラー内容
                string errContentStr = string.Empty;

                // エラーデータループ
                foreach (ErrTxtgetWork errWork in errWorkList)
                {
                    DataRow dataRow = ErrDataTable.NewRow();
                    // 東邦車両様
                    if (UserDiv == 0)
                    {
                        // 受注番号
                        dataRow[CT_Col_AcceptAnOrderNo] = errWork.AcceptAnOrderNo;
                        // 部品コード
                        dataRow[CT_Col_GoodsCode] = errWork.GoodsCode;
                        // 環境(システム)日付
                        dataRow[CT_Col_SysDate] = errWork.SysDate;
                    }
                    // 東邦車両様以外
                    else
                    {
                        // 仕入先
                        dataRow[CT_Col_SupplierCd] = errWork.SupplierCd;
                        // 仕入伝票番号
                        dataRow[CT_Col_SupplierSlipNo] = errWork.SupplierSlipNo;
                        // 品番
                        dataRow[CT_Col_GoodsNo] = errWork.GoodsNo;

                    }
                    // 出荷数量①
                    dataRow[CT_Col_ShipmentCnt1] = errWork.ShipmentCnt1;
                    // 受注単価
                    dataRow[CT_Col_AcceptAnOrderUnCst] = errWork.AcceptAnOrderUnCst;
                    // エラー内容
                    errContentStr = string.Empty;
                    foreach (string errMsg in errWork.Errormessage)
                    {
                        errContentStr += errMsg + ",";
                    }
                    dataRow[CT_Col_ErrContent] = errContentStr.Remove(errContentStr.LastIndexOf(","), 1);

                    ErrDataTable.Rows.Add(dataRow);
                }

                // CSV出力情報処理
                FormattedTextWriter printInfo = new FormattedTextWriter();
                Object paraInfo = (object)printInfo;
                this.GetCSVInfo(ref paraInfo, ErrDataTable, this.ErrFileName, writeCheck);

                // エラーデータ出力
                int TotalCount = 0;
                status = printInfo.TextOut(out TotalCount);
            }
            catch (Exception ex)
            {
                exErrMsg = ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// CSV出力情報処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <param name="dt">データ</param>
        /// <param name="outPutFileName">出力パース</param>
        /// <param name="outPutMode">新規書込か判断フラグ</param>
        /// <remarks>
        /// <br>Note        : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void GetCSVInfo(ref object parameter, DataTable dt, string outPutFileName, bool outPutMode)
        {
            List<string> schemeList = new List<string>();
            // 東邦車両の場合
            if (UserDiv == 0)
            {
                // 受注番号
                schemeList.Add(CT_Col_AcceptAnOrderNo);
                // 部品コード
                schemeList.Add(CT_Col_GoodsCode);
                // 出荷数量①
                schemeList.Add(CT_Col_ShipmentCnt1);
                // 受注単価
                schemeList.Add(CT_Col_AcceptAnOrderUnCst);
                // 環境(システム)日付
                schemeList.Add(CT_Col_SysDate);
            }
            // 東邦車両以外の場合
            else
            {
                // 出荷数量①
                schemeList.Add(CT_Col_ShipmentCnt1);
                // 受注単価
                schemeList.Add(CT_Col_AcceptAnOrderUnCst);
                // 仕入先
                schemeList.Add(CT_Col_SupplierCd);
                // 仕入伝票番号
                schemeList.Add(CT_Col_SupplierSlipNo);
                // 品番
                schemeList.Add(CT_Col_GoodsNo);
            }
            // エラー内容
            schemeList.Add(CT_Col_ErrContent);

            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();
             // 東邦車両様
            if (UserDiv == 0)
            {
                maxLengthList.Add(CT_Col_AcceptAnOrderNo, 10);
                maxLengthList.Add(CT_Col_GoodsCode, 30);
                maxLengthList.Add(CT_Col_AcceptAnOrderUnCst, 12);
            }
            maxLengthList.Add(CT_Col_ShipmentCnt1, 12);
            // 東邦車両様以外
            if (UserDiv == 1)
            {
                // 仕入先
                maxLengthList.Add(CT_Col_SupplierCd, 6);
                // 仕入伝票番号
                maxLengthList.Add(CT_Col_SupplierSlipNo,20);
                // 品番
                maxLengthList.Add(CT_Col_GoodsNo,30);
            }
            maxLengthList.Add(CT_Col_ErrContent, 50);

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());
            enclosingTypeList.Add(typeof(System.Int32));
            enclosingTypeList.Add(typeof(System.Int64));
            enclosingTypeList.Add(typeof(System.Double));

            FormattedTextWriter formattedTextWriter = parameter as FormattedTextWriter;
            formattedTextWriter.DataSource = dt;
            formattedTextWriter.DataMember = String.Empty;
            //テキストファイル出力パスの取得
            formattedTextWriter.OutputFileName = outPutFileName;
            //テキスト出力する項目名のリスト
            formattedTextWriter.SchemeList = schemeList;
            formattedTextWriter.Splitter = ",";
            formattedTextWriter.Encloser = "\"";
            formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            if (outPutMode)
            {
                formattedTextWriter.CaptionOutput = false;
                formattedTextWriter.OutputMode = true;
            }
            else
            {
                formattedTextWriter.CaptionOutput = true;
                formattedTextWriter.OutputMode = false;
            }
            formattedTextWriter.FixedLength = false;
            formattedTextWriter.ReplaceList = null;
            formattedTextWriter.FormatList = null;
            formattedTextWriter.MaxLengthList = maxLengthList;
        }

        /// <summary>
        /// 仕入データからエラーデータに変換
        /// </summary>
        /// <param name="initData">仕入データ</param>
        /// <param name="errornote">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note        : エラーデータに変換する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        public ErrTxtgetWork GetErrTxtWork(InitDataItem initData,List<string> errornote)
        {
            ErrTxtgetWork errwork = new ErrTxtgetWork();

            // 受注番号
            errwork.AcceptAnOrderNo = initData.AcceptAnOrderNo;
            // 部品コード
            errwork.GoodsCode = initData.GoodsCode;
            // 数量
            errwork.ShipmentCnt1 = initData.ShipmentCnt1;
            // 受注単価
            errwork.AcceptAnOrderUnCst = initData.AcceptAnOrderUnCst;
            // 環境(システム)日付
            errwork.SysDate = initData.SysDate;
            // 仕入先
            errwork.SupplierCd = initData.SupplierCd;
            // 品番
            errwork.GoodsNo = initData.GoodsNo;
            // 仕入伝票番号
            errwork.SupplierSlipNo = initData.SupplierSlipNo;
            // エラー内容
            errwork.Errormessage = errornote;

            return errwork;
        }

        /// <summary>
        /// XMLでデータの取得
        /// </summary>
        /// <param name="initDataInfo">XMLデータ</param>
        /// <param name=" errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : XMLでデータの取得します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br>Update Note : 2021/12/19 陳艶丹</br>
        /// <br>管理番号    : 11770181-00</br>
        /// <br>            : PMKOBETSU-4200 設定ファイルの保存場所読込順番を改良対応</br>
        /// </remarks>
        private int GetXmlDataInfo(ref InitDataItem initDataInfo, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // エラーメッセージ
            errMsg = string.Empty;
            // ------ ADD 2021/12/19 陳艶丹 PMKOBETSU-4200の対応 --------- >>>>>
            string　fileDir = ConstantManagement_ClientDirectory.NSCurrentDirectory;
            bool fileExist = false;
            // XMLファイル存在チェック
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, XmlFileName)))
            {
                fileExist = true;
            }
            else if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName)))
            {
                fileExist = true;
                fileDir = ConstantManagement_ClientDirectory.UISettings;
            }
            // ------ ADD 2021/12/19 陳艶丹 PMKOBETSU-4200の対応 --------- <<<<<

            // XMLファイル存在チェック
            // ------ UPD 2021/12/19 陳艶丹 PMKOBETSU-4200の対応 --------- >>>>>
            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, XmlFileName)))
            if (fileExist)
            // ------ UPD 2021/12/19 陳艶丹 PMKOBETSU-4200の対応 --------- <<<<<
            {
                try
                {
                    // ------ UPD 2021/12/19 陳艶丹 PMKOBETSU-4200の対応 --------- >>>>>
                    //initDataInfo = UserSettingController.DeserializeUserSetting<InitDataItem>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, XmlFileName));
                    initDataInfo = UserSettingController.DeserializeUserSetting<InitDataItem>(Path.Combine(fileDir, XmlFileName));
                    // ------ UPD 2021/12/19 陳艶丹 PMKOBETSU-4200の対応 --------- <<<<<
                    // 仕入先コード取り込み失敗
                    if (string.IsNullOrEmpty(initDataInfo.SupplierCd))
                    {
                        // 画面に仕入先コードを設定していない場合
                        if (this._stockSlip.SupplierCd == 0)
                        {
                            // 東邦車両の場合
                            if (UserDiv == 0)
                            {
                                errMsg = CT_ERROR_MEASSSAGE10;
                            }
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                        // 画面に仕入先コードを設定している場合
                        else
                        {
                            status = SetSecWarehouse(this._stockSlip.SupplierCd);
                            initDataInfo.SupplierCd = this._stockSlip.SupplierCd.ToString();
                        }
                    }
                    else
                    {
                        // 仕入先コード
                        int supplierCdInt = 0;

                        // 数字で設定している場合
                        if (Int32.TryParse(initDataInfo.SupplierCd, out supplierCdInt))
                        {
                            status = SetSecWarehouse(supplierCdInt);

                            // 汎用ファイルに設定されている仕入先が不正の場合
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 画面に仕入先コードを設定していない場合
                                if (this._stockSlip.SupplierCd == 0)
                                {
                                    // 東邦車両の場合
                                    if (UserDiv == 0)
                                    {
                                        errMsg = CT_ERROR_MEASSSAGE13;
                                    }
                                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                }
                                // 画面に仕入先コードを設定している場合
                                else
                                {
                                    status = SetSecWarehouse(this._stockSlip.SupplierCd);
                                    initDataInfo.SupplierCd = this._stockSlip.SupplierCd.ToString();
                                }
                            }
                            else
                            {
                                // 無し
                            }
                        }
                        else
                        {
                            // 画面に仕入先コードを設定していない場合
                            if (this._stockSlip.SupplierCd == 0)
                            {
                                // 東邦車両の場合
                                if (UserDiv == 0)
                                {
                                    errMsg = CT_ERROR_MEASSSAGE13;
                                }
                                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            }
                            // 画面に仕入先コードを設定している場合
                            else
                            {
                                status = SetSecWarehouse(this._stockSlip.SupplierCd);
                                initDataInfo.SupplierCd = this._stockSlip.SupplierCd.ToString();
                            }
                        }
                    }
                }
                catch
                {
                    initDataInfo = new InitDataItem();
                    errMsg = CT_ERROR_MEASSSAGE11;
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            else
            {
                errMsg = CT_ERROR_MEASSSAGE09;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 仕入先の管理拠点の倉庫リスト取得処理
        /// </summary>
        /// <param name="supplierCdInt">仕入先コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 仕入先の管理拠点の倉庫リスト取得処理を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private int SetSecWarehouse(int supplierCdInt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 仕入先情報
            Supplier supplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();

            // 仕入先情報取得
            status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCdInt);

            // 仕入先設定不正の場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplier.LogicalDeleteCode != 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else
            {
                // 拠点コード
                string sectionCodeStr = string.Empty;

                // 画面にて仕入先コード入力していない場合
                if (this._stockSlip.SupplierCd == 0)
                {
                    // 仕入先の管理拠点で在庫チェックを行う
                    sectionCodeStr = supplier.MngSectionCode;
                }
                // 画面にて仕入先コード入力している場合
                else
                {
                    // 画面にて拠点を入力していない場合
                    if (string.IsNullOrEmpty(this._stockSlip.StockSectionCd.Trim()))
                    {
                        // 仕入先の管理拠点で在庫チェックを行う
                        sectionCodeStr = supplier.MngSectionCode;
                    }
                    else
                    {
                        // 画面の拠点で在庫チェックを行う
                        sectionCodeStr = this._stockSlip.StockSectionCd.Trim();
                    }
                }

                // 仕入先の管理拠点の倉庫リスト取得
                SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(sectionCodeStr);
                if (secInfoSet != null)
                {
                    WarehouseDictionary = new Dictionary<string, string>();
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd1.Trim())) WarehouseDictionary.Add(secInfoSet.SectWarehouseCd1.Trim(), secInfoSet.SectWarehouseCd1.Trim());
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd2.Trim())) WarehouseDictionary.Add(secInfoSet.SectWarehouseCd2.Trim(), secInfoSet.SectWarehouseCd2.Trim());
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd3.Trim())) WarehouseDictionary.Add(secInfoSet.SectWarehouseCd3.Trim(), secInfoSet.SectWarehouseCd3.Trim());
                }

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// データチェック処理
        /// </summary>
        /// <param name="csvDataList">取込ファイル</param>
        /// <param name="errWorkList">エラーデータリスト</param>
        /// <param name="initDataInfo">XMLファイルのデータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note        : データチェック処理する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private int CheckData(List<string[]> csvDataList, ref List<ErrTxtgetWork> errWorkList, InitDataItem initDataInfo, string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            SFCMN00299CA msgForm = new SFCMN00299CA();
            // エラーメッセージ
            List<string> errorNote = null;
            // テキスト取込完了リスト
            List<InitDataItem> initDataList = new List<InitDataItem>();
            int count = 0;

            try
            {
                msgForm.Title = "データ取込中";
                msgForm.Show();
                msgForm.Message = "現在、データを取込中です。";

                // 取込データ
                FirstInitData = new InitDataItem();

                foreach(string[] arryLine in csvDataList)
                {
                    count++;

                    // エラーリスト
                    errorNote = new List<string>();
                    // 取込データ
                    InitDataItem initData = new InitDataItem();
                    // エラーログ出力用ワーク
                    ErrTxtgetWork errdata = new ErrTxtgetWork();

                    // 項目数不正チェック
                    // 東邦車両の場合
                    if ((arryLine.Length != 17 && UserDiv == 0) ||
                        // 東邦車両以外の場合
                        (arryLine.Length != 32 && UserDiv == 1))
                    {
                        errorNote.Add(CT_ERROR_MEASSSAGE00);
                        errdata.AcceptAnOrderNo = string.Empty;
                        errdata.GoodsCode = string.Empty;
                        errdata.ShipmentCnt1 = string.Empty;
                        errdata.AcceptAnOrderUnCst = string.Empty;
                        errdata.SysDate = string.Empty;
                        errdata.GoodsNo = string.Empty;
                        errdata.SupplierCd = string.Empty;
                        errdata.SupplierSlipNo = string.Empty;
                        errdata.Errormessage = errorNote;

                        errWorkList.Add(errdata);
                    }
                    else
                    {
                        // 東邦車両の場合
                        if (UserDiv == 0)
                        {
                            #region 受注番号
                            string acceptAnOrderNo = arryLine[0].Trim();
                            // １レコード目だけを桁数チェックを行う
                            if (count == 1)
                            {
                                initData.AcceptAnOrderNo = acceptAnOrderNo;
                                // 桁数ﾁｪｯｸ
                                if (initData.AcceptAnOrderNo.Length > 19)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE01);
                                }
                            }
                            else
                            {
                                initData.AcceptAnOrderNo = acceptAnOrderNo;
                            }
                            #endregion

                            #region 部品コード
                            string goodsCode = arryLine[2].Trim();
                            if (!string.IsNullOrEmpty(goodsCode))
                            {
                                initData.GoodsCode = goodsCode;
                            }
                            //テキストファイルデータなし xmlファイルの部品コードあり
                            else if (!string.IsNullOrEmpty(initDataInfo.GoodsCode))
                            {
                                initData.GoodsCode = initDataInfo.GoodsCode;
                            }
                            //xmlファイルの部品コードなし xmlファイルの品番あり
                            else if (!string.IsNullOrEmpty(initDataInfo.GoodsNo))
                            {
                                initData.GoodsCode = initDataInfo.GoodsNo;
                            }
                            //テキストファイルデータの部品コードなし、xmlファイルの部品コードと品番なし
                            else
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE02);
                            }
                            // 桁数ﾁｪｯｸ
                            if (initData.GoodsCode.Length > 24)
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE02);
                            }
                            //半角チェック
                            else if (!HalfCheck(initData.GoodsCode))
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE02);
                            }
                            #endregion
                        }
                        // 東邦車両以外の場合
                        else
                        {
                            #region 入荷日
                            // 日付
                            DateTime dt = DateTime.MinValue;
                            // 入荷日
                            string arrivalGoodsDay = arryLine[20].Trim();
                            // 取込レコードの入荷日設定されるか
                            bool inPutArrivalGoodsDayFlag = true;

                            try
                            {
                                dt = DateTime.ParseExact(arrivalGoodsDay, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                // 取込レコードの入荷日設定される場合
                                initData.ArrivalGoodsDay = arrivalGoodsDay;
                            }
                            catch
                            {
                                // 取込レコードの入荷日設定されない場合
                                inPutArrivalGoodsDayFlag = false;
                            }

                            // 取込レコードの入荷日設定されない場合
                            if (!inPutArrivalGoodsDayFlag)
                            {
                                arrivalGoodsDay = initDataInfo.ArrivalGoodsDay;

                                try
                                {
                                    dt = DateTime.ParseExact(arrivalGoodsDay, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                    // 汎用XMLファイルの入荷日設定される場合
                                    initData.ArrivalGoodsDay = arrivalGoodsDay;
                                }
                                catch
                                {
                                    // 汎用XMLファイルの入荷日設定されない場合
                                    initData.ArrivalGoodsDay = DateTime.Now.ToString("yyyyMMdd"); ;
                                }
                            }
                            #endregion

                            #region 仕入日
                            // 日付
                            dt = DateTime.MinValue;
                            // 仕入日
                            string stockDate = arryLine[21].Trim();
                            // 取込レコードの仕入日設定されるか
                            bool inPutstockDateFlag = true;

                            try
                            {
                                dt = DateTime.ParseExact(stockDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                // 取込レコードの仕入日設定される場合
                                initData.StockDate = stockDate;
                            }
                            catch
                            {
                                // 取込レコードの仕入日設定されない場合
                                inPutstockDateFlag = false;
                            }

                            // 取込レコードの仕入日設定されない場合
                            if (!inPutstockDateFlag)
                            {
                                stockDate = initDataInfo.StockDate;

                                try
                                {
                                    dt = DateTime.ParseExact(stockDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                    // 汎用XMLファイルの仕入日設定される場合
                                    initData.StockDate = stockDate;
                                }
                                catch
                                {
                                    // 汎用XMLファイルの仕入日設定されない場合
                                    initData.StockDate = DateTime.Now.ToString("yyyyMMdd"); ;
                                }
                            }
                            #endregion

                            #region 明細備考
                            // 明細備考
                            initData.StockDtlSlipNote = arryLine[25].Trim();
                            if (!string.IsNullOrEmpty(initData.StockDtlSlipNote))
                            {
                                // 明細備考
                                if (initData.StockDtlSlipNote.Length > 30)
                                {
                                    // 明細備考
                                    initData.StockDtlSlipNote = initData.StockDtlSlipNote.Substring(0, 30);
                                }
                            }
                            else
                            {
                                // 明細備考
                                if (initDataInfo.StockDtlSlipNote.Length > 30)
                                {
                                    // 明細備考
                                    initData.StockDtlSlipNote = initDataInfo.StockDtlSlipNote.Substring(0, 30);
                                }
                                else
                                {
                                    // 明細備考
                                    initData.StockDtlSlipNote = initDataInfo.StockDtlSlipNote;
                                }
                            }
                            #endregion

                            #region メモ
                            // 社内メモ１
                            initData.InsideMemo1 = arryLine[26].Trim();
                            // 社内メモ２
                            initData.InsideMemo2 = arryLine[27].Trim();
                            // 社内メモ３
                            initData.InsideMemo3 = arryLine[28].Trim();
                            // 社外メモ１
                            initData.SlipMemo1 = arryLine[29].Trim();
                            // 社外メモ２
                            initData.SlipMemo2 = arryLine[30].Trim();
                            // 社外メモ３
                            initData.SlipMemo3 = arryLine[31].Trim();
                            #endregion
                        }

                        #region 出荷数量①
                        double doublenum = 0;
                        string shipmentCnt1 = arryLine[5].Trim();
                        if (!string.IsNullOrEmpty(shipmentCnt1))
                        {
                            initData.ShipmentCnt1 = shipmentCnt1;
                            // ダブル型データチェック
                            if (Double.TryParse(shipmentCnt1, out doublenum))
                            {
                                // 0の場合
                                if (doublenum == 0)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE05);
                                }
                            }
                            else
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE05);
                            }
                        }
                        // テキストファイルデータなし XMLファイルの出荷数量①あり
                        else if (!string.IsNullOrEmpty(initDataInfo.ShipmentCnt1))
                        {
                            initData.ShipmentCnt1 = initDataInfo.ShipmentCnt1;
                            // ダブル型データチェック
                            if (Double.TryParse(initDataInfo.ShipmentCnt1, out doublenum))
                            {
                                // 0の場合
                                if (doublenum == 0)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE05);
                                }
                            }
                            else
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE05);
                            }

                        }
                        // テキストファイルデータの出荷数量①なし、xmlファイルの出荷数量①なし
                        else
                        {
                            doublenum = 0;
                            errorNote.Add(CT_ERROR_MEASSSAGE05);
                        }

                        // 桁数ﾁｪｯｸ
                        if (doublenum.ToString().Length > 10)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE05);
                        }
                        // 範囲チェック
                        else if (doublenum < -9999999.9 || doublenum > 9999999.9)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE05);
                        }
                        #endregion

                        #region 受注単価
                        doublenum = 0;
                        string acceptAnOrderUnCst = arryLine[8].Trim();
                        // テキストファイルデータあり
                        if (!string.IsNullOrEmpty(acceptAnOrderUnCst))
                        {
                            initData.AcceptAnOrderUnCst = acceptAnOrderUnCst;
                            // ダブル型データチェック
                            if (!Double.TryParse(acceptAnOrderUnCst, out doublenum))
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE06);
                            }
                        }
                        else if (!string.IsNullOrEmpty(initDataInfo.AcceptAnOrderUnCst))
                        {
                            initData.AcceptAnOrderUnCst = initDataInfo.AcceptAnOrderUnCst;
                            // ダブル型データチェック
                            if (!Double.TryParse(initDataInfo.AcceptAnOrderUnCst, out doublenum))
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE06);
                            }
                        }
                        else
                        {
                            doublenum = 0;
                            errorNote.Add(CT_ERROR_MEASSSAGE06);
                        }

                        // 桁数ﾁｪｯｸ
                        if (doublenum.ToString().Length > 10)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE06);
                        }
                        // 範囲チェック
                        else if (doublenum > 99999999.9 || doublenum < 0)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE06);
                        }
                        #endregion

                        // 東邦車両の場合
                        if (UserDiv == 0)
                        {
                            #region 環境(システム)日付
                            DateTime dt = DateTime.MinValue;
                            string sysDate = arryLine[11].Trim();

                            // １レコード目の場合
                            if (count == 1)
                            {
                                // 取込ファイルに環境(システム)日付を設定する場合
                                if (!string.IsNullOrEmpty(sysDate))
                                {
                                    initData.SysDate = sysDate;
                                    try
                                    {
                                        dt = DateTime.ParseExact(sysDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                        initData.ArrivalGoodsDay = sysDate;
                                        initData.StockDate = sysDate;
                                    }
                                    catch
                                    {
                                        errorNote.Add(CT_ERROR_MEASSSAGE08);
                                    }
                                }
                                // 汎用XMLファイルに環境(システム)日付を設定する場合
                                else if (!string.IsNullOrEmpty(initDataInfo.SysDate))
                                {
                                    initData.SysDate = initDataInfo.SysDate;
                                    try
                                    {
                                        dt = DateTime.ParseExact(initDataInfo.SysDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                        initData.ArrivalGoodsDay = initDataInfo.SysDate;
                                        initData.StockDate = initDataInfo.SysDate;
                                    }
                                    catch
                                    {
                                        errorNote.Add(CT_ERROR_MEASSSAGE08);
                                    }
                                }
                                else
                                {

                                    try
                                    {
                                        dt = DateTime.ParseExact(initDataInfo.ArrivalGoodsDay, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                        // 汎用XMLファイルに入荷日を設定する場合
                                        initData.ArrivalGoodsDay = initDataInfo.ArrivalGoodsDay;
                                    }
                                    catch
                                    {
                                        initData.ArrivalGoodsDay = DateTime.Now.ToString("yyyyMMdd");
                                    }

                                    try
                                    {
                                        dt = DateTime.ParseExact(initDataInfo.StockDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                        // 汎用XMLファイルに仕入日を設定する場合
                                        initData.StockDate = initDataInfo.StockDate;
                                    }
                                    catch
                                    {
                                        initData.StockDate = DateTime.Now.ToString("yyyyMMdd");
                                    }
                                }
                            }
                            else
                            {
                                initData.SysDate = FirstInitData.SysDate;
                                initData.ArrivalGoodsDay = FirstInitData.ArrivalGoodsDay;
                                initData.StockDate = FirstInitData.StockDate;
                            }
                            #endregion
                        }

                        // １レコード目のみの場合
                        if (count == 1)
                        {
                            #region 担当者
                            // 担当者
                            string stockAgentCode = string.Empty;
                            string stockAgentName = string.Empty;

                            // 東邦車両の場合
                            if (UserDiv == 0)
                            {
                                // 担当者
                                stockAgentCode = initDataInfo.StockAgentCode.Trim();
                                // 担当者名称
                                stockAgentName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockAgentCode);

                                // 汎用XMLの担当者不正の場合
                                // ログイン従業員を使用
                                if (string.IsNullOrEmpty(stockAgentName))
                                {
                                    initData.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                                }
                                // 汎用XMLの担当者を使用
                                else
                                {
                                    initData.StockAgentCode = stockAgentCode;
                                }
                            }
                            // 東邦車両以外の場合
                            else
                            {
                                // 担当者
                                stockAgentCode = arryLine[17].Trim();
                                // 担当者名称
                                stockAgentName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockAgentCode);

                                // １レコード目の担当者不正の場合
                                // 汎用XMLの担当者を使用
                                if (string.IsNullOrEmpty(stockAgentName))
                                {
                                    // 担当者
                                    stockAgentCode = initDataInfo.StockAgentCode.Trim();
                                    // 担当者名称
                                    stockAgentName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockAgentCode);

                                    // 汎用XMLの担当者不正の場合
                                    // ログイン従業員を使用
                                    if (string.IsNullOrEmpty(stockAgentName))
                                    {
                                        initData.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                                    }
                                    // 汎用XMLの担当者を使用
                                    else
                                    {
                                        initData.StockAgentCode = stockAgentCode;
                                    }
                                }
                                // １レコード目の担当者を使用
                                else
                                {
                                    initData.StockAgentCode = stockAgentCode;
                                }
                            }
                            #endregion

                            #region 仕入先
                            // 仕入先
                            string supplierCdStr = string.Empty;
                            int supplierCdInt = 0;

                            // 東邦車両の場合
                            if (UserDiv == 0)
                            {
                                initData.SupplierCd = initDataInfo.SupplierCd;
                            }
                            // 東邦車両以外の場合
                            else
                            {
                                initData.SupplierCd = arryLine[18].Trim();
                                int supplierCdStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                                // １レコード目の仕入先が数字の場合
                                if (Int32.TryParse(initData.SupplierCd, out supplierCdInt))
                                {
                                    // 仕入先が存在するか
                                    supplierCdStatus = SetSecWarehouse(supplierCdInt);

                                    // 当該仕入先が存在していない場合
                                    if (supplierCdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    {
                                        initData.SupplierCd = initDataInfo.SupplierCd;

                                        // 汎用XMLまたは画面に仕入先が数字の場合
                                        if (Int32.TryParse(initDataInfo.SupplierCd, out supplierCdInt))
                                        {
                                            // 仕入先が存在するか
                                            supplierCdStatus = SetSecWarehouse(supplierCdInt);

                                            // 当該仕入先が存在していない場合
                                            if (supplierCdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                            {
                                                errorNote.Add(CT_ERROR_MEASSSAGE18);
                                            }
                                            // 当該仕入先が存在する場合
                                            else
                                            {
                                                // 無し
                                            }
                                        }
                                        else
                                        {
                                            errorNote.Add(CT_ERROR_MEASSSAGE18);
                                        }
                                    }
                                    // 当該仕入先が存在する場合
                                    else
                                    {
                                        // 無し
                                    }
                                }
                                // １レコード目の仕入先が数字以外の場合
                                else
                                {
                                    initData.SupplierCd = initDataInfo.SupplierCd;

                                    // 汎用XMLまたは画面に仕入先が数字の場合
                                    if (Int32.TryParse(initDataInfo.SupplierCd, out supplierCdInt))
                                    {
                                        // 仕入先が存在するか
                                        supplierCdStatus = SetSecWarehouse(supplierCdInt);

                                        // 当該仕入先が存在していない場合
                                        if (supplierCdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                        {
                                            errorNote.Add(CT_ERROR_MEASSSAGE18);
                                        }
                                        // 当該仕入先が存在する場合
                                        else
                                        {
                                            // 無し
                                        }
                                    }
                                    else
                                    {
                                        errorNote.Add(CT_ERROR_MEASSSAGE18);
                                    }
                                }
                            }
                            #endregion

                            #region 伝票区分
                            // 伝票区分
                            string supplierSlipCd = string.Empty;

                            // 東邦車両の場合
                            if (UserDiv == 0)
                            {
                                initData.SupplierSlipCd = StockDiv;
                            }
                            // 東邦車両以外の場合
                            else
                            {
                                // 伝票区分
                                supplierSlipCd = arryLine[19].Trim();

                                // １レコード目の伝票区分が仕入または返品で設定している場合
                                if (StockDiv.Equals(supplierSlipCd) || ReturnDiv.Equals(supplierSlipCd))
                                {
                                    initData.SupplierSlipCd = supplierSlipCd;
                                }
                                else
                                {
                                    // 汎用XMLファイルの伝票区分
                                    supplierSlipCd = initDataInfo.SupplierSlipCd.Trim();

                                    // 汎用XMLファイルの伝票区分が仕入または返品で設定している場合
                                    if (StockDiv.Equals(supplierSlipCd) || ReturnDiv.Equals(supplierSlipCd))
                                    {
                                        initData.SupplierSlipCd = supplierSlipCd;
                                    }
                                    else
                                    {
                                        initData.SupplierSlipCd = StockDiv;
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            // 東邦車両以外の場合
                            if (UserDiv != 0)
                            {
                                // 仕入先
                                initData.SupplierCd = arryLine[18].Trim();
                            }
                        }

                        // 東邦車両以外の場合
                        if (UserDiv != 0)
                        {
                            #region 伝票番号
                            // 伝票番号
                            string supplierSlipNo = arryLine[22].Trim();

                            // １レコード目だけを桁数チェックを行う
                            if (count == 1)
                            {
                                // 伝票番号
                                if (!string.IsNullOrEmpty(supplierSlipNo))
                                {
                                    initData.SupplierSlipNo = supplierSlipNo;
                                }
                                // 取込ファイルデータなし 汎用XMLファイルの仕入伝票番号利用する
                                else if (!string.IsNullOrEmpty(initDataInfo.SupplierSlipNo))
                                {
                                    initData.SupplierSlipNo = initDataInfo.SupplierSlipNo;
                                }
                                else
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE07);
                                }
                                // 桁数ﾁｪｯｸ
                                if (initData.SupplierSlipNo.Length > 19)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE07);
                                }
                            }
                            else
                            {
                                initData.SupplierSlipNo = supplierSlipNo;
                            }
                            #endregion
                        }

                        #region 品番
                        // 東邦車両様
                        if (UserDiv == 0)
                        {
                            initData.GoodsNo = initDataInfo.GoodsNo;
                        }
                        // 東邦車両様以外
                        else
                        {
                            string goodsNo = arryLine[23].Trim();
                            if (!string.IsNullOrEmpty(goodsNo))
                            {
                                initData.GoodsNo = goodsNo;
                                // 桁数ﾁｪｯｸ
                                if (initData.GoodsNo.Length > 24)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE17);
                                }
                                //半角チェック
                                else if (!HalfCheck(initData.GoodsNo))
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE17);
                                }
                            }
                            //テキストファイルデータなし xmlファイルの品番あり
                            else if (!string.IsNullOrEmpty(initDataInfo.GoodsNo))
                            {
                                initData.GoodsNo = initDataInfo.GoodsNo;
                                // 桁数ﾁｪｯｸ
                                if (initData.GoodsNo.Length > 24)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE17);
                                }
                                //半角チェック
                                else if (!HalfCheck(initData.GoodsNo))
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE17);
                                }
                            }
                            else
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE17);
                            }
                            
                        }
                        #endregion

                        #region メーカー
                        // 東邦車両の場合
                        if (UserDiv == 0)
                        {
                            initData.GoodsMakerCd = initDataInfo.GoodsMakerCd;
                        }
                        // 東邦車両以外の場合
                        else
                        {
                            // メーカー
                            string goodsMakerCdStr = arryLine[24].Trim();
                            int goodsMakerCdInt = 0;

                            // １レコード目のメーカーが設定されている場合
                            if (Int32.TryParse(goodsMakerCdStr, out goodsMakerCdInt))
                            {
                                initData.GoodsMakerCd = goodsMakerCdStr;
                            }
                            // １レコード目のメーカーが設定されていない場合
                            else
                            {
                                initData.GoodsMakerCd = initDataInfo.GoodsMakerCd;
                            }
                        }
                        #endregion

                        #region メモ
                        // 社内メモ１
                        if (!string.IsNullOrEmpty(initData.InsideMemo1))
                        {
                            if (initData.InsideMemo1.Length > 20)
                            {
                                // 社内メモ１
                                initData.InsideMemo1 = initData.InsideMemo1.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // 汎用XMLの社内メモ１を使用
                            if (initDataInfo.InsideMemo1.Length > 20)
                            {
                                // 社内メモ１
                                initData.InsideMemo1 = initDataInfo.InsideMemo1.Substring(0, 20);
                            }
                            else
                            {
                                // 社内メモ１
                                initData.InsideMemo1 = initDataInfo.InsideMemo1;
                            }
                        }

                        // 社内メモ２
                        if (!string.IsNullOrEmpty(initData.InsideMemo2))
                        {
                            if (initData.InsideMemo2.Length > 20)
                            {
                                // 社内メモ２
                                initData.InsideMemo2 = initData.InsideMemo2.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // 汎用XMLの社内メモ２を使用
                            if (initDataInfo.InsideMemo2.Length > 20)
                            {
                                // 社内メモ２
                                initData.InsideMemo2 = initDataInfo.InsideMemo2.Substring(0, 20);
                            }
                            else
                            {
                                // 社内メモ２
                                initData.InsideMemo2 = initDataInfo.InsideMemo2;
                            }
                        }
                        // 社内メモ３
                        if (!string.IsNullOrEmpty(initData.InsideMemo3))
                        {
                            if (initData.InsideMemo3.Length > 20)
                            {
                                // 社内メモ３
                                initData.InsideMemo3 = initData.InsideMemo3.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // 汎用XMLの社内メモ３を使用
                            if (initDataInfo.InsideMemo3.Length > 20)
                            {
                                // 社内メモ３
                                initData.InsideMemo3 = initDataInfo.InsideMemo3.Substring(0, 20);
                            }
                            else
                            {
                                // 社内メモ３
                                initData.InsideMemo3 = initDataInfo.InsideMemo3;
                            }
                        }

                        // 社外メモ１
                        if (!string.IsNullOrEmpty(initData.SlipMemo1))
                        {
                            if (initData.SlipMemo1.Length > 20)
                            {
                                // 社外メモ１
                                initData.SlipMemo1 = initData.SlipMemo1.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // 汎用XMLの社外メモ１を使用
                            if (initDataInfo.SlipMemo1.Length > 20)
                            {
                                // 社外メモ１
                                initData.SlipMemo1 = initDataInfo.SlipMemo1.Substring(0, 20);
                            }
                            else
                            {
                                // 社外メモ１
                                initData.SlipMemo1 = initDataInfo.SlipMemo1;
                            }
                        }

                        // 社外メモ２
                        if (!string.IsNullOrEmpty(initData.SlipMemo2))
                        {
                            if (initData.SlipMemo2.Length > 20)
                            {
                                // 社外メモ２
                                initData.SlipMemo2 = initData.SlipMemo2.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // 汎用XMLの社外メモ２を使用
                            if (initDataInfo.SlipMemo2.Length > 20)
                            {
                                // 社外メモ２
                                initData.SlipMemo2 = initDataInfo.SlipMemo2.Substring(0, 20);
                            }
                            else
                            {
                                // 社外メモ２
                                initData.SlipMemo2 = initDataInfo.SlipMemo2;
                            }
                        }

                        // 社外メモ３
                        if (!string.IsNullOrEmpty(initData.SlipMemo3))
                        {
                            if (initData.SlipMemo3.Length > 20)
                            {
                                // 社外メモ３
                                initData.SlipMemo3 = initData.SlipMemo3.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // 汎用XMLの社外メモ３を使用
                            if (initDataInfo.SlipMemo3.Length > 20)
                            {
                                // 社外メモ３
                                initData.SlipMemo3 = initDataInfo.SlipMemo3.Substring(0, 20);
                            }
                            else
                            {
                                // 社外メモ３
                                initData.SlipMemo3 = initDataInfo.SlipMemo3;
                            }
                        }
                        #endregion

                        // エラーデータがある、エラーリストに添加
                        if (errorNote.Count != 0)
                        {
                            errWorkList.Add(GetErrTxtWork(initData, errorNote));
                        }
                        else
                        {
                            initDataList.Add(initData);
                        }
                    }

                    // １レコード目のみの場合
                    if (count == 1)
                    {
                        FirstInitData = initData;
                    }
                }
                
                // 項目フォーマットチェックがOKの場合
                if (errWorkList.Count == 0)
                {
                    // 汎用XMLメーカーコード
                    int goodsMakerCdInitData = 0;
                    Int32.TryParse(initDataInfo.GoodsMakerCd, out goodsMakerCdInitData);

                    // 取込ファイルメーカーコード
                    int goodsMakerCdInPutData = 0;

                    // 在庫リスト
                    List<Stock> stockList = null;

                    // 商品存在・在庫チェック
                    foreach (InitDataItem initdata in initDataList)
                    {
                        //エラーメッセージリスト
                        errorNote = new List<string>();
                        // 商品検証
                        GoodsCndtn condition = new GoodsCndtn();
                        condition.EnterpriseCode = this._enterpriseCode;

                        if (UserDiv == 0)
                        {
                            condition.GoodsNo = initdata.GoodsCode;
                        }
                        else
                        {
                            condition.GoodsNo = initdata.GoodsNo;
                        }
                        condition.GoodsNoSrchTyp = 0;
                        condition.GoodsKindCode = 9;
                        // 取込レコードのメーカーが数字の場合、取込レコードのメーカーを使用
                        if (Int32.TryParse(initdata.GoodsMakerCd, out goodsMakerCdInPutData))
                        {
                            condition.GoodsMakerCd = goodsMakerCdInPutData;
                        }
                        // 取込レコードのメーカーが数字以外の場合、汎用XMLファイルのメーカーを使用
                        else
                        {
                            condition.GoodsMakerCd = goodsMakerCdInitData;
                        }

                        // 在庫リスト
                        stockList = new List<Stock>();
                        // 商品検索処理
                        status = this.SearchGoods(condition, ref stockList);

                        // 商品マスタ未登録
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE03);
                        }
                        // 商品マスタ検索異常
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            errMsg = CT_ERROR_MEASSSAGE11;
                        }

                        // 商品存在する場合、在庫チェックを行う
                        if (errorNote.Count == 0)
                        {
                            // 在庫判定フラグ
                            bool checkstock = false;

                            foreach (Stock stock in stockList)
                            {
                                // 倉庫が論理削除されないて、仕入先の管理拠点にて設定される場合、在庫ありとする
                                if (!(string.IsNullOrEmpty(stock.WarehouseCode) || stock.LogicalDeleteCode != 0) &&
                                    WarehouseDictionary.ContainsKey(stock.WarehouseCode.Trim()))
                                {
                                    checkstock = true;
                                    break;
                                }
                            }

                            // 在庫無し場合
                            if (checkstock == false)
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE04);
                            }
                        }

                        // エラーメッセージあり
                        if (errorNote.Count != 0)
                        {
                            ErrTxtgetWork errWork = new ErrTxtgetWork();
                            errWork = GetErrTxtWork(initdata, errorNote);
                            errWorkList.Add(errWork);
                        }
                        // エラーメッセージなし
                        else 
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            this.CanDoStockDataWorkList.Add(initdata);
                        }
                    }

                    // 画面に展開できるデータがある場合
                    if (this.CanDoStockDataWorkList != null && this.CanDoStockDataWorkList.Count > 0)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
                // 項目フォーマットチェックがNGの場合
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                msgForm.Close();
                msgForm = null;

                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (msgForm != null) msgForm.Close();
            }

            return status;
        }

        /// <summary>
        /// 半角チェック
        /// </summary>
        /// <param name="str">チェック文字列</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 半角チェック</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private bool HalfCheck(string str)
        {
            if (str.Length == Encoding.Default.GetByteCount(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 商品検索処理
        /// </summary>
        /// <param name="goodsCndtn">検索条件</param>
        /// <param name="stockList">在庫リスト</param>
        /// <remarks>
        /// <br>Note        : 商品検索処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private int SearchGoods(GoodsCndtn goodsCndtn, ref List<Stock> stockList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                string msg;
                // 商品管理情報マスタ取得用
                GoodsAcs goodsAcs = new GoodsAcs();
                // 商品マスタ
                List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                string retMsg;
                goodsAcs.SearchInitial(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out retMsg);
                // 商品検索を行う
                status = goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData0, out goodsUnitDataList, out msg);

                switch (status)
                {
                    // 検索結果がある場合
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            foreach (GoodsUnitData goods in goodsUnitDataList)
                            {
                                stockList.AddRange(goods.StockList);
                            }
                            break;
                        }
                    // 検索結果がない場合
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            break;
                        }
                    // 検索異常場合
                    default:
                        {
                            break;
                        }
                }

                // 検索結果がない場合
                if (goodsUnitDataList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 指定した商品、在庫情報のリストを元に、仕入明細データ行オブジェクトに商品、在庫情報を一括設定します。（商品ベース）
        /// </summary>
        /// <param name="stockRowNo">仕入行番号</param>
        /// <param name="goodsUnitDataList">商品情報オブジェクトリスト</param>
        /// <param name="settingStockRowNoList">設定した仕入行番号のリスト</param>
        /// <param name="overWriteRow">true:行上書きあり false:行上書きなし</param>
        /// <param name="stockCount">出荷数量①</param>
        /// <param name="initData">汎用仕入データ</param>
        /// <remarks>
        /// <br>Note        : 指定した商品、在庫情報のリストを元に、仕入明細データ行オブジェクトに商品、在庫情報を一括設定します。（商品ベース）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        public void StockDetailRowGoodsSettingBasedOnGoodsUnitData(int stockRowNo, List<GoodsUnitData> goodsUnitDataList, out List<int> settingStockRowNoList, bool overWriteRow, double stockCount, InitDataItem initData)
        {
            // 設定した明細行番号リスト
            settingStockRowNoList = new List<int>();
            // 削除明細行番号リスト
            List<int> deletingStockRowNoList = new List<int>();
            // 値引行番号リスト
            List<int> goodsDiscountRowList = new List<int>();

            // 商品件数
            int addRowCnt = goodsUnitDataList.Count;
            // 明細行番号
            int stockRowNoWk = stockRowNo;

            while (addRowCnt > 0)
            {
                // 仕入明細行取得
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNoWk);

                try
                {
                    // 行が存在しない場合は新規に追加する
                    if (row == null)
                    {
                        this.AddStockDetailRow();

                        row = this.GetStockDetailRow(stockRowNoWk);
                    }
                    // 行が存在する場合は更新する
                    else
                    {
                        if (!overWriteRow)
                        {
                            if (this.ExistStockDetailInput(row))
                            {
                                continue;
                            }
                        }
                    }

                    // 設定した明細行番号追加
                    settingStockRowNoList.Add(row.StockRowNo);
                    // 削除明細行番号追加
                    deletingStockRowNoList.Add(row.StockRowNo);
                    // 値引行番号追加
                    if (row.StockSlipCdDtl == 2)
                    {
                        goodsDiscountRowList.Add(row.StockRowNo);
                    }

                    // 明細行更新
                    row.AcceptChanges();

                    addRowCnt--;
                }
                finally
                {
                    stockRowNoWk++;
                }
            }

            // 検索対象倉庫配列を取得
            string[] warehouseCodeArray = this.GetSearchWarehouseArray();

            // 仕入明細行削除処理
            this.ClearStockDetailRow(deletingStockRowNoList);
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();

            // 商品情報
            for (int i = 0; i < goodsUnitDataList.Count; i++)
            {
                goodsUnitData = goodsUnitDataList[i];

                // 倉庫を選択する場合
                if (goodsUnitData.SelectedWarehouseCode != null)
                {
                    stock = this._stockSlipInputInitDataAcs.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim());
                }
                // 倉庫を選択しない場合
                else
                {
                    stock = ((warehouseCodeArray != null) && (warehouseCodeArray.Length > 0)) ? this._stockSlipInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray) : null;
                }

                int targetStockRowNo = settingStockRowNoList[i];

                int stockSlipCdDtl = (goodsDiscountRowList.Contains(settingStockRowNoList[i])) ? 2 : 0;

                // 商品、在庫情報設定処理
                this.StockDetailRowGoodsSetting(targetStockRowNo, goodsUnitData, stock, stockSlipCdDtl, stockCount, initData);
            }
        }

        /// <summary>
        /// 指定した商品情報オブジェクトを元に、仕入明細データ行オブジェクトに商品情報を設定します。
        /// </summary>
        /// <param name="stockRowNo">仕入行番号</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <param name="stock">在庫情報オブジェクト</param>
        /// <param name="stockSlipCdDtl">仕入伝票区分(明細)</param>
        /// <param name="stockCount">出荷数量①</param>
        /// <param name="initData">汎用仕入データ</param>
        /// <remarks>
        /// <br>Note        : 指定した商品情報オブジェクトを元に、仕入明細データ行オブジェクトに商品情報を設定します</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void StockDetailRowGoodsSetting(int stockRowNo, GoodsUnitData goodsUnitData, Stock stock, int stockSlipCdDtl, double stockCount, InitDataItem initData)
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            List<int> deleteRowNoList = new List<int>();

            if (row != null)
            {
                // 明細行初期化
                this.ClearStockDetailRow(row);

                // 仕入伝票区分（明細）
                row.StockSlipCdDtl = stockSlipCdDtl;

                // 商品情報がない場合
                if (goodsUnitData == null)
                {
                    // 無し
                }
                else
                {
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
                    row.TaxationCode = goodsUnitData.TaxationDivCd;                     // 課税区分
                    row.GoodsOfferDate = goodsUnitData.OfferDate;                       // 提供日
                    row.TaxDiv = row.TaxationCode;                                      // 課税区分（表示）
                    // 東邦車両の場合
                    if (UserDiv == 0)
                    {
                        row.StockDtiSlipNote1 = initData.AcceptAnOrderNo;               // 仕入伝票明細備考1
                    }
                    // 東邦車両以外の場合
                    else
                    {
                        row.StockDtiSlipNote1 = initData.StockDtlSlipNote;               // 仕入伝票明細備考1
                    }

                    if (row.StockSlipCdDtl == 2)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;                    // 変更可能ステータス
                    }
                    else
                    {
                        row.EditStatus = ctEDITSTATUS_AllOK;                            // 変更可能ステータス
                    }

                    int sign = (row.StockSlipCdDtl == 2) ? -1 : 1;
                    row.StockCountDisplay = stockCount * sign;
                    sign = (this._stockSlip.SupplierSlipCd == 20) ? -1 : 1;
                    row.StockCount = row.StockCountDisplay * sign;
                    row.OrderCnt = row.StockCount;

                    row.OrderRemainCnt = (this._stockSlip.SupplierFormal == 0) ? 0 : row.StockCountDisplay;

                    // 在庫情報
                    if (stock != null)
                    {
                        this.CacheStockInfo(stock);

                        row.WarehouseCode = stock.WarehouseCode.Trim();
                        row.WarehouseName = stock.WarehouseName;
                        row.WarehouseShelfNo = stock.WarehouseShelfNo;
                    }
                    else
                    {
                        row.ShipmentPosCnt = 0;
                        row.ShipmentPosCntDisplay = row.ShipmentPosCnt;
                    }

                    // メモ設定
                    row.SlipMemo1 = initData.SlipMemo1;
                    row.SlipMemo2 = initData.SlipMemo2;
                    row.SlipMemo3 = initData.SlipMemo3;
                    row.InsideMemo1 = initData.InsideMemo1;
                    row.InsideMemo2 = initData.InsideMemo2;
                    row.InsideMemo3 = initData.InsideMemo3;

                    // 品番、メーカーが入っている場合は単価算出モジュールで原価計算
                    if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                    {
                        this.StockDetailRowGoodsPriceSetting(row, goodsUnitData);
                    }

                    // 商品情報キャッシュ
                    this.CacheGoodsUnitData(goodsUnitData);
                }
            }

            // セット親商品の場合は子商品行をクリアする
            if (deleteRowNoList.Count > 0)
            {
                this.DeleteStockDetailRow(deleteRowNoList, true);
            }
        }
        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<

    }
    // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
    /// <summary>
    /// エラークラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : エラークラス</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2020/06/22</br>
    /// </remarks>
    public class ErrTxtgetWork 
    {
        /// <summary>受注番号</summary>
        private string _acceptAnOrderNo = "";

        /// <summary>部品コード</summary>
        private string _goodsCode = "";

        /// <summary>出荷数量①</summary>
        private string _shipmentCnt1 = "";

        /// <summary>受注単価</summary>
        private string _acceptAnOrderUnCst = "";

        /// <summary>環境(システム)日付（YYYYMMDD）</summary>
        private string _sysDate = "";

        /// <summary>仕入先コード</summary>
        private string _supplierCd = "";

        /// <summary>仕入伝票番号</summary>
        private string _supplierSlipNo = "";

        /// <summary>品番</summary>
        private string _goodsNo = "";

        /// <summary>エラーメッセージ</summary>
        private List<string> errormessage;

        /// <summary>エラーメッセージ</summary>
        public List<string> Errormessage
        {
            get { return errormessage; }
            set { errormessage = value; }
        }

        /// <summary>受注番号プロパティ</summary>
        public string AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// <summary>部品コードプロパティ</summary>
        public string GoodsCode
        {
            get { return _goodsCode; }
            set { _goodsCode = value; }
        }

        /// <summary>出荷数量①プロパティ</summary>
        public string ShipmentCnt1
        {
            get { return _shipmentCnt1; }
            set { _shipmentCnt1 = value; }
        }

        /// <summary>受注単価プロパティ</summary>
        public string AcceptAnOrderUnCst
        {
            get { return _acceptAnOrderUnCst; }
            set { _acceptAnOrderUnCst = value; }
        }

        /// <summary>環境(システム)日付（YYYYMMDD）プロパティ</summary>
        public string SysDate
        {
            get { return _sysDate; }
            set { _sysDate = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

    }
    // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<
}
	