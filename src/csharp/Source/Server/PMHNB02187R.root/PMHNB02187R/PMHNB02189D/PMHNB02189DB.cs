using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustSalesDistributionReportResultWork
    /// <summary>
    ///                      得意先別取引分布表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先別取引分布表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustSalesDistributionReportResultWork 
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _secCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>販売従業員コード</summary>
        /// <remarks>計上担当者</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaName = "";

        /// <summary>伝票枚数</summary>
        private Int32 _salesCount;

        /// <summary>純売上</summary>
        /// <remarks>売上伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>原価金額計</summary>
        private Int64 _totalCost;

        /// <summary>売上日付</summary>
        private DateTime _salesDate;


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

        /// public propaty name  :  SecCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SecCode
        {
            get { return _secCode; }
            set { _secCode = value; }
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
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コードプロパティ</summary>
        /// <value>計上担当者</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// <value>地区コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  SalesCount
        /// <summary>伝票枚数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCount
        {
            get { return _salesCount; }
            set { _salesCount = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>純売上プロパティ</summary>
        /// <value>売上伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純売上プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>原価金額計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }


        /// <summary>
        /// 得意先別取引分布表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustSalesDistributionReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesDistributionReportResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustSalesDistributionReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustSalesDistributionReportResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustSalesDistributionReportResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustSalesDistributionReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesDistributionReportResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustSalesDistributionReportResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustSalesDistributionReportResultWork || graph is ArrayList || graph is CustSalesDistributionReportResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustSalesDistributionReportResultWork).FullName));

            if (graph != null && graph is CustSalesDistributionReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustSalesDistributionReportResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustSalesDistributionReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustSalesDistributionReportResultWork[])graph).Length;
            }
            else if (graph is CustSalesDistributionReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SecCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //販売従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //販売従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCount
            //純売上
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxExc
            //原価金額計
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate


            serInfo.Serialize(writer, serInfo);
            if (graph is CustSalesDistributionReportResultWork)
            {
                CustSalesDistributionReportResultWork temp = (CustSalesDistributionReportResultWork)graph;

                SetCustSalesDistributionReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustSalesDistributionReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustSalesDistributionReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustSalesDistributionReportResultWork temp in lst)
                {
                    SetCustSalesDistributionReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustSalesDistributionReportResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 13;

        /// <summary>
        ///  CustSalesDistributionReportResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesDistributionReportResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustSalesDistributionReportResultWork(System.IO.BinaryWriter writer, CustSalesDistributionReportResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //拠点コード
            writer.Write(temp.SecCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //販売従業員コード
            writer.Write(temp.SalesEmployeeCd);
            //販売従業員名称
            writer.Write(temp.SalesEmployeeNm);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称
            writer.Write(temp.SalesAreaName);
            //伝票枚数
            writer.Write(temp.SalesCount);
            //純売上
            writer.Write(temp.SalesTotalTaxExc);
            //原価金額計
            writer.Write(temp.TotalCost);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);

        }

        /// <summary>
        ///  CustSalesDistributionReportResultWorkインスタンス取得
        /// </summary>
        /// <returns>CustSalesDistributionReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesDistributionReportResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustSalesDistributionReportResultWork GetCustSalesDistributionReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustSalesDistributionReportResultWork temp = new CustSalesDistributionReportResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SecCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //販売従業員コード
            temp.SalesEmployeeCd = reader.ReadString();
            //販売従業員名称
            temp.SalesEmployeeNm = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称
            temp.SalesAreaName = reader.ReadString();
            //伝票枚数
            temp.SalesCount = reader.ReadInt32();
            //純売上
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //原価金額計
            temp.TotalCost = reader.ReadInt64();
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());


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
        /// <returns>CustSalesDistributionReportResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesDistributionReportResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustSalesDistributionReportResultWork temp = GetCustSalesDistributionReportResultWork(reader, serInfo);
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
                    retValue = (CustSalesDistributionReportResultWork[])lst.ToArray(typeof(CustSalesDistributionReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
