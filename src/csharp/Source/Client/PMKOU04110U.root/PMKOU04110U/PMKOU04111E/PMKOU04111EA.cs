using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SuppYearResultCndtn
    /// <summary>
    ///                      仕入年間実績照会抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入年間実績照会抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SuppYearResultCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>拠点コードが未設定時は「全社」</remarks>
        private string _sectionCode = "";

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>拠点コードスタート</summary>
        private string _sectionCodeSt = "";

        /// <summary>拠点コード終了</summary>
        private string _sectionCodeEnd = "";
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>仕入先コードスタート</summary>
        private Int32 _supplierCdSt;

        /// <summary>仕入先コード終了</summary>
        private Int32 _supplierCdEnd;

        /// <summary>画面区分</summary>
        private string _mainDiv;
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>精算先区分</summary>
        /// <remarks>0:親、1:子　　子の場合には買掛残高照会タブ用の項目は返さない</remarks>
        private Int32 _accDiv;

        /// <summary>仕入先締日(年月日)</summary>
        /// <remarks>YYYYMMDD 仕入先の最終締年月日</remarks>
        private DateTime _suppTotalDay;

        /// <summary>期首年月日</summary>
        /// <remarks>YYYYMMDD 買掛残高照会タブの当期項目用</remarks>
        private DateTime _companyBiginDate;

        /// <summary>当期開始年月度</summary>
        /// <remarks>YYYYMM 実績照会タブで使用</remarks>
        private DateTime _this_YearMonth;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM 現在処理中年月を設定</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>自社締日(年月日)</summary>
        /// <remarks>YYYYMMDD 自社の最終締年月日</remarks>
        private DateTime _secTotalDay;

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

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// public propaty name  :  SectionCodeSt
        /// <summary>拠点コードスタートプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードスタートプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEnd
        /// <summary>拠点コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEnd
        {
            get { return _sectionCodeEnd; }
            set { _sectionCodeEnd = value; }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

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

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// public propaty name  :  SupplierCdSt
        /// <summary>仕入先コードスタートプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードスタートプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEnd
        /// <summary>仕入先コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEnd
        {
            get { return _supplierCdEnd; }
            set { _supplierCdEnd = value; }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// public propaty name  :  AccDiv
        /// <summary>精算先区分プロパティ</summary>
        /// <value>0:親、1:子　　子の場合には買掛残高照会タブ用の項目は返さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   精算先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccDiv
        {
            get { return _accDiv; }
            set { _accDiv = value; }
        }

        /// public propaty name  :  SuppTotalDay
        /// <summary>仕入先締日(年月日)プロパティ</summary>
        /// <value>YYYYMMDD 仕入先の最終締年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日(年月日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SuppTotalDay
        {
            get { return _suppTotalDay; }
            set { _suppTotalDay = value; }
        }

        /// public propaty name  :  CompanyBiginDate
        /// <summary>期首年月日プロパティ</summary>
        /// <value>YYYYMMDD 買掛残高照会タブの当期項目用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期首年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CompanyBiginDate
        {
            get { return _companyBiginDate; }
            set { _companyBiginDate = value; }
        }

        /// public propaty name  :  CompanyBiginDateJpFormal
        /// <summary>期首年月日 和暦プロパティ</summary>
        /// <value>YYYYMMDD 買掛残高照会タブの当期項目用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期首年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyBiginDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _companyBiginDate); }
            set { }
        }

        /// public propaty name  :  CompanyBiginDateJpInFormal
        /// <summary>期首年月日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD 買掛残高照会タブの当期項目用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期首年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyBiginDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _companyBiginDate); }
            set { }
        }

        /// public propaty name  :  CompanyBiginDateAdFormal
        /// <summary>期首年月日 西暦プロパティ</summary>
        /// <value>YYYYMMDD 買掛残高照会タブの当期項目用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期首年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyBiginDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _companyBiginDate); }
            set { }
        }

        /// public propaty name  :  CompanyBiginDateAdInFormal
        /// <summary>期首年月日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD 買掛残高照会タブの当期項目用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期首年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyBiginDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _companyBiginDate); }
            set { }
        }

        /// public propaty name  :  This_YearMonth
        /// <summary>当期開始年月度プロパティ</summary>
        /// <value>YYYYMM 実績照会タブで使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期開始年月度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime This_YearMonth
        {
            get { return _this_YearMonth; }
            set { _this_YearMonth = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM 現在処理中年月を設定</value>
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

        /// public propaty name  :  AddUpYearMonthJpFormal
        /// <summary>計上年月 和暦プロパティ</summary>
        /// <value>YYYYMM 現在処理中年月を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpYearMonthJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonthJpInFormal
        /// <summary>計上年月 和暦(略)プロパティ</summary>
        /// <value>YYYYMM 現在処理中年月を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpYearMonthJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonthAdFormal
        /// <summary>計上年月 西暦プロパティ</summary>
        /// <value>YYYYMM 現在処理中年月を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpYearMonthAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonthAdInFormal
        /// <summary>計上年月 西暦(略)プロパティ</summary>
        /// <value>YYYYMM 現在処理中年月を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpYearMonthAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  SecTotalDay
        /// <summary>自社締日(年月日)プロパティ</summary>
        /// <value>YYYYMMDD 自社の最終締年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社締日(年月日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SecTotalDay
        {
            get { return _secTotalDay; }
            set { _secTotalDay = value; }
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

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// public propaty name  :  MainDiv
        /// <summary>画面区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画面区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainDiv
        {
            get { return _mainDiv; }
            set { _mainDiv = value; }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>
        /// 仕入年間実績照会抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>SuppYearResultCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppYearResultCndtn()
        {
        }

        /// <summary>
        /// 仕入年間実績照会抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード(拠点コードが未設定時は「全社」)</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="accDiv">精算先区分(0:親、1:子　　子の場合には買掛残高照会タブ用の項目は返さない)</param>
        /// <param name="suppTotalDay">仕入先締日(年月日)(YYYYMMDD 仕入先の最終締年月日)</param>
        /// <param name="companyBiginDate">期首年月日(YYYYMMDD 買掛残高照会タブの当期項目用)</param>
        /// <param name="this_YearMonth">当期開始年月度(YYYYMM 実績照会タブで使用)</param>
        /// <param name="addUpYearMonth">計上年月(YYYYMM 現在処理中年月を設定)</param>
        /// <param name="secTotalDay">自社締日(年月日)(YYYYMMDD 自社の最終締年月日)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>SuppYearResultCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppYearResultCndtn(string enterpriseCode, string sectionCode, Int32 supplierCd, Int32 accDiv, DateTime suppTotalDay, DateTime companyBiginDate, DateTime this_YearMonth, DateTime addUpYearMonth, DateTime secTotalDay, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._supplierCd = supplierCd;
            this._accDiv = accDiv;
            this._suppTotalDay = suppTotalDay;
            this.CompanyBiginDate = companyBiginDate;
            this._this_YearMonth = this_YearMonth;
            this.AddUpYearMonth = addUpYearMonth;
            this._secTotalDay = secTotalDay;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 仕入年間実績照会抽出条件クラスワーク複製処理
        /// </summary>
        /// <returns>SuppYearResultCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSuppYearResultCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppYearResultCndtn Clone()
        {
            return new SuppYearResultCndtn(this._enterpriseCode, this._sectionCode, this._supplierCd, this._accDiv, this._suppTotalDay, this._companyBiginDate, this._this_YearMonth, this._addUpYearMonth, this._secTotalDay, this._enterpriseName);
        }

        /// <summary>
        /// 仕入年間実績照会抽出条件クラスワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のSuppYearResultCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SuppYearResultCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.AccDiv == target.AccDiv)
                 && (this.SuppTotalDay == target.SuppTotalDay)
                 && (this.CompanyBiginDate == target.CompanyBiginDate)
                 && (this.This_YearMonth == target.This_YearMonth)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.SecTotalDay == target.SecTotalDay)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 仕入年間実績照会抽出条件クラスワーク比較処理
        /// </summary>
        /// <param name="suppYearResultCndtn1">
        ///                    比較するSuppYearResultCndtnクラスのインスタンス
        /// </param>
        /// <param name="suppYearResultCndtn2">比較するSuppYearResultCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SuppYearResultCndtn suppYearResultCndtn1, SuppYearResultCndtn suppYearResultCndtn2)
        {
            return ((suppYearResultCndtn1.EnterpriseCode == suppYearResultCndtn2.EnterpriseCode)
                 && (suppYearResultCndtn1.SectionCode == suppYearResultCndtn2.SectionCode)
                 && (suppYearResultCndtn1.SupplierCd == suppYearResultCndtn2.SupplierCd)
                 && (suppYearResultCndtn1.AccDiv == suppYearResultCndtn2.AccDiv)
                 && (suppYearResultCndtn1.SuppTotalDay == suppYearResultCndtn2.SuppTotalDay)
                 && (suppYearResultCndtn1.CompanyBiginDate == suppYearResultCndtn2.CompanyBiginDate)
                 && (suppYearResultCndtn1.This_YearMonth == suppYearResultCndtn2.This_YearMonth)
                 && (suppYearResultCndtn1.AddUpYearMonth == suppYearResultCndtn2.AddUpYearMonth)
                 && (suppYearResultCndtn1.SecTotalDay == suppYearResultCndtn2.SecTotalDay)
                 && (suppYearResultCndtn1.EnterpriseName == suppYearResultCndtn2.EnterpriseName));
        }
        /// <summary>
        /// 仕入年間実績照会抽出条件クラスワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のSuppYearResultCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SuppYearResultCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.AccDiv != target.AccDiv) resList.Add("AccDiv");
            if (this.SuppTotalDay != target.SuppTotalDay) resList.Add("SuppTotalDay");
            if (this.CompanyBiginDate != target.CompanyBiginDate) resList.Add("CompanyBiginDate");
            if (this.This_YearMonth != target.This_YearMonth) resList.Add("This_YearMonth");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.SecTotalDay != target.SecTotalDay) resList.Add("SecTotalDay");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 仕入年間実績照会抽出条件クラスワーク比較処理
        /// </summary>
        /// <param name="suppYearResultCndtn1">比較するSuppYearResultCndtnクラスのインスタンス</param>
        /// <param name="suppYearResultCndtn2">比較するSuppYearResultCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SuppYearResultCndtn suppYearResultCndtn1, SuppYearResultCndtn suppYearResultCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (suppYearResultCndtn1.EnterpriseCode != suppYearResultCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (suppYearResultCndtn1.SectionCode != suppYearResultCndtn2.SectionCode) resList.Add("SectionCode");
            if (suppYearResultCndtn1.SupplierCd != suppYearResultCndtn2.SupplierCd) resList.Add("SupplierCd");
            if (suppYearResultCndtn1.AccDiv != suppYearResultCndtn2.AccDiv) resList.Add("AccDiv");
            if (suppYearResultCndtn1.SuppTotalDay != suppYearResultCndtn2.SuppTotalDay) resList.Add("SuppTotalDay");
            if (suppYearResultCndtn1.CompanyBiginDate != suppYearResultCndtn2.CompanyBiginDate) resList.Add("CompanyBiginDate");
            if (suppYearResultCndtn1.This_YearMonth != suppYearResultCndtn2.This_YearMonth) resList.Add("This_YearMonth");
            if (suppYearResultCndtn1.AddUpYearMonth != suppYearResultCndtn2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (suppYearResultCndtn1.SecTotalDay != suppYearResultCndtn2.SecTotalDay) resList.Add("SecTotalDay");
            if (suppYearResultCndtn1.EnterpriseName != suppYearResultCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
