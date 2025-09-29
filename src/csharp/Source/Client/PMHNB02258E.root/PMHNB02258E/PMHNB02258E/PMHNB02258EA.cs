//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 請求書発行(総括)
// プログラム概要   : 請求書発行(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SumExtrInfo_DemandTotal
	/// <summary>
    ///                      請求書発行(総括)抽出条件クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   請求書発行(総括)抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/04/21  (CSharp File Generated Date)</br>
    /// <br>Note             : 11570208-00 軽減税率対応</br>
    /// <br>Programmer       : 陳艶丹</br>
    /// <br>Date             : 2020/04/13</br>
	/// </remarks>
	public class SumExtrInfo_DemandTotal
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
        
        /// <summary>総括得意先内訳</summary>
        private Int32 _sumCustDtl;

        /// <summary>売掛区分</summary>
        private Int32 _accRecDivCd;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

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
        
        /// public propaty name  :  SumCustDtl
        /// <summary>親得意先内訳プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親得意先内訳プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SumCustDtl
        {
            get { return _sumCustDtl; }
            set { _sumCustDtl = value; }
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
        /// 請求書発行(総括)抽出条件クラスコンストラクタ
		/// </summary>
        /// <returns>SumExtrInfo_DemandTotalクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandTotalクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SumExtrInfo_DemandTotal()
		{
		}

		/// <summary>
        /// 請求書発行(総括)抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="isSelectAllSection">全社選択(true:全社選択 false:各拠点選択)</param>
		/// <param name="isOutputAllSecRec">全拠点レコード出力(true:全拠点レコードを出力する。false:全拠点レコードを出力しない)</param>
		/// <param name="resultsAddUpSecList">実績計上拠点コードリスト(文字型　※配列項目)</param>
		/// <param name="isOptSection">拠点オプション導入区分(true:導入済, false:未導入)</param>
		/// <param name="isMainOfficeFunc">本社機能プロパティ(true:本社, false:拠点)</param>
        /// <param name="addUpDate">計上年月日</param>
		/// <param name="customerCodeSt">得意先コード(開始)</param>
		/// <param name="customerCodeEd">得意先コード(終了)</param>
		/// <param name="customerAgentDivCd">担当区分</param>
		/// <param name="billCollecterCdSt">集金担当コード(開始)(文字型)</param>
		/// <param name="billCollecterCdEd">集金担当コード(終了)(文字型)</param>
		/// <param name="customerAgentCdSt">顧客担当コード(開始)(文字型)</param>
		/// <param name="customerAgentCdEd">顧客担当コード(終了)(文字型)</param>
		/// <param name="sortOrder">出力順</param>
		/// <param name="outPutPriceCond">出力金額条件</param>
        /// <param name="newPageDiv">改頁</param>
        /// <param name="salesAreaCodeSt">地区コード(開始)</param>
        /// <param name="salesAreaCodeEd">地区コード(終了)</param>
        /// <param name="collectRatePrtDiv">回収率印字</param>
        /// <param name="balanceDepositDtl">残高入金内訳</param>
        /// <param name="isBillOutputOnly">請求書発行得意先フラグ</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <param name="issueDay">発行日</param>
        /// <param name="sumCustDtl">総括得意先内訳</param>
        /// <param name="accRecDivCd">売掛区分</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="taxPrintDiv">税別内訳印字区分</param>
        /// <param name="taxRate1">税率1</param>
        /// <param name="taxRate2">税率2</param>
        /// <returns>SumExtrInfo_DemandTotalクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandTotalクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
        //public SumExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 sumCustDtl, Int32 accRecDivCd, string enterpriseName)
        public SumExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 sumCustDtl, Int32 accRecDivCd, string enterpriseName, Int32 taxPrintDiv, double taxRate1, double taxRate2)
        // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
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
            this._newPageDiv = newPageDiv;
            this._salesAreaCodeSt = salesAreaCodeSt;
            this._salesAreaCodeEd = salesAreaCodeEd;
            this._collectRatePrtDiv = collectRatePrtDiv;
            this._balanceDepositDtl = balanceDepositDtl;
            this._isBillOutputOnly = isBillOutputOnly;
            this._slipPrtKind = slipPrtKind;
            this._issueDay = issueDay;
            this._sumCustDtl = sumCustDtl;
            this._accRecDivCd = accRecDivCd;
            this._enterpriseName = enterpriseName;
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            this._taxPrintDiv = taxPrintDiv;
            this._taxRate1 = taxRate1;
            this._taxRate2 = taxRate2;
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

		}

		/// <summary>
        /// 請求書発行(総括)抽出条件クラス複製処理
		/// </summary>
        /// <returns>SumExtrInfo_DemandTotalクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSumExtrInfo_DemandTotalクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SumExtrInfo_DemandTotal Clone()
		{
            // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            //return new SumExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._sumCustDtl, this._accRecDivCd, this._enterpriseName);
            return new SumExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._sumCustDtl, this._accRecDivCd, this._enterpriseName, this._taxPrintDiv, this._taxRate1, this._taxRate2);
            // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
        }

		/// <summary>
        /// 請求書発行(総括)抽出条件クラス比較処理
		/// </summary>
        /// <param name="target">比較対象のSumExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   SumExtrInfo_DemandTotalクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SumExtrInfo_DemandTotal target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
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
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)
                 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)
                 && (this.CollectRatePrtDiv == target.CollectRatePrtDiv)
                 && (this.BalanceDepositDtl == target.BalanceDepositDtl)
                 && (this.IsBillOutputOnly == target.IsBillOutputOnly)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.IssueDay == target.IssueDay)
                 && (this.SumCustDtl == target.SumCustDtl)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                && (this.TaxPrintDiv == target.TaxPrintDiv)
                && (this.TaxRate1 == target.TaxRate1)
                && (this.TaxRate2 == target.TaxRate2)
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
                 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
        /// 請求書発行(総括)抽出条件クラス比較処理
		/// </summary>
        /// <param name="sumExtrInfo_DemandTotal1">
        ///                    比較するSumExtrInfo_DemandTotalクラスのインスタンス
		/// </param>
        /// <param name="sumExtrInfo_DemandTotal2">比較するSumExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   SumExtrInfo_DemandTotalクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SumExtrInfo_DemandTotal sumExtrInfo_DemandTotal1, SumExtrInfo_DemandTotal sumExtrInfo_DemandTotal2)
		{
			return ((sumExtrInfo_DemandTotal1.EnterpriseCode == sumExtrInfo_DemandTotal2.EnterpriseCode)
				 && (sumExtrInfo_DemandTotal1.IsSelectAllSection == sumExtrInfo_DemandTotal2.IsSelectAllSection)
				 && (sumExtrInfo_DemandTotal1.IsOutputAllSecRec == sumExtrInfo_DemandTotal2.IsOutputAllSecRec)
                 && (sumExtrInfo_DemandTotal1.ResultsAddUpSecList == sumExtrInfo_DemandTotal2.ResultsAddUpSecList)
                 && (sumExtrInfo_DemandTotal1.IsOptSection == sumExtrInfo_DemandTotal2.IsOptSection)
				 && (sumExtrInfo_DemandTotal1.IsMainOfficeFunc == sumExtrInfo_DemandTotal2.IsMainOfficeFunc)
                 && (sumExtrInfo_DemandTotal1.AddUpDate == sumExtrInfo_DemandTotal2.AddUpDate)
                 && (sumExtrInfo_DemandTotal1.CustomerCodeSt == sumExtrInfo_DemandTotal2.CustomerCodeSt)
				 && (sumExtrInfo_DemandTotal1.CustomerCodeEd == sumExtrInfo_DemandTotal2.CustomerCodeEd)
                 && (sumExtrInfo_DemandTotal1.CustomerAgentDivCd == sumExtrInfo_DemandTotal2.CustomerAgentDivCd)
				 && (sumExtrInfo_DemandTotal1.BillCollecterCdSt == sumExtrInfo_DemandTotal2.BillCollecterCdSt)
				 && (sumExtrInfo_DemandTotal1.BillCollecterCdEd == sumExtrInfo_DemandTotal2.BillCollecterCdEd)
				 && (sumExtrInfo_DemandTotal1.CustomerAgentCdSt == sumExtrInfo_DemandTotal2.CustomerAgentCdSt)
				 && (sumExtrInfo_DemandTotal1.CustomerAgentCdEd == sumExtrInfo_DemandTotal2.CustomerAgentCdEd)
                 && (sumExtrInfo_DemandTotal1.SortOrder == sumExtrInfo_DemandTotal2.SortOrder)
				 && (sumExtrInfo_DemandTotal1.OutPutPriceCond == sumExtrInfo_DemandTotal2.OutPutPriceCond)
                 && (sumExtrInfo_DemandTotal1.NewPageDiv == sumExtrInfo_DemandTotal2.NewPageDiv)
                 && (sumExtrInfo_DemandTotal1.SalesAreaCodeSt == sumExtrInfo_DemandTotal2.SalesAreaCodeSt)
                 && (sumExtrInfo_DemandTotal1.SalesAreaCodeEd == sumExtrInfo_DemandTotal2.SalesAreaCodeEd)
                 && (sumExtrInfo_DemandTotal1.CollectRatePrtDiv == sumExtrInfo_DemandTotal2.CollectRatePrtDiv)
                 && (sumExtrInfo_DemandTotal1.BalanceDepositDtl == sumExtrInfo_DemandTotal2.BalanceDepositDtl)
                 && (sumExtrInfo_DemandTotal1.IsBillOutputOnly == sumExtrInfo_DemandTotal2.IsBillOutputOnly)
                 && (sumExtrInfo_DemandTotal1.SlipPrtKind == sumExtrInfo_DemandTotal2.SlipPrtKind)
                 && (sumExtrInfo_DemandTotal1.IssueDay == sumExtrInfo_DemandTotal2.IssueDay)
                 && (sumExtrInfo_DemandTotal1.SumCustDtl == sumExtrInfo_DemandTotal2.SumCustDtl)
                 && (sumExtrInfo_DemandTotal1.AccRecDivCd == sumExtrInfo_DemandTotal2.AccRecDivCd)
                 // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                 && (sumExtrInfo_DemandTotal1.TaxPrintDiv == sumExtrInfo_DemandTotal2.TaxPrintDiv)
                 && (sumExtrInfo_DemandTotal1.TaxRate1 == sumExtrInfo_DemandTotal2.TaxRate1)
                 && (sumExtrInfo_DemandTotal1.TaxRate2 == sumExtrInfo_DemandTotal2.TaxRate2)
                 // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
                 && (sumExtrInfo_DemandTotal1.EnterpriseName == sumExtrInfo_DemandTotal2.EnterpriseName));
		}
		/// <summary>
        /// 請求書発行(総括)抽出条件クラス比較処理
		/// </summary>
        /// <param name="target">比較対象のSumExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   SumExtrInfo_DemandTotalクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SumExtrInfo_DemandTotal target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if (this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if (this.IsOutputAllSecRec != target.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if (this.ResultsAddUpSecList != target.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if (this.IsOptSection != target.IsOptSection)resList.Add("IsOptSection");
			if (this.IsMainOfficeFunc != target.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if (this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
            if (this.CustomerAgentDivCd != target.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if (this.BillCollecterCdSt != target.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if (this.BillCollecterCdEd != target.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if (this.CustomerAgentCdSt != target.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if (this.CustomerAgentCdEd != target.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
			if (this.OutPutPriceCond != target.OutPutPriceCond) resList.Add("OutPutPriceCond");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.SalesAreaCodeSt != target.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (this.SalesAreaCodeEd != target.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (this.CollectRatePrtDiv != target.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (this.BalanceDepositDtl != target.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (this.IsBillOutputOnly != target.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.IssueDay != target.IssueDay) resList.Add("IssueDay");
            if (this.SumCustDtl != target.SumCustDtl) resList.Add("SumCustDtl");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            if (this.TaxPrintDiv != target.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (this.TaxRate1 != target.TaxRate1) resList.Add("TaxRate1");
            if (this.TaxRate2 != target.TaxRate2) resList.Add("TaxRate2");
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

			return resList;
		}

		/// <summary>
        /// 請求書発行(総括)抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">比較するExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <param name="extrInfo_DemandTotal2">比較するExtrInfo_DemandTotalクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   SumExtrInfo_DemandTotalクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SumExtrInfo_DemandTotal sumExtrInfo_DemandTotal1, SumExtrInfo_DemandTotal sumExtrInfo_DemandTotal2)
		{
			ArrayList resList = new ArrayList();
			if (sumExtrInfo_DemandTotal1.EnterpriseCode != sumExtrInfo_DemandTotal2.EnterpriseCode)resList.Add("EnterpriseCode");
			if (sumExtrInfo_DemandTotal1.IsSelectAllSection != sumExtrInfo_DemandTotal2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if (sumExtrInfo_DemandTotal1.IsOutputAllSecRec != sumExtrInfo_DemandTotal2.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if (sumExtrInfo_DemandTotal1.ResultsAddUpSecList != sumExtrInfo_DemandTotal2.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if (sumExtrInfo_DemandTotal1.IsOptSection != sumExtrInfo_DemandTotal2.IsOptSection)resList.Add("IsOptSection");
            if (sumExtrInfo_DemandTotal1.IsMainOfficeFunc != sumExtrInfo_DemandTotal2.IsMainOfficeFunc) resList.Add("IsMainOfficeFunc");
            if (sumExtrInfo_DemandTotal1.AddUpDate != sumExtrInfo_DemandTotal2.AddUpDate) resList.Add("AddUpDate");
            if (sumExtrInfo_DemandTotal1.CustomerCodeSt != sumExtrInfo_DemandTotal2.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if (sumExtrInfo_DemandTotal1.CustomerCodeEd != sumExtrInfo_DemandTotal2.CustomerCodeEd)resList.Add("CustomerCodeEd");
            if (sumExtrInfo_DemandTotal1.CustomerAgentDivCd != sumExtrInfo_DemandTotal2.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if (sumExtrInfo_DemandTotal1.BillCollecterCdSt != sumExtrInfo_DemandTotal2.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if (sumExtrInfo_DemandTotal1.BillCollecterCdEd != sumExtrInfo_DemandTotal2.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if (sumExtrInfo_DemandTotal1.CustomerAgentCdSt != sumExtrInfo_DemandTotal2.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if (sumExtrInfo_DemandTotal1.CustomerAgentCdEd != sumExtrInfo_DemandTotal2.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            if (sumExtrInfo_DemandTotal1.SortOrder != sumExtrInfo_DemandTotal2.SortOrder) resList.Add("SortOrder");
			if (sumExtrInfo_DemandTotal1.OutPutPriceCond != sumExtrInfo_DemandTotal2.OutPutPriceCond)resList.Add("OutPutPriceCond");
            if (sumExtrInfo_DemandTotal1.NewPageDiv != sumExtrInfo_DemandTotal2.NewPageDiv) resList.Add("NewPageDiv");
            if (sumExtrInfo_DemandTotal1.SalesAreaCodeSt != sumExtrInfo_DemandTotal2.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (sumExtrInfo_DemandTotal1.SalesAreaCodeEd != sumExtrInfo_DemandTotal2.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (sumExtrInfo_DemandTotal1.CollectRatePrtDiv != sumExtrInfo_DemandTotal2.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (sumExtrInfo_DemandTotal1.BalanceDepositDtl != sumExtrInfo_DemandTotal2.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (sumExtrInfo_DemandTotal1.IsBillOutputOnly != sumExtrInfo_DemandTotal2.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            if (sumExtrInfo_DemandTotal1.SlipPrtKind != sumExtrInfo_DemandTotal2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (sumExtrInfo_DemandTotal1.IssueDay != sumExtrInfo_DemandTotal2.IssueDay) resList.Add("IssueDay");
            if (sumExtrInfo_DemandTotal1.SumCustDtl != sumExtrInfo_DemandTotal2.SumCustDtl) resList.Add("SumCustDtl");
            if (sumExtrInfo_DemandTotal1.AccRecDivCd != sumExtrInfo_DemandTotal2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (sumExtrInfo_DemandTotal1.EnterpriseName != sumExtrInfo_DemandTotal2.EnterpriseName) resList.Add("EnterpriseName");
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            if (sumExtrInfo_DemandTotal1.TaxPrintDiv != sumExtrInfo_DemandTotal2.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (sumExtrInfo_DemandTotal1.TaxRate1 != sumExtrInfo_DemandTotal2.TaxRate1) resList.Add("TaxRate1");
            if (sumExtrInfo_DemandTotal1.TaxRate2 != sumExtrInfo_DemandTotal2.TaxRate2) resList.Add("TaxRate2");
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

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
