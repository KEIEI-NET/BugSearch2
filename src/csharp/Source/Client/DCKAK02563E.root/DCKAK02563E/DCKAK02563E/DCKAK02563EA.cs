using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_PaymentBalance
	/// <summary>
	///                      支払残高元帳抽出条件ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   支払残高元帳抽出条件ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2014/02/26 田建委</br>
    /// <br>                 :   Redmine#42188 出力金額区分追加</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExtrInfo_PaymentBalance
	{
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>出力対象拠点</summary>
		/// <remarks>nullの場合は全拠点</remarks>
		private string[] _paymentAddupSecCodeList;

		/// <summary>開始対象年月</summary>
		private Int32 _st_AddUpYearMonth;

		/// <summary>終了対象年月</summary>
		private Int32 _ed_AddUpYearMonth;

		/// <summary>開始支払先コード</summary>
		private Int32 _st_PayeeCode;

		/// <summary>終了支払先コード</summary>
		private Int32 _ed_PayeeCode;

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

		/// public propaty name  :  PaymentAddupSecCodeList
		/// <summary>出力対象拠点プロパティ</summary>
		/// <value>nullの場合は全拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力対象拠点プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] PaymentAddupSecCodeList
		{
			get{return _paymentAddupSecCodeList;}
			set{_paymentAddupSecCodeList = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始対象年月プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了対象年月プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  St_PayeeCode
		/// <summary>開始支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_PayeeCode
		{
			get{return _st_PayeeCode;}
			set{_st_PayeeCode = value;}
		}

		/// public propaty name  :  Ed_PayeeCode
		/// <summary>終了支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_PayeeCode
		{
			get{return _ed_PayeeCode;}
			set{_ed_PayeeCode = value;}
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
		/// 支払残高元帳抽出条件ワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_PaymentBalanceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_PaymentBalanceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_PaymentBalance()
		{
		}

		/// <summary>
		/// 支払残高元帳抽出条件ワークコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="paymentAddupSecCodeList">出力対象拠点(nullの場合は全拠点)</param>
		/// <param name="st_AddUpYearMonth">開始対象年月</param>
		/// <param name="ed_AddUpYearMonth">終了対象年月</param>
		/// <param name="st_PayeeCode">開始支払先コード</param>
		/// <param name="ed_PayeeCode">終了支払先コード</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="isSelectAllSection">全社選択フラグ</param>
        /// <param name="printMoneyDivCd">出力金額区分</param>
		/// <returns>ExtrInfo_PaymentBalanceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_PaymentBalanceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
        //public ExtrInfo_PaymentBalance(string enterpriseCode, string[] paymentAddupSecCodeList, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, Int32 st_PayeeCode, Int32 ed_PayeeCode, string enterpriseName, bool isSelectAllSection) // DEL 2014/02/26 田建委 Redmine#42188
        public ExtrInfo_PaymentBalance(string enterpriseCode, string[] paymentAddupSecCodeList, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, Int32 st_PayeeCode, Int32 ed_PayeeCode, string enterpriseName, bool isSelectAllSection, int printMoneyDivCd) // ADD 2014/02/26 田建委 Redmine#42188
		{
			this._enterpriseCode = enterpriseCode;
			this._paymentAddupSecCodeList = paymentAddupSecCodeList;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._st_PayeeCode = st_PayeeCode;
			this._ed_PayeeCode = ed_PayeeCode;
			this._enterpriseName = enterpriseName;
            this._isSelectAllSection = isSelectAllSection;
            this._printMoneyDivCd = printMoneyDivCd; // ADD 2014/02/26 田建委 Redmine#42188
		}

		/// <summary>
		/// 支払残高元帳抽出条件ワーク複製処理
		/// </summary>
		/// <returns>ExtrInfo_PaymentBalanceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_PaymentBalanceクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public ExtrInfo_PaymentBalance Clone()
		{
            //return new ExtrInfo_PaymentBalance(this._enterpriseCode,this._paymentAddupSecCodeList,this._st_AddUpYearMonth,this._ed_AddUpYearMonth,this._st_PayeeCode,this._ed_PayeeCode,this._enterpriseName, this._isSelectAllSection); // DEL 2014/02/26 田建委 Redmine#42188
            return new ExtrInfo_PaymentBalance(this._enterpriseCode, this._paymentAddupSecCodeList, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._st_PayeeCode, this._ed_PayeeCode, this._enterpriseName, this._isSelectAllSection, this._printMoneyDivCd); // ADD 2014/02/26 田建委 Redmine#42188
		}

		/// <summary>
		/// 支払残高元帳抽出条件ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_PaymentBalanceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_PaymentBalanceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public bool Equals(ExtrInfo_PaymentBalance target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.PaymentAddupSecCodeList == target.PaymentAddupSecCodeList)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.St_PayeeCode == target.St_PayeeCode)
				 && (this.Ed_PayeeCode == target.Ed_PayeeCode)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.PrintMoneyDivCd == target.PrintMoneyDivCd) // ADD 2014/02/26 田建委 Redmine#42188
                 );
		}

		/// <summary>
		/// 支払残高元帳抽出条件ワーク比較処理
		/// </summary>
		/// <param name="extrInfo_PaymentBalance1">
		///                    比較するExtrInfo_PaymentBalanceクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_PaymentBalance2">比較するExtrInfo_PaymentBalanceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_PaymentBalanceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_PaymentBalance extrInfo_PaymentBalance1, ExtrInfo_PaymentBalance extrInfo_PaymentBalance2)
		{
			return ((extrInfo_PaymentBalance1.EnterpriseCode == extrInfo_PaymentBalance2.EnterpriseCode)
				 && (extrInfo_PaymentBalance1.PaymentAddupSecCodeList == extrInfo_PaymentBalance2.PaymentAddupSecCodeList)
				 && (extrInfo_PaymentBalance1.St_AddUpYearMonth == extrInfo_PaymentBalance2.St_AddUpYearMonth)
				 && (extrInfo_PaymentBalance1.Ed_AddUpYearMonth == extrInfo_PaymentBalance2.Ed_AddUpYearMonth)
				 && (extrInfo_PaymentBalance1.St_PayeeCode == extrInfo_PaymentBalance2.St_PayeeCode)
				 && (extrInfo_PaymentBalance1.Ed_PayeeCode == extrInfo_PaymentBalance2.Ed_PayeeCode)
				 && (extrInfo_PaymentBalance1.EnterpriseName == extrInfo_PaymentBalance2.EnterpriseName)
                 && (extrInfo_PaymentBalance1.IsSelectAllSection == extrInfo_PaymentBalance2.IsSelectAllSection)
                 && (extrInfo_PaymentBalance1.PrintMoneyDivCd == extrInfo_PaymentBalance2.PrintMoneyDivCd) // ADD 2014/02/26 田建委 Redmine#42188
                 );
		}
		/// <summary>
		/// 支払残高元帳抽出条件ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_PaymentBalanceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_PaymentBalanceクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_PaymentBalance target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.PaymentAddupSecCodeList != target.PaymentAddupSecCodeList)resList.Add("PaymentAddupSecCodeList");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.St_PayeeCode != target.St_PayeeCode)resList.Add("St_PayeeCode");
			if(this.Ed_PayeeCode != target.Ed_PayeeCode)resList.Add("Ed_PayeeCode");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.PrintMoneyDivCd != target.PrintMoneyDivCd) resList.Add("PrintMoneyDivCd"); // ADD 2014/02/26 田建委 Redmine#42188

			return resList;
		}

		/// <summary>
		/// 支払残高元帳抽出条件ワーク比較処理
		/// </summary>
		/// <param name="extrInfo_PaymentBalance1">比較するExtrInfo_PaymentBalanceクラスのインスタンス</param>
		/// <param name="extrInfo_PaymentBalance2">比較するExtrInfo_PaymentBalanceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_PaymentBalanceクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/02/26 田建委</br>
        /// <br>                 :   Redmine#42188 出力金額区分追加</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_PaymentBalance extrInfo_PaymentBalance1, ExtrInfo_PaymentBalance extrInfo_PaymentBalance2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_PaymentBalance1.EnterpriseCode != extrInfo_PaymentBalance2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_PaymentBalance1.PaymentAddupSecCodeList != extrInfo_PaymentBalance2.PaymentAddupSecCodeList)resList.Add("PaymentAddupSecCodeList");
			if(extrInfo_PaymentBalance1.St_AddUpYearMonth != extrInfo_PaymentBalance2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(extrInfo_PaymentBalance1.Ed_AddUpYearMonth != extrInfo_PaymentBalance2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(extrInfo_PaymentBalance1.St_PayeeCode != extrInfo_PaymentBalance2.St_PayeeCode)resList.Add("St_PayeeCode");
			if(extrInfo_PaymentBalance1.Ed_PayeeCode != extrInfo_PaymentBalance2.Ed_PayeeCode)resList.Add("Ed_PayeeCode");
			if(extrInfo_PaymentBalance1.EnterpriseName != extrInfo_PaymentBalance2.EnterpriseName)resList.Add("EnterpriseName");
            if (extrInfo_PaymentBalance1.IsSelectAllSection != extrInfo_PaymentBalance2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (extrInfo_PaymentBalance1.PrintMoneyDivCd != extrInfo_PaymentBalance2.PrintMoneyDivCd) resList.Add("PrintMoneyDivCd"); // ADD 2014/02/26 田建委 Redmine#42188

			return resList;
		}
	}
}
