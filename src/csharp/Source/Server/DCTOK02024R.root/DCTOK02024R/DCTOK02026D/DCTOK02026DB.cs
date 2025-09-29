using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesDayMonthReportResultWork
    /// <summary>
    ///                      売上日報月報抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上日報月報抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      : 2012/05/22 李亜博</br>
    /// <br>管理番号         : 10801804-00 06/27配信分</br>
    /// <br>                   Redmine#29898   売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesDayMonthReportResultWork
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

        // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
        /// <summary>管理拠点コード</summary>
        private string _sectionMngCode = "";
        // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<

        /// <summary>得意先名称</summary>
        /// <remarks>得意先略称</remarks>
        private string _customerSnm = "";

        /// <summary>期間伝票枚数</summary>
        private Int32 _termSalesSlipCount;

        /// <summary>期間売上合計</summary>
        /// <remarks>伝票区分=0:売上 の売上伝票合計（税抜き）</remarks>
        private Int64 _termSalesTotalTaxExc;

        /// <summary>期間返品合計</summary>
        /// <remarks>伝票区分=1:返品 の売上伝票合計（税抜き）</remarks>
        private Int64 _termSalesBackTotalTaxExc;

        /// <summary>期間値引合計</summary>
        /// <remarks>売上値引金額計（税抜き）※伝票区分関係なし</remarks>
        private Int64 _termSalesDisTtlTaxExc;

        /// <summary>期間原価金額計</summary>
        private Int64 _termTotalCost;

        /// <summary>期間売上目標</summary>
        private Int64 _termSalesTargetMoney;

        /// <summary>期間粗利目標</summary>
        private Int64 _termSalesTargetProfit;

        /// <summary>当月伝票枚数</summary>
        private Int32 _monthSalesSlipCount;

        /// <summary>当月売上合計</summary>
        /// <remarks>伝票区分=0:売上 の売上伝票合計（税抜き）</remarks>
        private Int64 _monthSalesTotalTaxExc;

        /// <summary>当月返品合計</summary>
        /// <remarks>伝票区分=1:返品 の売上伝票合計（税抜き）</remarks>
        private Int64 _monthSalesBackTotalTaxExc;

        /// <summary>当月値引合計</summary>
        /// <remarks>売上値引金額計（税抜き）※伝票区分関係なし</remarks>
        private Int64 _monthSalesDisTtlTaxExc;

        /// <summary>当月原価金額計</summary>
        private Int64 _monthTotalCost;

        /// <summary>当月売上目標</summary>
        private Int64 _monthSalesTargetMoney;

        /// <summary>当月粗利目標</summary>
        private Int64 _monthSalesTargetProfit;


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

        // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
        /// public propaty name  :  SectionMngCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   李亜博</br>
        /// </remarks>
        public string SectionMngCode
        {
            get { return _sectionMngCode; }
            set { _sectionMngCode = value; }
        }
        // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<

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

        /// public propaty name  :  TermSalesSlipCount
        /// <summary>期間伝票枚数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TermSalesSlipCount
        {
            get { return _termSalesSlipCount; }
            set { _termSalesSlipCount = value; }
        }

        /// public propaty name  :  TermSalesTotalTaxExc
        /// <summary>期間売上合計プロパティ</summary>
        /// <value>伝票区分=0:売上 の売上伝票合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間売上合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTotalTaxExc
        {
            get { return _termSalesTotalTaxExc; }
            set { _termSalesTotalTaxExc = value; }
        }

        /// public propaty name  :  TermSalesBackTotalTaxExc
        /// <summary>期間返品合計プロパティ</summary>
        /// <value>伝票区分=1:返品 の売上伝票合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間返品合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesBackTotalTaxExc
        {
            get { return _termSalesBackTotalTaxExc; }
            set { _termSalesBackTotalTaxExc = value; }
        }

        /// public propaty name  :  TermSalesDisTtlTaxExc
        /// <summary>期間値引合計プロパティ</summary>
        /// <value>売上値引金額計（税抜き）※伝票区分関係なし</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間値引合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesDisTtlTaxExc
        {
            get { return _termSalesDisTtlTaxExc; }
            set { _termSalesDisTtlTaxExc = value; }
        }

        /// public propaty name  :  TermTotalCost
        /// <summary>期間原価金額計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間原価金額計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermTotalCost
        {
            get { return _termTotalCost; }
            set { _termTotalCost = value; }
        }

        /// public propaty name  :  TermSalesTargetMoney
        /// <summary>期間売上目標プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間売上目標プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTargetMoney
        {
            get { return _termSalesTargetMoney; }
            set { _termSalesTargetMoney = value; }
        }

        /// public propaty name  :  TermSalesTargetProfit
        /// <summary>期間粗利目標プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間粗利目標プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit
        {
            get { return _termSalesTargetProfit; }
            set { _termSalesTargetProfit = value; }
        }

        /// public propaty name  :  MonthSalesSlipCount
        /// <summary>当月伝票枚数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MonthSalesSlipCount
        {
            get { return _monthSalesSlipCount; }
            set { _monthSalesSlipCount = value; }
        }

        /// public propaty name  :  MonthSalesTotalTaxExc
        /// <summary>当月売上合計プロパティ</summary>
        /// <value>伝票区分=0:売上 の売上伝票合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月売上合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesTotalTaxExc
        {
            get { return _monthSalesTotalTaxExc; }
            set { _monthSalesTotalTaxExc = value; }
        }

        /// public propaty name  :  MonthSalesBackTotalTaxExc
        /// <summary>当月返品合計プロパティ</summary>
        /// <value>伝票区分=1:返品 の売上伝票合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月返品合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesBackTotalTaxExc
        {
            get { return _monthSalesBackTotalTaxExc; }
            set { _monthSalesBackTotalTaxExc = value; }
        }

        /// public propaty name  :  MonthSalesDisTtlTaxExc
        /// <summary>当月値引合計プロパティ</summary>
        /// <value>売上値引金額計（税抜き）※伝票区分関係なし</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月値引合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesDisTtlTaxExc
        {
            get { return _monthSalesDisTtlTaxExc; }
            set { _monthSalesDisTtlTaxExc = value; }
        }

        /// public propaty name  :  MonthTotalCost
        /// <summary>当月原価金額計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月原価金額計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthTotalCost
        {
            get { return _monthTotalCost; }
            set { _monthTotalCost = value; }
        }

        /// public propaty name  :  MonthSalesTargetMoney
        /// <summary>当月売上目標プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月売上目標プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesTargetMoney
        {
            get { return _monthSalesTargetMoney; }
            set { _monthSalesTargetMoney = value; }
        }

        /// public propaty name  :  MonthSalesTargetProfit
        /// <summary>当月粗利目標プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月粗利目標プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesTargetProfit
        {
            get { return _monthSalesTargetProfit; }
            set { _monthSalesTargetProfit = value; }
        }


        /// <summary>
        /// 売上日報月報抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesDayMonthReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDayMonthReportResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesDayMonthReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesDayMonthReportResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesDayMonthReportResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>管理番号         : 10801804-00 06/27配信分</br>
    /// <br>                   Redmine#29898   売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
    /// </remarks>
    public class SalesDayMonthReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDayMonthReportResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      : 2012/05/22 李亜博</br>
        /// <br>管理番号         : 10801804-00 06/27配信分</br>
        /// <br>                   Redmine#29898   売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesDayMonthReportResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesDayMonthReportResultWork || graph is ArrayList || graph is SalesDayMonthReportResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesDayMonthReportResultWork).FullName));

            if (graph != null && graph is SalesDayMonthReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesDayMonthReportResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesDayMonthReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesDayMonthReportResultWork[])graph).Length;
            }
            else if (graph is SalesDayMonthReportResultWork)
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
            // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
            //管理拠点コード
            serInfo.MemberInfo.Add(typeof(string));//SectionMngCode
            // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //期間伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //TermSalesSlipCount
            //期間売上合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTotalTaxExc
            //期間返品合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesBackTotalTaxExc
            //期間値引合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesDisTtlTaxExc
            //期間原価金額計
            serInfo.MemberInfo.Add(typeof(Int64)); //TermTotalCost
            //期間売上目標
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetMoney
            //期間粗利目標
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit
            //当月伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthSalesSlipCount
            //当月売上合計
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTotalTaxExc
            //当月返品合計
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesBackTotalTaxExc
            //当月値引合計
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesDisTtlTaxExc
            //当月原価金額計
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthTotalCost
            //当月売上目標
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTargetMoney
            //当月粗利目標
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTargetProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesDayMonthReportResultWork)
            {
                SalesDayMonthReportResultWork temp = (SalesDayMonthReportResultWork)graph;

                SetSalesDayMonthReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesDayMonthReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesDayMonthReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesDayMonthReportResultWork temp in lst)
                {
                    SetSalesDayMonthReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesDayMonthReportResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        // private const int currentMemberCount = 20;//DEL 2012/05/22 李亜博 Redmine#29898
           private const int currentMemberCount = 21;//ADD 2012/05/22 李亜博 Redmine#29898
        /// <summary>
        ///  SalesDayMonthReportResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDayMonthReportResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>管理番号         : 10801804-00 06/27配信分</br>
        /// <br>                   Redmine#29898   売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
        /// </remarks>
        private void SetSalesDayMonthReportResultWork(System.IO.BinaryWriter writer, SalesDayMonthReportResultWork temp)
        {
            //コード
            writer.Write(temp.Code);
            //名称
            writer.Write(temp.Name);
            //拠点コード
            writer.Write(temp.SectionCode);
            // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
            //管理拠点コード
            writer.Write(temp.SectionMngCode);
            // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<
            //拠点名称
            writer.Write(temp.CompanyName1);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerSnm);
            //期間伝票枚数
            writer.Write(temp.TermSalesSlipCount);
            //期間売上合計
            writer.Write(temp.TermSalesTotalTaxExc);
            //期間返品合計
            writer.Write(temp.TermSalesBackTotalTaxExc);
            //期間値引合計
            writer.Write(temp.TermSalesDisTtlTaxExc);
            //期間原価金額計
            writer.Write(temp.TermTotalCost);
            //期間売上目標
            writer.Write(temp.TermSalesTargetMoney);
            //期間粗利目標
            writer.Write(temp.TermSalesTargetProfit);
            //当月伝票枚数
            writer.Write(temp.MonthSalesSlipCount);
            //当月売上合計
            writer.Write(temp.MonthSalesTotalTaxExc);
            //当月返品合計
            writer.Write(temp.MonthSalesBackTotalTaxExc);
            //当月値引合計
            writer.Write(temp.MonthSalesDisTtlTaxExc);
            //当月原価金額計
            writer.Write(temp.MonthTotalCost);
            //当月売上目標
            writer.Write(temp.MonthSalesTargetMoney);
            //当月粗利目標
            writer.Write(temp.MonthSalesTargetProfit);

        }

        /// <summary>
        ///  SalesDayMonthReportResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalesDayMonthReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDayMonthReportResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>管理番号         : 10801804-00 06/27配信分</br>
        /// <br>                   Redmine#29898   売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
        /// </remarks>
        private SalesDayMonthReportResultWork GetSalesDayMonthReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesDayMonthReportResultWork temp = new SalesDayMonthReportResultWork();

            //コード
            temp.Code = reader.ReadString();
            //名称
            temp.Name = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
            //管理拠点コード
            temp.SectionMngCode = reader.ReadString();
            // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<
            //拠点名称
            temp.CompanyName1 = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerSnm = reader.ReadString();
            //期間伝票枚数
            temp.TermSalesSlipCount = reader.ReadInt32();
            //期間売上合計
            temp.TermSalesTotalTaxExc = reader.ReadInt64();
            //期間返品合計
            temp.TermSalesBackTotalTaxExc = reader.ReadInt64();
            //期間値引合計
            temp.TermSalesDisTtlTaxExc = reader.ReadInt64();
            //期間原価金額計
            temp.TermTotalCost = reader.ReadInt64();
            //期間売上目標
            temp.TermSalesTargetMoney = reader.ReadInt64();
            //期間粗利目標
            temp.TermSalesTargetProfit = reader.ReadInt64();
            //当月伝票枚数
            temp.MonthSalesSlipCount = reader.ReadInt32();
            //当月売上合計
            temp.MonthSalesTotalTaxExc = reader.ReadInt64();
            //当月返品合計
            temp.MonthSalesBackTotalTaxExc = reader.ReadInt64();
            //当月値引合計
            temp.MonthSalesDisTtlTaxExc = reader.ReadInt64();
            //当月原価金額計
            temp.MonthTotalCost = reader.ReadInt64();
            //当月売上目標
            temp.MonthSalesTargetMoney = reader.ReadInt64();
            //当月粗利目標
            temp.MonthSalesTargetProfit = reader.ReadInt64();


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
        /// <returns>SalesDayMonthReportResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDayMonthReportResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesDayMonthReportResultWork temp = GetSalesDayMonthReportResultWork(reader, serInfo);
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
                    retValue = (SalesDayMonthReportResultWork[])lst.ToArray(typeof(SalesDayMonthReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
