//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入金入力（売上指定型）
// プログラム概要   : 入金入力（売上指定型）の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2008/06/26  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/21  修正内容 : MANTIS【13326】入金日がシステム日付でした登録されない不具合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2010/12/20  修正内容 : PM.NS障害改良対応(12月分)
//                                : ①引当情報表示の改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2011/02/09  修正内容 : Redmine#18848の修正
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 田建委
// 修 正 日  2012/02/10  修正内容 : 2012/03/28配信分 Redmine#28395
//                                  引当保存エラー発生の修正
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 鄧潘ハ
// 作 成 日  2012/02/27  修正内容 : 2012/03/28配信分、Redmine#28395 
//                                  売上指定型で入金した場合、得意先子の入金が売上データと紐付かないについての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日  2012/09/21  修正内容 : 2012/10/17配信分 Redmine#32415
//                                  発行者の追加対応
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : zhujw
// 修 正 日  K2014/05/28 修正内容 : ㈱カト―個別対応  
//                                  ①入金入力（売上指定型）で売上伝票を複数選択し、保存したとき、
//                                    入金伝票が売上伝票それぞれに作成されるように変更を行います。
//                                  ②入金日がガイドではなく、画面（明細）に表示できるようにします。
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : zhujw
// 修 正 日  K2014/06/19 修正内容 : RedMine#42902 既存のデータパラメータを使用する
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using System.Collections.Specialized;
using System.Collections.Generic;
using Broadleaf.Application.Resources; // ADD zhujw K2014/05/28 ㈱カト―個別対応

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 入金入力（売上指定型）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金入力（売上指定型）ＵＩクラスのアクセスクラスです。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br>Update Note: 2007.01.30 18322 T.Kimura MA.NS用に変更</br>
    /// <br>             2007.05.14 18322 T.Kimura 請求売上データの検索パラメータにサービス伝票区分、売掛区分、自動入金区分を追加</br>
    /// <br>             2007.08.01 18322 T.Kimura 月次締めのチェックを追加</br>
    /// <br>             2007.10.05 20081 疋田 勇人 DC.NS用に変更</br> 
    /// <br>             2008/06/26 30414 忍 幸史 Partsman用に変更</br> 
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-支払手形データ更新追加</br>
    /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)
    /// <br>              引当情報表示の改良</br>
    /// <br>Update Note : 2012/02/10 田建委</br>
    /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
    /// <br>              Redmine#28395 引当保存エラー発生の対応</br>
    /// <br>Update Note : 2012/02/27 鄧潘ハン</br>
    /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
    /// <br>              Redmine#28395 売上指定型で入金した場合、得意先子の入金が売上データと紐付かないについての対応</br>
    /// </remarks>
	public class InputDepositSalesTypeAcs
	{
		# region Constructor
		/// <summary>
		/// 入金入力（売上指定型）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public InputDepositSalesTypeAcs()
		{
			// 請求売上情報 DataSet
			this._dsDmdSalesInfo = new DataSet();

            // ↓ 20070125 18322 c MA.NS用に変更
			//// 請求売上検索アクセスクラス
			//this._searchDmdSalesAcs = new SearchDmdSalesAcs();

			// 請求売上検索アクセスクラス
			this._searchDmdSalesAcs = new SearchClaimSalesAcs();
            // ↑ 20070125 18322 c

			// 入金更新アクセスクラス
			this._depsitMainAcs = new DepsitMainAcs();
		
			// 入金入力設定データ系アクセスクラス
			this.depositRelDataAcs = new DepositRelDataAcs();

            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //// リモートオブジェクト取得
            //this._iCustomerInfoDB = (ICustomerInfoDB)MediationCustomerInfoDB.GetCustomerInfoDB();
            this._customerInfoAcs = new CustomerInfoAcs();

            this._employeeAcs = new EmployeeAcs();

            ReadEmployee();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

            // ↓ 20070801 18322 a
            // 月次締め処理のリモートオブジェクト
            this._iMonthlyAddUpDB = (IMonthlyAddUpDB)MediationMonthlyAddUpDB.GetCustMonthlyAddUpDB();

            this._lastMonthlyAddUpHis = null;
            // ↑ 20070801 18322 a
		}
		# endregion

		# region Private Menbers
		//***************************************************************
		// 画面バインド用 DataSet
		//***************************************************************
		/// <summary>請求売上情報 DataSet</summary>
		private DataSet _dsDmdSalesInfo;

		//***************************************************************
		// メンバー
		//***************************************************************
		/// <summary>入金入力設定データ系アクセスクラス</summary>
		private DepositRelDataAcs depositRelDataAcs;

        // ↓ 20070125 18322 c MA.NS用に変更
		///// <summary>請求売上検索アクセスクラス</summary>
		//private SearchDmdSalesAcs _searchDmdSalesAcs;

		/// <summary>請求売上検索アクセスクラス</summary>
		private SearchClaimSalesAcs _searchDmdSalesAcs;
        // ↑ 20070125 18322 c

		/// <summary>入金更新アクセスクラス</summary>
		private DepsitMainAcs _depsitMainAcs;

        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        ///// <summary>得意先リモートクラス</summary>
        //private ICustomerInfoDB _iCustomerInfoDB;
        /// <summary>得意先情報アクセスクラス</summary>
        private CustomerInfoAcs _customerInfoAcs;

        private EmployeeAcs _employeeAcs;

        private Dictionary<string, EmployeeDtl> _emoloyeeDtlDic;

        // 前回月次締日
        private DateTime _lastMonthlyAddUpDay;
        // 前回締日
        private DateTime _lastAddUpDay;

        /// <summary>締日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator;
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

        // ↓ 20070801 18322 a
         // 月次締め処理のリモートオブジェクト
        private IMonthlyAddUpDB     _iMonthlyAddUpDB     = null;

        private MonthlyAddUpHisWork _lastMonthlyAddUpHis = null;

        private IControlDepsitAlwDB _iControlDepsitAlwDB; // ADD zhujw K2014/05/28 ㈱カト―個別対応 
        // ↑ 20070801 18322 a

		# endregion

		# region public const Menbers
		//***************************************************************
		// 請求売上情報DataSet用定数宣言
		//***************************************************************
		/// <summary>請求売上情報Table名称</summary>
		public const string ctDmdSalesDataTable = "DmdSalesTable";

        // ↓ 20070131 18322 c MA.NS用に変更
        #region SF 請求売上情報DataSet用定数宣言（全てコメントアウト）
		///// <summary>引</summary>
		//public const string ctAlwCheck = "AlwCheck";
		//
		///// <summary>請求売上赤黒区分</summary>
		//public const string ctDebitNoteDiv = "DebitNoteDiv";
		//
		///// <summary>請求売上赤黒名称</summary>
		//public const string ctDebitNoteNm = "DebitNoteNm";
		//
		///// <summary>得意先コード</summary>
		//public const string ctCustomerCode = "CustomerCode";
		//
		///// <summary>得意先名称</summary>
		//public const string ctCustomerName = "CustomerName";
		//
		///// <summary>受注番号</summary>
		//public const string ctAcceptAnOrderNo = "AcceptAnOrderNo";
		//
		///// <summary>伝票番号</summary>
		//public const string ctSlipNo = "SlipNo";
		//
		///// <summary>伝票日付(表示用)</summary>
		//public const string ctSearchSlipDateDisp = "SearchSlipDateDisp";
		//
		///// <summary>伝票日付</summary>
		//public const string ctSearchSlipDate = "SearchSlipDate";
		//
		///// <summary>計上日付</summary>
		//public const string ctAddUpADate = "AddUpADate";
		//
		///// <summary>システム</summary>
		//public const string ctDataInputSystem = "DataInputSystem";
		//
		///// <summary>受注ステータス</summary>
		//public const string ctAcptAnOdrStatus = "AcptAnOdrStatus";
		//
		///// <summary>伝票種類</summary>
		//public const string ctSalesKind = "SalesKind";
		//
		///// <summary>売上名称</summary>
		//public const string ctSalesName = "SalesName";
		//
		///// <summary>車両登録番号</summary>
		//public const string ctNumberPlate = "NumberPlate";
		//
		///// <summary>受注売上額</summary>
		//public const string ctAcceptAnOrderSales = "AcceptAnOrderSales";
		//
		///// <summary>諸費用額</summary>
		//public const string ctTotalVariousCost = "TotalVariousCost";
		//
		///// <summary>受注合計額</summary>
		//public const string ctTotalSales = "TotalSales";
		//
		///// <summary>引当額 受注 (入金引当額)</summary>
		//public const string ctAcpOdrDepositAlwc_Alw = "AcpOdrDepositAlwc_Alw";
		//
		///// <summary>引当残 受注 (請求売上マスタ)</summary>
		//public const string ctAcpOdrDepoAlwcBlnce_Sales = "AcpOdrDepoAlwcBlnce_Sales";
		//
		///// <summary>引当済 受注 (請求売上マスタ)</summary>
		//public const string ctAcpOdrDepositAlwc_Sales = "AcpOdrDepositAlwc_Sales";
		//
		///// <summary>引当額 諸費用 (入金引当額)</summary>
		//public const string ctVarCostDepoAlwc_Alw = "VarCostDepoAlwc_Alw";
		//
		///// <summary>引当残 諸費用 (請求売上マスタ)</summary>
		//public const string ctVarCostDepoAlwcBlnce_Sales = "VarCostDepoAlwcBlnce_Sales";
		//
		///// <summary>引当済 諸費用 (請求売上マスタ)</summary>
		//public const string ctVarCostDepoAlwc_Sales = "VarCostDepoAlwc_Sales";
		//
		///// <summary>引当額 共通 (入金引当額)</summary>
		//public const string ctDepositAllowance_Alw = "DepositAllowance_Alw";
		//
		///// <summary>引当残 共通 (請求売上マスタ)</summary>
		//public const string ctDepositAlwcBlnce_Sales = "DepositAlwcBlnce_Sales";
		//
		///// <summary>引当済 共通 (請求売上マスタ)</summary>
		//public const string ctDepositAllowance_Sales = "DepositAllowance_Sales";
		//
		///// <summary>入金内訳</summary>
		//public const string ctDepositAlwBtn = "DepositAlwBtn";
		//
		///// <summary>最終締次更新日</summary>
		//public const string ctLastTotalAddUpDt = "LastTotalAddUpDt";
		//
		///// <summary>締め状態</summary>
		//public const string ctSalesClosedFlg = "ClosedFlg";
        //
		///// <summary>請求売上クラス</summary>
		//public const string ctSearchDmdSalesCustomer = "SearchDmdSalesCustomer";
        #endregion

		/// <summary>引</summary>
		public const string ctAlwCheck = "AlwCheck";

		/// <summary>請求売上赤黒区分</summary>
		public const string ctDebitNoteDiv = "DebitNoteDiv";

		/// <summary>請求売上赤黒名称</summary>
		public const string ctDebitNoteNm = "DebitNoteNm";

        /// <summary>請求先コード</summary>
        public const string ctClaimCode = "ClaimCode";

        /// <summary>請求先名称</summary>
        public const string ctClaimName = "ClaimName";

        ///// <summary>得意先コード</summary>
        //public const string ctCustomerCode = "CustomerCode";

		/// <summary>得意先名称</summary>
		public const string ctCustomerName = "CustomerName";

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>引当</summary>
        public const string ctAllowDiv = "AllowDiv";

        /// <summary>売上伝票番号</summary>
        public const string ctDepSaleSlipNum = "DepSaleSlipNum";
        // --- ADD 2010/12/20  ----------<<<<<

		/// <summary>売上伝票番号</summary>
		public const string ctSalesSlipNum = "SalesSlipNum";

        /// <summary>伝票日付(表示用)</summary>
		public const string ctSearchSlipDateDisp = "SearchSlipDateDisp";

		/// <summary>伝票日付</summary>
		public const string ctSearchSlipDate = "SearchSlipDate";

		/// <summary>計上日付</summary>
		public const string ctAddUpADate = "AddUpADate";

		/// <summary>受注ステータス</summary>
		public const string ctAcptAnOdrStatus = "AcptAnOdrStatus";

        /// <summary>受注ステータス名</summary>
		public const string ctAcptAnOdrStatusNm = "AcptAnOdrStatusNm";

		/// <summary>伝票種類</summary>
		public const string ctSalesKind = "SalesKind";

		/// <summary>伝票備考</summary>
        public const string ctSlipNote = "SlipNote";

        /// <summary>売上伝票合計（税込み）</summary>
        public const string ctSalesTotalTaxExc = "SalesTotalTaxExc";

        // ↓ 20070525 18322 a
		/// <summary>売掛区分(0:売掛なし,1:売掛)</summary>
        public const string ctAccRecDivCd = "AccRecDivCd";
        ///// <summary>レジ処理日</summary>
        //public const string ctRegiProcDate = "RegiProcDate";
        ///// <summary>レジ番号</summary>
        //public const string ctCashRegisterNo = "CashRegisterNo";
        ///// <summary>POSレシート番号</summary>
        //public const string ctPosReceiptNo = "PosReceiptNo";
        // ↑ 20070525 18322 a

		/// <summary>引当額 共通 (入金引当額)</summary>
		public const string ctDepositAllowance_Alw = "DepositAllowance_Alw";

		/// <summary>引当残 共通 (請求売上マスタ)</summary>
		public const string ctDepositAlwcBlnce_Sales = "DepositAlwcBlnce_Sales";

		/// <summary>引当済 共通 (請求売上マスタ)</summary>
		public const string ctDepositAllowance_Sales = "DepositAllowance_Sales";

		/// <summary>入金内訳</summary>
		public const string ctDepositAlwBtn = "DepositAlwBtn";

        // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
        /// <summary>引当日</summary>
        public const string ctDepositDate = "DepositDate";

        /// <summary>担当者</summary>
        public const string ctDepositAgentCode = "DepositAgentCode";

        /// <summary>金種</summary>
        public const string ctDepositKindName = "DepositKindName";
        // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<

		/// <summary>最終締次更新日</summary>
		public const string ctLastTotalAddUpDt = "LastTotalAddUpDt";

		/// <summary>最終月次更新日</summary>
		public const string ctLastMonthlyDate = "LastMonthlyDate";

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>最終月次更新日(表示用)</summary>
        public const string ctLastMonthlyDateDisp = "LastMonthlyDateDisp";

        /// <summary>変更前引当残(請求売上マスタ)</summary>
        public const string ctBfDepositAlwcBlnce_Sales = "BfDepositAlwcBlnce_Sales";

        /// <summary>変更前引当済(請求売上マスタ)</summary>
        public const string ctBfDepositAllowance_Sales = "BfDepositAllowance_Sales";
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>締め状態</summary>
		public const string ctSalesClosedFlg = "ClosedFlg";

		/// <summary>請求売上検索データクラス</summary>
		public const string ctSearchClaimSales = "SearchClaimSales";
        // ↑ 20070131 18322 c

		/// <summary>新規作成入金更新パラメータクラス</summary>
		public const string ctUpdateDepositParameter = "UpdateDepositParameter";

		/// <summary>自身のDataRow</summary>
		public const string ctDmdSalesDataRow = "DmdSalesDataRow";
		# endregion

		# region public Methods
		/// <summary>
		/// 入金入力画面(売上指定型)アクセスクラス 初期化処理
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
			_dsDmdSalesInfo.Clear();
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
			return _dsDmdSalesInfo;
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
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
            #region SF 請求売上情報 列設定(全てコメントアウト)
			//// Addを行う順番が、列の表示順位となります。
			//dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// 引
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepositAlwc_Alw, typeof(Int64));		// 引当額 受注 (入金引当額)
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepoAlwcBlnce_Sales, typeof(Int64));	// 引当残 受注 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepositAlwc_Sales, typeof(Int64));		// 引当済 受注 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwc_Alw, typeof(Int64));			// 引当額 諸費用 (入金引当額)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwcBlnce_Sales, typeof(Int64));	// 引当残 諸費用 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwc_Sales, typeof(Int64));		// 引当済 諸費用 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// 引当額 共通 (入金引当額)
			//dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// 引当残 共通 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// 引当済 共通 (請求売上マスタ)
			//dtDmdSalesTable.Columns.Add(ctDebitNoteDiv, typeof(int));					// 赤黒区分
			//dtDmdSalesTable.Columns.Add(ctDebitNoteNm, typeof(string));					// 赤黒名称
			//dtDmdSalesTable.Columns.Add(ctSlipNo, typeof(string));						// 伝票番号
			//dtDmdSalesTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));				// 受注番号
			//dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// 伝票日付(表示用)
			//dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// 伝票日付
			//dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// 売上日
			//dtDmdSalesTable.Columns.Add(ctCustomerCode, typeof(int));					// 得意先コード
			//dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				// 得意先名称
			//dtDmdSalesTable.Columns.Add(ctDataInputSystem, typeof(int));				// システム
			//dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// 受注ステータス
			//dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// 伝票種類
			//dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// 売上名称
			//dtDmdSalesTable.Columns.Add(ctNumberPlate, typeof(string));					// 登録番号
			//dtDmdSalesTable.Columns.Add(ctAcceptAnOrderSales, typeof(Int64));			// 受注売上額
			//dtDmdSalesTable.Columns.Add(ctTotalVariousCost, typeof(Int64));				// 諸費用額
			//dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// 受注合計額
			//dtDmdSalesTable.Columns.Add(ctLastTotalAddUpDt, typeof(int));				// 最終締次更新日
			//dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// 締フラグ
			//dtDmdSalesTable.Columns.Add(ctSearchDmdSalesCustomer, typeof(SearchDmdSalesCustomer));	// 請求売上クラス
			//dtDmdSalesTable.Columns.Add(ctUpdateDepositParameter, typeof(UpdateDepositParameter));	// 新規作成入金パラメータクラス
			//dtDmdSalesTable.Columns.Add(ctDmdSalesDataRow, typeof(DataRow));			// 自身のDataRow
			//dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// 入金引当ボタン
            #endregion

			// Addを行う順番が、列の表示順位となります。
			dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// 引
			dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// 引当額 共通 (入金引当額)
			dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// 引当残 共通 (請求売上マスタ)
			dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// 引当済 共通 (請求売上マスタ)
			dtDmdSalesTable.Columns.Add(ctDebitNoteDiv, typeof(int));					// 赤黒区分
			dtDmdSalesTable.Columns.Add(ctDebitNoteNm, typeof(string));					// 赤黒名称
			dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                // 売上伝票番号
			dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// 伝票日付(表示用)
			dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// 伝票日付
			dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// 売上日
            dtDmdSalesTable.Columns.Add(ctClaimCode, typeof(int));					    // 請求先コード
            dtDmdSalesTable.Columns.Add(ctClaimName, typeof(string));				    // 請求先名称
			dtDmdSalesTable.Columns.Add(ctCustomerCode, typeof(int));					// 得意先コード
			dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				// 得意先名称
			dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// 受注ステータス
			dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatusNm, typeof(string));			// 受注ステータス名
			dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// 伝票種類
			dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// 売上名称
            dtDmdSalesTable.Columns.Add(ctSalesTotalTaxExc, typeof(Int64));				// 売上伝票合計（税込み）
            // ↓ 20070525 18322 a MK.NS用に変更
            dtDmdSalesTable.Columns.Add(ctAccRecDivCd   , typeof(int));                 // 売掛区分(0:売掛なし,1:売掛)
            //dtDmdSalesTable.Columns.Add(ctRegiProcDate  , typeof(string));              // レジ処理日
            //dtDmdSalesTable.Columns.Add(ctCashRegisterNo, typeof(int));                 // レジ番号
            //dtDmdSalesTable.Columns.Add(ctPosReceiptNo  , typeof(int));                 // POSレシート番号
            // ↑ 20070525 18322 a MK.NS用に変更
			dtDmdSalesTable.Columns.Add(ctLastTotalAddUpDt, typeof(int));				// 最終締次更新日
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDate, typeof(int));                // 最終月次締め日
			dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// 締フラグ
			dtDmdSalesTable.Columns.Add(ctSearchClaimSales, typeof(SearchClaimSales));	// 請求売上検索データクラス
			dtDmdSalesTable.Columns.Add(ctUpdateDepositParameter, typeof(UpdateDepositParameter));	// 新規作成入金パラメータクラス
			dtDmdSalesTable.Columns.Add(ctDmdSalesDataRow, typeof(DataRow));			// 自身のDataRow
			dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// 入金引当ボタン
            // ↑ 20070131 18322 c
			
			// データセットに追加
			_dsDmdSalesInfo.Tables.Add(dtDmdSalesTable.Clone());
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 請求売上情報 DataSet Table 作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 請求売上情報データセットのテーブルを作成します。
        ///	               :   ※ Method : GetDsDepositInfo より結果取得</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// <br>Update Note: 2010/12/20 李占川 PM.NS障害改良対応(12月分)
        /// <br>             項目「引当」を追加する。</br>
        /// </remarks>
        public void CreateDmdSalesDataTable()
        {
            // データテーブルの列定義
            DataTable dtDmdSalesTable = new DataTable(ctDmdSalesDataTable);

            // Addを行う順番が、列の表示順位となります。
            dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						            // 引
            dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			            // 引当額 共通 (入金引当額)
            dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		            // 引当残 共通 (請求売上マスタ)
            dtDmdSalesTable.Columns.Add(ctBfDepositAlwcBlnce_Sales, typeof(Int64));		            // 変更前引当残(請求売上マスタ)
            dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		            // 引当済 共通 (請求売上マスタ)
            dtDmdSalesTable.Columns.Add(ctBfDepositAllowance_Sales, typeof(Int64));		            // 変更前引当済(請求売上マスタ)
            dtDmdSalesTable.Columns.Add(ctDebitNoteDiv, typeof(int));					            // 赤黒区分
            dtDmdSalesTable.Columns.Add(ctDebitNoteNm, typeof(string));					            // 赤黒名称
            dtDmdSalesTable.Columns.Add(ctAllowDiv, typeof(string));                                // 引当 // ADD 2010/12/20
            dtDmdSalesTable.Columns.Add(ctDepSaleSlipNum, typeof(string));				            // 売上伝票番号  // ADD 2010/12/20
            dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                            // 売上伝票番号
            dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			            // 伝票日付(表示用)
            dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					            // 伝票日付
            dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						            // 売上日
            dtDmdSalesTable.Columns.Add(ctClaimCode, typeof(int));					                // 請求先コード
            dtDmdSalesTable.Columns.Add(ctClaimName, typeof(string));				                // 請求先名称
            //dtDmdSalesTable.Columns.Add(ctCustomerCode, typeof(int));					            // 得意先コード
            dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				            // 得意先名称
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				            // 受注ステータス
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatusNm, typeof(string));			            // 受注ステータス名
            dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					            // 伝票種類
            dtDmdSalesTable.Columns.Add(ctSlipNote, typeof(string));					            // 伝票備考
            dtDmdSalesTable.Columns.Add(ctSalesTotalTaxExc, typeof(Int64));				            // 売上伝票合計（税込み）
            dtDmdSalesTable.Columns.Add(ctAccRecDivCd, typeof(int));                                // 売掛区分(0:売掛なし,1:売掛)
            dtDmdSalesTable.Columns.Add(ctLastTotalAddUpDt, typeof(int));				            // 最終締次更新日
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDateDisp, typeof(string));                     // 最終月次締め日(表示用)
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDate, typeof(int));                            // 最終月次締め日
            dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				            // 締フラグ
            dtDmdSalesTable.Columns.Add(ctSearchClaimSales, typeof(SearchClaimSales));	            // 請求売上検索データクラス
            dtDmdSalesTable.Columns.Add(ctUpdateDepositParameter, typeof(UpdateDepositParameter));	// 新規作成入金パラメータクラス
            dtDmdSalesTable.Columns.Add(ctDmdSalesDataRow, typeof(DataRow));			            // 自身のDataRow
            dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				            // 入金引当ボタン
            // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
            if (this.KaToOption())
            {
                dtDmdSalesTable.Columns.Add(ctDepositDate, typeof(string));                             // 引当日
                dtDmdSalesTable.Columns.Add(ctDepositAgentCode, typeof(string));                        // 担当者
                dtDmdSalesTable.Columns.Add(ctDepositKindName, typeof(string));				            // 金種
            }
            // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<

            // データセットに追加
            _dsDmdSalesInfo.Tables.Add(dtDmdSalesTable.Clone());
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 入金関連データ取得処理（得意先コード指定）
		/// </summary>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ クラス</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 指定されたパラメータの請求売上情報を取得し、以下のデータセットにて返します。
		///					:   ※ 請求売上情報 : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchDmdSales(SearchSalesParameter searchSalesParameter, int consTaxLayMethod, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
				// 受注情報DataSet初期化処理
				this.ClearDmdSalesInfo();

				// 請求売上情報取得処理
				st = this.GetDmdSalesInfo(searchSalesParameter, consTaxLayMethod);
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					message = "指定された条件で、売上伝票は存在しませんでした。";
					return st;
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
			return _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].DefaultView[index].Row;
		}

        // ↓ 20070125 18322 c MA.NS用に変更
        #region SF 入金引当情報 受注・諸費用 変更処理（MA.NSでは使用しないので全てコメントアウト）
        ///// <summary>
		///// 入金引当情報 受注 変更処理
		///// </summary>
		///// <param name="difference">引当変更前後差額</param>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <param name="flgAcpOdrDepositAlwc_Alw">引当残 受注 (入金引当額) 更新フラグ</param>
		///// <param name="flgAcpOdrDepoAlwcBlnce_Sales">引当残 受注 (請求売上マスタ) 更新フラグ</param>
		///// <param name="flgAcpOdrDepositAlwc_Sales">引当済 受注 (請求売上マスタ) 更新フラグ</param>
		///// <remarks>
		///// <br>Note       : 引当額 受注 の変更を各内容に反映します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public void UpdateAcpOdrDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, bool flgAcpOdrDepositAlwc_Alw, bool flgAcpOdrDepoAlwcBlnce_Sales, bool flgAcpOdrDepositAlwc_Sales)
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
		//}
		//
		///// <summary>
		///// 入金引当情報 諸費用 変更処理
		///// </summary>
		///// <param name="difference">引当変更前後差額</param>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <param name="flgVarCostDepoAlwc_Alw">引当残 諸費用 (入金引当額) 更新フラグ</param>
		///// <param name="flgVarCostDepoAlwcBlnce_Sales">引当残 諸費用 (請求売上マスタ) 更新フラグ</param>
		///// <param name="flgVarCostDepoAlwc_Sales">引当済 諸費用 (請求売上マスタ) 更新フラグ</param>
		///// <remarks>
		///// <br>Note       : 引当額 諸費用 の変更を各内容に反映します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public void UpdateCostDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, bool flgVarCostDepoAlwc_Alw, bool flgVarCostDepoAlwcBlnce_Sales, bool flgVarCostDepoAlwc_Sales)
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
		//}
        #endregion
        // ↑ 20070125 18322 c

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金引当情報 共通 変更処理
		/// </summary>
		/// <param name="difference">引当変更前後差額</param>
		/// <param name="drDmdSales">請求売上情報DataRow</param>
		/// <param name="flgDepositAllowance_Alw">引当残 共通 (入金引当額) 更新フラグ</param>
		/// <param name="flgDepositAlwcBlnce_Sales">引当残 共通 (請求売上マスタ) 更新フラグ</param>
		/// <remarks>
		/// <br>Note       : 引当額 共通 の変更を各内容に反映します。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/06/26</br>
		/// </remarks>
		public void UpdateDepositAlwc(Int64 difference, ref DataRow drDmdSales, bool flgDepositAllowance_Alw, bool flgDepositAlwcBlnce_Sales)
		{
            if (flgDepositAllowance_Alw)   // ON
            {
                // 入金引当額
                drDmdSales[ctDepositAllowance_Alw] = 0;

                // 入金引当残
                drDmdSales[ctDepositAlwcBlnce_Sales] = difference;

                // 入金引当済
                drDmdSales[ctDepositAllowance_Sales] = 0;
            }

            if (flgDepositAlwcBlnce_Sales) // 入力中
            {
                // 入金引当額
                drDmdSales[ctDepositAllowance_Alw] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) + difference;

                // 入金引当残
                drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]) - difference;

                // 入金引当済
                drDmdSales[ctDepositAllowance_Sales] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Sales]) + difference;
            }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入金引当情報 共通 変更処理
        /// </summary>
        /// <param name="difference">引当変更前後差額</param>
        /// <param name="drDmdSales">請求売上情報DataRow</param>
        /// <param name="flgDepositAllowance_Alw">引当残 共通 (入金引当額) 更新フラグ</param>
        /// <param name="flgDepositAlwcBlnce_Sales">引当残 共通 (請求売上マスタ) 更新フラグ</param>
        /// <param name="flgDepositAllowance_Sales">引当済 共通 (請求売上マスタ) 更新フラグ</param>
        /// <remarks>
        /// <br>Note       : 引当額 共通 の変更を各内容に反映します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        public void UpdateDepositAlwc(Int64 difference, ref DataRow drDmdSales, bool flgDepositAllowance_Alw, bool flgDepositAlwcBlnce_Sales, bool flgDepositAllowance_Sales)
        {
            //// 引当額 共通 (入金引当額) を更新する
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
            if (flgDepositAllowance_Alw)   // ON
            {
                drDmdSales[ctDepositAllowance_Alw] = 0;
                drDmdSales[ctDepositAlwcBlnce_Sales] = difference;
                drDmdSales[ctDepositAllowance_Sales] = 0;
            }

            if (flgDepositAlwcBlnce_Sales) // 入力中
            {
                drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctSalesTotalTaxExc]) - difference;
                drDmdSales[ctDepositAllowance_Sales] = difference;
            }

            if (flgDepositAllowance_Sales) // OFF
            {
                // 何もしない
            }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        // ↓ 20070125 18322 c MA.NS用に変更
        #region SF 入金引当情報 受注・諸費用 変更処理（MA.NSでは使用しないので全てコメントアウト）
        ///// <summary>
		///// 入金引当情報 受注 変更処理
		///// </summary>
		///// <param name="difference">引当前後入金差額</param>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <returns>未引当入金額</returns>
		///// <remarks>
		///// <br>Note       : 引当情報 受注 の変更を各内容に反映します。引当上限は引当残が0円までです。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ZeroUpdateAcpOdrDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales)
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
		//	// 引当額 受注 (入金引当額) を更新する
		//	drDmdSales[ctAcpOdrDepositAlwc_Alw] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) + maxDepositAlw;
		//
		//	// 引当残 受注 (請求売上マスタ) を更新する
		//	drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]) - maxDepositAlw;
		//
		//	// 引当済 受注 (請求売上マスタ) を更新する
		//	drDmdSales[ctAcpOdrDepositAlwc_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Sales]) + maxDepositAlw;
		//
		//	return zanDifference;
		//}
		//
		///// <summary>
		///// 入金引当情報 諸費用 変更処理
		///// </summary>
		///// <param name="difference">引当前後入金差額</param>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <returns>未引当入金額</returns>
		///// <remarks>
		///// <br>Note       : 引当情報 諸費用 の変更を各内容に反映します。引当上限は引当残が0円までです。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ZeroUpdateCostDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales)
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
		//	// 引当額 諸費用 (入金引当額) を更新する
		//	drDmdSales[ctVarCostDepoAlwc_Alw] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) + maxDepositAlw;
		//
		//	// 引当残 諸費用 (請求売上マスタ) を更新する
		//	drDmdSales[ctVarCostDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]) - maxDepositAlw;
		//
		//	// 引当済 諸費用 (請求売上マスタ) を更新する
		//	drDmdSales[ctVarCostDepoAlwc_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Sales]) + maxDepositAlw;
		//
		//	return zanDifference;
        //}
        #endregion
        // ↑ 20070125 18322 c

        // ↓ 20070125 18322 c MA.NS用に変更
        #region SF 引当額 受注・諸費用 (入金引当額) 最大額取得処理（MA.NSでは使用しないので全てコメントアウト）
        ///// <summary>
		///// 引当額 受注 (入金引当額) 最大額取得処理
		///// </summary>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <returns>最大入金引当額</returns>
		///// <remarks>
		///// <br>Note       : 最大引当残を取得します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetMaxAcpOdrDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// 引当残 受注 (請求売上マスタ) を取得する
		//	return Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]);
		//}
        //
		///// <summary>
		///// 引当額 諸費用 (入金引当額) 最大額取得処理
		///// </summary>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <returns>最大入金引当額</returns>
		///// <remarks>
		///// <br>Note       : 最大引当残を取得します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetMaxCostDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// 引当残 諸費用 (請求売上マスタ) を取得する
		//	return Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]);
        //}
        #endregion
        // ↑ 20070125 18322 c

		/// <summary>
		/// 引当額 共通 (入金引当額) 最大額取得処理
		/// </summary>
		/// <param name="drDmdSales">請求売上情報DataRow</param>
		/// <returns>最大入金引当額</returns>
		/// <remarks>
		/// <br>Note       : 最大引当残を取得します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 GetMaxDepositAlwc(DataRow drDmdSales)
		{
			// 引当残 共通 (請求売上マスタ) を取得する
			//return Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]);
            return Convert.ToInt64(drDmdSales[ctSalesTotalTaxExc]);
		}

        // ↓ 20070125 18322 c MA.NS用に変更
        #region SF 引当額 受注・諸費用 (入金引当額) クリア額処理（MA.NSでは使用しないので全てコメントアウト）
        ///// <summary>
		///// 引当額 受注 (入金引当額) クリア額処理
		///// </summary>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <returns>入金引当クリア額</returns>
		///// <remarks>
		///// <br>Note       : クリア金額を取得します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetClearAcpOdrDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// 引当額 受注 (入金引当額) のクリア額取得
		//	return Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) * -1;
		//}
        //
		///// <summary>
		///// 引当額 諸費用 (入金引当額) クリア額処理
		///// </summary>
		///// <param name="drDmdSales">請求売上情報DataRow</param>
		///// <returns>入金引当クリア額</returns>
		///// <remarks>
		///// <br>Note       : クリア金額を取得します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetClearCostDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// 引当額 諸費用 (入金引当額) のクリア額取得
		//	return Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) * -1;
        //}
        #endregion
        // ↑ 20070125 18322 c

		/// <summary>
		/// 引当額 共通 (入金引当額) クリア額処理
		/// </summary>
		/// <param name="drDmdSales">請求売上情報DataRow</param>
		/// <returns>入金引当クリア額</returns>
		/// <remarks>
		/// <br>Note       : クリア金額を取得します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 GetClearDepositAlwc(DataRow drDmdSales)
		{
			// 引当額 共通 (入金引当額) のクリア額取得
			return Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) * -1;
		}

		/// <summary>
		/// 更新対象データの取得/不正チェック処理
		/// </summary>
		/// <param name="updateDepositParameter">入金更新用クラス</param>
		/// <param name="drDmdSalesList">請求売上情報DataRow</param>
		/// <param name="message">不正メッセージ</param>
		/// <returns>ステータス 0:正常, 1:変更データ無し, 2:入金日不正, 3:受注(締済み)に対し預り金, 4:受注(赤)に対し預り金, 5:受注(赤[相殺済み黒])に対し預り金</returns>
		/// <remarks>
		/// <br>Note       : 入金更新対象DatRowの不正チェック/取得を行います。
		///                : 正常時は更新対象データが戻ります。
		///                : エラー時はエラー対象データが戻ります。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheackUpdateDate(UpdateDepositParameter updateDepositParameter, out DataRow[] drDmdSalesList, out string message)
		{
            // --- ADD m.suzuki 2010/08/18 ---------->>>>>
            //--------------------------------------------------
            // ※日付をチェックする時は、必ず最新情報を使用する。
            //--------------------------------------------------
            // 月次更新履歴取得
            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec( updateDepositParameter.AddUpSecCode );
            // 締次処理日取得
            this._lastAddUpDay = GetTotalDayDmdC( updateDepositParameter.AddUpSecCode, updateDepositParameter.ClaimCode );
            // --- ADD m.suzuki 2010/08/18 ----------<<<<<

			message = "";
			drDmdSalesList = null;
			ArrayList alUpdateData = new ArrayList();
			ArrayList alMistakeData2 = new ArrayList();
			ArrayList alMistakeData3 = new ArrayList();
			ArrayList alMistakeData4 = new ArrayList();
			ArrayList alMistakeData5 = new ArrayList();
            ArrayList alMistakeData6 = new ArrayList();

			// 請求売上情報を全件ループ
			foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// 引当額 共通 (入金引当額) がセットされていれば取得する
                // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                //if ((dr[ctDepositAllowance_Alw] != DBNull.Value) && (Convert.ToInt64(dr[ctDepositAllowance_Alw]) != 0))
                if (Convert.ToString(dr[ctAlwCheck]) == "True")
                // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
                {
					alUpdateData.Add(dr);

					// 入金日付不正の時(入金日<=得意先前回締日)
                    if (updateDepositParameter.DepositDate <= TDateTime.DateTimeToLongDate(this._lastAddUpDay))
					{
						alMistakeData2.Add(dr);
					}
                    else
                    {
                        // 入金日付不正の時(入金日<=前回月次締め日)
                        if (updateDepositParameter.DepositDate <= TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay))
                        {
                            alMistakeData6.Add(dr);
                        }
                    }

                    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
					// 受注(締済み)に対して預り金入金の時
					if ((updateDepositParameter.DepositCd == 1) && (dr[ctSalesClosedFlg].ToString() != ""))
					{
						alMistakeData3.Add(dr);
					}

					// 受注(赤伝)に対して預り金入金の時
					if ((updateDepositParameter.DepositCd == 1) && (Convert.ToInt32(dr[ctDebitNoteDiv]) == 1))
					{
						alMistakeData4.Add(dr);
					}
				
					// 受注(赤伝[相殺済み黒])に対して預り金入金の時
					if ((updateDepositParameter.DepositCd == 1) && (Convert.ToInt32(dr[ctDebitNoteDiv]) == 2))
					{
						alMistakeData5.Add(dr);
					}
                       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                }
			}

			// 対象データ無し時
			if (alUpdateData.Count == 0)
			{
				message = "保存対象データがありません。";
				return 1;
			}

            // 入金日不正のとき（入金日<=最終月次締め日）
            if (alMistakeData6.Count != 0)
            {
                message = "入金日が前回月次更新日以前になっている為、登録できません。" + "\r\n\r\n" + "  前回月次更新日：" + this._lastMonthlyAddUpDay.ToString("yyyy年MM月dd日");
				// 不正データをセットする
				drDmdSalesList = (DataRow[])alMistakeData6.ToArray(typeof(DataRow));
				return 2;
            }

			// 入金日不正の時(入金日<=得意先前回締日)
			if (alMistakeData2.Count != 0)
			{
                message = "入金日が前回請求締日以前になっている為、登録できません。" + "\r\n\r\n" + "  前回請求締日：" + this._lastAddUpDay.ToString("yyyy年MM月dd日");
				// 不正データをセットする
				drDmdSalesList = (DataRow[])alMistakeData2.ToArray(typeof(DataRow));
				return 2;
			}

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // 受注(締済み)に対して預り金入金の時
            if (alMistakeData3.Count != 0)
            {
                message = "売上伝票(締済み)に対して預り金の入金を行っているデータがあります。";
                // 不正データをセットする
                drDmdSalesList = (DataRow[])alMistakeData3.ToArray(typeof(DataRow));
                return 3;
            }

            // 受注(赤伝)に対して預り金入金の時
            if (alMistakeData4.Count != 0)
            {
                message = "売上伝票(赤)に対して預り金の入金を行っているデータがあります。";
                // 不正データをセットする
                drDmdSalesList = (DataRow[])alMistakeData4.ToArray(typeof(DataRow));
                return 4;
            }

            // 受注(赤[相殺済み黒])に対して預り金入金の時
            if (alMistakeData5.Count != 0)
            {
                message = "売上伝票(赤[相殺済み黒])に対して預り金の入金を行っているデータがあります。";
                // 不正データをセットする
                drDmdSalesList = (DataRow[])alMistakeData5.ToArray(typeof(DataRow));
                return 5;
            }
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // 請求売上情報をセットする
			drDmdSalesList = (DataRow[])alUpdateData.ToArray(typeof(DataRow));
			
			return 0;
		}

		/// <summary>
		/// 入金伝票更新前確認メッセージ処理
		/// </summary>
		/// <param name="updateDepositParameter">入金更新用クラス</param>
		/// <param name="drDmdSalesQuestionList">請求売上確認情報DataRow</param>
		/// <param name="messages">不正メッセージ</param>
		/// <returns>変更ステータス 0:正常. -1:引当不正</returns>
		/// <remarks>
		/// <br>Note       : 保存データをチェックし、保存前の確認メッセージを返します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheckUpdateDepositQuestion(UpdateDepositParameter updateDepositParameter, out ArrayList drDmdSalesQuestionList, out StringCollection messages)
		{
			int st = 0;
			messages = new StringCollection();
			drDmdSalesQuestionList = new ArrayList();

			ArrayList alQuestionData1 = new ArrayList();
			ArrayList alQuestionData2 = new ArrayList();

			// 請求売上情報を全件ループ
			foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// 引当額 共通 (入金引当額) がある時
				if (Convert.ToInt64(dr[ctDepositAllowance_Alw]) != 0)
				{
                    // ↓ 20070202 18322 c MA.NS用に変更
					//// 通常入金で受注ステータスが納品書以外の時
					//if ((Convert.ToInt64(updateDepositParameter.DepositCd) == 0) && (Convert.ToInt32(dr[ctAcptAnOdrStatus]) != 30))
					//{
					//	alQuestionData1.Add(dr);
					//}

                    // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                    //if (Convert.ToInt32(updateDepositParameter.DepositCd) == 0)
                    //{
                    //    // 通常入金の時
                    //    switch (Convert.ToInt32(dr[ctAcptAnOdrStatus]))
                    //    {
                    //        case 30 :    // 売上
                    //        //case 40 :    // 売切     // 2007.10.05 del
                    //        //case 55 :    // 委託計上 // 2007.10.05 del
                    //            break;
                    //        default :
                    //            // 上記以外の伝票
                    //            alQuestionData1.Add(dr);
                    //            break;
                    //    }
                    //}
                    // 通常入金の時
                    switch (Convert.ToInt32(dr[ctAcptAnOdrStatus]))
                    {
                        case 30:    // 売上
                            break;
                        default:
                            // 上記以外の伝票
                            alQuestionData1.Add(dr);
                            break;
                    }
                    // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
                    // ↑ 20070202 18322 c

					// 引当残 共通 (請求売上マスタ) < 0 ※引当残 共通 (請求売上マスタ)がマイナスの時
					if (Convert.ToInt32(dr[ctDepositAlwcBlnce_Sales]) < 0)
					{
						// 引当額 共通 (入金引当額) > 0 ※引当額 共通 (入金引当額)がプラスの時
						if (Convert.ToInt32(dr[ctDepositAllowance_Alw]) > 0)
						{
							alQuestionData2.Add(dr);
						}
					}
				}
			}

			// 見積書/指示書に対しての通常入金
			if (alQuestionData1.Count != 0)
			{
                // ↓ 20070202 18322 c MA.NS用に変更
				//messages.Add("預り金区分が通常入金として、見積書/指示書に入金されているデータがあります。" + "\r\n\r\n" + 
				//	"このまま保存してよろしいですか？");

				messages.Add("預り金区分が通常入金として、売上/売切/委託計上以外の伝票に入金されているデータがあります。" + "\r\n\r\n" + 
					"このまま保存してよろしいですか？");
                // ↑ 20070202 18322 c

				// 不正データをセットする
				DataRow[] dr = (DataRow[])alQuestionData1.ToArray(typeof(DataRow));
				drDmdSalesQuestionList.Add(dr);
				st = 1;
			}

			// 過剰引当に対しての通常入金
			if (alQuestionData2.Count != 0)
			{
				messages.Add("売上額以上の入金がされているデータがあります。" + "\r\n\r\n" + 
					"このまま保存してよろしいですか？");
				// 不正データをセットする
				DataRow[] dr = (DataRow[])alQuestionData2.ToArray(typeof(DataRow));
				drDmdSalesQuestionList.Add(dr);
				st = 1;
			}

			return st;
        }

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金データ更新処理
		/// </summary>
		/// <param name="updateDepositParameter">入金更新用クラス</param>
		/// <param name="drDmdSalesList">更新対象請求売上DataRow</param>
		/// <param name="message">エラー発生時メッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金情報の更新処理を行います。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SaveDepositData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
				// 入金マスタ更新内容セット処理
				ArrayList alCreateDepsitMainWork;
				this.SetUpdateDepositData(updateDepositParameter, drDmdSalesList, out alCreateDepsitMainWork);

				CreateDepsitMainWork[] createDepsitMainWorkList = (CreateDepsitMainWork[])alCreateDepsitMainWork.ToArray(typeof(CreateDepsitMainWork));

				// 更新処理！
                // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
				int[] depositSlipNoList;
                //this.WriteDepositData(updateDepositParameter.EnterpriseCode, createDepsitMainWorkList, out depositSlipNoList);

                st = _depsitMainAcs.WriteDB(updateDepositParameter.EnterpriseCode, createDepsitMainWorkList, out depositSlipNoList, out message);

                // エラーの時は例外を発生させる
                if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    throw new DepositException(message, st);
                }
                // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

				// 新規作成した入金番号を請求売上DataRowに埋め込む
				for (int ix = 0; ix < createDepsitMainWorkList.Length; ix++)
				{
					// 請求売上情報を全件ループ
					foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
					{
                        // 同一売上番号の時、更新結果リストの同一Indexより入金番号を取得する
                        if ((string)dr[ctSalesSlipNum] == createDepsitMainWorkList[ix].SalesSlipNum)
						{
							if (ix <= depositSlipNoList.Length)
							{
								UpdateDepositParameter para = updateDepositParameter.Clone();
								para.DepositSlipNo = (Int32)depositSlipNoList[ix];
								dr[ctUpdateDepositParameter] = para;
							}
							break;
						}
					}
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
        #endregion DEL 2008/06/26 Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入金データ更新処理
        /// </summary>
        /// <param name="updateDepositParameter">入金更新用クラス</param>
        /// <param name="drDmdSalesList">更新対象請求売上DataRow</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金情報の更新処理を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int SaveDepositData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // 入金マスタ更新内容セット処理
                SearchDepsitMain depsitMain;
                Hashtable htDepositAlw;
                SetUpdateDepositData(updateDepositParameter, drDmdSalesList, out depsitMain, out htDepositAlw);

                // クラスメンバーコピー処理
                DepsitDataWork depsitDataWork = CopyToDepsitDataWorkFromDepsitMain(depsitMain);             // （入金マスタ⇒入金マスタワーク）
                DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);     // （入金引当マスタ⇒入金引当マスタワーク）

                // 更新処理
                status = this._depsitMainAcs.WriteDB(ref depsitDataWork, ref depositAlwWorkList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // 新規作成した入金番号を請求売上DataRowに埋め込む
                for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                {
                    // 請求売上情報を全件ループ
                    foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                    {
                        // 同一売上番号の時、更新結果リストの同一Indexより入金番号を取得する
                        if ((string)dr[ctSalesSlipNum] == depositAlwWorkList[ix].SalesSlipNum)
                        {
                            if (ix <= depositAlwWorkList.Length)
                            {
                                UpdateDepositParameter para = updateDepositParameter.Clone();
                                para.DepositSlipNo = (Int32)depositAlwWorkList[ix].DepositSlipNo;
                                dr[ctUpdateDepositParameter] = para;
                            }
                            break;
                        }
                    }
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

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>

        /// <summary>
        /// 入金データ更新処理(手形データも連れる)
        /// </summary>
        /// <param name="updateDepositParameter">入金更新用クラス</param>
        /// <param name="drDmdSalesList">更新対象請求売上DataRow</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <param name="rcvDraftDataUpd">手形データ（更新用）</param>
        /// <param name="rcvDraftDataDel">手形データ（削除用）</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金、手形情報の更新処理を行います。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010/05/06</br>
        /// </remarks>
        public int SaveDepositDataWithDraftData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out string message, RcvDraftData rcvDraftDataUpd, RcvDraftData rcvDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // 入金マスタ更新内容セット処理
                SearchDepsitMain depsitMain;
                Hashtable htDepositAlw;
                SetUpdateDepositData(updateDepositParameter, drDmdSalesList, out depsitMain, out htDepositAlw);

                // クラスメンバーコピー処理
                DepsitDataWork depsitDataWork = CopyToDepsitDataWorkFromDepsitMain(depsitMain);             // （入金マスタ⇒入金マスタワーク）
                DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);     // （入金引当マスタ⇒入金引当マスタワーク）

                RcvDraftDataWork rcvDraftDataWorkUpd;
                if (rcvDraftDataUpd != null)
                    rcvDraftDataWorkUpd = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftDataUpd);
                else
                    rcvDraftDataWorkUpd = null;

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

                // 新規作成した入金番号を請求売上DataRowに埋め込む
                for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                {
                    // 請求売上情報を全件ループ
                    foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                    {
                        // 同一売上番号の時、更新結果リストの同一Indexより入金番号を取得する
                        if ((string)dr[ctSalesSlipNum] == depositAlwWorkList[ix].SalesSlipNum)
                        {
                            if (ix <= depositAlwWorkList.Length)
                            {
                                UpdateDepositParameter para = updateDepositParameter.Clone();
                                para.DepositSlipNo = (Int32)depositAlwWorkList[ix].DepositSlipNo;
                                dr[ctUpdateDepositParameter] = para;
                            }
                            break;
                        }
                    }
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
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>

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

		/// <summary>
		/// 得意先名称取得処理
		/// </summary>
		/// <param name="logicalMode">論理削除区分</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="name">得意先名称</param>
        /// <param name="claimCode">請求先コード</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 得意先名称の取得処理を行います。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
        public int ReadCustomer(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, out string name, out int claimCode)
		{
			name = "";
            claimCode = 0;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// パラメータ生成
			CustomerWork customerWork = new CustomerWork();
			customerWork.EnterpriseCode		= enterpriseCode;
			customerWork.CustomerCode		= customerCode;

			ArrayList paraList = new ArrayList();
			paraList.Add(customerWork);
			object obj = (object)paraList;
			
			// 得意先読込処理
			int st = this._iCustomerInfoDB.Read(logicalMode, ref obj);
			if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				ArrayList list = obj as ArrayList;
				if (list != null)
				{
					CustomerWork ret = list[0] as CustomerWork;
					if (ret != null)
					{
						name = ret.Name + " " + ret.Name2;
                        claimCode = ret.ClaimCode;
					}
				}
			}
            
            return st;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            int status;
            CustomerInfo customerInfo;

            try
            {
                status = this._customerInfoAcs.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    name = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
                    claimCode = customerInfo.ClaimCode;
                }
            }
            catch
            {
                status = -1;
            }

            return status;
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
		}

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 領収書データ作成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">発行拠点コード</param>
        /// <param name="selectedDmdSalesRow">請求売上DataRow</param>
        /// <returns>領収書データ</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金情報より領収書データを作成します。</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        public Receipt SetReceiptFromDepositDataRow(string enterpriseCode, string sectionCode, DataRow selectedDmdSalesRow)
        {
            Receipt receipt = new Receipt();

            // ↓ 20070125 18322 c MA.NS用に変更
            //SearchDmdSalesCustomer searchDmdSalesCustomer = selectedDmdSalesRow[ctSearchDmdSalesCustomer] as SearchDmdSalesCustomer;

            SearchClaimSales searchDmdSalesCustomer = selectedDmdSalesRow[ctSearchClaimSales] as SearchClaimSales;
            // ↑ 20070125 18322 c
            UpdateDepositParameter updateDepositParameter = selectedDmdSalesRow[ctUpdateDepositParameter] as UpdateDepositParameter;

            receipt.EnterpriseCode = enterpriseCode;												// 企業コード
            receipt.CustomerCode = searchDmdSalesCustomer.CustomerCode;							// 得意先コード
            // ↓ 20070125 18322 c MA.NS用に変更
            //receipt.ReceiptAddress1		= searchDmdSalesCustomer.Name;									// 領収書宛名１
            //receipt.ReceiptAddress2		= searchDmdSalesCustomer.Name2;									// 領収書宛名２

            receipt.ReceiptAddress1 = searchDmdSalesCustomer.CustomerName;							// 領収書宛名１
            receipt.ReceiptAddress2 = searchDmdSalesCustomer.CustomerName2;							// 領収書宛名２
            // ↑ 20070125 18322 c
            receipt.RectHonorificTitle = searchDmdSalesCustomer.HonorificTitle;						// 領収書宛名敬称
            receipt.ReceiptMoney = Convert.ToInt64(selectedDmdSalesRow[ctDepositAllowance_Alw]);	// 領収書金額
            receipt.ReceiptIssueNote = "";															// 領収書備考内容（発行時）
            receipt.ReceiptIssueOrgCd = 1;															// 領収書発行区分 0:見積・納品,1:入金,2:領収書
            receipt.DepositSlipNo = updateDepositParameter.DepositSlipNo;							// 入金伝票番号
            receipt.AcceptAnOrderNo = 0;															// 受注番号
            // ↓ 20070118 18322 d MA.NS用に変更
            //receipt.SlipKind			= 0;															// 伝票種別 10:見積,20:指示,21:承り書,30:納品,40:加修
            //receipt.SlipNo				= "";															// 伝票番号
            // ↑ 20070118 18322 d
            receipt.DepositKindCode = updateDepositParameter.DepositKindCode;						// 入金金種コード
            receipt.DepositKindName =

                  (string)depositRelDataAcs.SlMoneyKindCode[updateDepositParameter.DepositKindCode];		// 入金金種名称
            receipt.Deposit = Convert.ToInt64(selectedDmdSalesRow[ctDepositAllowance_Alw]);	// 入金金額
            receipt.FeeDeposit = 0;															// 手数料入金額
            receipt.DiscountDeposit = 0;															// 値引入金額
            // ↓ 20070118 18322 d
            //receipt.ReceiptIssueSecCd	= sectionCode;													// 領収書発行拠点コード
            // ↑ 20070118 18322 d
            receipt.ReceiptPrintDate = TDateTime.GetSFDateNow();										// 領収書発行日付

            return receipt;
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 領収書データ作成処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">発行拠点コード</param>
		/// <param name="selectedDmdSalesRow">請求売上DataRow</param>
		/// <returns>領収書データ</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金情報より領収書データを作成します。</br>
		/// <br>Programmer  : 30414 忍 幸史</br>
		/// <br>Date        : 2008/06/26</br>
		/// </remarks>
		public Receipt SetReceiptFromDepositDataRow(string enterpriseCode, string sectionCode, DataRow selectedDmdSalesRow)
		{
			Receipt receipt = new Receipt();

			SearchClaimSales searchDmdSalesCustomer = selectedDmdSalesRow[ctSearchClaimSales] as SearchClaimSales;
			UpdateDepositParameter updateDepositParameter = selectedDmdSalesRow[ctUpdateDepositParameter] as UpdateDepositParameter;

			receipt.EnterpriseCode		= enterpriseCode;												// 企業コード
            receipt.CustomerCode		= searchDmdSalesCustomer.CustomerCode;							// 得意先コード
			receipt.ReceiptAddress1		= searchDmdSalesCustomer.CustomerName;							// 領収書宛名１
			receipt.ReceiptAddress2		= searchDmdSalesCustomer.CustomerName2;							// 領収書宛名２
			receipt.RectHonorificTitle	= searchDmdSalesCustomer.HonorificTitle;						// 領収書宛名敬称
			receipt.ReceiptMoney		= Convert.ToInt64(selectedDmdSalesRow[ctDepositAllowance_Alw]);	// 領収書金額
			receipt.ReceiptIssueNote	= "";															// 領収書備考内容（発行時）
			receipt.ReceiptIssueOrgCd	= 1;															// 領収書発行区分 0:見積・納品,1:入金,2:領収書
			receipt.DepositSlipNo		= updateDepositParameter.DepositSlipNo;							// 入金伝票番号
			receipt.AcceptAnOrderNo		= 0;															// 受注番号
            receipt.DepositKindCode = updateDepositParameter.MoneyKindCode;						        // 入金金種コード
			receipt.DepositKindName		=
                  (string)depositRelDataAcs.DicMoneyKindCode[updateDepositParameter.MoneyKindCode];		// 入金金種名称
            receipt.Deposit = Convert.ToInt64(selectedDmdSalesRow[ctDepositAllowance_Alw]);	            // 入金金額
			receipt.FeeDeposit			= 0;															// 手数料入金額
			receipt.DiscountDeposit		= 0;															// 値引入金額
			receipt.ReceiptPrintDate	= TDateTime.GetSFDateNow();										// 領収書発行日付

			return receipt;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
        /// <summary>
        /// ㈱カト―個別オプション判定
        /// </summary>
        public bool KaToOption()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_KatoCustom);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<
        # endregion

        # region Private Methods
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

        // ↓ 20070125 18322 c MA.NS用に変更
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
		//	ArrayList arrDmdSalesCustomer;
		//	SearchParaDmdSalesRead searchParaDmdSalesRead = new SearchParaDmdSalesRead();
		//	searchParaDmdSalesRead.EnterpriseCode	= searchSalesParameter.EnterpriseCode;			// 企業コード
		//	searchParaDmdSalesRead.AddUpSecCode		= searchSalesParameter.AddUpSecCod;				// 計上拠点
		//	searchParaDmdSalesRead.ClaimCode		= searchSalesParameter.CustomerCode;			// 請求先コード
		//	searchParaDmdSalesRead.AcceptAnOrderNo	= searchSalesParameter.AcceptAnOrderNo;			// 受注番号
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
		//	int st = _searchDmdSalesAcs.SearchCustDB(searchParaDmdSalesRead, out arrDmdSalesCustomer, out errMsg);
		//	
		//	switch (st)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
		//
		//			// 取得請求売上データをコレクションに保存
		//			SearchDmdSalesCustomer[] listDmdSalesCustomer = (SearchDmdSalesCustomer[])arrDmdSalesCustomer.ToArray(typeof(SearchDmdSalesCustomer));
		//
		//			// 請求売上情報データテーブル データセット処理
		//			foreach(SearchDmdSalesCustomer dmdSalesCustomer in listDmdSalesCustomer)
		//			{
		//				// 黒伝のみ対象とする ※あとでこのIFを入れたので画面制御の赤や元黒のロジックは入れたままにしておく
		//				if (!((dmdSalesCustomer.DebitNoteDiv == 0) && (dmdSalesCustomer.DebitNLnkAcptAnOdr == 0)))
		//				{
		//					continue;
		//				}
		//
		//				// 請求売上情報DataSetの行を新規作成する
		//				DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();
		//
		//				// 請求売上情報DataRowセット処理
		//				SetDmdSalesCustomer(drNew, dmdSalesCustomer);
		//
		//				// 請求売上情報DataSetの行を追加する
		//				this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
		//			}
		//
		//			// 赤伝のみの時などは件数が０件になる
		//			if (this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Count == 0)
		//			{
		//				st = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//			}
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
		/// 請求売上情報取得処理
		/// </summary>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報をデータセットに取得します。
		///					: エラー時はDepositException例外が発生します。</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.25</br>
		/// </remarks>
		private int GetDmdSalesInfo(SearchSalesParameter searchSalesParameter, int consTaxLayMethod)
		{
			string errMsg;
			
			ArrayList arrDmdSalesCustomer;

            // 売上月次更新履歴取得
            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchSalesParameter.DemandAddUpSecCd);

            // 売上締次処理日取得
            this._lastAddUpDay = GetTotalDayDmdC(searchSalesParameter.DemandAddUpSecCd, searchSalesParameter.ClaimCode);

            SearchParaClaimSalesRead searchParaDmdSalesRead = new SearchParaClaimSalesRead();

			// 企業コード
			searchParaDmdSalesRead.EnterpriseCode	= searchSalesParameter.EnterpriseCode;
			// 計上拠点
			searchParaDmdSalesRead.DemandAddUpSecCd = searchSalesParameter.DemandAddUpSecCd;
            // 受注ステータス
            searchParaDmdSalesRead.AcptAnOdrStatus = searchSalesParameter.AcptAnOdrStatus;
            // 売上伝票番号
            searchParaDmdSalesRead.SalesSlipNum = searchSalesParameter.SalesSlipNum;
            // 請求先コード
			searchParaDmdSalesRead.ClaimCode		= searchSalesParameter.ClaimCode;
            // 得意先コード
            searchParaDmdSalesRead.CustomerCode     = searchSalesParameter.CustomerCode;
            // 引当済請求売上伝票呼出区分
            searchParaDmdSalesRead.AlwcSalesSlipCall = searchSalesParameter.AlwcSalesSlipCall;
            //=================
            // 伝票日付
            //=================
			if (searchSalesParameter.SearchSlipDateStart == 0)
			{
				// 伝票日付 開始
				searchParaDmdSalesRead.SearchSlipDateStart	= TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
			    // 伝票日付 開始
				searchParaDmdSalesRead.SearchSlipDateStart	= searchSalesParameter.SearchSlipDateStart;
			}
			if (searchSalesParameter.SearchSlipDateEnd == 0)
			{
				// 伝票日付 終了
				searchParaDmdSalesRead.SearchSlipDateEnd	= TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
			    // 伝票日付 終了
				searchParaDmdSalesRead.SearchSlipDateEnd	= searchSalesParameter.SearchSlipDateEnd;
			}
            //=================
            // 計上日
            //=================
			if (searchSalesParameter.AddUpADateStart == 0)
			{
				// 計上日 開始
				searchParaDmdSalesRead.AddUpADateStart	= TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
				// 計上日 開始
				searchParaDmdSalesRead.AddUpADateStart	= searchSalesParameter.AddUpADateStart;
			}
			if (searchSalesParameter.AddUpADateEnd == 0)
			{
				// 計上日 終了
				searchParaDmdSalesRead.AddUpADateEnd	= TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
				// 計上日 終了
				searchParaDmdSalesRead.AddUpADateEnd	= searchSalesParameter.AddUpADateEnd;
			}

			// 販売従業員コード
			searchParaDmdSalesRead.SalesEmployeeCd	= searchSalesParameter.SalesEmployeeCd;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // サービス伝票区分
			searchParaDmdSalesRead.ServiceSlipCd	= searchSalesParameter.ServiceSlipCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // 売掛区分
			searchParaDmdSalesRead.AccRecDivCd      = searchSalesParameter.AccRecDivCd;

            // 自動入金区分
			searchParaDmdSalesRead.AutoDepositCd	= searchSalesParameter.AutoDepositCd;

			// --- 請求売上情報取得処理 --- //
			int st = _searchDmdSalesAcs.SearchCustDB(searchParaDmdSalesRead, out arrDmdSalesCustomer, out errMsg);

			switch (st)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL :

					// 取得請求売上データをコレクションに保存
					SearchClaimSales[] listDmdSalesCustomer = (SearchClaimSales[])arrDmdSalesCustomer.ToArray(typeof(SearchClaimSales));

                    // 請求売上情報データテーブル データセット処理
					foreach(SearchClaimSales dmdSalesCustomer in listDmdSalesCustomer)
					{
						// 黒伝のみ対象とする
                        // ※あとでこのIFを入れたので画面制御の赤や元黒のロジックは入れたままにしておく
                        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                        //if (!((dmdSalesCustomer.DebitNoteDiv == 0) &&
                        //      (dmdSalesCustomer.DebitNLnkAcptAnOdr == 0)))
                        //{
                        //    continue;
                        //}
                        //if (!(dmdSalesCustomer.DebitNoteDiv == 0))
                        //{
                        //    continue;
                        //}
                        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

                        // 請求売上情報DataSetの行を新規作成する
						DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();

						// 請求売上情報DataRowセット処理
						SetDmdSalesCustomer(drNew, dmdSalesCustomer, consTaxLayMethod);

						// 請求売上情報DataSetの行を追加する
						this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
					}

                    // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
                    // オプション判定
                    if (KaToOption())
                    {
                        //Dictionary<string, ControlKaToDepsitAlwWork> dic = new Dictionary<string, ControlKaToDepsitAlwWork>(); // DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する
                        Dictionary<string, DepositAlwWork> dic = new Dictionary<string, DepositAlwWork>();// ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する
                        int salesSlipNumSt = 0;
                        int salesSlipNumEd = 0;
                        // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>>
                        if (this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Count > 0)
                        {
                            // 売上伝票開始と終了初期化
                            salesSlipNumSt = Convert.ToInt32(this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows[0][ctSalesSlipNum]);
                            salesSlipNumEd = Convert.ToInt32(this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows[0][ctSalesSlipNum]);
                        }
                        // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<

                        // 売上伝票番号範囲
                        foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                        {
                            int salesSlipNum = Convert.ToInt32(dr[ctSalesSlipNum]);
                            if (salesSlipNum <= salesSlipNumSt || salesSlipNumSt == 0)
                            {
                                salesSlipNumSt = salesSlipNum;
                            }
                            if (salesSlipNum >= salesSlipNumEd)
                            {
                                salesSlipNumEd = salesSlipNum;
                            }
                        }
                        // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>> 
                        DepositAlwWork controlKaToDepsitAlwCndtnWork = new DepositAlwWork();
                        controlKaToDepsitAlwCndtnWork.CustomerCode = searchSalesParameter.ClaimCode;
                        controlKaToDepsitAlwCndtnWork.EnterpriseCode = searchSalesParameter.EnterpriseCode;
                        controlKaToDepsitAlwCndtnWork.SalesSlipNum = salesSlipNumSt.ToString().PadLeft(9, '0') + ";" + salesSlipNumEd.ToString().PadLeft(9, '0');
                        // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<< 

                        // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>> 
                        //ControlKaToDepsitAlwCndtnWork controlKaToDepsitAlwCndtnWork = new ControlKaToDepsitAlwCndtnWork();
                        //controlKaToDepsitAlwCndtnWork.CustomerCode = searchSalesParameter.ClaimCode;
                        //controlKaToDepsitAlwCndtnWork.EnterpriseCode = searchSalesParameter.EnterpriseCode;
                        //controlKaToDepsitAlwCndtnWork.AcptAnOdrStatus = 30;
                        //controlKaToDepsitAlwCndtnWork.SalesSlipNumSt = salesSlipNumSt.ToString().PadLeft(9, '0');
                        //controlKaToDepsitAlwCndtnWork.SalesSlipNumEd = salesSlipNumEd.ToString().PadLeft(9, '0');
                        // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<
                        this._iControlDepsitAlwDB = (IControlDepsitAlwDB)MediationControlDepsitAlwDB.GetControlDepsitAlwDB();
                        object controlKaToDepsitAlwResultWork = null;

                        // 売上引当入金データの取得
                        st = this._iControlDepsitAlwDB.Search(out controlKaToDepsitAlwResultWork, (object)controlKaToDepsitAlwCndtnWork);

                        // 正常の場合
                        if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                            || st == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                            || st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            //foreach (ControlKaToDepsitAlwWork work in (ArrayList)controlKaToDepsitAlwResultWork) // DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する
                            foreach (DepositAlwWork work in (ArrayList)controlKaToDepsitAlwResultWork) // ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する
                            {
                                string newSalesSlipNum = work.SalesSlipNum.ToString().PadLeft(9, '0');
                                if (!dic.ContainsKey(newSalesSlipNum))
                                {
                                    dic.Add(newSalesSlipNum, work);
                                }
                            }

                            // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>>
                            // グリッドに設定
                            foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                            {
                                string salesSlipNum = dr[ctSalesSlipNum].ToString();
                                if (dic.ContainsKey(salesSlipNum))
                                {
                                    // 引当日
                                    dr[ctDepositDate] = dic[salesSlipNum].ReconcileDate.ToString("d");

                                    // 得意先名->金種
                                    dr[ctDepositKindName] = dic[salesSlipNum].CustomerName;
                                }
                            }
                            // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<

                            // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>>
                            // グリッドに設定
                            //foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                            //{
                            //    string salesSlipNum = dr[ctSalesSlipNum].ToString();
                            //    if (dic.ContainsKey(salesSlipNum))
                            //    {
                            //        string date = dic[salesSlipNum].ReconcileDate.ToString();
                            //        // 引当日
                            //        dr[ctDepositDate] = date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6, 2);

                            //        // 金種
                            //        dr[ctDepositKindName] = dic[salesSlipNum].MoneyKindName;
                            //    }
                            //}
                            // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<
                        }
                    }
                    // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<

					// 赤伝のみの時などは件数が０件になる
					if (this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Count == 0)
					{
						st = (int)ConstantManagement.DB_Status.ctDB_EOF;
					}

					break;

				case (int)ConstantManagement.DB_Status.ctDB_EOF :

					break;

				default :

					throw new DepositException(errMsg, st);
			}

			return st;
		}
        // ↑ 20070125 18322 c

        // ↓ 20070125 18322 c MA.NS用に変更
        #region SF 請求売上情報DetaRowセット処理（全てコメントアウト）
		///// <summary>
		///// 請求売上情報DetaRowセット処理
		///// </summary>
		///// <param name="drNew">請求売上情報DataRow</param>
		///// <param name="dmdSalesCustomer">請求売上クラス</param>
		///// <remarks>
		///// <br>Note　　　  : 請求売上情報をDataRowにセットします。</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void SetDmdSalesCustomer(System.Data.DataRow drNew, SearchDmdSalesCustomer dmdSalesCustomer)
		//{
		//	// 引
		//	drNew[ctAlwCheck] = false;
		//
		//	// 赤黒区分/名称
		//	switch (dmdSalesCustomer.DebitNoteDiv)
		//	{
		//		case 0:
		//			if (dmdSalesCustomer.DebitNLnkAcptAnOdr == 0)
		//			{
		//				drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
		//				drNew[ctDebitNoteNm] = "黒";
		//			}
		//			else
		//			{
		//				drNew[ctDebitNoteDiv] = 2;					// 相殺済み黒は2にすりかえる
		//				drNew[ctDebitNoteNm] = "相殺済み黒";
		//			}
		//			break;
		//		case 1:
		//			drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
		//			drNew[ctDebitNoteNm] = "赤";
		//			break;
		//	}
		//
		//	// 受注番号
		//	drNew[ctAcceptAnOrderNo] = dmdSalesCustomer.AcceptAnOrderNo;
		//		
		//	// 伝票番号
		//	drNew[ctSlipNo] = dmdSalesCustomer.SlipNo;
		//		
		//	if (System.DateTime.MinValue != dmdSalesCustomer.SearchSlipDate)
		//	{
		//		// 伝票日付(表示用)
		//		drNew[ctSearchSlipDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", dmdSalesCustomer.SearchSlipDate);
		//		
		//		// 伝票日付
		//		drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.SearchSlipDate);
		//	}
		//
		//	if (System.DateTime.MinValue != dmdSalesCustomer.AddUpADate)
		//	{
		//		// 売上日
		//		drNew[ctAddUpADate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.AddUpADate);
		//	}
		//
		//	// 得意先コード
		//	drNew[ctCustomerCode] = dmdSalesCustomer.ClaimCode;
		//		
		//	// 得意先名称
		//	drNew[ctCustomerName] = dmdSalesCustomer.Name + " " + dmdSalesCustomer.Name2;
		//		
		//	// 受注種類
		//	string str = "";
		//	if (depositRelDataAcs.IntroducedSystemCount == 1)
		//	{
		//		switch (dmdSalesCustomer.AcptAnOdrStatus)
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
		//		switch (dmdSalesCustomer.DataInputSystem)
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
		//		switch (dmdSalesCustomer.AcptAnOdrStatus)
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
		//	drNew[ctDataInputSystem] = dmdSalesCustomer.DataInputSystem;
		//	drNew[ctAcptAnOdrStatus] = dmdSalesCustomer.AcptAnOdrStatus;
		//	drNew[ctSalesKind] = str;
		//
		//	// 売上名称
		//	drNew[ctSalesName] = dmdSalesCustomer.SalesName;
		//
		//	// 登録番号
		//	drNew[ctNumberPlate] = CarInfoCalculation.GetNumberPlateString(dmdSalesCustomer.CarMngNo, dmdSalesCustomer.NumberPlate1Code, dmdSalesCustomer.NumberPlate1Name, dmdSalesCustomer.NumberPlate2, dmdSalesCustomer.NumberPlate3, dmdSalesCustomer.NumberPlate4);
		//
		//	// 受注売上額  受注売上計＋受注消費税額
		//	drNew[ctAcceptAnOrderSales] = dmdSalesCustomer.AcceptAnOrderSales + dmdSalesCustomer.AcceptAnOrderConsTax;
		//
		//	// 諸費用額  諸費用金額計＋諸費用消費税額
		//	drNew[ctTotalVariousCost] = dmdSalesCustomer.TotalVariousCost + dmdSalesCustomer.VarCstConsTax;
		//
		//	// 受注合計額
		//	drNew[ctTotalSales] = Convert.ToInt64(drNew[ctAcceptAnOrderSales]) + Convert.ToInt64(drNew[ctTotalVariousCost]);
		//
		//	// 引当額 共通 (入金引当額)
		//	drNew[ctAcpOdrDepositAlwc_Alw] = 0;
		//
		//	// 引当残 受注 (請求売上マスタ)
		//	drNew[ctAcpOdrDepoAlwcBlnce_Sales] = dmdSalesCustomer.AcpOdrDepoAlwcBlnce;
		//
		//	// 引当済 受注 (請求売上マスタ)
		//	drNew[ctAcpOdrDepositAlwc_Sales] = dmdSalesCustomer.AcpOdrDepositAlwc;
		//
		//	// 引当額 受注 (入金引当額)
		//	drNew[ctVarCostDepoAlwc_Alw] = 0;
		//
		//	// 引当残 諸費用 (請求売上マスタ)
		//	drNew[ctVarCostDepoAlwcBlnce_Sales] = dmdSalesCustomer.VarCostDepoAlwcBlnce;
		//
		//	// 引当済 諸費用 (請求売上マスタ)
		//	drNew[ctVarCostDepoAlwc_Sales] = dmdSalesCustomer.VarCostDepoAlwc;
		//
		//	// 引当額 諸費用 (入金引当額)
		//	drNew[ctDepositAllowance_Alw] = 0;
		//
		//	// 引当残 共通 (請求売上マスタ)
		//	drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.DepositAlwcBlnce;
		//
		//	// 引当済 共通 (請求売上マスタ)
		//	drNew[ctDepositAllowance_Sales] = dmdSalesCustomer.DepositAllowance;
		//
		//	// 最終締次更新日
		//	drNew[ctLastTotalAddUpDt] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.LastTotalAddUpDt);
		//
		//	// 納品書かつ計上日付と前回締次更新の比較
		//	if ((drNew[ctAddUpADate] != System.DBNull.Value) &&
		//	    (Convert.ToInt32(drNew[ctAddUpADate]) <= Convert.ToInt32(drNew[ctLastTotalAddUpDt])) &&
		//		(dmdSalesCustomer.AcptAnOdrStatus == 30))
		//	{
		//		drNew[ctSalesClosedFlg] = "〆";
		//	}
		//
		//	// 請求売上クラス
		//	drNew[ctSearchDmdSalesCustomer] = dmdSalesCustomer;
		//
		//	// 新規作成入金パラメータクラス
		//	drNew[ctUpdateDepositParameter] = null;
		//
		//	// 自身のDataRow
		//	drNew[ctDmdSalesDataRow] = drNew;
		//}
        #endregion

        /// <summary>
		/// 請求売上情報DetaRowセット処理
		/// </summary>
		/// <param name="drNew">請求売上情報DataRow</param>
		/// <param name="dmdSalesCustomer">請求売上クラス</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
		/// <remarks>
		/// <br>Note　　　  : 請求売上情報をDataRowにセットします。</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.25</br>
        /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)
        /// <br>              項目「引当」を追加する。</br>
        /// <br>Update Date : 2011/02/09 李占川</br>
        /// <br>              Redmine#18848を修正する。</br>
		/// </remarks>
		private void SetDmdSalesCustomer(DataRow drNew, SearchClaimSales dmdSalesCustomer, int consTaxLayMethod)
		{
			// 引
			drNew[ctAlwCheck] = false;

			// 赤黒区分/名称
			switch (dmdSalesCustomer.DebitNoteDiv)
			{
				case 0:
                    // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                    //if (dmdSalesCustomer.DebitNLnkAcptAnOdr == 0)
                    //{
                    //    drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
                    //    drNew[ctDebitNoteNm] = "黒";
                    //}
                    //else
                    //{
                    //    drNew[ctDebitNoteDiv] = 2;					// 相殺済み黒は2にすりかえる
                    //    drNew[ctDebitNoteNm] = "相殺済み黒";
                    //}
                    drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
                    drNew[ctDebitNoteNm] = "黒";
                    // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
					break;
				case 1:
					drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
					drNew[ctDebitNoteNm] = "赤";
					break;
                case 2:
                    {
                        drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
                        drNew[ctDebitNoteNm] = "相殺済み黒";
                        break;
                    }
			}
	
            // 売上伝票番号
			drNew[ctSalesSlipNum] = dmdSalesCustomer.SalesSlipNum;

            if (System.DateTime.MinValue != dmdSalesCustomer.SalesDate)
			{
                // ↓ 20070418 18322 c MA.NS対応
				//// 伝票日付(表示用)
				//drNew[ctSearchSlipDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", dmdSalesCustomer.SearchSlipDate);

				// 伝票日付(表示用)
                //drNew[ctSearchSlipDateDisp] = dmdSalesCustomer.SearchSlipDate.ToString("yyyy/MM/dd");
                drNew[ctSearchSlipDateDisp] = dmdSalesCustomer.SalesDate.ToString("yyyy/MM/dd");
                // ↑ 20070418 18322 c
				
				// 伝票日付
                //drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.SearchSlipDate);
                drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.SalesDate);
			}

			if (System.DateTime.MinValue != dmdSalesCustomer.AddUpADate)
			{
				// 売上日
				drNew[ctAddUpADate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.AddUpADate);
			}

            // 請求先コード
            drNew[ctClaimCode] = dmdSalesCustomer.ClaimCode;

            // 請求先名称
            drNew[ctClaimName] = dmdSalesCustomer.ClaimSnm.Trim();

            //// 得意先コード
            //drNew[ctCustomerCode] = dmdSalesCustomer.CustomerCode;
            
            // 得意先名称
            drNew[ctCustomerName] = dmdSalesCustomer.CustomerSnm.Trim();

            // 受注ステータス
			drNew[ctAcptAnOdrStatus] = dmdSalesCustomer.AcptAnOdrStatus;

            // 受注ステータス名
			string str = "";
			switch (dmdSalesCustomer.AcptAnOdrStatus)
			{
                case 10 : str += "見積"          ; break;
				case 20 : str += "受注"          ; break;
                case 30 : str += "売上"          ; break;
                case 40 : str += "出荷"          ; break;
			}
            drNew[ctAcptAnOdrStatusNm] = str;

            // 伝票種類（売上伝票区分）
            str = "";
            switch (dmdSalesCustomer.SalesSlipCd)
            {
                case 0: str = "売上"; break; 
                case 1: str = "返品"; break; 
                case 2: str = "値引"; break; 
            }
            drNew[ctSalesKind] = str;
            
            //// 売上形式
            //str = "";
            //switch (dmdSalesCustomer.SalesFormal)
            //{
            //    case 10 : str = "店頭売上"        ; break;
            //    case 11 : str = "外販"            ; break;
            //    case 20 : str = "業務販売（売切）"; break;
            //    case 25 : str = "売切計上"        ; break;
            //    case 30 : str = "委託"            ; break;
            //    case 35 : str = "委託計上"        ; break;
            //}
            //drNew[ctSalesName] = str;
            // ↑ 20070125 18322 c

            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            // 伝票備考
            drNew[ctSlipNote] = dmdSalesCustomer.SlipNote.Trim() + " " + dmdSalesCustomer.SlipNote2.Trim() + " " + dmdSalesCustomer.SlipNote3.Trim();
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

			// 引当額 共通 (入金引当額)
			drNew[ctDepositAllowance_Alw] = 0;

			// 引当残 共通 (請求売上マスタ)
            if ((consTaxLayMethod == 2) || (consTaxLayMethod == 3) || (consTaxLayMethod == 9))
            {
                // --- UPD 2011/02/09 ---------->>>>>
                // 税抜き
                //if (dmdSalesCustomer.DepositAllowanceTtl != 0)
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxExc - dmdSalesCustomer.DepositAllowanceTtl;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxExc - dmdSalesCustomer.DepositAllowanceTtl;
                //}
                //else
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = 0;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = 0;
                //}

                drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxExc - dmdSalesCustomer.DepositAllowanceTtl;
                drNew[ctBfDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxExc - dmdSalesCustomer.DepositAllowanceTtl;
                // --- UPD 2011/02/09  ----------<<<<<
            }
            else
            {
                // --- UPD 2011/02/09 ---------->>>>>
                // 税込み
                //if (dmdSalesCustomer.DepositAllowanceTtl != 0)
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxInc - dmdSalesCustomer.DepositAllowanceTtl;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxInc - dmdSalesCustomer.DepositAllowanceTtl;
                //}
                //else
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = 0;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = 0;
                //}

                drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxInc - dmdSalesCustomer.DepositAllowanceTtl;
                drNew[ctBfDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxInc - dmdSalesCustomer.DepositAllowanceTtl;
                // --- UPD 2011/02/09  ----------<<<<<
            }
            
			// 引当済 共通 (請求売上マスタ)
            drNew[ctDepositAllowance_Sales] = dmdSalesCustomer.DepositAllowanceTtl;
            drNew[ctBfDepositAllowance_Sales] = dmdSalesCustomer.DepositAllowanceTtl;

            // --- ADD 2010/12/20 ---------->>>>>
            // 売上伝票番号
            drNew[ctDepSaleSlipNum] = dmdSalesCustomer.DepSalesSlipNum;

            // 引当
            if ((long)drNew[ctDepositAlwcBlnce_Sales] == 0 && !string.IsNullOrEmpty(dmdSalesCustomer.DepSalesSlipNum))
            {
                // №1:入金引当残高(DepositAlwcBlnce)＝0場合
                drNew[ctAllowDiv] = "済";
            }
            else if (dmdSalesCustomer.DepositAllowanceTtl != 0)
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

            // 売上伝票合計
            if ((consTaxLayMethod == 2) || (consTaxLayMethod == 3) || (consTaxLayMethod == 9))
            {
                // 税抜き
                drNew[ctSalesTotalTaxExc] = dmdSalesCustomer.SalesTotalTaxExc;
            }
            else
            {
                // 税込み
                drNew[ctSalesTotalTaxExc] = dmdSalesCustomer.SalesTotalTaxInc;
            }

            // 売掛区分(0:売掛なし,1:売掛)
            drNew[ctAccRecDivCd]  = dmdSalesCustomer.AccRecDivCd;

			// 最終締次更新日
            drNew[ctLastTotalAddUpDt] = TDateTime.DateTimeToLongDate(this._lastAddUpDay);

            // 最終月次締め日
            drNew[ctLastMonthlyDate] = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay);

            //// --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            //// 最終月次締め日(表示用)
            //if (this._lastMonthlyAddUpDay == DateTime.MinValue)
            //{
            //    drNew[ctLastMonthlyDateDisp] = DBNull.Value;
            //}
            //else
            //{
            //    drNew[ctLastMonthlyDateDisp] = this._lastMonthlyAddUpDay.ToString("yyyy/MM/dd");
            //}
            //// --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

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

			// 請求売上クラス
			drNew[ctSearchClaimSales] = dmdSalesCustomer;

			// 新規作成入金パラメータクラス
			drNew[ctUpdateDepositParameter] = null;

            // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
            if (KaToOption())
            {
                // 担当者
                drNew[ctDepositAgentCode] = dmdSalesCustomer.SalesEmployeeNm ;
            }
            // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<

			// 自身のDataRow
			drNew[ctDmdSalesDataRow] = drNew;
		}
        // ↑ 20070125 18322 c

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金マスタ更新内容セット処理
		/// </summary>
		/// <param name="updateDepositParameter">入金更新用クラス</param>
		/// <param name="drDmdSalesList">更新対象請求売上DataRow</param>
		/// <param name="alCreateDepsitMainWork">更新入金マスタ</param>
		/// <remarks>
		/// <br>Note       : 入金マスタの更新内容を作成します。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/06/26</br>
        /// <br>Update Note: 2012/02/27 鄧潘ハン</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28395 売上指定型で入金した場合、得意先子の入金が売上データと紐付かないについての対応</br>
        /// <br>Update Note: 2012/09/21 田建委</br>
        /// <br>管理番号   : 2012/10/17配信分</br>
        /// <br>             Redmine#32415 発行者の追加対応</br>
        /// </remarks>
        private void SetUpdateDepositData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out SearchDepsitMain depsitMain, out Hashtable htDepositAlw)
		{
            depsitMain = new SearchDepsitMain();
            htDepositAlw = new Hashtable();

            //==========================================//
            // ---            入金マスタ            --- //
            //==========================================//
            depsitMain.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;                                    // 企業コード

            SearchClaimSales searchClaimSales = drDmdSalesList[0][ctSearchClaimSales] as SearchClaimSales;
            depsitMain.ClaimCode = searchClaimSales.ClaimCode;                                            // 請求先コード
            depsitMain.ClaimName = searchClaimSales.ClaimName;                                            // 請求先名1
            depsitMain.ClaimName2 = searchClaimSales.ClaimName2;                                          // 請求先名2
            depsitMain.ClaimSnm = searchClaimSales.ClaimSnm;                                              // 請求先略称
            //---DEL 鄧潘ハン 2012/02/27 Redmine#28406------>>>>>
            //depsitMain.CustomerCode = searchClaimSales.CustomerCode;                                      // 得意先コード
            //depsitMain.CustomerName = searchClaimSales.CustomerName;                                      // 得意先名1
            //depsitMain.CustomerName2 = searchClaimSales.CustomerName2;                                    // 得意先名2
            //depsitMain.CustomerSnm = searchClaimSales.CustomerSnm;                                        // 得意先略称
            //---DEL 鄧潘ハン 2012/02/27 Redmine#28406------<<<<<
            //---ADD 鄧潘ハン 2012/02/27 Redmine#28406------>>>>>
            depsitMain.CustomerCode = searchClaimSales.ClaimCode;                                      // 得意先コード
            depsitMain.CustomerName = searchClaimSales.ClaimName;                                      // 得意先名1
            depsitMain.CustomerName2 = searchClaimSales.ClaimName2;                                    // 得意先名2
            depsitMain.CustomerSnm = searchClaimSales.ClaimSnm;                                        // 得意先略称
            //---ADD 鄧潘ハン 2012/02/27 Redmine#28406------<<<<<

            depsitMain.SubSectionCode = GetSubSectionCode(LoginInfoAcquisition.Employee.EmployeeCode);
            depsitMain.InputDepositSecCd = updateDepositParameter.InputDepositSecCd;                            // 入金入力拠点コード
            depsitMain.AddUpSecCode = updateDepositParameter.AddUpSecCode;                                      // 計上拠点コード
            depsitMain.LogicalDeleteCode = 0;                                                                   // 論理削除区分
            depsitMain.AcptAnOdrStatus = 30;                                                                    // 受注ステータス
            depsitMain.DepositDebitNoteCd = 0;                                                                  // 入金赤黒区分
            depsitMain.UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;                           // 更新拠点コード
            // DEL 2009/05/21 ------>>>
            //depsitMain.DepositDate = DateTime.Today;                                                            // 入金日付
            //depsitMain.AddUpADate = DateTime.Today;                                                             // 計上日付
            // DEL 2009/05/21 ------<<<
            // ADD 2009/05/21 ------>>>
            depsitMain.DepositDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);          // 入金日付
            depsitMain.AddUpADate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);           // 計上日付
            // ADD 2009/05/21 ------<<<
            depsitMain.DepositTotal = GetDepositAlwTotal(drDmdSalesList);                                       // 入金計
            depsitMain.Deposit = (GetDepositAlwTotal(drDmdSalesList) - updateDepositParameter.FeeDeposit);      // 共通 入金額
            depsitMain.FeeDeposit = updateDepositParameter.FeeDeposit;                                          // 共通 手数料
            depsitMain.DiscountDeposit = 0;                                                                     // 共通 値引
            depsitMain.DraftDrawingDate = TDateTime.LongDateToDateTime(updateDepositParameter.DraftDrawingDate);// 手形振出日
            depsitMain.DraftKind = updateDepositParameter.DraftKind;                                            // 手形種類
            depsitMain.DraftKindName = updateDepositParameter.DraftKindName;                                    // 手形種類名称
            depsitMain.DraftDivide = updateDepositParameter.DraftDivide;                                        // 手形区分
            depsitMain.DraftDivideName = updateDepositParameter.DraftDivideName;                                // 手形区分名称
            depsitMain.DraftNo = updateDepositParameter.DraftNo;                                                // 手形番号
            depsitMain.DebitNoteLinkDepoNo = 0;                                                                 // 赤黒入金連結番号
            depsitMain.DepositAgentCode = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;               // 入金担当者コード
            depsitMain.DepositAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;                         // 入金担当者名
            //----- DEL 2012/09/21 田建委 redmine#32415 ---------->>>>>
            //depsitMain.DepositInputAgentCd = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;            // 入金入力者コード
            //depsitMain.DepositInputAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;                    // 入金入力者名
            //----- DEL 2012/09/21 田建委 redmine#32415 ----------<<<<<
            //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
            depsitMain.DepositInputAgentCd = updateDepositParameter.DepositInputAgentCd;                        // 入金入力者コード
            depsitMain.DepositInputAgentNm = updateDepositParameter.DepositInputAgentNm;                        // 入金入力者名
            //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<
            depsitMain.Outline = updateDepositParameter.Outline;                                                // 摘要
            depsitMain.BankCode = updateDepositParameter.BankCode;                                              // 銀行コード
            depsitMain.BankName = updateDepositParameter.BankName;                                              // 銀行名称
            depsitMain.DepositAllowance = GetDepositAlwTotal(drDmdSalesList);                                   // 入金引当額 共通
            depsitMain.DepositAlwcBlnce = 0;                                                                    // 入金引当残 共通

            for (int index = 0; index < depsitMain.MoneyKindName.Length; index++)
            {
                depsitMain.MoneyKindName[index] = "";
            }
            // 入金行番号取得
            int depositRowNo = depositRelDataAcs.GetDepositRowNo(updateDepositParameter.MoneyKindCode);
            depsitMain.DepositRowNo[depositRowNo - 1] = depositRowNo;                                           // 入金行番号
            depsitMain.MoneyKindCode[depositRowNo - 1] = updateDepositParameter.MoneyKindCode;                  // 金種コード
            depsitMain.MoneyKindName[depositRowNo - 1] = updateDepositParameter.MoenyKindName;                  // 金種名称
            depsitMain.MoneyKindDiv[depositRowNo - 1] = (Int32)depositRelDataAcs.HtMoneyKindDiv[updateDepositParameter.MoneyKindCode];                    // 金種区分
            depsitMain.DepositDtl[depositRowNo - 1] = (GetDepositAlwTotal(drDmdSalesList) - updateDepositParameter.FeeDeposit); // 入金金額
            depsitMain.ValidityTerm[depositRowNo - 1] = TDateTime.LongDateToDateTime(updateDepositParameter.ValidityTerm);
            depsitMain.InputDay = DateTime.Today;

            //==========================================//
            // ---     入金引当マスタ 新規/更新     --- //
            //==========================================//
            foreach (DataRow dr in drDmdSalesList)
            {
                SearchDepositAlw depositAlw = new SearchDepositAlw();
                htDepositAlw.Add((String)dr[ctSalesSlipNum], depositAlw);
                
                depositAlw.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;                                    // 企業コード
                depositAlw.ClaimCode = depsitMain.ClaimCode;                                                        // 請求先コード
                depositAlw.ClaimName = depsitMain.ClaimName;                                                        // 請求先名1
                depositAlw.ClaimName2 = depsitMain.ClaimName2;                                                      // 請求先名2
                depositAlw.ClaimSnm = depsitMain.ClaimSnm;                                                          // 請求先略称
                depositAlw.CustomerCode = depsitMain.CustomerCode;                                                  // 得意先コード
                depositAlw.CustomerName = depsitMain.CustomerName;                                                  // 得意先名1
                depositAlw.CustomerName2 = depsitMain.CustomerName2;                                                // 得意先名2
                depositAlw.CustomerSnm = depsitMain.CustomerSnm;                                                    // 得意先略称
                depositAlw.AddUpSecCode = depsitMain.AddUpSecCode;                                                  // 計上拠点コード
                depositAlw.InputDepositSecCd = depsitMain.InputDepositSecCd;                                        // 入金入力拠点コード
                depositAlw.DepositSlipNo = depsitMain.DepositSlipNo;                                                // 入金番号
                depositAlw.AcptAnOdrStatus = (Int32)dr[ctAcptAnOdrStatus];                                          // 受注ステータス
                depositAlw.SalesSlipNum = (String)dr[ctSalesSlipNum];                                               // 売上伝票番号
                depositAlw.DepositAllowance = (Int64)dr[ctDepositAllowance_Alw];                                    // 入金引当額 共通
                depositAlw.ReconcileDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);        // 引当日（消込日）
                depositAlw.ReconcileAddUpDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);   // 引当計上日付（消込み計上日）
                depositAlw.DepositAgentCode = depsitMain.DepositAgentCode;                                          // 入金担当者コード
                depositAlw.DepositAgentNm = depsitMain.DepositAgentNm;                                              // 入金担当者名
                depositAlw.DebitNoteOffSetCd = depsitMain.DepositDebitNoteCd;                                       // 赤伝相殺区分
            }
        }

        /// <summary>
        /// 引当額合計取得処理
        /// </summary>
        /// <param name="drDmdSalesList">更新対象請求売上DataRow</param>
        /// <returns>引当額合計</returns>
        /// <remarks>
        /// <br>Note       : 引当額の合計を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private Int64 GetDepositAlwTotal(DataRow[] drDmdSalesList)
        {
            Int64 depositAlwTotal = 0;
            foreach (DataRow dr in drDmdSalesList)
            {
                depositAlwTotal += (Int64)dr[ctDepositAllowance_Alw];
            }

            return depositAlwTotal;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入金マスタ更新内容セット処理
        /// </summary>
        /// <param name="updateDepositParameter">入金更新用クラス</param>
        /// <param name="drDmdSalesList">更新対象請求売上DataRow</param>
        /// <param name="alCreateDepsitMainWork">更新入金マスタ</param>
        /// <remarks>
        /// <br>Note       : 入金マスタの更新内容を作成します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void SetUpdateDepositData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out ArrayList alCreateDepsitMainWork)
        {
            alCreateDepsitMainWork = new ArrayList();

            foreach (DataRow dr in drDmdSalesList)
            {
                // 入金更新データ
                CreateDepsitMainWork createDepsitMainWork = new CreateDepsitMainWork();

                // ↓ 20070131 18322 c MA.NS用に変更
                #region SF 全てコメントアウト
                //// 受注番号
                //createDepsitMainWork.AcceptAnOrderNo = Convert.ToInt32(dr[ctAcceptAnOrderNo]);
                //
                //// 入金金種コード
                //createDepsitMainWork.DepositKindCode = updateDepositParameter.DepositKindCode;
                //
                //// 得意先コード
                //createDepsitMainWork.CustomerCode = Convert.ToInt32(dr[ctCustomerCode]);
                //
                //// 預り金区分
                //createDepsitMainWork.DepositCd = updateDepositParameter.DepositCd;
                //
                //// 伝票摘要 (初期値)
                //createDepsitMainWork.Outline = "";
                //
                //// 入金入力拠点コード
                //createDepsitMainWork.InputDepositSecCd = updateDepositParameter.LoginSectionCode;
                //
                //// 入金日付
                //createDepsitMainWork.DepositDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);
                //
                //// 計上拠点コード
                //createDepsitMainWork.AddUpSecCode = updateDepositParameter.AddSectionCode;
                //
                //// 計上日付
                //createDepsitMainWork.AddUpADate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);
                //
                //// 更新拠点コード
                //createDepsitMainWork.UpdateSecCd = updateDepositParameter.LoginSectionCode;
                //
                //// 入金金種名称
                //createDepsitMainWork.DepositKindName = (string)depositRelDataAcs.SlMoneyKindCode[updateDepositParameter.DepositKindCode];
                //
                //// 入金担当者コード
                //createDepsitMainWork.DepositAgentCode = updateDepositParameter.EmployeeCd;
                //
                //// 入金金種区分
                //createDepsitMainWork.DepositKindDivCd = (int)depositRelDataAcs.HtMoneyKindDiv[updateDepositParameter.DepositKindCode];
                //
                //// 手数料入金額 共通 (初期値)
                //createDepsitMainWork.FeeDeposit = 0;
                //
                //// 手数料入金額 受注 (初期値)
                //createDepsitMainWork.AcpOdrChargeDeposit = 0;
                //
                //// 手数料入金額 諸費用 (初期値)
                //createDepsitMainWork.VarCostChargeDeposit = 0;
                //
                //// 値引入金額 共通 (初期値)
                //createDepsitMainWork.DiscountDeposit = 0;
                //
                //// 値引入金額 受注 (初期値)
                //createDepsitMainWork.AcpOdrDisDeposit = 0;
                //
                //// 値引入金額 諸費用 (初期値)
                //createDepsitMainWork.VarCostDisDeposit = 0;
                //
                //// クレジット／ローン区分
                //createDepsitMainWork.CreditOrLoanCd = updateDepositParameter.CreditOrLoanCd;
                //
                //// クレジット会社コード
                //createDepsitMainWork.CreditCompanyCode = updateDepositParameter.CreditCompanyCode;
                //
                //// 引当額 受注 (入金引当額)
                //createDepsitMainWork.AcpOdrDeposit = Convert.ToInt64(dr[ctAcpOdrDepositAlwc_Alw]);
                //
                //// 引当額 諸費用 (入金引当額)
                //createDepsitMainWork.VariousCostDeposit = Convert.ToInt64(dr[ctVarCostDepoAlwc_Alw]);
                //
                //// 引当額 共通 (入金引当額)
                //createDepsitMainWork.Deposit = Convert.ToInt64(dr[ctDepositAllowance_Alw]);
                //
                //// 手形振出日 (初期値)
                //createDepsitMainWork.DraftDrawingDate = DateTime.MinValue;
                //
                //// 手形支払期日 (初期値)
                //createDepsitMainWork.DraftPayTimeLimit = DateTime.MinValue;
                #endregion

                // 入金入力拠点コード
                createDepsitMainWork.InputDepositSecCd = updateDepositParameter.LoginSectionCode;

                // 計上拠点コード
                createDepsitMainWork.AddUpSecCode = updateDepositParameter.AddSectionCode;

                // 更新拠点コード
                createDepsitMainWork.UpdateSecCd = updateDepositParameter.LoginSectionCode;

                // 2007.10.05 upd start --------------------------------------------------->>
                // 入金日付
                //createDepsitMainWork.DepositDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);
                createDepsitMainWork.DepositDate = TDateTime.GetSFDateNow();
                // 2007.10.05 upd end -----------------------------------------------------<<

                // 計上日付
                createDepsitMainWork.AddUpADate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);

                // 入金金種コード
                createDepsitMainWork.DepositKindCode = updateDepositParameter.DepositKindCode;

                // 入金金種名称
                createDepsitMainWork.DepositKindName = (string)depositRelDataAcs.SlMoneyKindCode[updateDepositParameter.DepositKindCode];

                // 入金金種区分
                createDepsitMainWork.DepositKindDivCd = (int)depositRelDataAcs.HtMoneyKindDiv[updateDepositParameter.DepositKindCode];

                // 引当額取得
                Int64 amountOfDrawing = Convert.ToInt64(dr[ctDepositAllowance_Alw]);

                // 入金計
                createDepsitMainWork.DepositTotal = amountOfDrawing;

                // 入金金額
                createDepsitMainWork.Deposit = amountOfDrawing;

                // 手数料入金額 共通 (初期値)
                createDepsitMainWork.FeeDeposit = 0;

                // 値引入金額 共通 (初期値)
                createDepsitMainWork.DiscountDeposit = 0;

                // インセンティブ（リベート入金額）
                createDepsitMainWork.RebateDeposit = 0;

                // 自動入金区分(0:通常入金)
                createDepsitMainWork.AutoDepositCd = 0;

                // 預り金区分()
                createDepsitMainWork.DepositCd = updateDepositParameter.DepositCd;

                // 手形振出日 (初期値)
                createDepsitMainWork.DraftDrawingDate = DateTime.MinValue;

                // 手形支払期日 (初期値)
                createDepsitMainWork.DraftPayTimeLimit = DateTime.MinValue;

                // 銀行コード
                createDepsitMainWork.BankCode = updateDepositParameter.BankCode;
                // 銀行名称
                createDepsitMainWork.BankName = updateDepositParameter.BankName;
                // 手形種類
                createDepsitMainWork.DraftKind = updateDepositParameter.DraftKind;
                // 手形種類名称
                createDepsitMainWork.DraftKindName = updateDepositParameter.DraftKindName;
                // 手形区分
                createDepsitMainWork.DraftDivide = updateDepositParameter.DraftDivide;
                // 手形区分名称
                createDepsitMainWork.DraftDivideName = updateDepositParameter.DraftDivideName;
                // 手形番号
                createDepsitMainWork.DraftNo = updateDepositParameter.DraftNo;

                #region リモート側で設定？
                //// 引当額 共通 (入金引当額)
                //createDepsitMainWork.DepositAllowance = amountOfDrawing;
                //
                //// 入金引当残高
                //createDepsitMainWork.DepositAlwcBlnce = Convert.ToInt64(dr[ctDepositAlwcBlnce_Sales]);

                // 赤黒入金連結番号

                // 最終消込計上日
                #endregion

                // 入金担当者コード
                createDepsitMainWork.DepositAgentCode = updateDepositParameter.EmployeeCd;
                createDepsitMainWork.DepositAgentNm = updateDepositParameter.EmployeeName;

                SearchClaimSales searchClaimSales = dr[ctSearchClaimSales] as SearchClaimSales;
                if (searchClaimSales != null)
                {
                    // 請求先コード
                    createDepsitMainWork.ClaimCode = searchClaimSales.ClaimCode;
                    // 請求先名1
                    createDepsitMainWork.ClaimName = searchClaimSales.ClaimName;
                    // 請求先名2
                    createDepsitMainWork.ClaimName2 = searchClaimSales.ClaimName2;
                    // 請求先略称
                    createDepsitMainWork.ClaimSnm = searchClaimSales.ClaimSnm;

                    // 得意先コード
                    createDepsitMainWork.CustomerCode = searchClaimSales.CustomerCode;
                    // 得意先名1
                    createDepsitMainWork.CustomerName = searchClaimSales.CustomerName;
                    // 得意先名2
                    createDepsitMainWork.CustomerName2 = searchClaimSales.CustomerName2;
                    // 得意先略称
                    createDepsitMainWork.CustomerSnm = searchClaimSales.CustomerSnm;

                    // 受注ステータス
                    createDepsitMainWork.AcptAnOdrStatus = searchClaimSales.AcptAnOdrStatus;
                    // 売上伝票番号
                    createDepsitMainWork.SalesSlipNum = searchClaimSales.SalesSlipNum;
                }

                // 伝票摘要 (初期値)
                createDepsitMainWork.Outline = "";

                // ↑ 20070131 18322 c

                // 配列に追加
                alCreateDepsitMainWork.Add(createDepsitMainWork);
            }

        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        #region 2008/06/26 DEL 使用していないのでコメントアウト
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 入金データ更新処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="createDepsitMainWorkList">入金マスタ(更新用)</param>
		/// <param name="depositSlipNoList">新規保存した入金番号</param>
		/// <remarks>
		/// <br>Note       : 入金マスタの更新を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void WriteDepositData(string enterpriseCode, CreateDepsitMainWork[] createDepsitMainWorkList, out int[] depositSlipNoList)
		{
			string message;

			int st = _depsitMainAcs.WriteDB(enterpriseCode, createDepsitMainWorkList, out depositSlipNoList, out message);

			// エラーの時は例外を発生させる
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL 使用していないのでコメントアウト

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
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
            depsitDataWork.SubSectionCode = depsitMain.SubSectionCode;
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

        /// <summary>
        /// クラスメンバーコピー処理（入金引当マスタ⇒入金引当マスタワーク）
        /// </summary>
        /// <param name="depositAlwList">入金引当マスタクラス</param>
        /// <returns>入金マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note        : 入金引当マスタクラスから入金マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2012/02/10 田建委</br>
        /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
        /// <br>              Redmine#28395 引当保存エラー発生の対応</br>
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
                // ----- DEL 2012/02/10 田建委 Redmine#28395 --------------------------------------->>>>>
                //depositAlwWork.CustomerCode = depositAlw.CustomerCode;                  // 得意先コード
                //depositAlwWork.CustomerName = depositAlw.CustomerName;                  // 得意先名称
                //depositAlwWork.CustomerName2 = depositAlw.CustomerName2;                // 得意先名称2
                // ----- DEL 2012/02/10 田建委 Redmine#28395 ---------------------------------------<<<<<
                // ----- ADD 2012/02/10 田建委 Redmine#28395 --------------------------------------->>>>>
                depositAlwWork.CustomerCode = depositAlw.ClaimCode;                     // 請求先コード
                depositAlwWork.CustomerName = depositAlw.ClaimName;                     // 請求先名称
                depositAlwWork.CustomerName2 = depositAlw.ClaimName2;                   // 請求先名称2
                // ----- ADD 2012/02/10 田建委 Redmine#28395 ---------------------------------------<<<<<
                depositAlwWork.AcptAnOdrStatus = depositAlw.AcptAnOdrStatus;            // 受注ステータス
                depositAlwWork.SalesSlipNum = depositAlw.SalesSlipNum;                  // 売上伝票番号
                depositAlwWork.DebitNoteOffSetCd = depositAlw.DebitNoteOffSetCd;        // 赤伝相殺区分

                arrDepositAlw.Add(depositAlwWork);
            }

            DepositAlwWork[] list = (DepositAlwWork[])arrDepositAlw.ToArray(typeof(DepositAlwWork));

            return list;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
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
		# endregion

		# region Public class SearchSalesParameter
        // ↓ 20070125 18322 c MA.NS用に変更
        #region SF 請求売上情報取得用パラメータ（全てコメントアウト）
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
		//	/// <summary>受注番号</summary>
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
		//	/// <summary>受注番号 プロパティ</summary>
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
        #endregion

        #region 請求売上情報取得用パラメータ
		/// public class name:   SearchSalesParameter
		/// <summary>
		///                      請求売上情報取得用パラメータ
		/// </summary>
		/// <remarks>
		/// <br>note             :   請求売上情報取得用パラメータヘッダファイル</br>
		/// <br>Programmer       :   自動生成</br>
		/// <br>Date             :   木村 武正</br>
		/// <br>Genarated Date   :   2007/05/14  (CSharp File Generated Date)</br>
		/// <br>Update Note      :   </br>
		/// </remarks>
		public class SearchSalesParameter
		{
			/// <summary>企業コード</summary>
			/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
			private string _enterpriseCode = "";
	
			/// <summary>受注ステータス</summary>
			/// <remarks>1:予約,2:予約キャンセル,10:見積,11:見積キャンセル20:受注,21:受注キャンセル,30:売上,40:売切,45:売切計上,50:委託,55:委託計上</remarks>
			private Int32[] _acptAnOdrStatus = null;
	
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
			/// <remarks>0:OFF,1:ON</remarks>
			private Int32 _serviceSlipCd;
	
			/// <summary>売掛区分</summary>
			/// <remarks>0:売掛なし,1:売掛</remarks>
			private Int32 _accRecDivCd;
	
			/// <summary>自動入金区分</summary>
			/// <remarks>0:通常入金,1:自動入金</remarks>
			private Int32 _autoDepositCd;
	
			/// <summary>企業名称</summary>
			private string _enterpriseName = "";
	
			/// <summary>実績計上拠点名称</summary>
			private string _resultsAddUpSecNm = "";
	
			/// <summary>販売従業員名称</summary>
			private string _salesEmployeeNm = "";
	
	
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
			/// <value>0:OFF,1:ON</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   サービス伝票区分プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 ServiceSlipCd
			{
				get{return _serviceSlipCd;}
				set{_serviceSlipCd = value;}
			}
	
			/// public propaty name  :  AccRecDivCd
			/// <summary>売掛区分プロパティ</summary>
			/// <value>0:売掛なし,1:売掛</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   売掛区分プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 AccRecDivCd
			{
				get{return _accRecDivCd;}
				set{_accRecDivCd = value;}
			}
	
			/// public propaty name  :  AutoDepositCd
			/// <summary>自動入金区分プロパティ</summary>
			/// <value>0:通常入金,1:自動入金</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   自動入金区分プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public Int32 AutoDepositCd
			{
				get{return _autoDepositCd;}
				set{_autoDepositCd = value;}
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
	
			/// public propaty name  :  ResultsAddUpSecNm
			/// <summary>実績計上拠点名称プロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   実績計上拠点名称プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public string ResultsAddUpSecNm
			{
				get{return _resultsAddUpSecNm;}
				set{_resultsAddUpSecNm = value;}
			}
	
			/// public propaty name  :  SalesEmployeeNm
			/// <summary>販売従業員名称プロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   販売従業員名称プロパティ</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public string SalesEmployeeNm
			{
				get{return _salesEmployeeNm;}
				set{_salesEmployeeNm = value;}
			}
	
	
			/// <summary>
			/// 請求売上情報取得用パラメータコンストラクタ
			/// </summary>
			/// <returns>SearchSalesParameterクラスのインスタンス</returns>
			/// <remarks>
			/// <br>Note　　　　　　 :   SearchSalesParameterクラスの新しいインスタンスを生成します</br>
			/// <br>Programer        :   自動生成</br>
			/// </remarks>
			public SearchSalesParameter()
			{
			}
	
		}
        #endregion
        // ↑ 20070125 18322 c
        # endregion

        # region Public class UpdateDepositParameter
        /// <summary>入金更新用パラメータ</summary>
		public class UpdateDepositParameter
        {
            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            /// <summary>企業コード</summary>
            private string _enterpriseCode;

            /// <summary>入金番号(更新後)</summary>
            private Int32 _depositSlipNo;

            /// <summary>受注ステータス</summary>
            /// <value>10:見積 20:受注 30:売上 40:出荷</value>
            private Int32 _acptAnOdrStatus;

            /// <summary>売上伝票番号</summary>
            private String _salesSlipNum = "";

            /// <summary>入金入力拠点コード</summary>
            private String _inputDepositSecCd = "";

            /// <summary>計上拠点コード</summary>
            private String _addUpSecCode = "";

            /// <summary>更新拠点コード</summary>
            private String _updateSecCode = "";

            /// <summary>部門コード</summary>
            private Int32 _subSectionCode;

            /// <summary>入金日付</summary>
            /// <value>YYYYMMDD</value>
            private Int32 _depositDate;

            /// <summary>計上日付</summary>
            /// <value>YYYYMMDD</value>
            private Int32 _addUpDate;

            /// <summary>入金計</summary>
            /// <value>入金金額＋手数料入金額＋値引入金額</value>
            private Int64 _depositTotal;

            /// <summary>入金金額</summary>
            private Int64 _deposit;

            /// <summary>手数料入金額</summary>
            private Int64 _feeDeposit;

            /// <summary>値引入金額</summary>
            private Int64 _discountDeposit;

            /// <summary>自動入金区分</summary>
            /// <value>0:通常入金 1:自動入金</value>
            private Int32 _autoDepositCd;

            /// <summary>手形振出日</summary>
            /// <value>YYYYMMDD</value>
            private Int32 _draftDrawingDate;

            /// <summary>手形種類</summary>
            private Int32 _draftKind;

            /// <summary>手形種類名称</summary>
            private String _draftKindName = "";

            /// <summary>手形区分</summary>
            private Int32 _draftDivide;

            /// <summary>手形区分名称</summary>
            private String _draftDivideName = "";

            /// <summary>手形番号</summary>
            private String _draftNo = "";

            /// <summary>入金担当者コード</summary>
            private String _depositAgentCode = "";

            /// <summary>入金担当者名称</summary>
            private String _depositAgentNm = "";

            /// <summary>入金入力者コード</summary>
            private String _depositInputAgentCd = "";

            /// <summary>入金入力者名称</summary>
            private String _depositInputAgentNm = "";

            /// <summary>得意先コード</summary>
            private Int32 _customerCode;

            /// <summary>得意先名称</summary>
            private String _customerName = "";

            /// <summary>得意先名称2</summary>
            private String _customerName2 = "";

            /// <summary>得意先略称</summary>
            private String _customerSnm = "";

            /// <summary>請求先コード</summary>
            private Int32 _claimCode;

            /// <summary>請求先名称</summary>
            private String _claimName = "";

            /// <summary>請求先名称2</summary>
            private String _claimName2 = "";

            /// <summary>請求先略称</summary>
            private String _claimSnm = "";

            /// <summary>伝票摘要</summary>
            private String _outline = "";

            /// <summary>銀行コード</summary>
            private Int32 _bankCode;

            /// <summary>銀行名称</summary>
            private String _bankName = "";

            /// <summary>入金行番号</summary>
            private Int32 _depositRowNo;

            /// <summary>金種コード</summary>
            private Int32 _moneyKindCode;

            /// <summary>金種名称</summary>
            private String _moenyKindName = "";

            /// <summary>金種区分</summary>
            private Int32 _moneyKindDiv;

            /// <summary>有効期限</summary>
            /// <value>YYYYMMDD</value>
            private Int32 _validityTerm;

            /// <summary>企業コード プロパティ</summary>
            public String EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }

            /// <summary>入金番号(更新後)</summary>
            public Int32 DepositSlipNo
            {
                get { return _depositSlipNo; }
                set { _depositSlipNo = value; }
            }

            /// <summary>受注ステータス プロパティ</summary>
            /// <value>10:見積 20:受注 30:売上 40:出荷</value>
            public Int32 AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }

            /// <summary>売上伝票番号 プロパティ</summary>
            public String SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }

            /// <summary>入金入力拠点コード プロパティ</summary>
            public String InputDepositSecCd
            {
                get { return _inputDepositSecCd; }
                set { _inputDepositSecCd = value; }
            }

            /// <summary>計上拠点コード プロパティ</summary>
            public String AddUpSecCode
            {
                get { return _addUpSecCode; }
                set { _addUpSecCode = value; }
            }

            /// <summary>更新拠点コード プロパティ</summary>
            public String UpdateSecCode
            {
                get { return _updateSecCode; }
                set { _updateSecCode = value; }
            }

            /// <summary>部門コード プロパティ</summary>
            public Int32 SubSectionCode
            {
                get { return _subSectionCode; }
                set { _subSectionCode = value; }
            }

            /// <summary>入金日付 プロパティ</summary>
            /// <value>YYYYMMDD</value>
            public Int32 DepositDate
            {
                get { return _depositDate; }
                set { _depositDate = value; }
            }

            /// <summary>計上日付 プロパティ</summary>
            /// <value>YYYYMMDD</value>
            public Int32 AddUpDate
            {
                get { return _addUpDate; }
                set { _addUpDate = value; }
            }

            /// <summary>入金計 プロパティ</summary>
            /// <value>入金金額＋手数料入金額＋値引入金額</value>
            public Int64 DepositTotal
            {
                get { return _depositTotal; }
                set { _depositTotal = value; }
            }

            /// <summary>入金金額 プロパティ</summary>
            public Int64 Deposit
            {
                get { return _deposit; }
                set { _deposit = value; }
            }

            /// <summary>手数料入金額 プロパティ</summary>
            public Int64 FeeDeposit
            {
                get { return _feeDeposit; }
                set { _feeDeposit = value; }
            }

            /// <summary>値引入金額 プロパティ</summary>
            public Int64 DiscountDeposit
            {
                get { return _discountDeposit; }
                set { _discountDeposit = value; }
            }

            /// <summary>自動入金区分 プロパティ</summary>
            public Int32 AutoDepositCd
            {
                get { return _autoDepositCd; }
                set { _autoDepositCd = value; }
            }

            /// <summary>手形振出日 プロパティ</summary>
            /// <value>YYYYMMDD</value>
            public Int32 DraftDrawingDate
            {
                get { return _draftDrawingDate; }
                set { _draftDrawingDate = value; }
            }

            /// <summary>手形種類 プロパティ</summary>
            public Int32 DraftKind
            {
                get { return _draftKind; }
                set { _draftKind = value; }
            }

            /// <summary>手形種類名称 プロパティ</summary>
            public String DraftKindName
            {
                get { return _draftKindName; }
                set { _draftKindName = value; }
            }

            /// <summary>手形区分 プロパティ</summary>
            public Int32 DraftDivide
            {
                get { return _draftDivide; }
                set { _draftDivide = value; }
            }

            /// <summary>手形区分名称 プロパティ</summary>
            public String DraftDivideName
            {
                get { return _draftDivideName; }
                set { _draftDivideName = value; }
            }

            /// <summary>手形番号 プロパティ</summary>
            public String DraftNo
            {
                get { return _draftNo; }
                set { _draftNo = value; }
            }

            /// <summary>入金担当者コード プロパティ</summary>
            public String DepositAgentCode
            {
                get { return _depositAgentCode; }
                set { _depositAgentCode = value; }
            }

            /// <summary>入金担当者名称 プロパティ</summary>
            public String DepositAgentNm
            {
                get { return _depositAgentNm; }
                set { _depositAgentNm = value; }
            }

            /// <summary>入金入力者コード プロパティ</summary>
            public String DepositInputAgentCd
            {
                get { return _depositInputAgentCd; }
                set { _depositInputAgentCd = value; }
            }

            /// <summary>入金入力者名称 プロパティ</summary>
            public String DepositInputAgentNm
            {
                get { return _depositInputAgentNm; }
                set { _depositInputAgentNm = value; }
            }

            /// <summary>得意先コード プロパティ</summary>
            public Int32 CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }

            /// <summary>得意先名称 プロパティ</summary>
            public String CustomerName
            {
                get { return _customerName; }
                set { _customerName = value; }
            }

            /// <summary>得意先名称2 プロパティ</summary>
            public String CustomerName2
            {
                get { return _customerName2; }
                set { _customerName2 = value; }
            }

            /// <summary>得意先略称 プロパティ</summary>
            public String CustomerSnm
            {
                get { return _customerSnm; }
                set { _customerSnm = value; }
            }

            /// <summary>請求先コード プロパティ</summary>
            public Int32 ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }

            /// <summary>請求先名称 プロパティ</summary>
            public String ClaimName
            {
                get { return _claimName; }
                set { _claimName = value; }
            }

            /// <summary>請求先名称2 プロパティ</summary>
            public String ClaimName2
            {
                get { return _claimName2; }
                set { _claimName2 = value; }
            }

            /// <summary>請求先略称 プロパティ</summary>
            public String ClaimSnm
            {
                get { return _claimSnm; }
                set { _claimSnm = value; }
            }

            /// <summary>伝票摘要 プロパティ</summary>
            public String Outline
            {
                get { return _outline; }
                set { _outline = value; }
            }

            /// <summary>銀行コード プロパティ</summary>
            public Int32 BankCode
            {
                get { return _bankCode; }
                set { _bankCode = value; }
            }

            /// <summary>銀行名称 プロパティ</summary>
            public String BankName
            {
                get { return _bankName; }
                set { _bankName = value; }
            }

            /// <summary>入金行番号 プロパティ</summary>
            public Int32 DepositRowNo
            {
                get { return _depositRowNo; }
                set { _depositRowNo = value; }
            }

            /// <summary>金種コード プロパティ</summary>
            public Int32 MoneyKindCode
            {
                get { return _moneyKindCode; }
                set { _moneyKindCode = value; }
            }

            /// <summary>金種名称 プロパティ</summary>
            public String MoenyKindName
            {
                get { return _moenyKindName; }
                set { _moenyKindName = value; }
            }

            /// <summary>金種区分 プロパティ</summary>
            public Int32 MoneyKindDiv
            {
                get { return _moneyKindDiv; }
                set { _moneyKindDiv = value; }
            }

            /// <summary>有効期限 プロパティ</summary>
            public Int32 ValidityTerm
            {
                get { return _validityTerm; }
                set { _validityTerm = value; }
            }

            /// <summary>クローン</summary>
            public UpdateDepositParameter Clone()
            {
                UpdateDepositParameter ret = new UpdateDepositParameter();

                ret.EnterpriseCode = this._enterpriseCode;
                ret.DepositSlipNo = this._depositSlipNo;
                ret.AcptAnOdrStatus = this._acptAnOdrStatus;
                ret.SalesSlipNum = this._salesSlipNum;
                ret.InputDepositSecCd = this._inputDepositSecCd;
                ret.AddUpSecCode = this._addUpSecCode;
                ret.UpdateSecCode = this._updateSecCode;
                ret.SubSectionCode = this._subSectionCode;
                ret.DepositDate = this._depositDate;
                ret.AddUpDate = this._addUpDate;
                ret.DepositTotal = this._depositTotal;
                ret.Deposit = this._deposit;
                ret.FeeDeposit = this._feeDeposit;
                ret.DiscountDeposit = this._discountDeposit;
                ret.AutoDepositCd = this._autoDepositCd;
                ret.DraftDrawingDate = this._draftDrawingDate;
                ret.DraftKind = this._draftKind;
                ret.DraftKindName = this._draftKindName;
                ret.DraftDivide = this._draftDivide;
                ret.DraftDivideName = this._draftDivideName;
                ret.DraftNo = this._draftNo;
                ret.DepositAgentCode = this._depositAgentCode;
                ret.DepositAgentNm = this._depositAgentNm;
                ret.DepositInputAgentCd = this._depositInputAgentCd;
                ret.DepositInputAgentNm = this._depositInputAgentNm;
                ret.CustomerCode = this._customerCode;
                ret.CustomerName = this._customerName;
                ret.CustomerName2 = this._customerName2;
                ret.CustomerSnm = this._customerSnm;
                ret.ClaimCode = this._claimCode;
                ret.ClaimName = this._claimName;
                ret.ClaimName2 = this._claimName2;
                ret.ClaimSnm = this._claimSnm;
                ret.Outline = this._outline;
                ret.BankCode = this._bankCode;
                ret.BankName = this._bankName;
                ret.DepositRowNo = this._depositRowNo;
                ret.MoneyKindCode = this._moneyKindCode;
                ret.MoenyKindName = this._moenyKindName;
                ret.MoneyKindDiv = this._moneyKindDiv;
                ret.ValidityTerm = this._validityTerm;

                return ret;
            }
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            
            #region 2008/06/26 DEL Partsman用に変更
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			/// <summary>コンストラクタ</summary>
			public UpdateDepositParameter()
			{
				_enterpriseCode = "";
				_loginSectionCode = "";
				_addSectionCode = "";
				_employeeCd = "";
				_depositDate = 0;
				_depositCd = 0;
				_depositKindCode = 0;
				_depositSlipNo = 0;
                // ↓ 20070131 18322 c MA.NS用に変更
                _employeeName = "";
                // ↑ 20070131 18322 c
                _bankCode = 0;
                _bankName = "";
                _draftKind = 0;
                _draftKindName = "";
                _draftDivide = 0;
                _draftDivideName = "";
                _draftNo = "";
            }

			/// <summary>企業コード</summary>
			private string _enterpriseCode;
			/// <summary>ログイン拠点</summary>
			private string _loginSectionCode;
			/// <summary>計上拠点</summary>
			private string _addSectionCode;
			/// <summary>従業員コード</summary>
			private string _employeeCd;
			/// <summary>入金日</summary>
			private Int32 _depositDate;
			/// <summary>預り金区分</summary>
			private Int32 _depositCd;
			/// <summary>金種コード</summary>
			private Int32 _depositKindCode;
			/// <summary>入金番号(更新後)</summary>
			private Int32 _depositSlipNo;
            // ↓ 20070131 18322 c MA.NS用に変更
			/// <summary>従業員名</summary>
            private string _employeeName;
            // ↑ 20070131 18322 c
            /// <summary>銀行コード</summary>
            private Int32 _bankCode;
            /// <summary>銀行名称</summary>
            private string _bankName;
            /// <summary>手形種類</summary>
            private Int32 _draftKind;
            /// <summary>手形種類名称</summary>
            private string _draftKindName;
            /// <summary>手形区分</summary>
            private Int32 _draftDivide;
            /// <summary>手形区分名称</summary>
            private string _draftDivideName;
            /// <summary>手形番号</summary>
            private string _draftNo;

               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            /// <summary>企業コード プロパティ</summary>
			public string EnterpriseCode
			{
				get{return _enterpriseCode;}
				set{_enterpriseCode = value;}
			}
			/// <summary>ログイン拠点 プロパティ</summary>
			public string LoginSectionCode
			{
				get{return _loginSectionCode;}
				set{_loginSectionCode = value;}
			}
			/// <summary>計上拠点 プロパティ</summary>
			public string AddSectionCode
			{
				get{return _addSectionCode;}
				set{_addSectionCode = value;}
			}
			/// <summary>従業員コード プロパティ</summary>
			public string EmployeeCd
			{
				get{return _employeeCd;}
				set{_employeeCd = value;}
			}
			/// <summary>入金日 プロパティ</summary>
			public Int32 DepositDate
			{
				get{return _depositDate;}
				set{_depositDate = value;}
			}
			/// <summary>預り金区分 プロパティ</summary>
			public Int32 DepositCd
			{
				get{return _depositCd;}
				set{_depositCd = value;}
			}
			/// <summary>金種コード プロパティ</summary>
			public Int32 DepositKindCode
			{
				get{return _depositKindCode;}
				set{_depositKindCode = value;}
			}
			/// <summary>入金番号(更新後)</summary>
			public Int32 DepositSlipNo
			{
				get { return _depositSlipNo; }
				set { _depositSlipNo = value; }
			}

            // ↓ 20070131 18322 c MA.NS用に変更
			/// <summary>従業員名</summary>
			public string EmployeeName
			{
				get { return _employeeName; }
				set { _employeeName = value; }
			}
            // ↑ 20070131 18322 c

			/// <summary>銀行コード プロパティ</summary>
			public Int32 BankCode
			{
				get{return _bankCode;}
				set{_bankCode = value;}
			}

			/// <summary>銀行名称</summary>
			public string BankName
			{
				get { return _bankName; }
				set { _bankName = value; }
			}
			/// <summary>手形種類 プロパティ</summary>
			public Int32 DraftKind
			{
				get{return _draftKind;}
				set{_draftKind = value;}
			}

			/// <summary>手形種類名称</summary>
			public string DraftKindName
			{
				get { return _draftKindName; }
				set { _draftKindName = value; }
			}
			/// <summary>手形区分 プロパティ</summary>
			public Int32 DraftDivide
			{
				get{return _draftDivide;}
				set{_draftDivide = value;}
			}

			/// <summary>手形区分名称</summary>
			public string DraftDivideName
			{
				get { return _draftDivideName; }
				set { _draftDivideName = value; }
			}

			/// <summary>手形番号</summary>
			public string DraftNo
			{
				get { return _draftNo; }
				set { _draftNo = value; }
			}
            
            /// <summary>クローン</summary>
            public UpdateDepositParameter Clone()
            {
                UpdateDepositParameter ret = new UpdateDepositParameter();

                ret.EnterpriseCode = _enterpriseCode;
                ret.LoginSectionCode = _loginSectionCode;
                ret.AddSectionCode = _addSectionCode;
                ret.EmployeeCd = _employeeCd;
                ret.DepositDate = _depositDate;
                ret.DepositCd = _depositCd;
                ret.DepositKindCode = _depositKindCode;
                ret.DepositSlipNo = _depositSlipNo;
                // ↓ 20070131 18322 c MA.NS用に変更
                ret.EmployeeName = _employeeName;
                // ↑ 20070131 18322 c
                ret.BankCode = _bankCode;
                ret.BankName = _bankName;
                ret.DraftKind = _draftKind;
                ret.DraftKindName = _draftKindName;
                ret.DraftDivide = _draftDivide;
                ret.DraftDivideName = _draftDivideName; 
                ret.DraftNo = _draftNo;

                return ret;
            }
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            #endregion 2008/06/26 DEL Partsman用に変更
        }
		# endregion
	}
}
