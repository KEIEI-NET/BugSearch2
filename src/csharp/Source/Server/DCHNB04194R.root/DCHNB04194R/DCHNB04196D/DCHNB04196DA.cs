using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesAnnualDataSelectParamWork
    /// <summary>
    ///                      売上年間実績照会抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上年間実績照会抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesAnnualDataSelectParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>拠点コードが未設定時は「全社」</remarks>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>従業員コード</summary>
        /// <remarks>担当者/受注者/発行者コード</remarks>
        private string _employeeCode = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>集計区分</summary>
        /// <remarks>0:拠点,1:得意先,2:担当者,3:地区,4:業種</remarks>
        private Int32 _totalDiv;

        /// <summary>開始年月</summary>
        /// <remarks>YYYYMM （ex. 前期の開始年月）</remarks>
        private Int32 _yearMonthSt;

        /// <summary>終了年月</summary>
        /// <remarks>YYYYMM （ex. 当期の当月年月）</remarks>
        private Int32 _yearMonthEd;

        /// <summary>抽出区分</summary>
        /// <remarks>0:年度実績,1:残高(入金),2:残高(売上当月・当期)</remarks>
        private Int32 _searchDiv;

        /// <summary>従業員区分</summary>
        /// <remarks>10:販売担当者 20:受付担当者 30:入力担当者</remarks>
        private Int32 _employeeDivCd;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>開始集計年月日(得意先)</summary>
        /// <remarks>得意先前回締日(開始)</remarks>
        private Int32 _stAddUpDate;

        /// <summary>終了集計年月日(得意先)</summary>
        /// <remarks>得意先前回締日(終了)</remarks>
        private Int32 _edAddUpDate;

        /// <summary>集計得意先締日(年月日)</summary>
        /// <remarks>得意先今回締日(終了)</remarks>
        private Int32 _custTotalDay;

        /// <summary>開始集計年月日(拠点)</summary>
        /// <remarks>拠点前回締日(開始)</remarks>
        private Int32 _stSecAddUpDate;

        /// <summary>終了集計年月日(拠点)</summary>
        /// <remarks>拠点前回締日(終了)</remarks>
        private Int32 _edSecAddUpDate;

        /// <summary>集計拠点締日(年月日)</summary>
        /// <remarks>拠点今回締日(終了)</remarks>
        private Int32 _secTotalDay;

        /// <summary>請求拠点コード</summary>
        /// <remarks>得意先請求拠点</remarks>
        private string _claimSectionCode = "";

        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// <summary>拠点名称</summary>
        private string _sectionName = string.Empty;

        /// <summary>selectionCode</summary>
        private string _selectionCode = string.Empty;

        /// <summary>selectionName</summary>
        private string _selectionName = string.Empty;
        // --- ADD 2010/08/02 --------------------------------<<<<<

        // ---------------------- ADD 2010/08/26 -------------->>>>>
        /// <summary>開始selectionName</summary>
        private string _st_selectionCode;

        /// <summary>終了selectionName</summary>
        private string _ed_selectionCode;

        /// <summary>検索区分</summary>
        private Int32 _searDiv;

        /// <summary>拠点コードリスト</summary>
        private List<string[]> _sectionCodeList = new List<string[]>();
        // ---------------------- ADD 2010/08/26 ---------------<<<<<


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
        /// <value>拠点コードが未設定時は「全社」</value>
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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>担当者/受注者/発行者コード</value>
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

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  TotalDiv
        /// <summary>集計区分プロパティ</summary>
        /// <value>0:拠点,1:得意先,2:担当者,3:地区,4:業種</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDiv
        {
            get { return _totalDiv; }
            set { _totalDiv = value; }
        }

        /// public propaty name  :  YearMonthSt
        /// <summary>開始年月プロパティ</summary>
        /// <value>YYYYMM （ex. 前期の開始年月）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 YearMonthSt
        {
            get { return _yearMonthSt; }
            set { _yearMonthSt = value; }
        }

        /// public propaty name  :  YearMonthEd
        /// <summary>終了年月プロパティ</summary>
        /// <value>YYYYMM （ex. 当期の当月年月）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 YearMonthEd
        {
            get { return _yearMonthEd; }
            set { _yearMonthEd = value; }
        }

        /// public propaty name  :  SearchDiv
        /// <summary>抽出区分プロパティ</summary>
        /// <value>0:年度実績,1:残高(入金),2:残高(売上当月・当期)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }

        /// public propaty name  :  EmployeeDivCd
        /// <summary>従業員区分プロパティ</summary>
        /// <value>10:販売担当者 20:受付担当者 30:入力担当者</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployeeDivCd
        {
            get { return _employeeDivCd; }
            set { _employeeDivCd = value; }
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

        /// public propaty name  :  StAddUpDate
        /// <summary>開始集計年月日(得意先)プロパティ</summary>
        /// <value>得意先前回締日(開始)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始集計年月日(得意先)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StAddUpDate
        {
            get { return _stAddUpDate; }
            set { _stAddUpDate = value; }
        }

        /// public propaty name  :  EdAddUpDate
        /// <summary>終了集計年月日(得意先)プロパティ</summary>
        /// <value>得意先前回締日(終了)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了集計年月日(得意先)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdAddUpDate
        {
            get { return _edAddUpDate; }
            set { _edAddUpDate = value; }
        }

        /// public propaty name  :  CustTotalDay
        /// <summary>集計得意先締日(年月日)プロパティ</summary>
        /// <value>得意先今回締日(終了)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計得意先締日(年月日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustTotalDay
        {
            get { return _custTotalDay; }
            set { _custTotalDay = value; }
        }

        /// public propaty name  :  StSecAddUpDate
        /// <summary>開始集計年月日(拠点)プロパティ</summary>
        /// <value>拠点前回締日(開始)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始集計年月日(拠点)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StSecAddUpDate
        {
            get { return _stSecAddUpDate; }
            set { _stSecAddUpDate = value; }
        }

        /// public propaty name  :  EdSecAddUpDate
        /// <summary>終了集計年月日(拠点)プロパティ</summary>
        /// <value>拠点前回締日(終了)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了集計年月日(拠点)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdSecAddUpDate
        {
            get { return _edSecAddUpDate; }
            set { _edSecAddUpDate = value; }
        }

        /// public propaty name  :  SecTotalDay
        /// <summary>集計拠点締日(年月日)プロパティ</summary>
        /// <value>拠点今回締日(終了)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計拠点締日(年月日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecTotalDay
        {
            get { return _secTotalDay; }
            set { _secTotalDay = value; }
        }

        /// public propaty name  :  ClaimSectionCode
        /// <summary>請求拠点コードプロパティ</summary>
        /// <value>得意先請求拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// public propaty name  :  _sectionName
        /// <summary>拠点コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  SelectionCode
        /// <summary>SelectionCodeプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SelectionCodeプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelectionCode
        {
            get { return _selectionCode; }
            set { _selectionCode = value; }
        }

        /// public propaty name  :  SelectionName
        /// <summary>SelectionNameプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SelectionNameプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelectionName
        {
            get { return _selectionName; }
            set { _selectionName = value; }
        }
        // --- ADD 2010/08/02 --------------------------------<<<<<

        // ---------------------- ADD 2010/08/26 --------------->>>>>
        /// public propaty name  :  St_SelectionCode
        /// <summary>開始SelectionCodeプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始SelectionCodeプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_SelectionCode
        {
            get { return _st_selectionCode; }
            set { _st_selectionCode = value; }
        }

        /// public propaty name  :  Ed_SelectionCode
        /// <summary>終了SelectionCodeプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了SelectionCodeプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_SelectionCode
        {
            get { return _ed_selectionCode; }
            set { _ed_selectionCode = value; }
        }

        /// public propaty name  :  SearchDiv
        /// <summary>検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearDiv
        {
            get { return _searDiv; }
            set { _searDiv = value; }
        }

        /// public propaty name  :  SectionCodeList
        /// <summary>拠点コードListプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードListプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string[]> SectionCodeList
        {
            get { return this._sectionCodeList; }
            set { this._sectionCodeList = value; }
        }
        // ---------------------- ADD 2010/08/26 ---------------<<<<<


        /// <summary>
        /// 売上年間実績照会抽出条件クラスワークワークコンストラクタ
        /// </summary>
        /// <returns>SalesAnnualDataSelectParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesAnnualDataSelectParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesAnnualDataSelectParamWork()
        {
        }

    }
}
