using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustFinancialListCndtn
	/// <summary>
	///                      得意先過年度統計表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先過年度統計表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/31  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustFinancialListCndtn
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string[] _addUpSecCodes;

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>開始年度</summary>
		private DateTime _st_Year;

		/// <summary>終了年度</summary>
		private DateTime _ed_Year;

		/// <summary>開始計上年月</summary>
		/// <remarks>終了年度の開始年月度をセット</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了計上年月</summary>
		/// <remarks>終了年度の終了年月度をセット</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>発行タイプ</summary>
		/// <remarks>0:得意先別,1:拠点別,2:得意先別拠点別,3:管理拠点別,4:請求先別</remarks>
		private PrintDivState _printDiv;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // 自動生成以外
        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;

        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;

        /// <summary>金額単位</summary>
        /// <remarks>0:円 1:千円</remarks>
        private MoneyUnitState _moneyUnit;

        /// <summary>改頁区分</summary>
        /// <remarks>0:しない 1:拠点毎 2:得意先毎</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>印刷タイプ</summary>
        /// <remarks>0:売上＆粗利 1:売上 2:粗利</remarks>
        private PrintMoneyDivState _printMoneyDiv;

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

		/// public propaty name  :  AddUpSecCodes
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] AddUpSecCodes
		{
			get{return _addUpSecCodes;}
			set{_addUpSecCodes = value;}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  St_Year
		/// <summary>開始年度プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始年度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_Year
		{
			get{return _st_Year;}
			set{_st_Year = value;}
		}

		/// public propaty name  :  Ed_Year
		/// <summary>終了年度プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了年度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_Year
		{
			get{return _ed_Year;}
			set{_ed_Year = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始計上年月プロパティ</summary>
		/// <value>終了年度の開始年月度をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了計上年月プロパティ</summary>
		/// <value>終了年度の終了年月度をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:得意先別,1:拠点別,2:得意先別拠点別,3:管理拠点別,4:請求先別</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PrintDivState PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
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

        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }

        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// <summary>
        /// 金額単位　プロパティ
        /// </summary>
        public MoneyUnitState MoneyUnit
        {
            get { return this._moneyUnit; }
            set { this._moneyUnit = value; }
        }

        /// <summary>
        /// 改ページ区分　プロパティ
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }

        /// <summary>
        /// 印刷タイプ　プロパティ
        /// </summary>
        public PrintMoneyDivState PrintMoneyDiv
        {
            get { return this._printMoneyDiv;}
            set { this._printMoneyDiv = value; }
        }

		/// <summary>
		/// 得意先過年度統計表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>CustFinancialListCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustFinancialListCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustFinancialListCndtn()
		{
		}

		/// <summary>
		/// 得意先過年度統計表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="addUpSecCodes">計上拠点コード(集計の対象となっている拠点コード)</param>
		/// <param name="st_CustomerCode">開始得意先コード</param>
		/// <param name="ed_CustomerCode">終了得意先コード</param>
		/// <param name="st_Year">開始年度</param>
		/// <param name="ed_Year">終了年度</param>
		/// <param name="st_AddUpYearMonth">開始計上年月(終了年度の開始年月度をセット)</param>
		/// <param name="ed_AddUpYearMonth">終了計上年月(終了年度の終了年月度をセット)</param>
		/// <param name="printDiv">発行タイプ(0:得意先別,1:拠点別,2:得意先別拠点別,3:管理拠点別,4:請求先別)</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="isOptSection">拠点オプション有無</param>
        /// <param name="moneyUnit">金額単位</param>
        /// <param name="newPageDiv">改頁</param>
        /// <param name="printMoneyDiv">印刷タイプ</param>
        /// <param name="st_IntYear">開始対象期間(帳票印字位置制御用)</param>
        /// <param name="ed_IntYear">終了対象期間(帳票印字位置制御用)</param>
		/// <returns>CustFinancialListCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustFinancialListCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public CustFinancialListCndtn(string enterpriseCode, string[] addUpSecCodes, Int32 st_CustomerCode, Int32 ed_CustomerCode, DateTime st_Year, DateTime ed_Year, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, PrintDivState printDiv, string enterpriseName, bool isOptSection, MoneyUnitState moneyUnit, NewPageDivState newPageDiv, PrintMoneyDivState printMoneyDiv)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCodes = addUpSecCodes;
			this._st_CustomerCode = st_CustomerCode;
			this._ed_CustomerCode = ed_CustomerCode;
			this._st_Year = st_Year;
			this._ed_Year = ed_Year;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._printDiv = printDiv;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._moneyUnit = moneyUnit;
            this._newPageDiv = newPageDiv;
            this._printMoneyDiv = printMoneyDiv;
		}

		/// <summary>
		/// 得意先過年度統計表抽出条件クラス複製処理
		/// </summary>
		/// <returns>CustFinancialListCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCustFinancialListCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustFinancialListCndtn Clone()
		{
            return new CustFinancialListCndtn(this._enterpriseCode, this._addUpSecCodes, this._st_CustomerCode, this._ed_CustomerCode, this._st_Year, this._ed_Year, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._printDiv, this._enterpriseName, this._isOptSection, this._moneyUnit, this._newPageDiv, this._printMoneyDiv);
		}

		/// <summary>
		/// 得意先過年度統計表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCustFinancialListCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustFinancialListCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(CustFinancialListCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCodes == target.AddUpSecCodes)
				 && (this.St_CustomerCode == target.St_CustomerCode)
				 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
				 && (this.St_Year == target.St_Year)
				 && (this.Ed_Year == target.Ed_Year)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.PrintDiv == target.PrintDiv)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.MoneyUnit == target.MoneyUnit)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.PrintMoneyDiv == target.PrintMoneyDiv)
                 );
		}

		/// <summary>
		/// 得意先過年度統計表抽出条件クラス比較処理
		/// </summary>
		/// <param name="custFinancialListCndtn1">
		///                    比較するCustFinancialListCndtnクラスのインスタンス
		/// </param>
		/// <param name="custFinancialListCndtn2">比較するCustFinancialListCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustFinancialListCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(CustFinancialListCndtn custFinancialListCndtn1, CustFinancialListCndtn custFinancialListCndtn2)
		{
			return ((custFinancialListCndtn1.EnterpriseCode == custFinancialListCndtn2.EnterpriseCode)
				 && (custFinancialListCndtn1.AddUpSecCodes == custFinancialListCndtn2.AddUpSecCodes)
				 && (custFinancialListCndtn1.St_CustomerCode == custFinancialListCndtn2.St_CustomerCode)
				 && (custFinancialListCndtn1.Ed_CustomerCode == custFinancialListCndtn2.Ed_CustomerCode)
				 && (custFinancialListCndtn1.St_Year == custFinancialListCndtn2.St_Year)
				 && (custFinancialListCndtn1.Ed_Year == custFinancialListCndtn2.Ed_Year)
				 && (custFinancialListCndtn1.St_AddUpYearMonth == custFinancialListCndtn2.St_AddUpYearMonth)
				 && (custFinancialListCndtn1.Ed_AddUpYearMonth == custFinancialListCndtn2.Ed_AddUpYearMonth)
				 && (custFinancialListCndtn1.PrintDiv == custFinancialListCndtn2.PrintDiv)
				 && (custFinancialListCndtn1.EnterpriseName == custFinancialListCndtn2.EnterpriseName)
                 && (custFinancialListCndtn1.IsOptSection == custFinancialListCndtn2.IsOptSection)
                 && (custFinancialListCndtn1.MoneyUnit == custFinancialListCndtn2.MoneyUnit)
                 && (custFinancialListCndtn1.NewPageDiv == custFinancialListCndtn2.NewPageDiv)
                 && (custFinancialListCndtn1.PrintMoneyDiv == custFinancialListCndtn2.PrintMoneyDiv)
                 );
		}
		/// <summary>
		/// 得意先過年度統計表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCustFinancialListCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustFinancialListCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(CustFinancialListCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCodes != target.AddUpSecCodes)resList.Add("AddUpSecCodes");
			if(this.St_CustomerCode != target.St_CustomerCode)resList.Add("St_CustomerCode");
			if(this.Ed_CustomerCode != target.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(this.St_Year != target.St_Year)resList.Add("St_Year");
			if(this.Ed_Year != target.Ed_Year)resList.Add("Ed_Year");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.PrintDiv != target.PrintDiv)resList.Add("PrintDiv");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.MoneyUnit != target.MoneyUnit) resList.Add("MoneyUnit");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.PrintMoneyDiv != target.PrintMoneyDiv) resList.Add("PrintMoneyDiv");

			return resList;
		}

		/// <summary>
		/// 得意先過年度統計表抽出条件クラス比較処理
		/// </summary>
		/// <param name="custFinancialListCndtn1">比較するCustFinancialListCndtnクラスのインスタンス</param>
		/// <param name="custFinancialListCndtn2">比較するCustFinancialListCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustFinancialListCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(CustFinancialListCndtn custFinancialListCndtn1, CustFinancialListCndtn custFinancialListCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(custFinancialListCndtn1.EnterpriseCode != custFinancialListCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(custFinancialListCndtn1.AddUpSecCodes != custFinancialListCndtn2.AddUpSecCodes)resList.Add("AddUpSecCodes");
			if(custFinancialListCndtn1.St_CustomerCode != custFinancialListCndtn2.St_CustomerCode)resList.Add("St_CustomerCode");
			if(custFinancialListCndtn1.Ed_CustomerCode != custFinancialListCndtn2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(custFinancialListCndtn1.St_Year != custFinancialListCndtn2.St_Year)resList.Add("St_Year");
			if(custFinancialListCndtn1.Ed_Year != custFinancialListCndtn2.Ed_Year)resList.Add("Ed_Year");
			if(custFinancialListCndtn1.St_AddUpYearMonth != custFinancialListCndtn2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(custFinancialListCndtn1.Ed_AddUpYearMonth != custFinancialListCndtn2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(custFinancialListCndtn1.PrintDiv != custFinancialListCndtn2.PrintDiv)resList.Add("PrintDiv");
			if(custFinancialListCndtn1.EnterpriseName != custFinancialListCndtn2.EnterpriseName)resList.Add("EnterpriseName");
            if (custFinancialListCndtn1.IsOptSection != custFinancialListCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (custFinancialListCndtn1.MoneyUnit != custFinancialListCndtn2.MoneyUnit) resList.Add("MoneyUnit");
            if (custFinancialListCndtn1.NewPageDiv != custFinancialListCndtn2.NewPageDiv) resList.Add("NewPageDiv");
            if (custFinancialListCndtn1.PrintMoneyDiv != custFinancialListCndtn2.PrintMoneyDiv) resList.Add("PrintMoneyDiv");

			return resList;
        }

        #region ■項目名称プロパティ
        /// <summary>
        /// 金額単位タイトル　プロパティ
        /// </summary>
        public string MoneyUnitStateTitle
        {
            get
            {
                switch (this._moneyUnit)
                {
                    case MoneyUnitState.One: return ct_MoneyUnitState_One;
                    case MoneyUnitState.Thousand: return ct_MoneyUnitState_Thousand;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 改ページ区分タイトル　プロパティ
        /// </summary>
        public string NewPageDivStateTitle
        {
            get
            {
                switch (this._newPageDiv)
                {
                    case NewPageDivState.Section: return ct_NewPageDivState_Section;
                    case NewPageDivState.Customer: return ct_NewPageDivState_Customer;
                    case NewPageDivState.None: return ct_NewPageDivState_None;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 印刷タイプタイトル　プロパティ
        /// </summary>
        public string PrintMoneyDivStateTitle
        {
            get
            {
                switch (this._printMoneyDiv)
                {
                    case PrintMoneyDivState.SalesAndGross: return ct_PrintMoneyDivState_SalesAndGross;
                    case PrintMoneyDivState.SalesMoney: return ct_PrintMoneyDivState_SalesMoney;
                    case PrintMoneyDivState.GrossProfit: return ct_PrintMoneyDivState_GrossProfit;
                    default: return "";
                }
            }
        }

        #endregion

        #region ■列挙体
        /// <summary>
        /// 金額単位　列挙体
        /// </summary>
        public enum MoneyUnitState
        {
            /// <summary>円</summary>
            One = 0,
            /// <summary>千円</summary>
            Thousand = 1
        }

        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>しない</summary>
            None = 0,
            /// <summary>拠点毎</summary>
            Section = 1,
            /// <summary>得意先毎</summary>
            Customer = 2,
        }

        public enum PrintDivState
        {
            /// <summary>得意先別</summary>
            Customer = 0,
            /// <summary>拠点別</summary>
            Section = 1,
            /// <summary>得意先別拠点別</summary>
            CustomerSection = 2,
            /// <summary>管理拠点別</summary>
            ManageSection = 3,
            /// <summary>請求先別</summary>
            Clame = 4,
        }

        /// <summary>
        /// 印刷タイプ　列挙体
        /// </summary>
        public enum PrintMoneyDivState
        {
            /// <summary>売上＆粗利</summary>
            SalesAndGross = 0,
            /// <summary>売上</summary>
            SalesMoney = 1,
            /// <summary>粗利</summary>
            GrossProfit = 2,
        }
        #endregion

        #region ■項目名称
        /// <summary>金額単位　円</summary>
        private const string ct_MoneyUnitState_One = "円";
        /// <summary>金額単位　千円</summary>
        private const string ct_MoneyUnitState_Thousand = "千円";

        /// <summary>改ページ区分 拠点毎</summary>
        private const string ct_NewPageDivState_Section = "拠点単位";
        /// <summary>改ページ区分 仕入先毎</summary>
        private const string ct_NewPageDivState_Customer = "得意先単位";
        /// <summary>改ページ区分 しない</summary>
        private const string ct_NewPageDivState_None = "しない";

        /// <summary>印刷タイプ 売上＆粗利</summary>
        private const string ct_PrintMoneyDivState_SalesAndGross = "売上＆粗利";
        private const string ct_PrintMoneyDivState_SalesMoney = "売上";
        private const string ct_PrintMoneyDivState_GrossProfit = "粗利";
        #endregion
    }
}
