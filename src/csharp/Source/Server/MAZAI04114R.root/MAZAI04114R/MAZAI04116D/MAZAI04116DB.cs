using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockEachWarehouseWork
    /// <summary>
    ///                      商品在庫検索結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品在庫検索結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockEachWarehouseWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>在庫マスタ</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>在庫マスタ</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>在庫マスタ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>在庫マスタ</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>拠点コード</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>拠点情報設定マスタ</remarks>
        private string _sectionGuideNm = "";

        /// <summary>倉庫コード</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        /// <remarks>倉庫マスタ</remarks>
        private string _warehouseName = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>在庫マスタ</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _goodsNo = "";

        /// <summary>仕入単価（税抜,浮動）</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>仕入在庫数</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _supplierStock;

        /// <summary>受注数</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _acpOdrCount;

        /// <summary>M/O発注数</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _monthOrderCount;

        /// <summary>発注数</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _salesOrderCount;

        /// <summary>在庫区分</summary>
        /// <remarks>在庫マスタ</remarks>
        private Int32 _stockDiv;

        /// <summary>移動中仕入在庫数</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _movingSupliStock;

        /// <summary>出荷可能数</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _shipmentPosCnt;

        /// <summary>在庫保有総額</summary>
        /// <remarks>在庫マスタ</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>最終仕入年月日</summary>
        /// <remarks>在庫マスタ</remarks>
        private DateTime _lastStockDate;

        /// <summary>最終売上日</summary>
        /// <remarks>在庫マスタ</remarks>
        private DateTime _lastSalesDate;

        /// <summary>最終棚卸更新日</summary>
        /// <remarks>在庫マスタ</remarks>
        private DateTime _lastInventoryUpdate;

        /// <summary>最低在庫数</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _minimumStockCnt;

        /// <summary>最高在庫数</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _maximumStockCnt;

        /// <summary>基準発注数</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _nmlSalOdrCount;

        /// <summary>発注単位</summary>
        /// <remarks>在庫マスタ</remarks>
        private Int32 _salesOrderUnit;

        /// <summary>在庫発注先コード</summary>
        /// <remarks>在庫マスタ</remarks>
        private Int32 _stockSupplierCode;

        /// <summary>ハイフン無商品番号</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _goodsNoNoneHyphen = "";

        /// <summary>倉庫棚番</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _warehouseShelfNo = "";

        /// <summary>重複棚番１</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _duplicationShelfNo1 = "";

        /// <summary>重複棚番２</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _duplicationShelfNo2 = "";

        /// <summary>部品管理区分１</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _partsManagementDivide1 = "";

        /// <summary>部品管理区分２</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _partsManagementDivide2 = "";

        /// <summary>在庫備考１</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _stockNote1 = "";

        /// <summary>在庫備考２</summary>
        /// <remarks>在庫マスタ</remarks>
        private string _stockNote2 = "";

        /// <summary>出荷数（未計上）</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _shipmentCnt;

        /// <summary>入荷数（未計上）</summary>
        /// <remarks>在庫マスタ</remarks>
        private Double _arrivalCnt;

        /// <summary>在庫登録日</summary>
        /// <remarks>在庫マスタ</remarks>
        private DateTime _stockCreateDate;

        /// <summary>更新年月日</summary>
        /// <remarks>在庫マスタ</remarks>
        private DateTime _updateDate;

        /// <summary>品名</summary>
        /// <remarks>商品マスタ</remarks>
        private string _goodsName = "";

        /// <summary>BLコード</summary>
        /// <remarks>商品マスタ</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>商品名称カナ</summary>
        /// <remarks>商品マスタ</remarks>
        private string _goodsNameKana = "";

        /// <summary>商品規格・特記事項</summary>
        /// <remarks>商品マスタ</remarks>
        private string _goodsSpecialNote = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>JANコード</summary>
        /// <remarks>商品マスタ</remarks>
        private string _Jan = "";

        /// <summary>表示順位</summary>
        /// <remarks>商品マスタ</remarks>
        private Int32 _DisplayOrder;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>商品マスタ</remarks>
        private string _GoodsRateRank = "";

        /// <summary>課税区分</summary>
        /// <remarks>商品マスタ</remarks>
        private Int32 _TaxationDivCd;

        /// <summary>提供日付</summary>
        /// <remarks>商品マスタ</remarks>
        private Int32 _OfferDate;

        /// <summary>商品属性</summary>
        /// <remarks>商品マスタ</remarks>
        private Int32 _GoodsKindCode;

        /// <summary>商品備考</summary>
        /// <remarks>商品マスタ</remarks>
        private string _GoodsNote1 = "";

        /// <summary>商品備考</summary>
        /// <remarks>商品マスタ</remarks>
        private string _GoodsNote2 = "";

        /// <summary>自社分類コード</summary>
        /// <remarks>商品マスタ</remarks>
        private Int32 _EnterpriseGanreCode;

        /// <summary>価格開始日</summary>
        /// <remarks>価格マスタ</remarks>
        private Int32 _PriceStartDate;

        /// <summary>定価（浮動）</summary>
        /// <remarks>価格マスタ</remarks>
        private Double _ListPrice;

        /// <summary>原価単価</summary>
        /// <remarks>価格マスタ</remarks>
        private Double _SalesUnitCost;

        /// <summary>仕入率</summary>
        /// <remarks>価格マスタ</remarks>
        private Double _StockRate;

        /// <summary>オープン価格区分</summary>
        /// <remarks>価格マスタ</remarks>
        private Int32 _OpenPriceDiv;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>在庫マスタ</value>
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
        /// <value>在庫マスタ</value>
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
        /// <value>在庫マスタ</value>
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
        /// <value>在庫マスタ</value>
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
        /// <value>在庫マスタ</value>
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
        /// <value>在庫マスタ</value>
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
        /// <value>在庫マスタ</value>
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
        /// <value>在庫マスタ</value>
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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>在庫マスタ</value>
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>拠点情報設定マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>在庫マスタ</value>
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
        /// <value>倉庫マスタ</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>在庫マスタ</value>
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

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// <value>在庫マスタ</value>
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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜,浮動）プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜,浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  SupplierStock
        /// <summary>仕入在庫数プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SupplierStock
        {
            get { return _supplierStock; }
            set { _supplierStock = value; }
        }

        /// public propaty name  :  AcpOdrCount
        /// <summary>受注数プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcpOdrCount
        {
            get { return _acpOdrCount; }
            set { _acpOdrCount = value; }
        }

        /// public propaty name  :  MonthOrderCount
        /// <summary>M/O発注数プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   M/O発注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthOrderCount
        {
            get { return _monthOrderCount; }
            set { _monthOrderCount = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>発注数プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  MovingSupliStock
        /// <summary>移動中仕入在庫数プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動中仕入在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MovingSupliStock
        {
            get { return _movingSupliStock; }
            set { _movingSupliStock = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  StockTotalPrice
        /// <summary>在庫保有総額プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫保有総額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  LastStockDate
        /// <summary>最終仕入年月日プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終仕入年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LastStockDate
        {
            get { return _lastStockDate; }
            set { _lastStockDate = value; }
        }

        /// public propaty name  :  LastSalesDate
        /// <summary>最終売上日プロパティ</summary>
        /// <value>在庫マスタ</value>
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

        /// public propaty name  :  LastInventoryUpdate
        /// <summary>最終棚卸更新日プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終棚卸更新日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LastInventoryUpdate
        {
            get { return _lastInventoryUpdate; }
            set { _lastInventoryUpdate = value; }
        }

        /// public propaty name  :  MinimumStockCnt
        /// <summary>最低在庫数プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最低在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MinimumStockCnt
        {
            get { return _minimumStockCnt; }
            set { _minimumStockCnt = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>最高在庫数プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最高在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  NmlSalOdrCount
        /// <summary>基準発注数プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準発注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NmlSalOdrCount
        {
            get { return _nmlSalOdrCount; }
            set { _nmlSalOdrCount = value; }
        }

        /// public propaty name  :  SalesOrderUnit
        /// <summary>発注単位プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderUnit
        {
            get { return _salesOrderUnit; }
            set { _salesOrderUnit = value; }
        }

        /// public propaty name  :  StockSupplierCode
        /// <summary>在庫発注先コードプロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSupplierCode
        {
            get { return _stockSupplierCode; }
            set { _stockSupplierCode = value; }
        }

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>ハイフン無商品番号プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  DuplicationShelfNo1
        /// <summary>重複棚番１プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DuplicationShelfNo1
        {
            get { return _duplicationShelfNo1; }
            set { _duplicationShelfNo1 = value; }
        }

        /// public propaty name  :  DuplicationShelfNo2
        /// <summary>重複棚番２プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DuplicationShelfNo2
        {
            get { return _duplicationShelfNo2; }
            set { _duplicationShelfNo2 = value; }
        }

        /// public propaty name  :  PartsManagementDivide1
        /// <summary>部品管理区分１プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsManagementDivide1
        {
            get { return _partsManagementDivide1; }
            set { _partsManagementDivide1 = value; }
        }

        /// public propaty name  :  PartsManagementDivide2
        /// <summary>部品管理区分２プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsManagementDivide2
        {
            get { return _partsManagementDivide2; }
            set { _partsManagementDivide2 = value; }
        }

        /// public propaty name  :  StockNote1
        /// <summary>在庫備考１プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockNote1
        {
            get { return _stockNote1; }
            set { _stockNote1 = value; }
        }

        /// public propaty name  :  StockNote2
        /// <summary>在庫備考２プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockNote2
        {
            get { return _stockNote2; }
            set { _stockNote2 = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数（未計上）プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数（未計上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>入荷数（未計上）プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷数（未計上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>在庫登録日プロパティ</summary>
        /// <value>在庫マスタ</value>
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

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>在庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品名プロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BLコードプロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>商品規格・特記事項プロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// public propaty name  :  Jan
        /// <summary>JANコードプロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JANコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Jan
        {
            get { return _Jan; }
            set { _Jan = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _DisplayOrder; }
            set { _DisplayOrder = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _GoodsRateRank; }
            set { _GoodsRateRank = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _TaxationDivCd; }
            set { _TaxationDivCd = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _OfferDate; }
            set { _OfferDate = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _GoodsKindCode; }
            set { _GoodsKindCode = value; }
        }

        /// public propaty name  :  GoodsNote1
        /// <summary>商品備考1プロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNote1
        {
            get { return _GoodsNote1; }
            set { _GoodsNote1 = value; }
        }

        /// public propaty name  :  GoodsNote2
        /// <summary>商品備考2プロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNote2
        {
            get { return _GoodsNote2; }
            set { _GoodsNote2 = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// <value>商品マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _EnterpriseGanreCode; }
            set { _EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// <value>価格マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _PriceStartDate; }
            set { _PriceStartDate = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価（浮動）プロパティ</summary>
        /// <value>価格マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _ListPrice; }
            set { _ListPrice = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// <value>価格マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _SalesUnitCost; }
            set { _SalesUnitCost = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>仕入率プロパティ</summary>
        /// <value>価格マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _StockRate; }
            set { _StockRate = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>価格マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _OpenPriceDiv; }
            set { _OpenPriceDiv = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD


        /// <summary>
        /// 商品在庫検索結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockEachWarehouseWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockEachWarehouseWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockEachWarehouseWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockEachWarehouseWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockEachWarehouseWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockEachWarehouseWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockEachWarehouseWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockEachWarehouseWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockEachWarehouseWork || graph is ArrayList || graph is StockEachWarehouseWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockEachWarehouseWork).FullName));

            if (graph != null && graph is StockEachWarehouseWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockEachWarehouseWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockEachWarehouseWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockEachWarehouseWork[])graph).Length;
            }
            else if (graph is StockEachWarehouseWork)
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
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //仕入単価（税抜,浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //仕入在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierStock
            //受注数
            serInfo.MemberInfo.Add(typeof(Double)); //AcpOdrCount
            //M/O発注数
            serInfo.MemberInfo.Add(typeof(Double)); //MonthOrderCount
            //発注数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //在庫区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //移動中仕入在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MovingSupliStock
            //出荷可能数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //在庫保有総額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //最終仕入年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastStockDate
            //最終売上日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastSalesDate
            //最終棚卸更新日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastInventoryUpdate
            //最低在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCnt
            //最高在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //基準発注数
            serInfo.MemberInfo.Add(typeof(Double)); //NmlSalOdrCount
            //発注単位
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderUnit
            //在庫発注先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSupplierCode
            //ハイフン無商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //重複棚番１
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo1
            //重複棚番２
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo2
            //部品管理区分１
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide1
            //部品管理区分２
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide2
            //在庫備考１
            serInfo.MemberInfo.Add(typeof(string)); //StockNote1
            //在庫備考２
            serInfo.MemberInfo.Add(typeof(string)); //StockNote2
            //出荷数（未計上）
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //入荷数（未計上）
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //在庫登録日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //品名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //商品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
            //JANコード
            serInfo.MemberInfo.Add(typeof(string)); //_Jan = "";
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32));   //_DisplayOrder;
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //_GoodsRateRank = "";
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32));   //_TaxationDivCd;
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32));   //_OfferDate;
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32));   //_GoodsKindCode;
            //商品備考1
            serInfo.MemberInfo.Add(typeof(string)); //_GoodsNote1 = "";
            //商品備考2
            serInfo.MemberInfo.Add(typeof(string)); //_GoodsNote2 = "";
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32));   //_EnterpriseGanreCode = "";
            //価格開始日
            serInfo.MemberInfo.Add(typeof(Int32));   //_PriceStartDate;
            //定価（浮動）
            serInfo.MemberInfo.Add(typeof(Double));  //_ListPrice;
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double));  //_SalesUnitCost;
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double));  //_StockRate;
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32));   //_OpenPriceDiv;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD


            serInfo.Serialize(writer, serInfo);
            if (graph is StockEachWarehouseWork)
            {
                StockEachWarehouseWork temp = (StockEachWarehouseWork)graph;

                SetStockEachWarehouseWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockEachWarehouseWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockEachWarehouseWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockEachWarehouseWork temp in lst)
                {
                    SetStockEachWarehouseWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockEachWarehouseWorkメンバ数(publicプロパティ数)
        /// </summary>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 UPD
        //private const int currentMemberCount = 47;
        private const int currentMemberCount = 61;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 UPD

        /// <summary>
        ///  StockEachWarehouseWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockEachWarehouseWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockEachWarehouseWork(System.IO.BinaryWriter writer, StockEachWarehouseWork temp)
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
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //仕入単価（税抜,浮動）
            writer.Write(temp.StockUnitPriceFl);
            //仕入在庫数
            writer.Write(temp.SupplierStock);
            //受注数
            writer.Write(temp.AcpOdrCount);
            //M/O発注数
            writer.Write(temp.MonthOrderCount);
            //発注数
            writer.Write(temp.SalesOrderCount);
            //在庫区分
            writer.Write(temp.StockDiv);
            //移動中仕入在庫数
            writer.Write(temp.MovingSupliStock);
            //出荷可能数
            writer.Write(temp.ShipmentPosCnt);
            //在庫保有総額
            writer.Write(temp.StockTotalPrice);
            //最終仕入年月日
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //最終売上日
            writer.Write((Int64)temp.LastSalesDate.Ticks);
            //最終棚卸更新日
            writer.Write((Int64)temp.LastInventoryUpdate.Ticks);
            //最低在庫数
            writer.Write(temp.MinimumStockCnt);
            //最高在庫数
            writer.Write(temp.MaximumStockCnt);
            //基準発注数
            writer.Write(temp.NmlSalOdrCount);
            //発注単位
            writer.Write(temp.SalesOrderUnit);
            //在庫発注先コード
            writer.Write(temp.StockSupplierCode);
            //ハイフン無商品番号
            writer.Write(temp.GoodsNoNoneHyphen);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //重複棚番１
            writer.Write(temp.DuplicationShelfNo1);
            //重複棚番２
            writer.Write(temp.DuplicationShelfNo2);
            //部品管理区分１
            writer.Write(temp.PartsManagementDivide1);
            //部品管理区分２
            writer.Write(temp.PartsManagementDivide2);
            //在庫備考１
            writer.Write(temp.StockNote1);
            //在庫備考２
            writer.Write(temp.StockNote2);
            //出荷数（未計上）
            writer.Write(temp.ShipmentCnt);
            //入荷数（未計上）
            writer.Write(temp.ArrivalCnt);
            //在庫登録日
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //品名
            writer.Write(temp.GoodsName);
            //BLコード
            writer.Write(temp.BLGoodsCode);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //商品規格・特記事項
            writer.Write(temp.GoodsSpecialNote);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
            //JANコード
            writer.Write(temp.Jan);
            //表示順位
            writer.Write(temp.DisplayOrder);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //提供日付
            writer.Write(temp.OfferDate);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //商品備考1
            writer.Write(temp.GoodsNote1);
            //商品備考2
            writer.Write(temp.GoodsNote2);
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //価格開始日
            writer.Write(temp.PriceStartDate);
            //定価（浮動）
            writer.Write(temp.ListPrice);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //仕入率
            writer.Write(temp.StockRate);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

        }

        /// <summary>
        ///  StockEachWarehouseWorkインスタンス取得
        /// </summary>
        /// <returns>StockEachWarehouseWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockEachWarehouseWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockEachWarehouseWork GetStockEachWarehouseWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockEachWarehouseWork temp = new StockEachWarehouseWork();

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
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //仕入単価（税抜,浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //仕入在庫数
            temp.SupplierStock = reader.ReadDouble();
            //受注数
            temp.AcpOdrCount = reader.ReadDouble();
            //M/O発注数
            temp.MonthOrderCount = reader.ReadDouble();
            //発注数
            temp.SalesOrderCount = reader.ReadDouble();
            //在庫区分
            temp.StockDiv = reader.ReadInt32();
            //移動中仕入在庫数
            temp.MovingSupliStock = reader.ReadDouble();
            //出荷可能数
            temp.ShipmentPosCnt = reader.ReadDouble();
            //在庫保有総額
            temp.StockTotalPrice = reader.ReadInt64();
            //最終仕入年月日
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            //最終売上日
            temp.LastSalesDate = new DateTime(reader.ReadInt64());
            //最終棚卸更新日
            temp.LastInventoryUpdate = new DateTime(reader.ReadInt64());
            //最低在庫数
            temp.MinimumStockCnt = reader.ReadDouble();
            //最高在庫数
            temp.MaximumStockCnt = reader.ReadDouble();
            //基準発注数
            temp.NmlSalOdrCount = reader.ReadDouble();
            //発注単位
            temp.SalesOrderUnit = reader.ReadInt32();
            //在庫発注先コード
            temp.StockSupplierCode = reader.ReadInt32();
            //ハイフン無商品番号
            temp.GoodsNoNoneHyphen = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //重複棚番１
            temp.DuplicationShelfNo1 = reader.ReadString();
            //重複棚番２
            temp.DuplicationShelfNo2 = reader.ReadString();
            //部品管理区分１
            temp.PartsManagementDivide1 = reader.ReadString();
            //部品管理区分２
            temp.PartsManagementDivide2 = reader.ReadString();
            //在庫備考１
            temp.StockNote1 = reader.ReadString();
            //在庫備考２
            temp.StockNote2 = reader.ReadString();
            //出荷数（未計上）
            temp.ShipmentCnt = reader.ReadDouble();
            //入荷数（未計上）
            temp.ArrivalCnt = reader.ReadDouble();
            //在庫登録日
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //品名
            temp.GoodsName = reader.ReadString();
            //BLコード
            temp.BLGoodsCode = reader.ReadInt32();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //商品規格・特記事項
            temp.GoodsSpecialNote = reader.ReadString();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
            //JANコード
            temp.Jan = reader.ReadString();
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //商品備考1
            temp.GoodsNote1 = reader.ReadString();
            //商品備考2
            temp.GoodsNote2 = reader.ReadString();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //価格開始日
            temp.PriceStartDate = reader.ReadInt32();
            //定価（浮動）
            temp.ListPrice = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //仕入率
            temp.StockRate = reader.ReadDouble();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

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
        /// <returns>StockEachWarehouseWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockEachWarehouseWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockEachWarehouseWork temp = GetStockEachWarehouseWork(reader, serInfo);
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
                    retValue = (StockEachWarehouseWork[])lst.ToArray(typeof(StockEachWarehouseWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
