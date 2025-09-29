using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Stock
    /// <summary>
    ///                      在庫マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2008/07/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/8  杉村</br>
    /// <br>                 :   出荷可能数の補足修正</br>
    /// </remarks>
    public class Stock
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

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        // リモートクラスから取得はしないが表示のために保持する項目

        /// <summary>規格・特記事項</summary>
        private string _goodsSpecialNote = "";

        /// <summary>発注ロット</summary>
        private Double _supplierLot;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略名</summary>
        private string _supplierSnm;



        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>仕入単価（税抜,浮動）</summary>
        /// <remarks>※在庫評価単価</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>仕入在庫数</summary>
        /// <remarks>受託数を含まない在庫数（自社在庫）</remarks>
        private Double _supplierStock;

        /// <summary>受注数</summary>
        private Double _acpOdrCount;

        /// <summary>M/O発注数</summary>
        private Double _monthOrderCount;

        /// <summary>発注数</summary>
        private Double _salesOrderCount;

        /// <summary>在庫区分</summary>
        /// <remarks>0:自社,1:受託</remarks>
        private Int32 _stockDiv;

        /// <summary>移動中仕入在庫数</summary>
        /// <remarks>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</remarks>
        private Double _movingSupliStock;

        /// <summary>出荷可能数</summary>
        /// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
        private Double _shipmentPosCnt;

        /// <summary>在庫保有総額</summary>
        /// <remarks>値引含む</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>最終仕入年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastStockDate;

        /// <summary>最終売上日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastSalesDate;

        /// <summary>最終棚卸更新日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastInventoryUpdate;

        /// <summary>最低在庫数</summary>
        private Double _minimumStockCnt;

        /// <summary>最高在庫数</summary>
        private Double _maximumStockCnt;

        /// <summary>基準発注数</summary>
        private Double _nmlSalOdrCount;

        /// <summary>発注単位</summary>
        /// <remarks>発注する単位の数量（１０個、２０個単位等）</remarks>
        private Int32 _salesOrderUnit;

        /// <summary>在庫発注先コード</summary>
        /// <remarks>在庫発注する場合の発注先（商品の発注先とは別管理）</remarks>
        private Int32 _stockSupplierCode;

        /// <summary>ハイフン無商品番号</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>重複棚番１</summary>
        private string _duplicationShelfNo1 = "";

        /// <summary>重複棚番２</summary>
        private string _duplicationShelfNo2 = "";

        /// <summary>部品管理区分１</summary>
        private string _partsManagementDivide1 = "";

        /// <summary>部品管理区分２</summary>
        private string _partsManagementDivide2 = "";

        /// <summary>在庫備考１</summary>
        /// <remarks>※何の仕入かわかる内容を設定する　例）車両仕入であれば車種名　</remarks>
        private string _stockNote1 = "";

        /// <summary>在庫備考２</summary>
        private string _stockNote2 = "";

        /// <summary>出荷数（未計上）</summary>
        /// <remarks>貸出、出荷と同意</remarks>
        private Double _shipmentCnt;

        /// <summary>入荷数（未計上）</summary>
        /// <remarks>入荷</remarks>
        private Double _arrivalCnt;

        /// <summary>在庫登録日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   規格・特記事項プロパティ</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }

        /// public propaty name  :  SupplierLot
        /// <summary>発注ロットプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注ロットプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SupplierLot
        {
            get { return _supplierLot; }
            set { _supplierLot = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
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
        /// <value>※在庫評価単価</value>
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
        /// <value>受託数を含まない在庫数（自社在庫）</value>
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
        /// <value>0:自社,1:受託</value>
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
        /// <value>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</value>
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
        /// <value>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
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
        /// <value>値引含む</value>
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
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  LastStockDateJpFormal
        /// <summary>最終仕入年月日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終仕入年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastStockDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastStockDate); }
            set { }
        }

        /// public propaty name  :  LastStockDateJpInFormal
        /// <summary>最終仕入年月日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終仕入年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastStockDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastStockDate); }
            set { }
        }

        /// public propaty name  :  LastStockDateAdFormal
        /// <summary>最終仕入年月日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終仕入年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastStockDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastStockDate); }
            set { }
        }

        /// public propaty name  :  LastStockDateAdInFormal
        /// <summary>最終仕入年月日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終仕入年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastStockDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastStockDate); }
            set { }
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
            get { return _lastSalesDate; }
            set { _lastSalesDate = value; }
        }

        /// public propaty name  :  LastSalesDateJpFormal
        /// <summary>最終売上日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終売上日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastSalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastSalesDate); }
            set { }
        }

        /// public propaty name  :  LastSalesDateJpInFormal
        /// <summary>最終売上日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終売上日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastSalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastSalesDate); }
            set { }
        }

        /// public propaty name  :  LastSalesDateAdFormal
        /// <summary>最終売上日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終売上日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastSalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastSalesDate); }
            set { }
        }

        /// public propaty name  :  LastSalesDateAdInFormal
        /// <summary>最終売上日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終売上日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastSalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastSalesDate); }
            set { }
        }

        /// public propaty name  :  LastInventoryUpdate
        /// <summary>最終棚卸更新日プロパティ</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  LastInventoryUpdateJpFormal
        /// <summary>最終棚卸更新日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終棚卸更新日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastInventoryUpdateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastInventoryUpdate); }
            set { }
        }

        /// public propaty name  :  LastInventoryUpdateJpInFormal
        /// <summary>最終棚卸更新日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終棚卸更新日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastInventoryUpdateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastInventoryUpdate); }
            set { }
        }

        /// public propaty name  :  LastInventoryUpdateAdFormal
        /// <summary>最終棚卸更新日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終棚卸更新日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastInventoryUpdateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastInventoryUpdate); }
            set { }
        }

        /// public propaty name  :  LastInventoryUpdateAdInFormal
        /// <summary>最終棚卸更新日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終棚卸更新日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastInventoryUpdateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastInventoryUpdate); }
            set { }
        }

        /// public propaty name  :  MinimumStockCnt
        /// <summary>最低在庫数プロパティ</summary>
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
        /// <value>発注する単位の数量（１０個、２０個単位等）</value>
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
        /// <value>在庫発注する場合の発注先（商品の発注先とは別管理）</value>
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
        /// <value>※何の仕入かわかる内容を設定する　例）車両仕入であれば車種名　</value>
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
        /// <value>貸出、出荷と同意</value>
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
        /// <value>入荷</value>
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
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  StockCreateDateJpFormal
        /// <summary>在庫登録日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫登録日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockCreateDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockCreateDate); }
            set { }
        }

        /// public propaty name  :  StockCreateDateJpInFormal
        /// <summary>在庫登録日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫登録日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockCreateDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockCreateDate); }
            set { }
        }

        /// public propaty name  :  StockCreateDateAdFormal
        /// <summary>在庫登録日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫登録日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockCreateDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockCreateDate); }
            set { }
        }

        /// public propaty name  :  StockCreateDateAdInFormal
        /// <summary>在庫登録日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫登録日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockCreateDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockCreateDate); }
            set { }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  UpdateDateJpFormal
        /// <summary>更新年月日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDate); }
            set { }
        }

        /// public propaty name  :  UpdateDateJpInFormal
        /// <summary>更新年月日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate); }
            set { }
        }

        /// public propaty name  :  UpdateDateAdFormal
        /// <summary>更新年月日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate); }
            set { }
        }

        /// public propaty name  :  UpdateDateAdInFormal
        /// <summary>更新年月日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDate); }
            set { }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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

        /// public property name  :  GoodsName
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

        /// public property name  :  MakerName
        /// <summary>商品名称プロパティ</summary>
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

        /// <summary>
        /// 在庫マスタコンストラクタ
        /// </summary>
        /// <returns>Stockクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Stockクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Stock()
        {
        }

        /// <summary>
        /// 在庫マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="stockUnitPriceFl">仕入単価（税抜,浮動）(※在庫評価単価)</param>
        /// <param name="supplierStock">仕入在庫数(受託数を含まない在庫数（自社在庫）)</param>
        /// <param name="acpOdrCount">受注数</param>
        /// <param name="monthOrderCount">M/O発注数</param>
        /// <param name="salesOrderCount">発注数</param>
        /// <param name="stockDiv">在庫区分(0:自社,1:受託)</param>
        /// <param name="movingSupliStock">移動中仕入在庫数(在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。)</param>
        /// <param name="shipmentPosCnt">出荷可能数(出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数)</param>
        /// <param name="stockTotalPrice">在庫保有総額(値引含む)</param>
        /// <param name="lastStockDate">最終仕入年月日(YYYYMMDD)</param>
        /// <param name="lastSalesDate">最終売上日(YYYYMMDD)</param>
        /// <param name="lastInventoryUpdate">最終棚卸更新日(YYYYMMDD)</param>
        /// <param name="minimumStockCnt">最低在庫数</param>
        /// <param name="maximumStockCnt">最高在庫数</param>
        /// <param name="nmlSalOdrCount">基準発注数</param>
        /// <param name="salesOrderUnit">発注単位(発注する単位の数量（１０個、２０個単位等）)</param>
        /// <param name="stockSupplierCode">在庫発注先コード(在庫発注する場合の発注先（商品の発注先とは別管理）)</param>
        /// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
        /// <param name="warehouseShelfNo">倉庫棚番</param>
        /// <param name="duplicationShelfNo1">重複棚番１</param>
        /// <param name="duplicationShelfNo2">重複棚番２</param>
        /// <param name="partsManagementDivide1">部品管理区分１</param>
        /// <param name="partsManagementDivide2">部品管理区分２</param>
        /// <param name="stockNote1">在庫備考１(※何の仕入かわかる内容を設定する　例）車両仕入であれば車種名　)</param>
        /// <param name="stockNote2">在庫備考２</param>
        /// <param name="shipmentCnt">出荷数（未計上）(貸出、出荷と同意)</param>
        /// <param name="arrivalCnt">入荷数（未計上）(入荷)</param>
        /// <param name="stockCreateDate">在庫登録日(YYYYMMDD)</param>
        /// <param name="updateDate">更新年月日(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="warehouseName">倉庫名称</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="makerName">メーカー名称</param>
        /// <returns>Stockクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Stockクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Stock(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string warehouseCode, Int32 goodsMakerCd, string goodsNo, Double stockUnitPriceFl, Double supplierStock, Double acpOdrCount, Double monthOrderCount, Double salesOrderCount, Int32 stockDiv, Double movingSupliStock, Double shipmentPosCnt, Int64 stockTotalPrice, DateTime lastStockDate, DateTime lastSalesDate, DateTime lastInventoryUpdate, Double minimumStockCnt, Double maximumStockCnt, Double nmlSalOdrCount, Int32 salesOrderUnit, Int32 stockSupplierCode, string goodsNoNoneHyphen, string warehouseShelfNo, string duplicationShelfNo1, string duplicationShelfNo2, string partsManagementDivide1, string partsManagementDivide2, string stockNote1, string stockNote2, Double shipmentCnt, Double arrivalCnt, DateTime stockCreateDate, DateTime updateDate, string enterpriseName, string updEmployeeName, string warehouseName, string goodsName, string makerName, string goodsSpecialNote, int supplierCd, Double supplierLot, string supplierSnm)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._warehouseCode = warehouseCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._stockUnitPriceFl = stockUnitPriceFl;
            this._supplierStock = supplierStock;
            this._acpOdrCount = acpOdrCount;
            this._monthOrderCount = monthOrderCount;
            this._salesOrderCount = salesOrderCount;
            this._stockDiv = stockDiv;
            this._movingSupliStock = movingSupliStock;
            this._shipmentPosCnt = shipmentPosCnt;
            this._stockTotalPrice = stockTotalPrice;
            this.LastStockDate = lastStockDate;
            this.LastSalesDate = lastSalesDate;
            this.LastInventoryUpdate = lastInventoryUpdate;
            this._minimumStockCnt = minimumStockCnt;
            this._maximumStockCnt = maximumStockCnt;
            this._nmlSalOdrCount = nmlSalOdrCount;
            this._salesOrderUnit = salesOrderUnit;
            this._stockSupplierCode = stockSupplierCode;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._warehouseShelfNo = warehouseShelfNo;
            this._duplicationShelfNo1 = duplicationShelfNo1;
            this._duplicationShelfNo2 = duplicationShelfNo2;
            this._partsManagementDivide1 = partsManagementDivide1;
            this._partsManagementDivide2 = partsManagementDivide2;
            this._stockNote1 = stockNote1;
            this._stockNote2 = stockNote2;
            this._shipmentCnt = shipmentCnt;
            this._arrivalCnt = arrivalCnt;
            this.StockCreateDate = stockCreateDate;
            this.UpdateDate = updateDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._warehouseName = warehouseName;
            this._goodsName = goodsName;
            this._makerName = makerName;
            this._goodsSpecialNote = goodsSpecialNote;
            this._supplierCd = supplierCd;
            this._supplierLot = supplierLot;
            this._supplierSnm = supplierSnm;
        }

        /// <summary>
        /// 在庫マスタ複製処理
        /// </summary>
        /// <returns>Stockクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Stock Clone()
        {
            return new Stock(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._warehouseCode, this._goodsMakerCd, this._goodsNo, this._stockUnitPriceFl, this._supplierStock, this._acpOdrCount, this._monthOrderCount, this._salesOrderCount, this._stockDiv, this._movingSupliStock, this._shipmentPosCnt, this._stockTotalPrice, this._lastStockDate, this._lastSalesDate, this._lastInventoryUpdate, this._minimumStockCnt, this._maximumStockCnt, this._nmlSalOdrCount, this._salesOrderUnit, this._stockSupplierCode, this._goodsNoNoneHyphen, this._warehouseShelfNo, this._duplicationShelfNo1, this._duplicationShelfNo2, this._partsManagementDivide1, this._partsManagementDivide2, this._stockNote1, this._stockNote2, this._shipmentCnt, this._arrivalCnt, this._stockCreateDate, this._updateDate, this._enterpriseName, this._updEmployeeName, this._warehouseName, this._goodsName, this._makerName, this._goodsSpecialNote, this.SupplierCd, this.SupplierLot, this.SupplierSnm);
        }

        /// <summary>
        /// 在庫マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Stockクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(Stock target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
                 && (this.SupplierStock == target.SupplierStock)
                 && (this.AcpOdrCount == target.AcpOdrCount)
                 && (this.MonthOrderCount == target.MonthOrderCount)
                 && (this.SalesOrderCount == target.SalesOrderCount)
                 && (this.StockDiv == target.StockDiv)
                 && (this.MovingSupliStock == target.MovingSupliStock)
                 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
                 && (this.StockTotalPrice == target.StockTotalPrice)
                 && (this.LastStockDate == target.LastStockDate)
                 && (this.LastSalesDate == target.LastSalesDate)
                 && (this.LastInventoryUpdate == target.LastInventoryUpdate)
                 && (this.MinimumStockCnt == target.MinimumStockCnt)
                 && (this.MaximumStockCnt == target.MaximumStockCnt)
                 && (this.NmlSalOdrCount == target.NmlSalOdrCount)
                 && (this.SalesOrderUnit == target.SalesOrderUnit)
                 && (this.StockSupplierCode == target.StockSupplierCode)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.DuplicationShelfNo1 == target.DuplicationShelfNo1)
                 && (this.DuplicationShelfNo2 == target.DuplicationShelfNo2)
                 && (this.PartsManagementDivide1 == target.PartsManagementDivide1)
                 && (this.PartsManagementDivide2 == target.PartsManagementDivide2)
                 && (this.StockNote1 == target.StockNote1)
                 && (this.StockNote2 == target.StockNote2)
                 && (this.ShipmentCnt == target.ShipmentCnt)
                 && (this.ArrivalCnt == target.ArrivalCnt)
                 && (this.StockCreateDate == target.StockCreateDate)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.GoodsName == target.GoodsName)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierLot == target.SupplierLot)
                 && (this.SupplierSnm == target.SupplierSnm));
            
        }

        /// <summary>
        /// 在庫マスタ比較処理
        /// </summary>
        /// <param name="stock1">
        ///                    比較するStockクラスのインスタンス
        /// </param>
        /// <param name="stock2">比較するStockクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Stockクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(Stock stock1, Stock stock2)
        {
            return ((stock1.CreateDateTime == stock2.CreateDateTime)
                 && (stock1.UpdateDateTime == stock2.UpdateDateTime)
                 && (stock1.EnterpriseCode == stock2.EnterpriseCode)
                 && (stock1.FileHeaderGuid == stock2.FileHeaderGuid)
                 && (stock1.UpdEmployeeCode == stock2.UpdEmployeeCode)
                 && (stock1.UpdAssemblyId1 == stock2.UpdAssemblyId1)
                 && (stock1.UpdAssemblyId2 == stock2.UpdAssemblyId2)
                 && (stock1.LogicalDeleteCode == stock2.LogicalDeleteCode)
                 && (stock1.SectionCode == stock2.SectionCode)
                 && (stock1.WarehouseCode == stock2.WarehouseCode)
                 && (stock1.GoodsMakerCd == stock2.GoodsMakerCd)
                 && (stock1.GoodsNo == stock2.GoodsNo)
                 && (stock1.StockUnitPriceFl == stock2.StockUnitPriceFl)
                 && (stock1.SupplierStock == stock2.SupplierStock)
                 && (stock1.AcpOdrCount == stock2.AcpOdrCount)
                 && (stock1.MonthOrderCount == stock2.MonthOrderCount)
                 && (stock1.SalesOrderCount == stock2.SalesOrderCount)
                 && (stock1.StockDiv == stock2.StockDiv)
                 && (stock1.MovingSupliStock == stock2.MovingSupliStock)
                 && (stock1.ShipmentPosCnt == stock2.ShipmentPosCnt)
                 && (stock1.StockTotalPrice == stock2.StockTotalPrice)
                 && (stock1.LastStockDate == stock2.LastStockDate)
                 && (stock1.LastSalesDate == stock2.LastSalesDate)
                 && (stock1.LastInventoryUpdate == stock2.LastInventoryUpdate)
                 && (stock1.MinimumStockCnt == stock2.MinimumStockCnt)
                 && (stock1.MaximumStockCnt == stock2.MaximumStockCnt)
                 && (stock1.NmlSalOdrCount == stock2.NmlSalOdrCount)
                 && (stock1.SalesOrderUnit == stock2.SalesOrderUnit)
                 && (stock1.StockSupplierCode == stock2.StockSupplierCode)
                 && (stock1.GoodsNoNoneHyphen == stock2.GoodsNoNoneHyphen)
                 && (stock1.WarehouseShelfNo == stock2.WarehouseShelfNo)
                 && (stock1.DuplicationShelfNo1 == stock2.DuplicationShelfNo1)
                 && (stock1.DuplicationShelfNo2 == stock2.DuplicationShelfNo2)
                 && (stock1.PartsManagementDivide1 == stock2.PartsManagementDivide1)
                 && (stock1.PartsManagementDivide2 == stock2.PartsManagementDivide2)
                 && (stock1.StockNote1 == stock2.StockNote1)
                 && (stock1.StockNote2 == stock2.StockNote2)
                 && (stock1.ShipmentCnt == stock2.ShipmentCnt)
                 && (stock1.ArrivalCnt == stock2.ArrivalCnt)
                 && (stock1.StockCreateDate == stock2.StockCreateDate)
                 && (stock1.UpdateDate == stock2.UpdateDate)
                 && (stock1.EnterpriseName == stock2.EnterpriseName)
                 && (stock1.UpdEmployeeName == stock2.UpdEmployeeName)
                 && (stock1.WarehouseName == stock2.WarehouseName)
                 && (stock1.GoodsName == stock2.GoodsName)
                 && (stock1.MakerName == stock2.MakerName)
                 && (stock1.GoodsSpecialNote == stock2.GoodsSpecialNote)
                 && (stock1.SupplierCd == stock2.SupplierCd)
                 && (stock1.SupplierLot == stock2.SupplierLot)
                 && (stock1.SupplierSnm == stock2.SupplierSnm)
                 );
        }
        /// <summary>
        /// 在庫マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Stockクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(Stock target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.StockUnitPriceFl != target.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (this.SupplierStock != target.SupplierStock) resList.Add("SupplierStock");
            if (this.AcpOdrCount != target.AcpOdrCount) resList.Add("AcpOdrCount");
            if (this.MonthOrderCount != target.MonthOrderCount) resList.Add("MonthOrderCount");
            if (this.SalesOrderCount != target.SalesOrderCount) resList.Add("SalesOrderCount");
            if (this.StockDiv != target.StockDiv) resList.Add("StockDiv");
            if (this.MovingSupliStock != target.MovingSupliStock) resList.Add("MovingSupliStock");
            if (this.ShipmentPosCnt != target.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (this.StockTotalPrice != target.StockTotalPrice) resList.Add("StockTotalPrice");
            if (this.LastStockDate != target.LastStockDate) resList.Add("LastStockDate");
            if (this.LastSalesDate != target.LastSalesDate) resList.Add("LastSalesDate");
            if (this.LastInventoryUpdate != target.LastInventoryUpdate) resList.Add("LastInventoryUpdate");
            if (this.MinimumStockCnt != target.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (this.MaximumStockCnt != target.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (this.NmlSalOdrCount != target.NmlSalOdrCount) resList.Add("NmlSalOdrCount");
            if (this.SalesOrderUnit != target.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (this.StockSupplierCode != target.StockSupplierCode) resList.Add("StockSupplierCode");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.DuplicationShelfNo1 != target.DuplicationShelfNo1) resList.Add("DuplicationShelfNo1");
            if (this.DuplicationShelfNo2 != target.DuplicationShelfNo2) resList.Add("DuplicationShelfNo2");
            if (this.PartsManagementDivide1 != target.PartsManagementDivide1) resList.Add("PartsManagementDivide1");
            if (this.PartsManagementDivide2 != target.PartsManagementDivide2) resList.Add("PartsManagementDivide2");
            if (this.StockNote1 != target.StockNote1) resList.Add("StockNote1");
            if (this.StockNote2 != target.StockNote2) resList.Add("StockNote2");
            if (this.ShipmentCnt != target.ShipmentCnt) resList.Add("ShipmentCnt");
            if (this.ArrivalCnt != target.ArrivalCnt) resList.Add("ArrivalCnt");
            if (this.StockCreateDate != target.StockCreateDate) resList.Add("StockCreateDate");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsSpecialNote != target.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.SupplierLot != target.SupplierLot) resList.Add("SupplierLot");

            return resList;
        }

        /// <summary>
        /// 在庫マスタ比較処理
        /// </summary>
        /// <param name="stock1">比較するStockクラスのインスタンス</param>
        /// <param name="stock2">比較するStockクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Stockクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(Stock stock1, Stock stock2)
        {
            ArrayList resList = new ArrayList();
            if (stock1.CreateDateTime != stock2.CreateDateTime) resList.Add("CreateDateTime");
            if (stock1.UpdateDateTime != stock2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stock1.EnterpriseCode != stock2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stock1.FileHeaderGuid != stock2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stock1.UpdEmployeeCode != stock2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stock1.UpdAssemblyId1 != stock2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stock1.UpdAssemblyId2 != stock2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stock1.LogicalDeleteCode != stock2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stock1.SectionCode != stock2.SectionCode) resList.Add("SectionCode");
            if (stock1.WarehouseCode != stock2.WarehouseCode) resList.Add("WarehouseCode");
            if (stock1.GoodsMakerCd != stock2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stock1.GoodsNo != stock2.GoodsNo) resList.Add("GoodsNo");
            if (stock1.StockUnitPriceFl != stock2.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (stock1.SupplierStock != stock2.SupplierStock) resList.Add("SupplierStock");
            if (stock1.AcpOdrCount != stock2.AcpOdrCount) resList.Add("AcpOdrCount");
            if (stock1.MonthOrderCount != stock2.MonthOrderCount) resList.Add("MonthOrderCount");
            if (stock1.SalesOrderCount != stock2.SalesOrderCount) resList.Add("SalesOrderCount");
            if (stock1.StockDiv != stock2.StockDiv) resList.Add("StockDiv");
            if (stock1.MovingSupliStock != stock2.MovingSupliStock) resList.Add("MovingSupliStock");
            if (stock1.ShipmentPosCnt != stock2.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (stock1.StockTotalPrice != stock2.StockTotalPrice) resList.Add("StockTotalPrice");
            if (stock1.LastStockDate != stock2.LastStockDate) resList.Add("LastStockDate");
            if (stock1.LastSalesDate != stock2.LastSalesDate) resList.Add("LastSalesDate");
            if (stock1.LastInventoryUpdate != stock2.LastInventoryUpdate) resList.Add("LastInventoryUpdate");
            if (stock1.MinimumStockCnt != stock2.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (stock1.MaximumStockCnt != stock2.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (stock1.NmlSalOdrCount != stock2.NmlSalOdrCount) resList.Add("NmlSalOdrCount");
            if (stock1.SalesOrderUnit != stock2.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (stock1.StockSupplierCode != stock2.StockSupplierCode) resList.Add("StockSupplierCode");
            if (stock1.GoodsNoNoneHyphen != stock2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (stock1.WarehouseShelfNo != stock2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stock1.DuplicationShelfNo1 != stock2.DuplicationShelfNo1) resList.Add("DuplicationShelfNo1");
            if (stock1.DuplicationShelfNo2 != stock2.DuplicationShelfNo2) resList.Add("DuplicationShelfNo2");
            if (stock1.PartsManagementDivide1 != stock2.PartsManagementDivide1) resList.Add("PartsManagementDivide1");
            if (stock1.PartsManagementDivide2 != stock2.PartsManagementDivide2) resList.Add("PartsManagementDivide2");
            if (stock1.StockNote1 != stock2.StockNote1) resList.Add("StockNote1");
            if (stock1.StockNote2 != stock2.StockNote2) resList.Add("StockNote2");
            if (stock1.ShipmentCnt != stock2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (stock1.ArrivalCnt != stock2.ArrivalCnt) resList.Add("ArrivalCnt");
            if (stock1.StockCreateDate != stock2.StockCreateDate) resList.Add("StockCreateDate");
            if (stock1.UpdateDate != stock2.UpdateDate) resList.Add("UpdateDate");
            if (stock1.EnterpriseName != stock2.EnterpriseName) resList.Add("EnterpriseName");
            if (stock1.UpdEmployeeName != stock2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stock1.WarehouseName != stock2.WarehouseName) resList.Add("WarehouseName");
            if (stock1.GoodsName != stock2.GoodsName) resList.Add("GoodsName");
            if (stock1.MakerName != stock2.MakerName) resList.Add("MakerName");
            if (stock1.GoodsSpecialNote != stock2.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (stock1.SupplierCd != stock2.SupplierCd) resList.Add("SupplierCd");
            if (stock1.SupplierSnm != stock2.SupplierSnm) resList.Add("SupplierSnm");
            if (stock1.SupplierLot != stock2.SupplierLot) resList.Add("SupplierLot");

            return resList;
        }
    }
}
