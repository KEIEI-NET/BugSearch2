using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventoryDataWork
    /// <summary>
    ///                      棚卸データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   棚卸データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/7/18</br>
    /// <br>Genarated Date   :   2008/03/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/2/25  杉村</br>
    /// <br>                 :   下記項目の追加</br>
    /// <br>                 :   棚卸日，在庫総数（実施日），過不足更新区分</br>
    /// <br>                 :   下記項目の補足説明修正</br>
    /// <br>                 :   棚卸在庫数：「入力数」→「棚卸数」に変更</br>
    /// <br>                 :   棚卸過不足数：「棚卸在庫数－実施日帳簿数」で算出する</br>
    /// <br>                 :   棚卸準備処理日付：棚卸準備処理を処理した日付をセット</br>
    /// <br>                 :   棚卸準備処理時刻：棚卸準備処理を処理した時刻をセット</br>
    /// <br>                 :   棚卸実施日：「棚卸日」→「棚卸実施日をセット」に変更</br>
    /// <br>Update Note      :   2009/11/30 張凱 保守依頼③対応</br>
    /// <br>                     移動中仕入在庫数、出荷数（未計上）、入荷数（未計上）を追加</br>
    /// <br>Update Note      : 2012/06/08 yangyi</br>
    /// <br>管理番号         : 10801804-00 2012/06/27配信分</br>
    /// <br>                 Redmine#30282 №1002 棚卸準備処理の改良の対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventoryDataWork : IFileHeader
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

        /// <summary>棚卸通番</summary>
        private Int32 _inventorySeqNo;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>重複棚番１</summary>
        private string _duplicationShelfNo1 = "";

        /// <summary>重複棚番２</summary>
        private string _duplicationShelfNo2 = "";

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類（マスタ有）</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入を行った仕入先コードをセット</remarks>
        private Int32 _supplierCd;

        /// <summary>JANコード</summary>
        /// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
        private string _jan = "";

        /// <summary>仕入単価(浮動)</summary>
        /// <remarks>税抜き </remarks>
        private Double _stockUnitPriceFl;

        /// <summary>変更前仕入単価（浮動）</summary>
        /// <remarks>初期値は準備処理をした時の仕入単価</remarks>
        private Double _bfStockUnitPriceFl;

        /// <summary>仕入単価変更フラグ</summary>
        /// <remarks>0:無し,1:有り</remarks>
        private Int32 _stkUnitPriceChgFlg;

        /// <summary>在庫区分</summary>
        /// <remarks>0:自社,1:受託</remarks>
        private Int32 _stockDiv;

        /// <summary>最終仕入年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastStockDate;

        /// <summary>在庫総数</summary>
        /// <remarks>帳簿数</remarks>
        private Double _stockTotal;

        /// <summary>出荷先得意先コード</summary>
        /// <remarks>委託・売切り時の得意先コード</remarks>
        private Int32 _shipCustomerCode;

        /// <summary>棚卸在庫数</summary>
        /// <remarks>棚卸数</remarks>
        private Double _inventoryStockCnt;

        /// <summary>棚卸過不足数</summary>
        /// <remarks>「棚卸在庫数－実施日帳簿数」で算出する</remarks>
        private Double _inventoryTolerancCnt;

        /// <summary>棚卸準備処理日付</summary>
        /// <remarks>棚卸準備処理を処理した日付をセット</remarks>
        private DateTime _inventoryPreprDay;

        /// <summary>棚卸準備処理時間</summary>
        /// <remarks>棚卸準備処理を処理した時刻をセット</remarks>
        private Int32 _inventoryPreprTim;

        /// <summary>棚卸実施日</summary>
        /// <remarks>棚卸実施日をセット</remarks>
        private DateTime _inventoryDay;

        /// <summary>最終棚卸更新日</summary>
        private DateTime _lastInventoryUpdate;

        /// <summary>棚卸新規追加区分</summary>
        /// <remarks>0:自動作成(準備処理),1:新規作成(マスメン）</remarks>
        private Int32 _inventoryNewDiv;

        /// <summary>マシン在庫額</summary>
        /// <remarks>※在庫総数×仕入単価</remarks>
        private Int64 _stockMashinePrice;

        /// <summary>棚卸在庫額</summary>
        /// <remarks>※棚卸在庫数×仕入単価</remarks>
        private Int64 _inventoryStockPrice;

        /// <summary>棚卸過不足金額</summary>
        /// <remarks>※棚卸過不足数×仕入単価</remarks>
        private Int64 _inventoryTlrncPrice;

        /// <summary>棚卸日</summary>
        /// <remarks>棚卸日をセット</remarks>
        private DateTime _inventoryDate;

        /// <summary>在庫総数（実施日）</summary>
        /// <remarks>棚卸実施日で算出した在庫数をセット</remarks>
        private Double _stockTotalExec;

        /// <summary>過不足更新区分</summary>
        /// <remarks>0:未更新　1:更新</remarks>
        private Int32 _toleranceUpdateCd;

        /// <summary>調整用計算原価</summary>
        private Double _adjstCalcCost;

        // --- ADD 2009/11/30 ---------->>>>>
        /// <summary>移動中仕入在庫数</summary>
        private Double _movingSupliStock;

        /// <summary>出荷数（未計上）</summary>
        private Double _shipmentCnt;

        /// <summary>入荷数（未計上）</summary>
        private Double _arrivalCnt;
        // --- ADD 2009/11/30 ----------<<<<<

        //-----ADD 2011/01/11 ----->>>>>
        /// <summary>定価（浮動）</summary>
        private Double _listPriceFl;

        /// <summary>処理前の商品番号</summary>
        private string _goodsNoSrc = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";
        //-----ADD 2011/01/11 -----<<<<<

        //-----ADD 2012/06/08----->>>>>
        /// <summary>開始管理拠点コード</summary>
        private string _sectionCodeSt = "";

        /// <summary>終了管理拠点コード</summary>
        private string _sectionCodeEd = "";
        //-----ADD 2012/06/08-----<<<<<

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

        /// public propaty name  :  InventorySeqNo
        /// <summary>棚卸通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventorySeqNo
        {
            get { return _inventorySeqNo; }
            set { _inventorySeqNo = value; }
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

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>旧大分類（ユーザーガイド）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>旧中分類（マスタ有）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
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

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入を行った仕入先コードをセット</value>
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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価(浮動)プロパティ</summary>
        /// <value>税抜き </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価(浮動)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>変更前仕入単価（浮動）プロパティ</summary>
        /// <value>初期値は準備処理をした時の仕入単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前仕入単価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  StkUnitPriceChgFlg
        /// <summary>仕入単価変更フラグプロパティ</summary>
        /// <value>0:無し,1:有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価変更フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StkUnitPriceChgFlg
        {
            get { return _stkUnitPriceChgFlg; }
            set { _stkUnitPriceChgFlg = value; }
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

        /// public propaty name  :  StockTotal
        /// <summary>在庫総数プロパティ</summary>
        /// <value>帳簿数</value>
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

        /// public propaty name  :  ShipCustomerCode
        /// <summary>出荷先得意先コードプロパティ</summary>
        /// <value>委託・売切り時の得意先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷先得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipCustomerCode
        {
            get { return _shipCustomerCode; }
            set { _shipCustomerCode = value; }
        }

        /// public propaty name  :  InventoryStockCnt
        /// <summary>棚卸在庫数プロパティ</summary>
        /// <value>棚卸数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double InventoryStockCnt
        {
            get { return _inventoryStockCnt; }
            set { _inventoryStockCnt = value; }
        }

        /// public propaty name  :  InventoryTolerancCnt
        /// <summary>棚卸過不足数プロパティ</summary>
        /// <value>「棚卸在庫数－実施日帳簿数」で算出する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸過不足数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double InventoryTolerancCnt
        {
            get { return _inventoryTolerancCnt; }
            set { _inventoryTolerancCnt = value; }
        }

        /// public propaty name  :  InventoryPreprDay
        /// <summary>棚卸準備処理日付プロパティ</summary>
        /// <value>棚卸準備処理を処理した日付をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸準備処理日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InventoryPreprDay
        {
            get { return _inventoryPreprDay; }
            set { _inventoryPreprDay = value; }
        }

        /// public propaty name  :  InventoryPreprTim
        /// <summary>棚卸準備処理時間プロパティ</summary>
        /// <value>棚卸準備処理を処理した時刻をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸準備処理時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryPreprTim
        {
            get { return _inventoryPreprTim; }
            set { _inventoryPreprTim = value; }
        }

        /// public propaty name  :  InventoryDay
        /// <summary>棚卸実施日プロパティ</summary>
        /// <value>棚卸実施日をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸実施日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InventoryDay
        {
            get { return _inventoryDay; }
            set { _inventoryDay = value; }
        }

        /// public propaty name  :  LastInventoryUpdate
        /// <summary>最終棚卸更新日プロパティ</summary>
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

        /// public propaty name  :  InventoryNewDiv
        /// <summary>棚卸新規追加区分プロパティ</summary>
        /// <value>0:自動作成(準備処理),1:新規作成(マスメン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸新規追加区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryNewDiv
        {
            get { return _inventoryNewDiv; }
            set { _inventoryNewDiv = value; }
        }

        /// public propaty name  :  StockMashinePrice
        /// <summary>マシン在庫額プロパティ</summary>
        /// <value>※在庫総数×仕入単価</value>
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

        /// public propaty name  :  InventoryStockPrice
        /// <summary>棚卸在庫額プロパティ</summary>
        /// <value>※棚卸在庫数×仕入単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸在庫額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 InventoryStockPrice
        {
            get { return _inventoryStockPrice; }
            set { _inventoryStockPrice = value; }
        }

        /// public propaty name  :  InventoryTlrncPrice
        /// <summary>棚卸過不足金額プロパティ</summary>
        /// <value>※棚卸過不足数×仕入単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸過不足金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 InventoryTlrncPrice
        {
            get { return _inventoryTlrncPrice; }
            set { _inventoryTlrncPrice = value; }
        }

        /// public propaty name  :  InventoryDate
        /// <summary>棚卸日プロパティ</summary>
        /// <value>棚卸日をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InventoryDate
        {
            get { return _inventoryDate; }
            set { _inventoryDate = value; }
        }

        /// public propaty name  :  StockTotalExec
        /// <summary>在庫総数（実施日）プロパティ</summary>
        /// <value>棚卸実施日で算出した在庫数をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫総数（実施日）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockTotalExec
        {
            get { return _stockTotalExec; }
            set { _stockTotalExec = value; }
        }

        /// public propaty name  :  ToleranceUpdateCd
        /// <summary>過不足更新区分プロパティ</summary>
        /// <value>0:未更新　1:更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   過不足更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ToleranceUpdateCd
        {
            get { return _toleranceUpdateCd; }
            set { _toleranceUpdateCd = value; }
        }

        /// public propaty name  :  AdjstCalcCost
        /// <summary>調整用計算原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整用計算原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AdjstCalcCost
        {
            get { return _adjstCalcCost; }
            set { _adjstCalcCost = value; }
        }

        // --- ADD 2009/11/30 ---------->>>>>
        /// public propaty name  :  MovingSupliStock
        /// <summary>移動中仕入在庫数プロパティ</summary>
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

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数（未計上）プロパティ</summary>
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
        // --- ADD 2009/11/30 ----------<<<<<

        //-----ADD 2011/01/11 ----->>>>>
        /// public propaty name  :  ListPriceFl
        /// <summary>定価（浮動）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceFl
        {
            get { return _listPriceFl; }
            set { _listPriceFl = value; }
        }

        /// public propaty name  :  GoodsNoSrc
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSrc
        {
            get { return _goodsNoSrc; }
            set { _goodsNoSrc = value; }
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
        //-----ADD 2011/01/11 -----<<<<<

        //-----ADD 2012/06/08----->>>>>
        /// public propaty name  :  SectionCodeSt
        /// <summary>開始管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>終了管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }
        //-----ADD 2012/06/08-----<<<<<

        /// <summary>
        /// 棚卸データワークコンストラクタ
        /// </summary>
        /// <returns>InventoryDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InventoryDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>InventoryDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   InventoryDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class InventoryDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  InventoryDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is InventoryDataWork || graph is ArrayList || graph is InventoryDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(InventoryDataWork).FullName));

            if (graph != null && graph is InventoryDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.InventoryDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is InventoryDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((InventoryDataWork[])graph).Length;
            }
            else if (graph is InventoryDataWork)
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
            //棚卸通番
            serInfo.MemberInfo.Add(typeof(Int32)); //InventorySeqNo
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //重複棚番１
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo1
            //重複棚番２
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo2
            //商品大分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //JANコード
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //仕入単価(浮動)
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //変更前仕入単価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //仕入単価変更フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //StkUnitPriceChgFlg
            //在庫区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //最終仕入年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastStockDate
            //在庫総数
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //出荷先得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipCustomerCode
            //棚卸在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //InventoryStockCnt
            //棚卸過不足数
            serInfo.MemberInfo.Add(typeof(Double)); //InventoryTolerancCnt
            //棚卸準備処理日付
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryPreprDay
            //棚卸準備処理時間
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryPreprTim
            //棚卸実施日
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryDay
            //最終棚卸更新日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastInventoryUpdate
            //棚卸新規追加区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryNewDiv
            //マシン在庫額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMashinePrice
            //棚卸在庫額
            serInfo.MemberInfo.Add(typeof(Int64)); //InventoryStockPrice
            //棚卸過不足金額
            serInfo.MemberInfo.Add(typeof(Int64)); //InventoryTlrncPrice
            //棚卸日
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryDate
            //在庫総数（実施日）
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotalExec
            //過不足更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ToleranceUpdateCd
            //調整用計算原価
            serInfo.MemberInfo.Add(typeof(Double)); //AdjstCalcCost
            // --- ADD 2009/11/30 ---------->>>>>
            //移動中仕入在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MovingSupliStock
            //出荷数（未計上）
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //入荷数（未計上）
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            // --- ADD 2009/11/30 ----------<<<<<
            //-----ADD 2011/01/11 ----->>>>>
            //定価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceFl
            //処理前の商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoSrc
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName

            //-----ADD 2011/01/11 -----<<<<<
            //-----ADD 2012/06/08 ----->>>>>
            serInfo.MemberInfo.Add(typeof(string));  //sectionCodeSt
            serInfo.MemberInfo.Add(typeof(string));  //sectionCodeEd
            //-----ADD 2012/06/08 -----<<<<<
            serInfo.Serialize(writer, serInfo);
            if (graph is InventoryDataWork)
            {
                InventoryDataWork temp = (InventoryDataWork)graph;

                SetInventoryDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is InventoryDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((InventoryDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (InventoryDataWork temp in lst)
                {
                    SetInventoryDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// InventoryDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 47;//DEL 2011/01/11
        //private const int currentMemberCount = 50;//ADD 2011/01/11 //DEL 2012/06/08
        private const int currentMemberCount = 52;//ADD 2011/01/11
        /// <summary>
        ///  InventoryDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetInventoryDataWork(System.IO.BinaryWriter writer, InventoryDataWork temp)
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
            //棚卸通番
            writer.Write(temp.InventorySeqNo);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //重複棚番１
            writer.Write(temp.DuplicationShelfNo1);
            //重複棚番２
            writer.Write(temp.DuplicationShelfNo2);
            //商品大分類コード
            writer.Write(temp.GoodsLGroup);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //JANコード
            writer.Write(temp.Jan);
            //仕入単価(浮動)
            writer.Write(temp.StockUnitPriceFl);
            //変更前仕入単価（浮動）
            writer.Write(temp.BfStockUnitPriceFl);
            //仕入単価変更フラグ
            writer.Write(temp.StkUnitPriceChgFlg);
            //在庫区分
            writer.Write(temp.StockDiv);
            //最終仕入年月日
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //在庫総数
            writer.Write(temp.StockTotal);
            //出荷先得意先コード
            writer.Write(temp.ShipCustomerCode);
            //棚卸在庫数
            writer.Write(temp.InventoryStockCnt);
            //棚卸過不足数
            writer.Write(temp.InventoryTolerancCnt);
            //棚卸準備処理日付
            writer.Write((Int64)temp.InventoryPreprDay.Ticks);
            //棚卸準備処理時間
            writer.Write(temp.InventoryPreprTim);
            //棚卸実施日
            writer.Write((Int64)temp.InventoryDay.Ticks);
            //最終棚卸更新日
            writer.Write((Int64)temp.LastInventoryUpdate.Ticks);
            //棚卸新規追加区分
            writer.Write(temp.InventoryNewDiv);
            //マシン在庫額
            writer.Write(temp.StockMashinePrice);
            //棚卸在庫額
            writer.Write(temp.InventoryStockPrice);
            //棚卸過不足金額
            writer.Write(temp.InventoryTlrncPrice);
            //棚卸日
            writer.Write((Int64)temp.InventoryDate.Ticks);
            //在庫総数（実施日）
            writer.Write(temp.StockTotalExec);
            //過不足更新区分
            writer.Write(temp.ToleranceUpdateCd);
            //調整用計算原価
            writer.Write(temp.AdjstCalcCost);
            // --- ADD 2009/11/30 ---------->>>>>
            //移動中仕入在庫数
            writer.Write(temp.MovingSupliStock);
            //出荷数（未計上）
            writer.Write(temp.ShipmentCnt);
            //入荷数（未計上）
            writer.Write(temp.ArrivalCnt);
            // --- ADD 2009/11/30 ----------<<<<<
            //-----ADD 2011/01/11 ----->>>>>
            //定価（浮動）
            writer.Write(temp.ListPriceFl);
            //処理前の商品番号
            writer.Write(temp.GoodsNoSrc);
            //商品名称
            writer.Write(temp.GoodsName);
            //-----ADD 2011/01/11 -----<<<<<
            //-----ADD 2012/06/08 ----->>>>>
            //開始管理拠点コード
            writer.Write(temp.SectionCodeSt);
            //終了管理拠点コード
            writer.Write(temp.SectionCodeEd);
            //-----ADD 2012/06/08 -----<<<<<
        }

        /// <summary>
        ///  InventoryDataWorkインスタンス取得
        /// </summary>
        /// <returns>InventoryDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private InventoryDataWork GetInventoryDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            InventoryDataWork temp = new InventoryDataWork();

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
            //棚卸通番
            temp.InventorySeqNo = reader.ReadInt32();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //重複棚番１
            temp.DuplicationShelfNo1 = reader.ReadString();
            //重複棚番２
            temp.DuplicationShelfNo2 = reader.ReadString();
            //商品大分類コード
            temp.GoodsLGroup = reader.ReadInt32();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //JANコード
            temp.Jan = reader.ReadString();
            //仕入単価(浮動)
            temp.StockUnitPriceFl = reader.ReadDouble();
            //変更前仕入単価（浮動）
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //仕入単価変更フラグ
            temp.StkUnitPriceChgFlg = reader.ReadInt32();
            //在庫区分
            temp.StockDiv = reader.ReadInt32();
            //最終仕入年月日
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            //在庫総数
            temp.StockTotal = reader.ReadDouble();
            //出荷先得意先コード
            temp.ShipCustomerCode = reader.ReadInt32();
            //棚卸在庫数
            temp.InventoryStockCnt = reader.ReadDouble();
            //棚卸過不足数
            temp.InventoryTolerancCnt = reader.ReadDouble();
            //棚卸準備処理日付
            temp.InventoryPreprDay = new DateTime(reader.ReadInt64());
            //棚卸準備処理時間
            temp.InventoryPreprTim = reader.ReadInt32();
            //棚卸実施日
            temp.InventoryDay = new DateTime(reader.ReadInt64());
            //最終棚卸更新日
            temp.LastInventoryUpdate = new DateTime(reader.ReadInt64());
            //棚卸新規追加区分
            temp.InventoryNewDiv = reader.ReadInt32();
            //マシン在庫額
            temp.StockMashinePrice = reader.ReadInt64();
            //棚卸在庫額
            temp.InventoryStockPrice = reader.ReadInt64();
            //棚卸過不足金額
            temp.InventoryTlrncPrice = reader.ReadInt64();
            //棚卸日
            temp.InventoryDate = new DateTime(reader.ReadInt64());
            //在庫総数（実施日）
            temp.StockTotalExec = reader.ReadDouble();
            //過不足更新区分
            temp.ToleranceUpdateCd = reader.ReadInt32();
            //調整用計算原価
            temp.AdjstCalcCost = reader.ReadDouble();
            // --- ADD 2009/11/30 ---------->>>>>
            //移動中仕入在庫数
            temp.MovingSupliStock = reader.ReadDouble();
            //出荷数（未計上）
            temp.ShipmentCnt = reader.ReadDouble();
            //入荷数（未計上）
            temp.ArrivalCnt = reader.ReadDouble();
            // --- ADD 2009/11/30 ----------<<<<<
            //-----ADD 2011/01/11 ----->>>>>
            //定価（浮動）
            temp.ListPriceFl = reader.ReadDouble();
            //商品番号
            temp.GoodsNoSrc = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //-----ADD 2011/01/11 -----<<<<<
            //-----ADD 2012/06/08 ----->>>>>
            //開始管理拠点コード
            temp.SectionCodeSt = reader.ReadString();
            //終了管理拠点コード
            temp.SectionCodeEd = reader.ReadString(); 
            //-----ADD 2012/06/08 -----<<<<<

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
        /// <returns>InventoryDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                InventoryDataWork temp = GetInventoryDataWork(reader, serInfo);
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
                    retValue = (InventoryDataWork[])lst.ToArray(typeof(InventoryDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
