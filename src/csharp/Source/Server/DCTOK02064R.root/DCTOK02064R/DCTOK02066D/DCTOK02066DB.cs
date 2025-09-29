using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_ShipGoodsAnalyzeWork
    /// <summary>
    ///                      出荷商品分析表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   出荷商品分析表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_ShipGoodsAnalyzeWork
    {
        /// <summary>拠点コード</summary>
        /// <remarks>計上拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>拠点名称</summary>
        /// <remarks>拠点ガイド略称</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>品名</summary>
        /// <remarks>商品名称カナ</remarks>
        private string _goodsNameKana = "";

        /// <summary>品番</summary>
        /// <remarks>商品番号</remarks>
        private string _goodsNo = "";

        /// <summary>在庫登録日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;

        /// <summary>現在庫</summary>
        /// <remarks>出荷可能数</remarks>
        private Double _shipmentPosCnt;

        /// <summary>最低数</summary>
        /// <remarks>最低在庫数</remarks>
        private Double _minimumStockCnt;

        /// <summary>最高数</summary>
        /// <remarks>最高在庫数</remarks>
        private Double _maximumStockCnt;

        /// <summary>売上数計(合計)</summary>
        /// <remarks>実績集計区分が”合計”の売上数計</remarks>
        private Double _totalCount;

        /// <summary>売上数計(在庫)</summary>
        /// <remarks>実績集計区分が”在庫”の売上数計</remarks>
        private Double _stockCount;

        /// <summary>売上数計(取寄)</summary>
        /// <remarks>実績集計区分が”取寄”の売上数計</remarks>
        private Double _orderCount;

        /// <summary>売上(合計)</summary>
        /// <remarks>売上金額(合計)</remarks>
        private Int64 _salesMoney;

        /// <summary>粗利額(合計)</summary>
        /// <remarks>粗利金額(合計)</remarks>
        private Int64 _grossProfit;

        /// <summary>返品額(合計)</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>値引金額(合計)</summary>
        private Int64 _discountPrice;

        /// <summary>売上(在庫)</summary>
        /// <remarks>売上金額(在庫)</remarks>
        private Int64 _stockSalesMoney;

        /// <summary>粗利額(在庫)</summary>
        /// <remarks>粗利金額(在庫)</remarks>
        private Int64 _stockGrossProfit;

        /// <summary>返品額(在庫)</summary>
        private Int64 _stockSalesRetGoodsPrice;

        /// <summary>値引金額(在庫)</summary>
        private Int64 _stockDiscountPrice;


        /// public propaty name  :  AddUpSecCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>計上拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点名称プロパティ</summary>
        /// <value>拠点ガイド略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>品名プロパティ</summary>
        /// <value>商品名称カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// <value>商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
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

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>現在庫プロパティ</summary>
        /// <value>出荷可能数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  MinimumStockCnt
        /// <summary>最低数プロパティ</summary>
        /// <value>最低在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最低数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MinimumStockCnt
        {
            get { return _minimumStockCnt; }
            set { _minimumStockCnt = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>最高数プロパティ</summary>
        /// <value>最高在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最高数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  TotalCount
        /// <summary>売上数計(合計)プロパティ</summary>
        /// <value>実績集計区分が”合計”の売上数計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計(合計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>売上数計(在庫)プロパティ</summary>
        /// <value>実績集計区分が”在庫”の売上数計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計(在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  OrderCount
        /// <summary>売上数計(取寄)プロパティ</summary>
        /// <value>実績集計区分が”取寄”の売上数計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計(取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderCount
        {
            get { return _orderCount; }
            set { _orderCount = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>売上(合計)プロパティ</summary>
        /// <value>売上金額(合計)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上(合計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>粗利額(合計)プロパティ</summary>
        /// <value>粗利金額(合計)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(合計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>返品額(合計)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額(合計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  DiscountPrice
        /// <summary>値引金額(合計)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引金額(合計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }

        /// public propaty name  :  StockSalesMoney
        /// <summary>売上(在庫)プロパティ</summary>
        /// <value>売上金額(在庫)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上(在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSalesMoney
        {
            get { return _stockSalesMoney; }
            set { _stockSalesMoney = value; }
        }

        /// public propaty name  :  StockGrossProfit
        /// <summary>粗利額(在庫)プロパティ</summary>
        /// <value>粗利金額(在庫)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockGrossProfit
        {
            get { return _stockGrossProfit; }
            set { _stockGrossProfit = value; }
        }

        /// public propaty name  :  StockSalesRetGoodsPrice
        /// <summary>返品額(在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額(在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSalesRetGoodsPrice
        {
            get { return _stockSalesRetGoodsPrice; }
            set { _stockSalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  StockDiscountPrice
        /// <summary>値引金額(在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引金額(在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockDiscountPrice
        {
            get { return _stockDiscountPrice; }
            set { _stockDiscountPrice = value; }
        }


        /// <summary>
        /// 出荷商品分析表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>RsltInfo_ShipGoodsAnalyzeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_ShipGoodsAnalyzeWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RsltInfo_ShipGoodsAnalyzeWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RsltInfo_ShipGoodsAnalyzeWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RsltInfo_ShipGoodsAnalyzeWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RsltInfo_ShipGoodsAnalyzeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_ShipGoodsAnalyzeWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_ShipGoodsAnalyzeWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_ShipGoodsAnalyzeWork || graph is ArrayList || graph is RsltInfo_ShipGoodsAnalyzeWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RsltInfo_ShipGoodsAnalyzeWork).FullName));

            if (graph != null && graph is RsltInfo_ShipGoodsAnalyzeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_ShipGoodsAnalyzeWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_ShipGoodsAnalyzeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_ShipGoodsAnalyzeWork[])graph).Length;
            }
            else if (graph is RsltInfo_ShipGoodsAnalyzeWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー略称
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //品名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //品番
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //在庫登録日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //現在庫
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //最低数
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCnt
            //最高数
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //売上数計(合計)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalCount
            //売上数計(在庫)
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //売上数計(取寄)
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCount
            //売上(合計)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //粗利額(合計)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //返品額(合計)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //値引金額(合計)
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPrice
            //売上(在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSalesMoney
            //粗利額(在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockGrossProfit
            //返品額(在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSalesRetGoodsPrice
            //値引金額(在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockDiscountPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_ShipGoodsAnalyzeWork)
            {
                RsltInfo_ShipGoodsAnalyzeWork temp = (RsltInfo_ShipGoodsAnalyzeWork)graph;

                SetRsltInfo_ShipGoodsAnalyzeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_ShipGoodsAnalyzeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_ShipGoodsAnalyzeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_ShipGoodsAnalyzeWork temp in lst)
                {
                    SetRsltInfo_ShipGoodsAnalyzeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_ShipGoodsAnalyzeWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  RsltInfo_ShipGoodsAnalyzeWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_ShipGoodsAnalyzeWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRsltInfo_ShipGoodsAnalyzeWork(System.IO.BinaryWriter writer, RsltInfo_ShipGoodsAnalyzeWork temp)
        {
            //拠点コード
            writer.Write(temp.AddUpSecCode);
            //拠点名称
            writer.Write(temp.SectionGuideSnm);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー略称
            writer.Write(temp.MakerShortName);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //品名
            writer.Write(temp.GoodsNameKana);
            //品番
            writer.Write(temp.GoodsNo);
            //在庫登録日
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //現在庫
            writer.Write(temp.ShipmentPosCnt);
            //最低数
            writer.Write(temp.MinimumStockCnt);
            //最高数
            writer.Write(temp.MaximumStockCnt);
            //売上数計(合計)
            writer.Write(temp.TotalCount);
            //売上数計(在庫)
            writer.Write(temp.StockCount);
            //売上数計(取寄)
            writer.Write(temp.OrderCount);
            //売上(合計)
            writer.Write(temp.SalesMoney);
            //粗利額(合計)
            writer.Write(temp.GrossProfit);
            //返品額(合計)
            writer.Write(temp.SalesRetGoodsPrice);
            //値引金額(合計)
            writer.Write(temp.DiscountPrice);
            //売上(在庫)
            writer.Write(temp.StockSalesMoney);
            //粗利額(在庫)
            writer.Write(temp.StockGrossProfit);
            //返品額(在庫)
            writer.Write(temp.StockSalesRetGoodsPrice);
            //値引金額(在庫)
            writer.Write(temp.StockDiscountPrice);

        }

        /// <summary>
        ///  RsltInfo_ShipGoodsAnalyzeWorkインスタンス取得
        /// </summary>
        /// <returns>RsltInfo_ShipGoodsAnalyzeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_ShipGoodsAnalyzeWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RsltInfo_ShipGoodsAnalyzeWork GetRsltInfo_ShipGoodsAnalyzeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RsltInfo_ShipGoodsAnalyzeWork temp = new RsltInfo_ShipGoodsAnalyzeWork();

            //拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //拠点名称
            temp.SectionGuideSnm = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー略称
            temp.MakerShortName = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //品名
            temp.GoodsNameKana = reader.ReadString();
            //品番
            temp.GoodsNo = reader.ReadString();
            //在庫登録日
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //現在庫
            temp.ShipmentPosCnt = reader.ReadDouble();
            //最低数
            temp.MinimumStockCnt = reader.ReadDouble();
            //最高数
            temp.MaximumStockCnt = reader.ReadDouble();
            //売上数計(合計)
            temp.TotalCount = reader.ReadDouble();
            //売上数計(在庫)
            temp.StockCount = reader.ReadDouble();
            //売上数計(取寄)
            temp.OrderCount = reader.ReadDouble();
            //売上(合計)
            temp.SalesMoney = reader.ReadInt64();
            //粗利額(合計)
            temp.GrossProfit = reader.ReadInt64();
            //返品額(合計)
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //値引金額(合計)
            temp.DiscountPrice = reader.ReadInt64();
            //売上(在庫)
            temp.StockSalesMoney = reader.ReadInt64();
            //粗利額(在庫)
            temp.StockGrossProfit = reader.ReadInt64();
            //返品額(在庫)
            temp.StockSalesRetGoodsPrice = reader.ReadInt64();
            //値引金額(在庫)
            temp.StockDiscountPrice = reader.ReadInt64();


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
        /// <returns>RsltInfo_ShipGoodsAnalyzeWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_ShipGoodsAnalyzeWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_ShipGoodsAnalyzeWork temp = GetRsltInfo_ShipGoodsAnalyzeWork(reader, serInfo);
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
                    retValue = (RsltInfo_ShipGoodsAnalyzeWork[])lst.ToArray(typeof(RsltInfo_ShipGoodsAnalyzeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
