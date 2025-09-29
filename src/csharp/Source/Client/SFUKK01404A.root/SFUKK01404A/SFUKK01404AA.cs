using System;
using System.Data;
using System.Collections;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using System.Collections.Generic;
using System.Collections.Specialized;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 入金入力（入金型）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金入力（入金型）ＵＩクラスのアクセスクラスです。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br>Update Note: 2007.01.18 T.Kimura MA.NS用に変更</br>
    /// <br>               ・受注・諸費用項目は使用しないので削除</br>
    /// <br>               ・インセンティブを追加</br>
    /// <br>             2007.01.22 T.Kimura</br>
    /// <br>             2007.03.27 T.Kimura SetClaimSalesで、請求売上赤黒区分にnullが入る不具合を修正</br>
    /// <br>                                 （データがおかしいからかもしれない）</br>
    /// <br>             2007.04.18 T.Kimura 得意先請求金額マスタの変更に伴い修正</br>
    /// <br>             2007.10.05 20081 疋田 勇人 入金データの変更に伴い修正</br>
    /// <br>             2008/06/26 30414 忍 幸史 Partsman用に修正</br>
    /// <br>UpdateNote : 2009/12/16 李占川 ＰＭ．ＮＳ保守依頼④</br>
    /// <br>             操作性/入力速度向上のために以下の改良を行う</br>
    /// <br>UpdateNote : 2010/03/25 工藤 MANTIS対応[15195]</br>
    /// <br>             0円入金保存時に｢金種画面｣を表示し、選択後に登録へ変更</br>
    /// <br>UpdateNote : 2010/03/25 工藤 MANTIS対応[15196]</br>
    /// <br>             入金一覧画面に｢入力担当者｣を表示へ変更</br>
    /// <br>UpdateNote : 2010/05/12 工藤 MANTIS対応[15195]</br>
    /// <br>             入金0を修正呼出し直後の保存が行えない</br>
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-支払手形データ更新追加</br>
    /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)</br>
    /// <br>              ①鑑部の集計期間の終了日をMAXに変更する。</br>
    /// <br>              ②引当情報表示の改良</br>
    /// <br>Update Note : 2011/02/09 李占川 Redmine#18848の修正</br>
    /// <br>Update Note : 2011.07.22 施炳中</br>
    /// <br>              表示不具合の為改善願います，対応連番850。</br>
    /// <br>Update Note : 2011/12/15 tianjw</br>
    /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note : K2012/07/13 FSI今野 山形部品個別依頼</br>
    /// <br>              振込金額入力時は独自の銀行コードの入力を可能に修正</br>
    /// <br>Update Note : 2012/09/21 田建委</br>
    /// <br>管理番号    : 2012/10/17配信分</br>
    /// <br>              Redmine#32415 発行者の追加対応</br>
    /// <br>Update Note : 2012/10/05 高川 悟</br>
    /// <br>              2012/10/17配信システムテスト障害No24</br>
    /// <br>              赤入金伝票を削除すると、元黒の発行者がクリアされる</br>
    /// <br>Update Note : 2012/12/24 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#33741の対応</br>
    /// <br>Update Note : 2013/01/31 田建委</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34506 売上引当タブから引当すると、入金一覧で引当が"済"、未引当額がゼロにならない対応</br>
    /// <br>Update Note : 2015/07/16 脇田 靖之</br>
    /// <br>管理番号    : 11100068-00</br>
    /// <br>              東海自動車工業課題対応一覧№1</br>
    /// <br>              　一括引当ボタン押下時、入金未引当額・引当額・売上未引当額に不正な値が表示される</br>
    /// <br>              既存障害①</br>
    /// <br>              　一括引当ボタン押下時の明細チェック有無での動作不一致</br>
    /// <br>              既存障害②</br>
    /// <br>              　赤伝発行にアプリケーションエラーが発生する</br>
    /// <br>              既存障害③</br>
    /// <br>              　一部引当を行った入金伝票を呼び出し引当金額を修正し保存を行うと、伝票の未引当額が間違った額で表示される</br>
    /// <br>              既存障害④</br>
    /// <br>              　一部引当を行った入金伝票に対して伝票合計より多い金額を引当額に入力すると過剰引当される</br>
    /// <br></br>
	/// </remarks>
	public class InputDepositNormalTypeAcs
	{
		# region Constructor
		/// <summary>
		/// 入金入力（金型）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public InputDepositNormalTypeAcs()
		{
			// 入金情報 DataSet
			this._dsDepositInfo = new DataSet();

			// 請求売上情報 DataSet
			this._dsDmdSalesInfo = new DataSet();

			// 入金得意先情報クラス
			this._depositCustomer = new DepositCustomer();

			// 入金得意先請求金額情報クラス
			this._depositCustDmdPrc = new DepositCustDmdPrc();

			// 入金マスタクラス
			this._depsitMain = new Hashtable();

			// 入金引当マスタクラス(入金番号レベルで圧縮)
			this._depositAlw = new Hashtable();

			// 請求売上マスタクラス(初回検索分)
			this._dmdSales = new ArrayList();

			// 請求売上マスタクラス(初回検索で読み込んでない分)
			this._dmdSalesSecond = new ArrayList();

			// 入金入力設定データ系アクセスクラス
			this.depositRelDataAcs = new DepositRelDataAcs();

			// 入金検索アクセスクラス
			this._searchDepsitAcs = new SearchDepsitAcs();
			
            // ↓ 20070122 18322 c
			//// 請求売上検索アクセスクラス(SFUKK01461A)
			//this._searchDmdSalesAcs = new SearchDmdSalesAcs();

			// 請求売上検索アクセスクラス
			this._searchClaimSalesAcs = new SearchClaimSalesAcs();
            // ↑ 20070122 18322 c
			
			// 入金更新アクセスクラス
			this._depsitMainAcs = new DepsitMainAcs();

			// 請求KINGETアクセスクラス
			this._kingetCustDmdPrcAcs = new KingetCustDmdPrcAcs();

            this._employeeAcs = new EmployeeAcs();

            ReadEmployee();
            
            // ↓ 20070518 18322 d 使用しないので削除
			//// 締次更新履歴取得アクセスクラス
			//this._cAddUpHisAcs = new CAddUpHisAcs();
            // ↑ 20070518 18322 d

            //// ↓ 20070801 18322 a
            //// 月次締め処理のリモートオブジェクト
            //this._iMonthlyAddUpDB = (IMonthlyAddUpDB)MediationMonthlyAddUpDB.GetCustMonthlyAddUpDB();

            //this._lastMonthlyAddUpHis = null;
            //// ↑ 20070801 18322 a

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            //----- ADD K2013/03/22 張曼 Redmine#35063 ----->>>>>
            // オプション情報キャッシュ
            CacheOptionInfo();
            //----- ADD K2013/03/22 張曼 Redmine#35063 -----<<<<<
		}
		# endregion

		# region Private Menbers
		//***************************************************************
		// 画面バインド用 DataSet
		//***************************************************************
		/// <summary>入金情報 DataSet</summary>
		private DataSet _dsDepositInfo;

		/// <summary>請求売上情報 DataSet</summary>
		private DataSet _dsDmdSalesInfo;

		/// <summary>入金得意先情報クラス</summary>
		private DepositCustomer _depositCustomer;

		/// <summary>入金得意先請求金額情報クラス</summary>
		private DepositCustDmdPrc _depositCustDmdPrc;

		//***************************************************************
		// データ保持用 データクラス
		//***************************************************************
		/// <summary>入金マスタクラス</summary>
		private Hashtable _depsitMain;

		/// <summary>入金引当マスタクラス(入金番号レベルで圧縮)</summary>
		private Hashtable _depositAlw;

		/// <summary>請求売上マスタクラス(初回検索分)</summary>
		private ArrayList _dmdSales;

		/// <summary>請求売上マスタクラス(初回検索で読み込んでない分)</summary>
		private ArrayList _dmdSalesSecond;

		//***************************************************************
		// メンバー
		//***************************************************************
		/// <summary>入金入力設定データ系アクセスクラス</summary>
		private DepositRelDataAcs depositRelDataAcs;

		/// <summary>入金検索アクセスクラス</summary>
		private SearchDepsitAcs _searchDepsitAcs;

        // ↓ 20070122 18322 c
		///// <summary>請求売上検索アクセスクラス</summary>
		//private SearchDmdSalesAcs _searchDmdSalesAcs;

		/// <summary>請求売上検索アクセスクラス</summary>
		private SearchClaimSalesAcs _searchClaimSalesAcs;
        // ↑ 20070122 18322 c

		/// <summary>入金更新アクセスクラス</summary>
		private DepsitMainAcs _depsitMainAcs;

		/// <summary>請求KINGETアクセスクラス</summary>
		private KingetCustDmdPrcAcs _kingetCustDmdPrcAcs;

        ///// <summary>月次締リモートクラス</summary>
        //private IMonthlyAddUpDB     _iMonthlyAddUpDB = null;
        ///// <summary>月次締履歴クラス</summary>
        //private MonthlyAddUpHisWork _lastMonthlyAddUpHis = null;

        // 前回月次締日
        private DateTime _lastMonthlyAddUpDay;
        // 前回締日
        private DateTime _lastAddUpDay;

        /// <summary>締日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator;

        private int _consTaxLayMethod;

        private EmployeeAcs _employeeAcs;

        private Dictionary<string, EmployeeDtl> _emoloyeeDtlDic;

        // ↓ 20070518 18322 d 使用しないので削除
		///// <summary>締次更新アクセスクラス</summary>
		//private CAddUpHisAcs _cAddUpHisAcs;
        // ↑ 20070518 18322 d
        // --- ADD K2013/03/22 張曼 Redmine#35063 ---------->>>>>
        /// <summary> 山形部品オプションフラグ</summary>
        private int _opt_YamagataCtrl;
        // --- ADD K2013/03/22 張曼 Redmine#35063 ----------<<<<<
		# endregion

		# region public const Menbers
		//***************************************************************
		// 入金情報DataSet用定数宣言(入金情報)
		//***************************************************************
		/// <summary>入金情報Table名称</summary>
		public const string ctDepositDataTable = "DepositTable";

        // ----- ADD 王君　2012/12/24 Redmine#33741 ----- >>>>>
        /// <summary>入金Guid情報Table名称</summary>
        public const string ctDepositGuidDataTable = "DepositGuidTable";
        // ----- ADD 王君　2012/12/24 Redmine#33741 ----- <<<<<

		/// <summary>入金赤黒区分</summary>
		public const string ctDepositDebitNoteCd = "ctDepositDebitNoteCd";

		/// <summary>入金赤黒名称</summary>
		public const string ctDepositDebitNoteNm = "ctDepositDebitNoteNm";

		/// <summary>入金伝票番号</summary>
		public const string ctDepositSlipNo = "DepositSlipNo";

		/// <summary>赤黒入金連結番号</summary>
		public const string ctDebitNoteLinkDepoNo = "DebitNoteLinkDepoNo";

		/// <summary>入金日付(表示用)</summary>
		public const string ctDepositDateDisp = "DepositDateDisp";
		
		/// <summary>入金日付</summary>
		public const string ctDepositDate = "DepositDate";
		
		/// <summary>計上日付</summary>
		public const string ctDepositAddUpADate = "AddUpADate";

        /// <summary>計上日付(表示用)</summary>
        public const string ctDepositAddUpADateDisp = "AddUpADateDisp";   // 2007.10.05 add

        /// <summary>受注ステータス</summary>
        public const string ctDepositAcptAnOdrStatus = "AcptAnOdrStatus"; // 2007.10.05 add

		/// <summary>自動入金区分</summary>
		public const string ctAutoDepositCd = "AutoDepositCd";

        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        ///// <summary>預り金区分コード</summary>
        //public const string ctDepositCd = "DepositCd";
		
        /// <summary>預り金区分名称</summary>
        public const string ctDepositNm = "DepositNm";
		
        ///// <summary>入金金種区分</summary>
        //public const string ctDepositKindDivCd = "DepositKindDivCd";
		
        ///// <summary>入金金種コード</summary>
        //public const string ctDepositKindCode = "DepositKindCode";
        
        /// <summary>入金金種名称</summary>
		public const string ctDepositKindName = "DepositKindName";
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 受注・諸費用（全てコメントアウト）
        ///// <summary>受注 入金額</summary>
		//public const string ctAcpOdrDeposit = "AcpOdrDeposit";
		//
		///// <summary>受注 手数料</summary>
		//public const string ctAcpOdrChargeDeposit = "AcpOdrChargeDeposit";
		//
		///// <summary>受注 値引</summary>
		//public const string ctAcpOdrDisDeposit = "AcpOdrDisDeposit";
		//
		///// <summary>受注 入金計</summary>
		//public const string ctAcpOdrDepositTotal = "AcpOdrDepositTotal";
	
		///// <summary>諸費用 入金額</summary>
		//public const string ctVariousCostDeposit = "VariousCostDeposit";
		//
		///// <summary>諸費用 手数料</summary>
		//public const string ctVarCostChargeDeposit = "VarCostChargeDeposit";
		//
		///// <summary>諸費用 値引</summary>
		//public const string ctVarCostDisDeposit = "VarCostDisDeposit";
        //
		///// <summary>諸費用 入金計</summary>
        //public const string ctVariousCostDepositTotal = "VariousCostDepositTotal";
        #endregion
        // ↑ 20070118 18322 d
		
		/// <summary>共通 入金額</summary>
		public const string ctDeposit = "Deposit";
		
		/// <summary>共通 手数料</summary>
		public const string ctFeeDeposit = "FeeDeposit";
		
		/// <summary>共通 値引</summary>
		public const string ctDiscountDeposit = "DiscountDeposit";

        // ↓ 20070118 18322 a
		//// <summary>共通 インセンティブ</summary>
		// public const string ctRebateDeposit = "RebateDeposit";  // 2007.10.05 del
        // ↑ 20070118 18322 a

		/// <summary>共通 入金計</summary>
		public const string ctDepositTotal = "DepositTotal";

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>引当</summary>
        public const string ctAllowDiv = "AllowDiv";
        // --- ADD 2010/12/20  ----------<<<<<

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>売上伝票番号</summary>
        public const string ctDepSaleSlipNum = "DepSaleSlipNum";
        // --- ADD 2010/12/20  ----------<<<<<

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 入金引当額・入金引当残 受注・諸費用（全てコメントアウト）
        ///// <summary>入金引当額 受注</summary>
		//public const string ctAcpOdrDepositAlwc_Deposit = "AcpOdrDepositAlwc";
		//
		///// <summary>入金引当残 受注</summary>
		//public const string ctAcpOdrDepoAlwcBlnce_Deposit = "AcpOdrDepoAlwcBlnce";
        //	
		///// <summary>入金引当額 諸費用</summary>
		//public const string ctVarCostDepoAlwc_Deposit = "VarCostDepoAlwc";
		//
		///// <summary>入金引当残 諸費用</summary>
        //public const string ctVarCostDepoAlwcBlnce_Deposit = "VarCostDepoAlwcBlnce";
        #endregion
        // ↑ 20070118 18322 d

		/// <summary>入金引当額 共通</summary>
		public const string ctDepositAllowance_Deposit = "DepositAllowance";
		
		/// <summary>入金引当残 共通</summary>
		public const string ctDepositAlwcBlnce_Deposit = "DepositAlwcBlnce";
		
        // 2007.10.05 del start ------------------------------------->>
        ///// <summary>クレジット/ローン区分</summary>
        //public const string ctCreditOrLoanCd = "CreditOrLoanCd";　　
		
        ///// <summary>クレジット会社コード</summary>
        //public const string ctCreditCompanyCode = "CreditCompanyCode";
        // 2007.10.05 del end ---------------------------------------<<
		
		/// <summary>手形振出日</summary>
		public const string ctDraftDrawingDate = "DraftDrawingDate";

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>手形支払期日</summary>
        public const string ctDraftPayTimeLimit = "DraftPayTimeLimit";
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        // 2007.10.05 add start -------------------------------------->>
        /// <summary>銀行コード</summary>
        public const string ctBankCode = "BankCode";
        /// <summary>銀行名称</summary>
        public const string ctBankName = "BankName";
        /// <summary>手形番号</summary>
        public const string ctDraftNo = "DraftNo";
        /// <summary>手形種類</summary>
        public const string ctDraftKind = "DraftKind";
        /// <summary>手形種類名称</summary>
        public const string ctDraftKindName = "DraftKindName";
        /// <summary>手形区分</summary>
        public const string ctDraftDivide = "DraftDivide";
        /// <summary>手形区分名称</summary>
        public const string ctDraftDivideName = "DraftDivideName";
        // 2007.10.05 add end ----------------------------------------<<

		/// <summary>摘要</summary>
		public const string ctOutline = "Outline";

		/// <summary>締め状態</summary>
		public const string ctDepositClosedFlg = "ClosedFlg";

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>入金行番号1</summary>
        public const string ctDepositRowNo1 = "DepositRowNo1";
        /// <summary>金種コード1</summary>
        public const string ctMoneyKindCode1 = "MoneyKindCode1";
        /// <summary>金種名称1</summary>
        public const string ctMoneyKindName1 = "MoneyKindName1";
        /// <summary>金種区分1</summary>
        public const string ctMoneyKindDiv1 = "MoneyKindDiv1";
        /// <summary>入金金額1</summary>
        public const string ctDeposit1 = "Deposit1";
        /// <summary>有効期限1</summary>
        public const string ctValidityTerm1 = "ValidityTerm1";
        /// <summary>入金行番号2</summary>
        public const string ctDepositRowNo2 = "DepositRowNo2";
        /// <summary>金種コード2</summary>
        public const string ctMoneyKindCode2 = "MoneyKindCode2";
        /// <summary>金種名称2</summary>
        public const string ctMoneyKindName2 = "MoneyKindName2";
        /// <summary>金種区分2</summary>
        public const string ctMoneyKindDiv2 = "MoneyKindDiv2";
        /// <summary>入金金額2</summary>
        public const string ctDeposit2 = "Deposit2";
        /// <summary>有効期限2</summary>
        public const string ctValidityTerm2 = "ValidityTerm2";
        /// <summary>入金行番号3</summary>
        public const string ctDepositRowNo3 = "DepositRowNo3";
        /// <summary>金種コード3</summary>
        public const string ctMoneyKindCode3 = "MoneyKindCode3";
        /// <summary>金種名称3</summary>
        public const string ctMoneyKindName3 = "MoneyKindName3";
        /// <summary>金種区分3</summary>
        public const string ctMoneyKindDiv3 = "MoneyKindDiv3";
        /// <summary>入金金額3</summary>
        public const string ctDeposit3 = "Deposit3";
        /// <summary>有効期限3</summary>
        public const string ctValidityTerm3 = "ValidityTerm3";
        /// <summary>入金行番号4</summary>
        public const string ctDepositRowNo4 = "DepositRowNo4";
        /// <summary>金種コード4</summary>
        public const string ctMoneyKindCode4 = "MoneyKindCode4";
        /// <summary>金種名称4</summary>
        public const string ctMoneyKindName4 = "MoneyKindName4";
        /// <summary>金種区分4</summary>
        public const string ctMoneyKindDiv4 = "MoneyKindDiv4";
        /// <summary>入金金額4</summary>
        public const string ctDeposit4 = "Deposit4";
        /// <summary>有効期限4</summary>
        public const string ctValidityTerm4 = "ValidityTerm4";
        /// <summary>入金行番号5</summary>
        public const string ctDepositRowNo5 = "DepositRowNo5";
        /// <summary>金種コード5</summary>
        public const string ctMoneyKindCode5 = "MoneyKindCode5";
        /// <summary>金種名称5</summary>
        public const string ctMoneyKindName5 = "MoneyKindName5";
        /// <summary>金種区分5</summary>
        public const string ctMoneyKindDiv5 = "MoneyKindDiv5";
        /// <summary>入金金額5</summary>
        public const string ctDeposit5 = "Deposit5";
        /// <summary>有効期限5</summary>
        public const string ctValidityTerm5 = "ValidityTerm5";
        /// <summary>入金行番号6</summary>
        public const string ctDepositRowNo6 = "DepositRowNo6";
        /// <summary>金種コード6</summary>
        public const string ctMoneyKindCode6 = "MoneyKindCode6";
        /// <summary>金種名称6</summary>
        public const string ctMoneyKindName6 = "MoneyKindName6";
        /// <summary>金種区分6</summary>
        public const string ctMoneyKindDiv6 = "MoneyKindDiv6";
        /// <summary>入金金額6</summary>
        public const string ctDeposit6 = "Deposit6";
        /// <summary>有効期限6</summary>
        public const string ctValidityTerm6 = "ValidityTerm6";
        /// <summary>入金行番号7</summary>
        public const string ctDepositRowNo7 = "DepositRowNo7";
        /// <summary>金種コード7</summary>
        public const string ctMoneyKindCode7 = "MoneyKindCode7";
        /// <summary>金種名称7</summary>
        public const string ctMoneyKindName7 = "MoneyKindName7";
        /// <summary>金種区分7</summary>
        public const string ctMoneyKindDiv7 = "MoneyKindDiv7";
        /// <summary>入金金額7</summary>
        public const string ctDeposit7 = "Deposit7";
        /// <summary>有効期限7</summary>
        public const string ctValidityTerm7 = "ValidityTerm7";
        /// <summary>入金行番号8</summary>
        public const string ctDepositRowNo8 = "DepositRowNo8";
        /// <summary>金種コード8</summary>
        public const string ctMoneyKindCode8 = "MoneyKindCode8";
        /// <summary>金種名称8</summary>
        public const string ctMoneyKindName8 = "MoneyKindName8";
        /// <summary>金種区分8</summary>
        public const string ctMoneyKindDiv8 = "MoneyKindDiv8";
        /// <summary>入金金額8</summary>
        public const string ctDeposit8 = "Deposit8";
        /// <summary>有効期限8</summary>
        public const string ctValidityTerm8 = "ValidityTerm8";
        /// <summary>入金行番号9</summary>
        public const string ctDepositRowNo9 = "DepositRowNo9";
        /// <summary>金種コード9</summary>
        public const string ctMoneyKindCode9 = "MoneyKindCode9";
        /// <summary>金種名称9</summary>
        public const string ctMoneyKindName9 = "MoneyKindName9";
        /// <summary>金種区分9</summary>
        public const string ctMoneyKindDiv9 = "MoneyKindDiv9";
        /// <summary>入金金額9</summary>
        public const string ctDeposit9 = "Deposit9";
        /// <summary>有効期限9</summary>
        public const string ctValidityTerm9 = "ValidityTerm9";
        /// <summary>入金行番号10</summary>
        public const string ctDepositRowNo10 = "DepositRowNo10";
        /// <summary>金種コード10</summary>
        public const string ctMoneyKindCode10 = "MoneyKindCode10";
        /// <summary>金種名称10</summary>
        public const string ctMoneyKindName10 = "MoneyKindName10";
        /// <summary>金種区分10</summary>
        public const string ctMoneyKindDiv10 = "MoneyKindDiv10";
        /// <summary>入金金額10</summary>
        public const string ctDeposit10 = "Deposit10";
        /// <summary>有効期限10</summary>
        public const string ctValidityTerm10 = "ValidityTerm10";
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        // ADD 2010/03/25 MANTIS[15196]：入金一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
        /// <summary>入金入力者名称</summary>
        public const string ctDepositInputAgentNm = "DepositAgentNm";
        // ADD 2010/03/25 MANTIS[15196]：入金一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<

        //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
        /// <summary>発行者コード</summary>
        public const string ctDepositInputEmpCd = "ctDepositInputEmpCd";
        /// <summary>発行者名</summary>
        public const string ctDepositInputEmpNm = "ctDepositInputEmpNm";
        //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<

		/// <summary>自身のDataRow</summary>
		public const string ctDepositDataRow = "DepositDataRow";

		//***************************************************************
		// 入金情報DataSet用定数宣言(引当情報)
		//***************************************************************
		/// <summary>引当情報Table名称</summary>
		public const string ctAllowanceDataTable = "AllowanceTable";

		/// <summary>入金伝票番号</summary>
		public const string ctDepositSlipNo_Alw = "DepositSlipNo";

        ///// <summary>受注伝票番号</summary>
        //public const string ctAcceptAnOrderNo_Alw = "AcceptAnOrderNo";     // 2007.10.05 del

        /// <summary>受注ステータス</summary>
        public const string ctAcptAnOdrStatus_Alw = "AcptAnOdrStatus";       // 2007.10.05 add

        /// <summary>売上伝票番号</summary>
        public const string ctSalesSlipNum_Alw = "SalesSlipNum";             // 2007.10.05 add

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 入金引当額 受注・諸費用（全てコメントアウト）
        ///// <summary>入金引当額 受注</summary>
		//public const string ctAcpOdrDepositAlwc = "AcpOdrDepositAlwc";
		//
		///// <summary>入金引当額 諸費用</summary>
        //public const string ctVarCostDepoAlwc = "VarCostDepoAlwc";
        #endregion
        // ↑ 20070118 18322 d

		/// <summary>入金引当額 共通</summary>
		public const string ctDepositAllowance = "DepositAllowance";

		/// <summary>引当日(表示用)</summary>
		public const string ctReconcileDateDisp = "ReconcileDateDisp";

		/// <summary>引当日</summary>
		public const string ctReconcileDate = "ReconcileDate";

		/// <summary>引当計上日付</summary>
		public const string ctReconcileAddUpDate = "ReconcileAddUpDate";
		
		//***************************************************************
		// 請求売上情報DataSet用定数宣言
		//***************************************************************
		/// <summary>請求売上情報Table名称</summary>
		public const string ctDmdSalesDataTable = "DmdSalesTable";

		/// <summary>引</summary>
		public const string ctAlwCheck = "AlwCheck";

		/// <summary>請求売上赤黒区分</summary>
		public const string ctDmdSalesDebitNoteCd = "DmdSalesDebitNoteCd";

		/// <summary>請求売上赤黒名称</summary>
		public const string ctDmdSalesDebitNoteNm = "DmdSalesDebitNoteNm";

        ///// <summary>受注番号</summary>
        //public const string ctAcceptAnOrderNo = "AcceptAnOrderNo";　　// 2007.10.05 del

        // ↓ 20070122 18322 c MA.NS用に変更
		///// <summary>伝票番号</summary>
		//public const string ctSlipNo = "SlipNo";

        /// <summary>売上伝票番号</summary>
        public const string ctSalesSlipNum = "SalesSlipNum";
        // ↑ 20070122 18322 c

		/// <summary>伝票日付(表示用)</summary>
		public const string ctSearchSlipDateDisp = "SearchSlipDateDisp";

		/// <summary>伝票日付</summary>
		public const string ctSearchSlipDate = "SearchSlipDate";

		/// <summary>計上日付</summary>
		public const string ctAddUpADate = "AddUpADate";

		/// <summary>受注ステータス</summary>
		public const string ctAcptAnOdrStatus = "AcptAnOdrStatus";

        // ↓ 20070129 18322 a MA.NS用に変更
		/// <summary>受注ステータス名</summary>
		public const string ctAcptAnOdrStatusNm = "AcptAnOdrStatusNm";
        // ↓ 20070129 18322 a

		/// <summary>伝票種類</summary>
		public const string ctSalesKind = "SalesKind";

        // ---ADD 2011/07/22 -------->>>>>>>
        /// <summary>伝票備考</summary>
        public const string ctSlipNote = "SlipNote";

        /// <summary>最終月次締次更新日(表示用)</summary>
        public const string ctLastMonthlyDateDisp = "LastMonthlyDateDisp";

        /// <summary>最終月次更新日</summary>
        public const string ctLastMonthlyDate = "LastMonthlyDate";

        // ---ADD 2011/07/22 -------- <<<<<<

		/// <summary>売上名称</summary>
		public const string ctSalesName = "SalesName";

        // ↓ 20070122 18322 d MA.NS用に変更.
        #region SF 車両登録番号・受注売上額・諸費用額（全てコメントアウト）
        ///// <summary>車両登録番号</summary>
		//public const string ctNumberPlate = "NumberPlate";
        //
		///// <summary>受注売上額</summary>
		//public const string ctAcceptAnOrderSales = "AcceptAnOrderSales";
        //
        ///// <summary>諸費用額</summary>
        //public const string ctTotalVariousCost = "TotalVariousCost";
        #endregion
        // ↑ 20070122 18322 d

		/// <summary>伝票合計(税込)</summary>
		public const string ctTotalSales = "TotalSales";

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 引当額・引当残・引当済 受注・諸費用（全てコメントアウト）
        ///// <summary>引当額 受注 (入金引当マスタ)</summary>
		//public const string ctAcpOdrDepositAlwc_Alw = "AcpOdrDepositAlwc_Alw";
        //
		///// <summary>引当残 受注 (請求売上マスタ)</summary>
		//public const string ctAcpOdrDepoAlwcBlnce_Sales = "AcpOdrDepoAlwcBlnce_Sales";
        //
		///// <summary>引当済 受注 (請求売上マスタ)</summary>
		//public const string ctAcpOdrDepositAlwc_Sales = "AcpOdrDepositAlwc_Sales";
        //
		///// <summary>引当額 諸費用 (入金引当マスタ)</summary>
		//public const string ctVarCostDepoAlwc_Alw = "VarCostDepoAlwc_Alw";
        //
		///// <summary>引当残 諸費用 (請求売上マスタ)</summary>
		//public const string ctVarCostDepoAlwcBlnce_Sales = "VarCostDepoAlwcBlnce_Sales";
        //
		///// <summary>引当済 諸費用 (請求売上マスタ)</summary>
        //public const string ctVarCostDepoAlwc_Sales = "VarCostDepoAlwc_Sales";
        #endregion
        // ↑ 20070118 18322 d

		/// <summary>引当額 共通 (入金引当マスタ)</summary>
		public const string ctDepositAllowance_Alw = "DepositAllowance_Alw";

		/// <summary>引当残 共通 (請求売上マスタ)</summary>
		public const string ctDepositAlwcBlnce_Sales = "DepositAlwcBlnce_Sales";

		/// <summary>引当済 共通 (請求売上マスタ)</summary>
		public const string ctDepositAllowance_Sales = "DepositAllowance_Sales";

		/// <summary>入金内訳</summary>
		public const string ctDepositAlwBtn = "DepositAlwBtn";

		/// <summary>締め状態</summary>
		public const string ctSalesClosedFlg = "ClosedFlg";

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>変更前引当残(請求売上マスタ)</summary>
        public const string ctBfDepositAlwcBlnce_Sales = "BfDepositAlwcBlnce_Sales";

        /// <summary>変更前引当済(請求売上マスタ)</summary>
        public const string ctBfDepositAllowance_Sales = "BfDepositAllowance_Sales";
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        // 2007.10.05 add start ------------------------------------>>
        /// <summary>請求先コード</summary>
        public const string ctClaimCode = "ClaimCode";
        /// <summary>請求先名称</summary>
        public const string ctClaimName = "ClaimName";
        /// <summary>請求先名称2</summary>
        public const string ctClaimName2 = "ClaimName2";
        /// <summary>請求先略称</summary>
        public const string ctClaimSnm = "ClaimSnm";
        // 2007.10.05 add end --------------------------------------<<

        // ↓ 20070131 18322 a MA.NS用に変更
		/// <summary>得意先コード</summary>
		public const string ctCustomerCode = "CustomerCode";
		/// <summary>得意先名称</summary>
		public const string ctCustomerName = "CustomerName";
		/// <summary>得意先名称2</summary>
		public const string ctCustomerName2 = "CustomerName2";
        // ↑ 20070131 18322 a

        /// <summary>得意先略称</summary>
        public const string ctCustomerSnm = "CustomerSnm";  // 2007.10.05 add

        // ↓ 20070525 18322 a
		/// <summary>売掛区分(0:売掛なし,1:売掛)</summary>
        public const string ctAccRecDivCd = "AccRecDivCd";
        // 2007.10.05 hikita del start ------------------------------------>>
        ///// <summary>レジ処理日</summary>
        //public const string ctRegiProcDate = "RegiProcDate";
        ///// <summary>レジ番号</summary>
        //public const string ctCashRegisterNo = "CashRegisterNo";
        ///// <summary>POSレシート番号</summary>
        //public const string ctPosReceiptNo = "PosReceiptNo";
        // 2007.10.05 hikita del end --------------------------------------<<
        // ↑ 20070525 18322 a
        
		/// <summary>自身のDataRow</summary>
		public const string ctSalesDataRow = "SalesDataRow";

		//***************************************************************
		// リレーション情報
		//***************************************************************
		/// <summary>入金情報--引当情報リレーション名称</summary>
		public const string ctRelation_DepositAllowance = "Relation_DepositAllowance";
		# endregion

		# region public property
		# endregion

		# region public Methods
		/// <summary>
		/// 入金入力画面(入金型)アクセスクラス 初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : アクセスクラスを初期化します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void Initialize()
		{
		}

		/// <summary>
		/// 入金情報DataSet初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : DataSetを初期化します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ClearDsDepositInfo()
		{
			// DataSet初期化
			this._dsDepositInfo.Clear();

			// 入金マスタクラス
			this._depsitMain.Clear();

			// 入金引当マスタクラス(入金番号レベルで圧縮)
            this._depositAlw.Clear();
		}

        // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
        /// <summary>
        /// 入金情報DataSet初期化処理(入金検索画面用)
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : DataSetを初期化します。</br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        public void ClearDsDepositInfoUE()
        {
            // DataSet初期化
            int i = this._dsDepositInfo.Tables.Count;
            for (int k = 0; k < i; k++)
            {
                if (this._dsDepositInfo.Tables[k].TableName != "DepositGuidTable" && this._dsDepositInfo.Tables[k].TableName != "DepositTable")
                {
                    this._dsDepositInfo.Tables[k].Clear();
                }
            }

            this._dsDepositInfo.Tables[ctDepositDataTable].Clear();
            // 入金マスタクラス
            this._depsitMain.Clear();
            // 入金引当マスタクラス(入金番号レベルで圧縮)
            this._depositAlw.Clear();
        }

        /// <summary>
        /// 入金情報DataSet初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : DataSetを初期化します。</br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        public void ClearDsGuidDepositInfo()
        {
            // DataSet初期化
            this._dsDepositInfo.Tables[ctDepositGuidDataTable].Clear();

            // 入金マスタクラス
            this._depsitMain.Clear();

            // 入金引当マスタクラス(入金番号レベルで圧縮)
            this._depositAlw.Clear();
        }
        // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<

		/// <summary>
		/// 請求売上情報DataSet初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : DataSetを初期化します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ClearDmdSalesInfo()
		{
			// DataSet初期化
			this._dsDmdSalesInfo.Clear();

			// 請求売上マスタクラス(初回検索分)
			this._dmdSales.Clear();

			// 請求売上マスタクラス(初回検索で読み込んでない分)
			this._dmdSalesSecond.Clear();
		}
		
		/// <summary>
		/// 入金得意先情報クラス初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 入金得意先情報クラスを初期化します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ClearDepositCustomer()
		{
			this._depositCustomer = new DepositCustomer();
		}

		/// <summary>
		/// 入金得意先請求金額情報クラス初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 入金得意先請求金額情報クラスを初期化します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ClearDepositCustDmdPrc()
		{
			this._depositCustDmdPrc = new DepositCustDmdPrc();
		}
		
		/// <summary>
		/// 入金情報DataSet取得処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : DataSetを取得します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataSet GetDsDepositInfo()
		{
			return this._dsDepositInfo;
		}

		/// <summary>
		/// 請求売上情報DataSet取得処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : DataSetを取得します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataSet GetDsDmdSalesInfo()
		{
			return this._dsDmdSalesInfo;
		}
		
		/// <summary>
		/// 入金得意先情報クラス取得処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 入金得意先情報クラスを取得します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DepositCustomer GetDepositCustomer()
		{
			return this._depositCustomer;
		}

		/// <summary>
		/// 入金得意先請求金額情報クラス取得処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 入金得意先請求金額情報クラスを取得します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DepositCustDmdPrc GetDepositCustDmdPrc()
		{
			return this._depositCustDmdPrc;
		}
		
		/// <summary>
		/// 最終月次締め日取得処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 最終月次締め日取得を取得します。</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.08.01</br>
		/// </remarks>
		public int GetLastMonthlyDate()
		{
            int result = 0;

            //if (this._lastMonthlyAddUpHis != null)
            //{
            //    result = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpHis.MonthlyAddUpDate);
            //}

            if (this._lastMonthlyAddUpDay != null)
            {
                result = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay);
            }

            return result;
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金情報 DataSet Table 作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金情報データセットのテーブルを作成します。
		///	               :   ※ Method : GetDsDepositInfo より結果取得</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public void CreateDepositDataTable()
		{
            // ↓ 20070131 18322 c MA.NS用に変更
            #region SF 入金情報 列設定（全てコメントアウト）
			//// データテーブルの列定義
			//DataTable dtDepositTable = new DataTable(ctDepositDataTable);
            //
			//dtDepositTable.Columns.Add(ctDepositDebitNoteCd, typeof(int));				// 入金赤黒区分
			//dtDepositTable.Columns.Add(ctDepositDebitNoteNm, typeof(string));			// 入金赤黒名称
			//dtDepositTable.Columns.Add(ctDepositSlipNo, typeof(int));					// 入金伝票番号
			//dtDepositTable.Columns.Add(ctDebitNoteLinkDepoNo, typeof(int));				// 赤黒入金連結番号
			//dtDepositTable.Columns.Add(ctDepositDateDisp, typeof(string));				// 入金日付(表示用)
			//dtDepositTable.Columns.Add(ctDepositDate, typeof(int));						// 入金日付
			//dtDepositTable.Columns.Add(ctDepositAddUpADate, typeof(int));				// 計上日付
			//dtDepositTable.Columns.Add(ctAutoDepositCd, typeof(int));					// 自動入金区分
			//dtDepositTable.Columns.Add(ctDepositCd, typeof(int));						// 預り金区分コード
			//dtDepositTable.Columns.Add(ctDepositNm, typeof(string));					// 預り金区分名称
			//dtDepositTable.Columns.Add(ctDepositKindDivCd, typeof(int));				// 入金金種区分
			//dtDepositTable.Columns.Add(ctDepositKindCode, typeof(int));					// 入金金種コード
			//dtDepositTable.Columns.Add(ctDepositKindName, typeof(string));				// 入金金種名称
			//dtDepositTable.Columns.Add(ctAcpOdrDeposit, typeof(Int64));					// 受注 入金額
			//dtDepositTable.Columns.Add(ctAcpOdrChargeDeposit, typeof(Int64));			// 受注 手数料
			//dtDepositTable.Columns.Add(ctAcpOdrDisDeposit, typeof(Int64));				// 受注 値引
			//dtDepositTable.Columns.Add(ctAcpOdrDepositTotal, typeof(Int64));			// 受注 入金計
			//dtDepositTable.Columns.Add(ctVariousCostDeposit, typeof(Int64));			// 諸費用 入金額
			//dtDepositTable.Columns.Add(ctVarCostChargeDeposit, typeof(Int64));			// 諸費用 手数料
			//dtDepositTable.Columns.Add(ctVarCostDisDeposit, typeof(Int64));				// 諸費用 値引
			//dtDepositTable.Columns.Add(ctVariousCostDepositTotal, typeof(Int64));		// 諸費用 入金計
			//dtDepositTable.Columns.Add(ctDeposit, typeof(Int64));						// 共通 入金額
			//dtDepositTable.Columns.Add(ctFeeDeposit, typeof(Int64));					// 共通 手数料
			//dtDepositTable.Columns.Add(ctDiscountDeposit, typeof(Int64));				// 共通 値引
			//dtDepositTable.Columns.Add(ctDepositTotal, typeof(Int64));					// 共通 入金計
			//dtDepositTable.Columns.Add(ctAcpOdrDepositAlwc_Deposit, typeof(Int64));		// 入金引当額 受注
			//dtDepositTable.Columns.Add(ctAcpOdrDepoAlwcBlnce_Deposit, typeof(Int64));	// 入金引当残 受注
			//dtDepositTable.Columns.Add(ctVarCostDepoAlwc_Deposit, typeof(Int64));		// 入金引当額 諸費用
			//dtDepositTable.Columns.Add(ctVarCostDepoAlwcBlnce_Deposit, typeof(Int64));	// 入金引当残 諸費用
			//dtDepositTable.Columns.Add(ctDepositAllowance_Deposit, typeof(Int64));		// 入金引当額 共通
			//dtDepositTable.Columns.Add(ctDepositAlwcBlnce_Deposit, typeof(Int64));		// 入金引当残 共通
			//dtDepositTable.Columns.Add(ctCreditOrLoanCd, typeof(int));					// クレジット/ローン区分
			//dtDepositTable.Columns.Add(ctCreditCompanyCode, typeof(string));			// クレジット会社コード
			//dtDepositTable.Columns.Add(ctDraftDrawingDate, typeof(int));				// 手形振出日
			//dtDepositTable.Columns.Add(ctDraftPayTimeLimit, typeof(int));				// 手形支払期日
			//dtDepositTable.Columns.Add(ctOutline, typeof(string));						// 摘要
			//dtDepositTable.Columns.Add(ctDepositClosedFlg, typeof(string));				// 締フラグ
			//dtDepositTable.Columns.Add(ctDepositDataRow, typeof(DataRow));				// 自身のDataRow
			//
			//// データセットに追加
			//_dsDepositInfo.Tables.Add(dtDepositTable.Clone());
			//
			//
			//// データテーブルの列定義
			//DataTable dtAllowanceTable = new DataTable(ctAllowanceDataTable);
			//
			//// Addを行う順番が、列の表示順位となります。
			//dtAllowanceTable.Columns.Add(ctDepositSlipNo_Alw, typeof(int));				// 入金伝票番号
			//dtAllowanceTable.Columns.Add(ctAcceptAnOrderNo_Alw, typeof(int));			// 受注伝票番号
			//dtAllowanceTable.Columns.Add(ctAcpOdrDepositAlwc, typeof(Int64));			// 入金引当額 受注
			//dtAllowanceTable.Columns.Add(ctVarCostDepoAlwc, typeof(Int64));				// 入金引当額 諸費用
			//dtAllowanceTable.Columns.Add(ctDepositAllowance, typeof(Int64));			// 入金引当額 共通
			//dtAllowanceTable.Columns.Add(ctReconcileDateDisp, typeof(string));			// 引当日(表示用)
			//dtAllowanceTable.Columns.Add(ctReconcileDate, typeof(int));					// 引当日
			//dtAllowanceTable.Columns.Add(ctReconcileAddUpDate, typeof(int));			// 引当計上日付
			//
			//// データセットに追加
			//_dsDepositInfo.Tables.Add(dtAllowanceTable.Clone());
            #endregion

            //---------------------------------
            // 入金テーブル
            //---------------------------------
            // データテーブルの列定義
			DataTable dtDepositTable = new DataTable(ctDepositDataTable);

			// Addを行う順番が、列の表示順位となります。
			dtDepositTable.Columns.Add(ctDepositDebitNoteCd, typeof(int));				// 入金赤黒区分
			dtDepositTable.Columns.Add(ctDepositDebitNoteNm, typeof(string));			// 入金赤黒名称
			dtDepositTable.Columns.Add(ctDepositSlipNo, typeof(int));					// 入金伝票番号
			//dtDepositTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));	        	// 受注伝票番号         // 2007.10.05 del
            dtDepositTable.Columns.Add(ctSalesSlipNum, typeof(string));	        		// 売上伝票番号         // 2007.10.05 add
			dtDepositTable.Columns.Add(ctDebitNoteLinkDepoNo, typeof(int));				// 赤黒入金連結番号
			dtDepositTable.Columns.Add(ctDepositDateDisp, typeof(string));				// 入金日付(表示用)
			dtDepositTable.Columns.Add(ctDepositDate, typeof(int));						// 入金日付
			dtDepositTable.Columns.Add(ctDepositAddUpADate, typeof(int));				// 計上日付
            dtDepositTable.Columns.Add(ctDepositAddUpADateDisp, typeof(string));		// 計上日付(表示用)     // 2007.10.05 add
            dtDepositTable.Columns.Add(ctDepositAcptAnOdrStatus, typeof(int));			// 受注ステータス       // 2007.10.05 add
            dtDepositTable.Columns.Add(ctAutoDepositCd, typeof(int));					// 自動入金区分

            dtDepositTable.Columns.Add(ctDepositCd, typeof(int));						// 預り金区分コード
			dtDepositTable.Columns.Add(ctDepositNm, typeof(string));					// 預り金区分名称
            dtDepositTable.Columns.Add(ctDepositKindDivCd, typeof(int));				// 入金金種区分
            dtDepositTable.Columns.Add(ctDepositKindCode, typeof(int));					// 入金金種コード
            
            dtDepositTable.Columns.Add(ctDepositKindName, typeof(string));				// 入金金種名称
			dtDepositTable.Columns.Add(ctDeposit, typeof(Int64));						// 共通 入金額
			dtDepositTable.Columns.Add(ctFeeDeposit, typeof(Int64));					// 共通 手数料
			dtDepositTable.Columns.Add(ctDiscountDeposit, typeof(Int64));				// 共通 値引
			// dtDepositTable.Columns.Add(ctRebateDeposit, typeof(Int64));                 // 共通 インセンティブ     // 2007.10.05 del
			dtDepositTable.Columns.Add(ctDepositTotal, typeof(Int64));					// 共通 入金計
			dtDepositTable.Columns.Add(ctDepositAllowance_Deposit, typeof(Int64));		// 入金引当額 共通
			dtDepositTable.Columns.Add(ctDepositAlwcBlnce_Deposit, typeof(Int64));		// 入金引当残 共通
            // dtDepositTable.Columns.Add(ctCreditOrLoanCd, typeof(int));					// クレジット/ローン区分  // 2007.10.05 del
            // dtDepositTable.Columns.Add(ctCreditCompanyCode, typeof(string));			// クレジット会社コード       // 2007.10.05 del
			dtDepositTable.Columns.Add(ctDraftDrawingDate, typeof(int));				// 手形振出日

			dtDepositTable.Columns.Add(ctDraftPayTimeLimit, typeof(int));				// 手形支払期日

            // 2007.10.05 hikita add start -------------------------------------------------------------------->>
            dtDepositTable.Columns.Add(ctBankCode, typeof(int));                        // 銀行コード
            dtDepositTable.Columns.Add(ctBankName, typeof(string));                     // 銀行名称
            dtDepositTable.Columns.Add(ctDraftNo, typeof(string));                      // 手形番号
            dtDepositTable.Columns.Add(ctDraftKind, typeof(int));                       // 手形種類コード 
            dtDepositTable.Columns.Add(ctDraftKindName, typeof(string));                // 手形種類名称
            dtDepositTable.Columns.Add(ctDraftDivide, typeof(int));                     // 手形区分コード 
            dtDepositTable.Columns.Add(ctDraftDivideName, typeof(string));              // 手形区分名称
            // 2007.10.05 hikita add end ----------------------------------------------------------------------<<
			dtDepositTable.Columns.Add(ctOutline, typeof(string));						// 摘要
			dtDepositTable.Columns.Add(ctDepositClosedFlg, typeof(string));				// 締フラグ
            dtDepositTable.Columns.Add(ctDepositDataRow, typeof(DataRow));				// 自身のDataRow

			// データセットに追加
			_dsDepositInfo.Tables.Add(dtDepositTable.Clone());

            //---------------------------------
            // 入金引当テーブル
            //---------------------------------
			// データテーブルの列定義
			DataTable dtAllowanceTable = new DataTable(ctAllowanceDataTable);

			// Addを行う順番が、列の表示順位となります。
			dtAllowanceTable.Columns.Add(ctDepositSlipNo_Alw, typeof(int));				// 入金伝票番号
			// dtAllowanceTable.Columns.Add(ctAcceptAnOrderNo_Alw, typeof(int));		// 受注伝票番号    // 2007.10.05 del
            dtAllowanceTable.Columns.Add(ctAcptAnOdrStatus_Alw, typeof(int));			// 受注ステータス  // 2007.10.05 add
            dtAllowanceTable.Columns.Add(ctSalesSlipNum,typeof(string));                // 売上伝票番号
			dtAllowanceTable.Columns.Add(ctDepositAllowance, typeof(Int64));			// 入金引当額 共通
			dtAllowanceTable.Columns.Add(ctReconcileDateDisp, typeof(string));			// 引当日(表示用)
			dtAllowanceTable.Columns.Add(ctReconcileDate, typeof(int));					// 引当日
			dtAllowanceTable.Columns.Add(ctReconcileAddUpDate, typeof(int));			// 引当計上日付

			// データセットに追加
			_dsDepositInfo.Tables.Add(dtAllowanceTable.Clone());
            // ↑ 20070131 18322 c

			// リレーション設定
			DataRelation re = new DataRelation(ctRelation_DepositAllowance, _dsDepositInfo.Tables[ctDepositDataTable].Columns[ctDepositSlipNo], _dsDepositInfo.Tables[ctAllowanceDataTable].Columns[ctDepositSlipNo_Alw]);
			_dsDepositInfo.Relations.Add(re);
		}

		/// <summary>
		/// 請求売上情報 DataSet Table 作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 請求売上情報データセットのテーブルを作成します。
		///	               :   ※ Method : GetDsDepositInfo より結果取得</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public void CreateDmdSalesDataTable()
		{
			// データテーブルの列定義
			DataTable dtDmdSalesTable = new DataTable(ctDmdSalesDataTable);

            // ↓ 20070131 18322 c MA.NS用に変更
            #region SF 請求売上情報 列設定（全てコメントアウト）
			//// Addを行う順番が、列の表示順位となります。
			//dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// 引
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepositAlwc_Alw, typeof(Int64));		// 引当額 受注 (入金引当マスタ)
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepoAlwcBlnce_Sales, typeof(Int64));	// 引当残 受注 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepositAlwc_Sales, typeof(Int64));		// 引当済 受注 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwc_Alw, typeof(Int64));			// 引当額 諸費用 (入金引当マスタ)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwcBlnce_Sales, typeof(Int64));	// 引当残 諸費用 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwc_Sales, typeof(Int64));		// 引当済 諸費用 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// 引当額 共通 (入金引当マスタ)
			//dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// 引当残 共通 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// 引当済 共通 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteCd, typeof(int));			// 請求売上赤黒区分
			//dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteNm, typeof(string));			// 請求売上赤黒名称
			//dtDmdSalesTable.Columns.Add(ctSlipNo, typeof(string));						// 伝票番号
			//dtDmdSalesTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));				// 受注番号
			//dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// 伝票日付(表示用)
			//dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// 伝票日付
			//dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// 売上日
			//dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// 伝票ステータス
			//dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// 伝票種類
			//dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// 売上名称
			//dtDmdSalesTable.Columns.Add(ctNumberPlate, typeof(string));					// 登録番号
			//dtDmdSalesTable.Columns.Add(ctAcceptAnOrderSales, typeof(Int64));			// 受注売上額
			//dtDmdSalesTable.Columns.Add(ctTotalVariousCost, typeof(Int64));				// 諸費用額
			//dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// 受注合計額
			//dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// 締フラグ
			//dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// 入金引当ボタン
			//dtDmdSalesTable.Columns.Add(ctSalesDataRow, typeof(DataRow));				// 自身のDataRow
            #endregion

			// Addを行う順番が、列の表示順位となります。
			dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// 引
			dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// 引当額 共通 (入金引当マスタ)
			dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// 引当残 共通 (請求売上マスタ)
			dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// 引当済 共通 (請求売上マスタ)
			dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteCd, typeof(int));			// 請求売上赤黒区分
			dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteNm, typeof(string));			// 請求売上赤黒名称
			// dtDmdSalesTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));				// 受注番号             // 2007.10.05 hikita del
            dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                // 売上伝票番号
			dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// 伝票日付(表示用)
			dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// 伝票日付
			dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// 売上日
   			dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// 受注ステータス
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatusNm, typeof(string));           // 受注ステータス名
   			dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// 伝票種類
			dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// 売上名称
			dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// 伝票合計(税込)
			dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// 締フラグ
			dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// 入金引当ボタン
            dtDmdSalesTable.Columns.Add(ctClaimCode, typeof(int));				        // 請求先コード
            dtDmdSalesTable.Columns.Add(ctClaimName, typeof(string));				    // 請求先名称
            dtDmdSalesTable.Columns.Add(ctClaimName2, typeof(string));				    // 請求先名称2
            dtDmdSalesTable.Columns.Add(ctClaimSnm, typeof(string));				    // 請求先略称
			dtDmdSalesTable.Columns.Add(ctCustomerCode , typeof(int));				    // 得意先コード
            dtDmdSalesTable.Columns.Add(ctCustomerName , typeof(string));				// 得意先名称
			dtDmdSalesTable.Columns.Add(ctCustomerName2, typeof(string));				// 得意先名称2
            dtDmdSalesTable.Columns.Add(ctCustomerSnm, typeof(string));				    // 得意先略称

            // ↓ 20070525 18322 a
            dtDmdSalesTable.Columns.Add(ctAccRecDivCd   , typeof(int));				// 掛売区分
            // 2007.10.05 hikita del start -------------------------------------------------------------->>
            // dtDmdSalesTable.Columns.Add(ctRegiProcDate  , typeof(string));  	    // レジ処理日
            // dtDmdSalesTable.Columns.Add(ctCashRegisterNo, typeof(int));				// レジ番号
            // dtDmdSalesTable.Columns.Add(ctPosReceiptNo  , typeof(int));				// POSレシート番号
            // 2007.10.05 hikita del end ----------------------------------------------------------------<<
            // ↑ 20070525 18322 a
           
            dtDmdSalesTable.Columns.Add(ctSalesDataRow, typeof(DataRow));				// 自身のDataRow
            // ↑ 20070131 18322 c
			
			// データセットに追加
			_dsDmdSalesInfo.Tables.Add(dtDmdSalesTable.Clone());
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
        /// 入金情報 DataSet Table 作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金情報データセットのテーブルを作成します。
        ///	               :   ※ Method : GetDsDepositInfo より結果取得</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// <br>Update Note: 2012/09/21 田建委</br>
        /// <br>管理番号   : 2012/10/17配信分</br>
        /// <br>             Redmine#32415 発行者の追加対応</br>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// </remarks>
        public void CreateDepositDataTable()
        {
            //---------------------------------
            // 入金テーブル
            //---------------------------------
            // データテーブルの列定義
            DataTable dtDepositTable = new DataTable(ctDepositDataTable);

            // Addを行う順番が、列の表示順位となります。
            dtDepositTable.Columns.Add(ctDepositDebitNoteCd, typeof(Int32));			// 入金赤黒区分
            dtDepositTable.Columns.Add(ctDepositDebitNoteNm, typeof(string));			// 入金赤黒名称
            dtDepositTable.Columns.Add(ctDepositSlipNo, typeof(Int32));					// 入金伝票番号
            dtDepositTable.Columns.Add(ctSalesSlipNum, typeof(string));	        		// 売上伝票番号
            dtDepositTable.Columns.Add(ctDebitNoteLinkDepoNo, typeof(Int32));			// 赤黒入金連結番号
            dtDepositTable.Columns.Add(ctDepositDateDisp, typeof(string));				// 入金日付(表示用)
            dtDepositTable.Columns.Add(ctDepositDate, typeof(Int32));					// 入金日付
            dtDepositTable.Columns.Add(ctDepositAddUpADate, typeof(Int32));				// 計上日付
            dtDepositTable.Columns.Add(ctDepositAddUpADateDisp, typeof(string));		// 計上日付(表示用)
            dtDepositTable.Columns.Add(ctDepositAcptAnOdrStatus, typeof(Int32));		// 受注ステータス
            dtDepositTable.Columns.Add(ctAutoDepositCd, typeof(Int32));					// 自動入金区分
            dtDepositTable.Columns.Add(ctDepositNm, typeof(string));					// 預り金区分名称
            dtDepositTable.Columns.Add(ctDepositKindName, typeof(string));				// 入金金種名称(表示用)
            dtDepositTable.Columns.Add(ctDeposit, typeof(Int64));						// 共通 入金額
            dtDepositTable.Columns.Add(ctFeeDeposit, typeof(Int64));					// 共通 手数料
            dtDepositTable.Columns.Add(ctDiscountDeposit, typeof(Int64));				// 共通 値引
            dtDepositTable.Columns.Add(ctDepositTotal, typeof(Int64));					// 共通 入金計
            dtDepositTable.Columns.Add(ctAllowDiv, typeof(string));					    // 引当  // ADD 2010/12/20
            dtDepositTable.Columns.Add(ctDepositAllowance_Deposit, typeof(Int64));		// 入金引当額 共通
            dtDepositTable.Columns.Add(ctDepositAlwcBlnce_Deposit, typeof(Int64));		// 入金引当残 共通
            dtDepositTable.Columns.Add(ctDraftDrawingDate, typeof(Int32));				// 手形振出日
            dtDepositTable.Columns.Add(ctBankCode, typeof(Int32));                      // 銀行コード
            dtDepositTable.Columns.Add(ctBankName, typeof(string));                     // 銀行名称
            dtDepositTable.Columns.Add(ctDraftNo, typeof(string));                      // 手形番号
            dtDepositTable.Columns.Add(ctDraftKind, typeof(Int32));                     // 手形種類コード 
            dtDepositTable.Columns.Add(ctDraftKindName, typeof(string));                // 手形種類名称
            dtDepositTable.Columns.Add(ctDraftDivide, typeof(Int32));                   // 手形区分コード 
            dtDepositTable.Columns.Add(ctDraftDivideName, typeof(string));              // 手形区分名称
            dtDepositTable.Columns.Add(ctOutline, typeof(string));						// 摘要
            dtDepositTable.Columns.Add(ctDepositClosedFlg, typeof(string));				// 締フラグ
            dtDepositTable.Columns.Add(ctDepositRowNo1, typeof(Int32));				    // 入金行番号1
            dtDepositTable.Columns.Add(ctMoneyKindCode1, typeof(Int32));				// 金種コード1
            dtDepositTable.Columns.Add(ctMoneyKindName1, typeof(string));				// 金種名称1
            dtDepositTable.Columns.Add(ctMoneyKindDiv1, typeof(Int32));				    // 金種区分1
            dtDepositTable.Columns.Add(ctDeposit1, typeof(Int64));				        // 入金金額1
            dtDepositTable.Columns.Add(ctValidityTerm1, typeof(DateTime));				// 有効期限1
            dtDepositTable.Columns.Add(ctDepositRowNo2, typeof(Int32));				    // 入金行番号2
            dtDepositTable.Columns.Add(ctMoneyKindCode2, typeof(Int32));				// 金種コード2
            dtDepositTable.Columns.Add(ctMoneyKindName2, typeof(string));				// 金種名称2
            dtDepositTable.Columns.Add(ctMoneyKindDiv2, typeof(Int32));				    // 金種区分2
            dtDepositTable.Columns.Add(ctDeposit2, typeof(Int64));				        // 入金金額2
            dtDepositTable.Columns.Add(ctValidityTerm2, typeof(DateTime));				// 有効期限2
            dtDepositTable.Columns.Add(ctDepositRowNo3, typeof(Int32));				    // 入金行番号3
            dtDepositTable.Columns.Add(ctMoneyKindCode3, typeof(Int32));				// 金種コード3
            dtDepositTable.Columns.Add(ctMoneyKindName3, typeof(string));				// 金種名称3
            dtDepositTable.Columns.Add(ctMoneyKindDiv3, typeof(Int32));				    // 金種区分3
            dtDepositTable.Columns.Add(ctDeposit3, typeof(Int64));				        // 入金金額3
            dtDepositTable.Columns.Add(ctValidityTerm3, typeof(DateTime));				// 有効期限3
            dtDepositTable.Columns.Add(ctDepositRowNo4, typeof(Int32));				    // 入金行番号4
            dtDepositTable.Columns.Add(ctMoneyKindCode4, typeof(Int32));				// 金種コード4
            dtDepositTable.Columns.Add(ctMoneyKindName4, typeof(string));				// 金種名称4
            dtDepositTable.Columns.Add(ctMoneyKindDiv4, typeof(Int32));				    // 金種区分4
            dtDepositTable.Columns.Add(ctDeposit4, typeof(Int64));				        // 入金金額4
            dtDepositTable.Columns.Add(ctValidityTerm4, typeof(DateTime));				// 有効期限4
            dtDepositTable.Columns.Add(ctDepositRowNo5, typeof(Int32));				    // 入金行番号5
            dtDepositTable.Columns.Add(ctMoneyKindCode5, typeof(Int32));				// 金種コード5
            dtDepositTable.Columns.Add(ctMoneyKindName5, typeof(string));				// 金種名称5
            dtDepositTable.Columns.Add(ctMoneyKindDiv5, typeof(Int32));				    // 金種区分5
            dtDepositTable.Columns.Add(ctDeposit5, typeof(Int64));				        // 入金金額5
            dtDepositTable.Columns.Add(ctValidityTerm5, typeof(DateTime));				// 有効期限5
            dtDepositTable.Columns.Add(ctDepositRowNo6, typeof(Int32));				    // 入金行番号6
            dtDepositTable.Columns.Add(ctMoneyKindCode6, typeof(Int32));				// 金種コード6
            dtDepositTable.Columns.Add(ctMoneyKindName6, typeof(string));				// 金種名称6
            dtDepositTable.Columns.Add(ctMoneyKindDiv6, typeof(Int32));				    // 金種区分6
            dtDepositTable.Columns.Add(ctDeposit6, typeof(Int64));				        // 入金金額6
            dtDepositTable.Columns.Add(ctValidityTerm6, typeof(DateTime));				// 有効期限6
            dtDepositTable.Columns.Add(ctDepositRowNo7, typeof(Int32));				    // 入金行番号7
            dtDepositTable.Columns.Add(ctMoneyKindCode7, typeof(Int32));				// 金種コード7
            dtDepositTable.Columns.Add(ctMoneyKindName7, typeof(string));				// 金種名称7
            dtDepositTable.Columns.Add(ctMoneyKindDiv7, typeof(Int32));				    // 金種区分7
            dtDepositTable.Columns.Add(ctDeposit7, typeof(Int64));				        // 入金金額7
            dtDepositTable.Columns.Add(ctValidityTerm7, typeof(DateTime));				// 有効期限7
            dtDepositTable.Columns.Add(ctDepositRowNo8, typeof(Int32));				    // 入金行番号8
            dtDepositTable.Columns.Add(ctMoneyKindCode8, typeof(Int32));				// 金種コード8
            dtDepositTable.Columns.Add(ctMoneyKindName8, typeof(string));				// 金種名称8
            dtDepositTable.Columns.Add(ctMoneyKindDiv8, typeof(Int32));				    // 金種区分8
            dtDepositTable.Columns.Add(ctDeposit8, typeof(Int64));				        // 入金金額8
            dtDepositTable.Columns.Add(ctValidityTerm8, typeof(DateTime));				// 有効期限8
            dtDepositTable.Columns.Add(ctDepositRowNo9, typeof(Int32));				    // 入金行番号9
            dtDepositTable.Columns.Add(ctMoneyKindCode9, typeof(Int32));				// 金種コード9
            dtDepositTable.Columns.Add(ctMoneyKindName9, typeof(string));				// 金種名称9
            dtDepositTable.Columns.Add(ctMoneyKindDiv9, typeof(Int32));				    // 金種区分9
            dtDepositTable.Columns.Add(ctDeposit9, typeof(Int64));				        // 入金金額9
            dtDepositTable.Columns.Add(ctValidityTerm9, typeof(DateTime));				// 有効期限9
            dtDepositTable.Columns.Add(ctDepositRowNo10, typeof(Int32));				// 入金行番号10
            dtDepositTable.Columns.Add(ctMoneyKindCode10, typeof(Int32));				// 金種コード10
            dtDepositTable.Columns.Add(ctMoneyKindName10, typeof(string));				// 金種名称10
            dtDepositTable.Columns.Add(ctMoneyKindDiv10, typeof(Int32));				// 金種区分10
            dtDepositTable.Columns.Add(ctDeposit10, typeof(Int64));				        // 入金金額10
            dtDepositTable.Columns.Add(ctValidityTerm10, typeof(DateTime));				// 有効期限10

            // ADD 2010/03/25 MANTIS[15196]：入金一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
            dtDepositTable.Columns.Add(ctDepositInputAgentNm, typeof(string));          // 入金入力者名称
            // ADD 2010/03/25 MANTIS[15196]：入金一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<

            //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
            dtDepositTable.Columns.Add(ctDepositInputEmpCd, typeof(string));          // 発行者コード
            dtDepositTable.Columns.Add(ctDepositInputEmpNm, typeof(string));          // 発行者名
            //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<
            // ---- ADD 2012/12/24 王君 Redmine#33741 ----------->>>>>
            dtDepositTable.Columns.Add(ctCustomerCode, typeof(Int32));   // 得意先コード
            dtDepositTable.Columns.Add(ctCustomerName, typeof(string));  // 得意先名称
            // ---- ADD 2012/12/24 王君 Redmine#33741 -----------<<<<<
            
            dtDepositTable.Columns.Add(ctDepositDataRow, typeof(DataRow));				// 自身のDataRow

            // データセットに追加
            this._dsDepositInfo.Tables.Add(dtDepositTable.Clone());

            //---------------------------------
            // 入金引当テーブル
            //---------------------------------
            // データテーブルの列定義
            DataTable dtAllowanceTable = new DataTable(ctAllowanceDataTable);

            // Addを行う順番が、列の表示順位となります。
            dtAllowanceTable.Columns.Add(ctDepositSlipNo_Alw, typeof(int));				// 入金伝票番号
            dtAllowanceTable.Columns.Add(ctAcptAnOdrStatus_Alw, typeof(int));			// 受注ステータス
            dtAllowanceTable.Columns.Add(ctSalesSlipNum, typeof(string));               // 売上伝票番号
            dtAllowanceTable.Columns.Add(ctDepositAllowance, typeof(Int64));			// 入金引当額 共通
            dtAllowanceTable.Columns.Add(ctReconcileDateDisp, typeof(string));			// 引当日(表示用)
            dtAllowanceTable.Columns.Add(ctReconcileDate, typeof(int));					// 引当日
            dtAllowanceTable.Columns.Add(ctReconcileAddUpDate, typeof(int));			// 引当計上日付

            // データセットに追加
            this._dsDepositInfo.Tables.Add(dtAllowanceTable.Clone());

            // リレーション設定
            DataRelation re = new DataRelation(ctRelation_DepositAllowance, this._dsDepositInfo.Tables[ctDepositDataTable].Columns[ctDepositSlipNo], this._dsDepositInfo.Tables[ctAllowanceDataTable].Columns[ctDepositSlipNo_Alw]);
            this._dsDepositInfo.Relations.Add(re);
        }

        /// <summary>
        /// 請求売上情報 DataSet Table 作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 請求売上情報データセットのテーブルを作成します。
        ///	               :   ※ Method : GetDsDepositInfo より結果取得</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        public void CreateDmdSalesDataTable()
        {
            // データテーブルの列定義
            DataTable dtDmdSalesTable = new DataTable(ctDmdSalesDataTable);

            // Addを行う順番が、列の表示順位となります。
            dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// 引
            dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// 引当額 共通 (入金引当マスタ)
            dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// 引当残 共通 (請求売上マスタ)
            // ---ADD 2011/07/22 -------->>>>>>> 
            dtDmdSalesTable.Columns.Add(ctAllowDiv, typeof(string));                    // 引当
            dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                // 売上伝票番号
            dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// 伝票日付(表示用)
            dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				// 得意先名称
            dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// 伝票種類
            dtDmdSalesTable.Columns.Add(ctSlipNote, typeof(string));					// 伝票備考
            dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// 伝票合計(税込)
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDateDisp, typeof(string));         // 最終月次締め日(表示用)
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDate, typeof(string));         // 最終月次締め日
            
            // ---ADD 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctBfDepositAlwcBlnce_Sales, typeof(Int64));		// 変更前引当残(請求売上マスタ)
            dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// 引当済 共通 (請求売上マスタ)
            dtDmdSalesTable.Columns.Add(ctBfDepositAllowance_Sales, typeof(Int64));		// 変更前引当済(請求売上マスタ)
            dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteCd, typeof(int));			// 請求売上赤黒区分
            dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteNm, typeof(string));			// 請求売上赤黒名称
            // ---DEL 2011/07/22 -------->>>>>
            // dtDmdSalesTable.Columns.Add(ctAllowDiv, typeof(string));                    // 引当 // ADD 2010/12/20
            // dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                // 売上伝票番号
            // dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// 伝票日付(表示用)
            // ---DEL 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// 伝票日付
            dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// 売上日
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// 受注ステータス
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatusNm, typeof(string));           // 受注ステータス名
            // ---ADD 2011/07/22 -------->>>>>
            //dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// 伝票種類
            // ---ADD 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// 売上名称
            // ---DEL 2011/07/22 -------->>>>>
            //  dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// 伝票合計(税込)
            // ---DEL 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// 締フラグ
            dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// 入金引当ボタン
            dtDmdSalesTable.Columns.Add(ctClaimCode, typeof(int));				        // 請求先コード
            // ---DEL 2011/07/22 -------->>>>>
            dtDmdSalesTable.Columns.Add(ctClaimName, typeof(string));				    // 請求先名称
            // ---DEL 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctClaimName2, typeof(string));				    // 請求先名称2
            dtDmdSalesTable.Columns.Add(ctClaimSnm, typeof(string));				    // 請求先略称
            dtDmdSalesTable.Columns.Add(ctCustomerCode, typeof(int));				    // 得意先コード
            // ---DEL 2011/07/22 -------->>>>>
            // dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				// 得意先名称
            // ---ADD 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctCustomerName2, typeof(string));				// 得意先名称2
            dtDmdSalesTable.Columns.Add(ctCustomerSnm, typeof(string));				    // 得意先略称
            dtDmdSalesTable.Columns.Add(ctAccRecDivCd, typeof(int));				    // 掛売区分
            dtDmdSalesTable.Columns.Add(ctDepSaleSlipNum, typeof(string));				// 売上伝票番号  // ADD 2010/12/20
            dtDmdSalesTable.Columns.Add(ctSalesDataRow, typeof(DataRow));				// 自身のDataRow

            // データセットに追加
            _dsDmdSalesInfo.Tables.Add(dtDmdSalesTable.Clone());
        }


        // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
        /// <summary>
        /// 入金Guid情報 DataSet Table 作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金Guid情報データセットのテーブルを作成します。
        ///	               :   ※ Method : GetDsDepositInfo より結果取得</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2012/12/24</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// </remarks>
        public void CreateDepositGuidDataTable()
        {
            //---------------------------------
            // 入金テーブル
            //---------------------------------
            // データテーブルの列定義
            DataTable dtDepositTable = new DataTable(ctDepositGuidDataTable);

            // Addを行う順番が、列の表示順位となります。
            dtDepositTable.Columns.Add(ctDepositDebitNoteCd, typeof(Int32));			// 入金赤黒区分
            dtDepositTable.Columns.Add(ctDepositDebitNoteNm, typeof(string));			// 入金赤黒名称
            dtDepositTable.Columns.Add(ctDepositSlipNo, typeof(Int32));					// 入金伝票番号
            dtDepositTable.Columns.Add(ctSalesSlipNum, typeof(string));	        		// 売上伝票番号
            dtDepositTable.Columns.Add(ctDebitNoteLinkDepoNo, typeof(Int32));			// 赤黒入金連結番号
            dtDepositTable.Columns.Add(ctDepositDateDisp, typeof(string));				// 入金日付(表示用)
            dtDepositTable.Columns.Add(ctDepositDate, typeof(Int32));					// 入金日付
            dtDepositTable.Columns.Add(ctDepositAddUpADate, typeof(Int32));				// 計上日付
            dtDepositTable.Columns.Add(ctDepositAddUpADateDisp, typeof(string));		// 計上日付(表示用)
            dtDepositTable.Columns.Add(ctDepositAcptAnOdrStatus, typeof(Int32));		// 受注ステータス
            dtDepositTable.Columns.Add(ctAutoDepositCd, typeof(Int32));					// 自動入金区分
            dtDepositTable.Columns.Add(ctDepositNm, typeof(string));					// 預り金区分名称
            dtDepositTable.Columns.Add(ctDepositKindName, typeof(string));				// 入金金種名称(表示用)
            dtDepositTable.Columns.Add(ctDeposit, typeof(Int64));						// 共通 入金額
            dtDepositTable.Columns.Add(ctFeeDeposit, typeof(Int64));					// 共通 手数料
            dtDepositTable.Columns.Add(ctDiscountDeposit, typeof(Int64));				// 共通 値引
            dtDepositTable.Columns.Add(ctDepositTotal, typeof(Int64));					// 共通 入金計
            dtDepositTable.Columns.Add(ctAllowDiv, typeof(string));					    // 引当  // ADD 2010/12/20
            dtDepositTable.Columns.Add(ctDepositAllowance_Deposit, typeof(Int64));		// 入金引当額 共通
            dtDepositTable.Columns.Add(ctDepositAlwcBlnce_Deposit, typeof(Int64));		// 入金引当残 共通
            dtDepositTable.Columns.Add(ctDraftDrawingDate, typeof(Int32));				// 手形振出日
            dtDepositTable.Columns.Add(ctBankCode, typeof(Int32));                      // 銀行コード
            dtDepositTable.Columns.Add(ctBankName, typeof(string));                     // 銀行名称
            dtDepositTable.Columns.Add(ctDraftNo, typeof(string));                      // 手形番号
            dtDepositTable.Columns.Add(ctDraftKind, typeof(Int32));                     // 手形種類コード 
            dtDepositTable.Columns.Add(ctDraftKindName, typeof(string));                // 手形種類名称
            dtDepositTable.Columns.Add(ctDraftDivide, typeof(Int32));                   // 手形区分コード 
            dtDepositTable.Columns.Add(ctDraftDivideName, typeof(string));              // 手形区分名称
            dtDepositTable.Columns.Add(ctOutline, typeof(string));						// 摘要
            dtDepositTable.Columns.Add(ctDepositClosedFlg, typeof(string));				// 締フラグ
            dtDepositTable.Columns.Add(ctDepositRowNo1, typeof(Int32));				    // 入金行番号1
            dtDepositTable.Columns.Add(ctMoneyKindCode1, typeof(Int32));				// 金種コード1
            dtDepositTable.Columns.Add(ctMoneyKindName1, typeof(string));				// 金種名称1
            dtDepositTable.Columns.Add(ctMoneyKindDiv1, typeof(Int32));				    // 金種区分1
            dtDepositTable.Columns.Add(ctDeposit1, typeof(Int64));				        // 入金金額1
            dtDepositTable.Columns.Add(ctValidityTerm1, typeof(DateTime));				// 有効期限1
            dtDepositTable.Columns.Add(ctDepositRowNo2, typeof(Int32));				    // 入金行番号2
            dtDepositTable.Columns.Add(ctMoneyKindCode2, typeof(Int32));				// 金種コード2
            dtDepositTable.Columns.Add(ctMoneyKindName2, typeof(string));				// 金種名称2
            dtDepositTable.Columns.Add(ctMoneyKindDiv2, typeof(Int32));				    // 金種区分2
            dtDepositTable.Columns.Add(ctDeposit2, typeof(Int64));				        // 入金金額2
            dtDepositTable.Columns.Add(ctValidityTerm2, typeof(DateTime));				// 有効期限2
            dtDepositTable.Columns.Add(ctDepositRowNo3, typeof(Int32));				    // 入金行番号3
            dtDepositTable.Columns.Add(ctMoneyKindCode3, typeof(Int32));				// 金種コード3
            dtDepositTable.Columns.Add(ctMoneyKindName3, typeof(string));				// 金種名称3
            dtDepositTable.Columns.Add(ctMoneyKindDiv3, typeof(Int32));				    // 金種区分3
            dtDepositTable.Columns.Add(ctDeposit3, typeof(Int64));				        // 入金金額3
            dtDepositTable.Columns.Add(ctValidityTerm3, typeof(DateTime));				// 有効期限3
            dtDepositTable.Columns.Add(ctDepositRowNo4, typeof(Int32));				    // 入金行番号4
            dtDepositTable.Columns.Add(ctMoneyKindCode4, typeof(Int32));				// 金種コード4
            dtDepositTable.Columns.Add(ctMoneyKindName4, typeof(string));				// 金種名称4
            dtDepositTable.Columns.Add(ctMoneyKindDiv4, typeof(Int32));				    // 金種区分4
            dtDepositTable.Columns.Add(ctDeposit4, typeof(Int64));				        // 入金金額4
            dtDepositTable.Columns.Add(ctValidityTerm4, typeof(DateTime));				// 有効期限4
            dtDepositTable.Columns.Add(ctDepositRowNo5, typeof(Int32));				    // 入金行番号5
            dtDepositTable.Columns.Add(ctMoneyKindCode5, typeof(Int32));				// 金種コード5
            dtDepositTable.Columns.Add(ctMoneyKindName5, typeof(string));				// 金種名称5
            dtDepositTable.Columns.Add(ctMoneyKindDiv5, typeof(Int32));				    // 金種区分5
            dtDepositTable.Columns.Add(ctDeposit5, typeof(Int64));				        // 入金金額5
            dtDepositTable.Columns.Add(ctValidityTerm5, typeof(DateTime));				// 有効期限5
            dtDepositTable.Columns.Add(ctDepositRowNo6, typeof(Int32));				    // 入金行番号6
            dtDepositTable.Columns.Add(ctMoneyKindCode6, typeof(Int32));				// 金種コード6
            dtDepositTable.Columns.Add(ctMoneyKindName6, typeof(string));				// 金種名称6
            dtDepositTable.Columns.Add(ctMoneyKindDiv6, typeof(Int32));				    // 金種区分6
            dtDepositTable.Columns.Add(ctDeposit6, typeof(Int64));				        // 入金金額6
            dtDepositTable.Columns.Add(ctValidityTerm6, typeof(DateTime));				// 有効期限6
            dtDepositTable.Columns.Add(ctDepositRowNo7, typeof(Int32));				    // 入金行番号7
            dtDepositTable.Columns.Add(ctMoneyKindCode7, typeof(Int32));				// 金種コード7
            dtDepositTable.Columns.Add(ctMoneyKindName7, typeof(string));				// 金種名称7
            dtDepositTable.Columns.Add(ctMoneyKindDiv7, typeof(Int32));				    // 金種区分7
            dtDepositTable.Columns.Add(ctDeposit7, typeof(Int64));				        // 入金金額7
            dtDepositTable.Columns.Add(ctValidityTerm7, typeof(DateTime));				// 有効期限7
            dtDepositTable.Columns.Add(ctDepositRowNo8, typeof(Int32));				    // 入金行番号8
            dtDepositTable.Columns.Add(ctMoneyKindCode8, typeof(Int32));				// 金種コード8
            dtDepositTable.Columns.Add(ctMoneyKindName8, typeof(string));				// 金種名称8
            dtDepositTable.Columns.Add(ctMoneyKindDiv8, typeof(Int32));				    // 金種区分8
            dtDepositTable.Columns.Add(ctDeposit8, typeof(Int64));				        // 入金金額8
            dtDepositTable.Columns.Add(ctValidityTerm8, typeof(DateTime));				// 有効期限8
            dtDepositTable.Columns.Add(ctDepositRowNo9, typeof(Int32));				    // 入金行番号9
            dtDepositTable.Columns.Add(ctMoneyKindCode9, typeof(Int32));				// 金種コード9
            dtDepositTable.Columns.Add(ctMoneyKindName9, typeof(string));				// 金種名称9
            dtDepositTable.Columns.Add(ctMoneyKindDiv9, typeof(Int32));				    // 金種区分9
            dtDepositTable.Columns.Add(ctDeposit9, typeof(Int64));				        // 入金金額9
            dtDepositTable.Columns.Add(ctValidityTerm9, typeof(DateTime));				// 有効期限9
            dtDepositTable.Columns.Add(ctDepositRowNo10, typeof(Int32));				// 入金行番号10
            dtDepositTable.Columns.Add(ctMoneyKindCode10, typeof(Int32));				// 金種コード10
            dtDepositTable.Columns.Add(ctMoneyKindName10, typeof(string));				// 金種名称10
            dtDepositTable.Columns.Add(ctMoneyKindDiv10, typeof(Int32));				// 金種区分10
            dtDepositTable.Columns.Add(ctDeposit10, typeof(Int64));				        // 入金金額10
            dtDepositTable.Columns.Add(ctValidityTerm10, typeof(DateTime));				// 有効期限10
            dtDepositTable.Columns.Add(ctDepositInputAgentNm, typeof(string));          // 入金入力者名称
            dtDepositTable.Columns.Add(ctDepositInputEmpCd, typeof(string));            // 発行者コード
            dtDepositTable.Columns.Add(ctDepositInputEmpNm, typeof(string));            // 発行者名
            dtDepositTable.Columns.Add(ctCustomerCode, typeof(Int32));                  // 得意先コード
            dtDepositTable.Columns.Add(ctCustomerName, typeof(string));                 // 得意先名称
            dtDepositTable.Columns.Add(ctDepositDataRow, typeof(DataRow));				// 自身のDataRow
            // データセットに追加
            this._dsDepositInfo.Tables.Add(dtDepositTable.Clone());
        }
        // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
		/// <summary>
		/// 入金関連データ取得処理（得意先コード指定）
		/// </summary>
		/// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
		/// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ クラス</param>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
		/// <param name="getAllowanceDiv">引当/請求売上取得区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
		/// <param name="depositCustomer">入金得意先情報クラス</param>
		/// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 指定されたパラメータの得意先情報/請求金額情報を取得し返します。
		///	                : また、入金情報/請求売上情報を取得し、以下のデータセットにて返します。
		///					:   ※ 入金得意先情報         : Method : GetDepositCustomer
		///					:   ※ 入金得意先請求金額情報 : Method : GetDepositCustDmdPrc
		///					:   ※ 入金情報     : Method : GetDsDepositInfo
		///					:   ※ 請求売上情報 : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 30414 忍 幸史</br>
		/// <br>Date        : 2008/06/26</br>
        /// <br>UpdateNote  : 2009/12/16 李占川 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>              得意先入力後に入金一覧を初期表示しないように変更</br>
		/// </remarks>
		public int SearchCustomerMode(SearchCustomerParameter searchCustomerParameter, 
                                      SearchDepositParameter searchDepositParameter, 
                                      SearchSalesParameter searchSalesParameter, 
                                      bool getAllowanceDiv, 
                                      int consTaxLayMethod,
                                      out DepositCustomer depositCustomer, 
                                      out DepositCustDmdPrc depositCustDmdPrc, 
                                      out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositCustDmdPrc = null;
			depositCustomer = null;

            // 消費税転嫁方式
            this._consTaxLayMethod = consTaxLayMethod;

			try
			{
				int customerCode;
                int claimCode;
			
				// 入金得意先情報クラス初期化処理
				ClearDepositCustomer();

				// 入金得意先請求金額情報クラス初期化処理
				ClearDepositCustDmdPrc();

				// 入金情報DataSet初期化処理
				ClearDsDepositInfo();

				// 受注情報DataSet初期化処理
				ClearDmdSalesInfo();

                // 得意先情報/請求金額情報取得処理
                status = GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "得意先マスタの請求拠点が全体初期表示設定マスタに登録されていません。";
                        return (status);
                    default:
                        return (status);
                }

                // --- DEL 2009/12/16 ---------->>>>>
				// 入金情報/引当情報取得処理
                //status = GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        // 入金情報DetaSet締次更新フラグセット処理
                //        SetDepositDataSetClosedFlg();
                //        break;
                //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                //        break;
                //    default:
                //        return (status);
                //}
                // --- DEL 2009/12/16 ----------<<<<<

                if (getAllowanceDiv != true)
                {
                    return (status);
                }

                // --- DEL 2009/12/16 ---------->>>>>
				// 請求売上情報取得処理
                //status = GetClaimSalesInfo(searchSalesParameter, out message);
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        // 請求売上情報DetaSet締次更新フラグセット処理
                //        SetDmdSalesDataSetClosedFlg();
                //        break;
                //    default:
                //        return (status);
                //}
                // --- DEL 2009/12/16 ----------<<<<<
			}
			catch ( DepositException ex )
			{
				status = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return status;
		}

        /// <summary>
        /// 入金関連データ取得処理（入金伝票番号指定）
        /// </summary>
        /// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
        /// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ クラス</param>
        /// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
        /// <param name="getAllowanceDiv">引当/請求売上取得区分</param>
        /// <param name="depositCustomer">入金得意先情報クラス</param>
        /// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 指定されたパラメータの得意先情報/請求金額情報を取得し返します。
        ///	                : また、入金情報/請求売上情報を取得し、以下のデータセットにて返します。
        ///					:   ※ 入金情報     : Method : GetDsDepositInfo
        ///					:   ※ 請求売上情報 : Method : GetDsDmdSalesInfo</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int SearchDepositSlipNoMode(SearchCustomerParameter searchCustomerParameter, 
                                           SearchDepositParameter searchDepositParameter, 
                                           SearchSalesParameter searchSalesParameter, 
                                           bool getAllowanceDiv, 
                                           out DepositCustomer depositCustomer, 
                                           out DepositCustDmdPrc depositCustDmdPrc, 
                                           out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositCustomer = null;
            depositCustDmdPrc = null;

            try
            {
                int claimCode;
                int customerCode;

                // 入金得意先情報クラス初期化処理
                ClearDepositCustomer();

                // 入金得意先請求金額情報クラス初期化処理
                ClearDepositCustDmdPrc();

                // 入金情報DataSet初期化処理
                ClearDsDepositInfo();

                // 受注情報DataSet初期化処理
                ClearDmdSalesInfo();

                // 入金情報/引当情報取得処理
                status = GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        searchCustomerParameter.ClaimCode = claimCode;
                        searchCustomerParameter.CustomerCode = customerCode;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "指定された条件で、入金伝票は存在しませんでした。";
                        return (status);
                    default:
                        return (status);
                }

                // 得意先情報/請求金額情報取得処理
                status = GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "得意先マスタの請求拠点が全体初期表示設定マスタに登録されていません。";
                        return (status);
                    default:
                        return (status);
                }

                // 入金情報DetaSet締次更新フラグセット処理
                SetDepositDataSetClosedFlg();

                searchSalesParameter.ClaimCode = claimCode;
                searchSalesParameter.CustomerCode = customerCode;

                if (getAllowanceDiv != true)
                {
                    return (status);
                }

                // 請求売上情報取得処理
                status = GetClaimSalesInfo(searchSalesParameter, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // 請求売上情報DetaSet締次更新フラグセット処理
                        SetDmdSalesDataSetClosedFlg();
                        break;
                    default :
                        return (status);
                }
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            finally
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    // 入金得意先情報クラス初期化処理
                    ClearDepositCustomer();

                    // 入金得意先請求金額情報クラス初期化処理
                    ClearDepositCustDmdPrc();

                    // 入金情報DataSet初期化処理
                    ClearDsDepositInfo();

                    // 受注情報DataSet初期化処理
                    ClearDmdSalesInfo();
                }
            }
            return (status);
        }

        /// <summary>
        /// 入金関連データ取得処理（受注番号指定）
        /// </summary>
        /// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
        /// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ クラス</param>
        /// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
        /// <param name="depositCustomer">入金得意先情報クラス</param>
        /// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 指定されたパラメータの得意先情報/請求金額情報を取得し返します。
        ///	                : また、入金情報/請求売上情報を取得し、以下のデータセットにて返します。
        ///					:   ※ 入金得意先情報         : Method : GetDepositCustomer
        ///					:   ※ 入金得意先請求金額情報 : Method : GetDepositCustDmdPrc
        ///					:   ※ 入金情報     : Method : GetDsDepositInfo
        ///					:   ※ 請求売上情報 : Method : GetDsDmdSalesInfo</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int SearchAcceptAnOrderNoMode(SearchCustomerParameter searchCustomerParameter, 
                                             SearchDepositParameter searchDepositParameter, 
                                             SearchSalesParameter searchSalesParameter, 
                                             out DepositCustomer depositCustomer, 
                                             out DepositCustDmdPrc depositCustDmdPrc, 
                                             out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositCustDmdPrc = null;
            depositCustomer = null;

            try
            {
                int claimCode;
                int customerCode;

                // 入金得意先情報クラス初期化処理
                ClearDepositCustomer();

                // 入金得意先請求金額情報クラス初期化処理
                ClearDepositCustDmdPrc();

                // 入金情報DataSet初期化処理
                ClearDsDepositInfo();

                // 受注情報DataSet初期化処理
                ClearDmdSalesInfo();

                // 得意先情報/請求金額情報取得処理
                status = GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "得意先マスタの請求拠点が全体初期表示設定マスタに登録されていません。";
                        return (status);
                    default:
                        return (status);
                }

                // 請求売上情報取得処理
                status = GetClaimSalesInfo(searchSalesParameter, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "指定された条件で、売上伝票は存在しませんでした。";
                        return (status);
                    default:
                        return (status);
                }

                // 請求売上情報DetaSet締次更新フラグセット処理
                SetDmdSalesDataSetClosedFlg();

                // 入金情報/引当情報取得処理
                status = GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "指定された売上伝票に対する入金伝票は存在しませんでした。";
                        return (status);
                    default:
                        return (status);
                }

                // 入金情報DetaSet締次更新フラグセット処理
                SetDepositDataSetClosedFlg();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return (status);
        }

        /// <summary>
        /// 入金関連データ取得処理（入金情報のみ取得）
        /// </summary>
        /// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ クラス</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 指定されたパラメータの入金情報を取得し、以下のデータセットにて返します。
        ///					:   ※ 入金情報     : Method : GetDsDepositInfo</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2012/12/24 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        public int SearchDepositOnlyMode(SearchDepositParameter searchDepositParameter, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                int claimCode;
                int customerCode;

                // 入金情報DataSet初期化処理
                ClearDsDepositInfo();

                // 入金情報/引当情報取得処理
                status = GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "指定された条件で、入金伝票は存在しませんでした。";
                        return (status);
                    default:
                        return (status);
                }
                // ------- ADD 王君 2012/12/24 Redmine#33741 ------->>>>>
                if (status != 0)
                {
                    return 0;
                }
                // ------- ADD 王君 2012/12/24 Redmine#33741 -------<<<<<
                // 入金情報DetaSet締次更新フラグセット処理
                SetDepositDataSetClosedFlg();

                // 請求売上情報データセット再登録処理
                ResetDsDmdSalesInfo();

            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

        // ----- ADD 王君　2012/12/24　Redmine#33741 ----->>>>>
        /// <summary>
        /// 入金関連データ取得処理（入金情報のみ取得）
        /// </summary>
        /// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ クラス</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 指定されたパラメータの入金情報を取得し、以下のデータセットにて返します。
        ///					:   ※ 入金情報     : Method : GetDsDepositInfo</br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        public int SearchDepositGuidOnlyMode(SearchDepositParameter searchDepositParameter, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                int claimCode;
                int customerCode;

                // DataSet初期化
                this.ClearDsGuidDepositInfo();

                // 入金情報取得処理
                status = GetDepositGuidInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        this._dsDepositInfo.Tables[ctDepositGuidDataTable].DefaultView.Sort = "DepositSlipNo asc";
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "指定された条件で、入金伝票は存在しませんでした。";
                        return (status);
                    default:
                        return (status);
                }
                // ------- ADD 王君 2012/12/24 Redmine#33741 ------->>>>>
                if (status != 0)
                {
                    return 0;
                }
                // ------- ADD 王君 2012/12/24 Redmine#33741 -------<<<<<
                //if (searchDepositParameter.CustomerCode != 0)
                //{
                //    SetDepositGuidDataRemove();
                //}
                //else
                //{
                //    SetDepositGuidDataRemoveByMonth();
                //}
                // 入金情報DetaSet締次更新フラグセット処理
                SetDepositGuidDataSetClosedFlg();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }
        // ----- ADD 王君　2012/12/24　Redmine#33741 -----<<<<<

        /// <summary>
        /// 入金関連データ取得処理（請求売上情報のみ取得）
        /// </summary>
        /// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 指定されたパラメータの請求売上情報を取得し、以下のデータセットにて返します。
        ///					:   ※ 請求売上情報 : Method : GetDsDmdSalesInfo</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int SearchSalesOnlyMode(SearchSalesParameter searchSalesParameter, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // 受注情報DataSet初期化処理
                this.ClearDmdSalesInfo();

                // 請求売上情報取得処理
                status = GetClaimSalesInfo(searchSalesParameter, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "指定された条件で、売上伝票は存在しませんでした。";
                        return (status);
                    default:
                        return (status);
                }

                // 請求売上情報DetaSet締次更新フラグセット処理
                SetDmdSalesDataSetClosedFlg();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 請求金額情報取得処理
        /// </summary>
        /// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
        /// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 指定されたパラメータの請求金額情報を取得し返します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int ReadCustomDemandInfo(SearchCustomerParameter searchCustomerParameter, out DepositCustDmdPrc depositCustDmdPrc, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositCustDmdPrc = null;

            try
            {
                // 入金得意先請求金額情報クラス初期化処理
                ClearDepositCustDmdPrc();

                // 得意先情報/請求金額情報取得処理
                status = GetCustomDemandInfo2(searchCustomerParameter, out depositCustDmdPrc, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "指定された条件で、請求金額情報は存在しませんでした。";
                        return (status);
                    default:
                        return (status);
                }
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return (status);
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入金関連データ取得処理（得意先コード指定）
        /// </summary>
        /// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
        /// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ クラス</param>
        /// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
        /// <param name="getAllowanceDiv">引当/請求売上取得区分</param>
        /// <param name="depositCustomer">入金得意先情報クラス</param>
        /// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 指定されたパラメータの得意先情報/請求金額情報を取得し返します。
        ///	                : また、入金情報/請求売上情報を取得し、以下のデータセットにて返します。
        ///					:   ※ 入金得意先情報         : Method : GetDepositCustomer
        ///					:   ※ 入金得意先請求金額情報 : Method : GetDepositCustDmdPrc
        ///					:   ※ 入金情報     : Method : GetDsDepositInfo
        ///					:   ※ 請求売上情報 : Method : GetDsDmdSalesInfo</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        public int SearchCustomerMode(SearchCustomerParameter searchCustomerParameter, SearchDepositParameter searchDepositParameter, SearchSalesParameter searchSalesParameter, bool getAllowanceDiv, out DepositCustomer depositCustomer, out DepositCustDmdPrc depositCustDmdPrc, out string message)
        {
            int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositCustDmdPrc = null;
            depositCustomer = null;

            try
            {
                int customerCode;
                int claimCode;

                // 入金得意先情報クラス初期化処理
                this.ClearDepositCustomer();

                // 入金得意先請求金額情報クラス初期化処理
                this.ClearDepositCustDmdPrc();

                // 入金情報DataSet初期化処理
                this.ClearDsDepositInfo();

                // 受注情報DataSet初期化処理
                this.ClearDmdSalesInfo();

                // 得意先情報/請求金額情報取得処理
                st = this.GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    message = "指定された条件で、得意先は存在しませんでした。";
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                // 入金情報/引当情報取得処理
                if (this.GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode) == 0)
                {
                    // 入金情報DetaSet締次更新フラグセット処理
                    this.SetDepositDataSetClosedFlg();
                }

                // 請求売上情報取得処理
                if (getAllowanceDiv == true)
                {
                    // ↓ 20070122 18322 c MA.NS用に変更
                    //if (this.GetDmdSalesInfo(searchSalesParameter) == 0)

                    if (this.GetClaimSalesInfo(searchSalesParameter) == 0)
                    // ↑ 20070122 18322 c
                    {
                        // 請求売上情報DetaSet締次更新フラグセット処理
                        this.SetDmdSalesDataSetClosedFlg();
                    }
                }
            }
            catch (DepositException ex)
            {
                st = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return st;
        }
        
        /// <summary>
		/// 入金関連データ取得処理（入金伝票番号指定）
		/// </summary>
		/// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
		/// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ クラス</param>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
		/// <param name="getAllowanceDiv">引当/請求売上取得区分</param>
		/// <param name="depositCustomer">入金得意先情報クラス</param>
		/// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 指定されたパラメータの得意先情報/請求金額情報を取得し返します。
		///	                : また、入金情報/請求売上情報を取得し、以下のデータセットにて返します。
		///					:   ※ 入金情報     : Method : GetDsDepositInfo
		///					:   ※ 請求売上情報 : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchDepositSlipNoMode(SearchCustomerParameter searchCustomerParameter, SearchDepositParameter searchDepositParameter, SearchSalesParameter searchSalesParameter, bool getAllowanceDiv, out DepositCustomer depositCustomer, out DepositCustDmdPrc depositCustDmdPrc, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositCustomer = null;
			depositCustDmdPrc = null;

			try
			{
                int claimCode;
				int customerCode;

				// 入金得意先情報クラス初期化処理
				this.ClearDepositCustomer();

				// 入金得意先請求金額情報クラス初期化処理
				this.ClearDepositCustDmdPrc();

				// 入金情報DataSet初期化処理
				this.ClearDsDepositInfo();

				// 受注情報DataSet初期化処理
				this.ClearDmdSalesInfo();

				// 入金情報/引当情報取得処理
                st = this.GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    message = "指定された条件で、入金伝票は存在しませんでした。";
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                searchCustomerParameter.ClaimCode = claimCode;
                searchCustomerParameter.CustomerCode = customerCode;
                
				// 得意先情報/請求金額情報取得処理
                st = this.GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    message = "指定された入金伝票の得意先が存在しませんでした。";
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

				// 入金情報DetaSet締次更新フラグセット処理
				this.SetDepositDataSetClosedFlg();

                searchSalesParameter.ClaimCode = claimCode;
                searchSalesParameter.CustomerCode = customerCode;

				// 請求売上情報取得処理
				if (getAllowanceDiv == true)
				{
                    // ↓ 20070122 18322 c MA.NS用に変更
					//if (this.GetDmdSalesInfo(searchSalesParameter) == 0)

					if (this.GetClaimSalesInfo(searchSalesParameter) == 0)
                    // ↑ 20070122 18322 c
					{
						// 請求売上情報DetaSet締次更新フラグセット処理
						this.SetDmdSalesDataSetClosedFlg();
					}
				}
			}
			catch (DepositException ex)
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch (Exception ex)
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}
// >>> Ins Start 2006.11.04 amami >>> //
			finally
			{
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					// 入金得意先情報クラス初期化処理
					this.ClearDepositCustomer();

					// 入金得意先請求金額情報クラス初期化処理
					this.ClearDepositCustDmdPrc();

					// 入金情報DataSet初期化処理
					this.ClearDsDepositInfo();

					// 受注情報DataSet初期化処理
					this.ClearDmdSalesInfo();
				}
			}
// <<< Ins End 2006.11.04 amami <<< //
			return st;
		}

        /// <summary>
		/// 入金関連データ取得処理（受注番号指定）
		/// </summary>
		/// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
		/// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ クラス</param>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
		/// <param name="depositCustomer">入金得意先情報クラス</param>
		/// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 指定されたパラメータの得意先情報/請求金額情報を取得し返します。
		///	                : また、入金情報/請求売上情報を取得し、以下のデータセットにて返します。
		///					:   ※ 入金得意先情報         : Method : GetDepositCustomer
		///					:   ※ 入金得意先請求金額情報 : Method : GetDepositCustDmdPrc
		///					:   ※ 入金情報     : Method : GetDsDepositInfo
		///					:   ※ 請求売上情報 : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchAcceptAnOrderNoMode(SearchCustomerParameter searchCustomerParameter, SearchDepositParameter searchDepositParameter, SearchSalesParameter searchSalesParameter, out DepositCustomer depositCustomer, out DepositCustDmdPrc depositCustDmdPrc, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositCustDmdPrc = null;
			depositCustomer = null;

			try
			{
                int claimCode;
				int customerCode;
			
				// 入金得意先情報クラス初期化処理
				this.ClearDepositCustomer();

				// 入金得意先請求金額情報クラス初期化処理
				this.ClearDepositCustDmdPrc();

				// 入金情報DataSet初期化処理
				this.ClearDsDepositInfo();

				// 受注情報DataSet初期化処理
				this.ClearDmdSalesInfo();

				// 得意先情報/請求金額情報取得処理
                st = this.GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    // ↓ 20070129 18322 c MA.NS用に変更
                    //message = "指定された受注伝票の得意先が存在しませんでした。";

                    message = "指定された売上伝票の得意先が存在しませんでした。";
                    // ↑ 20070129 18322 c
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

				// 請求売上情報取得処理
                // ↓ 20070122 18322 c MA.NS用に変更
				//st = this.GetDmdSalesInfo(searchSalesParameter);

                st = this.GetClaimSalesInfo(searchSalesParameter);
                // ↑ 20070122 18322 c
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
                    // ↓ 20070129 18322 c MA.NS用に変更
					//message = "指定された条件で、受注伝票は存在しませんでした。";

					message = "指定された条件で、売上伝票は存在しませんでした。";
                    // ↑ 20070129 18322 c
					return 14;
				}

				// 請求売上情報DetaSet締次更新フラグセット処理
				this.SetDmdSalesDataSetClosedFlg();

				// 入金情報/引当情報取得処理
                st = this.GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode);
                if (st == 9)
                {
                    // ↓ 20070129 18322 c MA.NS用に変更
                    //message = "指定された受注伝票に対する入金伝票は存在しませんでした。";

                    message = "指定された売上伝票に対する入金伝票は存在しませんでした。";
                    // ↑ 20070129 18322 c
                    return 24;
                }

				// 入金情報DetaSet締次更新フラグセット処理
				this.SetDepositDataSetClosedFlg();
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}

		/// <summary>
		/// 入金関連データ取得処理（入金情報のみ取得）
		/// </summary>
		/// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ クラス</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 指定されたパラメータの入金情報を取得し、以下のデータセットにて返します。
		///					:   ※ 入金情報     : Method : GetDsDepositInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchDepositOnlyMode(SearchDepositParameter searchDepositParameter, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
                int claimCode;
				int customerCode;
			
				// 入金情報DataSet初期化処理
				this.ClearDsDepositInfo();

				// 入金情報/引当情報取得処理
                st = this.GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    message = "指定された条件で、入金伝票は存在しませんでした。";
                    return st;
                }

				// 入金情報DetaSet締次更新フラグセット処理
				this.SetDepositDataSetClosedFlg();

				// 請求売上情報データセット再登録処理
				this.ResetDsDmdSalesInfo();

			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}

		/// <summary>
		/// 入金関連データ取得処理（請求売上情報のみ取得）
		/// </summary>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 指定されたパラメータの請求売上情報を取得し、以下のデータセットにて返します。
		///					:   ※ 請求売上情報 : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchSalesOnlyMode(SearchSalesParameter searchSalesParameter, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
				// 受注情報DataSet初期化処理
				this.ClearDmdSalesInfo();

				// 請求売上情報取得処理
                // ↓ 20070122 18322 c MA.NS用に変更
                #region SF 請求売上情報取得処理(全てコメントアウト)
                //st = this.GetDmdSalesInfo(searchSalesParameter);
				//if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				//{
				//	message = "指定された条件で、受注伝票は存在しませんでした。";
				//	return st;
				//}
                #endregion

				st = this.GetClaimSalesInfo(searchSalesParameter);
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					message = "指定された条件で、売上伝票は存在しませんでした。";
					return st;
				}
                // ↑ 20070122 18322 c

				// 請求売上情報DetaSet締次更新フラグセット処理
				this.SetDmdSalesDataSetClosedFlg();
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}
        
        /// <summary>
		/// 請求金額情報取得処理
		/// </summary>
		/// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
		/// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 指定されたパラメータの請求金額情報を取得し返します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int ReadCustomDemandInfo(SearchCustomerParameter searchCustomerParameter, out DepositCustDmdPrc depositCustDmdPrc, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositCustDmdPrc = null;

			try
			{
				// 入金得意先請求金額情報クラス初期化処理
				this.ClearDepositCustDmdPrc();

				// 得意先情報/請求金額情報取得処理
				st = this.GetCustomDemandInfo2(searchCustomerParameter, out depositCustDmdPrc);
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					message = "指定された条件で、請求金額情報は存在しませんでした。";
					return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}

			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
        /// 入金情報新規行追加処理
        /// </summary>
        /// <returns>入金情報新規DataRow</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金情報のDataRowを新規作成し返します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2012/09/21 田建委</br>
        /// <br>管理番号    : 2012/10/17配信分</br>
        /// <br>              Redmine#32415 発行者の追加対応</br>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// </remarks>
        public DataRow DepositNewRow()
        {
            // 入金情報(画面用)の行を追加する
            DataRow drNew = this._dsDepositInfo.Tables[ctDepositDataTable].NewRow();

            drNew[ctDepositDebitNoteCd] = 0;                                                        // 入金赤黒区分
            drNew[ctDepositDebitNoteNm] = "";                                                       // 入金赤黒名称
            drNew[ctDepositSlipNo] = 0;                                                             // 入金伝票番号
            drNew[ctDepositAcptAnOdrStatus] = 30;                                                    // 受注ステータス
            drNew[ctSalesSlipNum] = "";                                                             // 売上伝票番号
            drNew[ctDebitNoteLinkDepoNo] = 0;                                                       // 赤黒入金連結番号
            drNew[ctDepositDateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");             // 入金日付(表示用)
            drNew[ctDepositDate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());          // 入金日付
            drNew[ctDepositAddUpADateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");       // 計上日付(表示用)
            drNew[ctDepositAddUpADate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());    // 計上日付
            drNew[ctAutoDepositCd] = 0;                                                             // 自動入金区分
            drNew[ctDepositNm] = "通常入金";                                                        // 預り金区分名称
            drNew[ctDepositKindName] = "";                                                          // 入金金種
            drNew[ctDeposit] = 0;                                                                   // 共通 入金額
            drNew[ctFeeDeposit] = 0;                                                                // 共通 手数料
            drNew[ctDiscountDeposit] = 0;                                                           // 共通 値引
            drNew[ctAllowDiv] = "";                                                                 // 引当    // ADD 2010/12/20
            drNew[ctDepositTotal] = 0;                                                              // 共通 入金計
            drNew[ctDepositAllowance_Deposit] = 0;                                                  // 入金引当額 共通
            drNew[ctDepositAlwcBlnce_Deposit] = 0;                                                  // 入金引当残 共通
            drNew[ctDraftDrawingDate] = 0;                                                          // 手形振出日
            drNew[ctBankCode] = 0;                                                                  // 銀行コード
            drNew[ctDraftNo] = "";                                                                  // 手形番号
            drNew[ctDraftKind] = 0;                                                                 // 手形種類コード
            drNew[ctDraftDivide] = 0;                                                               // 手形区分コード
            drNew[ctOutline] = "";                                                                  // 摘要
            drNew[ctDepositClosedFlg] = "";                                                         // 締フラグ
            drNew[ctDepositRowNo1] = 0;                                                             // 入金行番号1
            drNew[ctMoneyKindCode1] = 0;                                                            // 金種コード1
            drNew[ctMoneyKindName1] = "";                                                           // 金種名称1
            drNew[ctMoneyKindDiv1] = 0;                                                             // 金種区分1
            drNew[ctDeposit1] = 0;                                                                  // 入金金額1
            drNew[ctValidityTerm1] = DateTime.MinValue;                                             // 有効期限1
            drNew[ctDepositRowNo2] = 0;                                                             // 入金行番号2
            drNew[ctMoneyKindCode2] = 0;                                                            // 金種コード2
            drNew[ctMoneyKindName2] = "";                                                           // 金種名称2
            drNew[ctMoneyKindDiv2] = 0;                                                             // 金種区分2
            drNew[ctDeposit2] = 0;                                                                  // 入金金額2
            drNew[ctValidityTerm2] = DateTime.MinValue;                                             // 有効期限2
            drNew[ctDepositRowNo3] = 0;                                                             // 入金行番号3
            drNew[ctMoneyKindCode3] = 0;                                                            // 金種コード3
            drNew[ctMoneyKindName3] = "";                                                           // 金種名称3
            drNew[ctMoneyKindDiv3] = 0;                                                             // 金種区分3
            drNew[ctDeposit3] = 0;                                                                  // 入金金額3
            drNew[ctValidityTerm3] = DateTime.MinValue;                                             // 有効期限3
            drNew[ctDepositRowNo4] = 0;                                                             // 入金行番号4
            drNew[ctMoneyKindCode4] = 0;                                                            // 金種コード4
            drNew[ctMoneyKindName4] = "";                                                           // 金種名称4
            drNew[ctMoneyKindDiv4] = 0;                                                             // 金種区分4
            drNew[ctDeposit4] = 0;                                                                  // 入金金額4
            drNew[ctValidityTerm4] = DateTime.MinValue;                                             // 有効期限4
            drNew[ctDepositRowNo5] = 0;                                                             // 入金行番号5
            drNew[ctMoneyKindCode5] = 0;                                                            // 金種コード5
            drNew[ctMoneyKindName5] = "";                                                           // 金種名称5
            drNew[ctMoneyKindDiv5] = 0;                                                             // 金種区分5
            drNew[ctDeposit5] = 0;                                                                  // 入金金額5
            drNew[ctValidityTerm5] = DateTime.MinValue;                                             // 有効期限5
            drNew[ctDepositRowNo6] = 0;                                                             // 入金行番号6
            drNew[ctMoneyKindCode6] = 0;                                                            // 金種コード6
            drNew[ctMoneyKindName6] = "";                                                           // 金種名称6
            drNew[ctMoneyKindDiv6] = 0;                                                             // 金種区分6
            drNew[ctDeposit6] = 0;                                                                  // 入金金額6
            drNew[ctValidityTerm6] = DateTime.MinValue;                                             // 有効期限6
            drNew[ctDepositRowNo7] = 0;                                                             // 入金行番号7
            drNew[ctMoneyKindCode7] = 0;                                                            // 金種コード7
            drNew[ctMoneyKindName7] = "";                                                           // 金種名称7
            drNew[ctMoneyKindDiv7] = 0;                                                             // 金種区分7
            drNew[ctDeposit7] = 0;                                                                  // 入金金額7
            drNew[ctValidityTerm7] = DateTime.MinValue;                                             // 有効期限7
            drNew[ctDepositRowNo8] = 0;                                                             // 入金行番号8
            drNew[ctMoneyKindCode8] = 0;                                                            // 金種コード8
            drNew[ctMoneyKindName8] = "";                                                           // 金種名称8
            drNew[ctMoneyKindDiv8] = 0;                                                             // 金種区分8
            drNew[ctDeposit8] = 0;                                                                  // 入金金額8
            drNew[ctValidityTerm8] = DateTime.MinValue;                                             // 有効期限8
            drNew[ctDepositRowNo9] = 0;                                                             // 入金行番号9
            drNew[ctMoneyKindCode9] = 0;                                                            // 金種コード9
            drNew[ctMoneyKindName9] = "";                                                           // 金種名称9
            drNew[ctMoneyKindDiv9] = 0;                                                             // 金種区分9
            drNew[ctDeposit9] = 0;                                                                  // 入金金額9
            drNew[ctValidityTerm9] = DateTime.MinValue;                                             // 有効期限9
            drNew[ctDepositRowNo10] = 0;                                                             // 入金行番号10
            drNew[ctMoneyKindCode10] = 0;                                                            // 金種コード10
            drNew[ctMoneyKindName10] = "";                                                           // 金種名称10
            drNew[ctMoneyKindDiv10] = 0;                                                             // 金種区分10
            drNew[ctDeposit10] = 0;                                                                  // 入金金額10
            drNew[ctValidityTerm10] = DateTime.MinValue;                                             // 有効期限10

            // ADD 2010/03/25 MANTIS[15196]：入金一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
            drNew[ctDepositInputAgentNm] = "";                                                      // 入金入力者名称
            // ADD 2010/03/25 MANTIS[15196]：入金一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<

            //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
            drNew[ctDepositInputEmpCd] = LoginInfoAcquisition.Employee.EmployeeCode.Trim();                // 発行者コード
            drNew[ctDepositInputEmpNm] = LoginInfoAcquisition.Employee.Name.Trim();                        // 発行者名
            //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<
            // -----ADD 2012/12/24 王君 Redmine#33741 ---------->>>>>
            drNew[ctCustomerCode] = 0;          // 得意先コード
            drNew[ctCustomerName] = "";　　　　 // 得意先名称
            // -----ADD 2012/12/24 王君 Redmine#33741 ----------<<<<<
            
            drNew[ctDepositDataRow] = drNew;                                                        // 自身のDataRow

            // 選択行を取得
            return drNew;
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金情報新規行追加処理
		/// </summary>
		/// <returns>入金情報新規DataRow</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金情報のDataRowを新規作成し返します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataRow DepositNewRow()
		{
			// 入金情報(画面用)の行を追加する
			DataRow drNew = this._dsDepositInfo.Tables[ctDepositDataTable].NewRow();

			// 入金赤黒区分
			drNew[ctDepositDebitNoteCd] = 0;

			// 入金赤黒名称
			drNew[ctDepositDebitNoteNm] = "";

			// 入金伝票番号
			drNew[ctDepositSlipNo] = 0;

            // ↓ 20070525 18322 a
			// 受注番号
			// drNew[ctAcceptAnOrderNo] = 0;       // 2007.10.05 del
            // ↑ 20070525 18322 a

            // 受注ステータス
            drNew[ctDepositAcptAnOdrStatus] = 0;   // 2007.10.05 add

            // 売上伝票番号
            drNew[ctSalesSlipNum] = "";            // 2007.10.05 add

			// 赤黒入金連結番号
			drNew[ctDebitNoteLinkDepoNo] = 0;

            // ↓ 20070418 18322 c MA.NS対応
			//// 入金日付(表示用)
			//drNew[ctDepositDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd",TDateTime.GetSFDateNow());

			// 入金日付(表示用)
			drNew[ctDepositDateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");
            // ↑ 20070418 18322 c

			// 入金日付
			drNew[ctDepositDate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());

            // 計上日付(表示用)
            drNew[ctDepositAddUpADateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");      // 2007.10.05 add

            // 計上日付
            drNew[ctDepositAddUpADate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());   // 2007.10.05 add

   			// 自動入金区分
			drNew[ctAutoDepositCd] = 0;

			// 預り金区分名称
            //drNew[ctDepositCd] = 0;// DEL 2008/06/26
			drNew[ctDepositNm] = "通常入金";
            
            // 入金金種
			if ((depositRelDataAcs.InitSelMoneyKindCd != 0) && (depositRelDataAcs.HtMoneyKindDiv[depositRelDataAcs.InitSelMoneyKindCd] != null))
			{
                drNew[ctDepositKindDivCd] = (int)depositRelDataAcs.HtMoneyKindDiv[depositRelDataAcs.InitSelMoneyKindCd];
                drNew[ctDepositKindCode]  = depositRelDataAcs.InitSelMoneyKindCd;
                drNew[ctDepositKindName] = depositRelDataAcs.SlMoneyKindCode[depositRelDataAcs.InitSelMoneyKindCd];
                drNew[ctDepositKindName] = depositRelDataAcs.DicMoneyKindCode[depositRelDataAcs.InitSelMoneyKindCd];
			}
			else
			{
				drNew[ctDepositKindDivCd] = 0;
				drNew[ctDepositKindCode]  = 0;
                
                drNew[ctDepositKindName]  = "";
			}

            // ↓ 20070118 18322 d MA.NS用に変更
            #region SF 受注・諸費用（全てコメントアウト）
            //// 受注 入金額
			//drNew[ctAcpOdrDeposit] = 0;
            //
			//// 受注 手数料
			//drNew[ctAcpOdrChargeDeposit] = 0;
            //
			//// 受注 値引
			//drNew[ctAcpOdrDisDeposit] = 0;
            //
			//// 受注 入金計
			//drNew[ctAcpOdrDepositTotal] = 0;
            //
			//// 諸費用 入金額
			//drNew[ctVariousCostDeposit] = 0;
            //
			//// 諸費用 手数料
			//drNew[ctVarCostChargeDeposit] = 0;
            //
			//// 諸費用 値引
			//drNew[ctVarCostDisDeposit] = 0;
            //
			//// 諸費用 入金計
            //drNew[ctVariousCostDepositTotal] = 0;
            #endregion
            // ↑ 20070118 18322 d

			// 共通 入金額
			drNew[ctDeposit] = 0;

			// 共通 手数料
			drNew[ctFeeDeposit] = 0;

			// 共通 値引
			drNew[ctDiscountDeposit] = 0;

            // ↓ 20070118 18322 a
			// 共通 インセンティブ
			// drNew[ctRebateDeposit] = 0;   // 2007.10.05 hikita del
            // ↑ 20070118 18322 a

			// 共通 入金計
			drNew[ctDepositTotal] = 0;

            // ↓ 20070118 18322 d MA.NS用に変更
            #region SF 受注・諸費用（全てコメントアウト）
            //// 入金引当額 受注
			//drNew[ctAcpOdrDepositAlwc_Deposit] = 0;
            //
			//// 入金引当残 受注
			//drNew[ctAcpOdrDepoAlwcBlnce_Deposit] = 0;
            //
			//// 入金引当額 諸費用
			//drNew[ctVarCostDepoAlwc_Deposit] = 0;
            //
			//// 入金引当残 諸費用
            //drNew[ctVarCostDepoAlwcBlnce_Deposit] = 0;
            #endregion
            // ↑ 20070118 18322 d

			// 入金引当額 共通
			drNew[ctDepositAllowance_Deposit] = 0;

			// 入金引当残 共通
			drNew[ctDepositAlwcBlnce_Deposit] = 0;

            // 2007.10.05 hikita del start ------------------------------->>
			// クレジット/ローン区分
			// drNew[ctCreditOrLoanCd] = 0;

			// クレジット会社コード
			// drNew[ctCreditCompanyCode] = "";
            // 2007.10.05 hikita del end ---------------------------------<<

			// 手形振出日
			drNew[ctDraftDrawingDate] = 0;

			// 手形支払期日
			drNew[ctDraftPayTimeLimit] = 0;
            
            // 2007.10.05 hikita add start ------------------------------->>
            // 銀行コード
            drNew[ctBankCode] = 0;

            // 手形番号
            drNew[ctDraftNo] = "";

            // 手形種類コード
            drNew[ctDraftKind] = 0;

            // 手形区分コード
            drNew[ctDraftDivide] = 0;
            // 2007.10.05 hikita add end ---------------------------------<<

			// 摘要
			drNew[ctOutline] = "";

			// 締フラグ
			drNew[ctDepositClosedFlg] = "";

			// 自身のDataRow
			drNew[ctDepositDataRow] = drNew;

			// 選択行を取得
			return drNew;
		}

           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        // ↓ 20070202 18322 c MA.NS用に変更
        #region SF 引当情報新規行追加処理（全てコメントアウト）
        ///// <summary>
		///// 引当情報新規行追加処理
		///// </summary>
		///// <param name="depositSlipNo">入金番号</param>
		///// <param name="acceptAnOrderNo">受注番号</param>
		///// <param name="depositDate">入金日</param>
		///// <returns>入金情報新規DataRow</returns>
		///// <remarks>
		///// <br>Note　　　  : 引当情報のDataRowを新規作成し返します。</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
        ///// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        ///// <br>                MA.NS用に変更</br>
        ///// <br></br>
		///// </remarks>
        //public System.Data.DataRow AllowanceNewRow(int depositSlipNo, int acceptAnOrderNo, int depositDate)
		//{
		//	// 引当情報DataRowが無い時は新規として追加する
		//	DataRow drNew = this._dsDepositInfo.Tables[ctAllowanceDataTable].NewRow();
		//
		//	// 入金伝票番号
		//	drNew[ctDepositSlipNo_Alw] = depositSlipNo;
		//
		//	// 受注伝票番号
		//	drNew[ctAcceptAnOrderNo_Alw] = acceptAnOrderNo;
		//
		//	// 入金引当額 受注
		//	drNew[ctAcpOdrDepositAlwc] = 0;
		//
		//	// 入金引当額 諸費用
		//	drNew[ctVarCostDepoAlwc] = 0;
		//	
		//	// 入金引当額 共通
		//	drNew[ctDepositAllowance] = 0;
		//
		//	// 引当日(表示用)
		//	drNew[ctReconcileDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd",TDateTime.GetSFDateNow());
		//
		//	// 引当日
		//	drNew[ctReconcileDate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());
		//
		//	// 引当計上日付
		//	drNew[ctReconcileAddUpDate] = depositDate; 
		//
		//	// 選択行を取得
		//	return drNew;
		//}
        #endregion

        /// <summary>
		/// 引当情報新規行追加処理
		/// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="depositSlipNo">入金番号</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		/// <param name="depositDate">入金日</param>
		/// <returns>入金情報新規DataRow</returns>
		/// <remarks>
		/// <br>Note　　　  : 引当情報のDataRowを新規作成し返します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
        /// <br>Update Note : 2007.02.02 18322 T.Kimura</br>
        /// <br>                MA.NS用に変更</br>
        /// <br></br>
		/// </remarks>
        // public System.Data.DataRow AllowanceNewRow(int depositSlipNo, int acceptAnOrderNo, string salesSlipNum, int depositDate)  // 2007.10.05 del
        public DataRow AllowanceNewRow(int acptAnOdrStatus, int depositSlipNo, string salesSlipNum, int depositDate)     // 2007.10.05 add
		{
			// 引当情報DataRowが無い時は新規として追加する
			DataRow drNew = this._dsDepositInfo.Tables[ctAllowanceDataTable].NewRow();

			// 入金伝票番号
			drNew[ctDepositSlipNo_Alw] = depositSlipNo;

			// 受注伝票番号
			//drNew[ctAcceptAnOrderNo_Alw] = acceptAnOrderNo;  // 2007.10.05 del

            // 受注ステータス
            drNew[ctAcptAnOdrStatus_Alw] = acptAnOdrStatus;    // 2007.10.05 add
            
			// 売上伝票番号
			drNew[ctSalesSlipNum] = salesSlipNum;
			
			// 入金引当額 共通
			drNew[ctDepositAllowance] = 0;

            // ↓ 20070418 18322 c MA.NS対応
			//// 引当日(表示用)
			//drNew[ctReconcileDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd",TDateTime.GetSFDateNow());

			// 引当日(表示用)
			drNew[ctReconcileDateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");
            // ↑ 20070418 18322 c

			// 引当日
			drNew[ctReconcileDate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());

			// 引当計上日付
			drNew[ctReconcileAddUpDate] = depositDate; 

			// 選択行を取得
			return drNew;
		}
        // ↑ 20070202 18322 c
		
		/// <summary>
		/// 引当情報の請求売上情報展開処理
		/// </summary>
		/// <param name="dr">選択引当情報DataRow</param>
		/// <remarks>
		/// <br>Note       : 引当情報を請求売上情報の入金引当額欄に展開します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public void ExpandAllowanceRelationData(ArrayList dr)
		{
			// 請求売上情報DetaSet入金引当情報クリア処理
			this.DmdSalesDepositAllowanceClear();

			// 引当情報が無い時は処理を抜ける
			if (dr.Count == 0) return;

			// 引当情報DataRowの取得
			foreach (DataRow drChild in dr)
			{
				// 請求売上情報DataRowの取得
				foreach (DataRow drSales in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
				{
					// 同一受注番号の時、引当金額を展開する
					//if (Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw]) == Convert.ToInt32(drSales[ctAcceptAnOrderNo]))  // 2007.10.05 del
                    // 同一売上番号の時、引当金額を展開する
                    if (Convert.ToInt32(drChild[ctSalesSlipNum_Alw]) == Convert.ToInt32(drSales[ctSalesSlipNum]))          // 2007.10.05 add
					{
						// 引
						drSales[ctAlwCheck] = true;

                        // ↓ 20070118 18322 d MA.NS用に変更
						//// 引当額 受注 (入金引当マスタ)
						//drSales[ctAcpOdrDepositAlwc_Alw] = Convert.ToInt64(drChild[ctAcpOdrDepositAlwc]);
                        //
						//// 引当額 諸費用 (入金引当マスタ)
						//drSales[ctVarCostDepoAlwc_Alw] = Convert.ToInt64(drChild[ctVarCostDepoAlwc]);
                        // ↑ 20070118 18322 d

						// 引当額 共通 (入金引当マスタ)
						drSales[ctDepositAllowance_Alw] = Convert.ToInt64(drChild[ctDepositAllowance]);
					}
				}
			}
		}

		/// <summary>
		/// 請求売上データのステータスを取得します。
		/// </summary>
        /// <param name="salesSlipNum">売上番号</param>
		/// <param name="creditSales">掛売フラグ（true:掛売、false:掛売以外）</param>
		/// <remarks>
		/// <br>Note       : 請求売上データのステータスを取得します。</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 20070525</br>
		/// </remarks>
		// public void GetDmdSalesStatus(int acceptAnOrderNo, out bool posInput, out bool creditSales)   // 2007.10.05 del
        public void GetDmdSalesStatus(string salesSlipNum, out bool creditSales)                         // 2007.10.05 add
		{
			// posInput = false;    // 2007.10.05 del
			creditSales = false;
			
			// 請求売上情報DataRowの取得
			foreach (DataRow drSales in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
                // 2007.10.05 del start --------------------------------------->>
                //if (acceptAnOrderNo != Convert.ToInt32(drSales[ctAcceptAnOrderNo]))
                //{
                //    // 同一受注番号でなければ読み飛ばし
                //    continue;
                //}
			    
                //// POS入力かチェック
                //if (Convert.ToInt32(drSales[ctPosReceiptNo]) > 0)
                //{
                //    // POSレシート番号が入っている場合はPOS入力
                //    posInput = true;
                //}
                // 2007.10.05 del end -----------------------------------------<<
			    
                // 2007.10.05 add start --------------------------------------->>
                if (salesSlipNum != Convert.ToString(drSales[ctSalesSlipNum]))
                {
                    // 同一売上番号でなければ読み飛ばし
                    continue;
                }
                // 2007.10.05 add end -----------------------------------------<<

			    // 掛売かチェック
			    if (Convert.ToInt32(drSales[ctAccRecDivCd]) == 1)
			    {
			        // 掛売区分が1:掛売
			        creditSales = true;
			    }
			    
			    break;
			}
		}

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 入金金額 受注 変更処理（全てコメントアウト）
        ///// <summary>
		///// 入金金額 受注 変更処理
		///// </summary>
		///// <param name="acpOdrDeposit">受注 入金額</param>
		///// <param name="acpOdrChargeDeposit">受注 手数料</param>
		///// <param name="acpOdrDisDeposit">受注 値引</param>
		///// <param name="drDeposit">入金情報DataRow</param>
		///// <returns>入金合計 受注</returns>
		///// <remarks>
		///// <br>Note       : 受注 入金額 の変更を各内容に反映します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ChangeAcpOdrDepositSection(Int64 acpOdrDeposit, Int64 acpOdrChargeDeposit, Int64 acpOdrDisDeposit, ref System.Data.DataRow drDeposit)
		//{
		//	// 受注 入金額
		//	drDeposit[ctAcpOdrDeposit] = acpOdrDeposit;
        //
		//	// 受注 手数料
		//	drDeposit[ctAcpOdrChargeDeposit] = acpOdrChargeDeposit;
        //
		//	// 受注 値引
		//	drDeposit[ctAcpOdrDisDeposit] = acpOdrDisDeposit;
        //
		//	Int64 total = acpOdrDeposit + acpOdrChargeDeposit + acpOdrDisDeposit;
        //
		//	// 入金合計 受注
		//	drDeposit[ctAcpOdrDepositTotal] = total;
        //
		//	// 入金引当残 受注 (入金合計 受注 - 入金引当額 受注)
		//	drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit] = total - Convert.ToInt64(drDeposit[ctAcpOdrDepositAlwc_Deposit]);
        //
		//	return total;
        //}
        #endregion
        // ↑ 20070118 18322 d

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 入金金額 諸費用 変更処理（全てコメントアウト）
        ///// <summary>
		///// 入金金額 諸費用 変更処理
		///// </summary>
		///// <param name="variousCostDeposit">諸費用 入金額</param>
		///// <param name="varCostChargeDeposit">諸費用 手数料</param>
		///// <param name="varCostDisDeposit">諸費用 値引</param>
		///// <param name="drDeposit">入金情報DataRow</param>
		///// <returns>入金合計 諸費用</returns>
		///// <remarks>
		///// <br>Note       : 諸費用 入金額 の変更を各内容に反映します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ChangeCostDepositSection(Int64 variousCostDeposit, Int64 varCostChargeDeposit, Int64 varCostDisDeposit, ref System.Data.DataRow drDeposit)
		//{
		//	// 諸費用 入金額
		//	drDeposit[ctVariousCostDeposit] = variousCostDeposit;
        //
		//	// 諸費用 手数料
		//	drDeposit[ctVarCostChargeDeposit] = varCostChargeDeposit;
        //
		//	// 諸費用 値引
		//	drDeposit[ctVarCostDisDeposit] = varCostDisDeposit;
        //
		//	Int64 total = variousCostDeposit + varCostChargeDeposit + varCostDisDeposit;
        //
		//	// 入金合計 諸費用
		//	drDeposit[ctVariousCostDepositTotal] = total;
        //
		//	// 入金引当残 諸費用 (入金合計 諸費用 - 入金引当額 諸費用)
		//	drDeposit[ctVarCostDepoAlwcBlnce_Deposit] = total - Convert.ToInt64(drDeposit[ctVarCostDepoAlwc_Deposit]);
        //
		//	return total;
        //}
        #endregion
        // ↑ 20070118 18322 d

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        // 2007.10.05 hikita upd start DC.NS用に元のメソッドに復活(MA.NS用は使用しない)
        // ↓ 20070118 18322 c MA.NS用に作り直し
        #region SF 入金金額 共通 変更処理（全てコメントアウト）
        /// <summary>
		/// 入金金額 共通 変更処理
		/// </summary>
		/// <param name="deposit">共通 入金額</param>
		/// <param name="feeDeposit">共通 手数料</param>
		/// <param name="discountDeposit">共通 値引</param>
		/// <param name="drDeposit">入金情報DataRow</param>
		/// <returns>入金合計 共通</returns>
		/// <remarks>
		/// <br>Note       : 共通 入金額 の変更を各内容に反映します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 ChangeDepositSection(Int64 deposit, Int64 feeDeposit, Int64 discountDeposit, ref DataRow drDeposit)
		{
			// 共通 入金額
			drDeposit[ctDeposit] = deposit;
        
			// 共通 手数料
			drDeposit[ctFeeDeposit] = feeDeposit;
        
			// 共通 値引
			drDeposit[ctDiscountDeposit] = discountDeposit;
        
			Int64 total = deposit + feeDeposit + discountDeposit;
        
			// 入金合計 共通
			drDeposit[ctDepositTotal] = total;
        
			// 入金引当残 共通 (入金合計 共通 - 入金引当額 共通)
			drDeposit[ctDepositAlwcBlnce_Deposit] = total - Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]);
        
			return total;
        }
        #endregion
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        #region 2007.10.05 hikita del
        ///// <summary>
        ///// 入金金額 共通 変更処理
        ///// </summary>
        ///// <param name="deposit">共通 入金額</param>
        ///// <param name="feeDeposit">共通 手数料</param>
        ///// <param name="discountDeposit">共通 値引</param>
        ///// <param name="rebateDeposit">共通 インセンティブ</param>
        ///// <param name="drDeposit">入金情報DataRow</param>
        ///// <returns>入金合計 共通</returns>
        ///// <remarks>
        ///// <br>Note       : 共通 入金額 の変更を各内容に反映します。</br>
        ///// <br>Programmer : 18322 T.Kimura</br>
        ///// <br>Date       : 2007.01.18</br>
        ///// </remarks>
        //public Int64 ChangeDepositSection(Int64 deposit, Int64 feeDeposit, Int64 discountDeposit, Int64 rebateDeposit, ref System.Data.DataRow drDeposit)
        //{
        //    // 共通 入金額
        //    drDeposit[ctDeposit] = deposit;

        //    // 共通 手数料
        //    drDeposit[ctFeeDeposit] = feeDeposit;

        //    // 共通 値引
        //    drDeposit[ctDiscountDeposit] = discountDeposit;

        //    // 共通 インセンティブ
        //    drDeposit[ctRebateDeposit] = rebateDeposit;

        //    Int64 total = deposit + feeDeposit + discountDeposit + rebateDeposit;

        //    // 入金合計 共通
        //    drDeposit[ctDepositTotal] = total;

        //    // 入金引当残 共通 (入金合計 共通 - 入金引当額 共通)
        //    drDeposit[ctDepositAlwcBlnce_Deposit] = total
        //                                          - Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]);

        //    return total;
        //}
        // ↑ 20070118 18322 c
        // 2007.10.05 hikita upd end ----------------------------------------------------<<
        #endregion 2007.10.05 hikita del

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 入金引当情報 受注 変更処理（全てコメントアウト）
        ///// <summary>
		///// 入金引当情報 受注 変更処理
		///// </summary>
		///// <param name="difference">引当変更前後差額</param>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <param name="drDeposit">入金情報DataRow</param>
		///// <param name="flgAcpOdrDepositAlwc_Alw">引当残 受注 (入金引当額) 更新フラグ</param>
		///// <param name="flgAcpOdrDepoAlwcBlnce_Sales">引当残 受注 (請求売上マスタ) 更新フラグ</param>
		///// <param name="flgAcpOdrDepositAlwc_Sales">引当済 受注 (請求売上マスタ) 更新フラグ</param>
		///// <returns>入金情報の入金未引当額</returns>
		///// <remarks>
		///// <br>Note       : 引当額 受注 の変更を各内容に反映します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 UpdateAcpOdrDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, ref System.Data.DataRow drDeposit, bool flgAcpOdrDepositAlwc_Alw, bool flgAcpOdrDepoAlwcBlnce_Sales, bool flgAcpOdrDepositAlwc_Sales)
		//{
		//	// 引当残 受注 (入金引当額) を更新する
		//	if (flgAcpOdrDepositAlwc_Alw)
		//	{
		//		drDmdSales[ctAcpOdrDepositAlwc_Alw] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) + difference;
		//	}
        //
		//	// 引当残 受注 (請求売上マスタ) を更新する
		//	if (flgAcpOdrDepoAlwcBlnce_Sales)
		//	{
		//		drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]) - difference;
		//	}
        //
		//	// 引当済 受注 (請求売上マスタ) を更新する
		//	if (flgAcpOdrDepositAlwc_Sales)
		//	{
		//		drDmdSales[ctAcpOdrDepositAlwc_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Sales]) + difference;
		//	}
        //
		//	// 引当後の 入金引当額 受注 を更新する
		//	drDeposit[ctAcpOdrDepositAlwc_Deposit] = Convert.ToInt64(drDeposit[ctAcpOdrDepositAlwc_Deposit]) + difference;
        //
		//	// 引当後の 入金引当残 受注 を更新する
		//	drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit]) - difference;
        //
		//	// 入金引当残 受注 を戻す
		//	return Convert.ToInt64(drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit]);
        //}
        #endregion
        // ↑ 20070118 18322 d

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 入金引当情報 諸費用 変更処理(全てコメントアウト)
        ///// <summary>
		///// 入金引当情報 諸費用 変更処理
		///// </summary>
		///// <param name="difference">引当変更前後差額</param>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <param name="drDeposit">入金情報DataRow</param>
		///// <param name="flgVarCostDepoAlwc_Alw">引当残 諸費用 (入金引当額) 更新フラグ</param>
		///// <param name="flgVarCostDepoAlwcBlnce_Sales">引当残 諸費用 (請求売上マスタ) 更新フラグ</param>
		///// <param name="flgVarCostDepoAlwc_Sales">引当済 諸費用 (請求売上マスタ) 更新フラグ</param>
		///// <returns>入金情報の入金未引当額</returns>
		///// <remarks>
		///// <br>Note       : 引当額 諸費用 の変更を各内容に反映します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 UpdateCostDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, ref System.Data.DataRow drDeposit, bool flgVarCostDepoAlwc_Alw, bool flgVarCostDepoAlwcBlnce_Sales, bool flgVarCostDepoAlwc_Sales)
		//{
		//	// 引当額 諸費用 (入金引当額) を更新する
		//	if (flgVarCostDepoAlwc_Alw)
		//	{
		//		drDmdSales[ctVarCostDepoAlwc_Alw] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) + difference;
		//	}
        //
		//	// 引当残 諸費用 (請求売上マスタ) を更新する
		//	if (flgVarCostDepoAlwcBlnce_Sales)
		//	{
		//		drDmdSales[ctVarCostDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]) - difference;
		//	}
        //
		//	// 引当済 諸費用 (請求売上マスタ) を更新する
		//	if (flgVarCostDepoAlwc_Sales)
		//	{
		//		drDmdSales[ctVarCostDepoAlwc_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Sales]) + difference;
		//	}
        //
		//	// 引当後の 入金引当額 諸費用 を更新する
		//	drDeposit[ctVarCostDepoAlwc_Deposit] = Convert.ToInt64(drDeposit[ctVarCostDepoAlwc_Deposit]) + difference;
        //    
		//	// 引当後の 入金引当残 諸費用 を更新する
		//	drDeposit[ctVarCostDepoAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctVarCostDepoAlwcBlnce_Deposit]) - difference;
        //
		//	// 入金引当残 諸費用 を戻す
		//	return Convert.ToInt64(drDeposit[ctVarCostDepoAlwcBlnce_Deposit]);
		//}
        #endregion
        // ↑ 20070118 18322 d

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入金引当情報 共通 変更処理
        /// </summary>
        /// <param name="difference">引当変更前後差額</param>
        /// <param name="drDmdSales">請求売上情報DataRow</param>
        /// <param name="drDeposit">入金情報DataRow</param>
        /// <param name="flgDepositAllowance_Alw">引当残 共通 (入金引当マスタ) 更新フラグ</param>
        /// <param name="flgDepositAlwcBlnce_Sales">引当残 共通 (請求売上マスタ) 更新フラグ</param>
        /// <returns>入金情報の入金未引当額</returns>
        /// <remarks>
        /// <br>Note       : 引当額 共通 の変更を各内容に反映します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public Int64 UpdateDepositAlwc(Int64 difference, ref DataRow drDmdSales, ref DataRow drDeposit, bool flgDepositAllowance_Alw, bool flgDepositAlwcBlnce_Sales)
        {
            if (flgDepositAllowance_Alw)   // ON
            {
                // 入金引当額(入金マスタ)
                drDmdSales[ctDepositAllowance_Alw] = 0;

                // 入金引当残(請求売上マスタ)
                drDmdSales[ctDepositAlwcBlnce_Sales] = difference;

                // 入金引当済(請求売上マスタ)
                drDmdSales[ctDepositAllowance_Sales] = 0;
                
                //// 引当後の 入金引当額 共通 を更新する
                //drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) + Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]);
            }

            if (flgDepositAlwcBlnce_Sales) // 入力中
            {
                // 入金引当額
                drDmdSales[ctDepositAllowance_Alw] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) + difference;

                // 入金引当残
                drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]) - difference;

                // 入金引当済
                drDmdSales[ctDepositAllowance_Sales] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Sales]) + difference;

                // 引当後の 入金引当額 共通 を更新する
                drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) + difference;
            }

            return Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]);
        }

        /// <summary>
        /// 引当情報更新処理
        /// </summary>
        /// <param name="acpOdrDepositAlwc">入金引当額 受注</param>
        /// <param name="varCostDepoAlwc">入金引当額 諸費用</param>
        /// <param name="depositAllowance">入金引当額 共通</param>
        /// <param name="drDmdSales">請求売上情報DataRow</param>
        /// <param name="drDeposit">入金情報DataRow</param>
        /// <param name="drAllowance">引当情報DataRow</param>
        /// <remarks>
        /// <br>Note　　　  : 引当情報の引当額を更新します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public void UpdateAllowance(Int64 acpOdrDepositAlwc, Int64 varCostDepoAlwc, Int64 depositAllowance, DataRow drDmdSales, DataRow drDeposit, ref ArrayList drAllowance)
        {
            // 引当情報DataRowの取得
            foreach (DataRow drChild in drAllowance)
            {
                // 同一売上番号の時
                if (Convert.ToInt32(drChild[ctSalesSlipNum_Alw]) == Convert.ToInt32(drDmdSales[ctSalesSlipNum]))
                {
                    if ((acpOdrDepositAlwc == 0) && (varCostDepoAlwc == 0) && (depositAllowance == 0))
                    {
                        // 引当額0円の時は削除
                        drAllowance.Remove(drChild);
                    }
                    else
                    {
                        // 入金引当額
                        drChild[ctDepositAllowance] = depositAllowance;
                    }

                    return;
                }
            }

            //// 同一受注番号行が無くても引当額0円の時は新規行は追加せずに無視する
            //if ((acpOdrDepositAlwc == 0) && (varCostDepoAlwc == 0) && (depositAllowance == 0)) return;

            // 引当情報新規行追加処理  引当情報DataRowが無い時は新規として追加する
            DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDmdSales[ctAcptAnOdrStatus_Alw])
                                                   , Convert.ToInt32(drDeposit[ctDepositSlipNo])
                                                   , drDmdSales[ctSalesSlipNum].ToString()
                                                   , Convert.ToInt32(drDeposit[ctDepositAddUpADate]));
            
            // 入金引当額
            drNewAlw[ctDepositAllowance] = depositAllowance;

            // 新規追加
            drAllowance.Add(drNewAlw);
        }

        /// <summary>
        /// 引当済金額存在チェック
        /// </summary>
        /// <param name="selectedDmdSalesRow">選択行(請求売上情報DataRow)</param>
        /// <returns>ステータス(True:存在　False：存在せず)</returns>
        /// <remarks>
        /// <br>Note　　　  : 引当済金額が存在するかどうかチェックします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public bool CheckExistAllowanceSales(DataRow selectedDmdSalesRow)
        {
            if (selectedDmdSalesRow[ctDepositAllowance_Sales] == DBNull.Value)
            {
                return (false);
            }

            if ((Int64)selectedDmdSalesRow[ctDepositAllowance_Sales] == 0)
            {
                return (false);
            }

            return (true);
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Parsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金引当情報 共通 変更処理
		/// </summary>
		/// <param name="difference">引当変更前後差額</param>
		/// <param name="drDmdSales">請求売上情報DataRow</param>
		/// <param name="drDeposit">入金情報DataRow</param>
		/// <param name="flgDepositAllowance_Alw">引当残 共通 (入金引当マスタ) 更新フラグ</param>
		/// <param name="flgDepositAlwcBlnce_Sales">引当残 共通 (請求売上マスタ) 更新フラグ</param>
		/// <param name="flgDepositAllowance_Sales">引当済 共通 (請求売上マスタ) 更新フラグ</param>
		/// <returns>入金情報の入金未引当額</returns>
		/// <remarks>
		/// <br>Note       : 引当額 共通 の変更を各内容に反映します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 UpdateDepositAlwc(Int64 difference, ref DataRow drDmdSales, ref DataRow drDeposit, bool flgDepositAllowance_Alw, bool flgDepositAlwcBlnce_Sales, bool flgDepositAllowance_Sales)
		{
            //// 引当額 共通 (入金引当マスタ)を更新する
            //if (flgDepositAllowance_Alw)
            //{
            //    drDmdSales[ctDepositAllowance_Alw] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) + difference;
            //}

            //// 引当残 共通 (請求売上マスタ) を更新する
            //if (flgDepositAlwcBlnce_Sales)
            //{
            //    drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]) - difference;
            //}

            //// 引当済 共通 (請求売上マスタ) を更新する
            //if (flgDepositAllowance_Sales)
            //{
            //    drDmdSales[ctDepositAllowance_Sales] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Sales]) + difference;
            //}

            //// 引当後の 入金引当額 共通 を更新する
            //drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) + difference;

            //// 引当後の 入金引当残 共通 を更新する
            //drDeposit[ctDepositAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctDepositAlwcBlnce_Deposit]) - difference;

            //// 入金引当残 共通 を戻す
            //return Convert.ToInt64(drDeposit[ctDepositAlwcBlnce_Deposit]);

            if (flgDepositAllowance_Alw)   // ON
            {
                drDmdSales[ctDepositAllowance_Alw] = 0;
                drDmdSales[ctDepositAlwcBlnce_Sales] = difference;
                drDmdSales[ctDepositAllowance_Sales] = 0;
                // 引当後の 入金引当額 共通 を更新する
                drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) + Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]);
            }

            if (flgDepositAlwcBlnce_Sales) // 入力中
            {
                drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctTotalSales]) - difference;
                drDmdSales[ctDepositAllowance_Sales] = difference;
                // 引当後の 入金引当額 共通 を更新する
                drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) - difference;
            }

            if (flgDepositAllowance_Sales) // OFF
            {
                // 何もしない
            }

            return Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]);
		}
		
		/// <summary>
		/// 引当情報更新処理
		/// </summary>
		/// <param name="acpOdrDepositAlwc">入金引当額 受注</param>
		/// <param name="varCostDepoAlwc">入金引当額 諸費用</param>
		/// <param name="depositAllowance">入金引当額 共通</param>
		/// <param name="drDmdSales">請求売上情報DataRow</param>
		/// <param name="drDeposit">入金情報DataRow</param>
		/// <param name="drAllowance">引当情報DataRow</param>
		/// <remarks>
		/// <br>Note　　　  : 引当情報の引当額を更新します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void UpdateAllowance(Int64 acpOdrDepositAlwc, Int64 varCostDepoAlwc, Int64 depositAllowance, DataRow drDmdSales, DataRow drDeposit, ref ArrayList drAllowance)
		{
			// 引当情報DataRowの取得
			foreach (DataRow drChild in drAllowance)
			{
				// 同一受注番号の時
				// if (Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw]) == Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo]))   // 2007.10.05 hikita del
                // 同一売上番号の時
                if (Convert.ToInt32(drChild[ctSalesSlipNum_Alw]) == Convert.ToInt32(drDmdSales[ctSalesSlipNum]))            // 2007.10.05 hikita add
				{
					if ((acpOdrDepositAlwc == 0) && (varCostDepoAlwc == 0) && (depositAllowance == 0))
					{
						// 引当額0円の時は削除
						drAllowance.Remove(drChild);
					}
					else
					{
                        // ↓ 20070118 18322 d MA.NS用に変更
						//// 引当額の更新
						//drChild[ctAcpOdrDepositAlwc] = acpOdrDepositAlwc;
						//drChild[ctVarCostDepoAlwc] = varCostDepoAlwc;
                        // ↑ 20070118 18322 d
						drChild[ctDepositAllowance] = depositAllowance;
					}

					return;
				}
			}

			// 同一受注番号行が無くても引当額0円の時は新規行は追加せずに無視する
			if ((acpOdrDepositAlwc == 0) && (varCostDepoAlwc == 0) && (depositAllowance == 0)) return;

            // ↓ 20070202 18322 c MA.NS用に変更
            //// 引当情報新規行追加処理  引当情報DataRowが無い時は新規として追加する
			//DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDeposit[ctDepositSlipNo]), Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo]), Convert.ToInt32(drDeposit[ctDepositDate]));
            //
			//// 入金引当額
			//drNewAlw[ctAcpOdrDepositAlwc] = acpOdrDepositAlwc;
			//drNewAlw[ctVarCostDepoAlwc] = varCostDepoAlwc;

            // 引当情報新規行追加処理  引当情報DataRowが無い時は新規として追加する
            DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDmdSales[ctAcptAnOdrStatus_Alw])
                                                   , Convert.ToInt32(drDeposit[ctDepositSlipNo])
            //                                       , Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo])   // 2007.10.05 del
                                                   , drDmdSales[ctSalesSlipNum].ToString()
            //                                       , Convert.ToInt32(drDeposit[ctDepositDate]));      // 2007.10.05 del
                                                   , Convert.ToInt32(drDeposit[ctDepositAddUpADate]));  // 2007.10.05 add
            // ↑ 20070202 18322 c
			drNewAlw[ctDepositAllowance] = depositAllowance;

			// 新規追加
			drAllowance.Add(drNewAlw);
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Parsman用に変更

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 入金引当情報 受注 変更処理（全てコメントアウト）
        ///// <summary>
		///// 入金引当情報 受注 変更処理
		///// </summary>
		///// <param name="difference">引当前後入金差額</param>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <param name="drDeposit">入金情報DataRow</param>
		///// <returns>未引当入金額</returns>
		///// <remarks>
		///// <br>Note       : 引当情報 受注 の変更を各内容に反映します。引当上限は引当残が0円までです。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ZeroUpdateAcpOdrDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, ref System.Data.DataRow drDeposit)
		//{
		//	Int64 maxDepositAlw;
		//	Int64 zanDifference;
        //
		//	if (difference >= 0)		// --- ＋引当 --- //
		//	{
		//		// 引当残 受注 (請求売上マスタ) を取得
		//		Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]);
        //
		//		if (difference >= alwcBlnce_sales)		// --- 引当前後入金差額 >= 引当残 受注 (請求売上マスタ) --- //
		//		{
		//			// 引当残 受注 (請求売上マスタ) を取得
		//			maxDepositAlw = alwcBlnce_sales;
        //
		//			// 引当後の未引当入金額
		//			zanDifference = difference - alwcBlnce_sales;
		//		}
		//		else									// --- 引当前後入金差額 < 引当残 受注 (請求売上マスタ) --- //
		//		{
		//			// 引当前後差額 を取得
		//			maxDepositAlw = difference;
        //
		//			// 引当後の未引当入金額
		//			zanDifference = 0;
		//		}
		//	}
		//	else						// --- －引当 --- //
		//	{
		//		// 引当額 受注 (入金引当額) を取得
		//		Int64 alwc_Alw = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]);
        //
		//		if (difference * -1 > alwc_Alw)			// --- 引当前後入金差額 >= 引当額 受注 (入金引当額) --- //
		//		{
		//			// 引当額 受注 (請求売上マスタ) を取得
		//			maxDepositAlw = alwc_Alw * -1;
        //
		//			// 引当後の未引当入金額
		//			zanDifference = difference - alwc_Alw * -1;
		//		}
		//		else									// --- 引当前後入金差額 < 引当額 受注 (入金引当額) --- //
		//		{
		//			// 引当前後差額 を取得
		//			maxDepositAlw = difference;
        //
		//			// 引当後の未引当入金額
		//			zanDifference = 0;
		//		}
		//	}
        //
		//	// 受注入金計 より引当額が多くなっていれば、引当額の上限を 受注入金計 にする
		//	Int64 acpOdrDepositTotal = Convert.ToInt64(drDeposit[ctAcpOdrDepositTotal]);
		//	Int64 acpOdrDepositAlwc_Alw = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]);
		//	if (acpOdrDepositTotal < acpOdrDepositAlwc_Alw + maxDepositAlw)
		//	{
		//		zanDifference += acpOdrDepositAlwc_Alw + maxDepositAlw - acpOdrDepositTotal;
		//		maxDepositAlw = acpOdrDepositTotal - acpOdrDepositAlwc_Alw;
		//	}
        //
		//	// 引当額 受注 (入金引当額) を更新する
		//	drDmdSales[ctAcpOdrDepositAlwc_Alw] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) + maxDepositAlw;
        //
		//	// 引当残 受注 (請求売上マスタ) を更新する
		//	drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]) - maxDepositAlw;
        //
		//	// 引当済 受注 (請求売上マスタ) を更新する
		//	drDmdSales[ctAcpOdrDepositAlwc_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Sales]) + maxDepositAlw;
        //
		//	// 引当後の 入金引当額 受注 を更新する
		//	drDeposit[ctAcpOdrDepositAlwc_Deposit] = Convert.ToInt64(drDeposit[ctAcpOdrDepositAlwc_Deposit]) + maxDepositAlw;
        //
		//	// 引当後の 入金引当残 受注 を更新する
		//	drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit]) - maxDepositAlw;
        //
		//	return zanDifference;
        //}
        #endregion
        // ↑ 20070118 18322 d

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 入金引当情報 諸費用 変更処理（全てコメントアウト）
        ///// <summary>
		///// 入金引当情報 諸費用 変更処理
		///// </summary>
		///// <param name="difference">引当前後入金差額</param>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <param name="drDeposit">入金情報DataRow</param>
		///// <returns>未引当入金額</returns>
		///// <remarks>
		///// <br>Note       : 引当情報 諸費用 の変更を各内容に反映します。引当上限は引当残が0円までです。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ZeroUpdateCostDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, ref System.Data.DataRow drDeposit)
		//{
		//	Int64 maxDepositAlw;
		//	Int64 zanDifference;
        //
		//	if (difference >= 0)		// --- ＋引当 --- //
		//	{
		//		// 引当残 諸費用 (請求売上マスタ) を取得
		//		Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]);
        //
		//		if (difference >= alwcBlnce_sales)		// --- 引当前後入金差額 >= 引当残 諸費用 (請求売上マスタ) --- //
		//		{
		//			// 引当前後差額 が多いときは 引当残 諸費用 (請求売上マスタ) を取得
		//			maxDepositAlw = alwcBlnce_sales;
        //
		//			// 引当後の未引当入金額
		//			zanDifference = difference - alwcBlnce_sales;
		//		}
		//		else									// --- 引当前後入金差額 < 引当残 諸費用 (請求売上マスタ) --- //
		//		{
		//			// 引当残 諸費用 (請求売上マスタ) が多いときは 引当前後差額 を取得
		//			maxDepositAlw = difference;
        //
		//			// 引当後の未引当入金額
		//			zanDifference = 0;
		//		}
		//	}
		//	else						// --- －引当 --- //
		//	{
		//		// 引当額 諸費用 (入金引当額) を取得
		//		Int64 alwc_Alw = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]);
        //
		//		if (difference * -1 > alwc_Alw)			// --- 引当前後入金差額 >= 引当額 諸費用 (入金引当額) --- //
		//		{
		//			// 引当額 諸費用 (請求売上マスタ) を取得
		//			maxDepositAlw = alwc_Alw * -1;
        //
		//			// 引当後の未引当入金額
		//			zanDifference = difference - alwc_Alw * -1;
		//		}
		//		else									// --- 引当前後入金差額 < 引当額 諸費用 (入金引当額) --- //
		//		{
		//			// 引当前後差額 を取得
		//			maxDepositAlw = difference;
        //
		//			// 引当後の未引当入金額
		//			zanDifference = 0;
		//		}
		//	}
        //
		//	// 諸費用入金計 より引当額が多くなっていれば、引当額の上限を 諸費用入金計 にする
		//	Int64 variousCostDepositTotal = Convert.ToInt64(drDeposit[ctVariousCostDepositTotal]);
		//	Int64 varCostDepoAlwc_Alw = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]);
		//	if (variousCostDepositTotal < varCostDepoAlwc_Alw + maxDepositAlw)
		//	{
		//		zanDifference += varCostDepoAlwc_Alw + maxDepositAlw - variousCostDepositTotal;
		//		maxDepositAlw = variousCostDepositTotal - varCostDepoAlwc_Alw;
		//	}
        //
		//	// 引当額 諸費用 (入金引当額) を更新する
		//	drDmdSales[ctVarCostDepoAlwc_Alw] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) + maxDepositAlw;
        //
		//	// 引当残 諸費用 (請求売上マスタ) を更新する
		//	drDmdSales[ctVarCostDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]) - maxDepositAlw;
        //
		//	// 引当済 諸費用 (請求売上マスタ) を更新する
		//	drDmdSales[ctVarCostDepoAlwc_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Sales]) + maxDepositAlw;
        //
		//	// 引当後の 入金引当額 諸費用 を更新する
		//	drDeposit[ctVarCostDepoAlwc_Deposit] = Convert.ToInt64(drDeposit[ctVarCostDepoAlwc_Deposit]) + maxDepositAlw;
        //    
		//	// 引当後の 入金引当残 諸費用 を更新する
		//	drDeposit[ctVarCostDepoAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctVarCostDepoAlwcBlnce_Deposit]) - maxDepositAlw;
        //
		//	return zanDifference;
        //}
        #endregion
        // ↑ 20070118 18322 d

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 引当額 受注 (入金引当額) 最大額取得処理（全てコメントアウト）
        ///// <summary>
		///// 引当額 受注 (入金引当額) 最大額取得処理
		///// </summary>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <param name="drDeposit">入金情報DataRow</param>
		///// <returns>最大入金引当額</returns>
		///// <remarks>
		///// <br>Note       : 最大引当残を取得します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetMaxAcpOdrDepositAlwc(System.Data.DataRow drDmdSales, System.Data.DataRow drDeposit)
		//{
		//	// マイナス入金の時は計算しない
		//	if (Convert.ToInt64(drDeposit[ctDepositTotal]) < 0)
		//	{
		//		return 0;
		//	}
        //
		//	// 入金引当残 受注 を取得する
		//	Int64 alwcBlnce_deposit = Convert.ToInt64(drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit]);
        //
		//	// 引当残 受注 (請求売上マスタ) を取得する
		//	Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]);
        //
		//	Int64 maxDepositAlw;
		//	if (alwcBlnce_deposit >= alwcBlnce_sales)			// --- 入金引当残 受注 >= 引当残 受注 (請求売上マスタ) --- //
		//	{
		//		// 受注引当残 を返す
		//		maxDepositAlw = alwcBlnce_sales;
		//	}
		//	else												// --- 入金引当残 受注 < 引当残 受注 (請求売上マスタ) --- //
		//	{
		//		// 入金引当残 を返す
		//		maxDepositAlw = alwcBlnce_deposit;
		//	}
        //
		//	return maxDepositAlw;
        //}
        #endregion
        // ↑ 20070118 18322 d

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 引当額 諸費用 (入金引当額) 最大額取得処理(全てコメントアウト)
        ///// <summary>
		///// 引当額 諸費用 (入金引当額) 最大額取得処理
		///// </summary>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <param name="drDeposit">入金情報DataRow</param>
		///// <returns>最大入金引当額</returns>
		///// <remarks>
		///// <br>Note       : 最大引当残を取得します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetMaxCostDepositAlwc(System.Data.DataRow drDmdSales, System.Data.DataRow drDeposit)
		//{
		//	// マイナス入金の時は計算しない
		//	if (Convert.ToInt64(drDeposit[ctDepositTotal]) < 0)
		//	{
		//		return 0;
		//	}
        //
		//	// 入金引当残 諸費用 を取得する
		//	Int64 alwcBlnce_deposit = Convert.ToInt64(drDeposit[ctVarCostDepoAlwcBlnce_Deposit]);
        //
		//	// 引当残 諸費用 (請求売上マスタ) を取得する
		//	Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]);
        //
		//	Int64 maxDepositAlw;
		//	if (alwcBlnce_deposit >= alwcBlnce_sales)			// --- 入金引当残 諸費用 >= 引当残 諸費用 (請求売上マスタ) --- //
		//	{
		//		// 受注引当残 を返す
		//		maxDepositAlw = alwcBlnce_sales;
		//	}
		//	else												// --- 入金引当残 諸費用 < 引当残 諸費用 (請求売上マスタ) --- //
		//	{
		//		// 入金引当残 を返す
		//		maxDepositAlw = alwcBlnce_deposit;
		//	}
        //
		//	return maxDepositAlw;
        //}
        #endregion
        // ↑ 20070118 18322 d
		
		/// <summary>
		/// 引当額 共通 (入金引当額) 最大額取得処理
		/// </summary>
		/// <param name="drDmdSales">請求売上情報DataRow</param>
		/// <param name="drDeposit">入金情報DataRow</param>
		/// <returns>最大入金引当額</returns>
		/// <remarks>
		/// <br>Note       : 最大引当残を取得します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 GetMaxDepositAlwc(DataRow drDmdSales, DataRow drDeposit)
		{
            //// マイナス入金の時は計算しない
            //if (Convert.ToInt64(drDeposit[ctDepositTotal]) < 0)
            //{
            //    return 0;
            //}

            //// 入金引当残 共通 を取得する
            //Int64 alwcBlnce_deposit = Convert.ToInt64(drDeposit[ctDepositAlwcBlnce_Deposit]);

            //// 引当残 共通 (請求売上マスタ) を取得する
            //Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]);

            //Int64 maxDepositAlw;
            //if (alwcBlnce_deposit >= alwcBlnce_sales)			// --- 入金引当残 共通 >= 引当残 共通 (請求売上マスタ) --- //
            //{
            //    // 受注引当残 を返す
            //    maxDepositAlw = alwcBlnce_sales;
            //}
            //else												// --- 入金引当残 共通 < 引当残 共通 (請求売上マスタ) --- //
            //{
            //    // 入金引当残 を返す
            //    maxDepositAlw = alwcBlnce_deposit;
            //}

            //return maxDepositAlw;

            // 引当残を取得する
            Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctTotalSales]);
            return alwcBlnce_sales;

		}

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 引当額 受注 (入金引当額) クリア額処理（全てコメントアウト）
        ///// <summary>
		///// 引当額 受注 (入金引当額) クリア額処理
		///// </summary>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <returns>入金引当クリア額</returns>
		///// <remarks>
		///// <br>Note       : クリア金額を戻します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetClearAcpOdrDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// 引当額 受注 (入金引当額) のクリア額取得
		//	return Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) * -1;
        //}
        #endregion
        // ↑ 20070118 18322 d

        // ↓ 20070118 18322 d MA.NS用に変更
        #region SF 引当額 諸費用 (入金引当額) クリア額処理（全てコメントアウト）
        ///// <summary>
		///// 引当額 諸費用 (入金引当額) クリア額処理
		///// </summary>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <returns>入金引当クリア額</returns>
		///// <remarks>
		///// <br>Note       : クリア金額を戻します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetClearCostDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// 引当額 諸費用 (入金引当額) のクリア額取得
		//	return Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) * -1;
        //}
        #endregion
        // ↑ 20070118 18322 d
		
		/// <summary>
		/// 引当額 共通 (入金引当額) クリア額処理
		/// </summary>
		/// <param name="drDmdSales">請求売上情報DataRow</param>
		/// <returns>入金引当クリア額</returns>
		/// <remarks>
		/// <br>Note       : クリア金額を戻します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 GetClearDepositAlwc(DataRow drDmdSales)
		{
			// 引当額 共通 (入金引当額) のクリア額取得
			return Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) * -1;
		}
		
		/// <summary>
		/// 入金情報DataRowコピー処理
		/// </summary>
		/// <param name="drBef">コピー元DataRow</param>
		/// <param name="drAft">コピー先DataRow</param>
		/// <returns>入金情報DataRow</returns>
		/// <remarks>
		/// <br>Note　　　  : DataRowの中身の値のコピーを行います。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void CopyDepositDataRow(ref DataRow drBef, ref DataRow drAft)
		{
			// DataRowをコピーする
			drAft = drBef.Table.NewRow();
			for (int ix = 0; ix < drAft.ItemArray.Length; ix++)
			{
				drAft[ix] = drBef[ix];
			}
		}

		/// <summary>
		/// 引当情報DataRowコピー処理
		/// </summary>
		/// <param name="arBef">コピー元DataRow ArrayList</param>
		/// <param name="arAft">コピー先DataRow ArrayList</param>
		/// <returns>入金情報DataRow</returns>
		/// <remarks>
		/// <br>Note　　　  : DataRowの中身の値のコピーを行います。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void CopyAllowanceDataRow(ref ArrayList arBef, ref ArrayList arAft)
		{
			arAft.Clear();

			foreach (DataRow drBef in arBef)
			{
				// DataRowをコピーする
				DataRow drAft = drBef.Table.NewRow();
				for (int ix = 0; ix < drAft.ItemArray.Length; ix++)
				{
					drAft[ix] = drBef[ix];
				}
				arAft.Add(drAft);
			}
		}

		/// <summary>
		/// 入金情報DataRow複製取得処理
		/// </summary>
		/// <param name="drDeposit">入金情報DataRow</param>
		/// <returns>入金情報DataRow</returns>
		/// <remarks>
		/// <br>Note　　　  : 選択された入金情報DataSetのDataRowのコピーを返します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataRow GetSelectDepositCopyRow(DataRow drDeposit)
		{
			// 選択DataRowの複製を戻す
			DataRow dr = _dsDepositInfo.Tables[ctDepositDataTable].NewRow();
			for (int ix = 0; ix < dr.ItemArray.Length; ix++)
			{
				dr[ix] = drDeposit[ix];
			}

			return dr;
		}

		/// <summary>
		/// 引当情報DataRow複製取得処理
		/// </summary>
		/// <param name="drDeposit">入金情報DataRow</param>
		/// <returns>引当情報DataRow</returns>
		/// <remarks>
		/// <br>Note　　　  : 選択された入金情報DataSetの子DataRow(引当情報)のコピーを返します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public ArrayList GetSelectAllowanceCopyRow(DataRow drDeposit)
		{
			ArrayList al = new ArrayList();

			// 選択DataRowの子行を取得する
			foreach (DataRow dr in drDeposit.GetChildRows(ctRelation_DepositAllowance))
			{
				// 選択子DataRowの複製を戻す
				DataRow cdr = dr.Table.NewRow();
				for (int ix = 0; ix < cdr.ItemArray.Length; ix++)
				{
					cdr[ix] = dr[ix];
				}

				al.Add(cdr);
			}

			return al;
		}

		/// <summary>
		/// 請求売上情報DataRow取得処理
		/// </summary>
		/// <param name="index">請求売上情報DataSetのRowIndex</param>
		/// <returns>請求売上情報DataRow</returns>
		/// <remarks>
		/// <br>Note　　　  : 選択された請求売上情報DataSetのDataRowを返します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataRow GetSelectDmdSalesRow(int index)
		{
			// 選択DataRowを戻す
			return _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows[index];
		}

		/// <summary>
		/// 行の変更状況チェック処理
		/// </summary>
		/// <param name="befDepositRow">入金情報(処理前)</param>
		/// <param name="befAllowanceRows">引当情報(処理前)</param>
		/// <param name="aftDepositRow">入金情報(処理後)</param>
		/// <param name="aftAllowanceRows">引当情報(処理後)</param>
        /// <param name="flag">0:新規</param>
		/// <returns>変更ステータス true:変更有り.false:変更無し</returns>
		/// <remarks>
		/// <br>Note       : 行内容が変更されたかどうかをチェックします。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
        //public bool CheckUpdateData(DataRow befDepositRow, ArrayList befAllowanceRows, DataRow aftDepositRow, ArrayList aftAllowanceRows) // DEL 2009/12/25
        public bool CheckUpdateData(DataRow befDepositRow, ArrayList befAllowanceRows, DataRow aftDepositRow, ArrayList aftAllowanceRows, int flag) // ADD 2009/12/25
		{
			// 入金情報(処理後)が無い時は未チェック
			if (aftDepositRow != null)
			{
				// 入金情報(処理前)が無い時は新規取得
				if (befDepositRow == null)
				{
					// 入金情報新規行追加処理
					befDepositRow = DepositNewRow();
				}

				// 入金情報のチェック処理
				for (int ix=0; ix<befDepositRow.ItemArray.Length; ix++)
				{
                    // --- ADD 2009/12/25 ---------->>>>>
                    if (flag == 0
                        && (befDepositRow.Table.Columns[ix].ColumnName == InputDepositNormalTypeAcs.ctDepositAddUpADate
                        || befDepositRow.Table.Columns[ix].ColumnName == InputDepositNormalTypeAcs.ctDepositAddUpADateDisp
                        || befDepositRow.Table.Columns[ix].ColumnName == InputDepositNormalTypeAcs.ctOutline))
                    {
                        continue;
                    }
                    // --- ADD 2009/12/25 ----------<<<<<

					if (befDepositRow[ix].ToString() != aftDepositRow[ix].ToString())
						return true;

                    // ADD 2010/05/12 MANTIS対応[15195]：入金0を修正呼出し直後の保存が行えない ---------->>>>>
                    // 0円の入金は更新対象
                    if (!flag.Equals(0) && ix.Equals(13))   // [13]：入金の合計
                    {
                        long deposit = (long)befDepositRow.ItemArray[ix];
                        if (deposit.Equals(0)) return true;
                    }
                    // ADD 2010/05/12 MANTIS対応[15195]：入金0を修正呼出し直後の保存が行えない ----------<<<<<
				}
			}

			// 引当情報(処理後)が無い時は未チェック
			if (aftAllowanceRows != null)
			{
				// 引当情報のチェック処理 行数の比較
				if (befAllowanceRows.Count != aftAllowanceRows.Count) return true;

				// 引当情報のソート処理
				befAllowanceRows.Sort(new cmpAllowance());
				aftAllowanceRows.Sort(new cmpAllowance());

				// 引当情報のチェック処理 内容の比較
				for (int ix=0; ix<befAllowanceRows.Count; ix++)
				{
					DataRow befAllowanceRow = (DataRow)befAllowanceRows[ix];
					DataRow aftAllowanceRow = (DataRow)aftAllowanceRows[ix];

					for (int iy=0; iy<befAllowanceRow.ItemArray.Length; iy++)
					{
						if (befAllowanceRow[iy].ToString() != aftAllowanceRow[iy].ToString())
							return true;
					}
				}
			}

			return false;
        }

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 引当状況不正チェック処理
		/// </summary>
		/// <param name="errorLevel">不正チェックレベル 0:ERR, 1:Info</param>
		/// <param name="optSeparateCost">諸費用別入金オプション 有無</param>
		/// <param name="allowanceProc">引当処理区分</param>
		/// <param name="depositRow">入金情報(処理後)</param>
		/// <param name="arrAllowanceRow">引当情報(処理後)</param>
		/// <param name="dmdSalesDs">請求売上情報(処理後)</param>
		/// <param name="messages">エラーメッセージ</param>
		/// <returns>変更ステータス 0:正常. -1:引当不正</returns>
		/// <remarks>
		/// <br>Note       : 引当不正になっていないかチェックを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheckUpdateAlwcBlnce(int errorLevel, bool optSeparateCost, int allowanceProc, DataRow depositRow, ArrayList arrAllowanceRow, DataSet dmdSalesDs, out System.Collections.Specialized.StringCollection messages)
		{
			messages = new System.Collections.Specialized.StringCollection();

			// --- 必須引当の時 --- //
			if (allowanceProc == 1)
			{
				// 【Level:Err】引当残高(共通) > 0 ※入金額(共通)に満たない引当額(共通)
				if ((errorLevel == 0) && (Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]) > 0))
				{
					messages.Add("全入金金額が引当されていません。" + "\r\n\r\n" + 
						"    入金金額  :  " + Convert.ToInt64(depositRow[ctDepositTotal]).ToString("###,###,##0") + " 円" + "\r\n\r\n" +
						"    引当残  :  " + Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]).ToString("###,###,##0") + " 円" + "\r\n\r\n");
				}
			}

			// --- マイナス入金の時 --- //
			if (Convert.ToInt64(depositRow[ctDepositTotal]) < 0)
			{
				// 【Level:Info】入金合計(受注) < 0 ※マイナス入金
				if (errorLevel == 1)
				{
					messages.Add("入金金額がマイナスです。" + "\r\n\r\n" + 
							"このまま保存してよろしいですか？");
				}
			}
			else
			{
				// 【Level:Err】引当残高(共通) < 0 ※入金額(共通)を超える引当額(共通)
				if ((errorLevel == 0) && (Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]) < 0))
				{
					messages.Add("引当額が入金金額を超えています。" + "\r\n\r\n" + 
						"    入金金額  :  " + Convert.ToInt64(depositRow[ctDepositTotal]).ToString("###,###,##0") + " 円" + "\r\n\r\n" +
						"    引当額  :  " + Convert.ToInt64(depositRow[ctDepositAllowance_Deposit]).ToString("###,###,##0") + " 円" + "\r\n\r\n");
				}

                // ↓ 20070118 18322 d MA.NS用に変更
                #region SF 受注・諸費用（全てコメントアウト）
                //// --- 諸費用別入金 有り --- //
				//if (optSeparateCost == true)
				//{
				//	// 【Level:Info】引当残高(受注) < 0 ※入金額(受注)を超える引当額(受注)
				//	if ((errorLevel == 1) && (Convert.ToInt64(depositRow[ctAcpOdrDepoAlwcBlnce_Deposit]) < 0))
				//	{
				//		messages.Add("引当額(受)が入金額(受)を超えています。" + "\r\n\r\n" + 
				//			"    入金額(受)  :  " + Convert.ToInt64(depositRow[ctAcpOdrDepositTotal]).ToString("###,###,##0") + " 円" + "\r\n\r\n" +
				//			"    引当額(受)  :  " + Convert.ToInt64(depositRow[ctAcpOdrDepositAlwc_Deposit]).ToString("###,###,##0") + " 円" + "\r\n\r\n" +
				//			"このまま保存してよろしいですか？");
				//	}
                //
				//	// 【Level:Info】引当残高(諸費用) < 0 ※入金額(諸費用)を超える引当額(諸費用)
				//	if ((errorLevel == 1) && (Convert.ToInt64(depositRow[ctVarCostDepoAlwcBlnce_Deposit]) < 0))
				//	{
				//		messages.Add("引当額(諸)が入金額(諸)を超えています。" + "\r\n\r\n" + 
				//			"    入金額(諸)  :  " + Convert.ToInt64(depositRow[ctVariousCostDepositTotal]).ToString("###,###,##0") + " 円" + "\r\n\r\n" +
				//			"    引当額(諸)  :  " + Convert.ToInt64(depositRow[ctVarCostDepoAlwc_Deposit]).ToString("###,###,##0") + " 円" + "\r\n\r\n" +
				//			"このまま保存してよろしいですか？");
				//	}
                //}
                #endregion
                // ↑ 20070118 18322 d
			}


			// --- 請求売上データに対するエラーチェック --- //
			bool hitflg1 = false;
			bool hitflg2 = false;
			// 引当情報を順次取得
			DataRow[] allowanceRows = (DataRow[])arrAllowanceRow.ToArray(typeof(DataRow));
			foreach (DataRow allowanceRow in allowanceRows)
			{
				// 請求売上を順次取得
				foreach (DataRow dmdSalesRow in dmdSalesDs.Tables[ctDmdSalesDataTable].Rows)
				{
					// 同一請求売上の時
					// if (Convert.ToInt32(dmdSalesRow[ctAcceptAnOrderNo]) == Convert.ToInt32(allowanceRow[ctAcceptAnOrderNo_Alw]))   // 2007.10.05 del
                    if (Convert.ToInt32(dmdSalesRow[ctSalesSlipNum]) == Convert.ToInt32(allowanceRow[ctSalesSlipNum_Alw]))            // 2007.10.05 add
					{
                        // ↓ 20070129 18322 c MA.NS用に変更
                        #region SF 保存確認（全てコメントアウト）
                        //// 【Level:Info】預り金で納品書以外の時 ※通常入金の時、見積書/指示書への引当
						//if ((errorLevel == 1) && (hitflg1 == false) && (Convert.ToInt64(depositRow[ctDepositCd]) == 0) && (Convert.ToInt32(dmdSalesRow[ctAcptAnOdrStatus]) != 30)) 
						//{
						//	hitflg1 = true;
						//	messages.Add("預り金区分が通常入金として、見積書/指示書に引当てられています。" + "\r\n\r\n" + 
						//		"このまま保存してよろしいですか？");
						//}
                        //
						//// 【Level:Info】引当残 共通 (請求売上マスタ) < 0 ※引当残 共通 (請求売上マスタ)がマイナスの時
						//if ((errorLevel == 1) && (hitflg2 == false) && (Convert.ToInt32(dmdSalesRow[ctDmdSalesDebitNoteCd]) == 0) && (Convert.ToInt32(dmdSalesRow[ctDepositAlwcBlnce_Sales]) < 0)) 
						//{
						//	// 引当額がプラスの時
						//	if (Convert.ToInt64(allowanceRow[ctDepositAllowance]) > 0)
						//	{
						//		hitflg2 = true;
						//		messages.Add("受注額以上の入金が引当されています。" + "\r\n\r\n" + 
						//			"このまま保存してよろしいですか？");
						//	}
                        //}
                        #endregion

						// 【Level:Info】引当残 共通 (請求売上マスタ) < 0
                        //                         ※引当残 共通 (請求売上マスタ)がマイナスの時
						if ((errorLevel == 1) &&
                            (hitflg2 == false) &&
                            (Convert.ToInt32(dmdSalesRow[ctDmdSalesDebitNoteCd]) == 0))
                        {
                            if (Convert.ToInt32(dmdSalesRow[ctDepositAlwcBlnce_Sales]) < 0)
	    					{
							    // 引当額がプラスの時
							    if (Convert.ToInt64(allowanceRow[ctDepositAllowance]) > 0)
							    {
								    hitflg2 = true;
								    messages.Add("売上額以上の入金が引当されています。" + "\r\n\r\n" + 
									             "このまま保存してよろしいですか？");
							    }
                            }
                        }
                        // ↑ 20070129 18322 c

						break;
					}
				}
				if ((hitflg1 == true) && (hitflg2 == true)) break;
			}

			if (messages.Count == 0)
			{
				return 0;
			}
			else
			{
				return -1;
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 引当状況不正チェック処理
        /// </summary>
        /// <param name="errorLevel">不正チェックレベル 0:ERR, 1:Info</param>
        /// <param name="allowanceProc">引当処理区分</param>
        /// <param name="depositRow">入金情報(処理後)</param>
        /// <param name="arrAllowanceRow">引当情報(処理後)</param>
        /// <param name="dmdSalesDs">請求売上情報(処理後)</param>
        /// <param name="messages">エラーメッセージ</param>
        /// <returns>変更ステータス 0:正常. -1:引当不正</returns>
        public int CheckUpdateAlwcBlnce(int errorLevel, int allowanceProc, DataRow depositRow, ArrayList arrAllowanceRow, DataSet dmdSalesDs, out StringCollection messages)
        {
            messages = new StringCollection();

            // --- 必須引当の時 --- //
            if (allowanceProc == 1)
            {
                // 【Level:Err】引当残高(共通) > 0 ※入金額(共通)に満たない引当額(共通)
                if ((errorLevel == 0) && (Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]) > 0))
                {
                    messages.Add("全入金金額が引当されていません。" + "\r\n\r\n" +
                        "    入金金額  :  " + Convert.ToInt64(depositRow[ctDepositTotal]).ToString("###,###,##0") + " 円" + "\r\n\r\n" +
                        "    引当残  :  " + Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]).ToString("###,###,##0") + " 円" + "\r\n\r\n");
                }
            }

            // --- マイナス入金の時 --- //
            if (Convert.ToInt64(depositRow[ctDepositTotal]) < 0)
            {
                // 【Level:Info】入金合計(受注) < 0 ※マイナス入金
                if (errorLevel == 1)
                {
                    messages.Add("入金金額がマイナスです。" + "\r\n\r\n" +
                            "このまま保存してよろしいですか？");
                }
            }
            else
            {
                // 【Level:Err】引当残高(共通) < 0 ※入金額(共通)を超える引当額(共通)
                if ((errorLevel == 0) && (Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]) < 0))
                {
                    messages.Add("引当額が入金金額を超えています。" + "\r\n\r\n" +
                        "    入金金額  :  " + Convert.ToInt64(depositRow[ctDepositTotal]).ToString("###,###,##0") + " 円" + "\r\n\r\n" +
                        "    引当額  :  " + Convert.ToInt64(depositRow[ctDepositAllowance_Deposit]).ToString("###,###,##0") + " 円" + "\r\n\r\n");
                }
            }

            // --- 請求売上データに対するエラーチェック --- //
            bool hitflg1 = false;
            bool hitflg2 = false;

            // 引当情報を順次取得
            DataRow[] allowanceRows = (DataRow[])arrAllowanceRow.ToArray(typeof(DataRow));
            foreach (DataRow allowanceRow in allowanceRows)
            {
                // 請求売上を順次取得
                foreach (DataRow dmdSalesRow in dmdSalesDs.Tables[ctDmdSalesDataTable].Rows)
                {
                    // 同一請求売上の時
                    if (Convert.ToInt32(dmdSalesRow[ctSalesSlipNum]) == Convert.ToInt32(allowanceRow[ctSalesSlipNum_Alw]))            // 2007.10.05 add
                    {
                        // 【Level:Info】引当残 共通 (請求売上マスタ) < 0
                        //  ※引当残 共通 (請求売上マスタ)がマイナスの時
                        if ((errorLevel == 1) &&
                            (hitflg2 == false) &&
                            (Convert.ToInt32(dmdSalesRow[ctDmdSalesDebitNoteCd]) == 0))
                        {
                            if (Convert.ToInt32(dmdSalesRow[ctDepositAlwcBlnce_Sales]) < 0)
                            {
                                // 引当額がプラスの時
                                if (Convert.ToInt64(allowanceRow[ctDepositAllowance]) > 0)
                                {
                                    hitflg2 = true;
                                    messages.Add("売上額以上の入金が引当されています。" + "\r\n\r\n" +
                                                 "このまま保存してよろしいですか？");
                                }
                            }
                        }

                        break;
                    }
                }
                if ((hitflg1 == true) && (hitflg2 == true)) break;
            }

            if (messages.Count == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 入金日最終締日（請求）以前チェック処理
		/// </summary>
		/// <param name="depositDate">入金日</param>
		/// <returns>チェックステータス -1:過去, 0:同じ. 1:未来</returns>
		/// <remarks>
		/// <br>Note       : 入金日と前回締日の（請求）関係をチェックします。
		///                :   ※前回締日が0の時は、戻り値は0を返します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheckPastCAddUpUpdDate(int depositDate)
		{
            //// 未締め状態は未来で返す
            //if (_depositCustomer.CAddUpUpdDate == 0) return 1;

            //// 入金日が前回締日と同一
            //if (_depositCustomer.CAddUpUpdDate == depositDate)
            //{
            //    return 0;
            //}
            //// 入金日が前回締日より過去の時
            //else if (_depositCustomer.CAddUpUpdDate > depositDate)
            //{
            //    return -1;
            //}
            //else
            //{
            //    return 1;
            //}

            // 未締め状態は未来で返す
            if (this._lastAddUpDay == DateTime.MinValue) return 1;

            // 入金日が前回締日と同一
            if (TDateTime.DateTimeToLongDate(this._lastAddUpDay) == depositDate)
            {
                return 0;
            }
            // 入金日が前回締日より過去の時
            else if (TDateTime.DateTimeToLongDate(this._lastAddUpDay) > depositDate)
            {
                return -1;
            }
            else
            {
                return 1;
            }
		}

		/// <summary>
		/// 引当先受注伝票のチェック処理
		/// </summary>
		/// <param name="kbn">チェック区分 0:黒,1:赤,2:相殺済み黒,3:締済み</param>
		/// <param name="drChild">選択引当情報DataRow</param>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
		/// <param name="message">エラー時メッセージ</param>
		/// <returns>ステータス 0:チェック区分の受注無し. 2:チェック区分の受注有り, 以外:その他エラー </returns>
		/// <remarks>
		/// <br>Note       : 引当先の受注伝票の状態をチェックし、チェック種類にあわせたステータスを返します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheackAllowanceSalese(int kbn, DataRow drChild, SearchSalesParameter searchSalesParameter, out string message)
		{
            // ↓ 20070122 18322 c MA.NS用に変更
			//// 引当先受注伝票のチェック処理
			//return this.CheackAllowanceSalese(kbn, Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw]), searchSalesParameter.EnterpriseCode, searchSalesParameter.AddUpSecCod, searchSalesParameter.CustomerCode, out message);

			// 引当先受注伝票のチェック処理
			return this.CheackAllowanceSalese(     kbn
//                                             ,     Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw])   // 2007.10.05 del
                                             ,     searchSalesParameter.SalesSlipNum                   // 2007.10.05 add
                                             ,     searchSalesParameter.EnterpriseCode
                                             ,     searchSalesParameter.DemandAddUpSecCd
                                             ,     searchSalesParameter.CustomerCode
                                             ,     searchSalesParameter.ClaimCode
                                             ,     searchSalesParameter.AcptAnOdrStatus
                                             , out message
                                             );
            // ↑ 20070122 18322 c
		}

        /// <summary>
        /// 入金データ更新処理
        /// </summary>
        /// <param name="loginSectionCode">ログイン拠点コード</param>
        /// <param name="addSectionCode">更新拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="depositRow">入金情報(更新情報)</param>
        /// <param name="allowanceRows">引当情報(更新情報)</param>
        /// <param name="depositDate">入金日</param>
        /// <param name="depositSlipNo">更新入金番号</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金情報の更新処理を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2011/12/15 tianjw</br>
        /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
        public int SaveDepositData(string loginSectionCode, 
                                   string addSectionCode, 
                                   int customerCode, 
                                   int claimCode, 
                                   DataRow depositRow, 
                                   ArrayList allowanceRows, 
                                   DateTime depositDate,
                                   out int depositSlipNo, 
                                   out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositSlipNo = 0;

            SearchDepsitMain depsitMain = new SearchDepsitMain();
            Hashtable htDepositAlw = new Hashtable();
            DateTime preDepositDate = DateTime.MinValue; // ADD 2011/12/15

            try
            {
                // 更新入金伝票番号取得
                depositSlipNo = (Int32)depositRow[ctDepositSlipNo];

                // 更新時
                if (depositSlipNo != 0)
                {
                    // 読込時入金日の取得
                    preDepositDate = ((SearchDepsitMain)_depsitMain[depositSlipNo]).DepositDate; // ADD 2011/12/15
                    // 読込時入金マスタ・入金引当マスタ取得処理
                    GetBeforeDepositData(depositSlipNo, out depsitMain, out htDepositAlw);
                }

                // 入金マスタ・入金引当マスタ更新内容セット処理
                SetUpdateDepositData1(UpdateMode.Insert, loginSectionCode, addSectionCode, customerCode, claimCode, depositRow, allowanceRows, depositDate, ref depsitMain, ref htDepositAlw);

                // 引当マスタより入金マスタ項目セット処理
                SetUpdateDepositData2(ref depsitMain, htDepositAlw);

                // クラスメンバーコピー処理
                DepsitDataWork depsitDataWork = CopyToDepsitDataWorkFromDepsitMain(depsitMain);             // （入金マスタ⇒入金マスタワーク）
                depsitDataWork.PreDepositDate = preDepositDate; // ADD 2011/12/15
                DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);     // （入金引当マスタ⇒入金引当マスタワーク）

                // 更新処理
                status = this._depsitMainAcs.WriteDB(ref depsitDataWork, ref depositAlwWorkList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // クラスメンバーコピー処理
                ArrayList arrDepsitMain = CopyToDepsitMainFromDepsitDataWork(depsitDataWork);      // （入金マスタワーク⇒入金マスタ）
                ArrayList arrDepositAlw = CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);  // （入金引当マスタワーク⇒入金引当マスタ）

                if (depositSlipNo == 0)
                {
                    // 入金情報/引当情報 保持用データクラス登録処理
                    SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                    int customerCode1;
                    int claimCode1;

                    // 入金情報/引当情報データセット登録処理
                    SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode1, out claimCode1);
                }
                else
                {
                    // 入金情報/引当情報 保持用データクラス更新処理
                    UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

                    // 入金情報/引当情報データセット更新処理
                    UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);
                }

                // 請求売上マスタクラス更新処理
                UpdateDmdSales();

                // 入金番号の取得
                depositSlipNo = depsitDataWork.DepositSlipNo;

            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-支払手形データ更新追加------->>>>
        /// <summary>
        /// 入金更新処理(手形データも連れる)
        /// </summary>
        /// <param name="loginSectionCode">ログイン拠点コード</param>
        /// <param name="addSectionCode">更新拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="depositRow">入金情報(更新情報)</param>
        /// <param name="allowanceRows">引当情報(更新情報)</param>
        /// <param name="depositDate">入金日</param>
        /// <param name="depositSlipNo">更新入金番号</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <param name="rcvDraftDataUpd">手形データ（更新用）</param>
        /// <param name="rcvDraftDataDel">手形データ（削除用）</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金情報、手形データの更新処理を行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.06</br>
        /// <br>Update Note : 2011/12/15 tianjw</br>
        /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
        public int SaveDepositDataWithDraftData(string loginSectionCode,
                                   string addSectionCode,
                                   int customerCode,
                                   int claimCode,
                                   DataRow depositRow,
                                   ArrayList allowanceRows,
                                   DateTime depositDate,
                                   out int depositSlipNo,
                                   out string message,
                                   RcvDraftData rcvDraftDataUpd,
                                   RcvDraftData rcvDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositSlipNo = 0;

            SearchDepsitMain depsitMain = new SearchDepsitMain();
            Hashtable htDepositAlw = new Hashtable();
            DateTime preDepositDate = DateTime.MinValue; // ADD 2011/12/15

            try
            {

                // 更新入金伝票番号取得
                depositSlipNo = (Int32)depositRow[ctDepositSlipNo];

                // 更新時
                if (depositSlipNo != 0)
                {
                    // 読込時入金日の取得
                    preDepositDate = ((SearchDepsitMain)_depsitMain[depositSlipNo]).DepositDate; // ADD 2011/12/15
                    // 読込時入金マスタ・入金引当マスタ取得処理
                    GetBeforeDepositData(depositSlipNo, out depsitMain, out htDepositAlw);
                }

                // 入金マスタ・入金引当マスタ更新内容セット処理
                SetUpdateDepositData1(UpdateMode.Insert, loginSectionCode, addSectionCode, customerCode, claimCode, depositRow, allowanceRows, depositDate, ref depsitMain, ref htDepositAlw);

                // 引当マスタより入金マスタ項目セット処理
                SetUpdateDepositData2(ref depsitMain, htDepositAlw);


                // クラスメンバーコピー処理
                DepsitDataWork depsitDataWork = CopyToDepsitDataWorkFromDepsitMain(depsitMain);             // （入金マスタ⇒入金マスタワーク）
                depsitDataWork.PreDepositDate = preDepositDate; // ADD 2011/12/15
                DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);     // （入金引当マスタ⇒入金引当マスタワーク）

                // 更新用受取手形データ
                RcvDraftDataWork rcvDraftDataWorkUpd;
                if (rcvDraftDataUpd != null)
                    rcvDraftDataWorkUpd = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftDataUpd);
                else
                    rcvDraftDataWorkUpd = null;

                // 削除用受取手形データ
                RcvDraftDataWork rcvDraftDataWorkDel;
                if (rcvDraftDataDel != null)
                    rcvDraftDataWorkDel = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftDataDel);
                else
                    rcvDraftDataWorkDel = null;

                // 更新処理
                status = this._depsitMainAcs.WriteDBWithDraftData(ref depsitDataWork, ref depositAlwWorkList, out message, rcvDraftDataWorkUpd, rcvDraftDataWorkDel);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // 入金情報変更する場合
                if (depsitDataWork.UpdateSecCd != "")
                {
                    // クラスメンバーコピー処理
                    ArrayList arrDepsitMain = CopyToDepsitMainFromDepsitDataWork(depsitDataWork);      // （入金マスタワーク⇒入金マスタ）
                    ArrayList arrDepositAlw = CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);  // （入金引当マスタワーク⇒入金引当マスタ）

                    if (depositSlipNo == 0)
                    {
                        // 入金情報/引当情報 保持用データクラス登録処理
                        SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        int customerCode1;
                        int claimCode1;

                        // 入金情報/引当情報データセット登録処理
                        SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode1, out claimCode1);
                    }
                    else
                    {
                        // 入金情報/引当情報 保持用データクラス更新処理
                        UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        // 入金情報/引当情報データセット更新処理
                        UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);
                    }

                    // 請求売上マスタクラス更新処理
                    UpdateDmdSales();

                    // 入金番号の取得
                    depositSlipNo = depsitDataWork.DepositSlipNo;
                }

            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-支払手形データ更新追加------->>>>
        /// <summary>
        /// 入金データ削除処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="befDepositRow">入金情報(処理前)</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金情報の削除処理を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int DeleteDepositData(string enterpriseCode, DataRow befDepositRow, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            DepsitDataWork depsitDataWork = null;
            DepositAlwWork[] depositAlwWorkList = null;

            try
            {
                // 削除入金伝票番号取得
                int depositSlipNo = (Int32)befDepositRow[ctDepositSlipNo];
                // 入金赤黒区分取得
                int depositDebitNoteCd = (Int32)befDepositRow[ctDepositDebitNoteCd];
                // 受注ステータス
                //int acptAnOdrStatus = (Int32)befDepositRow[ctAcptAnOdrStatus];
                int acptAnOdrStatus = (Int32)befDepositRow[ctDepositAcptAnOdrStatus];

                // 入金赤黒区分 通常黒の時
                if (depositDebitNoteCd == 0)
                {
                    // 削除処理
                    status = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, acptAnOdrStatus, out message);
                }
                // 入金赤黒区分 赤の時
                else
                {
                    // 削除処理
                    status = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, acptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, out message);
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // 入金情報/引当情報 保持用データクラス削除処理
                DeleteDepositSaveClass(depositSlipNo);

                // 入金情報/引当情報データセット削除処理
                DeleteDepositDataSet(depositSlipNo);

                // 入金赤黒区分 赤の時
                if (depositDebitNoteCd != 0)
                {
                    // クラスメンバーコピー処理
                    ArrayList arrDepsitMain = CopyToDepsitMainFromDepsitDataWork(depsitDataWork);      // （入金マスタワーク⇒入金マスタ）
                    ArrayList arrDepositAlw = CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);  // （入金引当マスタワーク⇒入金引当マスタ）

                    // 入金情報/引当情報 保持用データクラス更新処理    赤(黒)の更新
                    UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

                    // 入金情報/引当情報データセット更新処理    赤(黒)の更新
                    UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);
                }

                // 請求売上情報データセット再登録処理
                ResetDsDmdSalesInfo();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金データ更新処理
		/// </summary>
		/// <param name="loginSectionCode">ログイン拠点コード</param>
		/// <param name="addSectionCode">更新拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="depositRow">入金情報(更新情報)</param>
		/// <param name="allowanceRows">引当情報(更新情報)</param>
		/// <param name="depositSlipNo">更新入金番号</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金情報の更新処理を行います。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SaveDepositData(string loginSectionCode, string addSectionCode, int customerCode, int claimCode, DataRow depositRow, ArrayList allowanceRows, out int depositSlipNo, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositSlipNo = 0;

			try
			{
				// 更新入金伝票番号取得
				depositSlipNo = Convert.ToInt32(depositRow[ctDepositSlipNo]);

				if (depositSlipNo == 0)
				{
					// --- 入金伝票新規！ --- //

					// 入金マスタ・入金引当マスタ更新内容セット処理
					SearchDepsitMain depsitMain = new SearchDepsitMain();
					Hashtable htDepositAlw = new Hashtable();
					this.SetUpdateDepositData1(UpdateMode.Insert, loginSectionCode, addSectionCode, customerCode, claimCode, depositRow, allowanceRows, ref depsitMain, ref htDepositAlw);

					// 引当マスタより入金マスタ項目セット処理
					this.SetUpdateDepositData2(ref depsitMain, htDepositAlw);

					// クラスメンバーコピー処理（入金マスタクラス⇒入金マスタワーククラス）
                    DepsitMainWork depsitMainWork = this.CopyToDepsitMainWorkFromDepsitMain(depsitMain);

					// クラスメンバーコピー処理（入金引当マスタクラス⇒入金引当マスタワーククラス）
					DepositAlwWork[] depositAlwWorkList = this.CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);

					// 更新処理！
                    this.WriteDeposit(ref depsitMainWork, ref depositAlwWorkList);

					// クラスメンバーコピー処理（入金マスタワーククラス⇒入金マスタクラス）
                    DepsitMainWork[] depsitMainWorkList = new DepsitMainWork[1];
                    depsitMainWorkList[0] = depsitMainWork;
                    ArrayList arrDepsitMain = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

					// クラスメンバーコピー処理（入金引当マスタワーククラス⇒入金引当マスタクラス）
					ArrayList arrDepositAlw = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);

					// 入金情報/引当情報 保持用データクラス登録処理
					this.SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                    int customerCode1;
                    int claimCode1;

					// 入金情報/引当情報データセット登録処理
                    this.SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode1, out claimCode1);

					// 請求売上マスタクラス更新処理
					this.UpdateDmdSales();

					// 新規作成入金番号の取得
                    depositSlipNo = depsitMainWork.DepositSlipNo;

				}
				else
				{
					// --- 入金伝票更新！ --- //

					// 読込時入金マスタ・入金引当マスタ取得処理
					SearchDepsitMain depsitMain;
					Hashtable htDepositAlw;
					this.GetBeforeDepositData(depositSlipNo, out depsitMain, out htDepositAlw);

					// 入金マスタ・入金引当マスタ更新内容セット処理
                    this.SetUpdateDepositData1(UpdateMode.Update, loginSectionCode, addSectionCode, customerCode, claimCode, depositRow, allowanceRows, ref depsitMain, ref htDepositAlw);

					// 引当マスタより入金マスタ項目セット処理
					this.SetUpdateDepositData2(ref depsitMain, htDepositAlw);

					// クラスメンバーコピー処理（入金マスタクラス⇒入金マスタワーククラス）
                    DepsitMainWork depsitMainWork = this.CopyToDepsitMainWorkFromDepsitMain(depsitMain);

					// クラスメンバーコピー処理（入金引当マスタクラス⇒入金引当マスタワーククラス）
					DepositAlwWork[] depositAlwWorkList = this.CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);

					// 更新処理！
                    this.WriteDeposit(ref depsitMainWork, ref depositAlwWorkList);

					// クラスメンバーコピー処理（入金マスタワーククラス⇒入金マスタクラス）
                    DepsitMainWork[] depsitMainWorkList = new DepsitMainWork[1];
                    depsitMainWorkList[0] = depsitMainWork;
                    ArrayList arrDepsitMain = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

					// クラスメンバーコピー処理（入金引当マスタワーククラス⇒入金引当マスタクラス）
					ArrayList arrDepositAlw = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);

					// 入金情報/引当情報 保持用データクラス更新処理
					this.UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

					// 入金情報/引当情報データセット更新処理
					this.UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);

					// 請求売上マスタクラス更新処理
					this.UpdateDmdSales();

					// 更新入金番号の取得
                    depositSlipNo = depsitMainWork.DepositSlipNo;
				}
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}

        /// <summary>
		/// 入金データ削除処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="befDepositRow">入金情報(処理前)</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金情報の削除処理を行います。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int DeleteDepositData(string enterpriseCode, DataRow befDepositRow, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
				// 削除入金伝票番号取得
				int depositSlipNo = Convert.ToInt32(befDepositRow[ctDepositSlipNo]);

				// 入金赤黒区分 通常黒の時
				if (Convert.ToInt32(befDepositRow[ctDepositDebitNoteCd]) == 0)
				{
					// 削除処理！
					this.DeleteDeposit(enterpriseCode, depositSlipNo);

					// 入金情報/引当情報 保持用データクラス削除処理
					this.DeleteDepositSaveClass(depositSlipNo);

					// 入金情報/引当情報データセット削除処理
					this.DeleteDepositDataSet(depositSlipNo);
				}
				// 入金赤黒区分 赤の時
				else
				{
                    DepsitMainWork depsitMainWork;

					DepositAlwWork[] depositAlwWorkList;

					// 削除処理！
                    this.DeleteDeposit(enterpriseCode, depositSlipNo, out depsitMainWork, out depositAlwWorkList);

					// 入金情報/引当情報 保持用データクラス削除処理    赤(赤)の削除
					this.DeleteDepositSaveClass(depositSlipNo);

					// 入金情報/引当情報データセット削除処理    赤(赤)の削除
					this.DeleteDepositDataSet(depositSlipNo);

					// クラスメンバーコピー処理（入金マスタワーククラス⇒入金マスタクラス）
                    DepsitMainWork[] depsitMainWorkList = new DepsitMainWork[1];
                    depsitMainWorkList[0] = depsitMainWork;
                    ArrayList arrDepsitMain = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

					// クラスメンバーコピー処理（入金引当マスタワーククラス⇒入金引当マスタクラス）
					ArrayList arrDepositAlw = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);

					// 入金情報/引当情報 保持用データクラス更新処理    赤(黒)の更新
					this.UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

					// 入金情報/引当情報データセット更新処理    赤(黒)の更新
					this.UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);
				}

				// 請求売上情報データセット再登録処理
				this.ResetDsDmdSalesInfo();
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}

        /// <summary>
		/// 入金データ赤伝処理
		/// </summary>
		/// <param name="mode">赤伝作成モード  0:赤入金作成, 1:赤入金・新黒入金作成</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="updateSecCd">更新拠点コード</param>
		/// <param name="depositAgentCode">入金担当者コード</param>
		/// <param name="depositAgentNm">入金担当者名</param>
		/// <param name="addUpADate">計上日</param>
		/// <param name="akaDepositCd">新赤伝の預り金区分</param>
		/// <param name="depositSlipNo">入金番号(黒)</param>
		/// <param name="akaDepositSlipNo">入金番号(赤)</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金情報の赤伝処理を行います。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		// ↓ 20070125 18322 c MA.NS用に変更
        //public int AkaDepositData(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, int addUpADate, int akaDepositCd, int depositSlipNo, out int akaDepositSlipNo, out string message)
		public int AkaDepositData(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, string depositAgentNm, int addUpADate, int akaDepositCd, int depositSlipNo, out int akaDepositSlipNo, out string message)
        // ↑ 20070125 18322 c
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			akaDepositSlipNo = 0;

			try
			{
                DepsitMainWork[] depsitMainWorkList;

				DepositAlwWork[] depositAlwWorkList;

                // ↓ 20070125 18322 c MA.NS用に変更
				//// 赤更新処理！
				//this.WriteAkaDeposit(mode, enterpriseCode, updateSecCd, depositAgentCode, addUpADate, akaDepositCd, depositSlipNo, out depsitMainWorkList, out depositAlwWorkList);

				// 赤更新処理！
				this.WriteAkaDeposit(     mode
                                    ,     enterpriseCode
                                    ,     updateSecCd
                                    ,     depositAgentCode
                                    ,     depositAgentNm
                                    ,     addUpADate
                                    ,     akaDepositCd
                                    ,     depositSlipNo
                                    , out depsitMainWorkList
                                    , out depsitDataWorkList
                                    , out depositAlwWorkList);
                // ↑ 20070125 18322 c

				// 赤伝入金番号の取得
                foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
                {
                    if (depsitMainWork.DepositDebitNoteCd == 1)
                    {
                        akaDepositSlipNo = depsitMainWork.DepositSlipNo;
                    }
                }

				// クラスメンバーコピー処理（入金マスタワーククラス⇒入金マスタクラス）
                ArrayList arrDepsitMain = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

				// クラスメンバーコピー処理（入金引当マスタワーククラス⇒入金引当マスタクラス）
				ArrayList arrDepositAlw = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);

				// 入金情報/引当情報 保持用データクラス更新処理
				this.UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

				// 入金情報/引当情報データセット更新処理
				this.UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);

				// 赤伝で黒伝が相殺されたので、引当額を黒伝の金額でクリアする
				Hashtable htDepositAlw = (Hashtable)_depositAlw[depositSlipNo];
				if (htDepositAlw != null)
				{
					// 請求売上マスタクラス引当情報クリア処理
					this.ClearDmdSalesAllowance(htDepositAlw);
					
				}

				// 請求売上情報データセット再登録処理
				this.ResetDsDmdSalesInfo();
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
        /// 入金データ赤伝処理
        /// </summary>
        /// <param name="mode">赤伝作成モード  0:赤入金作成, 1:赤入金・新黒入金作成</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updateSecCd">更新拠点コード</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
        /// <param name="depositAgentNm">入金担当者名</param>
        /// <param name="addUpADate">計上日</param>
        /// <param name="akaDepositCd">新赤伝の預り金区分</param>
        /// <param name="depositSlipNo">入金番号(黒)</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積　20:受注　30:売上　40:出荷)</param>
        /// <param name="akaDepositSlipNo">入金番号(赤)</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金情報の赤伝処理を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int AkaDepositData(int mode, 
                                  string enterpriseCode, 
                                  string updateSecCd, 
                                  string depositAgentCode, 
                                  string depositAgentNm, 
                                  int addUpADate, 
                                  int akaDepositCd, 
                                  int depositSlipNo, 
                                  int acptAnOdrStatus,
                                  out int akaDepositSlipNo, 
                                  out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            akaDepositSlipNo = 0;

            try
            {
                DepsitDataWork[] depsitDataWorkList;
                DepositAlwWork[] depositAlwWorkList;

                // 赤入金作成処理
                status = this._depsitMainAcs.RedCreate(mode, 
                                                       enterpriseCode, 
                                                       akaDepositCd, 
                                                       updateSecCd, 
                                                       depositAgentCode, 
                                                       depositAgentNm, 
                                                       TDateTime.LongDateToDateTime(addUpADate), 
                                                       depositSlipNo, 
                                                       acptAnOdrStatus,
                                                       out depsitDataWorkList, 
                                                       out depositAlwWorkList, 
                                                       out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // 赤伝入金番号の取得
                foreach (DepsitDataWork depsitDataWork in depsitDataWorkList)
                {
                    if (depsitDataWork.DepositDebitNoteCd == 1)
                    {
                        akaDepositSlipNo = depsitDataWork.DepositSlipNo;
                    }
                }

                // クラスメンバーコピー処理
                ArrayList arrDepsitMain = CopyToDepsitMainFromDepsitDataWork(depsitDataWorkList);  // （入金マスタワーク⇒入金マスタ）
                ArrayList arrDepositAlw = CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);  // （入金引当マスタワーク⇒入金引当マスタ）

                // 入金情報/引当情報 保持用データクラス更新処理
                this.UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

                // 入金情報/引当情報データセット更新処理
                this.UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);

                // 赤伝で黒伝が相殺されたので、引当額を黒伝の金額でクリアする
                Hashtable htDepositAlw = (Hashtable)_depositAlw[depositSlipNo];
                if (htDepositAlw != null)
                {
                    // 請求売上マスタクラス引当情報クリア処理
                    this.ClearDmdSalesAllowance(htDepositAlw);
                }

                // 請求売上情報データセット再登録処理
                this.ResetDsDmdSalesInfo();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

		/// <summary>
		/// 領収書データ作成処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">発行拠点コード</param>
		/// <param name="depositCustomer">入金得意先情報クラス</param>
		/// <param name="deposit">入金情報</param>
		/// <returns>領収書データ</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金情報より領収書データを作成します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public Receipt SetReceiptFromDepositDataRow(string enterpriseCode, string sectionCode, DepositCustomer depositCustomer, DataRow deposit)
		{
			Receipt receipt = new Receipt();

			receipt.EnterpriseCode		= enterpriseCode;											// 企業コード
   			receipt.CustomerCode		= depositCustomer.CustomerCode;								// 得意先コード
			receipt.ReceiptAddress1		= depositCustomer.Name;										// 領収書宛名１
			receipt.ReceiptAddress2		= depositCustomer.Name2;									// 領収書宛名２
			receipt.RectHonorificTitle	= depositCustomer.HonorificTitle;							// 領収書宛名敬称
			receipt.ReceiptMoney		= Convert.ToInt64(deposit[ctDepositTotal]);					// 領収書金額
			receipt.ReceiptIssueNote	= "";														// 領収書備考内容（発行時）
			receipt.ReceiptIssueOrgCd	= 1;														// 領収書発行区分 0:見積・納品,1:入金,2:領収書
			receipt.DepositSlipNo		= Convert.ToInt32(deposit[ctDepositSlipNo]);				// 入金伝票番号
			receipt.AcceptAnOrderNo		= 0;														// 受注番号
            // ↓ 20070118 18322 d MA.NS用に変更
			//receipt.SlipKind			= 0;														// 伝票種別 10:見積,20:指示,21:承り書,30:納品,40:加修
			//receipt.SlipNo				= "";														// 伝票番号
            // ↑ 20070118 18322 d
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			receipt.DepositKindCode		= Convert.ToInt32(deposit[ctDepositKindCode]);				// 入金金種コード
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            receipt.DepositKindName		= deposit[ctDepositKindName].ToString();					// 入金金種名称
			receipt.Deposit				= Convert.ToInt64(deposit[ctDeposit]);						// 入金金額
			receipt.FeeDeposit			= Convert.ToInt64(deposit[ctFeeDeposit]);					// 手数料入金額
			receipt.DiscountDeposit		= Convert.ToInt64(deposit[ctDiscountDeposit]);				// 値引入金額
            // ↓ 20070118 18322 a
            // インセンティブ
			// receipt.RebateDeposit		= Convert.ToInt64(deposit[ctRebateDeposit]);            // 2007.10.05 hikita del
            // ↑ 20070118 18322 a

			// ↓ 20070118 18322 d MA.NS用に変更
            //receipt.ReceiptIssueSecCd	= sectionCode;												// 領収書発行拠点コード
			// ↑ 20070118 18322 d

			receipt.ReceiptPrintDate	= TDateTime.GetSFDateNow();									// 領収書発行日付

			return receipt;
		}

		/// <summary>
		/// 請求売上情報データセット再登録処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報をデータセットへ再展開します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ResetDsDmdSalesInfo()
		{
			// DataSet初期化
			_dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Clear();

			// 請求売上情報データセット登録処理
			this.SetDsDmdSalesInfo(this._dmdSales);

			// 請求売上情報DetaSet締次更新フラグセット処理
			this.SetDmdSalesDataSetClosedFlg();
		}

		/// <summary>
		/// 引当情報キャンセル処理
		/// </summary>
		/// <param name="drDeposit">選択行入金情報DataRow(変更前)</param>
		/// <param name="selectedDepositCopyRow">入金情報(変更後)</param>
		/// <param name="selectedAllowanceCopyRows">引当情報(変更後)</param>
		/// <remarks>
		/// <br>Note　　　  : 引当情報を読込時状態に戻します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void CancelAllowance(DataRow drDeposit, ref DataRow selectedDepositCopyRow, ref ArrayList selectedAllowanceCopyRows)
		{
			if (drDeposit == null)
			{
				// 引当情報DataRow取得処理
				selectedAllowanceCopyRows.Clear();

                // ↓ 20070118 18322 d MA.NS用に変更
                #region SF 受注・諸費用（全てコメントアウト）
                //// 入金引当額 受注 をクリアする
				//selectedDepositCopyRow[ctAcpOdrDepositAlwc_Deposit] = 0;
                //
				//// 入金引当残 受注 を元に戻す (入金額 + 手数料 + 値引)
				//selectedDepositCopyRow[ctAcpOdrDepoAlwcBlnce_Deposit] = Convert.ToInt64(selectedDepositCopyRow[ctAcpOdrDeposit]) + 
				//														Convert.ToInt64(selectedDepositCopyRow[ctAcpOdrChargeDeposit]) + 
				//														Convert.ToInt64(selectedDepositCopyRow[ctAcpOdrDisDeposit]);
                //
				//// 入金引当額 諸費用 をクリアする
				//selectedDepositCopyRow[ctVarCostDepoAlwc_Deposit] = 0;
                //
				//// 入金引当残 諸費用 を元に戻す (入金額 + 手数料 + 値引)
				//selectedDepositCopyRow[ctVarCostDepoAlwcBlnce_Deposit] = Convert.ToInt64(selectedDepositCopyRow[ctVariousCostDeposit]) + 
				//															Convert.ToInt64(selectedDepositCopyRow[ctVarCostChargeDeposit]) + 
                //															Convert.ToInt64(selectedDepositCopyRow[ctVarCostDisDeposit]);
                #endregion
                // ↑ 20070118 18322 d
			
				// 入金引当額 共通 をクリアする
				selectedDepositCopyRow[ctDepositAllowance_Deposit] = 0;

                // ↓ 20070118 18322 c MA.NS用に変更
                #region SF 入金引当残 共通 を元に戻す（コメントアウト）
				//// 入金引当残 共通 を元に戻す (入金額 + 手数料 + 値引)
				//selectedDepositCopyRow[ctDepositAlwcBlnce_Deposit] = Convert.ToInt64(selectedDepositCopyRow[ctDeposit]) + 
				//														Convert.ToInt64(selectedDepositCopyRow[ctFeeDeposit]) + 
				//														Convert.ToInt64(selectedDepositCopyRow[ctDiscountDeposit]);
                #endregion

				// 入金引当残 共通 を元に戻す (入金額 + 手数料 + 値引＋インセンティブ)
                selectedDepositCopyRow[ctDepositAlwcBlnce_Deposit] = Convert.ToInt64(selectedDepositCopyRow[ctDeposit]) +
                                                                     Convert.ToInt64(selectedDepositCopyRow[ctFeeDeposit]) +
                                                                     Convert.ToInt64(selectedDepositCopyRow[ctDiscountDeposit]);
                //                                                     Convert.ToInt64(selectedDepositCopyRow[ctRebateDeposit]);  // 2007.10.05 hikita del
                // ↑ 20070118 18322 c
			}
			else
			{
				// 引当情報DataRow取得処理
				selectedAllowanceCopyRows = this.GetSelectAllowanceCopyRow(drDeposit);

				// 入金情報DataRow取得処理
				DataRow dr = this.GetSelectDepositCopyRow(drDeposit);

				Int64 iWork = 0;

                // ↓ 20070118 18322 d MA.NS用に変更
                #region SF 受注・諸費用（全てコメントアウト）
                //// 変更前後の差額を求める 入金引当額 受注
				//iWork = (Int64)selectedDepositCopyRow[ctAcpOdrDepositAlwc_Deposit] - (Int64)dr[ctAcpOdrDepositAlwc_Deposit];
                //
				//// 入金引当額 受注 を元に戻す
				//selectedDepositCopyRow[ctAcpOdrDepositAlwc_Deposit] = dr[ctAcpOdrDepositAlwc_Deposit];
                //
				//// 入金引当残 受注 を元に戻す
				//selectedDepositCopyRow[ctAcpOdrDepoAlwcBlnce_Deposit] = (Int64)selectedDepositCopyRow[ctAcpOdrDepoAlwcBlnce_Deposit] + iWork;
                //
				//// 変更前後の差額を求める 入金引当額 諸費用
				//iWork = (Int64)selectedDepositCopyRow[ctVarCostDepoAlwc_Deposit] - (Int64)dr[ctVarCostDepoAlwc_Deposit];
                //
				//// 入金引当額 諸費用 を元に戻す
				//selectedDepositCopyRow[ctVarCostDepoAlwc_Deposit] = dr[ctVarCostDepoAlwc_Deposit];
                //
				//// 入金引当残 諸費用 を元に戻す
                //selectedDepositCopyRow[ctVarCostDepoAlwcBlnce_Deposit] = (Int64)selectedDepositCopyRow[ctVarCostDepoAlwcBlnce_Deposit] + iWork;
                #endregion
                // ↑ 20070118 18322 d

				// 変更前後の差額を求める 入金引当額 共通
				iWork = (Int64)selectedDepositCopyRow[ctDepositAllowance_Deposit] - (Int64)dr[ctDepositAllowance_Deposit];

				// 入金引当額 共通 を元に戻す
				selectedDepositCopyRow[ctDepositAllowance_Deposit] = dr[ctDepositAllowance_Deposit];

				// 入金引当残 共通 を元に戻す
				selectedDepositCopyRow[ctDepositAlwcBlnce_Deposit] = (Int64)selectedDepositCopyRow[ctDepositAlwcBlnce_Deposit] + iWork;
			}
		}
		# endregion

		# region Private Methods

        //----- ADD K2013/03/22 田建委 Redmine#35071 ----->>>>>
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2013/03/18</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●山形部品オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_YamagataCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_YamagataCtrl = (int)Option.OFF;
            }
            #endregion
        }
        //----- ADD K2013/03/22 張曼 Redmine#35063 -----<<<<<

        private void ReadEmployee()
        {
            this._emoloyeeDtlDic = new Dictionary<string, EmployeeDtl>();

            try
            {
                ArrayList retList1;
                ArrayList retList2;

                int status = this._employeeAcs.SearchAll(out retList1, out retList2, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (EmployeeDtl employeeDtl in retList2)
                    {
                        if (employeeDtl.LogicalDeleteCode == 0)
                        {
                            this._emoloyeeDtlDic.Add(employeeDtl.EmployeeCode.Trim(), employeeDtl);
                        }
                    }
                }
            }
            catch
            {
                this._emoloyeeDtlDic = new Dictionary<string, EmployeeDtl>();
            }
        }

        private int GetSubSectionCode(string employeeCode)
        {
            employeeCode = employeeCode.Trim().PadLeft(2, '0');

            if (this._emoloyeeDtlDic.ContainsKey(employeeCode))
            {
                return this._emoloyeeDtlDic[employeeCode].BelongSubSectionCode;
            }

            return 0;
        }

        /// <summary>
        /// 得意先情報/請求金額情報取得処理
        /// </summary>
        /// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
        /// <param name="depositCustomer">入金得意先情報クラス</param>
        /// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 得意先情報と請求金額情報を取得します。
        ///					: エラー時はDepositException例外が発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)
        /// <br>              鑑部の集計期間の終了日をMAXに変更する。</br>
        /// </remarks>
        private int GetCustomDemandInfo1(SearchCustomerParameter searchCustomerParameter, 
                                         out DepositCustomer depositCustomer, 
                                         out DepositCustDmdPrc depositCustDmdPrc, 
                                         out string errMsg)
        {
            // パラメータ初期化
            KingetCustDmdPrcWork kingetCustDmdPrcWork;

            int status;
            errMsg = "";
            depositCustomer = new DepositCustomer();
            depositCustDmdPrc = new DepositCustDmdPrc();

            // --- UPD 2010/12/20 ---------->>>>>
            // 今回売上締処理日取得
            //DateTime currentDay = GetCurrentTotalDayDmdC(searchCustomerParameter.AddUpSecCod, searchCustomerParameter.ClaimCode);
            //if (currentDay == DateTime.MinValue)
            //{
            //    currentDay = TDateTime.LongDateToDateTime(searchCustomerParameter.AddUpADate);
            //}
            DateTime currentDay = DateTime.MaxValue;
            // --- UPD 2010/12/20  ----------<<<<<

            try
            {
                // 請求KINGET処理
                status = this._kingetCustDmdPrcAcs.Read(out kingetCustDmdPrcWork, 
                                                        searchCustomerParameter.EnterpriseCode, 
                                                        searchCustomerParameter.AddUpSecCod, 
                                                        searchCustomerParameter.ClaimCode,
                                                        TDateTime.DateTimeToLongDate(currentDay));
                switch (status)
                {   
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // クラスメンバーコピー処理（KINGET用得意先請求金額ワーク⇒入金得意先情報）
                        this._depositCustomer = this.CopyToDepositCustomerFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);
                        // クラスメンバーコピー処理（KINGET用得意先請求金額ワーク⇒入金得意先請求金額情報）
                        this._depositCustDmdPrc = this.CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        // 前回締次更新年月日
                        this._depositCustomer.CAddUpUpdDate = this._depositCustomer.CAddUpUpdDate;

                        // 入金得意先情報クラス
                        depositCustomer = _depositCustomer;
                        // 入金得意先請求金額情報クラス
                        depositCustDmdPrc = this._depositCustDmdPrc;

                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        this._depositCustomer = new DepositCustomer();
                        this._depositCustDmdPrc = new DepositCustDmdPrc();
                        depositCustomer = this._depositCustomer;
                        depositCustDmdPrc = this._depositCustDmdPrc;

                        return (status);

                    default:

                        errMsg = "請求KINGET情報の取得に失敗しました。";
                        return (status);
                }

                // 売上月次更新履歴取得
                this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchCustomerParameter.AddUpSecCod);

                // 売上締次処理日取得
                this._lastAddUpDay = GetTotalDayDmdC(searchCustomerParameter.AddUpSecCod, searchCustomerParameter.ClaimCode);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 前回売上月次更新日取得
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public DateTime GetHisTotalDayMonthlyAccRec(string sectionCode)
        {
            DateTime lastMonthlyAddUpDay;

            this._totalDayCalculator.ClearCache();
            this._totalDayCalculator.InitializeHisMonthlyAccRec();

            int status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out lastMonthlyAddUpDay);
            if (status != 0)
            {
                lastMonthlyAddUpDay = new DateTime();
            }

            return lastMonthlyAddUpDay;
        }

        /// <summary>
        /// 前回売上締次処理日取得
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="cliamCode"></param>
        /// <returns></returns>
        public DateTime GetTotalDayDmdC(string sectionCode, int cliamCode)
        {
            DateTime lastAddUpDay;

            this._totalDayCalculator.ClearCache();

            int status = this._totalDayCalculator.GetTotalDayDmdC(sectionCode, cliamCode, out lastAddUpDay);
            if (status != 0)
            {
                lastAddUpDay = new DateTime();
            }

            return lastAddUpDay;
        }

        /// <summary>
        /// 今回売上締次処理日取得
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="cliamCode"></param>
        /// <returns></returns>
        public DateTime GetCurrentTotalDayDmdC(string sectionCode, int cliamCode)
        {
            DateTime lastAddUpDay;
            DateTime currentDay;

            this._totalDayCalculator.ClearCache();

            int status = this._totalDayCalculator.GetTotalDayDmdC(sectionCode, cliamCode, out lastAddUpDay, out currentDay);
            if (status != 0)
            {
                currentDay = new DateTime();
            }

            return currentDay;
        }

        /// <summary>
        /// 請求金額情報取得処理
        /// </summary>
        /// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
        /// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 請求金額情報を取得します。
        ///					: エラー時はDepositException例外が発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        private int GetCustomDemandInfo2(SearchCustomerParameter searchCustomerParameter, 
                                         out DepositCustDmdPrc depositCustDmdPrc,
                                         out string errMsg)
        {
            // パラメータ初期化
            KingetCustDmdPrcWork kingetCustDmdPrcWork;

            int status;
            errMsg = "";
            depositCustDmdPrc = new DepositCustDmdPrc();

            try
            {
                // 請求KINGET処理
                status = this._kingetCustDmdPrcAcs.Read(out kingetCustDmdPrcWork, 
                                                        searchCustomerParameter.EnterpriseCode, 
                                                        searchCustomerParameter.AddUpSecCod, 
                                                        searchCustomerParameter.CustomerCode, 
                                                        searchCustomerParameter.AddUpADate);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // クラスメンバーコピー処理（KINGET用得意先請求金額ワーククラス⇒入金得意先請求金額情報クラス）
                       this. _depositCustDmdPrc = this.CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        depositCustDmdPrc = this._depositCustDmdPrc;

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        this._depositCustDmdPrc = null;
                        depositCustDmdPrc = this._depositCustDmdPrc;

                        break;
                    default:
                        errMsg = "請求金額情報の取得に失敗しました。";
                        break;
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 得意先情報/請求金額情報取得処理
		/// </summary>
		/// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
		/// <param name="depositCustomer">入金得意先情報クラス</param>
		/// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 得意先情報と請求金額情報を取得します。
		///					: エラー時はDepositException例外が発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private int GetCustomDemandInfo1(SearchCustomerParameter searchCustomerParameter, out DepositCustomer depositCustomer, out DepositCustDmdPrc depositCustDmdPrc)
		{
			// パラメータ初期化
			KingetCustDmdPrcWork kingetCustDmdPrcWork;

            int st;
            depositCustomer = new DepositCustomer();
            depositCustDmdPrc = new DepositCustDmdPrc();

            try
            {
                // 請求KINGET処理
                st = this._kingetCustDmdPrcAcs.Read(
                    out kingetCustDmdPrcWork, searchCustomerParameter.EnterpriseCode,
                    searchCustomerParameter.AddUpSecCod, searchCustomerParameter.CustomerCode, searchCustomerParameter.AddUpADate);

                switch (st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // クラスメンバーコピー処理（KINGET用得意先請求金額ワーククラス⇒入金得意先情報クラス）
                        _depositCustomer = this.CopyToDepositCustomerFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        // クラスメンバーコピー処理（KINGET用得意先請求金額ワーククラス⇒入金得意先請求金額情報クラス）
                        _depositCustDmdPrc = this.CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        // ↓ 20070518 18322 c 
                        // 前回締次更新年月日取得処理
                        //int cAddUpUpDate;
                        //this.GetCAddUpHisInfo(searchCustomerParameter.EnterpriseCode, kingetCustDmdPrcWork.TotalDay, out cAddUpUpDate);
                        //
                        //_depositCustomer.CAddUpUpdDate = cAddUpUpDate;

                        _depositCustomer.CAddUpUpdDate = _depositCustomer.CAddUpUpdDate;
                        // ↑ 20070518 18322 c

                        depositCustomer = _depositCustomer;
                        depositCustDmdPrc = _depositCustDmdPrc;

                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        _depositCustomer = null;
                        _depositCustDmdPrc = null;
                        depositCustomer = _depositCustomer;
                        depositCustDmdPrc = _depositCustDmdPrc;

                        break;

                    default:

                        throw new DepositException("得意先情報の取得に失敗しました。", st);
                }

                // ↓ 20070801 18322 a
                if (this._lastMonthlyAddUpHis == null)
                {
                    // 最終月次締め日を取得
                    MonthlyAddUpHisWork monthlyAddUpHisWork = new MonthlyAddUpHisWork();
                    monthlyAddUpHisWork.EnterpriseCode = searchCustomerParameter.EnterpriseCode;
                    monthlyAddUpHisWork.AddUpSecCode = searchCustomerParameter.AddUpSecCod;

                    string retMsg;
                    object retObj = monthlyAddUpHisWork;
                    int status = this._iMonthlyAddUpDB.ReadHis(ref retObj, out retMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        return status;
                    }

                    this._lastMonthlyAddUpHis = retObj as MonthlyAddUpHisWork;
                    if (this._lastMonthlyAddUpHis == null)
                    {
                        // 取得失敗
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                // ↑ 20070801 18322 a
            }
            catch
            {
                st = -1;
            }

			return st;
		}

		/// <summary>
		/// 請求金額情報取得処理
		/// </summary>
		/// <param name="searchCustomerParameter">得意先情報/得意先金額情報取得用パラメータ クラス</param>
		/// <param name="depositCustDmdPrc">入金得意先請求金額情報クラス</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 請求金額情報を取得します。
		///					: エラー時はDepositException例外が発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private int GetCustomDemandInfo2(SearchCustomerParameter searchCustomerParameter, out DepositCustDmdPrc depositCustDmdPrc)
		{
			// パラメータ初期化
			KingetCustDmdPrcWork kingetCustDmdPrcWork;

            int st;
            depositCustDmdPrc = new DepositCustDmdPrc();

            try
            {
                // 請求KINGET処理
                st = this._kingetCustDmdPrcAcs.Read(
                    out kingetCustDmdPrcWork, searchCustomerParameter.EnterpriseCode,
                    searchCustomerParameter.AddUpSecCod, searchCustomerParameter.CustomerCode, searchCustomerParameter.AddUpADate);

                switch (st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // クラスメンバーコピー処理（KINGET用得意先請求金額ワーククラス⇒入金得意先請求金額情報クラス）
                        _depositCustDmdPrc = this.CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        depositCustDmdPrc = _depositCustDmdPrc;

                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        _depositCustDmdPrc = null;
                        depositCustDmdPrc = _depositCustDmdPrc;

                        break;

                    default:

                        throw new DepositException("請求金額情報の取得に失敗しました。", st);
                }
            }
            catch
            {
                st = -1;
            }

			return st;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        // ↓ 20070518 18322 d 使用しないので削除
		#region 前回締次更新年月日取得処理（使用しないので削除）
		///// <summary>
		///// 前回締次更新年月日取得処理
		///// </summary>
		///// <param name="enterpriseCode">企業コード</param>
		///// <param name="totalDay">締日</param>
		///// <param name="cAddUpUpDate">締次更新年月日</param>
		///// <returns>ConstantManagement.DB_Status</returns>
		///// <remarks>
		///// <br>Note　　　  : 指定する締日に対する締次更新年月日を取得します。</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private int GetCAddUpHisInfo(string enterpriseCode, int totalDay, out int cAddUpUpDate)
		//{
		//	CAddUpHis[] cAddUpHis;
		//
		//	// 締次更新履歴取得処理
		//	int st = this._cAddUpHisAcs.SearchLastCAddUpHis(out cAddUpHis, enterpriseCode, totalDay, 0);
		//
		//	switch (st)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
		//			
		//			// 締次更新年月日取得
		//			cAddUpUpDate = TDateTime.DateTimeToLongDate(cAddUpHis[0].CAddUpUpdDate);
		//
		//			break;
		//
		//		case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
		//			
		//			// 締次更新年月日取得
		//			cAddUpUpDate = 0;
		//
		//			break;
		//
		//		default :
		//		
		//			throw new DepositException("締次更新履歴の取得に失敗しました。", st);
		//	}
		//
		//	return st;
		//}
		#endregion
        // ↑ 20070518 18322 d

		/// <summary>
		/// 入金情報/引当情報取得処理
		/// </summary>
		/// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金情報と引当情報をデータセットに取得します。
		///					: エラー時はDepositException例外が発生します。
		///					:   ※ Method : GetDsDepositInfo より結果取得</br>
		/// <br>Programmer  : 30414 忍 幸史</br>
		/// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2012/12/24 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
		/// </remarks>
        private int GetDepositAlwInfo(SearchDepositParameter searchDepositParameter, 
                                      out int customerCode, 
                                      out int claimCode,
                                      out string errMsg)
		{
            int status;
			errMsg = "";
            customerCode = 0;
            claimCode = 0;

			ArrayList arrDepsitMain;
			ArrayList arrDepositAlw;

			SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
			searchParaDepositRead.EnterpriseCode			= searchDepositParameter.EnterpriseCode;			// 企業コード
			searchParaDepositRead.AddUpSecCode				= searchDepositParameter.AddUpSecCode;				// 計上拠点
            searchParaDepositRead.ClaimCode                 = searchDepositParameter.ClaimCode;                 // 請求先コード
			searchParaDepositRead.CustomerCode				= searchDepositParameter.CustomerCode;				// 得意先コード
			searchParaDepositRead.DepositSlipNo				= searchDepositParameter.DepositSlipNo;				// 入金伝票番号
            searchParaDepositRead.AcptAnOdrStatus = searchDepositParameter.AcptAnOdrStatus;                     // 受注ステータス
            searchParaDepositRead.SalesSlipNum = searchDepositParameter.SalesSlipNum;                           // 売上伝票番号
            // 自動入金区分(0:通常入金のみ呼び出し
            //              1:自動入金は売上入力等で作成される為、入金入力では変更できない。)
            searchParaDepositRead.AutoDepositCd = -1;
			if (searchDepositParameter.DepositCallMonthsStart == 0)
			{
				// 入金日 開始
				searchParaDepositRead.DepositCallMonthsStart = TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
                // 入金日 開始
				searchParaDepositRead.DepositCallMonthsStart = searchDepositParameter.DepositCallMonthsStart;
			}
			if (searchDepositParameter.DepositCallMonthsEnd == 0)
			{
				// 入金日 終了
				searchParaDepositRead.DepositCallMonthsEnd = TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
                // 入金日 終了
				searchParaDepositRead.DepositCallMonthsEnd = searchDepositParameter.DepositCallMonthsEnd;
			}
			searchParaDepositRead.AlwcDepositCall			= searchDepositParameter.AlwcDepositCall;			// 引当済入金伝票呼出区分

            try
            {
                // 入金情報/引当情報取得処理
                status = this._searchDepsitAcs.SearchDB(searchParaDepositRead, out arrDepsitMain, out arrDepositAlw, out errMsg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // ----- ADD 王君 2012/12/24 Redmine#33741 ------- >>>>>
                        if (arrDepsitMain.Count != 0 && searchParaDepositRead.ClaimCode == 0)
                        {
                            searchParaDepositRead.ClaimCode = (arrDepsitMain[0] as SearchDepsitMain).ClaimCode;
                        }
                        // ----- ADD 王君 2012/12/24 Redmine#33741 ------- <<<<<
                        // 売上月次更新履歴取得
                        this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchParaDepositRead.AddUpSecCode);

                        // 売上締次処理日取得
                        this._lastAddUpDay = GetTotalDayDmdC(searchParaDepositRead.AddUpSecCode, searchParaDepositRead.ClaimCode);

                        // 入金情報/引当情報 保持用データクラス登録処理
                        SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        // 入金情報/引当情報データセット登録処理
                        SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode, out claimCode);

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "入金情報・引当情報の取得に失敗しました。";
                        break;
                }
            }
            catch
            {
                status = -1;
            }

			return (status);
        }

        // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
        /// <summary>
        /// 入金Guid情報/引当情報取得処理
        /// </summary>
        /// <param name="searchDepositParameter">入金Guid情報/引当情報取得用パラメータ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金情報と引当情報をデータセットに取得します。
        ///					: エラー時はDepositException例外が発生します。
        ///					:   ※ Method : GetDsDepositInfo より結果取得</br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private int GetDepositGuidInfo(SearchDepositParameter searchDepositParameter,
                                      out int customerCode,
                                      out int claimCode,
                                      out string errMsg)
        {
            int status;
            errMsg = "";
            customerCode = 0;
            claimCode = 0;

            ArrayList arrDepsitMain;
            ArrayList arrDepositAlw;

            SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
            searchParaDepositRead.EnterpriseCode = searchDepositParameter.EnterpriseCode;			// 企業コード
            searchParaDepositRead.AddUpSecCode = searchDepositParameter.AddUpSecCode;				// 拠点
            searchParaDepositRead.ClaimCode = searchDepositParameter.CustomerCode;                     // 請求先コード
            searchParaDepositRead.CustomerCode = searchDepositParameter.CustomerCode;				// 得意先コード
            searchParaDepositRead.AcptAnOdrStatus = searchDepositParameter.AcptAnOdrStatus;         // 受注ステータス
            searchParaDepositRead.AlwcDepositCall = searchDepositParameter.AlwcDepositCall;			// 引当済入金伝票呼出区分

            // 自動入金区分(0:通常入金のみ呼び出し
            //              1:自動入金は売上入力等で作成される為、入金入力では変更できない。)
            searchParaDepositRead.AutoDepositCd = -1;

            // 売上月次更新履歴取得
            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchParaDepositRead.AddUpSecCode);

            // 売上締次処理日取得
            this._lastAddUpDay = GetTotalDayDmdC(searchParaDepositRead.AddUpSecCode, searchParaDepositRead.ClaimCode);

            int dateUpDay = TDateTime.DateTimeToLongDate(this._lastAddUpDay.AddDays(1));

            int dateMonth = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay.AddDays(1));

            if (searchDepositParameter.CustomerCode == 0)
            {
                searchParaDepositRead.DepositCallMonthsStart = dateMonth;
            }
            else
            {
                if (dateUpDay > dateMonth)
                {
                    searchParaDepositRead.DepositCallMonthsStart = dateUpDay;
                }
                else
                {
                    searchParaDepositRead.DepositCallMonthsStart = dateMonth;
                }
            }

            try
            {
                // 入金情報/引当情報取得処理
                status = this._searchDepsitAcs.SearchDB(searchParaDepositRead, out arrDepsitMain, out arrDepositAlw, out errMsg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // 入金情報/引当情報 保持用データクラス登録処理
                        SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        // 入金情報データセット登録処理
                        SetDsDepositGuidInfo(arrDepsitMain, arrDepositAlw, out customerCode, out claimCode);

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "入金情報・引当情報の取得に失敗しました。";
                        break;
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入金情報/引当情報取得処理
        /// </summary>
        /// <param name="searchDepositParameter">入金情報/引当情報取得用パラメータ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金情報と引当情報をデータセットに取得します。
        ///					: エラー時はDepositException例外が発生します。
        ///					:   ※ Method : GetDsDepositInfo より結果取得</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private int GetDepositAlwInfo(SearchDepositParameter searchDepositParameter, out int customerCode, out int claimCode)
        {
            int st;
            string errMsg;

            customerCode = 0;
            claimCode = 0;

            ArrayList arrDepsitMain;
            ArrayList arrDepositAlw;
            // ↓ 20070125 18322 c MA.NS用に変更
            #region SF （全てコメントアウト）
            //SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
            //searchParaDepositRead.EnterpriseCode			= searchDepositParameter.EnterpriseCode;			// 企業コード
            //searchParaDepositRead.AddUpSecCode				= searchDepositParameter.AddUpSecCod;				// 計上拠点
            //searchParaDepositRead.CustomerCode				= searchDepositParameter.CustomerCode;				// 得意先コード
            //searchParaDepositRead.DepositSlipNo				= searchDepositParameter.DepositSlipNo;				// 入金伝票番号
            //
            //searchParaDepositRead.AcceptAnOrderNo			= searchDepositParameter.AcceptAnOrderNo;			// 受注番号
            //if (searchDepositParameter.DepositDateStart == 0)
            //{
            //	searchParaDepositRead.DepositCallMonthsStart	= DateTime.MinValue;							// 入金日 開始
            //}
            //else
            //{
            //	searchParaDepositRead.DepositCallMonthsStart	= 
            //		TDateTime.LongDateToDateTime(searchDepositParameter.DepositDateStart);						// 入金日 開始
            //}
            //if (searchDepositParameter.DepositDateEnd == 0)
            //{
            //	searchParaDepositRead.DepositCallMonthsEnd		= DateTime.MaxValue;							// 入金日 終了
            //}
            //else
            //{
            //	searchParaDepositRead.DepositCallMonthsEnd		= 
            //		TDateTime.LongDateToDateTime(searchDepositParameter.DepositDateEnd);						// 入金日 終了
            //}
            #endregion

            SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
            searchParaDepositRead.EnterpriseCode = searchDepositParameter.EnterpriseCode;			// 企業コード
            searchParaDepositRead.AddUpSecCode = searchDepositParameter.AddUpSecCode;				// 計上拠点
            searchParaDepositRead.ClaimCode = searchDepositParameter.ClaimCode;                 // 請求先コード
            searchParaDepositRead.CustomerCode = searchDepositParameter.CustomerCode;				// 得意先コード
            searchParaDepositRead.DepositSlipNo = searchDepositParameter.DepositSlipNo;				// 入金伝票番号

            // 受注番号
            // searchParaDepositRead.AcceptAnOrderNo = searchDepositParameter.AcceptAnOrderNo;   // 2007.10.05 del

            // 受注ステータス
            searchParaDepositRead.AcptAnOdrStatus = searchDepositParameter.AcptAnOdrStatus;      // 2007.10.05 add

            // 売上伝票番号
            searchParaDepositRead.SalesSlipNum = searchDepositParameter.SalesSlipNum;            // 2007.10.05 add

            // SFUKK01406U.SetSalesParameter()も参照して下さい。

            // 自動入金区分(0:通常入金のみ呼び出し
            //              1:自動入金は売上入力等で作成される為、入金入力では変更できない。)
            searchParaDepositRead.AutoDepositCd = -1;

            // サービス伝票区分(0:OFFのみ呼び出し、
            //                  1:ONは入金入力では作成できない為、呼び出し不可)
            // searchParaDepositRead.ServiceSlipCd = 0;   // 2007.10.05 hikita del

            if (searchDepositParameter.DepositCallMonthsStart == 0)
            {
                // 入金日 開始
                searchParaDepositRead.DepositCallMonthsStart = TDateTime.DateTimeToLongDate(DateTime.MinValue);
            }
            else
            {
                // 入金日 開始
                searchParaDepositRead.DepositCallMonthsStart = searchDepositParameter.DepositCallMonthsStart;
            }
            if (searchDepositParameter.DepositCallMonthsEnd == 0)
            {
                // 入金日 終了
                searchParaDepositRead.DepositCallMonthsEnd = TDateTime.DateTimeToLongDate(DateTime.MaxValue);
            }
            else
            {
                // 入金日 終了
                searchParaDepositRead.DepositCallMonthsEnd = searchDepositParameter.DepositCallMonthsEnd;
            }
            // ↑ 20070125 18322 c

            searchParaDepositRead.AlwcDepositCall = searchDepositParameter.AlwcDepositCall;			// 引当済入金伝票呼出区分

            try
            {
                // 入金情報/引当情報取得処理
                st = _searchDepsitAcs.SearchDB(searchParaDepositRead, out arrDepsitMain, out arrDepositAlw, out errMsg);

                switch (st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // 入金情報/引当情報 保持用データクラス登録処理
                        this.SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        // 入金情報/引当情報データセット登録処理
                        int customerCode1 = 0;
                        int claimCode1 = 0;

                        this.SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode1, out claimCode1);

                        customerCode = customerCode1;
                        claimCode = claimCode1;
                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        customerCode = 0;
                        claimCode = 0;

                        break;

                    default:

                        throw new DepositException(errMsg, st);
                }
            }
            catch
            {
                st = -1;
            }

            return st;
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        // ↓ 20070122 18322 c MA.NS用に変更
        #region SF 請求売上情報取得処理（全てコメントアウト）
		///// <summary>
		///// 請求売上情報取得処理
		///// </summary>
		///// <param name="searchSalesParameter">請求売上情報取得用パラメータ</param>
		///// <returns>ConstantManagement.DB_Status</returns>
		///// <remarks>
		///// <br>Note　　　  : 請求売上情報をデータセットに取得します。
		/////					: エラー時はDepositException例外が発生します。</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private int GetDmdSalesInfo(SearchSalesParameter searchSalesParameter)
		//{
		//	string errMsg;
		//	
		//	ArrayList arrDmdSales;
		//	SearchParaDmdSalesRead searchParaDmdSalesRead = new SearchParaDmdSalesRead();
		//	searchParaDmdSalesRead.EnterpriseCode	= searchSalesParameter.EnterpriseCode;			// 企業コード
		//	searchParaDmdSalesRead.AddUpSecCode		= searchSalesParameter.AddUpSecCod;				// 計上拠点
		//	searchParaDmdSalesRead.ClaimCode		= searchSalesParameter.CustomerCode;			// 請求先コード
		//	searchParaDmdSalesRead.AcceptAnOrderNo	= searchSalesParameter.AcceptAnOrderNo;			// 受注伝票番号
		//	searchParaDmdSalesRead.SlipNo			= searchSalesParameter.SlipNo;					// 伝票番号
		//	if (searchSalesParameter.SearchSlipDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateStart	= DateTime.MinValue;					// 伝票日付 開始
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.SearchSlipDateStart);			// 伝票日付 開始
		//	}
		//	if (searchSalesParameter.SearchSlipDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateEnd	= DateTime.MaxValue;					// 伝票日付 終了
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.SearchSlipDateEnd);			// 伝票日付 終了
		//	}
		//	if (searchSalesParameter.AddUpADateStart == 0)
		//	{
		//		searchParaDmdSalesRead.AddUpADateStart	= DateTime.MinValue;						// 売上日 開始
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AddUpADateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AddUpADateStart);				// 売上日 開始
		//	}
		//	if (searchSalesParameter.AddUpADateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.AddUpADateEnd	= DateTime.MaxValue;						// 売上日 終了
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AddUpADateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AddUpADateEnd);				// 売上日 終了
		//	}
		//	searchParaDmdSalesRead.AlwcDmdSalesCall	= searchSalesParameter.AlwcDmdSalesCall;		// 引当済請求売上伝票呼出区分
		//	searchParaDmdSalesRead.AcptAnOdrStatus	= searchSalesParameter.AcptAnOdrStatus;			// 受注ステータス
		//	searchParaDmdSalesRead.DataInputSystem	= searchSalesParameter.DataInputSystem;			// データ入力システム
        //
		//	searchParaDmdSalesRead.AutoAuctionDiv	= searchSalesParameter.AutoAuctionDiv;			// AA抽出区分
		//	searchParaDmdSalesRead.CreditOrLoanCd	= searchSalesParameter.CreditOrLoanCd;			// クレジット・ローン区分
		//	searchParaDmdSalesRead.CreditCompanyCode	= searchSalesParameter.CreditCompanyCode;	// クレジット会社コード
		//	searchParaDmdSalesRead.SalesEmployeeCd	= searchSalesParameter.SalesEmployeeCd;			// 販売従業員コード
		//	if (searchSalesParameter.AcceptAnOrderDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateStart	= DateTime.MinValue;				// 受注日 開始
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AcceptAnOrderDateStart);		// 受注日 開始
		//	}
		//	if (searchSalesParameter.AcceptAnOrderDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateEnd	= DateTime.MaxValue;					// 受注日 終了
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AcceptAnOrderDateEnd);		// 受注日 終了
		//	}
		//	if (searchSalesParameter.CarDeliExpectedDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateStart	= DateTime.MinValue;				// 納車予定日 開始
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.CarDeliExpectedDateStart);	// 納車予定日 開始
		//	}
		//	if (searchSalesParameter.CarDeliExpectedDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateEnd	= DateTime.MaxValue;				// 納車予定日 終了
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.CarDeliExpectedDateEnd);		// 納車予定日 終了
		//	}
        //
		//	// --- 請求売上情報取得処理 --- //
		//	int st = _searchDmdSalesAcs.SearchDB(searchParaDmdSalesRead, out arrDmdSales, out errMsg);
		//	
		//	switch (st)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
        //
		//			// 請求売上 保持用データクラス追加処理
		//			this.InsertDmdSalesSaveClass(arrDmdSales);
        //
		//			// 請求売上情報データセット登録処理
		//			this.SetDsDmdSalesInfo(arrDmdSales);
        //
		//			break;
        //
		//		case (int)ConstantManagement.DB_Status.ctDB_EOF :
        //
		//			break;
        //
		//		default :
        //
		//			throw new DepositException(errMsg, st);
		//	}
        //
		//	return st;
		//}

        ///// <summary>
		///// 請求売上情報取得処理
		///// </summary>
		///// <param name="searchSalesParameter">請求売上情報取得用パラメータ</param>
		///// <param name="searchDmdSalesList">取得請求売上データ</param>
		///// <returns>ConstantManagement.DB_Status</returns>
		///// <remarks>
		///// <br>Note　　　  : 請求売上情報をデータセットに取得します。
		/////					: エラー時はDepositException例外が発生します。</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private int GetDmdSalesInfo(SearchSalesParameter searchSalesParameter, out SearchDmdSales[] searchDmdSalesList)
		//{
		//	string errMsg;
		//	searchDmdSalesList = null;
		//	
		//	ArrayList arrDmdSales;
		//	SearchParaDmdSalesRead searchParaDmdSalesRead = new SearchParaDmdSalesRead();
		//	searchParaDmdSalesRead.EnterpriseCode	= searchSalesParameter.EnterpriseCode;			// 企業コード
		//	searchParaDmdSalesRead.AddUpSecCode		= searchSalesParameter.AddUpSecCod;				// 計上拠点
		//	searchParaDmdSalesRead.ClaimCode		= searchSalesParameter.CustomerCode;			// 請求先コード
		//	searchParaDmdSalesRead.AcceptAnOrderNo	= searchSalesParameter.AcceptAnOrderNo;			// 受注伝票番号
		//	searchParaDmdSalesRead.SlipNo			= searchSalesParameter.SlipNo;					// 伝票番号
		//	if (searchSalesParameter.SearchSlipDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateStart	= DateTime.MinValue;					// 伝票日付 開始
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.SearchSlipDateStart);			// 伝票日付 開始
		//	}
		//	if (searchSalesParameter.SearchSlipDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateEnd	= DateTime.MaxValue;					// 伝票日付 終了
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.SearchSlipDateEnd);			// 伝票日付 終了
		//	}
		//	if (searchSalesParameter.AddUpADateStart == 0)
		//	{
		//		searchParaDmdSalesRead.AddUpADateStart	= DateTime.MinValue;						// 売上日 開始
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AddUpADateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AddUpADateStart);				// 売上日 開始
		//	}
		//	if (searchSalesParameter.AddUpADateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.AddUpADateEnd	= DateTime.MaxValue;						// 売上日 終了
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AddUpADateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AddUpADateEnd);				// 売上日 終了
		//	}
		//	searchParaDmdSalesRead.AlwcDmdSalesCall	= searchSalesParameter.AlwcDmdSalesCall;		// 引当済請求売上伝票呼出区分
		//	searchParaDmdSalesRead.AcptAnOdrStatus	= searchSalesParameter.AcptAnOdrStatus;			// 受注ステータス
		//	searchParaDmdSalesRead.DataInputSystem	= searchSalesParameter.DataInputSystem;			// データ入力システム
        //
		//	searchParaDmdSalesRead.AutoAuctionDiv	= searchSalesParameter.AutoAuctionDiv;			// AA抽出区分
		//	searchParaDmdSalesRead.CreditOrLoanCd	= searchSalesParameter.CreditOrLoanCd;			// クレジット・ローン区分
		//	searchParaDmdSalesRead.CreditCompanyCode	= searchSalesParameter.CreditCompanyCode;	// クレジット会社コード
		//	searchParaDmdSalesRead.SalesEmployeeCd	= searchSalesParameter.SalesEmployeeCd;			// 販売従業員コード
		//	if (searchSalesParameter.AcceptAnOrderDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateStart	= DateTime.MinValue;				// 受注日 開始
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AcceptAnOrderDateStart);		// 受注日 開始
		//	}
		//	if (searchSalesParameter.AcceptAnOrderDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateEnd	= DateTime.MaxValue;					// 受注日 終了
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AcceptAnOrderDateEnd);		// 受注日 終了
		//	}
		//	if (searchSalesParameter.CarDeliExpectedDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateStart	= DateTime.MinValue;				// 納車予定日 開始
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.CarDeliExpectedDateStart);	// 納車予定日 開始
		//	}
		//	if (searchSalesParameter.CarDeliExpectedDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateEnd	= DateTime.MaxValue;				// 納車予定日 終了
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.CarDeliExpectedDateEnd);		// 納車予定日 終了
		//	}
        //
		//	// --- 請求売上情報取得処理 --- //
		//	int st = _searchDmdSalesAcs.SearchDB(searchParaDmdSalesRead, out arrDmdSales, out errMsg);
		//	
		//	switch (st)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
        //
		//			// 請求売上 保持用データクラス追加処理
		//			this.InsertDmdSalesSecondSaveClass(arrDmdSales);
        //
		//			// 取得請求売上データをコレクションに保存
		//			searchDmdSalesList = (SearchDmdSales[])arrDmdSales.ToArray(typeof(SearchDmdSales));
        //
		//			break;
        //
		//		case (int)ConstantManagement.DB_Status.ctDB_EOF :
        //
		//			break;
        //
		//		default :
        //
		//			throw new DepositException(errMsg, st);
		//	}
        //
		//	return st;
        //}
        #endregion

		/// <summary>
		/// 請求売上情報取得処理
		/// </summary>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報をデータセットに取得します。
		///					: エラー時はDepositException例外が発生します。</br>
		/// <br>Programmer  : 30414 忍 幸史</br>
		/// <br>Date        : 2008/06/26</br>
		/// </remarks>
		private int GetClaimSalesInfo(SearchSalesParameter searchSalesParameter, out string errMsg)
		{
			errMsg = "";
			
			ArrayList arrClaimSales;

            // 請求売上情報取得用パラメータを請求売上データ検索用パラメータに変換
            SearchParaClaimSalesRead searchParaClaimSalesRead =
                  CopyToSearchParaClaimSalesReadFromSalesParameter(searchSalesParameter);

			// --- 請求売上情報取得処理 --- //
			int status = this._searchClaimSalesAcs.SearchDB(searchParaClaimSalesRead, 
                                                            out arrClaimSales, 
                                                            out errMsg);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL :

                    // 売上月次更新履歴取得
                    this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchParaClaimSalesRead.DemandAddUpSecCd);

                    // 売上締次処理日取得
                    this._lastAddUpDay = GetTotalDayDmdC(searchParaClaimSalesRead.DemandAddUpSecCd, searchParaClaimSalesRead.ClaimCode);

					// 請求売上 保持用データクラス追加処理
					this.InsertDmdSalesSaveClass(arrClaimSales);

					// 請求売上情報データセット登録処理
					this.SetDsDmdSalesInfo(arrClaimSales);

					break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
					break;
				default :
                    errMsg = "請求売上情報の取得に失敗しました。";
                    break;
			}

			return (status);
        }

        /// <summary>
        /// 請求売上情報取得処理
        /// </summary>
        /// <param name="searchSalesParameter">請求売上情報取得用パラメータ</param>
        /// <param name="searchClaimSalesList">取得請求売上データ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 請求売上情報をデータセットに取得します。
        ///					: エラー時はDepositException例外が発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        private int GetClaimSalesInfo(SearchSalesParameter searchSalesParameter, 
                                      out SearchClaimSales[] searchClaimSalesList,
                                      out string errMsg)
        {
            errMsg = "";
            searchClaimSalesList = null;

            ArrayList arrClaimSales;

            // 請求売上情報取得用パラメータを請求売上データ検索用パラメータに変換
            SearchParaClaimSalesRead searchParaClaimSalesRead =
                  CopyToSearchParaClaimSalesReadFromSalesParameter(searchSalesParameter);

            // --- 請求売上情報取得処理 --- //
            int status = this._searchClaimSalesAcs.SearchDB(searchParaClaimSalesRead, out arrClaimSales, out errMsg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    // 請求売上 保持用データクラス追加処理
                    this.InsertDmdSalesSecondSaveClass(arrClaimSales);

                    // 取得請求売上データをコレクションに保存
                    searchClaimSalesList = (SearchClaimSales[])arrClaimSales.ToArray(typeof(SearchClaimSales));

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    errMsg = "請求売上情報の取得に失敗しました。";
                    break;
            }

            return (status);
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 請求売上情報取得処理
        /// </summary>
        /// <param name="searchSalesParameter">請求売上情報取得用パラメータ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 請求売上情報をデータセットに取得します。
        ///					: エラー時はDepositException例外が発生します。</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private int GetClaimSalesInfo(SearchSalesParameter searchSalesParameter)
        {
            string errMsg;

            ArrayList arrClaimSales;

            // 請求売上情報取得用パラメータを請求売上データ検索用パラメータに変換
            SearchParaClaimSalesRead searchParaClaimSalesRead =
                  CopyToSearchParaClaimSalesReadFromSalesParameter(searchSalesParameter);

            // --- 請求売上情報取得処理 --- //
            int st = _searchClaimSalesAcs.SearchDB(searchParaClaimSalesRead
                                                  , out arrClaimSales
                                                  , out errMsg
                                                  );

            switch (st)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    // 請求売上 保持用データクラス追加処理
                    this.InsertDmdSalesSaveClass(arrClaimSales);

                    // 請求売上情報データセット登録処理
                    this.SetDsDmdSalesInfo(arrClaimSales);

                    break;

                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:

                    break;

                default:

                    throw new DepositException(errMsg, st);
            }

            return st;
        }

        /// <summary>
		/// 請求売上情報取得処理
		/// </summary>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ</param>
		/// <param name="searchClaimSalesList">取得請求売上データ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報をデータセットに取得します。
		///					: エラー時はDepositException例外が発生します。</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.22</br>
		/// </remarks>
		private int GetClaimSalesInfo(SearchSalesParameter searchSalesParameter, out SearchClaimSales[] searchClaimSalesList)
		{
			string errMsg;
			searchClaimSalesList = null;
			
			ArrayList arrClaimSales;

            // 請求売上情報取得用パラメータを請求売上データ検索用パラメータに変換
            SearchParaClaimSalesRead searchParaClaimSalesRead =
                  CopyToSearchParaClaimSalesReadFromSalesParameter(searchSalesParameter);

			// --- 請求売上情報取得処理 --- //
			int st = _searchClaimSalesAcs.SearchDB(searchParaClaimSalesRead, out arrClaimSales, out errMsg);
			
			switch (st)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL :

					// 請求売上 保持用データクラス追加処理
					this.InsertDmdSalesSecondSaveClass(arrClaimSales);

					// 取得請求売上データをコレクションに保存
					searchClaimSalesList = (SearchClaimSales[])arrClaimSales.ToArray(typeof(SearchClaimSales));

					break;

				case (int)ConstantManagement.DB_Status.ctDB_EOF :

					break;

				default :

					throw new DepositException(errMsg, st);
			}

			return st;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
		///   請求売上情報検索用パラメータ変換処理
		/// </summary>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ</param>
		/// <returns>SearchParaClaimSalesRead</returns>
		/// <remarks>
		/// <br>Note　　　  : 画面で入力されたパラメータを請求売上データ検索パラメータに変換します。</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.22</br>
		/// </remarks>
		private SearchParaClaimSalesRead CopyToSearchParaClaimSalesReadFromSalesParameter(SearchSalesParameter searchSalesParameter)
		{
			SearchParaClaimSalesRead searchParaClaimSalesRead = new SearchParaClaimSalesRead();

            // 企業コード
			searchParaClaimSalesRead.EnterpriseCode   = searchSalesParameter.EnterpriseCode;
            // 受注ステータス
            searchParaClaimSalesRead.AcptAnOdrStatus  = searchSalesParameter.AcptAnOdrStatus;
            // 売上伝票番号
            searchParaClaimSalesRead.SalesSlipNum     = searchSalesParameter.SalesSlipNum;
            // 得意先コード
            searchParaClaimSalesRead.CustomerCode = searchSalesParameter.CustomerCode;
            // 請求先コード
            searchParaClaimSalesRead.ClaimCode        = searchSalesParameter.ClaimCode;
            // 計上日
			if (searchSalesParameter.AddUpADateStart == 0)
			{
				// 計上日 開始
				searchParaClaimSalesRead.AddUpADateStart = TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
				// 計上日 開始
				searchParaClaimSalesRead.AddUpADateStart = searchSalesParameter.AddUpADateStart;
			}

			if (searchSalesParameter.AddUpADateEnd == 0)
			{
				// 計上日 終了
				searchParaClaimSalesRead.AddUpADateEnd = TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
				// 計上日 終了
				searchParaClaimSalesRead.AddUpADateEnd = searchSalesParameter.AddUpADateEnd;
			}

			// 請求計上拠点
			searchParaClaimSalesRead.DemandAddUpSecCd = searchSalesParameter.DemandAddUpSecCd;

            // 実績計上拠点
			searchParaClaimSalesRead.ResultsAddUpSecCd = searchSalesParameter.ResultsAddUpSecCd;

    		// 引当済請求売上伝票呼出区分
            searchParaClaimSalesRead.AlwcSalesSlipCall	= searchSalesParameter.AlwcSalesSlipCall;
			
            // 販売従業員コード
			searchParaClaimSalesRead.SalesEmployeeCd	= searchSalesParameter.SalesEmployeeCd;

            // 伝票検索日付
            if (searchSalesParameter.SearchSlipDateStart == 0)
			{
                // 伝票日付 開始
				searchParaClaimSalesRead.SearchSlipDateStart = TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
			    // 伝票日付 開始
				searchParaClaimSalesRead.SearchSlipDateStart = searchSalesParameter.SearchSlipDateStart;
			}

			if (searchSalesParameter.SearchSlipDateEnd == 0)
			{
				// 伝票日付 終了
				searchParaClaimSalesRead.SearchSlipDateEnd	= TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
			    // 伝票日付 終了
				searchParaClaimSalesRead.SearchSlipDateEnd	= searchSalesParameter.SearchSlipDateEnd;
			}
			
            // ↓ 20070525 18322 a
            // 売掛区分を条件に含めない
            searchParaClaimSalesRead.AccRecDivCd = -1;

            // 自動入金を条件に含めない
            searchParaClaimSalesRead.AutoDepositCd = -1;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // サービス伝票区分(0:OFFのみ呼び出し、
            //                  1:ONは入金入力では作成できない為、呼び出し不可)
            searchParaClaimSalesRead.ServiceSlipCd = 0;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // ↑ 20070525 18322 a

			return searchParaClaimSalesRead;
		}
        // ↑ 20070122 18322 c


        // ↓ 20070122 18322 c MA.NS用に変更
        #region SF 引当先受注伝票のチェック処理（全てコメントアウト）
        ///// <summary>
		///// 引当先受注伝票のチェック処理
		///// </summary>
		///// <param name="kbn">チェック区分 0:黒,1:赤,2:相殺済み黒,3:締済み</param>
		///// <param name="acceptAnOrderNo">チェック対象受注番号</param>
		///// <param name="enterpriseCode">企業コード</param>
		///// <param name="addUpSecCod">請求計上拠点</param>
		///// <param name="customerCode">請求先コード</param>
		///// <param name="message">エラー時メッセージ</param>
		///// <returns>ステータス 0:チェック区分の受注無し. 2:チェック区分の受注有り, 以外:その他エラー </returns>
		///// <remarks>
		///// <br>Note       : 引当先の受注伝票の状態をチェックし、チェック種類にあわせたステータスを返します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//private int CheackAllowanceSalese(int kbn, int acceptAnOrderNo, string enterpriseCode, string addUpSecCod, int customerCode, out string message)
		//{
		//	message = "";
        //
		//	bool hitFlg = false;
        //
		//	// 請求売上情報DataRowの取得
		//	foreach (System.Data.DataRow drSales in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
		//	{
		//		// 同一受注番号の時
		//		if (acceptAnOrderNo == Convert.ToInt32(drSales[ctAcceptAnOrderNo]))
		//		{
		//			hitFlg = true;
        //
		//			switch (kbn)
		//			{
		//				case 0:		// --- 黒伝票チェック --- //
        //
		//					if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 0)
		//					{
		//						return 2;
		//					}
		//					
		//					break;
		//				
		//				case 1:		// --- 赤伝票チェック --- //
        //
		//					if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 1)
		//					{
		//						return 2;
		//					}
		//					
		//					break;
		//				
		//				case 2:		// --- 相殺済み黒伝票チェック --- //
        //
		//					if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 2)
		//					{
		//						return 2;
		//					}
		//					
		//					break;
		//				
		//				case 3:		// --- 締済み伝票チェック --- //
		//					
		//					if (drSales[ctSalesClosedFlg].ToString() != "")
		//					{
		//						return 2;
		//					}
        //
		//					break;
		//			}
        //
		//			break;
		//		}
		//	}
		//	
		//	// 引当に該当する受注データが無かった時
		//	// ※最初のリモートでひっぱてきてない時 (検索条件外の受注という事)
		//	if (hitFlg == false)
		//	{
        //        // ２次読込バッファに入っていればここから取得
		//		SearchDmdSales searchDmdSales = null;
		//		for (int ix = 0; ix < this._dmdSalesSecond.Count; ix++)
		//		{
		//			// 同一受注番号の時
		//			if (acceptAnOrderNo == ((SearchDmdSales)this._dmdSalesSecond[ix]).AcceptAnOrderNo)
		//			{
		//				searchDmdSales = (SearchDmdSales)this._dmdSalesSecond[ix];
		//				break;
		//			}
        //        }
        //
		//		// ２次読込バッファにも無い時は、再度読込取得する ※２次読込バッファにも保持する
		//		if (searchDmdSales == null)
		//		{
		//			try
		//			{
		//				SearchSalesParameter parameter = new SearchSalesParameter();
		//				SearchDmdSales[] searchDmdSalesList;
        //
		//				parameter.EnterpriseCode	= enterpriseCode;						// 企業コード
		//				parameter.AddUpSecCod		= addUpSecCod;							// 計上拠点
		//				parameter.CustomerCode		= customerCode;							// 請求先コード
		//				parameter.AcceptAnOrderNo	= acceptAnOrderNo;						// 受注伝票番号
		//				parameter.AcptAnOdrStatus	= new int[] {10, 20, 30};				// 受注ステータス
		//				parameter.CreditOrLoanCd	= new int[] {0, 1, 2};					// クレジット・ローン区分
		//				parameter.DataInputSystem	= new int[] {1, 2, 3};					// データ入力システム
        //
		//				// 請求売上情報取得処理
		//				if (this.GetDmdSalesInfo(parameter, out searchDmdSalesList) == 0)
		//				{
		//					// 取得した請求売上情報 戻りは１件しかないはず
		//					searchDmdSales = searchDmdSalesList[0];
		//				}
		//			}
		//			catch ( DepositException ex )
		//			{
		//				message = ex.Message;
		//				return ex.Status;
		//			}
		//			catch ( Exception ex )
		//			{
		//				message = ex.Message;
		//				return -999;
		//			}
		//		}
        //
		//		if (searchDmdSales != null)
		//		{
		//			switch (kbn)
		//			{
		//				case 0:		// --- 黒伝票チェック --- //
        //
		//					if (searchDmdSales.DebitNoteDiv == 0)
		//					{
		//						return 2;
		//					}
		//							
		//					break;
        //
		//				case 1:		// --- 赤伝票チェック --- //
        //
		//					if (searchDmdSales.DebitNoteDiv == 1)
		//					{
		//						return 2;
		//					}
		//							
		//					break;
		//						
		//				case 2:		// --- 相殺済み黒伝票チェック --- //
        //
		//					if (searchDmdSales.DebitNoteDiv == 2)
		//					{
		//						return 2;
		//					}
		//							
		//					break;
		//				
		//				case 3:		// --- 締済み伝票チェック --- //
		//					
		//					if (TDateTime.DateTimeToLongDate(searchDmdSales.AddUpADate) <= this._depositCustomer.CAddUpUpdDate)
		//					{
		//						return 2;
		//					}
        //
		//					break;
		//			}
		//		}
		//	}
        //
		//	return 0;
        //}
        #endregion

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 引当先受注伝票のチェック処理
		/// </summary>
		/// <param name="kbn">チェック区分 0:黒,1:赤,2:相殺済み黒,3:締済み</param>
        /// <param name="salesSlipNum">チェック対象 売上番号</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCod">請求計上拠点</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="message">エラー時メッセージ</param>
		/// <returns>ステータス 0:チェック区分の受注無し. 2:チェック区分の受注有り, 以外:その他エラー </returns>
		/// <remarks>
		/// <br>Note       : 引当先の受注伝票の状態をチェックし、チェック種類にあわせたステータスを返します。</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.22</br>
		/// </remarks>
		private int CheackAllowanceSalese(     int     kbn
		//                                 ,     int     acceptAnOrderNo   // 2007.10.05 hikita del
                                         ,     string  salesSlipNum        // 2007.10.05 hikita add
		                                 ,     string  enterpriseCode
		                                 ,     string  addUpSecCod
		                                 ,     int     customerCode
                                         ,     int     claimCode
                                         ,     int[]   acptAnOdrStatus 
		                                 ,     out string  message
		                                 )
		{
			message = "";

			bool hitFlg = false;

			// 請求売上情報DataRowの取得
			foreach (DataRow drSales in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// 同一受注番号の時
				//if (acceptAnOrderNo == Convert.ToInt32(drSales[ctAcceptAnOrderNo]))   // 2007.10.05 hikita del
                // 同一売上番号の時
                if (salesSlipNum == Convert.ToString(drSales[ctSalesSlipNum]))          // 2007.10.05 hikita add
				{
					hitFlg = true;

					switch (kbn)
					{
						case 0:		// --- 黒伝票チェック --- //

							if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 0)
							{
								return 2;
							}
							
							break;
						
						case 1:		// --- 赤伝票チェック --- //

							if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 1)
							{
								return 2;
							}
							
							break;
						
						case 2:		// --- 相殺済み黒伝票チェック --- //

							if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 2)
							{
								return 2;
							}
							
							break;
						
						case 3:		// --- 締済み伝票チェック --- //
							
							if (drSales[ctSalesClosedFlg].ToString() != "")
							{
								return 2;
							}

							break;
					}

					break;
				}
			}
			
			// 引当に該当する受注データが無かった時
			// ※最初のリモートでひっぱてきてない時 (検索条件外の受注という事)
			if (hitFlg == false)
			{
                // ２次読込バッファに入っていればここから取得
				SearchClaimSales searchClaimSales = null;
				for (int ix = 0; ix < this._dmdSalesSecond.Count; ix++)
				{
					// 同一受注番号の時
					//if (acceptAnOrderNo == ((SearchClaimSales)this._dmdSalesSecond[ix]).AcceptAnOrderNo)  // 2007.10.05 hikita del
                    // 同一売上番号の時
                    if (salesSlipNum == ((SearchClaimSales)this._dmdSalesSecond[ix]).SalesSlipNum)          // 2007.10.05 hikita add
					{
						searchClaimSales = (SearchClaimSales)this._dmdSalesSecond[ix];
						break;
					}
                }

				// ２次読込バッファにも無い時は、再度読込取得する ※２次読込バッファにも保持する
				if (searchClaimSales == null)
				{
					try
					{
						SearchSalesParameter parameter = new SearchSalesParameter();
						SearchClaimSales[] searchClaimSalesList;

						// 企業コード
						parameter.EnterpriseCode   = enterpriseCode;
						// 請求計上拠点
						parameter.DemandAddUpSecCd = addUpSecCod;
                        // 請求先コード
                        parameter.ClaimCode = claimCode;
                        // 得意先コード
						parameter.CustomerCode     = customerCode;
						// 受注番号
						//parameter.AcceptAnOrderNo  = acceptAnOrderNo;   // 2007.10.05 del
                        // 受注ステータス
                        parameter.AcptAnOdrStatus = acptAnOdrStatus;      // 2007.10.05 add
                        // 売上番号
                        parameter.SalesSlipNum = salesSlipNum;            // 2007.10.05 add

						// 請求売上情報取得処理
						if (this.GetClaimSalesInfo(parameter, out searchClaimSalesList) == 0)
						{
							// 取得した請求売上情報 戻りは１件しかないはず
							searchClaimSales = searchClaimSalesList[0];
						}
					}
					catch ( DepositException ex )
					{
						message = ex.Message;
						return ex.Status;
					}
					catch ( Exception ex )
					{
						message = ex.Message;
						return -999;
					}
				}

				if (searchClaimSales != null)
				{
					switch (kbn)
					{
						case 0:		// --- 黒伝票チェック --- //

							if (searchClaimSales.DebitNoteDiv == 0)
							{
								return 2;
							}
									
							break;

						case 1:		// --- 赤伝票チェック --- //

							if (searchClaimSales.DebitNoteDiv == 1)
							{
								return 2;
							}
									
							break;
								
						case 2:		// --- 相殺済み黒伝票チェック --- //

							if (searchClaimSales.DebitNoteDiv == 2)
							{
								return 2;
							}
									
							break;
						
						case 3:		// --- 締済み伝票チェック --- //
							
							if (TDateTime.DateTimeToLongDate(searchClaimSales.AddUpADate) <=
							    this._depositCustomer.CAddUpUpdDate)
							{
								return 2;
							}

							break;
					}
				}
			}

			return 0;
		}
        // ↑ 20070122 18322 c
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
        /// 引当先受注伝票のチェック処理
        /// </summary>
        /// <param name="kbn">チェック区分 0:黒,1:赤,2:相殺済み黒,3:締済み</param>
        /// <param name="salesSlipNum">チェック対象 売上番号</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCod">請求計上拠点</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="message">エラー時メッセージ</param>
        /// <returns>ステータス 0:チェック区分の受注無し. 2:チェック区分の受注有り, 以外:その他エラー </returns>
        /// <remarks>
        /// <br>Note       : 引当先の受注伝票の状態をチェックし、チェック種類にあわせたステータスを返します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private int CheackAllowanceSalese(int kbn, 
                                          string salesSlipNum, 
                                          string enterpriseCode, 
                                          string addUpSecCod, 
                                          int customerCode, 
                                          int claimCode, 
                                          int[] acptAnOdrStatus, 
                                          out string message)
        {
            message = "";
            int status;
            bool hitFlg = false;

            // 請求売上情報DataRowの取得
            foreach (DataRow drSales in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
            {
                // 同一売上番号の時
                if (salesSlipNum == (String)drSales[ctSalesSlipNum])
                {
                    hitFlg = true;

                    switch (kbn)
                    {
                        // --- 黒伝票チェック --- //
                        case 0: if ((Int32)drSales[ctDmdSalesDebitNoteCd] == 0)
                            if ((Int32)drSales[ctDmdSalesDebitNoteCd] == 0)
                            {
                                return 2;
                            }
                            break;
                        // --- 赤伝票チェック --- //
                        case 1:		
                            if ((Int32)drSales[ctDmdSalesDebitNoteCd] == 1)
                            {
                                return 2;
                            }
                            break;
                        // --- 相殺済み黒伝票チェック --- //
                        case 2:		
                            if ((Int32)drSales[ctDmdSalesDebitNoteCd] == 2)
                            {
                                return 2;
                            }
                            break;
                        // --- 締済み伝票チェック --- //
                        case 3:		
                            if ((String)drSales[ctSalesClosedFlg] != "")
                            {
                                return 2;
                            }
                            break;
                    }
                    break;
                }
            }

            // 引当に該当する受注データが無かった時
            // ※最初のリモートでひっぱてきてない時 (検索条件外の受注という事)
            if (hitFlg == false)
            {
                // ２次読込バッファに入っていればここから取得
                SearchClaimSales searchClaimSales = null;
                for (int ix = 0; ix < this._dmdSalesSecond.Count; ix++)
                {
                    // 同一売上番号の時
                    if (salesSlipNum == ((SearchClaimSales)this._dmdSalesSecond[ix]).SalesSlipNum)
                    {
                        searchClaimSales = (SearchClaimSales)this._dmdSalesSecond[ix];
                        break;
                    }
                }

                // ２次読込バッファにも無い時は、再度読込取得する ※２次読込バッファにも保持する
                if (searchClaimSales == null)
                {
                    try
                    {
                        SearchSalesParameter parameter = new SearchSalesParameter();
                        SearchClaimSales[] searchClaimSalesList;

                        parameter.EnterpriseCode = enterpriseCode;      // 企業コード
                        parameter.DemandAddUpSecCd = addUpSecCod;       // 請求計上拠点
                        parameter.ClaimCode = claimCode;                // 請求先コード
                        parameter.CustomerCode = customerCode;          // 得意先コード
                        parameter.AcptAnOdrStatus = acptAnOdrStatus;    // 受注ステータス
                        parameter.SalesSlipNum = salesSlipNum;          // 売上番号

                        // 請求売上情報取得処理
                        status = GetClaimSalesInfo(parameter, out searchClaimSalesList, out message);
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                // 取得した請求売上情報 戻りは１件しかないはず
                                searchClaimSales = searchClaimSalesList[0];
                                break;
                            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                break;
                            default:
                                return (status);
                        }
                    }
                    catch (DepositException ex)
                    {
                        message = ex.Message;
                        return ex.Status;
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        return -999;
                    }
                }

                if (searchClaimSales != null)
                {
                    switch (kbn)
                    {
                        // --- 黒伝票チェック --- //
                        case 0:		
                            if (searchClaimSales.DebitNoteDiv == 0)
                            {
                                return 2;
                            }
                            break;
                        // --- 赤伝票チェック --- //
                        case 1:		
                            if (searchClaimSales.DebitNoteDiv == 1)
                            {
                                return 2;
                            }
                            break;
                        // --- 相殺済み黒伝票チェック --- //
                        case 2:		
                            if (searchClaimSales.DebitNoteDiv == 2)
                            {
                                return 2;
                            }
                            break;
                        // --- 締済み伝票チェック --- //
                        case 3:		
                            if (TDateTime.DateTimeToLongDate(searchClaimSales.AddUpADate) <=
                                TDateTime.DateTimeToLongDate(this._lastAddUpDay))
                            {
                                return 2;
                            }
                            break;
                    }
                }
            }

            return 0;
        }

        // ↓ 20070122 18322 c MA.NS用に変更
        #region SF 請求売上情報データセット登録処理（全てコメントアウト）
        ///// <summary>
		///// 請求売上情報データセット登録処理
		///// </summary>
		///// <param name="arrDmdSales">請求売上クラス</param>
		///// <remarks>
		///// <br>Note　　　  : 請求売上情報をデータセットへ展開します。</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void SetDsDmdSalesInfo(ArrayList arrDmdSales)
		//{
		//	// 請求売上情報データテーブル データセット処理
		//	foreach(SearchDmdSales dmdSales in arrDmdSales)
		//	{
		//		// 請求売上情報DataSetの行を新規追加する
		//		DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();
        //
		//		// 請求売上情報DataRowセット処理
		//		SetDmdSales(drNew, dmdSales);
        //
		//		// 請求売上情報DataSetの行を追加する
		//		this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
		//	}
        //}
        #endregion

        /// <summary>
        /// 請求売上情報データセット登録処理
        /// </summary>
        /// <param name="arrDmdSales">請求売上クラス</param>
        /// <remarks>
        /// <br>Note　　　  : 請求売上情報をデータセットへ展開します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        private void SetDsDmdSalesInfo(ArrayList arrDmdSales)
        {
            // 請求売上情報データテーブル データセット処理
            foreach (SearchClaimSales dmdSales in arrDmdSales)
            {
                // 請求売上情報DataSetの行を新規追加する
                DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();

                // 請求売上情報DataRowセット処理
                SetClaimSales(drNew, dmdSales);

                // 入金引当データ検索
                int maxRows = this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Count;
                for (int i = 0; i < maxRows; i++)
                {
                    ////入金引当グリッドの売上伝票番号の請求売上の売上伝票番号と受注ステータスをセット
                    //this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctSalesSlipNum] = dmdSales.SalesSlipNum;
                    this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctAcptAnOdrStatus] = dmdSales.AcptAnOdrStatus;
                }

                // 請求売上情報DataSetの行を追加する
                this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
            }
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 請求売上情報データセット登録処理
		/// </summary>
		/// <param name="arrDmdSales">請求売上クラス</param>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報をデータセットへ展開します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDsDmdSalesInfo(ArrayList arrDmdSales)
		{
			// 請求売上情報データテーブル データセット処理
			foreach(SearchClaimSales dmdSales in arrDmdSales)
			{
				// 請求売上情報DataSetの行を新規追加する
				DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();

				// 請求売上情報DataRowセット処理
				SetClaimSales(drNew, dmdSales);

                // ↓ 20070202 18322 a
                // 入金引当に売上番号と受注ステータスをセット
                // 2007.10.05 hikita upd start -------------------------------->>
                //SetSalesSlipNumInAllowanceData( dmdSales.AcceptAnOrderNo
                //                              , dmdSales.SalesSlipNum);
                SetSalesSlipNumInAllowanceData(dmdSales.SalesSlipNum, dmdSales.AcptAnOdrStatus);
                // 2007.10.05 hikita upd end ----------------------------------<<
                // ↑ 20070202 18322 a

                // 入金引当データ検索
                int maxRows = this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Count;
                for (int i = 0; i < maxRows; i++)
                {
                    //入金引当グリッドの売上伝票番号の請求売上の売上伝票番号と受注ステータスをセット
                    this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctSalesSlipNum] = dmdSales.SalesSlipNum;
                    this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctAcptAnOdrStatus] = dmdSales.AcptAnOdrStatus;
                }

				// 請求売上情報DataSetの行を追加する
				this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
			}
        }

        /// <summary>
		/// 入金引当データに売上伝票番号と受注ステータスをセットします。
		/// </summary>
		/// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <remarks>
		/// <br>Note　　　  : 入金引当データに売上伝票番号をセットします。。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
        // 2007.10.05 hikita upd start ----------------------------------------------->>
		// private void SetSalesSlipNumInAllowanceData( int    acceptAnOrderNo    
		//                                           , string salesSlipNum)
        private void SetSalesSlipNumInAllowanceData(string salesSlipNum, int acptAnOdrStatus)    
        // 2007.10.05 hikita upd end -------------------------------------------------<<
		{
			// 入金引当データ検索
            int maxRows = this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Count;
            for (int i = 0; i < maxRows; i++)
            {
                // 2007.10.05 hikita upd start --------------------------------------->>
                // int no = Convert.ToInt32(this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctAcceptAnOrderNo]);
                // if (no == acceptAnOrderNo)
                //{
                    // 入金引当グリッドの売上伝票番号に、同一受注番号をもつ請求売上の売上伝票番号をセット
				//	this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctSalesSlipNum] = salesSlipNum;
                //}
                //入金引当グリッドの売上伝票番号の請求売上の売上伝票番号と受注ステータスをセット
                this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctSalesSlipNum] = salesSlipNum;
                this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctAcptAnOdrStatus] = acptAnOdrStatus;
                // 2007.10.05 hikita upd end -----------------------------------------<<
            }
        }
        // ↑ 20070122 18322 c
		   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
		/// 入金情報/引当情報データセット登録処理
		/// </summary>
		/// <param name="arrDepsitMain">入金クラス</param>
		/// <param name="arrDepositAlw">入金引当クラス</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
		/// <remarks>
		/// <br>Note　　　  : 入金情報/引当情報をデータセットへ展開します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
        private void SetDsDepositInfo(ArrayList arrDepsitMain, ArrayList arrDepositAlw, out int customerCode, out int claimCode)
		{
            int claimCode1 = 0;

			int customerCode1 = 0;
			
			// 入金情報データテーブル データセット処理
			if (arrDepsitMain != null)
			{
				foreach(SearchDepsitMain depsitMain in arrDepsitMain)
				{
					// 得意先コード取得
					customerCode1 = depsitMain.CustomerCode;
                    // 請求先コード取得
                    claimCode1 = depsitMain.ClaimCode;

					// 入金情報DataSetの行を新規作成する
					DataRow drNewDep = this._dsDepositInfo.Tables[ctDepositDataTable].NewRow();

					// 入金情報DataRowセット処理
					SetDeposit(drNewDep, depsitMain);

					// 入金情報DataSetの行を追加する
                    this._dsDepositInfo.Tables[ctDepositDataTable].Rows.Add(drNewDep);
				}
			}

			// 引当情報データテーブル データセット処理
			if (arrDepositAlw != null)
			{
				foreach(SearchDepositAlw depositAlw in arrDepositAlw)
				{
					// 得意先コード取得
					customerCode1 = depositAlw.CustomerCode;

                    // 請求先コード取得
                    claimCode1 = depositAlw.ClaimCode;

					// 引当情報の行を新規作成する
					DataRow drNewAlw = this._dsDepositInfo.Tables[ctAllowanceDataTable].NewRow();

					// 引当情報DataRowセット処理
					SetAllowance(drNewAlw, depositAlw);

					// 引当情報の行を追加する
					this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Add(drNewAlw);
				}
			}

            customerCode = customerCode1;
            claimCode = claimCode1;
		}

        // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
        /// <summary>
        /// 入金情報データセット登録処理
        /// </summary>
        /// <param name="arrDepsitMain">入金クラス</param>
        /// <param name="arrDepositAlw">入金引当クラス</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <remarks>
        /// <br>Note　　　  : 入金情報/引当情報をデータセットへ展開します。</br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void SetDsDepositGuidInfo(ArrayList arrDepsitMain, ArrayList arrDepositAlw, out int customerCode, out int claimCode)
        {
            int claimCode1 = 0;

            int customerCode1 = 0;

            // 入金情報データテーブル データセット処理
            if (arrDepsitMain != null)
            {
                foreach (SearchDepsitMain depsitMain in arrDepsitMain)
                {
                    // 得意先コード取得
                    customerCode1 = depsitMain.CustomerCode;
                    // 請求先コード取得
                    claimCode1 = depsitMain.ClaimCode;

                    // 入金情報DataSetの行を新規作成する
                    DataRow drNewDep = this._dsDepositInfo.Tables[ctDepositGuidDataTable].NewRow();

                    // 入金情報DataRowセット処理
                    SetDeposit(drNewDep, depsitMain);

                    // 入金情報DataSetの行を追加する
                    this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows.Add(drNewDep);
                }
            }
            customerCode = customerCode1;
            claimCode = claimCode1;
        }
        // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
			
		/// <summary>
		/// 入金情報/引当情報データセット更新処理
		/// </summary>
		/// <param name="arrDepsitMain">入金クラス</param>
		/// <param name="arrDepositAlw">入金引当クラス</param>
		/// <remarks>
		/// <br>Note　　　  : 入金情報/引当情報をデータセットへ更新します。
		///                   データセットに存在しない入金は新規追加します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void UpdateDepositDataSet(ArrayList arrDepsitMain, ArrayList arrDepositAlw)
		{
			bool updateFlag;

			// 入金情報データテーブル データセット処理
			foreach(SearchDepsitMain depsitMain in arrDepsitMain)
			{
				updateFlag = false;
				foreach(DataRow dr in this._dsDepositInfo.Tables[ctDepositDataTable].Rows)
				{
					if (Convert.ToInt32(dr[ctDepositSlipNo]) == depsitMain.DepositSlipNo)
					{
						// 入金情報DataRowセット処理
						SetDeposit(dr, depsitMain);
						updateFlag = true;
						break;
					}
				}

				// 更新されなかった時は新規
				if (updateFlag == false)
				{
					// 入金情報DataSetの行を新規作成する
					DataRow drNewDep = this._dsDepositInfo.Tables[ctDepositDataTable].NewRow();

					// 入金情報DataRowセット処理
					SetDeposit(drNewDep, depsitMain);

					// 入金情報DataSetの行を追加する
					this._dsDepositInfo.Tables[ctDepositDataTable].Rows.Add(drNewDep);
				}
			}

			// 引当情報データテーブル データセット処理
			foreach(SearchDepositAlw depositAlw in arrDepositAlw)
			{
				updateFlag = false;
				foreach(DataRow dr in this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows)
				{
					// 同一引当が存在すれば更新
					// 2007.10.05 hikita upd start ---------------------------------------------->>
                    //if ((Convert.ToInt32(dr[ctDepositSlipNo_Alw]) == depositAlw.DepositSlipNo) &&
					//	(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]) == depositAlw.AcceptAnOrderNo))
                    if (Convert.ToInt32(dr[ctDepositSlipNo_Alw]) == depositAlw.DepositSlipNo)
                    // 2007.10.05 hikita upd end ------------------------------------------------<<
					{
						if (depositAlw.LogicalDeleteCode == 0)
						{
							// 引当情報DataRowセット処理
							SetAllowance(dr, depositAlw);
							updateFlag = true;
							break;
						}
						else
						{
							// 論理削除の時は削除
							dr.Delete();
							updateFlag = true;
							break;
						}
					}
				}

				// 更新されなかった時は新規
				if (updateFlag == false)
				{
					// 引当情報の行を新規作成する
					DataRow drNewAlw = this._dsDepositInfo.Tables[ctAllowanceDataTable].NewRow();

					// 引当情報DataRowセット処理
					SetAllowance(drNewAlw, depositAlw);

					// 引当情報の行を追加する
					this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Add(drNewAlw);
				}
			}
		}

        // ↓ 20070122 18322 c MA.NS用に変更
        #region SF 請求売上マスタクラス引当情報クリア処理（コメントアウト）
        ///// <summary>
		///// 請求売上マスタクラス引当情報クリア処理
		///// </summary>
		///// <remarks>
		///// <br>Note　　　  : 請求売上マスタクラスの引当金額をクリアします。</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void ClearDmdSalesAllowance(Hashtable htDepositAlw)
		//{
		//	// 対象引当データ
		//	foreach (DictionaryEntry de in htDepositAlw)
		//	{
		//		SearchDepositAlw depositAlw = (SearchDepositAlw)de.Value;
        //
		//		// データ保持用の引当金額に削除引当金額を減算する
		//		foreach (SearchDmdSales dmdSales in this._dmdSales)
		//		{
		//			if (depositAlw.AcceptAnOrderNo == dmdSales.AcceptAnOrderNo)
		//			{
		//				// 引当額 受注 (請求売上マスタ)
		//				dmdSales.AcpOdrDepositAlwc = dmdSales.AcpOdrDepositAlwc - depositAlw.AcpOdrDepositAlwc;
        //
		//				// 引当残 受注 (請求売上マスタ)
		//				dmdSales.AcpOdrDepoAlwcBlnce = dmdSales.AcpOdrDepoAlwcBlnce + depositAlw.AcpOdrDepositAlwc;
        //
		//				// 引当額 諸費用 (請求売上マスタ)
		//				dmdSales.VarCostDepoAlwc = dmdSales.VarCostDepoAlwc - depositAlw.VarCostDepoAlwc;
        //
		//				// 引当残 諸費用 (請求売上マスタ)
		//				dmdSales.VarCostDepoAlwcBlnce = dmdSales.VarCostDepoAlwcBlnce + depositAlw.VarCostDepoAlwc;
        //
		//				// 引当額 共通 (請求売上マスタ)
		//				dmdSales.DepositAllowance = dmdSales.DepositAllowance - depositAlw.DepositAllowance;
        //
		//				// 引当残 共通 (請求売上マスタ)
		//				dmdSales.DepositAlwcBlnce = dmdSales.DepositAlwcBlnce + depositAlw.DepositAllowance;
		//			}
		//		}
		//	}
        //}
        #endregion

        /// <summary>
		/// 請求売上マスタクラス引当情報クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 請求売上マスタクラスの引当金額をクリアします。</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.22</br>
		/// </remarks>
		private void ClearDmdSalesAllowance(Hashtable htDepositAlw)
		{
			// 対象引当データ
			foreach (DictionaryEntry de in htDepositAlw)
			{
				SearchDepositAlw depositAlw = (SearchDepositAlw)de.Value;

				// データ保持用の引当金額に削除引当金額を減算する
				foreach (SearchClaimSales claimSales in this._dmdSales)
				{
                    //if (depositAlw.AcceptAnOrderNo == claimSales.AcceptAnOrderNo)  // 2007.10.05 del
                    if (depositAlw.SalesSlipNum == claimSales.SalesSlipNum)          // 2007.10.05 add
					{
						// 引当額 共通 (請求売上マスタ)
						claimSales.DepositAllowanceTtl = claimSales.DepositAllowanceTtl - depositAlw.DepositAllowance;

						// 引当残 共通 (請求売上マスタ)
						claimSales.DepositAlwcBlnce = claimSales.DepositAlwcBlnce + depositAlw.DepositAllowance;
					}
				}
			}
        }
        // ↑ 20070122 18322 c

        // ↓ 20070122 18322 c MA.NS用に変更
        #region SF 請求売上マスタクラス更新処理（全てコメントアウト）
        ///// <summary>
		///// 請求売上マスタクラス更新処理
		///// </summary>
		///// <remarks>
		///// <br>Note　　　  : 請求売上マスタクラス(データ保持用)の内容をデータセットから更新します。</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void UpdateDmdSales()
		//{
		//	// データセットの内容を取得
		//	foreach (System.Data.DataRow dr in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
		//	{
		//		// データ保持用から取得
		//		foreach (SearchDmdSales dmdSales in this._dmdSales)
		//		{
		//		
		//			if (Convert.ToInt32(dr[ctAcceptAnOrderNo]) == dmdSales.AcceptAnOrderNo)
		//			{
        //                // 引当残 受注 (請求売上マスタ)
		//				dmdSales.AcpOdrDepoAlwcBlnce = Convert.ToInt64(dr[ctAcpOdrDepoAlwcBlnce_Sales]);
        //                
		//				// 引当済 受注 (請求売上マスタ)
		//				dmdSales.AcpOdrDepositAlwc = Convert.ToInt64(dr[ctAcpOdrDepositAlwc_Sales]);
        //                
		//				// 引当残 諸費用 (請求売上マスタ)
		//				dmdSales.VarCostDepoAlwcBlnce = Convert.ToInt64(dr[ctVarCostDepoAlwcBlnce_Sales]);
        //                
		//    			// 引当済 諸費用 (請求売上マスタ)
        //                dmdSales.VarCostDepoAlwc = Convert.ToInt64(dr[ctVarCostDepoAlwc_Sales]);
        //
		//				// 引当残 共通 (請求売上マスタ)
		//				dmdSales.DepositAlwcBlnce = Convert.ToInt64(dr[ctDepositAlwcBlnce_Sales]);
        //
		//				// 引当済 共通 (請求売上マスタ)
		//				dmdSales.DepositAllowance = Convert.ToInt64(dr[ctDepositAllowance_Sales]);
		//			}
		//		}
		//	}
        //}
        #endregion

        /// <summary>
		/// 請求売上マスタクラス更新処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 請求売上マスタクラス(データ保持用)の内容をデータセットから更新します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void UpdateDmdSales()
		{
			// データセットの内容を取得
			foreach (DataRow dr in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// データ保持用から取得
				foreach (SearchClaimSales claimSales in this._dmdSales)
				{
				
					// if (Convert.ToInt32(dr[ctAcceptAnOrderNo]) == claimSales.AcceptAnOrderNo)    // 2007.10.05 del
                    if (Convert.ToString(dr[ctSalesSlipNum]) == claimSales.SalesSlipNum)            // 2007.10.05 add
                    {
						// 引当残 共通 (請求売上マスタ)
						claimSales.DepositAlwcBlnce = Convert.ToInt64(dr[ctDepositAlwcBlnce_Sales]);
                        
						// 引当済 共通 (請求売上マスタ)
						claimSales.DepositAllowanceTtl = Convert.ToInt64(dr[ctDepositAllowance_Sales]);
					}
				}
			}
		}
        // ↑ 20070122 18322 c
		
		/// <summary>
		/// 入金情報/引当情報データセット削除処理
		/// </summary>
		/// <param name="depositSlipNo">入金番号</param>
		/// <returns>得意先コード</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金情報/引当情報をデータセットから削除します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void DeleteDepositDataSet(int depositSlipNo)
		{
			int ix;

			// 引当情報データテーブル データ削除処理
			for (ix = 0; ix < this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Count; ix++)
			{
				if (Convert.ToInt32(this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[ix][ctDepositSlipNo_Alw]) == depositSlipNo)
				{
					this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[ix].Delete();
					ix--;
				}
			}

			// 入金情報データテーブル データ削除処理
			for (ix = 0; ix < this._dsDepositInfo.Tables[ctDepositDataTable].Rows.Count; ix++)
			{
				if (Convert.ToInt32(this._dsDepositInfo.Tables[ctDepositDataTable].Rows[ix][ctDepositSlipNo]) == depositSlipNo)
				{
					this._dsDepositInfo.Tables[ctDepositDataTable].Rows[ix].Delete();
					ix--;
				}
			}
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入金情報DetaRowセット処理
        /// </summary>
        /// <param name="drNew">入金情報DataRow</param>
        /// <param name="depsitMain">入金クラス</param>
        /// <remarks>
        /// <br>Note　　　  : 入金情報をDataRowにセットします。</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private void SetDeposit(DataRow drNew, SearchDepsitMain depsitMain)
        {
            // 入金赤黒区分
            drNew[ctDepositDebitNoteCd] = depsitMain.DepositDebitNoteCd;

            // 入金赤黒名称
            switch (depsitMain.DepositDebitNoteCd)
            {
                case 0:
                    drNew[ctDepositDebitNoteNm] = "黒";
                    break;
                case 1:
                    drNew[ctDepositDebitNoteNm] = "赤";
                    break;
                case 2:
                    drNew[ctDepositDebitNoteNm] = "相殺済み黒";
                    break;
            }

            // 入金伝票番号
            drNew[ctDepositSlipNo] = depsitMain.DepositSlipNo;

            // ↓ 20070525 18322 a
            // 受注番号
            //drNew[ctAcceptAnOrderNo] = depsitMain.AcceptAnOrderNo;      // 2007.10.05 del
            // ↑ 20070525 18322 a
            // 受注ステータス
            drNew[ctDepositAcptAnOdrStatus] = depsitMain.AcptAnOdrStatus; // 2007.10.05 add
            
            // 売上伝票番号
            drNew[ctSalesSlipNum] = depsitMain.SalesSlipNum;

            // 赤黒入金連結番号
            drNew[ctDebitNoteLinkDepoNo] = depsitMain.DebitNoteLinkDepoNo;

            // ↓ 20070418 18322 c MA.NS対応
            //// 入金日付(表示用)
            //drNew[ctDepositDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", depsitMain.DepositDate);

            // 入金日付(表示用)
            drNew[ctDepositDateDisp] = depsitMain.DepositDate.ToString("yyyy/MM/dd");
            // ↑ 20070418 18322 c

            // 入金日付
            drNew[ctDepositDate] = TDateTime.DateTimeToLongDate(depsitMain.DepositDate);
				
            // 計上日付(表示用)
            drNew[ctDepositAddUpADateDisp] = depsitMain.AddUpADate.ToString("yyyy/MM/dd");    // 2007.10.05 add
                
            // 計上日付
            drNew[ctDepositAddUpADate] = TDateTime.DateTimeToLongDate(depsitMain.AddUpADate); // 2007.10.05 add
				
            // 自動入金区分
            drNew[ctAutoDepositCd] = depsitMain.AutoDepositCd;

            // 預り金区分名称
            drNew[ctDepositCd] = depsitMain.DepositCd;
            if (depsitMain.AutoDepositCd == 0)
            {
                drNew[ctDepositNm] = depsitMain.DepositNm;
            }
            else
            {
                drNew[ctDepositNm] = depsitMain.DepositNm + "(自動)";
            }
            
            // 入金金種
            drNew[ctDepositKindDivCd] = depsitMain.DepositKindDivCd;
            drNew[ctDepositKindCode] = depsitMain.DepositKindCode;
            
            drNew[ctDepositKindName] = depsitMain.DepositKindName;

            // ↓ 20070118 18322 d MA.NS用に変更
            #region SF 受注・諸費用（全てコメントアウト）
            //// 受注 入金額
            //drNew[ctAcpOdrDeposit] = depsitMain.AcpOdrDeposit;
            //
            //// 受注 手数料
            //drNew[ctAcpOdrChargeDeposit] = depsitMain.AcpOdrChargeDeposit;
            //
            //// 受注 値引
            //drNew[ctAcpOdrDisDeposit] = depsitMain.AcpOdrDisDeposit;
            //
            //// 受注 入金計
            //drNew[ctAcpOdrDepositTotal] = depsitMain.AcpOdrDeposit + depsitMain.AcpOdrChargeDeposit + depsitMain.AcpOdrDisDeposit;
            //
            //// 諸費用 入金額
            //drNew[ctVariousCostDeposit] = depsitMain.VariousCostDeposit;
            //
            //// 諸費用 手数料
            //drNew[ctVarCostChargeDeposit] = depsitMain.VarCostChargeDeposit;
            //
            //// 諸費用 値引
            //drNew[ctVarCostDisDeposit] = depsitMain.VarCostDisDeposit;
            //
            //// 諸費用 入金計
            //drNew[ctVariousCostDepositTotal] = depsitMain.VariousCostDeposit + depsitMain.VarCostChargeDeposit + depsitMain.VarCostDisDeposit;
            #endregion
            // ↑ 20070118 18322 d

            // 共通 入金額
            drNew[ctDeposit] = depsitMain.Deposit;

            // 共通 手数料
            drNew[ctFeeDeposit] = depsitMain.FeeDeposit;

            // 共通 値引
            drNew[ctDiscountDeposit] = depsitMain.DiscountDeposit;

            // ↓ 20070118 18322 a
            // 共通 インセンティブ
            // drNew[ctRebateDeposit] = depsitMain.RebateDeposit;   // 2007.10.05 del
            // ↑ 20070118 18322 a

            // 共通 入金計
            drNew[ctDepositTotal] = depsitMain.DepositTotal;

            // ↓ 20070118 18322 d MA.NS用に変更
            #region SF 受注・諸費用（全てコメントアウト）
            //// 入金引当額 受注
            //drNew[ctAcpOdrDepositAlwc_Deposit] = depsitMain.AcpOdrDepositAlwc;
            //
            //// 入金引当残 受注
            //drNew[ctAcpOdrDepoAlwcBlnce_Deposit] = depsitMain.AcpOdrDepoAlwcBlnce;
            //
            //// 入金引当額 諸費用
            //drNew[ctVarCostDepoAlwc_Deposit] = depsitMain.VarCostDepoAlwc;
            //
            //// 入金引当残 諸費用
            //drNew[ctVarCostDepoAlwcBlnce_Deposit] = depsitMain.VarCostDepoAlwcBlnce;
            #endregion
            // ↑ 20070118 18322 d

            // 入金引当額 共通
            drNew[ctDepositAllowance_Deposit] = depsitMain.DepositAllowance;

            // 入金引当残 共通
            drNew[ctDepositAlwcBlnce_Deposit] = depsitMain.DepositAlwcBlnce;
            
            // クレジット/ローン区分
            // drNew[ctCreditOrLoanCd] = depsitMain.CreditOrLoanCd;        // 2007.10.05 del

            // クレジット会社コード
            // drNew[ctCreditCompanyCode] = depsitMain.CreditCompanyCode;  // 2007.10.05 del

            // 手形振出日
            drNew[ctDraftDrawingDate] = TDateTime.DateTimeToLongDate(depsitMain.DraftDrawingDate);

            // 手形支払期日
            drNew[ctDraftPayTimeLimit] = TDateTime.DateTimeToLongDate(depsitMain.DraftPayTimeLimit);

            // 2007.10.05 add start -------------------------------------------------------->>
            // 銀行コード
            drNew[ctBankCode] = depsitMain.BankCode;
 
            // 銀行名称
            drNew[ctBankName] = depsitMain.BankName;

            // 手形番号
            drNew[ctDraftNo] = depsitMain.DraftNo;

            // 手形種類
            drNew[ctDraftKind] = depsitMain.DraftKind;

            // 手形種類名称
            drNew[ctDraftKindName] = depsitMain.DraftKindName;

            // 手形区分
            drNew[ctDraftDivide] = depsitMain.DraftDivide;

            // 手形区分名称
            drNew[ctDraftDivideName] = depsitMain.DraftDivideName;
            // 2007.10.05 add end ----------------------------------------------------------<<
            // 摘要
            drNew[ctOutline] = depsitMain.Outline;

            // 自身のDataRow
            drNew[ctDepositDataRow] = drNew;
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
        /// 入金情報DetaRowセット処理
        /// </summary>
        /// <param name="drNew">入金情報DataRow</param>
        /// <param name="depsitMain">入金クラス</param>
        /// <remarks>
        /// <br>Note　　　  : 入金情報をDataRowにセットします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)
        /// <br>              項目「引当」を追加する。</br>
        /// <br>Update Note : 2012/09/21 田建委</br>
        /// <br>管理番号    : 2012/10/17配信分</br>
        /// <br>              Redmine#32415 発行者の追加対応</br>
        /// <br>Update Note : 2012/12/24 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void SetDeposit(DataRow drNew, SearchDepsitMain depsitMain)
        {
            drNew[ctDepositDebitNoteCd] = depsitMain.DepositDebitNoteCd;                            // 入金赤黒区分
            // 入金赤黒名称
            switch (depsitMain.DepositDebitNoteCd)
            {
                case 0:
                    drNew[ctDepositDebitNoteNm] = "黒";
                    break;
                case 1:
                    drNew[ctDepositDebitNoteNm] = "赤";
                    break;
                case 2:
                    drNew[ctDepositDebitNoteNm] = "相殺済み黒";
                    break;
            }
            drNew[ctDepositSlipNo] = depsitMain.DepositSlipNo;                                      // 入金伝票番号
            drNew[ctDepositAcptAnOdrStatus] = depsitMain.AcptAnOdrStatus;                           // 受注ステータス
            drNew[ctSalesSlipNum] = depsitMain.SalesSlipNum;                                        // 売上伝票番号
            drNew[ctDebitNoteLinkDepoNo] = depsitMain.DebitNoteLinkDepoNo;                          // 赤黒入金連結番号
            drNew[ctDepositDateDisp] = depsitMain.DepositDate.ToString("yyyy/MM/dd");               // 入金日付(表示用)
            drNew[ctDepositDate] = TDateTime.DateTimeToLongDate(depsitMain.DepositDate);            // 入金日付
            drNew[ctDepositAddUpADateDisp] = depsitMain.AddUpADate.ToString("yyyy/MM/dd");          // 計上日付(表示用)
            drNew[ctDepositAddUpADate] = TDateTime.DateTimeToLongDate(depsitMain.AddUpADate);       // 計上日付
            drNew[ctAutoDepositCd] = depsitMain.AutoDepositCd;                                      // 自動入金区分
            // 預り金区分名称
            if (depsitMain.AutoDepositCd == 0)
            {
                drNew[ctDepositNm] = depsitMain.DepositNm;
            }
            else
            {
                drNew[ctDepositNm] = "自動入金";
            }
            // TODO:入金金種(表示用)
            List<string> moneyKindNameList = new List<string>();
            for (int index = 0; index < depsitMain.DepositDtl.Length; index++)
            {
                // DEL 2010/03/25 MANTIS対応[15195]：0円入金保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
                // if (depsitMain.DepositDtl[index] != 0)
                // DEL 2010/03/25 MANTIS対応[15195]：0円入金保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
                // ADD 2010/03/25 MANTIS対応[15195]：0円入金保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
                if (!string.IsNullOrEmpty(depsitMain.MoneyKindName[index]))
                // ADD 2010/03/25 MANTIS対応[15195]：0円入金保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
                {
                    moneyKindNameList.Add(depsitMain.MoneyKindName[index]);
                }
            }
            switch (moneyKindNameList.Count)
            {
                case 0:
                    drNew[ctDepositKindName] = "";
                    break;
                case 1:
                    drNew[ctDepositKindName] = moneyKindNameList[0];
                    break;
                case 2:
                    drNew[ctDepositKindName] = moneyKindNameList[0] + "・" + moneyKindNameList[1];
                    break;
                default:
                    drNew[ctDepositKindName] = moneyKindNameList[0] + "・" + moneyKindNameList[1] + "ほか";
                    break;
            }
            drNew[ctDeposit] = depsitMain.Deposit;                                                  // 共通 入金額
            drNew[ctFeeDeposit] = depsitMain.FeeDeposit;                                            // 共通 手数料
            drNew[ctDiscountDeposit] = depsitMain.DiscountDeposit;                                  // 共通 値引
            // 共通 入金計(入金額＋手数料入金額＋値引入金額)
            drNew[ctDepositTotal] = depsitMain.Deposit + depsitMain.FeeDeposit + depsitMain.DiscountDeposit;
            drNew[ctDepositAllowance_Deposit] = depsitMain.DepositAllowance;                        // 入金引当額 共通
            //drNew[ctDepositAlwcBlnce_Deposit] = depsitMain.DepositAlwcBlnce;                        // 入金引当残 共通
            drNew[ctDepositAlwcBlnce_Deposit] = depsitMain.Deposit + depsitMain.FeeDeposit + depsitMain.DiscountDeposit - depsitMain.DepositAllowance;                        // 入金引当残 共通

            // --- ADD 2010/12/20 ---------->>>>>
            // 引当
            if ((long)drNew[ctDepositAlwcBlnce_Deposit] == 0)
            {
                // №1:入金引当残高(DepositAlwcBlnce)＝0場合
                drNew[ctAllowDiv] = "済";
            }
            else if (depsitMain.DepositAllowance != 0)
            {
                // №2:№1以外で、入金引当額(DepositAllowance)≠0場合
                drNew[ctAllowDiv] = "一部";
            }
            else
            {
                // №1以外かつ№2以外場合
                drNew[ctAllowDiv] = "";
            }
            // --- ADD 2010/12/20  ----------<<<<<

            if (depsitMain.DraftDrawingDate == DateTime.MinValue)
            {
                drNew[ctDraftDrawingDate] = 0;
            }
            else
            {
                drNew[ctDraftDrawingDate] = TDateTime.DateTimeToLongDate(depsitMain.DraftDrawingDate);  // 手形振出日
            }
            drNew[ctBankCode] = depsitMain.BankCode;                                                // 銀行コード
            drNew[ctBankName] = depsitMain.BankName;                                                // 銀行名称
            drNew[ctDraftNo] = depsitMain.DraftNo;                                                  // 手形番号
            drNew[ctDraftKind] = depsitMain.DraftKind;                                              // 手形種類
            drNew[ctDraftKindName] = depsitMain.DraftKindName;                                      // 手形種類名称
            drNew[ctDraftDivide] = depsitMain.DraftDivide;                                          // 手形区分
            drNew[ctDraftDivideName] = depsitMain.DraftDivideName;                                  // 手形区分名称
            drNew[ctOutline] = depsitMain.Outline;                                                  // 摘要

            drNew[ctDepositRowNo1] = depsitMain.DepositRowNo[0];                                    // 入金行番号1
            drNew[ctMoneyKindCode1] = depsitMain.MoneyKindCode[0];                                  // 金種コード1
            drNew[ctMoneyKindName1] = depsitMain.MoneyKindName[0];                                  // 金種名称1
            drNew[ctMoneyKindDiv1] = depsitMain.MoneyKindDiv[0];                                    // 金種区分1
            drNew[ctDeposit1] = depsitMain.DepositDtl[0];                                           // 入金金額1
            drNew[ctValidityTerm1] = depsitMain.ValidityTerm[0];                                    // 有効期限1
            drNew[ctDepositRowNo2] = depsitMain.DepositRowNo[1];                                    // 入金行番号2
            drNew[ctMoneyKindCode2] = depsitMain.MoneyKindCode[1];                                  // 金種コード2
            drNew[ctMoneyKindName2] = depsitMain.MoneyKindName[1];                                  // 金種名称2
            drNew[ctMoneyKindDiv2] = depsitMain.MoneyKindDiv[1];                                    // 金種区分2
            drNew[ctDeposit2] = depsitMain.DepositDtl[1];                                           // 入金金額2
            drNew[ctValidityTerm2] = depsitMain.ValidityTerm[1];                                    // 有効期限2
            drNew[ctDepositRowNo3] = depsitMain.DepositRowNo[2];                                    // 入金行番号3
            drNew[ctMoneyKindCode3] = depsitMain.MoneyKindCode[2];                                  // 金種コード3
            drNew[ctMoneyKindName3] = depsitMain.MoneyKindName[2];                                  // 金種名称3
            drNew[ctMoneyKindDiv3] = depsitMain.MoneyKindDiv[2];                                    // 金種区分3
            drNew[ctDeposit3] = depsitMain.DepositDtl[2];                                           // 入金金額3
            drNew[ctValidityTerm3] = depsitMain.ValidityTerm[2];                                    // 有効期限3
            drNew[ctDepositRowNo4] = depsitMain.DepositRowNo[3];                                    // 入金行番号4
            drNew[ctMoneyKindCode4] = depsitMain.MoneyKindCode[3];                                  // 金種コード4
            drNew[ctMoneyKindName4] = depsitMain.MoneyKindName[3];                                  // 金種名称4
            drNew[ctMoneyKindDiv4] = depsitMain.MoneyKindDiv[3];                                    // 金種区分4
            drNew[ctDeposit4] = depsitMain.DepositDtl[3];                                           // 入金金額4
            drNew[ctValidityTerm4] = depsitMain.ValidityTerm[3];                                    // 有効期限4
            drNew[ctDepositRowNo5] = depsitMain.DepositRowNo[4];                                    // 入金行番号5
            drNew[ctMoneyKindCode5] = depsitMain.MoneyKindCode[4];                                  // 金種コード5
            drNew[ctMoneyKindName5] = depsitMain.MoneyKindName[4];                                  // 金種名称5
            drNew[ctMoneyKindDiv5] = depsitMain.MoneyKindDiv[4];                                    // 金種区分5
            drNew[ctDeposit5] = depsitMain.DepositDtl[4];                                           // 入金金額5
            drNew[ctValidityTerm5] = depsitMain.ValidityTerm[4];                                    // 有効期限5
            drNew[ctDepositRowNo6] = depsitMain.DepositRowNo[5];                                    // 入金行番号6
            drNew[ctMoneyKindCode6] = depsitMain.MoneyKindCode[5];                                  // 金種コード6
            drNew[ctMoneyKindName6] = depsitMain.MoneyKindName[5];                                  // 金種名称6
            drNew[ctMoneyKindDiv6] = depsitMain.MoneyKindDiv[5];                                    // 金種区分6
            drNew[ctDeposit6] = depsitMain.DepositDtl[5];                                           // 入金金額6
            drNew[ctValidityTerm6] = depsitMain.ValidityTerm[5];                                    // 有効期限6
            drNew[ctDepositRowNo7] = depsitMain.DepositRowNo[6];                                    // 入金行番号7
            drNew[ctMoneyKindCode7] = depsitMain.MoneyKindCode[6];                                  // 金種コード7
            drNew[ctMoneyKindName7] = depsitMain.MoneyKindName[6];                                  // 金種名称7
            drNew[ctMoneyKindDiv7] = depsitMain.MoneyKindDiv[6];                                    // 金種区分7
            drNew[ctDeposit7] = depsitMain.DepositDtl[6];                                           // 入金金額7
            drNew[ctValidityTerm7] = depsitMain.ValidityTerm[6];                                    // 有効期限7
            drNew[ctDepositRowNo8] = depsitMain.DepositRowNo[7];                                    // 入金行番号8
            drNew[ctMoneyKindCode8] = depsitMain.MoneyKindCode[7];                                  // 金種コード8
            drNew[ctMoneyKindName8] = depsitMain.MoneyKindName[7];                                  // 金種名称8
            drNew[ctMoneyKindDiv8] = depsitMain.MoneyKindDiv[7];                                    // 金種区分8
            drNew[ctDeposit8] = depsitMain.DepositDtl[7];                                           // 入金金額8
            drNew[ctValidityTerm8] = depsitMain.ValidityTerm[7];                                    // 有効期限8
            drNew[ctDepositRowNo9] = depsitMain.DepositRowNo[8];                                    // 入金行番号9
            drNew[ctMoneyKindCode9] = depsitMain.MoneyKindCode[8];                                  // 金種コード9
            drNew[ctMoneyKindName9] = depsitMain.MoneyKindName[8];                                  // 金種名称9
            drNew[ctMoneyKindDiv9] = depsitMain.MoneyKindDiv[8];                                    // 金種区分9
            drNew[ctDeposit9] = depsitMain.DepositDtl[8];                                           // 入金金額9
            drNew[ctValidityTerm9] = depsitMain.ValidityTerm[8];                                    // 有効期限9
            drNew[ctDepositRowNo10] = depsitMain.DepositRowNo[9];                                    // 入金行番号10
            drNew[ctMoneyKindCode10] = depsitMain.MoneyKindCode[9];                                  // 金種コード10
            drNew[ctMoneyKindName10] = depsitMain.MoneyKindName[9];                                  // 金種名称10
            drNew[ctMoneyKindDiv10] = depsitMain.MoneyKindDiv[9];                                    // 金種区分10
            drNew[ctDeposit10] = depsitMain.DepositDtl[9];                                           // 入金金額10
            drNew[ctValidityTerm10] = depsitMain.ValidityTerm[9];                                    // 有効期限10

            // ADD 2010/03/25 MANTIS[15196]：入金一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
            drNew[ctDepositInputAgentNm] = depsitMain.DepositAgentNm;                               // FIXME:入力担当者
            // ADD 2010/03/25 MANTIS[15196]：入金一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<

            //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
            drNew[ctDepositInputEmpCd] = depsitMain.DepositInputAgentCd.Trim();                     // 発行者コード
            drNew[ctDepositInputEmpNm] = depsitMain.DepositInputAgentNm.Trim();                     // 発行者名
            //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<
            // ADD 2012/12/24 王君  Redmine#33741 ------------------------->>>>>
            drNew[ctCustomerCode] = depsitMain.CustomerCode;  // 得意先コード
            drNew[ctCustomerName] = depsitMain.CustomerSnm;   // 得意先略称
            // ADD 2012/12/24 王君　Redmine#33741 -------------------------<<<<<

            drNew[ctDepositDataRow] = drNew;                                                        // 自身のDataRow
        }
		
		/// <summary>
		/// 入金引当情報DetaRowセット処理
		/// </summary>
		/// <param name="drNew">入金引当情報DataRow</param>
		/// <param name="depositAlw">入金引当クラス</param>
		/// <remarks>
		/// <br>Note　　　  : 入金引当情報をDataRowにセットします。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetAllowance(DataRow drNew, SearchDepositAlw depositAlw)
		{
			// 入金伝票番号
			drNew[ctDepositSlipNo_Alw] = depositAlw.DepositSlipNo;

            // 受注ステータス
            drNew[ctAcptAnOdrStatus_Alw] = depositAlw.AcptAnOdrStatus;      // 2007.10.05 add
            
            // 売上伝票番号
            drNew[ctSalesSlipNum] = depositAlw.SalesSlipNum;                // 2007.10.05 add

			// 受注伝票番号
			// drNew[ctAcceptAnOrderNo_Alw] = depositAlw.AcceptAnOrderNo;   // 2007.10.05 del

            // ↓ 20070118 18322 d MA.NS用に変更
			//// 入金引当額 受注
			//drNew[ctAcpOdrDepositAlwc] = depositAlw.AcpOdrDepositAlwc;
            //
			//// 入金引当額 諸費用
			//drNew[ctVarCostDepoAlwc] = depositAlw.VarCostDepoAlwc;
            // ↑ 20070118 18322 d

			// 入金引当額 共通
			drNew[ctDepositAllowance] = depositAlw.DepositAllowance;

            // ↓ 20070418 18322 c MA.NS対応
			//// 引当日(表示用)
			//drNew[ctReconcileDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", depositAlw.ReconcileDate);

			// 引当日(表示用)
			drNew[ctReconcileDateDisp] = depositAlw.ReconcileDate.ToString("yyyy/MM/dd");
            // ↑ 20070418 18322 c

			// 引当日
			drNew[ctReconcileDate] = TDateTime.DateTimeToLongDate(depositAlw.ReconcileDate);

			// 引当計上日付
			drNew[ctReconcileAddUpDate] = TDateTime.DateTimeToLongDate(depositAlw.ReconcileAddUpDate);
		}
		
		/// <summary>
		/// 入金情報/引当情報 保持用データクラス登録処理
		/// </summary>
		/// <param name="arrDepsitMain">入金クラス</param>
		/// <param name="arrDepositAlw">入金引当クラス</param>
		/// <remarks>
		/// <br>Note　　　  : 入金情報/引当情報を保持用データクラスへ展開します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDepositSaveClass(ArrayList arrDepsitMain, ArrayList arrDepositAlw)
		{
			if (arrDepsitMain != null)
			{
				// 入金情報データテーブル データセット処理
				foreach(SearchDepsitMain depsitMain in arrDepsitMain)
				{
					// 入金マスタクラスに追加
					_depsitMain.Add(depsitMain.DepositSlipNo, depsitMain);
				}
			}

			if (arrDepositAlw != null)
			{
				// 入金引当情報データテーブル データセット処理
				// ※ htOrderNoTani   : 同一入金番号分が受注番号で入る
				// ※ _depositAlw     : 入金番号単位でhtOrderNoTaniが入る
				int depositSlipNo = -1;
				Hashtable htOrderNoTani = new Hashtable();
                // ----- ADD 王君 2012/12/24 Redmine#33741----- >>>>>
                IComparer depositSlipNoComparer = new DepositSlipNoComparer();
                arrDepositAlw.Sort(depositSlipNoComparer);
                // ----- ADD 王君 2012/12/24 Redmine#33741----- <<<<<
				foreach(SearchDepositAlw depositAlw in arrDepositAlw)
				{
					// 初回ではなく、入金番号が変わった時
					if ((depositSlipNo != -1) && (depositSlipNo != depositAlw.DepositSlipNo))
					{
						// 入金引当マスタクラス(入金番号レベルで圧縮)に追加
						_depositAlw.Add(depositSlipNo, htOrderNoTani);

						// 新規にオーダーNO単位ハッシュテーブルを生成
						htOrderNoTani = new Hashtable();
					}

					// オーダーNO単位ハッシュテーブルに追加
					// htOrderNoTani.Add(depositAlw.AcceptAnOrderNo, depositAlw);   // 2007.10.05 del
                    // 売上伝票番号単位ハッシュテーブルに追加
                    htOrderNoTani.Add(depositAlw.SalesSlipNum, depositAlw);         // 2007.10.05 add

					depositSlipNo = depositAlw.DepositSlipNo;
				}
				// 最後の１件分を追加
				if (htOrderNoTani.Count != 0)
				{
					// 入金引当マスタクラス(入金番号レベルで圧縮)に追加
					_depositAlw.Add(depositSlipNo, htOrderNoTani);
				}
			}
		}
		
		/// <summary>
		/// 請求売上 保持用データクラス追加処理(初回検索分)
		/// </summary>
		/// <param name="arrDmdSales">請求売上クラス</param>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報を保持用データクラスへ展開します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void InsertDmdSalesSaveClass(ArrayList arrDmdSales)
		{
			// 請求売上マスタクラスに追加
			this._dmdSales = (ArrayList)arrDmdSales.Clone();
		}
		
		/// <summary>
		/// 請求売上 保持用データクラス追加処理(初回検索で読み込んでない分)
		/// </summary>
		/// <param name="arrDmdSales">請求売上クラス</param>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報を保持用データクラスへ展開します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void InsertDmdSalesSecondSaveClass(ArrayList arrDmdSales)
		{
            // ↓ 20070122 18322 c
			//// 請求売上マスタクラスに追加
			//foreach (SearchDmdSales searchDmdSales in arrDmdSales)
			//{
			//	this._dmdSalesSecond.Add(searchDmdSales);
			//}

			// 請求売上マスタクラスに追加
			foreach (SearchClaimSales searchClaimSales in arrDmdSales)
			{
				this._dmdSalesSecond.Add(searchClaimSales);
			}
            // ↑ 20070122 18322 c
		}
		
		/// <summary>
		/// 入金情報/引当情報 保持用データクラス更新処理
		/// </summary>
		/// <param name="arrDepsitMain">入金クラス</param>
		/// <param name="arrDepositAlw">入金引当クラス</param>
		/// <remarks>
		/// <br>Note　　　  : 入金情報/引当情報を保持用データクラスへ更新します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void UpdateDepositSaveClass(ArrayList arrDepsitMain, ArrayList arrDepositAlw)
		{
			// 入金情報データテーブル データセット処理
			foreach(SearchDepsitMain depsitMain in arrDepsitMain)
			{
				// 入金マスタクラスから削除
				_depsitMain.Remove(depsitMain.DepositSlipNo);

				// 入金マスタクラスに追加
				_depsitMain.Add(depsitMain.DepositSlipNo, depsitMain);


				if ((arrDepositAlw != null) && (arrDepositAlw.Count != 0))
				{
					// データ保存用 入金引当マスタ取得
					Hashtable htDepositAlw = (Hashtable)_depositAlw[depsitMain.DepositSlipNo];
			
					// 更新した入金引当データを順次取得
					foreach (SearchDepositAlw depositAlw in arrDepositAlw)
					{
						// 入金マスタと同一の入金番号の時
						if (depositAlw.DepositSlipNo == depsitMain.DepositSlipNo)
						{
							// 入金引当データの保持分が無い時は新規登録
							if (htDepositAlw == null)
							{
								htDepositAlw = new Hashtable();
								_depositAlw.Add(depsitMain.DepositSlipNo, htDepositAlw);
							}

							// 入金引当マスタクラスから削除
							// htDepositAlw.Remove(depositAlw.AcceptAnOrderNo);  // 2007.10.05 del
                            htDepositAlw.Remove(depositAlw.SalesSlipNum);        // 2007.10.05 add

				
							// 削除更新ではない時は追加する
							if (depositAlw.LogicalDeleteCode == 0)
							{
								// 入金引当マスタクラスへ追加
                                // htDepositAlw.Add(depositAlw.AcceptAnOrderNo, depositAlw);  // 2007.10.05 del
                                htDepositAlw.Add(depositAlw.SalesSlipNum, depositAlw);        // 2007.10.05 add
							}
						}
					}
				}

			}
		}

		/// <summary>
		/// 入金情報/引当情報 保持用データクラス削除処理
		/// </summary>
		/// <param name="depositSlipNo">入金番号</param>
		/// <remarks>
		/// <br>Note　　　  : 入金情報/引当情報を保持用データクラスから削除します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void DeleteDepositSaveClass(int depositSlipNo)
		{
			// 入金情報データテーブル データ削除処理
			_depsitMain.Remove(depositSlipNo);
			
			Hashtable htDepositAlw = (Hashtable)_depositAlw[depositSlipNo];
			if (htDepositAlw != null)
			{
				// 請求売上マスタクラス引当情報クリア処理
				this.ClearDmdSalesAllowance(htDepositAlw);

				// 入金引当情報データテーブル データ削除処理
				_depositAlw.Remove(depositSlipNo);
			}
		}

        // ↓ 20070131 18322 c MA.NS用に変更
        #region SF 請求売上情報DetaRowセット処理（全てコメントアウト）
		///// <summary>
		///// 請求売上情報DetaRowセット処理
		///// </summary>
		///// <param name="drNew">請求売上情報DataRow</param>
		///// <param name="dmdSales">請求売上クラス</param>
		///// <remarks>
		///// <br>Note　　　  : 請求売上情報をDataRowにセットします。</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void SetDmdSales(System.Data.DataRow drNew, SearchDmdSales dmdSales)
		//{
		//	// 引
		//	drNew[ctAlwCheck] = false;
		//
		//	// 請求売上赤黒区分/名称
		//	switch (dmdSales.DebitNoteDiv)
		//	{
		//		case 0:
		//			if (dmdSales.DebitNLnkAcptAnOdr == 0)
		//			{
		//				drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
		//				drNew[ctDmdSalesDebitNoteNm] = "黒";
		//			}
		//			else
		//			{
		//				drNew[ctDmdSalesDebitNoteCd] = 2;					// 相殺済み黒は2にすりかえる
		//				drNew[ctDmdSalesDebitNoteNm] = "相殺済み黒";
		//			}
		//			break;
		//		case 1:
		//			drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
		//			drNew[ctDmdSalesDebitNoteNm] = "赤";
		//			break;
		//	}
		//
		//	// 受注番号
		//	drNew[ctAcceptAnOrderNo] = dmdSales.AcceptAnOrderNo;
		//
		//	// 伝票番号
		//	drNew[ctSlipNo] = dmdSales.SlipNo;
		//
		//	if (System.DateTime.MinValue != dmdSales.SearchSlipDate)
		//	{
		//		// 伝票日付(表示用)
		//		drNew[ctSearchSlipDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", dmdSales.SearchSlipDate);
		//		
		//		// 伝票日付
		//		drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSales.SearchSlipDate);
		//	}
		//
		//	if (System.DateTime.MinValue != dmdSales.AddUpADate)
		//	{
		//		// 売上日
		//		drNew[ctAddUpADate] = TDateTime.DateTimeToLongDate(dmdSales.AddUpADate);
		//	}
		//
		//	// 受注ステータス
		//	drNew[ctAcptAnOdrStatus] = dmdSales.AcptAnOdrStatus;
		//	
		//	// 受注種類
		//	string str = "";
		//	if (depositRelDataAcs.IntroducedSystemCount == 1)
		//	{
		//		switch (Convert.ToInt32(drNew[ctAcptAnOdrStatus]))
		//		{
		//			case 10 : 
		//				str += "見積";
		//				break;
		//			case 20 : 
		//				str += "指示";
		//				break;
		//			case 30 : 
		//				str += "納品";
		//				break;
		//		}
		//	}
		//	else
		//	{
		//		switch (dmdSales.DataInputSystem)
		//		{
		//			case 0 : 
		//				str = "共:";
		//				break;
		//			case 1 : 
		//				str = "整:";
		//				break;
		//			case 2 : 
		//				str = "鈑:";
		//				break;
		//			case 3 : 
		//				str = "販:";
		//				break;
		//		}
		//		switch (Convert.ToInt32(drNew[ctAcptAnOdrStatus]))
		//		{
		//			case 10 : 
		//				str += "見";
		//				break;
		//			case 20 : 
		//				str += "指";
		//				break;
		//			case 30 : 
		//				str += "納";
		//				break;
		//		}
		//	}
		//	drNew[ctSalesKind] = str;
		//
		//	// 売上名称
		//	drNew[ctSalesName] = dmdSales.SalesName;
		//
		//	// 登録番号
		//	drNew[ctNumberPlate] = CarInfoCalculation.GetNumberPlateString(dmdSales.CarMngNo, dmdSales.NumberPlate1Code, dmdSales.NumberPlate1Name, dmdSales.NumberPlate2, dmdSales.NumberPlate3, dmdSales.NumberPlate4);
		//
		//	// 受注売上額  受注売上計＋受注消費税額
		//	drNew[ctAcceptAnOrderSales] = dmdSales.AcceptAnOrderSales + dmdSales.AcceptAnOrderConsTax;
		//
		//	// 諸費用額  諸費用金額計＋諸費用消費税額
		//	drNew[ctTotalVariousCost] = dmdSales.TotalVariousCost + dmdSales.VarCstConsTax;
		//
		//	// 受注合計額
		//	drNew[ctTotalSales] = Convert.ToInt64(drNew[ctAcceptAnOrderSales]) + Convert.ToInt64(drNew[ctTotalVariousCost]);
		//
		//	// 引当額 受注 (入金引当マスタ)  ※後から引当マスタよりセット
		//	drNew[ctAcpOdrDepositAlwc_Alw] = 0;
		//
		//	// 引当残 受注 (請求売上マスタ)
		//	drNew[ctAcpOdrDepoAlwcBlnce_Sales] = dmdSales.AcpOdrDepoAlwcBlnce;
		//
		//	// 引当済 受注 (請求売上マスタ)
		//	drNew[ctAcpOdrDepositAlwc_Sales] = dmdSales.AcpOdrDepositAlwc;
		//
		//	// 引当額 諸費用 (入金引当マスタ)  ※後から引当マスタよりセット
		//	drNew[ctVarCostDepoAlwc_Alw] = 0;
		//
		//	// 引当残 諸費用 (請求売上マスタ)
		//	drNew[ctVarCostDepoAlwcBlnce_Sales] = dmdSales.VarCostDepoAlwcBlnce;
		//
		//	// 引当済 諸費用 (請求売上マスタ)
		//	drNew[ctVarCostDepoAlwc_Sales] = dmdSales.VarCostDepoAlwc;
		//
		//	// 引当額 共通 (入金引当マスタ)  ※後から引当マスタよりセット
		//	drNew[ctDepositAllowance_Alw] = 0;
		//
		//	// 引当残 共通 (請求売上マスタ)
		//	drNew[ctDepositAlwcBlnce_Sales] = dmdSales.DepositAlwcBlnce;
		//
		//	// 引当済 共通 (請求売上マスタ)
		//	drNew[ctDepositAllowance_Sales] = dmdSales.DepositAllowance;
		//
		//	// 自身のDataRow
		//	drNew[ctSalesDataRow] = drNew;
		//}
		#endregion

        /// <summary>
		/// 請求売上情報DetaRowセット処理
		/// </summary>
		/// <param name="drNew">請求売上情報DataRow</param>
		/// <param name="dmdSales">請求売上クラス</param>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報をDataRowにセットします。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// <br>Update Date : 2007.03.27 18322 T.Kimura 請求売上赤黒区分にnullが入らないように修正</br>
        /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)
        /// <br>              項目「引当」を追加する。</br>
        /// <br>Update Date : 2011/02/09 李占川</br>
        /// <br>              Redmine#18848を修正する。</br>
        /// <br>Update Date : 2011/07/22 施炳中</br>
        /// <br>              表示不具合の為改善願います。</br>
        /// </remarks>
		private void SetClaimSales(DataRow drNew, SearchClaimSales dmdSales)
		{
			// 引
			drNew[ctAlwCheck] = false;

			// 請求売上赤黒区分/名称
			switch (dmdSales.DebitNoteDiv)
			{
				case 0:
                    // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                    //if (dmdSales.DebitNLnkAcptAnOdr == 0)
                    //{
                    //    drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
                    //    drNew[ctDmdSalesDebitNoteNm] = "黒";
                    //}
                    //else
                    //{
                    //    drNew[ctDmdSalesDebitNoteCd] = 2;					// 相殺済み黒は2にすりかえる
                    //    drNew[ctDmdSalesDebitNoteNm] = "相殺済み黒";
                    //}
                    drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
                    drNew[ctDmdSalesDebitNoteNm] = "黒";
                    // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
					break;
				case 1:
					drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
					drNew[ctDmdSalesDebitNoteNm] = "赤";
					break;
                // ↓ 20070327 18322 a nullが入らないように修正
                case 2:
					drNew[ctDmdSalesDebitNoteCd] = 2;
        			drNew[ctDmdSalesDebitNoteNm] = "相殺済み黒";
                    break;
                // ↑ 20070327 18322 a
			}

			// 受注番号
			// drNew[ctAcceptAnOrderNo] = dmdSales.AcceptAnOrderNo;   // 2007.10.05 hikita del

            // 売上伝票番号
            drNew[ctSalesSlipNum] = dmdSales.SalesSlipNum;

            if (System.DateTime.MinValue != dmdSales.SalesDate)
			{
                // ↓ 20070418 18322 c MA.NS対応
				//// 伝票日付(表示用)
				//drNew[ctSearchSlipDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", dmdSales.SearchSlipDate);

				// 伝票日付(表示用)
                //drNew[ctSearchSlipDateDisp] = dmdSales.SearchSlipDate.ToString("yyyy/MM/dd");
                drNew[ctSearchSlipDateDisp] = dmdSales.SalesDate.ToString("yyyy/MM/dd");
                // ↑ 20070418 18322 c
				
				// 伝票日付
                //drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSales.SearchSlipDate);
                drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSales.SalesDate);
			}

			if (System.DateTime.MinValue != dmdSales.AddUpADate)
			{
				// 売上日
				drNew[ctAddUpADate] = TDateTime.DateTimeToLongDate(dmdSales.AddUpADate);
			}
		
			// 受注ステータス
			drNew[ctAcptAnOdrStatus] = dmdSales.AcptAnOdrStatus;

            string str;

            // 受注ステータス名
            str = "";
            switch (dmdSales.AcptAnOdrStatus)
            {
                case 10: str = "見積"          ; break;
                case 20: str = "受注"          ; break;
                case 30: str = "売上"          ; break;
                case 40: str = "出荷"          ; break;
            }
            drNew[ctAcptAnOdrStatusNm] = str;

            // 伝票種類（売上伝票区分）
            str = "";
            switch (dmdSales.SalesSlipCd)
            {
                case 0: str = "売上"; break; 
                case 1: str = "返品"; break; 
                case 2: str = "値引"; break; 
            }
            drNew[ctSalesKind] = str;

            //// 売上名称
            //str = "";
            //switch (dmdSales.SalesFormal)
            //{
            //    case 10: str = "店頭売上"      ; break;
            //    case 11: str = "外販"          ; break;
            //    case 20: str = "業務販売(売切)"; break;
            //    case 25: str = "売切計上"      ; break;
            //    case 30: str = "委託"          ; break;
            //    case 35: str = "委託計上"      ; break;
            //}
            //drNew[ctSalesName] = str;

			// 伝票合計
            if ((this._consTaxLayMethod == 2) || (this._consTaxLayMethod == 3) || (this._consTaxLayMethod == 9))
            {
                // 税抜き
                drNew[ctTotalSales] = dmdSales.SalesTotalTaxExc;

                // --- UPD 2011/02/09 ---------->>>>>
                // 引当残 共通 (請求売上マスタ)
                //if (dmdSales.DepositAllowanceTtl != 0)
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxExc - dmdSales.DepositAllowanceTtl;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxExc - dmdSales.DepositAllowanceTtl;
                //}
                //else
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = 0;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = 0;
                //}
                drNew[ctDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxExc - dmdSales.DepositAllowanceTtl;
                drNew[ctBfDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxExc - dmdSales.DepositAllowanceTtl;
                // --- UPD 2011/02/09  ----------<<<<<
            }
            else
            {
                // 税込み
                drNew[ctTotalSales] = dmdSales.SalesTotalTaxInc;

                // --- UPD 2011/02/09 ---------->>>>>
                // 引当残 共通 (請求売上マスタ)
                //if (dmdSales.DepositAllowanceTtl != 0)
                //{
                    //drNew[ctDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxInc - dmdSales.DepositAllowanceTtl;
                    //drNew[ctBfDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxInc - dmdSales.DepositAllowanceTtl;
                //}
                //else
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = 0;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = 0;
                //}
                drNew[ctDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxInc - dmdSales.DepositAllowanceTtl;
                drNew[ctBfDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxInc - dmdSales.DepositAllowanceTtl;
                // --- UPD 2011/02/09  ----------<<<<<
            }

			// 引当額 共通 (入金引当マスタ)  ※後から引当マスタよりセット
			drNew[ctDepositAllowance_Alw] = 0;
            
   			// 引当済 共通 (請求売上マスタ)
            drNew[ctDepositAllowance_Sales] = dmdSales.DepositAllowanceTtl;
            drNew[ctBfDepositAllowance_Sales] = dmdSales.DepositAllowanceTtl;

            // -- UPD 2011/07/22 ------->>>>>
            // 伝票備考
            drNew[ctSlipNote] = dmdSales.SlipNote.Trim() + " " + dmdSales.SlipNote2.Trim() + " " + dmdSales.SlipNote3.Trim();

            // 最終月次締め日
            drNew[ctLastMonthlyDate] = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay);

            // 計上日付と前回締次更新の比較
            if (drNew[ctAddUpADate] != System.DBNull.Value)
            {
                if ((Convert.ToInt32(drNew[ctAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                    (Convert.ToInt32(drNew[ctAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay)))
                {
                    // 計上日付が前回請求締め日以前か、前回月次更新日以前のときは、締め済み
                    drNew[ctSalesClosedFlg] = "〆";

                    if (this._lastAddUpDay > this._lastMonthlyAddUpDay)
                    {
                        drNew[ctLastMonthlyDateDisp] = this._lastAddUpDay.ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        drNew[ctLastMonthlyDateDisp] = this._lastMonthlyAddUpDay.ToString("yyyy/MM/dd");
                    }
                }
            }
            // -- UPD 2011/07/22 ------->>>>>

            // --- ADD 2010/12/20 ---------->>>>>
            // 売上伝票番号
            drNew[ctDepSaleSlipNum] = dmdSales.DepSalesSlipNum;

            // 引当
            if ((long)drNew[ctDepositAlwcBlnce_Sales] == 0 && !string.IsNullOrEmpty(dmdSales.DepSalesSlipNum))
            {
                // №1:入金引当残高(DepositAlwcBlnce)＝0かつ「関連付く入金伝票がある」場合
                drNew[ctAllowDiv] = "済";
            }
            else if (dmdSales.DepositAllowanceTtl != 0)
            {
                // №2:№1以外で、入金引当合計額(DepositAllowanceTtl)≠0
                drNew[ctAllowDiv] = "一部";
            }
            else
            {
                // №1以外かつ№2以外場合
                drNew[ctAllowDiv] = "";
            }
            // --- ADD 2010/12/20  ----------<<<<<

            // 請求先コード
            drNew[ctClaimCode] = dmdSales.ClaimCode;

            // 請求先名称
            drNew[ctClaimName] = dmdSales.ClaimName;

            // 請求先名称2
            drNew[ctClaimName2] = dmdSales.ClaimName2;

            // 請求先略称
            drNew[ctClaimSnm] = dmdSales.ClaimSnm;

            // 得意先コード
            drNew[ctCustomerCode] = dmdSales.CustomerCode;

            // 得意先名称
            drNew[ctCustomerName] = dmdSales.CustomerName;

            // 得意先名称2
            drNew[ctCustomerName2] = dmdSales.CustomerName2;

            // 得意先略称
            drNew[ctCustomerSnm] = dmdSales.CustomerSnm;

            // ↓ 20070525 18322 a
            // 売掛区分(0:売掛なし,1:売掛)
            drNew[ctAccRecDivCd] = dmdSales.AccRecDivCd;

            //// 2007.10.05 hikita del start ----------------------------------------->>
            //if (System.DateTime.MinValue == dmdSales.RegiProcDate)
            //{
            //    // レジ処理日
            //    drNew[ctRegiProcDate] = "";
            //}
            //else
            //{
            //    // レジ処理日
            //    drNew[ctRegiProcDate] = dmdSales.RegiProcDate.ToString("yyyy/MM/dd");
            //}

            //// レジ番号
            //drNew[ctCashRegisterNo] = dmdSales.CashRegisterNo;

            //// POSレシート番号
            //drNew[ctPosReceiptNo]   = dmdSales.PosReceiptNo;
            // ↑ 20070525 18322 a
            // 2007.10.05 hikita del end --------------------------------------------<<

			// 自身のDataRow
			drNew[ctSalesDataRow] = drNew;
		}
		// ↑ 20070131 18322 c

		/// <summary>
		/// 入金情報DetaSet締次更新フラグセット処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 入金情報DataSetの締次更新フラグをセットします。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDepositDataSetClosedFlg()
		{
			foreach (DataRow dr in this._dsDepositInfo.Tables[ctDepositDataTable].Rows)
			{
				// 計上日付
                if ((Convert.ToInt32(dr[ctDepositAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                    (Convert.ToInt32(dr[ctDepositAddUpADate]) <= this.GetLastMonthlyDate()))
				{
                    // 請求締め済みか月次締めのとき
					dr[ctDepositClosedFlg] = "〆";
				}
			}
		}

        // --------- ADD 王君　2012/12/24　Redmine#33741 ----->>>>>
        /// <summary>
        /// 入金情報DetaSet締次更新フラグセット処理
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 入金情報DataSetの締次更新フラグをセットします。</br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void SetDepositGuidDataSetClosedFlg()
        {
            foreach (DataRow dr in this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows)
            {
                // 計上日付
                if ((Convert.ToInt32(dr[ctDepositAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                    (Convert.ToInt32(dr[ctDepositAddUpADate]) <= this.GetLastMonthlyDate()))
                {
                    // 請求締め済みか月次締めのとき
                    dr[ctDepositClosedFlg] = "〆";
                }
            }
        }
        /// <summary>
        /// 入金情報DetaSet締次更新DataRow削除処理得意先入力ないの場合
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 入金情報DataSetの締次更新DataRowを削除します。</br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void SetDepositGuidDataRemoveByMonth()
        {
            for (int i = this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows.Count - 1; i >= 0; i--)
            {
                string data = this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows[i][ctDepositAddUpADate].ToString();
                //計上日付
                if ((Convert.ToInt32(data) <= this.GetLastMonthlyDate()))
                {
                    this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows[i].Delete();
                }
            }
            this._dsDepositInfo.Tables[ctDepositGuidDataTable].AcceptChanges();
        }

        /// <summary>
        /// 入金情報DetaSet締次更新DataRow削除処理(得意先入力の場合)
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 入金情報DataSetの締次更新DataRowを削除します。</br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void SetDepositGuidDataRemove()
        {
            for (int i = this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows.Count - 1; i >= 0; i--)
            {
                string data = this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows[i][ctDepositAddUpADate].ToString();
                //計上日付
                if ((Convert.ToInt32(data) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                        (Convert.ToInt32(data) <= this.GetLastMonthlyDate()))
                {
                    this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows[i].Delete();
                }
            }
            this._dsDepositInfo.Tables[ctDepositGuidDataTable].AcceptChanges();
        }
        // --------- ADD 王君　2012/12/24　Redmine#33741 -----<<<<<

		/// <summary>
		/// 請求売上情報DetaSet締次更新フラグセット処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報DataSetの締次更新フラグをセットします。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDmdSalesDataSetClosedFlg()
		{
			foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
                // ↓ 20070202 18322 c MA.NS用に変更
				//// 計上日付 かつ 精算伝票
				//if ((dr[ctAddUpADate] != System.DBNull.Value) &&
				//    (Convert.ToInt32(dr[ctAddUpADate]) <= _depositCustomer.CAddUpUpdDate) &&
				//	(Convert.ToInt32(dr[ctAcptAnOdrStatus]) == 30))
				//{
				//	dr[ctSalesClosedFlg] = "〆";
				//}

                if (dr[ctAddUpADate] != System.DBNull.Value)
                {
                    if ((Convert.ToInt32(dr[ctAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                        (Convert.ToInt32(dr[ctAddUpADate]) <= this.GetLastMonthlyDate()))
                    {
        				// 計上日付以前
                        switch (Convert.ToInt32(dr[ctAcptAnOdrStatus]))
                        {
                            case 30 :    // 売上
                            //case 40 :    // 売切                 // 2007.10.05 del
                            //case 55 :    // 委託計上             // 2007.10.05 del
             					dr[ctSalesClosedFlg] = "〆";
                                break;
                            default :
                                // 上記以外の伝票
         		    			dr[ctSalesClosedFlg] = "";
                                break;
                        }
                    }
                }
                // ↑ 20070202 18322 c

			}
		}
		
		/// <summary>
		/// 請求売上情報DetaSet入金引当情報クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報DataSetより入金引当情報をクリアします。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void DmdSalesDepositAllowanceClear()
		{
			foreach (DataRow dr in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// 引
				dr[ctAlwCheck] = false;

                // ↓ 20070118 18322 d MA.NS用に変更
				//// 引当額 受注 (入金引当マスタ)
				//dr[ctAcpOdrDepositAlwc_Alw] = 0;
                //
				//// 引当額 諸費用 (入金引当マスタ)
				//dr[ctVarCostDepoAlwc_Alw] = 0;
                // ↑ 20070118 18322 d

				// 引当額 共通 (入金引当マスタ)
				dr[ctDepositAllowance_Alw] = 0;
			}
        }

        #region DEL 2008/06/26 使用していないのでコメントアウト
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 引当情報変更処理
		/// </summary>
		/// <param name="depositAllowance">入金引当額</param>
		/// <param name="drDmdSales">請求売上情報DataRow</param>
		/// <param name="drDeposit">入金情報DataRow</param>
		/// <param name="drAllowance">引当情報DataRow</param>
		/// <remarks>
		/// <br>Note　　　  : 引当情報の引当額を更新します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void UpdateAllowance(Int64 depositAllowance, DataRow drDmdSales, DataRow drDeposit, ref ArrayList drAllowance)
		{
			// 引当情報DataRowの取得
			foreach (DataRow drChild in drAllowance)
			{
				// 同一受注番号の時
				// if (Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw]) == Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo]))  // 2007.10.05 del

                // 同一売上番号の時
                if (Convert.ToString(drChild[ctSalesSlipNum_Alw]) == Convert.ToString(drDmdSales[ctSalesSlipNum]))         // 2007.10.05 add
				{
					if (depositAllowance == 0)
					{
						// 引当額0円の時は削除
						drAllowance.Remove(drChild);
					}
					else
					{
						// 引当額の更新
						drChild[ctDepositAllowance] = depositAllowance;
					}

					return;
				}
			}

			// 同一受注番号行が無くても引当額0円の時は新規行は追加せずに無視する
			if (depositAllowance == 0) return;

            // ↓ 20070202 18322 c MA.NS用に変更
			//// 引当情報新規行追加処理  引当情報DataRowが無い時は新規として追加する
			//DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDeposit[ctDepositSlipNo]), Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo]), Convert.ToInt32(drDeposit[ctDepositDate]));

			// 引当情報新規行追加処理  引当情報DataRowが無い時は新規として追加する
            DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDmdSales[ctAcptAnOdrStatus_Alw])
                                                   , Convert.ToInt32(drDeposit[ctDepositSlipNo])
            //                                       , Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo])  // 2007.10.05 del
                                                   , drDmdSales[ctSalesSlipNum].ToString()
            //                                       , Convert.ToInt32(drDeposit[ctDepositDate]));     // 2007.10.05 del
                                                   , Convert.ToInt32(drDeposit[ctDepositAddUpADate])); // 2007.10.05 add

            // ↑ 20070202 18322 c

			// 入金引当額
			drNewAlw[ctDepositAllowance] = depositAllowance;

			// 新規追加
			drAllowance.Add(drNewAlw);
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 使用していないのでコメントアウト

        /// <summary>
		/// 読込時入金マスタ・入金引当マスタ取得処理
		/// </summary>
		/// <param name="depositSlipNo">入金番号</param>
		/// <param name="depsitMain">入金マスタ</param>
		/// <param name="htDepositAlw">入金引当マスタ</param>
		/// <remarks>
		/// <br>Note       : 入金番号を元に、読込時の入金マスタ/入金引当マスタを取得します。
		///                : エラー時はDepositException例外が発生します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void GetBeforeDepositData(int depositSlipNo, out SearchDepsitMain depsitMain, out Hashtable htDepositAlw)
		{
			// データ保存用 入金マスタ取得
			depsitMain = ((SearchDepsitMain)_depsitMain[depositSlipNo]).Clone();

			// データ保存用 入金引当マスタ取得
			if (_depositAlw[depositSlipNo] != null)
			{
				htDepositAlw = (Hashtable)((Hashtable)_depositAlw[depositSlipNo]).Clone();
			}
			else
			{
				htDepositAlw = new Hashtable();
			}

			// 入金マスタが無い時は例外を発生させる
			if (depsitMain == null)
			{
				throw new DepositException("読込時の入金伝票取得に失敗しました。", (int)ConstantManagement.DB_Status.ctDB_ERROR);
			}

		}

        // ↓ 20070131 18322 c MA.NS用に変更
        #region SF 入金マスタ・入金引当マスタ更新内容セット処理（全てコメントアウト）
		///// <summary>
		///// 入金マスタ・入金引当マスタ更新内容セット処理
		///// </summary>
		///// <param name="updateMode">更新モード</param>
		///// <param name="loginSectionCode">ログイン拠点コード</param>
		///// <param name="addSectionCode">更新拠点コード</param>
		///// <param name="customerCode">得意先コード</param>
		///// <param name="aftDepositRow">入金マスタ(変更内容)</param>
		///// <param name="aftAllowanceRows">入金引当マスタ(変更内容)</param>
		///// <param name="depsitMain">入金マスタ</param>
		///// <param name="htDepositAlw">入金引当マスタ</param>
		///// <remarks>
		///// <br>Note       : 入金マスタ/入金引当マスタの内容を読込時データより更新用データに変換します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//private void SetUpdateDepositData1(UpdateMode updateMode, string loginSectionCode, string addSectionCode, int customerCode, System.Data.DataRow aftDepositRow, ArrayList aftAllowanceRows, ref SearchDepsitMain depsitMain, ref Hashtable htDepositAlw)
		//{
		//
		//	// --- 入金マスタ --- //
		//
		//	// 新規登録の時
		//	if (updateMode == UpdateMode.Insert)
		//	{
		//		// 企業コード
		//		depsitMain.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		//
		//		// 得意先コード
		//		depsitMain.CustomerCode = customerCode;
		//
		//		// 入金入力拠点コード
		//		depsitMain.InputDepositSecCd = loginSectionCode;
		//
		//		// 計上拠点コード
		//		depsitMain.AddUpSecCode = addSectionCode;
		//	}
		//
		//	// 論理削除区分
		//	depsitMain.LogicalDeleteCode = 0;
		//
		//	// 入金赤黒区分
		//	depsitMain.DepositDebitNoteCd = 0;
		//
		//	// 入金金種コード
		//	depsitMain.DepositKindCode = Convert.ToInt32(aftDepositRow[ctDepositKindCode]);
		//	
		//	// 入金金種名称
		//	depsitMain.DepositKindName = aftDepositRow[ctDepositKindName].ToString();
		//
		//	// 入金金種区分
		//	depsitMain.DepositKindDivCd = Convert.ToInt32(aftDepositRow[ctDepositKindDivCd]);;
		//
		//	// 預り金区分
		//	depsitMain.DepositCd = Convert.ToInt32(aftDepositRow[ctDepositCd]);
		//
		//	// 受注 入金額
		//	depsitMain.AcpOdrDeposit = Convert.ToInt64(aftDepositRow[ctAcpOdrDeposit]);
		//
		//	// 受注 手数料
		//	depsitMain.AcpOdrChargeDeposit = Convert.ToInt64(aftDepositRow[ctAcpOdrChargeDeposit]);
		//
		//	// 受注 値引
		//	depsitMain.AcpOdrDisDeposit = Convert.ToInt64(aftDepositRow[ctAcpOdrDisDeposit]);
		//
		//	// 諸費用 入金額
		//	depsitMain.VariousCostDeposit = Convert.ToInt64(aftDepositRow[ctVariousCostDeposit]);
		//
		//	// 諸費用 手数料
		//	depsitMain.VarCostChargeDeposit = Convert.ToInt64(aftDepositRow[ctVarCostChargeDeposit]);
		//
		//	// 諸費用 値引
		//	depsitMain.VarCostDisDeposit = Convert.ToInt64(aftDepositRow[ctVarCostDisDeposit]);
		//
		//	// 共通 入金額
		//	depsitMain.Deposit = Convert.ToInt64(aftDepositRow[ctDeposit]);
		//
		//	// 共通 手数料
		//	depsitMain.FeeDeposit = Convert.ToInt64(aftDepositRow[ctFeeDeposit]);
		//
		//	// 共通 値引
		//	depsitMain.DiscountDeposit = Convert.ToInt64(aftDepositRow[ctDiscountDeposit]);
		//
		//	// 共通 入金計
		//	depsitMain.DepositTotal = Convert.ToInt64(aftDepositRow[ctDepositTotal]);
		//
		//	// 入金引当額 受注
		//	depsitMain.AcpOdrDepositAlwc = Convert.ToInt64(aftDepositRow[ctAcpOdrDepositAlwc_Deposit]);
		//
		//	// 入金引当残 受注
		//	depsitMain.AcpOdrDepoAlwcBlnce = Convert.ToInt64(aftDepositRow[ctAcpOdrDepoAlwcBlnce_Deposit]);
		//
		//	// 入金引当額 諸費用
		//	depsitMain.VarCostDepoAlwc = Convert.ToInt64(aftDepositRow[ctVarCostDepoAlwc_Deposit]);
		//
		//	// 入金引当残 諸費用
		//	depsitMain.VarCostDepoAlwcBlnce = Convert.ToInt64(aftDepositRow[ctVarCostDepoAlwcBlnce_Deposit]);
		//
		//	// 入金引当額 共通
		//	depsitMain.DepositAllowance = Convert.ToInt64(aftDepositRow[ctDepositAllowance_Deposit]);
		//
		//	// 入金引当残 共通
		//	depsitMain.DepositAlwcBlnce = Convert.ToInt64(aftDepositRow[ctDepositAlwcBlnce_Deposit]);
		//
		//	// 摘要
		//	depsitMain.Outline = aftDepositRow[ctOutline].ToString();
		//
		//	// 入金日付
		//	depsitMain.DepositDate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDepositDate])); 
		//
		//	// 計上日付
		//	depsitMain.AddUpADate = depsitMain.DepositDate; 
		//
		//	// 更新拠点コード
		//	depsitMain.UpdateSecCd = loginSectionCode;
		//
		//	// 入金担当者コード
		//	depsitMain.DepositAgentCode = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;
		//
		//	// クレジット/ローン区分
		//	depsitMain.CreditOrLoanCd = Convert.ToInt32(aftDepositRow[ctCreditOrLoanCd]);
		//
		//	// クレジット会社コード
		//	depsitMain.CreditCompanyCode = aftDepositRow[ctCreditCompanyCode].ToString();
		//
		//	// 手形振出日
		//	depsitMain.DraftDrawingDate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDraftDrawingDate])); 
		//
		//	// 手形支払期日
		//	depsitMain.DraftPayTimeLimit = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDraftPayTimeLimit])); 
		//
		//	// 赤黒入金連結番号
		//	depsitMain.DebitNoteLinkDepoNo = 0;
		//
		//
		//	// --- 入金引当マスタ 新規/更新 --- //
		//	UpdateMode allowanceUpdateMode = 0;
		//	foreach (System.Data.DataRow dr in aftAllowanceRows)
		//	{
		//		// 同一受注番号の引当を取得
		//		SearchDepositAlw depositAlw = (SearchDepositAlw)htDepositAlw[Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw])];
		//
		//		// ハッシュテーブルに無い時は新規扱い
		//		if (depositAlw == null)
		//		{
		//			// 新規モード
		//			allowanceUpdateMode = UpdateMode.Insert;
		//			depositAlw = new SearchDepositAlw();
		//			htDepositAlw.Add(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]), depositAlw);
		//		}
		//		else
		//		{
		//			// 以下の項目が変わらない時
		//			// 1.受注入金引当額, 2.諸費用入金引当額, 3.金種コード, 4.入金日付, 5.赤伝相殺区分, 6.預り金区分, 7.クレジット区分, 8.消込み日, 9.消込み計上日
		//			if ((depositAlw.AcpOdrDepositAlwc == Convert.ToInt64(dr[ctAcpOdrDepositAlwc])) &&
		//				(depositAlw.VarCostDepoAlwc == Convert.ToInt64(dr[ctVarCostDepoAlwc])) &&
		//				(depositAlw.DepositKindCode == depsitMain.DepositKindCode) &&
		//				(depositAlw.DepositInputDate == depsitMain.DepositDate) &&
		//				(depositAlw.DebitNoteOffSetCd == depsitMain.DepositDebitNoteCd) &&
		//				(depositAlw.DepositCd == depsitMain.DepositCd) &&
		//				(depositAlw.CreditOrLoanCd == depsitMain.CreditOrLoanCd) &&
		//				(depositAlw.ReconcileDate == TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileDate]))) &&
		//				(depositAlw.ReconcileAddUpDate == TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileAddUpDate]))))
		//			{
		//				// 変更無しはハッシュテーブルより削除
		//				htDepositAlw.Remove(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]));
		//				continue;
		//			}
		//
		//			// 更新モード
		//			allowanceUpdateMode = UpdateMode.Update;
		//		}
		//
		//		
		//		// 新規登録の時
		//		if (allowanceUpdateMode == UpdateMode.Insert)
		//		{
		//			// 企業コード
		//			depositAlw.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		//
		//			// 得意先コード
		//			depositAlw.CustomerCode = customerCode;
		//
		//			// 計上拠点コード
		//			depositAlw.AddUpSecCode = addSectionCode;
		//
		//			// 入金番号
		//			depositAlw.DepositSlipNo = depsitMain.DepositSlipNo;
		//		}
		//
		//		// 受注伝票番号
		//		depositAlw.AcceptAnOrderNo = Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]);
		//
		//		// 入金金種コード
		//		depositAlw.DepositKindCode = depsitMain.DepositKindCode;
		//
		//		// 入金日付
		//		depositAlw.DepositInputDate = depsitMain.DepositDate;
		//
		//		// 入金引当額 受注
		//		depositAlw.AcpOdrDepositAlwc = Convert.ToInt64(dr[ctAcpOdrDepositAlwc]);
		//
		//		// 入金引当額 諸費用
		//		depositAlw.VarCostDepoAlwc = Convert.ToInt64(dr[ctVarCostDepoAlwc]);
		//
		//		// 入金引当額 共通
		//		depositAlw.DepositAllowance = Convert.ToInt64(dr[ctDepositAllowance]);
		//
		//		// 引当日
		//		depositAlw.ReconcileDate = TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileDate])); 
		//
		//		// 引当計上日付
		//		depositAlw.ReconcileAddUpDate = TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileAddUpDate]));
		//
		//		// 赤伝相殺区分
		//		depositAlw.DebitNoteOffSetCd = depsitMain.DepositDebitNoteCd; 
		//
		//		// 預り金区分
		//		depositAlw.DepositCd = depsitMain.DepositCd;
		//
		//		// クレジット/ローン区分
		//		depositAlw.CreditOrLoanCd = depsitMain.CreditOrLoanCd;
		//	}
		//
		//	// --- 入金引当マスタ 削除 --- //
		//	foreach (DictionaryEntry myDE in htDepositAlw)
		//	{
		//		SearchDepositAlw depositAlw = (SearchDepositAlw)myDE.Value;
		//		allowanceUpdateMode = UpdateMode.Delete;
		//		foreach (System.Data.DataRow dr in aftAllowanceRows)
		//		{
		//			if (depositAlw.AcceptAnOrderNo == Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]))
		//			{
		//				allowanceUpdateMode = UpdateMode.Update;
		//				break;
		//			}
		//		}
		//
		//		// DataRowにハッシュテーブルのレコードが無い時は削除されたとみなす
		//		if (allowanceUpdateMode == UpdateMode.Delete)
		//		{
		//			depositAlw.LogicalDeleteCode = 1;
		//		}
		//	}
		//}
        #endregion

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 入金マスタ・入金引当マスタ更新内容セット処理
		/// </summary>
		/// <param name="updateMode">更新モード</param>
		/// <param name="loginSectionCode">ログイン拠点コード</param>
		/// <param name="addSectionCode">更新拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="aftDepositRow">入金マスタ(変更内容)</param>
		/// <param name="aftAllowanceRows">入金引当マスタ(変更内容)</param>
		/// <param name="depsitMain">入金マスタ</param>
		/// <param name="htDepositAlw">入金引当マスタ</param>
		/// <remarks>
		/// <br>Note       : 入金マスタ/入金引当マスタの内容を読込時データより更新用データに変換します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SetUpdateDepositData1(UpdateMode updateMode, string loginSectionCode, string addSectionCode, int customerCode, int claimCode, DataRow aftDepositRow, ArrayList aftAllowanceRows, ref SearchDepsitMain depsitMain, ref Hashtable htDepositAlw)
		{
            //==========================================//
			// ---            入金マスタ            --- //
            //==========================================//

			// 新規登録の時
			if (updateMode == UpdateMode.Insert)
			{
				// 企業コード
				depsitMain.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // 請求先コード
                depsitMain.ClaimCode = claimCode;

                // 請求先名1
                depsitMain.ClaimName = this._depositCustomer.CName;

                // 請求先名2
                depsitMain.ClaimName2 = this._depositCustomer.CName2;

                // 請求先略称
                depsitMain.ClaimSnm = this._depositCustomer.CSnm;

				// 得意先コード
				depsitMain.CustomerCode = customerCode;

                // 得意先名1
                depsitMain.CustomerName = this._depositCustomer.Name;

                // 得意先名2
                depsitMain.CustomerName2 = this._depositCustomer.Name2;

                // 得意先略称
                depsitMain.CustomerSnm = this._depositCustomer.CSnm;

				// 入金入力拠点コード
				depsitMain.InputDepositSecCd = loginSectionCode;

				// 計上拠点コード
				depsitMain.AddUpSecCode = addSectionCode;
			}

			// 論理削除区分
			depsitMain.LogicalDeleteCode = 0;

			// 入金赤黒区分
			depsitMain.DepositDebitNoteCd = 0;

            // 入金金種コード
            depsitMain.DepositKindCode = Convert.ToInt32(aftDepositRow[ctDepositKindCode]);

            // 入金金種名称
            depsitMain.DepositKindName = aftDepositRow[ctDepositKindName].ToString();

            // 入金金種区分
            depsitMain.DepositKindDivCd = Convert.ToInt32(aftDepositRow[ctDepositKindDivCd]);
            
			// 預り金区分
            depsitMain.DepositCd = Convert.ToInt32(aftDepositRow[ctDepositCd]);

			// 共通 入金額
			depsitMain.Deposit = Convert.ToInt64(aftDepositRow[ctDeposit]);

			// 共通 手数料
			depsitMain.FeeDeposit = Convert.ToInt64(aftDepositRow[ctFeeDeposit]);

			// 共通 値引
			depsitMain.DiscountDeposit = Convert.ToInt64(aftDepositRow[ctDiscountDeposit]);

			// 共通 インセンティブ
			// depsitMain.RebateDeposit = Convert.ToInt64(aftDepositRow[ctRebateDeposit]);    // 2007.10.05 hikita del

            // 共通 入金計
            depsitMain.DepositTotal = Convert.ToInt64(aftDepositRow[ctDepositTotal]);
            
            // 入金引当額 共通
			depsitMain.DepositAllowance = Convert.ToInt64(aftDepositRow[ctDepositAllowance_Deposit]);

			// 入金引当残 共通
			depsitMain.DepositAlwcBlnce = Convert.ToInt64(aftDepositRow[ctDepositAlwcBlnce_Deposit]);
            
			// 摘要
			depsitMain.Outline = aftDepositRow[ctOutline].ToString();

            // 受注ステータス
            depsitMain.AcptAnOdrStatus = Convert.ToInt32(aftDepositRow[ctDepositAcptAnOdrStatus]);                   // 2007.10.05 add

			// 入金日付
			// depsitMain.DepositDate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDepositDate])); // 2007.10.05 del
            depsitMain.DepositDate = DateTime.Today;                                                                 // 2007.10.05 add
                
			// 計上日付
			//depsitMain.AddUpADate = depsitMain.DepositDate;                                                            // 2007.10.05 del
            depsitMain.AddUpADate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDepositAddUpADate]));   // 2007.10.05 add

			// 更新拠点コード
			depsitMain.UpdateSecCd = loginSectionCode;

			// 入金担当者コード
			depsitMain.DepositAgentCode = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;

            // 入金担当者名
			depsitMain.DepositAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;

			// クレジット/ローン区分
			// depsitMain.CreditOrLoanCd = Convert.ToInt32(aftDepositRow[ctCreditOrLoanCd]);   // 2007.10.05 hikita del

			// クレジット会社コード
			// depsitMain.CreditCompanyCode = aftDepositRow[ctCreditCompanyCode].ToString();   // 2007.10.05 hikita del

			// 手形振出日
			depsitMain.DraftDrawingDate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDraftDrawingDate]));

            // 手形支払期日
            depsitMain.DraftPayTimeLimit = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDraftPayTimeLimit])); 

            // 2007.10.05 add start -------------------------------------------->>
            // 銀行コード
            depsitMain.BankCode = Convert.ToInt32(aftDepositRow[ctBankCode]);

            // 銀行名称
            depsitMain.BankName = aftDepositRow[ctBankName].ToString();

            // 手形番号
            depsitMain.DraftNo = aftDepositRow[ctDraftNo].ToString();

            // 手形種類
            depsitMain.DraftKind = Convert.ToInt32(aftDepositRow[ctDraftKind]);

            // 手形種類名称
            depsitMain.DraftKindName = aftDepositRow[ctDraftKindName].ToString();

            // 手形区分
            depsitMain.DraftDivide = Convert.ToInt32(aftDepositRow[ctDraftDivide]);

            // 手形区分名称
            depsitMain.DraftDivideName = aftDepositRow[ctDraftDivideName].ToString();
            // 2007.10.05 add end ----------------------------------------------<<

			// 赤黒入金連結番号
			depsitMain.DebitNoteLinkDepoNo = 0;


            //==========================================//
			// ---     入金引当マスタ 新規/更新     --- //
            //==========================================//
			UpdateMode allowanceUpdateMode = 0;
			foreach (DataRow dr in aftAllowanceRows)
			{
				// 同一受注番号の引当を取得
				// SearchDepositAlw depositAlw = (SearchDepositAlw)htDepositAlw[Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw])];  // 2007.10.05 del
                // 同一売上番号の引当を取得
                SearchDepositAlw depositAlw = (SearchDepositAlw)htDepositAlw[Convert.ToString(dr[ctSalesSlipNum_Alw])];       // 2007.10.05 add

				// ハッシュテーブルに無い時は新規扱い
				if (depositAlw == null)
				{
					// 新規モード
					allowanceUpdateMode = UpdateMode.Insert;
					depositAlw = new SearchDepositAlw();
					// htDepositAlw.Add(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]), depositAlw);   // 2007.10.05 del
                    htDepositAlw.Add(Convert.ToString(dr[ctSalesSlipNum_Alw]), depositAlw);        // 2007.10.05 add

				}
				else
				{
					// 以下の項目が変わらない時
					// 1.金種コード, 2.赤伝相殺区分, 3.預り金区分,
                    // 4.クレジット区分, 5.消込み日, 6.消込み計上日
                    // 7.引当額
					if (
                        //(depositAlw.DepositKindCode == depsitMain.DepositKindCode) &&   // 2008/06/26 DEL
						(depositAlw.DebitNoteOffSetCd == depsitMain.DepositDebitNoteCd) &&
                        //(depositAlw.DepositCd == depsitMain.DepositCd) &&   // 2008/06/26 DEL
//						(depositAlw.CreditOrLoanCd == depsitMain.CreditOrLoanCd) &&   // 2007.10.05 del
						(depositAlw.ReconcileDate == TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileDate]))) &&
						(depositAlw.ReconcileAddUpDate == TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileAddUpDate]))) &&
                        (depositAlw.DepositAllowance == Convert.ToInt64(dr[ctDepositAllowance])))
					{
						// 変更無しはハッシュテーブルより削除
						// htDepositAlw.Remove(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]));   // 2007.10.05 del
                        htDepositAlw.Remove(Convert.ToString(dr[ctSalesSlipNum_Alw]));        // 2007.10.05 add
						continue;
					}

					// 更新モード
					allowanceUpdateMode = UpdateMode.Update;
				}

				
				// 新規登録の時
				if (allowanceUpdateMode == UpdateMode.Insert)
				{
					// 企業コード
					depositAlw.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                    // 請求先コード
                    depositAlw.ClaimCode = depsitMain.ClaimCode;

                    // 請求先名1
                    depositAlw.ClaimName = depsitMain.ClaimName;

                    // 請求先名2
                    depositAlw.ClaimName2 = depsitMain.ClaimName2;

                    // 請求先略称
                    depositAlw.ClaimSnm = depsitMain.ClaimSnm;

					// 得意先コード
					depositAlw.CustomerCode = depsitMain.CustomerCode;

                    // 得意先名1
                    depositAlw.CustomerName = depsitMain.CustomerName;

                    // 得意先名2
                    depositAlw.CustomerName2 = depsitMain.CustomerName2;

                    // 得意先略称
                    depositAlw.CustomerSnm = depsitMain.CustomerSnm;

					// 計上拠点コード
					depositAlw.AddUpSecCode = depsitMain.AddUpSecCode;

     				// 入金入力拠点コード
	    			depositAlw.InputDepositSecCd = depsitMain.InputDepositSecCd;

					// 入金番号
					depositAlw.DepositSlipNo = depsitMain.DepositSlipNo;

  				}

                // 入金金種コード
                depositAlw.DepositKindCode = depsitMain.DepositKindCode;

                // 入金金種名称
                depositAlw.DepositKindName = depsitMain.DepositKindName;

				// 受注伝票番号
				depositAlw.AcceptAnOrderNo = Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]);   // 2007.10.05 del

                // 受注ステータス
                depositAlw.AcptAnOdrStatus = Convert.ToInt32(dr[ctAcptAnOdrStatus_Alw]);      // 2007.10.05 add
                
            　　// 売上伝票番号
                depositAlw.SalesSlipNum = Convert.ToString(dr[ctSalesSlipNum_Alw]);           // 2007.10.05 add

                // 入金引当額 共通
				depositAlw.DepositAllowance = Convert.ToInt64(dr[ctDepositAllowance]);

				// 引当日（消込日）
				depositAlw.ReconcileDate = TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileDate])); 

				// 引当計上日付（消込み計上日）
				depositAlw.ReconcileAddUpDate = TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileAddUpDate]));

       			// 入金担当者コード
			    depositAlw.DepositAgentCode = depsitMain.DepositAgentCode;

                // 入金担当者名
			    depositAlw.DepositAgentNm = depsitMain.DepositAgentNm;

				// 赤伝相殺区分
				depositAlw.DebitNoteOffSetCd = depsitMain.DepositDebitNoteCd;

				// 預り金区分
                depositAlw.DepositCd = 0;
                
                // クレジット/ローン区分
				// depositAlw.CreditOrLoanCd = depsitMain.CreditOrLoanCd;  // 2007.10.05 del
			}

			// --- 入金引当マスタ 削除 --- //
			foreach (DictionaryEntry myDE in htDepositAlw)
			{
				SearchDepositAlw depositAlw = (SearchDepositAlw)myDE.Value;
				allowanceUpdateMode = UpdateMode.Delete;
				foreach (DataRow dr in aftAllowanceRows)
				{
                    // if (depositAlw.AcceptAnOrderNo == Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]))  // 2007.10.05 del
                    if (depositAlw.SalesSlipNum == Convert.ToString(dr[ctSalesSlipNum_Alw]))          // 2007.10.05 add
					{
						allowanceUpdateMode = UpdateMode.Update;
						break;
                    }
				}

				// DataRowにハッシュテーブルのレコードが無い時は削除されたとみなす
				if (allowanceUpdateMode == UpdateMode.Delete)
				{
					depositAlw.LogicalDeleteCode = 1;
				}
			}
		}
        // ↑ 20070131 18322 c
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
        /// 入金マスタ・入金引当マスタ更新内容セット処理
        /// </summary>
        /// <param name="updateMode">更新モード</param>
        /// <param name="loginSectionCode">ログイン拠点コード</param>
        /// <param name="addSectionCode">更新拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="aftDepositRow">入金マスタ(変更内容)</param>
        /// <param name="aftAllowanceRows">入金引当マスタ(変更内容)</param>
        /// <param name="depositDate">入金日</param>
        /// <param name="depsitMain">入金マスタ</param>
        /// <param name="htDepositAlw">入金引当マスタ</param>
        /// <remarks>
        /// <br>Note       : 入金マスタ/入金引当マスタの内容を読込時データより更新用データに変換します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// <br>UpdateNote : K2012/07/13 FSI今野 山形部品個別依頼</br>
        /// <br>             振込金額入力時は独自の銀行コードの入力を可能に修正</br>
        /// <br>Update Note: 2012/09/21 田建委</br>
        /// <br>管理番号   : 2012/10/17配信分</br>
        /// <br>             Redmine#32415 発行者の追加対応</br>
        /// <br>Update Note: 2013/01/31 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#34506 売上引当タブから引当すると、入金一覧で引当が"済"、未引当額がゼロにならない対応</br>
        /// <br>Update Note: 2015/07/16 脇田 靖之</br>
        /// <br>管理番号   : 11100068-00</br>
        /// <br>             東海自動車工業課題対応一覧№1</br>
        /// <br>             既存障害③</br>
        /// <br>               一部引当を行った入金伝票を呼び出し引当金額を修正し保存を行うと、伝票の未引当額が間違った額で表示される</br>
        /// </remarks>
        private void SetUpdateDepositData1(UpdateMode updateMode, 
                                           string loginSectionCode, 
                                           string addSectionCode, 
                                           int customerCode, 
                                           int claimCode, 
                                           DataRow aftDepositRow, 
                                           ArrayList aftAllowanceRows, 
                                           DateTime depositDate,
                                           ref SearchDepsitMain depsitMain, 
                                           ref Hashtable htDepositAlw)
        {
            //==========================================//
            // ---            入金マスタ            --- //
            //==========================================//

            depsitMain.AcptAnOdrStatus = (Int32)aftDepositRow[ctDepositAcptAnOdrStatus];                            // 受注ステータス

            // 新規登録の時
            if (updateMode == UpdateMode.Insert)
            {
                depsitMain.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;                                    // 企業コード
                depsitMain.ClaimCode = claimCode;                                                                   // 請求先コード
                depsitMain.ClaimName = this._depositCustomer.CName;                                                 // 請求先名1
                depsitMain.ClaimName2 = this._depositCustomer.CName2;                                               // 請求先名2
                depsitMain.ClaimSnm = this._depositCustomer.CSnm;                                                   // 請求先略称
                depsitMain.CustomerCode = customerCode;                                                             // 得意先コード
                depsitMain.CustomerName = this._depositCustomer.Name;                                               // 得意先名1
                depsitMain.CustomerName2 = this._depositCustomer.Name2;                                             // 得意先名2
                depsitMain.CustomerSnm = this._depositCustomer.CSnm;                                                // 得意先略称
                depsitMain.InputDepositSecCd = loginSectionCode;                                                    // 入金入力拠点コード
                depsitMain.AddUpSecCode = addSectionCode;                                                           // 計上拠点コード
                depsitMain.AcptAnOdrStatus = 30;
            }

            depsitMain.LogicalDeleteCode = 0;                                                                       // 論理削除区分
            depsitMain.DepositDebitNoteCd = 0;                                                                      // 入金赤黒区分
            depsitMain.UpdateSecCd = loginSectionCode;                                                              // 更新拠点コード
            depsitMain.DepositDate = depositDate;                                                                   // 入金日付 
            depsitMain.AddUpADate = TDateTime.LongDateToDateTime((Int32)aftDepositRow[ctDepositAddUpADate]);        // 計上日付
            depsitMain.DepositTotal = (Int64)aftDepositRow[ctDepositTotal];                                         // 入金計
            depsitMain.Deposit = (Int64)aftDepositRow[ctDeposit];                                                   // 共通 入金額
            depsitMain.FeeDeposit = (Int64)aftDepositRow[ctFeeDeposit];                                             // 共通 手数料
            depsitMain.DiscountDeposit = (Int64)aftDepositRow[ctDiscountDeposit];                                   // 共通 値引
            //depsitMain.DraftDrawingDate = TDateTime.LongDateToDateTime((Int32)aftDepositRow[ctDraftDrawingDate]);   // 手形振出日
            //depsitMain.DraftKind = (Int32)aftDepositRow[ctDraftKind];                                               // 手形種類
            //depsitMain.DraftKindName = (String)aftDepositRow[ctDraftKindName];                                      // 手形種類名称
            //depsitMain.DraftDivide = (Int32)aftDepositRow[ctDraftDivide];                                           // 手形区分
            //depsitMain.DraftDivideName = (String)aftDepositRow[ctDraftDivideName];                                  // 手形区分名称
            //depsitMain.DraftNo = (String)aftDepositRow[ctDraftNo];                                                  // 手形番号
            depsitMain.DebitNoteLinkDepoNo = 0;                                                                     // 赤黒入金連結番号
            depsitMain.SubSectionCode = GetSubSectionCode(LoginInfoAcquisition.Employee.EmployeeCode);
            depsitMain.DepositAgentCode = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;                   // 入金担当者コード
            depsitMain.DepositAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;                             // 入金担当者名
            //----- DEL 2012/09/21 田建委 redmine#32415 ---------->>>>>
            //depsitMain.DepositInputAgentCd = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;                // 入金入力者コード
            //depsitMain.DepositInputAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;                        // 入金入力者名
            //----- DEL 2012/09/21 田建委 redmine#32415 ----------<<<<<
            //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
            depsitMain.DepositInputAgentCd = (String)aftDepositRow[ctDepositInputEmpCd];                            // 入金入力者コード
            depsitMain.DepositInputAgentNm = (String)aftDepositRow[ctDepositInputEmpNm];                            // 入金入力者名
            //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<
            depsitMain.Outline = (String)aftDepositRow[ctOutline];                                                  // 摘要
            //----- ADD K2013/03/22 張曼 Redmine#35063 ----->>>>>
            if (this._opt_YamagataCtrl == (int)Option.ON)
            {
                // --- ADD K2012/07/13 ---------->>>>>
                depsitMain.BankCode = (Int32)aftDepositRow[ctBankCode];                                                 // 銀行コード
                // --- ADD K2012/07/13 ----------<<<<<
            }
            //----- ADD K2013/03/22 張曼 Redmine#35063 -----<<<<<
            //depsitMain.BankName = (String)aftDepositRow[ctBankName];                                                // 銀行名称
            depsitMain.DepositAllowance = (Int64)aftDepositRow[ctDepositAllowance_Deposit];                         // 入金引当額 共通
            depsitMain.DepositAlwcBlnce = (Int64)aftDepositRow[ctDepositAlwcBlnce_Deposit];                         // 入金引当残 共通
            depsitMain.DepositRowNo[0] = (Int32)aftDepositRow[ctDepositRowNo1];                                     // 入金行番号1
            depsitMain.MoneyKindCode[0] = (Int32)aftDepositRow[ctMoneyKindCode1];                                   // 金種コード1
            depsitMain.MoneyKindName[0] = (String)aftDepositRow[ctMoneyKindName1];                                  // 金種名称1
            depsitMain.MoneyKindDiv[0] = (Int32)aftDepositRow[ctMoneyKindDiv1];                                     // 金種区分1
            depsitMain.DepositDtl[0] = (Int64)aftDepositRow[ctDeposit1];                                            // 入金金額1
            depsitMain.ValidityTerm[0] = (DateTime)aftDepositRow[ctValidityTerm1];                                  // 有効期限1
            depsitMain.DepositRowNo[1] = (Int32)aftDepositRow[ctDepositRowNo2];                                     // 入金行番号2
            depsitMain.MoneyKindCode[1] = (Int32)aftDepositRow[ctMoneyKindCode2];                                   // 金種コード2
            depsitMain.MoneyKindName[1] = (String)aftDepositRow[ctMoneyKindName2];                                  // 金種名称2
            depsitMain.MoneyKindDiv[1] = (Int32)aftDepositRow[ctMoneyKindDiv2];                                     // 金種区分2
            depsitMain.DepositDtl[1] = (Int64)aftDepositRow[ctDeposit2];                                            // 入金金額2
            depsitMain.ValidityTerm[1] = (DateTime)aftDepositRow[ctValidityTerm2];                                  // 有効期限2
            depsitMain.DepositRowNo[2] = (Int32)aftDepositRow[ctDepositRowNo3];                                     // 入金行番号3
            depsitMain.MoneyKindCode[2] = (Int32)aftDepositRow[ctMoneyKindCode3];                                   // 金種コード3
            depsitMain.MoneyKindName[2] = (String)aftDepositRow[ctMoneyKindName3];                                  // 金種名称3
            depsitMain.MoneyKindDiv[2] = (Int32)aftDepositRow[ctMoneyKindDiv3];                                     // 金種区分3
            depsitMain.DepositDtl[2] = (Int64)aftDepositRow[ctDeposit3];                                            // 入金金額3
            depsitMain.ValidityTerm[2] = (DateTime)aftDepositRow[ctValidityTerm3];                                  // 有効期限3
            depsitMain.DepositRowNo[3] = (Int32)aftDepositRow[ctDepositRowNo4];                                     // 入金行番号4
            depsitMain.MoneyKindCode[3] = (Int32)aftDepositRow[ctMoneyKindCode4];                                   // 金種コード4
            depsitMain.MoneyKindName[3] = (String)aftDepositRow[ctMoneyKindName4];                                  // 金種名称4
            depsitMain.MoneyKindDiv[3] = (Int32)aftDepositRow[ctMoneyKindDiv4];                                     // 金種区分4
            depsitMain.DepositDtl[3] = (Int64)aftDepositRow[ctDeposit4];                                            // 入金金額4
            depsitMain.ValidityTerm[3] = (DateTime)aftDepositRow[ctValidityTerm4];                                  // 有効期限4
            depsitMain.DepositRowNo[4] = (Int32)aftDepositRow[ctDepositRowNo5];                                     // 入金行番号5
            depsitMain.MoneyKindCode[4] = (Int32)aftDepositRow[ctMoneyKindCode5];                                   // 金種コード5
            depsitMain.MoneyKindName[4] = (String)aftDepositRow[ctMoneyKindName5];                                  // 金種名称5
            depsitMain.MoneyKindDiv[4] = (Int32)aftDepositRow[ctMoneyKindDiv5];                                     // 金種区分5
            depsitMain.DepositDtl[4] = (Int64)aftDepositRow[ctDeposit5];                                            // 入金金額5
            depsitMain.ValidityTerm[4] = (DateTime)aftDepositRow[ctValidityTerm5];                                  // 有効期限5
            depsitMain.DepositRowNo[5] = (Int32)aftDepositRow[ctDepositRowNo6];                                     // 入金行番号6
            depsitMain.MoneyKindCode[5] = (Int32)aftDepositRow[ctMoneyKindCode6];                                   // 金種コード6
            depsitMain.MoneyKindName[5] = (String)aftDepositRow[ctMoneyKindName6];                                  // 金種名称6
            depsitMain.MoneyKindDiv[5] = (Int32)aftDepositRow[ctMoneyKindDiv6];                                     // 金種区分6
            depsitMain.DepositDtl[5] = (Int64)aftDepositRow[ctDeposit6];                                            // 入金金額6
            depsitMain.ValidityTerm[5] = (DateTime)aftDepositRow[ctValidityTerm6];                                  // 有効期限6
            depsitMain.DepositRowNo[6] = (Int32)aftDepositRow[ctDepositRowNo7];                                     // 入金行番号7
            depsitMain.MoneyKindCode[6] = (Int32)aftDepositRow[ctMoneyKindCode7];                                   // 金種コード7
            depsitMain.MoneyKindName[6] = (String)aftDepositRow[ctMoneyKindName7];                                  // 金種名称7
            depsitMain.MoneyKindDiv[6] = (Int32)aftDepositRow[ctMoneyKindDiv7];                                     // 金種区分7
            depsitMain.DepositDtl[6] = (Int64)aftDepositRow[ctDeposit7];                                            // 入金金額7
            depsitMain.ValidityTerm[6] = (DateTime)aftDepositRow[ctValidityTerm7];                                  // 有効期限7
            depsitMain.DepositRowNo[7] = (Int32)aftDepositRow[ctDepositRowNo8];                                     // 入金行番号8
            depsitMain.MoneyKindCode[7] = (Int32)aftDepositRow[ctMoneyKindCode8];                                   // 金種コード8
            depsitMain.MoneyKindName[7] = (String)aftDepositRow[ctMoneyKindName8];                                  // 金種名称8
            depsitMain.MoneyKindDiv[7] = (Int32)aftDepositRow[ctMoneyKindDiv8];                                     // 金種区分8
            depsitMain.DepositDtl[7] = (Int64)aftDepositRow[ctDeposit8];                                            // 入金金額8
            depsitMain.ValidityTerm[7] = (DateTime)aftDepositRow[ctValidityTerm8];                                  // 有効期限8
            depsitMain.DepositRowNo[8] = (Int32)aftDepositRow[ctDepositRowNo9];                                     // 入金行番号9
            depsitMain.MoneyKindCode[8] = (Int32)aftDepositRow[ctMoneyKindCode9];                                   // 金種コード9
            depsitMain.MoneyKindName[8] = (String)aftDepositRow[ctMoneyKindName9];                                  // 金種名称9
            depsitMain.MoneyKindDiv[8] = (Int32)aftDepositRow[ctMoneyKindDiv9];                                     // 金種区分9
            depsitMain.DepositDtl[8] = (Int64)aftDepositRow[ctDeposit9];                                            // 入金金額9
            depsitMain.ValidityTerm[8] = (DateTime)aftDepositRow[ctValidityTerm9];                                  // 有効期限9
            depsitMain.DepositRowNo[9] = (Int32)aftDepositRow[ctDepositRowNo10];                                     // 入金行番号10
            depsitMain.MoneyKindCode[9] = (Int32)aftDepositRow[ctMoneyKindCode10];                                   // 金種コード10
            depsitMain.MoneyKindName[9] = (String)aftDepositRow[ctMoneyKindName10];                                  // 金種名称10
            depsitMain.MoneyKindDiv[9] = (Int32)aftDepositRow[ctMoneyKindDiv10];                                     // 金種区分10
            depsitMain.DepositDtl[9] = (Int64)aftDepositRow[ctDeposit10];                                            // 入金金額10
            depsitMain.ValidityTerm[9] = (DateTime)aftDepositRow[ctValidityTerm10];                                  // 有効期限10
            depsitMain.InputDay = DateTime.Today;
            //==========================================//
            // ---     入金引当マスタ 新規/更新     --- //
            //==========================================//
            UpdateMode allowanceUpdateMode = 0;
            foreach (DataRow dr in aftAllowanceRows)
            {
                // 同一売上番号の引当を取得
                SearchDepositAlw depositAlw = (SearchDepositAlw)htDepositAlw[(String)dr[ctSalesSlipNum_Alw]];

                // ハッシュテーブルに無い時は新規扱い
                if (depositAlw == null)
                {
                    // 新規モード
                    allowanceUpdateMode = UpdateMode.Insert;
                    depositAlw = new SearchDepositAlw();
                    htDepositAlw.Add((String)dr[ctSalesSlipNum_Alw], depositAlw);
                }
                else
                {
                    // 以下の項目が変わらない時
                    // 1.赤伝相殺区分, 2.消込み日, 6.消込み計上日, 7.引当額
                    if ((depositAlw.DebitNoteOffSetCd == depsitMain.DepositDebitNoteCd) &&
                        (depositAlw.ReconcileDate == TDateTime.LongDateToDateTime((Int32)dr[ctReconcileDate])) &&
                        (depositAlw.ReconcileAddUpDate == TDateTime.LongDateToDateTime((Int32)dr[ctReconcileAddUpDate])) &&
                        (depositAlw.DepositAllowance == (Int64)dr[ctDepositAllowance]))
                    {
                        // 変更無しはハッシュテーブルより削除
                        htDepositAlw.Remove((String)dr[ctSalesSlipNum_Alw]);
                        continue;
                    }

                    // 更新モード
                    allowanceUpdateMode = UpdateMode.Update;
                }

                // 新規登録の時
                if (allowanceUpdateMode == UpdateMode.Insert)
                {
                    depositAlw.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;                                // 企業コード
                    depositAlw.ClaimCode = depsitMain.ClaimCode;                                                    // 請求先コード
                    depositAlw.ClaimName = depsitMain.ClaimName;                                                    // 請求先名1
                    depositAlw.ClaimName2 = depsitMain.ClaimName2;                                                  // 請求先名2
                    depositAlw.ClaimSnm = depsitMain.ClaimSnm;                                                      // 請求先略称
                    depositAlw.CustomerCode = depsitMain.CustomerCode;                                              // 得意先コード
                    depositAlw.CustomerName = depsitMain.CustomerName;                                              // 得意先名1
                    depositAlw.CustomerName2 = depsitMain.CustomerName2;                                            // 得意先名2
                    depositAlw.CustomerSnm = depsitMain.CustomerSnm;                                                // 得意先略称
                    depositAlw.AddUpSecCode = depsitMain.AddUpSecCode;                                              // 計上拠点コード
                    depositAlw.InputDepositSecCd = depsitMain.InputDepositSecCd;                                    // 入金入力拠点コード
                    depositAlw.DepositSlipNo = depsitMain.DepositSlipNo;                                            // 入金番号
                }

                depositAlw.AcptAnOdrStatus = (Int32)dr[ctAcptAnOdrStatus_Alw];                                      // 受注ステータス
                depositAlw.SalesSlipNum = (String)dr[ctSalesSlipNum_Alw];                                           // 売上伝票番号

                // 変更前引当額
                long bfDepositAllowance = depositAlw.DepositAllowance;

                depositAlw.DepositAllowance = (Int64)dr[ctDepositAllowance];                                        // 入金引当額 共通

                // --- DEL 2015/07/16 y.wakita 東海自動車工業課題対応一覧№1 既存障害③ ----------------------------------------->>>>>
                #region 削除
                //if (allowanceUpdateMode == UpdateMode.Insert)
                //{
                //    //depsitMain.DepositAllowance += depositAlw.DepositAllowance; // DEL 2013/01/31 田建委 Redmine#34506
                //}
                //else
                //{
                //    depsitMain.DepositAllowance += (depositAlw.DepositAllowance - bfDepositAllowance);
                //}
                #endregion 削除
                // --- DEL 2015/07/16 y.wakita 東海自動車工業課題対応一覧№1 既存障害③ -----------------------------------------<<<<<
                
                depositAlw.ReconcileDate = TDateTime.LongDateToDateTime((Int32)dr[ctReconcileDate]);                // 引当日（消込日）
                depositAlw.ReconcileAddUpDate = TDateTime.LongDateToDateTime((Int32)dr[ctReconcileAddUpDate]);      // 引当計上日付（消込み計上日）
                depositAlw.DepositAgentCode = depsitMain.DepositAgentCode;                                          // 入金担当者コード
                depositAlw.DepositAgentNm = depsitMain.DepositAgentNm;                                              // 入金担当者名
                depositAlw.DebitNoteOffSetCd = depsitMain.DepositDebitNoteCd;                                       // 赤伝相殺区分
            }

            depsitMain.DepositAlwcBlnce = depsitMain.Deposit - depsitMain.DepositAllowance;

            // --- 入金引当マスタ 削除 --- //
            foreach (DictionaryEntry myDE in htDepositAlw)
            {
                SearchDepositAlw depositAlw = (SearchDepositAlw)myDE.Value;
                allowanceUpdateMode = UpdateMode.Delete;
                foreach (DataRow dr in aftAllowanceRows)
                {
                    if (depositAlw.SalesSlipNum == Convert.ToString(dr[ctSalesSlipNum_Alw]))
                    {
                        allowanceUpdateMode = UpdateMode.Update;
                        break;
                    }
                }

                // DataRowにハッシュテーブルのレコードが無い時は削除されたとみなす
                if (allowanceUpdateMode == UpdateMode.Delete)
                {
                    depositAlw.LogicalDeleteCode = 1;
                }
            }
        }

		/// <summary>
		/// 引当マスタより入金マスタ項目セット処理
		/// </summary>
		/// <param name="depsitMain">入金マスタ(変更内容)</param>
		/// <param name="htDepositAlw">入金引当マスタ(変更内容)</param>
		/// <remarks>
		/// <br>Note       : 入金引当マスタ読込時/更新用を元に更新項目を入金マスタにセットします。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SetUpdateDepositData2(ref SearchDepsitMain depsitMain, Hashtable htDepositAlw)
		{
			// 読込時入金マスタ・入金引当マスタ取得処理
			SearchDepsitMain readDepsitMain;
			Hashtable readDepositAlw;
			if (depsitMain.DepositSlipNo == 0)
			{
				readDepositAlw = new Hashtable();
			}
			else
			{
				this.GetBeforeDepositData(depsitMain.DepositSlipNo, out readDepsitMain, out readDepositAlw);
			}

			// 入金引当データの読込時データに更新用データをかぶせる
			foreach (DictionaryEntry myDE in htDepositAlw)
			{
				// 更新分の取得
				SearchDepositAlw depositAlw1 = (SearchDepositAlw)myDE.Value;

                // 読込時内容の取得
				// SearchDepositAlw depositAlw2 = (SearchDepositAlw)readDepositAlw[depositAlw1.AcceptAnOrderNo];  // 2007.10.05 del
                SearchDepositAlw depositAlw2 = (SearchDepositAlw)readDepositAlw[depositAlw1.SalesSlipNum];        // 2007.10.05 add

   				// 新規引当の時
				if (depositAlw2 == null)
				{
					// readDepositAlw.Add(depositAlw1.AcceptAnOrderNo, depositAlw1);    // 2007.10.05 del
                    readDepositAlw.Add(depositAlw1.SalesSlipNum, depositAlw1);          // 2007.10.05 add
                }
			}

			// マージデータ(更新後のイメージ)の中を検索
			DateTime reconcileAddUpDate = DateTime.MinValue;

            // int acceptAnOrderSalesNo = 0;         // 2007.10.05 del
            Int32[] acptAnOdrStatus = new Int32[1];  // 2007.10.05 add
            int index = 0;
            acptAnOdrStatus[index] = 0;
            string salesSlipNum = string.Empty;      // 2007.10.05 add

   			foreach (DictionaryEntry myDE in readDepositAlw)
			{
				SearchDepositAlw depositAlw = (SearchDepositAlw)myDE.Value;

				// 削除データでは無い時
				if (depositAlw.LogicalDeleteCode == 0)
				{
                    // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                    //// 受注伝票番号  自動入金/預り金の時のみ取得
                    //if ((depsitMain.DepositCd == 1) || (depsitMain.AutoDepositCd == 1))
                    // 受注伝票番号　自動入金の時のみ取得
                    if (depsitMain.AutoDepositCd == 1)
                    // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<					
                    {
						// 引当先受注伝票のチェック処理
						// ※引当先が黒の時のみ番号をセット
						// ※自動入金と預り金の時は、１入金→１受注(黒)の関係なので。　しかし逆は、１受注→Ｎ入金になる。
						// ※このロジックが必要になるケース(手順)は
						//   1.入金(黒)<-->受注(黒)引当
						//   2.受注を赤伝にする
						//   3.入金(黒)を別の受注(黒)に引当
						//   4.画面を起動しなおして、入金(黒)を呼出し更新。この時、受注(黒)が画面上展開されてない時
						string message;

						// int st = this.CheackAllowanceSalese(0, depositAlw.AcceptAnOrderNo, depsitMain.EnterpriseCode, depsitMain.AddUpSecCode, depsitMain.CustomerCode, out message); // 2007.10.05 del
                        int st = this.CheackAllowanceSalese(0, depositAlw.SalesSlipNum, depsitMain.EnterpriseCode, depsitMain.AddUpSecCode, depsitMain.CustomerCode, depsitMain.ClaimCode, acptAnOdrStatus, out message);       // 2007.10.05 add

                        // エラーの時は例外を発生させる
						if ((st != 0) && (st != 2))
						{
							throw new DepositException(message, st);
						}
						if (st == 2)
						{
							// acceptAnOrderSalesNo = depositAlw.AcceptAnOrderNo;   // 2007.10.05 del
                            acptAnOdrStatus[index] = depositAlw.AcptAnOdrStatus;    // 2007.10.05 add
                            salesSlipNum = depositAlw.SalesSlipNum;                 // 2007.10.05 add
   						}
					}

					// 一番未来の最終引当計上日を取得
					if (depositAlw.ReconcileAddUpDate > reconcileAddUpDate)
						reconcileAddUpDate = depositAlw.ReconcileAddUpDate;
				}
			}

			// 受注伝票番号
			// depsitMain.AcceptAnOrderNo = acceptAnOrderSalesNo;  // 2007.10.05 del

            //depsitMain.AcptAnOdrStatus = acptAnOdrStatus[index];   // 2007.10.05 add

            // 売上伝票番号
            depsitMain.SalesSlipNum = salesSlipNum;                // 2007.10.05 add

			// 最終引当計上日
			depsitMain.LastReconcileAddUpDt = reconcileAddUpDate;
		}
		
		/// <summary>
		/// 入金マスタ・入金引当マスタ削除内容セット処理
		/// </summary>
		/// <param name="depsitMain">入金マスタ</param>
		/// <param name="htDepositAlw">入金引当マスタ</param>
		/// <remarks>
		/// <br>Note       : 入金マスタ/入金引当マスタを削除データとします。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SetDeleteDepositData(ref SearchDepsitMain depsitMain, ref Hashtable htDepositAlw)
		{
			// 入金データの論理削除
			depsitMain.LogicalDeleteCode = 1;

			// 入金引当データの論理削除
			foreach (DictionaryEntry de in htDepositAlw)
			{
				((SearchDepositAlw)de.Value).LogicalDeleteCode = 1;
			}
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金データ更新処理
		/// </summary>
		/// <param name="depsitMainWork">入金マスタ(更新用)</param>
		/// <param name="depositAlwWorkList">入金引当マスタ(更新用)</param>
		/// <remarks>
		/// <br>Note       : 入金マスタ/入金引当マスタの更新を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void WriteDeposit(ref DepsitMainWork depsitMainWork, ref DepositAlwWork[] depositAlwWorkList)
		{
			string message = "";
			int st = 0;

            st = _depsitMainAcs.WriteDB(ref depsitMainWork, ref depositAlwWorkList, out message);

			// エラーの時は例外を発生させる
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}
        
        /// <summary>
		/// 入金データ削除処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="depositSlipNo">入金伝票番号</param>
		/// <remarks>
		/// <br>Note       : 入金マスタ/入金引当マスタの削除を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void DeleteDeposit(string enterpriseCode, int depositSlipNo)
		{
			string message;
			int st;

			st = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, out message);

			// エラーの時は例外を発生させる
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}

		/// <summary>
		/// 入金データ更新処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="depositSlipNo">入金伝票番号</param>
		/// <param name="depsitMainWork">入金マスタ(更新結果(赤黒の黒))</param>
		/// <param name="depositAlwWorkList">入金引当マスタ(更新結果(赤黒の黒))</param>
		/// <remarks>
		/// <br>Note       : 入金マスタ/入金引当マスタの削除を行います。
		///                  赤を削除した時には結びつく黒の更新結果が返ります。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void DeleteDeposit(string enterpriseCode, int depositSlipNo, out DepsitMainWork depsitMainWork, out DepositAlwWork[] depositAlwWorkList)
		{
			string message = "";
			int st = 0;

            depsitMainWork = new DepsitMainWork();
            depositAlwWorkList = new DepositAlwWork[1];
            st = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, out depsitMainWork, out depositAlwWorkList, out message);

			// エラーの時は例外を発生させる
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}

        /// <summary>
        /// 入金データ更新処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="depositSlipNo">入金伝票番号</param>
        /// <param name="depsitDataWork">入金マスタ(更新結果(赤黒の黒))</param>
        /// <param name="depositAlwWorkList">入金引当マスタ(更新結果(赤黒の黒))</param>
        /// <remarks>
        /// <br>Note       : 入金マスタ/入金引当マスタの削除を行います。
        ///                  赤を削除した時には結びつく黒の更新結果が返ります。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void DeleteDeposit(string enterpriseCode, int depositSlipNo, out DepsitDataWork depsitDataWork, out DepositAlwWork[] depositAlwWorkList)
        {
            string message = "";
            int st = 0;

            depsitDataWork = new DepsitDataWork();
            depositAlwWorkList = new DepositAlwWork[1];
            st = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, out depsitDataWork, out depositAlwWorkList, out message);

            // エラーの時は例外を発生させる
            if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                throw new DepositException(message, st);
            }
        }

		/// <summary>
		/// 赤入金データ作成処理
		/// </summary>
		/// <param name="mode">赤伝作成モード  0:赤入金作成, 1:赤入金・新黒入金作成</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="updateSecCd">更新拠点コード</param>
		/// <param name="depositAgentCode">入金担当者コード</param>
		/// <param name="depositAgentNm">入金担当者名</param>
		/// <param name="addUpADate">計上日</param>
		/// <param name="depositSlipNo">入金番号</param>
		/// <param name="akaDepositCd">新赤伝の預り金区分</param>
		/// <param name="depsitMainWorkList">入金マスタ(更新結果)</param>
		/// <param name="depositAlwWorkList">入金マスタ(更新結果)</param>
		/// <remarks>
		/// <br>Note       : 入金マスタ/入金引当マスタの更新を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		// ↓ 20070125 18322 c MA.NS用に変更
        //private void WriteAkaDeposit(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, int addUpADate, int akaDepositCd, int depositSlipNo, out DepsitMainWork[] depsitMainWorkList, out DepositAlwWork[] depositAlwWorkList)
        private void WriteAkaDeposit(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, string depositAgentNm, int addUpADate, int akaDepositCd, int depositSlipNo, out DepsitMainWork[] depsitMainWorkList, out DepositAlwWork[] depositAlwWorkList)
        // ↑ 20070125 18322 c
		{
			string message = "";
			int st = 0;

            // ↓ 20070125 18322 c MA.NS用に変更
			//// 赤入金作成処理
			//st = _depsitMainAcs.RedCreate(mode, enterpriseCode, akaDepositCd, updateSecCd, depositAgentCode, TDateTime.LongDateToDateTime(addUpADate), depositSlipNo, out depsitMainWorkList, out depositAlwWorkList, out message);

			// 赤入金作成処理
            depsitMainWorkList = new DepsitMainWork[1];
            depositAlwWorkList = new DepositAlwWork[1];
            st = _depsitMainAcs.RedCreate(mode
                                         , enterpriseCode
                                         , akaDepositCd
                                         , updateSecCd
                                         , depositAgentCode
                                         , depositAgentNm
                                         , TDateTime.LongDateToDateTime(addUpADate)
                                         , depositSlipNo
                                         , out depsitMainWorkList
                                         , out depositAlwWorkList
                                         , out message
                                         );
            // ↑ 20070125 18322 c

			// エラーの時は例外を発生させる
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}

        /// <summary>
        /// 赤入金データ作成処理
        /// </summary>
        /// <param name="mode">赤伝作成モード  0:赤入金作成, 1:赤入金・新黒入金作成</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updateSecCd">更新拠点コード</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
        /// <param name="depositAgentNm">入金担当者名</param>
        /// <param name="addUpADate">計上日</param>
        /// <param name="depositSlipNo">入金番号</param>
        /// <param name="akaDepositCd">新赤伝の預り金区分</param>
        /// <param name="depsitDataWorkList">入金マスタ(更新結果)</param>
        /// <param name="depositAlwWorkList">入金マスタ(更新結果)</param>
        /// <remarks>
        /// <br>Note       : 入金マスタ/入金引当マスタの更新を行います。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void WriteAkaDeposit(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, string depositAgentNm, int addUpADate, int akaDepositCd, int depositSlipNo, out DepsitDataWork[] depsitDataWorkList, out DepositAlwWork[] depositAlwWorkList)
        {
            string message = "";
            int st = 0;

            // 赤入金作成処理
            depsitDataWorkList = new DepsitDataWork[1];
            depositAlwWorkList = new DepositAlwWork[1];
            st = _depsitMainAcs.RedCreate(mode
                                         , enterpriseCode
                                         , akaDepositCd
                                         , updateSecCd
                                         , depositAgentCode
                                         , depositAgentNm
                                         , TDateTime.LongDateToDateTime(addUpADate)
                                         , depositSlipNo
                                         , out depsitDataWorkList
                                         , out depositAlwWorkList
                                         , out message
                                         );

            // エラーの時は例外を発生させる
            if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                throw new DepositException(message, st);
            }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
		/// クラスメンバーコピー処理（KINGET用得意先請求金額ワーククラス⇒入金得意先情報クラス）
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET用得意先請求金額ワーククラス</param>
		/// <returns>得意先請求クラス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額ワーククラスから入金得意先情報クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private DepositCustomer CopyToDepositCustomerFromKingetCustDmdPrcWork(KingetCustDmdPrcWork kingetCustDmdPrcWork)
		{
			DepositCustomer depositCustomer = new DepositCustomer();

			// 得意先情報セット
            depositCustomer.ClaimCode           = kingetCustDmdPrcWork.ClaimCode;           // 請求先コード
            depositCustomer.CName               = kingetCustDmdPrcWork.ClaimName;           // 請求先名称１
            depositCustomer.CName2              = kingetCustDmdPrcWork.ClaimName2;          // 請求先名称２
            depositCustomer.CSnm                = kingetCustDmdPrcWork.ClaimSnm;            // 請求先略称
			depositCustomer.CustomerCode		= kingetCustDmdPrcWork.CustomerCode;		// 得意先コード
			depositCustomer.Name				= kingetCustDmdPrcWork.CustomerName;		// 得意先名称１
			depositCustomer.Name2				= kingetCustDmdPrcWork.CustomerName2;		// 得意先名称２
            depositCustomer.SNm                 = kingetCustDmdPrcWork.CustomerSnm;         // 得意先略称 
            depositCustomer.HonorificTitle		= kingetCustDmdPrcWork.HonorificTitle;		// 敬称
			depositCustomer.TotalDay			= kingetCustDmdPrcWork.TotalDay;			// 締日
			depositCustomer.CollectMoneyName	= kingetCustDmdPrcWork.CollectMoneyName;	// 集金月区分名称
			depositCustomer.CollectMoneyDay		= kingetCustDmdPrcWork.CollectMoneyDay;		// 集金日
            depositCustomer.CAddUpUpdDate       = TDateTime.DateTimeToLongDate(kingetCustDmdPrcWork.LastCAddUpUpdDate);   // 前回締次更新年月日

			return depositCustomer;
		}

        /// <summary>
        /// クラスメンバーコピー処理（KINGET用得意先請求金額ワーク⇒入金得意先請求金額情報）
        /// </summary>
        /// <param name="kingetCustDmdPrcWork">KINGET用得意先請求金額ワーククラス</param>
        /// <returns>得意先請求クラス</returns>
        /// <remarks>
        /// <br>Note       : KINGET用得意先請求金額ワーククラスから入金得意先請求金額情報クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private DepositCustDmdPrc CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(KingetCustDmdPrcWork kingetCustDmdPrcWork)
        {
            DepositCustDmdPrc depositCustDmdPrc = new DepositCustDmdPrc();

            depositCustDmdPrc.AddUpSecCode = kingetCustDmdPrcWork.AddUpSecCode;             // 計上拠点コード
            depositCustDmdPrc.ClaimCode = kingetCustDmdPrcWork.ClaimCode;                   // 請求先コード
            depositCustDmdPrc.CustomerCode = kingetCustDmdPrcWork.CustomerCode;             // 得意先コード
            depositCustDmdPrc.AddUpDate = kingetCustDmdPrcWork.AddUpDate;                   // 計上年月日
            depositCustDmdPrc.StartDateSpan = kingetCustDmdPrcWork.StartDateSpan;           // 範囲日付（開始）
            depositCustDmdPrc.EndDateSpan = kingetCustDmdPrcWork.EndDateSpan;               // 範囲日付（終了）
            depositCustDmdPrc.LastTimeDemand = kingetCustDmdPrcWork.LastTimeDemand;         // 前回請求金額
            depositCustDmdPrc.AcpOdrTtl2TmBfBlDmd = kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd;
            depositCustDmdPrc.AcpOdrTtl3TmBfBlDmd = kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd;
            depositCustDmdPrc.ThisTimeDmdNrml = kingetCustDmdPrcWork.ThisTimeDmdNrml;       // 今回入金金額（通常入金）
            depositCustDmdPrc.ThisTimeFeeDmdNrml = kingetCustDmdPrcWork.ThisTimeFeeDmdNrml; // 今回手数料額（通常入金）
            depositCustDmdPrc.ThisTimeDisDmdNrml = kingetCustDmdPrcWork.ThisTimeDisDmdNrml; // 今回値引額（通常入金）
            depositCustDmdPrc.ThisTimeTtlBlcDmd = kingetCustDmdPrcWork.ThisTimeTtlBlcDmd;   // 今回繰越残高（請求計）
            depositCustDmdPrc.ThisTimeSales = kingetCustDmdPrcWork.ThisTimeSales;           // 今回売上金額
            depositCustDmdPrc.ThisSalesTax = kingetCustDmdPrcWork.ThisSalesTax;             // 今回売上消費税
            depositCustDmdPrc.OfsThisTimeSales = kingetCustDmdPrcWork.OfsThisTimeSales;     // 相殺後今回売上金額
            depositCustDmdPrc.OfsThisSalesTax = kingetCustDmdPrcWork.OfsThisSalesTax;       // 相殺後今回売上消費税
            depositCustDmdPrc.AfCalDemandPrice = kingetCustDmdPrcWork.AfCalDemandPrice;     // 計算後請求金額
            depositCustDmdPrc.ThisTimeDmdNrmlTtl = depositCustDmdPrc.ThisTimeDmdNrml;       // 今回入金計（通常入金）
            depositCustDmdPrc.ThisTimeDmdTtl = depositCustDmdPrc.ThisTimeDmdNrmlTtl;        // 今回入金計
            depositCustDmdPrc.LastCAddUpUpdDate = kingetCustDmdPrcWork.LastCAddUpUpdDate;   // 前回締次更新年月日
            depositCustDmdPrc.CAddUpUpdExecDate = kingetCustDmdPrcWork.CAddUpUpdExecDate;   // 締次更新実行年月日
            depositCustDmdPrc.StartCAddUpUpdDate = kingetCustDmdPrcWork.StartCAddUpUpdDate; // 締次更新開始年月日

            return depositCustDmdPrc;
        }

        /// <summary>
        /// クラスメンバーコピー処理（入金マスタワーク⇒入金マスタ）
        /// </summary>
        /// <param name="depsitDataWork">入金マスタワーククラス</param>
        /// <returns>入金マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 入金マスタワーククラスから入金マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private ArrayList CopyToDepsitMainFromDepsitDataWork(DepsitDataWork depsitDataWork)
        {
            ArrayList depsitDataList = new ArrayList();

            SearchDepsitMain depsitMain = new SearchDepsitMain();

            depsitMain.CreateDateTime = depsitDataWork.CreateDateTime;              // 作成日時
            depsitMain.UpdateDateTime = depsitDataWork.UpdateDateTime;              // 更新日時
            depsitMain.EnterpriseCode = depsitDataWork.EnterpriseCode;              // 企業コード
            depsitMain.FileHeaderGuid = depsitDataWork.FileHeaderGuid;              // GUID
            depsitMain.UpdEmployeeCode = depsitDataWork.UpdEmployeeCode;            // 更新従業員コード
            depsitMain.UpdAssemblyId1 = depsitDataWork.UpdAssemblyId1;              // 更新アセンブリID1
            depsitMain.UpdAssemblyId2 = depsitDataWork.UpdAssemblyId2;              // 更新アセンブリID2
            depsitMain.LogicalDeleteCode = depsitDataWork.LogicalDeleteCode;        // 論理削除区分
            depsitMain.DepositDebitNoteCd = depsitDataWork.DepositDebitNoteCd;      // 入金赤黒区分
            depsitMain.DepositSlipNo = depsitDataWork.DepositSlipNo;                // 入金伝票番号
            depsitMain.AcptAnOdrStatus = depsitDataWork.AcptAnOdrStatus;            // 受注ステータス
            depsitMain.SalesSlipNum = depsitDataWork.SalesSlipNum;                  // 売上伝票番号 
            depsitMain.InputDepositSecCd = depsitDataWork.InputDepositSecCd;        // 入金入力拠点コード
            depsitMain.AddUpSecCode = depsitDataWork.AddUpSecCode;                  // 計上拠点コード
            depsitMain.UpdateSecCd = depsitDataWork.UpdateSecCd;                    // 更新拠点コード
            depsitMain.DepositDate = depsitDataWork.DepositDate;                    // 入金日付
            depsitMain.AddUpADate = depsitDataWork.AddUpADate;                      // 計上日付
            depsitMain.Deposit = depsitDataWork.Deposit;
            depsitMain.FeeDeposit = depsitDataWork.FeeDeposit;                      // 手数料入金額
            depsitMain.DiscountDeposit = depsitDataWork.DiscountDeposit;            // 値引入金額
            depsitMain.AutoDepositCd = depsitDataWork.AutoDepositCd;                // 自動入金区分
            depsitMain.DraftDrawingDate = depsitDataWork.DraftDrawingDate;          // 手形振出日
            depsitMain.DebitNoteLinkDepoNo = depsitDataWork.DebitNoteLinkDepoNo;    // 赤黒入金連結番号
            depsitMain.LastReconcileAddUpDt = depsitDataWork.LastReconcileAddUpDt;  // 最終消し込み計上日
            depsitMain.DepositAgentCode = depsitDataWork.DepositAgentCode;          // 入金担当者コード
            depsitMain.DepositAgentNm = depsitDataWork.DepositAgentNm;              // 入金担当者名称
            depsitMain.ClaimCode = depsitDataWork.ClaimCode;                        // 請求先コード
            depsitMain.ClaimName = depsitDataWork.ClaimName;                        // 請求先名称
            depsitMain.ClaimName2 = depsitDataWork.ClaimName2;                      // 請求先名称2
            depsitMain.ClaimSnm = depsitDataWork.ClaimSnm;                          // 請求先略称
            depsitMain.CustomerCode = depsitDataWork.CustomerCode;                  // 得意先コード
            depsitMain.CustomerName = depsitDataWork.CustomerName;                  // 得意先名称
            depsitMain.CustomerName2 = depsitDataWork.CustomerName2;                // 得意先名称2
            depsitMain.CustomerSnm = depsitDataWork.CustomerSnm;                    // 得意先略称
            depsitMain.Outline = depsitDataWork.Outline;                            // 伝票摘要
            depsitMain.BankCode = depsitDataWork.BankCode;                          // 銀行コード
            depsitMain.BankName = depsitDataWork.BankName;                          // 銀行名称
            depsitMain.DraftNo = depsitDataWork.DraftNo;                            // 手形番号
            depsitMain.DraftKind = depsitDataWork.DraftKind;                        // 手形種類
            depsitMain.DraftKindName = depsitDataWork.DraftKindName;                // 手形種類名称
            depsitMain.DraftDivide = depsitDataWork.DraftDivide;                    // 手形区分
            depsitMain.DraftDivideName = depsitDataWork.DraftDivideName;            // 手形区分名称
            if (depsitMain.AutoDepositCd == 0)
            {
                depsitMain.DepositNm = "通常入金";                                      // 預かり金区分名称
            }
            else
            {
                depsitMain.DepositNm = "自動入金";                                      // 預かり金区分名称
            }
            depsitMain.DepositAllowance = depsitDataWork.DepositAllowance;          // 入金引当額
            depsitMain.DepositAlwcBlnce = depsitDataWork.DepositAlwcBlnce;          // 入金引当残高
            depsitMain.DepositRowNo[0] = depsitDataWork.DepositRowNo1;              // 入金行番号1
            depsitMain.MoneyKindCode[0] = depsitDataWork.MoneyKindCode1;            // 金種コード1
            depsitMain.MoneyKindName[0] = depsitDataWork.MoneyKindName1;            // 金種名称1
            depsitMain.MoneyKindDiv[0] = depsitDataWork.MoneyKindDiv1;              // 金種区分1
            depsitMain.DepositDtl[0] = depsitDataWork.Deposit1;                     // 入金金額1
            depsitMain.ValidityTerm[0] = depsitDataWork.ValidityTerm1;              // 有効期限1
            depsitMain.DepositRowNo[1] = depsitDataWork.DepositRowNo2;              // 入金行番号2
            depsitMain.MoneyKindCode[1] = depsitDataWork.MoneyKindCode2;            // 金種コード2
            depsitMain.MoneyKindName[1] = depsitDataWork.MoneyKindName2;            // 金種名称2
            depsitMain.MoneyKindDiv[1] = depsitDataWork.MoneyKindDiv2;              // 金種区分2
            depsitMain.DepositDtl[1] = depsitDataWork.Deposit2;                     // 入金金額2
            depsitMain.ValidityTerm[1] = depsitDataWork.ValidityTerm2;              // 有効期限2
            depsitMain.DepositRowNo[2] = depsitDataWork.DepositRowNo3;              // 入金行番号3
            depsitMain.MoneyKindCode[2] = depsitDataWork.MoneyKindCode3;            // 金種コード3
            depsitMain.MoneyKindName[2] = depsitDataWork.MoneyKindName3;            // 金種名称3
            depsitMain.MoneyKindDiv[2] = depsitDataWork.MoneyKindDiv3;              // 金種区分3
            depsitMain.DepositDtl[2] = depsitDataWork.Deposit3;                     // 入金金額3
            depsitMain.ValidityTerm[2] = depsitDataWork.ValidityTerm3;              // 有効期限3
            depsitMain.DepositRowNo[3] = depsitDataWork.DepositRowNo4;              // 入金行番号4
            depsitMain.MoneyKindCode[3] = depsitDataWork.MoneyKindCode4;            // 金種コード4
            depsitMain.MoneyKindName[3] = depsitDataWork.MoneyKindName4;            // 金種名称4
            depsitMain.MoneyKindDiv[3] = depsitDataWork.MoneyKindDiv4;              // 金種区分4
            depsitMain.DepositDtl[3] = depsitDataWork.Deposit4;                     // 入金金額4
            depsitMain.ValidityTerm[3] = depsitDataWork.ValidityTerm4;              // 有効期限4
            depsitMain.DepositRowNo[4] = depsitDataWork.DepositRowNo5;              // 入金行番号5
            depsitMain.MoneyKindCode[4] = depsitDataWork.MoneyKindCode5;            // 金種コード5
            depsitMain.MoneyKindName[4] = depsitDataWork.MoneyKindName5;            // 金種名称5
            depsitMain.MoneyKindDiv[4] = depsitDataWork.MoneyKindDiv5;              // 金種区分5
            depsitMain.DepositDtl[4] = depsitDataWork.Deposit5;                     // 入金金額5
            depsitMain.ValidityTerm[4] = depsitDataWork.ValidityTerm5;              // 有効期限5
            depsitMain.DepositRowNo[5] = depsitDataWork.DepositRowNo6;              // 入金行番号6
            depsitMain.MoneyKindCode[5] = depsitDataWork.MoneyKindCode6;            // 金種コード6
            depsitMain.MoneyKindName[5] = depsitDataWork.MoneyKindName6;            // 金種名称6
            depsitMain.MoneyKindDiv[5] = depsitDataWork.MoneyKindDiv6;              // 金種区分6
            depsitMain.DepositDtl[5] = depsitDataWork.Deposit6;                     // 入金金額6
            depsitMain.ValidityTerm[5] = depsitDataWork.ValidityTerm6;              // 有効期限6
            depsitMain.DepositRowNo[6] = depsitDataWork.DepositRowNo7;              // 入金行番号7
            depsitMain.MoneyKindCode[6] = depsitDataWork.MoneyKindCode7;            // 金種コード7
            depsitMain.MoneyKindName[6] = depsitDataWork.MoneyKindName7;            // 金種名称7
            depsitMain.MoneyKindDiv[6] = depsitDataWork.MoneyKindDiv7;              // 金種区分7
            depsitMain.DepositDtl[6] = depsitDataWork.Deposit7;                     // 入金金額7
            depsitMain.ValidityTerm[6] = depsitDataWork.ValidityTerm7;              // 有効期限7
            depsitMain.DepositRowNo[7] = depsitDataWork.DepositRowNo8;              // 入金行番号8
            depsitMain.MoneyKindCode[7] = depsitDataWork.MoneyKindCode8;            // 金種コード8
            depsitMain.MoneyKindName[7] = depsitDataWork.MoneyKindName8;            // 金種名称8
            depsitMain.MoneyKindDiv[7] = depsitDataWork.MoneyKindDiv8;              // 金種区分8
            depsitMain.DepositDtl[7] = depsitDataWork.Deposit8;                     // 入金金額8
            depsitMain.ValidityTerm[7] = depsitDataWork.ValidityTerm8;              // 有効期限8
            depsitMain.DepositRowNo[8] = depsitDataWork.DepositRowNo9;              // 入金行番号9
            depsitMain.MoneyKindCode[8] = depsitDataWork.MoneyKindCode9;            // 金種コード9
            depsitMain.MoneyKindName[8] = depsitDataWork.MoneyKindName9;            // 金種名称9
            depsitMain.MoneyKindDiv[8] = depsitDataWork.MoneyKindDiv9;              // 金種区分9
            depsitMain.DepositDtl[8] = depsitDataWork.Deposit9;                     // 入金金額9
            depsitMain.ValidityTerm[8] = depsitDataWork.ValidityTerm9;              // 有効期限9
            depsitMain.DepositRowNo[9] = depsitDataWork.DepositRowNo10;             // 入金行番号10
            depsitMain.MoneyKindCode[9] = depsitDataWork.MoneyKindCode10;           // 金種コード10
            depsitMain.MoneyKindName[9] = depsitDataWork.MoneyKindName10;           // 金種名称10
            depsitMain.MoneyKindDiv[9] = depsitDataWork.MoneyKindDiv10;             // 金種区分10
            depsitMain.DepositDtl[9] = depsitDataWork.Deposit10;                    // 入金金額10
            depsitMain.ValidityTerm[9] = depsitDataWork.ValidityTerm10;             // 有効期限10
            depsitMain.InputDay = depsitDataWork.InputDay;
            // 2012/10/05 ADD TAKAGAWA 2012/10/17配信システムテスト障害No24 ---------->>>>>>>>>>
            depsitMain.DepositInputAgentCd = depsitDataWork.DepositInputAgentCd;    // 発行者コード
            depsitMain.DepositInputAgentNm = depsitDataWork.DepositInputAgentNm;    // 発行者名
            // 2012/10/05 ADD TAKAGAWA 2012/10/17配信システムテスト障害No24 ----------<<<<<<<<<<

            depsitDataList.Add(depsitMain);

            return depsitDataList;
        }

        /// <summary>
        /// クラスメンバーコピー処理（入金マスタワーク⇒入金マスタ）
        /// </summary>
        /// <param name="depsitDataWorkList">入金マスタワーククラス</param>
        /// <returns>入金マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 入金マスタワーククラスから入金マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private ArrayList CopyToDepsitMainFromDepsitDataWork(DepsitDataWork[] depsitDataWorkList)
        {
            ArrayList depsitDataList = new ArrayList();

            foreach (DepsitDataWork depsitDataWork in depsitDataWorkList)
            {
                SearchDepsitMain depsitMain = new SearchDepsitMain();

                depsitMain.CreateDateTime = depsitDataWork.CreateDateTime;              // 作成日時
                depsitMain.UpdateDateTime = depsitDataWork.UpdateDateTime;              // 更新日時
                depsitMain.EnterpriseCode = depsitDataWork.EnterpriseCode;              // 企業コード
                depsitMain.FileHeaderGuid = depsitDataWork.FileHeaderGuid;              // GUID
                depsitMain.UpdEmployeeCode = depsitDataWork.UpdEmployeeCode;            // 更新従業員コード
                depsitMain.UpdAssemblyId1 = depsitDataWork.UpdAssemblyId1;              // 更新アセンブリID1
                depsitMain.UpdAssemblyId2 = depsitDataWork.UpdAssemblyId2;              // 更新アセンブリID2
                depsitMain.LogicalDeleteCode = depsitDataWork.LogicalDeleteCode;        // 論理削除区分
                depsitMain.DepositDebitNoteCd = depsitDataWork.DepositDebitNoteCd;      // 入金赤黒区分
                depsitMain.DepositSlipNo = depsitDataWork.DepositSlipNo;                // 入金伝票番号
                depsitMain.AcptAnOdrStatus = depsitDataWork.AcptAnOdrStatus;            // 受注ステータス
                depsitMain.SalesSlipNum = depsitDataWork.SalesSlipNum;                  // 売上伝票番号 
                depsitMain.InputDepositSecCd = depsitDataWork.InputDepositSecCd;        // 入金入力拠点コード
                depsitMain.AddUpSecCode = depsitDataWork.AddUpSecCode;                  // 計上拠点コード
                depsitMain.UpdateSecCd = depsitDataWork.UpdateSecCd;                    // 更新拠点コード
                depsitMain.DepositDate = depsitDataWork.DepositDate;                    // 入金日付
                depsitMain.AddUpADate = depsitDataWork.AddUpADate;                      // 計上日付
                depsitMain.Deposit = depsitDataWork.Deposit;                            // 入金金額(通常入金固定)
                depsitMain.FeeDeposit = depsitDataWork.FeeDeposit;                      // 手数料入金額
                depsitMain.DiscountDeposit = depsitDataWork.DiscountDeposit;            // 値引入金額
                depsitMain.AutoDepositCd = depsitDataWork.AutoDepositCd;                // 自動入金区分
                depsitMain.DraftDrawingDate = depsitDataWork.DraftDrawingDate;          // 手形振出日
                depsitMain.DebitNoteLinkDepoNo = depsitDataWork.DebitNoteLinkDepoNo;    // 赤黒入金連結番号
                depsitMain.LastReconcileAddUpDt = depsitDataWork.LastReconcileAddUpDt;  // 最終消し込み計上日
                depsitMain.DepositAgentCode = depsitDataWork.DepositAgentCode;          // 入金担当者コード
                depsitMain.DepositAgentNm = depsitDataWork.DepositAgentNm;              // 入金担当者名称
                depsitMain.ClaimCode = depsitDataWork.ClaimCode;                        // 請求先コード
                depsitMain.ClaimName = depsitDataWork.ClaimName;                        // 請求先名称
                depsitMain.ClaimName2 = depsitDataWork.ClaimName2;                      // 請求先名称2
                depsitMain.ClaimSnm = depsitDataWork.ClaimSnm;                          // 請求先略称
                depsitMain.CustomerCode = depsitDataWork.CustomerCode;                  // 得意先コード
                depsitMain.CustomerName = depsitDataWork.CustomerName;                  // 得意先名称
                depsitMain.CustomerName2 = depsitDataWork.CustomerName2;                // 得意先名称2
                depsitMain.CustomerSnm = depsitDataWork.CustomerSnm;                    // 得意先略称
                depsitMain.Outline = depsitDataWork.Outline;                            // 伝票摘要
                depsitMain.BankCode = depsitDataWork.BankCode;                          // 銀行コード
                depsitMain.BankName = depsitDataWork.BankName;                          // 銀行名称
                depsitMain.DraftNo = depsitDataWork.DraftNo;                            // 手形番号
                depsitMain.DraftKind = depsitDataWork.DraftKind;                        // 手形種類
                depsitMain.DraftKindName = depsitDataWork.DraftKindName;                // 手形種類名称
                depsitMain.DraftDivide = depsitDataWork.DraftDivide;                    // 手形区分
                depsitMain.DraftDivideName = depsitDataWork.DraftDivideName;            // 手形区分名称
                if (depsitMain.AutoDepositCd == 0)
                {
                    depsitMain.DepositNm = "通常入金";                                      // 預かり金区分名称
                }
                else
                {
                    depsitMain.DepositNm = "自動入金";                                      // 預かり金区分名称
                }
                depsitMain.DepositAllowance = depsitDataWork.DepositAllowance;          // 入金引当額
                depsitMain.DepositAlwcBlnce = depsitDataWork.DepositAlwcBlnce;          // 入金引当残高
                depsitMain.DepositRowNo[0] = depsitDataWork.DepositRowNo1;              // 入金行番号1
                depsitMain.MoneyKindCode[0] = depsitDataWork.MoneyKindCode1;            // 金種コード1
                depsitMain.MoneyKindName[0] = depsitDataWork.MoneyKindName1;            // 金種名称1
                depsitMain.MoneyKindDiv[0] = depsitDataWork.MoneyKindDiv1;              // 金種区分1
                depsitMain.DepositDtl[0] = depsitDataWork.Deposit1;                     // 入金金額1
                depsitMain.ValidityTerm[0] = depsitDataWork.ValidityTerm1;              // 有効期限1
                depsitMain.DepositRowNo[1] = depsitDataWork.DepositRowNo2;              // 入金行番号2
                depsitMain.MoneyKindCode[1] = depsitDataWork.MoneyKindCode2;            // 金種コード2
                depsitMain.MoneyKindName[1] = depsitDataWork.MoneyKindName2;            // 金種名称2
                depsitMain.MoneyKindDiv[1] = depsitDataWork.MoneyKindDiv2;              // 金種区分2
                depsitMain.DepositDtl[1] = depsitDataWork.Deposit2;                     // 入金金額2
                depsitMain.ValidityTerm[1] = depsitDataWork.ValidityTerm2;              // 有効期限2
                depsitMain.DepositRowNo[2] = depsitDataWork.DepositRowNo3;              // 入金行番号3
                depsitMain.MoneyKindCode[2] = depsitDataWork.MoneyKindCode3;            // 金種コード3
                depsitMain.MoneyKindName[2] = depsitDataWork.MoneyKindName3;            // 金種名称3
                depsitMain.MoneyKindDiv[2] = depsitDataWork.MoneyKindDiv3;              // 金種区分3
                depsitMain.DepositDtl[2] = depsitDataWork.Deposit3;                     // 入金金額3
                depsitMain.ValidityTerm[2] = depsitDataWork.ValidityTerm3;              // 有効期限3
                depsitMain.DepositRowNo[3] = depsitDataWork.DepositRowNo4;              // 入金行番号4
                depsitMain.MoneyKindCode[3] = depsitDataWork.MoneyKindCode4;            // 金種コード4
                depsitMain.MoneyKindName[3] = depsitDataWork.MoneyKindName4;            // 金種名称4
                depsitMain.MoneyKindDiv[3] = depsitDataWork.MoneyKindDiv4;              // 金種区分4
                depsitMain.DepositDtl[3] = depsitDataWork.Deposit4;                     // 入金金額4
                depsitMain.ValidityTerm[3] = depsitDataWork.ValidityTerm4;              // 有効期限4
                depsitMain.DepositRowNo[4] = depsitDataWork.DepositRowNo5;              // 入金行番号5
                depsitMain.MoneyKindCode[4] = depsitDataWork.MoneyKindCode5;            // 金種コード5
                depsitMain.MoneyKindName[4] = depsitDataWork.MoneyKindName5;            // 金種名称5
                depsitMain.MoneyKindDiv[4] = depsitDataWork.MoneyKindDiv5;              // 金種区分5
                depsitMain.DepositDtl[4] = depsitDataWork.Deposit5;                     // 入金金額5
                depsitMain.ValidityTerm[4] = depsitDataWork.ValidityTerm5;              // 有効期限5
                depsitMain.DepositRowNo[5] = depsitDataWork.DepositRowNo6;              // 入金行番号6
                depsitMain.MoneyKindCode[5] = depsitDataWork.MoneyKindCode6;            // 金種コード6
                depsitMain.MoneyKindName[5] = depsitDataWork.MoneyKindName6;            // 金種名称6
                depsitMain.MoneyKindDiv[5] = depsitDataWork.MoneyKindDiv6;              // 金種区分6
                depsitMain.DepositDtl[5] = depsitDataWork.Deposit6;                     // 入金金額6
                depsitMain.ValidityTerm[5] = depsitDataWork.ValidityTerm6;              // 有効期限6
                depsitMain.DepositRowNo[6] = depsitDataWork.DepositRowNo7;              // 入金行番号7
                depsitMain.MoneyKindCode[6] = depsitDataWork.MoneyKindCode7;            // 金種コード7
                depsitMain.MoneyKindName[6] = depsitDataWork.MoneyKindName7;            // 金種名称7
                depsitMain.MoneyKindDiv[6] = depsitDataWork.MoneyKindDiv7;              // 金種区分7
                depsitMain.DepositDtl[6] = depsitDataWork.Deposit7;                     // 入金金額7
                depsitMain.ValidityTerm[6] = depsitDataWork.ValidityTerm7;              // 有効期限7
                depsitMain.DepositRowNo[7] = depsitDataWork.DepositRowNo8;              // 入金行番号8
                depsitMain.MoneyKindCode[7] = depsitDataWork.MoneyKindCode8;            // 金種コード8
                depsitMain.MoneyKindName[7] = depsitDataWork.MoneyKindName8;            // 金種名称8
                depsitMain.MoneyKindDiv[7] = depsitDataWork.MoneyKindDiv8;              // 金種区分8
                depsitMain.DepositDtl[7] = depsitDataWork.Deposit8;                     // 入金金額8
                depsitMain.ValidityTerm[7] = depsitDataWork.ValidityTerm8;              // 有効期限8
                depsitMain.DepositRowNo[8] = depsitDataWork.DepositRowNo9;              // 入金行番号9
                depsitMain.MoneyKindCode[8] = depsitDataWork.MoneyKindCode9;            // 金種コード9
                depsitMain.MoneyKindName[8] = depsitDataWork.MoneyKindName9;            // 金種名称9
                depsitMain.MoneyKindDiv[8] = depsitDataWork.MoneyKindDiv9;              // 金種区分9
                depsitMain.DepositDtl[8] = depsitDataWork.Deposit9;                     // 入金金額9
                depsitMain.ValidityTerm[8] = depsitDataWork.ValidityTerm9;              // 有効期限9
                depsitMain.DepositRowNo[9] = depsitDataWork.DepositRowNo10;             // 入金行番号10
                depsitMain.MoneyKindCode[9] = depsitDataWork.MoneyKindCode10;           // 金種コード10
                depsitMain.MoneyKindName[9] = depsitDataWork.MoneyKindName10;           // 金種名称10
                depsitMain.MoneyKindDiv[9] = depsitDataWork.MoneyKindDiv10;             // 金種区分10
                depsitMain.DepositDtl[9] = depsitDataWork.Deposit10;                    // 入金金額10
                depsitMain.ValidityTerm[9] = depsitDataWork.ValidityTerm10;             // 有効期限10
                depsitMain.InputDay = depsitDataWork.InputDay;
                // 2012/10/05 ADD TAKAGAWA 2012/10/17配信システムテスト障害No24 ---------->>>>>>>>>>
                depsitMain.DepositInputAgentCd = depsitDataWork.DepositInputAgentCd;    // 発行者コード
                depsitMain.DepositInputAgentNm = depsitDataWork.DepositInputAgentNm;    // 発行者名
                // 2012/10/05 ADD TAKAGAWA 2012/10/17配信システムテスト障害No24 ----------<<<<<<<<<<

                depsitDataList.Add(depsitMain);
            }

            return depsitDataList;
        }

        /// <summary>
        /// クラスメンバーコピー処理（入金引当マスタワーク⇒入金引当マスタ）
        /// </summary>
        /// <param name="depositAlwWorkList">入金引当マスタワーククラス</param>
        /// <returns>入金引当マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 入金引当マスタワーククラスから入金引当マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private ArrayList CopyToDepositAlwFromDepositAlwWork(DepositAlwWork[] depositAlwWorkList)
        {
            ArrayList depositAlwList = new ArrayList();

            foreach (DepositAlwWork depositAlwWork in depositAlwWorkList)
            {
                SearchDepositAlw depositAlw = new SearchDepositAlw();

                depositAlw.CreateDateTime = depositAlwWork.CreateDateTime;          // 作成日時
                depositAlw.UpdateDateTime = depositAlwWork.UpdateDateTime;          // 更新日時
                depositAlw.EnterpriseCode = depositAlwWork.EnterpriseCode;          // 企業コード
                depositAlw.FileHeaderGuid = depositAlwWork.FileHeaderGuid;          // GUID
                depositAlw.UpdEmployeeCode = depositAlwWork.UpdEmployeeCode;        // 更新従業員コード
                depositAlw.UpdAssemblyId1 = depositAlwWork.UpdAssemblyId1;          // 更新アセンブリID1
                depositAlw.UpdAssemblyId2 = depositAlwWork.UpdAssemblyId2;          // 更新アセンブリID2
                depositAlw.LogicalDeleteCode = depositAlwWork.LogicalDeleteCode;    // 論理削除区分
                depositAlw.InputDepositSecCd = depositAlwWork.InputDepositSecCd;    // 入金入力拠点コード
                depositAlw.AddUpSecCode = depositAlwWork.AddUpSecCode;              // 計上拠点コード
                depositAlw.ReconcileDate = depositAlwWork.ReconcileDate;            // 消込み日
                depositAlw.ReconcileAddUpDate = depositAlwWork.ReconcileAddUpDate;  // 消込み計上日
                depositAlw.DepositSlipNo = depositAlwWork.DepositSlipNo;            // 入金伝票番号
                depositAlw.DepositAllowance = depositAlwWork.DepositAllowance;      // 入金引当額
                depositAlw.DepositAgentCode = depositAlwWork.DepositAgentCode;      // 入金担当者コード
                depositAlw.DepositAgentNm = depositAlwWork.DepositAgentNm;          // 入金担当者名称
                depositAlw.CustomerCode = depositAlwWork.CustomerCode;              // 得意先コード
                depositAlw.CustomerName = depositAlwWork.CustomerName;              // 得意先名称
                depositAlw.CustomerName2 = depositAlwWork.CustomerName2;            // 得意先名称2
                depositAlw.DebitNoteOffSetCd = depositAlwWork.DebitNoteOffSetCd;    // 赤伝相殺区分
                depositAlw.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;        // 受注ステータス
                depositAlw.SalesSlipNum = depositAlwWork.SalesSlipNum;              // 売上伝票番号

                depositAlwList.Add(depositAlw);
            }

            return depositAlwList;
        }

        /// <summary>
        /// クラスメンバーコピー処理（入金検索データ⇒入金マスタワーク）
        /// </summary>
        /// <param name="depsitMain">入金検索データクラス</param>
        /// <returns>入金マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note        : 入金検索データクラスから入金マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br></br>
        /// </remarks>
        private DepsitDataWork CopyToDepsitDataWorkFromDepsitMain(SearchDepsitMain depsitMain)
        {
            DepsitDataWork depsitDataWork = new DepsitDataWork();

            depsitDataWork.CreateDateTime = depsitMain.CreateDateTime;              // 作成日時
            depsitDataWork.UpdateDateTime = depsitMain.UpdateDateTime;              // 更新日時
            depsitDataWork.EnterpriseCode = depsitMain.EnterpriseCode;              // 企業コード
            depsitDataWork.FileHeaderGuid = depsitMain.FileHeaderGuid;              // GUID
            depsitDataWork.UpdEmployeeCode = depsitMain.UpdEmployeeCode;            // 更新従業員コード
            depsitDataWork.UpdAssemblyId1 = depsitMain.UpdAssemblyId1;              // 更新アセンブリID1
            depsitDataWork.UpdAssemblyId2 = depsitMain.UpdAssemblyId2;              // 更新アセンブリID2
            depsitDataWork.LogicalDeleteCode = depsitMain.LogicalDeleteCode;        // 論理削除区分
            depsitDataWork.DepositDebitNoteCd = depsitMain.DepositDebitNoteCd;      // 入金赤黒区分
            depsitDataWork.DepositSlipNo = depsitMain.DepositSlipNo;                // 入金伝票番号
            depsitDataWork.AcptAnOdrStatus = depsitMain.AcptAnOdrStatus;            // 受注ステータス
            depsitDataWork.SalesSlipNum = depsitMain.SalesSlipNum;                  // 売上伝票番号
            depsitDataWork.InputDepositSecCd = depsitMain.InputDepositSecCd;        // 入金入力拠点コード
            depsitDataWork.AddUpSecCode = depsitMain.AddUpSecCode;                  // 計上拠点コード
            depsitDataWork.UpdateSecCd = depsitMain.UpdateSecCd;                    // 更新拠点コード
            depsitDataWork.DepositDate = depsitMain.DepositDate;                    // 入金日付
            depsitDataWork.AddUpADate = depsitMain.AddUpADate;                      // 計上日付
            depsitDataWork.DepositTotal = depsitMain.DepositTotal;                  // 入金計
            depsitDataWork.Deposit = depsitMain.Deposit;                            // 入金金額
            depsitDataWork.FeeDeposit = depsitMain.FeeDeposit;                      // 手数料入金額
            depsitDataWork.DiscountDeposit = depsitMain.DiscountDeposit;            // 値引入金額
            depsitDataWork.AutoDepositCd = depsitMain.AutoDepositCd;                // 自動入金区分
            depsitDataWork.DraftDrawingDate = depsitMain.DraftDrawingDate;          // 手形振出日
            depsitDataWork.DebitNoteLinkDepoNo = depsitMain.DebitNoteLinkDepoNo;    // 赤黒入金連結番号
            depsitDataWork.LastReconcileAddUpDt = depsitMain.LastReconcileAddUpDt;  // 最終消し込み計上日
            depsitDataWork.SubSectionCode = depsitMain.SubSectionCode;
            depsitDataWork.DepositAgentCode = depsitMain.DepositAgentCode;          // 入金担当者コード
            depsitDataWork.DepositAgentNm = depsitMain.DepositAgentNm;              // 入金担当者名称
            depsitDataWork.DepositInputAgentCd = depsitMain.DepositInputAgentCd;    // 入金入力者コード
            depsitDataWork.DepositInputAgentNm = depsitMain.DepositInputAgentNm;    // 入金入力者名称
            depsitDataWork.ClaimCode = depsitMain.ClaimCode;                        // 請求先コード
            depsitDataWork.ClaimName = depsitMain.ClaimName;                        // 請求先名称
            depsitDataWork.ClaimName2 = depsitMain.ClaimName2;                      // 請求先名称2
            depsitDataWork.ClaimSnm = depsitMain.ClaimSnm;                          // 請求先略称
            depsitDataWork.CustomerCode = depsitMain.CustomerCode;                  // 得意先コード
            depsitDataWork.CustomerName = depsitMain.CustomerName;                  // 得意先名称
            depsitDataWork.CustomerName2 = depsitMain.CustomerName2;                // 得意先名称2
            depsitDataWork.CustomerSnm = depsitMain.CustomerSnm;                    // 得意先略称
            depsitDataWork.Outline = depsitMain.Outline;                            // 伝票摘要
            depsitDataWork.BankCode = depsitMain.BankCode;                          // 銀行コード
            depsitDataWork.BankName = depsitMain.BankName;                          // 銀行名称
            depsitDataWork.DraftNo = depsitMain.DraftNo;                            // 手形番号
            depsitDataWork.DraftKind = depsitMain.DraftKind;                        // 手形種類
            depsitDataWork.DraftKindName = depsitMain.DraftKindName;                // 手形種類名称
            depsitDataWork.DraftDivide = depsitMain.DraftDivide;                    // 手形区分
            depsitDataWork.DraftDivideName = depsitMain.DraftDivideName;            // 手形区分名称
            depsitDataWork.DepositAllowance = depsitMain.DepositAllowance;          // 入金引当額
            depsitDataWork.DepositAlwcBlnce = depsitMain.DepositAlwcBlnce;          // 入金引当残高
            depsitDataWork.DepositRowNo1 = depsitMain.DepositRowNo[0];              // 入金行番号1
            depsitDataWork.MoneyKindCode1 = depsitMain.MoneyKindCode[0];            // 金種コード1
            depsitDataWork.MoneyKindName1 = depsitMain.MoneyKindName[0];            // 金種名称1
            depsitDataWork.MoneyKindDiv1 = depsitMain.MoneyKindDiv[0];              // 金種区分1
            depsitDataWork.Deposit1 = depsitMain.DepositDtl[0];                     // 入金金額1
            depsitDataWork.ValidityTerm1 = depsitMain.ValidityTerm[0];              // 有効期限1
            depsitDataWork.DepositRowNo2 = depsitMain.DepositRowNo[1];              // 入金行番号2
            depsitDataWork.MoneyKindCode2 = depsitMain.MoneyKindCode[1];            // 金種コード2
            depsitDataWork.MoneyKindName2 = depsitMain.MoneyKindName[1];            // 金種名称2
            depsitDataWork.MoneyKindDiv2 = depsitMain.MoneyKindDiv[1];              // 金種区分2
            depsitDataWork.Deposit2 = depsitMain.DepositDtl[1];                     // 入金金額2
            depsitDataWork.ValidityTerm2 = depsitMain.ValidityTerm[1];              // 有効期限2
            depsitDataWork.DepositRowNo3 = depsitMain.DepositRowNo[2];              // 入金行番号3
            depsitDataWork.MoneyKindCode3 = depsitMain.MoneyKindCode[2];            // 金種コード3
            depsitDataWork.MoneyKindName3 = depsitMain.MoneyKindName[2];            // 金種名称3
            depsitDataWork.MoneyKindDiv3 = depsitMain.MoneyKindDiv[2];              // 金種区分3
            depsitDataWork.Deposit3 = depsitMain.DepositDtl[2];                     // 入金金額3
            depsitDataWork.ValidityTerm3 = depsitMain.ValidityTerm[2];              // 有効期限3
            depsitDataWork.DepositRowNo4 = depsitMain.DepositRowNo[3];              // 入金行番号4
            depsitDataWork.MoneyKindCode4 = depsitMain.MoneyKindCode[3];            // 金種コード4
            depsitDataWork.MoneyKindName4 = depsitMain.MoneyKindName[3];            // 金種名称4
            depsitDataWork.MoneyKindDiv4 = depsitMain.MoneyKindDiv[3];              // 金種区分4
            depsitDataWork.Deposit4 = depsitMain.DepositDtl[3];                     // 入金金額4
            depsitDataWork.ValidityTerm4 = depsitMain.ValidityTerm[3];              // 有効期限4
            depsitDataWork.DepositRowNo5 = depsitMain.DepositRowNo[4];              // 入金行番号5
            depsitDataWork.MoneyKindCode5 = depsitMain.MoneyKindCode[4];            // 金種コード5
            depsitDataWork.MoneyKindName5 = depsitMain.MoneyKindName[4];            // 金種名称5
            depsitDataWork.MoneyKindDiv5 = depsitMain.MoneyKindDiv[4];              // 金種区分5
            depsitDataWork.Deposit5 = depsitMain.DepositDtl[4];                     // 入金金額5
            depsitDataWork.ValidityTerm5 = depsitMain.ValidityTerm[4];              // 有効期限5
            depsitDataWork.DepositRowNo6 = depsitMain.DepositRowNo[5];              // 入金行番号6
            depsitDataWork.MoneyKindCode6 = depsitMain.MoneyKindCode[5];            // 金種コード6
            depsitDataWork.MoneyKindName6 = depsitMain.MoneyKindName[5];            // 金種名称6
            depsitDataWork.MoneyKindDiv6 = depsitMain.MoneyKindDiv[5];              // 金種区分6
            depsitDataWork.Deposit6 = depsitMain.DepositDtl[5];                     // 入金金額6
            depsitDataWork.ValidityTerm6 = depsitMain.ValidityTerm[5];              // 有効期限6
            depsitDataWork.DepositRowNo7 = depsitMain.DepositRowNo[6];              // 入金行番号7
            depsitDataWork.MoneyKindCode7 = depsitMain.MoneyKindCode[6];            // 金種コード7
            depsitDataWork.MoneyKindName7 = depsitMain.MoneyKindName[6];            // 金種名称7
            depsitDataWork.MoneyKindDiv7 = depsitMain.MoneyKindDiv[6];              // 金種区分7
            depsitDataWork.Deposit7 = depsitMain.DepositDtl[6];                     // 入金金額7
            depsitDataWork.ValidityTerm7 = depsitMain.ValidityTerm[6];              // 有効期限7
            depsitDataWork.DepositRowNo8 = depsitMain.DepositRowNo[7];              // 入金行番号8
            depsitDataWork.MoneyKindCode8 = depsitMain.MoneyKindCode[7];            // 金種コード8
            depsitDataWork.MoneyKindName8 = depsitMain.MoneyKindName[7];            // 金種名称8
            depsitDataWork.MoneyKindDiv8 = depsitMain.MoneyKindDiv[7];              // 金種区分8
            depsitDataWork.Deposit8 = depsitMain.DepositDtl[7];                     // 入金金額8
            depsitDataWork.ValidityTerm8 = depsitMain.ValidityTerm[7];              // 有効期限8
            depsitDataWork.DepositRowNo9 = depsitMain.DepositRowNo[8];              // 入金行番号9
            depsitDataWork.MoneyKindCode9 = depsitMain.MoneyKindCode[8];            // 金種コード9
            depsitDataWork.MoneyKindName9 = depsitMain.MoneyKindName[8];            // 金種名称9
            depsitDataWork.MoneyKindDiv9 = depsitMain.MoneyKindDiv[8];              // 金種区分9
            depsitDataWork.Deposit9 = depsitMain.DepositDtl[8];                     // 入金金額9
            depsitDataWork.ValidityTerm9 = depsitMain.ValidityTerm[8];              // 有効期限9
            depsitDataWork.DepositRowNo10 = depsitMain.DepositRowNo[9];              // 入金行番号10
            depsitDataWork.MoneyKindCode10 = depsitMain.MoneyKindCode[9];            // 金種コード10
            depsitDataWork.MoneyKindName10 = depsitMain.MoneyKindName[9];            // 金種名称10
            depsitDataWork.MoneyKindDiv10 = depsitMain.MoneyKindDiv[9];              // 金種区分10
            depsitDataWork.Deposit10 = depsitMain.DepositDtl[9];                     // 入金金額10
            depsitDataWork.ValidityTerm10 = depsitMain.ValidityTerm[9];              // 有効期限10
            depsitDataWork.InputDay = depsitMain.InputDay;

            return depsitDataWork;
        }
        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>
        /// <summary>
        /// クラスメンバーコピー処理（受取手形データマスタクラス⇒受取手形データマスタワーククラス）
        /// </summary>
        /// <param name="rcvDraftData">受取手形データマスタクラス</param>
        /// <returns>受取手形データマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタクラスから受取手形データマスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.06</br>
        /// </remarks>
        private RcvDraftDataWork CopyToRcvDraftDataWorkFromRcvDraftData(RcvDraftData rcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();

            rcvDraftDataWork.CreateDateTime = rcvDraftData.CreateDateTime;
            rcvDraftDataWork.UpdateDateTime = rcvDraftData.UpdateDateTime;
            rcvDraftDataWork.EnterpriseCode = rcvDraftData.EnterpriseCode;
            rcvDraftDataWork.FileHeaderGuid = rcvDraftData.FileHeaderGuid;
            rcvDraftDataWork.UpdEmployeeCode = rcvDraftData.UpdEmployeeCode;
            rcvDraftDataWork.UpdAssemblyId1 = rcvDraftData.UpdAssemblyId1;
            rcvDraftDataWork.UpdAssemblyId2 = rcvDraftData.UpdAssemblyId2;
            rcvDraftDataWork.LogicalDeleteCode = rcvDraftData.LogicalDeleteCode;
            rcvDraftDataWork.RcvDraftNo = rcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DraftKindCd = rcvDraftData.DraftKindCd;
            rcvDraftDataWork.DraftDivide = rcvDraftData.DraftDivide;
            rcvDraftDataWork.Deposit = rcvDraftData.Deposit;
            rcvDraftDataWork.BankAndBranchCd = rcvDraftData.BankAndBranchCd;
            rcvDraftDataWork.BankAndBranchNm = rcvDraftData.BankAndBranchNm;
            rcvDraftDataWork.SectionCode = rcvDraftData.SectionCode;
            rcvDraftDataWork.AddUpSecCode = rcvDraftData.AddUpSecCode;
            rcvDraftDataWork.CustomerCode = rcvDraftData.CustomerCode;
            rcvDraftDataWork.CustomerName = rcvDraftData.CustomerName;
            rcvDraftDataWork.CustomerName2 = rcvDraftData.CustomerName2;
            rcvDraftDataWork.CustomerSnm = rcvDraftData.CustomerSnm;
            rcvDraftDataWork.ProcDate = rcvDraftData.ProcDate;
            rcvDraftDataWork.DraftDrawingDate = rcvDraftData.DraftDrawingDate;
            rcvDraftDataWork.ValidityTerm = rcvDraftData.ValidityTerm;
            rcvDraftDataWork.DraftStmntDate = rcvDraftData.DraftStmntDate;
            rcvDraftDataWork.Outline1 = rcvDraftData.Outline1;
            rcvDraftDataWork.Outline2 = rcvDraftData.Outline2;
            rcvDraftDataWork.AcptAnOdrStatus = rcvDraftData.AcptAnOdrStatus;
            rcvDraftDataWork.DepositSlipNo = rcvDraftData.DepositSlipNo;
            rcvDraftDataWork.DepositRowNo = rcvDraftData.DepositRowNo;
            rcvDraftDataWork.DepositDate = rcvDraftData.DepositDate;

            return rcvDraftDataWork;
        }
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>
        /// <summary>
        /// クラスメンバーコピー処理（入金引当マスタ⇒入金引当マスタワーク）
        /// </summary>
        /// <param name="depositAlwList">入金引当マスタクラス</param>
        /// <returns>入金マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note        : 入金引当マスタクラスから入金マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br></br>
        /// </remarks>
        private DepositAlwWork[] CopyToDepositAlwWorkFromDepositAlw(Hashtable depositAlwList)
        {
            ArrayList arrDepositAlw = new ArrayList();

            foreach (DictionaryEntry de in depositAlwList)
            {
                SearchDepositAlw depositAlw = (SearchDepositAlw)de.Value;
                DepositAlwWork depositAlwWork = new DepositAlwWork();

                depositAlwWork.CreateDateTime = depositAlw.CreateDateTime;              // 作成日時
                depositAlwWork.UpdateDateTime = depositAlw.UpdateDateTime;              // 更新日時
                depositAlwWork.EnterpriseCode = depositAlw.EnterpriseCode;              // 企業コード
                depositAlwWork.FileHeaderGuid = depositAlw.FileHeaderGuid;              // GUID
                depositAlwWork.UpdEmployeeCode = depositAlw.UpdEmployeeCode;            // 更新従業員コード
                depositAlwWork.UpdAssemblyId1 = depositAlw.UpdAssemblyId1;              // 更新アセンブリID1
                depositAlwWork.UpdAssemblyId2 = depositAlw.UpdAssemblyId2;              // 更新アセンブリID2
                depositAlwWork.LogicalDeleteCode = depositAlw.LogicalDeleteCode;        // 論理削除区分
                depositAlwWork.InputDepositSecCd = depositAlw.InputDepositSecCd;        // 入金入力拠点コード
                depositAlwWork.AddUpSecCode = depositAlw.AddUpSecCode;                  // 計上拠点コード
                depositAlwWork.ReconcileDate = depositAlw.ReconcileDate;                // 消込み日
                depositAlwWork.ReconcileAddUpDate = depositAlw.ReconcileAddUpDate;      // 消込み計上日
                depositAlwWork.DepositSlipNo = depositAlw.DepositSlipNo;                // 入金伝票番号
                depositAlwWork.DepositAllowance = depositAlw.DepositAllowance;          // 入金引当額
                depositAlwWork.DepositAgentCode = depositAlw.DepositAgentCode;          // 入金担当者コード
                depositAlwWork.DepositAgentNm = depositAlw.DepositAgentNm;              // 入金担当者名称
                depositAlwWork.CustomerCode = depositAlw.CustomerCode;                  // 得意先コード
                depositAlwWork.CustomerName = depositAlw.CustomerName;                  // 得意先名称
                depositAlwWork.CustomerName2 = depositAlw.CustomerName2;                // 得意先名称2
                depositAlwWork.AcptAnOdrStatus = depositAlw.AcptAnOdrStatus;            // 受注ステータス
                depositAlwWork.SalesSlipNum = depositAlw.SalesSlipNum;                  // 売上伝票番号
                depositAlwWork.DebitNoteOffSetCd = depositAlw.DebitNoteOffSetCd;        // 赤伝相殺区分

                arrDepositAlw.Add(depositAlwWork);
            }

            DepositAlwWork[] list = (DepositAlwWork[])arrDepositAlw.ToArray(typeof(DepositAlwWork));

            return list;
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// クラスメンバーコピー処理（KINGET用得意先請求金額ワーククラス⇒入金得意先請求金額情報クラス）
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET用得意先請求金額ワーククラス</param>
		/// <returns>得意先請求クラス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額ワーククラスから入金得意先請求金額情報クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura MA.NS用に変更</br>
        /// <br>Update Note : 2007.04.18 18322 T.Kimura 画面に表示する請求の鏡情報に併せるため修正</br>
		/// </remarks>
		private DepositCustDmdPrc CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(KingetCustDmdPrcWork kingetCustDmdPrcWork)
		{
			DepositCustDmdPrc depositCustDmdPrc = new DepositCustDmdPrc();

            // ↓ 20070118 18322 c MA.NSでは諸費用は使用しないので削除
            #region SF 請求金額情報セット(コメントアウト)
            //// 請求金額情報セット
			//depositCustDmdPrc.AddUpSecCode			= kingetCustDmdPrcWork.AddUpSecCode;			// 計上拠点コード
			//depositCustDmdPrc.CustomerCode			= kingetCustDmdPrcWork.CustomerCode;			// 得意先コード
			//depositCustDmdPrc.AddUpDate				= kingetCustDmdPrcWork.AddUpDate;				// 計上年月日
			//depositCustDmdPrc.StartDateSpan			= kingetCustDmdPrcWork.StartDateSpan;			// 範囲日付（開始）
			//depositCustDmdPrc.EndDateSpan			= kingetCustDmdPrcWork.EndDateSpan;				// 範囲日付（終了）
			//depositCustDmdPrc.AcpOdrTtlLMBlDmd		= kingetCustDmdPrcWork.AcpOdrTtlLMBlDmd;		// 受注前月残高（請求計）
			//depositCustDmdPrc.TtlLMVarCstDmdBlnce	= kingetCustDmdPrcWork.TtlLMVarCstDmdBlnce;		// 諸費用前月残高（請求計）
			//depositCustDmdPrc.AfCalTtlAOdrDepoDmd	= kingetCustDmdPrcWork.AfCalTtlAOdrDepoDmd;		// 計算後受注入金額（請求計）
			//depositCustDmdPrc.AfCalTtlVCstDepoDmd	= kingetCustDmdPrcWork.AfCalTtlVCstDepoDmd;		// 計算後諸費用入金額（請求計）
			//depositCustDmdPrc.AfCalTtlAOdrDpDsDmd	= kingetCustDmdPrcWork.AfCalTtlAOdrDpDsDmd;		// 計算後受注入金値引額（請求計）
			//depositCustDmdPrc.AfCalTtlVCstDpDsDmd	= kingetCustDmdPrcWork.AfCalTtlVCstDpDsDmd;		// 計算後諸費用入金値引額（請求計）
			//depositCustDmdPrc.AcpOdrTtlSalesDmd		= kingetCustDmdPrcWork.AcpOdrTtlSalesDmd;		// 受注売上額（請求計）
			//depositCustDmdPrc.AcpOdrTtlConsTaxDmd	= kingetCustDmdPrcWork.AcpOdrTtlConsTaxDmd;		// 受注消費税額（請求計）
			//depositCustDmdPrc.DmdVarCst				= kingetCustDmdPrcWork.DmdVarCst;				// 諸費用金額（請求計）
			//depositCustDmdPrc.TtlDmdVarCstConsTax	= kingetCustDmdPrcWork.TtlDmdVarCstConsTax;		// 諸費用消費税額（請求計）
			//depositCustDmdPrc.AfCalTtlAOdrRMDmd		= kingetCustDmdPrcWork.AfCalTtlAOdrRMDmd;		// 計算後受注前受金（請求計）
			//depositCustDmdPrc.AfCalTtlVCstBfRMDmd	= kingetCustDmdPrcWork.AfCalTtlVCstBfRMDmd;		// 計算後諸費用前受金（請求計）
			//depositCustDmdPrc.AfCalTtlAOdrRMDsDmd	= kingetCustDmdPrcWork.AfCalTtlAOdrRMDsDmd;		// 計算後受注前受金値引額（請求計）
			//depositCustDmdPrc.AfCalTtlVCstRMDsDmd	= kingetCustDmdPrcWork.AfCalTtlVCstRMDsDmd;		// 計算後諸費用前受金値引額（請求計）
			//depositCustDmdPrc.AfCalTtlAOdrBlDmd		= kingetCustDmdPrcWork.AfCalTtlAOdrBlDmd;		// 計算後受注合計残高（請求計）
			//depositCustDmdPrc.AfCalTtlVCstBlDmd		= kingetCustDmdPrcWork.AfCalTtlVCstBlDmd;		// 計算後諸費用合計残高（請求計）
            #endregion

            #region MA.NS 請求金額情報セット
            // 計上拠点コード
            depositCustDmdPrc.AddUpSecCode       = kingetCustDmdPrcWork.AddUpSecCode;
            // 請求先コード
            depositCustDmdPrc.ClaimCode          = kingetCustDmdPrcWork.ClaimCode;
            // 得意先コード
            depositCustDmdPrc.CustomerCode       = kingetCustDmdPrcWork.CustomerCode;
            // 計上年月日
            depositCustDmdPrc.AddUpDate          = kingetCustDmdPrcWork.AddUpDate;
            // 範囲日付（開始）
            depositCustDmdPrc.StartDateSpan      = kingetCustDmdPrcWork.StartDateSpan;
            // 範囲日付（終了）
            depositCustDmdPrc.EndDateSpan        = kingetCustDmdPrcWork.EndDateSpan;
            // 前回請求金額
            depositCustDmdPrc.LastTimeDemand     = kingetCustDmdPrcWork.LastTimeDemand;
            // 今回入金金額（通常入金）
            depositCustDmdPrc.ThisTimeDmdNrml    = kingetCustDmdPrcWork.ThisTimeDmdNrml;
            // 今回手数料額（通常入金）
            depositCustDmdPrc.ThisTimeFeeDmdNrml = kingetCustDmdPrcWork.ThisTimeFeeDmdNrml;
            // 今回値引額（通常入金）
            depositCustDmdPrc.ThisTimeDisDmdNrml = kingetCustDmdPrcWork.ThisTimeDisDmdNrml;
            // 2007.10.05 del start---------------------------------------------------------->>
            // 今回リベート額（通常入金）
            //depositCustDmdPrc.ThisTimeRbtDmdNrml = kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;
            // 今回入金金額（預り金）
            //depositCustDmdPrc.ThisTimeDmdDepo    = kingetCustDmdPrcWork.ThisTimeDmdDepo;
            // 今回手数料額（預り金）
            //depositCustDmdPrc.ThisTimeFeeDmdDepo = kingetCustDmdPrcWork.ThisTimeFeeDmdDepo;
            // 今回値引額（預り金）
            //depositCustDmdPrc.ThisTimeDisDmdDepo = kingetCustDmdPrcWork.ThisTimeDisDmdDepo;
            // 今回リベート額（預り金）
            //depositCustDmdPrc.ThisTimeRbtDmdDepo = kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;
            // 2007.10.05 del end -----------------------------------------------------------<<
            // 今回繰越残高（請求計）
            depositCustDmdPrc.ThisTimeTtlBlcDmd = kingetCustDmdPrcWork.ThisTimeTtlBlcDmd;
            // 今回売上金額
            depositCustDmdPrc.ThisTimeSales     = kingetCustDmdPrcWork.ThisTimeSales;
            // 今回売上消費税
            depositCustDmdPrc.ThisSalesTax      = kingetCustDmdPrcWork.ThisSalesTax;
            // 2007.10.05 hikita del start ------------------------------------------------------>>
            //// 支払インセンティブ額合計（税抜き）
            //depositCustDmdPrc.TtlIncDtbtTaxExc  = kingetCustDmdPrcWork.TtlIncDtbtTaxExc;
            //// 支払インセンティブ額合計（税）
            //depositCustDmdPrc.TtlIncDtbtTax     = kingetCustDmdPrcWork.TtlIncDtbtTax;
            // 2007.10.05 hikita del end --------------------------------------------------------<<
            // 相殺後今回売上金額
            depositCustDmdPrc.OfsThisTimeSales  = kingetCustDmdPrcWork.OfsThisTimeSales;
            // 相殺後今回売上消費税
            depositCustDmdPrc.OfsThisSalesTax   = kingetCustDmdPrcWork.OfsThisSalesTax;
            // 計算後請求金額
            depositCustDmdPrc.AfCalDemandPrice  = kingetCustDmdPrcWork.AfCalDemandPrice;

            // 今回入金計（通常入金）
            depositCustDmdPrc.ThisTimeDmdNrmlTtl = depositCustDmdPrc.ThisTimeDmdNrml;
            //                                     + kingetCustDmdPrcWork.ThisTimeFeeDmdNrml   // 2007.10.05 hikita del
            //                                     + kingetCustDmdPrcWork.ThisTimeDisDmdNrml;  // 2007.10.05 hikita del
            //                                     + kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;  // 2007.10.05 hikita del


            //// 今回入金計（預り金）
            //depositCustDmdPrc.ThisTimeDmdDepoTtl = kingetCustDmdPrcWork.ThisTimeDmdDepo      // 2007.10.05 hikita del
            //                                     + kingetCustDmdPrcWork.ThisTimeFeeDmdDepo   // 2007.10.05 hikita del 
            //                                     + kingetCustDmdPrcWork.ThisTimeDisDmdDepo;  // 2007.10.05 hikita del 
            //                                     + kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;  // 2007.10.05 hikita del
            // 今回入金計
            depositCustDmdPrc.ThisTimeDmdTtl = depositCustDmdPrc.ThisTimeDmdNrmlTtl;
            //                                     + kingetCustDmdPrcWork.ThisTimeDmdDepoTtl;  // 2007.10.05 hikita del
            depositCustDmdPrc.LastCAddUpUpdDate = kingetCustDmdPrcWork.LastCAddUpUpdDate;
            depositCustDmdPrc.CAddUpUpdExecDate = kingetCustDmdPrcWork.CAddUpUpdExecDate;
            depositCustDmdPrc.StartCAddUpUpdDate = kingetCustDmdPrcWork.StartCAddUpUpdDate;
            #endregion
            // ↑ 20070118 18322 c

			return depositCustDmdPrc;
		}

        /// <summary>
        /// クラスメンバーコピー処理（入金マスタワーククラス⇒入金マスタクラス）
        /// </summary>
        /// <param name="depsitMainWorkList">入金マスタワーククラス</param>
        /// <returns>入金マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 入金マスタワーククラスから入金マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        /// <br>                MA.NS用に変更</br>
        /// </remarks>
        private ArrayList CopyToDepsitMainFromDepsitMainWork(DepsitMainWork[] depsitMainWorkList)
        {
            ArrayList depsitMainList = new ArrayList();

            foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
            {
                SearchDepsitMain depsitMain = new SearchDepsitMain();

                // ↓ 20070122 18322 c MA.NS用に変更
                #region SF 入金マスタワーククラス⇒入金マスタクラス（全てコメントアウト）
                //depsitMain.CreateDateTime		= depsitMainWork.CreateDateTime;
                //depsitMain.UpdateDateTime		= depsitMainWork.UpdateDateTime;
                //depsitMain.EnterpriseCode		= depsitMainWork.EnterpriseCode;
                //depsitMain.FileHeaderGuid		= depsitMainWork.FileHeaderGuid;
                //depsitMain.UpdEmployeeCode		= depsitMainWork.UpdEmployeeCode;
                //depsitMain.UpdAssemblyId1		= depsitMainWork.UpdAssemblyId1;
                //depsitMain.UpdAssemblyId2		= depsitMainWork.UpdAssemblyId2;
                //depsitMain.LogicalDeleteCode	= depsitMainWork.LogicalDeleteCode;
                //depsitMain.DepositDebitNoteCd	= depsitMainWork.DepositDebitNoteCd;
                //depsitMain.DepositSlipNo		= depsitMainWork.DepositSlipNo;
                //depsitMain.DepositKindCode		= depsitMainWork.DepositKindCode;
                //depsitMain.CustomerCode			= depsitMainWork.CustomerCode;
                //depsitMain.DepositCd			= depsitMainWork.DepositCd;
                //depsitMain.DepositTotal			= depsitMainWork.DepositTotal;
                //depsitMain.Outline				= depsitMainWork.Outline;
                //depsitMain.AcceptAnOrderSalesNo	= depsitMainWork.AcceptAnOrderSalesNo;
                //depsitMain.InputDepositSecCd	= depsitMainWork.InputDepositSecCd;
                //depsitMain.DepositDate			= depsitMainWork.DepositDate;
                //depsitMain.AddUpSecCode			= depsitMainWork.AddUpSecCode;
                //depsitMain.AddUpADate			= depsitMainWork.AddUpADate;
                //depsitMain.UpdateSecCd			= depsitMainWork.UpdateSecCd;
                //depsitMain.DepositKindName		= depsitMainWork.DepositKindName;
                //depsitMain.DepositAllowance		= depsitMainWork.DepositAllowance;
                //depsitMain.DepositAlwcBlnce		= depsitMainWork.DepositAlwcBlnce;
                //depsitMain.DepositAgentCode		= depsitMainWork.DepositAgentCode;
                //depsitMain.DepositKindDivCd		= depsitMainWork.DepositKindDivCd;
                //depsitMain.FeeDeposit			= depsitMainWork.FeeDeposit;
                //depsitMain.DiscountDeposit		= depsitMainWork.DiscountDeposit;
                //depsitMain.CreditOrLoanCd		= depsitMainWork.CreditOrLoanCd;
                //depsitMain.CreditCompanyCode	= depsitMainWork.CreditCompanyCode;
                //depsitMain.Deposit				= depsitMainWork.Deposit;
                //depsitMain.DraftDrawingDate		= depsitMainWork.DraftDrawingDate;
                //depsitMain.DraftPayTimeLimit	= depsitMainWork.DraftPayTimeLimit;
                //depsitMain.DebitNoteLinkDepoNo	= depsitMainWork.DebitNoteLinkDepoNo;
                //depsitMain.LastReconcileAddUpDt	= depsitMainWork.LastReconcileAddUpDt;
                //depsitMain.AcpOdrDeposit		= depsitMainWork.AcpOdrDeposit;
                //depsitMain.AcpOdrChargeDeposit	= depsitMainWork.AcpOdrChargeDeposit;
                //depsitMain.AcpOdrDisDeposit		= depsitMainWork.AcpOdrDisDeposit;
                //depsitMain.VariousCostDeposit	= depsitMainWork.VariousCostDeposit;
                //depsitMain.VarCostChargeDeposit	= depsitMainWork.VarCostChargeDeposit;
                //depsitMain.VarCostDisDeposit	= depsitMainWork.VarCostDisDeposit;
                //depsitMain.AcpOdrDepositAlwc	= depsitMainWork.AcpOdrDepositAlwc;
                //depsitMain.AcpOdrDepoAlwcBlnce	= depsitMainWork.AcpOdrDepoAlwcBlnce;
                //depsitMain.VarCostDepoAlwc		= depsitMainWork.VarCostDepoAlwc;
                //depsitMain.VarCostDepoAlwcBlnce	= depsitMainWork.VarCostDepoAlwcBlnce;
                #endregion

                // 作成日時
                depsitMain.CreateDateTime = depsitMainWork.CreateDateTime;
                // 更新日時
                depsitMain.UpdateDateTime = depsitMainWork.UpdateDateTime;
                // 企業コード
                depsitMain.EnterpriseCode = depsitMainWork.EnterpriseCode;
                // GUID
                depsitMain.FileHeaderGuid = depsitMainWork.FileHeaderGuid;
                // 更新従業員コード
                depsitMain.UpdEmployeeCode = depsitMainWork.UpdEmployeeCode;
                // 更新アセンブリID1
                depsitMain.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;
                // 更新アセンブリID2
                depsitMain.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;
                // 論理削除区分
                depsitMain.LogicalDeleteCode = depsitMainWork.LogicalDeleteCode;
                // 入金赤黒区分
                depsitMain.DepositDebitNoteCd = depsitMainWork.DepositDebitNoteCd;
                // 入金伝票番号
                depsitMain.DepositSlipNo = depsitMainWork.DepositSlipNo;
                // 受注番号
                //depsitMain.AcceptAnOrderNo      = depsitMainWork.AcceptAnOrderNo;  // 2007.10.05 del
                // サービス伝票区分
                //depsitMain.ServiceSlipCd        = depsitMainWork.ServiceSlipCd;    // 2007.10.05 del
                // 受注ステータス
                depsitMain.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;
                // 売上伝票番号 
                depsitMain.SalesSlipNum = depsitMainWork.SalesSlipNum;       // 2007.10.05 add
                // 入金入力拠点コード
                depsitMain.InputDepositSecCd = depsitMainWork.InputDepositSecCd;
                // 計上拠点コード
                depsitMain.AddUpSecCode = depsitMainWork.AddUpSecCode;
                // 更新拠点コード
                depsitMain.UpdateSecCd = depsitMainWork.UpdateSecCd;
                // 入金日付
                depsitMain.DepositDate = depsitMainWork.DepositDate;
                // 計上日付
                depsitMain.AddUpADate = depsitMainWork.AddUpADate;
                // 入金金種コード
                depsitMain.DepositKindCode = depsitMainWork.DepositKindCode;
                // 入金金種名称
                depsitMain.DepositKindName = depsitMainWork.DepositKindName;
                // 入金金種区分
                depsitMain.DepositKindDivCd = depsitMainWork.DepositKindDivCd;
                // 入金計
                depsitMain.DepositTotal = depsitMainWork.DepositTotal;
                // 入金金額
                depsitMain.Deposit = depsitMainWork.Deposit;
                // 手数料入金額
                depsitMain.FeeDeposit = depsitMainWork.FeeDeposit;
                // 値引入金額
                depsitMain.DiscountDeposit = depsitMainWork.DiscountDeposit;
                // リベート入金額
                // depsitMain.RebateDeposit        = depsitMainWork.RebateDeposit;     // 2007.10.05 del
                // 自動入金区分
                depsitMain.AutoDepositCd = depsitMainWork.AutoDepositCd;
                // 預り金区分
                depsitMain.DepositCd = depsitMainWork.DepositCd;
                // クレジット／ローン区分
                // depsitMain.CreditOrLoanCd       = depsitMainWork.CreditOrLoanCd;    // 2007.10.05 del
                // クレジット会社コード
                // depsitMain.CreditCompanyCode    = depsitMainWork.CreditCompanyCode; // 2007.10.05 del
                // 手形振出日
                depsitMain.DraftDrawingDate = depsitMainWork.DraftDrawingDate;
                // 手形支払期日
                depsitMain.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;
                // 入金引当額
                depsitMain.DepositAllowance = depsitMainWork.DepositAllowance;
                // 入金引当残高
                depsitMain.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce;
                // 赤黒入金連結番号
                depsitMain.DebitNoteLinkDepoNo = depsitMainWork.DebitNoteLinkDepoNo;
                // 最終消し込み計上日
                depsitMain.LastReconcileAddUpDt = depsitMainWork.LastReconcileAddUpDt;
                // 入金担当者コード
                depsitMain.DepositAgentCode = depsitMainWork.DepositAgentCode;
                // 入金担当者名称
                depsitMain.DepositAgentNm = depsitMainWork.DepositAgentNm;
                // 請求先コード
                depsitMain.ClaimCode = depsitMainWork.ClaimCode;
                // 請求先名称
                depsitMain.ClaimName = depsitMainWork.ClaimName;
                // 請求先名称2
                depsitMain.ClaimName2 = depsitMainWork.ClaimName2;
                // 請求先略称
                depsitMain.ClaimSnm = depsitMainWork.ClaimSnm;
                // 得意先コード
                depsitMain.CustomerCode = depsitMainWork.CustomerCode;
                // 得意先名称
                depsitMain.CustomerName = depsitMainWork.CustomerName;
                // 得意先名称2
                depsitMain.CustomerName2 = depsitMainWork.CustomerName2;
                // 得意先略称
                depsitMain.CustomerSnm = depsitMainWork.CustomerSnm;
                // 伝票摘要
                depsitMain.Outline = depsitMainWork.Outline;
                // ↑ 20070122 18322 c

                // 2007.10.05 add start ---------------------------------------->>
                // 銀行コード
                depsitMain.BankCode = depsitMainWork.BankCode;

                // 銀行名称
                depsitMain.BankName = depsitMainWork.BankName;

                // 手形番号
                depsitMain.DraftNo = depsitMainWork.DraftNo;

                // 手形種類
                depsitMain.DraftKind = depsitMainWork.DraftKind;

                // 手形種類名称
                depsitMain.DraftKindName = depsitMainWork.DraftKindName;

                // 手形区分
                depsitMain.DraftDivide = depsitMainWork.DraftDivide;

                // 手形区分名称
                depsitMain.DraftDivideName = depsitMainWork.DraftDivideName;
                // 2007.10.05 add end ------------------------------------------<<

                switch (depsitMain.DepositCd)
                {
                    case 1:
                        depsitMain.DepositNm = "預り金";
                        break;
                    case 2:
                        depsitMain.DepositNm = "自動入金";
                        break;
                    default:
                        depsitMain.DepositNm = "通常入金";
                        break;
                }

                depsitMainList.Add(depsitMain);
            }

            return depsitMainList;
        }

		/// <summary>
		/// クラスメンバーコピー処理（入金引当マスタワーククラス⇒入金引当マスタクラス）
		/// </summary>
		/// <param name="depositAlwWorkList">入金引当マスタワーククラス</param>
		/// <returns>入金引当マスタクラス</returns>
		/// <remarks>
		/// <br>Note       : 入金引当マスタワーククラスから入金引当マスタクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        /// <br>                MA.NS用に変更</br>
		/// </remarks>
		private ArrayList CopyToDepositAlwFromDepositAlwWork(DepositAlwWork[] depositAlwWorkList)
		{
			ArrayList depositAlwList = new ArrayList();

			foreach (DepositAlwWork depositAlwWork in depositAlwWorkList)
			{
				SearchDepositAlw depositAlw = new SearchDepositAlw();

                // ↓ 20070122 18322 c MA.NS用に変更
                #region SF 入金引当マスタワーククラス⇒入金引当マスタクラス（全てコメントアウト）
                //depositAlw.CreateDateTime		= depositAlwWork.CreateDateTime;
				//depositAlw.UpdateDateTime		= depositAlwWork.UpdateDateTime;
				//depositAlw.EnterpriseCode		= depositAlwWork.EnterpriseCode;
				//depositAlw.FileHeaderGuid		= depositAlwWork.FileHeaderGuid;
				//depositAlw.UpdEmployeeCode		= depositAlwWork.UpdEmployeeCode;
				//depositAlw.UpdAssemblyId1		= depositAlwWork.UpdAssemblyId1;
				//depositAlw.UpdAssemblyId2		= depositAlwWork.UpdAssemblyId2;
				//depositAlw.LogicalDeleteCode	= depositAlwWork.LogicalDeleteCode;
				//depositAlw.CustomerCode			= depositAlwWork.CustomerCode;
				//depositAlw.AddUpSecCode			= depositAlwWork.AddUpSecCode;
				//depositAlw.AcceptAnOrderNo		= depositAlwWork.AcceptAnOrderNo;
				//depositAlw.DepositSlipNo		= depositAlwWork.DepositSlipNo;
				//depositAlw.DepositKindCode		= depositAlwWork.DepositKindCode;
				//depositAlw.DepositInputDate		= depositAlwWork.DepositInputDate;
				//depositAlw.DepositAllowance		= depositAlwWork.DepositAllowance;
				//depositAlw.ReconcileDate		= depositAlwWork.ReconcileDate;
				//depositAlw.ReconcileAddUpDate	= depositAlwWork.ReconcileAddUpDate;
				//depositAlw.DebitNoteOffSetCd	= depositAlwWork.DebitNoteOffSetCd;
				//depositAlw.DepositCd			= depositAlwWork.DepositCd;
				//depositAlw.CreditOrLoanCd		= depositAlwWork.CreditOrLoanCd;
				//depositAlw.AcpOdrDepositAlwc	= depositAlwWork.AcpOdrDepositAlwc;
                //depositAlw.VarCostDepoAlwc		= depositAlwWork.VarCostDepoAlwc;
                #endregion

                // 作成日時
                depositAlw.CreateDateTime     = depositAlwWork.CreateDateTime;
                // 更新日時
                depositAlw.UpdateDateTime     = depositAlwWork.UpdateDateTime;
                // 企業コード
                depositAlw.EnterpriseCode     = depositAlwWork.EnterpriseCode;
                // GUID
                depositAlw.FileHeaderGuid     = depositAlwWork.FileHeaderGuid;
                // 更新従業員コード
                depositAlw.UpdEmployeeCode    = depositAlwWork.UpdEmployeeCode;
                // 更新アセンブリID1
                depositAlw.UpdAssemblyId1     = depositAlwWork.UpdAssemblyId1;
                // 更新アセンブリID2
                depositAlw.UpdAssemblyId2     = depositAlwWork.UpdAssemblyId2;
                // 論理削除区分
                depositAlw.LogicalDeleteCode  = depositAlwWork.LogicalDeleteCode;
                // 入金入力拠点コード
                depositAlw.InputDepositSecCd  = depositAlwWork.InputDepositSecCd;
                // 計上拠点コード
                depositAlw.AddUpSecCode       = depositAlwWork.AddUpSecCode;
                // 消込み日
                depositAlw.ReconcileDate      = depositAlwWork.ReconcileDate;
                // 消込み計上日
                depositAlw.ReconcileAddUpDate = depositAlwWork.ReconcileAddUpDate;
                // 入金伝票番号
                depositAlw.DepositSlipNo      = depositAlwWork.DepositSlipNo;

                // 入金金種コード
                depositAlw.DepositKindCode    = depositAlwWork.DepositKindCode;
                // 入金金種名称
                depositAlw.DepositKindName    = depositAlwWork.DepositKindName;

                // 入金引当額
                depositAlw.DepositAllowance   = depositAlwWork.DepositAllowance;
                // 入金担当者コード
                depositAlw.DepositAgentCode   = depositAlwWork.DepositAgentCode;
                // 入金担当者名称
                depositAlw.DepositAgentNm     = depositAlwWork.DepositAgentNm;
                // 得意先コード
                depositAlw.CustomerCode       = depositAlwWork.CustomerCode;
                // 得意先名称
                depositAlw.CustomerName       = depositAlwWork.CustomerName;
                // 得意先名称2
                depositAlw.CustomerName2      = depositAlwWork.CustomerName2;
                // 受注番号
                // depositAlw.AcceptAnOrderNo    = depositAlwWork.AcceptAnOrderNo;   // 2007.10.05 del
                // サービス伝票区分
                // depositAlw.ServiceSlipCd      = depositAlwWork.ServiceSlipCd;     // 2007.10.05 del
                // 赤伝相殺区分
                depositAlw.DebitNoteOffSetCd  = depositAlwWork.DebitNoteOffSetCd;

                // 預り金区分
                depositAlw.DepositCd = depositAlwWork.DepositCd;

                // クレジット／ローン区分
                // depositAlw.CreditOrLoanCd     = depositAlwWork.CreditOrLoanCd;    // 2007.10.05 del
                // ↑ 20070122 18322 c
                // 受注ステータス
                depositAlw.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;    // 2007.10.05 add
                // 売上伝票番号
                depositAlw.SalesSlipNum = depositAlwWork.SalesSlipNum;          // 2007.10.05 add

				depositAlwList.Add(depositAlw);
			}

			return depositAlwList;
		}

		/// <summary>
		/// クラスメンバーコピー処理（入金検索データクラス⇒入金マスタワーククラス）
		/// </summary>
		/// <param name="depsitMain">入金検索データクラス</param>
		/// <returns>入金マスタワーククラス</returns>
		/// <remarks>
		/// <br>Note        : 入金検索データクラスから入金マスタワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        /// <br>                MA.NS用に変更</br>
        /// <br></br>
		/// </remarks>
		private DepsitMainWork CopyToDepsitMainWorkFromDepsitMain(SearchDepsitMain depsitMain)
		{

			DepsitMainWork depsitMainWork = new DepsitMainWork();

            // ↓ 20070122 18322 c MA.NS用に変更
            #region SF 入金検索データクラス⇒入金マスタワーククラス（全てコメントアウト）
            //depsitMainWork.CreateDateTime		= depsitMain.CreateDateTime;
			//depsitMainWork.UpdateDateTime		= depsitMain.UpdateDateTime;
			//depsitMainWork.EnterpriseCode		= depsitMain.EnterpriseCode;
			//depsitMainWork.FileHeaderGuid		= depsitMain.FileHeaderGuid;
			//depsitMainWork.UpdEmployeeCode		= depsitMain.UpdEmployeeCode;
			//depsitMainWork.UpdAssemblyId1		= depsitMain.UpdAssemblyId1;
			//depsitMainWork.UpdAssemblyId2		= depsitMain.UpdAssemblyId2;
			//depsitMainWork.LogicalDeleteCode	= depsitMain.LogicalDeleteCode;
			//depsitMainWork.DepositDebitNoteCd	= depsitMain.DepositDebitNoteCd;
			//depsitMainWork.DepositSlipNo		= depsitMain.DepositSlipNo;
			//depsitMainWork.DepositKindCode		= depsitMain.DepositKindCode;
			//depsitMainWork.CustomerCode			= depsitMain.CustomerCode;
			//depsitMainWork.DepositCd			= depsitMain.DepositCd;
			//depsitMainWork.DepositTotal			= depsitMain.DepositTotal;
			//depsitMainWork.Outline				= depsitMain.Outline;
			//depsitMainWork.AcceptAnOrderSalesNo	= depsitMain.AcceptAnOrderSalesNo;
			//depsitMainWork.InputDepositSecCd	= depsitMain.InputDepositSecCd;
			//depsitMainWork.DepositDate			= depsitMain.DepositDate;
			//depsitMainWork.AddUpSecCode			= depsitMain.AddUpSecCode;
			//depsitMainWork.AddUpADate			= depsitMain.AddUpADate;
			//depsitMainWork.UpdateSecCd			= depsitMain.UpdateSecCd;
			//depsitMainWork.DepositKindName		= depsitMain.DepositKindName;
			//depsitMainWork.DepositAllowance		= depsitMain.DepositAllowance;
			//depsitMainWork.DepositAlwcBlnce		= depsitMain.DepositAlwcBlnce;
			//depsitMainWork.DepositAgentCode		= depsitMain.DepositAgentCode;
			//depsitMainWork.DepositKindDivCd		= depsitMain.DepositKindDivCd;
			//depsitMainWork.FeeDeposit			= depsitMain.FeeDeposit;
			//depsitMainWork.DiscountDeposit		= depsitMain.DiscountDeposit;
			//depsitMainWork.CreditOrLoanCd		= depsitMain.CreditOrLoanCd;
			//depsitMainWork.CreditCompanyCode	= depsitMain.CreditCompanyCode;
			//depsitMainWork.Deposit				= depsitMain.Deposit;
			//depsitMainWork.DraftDrawingDate		= depsitMain.DraftDrawingDate;
			//depsitMainWork.DraftPayTimeLimit	= depsitMain.DraftPayTimeLimit;
			//depsitMainWork.DebitNoteLinkDepoNo	= depsitMain.DebitNoteLinkDepoNo;
			//depsitMainWork.LastReconcileAddUpDt	= depsitMain.LastReconcileAddUpDt;
			//depsitMainWork.AcpOdrDeposit		= depsitMain.AcpOdrDeposit;
			//depsitMainWork.AcpOdrChargeDeposit	= depsitMain.AcpOdrChargeDeposit;
			//depsitMainWork.AcpOdrDisDeposit		= depsitMain.AcpOdrDisDeposit;
			//depsitMainWork.VariousCostDeposit	= depsitMain.VariousCostDeposit;
			//depsitMainWork.VarCostChargeDeposit	= depsitMain.VarCostChargeDeposit;
			//depsitMainWork.VarCostDisDeposit	= depsitMain.VarCostDisDeposit;
			//depsitMainWork.AcpOdrDepositAlwc	= depsitMain.AcpOdrDepositAlwc;
			//depsitMainWork.AcpOdrDepoAlwcBlnce	= depsitMain.AcpOdrDepoAlwcBlnce;
			//depsitMainWork.VarCostDepoAlwc		= depsitMain.VarCostDepoAlwc;
			//depsitMainWork.VarCostDepoAlwcBlnce	= depsitMain.VarCostDepoAlwcBlnce;
            #endregion

            // 作成日時
            depsitMainWork.CreateDateTime       = depsitMain.CreateDateTime;
            // 更新日時
            depsitMainWork.UpdateDateTime       = depsitMain.UpdateDateTime;
            // 企業コード
            depsitMainWork.EnterpriseCode       = depsitMain.EnterpriseCode;
            // GUID
            depsitMainWork.FileHeaderGuid       = depsitMain.FileHeaderGuid;
            // 更新従業員コード
            depsitMainWork.UpdEmployeeCode      = depsitMain.UpdEmployeeCode;
            // 更新アセンブリID1
            depsitMainWork.UpdAssemblyId1       = depsitMain.UpdAssemblyId1;
            // 更新アセンブリID2
            depsitMainWork.UpdAssemblyId2       = depsitMain.UpdAssemblyId2;
            // 論理削除区分
            depsitMainWork.LogicalDeleteCode    = depsitMain.LogicalDeleteCode;
            // 入金赤黒区分
            depsitMainWork.DepositDebitNoteCd   = depsitMain.DepositDebitNoteCd;
            // 入金伝票番号
            depsitMainWork.DepositSlipNo        = depsitMain.DepositSlipNo;
            // 受注番号
            //depsitMainWork.AcceptAnOrderNo      = depsitMain.AcceptAnOrderNo;   // 2007.10.05 del
            // サービス伝票区分
            //depsitMainWork.ServiceSlipCd        = depsitMain.ServiceSlipCd;     // 2007.10.05 del
            // 受注ステータス
            depsitMainWork.AcptAnOdrStatus = depsitMain.AcptAnOdrStatus;          // 2007.10.05 add
            // 売上伝票番号
            depsitMainWork.SalesSlipNum = depsitMain.SalesSlipNum;                // 2007.10.05 add
            // 入金入力拠点コード
            depsitMainWork.InputDepositSecCd    = depsitMain.InputDepositSecCd;
            // 計上拠点コード
            depsitMainWork.AddUpSecCode         = depsitMain.AddUpSecCode;
            // 更新拠点コード
            depsitMainWork.UpdateSecCd          = depsitMain.UpdateSecCd;
            // 入金日付
            depsitMainWork.DepositDate          = depsitMain.DepositDate;
            // 計上日付
            depsitMainWork.AddUpADate           = depsitMain.AddUpADate;

            // 入金金種コード
            depsitMainWork.DepositKindCode = depsitMain.DepositKindCode;
            // 入金金種名称
            depsitMainWork.DepositKindName = depsitMain.DepositKindName;
            // 入金金種区分
            depsitMainWork.DepositKindDivCd = depsitMain.DepositKindDivCd;
            // 入金計
            depsitMainWork.DepositTotal = depsitMain.DepositTotal;

            // 入金金額
            depsitMainWork.Deposit              = depsitMain.Deposit;
            // 手数料入金額
            depsitMainWork.FeeDeposit           = depsitMain.FeeDeposit;
            // 値引入金額
            depsitMainWork.DiscountDeposit      = depsitMain.DiscountDeposit;
            // リベート入金額
            // depsitMainWork.RebateDeposit        = depsitMain.RebateDeposit;       // 2007.10.05 del
            // 自動入金区分
            depsitMainWork.AutoDepositCd        = depsitMain.AutoDepositCd;

            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            // 預り金区分
            //depsitMainWork.DepositCd = depsitMain.DepositCd;
            depsitMainWork.DepositCd = 0;
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

            // クレジット／ローン区分
            // depsitMainWork.CreditOrLoanCd       = depsitMain.CreditOrLoanCd;      // 2007.10.05 del
            // クレジット会社コード
            // depsitMainWork.CreditCompanyCode    = depsitMain.CreditCompanyCode;   // 2007.10.05 del
            // 手形振出日
            depsitMainWork.DraftDrawingDate     = depsitMain.DraftDrawingDate;

            // 手形支払期日
            depsitMainWork.DraftPayTimeLimit = depsitMain.DraftPayTimeLimit;
            // 入金引当額
            depsitMainWork.DepositAllowance = depsitMain.DepositAllowance;
            // 入金引当残高
            depsitMainWork.DepositAlwcBlnce = depsitMain.DepositAlwcBlnce;

            // 赤黒入金連結番号
            depsitMainWork.DebitNoteLinkDepoNo  = depsitMain.DebitNoteLinkDepoNo;
            // 最終消し込み計上日
            depsitMainWork.LastReconcileAddUpDt = depsitMain.LastReconcileAddUpDt;
            // 入金担当者コード
            depsitMainWork.DepositAgentCode     = depsitMain.DepositAgentCode;
            // 入金担当者名称
            depsitMainWork.DepositAgentNm       = depsitMain.DepositAgentNm;
            // 請求先コード
            depsitMainWork.ClaimCode            = depsitMain.ClaimCode;
            // 請求先名称
            depsitMainWork.ClaimName            = depsitMain.ClaimName;
            // 請求先名称2
            depsitMainWork.ClaimName2           = depsitMain.ClaimName2;
            // 請求先略称
            depsitMainWork.ClaimSnm             = depsitMain.ClaimSnm;
            // 得意先コード
            depsitMainWork.CustomerCode         = depsitMain.CustomerCode;
            // 得意先名称
            depsitMainWork.CustomerName         = depsitMain.CustomerName;
            // 得意先名称2
            depsitMainWork.CustomerName2        = depsitMain.CustomerName2;
            // 得意先略称
            depsitMainWork.CustomerSnm          = depsitMain.CustomerSnm;
            // 伝票摘要
            depsitMainWork.Outline              = depsitMain.Outline;
            // ↑ 20070122 18322 c

            // 2007.10.05 add start ---------------------------------------->>
            // 銀行コード
            depsitMainWork.BankCode = depsitMain.BankCode;

            // 銀行名称
            depsitMainWork.BankName = depsitMain.BankName;

            // 手形番号
            depsitMainWork.DraftNo = depsitMain.DraftNo;

            // 手形種類
            depsitMainWork.DraftKind = depsitMain.DraftKind;

            // 手形種類名称
            depsitMainWork.DraftKindName = depsitMain.DraftKindName;

            // 手形区分
            depsitMainWork.DraftDivide = depsitMain.DraftDivide;

            // 手形区分名称
            depsitMainWork.DraftDivideName = depsitMain.DraftDivideName;
            // 2007.10.05 add end ------------------------------------------<<

            return depsitMainWork;
		}

        /// <summary>
        /// クラスメンバーコピー処理（入金検索データクラス⇒入金マスタワーククラス）
        /// </summary>
        /// <param name="depsitMain">入金検索データクラス</param>
        /// <returns>入金マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note        : 入金検索データクラスから入金マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br></br>
        /// </remarks>
        private DepsitDataWork CopyToDepsitDataWorkFromDepsitMain(SearchDepsitMain depsitMain)
        {
            DepsitDataWork depsitDataWork = new DepsitDataWork();

            // 作成日時
            depsitDataWork.CreateDateTime = depsitMain.CreateDateTime;
            // 更新日時
            depsitDataWork.UpdateDateTime = depsitMain.UpdateDateTime;
            // 企業コード
            depsitDataWork.EnterpriseCode = depsitMain.EnterpriseCode;
            // GUID
            depsitDataWork.FileHeaderGuid = depsitMain.FileHeaderGuid;
            // 更新従業員コード
            depsitDataWork.UpdEmployeeCode = depsitMain.UpdEmployeeCode;
            // 更新アセンブリID1
            depsitDataWork.UpdAssemblyId1 = depsitMain.UpdAssemblyId1;
            // 更新アセンブリID2
            depsitDataWork.UpdAssemblyId2 = depsitMain.UpdAssemblyId2;
            // 論理削除区分
            depsitDataWork.LogicalDeleteCode = depsitMain.LogicalDeleteCode;
            // 入金赤黒区分
            depsitDataWork.DepositDebitNoteCd = depsitMain.DepositDebitNoteCd;
            // 入金伝票番号
            depsitDataWork.DepositSlipNo = depsitMain.DepositSlipNo;
            // 受注ステータス
            depsitDataWork.AcptAnOdrStatus = depsitMain.AcptAnOdrStatus;
            // 売上伝票番号
            depsitDataWork.SalesSlipNum = depsitMain.SalesSlipNum;
            // 入金入力拠点コード
            depsitDataWork.InputDepositSecCd = depsitMain.InputDepositSecCd;
            // 計上拠点コード
            depsitDataWork.AddUpSecCode = depsitMain.AddUpSecCode;
            // 更新拠点コード
            depsitDataWork.UpdateSecCd = depsitMain.UpdateSecCd;
            // 入金日付
            depsitDataWork.DepositDate = depsitMain.DepositDate;
            // 計上日付
            depsitDataWork.AddUpADate = depsitMain.AddUpADate;
            // 入金金額
            depsitDataWork.Deposit = depsitMain.Deposit;
            // 手数料入金額
            depsitDataWork.FeeDeposit = depsitMain.FeeDeposit;
            // 値引入金額
            depsitDataWork.DiscountDeposit = depsitMain.DiscountDeposit;
            // 自動入金区分
            depsitDataWork.AutoDepositCd = depsitMain.AutoDepositCd;
            // 預り金区分
            depsitDataWork.DepositCd = 0;
            // 手形振出日
            depsitDataWork.DraftDrawingDate = depsitMain.DraftDrawingDate;
            // 赤黒入金連結番号
            depsitDataWork.DebitNoteLinkDepoNo = depsitMain.DebitNoteLinkDepoNo;
            // 最終消し込み計上日
            depsitDataWork.LastReconcileAddUpDt = depsitMain.LastReconcileAddUpDt;
            // 入金担当者コード
            depsitDataWork.DepositAgentCode = depsitMain.DepositAgentCode;
            // 入金担当者名称
            depsitDataWork.DepositAgentNm = depsitMain.DepositAgentNm;
            // 請求先コード
            depsitDataWork.ClaimCode = depsitMain.ClaimCode;
            // 請求先名称
            depsitDataWork.ClaimName = depsitMain.ClaimName;
            // 請求先名称2
            depsitDataWork.ClaimName2 = depsitMain.ClaimName2;
            // 請求先略称
            depsitDataWork.ClaimSnm = depsitMain.ClaimSnm;
            // 得意先コード
            depsitDataWork.CustomerCode = depsitMain.CustomerCode;
            // 得意先名称
            depsitDataWork.CustomerName = depsitMain.CustomerName;
            // 得意先名称2
            depsitDataWork.CustomerName2 = depsitMain.CustomerName2;
            // 得意先略称
            depsitDataWork.CustomerSnm = depsitMain.CustomerSnm;
            // 伝票摘要
            depsitDataWork.Outline = depsitMain.Outline;
            // 銀行コード
            depsitDataWork.BankCode = depsitMain.BankCode;
            // 銀行名称
            depsitDataWork.BankName = depsitMain.BankName;
            // 手形番号
            depsitDataWork.DraftNo = depsitMain.DraftNo;
            // 手形種類
            depsitDataWork.DraftKind = depsitMain.DraftKind;
            // 手形種類名称
            depsitDataWork.DraftKindName = depsitMain.DraftKindName;
            // 手形区分
            depsitDataWork.DraftDivide = depsitMain.DraftDivide;
            // 手形区分名称
            depsitDataWork.DraftDivideName = depsitMain.DraftDivideName;

            return depsitDataWork;
        }

		/// <summary>
		/// クラスメンバーコピー処理（入金引当マスタクラス⇒入金引当マスタワーククラス）
		/// </summary>
		/// <param name="depositAlwList">入金引当マスタクラス</param>
		/// <returns>入金マスタワーククラス</returns>
		/// <remarks>
		/// <br>Note        : 入金引当マスタクラスから入金マスタワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        /// <br>                MA.NS用に変更</br>
        /// <br></br>
		/// </remarks>
		private DepositAlwWork[] CopyToDepositAlwWorkFromDepositAlw(Hashtable depositAlwList)
		{
			ArrayList arrDepositAlw = new ArrayList();

			foreach (DictionaryEntry de in depositAlwList)
			{
				SearchDepositAlw depositAlw = (SearchDepositAlw)de.Value;
				DepositAlwWork depositAlwWork = new DepositAlwWork();

                // ↓ 20070122 18322 c MA.NS用に変更
                #region SF 入金引当マスタクラス⇒入金引当マスタワーククラス（全てコメントアウト）
                //depositAlwWork.CreateDateTime		= depositAlw.CreateDateTime;
				//depositAlwWork.UpdateDateTime		= depositAlw.UpdateDateTime;
				//depositAlwWork.EnterpriseCode		= depositAlw.EnterpriseCode;
				//depositAlwWork.FileHeaderGuid		= depositAlw.FileHeaderGuid;
				//depositAlwWork.UpdEmployeeCode		= depositAlw.UpdEmployeeCode;
				//depositAlwWork.UpdAssemblyId1		= depositAlw.UpdAssemblyId1;
				//depositAlwWork.UpdAssemblyId2		= depositAlw.UpdAssemblyId2;
				//depositAlwWork.LogicalDeleteCode	= depositAlw.LogicalDeleteCode;
				//depositAlwWork.CustomerCode			= depositAlw.CustomerCode;
				//depositAlwWork.AddUpSecCode			= depositAlw.AddUpSecCode;
				//depositAlwWork.AcceptAnOrderNo		= depositAlw.AcceptAnOrderNo;
				//depositAlwWork.DepositSlipNo		= depositAlw.DepositSlipNo;
				//depositAlwWork.DepositKindCode		= depositAlw.DepositKindCode;
				//depositAlwWork.DepositInputDate		= depositAlw.DepositInputDate;
				//depositAlwWork.DepositAllowance		= depositAlw.DepositAllowance;
				//depositAlwWork.ReconcileDate		= depositAlw.ReconcileDate;
				//depositAlwWork.ReconcileAddUpDate	= depositAlw.ReconcileAddUpDate;
				//depositAlwWork.DebitNoteOffSetCd	= depositAlw.DebitNoteOffSetCd;
				//depositAlwWork.DepositCd			= depositAlw.DepositCd;
				//depositAlwWork.CreditOrLoanCd		= depositAlw.CreditOrLoanCd;
				//depositAlwWork.AcpOdrDepositAlwc	= depositAlw.AcpOdrDepositAlwc;
				//depositAlwWork.VarCostDepoAlwc		= depositAlw.VarCostDepoAlwc;
                #endregion 

                // 作成日時
                depositAlwWork.CreateDateTime     = depositAlw.CreateDateTime;
                // 更新日時
                depositAlwWork.UpdateDateTime     = depositAlw.UpdateDateTime;
                // 企業コード
                depositAlwWork.EnterpriseCode     = depositAlw.EnterpriseCode;
                // GUID
                depositAlwWork.FileHeaderGuid     = depositAlw.FileHeaderGuid;
                // 更新従業員コード
                depositAlwWork.UpdEmployeeCode    = depositAlw.UpdEmployeeCode;
                // 更新アセンブリID1
                depositAlwWork.UpdAssemblyId1     = depositAlw.UpdAssemblyId1;
                // 更新アセンブリID2
                depositAlwWork.UpdAssemblyId2     = depositAlw.UpdAssemblyId2;
                // 論理削除区分
                depositAlwWork.LogicalDeleteCode  = depositAlw.LogicalDeleteCode;
                // 入金入力拠点コード
                depositAlwWork.InputDepositSecCd  = depositAlw.InputDepositSecCd;
                // 計上拠点コード
                depositAlwWork.AddUpSecCode       = depositAlw.AddUpSecCode;
                // 消込み日
                depositAlwWork.ReconcileDate      = depositAlw.ReconcileDate;
                // 消込み計上日
                depositAlwWork.ReconcileAddUpDate = depositAlw.ReconcileAddUpDate;
                // 入金伝票番号
                depositAlwWork.DepositSlipNo      = depositAlw.DepositSlipNo;

                // 入金金種コード
                depositAlwWork.DepositKindCode    = depositAlw.DepositKindCode;
                // 入金金種名称
                depositAlwWork.DepositKindName    = depositAlw.DepositKindName;

                // 入金引当額
                depositAlwWork.DepositAllowance   = depositAlw.DepositAllowance;
                // 入金担当者コード
                depositAlwWork.DepositAgentCode   = depositAlw.DepositAgentCode;
                // 入金担当者名称
                depositAlwWork.DepositAgentNm     = depositAlw.DepositAgentNm;
                // 得意先コード
                depositAlwWork.CustomerCode       = depositAlw.CustomerCode;
                // 得意先名称
                depositAlwWork.CustomerName       = depositAlw.CustomerName;
                // 得意先名称2
                depositAlwWork.CustomerName2      = depositAlw.CustomerName2;
                // 受注番号
                // depositAlwWork.AcceptAnOrderNo    = depositAlw.AcceptAnOrderNo; // 2007.10.05 del
                // 受注ステータス
                depositAlwWork.AcptAnOdrStatus = depositAlw.AcptAnOdrStatus;       // 2007.10.05 add
                // 売上伝票番号
                depositAlwWork.SalesSlipNum = depositAlw.SalesSlipNum;             // 2007.10.05 add
                // サービス伝票区分
                // depositAlwWork.ServiceSlipCd      = depositAlw.ServiceSlipCd;   // 2007.10.05 del
                // 赤伝相殺区分
                depositAlwWork.DebitNoteOffSetCd  = depositAlw.DebitNoteOffSetCd;

                // 預り金区分
                depositAlwWork.DepositCd = depositAlw.DepositCd;

                // クレジット／ローン区分
                // depositAlwWork.CreditOrLoanCd     = depositAlw.CreditOrLoanCd;  // 2007.10.05 del
                // ↑ 20070122 18322 c

                arrDepositAlw.Add(depositAlwWork);
			}

			DepositAlwWork[] list = (DepositAlwWork[])arrDepositAlw.ToArray(typeof(DepositAlwWork));

			return list;
		}

           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        # endregion

        # region Public class (parameter)

        # region Public class SearchCustomerParameter
        /// <summary>得意先情報/得意先金額情報取得用パラメータ</summary>
		public class SearchCustomerParameter
		{
			/// <summary>コンストラクタ</summary>
			public SearchCustomerParameter()
			{
				_enterpriseCode = "";
				_addUpSecCod = "";
				_addUpADate = 0;
				_customerCode = 0;
                _claimCode = 0;
			}

			/// <summary>企業コード</summary>
			private string _enterpriseCode;
			/// <summary>計上拠点</summary>
			private string _addUpSecCod;
			/// <summary>計上日</summary>
			private Int32 _addUpADate;
			/// <summary>得意先コード</summary>
			private Int32 _customerCode;
            /// <summary>請求先コード</summary>
            private Int32 _claimCode;

			/// <summary>企業コード プロパティ</summary>
			public string EnterpriseCode
			{
				get{return _enterpriseCode;}
				set{_enterpriseCode = value;}
			}
			/// <summary>計上拠点 プロパティ</summary>
			public string AddUpSecCod
			{
				get{return _addUpSecCod;}
				set{_addUpSecCod = value;}
			}
			/// <summary>計上日 プロパティ</summary>
			public Int32 AddUpADate
			{
				get{return _addUpADate;}
				set{_addUpADate = value;}
			}
			/// <summary>得意先コード プロパティ</summary>
			public Int32 CustomerCode
			{
				get{return _customerCode;}
				set{_customerCode = value;}
			}
            /// <summary>請求先コード プロパティ</summary>
            public Int32 ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
		}
		# endregion

		# region Public class SearchDepositParameter
        // ↓ 20070125 18322 c MA.NS用に変更
        #region SF 入金情報/引当情報取得用パラメータ（全てコメントアウト）
        ///// <summary>入金情報/引当情報取得用パラメータ</summary>
		//public class SearchDepositParameter
		//{
		//	/// <summary>コンストラクタ</summary>
		//	public SearchDepositParameter()
		//	{
		//		_enterpriseCode = "";
		//		_addUpSecCod = "";
		//		_customerCode = 0;
		//		_depositSlipNo = 0;
		//		_acceptAnOrderNo = 0;
		//		_depositDateStart = 0;
		//		_depositDateEnd = 0;
		//		_alwcDepositCall = 0;
		//	}
		//
		//	/// <summary>企業コード</summary>
		//	private string _enterpriseCode;
		//	/// <summary>計上拠点</summary>
		//	private string _addUpSecCod;
		//	/// <summary>得意先コード</summary>
		//	private Int32 _customerCode;
		//	/// <summary>入金伝票番号</summary>
		//	private Int32 _depositSlipNo;
		//	/// <summary>受注番号</summary>
		//	private Int32 _acceptAnOrderNo;
		//	/// <summary>入金日 開始</summary>
		//	private Int32 _depositDateStart;
		//	/// <summary>入金日 終了</summary>
		//	private Int32 _depositDateEnd;
		//	/// <summary>引当済入金伝票呼出区分</summary>
		//	private Int32 _alwcDepositCall;
		//
		//	/// <summary>企業コード プロパティ</summary>
		//	public string EnterpriseCode
		//	{
		//		get{return _enterpriseCode;}
		//		set{_enterpriseCode = value;}
		//	}
		//	/// <summary>計上拠点 プロパティ</summary>
		//	public string AddUpSecCod
		//	{
		//		get{return _addUpSecCod;}
		//		set{_addUpSecCod = value;}
		//	}
		//	/// <summary>得意先コード プロパティ</summary>
		//	public Int32 CustomerCode
		//	{
		//		get{return _customerCode;}
		//		set{_customerCode = value;}
		//	}
		//	/// <summary>入金伝票番号 プロパティ</summary>
		//	public Int32 DepositSlipNo
		//	{
		//		get{return _depositSlipNo;}
		//		set{_depositSlipNo = value;}
		//	}
		//	/// <summary>受注番号 プロパティ</summary>
		//	public Int32 AcceptAnOrderNo
		//	{
		//		get{return _acceptAnOrderNo;}
		//		set{_acceptAnOrderNo = value;}
		//	}
		//	/// <summary>入金日 開始 プロパティ</summary>
		//	public Int32 DepositDateStart
		//	{
		//		get{return _depositDateStart;}
		//		set{_depositDateStart = value;}
		//	}
		//	/// <summary>入金日 終了 プロパティ</summary>
		//	public Int32 DepositDateEnd
		//	{
		//		get{return _depositDateEnd;}
		//		set{_depositDateEnd = value;}
		//	}
		//	/// <summary>引当済入金伝票呼出区分 プロパティ</summary>
		//	public Int32 AlwcDepositCall
		//	{
		//		get{return _alwcDepositCall;}
		//		set{_alwcDepositCall = value;}
		//	}
        //}
        #endregion

		/// public class name:   SearchDepositParameter
		/// <summary>
		///                      入金情報／引当情報取得用パラメータ
		/// </summary>
		/// <remarks>
		/// <br>note             :   入金情報／引当情報取得用パラメータヘッダファイル</br>
		/// <br>Programmer       :   自動生成</br>
		/// <br>Date             :   木村 武正</br>
		/// <br>Genarated Date   :   2007/02/01  (CSharp File Generated Date)</br>
		/// <br>Update Note      :   </br>
		/// </remarks>
		public class SearchDepositParameter
		{
			/// <summary>企業コード</summary>
			/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
			private string _enterpriseCode = "";
	
			/// <summary>計上拠点コード</summary>
			/// <remarks>集計の対象となっている拠点コード</remarks>
			private string _addUpSecCode = "";

            /// <summary>請求先コード</summary>
            private Int32 _claimCode;

			/// <summary>得意先コード</summary>
			private Int32 _customerCode;
	
			///// <summary>受注番号</summary>
			// private Int32 _acceptAnOrderNo;   // 2007.10.05 del
	
			/// <summary>受注ステータス</summary>
			/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
			private Int32 _acptAnOdrStatus;
	
			/// <summary>売上伝票番号</summary>
			private string _salesSlipNum = "";
	
			///// <summary>受注伝票番号</summary>
            //private Int32 _acptAnOdrSlipNum;  // 2007.10.05 del
	
			/// <summary>入金伝票番号</summary>
			private Int32 _depositSlipNo;
	
			/// <summary>入金日(開始)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _depositCallMonthsStart;
	
			/// <summary>入金日(終了)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _depositCallMonthsEnd;
	
			/// <summary>引当済入金伝票呼出区分</summary>
			private Int32 _alwcDepositCall;
	
	
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
	
			/// public propaty name  :  AddUpSecCode
			/// <summary>計上拠点コードプロパティ</summary>
			/// <value>集計の対象となっている拠点コード</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   計上拠点コードプロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public string AddUpSecCode
			{
				get{return _addUpSecCode;}
				set{_addUpSecCode = value;}
			}

            /// public propaty name  :  ClaimCode
            /// <summary>請求先コードプロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   請求先コードプロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int32 ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
	
			/// public propaty name  :  CustomerCode
			/// <summary>得意先コードプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   得意先コードプロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 CustomerCode
			{
				get{return _customerCode;}
				set{_customerCode = value;}
			}
	
            // 2007.10.05 hikita del start ------------------------------------------------>>
            ///// public propaty name  :  AcceptAnOrderNo
            ///// <summary>受注番号プロパティ</summary>
            ///// ----------------------------------------------------------------------
            ///// <remarks>
            ///// <br>note             :   受注番号プロパティ</br>
            ///// <br>Programer        :   自動生成</br>
            ///// </remarks>
            //public Int32 AcceptAnOrderNo
            //{
            //    get{return _acceptAnOrderNo;}
            //    set{_acceptAnOrderNo = value;}
            //}
            // 2007.10.05 hikita del end --------------------------------------------------<<
	
			/// public propaty name  :  AcptAnOdrStatus
			/// <summary>受注ステータスプロパティ</summary>
			/// <value>1:予約,2:予約キャンセル,10:見積,11:見積キャンセル20:受注,21:受注キャンセル,30:売上,40:売切,45:売切計上,50:委託,55:委託計上</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   受注ステータスプロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 AcptAnOdrStatus
			{
				get{return _acptAnOdrStatus;}
				set{_acptAnOdrStatus = value;}
			}
	
			/// public propaty name  :  SalesSlipNum
			/// <summary>売上伝票番号プロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   売上伝票番号プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public string SalesSlipNum
			{
				get{return _salesSlipNum;}
				set{_salesSlipNum = value;}
			}

            // 2007.10.05 del start ------------------------------------------------>>
            ///// public propaty name  :  AcptAnOdrSlipNum
            ///// <summary>受注伝票番号プロパティ</summary>
            ///// ----------------------------------------------------------------------
            ///// <remarks>
            ///// <br>note             :   受注伝票番号プロパティ</br>
            ///// <br>Programer        :   自動生成</br>
            ///// </remarks>
            //public Int32 AcptAnOdrSlipNum
            //{
            //    get{return _acptAnOdrSlipNum;}
            //    set{_acptAnOdrSlipNum = value;}
            //}
            // 2007.10.05 del end --------------------------------------------------<<

			/// public propaty name  :  DepositSlipNo
			/// <summary>入金伝票番号プロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   入金伝票番号プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 DepositSlipNo
			{
				get{return _depositSlipNo;}
				set{_depositSlipNo = value;}
			}
	
			/// public propaty name  :  DepositCallMonthsStart
			/// <summary>入金日(開始)プロパティ</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   入金日(開始)プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 DepositCallMonthsStart
			{
				get{return _depositCallMonthsStart;}
				set{_depositCallMonthsStart = value;}
			}
	
			/// public propaty name  :  DepositCallMonthsEnd
			/// <summary>入金日(終了)プロパティ</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   入金日(終了)プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 DepositCallMonthsEnd
			{
				get{return _depositCallMonthsEnd;}
				set{_depositCallMonthsEnd = value;}
			}
	
			/// public propaty name  :  AlwcDepositCall
			/// <summary>引当済入金伝票呼出区分プロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   引当済入金伝票呼出区分プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 AlwcDepositCall
			{
				get{return _alwcDepositCall;}
				set{_alwcDepositCall = value;}
			}
	
	
			/// <summary>
			/// 入金情報／引当情報取得用パラメータコンストラクタ
			/// </summary>
			/// <returns>SearchDepositParameterクラスのインスタンス</returns>
			/// <remarks>
			/// <br>Note　　　　　　 :   SearchDepositParameterクラスの新しいインスタンスを生成します</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public SearchDepositParameter()
			{
			}
	
		}
        # endregion

        // ↓ 20070122 18322 c MA.NS用に変更
		# region Public class SearchSalesParameter(コメントアウト)
		///// <summary>請求売上情報取得用パラメータ</summary>
		//public class SearchSalesParameter
		//{
		//	/// <summary>コンストラクタ</summary>
		//	public SearchSalesParameter()
		//	{
		//		_enterpriseCode = "";
		//		_addUpSecCod = "";
		//		_customerCode = 0;
		//		_acceptAnOrderNo = 0;
		//		_slipNo = "";
		//		_searchSlipDateStart = 0;
		//		_searchSlipDateEnd = 0;
		//		_addUpADateStart = 0;
		//		_addUpADateEnd = 0;
		//		_alwcDmdSalesCall = 0;
		//		_acptAnOdrStatus = null;
		//		_dataInputSystem = null;
		//		_autoAuctionDiv = 0;
		//		_creditOrLoanCd = null;
		//		_creditCompanyCode = "";
		//		_salesEmployeeCd = "";
		//		_acceptAnOrderDateStart = 0;
		//		_acceptAnOrderDateEnd = 0;
		//		_carDeliExpectedDateStart = 0;
		//		_carDeliExpectedDateEnd = 0;
		//	}
        //
		//	/// <summary>企業コード</summary>
		//	private string _enterpriseCode;
		//	/// <summary>計上拠点</summary>
		//	private string _addUpSecCod;
		//	/// <summary>得意先コード</summary>
		//	private Int32 _customerCode;
		//	/// <summary>受注伝票番号</summary>
		//	private Int32 _acceptAnOrderNo;
		//	/// <summary>伝票番号</summary>
		//	private string _slipNo;
		//	/// <summary>伝票日付 開始</summary>
		//	private Int32 _searchSlipDateStart;
		//	/// <summary>伝票日付 終了</summary>
		//	private Int32 _searchSlipDateEnd;
		//	/// <summary>受注計上日 開始</summary>
		//	private Int32 _addUpADateStart;
		//	/// <summary>受注計上日 終了</summary>
		//	private Int32 _addUpADateEnd;
		//	/// <summary>引当済請求売上伝票呼出区分</summary>
		//	private Int32 _alwcDmdSalesCall;
		//	/// <summary>受注ステータス</summary>
		//	private Int32[] _acptAnOdrStatus;
		//	/// <summary>データ入力システム</summary>
		//	private Int32[] _dataInputSystem;
		//	/// <summary>AA抽出区分</summary>
		//	private Int32 _autoAuctionDiv;
		//	/// <summary>クレジット・ローン区分</summary>
		//	private Int32[] _creditOrLoanCd;
		//	/// <summary>クレジット会社コード</summary>
		//	private string _creditCompanyCode;
		//	/// <summary>販売従業員コード</summary>
		//	private string _salesEmployeeCd;
		//	/// <summary>受注日(開始)</summary>
		//	private Int32 _acceptAnOrderDateStart;
		//	/// <summary>受注日(終了)</summary>
		//	private Int32 _acceptAnOrderDateEnd;
		//	/// <summary>納車予定日(開始)</summary>
		//	private Int32 _carDeliExpectedDateStart;
		//	/// <summary>納車予定日(終了)</summary>
		//	private Int32 _carDeliExpectedDateEnd;
		//	
		//	/// <summary>企業コード プロパティ</summary>
		//	public string EnterpriseCode
		//	{
		//		get{return _enterpriseCode;}
		//		set{_enterpriseCode = value;}
		//	}
		//	/// <summary>計上拠点 プロパティ</summary>
		//	public string AddUpSecCod
		//	{
		//		get{return _addUpSecCod;}
		//		set{_addUpSecCod = value;}
		//	}
		//	/// <summary>得意先コード プロパティ</summary>
		//	public Int32 CustomerCode
		//	{
		//		get{return _customerCode;}
		//		set{_customerCode = value;}
		//	}
		//	/// <summary>受注伝票番号 プロパティ</summary>
		//	public Int32 AcceptAnOrderNo
		//	{
		//		get{return _acceptAnOrderNo;}
		//		set{_acceptAnOrderNo = value;}
		//	}
		//	/// <summary>伝票番号 プロパティ</summary>
		//	public string SlipNo
		//	{
		//		get{return _slipNo;}
		//		set{_slipNo = value;}
		//	}
		//	/// <summary>伝票日付 開始 プロパティ</summary>
		//	public Int32 SearchSlipDateStart
		//	{
		//		get{return _searchSlipDateStart;}
		//		set{_searchSlipDateStart = value;}
		//	}
		//	/// <summary>伝票日付 終了 プロパティ</summary>
		//	public Int32 SearchSlipDateEnd
		//	{
		//		get{return _searchSlipDateEnd;}
		//		set{_searchSlipDateEnd = value;}
		//	}
		//	/// <summary>受注計上日 開始 プロパティ</summary>
		//	public Int32 AddUpADateStart
		//	{
		//		get{return _addUpADateStart;}
		//		set{_addUpADateStart = value;}
		//	}
		//	/// <summary>受注計上日 終了 プロパティ</summary>
		//	public Int32 AddUpADateEnd
		//	{
		//		get{return _addUpADateEnd;}
		//		set{_addUpADateEnd = value;}
		//	}
		//	/// <summary>引当済請求売上伝票呼出区分 プロパティ</summary>
		//	public Int32 AlwcDmdSalesCall
		//	{
		//		get{return _alwcDmdSalesCall;}
		//		set{_alwcDmdSalesCall = value;}
		//	}
		//	/// <summary>受注ステータス プロパティ</summary>
		//	public Int32[] AcptAnOdrStatus
		//	{
		//		get{return _acptAnOdrStatus;}
		//		set{_acptAnOdrStatus = value;}
		//	}
		//	/// <summary>データ入力システム プロパティ</summary>
		//	public Int32[] DataInputSystem
		//	{
		//		get{return _dataInputSystem;}
		//		set{_dataInputSystem = value;}
		//	}
		//	/// <summary>AA抽出区分</summary>
		//	public Int32 AutoAuctionDiv
		//	{
		//		get{return _autoAuctionDiv;}
		//		set{_autoAuctionDiv = value;}
		//	}
		//	/// <summary>クレジット・ローン区分</summary>
		//	public Int32[] CreditOrLoanCd
		//	{
		//		get{return _creditOrLoanCd;}
		//		set{_creditOrLoanCd = value;}
		//	}
		//	/// <summary>クレジット会社コード</summary>
		//	public string CreditCompanyCode
		//	{
		//		get{return _creditCompanyCode;}
		//		set{_creditCompanyCode = value;}
		//	}
		//	/// <summary>販売従業員コード</summary>
		//	public string SalesEmployeeCd
		//	{
		//		get{return _salesEmployeeCd;}
		//		set{_salesEmployeeCd = value;}
		//	}
		//	/// <summary>受注日(開始)</summary>
		//	public Int32 AcceptAnOrderDateStart
		//	{
		//		get{return _acceptAnOrderDateStart;}
		//		set{_acceptAnOrderDateStart = value;}
		//	}
		//	/// <summary>受注日(終了)</summary>
		//	public Int32 AcceptAnOrderDateEnd
		//	{
		//		get{return _acceptAnOrderDateEnd;}
		//		set{_acceptAnOrderDateEnd = value;}
		//	}
		//	/// <summary>納車予定日(開始)</summary>
		//	public Int32 CarDeliExpectedDateStart
		//	{
		//		get{return _carDeliExpectedDateStart;}
		//		set{_carDeliExpectedDateStart = value;}
		//	}
		//	/// <summary>納車予定日(終了)</summary>
		//	public Int32 CarDeliExpectedDateEnd
		//	{
		//		get{return _carDeliExpectedDateEnd;}
		//		set{_carDeliExpectedDateEnd = value;}
		//	}
		//}
		# endregion

        #region MA.NS 請求売上情報取得用パラメータ
		/// <summary>請求売上情報取得用パラメータ</summary>
		/// <remarks>コンストラクタを除き、MAHNB01216Dのパラメータと同様です。</remarks>
        //     ※ 引当済売上伝票呼出区分の初期値「-1」に注意
        public class SearchSalesParameter
		{
			/// <summary>コンストラクタ</summary>
			public SearchSalesParameter()
			{
				// <summary>企業コード</summary>
				_enterpriseCode = "";
		
				// <summary>受注ステータス</summary>
				_acptAnOdrStatus = null;
		
				// <summary>売上伝票番号</summary>
				_salesSlipNum = "";
		
				// <summary>得意先コード</summary>
				_customerCode = 0;

                // <summary>請求先コード</summary>
                _claimCode = 0;

				// <summary>計上日付(開始)</summary>
				_addUpADateStart = 0;
		
				// <summary>計上日付(終了)</summary>
				_addUpADateEnd = 0;

				// <summary>請求計上拠点コード</summary>
				_demandAddUpSecCd = "";
		
				// <summary>実績計上拠点コード</summary>
				_resultsAddUpSecCd = "";

				// <summary>引当済売上伝票呼出区分</summary>
				_alwcSalesSlipCall = -1;

				// <summary>販売従業員コード</summary>
				_salesEmployeeCd = "";

				// <summary>伝票検索日付(開始)</summary>
				_searchSlipDateStart = 0;
		
				// <summary>伝票検索日付(終了)</summary>
				_searchSlipDateEnd = 0;

                // <summary>サービス伝票区分</summary>
                _serviceSlipCd = 0;

                // <summary>売掛区分</summary>
                _accRecDivCd = 0;

                // <summary>自動入金区分</summary>
                _autoDepositCd = 0;
			}

			/// <summary>企業コード</summary>
			/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
			private string _enterpriseCode = "";
	
			/// <summary>受注ステータス</summary>
			/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
			private Int32[] _acptAnOdrStatus;
	
			/// <summary>売上伝票番号</summary>
			private string _salesSlipNum = "";
	
			/// <summary>得意先コード</summary>
			private Int32 _customerCode;

            /// <summary>請求先コード</summary>
            private Int32 _claimCode;

			/// <summary>計上日付(開始)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _addUpADateStart;
	
			/// <summary>計上日付(終了)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _addUpADateEnd;
	
			/// <summary>請求計上拠点コード</summary>
			/// <remarks>文字型</remarks>
			private string _demandAddUpSecCd = "";
	
			/// <summary>実績計上拠点コード</summary>
			/// <remarks>実績計上を行う企業内の拠点コード</remarks>
			private string _resultsAddUpSecCd = "";
	
			/// <summary>引当済売上伝票呼出区分</summary>
			/// <remarks>=0：引当済、!=0：未引当</remarks>
			private Int32 _alwcSalesSlipCall;
	
			/// <summary>販売従業員コード</summary>
			private string _salesEmployeeCd = "";
	
			/// <summary>伝票検索日付(開始)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _searchSlipDateStart;
	
			/// <summary>伝票検索日付(終了)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _searchSlipDateEnd;

            /// <summary>サービス伝票区分</summary>
            private Int32 _serviceSlipCd;

            /// <summary>売掛区分</summary>
            private Int32 _accRecDivCd;

            /// <summary>自動入金区分</summary>
            private Int32 _autoDepositCd;
	
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
	
			/// public propaty name  :  AcptAnOdrStatus
			/// <summary>受注ステータスプロパティ</summary>
			/// <value>1:予約,2:予約キャンセル,10:見積,11:見積キャンセル20:受注,21:受注キャンセル,30:売上,40:売切,45:売切計上,50:委託,55:委託計上</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   受注ステータスプロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32[] AcptAnOdrStatus
			{
				get{return _acptAnOdrStatus;}
				set{_acptAnOdrStatus = value;}
			}
	
			/// public propaty name  :  SalesSlipNum
			/// <summary>売上伝票番号プロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   売上伝票番号プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public string SalesSlipNum
			{
				get{return _salesSlipNum;}
				set{_salesSlipNum = value;}
			}

			/// public propaty name  :  CustomerCode
			/// <summary>得意先コードプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   得意先コードプロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 CustomerCode
			{
				get{return _customerCode;}
				set{_customerCode = value;}
			}

            /// public propaty name  :  ClaimCode
            /// <summary>請求先コードプロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   請求先コードプロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int32 ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }

			/// public propaty name  :  AddUpADateStart
			/// <summary>計上日付(開始)プロパティ</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   計上日付(開始)プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 AddUpADateStart
			{
				get{return _addUpADateStart;}
				set{_addUpADateStart = value;}
			}
	
			/// public propaty name  :  AddUpADateEnd
			/// <summary>計上日付(終了)プロパティ</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   計上日付(終了)プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 AddUpADateEnd
			{
				get{return _addUpADateEnd;}
				set{_addUpADateEnd = value;}
			}
	
			/// public propaty name  :  DemandAddUpSecCd
			/// <summary>請求計上拠点コードプロパティ</summary>
			/// <value>文字型</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   請求計上拠点コードプロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public string DemandAddUpSecCd
			{
				get{return _demandAddUpSecCd;}
				set{_demandAddUpSecCd = value;}
			}
	
			/// public propaty name  :  ResultsAddUpSecCd
			/// <summary>実績計上拠点コードプロパティ</summary>
			/// <value>実績計上を行う企業内の拠点コード</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   実績計上拠点コードプロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public string ResultsAddUpSecCd
			{
				get{return _resultsAddUpSecCd;}
				set{_resultsAddUpSecCd = value;}
			}
	
			/// public propaty name  :  AlwcSalesSlipCall
			/// <summary>引当済売上伝票呼出区分プロパティ</summary>
			/// <value>=0：引当済、!=0：未引当</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   引当済売上伝票呼出区分プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 AlwcSalesSlipCall
			{
				get{return _alwcSalesSlipCall;}
				set{_alwcSalesSlipCall = value;}
			}
	
			/// public propaty name  :  SalesEmployeeCd
			/// <summary>販売従業員コードプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   販売従業員コードプロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public string SalesEmployeeCd
			{
				get{return _salesEmployeeCd;}
				set{_salesEmployeeCd = value;}
			}
	
			/// public propaty name  :  SearchSlipDateStart
			/// <summary>伝票検索日付(開始)プロパティ</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   伝票検索日付(開始)プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 SearchSlipDateStart
			{
				get{return _searchSlipDateStart;}
				set{_searchSlipDateStart = value;}
			}
	
			/// public propaty name  :  SearchSlipDateEnd
			/// <summary>伝票検索日付(終了)プロパティ</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   伝票検索日付(終了)プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 SearchSlipDateEnd
			{
				get{return _searchSlipDateEnd;}
				set{_searchSlipDateEnd = value;}
			}

            /// public propaty name  :  ServiceSlipCd
            /// <summary>サービス伝票区分プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   サービス伝票区分プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int32 ServiceSlipCd
            {
                get { return _serviceSlipCd; }
                set { _serviceSlipCd = value; }
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

            /// public propaty name  :  AutoDepositCd
            /// <summary>自動入金区分プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   自動入金区分プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int32 AutoDepositCd
            {
                get { return _autoDepositCd; }
                set { _autoDepositCd = value; }
            }
        }
        #endregion
        // ↑ 20070122 18322 c

		# endregion

		# region Private class
		//***************************************************************
		// 例外処理クラス
		//***************************************************************
		private class DepositException : ApplicationException
		{
			private int _status;

			# region Constructor
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public DepositException(string message, int status): base(message)
			{
				_status = status;
			}
			# endregion

			# region public property
			public int Status
			{
				get {return _status;}
			}
			# endregion
		}
		//***************************************************************
		// 引当情報 売上伝票番号ソートクラス
		//***************************************************************
		private class cmpAllowance : IComparer
		{
			public int Compare(object obj1, object obj2)
			{
                // 2007.10.05 upd start -------------------------------------------------->>
				// int no1 = Convert.ToInt32(((System.Data.DataRow)obj1)[ctAcceptAnOrderNo_Alw]);
				// int no2 = Convert.ToInt32(((System.Data.DataRow)obj2)[ctAcceptAnOrderNo_Alw]);
                string no1 = Convert.ToString(((DataRow)obj1)[ctSalesSlipNum_Alw]);
                string no2 = Convert.ToString(((DataRow)obj2)[ctSalesSlipNum_Alw]);
                // 2007.10.05 upd end ----------------------------------------------------<<

				return no1.CompareTo(no2);
			}
		}
		# endregion

		# region Enum
		enum UpdateMode
		{
			Insert = 0,
			Update = 1,
			Delete = 2,
			Aka = 3
		}
        // --- ADD K2013/03/22 張曼 Redmine#35063 ---------->>>>>
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        // --- ADD K2013/03/22 張曼 Redmine#35063 ----------<<<<<
		# endregion

        /// <summary>
        /// データソート順処理
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2012/12/24 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private class DepositSlipNoComparer : IComparer
        {
            #region IComparer メンバ
            int IComparer.Compare(object x, object y)
            {
                return (((SearchDepositAlw)x).DepositSlipNo.CompareTo(((SearchDepositAlw)y).DepositSlipNo));
            }
            #endregion
        }
	}
}
