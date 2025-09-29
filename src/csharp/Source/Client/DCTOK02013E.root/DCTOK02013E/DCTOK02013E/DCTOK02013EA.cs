using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesDayMonthReport
	/// <summary>
	///                      売上日報月報抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上日報月報抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/11/16  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2012/12/28 zhuhh </br>
    /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
    /// <br>Date	         :   redmine #34098 罫線印字制御の追加</br>
	/// </remarks>
	public class SalesDayMonthReport
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>文字型　※配列項目</remarks>
		private string[] _sectionCodes;

        /// <summary>集計単位</summary>
        /// <remarks>0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業種別 6:販売区分別</remarks>
        private Int32 _totalType;

		/// <summary>集計方法</summary>
		/// <remarks>0:全社 1:営業所毎</remarks>
		private Int32 _ttlType;

        /// <summary>出力順</summary>
        /// <remarks>※出力順について参照</remarks>
        private Int32 _outType;

        /// <summary>開始対象日付(期間)</summary>
        /// <remarks>計上年月(YYYYMMDD)</remarks>
        private DateTime _salesDateSt;

        /// <summary>終了対象日付(期間)</summary>
        /// <remarks>計上年月(YYYYMMDD)</remarks>
        private DateTime _salesDateEd;

        /// <summary>開始対象日付(当月)</summary>
        /// <remarks>前月締日の翌日(YYYYMMDD)</remarks>
        private DateTime _monthReportDateSt;

        /// <summary>終了対象日付(当月)</summary>
        /// <remarks>計上年月(YYYYMMDD)</remarks>
        private DateTime _monthReportDateEd;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private Int32 _customerCodeEd;

        /// <summary>開始検索コード</summary>
        /// <remarks>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</remarks>
        private string _srchCodeSt = "";

        /// <summary>終了検索コード</summary>
        /// <remarks>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</remarks>
        private string _srchCodeEd = "";

        /// <summary>開始対象年月(目標期間)</summary>
        /// <remarks>年月度(YYYYMM)</remarks>
        private DateTime _targetYearMonthSt;

        /// <summary>終了対象年月(目標期間)</summary>
        /// <remarks>年月度(YYYYMM)</remarks>
        private DateTime _targetYearMonthEd;

        /// <summary>金額単位</summary>
		/// <remarks>0:円 1:千円</remarks>
		private Int32 _moneyUnit;

        /// <summary>日計なし印刷</summary>
        /// <remarks>0:あり 1:なし</remarks>
        private Int32 _daySumPrtDiv;

		/// <summary>改頁</summary>
		/// <remarks>0:なし 1:あり</remarks>
		private Int32 _crMode;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
        /// <summary>罫線印字</summary>
        private Int32 _lineMaSqOfChDiv;
        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

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

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コードプロパティ</summary>
		/// <value>文字型　※配列項目</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get { return _sectionCodes; }
			set { _sectionCodes = value; }
		}

        /// public propaty name  :  TotalType
        /// <summary>集計単位プロパティ</summary>
        /// <value>0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業種別 6:販売区分別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalType
        {
            get { return _totalType; }
            set { _totalType = value; }
        }

		/// public propaty name  :  TtlType
		/// <summary>集計方法プロパティ</summary>
		/// <value>0:全社 1:営業所毎</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TtlType
		{
			get { return _ttlType; }
			set { _ttlType = value; }
		}

        /// public propaty name  :  OutType
        /// <summary>出力順プロパティ</summary>
        /// <value>※出力順について参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutType
        {
            get { return _outType; }
            set { _outType = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>開始対象日付(期間)プロパティ</summary>
        /// <value>計上年月(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日付(期間)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>終了対象日付(期間)プロパティ</summary>
        /// <value>計上年月(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日付(期間)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  MonthReportDateSt
        /// <summary>開始対象日付(当月)プロパティ</summary>
        /// <value>前月締日の翌日(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日付(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MonthReportDateSt
        {
            get { return _monthReportDateSt; }
            set { _monthReportDateSt = value; }
        }

        /// public propaty name  :  MonthReportDateEd
        /// <summary>終了対象日付(当月)プロパティ</summary>
        /// <value>計上年月(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日付(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MonthReportDateEd
        {
            get { return _monthReportDateEd; }
            set { _monthReportDateEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  SrchCodeSt
        /// <summary>開始検索コードプロパティ</summary>
        /// <value>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始検索コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SrchCodeSt
        {
            get { return _srchCodeSt; }
            set { _srchCodeSt = value; }
        }

        /// public propaty name  :  SrchCodeEd
        /// <summary>終了検索コードプロパティ</summary>
        /// <value>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了検索コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SrchCodeEd
        {
            get { return _srchCodeEd; }
            set { _srchCodeEd = value; }
        }

        /// public propaty name  :  TargetYearMonthSt
        /// <summary>開始対象年月(目標期間)プロパティ</summary>
        /// <value>年月度(YYYYMM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日付(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TargetYearMonthSt
        {
            get { return _targetYearMonthSt; }
            set { _targetYearMonthSt = value; }
        }

        /// public propaty name  :  TargetYearMonthEd
        /// <summary>終了対象年月(目標期間)プロパティ</summary>
        /// <value>年月度(YYYYMM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日付(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TargetYearMonthEd
        {
            get { return _targetYearMonthEd; }
            set { _targetYearMonthEd = value; }
        }

		/// public propaty name  :  MoneyUnit
		/// <summary>金額単位プロパティ</summary>
		/// <value>0:円 1:千円</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   金額単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MoneyUnit
		{
			get { return _moneyUnit; }
			set { _moneyUnit = value; }
		}

        /// public propaty name  :  DaySumPrtDiv
        /// <summary>日計無し印刷プロパティ</summary>
        /// <value>0:あり 1:なし</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日計無し印刷プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DaySumPrtDiv
        {
            get { return _daySumPrtDiv; }
            set { _daySumPrtDiv = value; }
        }

		/// public propaty name  :  CrMode
		/// <summary>改頁プロパティ</summary>
		/// <value>0:なし 1:あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改頁プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CrMode
		{
			get { return _crMode; }
			set { _crMode = value; }
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

        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
        /// public propaty name :  LineMaSqOfChDiv
        /// <summary>罫線印字プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   罫線印字プロパティ</br>
        /// <br>Programer        :   zhuhh</br>
        /// <br>Date	         :   2012/12/28</br>
        /// </remarks>
        public Int32 LineMaSqOfChDiv
        {
            get { return _lineMaSqOfChDiv; }
            set { _lineMaSqOfChDiv = value; }
        }
        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

		/// <summary>
		/// 売上日報月報抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>SalesDayMonthReportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesDayMonthReportクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesDayMonthReport()
		{
		}

		/// <summary>
		/// 売上日報月報抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCodes">拠点コード(文字型　※配列項目)</param>
        /// <param name="totalType">集計単位(0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業種別 6:販売区分別)</param>
        /// <param name="ttlType">集計方法(0:全社 1:拠点毎)</param>
        /// <param name="outType">出力順(※出力順について参照)</param>
        /// <param name="salesDateSt">開始対象日付(期間)(計上年月(YYYYMMDD))</param>
        /// <param name="salesDateEd">終了対象日付(期間)(計上年月(YYYYMMDD))</param>
        /// <param name="monthReportDateSt">開始対象日付(当月)(前月締日の翌日(YYYYMMDD))</param>
        /// <param name="monthReportDateEd">終了対象日付(当月)(計上年月(YYYYMMDD))</param>
        /// <param name="customerCodeSt">開始得意先コード</param>
        /// <param name="customerCodeEd">終了得意先コード</param>
        /// <param name="srchCodeSt">開始検索コード(XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分))</param>
        /// <param name="srchCodeEd">終了検索コード(XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分))</param>
        /// <param name="targetYearMonthSt">終了対象年月(目標期間)(年月度(YYYYMM))</param>
        /// <param name="targetYearMonthEd">終了対象年月(目標期間)(年月度(YYYYMM))</param>
        /// <param name="moneyUnit">金額単位(0:円 1:千円)</param>
        /// <param name="daySumPrtDiv">日計なし印刷(0:あり 1:なし)</param>
        /// <param name="crMode">改頁(0:なし 1:あり)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>SalesDayMonthReportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesDayMonthReportクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SalesDayMonthReport(string enterpriseCode, string[] sectionCodes, Int32 totalType, Int32 ttlType, Int32 outType, DateTime salesDateSt, DateTime salesDateEd, DateTime monthReportDateSt, DateTime monthReportDateEd, Int32 customerCodeSt, Int32 customerCodeEd, string srchCodeSt, string srchCodeEd, DateTime targetYearMonthSt, DateTime targetYearMonthEd, Int32 moneyUnit, Int32 daySumPrtDiv, Int32 crMode, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
            this._totalType = totalType;
            this._ttlType = ttlType;
            this._outType = outType;
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._monthReportDateSt = monthReportDateSt;
            this._monthReportDateEd = monthReportDateEd;
            this._customerCodeSt = customerCodeSt;
            this._customerCodeEd = customerCodeEd;
            this._srchCodeSt = srchCodeSt;
            this._srchCodeEd = srchCodeEd;
            this._targetYearMonthSt = targetYearMonthSt;
            this._targetYearMonthEd = targetYearMonthEd;
            this._moneyUnit = moneyUnit;
            this._daySumPrtDiv = daySumPrtDiv;
			this._crMode = crMode;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 売上日報月報抽出条件クラス複製処理
		/// </summary>
		/// <returns>SalesDayMonthReportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSalesDayMonthReportクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesDayMonthReport Clone()
		{
            return new SalesDayMonthReport(this._enterpriseCode, this._sectionCodes, this._totalType, this._ttlType, this._outType, this._salesDateSt, this._salesDateEd, this._monthReportDateSt, this._monthReportDateEd, this._customerCodeSt, this._customerCodeEd, this._srchCodeSt, this._srchCodeEd, this._targetYearMonthSt, this._targetYearMonthEd, this._moneyUnit, this._daySumPrtDiv, this._crMode, this._enterpriseName);
		}

		/// <summary>
		/// 売上日報月報抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesDayMonthReportクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesDayMonthReportクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SalesDayMonthReport target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
                 && (this.TotalType == target.TotalType)
                 && (this.TtlType == target.TtlType)
                 && (this.OutType == target.OutType)
                 && (this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.MonthReportDateSt == target.MonthReportDateSt)
                 && (this.MonthReportDateEd == target.MonthReportDateEd)
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
                 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 && (this.SrchCodeSt == target.SrchCodeSt)
                 && (this.SrchCodeEd == target.SrchCodeEd)
                 && (this.TargetYearMonthSt == target.TargetYearMonthSt)
                 && (this.TargetYearMonthEd == target.TargetYearMonthEd)
                 && (this.MoneyUnit == target.MoneyUnit)
                 && (this.DaySumPrtDiv == target.DaySumPrtDiv)
				 && (this.CrMode == target.CrMode)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 売上日報月報抽出条件クラス比較処理
		/// </summary>
		/// <param name="salesDayMonthReport1">
		///                    比較するSalesDayMonthReportクラスのインスタンス
		/// </param>
		/// <param name="salesDayMonthReport2">比較するSalesDayMonthReportクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesDayMonthReportクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SalesDayMonthReport salesDayMonthReport1, SalesDayMonthReport salesDayMonthReport2)
		{
			return ((salesDayMonthReport1.EnterpriseCode == salesDayMonthReport2.EnterpriseCode)
				 && (salesDayMonthReport1.SectionCodes == salesDayMonthReport2.SectionCodes)
                 && (salesDayMonthReport1.TotalType == salesDayMonthReport2.TotalType)
                 && (salesDayMonthReport1.TtlType == salesDayMonthReport2.TtlType)
                 && (salesDayMonthReport1.OutType == salesDayMonthReport2.OutType)
                 && (salesDayMonthReport1.SalesDateSt == salesDayMonthReport2.SalesDateSt)
                 && (salesDayMonthReport1.SalesDateEd == salesDayMonthReport2.SalesDateEd)
                 && (salesDayMonthReport1.MonthReportDateSt == salesDayMonthReport2.MonthReportDateSt)
                 && (salesDayMonthReport1.MonthReportDateEd == salesDayMonthReport2.MonthReportDateEd)
                 && (salesDayMonthReport1.CustomerCodeSt == salesDayMonthReport2.CustomerCodeSt)
                 && (salesDayMonthReport1.CustomerCodeEd == salesDayMonthReport2.CustomerCodeEd)
                 && (salesDayMonthReport1.SrchCodeSt == salesDayMonthReport2.SrchCodeSt)
                 && (salesDayMonthReport1.SrchCodeEd == salesDayMonthReport2.SrchCodeEd)
                 && (salesDayMonthReport1.TargetYearMonthSt == salesDayMonthReport2.TargetYearMonthSt)
                 && (salesDayMonthReport1.TargetYearMonthEd == salesDayMonthReport2.TargetYearMonthEd)
                 && (salesDayMonthReport1.MoneyUnit == salesDayMonthReport2.MoneyUnit)
                 && (salesDayMonthReport1.DaySumPrtDiv == salesDayMonthReport2.DaySumPrtDiv)
                 && (salesDayMonthReport1.CrMode == salesDayMonthReport2.CrMode)
				 && (salesDayMonthReport1.EnterpriseName == salesDayMonthReport2.EnterpriseName));
		}
		/// <summary>
		/// 売上日報月報抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesDayMonthReportクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesDayMonthReportクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SalesDayMonthReport target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.SectionCodes != target.SectionCodes) resList.Add("SectionCodes");
            if (this.TotalType != target.TotalType) resList.Add("TotalType");
            if (this.TtlType != target.TtlType) resList.Add("TtlType");
            if (this.OutType != target.OutType) resList.Add("OutType");
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.MonthReportDateSt != target.MonthReportDateSt) resList.Add("MonthReportDateSt");
            if (this.MonthReportDateEd != target.MonthReportDateEd) resList.Add("MonthReportDateEd");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (this.SrchCodeSt != target.SrchCodeSt) resList.Add("SrchCodeSt");
            if (this.SrchCodeEd != target.SrchCodeEd) resList.Add("SrchCodeEd");
            if (this.TargetYearMonthSt != target.TargetYearMonthSt) resList.Add("TargetYearMonthSt");
            if (this.TargetYearMonthEd != target.TargetYearMonthEd) resList.Add("TargetYearMonthEd");
            if (this.MoneyUnit != target.MoneyUnit) resList.Add("MoneyUnit");
            if (this.DaySumPrtDiv != target.DaySumPrtDiv) resList.Add("DaySumPrtDiv");
			if (this.CrMode != target.CrMode) resList.Add("CrMode");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 売上日報月報抽出条件クラス比較処理
		/// </summary>
		/// <param name="salesDayMonthReport1">比較するSalesDayMonthReportクラスのインスタンス</param>
		/// <param name="salesDayMonthReport2">比較するSalesDayMonthReportクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesDayMonthReportクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SalesDayMonthReport salesDayMonthReport1, SalesDayMonthReport salesDayMonthReport2)
		{
			ArrayList resList = new ArrayList();
			if (salesDayMonthReport1.EnterpriseCode != salesDayMonthReport2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (salesDayMonthReport1.SectionCodes != salesDayMonthReport2.SectionCodes) resList.Add("SectionCodes");
            if (salesDayMonthReport1.TotalType != salesDayMonthReport2.TotalType) resList.Add("TotalType");
            if (salesDayMonthReport1.TtlType != salesDayMonthReport2.TtlType) resList.Add("TtlType");
            if (salesDayMonthReport1.OutType != salesDayMonthReport2.OutType) resList.Add("OutType");
            if (salesDayMonthReport1.SalesDateSt != salesDayMonthReport2.SalesDateSt) resList.Add("SalesDateSt");
            if (salesDayMonthReport1.SalesDateEd != salesDayMonthReport2.SalesDateEd) resList.Add("SalesDateEd");
            if (salesDayMonthReport1.MonthReportDateSt != salesDayMonthReport2.MonthReportDateSt) resList.Add("MonthReportDateSt");
            if (salesDayMonthReport1.MonthReportDateEd != salesDayMonthReport2.MonthReportDateEd) resList.Add("MonthReportDateEd");
            if (salesDayMonthReport1.CustomerCodeSt != salesDayMonthReport2.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (salesDayMonthReport1.CustomerCodeEd != salesDayMonthReport2.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (salesDayMonthReport1.SrchCodeSt != salesDayMonthReport2.SrchCodeSt) resList.Add("SrchCodeSt");
            if (salesDayMonthReport1.SrchCodeEd != salesDayMonthReport2.SrchCodeEd) resList.Add("SrchCodeEd");
            if (salesDayMonthReport1.TargetYearMonthSt != salesDayMonthReport2.TargetYearMonthSt) resList.Add("TargetYearMonthSt");
            if (salesDayMonthReport1.TargetYearMonthEd != salesDayMonthReport2.TargetYearMonthEd) resList.Add("TargetYearMonthEd");
            if (salesDayMonthReport1.MoneyUnit != salesDayMonthReport2.MoneyUnit) resList.Add("MoneyUnit");
            if (salesDayMonthReport1.DaySumPrtDiv != salesDayMonthReport2.DaySumPrtDiv) resList.Add("DaySumPrtDiv");
            if (salesDayMonthReport1.CrMode != salesDayMonthReport2.CrMode) resList.Add("CrMode");
			if (salesDayMonthReport1.EnterpriseName != salesDayMonthReport2.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
        }

        #region ◆ 集計単位列挙体
        /// <summary> 集計単位列挙体 </summary>
        public enum TotalTypeState
        {
            /// <summary> 得意先別 </summary>
            Customer = 0,
            /// <summary> 担当者別 </summary>
            SalesEmployee = 1,
            /// <summary> 受注者別 </summary>
            FrontEmployee = 2,
            /// <summary> 発行者別 </summary>
            SalesInput = 3,
            /// <summary> 地区別 </summary>
            Area = 4,
            /// <summary> 業種別 </summary>
            BusinessType = 5,
            /// <summary> 販売区分別 </summary>
            SalesDiv = 6
        }
        #endregion ◆
	}
}
