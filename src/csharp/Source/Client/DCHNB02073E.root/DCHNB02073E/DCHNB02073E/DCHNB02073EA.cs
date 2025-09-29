using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesMonthYearReportCndtn
	/// <summary>
	///                      売上月報年報抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上月報年報抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/12/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      : 2008.09.08 30452 上野 俊治</br>
    /// <br>			       ・PM.NS対応</br>
    /// <br>UpdateNote       : 2012/12/28 zhuhh </br>
    /// <br>管理番号         : 10806793-00 2013/03/13配信分</br>
    /// <br>	             : Redmine#34098 罫線印字制御の追加</br>
	/// </remarks>
	public class SalesMonthYearReportCndtn
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>文字型　※配列項目　※部署管理区分が[0:拠点]の時に使用</remarks>
		private string[] _sectionCodes;

        //--- DEL 2008.08.14 ---------->>>>>
        ///// <summary>部署管理区分</summary>
        ///// <remarks>0:拠点(部署管理無し)　1:拠点＋部　2:拠点＋部＋課</remarks>
        //private Int32 _sectionDiv;

        ///// <summary>拠点コード(開始)</summary>
        ///// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        //private string _sectionCodeSt = "";

        ///// <summary>拠点コード(終了)</summary>
        ///// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        //private string _sectionCodeEd = "";

        ///// <summary>部門コード(開始)</summary>
        ///// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        //private Int32 _subSectionCodeSt;

        ///// <summary>部門コード(終了)</summary>
        ///// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        //private Int32 _subSectionCodeEd;

        ///// <summary>課コード(開始)</summary>
        ///// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        //private Int32 _minSectionCodeSt;

        ///// <summary>課コード(終了)</summary>
        ///// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        //private Int32 _minSectionCodeEd;
        //--- DEL 2008.08.14 ----------<<<<<

		/// <summary>集計方法</summary>
		/// <remarks>0:全社 1:営業所毎</remarks>
		private Int32 _ttlType;

		/// <summary>計上年月(開始)</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonthSt;

		/// <summary>計上日付(終了)</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonthEd;

        /// <summary>計上期年月(開始)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _annualAddUpYearMonthSt;

        /// <summary>計上期年月(終了)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _annualAddUpYaerMonthEd;

		/// <summary>得意先コード(開始)</summary>
		private Int32 _customerCodeSt;

		/// <summary>得意先コード(終了)</summary>
		private Int32 _customerCodeEd;

        // --- ADD 2008/09/08 -------------------------------->>>>>
        /// <summary>検索条件コード(開始)</summary>
        private string _searchCodeSt;

        /// <summary>検索条件コード(終了)</summary>
        private string _searchCodeEd;
        // --- ADD 2008/09/08 --------------------------------<<<<<

        //--- DEL 2008.08.14 ---------->>>>>
        ///// <summary>担当者コード(開始)</summary>
        ///// <remarks>未入力時は空文字("")</remarks>
        //private string _salesEmployeeCdSt = "";

        ///// <summary>担当者コード(終了)</summary>
        ///// <remarks>未入力時は空文字("")</remarks>
        //private string _salesEmployeeCdEd = "";

        ///// <summary>受注者コード(開始)</summary>
        ///// <remarks>未入力時は空文字("")</remarks>
        //private string _frontEmployeeCdSt = "";

        ///// <summary>受注者コード(終了)</summary>
        ///// <remarks>未入力時は空文字("")</remarks>
        //private string _frontEmployeeCdEd = "";

        ///// <summary>発行者コード(開始)</summary>
        ///// <remarks>未入力時は空文字("")</remarks>
        //private string _salesInputCodeSt = "";

        ///// <summary>発行者コード(終了)</summary>
        ///// <remarks>未入力時は空文字("")</remarks>
        //private string _salesInputCodeEd = "";

        ///// <summary>販売エリアコード(開始)</summary>
        //private Int32 _salesAreaCodeSt;

        ///// <summary>販売エリアコード(終了)</summary>
        //private Int32 _salesAreaCodeEd;

        ///// <summary>業種コード(開始)</summary>
        //private Int32 _businessTypeCodeSt;

        ///// <summary>業種コード(終了)</summary>
        //private Int32 _businessTypeCodeEd;

        ///// <summary>メーカーコード(開始)</summary>
        //private Int32 _goodsMakerCdSt;

        ///// <summary>メーカーコード(終了)</summary>
        //private Int32 _goodsMakerCdEd;
        //--- DEL 2008.08.14 ----------<<<<<

		/// <summary>集計単位</summary>
		/// <remarks>0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業種別 6:販売区分別</remarks>
        private Int32 _totalType;

		/// <summary>集計単位名称</summary>
		private string _totalTypeName = "";

		/// <summary>印刷タイプ</summary>
		/// <remarks>0:当月 1:当期 2:当月＆当期</remarks>
		private Int32 _printType;

		/// <summary>印刷タイプ名称</summary>
		private string _printTypeName = "";

		/// <summary>金額単位</summary>
		/// <remarks>0:円 1:千円</remarks>
		private Int32 _moneyUnit;

		/// <summary>金額単位名称</summary>
		private string _moneyUnitName = "";

        // --- DEL 2008/09/08 -------------------------------->>>>>
		///// <summary>改頁</summary>
		///// <remarks>0:なし 1:拠点 2:得意先 3:担当者 4:受注者 5:発行者 6:地区別 7:業種別</remarks>
		//private Int32 _crMode;
        // --- DEL 2008/09/08 --------------------------------<<<<<

        // --- ADD 2008/09/08 -------------------------------->>>>>
        /// <summary>拠点毎に改頁</summary>
        private bool _crMode1;
        /// <summary>集計単位による改頁</summary>
        private bool _crMode2;
        // --- ADD 2008/09/08 --------------------------------<<<<<

		/// <summary>構成比単位</summary>
		/// <remarks>0:総合計 1:小計</remarks>
		private Int32 _constUnit;

		/// <summary>構成比単位名称</summary>
		private string _constUnitName = "";

		/// <summary>集計方法名称</summary>
		private string _ttlTypeName = "";

        //--- ADD 2008.08.14 ---------->>>>>
        /// <summary>出力順</summary>
        private Int32 _outType;
        /// <summary>印刷順</summary>
        private PrintOrderDivState _printOrder;
        /// <summary>順位付け設定(単位)</summary>
        private Int32 _orderUnit;
        /// <summary>順位付け設定(方法)</summary>
        private StockOrderDivState _orderMethod;
        /// <summary>順位付け設定(範囲)</summary>
        private Int32 _orderRange;

        /// <summary>順位指定</summary>
        private OrderAppointmentDivState _orderAppointment = 0;

        /// <summary>印字パターン</summary>
        private Int32 _printingPattern;

        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
        /// <summary>罫線印字</summary>
        private Int32 _lineMaSqOfChDiv;
        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<


        //--- ADD 2008.08.14 ----------<<<<<

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
		/// <value>文字型　※配列項目　※部署管理区分が[0:拠点]の時に使用</value>
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

        //--- DEL 2008.08.14 ---------->>>>>
        ///// public propaty name  :  SectionDiv
        ///// <summary>部署管理区分プロパティ</summary>
        ///// <value>0:拠点(部署管理無し)　1:拠点＋部　2:拠点＋部＋課</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   部署管理区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SectionDiv
        //{
        //    get{return _sectionDiv;}
        //    set{_sectionDiv = value;}
        //}

        ///// public propaty name  :  SectionCodeSt
        ///// <summary>拠点コード(開始)プロパティ</summary>
        ///// <value>※部署管理区分が[1 または 2]の時に使用</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   拠点コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SectionCodeSt
        //{
        //    get{return _sectionCodeSt;}
        //    set{_sectionCodeSt = value;}
        //}

        ///// public propaty name  :  SectionCodeEd
        ///// <summary>拠点コード(終了)プロパティ</summary>
        ///// <value>※部署管理区分が[1 または 2]の時に使用</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   拠点コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SectionCodeEd
        //{
        //    get{return _sectionCodeEd;}
        //    set{_sectionCodeEd = value;}
        //}

        ///// public propaty name  :  SubSectionCodeSt
        ///// <summary>部門コード(開始)プロパティ</summary>
        ///// <value>※部署管理区分が[1 または 2]の時に使用</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   部門コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SubSectionCodeSt
        //{
        //    get{return _subSectionCodeSt;}
        //    set{_subSectionCodeSt = value;}
        //}

        ///// public propaty name  :  SubSectionCodeEd
        ///// <summary>部門コード(終了)プロパティ</summary>
        ///// <value>※部署管理区分が[1 または 2]の時に使用</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   部門コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SubSectionCodeEd
        //{
        //    get{return _subSectionCodeEd;}
        //    set{_subSectionCodeEd = value;}
        //}

        ///// public propaty name  :  MinSectionCodeSt
        ///// <summary>課コード(開始)プロパティ</summary>
        ///// <value>※部署管理区分が[1 または 2]の時に使用</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   課コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 MinSectionCodeSt
        //{
        //    get{return _minSectionCodeSt;}
        //    set{_minSectionCodeSt = value;}
        //}

        ///// public propaty name  :  MinSectionCodeEd
        ///// <summary>課コード(終了)プロパティ</summary>
        ///// <value>※部署管理区分が[1 または 2]の時に使用</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   課コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 MinSectionCodeEd
        //{
        //    get{return _minSectionCodeEd;}
        //    set{_minSectionCodeEd = value;}
        //}
        //--- DEL 2008.08.14 ----------<<<<<

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
			get{return _ttlType;}
			set{_ttlType = value;}
		}

		/// public propaty name  :  AddUpYearMonthSt
		/// <summary>計上年月(開始)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonthSt
		{
			get{return _addUpYearMonthSt;}
			set{_addUpYearMonthSt = value;}
		}

		/// public propaty name  :  AddUpYearMonthEd
		/// <summary>計上日付(終了)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonthEd
		{
			get{return _addUpYearMonthEd;}
			set{_addUpYearMonthEd = value;}
		}

        /// public propaty name  :  AnnualAddUpYearMonthSt
        /// <summary>計上期年月(開始)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上期年月(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AnnualAddUpYearMonthSt
        {
            get { return _annualAddUpYearMonthSt; }
            set { _annualAddUpYearMonthSt = value; }
        }

        /// public propaty name  :  AnnualAddUpYaerMonthEd
        /// <summary>計上期年月(終了)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上期年月(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AnnualAddUpYaerMonthEd
        {
            get { return _annualAddUpYaerMonthEd; }
            set { _annualAddUpYaerMonthEd = value; }
        }

		/// public propaty name  :  CustomerCodeSt
		/// <summary>得意先コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get{return _customerCodeSt;}
			set{_customerCodeSt = value;}
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>得意先コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get{return _customerCodeEd;}
			set{_customerCodeEd = value;}
		}

        // --- ADD 2008/09/08 -------------------------------->>>>>
        /// public propaty name  :  SearchCodeSt
        /// <summary>検索条件コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索条件コード(開始)プロパティ</br>
        /// <br>Programer        :   30452 上野 俊治</br>
        /// </remarks>
        public string SearchCodeSt
        {
            get { return _searchCodeSt; }
            set { _searchCodeSt = value; }
        }

        /// public propaty name  :  SearchCodeEd
        /// <summary>検索条件コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索条件コード(終了)プロパティ</br>
        /// <br>Programer        :   30452 上野 俊治</br>
        /// </remarks>
        public string SearchCodeEd
        {
            get { return _searchCodeEd; }
            set { _searchCodeEd = value; }
        }

        // --- ADD 2008/09/08 --------------------------------<<<<< 

        //--- DEL 2008.08.14 ---------->>>>>
        ///// public propaty name  :  SalesEmployeeCdSt
        ///// <summary>担当者コード(開始)プロパティ</summary>
        ///// <value>未入力時は空文字("")</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   担当者コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SalesEmployeeCdSt
        //{
        //    get{return _salesEmployeeCdSt;}
        //    set{_salesEmployeeCdSt = value;}
        //}

        ///// public propaty name  :  SalesEmployeeCdEd
        ///// <summary>担当者コード(終了)プロパティ</summary>
        ///// <value>未入力時は空文字("")</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   担当者コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SalesEmployeeCdEd
        //{
        //    get{return _salesEmployeeCdEd;}
        //    set{_salesEmployeeCdEd = value;}
        //}

        ///// public propaty name  :  FrontEmployeeCdSt
        ///// <summary>受注者コード(開始)プロパティ</summary>
        ///// <value>未入力時は空文字("")</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   受注者コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string FrontEmployeeCdSt
        //{
        //    get{return _frontEmployeeCdSt;}
        //    set{_frontEmployeeCdSt = value;}
        //}

        ///// public propaty name  :  FrontEmployeeCdEd
        ///// <summary>受注者コード(終了)プロパティ</summary>
        ///// <value>未入力時は空文字("")</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   受注者コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string FrontEmployeeCdEd
        //{
        //    get{return _frontEmployeeCdEd;}
        //    set{_frontEmployeeCdEd = value;}
        //}

        ///// public propaty name  :  SalesInputCodeSt
        ///// <summary>発行者コード(開始)プロパティ</summary>
        ///// <value>未入力時は空文字("")</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   発行者コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SalesInputCodeSt
        //{
        //    get{return _salesInputCodeSt;}
        //    set{_salesInputCodeSt = value;}
        //}

        ///// public propaty name  :  SalesInputCodeEd
        ///// <summary>発行者コード(終了)プロパティ</summary>
        ///// <value>未入力時は空文字("")</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   発行者コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SalesInputCodeEd
        //{
        //    get{return _salesInputCodeEd;}
        //    set{_salesInputCodeEd = value;}
        //}

        ///// public propaty name  :  SalesAreaCodeSt
        ///// <summary>販売エリアコード(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   販売エリアコード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SalesAreaCodeSt
        //{
        //    get{return _salesAreaCodeSt;}
        //    set{_salesAreaCodeSt = value;}
        //}

        ///// public propaty name  :  SalesAreaCodeEd
        ///// <summary>販売エリアコード(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   販売エリアコード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SalesAreaCodeEd
        //{
        //    get{return _salesAreaCodeEd;}
        //    set{_salesAreaCodeEd = value;}
        //}

        ///// public propaty name  :  BusinessTypeCodeSt
        ///// <summary>業種コード(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   業種コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 BusinessTypeCodeSt
        //{
        //    get{return _businessTypeCodeSt;}
        //    set{_businessTypeCodeSt = value;}
        //}

        ///// public propaty name  :  BusinessTypeCodeEd
        ///// <summary>業種コード(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   業種コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 BusinessTypeCodeEd
        //{
        //    get{return _businessTypeCodeEd;}
        //    set{_businessTypeCodeEd = value;}
        //}

        ///// public propaty name  :  GoodsMakerCdSt
        ///// <summary>メーカーコード(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   メーカーコード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 GoodsMakerCdSt
        //{
        //    get{return _goodsMakerCdSt;}
        //    set{_goodsMakerCdSt = value;}
        //}

        ///// public propaty name  :  GoodsMakerCdEd
        ///// <summary>メーカーコード(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   メーカーコード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 GoodsMakerCdEd
        //{
        //    get{return _goodsMakerCdEd;}
        //    set{_goodsMakerCdEd = value;}
        //}
        //--- DEL 2008.08.14 ----------<<<<<

		/// public propaty name  :  TotalType
		/// <summary>集計単位プロパティ</summary>
		/// <value>0:拠点別 1:得意先別 2:地区別得意先別 3:業種別得意先別 4:地区別 5:業種別 6:担当者別 7:部署別 8:メーカー別 9:得意先別メーカー別</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalType
		{
			get{return _totalType;}
			set{_totalType = value;}
		}

		/// public propaty name  :  TotalTypeName
		/// <summary>集計単位名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計単位名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TotalTypeName
		{
			get{return _totalTypeName;}
			set{_totalTypeName = value;}
		}

		/// public propaty name  :  PrintType
		/// <summary>印刷タイププロパティ</summary>
		/// <value>0:当月 1:当期 2:当月＆当期</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintType
		{
			get{return _printType;}
			set{_printType = value;}
		}

		/// public propaty name  :  PrintTypeName
		/// <summary>印刷タイプ名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷タイプ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrintTypeName
		{
			get{return _printTypeName;}
			set{_printTypeName = value;}
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
			get{return _moneyUnit;}
			set{_moneyUnit = value;}
		}

		/// public propaty name  :  MoneyUnitName
		/// <summary>金額単位名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   金額単位名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MoneyUnitName
		{
			get{return _moneyUnitName;}
			set{_moneyUnitName = value;}
		}

        /* --- DEL 2008/09/08 -------------------------------->>>>>
		/// public propaty name  :  CrMode
		/// <summary>改頁プロパティ</summary>
		/// <value>0:なし 10:拠点 1:部門 2:得意先 3:地区 4:業種11:拠点/部門 12:拠点/得意先 13:拠点/地区 14:拠点/業種</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改頁プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CrMode
		{
			get{return _crMode;}
			set{_crMode = value;}
		}
        --- DEL 2008/09/08 -------------------------------->>>>> */

        // --- ADD 2008/09/08 -------------------------------->>>>>
        /// public propaty name  :  CrMode1
        /// <summary>改頁プロパティ</summary>
        /// <value>false:なし true:拠点毎で改頁</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁1プロパティ</br>
        /// <br>Programer        :   30452 上野 俊治</br>
        /// </remarks>
        public bool CrMode1
        {
            get { return _crMode1; }
            set { _crMode1 = value; }
        }

        /// public propaty name  :  CrMode2
        /// <summary>改頁プロパティ</summary>
        /// <value>false:なし true:各検索条件で改頁</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁2プロパティ</br>
        /// <br>Programer        :   30452 上野 俊治</br>
        /// </remarks>
        public bool CrMode2
        {
            get { return _crMode2; }
            set { _crMode2 = value; }
        }
        // --- ADD 2008/09/08 --------------------------------<<<<<

        /// public propaty name  :  ConstUnit
		/// <summary>構成比単位プロパティ</summary>
		/// <value>0:総合計 1:小計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   構成比単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ConstUnit
		{
			get{return _constUnit;}
			set{_constUnit = value;}
		}

		/// public propaty name  :  ConstUnitName
		/// <summary>構成比単位名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   構成比単位名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ConstUnitName
		{
			get{return _constUnitName;}
			set{_constUnitName = value;}
		}

		/// public propaty name  :  TtlTypeName
		/// <summary>集計方法名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計方法名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TtlTypeName
		{
			get{return _ttlTypeName;}
			set{_ttlTypeName = value;}
		}

        //--- ADD 2008.08.14 ---------->>>>>
        /// public propaty name  :  OutType
        /// <summary>出力順プロパティ</summary>
        /// <value>0:得意先 1:拠点 2:得意先－拠点 3:管理拠点 4:請求先</value>
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

        /// public propaty name  :  OutType
        /// <summary>印刷順プロパティ</summary>
        /// <value>0:コード 1:順位</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrintOrderDivState PrintOrder
        {
            get { return _printOrder; }
            set { _printOrder = value; }
        }

        /// public propaty name  :  OrderUnit
        /// <summary>順位付け設定(単位)プロパティ</summary>
        /// <value>0:全社 1:小計毎</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderUnit
        {
            get { return _orderUnit; }
            set { _orderUnit = value; }
        }

        /// public propaty name  :  OrderMethod
        /// <summary>順位付け設定(方法)プロパティ</summary>
        /// <value>0:上位 1:下位</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockOrderDivState OrderMethod
        {
            get { return _orderMethod; }
            set { _orderMethod = value; }
        }

        /// public propaty name  :  OrderRange
        /// <summary>順位付け設定(範囲)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderRange
        {
            get { return _orderRange; }
            set { _orderRange = value; }
        }

        /// public propaty name  :  OrderRange
        /// <summary>順位指定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   順位指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderAppointmentDivState OrderAppointment
        {
            get { return _orderAppointment; }
            set { _orderAppointment = value; }
        }

        /// public propaty name  :  PrintingPattern
        /// <summary>印字パターンプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   順位指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintingPattern
        {
            get { return _printingPattern; }
            set { _printingPattern = value; }
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

        /// public propaty name  :  PrintOrderTitle
        /// <summary>順位指定タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   順位指定タイトルプロパティ</br>
        /// <br>Programer        :   30416 長沼 賢二</br>
        /// </remarks>
        public string PrintOrderTitle
        {
            get
            {
                string extractDateTitle = "";
                switch (this._printOrder)
                {
                    case PrintOrderDivState.Code:
                        extractDateTitle = "コード";
                        break;
                    case PrintOrderDivState.Order:
                        extractDateTitle = "順位";
                        break;
                }
                return extractDateTitle;
            }
        }

        /// public propaty name  :  PriceDesignatTitle
        /// <summary>順位指定タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   順位指定タイトルプロパティ</br>
        /// <br>Programer        :   30416 長沼 賢二</br>
        /// </remarks>
        public string OrderAppointmentTitle
        {
            get
            {
                string extractDateTitle = "";
                switch (this._orderAppointment)
                {
                    case OrderAppointmentDivState.Sales:
                        extractDateTitle = "純売上";
                        break;
                    case OrderAppointmentDivState.GrossProfit:
                        extractDateTitle = "粗利";
                        break;
                    case OrderAppointmentDivState.SalesRetGoods:
                        extractDateTitle = "返品";
                        break;
                }
                return extractDateTitle;
            }
        }

        /// public propaty name  :  PrintOrderTitle
        /// <summary>順位付け設定(単位)タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   順位付け設定(単位)タイトルプロパティ</br>
        /// <br>Programer        :   30416 長沼 賢二</br>
        /// </remarks>
        public string OrderUnitTitle
        {
            get
            {
                string extractDateTitle = "";
                switch (this._orderUnit)
                {
                    case 0:
                        extractDateTitle = "全社";
                        break;
                    case 1:
                        extractDateTitle = "小計毎";
                        break;
                }
                return extractDateTitle;
            }
        }

        /// public propaty name  :  PrintOrderTitle
        /// <summary>順位付け設定(方法)タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   順位付け設定(方法)タイトルプロパティ</br>
        /// <br>Programer        :   30416 長沼 賢二</br>
        /// </remarks>
        public string OrderMethodTitle
        {
            get
            {
                string extractDateTitle = "";
                switch (this._orderMethod)
                {
                    case StockOrderDivState.High:
                        extractDateTitle = "上位";
                        break;
                    case StockOrderDivState.Low:
                        extractDateTitle = "下位";
                        break;
                }
                return extractDateTitle;
            }
        }
        //--- ADD 2008.08.14 ----------<<<<<

		/// <summary>
		/// 売上月報年報抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>SalesMonthYearReportCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesMonthYearReportCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesMonthYearReportCndtn()
		{
		}

		/// <summary>
		/// 売上月報年報抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCodes">拠点コード(文字型　※配列項目　※部署管理区分が[0:拠点]の時に使用)</param>
		/// <param name="ttlType">集計方法(0:全社 1:営業所毎)</param>
		/// <param name="addUpYearMonthSt">計上年月(開始)(YYYYMM)</param>
		/// <param name="addUpYearMonthEd">計上日付(終了)(YYYYMM)</param>
		/// <param name="customerCodeSt">得意先コード(開始)</param>
		/// <param name="customerCodeEd">得意先コード(終了)</param>
        /// <param name="searchCodeSt">検索条件コード(開始)</param>
        /// <param name="searchCodeEd">検索条件コード(終了)</param>
		/// <param name="totalType">集計単位(0:拠点別 1:得意先別 2:地区別得意先別 3:業種別得意先別 4:地区別 5:業種別 6:担当者別 7:部署別 8:メーカー別 9:得意先別メーカー別)</param>
		/// <param name="totalTypeName">集計単位名称</param>
		/// <param name="printType">印刷タイプ(0:当月 1:当期 2:当月＆当期)</param>
		/// <param name="printTypeName">印刷タイプ名称</param>
		/// <param name="moneyUnit">金額単位(0:円 1:千円)</param>
		/// <param name="moneyUnitName">金額単位名称</param>
		/// <param name="crMode1">拠点毎で改頁するか</param>
        /// <param name="crMode2">各検索条件ごとで改頁するか</param>
		/// <param name="constUnit">構成比単位(0:総合計 1:小計)</param>
		/// <param name="constUnitName">構成比単位名称</param>
		/// <param name="ttlTypeName">集計方法名称</param>
		/// <returns>SalesMonthYearReportCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesMonthYearReportCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        //public SalesMonthYearReportCndtn(string enterpriseCode, string[] sectionCodes, Int32 sectionDiv, string sectionCodeSt, string sectionCodeEd, Int32 subSectionCodeSt, Int32 subSectionCodeEd, Int32 minSectionCodeSt, Int32 minSectionCodeEd, Int32 ttlType, DateTime addUpYearMonthSt, DateTime addUpYearMonthEd, DateTime annualAddUpYearMonthSt, DateTime annualAddUpYaerMonthEd, Int32 customerCodeSt, Int32 customerCodeEd, string salesEmployeeCdSt, string salesEmployeeCdEd, string frontEmployeeCdSt, string frontEmployeeCdEd, string salesInputCodeSt, string salesInputCodeEd, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 businessTypeCodeSt, Int32 businessTypeCodeEd, Int32 goodsMakerCdSt, Int32 goodsMakerCdEd, Int32 totalType, string totalTypeName, Int32 printType, string printTypeName, Int32 moneyUnit, string moneyUnitName, Int32 crMode, Int32 constUnit, string constUnitName, string ttlTypeName)
        public SalesMonthYearReportCndtn(string enterpriseCode,string[] sectionCodes,Int32 ttlType,DateTime addUpYearMonthSt,DateTime addUpYearMonthEd,Int32 customerCodeSt,Int32 customerCodeEd,string searchCodeSt, string searchCodeEd ,Int32 totalType,string totalTypeName,Int32 printType,string printTypeName,Int32 moneyUnit,string moneyUnitName,bool crMode1, bool crMode2,Int32 constUnit,string constUnitName,string ttlTypeName)
        {
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
            //--- DEL 2008.08.14 ---------->>>>>
            //this._sectionDiv = sectionDiv;
            //this._sectionCodeSt = sectionCodeSt;
            //this._sectionCodeEd = sectionCodeEd;
            //this._subSectionCodeSt = subSectionCodeSt;
            //this._subSectionCodeEd = subSectionCodeEd;
            //this._minSectionCodeSt = minSectionCodeSt;
            //this._minSectionCodeEd = minSectionCodeEd;
            //--- DEL 2008.08.14 ----------<<<<<
            this._ttlType = ttlType;
			this._addUpYearMonthSt = addUpYearMonthSt;
			this._addUpYearMonthEd = addUpYearMonthEd;
            //--- DEL 2008.08.14 ---------->>>>>
            //this._annualAddUpYearMonthSt = annualAddUpYearMonthSt;
            //this._annualAddUpYaerMonthEd = annualAddUpYaerMonthEd;
            //--- DEL 2008.08.14 ----------<<<<<
            this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
            // --- ADD 2008/09/08 -------------------------------->>>>>
            this._searchCodeSt = searchCodeSt;
            this._searchCodeEd = searchCodeEd;
            // --- ADD 2008/09/08 --------------------------------<<<<< 
            //--- DEL 2008.08.14 ---------->>>>>
            //this._salesEmployeeCdSt = salesEmployeeCdSt;
            //this._salesEmployeeCdEd = salesEmployeeCdEd;
            //this._frontEmployeeCdSt = frontEmployeeCdSt;
            //this._frontEmployeeCdEd = frontEmployeeCdEd;
            //this._salesInputCodeSt = salesInputCodeSt;
            //this._salesInputCodeEd = salesInputCodeEd;
            //this._salesAreaCodeSt = salesAreaCodeSt;
            //this._salesAreaCodeEd = salesAreaCodeEd;
            //this._businessTypeCodeSt = businessTypeCodeSt;
            //this._businessTypeCodeEd = businessTypeCodeEd;
            //this._goodsMakerCdSt = goodsMakerCdSt;
            //this._goodsMakerCdEd = goodsMakerCdEd;
            //--- DEL 2008.08.14 ----------<<<<<
            this._totalType = totalType;
			this._totalTypeName = totalTypeName;
			this._printType = printType;
			this._printTypeName = printTypeName;
			this._moneyUnit = moneyUnit;
			this._moneyUnitName = moneyUnitName;
            // --- DEL 2008/09/08 -------------------------------->>>>>
			//this._crMode = crMode;
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            this._crMode1 = crMode1;
            this._crMode2 = crMode2;
            // --- ADD 2008/09/08 --------------------------------<<<<<
			this._constUnit = constUnit;
			this._constUnitName = constUnitName;
			this._ttlTypeName = ttlTypeName;

		}

		/// <summary>
		/// 売上月報年報抽出条件クラス複製処理
		/// </summary>
		/// <returns>SalesMonthYearReportCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSalesMonthYearReportCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesMonthYearReportCndtn Clone()
		{
            //--- DEL 2008.08.14 ---------->>>>>
            //return new SalesMonthYearReportCndtn(this._enterpriseCode, this._sectionCodes, this._sectionDiv, this._sectionCodeSt, this._sectionCodeEd, this._subSectionCodeSt, this._subSectionCodeEd, this._minSectionCodeSt, this._minSectionCodeEd, this._ttlType, this._addUpYearMonthSt, this._addUpYearMonthEd, this._annualAddUpYearMonthSt, this._annualAddUpYaerMonthEd, this._customerCodeSt, this._customerCodeEd, this._salesEmployeeCdSt, this._salesEmployeeCdEd, this._frontEmployeeCdSt, this._frontEmployeeCdEd, this._salesInputCodeSt, this._salesInputCodeEd, this._salesAreaCodeSt, this._salesAreaCodeEd, this._businessTypeCodeSt, this._businessTypeCodeEd, this._goodsMakerCdSt, this._goodsMakerCdEd, this._totalType, this._totalTypeName, this._printType, this._printTypeName, this._moneyUnit, this._moneyUnitName, this._crMode, this._constUnit, this._constUnitName, this._ttlTypeName);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            return new SalesMonthYearReportCndtn(this._enterpriseCode, this._sectionCodes, this._ttlType, this._addUpYearMonthSt, this._addUpYearMonthEd, this._customerCodeSt, this._customerCodeEd, this._searchCodeSt, this._searchCodeEd, this._totalType, this._totalTypeName, this._printType, this._printTypeName, this._moneyUnit, this._moneyUnitName, this._crMode1, this._crMode2, this._constUnit, this._constUnitName, this._ttlTypeName);
            //--- ADD 2008.08.14 ----------<<<<<
        }

		/// <summary>
		/// 売上月報年報抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesMonthYearReportCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesMonthYearReportCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SalesMonthYearReportCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
                 //--- DEL 2008.08.14 ---------->>>>>
                 //&& (this.SectionDiv == target.SectionDiv)
                 //&& (this.SectionCodeSt == target.SectionCodeSt)
                 //&& (this.SectionCodeEd == target.SectionCodeEd)
                 //&& (this.SubSectionCodeSt == target.SubSectionCodeSt)
                 //&& (this.SubSectionCodeEd == target.SubSectionCodeEd)
                 //&& (this.MinSectionCodeSt == target.MinSectionCodeSt)
                 //&& (this.MinSectionCodeEd == target.MinSectionCodeEd)
                 //--- DEL 2008.08.14 ----------<<<<<
                 && (this.TtlType == target.TtlType)
				 && (this.AddUpYearMonthSt == target.AddUpYearMonthSt)
				 && (this.AddUpYearMonthEd == target.AddUpYearMonthEd)
                 //--- DEL 2008.08.14 ---------->>>>>
                 //&& (this.AnnualAddUpYearMonthSt == target.AnnualAddUpYearMonthSt)
                 //&& (this.AnnualAddUpYaerMonthEd == target.AnnualAddUpYaerMonthEd)
                 //--- DEL 2008.08.14 ----------<<<<<
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
				 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 //--- DEL 2008.08.14 ---------->>>>>
                // --- ADD 2008/09/08 -------------------------------->>>>>
                && (this.SearchCodeSt == target.SearchCodeSt)
                 && (this.SearchCodeEd == target.SearchCodeEd)
                // --- ADD 2008/09/08 --------------------------------<<<<<
                 //&& (this.SalesEmployeeCdSt == target.SalesEmployeeCdSt)
                 //&& (this.SalesEmployeeCdEd == target.SalesEmployeeCdEd)
                 //&& (this.FrontEmployeeCdSt == target.FrontEmployeeCdSt)
                 //&& (this.FrontEmployeeCdEd == target.FrontEmployeeCdEd)
                 //&& (this.SalesInputCodeSt == target.SalesInputCodeSt)
                 //&& (this.SalesInputCodeEd == target.SalesInputCodeEd)
                 //&& (this.SalesAreaCodeSt == target.SalesAreaCodeSt)
                 //&& (this.SalesAreaCodeEd == target.SalesAreaCodeEd)
                 //&& (this.BusinessTypeCodeSt == target.BusinessTypeCodeSt)
                 //&& (this.BusinessTypeCodeEd == target.BusinessTypeCodeEd)
                 //&& (this.GoodsMakerCdSt == target.GoodsMakerCdSt)
                 //&& (this.GoodsMakerCdEd == target.GoodsMakerCdEd)
                 //--- DEL 2008.08.14 ----------<<<<<
                 && (this.TotalType == target.TotalType)
				 && (this.TotalTypeName == target.TotalTypeName)
				 && (this.PrintType == target.PrintType)
				 && (this.PrintTypeName == target.PrintTypeName)
				 && (this.MoneyUnit == target.MoneyUnit)
				 && (this.MoneyUnitName == target.MoneyUnitName)
                // --- DEL 2008/09/08 -------------------------------->>>>>
				 //&& (this.CrMode == target.CrMode)
                // --- DEL 2008/09/08 --------------------------------<<<<<
                // --- ADD 2008/09/08 -------------------------------->>>>>
                 && (this.CrMode1 == target.CrMode1)
                 && (this.CrMode2 == target.CrMode2)
                // --- ADD 2008/09/08 --------------------------------<<<<<
				 && (this.ConstUnit == target.ConstUnit)
				 && (this.ConstUnitName == target.ConstUnitName)
				 && (this.TtlTypeName == target.TtlTypeName));
		}

		/// <summary>
		/// 売上月報年報抽出条件クラス比較処理
		/// </summary>
		/// <param name="salesMonthYearReportCndtn1">
		///                    比較するSalesMonthYearReportCndtnクラスのインスタンス
		/// </param>
		/// <param name="salesMonthYearReportCndtn2">比較するSalesMonthYearReportCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesMonthYearReportCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SalesMonthYearReportCndtn salesMonthYearReportCndtn1, SalesMonthYearReportCndtn salesMonthYearReportCndtn2)
		{
			return ((salesMonthYearReportCndtn1.EnterpriseCode == salesMonthYearReportCndtn2.EnterpriseCode)
				 && (salesMonthYearReportCndtn1.SectionCodes == salesMonthYearReportCndtn2.SectionCodes)
                 //--- DEL 2008.08.14 ---------->>>>>
                 //&& (salesMonthYearReportCndtn1.SectionDiv == salesMonthYearReportCndtn2.SectionDiv)
                 //&& (salesMonthYearReportCndtn1.SectionCodeSt == salesMonthYearReportCndtn2.SectionCodeSt)
                 //&& (salesMonthYearReportCndtn1.SectionCodeEd == salesMonthYearReportCndtn2.SectionCodeEd)
                 //&& (salesMonthYearReportCndtn1.SubSectionCodeSt == salesMonthYearReportCndtn2.SubSectionCodeSt)
                 //&& (salesMonthYearReportCndtn1.SubSectionCodeEd == salesMonthYearReportCndtn2.SubSectionCodeEd)
                 //&& (salesMonthYearReportCndtn1.MinSectionCodeSt == salesMonthYearReportCndtn2.MinSectionCodeSt)
                 //&& (salesMonthYearReportCndtn1.MinSectionCodeEd == salesMonthYearReportCndtn2.MinSectionCodeEd)
                 //--- DEL 2008.08.14 ----------<<<<<
                 && (salesMonthYearReportCndtn1.TtlType == salesMonthYearReportCndtn2.TtlType)
				 && (salesMonthYearReportCndtn1.AddUpYearMonthSt == salesMonthYearReportCndtn2.AddUpYearMonthSt)
				 && (salesMonthYearReportCndtn1.AddUpYearMonthEd == salesMonthYearReportCndtn2.AddUpYearMonthEd)
                 //--- DEL 2008.08.14 ---------->>>>>
                 //&& (salesMonthYearReportCndtn1.AnnualAddUpYearMonthSt == salesMonthYearReportCndtn2.AnnualAddUpYearMonthSt)
                 //&& (salesMonthYearReportCndtn1.AnnualAddUpYaerMonthEd == salesMonthYearReportCndtn2.AnnualAddUpYaerMonthEd)
                 //--- DEL 2008.08.14 ----------<<<<<
                 && (salesMonthYearReportCndtn1.CustomerCodeSt == salesMonthYearReportCndtn2.CustomerCodeSt)
				 && (salesMonthYearReportCndtn1.CustomerCodeEd == salesMonthYearReportCndtn2.CustomerCodeEd)
                 //--- DEL 2008.08.14 ---------->>>>>
                // --- ADD 2008/09/08 -------------------------------->>>>>
                && (salesMonthYearReportCndtn1.SearchCodeSt == salesMonthYearReportCndtn2.SearchCodeSt)
                 && (salesMonthYearReportCndtn1.SearchCodeEd == salesMonthYearReportCndtn2.SearchCodeEd)
                // --- ADD 2008/09/08 --------------------------------<<<<<
                 //&& (salesMonthYearReportCndtn1.SalesEmployeeCdSt == salesMonthYearReportCndtn2.SalesEmployeeCdSt)
                 //&& (salesMonthYearReportCndtn1.SalesEmployeeCdEd == salesMonthYearReportCndtn2.SalesEmployeeCdEd)
                 //&& (salesMonthYearReportCndtn1.FrontEmployeeCdSt == salesMonthYearReportCndtn2.FrontEmployeeCdSt)
                 //&& (salesMonthYearReportCndtn1.FrontEmployeeCdEd == salesMonthYearReportCndtn2.FrontEmployeeCdEd)
                 //&& (salesMonthYearReportCndtn1.SalesInputCodeSt == salesMonthYearReportCndtn2.SalesInputCodeSt)
                 //&& (salesMonthYearReportCndtn1.SalesInputCodeEd == salesMonthYearReportCndtn2.SalesInputCodeEd)
                 //&& (salesMonthYearReportCndtn1.SalesAreaCodeSt == salesMonthYearReportCndtn2.SalesAreaCodeSt)
                 //&& (salesMonthYearReportCndtn1.SalesAreaCodeEd == salesMonthYearReportCndtn2.SalesAreaCodeEd)
                 //&& (salesMonthYearReportCndtn1.BusinessTypeCodeSt == salesMonthYearReportCndtn2.BusinessTypeCodeSt)
                 //&& (salesMonthYearReportCndtn1.BusinessTypeCodeEd == salesMonthYearReportCndtn2.BusinessTypeCodeEd)
                 //&& (salesMonthYearReportCndtn1.GoodsMakerCdSt == salesMonthYearReportCndtn2.GoodsMakerCdSt)
                 //&& (salesMonthYearReportCndtn1.GoodsMakerCdEd == salesMonthYearReportCndtn2.GoodsMakerCdEd)
                 //--- DEL 2008.08.14 ----------<<<<<
                 && (salesMonthYearReportCndtn1.TotalType == salesMonthYearReportCndtn2.TotalType)
				 && (salesMonthYearReportCndtn1.TotalTypeName == salesMonthYearReportCndtn2.TotalTypeName)
				 && (salesMonthYearReportCndtn1.PrintType == salesMonthYearReportCndtn2.PrintType)
				 && (salesMonthYearReportCndtn1.PrintTypeName == salesMonthYearReportCndtn2.PrintTypeName)
				 && (salesMonthYearReportCndtn1.MoneyUnit == salesMonthYearReportCndtn2.MoneyUnit)
				 && (salesMonthYearReportCndtn1.MoneyUnitName == salesMonthYearReportCndtn2.MoneyUnitName)
                // --- DEL 2008/09/08 -------------------------------->>>>>
                //&& (salesMonthYearReportCndtn1.CrMode == salesMonthYearReportCndtn2.CrMode)
                // --- DEL 2008/09/08 --------------------------------<<<<<
                // --- ADD 2008/09/08 -------------------------------->>>>>
                 && (salesMonthYearReportCndtn1.CrMode1 == salesMonthYearReportCndtn2.CrMode1)
                  && (salesMonthYearReportCndtn1.CrMode2 == salesMonthYearReportCndtn2.CrMode2)
                // --- ADD 2008/09/08 --------------------------------<<<<<
				 
				 && (salesMonthYearReportCndtn1.ConstUnit == salesMonthYearReportCndtn2.ConstUnit)
				 && (salesMonthYearReportCndtn1.ConstUnitName == salesMonthYearReportCndtn2.ConstUnitName)
				 && (salesMonthYearReportCndtn1.TtlTypeName == salesMonthYearReportCndtn2.TtlTypeName));
		}
		/// <summary>
		/// 売上月報年報抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesMonthYearReportCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesMonthYearReportCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SalesMonthYearReportCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
            //--- DEL 2008.08.14 ---------->>>>>
            //if (this.SectionDiv != target.SectionDiv) resList.Add("SectionDiv");
            //if(this.SectionCodeSt != target.SectionCodeSt)resList.Add("SectionCodeSt");
            //if(this.SectionCodeEd != target.SectionCodeEd)resList.Add("SectionCodeEd");
            //if(this.SubSectionCodeSt != target.SubSectionCodeSt)resList.Add("SubSectionCodeSt");
            //if(this.SubSectionCodeEd != target.SubSectionCodeEd)resList.Add("SubSectionCodeEd");
            //if(this.MinSectionCodeSt != target.MinSectionCodeSt)resList.Add("MinSectionCodeSt");
            //if(this.MinSectionCodeEd != target.MinSectionCodeEd)resList.Add("MinSectionCodeEd");
            //--- DEL 2008.08.14 ----------<<<<<
            if (this.TtlType != target.TtlType) resList.Add("TtlType");
			if(this.AddUpYearMonthSt != target.AddUpYearMonthSt)resList.Add("AddUpYearMonthSt");
			if(this.AddUpYearMonthEd != target.AddUpYearMonthEd)resList.Add("AddUpYearMonthEd");
            //--- DEL 2008.08.14 ---------->>>>>
            //if (this.AnnualAddUpYearMonthSt != target.AnnualAddUpYearMonthSt) resList.Add("AnnualAddUpYearMonthSt");
            //if(this.AnnualAddUpYaerMonthEd != target.AnnualAddUpYaerMonthEd)resList.Add("AnnualAddUpYaerMonthEd");
            //--- DEL 2008.08.14 ----------<<<<<
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
            //--- DEL 2008.08.14 ---------->>>>>
            // --- ADD 2008/09/08 -------------------------------->>>>>
            if (this.SearchCodeSt != target.SearchCodeSt) resList.Add("SearchCodeSt");
            if (this.SearchCodeEd != target.SearchCodeEd) resList.Add("SearchCodeEd");
            // --- ADD 2008/09/08 --------------------------------<<<<<
            //if (this.SalesEmployeeCdSt != target.SalesEmployeeCdSt) resList.Add("SalesEmployeeCdSt");
            //if(this.SalesEmployeeCdEd != target.SalesEmployeeCdEd)resList.Add("SalesEmployeeCdEd");
            //if(this.FrontEmployeeCdSt != target.FrontEmployeeCdSt)resList.Add("FrontEmployeeCdSt");
            //if(this.FrontEmployeeCdEd != target.FrontEmployeeCdEd)resList.Add("FrontEmployeeCdEd");
            //if(this.SalesInputCodeSt != target.SalesInputCodeSt)resList.Add("SalesInputCodeSt");
            //if(this.SalesInputCodeEd != target.SalesInputCodeEd)resList.Add("SalesInputCodeEd");
            //if(this.SalesAreaCodeSt != target.SalesAreaCodeSt)resList.Add("SalesAreaCodeSt");
            //if(this.SalesAreaCodeEd != target.SalesAreaCodeEd)resList.Add("SalesAreaCodeEd");
            //if(this.BusinessTypeCodeSt != target.BusinessTypeCodeSt)resList.Add("BusinessTypeCodeSt");
            //if(this.BusinessTypeCodeEd != target.BusinessTypeCodeEd)resList.Add("BusinessTypeCodeEd");
            //if(this.GoodsMakerCdSt != target.GoodsMakerCdSt)resList.Add("GoodsMakerCdSt");
            //if(this.GoodsMakerCdEd != target.GoodsMakerCdEd)resList.Add("GoodsMakerCdEd");
            //--- DEL 2008.08.14 ----------<<<<<
            if (this.TotalType != target.TotalType) resList.Add("TotalType");
			if(this.TotalTypeName != target.TotalTypeName)resList.Add("TotalTypeName");
			if(this.PrintType != target.PrintType)resList.Add("PrintType");
			if(this.PrintTypeName != target.PrintTypeName)resList.Add("PrintTypeName");
			if(this.MoneyUnit != target.MoneyUnit)resList.Add("MoneyUnit");
			if(this.MoneyUnitName != target.MoneyUnitName)resList.Add("MoneyUnitName");
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //if (this.CrMode != target.CrMode) resList.Add("CrMode");
            // --- DEL 2008/09/08 --------------------------------<<<<< 
            // --- ADD 2008/09/08 -------------------------------->>>>>
            if (this.CrMode1 != target.CrMode1) resList.Add("CrMode1");
            if (this.CrMode2 != target.CrMode2) resList.Add("CrMode2");
            // --- ADD 2008/09/08 --------------------------------<<<<< 
			if(this.ConstUnit != target.ConstUnit)resList.Add("ConstUnit");
			if(this.ConstUnitName != target.ConstUnitName)resList.Add("ConstUnitName");
			if(this.TtlTypeName != target.TtlTypeName)resList.Add("TtlTypeName");

			return resList;
		}

		/// <summary>
		/// 売上月報年報抽出条件クラス比較処理
		/// </summary>
		/// <param name="salesMonthYearReportCndtn1">比較するSalesMonthYearReportCndtnクラスのインスタンス</param>
		/// <param name="salesMonthYearReportCndtn2">比較するSalesMonthYearReportCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesMonthYearReportCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SalesMonthYearReportCndtn salesMonthYearReportCndtn1, SalesMonthYearReportCndtn salesMonthYearReportCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(salesMonthYearReportCndtn1.EnterpriseCode != salesMonthYearReportCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(salesMonthYearReportCndtn1.SectionCodes != salesMonthYearReportCndtn2.SectionCodes)resList.Add("SectionCodes");
            //--- DEL 2008.08.14 ---------->>>>>
            //if (salesMonthYearReportCndtn1.SectionDiv != salesMonthYearReportCndtn2.SectionDiv) resList.Add("SectionDiv");
            //if(salesMonthYearReportCndtn1.SectionCodeSt != salesMonthYearReportCndtn2.SectionCodeSt)resList.Add("SectionCodeSt");
            //if(salesMonthYearReportCndtn1.SectionCodeEd != salesMonthYearReportCndtn2.SectionCodeEd)resList.Add("SectionCodeEd");
            //if(salesMonthYearReportCndtn1.SubSectionCodeSt != salesMonthYearReportCndtn2.SubSectionCodeSt)resList.Add("SubSectionCodeSt");
            //if(salesMonthYearReportCndtn1.SubSectionCodeEd != salesMonthYearReportCndtn2.SubSectionCodeEd)resList.Add("SubSectionCodeEd");
            //if(salesMonthYearReportCndtn1.MinSectionCodeSt != salesMonthYearReportCndtn2.MinSectionCodeSt)resList.Add("MinSectionCodeSt");
            //if(salesMonthYearReportCndtn1.MinSectionCodeEd != salesMonthYearReportCndtn2.MinSectionCodeEd)resList.Add("MinSectionCodeEd");
            //--- DEL 2008.08.14 ----------<<<<<
            if (salesMonthYearReportCndtn1.TtlType != salesMonthYearReportCndtn2.TtlType) resList.Add("TtlType");
			if(salesMonthYearReportCndtn1.AddUpYearMonthSt != salesMonthYearReportCndtn2.AddUpYearMonthSt)resList.Add("AddUpYearMonthSt");
			if(salesMonthYearReportCndtn1.AddUpYearMonthEd != salesMonthYearReportCndtn2.AddUpYearMonthEd)resList.Add("AddUpYearMonthEd");
            //--- DEL 2008.08.14 ---------->>>>>
            //if (salesMonthYearReportCndtn1.AnnualAddUpYearMonthSt != salesMonthYearReportCndtn2.AnnualAddUpYearMonthSt) resList.Add("AnnualAddUpYearMonthSt");
            //if(salesMonthYearReportCndtn1.AnnualAddUpYaerMonthEd != salesMonthYearReportCndtn2.AnnualAddUpYaerMonthEd)resList.Add("AnnualAddUpYaerMonthEd");
            //--- DEL 2008.08.14 ----------<<<<<
            if (salesMonthYearReportCndtn1.CustomerCodeSt != salesMonthYearReportCndtn2.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(salesMonthYearReportCndtn1.CustomerCodeEd != salesMonthYearReportCndtn2.CustomerCodeEd)resList.Add("CustomerCodeEd");
            //--- DEL 2008.08.14 ---------->>>>>
            // --- ADD 2008/09/08 -------------------------------->>>>>
            if (salesMonthYearReportCndtn1.SearchCodeSt != salesMonthYearReportCndtn2.SearchCodeSt) resList.Add("SearchCodeSt");
            if (salesMonthYearReportCndtn1.SearchCodeEd != salesMonthYearReportCndtn2.SearchCodeEd) resList.Add("SearchCodeEd");
            // --- ADD 2008/09/08 --------------------------------<<<<<
            //if(salesMonthYearReportCndtn1.SalesEmployeeCdSt != salesMonthYearReportCndtn2.SalesEmployeeCdSt)resList.Add("SalesEmployeeCdSt");
            //if(salesMonthYearReportCndtn1.SalesEmployeeCdEd != salesMonthYearReportCndtn2.SalesEmployeeCdEd)resList.Add("SalesEmployeeCdEd");
            //if(salesMonthYearReportCndtn1.FrontEmployeeCdSt != salesMonthYearReportCndtn2.FrontEmployeeCdSt)resList.Add("FrontEmployeeCdSt");
            //if(salesMonthYearReportCndtn1.FrontEmployeeCdEd != salesMonthYearReportCndtn2.FrontEmployeeCdEd)resList.Add("FrontEmployeeCdEd");
            //if(salesMonthYearReportCndtn1.SalesInputCodeSt != salesMonthYearReportCndtn2.SalesInputCodeSt)resList.Add("SalesInputCodeSt");
            //if(salesMonthYearReportCndtn1.SalesInputCodeEd != salesMonthYearReportCndtn2.SalesInputCodeEd)resList.Add("SalesInputCodeEd");
            //if(salesMonthYearReportCndtn1.SalesAreaCodeSt != salesMonthYearReportCndtn2.SalesAreaCodeSt)resList.Add("SalesAreaCodeSt");
            //if(salesMonthYearReportCndtn1.SalesAreaCodeEd != salesMonthYearReportCndtn2.SalesAreaCodeEd)resList.Add("SalesAreaCodeEd");
            //if(salesMonthYearReportCndtn1.BusinessTypeCodeSt != salesMonthYearReportCndtn2.BusinessTypeCodeSt)resList.Add("BusinessTypeCodeSt");
            //if(salesMonthYearReportCndtn1.BusinessTypeCodeEd != salesMonthYearReportCndtn2.BusinessTypeCodeEd)resList.Add("BusinessTypeCodeEd");
            //if(salesMonthYearReportCndtn1.GoodsMakerCdSt != salesMonthYearReportCndtn2.GoodsMakerCdSt)resList.Add("GoodsMakerCdSt");
            //if(salesMonthYearReportCndtn1.GoodsMakerCdEd != salesMonthYearReportCndtn2.GoodsMakerCdEd)resList.Add("GoodsMakerCdEd");
            //--- DEL 2008.08.14 ----------<<<<<
            if (salesMonthYearReportCndtn1.TotalType != salesMonthYearReportCndtn2.TotalType) resList.Add("TotalType");
			if(salesMonthYearReportCndtn1.TotalTypeName != salesMonthYearReportCndtn2.TotalTypeName)resList.Add("TotalTypeName");
			if(salesMonthYearReportCndtn1.PrintType != salesMonthYearReportCndtn2.PrintType)resList.Add("PrintType");
			if(salesMonthYearReportCndtn1.PrintTypeName != salesMonthYearReportCndtn2.PrintTypeName)resList.Add("PrintTypeName");
			if(salesMonthYearReportCndtn1.MoneyUnit != salesMonthYearReportCndtn2.MoneyUnit)resList.Add("MoneyUnit");
			if(salesMonthYearReportCndtn1.MoneyUnitName != salesMonthYearReportCndtn2.MoneyUnitName)resList.Add("MoneyUnitName");
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //if(salesMonthYearReportCndtn1.CrMode != salesMonthYearReportCndtn2.CrMode)resList.Add("CrMode");
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            if (salesMonthYearReportCndtn1.CrMode1 != salesMonthYearReportCndtn2.CrMode1) resList.Add("CrMode1");
            if (salesMonthYearReportCndtn1.CrMode2 != salesMonthYearReportCndtn2.CrMode2) resList.Add("CrMode2");
            // --- ADD 2008/09/08 --------------------------------<<<<< 
			if(salesMonthYearReportCndtn1.ConstUnit != salesMonthYearReportCndtn2.ConstUnit)resList.Add("ConstUnit");
			if(salesMonthYearReportCndtn1.ConstUnitName != salesMonthYearReportCndtn2.ConstUnitName)resList.Add("ConstUnitName");
			if(salesMonthYearReportCndtn1.TtlTypeName != salesMonthYearReportCndtn2.TtlTypeName)resList.Add("TtlTypeName");

			return resList;
		}

        //--- ADD 2008/08/14 ---------->>>>>
        #region ◆ 印刷順列挙体
        /// <summary> 印刷順列挙体 </summary>
        public enum PrintOrderDivState
        {
            /// <summary> コード </summary>
            Code = 0,
            /// <summary> 順位 </summary>
            Order = 1,
        }
        #endregion

        #region ◆ 順位指定列挙体
        /// <summary> 順位指定列挙体 </summary>
        public enum OrderAppointmentDivState
        {
            /// <summary> 純売上 </summary>
            Sales = 0,
            /// <summary> 粗利 </summary>
            GrossProfit = 1,
            /// <summary> 返品 </summary>
            SalesRetGoods = 2,
        }
        #endregion

        #region ◆ 順位指定列挙体
        /// <summary> 順位指定列挙体 </summary>
        public enum StockOrderDivState
        {
            /// <summary> 上位 </summary>
            High = 0,
            /// <summary> 下位 </summary>
            Low = 1,
        }
        #endregion

        // --- ADD 2008/09/08 -------------------------------->>>>>
        #region ◆ 集計単位列挙体
        /// <summary> 集計単位列挙体 </summary>
        public enum TotalTypeEnum
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
            SalesDivision = 6
        }
        // --- ADD 2008/09/08 --------------------------------<<<<<
        #endregion
    }
}
