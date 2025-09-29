using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SlipHistAnalyzeParam
	/// <summary>
	///                      仕入分析表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入分析表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SlipHistAnalyzeParam
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定はnull</remarks>
		private string[] _sectionCodes;

		/// <summary>開始計上年月(当月)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAddUpYearMonth;

		/// <summary>終了計上年月(当月)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAddUpYearMonth;

		/// <summary>開始計上年月(当期)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAnnualAddUpYearMonth;

		/// <summary>終了計上年月(当期)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAnnualAddUpYearMonth;

		/// <summary>開始仕入先コード</summary>
		private Int32 _stSupplierCd;

		/// <summary>終了仕入先コード</summary>
		private Int32 _edSupplierCd;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // 自動生成以外
        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;

        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;

        /// <summary>構成比単位</summary>
        private ConstUnitDivState _constUnitDiv;

        /// <summary>金額単位</summary>
        private MoneyUnitDivState _moneyUnitDiv;

        /// <summary>改頁単位</summary>
        private NewPageDivState _newPageDiv;

        /// <summary>発行タイプ</summary>
        private PrintTypeState _printType;

        /// <summary>印刷タイプ</summary>
        private PrintTermTypeState _printTermType;


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
		/// <value>(配列)　全社指定はnull</value>
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

		/// public propaty name  :  StAddUpYearMonth
		/// <summary>開始計上年月(当月)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上年月(当月)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StAddUpYearMonth
		{
			get{return _stAddUpYearMonth;}
			set{_stAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAddUpYearMonth
		/// <summary>終了計上年月(当月)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上年月(当月)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdAddUpYearMonth
		{
			get{return _edAddUpYearMonth;}
			set{_edAddUpYearMonth = value;}
		}

		/// public propaty name  :  StAnnualAddUpYearMonth
		/// <summary>開始計上年月(当期)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上年月(当期)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StAnnualAddUpYearMonth
		{
			get{return _stAnnualAddUpYearMonth;}
			set{_stAnnualAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAnnualAddUpYearMonth
		/// <summary>終了計上年月(当期)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上年月(当期)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdAnnualAddUpYearMonth
		{
			get{return _edAnnualAddUpYearMonth;}
			set{_edAnnualAddUpYearMonth = value;}
		}

		/// public propaty name  :  StSupplierCd
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StSupplierCd
		{
			get{return _stSupplierCd;}
			set{_stSupplierCd = value;}
		}

		/// public propaty name  :  EdSupplierCd
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdSupplierCd
		{
			get{return _edSupplierCd;}
			set{_edSupplierCd = value;}
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
		/// 仕入分析表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>SlipHistAnalyzeParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipHistAnalyzeParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SlipHistAnalyzeParam()
		{
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
        /// 構成比単位プロパティ
        /// </summary>
        public ConstUnitDivState ConstUnitDiv
        {
            get { return this._constUnitDiv; }
            set { this._constUnitDiv = value; }
        }

        /// <summary>
        /// 金額単位プロパティ
        /// </summary>
        public MoneyUnitDivState MoneyUnitDiv
        {
            get { return this._moneyUnitDiv; }
            set { this._moneyUnitDiv = value; }
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
        /// 発行タイププロパティ
        /// </summary>
        public PrintTypeState PrintType
        {
            get { return this._printType; }
            set { this._printType = value; }
        }

        /// <summary>
        /// 印刷タイププロパティ
        /// </summary>
        public PrintTermTypeState PrintTermType
        {
            get { return this._printTermType; }
            set { this._printTermType = value; }
        }

		/// <summary>
		/// 仕入分析表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCodes">拠点コード((配列)　全社指定はnull)</param>
		/// <param name="stAddUpYearMonth">開始計上年月(当月)(YYYYMM)</param>
		/// <param name="edAddUpYearMonth">終了計上年月(当月)(YYYYMM)</param>
		/// <param name="stAnnualAddUpYearMonth">開始計上年月(当期)(YYYYMM)</param>
		/// <param name="edAnnualAddUpYearMonth">終了計上年月(当期)(YYYYMM)</param>
		/// <param name="stSupplierCd">開始仕入先コード</param>
		/// <param name="edSupplierCd">終了仕入先コード</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>SlipHistAnalyzeParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipHistAnalyzeParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SlipHistAnalyzeParam(string enterpriseCode, string[] sectionCodes,Int32 stAddUpYearMonth,Int32 edAddUpYearMonth,Int32 stAnnualAddUpYearMonth,Int32 edAnnualAddUpYearMonth,Int32 stSupplierCd,Int32 edSupplierCd,string enterpriseName,
            bool isOptSection, bool isSelectAllSection, ConstUnitDivState constUnitDiv, MoneyUnitDivState moneyUnitDiv, NewPageDivState newPageDiv, PrintTypeState printType, PrintTermTypeState printTermType)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
			this._stAddUpYearMonth = stAddUpYearMonth;
			this._edAddUpYearMonth = edAddUpYearMonth;
			this._stAnnualAddUpYearMonth = stAnnualAddUpYearMonth;
			this._edAnnualAddUpYearMonth = edAnnualAddUpYearMonth;
			this._stSupplierCd = stSupplierCd;
			this._edSupplierCd = edSupplierCd;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._constUnitDiv = constUnitDiv;
            this._moneyUnitDiv = moneyUnitDiv;
            this._newPageDiv = newPageDiv;
            this._printType = printType;
            this._printTermType = printTermType;
		}

		/// <summary>
		/// 仕入分析表抽出条件クラス複製処理
		/// </summary>
		/// <returns>SlipHistAnalyzeParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSlipHistAnalyzeParamクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SlipHistAnalyzeParam Clone()
		{
			return new SlipHistAnalyzeParam(this._enterpriseCode,this._sectionCodes,this._stAddUpYearMonth,this._edAddUpYearMonth,this._stAnnualAddUpYearMonth,this._edAnnualAddUpYearMonth,this._stSupplierCd,this._edSupplierCd,this._enterpriseName,
                this._isOptSection, this._isSelectAllSection, this._constUnitDiv, this._moneyUnitDiv, this._newPageDiv, this._printType, this._printTermType);
		}

		/// <summary>
		/// 仕入分析表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSlipHistAnalyzeParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipHistAnalyzeParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public bool Equals(SlipHistAnalyzeParam target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCodes == target.SectionCodes)
                 && (this.StAddUpYearMonth == target.StAddUpYearMonth)
                 && (this.EdAddUpYearMonth == target.EdAddUpYearMonth)
                 && (this.StAnnualAddUpYearMonth == target.StAnnualAddUpYearMonth)
                 && (this.EdAnnualAddUpYearMonth == target.EdAnnualAddUpYearMonth)
                 && (this.StSupplierCd == target.StSupplierCd)
                 && (this.EdSupplierCd == target.EdSupplierCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.ConstUnitDiv == target.ConstUnitDiv)
                 && (this.MoneyUnitDiv == target.MoneyUnitDiv)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.PrintType == target.PrintType)
                 && (this.PrintTermType == target.PrintTermType)
                 );
        }

		/// <summary>
		/// 仕入分析表抽出条件クラス比較処理
		/// </summary>
		/// <param name="slipHistAnalyzeParam1">
		///                    比較するSlipHistAnalyzeParamクラスのインスタンス
		/// </param>
		/// <param name="slipHistAnalyzeParam2">比較するSlipHistAnalyzeParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipHistAnalyzeParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SlipHistAnalyzeParam slipHistAnalyzeParam1, SlipHistAnalyzeParam slipHistAnalyzeParam2)
		{
			return ((slipHistAnalyzeParam1.EnterpriseCode == slipHistAnalyzeParam2.EnterpriseCode)
				 && (slipHistAnalyzeParam1.SectionCodes == slipHistAnalyzeParam2.SectionCodes)
				 && (slipHistAnalyzeParam1.StAddUpYearMonth == slipHistAnalyzeParam2.StAddUpYearMonth)
				 && (slipHistAnalyzeParam1.EdAddUpYearMonth == slipHistAnalyzeParam2.EdAddUpYearMonth)
				 && (slipHistAnalyzeParam1.StAnnualAddUpYearMonth == slipHistAnalyzeParam2.StAnnualAddUpYearMonth)
				 && (slipHistAnalyzeParam1.EdAnnualAddUpYearMonth == slipHistAnalyzeParam2.EdAnnualAddUpYearMonth)
				 && (slipHistAnalyzeParam1.StSupplierCd == slipHistAnalyzeParam2.StSupplierCd)
				 && (slipHistAnalyzeParam1.EdSupplierCd == slipHistAnalyzeParam2.EdSupplierCd)
				 && (slipHistAnalyzeParam1.EnterpriseName == slipHistAnalyzeParam2.EnterpriseName)
                 && (slipHistAnalyzeParam1.IsOptSection == slipHistAnalyzeParam2.IsOptSection)
                 && (slipHistAnalyzeParam1.IsSelectAllSection == slipHistAnalyzeParam2.IsSelectAllSection)
                 && (slipHistAnalyzeParam1.ConstUnitDiv == slipHistAnalyzeParam2.ConstUnitDiv)
                 && (slipHistAnalyzeParam1.MoneyUnitDiv == slipHistAnalyzeParam2.MoneyUnitDiv)
                 && (slipHistAnalyzeParam1.NewPageDiv == slipHistAnalyzeParam2.NewPageDiv)
                 && (slipHistAnalyzeParam1.PrintType == slipHistAnalyzeParam2.PrintType)
                 && (slipHistAnalyzeParam1.PrintTermType == slipHistAnalyzeParam2.PrintTermType)
                 );
		}
		/// <summary>
		/// 仕入分析表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSlipHistAnalyzeParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipHistAnalyzeParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SlipHistAnalyzeParam target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.StAddUpYearMonth != target.StAddUpYearMonth)resList.Add("StAddUpYearMonth");
			if(this.EdAddUpYearMonth != target.EdAddUpYearMonth)resList.Add("EdAddUpYearMonth");
			if(this.StAnnualAddUpYearMonth != target.StAnnualAddUpYearMonth)resList.Add("StAnnualAddUpYearMonth");
			if(this.EdAnnualAddUpYearMonth != target.EdAnnualAddUpYearMonth)resList.Add("EdAnnualAddUpYearMonth");
			if(this.StSupplierCd != target.StSupplierCd)resList.Add("StSupplierCd");
			if(this.EdSupplierCd != target.EdSupplierCd)resList.Add("EdSupplierCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.ConstUnitDiv != target.ConstUnitDiv) resList.Add("ConstUnitDiv");
            if (this.MoneyUnitDiv != target.MoneyUnitDiv) resList.Add("MoneyUnitDiv");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
            if (this.PrintTermType != target.PrintTermType) resList.Add("PrintTermType");
			return resList;
		}

		/// <summary>
		/// 仕入分析表抽出条件クラス比較処理
		/// </summary>
		/// <param name="slipHistAnalyzeParam1">比較するSlipHistAnalyzeParamクラスのインスタンス</param>
		/// <param name="slipHistAnalyzeParam2">比較するSlipHistAnalyzeParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipHistAnalyzeParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SlipHistAnalyzeParam slipHistAnalyzeParam1, SlipHistAnalyzeParam slipHistAnalyzeParam2)
		{
			ArrayList resList = new ArrayList();
			if(slipHistAnalyzeParam1.EnterpriseCode != slipHistAnalyzeParam2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(slipHistAnalyzeParam1.SectionCodes != slipHistAnalyzeParam2.SectionCodes)resList.Add("SectionCodes");
			if(slipHistAnalyzeParam1.StAddUpYearMonth != slipHistAnalyzeParam2.StAddUpYearMonth)resList.Add("StAddUpYearMonth");
			if(slipHistAnalyzeParam1.EdAddUpYearMonth != slipHistAnalyzeParam2.EdAddUpYearMonth)resList.Add("EdAddUpYearMonth");
			if(slipHistAnalyzeParam1.StAnnualAddUpYearMonth != slipHistAnalyzeParam2.StAnnualAddUpYearMonth)resList.Add("StAnnualAddUpYearMonth");
			if(slipHistAnalyzeParam1.EdAnnualAddUpYearMonth != slipHistAnalyzeParam2.EdAnnualAddUpYearMonth)resList.Add("EdAnnualAddUpYearMonth");
			if(slipHistAnalyzeParam1.StSupplierCd != slipHistAnalyzeParam2.StSupplierCd)resList.Add("StSupplierCd");
			if(slipHistAnalyzeParam1.EdSupplierCd != slipHistAnalyzeParam2.EdSupplierCd)resList.Add("EdSupplierCd");
			if(slipHistAnalyzeParam1.EnterpriseName != slipHistAnalyzeParam2.EnterpriseName)resList.Add("EnterpriseName");
            if (slipHistAnalyzeParam1.IsOptSection != slipHistAnalyzeParam2.IsOptSection) resList.Add("IsOptSection");
            if (slipHistAnalyzeParam1.IsSelectAllSection != slipHistAnalyzeParam2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (slipHistAnalyzeParam1.ConstUnitDiv != slipHistAnalyzeParam2.ConstUnitDiv) resList.Add("ConstUnitDiv");
            if (slipHistAnalyzeParam1.MoneyUnitDiv != slipHistAnalyzeParam2.MoneyUnitDiv) resList.Add("MoneyUnitDiv");
            if (slipHistAnalyzeParam1.NewPageDiv != slipHistAnalyzeParam2.NewPageDiv) resList.Add("NewPageDiv");
            if (slipHistAnalyzeParam1.PrintType != slipHistAnalyzeParam2.PrintType) resList.Add("PrintType");
            if (slipHistAnalyzeParam1.PrintTermType != slipHistAnalyzeParam2.PrintTermType) resList.Add("PrintTermType");

			return resList;
		}

        #region ■項目名称プロパティ
        /// <summary>
        /// 構成比単位タイトル　プロパティ
        /// </summary>
        public string ConstUnitDivStateTitle
        {
            get
            {
                switch (this._constUnitDiv)
                {
                    case ConstUnitDivState.Total: return ct_ConstUnitDivState_Total;
                    case ConstUnitDivState.SubTotal: return ct_ConstUnitDivState_SubTotal;

                    default: return "";
                }
            }
        }

        /// <summary>
        /// 金額単位タイトル　プロパティ
        /// </summary>
        public string MoneyUnitDivStateTitle
        {
            get
            {
                switch (this._moneyUnitDiv)
                {
                    case MoneyUnitDivState.One: return ct_MoneyUnitDivState_One;
                    case MoneyUnitDivState.Thousand: return ct_MoneyUnitDivState_Thousand;

                    default: return "";
                }
            }
        }

        /// <summary>
        /// 発行タイプタイトル　プロパティ
        /// </summary>
        public string PrintTypeStateTitle
        {
            get
            {
                switch (this._printType)
                {
                    case PrintTypeState.Section: return ct_PrintTypeState_Section;
                    case PrintTypeState.Supplier: return ct_PrintTypeState_Supplier;

                    default: return "";
                }
            }
        }

        /// <summary>
        /// 印刷タイプタイトル　プロパティ
        /// </summary>
        public string PrintTermTypeStateTitle
        {
            get
            {
                switch (this._printTermType)
                {
                    case PrintTermTypeState.MonthAndTerm: return ct_PrintTermType_MonthAndTerm;
                    case PrintTermTypeState.Month: return ct_PrintTermType_Month;
                    case PrintTermTypeState.Term: return ct_PrintTermType_Term;

                    default: return "";
                }
            }
        }

        #endregion

        #region ■列挙体

        /// <summary>
        /// 構成比単位　列挙体
        /// </summary>
        public enum ConstUnitDivState
        {
            /// <summary>総合計</summary>
            Total = 0,
            /// <summary>合計</summary>
            SubTotal = 1,
        }

        /// <summary>
        /// 金額単位　列挙体
        /// </summary>
        public enum MoneyUnitDivState
        {
            /// <summary>円</summary>
            One = 0,
            /// <summary>千円</summary>
            Thousand = 1,
        }

        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>する</summary>
            Do = 0,
            /// <summary>しない</summary>
            None = 1,
        }

        /// <summary>
        /// 発行タイプ 列挙体
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>拠点毎</summary>
            Section = 0,
            /// <summary>仕入先毎</summary>
            Supplier = 1,
        }

        /// <summary>
        /// 印刷タイプ 列挙体
        /// </summary>
        public enum PrintTermTypeState
        {
            /// <summary>当月＆当期</summary>
            MonthAndTerm = 0,
            /// <summary>当月</summary>
            Month = 1,
            /// <summary>当期</summary>
            Term = 2,

        }
        #endregion

        #region ■項目名称

        /// <summary>構成比単位 総合計</summary>
        private const string ct_ConstUnitDivState_Total = "総合計";
        /// <summary>構成比単位 小計</summary>
        private const string ct_ConstUnitDivState_SubTotal = "小計";

        /// <summary>金額単位 円</summary>
        private const string ct_MoneyUnitDivState_One = "円";
        /// <summary>金額単位 千円</summary>
        private const string ct_MoneyUnitDivState_Thousand = "千円";

        /// <summary>発行タイプ　拠点毎</summary>
        private const string ct_PrintTypeState_Section = "拠点毎";
        /// <summary>発行タイプ　仕入先毎</summary>
        private const string ct_PrintTypeState_Supplier = "仕入先毎";

        /// <summary>印刷タイプ　当月＆当期</summary>
        private const string ct_PrintTermType_MonthAndTerm = "当月＆当期";
        /// <summary>印刷タイプ　当月</summary>
        private const string ct_PrintTermType_Month = "当月";
        /// <summary>印刷タイプ　当期</summary>
        private const string ct_PrintTermType_Term = "当期";

        #endregion
	}
}
