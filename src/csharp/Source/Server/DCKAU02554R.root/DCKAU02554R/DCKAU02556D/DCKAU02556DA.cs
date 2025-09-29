using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_BillBalanceWork
	/// <summary>
	///                      売掛残高一覧表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売掛残高一覧表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/22  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
    /// <br>Programmer       :   3H 劉星光</br>
    /// <br>Date	         :   2020/02/28</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_BillBalanceWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>計上年月日</summary>
		/// <remarks>YYYYMMDD ※処理月を締める日付。</remarks>
		private DateTime _addUpDate;

		/// <summary>対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>出力順</summary>
		/// <remarks>0:得意先順 1:担当者順 2:地区順</remarks>
		private Int32 _sortOrderDiv;

		/// <summary>担当者区分</summary>
		/// <remarks>0:得意先担当 1:集金担当</remarks>
		private Int32 _employeeKindDiv;

		/// <summary>開始担当者コード</summary>
		private string _st_EmployeeCode = "";

		/// <summary>終了担当者コード</summary>
		private string _ed_EmployeeCode = "";

		/// <summary>開始販売エリアコード</summary>
		private Int32 _st_SalesAreaCode;

		/// <summary>終了販売エリアコード</summary>
		private Int32 _ed_SalesAreaCode;

		/// <summary>開始請求先コード</summary>
		private Int32 _st_ClaimCode;

		/// <summary>終了請求先コード</summary>
		private Int32 _ed_ClaimCode;

		/// <summary>出力金額区分</summary>
		/// <remarks>0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:0以外 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ</remarks>
		private Int32 _outMoneyDiv;

		/// <summary>入金内訳区分</summary>
		/// <remarks>0:印字する 1:印字しない</remarks>
		private Int32 _depoDtlDiv;

		// --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
        /// <summary>税別内訳印字区分</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>税率1</summary>
        /// <remarks>税率1</remarks>
        private Double _taxRate1;

        /// <summary>税率2</summary>
        /// <remarks>税率2</remarks>
        private Double _taxRate2;
        // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<

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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>計上年月日プロパティ</summary>
		/// <value>YYYYMMDD ※処理月を締める日付。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  AddUpYearMonth
		/// <summary>対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  SortOrderDiv
		/// <summary>出力順プロパティ</summary>
		/// <value>0:得意先順 1:担当者順 2:地区順</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortOrderDiv
		{
			get{return _sortOrderDiv;}
			set{_sortOrderDiv = value;}
		}

		/// public propaty name  :  EmployeeKindDiv
		/// <summary>担当者区分プロパティ</summary>
		/// <value>0:得意先担当 1:集金担当</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   担当者区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployeeKindDiv
		{
			get{return _employeeKindDiv;}
			set{_employeeKindDiv = value;}
		}

		/// public propaty name  :  St_EmployeeCode
		/// <summary>開始担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_EmployeeCode
		{
			get{return _st_EmployeeCode;}
			set{_st_EmployeeCode = value;}
		}

		/// public propaty name  :  Ed_EmployeeCode
		/// <summary>終了担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_EmployeeCode
		{
			get{return _ed_EmployeeCode;}
			set{_ed_EmployeeCode = value;}
		}

		/// public propaty name  :  St_SalesAreaCode
		/// <summary>開始販売エリアコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_SalesAreaCode
		{
			get{return _st_SalesAreaCode;}
			set{_st_SalesAreaCode = value;}
		}

		/// public propaty name  :  Ed_SalesAreaCode
		/// <summary>終了販売エリアコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_SalesAreaCode
		{
			get{return _ed_SalesAreaCode;}
			set{_ed_SalesAreaCode = value;}
		}

		/// public propaty name  :  St_ClaimCode
		/// <summary>開始請求先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_ClaimCode
		{
			get{return _st_ClaimCode;}
			set{_st_ClaimCode = value;}
		}

		/// public propaty name  :  Ed_ClaimCode
		/// <summary>終了請求先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_ClaimCode
		{
			get{return _ed_ClaimCode;}
			set{_ed_ClaimCode = value;}
		}

		/// public propaty name  :  OutMoneyDiv
		/// <summary>出力金額区分プロパティ</summary>
		/// <value>0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:0以外 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力金額区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OutMoneyDiv
		{
			get{return _outMoneyDiv;}
			set{_outMoneyDiv = value;}
		}

		/// public propaty name  :  DepoDtlDiv
		/// <summary>入金内訳区分プロパティ</summary>
		/// <value>0:印字する 1:印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金内訳区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepoDtlDiv
		{
			get{return _depoDtlDiv;}
			set{_depoDtlDiv = value;}
		}

        // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
        /// public propaty name  :  TaxPrintDiv
        /// <summary>税別内訳印字区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税別内訳印字区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>税率1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率1</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>税率2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<

		/// <summary>
		/// 売掛残高一覧表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_BillBalanceWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_BillBalanceWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_BillBalanceWork()
		{
		}

	}
}
