using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMonthYearReportResultWork
    /// <summary>
    ///                      仕入月報年報抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入月報年報抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMonthYearReportResultWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>従業員名称</summary>
        private string _employeeName = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>部門名称</summary>
        private string _subSectionName = "";

        /// <summary>課コード</summary>
        private Int32 _minSectionCode;

        /// <summary>課名称</summary>
        private string _minSectionName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>月間仕入数計</summary>
        private Double _monthTotalStockCount;

        /// <summary>月間仕入金額合計</summary>
        private Int64 _monthStockTotalPrice;

        /// <summary>月間仕入返品額</summary>
        private Int64 _monthStockRetGoodsPrice;

        /// <summary>月間仕入値引計</summary>
        private Int64 _monthStockTotalDiscount;

        /// <summary>年間仕入数計</summary>
        private Double _annualTotalStockCount;

        /// <summary>年間仕入金額合計</summary>
        private Int64 _annualStockTotalPrice;

        /// <summary>年間仕入返品額</summary>
        private Int64 _annualStockRetGoodsPrice;

        /// <summary>年間仕入値引計</summary>
        private Int64 _annualStockTotalDiscount;


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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>部門名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { _subSectionName = value; }
        }

        /// public propaty name  :  MinSectionCode
        /// <summary>課コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }

        /// public propaty name  :  MinSectionName
        /// <summary>課名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MinSectionName
        {
            get { return _minSectionName; }
            set { _minSectionName = value; }
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

        /// public propaty name  :  MonthTotalStockCount
        /// <summary>月間仕入数計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月間仕入数計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthTotalStockCount
        {
            get { return _monthTotalStockCount; }
            set { _monthTotalStockCount = value; }
        }

        /// public propaty name  :  MonthStockTotalPrice
        /// <summary>月間仕入金額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月間仕入金額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthStockTotalPrice
        {
            get { return _monthStockTotalPrice; }
            set { _monthStockTotalPrice = value; }
        }

        /// public propaty name  :  MonthStockRetGoodsPrice
        /// <summary>月間仕入返品額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月間仕入返品額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthStockRetGoodsPrice
        {
            get { return _monthStockRetGoodsPrice; }
            set { _monthStockRetGoodsPrice = value; }
        }

        /// public propaty name  :  MonthStockTotalDiscount
        /// <summary>月間仕入値引計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月間仕入値引計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthStockTotalDiscount
        {
            get { return _monthStockTotalDiscount; }
            set { _monthStockTotalDiscount = value; }
        }

        /// public propaty name  :  AnnualTotalStockCount
        /// <summary>年間仕入数計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年間仕入数計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AnnualTotalStockCount
        {
            get { return _annualTotalStockCount; }
            set { _annualTotalStockCount = value; }
        }

        /// public propaty name  :  AnnualStockTotalPrice
        /// <summary>年間仕入金額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年間仕入金額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualStockTotalPrice
        {
            get { return _annualStockTotalPrice; }
            set { _annualStockTotalPrice = value; }
        }

        /// public propaty name  :  AnnualStockRetGoodsPrice
        /// <summary>年間仕入返品額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年間仕入返品額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualStockRetGoodsPrice
        {
            get { return _annualStockRetGoodsPrice; }
            set { _annualStockRetGoodsPrice = value; }
        }

        /// public propaty name  :  AnnualStockTotalDiscount
        /// <summary>年間仕入値引計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年間仕入値引計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualStockTotalDiscount
        {
            get { return _annualStockTotalDiscount; }
            set { _annualStockTotalDiscount = value; }
        }


        /// <summary>
        /// 仕入月報年報抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>StockMonthYearReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMonthYearReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockMonthYearReportResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockMonthYearReportResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockMonthYearReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMonthYearReportResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMonthYearReportResultWork || graph is ArrayList || graph is StockMonthYearReportResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockMonthYearReportResultWork).FullName));

            if (graph != null && graph is StockMonthYearReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMonthYearReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMonthYearReportResultWork[])graph).Length;
            }
            else if (graph is StockMonthYearReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //部門名称
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //課コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //課名称
            serInfo.MemberInfo.Add(typeof(string)); //MinSectionName
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //月間仕入数計
            serInfo.MemberInfo.Add(typeof(Double)); //MonthTotalStockCount
            //月間仕入金額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockTotalPrice
            //月間仕入返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockRetGoodsPrice
            //月間仕入値引計
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockTotalDiscount
            //年間仕入数計
            serInfo.MemberInfo.Add(typeof(Double)); //AnnualTotalStockCount
            //年間仕入金額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockTotalPrice
            //年間仕入返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockRetGoodsPrice
            //年間仕入値引計
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockTotalDiscount


            serInfo.Serialize(writer, serInfo);
            if (graph is StockMonthYearReportResultWork)
            {
                StockMonthYearReportResultWork temp = (StockMonthYearReportResultWork)graph;

                SetStockMonthYearReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockMonthYearReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMonthYearReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMonthYearReportResultWork temp in lst)
                {
                    SetStockMonthYearReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMonthYearReportResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  StockMonthYearReportResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockMonthYearReportResultWork(System.IO.BinaryWriter writer, StockMonthYearReportResultWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //従業員名称
            writer.Write(temp.EmployeeName);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //部門名称
            writer.Write(temp.SubSectionName);
            //課コード
            writer.Write(temp.MinSectionCode);
            //課名称
            writer.Write(temp.MinSectionName);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //月間仕入数計
            writer.Write(temp.MonthTotalStockCount);
            //月間仕入金額合計
            writer.Write(temp.MonthStockTotalPrice);
            //月間仕入返品額
            writer.Write(temp.MonthStockRetGoodsPrice);
            //月間仕入値引計
            writer.Write(temp.MonthStockTotalDiscount);
            //年間仕入数計
            writer.Write(temp.AnnualTotalStockCount);
            //年間仕入金額合計
            writer.Write(temp.AnnualStockTotalPrice);
            //年間仕入返品額
            writer.Write(temp.AnnualStockRetGoodsPrice);
            //年間仕入値引計
            writer.Write(temp.AnnualStockTotalDiscount);

        }

        /// <summary>
        ///  StockMonthYearReportResultWorkインスタンス取得
        /// </summary>
        /// <returns>StockMonthYearReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockMonthYearReportResultWork GetStockMonthYearReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockMonthYearReportResultWork temp = new StockMonthYearReportResultWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //従業員名称
            temp.EmployeeName = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //部門名称
            temp.SubSectionName = reader.ReadString();
            //課コード
            temp.MinSectionCode = reader.ReadInt32();
            //課名称
            temp.MinSectionName = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //月間仕入数計
            temp.MonthTotalStockCount = reader.ReadDouble();
            //月間仕入金額合計
            temp.MonthStockTotalPrice = reader.ReadInt64();
            //月間仕入返品額
            temp.MonthStockRetGoodsPrice = reader.ReadInt64();
            //月間仕入値引計
            temp.MonthStockTotalDiscount = reader.ReadInt64();
            //年間仕入数計
            temp.AnnualTotalStockCount = reader.ReadDouble();
            //年間仕入金額合計
            temp.AnnualStockTotalPrice = reader.ReadInt64();
            //年間仕入返品額
            temp.AnnualStockRetGoodsPrice = reader.ReadInt64();
            //年間仕入値引計
            temp.AnnualStockTotalDiscount = reader.ReadInt64();


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
        /// <returns>StockMonthYearReportResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMonthYearReportResultWork temp = GetStockMonthYearReportResultWork(reader, serInfo);
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
                    retValue = (StockMonthYearReportResultWork[])lst.ToArray(typeof(StockMonthYearReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
