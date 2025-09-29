//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫分析順位表
// プログラム概要   : 在庫分析順位表で使用する抽出条件の定義
//----------------------------------------------------------------------------//
//                (c)Copyright  2006 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 作 成 日  2007/09/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/02  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/27  修正内容 : 不具合対応[12783]
//----------------------------------------------------------------------------//
using System;
using System.Collections;
 
namespace Broadleaf.Application.UIData
{
	/// public class name:   StockShipArrivalListCndtn
	/// <summary>
	///                      在庫分析順位表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫分析順位表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/09/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/10/02 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>                 :   2009/03/27 照田 貴志　不具合対応[12783]</br>
    /// </remarks>
	public class StockAnalysisOrderListCndtn
    {
        # region ■ private field ■

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>開始年月度</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了年月度</summary>
		/// <remarks>YYYYMM</remarks>
        private DateTime _ed_AddUpYearMonth;

		/// <summary>拠点コード</summary>
		/// <remarks>（配列）</remarks>
		private string[] _sectionCodes = new string[0];

		/// <summary>開始倉庫コード</summary>
		private string _st_WarehouseCode = "";

		/// <summary>終了倉庫コード</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>開始仕入先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了仕入先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>開始商品メーカーコード</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>終了商品メーカーコード</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>開始商品区分グループコード</summary>
		private string _st_LargeGoodsGanreCode = "";

		/// <summary>終了商品区分グループコード</summary>
		private string _ed_LargeGoodsGanreCode = "";

		/// <summary>開始商品区分コード</summary>
		private string _st_MediumGoodsGanreCode = "";

		/// <summary>終了商品区分コード</summary>
		private string _ed_MediumGoodsGanreCode = "";

		/// <summary>開始商品区分詳細コード</summary>
		private string _st_DetailGoodsGanreCode = "";

		/// <summary>終了商品区分詳細コード</summary>
		private string _ed_DetailGoodsGanreCode = "";

		/// <summary>開始自社分類コード</summary>
		private Int32 _st_EnterpriseGanreCode;

		/// <summary>終了自社分類コード</summary>
		private Int32 _ed_EnterpriseGanreCode;

		/// <summary>開始ＢＬ商品コード</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>終了ＢＬ商品コード</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>開始商品番号</summary>
		private string _st_GoodsNo = "";

		/// <summary>終了商品番号</summary>
		private string _ed_GoodsNo = "";

		/// <summary>開始倉庫棚番</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>終了倉庫棚番</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>印刷タイプ</summary>
		/// <remarks>0:出荷＆入荷, 1:出荷, 2:入荷</remarks>
		private Int32 _shipArrivalPrintDiv;

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockCreateDate;

		/// <summary>在庫登録日指定区分</summary>
		/// <remarks>0:以前, 1:以降</remarks>
        private StockCreateDateDivState _stockCreateDateDiv;

		/// <summary>開始出荷数</summary>
		/// <remarks>(以上)</remarks>
        //private Int32 _st_ShipmentCnt;        //DEL 2008/10/02　Int→Double
        private Double _st_ShipmentCnt;         //ADD 2008/10/02

		/// <summary>終了出荷数</summary>
		/// <remarks>(以下)</remarks>
        //private Int32 _ed_ShipmentCnt;        //DEL 2008/10/02 Int→Double
        private Double _ed_ShipmentCnt;         //ADD 2008/10/02

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        //--- ADD 2008/07/22 ---------->>>>>
        /// <summary>部品管理区分１</summary>
        private string[] _partsManagementDivide1 = new string[0];

        /// <summary>部品管理区分２</summary>
        private string[] _partsManagementDivide2 = new string[0];
        //--- ADD 2008/07/22 ----------<<<<<

        # endregion  ■ private field ■

        # region ■ public propaty ■

		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始年月度プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始年月度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了年月度プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了年月度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コードプロパティ</summary>
		/// <value>（配列）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_WarehouseCode
		/// <summary>開始倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>終了倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>開始商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>終了商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_LargeGoodsGanreCode
		/// <summary>開始商品区分グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品区分グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_LargeGoodsGanreCode
		{
			get{return _st_LargeGoodsGanreCode;}
			set{_st_LargeGoodsGanreCode = value;}
		}

		/// public propaty name  :  Ed_LargeGoodsGanreCode
		/// <summary>終了商品区分グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品区分グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_LargeGoodsGanreCode
		{
			get{return _ed_LargeGoodsGanreCode;}
			set{_ed_LargeGoodsGanreCode = value;}
		}

		/// public propaty name  :  St_MediumGoodsGanreCode
		/// <summary>開始商品区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_MediumGoodsGanreCode
		{
			get{return _st_MediumGoodsGanreCode;}
			set{_st_MediumGoodsGanreCode = value;}
		}

		/// public propaty name  :  Ed_MediumGoodsGanreCode
		/// <summary>終了商品区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_MediumGoodsGanreCode
		{
			get{return _ed_MediumGoodsGanreCode;}
			set{_ed_MediumGoodsGanreCode = value;}
		}

		/// public propaty name  :  St_DetailGoodsGanreCode
		/// <summary>開始商品区分詳細コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品区分詳細コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_DetailGoodsGanreCode
		{
			get{return _st_DetailGoodsGanreCode;}
			set{_st_DetailGoodsGanreCode = value;}
		}

		/// public propaty name  :  Ed_DetailGoodsGanreCode
		/// <summary>終了商品区分詳細コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品区分詳細コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_DetailGoodsGanreCode
		{
			get{return _ed_DetailGoodsGanreCode;}
			set{_ed_DetailGoodsGanreCode = value;}
		}

		/// public propaty name  :  St_EnterpriseGanreCode
		/// <summary>開始自社分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_EnterpriseGanreCode
		{
			get{return _st_EnterpriseGanreCode;}
			set{_st_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  Ed_EnterpriseGanreCode
		/// <summary>終了自社分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_EnterpriseGanreCode
		{
			get{return _ed_EnterpriseGanreCode;}
			set{_ed_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>開始ＢＬ商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始ＢＬ商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>終了ＢＬ商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了ＢＬ商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_BLGoodsCode
		{
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>開始商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>終了商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>開始倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>終了倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  ShipArrivalPrintDiv
		/// <summary>印刷タイププロパティ</summary>
		/// <value>0:出荷＆入荷, 1:出荷, 2:入荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipArrivalPrintDiv
		{
			get{return _shipArrivalPrintDiv;}
			set{_shipArrivalPrintDiv = value;}
		}

		/// public propaty name  :  StockCreateDate
		/// <summary>在庫登録日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime StockCreateDate
		{
			get{return _stockCreateDate;}
			set{_stockCreateDate = value;}
		}

		/// public propaty name  :  StockCreateDateDiv
		/// <summary>在庫登録日指定区分プロパティ</summary>
		/// <value>0:以前, 1:以降 ()</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public StockCreateDateDivState StockCreateDateDiv
		{
			get{return _stockCreateDateDiv;}
			set{_stockCreateDateDiv = value;}
		}

		/// public propaty name  :  St_ShipmentCnt
		/// <summary>開始出荷数プロパティ</summary>
		/// <value>(以上)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        //public Int32 St_ShipmentCnt       //DEL 2008/10/02 Int→Double
		public Double St_ShipmentCnt        //ADD 2008/10/02
		{
			get{return _st_ShipmentCnt;}
			set{_st_ShipmentCnt = value;}
		}

		/// public propaty name  :  Ed_ShipmentCnt
		/// <summary>終了出荷数プロパティ</summary>
		/// <value>(以下)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        //public Int32 Ed_ShipmentCnt       //DEL 2008/10/02 Int→Double
		public Double Ed_ShipmentCnt        //ADD 2008/10/02
		{
			get{return _ed_ShipmentCnt;}
			set{_ed_ShipmentCnt = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

        //--- ADD 2008/07/22 ---------->>>>>
        /// public propaty name  :  PartsManagementDivide1
        /// <summary>部品管理区分１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] PartsManagementDivide1
        {
            get { return _partsManagementDivide1; }
            set { _partsManagementDivide1 = value; }
        }

        /// public propaty name  :  PartsManagementDivide2
        /// <summary>部品管理区分２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] PartsManagementDivide2
        {
            get { return _partsManagementDivide2; }
            set { _partsManagementDivide2 = value; }
        }
        //--- ADD 2008/07/22 ----------<<<<<

        # endregion ■ public propaty ■

        # region ■ private field (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;
        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;
        /// <summary>
        /// 順位区分
        /// </summary>
        private StockOrderDivState _stockOrderDiv = StockOrderDivState.High;
        /// <summary>
        /// 印刷タイプ
        /// </summary>
        private OrderPrintTypeState _OrderPrintType = OrderPrintTypeState.SalesMoneyTaxExcOrder;
        /// <summary>
        /// 金額単位
        /// </summary>
        private MoneyUnitState _moneyUnit = MoneyUnitState.One;

        /// <summary>
        /// 順位Max
        /// </summary>
        private int _stockOrderMax = 9999;

        /// <summary>
        /// 改ページ区分
        /// </summary>
        private NewPageDivState _newPageDiv = NewPageDivState.ByWarehouse;

        /// <summary>
        /// 印刷タイプ
        /// </summary>
        private PrintTypeDivState _printTypeDiv = PrintTypeDivState.ByWarehouse;

        # endregion ■ private field (自動生成以外) ■

        # region ■ public propaty (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }
        /// <summary>
        /// 順位区分　プロパティ
        /// </summary>
        public StockOrderDivState StockOrderDiv
        {
            get { return this._stockOrderDiv; }
            set { this._stockOrderDiv = value; }
        }
        /// <summary>
        /// 印刷タイプ　プロパティ
        /// </summary>
        public OrderPrintTypeState OrderPrintType
        {
            get { return this._OrderPrintType; }
            set { this._OrderPrintType = value; }
        }
        /// <summary>
        /// 金額単位　プロパティ
        /// </summary>
        public MoneyUnitState MoneyUnit
        {
            get { return this._moneyUnit; }
            set { this._moneyUnit = value; }
        }
        /// <summary>
        /// 順位Max　プロパティ
        /// </summary>
        public int StockOrderMax
        {
            get { return this._stockOrderMax; }
            set { this._stockOrderMax = value; }
        }
        /// <summary>
        /// 改ページ区分　プロパティ
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }
        /// <summary>
        /// 印刷タイプ　プロパティ
        /// </summary>
        public PrintTypeDivState PrintTypeDiv
        {
            get { return this._printTypeDiv; }
            set { this._printTypeDiv = value; }
        }
        /// <summary>
        /// 出力順位区分タイトル　プロパティ
        /// </summary>
        public string StockOrderDivStateTitle
        {
            get {
                switch (this._stockOrderDiv) {
                    case StockOrderDivState.High : return ct_StockOrderDivState_High;
                    case StockOrderDivState.Low : return ct_StockOrderDivState_Low;
                    default : return "";
                }
            }
        }
        /// <summary>
        /// 印刷タイプタイトル　プロパティ
        /// </summary>
        public string OrderPrintTypeStateTitle
        {
            get {
                switch (this._OrderPrintType) {
                    case OrderPrintTypeState.SalesMoneyTaxExcOrder : return ct_OrderPrintTypeState_SalesMoneyTaxExcOrder;
                    case OrderPrintTypeState.GrossProfitOrder : return ct_OrderPrintTypeState_GrossProfitOrder;
                    case OrderPrintTypeState.ShipmentCntOrder : return ct_OrderPrintTypeState_ShipmentCntOrder;
                    default : return "";
                }
            }
        }
        /// <summary>
        /// 金額単位タイトル　プロパティ
        /// </summary>
        public string MoneyUnitStateTitle
        {
            get {
                switch (this._moneyUnit) {
                    case MoneyUnitState.One : return ct_MoneyUnitState_One;
                    case MoneyUnitState.Thousand : return ct_MoneyUnitState_Thousand;
                    case MoneyUnitState.TenThousand : return ct_MoneyUnitState_TenThousand;
                    default : return "";
                }
            }
        }
        # endregion ■ public propaty (自動生成以外) ■

        # region ■ public Enum (自動生成以外) ■
        /// <summary>
        /// 在庫登録日指定区分　列挙体
        /// </summary>
        public enum StockCreateDateDivState
        {
            /// <summary>指定日 以前</summary>
            Before = 0,
            /// <summary>指定日 以後</summary>
            After = 1,
        }
        /// <summary>
        /// 順位区分　列挙体
        /// </summary>
        public enum StockOrderDivState
        {
            /// <summary>上位</summary>
            High = 0,
            /// <summary>下位</summary>
            Low = 1,
        }
        /// <summary>
        /// 印刷タイプ　列挙体
        /// </summary>
        public enum OrderPrintTypeState
        {
            /// <summary>売上金額順</summary>
            SalesMoneyTaxExcOrder = 0,
            /// <summary>粗利額順</summary>
            GrossProfitOrder = 1,
            /// <summary>出荷数順</summary>
            ShipmentCntOrder = 2,
        }
        /// <summary>
        /// 金額単位　列挙体
        /// </summary>
        public enum MoneyUnitState
        {
            /// <summary>円</summary>
            One = 0,
            /// <summary>千円</summary>
            Thousand = 1,
            /// <summary>万円</summary>
            TenThousand = 2,
        }
        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>倉庫毎</summary>
            ByWarehouse = 0,
            /// <summary>しない</summary>
            None = 1,
        }
        /// <summary>
        /// 印刷タイプ　列挙体
        /// </summary>
        public enum PrintTypeDivState
        {
            /// <summary>倉庫別</summary>
            ByWarehouse = 0,
            /// <summary>全社計</summary>
            Total = 1,
        }
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        /// <summary>在庫登録日指定区分　以前</summary>
        public const string ct_StockCreateDateDivState_Before = "以前";
        /// <summary>在庫登録日指定区分　以後</summary>
        public const string ct_StockCreateDateDivState_After = "以後";

        /// <summary>順位区分　上位</summary>
        public const string ct_StockOrderDivState_High = "上位";
        /// <summary>順位区分　下位</summary>
        public const string ct_StockOrderDivState_Low = "下位";

        /* ---DEL 2009/03/27 不具合対応[12783] --------------------------------->>>>>
        /// <summary>印刷タイプ　売上金額順</summary>
        public const string ct_OrderPrintTypeState_SalesMoneyTaxExcOrder = "売上金額";
        /// <summary>印刷タイプ　粗利額順</summary>
        public const string ct_OrderPrintTypeState_GrossProfitOrder = "粗利額";
        /// <summary>印刷タイプ　出荷数順</summary>
        public const string ct_OrderPrintTypeState_ShipmentCntOrder = "出荷数";
           ---DEL 2009/03/27 不具合対応[12783] ---------------------------------<<<<< */
        // ---ADD 2009/03/27 不具合対応[12783] --------------------------------->>>>>
        /// <summary>印刷タイプ　売上金額順</summary>
        public const string ct_OrderPrintTypeState_SalesMoneyTaxExcOrder = "売上金額順";
        /// <summary>印刷タイプ　粗利額順</summary>
        public const string ct_OrderPrintTypeState_GrossProfitOrder = "粗利額順";
        /// <summary>印刷タイプ　出荷数順</summary>
        public const string ct_OrderPrintTypeState_ShipmentCntOrder = "出荷数順";
        // ---ADD 2009/03/27 不具合対応[12783] ---------------------------------<<<<<

        /// <summary>金額単位　円</summary>
        public const string ct_MoneyUnitState_One = "円";
        /// <summary>金額単位　千円</summary>
        public const string ct_MoneyUnitState_Thousand = "千円";
        /// <summary>金額単位　万円</summary>
        public const string ct_MoneyUnitState_TenThousand = "万円";
        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 在庫分析順位表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>StockAnalysisOrderListCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAnalysisOrderListCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockAnalysisOrderListCndtn ()
        {
        }
        # endregion ■ Constructor ■
    }
}
