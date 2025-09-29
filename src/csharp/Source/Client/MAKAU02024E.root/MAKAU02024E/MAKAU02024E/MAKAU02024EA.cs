using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DemandTotal
	/// <summary>
	///                      請求書(鑑部)抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求書(鑑部)抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/07/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   20081 疋田 勇人</br>
    /// <br>                 :   2007.10.15 DC.NS用に変更</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote       : PM.NS対応</br>
    /// <br>Programmer       : 犬飼</br>
    /// <br>Date	         : 2008.09.04</br>
    /// <br>Note             : 11570208-00 軽減税率対応</br>
    /// <br>Programmer       : 陳艶丹</br>
    /// <br>Date             : 2020/04/13</br>
    /// </remarks>
	public class ExtrInfo_DemandTotal
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>全社選択</summary>
		/// <remarks>true:全社選択 false:各拠点選択</remarks>
		private bool _isSelectAllSection;

		/// <summary>全拠点レコード出力</summary>
		/// <remarks>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</remarks>
		private bool _isOutputAllSecRec;

        // 2008.10.17 30413 犬飼 実績計上拠点コードリストの型を変更 >>>>>>START
        ///// <summary>実績計上拠点コードリスト</summary>
        ///// <remarks>文字型　※配列項目</remarks>
        //private ArrayList _resultsAddUpSecList;
        /// <summary>実績計上拠点コードリスト</summary>
        /// <remarks>文字型　※配列項目 全社指定は{""}</remarks>
        private string[] _resultsAddUpSecList;
        // 2008.10.17 30413 犬飼 実績計上拠点コードリストの型を変更 <<<<<<END
        
		/// <summary>拠点オプション導入区分</summary>
		/// <remarks>true:導入済, false:未導入</remarks>
		private bool _isOptSection;

		/// <summary>本社機能プロパティ</summary>
		/// <remarks>true:本社, false:拠点</remarks>
		private bool _isMainOfficeFunc;

        // 2008.09.08 30413 犬飼 計上年月日の型を変更 >>>>>>START
        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 請求締を行なった日（相手先基準）</remarks>
        private DateTime _addUpDate;
        // 2008.09.08 30413 犬飼 計上年月日の型を変更 <<<<<<END
        
        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// <summary>計上年月日</summary>
        ///// <remarks>YYYYMMDD 請求締を行なった日（相手先基準）</remarks>
        //private Int32 _targetAddUpDate;

        ///// <summary>締日</summary>
        ///// <remarks>DD</remarks>
        //private Int32 _totalDay;

        ///// <summary>得意先締末尾指定</summary>
        ///// <remarks>true:28～31全て false:指定締日のみ</remarks>
        //private bool _isLastDay;
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            
		/// <summary>得意先コード(開始)</summary>
		private Int32 _customerCodeSt;

		/// <summary>得意先コード(終了)</summary>
		private Int32 _customerCodeEd;

        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// <summary>得意先カナ(開始)</summary>
        //private string _kanaSt = "";

        ///// <summary>得意先カナ(終了)</summary>
        //private string _kanaEd = "";
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        
        // 2007.10.15 hikita del start -------------------------------------->>
        ///// <summary>個人・法人区分リスト</summary>
        ///// <remarks>個人・法人区分コード配列</remarks>
        //private Int32[] _corporateDivCodeList;           

        ///// <summary>個人・法人区分全選択</summary>
        ///// <remarks>true:全選択 false:各選択</remarks>
        //private bool _isSelectAllCorporateDiv;           
        // 2007.10.15 hikita del end ----------------------------------------<<

        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// <summary>担当者毎改ページ区分</summary>
        ///// <remarks>(請求一覧表のみ)true:担当者で改ページ false:担当者で改ページしない</remarks>
        //private bool _isEmployeeNextPage;

        ///// <summary>請求書出力区分</summary>
        ///// <remarks>true:「請求書発行する」得意先のみ false:全て</remarks>
        //private bool _isJudgeBillOutputCode;
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        
		/// <summary>担当区分</summary>
		private Int32 _customerAgentDivCd;

		/// <summary>集金担当コード(開始)</summary>
		/// <remarks>文字型</remarks>
		private string _billCollecterCdSt = "";

		/// <summary>集金担当コード(終了)</summary>
		/// <remarks>文字型</remarks>
		private string _billCollecterCdEd = "";

		/// <summary>顧客担当コード(開始)</summary>
		/// <remarks>文字型</remarks>
		private string _customerAgentCdSt = "";

		/// <summary>顧客担当コード(終了)</summary>
		/// <remarks>文字型</remarks>
		private string _customerAgentCdEd = "";

        // 2007.10.15 hikita del start -------------------------------------->>
        ///// <summary>得意先分析コード1(開始)</summary>
        //private Int32 _custAnalysCode1St;

        ///// <summary>得意先分析コード1(終了)</summary>
        //private Int32 _custAnalysCode1Ed;

        ///// <summary>得意先分析コード2(開始)</summary>
        //private Int32 _custAnalysCode2St;

        ///// <summary>得意先分析コード2(終了)</summary>
        //private Int32 _custAnalysCode2Ed;

        ///// <summary>得意先分析コード3(開始)</summary>
        //private Int32 _custAnalysCode3St;

        ///// <summary>得意先分析コード3(終了)</summary>
        //private Int32 _custAnalysCode3Ed;

        ///// <summary>得意先分析コード4(開始)</summary>
        //private Int32 _custAnalysCode4St;

        ///// <summary>得意先分析コード4(終了)</summary>
        //private Int32 _custAnalysCode4Ed;

        ///// <summary>得意先分析コード5(開始)</summary>
        //private Int32 _custAnalysCode5St;

        ///// <summary>得意先分析コード5(終了)</summary>
        //private Int32 _custAnalysCode5Ed;

        ///// <summary>得意先分析コード6(開始)</summary>
        //private Int32 _custAnalysCode6St;

        ///// <summary>得意先分析コード6(終了)</summary>
        //private Int32 _custAnalysCode6Ed;
        // 2007.10.15 hikita del end ----------------------------------------<<

        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// <summary>請求書発行得意先フラグ</summary>
        //private bool _isBillOutputOnly;
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        
		/// <summary>出力順</summary>
		private Int32 _sortOrder;

        ///// <summary>個人・法人区分名称リスト</summary>
        //private ArrayList _corporateDivNameList;         // 2007.10.15 hikita del

        /// <summary>出力金額条件</summary>
		private Int32 _outPutPriceCond;

        // 2007.10.15 hikita add start ------------------------------------------>>
        /// <summary>請求内訳</summary>
        private Int32 _dmdDtl;
        // 2007.10.15 hikita add end --------------------------------------------<<

        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// <summary>伝票計印字選択</summary>
        //private bool _slipTotalPrt;

        ///// <summary>売上日計印字選択</summary>
        //private bool _addUpDateTotalPrt;

        ///// <summary>得意先計印字選択</summary>
        //private bool _customerTotalPrt;
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        
        ///// <summary>キャリア計印字選択</summary>
        //private bool _carrierTotalPrt;                   // 2007.10.15 hikita del 

        // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
        /// <summary>改頁</summary>
        private Int32 _newPageDiv;

        /// <summary>販売エリアコード(開始)</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>販売エリアコード(終了)</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>回収率印字</summary>
        private Int32 _collectRatePrtDiv;

        /// <summary>残高入金内訳</summary>
        private Int32 _balanceDepositDtl;

        /// <summary>請求書発行得意先フラグ</summary>
        private bool _isBillOutputOnly;

        /// <summary>伝票印刷種別</summary>
        private Int32 _slipPrtKind;

        /// <summary>発行日</summary>
        private DateTime _issueDay;
        // 2008.09.05 30413 犬飼 項目追加 <<<<<<END

        /// <summary>親得意先内訳</summary>
        private Int32 _prCustDtl;

        /// <summary>売掛区分</summary>
        private Int32 _accRecDivCd;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        //---ADD 2011/03/14------------->>>>>
        /// <summary>
        /// 空白行印字
        /// </summary>
        private Int32 _printBlLiDiv;

        /// <summary>
        /// 罫線印字
        /// </summary>
        private Int32 _lineMaSqOfChDiv;
        //---ADD 2011/03/14-------------<<<<<

        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
        /// <summary>消費税別の内訳区分</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>税率1</summary>
        /// <remarks>税率1</remarks>
        private Double _taxRate1;

        /// <summary>税率2</summary>
        /// <remarks>税率2</remarks>
        private Double _taxRate2;
        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<


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

		/// public propaty name  :  IsSelectAllSection
		/// <summary>全社選択プロパティ</summary>
		/// <value>true:全社選択 false:各拠点選択</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全社選択プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsSelectAllSection
		{
			get{return _isSelectAllSection;}
			set{_isSelectAllSection = value;}
		}

		/// public propaty name  :  IsOutputAllSecRec
		/// <summary>全拠点レコード出力プロパティ</summary>
		/// <value>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全拠点レコード出力プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsOutputAllSecRec
		{
			get{return _isOutputAllSecRec;}
			set{_isOutputAllSecRec = value;}
		}

        // 2008.10.17 30413 犬飼 実績計上拠点コードリストの型を変更 >>>>>>START
        ///// public propaty name  :  ResultsAddUpSecList
        ///// <summary>実績計上拠点コードリストプロパティ</summary>
        ///// <value>文字型　※配列項目</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   実績計上拠点コードリストプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public ArrayList ResultsAddUpSecList
        //{
        //    get{return _resultsAddUpSecList;}
        //    set{_resultsAddUpSecList = value;}
        //}
        /// public propaty name  :  ResultsAddUpSecList
        /// <summary>実績計上拠点コードリストプロパティ</summary>
        /// <value>文字型　※配列項目 全社指定は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績計上拠点コードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] ResultsAddUpSecList
        {
            get { return _resultsAddUpSecList; }
            set { _resultsAddUpSecList = value; }
        }
        // 2008.10.17 30413 犬飼 実績計上拠点コードリストの型を変更 <<<<<<END
        
		/// public propaty name  :  IsOptSection
		/// <summary>拠点オプション導入区分プロパティ</summary>
		/// <value>true:導入済, false:未導入</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点オプション導入区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsOptSection
		{
			get{return _isOptSection;}
			set{_isOptSection = value;}
		}

		/// public propaty name  :  IsMainOfficeFunc
		/// <summary>本社機能プロパティプロパティ</summary>
		/// <value>true:本社, false:拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   本社機能プロパティプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsMainOfficeFunc
		{
			get{return _isMainOfficeFunc;}
			set{_isMainOfficeFunc = value;}
		}

        // 2008.09.08 30413 犬飼 計上年月日の型を変更 >>>>>>START
        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD 請求締を行なった日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }
        // 2008.09.08 30413 犬飼 計上年月日の型を変更 <<<<<<END
        
        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// public propaty name  :  TargetAddUpDate
        ///// <summary>計上年月日プロパティ</summary>
        ///// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   計上年月日プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 TargetAddUpDate
        //{
        //    get { return _targetAddUpDate; }
        //    set { _targetAddUpDate = value; }
        //}

        ///// public propaty name  :  TotalDay
        ///// <summary>締日プロパティ</summary>
        ///// <value>DD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   締日プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 TotalDay
        //{
        //    get{return _totalDay;}
        //    set{_totalDay = value;}
        //}

        ///// public propaty name  :  IsLastDay
        ///// <summary>得意先締末尾指定プロパティ</summary>
        ///// <value>true:28～31全て false:指定締日のみ</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先締末尾指定プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool IsLastDay
        //{
        //    get{return _isLastDay;}
        //    set{_isLastDay = value;}
        //}
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        
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

        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// public propaty name  :  KanaSt
        ///// <summary>得意先カナ(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先カナ(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string KanaSt
        //{
        //    get{return _kanaSt;}
        //    set{_kanaSt = value;}
        //}

        ///// public propaty name  :  KanaEd
        ///// <summary>得意先カナ(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先カナ(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string KanaEd
        //{
        //    get{return _kanaEd;}
        //    set{_kanaEd = value;}
        //}
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        
        // 2007.10.15 hikita del start --------------------------------------------->>
        ///// public propaty name  :  CorporateDivCodeList
        ///// <summary>個人・法人区分リストプロパティ</summary>
        ///// <value>個人・法人区分コード配列</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   個人・法人区分リストプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32[] CorporateDivCodeList
        //{
        //    get{return _corporateDivCodeList;}
        //    set{_corporateDivCodeList = value;}
        //}

        ///// public propaty name  :  IsSelectAllCorporateDiv
        ///// <summary>個人・法人区分全選択プロパティ</summary>
        ///// <value>true:全選択 false:各選択</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   個人・法人区分全選択プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool IsSelectAllCorporateDiv
        //{
        //    get{return _isSelectAllCorporateDiv;}
        //    set{_isSelectAllCorporateDiv = value;}
        //}
        // 2007.10.15 hikita del end ------------------------------------------------<<

        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// public propaty name  :  IsEmployeeNextPage
        ///// <summary>担当者毎改ページ区分プロパティ</summary>
        ///// <value>(請求一覧表のみ)true:担当者で改ページ false:担当者で改ページしない</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   担当者毎改ページ区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool IsEmployeeNextPage
        //{
        //    get{return _isEmployeeNextPage;}
        //    set{_isEmployeeNextPage = value;}
        //}

        ///// public propaty name  :  IsJudgeBillOutputCode
        ///// <summary>請求書出力区分プロパティ</summary>
        ///// <value>true:「請求書発行する」得意先のみ false:全て</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   請求書出力区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool IsJudgeBillOutputCode
        //{
        //    get{return _isJudgeBillOutputCode;}
        //    set{_isJudgeBillOutputCode = value;}
        //}
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        
		/// public propaty name  :  CustomerAgentDivCd
		/// <summary>担当区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   担当区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerAgentDivCd
		{
			get{return _customerAgentDivCd;}
			set{_customerAgentDivCd = value;}
		}

		/// public propaty name  :  BillCollecterCdSt
		/// <summary>集金担当コード(開始)プロパティ</summary>
		/// <value>文字型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金担当コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BillCollecterCdSt
		{
			get{return _billCollecterCdSt;}
			set{_billCollecterCdSt = value;}
		}

		/// public propaty name  :  BillCollecterCdEd
		/// <summary>集金担当コード(終了)プロパティ</summary>
		/// <value>文字型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金担当コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BillCollecterCdEd
		{
			get{return _billCollecterCdEd;}
			set{_billCollecterCdEd = value;}
		}

		/// public propaty name  :  CustomerAgentCdSt
		/// <summary>顧客担当コード(開始)プロパティ</summary>
		/// <value>文字型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   顧客担当コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerAgentCdSt
		{
			get{return _customerAgentCdSt;}
			set{_customerAgentCdSt = value;}
		}

		/// public propaty name  :  CustomerAgentCdEd
		/// <summary>顧客担当コード(終了)プロパティ</summary>
		/// <value>文字型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   顧客担当コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerAgentCdEd
		{
			get{return _customerAgentCdEd;}
			set{_customerAgentCdEd = value;}
		}

        // 2007.10.15 hikita del start ---------------------------------------------->>
        ///// public propaty name  :  CustAnalysCode1St
        ///// <summary>得意先分析コード1(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード1(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode1St
        //{
        //    get{return _custAnalysCode1St;}
        //    set{_custAnalysCode1St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode1Ed
        ///// <summary>得意先分析コード1(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード1(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode1Ed
        //{
        //    get{return _custAnalysCode1Ed;}
        //    set{_custAnalysCode1Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode2St
        ///// <summary>得意先分析コード2(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード2(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode2St
        //{
        //    get{return _custAnalysCode2St;}
        //    set{_custAnalysCode2St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode2Ed
        ///// <summary>得意先分析コード2(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード2(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode2Ed
        //{
        //    get{return _custAnalysCode2Ed;}
        //    set{_custAnalysCode2Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode3St
        ///// <summary>得意先分析コード3(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード3(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode3St
        //{
        //    get{return _custAnalysCode3St;}
        //    set{_custAnalysCode3St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode3Ed
        ///// <summary>得意先分析コード3(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード3(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode3Ed
        //{
        //    get{return _custAnalysCode3Ed;}
        //    set{_custAnalysCode3Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode4St
        ///// <summary>得意先分析コード4(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード4(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode4St
        //{
        //    get{return _custAnalysCode4St;}
        //    set{_custAnalysCode4St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode4Ed
        ///// <summary>得意先分析コード4(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード4(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode4Ed
        //{
        //    get{return _custAnalysCode4Ed;}
        //    set{_custAnalysCode4Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode5St
        ///// <summary>得意先分析コード5(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード5(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode5St
        //{
        //    get{return _custAnalysCode5St;}
        //    set{_custAnalysCode5St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode5Ed
        ///// <summary>得意先分析コード5(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード5(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode5Ed
        //{
        //    get{return _custAnalysCode5Ed;}
        //    set{_custAnalysCode5Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode6St
        ///// <summary>得意先分析コード6(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード6(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode6St
        //{
        //    get{return _custAnalysCode6St;}
        //    set{_custAnalysCode6St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode6Ed
        ///// <summary>得意先分析コード6(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先分析コード6(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustAnalysCode6Ed
        //{
        //    get{return _custAnalysCode6Ed;}
        //    set{_custAnalysCode6Ed = value;}
        //}
        // 2007.10.15 hikita del end ------------------------------------------------<<

        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// public propaty name  :  IsBillOutputOnly
        ///// <summary>請求書発行得意先フラグプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   請求書発行得意先フラグプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool IsBillOutputOnly
        //{
        //    get{return _isBillOutputOnly;}
        //    set{_isBillOutputOnly = value;}
        //}
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        
		/// public propaty name  :  SortOrder
		/// <summary>出力順プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortOrder
		{
			get{return _sortOrder;}
			set{_sortOrder = value;}
		}

        // 2007.10.15 hikita del start ---------------------------------------------------->>
        ///// public propaty name  :  CorporateDivNameList
        ///// <summary>個人・法人区分名称リストプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   個人・法人区分名称リストプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public ArrayList CorporateDivNameList
        //{
        //    get{return _corporateDivNameList;}
        //    set{_corporateDivNameList = value;}
        //}
        // 2007.10.15 hikita del end ------------------------------------------------------<<

		/// public propaty name  :  OutPutPriceCond
		/// <summary>出力金額条件プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力金額条件プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OutPutPriceCond
		{
			get{return _outPutPriceCond;}
			set{_outPutPriceCond = value;}
		}

        // 2007.10.15 hikita add start ----------------------------------------------------->>
        /// public propaty name  :  DmdDtl
        /// <summary>請求内訳プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求内訳プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DmdDtl
        {
            get { return _dmdDtl; }
            set { _dmdDtl = value; }
        }
        // 2007.10.15 hikita add end -------------------------------------------------------<<

        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        ///// public propaty name  :  SlipTotalPrt
        ///// <summary>伝票計印字選択プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   伝票計印字選択プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool SlipTotalPrt
        //{
        //    get{return _slipTotalPrt;}
        //    set{_slipTotalPrt = value;}
        //}

        ///// public propaty name  :  AddUpDateTotalPrt
        ///// <summary>売上日計印字選択プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   売上日計印字選択プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool AddUpDateTotalPrt
        //{
        //    get{return _addUpDateTotalPrt;}
        //    set{_addUpDateTotalPrt = value;}
        //}

        ///// public propaty name  :  CustomerTotalPrt
        ///// <summary>得意先計印字選択プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先計印字選択プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool CustomerTotalPrt
        //{
        //    get{return _customerTotalPrt;}
        //    set{_customerTotalPrt = value;}
        //}
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        
        // 2007.10.15 hikita del start -------------------------------------------------->>
        ///// public propaty name  :  CarrierTotalPrt
        ///// <summary>キャリア計印字選択プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   キャリア計印字選択プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool CarrierTotalPrt
        //{
        //    get{return _carrierTotalPrt;}
        //    set{_carrierTotalPrt = value;}
        //}
        // 2007.10.15 hikita del end ----------------------------------------------------<<

        // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
        /// public propaty name  :  NewPageDiv
        /// <summary>改頁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>販売エリアコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>販売エリアコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  CollectRatePrtDiv
        /// <summary>回収率印字プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収率印字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectRatePrtDiv
        {
            get { return _collectRatePrtDiv; }
            set { _collectRatePrtDiv = value; }
        }

        /// public propaty name  :  BalanceDepositDtl
        /// <summary>残高入金内訳プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残高入金内訳プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BalanceDepositDtl
        {
            get { return _balanceDepositDtl; }
            set { _balanceDepositDtl = value; }
        }

        /// public propaty name  :  IsBillOutputOnly
        /// <summary>請求書発行得意先フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行得意先フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsBillOutputOnly
        {
            get { return _isBillOutputOnly; }
            set { _isBillOutputOnly = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>伝票印刷種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }

        /// public propaty name  :  IssueDay
        /// <summary>発行日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime IssueDay
        {
            get { return _issueDay; }
            set { _issueDay = value; }
        }
        // 2008.09.05 30413 犬飼 項目追加 <<<<<<END

        /// public propaty name  :  PrCustDtl
        /// <summary>親得意先内訳プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親得意先内訳プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrCustDtl
        {
            get { return _prCustDtl; }
            set { _prCustDtl = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
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

        //---ADD 2011/03/14------------->>>>>

        /// public propaty name  :  PrintBlLiDiv
        /// <summary>空白行印字プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   空白行印字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintBlLiDiv
        {
            get { return _printBlLiDiv; }
            set { _printBlLiDiv = value; }
        }

        /// public propaty name  :  LineMaSqOfChDiv
        /// <summary>罫線印字プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   罫線印字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LineMaSqOfChDiv
        {
            get { return _lineMaSqOfChDiv; }
            set { _lineMaSqOfChDiv = value; }
        }
        //---ADD 2011/03/14-------------<<<<<

        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
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
        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
		/// <summary>
		/// 請求書(鑑部)抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_DemandTotalクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandTotalクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DemandTotal()
		{
		}

		/// <summary>
		/// 請求書(鑑部)抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="isSelectAllSection">全社選択(true:全社選択 false:各拠点選択)</param>
		/// <param name="isOutputAllSecRec">全拠点レコード出力(true:全拠点レコードを出力する。false:全拠点レコードを出力しない)</param>
		/// <param name="resultsAddUpSecList">実績計上拠点コードリスト(文字型　※配列項目)</param>
		/// <param name="isOptSection">拠点オプション導入区分(true:導入済, false:未導入)</param>
		/// <param name="isMainOfficeFunc">本社機能プロパティ(true:本社, false:拠点)</param>
		/// <param name="targetAddUpDate">計上年月日(YYYYMMDD 請求締を行なった日（相手先基準）)</param>
		/// <param name="totalDay">締日(DD)</param>
		/// <param name="isLastDay">得意先締末尾指定(true:28～31全て false:指定締日のみ)</param>
		/// <param name="customerCodeSt">得意先コード(開始)</param>
		/// <param name="customerCodeEd">得意先コード(終了)</param>
		/// <param name="kanaSt">得意先カナ(開始)</param>
		/// <param name="kanaEd">得意先カナ(終了)</param>
		/// <param name="isEmployeeNextPage">担当者毎改ページ区分((請求一覧表のみ)true:担当者で改ページ false:担当者で改ページしない)</param>
		/// <param name="isJudgeBillOutputCode">請求書出力区分(true:「請求書発行する」得意先のみ false:全て)</param>
		/// <param name="customerAgentDivCd">担当区分</param>
		/// <param name="billCollecterCdSt">集金担当コード(開始)(文字型)</param>
		/// <param name="billCollecterCdEd">集金担当コード(終了)(文字型)</param>
		/// <param name="customerAgentCdSt">顧客担当コード(開始)(文字型)</param>
		/// <param name="customerAgentCdEd">顧客担当コード(終了)(文字型)</param>
		/// <param name="isBillOutputOnly">請求書発行得意先フラグ</param>
		/// <param name="sortOrder">出力順</param>
		/// <param name="outPutPriceCond">出力金額条件</param>
        /// <param name="dmdDtl">請求内訳</param>
        /// <param name="slipTotalPrt">伝票計印字選択</param>
		/// <param name="addUpDateTotalPrt">売上日計印字選択</param>
		/// <param name="customerTotalPrt">得意先計印字選択</param>
        /// <param name="newPageDiv">改頁</param>
        /// <param name="collectRatePrtDiv">回収率印字</param>
        /// <param name="balanceDepositDtl">残高入金内訳</param>
        /// <param name="printBlLiDiv">空白行印字区分</param>
        /// <param name="lineMaSqOfChDiv">罫線印字区分</param>
        /// <param name="taxPrintDiv">税別内訳印字区分</param>
        /// <param name="taxRate1">税率1</param>
        /// <param name="taxRate2">税率2</param>
		/// <returns>ExtrInfo_DemandTotalクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandTotalクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        // 2008.09.05 30413 犬飼 項目変更 >>>>>>START
        //public ExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, ArrayList resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, Int32 targetAddUpDate, Int32 totalDay, bool isLastDay, Int32 customerCodeSt, Int32 customerCodeEd, string kanaSt, string kanaEd, bool isEmployeeNextPage, bool isJudgeBillOutputCode, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, bool isBillOutputOnly, Int32 sortOrder, Int32 outPutPriceCond, Int32 dmdDtl, bool slipTotalPrt, bool addUpDateTotalPrt, bool customerTotalPrt, string enterpriseName)
        //---UPD 2011/03/14------------->>>>>
        //public ExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 dmdDtl, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 prCustDtl, Int32 accRecDivCd, string enterpriseName)
        // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
        //public ExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 dmdDtl, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 prCustDtl, Int32 accRecDivCd, string enterpriseName, Int32 printBlLiDiv, Int32 lineMaSqOfChDiv)
        public ExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 dmdDtl, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 prCustDtl, Int32 accRecDivCd, string enterpriseName, Int32 printBlLiDiv, Int32 lineMaSqOfChDiv, Int32 taxPrintDiv, double taxRate1, double taxRate2)
        // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
        //---UPD 2011/03/14-------------<<<<<
       // 2008.09.05 30413 犬飼 項目変更 <<<<<<END
        {
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._resultsAddUpSecList = resultsAddUpSecList;
			this._isOptSection = isOptSection;
			this._isMainOfficeFunc = isMainOfficeFunc;
            // 2008.09.08 30413 犬飼 計上年月日の型を変更 >>>>>>START
            this._addUpDate = addUpDate;
            // 2008.09.08 30413 犬飼 計上年月日の型を変更 <<<<<<END
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //this._targetAddUpDate = targetAddUpDate;
            //this._totalDay = totalDay;
            //this._isLastDay = isLastDay;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //this._kanaSt = kanaSt;
            //this._kanaEd = kanaEd;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            // 2007.10.15 hikita del start ----------------------------->>
            //this._corporateDivCodeList = corporateDivCodeList;
            //this._isSelectAllCorporateDiv = isSelectAllCorporateDiv;
            // 2007.10.15 hikita del end -------------------------------<<
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //this._isEmployeeNextPage = isEmployeeNextPage;
            //this._isJudgeBillOutputCode = isJudgeBillOutputCode;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            this._customerAgentDivCd = customerAgentDivCd;
			this._billCollecterCdSt = billCollecterCdSt;
			this._billCollecterCdEd = billCollecterCdEd;
			this._customerAgentCdSt = customerAgentCdSt;
			this._customerAgentCdEd = customerAgentCdEd;
            // 2007.10.15 hikita del start ----------------------------->>
            //this._custAnalysCode1St = custAnalysCode1St;
            //this._custAnalysCode1Ed = custAnalysCode1Ed;
            //this._custAnalysCode2St = custAnalysCode2St;
            //this._custAnalysCode2Ed = custAnalysCode2Ed;
            //this._custAnalysCode3St = custAnalysCode3St;
            //this._custAnalysCode3Ed = custAnalysCode3Ed;
            //this._custAnalysCode4St = custAnalysCode4St;
            //this._custAnalysCode4Ed = custAnalysCode4Ed;
            //this._custAnalysCode5St = custAnalysCode5St;
            //this._custAnalysCode5Ed = custAnalysCode5Ed;
            //this._custAnalysCode6St = custAnalysCode6St;
            //this._custAnalysCode6Ed = custAnalysCode6Ed;
            // 2007.10.15 hikita del end -------------------------------<<
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //this._isBillOutputOnly = isBillOutputOnly;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            this._sortOrder = sortOrder;
			//this._corporateDivNameList = corporateDivNameList;   // 2007.10.15 hikita del
			this._outPutPriceCond = outPutPriceCond;
            this._dmdDtl = dmdDtl;                                 // 2007.10.15 hikita add
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //this._slipTotalPrt = slipTotalPrt;
            //this._addUpDateTotalPrt = addUpDateTotalPrt;
            //this._customerTotalPrt = customerTotalPrt;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            //this._carrierTotalPrt = carrierTotalPrt;             // 2007.10.15 hikita del
            // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
            this._newPageDiv = newPageDiv;
            this._salesAreaCodeSt = salesAreaCodeSt;
            this._salesAreaCodeEd = salesAreaCodeEd;
            this._collectRatePrtDiv = collectRatePrtDiv;
            this._balanceDepositDtl = balanceDepositDtl;
            this._isBillOutputOnly = isBillOutputOnly;
            this._slipPrtKind = slipPrtKind;
            this._issueDay = issueDay;
            // 2008.09.05 30413 犬飼 項目追加 <<<<<<END
            this._prCustDtl = prCustDtl;
            this._accRecDivCd = accRecDivCd;
            this._enterpriseName = enterpriseName;
            //---ADD 2011/03/14------------->>>>>
            this.PrintBlLiDiv = printBlLiDiv;
            this.LineMaSqOfChDiv = lineMaSqOfChDiv;
            //---ADD 2011/03/14-------------<<<<<

            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            this._taxPrintDiv = taxPrintDiv;
            this._taxRate1 = taxRate1;
            this._taxRate2 = taxRate2;
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
		}

		/// <summary>
		/// 請求書(鑑部)抽出条件クラス複製処理
		/// </summary>
		/// <returns>ExtrInfo_DemandTotalクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_DemandTotalクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DemandTotal Clone()
		{
            // 2008.09.05 30413 犬飼 項目変更 >>>>>>START
            //return new ExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._targetAddUpDate, this._totalDay, this._isLastDay, this._customerCodeSt, this._customerCodeEd, this._kanaSt, this._kanaEd, this._isEmployeeNextPage, this._isJudgeBillOutputCode, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._isBillOutputOnly, this._sortOrder, this._outPutPriceCond, this._dmdDtl, this._slipTotalPrt, this._addUpDateTotalPrt, this._customerTotalPrt, this._enterpriseName);
            //---UPD 2011/03/14------------->>>>>
            //return new ExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._dmdDtl, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._prCustDtl, this._accRecDivCd, this._enterpriseName);
            // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            //return new ExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._dmdDtl, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._prCustDtl, this._accRecDivCd, this._enterpriseName, this._printBlLiDiv, this._lineMaSqOfChDiv);
            return new ExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._dmdDtl, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._prCustDtl, this._accRecDivCd, this._enterpriseName, this._printBlLiDiv, this._lineMaSqOfChDiv, this._taxPrintDiv, this._taxRate1, this._taxRate2);
            // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
            //---UPD 2011/03/14-------------<<<<<
            // 2008.09.05 30413 犬飼 項目変更 <<<<<<END
        }

		/// <summary>
		/// 請求書(鑑部)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandTotalクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DemandTotal target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
                 //&& (this.ResultsAddUpSecList == target.ResultsAddUpSecList)
                 && (EqualsStrList(this.ResultsAddUpSecList, target.ResultsAddUpSecList))
				 && (this.IsOptSection == target.IsOptSection)
				 && (this.IsMainOfficeFunc == target.IsMainOfficeFunc)
                 // 2008.09.08 30413 犬飼 計上年月日の型を変更 >>>>>>START
                 && (this.AddUpDate == target.AddUpDate)
                 // 2008.09.08 30413 犬飼 計上年月日の型を変更 <<<<<<END
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (this.TargetAddUpDate == target.TargetAddUpDate)
                 //&& (this.TotalDay == target.TotalDay)
                 //&& (this.IsLastDay == target.IsLastDay)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
				 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (this.KanaSt == target.KanaSt)
                 //&& (this.KanaEd == target.KanaEd)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 // 2007.10.15 hikita del start ------------------------------------------->>
                 //&& (this.CorporateDivCodeList == target.CorporateDivCodeList)
                 //&& (this.IsSelectAllCorporateDiv == target.IsSelectAllCorporateDiv)
                 // 2007.10.15 hikita del end ---------------------------------------------<<
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (this.IsEmployeeNextPage == target.IsEmployeeNextPage)
                 //&& (this.IsJudgeBillOutputCode == target.IsJudgeBillOutputCode)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 && (this.CustomerAgentDivCd == target.CustomerAgentDivCd)
				 && (this.BillCollecterCdSt == target.BillCollecterCdSt)
				 && (this.BillCollecterCdEd == target.BillCollecterCdEd)
				 && (this.CustomerAgentCdSt == target.CustomerAgentCdSt)
				 && (this.CustomerAgentCdEd == target.CustomerAgentCdEd)
                 // 2007.10.15 hikita del start ------------------------------------------->>
                 //&& (this.CustAnalysCode1St == target.CustAnalysCode1St)
                 //&& (this.CustAnalysCode1Ed == target.CustAnalysCode1Ed)
                 //&& (this.CustAnalysCode2St == target.CustAnalysCode2St)
                 //&& (this.CustAnalysCode2Ed == target.CustAnalysCode2Ed)
                 //&& (this.CustAnalysCode3St == target.CustAnalysCode3St)
                 //&& (this.CustAnalysCode3Ed == target.CustAnalysCode3Ed)
                 //&& (this.CustAnalysCode4St == target.CustAnalysCode4St)
                 //&& (this.CustAnalysCode4Ed == target.CustAnalysCode4Ed)
                 //&& (this.CustAnalysCode5St == target.CustAnalysCode5St)
                 //&& (this.CustAnalysCode5Ed == target.CustAnalysCode5Ed)
                 //&& (this.CustAnalysCode6St == target.CustAnalysCode6St)
                 //&& (this.CustAnalysCode6Ed == target.CustAnalysCode6Ed)
                 // 2007.10.15 hikita del end ---------------------------------------------<<
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (this.IsBillOutputOnly == target.IsBillOutputOnly)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 && (this.SortOrder == target.SortOrder)
				 //&& (this.CorporateDivNameList == target.CorporateDivNameList)    // 2007.10.15 hikita del
				 && (this.OutPutPriceCond == target.OutPutPriceCond)
                 && (this.DmdDtl == target.DmdDtl)                                  // 2007.10.15 hikita add
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (this.SlipTotalPrt == target.SlipTotalPrt)
                 //&& (this.AddUpDateTotalPrt == target.AddUpDateTotalPrt)
                 //&& (this.CustomerTotalPrt == target.CustomerTotalPrt)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 //&& (this.CarrierTotalPrt == target.CarrierTotalPrt)              // 2007.10.15 hikita del
                 // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)
                 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)
                 && (this.CollectRatePrtDiv == target.CollectRatePrtDiv)
                 && (this.BalanceDepositDtl == target.BalanceDepositDtl)
                 && (this.IsBillOutputOnly == target.IsBillOutputOnly)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.IssueDay == target.IssueDay)
                 // 2008.09.05 30413 犬飼 項目追加 <<<<<<END
                 && (this.PrCustDtl == target.PrCustDtl)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 //---ADD 2011/03/14------------->>>>>
                 && (this.PrintBlLiDiv == target.PrintBlLiDiv)
                 && (this.LineMaSqOfChDiv == target.LineMaSqOfChDiv)
                 //---ADD 2011/03/14-------------<<<<<
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                && (this.TaxPrintDiv == target.TaxPrintDiv)
                && (this.TaxRate1 == target.TaxRate1)
                && (this.TaxRate2 == target.TaxRate2)
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
                 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 請求書(鑑部)抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">
		///                    比較するExtrInfo_DemandTotalクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_DemandTotal2">比較するExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandTotalクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DemandTotal extrInfo_DemandTotal1, ExtrInfo_DemandTotal extrInfo_DemandTotal2)
		{
			return ((extrInfo_DemandTotal1.EnterpriseCode == extrInfo_DemandTotal2.EnterpriseCode)
				 && (extrInfo_DemandTotal1.IsSelectAllSection == extrInfo_DemandTotal2.IsSelectAllSection)
				 && (extrInfo_DemandTotal1.IsOutputAllSecRec == extrInfo_DemandTotal2.IsOutputAllSecRec)
                 && (extrInfo_DemandTotal1.ResultsAddUpSecList == extrInfo_DemandTotal2.ResultsAddUpSecList)
                 && (extrInfo_DemandTotal1.IsOptSection == extrInfo_DemandTotal2.IsOptSection)
				 && (extrInfo_DemandTotal1.IsMainOfficeFunc == extrInfo_DemandTotal2.IsMainOfficeFunc)
                 // 2008.09.08 30413 犬飼 計上年月日の型を変更 >>>>>>START
                 && (extrInfo_DemandTotal1.AddUpDate == extrInfo_DemandTotal2.AddUpDate)
                 // 2008.09.08 30413 犬飼 計上年月日の型を変更 <<<<<<END
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (extrInfo_DemandTotal1.TargetAddUpDate == extrInfo_DemandTotal2.TargetAddUpDate)
                 //&& (extrInfo_DemandTotal1.TotalDay == extrInfo_DemandTotal2.TotalDay)
                 //&& (extrInfo_DemandTotal1.IsLastDay == extrInfo_DemandTotal2.IsLastDay)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 && (extrInfo_DemandTotal1.CustomerCodeSt == extrInfo_DemandTotal2.CustomerCodeSt)
				 && (extrInfo_DemandTotal1.CustomerCodeEd == extrInfo_DemandTotal2.CustomerCodeEd)
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (extrInfo_DemandTotal1.KanaSt == extrInfo_DemandTotal2.KanaSt)
                 //&& (extrInfo_DemandTotal1.KanaEd == extrInfo_DemandTotal2.KanaEd)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 // 2007.10.15 hikita del start ---------------------------------------------------------------------->>
                 //&& (extrInfo_DemandTotal1.CorporateDivCodeList == extrInfo_DemandTotal2.CorporateDivCodeList)
                 //&& (extrInfo_DemandTotal1.IsSelectAllCorporateDiv == extrInfo_DemandTotal2.IsSelectAllCorporateDiv)
                 // 2007.10.15 hikita del end ------------------------------------------------------------------------<<
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (extrInfo_DemandTotal1.IsEmployeeNextPage == extrInfo_DemandTotal2.IsEmployeeNextPage)
                 //&& (extrInfo_DemandTotal1.IsJudgeBillOutputCode == extrInfo_DemandTotal2.IsJudgeBillOutputCode)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 && (extrInfo_DemandTotal1.CustomerAgentDivCd == extrInfo_DemandTotal2.CustomerAgentDivCd)
				 && (extrInfo_DemandTotal1.BillCollecterCdSt == extrInfo_DemandTotal2.BillCollecterCdSt)
				 && (extrInfo_DemandTotal1.BillCollecterCdEd == extrInfo_DemandTotal2.BillCollecterCdEd)
				 && (extrInfo_DemandTotal1.CustomerAgentCdSt == extrInfo_DemandTotal2.CustomerAgentCdSt)
				 && (extrInfo_DemandTotal1.CustomerAgentCdEd == extrInfo_DemandTotal2.CustomerAgentCdEd)
                 // 2007.10.15 hikita del start ---------------------------------------------------------------------->>
                 //&& (extrInfo_DemandTotal1.CustAnalysCode1St == extrInfo_DemandTotal2.CustAnalysCode1St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode1Ed == extrInfo_DemandTotal2.CustAnalysCode1Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode2St == extrInfo_DemandTotal2.CustAnalysCode2St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode2Ed == extrInfo_DemandTotal2.CustAnalysCode2Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode3St == extrInfo_DemandTotal2.CustAnalysCode3St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode3Ed == extrInfo_DemandTotal2.CustAnalysCode3Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode4St == extrInfo_DemandTotal2.CustAnalysCode4St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode4Ed == extrInfo_DemandTotal2.CustAnalysCode4Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode5St == extrInfo_DemandTotal2.CustAnalysCode5St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode5Ed == extrInfo_DemandTotal2.CustAnalysCode5Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode6St == extrInfo_DemandTotal2.CustAnalysCode6St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode6Ed == extrInfo_DemandTotal2.CustAnalysCode6Ed)
                 // 2007.10.15 hikita del end ------------------------------------------------------------------------<<
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (extrInfo_DemandTotal1.IsBillOutputOnly == extrInfo_DemandTotal2.IsBillOutputOnly)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 && (extrInfo_DemandTotal1.SortOrder == extrInfo_DemandTotal2.SortOrder)
				 //&& (extrInfo_DemandTotal1.CorporateDivNameList == extrInfo_DemandTotal2.CorporateDivNameList)   // 2007.10.15 hikita del
				 && (extrInfo_DemandTotal1.OutPutPriceCond == extrInfo_DemandTotal2.OutPutPriceCond)
                 && (extrInfo_DemandTotal1.DmdDtl == extrInfo_DemandTotal2.DmdDtl)                                 // 2007.10.15 hikita add
                 // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                 //&& (extrInfo_DemandTotal1.SlipTotalPrt == extrInfo_DemandTotal2.SlipTotalPrt)
                 //&& (extrInfo_DemandTotal1.AddUpDateTotalPrt == extrInfo_DemandTotal2.AddUpDateTotalPrt)
                 //&& (extrInfo_DemandTotal1.CustomerTotalPrt == extrInfo_DemandTotal2.CustomerTotalPrt)
                 // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                 //&& (extrInfo_DemandTotal1.CarrierTotalPrt == extrInfo_DemandTotal2.CarrierTotalPrt)             // 2007.10.15 hikita del 
				 // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
                 && (extrInfo_DemandTotal1.NewPageDiv == extrInfo_DemandTotal2.NewPageDiv)
                 && (extrInfo_DemandTotal1.SalesAreaCodeSt == extrInfo_DemandTotal2.SalesAreaCodeSt)
                 && (extrInfo_DemandTotal1.SalesAreaCodeEd == extrInfo_DemandTotal2.SalesAreaCodeEd)
                 && (extrInfo_DemandTotal1.CollectRatePrtDiv == extrInfo_DemandTotal2.CollectRatePrtDiv)
                 && (extrInfo_DemandTotal1.BalanceDepositDtl == extrInfo_DemandTotal2.BalanceDepositDtl)
                 && (extrInfo_DemandTotal1.IsBillOutputOnly == extrInfo_DemandTotal2.IsBillOutputOnly)
                 && (extrInfo_DemandTotal1.SlipPrtKind == extrInfo_DemandTotal2.SlipPrtKind)
                 && (extrInfo_DemandTotal1.IssueDay == extrInfo_DemandTotal2.IssueDay)
                 // 2008.09.05 30413 犬飼 項目追加 <<<<<<END
                 && (extrInfo_DemandTotal1.PrCustDtl == extrInfo_DemandTotal2.PrCustDtl)
                 && (extrInfo_DemandTotal1.AccRecDivCd == extrInfo_DemandTotal2.AccRecDivCd)
                 //---ADD 2011/03/14------------->>>>>
                 && (extrInfo_DemandTotal1.PrintBlLiDiv == extrInfo_DemandTotal2.PrintBlLiDiv)
                 && (extrInfo_DemandTotal1.LineMaSqOfChDiv == extrInfo_DemandTotal2.LineMaSqOfChDiv)
                 //---ADD 2011/03/14-------------<<<<<
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                 && (extrInfo_DemandTotal1.TaxPrintDiv == extrInfo_DemandTotal2.TaxPrintDiv)
                 && (extrInfo_DemandTotal1.TaxRate1 == extrInfo_DemandTotal2.TaxRate1)
                 && (extrInfo_DemandTotal1.TaxRate2 == extrInfo_DemandTotal2.TaxRate2)
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
                 && (extrInfo_DemandTotal1.EnterpriseName == extrInfo_DemandTotal2.EnterpriseName));
		}
		/// <summary>
		/// 請求書(鑑部)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandTotalクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DemandTotal target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(this.IsOutputAllSecRec != target.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(this.ResultsAddUpSecList != target.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(this.IsOptSection != target.IsOptSection)resList.Add("IsOptSection");
			if(this.IsMainOfficeFunc != target.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            // 2008.09.08 30413 犬飼 計上年月日の型を変更 >>>>>>START
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            // 2008.09.08 30413 犬飼 計上年月日の型を変更 <<<<<<END
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (this.TargetAddUpDate != target.TargetAddUpDate) resList.Add("TargetAddUpDate");
            //if(this.TotalDay != target.TotalDay)resList.Add("TotalDay");
            //if (this.IsLastDay != target.IsLastDay) resList.Add("IsLastDay");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (this.KanaSt != target.KanaSt) resList.Add("KanaSt");
            //if(this.KanaEd != target.KanaEd)resList.Add("KanaEd");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            // 2007.10.15 hikita del start ----------------------------------------------------------------------------->>
            //if(this.CorporateDivCodeList != target.CorporateDivCodeList)resList.Add("CorporateDivCodeList");
            //if(this.IsSelectAllCorporateDiv != target.IsSelectAllCorporateDiv)resList.Add("IsSelectAllCorporateDiv");
            // 2007.10.15 hikita del end -------------------------------------------------------------------------------<<
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (this.IsEmployeeNextPage != target.IsEmployeeNextPage) resList.Add("IsEmployeeNextPage");
            //if(this.IsJudgeBillOutputCode != target.IsJudgeBillOutputCode)resList.Add("IsJudgeBillOutputCode");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            if (this.CustomerAgentDivCd != target.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if(this.BillCollecterCdSt != target.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if(this.BillCollecterCdEd != target.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if(this.CustomerAgentCdSt != target.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if(this.CustomerAgentCdEd != target.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            // 2007.10.15 hikita del start ----------------------------------------------------------------------------->>
            //if(this.CustAnalysCode1St != target.CustAnalysCode1St)resList.Add("CustAnalysCode1St");
            //if(this.CustAnalysCode1Ed != target.CustAnalysCode1Ed)resList.Add("CustAnalysCode1Ed");
            //if(this.CustAnalysCode2St != target.CustAnalysCode2St)resList.Add("CustAnalysCode2St");
            //if(this.CustAnalysCode2Ed != target.CustAnalysCode2Ed)resList.Add("CustAnalysCode2Ed");
            //if(this.CustAnalysCode3St != target.CustAnalysCode3St)resList.Add("CustAnalysCode3St");
            //if(this.CustAnalysCode3Ed != target.CustAnalysCode3Ed)resList.Add("CustAnalysCode3Ed");
            //if(this.CustAnalysCode4St != target.CustAnalysCode4St)resList.Add("CustAnalysCode4St");
            //if(this.CustAnalysCode4Ed != target.CustAnalysCode4Ed)resList.Add("CustAnalysCode4Ed");
            //if(this.CustAnalysCode5St != target.CustAnalysCode5St)resList.Add("CustAnalysCode5St");
            //if(this.CustAnalysCode5Ed != target.CustAnalysCode5Ed)resList.Add("CustAnalysCode5Ed");
            //if(this.CustAnalysCode6St != target.CustAnalysCode6St)resList.Add("CustAnalysCode6St");
            //if(this.CustAnalysCode6Ed != target.CustAnalysCode6Ed)resList.Add("CustAnalysCode6Ed");
            // 2007.10.15 hikita del end -------------------------------------------------------------------------------<<
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (this.IsBillOutputOnly != target.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<<END
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
			//if(this.CorporateDivNameList != target.CorporateDivNameList)resList.Add("CorporateDivNameList");  // 2007.10.15 hikita del
            if (this.OutPutPriceCond != target.OutPutPriceCond) resList.Add("OutPutPriceCond");
            if (this.DmdDtl != target.DmdDtl) resList.Add("DmdDtl");                                            // 2007.10.15 hikita add   
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (this.SlipTotalPrt != target.SlipTotalPrt) resList.Add("SlipTotalPrt");
            //if(this.AddUpDateTotalPrt != target.AddUpDateTotalPrt)resList.Add("AddUpDateTotalPrt");
            //if(this.CustomerTotalPrt != target.CustomerTotalPrt)resList.Add("CustomerTotalPrt");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            //if(this.CarrierTotalPrt != target.CarrierTotalPrt)resList.Add("CarrierTotalPrt");                 // 2007.10.15 hikita del
            // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.SalesAreaCodeSt != target.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (this.SalesAreaCodeEd != target.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (this.CollectRatePrtDiv != target.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (this.BalanceDepositDtl != target.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (this.IsBillOutputOnly != target.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.IssueDay != target.IssueDay) resList.Add("IssueDay");
            // 2008.09.05 30413 犬飼 項目追加 <<<<<<END
            if (this.PrCustDtl != target.PrCustDtl) resList.Add("PrCustDtl");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            //---ADD 2011/03/14------------->>>>>
            if (this.PrintBlLiDiv != target.PrintBlLiDiv) resList.Add("PrintBlLiDiv");
            if (this.LineMaSqOfChDiv != target.LineMaSqOfChDiv) resList.Add("LineMaSqOfChDiv");
            //---ADD 2011/03/14-------------<<<<<
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            if (this.TaxPrintDiv != target.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (this.TaxRate1 != target.TaxRate1) resList.Add("TaxRate1");
            if (this.TaxRate2 != target.TaxRate2) resList.Add("TaxRate2");
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
			return resList;
		}

		/// <summary>
		/// 請求書(鑑部)抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">比較するExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <param name="extrInfo_DemandTotal2">比較するExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandTotalクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DemandTotal extrInfo_DemandTotal1, ExtrInfo_DemandTotal extrInfo_DemandTotal2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_DemandTotal1.EnterpriseCode != extrInfo_DemandTotal2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_DemandTotal1.IsSelectAllSection != extrInfo_DemandTotal2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(extrInfo_DemandTotal1.IsOutputAllSecRec != extrInfo_DemandTotal2.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(extrInfo_DemandTotal1.ResultsAddUpSecList != extrInfo_DemandTotal2.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(extrInfo_DemandTotal1.IsOptSection != extrInfo_DemandTotal2.IsOptSection)resList.Add("IsOptSection");
			if(extrInfo_DemandTotal1.IsMainOfficeFunc != extrInfo_DemandTotal2.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            // 2008.09.08 30413 犬飼 計上年月日の型を変更 >>>>>>START
            if (extrInfo_DemandTotal1.AddUpDate != extrInfo_DemandTotal2.AddUpDate) resList.Add("AddUpDate");
            // 2008.09.08 30413 犬飼 計上年月日の型を変更 <<<<<<END
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (extrInfo_DemandTotal1.TargetAddUpDate != extrInfo_DemandTotal2.TargetAddUpDate) resList.Add("TargetAddUpDate");
            //if(extrInfo_DemandTotal1.TotalDay != extrInfo_DemandTotal2.TotalDay)resList.Add("TotalDay");
            //if (extrInfo_DemandTotal1.IsLastDay != extrInfo_DemandTotal2.IsLastDay) resList.Add("IsLastDay");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            if (extrInfo_DemandTotal1.CustomerCodeSt != extrInfo_DemandTotal2.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(extrInfo_DemandTotal1.CustomerCodeEd != extrInfo_DemandTotal2.CustomerCodeEd)resList.Add("CustomerCodeEd");
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (extrInfo_DemandTotal1.KanaSt != extrInfo_DemandTotal2.KanaSt) resList.Add("KanaSt");
            //if(extrInfo_DemandTotal1.KanaEd != extrInfo_DemandTotal2.KanaEd)resList.Add("KanaEd");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            // 2007.10.15 hikita del start ------------------------------------------------------------------------------------------------->>
            //if(extrInfo_DemandTotal1.CorporateDivCodeList != extrInfo_DemandTotal2.CorporateDivCodeList)resList.Add("CorporateDivCodeList");
            //if(extrInfo_DemandTotal1.IsSelectAllCorporateDiv != extrInfo_DemandTotal2.IsSelectAllCorporateDiv)resList.Add("IsSelectAllCorporateDiv");
            // 2007.10.15 hikita del end ---------------------------------------------------------------------------------------------------<<
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (extrInfo_DemandTotal1.IsEmployeeNextPage != extrInfo_DemandTotal2.IsEmployeeNextPage) resList.Add("IsEmployeeNextPage");
            //if(extrInfo_DemandTotal1.IsJudgeBillOutputCode != extrInfo_DemandTotal2.IsJudgeBillOutputCode)resList.Add("IsJudgeBillOutputCode");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            if (extrInfo_DemandTotal1.CustomerAgentDivCd != extrInfo_DemandTotal2.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if(extrInfo_DemandTotal1.BillCollecterCdSt != extrInfo_DemandTotal2.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if(extrInfo_DemandTotal1.BillCollecterCdEd != extrInfo_DemandTotal2.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if(extrInfo_DemandTotal1.CustomerAgentCdSt != extrInfo_DemandTotal2.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if(extrInfo_DemandTotal1.CustomerAgentCdEd != extrInfo_DemandTotal2.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            // 2007.10.15 hikita del start ------------------------------------------------------------------------------------------------->>
            //if(extrInfo_DemandTotal1.CustAnalysCode1St != extrInfo_DemandTotal2.CustAnalysCode1St)resList.Add("CustAnalysCode1St");
            //if(extrInfo_DemandTotal1.CustAnalysCode1Ed != extrInfo_DemandTotal2.CustAnalysCode1Ed)resList.Add("CustAnalysCode1Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode2St != extrInfo_DemandTotal2.CustAnalysCode2St)resList.Add("CustAnalysCode2St");
            //if(extrInfo_DemandTotal1.CustAnalysCode2Ed != extrInfo_DemandTotal2.CustAnalysCode2Ed)resList.Add("CustAnalysCode2Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode3St != extrInfo_DemandTotal2.CustAnalysCode3St)resList.Add("CustAnalysCode3St");
            //if(extrInfo_DemandTotal1.CustAnalysCode3Ed != extrInfo_DemandTotal2.CustAnalysCode3Ed)resList.Add("CustAnalysCode3Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode4St != extrInfo_DemandTotal2.CustAnalysCode4St)resList.Add("CustAnalysCode4St");
            //if(extrInfo_DemandTotal1.CustAnalysCode4Ed != extrInfo_DemandTotal2.CustAnalysCode4Ed)resList.Add("CustAnalysCode4Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode5St != extrInfo_DemandTotal2.CustAnalysCode5St)resList.Add("CustAnalysCode5St");
            //if(extrInfo_DemandTotal1.CustAnalysCode5Ed != extrInfo_DemandTotal2.CustAnalysCode5Ed)resList.Add("CustAnalysCode5Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode6St != extrInfo_DemandTotal2.CustAnalysCode6St)resList.Add("CustAnalysCode6St");
            //if(extrInfo_DemandTotal1.CustAnalysCode6Ed != extrInfo_DemandTotal2.CustAnalysCode6Ed)resList.Add("CustAnalysCode6Ed");
            // 2007.10.15 hikita del end ---------------------------------------------------------------------------------------------------<<
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (extrInfo_DemandTotal1.IsBillOutputOnly != extrInfo_DemandTotal2.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            if (extrInfo_DemandTotal1.SortOrder != extrInfo_DemandTotal2.SortOrder) resList.Add("SortOrder");
			//if(extrInfo_DemandTotal1.CorporateDivNameList != extrInfo_DemandTotal2.CorporateDivNameList)resList.Add("CorporateDivNameList");    // 2007.10.15 hiktia del
			if(extrInfo_DemandTotal1.OutPutPriceCond != extrInfo_DemandTotal2.OutPutPriceCond)resList.Add("OutPutPriceCond");
            if (extrInfo_DemandTotal1.DmdDtl != extrInfo_DemandTotal2.DmdDtl) resList.Add("DmdDtl");                                              // 2007.10.15 hikita add
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (extrInfo_DemandTotal1.SlipTotalPrt != extrInfo_DemandTotal2.SlipTotalPrt) resList.Add("SlipTotalPrt");
            //if(extrInfo_DemandTotal1.AddUpDateTotalPrt != extrInfo_DemandTotal2.AddUpDateTotalPrt)resList.Add("AddUpDateTotalPrt");
            //if(extrInfo_DemandTotal1.CustomerTotalPrt != extrInfo_DemandTotal2.CustomerTotalPrt)resList.Add("CustomerTotalPrt");
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            //if(extrInfo_DemandTotal1.CarrierTotalPrt != extrInfo_DemandTotal2.CarrierTotalPrt)resList.Add("CarrierTotalPrt");                   // 2007.10.15 hiktia del
            // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
            if (extrInfo_DemandTotal1.NewPageDiv != extrInfo_DemandTotal2.NewPageDiv) resList.Add("NewPageDiv");
            if (extrInfo_DemandTotal1.SalesAreaCodeSt != extrInfo_DemandTotal2.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (extrInfo_DemandTotal1.SalesAreaCodeEd != extrInfo_DemandTotal2.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (extrInfo_DemandTotal1.CollectRatePrtDiv != extrInfo_DemandTotal2.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (extrInfo_DemandTotal1.BalanceDepositDtl != extrInfo_DemandTotal2.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (extrInfo_DemandTotal1.IsBillOutputOnly != extrInfo_DemandTotal2.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            if (extrInfo_DemandTotal1.SlipPrtKind != extrInfo_DemandTotal2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (extrInfo_DemandTotal1.IssueDay != extrInfo_DemandTotal2.IssueDay) resList.Add("IssueDay");
            // 2008.09.05 30413 犬飼 項目追加 <<<<<<END
            if (extrInfo_DemandTotal1.PrCustDtl != extrInfo_DemandTotal2.PrCustDtl) resList.Add("PrCustDtl");
            if (extrInfo_DemandTotal1.AccRecDivCd != extrInfo_DemandTotal2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (extrInfo_DemandTotal1.EnterpriseName != extrInfo_DemandTotal2.EnterpriseName) resList.Add("EnterpriseName");
            //---ADD 2011/03/14------------->>>>>
            if (extrInfo_DemandTotal1.PrintBlLiDiv != extrInfo_DemandTotal2.PrintBlLiDiv) resList.Add("PrintBlLiDiv");
            if (extrInfo_DemandTotal1.LineMaSqOfChDiv != extrInfo_DemandTotal2.LineMaSqOfChDiv) resList.Add("LineMaSqOfChDiv");
            //---ADD 2011/03/14-------------<<<<<
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            if (extrInfo_DemandTotal1.TaxPrintDiv != extrInfo_DemandTotal2.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (extrInfo_DemandTotal1.TaxRate1 != extrInfo_DemandTotal2.TaxRate1) resList.Add("TaxRate1");
            if (extrInfo_DemandTotal1.TaxRate2 != extrInfo_DemandTotal2.TaxRate2) resList.Add("TaxRate2");
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
			return resList;
		}

        // ----- iitani a ---------- start 2007.05.14
        private bool CompareArrayStr(ArrayList cmpString1, ArrayList cmpString2)
        {
            // まずは要素数で比較
            if (cmpString1.Count != cmpString2.Count)
            {
                return false;
            }

            // 値一つ一つの比較(値の順番も一致していないとfalseになる)
            for (int i = 0; i < cmpString1.Count; i++)
            {
                if (cmpString1[i] != cmpString2[i])
                {
                    return false;
                }
            }

            return true;
        }
        // ----- iitani a ---------- end 2007.05.14

        private bool EqualsStrList(string[] strList1, string[] strList2)
        {
            // 要素数で比較
            if (strList1.Length != strList2.Length)
            {
                return false;
            }

            // 値一つ一つの比較(値の順番も一致していないとfalseになる)
            for (int i = 0; i < strList1.Length; i++)
            {
                if (strList1[i] != strList2[i])
                {
                    return false;
                }
            }

            return true;
        }
	}
}
