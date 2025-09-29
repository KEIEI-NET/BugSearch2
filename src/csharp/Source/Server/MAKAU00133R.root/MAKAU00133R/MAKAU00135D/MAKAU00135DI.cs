using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlSalesStockSlipWork
    /// <summary>
    ///                      売上仕入月次集計データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上仕入月次集計データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/5/13</br>
    /// <br>Genarated Date   :   2008/07/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/25  杉村</br>
    /// <br>                 :   ・項目追加</br>
    /// <br>                 :   移動入荷数</br>
    /// <br>                 :   移動入荷額</br>
    /// <br>                 :   移動出荷数</br>
    /// <br>                 :   移動出荷額</br>
    /// <br>                 :   ・項目区分変更</br>
    /// <br>                 :   0:合計 1:在庫 2:純正⇒0:合計 1:在庫</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MTtlSalesStockSlipWork : IFileHeader
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

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _addUpYearMonth;

        /// <summary>実績集計区分</summary>
        /// <remarks>0:合計 1:在庫</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入先</remarks>
        private Int32 _customerCode;

        /// <summary>売上数計</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalSalesCount;

        /// <summary>売上金額</summary>
        /// <remarks>税抜き</remarks>
        private Int64 _salesMoney;

        /// <summary>返品額</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>値引金額</summary>
        private Int64 _discountPrice;

        /// <summary>粗利金額</summary>
        private Int64 _grossProfit;

        /// <summary>仕入金額合計</summary>
        /// <remarks>値引含む</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>仕入数計</summary>
        private Double _totalStockCount;

        /// <summary>仕入返品額</summary>
        private Int64 _stockRetGoodsPrice;

        /// <summary>仕入値引計</summary>
        private Int64 _stockTotalDiscount;

        /// <summary>移動入荷数</summary>
        private Double _moveArrivalCnt;

        /// <summary>移動入荷額</summary>
        private Int64 _moveArrivalPrice;

        /// <summary>移動出荷数</summary>
        private Double _moveShipmentCnt;

        /// <summary>移動出荷額</summary>
        private Int64 _moveShipmentPrice;


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

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>実績集計区分プロパティ</summary>
        /// <value>0:合計 1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RsltTtlDivCd
        {
            get { return _rsltTtlDivCd; }
            set { _rsltTtlDivCd = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>売上数計プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount
        {
            get { return _totalSalesCount; }
            set { _totalSalesCount = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>売上金額プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>返品額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  DiscountPrice
        /// <summary>値引金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
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

        /// public propaty name  :  StockTotalPrice
        /// <summary>仕入金額合計プロパティ</summary>
        /// <value>値引含む</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  TotalStockCount
        /// <summary>仕入数計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入数計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount
        {
            get { return _totalStockCount; }
            set { _totalStockCount = value; }
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

        /// public propaty name  :  StockTotalDiscount
        /// <summary>仕入値引計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalDiscount
        {
            get { return _stockTotalDiscount; }
            set { _stockTotalDiscount = value; }
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


        /// <summary>
        /// 売上仕入月次集計データワークコンストラクタ
        /// </summary>
        /// <returns>MTtlSalesStockSlipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesStockSlipWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MTtlSalesStockSlipWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MTtlSalesStockSlipWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   MTtlSalesStockSlipWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MTtlSalesStockSlipWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesStockSlipWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MTtlSalesStockSlipWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MTtlSalesStockSlipWork || graph is ArrayList || graph is MTtlSalesStockSlipWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MTtlSalesStockSlipWork).FullName));

            if (graph != null && graph is MTtlSalesStockSlipWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MTtlSalesStockSlipWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MTtlSalesStockSlipWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MTtlSalesStockSlipWork[])graph).Length;
            }
            else if (graph is MTtlSalesStockSlipWork)
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
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //実績集計区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //売上数計
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPrice
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //仕入金額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //仕入数計
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount
            //仕入返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice
            //仕入値引計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalDiscount
            //移動入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveArrivalCnt
            //移動入荷額
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveArrivalPrice
            //移動出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveShipmentCnt
            //移動出荷額
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveShipmentPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is MTtlSalesStockSlipWork)
            {
                MTtlSalesStockSlipWork temp = (MTtlSalesStockSlipWork)graph;

                SetMTtlSalesStockSlipWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MTtlSalesStockSlipWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MTtlSalesStockSlipWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MTtlSalesStockSlipWork temp in lst)
                {
                    SetMTtlSalesStockSlipWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MTtlSalesStockSlipWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  MTtlSalesStockSlipWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesStockSlipWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMTtlSalesStockSlipWork(System.IO.BinaryWriter writer, MTtlSalesStockSlipWork temp)
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
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //計上年月
            writer.Write(temp.AddUpYearMonth);
            //実績集計区分
            writer.Write(temp.RsltTtlDivCd);
            //仕入先コード
            writer.Write(temp.CustomerCode);
            //売上数計
            writer.Write(temp.TotalSalesCount);
            //売上金額
            writer.Write(temp.SalesMoney);
            //返品額
            writer.Write(temp.SalesRetGoodsPrice);
            //値引金額
            writer.Write(temp.DiscountPrice);
            //粗利金額
            writer.Write(temp.GrossProfit);
            //仕入金額合計
            writer.Write(temp.StockTotalPrice);
            //仕入数計
            writer.Write(temp.TotalStockCount);
            //仕入返品額
            writer.Write(temp.StockRetGoodsPrice);
            //仕入値引計
            writer.Write(temp.StockTotalDiscount);
            //移動入荷数
            writer.Write(temp.MoveArrivalCnt);
            //移動入荷額
            writer.Write(temp.MoveArrivalPrice);
            //移動出荷数
            writer.Write(temp.MoveShipmentCnt);
            //移動出荷額
            writer.Write(temp.MoveShipmentPrice);

        }

        /// <summary>
        ///  MTtlSalesStockSlipWorkインスタンス取得
        /// </summary>
        /// <returns>MTtlSalesStockSlipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesStockSlipWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MTtlSalesStockSlipWork GetMTtlSalesStockSlipWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MTtlSalesStockSlipWork temp = new MTtlSalesStockSlipWork();

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
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //計上年月
            temp.AddUpYearMonth = reader.ReadInt32();
            //実績集計区分
            temp.RsltTtlDivCd = reader.ReadInt32();
            //仕入先コード
            temp.CustomerCode = reader.ReadInt32();
            //売上数計
            temp.TotalSalesCount = reader.ReadDouble();
            //売上金額
            temp.SalesMoney = reader.ReadInt64();
            //返品額
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //値引金額
            temp.DiscountPrice = reader.ReadInt64();
            //粗利金額
            temp.GrossProfit = reader.ReadInt64();
            //仕入金額合計
            temp.StockTotalPrice = reader.ReadInt64();
            //仕入数計
            temp.TotalStockCount = reader.ReadDouble();
            //仕入返品額
            temp.StockRetGoodsPrice = reader.ReadInt64();
            //仕入値引計
            temp.StockTotalDiscount = reader.ReadInt64();
            //移動入荷数
            temp.MoveArrivalCnt = reader.ReadDouble();
            //移動入荷額
            temp.MoveArrivalPrice = reader.ReadInt64();
            //移動出荷数
            temp.MoveShipmentCnt = reader.ReadDouble();
            //移動出荷額
            temp.MoveShipmentPrice = reader.ReadInt64();


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
        /// <returns>MTtlSalesStockSlipWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesStockSlipWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MTtlSalesStockSlipWork temp = GetMTtlSalesStockSlipWork(reader, serInfo);
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
                    retValue = (MTtlSalesStockSlipWork[])lst.ToArray(typeof(MTtlSalesStockSlipWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
