using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecPrintSet
    /// <summary>
    ///                      従業員マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   従業員マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class EmployeeSet 
    {
        /// <summary>従業員コード</summary>
		private string _employeeCode = "";

		/// <summary>名称</summary>
		private string _name = "";

		/// <summary>カナ</summary>
		private string _kana = "";

		/// <summary>短縮名称</summary>
		private string _shortName = "";

		/// <summary>性別名称</summary>
		/// <remarks>全角で管理</remarks>
		private string _sexName = "";

		/// <summary>生年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _birthday;

		/// <summary>電話番号（会社）</summary>
		private string _companyTelNo = "";

		/// <summary>電話番号（携帯）</summary>
		private string _portableTelNo = "";

		/// <summary>職種</summary>
		/// <remarks>80:店長 70:店頭販売員(正社員) 60:店頭販売員(アルバイト) 40:バックヤード担当者 20:事務</remarks>
		private Int32 _authorityLevel1;

		/// <summary>職種名称</summary>
		private string _authorityLevelNm1 = "";

		/// <summary>雇用形態</summary>
		/// <remarks>50:正社員 10:アルバイト</remarks>
		private Int32 _authorityLevel2;

		/// <summary>雇用形態名称</summary>
		private string _authorityLevelNm2 = "";

		/// <summary>所属拠点コード</summary>
		private string _belongSectionCode = "";

		/// <summary>拠点ガイド名称</summary>
		private string _sectionGuideNm = "";

		/// <summary>所属部門コード</summary>
		private Int32 _belongSubSectionCode;

		/// <summary>部門名称</summary>
		private string _subSectionName = "";

		/// <summary>入社日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _enterCompanyDate;

		/// <summary>退職日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _retirementDate;

		/// <summary>従業員分析コード１</summary>
		private Int32 _employAnalysCode1;

		/// <summary>従業員分析コード２</summary>
		private Int32 _employAnalysCode2;

		/// <summary>従業員分析コード３</summary>
		private Int32 _employAnalysCode3;

		/// <summary>従業員分析コード４</summary>
		private Int32 _employAnalysCode4;

		/// <summary>従業員分析コード５</summary>
		private Int32 _employAnalysCode5;

		/// <summary>従業員分析コード６</summary>
		private Int32 _employAnalysCode6;


        /// public propaty name  :  EmployeeCode
		/// <summary>従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeCode
		{
			get{return _employeeCode;}
			set{_employeeCode = value;}
		}

		/// public propaty name  :  Name
		/// <summary>名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
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
			get{return _kana;}
			set{_kana = value;}
		}

		/// public propaty name  :  ShortName
		/// <summary>短縮名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   短縮名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShortName
		{
			get{return _shortName;}
			set{_shortName = value;}
		}

		/// public propaty name  :  SexName
		/// <summary>性別名称プロパティ</summary>
		/// <value>全角で管理</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   性別名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SexName
		{
			get{return _sexName;}
			set{_sexName = value;}
		}

		/// public propaty name  :  Birthday
		/// <summary>生年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Birthday
		{
			get{return _birthday;}
			set{_birthday = value;}
		}

		/// public propaty name  :  CompanyTelNo
		/// <summary>電話番号（会社）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（会社）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyTelNo
		{
			get{return _companyTelNo;}
			set{_companyTelNo = value;}
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>電話番号（携帯）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（携帯）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PortableTelNo
		{
			get{return _portableTelNo;}
			set{_portableTelNo = value;}
		}

		/// public propaty name  :  AuthorityLevel1
		/// <summary>職種プロパティ</summary>
		/// <value>80:店長 70:店頭販売員(正社員) 60:店頭販売員(アルバイト) 40:バックヤード担当者 20:事務</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   職種プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AuthorityLevel1
		{
			get{return _authorityLevel1;}
			set{_authorityLevel1 = value;}
		}

		/// public propaty name  :  AuthorityLevelNm1
		/// <summary>職種名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   職種名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AuthorityLevelNm1
		{
			get{return _authorityLevelNm1;}
			set{_authorityLevelNm1 = value;}
		}

		/// public propaty name  :  AuthorityLevel2
		/// <summary>雇用形態プロパティ</summary>
		/// <value>50:正社員 10:アルバイト</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   雇用形態プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AuthorityLevel2
		{
			get{return _authorityLevel2;}
			set{_authorityLevel2 = value;}
		}

		/// public propaty name  :  AuthorityLevelNm2
		/// <summary>雇用形態名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   雇用形態名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AuthorityLevelNm2
		{
			get{return _authorityLevelNm2;}
			set{_authorityLevelNm2 = value;}
		}

		/// public propaty name  :  BelongSectionCode
		/// <summary>所属拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   所属拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BelongSectionCode
		{
			get{return _belongSectionCode;}
			set{_belongSectionCode = value;}
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
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  BelongSubSectionCode
		/// <summary>所属部門コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   所属部門コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BelongSubSectionCode
		{
			get{return _belongSubSectionCode;}
			set{_belongSubSectionCode = value;}
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
			get{return _subSectionName;}
			set{_subSectionName = value;}
		}

		/// public propaty name  :  EnterCompanyDate
		/// <summary>入社日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入社日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime EnterCompanyDate
		{
			get{return _enterCompanyDate;}
			set{_enterCompanyDate = value;}
		}

		/// public propaty name  :  RetirementDate
		/// <summary>退職日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   退職日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime RetirementDate
		{
			get{return _retirementDate;}
			set{_retirementDate = value;}
		}

		/// public propaty name  :  EmployAnalysCode1
		/// <summary>従業員分析コード１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員分析コード１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployAnalysCode1
		{
			get{return _employAnalysCode1;}
			set{_employAnalysCode1 = value;}
		}

		/// public propaty name  :  EmployAnalysCode2
		/// <summary>従業員分析コード２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員分析コード２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployAnalysCode2
		{
			get{return _employAnalysCode2;}
			set{_employAnalysCode2 = value;}
		}

		/// public propaty name  :  EmployAnalysCode3
		/// <summary>従業員分析コード３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員分析コード３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployAnalysCode3
		{
			get{return _employAnalysCode3;}
			set{_employAnalysCode3 = value;}
		}

		/// public propaty name  :  EmployAnalysCode4
		/// <summary>従業員分析コード４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員分析コード４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployAnalysCode4
		{
			get{return _employAnalysCode4;}
			set{_employAnalysCode4 = value;}
		}

		/// public propaty name  :  EmployAnalysCode5
		/// <summary>従業員分析コード５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員分析コード５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployAnalysCode5
		{
			get{return _employAnalysCode5;}
			set{_employAnalysCode5 = value;}
		}

		/// public propaty name  :  EmployAnalysCode6
		/// <summary>従業員分析コード６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員分析コード６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployAnalysCode6
		{
			get{return _employAnalysCode6;}
			set{_employAnalysCode6 = value;}
		}

        /// <summary>
        /// 従業員（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeSet Clone()
        {
            return new EmployeeSet(this._employeeCode, this._name, this._kana, this._shortName, this._sexName, this._birthday, this._companyTelNo, this._portableTelNo, this._authorityLevel1, this._authorityLevelNm1, this._authorityLevel2, this._authorityLevelNm2, this._belongSectionCode, this._sectionGuideNm, this._belongSubSectionCode, this._subSectionName, this._enterCompanyDate, this._retirementDate, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6);

        }

        /// <summary>
		/// 従業員（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>EmployeeSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public EmployeeSet()
		{
		}

        /// <summary>
        /// 従業員（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="EmployeeCode"></param>
        /// <param name="Name"></param>
        /// <param name="Kana"></param>
        /// <param name="ShortName"></param>
        /// <param name="SexName"></param>
        /// <param name="Birthday"></param>
        /// <param name="CompanyTelNo"></param>
        /// <param name="PortableTelNo"></param>
        /// <param name="AuthorityLevel1"></param>
        /// <param name="AuthorityLevelNm1"></param>
        /// <param name="AuthorityLevel2"></param>
        /// <param name="AuthorityLevelNm2"></param>
        /// <param name="BelongSectionCode"></param>
        /// <param name="SectionGuideNm"></param>
        /// <param name="BelongSubSectionCode"></param>
        /// <param name="SubSectionName"></param>
        /// <param name="EnterCompanyDate"></param>
        /// <param name="RetirementDate"></param>
        /// <param name="EmployAnalysCode1"></param>
        /// <param name="EmployAnalysCode2"></param>
        /// <param name="EmployAnalysCode3"></param>
        /// <param name="EmployAnalysCode4"></param>
        /// <param name="EmployAnalysCode5"></param>
        /// <param name="EmployAnalysCode6"></param>
        public EmployeeSet(string EmployeeCode, string Name, string Kana, string ShortName, string SexName, DateTime Birthday, string CompanyTelNo, string PortableTelNo, Int32 AuthorityLevel1, string AuthorityLevelNm1, Int32 AuthorityLevel2, string AuthorityLevelNm2, string BelongSectionCode, string SectionGuideNm, Int32 BelongSubSectionCode, string SubSectionName, DateTime EnterCompanyDate, DateTime RetirementDate, Int32 EmployAnalysCode1, Int32 EmployAnalysCode2, Int32 EmployAnalysCode3, Int32 EmployAnalysCode4, Int32 EmployAnalysCode5, Int32 EmployAnalysCode6)
        {
            this._employeeCode = EmployeeCode;
            this._name = Name;
            this._kana = Kana;
            this._shortName = ShortName;
            this._sexName = SexName;
            this._birthday = Birthday;
            this._companyTelNo = CompanyTelNo;
            this._portableTelNo = PortableTelNo;
            this._authorityLevel1 = AuthorityLevel1;
            this._authorityLevelNm1 = AuthorityLevelNm1;
            this._authorityLevel2 = AuthorityLevel2;
            this._authorityLevelNm2 = AuthorityLevelNm2;
            this._belongSectionCode = BelongSectionCode;
            this._sectionGuideNm = SectionGuideNm;
            this._belongSubSectionCode = BelongSubSectionCode;
            this._subSectionName = SubSectionName;
            this._enterCompanyDate = EnterCompanyDate;
            this._retirementDate = RetirementDate;
            this._employAnalysCode1 = EmployAnalysCode1;
            this._employAnalysCode2 = EmployAnalysCode2;
            this._employAnalysCode3 = EmployAnalysCode3;
            this._employAnalysCode4 = EmployAnalysCode4;
            this._employAnalysCode5 = EmployAnalysCode5;
            this._employAnalysCode6 = EmployAnalysCode6;

        }
    }
}
