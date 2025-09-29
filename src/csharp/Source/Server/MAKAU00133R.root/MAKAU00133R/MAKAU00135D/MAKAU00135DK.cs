using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockHistoryWork
    /// <summary>
    ///                      在庫履歴データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫履歴データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/07/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockHistoryWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>前月末在庫数</summary>
        /// <remarks>前月の「在庫総数」</remarks>
        private Double _lMonthStockCnt;

        /// <summary>前月末在庫額</summary>
        /// <remarks>前月の「マシン在庫金額」</remarks>
        private Int64 _lMonthStockPrice;

        /// <summary>前月末自社在庫数</summary>
        private Double _lMonthPptyStockCnt;

        /// <summary>前月末自社在庫金額</summary>
        private Int64 _lMonthPptyStockPrice;

        /// <summary>売上回数</summary>
        private Int32 _salesTimes;

        /// <summary>売上数</summary>
        private Double _salesCount;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>売上返品回数</summary>
        private Int32 _salesRetGoodsTimes;

        /// <summary>売上返品数</summary>
        private Double _salesRetGoodsCnt;

        /// <summary>売上返品額</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>粗利金額</summary>
        private Int64 _grossProfit;

        /// <summary>仕入回数</summary>
        private Int32 _stockTimes;

        /// <summary>仕入数</summary>
        private Double _stockCount;

        /// <summary>仕入金額（税抜き）</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>仕入返品回数</summary>
        private Int32 _stockRetGoodsTimes;

        /// <summary>仕入返品数</summary>
        private Double _stockRetGoodsCnt;

        /// <summary>仕入返品額</summary>
        private Int64 _stockRetGoodsPrice;

        /// <summary>移動入荷数</summary>
        private Double _moveArrivalCnt;

        /// <summary>移動入荷額</summary>
        private Int64 _moveArrivalPrice;

        /// <summary>移動出荷数</summary>
        private Double _moveShipmentCnt;

        /// <summary>移動出荷額</summary>
        private Int64 _moveShipmentPrice;

        /// <summary>調整数</summary>
        private Double _adjustCount;

        /// <summary>調整金額</summary>
        private Int64 _adjustPrice;

        /// <summary>入荷数</summary>
        /// <remarks>入出荷日が当月の仕入（入荷）の数量</remarks>
        private Double _arrivalCnt;

        /// <summary>入荷金額</summary>
        /// <remarks>上記金額</remarks>
        private Int64 _arrivalPrice;

        /// <summary>出荷数</summary>
        /// <remarks>入出荷日が当月の売上（出荷）の数量</remarks>
        private Double _shipmentCnt;

        /// <summary>出荷金額</summary>
        /// <remarks>上記金額</remarks>
        private Int64 _shipmentPrice;

        /// <summary>総入荷数</summary>
        /// <remarks>入出荷日が当月の入荷した総数（入荷、仕入、移動入荷、調整、棚卸）</remarks>
        private Double _totalArrivalCnt;

        /// <summary>総入荷金額</summary>
        /// <remarks>上記金額</remarks>
        private Int64 _totalArrivalPrice;

        /// <summary>総出荷数</summary>
        /// <remarks>入出荷日が当月の出荷した総数（出荷、売上、移動出荷）</remarks>
        private Double _totalShipmentCnt;

        /// <summary>総出荷金額</summary>
        /// <remarks>上記金額</remarks>
        private Int64 _totalShipmentPrice;

        /// <summary>仕入単価（税抜，浮動）</summary>
        /// <remarks>棚卸評価単価</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>在庫総数</summary>
        /// <remarks>入荷、出荷を含む在庫数（入出荷日ベース）</remarks>
        private Double _stockTotal;

        /// <summary>マシン在庫額</summary>
        /// <remarks>入荷、出荷を含む在庫金額</remarks>
        private Int64 _stockMashinePrice;

        /// <summary>自社在庫数</summary>
        /// <remarks>自社の資産の在庫数（計上日ベース）</remarks>
        private Double _propertyStockCnt;

        /// <summary>自社在庫金額</summary>
        /// <remarks>自社の資産の在庫金額</remarks>
        private Int64 _propertyStockPrice;

        /// <summary>BL商品コード</summary>
        /// <remarks>BL商品コード</remarks>
        private Int32 _bLGoodsCode;

        // -------ADD 2010/09/21--------->>>>>
        /// <summary>BL商品コード名称（半角）</summary>
        /// <remarks>BL商品コード名称（半角）</remarks>
        private string _bLGoodsHalfName;
        // -------ADD 2010/09/21---------<<<<<

        // -------ADD 2010/09/28--------->>>>>
        /// <summary>倉庫コード</summary>
        /// <remarks>倉庫コード</remarks>
        private string _wareHouseCd;
        // -------ADD 2010/09/28---------<<<<<

        /// <summary>棚番</summary>
        /// <remarks>棚番</remarks>
        private String _warehouseShelfno;

        /// <summary>在庫登録日</summary>
        /// <remarks>在庫登録日</remarks>
        private DateTime _stockCreateDate;

        /// <summary>最終売上日</summary>
        /// <remarks>最終売上日</remarks>
        private DateTime _lastSalesDate;

        /// <summary>最終仕入日</summary>
        /// <remarks>最終仕入日</remarks>
        private DateTime _lastStockDate;

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
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
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  LMonthStockCnt
        /// <summary>前月末在庫数プロパティ</summary>
        /// <value>前月の「在庫総数」</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前月末在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double LMonthStockCnt
        {
            get { return _lMonthStockCnt; }
            set { _lMonthStockCnt = value; }
        }

        /// public propaty name  :  LMonthStockPrice
        /// <summary>前月末在庫額プロパティ</summary>
        /// <value>前月の「マシン在庫金額」</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前月末在庫額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LMonthStockPrice
        {
            get { return _lMonthStockPrice; }
            set { _lMonthStockPrice = value; }
        }

        /// public propaty name  :  LMonthPptyStockCnt
        /// <summary>前月末自社在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前月末自社在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double LMonthPptyStockCnt
        {
            get { return _lMonthPptyStockCnt; }
            set { _lMonthPptyStockCnt = value; }
        }

        /// public propaty name  :  LMonthPptyStockPrice
        /// <summary>前月末自社在庫金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前月末自社在庫金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LMonthPptyStockPrice
        {
            get { return _lMonthPptyStockPrice; }
            set { _lMonthPptyStockPrice = value; }
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
            get { return _salesTimes; }
            set { _salesTimes = value; }
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
            get { return _salesCount; }
            set { _salesCount = value; }
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
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesRetGoodsTimes
        /// <summary>売上返品回数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上返品回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRetGoodsTimes
        {
            get { return _salesRetGoodsTimes; }
            set { _salesRetGoodsTimes = value; }
        }

        /// public propaty name  :  SalesRetGoodsCnt
        /// <summary>売上返品数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上返品数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesRetGoodsCnt
        {
            get { return _salesRetGoodsCnt; }
            set { _salesRetGoodsCnt = value; }
        }

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>売上返品額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上返品額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
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
            get { return _grossProfit; }
            set { _grossProfit = value; }
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
            get { return _stockTimes; }
            set { _stockTimes = value; }
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
            get { return _stockCount; }
            set { _stockCount = value; }
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
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockRetGoodsTimes
        /// <summary>仕入返品回数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入返品回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockRetGoodsTimes
        {
            get { return _stockRetGoodsTimes; }
            set { _stockRetGoodsTimes = value; }
        }

        /// public propaty name  :  StockRetGoodsCnt
        /// <summary>仕入返品数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入返品数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockRetGoodsCnt
        {
            get { return _stockRetGoodsCnt; }
            set { _stockRetGoodsCnt = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice
        /// <summary>仕入返品額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入返品額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice
        {
            get { return _stockRetGoodsPrice; }
            set { _stockRetGoodsPrice = value; }
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
            get { return _moveArrivalCnt; }
            set { _moveArrivalCnt = value; }
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
            get { return _moveArrivalPrice; }
            set { _moveArrivalPrice = value; }
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
            get { return _moveShipmentCnt; }
            set { _moveShipmentCnt = value; }
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
            get { return _moveShipmentPrice; }
            set { _moveShipmentPrice = value; }
        }

        /// public propaty name  :  AdjustCount
        /// <summary>調整数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AdjustCount
        {
            get { return _adjustCount; }
            set { _adjustCount = value; }
        }

        /// public propaty name  :  AdjustPrice
        /// <summary>調整金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AdjustPrice
        {
            get { return _adjustPrice; }
            set { _adjustPrice = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>入荷数プロパティ</summary>
        /// <value>入出荷日が当月の仕入（入荷）の数量</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ArrivalPrice
        /// <summary>入荷金額プロパティ</summary>
        /// <value>上記金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ArrivalPrice
        {
            get { return _arrivalPrice; }
            set { _arrivalPrice = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// <value>入出荷日が当月の売上（出荷）の数量</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ShipmentPrice
        /// <summary>出荷金額プロパティ</summary>
        /// <value>上記金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ShipmentPrice
        {
            get { return _shipmentPrice; }
            set { _shipmentPrice = value; }
        }

        /// public propaty name  :  TotalArrivalCnt
        /// <summary>総入荷数プロパティ</summary>
        /// <value>入出荷日が当月の入荷した総数（入荷、仕入、移動入荷、調整、棚卸）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalArrivalCnt
        {
            get { return _totalArrivalCnt; }
            set { _totalArrivalCnt = value; }
        }

        /// public propaty name  :  TotalArrivalPrice
        /// <summary>総入荷金額プロパティ</summary>
        /// <value>上記金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalArrivalPrice
        {
            get { return _totalArrivalPrice; }
            set { _totalArrivalPrice = value; }
        }

        /// public propaty name  :  TotalShipmentCnt
        /// <summary>総出荷数プロパティ</summary>
        /// <value>入出荷日が当月の出荷した総数（出荷、売上、移動出荷）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalShipmentCnt
        {
            get { return _totalShipmentCnt; }
            set { _totalShipmentCnt = value; }
        }

        /// public propaty name  :  TotalShipmentPrice
        /// <summary>総出荷金額プロパティ</summary>
        /// <value>上記金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalShipmentPrice
        {
            get { return _totalShipmentPrice; }
            set { _totalShipmentPrice = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜，浮動）プロパティ</summary>
        /// <value>棚卸評価単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockTotal
        /// <summary>在庫総数プロパティ</summary>
        /// <value>入荷、出荷を含む在庫数（入出荷日ベース）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫総数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockTotal
        {
            get { return _stockTotal; }
            set { _stockTotal = value; }
        }

        /// public propaty name  :  StockMashinePrice
        /// <summary>マシン在庫額プロパティ</summary>
        /// <value>入荷、出荷を含む在庫金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マシン在庫額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockMashinePrice
        {
            get { return _stockMashinePrice; }
            set { _stockMashinePrice = value; }
        }

        /// public propaty name  :  PropertyStockCnt
        /// <summary>自社在庫数プロパティ</summary>
        /// <value>自社の資産の在庫数（計上日ベース）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PropertyStockCnt
        {
            get { return _propertyStockCnt; }
            set { _propertyStockCnt = value; }
        }

        /// public propaty name  :  PropertyStockPrice
        /// <summary>自社在庫金額プロパティ</summary>
        /// <value>自社の資産の在庫金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社在庫金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PropertyStockPrice
        {
            get { return _propertyStockPrice; }
            set { _propertyStockPrice = value; }
        }

        /// public propaty name  :  WarehouseShelfno
        /// <summary>棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        // -------ADD 2010/09/21--------->>>>>
        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }
        // -------ADD 2010/09/21---------<<<<<

        // -------ADD 2010/09/28--------->>>>>
        public string WareHouseCd
        {
            get { return _wareHouseCd; }
            set { _wareHouseCd = value; }
        }
        // -------ADD 2010/09/28---------<<<<<

        /// public propaty name  :  WarehouseShelfno
        /// <summary>棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String WarehouseShelfNo
        {
            get { return _warehouseShelfno; }
            set { _warehouseShelfno = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>在庫登録日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫登録日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockCreateDate
        {
            get { return _stockCreateDate; }
            set { _stockCreateDate = value; }
        }

        /// public propaty name  :  LastSalesDate
        /// <summary>最終売上日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終売上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LastSalesDate
        {
            get { return _lastSalesDate; }
            set { _lastSalesDate = value; }
        }

        /// public propaty name  :  LastStockDate
        /// <summary>最終仕入日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LastStockDate
        {
            get { return _lastStockDate; }
            set { _lastStockDate = value; }
        }


        /// <summary>
        /// 在庫履歴データワークコンストラクタ
        /// </summary>
        /// <returns>StockHistoryWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockHistoryWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockHistoryWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockHistoryWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockHistoryWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockHistoryWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockHistoryWork || graph is ArrayList || graph is StockHistoryWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockHistoryWork).FullName));

            if (graph != null && graph is StockHistoryWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockHistoryWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockHistoryWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockHistoryWork[])graph).Length;
            }
            else if (graph is StockHistoryWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //前月末在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //LMonthStockCnt
            //前月末在庫額
            serInfo.MemberInfo.Add(typeof(Int64)); //LMonthStockPrice
            //前月末自社在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //LMonthPptyStockCnt
            //前月末自社在庫金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LMonthPptyStockPrice
            //売上回数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //売上数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesCount
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //売上返品回数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRetGoodsTimes
            //売上返品数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRetGoodsCnt
            //売上返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //仕入回数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockTimes
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //仕入返品回数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRetGoodsTimes
            //仕入返品数
            serInfo.MemberInfo.Add(typeof(Double)); //StockRetGoodsCnt
            //仕入返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice
            //移動入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveArrivalCnt
            //移動入荷額
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveArrivalPrice
            //移動出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveShipmentCnt
            //移動出荷額
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveShipmentPrice
            //調整数
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCount
            //調整金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AdjustPrice
            //入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //入荷金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ArrivalPrice
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //出荷金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ShipmentPrice
            //総入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //TotalArrivalCnt
            //総入荷金額
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalArrivalPrice
            //総出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //TotalShipmentCnt
            //総出荷金額
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalShipmentPrice
            //仕入単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //在庫総数
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //マシン在庫額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMashinePrice
            //自社在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //PropertyStockCnt
            //自社在庫金額
            serInfo.MemberInfo.Add(typeof(Int64)); //PropertyStockPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is StockHistoryWork)
            {
                StockHistoryWork temp = (StockHistoryWork)graph;

                SetStockHistoryWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockHistoryWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockHistoryWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockHistoryWork temp in lst)
                {
                    SetStockHistoryWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockHistoryWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 52;
        private const int currentMemberCount = 56;

        /// <summary>
        ///  StockHistoryWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockHistoryWork(System.IO.BinaryWriter writer, StockHistoryWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //拠点コード
            writer.Write(temp.SectionCode);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //前月末在庫数
            writer.Write(temp.LMonthStockCnt);
            //前月末在庫額
            writer.Write(temp.LMonthStockPrice);
            //前月末自社在庫数
            writer.Write(temp.LMonthPptyStockCnt);
            //前月末自社在庫金額
            writer.Write(temp.LMonthPptyStockPrice);
            //売上回数
            writer.Write(temp.SalesTimes);
            //売上数
            writer.Write(temp.SalesCount);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //売上返品回数
            writer.Write(temp.SalesRetGoodsTimes);
            //売上返品数
            writer.Write(temp.SalesRetGoodsCnt);
            //売上返品額
            writer.Write(temp.SalesRetGoodsPrice);
            //粗利金額
            writer.Write(temp.GrossProfit);
            //仕入回数
            writer.Write(temp.StockTimes);
            //仕入数
            writer.Write(temp.StockCount);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);
            //仕入返品回数
            writer.Write(temp.StockRetGoodsTimes);
            //仕入返品数
            writer.Write(temp.StockRetGoodsCnt);
            //仕入返品額
            writer.Write(temp.StockRetGoodsPrice);
            //移動入荷数
            writer.Write(temp.MoveArrivalCnt);
            //移動入荷額
            writer.Write(temp.MoveArrivalPrice);
            //移動出荷数
            writer.Write(temp.MoveShipmentCnt);
            //移動出荷額
            writer.Write(temp.MoveShipmentPrice);
            //調整数
            writer.Write(temp.AdjustCount);
            //調整金額
            writer.Write(temp.AdjustPrice);
            //入荷数
            writer.Write(temp.ArrivalCnt);
            //入荷金額
            writer.Write(temp.ArrivalPrice);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //出荷金額
            writer.Write(temp.ShipmentPrice);
            //総入荷数
            writer.Write(temp.TotalArrivalCnt);
            //総入荷金額
            writer.Write(temp.TotalArrivalPrice);
            //総出荷数
            writer.Write(temp.TotalShipmentCnt);
            //総出荷金額
            writer.Write(temp.TotalShipmentPrice);
            //仕入単価（税抜，浮動）
            writer.Write(temp.StockUnitPriceFl);
            //在庫総数
            writer.Write(temp.StockTotal);
            //マシン在庫額
            writer.Write(temp.StockMashinePrice);
            //自社在庫数
            writer.Write(temp.PropertyStockCnt);
            //自社在庫金額
            writer.Write(temp.PropertyStockPrice);

        }

        /// <summary>
        ///  StockHistoryWorkインスタンス取得
        /// </summary>
        /// <returns>StockHistoryWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockHistoryWork GetStockHistoryWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockHistoryWork temp = new StockHistoryWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //前月末在庫数
            temp.LMonthStockCnt = reader.ReadDouble();
            //前月末在庫額
            temp.LMonthStockPrice = reader.ReadInt64();
            //前月末自社在庫数
            temp.LMonthPptyStockCnt = reader.ReadDouble();
            //前月末自社在庫金額
            temp.LMonthPptyStockPrice = reader.ReadInt64();
            //売上回数
            temp.SalesTimes = reader.ReadInt32();
            //売上数
            temp.SalesCount = reader.ReadDouble();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //売上返品回数
            temp.SalesRetGoodsTimes = reader.ReadInt32();
            //売上返品数
            temp.SalesRetGoodsCnt = reader.ReadDouble();
            //売上返品額
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //粗利金額
            temp.GrossProfit = reader.ReadInt64();
            //仕入回数
            temp.StockTimes = reader.ReadInt32();
            //仕入数
            temp.StockCount = reader.ReadDouble();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();
            //仕入返品回数
            temp.StockRetGoodsTimes = reader.ReadInt32();
            //仕入返品数
            temp.StockRetGoodsCnt = reader.ReadDouble();
            //仕入返品額
            temp.StockRetGoodsPrice = reader.ReadInt64();
            //移動入荷数
            temp.MoveArrivalCnt = reader.ReadDouble();
            //移動入荷額
            temp.MoveArrivalPrice = reader.ReadInt64();
            //移動出荷数
            temp.MoveShipmentCnt = reader.ReadDouble();
            //移動出荷額
            temp.MoveShipmentPrice = reader.ReadInt64();
            //調整数
            temp.AdjustCount = reader.ReadDouble();
            //調整金額
            temp.AdjustPrice = reader.ReadInt64();
            //入荷数
            temp.ArrivalCnt = reader.ReadDouble();
            //入荷金額
            temp.ArrivalPrice = reader.ReadInt64();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //出荷金額
            temp.ShipmentPrice = reader.ReadInt64();
            //総入荷数
            temp.TotalArrivalCnt = reader.ReadDouble();
            //総入荷金額
            temp.TotalArrivalPrice = reader.ReadInt64();
            //総出荷数
            temp.TotalShipmentCnt = reader.ReadDouble();
            //総出荷金額
            temp.TotalShipmentPrice = reader.ReadInt64();
            //仕入単価（税抜，浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //在庫総数
            temp.StockTotal = reader.ReadDouble();
            //マシン在庫額
            temp.StockMashinePrice = reader.ReadInt64();
            //自社在庫数
            temp.PropertyStockCnt = reader.ReadDouble();
            //自社在庫金額
            temp.PropertyStockPrice = reader.ReadInt64();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>StockHistoryWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockHistoryWork temp = GetStockHistoryWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (StockHistoryWork[])lst.ToArray(typeof(StockHistoryWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
