using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventInputSearchResultWork
    /// <summary>
    ///                      棚卸検索抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   棚卸検索抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/12/25 呉元嘯 Redmine#1994対応</br>
    /// <br>Update Note      :   2010/03/02 呉元嘯 標準価格を追加する</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventInputSearchResultWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>棚卸通番</summary>
        private Int32 _inventorySeqNo;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        // --------ADD 2009/12/25--------->>>>>
        /// <summary>処理前の商品番号</summary>
        private string _goodsNoSrc = "";
        // --------ADD 2009/12/25---------<<<<<
        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>重複棚番1</summary>
        private string _duplicationShelfNo1 = "";

        /// <summary>重複棚番2</summary>
        private string _duplicationShelfNo2 = "";

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品大分類コード名称</summary>
        private string _goodsLGroupName = "";

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類（マスタ有）</remarks>
        private Int32 _goodsMGroup;

        /// <summary>商品中分類コード名称</summary>
        private string _goodsMGroupName = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコード名称</summary>
        private string _bLGroupName = "";

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>自社分類名称</summary>
        private string _enterpriseGanreName = "";

        /// <summary>ＢＬ商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>ＢＬ商品コード枝番</summary>
        private Int32 _bLGoodsCdDerivedNo;

        /// <summary>ＢＬ商品名称</summary>
        private string _bLGoodsName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>ＪＡＮコード</summary>
        /// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
        private string _jan = "";

        /// <summary>仕入単価</summary>
        /// <remarks>税抜き ※棚卸評価単価</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>変更前仕入単価</summary>
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

        // --- ADD 2009/12/23 ---------->>>>>
        /// <summary>出荷数</summary>
        /// <remarks>出荷数</remarks>
        private Double _shipmentCnt;
        // --- ADD 2009/12/23 ----------<<<<<

        /// <summary>出荷先得意先コード</summary>
        /// <remarks>委託・売切り時の得意先コード</remarks>
        private Int32 _shipCustomerCode;

        /// <summary>出荷先得意先名称</summary>
        /// <remarks>委託・売切り時の得意先名称</remarks>
        private string _shipCustomerName = "";

        /// <summary>出荷得意先名称2</summary>
        /// <remarks>委託・売切り時の得意先名称2</remarks>
        private string _shipCustomerName2 = "";

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

        /// <summary>定価（浮動）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Double _listPriceFl;

        /// <summary>棚卸日</summary>
        /// <remarks>棚卸日をセット</remarks>
        private DateTime _inventoryDate;

        /// <summary>在庫総数（実施日）</summary>
        /// <remarks>棚卸実施日で算出した在庫数をセット</remarks>
        private Double _stockTotalExec;

        /// <summary>過不足更新区分</summary>
        /// <remarks>0:未更新　1:更新</remarks>
        private Int32 _toleranceUpdateCd;

        /// <summary>算出在庫数</summary>
        /// <remarks>在庫数算出日付に於ける在庫数</remarks>
        private Double _stockAmount;

        // --- ADD 2010/03/02 ---------->>>>>
        /// <summary>標準価格</summary>
        /// <remarks>標準価格</remarks>
        private Double _listPrice;
        // --- ADD 2010/03/02 ----------<<<<<


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

        // ----------ADD 2009/12/25------------>>>>>
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
        // ----------ADD 2009/12/25------------<<<<<

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
        /// <summary>重複棚番1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DuplicationShelfNo1
        {
            get { return _duplicationShelfNo1; }
            set { _duplicationShelfNo1 = value; }
        }

        /// public propaty name  :  DuplicationShelfNo2
        /// <summary>重複棚番2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番2プロパティ</br>
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

        /// public propaty name  :  GoodsLGroupName
        /// <summary>商品大分類コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
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

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
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

        /// public propaty name  :  BLGroupName
        /// <summary>BLグループコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>ＢＬ商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬ商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsCdDerivedNo
        /// <summary>ＢＬ商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬ商品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCdDerivedNo
        {
            get { return _bLGoodsCdDerivedNo; }
            set { _bLGoodsCdDerivedNo = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>ＢＬ商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬ商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
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

        /// public propaty name  :  Jan
        /// <summary>ＪＡＮコードプロパティ</summary>
        /// <value>標準タイプ13桁または短縮タイプ8桁のJANコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＪＡＮコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価プロパティ</summary>
        /// <value>税抜き ※棚卸評価単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>変更前仕入単価プロパティ</summary>
        /// <value>初期値は準備処理をした時の仕入単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前仕入単価プロパティ</br>
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

        // --- ADD 2009/12/23 ---------->>>>>
        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// <value>出荷数</value>
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
        // --- ADD 2009/12/23 ----------<<<<<

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

        /// public propaty name  :  ShipCustomerName
        /// <summary>出荷先得意先名称プロパティ</summary>
        /// <value>委託・売切り時の得意先名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷先得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipCustomerName
        {
            get { return _shipCustomerName; }
            set { _shipCustomerName = value; }
        }

        /// public propaty name  :  ShipCustomerName2
        /// <summary>出荷得意先名称2プロパティ</summary>
        /// <value>委託・売切り時の得意先名称2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷得意先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipCustomerName2
        {
            get { return _shipCustomerName2; }
            set { _shipCustomerName2 = value; }
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

        /// public propaty name  :  StockAmount
        /// <summary>算出在庫数プロパティ</summary>
        /// <value>在庫数算出日付に於ける在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   算出在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockAmount
        {
            get { return _stockAmount; }
            set { _stockAmount = value; }
        }

        // --- ADD 2010/03/02 ---------->>>>>
        /// public propaty name  :  ListPrice
        /// <summary>標準価格プロパティ</summary>
        /// <value>標準価格</value>
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
        // --- ADD 2010/03/02 ----------<<<<<


        /// <summary>
        /// 棚卸検索リモート抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>InventInputSearchResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventInputSearchResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InventInputSearchResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>InventInputSearchResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   InventInputSearchResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class InventInputSearchResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventInputSearchResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  InventInputSearchResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is InventInputSearchResultWork || graph is ArrayList || graph is InventInputSearchResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(InventInputSearchResultWork).FullName));

            if (graph != null && graph is InventInputSearchResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.InventInputSearchResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is InventInputSearchResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((InventInputSearchResultWork[])graph).Length;
            }
            else if (graph is InventInputSearchResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //棚卸通番
            serInfo.MemberInfo.Add(typeof(Int32)); //InventorySeqNo
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            // ------------ADD 2009/12/25----------->>>>>
            //処理前の商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoSrc
            // ------------ADD 2009/12/25-----------<<<<<
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //重複棚番1
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo1
            //重複棚番2
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo2
            //商品大分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //商品大分類コード名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //商品中分類コード名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLグループコード名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //自社分類名称
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //ＢＬ商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //ＢＬ商品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdDerivedNo
            //ＢＬ商品名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsName
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //ＪＡＮコード
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //仕入単価
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //変更前仕入単価
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
            //出荷先得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //ShipCustomerName
            //出荷得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //ShipCustomerName2
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
            //定価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceFl
            //棚卸日
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryDate
            //在庫総数（実施日）
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotalExec
            //過不足更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ToleranceUpdateCd
            //算出在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //StockAmount
            // --- ADD 2010/03/02 ---------->>>>>
            //標準価格
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            // --- ADD 2010/03/02 ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is InventInputSearchResultWork)
            {
                InventInputSearchResultWork temp = (InventInputSearchResultWork)graph;

                SetInventInputSearchResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is InventInputSearchResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((InventInputSearchResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (InventInputSearchResultWork temp in lst)
                {
                    SetInventInputSearchResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// InventInputSearchResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 50;// DEL 2010/03/02
        private const int currentMemberCount = 51;// ADD 2010/03/02

        /// <summary>
        ///  InventInputSearchResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventInputSearchResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetInventInputSearchResultWork(System.IO.BinaryWriter writer, InventInputSearchResultWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //棚卸通番
            writer.Write(temp.InventorySeqNo);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            // -----------ADD 2009/12/25------------>>>>>
            //処理前の商品番号
            writer.Write(temp.GoodsNoSrc);
            // -----------ADD 2009/12/25------------<<<<<
            //商品名称
            writer.Write(temp.GoodsName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //重複棚番1
            writer.Write(temp.DuplicationShelfNo1);
            //重複棚番2
            writer.Write(temp.DuplicationShelfNo2);
            //商品大分類コード
            writer.Write(temp.GoodsLGroup);
            //商品大分類コード名称
            writer.Write(temp.GoodsLGroupName);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //商品中分類コード名称
            writer.Write(temp.GoodsMGroupName);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLグループコード名称
            writer.Write(temp.BLGroupName);
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //自社分類名称
            writer.Write(temp.EnterpriseGanreName);
            //ＢＬ商品コード
            writer.Write(temp.BLGoodsCode);
            //ＢＬ商品コード枝番
            writer.Write(temp.BLGoodsCdDerivedNo);
            //ＢＬ商品名称
            writer.Write(temp.BLGoodsName);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //ＪＡＮコード
            writer.Write(temp.Jan);
            //仕入単価
            writer.Write(temp.StockUnitPriceFl);
            //変更前仕入単価
            writer.Write(temp.BfStockUnitPriceFl);
            //仕入単価変更フラグ
            writer.Write(temp.StkUnitPriceChgFlg);
            //在庫区分
            writer.Write(temp.StockDiv);
            //最終仕入年月日
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //在庫総数
            writer.Write(temp.StockTotal);
            // --- ADD 2009/12/23 ---------->>>>>
            //出荷数
            writer.Write(temp.ShipmentCnt);
            // --- ADD 2009/12/23 ----------<<<<<
            //出荷先得意先コード
            writer.Write(temp.ShipCustomerCode);
            //出荷先得意先名称
            writer.Write(temp.ShipCustomerName);
            //出荷得意先名称2
            writer.Write(temp.ShipCustomerName2);
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
            //定価（浮動）
            writer.Write(temp.ListPriceFl);
            //棚卸日
            writer.Write((Int64)temp.InventoryDate.Ticks);
            //在庫総数（実施日）
            writer.Write(temp.StockTotalExec);
            //過不足更新区分
            writer.Write(temp.ToleranceUpdateCd);
            //算出在庫数
            writer.Write(temp.StockAmount);
            // --- ADD 2010/03/02 ---------->>>>>
            //標準価格
            writer.Write(temp.ListPrice);
            // --- ADD 2010/03/02 ----------<<<<<

        }

        /// <summary>
        ///  InventInputSearchResultWorkインスタンス取得
        /// </summary>
        /// <returns>InventInputSearchResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventInputSearchResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private InventInputSearchResultWork GetInventInputSearchResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            InventInputSearchResultWork temp = new InventInputSearchResultWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //棚卸通番
            temp.InventorySeqNo = reader.ReadInt32();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            // ----------ADD 2009/12/25----------->>>>>
            //商品番号
            temp.GoodsNoSrc = reader.ReadString();
            // ----------ADD 2009/12/25-----------<<<<<
            //商品名称
            temp.GoodsName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //重複棚番1
            temp.DuplicationShelfNo1 = reader.ReadString();
            //重複棚番2
            temp.DuplicationShelfNo2 = reader.ReadString();
            //商品大分類コード
            temp.GoodsLGroup = reader.ReadInt32();
            //商品大分類コード名称
            temp.GoodsLGroupName = reader.ReadString();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //商品中分類コード名称
            temp.GoodsMGroupName = reader.ReadString();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLグループコード名称
            temp.BLGroupName = reader.ReadString();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //自社分類名称
            temp.EnterpriseGanreName = reader.ReadString();
            //ＢＬ商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //ＢＬ商品コード枝番
            temp.BLGoodsCdDerivedNo = reader.ReadInt32();
            //ＢＬ商品名称
            temp.BLGoodsName = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //ＪＡＮコード
            temp.Jan = reader.ReadString();
            //仕入単価
            temp.StockUnitPriceFl = reader.ReadDouble();
            //変更前仕入単価
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //仕入単価変更フラグ
            temp.StkUnitPriceChgFlg = reader.ReadInt32();
            //在庫区分
            temp.StockDiv = reader.ReadInt32();
            //最終仕入年月日
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            //在庫総数
            temp.StockTotal = reader.ReadDouble();
            // --- ADD 2009/12/23 ---------->>>>>
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            // --- ADD 2009/12/23 ----------<<<<<
            //出荷先得意先コード
            temp.ShipCustomerCode = reader.ReadInt32();
            //出荷先得意先名称
            temp.ShipCustomerName = reader.ReadString();
            //出荷得意先名称2
            temp.ShipCustomerName2 = reader.ReadString();
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
            //定価（浮動）
            temp.ListPriceFl = reader.ReadDouble();
            //棚卸日
            temp.InventoryDate = new DateTime(reader.ReadInt64());
            //在庫総数（実施日）
            temp.StockTotalExec = reader.ReadDouble();
            //過不足更新区分
            temp.ToleranceUpdateCd = reader.ReadInt32();
            //算出在庫数
            temp.StockAmount = reader.ReadDouble();
            // --- ADD 2010/03/02 ---------->>>>>
            //標準価格
            temp.ListPrice = reader.ReadDouble();
            // --- ADD 2010/03/02 ----------<<<<<


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
        /// <returns>InventInputSearchResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventInputSearchResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                InventInputSearchResultWork temp = GetInventInputSearchResultWork(reader, serInfo);
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
                    retValue = (InventInputSearchResultWork[])lst.ToArray(typeof(InventInputSearchResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
