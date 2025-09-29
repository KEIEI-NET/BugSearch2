using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockShipArrivalListCndtn
	/// <summary>
	///                      在庫入出荷一覧表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫入出荷一覧表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/09/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/03/18 照田 貴志　不具合対応[12540]</br>
	/// </remarks>
	public class StockShipArrivalListCndtn
    {
        # region ■ private field ■

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>開始年月度</summary>
		/// <remarks>YYYYMM00</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了年月度</summary>
		/// <remarks>YYYYMM00</remarks>
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
        private ShipArrivalPrintDivState _shipArrivalPrintDiv;

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;

		/// <summary>在庫登録日指定区分</summary>
		/// <remarks>0:以前, 1:以降 ()</remarks>
        private StockCreateDateDivState _stockCreateDateDiv;

		/// <summary>出荷数指定区分</summary>
		/// <remarks>0:出荷or入荷, 1:出荷, 2:入荷</remarks>
        private ShipArrivalCntDivState _shipArrivalCntDiv;

		/// <summary>開始入出荷数</summary>
		/// <remarks>(以上)</remarks>
		private Int32 _st_ShipArrivalCnt;

		/// <summary>終了入出荷数</summary>
		/// <remarks>(以下)</remarks>
		private Int32 _ed_ShipArrivalCnt;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

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
		/// <value>YYYYMM00</value>
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
		/// <value>YYYYMM00</value>
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
        public ShipArrivalPrintDivState ShipArrivalPrintDiv
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

		/// public propaty name  :  ShipArrivalCntDiv
		/// <summary>出荷数指定区分プロパティ</summary>
		/// <value>0:出荷or入荷, 1:出荷, 2:入荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷数指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ShipArrivalCntDivState ShipArrivalCntDiv
		{
			get{return _shipArrivalCntDiv;}
			set{_shipArrivalCntDiv = value;}
		}

		/// public propaty name  :  St_ShipArrivalCnt
		/// <summary>開始入出荷数プロパティ</summary>
		/// <value>(以上)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_ShipArrivalCnt
		{
			get{return _st_ShipArrivalCnt;}
			set{_st_ShipArrivalCnt = value;}
		}

		/// public propaty name  :  Ed_ShipArrivalCnt
		/// <summary>終了入出荷数プロパティ</summary>
		/// <value>(以下)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_ShipArrivalCnt
		{
			get{return _ed_ShipArrivalCnt;}
			set{_ed_ShipArrivalCnt = value;}
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
        /// 印刷有無　倉庫計
        /// </summary>
        private SummaryPrintDivState _warehouseSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　仕入先計
        /// </summary>
        private SummaryPrintDivState _supplierSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　メーカー計
        /// </summary>
        private SummaryPrintDivState _goodsMakerSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　商品区分グループ計
        /// </summary>
        private SummaryPrintDivState _largeGoodsGanreSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　商品区分計
        /// </summary>
        private SummaryPrintDivState _mediumGoodsGanreSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　商品区分詳細計
        /// </summary>
        private SummaryPrintDivState _detailGoodsGanreSummaryPrintDiv = SummaryPrintDivState.Print;

        // ---ADD 2009/03/18 不具合対応[12540] ---------------------------->>>>>
        /// <summary>
        /// 改ページ区分
        /// </summary>
        private NewPageDivState _newPageDiv;
        // ---ADD 2009/03/18 不具合対応[12540] ----------------------------<<<<<
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
        /// 印刷タイプタイトル　プロパティ
        /// </summary>
        public string ShipArrivalPrintDivTitle
        {
            get {
                switch (this._shipArrivalPrintDiv) {
                    case ShipArrivalPrintDivState.ShipArrival : return ct_ShipArrivalPrintDivState_ShipArrival; 
                    case ShipArrivalPrintDivState.Shipment    : return ct_ShipArrivalPrintDivState_Shipment; 
                    case ShipArrivalPrintDivState.Arrival     : return ct_ShipArrivalPrintDivState_Arrival;
                    default : return "";
                }
            }
        }
        /// <summary>
        /// 在庫登録日指定区分タイトル　プロパティ
        /// </summary>
        public string StockCreateDateDivTitle
        {
            get {
                switch (this._stockCreateDateDiv) {
                    case StockCreateDateDivState.Before : return ct_StockCreateDateDivState_Before;
                    case StockCreateDateDivState.After: return ct_StockCreateDateDivState_After;
                    default: return "";
                }
            }
        }
        /// <summary>
        /// 出荷数指定区分タイトル　プロパティ
        /// </summary>
        public string ShipArrivalCntDivTitle
        {
            get {
                switch (this._shipArrivalCntDiv) {
                    case ShipArrivalCntDivState.ShipArrival : return ct_ShipArrivalCntDivState_ShipArrival;
                    case ShipArrivalCntDivState.Shipment : return ct_ShipArrivalCntDivState_Shipment;
                    case ShipArrivalCntDivState.Arrival : return ct_ShipArrivalCntDivState_Arrival;
                    default : return "";
                }
            }
        }

        // ---ADD 2009/03/18 不具合対応[12540] --------------------------------------------->>>>>
        /// <summary>
        /// 改ページ区分　名称取得プロパティ
        /// </summary>
        public string NewPageDivStateTitle
        {
            get
            {
                switch (this._newPageDiv)
                {
                    case NewPageDivState.EachSummaly: return ct_NewPageDivState_EachSummaly;
                    case NewPageDivState.None: return ct_NewPageDivState_None;
                    default: return string.Empty;
                }
            }
        }
        // ---ADD 2009/03/18 不具合対応[12540] ---------------------------------------------<<<<<

        /// <summary>
        /// 印刷有無　倉庫計
        /// </summary>
        public SummaryPrintDivState WarehouseSummaryPrintDiv
        {
            get { return this._warehouseSummaryPrintDiv; }
            set { this._warehouseSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　仕入先計
        /// </summary>
        public SummaryPrintDivState SupplierSummaryPrintDiv
        {
            get { return this._supplierSummaryPrintDiv; }
            set { this._supplierSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　メーカー計
        /// </summary>
        public SummaryPrintDivState GoodsMakerSummaryPrintDiv
        {
            get { return this._goodsMakerSummaryPrintDiv; }
            set { this._goodsMakerSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　商品区分グループ計
        /// </summary>
        public SummaryPrintDivState LargeGoodsGanreSummaryPrintDiv
        {
            get { return this._largeGoodsGanreSummaryPrintDiv; }
            set { this._largeGoodsGanreSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　商品区分計
        /// </summary>
        public SummaryPrintDivState MediumGoodsGanreSummaryPrintDiv
        {
            get { return this._mediumGoodsGanreSummaryPrintDiv; }
            set { this._mediumGoodsGanreSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　商品区分詳細計
        /// </summary>
        public SummaryPrintDivState DetailGoodsGanreSummaryPrintDiv
        {
            get { return this._detailGoodsGanreSummaryPrintDiv; }
            set { this._detailGoodsGanreSummaryPrintDiv = value; }
        }
        // ---ADD 2009/03/18 不具合対応[12540] ------------------------>>>>>
        /// <summary>
        /// 改ページ区分　プロパティ
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }
        // ---ADD 2009/03/18 不具合対応[12540] ------------------------<<<<<
        # endregion ■ public propaty (自動生成以外) ■

        # region ■ public Enum (自動生成以外) ■
        /// <summary>
        /// 印刷タイプ　列挙体
        /// </summary>
        public enum ShipArrivalPrintDivState
        {
            /// <summary>出荷＆入荷</summary>
            ShipArrival = 0,
            /// <summary>出荷</summary>
            Shipment = 1,
            /// <summary>入荷</summary>
            Arrival = 2,
        }
        /// <summary>
        /// 在庫登録日指定区分　列挙体
        /// </summary>
        public enum StockCreateDateDivState
        {
            /// <summary>指定日 以前</summary>
            Before = 0,
            /// <summary>指定日 以降</summary>
            After = 1,
        }
        /// <summary>
        /// 出荷数指定区分
        /// </summary>
        public enum ShipArrivalCntDivState
        {
            /// <summary>出荷or入荷</summary>
            ShipArrival = 0,
            /// <summary>出荷</summary>
            Shipment = 1,
            /// <summary>入荷</summary>
            Arrival = 2,
        }
        /// <summary>
        /// 合計印字区分　列挙体
        /// </summary>
        public enum SummaryPrintDivState
        {
            /// <summary>印字しない</summary>
            None = 0,
            /// <summary>印字する</summary>
            Print = 1,
        }
        // ---ADD 2009/03/18 不具合対応[12540] ------------------------------------>>>>>
        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>小計毎</summary>
            EachSummaly = 0,
            /// <summary>しない</summary>
            None = 1,
        }
        // ---ADD 2009/03/18 不具合対応[12540] ------------------------------------<<<<<
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        /// <summary>印刷タイプ　出荷＆入荷</summary>
        public const string ct_ShipArrivalPrintDivState_ShipArrival = "出荷＆入荷";
        /// <summary>印刷タイプ　出荷</summary>
        public const string ct_ShipArrivalPrintDivState_Shipment = "出荷";
        /// <summary>印刷タイプ　入荷</summary>
        public const string ct_ShipArrivalPrintDivState_Arrival = "入荷";

        /// <summary>在庫登録日指定区分　以前</summary>
        public const string ct_StockCreateDateDivState_Before = "以前";
        /// <summary>在庫登録日指定区分　以後</summary>
        public const string ct_StockCreateDateDivState_After = "以後";

        /// <summary>出荷数指定区分　出荷or入荷</summary>
        public const string ct_ShipArrivalCntDivState_ShipArrival = "出荷or入荷";
        /// <summary>出荷数指定区分　出荷</summary>
        public const string ct_ShipArrivalCntDivState_Shipment = "出荷";
        /// <summary>出荷数指定区分　入荷</summary>
        public const string ct_ShipArrivalCntDivState_Arrival = "入荷";

        // ---ADD 2009/03/18 不具合対応[12540] ------------------------------------>>>>>
        /// <summary>改ページ区分　倉庫毎</summary>
        public const string ct_NewPageDivState_EachSummaly = "小計毎";
        /// <summary>改ページ区分　印刷しない</summary>
        public const string ct_NewPageDivState_None = "印刷しない";
        // ---ADD 2009/03/18 不具合対応[12540] ------------------------------------<<<<<
        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 在庫入出荷一覧表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>StockShipArrivalListCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockShipArrivalListCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockShipArrivalListCndtn ()
        {
        }
        # endregion ■ Constructor ■
    }
}
