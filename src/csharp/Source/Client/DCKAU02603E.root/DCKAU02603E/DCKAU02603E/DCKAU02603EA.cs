using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_AccRecBalance
	/// <summary>
	///                      売掛残高元帳抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   売掛残高元帳抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/26  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       : 2008/12/11 30414 忍 幸史 Partsman用に変更</br>
    /// <br>Update Note      :   2014/02/26 田建委</br>
    /// <br>                 :   Redmine#42188 出力金額区分追加</br>
	/// </remarks>
	public class ExtrInfo_AccRecBalance
	{
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_MonthFomat = "YYYY/MM";

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード（複数指定）</summary>
		/// <remarks>（配列）</remarks>
		private string[] _sectionCodes;

		/// <summary>開始計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _st_AddUpYearMonth;

		/// <summary>終了計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _ed_AddUpYearMonth;

		/// <summary>開始請求先コード</summary>
		private Int32 _st_ClaimCode;

		/// <summary>終了請求先コード</summary>
		private Int32 _ed_ClaimCode;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        /// <summary>全社選択フラグ</summary>
        private bool _isSelectAllSection;

        //----- ADD 2014/02/26 田建委 Redmine#42188 ---------->>>>>
        /// <summary>出力金額区分</summary>
        private Int32 _printMoneyDivCd;
        //----- ADD 2014/02/26 田建委 Redmine#42188 ----------<<<<<

        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプション導入区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点オプション導入区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

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
		/// <summary>拠点コード（複数指定）プロパティ</summary>
		/// <value>（配列）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コード（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
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

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全社選択プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get { return _isSelectAllSection; }
            set { _isSelectAllSection = value; }
        }

        //----- ADD 2014/02/26 田建委 Redmine#42188 ---------->>>>>
        /// public propaty name  :  PrintMoneyDivCd
        /// <summary>出力金額区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力金額区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintMoneyDivCd
        {
            get { return _printMoneyDivCd; }
            set { _printMoneyDivCd = value; }
        }
        //----- ADD 2014/02/26 田建委 Redmine#42188 ----------<<<<<

		/// <summary>
		/// 売掛残高元帳抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_AccRecBalanceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_AccRecBalanceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_AccRecBalance()
		{
		}

		/// <summary>
		/// 売掛残高元帳抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCodes">拠点コード（複数指定）(（配列）)</param>
		/// <param name="st_AddUpYearMonth">開始計上年月(YYYYMM)</param>
		/// <param name="ed_AddUpYearMonth">終了計上年月(YYYYMM)</param>
		/// <param name="st_ClaimCode">開始請求先コード</param>
		/// <param name="ed_ClaimCode">終了請求先コード</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="printMoneyDivCd">出力金額区分</param>
		/// <returns>ExtrInfo_AccRecBalanceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_AccRecBalanceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
        //public ExtrInfo_AccRecBalance(string enterpriseCode, string[] sectionCodes, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, Int32 st_ClaimCode, Int32 ed_ClaimCode, string enterpriseName, bool isSelectAllSection) // DEL 2014/02/26 田建委 Redmine#42188
        public ExtrInfo_AccRecBalance(string enterpriseCode, string[] sectionCodes, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, Int32 st_ClaimCode, Int32 ed_ClaimCode, string enterpriseName, bool isSelectAllSection, int printMoneyDivCd) // ADD 2014/02/26 田建委 Redmine#42188
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._st_ClaimCode = st_ClaimCode;
			this._ed_ClaimCode = ed_ClaimCode;
			this._enterpriseName = enterpriseName;
            this._isSelectAllSection = isSelectAllSection;
            this._printMoneyDivCd = printMoneyDivCd; // ADD 2014/02/26 田建委 Redmine#42188
		}

		/// <summary>
		/// 売掛残高元帳抽出条件クラス複製処理
		/// </summary>
		/// <returns>ExtrInfo_AccRecBalanceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_AccRecBalanceクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public ExtrInfo_AccRecBalance Clone()
		{
            //return new ExtrInfo_AccRecBalance(this._enterpriseCode, this._sectionCodes, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._st_ClaimCode, this._ed_ClaimCode, this._enterpriseName, this._isSelectAllSection); // DEL 2014/02/26 田建委 Redmine#42188
            return new ExtrInfo_AccRecBalance(this._enterpriseCode, this._sectionCodes, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._st_ClaimCode, this._ed_ClaimCode, this._enterpriseName, this._isSelectAllSection, this._printMoneyDivCd); // ADD 2014/02/26 田建委 Redmine#42188
		}

		/// <summary>
		/// 売掛残高元帳抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_AccRecBalanceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_AccRecBalanceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public bool Equals(ExtrInfo_AccRecBalance target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.St_ClaimCode == target.St_ClaimCode)
				 && (this.Ed_ClaimCode == target.Ed_ClaimCode)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.PrintMoneyDivCd == target.PrintMoneyDivCd) // ADD 2014/02/26 田建委 Redmine#42188
                 );
		}

		/// <summary>
		/// 売掛残高元帳抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_AccRecBalance1">
		///                    比較するExtrInfo_AccRecBalanceクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_AccRecBalance2">比較するExtrInfo_AccRecBalanceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_AccRecBalanceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_AccRecBalance extrInfo_AccRecBalance1, ExtrInfo_AccRecBalance extrInfo_AccRecBalance2)
		{
			return ((extrInfo_AccRecBalance1.EnterpriseCode == extrInfo_AccRecBalance2.EnterpriseCode)
				 && (extrInfo_AccRecBalance1.SectionCodes == extrInfo_AccRecBalance2.SectionCodes)
				 && (extrInfo_AccRecBalance1.St_AddUpYearMonth == extrInfo_AccRecBalance2.St_AddUpYearMonth)
				 && (extrInfo_AccRecBalance1.Ed_AddUpYearMonth == extrInfo_AccRecBalance2.Ed_AddUpYearMonth)
				 && (extrInfo_AccRecBalance1.St_ClaimCode == extrInfo_AccRecBalance2.St_ClaimCode)
				 && (extrInfo_AccRecBalance1.Ed_ClaimCode == extrInfo_AccRecBalance2.Ed_ClaimCode)
				 && (extrInfo_AccRecBalance1.EnterpriseName == extrInfo_AccRecBalance2.EnterpriseName)
                 && (extrInfo_AccRecBalance1.IsSelectAllSection == extrInfo_AccRecBalance2.IsSelectAllSection)
                 && (extrInfo_AccRecBalance1.PrintMoneyDivCd == extrInfo_AccRecBalance2.PrintMoneyDivCd) // ADD 2014/02/26 田建委 Redmine#42188
                 );
		}
		/// <summary>
		/// 売掛残高元帳抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_AccRecBalanceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_AccRecBalanceクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_AccRecBalance target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.St_ClaimCode != target.St_ClaimCode)resList.Add("St_ClaimCode");
			if(this.Ed_ClaimCode != target.Ed_ClaimCode)resList.Add("Ed_ClaimCode");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.PrintMoneyDivCd != target.PrintMoneyDivCd) resList.Add("PrintMoneyDivCd"); // ADD 2014/02/26 田建委 Redmine#42188

			return resList;
		}

		/// <summary>
		/// 売掛残高元帳抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_AccRecBalance1">比較するExtrInfo_AccRecBalanceクラスのインスタンス</param>
		/// <param name="extrInfo_AccRecBalance2">比較するExtrInfo_AccRecBalanceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_AccRecBalanceクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_AccRecBalance extrInfo_AccRecBalance1, ExtrInfo_AccRecBalance extrInfo_AccRecBalance2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_AccRecBalance1.EnterpriseCode != extrInfo_AccRecBalance2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_AccRecBalance1.SectionCodes != extrInfo_AccRecBalance2.SectionCodes)resList.Add("SectionCodes");
			if(extrInfo_AccRecBalance1.St_AddUpYearMonth != extrInfo_AccRecBalance2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(extrInfo_AccRecBalance1.Ed_AddUpYearMonth != extrInfo_AccRecBalance2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(extrInfo_AccRecBalance1.St_ClaimCode != extrInfo_AccRecBalance2.St_ClaimCode)resList.Add("St_ClaimCode");
			if(extrInfo_AccRecBalance1.Ed_ClaimCode != extrInfo_AccRecBalance2.Ed_ClaimCode)resList.Add("Ed_ClaimCode");
			if(extrInfo_AccRecBalance1.EnterpriseName != extrInfo_AccRecBalance2.EnterpriseName)resList.Add("EnterpriseName");
            if (extrInfo_AccRecBalance1.IsSelectAllSection != extrInfo_AccRecBalance2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (extrInfo_AccRecBalance1.PrintMoneyDivCd != extrInfo_AccRecBalance2.PrintMoneyDivCd) resList.Add("PrintMoneyDivCd"); // ADD 2014/02/26 田建委 Redmine#42188

			return resList;
		}
	}
}
