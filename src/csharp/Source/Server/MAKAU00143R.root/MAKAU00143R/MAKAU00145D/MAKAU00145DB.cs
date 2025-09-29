using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuplierPayUpdateWork
    /// <summary>
    ///                      仕入先支払金額更新パラメータクラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先支払金額更新パラメータクラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/04/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuplierPayUpdateWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>仕入先締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _supplierTotalDay;

        /// <summary>仕入先コード1</summary>
        private Int32 _supplierCd1;

        /// <summary>仕入先1締日</summary>
        private Int32 _supplier1TotalDay;

        /// <summary>仕入先コード2</summary>
        private Int32 _supplierCd2;

        /// <summary>仕入先2締日</summary>
        private Int32 _supplier2TotalDay;

        /// <summary>仕入先コード3</summary>
        private Int32 _supplierCd3;

        /// <summary>仕入先3締日</summary>
        private Int32 _supplier3TotalDay;

        /// <summary>仕入先コード4</summary>
        private Int32 _supplierCd4;

        /// <summary>仕入先4締日</summary>
        private Int32 _supplier4TotalDay;

        /// <summary>仕入先コード5</summary>
        private Int32 _supplierCd5;

        /// <summary>仕入先5締日</summary>
        private Int32 _supplier5TotalDay;

        /// <summary>仕入先コード6</summary>
        private Int32 _supplierCd6;

        /// <summary>仕入先6締日</summary>
        private Int32 _supplier6TotalDay;

        /// <summary>仕入先コード7</summary>
        private Int32 _supplierCd7;

        /// <summary>仕入先7締日</summary>
        private Int32 _supplier7TotalDay;

        /// <summary>仕入先コード8</summary>
        private Int32 _supplierCd8;

        /// <summary>仕入先8締日</summary>
        private Int32 _supplier8TotalDay;

        /// <summary>仕入先コード9</summary>
        private Int32 _supplierCd9;

        /// <summary>仕入先9締日</summary>
        private Int32 _supplier9TotalDay;

        /// <summary>仕入先コード10</summary>
        private Int32 _supplierCd10;

        /// <summary>仕入先10締日</summary>
        private Int32 _supplier10TotalDay;

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD　支払締を行った日</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>更新対象フラグ</summary>
        /// <remarks>1:全得意先対象,2:個別得意先指定,3:個別得意先除外</remarks>
        private Int32 _updObjectFlag;

        /// <summary>処理内容フラグ</summary>
        /// <remarks>1:締次更新処理,2:支払処理</remarks>
        private Int32 _procCntntsFlag;


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

        /// public propaty name  :  CustomerTotalDay
        /// <summary>仕入先締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay
        {
            get { return _supplierTotalDay; }
            set { _supplierTotalDay = value; }
        }

        /// public propaty name  :  SupplierCd1
        /// <summary>仕入先コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd1
        {
            get { return _supplierCd1; }
            set { _supplierCd1 = value; }
        }

        /// public propaty name  :  Supplier1TotalDay
        /// <summary>仕入先1締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先1締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier1TotalDay
        {
            get { return _supplier1TotalDay; }
            set { _supplier1TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd2
        /// <summary>仕入先コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd2
        {
            get { return _supplierCd2; }
            set { _supplierCd2 = value; }
        }

        /// public propaty name  :  Supplier2TotalDay
        /// <summary>仕入先2締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先2締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier2TotalDay
        {
            get { return _supplier2TotalDay; }
            set { _supplier2TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd3
        /// <summary>仕入先コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd3
        {
            get { return _supplierCd3; }
            set { _supplierCd3 = value; }
        }

        /// public propaty name  :  Supplier3TotalDay
        /// <summary>仕入先3締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先3締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier3TotalDay
        {
            get { return _supplier3TotalDay; }
            set { _supplier3TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd4
        /// <summary>仕入先コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd4
        {
            get { return _supplierCd4; }
            set { _supplierCd4 = value; }
        }

        /// public propaty name  :  Supplier4TotalDay
        /// <summary>仕入先4締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先4締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier4TotalDay
        {
            get { return _supplier4TotalDay; }
            set { _supplier4TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd5
        /// <summary>仕入先コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd5
        {
            get { return _supplierCd5; }
            set { _supplierCd5 = value; }
        }

        /// public propaty name  :  Supplier5TotalDay
        /// <summary>仕入先5締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先5締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier5TotalDay
        {
            get { return _supplier5TotalDay; }
            set { _supplier5TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd6
        /// <summary>仕入コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd6
        {
            get { return _supplierCd6; }
            set { _supplierCd6 = value; }
        }

        /// public propaty name  :  Supplier6TotalDay
        /// <summary>仕入先6締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先6締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier6TotalDay
        {
            get { return _supplier6TotalDay; }
            set { _supplier6TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd7
        /// <summary>仕入先コード7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd7
        {
            get { return _supplierCd7; }
            set { _supplierCd7 = value; }
        }

        /// public propaty name  :  Supplier7TotalDay
        /// <summary>仕入先7締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先7締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier7TotalDay
        {
            get { return _supplier7TotalDay; }
            set { _supplier7TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd8
        /// <summary>仕入先コード8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd8
        {
            get { return _supplierCd8; }
            set { _supplierCd8 = value; }
        }

        /// public propaty name  :  Supplier8TotalDay
        /// <summary>仕入先8締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先8締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier8TotalDay
        {
            get { return _supplier8TotalDay; }
            set { _supplier8TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd9
        /// <summary>仕入先コード9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd9
        {
            get { return _supplierCd9; }
            set { _supplierCd9 = value; }
        }

        /// public propaty name  :  Supplier9TotalDay
        /// <summary>仕入先9締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先9締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier9TotalDay
        {
            get { return _supplier9TotalDay; }
            set { _supplier9TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd10
        /// <summary>仕入先コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd10
        {
            get { return _supplierCd10; }
            set { _supplierCd10 = value; }
        }

        /// public propaty name  :  Supplier10TotalDay
        /// <summary>仕入先10締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先10締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Supplier10TotalDay
        {
            get { return _supplier10TotalDay; }
            set { _supplier10TotalDay = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD　支払締を行った日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
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

        /// public propaty name  :  UpdObjectFlag
        /// <summary>更新対象フラグプロパティ</summary>
        /// <value>1:全得意先対象,2:個別得意先指定,3:個別得意先除外</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新対象フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdObjectFlag
        {
            get { return _updObjectFlag; }
            set { _updObjectFlag = value; }
        }

        /// public propaty name  :  ProcCntntsFlag
        /// <summary>処理内容フラグプロパティ</summary>
        /// <value>1:締次更新処理,2:支払処理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理内容フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcCntntsFlag
        {
            get { return _procCntntsFlag; }
            set { _procCntntsFlag = value; }
        }


        /// <summary>
        /// 仕入先支払金額更新パラメータクラスワークコンストラクタ
        /// </summary>
        /// <returns>SuplierPayUpdateWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayUpdateWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuplierPayUpdateWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuplierPayUpdateWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuplierPayUpdateWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuplierPayUpdateWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayUpdateWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuplierPayUpdateWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuplierPayUpdateWork || graph is ArrayList || graph is SuplierPayUpdateWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuplierPayUpdateWork).FullName));

            if (graph != null && graph is SuplierPayUpdateWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuplierPayUpdateWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuplierPayUpdateWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuplierPayUpdateWork[])graph).Length;
            }
            else if (graph is SuplierPayUpdateWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //仕入先締日
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay
            //仕入先コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd1
            //仕入先1締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier1TotalDay
            //仕入先コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd2
            //仕入先2締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier2TotalDay
            //仕入先コード3
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd3
            //仕入先3締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier3TotalDay
            //仕入先コード4
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd4
            //仕入先4締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier4TotalDay
            //仕入先コード5
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd5
            //仕入先5締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier5TotalDay
            //仕入先コード6
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd6
            //仕入先6締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier6TotalDay
            //仕入先コード7
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd7
            //仕入先7締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier7TotalDay
            //仕入先コード8
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd8
            //仕入先8締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier8TotalDay
            //仕入先コード9
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd9
            //仕入先9締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier9TotalDay
            //仕入先コード10
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd10
            //仕入先10締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier10TotalDay
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //更新対象フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdObjectFlag
            //処理内容フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcCntntsFlag


            serInfo.Serialize(writer, serInfo);
            if (graph is SuplierPayUpdateWork)
            {
                SuplierPayUpdateWork temp = (SuplierPayUpdateWork)graph;

                SetSuplierPayUpdateWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuplierPayUpdateWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuplierPayUpdateWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuplierPayUpdateWork temp in lst)
                {
                    SetSuplierPayUpdateWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuplierPayUpdateWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  SuplierPayUpdateWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayUpdateWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSuplierPayUpdateWork(System.IO.BinaryWriter writer, SuplierPayUpdateWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //仕入先締日
            writer.Write(temp.SupplierTotalDay);
            //仕入先コード1
            writer.Write(temp.SupplierCd1);
            //仕入先1締日
            writer.Write(temp.Supplier1TotalDay);
            //仕入先コード2
            writer.Write(temp.SupplierCd2);
            //仕入先2締日
            writer.Write(temp.Supplier2TotalDay);
            //仕入先コード3
            writer.Write(temp.SupplierCd3);
            //仕入先3締日
            writer.Write(temp.Supplier3TotalDay);
            //仕入先コード4
            writer.Write(temp.SupplierCd4);
            //仕入先4締日
            writer.Write(temp.Supplier4TotalDay);
            //仕入先コード5
            writer.Write(temp.SupplierCd5);
            //仕入先5締日
            writer.Write(temp.Supplier5TotalDay);
            //仕入先コード6
            writer.Write(temp.SupplierCd6);
            //仕入先6締日
            writer.Write(temp.Supplier6TotalDay);
            //仕入先コード7
            writer.Write(temp.SupplierCd7);
            //仕入先7締日
            writer.Write(temp.Supplier7TotalDay);
            //仕入先コード8
            writer.Write(temp.SupplierCd8);
            //仕入先8締日
            writer.Write(temp.Supplier8TotalDay);
            //仕入先コード9
            writer.Write(temp.SupplierCd9);
            //仕入先9締日
            writer.Write(temp.Supplier9TotalDay);
            //仕入先コード10
            writer.Write(temp.SupplierCd10);
            //仕入先10締日
            writer.Write(temp.Supplier10TotalDay);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //更新対象フラグ
            writer.Write(temp.UpdObjectFlag);
            //処理内容フラグ
            writer.Write(temp.ProcCntntsFlag);

        }

        /// <summary>
        ///  SuplierPayUpdateWorkインスタンス取得
        /// </summary>
        /// <returns>SuplierPayUpdateWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayUpdateWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SuplierPayUpdateWork GetSuplierPayUpdateWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuplierPayUpdateWork temp = new SuplierPayUpdateWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //仕入先締日
            temp.SupplierTotalDay = reader.ReadInt32();
            //仕入先コード1
            temp.SupplierCd1 = reader.ReadInt32();
            //仕入先1締日
            temp.Supplier1TotalDay = reader.ReadInt32();
            //仕入先コード2
            temp.SupplierCd2 = reader.ReadInt32();
            //仕入先2締日
            temp.Supplier2TotalDay = reader.ReadInt32();
            //仕入先コード3
            temp.SupplierCd3 = reader.ReadInt32();
            //仕入先3締日
            temp.Supplier3TotalDay = reader.ReadInt32();
            //仕入先コード4
            temp.SupplierCd4 = reader.ReadInt32();
            //仕入先4締日
            temp.Supplier4TotalDay = reader.ReadInt32();
            //仕入先コード5
            temp.SupplierCd5 = reader.ReadInt32();
            //仕入先5締日
            temp.Supplier5TotalDay = reader.ReadInt32();
            //仕入先コード6
            temp.SupplierCd6 = reader.ReadInt32();
            //仕入先6締日
            temp.Supplier6TotalDay = reader.ReadInt32();
            //仕入先コード7
            temp.SupplierCd7 = reader.ReadInt32();
            //仕入先7締日
            temp.Supplier7TotalDay = reader.ReadInt32();
            //仕入先コード8
            temp.SupplierCd8 = reader.ReadInt32();
            //仕入先8締日
            temp.Supplier8TotalDay = reader.ReadInt32();
            //仕入先コード9
            temp.SupplierCd9 = reader.ReadInt32();
            //仕入先9締日
            temp.Supplier9TotalDay = reader.ReadInt32();
            //仕入先コード10
            temp.SupplierCd10 = reader.ReadInt32();
            //仕入先10締日
            temp.Supplier10TotalDay = reader.ReadInt32();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //更新対象フラグ
            temp.UpdObjectFlag = reader.ReadInt32();
            //処理内容フラグ
            temp.ProcCntntsFlag = reader.ReadInt32();


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
        /// <returns>SuplierPayUpdateWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayUpdateWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuplierPayUpdateWork temp = GetSuplierPayUpdateWork(reader, serInfo);
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
                    retValue = (SuplierPayUpdateWork[])lst.ToArray(typeof(SuplierPayUpdateWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
