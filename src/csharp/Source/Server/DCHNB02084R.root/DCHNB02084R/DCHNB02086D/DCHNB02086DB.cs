using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesMonthYearReportResultWork
    /// <summary>
    ///                      売上月報年報抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上月報年報抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesMonthYearReportResultWork
    {
        /// <summary>コード</summary>
        /// <remarks>XXXコード(担当者/受注者/発行者/地区/業種/販売区分)</remarks>
        private string _code = "";

        /// <summary>名称</summary>
        /// <remarks>XXX名称(担当者/受注者/発行者/地区/業種/販売区分)</remarks>
        private string _name = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点名称</summary>
        /// <remarks>拠点ガイド略称</remarks>
        private string _companyName1 = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        /// <remarks>得意先略称</remarks>
        private string _customerSnm = "";

        /// <summary>当月売上金額</summary>
        private Int64 _monthSalesMoney;

        /// <summary>当月返品額</summary>
        private Int64 _monthSalesRetGoodsPrice;

        /// <summary>当月値引金額</summary>
        private Int64 _monthDiscountPrice;

        /// <summary>当月売上目標金額</summary>
        private Int64 _monthSalesTargetMoney;

        /// <summary>当月粗利金額</summary>
        private Int64 _monthGrossProfit;

        /// <summary>当月売上目標粗利額</summary>
        private Int64 _monthSalesTargetProfit;

        /// <summary>当期売上金額</summary>
        private Int64 _annualSalesMoney;

        /// <summary>当期返品額</summary>
        private Int64 _annualSalesRetGoodsPrice;

        /// <summary>当期値引金額</summary>
        private Int64 _annualDiscountPrice;

        /// <summary>当期売上目標金額</summary>
        private Int64 _annualSalesTargetMoney;

        /// <summary>当期粗利金額</summary>
        private Int64 _annualGrossProfit;

        /// <summary>当期売上目標粗利額</summary>
        private Int64 _annualSalesTargetProfit;


        /// public propaty name  :  Code
        /// <summary>コードプロパティ</summary>
        /// <value>XXXコード(担当者/受注者/発行者/地区/業種/販売区分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// public propaty name  :  Name
        /// <summary>名称プロパティ</summary>
        /// <value>XXX名称(担当者/受注者/発行者/地区/業種/販売区分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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

        /// public propaty name  :  CompanyName1
        /// <summary>拠点名称プロパティ</summary>
        /// <value>拠点ガイド略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先名称プロパティ</summary>
        /// <value>得意先略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  MonthSalesMoney
        /// <summary>当月売上金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesMoney
        {
            get { return _monthSalesMoney; }
            set { _monthSalesMoney = value; }
        }

        /// public propaty name  :  MonthSalesRetGoodsPrice
        /// <summary>当月返品額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月返品額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesRetGoodsPrice
        {
            get { return _monthSalesRetGoodsPrice; }
            set { _monthSalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  MonthDiscountPrice
        /// <summary>当月値引金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthDiscountPrice
        {
            get { return _monthDiscountPrice; }
            set { _monthDiscountPrice = value; }
        }

        /// public propaty name  :  MonthSalesTargetMoney
        /// <summary>当月売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月売上目標金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesTargetMoney
        {
            get { return _monthSalesTargetMoney; }
            set { _monthSalesTargetMoney = value; }
        }

        /// public propaty name  :  MonthGrossProfit
        /// <summary>当月粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthGrossProfit
        {
            get { return _monthGrossProfit; }
            set { _monthGrossProfit = value; }
        }

        /// public propaty name  :  MonthSalesTargetProfit
        /// <summary>当月売上目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月売上目標粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesTargetProfit
        {
            get { return _monthSalesTargetProfit; }
            set { _monthSalesTargetProfit = value; }
        }

        /// public propaty name  :  AnnualSalesMoney
        /// <summary>当期売上金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualSalesMoney
        {
            get { return _annualSalesMoney; }
            set { _annualSalesMoney = value; }
        }

        /// public propaty name  :  AnnualSalesRetGoodsPrice
        /// <summary>当期返品額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期返品額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualSalesRetGoodsPrice
        {
            get { return _annualSalesRetGoodsPrice; }
            set { _annualSalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  AnnualDiscountPrice
        /// <summary>当期値引金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualDiscountPrice
        {
            get { return _annualDiscountPrice; }
            set { _annualDiscountPrice = value; }
        }

        /// public propaty name  :  AnnualSalesTargetMoney
        /// <summary>当期売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期売上目標金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualSalesTargetMoney
        {
            get { return _annualSalesTargetMoney; }
            set { _annualSalesTargetMoney = value; }
        }

        /// public propaty name  :  AnnualGrossProfit
        /// <summary>当期粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualGrossProfit
        {
            get { return _annualGrossProfit; }
            set { _annualGrossProfit = value; }
        }

        /// public propaty name  :  AnnualSalesTargetProfit
        /// <summary>当期売上目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期売上目標粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualSalesTargetProfit
        {
            get { return _annualSalesTargetProfit; }
            set { _annualSalesTargetProfit = value; }
        }


        /// <summary>
        /// 売上月報年報抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesMonthYearReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesMonthYearReportResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesMonthYearReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesMonthYearReportResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesMonthYearReportResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesMonthYearReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesMonthYearReportResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesMonthYearReportResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesMonthYearReportResultWork || graph is ArrayList || graph is SalesMonthYearReportResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesMonthYearReportResultWork).FullName));

            if (graph != null && graph is SalesMonthYearReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesMonthYearReportResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesMonthYearReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesMonthYearReportResultWork[])graph).Length;
            }
            else if (graph is SalesMonthYearReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //コード
            serInfo.MemberInfo.Add(typeof(string)); //Code
            //名称
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //当月売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoney
            //当月返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesRetGoodsPrice
            //当月値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthDiscountPrice
            //当月売上目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTargetMoney
            //当月粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfit
            //当月売上目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTargetProfit
            //当期売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesMoney
            //当期返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesRetGoodsPrice
            //当期値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualDiscountPrice
            //当期売上目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesTargetMoney
            //当期粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualGrossProfit
            //当期売上目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesTargetProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesMonthYearReportResultWork)
            {
                SalesMonthYearReportResultWork temp = (SalesMonthYearReportResultWork)graph;

                SetSalesMonthYearReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesMonthYearReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesMonthYearReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesMonthYearReportResultWork temp in lst)
                {
                    SetSalesMonthYearReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesMonthYearReportResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  SalesMonthYearReportResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesMonthYearReportResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesMonthYearReportResultWork(System.IO.BinaryWriter writer, SalesMonthYearReportResultWork temp)
        {
            //コード
            writer.Write(temp.Code);
            //名称
            writer.Write(temp.Name);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点名称
            writer.Write(temp.CompanyName1);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerSnm);
            //当月売上金額
            writer.Write(temp.MonthSalesMoney);
            //当月返品額
            writer.Write(temp.MonthSalesRetGoodsPrice);
            //当月値引金額
            writer.Write(temp.MonthDiscountPrice);
            //当月売上目標金額
            writer.Write(temp.MonthSalesTargetMoney);
            //当月粗利金額
            writer.Write(temp.MonthGrossProfit);
            //当月売上目標粗利額
            writer.Write(temp.MonthSalesTargetProfit);
            //当期売上金額
            writer.Write(temp.AnnualSalesMoney);
            //当期返品額
            writer.Write(temp.AnnualSalesRetGoodsPrice);
            //当期値引金額
            writer.Write(temp.AnnualDiscountPrice);
            //当期売上目標金額
            writer.Write(temp.AnnualSalesTargetMoney);
            //当期粗利金額
            writer.Write(temp.AnnualGrossProfit);
            //当期売上目標粗利額
            writer.Write(temp.AnnualSalesTargetProfit);

        }

        /// <summary>
        ///  SalesMonthYearReportResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalesMonthYearReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesMonthYearReportResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalesMonthYearReportResultWork GetSalesMonthYearReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesMonthYearReportResultWork temp = new SalesMonthYearReportResultWork();

            //コード
            temp.Code = reader.ReadString();
            //名称
            temp.Name = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点名称
            temp.CompanyName1 = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerSnm = reader.ReadString();
            //当月売上金額
            temp.MonthSalesMoney = reader.ReadInt64();
            //当月返品額
            temp.MonthSalesRetGoodsPrice = reader.ReadInt64();
            //当月値引金額
            temp.MonthDiscountPrice = reader.ReadInt64();
            //当月売上目標金額
            temp.MonthSalesTargetMoney = reader.ReadInt64();
            //当月粗利金額
            temp.MonthGrossProfit = reader.ReadInt64();
            //当月売上目標粗利額
            temp.MonthSalesTargetProfit = reader.ReadInt64();
            //当期売上金額
            temp.AnnualSalesMoney = reader.ReadInt64();
            //当期返品額
            temp.AnnualSalesRetGoodsPrice = reader.ReadInt64();
            //当期値引金額
            temp.AnnualDiscountPrice = reader.ReadInt64();
            //当期売上目標金額
            temp.AnnualSalesTargetMoney = reader.ReadInt64();
            //当期粗利金額
            temp.AnnualGrossProfit = reader.ReadInt64();
            //当期売上目標粗利額
            temp.AnnualSalesTargetProfit = reader.ReadInt64();


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
        /// <returns>SalesMonthYearReportResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesMonthYearReportResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesMonthYearReportResultWork temp = GetSalesMonthYearReportResultWork(reader, serInfo);
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
                    retValue = (SalesMonthYearReportResultWork[])lst.ToArray(typeof(SalesMonthYearReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
