using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustDmdPrcUpdateWork
    /// <summary>
    ///                      得意先請求金額更新パラメータクラスワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先請求金額更新パラメータクラスワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustDmdPrcUpdateWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード,全社：""またはNull</remarks>
        private string _addUpSecCode = "";

        /// <summary>得意先コード1</summary>
        private Int32 _customerCode1;

        /// <summary>得意先1締日</summary>
        private Int32 _customer1TotalDay;

        /// <summary>得意先コード2</summary>
        private Int32 _customerCode2;

        /// <summary>得意先2締日</summary>
        private Int32 _customer2TotalDay;

        /// <summary>得意先コード3</summary>
        private Int32 _customerCode3;

        /// <summary>得意先3締日</summary>
        private Int32 _customer3TotalDay;

        /// <summary>得意先コード4</summary>
        private Int32 _customerCode4;

        /// <summary>得意先4締日</summary>
        private Int32 _customer4TotalDay;

        /// <summary>得意先コード5</summary>
        private Int32 _customerCode5;

        /// <summary>得意先5締日</summary>
        private Int32 _customer5TotalDay;

        /// <summary>得意先コード6</summary>
        private Int32 _customerCode6;

        /// <summary>得意先6締日</summary>
        private Int32 _customer6TotalDay;

        /// <summary>得意先コード7</summary>
        private Int32 _customerCode7;

        /// <summary>得意先7締日</summary>
        private Int32 _customer7TotalDay;

        /// <summary>得意先コード8</summary>
        private Int32 _customerCode8;

        /// <summary>得意先8締日</summary>
        private Int32 _customer8TotalDay;

        /// <summary>得意先コード9</summary>
        private Int32 _customerCode9;

        /// <summary>得意先9締日</summary>
        private Int32 _customer9TotalDay;

        /// <summary>得意先コード10</summary>
        private Int32 _customerCode10;

        /// <summary>得意先10締日</summary>
        private Int32 _customer10TotalDay;

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD　請求締を行った日</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>更新対象フラグ</summary>
        /// <remarks>1:全得意先対象,2:個別得意先指定,3:個別得意先除外</remarks>
        private Int32 _updObjectFlag;

        /// <summary>処理内容フラグ</summary>
        /// <remarks>1:締次更新処理,2:締取消</remarks>
        private Int32 _procCntntsFlag;

        /// <summary>対象締日</summary>
        private Int32 _objTotalDay;

        /// <summary>期末更新区分</summary>
        /// <remarks>0:期末以外,1:期末</remarks>
        private Int32 _termLastDiv;

        /// <summary>得意先締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _customerTotalDay;


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
        /// <value>集計の対象となっている拠点コード,全社：""またはNull</value>
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

        /// public propaty name  :  CustomerCode1
        /// <summary>得意先コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode1
        {
            get { return _customerCode1; }
            set { _customerCode1 = value; }
        }

        /// public propaty name  :  Customer1TotalDay
        /// <summary>得意先1締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先1締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer1TotalDay
        {
            get { return _customer1TotalDay; }
            set { _customer1TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode2
        /// <summary>得意先コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode2
        {
            get { return _customerCode2; }
            set { _customerCode2 = value; }
        }

        /// public propaty name  :  Customer2TotalDay
        /// <summary>得意先2締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先2締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer2TotalDay
        {
            get { return _customer2TotalDay; }
            set { _customer2TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode3
        /// <summary>得意先コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode3
        {
            get { return _customerCode3; }
            set { _customerCode3 = value; }
        }

        /// public propaty name  :  Customer3TotalDay
        /// <summary>得意先3締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先3締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer3TotalDay
        {
            get { return _customer3TotalDay; }
            set { _customer3TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode4
        /// <summary>得意先コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode4
        {
            get { return _customerCode4; }
            set { _customerCode4 = value; }
        }

        /// public propaty name  :  Customer4TotalDay
        /// <summary>得意先4締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先4締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer4TotalDay
        {
            get { return _customer4TotalDay; }
            set { _customer4TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode5
        /// <summary>得意先コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode5
        {
            get { return _customerCode5; }
            set { _customerCode5 = value; }
        }

        /// public propaty name  :  Customer5TotalDay
        /// <summary>得意先5締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先5締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer5TotalDay
        {
            get { return _customer5TotalDay; }
            set { _customer5TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode6
        /// <summary>得意先コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode6
        {
            get { return _customerCode6; }
            set { _customerCode6 = value; }
        }

        /// public propaty name  :  Customer6TotalDay
        /// <summary>得意先6締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先6締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer6TotalDay
        {
            get { return _customer6TotalDay; }
            set { _customer6TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode7
        /// <summary>得意先コード7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode7
        {
            get { return _customerCode7; }
            set { _customerCode7 = value; }
        }

        /// public propaty name  :  Customer7TotalDay
        /// <summary>得意先7締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先7締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer7TotalDay
        {
            get { return _customer7TotalDay; }
            set { _customer7TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode8
        /// <summary>得意先コード8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode8
        {
            get { return _customerCode8; }
            set { _customerCode8 = value; }
        }

        /// public propaty name  :  Customer8TotalDay
        /// <summary>得意先8締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先8締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer8TotalDay
        {
            get { return _customer8TotalDay; }
            set { _customer8TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode9
        /// <summary>得意先コード9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode9
        {
            get { return _customerCode9; }
            set { _customerCode9 = value; }
        }

        /// public propaty name  :  Customer9TotalDay
        /// <summary>得意先9締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先9締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer9TotalDay
        {
            get { return _customer9TotalDay; }
            set { _customer9TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode10
        /// <summary>得意先コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode10
        {
            get { return _customerCode10; }
            set { _customerCode10 = value; }
        }

        /// public propaty name  :  Customer10TotalDay
        /// <summary>得意先10締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先10締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Customer10TotalDay
        {
            get { return _customer10TotalDay; }
            set { _customer10TotalDay = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD　請求締を行った日</value>
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
        /// <value>1:締次更新処理,2:締取消</value>
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

        /// public propaty name  :  ObjTotalDay
        /// <summary>対象締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ObjTotalDay
        {
            get { return _objTotalDay; }
            set { _objTotalDay = value; }
        }

        /// public propaty name  :  TermLastDiv
        /// <summary>期末更新区分プロパティ</summary>
        /// <value>0:期末以外,1:期末</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期末更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TermLastDiv
        {
            get { return _termLastDiv; }
            set { _termLastDiv = value; }
        }

        /// public propaty name  :  CustomerTotalDay
        /// <summary>得意先締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay
        {
            get { return _customerTotalDay; }
            set { _customerTotalDay = value; }
        }


        /// <summary>
        /// 得意先請求金額更新パラメータクラスワークワークコンストラクタ
        /// </summary>
        /// <returns>CustDmdPrcUpdateWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdateWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustDmdPrcUpdateWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustDmdPrcUpdateWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustDmdPrcUpdateWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustDmdPrcUpdateWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdateWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustDmdPrcUpdateWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustDmdPrcUpdateWork || graph is ArrayList || graph is CustDmdPrcUpdateWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustDmdPrcUpdateWork).FullName));

            if (graph != null && graph is CustDmdPrcUpdateWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcUpdateWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustDmdPrcUpdateWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustDmdPrcUpdateWork[])graph).Length;
            }
            else if (graph is CustDmdPrcUpdateWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //得意先コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode1
            //得意先1締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer1TotalDay
            //得意先コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode2
            //得意先2締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer2TotalDay
            //得意先コード3
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode3
            //得意先3締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer3TotalDay
            //得意先コード4
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode4
            //得意先4締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer4TotalDay
            //得意先コード5
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode5
            //得意先5締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer5TotalDay
            //得意先コード6
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode6
            //得意先6締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer6TotalDay
            //得意先コード7
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode7
            //得意先7締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer7TotalDay
            //得意先コード8
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode8
            //得意先8締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer8TotalDay
            //得意先コード9
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode9
            //得意先9締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer9TotalDay
            //得意先コード10
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode10
            //得意先10締日
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer10TotalDay
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //更新対象フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdObjectFlag
            //処理内容フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcCntntsFlag
            //対象締日
            serInfo.MemberInfo.Add(typeof(Int32)); //ObjTotalDay
            //期末更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TermLastDiv
            //得意先締日
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay


            serInfo.Serialize(writer, serInfo);
            if (graph is CustDmdPrcUpdateWork)
            {
                CustDmdPrcUpdateWork temp = (CustDmdPrcUpdateWork)graph;

                SetCustDmdPrcUpdateWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustDmdPrcUpdateWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustDmdPrcUpdateWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustDmdPrcUpdateWork temp in lst)
                {
                    SetCustDmdPrcUpdateWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustDmdPrcUpdateWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 29;

        /// <summary>
        ///  CustDmdPrcUpdateWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdateWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustDmdPrcUpdateWork(System.IO.BinaryWriter writer, CustDmdPrcUpdateWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //得意先コード1
            writer.Write(temp.CustomerCode1);
            //得意先1締日
            writer.Write(temp.Customer1TotalDay);
            //得意先コード2
            writer.Write(temp.CustomerCode2);
            //得意先2締日
            writer.Write(temp.Customer2TotalDay);
            //得意先コード3
            writer.Write(temp.CustomerCode3);
            //得意先3締日
            writer.Write(temp.Customer3TotalDay);
            //得意先コード4
            writer.Write(temp.CustomerCode4);
            //得意先4締日
            writer.Write(temp.Customer4TotalDay);
            //得意先コード5
            writer.Write(temp.CustomerCode5);
            //得意先5締日
            writer.Write(temp.Customer5TotalDay);
            //得意先コード6
            writer.Write(temp.CustomerCode6);
            //得意先6締日
            writer.Write(temp.Customer6TotalDay);
            //得意先コード7
            writer.Write(temp.CustomerCode7);
            //得意先7締日
            writer.Write(temp.Customer7TotalDay);
            //得意先コード8
            writer.Write(temp.CustomerCode8);
            //得意先8締日
            writer.Write(temp.Customer8TotalDay);
            //得意先コード9
            writer.Write(temp.CustomerCode9);
            //得意先9締日
            writer.Write(temp.Customer9TotalDay);
            //得意先コード10
            writer.Write(temp.CustomerCode10);
            //得意先10締日
            writer.Write(temp.Customer10TotalDay);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //更新対象フラグ
            writer.Write(temp.UpdObjectFlag);
            //処理内容フラグ
            writer.Write(temp.ProcCntntsFlag);
            //対象締日
            writer.Write(temp.ObjTotalDay);
            //期末更新区分
            writer.Write(temp.TermLastDiv);
            //得意先締日
            writer.Write(temp.CustomerTotalDay);

        }

        /// <summary>
        ///  CustDmdPrcUpdateWorkインスタンス取得
        /// </summary>
        /// <returns>CustDmdPrcUpdateWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdateWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustDmdPrcUpdateWork GetCustDmdPrcUpdateWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustDmdPrcUpdateWork temp = new CustDmdPrcUpdateWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //得意先コード1
            temp.CustomerCode1 = reader.ReadInt32();
            //得意先1締日
            temp.Customer1TotalDay = reader.ReadInt32();
            //得意先コード2
            temp.CustomerCode2 = reader.ReadInt32();
            //得意先2締日
            temp.Customer2TotalDay = reader.ReadInt32();
            //得意先コード3
            temp.CustomerCode3 = reader.ReadInt32();
            //得意先3締日
            temp.Customer3TotalDay = reader.ReadInt32();
            //得意先コード4
            temp.CustomerCode4 = reader.ReadInt32();
            //得意先4締日
            temp.Customer4TotalDay = reader.ReadInt32();
            //得意先コード5
            temp.CustomerCode5 = reader.ReadInt32();
            //得意先5締日
            temp.Customer5TotalDay = reader.ReadInt32();
            //得意先コード6
            temp.CustomerCode6 = reader.ReadInt32();
            //得意先6締日
            temp.Customer6TotalDay = reader.ReadInt32();
            //得意先コード7
            temp.CustomerCode7 = reader.ReadInt32();
            //得意先7締日
            temp.Customer7TotalDay = reader.ReadInt32();
            //得意先コード8
            temp.CustomerCode8 = reader.ReadInt32();
            //得意先8締日
            temp.Customer8TotalDay = reader.ReadInt32();
            //得意先コード9
            temp.CustomerCode9 = reader.ReadInt32();
            //得意先9締日
            temp.Customer9TotalDay = reader.ReadInt32();
            //得意先コード10
            temp.CustomerCode10 = reader.ReadInt32();
            //得意先10締日
            temp.Customer10TotalDay = reader.ReadInt32();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //更新対象フラグ
            temp.UpdObjectFlag = reader.ReadInt32();
            //処理内容フラグ
            temp.ProcCntntsFlag = reader.ReadInt32();
            //対象締日
            temp.ObjTotalDay = reader.ReadInt32();
            //期末更新区分
            temp.TermLastDiv = reader.ReadInt32();
            //得意先締日
            temp.CustomerTotalDay = reader.ReadInt32();


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
        /// <returns>CustDmdPrcUpdateWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdateWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustDmdPrcUpdateWork temp = GetCustDmdPrcUpdateWork(reader, serInfo);
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
                    retValue = (CustDmdPrcUpdateWork[])lst.ToArray(typeof(CustDmdPrcUpdateWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
