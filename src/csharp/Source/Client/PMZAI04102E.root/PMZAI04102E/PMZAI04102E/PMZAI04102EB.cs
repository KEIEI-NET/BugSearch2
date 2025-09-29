using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockHistoryDspSearchResultWork
	/// <summary>
	///                      在庫実績照会抽出結果ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫実績照会抽出結果ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/07/20 王増喜 テキスト出力対応</br>
	/// </remarks>
	[Serializable]
	public class StockHistoryDspSearchResult
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

        /// <summary>計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// <summary>棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>BLコード</summary>
        private Int32 _blGoodsCode;
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

		/// <summary>商品番号</summary>
        private string _goodsNo = "";

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// <summary>商品名称</summary>
        private string _goodsName = "";
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>売上回数</summary>
		private Int32 _salesTimes;

		/// <summary>売上数</summary>
		private Double _salesCount;

		/// <summary>売上金額（税抜き）</summary>
		private Int64 _salesMoneyTaxExc;

        /// <summary>売上平均</summary>
		private Double _salesMoneyAvg;

		/// <summary>仕入回数</summary>
		private Int32 _stockTimes;

		/// <summary>仕入数</summary>
		private Double _stockCount;

		/// <summary>仕入金額（税抜き）</summary>
		private Int64 _stockPriceTaxExc;

        /// <summary>仕入平均（税抜き）</summary>
		private Double _stockPriceAvg;

		/// <summary>粗利金額</summary>
		private Int64 _grossProfit;

		/// <summary>移動入荷数</summary>
		private Double _moveArrivalCnt;

		/// <summary>移動入荷額</summary>
		private Int64 _moveArrivalPrice;

		/// <summary>移動出荷数</summary>
		private Double _moveShipmentCnt;

		/// <summary>移動出荷額</summary>
		private Int64 _moveShipmentPrice;

		/// <summary>在庫発注先コード</summary>
		private Int32 _stockSupplierCode;

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockCreateDate;

		/// <summary>最終売上日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastSalesDate;

		/// <summary>最終仕入年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastStockDate;

        /// <summary>検索区分</summary>
        private Int32 _searchDiv;

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


		/// public propaty name  :  AddUpYearMonth
		/// <summary>計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
        }

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// public propaty name  :  WarehouseShelfCode
        /// <summary>棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  BlGoodsCode
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
        }

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  SalesTimes
		/// <summary>売上回数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上回数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesTimes
		{
			get{return _salesTimes;}
			set{_salesTimes = value;}
		}

		/// public propaty name  :  SalesCount
		/// <summary>売上数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesCount
		{
			get{return _salesCount;}
			set{_salesCount = value;}
		}

		/// public propaty name  :  SalesMoneyTaxExc
		/// <summary>売上金額（税抜き）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesMoneyTaxExc
		{
			get{return _salesMoneyTaxExc;}
			set{_salesMoneyTaxExc = value;}
		}

        /// public propaty name  :  SalesMoneyAvg
		/// <summary>売上平均プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上平均プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesMoneyAvg
		{
			get{return _salesMoneyAvg;}
			set{_salesMoneyAvg = value;}
		}

		/// public propaty name  :  StockTimes
		/// <summary>仕入回数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入回数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockTimes
		{
			get{return _stockTimes;}
			set{_stockTimes = value;}
		}

		/// public propaty name  :  StockCount
		/// <summary>仕入数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockCount
		{
			get{return _stockCount;}
			set{_stockCount = value;}
		}

		/// public propaty name  :  StockPriceTaxExc
		/// <summary>仕入金額（税抜き）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceTaxExc
		{
			get{return _stockPriceTaxExc;}
			set{_stockPriceTaxExc = value;}
		}

        /// public propaty name  :  StockPriceTaxExc
		/// <summary>仕入平均プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入平均プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockPriceAvg
		{
			get{return _stockPriceAvg;}
			set{_stockPriceAvg = value;}
		}

		/// public propaty name  :  GrossProfit
		/// <summary>粗利金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 GrossProfit
		{
			get{return _grossProfit;}
			set{_grossProfit = value;}
		}

		/// public propaty name  :  MoveArrivalCnt
		/// <summary>移動入荷数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動入荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double MoveArrivalCnt
		{
			get{return _moveArrivalCnt;}
			set{_moveArrivalCnt = value;}
		}

		/// public propaty name  :  MoveArrivalPrice
		/// <summary>移動入荷額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動入荷額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 MoveArrivalPrice
		{
			get{return _moveArrivalPrice;}
			set{_moveArrivalPrice = value;}
		}

		/// public propaty name  :  MoveShipmentCnt
		/// <summary>移動出荷数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double MoveShipmentCnt
		{
			get{return _moveShipmentCnt;}
			set{_moveShipmentCnt = value;}
		}

		/// public propaty name  :  MoveShipmentPrice
		/// <summary>移動出荷額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動出荷額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 MoveShipmentPrice
		{
			get{return _moveShipmentPrice;}
			set{_moveShipmentPrice = value;}
		}

		/// public propaty name  :  StockSupplierCode
		/// <summary>在庫発注先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockSupplierCode
		{
			get{return _stockSupplierCode;}
			set{_stockSupplierCode = value;}
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

		/// public propaty name  :  LastSalesDate
		/// <summary>最終売上日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終売上日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastSalesDate
		{
			get{return _lastSalesDate;}
			set{_lastSalesDate = value;}
		}

		/// public propaty name  :  LastStockDate
		/// <summary>最終仕入年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終仕入年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastStockDate
		{
			get{return _lastStockDate;}
			set{_lastStockDate = value;}
		}

        /// public propaty name  :  SearchDiv
        /// <summary>検索区分プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }


		/// <summary>
		/// 在庫実績照会抽出結果ワークコンストラクタ
		/// </summary>
        /// <returns>StockHistoryDspSearchResultクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryDspSearchResultクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockHistoryDspSearchResult()
		{
		}

	

        /// <summary>
        /// 在庫実績照会データコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="rsltTtlDivCd">実績集計区分(0:部品合計 1:在庫 2:純正 3:作業)</param>
        /// <param name="salesTimes">売上回数(出荷回数(売上時のみ）)</param>
        /// <param name="salesMoney">売上金額(税抜き（値引,返品含まず）)</param>
        /// <param name="grossProfit">粗利金額</param>
        /// <returns>StockHistoryDspSearchResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryDspSearchResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockHistoryDspSearchResult(string enterpriseCode, DateTime addUpYearMonth, string warehouseCode, string warehouseShelfNo, Int32 blGoodsCode, string goodsNo, string goodsName, Int32 goodsMakerCd,
            Int32 salesTimes, Double salesCount, Int64 salesMoneyTaxExc, Double salesMoneyAvg, Int32 stockTimes, Double stockCount, Int64 stockPriceTaxExc,
            Double stockPriceAvg, Int64 grossProfit, Double moveArrivalCnt,Int64 moveArrivalPrice, Double moveShipmentCnt, Int64 moveShipmentPrice,
            Int32 stockSupplierCode, DateTime stockCreateDate, DateTime lastSalesDate, DateTime lastStockDate, Int32 searchDiv)
        {
            this._enterpriseCode = enterpriseCode;
            this._addUpYearMonth = addUpYearMonth;
            this._warehouseCode = warehouseCode;
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            this._warehouseShelfNo = warehouseShelfNo;
            this._blGoodsCode = blGoodsCode;
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            this._goodsNo = goodsNo;
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            this._goodsName = GoodsName;
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            this._goodsMakerCd = goodsMakerCd;
            this._salesTimes = salesTimes;
            this._salesCount = salesCount;
            this._salesMoneyTaxExc = salesMoneyTaxExc;
            this._salesMoneyAvg = salesMoneyAvg;
            this._stockTimes = stockTimes;
            this._stockCount = stockCount;
            this._stockPriceTaxExc = stockPriceTaxExc;
            this._stockPriceAvg = stockPriceAvg;
            this._grossProfit = grossProfit;
            this._moveArrivalCnt = moveArrivalCnt;
            this._moveArrivalPrice = moveArrivalPrice;
            this._moveShipmentCnt = moveShipmentCnt;
            this._moveShipmentPrice = moveShipmentPrice;
            this._stockSupplierCode = stockSupplierCode;
            this._stockCreateDate = stockCreateDate;
            this._lastSalesDate = lastSalesDate;
            this._lastStockDate = lastStockDate;
            this._searchDiv = SearchDiv;
        }

        /// <summary>
        /// 在庫実績照会データ複製処理
        /// </summary>
        /// <returns>StockHistoryDspSearchResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockHistoryDspSearchResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockHistoryDspSearchResult Clone()
        {
            return new StockHistoryDspSearchResult(this._enterpriseCode, this._addUpYearMonth, this._warehouseCode, 
                            this._warehouseShelfNo, this._blGoodsCode, this._goodsNo, this._goodsName,
                            this._goodsMakerCd, this._salesTimes, this._salesCount, this._salesMoneyTaxExc, this._salesMoneyAvg,
                            this._stockTimes, this._stockCount, this._stockPriceTaxExc, this._stockPriceAvg, this._grossProfit, 
                            this._moveArrivalCnt, this._moveArrivalPrice, this._moveShipmentCnt, this._moveShipmentPrice, 
                            this._stockSupplierCode, this._stockCreateDate, this._lastSalesDate, this._lastStockDate, this._searchDiv);
        }

        /// <summary>
        /// 在庫実績照会データ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockHistoryDspSearchResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockHistoryDspSearchResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.WarehouseCode == target.WarehouseCode)
                 // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.BlGoodsCode == target.BlGoodsCode)
                 // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
                 && (this.GoodsNo == target.GoodsNo)
                 // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
                 && (this.GoodsName == target.GoodsName)
                 // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.SalesTimes == target.SalesTimes)
                 && (this.SalesCount == target.SalesCount)
                 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
                 && (this.SalesMoneyAvg == target.SalesMoneyAvg)
                 && (this.StockTimes == target.StockTimes)
                 && (this.StockCount == target.StockCount)
                 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
                 && (this.StockPriceAvg == target.StockPriceAvg)
                 && (this.GrossProfit == target.GrossProfit)
                 && (this.MoveArrivalCnt == target.MoveArrivalCnt)
                 && (this.MoveArrivalPrice == target.MoveArrivalPrice)
                 && (this.MoveShipmentCnt == target.MoveShipmentPrice)
                 && (this.StockSupplierCode == target.StockSupplierCode)
                 && (this.StockCreateDate == target.StockCreateDate)
                 && (this.LastSalesDate == target.LastSalesDate)
                 && (this.LastStockDate == target.LastStockDate)
                 && (this.SearchDiv == target.SearchDiv));
        }

        /// <summary>
        /// 在庫実績照会集計データ比較処理
        /// </summary>
        /// <param name="ShipmentPartsDspResult">
        ///                    比較するStockHistoryDspSearchResultクラスのインスタンス
        /// </param>
        /// <param name="mTtlSalesSlip2">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryDspSearchResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockHistoryDspSearchResult mTtlStockhist1, StockHistoryDspSearchResult mTtlStockhist2)
        {
            return ((mTtlStockhist1.EnterpriseCode == mTtlStockhist2.EnterpriseCode)
                 && (mTtlStockhist1.AddUpYearMonth == mTtlStockhist2.AddUpYearMonth)
                 && (mTtlStockhist1.WarehouseCode == mTtlStockhist2.WarehouseCode)
                 // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
                 && (mTtlStockhist1.WarehouseShelfNo == mTtlStockhist2.WarehouseShelfNo)
                 && (mTtlStockhist1.BlGoodsCode == mTtlStockhist2.BlGoodsCode)
                 // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
                 && (mTtlStockhist1.GoodsNo == mTtlStockhist2.GoodsNo)
                 // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
                 && (mTtlStockhist1.GoodsName == mTtlStockhist2.GoodsName)
                 // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
                 && (mTtlStockhist1.GoodsMakerCd == mTtlStockhist2.GoodsMakerCd)
                 && (mTtlStockhist1.SalesTimes == mTtlStockhist2.SalesTimes)
                 && (mTtlStockhist1.SalesCount == mTtlStockhist2.SalesCount)
                 && (mTtlStockhist1.SalesMoneyTaxExc == mTtlStockhist2.SalesMoneyTaxExc)
                 && (mTtlStockhist1.SalesMoneyAvg == mTtlStockhist2.SalesMoneyAvg)
                 && (mTtlStockhist1.StockTimes == mTtlStockhist2.StockTimes)
                 && (mTtlStockhist1.StockCount == mTtlStockhist2.StockCount)
                 && (mTtlStockhist1.StockPriceTaxExc == mTtlStockhist2.StockPriceTaxExc)
                 && (mTtlStockhist1.StockPriceAvg == mTtlStockhist2.StockPriceAvg)
                 && (mTtlStockhist1.GrossProfit == mTtlStockhist2.GrossProfit)
                 && (mTtlStockhist1.MoveArrivalCnt == mTtlStockhist2.MoveArrivalCnt)
                 && (mTtlStockhist1.MoveArrivalPrice == mTtlStockhist2.MoveArrivalPrice)
                 && (mTtlStockhist1.MoveShipmentCnt == mTtlStockhist2.MoveShipmentCnt)
                 && (mTtlStockhist1.MoveShipmentPrice == mTtlStockhist2.MoveShipmentPrice) 
                 && (mTtlStockhist1.StockSupplierCode == mTtlStockhist2.StockSupplierCode)
                 && (mTtlStockhist1.StockCreateDate == mTtlStockhist2.StockCreateDate)
                 && (mTtlStockhist1.LastSalesDate == mTtlStockhist2.LastSalesDate)
                 && (mTtlStockhist1.LastStockDate == mTtlStockhist2.LastStockDate)
                 && (mTtlStockhist1.SearchDiv == mTtlStockhist2.SearchDiv));
        }
        /// <summary>
        /// 在庫実績照会集計データ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockHistoryDspSearchResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockHistoryDspSearchResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.BlGoodsCode != target.BlGoodsCode) resList.Add("BlGoodsCode");
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.SalesTimes != target.SalesTimes) resList.Add("SalesTimes");
            if (this.SalesCount != target.SalesCount) resList.Add("SalesCount");
            if (this.SalesMoneyTaxExc != target.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (this.SalesMoneyAvg != target.SalesMoneyAvg) resList.Add("SalesMoneyAvg");
            if (this.StockTimes != target.StockTimes) resList.Add("StockTimes");
            if (this.StockCount != target.StockCount) resList.Add("StockCount");
            if (this.StockPriceTaxExc != target.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (this.StockPriceAvg != target.StockPriceAvg) resList.Add("StockPriceAvg");
            if (this.GrossProfit != target.GrossProfit) resList.Add("GrossProfit");
            if (this.MoveArrivalCnt != target.MoveArrivalCnt) resList.Add("MoveArrivalCnt");
            if (this.MoveArrivalPrice != target.MoveArrivalPrice) resList.Add("MoveArrivalPrice");
            if (this.MoveShipmentCnt != target.MoveShipmentCnt) resList.Add("MoveShipmentCnt");
            if (this.MoveShipmentPrice != target.MoveShipmentPrice) resList.Add("MoveShipmentPrice");
            if (this.StockSupplierCode != target.StockSupplierCode) resList.Add("StockSupplierCode");
            if (this.StockCreateDate != target.StockCreateDate) resList.Add("StockCreateDate");
            if (this.LastSalesDate != target.LastSalesDate) resList.Add("LastSalesDate");
            if (this.LastStockDate != target.LastStockDate) resList.Add("LastStockDate");
            if (this.SearchDiv != target.SearchDiv) resList.Add("SearchDiv");

            return resList;
        }

        /// <summary>
        /// 売上月次集計データ比較処理
        /// </summary>
        /// <param name="shipmentPartsDspResult1">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <param name="shipmentPartsDspResult2">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesSlipクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockHistoryDspSearchResult shipmentPartsDspResult1, StockHistoryDspSearchResult shipmentPartsDspResult2)
        {
            ArrayList resList = new ArrayList();
            if (shipmentPartsDspResult1.EnterpriseCode != shipmentPartsDspResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (shipmentPartsDspResult1.AddUpYearMonth != shipmentPartsDspResult2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (shipmentPartsDspResult1.WarehouseCode != shipmentPartsDspResult2.WarehouseCode) resList.Add("WarehouseCode");
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            if (shipmentPartsDspResult1.WarehouseShelfNo != shipmentPartsDspResult2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (shipmentPartsDspResult1.BlGoodsCode != shipmentPartsDspResult2.BlGoodsCode) resList.Add("BlGoodsCode");
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            if (shipmentPartsDspResult1.GoodsNo != shipmentPartsDspResult2.GoodsNo) resList.Add("GoodsNo");
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            if (shipmentPartsDspResult1.GoodsName != shipmentPartsDspResult2.GoodsName) resList.Add("GoodsName");
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            if (shipmentPartsDspResult1.GoodsMakerCd != shipmentPartsDspResult2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (shipmentPartsDspResult1.SalesTimes != shipmentPartsDspResult2.SalesTimes) resList.Add("SalesTimes");
            if (shipmentPartsDspResult1.SalesCount != shipmentPartsDspResult2.SalesCount) resList.Add("SalesCount");
            if (shipmentPartsDspResult1.SalesMoneyTaxExc != shipmentPartsDspResult2.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (shipmentPartsDspResult1.SalesMoneyAvg != shipmentPartsDspResult2.SalesMoneyAvg) resList.Add("SalesMoneyAvg");
            if (shipmentPartsDspResult1.StockTimes != shipmentPartsDspResult2.StockTimes) resList.Add("StockTimes");
            if (shipmentPartsDspResult1.StockCount != shipmentPartsDspResult2.StockCount) resList.Add("StockCount");
            if (shipmentPartsDspResult1.StockPriceTaxExc != shipmentPartsDspResult2.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (shipmentPartsDspResult1.StockPriceAvg != shipmentPartsDspResult2.StockPriceAvg) resList.Add("StockPriceAvg");
            if (shipmentPartsDspResult1.GrossProfit != shipmentPartsDspResult2.GrossProfit) resList.Add("GrossProfit");
            if (shipmentPartsDspResult1.MoveArrivalCnt != shipmentPartsDspResult2.MoveArrivalCnt) resList.Add("MoveArrivalCnt");
            if (shipmentPartsDspResult1.MoveArrivalPrice != shipmentPartsDspResult2.MoveArrivalPrice) resList.Add("MoveArrivalPrice");
            if (shipmentPartsDspResult1.MoveShipmentCnt != shipmentPartsDspResult2.MoveShipmentCnt) resList.Add("MoveShipmentCnt");
            if (shipmentPartsDspResult1.MoveShipmentPrice != shipmentPartsDspResult2.MoveShipmentPrice) resList.Add("MoveShipmentPrice");
            if (shipmentPartsDspResult1.StockSupplierCode != shipmentPartsDspResult2.StockSupplierCode) resList.Add("StockSupplierCode");
            if (shipmentPartsDspResult1.StockCreateDate != shipmentPartsDspResult2.StockCreateDate) resList.Add("StockCreateDate");
            if (shipmentPartsDspResult1.LastSalesDate != shipmentPartsDspResult2.LastSalesDate) resList.Add("LastSalesDate");
            if (shipmentPartsDspResult1.LastStockDate != shipmentPartsDspResult2.LastStockDate) resList.Add("LastStockDate");
            if (shipmentPartsDspResult1.SearchDiv != shipmentPartsDspResult2.SearchDiv) resList.Add("SearchDiv");

            return resList;
        }
    }
}
