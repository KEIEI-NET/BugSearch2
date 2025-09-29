using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesSlipYearContrastResultWork
    /// <summary>
    ///                      売上仕入対比表(月報年報)抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上仕入対比表(月報年報)抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesSlipYearContrastResultWork 
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>売上金額(合計)(当月)</summary>
        /// <remarks>税抜き</remarks>
        private Int64 _salesMoney;

        /// <summary>売上金額(在庫)(当月)</summary>
        private Int64 _salesMoneyStock;

        /// <summary>粗利金額(当月)</summary>
        private Int64 _grossProfit;

        /// <summary>移動出荷額(当月)</summary>
        private Int64 _moveShipmentPrice;

        /// <summary>仕入金額合計(合計)(当月)</summary>
        /// <remarks>値引含む</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>仕入金額合計(在庫)(当月)</summary>
        private Int64 _stockTotalPriceStock;

        /// <summary>移動入荷額(当月)</summary>
        private Int64 _moveArrivalPrice;

        /// <summary>売上金額(合計)(当期)</summary>
        private Int64 _annualSalesMoney;

        /// <summary>売上金額(在庫)(当期)</summary>
        private Int64 _annualSalesMoneyStock;

        /// <summary>粗利金額(当期)</summary>
        private Int64 _annualGrossProfit;

        /// <summary>移動出荷額(当期)</summary>
        private Int64 _annualMoveShipmentPrice;

        /// <summary>仕入金額合計(合計)(当期)</summary>
        private Int64 _annualStockTotalPrice;

        /// <summary>仕入金額合計(在庫)(当期)</summary>
        private Int64 _annualStockTotalPriceStock;

        /// <summary>移動入荷額(当期)</summary>
        private Int64 _annualMoveArrivalPrice;


        /// public propaty name  :  AddUpSecCode
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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
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

        /// public propaty name  :  SalesMoney
        /// <summary>売上金額(合計)(当月)プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(合計)(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  SalesMoneyStock
        /// <summary>売上金額(在庫)(当月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(在庫)(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyStock
        {
            get { return _salesMoneyStock; }
            set { _salesMoneyStock = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>粗利金額(当月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  MoveShipmentPrice
        /// <summary>移動出荷額(当月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動出荷額(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MoveShipmentPrice
        {
            get { return _moveShipmentPrice; }
            set { _moveShipmentPrice = value; }
        }

        /// public propaty name  :  StockTotalPrice
        /// <summary>仕入金額合計(合計)(当月)プロパティ</summary>
        /// <value>値引含む</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(合計)(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  StockTotalPriceStock
        /// <summary>仕入金額合計(在庫)(当月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(在庫)(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPriceStock
        {
            get { return _stockTotalPriceStock; }
            set { _stockTotalPriceStock = value; }
        }

        /// public propaty name  :  MoveArrivalPrice
        /// <summary>移動入荷額(当月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動入荷額(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MoveArrivalPrice
        {
            get { return _moveArrivalPrice; }
            set { _moveArrivalPrice = value; }
        }

        /// public propaty name  :  AnnualSalesMoney
        /// <summary>売上金額(合計)(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(合計)(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualSalesMoney
        {
            get { return _annualSalesMoney; }
            set { _annualSalesMoney = value; }
        }

        /// public propaty name  :  AnnualSalesMoneyStock
        /// <summary>売上金額(在庫)(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(在庫)(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualSalesMoneyStock
        {
            get { return _annualSalesMoneyStock; }
            set { _annualSalesMoneyStock = value; }
        }

        /// public propaty name  :  AnnualGrossProfit
        /// <summary>粗利金額(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualGrossProfit
        {
            get { return _annualGrossProfit; }
            set { _annualGrossProfit = value; }
        }

        /// public propaty name  :  AnnualMoveShipmentPrice
        /// <summary>移動出荷額(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動出荷額(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualMoveShipmentPrice
        {
            get { return _annualMoveShipmentPrice; }
            set { _annualMoveShipmentPrice = value; }
        }

        /// public propaty name  :  AnnualStockTotalPrice
        /// <summary>仕入金額合計(合計)(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(合計)(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualStockTotalPrice
        {
            get { return _annualStockTotalPrice; }
            set { _annualStockTotalPrice = value; }
        }

        /// public propaty name  :  AnnualStockTotalPriceStock
        /// <summary>仕入金額合計(在庫)(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(在庫)(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualStockTotalPriceStock
        {
            get { return _annualStockTotalPriceStock; }
            set { _annualStockTotalPriceStock = value; }
        }

        /// public propaty name  :  AnnualMoveArrivalPrice
        /// <summary>移動入荷額(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動入荷額(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualMoveArrivalPrice
        {
            get { return _annualMoveArrivalPrice; }
            set { _annualMoveArrivalPrice = value; }
        }


        /// <summary>
        /// 売上仕入対比表(月報年報)抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesSlipYearContrastResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipYearContrastResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSlipYearContrastResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesSlipYearContrastResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesSlipYearContrastResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesSlipYearContrastResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipYearContrastResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesSlipYearContrastResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesSlipYearContrastResultWork || graph is ArrayList || graph is SalesSlipYearContrastResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesSlipYearContrastResultWork).FullName));

            if (graph != null && graph is SalesSlipYearContrastResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesSlipYearContrastResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesSlipYearContrastResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesSlipYearContrastResultWork[])graph).Length;
            }
            else if (graph is SalesSlipYearContrastResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //売上金額(合計)(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //売上金額(在庫)(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyStock
            //粗利金額(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //移動出荷額(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveShipmentPrice
            //仕入金額合計(合計)(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //仕入金額合計(在庫)(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPriceStock
            //移動入荷額(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveArrivalPrice
            //売上金額(合計)(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesMoney
            //売上金額(在庫)(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesMoneyStock
            //粗利金額(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualGrossProfit
            //移動出荷額(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualMoveShipmentPrice
            //仕入金額合計(合計)(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockTotalPrice
            //仕入金額合計(在庫)(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockTotalPriceStock
            //移動入荷額(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualMoveArrivalPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesSlipYearContrastResultWork)
            {
                SalesSlipYearContrastResultWork temp = (SalesSlipYearContrastResultWork)graph;

                SetSalesSlipYearContrastResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesSlipYearContrastResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesSlipYearContrastResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesSlipYearContrastResultWork temp in lst)
                {
                    SetSalesSlipYearContrastResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesSlipYearContrastResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  SalesSlipYearContrastResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipYearContrastResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesSlipYearContrastResultWork(System.IO.BinaryWriter writer, SalesSlipYearContrastResultWork temp)
        {
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //売上金額(合計)(当月)
            writer.Write(temp.SalesMoney);
            //売上金額(在庫)(当月)
            writer.Write(temp.SalesMoneyStock);
            //粗利金額(当月)
            writer.Write(temp.GrossProfit);
            //移動出荷額(当月)
            writer.Write(temp.MoveShipmentPrice);
            //仕入金額合計(合計)(当月)
            writer.Write(temp.StockTotalPrice);
            //仕入金額合計(在庫)(当月)
            writer.Write(temp.StockTotalPriceStock);
            //移動入荷額(当月)
            writer.Write(temp.MoveArrivalPrice);
            //売上金額(合計)(当期)
            writer.Write(temp.AnnualSalesMoney);
            //売上金額(在庫)(当期)
            writer.Write(temp.AnnualSalesMoneyStock);
            //粗利金額(当期)
            writer.Write(temp.AnnualGrossProfit);
            //移動出荷額(当期)
            writer.Write(temp.AnnualMoveShipmentPrice);
            //仕入金額合計(合計)(当期)
            writer.Write(temp.AnnualStockTotalPrice);
            //仕入金額合計(在庫)(当期)
            writer.Write(temp.AnnualStockTotalPriceStock);
            //移動入荷額(当期)
            writer.Write(temp.AnnualMoveArrivalPrice);

        }

        /// <summary>
        ///  SalesSlipYearContrastResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalesSlipYearContrastResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipYearContrastResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalesSlipYearContrastResultWork GetSalesSlipYearContrastResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesSlipYearContrastResultWork temp = new SalesSlipYearContrastResultWork();

            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //売上金額(合計)(当月)
            temp.SalesMoney = reader.ReadInt64();
            //売上金額(在庫)(当月)
            temp.SalesMoneyStock = reader.ReadInt64();
            //粗利金額(当月)
            temp.GrossProfit = reader.ReadInt64();
            //移動出荷額(当月)
            temp.MoveShipmentPrice = reader.ReadInt64();
            //仕入金額合計(合計)(当月)
            temp.StockTotalPrice = reader.ReadInt64();
            //仕入金額合計(在庫)(当月)
            temp.StockTotalPriceStock = reader.ReadInt64();
            //移動入荷額(当月)
            temp.MoveArrivalPrice = reader.ReadInt64();
            //売上金額(合計)(当期)
            temp.AnnualSalesMoney = reader.ReadInt64();
            //売上金額(在庫)(当期)
            temp.AnnualSalesMoneyStock = reader.ReadInt64();
            //粗利金額(当期)
            temp.AnnualGrossProfit = reader.ReadInt64();
            //移動出荷額(当期)
            temp.AnnualMoveShipmentPrice = reader.ReadInt64();
            //仕入金額合計(合計)(当期)
            temp.AnnualStockTotalPrice = reader.ReadInt64();
            //仕入金額合計(在庫)(当期)
            temp.AnnualStockTotalPriceStock = reader.ReadInt64();
            //移動入荷額(当期)
            temp.AnnualMoveArrivalPrice = reader.ReadInt64();


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
        /// <returns>SalesSlipYearContrastResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipYearContrastResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesSlipYearContrastResultWork temp = GetSalesSlipYearContrastResultWork(reader, serInfo);
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
                    retValue = (SalesSlipYearContrastResultWork[])lst.ToArray(typeof(SalesSlipYearContrastResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
