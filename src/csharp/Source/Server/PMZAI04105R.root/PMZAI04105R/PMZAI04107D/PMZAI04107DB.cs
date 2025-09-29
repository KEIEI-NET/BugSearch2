using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockHistoryDspSearchResultWork
    /// <summary>
    ///                      在庫実績照会抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫実績照会抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockHistoryDspSearchResultWork 
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

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

        /// <summary>在庫登録日</summary>
        private DateTime _stockCreateDate;

        /// <summary>最終売上日</summary>
        private DateTime _lastSalesDate;

        /// <summary>最終仕入日</summary>
        private DateTime _lastStockDate;
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

        /// <summary>仕入回数</summary>
        private Int32 _stockTimes;

        /// <summary>仕入数</summary>
        private Double _stockCount;

        /// <summary>仕入金額（税抜き）</summary>
        private Int64 _stockPriceTaxExc;

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

        /// <summary>検索区分</summary>
        /// <remarks>0:当月分,1:過去分</remarks>
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
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

        /// public propaty name  :  SastStockDate
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
            get { return _goodsNo; }
            set { _goodsNo = value; }
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
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
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

        /// public propaty name  :  SearchDiv
        /// <summary>検索区分プロパティ</summary>
        /// <value>0:当月分,1:過去分</value>
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
        /// <returns>StockHistoryDspSearchResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryDspSearchResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockHistoryDspSearchResultWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockHistoryDspSearchResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockHistoryDspSearchResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockHistoryDspSearchResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryDspSearchResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockHistoryDspSearchResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockHistoryDspSearchResultWork || graph is ArrayList || graph is StockHistoryDspSearchResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockHistoryDspSearchResultWork).FullName));

            if (graph != null && graph is StockHistoryDspSearchResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockHistoryDspSearchResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockHistoryDspSearchResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockHistoryDspSearchResultWork[])graph).Length;
            }
            else if (graph is StockHistoryDspSearchResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            //棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BlGoodsCode
            //在庫登録日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //最終売上日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastSalesDate
            //最終仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //SastStockDate
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //売上回数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //売上数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesCount
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //仕入回数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockTimes
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //移動入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveArrivalCnt
            //移動入荷額
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveArrivalPrice
            //移動出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveShipmentCnt
            //移動出荷額
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveShipmentPrice
            //検索区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is StockHistoryDspSearchResultWork)
            {
                StockHistoryDspSearchResultWork temp = (StockHistoryDspSearchResultWork)graph;

                SetStockHistoryDspSearchResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockHistoryDspSearchResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockHistoryDspSearchResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockHistoryDspSearchResultWork temp in lst)
                {
                    SetStockHistoryDspSearchResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockHistoryDspSearchResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 24;

        /// <summary>
        ///  StockHistoryDspSearchResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryDspSearchResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockHistoryDspSearchResultWork(System.IO.BinaryWriter writer, StockHistoryDspSearchResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            //棚番
            writer.Write(temp.WarehouseShelfNo);
            //BLコード
            writer.Write(temp.BlGoodsCode);
            //在庫登録日
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //最終売上日
            writer.Write((Int64)temp.LastSalesDate.Ticks);
            //最終仕入日
            writer.Write((Int64)temp.LastStockDate.Ticks);
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            //商品番号
            writer.Write(temp.GoodsNo);
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            //商品名称
            writer.Write(temp.GoodsName);
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //売上回数
            writer.Write(temp.SalesTimes);
            //売上数
            writer.Write(temp.SalesCount);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //仕入回数
            writer.Write(temp.StockTimes);
            //仕入数
            writer.Write(temp.StockCount);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);
            //粗利金額
            writer.Write(temp.GrossProfit);
            //移動入荷数
            writer.Write(temp.MoveArrivalCnt);
            //移動入荷額
            writer.Write(temp.MoveArrivalPrice);
            //移動出荷数
            writer.Write(temp.MoveShipmentCnt);
            //移動出荷額
            writer.Write(temp.MoveShipmentPrice);
            //検索区分
            writer.Write(temp.SearchDiv);

        }

        /// <summary>
        ///  StockHistoryDspSearchResultWorkインスタンス取得
        /// </summary>
        /// <returns>StockHistoryDspSearchResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryDspSearchResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockHistoryDspSearchResultWork GetStockHistoryDspSearchResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockHistoryDspSearchResultWork temp = new StockHistoryDspSearchResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            //棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //BLコード
            temp.BlGoodsCode = reader.ReadInt32();
            //在庫登録日
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //最終売上日
            temp.LastSalesDate = new DateTime(reader.ReadInt64());
            //最終仕入日
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            //商品番号
            temp.GoodsNo = reader.ReadString();
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            //商品名称
            temp.GoodsName = reader.ReadString();
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //売上回数
            temp.SalesTimes = reader.ReadInt32();
            //売上数
            temp.SalesCount = reader.ReadDouble();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //仕入回数
            temp.StockTimes = reader.ReadInt32();
            //仕入数
            temp.StockCount = reader.ReadDouble();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();
            //粗利金額
            temp.GrossProfit = reader.ReadInt64();
            //移動入荷数
            temp.MoveArrivalCnt = reader.ReadDouble();
            //移動入荷額
            temp.MoveArrivalPrice = reader.ReadInt64();
            //移動出荷数
            temp.MoveShipmentCnt = reader.ReadDouble();
            //移動出荷額
            temp.MoveShipmentPrice = reader.ReadInt64();
            //検索区分
            temp.SearchDiv = reader.ReadInt32();


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
        /// <returns>StockHistoryDspSearchResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryDspSearchResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockHistoryDspSearchResultWork temp = GetStockHistoryDspSearchResultWork(reader, serInfo);
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
                    retValue = (StockHistoryDspSearchResultWork[])lst.ToArray(typeof(StockHistoryDspSearchResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
