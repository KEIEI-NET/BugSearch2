using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustomerSearchParaWork
    /// <summary>
    ///                      得意先検索条件パラメータクラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先検索条件パラメータクラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/01/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   MANTIS:14720 得意先名検索追加</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2009/12/02</br>
    /// <br>Update Note      :   電話番号検索追加と伴う修正</br>
    /// <br>Programmer       :   PM1012A 朱 猛</br>
    /// <br>Date             :   2010/08/06</br>
     /// <br>Update Note     :   得意先略称表示列と検索追加(#826)</br>
    /// <br>Programmer       :   PM1107C 徐錦山</br>
    /// <br>Date             :   2011/07/22</br>
    /// <br>Update Note      : PCC自社用得意先ガイド追加</br>
    /// <br>Programmer       : 黄海霞</br>
    /// <br>Date             : 2011/08/19</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustomerSearchParaWork 
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先サブコード</summary>
        private string _customerSubCode = "";

        /// <summary>カナ</summary>
        private string _kana = "";

        /// <summary>電話番号（検索用下4桁）</summary>
        private string _searchTelNo = "";

        /// <summary>業販先区分</summary>
        /// <remarks>0:業販先以外,1:業販先</remarks>
        private Int32 _acceptWholeSale;

        /// <summary>得意先サブコード検索タイプ</summary>
        /// <remarks>0:前方一致検索,1:曖昧検索</remarks>
        private Int32 _customerSubCodeSearchType;

        /// <summary>得意先カナ検索タイプ</summary>
        /// <remarks>0:前方一致検索,1:曖昧検索</remarks>
        private Int32 _kanaSearchType;

        /// <summary>得意先分析コード１</summary>
        private Int32 _custAnalysCode1;

        /// <summary>得意先分析コード２</summary>
        private Int32 _custAnalysCode2;

        /// <summary>得意先分析コード３</summary>
        private Int32 _custAnalysCode3;

        /// <summary>得意先分析コード４</summary>
        private Int32 _custAnalysCode4;

        /// <summary>得意先分析コード５</summary>
        private Int32 _custAnalysCode5;

        /// <summary>得意先分析コード６</summary>
        private Int32 _custAnalysCode6;

        /// <summary>顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentCd = "";

        /// <summary>集金担当従業員コード</summary>
        private string _billCollecterCd = "";

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";

        // 2009/12/02 Add >>>
        /// <summary>得意先名</summary>
        private string _name = "";

        /// <summary>得意先名検索タイプ</summary>
        /// <remarks>0:前方一致検索,1:曖昧検索</remarks>
        private Int32 _nameSearchType;
        // 2009/12/02 Add <<<

        // ---ADD 2010/08/06-------------------->>>
        /// <summary>電話番号</summary>
        private string _telNum = "";

        /// <summary>電話番号検索タイプ</summary>
        /// <remarks>0:前方一致検索,1:曖昧検索</remarks>
        private Int32 _telNumSearchType;
        // ---ADD 2010/08/06--------------------<<<
        
        // 2011/7/22 XUJS ADD STA>>>>>>
        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>得意先略称検索タイプ</summary>
        /// <remarks>0:前方一致検索,1:曖昧検索</remarks>
        private Int32 _customerSnmSearchType;
        // 2011/7/22 XUJS ADD END<<<<<<

        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
        private Int32 _pccuoeMode;
        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<

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

        /// public propaty name  :  CustomerSubCode
        /// <summary>得意先サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSubCode
        {
            get { return _customerSubCode; }
            set { _customerSubCode = value; }
        }

        /// public propaty name  :  Kana
        /// <summary>カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  SearchTelNo
        /// <summary>電話番号（検索用下4桁）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（検索用下4桁）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTelNo
        {
            get { return _searchTelNo; }
            set { _searchTelNo = value; }
        }

        /// public propaty name  :  AcceptWholeSale
        /// <summary>業販先区分プロパティ</summary>
        /// <value>0:業販先以外,1:業販先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業販先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptWholeSale
        {
            get { return _acceptWholeSale; }
            set { _acceptWholeSale = value; }
        }

        /// public propaty name  :  CustomerSubCodeSearchType
        /// <summary>得意先サブコード検索タイププロパティ</summary>
        /// <value>0:前方一致検索,1:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先サブコード検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerSubCodeSearchType
        {
            get { return _customerSubCodeSearchType; }
            set { _customerSubCodeSearchType = value; }
        }

        /// public propaty name  :  KanaSearchType
        /// <summary>得意先カナ検索タイププロパティ</summary>
        /// <value>0:前方一致検索,1:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先カナ検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 KanaSearchType
        {
            get { return _kanaSearchType; }
            set { _kanaSearchType = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>得意先分析コード１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>得意先分析コード２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>得意先分析コード３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>得意先分析コード４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>得意先分析コード５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>得意先分析コード６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>集金担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        // 2009/12/02 Add >>>
        /// public propaty name  :  Name
        /// <summary>得意先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  KanaSearchType
        /// <summary>得意先名検索タイププロパティ</summary>
        /// <value>0:前方一致検索,1:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NameSearchType
        {
            get { return _nameSearchType; }
            set { _nameSearchType = value; }
        }
        // 2009/12/02 Add <<<

        // ---ADD 2010/08/06-------------------->>>
        /// public propaty name  :  TelNum
        /// <summary>電話番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TelNum
        {
            get { return _telNum; }
            set { _telNum = value; }
        }

        /// public propaty name  :  TelNumSearchType
        /// <summary>電話番号検索タイププロパティ</summary>
        /// <value>0:前方一致検索,1:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TelNumSearchType
        {
            get { return _telNumSearchType; }
            set { _telNumSearchType = value; }
        }
        // ---ADD 2010/08/06--------------------<<<
        //1/7/22 XUJS ADD STA>>>>>>
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

        /// public propaty name  :  CustomerSnmSearchType
        /// <summary>得意先略称検索タイププロパティ</summary>
        /// <value>0:前方一致検索,1:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerSnmSearchType
        {
            get { return _customerSnmSearchType; }
            set { _customerSnmSearchType = value; }
        }
        // 2011/7/22 XUJS ADD END<<<<<<

        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
        /// public propaty name  :  PccuoeMode
        /// <summary>PCC自社用タイプロパティ</summary>
        /// <value>0:通常,1:PCC自社用,2:PCCマスメン用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PccuoeMode
        {
            get { return _pccuoeMode; }
            set { _pccuoeMode = value; }
        }
        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<

        /// <summary>
        /// 得意先検索条件パラメータクラスワークコンストラクタ
        /// </summary>
        /// <returns>CustomerSearchParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerSearchParaWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustomerSearchParaWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustomerSearchParaWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustomerSearchParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchParaWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   得意先略称表示列と検索追加(#826)</br>
        /// <br>Programmer       :   PM1107C 徐錦山</br>
        /// <br>Date             :   2011/07/22</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustomerSearchParaWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustomerSearchParaWork || graph is ArrayList || graph is CustomerSearchParaWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustomerSearchParaWork).FullName));

            if (graph != null && graph is CustomerSearchParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustomerSearchParaWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustomerSearchParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustomerSearchParaWork[])graph).Length;
            }
            else if (graph is CustomerSearchParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先サブコード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSubCode
            //カナ
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //電話番号（検索用下4桁）
            serInfo.MemberInfo.Add(typeof(string)); //SearchTelNo
            //業販先区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptWholeSale
            //得意先サブコード検索タイプ
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerSubCodeSearchType
            //得意先カナ検索タイプ
            serInfo.MemberInfo.Add(typeof(Int32)); //KanaSearchType
            //得意先分析コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode1
            //得意先分析コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode2
            //得意先分析コード３
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode3
            //得意先分析コード４
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode4
            //得意先分析コード５
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode5
            //得意先分析コード６
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode6
            //顧客担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
            //集金担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //管理拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            // 2009/12/02 Add >>>
            //得意先名
            serInfo.MemberInfo.Add(typeof(string)); //Name
            // 2009/12/02 Add <<<

            // ---ADD 2010/08/06-------------------->>>
            //電話番号
            serInfo.MemberInfo.Add(typeof(string)); //TelNum
            // ---ADD 2010/08/06--------------------<<<
            
            // 2011/7/22 XUJS ADD STA>>>>>>
            serInfo.MemberInfo.Add(typeof(string)); //SNM
            // 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
            //PCC自社用タイプ
            serInfo.MemberInfo.Add(typeof(Int32)); //PccuoeMode
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CustomerSearchParaWork)
            {
                CustomerSearchParaWork temp = (CustomerSearchParaWork)graph;

                SetCustomerSearchParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustomerSearchParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustomerSearchParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustomerSearchParaWork temp in lst)
                {
                    SetCustomerSearchParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustomerSearchParaWorkメンバ数(publicプロパティ数)
        /// </summary>
        // 2009/12/02 >>>
        //private const int currentMemberCount = 17;
        // ---UPD 2010/08/06-------------------->>>
        //private const int currentMemberCount = 18;
        // 2011/7/22 XUJS EDIT STA>>>>>>
        //private const int currentMemberCount = 19;
       // private const int currentMemberCount = 20;
        // 2011/7/22 XUJS EDIT END<<<<<<
        // ---UPD 2010/08/06--------------------<<<
        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
        private const int currentMemberCount = 21;
        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
        // 2009/12/02 <<<

        /// <summary>
        ///  CustomerSearchParaWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchParaWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   得意先略称表示列と検索追加(#826)</br>
        /// <br>Programmer       :   PM1107C 徐錦山</br>
        /// <br>Date             :   2011/07/22</br>
        /// </remarks>
        private void SetCustomerSearchParaWork(System.IO.BinaryWriter writer, CustomerSearchParaWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先サブコード
            writer.Write(temp.CustomerSubCode);
            //カナ
            writer.Write(temp.Kana);
            //電話番号（検索用下4桁）
            writer.Write(temp.SearchTelNo);
            //業販先区分
            writer.Write(temp.AcceptWholeSale);
            //得意先サブコード検索タイプ
            writer.Write(temp.CustomerSubCodeSearchType);
            //得意先カナ検索タイプ
            writer.Write(temp.KanaSearchType);
            //得意先分析コード１
            writer.Write(temp.CustAnalysCode1);
            //得意先分析コード２
            writer.Write(temp.CustAnalysCode2);
            //得意先分析コード３
            writer.Write(temp.CustAnalysCode3);
            //得意先分析コード４
            writer.Write(temp.CustAnalysCode4);
            //得意先分析コード５
            writer.Write(temp.CustAnalysCode5);
            //得意先分析コード６
            writer.Write(temp.CustAnalysCode6);
            //顧客担当従業員コード
            writer.Write(temp.CustomerAgentCd);
            //集金担当従業員コード
            writer.Write(temp.BillCollecterCd);
            //管理拠点コード
            writer.Write(temp.MngSectionCode);
            // 2009/12/02 Add >>>
            //得意先名
            writer.Write(temp.Name);
            // 2009/12/02 Add <<<
            // ---ADD 2010/08/06-------------------->>>
            //電話番号
            writer.Write(temp.TelNum);
            // ---ADD 2010/08/06--------------------<<<
      
            // 2011/7/22 XUJS ADD STA>>>>>>
            //得意先略称
            writer.Write(temp.CustomerSnm);
            // 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
            //PCC自社用タイプ
            writer.Write(temp.PccuoeMode);
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
        }

        /// <summary>
        ///  CustomerSearchParaWorkインスタンス取得
        /// </summary>
        /// <returns>CustomerSearchParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchParaWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   得意先略称表示列と検索追加(#826)</br>
        /// <br>Programmer       :   PM1107C 徐錦山</br>
        /// <br>Date             :   2011/07/22</br>
        /// </remarks>
        private CustomerSearchParaWork GetCustomerSearchParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustomerSearchParaWork temp = new CustomerSearchParaWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先サブコード
            temp.CustomerSubCode = reader.ReadString();
            //カナ
            temp.Kana = reader.ReadString();
            //電話番号（検索用下4桁）
            temp.SearchTelNo = reader.ReadString();
            //業販先区分
            temp.AcceptWholeSale = reader.ReadInt32();
            //得意先サブコード検索タイプ
            temp.CustomerSubCodeSearchType = reader.ReadInt32();
            //得意先カナ検索タイプ
            temp.KanaSearchType = reader.ReadInt32();
            //得意先分析コード１
            temp.CustAnalysCode1 = reader.ReadInt32();
            //得意先分析コード２
            temp.CustAnalysCode2 = reader.ReadInt32();
            //得意先分析コード３
            temp.CustAnalysCode3 = reader.ReadInt32();
            //得意先分析コード４
            temp.CustAnalysCode4 = reader.ReadInt32();
            //得意先分析コード５
            temp.CustAnalysCode5 = reader.ReadInt32();
            //得意先分析コード６
            temp.CustAnalysCode6 = reader.ReadInt32();
            //顧客担当従業員コード
            temp.CustomerAgentCd = reader.ReadString();
            //集金担当従業員コード
            temp.BillCollecterCd = reader.ReadString();
            //管理拠点コード
            temp.MngSectionCode = reader.ReadString();
            // 2009/12/02 Add >>>
            //得意先名
            temp.Name = reader.ReadString();
            // 2009/12/02 Add <<<
            // ---ADD 2010/08/06-------------------->>>
            //電話番号
            temp.TelNum = reader.ReadString();
            // ---ADD 2010/08/06--------------------<<<
            
            // 2011/7/22 XUJS ADD STA>>>>>>
            temp.CustomerSnm = reader.ReadString();
            // 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>> 
            //PCC自社用タイプ
            temp.PccuoeMode = reader.ReadInt32();
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<

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
        /// <returns>CustomerSearchParaWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchParaWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustomerSearchParaWork temp = GetCustomerSearchParaWork(reader, serInfo);
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
                    retValue = (CustomerSearchParaWork[])lst.ToArray(typeof(CustomerSearchParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
