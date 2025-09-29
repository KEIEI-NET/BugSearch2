using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockManagementListWork
    /// <summary>
    ///                      在庫管理表リモート抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫管理表リモート抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockManagementListWork
    {
        /// <summary>仕入先コード</summary>
        /// <remarks>商品管理情報マスタより取得</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先名称</summary>
        /// <remarks>商品管理情報マスタより取得</remarks>
        private string _supplierName = "";

        /// <summary>仕入先名称2</summary>
        /// <remarks>商品管理情報マスタより取得</remarks>
        private string _supplierName2 = "";

        /// <summary>拠点コード</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private string _sectionCode = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private string _makerName = "";

        /// <summary>倉庫コード</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private string _warehouseName = "";

        /// <summary>商品番号</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private string _goodsName = "";

        /// <summary>商品区分グループコード</summary>
        /// <remarks>在庫マスタより取得</remarks>
        private string _largeGoodsGanreCode = "";

        /// <summary>商品区分グループ名称</summary>
        /// <remarks>商品マスタより取得</remarks>
        private string _largeGoodsGanreName = "";

        /// <summary>商品区分コード</summary>
        /// <remarks>在庫マスタより取得</remarks>
        private string _mediumGoodsGanreCode = "";

        /// <summary>商品区分名称</summary>
        /// <remarks>商品マスタより取得</remarks>
        private string _mediumGoodsGanreName = "";

        /// <summary>商品区分詳細コード</summary>
        /// <remarks>在庫マスタより取得</remarks>
        private string _detailGoodsGanreCode = "";

        /// <summary>商品区分詳細名称</summary>
        /// <remarks>商品マスタより取得</remarks>
        private string _detailGoodsGanreName = "";

        /// <summary>前月末在庫数</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _lMonthStockCnt;

        /// <summary>前月末在庫額</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Int64 _lMonthStockPrice;

        /// <summary>純仕入数</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _netStockCnt;

        /// <summary>純仕入額</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Int64 _netStockPrice;

        /// <summary>純売上数</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _netSalesCnt;

        /// <summary>純売上額</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Int64 _netSalesPrice;

        /// <summary>粗利金額</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Int64 _grossProfit;

        /// <summary>調整数</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _adjustCount;

        /// <summary>調整金額</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Int64 _adjustPrice;

        /// <summary>在庫総数</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _stockTotal;

        /// <summary>当月末評価単価</summary>
        private Double _stockUnitPriceFl;

        /// <summary>平均在庫</summary>
        private Double _stockAverage;

        /// <summary>回転率</summary>
        private Double _turnRate;

        /// <summary>合計純仕入数</summary>
        /// <remarks>期首月から集計</remarks>
        private Double _netStockCntTotal;

        /// <summary>合計純仕入額</summary>
        /// <remarks>期首月から集計</remarks>
        private Int64 _netStockPriceTotal;

        /// <summary>合計純売上数</summary>
        /// <remarks>期首月から集計</remarks>
        private Double _netSalesCntTotal;

        /// <summary>合計純売上額</summary>
        /// <remarks>期首月から集計</remarks>
        private Int64 _netSalesPriceTotal;

        /// <summary>合計粗利金額</summary>
        /// <remarks>期首月から集計</remarks>
        private Int64 _grossProfitTotal;

        /// <summary>合計調整数</summary>
        /// <remarks>期首月から集計</remarks>
        private Double _adjustCountTotal;

        /// <summary>合計調整金額</summary>
        /// <remarks>期首月から集計</remarks>
        private Int64 _adjustPriceTotal;


        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>商品管理情報マスタより取得</value>
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

        /// public propaty name  :  SupplierName
        /// <summary>仕入先名称プロパティ</summary>
        /// <value>商品管理情報マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }

        /// public propaty name  :  SupplierName2
        /// <summary>仕入先名称2プロパティ</summary>
        /// <value>商品管理情報マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierName2
        {
            get { return _supplierName2; }
            set { _supplierName2 = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>在庫履歴データより取得</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>在庫履歴データより取得</value>
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
        /// <value>在庫履歴データより取得</value>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>在庫履歴データより取得</value>
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
        /// <value>在庫履歴データより取得</value>
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

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
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
        /// <value>在庫履歴データより取得</value>
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

        /// public propaty name  :  LargeGoodsGanreCode
        /// <summary>商品区分グループコードプロパティ</summary>
        /// <value>在庫マスタより取得</value>
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
        /// <value>商品マスタより取得</value>
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
        /// <value>在庫マスタより取得</value>
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
        /// <value>商品マスタより取得</value>
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
        /// <value>在庫マスタより取得</value>
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
        /// <value>商品マスタより取得</value>
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

        /// public propaty name  :  LMonthStockCnt
        /// <summary>前月末在庫数プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
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
        /// <value>在庫履歴データより取得</value>
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

        /// public propaty name  :  NetStockCnt
        /// <summary>純仕入数プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純仕入数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NetStockCnt
        {
            get { return _netStockCnt; }
            set { _netStockCnt = value; }
        }

        /// public propaty name  :  NetStockPrice
        /// <summary>純仕入額プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純仕入額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 NetStockPrice
        {
            get { return _netStockPrice; }
            set { _netStockPrice = value; }
        }

        /// public propaty name  :  NetSalesCnt
        /// <summary>純売上数プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純売上数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NetSalesCnt
        {
            get { return _netSalesCnt; }
            set { _netSalesCnt = value; }
        }

        /// public propaty name  :  NetSalesPrice
        /// <summary>純売上額プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純売上額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 NetSalesPrice
        {
            get { return _netSalesPrice; }
            set { _netSalesPrice = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>粗利金額プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
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

        /// public propaty name  :  AdjustCount
        /// <summary>調整数プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
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
        /// <value>在庫履歴データより取得</value>
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

        /// public propaty name  :  StockTotal
        /// <summary>在庫総数プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>当月末評価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月末評価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockAverage
        /// <summary>平均在庫プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   平均在庫プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockAverage
        {
            get { return _stockAverage; }
            set { _stockAverage = value; }
        }

        /// public propaty name  :  TurnRate
        /// <summary>回転率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回転率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TurnRate
        {
            get { return _turnRate; }
            set { _turnRate = value; }
        }

        /// public propaty name  :  NetStockCntTotal
        /// <summary>合計純仕入数プロパティ</summary>
        /// <value>期首月から集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計純仕入数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NetStockCntTotal
        {
            get { return _netStockCntTotal; }
            set { _netStockCntTotal = value; }
        }

        /// public propaty name  :  NetStockPriceTotal
        /// <summary>合計純仕入額プロパティ</summary>
        /// <value>期首月から集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計純仕入額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 NetStockPriceTotal
        {
            get { return _netStockPriceTotal; }
            set { _netStockPriceTotal = value; }
        }

        /// public propaty name  :  NetSalesCntTotal
        /// <summary>合計純売上数プロパティ</summary>
        /// <value>期首月から集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計純売上数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NetSalesCntTotal
        {
            get { return _netSalesCntTotal; }
            set { _netSalesCntTotal = value; }
        }

        /// public propaty name  :  NetSalesPriceTotal
        /// <summary>合計純売上額プロパティ</summary>
        /// <value>期首月から集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計純売上額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 NetSalesPriceTotal
        {
            get { return _netSalesPriceTotal; }
            set { _netSalesPriceTotal = value; }
        }

        /// public propaty name  :  GrossProfitTotal
        /// <summary>合計粗利金額プロパティ</summary>
        /// <value>期首月から集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfitTotal
        {
            get { return _grossProfitTotal; }
            set { _grossProfitTotal = value; }
        }

        /// public propaty name  :  AdjustCountTotal
        /// <summary>合計調整数プロパティ</summary>
        /// <value>期首月から集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AdjustCountTotal
        {
            get { return _adjustCountTotal; }
            set { _adjustCountTotal = value; }
        }

        /// public propaty name  :  AdjustPriceTotal
        /// <summary>合計調整金額プロパティ</summary>
        /// <value>期首月から集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計調整金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AdjustPriceTotal
        {
            get { return _adjustPriceTotal; }
            set { _adjustPriceTotal = value; }
        }


        /// <summary>
        /// 在庫管理表リモート抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockManagementListWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockManagementListWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockManagementListWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockManagementListWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockManagementListWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockManagementListWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockManagementListWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockManagementListWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockManagementListWork || graph is ArrayList || graph is StockManagementListWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockManagementListWork).FullName));

            if (graph != null && graph is StockManagementListWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockManagementListWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockManagementListWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockManagementListWork[])graph).Length;
            }
            else if (graph is StockManagementListWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierName
            //仕入先名称2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierName2
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品区分グループコード
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreCode
            //商品区分グループ名称
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreName
            //商品区分コード
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreCode
            //商品区分名称
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreName
            //商品区分詳細コード
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreCode
            //商品区分詳細名称
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreName
            //前月末在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //LMonthStockCnt
            //前月末在庫額
            serInfo.MemberInfo.Add(typeof(Int64)); //LMonthStockPrice
            //純仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //NetStockCnt
            //純仕入額
            serInfo.MemberInfo.Add(typeof(Int64)); //NetStockPrice
            //純売上数
            serInfo.MemberInfo.Add(typeof(Double)); //NetSalesCnt
            //純売上額
            serInfo.MemberInfo.Add(typeof(Int64)); //NetSalesPrice
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //調整数
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCount
            //調整金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AdjustPrice
            //在庫総数
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //当月末評価単価
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //平均在庫
            serInfo.MemberInfo.Add(typeof(Double)); //StockAverage
            //回転率
            serInfo.MemberInfo.Add(typeof(Double)); //TurnRate
            //合計純仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //NetStockCntTotal
            //合計純仕入額
            serInfo.MemberInfo.Add(typeof(Int64)); //NetStockPriceTotal
            //合計純売上数
            serInfo.MemberInfo.Add(typeof(Double)); //NetSalesCntTotal
            //合計純売上額
            serInfo.MemberInfo.Add(typeof(Int64)); //NetSalesPriceTotal
            //合計粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitTotal
            //合計調整数
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCountTotal
            //合計調整金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AdjustPriceTotal


            serInfo.Serialize(writer, serInfo);
            if (graph is StockManagementListWork)
            {
                StockManagementListWork temp = (StockManagementListWork)graph;

                SetStockManagementListWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockManagementListWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockManagementListWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockManagementListWork temp in lst)
                {
                    SetStockManagementListWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockManagementListWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 36;

        /// <summary>
        ///  StockManagementListWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockManagementListWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockManagementListWork(System.IO.BinaryWriter writer, StockManagementListWork temp)
        {
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名称
            writer.Write(temp.SupplierName);
            //仕入先名称2
            writer.Write(temp.SupplierName2);
            //拠点コード
            writer.Write(temp.SectionCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品区分グループコード
            writer.Write(temp.LargeGoodsGanreCode);
            //商品区分グループ名称
            writer.Write(temp.LargeGoodsGanreName);
            //商品区分コード
            writer.Write(temp.MediumGoodsGanreCode);
            //商品区分名称
            writer.Write(temp.MediumGoodsGanreName);
            //商品区分詳細コード
            writer.Write(temp.DetailGoodsGanreCode);
            //商品区分詳細名称
            writer.Write(temp.DetailGoodsGanreName);
            //前月末在庫数
            writer.Write(temp.LMonthStockCnt);
            //前月末在庫額
            writer.Write(temp.LMonthStockPrice);
            //純仕入数
            writer.Write(temp.NetStockCnt);
            //純仕入額
            writer.Write(temp.NetStockPrice);
            //純売上数
            writer.Write(temp.NetSalesCnt);
            //純売上額
            writer.Write(temp.NetSalesPrice);
            //粗利金額
            writer.Write(temp.GrossProfit);
            //調整数
            writer.Write(temp.AdjustCount);
            //調整金額
            writer.Write(temp.AdjustPrice);
            //在庫総数
            writer.Write(temp.StockTotal);
            //当月末評価単価
            writer.Write(temp.StockUnitPriceFl);
            //平均在庫
            writer.Write(temp.StockAverage);
            //回転率
            writer.Write(temp.TurnRate);
            //合計純仕入数
            writer.Write(temp.NetStockCntTotal);
            //合計純仕入額
            writer.Write(temp.NetStockPriceTotal);
            //合計純売上数
            writer.Write(temp.NetSalesCntTotal);
            //合計純売上額
            writer.Write(temp.NetSalesPriceTotal);
            //合計粗利金額
            writer.Write(temp.GrossProfitTotal);
            //合計調整数
            writer.Write(temp.AdjustCountTotal);
            //合計調整金額
            writer.Write(temp.AdjustPriceTotal);

        }

        /// <summary>
        ///  StockManagementListWorkインスタンス取得
        /// </summary>
        /// <returns>StockManagementListWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockManagementListWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockManagementListWork GetStockManagementListWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockManagementListWork temp = new StockManagementListWork();

            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名称
            temp.SupplierName = reader.ReadString();
            //仕入先名称2
            temp.SupplierName2 = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品区分グループコード
            temp.LargeGoodsGanreCode = reader.ReadString();
            //商品区分グループ名称
            temp.LargeGoodsGanreName = reader.ReadString();
            //商品区分コード
            temp.MediumGoodsGanreCode = reader.ReadString();
            //商品区分名称
            temp.MediumGoodsGanreName = reader.ReadString();
            //商品区分詳細コード
            temp.DetailGoodsGanreCode = reader.ReadString();
            //商品区分詳細名称
            temp.DetailGoodsGanreName = reader.ReadString();
            //前月末在庫数
            temp.LMonthStockCnt = reader.ReadDouble();
            //前月末在庫額
            temp.LMonthStockPrice = reader.ReadInt64();
            //純仕入数
            temp.NetStockCnt = reader.ReadDouble();
            //純仕入額
            temp.NetStockPrice = reader.ReadInt64();
            //純売上数
            temp.NetSalesCnt = reader.ReadDouble();
            //純売上額
            temp.NetSalesPrice = reader.ReadInt64();
            //粗利金額
            temp.GrossProfit = reader.ReadInt64();
            //調整数
            temp.AdjustCount = reader.ReadDouble();
            //調整金額
            temp.AdjustPrice = reader.ReadInt64();
            //在庫総数
            temp.StockTotal = reader.ReadDouble();
            //当月末評価単価
            temp.StockUnitPriceFl = reader.ReadDouble();
            //平均在庫
            temp.StockAverage = reader.ReadDouble();
            //回転率
            temp.TurnRate = reader.ReadDouble();
            //合計純仕入数
            temp.NetStockCntTotal = reader.ReadDouble();
            //合計純仕入額
            temp.NetStockPriceTotal = reader.ReadInt64();
            //合計純売上数
            temp.NetSalesCntTotal = reader.ReadDouble();
            //合計純売上額
            temp.NetSalesPriceTotal = reader.ReadInt64();
            //合計粗利金額
            temp.GrossProfitTotal = reader.ReadInt64();
            //合計調整数
            temp.AdjustCountTotal = reader.ReadDouble();
            //合計調整金額
            temp.AdjustPriceTotal = reader.ReadInt64();


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
        /// <returns>StockManagementListWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockManagementListWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockManagementListWork temp = GetStockManagementListWork(reader, serInfo);
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
                    retValue = (StockManagementListWork[])lst.ToArray(typeof(StockManagementListWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
