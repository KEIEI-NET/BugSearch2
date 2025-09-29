using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMonthYearReportDataWork
    /// <summary>
    ///                      在庫月報年報リモート抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫月報年報リモート抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/03/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMonthYearReportDataWork
    {
        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>在庫発注先コード</summary>
        private Int32 _stockSupplierCode;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>前月末在庫数</summary>
        private Double _lMonthStockCnt;

        /// <summary>仕入数</summary>
        private Double _stockCount;

        /// <summary>移動入荷数</summary>
        private Double _moveArrivalCnt;

        /// <summary>総入荷数</summary>
        private Double _totalArrivalCnt;

        /// <summary>売上数</summary>
        private Double _salesCount;

        /// <summary>移動出荷数</summary>
        private Double _moveShipmentCnt;

        /// <summary>総出荷数</summary>
        private Double _totalShipmentCnt;

        /// <summary>最高在庫数</summary>
        private Double _maximumStockCnt;

        /// <summary>最低在庫数</summary>
        private Double _minimumStockCnt;

        /// <summary>原価</summary>
        private Double _salesCost;

        /// <summary>前月末在庫額</summary>
        private Int64 _lMonthStockPrice;

        /// <summary>仕入金額（税抜き）</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>移動入荷額</summary>
        private Int64 _moveArrivalPrice;

        /// <summary>総入荷金額</summary>
        private Int64 _totalArrivalPrice;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>移動出荷額</summary>
        private Int64 _moveShipmentPrice;

        /// <summary>総出荷金額</summary>
        private Int64 _totalShipmentPrice;

        /// <summary>粗利金額</summary>
        private Int64 _grossProfit;

        /// <summary>粗利率</summary>
        private Double _grossProfitRate;

        /// <summary>在庫総数</summary>
        /// <remarks>在庫総数=仕入在庫数+委託数+受託数</remarks>
        private Double _stockTotal;

        /// <summary>マシン在庫額</summary>
        private Int64 _stockMashinePrice;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類（マスタ有）</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>部品管理区分１</summary>
        private string _partsManagementDivide1 = "";

        /// <summary>部品管理区分２</summary>
        private string _partsManagementDivide2 = "";

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

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
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

        /// public propaty name  :  WarehouseShelfNo
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

        /// public propaty name  :  LMonthStockCnt
        /// <summary>前月末在庫数プロパティ</summary>
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

        /// public propaty name  :  TotalArrivalCnt
        /// <summary>総入荷数プロパティ</summary>
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

        /// public propaty name  :  TotalShipmentCnt
        /// <summary>総出荷数プロパティ</summary>
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

        /// public propaty name  :  SalesCost
        /// <summary>原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesCost
        {
            get { return _salesCost; }
            set { _salesCost = value; }
        }

        /// public propaty name  :  LMonthStockPrice
        /// <summary>前月末在庫額プロパティ</summary>
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

        /// public propaty name  :  TotalArrivalPrice
        /// <summary>総入荷金額プロパティ</summary>
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

        /// public propaty name  :  TotalShipmentPrice
        /// <summary>総出荷金額プロパティ</summary>
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

        /// public propaty name  :  GrossProfitRate
        /// <summary>粗利率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrossProfitRate
        {
            get { return _grossProfitRate; }
            set { _grossProfitRate = value; }
        }

        /// public propaty name  :  StockTotal
        /// <summary>在庫総数プロパティ</summary>
        /// <value>在庫総数=仕入在庫数+委託数+受託数</value>
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

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
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

        /// <summary>
        /// 在庫月報年報リモート抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockMonthYearReportDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMonthYearReportDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockMonthYearReportDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockMonthYearReportDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockMonthYearReportDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMonthYearReportDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMonthYearReportDataWork || graph is ArrayList || graph is StockMonthYearReportDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockMonthYearReportDataWork).FullName));

            if (graph != null && graph is StockMonthYearReportDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMonthYearReportDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMonthYearReportDataWork[])graph).Length;
            }
            else if (graph is StockMonthYearReportDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //在庫発注先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSupplierCode
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //前月末在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //LMonthStockCnt
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //移動入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveArrivalCnt
            //総入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //TotalArrivalCnt
            //売上数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesCount
            //移動出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveShipmentCnt
            //総出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //TotalShipmentCnt
            //最高在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //最低在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCnt
            //原価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesCost
            //前月末在庫額
            serInfo.MemberInfo.Add(typeof(Int64)); //LMonthStockPrice
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //移動入荷額
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveArrivalPrice
            //総入荷金額
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalArrivalPrice
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //移動出荷額
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveShipmentPrice
            //総出荷金額
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalShipmentPrice
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //粗利率
            serInfo.MemberInfo.Add(typeof(Double)); //GrossProfitRate
            //在庫総数
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //マシン在庫額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMashinePrice
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //商品大分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー略称
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //部品管理区分１
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide1
            //部品管理区分２
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide2

            serInfo.Serialize(writer, serInfo);
            if (graph is StockMonthYearReportDataWork)
            {
                StockMonthYearReportDataWork temp = (StockMonthYearReportDataWork)graph;

                SetStockMonthYearReportDataWork(writer, temp);
            }

            else
            {
                ArrayList lst = null;
                if (graph is StockMonthYearReportDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMonthYearReportDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMonthYearReportDataWork temp in lst)
                {
                    SetStockMonthYearReportDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMonthYearReportDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 37;

        /// <summary>
        ///  StockMonthYearReportDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockMonthYearReportDataWork(System.IO.BinaryWriter writer, StockMonthYearReportDataWork temp)
        {
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //在庫発注先コード
            writer.Write(temp.StockSupplierCode);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //棚番
            writer.Write(temp.WarehouseShelfNo);
            //前月末在庫数
            writer.Write(temp.LMonthStockCnt);
            //仕入数
            writer.Write(temp.StockCount);
            //移動入荷数
            writer.Write(temp.MoveArrivalCnt);
            //総入荷数
            writer.Write(temp.TotalArrivalCnt);
            //売上数
            writer.Write(temp.SalesCount);
            //移動出荷数
            writer.Write(temp.MoveShipmentCnt);
            //総出荷数
            writer.Write(temp.TotalShipmentCnt);
            //最高在庫数
            writer.Write(temp.MaximumStockCnt);
            //最低在庫数
            writer.Write(temp.MinimumStockCnt);
            //原価
            writer.Write(temp.SalesCost);
            //前月末在庫額
            writer.Write(temp.LMonthStockPrice);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);
            //移動入荷額
            writer.Write(temp.MoveArrivalPrice);
            //総入荷金額
            writer.Write(temp.TotalArrivalPrice);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //移動出荷額
            writer.Write(temp.MoveShipmentPrice);
            //総出荷金額
            writer.Write(temp.TotalShipmentPrice);
            //粗利金額
            writer.Write(temp.GrossProfit);
            //粗利率
            writer.Write(temp.GrossProfitRate);
            //在庫総数
            writer.Write(temp.StockTotal);
            //マシン在庫額
            writer.Write(temp.StockMashinePrice);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //商品大分類コード
            writer.Write(temp.GoodsLGroup);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー略称
            writer.Write(temp.MakerShortName);
            //拠点コード
            writer.Write(temp.SectionCode);
            //部品管理区分１
            writer.Write(temp.PartsManagementDivide1);
            //部品管理区分２
            writer.Write(temp.PartsManagementDivide2);

        }

        /// <summary>
        ///  StockMonthYearReportDataWorkインスタンス取得
        /// </summary>
        /// <returns>StockMonthYearReportDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockMonthYearReportDataWork GetStockMonthYearReportDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockMonthYearReportDataWork temp = new StockMonthYearReportDataWork();

            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //在庫発注先コード
            temp.StockSupplierCode = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //前月末在庫数
            temp.LMonthStockCnt = reader.ReadDouble();
            //仕入数
            temp.StockCount = reader.ReadDouble();
            //移動入荷数
            temp.MoveArrivalCnt = reader.ReadDouble();
            //総入荷数
            temp.TotalArrivalCnt = reader.ReadDouble();
            //売上数
            temp.SalesCount = reader.ReadDouble();
            //移動出荷数
            temp.MoveShipmentCnt = reader.ReadDouble();
            //総出荷数
            temp.TotalShipmentCnt = reader.ReadDouble();
            //最高在庫数
            temp.MaximumStockCnt = reader.ReadDouble();
            //最低在庫数
            temp.MinimumStockCnt = reader.ReadDouble();
            //原価
            temp.SalesCost = reader.ReadDouble();
            //前月末在庫額
            temp.LMonthStockPrice = reader.ReadInt64();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();
            //移動入荷額
            temp.MoveArrivalPrice = reader.ReadInt64();
            //総入荷金額
            temp.TotalArrivalPrice = reader.ReadInt64();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //移動出荷額
            temp.MoveShipmentPrice = reader.ReadInt64();
            //総出荷金額
            temp.TotalShipmentPrice = reader.ReadInt64();
            //粗利金額
            temp.GrossProfit = reader.ReadInt64();
            //粗利率
            temp.GrossProfitRate = reader.ReadDouble();
            //在庫総数
            temp.StockTotal = reader.ReadDouble();
            //マシン在庫額
            temp.StockMashinePrice = reader.ReadInt64();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //商品大分類コード
            temp.GoodsLGroup = reader.ReadInt32();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー略称
            temp.MakerShortName = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //部品管理区分１
            temp.PartsManagementDivide1 = reader.ReadString();
            //部品管理区分２
            temp.PartsManagementDivide2 = reader.ReadString();


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
        /// <returns>StockMonthYearReportDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMonthYearReportDataWork temp = GetStockMonthYearReportDataWork(reader, serInfo);
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
                    retValue = (StockMonthYearReportDataWork[])lst.ToArray(typeof(StockMonthYearReportDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}