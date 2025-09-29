//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 請求書(鑑部)抽出条件クラス
// プログラム概要   : 請求書(鑑部)抽出条件クラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/07    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_EBooksDemandTotal
	/// <summary>
	///                      請求書(鑑部)抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求書(鑑部)抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
    /// <br>Genarated Date   :   2022/03/07  (CSharp File Generated Date)</br>
    /// </remarks>
	public class ExtrInfo_EBooksDemandTotal
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

        /// <summary>実績計上拠点コードリスト</summary>
        /// <remarks>文字型　※配列項目 全社指定は{""}</remarks>
        private string[] _resultsAddUpSecList;
        
		/// <summary>拠点オプション導入区分</summary>
		/// <remarks>true:導入済, false:未導入</remarks>
		private bool _isOptSection;

		/// <summary>本社機能プロパティ</summary>
		/// <remarks>true:本社, false:拠点</remarks>
		private bool _isMainOfficeFunc;

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 請求締を行なった日（相手先基準）</remarks>
        private DateTime _addUpDate;        
            
		/// <summary>得意先コード(開始)</summary>
		private Int32 _customerCodeSt;

		/// <summary>得意先コード(終了)</summary>
		private Int32 _customerCodeEd;
        
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
        
		/// <summary>出力順</summary>
		private Int32 _sortOrder;

        /// <summary>出力金額条件</summary>
		private Int32 _outPutPriceCond;

        /// <summary>販売エリアコード(開始)</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>販売エリアコード(終了)</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>発行日</summary>
        private DateTime _issueDay;

		/// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>電子帳簿出力対象</summary>
        private Int32 _eBooksOutMode;

        /// <summary>印刷出力対象</summary>
        private Int32 _printOutMode;

        /// <summary>同期処理区分</summary>
        private Int32 _eBooksFlg;

        /// <summary>伝票印刷設定用帳票ID</summary>
        private string _prtSetPaperId = "";

        /// <summary>ファイル名パターン</summary>
        private Int32 _outPutPattern;

        /// <summary>伝票印刷種別</summary>
        private Int32 _slipPrtKind;

        /// <summary>改頁</summary>
        private Int32 _newPageDiv;
        
        /// <summary>回収率印字</summary>
        private Int32 _collectRatePrtDiv;

        /// <summary>残高入金内訳</summary>
        private Int32 _balanceDepositDtl;

        /// <summary>空白行印字</summary>
        private Int32 _printBlLiDiv;

        /// <summary>罫線印字</summary>
        private Int32 _lineMaSqOfChDiv;

        /// <summary>売掛区分</summary>
        private Int32 _accRecDivCd;

        /// <summary>消費税別の内訳区分</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>税率1</summary>
        /// <remarks>税率1</remarks>
        private Double _taxRate1;

        /// <summary>税率2</summary>
        /// <remarks>税率2</remarks>
        private Double _taxRate2;

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

        /// public propaty name  :  EBooksOutMode
        /// <summary>電子帳簿出力対象プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電子帳簿出力対象プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EBooksOutMode
        {
            get { return _eBooksOutMode; }
            set { _eBooksOutMode = value; }
        }

        /// public propaty name  :  PrintOutMode
        /// <summary>印刷出力対象プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷出力対象プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintOutMode
        {
            get { return _printOutMode; }
            set { _printOutMode = value; }
        }

        /// public propaty name  :  EBookFlg
        /// <summary>同期処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EBooksFlg
        {
            get { return _eBooksFlg; }
            set { _eBooksFlg = value; }
        }

        /// public propaty name  :  PrtSetPaperId
        /// <summary>伝票印刷設定用帳票IDプロパティ</summary>
        /// <value>伝票印刷設定用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSetPaperId
        {
            get { return _prtSetPaperId; }
            set { _prtSetPaperId = value; }
        }

        /// public propaty name  :  OutPutPattern
        /// <summary>ファイル名パターンプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル名パターンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutPutPattern
        {
            get { return _outPutPattern; }
            set { _outPutPattern = value; }
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

		/// <summary>
		/// 請求書(鑑部)抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_EBooksDemandTotalクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_EBooksDemandTotalクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_EBooksDemandTotal()
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
        /// <param name="slipPrtKind">種別</param>
		/// <returns>ExtrInfo_EBooksDemandTotalクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_EBooksDemandTotalクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ExtrInfo_EBooksDemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, DateTime issueDay, string enterpriseName, Int32 eBooksOutMode, Int32 printOutMode, Int32 eBooksFlg, string prtSetPaperId, Int32 outPutPattern, Int32 slipPrtKind, Int32 newPageDiv, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, Int32 printBlLiDiv, Int32 lineMaSqOfChDiv, Int32 accRecDivCd, Int32 taxPrintDiv, double taxRate1, double taxRate2)
        {
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._resultsAddUpSecList = resultsAddUpSecList;
			this._isOptSection = isOptSection;
			this._isMainOfficeFunc = isMainOfficeFunc;
            this._addUpDate = addUpDate;
            this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
            this._customerAgentDivCd = customerAgentDivCd;
			this._billCollecterCdSt = billCollecterCdSt;
			this._billCollecterCdEd = billCollecterCdEd;
			this._customerAgentCdSt = customerAgentCdSt;
			this._customerAgentCdEd = customerAgentCdEd;
            this._sortOrder = sortOrder;
			this._outPutPriceCond = outPutPriceCond;
            this._salesAreaCodeSt = salesAreaCodeSt;
            this._salesAreaCodeEd = salesAreaCodeEd;
            this._issueDay = issueDay;
            this._enterpriseName = enterpriseName;
            this._eBooksOutMode = eBooksOutMode;
            this._printOutMode = printOutMode;
            this._eBooksFlg = eBooksFlg;
            this._prtSetPaperId = prtSetPaperId;
            this._outPutPattern = outPutPattern;
            this._slipPrtKind = slipPrtKind;
            this._newPageDiv = newPageDiv;
            this._collectRatePrtDiv = collectRatePrtDiv;
            this._balanceDepositDtl = balanceDepositDtl;
            this._printBlLiDiv = printBlLiDiv;
            this._lineMaSqOfChDiv = lineMaSqOfChDiv;
            this._accRecDivCd = accRecDivCd;
            this._taxPrintDiv = taxPrintDiv;
            this._taxRate1 = taxRate1;
            this._taxRate2 = taxRate2;

		}

		/// <summary>
		/// 請求書(鑑部)抽出条件クラス複製処理
		/// </summary>
		/// <returns>ExtrInfo_EBooksDemandTotalクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_EBooksDemandTotalクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_EBooksDemandTotal Clone()
		{
            return new ExtrInfo_EBooksDemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._salesAreaCodeSt, this._salesAreaCodeEd, this._issueDay, this._enterpriseName, this._eBooksOutMode, this.PrintOutMode, this.EBooksFlg, this._prtSetPaperId, this._outPutPattern, this._slipPrtKind, this._newPageDiv, this._collectRatePrtDiv, this._balanceDepositDtl, this._printBlLiDiv, this._lineMaSqOfChDiv, this._accRecDivCd, this._taxPrintDiv, this._taxRate1, this._taxRate2);
        }

		/// <summary>
		/// 請求書(鑑部)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_EBooksDemandTotalクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_EBooksDemandTotalクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExtrInfo_EBooksDemandTotal target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (EqualsStrList(this.ResultsAddUpSecList, target.ResultsAddUpSecList))
				 && (this.IsOptSection == target.IsOptSection)
				 && (this.IsMainOfficeFunc == target.IsMainOfficeFunc)
                 && (this.AddUpDate == target.AddUpDate)
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
				 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 && (this.CustomerAgentDivCd == target.CustomerAgentDivCd)
				 && (this.BillCollecterCdSt == target.BillCollecterCdSt)
				 && (this.BillCollecterCdEd == target.BillCollecterCdEd)
				 && (this.CustomerAgentCdSt == target.CustomerAgentCdSt)
				 && (this.CustomerAgentCdEd == target.CustomerAgentCdEd)
                 && (this.SortOrder == target.SortOrder)
				 && (this.OutPutPriceCond == target.OutPutPriceCond) 
                 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)
                 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)
                 && (this.IssueDay == target.IssueDay)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.EBooksOutMode == target.EBooksOutMode)
                 && (this.PrintOutMode == target.PrintOutMode)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.CollectRatePrtDiv == target.CollectRatePrtDiv)
                 && (this.BalanceDepositDtl == target.BalanceDepositDtl)
                 && (this.PrintBlLiDiv == target.PrintBlLiDiv)
                 && (this.LineMaSqOfChDiv == target.LineMaSqOfChDiv)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.TaxPrintDiv == target.TaxPrintDiv)
                 && (this.TaxRate1 == target.TaxRate1)
                 && (this.TaxRate2 == target.TaxRate2)
                 );
		}

		/// <summary>
		/// 請求書(鑑部)抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">
		///                    比較するExtrInfo_EBooksDemandTotalクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_DemandTotal2">比較するExtrInfo_EBooksDemandTotalクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_EBooksDemandTotalクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_EBooksDemandTotal extrInfo_DemandTotal1, ExtrInfo_EBooksDemandTotal extrInfo_DemandTotal2)
		{
			return ((extrInfo_DemandTotal1.EnterpriseCode == extrInfo_DemandTotal2.EnterpriseCode)
				 && (extrInfo_DemandTotal1.IsSelectAllSection == extrInfo_DemandTotal2.IsSelectAllSection)
                 && (extrInfo_DemandTotal1.ResultsAddUpSecList == extrInfo_DemandTotal2.ResultsAddUpSecList)
                 && (extrInfo_DemandTotal1.IsOptSection == extrInfo_DemandTotal2.IsOptSection)
				 && (extrInfo_DemandTotal1.IsMainOfficeFunc == extrInfo_DemandTotal2.IsMainOfficeFunc)
                 && (extrInfo_DemandTotal1.AddUpDate == extrInfo_DemandTotal2.AddUpDate)
                 && (extrInfo_DemandTotal1.CustomerCodeSt == extrInfo_DemandTotal2.CustomerCodeSt)
				 && (extrInfo_DemandTotal1.CustomerCodeEd == extrInfo_DemandTotal2.CustomerCodeEd)
                 && (extrInfo_DemandTotal1.CustomerAgentDivCd == extrInfo_DemandTotal2.CustomerAgentDivCd)
				 && (extrInfo_DemandTotal1.BillCollecterCdSt == extrInfo_DemandTotal2.BillCollecterCdSt)
				 && (extrInfo_DemandTotal1.BillCollecterCdEd == extrInfo_DemandTotal2.BillCollecterCdEd)
				 && (extrInfo_DemandTotal1.CustomerAgentCdSt == extrInfo_DemandTotal2.CustomerAgentCdSt)
				 && (extrInfo_DemandTotal1.CustomerAgentCdEd == extrInfo_DemandTotal2.CustomerAgentCdEd)
                 && (extrInfo_DemandTotal1.SortOrder == extrInfo_DemandTotal2.SortOrder)
				 && (extrInfo_DemandTotal1.OutPutPriceCond == extrInfo_DemandTotal2.OutPutPriceCond)
                 && (extrInfo_DemandTotal1.SalesAreaCodeSt == extrInfo_DemandTotal2.SalesAreaCodeSt)
                 && (extrInfo_DemandTotal1.SalesAreaCodeEd == extrInfo_DemandTotal2.SalesAreaCodeEd)
                 && (extrInfo_DemandTotal1.IssueDay == extrInfo_DemandTotal2.IssueDay)
                 && (extrInfo_DemandTotal1.EnterpriseName == extrInfo_DemandTotal2.EnterpriseName)
                 && (extrInfo_DemandTotal1.EBooksOutMode == extrInfo_DemandTotal2.EBooksOutMode)
                 && (extrInfo_DemandTotal1.PrintOutMode == extrInfo_DemandTotal2.PrintOutMode)
                 && (extrInfo_DemandTotal1.SlipPrtKind == extrInfo_DemandTotal2.SlipPrtKind)
                 && (extrInfo_DemandTotal1.NewPageDiv == extrInfo_DemandTotal2.NewPageDiv)
                 && (extrInfo_DemandTotal1.CollectRatePrtDiv == extrInfo_DemandTotal2.CollectRatePrtDiv)
                 && (extrInfo_DemandTotal1.BalanceDepositDtl == extrInfo_DemandTotal2.BalanceDepositDtl)
                 && (extrInfo_DemandTotal1.PrintBlLiDiv == extrInfo_DemandTotal2.PrintBlLiDiv)
                 && (extrInfo_DemandTotal1.LineMaSqOfChDiv == extrInfo_DemandTotal2.LineMaSqOfChDiv)
                 && (extrInfo_DemandTotal1.AccRecDivCd == extrInfo_DemandTotal2.AccRecDivCd)
                 && (extrInfo_DemandTotal1.TaxPrintDiv == extrInfo_DemandTotal2.TaxPrintDiv)
                 && (extrInfo_DemandTotal1.TaxRate1 == extrInfo_DemandTotal2.TaxRate1)
                 && (extrInfo_DemandTotal1.TaxRate2 == extrInfo_DemandTotal2.TaxRate2)
                 );
		}
		/// <summary>
		/// 請求書(鑑部)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_EBooksDemandTotalクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_EBooksDemandTotalクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_EBooksDemandTotal target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(this.IsOutputAllSecRec != target.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(this.ResultsAddUpSecList != target.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(this.IsOptSection != target.IsOptSection)resList.Add("IsOptSection");
			if(this.IsMainOfficeFunc != target.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
            if (this.CustomerAgentDivCd != target.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if(this.BillCollecterCdSt != target.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if(this.BillCollecterCdEd != target.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if(this.CustomerAgentCdSt != target.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if(this.CustomerAgentCdEd != target.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
            if (this.OutPutPriceCond != target.OutPutPriceCond) resList.Add("OutPutPriceCond");
            if (this.SalesAreaCodeSt != target.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (this.SalesAreaCodeEd != target.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (this.IssueDay != target.IssueDay) resList.Add("IssueDay");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.EBooksOutMode != target.EBooksOutMode) resList.Add("EBooksOutMode");
            if (this.PrintOutMode != target.PrintOutMode) resList.Add("PrintOutMode");
            if (this.EBooksFlg != target.EBooksFlg) resList.Add("EBooksFlg");
            if (this.PrtSetPaperId != target.PrtSetPaperId) resList.Add("PrtSetPaperId");
            if (this.OutPutPattern != target.OutPutPattern) resList.Add("OutPutPattern");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.CollectRatePrtDiv != target.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (this.BalanceDepositDtl != target.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (this.PrintBlLiDiv != target.PrintBlLiDiv) resList.Add("PrintBlLiDiv");
            if (this.LineMaSqOfChDiv != target.LineMaSqOfChDiv) resList.Add("LineMaSqOfChDiv");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.TaxPrintDiv != target.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (this.TaxRate1 != target.TaxRate1) resList.Add("TaxRate1");
            if (this.TaxRate2 != target.TaxRate2) resList.Add("TaxRate2");
			return resList;
		}

		/// <summary>
		/// 請求書(鑑部)抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">比較するExtrInfo_EBooksDemandTotalクラスのインスタンス</param>
		/// <param name="extrInfo_DemandTotal2">比較するExtrInfo_EBooksDemandTotalクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_EBooksDemandTotalクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_EBooksDemandTotal extrInfo_DemandTotal1, ExtrInfo_EBooksDemandTotal extrInfo_DemandTotal2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_DemandTotal1.EnterpriseCode != extrInfo_DemandTotal2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_DemandTotal1.IsSelectAllSection != extrInfo_DemandTotal2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(extrInfo_DemandTotal1.IsOutputAllSecRec != extrInfo_DemandTotal2.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(extrInfo_DemandTotal1.ResultsAddUpSecList != extrInfo_DemandTotal2.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(extrInfo_DemandTotal1.IsOptSection != extrInfo_DemandTotal2.IsOptSection)resList.Add("IsOptSection");
			if(extrInfo_DemandTotal1.IsMainOfficeFunc != extrInfo_DemandTotal2.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            if (extrInfo_DemandTotal1.AddUpDate != extrInfo_DemandTotal2.AddUpDate) resList.Add("AddUpDate");
            if (extrInfo_DemandTotal1.CustomerCodeSt != extrInfo_DemandTotal2.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(extrInfo_DemandTotal1.CustomerCodeEd != extrInfo_DemandTotal2.CustomerCodeEd)resList.Add("CustomerCodeEd");
            if (extrInfo_DemandTotal1.CustomerAgentDivCd != extrInfo_DemandTotal2.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if(extrInfo_DemandTotal1.BillCollecterCdSt != extrInfo_DemandTotal2.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if(extrInfo_DemandTotal1.BillCollecterCdEd != extrInfo_DemandTotal2.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if(extrInfo_DemandTotal1.CustomerAgentCdSt != extrInfo_DemandTotal2.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if(extrInfo_DemandTotal1.CustomerAgentCdEd != extrInfo_DemandTotal2.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            if (extrInfo_DemandTotal1.SortOrder != extrInfo_DemandTotal2.SortOrder) resList.Add("SortOrder");
			if(extrInfo_DemandTotal1.OutPutPriceCond != extrInfo_DemandTotal2.OutPutPriceCond)resList.Add("OutPutPriceCond");
            if (extrInfo_DemandTotal1.SalesAreaCodeSt != extrInfo_DemandTotal2.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (extrInfo_DemandTotal1.SalesAreaCodeEd != extrInfo_DemandTotal2.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (extrInfo_DemandTotal1.IssueDay != extrInfo_DemandTotal2.IssueDay) resList.Add("IssueDay");
            if (extrInfo_DemandTotal1.EnterpriseName != extrInfo_DemandTotal2.EnterpriseName) resList.Add("EnterpriseName");
            if (extrInfo_DemandTotal1.EBooksOutMode != extrInfo_DemandTotal2.EBooksOutMode) resList.Add("EBooksOutMode");
            if (extrInfo_DemandTotal1.PrintOutMode != extrInfo_DemandTotal2.PrintOutMode) resList.Add("PrintOutMode");
            if (extrInfo_DemandTotal1.EBooksFlg != extrInfo_DemandTotal2.EBooksFlg) resList.Add("EBooksFlg");
            if (extrInfo_DemandTotal1.PrtSetPaperId != extrInfo_DemandTotal2.PrtSetPaperId) resList.Add("PrtSetPaperId");
            if (extrInfo_DemandTotal1.OutPutPattern != extrInfo_DemandTotal2.OutPutPattern) resList.Add("OutPutPattern");
            if (extrInfo_DemandTotal1.SlipPrtKind != extrInfo_DemandTotal2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (extrInfo_DemandTotal1.NewPageDiv != extrInfo_DemandTotal2.NewPageDiv) resList.Add("NewPageDiv");
            if (extrInfo_DemandTotal1.CollectRatePrtDiv != extrInfo_DemandTotal2.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (extrInfo_DemandTotal1.BalanceDepositDtl != extrInfo_DemandTotal2.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (extrInfo_DemandTotal1.PrintBlLiDiv != extrInfo_DemandTotal2.PrintBlLiDiv) resList.Add("PrintBlLiDiv");
            if (extrInfo_DemandTotal1.LineMaSqOfChDiv != extrInfo_DemandTotal2.LineMaSqOfChDiv) resList.Add("LineMaSqOfChDiv");
            if (extrInfo_DemandTotal1.AccRecDivCd != extrInfo_DemandTotal2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (extrInfo_DemandTotal1.TaxPrintDiv != extrInfo_DemandTotal2.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (extrInfo_DemandTotal1.TaxRate1 != extrInfo_DemandTotal2.TaxRate1) resList.Add("TaxRate1");
            if (extrInfo_DemandTotal1.TaxRate2 != extrInfo_DemandTotal2.TaxRate2) resList.Add("TaxRate2");
			return resList;
		}

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
