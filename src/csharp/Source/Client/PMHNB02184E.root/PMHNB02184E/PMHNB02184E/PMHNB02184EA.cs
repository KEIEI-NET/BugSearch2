using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustSalesDistributionReportParam
	/// <summary>
	///                      得意先別取引分布表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先別取引分布表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/21  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustSalesDistributionReportParam
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string[] _sectionCode;

		/// <summary>開始対象日付</summary>
		private Int32 _stSalesDate;

		/// <summary>終了対象日付</summary>
		private Int32 _edSalesDate;

		/// <summary>開始販売従業員コード</summary>
		private string _stSalesEmployeeCd = "";

		/// <summary>終了販売従業員コード</summary>
		private string _edSalesEmployeeCd = "";

		/// <summary>販売エリアコード</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _stSalesAreaCode;

		/// <summary>販売エリアコード</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _edSalesAreaCode;

		/// <summary>開始得意先コード</summary>
		private Int32 _stCustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _edCustomerCode;

		/// <summary>発行タイプ</summary>
		/// <remarks>0:得意先 1:担当者 2:地区</remarks>
        private PrintTypeState _printType;

		/// <summary>実績無印刷区分</summary>
		/// <remarks>0:する 1:しない</remarks>
		private Int32 _searchDiv;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // 自動生成以外
        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;

        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;

        /// <summary>改頁</summary>
        /// <remarks>0:拠点 1:しない</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>順位付設定　単位</summary>
        /// <remarks>0:全拠点 1:拠点毎</remarks>
        private RankSectionState _rankSection;

        /// <summary>順位付設定　上位・下位</summary>
        /// <remarks>0:上位 1:下位</remarks>
        private RankHighLowState _rankHighLow;

        /// <summary>順位付設定　最大値</summary>
        private Int32 _rankOrderMax;

        /// <summary>順位指定</summary>
        /// <remarks>0:順売上 1:粗利</remarks>
        private RankStandardState _rankStandard;

        /// <summary>印刷順</summary>
        private PrintOrderState _printOrder;
        
        /// <summary>期首年月日</summary>
		private DateTime _startDate;

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

		/// public propaty name  :  StSalesDate
		/// <summary>開始対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StSalesDate
		{
			get{return _stSalesDate;}
			set{_stSalesDate = value;}
		}

		/// public propaty name  :  EdSalesDate
		/// <summary>終了対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdSalesDate
		{
			get{return _edSalesDate;}
			set{_edSalesDate = value;}
		}

		/// public propaty name  :  StSalesEmployeeCd
		/// <summary>開始販売従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始販売従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StSalesEmployeeCd
		{
			get{return _stSalesEmployeeCd;}
			set{_stSalesEmployeeCd = value;}
		}

		/// public propaty name  :  EdSalesEmployeeCd
		/// <summary>終了販売従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了販売従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdSalesEmployeeCd
		{
			get{return _edSalesEmployeeCd;}
			set{_edSalesEmployeeCd = value;}
		}

		/// public propaty name  :  StSalesAreaCode
		/// <summary>販売エリアコードプロパティ</summary>
		/// <value>地区コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StSalesAreaCode
		{
			get{return _stSalesAreaCode;}
			set{_stSalesAreaCode = value;}
		}

		/// public propaty name  :  EdSalesAreaCode
		/// <summary>販売エリアコードプロパティ</summary>
		/// <value>地区コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdSalesAreaCode
		{
			get{return _edSalesAreaCode;}
			set{_edSalesAreaCode = value;}
		}

		/// public propaty name  :  StCustomerCode
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StCustomerCode
		{
			get{return _stCustomerCode;}
			set{_stCustomerCode = value;}
		}

		/// public propaty name  :  EdCustomerCode
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdCustomerCode
		{
			get{return _edCustomerCode;}
			set{_edCustomerCode = value;}
		}

		/// public propaty name  :  PrintType
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:得意先 1:担当者 2:地区</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public PrintTypeState PrintType
		{
			get{return _printType;}
            set{ _printType = value; }
		}

		/// public propaty name  :  SearchDiv
		/// <summary>実績無印刷区分プロパティ</summary>
		/// <value>0:する 1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   実績無印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchDiv
		{
			get{return _searchDiv;}
			set{_searchDiv = value;}
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
        /// 順位付設定　単位プロパティ
        /// </summary>
        public RankSectionState RankSection
        {
            get { return this._rankSection; }
            set { this._rankSection = value; }
        }

        /// <summary>
        /// 順位付設定　上位・下位プロパティ
        /// </summary>
        public RankHighLowState RankHighLow
        {
            get { return this._rankHighLow; }
            set { this._rankHighLow = value; }
        }

        /// <summary>
        /// 順位付設定　最大値プロパティ
        /// </summary>
        public Int32 RankOrderMax
        {
            get { return this._rankOrderMax; }
            set { this._rankOrderMax = value; }
        }

        /// <summary>
        /// 順位指定　プロパティ
        /// </summary>
        public RankStandardState RankStandard
        {
            get { return this._rankStandard; }
            set { this._rankStandard = value; }
        }

        /// <summary>
        /// 印刷順　プロパティ
        /// </summary>
        public PrintOrderState PrintOrder
        {
            get { return this._printOrder; }
            set { this._printOrder = value; }
        }

        /// <summary>
        /// 改頁プロパティ
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }

        /// <summary>
        /// 期首日　プロパティ
        /// </summary>
        public DateTime StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }


		/// <summary>
		/// 得意先別取引分布表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>CustSalesDistributionReportParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustSalesDistributionReportParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustSalesDistributionReportParam()
		{
		}

		/// <summary>
		/// 得意先別取引分布表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード(集計の対象となっている拠点コード)</param>
		/// <param name="stSalesDate">開始対象日付</param>
		/// <param name="edSalesDate">終了対象日付</param>
		/// <param name="stSalesEmployeeCd">開始販売従業員コード</param>
		/// <param name="edSalesEmployeeCd">終了販売従業員コード</param>
		/// <param name="stSalesAreaCode">販売エリアコード(地区コード)</param>
		/// <param name="edSalesAreaCode">販売エリアコード(地区コード)</param>
		/// <param name="stCustomerCode">開始得意先コード</param>
		/// <param name="edCustomerCode">終了得意先コード</param>
		/// <param name="printType">発行タイプ(0:得意先 1:担当者 2:地区)</param>
		/// <param name="searchDiv">実績無印刷区分(0:する 1:しない)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>CustSalesDistributionReportParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustSalesDistributionReportParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public CustSalesDistributionReportParam(string enterpriseCode, string[] sectionCode, Int32 stSalesDate, Int32 edSalesDate, string stSalesEmployeeCd, string edSalesEmployeeCd, Int32 stSalesAreaCode, Int32 edSalesAreaCode, Int32 stCustomerCode, Int32 edCustomerCode, PrintTypeState printType, Int32 searchDiv, string enterpriseName,
            bool isOptSection, bool isSelectAllSection, RankSectionState rankSection, RankHighLowState rankHighLow, Int32 rankOrderMax, RankStandardState rankStandard, PrintOrderState printOrder, NewPageDivState newPageDiv, DateTime startDate)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._stSalesDate = stSalesDate;
			this._edSalesDate = edSalesDate;
			this._stSalesEmployeeCd = stSalesEmployeeCd;
			this._edSalesEmployeeCd = edSalesEmployeeCd;
			this._stSalesAreaCode = stSalesAreaCode;
			this._edSalesAreaCode = edSalesAreaCode;
			this._stCustomerCode = stCustomerCode;
			this._edCustomerCode = edCustomerCode;
			this._printType = printType;
			this._searchDiv = searchDiv;
			this._enterpriseName = enterpriseName;

            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._rankSection = rankSection;
            this._rankHighLow = rankHighLow;
            this._rankOrderMax = rankOrderMax;
            this._rankStandard = rankStandard;
            this._printOrder = printOrder;
            this._newPageDiv = newPageDiv;
            this._startDate = startDate;
		}

		/// <summary>
		/// 得意先別取引分布表抽出条件クラス複製処理
		/// </summary>
		/// <returns>CustSalesDistributionReportParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCustSalesDistributionReportParamクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustSalesDistributionReportParam Clone()
		{
			return new CustSalesDistributionReportParam(this._enterpriseCode,this._sectionCode,this._stSalesDate,this._edSalesDate,this._stSalesEmployeeCd,this._edSalesEmployeeCd,this._stSalesAreaCode,this._edSalesAreaCode,this._stCustomerCode,this._edCustomerCode,this._printType,this._searchDiv,this._enterpriseName,
                this._isOptSection, this._isSelectAllSection, this._rankSection, this._rankHighLow, this._rankOrderMax, this._rankStandard, this._printOrder, this._newPageDiv, this._startDate);
		}

		/// <summary>
		/// 得意先別取引分布表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCustSalesDistributionReportParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustSalesDistributionReportParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(CustSalesDistributionReportParam target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.StSalesDate == target.StSalesDate)
				 && (this.EdSalesDate == target.EdSalesDate)
				 && (this.StSalesEmployeeCd == target.StSalesEmployeeCd)
				 && (this.EdSalesEmployeeCd == target.EdSalesEmployeeCd)
				 && (this.StSalesAreaCode == target.StSalesAreaCode)
				 && (this.EdSalesAreaCode == target.EdSalesAreaCode)
				 && (this.StCustomerCode == target.StCustomerCode)
				 && (this.EdCustomerCode == target.EdCustomerCode)
				 && (this.PrintType == target.PrintType)
				 && (this.SearchDiv == target.SearchDiv)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.RankSection == target.RankSection)
                 && (this.RankHighLow == target.RankHighLow)
                 && (this.RankOrderMax == target.RankOrderMax)
                 && (this.RankStandard == target.RankStandard)
                 && (this.PrintOrder == target.PrintOrder)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.StartDate == target.StartDate)  
                 );
		}

		/// <summary>
		/// 得意先別取引分布表抽出条件クラス比較処理
		/// </summary>
		/// <param name="custSalesDistributionReportParam1">
		///                    比較するCustSalesDistributionReportParamクラスのインスタンス
		/// </param>
		/// <param name="custSalesDistributionReportParam2">比較するCustSalesDistributionReportParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustSalesDistributionReportParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(CustSalesDistributionReportParam custSalesDistributionReportParam1, CustSalesDistributionReportParam custSalesDistributionReportParam2)
		{
			return ((custSalesDistributionReportParam1.EnterpriseCode == custSalesDistributionReportParam2.EnterpriseCode)
				 && (custSalesDistributionReportParam1.SectionCode == custSalesDistributionReportParam2.SectionCode)
				 && (custSalesDistributionReportParam1.StSalesDate == custSalesDistributionReportParam2.StSalesDate)
				 && (custSalesDistributionReportParam1.EdSalesDate == custSalesDistributionReportParam2.EdSalesDate)
				 && (custSalesDistributionReportParam1.StSalesEmployeeCd == custSalesDistributionReportParam2.StSalesEmployeeCd)
				 && (custSalesDistributionReportParam1.EdSalesEmployeeCd == custSalesDistributionReportParam2.EdSalesEmployeeCd)
				 && (custSalesDistributionReportParam1.StSalesAreaCode == custSalesDistributionReportParam2.StSalesAreaCode)
				 && (custSalesDistributionReportParam1.EdSalesAreaCode == custSalesDistributionReportParam2.EdSalesAreaCode)
				 && (custSalesDistributionReportParam1.StCustomerCode == custSalesDistributionReportParam2.StCustomerCode)
				 && (custSalesDistributionReportParam1.EdCustomerCode == custSalesDistributionReportParam2.EdCustomerCode)
				 && (custSalesDistributionReportParam1.PrintType == custSalesDistributionReportParam2.PrintType)
				 && (custSalesDistributionReportParam1.SearchDiv == custSalesDistributionReportParam2.SearchDiv)
				 && (custSalesDistributionReportParam1.EnterpriseName == custSalesDistributionReportParam2.EnterpriseName)
                 && (custSalesDistributionReportParam1.IsOptSection == custSalesDistributionReportParam2.IsOptSection)
                 && (custSalesDistributionReportParam1.IsSelectAllSection == custSalesDistributionReportParam2.IsSelectAllSection)
                 && (custSalesDistributionReportParam1.RankSection == custSalesDistributionReportParam2.RankSection)
                 && (custSalesDistributionReportParam1.RankHighLow == custSalesDistributionReportParam2.RankHighLow)
                 && (custSalesDistributionReportParam1.RankOrderMax == custSalesDistributionReportParam2.RankOrderMax)
                 && (custSalesDistributionReportParam1.RankStandard == custSalesDistributionReportParam2.RankStandard)
                 && (custSalesDistributionReportParam1.PrintOrder == custSalesDistributionReportParam2.PrintOrder)
                 && (custSalesDistributionReportParam1.NewPageDiv == custSalesDistributionReportParam2.NewPageDiv)
                 && (custSalesDistributionReportParam1.StartDate == custSalesDistributionReportParam2.StartDate)

                 );
		}
		/// <summary>
		/// 得意先別取引分布表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCustSalesDistributionReportParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustSalesDistributionReportParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(CustSalesDistributionReportParam target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.StSalesDate != target.StSalesDate)resList.Add("StSalesDate");
			if(this.EdSalesDate != target.EdSalesDate)resList.Add("EdSalesDate");
			if(this.StSalesEmployeeCd != target.StSalesEmployeeCd)resList.Add("StSalesEmployeeCd");
			if(this.EdSalesEmployeeCd != target.EdSalesEmployeeCd)resList.Add("EdSalesEmployeeCd");
			if(this.StSalesAreaCode != target.StSalesAreaCode)resList.Add("StSalesAreaCode");
			if(this.EdSalesAreaCode != target.EdSalesAreaCode)resList.Add("EdSalesAreaCode");
			if(this.StCustomerCode != target.StCustomerCode)resList.Add("StCustomerCode");
			if(this.EdCustomerCode != target.EdCustomerCode)resList.Add("EdCustomerCode");
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
			if(this.SearchDiv != target.SearchDiv)resList.Add("SearchDiv");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.RankSection != target.RankSection) resList.Add("RankSection");
            if (this.RankHighLow != target.RankHighLow) resList.Add("RankHighLow");
            if (this.RankOrderMax != target.RankOrderMax) resList.Add("RankOrderMax");
            if (this.RankStandard != target.RankStandard) resList.Add("RankStandard");
            if (this.PrintOrder != target.PrintOrder) resList.Add("PrintOrder");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.StartDate != target.StartDate) resList.Add("StartDate");


			return resList;
		}

		/// <summary>
		/// 得意先別取引分布表抽出条件クラス比較処理
		/// </summary>
		/// <param name="custSalesDistributionReportParam1">比較するCustSalesDistributionReportParamクラスのインスタンス</param>
		/// <param name="custSalesDistributionReportParam2">比較するCustSalesDistributionReportParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustSalesDistributionReportParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(CustSalesDistributionReportParam custSalesDistributionReportParam1, CustSalesDistributionReportParam custSalesDistributionReportParam2)
		{
			ArrayList resList = new ArrayList();
			if(custSalesDistributionReportParam1.EnterpriseCode != custSalesDistributionReportParam2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(custSalesDistributionReportParam1.SectionCode != custSalesDistributionReportParam2.SectionCode)resList.Add("SectionCode");
			if(custSalesDistributionReportParam1.StSalesDate != custSalesDistributionReportParam2.StSalesDate)resList.Add("StSalesDate");
			if(custSalesDistributionReportParam1.EdSalesDate != custSalesDistributionReportParam2.EdSalesDate)resList.Add("EdSalesDate");
			if(custSalesDistributionReportParam1.StSalesEmployeeCd != custSalesDistributionReportParam2.StSalesEmployeeCd)resList.Add("StSalesEmployeeCd");
			if(custSalesDistributionReportParam1.EdSalesEmployeeCd != custSalesDistributionReportParam2.EdSalesEmployeeCd)resList.Add("EdSalesEmployeeCd");
			if(custSalesDistributionReportParam1.StSalesAreaCode != custSalesDistributionReportParam2.StSalesAreaCode)resList.Add("StSalesAreaCode");
			if(custSalesDistributionReportParam1.EdSalesAreaCode != custSalesDistributionReportParam2.EdSalesAreaCode)resList.Add("EdSalesAreaCode");
			if(custSalesDistributionReportParam1.StCustomerCode != custSalesDistributionReportParam2.StCustomerCode)resList.Add("StCustomerCode");
			if(custSalesDistributionReportParam1.EdCustomerCode != custSalesDistributionReportParam2.EdCustomerCode)resList.Add("EdCustomerCode");
            if (custSalesDistributionReportParam1.PrintType != custSalesDistributionReportParam2.PrintType) resList.Add("PrintType");
			if(custSalesDistributionReportParam1.SearchDiv != custSalesDistributionReportParam2.SearchDiv)resList.Add("SearchDiv");
			if(custSalesDistributionReportParam1.EnterpriseName != custSalesDistributionReportParam2.EnterpriseName)resList.Add("EnterpriseName");
            if (custSalesDistributionReportParam1.IsOptSection != custSalesDistributionReportParam2.IsOptSection) resList.Add("IsOptSection");
            if (custSalesDistributionReportParam1.IsSelectAllSection != custSalesDistributionReportParam2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (custSalesDistributionReportParam1.RankSection != custSalesDistributionReportParam2.RankSection) resList.Add("RankSection");
            if (custSalesDistributionReportParam1.RankHighLow != custSalesDistributionReportParam2.RankHighLow) resList.Add("RankHighLow");
            if (custSalesDistributionReportParam1.RankOrderMax != custSalesDistributionReportParam2.RankOrderMax) resList.Add("RankOrderMax");
            if (custSalesDistributionReportParam1.RankStandard != custSalesDistributionReportParam2.RankStandard) resList.Add("RankStandard");
            if (custSalesDistributionReportParam1.PrintOrder != custSalesDistributionReportParam2.PrintOrder) resList.Add("PrintOrder");
            if (custSalesDistributionReportParam1.NewPageDiv != custSalesDistributionReportParam2.NewPageDiv) resList.Add("NewPageDiv");
            if (custSalesDistributionReportParam1.StartDate != custSalesDistributionReportParam2.StartDate) resList.Add("StartDate"); 

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
        /// 順位付設定単位　プロパティ
        /// </summary>
        public string RankSectionStateTitle
        {
            get
            {
                switch (this._rankSection)
                {
                    case RankSectionState.All: return ct_RankSectionState_All;
                    case RankSectionState.Section: return ct_RankSectionState_Section;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 順位付設定 上位・下位　プロパティ
        /// </summary>
        public string RankHighLowStateTitle
        {
            get
            {
                switch (this._rankHighLow)
                {
                    case RankHighLowState.High: return ct_RankHighLowState_High;
                    case RankHighLowState.Low: return ct_RankHighLowState_Low;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 順位指定　プロパティ
        /// </summary>
        public string RankStandardStateTitle
        {
            get
            {
                switch (this._rankStandard)
                {
                    case RankStandardState.Sales: return ct_RankStandardState_Sales;
                    case RankStandardState.Gross: return ct_RankStandardState_Gross;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 印刷順　プロパティ
        /// </summary>
        public string PrintOrderStateTitle
        {
            get
            {
                switch (this._printOrder)
                {
                    case PrintOrderState.Code: return ct_PrintOrderState_Code;
                    case PrintOrderState.Order: return ct_PrintOrderState_Order;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 発行タイプ　プロパティ
        /// </summary>
        public string PrintTypeStateTitle
        {
            get
            {
                switch (this._printType)
                {
                    case PrintTypeState.Customer: return ct_PrintTypeState_Customer;
                    case PrintTypeState.Employee: return ct_PrintTypeState_Employee;
                    case PrintTypeState.Area: return ct_PrintTypeState_Area;
                    default: return "";
                }
            }
        }
        #endregion

        #region ■列挙体

        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>拠点毎</summary>
            Section = 0,
            /// <summary>しない</summary>
            None = 1,
        }

        /// <summary>
        /// 順位付設定単位　列挙体
        /// </summary>
        public enum RankSectionState
        {
            /// <summary>全拠点</summary>
            All = 0,
            /// <summary>拠点毎</summary>
            Section = 1,
        }

        /// <summary>
        /// 順位付設定上位下位　列挙体
        /// </summary>
        public enum RankHighLowState
        {
            /// <summary>上位</summary>
            High = 0,
            /// <summary>下位</summary>
            Low = 1,
        }

        /// <summary>
        /// 順位指定 列挙体
        /// </summary>
        public enum RankStandardState
        {
            /// <summary>純売上</summary>
            Sales = 0,
            /// <summary>粗利</summary>
            Gross = 1,
        }

        /// <summary>
        /// 印刷順 列挙体
        /// </summary>
        public enum PrintOrderState
        {
            /// <summary>コード</summary>
            Code = 0,
            /// <summary>順位</summary>
            Order = 1,
        }

        /// <summary>
        /// 発行タイプ 列挙体
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>得意先</summary>
            Customer = 0,
            /// <summary>担当者</summary>
            Employee = 1,
            /// <summary>地区</summary>
            Area = 2,
        }
        #endregion

        #region ■項目名称

        /// <summary>改ページ区分 拠点毎</summary>
        private const string ct_NewPageDivState_Section = "拠点単位";
        /// <summary>改ページ区分 しない</summary>
        private const string ct_NewPageDivState_None = "しない";

        /// <summary>順位付設定単位 全拠点</summary>
        private const string ct_RankSectionState_All = "全拠点で";
        /// <summary>順位付設定単位 拠点毎</summary>
        private const string ct_RankSectionState_Section = "拠点毎で";

        /// <summary>順位付設定上位下位 上位</summary>
        private const string ct_RankHighLowState_High = "上位";
        /// <summary>順位付設定上位下位 下位</summary>
        private const string ct_RankHighLowState_Low = "下位";

        /// <summary>順位指定 純売上</summary>
        private const string ct_RankStandardState_Sales = "純売上";
        /// <summary>順位指定 粗利</summary>
        private const string ct_RankStandardState_Gross = "粗利";

        /// <summary>印刷順 コード</summary>
        private const string ct_PrintOrderState_Code = "コード";
        /// <summary>印刷順 順位</summary>
        private const string ct_PrintOrderState_Order = "順位";

        /// <summary>発行タイプ 得意先</summary>
        private const string ct_PrintTypeState_Customer = "得意先";
        /// <summary>発行タイプ 担当者</summary>
        private const string ct_PrintTypeState_Employee = "担当者";
        /// <summary>発行タイプ 地区</summary>
        private const string ct_PrintTypeState_Area = "地区";
        #endregion
	}
}
