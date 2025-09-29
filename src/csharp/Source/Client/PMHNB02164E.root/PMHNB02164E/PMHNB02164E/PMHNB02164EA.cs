using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesHistAnalyzeCndtn
	/// <summary>
	///                      売上内容分析表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上内容分析表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SalesHistAnalyzeCndtn
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string[] _sectionCode;

		/// <summary>開始対象日付</summary>
		private Int32 _st_SalesDate;

		/// <summary>終了対象日付</summary>
		private Int32 _ed_SalesDate;

		/// <summary>開始対象日付(累計)</summary>
		/// <remarks>累計抽出範囲の開始日付をセット</remarks>
		private Int32 _st_MonthReportDate;

		/// <summary>終了対象日付(累計)</summary>
		/// <remarks>終了日付をセット</remarks>
		private Int32 _ed_MonthReportDate;

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>開始販売従業員コード</summary>
		private string _st_SalesEmployeeCd = "";

		/// <summary>終了販売従業員コード</summary>
		private string _ed_SalesEmployeeCd = "";

		/// <summary>開始販売エリアコード</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _st_SalesAreaCode;

		/// <summary>終了販売エリアコード</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _ed_SalesAreaCode;

		/// <summary>発行タイプ</summary>
		/// <remarks>0:得意先別,1:担当者別,2:地区別</remarks>
        private PrintDivState _printDiv;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // 自動生成以外
        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;

        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;

        /// <summary>累計印刷</summary>
        /// <remarks>0:する 1:しない</remarks>
        private MonthReportDivState _monthReportDiv;

        /// <summary>改頁区分</summary>
        /// <remarks>0:しない 1:拠点毎 2:得意先毎</remarks>
        private NewPageDivState _newPageDiv;

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

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  St_SalesDate
		/// <summary>開始対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_SalesDate
		{
			get{return _st_SalesDate;}
			set{_st_SalesDate = value;}
		}

		/// public propaty name  :  Ed_SalesDate
		/// <summary>終了対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_SalesDate
		{
			get{return _ed_SalesDate;}
			set{_ed_SalesDate = value;}
		}

		/// public propaty name  :  St_MonthReportDate
		/// <summary>開始対象日付(累計)プロパティ</summary>
		/// <value>累計抽出範囲の開始日付をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象日付(累計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_MonthReportDate
		{
			get{return _st_MonthReportDate;}
			set{_st_MonthReportDate = value;}
		}

		/// public propaty name  :  Ed_MonthReportDate
		/// <summary>終了対象日付(累計)プロパティ</summary>
		/// <value>終了日付をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象日付(累計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_MonthReportDate
		{
			get{return _ed_MonthReportDate;}
			set{_ed_MonthReportDate = value;}
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

		/// public propaty name  :  St_SalesEmployeeCd
		/// <summary>開始販売従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始販売従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_SalesEmployeeCd
		{
			get{return _st_SalesEmployeeCd;}
			set{_st_SalesEmployeeCd = value;}
		}

		/// public propaty name  :  Ed_SalesEmployeeCd
		/// <summary>終了販売従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了販売従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_SalesEmployeeCd
		{
			get{return _ed_SalesEmployeeCd;}
			set{_ed_SalesEmployeeCd = value;}
		}

		/// public propaty name  :  St_SalesAreaCode
		/// <summary>開始販売エリアコードプロパティ</summary>
		/// <value>地区コード</value>
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
		/// <value>地区コード</value>
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

		/// public propaty name  :  PrintDiv
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:得意先別,1:担当者別,2:地区別</value>
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
        /// 累計印刷　プロパティ
        /// </summary>
        public MonthReportDivState MonthReportDiv
        {
            get { return this._monthReportDiv; }
            set { this._monthReportDiv = value; }
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
		/// 売上内容分析表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>SalesHistAnalyzeCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesHistAnalyzeCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesHistAnalyzeCndtn()
		{
		}

		/// <summary>
		/// 売上内容分析表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード(集計の対象となっている拠点コード)</param>
		/// <param name="st_SalesDate">開始対象日付</param>
		/// <param name="ed_SalesDate">終了対象日付</param>
		/// <param name="st_MonthReportDate">開始対象日付(累計)(累計抽出範囲の開始日付をセット)</param>
		/// <param name="ed_MonthReportDate">終了対象日付(累計)(終了日付をセット)</param>
		/// <param name="st_CustomerCode">開始得意先コード</param>
		/// <param name="ed_CustomerCode">終了得意先コード</param>
		/// <param name="st_SalesEmployeeCd">開始販売従業員コード</param>
		/// <param name="ed_SalesEmployeeCd">終了販売従業員コード</param>
		/// <param name="st_SalesAreaCode">開始販売エリアコード(地区コード)</param>
		/// <param name="ed_SalesAreaCode">終了販売エリアコード(地区コード)</param>
		/// <param name="printDiv">発行タイプ(0:得意先別,1:担当者別,2:地区別)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>SalesHistAnalyzeCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesHistAnalyzeCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SalesHistAnalyzeCndtn(string enterpriseCode, string[] sectionCode, Int32 st_SalesDate, Int32 ed_SalesDate, Int32 st_MonthReportDate, Int32 ed_MonthReportDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesEmployeeCd, string ed_SalesEmployeeCd, Int32 st_SalesAreaCode, Int32 ed_SalesAreaCode, PrintDivState printDiv, string enterpriseName, bool isOptSection, bool isSelectAllSection, MonthReportDivState monthReportDiv, NewPageDivState newPageDiv)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._st_SalesDate = st_SalesDate;
			this._ed_SalesDate = ed_SalesDate;
			this._st_MonthReportDate = st_MonthReportDate;
			this._ed_MonthReportDate = ed_MonthReportDate;
			this._st_CustomerCode = st_CustomerCode;
			this._ed_CustomerCode = ed_CustomerCode;
			this._st_SalesEmployeeCd = st_SalesEmployeeCd;
			this._ed_SalesEmployeeCd = ed_SalesEmployeeCd;
			this._st_SalesAreaCode = st_SalesAreaCode;
			this._ed_SalesAreaCode = ed_SalesAreaCode;
			this._printDiv = printDiv;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._monthReportDiv = monthReportDiv;
            this._newPageDiv = newPageDiv;
		}

		/// <summary>
		/// 売上内容分析表抽出条件クラス複製処理
		/// </summary>
		/// <returns>SalesHistAnalyzeCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSalesHistAnalyzeCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesHistAnalyzeCndtn Clone()
		{
            return new SalesHistAnalyzeCndtn(this._enterpriseCode, this._sectionCode, this._st_SalesDate, this._ed_SalesDate, this._st_MonthReportDate, this._ed_MonthReportDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesEmployeeCd, this._ed_SalesEmployeeCd, this._st_SalesAreaCode, this._ed_SalesAreaCode, this._printDiv, this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._monthReportDiv, this._newPageDiv);
		}

		/// <summary>
		/// 売上内容分析表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesHistAnalyzeCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesHistAnalyzeCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SalesHistAnalyzeCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.St_SalesDate == target.St_SalesDate)
				 && (this.Ed_SalesDate == target.Ed_SalesDate)
				 && (this.St_MonthReportDate == target.St_MonthReportDate)
				 && (this.Ed_MonthReportDate == target.Ed_MonthReportDate)
				 && (this.St_CustomerCode == target.St_CustomerCode)
				 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
				 && (this.St_SalesEmployeeCd == target.St_SalesEmployeeCd)
				 && (this.Ed_SalesEmployeeCd == target.Ed_SalesEmployeeCd)
				 && (this.St_SalesAreaCode == target.St_SalesAreaCode)
				 && (this.Ed_SalesAreaCode == target.Ed_SalesAreaCode)
				 && (this.PrintDiv == target.PrintDiv)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.MonthReportDiv == target.MonthReportDiv)
                 && (this.NewPageDiv == target.NewPageDiv));

		}

		/// <summary>
		/// 売上内容分析表抽出条件クラス比較処理
		/// </summary>
		/// <param name="salesHistAnalyzeCndtn1">
		///                    比較するSalesHistAnalyzeCndtnクラスのインスタンス
		/// </param>
		/// <param name="salesHistAnalyzeCndtn2">比較するSalesHistAnalyzeCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesHistAnalyzeCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn1, SalesHistAnalyzeCndtn salesHistAnalyzeCndtn2)
		{
			return ((salesHistAnalyzeCndtn1.EnterpriseCode == salesHistAnalyzeCndtn2.EnterpriseCode)
				 && (salesHistAnalyzeCndtn1.SectionCode == salesHistAnalyzeCndtn2.SectionCode)
				 && (salesHistAnalyzeCndtn1.St_SalesDate == salesHistAnalyzeCndtn2.St_SalesDate)
				 && (salesHistAnalyzeCndtn1.Ed_SalesDate == salesHistAnalyzeCndtn2.Ed_SalesDate)
				 && (salesHistAnalyzeCndtn1.St_MonthReportDate == salesHistAnalyzeCndtn2.St_MonthReportDate)
				 && (salesHistAnalyzeCndtn1.Ed_MonthReportDate == salesHistAnalyzeCndtn2.Ed_MonthReportDate)
				 && (salesHistAnalyzeCndtn1.St_CustomerCode == salesHistAnalyzeCndtn2.St_CustomerCode)
				 && (salesHistAnalyzeCndtn1.Ed_CustomerCode == salesHistAnalyzeCndtn2.Ed_CustomerCode)
				 && (salesHistAnalyzeCndtn1.St_SalesEmployeeCd == salesHistAnalyzeCndtn2.St_SalesEmployeeCd)
				 && (salesHistAnalyzeCndtn1.Ed_SalesEmployeeCd == salesHistAnalyzeCndtn2.Ed_SalesEmployeeCd)
				 && (salesHistAnalyzeCndtn1.St_SalesAreaCode == salesHistAnalyzeCndtn2.St_SalesAreaCode)
				 && (salesHistAnalyzeCndtn1.Ed_SalesAreaCode == salesHistAnalyzeCndtn2.Ed_SalesAreaCode)
				 && (salesHistAnalyzeCndtn1.PrintDiv == salesHistAnalyzeCndtn2.PrintDiv)
				 && (salesHistAnalyzeCndtn1.EnterpriseName == salesHistAnalyzeCndtn2.EnterpriseName)
                 && (salesHistAnalyzeCndtn1.IsOptSection == salesHistAnalyzeCndtn2.IsOptSection)
                 && (salesHistAnalyzeCndtn1.IsSelectAllSection == salesHistAnalyzeCndtn2.IsSelectAllSection)
                 && (salesHistAnalyzeCndtn1.MonthReportDiv == salesHistAnalyzeCndtn2.MonthReportDiv)
                 && (salesHistAnalyzeCndtn1.NewPageDiv == salesHistAnalyzeCndtn2.NewPageDiv)
                 );
		}
		/// <summary>
		/// 売上内容分析表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesHistAnalyzeCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesHistAnalyzeCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SalesHistAnalyzeCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.St_SalesDate != target.St_SalesDate)resList.Add("St_SalesDate");
			if(this.Ed_SalesDate != target.Ed_SalesDate)resList.Add("Ed_SalesDate");
			if(this.St_MonthReportDate != target.St_MonthReportDate)resList.Add("St_MonthReportDate");
			if(this.Ed_MonthReportDate != target.Ed_MonthReportDate)resList.Add("Ed_MonthReportDate");
			if(this.St_CustomerCode != target.St_CustomerCode)resList.Add("St_CustomerCode");
			if(this.Ed_CustomerCode != target.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(this.St_SalesEmployeeCd != target.St_SalesEmployeeCd)resList.Add("St_SalesEmployeeCd");
			if(this.Ed_SalesEmployeeCd != target.Ed_SalesEmployeeCd)resList.Add("Ed_SalesEmployeeCd");
			if(this.St_SalesAreaCode != target.St_SalesAreaCode)resList.Add("St_SalesAreaCode");
			if(this.Ed_SalesAreaCode != target.Ed_SalesAreaCode)resList.Add("Ed_SalesAreaCode");
			if(this.PrintDiv != target.PrintDiv)resList.Add("PrintDiv");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsOptSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.MonthReportDiv != target.MonthReportDiv) resList.Add("MonthReportDiv");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");

			return resList;
		}

		/// <summary>
		/// 売上内容分析表抽出条件クラス比較処理
		/// </summary>
		/// <param name="salesHistAnalyzeCndtn1">比較するSalesHistAnalyzeCndtnクラスのインスタンス</param>
		/// <param name="salesHistAnalyzeCndtn2">比較するSalesHistAnalyzeCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesHistAnalyzeCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn1, SalesHistAnalyzeCndtn salesHistAnalyzeCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(salesHistAnalyzeCndtn1.EnterpriseCode != salesHistAnalyzeCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(salesHistAnalyzeCndtn1.SectionCode != salesHistAnalyzeCndtn2.SectionCode)resList.Add("SectionCode");
			if(salesHistAnalyzeCndtn1.St_SalesDate != salesHistAnalyzeCndtn2.St_SalesDate)resList.Add("St_SalesDate");
			if(salesHistAnalyzeCndtn1.Ed_SalesDate != salesHistAnalyzeCndtn2.Ed_SalesDate)resList.Add("Ed_SalesDate");
			if(salesHistAnalyzeCndtn1.St_MonthReportDate != salesHistAnalyzeCndtn2.St_MonthReportDate)resList.Add("St_MonthReportDate");
			if(salesHistAnalyzeCndtn1.Ed_MonthReportDate != salesHistAnalyzeCndtn2.Ed_MonthReportDate)resList.Add("Ed_MonthReportDate");
			if(salesHistAnalyzeCndtn1.St_CustomerCode != salesHistAnalyzeCndtn2.St_CustomerCode)resList.Add("St_CustomerCode");
			if(salesHistAnalyzeCndtn1.Ed_CustomerCode != salesHistAnalyzeCndtn2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(salesHistAnalyzeCndtn1.St_SalesEmployeeCd != salesHistAnalyzeCndtn2.St_SalesEmployeeCd)resList.Add("St_SalesEmployeeCd");
			if(salesHistAnalyzeCndtn1.Ed_SalesEmployeeCd != salesHistAnalyzeCndtn2.Ed_SalesEmployeeCd)resList.Add("Ed_SalesEmployeeCd");
			if(salesHistAnalyzeCndtn1.St_SalesAreaCode != salesHistAnalyzeCndtn2.St_SalesAreaCode)resList.Add("St_SalesAreaCode");
			if(salesHistAnalyzeCndtn1.Ed_SalesAreaCode != salesHistAnalyzeCndtn2.Ed_SalesAreaCode)resList.Add("Ed_SalesAreaCode");
			if(salesHistAnalyzeCndtn1.PrintDiv != salesHistAnalyzeCndtn2.PrintDiv)resList.Add("PrintDiv");
			if(salesHistAnalyzeCndtn1.EnterpriseName != salesHistAnalyzeCndtn2.EnterpriseName)resList.Add("EnterpriseName");
            if (salesHistAnalyzeCndtn1.IsOptSection != salesHistAnalyzeCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (salesHistAnalyzeCndtn1.IsSelectAllSection != salesHistAnalyzeCndtn2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (salesHistAnalyzeCndtn1.MonthReportDiv != salesHistAnalyzeCndtn2.MonthReportDiv) resList.Add("MoneyUnit");
            if (salesHistAnalyzeCndtn1.NewPageDiv != salesHistAnalyzeCndtn2.NewPageDiv) resList.Add("NewPageDiv");

			return resList;
		}
        #region ■項目名称プロパティ
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
                    case NewPageDivState.None: return ct_NewPageDivState_None;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 発行タイプタイトル　プロパティ
        /// </summary>
        public string PrintDivStateTitle
        {
            get
            {
                switch (this._printDiv)
                {
                    case PrintDivState.Customer: return ct_PrintDivState_Customer;
                    case PrintDivState.Employee: return ct_PrintDivState_Employee;
                    case PrintDivState.SalesArea: return ct_PrintDivState_SalesArea;
                    default: return "";
                }
            }
        }

        #endregion

        #region ■列挙体
        /// <summary>
        /// 累計印刷　列挙体
        /// </summary>
        public enum MonthReportDivState
        {
            /// <summary>する</summary>
            Do = 0,
            /// <summary>しない</summary>
            None = 1
        }

        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>しない</summary>
            None = 1,
            /// <summary>拠点毎</summary>
            Section = 0,
        }

        /// <summary>
        /// 発行タイプ列挙対
        /// </summary>
        public enum PrintDivState
        {
            /// <summary>得意先別</summary>
            Customer = 0,
            /// <summary>担当者別</summary>
            Employee = 1,
            /// <summary>地区別</summary>
            SalesArea = 2,

        }
        #endregion

        #region ■項目名称
        /// <summary>改ページ区分 拠点毎</summary>
        private const string ct_NewPageDivState_Section = "拠点単位";
        /// <summary>改ページ区分 しない</summary>
        private const string ct_NewPageDivState_None = "しない";

        /// <summary>発行タイプ</summary>
        private const string ct_PrintDivState_Customer = "得意先";
        private const string ct_PrintDivState_Employee = "担当者";
        private const string ct_PrintDivState_SalesArea = "地区";
        #endregion
	}
}
