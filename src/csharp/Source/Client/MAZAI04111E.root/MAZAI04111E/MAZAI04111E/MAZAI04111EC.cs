using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockExpansion
    /// <summary>
    ///                      商品在庫情報クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品在庫情報クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/10  (CSharp File Generated Date)</br>
    /// <br>-------------------------------------------------------------</br>
    /// <br>Update Note      :   2008/02/18 鈴木 正臣  ①最新のレイアウトに対応</br>
    /// <br>                                           ②ファイルレイアウトの項目以外で必要な項目を追加</br>
    /// <br>                 :   2009/04/01 照田 貴志　不具合対応[12836]</br>
    /// </remarks>
    public class StockExpansion
    {
        # region [ private Fields (テーブルレイアウトより自動生成分) ]
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>仕入単価（税抜,浮動）</summary>
        /// <remarks>※在庫評価単価</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>仕入在庫数</summary>
        /// <remarks>受託数を含まない在庫数（自社在庫）</remarks>
        private Double _supplierStock;

        /// <summary>受託数</summary>
        /// <remarks>受託している在庫数（他社在庫）</remarks>
        private Double _trustCount;

        /// <summary>受注数</summary>
        private Double _acpOdrCount;

        /// <summary>発注数</summary>
        private Double _salesOrderCount;

        /// <summary>仕入在庫分委託数</summary>
        /// <remarks>委託している在庫数（自社在庫）</remarks>
        private Double _entrustCnt;

        /// <summary>売切数</summary>
        private Double _soldCnt;

        /// <summary>移動中仕入在庫数</summary>
        /// <remarks>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</remarks>
        private Double _movingSupliStock;

        /// <summary>移動中受託在庫数</summary>
        /// <remarks>　　〃</remarks>
        private Double _movingTrustStock;

        /// <summary>出荷可能数</summary>
        /// <remarks>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－受注数</remarks>
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

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>ハイフン無商品番号</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>在庫評価率</summary>
        private Double _stockAssessmentRate;

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

        /// <summary>商品区分グループコード</summary>
        /// <remarks>旧：商品大分類コード</remarks>
        private string _largeGoodsGanreCode = "";

        /// <summary>商品区分グループ名称</summary>
        /// <remarks>旧：商品大分類名称</remarks>
        private string _largeGoodsGanreName = "";

        /// <summary>商品区分コード</summary>
        /// <remarks>旧：商品中分類コード</remarks>
        private string _mediumGoodsGanreCode = "";

        /// <summary>商品区分名称</summary>
        /// <remarks>旧：商品中分類名称</remarks>
        private string _mediumGoodsGanreName = "";

        /// <summary>商品区分詳細コード</summary>
        private string _detailGoodsGanreCode = "";

        /// <summary>商品区分詳細名称</summary>
        private string _detailGoodsGanreName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>商品名略称</summary>
        private string _goodsShortName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>自社分類名称</summary>
        private string _enterpriseGanreName = "";

        /// <summary>JANコード</summary>
        /// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
        private string _jan = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";
        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        # region [ private Fields (手動で追加) ]
        /// <summary>価格区分</summary>
        private Int32 _priceDivCd;

        /// <summary>新価格</summary>
        private Double _newPrice;

        /// <summary>新価格開始日</summary>
        private DateTime _newPriceStartDate;

        /// <summary>旧価格</summary>
        private Double _oldPrice;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
        
        /// <summary>M/O発注数</summary>
        private Double _monthOrderCount;

        /// <summary>在庫区分</summary>
        private Int32 _stockDiv;

        /// <summary>在庫発注先コード</summary>
        private Int32 _stockSupplierCode;

        /// <summary>更新年月日</summary>
        private Int32 _updateDate;


        // リモートクラスから取得はしないが表示のために保持する項目

        /// <summary>発注ロット</summary>
        private Double _supplierLot;

        /// <summary>規格・特記事項</summary>
        private string _goodsSpecialNote;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略名</summary>
        private string _supplierSnm;

        /// <summary>標準価格</summary>
        private Double _listPrice;

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
        
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        # region [ public Propaties (テーブルレイアウトより自動生成分) ]
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

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

        /// public propaty name  :  TrustCount
        /// <summary>受託数プロパティ</summary>
        /// <value>受託している在庫数（他社在庫）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受託数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TrustCount
        {
            get { return _trustCount; }
            set { _trustCount = value; }
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

        /// public propaty name  :  EntrustCnt
        /// <summary>仕入在庫分委託数プロパティ</summary>
        /// <value>委託している在庫数（自社在庫）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫分委託数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double EntrustCnt
        {
            get { return _entrustCnt; }
            set { _entrustCnt = value; }
        }

        /// public propaty name  :  SoldCnt
        /// <summary>売切数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売切数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SoldCnt
        {
            get { return _soldCnt; }
            set { _soldCnt = value; }
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

        /// public propaty name  :  MovingTrustStock
        /// <summary>移動中受託在庫数プロパティ</summary>
        /// <value>　　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動中受託在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MovingTrustStock
        {
            get { return _movingTrustStock; }
            set { _movingTrustStock = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－受注数</value>
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

        /// public propaty name  :  StockAssessmentRate
        /// <summary>在庫評価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫評価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockAssessmentRate
        {
            get { return _stockAssessmentRate; }
            set { _stockAssessmentRate = value; }
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

        /// public propaty name  :  LargeGoodsGanreCode
        /// <summary>商品区分グループコードプロパティ</summary>
        /// <value>旧：商品大分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LargeGoodsGanreCode
        {
            get { return _largeGoodsGanreCode; }
            set { _largeGoodsGanreCode = value; }
        }

        /// public propaty name  :  LargeGoodsGanreName
        /// <summary>商品区分グループ名称プロパティ</summary>
        /// <value>旧：商品大分類名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分グループ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LargeGoodsGanreName
        {
            get { return _largeGoodsGanreName; }
            set { _largeGoodsGanreName = value; }
        }

        /// public propaty name  :  MediumGoodsGanreCode
        /// <summary>商品区分コードプロパティ</summary>
        /// <value>旧：商品中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MediumGoodsGanreCode
        {
            get { return _mediumGoodsGanreCode; }
            set { _mediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  MediumGoodsGanreName
        /// <summary>商品区分名称プロパティ</summary>
        /// <value>旧：商品中分類名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MediumGoodsGanreName
        {
            get { return _mediumGoodsGanreName; }
            set { _mediumGoodsGanreName = value; }
        }

        /// public propaty name  :  DetailGoodsGanreCode
        /// <summary>商品区分詳細コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分詳細コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DetailGoodsGanreCode
        {
            get { return _detailGoodsGanreCode; }
            set { _detailGoodsGanreCode = value; }
        }

        /// public propaty name  :  DetailGoodsGanreName
        /// <summary>商品区分詳細名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分詳細名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DetailGoodsGanreName
        {
            get { return _detailGoodsGanreName; }
            set { _detailGoodsGanreName = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  GoodsShortName
        /// <summary>商品名略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsShortName
        {
            get { return _goodsShortName; }
            set { _goodsShortName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>自社分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
        }

        /// public propaty name  :  Jan
        /// <summary>JANコードプロパティ</summary>
        /// <value>標準タイプ13桁または短縮タイプ8桁のJANコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JANコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }
        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        # region [ public Propaties (手動で追加) ]
        /// public propaty name  :  PriceDivCd
        /// <summary>価格区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceDivCd
        {
            get { return _priceDivCd; }
            set { _priceDivCd = value; }
        }

        /// public propaty name  :  NewPrice
        /// <summary>新価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NewPrice
        {
            get { return _newPrice; }
            set { _newPrice = value; }
        }

        /// public propaty name  :  NewPriceStartDate
        /// <summary>新価格開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime NewPriceStartDate
        {
            get { return _newPriceStartDate; }
            set { _newPriceStartDate = value; }
        }

        /// public propaty name  :  OldPrice
        /// <summary>旧価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OldPrice
        {
            get { return _oldPrice; }
            set { _oldPrice = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START

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

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
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

        /// public propaty name  :  StockSupplierCode
        /// <summary>在庫発注先コードプロパティ</summary>
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

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateDateDT
        /// <summary>更新年月日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateDT
        {
            get { return TDateTime.LongDateToDateTime(_updateDate); 
            }
            set { _updateDate = TDateTime.DateTimeToLongDate(value); }
        }


        /// public propaty name  :  UpdateDateString
        /// <summary>更新年月日文字列プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日文字列プロパティ</br>
        /// </remarks>
        public string UpdateDateString
        {
            get { return TDateTime.DateTimeToString("yyyy/mm/dd", TDateTime.LongDateToDateTime(_updateDate)); }
        }

        /// public propaty name  :  StockCreateDateString
        /// <summary>在庫登録日文字列プロパティ</summary>
        /// <value>YYYY/MM/DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫登録日文字列プロパティ</br>
        /// </remarks>
        public string StockCreateDateString
        {
            get { return TDateTime.DateTimeToString("yyyy/mm/dd", _stockCreateDate); }
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

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
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

        /// public propaty name  :  ListPrice
        /// <summary>標準価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END

        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


        # region [ constructorとmethods (手動で変更) ]
        /// <summary>
        /// 在庫マスタコンストラクタ
        /// </summary>
        /// <returns>StockExpansionクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExpansionクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockExpansion()
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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
        /// <param name="sectionGuideNm">拠点ガイド名称</param>
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="stockUnitPriceFl">仕入単価（税抜,浮動）(※在庫評価単価)</param>
        /// <param name="supplierStock">仕入在庫数(受託数を含まない在庫数（自社在庫）)</param>
        /// <param name="trustCount">受託数(受託している在庫数（他社在庫）)</param>
        /// <param name="acpOdrCount">受注数</param>
        /// <param name="salesOrderCount">発注数</param>
        /// <param name="entrustCnt">仕入在庫分委託数(委託している在庫数（自社在庫）)</param>
        /// <param name="soldCnt">売切数</param>
        /// <param name="movingSupliStock">移動中仕入在庫数(在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。)</param>
        /// <param name="movingTrustStock">移動中受託在庫数(　　〃)</param>
        /// <param name="shipmentPosCnt">出荷可能数(出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－受注数)</param>
        /// <param name="stockTotalPrice">在庫保有総額(値引含む)</param>
        /// <param name="lastStockDate">最終仕入年月日(YYYYMMDD)</param>
        /// <param name="lastSalesDate">最終売上日(YYYYMMDD)</param>
        /// <param name="lastInventoryUpdate">最終棚卸更新日(YYYYMMDD)</param>
        /// <param name="minimumStockCnt">最低在庫数</param>
        /// <param name="maximumStockCnt">最高在庫数</param>
        /// <param name="nmlSalOdrCount">基準発注数</param>
        /// <param name="salesOrderUnit">発注単位(発注する単位の数量（１０個、２０個単位等）)</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="warehouseName">倉庫名称</param>
        /// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
        /// <param name="stockAssessmentRate">在庫評価率</param>
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
        /// <param name="largeGoodsGanreCode">商品区分グループコード(旧：商品大分類コード)</param>
        /// <param name="largeGoodsGanreName">商品区分グループ名称(旧：商品大分類名称)</param>
        /// <param name="mediumGoodsGanreCode">商品区分コード(旧：商品中分類コード)</param>
        /// <param name="mediumGoodsGanreName">商品区分名称(旧：商品中分類名称)</param>
        /// <param name="detailGoodsGanreCode">商品区分詳細コード</param>
        /// <param name="detailGoodsGanreName">商品区分詳細名称</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
        /// <param name="goodsShortName">商品名略称</param>
        /// <param name="goodsNameKana">商品名称カナ</param>
        /// <param name="enterpriseGanreCode">自社分類コード</param>
        /// <param name="enterpriseGanreName">自社分類名称</param>
        /// <param name="jan">JANコード(標準タイプ13桁または短縮タイプ8桁のJANコード)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
        /// <param name="monthOrderCount">M/O発注数</param>
        /// <param name="stockDiv">在庫区分</param>
        /// <param name="stockSupplierCode">在庫発注先コード</param>
        /// <param name="updateDate">更新年月日</param>
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
        /// <returns>StockExpansionクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExpansionクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockExpansion(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string sectionGuideNm, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, Double stockUnitPriceFl, Double supplierStock, Double trustCount, Double acpOdrCount, Double salesOrderCount, Double entrustCnt, Double soldCnt, Double movingSupliStock, Double movingTrustStock, Double shipmentPosCnt, Int64 stockTotalPrice, DateTime lastStockDate, DateTime lastSalesDate, DateTime lastInventoryUpdate, Double minimumStockCnt, Double maximumStockCnt, Double nmlSalOdrCount, Int32 salesOrderUnit, string warehouseCode, string warehouseName, string goodsNoNoneHyphen, Double stockAssessmentRate, string warehouseShelfNo, string duplicationShelfNo1, string duplicationShelfNo2, string partsManagementDivide1, string partsManagementDivide2, string stockNote1, string stockNote2, Double shipmentCnt, Double arrivalCnt, DateTime stockCreateDate, string largeGoodsGanreCode, string largeGoodsGanreName, string mediumGoodsGanreCode, string mediumGoodsGanreName, string detailGoodsGanreCode, string detailGoodsGanreName, Int32 bLGoodsCode, string bLGoodsFullName, string goodsShortName, string goodsNameKana, Int32 enterpriseGanreCode, string enterpriseGanreName, string jan, string enterpriseName, string updEmployeeName, string bLGoodsName, Int32 priceDivCd, Double newPrice, DateTime newPriceStartDate, Double oldPrice, Int32 openPriceDiv, Double monthOrderCount, Int32 stockDiv, Int32 stockSupplierCode, Int32 updateDate, double supplierLot, string goodsSpecialNote, int supplierCd, string supplierSnm, double listPrice)
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
            this._sectionGuideNm = sectionGuideNm;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._stockUnitPriceFl = stockUnitPriceFl;
            this._supplierStock = supplierStock;
            this._trustCount = trustCount;
            this._acpOdrCount = acpOdrCount;
            this._salesOrderCount = salesOrderCount;
            this._entrustCnt = entrustCnt;
            this._soldCnt = soldCnt;
            this._movingSupliStock = movingSupliStock;
            this._movingTrustStock = movingTrustStock;
            this._shipmentPosCnt = shipmentPosCnt;
            this._stockTotalPrice = stockTotalPrice;
            this.LastStockDate = lastStockDate;
            this.LastSalesDate = lastSalesDate;
            this.LastInventoryUpdate = lastInventoryUpdate;
            this._minimumStockCnt = minimumStockCnt;
            this._maximumStockCnt = maximumStockCnt;
            this._nmlSalOdrCount = nmlSalOdrCount;
            this._salesOrderUnit = salesOrderUnit;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._stockAssessmentRate = stockAssessmentRate;
            this._warehouseShelfNo = warehouseShelfNo;
            this._duplicationShelfNo1 = duplicationShelfNo1;
            this._duplicationShelfNo2 = duplicationShelfNo2;
            this._partsManagementDivide1 = partsManagementDivide1;
            this._partsManagementDivide2 = partsManagementDivide2;
            this._stockNote1 = stockNote1;
            this._stockNote2 = stockNote2;
            this._shipmentCnt = shipmentCnt;
            this._arrivalCnt = arrivalCnt;
            this._stockCreateDate = stockCreateDate;
            this._largeGoodsGanreCode = largeGoodsGanreCode;
            this._largeGoodsGanreName = largeGoodsGanreName;
            this._mediumGoodsGanreCode = mediumGoodsGanreCode;
            this._mediumGoodsGanreName = mediumGoodsGanreName;
            this._detailGoodsGanreCode = detailGoodsGanreCode;
            this._detailGoodsGanreName = detailGoodsGanreName;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._goodsShortName = goodsShortName;
            this._goodsNameKana = goodsNameKana;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._enterpriseGanreName = enterpriseGanreName;
            this._jan = jan;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._priceDivCd = priceDivCd;
            this._newPrice = newPrice;
            this._newPriceStartDate = newPriceStartDate;
            this._oldPrice = oldPrice;
            this._openPriceDiv = openPriceDiv;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
            this._monthOrderCount = monthOrderCount;
            this._stockDiv = stockDiv;
            this._stockSupplierCode = stockSupplierCode;
            this._updateDate = updateDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
            _supplierLot = supplierLot;
            //_goodsSpecialNote = GoodsSpecialNote;         //DEL 2009/04/01 不具合対応[12836]
            _goodsSpecialNote = goodsSpecialNote;           //ADD 2009/04/01 不具合対応[12836]
            _supplierCd = supplierCd;
            _supplierSnm = supplierSnm;
            _listPrice = listPrice;
        }

        /// <summary>
        /// 在庫マスタ複製処理
        /// </summary>
        /// <returns>StockExpansionクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockExpansionクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockExpansion Clone()
        {
            return new StockExpansion(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._sectionGuideNm, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._stockUnitPriceFl, this._supplierStock, this._trustCount, this._acpOdrCount, this._salesOrderCount, this._entrustCnt, this._soldCnt, this._movingSupliStock, this._movingTrustStock, this._shipmentPosCnt, this._stockTotalPrice, this._lastStockDate, this._lastSalesDate, this._lastInventoryUpdate, this._minimumStockCnt, this._maximumStockCnt, this._nmlSalOdrCount, this._salesOrderUnit, this._warehouseCode, this._warehouseName, this._goodsNoNoneHyphen, this._stockAssessmentRate, this._warehouseShelfNo, this._duplicationShelfNo1, this._duplicationShelfNo2, this._partsManagementDivide1, this._partsManagementDivide2, this._stockNote1, this._stockNote2, this._shipmentCnt, this._arrivalCnt, this._stockCreateDate, this._largeGoodsGanreCode, this._largeGoodsGanreName, this._mediumGoodsGanreCode, this._mediumGoodsGanreName, this._detailGoodsGanreCode, this._detailGoodsGanreName, this._bLGoodsCode, this._bLGoodsFullName, this._goodsShortName, this._goodsNameKana, this._enterpriseGanreCode, this._enterpriseGanreName, this._jan, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._priceDivCd, this._newPrice, this._newPriceStartDate, this._oldPrice, this._openPriceDiv, this._monthOrderCount, this._stockDiv, this._stockSupplierCode, this._updateDate, _supplierLot, _goodsSpecialNote, _supplierCd, _supplierSnm, _listPrice);
        }

        /// <summary>
        /// 在庫マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockExpansionクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExpansionクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockExpansion target)
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
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                 && (this.SectionGuideNm == target.SectionGuideNm)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
                 && (this.SupplierStock == target.SupplierStock)
                 && (this.TrustCount == target.TrustCount)
                 && (this.AcpOdrCount == target.AcpOdrCount)
                 && (this.SalesOrderCount == target.SalesOrderCount)
                 && (this.EntrustCnt == target.EntrustCnt)
                 && (this.SoldCnt == target.SoldCnt)
                 && (this.MovingSupliStock == target.MovingSupliStock)
                 && (this.MovingTrustStock == target.MovingTrustStock)
                 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
                 && (this.StockTotalPrice == target.StockTotalPrice)
                 && (this.LastStockDate == target.LastStockDate)
                 && (this.LastSalesDate == target.LastSalesDate)
                 && (this.LastInventoryUpdate == target.LastInventoryUpdate)
                 && (this.MinimumStockCnt == target.MinimumStockCnt)
                 && (this.MaximumStockCnt == target.MaximumStockCnt)
                 && (this.NmlSalOdrCount == target.NmlSalOdrCount)
                 && (this.SalesOrderUnit == target.SalesOrderUnit)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.StockAssessmentRate == target.StockAssessmentRate)
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
                 && (this.LargeGoodsGanreCode == target.LargeGoodsGanreCode)
                 && (this.LargeGoodsGanreName == target.LargeGoodsGanreName)
                 && (this.MediumGoodsGanreCode == target.MediumGoodsGanreCode)
                 && (this.MediumGoodsGanreName == target.MediumGoodsGanreName)
                 && (this.DetailGoodsGanreCode == target.DetailGoodsGanreCode)
                 && (this.DetailGoodsGanreName == target.DetailGoodsGanreName)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.GoodsShortName == target.GoodsShortName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
                 && (this.Jan == target.Jan)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (this.PriceDivCd == target.PriceDivCd)
                 && (this.NewPrice == target.NewPrice)
                 && (this.NewPriceStartDate == target.NewPriceStartDate)
                 && (this.OldPrice == target.OldPrice)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
                 && (this.MonthOrderCount == target.MonthOrderCount)
                 && (this.StockDiv == target.StockDiv)
                 && (this.StockSupplierCode == target.StockSupplierCode)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.SupplierLot == target.SupplierLot)
                 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.ListPrice == target.ListPrice)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
                 );
        }

        /// <summary>
        /// 在庫マスタ比較処理
        /// </summary>
        /// <param name="stockExpansion1">
        ///                    比較するStockExpansionクラスのインスタンス
        /// </param>
        /// <param name="stockExpansion2">比較するStockExpansionクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExpansionクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockExpansion stockExpansion1, StockExpansion stockExpansion2)
        {
            return ((stockExpansion1.CreateDateTime == stockExpansion2.CreateDateTime)
                 && (stockExpansion1.UpdateDateTime == stockExpansion2.UpdateDateTime)
                 && (stockExpansion1.EnterpriseCode == stockExpansion2.EnterpriseCode)
                 && (stockExpansion1.FileHeaderGuid == stockExpansion2.FileHeaderGuid)
                 && (stockExpansion1.UpdEmployeeCode == stockExpansion2.UpdEmployeeCode)
                 && (stockExpansion1.UpdAssemblyId1 == stockExpansion2.UpdAssemblyId1)
                 && (stockExpansion1.UpdAssemblyId2 == stockExpansion2.UpdAssemblyId2)
                 && (stockExpansion1.LogicalDeleteCode == stockExpansion2.LogicalDeleteCode)
                 && (stockExpansion1.SectionCode == stockExpansion2.SectionCode)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                 && (stockExpansion1.SectionGuideNm == stockExpansion2.SectionGuideNm)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
                 && (stockExpansion1.GoodsMakerCd == stockExpansion2.GoodsMakerCd)
                 && (stockExpansion1.MakerName == stockExpansion2.MakerName)
                 && (stockExpansion1.GoodsNo == stockExpansion2.GoodsNo)
                 && (stockExpansion1.GoodsName == stockExpansion2.GoodsName)
                 && (stockExpansion1.StockUnitPriceFl == stockExpansion2.StockUnitPriceFl)
                 && (stockExpansion1.SupplierStock == stockExpansion2.SupplierStock)
                 && (stockExpansion1.TrustCount == stockExpansion2.TrustCount)
                 && (stockExpansion1.AcpOdrCount == stockExpansion2.AcpOdrCount)
                 && (stockExpansion1.SalesOrderCount == stockExpansion2.SalesOrderCount)
                 && (stockExpansion1.EntrustCnt == stockExpansion2.EntrustCnt)
                 && (stockExpansion1.SoldCnt == stockExpansion2.SoldCnt)
                 && (stockExpansion1.MovingSupliStock == stockExpansion2.MovingSupliStock)
                 && (stockExpansion1.MovingTrustStock == stockExpansion2.MovingTrustStock)
                 && (stockExpansion1.ShipmentPosCnt == stockExpansion2.ShipmentPosCnt)
                 && (stockExpansion1.StockTotalPrice == stockExpansion2.StockTotalPrice)
                 && (stockExpansion1.LastStockDate == stockExpansion2.LastStockDate)
                 && (stockExpansion1.LastSalesDate == stockExpansion2.LastSalesDate)
                 && (stockExpansion1.LastInventoryUpdate == stockExpansion2.LastInventoryUpdate)
                 && (stockExpansion1.MinimumStockCnt == stockExpansion2.MinimumStockCnt)
                 && (stockExpansion1.MaximumStockCnt == stockExpansion2.MaximumStockCnt)
                 && (stockExpansion1.NmlSalOdrCount == stockExpansion2.NmlSalOdrCount)
                 && (stockExpansion1.SalesOrderUnit == stockExpansion2.SalesOrderUnit)
                 && (stockExpansion1.WarehouseCode == stockExpansion2.WarehouseCode)
                 && (stockExpansion1.WarehouseName == stockExpansion2.WarehouseName)
                 && (stockExpansion1.GoodsNoNoneHyphen == stockExpansion2.GoodsNoNoneHyphen)
                 && (stockExpansion1.StockAssessmentRate == stockExpansion2.StockAssessmentRate)
                 && (stockExpansion1.WarehouseShelfNo == stockExpansion2.WarehouseShelfNo)
                 && (stockExpansion1.DuplicationShelfNo1 == stockExpansion2.DuplicationShelfNo1)
                 && (stockExpansion1.DuplicationShelfNo2 == stockExpansion2.DuplicationShelfNo2)
                 && (stockExpansion1.PartsManagementDivide1 == stockExpansion2.PartsManagementDivide1)
                 && (stockExpansion1.PartsManagementDivide2 == stockExpansion2.PartsManagementDivide2)
                 && (stockExpansion1.StockNote1 == stockExpansion2.StockNote1)
                 && (stockExpansion1.StockNote2 == stockExpansion2.StockNote2)
                 && (stockExpansion1.ShipmentCnt == stockExpansion2.ShipmentCnt)
                 && (stockExpansion1.ArrivalCnt == stockExpansion2.ArrivalCnt)
                 && (stockExpansion1.StockCreateDate == stockExpansion2.StockCreateDate)
                 && (stockExpansion1.LargeGoodsGanreCode == stockExpansion2.LargeGoodsGanreCode)
                 && (stockExpansion1.LargeGoodsGanreName == stockExpansion2.LargeGoodsGanreName)
                 && (stockExpansion1.MediumGoodsGanreCode == stockExpansion2.MediumGoodsGanreCode)
                 && (stockExpansion1.MediumGoodsGanreName == stockExpansion2.MediumGoodsGanreName)
                 && (stockExpansion1.DetailGoodsGanreCode == stockExpansion2.DetailGoodsGanreCode)
                 && (stockExpansion1.DetailGoodsGanreName == stockExpansion2.DetailGoodsGanreName)
                 && (stockExpansion1.BLGoodsCode == stockExpansion2.BLGoodsCode)
                 && (stockExpansion1.BLGoodsFullName == stockExpansion2.BLGoodsFullName)
                 && (stockExpansion1.GoodsShortName == stockExpansion2.GoodsShortName)
                 && (stockExpansion1.GoodsNameKana == stockExpansion2.GoodsNameKana)
                 && (stockExpansion1.EnterpriseGanreCode == stockExpansion2.EnterpriseGanreCode)
                 && (stockExpansion1.EnterpriseGanreName == stockExpansion2.EnterpriseGanreName)
                 && (stockExpansion1.Jan == stockExpansion2.Jan)
                 && (stockExpansion1.EnterpriseName == stockExpansion2.EnterpriseName)
                 && (stockExpansion1.UpdEmployeeName == stockExpansion2.UpdEmployeeName)
                 && (stockExpansion1.BLGoodsName == stockExpansion2.BLGoodsName)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (stockExpansion1.PriceDivCd == stockExpansion2.PriceDivCd)
                 && (stockExpansion1.NewPrice == stockExpansion2.NewPrice)
                 && (stockExpansion1.NewPriceStartDate == stockExpansion2.NewPriceStartDate)
                 && (stockExpansion1.OldPrice == stockExpansion2.OldPrice)
                 && (stockExpansion1.OpenPriceDiv == stockExpansion2.OpenPriceDiv)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
                 && (stockExpansion1.MonthOrderCount == stockExpansion2.MonthOrderCount)
                 && (stockExpansion1.StockDiv == stockExpansion2.StockDiv)
                 && (stockExpansion1.StockSupplierCode == stockExpansion2.StockSupplierCode)
                 && (stockExpansion1.UpdateDate == stockExpansion2.UpdateDate)
                 && (stockExpansion1.SupplierLot == stockExpansion2.SupplierLot)
                 && (stockExpansion1.GoodsSpecialNote == stockExpansion2.GoodsSpecialNote)
                 && (stockExpansion1.SupplierSnm == stockExpansion2.SupplierSnm)
                 && (stockExpansion1.SupplierCd == stockExpansion2.SupplierCd)
                 && (stockExpansion1.ListPrice == stockExpansion2.ListPrice)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
                 );
        }
        /// <summary>
        /// 在庫マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockExpansionクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExpansionクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockExpansion target)
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
            if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.StockUnitPriceFl != target.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (this.SupplierStock != target.SupplierStock) resList.Add("SupplierStock");
            if (this.TrustCount != target.TrustCount) resList.Add("TrustCount");
            if (this.AcpOdrCount != target.AcpOdrCount) resList.Add("AcpOdrCount");
            if (this.SalesOrderCount != target.SalesOrderCount) resList.Add("SalesOrderCount");
            if (this.EntrustCnt != target.EntrustCnt) resList.Add("EntrustCnt");
            if (this.SoldCnt != target.SoldCnt) resList.Add("SoldCnt");
            if (this.MovingSupliStock != target.MovingSupliStock) resList.Add("MovingSupliStock");
            if (this.MovingTrustStock != target.MovingTrustStock) resList.Add("MovingTrustStock");
            if (this.ShipmentPosCnt != target.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (this.StockTotalPrice != target.StockTotalPrice) resList.Add("StockTotalPrice");
            if (this.LastStockDate != target.LastStockDate) resList.Add("LastStockDate");
            if (this.LastSalesDate != target.LastSalesDate) resList.Add("LastSalesDate");
            if (this.LastInventoryUpdate != target.LastInventoryUpdate) resList.Add("LastInventoryUpdate");
            if (this.MinimumStockCnt != target.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (this.MaximumStockCnt != target.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (this.NmlSalOdrCount != target.NmlSalOdrCount) resList.Add("NmlSalOdrCount");
            if (this.SalesOrderUnit != target.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.StockAssessmentRate != target.StockAssessmentRate) resList.Add("StockAssessmentRate");
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
            if (this.LargeGoodsGanreCode != target.LargeGoodsGanreCode) resList.Add("LargeGoodsGanreCode");
            if (this.LargeGoodsGanreName != target.LargeGoodsGanreName) resList.Add("LargeGoodsGanreName");
            if (this.MediumGoodsGanreCode != target.MediumGoodsGanreCode) resList.Add("MediumGoodsGanreCode");
            if (this.MediumGoodsGanreName != target.MediumGoodsGanreName) resList.Add("MediumGoodsGanreName");
            if (this.DetailGoodsGanreCode != target.DetailGoodsGanreCode) resList.Add("DetailGoodsGanreCode");
            if (this.DetailGoodsGanreName != target.DetailGoodsGanreName) resList.Add("DetailGoodsGanreName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.GoodsShortName != target.GoodsShortName) resList.Add("GoodsShortName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.EnterpriseGanreName != target.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (this.Jan != target.Jan) resList.Add("Jan");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if (this.PriceDivCd != target.PriceDivCd) resList.Add("PriceDivCd");
            if (this.NewPrice != target.NewPrice) resList.Add("NewPrice");
            if (this.NewPriceStartDate != target.NewPriceStartDate) resList.Add("NewPriceStartDate");
            if (this.OldPrice != target.OldPrice) resList.Add("OldPrice");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
            if (this.MonthOrderCount != target.MonthOrderCount) resList.Add("MonthOrderCount");
            if (this.StockDiv != target.StockDiv) resList.Add("StockDiv");
            if (this.StockSupplierCode != target.StockSupplierCode) resList.Add("StockSupplierCode");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.SupplierLot != target.SupplierLot) resList.Add("SupplierLot");
            if (this.GoodsSpecialNote != target.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END

            return resList;
        }

        /// <summary>
        /// 在庫マスタ比較処理
        /// </summary>
        /// <param name="stockExpansion1">比較するStockExpansionクラスのインスタンス</param>
        /// <param name="stockExpansion2">比較するStockExpansionクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExpansionクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockExpansion stockExpansion1, StockExpansion stockExpansion2)
        {
            ArrayList resList = new ArrayList();
            if (stockExpansion1.CreateDateTime != stockExpansion2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockExpansion1.UpdateDateTime != stockExpansion2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockExpansion1.EnterpriseCode != stockExpansion2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockExpansion1.FileHeaderGuid != stockExpansion2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockExpansion1.UpdEmployeeCode != stockExpansion2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockExpansion1.UpdAssemblyId1 != stockExpansion2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockExpansion1.UpdAssemblyId2 != stockExpansion2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockExpansion1.LogicalDeleteCode != stockExpansion2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockExpansion1.SectionCode != stockExpansion2.SectionCode) resList.Add("SectionCode");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
            if (stockExpansion1.SectionGuideNm != stockExpansion2.SectionGuideNm) resList.Add("SectionGuideNm");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
            if (stockExpansion1.GoodsMakerCd != stockExpansion2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stockExpansion1.MakerName != stockExpansion2.MakerName) resList.Add("MakerName");
            if (stockExpansion1.GoodsNo != stockExpansion2.GoodsNo) resList.Add("GoodsNo");
            if (stockExpansion1.GoodsName != stockExpansion2.GoodsName) resList.Add("GoodsName");
            if (stockExpansion1.StockUnitPriceFl != stockExpansion2.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (stockExpansion1.SupplierStock != stockExpansion2.SupplierStock) resList.Add("SupplierStock");
            if (stockExpansion1.TrustCount != stockExpansion2.TrustCount) resList.Add("TrustCount");
            if (stockExpansion1.AcpOdrCount != stockExpansion2.AcpOdrCount) resList.Add("AcpOdrCount");
            if (stockExpansion1.SalesOrderCount != stockExpansion2.SalesOrderCount) resList.Add("SalesOrderCount");
            if (stockExpansion1.EntrustCnt != stockExpansion2.EntrustCnt) resList.Add("EntrustCnt");
            if (stockExpansion1.SoldCnt != stockExpansion2.SoldCnt) resList.Add("SoldCnt");
            if (stockExpansion1.MovingSupliStock != stockExpansion2.MovingSupliStock) resList.Add("MovingSupliStock");
            if (stockExpansion1.MovingTrustStock != stockExpansion2.MovingTrustStock) resList.Add("MovingTrustStock");
            if (stockExpansion1.ShipmentPosCnt != stockExpansion2.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (stockExpansion1.StockTotalPrice != stockExpansion2.StockTotalPrice) resList.Add("StockTotalPrice");
            if (stockExpansion1.LastStockDate != stockExpansion2.LastStockDate) resList.Add("LastStockDate");
            if (stockExpansion1.LastSalesDate != stockExpansion2.LastSalesDate) resList.Add("LastSalesDate");
            if (stockExpansion1.LastInventoryUpdate != stockExpansion2.LastInventoryUpdate) resList.Add("LastInventoryUpdate");
            if (stockExpansion1.MinimumStockCnt != stockExpansion2.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (stockExpansion1.MaximumStockCnt != stockExpansion2.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (stockExpansion1.NmlSalOdrCount != stockExpansion2.NmlSalOdrCount) resList.Add("NmlSalOdrCount");
            if (stockExpansion1.SalesOrderUnit != stockExpansion2.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (stockExpansion1.WarehouseCode != stockExpansion2.WarehouseCode) resList.Add("WarehouseCode");
            if (stockExpansion1.WarehouseName != stockExpansion2.WarehouseName) resList.Add("WarehouseName");
            if (stockExpansion1.GoodsNoNoneHyphen != stockExpansion2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (stockExpansion1.StockAssessmentRate != stockExpansion2.StockAssessmentRate) resList.Add("StockAssessmentRate");
            if (stockExpansion1.WarehouseShelfNo != stockExpansion2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stockExpansion1.DuplicationShelfNo1 != stockExpansion2.DuplicationShelfNo1) resList.Add("DuplicationShelfNo1");
            if (stockExpansion1.DuplicationShelfNo2 != stockExpansion2.DuplicationShelfNo2) resList.Add("DuplicationShelfNo2");
            if (stockExpansion1.PartsManagementDivide1 != stockExpansion2.PartsManagementDivide1) resList.Add("PartsManagementDivide1");
            if (stockExpansion1.PartsManagementDivide2 != stockExpansion2.PartsManagementDivide2) resList.Add("PartsManagementDivide2");
            if (stockExpansion1.StockNote1 != stockExpansion2.StockNote1) resList.Add("StockNote1");
            if (stockExpansion1.StockNote2 != stockExpansion2.StockNote2) resList.Add("StockNote2");
            if (stockExpansion1.ShipmentCnt != stockExpansion2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (stockExpansion1.ArrivalCnt != stockExpansion2.ArrivalCnt) resList.Add("ArrivalCnt");
            if (stockExpansion1.StockCreateDate != stockExpansion2.StockCreateDate) resList.Add("StockCreateDate");
            if (stockExpansion1.LargeGoodsGanreCode != stockExpansion2.LargeGoodsGanreCode) resList.Add("LargeGoodsGanreCode");
            if (stockExpansion1.LargeGoodsGanreName != stockExpansion2.LargeGoodsGanreName) resList.Add("LargeGoodsGanreName");
            if (stockExpansion1.MediumGoodsGanreCode != stockExpansion2.MediumGoodsGanreCode) resList.Add("MediumGoodsGanreCode");
            if (stockExpansion1.MediumGoodsGanreName != stockExpansion2.MediumGoodsGanreName) resList.Add("MediumGoodsGanreName");
            if (stockExpansion1.DetailGoodsGanreCode != stockExpansion2.DetailGoodsGanreCode) resList.Add("DetailGoodsGanreCode");
            if (stockExpansion1.DetailGoodsGanreName != stockExpansion2.DetailGoodsGanreName) resList.Add("DetailGoodsGanreName");
            if (stockExpansion1.BLGoodsCode != stockExpansion2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (stockExpansion1.BLGoodsFullName != stockExpansion2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (stockExpansion1.GoodsShortName != stockExpansion2.GoodsShortName) resList.Add("GoodsShortName");
            if (stockExpansion1.GoodsNameKana != stockExpansion2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (stockExpansion1.EnterpriseGanreCode != stockExpansion2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (stockExpansion1.EnterpriseGanreName != stockExpansion2.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (stockExpansion1.Jan != stockExpansion2.Jan) resList.Add("Jan");
            if (stockExpansion1.EnterpriseName != stockExpansion2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockExpansion1.UpdEmployeeName != stockExpansion2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stockExpansion1.BLGoodsName != stockExpansion2.BLGoodsName) resList.Add("BLGoodsName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if (stockExpansion1.PriceDivCd != stockExpansion2.PriceDivCd) resList.Add("PriceDivCd");
            if (stockExpansion1.NewPrice != stockExpansion2.NewPrice) resList.Add("NewPrice");
            if (stockExpansion1.NewPriceStartDate != stockExpansion2.NewPriceStartDate) resList.Add("NewPriceStartDate");
            if (stockExpansion1.OldPrice != stockExpansion2.OldPrice) resList.Add("OldPrice");
            if (stockExpansion1.OpenPriceDiv != stockExpansion2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
            if (stockExpansion1.MonthOrderCount != stockExpansion2.MonthOrderCount) resList.Add("MonthOrderCount");
            if (stockExpansion1.StockDiv != stockExpansion2.StockDiv) resList.Add("StockDiv");
            if (stockExpansion1.StockSupplierCode != stockExpansion2.StockSupplierCode) resList.Add("StockSupplierCode");
            if (stockExpansion1.UpdateDate != stockExpansion2.UpdateDate) resList.Add("UpdateDate");
            if (stockExpansion1.SupplierLot != stockExpansion2.SupplierLot) resList.Add("SupplierLot");
            if (stockExpansion1.GoodsSpecialNote != stockExpansion2.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (stockExpansion1.SupplierSnm != stockExpansion2.SupplierSnm) resList.Add("SupplierSnm");
            if (stockExpansion1.SupplierCd != stockExpansion2.SupplierCd) resList.Add("SupplierCd");
            if (stockExpansion1.ListPrice != stockExpansion2.ListPrice) resList.Add("ListPrice");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END

            return resList;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
        /// <summary>
        /// StockExpantionオブジェクトをStockオブジェクトに変換
        /// </summary>
        /// <param name="stockEx"></param>
        /// <returns></returns>
        public static Stock ConvertToStock(StockExpansion stockEx)
        {
            return new Stock(stockEx.CreateDateTime,
                        stockEx.UpdateDateTime,
                        stockEx.EnterpriseCode,
                        stockEx.FileHeaderGuid,
                        stockEx.UpdEmployeeCode,
                        stockEx.UpdAssemblyId1,
                        stockEx.UpdAssemblyId2,
                        stockEx.LogicalDeleteCode,
                        stockEx.SectionCode,
                        stockEx.WarehouseCode,
                        stockEx.GoodsMakerCd,
                        stockEx.GoodsNo,
                        stockEx.StockUnitPriceFl,
                        stockEx.SupplierStock,
                        stockEx.AcpOdrCount,
                        stockEx.MonthOrderCount,
                        stockEx.SalesOrderCount,
                        stockEx.StockDiv,
                        stockEx.MovingSupliStock,
                        stockEx.ShipmentPosCnt,
                        stockEx.StockTotalPrice,
                        stockEx.LastStockDate,
                        stockEx.LastSalesDate,
                        stockEx.LastInventoryUpdate,
                        stockEx.MinimumStockCnt,
                        stockEx.MaximumStockCnt,
                        stockEx.NmlSalOdrCount,
                        stockEx.SalesOrderUnit,
                        stockEx.StockSupplierCode,
                        stockEx.GoodsNoNoneHyphen,
                        stockEx.WarehouseShelfNo,
                        stockEx.DuplicationShelfNo1,
                        stockEx.DuplicationShelfNo2,
                        stockEx.PartsManagementDivide1,
                        stockEx.PartsManagementDivide2,
                        stockEx.StockNote1,
                        stockEx.StockNote2,
                        stockEx.ShipmentCnt,
                        stockEx.ArrivalCnt,
                        stockEx.StockCreateDate,
                        stockEx.UpdateDateDT,
                        stockEx.EnterpriseName,
                        stockEx.UpdEmployeeName,
                        stockEx.WarehouseName,
                        stockEx.GoodsName,
                        stockEx.MakerName,
                        stockEx.GoodsSpecialNote,
                        stockEx.SupplierCd,
                        stockEx.SupplierLot,
                        stockEx.SupplierSnm
                        );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
        # endregion

    }
}
