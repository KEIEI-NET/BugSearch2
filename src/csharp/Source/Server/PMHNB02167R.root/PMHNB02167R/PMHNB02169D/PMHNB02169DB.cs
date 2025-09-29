using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesHistAnalyzeResultWork
    /// <summary>
    ///                      売上内容分析表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上内容分析表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesHistAnalyzeResultWork 
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
        /// <remarks>計上担当者（担当者）</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaName = "";

        /// <summary>売上金額(日計取寄)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _salesMoneyOrder;

        /// <summary>売上金額(日計在庫)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _salesMoneyStock;

        /// <summary>売上金額(日計純正)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _salesMoneyGenuine;

        /// <summary>売上金額(日計優良)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _salesMoneyPrm;

        /// <summary>売上金額(日計外装)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _salesMoneyOutside;

        /// <summary>売上金額(日計その他)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _salesMoneyOther;

        /// <summary>粗利金額(日計取寄)</summary>
        private Int64 _grossProfitOrder;

        /// <summary>粗利金額(日計在庫)</summary>
        private Int64 _grossProfitStock;

        /// <summary>粗利金額(日計純正)</summary>
        private Int64 _grossProfitGenuine;

        /// <summary>粗利金額(日計優良)</summary>
        private Int64 _grossProfitPrm;

        /// <summary>粗利金額(日計外装)</summary>
        private Int64 _grossProfitOutside;

        /// <summary>粗利金額(日計その他)</summary>
        private Int64 _grossProfitOther;

        /// <summary>売上金額(累計取寄)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _monthSalesMoneyOrder;

        /// <summary>売上金額(累計在庫)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _monthSalesMoneyStock;

        /// <summary>売上金額(累計純正)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _monthSalesMoneyGenuine;

        /// <summary>売上金額(累計優良)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _monthSalesMoneyPrm;

        /// <summary>売上金額(累計外装)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _monthSalesMoneyOutside;

        /// <summary>売上金額(累計その他)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _monthSalesMoneyOther;

        /// <summary>粗利金額(累計取寄)</summary>
        private Int64 _monthGrossProfitOrder;

        /// <summary>粗利金額(累計在庫)</summary>
        private Int64 _monthGrossProfitStock;

        /// <summary>粗利金額(累計純正)</summary>
        private Int64 _monthGrossProfitGenuine;

        /// <summary>粗利金額(累計優良)</summary>
        private Int64 _monthGrossProfitPrm;

        /// <summary>粗利金額(累計外装)</summary>
        private Int64 _monthGrossProfitOutside;

        /// <summary>粗利金額(累計その他)</summary>
        private Int64 _monthGrossProfitOther;


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
        /// <value>計上担当者（担当者）</value>
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

        /// public propaty name  :  SalesMoneyOrder
        /// <summary>売上金額(日計取寄)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(日計取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyOrder
        {
            get { return _salesMoneyOrder; }
            set { _salesMoneyOrder = value; }
        }

        /// public propaty name  :  SalesMoneyStock
        /// <summary>売上金額(日計在庫)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(日計在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyStock
        {
            get { return _salesMoneyStock; }
            set { _salesMoneyStock = value; }
        }

        /// public propaty name  :  SalesMoneyGenuine
        /// <summary>売上金額(日計純正)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(日計純正)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyGenuine
        {
            get { return _salesMoneyGenuine; }
            set { _salesMoneyGenuine = value; }
        }

        /// public propaty name  :  SalesMoneyPrm
        /// <summary>売上金額(日計優良)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(日計優良)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyPrm
        {
            get { return _salesMoneyPrm; }
            set { _salesMoneyPrm = value; }
        }

        /// public propaty name  :  SalesMoneyOutside
        /// <summary>売上金額(日計外装)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(日計外装)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyOutside
        {
            get { return _salesMoneyOutside; }
            set { _salesMoneyOutside = value; }
        }

        /// public propaty name  :  SalesMoneyOther
        /// <summary>売上金額(日計その他)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(日計その他)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyOther
        {
            get { return _salesMoneyOther; }
            set { _salesMoneyOther = value; }
        }

        /// public propaty name  :  GrossProfitOrder
        /// <summary>粗利金額(日計取寄)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(日計取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfitOrder
        {
            get { return _grossProfitOrder; }
            set { _grossProfitOrder = value; }
        }

        /// public propaty name  :  GrossProfitStock
        /// <summary>粗利金額(日計在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(日計在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfitStock
        {
            get { return _grossProfitStock; }
            set { _grossProfitStock = value; }
        }

        /// public propaty name  :  GrossProfitGenuine
        /// <summary>粗利金額(日計純正)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(日計純正)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfitGenuine
        {
            get { return _grossProfitGenuine; }
            set { _grossProfitGenuine = value; }
        }

        /// public propaty name  :  GrossProfitPrm
        /// <summary>粗利金額(日計優良)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(日計優良)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfitPrm
        {
            get { return _grossProfitPrm; }
            set { _grossProfitPrm = value; }
        }

        /// public propaty name  :  GrossProfitOutside
        /// <summary>粗利金額(日計外装)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(日計外装)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfitOutside
        {
            get { return _grossProfitOutside; }
            set { _grossProfitOutside = value; }
        }

        /// public propaty name  :  GrossProfitOther
        /// <summary>粗利金額(日計その他)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(日計その他)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfitOther
        {
            get { return _grossProfitOther; }
            set { _grossProfitOther = value; }
        }

        /// public propaty name  :  MonthSalesMoneyOrder
        /// <summary>売上金額(累計取寄)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(累計取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesMoneyOrder
        {
            get { return _monthSalesMoneyOrder; }
            set { _monthSalesMoneyOrder = value; }
        }

        /// public propaty name  :  MonthSalesMoneyStock
        /// <summary>売上金額(累計在庫)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(累計在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesMoneyStock
        {
            get { return _monthSalesMoneyStock; }
            set { _monthSalesMoneyStock = value; }
        }

        /// public propaty name  :  MonthSalesMoneyGenuine
        /// <summary>売上金額(累計純正)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(累計純正)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesMoneyGenuine
        {
            get { return _monthSalesMoneyGenuine; }
            set { _monthSalesMoneyGenuine = value; }
        }

        /// public propaty name  :  MonthSalesMoneyPrm
        /// <summary>売上金額(累計優良)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(累計優良)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesMoneyPrm
        {
            get { return _monthSalesMoneyPrm; }
            set { _monthSalesMoneyPrm = value; }
        }

        /// public propaty name  :  MonthSalesMoneyOutside
        /// <summary>売上金額(累計外装)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(累計外装)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesMoneyOutside
        {
            get { return _monthSalesMoneyOutside; }
            set { _monthSalesMoneyOutside = value; }
        }

        /// public propaty name  :  MonthSalesMoneyOther
        /// <summary>売上金額(累計その他)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(累計その他)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesMoneyOther
        {
            get { return _monthSalesMoneyOther; }
            set { _monthSalesMoneyOther = value; }
        }

        /// public propaty name  :  MonthGrossProfitOrder
        /// <summary>粗利金額(累計取寄)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(累計取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthGrossProfitOrder
        {
            get { return _monthGrossProfitOrder; }
            set { _monthGrossProfitOrder = value; }
        }

        /// public propaty name  :  MonthGrossProfitStock
        /// <summary>粗利金額(累計在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(累計在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthGrossProfitStock
        {
            get { return _monthGrossProfitStock; }
            set { _monthGrossProfitStock = value; }
        }

        /// public propaty name  :  MonthGrossProfitGenuine
        /// <summary>粗利金額(累計純正)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(累計純正)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthGrossProfitGenuine
        {
            get { return _monthGrossProfitGenuine; }
            set { _monthGrossProfitGenuine = value; }
        }

        /// public propaty name  :  MonthGrossProfitPrm
        /// <summary>粗利金額(累計優良)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(累計優良)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthGrossProfitPrm
        {
            get { return _monthGrossProfitPrm; }
            set { _monthGrossProfitPrm = value; }
        }

        /// public propaty name  :  MonthGrossProfitOutside
        /// <summary>粗利金額(累計外装)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(累計外装)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthGrossProfitOutside
        {
            get { return _monthGrossProfitOutside; }
            set { _monthGrossProfitOutside = value; }
        }

        /// public propaty name  :  MonthGrossProfitOther
        /// <summary>粗利金額(累計その他)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額(累計その他)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthGrossProfitOther
        {
            get { return _monthGrossProfitOther; }
            set { _monthGrossProfitOther = value; }
        }


        /// <summary>
        /// 売上内容分析表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesHistAnalyzeResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistAnalyzeResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesHistAnalyzeResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesHistAnalyzeResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesHistAnalyzeResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesHistAnalyzeResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistAnalyzeResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesHistAnalyzeResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesHistAnalyzeResultWork || graph is ArrayList || graph is SalesHistAnalyzeResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesHistAnalyzeResultWork).FullName));

            if (graph != null && graph is SalesHistAnalyzeResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesHistAnalyzeResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesHistAnalyzeResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesHistAnalyzeResultWork[])graph).Length;
            }
            else if (graph is SalesHistAnalyzeResultWork)
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
            //売上金額(日計取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyOrder
            //売上金額(日計在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyStock
            //売上金額(日計純正)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyGenuine
            //売上金額(日計優良)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyPrm
            //売上金額(日計外装)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyOutside
            //売上金額(日計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyOther
            //粗利金額(日計取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitOrder
            //粗利金額(日計在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitStock
            //粗利金額(日計純正)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitGenuine
            //粗利金額(日計優良)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitPrm
            //粗利金額(日計外装)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitOutside
            //粗利金額(日計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitOther
            //売上金額(累計取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyOrder
            //売上金額(累計在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyStock
            //売上金額(累計純正)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyGenuine
            //売上金額(累計優良)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyPrm
            //売上金額(累計外装)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyOutside
            //売上金額(累計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyOther
            //粗利金額(累計取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitOrder
            //粗利金額(累計在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitStock
            //粗利金額(累計純正)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitGenuine
            //粗利金額(累計優良)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitPrm
            //粗利金額(累計外装)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitOutside
            //粗利金額(累計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitOther


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesHistAnalyzeResultWork)
            {
                SalesHistAnalyzeResultWork temp = (SalesHistAnalyzeResultWork)graph;

                SetSalesHistAnalyzeResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesHistAnalyzeResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesHistAnalyzeResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesHistAnalyzeResultWork temp in lst)
                {
                    SetSalesHistAnalyzeResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesHistAnalyzeResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 33;

        /// <summary>
        ///  SalesHistAnalyzeResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistAnalyzeResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesHistAnalyzeResultWork(System.IO.BinaryWriter writer, SalesHistAnalyzeResultWork temp)
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
            //売上金額(日計取寄)
            writer.Write(temp.SalesMoneyOrder);
            //売上金額(日計在庫)
            writer.Write(temp.SalesMoneyStock);
            //売上金額(日計純正)
            writer.Write(temp.SalesMoneyGenuine);
            //売上金額(日計優良)
            writer.Write(temp.SalesMoneyPrm);
            //売上金額(日計外装)
            writer.Write(temp.SalesMoneyOutside);
            //売上金額(日計その他)
            writer.Write(temp.SalesMoneyOther);
            //粗利金額(日計取寄)
            writer.Write(temp.GrossProfitOrder);
            //粗利金額(日計在庫)
            writer.Write(temp.GrossProfitStock);
            //粗利金額(日計純正)
            writer.Write(temp.GrossProfitGenuine);
            //粗利金額(日計優良)
            writer.Write(temp.GrossProfitPrm);
            //粗利金額(日計外装)
            writer.Write(temp.GrossProfitOutside);
            //粗利金額(日計その他)
            writer.Write(temp.GrossProfitOther);
            //売上金額(累計取寄)
            writer.Write(temp.MonthSalesMoneyOrder);
            //売上金額(累計在庫)
            writer.Write(temp.MonthSalesMoneyStock);
            //売上金額(累計純正)
            writer.Write(temp.MonthSalesMoneyGenuine);
            //売上金額(累計優良)
            writer.Write(temp.MonthSalesMoneyPrm);
            //売上金額(累計外装)
            writer.Write(temp.MonthSalesMoneyOutside);
            //売上金額(累計その他)
            writer.Write(temp.MonthSalesMoneyOther);
            //粗利金額(累計取寄)
            writer.Write(temp.MonthGrossProfitOrder);
            //粗利金額(累計在庫)
            writer.Write(temp.MonthGrossProfitStock);
            //粗利金額(累計純正)
            writer.Write(temp.MonthGrossProfitGenuine);
            //粗利金額(累計優良)
            writer.Write(temp.MonthGrossProfitPrm);
            //粗利金額(累計外装)
            writer.Write(temp.MonthGrossProfitOutside);
            //粗利金額(累計その他)
            writer.Write(temp.MonthGrossProfitOther);

        }

        /// <summary>
        ///  SalesHistAnalyzeResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalesHistAnalyzeResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistAnalyzeResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalesHistAnalyzeResultWork GetSalesHistAnalyzeResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesHistAnalyzeResultWork temp = new SalesHistAnalyzeResultWork();

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
            //売上金額(日計取寄)
            temp.SalesMoneyOrder = reader.ReadInt64();
            //売上金額(日計在庫)
            temp.SalesMoneyStock = reader.ReadInt64();
            //売上金額(日計純正)
            temp.SalesMoneyGenuine = reader.ReadInt64();
            //売上金額(日計優良)
            temp.SalesMoneyPrm = reader.ReadInt64();
            //売上金額(日計外装)
            temp.SalesMoneyOutside = reader.ReadInt64();
            //売上金額(日計その他)
            temp.SalesMoneyOther = reader.ReadInt64();
            //粗利金額(日計取寄)
            temp.GrossProfitOrder = reader.ReadInt64();
            //粗利金額(日計在庫)
            temp.GrossProfitStock = reader.ReadInt64();
            //粗利金額(日計純正)
            temp.GrossProfitGenuine = reader.ReadInt64();
            //粗利金額(日計優良)
            temp.GrossProfitPrm = reader.ReadInt64();
            //粗利金額(日計外装)
            temp.GrossProfitOutside = reader.ReadInt64();
            //粗利金額(日計その他)
            temp.GrossProfitOther = reader.ReadInt64();
            //売上金額(累計取寄)
            temp.MonthSalesMoneyOrder = reader.ReadInt64();
            //売上金額(累計在庫)
            temp.MonthSalesMoneyStock = reader.ReadInt64();
            //売上金額(累計純正)
            temp.MonthSalesMoneyGenuine = reader.ReadInt64();
            //売上金額(累計優良)
            temp.MonthSalesMoneyPrm = reader.ReadInt64();
            //売上金額(累計外装)
            temp.MonthSalesMoneyOutside = reader.ReadInt64();
            //売上金額(累計その他)
            temp.MonthSalesMoneyOther = reader.ReadInt64();
            //粗利金額(累計取寄)
            temp.MonthGrossProfitOrder = reader.ReadInt64();
            //粗利金額(累計在庫)
            temp.MonthGrossProfitStock = reader.ReadInt64();
            //粗利金額(累計純正)
            temp.MonthGrossProfitGenuine = reader.ReadInt64();
            //粗利金額(累計優良)
            temp.MonthGrossProfitPrm = reader.ReadInt64();
            //粗利金額(累計外装)
            temp.MonthGrossProfitOutside = reader.ReadInt64();
            //粗利金額(累計その他)
            temp.MonthGrossProfitOther = reader.ReadInt64();


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
        /// <returns>SalesHistAnalyzeResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistAnalyzeResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesHistAnalyzeResultWork temp = GetSalesHistAnalyzeResultWork(reader, serInfo);
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
                    retValue = (SalesHistAnalyzeResultWork[])lst.ToArray(typeof(SalesHistAnalyzeResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
