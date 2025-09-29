using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesReportOrderCndtn
    /// <summary>
    ///                      売上速報表示抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上速報表示抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalesReportOrderCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>売上日付（開始）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_SalesDate;

        /// <summary>売上日付（終了）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_SalesDate;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";


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

        /// public propaty name  :  St_SalesDate
        /// <summary>売上日付（開始）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>売上日付（終了）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }


        /// <summary>
        /// 売上速報表示抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>SalesReportOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesReportOrderCndtn()
        {
        }

        /// <summary>
        /// 売上速報表示抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="st_SalesDate">売上日付（開始）(YYYYMMDD)</param>
        /// <param name="ed_SalesDate">売上日付（終了）(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>SalesReportOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesReportOrderCndtn(string enterpriseCode, string sectionCode, Int32 st_SalesDate, Int32 ed_SalesDate, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._st_SalesDate = st_SalesDate;
            this._ed_SalesDate = ed_SalesDate;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 売上速報表示抽出条件クラス複製処理
        /// </summary>
        /// <returns>SalesReportOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesReportOrderCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesReportOrderCndtn Clone()
        {
            return new SalesReportOrderCndtn(this._enterpriseCode, this._sectionCode, this._st_SalesDate, this._ed_SalesDate, this._enterpriseName);
        }

        /// <summary>
        /// 売上速報表示抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesReportOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SalesReportOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.St_SalesDate == target.St_SalesDate)
                 && (this.Ed_SalesDate == target.Ed_SalesDate)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 売上速報表示抽出条件クラス比較処理
        /// </summary>
        /// <param name="salesReportOrderCndtn1">
        ///                    比較するSalesReportOrderCndtnクラスのインスタンス
        /// </param>
        /// <param name="salesReportOrderCndtn2">比較するSalesReportOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SalesReportOrderCndtn salesReportOrderCndtn1, SalesReportOrderCndtn salesReportOrderCndtn2)
        {
            return ((salesReportOrderCndtn1.EnterpriseCode == salesReportOrderCndtn2.EnterpriseCode)
                 && (salesReportOrderCndtn1.SectionCode == salesReportOrderCndtn2.SectionCode)
                 && (salesReportOrderCndtn1.St_SalesDate == salesReportOrderCndtn2.St_SalesDate)
                 && (salesReportOrderCndtn1.Ed_SalesDate == salesReportOrderCndtn2.Ed_SalesDate)
                 && (salesReportOrderCndtn1.EnterpriseName == salesReportOrderCndtn2.EnterpriseName));
        }
        /// <summary>
        /// 売上速報表示抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesReportOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportOrderCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SalesReportOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.St_SalesDate != target.St_SalesDate) resList.Add("St_SalesDate");
            if (this.Ed_SalesDate != target.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 売上速報表示抽出条件クラス比較処理
        /// </summary>
        /// <param name="salesReportOrderCndtn1">比較するSalesReportOrderCndtnクラスのインスタンス</param>
        /// <param name="salesReportOrderCndtn2">比較するSalesReportOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportOrderCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SalesReportOrderCndtn salesReportOrderCndtn1, SalesReportOrderCndtn salesReportOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (salesReportOrderCndtn1.EnterpriseCode != salesReportOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesReportOrderCndtn1.SectionCode != salesReportOrderCndtn2.SectionCode) resList.Add("SectionCode");
            if (salesReportOrderCndtn1.St_SalesDate != salesReportOrderCndtn2.St_SalesDate) resList.Add("St_SalesDate");
            if (salesReportOrderCndtn1.Ed_SalesDate != salesReportOrderCndtn2.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (salesReportOrderCndtn1.EnterpriseName != salesReportOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
