using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockDayMonthReport
	/// <summary>
	///                      仕入日報月報抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入日報月報抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/09/20  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2008/08/08 30415 柴田 倫幸</br>
    /// <br>        	         ・PM.NS対応</br>   
	/// </remarks>
	public class StockDayMonthReport
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>全社選択</summary>
		/// <remarks>true:全社選択　false:各拠点選択</remarks>
		private Boolean _isSelectAllSection;

		/// <summary>全拠点レコード出力</summary>
		/// <remarks>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</remarks>
		private Boolean _isOutputAllSecRec;

		/// <summary>拠点コード</summary>
		/// <remarks>文字型　※配列項目</remarks>
		private string[] _sectionCode;

        // --- DEL 2008/08/08 -------------------------------->>>>>
        ///// <summary>得意先コード(開始)</summary>
        //private Int32 _customerCodeSt;

        ///// <summary>得意先コード(終了)</summary>
        //private Int32 _customerCodeEd;
        // --- DEL 2008/08/08 --------------------------------<<<<< 

        // --- ADD 2008/08/08 -------------------------------->>>>>
        /// <summary>仕入先コード(開始)</summary>
        private Int32 _supplierCodeSt;

        /// <summary>仕入先コード(終了)</summary>
        private Int32 _supplierCodeEd;
        // --- ADD 2008/08/08 --------------------------------<<<<< 

        // --- DEL 2008/08/08 -------------------------------->>>>>
        ///// <summary>仕入担当者コード(開始)</summary>
        ///// <remarks>未入力時は空文字("")</remarks>
        //private string _stockAgentCodeSt = "";

        ///// <summary>仕入担当者コード(終了)</summary>
        ///// <remarks>未入力時は空文字("")</remarks>
        //private string _stockAgentCodeEd = "";
        // --- DEL 2008/08/08 --------------------------------<<<<< 

		/// <summary>開始仕入日(日計)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _dayStockDateSt;

		/// <summary>終了仕入日(日計)</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _dayStockDateEd;

        // --- ADD 2008/08/08 -------------------------------->>>>>
        /// <summary>開始仕入日(累計)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _monthStockDateSt;

        /// <summary>終了仕入日(累計)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _monthStockDateEd;
        // --- ADD 2008/08/08 --------------------------------<<<<<

		/// <summary>帳票種別</summary>
		/// <remarks>0:営業所別 1:担当者別 2:仕入先別 3:担当別仕入先別</remarks>
		private Int32 _printType;

        // --- DEL 2008/08/08 -------------------------------->>>>>
        ///// <summary>出力順</summary>
        ///// <remarks>0:コード順 1:カナ順</remarks>
        //private Int32 _sortOrder;
        // --- DEL 2008/08/08 --------------------------------<<<<< 

		/// <summary>改頁</summary>
		/// <remarks>0:する 1:しない</remarks>
		private Int32 _pageType;

		/// <summary>締日</summary>
		/// <remarks>１～31</remarks>
		private Int32 _totalDay;

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

		/// public propaty name  :  IsSelectAllSection
		/// <summary>全社選択プロパティ</summary>
		/// <value>true:全社選択　false:各拠点選択</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全社選択プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean IsSelectAllSection
		{
			get { return _isSelectAllSection; }
			set { _isSelectAllSection = value; }
		}

		/// public propaty name  :  IsOutputAllSecRec
		/// <summary>全拠点レコード出力プロパティ</summary>
		/// <value>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全拠点レコード出力プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean IsOutputAllSecRec
		{
			get { return _isOutputAllSecRec; }
			set { _isOutputAllSecRec = value; }
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// <value>文字型　※配列項目</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCode
		{
			get { return _sectionCode; }
			set { _sectionCode = value; }
		}

        // --- DEL 2008/08/08 -------------------------------->>>>>
        ///// public propaty name  :  CustomerCodeSt
        ///// <summary>得意先コード(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustomerCodeSt
        //{
        //    get { return _customerCodeSt; }
        //    set { _customerCodeSt = value; }
        //}

        ///// public propaty name  :  CustomerCodeEd
        ///// <summary>得意先コード(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustomerCodeEd
        //{
        //    get { return _customerCodeEd; }
        //    set { _customerCodeEd = value; }
        //}
        // --- DEL 2008/08/08 --------------------------------<<<<< 

        // --- ADD 2008/08/08 -------------------------------->>>>>
        /// public propaty name  :  SupplierCodeSt
        /// <summary>仕入先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCodeSt
        {
            get { return _supplierCodeSt; }
            set { _supplierCodeSt = value; }
        }

        /// public propaty name  :  SupplierCodeEd
        /// <summary>仕入先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCodeEd
        {
            get { return _supplierCodeEd; }
            set { _supplierCodeEd = value; }
        }
        // --- ADD 2008/08/08 --------------------------------<<<<< 

        // --- DEL 2008/08/08 -------------------------------->>>>>
        ///// public propaty name  :  StockAgentCodeSt
        ///// <summary>仕入担当者コード(開始)プロパティ</summary>
        ///// <value>未入力時は空文字("")</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   仕入担当者コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string StockAgentCodeSt
        //{
        //    get { return _stockAgentCodeSt; }
        //    set { _stockAgentCodeSt = value; }
        //}

        ///// public propaty name  :  StockAgentCodeEd
        ///// <summary>仕入担当者コード(終了)プロパティ</summary>
        ///// <value>未入力時は空文字("")</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   仕入担当者コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string StockAgentCodeEd
        //{
        //    get { return _stockAgentCodeEd; }
        //    set { _stockAgentCodeEd = value; }
        //}
        // --- DEL 2008/08/08 --------------------------------<<<<< 

        /// public propaty name  :  DayStockDateSt
		/// <summary>開始仕入日(日計)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入日(日計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime DayStockDateSt
		{
            get { return _dayStockDateSt; }
            set { _dayStockDateSt = value; }
		}

        /// public propaty name  :  DayStockDateEd
		/// <summary>終了仕入日(日計)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入日(日計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime DayStockDateEd
		{
            get { return _dayStockDateEd; }
            set { _dayStockDateEd = value; }
		}

        // --- ADD 2008/08/08 -------------------------------->>>>>
        /// public propaty name  :  MonthStockDateSt
        /// <summary>開始仕入日(累計)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入日(累計)プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public DateTime MonthStockDateSt
        {
            get { return _monthStockDateSt; }
            set { _monthStockDateSt = value; }
        }

        /// public propaty name  :  MonthStockDateEd
        /// <summary>終了仕入日(累計)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入日(累計)プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public DateTime MonthStockDateEd
        {
            get { return _monthStockDateEd; }
            set { _monthStockDateEd = value; }
        }
        // --- ADD 2008/08/08 --------------------------------<<<<<

		/// public propaty name  :  PrintType
		/// <summary>帳票種別プロパティ</summary>
		/// <value>0:営業所別 1:担当者別 2:仕入先別 3:担当別仕入先別</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintType
		{
			get { return _printType; }
			set { _printType = value; }
		}

        // --- DEL 2008/08/08 -------------------------------->>>>>
        ///// public propaty name  :  SortOrder
        ///// <summary>出力順プロパティ</summary>
        ///// <value>0:コード順 1:カナ順</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   出力順プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SortOrder
        //{
        //    get { return _sortOrder; }
        //    set { _sortOrder = value; }
        //}
        // --- DEL 2008/08/08 --------------------------------<<<<< 

		/// public propaty name  :  PageType
		/// <summary>改頁プロパティ</summary>
		/// <value>0:改頁なし 1:営業所</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改頁プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PageType
		{
			get { return _pageType; }
			set { _pageType = value; }
		}

		/// public propaty name  :  TotalDay
		/// <summary>締日プロパティ</summary>
		/// <value>１～31</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get { return _totalDay; }
			set { _totalDay = value; }
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


		/// <summary>
		/// 仕入日報月報抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>StockDayMonthReportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDayMonthReportクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockDayMonthReport()
		{
		}

		/// <summary>
		/// 仕入日報月報抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="isSelectAllSection">全社選択(true:全社選択　false:各拠点選択)</param>
		/// <param name="isOutputAllSecRec">全拠点レコード出力(true:全拠点レコードを出力する。false:全拠点レコードを出力しない)</param>
		/// <param name="sectionCode">拠点コード(文字型　※配列項目)</param>
		/// <param name="customerCodeSt">得意先コード(開始)</param>
		/// <param name="customerCodeEd">得意先コード(終了)</param>
		/// <param name="stockAgentCodeSt">仕入担当者コード(開始)(未入力時は空文字(""))</param>
		/// <param name="stockAgentCodeEd">仕入担当者コード(終了)(未入力時は空文字(""))</param>
		/// <param name="stockDateSt">仕入日(開始)(YYYYMMDD)</param>
		/// <param name="stockDateEd">仕入日(終了)(YYYYMMDD)</param>
		/// <param name="printType">帳票種別(0:営業所別 1:担当者別 2:仕入先別 3:担当別仕入先別)</param>
		/// <param name="sortOrder">出力順(0:コード順 1:カナ順)</param>
		/// <param name="pageType">改頁(0:改頁なし 1:営業所)</param>
		/// <param name="totalDay">締日(１～31)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>StockDayMonthReportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDayMonthReportクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		//public StockDayMonthReport(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] sectionCode, Int32 customerCodeSt, Int32 customerCodeEd, string stockAgentCodeSt, string stockAgentCodeEd, Int32 stockDateSt, Int32 stockDateEd, Int32 printType, Int32 sortOrder, Int32 pageType, Int32 totalDay, string enterpriseName)  // DEL 2008/08/08
        public StockDayMonthReport(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] sectionCode, Int32 supplierCodeSt, Int32 supplierCodeEd, DateTime dayStockDateSt, DateTime dayStockDateEd, DateTime MonthStockDateSt, DateTime MonthStockDateEd, Int32 printType, Int32 pageType, Int32 totalDay, string enterpriseName)    // ADD 2008/08/08
        {
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._sectionCode = sectionCode;

            // --- DEL 2008/08/08 -------------------------------->>>>>
            //this._customerCodeSt = customerCodeSt;
            //this._customerCodeEd = customerCodeEd;
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            this._supplierCodeSt = supplierCodeSt;
            this._supplierCodeEd = supplierCodeEd;
            // --- ADD 2008/08/08 --------------------------------<<<<< 

            // --- DEL 2008/08/08 -------------------------------->>>>>
            //this._stockAgentCodeSt = stockAgentCodeSt;
            //this._stockAgentCodeEd = stockAgentCodeEd;
            //this._stockDateSt = stockDateSt;
            //this._stockDateEd = stockDateEd;
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            this._dayStockDateSt = dayStockDateSt;      // 開始仕入日(日計)
            this._dayStockDateEd = dayStockDateEd;      // 終了仕入日(日計)
            this._monthStockDateSt = MonthStockDateSt;  // 開始仕入日(累計)
            this._monthStockDateEd = MonthStockDateEd;  // 終了仕入日(累計)
            // --- ADD 2008/08/08 --------------------------------<<<<<

			this._printType = printType;
			//this._sortOrder = sortOrder;  // DEL 2008/08/08
			this._pageType = pageType;
			this._totalDay = totalDay;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 仕入日報月報抽出条件クラス複製処理
		/// </summary>
		/// <returns>StockDayMonthReportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockDayMonthReportクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockDayMonthReport Clone()
		{
			//return new StockDayMonthReport(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._sectionCode, this._customerCodeSt, this._customerCodeEd, this._stockAgentCodeSt, this._stockAgentCodeEd, this._stockDateSt, this._stockDateEd, this._printType, this._sortOrder, this._pageType, this._totalDay, this._enterpriseName);  // DEL 2008/08/08
            return new StockDayMonthReport(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._sectionCode, this._supplierCodeSt, this._supplierCodeEd, this._dayStockDateSt, this._dayStockDateEd, this._monthStockDateSt, this._monthStockDateEd, this._printType, this._pageType, this._totalDay, this._enterpriseName);    // ADD 2008/08/08
        }

		/// <summary>
		/// 仕入日報月報抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のStockDayMonthReportクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDayMonthReportクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockDayMonthReport target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
				 && (this.SectionCode == target.SectionCode)

                // --- DEL 2008/08/08 -------------------------------->>>>>
                 //&& (this.CustomerCodeSt == target.CustomerCodeSt)
                 //&& (this.CustomerCodeEd == target.CustomerCodeEd)
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                 && (this.SupplierCodeSt == target.SupplierCodeSt)
                 && (this.SupplierCodeEd == target.SupplierCodeEd)
                // --- ADD 2008/08/08 --------------------------------<<<<< 

                // --- DEL 2008/08/08 -------------------------------->>>>>
                 //&& (this.StockAgentCodeSt == target.StockAgentCodeSt)
                 //&& (this.StockAgentCodeEd == target.StockAgentCodeEd)
                 //&& (this.StockDateSt == target.StockDateSt)
                 //&& (this.StockDateEd == target.StockDateEd)
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
				 && (this.DayStockDateSt == target.DayStockDateSt)      // 開始仕入日(日計)
				 && (this.DayStockDateEd == target.DayStockDateEd)      // 終了仕入日(日計)
                 && (this.MonthStockDateSt == target.MonthStockDateSt)  // 開始仕入日(累計)
                 && (this.MonthStockDateEd == target.MonthStockDateEd)  // 終了仕入日(累計)
                 // --- ADD 2008/08/08 --------------------------------<<<<<

				 && (this.PrintType == target.PrintType)
				 //&& (this.SortOrder == target.SortOrder)  // DEL 2008/08/08
				 && (this.PageType == target.PageType)
				 && (this.TotalDay == target.TotalDay)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 仕入日報月報抽出条件クラス比較処理
		/// </summary>
		/// <param name="stockDayMonthReport1">
		///                    比較するStockDayMonthReportクラスのインスタンス
		/// </param>
		/// <param name="stockDayMonthReport2">比較するStockDayMonthReportクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDayMonthReportクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockDayMonthReport stockDayMonthReport1, StockDayMonthReport stockDayMonthReport2)
		{
			return ((stockDayMonthReport1.EnterpriseCode == stockDayMonthReport2.EnterpriseCode)
				 && (stockDayMonthReport1.IsSelectAllSection == stockDayMonthReport2.IsSelectAllSection)
				 && (stockDayMonthReport1.IsOutputAllSecRec == stockDayMonthReport2.IsOutputAllSecRec)
				 && (stockDayMonthReport1.SectionCode == stockDayMonthReport2.SectionCode)

                 // --- DEL 2008/08/08 -------------------------------->>>>>
                 //&& (stockDayMonthReport1.CustomerCodeSt == stockDayMonthReport2.CustomerCodeSt)
                 //&& (stockDayMonthReport1.CustomerCodeEd == stockDayMonthReport2.CustomerCodeEd)
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                 && (stockDayMonthReport1.SupplierCodeSt == stockDayMonthReport2.SupplierCodeSt)
                 && (stockDayMonthReport1.SupplierCodeEd == stockDayMonthReport2.SupplierCodeEd)
                // --- ADD 2008/08/08 --------------------------------<<<<< 

                // --- DEL 2008/08/08 -------------------------------->>>>>
                 //&& (stockDayMonthReport1.StockAgentCodeSt == stockDayMonthReport2.StockAgentCodeSt)
                 //&& (stockDayMonthReport1.StockAgentCodeEd == stockDayMonthReport2.StockAgentCodeEd)
                 //&& (stockDayMonthReport1.StockDateSt == stockDayMonthReport2.StockDateSt)
                 //&& (stockDayMonthReport1.StockDateEd == stockDayMonthReport2.StockDateEd)
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
				 && (stockDayMonthReport1.DayStockDateSt == stockDayMonthReport2.DayStockDateSt)      // 開始仕入日(日計)
				 && (stockDayMonthReport1.DayStockDateEd == stockDayMonthReport2.DayStockDateEd)      // 終了仕入日(日計)
                 && (stockDayMonthReport1.MonthStockDateSt == stockDayMonthReport2.MonthStockDateSt)  // 開始仕入日(累計)
                 && (stockDayMonthReport1.MonthStockDateEd == stockDayMonthReport2.MonthStockDateEd)  // 終了仕入日(累計)
                 // --- ADD 2008/08/08 --------------------------------<<<<<

				 && (stockDayMonthReport1.PrintType == stockDayMonthReport2.PrintType)
				 //&& (stockDayMonthReport1.SortOrder == stockDayMonthReport2.SortOrder)  // DEL 2008/08/08
				 && (stockDayMonthReport1.PageType == stockDayMonthReport2.PageType)
				 && (stockDayMonthReport1.TotalDay == stockDayMonthReport2.TotalDay)
				 && (stockDayMonthReport1.EnterpriseName == stockDayMonthReport2.EnterpriseName));
		}
		/// <summary>
		/// 仕入日報月報抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のStockDayMonthReportクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDayMonthReportクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockDayMonthReport target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (this.IsOutputAllSecRec != target.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");

            // --- DEL 2008/08/08 -------------------------------->>>>>
            //if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
            //if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            if (this.SupplierCodeSt != target.SupplierCodeSt) resList.Add("SupplierCodeSt");
            if (this.SupplierCodeEd != target.SupplierCodeEd) resList.Add("SupplierCodeEd");
            // --- ADD 2008/08/08 --------------------------------<<<<< 

            // --- DEL 2008/08/08 -------------------------------->>>>>
            //if (this.StockAgentCodeSt != target.StockAgentCodeSt) resList.Add("StockAgentCodeSt");
            //if (this.StockAgentCodeEd != target.StockAgentCodeEd) resList.Add("StockAgentCodeEd");
            //if (this.StockDateSt != target.StockDateSt) resList.Add("StockDateSt");
            //if (this.StockDateEd != target.StockDateEd) resList.Add("StockDateEd");
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
			if (this.DayStockDateSt != target.DayStockDateSt) resList.Add("DayStockDateSt");        // 開始仕入日(日計)
			if (this.DayStockDateEd != target.DayStockDateEd) resList.Add("DayStockDateEd");        // 終了仕入日(日計)
            if (this.MonthStockDateSt != target.MonthStockDateSt) resList.Add("MonthStockDateSt");  // 開始仕入日(累計)
            if (this.MonthStockDateEd != target.MonthStockDateEd) resList.Add("MonthStockDateEd");  // 終了仕入日(累計)
            // --- ADD 2008/08/08 --------------------------------<<<<<

			if (this.PrintType != target.PrintType) resList.Add("PrintType");
			//if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");  // DEL 2008/08/08
			if (this.PageType != target.PageType) resList.Add("PageType");
			if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 仕入日報月報抽出条件クラス比較処理
		/// </summary>
		/// <param name="stockDayMonthReport1">比較するStockDayMonthReportクラスのインスタンス</param>
		/// <param name="stockDayMonthReport2">比較するStockDayMonthReportクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDayMonthReportクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockDayMonthReport stockDayMonthReport1, StockDayMonthReport stockDayMonthReport2)
		{
			ArrayList resList = new ArrayList();
			if (stockDayMonthReport1.EnterpriseCode != stockDayMonthReport2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (stockDayMonthReport1.IsSelectAllSection != stockDayMonthReport2.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (stockDayMonthReport1.IsOutputAllSecRec != stockDayMonthReport2.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (stockDayMonthReport1.SectionCode != stockDayMonthReport2.SectionCode) resList.Add("SectionCode");

            // --- DEL 2008/08/08 -------------------------------->>>>>
            //if (stockDayMonthReport1.CustomerCodeSt != stockDayMonthReport2.CustomerCodeSt) resList.Add("CustomerCodeSt");
            //if (stockDayMonthReport1.CustomerCodeEd != stockDayMonthReport2.CustomerCodeEd) resList.Add("CustomerCodeEd");
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            if (stockDayMonthReport1.SupplierCodeSt != stockDayMonthReport2.SupplierCodeSt) resList.Add("SupplierCodeSt");
            if (stockDayMonthReport1.SupplierCodeEd != stockDayMonthReport2.SupplierCodeEd) resList.Add("SupplierCodeEd");
            // --- ADD 2008/08/08 --------------------------------<<<<< 

            // --- DEL 2008/08/08 -------------------------------->>>>>
            //if (stockDayMonthReport1.StockAgentCodeSt != stockDayMonthReport2.StockAgentCodeSt) resList.Add("StockAgentCodeSt");
            //if (stockDayMonthReport1.StockAgentCodeEd != stockDayMonthReport2.StockAgentCodeEd) resList.Add("StockAgentCodeEd");
            //if (stockDayMonthReport1.StockDateSt != stockDayMonthReport2.StockDateSt) resList.Add("StockDateSt");
            //if (stockDayMonthReport1.StockDateEd != stockDayMonthReport2.StockDateEd) resList.Add("StockDateEd");
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            if (stockDayMonthReport1.DayStockDateSt != stockDayMonthReport2.DayStockDateSt) resList.Add("DayStockDateSt");
			if (stockDayMonthReport1.DayStockDateEd != stockDayMonthReport2.DayStockDateEd) resList.Add("DayStockDateEd");
            if (stockDayMonthReport1.MonthStockDateSt != stockDayMonthReport2.MonthStockDateSt) resList.Add("MonthStockDateSt");
            if (stockDayMonthReport1.MonthStockDateEd != stockDayMonthReport2.MonthStockDateEd) resList.Add("MonthStockDateEd");
            // --- ADD 2008/08/08 --------------------------------<<<<<

			if (stockDayMonthReport1.PrintType != stockDayMonthReport2.PrintType) resList.Add("PrintType");
			//if (stockDayMonthReport1.SortOrder != stockDayMonthReport2.SortOrder) resList.Add("SortOrder");  // DEL 2008/08/08
			if (stockDayMonthReport1.PageType != stockDayMonthReport2.PageType) resList.Add("PageType");
			if (stockDayMonthReport1.TotalDay != stockDayMonthReport2.TotalDay) resList.Add("TotalDay");
			if (stockDayMonthReport1.EnterpriseName != stockDayMonthReport2.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}
	}
}
